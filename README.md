# BibliotecaUNI_E8
Entregable #8 de la Clase de Programación de Aplicaciones de Escritorio 

## Solución de problemas: Archivos de recursos (.resx) bloqueados

Si al clonar o descargar el repositorio por primera vez Visual Studio no te deja abrir los formularios o muestra un error de recursos bloqueados por seguridad (*Zone.Identifier*), sigue estos pasos:

### Opción 1: Desbloqueo rápido mediante PowerShell (Recomendado)
1. Cierra **Visual Studio**.
2. Abre la terminal de **PowerShell** dentro de la carpeta raíz de este proyecto.
3. Ejecuta el siguiente comando para desbloquear todos los archivos descargados:

```powershell
Get-ChildItem -Recurse | Unblock-File
