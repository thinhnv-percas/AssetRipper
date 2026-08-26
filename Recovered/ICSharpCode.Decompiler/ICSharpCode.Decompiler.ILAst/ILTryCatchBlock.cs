using Mono.Cecil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILTryCatchBlock : ILNode
	{
		public class CatchBlock : ILBlock
		{
			public TypeReference ExceptionType;

			public ILVariable ExceptionVariable;

			public override void WriteTo(ITextOutput output)
			{
				output.Write("catch ");
				output.WriteReference(ExceptionType.FullName, ExceptionType);
				if (ExceptionVariable != null)
				{
					output.Write(' ');
					output.Write(ExceptionVariable.Name);
				}
				output.WriteLine(" {");
				output.Indent();
				base.WriteTo(output);
				output.Unindent();
				output.WriteLine("}");
			}
		}

		public ILBlock TryBlock;

		public List<CatchBlock> CatchBlocks;

		public ILBlock FinallyBlock;

		public ILBlock FaultBlock;

		public override IEnumerable<ILNode> GetChildren()
		{
			if (TryBlock != null)
			{
				yield return TryBlock;
			}
			foreach (CatchBlock catchBlock in CatchBlocks)
			{
				yield return catchBlock;
			}
			if (FaultBlock != null)
			{
				yield return FaultBlock;
			}
			if (FinallyBlock != null)
			{
				yield return FinallyBlock;
			}
		}

		public override void WriteTo(ITextOutput output)
		{
			output.WriteLine(".try {");
			output.Indent();
			TryBlock.WriteTo(output);
			output.Unindent();
			output.WriteLine("}");
			foreach (CatchBlock catchBlock in CatchBlocks)
			{
				catchBlock.WriteTo(output);
			}
			if (FaultBlock != null)
			{
				output.WriteLine("fault {");
				output.Indent();
				FaultBlock.WriteTo(output);
				output.Unindent();
				output.WriteLine("}");
			}
			if (FinallyBlock != null)
			{
				output.WriteLine("finally {");
				output.Indent();
				FinallyBlock.WriteTo(output);
				output.Unindent();
				output.WriteLine("}");
			}
		}
	}
}
