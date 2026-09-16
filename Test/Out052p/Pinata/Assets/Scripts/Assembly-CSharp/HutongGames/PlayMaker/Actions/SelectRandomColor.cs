using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754C6C", Offset = "0x754C6C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754C6C", Offset = "0x754C6C")]
	[Token(Token = "0x20001A4")]
	public class SelectRandomColor : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7AD0B0", Offset = "0x7AD0B0")]
		[Token(Token = "0x400132D")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor[] colors;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AD118", Offset = "0x7AD118")]
		[Token(Token = "0x400132E")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] weights;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD130", Offset = "0x7AD130")]
		[Token(Token = "0x400132F")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor storeColor;

		[Token(Token = "0x60008EB")]
		[Address(RVA = "0xB26350", Offset = "0xB26350", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ECB0E0]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225DD]) = v40;\nL_0018:\n\t// 24 NewArr v45 @ X0_v3 (HutongGames.PlayMaker.FsmColor[]), typeof(HutongGames.PlayMaker.FsmColor[]), 3\n\tthis.colors = v45;\n\t// 30 NewArr v50 @ X0_v5 (HutongGames.PlayMaker.FsmFloat[]), typeof(HutongGames.PlayMaker.FsmFloat[]), 3\n\tv54 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tv57 = v54 == 0;\n\tif (v57) goto L_002F;\n\t// 43 IsInst v104 @ X0_v29, typeof(HutongGames.PlayMaker.FsmFloat), v54 @ X0_v7 (HutongGames.PlayMaker.FsmFloat)\nL_002F:\n\tv111 = v50.Length == 0;\n\tif (v111) goto L_006F;\n\tv50[0] = v54;\n\tv114 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tv209 = v114 == 0;\n\tif (v209) goto L_003F;\n\t// 59 IsInst v200 @ X0_v27, typeof(HutongGames.PlayMaker.FsmFloat), v114 @ X0_v19 (HutongGames.PlayMaker.FsmFloat)\nL_003F:\n\tv214 = v50.Length < 1;\n\tv140 = ~v214;\n\tv137 = v50.Length - 1;\n\tv131 = v137 == 0;\n\tv215 = ~v140;\n\tv116 = v215 | v131;\n\tif (v116) goto L_006F;\n\tv50[1] = v114;\n\tv217 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tv218 = v217 == 0;\n\tif (v218) goto L_0059;\n\t// 85 IsInst v201 @ X0_v25, typeof(HutongGames.PlayMaker.FsmFloat), v217 @ X0_v22 (HutongGames.PlayMaker.FsmFloat)\nL_0059:\n\tv221 = v50.Length < 2;\n\tv141 = ~v221;\n\tv138 = v50.Length - 2;\n\tv132 = v138 == 0;\n\tv222 = ~v141;\n\tv117 = v222 | v132;\n\tif (v117) goto L_006F;\n\tv50[2] = v217;\n\tthis.weights = v50;\n\tthis.storeColor = 0;\n\treturn;\nL_006F:\n\tv159 = new System.IndexOutOfRangeException();\n\tgoto L_0074;\n\tv208 = new System.ArrayTypeMismatchException();\nL_0074:\n\tthrow v211;\n\tthrow System.NullReferenceException;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_00ce: Expected O, but got I4
			//IL_017e: Expected O, but got I4
			FsmColor[] array = new FsmColor[3];
			colors = array;
			FsmFloat[] array2 = new FsmFloat[3];
			FsmFloat fsmFloat = 1f;
			if (fsmFloat != null)
			{
				object obj = fsmFloat as FsmFloat;
			}
			if (array2.Length != 0)
			{
				array2[0] = fsmFloat;
				FsmFloat fsmFloat2 = 1f;
				if (fsmFloat2 != null)
				{
					object obj2 = fsmFloat2 as FsmFloat;
				}
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj3 = array2.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = fsmFloat2;
					FsmFloat fsmFloat3 = 1f;
					if (fsmFloat3 != null)
					{
						object obj4 = fsmFloat3 as FsmFloat;
					}
					bool flag5 = array2.Length < 2;
					bool flag6 = !flag5;
					object obj5 = array2.Length - 2;
					bool flag7 = obj5 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array2[2] = fsmFloat3;
						weights = array2;
						storeColor = null;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008EC")]
		[Address(RVA = "0xB26494", Offset = "0xB26494", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SelectRandomColor::DoSelectRandomColor(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSelectRandomColor();
			Finish();
		}

		[Token(Token = "0x60008ED")]
		[Address(RVA = "0xB264BC", Offset = "0xB264BC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.colors;\n\tv11 = this.colors == 0;\n\tif (v11) goto L_0038;\n\tv13 = v10.Length == 0;\n\tif (v13) goto L_0038;\n\tv61 = this.storeColor == 0;\n\tif (v61) goto L_0038;\n\tv58 = HutongGames.PlayMaker.ActionHelpers::GetRandomWeightedIndex(this.weights);\n\tv62 = v58 + 1;\n\tv49 = v62 == 0;\n\tif (v49) goto L_0038;\n\tv106 = this.colors;\n\tv109 = v58 < v106.Length;\n\tv43 = ~v109;\n\tif (v43) goto L_003B;\n\tv123 = v106[v58 @ X0_v3 (System.Int32)];\n\tv36 = this.storeColor;\n\tv36.value.r = v123.value;\n\tv36.value.g = v123.value.g;\n\tv36.value.a = v123.value.a;\nL_0038:\n\treturn;\n\tv125 = new System.NullReferenceException();\nL_003B:\n\tv141 = new System.IndexOutOfRangeException();\n\tthrow v141;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSelectRandomColor()
		{
			FsmColor[] array = colors;
			if (colors == null || array.Length == 0 || storeColor == null)
			{
				return;
			}
			int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(weights);
			if (randomWeightedIndex + 1 != 0)
			{
				FsmColor[] array2 = colors;
				if (randomWeightedIndex >= array2.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				FsmColor fsmColor = array2[randomWeightedIndex];
				FsmColor fsmColor2 = storeColor;
				fsmColor2.value.r = fsmColor.value.r;
				fsmColor2.value.g = fsmColor.value.g;
				fsmColor2.value.a = fsmColor.value.a;
			}
		}

		[Token(Token = "0x60008EE")]
		[Address(RVA = "0xB2655C", Offset = "0xB2655C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SelectRandomColor()
		{
		}
	}
}
