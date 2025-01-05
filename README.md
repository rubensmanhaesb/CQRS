# TarefasApp

Implementação do CQRS utilizando Angular, .NET, SQL Server, MongoDB, Docker, Azure e RabbitMQ)
O projeto utiliza o conceito de **CI/CD** (Integração Contínua e Entrega Contínua), 
práticas que automatizam a integração, teste e entrega de código em um ambiente de produção de
forma contínua. Além disso, o projeto pode ser executado localmente utilizando Docker.

- Utiliza os Patterns Mediator (Mediatr) e Command
- NugetPackages.docx  - contém as extensões utilizadas nos projetos em Angular e em .NET (Nuget) 
- Configurações estão no appsettings.


Caso tenha dúvidas, entre em contato através do e-mail: rubensmanhaesb@hotmail.com
Você também pode conectar-se comigo no [LinkedIn](https://www.linkedin.com/in/rubens-bernardes-1b6769a7/).

## **Instruções para Execução**

### **Localmente (Docker)**
- Certifique-se de ter o Docker instalado. Baixe o Docker Desktop em: https://www.docker.com/products/docker-desktop
- Na pasta raiz do projeto (onde está o arquivo 'TarefasApp.sln'), execute o comando: **docker-compose up -d**
- Banco de Dados - rodar a migration ou executar o arquivo Script.Sql (localizado na pasta raiz do projeto)

### **No Azure**
- A API TarefasApp.API do projeto está publicada no Azure em: https://cqrs.azurewebsites.net/swagger/index.html
- A API UsuairiosApp.API do projeto está publicada no Azure em: https://usuarioscqrs.azurewebsites.net/swagger/index.html
## **Limitações da Versão Atual**
Este projeto foi desenvolvido como parte de um desafio técnico e adota diversas práticas modernas de desenvolvimento. No entanto, a versão atual inclui a implementação de Autenticação e Autorização.

### **Possíveis Melhorias Futuras**
Caso o projeto seja continuado, as seguintes melhorias poderiam ser implementadas:

### **Autenticação e Autorização:**

Desenvolver o front-end em MAUI disponibilizando para mobile.
Configurações Seguras:

Remoção do appsettings.production.json e substituição por variáveis de ambiente configuradas no Azure, garantindo maior segurança e seguindo boas práticas para gerenciamento de configurações sensíveis.

## Requisitos

-  Angular
- .NET 8 SDK
- Visual Studio 2022 ou superior
- Docker (Opcional)
- SQL Server (ou outro banco de dados configurado)
- RabbitMQ
- MongoDB

## Funcionalidades

- Gerenciamento de tarefas
- Autenticação e Autorização
- CRUD de tarefas 
- API RESTful para interação com as tarefas
- Implementação de princípios DDD e TDD para desenvolvimento orientado a testes
- CI/CD


## Tecnologias Utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- XUnit (Framework de Testes)
- Domain-Driven Design (DDD)
- Test-Driven Development (TDD)
- MicroServiços
- RabbitMQ (Mensageria)
- Github Actions (CI /CD) -- dois projetos na mesma pipe --

## Principais Ferramentas e Bibliotecas

1.	.Angular:
2.	.NET 8:
3.	C# 12.0:
4.	ASP.NET Core:
5.	Middleware:
6.	Exceções Personalizadas:
7.	Serialização JSON:
8.	HTTP:
9.	RabbitMQ:
10.	MongoDB:
11.	Docker:
12.	Teste unitário:
13.	Teste de integração:

## Estrutura do Projeto

- TarefasWeb (Angular)
- UsuariosApp.API (.NET): Gerencia autenticação e usuários.
- TarefasApp.API (.NET): Responsável pela gestão de tarefas.
- Microsoft.AspNetCore.App: Inclui todos os pacotes necessários para construir uma aplicação ASP.NET Core.
- System.Text.Json: Para serialização e desserialização de JSON.
- Microsoft.Extensions.Logging: Para logging dentro da aplicação.
- Microsoft.AspNetCore.Http: Para manipulação de requisições e respostas HTTP.
- TarefasApp.Domain:  Define as regras de negócio e entidades do domínio.
- System.ComponentModel.Annotations: Para validações e anotações de dados.
- FluentValidation: Para validações de regras de negócio e entidade.
- Microsoft.AspNetCore.Authentication.JwtBearer: Para implementar autenticação baseada em tokens JWT (JSON Web Tokens).
- FluentAssertions: Para facilitar asserções em testes, permitindo escrita de testes mais expressivos e legíveis.
- TarefasApp.Infrastructure
- MongoDB.Driver: Para interação com o MongoDB.
- RabbitMQ.Client: Para interação com o RabbitMQ.
- TarefasApp.Tests
	- xUnit: Framework de testes unitários.
	- Moq: Para criação de mocks em testes.
	- Microsoft.AspNetCore.Mvc.Testing: Para testes de integração em aplicações ASP.NET Core.

## Detalhamento da Estrutura do Projeto

1. TarefasApp.API - Este projeto é a API principal do sistema, responsável por expor endpoints HTTP para interagir com o sistema. Ele utiliza o .NET 8 e é configurado para diferentes ambientes (Desenvolvimento e Produção) através de arquivos appsettings.
	-	Principais Responsabilidades:
		-	Expor endpoints RESTful para operações de leitura e escrita.
		-	Configurar dependências como SQL Server, MongoDB, RabbitMQ e serviços de email.
		-	Implementar middleware para CORS, autenticação, autorização e logging.
2. TarefasApp.Application - Este projeto contém a lógica de aplicação, incluindo os handlers para comandos e queries. Ele segue o padrão CQRS para separar as responsabilidades de leitura e escrita.
	-	Principais Responsabilidades:
		-	Definir comandos (commands) e consultas (queries).
		-	Implementar handlers para processar comandos e consultas.
		-	Orquestrar a lógica de negócios e interagir com os repositórios.
3. TarefasApp.Domain - Este projeto contém as entidades de domínio e as regras de negócio. Ele é independente de qualquer tecnologia de persistência ou infraestrutura.
	-	Principais Responsabilidades:
		-	Definir entidades de domínio e agregados.
		-	Implementar regras de negócio e validações.
		-	Definir eventos de domínio.
4. TarefasApp.Infrastructure - Este projeto contém a implementação de infraestrutura, como repositórios, contextos de banco de dados e integrações com serviços externos.
	-	Principais Responsabilidades:
		-	Implementar repositórios para acesso a dados (SQL Server, MongoDB).
		-	Configurar contextos de banco de dados e mapeamentos ORM.
		-	Integrar com serviços externos como RabbitMQ e provedores de email.
5. TarefasApp.Tests - Este projeto contém testes automatizados para garantir a qualidade e a funcionalidade do sistema. Ele pode incluir testes unitários, de integração e de aceitação.
	-	Principais Responsabilidades:
		-	Implementar testes unitários para a lógica de aplicação e domínio.
		-	Implementar testes de integração para verificar a interação entre componentes.
		-	Implementar testes de aceitação para validar cenários de uso completos.
6. TarefasWeb - Este projeto é a aplicação front-end, é uma aplicação Angular, que interage com a API para fornecer uma interface de usuário.
	-	Principais Responsabilidades:
		-	Implementar a interface de usuário para interagir com a API.
		-	Gerenciar estado e navegação da aplicação.
		-	Consumir endpoints da API para operações de leitura e escrita.
7. UsuarioApp.API - Este projeto é a API responsável por gerar e gerenciar usuários na geração de tokens no padrão JWT. Ele utiliza o .NET 8 e é configurado para diferentes ambientes (Desenvolvimento e Produção) através de arquivos appsettings.
    - Principais Responsabilidades:
        - Expor endpoints RESTful para operações de leitura e escrita de usuários.
        - Implementar geração de tokens utilizando JWT.
		