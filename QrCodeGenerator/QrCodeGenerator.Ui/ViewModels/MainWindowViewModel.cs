using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrCodeGenerator.Application.FileSystem;
using QrCodeGenerator.Application.Parsing;

namespace QrCodeGenerator.Ui.ViewModels;

public partial class MainWindowViewModel : ObservableValidator
{
    private readonly Application.QrCode.QrCodeGenerator _qrCodeGenerator = new();

    [ObservableProperty]
    [Required]
    [Url]
    private string url = "";
    
    partial void OnUrlChanged(string value)
    {
        ValidateProperty(value, nameof(Url));
        OnPropertyChanged(nameof(UrlError));
    }
    
    public string? UrlError =>
        GetErrors(nameof(Url))
            .Cast<ValidationResult>()
            .FirstOrDefault()
            ?.ErrorMessage;
    
    [ObservableProperty]
    private Color lightColour = Colors.White;

    
    [ObservableProperty]
    private Color darkColour = Colors.Navy;
    
    [ObservableProperty]
    private string? contrastWarning;
    
    partial void OnContrastWarningChanged(string? value)
    {
        OnPropertyChanged(nameof(HasContrastWarning));
    }
    
    public bool HasContrastWarning =>
        !string.IsNullOrWhiteSpace(ContrastWarning);
    
    private void UpdateContrastWarning()
    {
        ContrastWarning =
            ColourHelper.WarnIfContrastMayBePoor(
            DarkColour,
            LightColour);
    }
    
    partial void OnLightColourChanged(Color value)
    {
        UpdateContrastWarning();
    }

    partial void OnDarkColourChanged(Color value)
    {
        UpdateContrastWarning();
    }
    
    [RelayCommand]
    private async Task Generate(TopLevel topLevel)
    {
        var path = await PathGenerator.GetSavePath(topLevel);

        if (path != null)
            await _qrCodeGenerator.GenerateQrCode(Url, DarkColour, LightColour, path.Path.AbsolutePath);
    }
}
