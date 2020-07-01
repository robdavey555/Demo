variable "projectname" {
  type    = string
  default = "eintech"
}

variable "environment" {
  type    = string
  default = "demo"
}

variable "location" {
  type    = string
  default = "westeurope"
}

variable "aspTier" {
  description = "Tier used for App Service Plans e.g. Standard"
  type        = string
  default     = "Free"
}

variable "aspSize" {
  description = "Size used for App Service Plans e.g. S1"
  type        = string
  default     = "F1"
}

variable "sqluser" {
  type    = string
  default = "4dm1n157r470r" ##move to key vault in the real world
}

variable "sqlpassword" {
  type    = string
  default = "4-v3ry-53cr37-p455w0rd" ##move to key vault in the real world
}


variable "extra_tags" {
  type        = map(string)
  description = ""

  default = {
    maintained_by = "terraform"
  }
}

## Application Insights Settings
variable "app_settings" {
  type        = map(string)
  description = ""

  default = {
    APPINSIGHTS_PROFILERFEATURE_VERSION             = "1.0.0"
    APPINSIGHTS_SNAPSHOTFEATURE_VERSION             = "1.0.0"
    ApplicationInsightsAgent_EXTENSION_VERSION      = "~2"
    DiagnosticServices_EXTENSION_VERSION            = "~3"
    InstrumentationEngine_EXTENSION_VERSION         = "disabled"
    SnapshotDebugger_EXTENSION_VERSION              = "disabled"
    XDT_MicrosoftApplicationInsights_BaseExtensions = "~1"
    XDT_MicrosoftApplicationInsights_Mode           = "recommended"
  }
}
