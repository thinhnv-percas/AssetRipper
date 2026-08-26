namespace DevX.Cecil
{
	public interface IReflectionStructureVisitable
	{
		void Accept(IReflectionStructureVisitor visitor);
	}
}
