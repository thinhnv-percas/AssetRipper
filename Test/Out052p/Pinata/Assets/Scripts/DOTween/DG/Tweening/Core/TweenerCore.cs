using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening.Core
{
	[Token(Token = "0x2000055")]
	public class TweenerCore<T1, T2, TPlugOptions> : Tweener where TPlugOptions : struct, IPlugOptions
	{
		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x0")]
		public T2 startValue;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x0")]
		public T2 endValue;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x0")]
		public T2 changeValue;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x0")]
		public TPlugOptions plugOptions;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x0")]
		public DOGetter<T1> getter;

		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x0")]
		public DOSetter<T1> setter;

		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x0")]
		internal ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin;

		[Token(Token = "0x400018C")]
		private const string _TxtCantChangeSequencedValues = "You cannot change the values of a tween contained inside a Sequence";

		[Token(Token = "0x60002DC")]
		[Address(RVA = "0x13EF04C", Offset = "0x13EF04C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EA69C0]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B3A]) = v41;\nL_0019:\n\tDG.Tweening.Tweener::.ctor(this);\n\tgoto L_002B;\n\tv56 = *([v51 @ X0_v5+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002B;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v51, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002B:\n\tv65 = System.Type::GetTypeFromHandle(Il2CppClass<T1>);\n\tthis.typeofT1 = v65;\n\tv91 = System.Type::GetTypeFromHandle(Il2CppClass<T2>);\n\tthis.typeofT2 = v91;\n\tv96 = System.Type::GetTypeFromHandle(Il2CppClass<TPlugOptions>);\n\tv82 = this->klass;\n\tthis.typeofTPlugOptions = v96;\n\tthis.tweenType = 0;\n\tv69 = this->klass->vtable[4];\n\tv73 = this->klass->vtable[4];\n\t// 68 IndirectJump v69 @ X2_v1, this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), v73 @ X1_v5, v69 @ X2_v1, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal TweenerCore()
		{
			//IL_0058: Expected I, but got O
			//IL_0086: Expected O, but got I
			//IL_0096: Expected O, but got I
			base._002Ector();
			Type typeFromHandle = typeof(T1);
			this.typeofT1 = typeFromHandle;
			Type typeFromHandle2 = typeof(T2);
			this.typeofT2 = typeFromHandle2;
			Type typeFromHandle3 = typeof(TPlugOptions);
			IntPtr intPtr = (IntPtr)this;
			this.typeofTPlugOptions = typeFromHandle3;
			this.tweenType = default(TweenType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v10 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+170]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v10 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+178]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v69 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002DD")]
		[Address(RVA = "0x13EF12C", Offset = "0x13EF12C", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1EAA9A8]);\n\tv33 = *([v32 @ X8_v66]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, newStartValue, methodInfo, v35, v36, v37, v38, v39, newDuration, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2028B3B]) = v49;\nL_001B:\n\tv51 = ~this.isSequenced;\n\tif (v51) goto L_0041;\n\tgoto L_0037;\n\tv58 = *([1EEF540]);\n\tv59 = *([v58 @ X8_v62]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v59, newStartValue, methodInfo, v35, v36, v37, v38, v39, newDuration, v40, v41, v42, v43, v44, v45, v46);\n\tv63 = 0 | 1;\n\t*([2022B9B]) = v63;\nL_0037:\n\tv79 = v67._logPriority < 1;\n\tif (v79) goto L_012A;\n\tgoto L_011F;\nL_0041:\n\tv82 = System.Object::GetType(newStartValue);\n\tv224 = v82 == this.typeofT2;\n\tif (v224) goto L_00D3;\n\tgoto L_0068;\n\tv326 = *([1EEF540]);\n\tv327 = *([v326 @ X8_v50]);\n\tv328 = \"il2cpp_codegen_initialize_method\"(v327, v81, methodInfo, v35, v36, v37, v38, v39, newDuration, v40, v41, v42, v43, v44, v45, v46);\n\tv330 = 0 | 1;\n\t*([2022B9B]) = v330;\nL_0068:\n\tv148 = v334._logPriority < 1;\n\tif (v148) goto L_012A;\n\t// 110 NewArr v243 @ X0_v22 (System.String[]), typeof(System.String[]), 5\n\tv351 = \"ChangeStartValue: incorrect newStartValue type (is \" == 0;\n\tif (v351) goto L_007D;\n\t// 121 IsInst v354 @ X0_v49, typeof(System.String), \"ChangeStartValue: incorrect newStartValue type (is \"\nL_007D:\n\tv361 = v243.Length == 0;\n\tif (v361) goto L_012B;\n\tv243[0] = \"ChangeStartValue: incorrect newStartValue type (is \";\n\tv363 = v82 == 0;\n\tif (v363) goto L_0091;\n\tv465 = System.Type::ToString(v82);\n\tv466 = v465 == 0;\n\tif (v466) goto L_0091;\n\t// 142 IsInst v444 @ X0_v48, typeof(System.String), v465 @ X0_v46 (System.String)\nL_0091:\n\tv418 = v243.Length;\n\tv468 = v243.Length < 1;\n\tv399 = ~v468;\n\tv395 = v243.Length - 1;\n\tv387 = v395 == 0;\n\tv469 = ~v399;\n\tv365 = v469 | v387;\n\tif (v365) goto L_012B;\n\tv243[1] = v422;\n\tv475 = \", should be \" == 0;\n\tif (v475) goto L_00AA;\n\t// 166 IsInst v445 @ X0_v44, typeof(System.String), \", should be \"\n\tv418 = v243.Length;\nL_00AA:\n\tv477 = v418 < 2;\n\tv400 = ~v477;\n\tv396 = v418 - 2;\n\tv388 = v396 == 0;\n\tv478 = ~v400;\n\tv366 = v478 | v388;\n\tif (v366) goto L_012B;\n\tv243[2] = \", should be \";\n\tv481 = this.typeofT2 == 0;\n\tif (v481) goto L_FFFFFFFF;\n\tv484 = System.Type::ToString(this.typeofT2);\n\tv485 = v484 == 0;\n\tif (v485) goto L_00F4;\n\t// 197 IsInst v446 @ X0_v43, typeof(System.String), v484 @ X0_v41 (System.String)\n\tv491 = v446 == 0;\n\tv451 = ~v491;\n\tif (v451) goto L_00F4;\n\tgoto L_012D;\nL_00D3:\n\tgoto L_FFFFFFFF;\n\tv337 = v208;\n\tv338 = 0x8907BC(v337, v81, methodInfo, v35, v36, v37, v38, v39, newDuration, v40, v41, v42, v43, v44, v45, v46);\n\tv147 = v147_asT == 0;\n\tif (v147) goto L_0134;\n\tv344 = \"il2cpp_vm_object_unbox\"(newStartValue, 0, methodInfo, v35, v36, v37, v38, v39, newDuration, v40, v41, v42, v43, v44, v45, v46);\n\tnewDuration = *([v344 @ X0_v15]);\n\tv189 = DG.Tweening.Tweener::DoChangeStartValue(this, &newDuration @ V0 (System.Single), *([v344 @ X0_v15]));\n\tgoto L_012A;\nL_00F4:\n\tv420 = v243.Length;\n\tv489 = v243.Length < 3;\n\tv401 = ~v489;\n\tv397 = v243.Length - 3;\n\tv389 = v397 == 0;\n\tv490 = ~v401;\n\tv367 = v490 | v389;\n\tif (v367) goto L_012B;\n\tv243[3] = v424;\n\tv494 = \")\" == 0;\n\tif (v494) goto L_010D;\n\t// 265 IsInst v447 @ X0_v40, typeof(System.String), \")\"\n\tv420 = v243.Length;\nL_010D:\n\tv496 = v420 < 4;\n\tv261 = ~v496;\n\tv260 = v420 - 4;\n\tv258 = v260 == 0;\n\tv497 = ~v261;\n\tv252 = v497 | v258;\n\tif (v252) goto L_012B;\n\tv243[4] = \")\";\n\tv188 = System.String::Concat(v243);\nL_011F:\n\tDG.Tweening.Core.Debugger::LogWarning(v188);\nL_012A:\n\treturn v195;\nL_012B:\n\tv425 = new System.IndexOutOfRangeException();\n\tgoto L_0130;\nL_012D:\n\tv461 = new System.ArrayTypeMismatchException();\nL_0130:\n\tthrow v425;\n\tv251 = new System.NullReferenceException();\nL_0134:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeStartValue(object newStartValue, float newDuration = -1f)
		{
			//IL_02d5: Expected F4, but got O
			//IL_02e3: Expected F4, but got O
			//IL_02e3: Expected O, but got F4
			//IL_0139: Expected O, but got I4
			//IL_0165: Expected O, but got I4
			//IL_0446: Expected O, but got I
			//IL_01e7: Expected O, but got I4
			//IL_0485: Expected O, but got I4
			//IL_04b1: Expected O, but got I4
			//IL_050f: Expected O, but got I
			//IL_034b: Expected O, but got I4
			TweenerCore<T1, T2, TPlugOptions> result;
			string message;
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			if (!this.isSequenced)
			{
				Type type = newStartValue.GetType();
				if ((object)type == this.typeofT2)
				{
					T2 val = (T2)((newStartValue is T2) ? newStartValue : null);
					if (val == null)
					{
						return (Tweener)(object)new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					float num = (float)obj;
					TweenerCore<T1, T2, TPlugOptions> tweenerCore = Tweener.DoChangeStartValue(this, (T2)newDuration, (float)obj);
					result = tweenerCore;
				}
				else
				{
					bool flag = Debugger._logPriority < 1;
					result = this;
					if (!flag)
					{
						string[] array = new string[5];
						if ("ChangeStartValue: incorrect newStartValue type (is " != null)
						{
							object obj2 = "ChangeStartValue: incorrect newStartValue type (is " as string;
						}
						if (array.Length != 0)
						{
							array[0] = "ChangeStartValue: incorrect newStartValue type (is ";
							bool flag2 = (object)type == null;
							Type type2 = type;
							if (!flag2)
							{
								string text = type.ToString();
								bool flag3 = text == null;
								type2 = (Type)(object)text;
								if (!flag3)
								{
									object obj3 = text as string;
									type2 = (Type)(object)text;
								}
							}
							object obj4 = array.Length;
							bool flag4 = array.Length < 1;
							bool flag5 = !flag4;
							object obj5 = array.Length - 1;
							bool flag6 = obj5 == null;
							bool flag7 = !flag5;
							if (!(flag7 || flag6))
							{
								array[1] = (string)(object)type2;
								if (", should be " != null)
								{
									object obj6 = ", should be " as string;
									obj4 = array.Length;
								}
								bool flag8 = (long)(IntPtr)obj4 < 2L;
								bool flag9 = !flag8;
								object obj7 = (long)(IntPtr)obj4 - 2L;
								bool flag10 = obj7 == null;
								bool flag11 = !flag9;
								if (!(flag11 || flag10))
								{
									array[2] = ", should be ";
									string text3;
									if ((object)this.typeofT2 != null)
									{
										string text2 = this.typeofT2.ToString();
										bool flag12 = text2 == null;
										text3 = text2;
										if (!flag12)
										{
											object obj8 = text2 as string;
											bool flag13 = obj8 == null;
											bool flag14 = !flag13;
											text3 = text2;
											if (!flag14)
											{
												ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
												goto IL_03a9;
											}
										}
									}
									else
									{
										text3 = null;
									}
									object obj9 = array.Length;
									bool flag15 = array.Length < 3;
									bool flag16 = !flag15;
									object obj10 = array.Length - 3;
									bool flag17 = obj10 == null;
									bool flag18 = !flag16;
									if (!(flag18 || flag17))
									{
										array[3] = text3;
										if (")" != null)
										{
											object obj11 = ")" as string;
											obj9 = array.Length;
										}
										bool flag19 = (long)(IntPtr)obj9 < 4L;
										bool flag20 = !flag19;
										object obj12 = (long)(IntPtr)obj9 - 4L;
										bool flag21 = obj12 == null;
										bool flag22 = !flag20;
										if (!(flag22 || flag21))
										{
											array[4] = ")";
											message = string.Concat(array);
											goto IL_0375;
										}
									}
								}
							}
						}
						ex2 = new IndexOutOfRangeException();
						goto IL_03a9;
					}
				}
			}
			else
			{
				bool flag23 = Debugger._logPriority < 1;
				result = this;
				if (!flag23)
				{
					message = "You cannot change the values of a tween contained inside a Sequence";
					goto IL_0375;
				}
			}
			goto IL_0388;
			IL_03a9:
			throw ex2;
			IL_0375:
			Debugger.LogWarning(message);
			result = this;
			goto IL_0388;
			IL_0388:
			return result;
		}

		[Token(Token = "0x60002DE")]
		[Address(RVA = "0x13EF43C", Offset = "0x13EF43C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this->klass;\n\tv6 = this->klass->vtable[10];\n\tv7 = this->klass->vtable[10];\n\t// 7 IndirectJump v6 @ X4_v1, this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), newEndValue @ X1 (System.Object), snapStartValue @ X2 (System.Boolean), v7 @ X3_v1, v6 @ X4_v1, v9 @ X5, v10 @ X6, v11 @ X7, -1f, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeEndValue(object newEndValue, bool snapStartValue)
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+1D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>>)+1D8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x60002DF")]
		[Address(RVA = "0x13EF460", Offset = "0x13EF460", Length = "0x324")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv36 = *([1EB2098]);\n\tv37 = *([v36 @ X8_v66]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, newEndValue, snapStartValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2028B3C]) = v52;\nL_001D:\n\tv54 = ~this.isSequenced;\n\tif (v54) goto L_0043;\n\tgoto L_0039;\n\tv61 = *([1EEF540]);\n\tv62 = *([v61 @ X8_v62]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, newEndValue, snapStartValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv66 = 0 | 1;\n\t*([2022B9B]) = v66;\nL_0039:\n\tv82 = v70._logPriority < 1;\n\tif (v82) goto L_0131;\n\tgoto L_0125;\nL_0043:\n\tv85 = System.Object::GetType(newEndValue);\n\tv229 = v85 == this.typeofT2;\n\tif (v229) goto L_009E;\n\tgoto L_006A;\n\tv333 = *([1EEF540]);\n\tv334 = *([v333 @ X8_v50]);\n\tv335 = \"il2cpp_codegen_initialize_method\"(v334, v84, snapStartValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv337 = 0 | 1;\n\t*([2022B9B]) = v337;\nL_006A:\n\tv151 = v341._logPriority < 1;\n\tif (v151) goto L_0131;\n\t// 112 NewArr v248 @ X0_v22 (System.String[]), typeof(System.String[]), 5\n\tv359 = \"ChangeEndValue: incorrect newEndValue type (is \" == 0;\n\tif (v359) goto L_007F;\n\t// 123 IsInst v362 @ X0_v49, typeof(System.String), \"ChangeEndValue: incorrect newEndValue type (is \"\nL_007F:\n\tv369 = v248.Length == 0;\n\tif (v369) goto L_0132;\n\tv248[0] = \"ChangeEndValue: incorrect newEndValue type (is \";\n\tv371 = v85 == 0;\n\tif (v371) goto L_FFFFFFFF;\n\tv473 = System.Type::ToString(v85);\n\tv474 = v473 == 0;\n\tif (v474) goto L_00C0;\n\t// 144 IsInst v452 @ X0_v48, typeof(System.String), v473 @ X0_v46 (System.String)\n\tv482 = v452 == 0;\n\tv457 = ~v482;\n\tif (v457) goto L_00C0;\n\tgoto L_0134;\nL_009E:\n\tgoto L_FFFFFFFF;\n\tv344 = v213;\n\tv345 = 0x8907BC(v344, v84, snapStartValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv150 = v150_asT == 0;\n\tif (v150) goto L_013B;\n\tv351 = \"il2cpp_vm_object_unbox\"(newEndValue, 0, snapStartValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tnewDuration = *([v351 @ X0_v15]);\n\tv194 = DG.Tweening.Tweener::DoChangeEndValue(this, &newDuration @ V0 (System.Single), *([v351 @ X0_v15]), snapStartValue);\n\tgoto L_0131;\nL_00C0:\n\tv430 = v248.Length;\n\tv480 = v248.Length < 1;\n\tv407 = ~v480;\n\tv403 = v248.Length - 1;\n\tv395 = v403 == 0;\n\tv481 = ~v407;\n\tv373 = v481 | v395;\n\tif (v373) goto L_0132;\n\tv248[1] = v425;\n\tv485 = \", should be \" == 0;\n\tif (v485) goto L_00D9;\n\t// 213 IsInst v453 @ X0_v44, typeof(System.String), \", should be \"\n\tv430 = v248.Length;\nL_00D9:\n\tv487 = v430 < 2;\n\tv408 = ~v487;\n\tv404 = v430 - 2;\n\tv396 = v404 == 0;\n\tv488 = ~v408;\n\tv374 = v488 | v396;\n\tif (v374) goto L_0132;\n\tv248[2] = \", should be \";\n\tv491 = this.typeofT2 == 0;\n\tif (v491) goto L_FFFFFFFF;\n\tv494 = System.Type::ToString(this.typeofT2);\n\tv495 = v494 == 0;\n\tif (v495) goto L_00FA;\n\t// 244 IsInst v454 @ X0_v43, typeof(System.String), v494 @ X0_v41 (System.String)\n\tv501 = v454 == 0;\n\tv459 = ~v501;\n\tif (v459) goto L_00FA;\n\tgoto L_0134;\nL_00FA:\n\tv432 = v248.Length;\n\tv499 = v248.Length < 3;\n\tv409 = ~v499;\n\tv405 = v248.Length - 3;\n\tv397 = v405 == 0;\n\tv500 = ~v409;\n\tv375 = v500 | v397;\n\tif (v375) goto L_0132;\n\tv248[3] = v427;\n\tv504 = \")\" == 0;\n\tif (v504) goto L_0113;\n\t// 271 IsInst v455 @ X0_v40, typeof(System.String), \")\"\n\tv432 = v248.Length;\nL_0113:\n\tv506 = v432 < 4;\n\tv266 = ~v506;\n\tv265 = v432 - 4;\n\tv263 = v265 == 0;\n\tv507 = ~v266;\n\tv257 = v507 | v263;\n\tif (v257) goto L_0132;\n\tv248[4] = \")\";\n\tv193 = System.String::Concat(v248);\nL_0125:\n\tDG.Tweening.Core.Debugger::LogWarning(v193);\nL_0131:\n\treturn v200;\nL_0132:\n\tv433 = new System.IndexOutOfRangeException();\n\tgoto L_0137;\nL_0134:\n\tv469 = new System.ArrayTypeMismatchException();\nL_0137:\n\tthrow v433;\n\tv256 = new System.NullReferenceException();\nL_013B:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeEndValue(object newEndValue, float newDuration = -1f, bool snapStartValue = false)
		{
			//IL_0190: Expected F4, but got O
			//IL_01a2: Expected F4, but got O
			//IL_01a2: Expected O, but got F4
			//IL_03ea: Expected O, but got I4
			//IL_0416: Expected O, but got I4
			//IL_0474: Expected O, but got I
			//IL_020a: Expected O, but got I4
			//IL_04b3: Expected O, but got I4
			//IL_04df: Expected O, but got I4
			//IL_053d: Expected O, but got I
			//IL_030e: Expected O, but got I4
			TweenerCore<T1, T2, TPlugOptions> result;
			string message;
			IndexOutOfRangeException ex = default(IndexOutOfRangeException);
			if (!this.isSequenced)
			{
				Type type = newEndValue.GetType();
				if ((object)type == this.typeofT2)
				{
					T2 val = (T2)((newEndValue is T2) ? newEndValue : null);
					if (val == null)
					{
						return (Tweener)(object)new InvalidCastException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					float num = (float)obj;
					TweenerCore<T1, T2, TPlugOptions> tweenerCore = Tweener.DoChangeEndValue(this, (T2)newDuration, (float)obj, snapStartValue);
					result = tweenerCore;
				}
				else
				{
					bool flag = Debugger._logPriority < 1;
					result = this;
					if (!flag)
					{
						string[] array = new string[5];
						if ("ChangeEndValue: incorrect newEndValue type (is " != null)
						{
							object obj2 = "ChangeEndValue: incorrect newEndValue type (is " as string;
						}
						if (array.Length != 0)
						{
							array[0] = "ChangeEndValue: incorrect newEndValue type (is ";
							string text2;
							if ((object)type != null)
							{
								string text = type.ToString();
								bool flag2 = text == null;
								text2 = text;
								if (!flag2)
								{
									object obj3 = text as string;
									bool flag3 = obj3 == null;
									bool flag4 = !flag3;
									text2 = text;
									if (!flag4)
									{
										goto IL_035e;
									}
								}
							}
							else
							{
								text2 = null;
							}
							object obj4 = array.Length;
							bool flag5 = array.Length < 1;
							bool flag6 = !flag5;
							object obj5 = array.Length - 1;
							bool flag7 = obj5 == null;
							bool flag8 = !flag6;
							if (!(flag8 || flag7))
							{
								array[1] = text2;
								if (", should be " != null)
								{
									object obj6 = ", should be " as string;
									obj4 = array.Length;
								}
								bool flag9 = (long)(IntPtr)obj4 < 2L;
								bool flag10 = !flag9;
								object obj7 = (long)(IntPtr)obj4 - 2L;
								bool flag11 = obj7 == null;
								bool flag12 = !flag10;
								if (!(flag12 || flag11))
								{
									array[2] = ", should be ";
									string text4;
									if ((object)this.typeofT2 != null)
									{
										string text3 = this.typeofT2.ToString();
										bool flag13 = text3 == null;
										text4 = text3;
										if (!flag13)
										{
											object obj8 = text3 as string;
											bool flag14 = obj8 == null;
											bool flag15 = !flag14;
											text4 = text3;
											if (!flag15)
											{
												goto IL_035e;
											}
										}
									}
									else
									{
										text4 = null;
									}
									object obj9 = array.Length;
									bool flag16 = array.Length < 3;
									bool flag17 = !flag16;
									object obj10 = array.Length - 3;
									bool flag18 = obj10 == null;
									bool flag19 = !flag17;
									if (!(flag19 || flag18))
									{
										array[3] = text4;
										if (")" != null)
										{
											object obj11 = ")" as string;
											obj9 = array.Length;
										}
										bool flag20 = (long)(IntPtr)obj9 < 4L;
										bool flag21 = !flag20;
										object obj12 = (long)(IntPtr)obj9 - 4L;
										bool flag22 = obj12 == null;
										bool flag23 = !flag21;
										if (!(flag23 || flag22))
										{
											array[4] = ")";
											message = string.Concat(array);
											goto IL_0338;
										}
									}
								}
							}
						}
						ex = new IndexOutOfRangeException();
						goto IL_036c;
					}
				}
			}
			else
			{
				bool flag24 = Debugger._logPriority < 1;
				result = this;
				if (!flag24)
				{
					message = "You cannot change the values of a tween contained inside a Sequence";
					goto IL_0338;
				}
			}
			goto IL_034b;
			IL_035e:
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			goto IL_036c;
			IL_036c:
			throw ex;
			IL_034b:
			return result;
			IL_0338:
			Debugger.LogWarning(message);
			result = this;
			goto IL_034b;
		}

		[Token(Token = "0x60002E0")]
		[Address(RVA = "0x13EF784", Offset = "0x13EF784", Length = "0x424")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv36 = *([1F0E818]);\n\tv37 = *([v36 @ X8_v89]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, newStartValue, newEndValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2028B3D]) = v52;\nL_001D:\n\tv54 = ~this.isSequenced;\n\tif (v54) goto L_0043;\n\tgoto L_0039;\n\tv61 = *([1EEF540]);\n\tv62 = *([v61 @ X8_v85]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, newStartValue, newEndValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv66 = 0 | 1;\n\t*([2022B9B]) = v66;\nL_0039:\n\tv82 = v70._logPriority < 1;\n\tif (v82) goto L_014F;\n\tgoto L_0143;\nL_0043:\n\tv596 = System.Object::GetType(newStartValue);\n\tv313 = System.Object::GetType(newEndValue);\n\tv407 = v596 == this.typeofT2;\n\tif (v407) goto L_0092;\n\tgoto L_0070;\n\tv480 = *([1EEF540]);\n\tv481 = *([v480 @ X8_v73]);\n\tv482 = \"il2cpp_codegen_initialize_method\"(v481, v170, newEndValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv484 = 0 | 1;\n\t*([2022B9B]) = v484;\nL_0070:\n\tv117 = v488._logPriority < 1;\n\tif (v117) goto L_014F;\n\t// 118 NewArr v230 @ X0_v63 (System.String[]), typeof(System.String[]), 5\n\tv523 = \"ChangeValues: incorrect value type (is \" == 0;\n\tif (v523) goto L_0085;\n\t// 129 IsInst v372 @ X0_v67, typeof(System.String), \"ChangeValues: incorrect value type (is \"\nL_0085:\n\tv535 = v230.Length == 0;\n\tif (v535) goto L_0198;\n\tv230[0] = \"ChangeValues: incorrect value type (is \";\n\tv545 = v596 == 0;\n\tif (v545) goto L_FFFFFFFF;\n\tgoto L_00D1;\nL_0092:\n\tv455 = v313 == v596;\n\tif (v455) goto L_0159;\n\tgoto L_00B2;\n\tv502 = *([1EEF540]);\n\tv503 = *([v502 @ X8_v56]);\n\tv504 = \"il2cpp_codegen_initialize_method\"(v503, v170, newEndValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv506 = 0 | 1;\n\t*([2022B9B]) = v506;\nL_00B2:\n\tv118 = v510._logPriority < 1;\n\tif (v118) goto L_014F;\n\t// 184 NewArr v231 @ X0_v54 (System.String[]), typeof(System.String[]), 5\n\tv538 = \"ChangeValues: incorrect value type (is \" == 0;\n\tif (v538) goto L_00C7;\n\t// 195 IsInst v373 @ X0_v58, typeof(System.String), \"ChangeValues: incorrect value type (is \"\nL_00C7:\n\tv557 = v231.Length == 0;\n\tif (v557) goto L_0198;\n\tv231[0] = \"ChangeValues: incorrect value type (is \";\n\tv585 = v313 == 0;\n\tif (v585) goto L_FFFFFFFF;\nL_00D1:\n\tv603 = System.Type::ToString(v596);\n\tv604 = v603 == 0;\n\tif (v604) goto L_00DE;\n\t// 216 IsInst v374 @ X0_v36, typeof(System.String), v603 @ X0_v34 (System.String)\n\tv621 = v374 == 0;\n\tv381 = ~v621;\n\tif (v381) goto L_00DE;\n\tgoto L_019C;\nL_00DE:\n\tv565 = v258.Length;\n\tv615 = v258.Length < 1;\n\tv360 = ~v615;\n\tv355 = v258.Length - 1;\n\tv345 = v355 == 0;\n\tv616 = ~v360;\n\tv316 = v616 | v345;\n\tif (v316) goto L_0198;\n\tv258[1] = v561;\n\tv620 = \", should be \" == 0;\n\tif (v620) goto L_00F7;\n\t// 243 IsInst v375 @ X0_v32, typeof(System.String), \", should be \"\n\tv565 = v258.Length;\nL_00F7:\n\tv623 = v565 < 2;\n\tv361 = ~v623;\n\tv356 = v565 - 2;\n\tv346 = v356 == 0;\n\tv624 = ~v361;\n\tv317 = v624 | v346;\n\tif (v317) goto L_0198;\n\tv258[2] = \", should be \";\n\tv627 = this.typeofT2 == 0;\n\tif (v627) goto L_FFFFFFFF;\n\tv630 = System.Type::ToString(this.typeofT2);\n\tv631 = v630 == 0;\n\tif (v631) goto L_0118;\n\t// 274 IsInst v376 @ X0_v31, typeof(System.String), v630 @ X0_v29 (System.String)\n\tv637 = v376 == 0;\n\tv383 = ~v637;\n\tif (v383) goto L_0118;\n\tgoto L_019C;\nL_0118:\n\tv567 = v258.Length;\n\tv635 = v258.Length < 3;\n\tv362 = ~v635;\n\tv357 = v258.Length - 3;\n\tv347 = v357 == 0;\n\tv636 = ~v362;\n\tv318 = v636 | v347;\n\tif (v318) goto L_0198;\n\tv258[3] = v562;\n\tv640 = \")\" == 0;\n\tif (v640) goto L_0131;\n\t// 301 IsInst v377 @ X0_v28, typeof(System.String), \")\"\n\tv567 = v258.Length;\nL_0131:\n\tv642 = v567 < 4;\n\tv252 = ~v642;\n\tv251 = v567 - 4;\n\tv249 = v251 == 0;\n\tv643 = ~v252;\n\tv243 = v643 | v249;\n\tif (v243) goto L_0198;\n\tv258[4] = \")\";\n\tv172 = System.String::Concat(v258);\nL_0143:\n\tDG.Tweening.Core.Debugger::LogWarning(v172);\nL_014F:\n\treturn v181;\nL_0159:\n\tgoto L_FFFFFFFF;\n\tv513 = v478;\n\tv514 = 0x8907BC(v513, v170, newEndValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tv461 = v461_asT == 0;\n\tif (v461) goto L_01A1;\n\tv520 = \"il2cpp_vm_object_unbox\"(newStartValue, 0, newEndValue, methodInfo, v39, v40, v41, v42, newDuration, v43, v44, v45, v46, v47, v48, v49);\n\tnewDuration = *([v520 @ X0_v42]);\n\tgoto L_FFFFFFFF;\n\tv539 = v196;\n\tv540 = 0x8907BC(v539, v170, newEndValue, methodInfo, v39, v40, v41, v42, v460, v43, v44, v45, v46, v47, v48, v49);\n\tv116 = v116_asT == 0;\n\tif (v116) goto L_01A1;\n\tv570 = \"il2cpp_vm_object_unbox\"(newEndValue, 0, newEndValue, methodInfo, v39, v40, v41, v42, *([v520 @ X0_v42]), v43, v44, v45, v46, v47, v48, v49);\n\tnewDuration = *([v570 @ X0_v45]);\n\tv173 = DG.Tweening.Tweener::DoChangeValues(this, &newDuration @ V0 (System.Single), &newDuration @ V0 (System.Single), *([v570 @ X0_v45]));\n\tgoto L_014F;\nL_0198:\n\tv436 = new System.IndexOutOfRangeException();\n\tgoto L_019F;\n\tv242 = new System.NullReferenceException();\nL_019C:\n\tv401 = new System.ArrayTypeMismatchException();\nL_019F:\n\tthrow v436;\nL_01A1:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 275 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Tweener ChangeValues(object newStartValue, object newEndValue, float newDuration = -1f)
		{
			//IL_03f3: Expected F4, but got O
			//IL_0434: Expected F4, but got O
			//IL_0446: Expected F4, but got O
			//IL_0446: Expected O, but got F4
			//IL_0446: Expected O, but got F4
			//IL_0546: Expected O, but got I4
			//IL_0572: Expected O, but got I4
			//IL_05d0: Expected O, but got I
			//IL_026c: Expected O, but got I4
			//IL_060f: Expected O, but got I4
			//IL_063b: Expected O, but got I4
			//IL_0699: Expected O, but got I
			//IL_0370: Expected O, but got I4
			TweenerCore<T1, T2, TPlugOptions> result;
			string[] array2;
			string text2;
			if (!this.isSequenced)
			{
				Type type = newStartValue.GetType();
				Type type2 = newEndValue.GetType();
				if ((object)type == this.typeofT2)
				{
					if ((object)type2 == type)
					{
						T2 val = (T2)((newStartValue is T2) ? newStartValue : null);
						if (val != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj = default(object);
							float num = (float)obj;
							T2 val2 = (T2)((newEndValue is T2) ? newEndValue : null);
							if (val2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								object obj2 = default(object);
								num = (float)obj2;
								TweenerCore<T1, T2, TPlugOptions> tweenerCore = Tweener.DoChangeValues(this, (T2)newDuration, (T2)newDuration, (float)obj2);
								result = tweenerCore;
								goto IL_03ad;
							}
						}
						return (Tweener)(object)new InvalidCastException();
					}
					bool flag = Debugger._logPriority < 1;
					result = this;
					if (flag)
					{
						goto IL_03ad;
					}
					string[] array = new string[5];
					if ("ChangeValues: incorrect value type (is " != null)
					{
						object obj3 = "ChangeValues: incorrect value type (is " as string;
					}
					if (array.Length == 0)
					{
						goto IL_0457;
					}
					array[0] = "ChangeValues: incorrect value type (is ";
					bool flag2 = (object)type2 == null;
					array2 = array;
					if (flag2)
					{
						goto IL_0215;
					}
					type = type2;
					array2 = array;
				}
				else
				{
					bool flag3 = Debugger._logPriority < 1;
					result = this;
					if (flag3)
					{
						goto IL_03ad;
					}
					string[] array3 = new string[5];
					if ("ChangeValues: incorrect value type (is " != null)
					{
						object obj4 = "ChangeValues: incorrect value type (is " as string;
					}
					if (array3.Length == 0)
					{
						goto IL_0457;
					}
					array3[0] = "ChangeValues: incorrect value type (is ";
					bool flag4 = (object)type == null;
					array2 = array3;
					if (flag4)
					{
						goto IL_0215;
					}
					array2 = array3;
				}
				string text = type.ToString();
				bool flag5 = text == null;
				text2 = text;
				if (!flag5)
				{
					object obj5 = text as string;
					bool flag6 = obj5 == null;
					bool flag7 = !flag6;
					text2 = text;
					if (!flag7)
					{
						goto IL_0465;
					}
				}
				goto IL_053c;
			}
			bool flag8 = Debugger._logPriority < 1;
			result = this;
			string message;
			if (!flag8)
			{
				message = "You cannot change the values of a tween contained inside a Sequence";
				goto IL_039a;
			}
			goto IL_03ad;
			IL_0457:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			goto IL_0473;
			IL_0473:
			throw ex;
			IL_039a:
			Debugger.LogWarning(message);
			result = this;
			goto IL_03ad;
			IL_0465:
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			goto IL_0473;
			IL_053c:
			object obj6 = array2.Length;
			bool flag9 = array2.Length < 1;
			bool flag10 = !flag9;
			object obj7 = array2.Length - 1;
			bool flag11 = obj7 == null;
			bool flag12 = !flag10;
			if (!(flag12 || flag11))
			{
				array2[1] = text2;
				if (", should be " != null)
				{
					object obj8 = ", should be " as string;
					obj6 = array2.Length;
				}
				bool flag13 = (long)(IntPtr)obj6 < 2L;
				bool flag14 = !flag13;
				object obj9 = (long)(IntPtr)obj6 - 2L;
				bool flag15 = obj9 == null;
				bool flag16 = !flag14;
				if (!(flag16 || flag15))
				{
					array2[2] = ", should be ";
					string text4;
					if ((object)this.typeofT2 != null)
					{
						string text3 = this.typeofT2.ToString();
						bool flag17 = text3 == null;
						text4 = text3;
						if (!flag17)
						{
							object obj10 = text3 as string;
							bool flag18 = obj10 == null;
							bool flag19 = !flag18;
							text4 = text3;
							if (!flag19)
							{
								goto IL_0465;
							}
						}
					}
					else
					{
						text4 = null;
					}
					object obj11 = array2.Length;
					bool flag20 = array2.Length < 3;
					bool flag21 = !flag20;
					object obj12 = array2.Length - 3;
					bool flag22 = obj12 == null;
					bool flag23 = !flag21;
					if (!(flag23 || flag22))
					{
						array2[3] = text4;
						if (")" != null)
						{
							object obj13 = ")" as string;
							obj11 = array2.Length;
						}
						bool flag24 = (long)(IntPtr)obj11 < 4L;
						bool flag25 = !flag24;
						object obj14 = (long)(IntPtr)obj11 - 4L;
						bool flag26 = obj14 == null;
						bool flag27 = !flag25;
						if (!(flag27 || flag26))
						{
							array2[4] = ")";
							message = string.Concat(array2);
							goto IL_039a;
						}
					}
				}
			}
			goto IL_0457;
			IL_03ad:
			return result;
			IL_0215:
			text2 = null;
			goto IL_053c;
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0x13EFBA8", Offset = "0x13EFBA8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EC6158]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, newStartValue, methodInfo, v33, v34, v35, v36, v37, newDuration, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028B3E]) = v47;\nL_001A:\n\tv49 = ~this.isSequenced;\n\tif (v49) goto L_003E;\n\tgoto L_0036;\n\tv71 = *([1EEF540]);\n\tv72 = *([v71 @ X8_v17]);\n\tv73 = \"il2cpp_codegen_initialize_method\"(v72, newStartValue, methodInfo, v33, v34, v35, v36, v37, newDuration, v38, v39, v40, v41, v42, v43, v44);\n\tv76 = 0 | 1;\n\t*([2022B9B]) = v76;\nL_0036:\n\tv92 = v80._logPriority < 1;\n\tif (v92) goto L_0057;\n\tDG.Tweening.Core.Debugger::LogWarning(\"You cannot change the values of a tween contained inside a Sequence\");\n\tgoto L_0057;\nL_003E:\n\tv54 = newStartValue->klass;\n\tv61 = *([2022018]);\n\tv62 = *([v61 @ X8_v5+C0]);\n\tv63 = *([v62 @ X8_v6+20]);\n\t*([v63 @ X9_v2])(v68, this, &v54 @ V1_v2 (Il2CppClass<T2>), *([v62 @ X8_v6+20]), v33, v34, v35, v36, v37, newDuration, *([newStartValue @ X1 (T2)]), v39, v40, v41, v42, v43, v44);\nL_0057:\n\treturn v129;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeStartValue(T2 newStartValue, float newDuration = -1f)
		{
			//IL_0026: Expected I, but got O
			//IL_0036: Expected O, but got I
			//IL_0046: Expected O, but got I
			//IL_0056: Expected O, but got I
			TweenerCore<T1, T2, TPlugOptions> result;
			if (!this.isSequenced)
			{
				IntPtr intPtr = (IntPtr)newStartValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022018]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X8_v5+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v6+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v63 @ X9_v2] (should have been resolved before IL gen)");
				TweenerCore<T1, T2, TPlugOptions> tweenerCore = default(TweenerCore<T1, T2, TPlugOptions>);
				result = tweenerCore;
			}
			else
			{
				bool flag = Debugger._logPriority < 1;
				result = this;
				if (!flag)
				{
					Debugger.LogWarning("You cannot change the values of a tween contained inside a Sequence");
					result = this;
				}
			}
			return result;
		}

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0x13EFCA4", Offset = "0x13EFCA4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = newEndValue->klass;\n\treturnVal1 = DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>::ChangeEndValue(this, &v9 @ V0_v2 (Il2CppClass<T2>), -1f, snapStartValue);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeEndValue(T2 newEndValue, bool snapStartValue)
		{
			//IL_0008: Expected I, but got O
			//IL_0020: Expected O, but got I
			IntPtr intPtr = (IntPtr)newEndValue;
			return ChangeEndValue((T2)(long)intPtr, -1f, snapStartValue);
		}

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0x13EFD00", Offset = "0x13EFD00", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EC3D50]);\n\tv35 = *([v34 @ X8_v20]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, newEndValue, snapStartValue, methodInfo, v37, v38, v39, v40, newDuration, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2028B3F]) = v50;\nL_001C:\n\tv52 = ~this.isSequenced;\n\tif (v52) goto L_0040;\n\tgoto L_0038;\n\tv75 = *([1EEF540]);\n\tv76 = *([v75 @ X8_v17]);\n\tv77 = \"il2cpp_codegen_initialize_method\"(v76, newEndValue, snapStartValue, methodInfo, v37, v38, v39, v40, newDuration, v41, v42, v43, v44, v45, v46, v47);\n\tv80 = 0 | 1;\n\t*([2022B9B]) = v80;\nL_0038:\n\tv96 = v84._logPriority < 1;\n\tif (v96) goto L_005B;\n\tDG.Tweening.Core.Debugger::LogWarning(\"You cannot change the values of a tween contained inside a Sequence\");\n\tgoto L_005B;\nL_0040:\n\tv57 = newEndValue->klass;\n\tv72 = DG.Tweening.Tweener::DoChangeEndValue(this, &v57 @ V1_v2 (Il2CppClass<T2>), newDuration, snapStartValue);\nL_005B:\n\treturn v134;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeEndValue(T2 newEndValue, float newDuration = -1f, bool snapStartValue = false)
		{
			//IL_0026: Expected I, but got O
			//IL_0038: Expected O, but got I
			TweenerCore<T1, T2, TPlugOptions> result;
			if (!this.isSequenced)
			{
				IntPtr intPtr = (IntPtr)newEndValue;
				TweenerCore<T1, T2, TPlugOptions> tweenerCore = Tweener.DoChangeEndValue(this, (T2)(long)intPtr, newDuration, snapStartValue);
				result = tweenerCore;
			}
			else
			{
				bool flag = Debugger._logPriority < 1;
				result = this;
				if (!flag)
				{
					Debugger.LogWarning("You cannot change the values of a tween contained inside a Sequence");
					result = this;
				}
			}
			return result;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0x13EFE0C", Offset = "0x13EFE0C", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-10_v2;\n\tgoto L_001C;\n\tv34 = *([1F00050]);\n\tv35 = *([v34 @ X8_v20]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, newStartValue, newEndValue, methodInfo, v37, v38, v39, v40, newDuration, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2028B40]) = v50;\nL_001C:\n\tv52 = ~this.isSequenced;\n\tif (v52) goto L_0040;\n\tgoto L_0038;\n\tv83 = *([1EEF540]);\n\tv84 = *([v83 @ X8_v17]);\n\tv85 = \"il2cpp_codegen_initialize_method\"(v84, newStartValue, newEndValue, methodInfo, v37, v38, v39, v40, newDuration, v41, v42, v43, v44, v45, v46, v47);\n\tv88 = 0 | 1;\n\t*([2022B9B]) = v88;\nL_0038:\n\tv104 = v92._logPriority < 1;\n\tif (v104) goto L_0065;\n\tDG.Tweening.Core.Debugger::LogWarning(\"You cannot change the values of a tween contained inside a Sequence\");\n\tgoto L_0065;\nL_0040:\n\tv63 = *([newStartValue @ X1 (T2)+10]);\n\t*([v16 @ X29_v1-40]) = *([newStartValue @ X1 (T2)+10]);\n\tv63 = newStartValue->klass;\n\tnewStartValue->klass = newStartValue->klass;\n\tv63 = *([newEndValue @ X2 (T2)+10]);\n\tv63 = newEndValue->klass;\n\tv68 = *([2022018]);\n\tv69 = *([v16 @ X29_v1-50]);\n\tv73 = *([v68 @ X8_v5+C0]);\n\tv74 = *([v73 @ X8_v6+30]);\n\t*([v74 @ X9_v2])(v80, this, &v69 @ V1_v2, &v63 @ V0_v3 (Il2CppClass<T2>), *([v73 @ X8_v6+30]), v37, v38, v39, v40, newDuration, *([v16 @ X29_v1-50]), *([newEndValue @ X2 (T2)]), *([newEndValue @ X2 (T2)]), v44, v45, v46, v47);\nL_0065:\n\treturn v148;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenerCore<T1, T2, TPlugOptions> ChangeValues(T2 newStartValue, T2 newEndValue, float newDuration = -1f)
		{
			//IL_004b: Expected I, but got O
			//IL_0068: Expected I, but got O
			//IL_0078: Expected O, but got I
			//IL_0088: Expected O, but got I
			//IL_0098: Expected O, but got I
			//IL_00a8: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			TweenerCore<T1, T2, TPlugOptions> result;
			if (!this.isSequenced)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+10]");
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+10]");
				_ = 0;
				intPtr = (IntPtr)newStartValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newEndValue @ X2 (T2)+10]");
				intPtr = (IntPtr)0;
				intPtr = (IntPtr)newEndValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2022018]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-50]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v5+C0]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v6+30]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ X9_v2] (should have been resolved before IL gen)");
				TweenerCore<T1, T2, TPlugOptions> tweenerCore = default(TweenerCore<T1, T2, TPlugOptions>);
				result = tweenerCore;
			}
			else
			{
				bool flag = Debugger._logPriority < 1;
				result = this;
				if (!flag)
				{
					Debugger.LogWarning("You cannot change the values of a tween contained inside a Sequence");
					result = this;
				}
			}
			return result;
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0x13EFF3C", Offset = "0x13EFF3C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv12 = *([v10 @ X0_v1]);\n\t*([v12 @ X8_v1+180])(v18, v10, this, relative, *([v12 @ X8_v1+188]), v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tthis.hasManuallySetStartValue = 1;\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override Tweener SetFrom(bool relative)
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
			object obj = 0;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v12 @ X8_v1+180] (should have been resolved before IL gen)");
			this.hasManuallySetStartValue = true;
			return this;
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0x13EFF84", Offset = "0x13EFF84", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([fromValue @ X1 (T2)+10]);\n\tv12 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv14 = fromValue->klass;\n\tv17 = *([v12 @ X0_v1]);\n\t*([v17 @ X8_v1+190])(v28, v12, this, &v14 @ V0_v2 (Il2CppClass<T2>), setImmediately, *([v17 @ X8_v1+198]), v29, v30, v31, *([fromValue @ X1 (T2)]), *([fromValue @ X1 (T2)]), v32, v33, v34, v35, v36, v37);\n\tthis.hasManuallySetStartValue = 1;\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Tweener SetFrom(T2 fromValue, bool setImmediately)
		{
			//IL_0020: Expected O, but got I
			//IL_0028: Expected I, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [fromValue @ X1 (T2)+10]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
			object obj = 0;
			intPtr = (IntPtr)fromValue;
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v17 @ X8_v1+190] (should have been resolved before IL gen)");
			this.hasManuallySetStartValue = true;
			return this;
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0x13EFFF4", Offset = "0x13EFFF4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.Tween::Reset(this);\n\tv29 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv30 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]) == 0;\n\tif (v30) goto L_0013;\n\tv31 = *([v29 @ X0_v3]);\n\t*([v31 @ X8_v3+170])(v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]), this, *([v31 @ X8_v3+178]), v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0013:\n\tv43 = this + 0x17C;\n\tv45 = 0x1084C74(v43, 0, *([v31 @ X8_v3+178]), v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tthis.hasManuallySetStartValue = 0x100;\n\t*([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]) = 0;\n\t*([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+188]) = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal sealed override void Reset()
		{
			//IL_0016: Expected O, but got I
			//IL_005e: Expected O, but got I
			base.Reset();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ X8_v3+170] (should have been resolved before IL gen)");
			}
			object obj3 = (long)(IntPtr)this + 380L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1084C74 (inside DG.Tweening.Plugins.LongPlugin::.ctor +0x50)");
			this.hasManuallySetStartValue = false;
			_ = 0;
			_ = 0;
		}

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0x13F0054", Offset = "0x13F0054", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB5058]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028B41]) = v41;\nL_0016:\n\tv43 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]) == 0;\n\tif (v43) goto L_0026;\n\tv50 = DG.Tweening.Core.DOGetter`1<T1>::Invoke(*([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]));\nL_0025:\n\treturn returnVal1;\nL_0026:\n\tv52 = new System.NullReferenceException();\n\tv55 = v114 != 1;\n\tif (v55) goto L_004D;\n\tv127 = 0x6D2BC0(v52, v114, v101, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv91 = *([v127 @ X0_v10]);\n\tv139 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v91 @ X8_v5]), v101, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv140 = v139 & 1;\n\tv87 = v140 == 0;\n\tif (v87) goto L_0043;\n\tv141 = 0x6D2490(v139, *([v91 @ X8_v5]), v101, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0025;\nL_0043:\n\tv143 = 0x6D1E60(8, *([v91 @ X8_v5]), v101, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v143 @ X0_v14]) = *([v127 @ X0_v10]);\n\tv114 = 0x1E8A000 + 0x870;\n\tv145 = 0x6D2A00(v143, v114, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = 0x6D2490(v145, v114, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004D:\n\tv136 = 0x6D2380(v121, v114, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = 0x846AA4(v136, v114, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool Validate()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]");
				T1 val = ((DOGetter<T1>)0)();
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			bool flag = intPtr != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj4 = obj2;
				intPtr = (IntPtr)(32022528 + 2160);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0x13F0144", Offset = "0x13F0144", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), methodof(DG.Tweening.Tweener::DoUpdateDelay), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, elapsed @ V0 (System.Single), v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn V0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override float UpdateDelay(float elapsed)
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
			return 0f;
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0x13F0158", Offset = "0x13F0158", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Il2CppMethodInfo;\n\tv4 = *([v3 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 4 IndirectJump v4 @ X2_v1, this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), methodof(DG.Tweening.Tweener::DoStartup), v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool Startup()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0x13F016C", Offset = "0x13F016C", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\tgoto L_0019;\n\tv28 = *([1EC9380]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode, updateNotice, methodInfo, v35, prevPosition, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2028B42]) = v46;\nL_0019:\n\tv48 = useInversePosition == 0;\n\tif (v48) goto L_0023;\n\tv51 = this.duration;\n\tv57 = this.duration - this.<position>k__BackingField;\n\tgoto L_002A;\nL_0023:\n\tv57 = this.<position>k__BackingField;\nL_002A:\n\tgoto L_0033;\n\tv100 = *([v63 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tgoto L_0033;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v63, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode, updateNotice, methodInfo, v35, v59, v58, v38, v39, v40, v41, v42, v43);\n\tv104 = DG.Tweening.DOTween;\nL_0033:\n\tv93 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv109 = ~v107.useSafeMode;\n\tif (v109) goto L_006A;\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]);\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+11C]);\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+16C]);\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]);\n\tv129 = v93 == 0;\n\tif (v129) goto L_00A4;\n\tv157 = *([v93 @ X0_v8]);\n\t*([v14 @ X29_v1-50]) = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]);\n\t*([v14 @ X29_v1-40]) = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]);\n\tv171 = this.<isRelative>k__BackingField == 0;\n\tv176 = ~v171;\n\tv179 = &v15 @ stack_-10_v2 - 0x50;\n\t*([v157 @ X9_v16+1E0])(v186, v93, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+17C]), this, v176, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+188]), v179, &v51 @ V0_v18 (System.Single), v57, this.duration, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v41, v42, v43);\n\tgoto L_FFFFFFFF;\nL_006A:\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]);\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+11C]);\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+16C]);\n\tv51 = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]);\n\tv187 = *([v93 @ X0_v8]);\n\t*([v14 @ X29_v1-50]) = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]);\n\t*([v14 @ X29_v1-40]) = *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]);\n\tv201 = this.<isRelative>k__BackingField == 0;\n\tv206 = ~v201;\n\tv209 = &v15 @ stack_-10_v2 - 0x50;\n\t*([v187 @ X9_v10+1E0])(v216, v93, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+17C]), this, v206, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+188]), v209, &v51 @ V0_v18 (System.Single), v57, this.duration, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v41, v42, v43);\nL_00A1:\n\treturn v320;\n\tv99 = new System.NullReferenceException();\nL_00A4:\n\tv132 = new System.NullReferenceException();\n\tv156 = v219 != 1;\n\tif (v156) goto L_00DB;\n\tv218 = 0x6D2BC0(v132, v219, v221, useInversePosition, v110, v111, methodInfo, v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v124, v38, v39, v40, v41, v42, v43);\n\tv270 = *([v218 @ X0_v21]);\n\tv273 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v270 @ X8_v14]), v221, useInversePosition, v110, v111, methodInfo, v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v124, v38, v39, v40, v41, v42, v43);\n\tv333 = v273 & 1;\n\tv228 = v333 == 0;\n\tif (v228) goto L_00D1;\n\tv376 = 0x6D2490(v273, *([v270 @ X8_v14]), v221, useInversePosition, v110, v111, methodInfo, v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v124, v38, v39, v40, v41, v42, v43);\n\tv388 = *([v131 @ X22_v7 (Il2CppClass<DG.Tweening.DOTween>)]);\n\tgoto L_00CD;\n\tv385 = *([v379 @ X0_v29+E0]);\n\tv386 = v385 == 0;\n\tv387 = ~v386;\n\tif (v387) goto L_00CD;\n\tv392 = \"il2cpp_codegen_runtime_class_init\"(v379, v271, newCompletedSteps, useInversePosition, v110, v111, methodInfo, v35, v125, v124, v38, v39, v40, v41, v42, v43);\n\tv389 = *([v131 @ X22_v7 (Il2CppClass<DG.Tweening.DOTween>)]);\nL_00CD:\n\tv391 = *([v388 @ X0_v30+B8]) + 0x68;\n\tv317 = 0x1075B9C(v391, 1, 0, useInversePosition, v110, v111, methodInfo, v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v124, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A1;\nL_00D1:\n\tv378 = 0x6D1E60(8, *([v270 @ X8_v14]), v221, useInversePosition, v110, v111, methodInfo, v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v124, v38, v39, v40, v41, v42, v43);\n\t*([v378 @ X0_v25]) = *([v218 @ X0_v21]);\n\tv219 = 0x1E8A000 + 0x870;\n\tv384 = 0x6D2A00(v378, v219, 0, useInversePosition, v110, v111, methodInfo, v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v124, v38, v39, v40, v41, v42, v43);\n\tv226 = 0x6D2490(v384, v219, 0, useInversePosition, v110, v111, methodInfo, v35, *([this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v124, v38, v39, v40, v41, v42, v43);\nL_00DB:\n\tv234 = 0x6D2380(v229, v219, 0, useInversePosition, v110, v111, methodInfo, v35, v51, v124, v38, v39, v40, v41, v42, v43);\n\treturnVal2 = 0x846AA4(v234, v219, 0, useInversePosition, v110, v111, methodInfo, v35, v51, v124, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice)
		{
			//IL_02c4: Expected O, but got I
			//IL_0107: Expected F4, but got I
			//IL_0117: Expected F4, but got I
			//IL_0127: Expected F4, but got I
			//IL_0137: Expected F4, but got I
			//IL_0189: Expected O, but got I
			//IL_004e: Expected F4, but got I
			//IL_005e: Expected F4, but got I
			//IL_006e: Expected F4, but got I
			//IL_007e: Expected F4, but got I
			//IL_00e8: Expected O, but got I
			//IL_0228: Expected O, but got I
			//IL_0302: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			if (useInversePosition)
			{
				float num = this.duration;
				float num2 = this.duration - this._003Cposition_003Ek__BackingField;
			}
			else
			{
				float num2 = this._003Cposition_003Ek__BackingField;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
			object obj3 = 0;
			if (DOTween.useSafeMode)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]");
				float num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+11C]");
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+16C]");
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]");
				num = 0f;
				if (obj3 == null)
				{
					NullReferenceException ex = new NullReferenceException();
					int num3 = default(int);
					bool flag = num3 != 1;
					NullReferenceException ex2 = ex;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj5 = default(object);
						object obj4 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj6 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							IntPtr intPtr = default(IntPtr);
							object obj7 = (long)intPtr;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ X0_v30+B8]");
							object obj8 = 0L + 104L;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1075B9C (inside DG.Tweening.Core.Easing.Flash::WeightedEase +0x170)");
							return true;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj9 = obj5;
						num3 = 32022528 + 2160;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					bool result = default(bool);
					return result;
				}
				object obj10 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]");
				_ = 0;
				bool flag2 = !this._003CisRelative_003Ek__BackingField;
				bool flag3 = !flag2;
				object obj11 = (long)(IntPtr)obj2 - 80L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v157 @ X9_v16+1E0] (should have been resolved before IL gen)");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]");
				float num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+11C]");
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+16C]");
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]");
				num = 0f;
				object obj12 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]");
				_ = 0;
				bool flag4 = !this._003CisRelative_003Ek__BackingField;
				bool flag5 = !flag4;
				object obj13 = (long)(IntPtr)obj2 - 80L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v187 @ X9_v10+1E0] (should have been resolved before IL gen)");
			}
			return false;
		}
	}
}
