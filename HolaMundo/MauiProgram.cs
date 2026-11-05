namespace EstefanoMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("DejaVuSerif-Bold.ttf", "ScenarioSerif");
            fonts.AddFont("DejaVuSansMono.ttf", "ScenarioMono");
            fonts.AddFont("lmsans12-oblique.otf", "ScenarioItalic");
            fonts.AddFont("DejaVuSans-Bold.ttf", "ScenarioBold");
        });
        return builder.Build();
    }
}
