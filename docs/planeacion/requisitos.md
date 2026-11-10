# Requisitos del Sistema · Programa 1 (PSP0)
**Programa:** Cálculo de Media y Desviación Estándar Muestral  
**Lenguaje / Plataforma:** C# (.NET 9)  
**Nivel PSP:** PSP0  

---

## 1. Preguntas previas resueltas

| # | Pregunta | Decisión / Respuesta |
|---|---|---|
| **P1** | ¿De dónde se leen los datos? | De un archivo de texto plano (`.txt`), uno por línea. |
| **P2** | ¿Qué formato tiene el archivo? | Un número real por línea, punto decimal como separador. Las líneas en blanco se ignoran. |
| **P3** | ¿Se puede usar `List<double>` o colecciones genéricas de .NET? | **No.** El kit exige implementar y usar una **lista enlazada propia** (`ListaEnlazada`). |
| **P4** | ¿Cuántos decimales se deben mostrar en pantalla? | Dos decimales (`F2`), tal como indica la Tabla 2 del Assignment Kit. |
| **P5** | ¿La desviación estándar es muestral o poblacional? | **Muestral**, dividiendo entre $(n - 1)$. Para $n < 2$ no está definida. |

---

## 2. Requisitos Funcionales (RF)

| Id | Requisito | Criterio de Aceptación |
|---|---|---|
| **RF-01** | Leer $n$ números reales desde un archivo de texto plano. | Lee los 10 valores de cada columna de la Tabla 1 del kit ignorando líneas vacías. |
| **RF-02** | Almacenar los números en una lista enlazada propia. | La clase `ListaEnlazada` conserva el orden exacto de inserción y lleva la cuenta de cantidad $n$. |
| **RF-03** | Calcular la media aritmética ($\bar{x} = \frac{\sum x_i}{n}$). | Con la Columna 1 del kit da $550.60 \pm 0.01$; con la Columna 2 da $60.32 \pm 0.01$. |
| **RF-04** | Calcular la desviación estándar muestral ($\sigma = \sqrt{\frac{\sum (x_i - \bar{x})^2}{n - 1}}$). | Con la Columna 1 da $572.03 \pm 0.01$; con la Columna 2 da $62.26 \pm 0.01$. |
| **RF-05** | Mostrar resultados en consola con formato claro. | Muestra cantidad $n$, media y desviación con 2 decimales y etiquetas legibles. |
| **RF-06** | Validar datos de entrada y errores de archivo. | Si el archivo no existe, está vacío, o tiene líneas no numéricas, emite mensaje descriptivo en español y termina con código de salida `1`. |
| **RF-07** | Recibir la ruta del archivo por argumento o solicitarla. | Acepta `dotnet run -- ruta/archivo.txt` o pide la ruta por consola si no se pasa argumento. |

---

## 3. Requisitos No Funcionales (RNF)

| Id | Requisito | Criterio de Aceptación |
|---|---|---|
| **RNF-01** | Portabilidad y tecnología. | Consola en C# sobre .NET 9, ejecutable en Windows y Linux con `dotnet run`. |
| **RNF-02** | Independencia cultural / regional. | Usa `CultureInfo.InvariantCulture` para que números como `15.0` se interpreten siempre con punto decimal (evitando que `15.0` se lea como `150`). |
| **RNF-03** | Exactitud numérica. | Precisión de punto flotante de doble precisión (`double`), margen de error $\le 0.01$ respecto al Assignment Kit. |
| **RNF-04** | Mantenibilidad y arquitectura en capas. | Código dividido en capas (Dominio, Infraestructura, Presentación, Aplicación), métodos $\le 30$ líneas y cero advertencias del compilador. |
| **RNF-05** | Usabilidad de errores. | Mensajes de error claros sin mostrar excepciones técnicas descontroladas ni `NaN`. |
| **RNF-06** | Rendimiento. | Procesa listas de hasta 100 000 números en menos de 1 segundo. |
| **RNF-07** | Pruebas automatizadas. | Suite de pruebas unitarias xUnit cubriendo casos normales, límites y de error. |
| **RNF-08** | Trazabilidad y control de versiones. | Repositorio Git con al menos un commit al finalizar cada fase PSP. |
