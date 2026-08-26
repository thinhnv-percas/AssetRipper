namespace DevX.Cecil
{
	public interface IReflectionVisitable
	{
		void Accept(IReflectionVisitor visitor);
	}
}
