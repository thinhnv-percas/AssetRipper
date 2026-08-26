using DecompTools.Decompiler.Semantics;

namespace DecompTools.Decompiler.CSharp.Resolver;

internal class LambdaConversion : Conversion
{
	public static readonly LambdaConversion Instance = new LambdaConversion();

	public override bool IsAnonymousFunctionConversion => true;

	public override bool IsImplicit => true;
}
