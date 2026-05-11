using Avalonia.Media;

namespace QrCodeGenerator.Ui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public Color LightColour { get; set; } = Colors.White;

    public Color DarkColour { get; set; } = Colors.White;
}
