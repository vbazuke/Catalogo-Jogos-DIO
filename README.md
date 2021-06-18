# Catálogo de Jogos DIO

Projeto desenvolvido no o bootcamp da Take Blip na Digital Innovation One. Este é o repo com a aplicação original criada por Thiago Campos de Oliveira https://github.com/ThiagoAcam/ApiCatalogoJogos .

Trata-se de uma aplicação backend .NET de catálogo de jogos, que expõe uma API e seus endpoints para ser utilizada/consumida por outra aplicação interessada em seus dados. 
Na versão original são criados e expostos endpoints para criação, atualização e remoção de um jogo.

O projeto teve as seguintes alterações como forma de aprendizado:

  * Foi modificada a entidade Jogo, para incluir uma imagem, e várias tags. Dessa forma agora é possível cadastrar uma imagem de capa e tags que descrevem o jogo.

  * Foram criadas duas novas entidades no projeto, uma chamada Tag que relaciona um jogo com uma Tag(etiqueta), descrevendo assim o estilo/gênero do jogo, as tags 
    iniciais do   projeto são palavras que tem potencial de descrever o jogo, como: Ação, Casual, Multiplayer, etc... Todo o padrão arquitetural de camadas do projeto foi
    mantido e atualizado quando necessário (Services, Repositories, ViewModels, etc...)

  * A segunda entidade JogoTag é responsável por ser o pivô de ligação entre Jogo e Tag, essa entidade é necessária pela natureza da relação N:N entre Jogos e Tags.
   (Muitos Jogos estão relacionados a Muitas Tags)
   
  * Foram criados todos os endpoints necessários mantendo o padrão do projeto original (criar, atualizar, remover, etc...)

  * Foi adicionado uma aplicação frontend Angular básica que consome a API .NET e exibe o catálogo no navegador do usuário, 
  para o layout foram utilizados Angular Material + FlexBox. O projeto angular encontra-se no diretório "front-catalogo"
  
  * Nesse layout são exibidos cards com todas as informações cadastradas dos jogos, cada card possui uma imagem de capa com um overlay no topo onde são mostradas as tags de 
  cada jogo.

Requisitos:
.NET Core 5.0

Visual Studio Code (opcional)

Angular-CLI 11 +

É necessário rodar os dois projetos (.NET e Angular) simultaneamente para que o o frontend possa consultar o backend corretamente. Foi utilizada uma solução de proxy no projeto Angular para evitar problemas relacionados ao CORS, dessa forma o próprio Angular faz as requisições ao backend, ao invés de serem feitas diretamente pelo navegador. O proxy deve ser configurado, se for preciso. [proxy.conf](https://github.com/vbazuke/Catalogo-Jogos-DIO/blob/main/front-catalogo/proxy.conf.json)
