namespace Programa1.Estadistica.Presentacion;

using System.Globalization;
using System.IO;
using Programa1.Estadistica.Dominio;

/// <summary>
/// Gestiona la interacción en consola con el usuario.
/// </summary>
public sealed class ConsolaUI
{
    private readonly TextReader _entrada;
    private readonly TextWriter _salida;

    public ConsolaUI(TextReader entrada, TextWriter salida)
    {
        _entrada = entrada;
        _salida = salida;
    }

    public void MostrarEncabezado()
    {
        _salida.WriteLine("==================================================");
        _salida.WriteLine("    PROGRAMA 1 · MEDIA Y DESVIACIÓN ESTÁNDAR      ");
        _salida.WriteLine("==================================================");
    }

    public string PedirRuta()
    {
        _salida.Write("Ingrese la ruta del archivo de datos: ");
        var ruta = _entrada.ReadLine();
        return ruta?.Trim() ?? string.Empty;
    }

    public void MostrarResultado(string ruta, ResultadoEstadistico resultado)
    {
        _salida.WriteLine($"\nArchivo procesado     : {ruta}");
        _salida.WriteLine($"Cantidad de datos (n) : {resultado.Cantidad}");
        _salida.WriteLine($"Media aritmética      : {resultado.Media.ToString("F2", CultureInfo.InvariantCulture)}");

        if (resultado.DesviacionEstandar.HasValue)
        {
            _salida.WriteLine($"Desv. estándar (s)    : {resultado.DesviacionEstandar.Value.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        else
        {
            _salida.WriteLine("Desv. estándar (s)    : no definida (se necesitan al menos 2 datos)");
        }
    }

    public void MostrarError(string mensaje)
    {
        _salida.WriteLine($"\n[ERROR] {mensaje}");
    }
}
