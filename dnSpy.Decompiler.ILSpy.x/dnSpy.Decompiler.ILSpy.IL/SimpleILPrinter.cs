using System.ComponentModel.Composition;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.ILSpy.Core.IL;
using ICSharpCode.Decompiler.Disassembler;

namespace dnSpy.Decompiler.ILSpy.IL;

[Export(typeof(ISimpleILPrinter))]
internal sealed class SimpleILPrinter : ISimpleILPrinter
{
	double ISimpleILPrinter.Order => -100.0;

	bool ISimpleILPrinter.Write(IDecompilerOutput output, IMemberRef member)
	{
		return ILDecompilerUtils.Write(output, member);
	}

	void ISimpleILPrinter.Write(IDecompilerOutput output, MethodSig sig)
	{
		output.Write(sig);
	}

	void ISimpleILPrinter.Write(IDecompilerOutput output, TypeSig type)
	{
		type.WriteTo(output);
	}
}
