CRUD C# – Interface Gráfica (Windows Forms)

Este projeto é uma aplicação CRUD (Create, Read, Update, Delete) desenvolvida em C# com Windows Forms, utilizando MySQL como banco de dados. O objetivo é praticar conceitos de POO, camada DAO, conexão com banco de dados e interfaces gráficas no .NET.

🛠️ Tecnologias utilizadas

	•	C#
  
	•	.NET (Windows Forms)
  
	•	MySQL
  
	•	ADO.NET
  
	•	Git e GitHub
	
🧰 Ferramentas necessárias

Visual Studio (para executar e editar o projeto)

XAMPP (para gerenciar o servidor MySQL)

MySQL (banco de dados)

Git (opcional, para versionamento)

📌 Funcionalidades

	•	Cadastro de contatos
  
	•	Listagem de registros
  
	•	Atualização de dados
  
	•	Exclusão de registros
  
	•	Interface gráfica para interação com o usuário

🧱 Estrutura do projeto

	•	Contato.cs → Classe modelo (entidade)
  
	•	ContatoDAO.cs → Camada de acesso a dados (DAO)
  
	•	ConnectionFactory.cs → Responsável pela conexão com o banco de dados
  
	•	Form1.cs → Interface gráfica e regras de interação
  
	•	Program.cs → Inicialização da aplicação

🗄️ Banco de Dados

O projeto utiliza MySQL, acessado via ADO.NET, seguindo boas práticas como separação de responsabilidades e reutilização de conexão.

## ▶️ Como executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/pinaciolopes/Crud-C--InterfaceGrafica.git

2.	Abra o arquivo .sln no Visual Studio

3.	Configure a string de conexão no arquivo ConnectionFactory.cs

4.	Execute o projeto pressionando F5 ou clicando em Iniciar

🎯 Objetivo do projeto

Projeto desenvolvido com fins educacionais, focado em consolidar conhecimentos em C#, Windows Forms, CRUD, banco de dados e arquitetura básica de software.

👨‍💻 Autor

Pablo Phelipe Inácio Lopes
Desenvolvedor em formação.
