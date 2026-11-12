namespace Programa1.Estadistica.Tests;

using System.IO;

public class AplicacionTests
{
    // CP-15: Ruta pasada como argumento (RF-05, RF-07)
    [Fact]
    public void CP15_RutaPorArgumento_RetornaExitoYMuestraResultado()
    {
        var tempFile = Path.GetTempFileName();
        try
        {
            File.WriteAllLines(tempFile, ["10.0", "20.0"]);
            using var entrada = new StringReader(string.Empty);
            using var salida = new StringWriter();

            var codigo = Aplicacion.Ejecutar([tempFile], entrada, salida);

            Assert.Equal(Aplicacion.Exito, codigo);
            var salidaTexto = salida.ToString();
            Assert.Contains("Cantidad de datos (n) : 2", salidaTexto);
            Assert.Contains("Media aritmética      : 15.00", salidaTexto);
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }
    }

    // CP-16: Sin argumento pide la ruta interactivamente (RF-07)
    [Fact]
    public void CP16_SinArgumento_PideRutaPorEntrada()
    {
        var tempFile = Path.GetTempFileName();
        try
        {
            File.WriteAllLines(tempFile, ["5.0", "5.0"]);
            using var entrada = new StringReader(tempFile + Environment.NewLine);
            using var salida = new StringWriter();

            var codigo = Aplicacion.Ejecutar([], entrada, salida);

            Assert.Equal(Aplicacion.Exito, codigo);
            Assert.Contains("Ingrese la ruta del archivo de datos:", salida.ToString());
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }
    }

    // CP-17: Archivo vacío por consola retorna Error (código 1) (RF-06)
    [Fact]
    public void CP17_ArchivoVacio_MuestraErrorYRetornaError()
    {
        var tempFile = Path.GetTempFileName();
        try
        {
            File.WriteAllText(tempFile, "   \n\n  ");
            using var entrada = new StringReader(string.Empty);
            using var salida = new StringWriter();

            var codigo = Aplicacion.Ejecutar([tempFile], entrada, salida);

            Assert.Equal(Aplicacion.Error, codigo);
            Assert.Contains("[ERROR]", salida.ToString());
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }
    }

    // CP-18: Archivo con 1 número muestra desviación no definida y código 0 (RF-04, RF-06)
    [Fact]
    public void CP18_UnDato_MuestraNoDefinidaYRetornaExito()
    {
        var tempFile = Path.GetTempFileName();
        try
        {
            File.WriteAllLines(tempFile, ["100.0"]);
            using var entrada = new StringReader(string.Empty);
            using var salida = new StringWriter();

            var codigo = Aplicacion.Ejecutar([tempFile], entrada, salida);

            Assert.Equal(Aplicacion.Exito, codigo);
            Assert.Contains("no definida (se necesitan al menos 2 datos)", salida.ToString());
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }
    }
}
