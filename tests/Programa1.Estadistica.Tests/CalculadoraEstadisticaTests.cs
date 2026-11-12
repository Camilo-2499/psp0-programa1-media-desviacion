namespace Programa1.Estadistica.Tests;

using Programa1.Estadistica.Dominio;

public class CalculadoraEstadisticaTests
{
    // CP-01: Tabla 1, Columna 1 del Kit (RF-03, RF-04, RNF-03)
    [Fact]
    public void CP01_Tabla1Columna1_MediaYDesviacionEsperadas()
    {
        var datos = DatosDePrueba.CrearLista(DatosDePrueba.Columna1);
        var resultado = CalculadoraEstadistica.Calcular(datos);

        Assert.Equal(550.60, resultado.Media, precision: 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(572.03, resultado.DesviacionEstandar.Value, precision: 2);
    }

    // CP-02: Tabla 1, Columna 2 del Kit (RF-03, RF-04, RNF-03)
    [Fact]
    public void CP02_Tabla1Columna2_MediaYDesviacionEsperadas()
    {
        var datos = DatosDePrueba.CrearLista(DatosDePrueba.Columna2);
        var resultado = CalculadoraEstadistica.Calcular(datos);

        Assert.Equal(60.32, resultado.Media, precision: 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(62.26, resultado.DesviacionEstandar.Value, precision: 2);
    }

    // CP-03: Tabla 3 del Kit (RF-03, RF-04)
    [Fact]
    public void CP03_Tabla3Ejemplo_MediaYDesviacionEsperadas()
    {
        var datos = DatosDePrueba.CrearLista(DatosDePrueba.Tabla3);
        var resultado = CalculadoraEstadistica.Calcular(datos);

        Assert.Equal(638.90, resultado.Media, precision: 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(625.63, resultado.DesviacionEstandar.Value, precision: 2);
    }

    // CP-04: Lista vacía lanzando DatosInsuficientesException (RF-06)
    [Fact]
    public void CP04_ListaVacia_LanzaDatosInsuficientesException()
    {
        var datos = new ListaEnlazada();
        Assert.Throws<DatosInsuficientesException>(() => CalculadoraEstadistica.Media(datos));
    }

    // CP-05: Un solo dato (media definida, desviación no definida) (RF-04, RF-06)
    [Fact]
    public void CP05_UnSoloDato_MediaDefinidaDesviacionNull()
    {
        var datos = DatosDePrueba.CrearLista(42.5);
        var resultado = CalculadoraEstadistica.Calcular(datos);

        Assert.Equal(42.5, resultado.Media, precision: 2);
        Assert.Null(resultado.DesviacionEstandar);
    }

    // CP-06: Datos idénticos (desviación exactamente 0.00) (RF-04)
    [Fact]
    public void CP06_DatosIdenticos_DesviacionCero()
    {
        var datos = DatosDePrueba.CrearLista(7.0, 7.0, 7.0, 7.0);
        var resultado = CalculadoraEstadistica.Calcular(datos);

        Assert.Equal(7.0, resultado.Media, precision: 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(0.00, resultado.DesviacionEstandar.Value, precision: 2);
    }

    // CP-07: Números negativos y cero (RF-03, RF-04)
    [Fact]
    public void CP07_NumerosNegativosYCero_CalculaCorrectamente()
    {
        var datos = DatosDePrueba.CrearLista(-2.5, 0.0, 2.5);
        var resultado = CalculadoraEstadistica.Calcular(datos);

        Assert.Equal(0.00, resultado.Media, precision: 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(2.50, resultado.DesviacionEstandar.Value, precision: 2);
    }
}
