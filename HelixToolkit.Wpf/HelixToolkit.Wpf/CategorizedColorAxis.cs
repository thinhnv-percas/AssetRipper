using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace HelixToolkit.Wpf;

public class CategorizedColorAxis : ColorAxis
{
	public static readonly DependencyProperty CategoriesProperty = DependencyProperty.Register("Categories", typeof(IList<string>), typeof(CategorizedColorAxis), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, ColorAxis.PropertyChanged));

	public IList<string> Categories
	{
		get
		{
			return (IList<string>)GetValue(CategoriesProperty);
		}
		set
		{
			SetValue(CategoriesProperty, value);
		}
	}

	protected override void AddVisuals()
	{
		if (Categories == null || Categories.Count == 0 || base.ColorScheme == null)
		{
			return;
		}
		base.AddVisuals();
		for (int i = 0; i < Categories.Count; i++)
		{
			string text = Categories[i];
			TextBlock textBlock = new TextBlock(new Run(text))
			{
				Foreground = base.Foreground
			};
			textBlock.Measure(new Size(base.ActualWidth, base.ActualHeight));
			double y = base.ColorArea.Top + (double)i / (double)Categories.Count * base.ColorArea.Height;
			double num = base.ColorArea.Top + ((double)i + 0.5) / (double)Categories.Count * base.ColorArea.Height;
			double y2 = base.ColorArea.Top + ((double)i + 1.0) / (double)Categories.Count * base.ColorArea.Height;
			ColorAxisPosition position = base.Position;
			Point point;
			Point point2;
			Point point3;
			Point point4;
			Point point5;
			if (position == ColorAxisPosition.Right)
			{
				point = new Point(base.ColorArea.Right, y);
				point2 = new Point(base.ColorArea.Left - base.TickLength, y);
				point3 = new Point(base.ColorArea.Left - base.TickLength - base.TextMargin - textBlock.DesiredSize.Width, num - textBlock.DesiredSize.Height / 2.0);
				point4 = new Point(base.ColorArea.Right, y2);
				point5 = new Point(base.ColorArea.Left - base.TickLength, y2);
			}
			else
			{
				point = new Point(base.ColorArea.Left, y);
				point2 = new Point(base.ColorArea.Right + base.TickLength, y);
				point3 = new Point(base.ColorArea.Right + base.TickLength + base.TextMargin, num - textBlock.DesiredSize.Height / 2.0);
				point4 = new Point(base.ColorArea.Left, y2);
				point5 = new Point(base.ColorArea.Right + base.TickLength, y2);
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
			if (i == Categories.Count - 1)
			{
				Line element2 = new Line
				{
					X1 = point4.X,
					X2 = point5.X,
					Y1 = point4.Y,
					Y2 = point5.Y,
					Stroke = base.BorderBrush,
					StrokeThickness = 1.0,
					SnapsToDevicePixels = true
				};
				base.Canvas.Children.Add(element2);
			}
			Canvas.SetLeft(textBlock, point3.X);
			Canvas.SetTop(textBlock, point3.Y);
			base.Canvas.Children.Add(textBlock);
		}
	}

	protected override IEnumerable<string> GetTickLabels()
	{
		if (Categories == null)
		{
			return new string[1] { string.Empty };
		}
		return Categories;
	}
}
