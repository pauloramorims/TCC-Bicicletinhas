# TCC-Bicicletinhas

*CONFIGURAÇÃO - BACKEND*

1 → Instalar ou estar instalado
     - .Net 6.0 (https://dotnet.microsoft.com/en-us/download/dotnet/6.0);
     - SQLServer 2017 (https://go.microsoft.com/fwlink/?linkid=853016);
     - Microsoft SQL Server Management Studio 18 ou outra IDE compatível com SQLServer 2017;
     
2 → Appsettings.json
     -Abrir o arquivo appsettings.Development.json do projeto TirandoAsRodinhas
        -Configurar a string de conexão "BiciSemRodinhas", alterando o ID e o Password para o padrão que seu SQLServer 
         está configurado (User Id=  ;Password= )        

3 → Entity Framework Core
     -No powershell ou  cmd 
        → entrar no local que está o projeto, utilizando o comando: cd "endereco da pasta" (...\TCC-Bicicletas\TirandoAsRodinhas)
        → dotnet tool install --global dotnet-ef
        → dotnet ef database update

4 → Realizar o script de população e criação de View no Banco de Dados
     - Arquivo Popular.sql ...\TCC-Bicicletas\Popular.sql
     - Arquivo ViewParceiros.sql ...\TCC-Bicicletas\ViewParceiros.sql
    
