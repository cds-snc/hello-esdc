# prepare values for app
data "template_file" "app_values" {
  template = "${file("${path.root}/templates/app.values.yaml.tpl")}"

  vars {
    # Ingress
    K8S_INGRESS_FQDN = "${azurerm_public_ip.ingress_ip.fqdn}"

    # Container Registry
    CR_ENDPOINT       = "${azurerm_container_registry.main.login_server}"
    CR_ADMIN_USERNAME = "${azurerm_container_registry.main.admin_username}"
    CR_ADMIN_PASSWORD = "${azurerm_container_registry.main.admin_password}"
  }
}

resource "local_file" "app_values" {
  content  = "${data.template_file.app_values.rendered}"
  filename = "${path.root}/../app.values.yaml"
}