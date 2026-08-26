using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class FloorConstraint : Constraint
{
	public double Friction { get; set; }

	public int Index { get; set; }

	public FloorConstraint(int index, double friction = 1.0)
	{
		Index = index;
		Friction = friction;
	}

	public override void Satisfy(VerletIntegrator vs, int iteration)
	{
		int index = Index;
		Point3D point3D = vs.Positions[index];
		if (!(point3D.Z <= 0.0))
		{
			return;
		}
		if (Friction != 0.0)
		{
			double num = (0.0 - point3D.Z) * Friction;
			Vector3D vector3D = vs.Positions[index] - vs.Positions0[index];
			vector3D.Z = 0.0;
			if (vector3D.X > 0.0)
			{
				vector3D.X -= num * vector3D.X;
				if (vector3D.X < 0.0)
				{
					vector3D.X = 0.0;
				}
			}
			else
			{
				vector3D.X += num;
				if (vector3D.X > 0.0)
				{
					vector3D.X = 0.0;
				}
			}
			if (vector3D.Y > 0.0)
			{
				vector3D.Y -= num * vector3D.Y;
				if (vector3D.Y < 0.0)
				{
					vector3D.Y = 0.0;
				}
			}
			else
			{
				vector3D.Y += num;
				if (vector3D.Y > 0.0)
				{
					vector3D.Y = 0.0;
				}
			}
			vs.Positions0[index] = vs.Positions[index] - vector3D;
		}
		vs.Positions[index].Z = 0.0;
	}
}
