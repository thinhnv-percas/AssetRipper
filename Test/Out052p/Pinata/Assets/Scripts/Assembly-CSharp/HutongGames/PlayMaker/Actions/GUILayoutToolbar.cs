using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7579B8", Offset = "0x7579B8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7579B8", Offset = "0x7579B8")]
	[Token(Token = "0x2000232")]
	public class GUILayoutToolbar : GUILayoutAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B2EEC", Offset = "0x7B2EEC")]
		[Token(Token = "0x4001545")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt numButtons;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B2F24", Offset = "0x7B2F24")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B2F24", Offset = "0x7B2F24")]
		[Token(Token = "0x4001546")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt selectedButton;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B2F74", Offset = "0x7B2F74")]
		[Token(Token = "0x4001547")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent[] buttonEventsArray;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B2FAC", Offset = "0x7B2FAC")]
		[Token(Token = "0x4001548")]
		[FieldOffset(Offset = "0x78")]
		public FsmTexture[] imagesArray;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B2FE4", Offset = "0x7B2FE4")]
		[Token(Token = "0x4001549")]
		[FieldOffset(Offset = "0x80")]
		public FsmString[] textsArray;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B301C", Offset = "0x7B301C")]
		[Token(Token = "0x400154A")]
		[FieldOffset(Offset = "0x88")]
		public FsmString[] tooltipsArray;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3054", Offset = "0x7B3054")]
		[Token(Token = "0x400154B")]
		[FieldOffset(Offset = "0x90")]
		public FsmString style;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B308C", Offset = "0x7B308C")]
		[Token(Token = "0x400154C")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x400154D")]
		[FieldOffset(Offset = "0xA0")]
		private GUIContent[] contents;

		[Token(Token = "0x17000062")]
		public GUIContent[] Contents
		{
			[Token(Token = "0x6000B0C")]
			[Address(RVA = "0xB7BCEC", Offset = "0xB7BCEC", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.contents;\n\tv11 = this.contents == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0011;\n\tHutongGames.PlayMaker.Actions.GUILayoutToolbar::SetButtonsContent(this);\n\treturnVal1 = this.contents;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GUIContent[] result = contents;
				if (contents == null)
				{
					SetButtonsContent();
					result = contents;
				}
				return result;
			}
		}

		[Token(Token = "0x6000B0D")]
		[Address(RVA = "0xB7BD1C", Offset = "0xB7BD1C", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA7AC8]);\n\tv25 = *([v24 @ X8_v35]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202296E]) = v44;\nL_0017:\n\tv46 = this.contents == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0026;\n\tv60 = HutongGames.PlayMaker.FsmInt::get_Value(this.numButtons);\n\t// 36 NewArr v53 @ X0_v39 (UnityEngine.GUIContent[]), typeof(UnityEngine.GUIContent[]), v60 @ X0_v37 (System.Int32)\n\tthis.contents = v53;\nL_0026:\n\tv364 = this.numButtons;\nL_002D:\n\tv277 = HutongGames.PlayMaker.FsmInt::get_Value(v364);\n\tv210 = v261 >= v277;\n\tif (v210) goto L_005D;\n\tv208 = this.contents;\n\tv275 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v275);\n\tv436 = v275 == 0;\n\tif (v436) goto L_0056;\n\t// 70 IsInst v347 @ X0_v29, typeof(UnityEngine.GUIContent), v275 @ X0_v25 (UnityEngine.GUIContent)\n\tv349 = v347 == 0;\n\tif (v349) goto L_0129;\nL_0056:\n\tv208[v261 @ X21_v5 (System.Int32)] = v275;\n\tv364 = this.numButtons;\n\tv261 = v261 + 1;\n\tv453 = this.numButtons == 0;\n\tv289 = ~v453;\n\tif (v289) goto L_002D;\n\tgoto L_011A;\nL_005D:\n\tv306 = this.imagesArray;\nL_006B:\n\tv96 = v149 >= v306.Length;\n\tif (v96) goto L_009C;\n\tv81 = this.contents;\n\tv279 = HutongGames.PlayMaker.FsmTexture::get_Value(v306[v149 @ X21_v8 (System.Int32)]);\n\tv263 = v149 + 1;\n\tUnityEngine.GUIContent::set_image(v81[v149 @ X21_v8 (System.Int32)], v279);\n\tv306 = this.imagesArray;\n\tv499 = this.imagesArray == 0;\n\tv293 = ~v499;\n\tif (v293) goto L_006B;\n\tgoto L_011A;\nL_009C:\n\tv310 = this.textsArray;\nL_00AA:\n\tv97 = v150 >= v310.Length;\n\tif (v97) goto L_00DB;\n\tv82 = this.contents;\n\tv282 = HutongGames.PlayMaker.FsmString::get_Value(v310[v150 @ X21_v10 (System.Int32)]);\n\tv264 = v150 + 1;\n\tUnityEngine.GUIContent::set_text(v82[v150 @ X21_v10 (System.Int32)], v282);\n\tv310 = this.textsArray;\n\tv503 = this.textsArray == 0;\n\tv297 = ~v503;\n\tif (v297) goto L_00AA;\n\tgoto L_011A;\nL_00DB:\n\tv314 = this.tooltipsArray;\nL_00E9:\n\tv98 = v151 >= v314.Length;\n\tif (v98) goto L_0123;\n\tv83 = this.contents;\n\tv285 = HutongGames.PlayMaker.FsmString::get_Value(v314[v151 @ X21_v12 (System.Int32)]);\n\tv260 = v151 + 1;\n\tUnityEngine.GUIContent::set_tooltip(v83[v151 @ X21_v12 (System.Int32)], v285);\n\tv314 = this.tooltipsArray;\n\tv505 = this.tooltipsArray == 0;\n\tv287 = ~v505;\n\tif (v287) goto L_00E9;\nL_011A:\n\tthrow System.NullReferenceException;\nL_0123:\n\treturn;\n\tv418 = new System.IndexOutOfRangeException();\nL_0127:\n\tv161 = new System.TypeLoadException();\n\tv180 = new System.NullReferenceException();\nL_0129:\n\tv353 = new System.ArrayTypeMismatchException();\n\tgoto L_0127;\n\treturn;\n// 226 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetButtonsContent()
		{
			if (contents == null)
			{
				int value = numButtons.Value;
				GUIContent[] array = new GUIContent[value];
				contents = array;
			}
			FsmInt fsmInt = numButtons;
			int num = 0;
			while (true)
			{
				int value2 = fsmInt.Value;
				if (num < value2)
				{
					GUIContent[] array2 = contents;
					GUIContent gUIContent = new GUIContent();
					if (gUIContent != null)
					{
						object obj = gUIContent as GUIContent;
						if (obj == null)
						{
							break;
						}
					}
					array2[num] = gUIContent;
					fsmInt = numButtons;
					num++;
					if (numButtons != null)
					{
						continue;
					}
				}
				else
				{
					FsmTexture[] array3 = imagesArray;
					int num2 = 0;
					bool flag2;
					do
					{
						if (num2 < array3.Length)
						{
							GUIContent[] array4 = contents;
							Texture value3 = array3[num2].Value;
							int num3 = num2 + 1;
							array4[num2].image = value3;
							array3 = imagesArray;
							bool flag = imagesArray == null;
							flag2 = !flag;
							num2 = num3;
							continue;
						}
						FsmString[] array5 = textsArray;
						int num4 = 0;
						bool flag4;
						do
						{
							if (num4 < array5.Length)
							{
								GUIContent[] array6 = contents;
								string value4 = array5[num4].Value;
								int num5 = num4 + 1;
								array6[num4].text = value4;
								array5 = textsArray;
								bool flag3 = textsArray == null;
								flag4 = !flag3;
								num4 = num5;
								continue;
							}
							FsmString[] array7 = tooltipsArray;
							int num6 = 0;
							bool flag6;
							do
							{
								if (num6 < array7.Length)
								{
									GUIContent[] array8 = contents;
									string value5 = array7[num6].Value;
									int num7 = num6 + 1;
									array8[num6].tooltip = value5;
									array7 = tooltipsArray;
									bool flag5 = tooltipsArray == null;
									flag6 = !flag5;
									num6 = num7;
									continue;
								}
								return;
							}
							while (flag6);
							break;
						}
						while (flag4);
						break;
					}
					while (flag2);
				}
				throw new NullReferenceException();
			}
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
				NullReferenceException ex3 = new NullReferenceException();
			}
		}

		[Token(Token = "0x6000B0E")]
		[Address(RVA = "0xB7BFA4", Offset = "0xB7BFA4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF9778]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202296F]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tv42 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.numButtons = v42;\n\tthis.selectedButton = 0;\n\t// 30 NewArr v47 @ X0_v6 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 0\n\tthis.buttonEventsArray = v47;\n\t// 36 NewArr v52 @ X0_v8 (HutongGames.PlayMaker.FsmTexture[]), typeof(HutongGames.PlayMaker.FsmTexture[]), 0\n\tthis.imagesArray = v52;\n\t// 42 NewArr v57 @ X0_v10 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 0\n\tthis.tooltipsArray = v57;\n\tv62 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Button\");\n\tthis.style = v62;\n\tthis.everyFrame = 0;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmInt fsmInt = 0;
			numButtons = fsmInt;
			selectedButton = null;
			FsmEvent[] array = new FsmEvent[0];
			buttonEventsArray = array;
			FsmTexture[] array2 = new FsmTexture[0];
			imagesArray = array2;
			FsmString[] array3 = new FsmString[0];
			tooltipsArray = array3;
			FsmString fsmString = "Button";
			style = fsmString;
			everyFrame = false;
		}

		[Token(Token = "0x6000B0F")]
		[Address(RVA = "0xB7C060", Offset = "0xB7C060", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.Actions.GUILayoutToolbar::ErrorCheck(this);\n\tv32 = System.String::IsNullOrEmpty(v15);\n\tv34 = v32 == 0;\n\tif (v34) goto L_001A;\n\treturn;\nL_001A:\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v15);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string text = ErrorCheck();
			if (!string.IsNullOrEmpty(text))
			{
				LogError(text);
				Finish();
			}
		}

		[Token(Token = "0x6000B10")]
		[Address(RVA = "0xB7C0C0", Offset = "0xB7C0C0", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1F04798]);\n\tv29 = *([v28 @ X8_v21]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022970]) = v48;\nL_0019:\n\tv50 = ~this.everyFrame;\n\tif (v50) goto L_0023;\n\tHutongGames.PlayMaker.Actions.GUILayoutToolbar::SetButtonsContent(this);\nL_0023:\n\tgoto L_002A;\n\tv59 = *([v55 @ X0_v3+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002A;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_002A:\n\tv67 = UnityEngine.GUI::get_changed();\n\tUnityEngine.GUI::set_changed(0);\n\tv71 = this.selectedButton;\n\tv75 = HutongGames.PlayMaker.FsmInt::get_Value(this.selectedButton);\n\tv117 = this.contents;\n\tv136 = this.contents == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0041;\n\tHutongGames.PlayMaker.Actions.GUILayoutToolbar::SetButtonsContent(this);\n\tv117 = this.contents;\nL_0041:\n\tv204 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0052;\n\tv214 = *([v130 @ X8_v11+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_0052;\n\tv287 = v130;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v287, v203, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0052:\n\tv222 = UnityEngine.GUIStyle::op_Implicit(v204);\n\tv289 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tv291 = UnityEngine.GUILayout::Toolbar(v75, v117, v222, v289);\n\tv71.value = v291;\n\tv293 = UnityEngine.GUI::get_changed();\n\tv295 = v293 == 0;\n\tif (v295) goto L_00A0;\n\tv122 = HutongGames.PlayMaker.FsmInt::get_Value(this.selectedButton);\n\tv133 = this.buttonEventsArray;\n\tv78 = v122 >= v133.Length;\n\tif (v78) goto L_00BE;\n\tv123 = HutongGames.PlayMaker.FsmInt::get_Value(this.selectedButton);\n\tv306 = v123 < v133.Length;\n\tv102 = ~v306;\n\tif (v102) goto L_00C1;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v133[v123 @ X0_v36 (System.Int32)]);\n\tUnityEngine.GUIUtility::ExitGUI();\n\treturn;\nL_00A0:\n\tgoto L_00B2;\n\tv300 = *([v296 @ X0_v29+E0]);\n\tv301 = v300 == 0;\n\tv302 = ~v301;\n\tif (v302) goto L_00B2;\n\tv304 = \"il2cpp_codegen_runtime_class_init\"(v296, v163, v106, v108, v104, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00B2:\n\tUnityEngine.GUI::set_changed(v67);\n\treturn;\nL_00BE:\n\treturn;\n\tv176 = new System.NullReferenceException();\nL_00C1:\n\tv202 = new System.IndexOutOfRangeException();\n\tthrow v202;\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			if (everyFrame)
			{
				SetButtonsContent();
			}
			bool changed = GUI.changed;
			GUI.changed = false;
			FsmInt fsmInt = selectedButton;
			int value = selectedButton.Value;
			GUIContent[] array = contents;
			if (contents == null)
			{
				SetButtonsContent();
				array = contents;
			}
			string value2 = style.Value;
			GUIStyle gUIStyle = value2;
			GUILayoutOption[] array2 = base.LayoutOptions;
			int value3 = GUILayout.Toolbar(value, array, gUIStyle, array2);
			fsmInt.Value = value3;
			if (GUI.changed)
			{
				int value4 = selectedButton.Value;
				FsmEvent[] array3 = buttonEventsArray;
				if (value4 < array3.Length)
				{
					int value5 = selectedButton.Value;
					if (value5 >= array3.Length)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					Fsm.Event(array3[value5]);
					GUIUtility.ExitGUI();
				}
			}
			else
			{
				GUI.changed = changed;
			}
		}

		[Token(Token = "0x6000B11")]
		[Address(RVA = "0xB7C2CC", Offset = "0xB7C2CC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F095D8]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022971]) = v40;\nL_0014:\n\tv41 = this.imagesArray;\n\tv47 = v41.Length == 0;\n\tif (v47) goto L_0034;\n\tv118 = HutongGames.PlayMaker.FsmInt::get_Value(this.numButtons);\n\tv111 = v118 == v41.Length;\n\tif (v111) goto L_0034;\n\tv117 = System.String::Concat(\"\", \"Images array doesn't match NumButtons.\\n\");\nL_0034:\n\tv49 = this.textsArray;\n\tv146 = v49.Length == 0;\n\tif (v146) goto L_0051;\n\tv160 = HutongGames.PlayMaker.FsmInt::get_Value(this.numButtons);\n\tv153 = v160 == v49.Length;\n\tif (v153) goto L_0051;\n\tv159 = System.String::Concat(v102, \"Texts array doesn't match NumButtons.\\n\");\nL_0051:\n\tv50 = this.tooltipsArray;\n\tv224 = v50.Length == 0;\n\tif (v224) goto L_006F;\n\tv228 = HutongGames.PlayMaker.FsmInt::get_Value(this.numButtons);\n\tv173 = v228 != v50.Length;\n\tif (v173) goto L_007B;\nL_006F:\n\treturn v102;\nL_007B:\n\treturnVal3 = System.String::Concat(v102, \"Tooltips array doesn't match NumButtons.\\n\");\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			FsmTexture[] array = imagesArray;
			bool flag = array.Length == 0;
			string text = "";
			if (!flag)
			{
				int value = numButtons.Value;
				bool flag2 = value == array.Length;
				text = "";
				if (!flag2)
				{
					string text2 = "" + "Images array doesn't match NumButtons.\n";
					text = text2;
				}
			}
			FsmString[] array2 = textsArray;
			if (array2.Length != 0)
			{
				int value2 = numButtons.Value;
				if (value2 != array2.Length)
				{
					string text3 = text + "Texts array doesn't match NumButtons.\n";
					text = text3;
				}
			}
			FsmString[] array3 = tooltipsArray;
			if (array3.Length != 0)
			{
				int value3 = numButtons.Value;
				if (value3 != array3.Length)
				{
					return text + "Tooltips array doesn't match NumButtons.\n";
				}
			}
			return text;
		}

		[Token(Token = "0x6000B12")]
		[Address(RVA = "0xB7C40C", Offset = "0xB7C40C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutToolbar()
		{
		}
	}
}
