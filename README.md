#Game Store API


## starting SQL Server
```powershell
$sa_password = "{SA PASSWORD}"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433 -v sqlvolume:/var/opt/mssql  --name sqlpreview --hostname sqlpreview -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```
#   G a m e S t o r e A p i  
 #   G a m e S t o r e A p i  
 