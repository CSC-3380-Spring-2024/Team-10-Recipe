# Team-10

## API finished (Recipe_Proj.Server)

### Client Url:
localhost:5155/

### Api Url:
localhost:5123/swagger/index.html



### Need to update IP address in 
                            .vscode/settings.json, 
                            Recipe_Proj.Server/appsettings.Development.json
                            and Recipe_Proj.Server/appsettings.Development.json

#### command to get IP address to connect to
ifconfig | grep inet | grep -v inet6 | awk '{print $2}'

Alex's house: 192.168.0.220
Alex's Hotspot: 172.20.10.2
