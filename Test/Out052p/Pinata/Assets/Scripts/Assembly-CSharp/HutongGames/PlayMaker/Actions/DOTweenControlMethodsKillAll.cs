using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74E018", Offset = "0x74E018")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74E018", Offset = "0x74E018")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74E018", Offset = "0x74E018")]
	[Token(Token = "0x200009A")]
	public class DOTweenControlMethodsKillAll : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F5E0", Offset = "0x76F5E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F5E0", Offset = "0x76F5E0")]
		[Token(Token = "0x4000527")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool complete;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76F630", Offset = "0x76F630")]
		[Token(Token = "0x4000528")]
		[FieldOffset(Offset = "0x58")]
		public FsmString[] idsToExclude;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76F668", Offset = "0x76F668")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76F668", Offset = "0x76F668")]
		[Token(Token = "0x4000529")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool debugThis;

		[Token(Token = "0x60003FA")]
		[Address(RVA = "0xAF0F84", Offset = "0xAF0F84", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F04EC8]);\n\tv21 = *([v20 @ X8_v4]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022439]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v46);\n\tv46.useVariable = 0;\n\tv46.value = 0;\n\tthis.complete = v46;\n\tv51 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v51);\n\tv51.value = 0;\n\tthis.debugThis = v51;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			complete = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.value = false;
			debugThis = fsmBool2;
		}

		[Token(Token = "0x60003FB")]
		[Address(RVA = "0xAF102C", Offset = "0xAF102C", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EA6BC0]);\n\tv25 = *([v24 @ X8_v36]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202243A]) = v44;\nL_0016:\n\tv45 = this.idsToExclude;\n\tv48 = v45.Length == 0;\n\tif (v48) goto L_0088;\n\t// 31 NewArr v102 @ X0_v28 (System.Object[]), typeof(System.String[]), v45.Length\n\tv218 = v102.Length < 1;\n\tif (v218) goto L_0070;\nL_0031:\n\tv95 = this.idsToExclude;\n\tv348 = v60 < v95.Length;\n\tv157 = ~v348;\n\tif (v157) goto L_00C4;\n\tv374 = HutongGames.PlayMaker.FsmString::get_Value(v95[v60 @ X22_v9 (System.Int32)]);\n\tv392 = v374 == 0;\n\tif (v392) goto L_0051;\n\t// 77 IsInst this @ X0 (HutongGames.PlayMaker.Actions.DOTweenControlMethodsKillAll), typeof(System.Object), v374 @ X0_v41 (System.String)\nL_0051:\n\tv402 = v60 < v102.Length;\n\tv363 = ~v402;\n\tif (v363) goto L_00C4;\n\tv102[v60 @ X22_v9 (System.Int32)] = v374;\n\tv60 = v60 + 1;\n\tv267 = v60 < v102.Length;\n\tif (v267) goto L_0031;\nL_0070:\n\tv295 = HutongGames.PlayMaker.FsmBool::get_Value(this.complete);\n\tgoto L_0082;\n\tv366 = *([v305 @ X8_v24+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_0082;\n\tv375 = v305;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v375, v294, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0082:\n\tv301 = DG.Tweening.DOTween::KillAll(v295, v102);\n\tgoto L_009F;\nL_0088:\n\tv180 = HutongGames.PlayMaker.FsmBool::get_Value(this.complete);\n\tgoto L_0099;\n\tv282 = *([v222 @ X8_v17+E0]);\n\tv283 = v282 == 0;\n\tv284 = ~v283;\n\tif (v284) goto L_0099;\n\tv296 = v222;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v296, v179, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0099:\n\tv301 = DG.Tweening.DOTween::KillAll(v180);\nL_009F:\n\tv355 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv339 = v355 == 0;\n\tif (v339) goto L_00BA;\n\t// 169 Box v382 @ X0_v16 (System.Object), typeof(System.Int32), &v301 @ X0_v10 (System.Int32)\n\tv399 = System.String::Concat(\"DOTween Control Methods Kill All - Killed \", v382, \" tweens\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v399);\nL_00BA:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00C4:\n\tv255 = new System.IndexOutOfRangeException();\n\tgoto L_00CB;\n\tv178 = new System.NullReferenceException();\n\tv206 = new System.ArrayTypeMismatchException();\nL_00CB:\n\tthrow v254;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmString[] array = idsToExclude;
			int num2;
			if (array.Length != 0)
			{
				object[] array2 = new string[array.Length];
				if (array2.Length >= 1)
				{
					int num = 0;
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					while (true)
					{
						FsmString[] array3 = idsToExclude;
						if (num < array3.Length)
						{
							string value = array3[num].Value;
							if (value != null)
							{
								DOTweenControlMethodsKillAll dOTweenControlMethodsKillAll = (DOTweenControlMethodsKillAll)(value as object);
							}
							if (num < array2.Length)
							{
								array2[num] = value;
								num++;
								if (num >= array2.Length)
								{
									break;
								}
								continue;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex2;
					}
				}
				bool value2 = complete.Value;
				num2 = DOTween.KillAll(value2, array2);
			}
			else
			{
				bool value3 = complete.Value;
				num2 = DOTween.KillAll(value3);
			}
			if (debugThis.Value)
			{
				object obj = num2;
				string message = string.Concat("DOTween Control Methods Kill All - Killed ", obj, " tweens");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x60003FC")]
		[Address(RVA = "0xAF1248", Offset = "0xAF1248", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsKillAll()
		{
		}
	}
}
