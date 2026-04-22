# CRUD-AspNet-WebForm-MySQL

Exemplo de criação CRUD C# WebForms com banco de dados MySQL.

## O que voçê vai ver nesse Projeto

- **MySQL Command** - Comunicação com o Banco de dados
- **MultiView** - Criação de Abas para navegação
- **SelectedIndexChanged** - Seleções de registros com Click 
- **Blob** - Seleção de Arquivos de imagens, gravação e visualização

## Execução da aplicação

Para executar a aplicação é necessário rodar Script banco de dados e Compilar o Projeto

## String de conexão do banco

Modifique a string de conexão no arquivo **app.config**, no trecho indicado:

```bash
...
    connectionString="server=127.0.0.1;userid=root;password=SUASENHA;database=webform;persistsecurityinfo=True;"
...

```
O script para criação da tabela do exemplo encontra-se na pasta **Database**.

### Aqui está uma demonstração do Projeto

<img width="1106" height="574" alt="WebForm-CRUD-MySql" src="https://github.com/user-attachments/assets/a3eafec4-1d72-4bd6-be12-45f7cfbea727" />



