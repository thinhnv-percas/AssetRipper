using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753784", Offset = "0x753784")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753784", Offset = "0x753784")]
	[Token(Token = "0x200016A")]
	public class ApplicationQuit : FsmStateAction
	{
		[Token(Token = "0x60007F5")]
		[Address(RVA = "0xA88660", Offset = "0xA88660", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x60007F6")]
		[Address(RVA = "0xA88664", Offset = "0xA88664", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Application::Quit();\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Application.Quit();
			Finish();
		}

		[Token(Token = "0x60007F7")]
		[Address(RVA = "0xA88690", Offset = "0xA88690", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ApplicationQuit()
		{
		}
	}
}
