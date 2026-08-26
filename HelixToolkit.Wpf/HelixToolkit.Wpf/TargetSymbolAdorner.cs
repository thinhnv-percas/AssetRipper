using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class TargetSymbolAdorner : Adorner
{
	public Point Position { get; set; }

	public TargetSymbolAdorner(UIElement adornedElement, Point position)
		: base(adornedElement)
	{
		Position = position;
	}

	protected override void OnRender(DrawingContext dc)
	{
		SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.LightGray);
		SolidColorBrush solidColorBrush2 = new SolidColorBrush(Colors.Black);
		solidColorBrush.Opacity = 0.4;
		solidColorBrush2.Opacity = 0.1;
		double num = 6.0;
		double num2 = 2.0;
		double num3 = 0.0;
		double num4 = 10.0;
		double num5 = 20.0;
		double num6 = num5 - (num + num2) / 2.0;
		double num7 = num5 + num4;
		double num8 = num5 + num2 / 2.0 + num3;
		double num9 = (num5 + num7) / 2.0;
		Pen pen = new Pen(solidColorBrush2, num);
		Pen pen2 = new Pen(solidColorBrush, num2);
		dc.DrawEllipse(null, pen2, Position, num5, num5);
		dc.DrawEllipse(null, pen, Position, num6, num6);
		dc.DrawArc(null, pen2, Position, 10.0, 80.0, num9, num9);
		dc.DrawArc(null, pen2, Position, 100.0, 170.0, num9, num9);
		dc.DrawArc(null, pen2, Position, 190.0, 260.0, num9, num9);
		dc.DrawArc(null, pen2, Position, 280.0, 350.0, num9, num9);
		dc.DrawLine(pen2, new Point(Position.X, Position.Y - num7), new Point(Position.X, Position.Y - num8));
		dc.DrawLine(pen2, new Point(Position.X, Position.Y + num7), new Point(Position.X, Position.Y + num8));
		dc.DrawLine(pen2, new Point(Position.X - num7, Position.Y), new Point(Position.X - num8, Position.Y));
		dc.DrawLine(pen2, new Point(Position.X + num7, Position.Y), new Point(Position.X + num8, Position.Y));
	}
}
