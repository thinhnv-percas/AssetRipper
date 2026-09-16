using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.InAppPurchase.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200004C")]
	public class SetStateGameObjectListSystem : UpdateSystem
	{
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x6000091")]
		[Address(RVA = "0xCC189C", Offset = "0xCC189C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBB860]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023748]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<SetStateGameObjectListComponent>();
			this.filter = filter;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0xCC190C", Offset = "0xCC190C", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001D;\n\tv33 = *([1EAB978]);\n\tv34 = *([v33 @ X8_v31]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, deltaTime, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2023749]) = v53;\nL_001D:\n\tv55 = &v56 @ stack_-D0;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\tv62 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv376 = *([v21 @ X29-B0]);\n\tv375 = *([v21 @ X29-A0]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-B0]);\n\t*([v21 @ X29-60]) = *([v21 @ X29-A0]);\nL_0039:\n\tv254 = &v21 @ X29 - 0x70;\n\tv256 = 0x15F75B8(v254, 0, v231, v38, v39, v40, v41, v42, v375, v376, v45, v46, v47, v48, v49, v50);\n\tv300 = v256 & 1;\n\tv301 = v300 == 0;\n\tif (v301) goto L_00DA;\n\tv304 = *([v21 @ X29-68]);\n\tv178 = Il2CppMethodInfo;\n\tv347 = *([v304 @ X20_v9]);\n\tv231 = *([v178 @ X21_v9 (Il2CppMethodInfo)+48]);\n\tv350 = *([v347 @ X8_v17+126]) == 0;\n\tif (v350) goto L_0065;\n\tv439 = *([v347 @ X8_v17+B0]) + 8;\nL_0051:\n\tv444 = *([v439 @ X11_v12-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v444) goto L_0068;\n\tv438 = v438 + 1;\n\tv536 = v438 < *([v347 @ X8_v17+126]);\n\tv412 = ~v536;\n\tv439 = v439 + 0x10;\n\tv396 = ~v412;\n\tif (v396) goto L_0051;\nL_0065:\n\tv543 = 0x8909C4(v304, Il2CppClass<Morpeh.IEntity>, v231, v38, v39, v40, v41, v42, v375, v376, v45, v46, v47, v48, v49, v50);\n\tgoto L_006E;\nL_0068:\n\tv538 = *([v439 @ X11_v12]) + v231;\n\tv539 = v538 << 4;\n\tv540 = v347 + v539;\n\tv543 = v540 + 0x130;\nL_006E:\n\tv547 = Morpeh.IEntity::GetComponent(*([v543 @ X0_v29+8]));\n\t*([v547 @ X0_v31 (GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectListComponent&)])(v576, v304, v547, v231, v38, v39, v40, v41, v42, v375, v376, v45, v46, v47, v48, v49, v50);\n\tv241 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v576 @ X0_v33]));\n\tv244 = v241 == 0;\n\tif (v244) goto L_0039;\n\tv580 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>::GetEnumerator(*([v576 @ X0_v33+10]));\n\tv376 = *([v21 @ X29-B0]);\n\tv375 = *([v21 @ X29-A0]);\n\t*([v21 @ X29-90]) = *([v21 @ X29-B0]);\n\t*([v21 @ X29-80]) = *([v21 @ X29-A0]);\nL_0088:\n\tv597 = &v21 @ X29 - 0x90;\n\tv598 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>::MoveNext(v597);\n\tv600 = v598 == 0;\n\tif (v600) goto L_009F;\n\tv295 = *([v21 @ X29-80]) == 0;\n\tif (v295) goto L_00A4;\n\tv586 = *([v21 @ X29-78]) == 0;\n\tv581 = ~v586;\n\tUnityEngine.GameObject::SetActive(*([v21 @ X29-80]), v581);\n\tgoto L_0088;\nL_009F:\n\tv323 = v323 + 1;\n\t*([v55 @ X22_v1+v323 @ X23_v8*4]) = 0x68;\n\tgoto L_00BA;\nL_00A4:\n\tv293 = new System.NullReferenceException();\n\tgoto L_00E3;\n\tgoto L_00A8;\n\tgoto L_00A8;\nL_00A8:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00F7;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BA:\n\tv603 = &v21 @ X29 - 0x90;\n\tv242 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>::Dispose(v603);\n\tv245 = v323 + 1;\n\tv605 = v245 == 0;\n\tif (v605) goto L_00D4;\n\tv202 = *([v55 @ X22_v1+v323 @ X23_v8*4]) != 0x68;\n\tif (v202) goto L_00D4;\n\tv250 = 0xFFFFFFFF ^ v323;\n\tv323 = v323 + v250;\n\tgoto L_0039;\nL_00D4:\n\tv246 = ~v381;\n\tif (v246) goto L_0039;\n\tthrow System.TypeLoadException;\nL_00DA:\n\tv369 = v323 + 1;\n\t*([v55 @ X22_v1+v369 @ X23_v1*4]) = 0x81;\n\tgoto L_00FC;\n\tv352 = new System.NullReferenceException();\n\tv128 = new System.NullReferenceException();\n\tv137 = new System.NullReferenceException();\n\tv198 = new System.NullReferenceException();\nL_00E3:\n\tgoto L_00F7;\n\t// 228 Jump @b52\n\t// 229 Jump @b52\n\t// 230 Jump @b52\n\t// 231 Jump @b52\n\t// 232 Jump @b52\n\t// 233 Jump @b52\n\t// 234 Jump @b52\nL_00F7:\n\tv346 = v290 != 1;\n\tif (v346) goto L_0128;\n\tv388 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>::MoveNext(v292);\n\tv381 = v388.m_value;\n\tv379 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>::MoveNext(v388);\nL_00FC:\n\tv385 = &v21 @ X29 - 0x70;\n\tv387 = 0x15F7664(v385, 0, v231, v38, v39, v40, v41, v42, v375, v376, v45, v46, v47, v48, v49, v50);\n\tv423 = v369 + 1;\n\tv425 = v423 == 0;\n\tif (v425) goto L_0116;\n\tv449 = ~v381;\n\tif (v449) goto L_0127;\n\tv553 = *([v55 @ X22_v1+v369 @ X23_v1*4]) == 0x81;\n\tif (v553) goto L_0127;\nL_0115:\n\tthrow System.TypeLoadException;\nL_0116:\n\tv476 = ~v381;\n\tv477 = ~v476;\n\tif (v477) goto L_0115;\nL_0127:\n\treturn;\nL_0128:\n\tv389 = System.Collections.Generic.List`1<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>+Enumerator<GBG.Pinata.ECS.InAppPurchase.Components.GameObjectsState>::MoveNext(v292);\n\treturn;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnUpdate(float deltaTime)
		{
			//IL_002c: Expected O, but got I
			//IL_003c: Expected O, but got I
			//IL_0063: Expected O, but got I8
			//IL_04ff: Expected O, but got I
			//IL_0375: Expected O, but got I
			//IL_03d8: Expected O, but got I
			//IL_03f1: Expected O, but got I
			//IL_0081: Expected O, but got I
			//IL_00a4: Expected O, but got I
			//IL_04dd: Expected O, but got I
			//IL_00df: Expected O, but got I
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_017e: Expected O, but got I
			//IL_018d: Expected O, but got I
			//IL_01cd: Expected O, but got I
			//IL_01e1: Expected O, but got I
			//IL_01f1: Expected O, but got I
			//IL_012b: Expected O, but got I
			//IL_0544: Expected O, but got I
			//IL_0285: Expected O, but got I
			//IL_02ad: Expected O, but got I
			//IL_02c5: Expected O, but got I
			//IL_026c: Expected O, but got I
			//IL_031d: Expected I4, but got I8
			//IL_032b: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Filter.EntityEnumerator enumerator = filter.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A0]");
			_ = 0;
			object obj6 = 4294967295L;
			bool flag = false;
			object obj8 = default(object);
			object obj15 = default(object);
			object obj18 = default(object);
			IntPtr intPtr2 = default(IntPtr);
			NullReferenceException ex3 = default(NullReferenceException);
			object obj20 = default(object);
			object obj21 = default(object);
			while (true)
			{
				object obj7 = (long)(IntPtr)obj - 112L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				NullReferenceException ex;
				if ((uint)((ulong)(long)(IntPtr)obj8 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
					object obj9 = 0;
					IntPtr intPtr = (IntPtr)0;
					object obj10 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ X21_v9 (Il2CppMethodInfo)+48]");
					ex = (NullReferenceException)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v17+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0144;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v17+B0]");
					object obj11 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X11_v12-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X8_v17+126]");
						bool flag2 = (long)num2 < 0L;
						bool flag3 = !flag2;
						obj11 = (long)(IntPtr)obj11 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_0144;
					}
					object obj12 = obj11 + (long)(IntPtr)ex;
					int num3 = (int)((long)(IntPtr)obj12 << 4);
					object obj13 = (long)(IntPtr)obj10 + (long)num3;
					object obj14 = (long)(IntPtr)obj13 + 304L;
					goto IL_04cc;
				}
				obj15 = (long)(IntPtr)obj6 + 1L;
				_ = 129;
				goto IL_03c9;
				IL_0144:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_04cc;
				IL_03c9:
				object obj16 = (long)(IntPtr)obj - 112L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj17 = (long)(IntPtr)obj15 + 1L;
				if (obj17 != null)
				{
					if (!flag)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X22_v1+v369 @ X23_v1*4]");
					if ((IntPtr)0 == (IntPtr)129)
					{
						return;
					}
				}
				else if (!flag)
				{
					return;
				}
				throw new TypeLoadException();
				IL_04cc:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X0_v29+8]");
				ref SetStateGameObjectListComponent component = ref ((IEntity)0).GetComponent<SetStateGameObjectListComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v547 @ X0_v31 (GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectListComponent&)] (should have been resolved before IL gen)");
				if (!((BaseGlobalEvent<int>)obj18).IsPublished)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ X0_v33+10]");
				List<GameObjectsState>.Enumerator enumerator2 = ((List<GameObjectsState>)0).GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
				obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A0]");
				obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A0]");
				_ = 0;
				while (true)
				{
					List<GameObjectsState>.Enumerator enumerator3 = (List<GameObjectsState>.Enumerator)((long)(IntPtr)obj - 144L);
					if (!((List<GameObjectsState>.Enumerator*)enumerator3)->MoveNext())
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
						bool flag4 = (IntPtr)0 == (IntPtr)0;
						bool active = !flag4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
						((GameObject)0).SetActive(active);
						ex = null;
						continue;
					}
					goto IL_0290;
				}
				obj6 = (long)(IntPtr)obj6 + 1L;
				_ = 104;
				List<GameObjectsState>.Enumerator enumerator4 = (List<GameObjectsState>.Enumerator)((long)(IntPtr)obj - 144L);
				((List<GameObjectsState>.Enumerator*)enumerator4)->Dispose();
				object obj19 = (long)(IntPtr)obj6 + 1L;
				if (obj19 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X22_v1+v323 @ X23_v8*4]");
					if ((IntPtr)0 == (IntPtr)104)
					{
						int num4 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj6);
						obj6 = (long)(IntPtr)obj6 + (long)num4;
						continue;
					}
				}
				bool flag5 = !flag;
				flag = false;
				if (!flag5)
				{
					ex = null;
					flag = false;
					throw new TypeLoadException();
				}
				continue;
				IL_0290:
				NullReferenceException ex2 = new NullReferenceException();
				if (intPtr2 != (IntPtr)1)
				{
					break;
				}
				bool flag6 = ((List<GameObjectsState>.Enumerator*)ex3)->MoveNext();
				flag = ((bool*)(flag6 ? 1 : 0))->m_value;
				bool flag7 = (flag6 ? ((List<GameObjectsState>.Enumerator*)1) : ((List<GameObjectsState>.Enumerator*)null))->MoveNext();
				ex = ex3;
				obj5 = obj20;
				obj4 = obj21;
				goto IL_03c9;
			}
			bool flag8 = ((List<GameObjectsState>.Enumerator*)ex3)->MoveNext();
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0xCC1BFC", Offset = "0xCC1BFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetStateGameObjectListSystem()
		{
		}
	}
}
