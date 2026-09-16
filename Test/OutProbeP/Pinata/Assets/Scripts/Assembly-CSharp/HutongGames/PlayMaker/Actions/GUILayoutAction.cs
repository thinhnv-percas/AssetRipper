using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7570C0", Offset = "0x7570C0")]
	[Token(Token = "0x2000215")]
	public abstract class GUILayoutAction : FsmStateAction
	{
		[Token(Token = "0x40014E3")]
		[FieldOffset(Offset = "0x50")]
		public LayoutOption[] layoutOptions;

		[Token(Token = "0x40014E4")]
		[FieldOffset(Offset = "0x58")]
		private GUILayoutOption[] options;

		[Token(Token = "0x17000061")]
		public GUILayoutOption[] LayoutOptions
		{
			[Token(Token = "0x6000AB5")]
			[Address(RVA = "0xB78B98", Offset = "0xB78B98", Length = "0x118")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EF4108]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022945]) = v44;\nL_0016:\n\tv116 = this.options;\n\tv46 = this.options == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_006F;\n\tv48 = this.layoutOptions;\n\t// 33 NewArr v130 @ X0_v9 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), v48.Length\n\tv114 = this.layoutOptions;\n\tthis.options = v130;\nL_0028:\n\tv116 = this.options;\n\tv52 = v98 >= v114.Length;\n\tif (v52) goto L_006F;\n\tv237 = v98 < v114.Length;\n\tv162 = ~v237;\n\tif (v162) goto L_0070;\n\tv171 = HutongGames.PlayMaker.LayoutOption::GetGUILayoutOption(v114[v98 @ X22_v6 (System.Int32)]);\n\tv262 = v171 == 0;\n\tif (v262) goto L_0052;\n\t// 78 IsInst v264 @ X0_v19, typeof(UnityEngine.GUILayoutOption), v171 @ X0_v16 (UnityEngine.GUILayoutOption)\nL_0052:\n\tv266 = v98 < v116.Length;\n\tv161 = ~v266;\n\tif (v161) goto L_0070;\n\tv116[v98 @ X22_v6 (System.Int32)] = v171;\n\tv114 = this.layoutOptions;\n\tv98 = v98 + 1;\n\tv268 = this.layoutOptions == 0;\n\tv173 = ~v268;\n\tif (v173) goto L_0028;\n\tthrow System.NullReferenceException;\nL_006F:\n\treturn v116;\nL_0070:\n\tv255 = new System.IndexOutOfRangeException();\n\tgoto L_0075;\n\tv259 = new System.ArrayTypeMismatchException();\nL_0075:\n\tthrow v258;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GUILayoutOption[] array = options;
				if (options == null)
				{
					LayoutOption[] array2 = layoutOptions;
					GUILayoutOption[] array3 = new GUILayoutOption[array2.Length];
					LayoutOption[] array4 = layoutOptions;
					options = array3;
					int num = 0;
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					while (true)
					{
						array = options;
						if (num >= array4.Length)
						{
							break;
						}
						if (num < array4.Length)
						{
							GUILayoutOption gUILayoutOption = array4[num].GetGUILayoutOption();
							if (gUILayoutOption != null)
							{
								object obj = gUILayoutOption as GUILayoutOption;
							}
							if (num < array.Length)
							{
								array[num] = gUILayoutOption;
								array4 = layoutOptions;
								num++;
								if (layoutOptions == null)
								{
									throw new NullReferenceException();
								}
								continue;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex2;
					}
				}
				return array;
			}
		}

		[Token(Token = "0x6000AB6")]
		[Address(RVA = "0xB78CB0", Offset = "0xB78CB0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC8BE0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022946]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.LayoutOption[]), typeof(HutongGames.PlayMaker.LayoutOption[]), 0\n\tthis.layoutOptions = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			LayoutOption[] array = new LayoutOption[0];
			layoutOptions = array;
		}

		[Token(Token = "0x6000AB7")]
		[Address(RVA = "0xB78D08", Offset = "0xB78D08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal GUILayoutAction()
		{
		}
	}
}
