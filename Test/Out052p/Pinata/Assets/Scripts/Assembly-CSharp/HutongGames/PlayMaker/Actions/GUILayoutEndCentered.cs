using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757468", Offset = "0x757468")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757468", Offset = "0x757468")]
	[Token(Token = "0x2000221")]
	public class GUILayoutEndCentered : FsmStateAction
	{
		[Token(Token = "0x6000ADA")]
		[Address(RVA = "0xB7A4AC", Offset = "0xB7A4AC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000ADB")]
		[Address(RVA = "0xB7A4B0", Offset = "0xB7A4B0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GUILayout::EndVertical();\n\tUnityEngine.GUILayout::FlexibleSpace();\n\tUnityEngine.GUILayout::EndHorizontal();\n\tUnityEngine.GUILayout::FlexibleSpace();\n\tUnityEngine.GUILayout::EndVertical();\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
		}

		[Token(Token = "0x6000ADC")]
		[Address(RVA = "0xB7A4E4", Offset = "0xB7A4E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutEndCentered()
		{
		}
	}
}
