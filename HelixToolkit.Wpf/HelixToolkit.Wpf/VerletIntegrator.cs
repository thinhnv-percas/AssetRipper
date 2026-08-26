using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class VerletIntegrator
{
	private double dtprev;

	public Vector3D[] Accelerations { get; private set; }

	public List<Constraint> Constraints { get; private set; }

	public double Damping { get; set; }

	public double[] InverseMass { get; private set; }

	public int Iterations { get; set; }

	public Point3D[] Positions { get; private set; }

	public Point3D[] Positions0 { get; private set; }

	public VerletIntegrator()
	{
		Damping = 0.9950000047683716;
		Iterations = 4;
		Constraints = new List<Constraint>();
	}

	public void AddConstraint(int A, int B, double relax)
	{
		DistanceConstraint distanceConstraint = new DistanceConstraint(A, B);
		distanceConstraint.Restlength = (Positions[A] - Positions[B]).Length;
		distanceConstraint.RelaxationFactor = relax;
		distanceConstraint.Iterations = Iterations;
		Constraints.Add(distanceConstraint);
	}

	public void AddFloor(double friction)
	{
		for (int i = 0; i < Positions.Length; i++)
		{
			FloorConstraint item = new FloorConstraint(i, friction);
			Constraints.Add(item);
		}
	}

	public void AddSphere(Point3D center, double radius)
	{
		for (int i = 0; i < Positions.Length; i++)
		{
			SphereConstraint item = new SphereConstraint(i, center, radius);
			Constraints.Add(item);
		}
	}

	public void ApplyGravity(Vector3D gravity)
	{
		for (int i = 0; i < Positions.Length; i++)
		{
			Accelerations[i] = gravity * InverseMass[i];
		}
	}

	public void CreateConstraintsByMesh(MeshGeometry3D mesh, double relax)
	{
		for (int i = 0; i < mesh.TriangleIndices.Count; i += 3)
		{
			int num = mesh.TriangleIndices[i];
			int num2 = mesh.TriangleIndices[i + 1];
			int num3 = mesh.TriangleIndices[i + 2];
			AddConstraint(num, num2, relax);
			AddConstraint(num2, num3, relax);
			AddConstraint(num3, num, relax);
		}
	}

	public void FixPosition(int i)
	{
		InverseMass[i] = 0.0;
	}

	public void Init(MeshGeometry3D mesh)
	{
		Resize(mesh.Positions.Count);
		for (int i = 0; i < mesh.Positions.Count; i++)
		{
			Positions[i] = mesh.Positions[i];
			Positions0[i] = Positions[i];
			Accelerations[i] = default(Vector3D);
		}
	}

	public void Resize(int n)
	{
		Positions = new Point3D[n];
		Positions0 = new Point3D[n];
		Accelerations = new Vector3D[n];
		InverseMass = new double[n];
	}

	public void SetForce(int index, Vector3D force)
	{
		Accelerations[index] = force * InverseMass[index];
	}

	public void SetInverseMass(double invmass)
	{
		for (int i = 0; i < Positions.Length; i++)
		{
			InverseMass[i] = invmass;
		}
	}

	public void TimeStep(double dt)
	{
		Integrate(dt);
		for (int i = 0; i < Iterations; i++)
		{
			SatisfyConstraints(i);
		}
	}

	public void TransferPositions(MeshGeometry3D mesh)
	{
		lock (Positions)
		{
			Point3DCollection point3DCollection = new Point3DCollection(Positions.Length);
			for (int i = 0; i < Positions.Length; i++)
			{
				point3DCollection.Add(Positions[i]);
			}
			mesh.Positions = point3DCollection;
		}
	}

	private void Integrate(double dt)
	{
		if (dtprev == 0.0)
		{
			dtprev = dt;
		}
		lock (Positions)
		{
			for (int i = 0; i < Positions.Length; i++)
			{
				if (InverseMass[i] != 0.0)
				{
					Point3D point3D = Positions[i];
					Positions[i] += (Positions[i] - Positions0[i]) * dt / dtprev * Damping + Accelerations[i] * dt * dt;
					Positions0[i] = point3D;
				}
			}
		}
		dtprev = dt;
	}

	private void SatisfyConstraints(int iteration)
	{
		foreach (Constraint constraint in Constraints)
		{
			constraint.Satisfy(this, iteration);
		}
	}
}
