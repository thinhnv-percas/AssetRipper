using System;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class DistanceConstraint : Constraint
{
	public int Index1 { get; set; }

	public int Index2 { get; set; }

	public int Iterations { get; set; }

	public double RelaxationFactor { get; set; }

	public double Restlength { get; set; }

	public DistanceConstraint(int A, int B)
	{
		Index1 = A;
		Index2 = B;
	}

	public override void Satisfy(VerletIntegrator vs, int iteration)
	{
		if (Iterations <= iteration)
		{
			return;
		}
		Point3D point3D = vs.Positions[Index1];
		Point3D point3D2 = vs.Positions[Index2];
		Vector3D vector3D = point3D2 - point3D;
		double length = vector3D.Length;
		double num = length - Restlength;
		double num2 = length * (vs.InverseMass[Index1] + vs.InverseMass[Index2]);
		if (Math.Abs(num2) > 1E-08)
		{
			num /= num2;
			if (vs.InverseMass[Index1] != 0.0)
			{
				vs.Positions[Index1] += vector3D * num * vs.InverseMass[Index1] * RelaxationFactor;
			}
			if (vs.InverseMass[Index2] != 0.0)
			{
				vs.Positions[Index2] -= vector3D * num * vs.InverseMass[Index2] * RelaxationFactor;
			}
		}
	}
}
