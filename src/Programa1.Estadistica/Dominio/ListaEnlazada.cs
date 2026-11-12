namespace Programa1.Estadistica.Dominio;

using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Lista enlazada simple de números reales para almacenar los datos.
/// Mantiene punteros al primer y último elemento para inserción O(1).
/// </summary>
public sealed class ListaEnlazada : IEnumerable<double>
{
    private Nodo? _primero;
    private Nodo? _ultimo;

    /// <summary>Cantidad de nodos almacenados (n).</summary>
    public int Cantidad { get; private set; }

    /// <summary>Indica si la lista no contiene nodos.</summary>
    public bool EstaVacia => Cantidad == 0;

    /// <summary>Agrega un valor real al final de la lista.</summary>
    /// <param name="valor">Número real a agregar.</param>
    public void Agregar(double valor)
    {
        var nuevo = new Nodo(valor);

        if (_ultimo is null)
        {
            _primero = nuevo;
        }
        else
        {
            _ultimo.Siguiente = nuevo;
        }

        _ultimo = nuevo;
        Cantidad++;
    }

    /// <summary>Recorre los valores en el orden en que se agregaron.</summary>
    public IEnumerator<double> GetEnumerator()
    {
        for (var actual = _primero; actual is not null; actual = actual.Siguiente)
        {
            yield return actual.Valor;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
