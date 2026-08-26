using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace HelixToolkit.Wpf;

public class AnaglyphEffect : ShaderEffect
{
	public static readonly DependencyProperty LeftInputProperty;

	public static readonly DependencyProperty MethodProperty;

	public static readonly DependencyProperty RightInputProperty;

	private const string EffectFile = "ShaderEffects/AnaglyphEffect.ps";

	private static readonly DependencyProperty OffsetProperty;

	private static readonly PixelShader Shader;

	private static readonly DependencyProperty ShaderMethodProperty;

	public Brush LeftInput
	{
		get
		{
			return (Brush)GetValue(LeftInputProperty);
		}
		set
		{
			SetValue(LeftInputProperty, value);
		}
	}

	public AnaglyphMethod Method
	{
		get
		{
			return (AnaglyphMethod)GetValue(MethodProperty);
		}
		set
		{
			SetValue(MethodProperty, value);
		}
	}

	public float Offset
	{
		get
		{
			return (float)GetValue(OffsetProperty);
		}
		set
		{
			SetValue(OffsetProperty, value);
		}
	}

	public Brush RightInput
	{
		get
		{
			return (Brush)GetValue(RightInputProperty);
		}
		set
		{
			SetValue(RightInputProperty, value);
		}
	}

	private float ShaderMethod
	{
		set
		{
			SetValue(ShaderMethodProperty, value);
		}
	}

	static AnaglyphEffect()
	{
		LeftInputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("LeftInput", typeof(AnaglyphEffect), 0);
		MethodProperty = DependencyProperty.Register("Method", typeof(AnaglyphMethod), typeof(AnaglyphEffect), new UIPropertyMetadata(AnaglyphMethod.Gray, AnaglyphMethodChanged));
		RightInputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("RightInput", typeof(AnaglyphEffect), 1);
		OffsetProperty = DependencyProperty.Register("Offset", typeof(float), typeof(AnaglyphEffect), new UIPropertyMetadata(0f, ShaderEffect.PixelShaderConstantCallback(1)));
		Shader = new PixelShader();
		ShaderMethodProperty = DependencyProperty.Register("ShaderMethod", typeof(float), typeof(AnaglyphEffect), new UIPropertyMetadata(1f, ShaderEffect.PixelShaderConstantCallback(0)));
		Assembly assembly = typeof(AnaglyphEffect).Assembly;
		string text = assembly.ToString().Split(',')[0];
		string uriString = "pack://application:,,,/" + text + ";component/ShaderEffects/AnaglyphEffect.ps";
		Shader.UriSource = new Uri(uriString);
	}

	public AnaglyphEffect()
	{
		base.PixelShader = Shader;
		UpdateShaderValue(MethodProperty);
		UpdateShaderValue(LeftInputProperty);
		UpdateShaderValue(RightInputProperty);
	}

	private static void AnaglyphMethodChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		AnaglyphEffect anaglyphEffect = (AnaglyphEffect)d;
		anaglyphEffect.ShaderMethod = (float)anaglyphEffect.Method;
	}
}
