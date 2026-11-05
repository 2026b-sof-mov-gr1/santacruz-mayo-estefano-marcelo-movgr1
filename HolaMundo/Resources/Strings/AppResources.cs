using System.Globalization;
using System.Resources;

namespace EstefanoMaui.Resources.Strings;

// Acceso manual a .resx: no depende de generar Designer.cs desde el IDE.
public static class AppResources
{
    private static readonly ResourceManager Manager = new(
        "EstefanoMaui.Resources.Strings.AppResources", typeof(AppResources).Assembly);

    public static string VerticalText => Get(nameof(VerticalText));
    public static string HorizontalText => Get(nameof(HorizontalText));

    private static string Get(string key) =>
        Manager.GetString(key, CultureInfo.CurrentUICulture)
        ?? throw new MissingManifestResourceException($"No se encontró el recurso {key}.");
}
