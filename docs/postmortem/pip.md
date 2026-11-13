# Propuesta de Mejora del Proceso (PIP #1) · PSP0

**Estudiante:** Camilo  
**Fecha:** 13 de noviembre de 2026  
**Proyecto:** Programa 1 · Media y Desviación Estándar  

---

## 1. Descripción del Problema o Hallazgo

### Hallazgo 1: Sobreestimación en fases de Código y Pruebas
* **Medición:** El tiempo real de Código (65 min) y Pruebas (25 min) fue notablemente menor a lo planeado (90 min y 60 min respectivamente), generando un error global de estimación de $-29.6\ \%$.
* **Causa:** El diseño detallado en pseudocódigo y traza de escritorio en la Fase 2 fue tan exhaustivo que al momento de codificar solo se requirió traducción directa sin improvisación ni retrabajos por errores lógicos.
* **Propuesta para el Programa 2:** Ajustar las proporciones históricas: en problemas estructurados, el Diseño debe representar $\approx 22\ \%$ del esfuerzo y las Pruebas automatizadas $\approx 15\ - 20\ \%$, reduciendo la contingencia del $10\ \%$ al $5\ \%$.

---

### Hallazgo 2: Dependencia de configuración de Git en estaciones compartidas
* **Medición:** Se requirieron $\approx 10$ minutos para configurar Git portable y credenciales personales (PAT) debido a que la estación de trabajo compartida tenía credenciales de otro usuario en caché.
* **Causa:** Las salas de informática académica mantienen perfiles genéricos sin control de versiones preinstalado o con sesiones previas activas.
* **Propuesta para el Programa 2:** Mantener el token de acceso personal (PAT) listo y configurar el repositorio con Git portable en la primera fase (Planeación) para que no impacte la fluidez de las fases de desarrollo.

---

### Hallazgo 3: Alta efectividad de la arquitectura en 4 capas y xUnit
* **Medición:** 19 de 19 pruebas pasaron a la primera ejecución; cero errores de compilación y cero defectos en pruebas.
* **Causa:** Aislar el Dominio matemático (`CalculadoraEstadistica` y `ListaEnlazada`) de la Infraestructura (`File`) y la Presentación (`Console`) permitió verificar cada regla de negocio de forma pura e independiente.
* **Propuesta para el Programa 2:** Reutilizar directamente la clase `ListaEnlazada` y los patrones de `ConsolaUI` en los siguientes programas del curso (Programa 2 y 3), aprovechando la modularidad ya construida.

---

## 2. Metas Numéricas para el Programa 2

| Métrica | Valor Obtenido en Programa 1 | Meta para Programa 2 |
|---|:---:|:---:|
| **Error de Estimación Global** | $-29.6\ \%$ | Entre $-15\ \%$ y $+15\ \%$ |
| **Tiempo en Pruebas Automatizadas** | $25$ minutos | $\le 30$ minutos |
| **Compilaciones Limpias (0 errores)** | 1 (100 %) | Mantener $\ge 80\ \%$ |
| **Defectos inyectados en Código** | 0 | $\le 2$ defectos |
