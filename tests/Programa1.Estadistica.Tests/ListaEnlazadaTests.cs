namespace Programa1.Estadistica.Tests;

using Programa1.Estadistica.Dominio;

public class ListaEnlazadaTests
{
    // CP-08: Lista nueva inicia vacía; luego conserva orden y cantidad (RF-02)
    [Fact]
    public void CP08_ListaEnlazada_ConservaOrdenYCantidad()
    {
        var lista = new ListaEnlazada();
        Assert.True(lista.EstaVacia);
        Assert.Equal(0, lista.Cantidad);

        lista.Agregar(3.0);
        lista.Agregar(1.0);
        lista.Agregar(2.0);

        Assert.False(lista.EstaVacia);
        Assert.Equal(3, lista.Cantidad);

        var elementos = new List<double>();
        foreach (var v in lista)
        {
            elementos.Add(v);
        }

        Assert.Equal(new[] { 3.0, 1.0, 2.0 }, elementos);
    }
}
