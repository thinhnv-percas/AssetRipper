using System;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HelixToolkit.Wpf;

public class ImageBrushExtension : MarkupExtension
{
	private readonly string uri;

	public UriKind UriKind { get; set; }

	public ImageBrushExtension(string uri)
	{
		this.uri = uri;
		UriKind = UriKind.RelativeOrAbsolute;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.UriSource = new Uri(uri, UriKind);
		bitmapImage.EndInit();
		return new ImageBrush(bitmapImage);
	}
}
