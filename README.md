# Seguindo o livro Princípios, Padrões e Práticas Ágeis em C#

## Princípio da Responsabilidade Única (SRP)
Separar principalmente a regra de negócio do das regras de persistência, pois elas mudam por motivos muitas vezes diferentes.

* Uma classe deve ter uma única responsabilidade, com isso, ela só deve ter uma razão para ser alterada;
* Nesse exemplo do livro, embora as responsabilidades estajam em uma única classe (Modem), duas dependências foram retiradas, com isso ninguém vai se tornar dependente da classe Modem.
