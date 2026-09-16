using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Morpeh.Globals.ECS
{
	[Token(Token = "0x200002B")]
	internal abstract class GlobalEventComponentUpdater
	{
		[Token(Token = "0x400004D")]
		internal static List<GlobalEventComponentUpdater> Updaters;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x10")]
		protected Filter filter;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x18")]
		protected Filter filterNextFrame;

		[Token(Token = "0x60000BE")]
		internal abstract void Update();

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x15F76C0", Offset = "0x15F76C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal GlobalEventComponentUpdater()
		{
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x15F76C8", Offset = "0x15F76C8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1ED7C20]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A050]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>();\n\tSystem.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::.ctor(v39);\n\tv47.Updaters = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static GlobalEventComponentUpdater()
		{
			List<GlobalEventComponentUpdater> updaters = new List<GlobalEventComponentUpdater>();
			Updaters = updaters;
		}
	}
	[Token(Token = "0x200002C")]
	internal sealed class GlobalEventComponentUpdater<T> : GlobalEventComponentUpdater
	{
		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x109D4F0", Offset = "0x109D4F0", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1F01018]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, rootFilter, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026B00]) = v44;\nL_001F:\n\tgoto L_0027;\n\tv61 = *([v48 @ X0_v6+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0027;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v48, rootFilter, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0027:\n\tMorpeh.Globals.ECS.GlobalEventComponentUpdater::.ctor(this);\n\tv74 = Morpeh.Filter::With(rootFilter, 1);\n\tv75 = Morpeh.Filter::With(v74, 1);\n\tv115 = Morpeh.Filter::With(v75, 1);\n\tthis.filter = v115;\n\tv94 = Morpeh.Filter::With(v75, 1);\n\tthis.filterNextFrame = v94;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal GlobalEventComponentUpdater(Filter rootFilter)
		{
			Filter filter = rootFilter.With<GlobalEventMarker>();
			Filter filter2 = filter.With<GlobalEventComponent<T>>();
			Filter filter3 = filter2.With<GlobalEventPublished>();
			this.filter = filter3;
			Filter filter4 = filter2.With<GlobalEventNextFrame>();
			this.filterNextFrame = filter4;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x109D5F0", Offset = "0x109D5F0", Length = "0x414")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EA8478]);\n\tv29 = *([v28 @ X8_v40]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026B01]) = v47;\nL_001B:\n\tv51 = 0;\n\tv54 = &v168 @ stack_-88_v5 (Morpeh.World);\n\tv57 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv168 = *([v54 @ X8_v6]);\nL_0033:\n\tv303 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(&v168 @ stack_-88_v5 (Morpeh.World), 0);\n\tv348 = v303 & 1;\n\tv349 = v348 == 0;\n\tif (v349) goto L_00CB;\n\tv408 = *([v350 @ stack_-58 (System.Action`1<System.Collections.Generic.IEnumerable`1<T>>)]);\n\tv409 = Il2CppMethodInfo;\n\tv413 = *([v408 @ X8_v22 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]) == 0;\n\tif (v413) goto L_005F;\n\tv501 = *([v408 @ X8_v22 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]) + 8;\nL_004B:\n\tv506 = *([v501 @ X11_v31-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v506) goto L_0062;\n\tv500 = v500 + 1;\n\tv532 = v500 < *([v408 @ X8_v22 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]);\n\tv438 = ~v532;\n\tv501 = v501 + 0x10;\n\tv422 = ~v438;\n\tif (v422) goto L_004B;\nL_005F:\n\tv547 = 0x8909C4(v350, Il2CppClass<Morpeh.IEntity>, *([v409 @ X23_v9 (Il2CppMethodInfo)+48]), v32, v33, v34, v35, v36, *([v54 @ X8_v6+10]), v168, v39, v40, v41, v42, v43, v44);\n\tgoto L_0068;\nL_0062:\n\tv534 = *([v501 @ X11_v31]) + *([v409 @ X23_v9 (Il2CppMethodInfo)+48]);\n\tv535 = v534 << 4;\n\tv536 = v408 + v535;\n\tv547 = v536 + 0x130;\nL_0068:\n\tv551 = 0x8D8294(*([v547 @ X0_v54+8]), Il2CppMethodInfo, *([v409 @ X23_v9 (Il2CppMethodInfo)+48]), v32, v33, v34, v35, v36, *([v54 @ X8_v6+10]), v168, v39, v40, v41, v42, v43, v44);\n\tv524 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(v350, &v51 @ stack_-64_v1);\n\tv259 = *([v524 @ X0_v58]) != 0;\n\tif (v259) goto L_FFFFFFFF;\n\tgoto L_0080;\nL_0080:\n\tv589 = *([v524 @ X0_v58]) == 0;\n\tif (v589) goto L_008D;\n\tv525 = v300 == 0;\n\tif (v525) goto L_00D1;\n\tv475 = v524 + 8;\n\tv608 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(v300, *([v475 @ X23_v11]));\n\tgoto L_0095;\nL_008D:\n\tv475 = v524 + 8;\nL_0095:\n\tv645 = System.Collections.Generic.List`1<T>::Clear(*([v475 @ X23_v11]));\n\tv287 = Il2CppMethodInfo;\n\tv646 = *([v350 @ stack_-58 (System.Action`1<System.Collections.Generic.IEnumerable`1<T>>)]);\n\tv114 = *([v287 @ X23_v12 (Il2CppMethodInfo)+48]);\n\tv296 = *([v646 @ X8_v30 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]) == 0;\n\tif (v296) goto L_00B9;\n\tv735 = *([v646 @ X8_v30 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]) + 8;\nL_00A5:\n\tv740 = *([v735 @ X11_v26-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v740) goto L_00BC;\n\tv734 = v734 + 1;\n\tv753 = v734 < *([v646 @ X8_v30 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]);\n\tv692 = ~v753;\n\tv735 = v735 + 0x10;\n\tv676 = ~v692;\n\tif (v676) goto L_00A5;\nL_00B9:\n\tv760 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(v350, Il2CppClass<Morpeh.IEntity>);\n\tgoto L_00C2;\nL_00BC:\n\tv755 = *([v735 @ X11_v26]) + v114;\n\tv756 = v755 << 4;\n\tv757 = v646 + v756;\n\tv760 = v757 + 0x130;\nL_00C2:\n\tv764 = Morpeh.IEntity::RemoveComponent(*([v760 @ X0_v62+8]));\n\tv764.m_value(v294, v350, v764, v114, v32, v33, v34, v35, v36, *([v54 @ X8_v6+10]), v168, v39, v40, v41, v42, v43, v44);\n\tgoto L_0033;\nL_00CB:\n\tv354 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(&v168 @ stack_-88_v5 (Morpeh.World), 0);\n\tgoto L_00F1;\n\tv415 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00D1:\n\tv528 = new System.NullReferenceException();\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\n\tgoto L_00E1;\nL_00E1:\n\tv200 = v336 != 1;\n\tif (v200) goto L_0199;\n\tv586 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(v528, v336);\n\tv590 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(v586, v336);\n\tv245 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(&v168 @ stack_-88_v5 (Morpeh.World), 0);\n\tv611 = *([v586 @ X0_v46 (System.Action`1<System.Collections.Generic.IEnumerable`1<T>>)]) == 0;\n\tv247 = ~v611;\n\tif (v247) goto L_0178;\nL_00F1:\n\tv531 = Morpeh.Filter::GetEnumerator(this.filterNextFrame);\n\tv168 = v531.world;\nL_0104:\n\tv583 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(&v168 @ stack_-88_v5 (Morpeh.World), 0);\n\tv588 = v583 & 1;\n\tv396 = v588 == 0;\n\tif (v396) goto L_0172;\n\tv594 = Il2CppMethodInfo;\n\tv595 = *([v350 @ stack_-58 (System.Action`1<System.Collections.Generic.IEnumerable`1<T>>)]);\n\tv599 = *([v595 @ X8_v11 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]) == 0;\n\tif (v599) goto L_012E;\n\tv660 = *([v595 @ X8_v11 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]) + 8;\nL_011A:\n\tv665 = *([v660 @ X11_v17-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v665) goto L_0131;\n\tv659 = v659 + 1;\n\tv699 = v659 < *([v595 @ X8_v11 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]);\n\tv634 = ~v699;\n\tv660 = v660 + 0x10;\n\tv618 = ~v634;\n\tif (v618) goto L_011A;\nL_012E:\n\tv719 = 0x8909C4(v350, Il2CppClass<Morpeh.IEntity>, *([v594 @ X20_v8 (Il2CppMethodInfo)+48]), v32, v33, v34, v35, v36, v531.ids, v168, v39, v40, v41, v42, v43, v44);\n\tgoto L_0137;\nL_0131:\n\tv701 = *([v660 @ X11_v17]) + *([v594 @ X20_v8 (Il2CppMethodInfo)+48]);\n\tv702 = v701 << 4;\n\tv703 = v595 + v702;\n\tv719 = v703 + 0x130;\nL_0137:\n\tv723 = Morpeh.IEntity::AddComponent(*([v719 @ X0_v23+8]));\n\t*([v723 @ X0_v25 (Morpeh.Globals.ECS.GlobalEventPublished&)])(v749, v350, v723, *([v594 @ X20_v8 (Il2CppMethodInfo)+48]), v32, v33, v34, v35, v36, v531.ids, v168, v39, v40, v41, v42, v43, v44);\n\tv580 = Il2CppMethodInfo;\n\tv750 = *([v350 @ stack_-58 (System.Action`1<System.Collections.Generic.IEnumerable`1<T>>)]);\n\tv114 = *([v580 @ X20_v9 (Il2CppMethodInfo)+48]);\n\tv578 = *([v750 @ X8_v14 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]) == 0;\n\tif (v578) goto L_0160;\n\tv806 = *([v750 @ X8_v14 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]) + 8;\nL_014C:\n\tv811 = *([v806 @ X11_v12-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v811) goto L_0163;\n\tv805 = v805 + 1;\n\tv816 = v805 < *([v750 @ X8_v14 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]);\n\tv787 = ~v816;\n\tv806 = v806 + 0x10;\n\tv771 = ~v787;\n\tif (v771) goto L_014C;\nL_0160:\n\tv823 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(v350, Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0169;\nL_0163:\n\tv818 = *([v806 @ X11_v12]) + v114;\n\tv819 = v818 << 4;\n\tv820 = v750 + v819;\n\tv823 = v820 + 0x130;\nL_0169:\n\tv827 = Morpeh.IEntity::RemoveComponent(*([v823 @ X0_v28+8]));\n\tv827.m_value(v576, v350, v827, v114, v32, v33, v34, v35, v36, v531.ids, v168, v39, v40, v41, v42, v43, v44);\n\tgoto L_0104;\nL_0172:\n\tv394 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(&v168 @ stack_-88_v5 (Morpeh.World), 0);\n\tgoto L_0198;\n\tv174 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0178:\n\tgoto L_019D;\n\tgoto L_017B;\n\tgoto L_017B;\nL_017B:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0199;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = &stack[30];\n\tX1 = 0;\n\tX0 = 0x15F7664(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_019A;\nL_0198:\n\treturn;\nL_0199:\n\tv587 = System.Action`1<System.Collections.Generic.IEnumerable`1<T>>::Invoke(v528, v336);\nL_019A:\n\t;\nL_019D:\n\tthrow System.TypeLoadException;\n// 247 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void Update()
		{
			//IL_055f: Expected O, but got I4
			//IL_0036: Expected I, but got O
			//IL_0077: Expected O, but got I
			//IL_0370: Expected I, but got O
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Expected O, but got Unknown
			//IL_011d: Expected O, but got I
			//IL_012c: Expected O, but got I
			//IL_0689: Expected O, but got I
			//IL_06a5: Expected I, but got O
			//IL_03ab: Expected O, but got I
			//IL_0190: Expected O, but got I
			//IL_00c3: Expected O, but got I
			//IL_04eb: Expected O, but got I
			//IL_01ac: Expected I, but got O
			//IL_070d: Expected O, but got I
			//IL_047b: Expected O, but got I
			//IL_042f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Expected O, but got Unknown
			//IL_0451: Expected O, but got I
			//IL_0460: Expected O, but got I
			//IL_0267: Expected O, but got I
			//IL_03f7: Expected O, but got I
			//IL_060d: Expected O, but got I
			//IL_01f7: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fe: Expected O, but got Unknown
			//IL_051b: Expected O, but got I
			//IL_052a: Expected O, but got I
			//IL_04c7: Expected O, but got I
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_027a: Expected O, but got Unknown
			//IL_0297: Expected O, but got I
			//IL_02a6: Expected O, but got I
			//IL_0243: Expected O, but got I
			object obj = 0;
			World world = default(World);
			object obj2 = world;
			Filter.EntityEnumerator enumerator = this.filter.GetEnumerator();
			world = (World)obj2;
			Action<IEnumerable<T>> action = null;
			object obj3 = default(object);
			Action<IEnumerable<T>> action2 = default(Action<IEnumerable<T>>);
			object obj9 = default(object);
			IEnumerable<T> enumerable = default(IEnumerable<T>);
			Action<IEnumerable<T>> action3 = default(Action<IEnumerable<T>>);
			IntPtr intPtr4 = default(IntPtr);
			object obj15 = default(object);
			while (true)
			{
				world(null);
				if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
				{
					IntPtr intPtr = (IntPtr)action2;
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ X8_v22 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00dc;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ X8_v22 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]");
					object obj4 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ X11_v31-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ X8_v22 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00dc;
					}
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ X23_v9 (Il2CppMethodInfo)+48]");
					object obj6 = obj5 + 0;
					int num3 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)intPtr + (long)num3;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_0586;
				}
				world(null);
				goto IL_0341;
				IL_0586:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				action2((IEnumerable<T>)obj);
				if (obj9 != null)
				{
					action = (Action<IEnumerable<T>>)obj9;
				}
				object obj10;
				IntPtr intPtr3;
				if (obj9 != null)
				{
					if (action == null)
					{
						NullReferenceException ex = new NullReferenceException();
						if ((IntPtr)enumerable == (IntPtr)1)
						{
							ex(enumerable);
							action3(enumerable);
							world(null);
							bool flag3 = action3 == null;
							bool flag4 = !flag3;
							intPtr3 = intPtr4;
							if (!flag4)
							{
								goto IL_0341;
							}
							break;
						}
						ex(enumerable);
						break;
					}
					obj10 = (long)(IntPtr)obj9 + 8L;
					action((IEnumerable<T>)obj10);
				}
				else
				{
					obj10 = (long)(IntPtr)obj9 + 8L;
				}
				((List<T>)obj10).Clear();
				IntPtr intPtr5 = (IntPtr)0;
				IntPtr intPtr6 = (IntPtr)action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ X23_v12 (Il2CppMethodInfo)+48]");
				intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ X8_v30 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ X8_v30 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]");
					object obj11 = 0L + 8L;
					int num4 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v735 @ X11_v26-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ X8_v30 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
						bool flag5 = (long)num5 < 0L;
						bool flag6 = !flag5;
						obj11 = (long)(IntPtr)obj11 + 16L;
						if (!flag6)
						{
							continue;
						}
						goto IL_025c;
					}
					object obj12 = obj11 + (long)intPtr3;
					int num6 = (int)((long)(IntPtr)obj12 << 4);
					object obj13 = (long)intPtr6 + (long)num6;
					object obj14 = (long)(IntPtr)obj13 + 304L;
					goto IL_05fc;
				}
				goto IL_025c;
				IL_0341:
				world = this.filterNextFrame.GetEnumerator().world;
				while (true)
				{
					world(null);
					if ((int)((long)(IntPtr)obj15 & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr7 = (IntPtr)0;
					IntPtr intPtr8 = (IntPtr)action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ X8_v11 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0410;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ X8_v11 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]");
					object obj16 = 0L + 8L;
					int num7 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ X11_v17-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ X8_v11 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
						bool flag7 = (long)num8 < 0L;
						bool flag8 = !flag7;
						obj16 = (long)(IntPtr)obj16 + 16L;
						if (!flag8)
						{
							continue;
						}
						goto IL_0410;
					}
					object obj17 = obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ X20_v8 (Il2CppMethodInfo)+48]");
					object obj18 = obj17 + 0;
					int num9 = (int)((long)(IntPtr)obj18 << 4);
					object obj19 = (long)intPtr8 + (long)num9;
					object obj20 = (long)(IntPtr)obj19 + 304L;
					goto IL_0678;
					IL_0410:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0678;
					IL_0678:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X0_v23+8]");
					ref GlobalEventPublished reference = ref ((IEntity)0).AddComponent<GlobalEventPublished>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v723 @ X0_v25 (Morpeh.Globals.ECS.GlobalEventPublished&)] (should have been resolved before IL gen)");
					IntPtr intPtr9 = (IntPtr)0;
					IntPtr intPtr10 = (IntPtr)action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ X20_v9 (Il2CppMethodInfo)+48]");
					intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ X8_v14 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ X8_v14 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+B0]");
						object obj21 = 0L + 8L;
						int num10 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ X11_v12-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num10++;
							int num11 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ X8_v14 (Il2CppClass<System.Action`1<System.Collections.Generic.IEnumerable`1<T>>>)+126]");
							bool flag9 = (long)num11 < 0L;
							bool flag10 = !flag9;
							obj21 = (long)(IntPtr)obj21 + 16L;
							if (!flag10)
							{
								continue;
							}
							goto IL_04e0;
						}
						object obj22 = obj21 + (long)intPtr3;
						int num12 = (int)((long)(IntPtr)obj22 << 4);
						object obj23 = (long)intPtr10 + (long)num12;
						object obj24 = (long)(IntPtr)obj23 + 304L;
						goto IL_06fc;
					}
					goto IL_04e0;
					IL_06fc:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ X0_v28+8]");
					bool flag11 = ((IEntity)0).RemoveComponent<GlobalEventNextFrame>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v827.m_value (System.Boolean) (should have been resolved before IL gen)");
					continue;
					IL_04e0:
					action2((IEnumerable<T>)0);
					goto IL_06fc;
				}
				world(null);
				return;
				IL_025c:
				action2((IEnumerable<T>)0);
				goto IL_05fc;
				IL_05fc:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ X0_v62+8]");
				bool flag12 = ((IEntity)0).RemoveComponent<GlobalEventPublished>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v764.m_value (System.Boolean) (should have been resolved before IL gen)");
				continue;
				IL_00dc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0586;
			}
			throw new TypeLoadException();
		}
	}
}
