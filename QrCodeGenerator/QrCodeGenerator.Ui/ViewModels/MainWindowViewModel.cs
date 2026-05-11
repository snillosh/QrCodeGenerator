using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using QrCodeGenerator.Application.FileSystem;

namespace QrCodeGenerator.Ui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly Application.QrCode.QrCodeGenerator _qrCodeGenerator = new();
    
    public string Url {get; set;}
    
    public Color LightColour { get; set; } = Colors.White;

    public Color DarkColour { get; set; } = Colors.White;
    
    [RelayCommand]
    private async Task Generate(TopLevel topLevel)
    {
        var path = await PathGenerator.GetSavePath(topLevel);

        if (path != null)
            await _qrCodeGenerator.GenerateQrCode(Url, DarkColour, LightColour, path.Path.AbsolutePath);
    }
}
