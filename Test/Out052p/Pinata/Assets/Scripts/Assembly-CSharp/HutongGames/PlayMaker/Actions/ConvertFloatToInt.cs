using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754EEC", Offset = "0x754EEC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754EEC", Offset = "0x754EEC")]
	[Token(Token = "0x20001AD")]
	public class ConvertFloatToInt : FsmStateAction
	{
		[Token(Token = "0x2000484")]
		public enum FloatRounding
		{
			[Token(Token = "0x400215B")]
			RoundDown = 0,
			[Token(Token = "0x400215C")]
			RoundUp = 1,
			[Token(Token = "0x400215D")]
			Nearest = 2
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD8EC", Offset = "0x7AD8EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD8EC", Offset = "0x7AD8EC")]
		[Token(Token = "0x4001352")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD94C", Offset = "0x7AD94C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD94C", Offset = "0x7AD94C")]
		[Token(Token = "0x4001353")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt intVariable;

		[Token(Token = "0x4001354")]
		[FieldOffset(Offset = "0x60")]
		public FloatRounding rounding;

		[Token(Token = "0x4001355")]
		[FieldOffset(Offset = "0x64")]
		public bool everyFrame;

		[Token(Token = "0x600091F")]
		[Address(RVA = "0xA924CC", Offset = "0xA924CC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.floatVariable = 0;\n\tthis.intVariable = 0;\n\tthis.rounding = 2;\n\tthis.everyFrame = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			floatVariable = null;
			intVariable = null;
			rounding = FloatRounding.Nearest;
			everyFrame = false;
		}

		[Token(Token = "0x6000920")]
		[Address(RVA = "0xA924E0", Offset = "0xA924E0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertFloatToInt::DoConvertFloatToInt(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertFloatToInt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000921")]
		[Address(RVA = "0xA92668", Offset = "0xA92668", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertFloatToInt::DoConvertFloatToInt(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertFloatToInt();
		}

		[Token(Token = "0x6000922")]
		[Address(RVA = "0xA9251C", Offset = "0xA9251C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF71F8]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022202]) = v40;\nL_0015:\n\tv42 = this.rounding == 0;\n\tif (v42) goto L_004C;\n\tv47 = this.rounding == 1;\n\tif (v47) goto L_006A;\n\tv104 = this.rounding != 2;\n\tif (v104) goto L_0066;\n\tv178 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tgoto L_0041;\n\tv233 = *([v218 @ X0_v23+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_0041;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v218, v177, v24, v25, v26, v27, v28, v29, v178, v31, v32, v33, v34, v35, v36, v37);\nL_0041:\n\tv154 = UnityEngine.Mathf::RoundToInt(v178);\n\tv248 = this.intVariable == 0;\n\tv245 = ~v248;\n\tif (v245) goto L_005F;\nL_0046:\n\tthrow System.NullReferenceException;\nL_004C:\n\tv109 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tgoto L_005C;\n\tv205 = *([v172 @ X0_v8+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_005C;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v172, v108, v24, v25, v26, v27, v28, v29, v109, v31, v32, v33, v34, v35, v36, v37);\nL_005C:\n\tv154 = UnityEngine.Mathf::FloorToInt(v109);\nL_005F:\n\tv158.value = v154;\nL_0066:\n\treturn;\nL_006A:\n\tv158 = this.intVariable;\n\tv168 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tgoto L_007C;\n\tv222 = *([v201 @ X0_v17+E0]);\n\tv223 = v222 == 0;\n\tv224 = ~v223;\n\tif (v224) goto L_007C;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v201, v167, v24, v25, v26, v27, v28, v29, v168, v31, v32, v33, v34, v35, v36, v37);\nL_007C:\n\tv154 = UnityEngine.Mathf::CeilToInt(v168);\n\tv243 = this.intVariable == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_005F;\n\tgoto L_0046;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertFloatToInt()
		{
			int value2;
			FsmInt fsmInt;
			if (rounding != FloatRounding.RoundDown)
			{
				if (rounding != FloatRounding.RoundUp)
				{
					if (rounding != FloatRounding.Nearest)
					{
						return;
					}
					float value = floatVariable.Value;
					value2 = Mathf.RoundToInt(value);
					bool flag = intVariable == null;
					bool flag2 = !flag;
					fsmInt = intVariable;
					if (!flag2)
					{
						goto IL_009b;
					}
				}
				else
				{
					fsmInt = intVariable;
					float value3 = floatVariable.Value;
					value2 = Mathf.CeilToInt(value3);
					if (intVariable == null)
					{
						goto IL_009b;
					}
				}
			}
			else
			{
				float value4 = floatVariable.Value;
				value2 = Mathf.FloorToInt(value4);
				fsmInt = intVariable;
			}
			fsmInt.Value = value2;
			return;
			IL_009b:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000923")]
		[Address(RVA = "0xA9266C", Offset = "0xA9266C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertFloatToInt()
		{
		}
	}
}
