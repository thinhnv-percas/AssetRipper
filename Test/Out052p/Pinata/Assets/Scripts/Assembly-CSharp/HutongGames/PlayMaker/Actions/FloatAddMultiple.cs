using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759488", Offset = "0x759488")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759488", Offset = "0x759488")]
	[Token(Token = "0x2000282")]
	public class FloatAddMultiple : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B80C8", Offset = "0x7B80C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B80C8", Offset = "0x7B80C8")]
		[Token(Token = "0x40016B1")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat[] floatVariables;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B8118", Offset = "0x7B8118")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8118", Offset = "0x7B8118")]
		[Token(Token = "0x40016B2")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat addTo;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8178", Offset = "0x7B8178")]
		[Token(Token = "0x40016B3")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000C7D")]
		[Address(RVA = "0xB75DB4", Offset = "0xB75DB4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.floatVariables = 0;\n\tthis.addTo = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			floatVariables = null;
			addTo = null;
		}

		[Token(Token = "0x6000C7E")]
		[Address(RVA = "0xB75DC0", Offset = "0xB75DC0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatAddMultiple::DoFloatAdd(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFloatAdd();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C7F")]
		[Address(RVA = "0xB75EB0", Offset = "0xB75EB0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatAddMultiple::DoFloatAdd(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFloatAdd();
		}

		[Token(Token = "0x6000C80")]
		[Address(RVA = "0xB75DFC", Offset = "0xB75DFC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv118 = this.floatVariables;\nL_0017:\n\tv20 = v83 >= v118.Length;\n\tif (v20) goto L_0045;\n\tv80 = this.addTo;\n\tv69 = HutongGames.PlayMaker.FsmFloat::get_Value(this.addTo);\n\tv91 = this.floatVariables;\n\tv174 = v83 < v91.Length;\n\tv55 = ~v174;\n\tif (v55) goto L_0046;\n\tv178 = HutongGames.PlayMaker.FsmFloat::get_Value(v91[v83 @ X21_v5 (System.Int32)]);\n\tv66 = v69 + v178;\n\tv80.value = v66;\n\tv118 = this.floatVariables;\n\tv83 = v83 + 1;\n\tv183 = this.floatVariables == 0;\n\tv85 = ~v183;\n\tif (v85) goto L_0017;\n\tthrow System.NullReferenceException;\nL_0045:\n\treturn;\nL_0046:\n\tv177 = new System.IndexOutOfRangeException();\n\tthrow v177;\n\tthrow System.NullReferenceException;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFloatAdd()
		{
			FsmFloat[] array = floatVariables;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					FsmFloat fsmFloat = addTo;
					float value = addTo.Value;
					FsmFloat[] array2 = floatVariables;
					if (num >= array2.Length)
					{
						break;
					}
					float value2 = array2[num].Value;
					float value3 = value + value2;
					fsmFloat.Value = value3;
					array = floatVariables;
					num++;
					if (floatVariables == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000C81")]
		[Address(RVA = "0xB75EB4", Offset = "0xB75EB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatAddMultiple()
		{
		}
	}
}
