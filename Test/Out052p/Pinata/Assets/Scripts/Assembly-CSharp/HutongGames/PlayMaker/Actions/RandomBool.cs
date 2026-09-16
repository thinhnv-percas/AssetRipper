using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7597A8", Offset = "0x7597A8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7597A8", Offset = "0x7597A8")]
	[Token(Token = "0x200028C")]
	public class RandomBool : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8A1C", Offset = "0x7B8A1C")]
		[Token(Token = "0x40016DC")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool storeResult;

		[Token(Token = "0x6000CAB")]
		[Address(RVA = "0xB1CA3C", Offset = "0xB1CA3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeResult = null;
		}

		[Token(Token = "0x6000CAC")]
		[Address(RVA = "0xB1CA44", Offset = "0xB1CA44", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.storeResult;\n\tv16 = UnityEngine.Random::Range(0, 0x64);\n\tv20 = v16 - 0x32;\n\tv21 = v20 < 0;\n\tv23 = v16 ^ 0x32;\n\tv24 = v16 ^ v20;\n\tv25 = v23 & v24;\n\tv26 = v25 < 0;\n\tv27 = v21 == v26;\n\tv28 = ~v27;\n\tv12.value = v28;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmBool fsmBool = storeResult;
			int num = Random.Range(0, 100);
			int num2 = num - 50;
			bool flag = num2 < 0;
			int num3 = num ^ 0x32;
			int num4 = num ^ num2;
			int num5 = num3 & num4;
			bool flag2 = num5 < 0;
			bool flag3 = flag == flag2;
			bool value = !flag3;
			fsmBool.value = value;
			Finish();
		}

		[Token(Token = "0x6000CAD")]
		[Address(RVA = "0xB1CA94", Offset = "0xB1CA94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RandomBool()
		{
		}
	}
}
