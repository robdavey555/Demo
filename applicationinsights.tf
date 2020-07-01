resource "azurerm_application_insights" "eintech" {
  name                = "${local.prefixdashed}-eintechdemo"
  location            = azurerm_resource_group.windows.location
  resource_group_name = azurerm_resource_group.windows.name
  application_type    = "web"

  tags = local.tags
}
