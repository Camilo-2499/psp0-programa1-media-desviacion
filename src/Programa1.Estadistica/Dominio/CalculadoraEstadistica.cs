namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Calcula la media aritmética y la desviación estándar muestral
/// de una lista enlazada de números reales.
/// </summary>
public static class CalculadoraEstadistica
{
    /// <summary>Datos mínimos requeridos para la desviación estándar muestral.</summary>
    public const int MinimoParaDesviacion = 2;

    /// <summary>Calcula la media aritmética: suma de los datos dividida entre n.</summary>
    /// <exception cref="DatosInsuficientesException">Si la lista está vacía.</exception>
    public static double Media(ListaEnlazada datos)
    {
        ArgumentNullException.ThrowIfNull(datos);

        if (datos.EstaVacia)
        {
            throw new DatosInsuficientesException("Se necesita al menos 1 dato para calcular la media.");
        }

        double suma = 0;

        foreach (var valor in datos)
        {
            suma += valor;
        }

        return suma / datos.Cantidad;
    }

    /// <summary>
    /// Calcula la desviación estándar muestral: raíz de la suma de diferencias al cuadrado dividida entre (n - 1).
    /// </summary>
    /// <exception cref="DatosInsuficientesException">Si hay menos de 2 datos.</exception>
    public static double DesviacionEstandar(ListaEnlazada datos)
    {
        ArgumentNullException.ThrowIfNull(datos);

        if (datos.Cantidad < MinimoParaDesviacion)
        {
            throw new DatosInsuficientesException(
                $"Se necesitan al menos {MinimoParaDesviacion} datos para calcular la desviación estándar.");
        }

        var media = Media(datos);
        double sumaCuadrados = 0;

        foreach (var valor in datos)
        {
            sumaCuadrados += Math.Pow(valor - media, 2);
        }

        return Math.Sqrt(sumaCuadrados / (datos.Cantidad - 1));
    }

    /// <summary>
    /// Calcula la media y, si hay al menos 2 datos, la desviación estándar muestral.
    /// </summary>
    public static ResultadoEstadistico Calcular(ListaEnlazada datos)
    {
        var media = Media(datos);

        double? desviacion = datos.Cantidad >= MinimoParaDesviacion
            ? DesviacionEstandar(datos)
            : null;

        return new ResultadoEstadistico(datos.Cantidad, media, desviacion);
    }
}
