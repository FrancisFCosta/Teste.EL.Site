# Teste.EL.Site

O Projeto representa a interfaceWeb criada para atender um cenário hipotético de uma locadora de veículos. Duvidas sobre o relacionamento entre as entidades podem ser esclarecidas na seção Diagrama de classes.  Mais informações sobre o funcionamento podem ser verificadas na seção Resquisitos do projeto. 

## Web-To-Case Salesforce 

Foi realizada a implementação da criação de casos no salesforce para os usuários darem um feedback de suas reservas. Para isso foi realizada a configuração da pagina Web-to-Case no salesforce, que por sua vez recebe o formulario e realiza a criação do caso que pode ser acompanhado por meio da ferramente Service Cloud. Exemplo abaixo:

• Formulário no site:


![alt text](https://github.com/FrancisFCosta/Teste.EL.Site/blob/main/FormularioWebSite.png?raw=true)

• Caso criado no Salesforce:


![alt text](https://github.com/FrancisFCosta/Teste.EL.Site/blob/main/ExemploCasoCriado.png?raw=true)

## Decisões Técnicas

• Optou-se por desenvolver uma a interface Web utilizando framework ASP.NET Core MVC.


• Estrutura da Solução criada adotando um modelo de três camadas: Interface UI (Projeto Web), Camada de negócio (Projeto Business) e Camada de Acesso a Dados (Projeto Interface). Com essa configuração é possivel implementar de forma simples a segregação de responsabilidades por camada. 


• Para trafego das informações está sendo utilizado o pattern Data Transfer Object (DTO), implementado no Projeto Entidades.


• Implementando Autenticação e Autorização no esquema Bearer Authentication + JWT. 

## Diagrama de classes

Para melhor entendimento de como estão relacionadas as entidades do domínio, foi criado um diagrama de classes para compor esta documentação.

![alt text](https://github.com/FrancisFCosta/Teste.EL.NucleoAluguel.API/blob/master/NucleoAluguel_DiagramaDeClasses.png?raw=true)

## Requisitos do projeto

• Disponibilizar o Site para que o cliente visualize os veículos por categorias, realize o cadastro e efetue a locação do veículo


• O Site deverá exibir os veículos disponíveis para locação 


• Disponibilizar um formulário de simulação de locação com base no veículo selecionado, valor hora do veículo, total de horas. Caso o cliente confirme, validar\realizar o login para a simulação se tornar uma reserva 


• Caso o CPF ainda não esteja na base de dados, realizar o cadastro de cliente informando os dados conforme especificação Serviço Web


• Listar as locações já realizadas pelo cliente por data 
