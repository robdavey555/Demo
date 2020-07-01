resource "azurerm_storage_account" "windows" {
  name                      = "${local.prefix}storage"
  resource_group_name       = azurerm_resource_group.windows.name
  location                  = azurerm_resource_group.windows.location
  account_tier              = "Standard"
  account_replication_type  = "LRS"
  enable_https_traffic_only = true

  tags = local.tags
}