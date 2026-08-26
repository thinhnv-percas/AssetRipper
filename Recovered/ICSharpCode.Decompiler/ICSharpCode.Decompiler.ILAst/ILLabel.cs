namespace ICSharpCode.Decompiler.ILAst
{
	public class ILLabel : ILNode
	{
		public string Name;

		public override void WriteTo(ITextOutput output)
		{
			output.WriteDefinition(Name + ":", this);
		}
	}
}
