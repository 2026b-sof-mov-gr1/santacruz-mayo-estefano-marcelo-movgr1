using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;
using System.Globalization;

namespace EstefanoMaui;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, Exported = true,
    ScreenOrientation = ScreenOrientation.FullSensor,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation |
        ConfigChanges.UiMode | ConfigChanges.ScreenLayout |
        ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        // Leer el idioma de Android antes de crear la página de MAUI.
        var locale = Java.Util.Locale.Default;
        if (locale is not null)
        {
            try
            {
                var culture = CultureInfo.GetCultureInfo(locale.ToLanguageTag());
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
            catch (CultureNotFoundException)
            {
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("es");
            }
        }
        base.OnCreate(savedInstanceState);
        HideSystemBars();
    }

    public override void OnWindowFocusChanged(bool hasFocus)
    {
        base.OnWindowFocusChanged(hasFocus);
        if (hasFocus)
            HideSystemBars();
    }

    private void HideSystemBars()
    {
        if (Window is null)
            return;
        WindowCompat.SetDecorFitsSystemWindows(Window, false);
        var controller = WindowCompat.GetInsetsController(Window, Window.DecorView);
        controller.Hide(WindowInsetsCompat.Type.SystemBars());
        controller.SystemBarsBehavior = WindowInsetsControllerCompat.BehaviorShowTransientBarsBySwipe;
    }
}
