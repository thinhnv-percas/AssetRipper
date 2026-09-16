using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757508", Offset = "0x757508")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757508", Offset = "0x757508")]
	[Token(Token = "0x2000223")]
	public class GUILayoutEndScrollView : FsmStateAction
	{
		[Token(Token = "0x6000AE0")]
		[Address(RVA = "0xB7A500", Offset = "0xB7A500", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GUILayout::EndScrollView();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			GUILayout.EndScrollView();
		}

		[Token(Token = "0x6000AE1")]
		[Address(RVA = "0xB7A508", Offset = "0xB7A508", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutEndScrollView()
		{
		}
	}
}
