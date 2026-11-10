# Estándar de Codificación C# (.NET 9) · PSP0

Este estándar define las reglas obligatorias para la escritura de código en la Fase 3, asegurando calidad, legibilidad y cumplimiento de los requisitos de mantenibilidad (RNF-04).

---

## 1. Convenciones de Nomenclatura

* **E-01:** Clases, estructuras, registros, métodos y propiedades en **PascalCase**. Los nombres deben ser sustantivos o verbos descriptivos en español (ej. `CalculadoraEstadistica`, `CalcularMedia`).
* **E-02:** Parámetros y variables locales en **camelCase** (ej. `sumaCuadrados`, `numeroLinea`).
* **E-03:** Campos privados en **_camelCase** con prefijo de guion bajo (ej. `_primero`, `_ultimo`).
* **E-04:** Constantes en **PascalCase** sin números mágicos (ej. `MinimoParaDesviacion = 2`).

---

## 2. Estructura y Buenas Prácticas

* **E-08:** Métodos cortos: **máximo 30 líneas de código**. Cada método debe tener una sola responsabilidad bien delimitada.
* **E-09:** Comentarios XML de documentación (`/// <summary>`) obligatorios en todas las clases, métodos y propiedades públicas. Comentarios de línea (`//`) solo para explicar el "por qué", no el "qué".
* **E-11:** Manejo explícito de errores: se deben crear clases de excepción propias (`DatosInvalidosException`, `DatosInsuficientesException`). Está prohibido capturar excepciones vacías (`catch { }`).
* **E-12:** Conversión y formateo numérico siempre con **`CultureInfo.InvariantCulture`** y `NumberStyles.Float` para evitar fallos por configuración regional (coma vs. punto decimal).
* **E-13:** Los acumuladores de sumas reales deben declararse siempre como `double` (nunca `int` ni `float` para no perder precisión).
* **E-16:** El Dominio no debe tener referencias a `System.Console`, `System.IO.File`, ni depender de otras capas.
