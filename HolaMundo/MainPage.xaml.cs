using System.Globalization;
using EstefanoMaui.Resources.Strings;
using EstefanoMaui.Resources.Styles;

namespace EstefanoMaui;

public partial class MainPage : ContentPage
{
    private (bool Landscape, bool English)? activeScenario;

    public MainPage()
    {
        InitializeComponent();
        Resources.MergedDictionaries.Add(new PortraitDefault());
        ScenarioLabel.Text = AppResources.VerticalText;
        SizeChanged += (_, _) => UpdateScenario();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateScenario();
    }

    private void UpdateScenario()
    {
        if (Width <= 0 || Height <= 0)
            return;

        bool landscape = Width > Height;
        bool english = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";
        var scenario = (Landscape: landscape, English: english);

        if (activeScenario != scenario)
        {
            ResourceDictionary theme = scenario switch
            {
                (false, false) => new PortraitDefault(),
                (false, true) => new PortraitEnglish(),
                (true, false) => new LandscapeDefault(),
                (true, true) => new LandscapeEnglish()
            };
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(theme);
            ScenarioLabel.Text = landscape ? AppResources.HorizontalText : AppResources.VerticalText;
            activeScenario = scenario;
        }

        // Los tamaños de referencia se escalan al ancho real del dispositivo.
        double designWidth = landscape ? 1067.0 : 600.0;
        double baseFontSize = Convert.ToDouble(Resources["DesignFontSize"], CultureInfo.InvariantCulture);
        double fontSize = baseFontSize * Math.Min(Width / designWidth, 1.5);
        if (!Resources.TryGetValue("ScenarioFontSize", out var current) ||
            Math.Abs(Convert.ToDouble(current) - fontSize) > 0.1)
            Resources["ScenarioFontSize"] = fontSize;
    }
}
