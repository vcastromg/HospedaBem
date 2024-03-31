
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

- Back-end: C#
- Front-end: C#
- Banco de dados: PostgreSQL

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
- Criar esqueleto do projeto utilizando .Net
- Esboço de um diagrama ER para melhor entendimento no backend [Lucas]
- Configurar banco de dados sqlite.
- Criar classes de domínio para Hotel, Room, Booking e Guest, e instanciar as tabelas referentes
- Criar e testar primeira rota usando Asp.Net
- Implementar no backend a lógica de pesquisar e listar acomodações disponíveis de um hotel [Andre]
- Desenvolver tela principal de usuário para pesquisar acomodações
- Ajustar tela de usuário para apresentar a lista de acomodações

**História #2:** Como viajante, gostaria de pesquisar acomodações disponíveis em um certo intervalo de dias. <br>
**Tarefas e responsáveis:**
- Criar consulta de quartos disponíveis para certo intervalo de dias [Lucas]
- Configurar rota de consulta de acomodações para receber filtro de dias [Lucas]
- Ajustar tela de usuário feita por usuário para apresentar nova lista filtrada de acomodações
  
**História #3:** Como viajante, gostaria de pesquisar acomodações disponíveis em uma cidade. <br>
**Tarefas e responsáveis:**
- Implementar no backend lógica de consulta filtrada por certa localidade [Lucas]
- Configurar rota de consulta de acomodações para receber filtro de localidade [Lucas]
- Adaptar tela de consulta feita por usuário para apresentar acomodações seguindo nova filtragem

**História #4:** Como viajante, gostaria de reservar uma acomodação em um hotel. <br>
**Tarefas e responsáveis:**
- Criar lógica de vincular um usuário para uma reserva de determinada acomodação, verificando disponibilidade [Lucas]
- Criar uma rota do tipo Post para permitir a reserva [Lucas]
- Adaptar tela de consulta de acomdações, apresentando botão para reservar.

**História #5:** Como viajante, gostaria de editar e cancelar uma acomodação já reservada. <br>
**Tarefas e responsáveis:**
- Criar lógica no backend que permita edição de data/horário de uma reserva para outra que esteja disponível [Lucas]
- Criar lógica no backend que permita a deleção de uma determinada reserva feita pelo usuário [Andre]
- Criar tela que lista as reservas feitas pelo usuário
- Adaptar tela de listagem de reservas para apresentar opção de editar reserva e opção de deletar reserva

**História #6:** Como gerente de um hotel, gostaria de me cadastar no sistema e ter uma página de hospedagem no sistema. <br>
**Tarefas e responsáveis:**
- Verificar e ajustar tabela no banco de dados para que fique de acordo com a entidade Hotel e Quarto [Lucas]
- Criar lógica no backend que permita o cadastro de novo hotel no sistema. [Andre]
- Criar nova rota que permita o usuário se cadastar novo hotel.
- Implementar tela que permita usuário cadastar seu hotel no sistema.

**História #7:** Como gerente de um hotel, gostaria de editar e deletar minha página de hospedagem no sistema. <br>
- Criar lógica no backend que permita edição de informações a respeito do hotel previamente cadastrado no sistema [Andre]
- Criar lógica no backend que permita deleção de um hotel no sistema. [Andre]
- Desenvolver nova rota que permita edição/deleção de um hotel para o frontend.
- Implementar tela de edição de informações de um hotel
- Implementar tela de confirmação de deleção de hotel do sistema

**História #8:** Como gerente de um hotel, gostaria de visualizar as reservas feitas em minhas acomodações <br>
- Implementar lógica que permita listar as reservas feitas no hotel administrado pelo gerente [Andre]
- Desenvolver rota que permita frontend ter acesso a listagem de acomodações
- Implementar tela que permita visualização das reservas feitas
  
  
