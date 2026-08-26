using System;
using System.Runtime.Serialization;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler;

public class DecompilerException : Exception, ISerializable
{
	public MethodDef DecompiledMethod { get; set; }

	public DecompilerException(MethodDef decompiledMethod, Exception innerException)
		: base("Error decompiling " + decompiledMethod.FullName + Environment.NewLine, innerException)
	{
	}

	protected DecompilerException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
