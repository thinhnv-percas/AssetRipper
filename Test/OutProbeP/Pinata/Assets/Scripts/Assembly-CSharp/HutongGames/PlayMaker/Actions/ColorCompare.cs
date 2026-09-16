using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758764", Offset = "0x758764")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758764", Offset = "0x758764")]
	[Token(Token = "0x200025C")]
	public class ColorCompare : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B56B0", Offset = "0x7B56B0")]
		[Token(Token = "0x40015F6")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor color1;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B56FC", Offset = "0x7B56FC")]
		[Token(Token = "0x40015F7")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor color2;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5748", Offset = "0x7B5748")]
		[Token(Token = "0x40015F8")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat tolerance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5794", Offset = "0x7B5794")]
		[Token(Token = "0x40015F9")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent equal;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B57CC", Offset = "0x7B57CC")]
		[Token(Token = "0x40015FA")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent notEqual;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5804", Offset = "0x7B5804")]
		[Token(Token = "0x40015FB")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000BC6")]
		[Address(RVA = "0xA909BC", Offset = "0xA909BC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_white();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.color1 = v17;\n\tv19 = UnityEngine.Color::get_white();\n\tv25 = HutongGames.PlayMaker.FsmColor::op_Implicit(v19);\n\tthis.color2 = v25;\n\tv28 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.everyFrame = 0;\n\tthis.equal = 0;\n\tthis.notEqual = 0;\n\tthis.tolerance = v28;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			Color white = Color.white;
			FsmColor fsmColor = white;
			color1 = fsmColor;
			Color white2 = Color.white;
			FsmColor fsmColor2 = white2;
			color2 = fsmColor2;
			FsmFloat fsmFloat = 0f;
			everyFrame = false;
			equal = null;
			notEqual = null;
			tolerance = fsmFloat;
		}

		[Token(Token = "0x6000BC7")]
		[Address(RVA = "0xA90A18", Offset = "0xA90A18", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ColorCompare::DoCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BC8")]
		[Address(RVA = "0xA90C0C", Offset = "0xA90C0C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ColorCompare::DoCompare(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoCompare();
		}

		[Token(Token = "0x6000BC9")]
		[Address(RVA = "0xA90A54", Offset = "0xA90A54", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC6AA0]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20221F0]) = v42;\nL_0015:\n\tv43 = this.color1;\n\tv45 = this.color2;\n\tgoto L_002C;\n\tv207 = *([v138 @ X0_v6+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\t// 39 ConditionalJump @b9, v209 @ TEMP_v41\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v138, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv213 = v43.value - v45.value;\n\tv110 = UnityEngine.Mathf::Abs(v213);\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.tolerance);\n\tv54 = v110 > v102;\n\tif (v54) goto L_00AF;\n\tv130 = this.color1;\n\tv114 = this.color2;\n\tgoto L_0052;\n\tv272 = *([v265 @ X0_v12+E0]);\n\tv273 = v272 == 0;\n\tv274 = ~v273;\n\t// 77 ConditionalJump @b18, v274 @ TEMP_v39\n\tv276 = \"il2cpp_codegen_runtime_class_init\"(v265, v98, v26, v27, v28, v29, v30, v31, v102, v33, v34, v35, v36, v37, v38, v39);\nL_0052:\n\tv278 = v130.value.g - v114.value.g;\n\tv111 = UnityEngine.Mathf::Abs(v278);\n\tv103 = HutongGames.PlayMaker.FsmFloat::get_Value(this.tolerance);\n\tv55 = v111 > v103;\n\tif (v55) goto L_00AF;\n\tv131 = this.color1;\n\tv115 = this.color2;\n\tgoto L_0078;\n\tv285 = *([v281 @ X0_v15+E0]);\n\tv286 = v285 == 0;\n\tv287 = ~v286;\n\t// 115 ConditionalJump @b27, v287 @ TEMP_v37\n\tv289 = \"il2cpp_codegen_runtime_class_init\"(v281, v99, v26, v27, v28, v29, v30, v31, v103, v33, v34, v35, v36, v37, v38, v39);\nL_0078:\n\tv291 = v131.value.b - v115.value.b;\n\tv112 = UnityEngine.Mathf::Abs(v291);\n\tv104 = HutongGames.PlayMaker.FsmFloat::get_Value(this.tolerance);\n\tv56 = v112 > v104;\n\tif (v56) goto L_00AF;\n\tv132 = this.color1;\n\tv116 = this.color2;\n\tgoto L_009E;\n\tv298 = *([v294 @ X0_v18+E0]);\n\tv299 = v298 == 0;\n\tv300 = ~v299;\n\t// 153 ConditionalJump @b36, v300 @ TEMP_v35\n\tv302 = \"il2cpp_codegen_runtime_class_init\"(v294, v100, v26, v27, v28, v29, v30, v31, v104, v33, v34, v35, v36, v37, v38, v39);\nL_009E:\n\tv304 = v132.value.a - v116.value.a;\n\tv185 = UnityEngine.Mathf::Abs(v304);\n\tv176 = HutongGames.PlayMaker.FsmFloat::get_Value(this.tolerance);\n\tv146 = v185 <= v176;\n\tif (v146) goto L_00BD;\nL_00AF:\n\tv249 = this.fsm;\n\tv239 = this.notEqual;\nL_00BB:\n\tHutongGames.PlayMaker.Fsm::Event(v249, v239);\n\treturn;\nL_00BD:\n\tv249 = this.fsm;\n\tv239 = this.equal;\n\tgoto L_00BB;\n\tthrow System.NullReferenceException;\n\treturn;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCompare()
		{
			FsmColor fsmColor = color1;
			FsmColor fsmColor2 = color2;
			float f = fsmColor.value.r - fsmColor2.value.r;
			float num = Mathf.Abs(f);
			float value = tolerance.Value;
			Fsm fsm;
			FsmEvent fsmEvent;
			if (!(num > value))
			{
				FsmColor fsmColor3 = color1;
				FsmColor fsmColor4 = color2;
				float f2 = fsmColor3.value.g - fsmColor4.value.g;
				float num2 = Mathf.Abs(f2);
				float value2 = tolerance.Value;
				if (!(num2 > value2))
				{
					FsmColor fsmColor5 = color1;
					FsmColor fsmColor6 = color2;
					float f3 = fsmColor5.value.b - fsmColor6.value.b;
					float num3 = Mathf.Abs(f3);
					float value3 = tolerance.Value;
					if (!(num3 > value3))
					{
						FsmColor fsmColor7 = color1;
						FsmColor fsmColor8 = color2;
						float f4 = fsmColor7.value.a - fsmColor8.value.a;
						float num4 = Mathf.Abs(f4);
						float value4 = tolerance.Value;
						if (!(num4 > value4))
						{
							fsm = Fsm;
							fsmEvent = equal;
							goto IL_0258;
						}
					}
				}
			}
			fsm = Fsm;
			fsmEvent = notEqual;
			goto IL_0258;
			IL_0258:
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000BCA")]
		[Address(RVA = "0xA90C10", Offset = "0xA90C10", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EF3C20]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221F1]) = v40;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tv57 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.equal);\n\tv59 = v57 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0034;\n\tv76 = *([v60 @ X0_v9+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0034;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v60, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv68 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.notEqual);\n\tv70 = v68 == 0;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\treturn *([v87 @ X8_v5 (System.String)]);\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(equal) && FsmEvent.IsNullOrEmpty(notEqual))
			{
				return "Action sends no events!";
			}
			return "";
		}

		[Token(Token = "0x6000BCB")]
		[Address(RVA = "0xA90CD0", Offset = "0xA90CD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorCompare()
		{
		}
	}
}
