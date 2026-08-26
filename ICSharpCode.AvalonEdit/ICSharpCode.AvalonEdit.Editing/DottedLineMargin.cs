using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ICSharpCode.AvalonEdit.Editing;

public static class DottedLineMargin
{
	private static readonly object tag = new object();

	public static UIElement Create()
	{
		Line line = new Line();
		line.X1 = 0.0;
		line.Y1 = 0.0;
		line.X2 = 0.0;
		line.Y2 = 1.0;
		line.StrokeDashArray.Add(0.0);
		line.StrokeDashArray.Add(2.0);
		line.Stretch = Stretch.Fill;
		line.StrokeThickness = 1.0;
		line.StrokeDashCap = PenLineCap.Round;
		line.Margin = new Thickness(2.0, 0.0, 2.0, 0.0);
		line.Tag = tag;
		return line;
	}

	[Obsolete("This method got published accidentally; and will be removed again in a future version. Use the parameterless overload instead.")]
	public static UIElement Create(TextEditor editor)
	{
		Line line = (Line)Create();
		line.SetBinding(Shape.StrokeProperty, new Binding("LineNumbersForeground")
		{
			Source = editor
		});
		return line;
	}

	public static bool IsDottedLineMargin(UIElement element)
	{
		if (element is Line line)
		{
			return line.Tag == tag;
		}
		return false;
	}
}
