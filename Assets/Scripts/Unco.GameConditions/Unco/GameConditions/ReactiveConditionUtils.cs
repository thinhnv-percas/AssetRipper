using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.GameConditions.Implementations;

namespace Unco.GameConditions
{
	[Token(Token = "0x2000004")]
	public static class ReactiveConditionUtils
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81AC4E8", Offset = "0x81AC4E8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\treturn \"No description available for this condition type\";\n")]
		public static string GetConditionUnlockedText(this ICondition condition)
		{
			return "No description available for this condition type";
		}
	}
}
