namespace Entidades.Domain.Entities;

using Entidades.Domain.Primitives;
using System;

public sealed class Filme
    (Guid id, string titulo, string diretor, DateTime dataLancamento, double avaliacao) : Entity(id)
{
    public string Titulo { get; set; } = titulo;

    public string Diretor { get; set; } = diretor;

    public DateTime DataLancamento { get; set; } = dataLancamento;

    public double Avaliacao { get; set; } = avaliacao;
}