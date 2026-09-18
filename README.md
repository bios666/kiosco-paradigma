# Kiosco - Sistema de gestión (C# / .NET 8 / Windows Forms)

Programa de gestión de un kiosco: administrador y empleados, ABM de productos,
ventas con carrito, caja (apertura y cierre), reportes y tickets en `.txt`.
Sin base de datos: todo se guarda con serialización binaria en `sistema.dat`.

## Cómo correrlo

Requisitos: **Windows 10/11** y el **SDK de .NET 8** (o Visual Studio 2022 con la carga
de trabajo "Desarrollo de escritorio con .NET").

```
git clone git@github.com:bios666/kiosco-paradigma.git
cd kiosco-paradigma
dotnet run --project Kiosco
```

O abrir `Kiosco.sln` en Visual Studio y ejecutar con F5.

> WinForms solo corre en Windows. No cambiar el framework a .NET 9 o superior:
> `BinaryFormatter` fue eliminado en esa versión.

## Primer uso

- Contraseña de administrador por defecto: `123123`
- Orden recomendado: primero **empleados**, después **productos**.
- El empleado debe **abrir la caja** antes de poder vender.
- Se crean las carpetas `Documentos\ArchivosKiosco` (datos) y `Documentos\TicketsKiosco`
  (tickets). Conviene borrarlas después de probar.

Más detalle en [`IMPORTANTE ANTES DE USAR.txt`](IMPORTANTE%20ANTES%20DE%20USAR.txt).

## Estructura

| Carpeta | Contenido |
|---|---|
| `Kiosco/Modelo` | `Persona` (abstracta) > `Empleado` / `Administrador`, `Producto`, `Venta`, `Caja`, `Sistema`... |
| `Kiosco/Formularios` | Una pantalla por Form (`.cs`, `.Designer.cs`, `.resx`) |
| `Kiosco/Utilidades` | `Validador` (ErrorProvider + Tag) y `Estilo` |
| `Kiosco/Resources` | Imagen decorativa |
| `PROMPT_KIOSCO.md` | Prompt con el que se especificó el proyecto |
