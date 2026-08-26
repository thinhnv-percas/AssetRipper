using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public interface ISimpleILPrinter
{
	double Order { get; }

	bool Write(IDecompilerOutput output, IMemberRef member);

	void Write(IDecompilerOutput output, MethodSig sig);

	void Write(IDecompilerOutput output, TypeSig type);
}
