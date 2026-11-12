namespace Programa1.Estadistica.Infraestructura;

/// <summary>
/// Excepción lanzada cuando los datos del archivo no cumplen el formato esperado.
/// </summary>
public class DatosInvalidosException : Exception
{
    /// <summary>Número de línea donde ocurrió el error (opcional).</summary>
    public int? NumeroLinea { get; }

    public DatosInvalidosException(string mensaje) : base(mensaje) { }

    public DatosInvalidosException(string mensaje, int numeroLinea) : base(mensaje)
    {
        NumeroLinea = numeroLinea;
    }
}
