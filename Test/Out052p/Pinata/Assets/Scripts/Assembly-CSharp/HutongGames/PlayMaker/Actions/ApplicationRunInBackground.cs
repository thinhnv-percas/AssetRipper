using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7537D4", Offset = "0x7537D4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7537D4", Offset = "0x7537D4")]
	[Token(Token = "0x200016B")]
	public class ApplicationRunInBackground : FsmStateAction
	{
		[Token(Token = "0x4001230")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool runInBackground;

		[Token(Token = "0x60007F8")]
		[Address(RVA = "0xA88698", Offset = "0xA88698", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.runInBackground = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = true;
			runInBackground = fsmBool;
		}

		[Token(Token = "0x60007F9")]
		[Address(RVA = "0xA886C4", Offset = "0xA886C4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmBool::get_Value(this.runInBackground);\n\tUnityEngine.Application::set_runInBackground(v13);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool value = runInBackground.Value;
			Application.runInBackground = value;
			Finish();
		}

		[Token(Token = "0x60007FA")]
		[Address(RVA = "0xA88708", Offset = "0xA88708", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ApplicationRunInBackground()
		{
		}
	}
}
