# Documento de Diseño del Sistema · Programa 1 (PSP0)

---

## 1. Arquitectura en 4 Capas

El sistema sigue una arquitectura limpia en capas orientada al dominio:

```text
[ Presentación ]  --> ConsolaUI (Interactúa con el usuario, formatea datos y mensajes)
       |
       v
[  Aplicación  ]  --> Aplicacion.cs (Orquesta el flujo: ruta -> lector -> cálculo -> salida)
       |
       v
[Infraestructura] --> LectorArchivoNumeros (Lectura de disco y parseo invariante)
       |
       v
[   Dominio    ]  --> Nodo, ListaEnlazada, CalculadoraEstadistica, Excepciones
```

### Reglas Arquitectónicas:
1. **El Dominio es puro e independiente:** No sabe nada de archivos ni de `Console.ReadLine()` o `Console.WriteLine()`. Se puede reutilizar intacto en los siguientes programas del curso (Programa 3 y 4).
2. **Inyección de Entrada/Salida:** La capa de presentación y aplicación recibe `TextReader` y `TextWriter`, permitiendo pruebas unitarias automáticas sin depender de la consola física del sistema operativo.

---

## 2. Traza de Escritorio (Prueba Matemática a Mano)

Para validar el algoritmo antes de escribir una sola línea de código en C#, ejecutamos la traza con los datos de la **Tabla 3** del Assignment Kit del SEI:

**Datos:** $X = \{186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601\}$ ($n = 10$)

### Paso A: Media ($\bar{x}$)
$$\sum x_i = 186 + 699 + 132 + 272 + 291 + 331 + 199 + 1890 + 788 + 1601 = 6389.0$$
$$\bar{x} = \frac{6389.0}{10} = 638.90$$
*(Coincide exactamente con el valor del kit: 638.9)*

### Paso B: Suma de Diferencias al Cuadrado ($\sum (x_i - \bar{x})^2$)
* $(186 - 638.9)^2 = (-452.9)^2 = 205118.41$
* $(699 - 638.9)^2 = (60.1)^2 = 3612.01$
* $(132 - 638.9)^2 = (-506.9)^2 = 256947.61$
* $(272 - 638.9)^2 = (-366.9)^2 = 134615.61$
* $(291 - 638.9)^2 = (-347.9)^2 = 121034.41$
* $(331 - 638.9)^2 = (-307.9)^2 = 94802.41$
* $(199 - 638.9)^2 = (-439.9)^2 = 193512.01$
* $(1890 - 638.9)^2 = (1251.1)^2 = 1565251.21$
* $(788 - 638.9)^2 = (149.1)^2 = 22230.81$
* $(1601 - 638.9)^2 = (962.1)^2 = 925636.41$

$$\sum (x_i - \bar{x})^2 = 3522760.90$$

### Paso C: Comparación de Fórmulas de Desviación
* **División entre $n$ (Poblacional):**
  $$\sigma_{pob} = \sqrt{\frac{3522760.90}{10}} = \sqrt{352276.09} = 593.528 \text{ (INCORRECTO)}$$
* **División entre $n - 1$ (Muestral):**
  $$\sigma = \sqrt{\frac{3522760.90}{9}} = \sqrt{391417.8778} = \mathbf{625.633981} \text{ (CORRECTO)}$$

> 💡 **Lección aprendida:** La traza de escritorio demuestra matemáticamente que la desviación debe calcularse con $(n - 1)$. Si se hubiese usado $n$, se habría generado un defecto de diseño grave.

---

## 3. Justificación de Base de Datos
**Decisión:** **No se utiliza base de datos.**  
**Justificación:** El enunciado del SEI solicita procesar conjuntos de datos leídos directamente de archivos de texto plano y almacenarlos en memoria dinámica mediante una lista enlazada. Añadir una base de datos relacional (como SQLite o PostgreSQL) introduciría complejidad accidental, dependencias innecesarias de instalación y no aportaría a ninguno de los requisitos planteados.

---

## 4. Diseño de la Interfaz de Consola

### Escenario A: Ejecución normal con archivo
```text
==================================================
PSP0 · Programa 1 — Media y desviación estándar
==================================================
Archivo leído : datos/columna1_tamano_proxy.txt
Datos (n)     : 10
Media         : 550.60
Desv. estándar: 572.03
```

### Escenario B: Archivo con 1 solo dato ($n = 1$)
```text
==================================================
PSP0 · Programa 1 — Media y desviación estándar
==================================================
Archivo leído : datos/uno.txt
Datos (n)     : 1
Media         : 42.50
Desv. estándar: no definida (se necesitan al menos 2 datos)
```

### Escenario C: Error de archivo o dato inválido
```text
==================================================
PSP0 · Programa 1 — Media y desviación estándar
==================================================
ERROR: Línea 3: «abc» no es un número real. Use punto decimal (ej. 15.0).
```
*(Código de salida: 1)*
