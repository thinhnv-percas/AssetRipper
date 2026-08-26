namespace DevX.Cecil.Cil
{
	public interface ICodeVisitable
	{
		void Accept(ICodeVisitor visitor);
	}
}
