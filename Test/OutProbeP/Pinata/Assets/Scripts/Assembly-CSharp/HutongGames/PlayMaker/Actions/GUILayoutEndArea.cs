using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757418", Offset = "0x757418")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757418", Offset = "0x757418")]
	[Token(Token = "0x2000220")]
	public class GUILayoutEndArea : FsmStateAction
	{
		[Token(Token = "0x6000AD7")]
		[Address(RVA = "0xB7A498", Offset = "0xB7A498", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000AD8")]
		[Address(RVA = "0xB7A49C", Offset = "0xB7A49C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GUILayout::EndArea();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			GUILayout.EndArea();
		}

		[Token(Token = "0x6000AD9")]
		[Address(RVA = "0xB7A4A4", Offset = "0xB7A4A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutEndArea()
		{
		}
	}
}
