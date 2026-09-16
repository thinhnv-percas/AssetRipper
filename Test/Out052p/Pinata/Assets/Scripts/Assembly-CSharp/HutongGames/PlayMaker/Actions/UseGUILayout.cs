using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757A58", Offset = "0x757A58")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757A58", Offset = "0x757A58")]
	[Token(Token = "0x2000234")]
	public class UseGUILayout : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001552")]
		[FieldOffset(Offset = "0x49")]
		public bool turnOffGUIlayout;

		[Token(Token = "0x6000B16")]
		[Address(RVA = "0x98661C", Offset = "0x98661C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.turnOffGUIlayout = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			turnOffGUIlayout = true;
		}

		[Token(Token = "0x6000B17")]
		[Address(RVA = "0x986628", Offset = "0x986628", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.fsm;\n\tv21 = this.turnOffGUIlayout == 0;\n\tUnityEngine.MonoBehaviour::set_useGUILayout(v10.owner, v21);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Fsm fsm = Fsm;
			bool useGUILayout = !turnOffGUIlayout;
			fsm.Owner.useGUILayout = useGUILayout;
			Finish();
		}

		[Token(Token = "0x6000B18")]
		[Address(RVA = "0x986678", Offset = "0x986678", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UseGUILayout()
		{
		}
	}
}
