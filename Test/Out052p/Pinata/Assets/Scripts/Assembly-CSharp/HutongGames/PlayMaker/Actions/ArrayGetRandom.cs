using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753BE4", Offset = "0x753BE4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753BE4", Offset = "0x753BE4")]
	[Token(Token = "0x2000178")]
	public class ArrayGetRandom : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9CB4", Offset = "0x7A9CB4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9CB4", Offset = "0x7A9CB4")]
		[Token(Token = "0x4001262")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9D14", Offset = "0x7A9D14")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9D14", Offset = "0x7A9D14")]
		[Attribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A9D14", Offset = "0x7A9D14")]
		[Token(Token = "0x4001263")]
		[FieldOffset(Offset = "0x58")]
		public FsmVar storeValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9D98", Offset = "0x7A9D98")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9D98", Offset = "0x7A9D98")]
		[Token(Token = "0x4001264")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt index;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9DE8", Offset = "0x7A9DE8")]
		[Token(Token = "0x4001265")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool noRepeat;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9E20", Offset = "0x7A9E20")]
		[Token(Token = "0x4001266")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001267")]
		[FieldOffset(Offset = "0x74")]
		private int randomIndex;

		[Token(Token = "0x4001268")]
		[FieldOffset(Offset = "0x78")]
		private int lastIndex;

		[Token(Token = "0x6000830")]
		[Address(RVA = "0xA898C0", Offset = "0xA898C0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.storeValue = 0;\n\tthis.index = 0;\n\tthis.array = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.noRepeat = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			storeValue = null;
			index = null;
			array = null;
			FsmBool fsmBool = false;
			noRepeat = fsmBool;
		}

		[Token(Token = "0x6000831")]
		[Address(RVA = "0xA898F8", Offset = "0xA898F8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayGetRandom::DoGetRandomValue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetRandomValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000832")]
		[Address(RVA = "0xA89A48", Offset = "0xA89A48", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayGetRandom::DoGetRandomValue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetRandomValue();
		}

		[Token(Token = "0x6000833")]
		[Address(RVA = "0xA89934", Offset = "0xA89934", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.FsmVar::get_IsNone(this.storeValue);\n\tv102 = v15 == 0;\n\tif (v102) goto L_0019;\n\treturn;\nL_0019:\n\tv160 = HutongGames.PlayMaker.FsmBool::get_Value(this.noRepeat);\n\tv162 = v160 == 0;\n\tif (v162) goto L_0031;\n\tv174 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv27 = v174 != 1;\n\tif (v27) goto L_003C;\nL_0031:\n\tv176 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv127 = UnityEngine.Random::Range(0, v176);\n\tthis.randomIndex = v127;\n\tgoto L_004E;\nL_003C:\n\tv197 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv127 = UnityEngine.Random::Range(0, v197);\n\tthis.randomIndex = v127;\n\tv188 = v127 == this.lastIndex;\n\tif (v188) goto L_003C;\n\tthis.lastIndex = v127;\nL_004E:\n\tv19 = this.index;\n\tv19.value = v127;\n\tv125 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv126 = HutongGames.PlayMaker.FsmArray::Get(this.array, v125);\n\tHutongGames.PlayMaker.FsmVar::SetValue(this.storeValue, v126);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetRandomValue()
		{
			if (storeValue.IsNone)
			{
				return;
			}
			int num;
			if (noRepeat.Value)
			{
				int length = array.Length;
				if (length != 1)
				{
					do
					{
						int length2 = array.Length;
						num = (randomIndex = Random.Range(0, length2));
					}
					while (num == lastIndex);
					lastIndex = num;
					goto IL_0168;
				}
			}
			int length3 = array.Length;
			num = (randomIndex = Random.Range(0, length3));
			goto IL_0168;
			IL_0168:
			FsmInt fsmInt = index;
			fsmInt.Value = num;
			int value = index.Value;
			object value2 = array.Get(value);
			storeValue.SetValue(value2);
		}

		[Token(Token = "0x6000834")]
		[Address(RVA = "0xA89A4C", Offset = "0xA89A4C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lastIndex = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayGetRandom()
		{
			lastIndex = -1;
		}
	}
}
