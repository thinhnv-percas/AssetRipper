using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759DD8", Offset = "0x759DD8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759DD8", Offset = "0x759DD8")]
	[Token(Token = "0x20002A0")]
	public class GetParticleCollisionInfo : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B9EEC", Offset = "0x7B9EEC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B9EEC", Offset = "0x7B9EEC")]
		[Token(Token = "0x4001734")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[Token(Token = "0x6000D14")]
		[Address(RVA = "0xA326F0", Offset = "0xA326F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObjectHit = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObjectHit = null;
		}

		[Token(Token = "0x6000D15")]
		[Address(RVA = "0xA326F8", Offset = "0xA326F8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.fsm;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v6.<ParticleCollisionGO>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreCollisionInfo()
		{
			Fsm fsm = Fsm;
			gameObjectHit.Value = fsm.ParticleCollisionGO;
		}

		[Token(Token = "0x6000D16")]
		[Address(RVA = "0xA32728", Offset = "0xA32728", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetParticleCollisionInfo::StoreCollisionInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreCollisionInfo();
			Finish();
		}

		[Token(Token = "0x6000D17")]
		[Address(RVA = "0xA32750", Offset = "0xA32750", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetParticleCollisionInfo()
		{
		}
	}
}
