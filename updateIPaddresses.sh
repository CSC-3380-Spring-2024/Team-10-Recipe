# #!/bin/bash

# # Check if jq is installed
# if ! command -v jq &> /dev/null; then
#     echo "jq could not be found. Please install jq using 'brew install jq'."
#     exit 1
# fi

# # Check if current directory is correct
# if [ ! -d "Recipe_Proj" ] || [ ! -d "Recipe_Proj.Server" ] || [ ! -d ".vscode" ]; then
#     echo "This script must be run from the Team-10-Recipe directory containing Recipe_Proj, Recipe_Proj.Server, and .vscode."
#     exit 1
# fi

# # Extract the second IP address from the ifconfig output
# IPADDRESS=$(ifconfig | grep inet | grep -v inet6 | awk 'NR==2 {print $2}')

# # Ensure an IP address was found
# if [ -z "$IPADDRESS" ]; then
#     echo "No IP address detected. Exiting..."
#     exit 1
# fi

# # Function to replace $IPADDRESS in a template file and write to target
# update_file_from_template() {
#     local template=$1
#     local target=$2
#     local ip=$3

#     if [ ! -f "$template" ]; then
#         echo "Template file $template not found."
#         return
#     fi

#     # Use sed to replace $IPADDRESS with the actual IP and write to the target file
#     sed "s/\$IPADDRESS/$ip/g" "$template" > "$target"
#     echo "Updated $target with IP $ip"
# }

# # Update files from their respective templates
# update_file_from_template "./.vscode/settings.json.template" "./.vscode/settings.json" "$IPADDRESS"
# update_file_from_template "./Recipe_Proj.Server/appsettings.json.template" "./Recipe_Proj.Server/appsettings.Development.json" "$IPADDRESS"
# update_file_from_template "./Recipe_Proj.Server/appsettings.json.template" "./Recipe_Proj.Server/appsettings.json" "$IPADDRESS"