provider "azurerm" {
    version = "~>1.5"
}

#terraform {
#    backend "azurerm" {
#        storage_account_name = "helloesdctf"
#        container_name = "tfstate"
#        key = "dev.terraform.tfstate"
#    }
#}

resource "azurerm_resource_group" "main" {
    name     = "${var.resource_group_name}"
    location = "${var.location}"

    tags {
        project = "hello-esdc"
        environment = "${var.environment}"
    }
}

# container registry
resource "azurerm_container_registry" "main" {
  name                = "helloesdc${var.environment}cr"
  resource_group_name = "${azurerm_resource_group.main.name}"
  location            = "${azurerm_resource_group.main.location}"

  admin_enabled = true
  sku = "Basic"

  tags {
    project = "hello-esdc"
    environment = "${var.environment}"
  }

  # perform docker login
  provisioner "local-exec" {
    command = "sleep 5 && echo '${azurerm_container_registry.main.admin_password}' | docker login '${azurerm_container_registry.main.login_server}' --username '${azurerm_container_registry.main.admin_username}' --password-stdin"
    interpreter = [ "bash", "-c" ]
  }
}
