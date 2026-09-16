using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x73EC74", Offset = "0x73EC74")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x73EC74", Offset = "0x73EC74")]
	[Token(Token = "0x200007B")]
	public class MissingAction : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x740114", Offset = "0x740114")]
		[Token(Token = "0x400033E")]
		[FieldOffset(Offset = "0x50")]
		public string actionName;

		[Token(Token = "0x6000677")]
		[Address(RVA = "0x9D76C0", Offset = "0x9D76C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MissingAction()
		{
		}
	}
}
