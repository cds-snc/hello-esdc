# service principal for aks
resource "azurerm_azuread_application" "k8s" {
  name = "hello-esdc-${var.environment}-aks"
}

resource "azurerm_azuread_service_principal" "k8s" {
  application_id = "${azurerm_azuread_application.k8s.application_id}"
}

resource "random_string" "aks-principal-secret" {
  length  = 30
  special = true
}

resource "azurerm_azuread_service_principal_password" "k8s" {
  service_principal_id = "${azurerm_azuread_service_principal.k8s.id}"
  value                = "${random_string.aks-principal-secret.result}"
  end_date             = "2100-01-01T00:00:00Z"
}

resource "azurerm_role_assignment" "aks-network-contributor" {
  scope                = "${azurerm_resource_group.main.id}"
  role_definition_name = "Network Contributor"
  principal_id         = "${azurerm_azuread_service_principal.k8s.id}"
}

resource "azurerm_kubernetes_cluster" "k8s" {
    name                = "${var.cluster_name}"
    location            = "${azurerm_resource_group.main.location}"
    resource_group_name = "${azurerm_resource_group.main.name}"

    depends_on = [
        "azurerm_role_assignment.aks-network-contributor",
        "azurerm_public_ip.ingress_ip"
    ]

    dns_prefix          = "${var.dns_prefix}"

    linux_profile {
        admin_username = "ubuntu"

        ssh_key {
            key_data = "${file("${var.ssh_public_key}")}"
        }
    }

    agent_pool_profile {
        name            = "agentpool"
        count           = "${var.agent_count}"
        vm_size         = "Standard_DS1_v2"
        os_type         = "Linux"
        os_disk_size_gb = 30
    }

    service_principal {
        client_id     = "${azurerm_azuread_application.k8s.application_id}"
        client_secret = "${azurerm_azuread_service_principal_password.k8s.value}"
    }

    tags {
        Project = "Hello ESDC"
        Environment = "Development"
    }
}

# kube config and helm init
resource "local_file" "kube_config" {
  # kube config
  filename = "${var.k8s_kube_config}"
  content  = "${azurerm_kubernetes_cluster.k8s.kube_config_raw}"

  # helm init
  provisioner "local-exec" {
    command = "helm init --client-only"
    environment {
      KUBECONFIG = "${var.k8s_kube_config}"
      HELM_HOME  = "${var.k8s_helm_home}"
    }
  }
}
