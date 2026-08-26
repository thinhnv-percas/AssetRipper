using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory;
using Mono.Cecil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler
{
	public class MethodDebugSymbols
	{
		public MethodDefinition CecilMethod
		{
			get;
			set;
		}

		public List<ILVariable> LocalVariables
		{
			get;
			set;
		}

		public List<SequencePoint> SequencePoints
		{
			get;
			set;
		}

		public TextLocation StartLocation
		{
			get;
			set;
		}

		public TextLocation EndLocation
		{
			get;
			set;
		}

		public MethodDebugSymbols(MethodDefinition methodDef)
		{
			CecilMethod = methodDef;
			LocalVariables = new List<ILVariable>();
			SequencePoints = new List<SequencePoint>();
		}
	}
}
