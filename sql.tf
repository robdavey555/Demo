resource "azurerm_sql_server" "windows" {
  name                         = local.db_server
  resource_group_name          = azurerm_resource_group.windows.name
  location                     = azurerm_resource_group.windows.location
  version                      = "12.0"
  administrator_login          = var.sqluser
  administrator_login_password = var.sqlpassword

  tags = local.tags
}

resource "azurerm_sql_database" "windows" {
  name                = local.db_name
  resource_group_name = azurerm_resource_group.windows.name
  location            = azurerm_resource_group.windows.location
  server_name         = azurerm_sql_server.windows.name
  edition             = "Free"

  tags = local.tags
}

resource "azurerm_sql_firewall_rule" "windows" {
  name                = "AllowAllAzureIps"
  resource_group_name = azurerm_resource_group.windows.name
  server_name         = azurerm_sql_server.windows.name
  start_ip_address    = "0.0.0.0"
  end_ip_address      = "0.0.0.0"
}