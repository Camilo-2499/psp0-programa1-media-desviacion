# Pseudocódigo del Sistema · Programa 1 (PSP0)
**Programa:** Cálculo de Media y Desviación Estándar Muestral  
**Lenguaje meta:** C# (.NET 9)  

---

## 1. Módulo Dominio: Estructura de Datos (Lista Enlazada)

### 1.1. Estructura del Nodo
```text
CLASE Nodo
    ATRIBUTOS:
        valor: real
        siguiente: Nodo (puede ser nulo)

    CONSTRUCTOR(val: real)
        valor ← val
        siguiente ← NULO
    FIN CONSTRUCTOR
FIN CLASE
```

### 1.2. Clase ListaEnlazada
```text
CLASE ListaEnlazada
    ATRIBUTOS PRIVADOS:
        _primero: Nodo (nulo al inicio)
        _ultimo: Nodo (nulo al inicio)
    
    PROPIEDADES PÚBLICAS:
        Cantidad: entero (inicia en 0)
        EstaVacia: booleano (retorna Cantidad == 0)

    MÉTODO Agregar(val: real): vacío
        nuevo ← NUEVO Nodo(val)
        SI _ultimo ES NULO ENTONCES
            _primero ← nuevo
        SINO
            _ultimo.siguiente ← nuevo
        FIN SI
        _ultimo ← nuevo
        Cantidad ← Cantidad + 1
    FIN MÉTODO

    MÉTODO ObtenerIterador(): Retorna cada elemento en orden de inserción
        actual ← _primero
        MIENTRAS actual NO SEA NULO HACER
            RETORNAR ELEMENTO actual.valor
            actual ← actual.siguiente
        FIN MIENTRAS
    FIN MÉTODO
FIN CLASE
```

---

## 2. Módulo Dominio: Calculadora Estadística

```text
CLASE CalculadoraEstadistica
    CONSTANTE MinimoParaDesviacion = 2

    FUNCIÓN Media(datos: ListaEnlazada): real
        SI datos.EstaVacia ENTONCES
            LANZAR DatosInsuficientesException("Se necesita al menos 1 dato para calcular la media.")
        FIN SI

        suma ← 0.0  // Debe ser real de doble precisión
        PARA CADA x EN datos HACER
            suma ← suma + x
        FIN PARA

        RETORNAR suma / datos.Cantidad
    FIN FUNCIÓN

    FUNCIÓN DesviacionEstandar(datos: ListaEnlazada): real
        SI datos.Cantidad < MinimoParaDesviacion ENTONCES
            LANZAR DatosInsuficientesException("Se necesitan al menos 2 datos para calcular la desviación estándar.")
        FIN SI

        media ← Media(datos)
        sumaCuadrados ← 0.0

        PARA CADA x EN datos HACER
            diferencia ← x - media
            sumaCuadrados ← sumaCuadrados + (diferencia * diferencia)
        FIN PARA

        // Fórmula Muestral: dividir entre (n - 1)
        varianza ← sumaCuadrados / (datos.Cantidad - 1)
        RETORNAR RaizCuadrada(varianza)
    FIN FUNCIÓN

    FUNCIÓN Calcular(datos: ListaEnlazada): ResultadoEstadistico
        media ← Media(datos)
        desviacion ← NULO
        SI datos.Cantidad >= MinimoParaDesviacion ENTONCES
            desviacion ← DesviacionEstandar(datos)
        FIN SI
        RETORNAR NUEVO ResultadoEstadistico(datos.Cantidad, media, desviacion)
    FIN FUNCIÓN
FIN CLASE
```

---

## 3. Módulo Infraestructura: Lector de Archivos

```text
CLASE LectorArchivoNumeros
    FUNCIÓN Leer(ruta: texto): ListaEnlazada
        SI NO ExisteArchivo(ruta) ENTONCES
            LANZAR DatosInvalidosException("No se encontró el archivo en la ruta especificada.")
        FIN SI

        lineas ← LeerTodasLasLineas(ruta)
        RETORNAR LeerLineas(lineas)
    FIN FUNCIÓN

    FUNCIÓN LeerLineas(lineas: ColecciónDeTexto): ListaEnlazada
        lista ← NUEVA ListaEnlazada()
        numeroLinea ← 0

        PARA CADA linea EN lineas HACER
            numeroLinea ← numeroLinea + 1
            textoLimpio ← linea.Trim()

            // Ignorar líneas vacías
            SI textoLimpio NO ESTÁ VACÍO ENTONCES
                valor ← ConvertirNumero(textoLimpio, numeroLinea)
                lista.Agregar(valor)
            FIN SI
        FIN PARA

        SI lista.EstaVacia ENTONCES
            LANZAR DatosInvalidosException("El archivo no contiene datos numéricos válidos.")
        FIN SI

        RETORNAR lista
    FIN FUNCIÓN

    FUNCIÓN ConvertirNumero(texto: texto, linea: entero): real
        // Parseo con InvariantCulture (punto decimal)
        SI ParsearDoubleInvariante(texto, out valor) Y EsFinito(valor) ENTONCES
            RETORNAR valor
        SINO
            LANZAR DatosInvalidosException("Línea " + linea + ": «" + texto + "» no es un número real válido. Use punto decimal (ej. 15.0).")
        FIN SI
    FIN FUNCIÓN
FIN CLASE
```

---

## 4. Módulo Presentación y Aplicación

```text
CLASE Aplicacion
    FUNCIÓN Ejecutar(args: ArregloDeTexto, entrada: LectorTexto, salida: EscritorTexto): entero
        ui ← NUEVA ConsolaUI(entrada, salida)
        ui.MostrarEncabezado()

        SI args.Longitud > 0 ENTONCES
            ruta ← args[0]
        SINO
            ruta ← ui.PedirRuta()
        FIN SI

        INTENTAR
            datos ← LectorArchivoNumeros.Leer(ruta)
            resultado ← CalculadoraEstadistica.Calcular(datos)
            ui.MostrarResultado(ruta, resultado)
            RETORNAR 0  // Código de salida EXIT_SUCCESS
        CAPTURAR DatosInvalidosException O DatosInsuficientesException COMO ex
            ui.MostrarError(ex.Mensaje)
            RETORNAR 1  // Código de salida EXIT_FAILURE
        CAPTURAR ExcepcionGeneral COMO ex
            ui.MostrarError("Error inesperado: " + ex.Mensaje)
            RETORNAR 1
        FIN INTENTAR
    FIN FUNCIÓN
FIN CLASE
```
