namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Se lanza cuando no hay suficientes datos para un cálculo estadístico.
/// </summary>
public class DatosInsuficientesException : InvalidOperationException
{
    /// <summary>Crea la excepción con un mensaje descriptivo.</summary>
    /// <param name="mensaje">Texto que explica qué faltó.</param>
    public DatosInsuficientesException(string mensaje) : base(mensaje) { }
}
