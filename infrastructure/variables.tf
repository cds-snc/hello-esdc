variable "client_id" {}
variable "client_secret" {}

variable "agent_count" {
    default = 3
}

variable "ssh_public_key" {
    default = "~/.ssh/id_rsa.pub"
}

variable "dns_prefix" {
    default = "hello-esdc-k8stest"
}

variable cluster_name {
    default = "hello-esdc-k8stest"
}

variable resource_group_name {
    default = "hello-esdc-k8stest"
}

variable location {
    default = "Canada Central"
}

variable log_analytics_workspace_name {
    default = "HelloESDCLogAnalyticsWorkspace"
}

# refer https://azure.microsoft.com/global-infrastructure/services/?products=monitor for log analytics available regions
variable log_analytics_workspace_location {
    default = "canadacentral"
}

# refer https://azure.microsoft.com/pricing/details/monitor/ for log analytics pricing 
variable log_analytics_workspace_sku {
    default = "PerGB2018"
}

variable db_name {
    default = "helloesdcdb"
}

variable db_admin_login {
  
}

variable "db_admin_password" {
  
}

