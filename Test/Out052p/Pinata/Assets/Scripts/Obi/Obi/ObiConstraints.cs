using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000015")]
	public class ObiConstraints<T> : IObiConstraints where T : class, IObiConstraintsBatch
	{
		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x0")]
		protected ObiActor actor;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x0")]
		protected ObiConstraints<T> source;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x0")]
		protected bool inSolver;

		[HideInInspector]
		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x0")]
		public List<T> batches;

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x10A5F9C", Offset = "0x10A5F9C", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = *([1EFFAE8]);\n\tv31 = *([v30 @ X8_v40]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, actor, source, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026B0D]) = v47;\nL_0023:\n\tgoto L_0027;\n\tv58 = v53;\n\tv59 = 0x8907BC(v58, actor, source, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0027:\n\tv62 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv68 = System.Collections.Generic.List`1<T>::.ctor(v62);\n\tthis.batches = v62;\n\tv69 = this == 0;\n\tif (v69) goto L_008D;\n\tSystem.Object::.ctor(this);\n\tthis.actor = actor;\n\tthis.source = source;\n\tv138 = source == 0;\n\tif (v138) goto L_00F6;\n\tv162 = source.batches == 0;\n\tif (v162) goto L_008D;\n\tv243 = System.Collections.Generic.List`1<T>::GetEnumerator(source.batches);\nL_004B:\n\tv347 = 0xEF9AB0(&v114 @ stack_-60_v10 (System.Int32), Il2CppMethodInfo, v181, methodInfo, v33, v34, v35, v36, v213, v38, v39, v40, v41, v42, v43, v44);\n\tv353 = v347 & 1;\n\tv354 = v353 == 0;\n\tif (v354) goto L_FFFFFFFF;\n\tv360 = *([v171 @ stack_-78]);\n\tv341 = *([v360 @ X8_v31+126]) == 0;\n\tif (v341) goto L_0074;\n\tv446 = *([v360 @ X8_v31+B0]) + 8;\nL_005F:\n\tv451 = *([v446 @ X11_v15-8]) == Obi.IObiConstraintsBatch;\n\tif (v451) goto L_0077;\n\tv445 = v445 + 1;\n\tv486 = v445 < *([v360 @ X8_v31+126]);\n\tv415 = ~v486;\n\tv446 = v446 + 0x10;\n\tv399 = ~v415;\n\tif (v399) goto L_005F;\nL_0074:\n\tv493 = 0x8909C4(v171, Obi.IObiConstraintsBatch, 7, methodInfo, v33, v34, v35, v36, v213, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_007E;\nL_0077:\n\tv488 = *([v446 @ X11_v15]) + 7;\n\tv489 = v488 << 4;\n\tv490 = v360 + v489;\n\tv493 = v490 + 0x130;\nL_007E:\n\t*([v493 @ X0_v35])(v498, v171, *([v493 @ X0_v35+8]), v181, methodInfo, v33, v34, v35, v36, v213, v38, v39, v40, v41, v42, v43, v44);\n\tv339 = Obi.ObiConstraints`1<T>::AddBatch(this, v498);\n\tgoto L_004B;\n\tgoto L_00A2;\n\tthrow System.NullReferenceException;\nL_008D:\n\tv166 = new System.NullReferenceException();\n\tgoto L_009A;\n\tgoto L_009A;\n\tgoto L_009A;\nL_009A:\n\tv319 = v293 != 1;\n\tif (v319) goto L_00FB;\n\tv348 = 0x6D2BC0(v166, v293, v181, methodInfo, v33, v34, v35, v36, v287, v38, v39, v40, v41, v42, v43, v44);\n\tv222 = *([v348 @ X0_v20]);\n\tv356 = 0x6D2490(v348, v293, v181, methodInfo, v33, v34, v35, v36, v287, v38, v39, v40, v41, v42, v43, v44);\nL_00A2:\n\tv228 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_00AD;\n\tv423 = v228;\n\tv424 = 0x8907BC(v423, v382, v365, methodInfo, v33, v34, v35, v36, v379, v38, v39, v40, v41, v42, v43, v44);\nL_00AD:\n\tv213 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv224 = &v213 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>) + 0x10;\n\tv434 = *([v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v434) goto L_00D6;\n\tv511 = *([v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_00C1:\n\tv518 = *([v511 @ X10_v6-8]) == System.IDisposable;\n\tif (v518) goto L_00D9;\n\tv513 = v513 + 1;\n\tv523 = v513 < *([v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv476 = ~v523;\n\tv511 = v511 + 0x10;\n\tv460 = ~v476;\n\tif (v460) goto L_00C1;\nL_00D6:\n\tv533 = 0x8909C4(&v213 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, methodInfo, v33, v34, v35, v36, 0, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00DF;\nL_00D9:\n\tv525 = *([v511 @ X10_v6]) << 4;\n\tv526 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v525;\n\tv533 = v526 + 0x130;\nL_00DF:\n\t*([v533 @ X0_v8])(v217, &v213 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v533 @ X0_v8+8]), v181, methodInfo, v33, v34, v35, v36, 0, v38, v39, v40, v41, v42, v43, v44);\n\tv287 = *([v224 @ X22_v3]);\n\tv220 = v226 + 1;\n\tv193 = v220 == 0;\n\tv183 = ~v193;\n\tif (v183) goto L_00F6;\n\tv537 = v222 == 0;\n\tv219 = ~v537;\n\tif (v219) goto L_00FA;\nL_00F6:\n\treturn;\nL_00FA:\n\tv352 = new System.TypeLoadException();\nL_00FB:\n\tv295 = 0x6D2380(v166, v293, v181, methodInfo, v33, v34, v35, v36, v287, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n// 160 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiConstraints(ObiActor actor = null, ObiConstraints<T> source = null)
		{
			//IL_002d: Expected O, but got I
			//IL_021f: Expected I4, but got O
			//IL_00aa: Expected I, but got O
			//IL_0251: Expected O, but got I
			//IL_028c: Expected O, but got I
			//IL_0192: Expected O, but got I4
			//IL_0313: Expected I4, but got O
			//IL_031e: Expected O, but got I
			//IL_032d: Expected O, but got I
			//IL_03e1: Expected O, but got I
			//IL_011a: Expected O, but got I
			//IL_036e: Expected I, but got O
			//IL_02d8: Expected O, but got I
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Expected O, but got Unknown
			//IL_01c2: Expected O, but got I
			//IL_01d1: Expected O, but got I
			//IL_0166: Expected O, but got I
			batches = new List<T>();
			bool flag = this == null;
			IntPtr intPtr = default(IntPtr);
			object obj = (long)intPtr;
			IntPtr intPtr2 = (IntPtr)0;
			int num5;
			int num6;
			ObiConstraints<T> obiConstraints;
			if (!flag)
			{
				base._002Ector();
				this.actor = actor;
				this.source = source;
				if (source == null)
				{
					return;
				}
				bool flag2 = source.batches == null;
				obiConstraints = source;
				int num = 0;
				object obj2 = default(object);
				obj = obj2;
				intPtr2 = (IntPtr)null;
				if (!flag2)
				{
					List<T>.Enumerator enumerator = source.batches.GetEnumerator();
					obiConstraints = source;
					object obj3 = default(object);
					object obj5 = default(object);
					IObiConstraintsBatch batch = default(IObiConstraintsBatch);
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
						if ((int)((long)(IntPtr)obj3 & 1L) == 0)
						{
							break;
						}
						object obj4 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ X8_v31+126]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ X8_v31+B0]");
							object obj6 = 0L + 8L;
							int num2 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ X11_v15-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
								{
									break;
								}
								num2++;
								int num3 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ X8_v31+126]");
								bool flag3 = (long)num3 < 0L;
								bool flag4 = !flag3;
								obj6 = (long)(IntPtr)obj6 + 16L;
								if (!flag4)
								{
									continue;
								}
								goto IL_017f;
							}
							object obj7 = obj6 + 7;
							int num4 = (int)((long)(IntPtr)obj7 << 4);
							object obj8 = (long)(IntPtr)obj4 + (long)num4;
							object obj9 = (long)(IntPtr)obj8 + 304L;
							goto IL_03c3;
						}
						goto IL_017f;
						IL_017f:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						obiConstraints = (ObiConstraints<T>)7;
						goto IL_03c3;
						IL_03c3:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v493 @ X0_v35] (should have been resolved before IL gen)");
						bool flag5 = AddBatch(batch);
						obiConstraints = (ObiConstraints<T>)0;
					}
					num5 = 0;
					num6 = 0;
					goto IL_03e6;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (intPtr2 != (IntPtr)1)
			{
				goto IL_037b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj10 = default(object);
			num5 = (int)obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			num6 = -1;
			goto IL_03e6;
			IL_037b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_02f1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			obiConstraints = null;
			goto IL_041b;
			IL_03e6:
			IntPtr intPtr3 = (IntPtr)0;
			intPtr = (IntPtr)0;
			object obj11 = (long)intPtr + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_02f1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
			object obj12 = 0L + 8L;
			int num7 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ X10_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num7++;
				int num8 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
				bool flag6 = (long)num8 < 0L;
				bool flag7 = !flag6;
				obj12 = (long)(IntPtr)obj12 + 16L;
				if (!flag7)
				{
					continue;
				}
				goto IL_02f1;
			}
			int num9 = obj12 << 4;
			object obj13 = 0L + (long)num9;
			object obj14 = (long)(IntPtr)obj13 + 304L;
			goto IL_041b;
			IL_041b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v533 @ X0_v8] (should have been resolved before IL gen)");
			obj = obj11;
			if (num6 + 1 != 0 || num5 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			obiConstraints = null;
			intPtr2 = (IntPtr)null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_037b;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x10A624C", Offset = "0x10A624C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv27 = v22;\n\tv28 = 0x8907BC(v27, actor, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0016:\n\tv44 = new Il2CppClass<Obi.ObiConstraints`1<T>>();\n\tv52 = Obi.ObiConstraints`1<T>::.ctor(v44, actor, this);\n\treturn v44;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IObiConstraints Clone(ObiActor actor)
		{
			return new ObiConstraints<T>(actor, this);
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x10A62C0", Offset = "0x10A62C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.actor;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiActor GetActor()
		{
			return actor;
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x10A62C8", Offset = "0x10A62C8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.batches;\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 5 IndirectJump v6 @ X2_v1, v2 @ X0_v1 (System.Collections.Generic.List`1<T>), v2 @ X0_v1 (System.Collections.Generic.List`1<T>), methodof(Obi.ListExtensions::CastList), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\treturn X0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IList<IObiConstraintsBatch> GetBatchInterfaces()
		{
			//IL_0018: Expected O, but got I
			List<T> list = batches;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x10A62E0", Offset = "0x10A62E0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.batches;\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X2_v1, v0 @ X0_v1 (System.Collections.Generic.List`1<T>), v0 @ X0_v1 (System.Collections.Generic.List`1<T>), methodof(System.Collections.Generic.List`1<T>::get_Count), v7 @ X2_v1, v8 @ X3, v9 @ X4, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetBatchCount()
		{
			//IL_001d: Expected O, but got I
			List<T> list = batches;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X2_v1 (should have been resolved before IL gen)");
			return 0;
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0x10A6308", Offset = "0x10A6308", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EA4000]);\n\tv27 = *([v26 @ X8_v29]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2026B0E]) = v45;\nL_001B:\n\tv50 = this.batches == 0;\n\tif (v50) goto L_0069;\n\tv57 = System.Collections.Generic.List`1<T>::GetEnumerator(this.batches);\n\tgoto L_005F;\nL_0032:\n\tgoto L_0059;\n\tv287 = *([v271 @ X8_v23+B0]);\n\tv288 = 0;\n\tv289 = v287 + 8;\n\tv291 = *([v402 @ X11_v13-8]);\n\tv407 = v291 == v272;\n\tif (v407) goto L_0052;\n\tv311 = v401 + 1;\n\tv433 = v311 < v273;\n\tv309 = ~v433;\n\tv313 = v402 + 0x10;\n\tv293 = ~v309;\n\tif (v293) goto L_FFFFFFFF;\n\tv314 = v128;\n\tv315 = 0;\n\tv316 = 0x8909C4(v314, v272, v315, v30, v31, v32, v33, v34, v60, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0059;\nL_0052:\n\tv434 = *([v402 @ X11_v13]);\n\tv435 = v434 << 4;\n\tv436 = v271 + v435;\n\tv437 = v436 + 0x130;\nL_0059:\n\tv149 = Obi.IObiConstraintsBatch::get_constraintCount(v59);\n\tv232 = v149 + v232;\nL_005F:\n\tv158 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(&v108 @ stack_-60_v8 (System.Collections.Generic.List`1<T>+Enumerator<T>));\n\tv160 = v158 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0032;\n\tgoto L_007D;\n\tv120 = new System.NullReferenceException();\nL_0069:\n\tv129 = new System.NullReferenceException();\n\tgoto L_0075;\n\tgoto L_0075;\nL_0075:\n\tv171 = Il2CppMethodInfo != 1;\n\tif (v171) goto L_00D7;\n\tv174 = 0x6D2BC0(v129, Il2CppMethodInfo, v327, v30, v31, v32, v33, v34, v224, v36, v37, v38, v39, v40, v41, v42);\n\tv238 = *([v174 @ X0_v20]);\n\tv261 = 0x6D2490(v174, Il2CppMethodInfo, v327, v30, v31, v32, v33, v34, v224, v36, v37, v38, v39, v40, v41, v42);\nL_007D:\n\tv234 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_0088;\n\tv275 = v234;\n\tv276 = 0x8907BC(v275, v259, v241, v30, v31, v32, v33, v34, v256, v36, v37, v38, v39, v40, v41, v42);\nL_0088:\n\tv224 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv178 = &v224 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>) + 0x10;\n\tv286 = *([v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v286) goto L_00B1;\n\tv421 = *([v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_009C:\n\tv428 = *([v421 @ X10_v6-8]) == System.IDisposable;\n\tif (v428) goto L_00B4;\n\tv423 = v423 + 1;\n\tv441 = v423 < *([v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv381 = ~v441;\n\tv421 = v421 + 0x10;\n\tv365 = ~v381;\n\tif (v365) goto L_009C;\nL_00B1:\n\tv451 = 0x8909C4(&v224 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, v30, v31, v32, v33, v34, v108, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00BA;\nL_00B4:\n\tv443 = *([v421 @ X10_v6]) << 4;\n\tv444 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v443;\n\tv451 = v444 + 0x130;\nL_00BA:\n\t*([v451 @ X0_v5])(v455, &v224 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v451 @ X0_v5+8]), v327, v30, v31, v32, v33, v34, v108, v36, v37, v38, v39, v40, v41, v42);\n\tv219 = *([v178 @ X23_v1]);\n\tv456 = v218 + 1;\n\tv202 = v456 == 0;\n\tv192 = ~v202;\n\tif (v192) goto L_00D2;\n\tv457 = v238 == 0;\n\tv230 = ~v457;\n\tif (v230) goto L_00D6;\nL_00D2:\n\treturn v232;\nL_00D6:\n\tv228 = new System.TypeLoadException();\nL_00D7:\n\treturnVal1 = 0x6D2380(v129, v225, v327, v30, v31, v32, v33, v34, v219, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetConstraintCount()
		{
			//IL_0210: Expected O, but got I
			//IL_0080: Expected I4, but got O
			//IL_0274: Expected O, but got I
			//IL_00b2: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_01c4: Expected I4, but got O
			//IL_0178: Expected I4, but got O
			//IL_0183: Expected O, but got I
			//IL_0192: Expected O, but got I
			//IL_01db: Expected I, but got O
			//IL_0139: Expected O, but got I
			bool flag = batches == null;
			IntPtr intPtr = default(IntPtr);
			object obj = (long)intPtr;
			IntPtr intPtr2 = (IntPtr)0;
			ObiConstraints<T> obiConstraints = default(ObiConstraints<T>);
			int num3;
			int num4;
			int num;
			NullReferenceException ex;
			if (!flag)
			{
				List<T>.Enumerator enumerator = batches.GetEnumerator();
				int num2 = default(int);
				num = num2;
				obiConstraints = null;
				List<T>.Enumerator enumerator2 = default(List<T>.Enumerator);
				IObiConstraintsBatch obiConstraintsBatch = default(IObiConstraintsBatch);
				while (enumerator2.MoveNext())
				{
					int constraintCount = obiConstraintsBatch.constraintCount;
					obiConstraints = (ObiConstraints<T>)((long)constraintCount + (long)(IntPtr)obiConstraints);
					num = 0;
				}
				num3 = 0;
				num4 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					goto IL_01e8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj2 = default(object);
				num4 = (int)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num3 = -1;
			}
			IntPtr intPtr3 = (IntPtr)0;
			intPtr = (IntPtr)0;
			object obj3 = (long)intPtr + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0152;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
			object obj4 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ X10_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
				bool flag2 = (long)num6 < 0L;
				bool flag3 = !flag2;
				obj4 = (long)(IntPtr)obj4 + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_0152;
			}
			int num7 = obj4 << 4;
			object obj5 = 0L + (long)num7;
			object obj6 = (long)(IntPtr)obj5 + 304L;
			goto IL_02b7;
			IL_0152:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num = 0;
			goto IL_02b7;
			IL_02b7:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v451 @ X0_v5] (should have been resolved before IL gen)");
			obj = obj3;
			if (num3 + 1 != 0 || num4 == 0)
			{
				return (int)obiConstraints;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			intPtr2 = (IntPtr)null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_01e8;
			IL_01e8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			int result = default(int);
			return result;
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0x10A653C", Offset = "0x10A653C", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EC17E0]);\n\tv27 = *([v26 @ X8_v29]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2026B0F]) = v45;\nL_001B:\n\tv50 = this.batches == 0;\n\tif (v50) goto L_006A;\n\tv57 = System.Collections.Generic.List`1<T>::GetEnumerator(this.batches);\n\tgoto L_0060;\nL_002E:\n\tv271 = *([v59 @ stack_-78]);\n\tv151 = *([v271 @ X8_v23+126]) == 0;\n\tif (v151) goto L_0050;\n\tv402 = *([v271 @ X8_v23+B0]) + 8;\nL_003B:\n\tv407 = *([v402 @ X11_v13-8]) == Obi.IObiConstraintsBatch;\n\tif (v407) goto L_0053;\n\tv401 = v401 + 1;\n\tv433 = v401 < *([v271 @ X8_v23+126]);\n\tv309 = ~v433;\n\tv402 = v402 + 0x10;\n\tv293 = ~v309;\n\tif (v293) goto L_003B;\nL_0050:\n\tv439 = 0x8909C4(v59, Obi.IObiConstraintsBatch, 1, v30, v31, v32, v33, v34, v224, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_005A;\nL_0053:\n\tv435 = *([v402 @ X11_v13]) + 1;\n\tv436 = v435 << 4;\n\tv437 = v271 + v436;\n\tv439 = v437 + 0x130;\nL_005A:\n\t*([v439 @ X0_v28])(v149, v59, *([v439 @ X0_v28+8]), v327, v30, v31, v32, v33, v34, v224, v36, v37, v38, v39, v40, v41, v42);\n\tv232 = v149 + v232;\nL_0060:\n\tv158 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(&v108 @ stack_-60_v8 (System.Collections.Generic.List`1<T>+Enumerator<T>));\n\tv160 = v158 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_002E;\n\tgoto L_007E;\n\tv120 = new System.NullReferenceException();\nL_006A:\n\tv129 = new System.NullReferenceException();\n\tgoto L_0076;\n\tgoto L_0076;\nL_0076:\n\tv171 = Il2CppMethodInfo != 1;\n\tif (v171) goto L_00D8;\n\tv174 = 0x6D2BC0(v129, Il2CppMethodInfo, v327, v30, v31, v32, v33, v34, v224, v36, v37, v38, v39, v40, v41, v42);\n\tv238 = *([v174 @ X0_v20]);\n\tv261 = 0x6D2490(v174, Il2CppMethodInfo, v327, v30, v31, v32, v33, v34, v224, v36, v37, v38, v39, v40, v41, v42);\nL_007E:\n\tv234 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_0089;\n\tv275 = v234;\n\tv276 = 0x8907BC(v275, v259, v241, v30, v31, v32, v33, v34, v256, v36, v37, v38, v39, v40, v41, v42);\nL_0089:\n\tv224 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv178 = &v224 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>) + 0x10;\n\tv286 = *([v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v286) goto L_00B2;\n\tv421 = *([v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_009D:\n\tv428 = *([v421 @ X10_v6-8]) == System.IDisposable;\n\tif (v428) goto L_00B5;\n\tv423 = v423 + 1;\n\tv442 = v423 < *([v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv381 = ~v442;\n\tv421 = v421 + 0x10;\n\tv365 = ~v381;\n\tif (v365) goto L_009D;\nL_00B2:\n\tv452 = 0x8909C4(&v224 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, v30, v31, v32, v33, v34, v108, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00BB;\nL_00B5:\n\tv444 = *([v421 @ X10_v6]) << 4;\n\tv445 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v444;\n\tv452 = v445 + 0x130;\nL_00BB:\n\t*([v452 @ X0_v5])(v456, &v224 @ stack_-88_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v452 @ X0_v5+8]), v327, v30, v31, v32, v33, v34, v108, v36, v37, v38, v39, v40, v41, v42);\n\tv219 = *([v178 @ X23_v1]);\n\tv457 = v218 + 1;\n\tv202 = v457 == 0;\n\tv192 = ~v202;\n\tif (v192) goto L_00D3;\n\tv458 = v238 == 0;\n\tv230 = ~v458;\n\tif (v230) goto L_00D7;\nL_00D3:\n\treturn v232;\nL_00D7:\n\tv228 = new System.TypeLoadException();\nL_00D8:\n\treturnVal1 = 0x6D2380(v129, v225, v327, v30, v31, v32, v33, v34, v219, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetActiveConstraintCount()
		{
			//IL_030a: Expected O, but got I
			//IL_017a: Expected I4, but got O
			//IL_0396: Expected O, but got I
			//IL_0069: Expected O, but got I
			//IL_01ac: Expected O, but got I
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_0111: Expected O, but got I
			//IL_0120: Expected O, but got I
			//IL_01e7: Expected O, but got I
			//IL_00b5: Expected O, but got I
			//IL_02be: Expected I4, but got O
			//IL_0272: Expected I4, but got O
			//IL_027d: Expected O, but got I
			//IL_028c: Expected O, but got I
			//IL_02d5: Expected I, but got O
			//IL_0233: Expected O, but got I
			bool flag = batches == null;
			IntPtr intPtr = default(IntPtr);
			object obj = (long)intPtr;
			IntPtr intPtr2 = (IntPtr)0;
			ObiConstraints<T> obiConstraints = default(ObiConstraints<T>);
			int num6;
			int num7;
			NullReferenceException ex;
			int num;
			if (!flag)
			{
				List<T>.Enumerator enumerator = batches.GetEnumerator();
				int num2 = default(int);
				num = num2;
				List<T>.Enumerator enumerator2 = default(List<T>.Enumerator);
				object obj8 = default(object);
				object obj3 = default(object);
				for (obiConstraints = null; enumerator2.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v439 @ X0_v28] (should have been resolved before IL gen)"), obiConstraints = (ObiConstraints<T>)((long)(IntPtr)obj8 + (long)(IntPtr)obiConstraints))
				{
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ X8_v23+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ X8_v23+B0]");
						object obj4 = 0L + 8L;
						int num3 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X11_v13-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ X8_v23+126]");
							bool flag2 = (long)num4 < 0L;
							bool flag3 = !flag2;
							obj4 = (long)(IntPtr)obj4 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_00ce;
						}
						object obj5 = obj4 + 1;
						int num5 = (int)((long)(IntPtr)obj5 << 4);
						object obj6 = (long)(IntPtr)obj2 + (long)num5;
						object obj7 = (long)(IntPtr)obj6 + 304L;
						continue;
					}
					goto IL_00ce;
					IL_00ce:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num = 1;
				}
				num6 = 0;
				num7 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					goto IL_02e2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj9 = default(object);
				num7 = (int)obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num6 = -1;
			}
			IntPtr intPtr3 = (IntPtr)0;
			intPtr = (IntPtr)0;
			object obj10 = (long)intPtr + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_024c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
			object obj11 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ X10_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X20_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
				bool flag4 = (long)num9 < 0L;
				bool flag5 = !flag4;
				obj11 = (long)(IntPtr)obj11 + 16L;
				if (!flag5)
				{
					continue;
				}
				goto IL_024c;
			}
			int num10 = obj11 << 4;
			object obj12 = 0L + (long)num10;
			object obj13 = (long)(IntPtr)obj12 + 304L;
			goto IL_03d0;
			IL_03d0:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v452 @ X0_v5] (should have been resolved before IL gen)");
			obj = obj10;
			if (num6 + 1 != 0 || num7 == 0)
			{
				return (int)obiConstraints;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			intPtr2 = (IntPtr)null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_02e2;
			IL_02e2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			int result = default(int);
			return result;
			IL_024c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num = 0;
			goto IL_03d0;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0x10A6774", Offset = "0x10A6774", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EA3DC0]);\n\tv25 = *([v24 @ X8_v29]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026B10]) = v43;\nL_001A:\n\tv48 = this.batches == 0;\n\tif (v48) goto L_0066;\n\tv55 = System.Collections.Generic.List`1<T>::GetEnumerator(this.batches);\nL_002C:\n\tv152 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(&v105 @ stack_-50_v8 (System.Collections.Generic.List`1<T>+Enumerator<T>));\n\tv154 = v152 == 0;\n\tif (v154) goto L_FFFFFFFF;\n\tv231 = *([v57 @ stack_-68]);\n\tv146 = *([v231 @ X8_v23+126]) == 0;\n\tif (v146) goto L_0055;\n\tv361 = *([v231 @ X8_v23+B0]) + 8;\nL_0040:\n\tv366 = *([v361 @ X11_v13-8]) == Obi.IObiConstraintsBatch;\n\tif (v366) goto L_0058;\n\tv360 = v360 + 1;\n\tv401 = v360 < *([v231 @ X8_v23+126]);\n\tv288 = ~v401;\n\tv361 = v361 + 0x10;\n\tv272 = ~v288;\n\tif (v272) goto L_0040;\nL_0055:\n\tv407 = 0x8909C4(v57, Obi.IObiConstraintsBatch, 0xC, v28, v29, v30, v31, v32, v215, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_005F;\nL_0058:\n\tv403 = *([v361 @ X11_v13]) + 0xC;\n\tv404 = v403 << 4;\n\tv405 = v231 + v404;\n\tv407 = v405 + 0x130;\nL_005F:\n\t*([v407 @ X0_v27])(v144, v57, *([v407 @ X0_v27+8]), v318, v28, v29, v30, v31, v32, v215, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_002C;\n\tgoto L_007A;\n\tv116 = new System.NullReferenceException();\nL_0066:\n\tv124 = new System.NullReferenceException();\n\tgoto L_0072;\n\tgoto L_0072;\nL_0072:\n\tv164 = Il2CppMethodInfo != 1;\n\tif (v164) goto L_00D2;\n\tv167 = 0x6D2BC0(v124, Il2CppMethodInfo, v318, v28, v29, v30, v31, v32, v215, v34, v35, v36, v37, v38, v39, v40);\n\tv223 = *([v167 @ X0_v19]);\n\tv255 = 0x6D2490(v167, Il2CppMethodInfo, v318, v28, v29, v30, v31, v32, v215, v34, v35, v36, v37, v38, v39, v40);\nL_007A:\n\tv225 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_0085;\n\tv296 = v225;\n\tv297 = 0x8907BC(v296, v253, v236, v28, v29, v30, v31, v32, v250, v34, v35, v36, v37, v38, v39, v40);\nL_0085:\n\tv215 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv171 = &v215 @ stack_-78_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>) + 0x10;\n\tv307 = *([v225 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v307) goto L_00AE;\n\tv419 = *([v225 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_0099:\n\tv426 = *([v419 @ X10_v6-8]) == System.IDisposable;\n\tif (v426) goto L_00B1;\n\tv421 = v421 + 1;\n\tv431 = v421 < *([v225 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv391 = ~v431;\n\tv419 = v419 + 0x10;\n\tv375 = ~v391;\n\tif (v375) goto L_0099;\nL_00AE:\n\tv441 = 0x8909C4(&v215 @ stack_-78_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, v28, v29, v30, v31, v32, v105, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00B7;\nL_00B1:\n\tv433 = *([v419 @ X10_v6]) << 4;\n\tv434 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v433;\n\tv441 = v434 + 0x130;\nL_00B7:\n\t*([v441 @ X0_v5])(v338, &v215 @ stack_-78_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v441 @ X0_v5+8]), v318, v28, v29, v30, v31, v32, v105, v34, v35, v36, v37, v38, v39, v40);\n\tv210 = *([v171 @ X22_v1]);\n\tv445 = v229 + 1;\n\tv195 = v445 == 0;\n\tv185 = ~v195;\n\tif (v185) goto L_00CD;\n\tv446 = v223 == 0;\n\tv221 = ~v446;\n\tif (v221) goto L_00D1;\nL_00CD:\n\treturn;\nL_00D1:\n\tv219 = new System.TypeLoadException();\nL_00D2:\n\tv230 = 0x6D2380(v124, v216, v318, v28, v29, v30, v31, v32, v210, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DeactivateAllConstraints()
		{
			//IL_02fd: Expected O, but got I
			//IL_0175: Expected I4, but got O
			//IL_01a7: Expected O, but got I
			//IL_0064: Expected O, but got I
			//IL_01e2: Expected O, but got I
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_010c: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_026d: Expected I4, but got O
			//IL_0278: Expected O, but got I
			//IL_0287: Expected O, but got I
			//IL_00b0: Expected O, but got I
			//IL_02cc: Expected I, but got O
			//IL_022e: Expected O, but got I
			bool flag = batches == null;
			IntPtr intPtr = default(IntPtr);
			object obj = (long)intPtr;
			IntPtr intPtr2 = (IntPtr)0;
			int num6;
			int num7;
			NullReferenceException ex;
			int num;
			if (!flag)
			{
				List<T>.Enumerator enumerator = batches.GetEnumerator();
				int num2 = default(int);
				num = num2;
				List<T>.Enumerator enumerator2 = default(List<T>.Enumerator);
				object obj3 = default(object);
				for (; enumerator2.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v407 @ X0_v27] (should have been resolved before IL gen)"))
				{
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v23+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v23+B0]");
						object obj4 = 0L + 8L;
						int num3 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ X11_v13-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v23+126]");
							bool flag2 = (long)num4 < 0L;
							bool flag3 = !flag2;
							obj4 = (long)(IntPtr)obj4 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_00c9;
						}
						object obj5 = obj4 + 12;
						int num5 = (int)((long)(IntPtr)obj5 << 4);
						object obj6 = (long)(IntPtr)obj2 + (long)num5;
						object obj7 = (long)(IntPtr)obj6 + 304L;
						continue;
					}
					goto IL_00c9;
					IL_00c9:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num = 12;
				}
				num6 = 0;
				num7 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					goto IL_02d9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj8 = default(object);
				num6 = (int)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num7 = -1;
			}
			IntPtr intPtr3 = (IntPtr)0;
			intPtr = (IntPtr)0;
			object obj9 = (long)intPtr + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0247;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
			object obj10 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X10_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
				bool flag4 = (long)num9 < 0L;
				bool flag5 = !flag4;
				obj10 = (long)(IntPtr)obj10 + 16L;
				if (!flag5)
				{
					continue;
				}
				goto IL_0247;
			}
			int num10 = obj10 << 4;
			object obj11 = 0L + (long)num10;
			object obj12 = (long)(IntPtr)obj11 + 304L;
			goto IL_037f;
			IL_02d9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_037f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v441 @ X0_v5] (should have been resolved before IL gen)");
			obj = obj9;
			if (num7 + 1 != 0 || num6 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			intPtr2 = (IntPtr)null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_02d9;
			IL_0247:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num = 0;
			goto IL_037f;
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0x10A6998", Offset = "0x10A6998", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = System.Collections.Generic.List`1<T>::get_Count(this.batches);\n\tv45 = v20 < 1;\n\tif (v45) goto L_0030;\n\tv70 = this.batches;\n\tv82 = Il2CppMethodInfo;\n\tv83 = *([v82 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 41 IndirectJump v83 @ X3_v1, v70 @ X0_v6 (System.Collections.Generic.List`1<T>), v70 @ X0_v6 (System.Collections.Generic.List`1<T>), 0, methodof(System.Collections.Generic.List`1<T>::get_Item), v83 @ X3_v1, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0030:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetFirstBatch()
		{
			//IL_0049: Expected O, but got I
			int count = batches.Count;
			if (count >= 1)
			{
				List<T> list = batches;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v83 @ X3_v1 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0x10A6A0C", Offset = "0x10A6A0C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EBD508]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026B11]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.List`1<T>::get_Count(this.batches);\n\tv59 = v48 < 1;\n\tif (v59) goto L_FFFFFFFF;\n\tv84 = System.Collections.Generic.List`1<T>::get_Item(this.batches, 0);\n\tgoto L_0066;\n\tv179 = *([v175 @ X8_v11+B0]);\n\tv180 = 0;\n\tv181 = v179 + 8;\n\tv183 = *([v210 @ X11_v6-8]);\n\tv225 = v183 == v178;\n\tif (v225) goto L_005E;\n\tv187 = v211 + 1;\n\tv230 = v187 < v177;\n\tv205 = ~v230;\n\tv185 = v210 + 0x10;\n\tv189 = ~v205;\n\tif (v189) goto L_FFFFFFFF;\n\tv206 = 5;\n\tv207 = v89;\n\tv208 = 0x8909C4(v207, v178, v206, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0066;\n\tgoto L_0075;\nL_005E:\n\tv231 = *([v210 @ X11_v6]);\n\tv232 = v231 + 5;\n\tv233 = v232 << 4;\n\tv234 = v175 + v233;\n\tv235 = v234 + 0x130;\nL_0066:\n\tv242 = Obi.IObiConstraintsBatch::get_constraintType(v84);\n\tv104 = 0;\n\tv245 = System.Nullable`1<Oni+ConstraintType>::.ctor(&v104 @ stack_-28_v3 (System.Nullable`1<Oni+ConstraintType>), v242);\nL_0075:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Oni.ConstraintType? GetConstraintType()
		{
			int count = batches.Count;
			Oni.ConstraintType? result;
			if (count >= 1)
			{
				IObiConstraintsBatch obiConstraintsBatch = batches.get_Item(0);
				Oni.ConstraintType constraintType = obiConstraintsBatch.constraintType;
				Oni.ConstraintType? constraintType2 = null;
				constraintType2 = constraintType;
				result = null;
			}
			else
			{
				result = null;
			}
			return result;
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0x10A6B40", Offset = "0x10A6B40", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = Obi.ObiConstraints`1<T>::RemoveFromSolver(this);\n\tv35 = this.batches;\n\tv47 = Il2CppMethodInfo;\n\tv48 = *([v47 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 28 IndirectJump v48 @ X2_v1, v35 @ X0_v5 (System.Collections.Generic.List`1<T>), v35 @ X0_v5 (System.Collections.Generic.List`1<T>), methodof(System.Collections.Generic.List`1<T>::Clear), v48 @ X2_v1, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			//IL_0027: Expected O, but got I
			bool flag = RemoveFromSolver();
			List<T> list = batches;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v48 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0x10A6B98", Offset = "0x10A6B98", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv27 = v22;\n\tv28 = 0x8907BC(v27, batch, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0017:\n\t// 23 IsInst v45 @ X0_v3, typeof(T), batch @ X1 (Obi.IObiConstraintsBatch)\n\tgoto L_0023;\n\tv54 = v49;\n\tv55 = 0x8907BC(v54, v44, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0023:\n\tv57 = v45 == 0;\n\tif (v57) goto L_FFFFFFFF;\n\t// 39 IsInst v60 @ X0_v8 (T), typeof(T), v45 @ X0_v3\n\tv63 = v60 == 0;\n\tif (v63) goto L_0041;\n\tv103 = System.Collections.Generic.List`1<T>::Add(this.batches, v60);\n\tgoto L_003E;\nL_003E:\n\treturn returnVal1;\nL_0041:\n\tv85 = new System.InvalidCastException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AddBatch(IObiConstraintsBatch batch)
		{
			//IL_00a5: Expected I4, but got O
			object obj = batch as T;
			if (obj != null)
			{
				T val = obj as T;
				if (val != null)
				{
					batches.Add(val);
					return true;
				}
				InvalidCastException ex = new InvalidCastException();
				NullReferenceException ex2 = new NullReferenceException();
				return (byte)(int)ex2 != 0;
			}
			return false;
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0x10A6C60", Offset = "0x10A6C60", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.batches;\n\tv24 = Il2CppMethodInfo;\n\tv26 = *([v24 @ X8_v3 (Il2CppMethodInfo)]);\n\tgoto L_001C;\n\tv46 = v23;\n\tv47 = 0x8907BC(v46, batch, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_001C:\n\t// 28 IsInst v51 @ X0_v6, typeof(T), batch @ X1 (Obi.IObiConstraintsBatch)\n\tgoto L_0028;\n\tv89 = v55;\n\tv90 = 0x8907BC(v89, v50, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0028:\n\tv92 = v51 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 44 IsInst v95 @ X0_v12 (System.Int32), typeof(T), v51 @ X0_v6\n\tv104 = v95 == 0;\n\tv101 = ~v104;\n\tif (v101) goto L_0041;\n\tthrow System.InvalidCastException;\nL_0041:\n\t// 65 IndirectJump v26 @ X0_v3, v14 @ X20_v1 (System.Collections.Generic.List`1<T>), v14 @ X20_v1 (System.Collections.Generic.List`1<T>), v67 @ X1_v2 (System.Int32), methodof(System.Collections.Generic.List`1<T>::Remove), v26 @ X0_v3, v34 @ X4, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool RemoveBatch(IObiConstraintsBatch batch)
		{
			//IL_001d: Expected O, but got I
			//IL_005e: Expected I4, but got O
			List<T> list = batches;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			object obj2 = batch as T;
			if (obj2 != null)
			{
				if ((int)(obj2 as T) == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				int num = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v26 @ X0_v3 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0x10A6D30", Offset = "0x10A6D30", Length = "0x308")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EE2558]);\n\tv29 = *([v28 @ X8_v46]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026B12]) = v47;\nL_001C:\n\tv52 = ~this.inSolver;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_002F;\n\tv83 = *([v57 @ X0_v5+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002F;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002F:\n\tv73 = UnityEngine.Object::op_Equality(this.actor, 0);\n\tv176 = v73 == 0;\n\tv76 = ~v176;\n\tif (v76) goto L_FFFFFFFF;\n\tv241 = this.actor;\n\tgoto L_0045;\n\tv282 = *([v243 @ X0_v18+E0]);\n\tv283 = v282 == 0;\n\tv284 = ~v283;\n\tif (v284) goto L_0045;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v243, v69, v66, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0045:\n\tv72 = UnityEngine.Object::op_Equality(v241.m_Solver, 0);\n\tv75 = v72 == 0;\n\tif (v75) goto L_0056;\nL_0053:\n\treturn returnVal1;\nL_0056:\n\tthis.inSolver = 1;\n\tv392 = System.Collections.Generic.List`1<T>::GetEnumerator(this.batches);\nL_0069:\n\tv432 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(&v374 @ stack_-60_v9 (System.Collections.Generic.List`1<T>+Enumerator<T>));\n\tv434 = v432 == 0;\n\tif (v434) goto L_FFFFFFFF;\n\tv384 = v96 == 0;\n\tif (v384) goto L_00A3;\n\tv437 = *([v96 @ stack_-78]);\n\tv426 = *([v437 @ X8_v38+126]) == 0;\n\tif (v426) goto L_0092;\n\tv514 = *([v437 @ X8_v38+B0]) + 8;\nL_007D:\n\tv519 = *([v514 @ X11_v15-8]) == Obi.IObiConstraintsBatch;\n\tif (v519) goto L_0095;\n\tv513 = v513 + 1;\n\tv555 = v513 < *([v437 @ X8_v38+126]);\n\tv483 = ~v555;\n\tv514 = v514 + 0x10;\n\tv467 = ~v483;\n\tif (v467) goto L_007D;\nL_0092:\n\tv562 = 0x8909C4(v96, Obi.IObiConstraintsBatch, 8, v32, v33, v34, v35, v36, v150, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_009A;\nL_0095:\n\tv557 = *([v514 @ X11_v15]) + 8;\n\tv558 = v557 << 4;\n\tv559 = v437 + v558;\n\tv562 = v559 + 0x130;\nL_009A:\n\tv270 = *([v562 @ X0_v48+8]);\n\t*([v562 @ X0_v48])(v424, v96, this, *([v562 @ X0_v48+8]), v32, v33, v34, v35, v36, v150, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0069;\n\tgoto L_00B7;\nL_00A3:\n\tv383 = new System.NullReferenceException();\n\tgoto L_00AF;\n\tgoto L_00AF;\nL_00AF:\n\tv363 = Il2CppMethodInfo != 1;\n\tif (v363) goto L_011F;\n\tv565 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(v383);\n\tv166 = v565.m_value;\n\tv452 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(v565);\nL_00B7:\n\tv158 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_00C2;\n\tv491 = v158;\n\tv492 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(v491, v380);\nL_00C2:\n\tv150 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv502 = *([v158 @ X22_v12 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v502) goto L_00EB;\n\tv575 = *([v158 @ X22_v12 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_00D6:\n\tv582 = *([v575 @ X10_v11-8]) == System.IDisposable;\n\tif (v582) goto L_00EE;\n\tv577 = v577 + 1;\n\tv587 = v577 < *([v158 @ X22_v12 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv545 = ~v587;\n\tv575 = v575 + 0x10;\n\tv529 = ~v545;\n\tif (v529) goto L_00D6;\nL_00EB:\n\tv597 = 0x8909C4(&v150 @ stack_-88_v7 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, v32, v33, v34, v35, v36, v374, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00F4;\nL_00EE:\n\tv589 = *([v575 @ X10_v11]) << 4;\n\tv590 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v589;\n\tv597 = v590 + 0x130;\nL_00F4:\n\t*([v597 @ X0_v29])(v275, &v150 @ stack_-88_v7 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v597 @ X0_v29+8]), v270, v32, v33, v34, v35, v36, v374, v38, v39, v40, v41, v42, v43, v44);\n\tv601 = v105 + 1;\n\tv126 = v601 == 0;\n\tv111 = ~v126;\n\tif (v111) goto L_010A;\n\tv602 = ~v166;\n\tv355 = ~v602;\n\tif (v355) goto L_011E;\nL_010A:\n\tv607 = Obi.ObiConstraints`1<T>::GenerateBatchDependencies(this);\n\tv609 = UnityEngine.Behaviour::get_isActiveAndEnabled(this.actor);\n\tv613 = Obi.ObiConstraints`1<T>::SetEnabled(this, v609);\n\tgoto L_0053;\n\tthrow System.NullReferenceException;\nL_011E:\n\tv361 = new System.TypeLoadException();\nL_011F:\n\treturnVal2 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(v382);\n\treturn returnVal2;\n// 185 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool AddToSolver()
		{
			//IL_029b: Expected O, but got I
			//IL_0121: Expected O, but got I
			//IL_0326: Expected I4, but got O
			//IL_0331: Expected O, but got I
			//IL_0340: Expected O, but got I
			//IL_02e7: Expected O, but got I
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01c0: Expected O, but got I
			//IL_01cf: Expected O, but got I
			//IL_016d: Expected O, but got I
			if (!inSolver && !(actor == null))
			{
				ObiActor obiActor = actor;
				if (!(obiActor.solver == null))
				{
					inSolver = true;
					List<T>.Enumerator enumerator = batches.GetEnumerator();
					int num = 0;
					List<T>.Enumerator enumerator2 = default(List<T>.Enumerator);
					object obj = default(object);
					List<T>.Enumerator enumerator3;
					while (true)
					{
						bool flag5;
						int num5;
						if (enumerator2.MoveNext())
						{
							if (obj != null)
							{
								object obj2 = obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v38+126]");
								if ((IntPtr)0 != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v38+B0]");
									object obj3 = 0L + 8L;
									int num2 = 0;
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X11_v15-8]");
										if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
										{
											break;
										}
										num2++;
										int num3 = num2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v38+126]");
										bool flag = (long)num3 < 0L;
										bool flag2 = !flag;
										obj3 = (long)(IntPtr)obj3 + 16L;
										if (!flag2)
										{
											continue;
										}
										goto IL_0186;
									}
									object obj4 = obj3 + 8;
									int num4 = (int)((long)(IntPtr)obj4 << 4);
									object obj5 = (long)(IntPtr)obj2 + (long)num4;
									object obj6 = (long)(IntPtr)obj5 + 304L;
									goto IL_0414;
								}
								goto IL_0186;
							}
							NullReferenceException ex = new NullReferenceException();
							bool flag3 = (IntPtr)0 != (IntPtr)1;
							enumerator3 = (List<T>.Enumerator)ex;
							if (flag3)
							{
								break;
							}
							bool flag4 = ((List<T>.Enumerator*)ex)->MoveNext();
							flag5 = ((bool*)(flag4 ? 1 : 0))->m_value;
							bool flag6 = (flag4 ? ((List<T>.Enumerator*)1) : ((List<T>.Enumerator*)null))->MoveNext();
							num5 = -1;
						}
						else
						{
							num5 = 0;
							flag5 = false;
						}
						IntPtr intPtr = (IntPtr)0;
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X22_v12 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0300;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X22_v12 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
						object obj7 = 0L + 8L;
						int num6 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ X10_v11-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
							{
								break;
							}
							num6++;
							int num7 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X22_v12 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
							bool flag7 = (long)num7 < 0L;
							bool flag8 = !flag7;
							obj7 = (long)(IntPtr)obj7 + 16L;
							if (!flag8)
							{
								continue;
							}
							goto IL_0300;
						}
						int num8 = obj7 << 4;
						object obj8 = 0L + (long)num8;
						object obj9 = (long)(IntPtr)obj8 + 304L;
						goto IL_0468;
						IL_0186:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						goto IL_0414;
						IL_0300:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						num = 0;
						goto IL_0468;
						IL_0414:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ X0_v48+8]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v562 @ X0_v48] (should have been resolved before IL gen)");
						continue;
						IL_0468:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v597 @ X0_v29] (should have been resolved before IL gen)");
						if (num5 + 1 != 0 || !flag5)
						{
							GenerateBatchDependencies();
							bool isActiveAndEnabled = actor.isActiveAndEnabled;
							SetEnabled(isActiveAndEnabled);
							return true;
						}
						TypeLoadException ex2 = new TypeLoadException();
						enumerator3 = (List<T>.Enumerator)ex2;
						break;
					}
					return ((List<T>.Enumerator*)enumerator3)->MoveNext();
				}
			}
			return false;
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0x10A7038", Offset = "0x10A7038", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EA95D0]);\n\tv27 = *([v26 @ X8_v39]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2026B13]) = v45;\nL_001B:\n\tv50 = ~this.inSolver;\n\tif (v50) goto L_FFFFFFFF;\n\tgoto L_002D;\n\tv80 = *([v54 @ X0_v5+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002D;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_002D:\n\tv70 = UnityEngine.Object::op_Equality(this.actor, 0);\n\tv172 = v70 == 0;\n\tv73 = ~v172;\n\tif (v73) goto L_FFFFFFFF;\n\tv236 = this.actor;\n\tv237 = this.actor == 0;\n\tif (v237) goto L_00A0;\n\tgoto L_0043;\n\tv292 = *([v238 @ X0_v30+E0]);\n\tv293 = v292 == 0;\n\tv294 = ~v293;\n\tif (v294) goto L_0043;\n\tv296 = \"il2cpp_codegen_runtime_class_init\"(v238, v66, v63, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0043:\n\tv69 = UnityEngine.Object::op_Equality(v236.m_Solver, 0);\n\tv72 = v69 == 0;\n\tif (v72) goto L_0052;\nL_0050:\n\treturn returnVal1;\nL_0052:\n\tv323 = this.batches == 0;\n\tif (v323) goto L_00A0;\n\tv343 = System.Collections.Generic.List`1<T>::GetEnumerator(this.batches);\nL_0064:\n\tv380 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(&v268 @ stack_-60_v10 (System.Collections.Generic.List`1<T>+Enumerator<T>));\n\tv384 = v380 == 0;\n\tif (v384) goto L_FFFFFFFF;\n\tgoto L_0098;\n\tv432 = *([v416 @ X8_v31+B0]);\n\tv433 = 0;\n\tv434 = v432 + 8;\n\tv436 = *([v503 @ X11_v15-8]);\n\tv508 = v436 == v417;\n\tif (v508) goto L_008F;\n\tv456 = v502 + 1;\n\tv534 = v456 < v418;\n\tv454 = ~v534;\n\tv458 = v503 + 0x10;\n\tv438 = ~v454;\n\tif (v438) goto L_FFFFFFFF;\n\tv459 = 9;\n\tv460 = v290;\n\tv461 = 0x8909C4(v460, v417, v459, v30, v31, v32, v33, v34, v272, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0098;\nL_008F:\n\tv535 = *([v503 @ X11_v15]);\n\tv536 = v535 + 9;\n\tv537 = v536 << 4;\n\tv538 = v416 + v537;\n\tv539 = v538 + 0x130;\nL_0098:\n\tObi.IObiConstraintsBatch::RemoveFromSolver(v93, this);\n\tgoto L_0064;\n\tgoto L_00B4;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv326 = new System.NullReferenceException();\n\tgoto L_00AC;\n\tgoto L_00AC;\nL_00AC:\n\tv337 = v221 != 1;\n\tif (v337) goto L_0107;\n\tv347 = 0x6D2BC0(v326, v221, v149, v30, v31, v32, v33, v34, v213, v36, v37, v38, v39, v40, v41, v42);\n\tv163 = *([v347 @ X0_v24]);\n\tv382 = 0x6D2490(v347, v221, v149, v30, v31, v32, v33, v34, v213, v36, v37, v38, v39, v40, v41, v42);\nL_00B4:\n\tv159 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_00BF;\n\tv420 = v159;\n\tv421 = 0x8907BC(v420, v406, v405, v30, v31, v32, v33, v34, v402, v36, v37, v38, v39, v40, v41, v42);\nL_00BF:\n\tv145 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv91 = &v145 @ stack_-88_v3 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>) + 0x10;\n\tv431 = *([v159 @ X20_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v431) goto L_00E8;\n\tv522 = *([v159 @ X20_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_00D3:\n\tv529 = *([v522 @ X10_v7-8]) == System.IDisposable;\n\tif (v529) goto L_00EB;\n\tv524 = v524 + 1;\n\tv544 = v524 < *([v159 @ X20_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv482 = ~v544;\n\tv522 = v522 + 0x10;\n\tv466 = ~v482;\n\tif (v466) goto L_00D3;\nL_00E8:\n\tv554 = 0x8909C4(&v145 @ stack_-88_v3 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, v30, v31, v32, v33, v34, 0, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00F1;\nL_00EB:\n\tv546 = *([v522 @ X10_v7]) << 4;\n\tv547 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v546;\n\tv554 = v547 + 0x130;\nL_00F1:\n\t*([v554 @ X0_v11])(v558, &v145 @ stack_-88_v3 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v554 @ X0_v11+8]), v149, v30, v31, v32, v33, v34, 0, v36, v37, v38, v39, v40, v41, v42);\n\tv213 = *([v91 @ X23_v3]);\n\tv559 = v153 + 1;\n\tv121 = v559 == 0;\n\tv106 = ~v121;\n\tif (v106) goto L_0101;\n\tv560 = v163 == 0;\n\tv352 = ~v560;\n\tif (v352) goto L_0106;\nL_0101:\n\tthis.inSolver = 0;\n\tgoto L_0050;\nL_0106:\n\tv351 = new System.TypeLoadException();\nL_0107:\n\treturnVal2 = 0x6D2380(v326, v221, v149, v30, v31, v32, v33, v34, v213, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal2;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool RemoveFromSolver()
		{
			//IL_0065: Expected O, but got I
			//IL_006b: Expected O, but got I
			//IL_0166: Expected I4, but got O
			//IL_0198: Expected O, but got I
			//IL_01d3: Expected O, but got I
			//IL_025e: Expected I4, but got O
			//IL_0269: Expected O, but got I
			//IL_0278: Expected O, but got I
			//IL_021f: Expected O, but got I
			if (!inSolver || actor == null)
			{
				goto IL_00ae;
			}
			ObiActor obiActor = actor;
			bool flag = (object)actor == null;
			IntPtr intPtr = default(IntPtr);
			object obj = (long)intPtr;
			UnityEngine.Object obj2 = (UnityEngine.Object)0;
			int num2;
			int num3;
			int num;
			if (!flag)
			{
				if (obiActor.solver == null)
				{
					goto IL_00ae;
				}
				bool flag2 = batches == null;
				List<T>.Enumerator enumerator = default(List<T>.Enumerator);
				object obj3 = default(object);
				obj = obj3;
				num = 0;
				obj2 = null;
				if (!flag2)
				{
					List<T>.Enumerator enumerator2 = batches.GetEnumerator();
					num = 0;
					IObiConstraintsBatch obiConstraintsBatch = default(IObiConstraintsBatch);
					while (enumerator.MoveNext())
					{
						obiConstraintsBatch.RemoveFromSolver(this);
						num = 0;
					}
					num2 = 0;
					num3 = 0;
					goto IL_0332;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)obj2 != (IntPtr)1)
			{
				goto IL_02e2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj4 = default(object);
			num3 = (int)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			num2 = -1;
			goto IL_0332;
			IL_00ae:
			return false;
			IL_0238:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num = 0;
			goto IL_0367;
			IL_02e2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			bool result = default(bool);
			return result;
			IL_0332:
			IntPtr intPtr2 = (IntPtr)0;
			intPtr = (IntPtr)0;
			object obj5 = (long)intPtr + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X20_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0238;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X20_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
			object obj6 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ X10_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X20_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0238;
			}
			int num6 = obj6 << 4;
			object obj7 = 0L + (long)num6;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_0367;
			IL_0367:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v554 @ X0_v11] (should have been resolved before IL gen)");
			obj = obj5;
			if (num2 + 1 != 0 || num3 == 0)
			{
				inSolver = false;
				return true;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			obj2 = null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_02e2;
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0x10A72F4", Offset = "0x10A72F4", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EA51F0]);\n\tv27 = *([v26 @ X8_v35]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2026B14]) = v45;\nL_001B:\n\tv50 = ~this.inSolver;\n\tif (v50) goto L_010A;\n\tv52 = this.batches == 0;\n\tif (v52) goto L_00A0;\n\tv147 = System.Collections.Generic.List`1<T>::GetEnumerator(this.batches);\nL_0032:\n\tv290 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(&v186 @ stack_-60_v9 (System.Collections.Generic.List`1<T>+Enumerator<T>));\n\tv302 = v290 == 0;\n\tif (v302) goto L_FFFFFFFF;\n\tv293 = v295 == 0;\n\tif (v293) goto L_0032;\n\tv352 = *([v60 @ stack_-78 (System.Int32)]);\n\tv355 = *([v352 @ X8_v25+126]) == 0;\n\tif (v355) goto L_005D;\n\tv440 = *([v352 @ X8_v25+B0]) + 8;\nL_0048:\n\tv445 = *([v440 @ X11_v20-8]) == Obi.IObiConstraintsBatch;\n\tif (v445) goto L_0060;\n\tv439 = v439 + 1;\n\tv471 = v439 < *([v352 @ X8_v25+126]);\n\tv391 = ~v471;\n\tv440 = v440 + 0x10;\n\tv375 = ~v391;\n\tif (v375) goto L_0048;\nL_005D:\n\tv492 = 0x8909C4(v60, Obi.IObiConstraintsBatch, 6, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0067;\nL_0060:\n\tv473 = *([v440 @ X11_v20]) + 6;\n\tv474 = v473 << 4;\n\tv475 = v352 + v474;\n\tv492 = v475 + 0x130;\nL_0067:\n\t*([v492 @ X0_v28])(v497, v60, *([v492 @ X0_v28+8]), v574, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\n\tv498 = *([v295 @ X20_v9 (System.Int32)]);\n\tv294 = *([v498 @ X8_v28+126]) == 0;\n\tif (v294) goto L_008B;\n\tv557 = *([v498 @ X8_v28+B0]) + 8;\nL_0076:\n\tv562 = *([v557 @ X11_v15-8]) == Obi.IObiConstraintsBatch;\n\tif (v562) goto L_008E;\n\tv556 = v556 + 1;\n\tv568 = v556 < *([v498 @ X8_v28+126]);\n\tv537 = ~v568;\n\tv557 = v557 + 0x10;\n\tv521 = ~v537;\n\tif (v521) goto L_0076;\nL_008B:\n\tv575 = 0x8909C4(v295, Obi.IObiConstraintsBatch, 6, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0095;\nL_008E:\n\tv570 = *([v557 @ X11_v15]) + 6;\n\tv571 = v570 << 4;\n\tv572 = v498 + v571;\n\tv575 = v572 + 0x130;\nL_0095:\n\t*([v575 @ X0_v31])(v579, v295, *([v575 @ X0_v31+8]), v574, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\n\tOni::SetDependency(v497, v579);\n\tgoto L_0032;\n\tgoto L_00B6;\n\tv196 = new System.NullReferenceException();\nL_00A0:\n\tv205 = new System.NullReferenceException();\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\nL_00AE:\n\tv312 = Il2CppMethodInfo != 1;\n\tif (v312) goto L_010F;\n\tv315 = 0x6D2BC0(v205, Il2CppMethodInfo, v574, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\n\tv127 = *([v315 @ X0_v20]);\n\tv341 = 0x6D2490(v315, Il2CppMethodInfo, v574, v30, v31, v32, v33, v34, v117, v36, v37, v38, v39, v40, v41, v42);\nL_00B6:\n\tv129 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_00C1;\n\tv357 = v129;\n\tv358 = 0x8907BC(v357, v339, v322, v30, v31, v32, v33, v34, v336, v36, v37, v38, v39, v40, v41, v42);\nL_00C1:\n\tv117 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv57 = &v117 @ stack_-88_v3 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>) + 0x10;\n\tv368 = *([v129 @ X19_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v368) goto L_00EA;\n\tv459 = *([v129 @ X19_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_00D5:\n\tv466 = *([v459 @ X10_v7-8]) == System.IDisposable;\n\tif (v466) goto L_00ED;\n\tv461 = v461 + 1;\n\tv501 = v461 < *([v129 @ X19_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv419 = ~v501;\n\tv459 = v459 + 0x10;\n\tv403 = ~v419;\n\tif (v403) goto L_00D5;\nL_00EA:\n\tv511 = 0x8909C4(&v117 @ stack_-88_v3 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, v30, v31, v32, v33, v34, v186, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00F3;\nL_00ED:\n\tv503 = *([v459 @ X10_v7]) << 4;\n\tv504 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v503;\n\tv511 = v504 + 0x130;\nL_00F3:\n\t*([v511 @ X0_v6])(v122, &v117 @ stack_-88_v3 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v511 @ X0_v6+8]), v574, v30, v31, v32, v33, v34, v186, v36, v37, v38, v39, v40, v41, v42);\n\tv250 = *([v57 @ X22_v4]);\n\tv125 = v133 + 1;\n\tv88 = v125 == 0;\n\tv73 = ~v88;\n\tif (v73) goto L_010A;\n\tv545 = v127 == 0;\n\tv124 = ~v545;\n\tif (v124) goto L_010E;\nL_010A:\n\treturn;\nL_010E:\n\tv319 = new System.TypeLoadException();\nL_010F:\n\tv258 = 0x6D2380(v205, v256, v574, v30, v31, v32, v33, v34, v250, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GenerateBatchDependencies()
		{
			//IL_001e: Expected O, but got I
			//IL_02a4: Expected I4, but got O
			//IL_02d6: Expected O, but got I
			//IL_0084: Expected O, but got I4
			//IL_0311: Expected O, but got I
			//IL_0494: Expected O, but got I4
			//IL_00c1: Expected O, but got I
			//IL_039c: Expected I4, but got O
			//IL_03a7: Expected O, but got I
			//IL_03b6: Expected O, but got I
			//IL_03fb: Expected I, but got O
			//IL_035d: Expected O, but got I
			//IL_0193: Expected O, but got I
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected O, but got Unknown
			//IL_0169: Expected O, but got I
			//IL_0178: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Expected O, but got Unknown
			//IL_023b: Expected O, but got I
			//IL_024a: Expected O, but got I
			//IL_01df: Expected O, but got I
			if (!inSolver)
			{
				return;
			}
			bool flag = batches == null;
			IntPtr intPtr = default(IntPtr);
			object obj = (long)intPtr;
			IntPtr intPtr2 = (IntPtr)0;
			int num11;
			int num12;
			int num;
			NullReferenceException ex;
			if (!flag)
			{
				List<T>.Enumerator enumerator = batches.GetEnumerator();
				int num2 = default(int);
				num = num2;
				int num3 = 0;
				List<T>.Enumerator enumerator2 = default(List<T>.Enumerator);
				int num4 = default(int);
				IntPtr batch = default(IntPtr);
				IntPtr dependency = default(IntPtr);
				while (enumerator2.MoveNext())
				{
					bool flag2 = num3 == 0;
					num3 = num4;
					if (flag2)
					{
						continue;
					}
					object obj2 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v25+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0126;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v25+B0]");
					object obj3 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X11_v20-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X8_v25+126]");
						bool flag3 = (long)num6 < 0L;
						bool flag4 = !flag3;
						obj3 = (long)(IntPtr)obj3 + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_0126;
					}
					object obj4 = obj3 + 6;
					int num7 = (int)((long)(IntPtr)obj4 << 4);
					object obj5 = (long)(IntPtr)obj2 + (long)num7;
					object obj6 = (long)(IntPtr)obj5 + 304L;
					goto IL_0482;
					IL_01f8:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num = 6;
					goto IL_04e3;
					IL_0126:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num = 6;
					goto IL_0482;
					IL_0482:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v492 @ X0_v28] (should have been resolved before IL gen)");
					object obj7 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ X8_v28+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01f8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ X8_v28+B0]");
					object obj8 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ X11_v15-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ X8_v28+126]");
						bool flag5 = (long)num9 < 0L;
						bool flag6 = !flag5;
						obj8 = (long)(IntPtr)obj8 + 16L;
						if (!flag6)
						{
							continue;
						}
						goto IL_01f8;
					}
					object obj9 = obj8 + 6;
					int num10 = (int)((long)(IntPtr)obj9 << 4);
					object obj10 = (long)(IntPtr)obj7 + (long)num10;
					object obj11 = (long)(IntPtr)obj10 + 304L;
					goto IL_04e3;
					IL_04e3:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v575 @ X0_v31] (should have been resolved before IL gen)");
					Oni.SetDependency(batch, dependency);
					num = 0;
					num3 = num4;
				}
				num11 = 0;
				num12 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					goto IL_0408;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj12 = default(object);
				num11 = (int)obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num12 = -1;
			}
			IntPtr intPtr3 = (IntPtr)0;
			intPtr = (IntPtr)0;
			object obj13 = (long)intPtr + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X19_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0376;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X19_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
			object obj14 = 0L + 8L;
			int num13 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ X10_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num13++;
				int num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X19_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
				bool flag7 = (long)num14 < 0L;
				bool flag8 = !flag7;
				obj14 = (long)(IntPtr)obj14 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_0376;
			}
			int num15 = obj14 << 4;
			object obj15 = 0L + (long)num15;
			object obj16 = (long)(IntPtr)obj15 + 304L;
			goto IL_0545;
			IL_0376:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num = 0;
			goto IL_0545;
			IL_0408:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_0545:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v511 @ X0_v6] (should have been resolved before IL gen)");
			obj = obj13;
			if (num12 + 1 != 0 || num11 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num = 0;
			intPtr2 = (IntPtr)null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_0408;
		}

		[Token(Token = "0x60001B7")]
		[Address(RVA = "0x10A75B4", Offset = "0x10A75B4", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EE4F48]);\n\tv27 = *([v26 @ X8_v29]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, enabled, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026B15]) = v44;\nL_001B:\n\tv49 = this.batches == 0;\n\tif (v49) goto L_0069;\n\tv56 = System.Collections.Generic.List`1<T>::GetEnumerator(this.batches);\nL_002E:\n\tv155 = 0xEF9AB0(&v107 @ stack_-50_v8 (System.Int32), Il2CppMethodInfo, v320, v29, v30, v31, v32, v33, v216, v35, v36, v37, v38, v39, v40, v41);\n\tv156 = v155 & 1;\n\tv157 = v156 == 0;\n\tif (v157) goto L_FFFFFFFF;\n\tgoto L_0062;\n\tv270 = *([v234 @ X8_v23+B0]);\n\tv271 = 0;\n\tv272 = v270 + 8;\n\tv274 = *([v365 @ X11_v13-8]);\n\tv370 = v274 == v235;\n\tif (v370) goto L_0059;\n\tv294 = v364 + 1;\n\tv405 = v294 < v236;\n\tv292 = ~v405;\n\tv296 = v365 + 0x10;\n\tv276 = ~v292;\n\tif (v276) goto L_FFFFFFFF;\n\tv297 = 0xD;\n\tv298 = v122;\n\tv299 = 0x8909C4(v298, v235, v297, v29, v30, v31, v32, v33, v59, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0062;\nL_0059:\n\tv406 = *([v365 @ X11_v13]);\n\tv407 = v406 + 0xD;\n\tv408 = v407 << 4;\n\tv409 = v234 + v408;\n\tv410 = v409 + 0x130;\nL_0062:\n\tObi.IObiConstraintsBatch::SetEnabled(v58, enabled);\n\tgoto L_002E;\n\tgoto L_007D;\n\tv118 = new System.NullReferenceException();\nL_0069:\n\tv127 = new System.NullReferenceException();\n\tgoto L_0075;\n\tgoto L_0075;\nL_0075:\n\tv167 = Il2CppMethodInfo != 1;\n\tif (v167) goto L_00D5;\n\tv170 = 0x6D2BC0(v127, Il2CppMethodInfo, v320, v29, v30, v31, v32, v33, v216, v35, v36, v37, v38, v39, v40, v41);\n\tv226 = *([v170 @ X0_v19]);\n\tv258 = 0x6D2490(v170, Il2CppMethodInfo, v320, v29, v30, v31, v32, v33, v216, v35, v36, v37, v38, v39, v40, v41);\nL_007D:\n\tv228 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tgoto L_0088;\n\tv300 = v228;\n\tv301 = 0x8907BC(v300, v256, v239, v29, v30, v31, v32, v33, v253, v35, v36, v37, v38, v39, v40, v41);\nL_0088:\n\tv216 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv232 = &v216 @ stack_-78_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>) + 0x10;\n\tv311 = *([v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]) == 0;\n\tif (v311) goto L_00B1;\n\tv424 = *([v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]) + 8;\nL_009C:\n\tv431 = *([v424 @ X10_v6-8]) == System.IDisposable;\n\tif (v431) goto L_00B4;\n\tv426 = v426 + 1;\n\tv436 = v426 < *([v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]);\n\tv395 = ~v436;\n\tv424 = v424 + 0x10;\n\tv379 = ~v395;\n\tif (v379) goto L_009C;\nL_00B1:\n\tv446 = 0x8909C4(&v216 @ stack_-78_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), System.IDisposable, 0, v29, v30, v31, v32, v33, v107, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00BA;\nL_00B4:\n\tv438 = *([v424 @ X10_v6]) << 4;\n\tv439 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>> + v438;\n\tv446 = v439 + 0x130;\nL_00BA:\n\t*([v446 @ X0_v5])(v340, &v216 @ stack_-78_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>), *([v446 @ X0_v5+8]), v320, v29, v30, v31, v32, v33, v107, v35, v36, v37, v38, v39, v40, v41);\n\tv211 = *([v232 @ X22_v3]);\n\tv450 = v224 + 1;\n\tv196 = v450 == 0;\n\tv186 = ~v196;\n\tif (v186) goto L_00D0;\n\tv451 = v226 == 0;\n\tv222 = ~v451;\n\tif (v222) goto L_00D4;\nL_00D0:\n\treturn;\nL_00D4:\n\tv220 = new System.TypeLoadException();\nL_00D5:\n\tv233 = 0x6D2380(v127, v217, v320, v29, v30, v31, v32, v33, v211, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEnabled(bool enabled)
		{
			//IL_01ff: Expected O, but got I
			//IL_007b: Expected I4, but got O
			//IL_00ad: Expected O, but got I
			//IL_0225: Expected I, but got O
			//IL_015c: Expected I, but got O
			//IL_00e8: Expected O, but got I
			//IL_016f: Expected I4, but got O
			//IL_017a: Expected O, but got I
			//IL_0189: Expected O, but got I
			//IL_01c5: Expected I, but got O
			//IL_0134: Expected O, but got I
			bool flag = batches == null;
			IntPtr intPtr = default(IntPtr);
			object obj = (long)intPtr;
			bool flag2 = false;
			int num;
			int num2;
			NullReferenceException ex;
			IntPtr intPtr2;
			if (!flag)
			{
				List<T>.Enumerator enumerator = batches.GetEnumerator();
				IntPtr intPtr3 = default(IntPtr);
				intPtr2 = intPtr3;
				object obj2 = default(object);
				IObiConstraintsBatch obiConstraintsBatch = default(IObiConstraintsBatch);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
					if ((int)((long)(IntPtr)obj2 & 1L) == 0)
					{
						break;
					}
					obiConstraintsBatch.SetEnabled(enabled);
					intPtr2 = (IntPtr)null;
				}
				num = 0;
				num2 = 0;
			}
			else
			{
				ex = new NullReferenceException();
				if ((IntPtr)0 != (IntPtr)1)
				{
					goto IL_01db;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				num2 = (int)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num = -1;
			}
			IntPtr intPtr4 = (IntPtr)0;
			intPtr = (IntPtr)0;
			object obj4 = (long)intPtr + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_014d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+B0]");
			object obj5 = 0L + 8L;
			int num3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ X10_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num3++;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X19_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+126]");
				bool flag3 = (long)num4 < 0L;
				bool flag4 = !flag3;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_014d;
			}
			int num5 = obj5 << 4;
			object obj6 = 0L + (long)num5;
			object obj7 = (long)(IntPtr)obj6 + 304L;
			goto IL_025f;
			IL_01db:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_025f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v446 @ X0_v5] (should have been resolved before IL gen)");
			obj = obj4;
			if (num + 1 != 0 || num2 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			intPtr2 = (IntPtr)null;
			flag2 = false;
			ex = (NullReferenceException)(object)ex2;
			goto IL_01db;
			IL_014d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			intPtr2 = (IntPtr)null;
			goto IL_025f;
		}
	}
}
