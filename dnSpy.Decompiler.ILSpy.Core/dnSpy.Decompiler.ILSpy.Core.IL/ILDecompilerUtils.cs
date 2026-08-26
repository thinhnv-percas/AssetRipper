using System.Threading;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.Decompiler.Disassembler;

namespace dnSpy.Decompiler.ILSpy.Core.IL;

internal static class ILDecompilerUtils
{
	public static bool Write(IDecompilerOutput output, IMemberRef member)
	{
		if (member is IMethod { IsMethod: not false } method)
		{
			method.WriteMethodTo(output);
			return true;
		}
		if (member is IField { IsField: not false } field)
		{
			field.WriteFieldTo(output);
			return true;
		}
		if (member is PropertyDef property)
		{
			ReflectionDisassembler reflectionDisassembler = new ReflectionDisassembler(output, detectControlStructure: false, new DisassemblerOptions(0, default(CancellationToken), null));
			reflectionDisassembler.DisassembleProperty(property, full: false);
			return true;
		}
		if (member is EventDef ev)
		{
			ReflectionDisassembler reflectionDisassembler2 = new ReflectionDisassembler(output, detectControlStructure: false, new DisassemblerOptions(0, default(CancellationToken), null));
			reflectionDisassembler2.DisassembleEvent(ev, full: false);
			return true;
		}
		if (member is ITypeDefOrRef type)
		{
			type.WriteTo(output, ILNameSyntax.TypeName);
			return true;
		}
		return false;
	}
}
