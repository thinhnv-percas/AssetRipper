using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace HelixToolkit.Wpf;

public class InterlacedEffect : ShaderEffect
{
	public static readonly DependencyProperty LeftInputProperty;

	public static readonly DependencyProperty EvenLeftProperty;

	public static readonly DependencyProperty RightInputProperty;

	private const string EffectFile = "ShaderEffects/InterlacedEffect.ps";

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

	public bool EvenLeft
	{
		get
		{
			return (bool)GetValue(EvenLeftProperty);
		}
		set
		{
			SetValue(EvenLeftProperty, value);
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

	static InterlacedEffect()
	{
		LeftInputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("LeftInput", typeof(InterlacedEffect), 0);
		EvenLeftProperty = DependencyProperty.Register("EvenLeft", typeof(bool), typeof(InterlacedEffect), new UIPropertyMetadata(true, EvenLeftChanged));
		RightInputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("RightInput", typeof(InterlacedEffect), 1);
		OffsetProperty = DependencyProperty.Register("Offset", typeof(float), typeof(InterlacedEffect), new UIPropertyMetadata(0f, ShaderEffect.PixelShaderConstantCallback(1)));
		Shader = new PixelShader();
		ShaderMethodProperty = DependencyProperty.Register("ShaderMethod", typeof(float), typeof(InterlacedEffect), new UIPropertyMetadata(1f, ShaderEffect.PixelShaderConstantCallback(0)));
		Assembly assembly = typeof(InterlacedEffect).Assembly;
		string text = assembly.ToString().Split(',')[0];
		string uriString = "pack://application:,,,/" + text + ";component/ShaderEffects/InterlacedEffect.ps";
		Shader.UriSource = new Uri(uriString);
	}

	public InterlacedEffect()
	{
		base.PixelShader = Shader;
		UpdateShaderValue(EvenLeftProperty);
		UpdateShaderValue(LeftInputProperty);
		UpdateShaderValue(RightInputProperty);
	}

	private static void EvenLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		InterlacedEffect interlacedEffect = (InterlacedEffect)d;
		interlacedEffect.ShaderMethod = ((!interlacedEffect.EvenLeft) ? 1 : 0);
	}
}
