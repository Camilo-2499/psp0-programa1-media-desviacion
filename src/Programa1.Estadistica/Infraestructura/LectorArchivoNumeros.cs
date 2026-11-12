namespace Programa1.Estadistica.Infraestructura;

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Programa1.Estadistica.Dominio;

/// <summary>
/// Lee números reales desde un archivo de texto o secuencia de líneas.
/// </summary>
public static class LectorArchivoNumeros
{
    private static double Convertir(string texto, int numeroLinea)
    {
        if (double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out var valor)
            && double.IsFinite(valor))
        {
            return valor;
        }

        throw new DatosInvalidosException(
            $"Línea {numeroLinea}: «{texto}» no es un número real. Use punto decimal (ej. 15.0).", numeroLinea);
    }

    /// <summary>Procesa una colección de líneas de texto y las guarda en la lista enlazada.</summary>
    public static ListaEnlazada LeerLineas(IEnumerable<string> lineas)
    {
        ArgumentNullException.ThrowIfNull(lineas);

        var lista = new ListaEnlazada();
        int numeroLinea = 0;

        foreach (var linea in lineas)
        {
            numeroLinea++;

            if (string.IsNullOrWhiteSpace(linea))
            {
                continue;
            }

            double valor = Convertir(linea.Trim(), numeroLinea);
            lista.Agregar(valor);
        }

        if (lista.EstaVacia)
        {
            throw new DatosInvalidosException("El archivo no contiene datos numéricos válidos.");
        }

        return lista;
    }

    /// <summary>Lee un archivo desde el disco y retorna la lista enlazada.</summary>
    public static ListaEnlazada Leer(string ruta)
    {
        if (string.IsNullOrWhiteSpace(ruta))
        {
            throw new DatosInvalidosException("La ruta del archivo no puede estar vacía.");
        }

        if (!File.Exists(ruta))
        {
            throw new FileNotFoundException($"No se encontró el archivo: «{ruta}».");
        }

        return LeerLineas(File.ReadLines(ruta));
    }
}
