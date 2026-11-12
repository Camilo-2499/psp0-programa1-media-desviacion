namespace Programa1.Estadistica.Dominio;

/// <summary>Empaqueta los resultados del cálculo estadístico.</summary>
/// <param name="Cantidad">Número de datos procesados (n).</param>
/// <param name="Media">Media aritmética.</param>
/// <param name="DesviacionEstandar">Desviación estándar muestral, o null si n &lt; 2.</param>
public record ResultadoEstadistico(
    int Cantidad,
    double Media,
    double? DesviacionEstandar);
