using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7574B8", Offset = "0x7574B8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7574B8", Offset = "0x7574B8")]
	[Token(Token = "0x2000222")]
	public class GUILayoutEndHorizontal : FsmStateAction
	{
		[Token(Token = "0x6000ADD")]
		[Address(RVA = "0xB7A4EC", Offset = "0xB7A4EC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000ADE")]
		[Address(RVA = "0xB7A4F0", Offset = "0xB7A4F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GUILayout::EndHorizontal();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			GUILayout.EndHorizontal();
		}

		[Token(Token = "0x6000ADF")]
		[Address(RVA = "0xB7A4F8", Offset = "0xB7A4F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutEndHorizontal()
		{
		}
	}
}
