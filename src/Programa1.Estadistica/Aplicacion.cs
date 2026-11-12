namespace Programa1.Estadistica;

using System.IO;
using Programa1.Estadistica.Dominio;
using Programa1.Estadistica.Infraestructura;
using Programa1.Estadistica.Presentacion;

/// <summary>
/// Orquestador principal del flujo del programa.
/// </summary>
public static class Aplicacion
{
    public const int Exito = 0;
    public const int Error = 1;

    public static int Ejecutar(string[] args, TextReader entrada, TextWriter salida)
    {
        ArgumentNullException.ThrowIfNull(args);
        var ui = new ConsolaUI(entrada, salida);
        ui.MostrarEncabezado();

        try
        {
            string ruta = args.Length > 0 ? args[0] : ui.PedirRuta();

            ListaEnlazada datos = LectorArchivoNumeros.Leer(ruta);
            ResultadoEstadistico resultado = CalculadoraEstadistica.Calcular(datos);

            ui.MostrarResultado(ruta, resultado);
            return Exito;
        }
        catch (FileNotFoundException ex)
        {
            ui.MostrarError(ex.Message);
            return Error;
        }
        catch (DatosInvalidosException ex)
        {
            ui.MostrarError(ex.Message);
            return Error;
        }
        catch (DatosInsuficientesException ex)
        {
            ui.MostrarError(ex.Message);
            return Error;
        }
        catch (Exception ex)
        {
            ui.MostrarError($"Error inesperado: {ex.Message}");
            return Error;
        }
    }
}
