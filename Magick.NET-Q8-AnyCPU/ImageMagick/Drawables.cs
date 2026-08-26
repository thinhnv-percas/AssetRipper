using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace ImageMagick;

[GeneratedCode("Magick.NET.FileGenerator", "")]
public sealed class Drawables : IEnumerable<IDrawable>, IEnumerable
{
	private readonly Collection<IDrawable> _drawables;

	public Drawables Affine(Matrix matrix)
	{
		_drawables.Add(new DrawableAffine(matrix));
		return this;
	}

	public Drawables BorderColor(Color color)
	{
		_drawables.Add(new DrawableBorderColor(color));
		return this;
	}

	public Drawables FillColor(Color color)
	{
		_drawables.Add(new DrawableFillColor(color));
		return this;
	}

	public Drawables Rectangle(Rectangle rectangle)
	{
		_drawables.Add(new DrawableRectangle(rectangle));
		return this;
	}

	public Drawables StrokeColor(Color color)
	{
		_drawables.Add(new DrawableStrokeColor(color));
		return this;
	}

	public Drawables TextUnderColor(Color color)
	{
		_drawables.Add(new DrawableTextUnderColor(color));
		return this;
	}

	public Drawables Viewbox(Rectangle rectangle)
	{
		_drawables.Add(new DrawableViewbox(rectangle));
		return this;
	}

	public Drawables()
	{
		_drawables = new Collection<IDrawable>();
	}

	public Drawables Draw(IMagickImage image)
	{
		Throw.IfNull("image", image);
		image.Draw(this);
		return this;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public Paths Paths()
	{
		return new Paths(this);
	}

	public IEnumerator<IDrawable> GetEnumerator()
	{
		return _drawables.GetEnumerator();
	}

	public Drawables Affine(double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY)
	{
		_drawables.Add(new DrawableAffine(scaleX, scaleY, shearX, shearY, translateX, translateY));
		return this;
	}

	public Drawables Alpha(double x, double y, PaintMethod paintMethod)
	{
		_drawables.Add(new DrawableAlpha(x, y, paintMethod));
		return this;
	}

	public Drawables Arc(double startX, double startY, double endX, double endY, double startDegrees, double endDegrees)
	{
		_drawables.Add(new DrawableArc(startX, startY, endX, endY, startDegrees, endDegrees));
		return this;
	}

	public Drawables Bezier(params PointD[] coordinates)
	{
		_drawables.Add(new DrawableBezier(coordinates));
		return this;
	}

	public Drawables Bezier(IEnumerable<PointD> coordinates)
	{
		_drawables.Add(new DrawableBezier(coordinates));
		return this;
	}

	public Drawables BorderColor(MagickColor color)
	{
		_drawables.Add(new DrawableBorderColor(color));
		return this;
	}

	public Drawables Circle(double originX, double originY, double perimeterX, double perimeterY)
	{
		_drawables.Add(new DrawableCircle(originX, originY, perimeterX, perimeterY));
		return this;
	}

	public Drawables ClipPath(string clipPath)
	{
		_drawables.Add(new DrawableClipPath(clipPath));
		return this;
	}

	public Drawables ClipRule(FillRule fillRule)
	{
		_drawables.Add(new DrawableClipRule(fillRule));
		return this;
	}

	public Drawables ClipUnits(ClipPathUnit units)
	{
		_drawables.Add(new DrawableClipUnits(units));
		return this;
	}

	public Drawables Color(double x, double y, PaintMethod paintMethod)
	{
		_drawables.Add(new DrawableColor(x, y, paintMethod));
		return this;
	}

	public Drawables Composite(MagickGeometry offset, IMagickImage image)
	{
		_drawables.Add(new DrawableComposite(offset, image));
		return this;
	}

	public Drawables Composite(double x, double y, IMagickImage image)
	{
		_drawables.Add(new DrawableComposite(x, y, image));
		return this;
	}

	public Drawables Composite(MagickGeometry offset, CompositeOperator compose, IMagickImage image)
	{
		_drawables.Add(new DrawableComposite(offset, compose, image));
		return this;
	}

	public Drawables Composite(double x, double y, CompositeOperator compose, IMagickImage image)
	{
		_drawables.Add(new DrawableComposite(x, y, compose, image));
		return this;
	}

	public Drawables Density(double density)
	{
		_drawables.Add(new DrawableDensity(density));
		return this;
	}

	public Drawables Density(PointD pointDensity)
	{
		_drawables.Add(new DrawableDensity(pointDensity));
		return this;
	}

	public Drawables Ellipse(double originX, double originY, double radiusX, double radiusY, double startDegrees, double endDegrees)
	{
		_drawables.Add(new DrawableEllipse(originX, originY, radiusX, radiusY, startDegrees, endDegrees));
		return this;
	}

	public Drawables FillColor(MagickColor color)
	{
		_drawables.Add(new DrawableFillColor(color));
		return this;
	}

	public Drawables FillOpacity(Percentage opacity)
	{
		_drawables.Add(new DrawableFillOpacity(opacity));
		return this;
	}

	public Drawables FillPatternUrl(string url)
	{
		_drawables.Add(new DrawableFillPatternUrl(url));
		return this;
	}

	public Drawables FillRule(FillRule fillRule)
	{
		_drawables.Add(new DrawableFillRule(fillRule));
		return this;
	}

	public Drawables Font(string family)
	{
		_drawables.Add(new DrawableFont(family));
		return this;
	}

	public Drawables Font(string family, FontStyleType style, FontWeight weight, FontStretch stretch)
	{
		_drawables.Add(new DrawableFont(family, style, weight, stretch));
		return this;
	}

	public Drawables FontPointSize(double pointSize)
	{
		_drawables.Add(new DrawableFontPointSize(pointSize));
		return this;
	}

	public Drawables Gravity(Gravity gravity)
	{
		_drawables.Add(new DrawableGravity(gravity));
		return this;
	}

	public Drawables Line(double startX, double startY, double endX, double endY)
	{
		_drawables.Add(new DrawableLine(startX, startY, endX, endY));
		return this;
	}

	public Drawables Path(params IPath[] paths)
	{
		_drawables.Add(new DrawablePath(paths));
		return this;
	}

	public Drawables Path(IEnumerable<IPath> paths)
	{
		_drawables.Add(new DrawablePath(paths));
		return this;
	}

	public Drawables Point(double x, double y)
	{
		_drawables.Add(new DrawablePoint(x, y));
		return this;
	}

	public Drawables Polygon(params PointD[] coordinates)
	{
		_drawables.Add(new DrawablePolygon(coordinates));
		return this;
	}

	public Drawables Polygon(IEnumerable<PointD> coordinates)
	{
		_drawables.Add(new DrawablePolygon(coordinates));
		return this;
	}

	public Drawables Polyline(params PointD[] coordinates)
	{
		_drawables.Add(new DrawablePolyline(coordinates));
		return this;
	}

	public Drawables Polyline(IEnumerable<PointD> coordinates)
	{
		_drawables.Add(new DrawablePolyline(coordinates));
		return this;
	}

	public Drawables PopClipPath()
	{
		_drawables.Add(new DrawablePopClipPath());
		return this;
	}

	public Drawables PopGraphicContext()
	{
		_drawables.Add(new DrawablePopGraphicContext());
		return this;
	}

	public Drawables PopPattern()
	{
		_drawables.Add(new DrawablePopPattern());
		return this;
	}

	public Drawables PushClipPath(string clipPath)
	{
		_drawables.Add(new DrawablePushClipPath(clipPath));
		return this;
	}

	public Drawables PushGraphicContext()
	{
		_drawables.Add(new DrawablePushGraphicContext());
		return this;
	}

	public Drawables PushPattern(string id, double x, double y, double width, double height)
	{
		_drawables.Add(new DrawablePushPattern(id, x, y, width, height));
		return this;
	}

	public Drawables Rectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
	{
		_drawables.Add(new DrawableRectangle(upperLeftX, upperLeftY, lowerRightX, lowerRightY));
		return this;
	}

	public Drawables Rotation(double angle)
	{
		_drawables.Add(new DrawableRotation(angle));
		return this;
	}

	public Drawables RoundRectangle(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY, double cornerWidth, double cornerHeight)
	{
		_drawables.Add(new DrawableRoundRectangle(upperLeftX, upperLeftY, lowerRightX, lowerRightY, cornerWidth, cornerHeight));
		return this;
	}

	public Drawables Scaling(double x, double y)
	{
		_drawables.Add(new DrawableScaling(x, y));
		return this;
	}

	public Drawables SkewX(double angle)
	{
		_drawables.Add(new DrawableSkewX(angle));
		return this;
	}

	public Drawables SkewY(double angle)
	{
		_drawables.Add(new DrawableSkewY(angle));
		return this;
	}

	public Drawables StrokeAntialias(bool isEnabled)
	{
		_drawables.Add(new DrawableStrokeAntialias(isEnabled));
		return this;
	}

	public Drawables StrokeColor(MagickColor color)
	{
		_drawables.Add(new DrawableStrokeColor(color));
		return this;
	}

	public Drawables StrokeDashArray(params double[] dash)
	{
		_drawables.Add(new DrawableStrokeDashArray(dash));
		return this;
	}

	public Drawables StrokeDashOffset(double offset)
	{
		_drawables.Add(new DrawableStrokeDashOffset(offset));
		return this;
	}

	public Drawables StrokeLineCap(LineCap lineCap)
	{
		_drawables.Add(new DrawableStrokeLineCap(lineCap));
		return this;
	}

	public Drawables StrokeLineJoin(LineJoin lineJoin)
	{
		_drawables.Add(new DrawableStrokeLineJoin(lineJoin));
		return this;
	}

	public Drawables StrokeMiterLimit(int miterlimit)
	{
		_drawables.Add(new DrawableStrokeMiterLimit(miterlimit));
		return this;
	}

	public Drawables StrokeOpacity(Percentage opacity)
	{
		_drawables.Add(new DrawableStrokeOpacity(opacity));
		return this;
	}

	public Drawables StrokePatternUrl(string url)
	{
		_drawables.Add(new DrawableStrokePatternUrl(url));
		return this;
	}

	public Drawables StrokeWidth(double width)
	{
		_drawables.Add(new DrawableStrokeWidth(width));
		return this;
	}

	public Drawables Text(double x, double y, string value)
	{
		_drawables.Add(new DrawableText(x, y, value));
		return this;
	}

	public Drawables TextAlignment(TextAlignment alignment)
	{
		_drawables.Add(new DrawableTextAlignment(alignment));
		return this;
	}

	public Drawables TextAntialias(bool isEnabled)
	{
		_drawables.Add(new DrawableTextAntialias(isEnabled));
		return this;
	}

	public Drawables TextDecoration(TextDecoration decoration)
	{
		_drawables.Add(new DrawableTextDecoration(decoration));
		return this;
	}

	public Drawables TextDirection(TextDirection direction)
	{
		_drawables.Add(new DrawableTextDirection(direction));
		return this;
	}

	public Drawables TextEncoding(Encoding encoding)
	{
		_drawables.Add(new DrawableTextEncoding(encoding));
		return this;
	}

	public Drawables TextInterlineSpacing(double spacing)
	{
		_drawables.Add(new DrawableTextInterlineSpacing(spacing));
		return this;
	}

	public Drawables TextInterwordSpacing(double spacing)
	{
		_drawables.Add(new DrawableTextInterwordSpacing(spacing));
		return this;
	}

	public Drawables TextKerning(double kerning)
	{
		_drawables.Add(new DrawableTextKerning(kerning));
		return this;
	}

	public Drawables TextUnderColor(MagickColor color)
	{
		_drawables.Add(new DrawableTextUnderColor(color));
		return this;
	}

	public Drawables Translation(double x, double y)
	{
		_drawables.Add(new DrawableTranslation(x, y));
		return this;
	}

	public Drawables Viewbox(double upperLeftX, double upperLeftY, double lowerRightX, double lowerRightY)
	{
		_drawables.Add(new DrawableViewbox(upperLeftX, upperLeftY, lowerRightX, lowerRightY));
		return this;
	}
}
