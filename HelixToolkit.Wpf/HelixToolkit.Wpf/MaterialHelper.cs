using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class MaterialHelper
{
	public static void ChangeOpacity(Material material, double opacity)
	{
		if (material is MaterialGroup materialGroup)
		{
			foreach (Material child in materialGroup.Children)
			{
				ChangeOpacity(child, opacity);
			}
		}
		if (material is DiffuseMaterial { Brush: not null } diffuseMaterial)
		{
			diffuseMaterial.Brush.Opacity = opacity;
		}
	}

	public static Material CreateImageMaterial(string uri, double opacity = 1.0, UriKind uriKind = UriKind.RelativeOrAbsolute, bool freeze = true)
	{
		BitmapImage image = GetImage(uri, uriKind);
		if (image == null)
		{
			return null;
		}
		return CreateImageMaterial(image, opacity, freeze);
	}

	public static Material CreateImageMaterial(BitmapImage image, double opacity, bool freeze = true)
	{
		ImageBrush brush = new ImageBrush(image)
		{
			Opacity = opacity
		};
		DiffuseMaterial diffuseMaterial = new DiffuseMaterial(brush);
		if (freeze)
		{
			diffuseMaterial.Freeze();
		}
		return diffuseMaterial;
	}

	public static Material CreateEmissiveImageMaterial(string uri, Brush diffuseBrush, UriKind uriKind, bool freeze = true)
	{
		BitmapImage image = GetImage(uri, uriKind);
		if (image == null)
		{
			return null;
		}
		return CreateEmissiveImageMaterial(image, diffuseBrush, freeze);
	}

	public static Material CreateEmissiveImageMaterial(BitmapImage image, Brush diffuseBrush, bool freeze = true)
	{
		ImageBrush brush = new ImageBrush(image);
		EmissiveMaterial value = new EmissiveMaterial(brush);
		DiffuseMaterial value2 = new DiffuseMaterial(diffuseBrush);
		MaterialGroup materialGroup = new MaterialGroup();
		materialGroup.Children.Add(value2);
		materialGroup.Children.Add(value);
		if (freeze)
		{
			materialGroup.Freeze();
		}
		return materialGroup;
	}

	public static Material CreateMaterial(Color color)
	{
		return CreateMaterial(new SolidColorBrush(color));
	}

	public static Material CreateMaterial(Color color, double opacity)
	{
		return CreateMaterial(Color.FromArgb((byte)(opacity * 255.0), color.R, color.G, color.B));
	}

	public static Material CreateMaterial(Brush brush, double specularPower = 100.0, byte ambient = byte.MaxValue, bool freeze = true)
	{
		return CreateMaterial(brush, 1.0, specularPower, ambient, freeze);
	}

	public static Material CreateMaterial(Brush brush, double specularBrightness, double specularPower = 100.0, byte ambient = byte.MaxValue, bool freeze = true)
	{
		MaterialGroup materialGroup = new MaterialGroup();
		materialGroup.Children.Add(new DiffuseMaterial(brush)
		{
			AmbientColor = Color.FromRgb(ambient, ambient, ambient)
		});
		if (specularPower > 0.0)
		{
			byte b = (byte)(255.0 * specularBrightness);
			materialGroup.Children.Add(new SpecularMaterial(new SolidColorBrush(Color.FromRgb(b, b, b)), specularPower));
		}
		if (freeze)
		{
			materialGroup.Freeze();
		}
		return materialGroup;
	}

	public static Material CreateMaterial(Brush diffuse, Brush emissive, Brush specular = null, double opacity = 1.0, double specularPower = 85.0, bool freeze = true)
	{
		MaterialGroup materialGroup = new MaterialGroup();
		if (diffuse != null)
		{
			diffuse = diffuse.Clone();
			diffuse.Opacity = opacity;
			materialGroup.Children.Add(new DiffuseMaterial(diffuse));
		}
		if (emissive != null)
		{
			emissive = emissive.Clone();
			emissive.Opacity = opacity;
			materialGroup.Children.Add(new EmissiveMaterial(emissive));
		}
		if (specular != null)
		{
			specular = specular.Clone();
			specular.Opacity = opacity;
			materialGroup.Children.Add(new SpecularMaterial(specular, specularPower));
		}
		if (freeze)
		{
			materialGroup.Freeze();
		}
		return materialGroup;
	}

	public static T GetFirst<T>(Material material) where T : Material
	{
		if (material.GetType() == typeof(T))
		{
			return (T)material;
		}
		if (material is MaterialGroup materialGroup)
		{
			return materialGroup.Children.Select(GetFirst<T>).FirstOrDefault((T m) => m != null);
		}
		return null;
	}

	private static BitmapImage GetImage(string uri, UriKind uriKind = UriKind.RelativeOrAbsolute)
	{
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.UriSource = new Uri(uri, uriKind);
		bitmapImage.EndInit();
		return bitmapImage;
	}
}
