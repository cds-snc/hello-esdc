output "client_key" {
    value = "${azurerm_kubernetes_cluster.k8s.kube_config.0.client_key}"
}

output "client_certificate" {
    value = "${azurerm_kubernetes_cluster.k8s.kube_config.0.client_certificate}"
}

output "cluster_ca_certificate" {
    value = "${azurerm_kubernetes_cluster.k8s.kube_config.0.cluster_ca_certificate}"
}

output "cluster_username" {
    value = "${azurerm_kubernetes_cluster.k8s.kube_config.0.username}"
}

output "cluster_password" {
    value = "${azurerm_kubernetes_cluster.k8s.kube_config.0.password}"
}

output "kube_config" {
    value = "${azurerm_kubernetes_cluster.k8s.kube_config_raw}"
}

output "host" {
    value = "${azurerm_kubernetes_cluster.k8s.kube_config.0.host}"
}

output "k8s_ingress_fqdn" {
    value = "${azurerm_public_ip.ingress_ip.fqdn}"
    description = "Kubernetes Ingress FQDN"
}

/*
 * Container Registry
 */

output "CR_ENDPOINT" {
  value       = "${azurerm_container_registry.main.login_server}"
  description = "Container Registry Endpoint"
}

output "CR_ADMIN_USERNAME" {
  value       = "${azurerm_container_registry.main.admin_username}"
  description = "Container Registry Admin Username"
}

output "CR_ADMIN_PASSWORD" {
  value       = "${azurerm_container_registry.main.admin_password}"
  description = "Container Registry Admin Password"
  sensitive   = true
}