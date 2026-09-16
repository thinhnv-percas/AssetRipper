using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Providers
{
	[Token(Token = "0x2000076")]
	public class EnemyPartsProvider : MonoProvider<EnemyPartsComponent>
	{
		[Token(Token = "0x60000E4")]
		[Address(RVA = "0xCC2970", Offset = "0xCC2970", Length = "0x3B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EF7CB0]);\n\tv31 = *([v30 @ X8_v49]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023754]) = v50;\nL_001D:\n\tv54 = 0;\n\tv57 = Morpeh.MonoProvider`1<GBG.Pinata.ECS.Components.EnemyPartsComponent>::GetData(this, &v54 @ stack_-54_v1 (System.Boolean));\n\tv60 = *([v57 @ X0_v3 (GBG.Pinata.ECS.Components.EnemyPartsComponent&)]) == 0;\n\tif (v60) goto L_00D0;\n\tv64 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v64);\n\tv81 = UnityEngine.Component::get_transform(this);\n\tv97 = UnityEngine.Transform::GetEnumerator(v81);\n\tv228 = v97 == 0;\n\tif (v228) goto L_00F1;\nL_0043:\n\tgoto L_006A;\n\tv368 = *([v354 @ X8_v31+B0]);\n\tv369 = 0;\n\tv370 = v368 + 8;\n\tv372 = *([v425 @ X11_v24-8]);\n\tv430 = v372 == v355;\n\tif (v430) goto L_0063;\n\tv392 = v424 + 1;\n\tv437 = v392 < v356;\n\tv390 = ~v437;\n\tv394 = v425 + 0x10;\n\tv374 = ~v390;\n\tif (v374) goto L_FFFFFFFF;\n\tv395 = v159;\n\tv396 = 0;\n\tv397 = 0x8909C4(v395, v355, v396, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_006A;\nL_0063:\n\tv438 = *([v425 @ X11_v24]);\n\tv439 = v438 << 4;\n\tv440 = v354 + v439;\n\tv441 = v440 + 0x130;\nL_006A:\n\tv462 = System.Collections.IEnumerator::MoveNext(v97);\n\tv464 = v462 == 0;\n\tif (v464) goto L_FFFFFFFF;\n\tv466 = *([v97 @ X0_v40 (System.Collections.IEnumerator)]);\n\tv469 = *([v466 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v469) goto L_0090;\n\tv539 = *([v466 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_007B:\n\tv544 = *([v539 @ X11_v19-8]) == System.Collections.IEnumerator;\n\tif (v544) goto L_0093;\n\tv538 = v538 + 1;\n\tv579 = v538 < *([v466 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv519 = ~v579;\n\tv539 = v539 + 0x10;\n\tv503 = ~v519;\n\tif (v503) goto L_007B;\nL_0090:\n\tv598 = 0x8909C4(v97, System.Collections.IEnumerator, 1, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_009A;\nL_0093:\n\tv581 = *([v539 @ X11_v19]) + 1;\n\tv582 = v581 << 4;\n\tv583 = v466 + v582;\n\tv598 = v583 + 0x130;\nL_009A:\n\t*([v598 @ X0_v45])(v603, v97, *([v598 @ X0_v45+8]), v587, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_FFFFFFFF;\n\tv323 = v323_asT == 0;\n\tif (v323) goto L_00EA;\n\tv726 = UnityEngine.Object::get_name(v603);\n\tv347 = System.String::Contains(v726, \"Body_P\");\n\tv350 = v347 == 0;\n\tif (v350) goto L_0043;\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(v64, v603);\n\tgoto L_0043;\nL_00D0:\n\tv67 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00E4;\n\tv82 = *([v75 @ X8_v9+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_00E4;\n\tv95 = v75;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v95, v66, v56, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00E4:\n\tUnityEngine.Debug::LogError(\"Set the Parts of Enemy!\", v67);\n\tgoto L_016A;\n\tgoto L_010E;\nL_00EA:\n\tthrow System.InvalidCastException;\n\tv680 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv155 = new System.NullReferenceException();\n\tv162 = new System.NullReferenceException();\nL_00F1:\n\tv254 = new System.NullReferenceException();\n\tgoto L_0104;\n\tgoto L_0104;\n\tgoto L_0104;\n\tgoto L_0104;\n\tgoto L_0104;\n\tgoto L_0104;\n\tgoto L_0104;\n\tgoto L_0104;\n\tgoto L_0104;\nL_0104:\n\tv367 = 0 != 1;\n\tif (v367) goto L_0171;\n\tv398 = Morpeh.MonoProvider`1<GBG.Pinata.ECS.Components.EnemyPartsComponent>::GetData(v254, 0);\n\tv166 = *([v398 @ X0_v36 (GBG.Pinata.ECS.Components.EnemyPartsComponent&)]);\n\tv436 = Morpeh.MonoProvider`1<GBG.Pinata.ECS.Components.EnemyPartsComponent>::GetData(v398, 0);\nL_010E:\n\t// 270 IsInst v496 @ X0_v17 (System.IDisposable), typeof(System.IDisposable), v491 @ X21_v4 (System.Collections.IEnumerator)\n\tv527 = v496 == 0;\n\tif (v527) goto L_013E;\n\tgoto L_013D;\n\tv605 = *([v549 @ X8_v23+B0]);\n\tv606 = 0;\n\tv607 = v605 + 8;\n\tv609 = *([v692 @ X11_v8-8]);\n\tv697 = v609 == v550;\n\tif (v697) goto L_0136;\n\tv629 = v691 + 1;\n\tv731 = v629 < v551;\n\tv627 = ~v731;\n\tv631 = v692 + 0x10;\n\tv611 = ~v627;\n\tif (v611) goto L_FFFFFFFF;\n\tv632 = v213;\n\tv633 = 0;\n\tv634 = 0x8909C4(v632, v550, v633, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_013D;\nL_0136:\n\tv732 = *([v692 @ X11_v8]);\n\tv733 = v732 << 4;\n\tv734 = v549 + v733;\n\tv735 = v734 + 0x130;\nL_013D:\n\tSystem.IDisposable::Dispose(v496);\nL_013E:\n\tv578 = v202 + 1;\n\tv405 = v578 == 0;\n\tv174 = ~v405;\n\tif (v174) goto L_0148;\n\tv635 = v166 == 0;\n\tv636 = ~v635;\n\tif (v636) goto L_0170;\nL_0148:\n\tv638 = *([v57 @ X0_v3 (GBG.Pinata.ECS.Components.EnemyPartsComponent&)]);\n\tv184 = v64._size == *([v638 @ X8_v19+18]);\n\tif (v184) goto L_016A;\n\tv208 = System.Collections.Generic.List`1<UnityEngine.Transform>::ToArray(v64);\n\t*([v57 @ X0_v3 (GBG.Pinata.ECS.Components.EnemyPartsComponent&)]) = v208;\nL_016A:\n\treturn;\n\tthrow System.NullReferenceException;\nL_0170:\n\tv411 = new System.TypeLoadException();\nL_0171:\n\tv300 = Morpeh.MonoProvider`1<GBG.Pinata.ECS.Components.EnemyPartsComponent>::GetData(v410, v297);\n\treturn;\n// 230 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void OnValidate()
		{
			//IL_027e: Expected I4, but got O
			//IL_0288: Expected O, but got Ref
			//IL_0063: Expected I, but got O
			//IL_009e: Expected O, but got I
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected O, but got Unknown
			//IL_0146: Expected O, but got I
			//IL_0155: Expected O, but got I
			//IL_00ea: Expected O, but got I
			bool existOnEntity = false;
			ref EnemyPartsComponent data = ref GetData(out existOnEntity);
			ref bool existOnEntity2;
			MonoProvider<EnemyPartsComponent> monoProvider;
			if ((object)data != null)
			{
				List<Transform> list = new List<Transform>();
				Transform transform = base.transform;
				IEnumerator enumerator = transform.GetEnumerator();
				bool flag = enumerator == null;
				existOnEntity2 = ref *(bool*)null;
				IEnumerator enumerator2 = enumerator;
				int num;
				int num2;
				if (flag)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag2 = 0 != 1;
					monoProvider = (MonoProvider<EnemyPartsComponent>)(object)ex;
					if (flag2)
					{
						goto IL_033d;
					}
					ref EnemyPartsComponent data2 = ref ((MonoProvider<EnemyPartsComponent>)(object)ex).GetData(out *(bool*)null);
					num = (int)data2;
					ref EnemyPartsComponent data3 = ref ((MonoProvider<EnemyPartsComponent>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref data2)).GetData(out *(bool*)null);
					num2 = -1;
				}
				else
				{
					UnityEngine.Object obj5 = default(UnityEngine.Object);
					while (enumerator.MoveNext())
					{
						IntPtr intPtr = (IntPtr)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0103;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj = 0L + 8L;
						int num3 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ X11_v19-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag3 = (long)num4 < 0L;
							bool flag4 = !flag3;
							obj = (long)(IntPtr)obj + 16L;
							if (!flag4)
							{
								continue;
							}
							goto IL_0103;
						}
						object obj2 = obj + 1;
						int num5 = (int)((long)(IntPtr)obj2 << 4);
						object obj3 = (long)intPtr + (long)num5;
						object obj4 = (long)(IntPtr)obj3 + 304L;
						int num6 = 0;
						goto IL_03dc;
						IL_0103:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						num6 = 1;
						goto IL_03dc;
						IL_03dc:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v598 @ X0_v45] (should have been resolved before IL gen)");
						Transform transform2 = obj5 as Transform;
						if ((object)transform2 != null)
						{
							string text = obj5.name;
							if (text.Contains("Body_P"))
							{
								list.Add((Transform)obj5);
							}
							continue;
						}
						throw new InvalidCastException();
					}
					num = 0;
					num2 = 0;
					enumerator2 = enumerator;
				}
				(enumerator2 as IDisposable)?.Dispose();
				if (num2 + 1 != 0 || num == 0)
				{
					object obj6 = data;
					int count = list.Count;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ X8_v19+18]");
					if ((IntPtr)count != (IntPtr)0)
					{
						Transform[] array = list.ToArray();
						data = ref *(EnemyPartsComponent*)array;
					}
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
				existOnEntity2 = ref *(bool*)null;
				monoProvider = (MonoProvider<EnemyPartsComponent>)(object)ex2;
				goto IL_033d;
			}
			GameObject context = base.gameObject;
			Debug.LogError("Set the Parts of Enemy!", context);
			return;
			IL_033d:
			ref EnemyPartsComponent data4 = ref monoProvider.GetData(out existOnEntity2);
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0xCC2D24", Offset = "0xCC2D24", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFCC88]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023755]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<GBG.Pinata.ECS.Components.EnemyPartsComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnemyPartsProvider()
		{
		}
	}
}
