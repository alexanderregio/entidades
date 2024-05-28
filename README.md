## Entidades em DDD: Uma Abordagem Prática

Este documento explora o conceito de Entidades em Domain Driven Design (DDD) com exemplos de código em C#.

### O que é uma Entidade?

Uma Entidade em DDD é um objeto com identidade única e persistente. Isso significa que a Entidade pode ser rastreada e identificada independentemente de suas propriedades. Imagine um cliente em um sistema de vendas: mesmo que seu nome ou endereço mudem, ele continua sendo o mesmo cliente com a mesma identidade.

### Implementação de Entidades em C#

A estrutura de código a seguir demonstra uma implementação de Entidade em C#, utilizando o conceito de `Entity` como base.

**1. Classe Base `Entity`**

```C#
public abstract class Entity(Guid id) : IEquatable<Entity>
{
    public Guid Id { get; private init; } = id;

    public override bool Equals(object obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not Entity entity)
            return false;

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity other)
    {
        if (other is null)
            return false;

        if (other.GetType() != GetType())
            return false;

        return other.Id == Id;
    }

    public static bool operator ==(Entity first, Entity second)
        => first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity first, Entity second)
        => !(first == second);

}
```

* **`Entity` é uma classe abstrata:** Isso significa que ela não pode ser instanciada diretamente, mas serve como base para outras Entidades.
* **`Id` é um `Guid`:** Cada Entidade possui um ID único e persistente, gerado como `Guid`.
* **Implementação de `IEquatable<Entity>`:** A classe `Entity` implementa a interface `IEquatable<Entity>`, garantindo que a comparação de duas Entidades seja feita com base no ID.
* **Sobrecarga de operadores `==` e `!=`:** Os operadores `==` e `!=` são sobrecarregados para comparar Entidades com base no ID.

**2. Exemplo de Entidade: `Filme`**

```C#
public sealed class Filme
    (Guid id, string titulo, string diretor, DateTime dataLancamento, double avaliacao) : Entity(id)
{
    public string Titulo { get; set; } = titulo;

    public string Diretor { get; set; } = diretor;

    public DateTime DataLancamento { get; set; } = dataLancamento;

    public double Avaliacao { get; set; } = avaliacao;
}
```

* **`Filme` é uma classe selada:** Isso significa que ela não pode ser herdada por outras classes.
* **`Filme` herda da classe `Entity`:** Todas as Entidades devem herdar da classe `Entity` para garantir a identidade única.
* **Propriedades:** `Filme` possui propriedades como `Titulo`, `Diretor`, `DataLancamento` e `Avaliacao`, que armazenam dados específicos sobre o filme.

### Conclusões

Este exemplo demonstra como utilizar Entidades em DDD com C#. A classe `Entity` fornece uma base sólida para a criação de Entidades em seu domínio, garantindo identidade única e persistência. As Entidades são elementos-chave em DDD, pois representam os objetos mais importantes do seu domínio e são essenciais para modelar seu negócio de forma precisa e eficiente.