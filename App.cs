namespace Mauizzle;

public partial class App : Application
{
    public App()
    {
        Resources.Add("Accent", Color.FromArgb("#FF4081"));
        Resources.Add(new Style(typeof(Frame))
        {
            Setters = { new() { Property = Frame.BorderColorProperty, Value = Resources["Accent"] } }
        });

        MainPage = new MauizzlePage();
    }
}
