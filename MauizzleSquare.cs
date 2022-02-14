namespace Mauizzle;

public class MauizzleSquare : ContentView
{
    private readonly Label label;
    private readonly string normText;
    private readonly string winText;

    public MauizzleSquare(char normChar, char winChar, int index)
    {
        this.Index = index;
        this.normText = normChar.ToString();
        this.winText = winChar.ToString();

        if (normChar != default && winChar != default)
        {
            // A Frame surrounding two Labels.
            label = new Label
            {
                Text = this.normText,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Label tinyLabel = new()
            {
                Text = (index + 1).ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.End
            };

            this.Padding = new Thickness(3);

            this.Content = new Frame
            {
                Padding = new Thickness(5, 10, 5, 0),
                Content = new StackLayout
                {
                    Spacing = 0,
                    Children = {
                        label,
                        tinyLabel,
                    }
                }
            };
        }

        // Don't let touch pass us by.
        this.BackgroundColor = Colors.Transparent;
    }

    // Retain current Row and Col position.
    public int Index { private set; get; }

    public int Row { set; get; }

    public int Col { set; get; }

    public async Task AnimateWinAsync(bool isReverse)
    {
        uint length = 150;
        await Task.WhenAll(this.ScaleTo(3, length), this.RotateTo(180, length));
        
        label.Text = isReverse ? normText : winText;
        
        await Task.WhenAll(this.ScaleTo(1, length), this.RotateTo(360, length));
        this.Rotation = 0;
    }

    public void SetLabelFont(double fontSize, FontAttributes attributes)
    {
        label.FontSize = fontSize;
        label.FontAttributes = attributes;
    }
}