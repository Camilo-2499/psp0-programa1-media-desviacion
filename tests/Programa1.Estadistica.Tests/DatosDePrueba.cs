namespace Programa1.Estadistica.Tests;

using Programa1.Estadistica.Dominio;

internal static class DatosDePrueba
{
    // Tabla 1, Columna 1 del Kit (Proxy Size)
    public static readonly double[] Columna1 = [160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503];

    // Tabla 1, Columna 2 del Kit (Development Hours)
    public static readonly double[] Columna2 = [15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2];

    // Tabla 3 del Kit (Ejemplo resuelto)
    public static readonly double[] Tabla3 = [186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601];

    public static ListaEnlazada CrearLista(params double[] valores)
    {
        var lista = new ListaEnlazada();
        foreach (var v in valores)
        {
            lista.Agregar(v);
        }
        return lista;
    }
}
