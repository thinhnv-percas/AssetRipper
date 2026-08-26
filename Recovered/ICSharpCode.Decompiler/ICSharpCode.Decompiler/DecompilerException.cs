using Mono.Cecil;
using System;
using System.Runtime.Serialization;

namespace ICSharpCode.Decompiler
{
	public class DecompilerException : Exception, ISerializable
	{
		public MethodDefinition DecompiledMethod
		{
			get;
			set;
		}

		public DecompilerException(MethodDefinition decompiledMethod, Exception innerException)
			: base("Error decompiling " + decompiledMethod.FullName + Environment.NewLine, innerException)
		{
		}

		protected DecompilerException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
