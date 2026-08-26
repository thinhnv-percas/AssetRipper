namespace HelixToolkit.Wpf;

public abstract class Constraint
{
	public abstract void Satisfy(VerletIntegrator vs, int iteration);
}
