using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759D38", Offset = "0x759D38")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759D38", Offset = "0x759D38")]
	[Token(Token = "0x200029E")]
	public class GetJointBreakInfo : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B9DA4", Offset = "0x7B9DA4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9DA4", Offset = "0x7B9DA4")]
		[Token(Token = "0x4001731")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat breakForce;

		[Token(Token = "0x6000D0D")]
		[Address(RVA = "0xA2EF80", Offset = "0xA2EF80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.breakForce = 0;\n\treturn;\n")]
		public override void Reset()
		{
			breakForce = null;
		}

		[Token(Token = "0x6000D0E")]
		[Address(RVA = "0xA2EF88", Offset = "0xA2EF88", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.fsm;\n\tv9 = this.breakForce;\n\tv9.value = v6.<JointBreakForce>k__BackingField;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Fsm fsm = Fsm;
			FsmFloat fsmFloat = breakForce;
			fsmFloat.Value = fsm.JointBreakForce;
			Finish();
		}

		[Token(Token = "0x6000D0F")]
		[Address(RVA = "0xA2EFBC", Offset = "0xA2EFBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetJointBreakInfo()
		{
		}
	}
}
