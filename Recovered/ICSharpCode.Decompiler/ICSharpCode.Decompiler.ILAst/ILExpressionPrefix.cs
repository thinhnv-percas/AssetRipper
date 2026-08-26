namespace ICSharpCode.Decompiler.ILAst
{
	public class ILExpressionPrefix
	{
		public readonly ILCode Code;

		public readonly object Operand;

		public ILExpressionPrefix(ILCode code, object operand = null)
		{
			Code = code;
			Operand = operand;
		}
	}
}
