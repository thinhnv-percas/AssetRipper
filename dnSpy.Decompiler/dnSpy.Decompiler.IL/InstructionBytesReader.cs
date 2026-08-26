using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Decompiler.IL;

public static class InstructionBytesReader
{
	public static IInstructionBytesReader Create(MethodDef method, bool isBodyModified)
	{
		bool flag = method is MethodDefUser;
		if (!(method.Module is ModuleDefMD))
		{
			flag = true;
		}
		if (flag | isBodyModified)
		{
			return new ModifiedInstructionBytesReader(method);
		}
		return new OriginalInstructionBytesReader(method);
	}
}
