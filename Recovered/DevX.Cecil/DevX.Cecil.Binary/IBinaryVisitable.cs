namespace DevX.Cecil.Binary
{
	public interface IBinaryVisitable
	{
		void Accept(IBinaryVisitor visitor);
	}
}
