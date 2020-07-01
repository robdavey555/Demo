resource "azurerm_app_service_plan" "windows" {
  name                = "${local.prefixdashed}-windows-asp"
  location            = azurerm_resource_group.windows.location
  resource_group_name = azurerm_resource_group.windows.name

  sku {
    tier = var.aspTier
    size = var.aspSize
  }

  tags = local.tags
}