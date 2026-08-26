using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace HelixToolkit.Wpf;

public class RectangleAdorner : Adorner
{
	private readonly double crossHairSize;

	private readonly Pen pen;

	private readonly Pen pen2;

	public Rect Rectangle { get; set; }

	public RectangleAdorner(UIElement adornedElement, Rect rectangle, Color color1, Color color2, double thickness1 = 1.0, double thickness2 = 1.0, double crossHairSize = 10.0)
		: this(adornedElement, rectangle, color1, color2, thickness1, thickness2, crossHairSize, DashStyles.Dash)
	{
	}

	public RectangleAdorner(UIElement adornedElement, Rect rectangle, Color color1, Color color2, double thickness1, double thickness2, double crossHairSize, DashStyle dashStyle2)
		: base(adornedElement)
	{
		if (adornedElement == null)
		{
			throw new ArgumentNullException("adornedElement");
		}
		Rectangle = rectangle;
		PresentationSource presentationSource = PresentationSource.FromVisual(adornedElement);
		if (presentationSource != null)
		{
			CompositionTarget compositionTarget = presentationSource.CompositionTarget;
			if (compositionTarget != null)
			{
				double num = 1.0 / compositionTarget.TransformToDevice.M11;
				pen = new Pen(new SolidColorBrush(color1), thickness1 * num);
				pen2 = new Pen(new SolidColorBrush(color2), thickness2 * num);
				pen2.DashStyle = dashStyle2;
				this.crossHairSize = crossHairSize;
			}
		}
	}

	protected override void OnRender(DrawingContext dc)
	{
		double num = pen.Thickness / 2.0;
		double num2 = (Rectangle.Left + Rectangle.Right) / 2.0;
		double num3 = (Rectangle.Top + Rectangle.Bottom) / 2.0;
		num2 = (double)(int)num2 + num;
		num3 = (double)(int)num3 + num;
		Rect rectangle = new Rect((double)(int)Rectangle.Left + num, (double)(int)Rectangle.Top + num, (int)Rectangle.Width, (int)Rectangle.Height);
		dc.DrawRectangle(null, pen, rectangle);
		dc.DrawRectangle(null, pen2, rectangle);
		if (crossHairSize > 0.0)
		{
			dc.DrawLine(pen, new Point(num2, num3 - crossHairSize), new Point(num2, num3 + crossHairSize));
			dc.DrawLine(pen, new Point(num2 - crossHairSize, num3), new Point(num2 + crossHairSize, num3));
			dc.DrawLine(pen2, new Point(num2, num3 - crossHairSize), new Point(num2, num3 + crossHairSize));
			dc.DrawLine(pen2, new Point(num2 - crossHairSize, num3), new Point(num2 + crossHairSize, num3));
		}
	}
}
