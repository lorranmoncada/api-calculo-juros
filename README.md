# Indice

- [Sobre](#-sobre)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Como baixar o projeto](#-como-baixar-o-projeto)

## 🔖&nbsp; Sobre

A API  **Caculo de Juros Composto** consome a taxa de juros da api https://api-juros.herokuapp.com/swagger/index.html, e executa o calculo de juros composto em cima do juros obtido e também possue um endpoint que retorna o repositório dos condigos fonte de ambas as Apis Rest
A Api se encotra no Heroku - https://www.heroku.com
---
Url no Swagger: https://api-calculo-juros.herokuapp.com/swagger/index.html
Url da api : https://api-calculo-juros.herokuapp.com

---

## 🚀 Tecnologias utilizadas

O projeto foi desenvolvido utilizando as seguintes tecnologias

- [NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

---

## 🚀 Packages utilizadas

O projeto foi desenvolvido utilizando os seguintes packages

-  Microsoft.VisualStudio.Azure.Containers.Tools.Targets
-  Refit.HttpClientFactory
-  Serilog.Extensions.Logging.File
-  Swashbuckle.AspNetCore
-  FluentValidation
-  Newtonsoft.Json
-  Refit

---

## 🗂 Como baixar o projeto

```bash

    # Clonar o repositório
    $ git clone https://github.com/lorranmoncada/api-calculo-juros.git

    # Entrar no diretório
    $ cd api-calculo-juros-main\api-calculo-juros-main

    # Instalar as dependências
    $ Clean Solution
    $ Compile Solution

```
---

Observações: 
- Foi utilizado o Docker para subir a aplicação no cloud do Heroku
- Foi utilizado o Refit para a comunicação entre a API de Taxa de Juros e do GitHub
- Como alternativa também pode se usado o RabbitMQ , MSMQ assim como o ZeroMQ
- Não ouve necessidade de utilização do autoMapper para o mapeamento dos meus objetos 
de dominio para minha view model, ja que os objetos de response não possuiam uma estrutura complexa.

---

Desenvolvido por Lorran Mendes  😀 
