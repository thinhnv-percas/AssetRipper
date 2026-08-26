using DecompTools.Decompiler.IL;

namespace DecompTools.Decompiler.CSharp;

public class ImplicitReturnAnnotation
{
	public readonly Leave Leave;

	public ImplicitReturnAnnotation(Leave leave)
	{
		Leave = leave;
	}
}
