namespace Programa1.Estadistica.Tests;

using System.Globalization;
using System.IO;
using Programa1.Estadistica.Infraestructura;

public class LectorArchivoNumerosTests
{
    // CP-09: Líneas en blanco entre datos se ignoran (RF-01)
    [Fact]
    public void CP09_LineasEnBlanco_SeIgnoran()
    {
        string[] lineas = ["  ", "10.5", "", "  ", "20.5", "   "];
        var lista = LectorArchivoNumeros.LeerLineas(lineas);

        Assert.Equal(2, lista.Cantidad);
        Assert.Equal(new[] { 10.5, 20.5 }, lista.ToArray());
    }

    // CP-10: Dato no numérico arroja excepción indicando la línea exacta (RF-06, RNF-05)
    [Fact]
    public void CP10_DatoNoNumerico_IndicaNumeroLinea()
    {
        string[] lineas = ["1.0", "2.0", "abc"];
        var ex = Assert.Throws<DatosInvalidosException>(() => LectorArchivoNumeros.LeerLineas(lineas));

        Assert.Equal(3, ex.NumeroLinea);
        Assert.Contains("Línea 3", ex.Message);
        Assert.Contains("abc", ex.Message);
    }

    // CP-11: Colección sin datos válidos arroja DatosInvalidosException (RF-06)
    [Fact]
    public void CP11_SoloEspacios_LanzaDatosInvalidosException()
    {
        string[] lineas = ["  ", "   ", ""];
        Assert.Throws<DatosInvalidosException>(() => LectorArchivoNumeros.LeerLineas(lineas));
    }

    // CP-12: Archivo inexistente arroja FileNotFoundException (RF-06)
    [Fact]
    public void CP12_ArchivoInexistente_LanzaFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => LectorArchivoNumeros.Leer("archivo_ficticio_no_existe.txt"));
    }

    // CP-13: Robustez regional: con cultura es-CO (Colombia) '15.0' se lee como 15.0, NO como 150 (RNF-02)
    [Fact]
    public void CP13_CulturaColombia_UsaPuntoDecimal()
    {
        var culturaOriginal = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-CO");
            string[] lineas = ["15.0", "6.5"];
            var lista = LectorArchivoNumeros.LeerLineas(lineas);

            Assert.Equal(new[] { 15.0, 6.5 }, lista.ToArray());
        }
        finally
        {
            CultureInfo.CurrentCulture = culturaOriginal;
        }
    }

    // CP-14: Lectura de archivo físico real del kit (RF-01)
    [Fact]
    public void CP14_ArchivoReal_LeeCorrectamente()
    {
        var ruta = Path.Combine("..", "..", "..", "..", "..", "datos", "columna2_horas.txt");
        if (File.Exists(ruta))
        {
            var lista = LectorArchivoNumeros.Leer(ruta);
            Assert.Equal(10, lista.Cantidad);
        }
    }
}
