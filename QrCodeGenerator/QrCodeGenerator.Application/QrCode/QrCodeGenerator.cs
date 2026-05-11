using Avalonia.Media;
using QrCodeGenerator.Application.Parsing;
using QRCoder;

namespace QrCodeGenerator.Application.QrCode;

public sealed class QrCodeGenerator
{
    public async Task GenerateQrCode(string url, string darkColorHex, string lightColorHex, string savePath)
    {
        
        using var generator = new QRCodeGenerator();
        using var data = generator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

        var pngQr = new PngByteQRCode(data);

        var pngBytes = pngQr.GetGraphic(
        pixelsPerModule: 10,
        darkColorRgba: darkColorHex.ToRgba(),
        lightColorRgba: lightColorHex.ToRgba()
        );
        
        await File.WriteAllBytesAsync(savePath, pngBytes);
    }
}
