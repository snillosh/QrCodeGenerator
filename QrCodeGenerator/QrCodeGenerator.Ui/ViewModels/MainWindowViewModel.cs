using Avalonia.Media;

namespace QrCodeGenerator.Ui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    private Color _lightColour = Colors.Black;

    public Color LightColour
    {
        get => _lightColour;
        set
        {
            _lightColour = value;
        }
    }
    
    private Color _darkColour = Colors.Black;

    public Color DarkColour
    {
        get => _darkColour;
        set
        {
            _darkColour = value;
        }
    }
}
