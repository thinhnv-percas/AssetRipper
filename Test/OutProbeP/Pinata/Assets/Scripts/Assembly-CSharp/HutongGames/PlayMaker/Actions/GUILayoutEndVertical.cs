using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757558", Offset = "0x757558")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757558", Offset = "0x757558")]
	[Token(Token = "0x2000224")]
	public class GUILayoutEndVertical : FsmStateAction
	{
		[Token(Token = "0x6000AE2")]
		[Address(RVA = "0xB7A510", Offset = "0xB7A510", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000AE3")]
		[Address(RVA = "0xB7A514", Offset = "0xB7A514", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GUILayout::EndVertical();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			GUILayout.EndVertical();
		}

		[Token(Token = "0x6000AE4")]
		[Address(RVA = "0xB7A51C", Offset = "0xB7A51C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutEndVertical()
		{
		}
	}
}
