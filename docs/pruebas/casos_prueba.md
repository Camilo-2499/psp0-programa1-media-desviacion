# Casos de Prueba · Programa 1 (PSP0)

**Estudiante:** Camilo  
**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Framework de Pruebas:** xUnit (.NET 9)  
**Total de Casos:** 19  

---

## 1. Matriz de Casos de Prueba

| Id | Requisito | Descripción | Entrada | Resultado Esperado | Estado |
|---|---|---|---|---|:---:|
| **CP-01** | RF-03, RF-04, RNF-03 | Datos del Kit: Tabla 1, Columna 1 (Proxy Size) | 160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503 | Media: 550.60, Desv: 572.03 | ✅ Pasa |
| **CP-02** | RF-03, RF-04, RNF-03 | Datos del Kit: Tabla 1, Columna 2 (Development Hours) | 15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2 | Media: 60.32, Desv: 62.26 | ✅ Pasa |
| **CP-03** | RF-03, RF-04 | Datos del Kit: Tabla 3 (Ejemplo resuelto) | 186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601 | Media: 638.90, Desv: 625.63 | ✅ Pasa |
| **CP-04** | RF-06 | Validación: Lista vacía a cálculo de media | ListaEnlazada vacía | Lanza `DatosInsuficientesException` | ✅ Pasa |
| **CP-05** | RF-04, RF-06 | Límite: Lista con un único dato | `42.5` | Media: 42.50, Desviación: null (no definida) | ✅ Pasa |
| **CP-06** | RF-04 | Límite: Muestra con datos idénticos | `7.0, 7.0, 7.0, 7.0` | Desviación estándar: 0.00 | ✅ Pasa |
| **CP-07** | RF-03, RF-04 | Partición: Números negativos y cero | `-2.5, 0.0, 2.5` | Media: 0.00, Desviación: 2.50 | ✅ Pasa |
| **CP-08** | RF-02 | ListaEnlazada: Inserción y preservación de orden | Agregar `3.0, 1.0, 2.0` | Cantidad: 3, Orden: `[3, 1, 2]` | ✅ Pasa |
| **CP-09** | RF-01 | Lector: Líneas en blanco intermedias | Espacios y líneas vacías entre números | Se ignoran líneas vacías, conserva datos | ✅ Pasa |
| **CP-10** | RF-06, RNF-05 | Lector: Dato no numérico | `"1.0", "2.0", "abc"` | Lanza excepción indicando «Línea 3» y «abc» | ✅ Pasa |
| **CP-11** | RF-06 | Lector: Archivo compuesto solo por espacios | Líneas vacías | Lanza `DatosInvalidosException` | ✅ Pasa |
| **CP-12** | RF-06 | Lector: Archivo inexistente | `"archivo_ficticio_no_existe.txt"` | Lanza `FileNotFoundException` | ✅ Pasa |
| **CP-13** | RNF-02 | Cultura: Configuración regional Colombia (es-CO) | `"15.0", "6.5"` con cultura es-CO | Lee `15.0` y `6.5` (no `150` y `65`) | ✅ Pasa |
| **CP-14** | RF-01 | Lector: Archivo físico del kit en disco | `datos/columna2_horas.txt` | Lee exactamente `n = 10` números | ✅ Pasa |
| **CP-15** | RF-05, RF-07 | Interfaz: Ruta suministrada por argumento CLI | Argumento `tempFile` | Muestra resultados formateados y código 0 | ✅ Pasa |
| **CP-16** | RF-07 | Interfaz: Sin argumento pide ruta por consola | Entrada simulada | Solicita ruta y ejecuta con código 0 | ✅ Pasa |
| **CP-17** | RF-06 | Interfaz: Archivo vacío por consola | Archivo sin números | Muestra `[ERROR]` y retorna código 1 | ✅ Pasa |
| **CP-18** | RF-04, RF-06 | Interfaz: Archivo con 1 número por consola | Archivo con `100.0` | Muestra «desv. estándar: no definida», código 0 | ✅ Pasa |
| **CP-19** | RNF-06 | Rendimiento: Carga masiva de datos | 100.000 números reales | Tiempo < 1.000 ms (obtenido: ~200 ms) | ✅ Pasa |
