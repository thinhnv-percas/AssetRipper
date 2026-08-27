using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WFTools3D
{
	public static class Math3D_ExtHost
	{
	public static double Distance(this Point3D pt)
	{
		return Math3D.Distance(pt);
	}
	public static double DistanceSquared(this Point3D pt)
	{
		return Math3D.DistanceSquared(pt);
	}
	public static Point3D Add(this Point3D pt, Point3D add)
	{
		return Math3D.Add(pt, add);
	}
	public static Point3D Subtract(this Point3D pt, Point3D add)
	{
		return Math3D.Subtract(pt, add);
	}
	public static Point3D Inverse(this Point3D pt)
	{
		return Math3D.Inverse(pt);
	}
	public static bool IsValid(this Point3D pt)
	{
		return Math3D.IsValid(pt);
	}
	public static bool IsValid(this Vector3D dir)
	{
		return Math3D.IsValid(dir);
	}
	public static Vector3D Transform(this Quaternion q, Vector3D v)
	{
		return Math3D.Transform(q, v);
	}
	public static Point3D Transform(this Quaternion q, Point3D p)
	{
		return Math3D.Transform(q, p);
	}
	public static Vector3D Rotate(this Vector3D v, Vector3D rotationAxis, double angleInDegrees)
	{
		return Math3D.Rotate(v, rotationAxis, angleInDegrees);
	}
	public static Vector3D Cross(this Vector3D v, Vector3D vector)
	{
		return Math3D.Cross(v, vector);
	}
	public static double Dot(this Vector3D v, Vector3D vector)
	{
		return Math3D.Dot(v, vector);
	}
	public static double AngleTo(this Vector3D v, Vector3D vector)
	{
		return Math3D.AngleTo(v, vector);
	}
	public static Vector3D DirectionTo(this Point3D thisPoint, Point3D targetPoint)
	{
		return Math3D.DirectionTo(thisPoint, targetPoint);
	}
	}
}
