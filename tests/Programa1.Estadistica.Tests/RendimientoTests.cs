namespace Programa1.Estadistica.Tests;

using System.Diagnostics;
using Programa1.Estadistica.Dominio;

public class RendimientoTests
{
    // CP-19: Rendimiento: 100 000 números reales en menos de 1 segundo (1000 ms) (RNF-06)
    [Fact]
    public void CP19_CienMilDatos_ProcesaEnMenosDeUnSegundo()
    {
        const int cantidad = 100_000;
        var lista = new ListaEnlazada();

        var cronometro = Stopwatch.StartNew();

        for (int i = 0; i < cantidad; i++)
        {
            lista.Agregar(i * 1.5);
        }

        var resultado = CalculadoraEstadistica.Calcular(lista);
        cronometro.Stop();

        Assert.Equal(cantidad, resultado.Cantidad);
        Assert.True(cronometro.ElapsedMilliseconds < 1000,
            $"El procesamiento tardó {cronometro.ElapsedMilliseconds} ms, superando el límite de 1000 ms.");
    }
}
