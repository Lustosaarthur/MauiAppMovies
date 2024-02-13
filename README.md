## App de Filmes
Esse é um aplicativo que oferece um longo banco de dados de filmes, onde você pode pesquisar por vários filmes, navegar por categorias, ver detalhes dos filmes como Sinopse, Atores, Categoria, Genero etc...
Além de uma página apenas com os filmes favoritos do usuário.

## Tecnologias
- **.NET MAUI** - Framewkork
- **C#** - Linguagem de programção
- **XAML** - Linguagem de marcação
- **Entity Framework Core** - Bibliotecas
- **SQLite** - Banco de dados
- **MVVM** - Padrão de Projeto
- **API Rest OmdbAPI** - API com o banco de dados dos filmes

## Desafio 1
Uma das principais dificuldades que eu enfrentei nessa aplicação foi carregar alguns dados adicionais do filme no detail, na página inicial, o user podia clicar em qualquer filme que ela era redirecionado
a uma detail com dados desse filme, na página eu fazia o GET a API pra solicitar esses dados por meio do ImdID, acontece que esse filme só era carregado depois que a solicitção já havia acontecido, por isso dava uma exceção
a solução que eu encontrei foi só fazer a solicitção depois que o filme já estava 100% carregado
## Desafio 2
Outro desafio interessante que eu enfrentei, foi que, o user tem uma tela de Filmes favoritos, e quando ele adicionava eu enfrentei um problema pra atualizar a UI, eu solucionei esse problema por meios da Mensagem em .NET MAUI
eu enviava uma mensagem pra tela pra ela atualizar a UI.
