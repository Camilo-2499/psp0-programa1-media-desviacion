namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Eslabón de la lista enlazada. Guarda un valor real
/// y la referencia al nodo que le sigue.
/// </summary>
internal sealed class Nodo
{
    /// <summary>Número real almacenado en este nodo.</summary>
    public double Valor { get; }

    /// <summary>Referencia al siguiente nodo, o null si es el último.</summary>
    public Nodo? Siguiente { get; set; }

    /// <summary>Crea un nodo con el valor indicado, sin siguiente.</summary>
    /// <param name="valor">Número real a almacenar.</param>
    public Nodo(double valor)
    {
        Valor = valor;
    }
}
