# SmartManager
SmartManager é um sistema de gerenciamento de vendas e estoque que visa garantir melhor controle do seu negócio. Nosso sistema permitirá a atualização do estoque, realização de vendas, obtenção de relatórios contendo informações sobre o estoque e vendas da sua empresa. Além disso, o SmartManager conta com um sistema de login, restringindo o uso do programa apenas para pessoas autorizadas.

# Relatório de desenvolvimento

24/11/2021 – Descrição do projeto

Nós faremos um sistema de gerenciamento de estoque e de vendas. Nosso sistema contará com um sistema de login, para que só pessoas autorizadas tenham acesso ao sistema. Além disso nosso sistema contará com dois níveis de acesso, um para o vendedor (vendas) e o outro para o gerente (administração). O gerente ficará responsável por cadastrar produto, editar produto, cadastrar funcionário, remover funcionário, ele também terá acesso a relatórios de estoque, relatórios de vendas. O vendedor ficará responsável pela realização das vendas, além de ter acesso a uma lista de itens do estoque.

01/12/2021 – Definição das classes do sistema, seus métodos e propriedades

Definimos as classes que irão compor o nosso projeto e iniciamos o desenvolvimento. Classes do sistema: Funcionário, Gerente, Vendedor, Administração, Produto, Venda. 
Funcionário: Irá conter os atributos e métodos em comum das classes Gerente e Vendedor
Gerente: Irá conter os métodos referentes as ações do gerente no sistema.
Vendedor: Irá conter os métodos referentes as ações do vendedor no sistema.
Administração: Na classe administração ficaram guardados a lista de produtos (estoque) e a lista de vendas realizadas no sistema, além disso teremos métodos para a exibição dessas listas.
Produto: Na classe produto nós teremos armazenados todos os dados relevantes referente a um produto, por exemplo, nome, quantidade, preço.
Venda: Nessa classe ficarão os dados relevantes a uma venda realizada, por exemplo, itens, quantidade, data.


![SmartManager](https://user-images.githubusercontent.com/94657026/146691653-8b31230e-8037-4c34-9ce3-8ac11f5aa8b3.png)


08/12/2021 – Implementação da persistência de dados

Finalizado o desenvolvimento das classes, finalizado desenvolvimento da interação com o usuário e feito a implementação da persistência de dados.

15/12/2021 – Testes de funcionamento do sistema.

Foram realizados diversos testes no sistema buscando entrar possíveis problema e bugs para as devidas correções.

19/12/2021 – Gravação do vídeo de funcionamento do sistema.

Foi feita a gravação do vídeo de funcionamento do sistema.

# Funcionamento do sistema

https://www.youtube.com/watch?v=GSs6PfeQxr4

