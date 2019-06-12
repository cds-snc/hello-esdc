resource "azurerm_postgresql_server" "hello-esdc-db-server" {
  name                = "hello-esdc-db-server-1"
  location            = "${azurerm_resource_group.k8s.location}"
  resource_group_name = "${azurerm_resource_group.k8s.name}"

  sku {
    name     = "B_Gen5_2"
    capacity = 2
    tier     = "Basic"
    family   = "Gen5"
  }

  storage_profile {
    storage_mb            = 5120
    backup_retention_days = 7
    geo_redundant_backup  = "Disabled"
  }

  administrator_login          = "${var.db_admin_login}"
  administrator_login_password = "${var.db_admin_password}"
  version                      = "9.5"
  ssl_enforcement              = "Enabled"
}

resource "azurerm_postgresql_database" "hello-esdc-db-server" {
  name                = "helloesdcdb"
  resource_group_name = "${azurerm_resource_group.k8s.name}"
  server_name         = "${azurerm_postgresql_server.hello-esdc-db-server.name}"
  charset             = "UTF8"
  collation           = "English_United States.1252"
}