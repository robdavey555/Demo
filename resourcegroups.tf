resource "azurerm_resource_group" "windows" {
  name     = "${local.prefixdashed}-windows"
  location = var.location

  tags = local.tags
}