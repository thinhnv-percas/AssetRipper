using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ICSharpCode.Decompiler
{
	public class DecompilerContext
	{
		public ModuleDefinition CurrentModule;

		public CancellationToken CancellationToken;

		public TypeDefinition CurrentType;

		public MethodDefinition CurrentMethod;

		public DecompilerSettings Settings = new DecompilerSettings();

		public bool CurrentMethodIsAsync;

		internal List<string> ReservedVariableNames = new List<string>();

		public DecompilerContext(ModuleDefinition currentModule)
		{
			if (currentModule == null)
			{
				throw new ArgumentNullException("currentModule");
			}
			CurrentModule = currentModule;
		}

		public DecompilerContext Clone()
		{
			DecompilerContext obj = (DecompilerContext)MemberwiseClone();
			obj.ReservedVariableNames = new List<string>(obj.ReservedVariableNames);
			return obj;
		}
	}
}
