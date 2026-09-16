using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7597F8", Offset = "0x7597F8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7597F8", Offset = "0x7597F8")]
	[Token(Token = "0x200028D")]
	public class RandomFloat : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40016DD")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat min;

		[RequiredField]
		[Token(Token = "0x40016DE")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat max;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8A50", Offset = "0x7B8A50")]
		[Token(Token = "0x40016DF")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeResult;

		[Token(Token = "0x6000CAE")]
		[Address(RVA = "0xB1CCE4", Offset = "0xB1CCE4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.min = v12;\n\tv15 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.max = v15;\n\tthis.storeResult = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0f;
			min = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			max = fsmFloat2;
			storeResult = null;
		}

		[Token(Token = "0x6000CAF")]
		[Address(RVA = "0xB1CD20", Offset = "0xB1CD20", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.storeResult;\n\tv18 = HutongGames.PlayMaker.FsmFloat::get_Value(this.min);\n\tv58 = HutongGames.PlayMaker.FsmFloat::get_Value(this.max);\n\tv48 = UnityEngine.Random::Range(v18, v58);\n\tv16.value = v48;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat = storeResult;
			float value = min.Value;
			float value2 = max.Value;
			float value3 = Random.Range(value, value2);
			fsmFloat.Value = value3;
			Finish();
		}

		[Token(Token = "0x6000CB0")]
		[Address(RVA = "0xB1CD98", Offset = "0xB1CD98", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RandomFloat()
		{
		}
	}
}
