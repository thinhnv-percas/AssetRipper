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
	[Token(Token = "0x2000049")]
	public class OpenURLSystem : UpdateSystem
	{
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x6000085")]
		[Address(RVA = "0xCC0F64", Offset = "0xCC0F64", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDEFF0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023741]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<OpenURLComponent>();
			this.filter = filter;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0xCC0FD4", Offset = "0xCC0FD4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = *([2023742]) & 1;\n\tv19 = v18 == 0;\n\tv20 = ~v19;\n\tif (v20) goto L_001A;\n\tv23 = 0xCCDC14(this, methodInfo, v258, v26, v27, v28, v29, v30, deltaTime, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023742]) = X8;\nL_001A:\n\tv43 = this.filter == 0;\n\tif (v43) goto L_0080;\n\tv47 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv126 = v47.world;\nL_0031:\n\tv278 = 0x15F75B8(&v126 @ stack_-70_v3 (Morpeh.World), 0, *([v275 @ X20_v7 (Il2CppMethodInfo)+48]), v26, v27, v28, v29, v30, v47.ids, v47.world, v33, v34, v35, v36, v37, v38);\n\tv280 = v278 & 1;\n\tv281 = v280 == 0;\n\tif (v281) goto L_007A;\n\tv275 = Il2CppMethodInfo;\n\tv297 = *([v284 @ stack_-48]);\n\tv258 = *([v275 @ X20_v7 (Il2CppMethodInfo)+48]);\n\tv300 = *([v297 @ X8_v7+126]) == 0;\n\tif (v300) goto L_005B;\n\tv354 = *([v297 @ X8_v7+B0]) + 8;\nL_0042:\n\t;\n\tv359 = *([v354 @ X11_v9-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v359) goto L_005D;\n\tv353 = v353 + 1;\n\tv364 = v353 < *([v297 @ X8_v7+126]);\n\tv326 = ~v364;\n\tv354 = v354 + 0x10;\n\tv310 = ~v326;\n\tif (v310) goto L_0042;\nL_005B:\n\tv371 = 0x8909C4(v284, Il2CppClass<Morpeh.IEntity>, *([v275 @ X20_v7 (Il2CppMethodInfo)+48]), v26, v27, v28, v29, v30, v47.ids, v47.world, v33, v34, v35, v36, v37, v38);\n\tgoto L_0062;\nL_005D:\n\t;\n\tv366 = *([v354 @ X11_v9]) + *([v275 @ X20_v7 (Il2CppMethodInfo)+48]);\n\tv367 = v366 << 4;\n\tv368 = v297 + v367;\n\tv371 = v368 + 0x130;\nL_0062:\n\t;\n\tv375 = Morpeh.IEntity::GetComponent(*([v371 @ X0_v24+8]));\n\t*([v375 @ X0_v26 (GBG.Pinata.ECS.InAppPurchase.Components.OpenURLComponent&)])(v335, v284, v375, *([v275 @ X20_v7 (Il2CppMethodInfo)+48]), v26, v27, v28, v29, v30, v47.ids, v47.world, v33, v34, v35, v36, v37, v38);\n\tv266 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v335 @ X0_v28]));\n\tv269 = v266 == 0;\n\tif (v269) goto L_0031;\n\tUnityEngine.Application::OpenURL(*([v335 @ X0_v28+8]));\n\tgoto L_0031;\nL_007A:\n\tv288 = 0x15F7664(&v126 @ stack_-70_v3 (Morpeh.World), 0, *([v275 @ X20_v7 (Il2CppMethodInfo)+48]), v26, v27, v28, v29, v30, v47.ids, v47.world, v33, v34, v35, v36, v37, v38);\n\tgoto L_00A1;\n\tthrow System.NullReferenceException;\n\tv130 = new System.NullReferenceException();\nL_0080:\n\tv139 = new System.NullReferenceException();\n\tgoto L_008F;\n\tgoto L_008F;\n\tgoto L_008F;\n\tgoto L_008F;\n\tgoto L_008F;\nL_008F:\n\tv148 = v127 != 1;\n\tif (v148) goto L_00A2;\n\tv282 = 0x6D2BC0(v139, v127, v87, v26, v27, v28, v29, v30, v114, v126, v33, v34, v35, v36, v37, v38);\n\tv290 = 0x6D2490(v282, v127, v87, v26, v27, v28, v29, v30, v114, v126, v33, v34, v35, v36, v37, v38);\n\tv294 = 0x15F7664(&v94 @ stack_-50_v3 (Morpeh.World), 0, v87, v26, v27, v28, v29, v30, v114, v126, v33, v34, v35, v36, v37, v38);\n\tv342 = *([v282 @ X0_v9]) == 0;\n\tv295 = ~v342;\n\tif (v295) goto L_00A6;\nL_00A1:\n\treturn;\nL_00A2:\n\tv283 = 0x6D2380(v139, v127, v87, v26, v27, v28, v29, v30, v114, v126, v33, v34, v35, v36, v37, v38);\nL_00A6:\n\tthrow System.TypeLoadException;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_0089: Expected O, but got I
			//IL_02bb: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Expected O, but got Unknown
			//IL_016c: Expected O, but got I
			//IL_017b: Expected O, but got I
			//IL_01bc: Expected O, but got I
			//IL_0111: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2023742]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CCDC14 (inside WeaponParametersProvider::.ctor +0x64)");
				return;
			}
			bool flag = filter == null;
			World world2 = default(World);
			World world = world2;
			if (!flag)
			{
				world2 = filter.GetEnumerator().world;
				object obj = default(object);
				object obj3 = default(object);
				object obj10 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ X20_v7 (Il2CppMethodInfo)+48]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X8_v7+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_012a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X8_v7+B0]");
					object obj5 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ X11_v9-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X8_v7+126]");
						bool flag2 = (long)num2 < 0L;
						bool flag3 = !flag2;
						obj5 = (long)(IntPtr)obj5 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_012a;
					}
					object obj6 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ X20_v7 (Il2CppMethodInfo)+48]");
					object obj7 = obj6 + 0;
					int num3 = (int)((long)(IntPtr)obj7 << 4);
					object obj8 = (long)(IntPtr)obj2 + (long)num3;
					object obj9 = (long)(IntPtr)obj8 + 304L;
					goto IL_02a9;
					IL_012a:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_02a9;
					IL_02a9:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ X0_v24+8]");
					ref OpenURLComponent component = ref ((IEntity)0).GetComponent<OpenURLComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v375 @ X0_v26 (GBG.Pinata.ECS.InAppPurchase.Components.OpenURLComponent&)] (should have been resolved before IL gen)");
					if (((BaseGlobalEvent<int>)obj10).IsPublished)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ X0_v28+8]");
						Application.OpenURL((string)0);
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr2 = default(IntPtr);
			if (intPtr2 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj11 = default(object);
				if (obj11 == null)
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

		[Token(Token = "0x6000087")]
		[Address(RVA = "0xCC1188", Offset = "0xCC1188", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OpenURLSystem()
		{
		}
	}
}
