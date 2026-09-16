using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7575A8", Offset = "0x7575A8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7575A8", Offset = "0x7575A8")]
	[Token(Token = "0x2000225")]
	public class GUILayoutFlexibleSpace : FsmStateAction
	{
		[Token(Token = "0x6000AE5")]
		[Address(RVA = "0xB7A524", Offset = "0xB7A524", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000AE6")]
		[Address(RVA = "0xB7A528", Offset = "0xB7A528", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GUILayout::FlexibleSpace();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			GUILayout.FlexibleSpace();
		}

		[Token(Token = "0x6000AE7")]
		[Address(RVA = "0xB7A530", Offset = "0xB7A530", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutFlexibleSpace()
		{
		}
	}
}
