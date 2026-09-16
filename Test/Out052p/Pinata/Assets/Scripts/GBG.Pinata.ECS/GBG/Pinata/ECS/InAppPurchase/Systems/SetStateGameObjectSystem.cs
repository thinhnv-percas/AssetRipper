using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.InAppPurchase.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200004D")]
	public class SetStateGameObjectSystem : UpdateSystem
	{
		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x6000094")]
		[Address(RVA = "0xCC1C04", Offset = "0xCC1C04", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBE3A0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202374A]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<SetStateGameObjectComponent>();
			this.filter = filter;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0xCC1C74", Offset = "0xCC1C74", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EA5250]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, deltaTime, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202374B]) = v42;\nL_0019:\n\tv47 = this.filter == 0;\n\tif (v47) goto L_0081;\n\tv51 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv130 = v51.world;\nL_0030:\n\tv194 = 0x15F75B8(&v130 @ stack_-70_v3 (Morpeh.World), 0, v172, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv205 = v194 & 1;\n\tv206 = v205 == 0;\n\tif (v206) goto L_007B;\n\tv191 = Il2CppMethodInfo;\n\tv228 = *([v210 @ stack_-48]);\n\tv172 = *([v191 @ X20_v8 (Il2CppMethodInfo)+48]);\n\tv231 = *([v228 @ X8_v9+126]) == 0;\n\tif (v231) goto L_005A;\n\tv379 = *([v228 @ X8_v9+B0]) + 8;\nL_0041:\n\t;\n\tv384 = *([v379 @ X11_v10-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v384) goto L_005C;\n\tv378 = v378 + 1;\n\tv390 = v378 < *([v228 @ X8_v9+126]);\n\tv257 = ~v390;\n\tv379 = v379 + 0x10;\n\tv241 = ~v257;\n\tif (v241) goto L_0041;\nL_005A:\n\tv397 = 0x8909C4(v210, Il2CppClass<Morpeh.IEntity>, v172, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tgoto L_0061;\nL_005C:\n\t;\n\tv392 = *([v379 @ X11_v10]) + v172;\n\tv393 = v392 << 4;\n\tv394 = v228 + v393;\n\tv397 = v394 + 0x130;\nL_0061:\n\t;\n\tv401 = Morpeh.IEntity::GetComponent(*([v397 @ X0_v26+8]));\n\t*([v401 @ X0_v28 (GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectComponent&)])(v403, v210, v401, v172, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tv181 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v403 @ X0_v30]));\n\tv184 = v181 == 0;\n\tif (v184) goto L_0030;\n\tUnityEngine.GameObject::SetActive(*([v403 @ X0_v30+10]), *([v403 @ X0_v30+18]));\n\tgoto L_0030;\nL_007B:\n\tv214 = 0x15F7664(&v130 @ stack_-70_v3 (Morpeh.World), 0, v172, v27, v28, v29, v30, v31, v51.ids, v51.world, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A3;\n\tv233 = new System.NullReferenceException();\n\tv288 = new System.NullReferenceException();\n\tv134 = new System.NullReferenceException();\nL_0081:\n\tv143 = new System.NullReferenceException();\n\tgoto L_0091;\n\tgoto L_0091;\n\tgoto L_0091;\n\tgoto L_0091;\n\tgoto L_0091;\n\tgoto L_0091;\nL_0091:\n\tv204 = v131 != 1;\n\tif (v204) goto L_00A4;\n\tv207 = 0x6D2BC0(v143, v131, v91, v27, v28, v29, v30, v31, v118, v130, v34, v35, v36, v37, v38, v39);\n\tv216 = 0x6D2490(v207, v131, v91, v27, v28, v29, v30, v31, v118, v130, v34, v35, v36, v37, v38, v39);\n\tv220 = 0x15F7664(&v98 @ stack_-50_v3 (Morpeh.World), 0, v91, v27, v28, v29, v30, v31, v118, v130, v34, v35, v36, v37, v38, v39);\n\tv330 = *([v207 @ X0_v10]) == 0;\n\tv222 = ~v330;\n\tif (v222) goto L_00A8;\nL_00A3:\n\treturn;\nL_00A4:\n\tv208 = 0x6D2380(v143, v131, v91, v27, v28, v29, v30, v31, v118, v130, v34, v35, v36, v37, v38, v39);\nL_00A8:\n\tthrow System.TypeLoadException;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_0045: Expected O, but got I
			//IL_028b: Expected O, but got I
			//IL_0081: Expected O, but got I
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_0121: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_00cd: Expected O, but got I
			//IL_0183: Expected O, but got I
			//IL_018c: Expected O, but got I4
			bool flag = filter == null;
			World world2 = default(World);
			World world = world2;
			if (!flag)
			{
				world2 = filter.GetEnumerator().world;
				object obj = default(object);
				object obj3 = default(object);
				object obj9 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X20_v8 (Il2CppMethodInfo)+48]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v9+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00e6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v9+B0]");
					object obj5 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ X11_v10-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v9+126]");
						bool flag2 = (long)num2 < 0L;
						bool flag3 = !flag2;
						obj5 = (long)(IntPtr)obj5 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_00e6;
					}
					object obj6 = obj5 + (long)(IntPtr)obj4;
					int num3 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)(IntPtr)obj2 + (long)num3;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_0279;
					IL_00e6:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0279;
					IL_0279:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X0_v26+8]");
					ref SetStateGameObjectComponent component = ref ((IEntity)0).GetComponent<SetStateGameObjectComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v401 @ X0_v28 (GBG.Pinata.ECS.InAppPurchase.Components.SetStateGameObjectComponent&)] (should have been resolved before IL gen)");
					if (((BaseGlobalEvent<int>)obj9).IsPublished)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ X0_v30+10]");
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ X0_v30+18]");
						((GameObject)(long)intPtr2).SetActive(value: false);
						obj4 = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr3 = default(IntPtr);
			if (intPtr3 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj10 = default(object);
				if (obj10 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0xCC1E30", Offset = "0xCC1E30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetStateGameObjectSystem()
		{
		}
	}
}
