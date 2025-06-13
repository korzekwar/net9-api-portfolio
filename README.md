# API RESTful com ASP.NET Core 9 e Docker

Projeto de portfólio que demonstra a construção de uma API RESTful completa, seguindo as melhores práticas de desenvolvimento, arquitetura e segurança.

## Funcionalidades

-   **Autenticação JWT:** Endpoints seguros utilizando JSON Web Tokens.
-   **Arquitetura Limpa (simplificada):** Separação de responsabilidades em projetos Core, Infrastructure e API.
-   **Operações CRUD:** Implementação completa de `POST`, `GET`, `PATCH` e `DELETE` para manipulação de recursos.
-   **Persistência de Dados:** Uso do Entity Framework Core com PostgreSQL.
-   **Ambiente Containerizado:** Aplicação e banco de dados totalmente gerenciados por Docker e Docker Compose para um setup de desenvolvimento simplificado.
-   **Testes Automatizados:** Cobertura de testes unitários (xUnit e Moq) e um exemplo de teste de integração com `HttpClient`.
-   **Documentação de API:** Geração automática de documentação interativa com Swagger/OpenAPI.

---

## Tecnologias Utilizadas

-   **Backend:** .NET 9, ASP.NET Core
-   **Banco de Dados:** PostgreSQL
-   **ORM:** Entity Framework Core 9
-   **Testes:** xUnit, Moq
-   **Containerização:** Docker, Docker Compose
-   **Autenticação:** JWT (JSON Web Tokens)
-   **Documentação:** Swashbuckle.AspNetCore (Swagger)

---

## Pré-requisitos

-   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
-   [Docker Desktop](https://www.docker.com/products/docker-desktop)

---

## Como Executar o Sistema Localmente

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/korzekwar/net9-api-portfolio.git
    cd net9-api-portfolio
    ```

2.  **Execute o Docker Compose:**
    Este comando irá construir a imagem da API, iniciar os contêineres da API e do banco de dados, e aplicar as migrações automaticamente.
    ```bash
    docker-compose up --build
    ```

A API estará disponível em `http://localhost:8080`.

---

## Como Testar os Endpoints via Swagger

1.  Após a inicialização dos contêineres, acesse a interface do Swagger no seu navegador:
    > [http://localhost:8080/swagger](http://localhost:8080/swagger)

2.  **Obtendo o Token de Autenticação:**
    -   Nos endpoints do `AuthController`, expanda a rota `POST /api/Auth/login`.
    -   Clique em "Try it out".
    -   No corpo da requisição, use as seguintes credenciais de exemplo:
        ```json
        {
          "username": "admin",
          "password": "password"
        }
        ```
    -   Clique em "Execute". Copie o `token` JWT retornado na resposta.

3.  **Autorizando Requisições:**
    -   No topo da página do Swagger, clique no botão **"Authorize"**.
    -   Na janela que abrir, cole o token que você copiou no campo "Value", e clique em "Authorize".
    -   Feche a janela.

Agora você está autenticado! Todos os endpoints com cadeado (como os do `ProductsController`) podem ser executados com sucesso.

---

## Como Rodar os Testes

Para executar a suíte de testes unitários e de integração, pare os contêineres (`Ctrl+C` no terminal) e execute o seguinte comando na pasta raiz do projeto:

```bash
dotnet test
```