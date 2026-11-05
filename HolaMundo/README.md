# Proyecto 01 — Estefano S. — .NET MAUI

Aplicación para Android desarrollada en C# y XAML. Muestra cuatro diseños a partir
del idioma del dispositivo y la orientación de la ventana. No tiene botones:
el cambio se realiza girando el dispositivo y cambiando el idioma de Android.

## Los cuatro resultados

| Orientación | Idioma de Android | Texto | Fondo | Letra | Fuente | Tamaño base* |
|---|---|---|---|---|---|---|---|
| Vertical | Español u otro distinto de inglés | Vertical Estefano S. (Default) | #FFE0B2 | #751A35 | Serif negrita | 30 |
| Vertical | Inglés | Vertical Estefano S. (English Default) | #14213D | #FFE66D | Monoespaciada | 22 |
| Horizontal | Español u otro distinto de inglés | Horizontal Estefano S. (Default) | #C8F4D4 | #145A45 | Sans serif cursiva | 40 |
| Horizontal | Inglés | Horizontal Estefano S. (English Default) | #DCCCF7 | #462080 | Sans serif negrita | 32 |

\* Para conservar las proporciones, el tamaño base se multiplica por el ancho de
la página dividido para 600 (vertical) o 1067 (horizontal), con escala máxima 1.5.
Por ejemplo, en vertical con ancho de 360 unidades, los tamaños son 18 y 13.2.
Los tamaños de MAUI se expresan en unidades independientes de la densidad.
El escalado de texto del sistema está desactivado para esta práctica visual.

## Estructura

- `Proyecto_01.sln`: solución para abrir el proyecto.
- `EstefanoMaui/EstefanoMaui.csproj`: configuración de .NET y Android.
- `EstefanoMaui/App.xaml` y `App.xaml.cs`: arranque de la aplicación.
- `EstefanoMaui/MauiProgram.cs`: registro de las cuatro fuentes.
- `EstefanoMaui/MainPage.xaml`: pantalla con el texto centrado.
- `EstefanoMaui/MainPage.xaml.cs`: selección del diseño al girar la pantalla.
- `EstefanoMaui/Resources/Strings/AppResources.resx`: textos predeterminados.
- `EstefanoMaui/Resources/Strings/AppResources.en.resx`: textos en inglés.
- `EstefanoMaui/Resources/Styles/`: cuatro diccionarios XAML de diseño.
- `EstefanoMaui/Resources/Fonts/`: fuentes usadas por la app.
- `EstefanoMaui/Resources/AppIcon/` y `Splash/`: icono e imagen de inicio.
- `EstefanoMaui/Platforms/Android/`: arranque, manifiesto y pantalla completa.
- `docs/REFERENCIAS.md`: instrucciones sobre las imágenes de referencia.
- `docs/CAPTURAS.md`: pasos para registrar los resultados del emulador.
- `THIRD_PARTY_NOTICES/`: licencias de las fuentes.
- `.gitignore`: excluye archivos generados y configuraciones personales.

## Diferencia con Kotlin

| Proyecto Android con Kotlin | Este proyecto .NET MAUI |
|---|---|
| Código `.kt` | Código `.cs` |
| Layout XML o Compose | Interfaz XAML |
| Gradle / `build.gradle.kts` | MSBuild / `.csproj` |
| `res/values`, `values-en`, `layout-land` | `.resx` de idioma y diccionarios XAML seleccionados al cambiar tamaño |
| Android Studio como IDE | Visual Studio o VS Code con extensión .NET MAUI |

En MAUI no se crean carpetas `layout-land` para el XAML. La app detecta si el ancho
supera al alto y selecciona un diccionario. Los `.resx` se resuelven por idioma.

## Requisitos

1. SDK de .NET 10 y workload `maui-android`.
2. Visual Studio con soporte para .NET 10 y MAUI, o VS Code con extensión .NET MAUI.
3. Android SDK con API 36, herramientas de compilación y JDK 21 compatibles con el workload.
4. Un emulador Android o un teléfono con depuración USB habilitada.

Android Studio puede administrar el SDK y el emulador. Para editar y depurar el C#
y XAML de MAUI, usa Visual Studio o VS Code. Si ya tienes otra versión de .NET en
tu proyecto anterior, revisa esa versión antes de mezclar archivos.

## Ejecutar desde VS Code

1. Extrae el ZIP completo en una carpeta conocida.
2. Abre la carpeta `Proyecto_01` en VS Code e instala la extensión `.NET MAUI`.
3. En una terminal dentro de esta carpeta, ejecuta:

```bash
dotnet --info
dotnet workload install maui-android
dotnet workload restore EstefanoMaui/EstefanoMaui.csproj
dotnet restore EstefanoMaui/EstefanoMaui.csproj
```

4. Configura la ubicación del Android SDK y del JDK en los comandos `.NET MAUI: Configure Android`
   de VS Code. Si usas el SDK de Android Studio, selecciona esa misma ubicación.
5. Inicia el emulador desde Device Manager de Android Studio o conecta el teléfono.
6. Selecciona el dispositivo con `.NET MAUI: Pick Android Device` y ejecuta con `F5`.

También puedes compilar y ejecutar desde la terminal, con un solo dispositivo conectado:

```bash
dotnet build EstefanoMaui/EstefanoMaui.csproj -f net10.0-android -c Debug
dotnet build EstefanoMaui/EstefanoMaui.csproj -t:Run -f net10.0-android -c Debug
```

Si falta una plataforma o herramienta Android, instálala con el SDK Manager o
sigue las instrucciones oficiales de instalación de MAUI. No guardes rutas
personales del SDK ni contraseñas en el repositorio.

## Verificar los cuatro escenarios

1. En Android, configura español como primer idioma y abre la app: fondo albaricoque.
2. Gira a horizontal con los botones de rotación del emulador: fondo menta.
3. En Ajustes de Android, cambia el primer idioma a English.
4. Cierra por completo la app y vuelve a abrirla: en vertical, fondo azul marino.
5. Gira a horizontal: fondo lavanda.

La ubicación de los ajustes de idioma depende de la versión de Android.
La Activity permite ambas orientaciones. Si aparecen barras del sistema al tocar
el borde, espera a que se oculten antes de tomar la captura.

## Subir a un repositorio existente de GitHub

La carpeta del ZIP se llama `Proyecto_01`. Puedes renombrarla a `Proyecto 01`
para seguir la organización de tu clase. Copia la carpeta completa dentro del
repositorio local, junto a tus otros proyectos. Después, desde la raíz del repositorio:

```bash
git status
git add "Proyecto 01"
git commit -m "Agrega Proyecto 01 en .NET MAUI con idioma y orientación"
git push
```

Si conservas el nombre `Proyecto_01`, cambia el comando a `git add Proyecto_01`.
Usa estos comandos sobre tu propio repositorio ya clonado. No ejecutes `git init`
dentro del proyecto si ya pertenece a otro repositorio.

También puedes abrir tu repositorio en GitHub, elegir **Add file → Upload files**
y arrastrar la carpeta descomprimida. Activa la visualización de archivos ocultos
para incluir `.gitignore` y `.gitattributes` si el navegador no los incorpora.
Para que GitHub muestre el código y sus carpetas, sube el contenido extraído del ZIP.

## Referencias visuales y validación

El código implementa las combinaciones de texto, colores y estilos de las imágenes
creadas previamente. Las tipografías incluidas son alternativas redistribuibles:
la rasterización y algunas formas de las letras variarán respecto de esas imágenes.
Las imágenes anteriores fueron generadas como referencia, no capturas de una app ejecutada.
No se incluyen como evidencia de funcionamiento. Usa `docs/CAPTURAS.md` para obtener
las capturas reales y agregarlas al repositorio.

Se revisaron la sintaxis XML/XAML, las claves de idioma, las fuentes y la estructura
del paquete. No se pudo compilar ni ejecutar en el entorno de preparación porque
no dispone del SDK .NET ni del emulador Android. Antes de entregar, ejecuta la app
y comprueba los cuatro casos en tu equipo.

## Documentación oficial

- [Instalación de .NET MAUI](https://learn.microsoft.com/dotnet/maui/get-started/installation?view=net-maui-10.0)
- [Localización con archivos .resx](https://learn.microsoft.com/dotnet/maui/fundamentals/localization?view=net-maui-10.0)
- [Fuentes en .NET MAUI](https://learn.microsoft.com/dotnet/maui/user-interface/fonts?view=net-maui-10.0)
