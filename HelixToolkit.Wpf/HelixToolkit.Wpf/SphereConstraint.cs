using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class SphereConstraint : Constraint
{
	public Point3D Center { get; set; }

	public int Index { get; set; }

	public double Radius { get; set; }

	public double RadiusSquared { get; set; }

	public SphereConstraint(int index, Point3D center, double radius)
	{
		Index = index;
		Center = center;
		Radius = radius;
		RadiusSquared = radius * radius;
	}

	public override void Satisfy(VerletIntegrator vs, int iteration)
	{
		Vector3D vector3D = Point3D.Subtract(vs.Positions[Index], Center);
		if (vector3D.LengthSquared < RadiusSquared)
		{
			vector3D.Normalize();
			vs.Positions[Index] = Center + vector3D * Radius * 1.1;
			vs.Positions0[Index] = vs.Positions[Index];
		}
	}
}
