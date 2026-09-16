using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200006C")]
	public class InitializeEnemiesSystem : UpdateSystem
	{
		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0xCC58C4", Offset = "0xCC58C4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDFAD0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023766]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv48 = Morpeh.Filter::With(v42, 1);\n\tv63 = Morpeh.Filter::Without(v48, 1);\n\tthis.filter = v63;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<EnemyConfigComponent>();
			Filter filter2 = filter.Without<EnemiesInitializedMarker>();
			this.filter = filter2;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0xCC594C", Offset = "0xCC594C", Length = "0x444")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1F05400]);\n\tv35 = *([v34 @ X8_v36]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023767]) = v54;\nL_001E:\n\tv58 = 0;\n\tv59 = 0;\n\tv60 = 0;\n\tv64 = 0;\n\tv65 = 0;\n\tv67 = this.filter == 0;\n\tif (v67) goto L_016C;\n\tv71 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv181 = v71.world;\n\tv128 = &v64 @ stack_-A8_v1 (Morpeh.World) + 0x10;\nL_0046:\n\tv246 = 0x15F75B8(&v181 @ stack_-E0_v3 (Morpeh.World), 0, v840, v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tv259 = v246 & 1;\n\tv260 = v259 == 0;\n\tif (v260) goto L_0165;\n\tv281 = Il2CppMethodInfo;\n\tv364 = *([v263 @ stack_-78]);\n\tv286 = *([v364 @ X8_v19 (System.Int32)+126]) == 0;\n\tif (v286) goto L_0070;\n\tv480 = *([v364 @ X8_v19 (System.Int32)+B0]) + 8;\nL_0057:\n\t;\n\tv485 = *([v480 @ X11_v34-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v485) goto L_0072;\n\tv479 = v479 + 1;\n\tv497 = v479 < *([v364 @ X8_v19 (System.Int32)+126]);\n\tv312 = ~v497;\n\tv480 = v480 + 0x10;\n\tv296 = ~v312;\n\tif (v296) goto L_0057;\nL_0070:\n\tv517 = 0x8909C4(v263, Il2CppClass<Morpeh.IEntity>, *([v281 @ X21_v7 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_0077;\nL_0072:\n\t;\n\tv499 = *([v480 @ X11_v34]) + *([v281 @ X21_v7 (Il2CppMethodInfo)+48]);\n\tv500 = v499 << 4;\n\tv364 = v364 + v500;\n\tv517 = v364 + 0x130;\nL_0077:\n\t;\n\tv521 = 0x8D8294(*([v517 @ X0_v27+8]), Il2CppMethodInfo, *([v281 @ X21_v7 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\t*([v521 @ X0_v29])(v527, v263, &v58 @ stack_-B4_v1, v521, v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tv229 = *([v527 @ X0_v31]);\n\tv353 = Il2CppMethodInfo;\n\tv64 = 0;\n\t*([v128 @ X27_v4+10]) = *([v527 @ X0_v31+10]);\n\t*([v128 @ X27_v4]) = *([v527 @ X0_v31]);\n\tv364 = *([v263 @ stack_-78]);\n\tv535 = *([v364 @ X8_v19 (System.Int32)+126]) == 0;\n\tif (v535) goto L_00AD;\n\tv576 = *([v364 @ X8_v19 (System.Int32)+B0]) + 8;\nL_0094:\n\t;\n\tv581 = *([v576 @ X11_v29-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v581) goto L_00AF;\n\tv575 = v575 + 1;\n\tv586 = v575 < *([v364 @ X8_v19 (System.Int32)+126]);\n\tv558 = ~v586;\n\tv576 = v576 + 0x10;\n\tv542 = ~v558;\n\tif (v542) goto L_0094;\nL_00AD:\n\tv593 = 0x8909C4(v263, Il2CppClass<Morpeh.IEntity>, *([v353 @ X21_v8 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_00B4;\nL_00AF:\n\t;\n\tv588 = *([v576 @ X11_v29]) + *([v353 @ X21_v8 (Il2CppMethodInfo)+48]);\n\tv589 = v588 << 4;\n\tv364 = v364 + v589;\n\tv593 = v364 + 0x130;\nL_00B4:\n\t;\n\tv597 = 0x8D8294(*([v593 @ X0_v32+8]), Il2CppMethodInfo, *([v353 @ X21_v8 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\t*([v597 @ X0_v34])(v600, v263, &v59 @ stack_-B8_v1, v597, v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tv364 = *([v600 @ X0_v36+4]);\n\tv364 = v364 << 0x20;\n\tv494 = Morpeh.World::CreateEntity(this.world, &v60 @ stack_-BC_v1 (System.Int32));\n\tv602 = Il2CppMethodInfo;\n\tv603 = *([v494 @ X0_v38 (Morpeh.IEntity)]);\n\tv607 = *([v603 @ X8_v20 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v607) goto L_00EC;\n\tv648 = *([v603 @ X8_v20 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_00D3:\n\t;\n\tv653 = *([v648 @ X11_v24-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v653) goto L_00EE;\n\tv647 = v647 + 1;\n\tv658 = v647 < *([v603 @ X8_v20 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv630 = ~v658;\n\tv648 = v648 + 0x10;\n\tv614 = ~v630;\n\tif (v614) goto L_00D3;\nL_00EC:\n\tv678 = 0x8909C4(v494, Il2CppClass<Morpeh.IEntity>, *([v602 @ X22_v5 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_00F3;\nL_00EE:\n\t;\n\tv660 = *([v648 @ X11_v24]) + *([v602 @ X22_v5 (Il2CppMethodInfo)+48]);\n\tv661 = v660 << 4;\n\tv364 = v603 + v661;\n\tv678 = v364 + 0x130;\nL_00F3:\n\t;\n\tv682 = 0x8D8294(*([v678 @ X0_v39+8]), Il2CppMethodInfo, *([v602 @ X22_v5 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\t*([v682 @ X0_v41])(v688, v494, &v64 @ stack_-A8_v1 (Morpeh.World), v682, v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tv192 = Il2CppMethodInfo;\n\tv689 = *([v494 @ X0_v38 (Morpeh.IEntity)]);\n\tv693 = *([v689 @ X8_v23 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v693) goto L_011F;\n\tv734 = *([v689 @ X8_v23 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0106:\n\t;\n\tv739 = *([v734 @ X11_v19-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v739) goto L_0121;\n\tv733 = v733 + 1;\n\tv744 = v733 < *([v689 @ X8_v23 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv716 = ~v744;\n\tv734 = v734 + 0x10;\n\tv700 = ~v716;\n\tif (v700) goto L_0106;\nL_011F:\n\tv764 = 0x8909C4(v494, Il2CppClass<Morpeh.IEntity>, *([v192 @ X22_v6 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_0126;\nL_0121:\n\t;\n\tv746 = *([v734 @ X11_v19]) + *([v192 @ X22_v6 (Il2CppMethodInfo)+48]);\n\tv747 = v746 << 4;\n\tv364 = v689 + v747;\n\tv764 = v364 + 0x130;\nL_0126:\n\t;\n\tv768 = 0x8D8294(*([v764 @ X0_v44+8]), Il2CppMethodInfo, *([v192 @ X22_v6 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\t*([v768 @ X0_v46])(v774, v494, &v364 @ X8_v19 (System.Int32), v768, v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tv228 = Il2CppMethodInfo;\n\tv364 = *([v263 @ stack_-78]);\n\tv240 = *([v364 @ X8_v19 (System.Int32)+126]) == 0;\n\tif (v240) goto L_0152;\n\tv819 = *([v364 @ X8_v19 (System.Int32)+B0]) + 8;\nL_0139:\n\t;\n\tv824 = *([v819 @ X11_v14-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v824) goto L_0154;\n\tv818 = v818 + 1;\n\tv829 = v818 < *([v364 @ X8_v19 (System.Int32)+126]);\n\tv801 = ~v829;\n\tv819 = v819 + 0x10;\n\tv785 = ~v801;\n\tif (v785) goto L_0139;\nL_0152:\n\tv836 = 0x8909C4(v263, Il2CppClass<Morpeh.IEntity>, *([v228 @ X21_v10 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_0159;\nL_0154:\n\t;\n\tv831 = *([v819 @ X11_v14]) + *([v228 @ X21_v10 (Il2CppMethodInfo)+48]);\n\tv832 = v831 << 4;\n\tv364 = v364 + v832;\n\tv836 = v364 + 0x130;\nL_0159:\n\t;\n\tv840 = 0x8D8294(*([v836 @ X0_v49+8]), Il2CppMethodInfo, *([v228 @ X21_v10 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\t*([v840 @ X0_v51])(v238, v263, &v65 @ stack_-C0_v1, v840, v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_0046;\nL_0165:\n\tv267 = 0x15F7664(&v181 @ stack_-E0_v3 (Morpeh.World), 0, v840, v39, v40, v41, v42, v43, v229, v71.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_0197;\n\tv288 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv173 = new System.NullReferenceException();\nL_016C:\n\tv180 = new System.NullReferenceException();\n\tgoto L_017F;\n\tgoto L_017F;\n\tgoto L_017F;\n\tgoto L_017F;\n\tgoto L_017F;\n\tgoto L_017F;\n\tgoto L_017F;\nL_017F:\n\tv258 = v170 != 1;\n\tif (v258) goto L_0198;\n\tv261 = 0x6D2BC0(v180, v170, v180, v39, v40, v41, v42, v43, v143, v181, v46, v47, v48, v49, v50, v51);\n\tv269 = 0x6D2490(v261, v170, v180, v39, v40, v41, v42, v43, v143, v181, v46, v47, v48, v49, v50, v51);\n\tv273 = 0x15F7664(&v133 @ stack_-80_v3 (Morpeh.World), 0, v180, v39, v40, v41, v42, v43, v143, v181, v46, v47, v48, v49, v50, v51);\n\tv422 = *([v261 @ X0_v10]) == 0;\n\tv275 = ~v422;\n\tif (v275) goto L_019C;\nL_0197:\n\treturn;\nL_0198:\n\tv262 = 0x6D2380(v180, v170, v180, v39, v40, v41, v42, v43, v143, v181, v46, v47, v48, v49, v50, v51);\nL_019C:\n\tthrow System.TypeLoadException;\n// 242 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_05af: Expected O, but got I4
			//IL_05b8: Expected O, but got I4
			//IL_05cf: Expected O, but got I4
			//IL_0030: Expected O, but got I
			//IL_0050: Expected I4, but got O
			//IL_0665: Expected I4, but got O
			//IL_008e: Expected O, but got I
			//IL_0163: Expected O, but got I
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Expected O, but got Unknown
			//IL_0147: Expected O, but got I4
			//IL_00da: Expected O, but got I
			//IL_0247: Expected I, but got O
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Expected O, but got Unknown
			//IL_021c: Expected O, but got I4
			//IL_01af: Expected O, but got I
			//IL_0739: Expected I, but got O
			//IL_0285: Expected O, but got I
			//IL_07ac: Expected I4, but got O
			//IL_035b: Expected O, but got I
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Expected O, but got Unknown
			//IL_033f: Expected O, but got I4
			//IL_02d1: Expected O, but got I
			//IL_0431: Expected O, but got I
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ea: Expected O, but got Unknown
			//IL_0415: Expected O, but got I4
			//IL_03a7: Expected O, but got I
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c0: Expected O, but got Unknown
			//IL_04ea: Expected O, but got I4
			//IL_047d: Expected O, but got I
			object obj = 0;
			object obj2 = 0;
			int id = 0;
			World world = null;
			object obj3 = 0;
			bool flag = filter == null;
			World world3 = default(World);
			World world2 = world3;
			if (!flag)
			{
				Filter.EntityEnumerator enumerator = filter.GetEnumerator();
				world3 = enumerator.world;
				object obj4 = (long)(IntPtr)world + 16L;
				int[] ids = enumerator.ids;
				object obj5 = default(object);
				object obj6 = default(object);
				object obj15 = default(object);
				while (true)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj5 & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)0;
					int num = (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00f3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+B0]");
					object obj7 = 0L + 8L;
					int num2 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ X11_v34-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num2++;
						int num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+126]");
						bool flag2 = (long)num3 < 0L;
						bool flag3 = !flag2;
						obj7 = (long)(IntPtr)obj7 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_00f3;
					}
					object obj8 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X21_v7 (Il2CppMethodInfo)+48]");
					object obj9 = obj8 + 0;
					int num4 = (int)((long)(IntPtr)obj9 << 4);
					num += num4;
					object obj10 = num + 304;
					goto IL_0619;
					IL_06af:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v597 @ X0_v34] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ X0_v36+4]");
					num = 0;
					num <<= 32;
					IEntity entity = World.CreateEntity(out id);
					IntPtr intPtr2 = (IntPtr)0;
					IntPtr intPtr3 = (IntPtr)entity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ X8_v20 (Il2CppClass<Morpeh.IEntity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_02ea;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ X8_v20 (Il2CppClass<Morpeh.IEntity>)+B0]");
					object obj11 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ X11_v24-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ X8_v20 (Il2CppClass<Morpeh.IEntity>)+126]");
						bool flag4 = (long)num6 < 0L;
						bool flag5 = !flag4;
						obj11 = (long)(IntPtr)obj11 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_02ea;
					}
					object obj12 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X22_v5 (Il2CppMethodInfo)+48]");
					object obj13 = obj12 + 0;
					int num7 = (int)((long)(IntPtr)obj13 << 4);
					num = (int)((long)intPtr3 + (long)num7);
					object obj14 = num + 304;
					goto IL_0710;
					IL_07f6:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v840 @ X0_v51] (should have been resolved before IL gen)");
					continue;
					IL_0496:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_07f6;
					IL_03c0:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0783;
					IL_00f3:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0619;
					IL_0619:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v521 @ X0_v29] (should have been resolved before IL gen)");
					ids = (int[])obj15;
					IntPtr intPtr4 = (IntPtr)0;
					world = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ X0_v31+10]");
					_ = 0;
					obj4 = obj15;
					num = (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01c8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+B0]");
					object obj16 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ X11_v29-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+126]");
						bool flag6 = (long)num9 < 0L;
						bool flag7 = !flag6;
						obj16 = (long)(IntPtr)obj16 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_01c8;
					}
					object obj17 = obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ X21_v8 (Il2CppMethodInfo)+48]");
					object obj18 = obj17 + 0;
					int num10 = (int)((long)(IntPtr)obj18 << 4);
					num += num10;
					object obj19 = num + 304;
					goto IL_06af;
					IL_02ea:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0710;
					IL_0710:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v682 @ X0_v41] (should have been resolved before IL gen)");
					IntPtr intPtr5 = (IntPtr)0;
					IntPtr intPtr6 = (IntPtr)entity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ X8_v23 (Il2CppClass<Morpeh.IEntity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_03c0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ X8_v23 (Il2CppClass<Morpeh.IEntity>)+B0]");
					object obj20 = 0L + 8L;
					int num11 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num11++;
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ X8_v23 (Il2CppClass<Morpeh.IEntity>)+126]");
						bool flag8 = (long)num12 < 0L;
						bool flag9 = !flag8;
						obj20 = (long)(IntPtr)obj20 + 16L;
						if (!flag9)
						{
							continue;
						}
						goto IL_03c0;
					}
					object obj21 = obj20;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X22_v6 (Il2CppMethodInfo)+48]");
					object obj22 = obj21 + 0;
					int num13 = (int)((long)(IntPtr)obj22 << 4);
					num = (int)((long)intPtr6 + (long)num13);
					object obj23 = num + 304;
					goto IL_0783;
					IL_0783:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v768 @ X0_v46] (should have been resolved before IL gen)");
					IntPtr intPtr7 = (IntPtr)0;
					num = (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+B0]");
						object obj24 = 0L + 8L;
						int num14 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ X11_v14-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num14++;
							int num15 = num14;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v19 (System.Int32)+126]");
							bool flag10 = (long)num15 < 0L;
							bool flag11 = !flag10;
							obj24 = (long)(IntPtr)obj24 + 16L;
							if (!flag11)
							{
								continue;
							}
							goto IL_0496;
						}
						object obj25 = obj24;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X21_v10 (Il2CppMethodInfo)+48]");
						object obj26 = obj25 + 0;
						int num16 = (int)((long)(IntPtr)obj26 << 4);
						num += num16;
						object obj27 = num + 304;
						goto IL_07f6;
					}
					goto IL_0496;
					IL_01c8:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_06af;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr8 = default(IntPtr);
			if (intPtr8 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj28 = default(object);
				if (obj28 == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0xCC5D90", Offset = "0xCC5D90", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F09B98]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023768]) = v40;\nL_0018:\n\tv45 = this.filter == 0;\n\tif (v45) goto L_0079;\n\tv47 = Morpeh.FilterProvider::get_All(this.filter);\n\tv135 = v47 == 0;\n\tif (v135) goto L_0079;\n\tv132 = Morpeh.Filter::With(v47, 1);\n\tv136 = v132 == 0;\n\tif (v136) goto L_0079;\n\tv158 = Morpeh.Filter::GetEnumerator(v132);\n\tv122 = v158.world;\nL_0038:\n\tv215 = Morpeh.Filter::With(&v122 @ stack_-70_v3 (Morpeh.World), 0);\n\tv289 = v215 & 1;\n\tv290 = v289 == 0;\n\tif (v290) goto L_0074;\n\tgoto L_006A;\n\tv305 = *([v299 @ X8_v10+B0]);\n\tv306 = 0;\n\tv307 = v305 + 8;\n\tv309 = *([v349 @ X11_v9-8]);\n\tv354 = v309 == v300;\n\tif (v354) goto L_0063;\n\tv329 = v348 + 1;\n\tv359 = v329 < v301;\n\tv327 = ~v359;\n\tv331 = v349 + 0x10;\n\tv311 = ~v327;\n\tif (v311) goto L_FFFFFFFF;\n\tv332 = v141;\n\tv333 = 0;\n\tv334 = 0x8909C4(v332, v300, v333, v25, v26, v27, v28, v29, v97, v99, v32, v33, v34, v35, v36, v37);\n\tgoto L_006A;\nL_0063:\n\tv360 = *([v349 @ X11_v9]);\n\tv361 = v360 << 4;\n\tv362 = v299 + v361;\n\tv363 = v362 + 0x130;\nL_006A:\n\tSystem.IDisposable::Dispose(v296);\n\tMorpeh.World::RemoveEntity(this.world, v296);\n\tgoto L_0038;\nL_0074:\n\tv293 = Morpeh.Filter::With(&v122 @ stack_-70_v3 (Morpeh.World), 0);\n\tgoto L_0098;\n\tv304 = new System.NullReferenceException();\n\tv131 = new System.NullReferenceException();\nL_0079:\n\tv142 = new System.NullReferenceException();\n\tgoto L_0087;\n\tgoto L_0087;\n\tgoto L_0087;\n\tgoto L_0087;\nL_0087:\n\tv153 = v127 != 1;\n\tif (v153) goto L_0099;\n\tv154 = Morpeh.Filter::With(v142, v127);\n\tv160 = Morpeh.Filter::With(v154, v127);\n\tv164 = Morpeh.Filter::With(&v92 @ stack_-50_v3 (Morpeh.World), 0);\n\tv216 = *([v154 @ X0_v10 (Morpeh.Filter)]) == 0;\n\tv166 = ~v216;\n\tif (v166) goto L_009D;\nL_0098:\n\treturn;\nL_0099:\n\tv155 = Morpeh.Filter::With(v142, v127);\nL_009D:\n\tthrow System.TypeLoadException;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Dispose()
		{
			bool flag = Filter == null;
			World world = null;
			bool flag2 = true;
			if (!flag)
			{
				Filter all = Filter.All;
				bool flag3 = all == null;
				World world2 = default(World);
				world = world2;
				bool flag4 = default(bool);
				flag2 = flag4;
				if (!flag3)
				{
					Filter filter = all.With<EnemyComponent>();
					bool flag5 = filter == null;
					world = null;
					flag2 = false;
					if (!flag5)
					{
						world2 = filter.GetEnumerator().world;
						IDisposable disposable = default(IDisposable);
						while (true)
						{
							Filter filter2 = ((Filter)(object)world2).With<EnemyComponent>(false);
							if ((int)((long)(IntPtr)filter2 & 1L) == 0)
							{
								break;
							}
							disposable.Dispose();
							World.RemoveEntity((IEntity)disposable);
						}
						Filter filter3 = ((Filter)(object)world2).With<EnemyComponent>(false);
						return;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (flag2)
			{
				Filter filter4 = ((Filter)(object)ex).With<EnemyComponent>(flag2);
				Filter filter5 = filter4.With<EnemyComponent>(flag2);
				Filter filter6 = ((Filter)(object)world).With<EnemyComponent>(false);
				if (filter4 == null)
				{
					return;
				}
			}
			else
			{
				Filter filter7 = ((Filter)(object)ex).With<EnemyComponent>(flag2);
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0xCC5F28", Offset = "0xCC5F28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InitializeEnemiesSystem()
		{
		}
	}
}
