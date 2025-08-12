Este repositório contém o código-fonte do meu projeto final de licenciatura do curso de Engenharia Informática na UTAD. Trata-se de uma API RESTful completa, desenvolvida com .NET 8, que serve como backend para uma plataforma de gestão de propostas de projetos, candidaturas e interações entre alunos e orientadores no contexto académico.


Funcionalidades Principais
Gestão Completa de Propostas: Operações CRUD (Create, Read, Update, Delete) para propostas de projetos.

Sistema de Consulta Avançado: A API suporta funcionalidades de filtragem, ordenação e paginação dinâmicas do lado do servidor para garantir a máxima performance, mesmo com grandes volumes de dados(Devido à gestão de tempo, foi aplicado parcialmente no mais importante).

Autenticação e Autorização: Sistema de segurança robusto baseado em tokens JWT, com endpoints públicos e rotas protegidas que requerem autenticação.

Sistema de Interação Social: Funcionalidade de "like/unlike" em propostas, com lógica de negócio para garantir que um utilizador só pode interagir uma vez.

Documentação Interativa: Geração automática de documentação da API com Swagger/OpenAPI para facilitar os testes e a integração com um frontend.

O projeto foi desenvolvido com foco na criação de uma arquitetura limpa, escalável e segura, aplicando as melhores práticas da indústria de desenvolvimento de software.
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



