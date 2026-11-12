# Informe de Ejecución de Pruebas · Programa 1 (PSP0)

**Estudiante:** Camilo  
**Fecha de Ejecución:** 12 de noviembre de 2026  
**Ambiente:** .NET 9.0 · xUnit v2.8.2 · Windows 11  

---

## 1. Resumen Ejecutivo de la Serie de Pruebas

| Métrica | Valor |
|---|---|
| **Total de pruebas ejecutadas** | **19** |
| **Pruebas superadas (Passed)** | **19 (100 %)** |
| **Pruebas fallidas (Failed)** | **0 (0 %)** |
| **Pruebas omitidas (Skipped)** | **0** |
| **Tiempo total de ejecución** | **2.43 segundos** |

---

## 2. Evidencia de Ejecución con xUnit (`dotnet test`)

```text
Serie de pruebas para Programa1.Estadistica.Tests.dll (.NETCoreApp,Version=v9.0)
[xUnit.net]   Discovering: Programa1.Estadistica.Tests
[xUnit.net]   Discovered:  Programa1.Estadistica.Tests
[xUnit.net]   Starting:    Programa1.Estadistica.Tests
  Correctas LectorArchivoNumerosTests.CP11_SoloEspacios_LanzaDatosInvalidosException [183 ms]
  Correctas CalculadoraEstadisticaTests.CP06_DatosIdenticos_DesviacionCero [183 ms]
  Correctas CalculadoraEstadisticaTests.CP02_Tabla1Columna2_MediaYDesviacionEsperadas [< 1 ms]
  Correctas CalculadoraEstadisticaTests.CP03_Tabla3Ejemplo_MediaYDesviacionEsperadas [< 1 ms]
  Correctas CalculadoraEstadisticaTests.CP04_ListaVacia_LanzaDatosInsuficientesException [< 1 ms]
  Correctas CalculadoraEstadisticaTests.CP07_NumerosNegativosYCero_CalculaCorrectamente [< 1 ms]
  Correctas CalculadoraEstadisticaTests.CP05_UnSoloDato_MediaDefinidaDesviacionNull [< 1 ms]
  Correctas CalculadoraEstadisticaTests.CP01_Tabla1Columna1_MediaYDesviacionEsperadas [< 1 ms]
  Correctas RendimientoTests.CP19_CienMilDatos_ProcesaEnMenosDeUnSegundo [200 ms]
  Correctas LectorArchivoNumerosTests.CP13_CulturaColombia_UsaPuntoDecimal [6 ms]
  Correctas LectorArchivoNumerosTests.CP12_ArchivoInexistente_LanzaFileNotFoundException [< 1 ms]
  Correctas ListaEnlazadaTests.CP08_ListaEnlazada_ConservaOrdenYCantidad [201 ms]
  Correctas LectorArchivoNumerosTests.CP14_ArchivoReal_LeeCorrectamente [2 ms]
  Correctas AplicacionTests.CP18_UnDato_MuestraNoDefinidaYRetornaExito [211 ms]
  Correctas LectorArchivoNumerosTests.CP10_DatoNoNumerico_IndicaNumeroLinea [8 ms]
  Correctas LectorArchivoNumerosTests.CP09_LineasEnBlanco_SeIgnoran [< 1 ms]
  Correctas AplicacionTests.CP16_SinArgumento_PideRutaPorEntrada [8 ms]
  Correctas AplicacionTests.CP15_RutaPorArgumento_RetornaExitoYMuestraResultado [9 ms]
  Correctas AplicacionTests.CP17_ArchivoVacio_MuestraErrorYRetornaError [8 ms]

La serie de pruebas se ejecutó correctamente.
Pruebas totales: 19
     Correcto: 19
 Tiempo total: 2,4314 Segundos
```

---

## 3. Verificación de Criterios del Assignment Kit

| Conjunto de Prueba | Media Esperada | Media Obtenida | Desv. Esperada | Desv. Obtenida | Cumplimiento |
|---|:---:|:---:|:---:|:---:|:---:|
| **Columna 1 (Proxy Size)** | 550.60 | **550.60** | 572.03 | **572.03** | Exacto (±0.00) |
| **Columna 2 (Hours)** | 60.32 | **60.32** | 62.26 | **62.26** | Exacto (±0.00) |
| **Tabla 3 (Ejemplo kit)** | 638.90 | **638.90** | 625.63 | **625.63** | Exacto (±0.00) |

---

## 4. Defect Log en Pruebas

* **Defectos encontrados en la fase de pruebas:** **0**.
* Todas las aserciones numéricas y de control de excepciones se cumplieron en la primera ejecución completa de la suite de pruebas.
