using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace HelixToolkit.Wpf;

public class RangeColorAxis : ColorAxis
{
	public static readonly DependencyProperty FormatProviderProperty = DependencyProperty.Register("FormatProvider", typeof(IFormatProvider), typeof(RangeColorAxis), new UIPropertyMetadata(null));

	public static readonly DependencyProperty FormatStringProperty = DependencyProperty.Register("FormatString", typeof(string), typeof(RangeColorAxis), new UIPropertyMetadata(null));

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(RangeColorAxis), new UIPropertyMetadata(100.0));

	public static readonly DependencyProperty MaximumTextureCoordinateProperty = DependencyProperty.Register("MaximumTextureCoordinate", typeof(double), typeof(RangeColorAxis), new UIPropertyMetadata(1.0));

	public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(RangeColorAxis), new UIPropertyMetadata(0.0));

	public static readonly DependencyProperty MinimumTextureCoordinateProperty = DependencyProperty.Register("MinimumTextureCoordinate", typeof(double), typeof(RangeColorAxis), new UIPropertyMetadata(0.0));

	public static readonly DependencyProperty StepProperty = DependencyProperty.Register("Step", typeof(double), typeof(RangeColorAxis), new UIPropertyMetadata(10.0));

	public IFormatProvider FormatProvider
	{
		get
		{
			return (IFormatProvider)GetValue(FormatProviderProperty);
		}
		set
		{
			SetValue(FormatProviderProperty, value);
		}
	}

	public string FormatString
	{
		get
		{
			return (string)GetValue(FormatStringProperty);
		}
		set
		{
			SetValue(FormatStringProperty, value);
		}
	}

	public double Maximum
	{
		get
		{
			return (double)GetValue(MaximumProperty);
		}
		set
		{
			SetValue(MaximumProperty, value);
		}
	}

	public double MaximumTextureCoordinate
	{
		get
		{
			return (double)GetValue(MaximumTextureCoordinateProperty);
		}
		set
		{
			SetValue(MaximumTextureCoordinateProperty, value);
		}
	}

	public double Minimum
	{
		get
		{
			return (double)GetValue(MinimumProperty);
		}
		set
		{
			SetValue(MinimumProperty, value);
		}
	}

	public double MinimumTextureCoordinate
	{
		get
		{
			return (double)GetValue(MinimumTextureCoordinateProperty);
		}
		set
		{
			SetValue(MinimumTextureCoordinateProperty, value);
		}
	}

	public double Step
	{
		get
		{
			return (double)GetValue(StepProperty);
		}
		set
		{
			SetValue(StepProperty, value);
		}
	}

	protected override void AddVisuals()
	{
		if (Maximum <= Minimum || Step <= 0.0 || base.ColorScheme == null)
		{
			return;
		}
		base.AddVisuals();
		double miny = base.ColorArea.Bottom - MinimumTextureCoordinate * base.ColorArea.Height;
		double maxy = base.ColorArea.Bottom - MaximumTextureCoordinate * base.ColorArea.Height;
		Func<double, double> func = (double v) => miny + (v - Minimum) / (Maximum - Minimum) * (maxy - miny);
		double num = double.MinValue;
		double num2 = func(Maximum);
		foreach (double tickValue in GetTickValues())
		{
			string text = tickValue.ToString(FormatString, FormatProvider);
			TextBlock textBlock = new TextBlock(new Run(text))
			{
				Foreground = base.Foreground
			};
			textBlock.Measure(new Size(base.ActualWidth, base.ActualHeight));
			double num3 = func(tickValue);
			ColorAxisPosition position = base.Position;
			Point point;
			Point point2;
			Point point3;
			if (position == ColorAxisPosition.Right)
			{
				point = new Point(base.ColorArea.Right, num3);
				point2 = new Point(base.ColorArea.Left - base.TickLength, num3);
				point3 = new Point(base.ColorArea.Left - base.TickLength - base.TextMargin - textBlock.DesiredSize.Width, num3 - textBlock.DesiredSize.Height / 2.0);
			}
			else
			{
				point = new Point(base.ColorArea.Left, num3);
				point2 = new Point(base.ColorArea.Right + base.TickLength, num3);
				point3 = new Point(base.ColorArea.Right + base.TickLength + base.TextMargin, num3 - textBlock.DesiredSize.Height / 2.0);
			}
			Line element = new Line
			{
				X1 = point.X,
				X2 = point2.X,
				Y1 = point.Y,
				Y2 = point2.Y,
				Stroke = base.Foreground,
				StrokeThickness = 1.0,
				SnapsToDevicePixels = true
			};
			base.Canvas.Children.Add(element);
			double num4 = textBlock.DesiredSize.Height * 0.7;
			if ((!(tickValue < Maximum) || !(Math.Abs(num3 - num2) < num4)) && !(Math.Abs(num3 - num) < num4))
			{
				Canvas.SetLeft(textBlock, point3.X);
				Canvas.SetTop(textBlock, point3.Y);
				base.Canvas.Children.Add(textBlock);
				num = num3;
			}
		}
	}

	protected override IEnumerable<string> GetTickLabels()
	{
		return from v in GetTickValues()
			select v.ToString(FormatString, FormatProvider);
	}

	private IEnumerable<double> GetTickValues()
	{
		yield return Minimum;
		for (double x = Math.Floor(Minimum / Step) * Step; x < Maximum; x += Step)
		{
			if (x > Minimum)
			{
				yield return x;
			}
		}
		yield return Maximum;
	}
}
