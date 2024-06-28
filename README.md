
# HospedaBem

Um sistema web para agendamento de hospedagem em hoteis.

## Membros

- André Luiz (backend)
- Lucas Carvalho (backend)
- Erico Colen (fullstack)
- Victor Castro (fullstack)

## Escopo

### Para Clientes (Viajantes):

- Pesquisa de Acomodações: Os clientes podem pesquisar por acomodações utilizando diversos critérios, como localização, datas de estadia, número de hóspedes,  preço e avaliação.

- Reserva de Acomodações: Após encontrar uma acomodação desejada, os clientes podem realizar a reserva diretamente através da plataforma, garantindo assim a disponibilidade da hospedagem para as datas desejadas.

- Perfil do Cliente: Cada cliente terá um perfil onde poderá gerenciar suas reservas, histórico de viagens e preferências de hospedagem.

- Avaliações e Comentários: Os clientes podem deixar avaliações e comentários sobre as acomodações que utilizaram, ajudando assim outros viajantes na escolha de suas hospedagens.


### Para Hotéis (Estabelecimentos Hoteleiros):

- Gerenciamento de Acomodações: Os hotéis podem cadastrar suas acomodações na plataforma, especificando detalhes como tipo de quarto, disponibilidade, preços, entre outros.

- Gestão de Reservas: Os hotéis podem visualizar e gerenciar as reservas feitas pelos clientes, podendo aceitar, recusar ou modificar as solicitações de reserva.

- Perfil do Hotel: Cada hotel terá um perfil onde poderá gerenciar suas informações de contato, políticas de hospedagem e responder às avaliações dos clientes.

## Tecnologias

- Back-end: .NET 7
- Front-end: .NET Razor
- Banco de dados: SQLite

## Backlog do produto
1. Como viajante, gostaria de pesquisar acomodações disponíveis em um hotel.
2. Como viajante, gostaria de pesquisar acomodações disponíveis em um certo intervalo de dias.
3. Como viajante, gostaria de pesquisar acomodações disponíveis em uma cidade.
3. Como viajante, gostaria de filtar minhas pesquisas de acordo com uma faixa de preço.
4. Como viajante, gostaria de filtrar acomodações de acordo com uma faixa de notas de avaliação.
5. Como viajante, gostaria de reservar uma acomodação em um hotel.
6. Como viajante, gostaria de editar e cancelar uma acomodação já reservada.
7. Como viajante, gostaria de avaliar um hotel após minha hospedagem.
8. Como viajante, gostaria de fazer perguntas para os hotéis sobre suas acomodações.
8. Como viajante, gostaria de editar e deletar minhas avaliações de minhas hospedagens.
9. Como viajante, gostaria de me cadastrar no sistema e ter uma página de perfil.
10. Como viajante, gostaria de editar e deletar meu perfil no sistema.
11. Como gerente de um hotel, gostaria de me cadastar no sistema e ter uma página de hospedagem no sistema.
12. Como gerente de um hotel, gostaria de editar e deletar minha página de hospedagem no sistema.
13. Como gerente de um hotel, gostaria de responder as dúvidas que clientes possam ter.
14. Como gerente de um hotel, gostaria de responder as avaliações que clientes façam sobre minhas acomodações
15. Como gerente de um hotel, gostaria de visualizar as reservas feitas em minhas acomodações
16. Como gerente de um hotel, gostaria de apresentar minhas políticas de hospedagem
17. Como gerente de um hotel, gostaria de editar/deletar minhas políticas de hospedagem

## Backlog da sprint

**História #1:** Como viajante, gostaria de pesquisar acomodações disponíveis em um hotel. <br>
**Tarefas e responsáveis:**
- Criar esqueleto do projeto utilizando .Net (Lucas Carvalho)
- Esboço de um diagrama ER para melhor entendimento no backend (Lucas Carvalho)
- Configurar banco de dados sqlite (Lucas Carvalho)
- Criar classes de domínio para Hotel, Room, Booking e Guest, e instanciar as tabelas referentes (Lucas Carvalho)
- Criar e testar primeira rota usando Asp.Net (Lucas Carvalho)
- Implementar no backend a lógica de pesquisar e listar acomodações disponíveis de um hotel (André Luiz)
- Desenvolver tela principal de usuário para pesquisar acomodações (Erico Colen)
- Ajustar tela de usuário para apresentar a lista de acomodações (Erico Colen)

**História #2:** Como viajante, gostaria de pesquisar acomodações disponíveis em um certo intervalo de dias. <br>
**Tarefas e responsáveis:**
- Criar consulta de quartos disponíveis para certo intervalo de dias (Lucas Carvalho)
- Configurar rota de consulta de acomodações para receber filtro de dias (Lucas Carvalho)
- Ajustar tela de usuário feita por usuário para apresentar nova lista filtrada de acomodações (Erico Colen)
  
**História #3:** Como viajante, gostaria de pesquisar acomodações disponíveis em uma cidade. <br>
**Tarefas e responsáveis:**
- Implementar no backend lógica de consulta filtrada por certa localidade (Lucas Carvalho)
- Configurar rota de consulta de acomodações para receber filtro de localidade (Lucas Carvalho)
- Adaptar tela de consulta feita por usuário para apresentar acomodações seguindo nova filtragem (Erico Colen)

**História #4:** Como viajante, gostaria de reservar uma acomodação em um hotel. <br>
**Tarefas e responsáveis:**
- Criar lógica de vincular um usuário para uma reserva de determinada acomodação, verificando disponibilidade (André Luiz)
- Criar uma rota do tipo Post para permitir a reserva (André Luiz)
- Adaptar tela de consulta de acomodações, apresentando botão para reservar (Erico Colen)

**História #5:** Como viajante, gostaria de editar e cancelar uma acomodação já reservada. <br>
**Tarefas e responsáveis:**
- Criar lógica no backend que permita edição de data/horário de uma reserva para outra que esteja disponível (Lucas Carvalho)
- Criar lógica no backend que permita a deleção de uma determinada reserva feita pelo usuário (André Luiz)
- Criar tela que lista as reservas feitas pelo usuário (Erico Colen)
- Adaptar tela de listagem de reservas para apresentar opção de editar reserva e opção de deletar reserva (Erico Colen)

**História #6:** Como gerente de um hotel, gostaria de me cadastar no sistema e ter uma página de hospedagem no sistema. <br>
**Tarefas e responsáveis:**
- Verificar e ajustar tabela no banco de dados para que fique de acordo com a entidade Hotel e Quarto (Lucas Carvalho)
- Criar lógica no backend que permita o cadastro de novo hotel no sistema (André Luiz)
- Criar nova rota que permita o usuário se cadastrar novo hotel (André Luiz)
- Implementar tela que permita usuário cadastrar seu hotel no sistema (Victor Castro)

**História #7:** Como gerente de um hotel, gostaria de editar e deletar minha página de hospedagem no sistema. <br>
- Criar lógica no backend que permita edição de informações a respeito do hotel previamente cadastrado no sistema (André Luiz)
- Criar lógica no backend que permita deleção de um hotel no sistema (André Luiz)
- Desenvolver nova rota que permita edição/deleção de um hotel para o frontend (André Luiz)
- Implementar tela de edição de informações de um hotel (Victor Castro)
- Implementar tela de confirmação de deleção de hotel do sistema (Victor Castro)

**História #8:** Como gerente de um hotel, gostaria de visualizar as reservas feitas em minhas acomodações <br>
- Implementar lógica que permita listar as reservas feitas no hotel administrado pelo gerente (André Luiz)
- Desenvolver rota que permita frontend ter acesso a listagem de acomodações (André Luiz)
- Implementar tela que permita visualização das reservas feitas (Victor Castro)

## Backlog da sprint (nova versão)

**História #1:** Como viajante, gostaria de pesquisar acomodações disponíveis em um hotel. <br>
**Tarefas e responsáveis:**
- Criar esqueleto do projeto utilizando .Net (Victor)
- Esboço de um diagrama ER para melhor entendimento no backend (Lucas)
- Configurar banco de dados sqlite (Victor)
- Criar classes de domínio para Hotel, Room, Booking e Guest, e instanciar as tabelas referentes (Victor)
- Criar e testar primeira rota usando Asp.Net (Lucas)
- Implementar no backend a lógica de pesquisar e listar acomodações disponíveis de um hotel (Lucas)
- Desenvolver tela principal de usuário para pesquisar acomodações (Victor e Erico)
- Ajustar tela de usuário para apresentar a lista de acomodações (Victor e Erico)

**História #2:** Como viajante, gostaria de pesquisar acomodações disponíveis em um certo intervalo de dias. <br>
**Tarefas e responsáveis:**
- Criar consulta de quartos disponíveis para certo intervalo de dias (Victor)
- Configurar rota de consulta de acomodações para receber filtro de dias (Victor)
- Ajustar tela de usuário feita por usuário para apresentar nova lista filtrada de acomodações (Victor e Erico)
  
**História #3:** Como viajante, gostaria de pesquisar acomodações disponíveis em uma cidade. <br>
**Tarefas e responsáveis:**
- Implementar no backend lógica de consulta filtrada por certa localidade (Lucas)
- Configurar rota de consulta de acomodações para receber filtro de localidade (Victor)
- Adaptar tela de consulta feita por usuário para apresentar acomodações seguindo nova filtragem (Victor e Erico)

**História #4:** Como viajante, gostaria de reservar uma acomodação em um hotel. <br>
**Tarefas e responsáveis:**
- Criar lógica para verificar disponibilidade de datas para um quarto (André Luiz e Lucas)
- Criar lógica de vincular um usuário para uma reserva de determinada acomodação, verificando disponibilidade (André Luiz e Lucas)
- Criar uma rota do tipo Post para permitir a reserva (Lucas)
- Adaptar tela de consulta de acomodações, apresentando botão para reservar (Victor e Erico)

**História #5:** Como viajante, gostaria de editar e cancelar uma acomodação já reservada. <br>
**Tarefas e responsáveis:**
- Criar lógica no backend que permita edição de data/horário de uma reserva para outra que esteja disponível (André Luiz)
- Criar lógica no backend que permita a deleção de uma determinada reserva feita pelo usuário (André Luiz)
- Criar tela que lista as reservas feitas pelo usuário (Victor e Erico)
- Adaptar tela de listagem de reservas para apresentar opção de deletar reserva (Victor e Erico)

**História #6:** Como gerente de um hotel, gostaria de me cadastar no sistema e ter uma página de hospedagem no sistema. <br>
**Tarefas e responsáveis:**
- Verificar e ajustar tabela no banco de dados para que fique de acordo com a entidade Hotel e Quarto (Victor)
- Criar lógica no backend que permita o cadastro de novo hotel no sistema (Lucas)
- Criar nova rota que permita o usuário se cadastrar novo hotel (Lucas)
- Implementar tela que permita usuário cadastrar seu hotel no sistema (Victor e Erico)

**História #7:** Como gerente de um hotel, gostaria de editar e deletar minha página de hospedagem no sistema. <br>
- Criar lógica no backend que permita edição de informações a respeito do hotel previamente cadastrado no sistema (André Luiz)
- Criar lógica no backend que permita deleção de um hotel no sistema (André Luiz)
- Desenvolver nova rota que permita edição/deleção de um hotel para o frontend (André Luiz)
- Implementar tela de confirmação de deleção de hotel do sistema (Victor e Erico)

**História #8:** Como viajante, gostaria de ver as avaliações que fiz e poder deletá-las.
- Criar lógica no backend que permita criação de uma avaliação de um booking já feito (Lucas)
- Criar lógica no backend que permita usuário deletar uma avaliação feita por este mesmo usuário (Lucas)
- Desenvolver nova rota que permita criação/deleção de uma avaliação para o frontend (Lucas)
- Implementar tela que liste as avaliações feitas por um usuário (Lucas)
