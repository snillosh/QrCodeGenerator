using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace QrCodeGenerator.Application.FileSystem;

public static class PathGenerator
{
    public async static Task<IStorageFile?> GetSavePath(TopLevel topLevel)
    {
        var file = await topLevel.StorageProvider.SaveFilePickerAsync(
        new FilePickerSaveOptions
        {
            Title = "Save QR Code",
            SuggestedFileName = "qrcode.png",
            FileTypeChoices =
            [
                new FilePickerFileType("PNG image")
                {
                    Patterns = ["*.png"],
                    MimeTypes = ["image/png"]
                }
            ]
        });

        return file ?? null;

    }
}
