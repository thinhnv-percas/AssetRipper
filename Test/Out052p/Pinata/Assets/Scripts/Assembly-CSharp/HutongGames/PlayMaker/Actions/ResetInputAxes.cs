using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7580C4", Offset = "0x7580C4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7580C4", Offset = "0x7580C4")]
	[Token(Token = "0x2000247")]
	public class ResetInputAxes : FsmStateAction
	{
		[Token(Token = "0x6000B6E")]
		[Address(RVA = "0xB241F8", Offset = "0xB241F8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000B6F")]
		[Address(RVA = "0xB241FC", Offset = "0xB241FC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Input::ResetInputAxes();\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Input.ResetInputAxes();
			Finish();
		}

		[Token(Token = "0x6000B70")]
		[Address(RVA = "0xB24228", Offset = "0xB24228", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResetInputAxes()
		{
		}
	}
}
