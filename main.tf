provider "azurerm" {
  version = "=2.1.0"
  features {}
}

terraform {
  required_version = "0.12.24"
  backend "azurerm" {
  }
}