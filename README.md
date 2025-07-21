
Processo para correr a API pela primeira vez.

Pré-requisitos:
-.NET SDK 8.0
-Visual Studio Code
-Extensão C# para o VS Code(Ou C# Dev Kit)
-SQL Server
-SQL Server Management Studio
-Git Bash

1. Clonar o repositório para a máquina local.
2. Abrir o repositório no VS Code.
3. Abrir um terminal bash no VS Code.
4. Executar os seguintes comandos:
	cd Backend
	dotnet restore
	dotnet tool install --global dotnet-ef

5. Alterar no ficheiro Backend\appsettings.json:
	Em ConnectionsStrings, DefaulConnection:
	Onde diz "Server=Desktop-C8RJFE8\\MSSQLSERVER2022"
	Deverá ser alterado para o servidor local da máquina que está a correr a API.
6. Executar os seguintes comandos no terminal bash:
	dotnet ef database update

Após isto para correr a API basta sempre apenas executar o comando:
	dotnet run

Para aceder ao Swagger, quando a API correr com sucesso deverá aparecer um endereço link para abrir no browser, por exemplo:
	"http://localhost:5152" 


