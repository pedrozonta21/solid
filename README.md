SOLID
=====

### *Princípio da Responsabilidade Única (SRP)*
Separar principalmente a regra de negócio do das regras de persistência, pois elas mudam por motivos muitas vezes diferentes.

* Uma classe deve ter uma única responsabilidade, com isso, ela só deve ter uma razão para ser alterada.
* Nesse exemplo do livro, embora as responsabilidades estajam em uma única classe (Modem), duas dependências foram retiradas, com isso ninguém vai se tornar dependente da classe Modem.
* 
### *Princípio do Aberto/Fechado (OCP)*
Uma classe, à medida que os requisitos aumentam deve estar aberta para ampliação e fechada para modificação. É meio confuso pensar nisso em um primeiro momento, já que se algo vai ser ampliado, vai ter que se mexer no código.

A aplicação desse princípio consiste em:
* A classe abstrata inicial tem sua implementação padrão (ou não).
* Conforme outras classes precisem de seu comportamento específico, elas implementam e dão um override.
* Isso evita ficar criando if's, pois como desmonstrado no exemplo, caso apareça um novo tipo de cliente, basta criar uma classe pra ele (o que condiz com o SRP).
* Caso a saudação de um determinado cliente mude, as outras continuarão intactas.

> Em um exemplo pequeno como esse no link por exemplo, pode parecer inofensivo adicionar apenas mais um if, porém os requisitos sempre mudam, e ficar mexendo em um método acoplado com certeza vai ocasionar um código feio e muito frágil futuramente.

Mesclei esse exemplo https://medium.com/@tbaragao/solid-ocp-open-closed-principle-600be0382244 com o do livro.
