using System;
using System.Drawing.Drawing2D;

namespace ImageMagick;

public sealed class DrawableAffine : IDrawable, IDrawingWand
{
	public double ScaleX { get; set; }

	public double ScaleY { get; set; }

	public double ShearX { get; set; }

	public double ShearY { get; set; }

	public double TranslateX { get; set; }

	public double TranslateY { get; set; }

	public DrawableAffine(Matrix matrix)
	{
		Throw.IfNull("matrix", matrix);
		ScaleX = matrix.Elements[0];
		ScaleY = matrix.Elements[1];
		ShearX = matrix.Elements[2];
		ShearY = matrix.Elements[3];
		TranslateX = matrix.Elements[4];
		TranslateY = matrix.Elements[5];
	}

	public DrawableAffine()
	{
		Reset();
	}

	public DrawableAffine(double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY)
	{
		ScaleX = scaleX;
		ScaleY = scaleY;
		ShearX = shearX;
		ShearY = shearY;
		TranslateX = translateX;
		TranslateY = translateY;
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		wand?.Affine(ScaleX, ScaleY, ShearX, ShearY, TranslateX, TranslateY);
	}

	public void Reset()
	{
		ScaleX = 1.0;
		ScaleY = 1.0;
		ShearX = 0.0;
		ShearY = 0.0;
		TranslateX = 0.0;
		TranslateY = 0.0;
	}

	public void TransformOrigin(double translateX, double translateY)
	{
		DrawableAffine drawableAffine = new DrawableAffine();
		drawableAffine.TranslateX = translateX;
		drawableAffine.TranslateY = translateY;
		Transform(drawableAffine);
	}

	public void TransformRotation(double angle)
	{
		DrawableAffine drawableAffine = new DrawableAffine();
		drawableAffine.ScaleX = Math.Cos(DegreesToRadians(Math.IEEERemainder(angle, 360.0)));
		drawableAffine.ScaleY = Math.Cos(DegreesToRadians(Math.IEEERemainder(angle, 360.0)));
		drawableAffine.ShearX = 0.0 - Math.Sin(DegreesToRadians(Math.IEEERemainder(angle, 360.0)));
		drawableAffine.ShearY = Math.Sin(DegreesToRadians(Math.IEEERemainder(angle, 360.0)));
		Transform(drawableAffine);
	}

	public void TransformScale(double scaleX, double scaleY)
	{
		DrawableAffine drawableAffine = new DrawableAffine();
		drawableAffine.ScaleX = scaleX;
		drawableAffine.ScaleY = scaleY;
		Transform(drawableAffine);
	}

	public void TransformSkewX(double skewX)
	{
		DrawableAffine drawableAffine = new DrawableAffine();
		drawableAffine.ShearX = Math.Tan(DegreesToRadians(Math.IEEERemainder(skewX, 360.0)));
		Transform(drawableAffine);
	}

	public void TransformSkewY(double skewY)
	{
		DrawableAffine drawableAffine = new DrawableAffine();
		drawableAffine.ShearY = Math.Tan(DegreesToRadians(Math.IEEERemainder(skewY, 360.0)));
		Transform(drawableAffine);
	}

	private static double DegreesToRadians(double x)
	{
		return Math.PI * x / 180.0;
	}

	private void Transform(DrawableAffine affine)
	{
		double scaleX = ScaleX;
		double scaleY = ScaleY;
		double shearX = ShearX;
		double shearY = ShearY;
		double translateX = TranslateX;
		double translateY = TranslateY;
		ScaleX = scaleX * affine.ScaleX + shearY * affine.ShearX;
		ScaleY = shearX * affine.ShearY + scaleY * affine.ScaleY;
		ShearX = shearX * affine.ScaleX + scaleY * affine.ShearX;
		ShearY = scaleX * affine.ShearY + shearY * affine.ScaleY;
		TranslateX = scaleX * affine.TranslateX + shearY * affine.TranslateY + translateX;
		TranslateY = shearX * affine.TranslateX + scaleY * affine.TranslateY + translateY;
	}
}
