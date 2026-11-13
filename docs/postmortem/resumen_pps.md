# Resumen del Plan del Proyecto (PPS) · PSP0

**Estudiante:** Camilo  
**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Lenguaje:** C# (.NET 9)  
**Fecha de Cierre:** 13 de noviembre de 2026  

---

## 1. Resumen de Tiempos (Plan vs. Real)

| Fase PSP0 | Tiempo Planeado (min) | Tiempo Real (min) | Diferencia (min) | % del Total Real |
|---|:---:|:---:|:---:|:---:|
| **1. Planeación** | 30 | 48 | +18 | 22.8 % |
| **2. Diseño** | 50 | 46 | -4 | 21.9 % |
| **3. Código** | 90 | 65 | -25 | 30.9 % |
| **4. Compilación** | 15 | 12 | -3 | 5.7 % |
| **5. Pruebas** | 60 | 25 | -35 | 11.9 % |
| **6. Postmortem** | 25 | 15 | -10 | 6.8 % |
| *Contingencia (10 %)* | 30 | — | — | — |
| **TOTAL** | **300 min** | **211 min** | **-89 min** | **100.0 %** |

* **Error de estimación:** $\frac{211 - 300}{300} = -29.6\ \% $ (El proyecto concluyó un ~30 % más rápido de lo estimado gracias a la ausencia de defectos en código y pruebas automatizadas).

---

## 2. Resumen de Tamaño (Líneas de Código - LOC)

| Componente | Total Líneas | Líneas de Código (LOC) | Comentarios | Blancos |
|---|:---:|:---:|:---:|:---:|
| **Capa de Dominio** | 175 | 124 | 28 | 23 |
| **Capa de Infraestructura** | 88 | 58 | 14 | 16 |
| **Capa de Presentación** | 52 | 34 | 8 | 10 |
| **Aplicación y Program** | 45 | 30 | 5 | 10 |
| **Subtotal Código Fuente (`src/`)** | **360** | **246** | **55** | **59** |
| **Pruebas Automatizadas (`tests/`)** | **342** | **250** | **45** | **47** |
| **TOTAL GENERAL DEL PROYECTO** | **702** | **496** | **100** | **106** |

* **Densidad de comentarios en `src/`:** $15.3\ \%$ (Cumple holgadamente el estándar de documentación E-09).
* **Ratio Pruebas / Código:** $0.95$ (Casi 1 línea de prueba por cada línea de código de producción).

---

## 3. Resumen de Defectos (Defect Log)

| Fase | Inyectados | Eliminados | % Defectos |
|---|:---:|:---:|:---:|
| **Planeación** | 1 (D1 - Ambigüedad desviación muestral) | 0 | 100.0 % |
| **Diseño** | 0 | 1 (D1 corregido en traza) | 0.0 % |
| **Código** | 0 | 0 | 0.0 % |
| **Compilación** | 0 | 0 | 0.0 % |
| **Pruebas** | 0 | 0 | 0.0 % |
| **TOTAL** | **1** | **1** | **100 %** |

* **Calidad de Compilación:** Compilación limpia (*Clean Compile*) en el primer intento con `TreatWarningsAsErrors` activo.
* **Calidad de Pruebas:** 19 de 19 casos pasados a la primera ejecución (100 % efectividad).
