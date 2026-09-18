Quiero que generes un programa de gestión de kiosco en C# usando .NET 6 (o .NET 7/8) con Windows Forms (WinForms), replicando el mismo formato, arquitectura y estilo que se detallan a continuación.

TECNOLOGÍA Y ESTRUCTURA DEL PROYECTO
- Lenguaje: C#, proyecto .NET 6+ tipo WinExe con UseWindowsForms=true (SDK-style .csproj), sin paquetes NuGet externos (solo librerías base del framework).
- Solución (.sln) con un único proyecto de Windows Forms.
- Persistencia SIN base de datos: todo el estado del sistema se guarda mediante serialización binaria (BinaryFormatter) en un único archivo (ej. "sistema.dat") dentro de una carpeta en Mis Documentos (ej. Documentos/ArchivosKiosco/). Los tickets de venta se exportan además como archivos de texto plano individuales en otra carpeta (ej. Documentos/TicketsKiosco/).
  - Nota: BinaryFormatter está obsoleto (SYSLIB0011) y fue eliminado en .NET 9, por eso el proyecto debe apuntar a net6.0-windows, net7.0-windows o net8.0-windows. Habilitarlo con <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization> en el .csproj y suprimir la advertencia SYSLIB0011. Si no se puede, usar DataContractSerializer como alternativa equivalente.
- Todo el código, comentarios (XML /// en cada clase y método), nombres de variables y mensajes de la interfaz deben estar en ESPAÑOL. Clases de modelo en PascalCase.
- Sin capas formales tipo MVC: usar el patrón típico de WinForms Designer (cada pantalla es un Form con su .cs, .Designer.cs y .resx), navegando entre formularios con Show()/Hide()/ShowDialog() e inyectando referencias por constructor (sin frameworks de DI).
- Incluir comentarios de código en español explicando el propósito de clases y métodos.

ARQUITECTURA DE CLASES (POO con herencia y polimorfismo)
- Clase abstracta "Persona": Nombres, Apellidos, DNI, FechaNacimiento, Edad (calculada), y una lista de registros de actividad (ej. asistencias/turnos). Debe sobrescribir ToString() de forma distinta en cada clase hija (polimorfismo).
- "Empleado : Persona": Contraseña, Sueldo por día u hora, historial de turnos trabajados, y métodos para registrar ventas y marcar su propia asistencia.
- "Administrador": Contraseña propia (valor por defecto de ejemplo), da de alta/baja empleados y productos, y puede marcar asistencia de empleados.
- "Producto": Código, Nombre, Categoría, Precio, Stock actual, Proveedor (opcional). Con método para descontar stock al vender.
- "Venta" (equivalente a un ticket/factura): Fecha y hora, Empleado que la realizó, lista de (Producto, Cantidad, Subtotal), Total, Medio de pago (efectivo/tarjeta). Debe generar un archivo de texto tipo ticket al confirmarse.
- "Caja": control de apertura/cierre de caja por turno o por día, total vendido, listado histórico de Ventas, y lógica para calcular totales y el sueldo a pagar a cada empleado según sus ventas o turnos trabajados.
- "Sistema": clase contenedora raíz con el Administrador, la Caja, la lista de Empleados y la lista de Productos. Debe tener métodos Guardar() y Abrir() que serialicen/deserialicen todo el objeto a disco, con manejo de excepción si el archivo no existe todavía (primera ejecución).
- Todas las clases del modelo deben marcarse como [Serializable].

PANTALLAS Y FLUJO DE NAVEGACIÓN (tipo wizard, igual que el TP de referencia)
1. Form inicial (splash/selección): botones para "Ingresar como Administrador" o "Ingresar como Empleado".
2. Form de login de Administrador: campo de contraseña con validación (ErrorProvider), contraseña por defecto de ejemplo (ej. "123123").
3. Form de login de Empleado: combo con la lista de empleados registrados + campo de contraseña propia; al ingresar se marca su asistencia/turno automáticamente.
4. Panel de Administrador (post-login):
   - ABM de Empleados (alta con validación de campos: nombre, apellido, DNI, fecha de nacimiento con combos día/mes/año, contraseña, sueldo), baja, listado en DataGridView, ficha de detalle.
   - ABM de Productos (alta con código, nombre, categoría, precio, stock, proveedor), baja, edición de precio/stock, listado en DataGridView.
   - Configuración de precios/promociones (equivalente a la gestión de tarifas de la Caja).
   - Ver reportes: historial de ventas, ventas por empleado, cierre de caja.
5. Panel de Empleado (post-login):
   - Pantalla de venta: buscar/seleccionar productos, indicar cantidad, agregar a un carrito (lista), calcular total, elegir medio de pago, confirmar venta (descuenta stock, genera Venta, imprime/genera ticket .txt).
   - Ver su propio historial de ventas del día/turno.

VALIDACIONES Y UX
- Validaciones de campos centralizadas (tipo "Números", "Letras", "Contraseña") usando ErrorProvider y la propiedad Tag de los controles como metadato del tipo de validación, igual que en el proyecto de referencia.
- Uso de MessageBox.Show para toda la retroalimentación al usuario (éxito, error, confirmaciones sí/no).
- Guardado automático del Sistema (Guardar()) después de cada operación relevante (alta, baja, venta, cierre de caja), y carga automática (Abrir()) al iniciar la aplicación.
- Incluir imágenes/recursos decorativos simples en las pantallas (carpeta Resources), como en el proyecto original.

ENTREGABLES ESPERADOS
- Estructura completa de carpetas y archivos del proyecto (.sln, .csproj, Forms, clases de modelo, Properties, Resources).
- Código completo y funcional de cada clase y formulario.
- Un archivo de texto breve (tipo "IMPORTANTE ANTES DE USAR.txt") con instrucciones de uso: contraseña de administrador por defecto, orden recomendado de carga de datos (primero empleados, luego productos), y advertencia de que se generan carpetas en Documentos que conviene borrar después de probar.
