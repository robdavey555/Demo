locals {
  prefixdashed = join("-", [var.environment, var.projectname])
  prefix       = join("", [var.environment, var.projectname])
  db_server    = "${local.prefix}sqlserver"
  db_name      = "${local.prefixdashed}-db"
  db_connection = join("", ["Server=", local.db_server, ".database.windows.net;Database=", local.db_name, ";MultipleActiveResultSets=false;", "User ID=", var.sqluser ,";Password=", var.sqlpassword, ";Encrypt=false;"])


  tags = merge(
    var.extra_tags,
    {
      environment = local.prefixdashed
    },
  )
}