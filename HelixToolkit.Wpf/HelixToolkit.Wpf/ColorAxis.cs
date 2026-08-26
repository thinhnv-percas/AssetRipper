using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HelixToolkit.Wpf;

[TemplatePart(Name = "PART_Canvas", Type = typeof(Canvas))]
public abstract class ColorAxis : Control
{
	public static readonly DependencyProperty BarWidthProperty;

	public static readonly DependencyProperty ColorSchemeProperty;

	public static readonly DependencyProperty FlipColorSchemeProperty;

	public static readonly DependencyProperty PositionProperty;

	public static readonly DependencyProperty TextMarginProperty;

	public static readonly DependencyProperty TickLengthProperty;

	public double BarWidth
	{
		get
		{
			return (double)GetValue(BarWidthProperty);
		}
		set
		{
			SetValue(BarWidthProperty, value);
		}
	}

	public Brush ColorScheme
	{
		get
		{
			return (Brush)GetValue(ColorSchemeProperty);
		}
		set
		{
			SetValue(ColorSchemeProperty, value);
		}
	}

	public bool FlipColorScheme
	{
		get
		{
			return (bool)GetValue(FlipColorSchemeProperty);
		}
		set
		{
			SetValue(FlipColorSchemeProperty, value);
		}
	}

	public ColorAxisPosition Position
	{
		get
		{
			return (ColorAxisPosition)GetValue(PositionProperty);
		}
		set
		{
			SetValue(PositionProperty, value);
		}
	}

	public double TextMargin
	{
		get
		{
			return (double)GetValue(TextMarginProperty);
		}
		set
		{
			SetValue(TextMarginProperty, value);
		}
	}

	public double TickLength
	{
		get
		{
			return (double)GetValue(TickLengthProperty);
		}
		set
		{
			SetValue(TickLengthProperty, value);
		}
	}

	protected Canvas Canvas { get; private set; }

	protected Rect ColorArea { get; private set; }

	static ColorAxis()
	{
		BarWidthProperty = DependencyProperty.Register("BarWidth", typeof(double), typeof(ColorAxis), new UIPropertyMetadata(20.0));
		ColorSchemeProperty = DependencyProperty.Register("ColorScheme", typeof(Brush), typeof(ColorAxis), new UIPropertyMetadata(null, PropertyChanged));
		FlipColorSchemeProperty = DependencyProperty.Register("FlipColorScheme", typeof(bool), typeof(ColorAxis), new UIPropertyMetadata(false, PropertyChanged));
		PositionProperty = DependencyProperty.Register("Position", typeof(ColorAxisPosition), typeof(ColorAxis), new UIPropertyMetadata(ColorAxisPosition.Left));
		TextMarginProperty = DependencyProperty.Register("TextMargin", typeof(double), typeof(ColorAxis), new UIPropertyMetadata(2.0));
		TickLengthProperty = DependencyProperty.Register("TickLength", typeof(double), typeof(ColorAxis), new UIPropertyMetadata(3.0));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorAxis), new FrameworkPropertyMetadata(typeof(ColorAxis)));
	}

	protected ColorAxis()
	{
		base.SizeChanged += delegate
		{
			UpdateVisuals();
		};
		base.Loaded += delegate
		{
			UpdateVisuals();
		};
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		Canvas = (Canvas)GetTemplateChild("PART_Canvas");
	}

	protected static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ColorAxis)d).UpdateVisuals();
	}

	protected virtual void AddVisuals()
	{
		switch (Position)
		{
		case ColorAxisPosition.Left:
			ColorArea = new Rect(base.Padding.Left, base.Padding.Top, BarWidth, base.ActualHeight - base.Padding.Bottom - base.Padding.Top);
			break;
		case ColorAxisPosition.Right:
			ColorArea = new Rect(base.ActualWidth - base.Padding.Right - BarWidth, base.Padding.Top, BarWidth, base.ActualHeight - base.Padding.Bottom - base.Padding.Top);
			break;
		}
		Rectangle rectangle = new Rectangle
		{
			Fill = ColorScheme,
			Width = ColorArea.Width,
			Height = ColorArea.Height
		};
		if (FlipColorScheme)
		{
			rectangle.LayoutTransform = new RotateTransform(180.0);
		}
		Canvas.SetLeft(rectangle, ColorArea.Left);
		Canvas.SetTop(rectangle, ColorArea.Top);
		Canvas.Children.Add(rectangle);
		Canvas.Children.Add(new Line
		{
			Stroke = base.Foreground,
			StrokeThickness = 1.0,
			SnapsToDevicePixels = true,
			X1 = ColorArea.Left,
			Y1 = ColorArea.Top,
			X2 = ColorArea.Left,
			Y2 = ColorArea.Bottom
		});
		Canvas.Children.Add(new Line
		{
			Stroke = base.Foreground,
			StrokeThickness = 1.0,
			SnapsToDevicePixels = true,
			X1 = ColorArea.Right,
			Y1 = ColorArea.Top,
			X2 = ColorArea.Right,
			Y2 = ColorArea.Bottom
		});
	}

	protected abstract IEnumerable<string> GetTickLabels();

	protected override Size MeasureOverride(Size constraint)
	{
		Size result = base.MeasureOverride(constraint);
		double num = GetTickLabels().Max(delegate(string c)
		{
			TextBlock textBlock = new TextBlock(new Run(c));
			textBlock.Measure(constraint);
			return textBlock.DesiredSize.Width;
		});
		result.Width = num + BarWidth + TickLength + base.Padding.Left + base.Padding.Right + TextMargin;
		return result;
	}

	protected void UpdateVisuals()
	{
		if (Canvas != null)
		{
			Canvas.Children.Clear();
			AddVisuals();
		}
	}
}
