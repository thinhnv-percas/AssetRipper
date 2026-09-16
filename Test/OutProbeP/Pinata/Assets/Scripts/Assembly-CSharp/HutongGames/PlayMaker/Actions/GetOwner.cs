using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75631C", Offset = "0x75631C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75631C", Offset = "0x75631C")]
	[Token(Token = "0x20001EB")]
	public class GetOwner : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B12B4", Offset = "0x7B12B4")]
		[Token(Token = "0x400145E")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject storeGameObject;

		[Token(Token = "0x6000A1E")]
		[Address(RVA = "0xA32548", Offset = "0xA32548", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeGameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeGameObject = null;
		}

		[Token(Token = "0x6000A1F")]
		[Address(RVA = "0xA32550", Offset = "0xA32550", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, this.owner);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			storeGameObject.Value = Owner;
			Finish();
		}

		[Token(Token = "0x6000A20")]
		[Address(RVA = "0xA3258C", Offset = "0xA3258C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetOwner()
		{
		}
	}
}
