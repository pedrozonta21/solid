Princípios, Padrões e Práticas Ágeis em C# - SOLID
=====

### *Princípio da Responsabilidade Única (SRP)*
Separar principalmente a regra de negócio das regras de persistência, pois elas mudam por motivos muitas vezes diferentes.

* Uma classe deve ter uma única responsabilidade, com isso, ela só deve ter uma razão para ser alterada.
* Nesse exemplo do livro, embora as responsabilidades estejam em uma única classe (Modem), duas dependências foram retiradas, com isso ninguém vai se tornar dependente da classe Modem.

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

Então a funcionalidade de ordenar os círculos primeiro, sem mexer diretamente no método DesenharFormas(), foi extraída para uma classe que herda _IComparer_, para caso novas formas sejam adicionadas juntamente com suas prioriades, a alteração será feita na classe ComparadorDeForma.

> Não existe para nenhum cenário um fechamento completo, onde tudo pode ser abstrato, então a abstração deve ser feita de forma estratégica, visando sempre quais e onde serão as alterações mais prováveis.

### *Princípio da Substituição de Liskov (LSP)*
Esse princípio está diretamente ligado com o OCP, já que o uso correto dele significa que o LSP está sendo respeitado. Mas como saber?
Liskov determinou que, em uma implementação (herança), todas as classes que implementam, podem ser substituídas pela classe implementadora sem nenhum problema.

Reproduzi o exemplo https://medium.com/netcoders/aplicando-solid-com-c-lsp-liskov-substitution-principle-2a5d23753506, acrescentando uma implementação correta.
Dois fatores bem importantes devem ser avaliados para aplicar o LSP:
1. A classe base possui comportamentos/métodos inúteis para a classe derivada?
2. O comportamento externo é alterado se substituímos a classe base pela derivada?

Se uma dessas duas perguntas tiver uma resposta positiva, o LSP não está sendo respeitado. No exemplo, vamos imaginar o seguinte cenário:
- Toda _Conta_ tem a opção de RetirarDinheiro() (seja em saque ou pagamento), e essa conta pode ficar negativada, isto é, pode haver uma retirada de dinheiro maior do que o disponível. 
- A classe __ContaCorrente__ se encaixa nesse quesito, além de ter, é claro, seu método próprio de cartão de crédito.
- A classe __ContaPoupanca___, a princípio se encaixa, já que ela também possui retirada de dinheiro. Porém a ela não pode ficar com saldo negativo, então não é possível fazer uma retirada de dinheiro maior do que o disponível.

Em um primeiro momento, tudo parece estar lindo. Agora, para saber se o LSP está sendo respeitado, basta responder a pergunta número 2 acima. A resposta é sim! Pois em todo segmento de conta que É UMA CONTA (herança), deve-se esperar poder ficar com um saldo negativo, sendo assim, não importa se seja __ContaCorrente__, __ContaSeiLaOQue__, elas sempre vão ter o comportamento esperado de poderem ficar negativadas.
A __ContaPoupanca__ entrega um comportamento diferente, pois se fizermos uma retirada de R$100, tendo um saldo de R$50, o método RetornarQuantoDinheiroPossuiNaConta() retornará R$100, e não R$-50 como é esperado.

Se duas classes filhas possuem resultados diferentes nas implementações, o princípio é violado.
Precisamos ter muita atenção, pois o LSP demanda muita análise. Como dito por Robert C. Martin, o conceito de É UM para se ter uma implemenção, é muito amplo para ser uma decisão fácil. Como mostrado no exemplo, embora ContaPoupanca teoricamento É UMA _Conta_, na prática a implementação está errada por ter um resultado diferente do esperado. 
Obviamente, a classe ContaPoupanca poderia implementar o método RetirarDinheiro() fazendo um cálculo diferente por qualquer motivo que seja, porém o __resultado__ deve ser o mesmo esperado em sua classe pai (_Conta_).

### *Princípio da Inversão de Dependência (DIP)*
A ideia desse princípio ajuda muito no reaproveitamento de código. Quando se tem uma classe de alto nível, isto é, uma classe mestre que faz ações muito importantes dentro do sistema, normalmente usamos outras classes de nível menor para fazer ações mais detalhadas, como realizar um cálculo, validar um texto, etc. Essa classe mestre não pode ser frágil ao se fazer uma alteração nos níveis mais baixos.

No exemplo do livro de Robert C. Martin, temos uma classe __Botao__, que é a classe mestre (afinal, muitas coisas possuem botões de ligar / desligar). E temos a classe de um nível mais baixo, a __Lampada__. Até aí tudo funcionando perfeitamente.
Só que agora, surgiu a classe __Computador__, que também possui um botão liga / desliga. Ora, é só usarmos a classe __Botao__ que já controla isso, a classe __Computador__ faz o seu método de ligar, enquanto __Botao__ apenas chama.

Mas neste caso, se formos reutilizar a classe __Botao__, teremos que criar mais um parâmetro no construtor, e colocar um parâmetro nos métodos para sabermos qual o objeto que estamos apertando o botão, e assim fazer um if.

É a partir de agora que surge o problema, pois para cada novo objeto, teremos que criar uma variável de instância, um parâmetro no construtor e um if nos dois métodos existentes na classe. Isso se torna inviável, porque caso formos usar a classe __Botao__, temos que injetar todos os objetos (__Lampada__ e __Computador__), e com certeza em cada contexto da classe mestre, só precisaremos de um desses objetos.

> Isso viola o OCP, já que a classe não está fechada para alteração, e uma mudança lá embaixo ocasiona mudanças em cascata.

Agora, no exemplo com DIP, resolvemos o problema. Agora a classe __Botao__ não conhece os objetos reais, até porque pra ela, pouco importa isso, já que ela só quer saber se o objeto Liga e Desliga. Ao implementarmos a interface ___IObjetoEletrico___ em __Lampada__ e __Computador__, tiramos elas da classe __Botao__.

Para usar, basta no contexto da classe __Botao__ passar uma classe que É UM ___IObjetoEletrico___, pois não importa qual objeto seja, a classe __Botao__ vai saber que esse objeto Liga e Desliga (e só isso interessa). Com isso, caso seja necessário adicionar uma classe __Furadeira__, basta criarmos ela e implementar a interface.
- A classe __Botao__ não vai precisar ser alterada, o que é uma maravilha, pois não queremos ter que alterar todos os lugares onde essa classe é usada passando um novo parâmetro (como no exemplo sem DIP).

### *Princípio da Segregação de Interface (ISP)*
Clientes (classes) não devem depender de métodos que não utilizam. É um conceito simples de entender: se uma classe implementa uma interface, e metade dos métodos (por exemplo) não tem utilidade nenhuma, há algo errado na divisão desse contexto.

> Ao ter métodos que não precisa, pode ocorrer de essa classe ser chamada e rodar um método que não faz sentido ela ter, causando ou um __NotImplementedException__, ou simplesmente não fazer nada.

No exemplo sem ISP do telefone, temos uma interface _IObjetoEletronico_ com todos os métodos somados das classes que a implementam, porém, na classe __TelefoneFixo__ temos alguns métodos que não fazem sentido estarem lá, podendo ocasionar a situação descrita no parágrafo anterior.
Se fizermos uma análise nessa interface, percebemos que ela possui três contextos:
- Telefone padrão.
- Telefone moderno.
- Objeto eletrônico.

No exemplo com ISP, resolvemos esse problema, criando uma interface para cada contexto. A análise para a divisão foi:
- Nem todo objeto eletrônico tira foto, abre navegador ou toca.
- Nem todo telefone padrão tira foto ou abre navegador.
- Todo objeto eletrônico liga e desliga.
- Todo telefone disca e toca.

Assim, tiramos métodos inúteis das classes, deixando apenas os que importam, usando herança múltipla. Por exemplo, na classe __TelefoneModerno__, identificamos que ela é um objeto eletrônico, um telefone padrão e um telefone moderno, já que essa classe possui todos os comportamentos, diferente de __TelefoneCelular__.

Se fôssemos adicionar mais uma classe (__Lampada__) por exemplo, sem o ISP ela teria um método TirarFoto(), que não faz o menor sentido para uma lâmpada. Com o ISP, essa classe implementaria apenas a interface que lhe diz respeito, que é a _IObjetoEletrônico_.
