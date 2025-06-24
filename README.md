
<div align="center">

# 🚀 Desafio: Gerenciador de Tarefas - .NET

🔧 Projeto desenvolvido para o desafio [Gerenciador de Tarefas](https://efficient-sloth-d85.notion.site/Desafio-pr-tico-Gerenciador-de-tarefas-8dc106b6b7f54ec7ae31f1cbd5a4dc3e) da [Rocketseat](https://www.rocketseat.com.br/).
🎯 O objetivo é construir uma API RESTful em .NET 8 aplicando boas práticas de arquitetura, injeção de dependência e padrões de projeto.

</div>

---

## 🧩 Funcionalidades

| Método | Rota                     | Descrição                           |
|--------|---------------------------|--------------------------------------|
| POST   | `/api/task`               | Criar uma nova tarefa               |
| GET    | `/api/task`               | Listar todas as tarefas             |
| GET    | `/api/task/{id}`          | Obter uma tarefa por ID             |
| PUT    | `/api/task/{id}`          | Atualizar uma tarefa                |
| DELETE | `/api/task/{id}`          | Deletar uma tarefa                  |

---

## 🧠 Tecnologias e Conceitos Praticados

✔️ .NET 8 e C#  
✔️ ASP.NET Core Web API  
✔️ Clean Code  
✔️ Repository Pattern (In Memory)  
✔️ Documentação Swagger/OpenAPI  
✔️ Data Transfer Objects (DTO)  
✔️ Boas práticas com Enums e validação  

---

## ▶️ Como Executar

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/seu-repositorio.git

# Acesse a pasta do projeto
cd seu-repositorio

# Restaure os pacotes
dotnet restore

# Execute o projeto
dotnet run
```

Acesse o Swagger em:  
👉 `https://localhost:{porta}/swagger`

---

## 🗂️ Estrutura de Arquivos

```
.
├── TaskManager.API               // Camada de API (Controllers, Program, Swagger)
├── TaskManager.Application       // Casos de uso, entidades e repositórios
├── TaskManager.Communication     // DTOs, Requests, Responses e Enums
├── TaskManager.Utilities         // Camada para classes globais
```

---

## 💻 Requisitos

- [.NET SDK 8.0 ou superior](https://dotnet.microsoft.com/download)

---

## 🙌 Créditos

Desenvolvido por [Jonny Yamagushi](https://github.com/JonnyYamagushi) como parte do [Desafio: Gerenciador de Tarefas](https://efficient-sloth-d85.notion.site/Desafio-pr-tico-Gerenciador-de-tarefas-8dc106b6b7f54ec7ae31f1cbd5a4dc3e) da [Rocketseat](https://www.rocketseat.com.br/).

---

## 📄 Licença

Este projeto está licenciado sob a **MIT License**.  
Sinta-se livre para usar, estudar, modificar e distribuir.
