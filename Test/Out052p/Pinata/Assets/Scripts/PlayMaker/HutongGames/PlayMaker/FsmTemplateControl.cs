using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000046")]
	public class FsmTemplateControl
	{
		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x10")]
		public FsmTemplate fsmTemplate;

		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x18")]
		public FsmVarOverride[] fsmVarOverrides;

		[NonSerialized]
		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x28")]
		private Fsm runFsm;

		[Token(Token = "0x17000052")]
		public int ID
		{
			[CompilerGenerated]
			[Token(Token = "0x600013A")]
			[Address(RVA = "0xCB6230", Offset = "0xCB6230", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ID;
			}
			[CompilerGenerated]
			[Token(Token = "0x600013B")]
			[Address(RVA = "0xCB6238", Offset = "0xCB6238", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ID>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ID = value;
			}
		}

		[Token(Token = "0x17000053")]
		public Fsm RunFsm
		{
			[Token(Token = "0x600013C")]
			[Address(RVA = "0xCB6240", Offset = "0xCB6240", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.runFsm;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RunFsm;
			}
			[Token(Token = "0x600013D")]
			[Address(RVA = "0xCB6248", Offset = "0xCB6248", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.runFsm = value;\n\treturn;\n")]
			private set
			{
				runFsm = value;
			}
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0xCB6250", Offset = "0xCB6250", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFC958]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202365F]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmVarOverride[]), typeof(HutongGames.PlayMaker.FsmVarOverride[]), 0\n\tthis.fsmVarOverrides = v43;\n\tSystem.Object::.ctor(this);\n\t// 30 NewArr v48 @ X0_v6 (HutongGames.PlayMaker.FsmVarOverride[]), typeof(HutongGames.PlayMaker.FsmVarOverride[]), 0\n\tthis.fsmVarOverrides = v48;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTemplateControl()
		{
			FsmVarOverride[] array = new FsmVarOverride[0];
			fsmVarOverrides = array;
			FsmVarOverride[] array2 = new FsmVarOverride[0];
			fsmVarOverrides = array2;
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0xCB62C4", Offset = "0xCB62C4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EFF818]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023660]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (HutongGames.PlayMaker.FsmVarOverride[]), typeof(HutongGames.PlayMaker.FsmVarOverride[]), 0\n\tthis.fsmVarOverrides = v46;\n\tSystem.Object::.ctor(this);\n\tthis.fsmTemplate = source.fsmTemplate;\n\tv52 = HutongGames.PlayMaker.FsmTemplateControl::CopyOverrides(source);\n\tthis.fsmVarOverrides = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTemplateControl(FsmTemplateControl source)
		{
			FsmVarOverride[] array = new FsmVarOverride[0];
			fsmVarOverrides = array;
			fsmTemplate = source.fsmTemplate;
			FsmVarOverride[] array2 = CopyOverrides(source);
			fsmVarOverrides = array2;
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0xCB647C", Offset = "0xCB647C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fsmTemplate = template;\n\tHutongGames.PlayMaker.FsmTemplateControl::ClearOverrides(this);\n\tHutongGames.PlayMaker.FsmTemplateControl::UpdateOverrides(this);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFsmTemplate(FsmTemplate template)
		{
			fsmTemplate = template;
			ClearOverrides();
			UpdateOverrides();
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0xCB6760", Offset = "0xCB6760", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC4860]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023661]) = v40;\nL_0014:\n\tv41 = this.fsmTemplate;\n\tv47 = new HutongGames.PlayMaker.Fsm();\n\tHutongGames.PlayMaker.Fsm::.ctor(v47, v41.fsm, 0);\n\tthis.runFsm = v47;\n\tHutongGames.PlayMaker.FsmTemplateControl::ApplyOverrides(this, v47);\n\treturn this.runFsm;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Fsm InstantiateFsm()
		{
			FsmTemplate fsmTemplate = this.fsmTemplate;
			ApplyOverrides(runFsm = new Fsm(fsmTemplate.fsm));
			return RunFsm;
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0xCB6354", Offset = "0xCB6354", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EAD788]);\n\tv29 = *([v28 @ X8_v18]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023662]) = v48;\nL_001A:\n\tv50 = source.fsmVarOverrides;\n\t// 33 NewArr v114 @ X0_v8 (HutongGames.PlayMaker.FsmVarOverride[]), typeof(HutongGames.PlayMaker.FsmVarOverride[]), v50.Length\n\tv167 = source.fsmVarOverrides;\nL_0033:\n\tv53 = v101 >= v167.Length;\n\tif (v53) goto L_0073;\n\tv234 = v101 < v167.Length;\n\tv98 = ~v234;\n\tif (v98) goto L_0074;\n\tv115 = new HutongGames.PlayMaker.FsmVarOverride();\n\tHutongGames.PlayMaker.FsmVarOverride::.ctor(v115, v167[v101 @ X23_v5 (System.Int32)]);\n\tv263 = v115 == 0;\n\tif (v263) goto L_0054;\n\t// 80 IsInst v265 @ X0_v18, typeof(HutongGames.PlayMaker.FsmVarOverride), v115 @ X0_v15 (HutongGames.PlayMaker.FsmVarOverride)\nL_0054:\n\tv267 = v101 < v114.Length;\n\tv96 = ~v267;\n\tif (v96) goto L_0074;\n\tv114[v101 @ X23_v5 (System.Int32)] = v115;\n\tv167 = source.fsmVarOverrides;\n\tv101 = v101 + 1;\n\tv269 = source.fsmVarOverrides == 0;\n\tv117 = ~v269;\n\tif (v117) goto L_0033;\n\tthrow System.NullReferenceException;\nL_0073:\n\treturn v114;\nL_0074:\n\tv255 = new System.IndexOutOfRangeException();\n\tgoto L_0079;\n\tv260 = new System.ArrayTypeMismatchException();\nL_0079:\n\tthrow v259;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static FsmVarOverride[] CopyOverrides(FsmTemplateControl source)
		{
			FsmVarOverride[] array = source.fsmVarOverrides;
			FsmVarOverride[] array2 = new FsmVarOverride[array.Length];
			FsmVarOverride[] array3 = source.fsmVarOverrides;
			int num = 0;
			while (true)
			{
				if (num < array3.Length)
				{
					if (num >= array3.Length)
					{
						break;
					}
					FsmVarOverride fsmVarOverride = new FsmVarOverride(array3[num]);
					if (fsmVarOverride != null)
					{
						object obj = fsmVarOverride as FsmVarOverride;
					}
					if (num >= array2.Length)
					{
						break;
					}
					array2[num] = fsmVarOverride;
					array3 = source.fsmVarOverrides;
					num++;
					if (source.fsmVarOverrides == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return array2;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0xCB64A4", Offset = "0xCB64A4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEB580]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023663]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmVarOverride[]), typeof(HutongGames.PlayMaker.FsmVarOverride[]), 0\n\tthis.fsmVarOverrides = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearOverrides()
		{
			FsmVarOverride[] array = new FsmVarOverride[0];
			fsmVarOverrides = array;
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0xCB64FC", Offset = "0xCB64FC", Length = "0x264")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1F017B0]);\n\tv35 = *([v34 @ X8_v41]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023664]) = v54;\nL_0022:\n\tgoto L_002B;\n\tv62 = *([v58 @ X0_v2+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_002B;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_002B:\n\tv72 = UnityEngine.Object::op_Inequality(this.fsmTemplate, 0);\n\tv74 = v72 == 0;\n\tif (v74) goto L_00C1;\n\tv79 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVarOverride>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVarOverride>::.ctor(v79, this.fsmVarOverrides);\n\tv91 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVarOverride>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVarOverride>::.ctor(v91);\n\tv225 = this.fsmTemplate;\n\tv227 = v225.fsm;\n\tv322 = HutongGames.PlayMaker.FsmVariables::GetAllNamedVariables(v227.variables);\n\tv345 = v322.Length < 1;\n\tif (v345) goto L_00B9;\nL_0067:\n\tv279 = new HutongGames.PlayMaker.FsmTemplateControl+<>c__DisplayClass16_0();\n\tSystem.Object::.ctor(v279);\n\tv386 = v243 < v322.Length;\n\tv267 = ~v386;\n\tif (v267) goto L_00D3;\n\tv291 = v322[v243 @ X25_v8 (System.Int32)];\n\tv279.namedVariable = v322[v243 @ X25_v8 (System.Int32)];\n\tv389 = ~v291.showInInspector;\n\tif (v389) goto L_00A6;\n\tv280 = new System.Predicate`1<HutongGames.PlayMaker.FsmVarOverride>();\n\tSystem.Predicate`1<HutongGames.PlayMaker.FsmVarOverride>::.ctor(v280, v279, Il2CppMethodInfo);\n\tv403 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVarOverride>::Find(v79, v280);\n\tv405 = v403 == 0;\n\tv406 = ~v405;\n\tif (v406) goto L_00A4;\n\tv411 = new HutongGames.PlayMaker.FsmVarOverride();\n\tHutongGames.PlayMaker.FsmVarOverride::.ctor(v411, v279.namedVariable);\nL_00A4:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVarOverride>::Add(v91, v232);\nL_00A6:\n\tv243 = v243 + 1;\n\tv355 = v243 < v322.Length;\n\tif (v355) goto L_0067;\nL_00B9:\n\tv147 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVarOverride>::ToArray(v91);\n\tthis.fsmVarOverrides = v147;\n\tgoto L_00D0;\nL_00C1:\n\t// 193 NewArr v84 @ X0_v8 (HutongGames.PlayMaker.FsmVarOverride[]), typeof(HutongGames.PlayMaker.FsmVarOverride[]), 0\n\tthis.fsmVarOverrides = v84;\nL_00D0:\n\treturn;\n\tv328 = new System.NullReferenceException();\nL_00D3:\n\tv333 = new System.IndexOutOfRangeException();\n\tthrow v333;\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateOverrides()
		{
			//IL_003d: Expected I4, but got O
			if (this.fsmTemplate != null)
			{
				List<FsmVarOverride> list = new List<FsmVarOverride>((int)fsmVarOverrides);
				List<FsmVarOverride> list2 = new List<FsmVarOverride>();
				FsmTemplate fsmTemplate = this.fsmTemplate;
				Fsm fsm = fsmTemplate.fsm;
				NamedVariable[] allNamedVariables = fsm.Variables.GetAllNamedVariables();
				if (allNamedVariables.Length >= 1)
				{
					int num = 0;
					do
					{
						if (num < allNamedVariables.Length)
						{
							NamedVariable namedVariable = allNamedVariables[num];
							NamedVariable namedVariable2 = allNamedVariables[num];
							if (namedVariable.ShowInInspector)
							{
								Predicate<FsmVarOverride> match = delegate(FsmVarOverride o)
								{
									NamedVariable variable = o.variable;
									NamedVariable namedVariable3 = namedVariable2;
									return variable.Name == namedVariable3.Name;
								};
								FsmVarOverride fsmVarOverride = list.Find(match);
								bool flag = fsmVarOverride == null;
								bool flag2 = !flag;
								FsmVarOverride item = fsmVarOverride;
								if (!flag2)
								{
									FsmVarOverride fsmVarOverride2 = new FsmVarOverride(namedVariable2);
									item = fsmVarOverride2;
								}
								list2.Add(item);
							}
							num++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num < allNamedVariables.Length);
				}
				FsmVarOverride[] array = list2.ToArray();
				fsmVarOverrides = array;
			}
			else
			{
				FsmVarOverride[] array2 = new FsmVarOverride[0];
				fsmVarOverrides = array2;
			}
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0xCB6884", Offset = "0xCB6884", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.fsmVarOverrides;\n\tv68 = v10.Length;\n\tv24 = v10.Length < 1;\n\tif (v24) goto L_003D;\nL_0017:\n\tv145 = v39 < v68;\n\tv65 = ~v145;\n\tif (v65) goto L_003E;\n\tv70 = v10[v39 @ X20_v6 (System.Int32)];\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(v70.fsmVar);\n\tv68 = v10.Length;\n\tv39 = v39 + 1;\n\tv82 = v39 < v10.Length;\n\tif (v82) goto L_0017;\nL_003D:\n\treturn;\nL_003E:\n\tv166 = new System.IndexOutOfRangeException();\n\tthrow v166;\n\tthrow System.NullReferenceException;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateValues()
		{
			FsmVarOverride[] array = fsmVarOverrides;
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				FsmVarOverride fsmVarOverride = array[num2];
				fsmVarOverride.fsmVar.UpdateValue();
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xCB67F4", Offset = "0xCB67F4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.fsmVarOverrides;\n\tv72 = v12.Length;\n\tv28 = v12.Length < 1;\n\tif (v28) goto L_0041;\nL_0019:\n\tv155 = v43 < v72;\n\tv69 = ~v155;\n\tif (v69) goto L_0042;\n\tHutongGames.PlayMaker.FsmVarOverride::Apply(v12[v43 @ X21_v6 (System.Int32)], overrideFsm.variables);\n\tv72 = v12.Length;\n\tv43 = v43 + 1;\n\tv90 = v43 < v12.Length;\n\tif (v90) goto L_0019;\nL_0041:\n\treturn;\nL_0042:\n\tv176 = new System.IndexOutOfRangeException();\n\tthrow v176;\n\tthrow System.NullReferenceException;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ApplyOverrides(Fsm overrideFsm)
		{
			FsmVarOverride[] array = fsmVarOverrides;
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				array[num2].Apply(overrideFsm.Variables);
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
