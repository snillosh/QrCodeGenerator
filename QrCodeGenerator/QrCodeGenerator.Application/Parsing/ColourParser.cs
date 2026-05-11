

using Avalonia.Media;

namespace QrCodeGenerator.Application.Parsing;

public static class ColourParser
{
    public static string? WarnIfContrastMayBePoor(
        string darkColorInput,
        string lightColorInput)
    {

        if (!Color.TryParse(darkColorInput, out var dark) || !Color.TryParse(lightColorInput, out var light))
            return "Invalid color format.";

        double darkLum = RelativeLuminance(dark);
        double lightLum = RelativeLuminance(light);

        double brighter = Math.Max(darkLum, lightLum);
        double darker = Math.Min(darkLum, lightLum);
        double contrast = (brighter + 0.05) / (darker + 0.05);

        if (contrast < 3.0)
        {
            return "Contrast is low. Some phones may struggle to scan the QR code.\nDark-on-light combinations usually work best.";
        }
        
        return null;
    }
    
    public static double RelativeLuminance(Color c)
    {
        static double Channel(double v)
        {
            v /= 255.0;
            return v <= 0.03928 ? v / 12.92 : Math.Pow((v + 0.055) / 1.055, 2.4);
        }

        double r = Channel(c.R);
        double g = Channel(c.G);
        double b = Channel(c.B);

        return 0.2126 * r + 0.7152 * g + 0.0722 * b;
    }

    public static byte[] ToRgba(
        this string hexColour)
    {
        var colour = Color.Parse(hexColour);

        return 
        [
            colour.R,
            colour.G,
            colour.B,
            colour.A
        ];
    }
}
