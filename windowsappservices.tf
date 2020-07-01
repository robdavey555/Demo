resource "azurerm_app_service" "eintechapp" {
  name                = "${local.prefixdashed}-eintechapp"
  location            = azurerm_resource_group.windows.location
  resource_group_name = azurerm_resource_group.windows.name
  app_service_plan_id = azurerm_app_service_plan.windows.id
  https_only          = false

  app_settings = merge(
    var.app_settings,
    map(
      "APPINSIGHTS_INSTRUMENTATIONKEY", azurerm_application_insights.eintech.instrumentation_key,
      "SCM_COMMAND_IDLE_TIMEOUT", "10000"
  ))

  tags = local.tags  
}