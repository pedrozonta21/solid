Princípios, Padrões e Práticas Ágeis em C# - SOLID
=====

### *Princípio da Responsabilidade Única (SRP)*
Separar principalmente a regra de negócio das regras de persistência, pois elas mudam por motivos muitas vezes diferentes.

* Uma classe deve ter uma única responsabilidade, com isso, ela só deve ter uma razão para ser alterada.
* Nesse exemplo do livro, embora as responsabilidades estajam em uma única classe (Modem), duas dependências foram retiradas, com isso ninguém vai se tornar dependente da classe Modem.

### *Princípio do Aberto/Fechado (OCP)*
Uma classe, à medida que os requisitos aumentam deve estar aberta para ampliação e fechada para modificação. É meio confuso pensar nisso em um primeiro momento, já que se algo vai ser ampliado, vai ter que se mexer no código.

A aplicação desse princípio consiste em:
* A classe abstrata inicial tem sua implementação padrão (ou não).
* Conforme outras classes precisem de seu comportamento específico, elas implementam e dão um override.
* Isso evita ficar criando if's, pois como demonstrado no exemplo, caso apareça um novo tipo de cliente, basta criar uma classe pra ele (o que condiz com o SRP).
* Caso a saudação de um determinado cliente mude, as outras continuarão intactas.

Em um exemplo pequeno como esse no link por exemplo, pode parecer inofensivo adicionar apenas mais um if, porém os requisitos sempre mudam, e ficar mexendo em um método acoplado com certeza vai ocasionar um código feio e muito frágil futuramente.

Mesclei esse exemplo https://medium.com/@tbaragao/solid-ocp-open-closed-principle-600be0382244 com o do livro.

Um outro exemplo do livro foi o famoso projeto Shape. Inicialmente, a ideia é a mesma do exemplo acima, porém no livro o exemplo foi além, onde foi imaginado uma situação onde fosse necessário fazer uma alteração na hora de listar todas as formas (desenhar primeiro os círculos).

Então a funcionalidade de ordenar os círculos primeiro, sem mexer diretamente no método DesenharFormas(), foi extraída para uma classe que herda IComparer, para caso novas formas sejam adicionadas juntamente com suas prioriades, a alteração será feita na classe ComparadorDeForma.

> Não existe para nenhum cenário um fechamento completo, onde tudo pode ser abstrato, então a abstração deve ser feita de forma estratégica, visando sempre quais e onde serão as alterações mais prováveis.

### *Princípio da Substituição de Liskov (LSP)*
Esse princípio está diretamente ligado com o OCP, já que o uso correto dele significa que o LSP está sendo respeitado. Mas como saber?
Liskov determinou que, em uma implementação (herança), todas as classes que implementam, podem ser substituídas pela classe implementadora sem nenhum problema.

Reproduzi o exemplo https://medium.com/netcoders/aplicando-solid-com-c-lsp-liskov-substitution-principle-2a5d23753506, acrescentando uma implementação correta.
Dois fatores bem importantes devem ser avaliados para aplicar o LSP:
1. A classe base possui comportamentos/métodos inúteis para a classe derivada?
2. O comportamento externo é alterado se substituímos a classe base pela derivada?

Se uma dessas duas perguntas tiver uma resposta positiva, o LSP não está sendo respeitado. No exemplo, vamos imaginar o seguinte cenário:
- Toda conta tem a opção de RetirarDinheiro (seja em saque ou pagamento), e essa conta pode ficar negativada, isto é, pode haver uma retirada de dinheiro maior do que o disponível. 
- A classe ContaCorrente se encaixa nesse quesito, além de ter, é claro, seu método próprio de cartão de crédito.
- A classe ContaPoupanca, a princípio se encaixa, já que ela também possui retirada de dinheiro. Porém a ela não pode ficar com saldo negativo, então não é possível fazer uma retirada de dinheiro maior do que o disponível.

Em um primeiro momento, tudo parece estar lindo. Agora, para saber se o LSP está sendo respeitado, basta responder a pergunta número 2 acima. A resposta é sim! Pois em todo segmento de conta que É UMA CONTA (herança), deve-se esperar poder ficar com um saldo negativo, sendo assim, não importa se seja ContaCorrente, ContaSeiLaOQue, elas sempre vão ter o comportamento esperado de poderem ficar negativadas.
A ContaPoupanca entrega um comportamento diferente, pois se fizermos uma retirada de R$100, tendo um saldo de R$50, o método RetornarQuantoDinheiroPossuiNaConta() retornará R$100, e não R$-50 como é esperado.

Se duas classes filhas possuem resultados diferentes nas implementações, o princípio é violado.
Precisamos ter muita atenção, pois o LSP demanda muita análise. Como dito por Robert C. Martin, o conceito de É UM para se ter uma implemenção, é muito amplo para ser uma decisão fácil. Como mostrado no exemplo, embora ContaPoupanca teoricamento É UMA Conta, na prática a implementação está errada por ter um resultado diferente do esperado. 
Obviamente, a classe ContaPoupanca poderia implementar o método RetirarDinheiro() fazendo um cálculo diferente por qualquer motivo que seja, porém o __resultado__ deve ser o mesmo esperado em sua classe pai (Conta).

### *Princípio da Inversão de Dependência (DIP)*
A ideia desse princípio ajuda muito no reaproveitamento de código. Quando se tem uma classe de alto nível, isto é, uma classe mestre que faz ações muito importantes dentro do sistema, normalmente usamos outras classes de nível menor para fazer ações mais detalhadas, como realizar um cálculo, validar um texto, etc. Essa classe mestre não pode ser frágil ao se fazer uma alteração nos níveis mais baixos.

No exemplo do livro de Robert C. Maritin, temos uma classe Botao, que é a classe mestre (afinal, muitas coisas possuem botões de ligar / desligar). E temos a classe de um nível mais baixo, a Lampada. Até aí tudo funcionando perfeitamente.
Só que agora, surgiu a classe Computador, que também possui um botão liga / desliga. Ora, é só usarmos a classe Botao que já controle isso, a classe Computador faz o seu método de ligar, enquanto Botao apenas chama.

Mas neste caso, se formos reutilizar a classe Botao, teremos que criar mais um parâmetro no construtor, e colocar um parâmetro nos métodos para sabermos qual o objeto que estamos apertando o botão, e assim fazer um if.

É a partir de agora que surge o problema, pois para cada novo objeto, teremos que criar uma variável de instância, um parâmetro no construtor e um if nos dois métodos existentes na classe. Isso se torna inviável, porque caso formos usar a classe Botao, temos que injetar todos os objetos (Lampada e Computador), e com certeza em cada contexto da classe mestre, só precisaremos de um desses objetos.

> Isso viola o OCP, já que a classe não está fechada para alteração, e uma mudança lá embaixo ocasiona mudanças em cascata.
