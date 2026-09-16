using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200006E")]
	public class InitializeWeaponsSystem : UpdateSystem
	{
		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x30")]
		private GameConfig config;

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0xCC5F30", Offset = "0xCC5F30", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFFA68]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023769]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv48 = Morpeh.Filter::With(v42, 1);\n\tv74 = Morpeh.Filter::Without(v48, 1);\n\tthis.filter = v74;\n\tv63 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v63;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<WeaponsConfigComponent>();
			Filter filter2 = filter.Without<WeaponsInitializedMarker>();
			this.filter = filter2;
			GameConfig instance = GameConfig.Instance;
			config = instance;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0xCC5FC0", Offset = "0xCC5FC0", Length = "0x5F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv30 = &v25 @ stack_-10_v2 - 0x70;\n\tgoto L_0020;\n\tv35 = *([1EEFA50]);\n\tv36 = *([v35 @ X8_v65]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, deltaTime, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202376A]) = v55;\nL_0020:\n\t*([v30 @ X19_v1]) = 0;\n\t*([v30 @ X19_v1+10]) = 0;\n\tv62 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(&v58 @ stack_-F0);\n\tv70 = this.filter == 0;\n\tif (v70) goto L_01E4;\n\tv74 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv265 = &v58 @ stack_-F0 | 6;\n\tv266 = &v58 @ stack_-F0 + 0x20;\n\t*([v30 @ X19_v1]) = v74.world;\n\t*([v30 @ X19_v1+10]) = v74.ids;\nL_0042:\n\tv395 = &v25 @ stack_-10_v2 - 0x70;\n\tv397 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v395);\n\tv408 = v397 & 1;\n\tv409 = v408 == 0;\n\tif (v409) goto L_01C6;\n\tv388 = *([v24 @ X29_v1-68]);\n\tv430 = *([v366 @ X25_v20 (Il2CppMethodInfo)]);\n\tv431 = *([v388 @ X19_v22 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv435 = *([v431 @ X8_v21 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v435) goto L_006E;\n\tv835 = *([v431 @ X8_v21 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_0055:\n\t;\n\tv840 = *([v835 @ X11_v42-8]) == *([v430 @ X21_v17+18]);\n\tif (v840) goto L_0070;\n\tv834 = v834 + 1;\n\tv907 = v834 < *([v431 @ X8_v21 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv578 = ~v907;\n\tv835 = v835 + 0x10;\n\tv562 = ~v578;\n\tif (v562) goto L_0055;\nL_006E:\n\tv914 = 0x8909C4(v388, *([v430 @ X21_v17+18]), *([v430 @ X21_v17+48]), v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\tgoto L_0075;\nL_0070:\n\t;\n\tv909 = *([v835 @ X11_v42]) + *([v430 @ X21_v17+48]);\n\tv910 = v909 << 4;\n\tv911 = v431 + v910;\n\tv914 = v911 + 0x130;\nL_0075:\n\t;\n\tv918 = 0x8D8294(*([v914 @ X0_v54+8]), v430, *([v430 @ X21_v17+48]), v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\tv654 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v388);\n\tv660 = this.config;\n\tv975 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v660.Weapon.Data);\n\tv981 = this.config;\n\tv1105 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v981.Weapon);\n\tv1520 = *([v975 @ X0_v60 (GBG.Pinata.ECS.WeaponSetup)+18]) < v1105;\n\tv1167 = ~v1520;\n\tv1165 = *([v975 @ X0_v60 (GBG.Pinata.ECS.WeaponSetup)+18]) - v1105;\n\tv1161 = v1165 == 0;\n\tv1521 = ~v1161;\n\tv1151 = v1167 & v1521;\n\tif (v1151) goto L_00AB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00AB:\n\tv1269 = v654.m_value;\nL_00B8:\n\t;\n\tgoto L_00C4;\nL_00BA:\n\tv1251 = v1251 + 1;\nL_00C4:\n\tv1227 = v1251 >= *([v1269 @ X8_v35 (System.Int32)+18]);\n\tif (v1227) goto L_0154;\n\tv1596 = v1251 < *([v1269 @ X8_v35 (System.Int32)+18]);\n\tv1325 = ~v1596;\n\tif (v1325) goto L_01CA;\n\tv1308 = v1251 << 4;\n\tv1331 = v1269 + v1308;\n\tv1328 = *([v1331 @ X9_v37 (System.Int32)+20]) & 0xFF;\n\tv1594 = v1328 == 0;\n\tif (v1594) goto L_00BA;\n\tv1507 = UnityEngine.Transform::get_position(*([v1331 @ X9_v37 (System.Int32)+28]));\n\t*([v265 @ X8_v6 (System.Int32)+10]) = 0;\n\tv265.m_value = 0;\n\t*([v266 @ X8_v7]) = 0;\n\tv1526 = Morpeh.World::CreateEntity(this.world);\n\tv1541 = Il2CppMethodInfo;\n\tv1690 = *([v1526 @ X0_v90 (Morpeh.IEntity)]);\n\tv1694 = *([v1690 @ X8_v57 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v1694) goto L_0137;\n\tv1775 = *([v1690 @ X8_v57 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_011E:\n\t;\n\tv1780 = *([v1775 @ X11_v37-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1780) goto L_013A;\n\tv1774 = v1774 + 1;\n\tv1807 = v1774 < *([v1690 @ X8_v57 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv1728 = ~v1807;\n\tv1775 = v1775 + 0x10;\n\tv1712 = ~v1728;\n\tif (v1712) goto L_011E;\nL_0137:\n\tv1815 = 0x8909C4(v1526, Il2CppClass<Morpeh.IEntity>, *([v1541 @ X23_v22 (Il2CppMethodInfo)+48]), v40, v41, v42, v43, v44, v1507, v1507.y, v1507.z, 0, 0, v50, v51, v52);\n\tgoto L_0140;\nL_013A:\n\t;\n\tv1810 = *([v1775 @ X11_v37]) + *([v1541 @ X23_v22 (Il2CppMethodInfo)+48]);\n\tv1811 = v1810 << 4;\n\tv1812 = v1690 + v1811;\n\tv1815 = v1812 + 0x130;\nL_0140:\n\t;\n\tv1819 = 0x8D8294(*([v1815 @ X0_v91+8]), Il2CppMethodInfo, *([v1541 @ X23_v22 (Il2CppMethodInfo)+48]), v40, v41, v42, v43, v44, v1507, v1507.y, v1507.z, 0, 0, v50, v51, v52);\n\tv1819.m_value(v1561, v1526, &v328 @ X26_v19 (System.Int32), v1819, v40, v41, v42, v43, v44, v1507, v1507.y, v1507.z, 0, 0, v50, v51, v52);\n\tv1269 = v654.m_value;\n\tv328 = v328 + 1;\n\tv1251 = v1251 + 1;\n\tv1835 = v654.m_value == 0;\n\tv1563 = ~v1835;\n\tif (v1563) goto L_00B8;\n\tgoto L_01CF;\nL_0154:\n\tv1417 = Morpeh.World::CreateEntity(this.world);\n\tv372 = 0;\n\tv334 = Il2CppMethodInfo;\n\tv1602 = *([v1417 @ X0_v69 (Morpeh.IEntity)]);\n\tv1606 = *([v1602 @ X8_v39 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v1606) goto L_0181;\n\tv1653 = *([v1602 @ X8_v39 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0168:\n\t;\n\tv1658 = *([v1653 @ X11_v30-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1658) goto L_0183;\n\tv1652 = v1652 + 1;\n\tv1663 = v1652 < *([v1602 @ X8_v39 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv1635 = ~v1663;\n\tv1653 = v1653 + 0x10;\n\tv1619 = ~v1635;\n\tif (v1619) goto L_0168;\nL_0181:\n\tv1683 = 0x8909C4(v1417, Il2CppClass<Morpeh.IEntity>, *([v334 @ X22_v20 (Il2CppMethodInfo)+48]), v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\tgoto L_0188;\nL_0183:\n\t;\n\tv1665 = *([v1653 @ X11_v30]) + *([v334 @ X22_v20 (Il2CppMethodInfo)+48]);\n\tv1666 = v1665 << 4;\n\tv1667 = v1602 + v1666;\n\tv1683 = v1667 + 0x130;\nL_0188:\n\t;\n\tv1687 = 0x8D8294(*([v1683 @ X0_v70+8]), Il2CppMethodInfo, *([v334 @ X22_v20 (Il2CppMethodInfo)+48]), v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\t*([v1687 @ X0_v72])(v1700, v1417, &v372 @ stack_-128_v8, v1687, v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\tv364 = Il2CppMethodInfo;\n\tv1703 = *([v388 @ X19_v22 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv359 = *([v364 @ X21_v21 (Il2CppMethodInfo)+48]);\n\tv386 = *([v1703 @ X8_v44 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v386) goto L_01B6;\n\tv1797 = *([v1703 @ X8_v44 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_019D:\n\t;\n\tv1802 = *([v1797 @ X11_v25-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1802) goto L_01B8;\n\tv1796 = v1796 + 1;\n\tv1820 = v1796 < *([v1703 @ X8_v44 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv1757 = ~v1820;\n\tv1797 = v1797 + 0x10;\n\tv1741 = ~v1757;\n\tif (v1741) goto L_019D;\nL_01B6:\n\tv1827 = 0x8909C4(v388, Il2CppClass<Morpeh.IEntity>, v359, v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\tgoto L_01BD;\nL_01B8:\n\t;\n\tv1822 = *([v1797 @ X11_v25]) + v359;\n\tv1823 = v1822 << 4;\n\tv1824 = v1703 + v1823;\n\tv1827 = v1824 + 0x130;\nL_01BD:\n\t;\n\tv1831 = Morpeh.IEntity::AddComponent(*([v1827 @ X0_v75+8]));\n\t*([v1831 @ X0_v77 (GBG.Pinata.ECS.Systems.WeaponsInitializedMarker&)])(v384, v388, v1831, v359, v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\tgoto L_0042;\nL_01C6:\n\tv414 = &v25 @ stack_-10_v2 - 0x70;\n\tv416 = 0x15F7664(v414, 0, v359, v40, v41, v42, v43, v44, v382, v368, v1507.z, 0, 0, v50, v51, v52);\n\tgoto L_021E;\nL_01CA:\n\tv1597 = new System.IndexOutOfRangeException();\n\tthrow v1597;\nL_01CF:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv664 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv984 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv1190 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv1426 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv253 = new System.NullReferenceException();\nL_01E4:\n\tv264 = new System.NullReferenceException();\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_0206;\n\tgoto L_02\n// ... truncated")]
		public unsafe override void OnUpdate(float deltaTime)
		{
			//IL_0017: Expected O, but got I
			//IL_076c: Expected O, but got I4
			//IL_0049: Expected O, but got I
			//IL_09a6: Expected O, but got I
			//IL_06f6: Expected O, but got I4
			//IL_0689: Expected O, but got I
			//IL_070e: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_00ab: Expected O, but got I
			//IL_00b3: Expected I, but got O
			//IL_00f2: Expected O, but got I
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Expected O, but got Unknown
			//IL_019e: Expected O, but got I
			//IL_01ad: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_049a: Expected O, but got I4
			//IL_04ad: Expected I, but got O
			//IL_0918: Expected I, but got O
			//IL_04eb: Expected O, but got I
			//IL_0983: Expected O, but got I
			//IL_05c2: Expected O, but got I
			//IL_0575: Unknown result type (might be due to invalid IL or missing references)
			//IL_057a: Expected O, but got Unknown
			//IL_0597: Expected O, but got I
			//IL_05a6: Expected O, but got I
			//IL_0537: Expected O, but got I
			//IL_0337: Expected O, but got I
			//IL_0358: Expected O, but got I4
			//IL_0644: Unknown result type (might be due to invalid IL or missing references)
			//IL_0649: Expected O, but got Unknown
			//IL_0666: Expected O, but got I
			//IL_0675: Expected O, but got I
			//IL_060e: Expected O, but got I
			//IL_037f: Expected I, but got O
			//IL_08b0: Expected O, but got F4
			//IL_03bd: Expected O, but got I
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_044c: Expected O, but got Unknown
			//IL_0469: Expected O, but got I
			//IL_0478: Expected O, but got I
			//IL_0409: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)obj2 - 112L;
			obj3 = 0;
			_ = 0;
			object obj4 = default(object);
			int value = ((BaseGlobalVariable<int>)obj4).Value;
			if (filter != null)
			{
				Filter.EntityEnumerator enumerator = filter.GetEnumerator();
				int num = (int)((long)(IntPtr)obj4 | 6L);
				object obj5 = (long)(IntPtr)obj4 + 32L;
				obj3 = enumerator.world;
				_ = enumerator.ids;
				int num2 = 112;
				IntPtr intPtr = (IntPtr)0;
				World world = enumerator.world;
				int[] ids = enumerator.ids;
				while (true)
				{
					BaseGlobalVariable<int> baseGlobalVariable = (BaseGlobalVariable<int>)((long)(IntPtr)obj2 - 112L);
					int value2 = baseGlobalVariable.Value;
					if ((value2 & 1) == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-68]");
					BaseGlobalVariable<int> baseGlobalVariable2 = (BaseGlobalVariable<int>)0;
					object obj6 = (long)intPtr;
					IntPtr intPtr2 = (IntPtr)baseGlobalVariable2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ X8_v21 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0157;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ X8_v21 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
					object obj7 = 0L + 8L;
					int num3 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ X11_v42-8]");
						IntPtr intPtr3 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ X21_v17+18]");
						if (intPtr3 == (IntPtr)0)
						{
							break;
						}
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ X8_v21 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
						bool flag = (long)num4 < 0L;
						bool flag2 = !flag;
						obj7 = (long)(IntPtr)obj7 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0157;
					}
					object obj8 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ X21_v17+48]");
					object obj9 = obj8 + 0;
					int num5 = (int)((long)(IntPtr)obj9 << 4);
					object obj10 = (long)intPtr2 + (long)num5;
					object obj11 = (long)(IntPtr)obj10 + 304L;
					goto IL_07cb;
					IL_08ef:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1687 @ X0_v72] (should have been resolved before IL gen)");
					IntPtr intPtr4 = (IntPtr)0;
					IntPtr intPtr5 = (IntPtr)baseGlobalVariable2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X21_v21 (Il2CppMethodInfo)+48]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1703 @ X8_v44 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1703 @ X8_v44 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
						object obj12 = 0L + 8L;
						int num6 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1797 @ X11_v25-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num6++;
							int num7 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1703 @ X8_v44 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
							bool flag3 = (long)num7 < 0L;
							bool flag4 = !flag3;
							obj12 = (long)(IntPtr)obj12 + 16L;
							if (!flag4)
							{
								continue;
							}
							goto IL_0627;
						}
						object obj13 = obj12 + num2;
						int num8 = (int)((long)(IntPtr)obj13 << 4);
						object obj14 = (long)intPtr5 + (long)num8;
						object obj15 = (long)(IntPtr)obj14 + 304L;
						goto IL_0971;
					}
					goto IL_0627;
					IL_0971:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1827 @ X0_v75+8]");
					ref WeaponsInitializedMarker reference = ref ((IEntity)0).AddComponent<WeaponsInitializedMarker>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1831 @ X0_v77 (GBG.Pinata.ECS.Systems.WeaponsInitializedMarker&)] (should have been resolved before IL gen)");
					continue;
					IL_0627:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0971;
					IL_0550:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_08ef;
					IL_0157:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_07cb;
					IL_07cb:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
					int value3 = baseGlobalVariable2.Value;
					GameConfig gameConfig = config;
					WeaponSetup value4 = gameConfig.Weapon.Data.Value;
					GameConfig gameConfig2 = config;
					int value5 = ((BaseGlobalVariable<int>)gameConfig2.Weapon).Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ X0_v60 (GBG.Pinata.ECS.WeaponSetup)+18]");
					bool flag5 = 0L < (long)value5;
					bool flag6 = !flag5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ X0_v60 (GBG.Pinata.ECS.WeaponSetup)+18]");
					int num9 = (int)(-value5);
					bool flag7 = num9 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						throw new ArgumentOutOfRangeException();
					}
					int value6 = ((int*)value3)->m_value;
					int num10 = 0;
					int num11 = 0;
					while (true)
					{
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ X8_v35 (System.Int32)+18]");
						if ((long)num12 >= 0L)
						{
							break;
						}
						int num13 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ X8_v35 (System.Int32)+18]");
						Vector3 position;
						if ((long)num13 < 0L)
						{
							int num14 = num11 << 4;
							int num15 = value6 + num14;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1331 @ X9_v37 (System.Int32)+20]");
							if (0 == 0)
							{
								num11++;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1331 @ X9_v37 (System.Int32)+28]");
							position = ((Transform)0).position;
							_ = 0;
							((int*)num)->m_value = 0;
							obj5 = 0;
							IEntity entity = World.CreateEntity();
							IntPtr intPtr6 = (IntPtr)0;
							IntPtr intPtr7 = (IntPtr)entity;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ X8_v57 (Il2CppClass<Morpeh.IEntity>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_0422;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ X8_v57 (Il2CppClass<Morpeh.IEntity>)+B0]");
							object obj16 = 0L + 8L;
							int num16 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1775 @ X11_v37-8]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									break;
								}
								num16++;
								int num17 = num16;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ X8_v57 (Il2CppClass<Morpeh.IEntity>)+126]");
								bool flag9 = (long)num17 < 0L;
								bool flag10 = !flag9;
								obj16 = (long)(IntPtr)obj16 + 16L;
								if (!flag10)
								{
									continue;
								}
								goto IL_0422;
							}
							object obj17 = obj16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ X23_v22 (Il2CppMethodInfo)+48]");
							object obj18 = obj17 + 0;
							int num18 = (int)((long)(IntPtr)obj18 << 4);
							object obj19 = (long)intPtr7 + (long)num18;
							object obj20 = (long)(IntPtr)obj19 + 304L;
							goto IL_0841;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
						IL_0422:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						goto IL_0841;
						IL_0841:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1819.m_value (System.Int32) (should have been resolved before IL gen)");
						value6 = ((int*)value3)->m_value;
						num10++;
						num11++;
						bool flag11 = ((int*)value3)->m_value == 0;
						bool flag12 = !flag11;
						world = (World)position.y;
						ids = (int[])position;
						if (!flag12)
						{
							throw new NullReferenceException();
						}
					}
					IEntity entity2 = World.CreateEntity();
					object obj21 = 0;
					IntPtr intPtr8 = (IntPtr)0;
					IntPtr intPtr9 = (IntPtr)entity2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1602 @ X8_v39 (Il2CppClass<Morpeh.IEntity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0550;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1602 @ X8_v39 (Il2CppClass<Morpeh.IEntity>)+B0]");
					object obj22 = 0L + 8L;
					int num19 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1653 @ X11_v30-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num19++;
						int num20 = num19;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1602 @ X8_v39 (Il2CppClass<Morpeh.IEntity>)+126]");
						bool flag13 = (long)num20 < 0L;
						bool flag14 = !flag13;
						obj22 = (long)(IntPtr)obj22 + 16L;
						if (!flag14)
						{
							continue;
						}
						goto IL_0550;
					}
					object obj23 = obj22;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X22_v20 (Il2CppMethodInfo)+48]");
					object obj24 = obj23 + 0;
					int num21 = (int)((long)(IntPtr)obj24 << 4);
					object obj25 = (long)intPtr9 + (long)num21;
					object obj26 = (long)(IntPtr)obj25 + 304L;
					goto IL_08ef;
				}
				object obj27 = (long)(IntPtr)obj2 - 112L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex2 = new NullReferenceException();
			if (0 == 1)
			{
				int value7 = ((BaseGlobalVariable<int>)(object)ex2).Value;
				int value8 = ((BaseGlobalVariable<int>)value7).Value;
				object obj28 = (long)(IntPtr)obj2 - 112L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				if (((int*)value7)->m_value == 0)
				{
					return;
				}
			}
			else
			{
				int value9 = ((BaseGlobalVariable<int>)(object)ex2).Value;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xCC65B4", Offset = "0xCC65B4", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EAE068]);\n\tv21 = *([v20 @ X8_v27]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202376B]) = v40;\nL_001B:\n\tv47 = Morpeh.FilterProvider::get_All(this.filter);\n\tv163 = Morpeh.Filter::With(v47, 1);\n\tv278 = &v147 @ stack_-70_v5 (Morpeh.World);\n\tv280 = Morpeh.Filter::GetEnumerator(v163);\n\tv147 = *([v278 @ X8_v8]);\nL_0038:\n\tv383 = Morpeh.Filter::With(&v147 @ stack_-70_v5 (Morpeh.World), 0);\n\tv384 = v383 & 1;\n\tv385 = v384 == 0;\n\tif (v385) goto L_0074;\n\tgoto L_006A;\n\tv397 = *([v391 @ X8_v21+B0]);\n\tv398 = 0;\n\tv399 = v397 + 8;\n\tv401 = *([v453 @ X11_v19-8]);\n\tv458 = v401 == v392;\n\tif (v458) goto L_0063;\n\tv421 = v452 + 1;\n\tv463 = v421 < v393;\n\tv419 = ~v463;\n\tv423 = v453 + 0x10;\n\tv403 = ~v419;\n\tif (v403) goto L_FFFFFFFF;\n\tv424 = v274;\n\tv425 = 0;\n\tv426 = 0x8909C4(v424, v392, v425, v25, v26, v27, v28, v29, v114, v117, v32, v33, v34, v35, v36, v37);\n\tgoto L_006A;\nL_0063:\n\tv464 = *([v453 @ X11_v19]);\n\tv465 = v464 << 4;\n\tv466 = v391 + v465;\n\tv467 = v466 + 0x130;\nL_006A:\n\tSystem.IDisposable::Dispose(v386);\n\tv377 = this.world == 0;\n\tif (v377) goto L_0078;\n\tMorpeh.World::RemoveEntity(this.world, v386);\n\tgoto L_0038;\nL_0074:\n\tv390 = Morpeh.Filter::With(&v147 @ stack_-70_v5 (Morpeh.World), 0);\n\tgoto L_0095;\n\tv396 = new System.NullReferenceException();\nL_0078:\n\tv439 = new System.NullReferenceException();\n\tgoto L_0086;\n\tgoto L_0086;\n\tgoto L_0086;\n\tgoto L_0086;\nL_0086:\n\tv188 = 0 != 1;\n\tif (v188) goto L_0113;\n\tv473 = Morpeh.Filter::With(v439, 0);\n\tv476 = Morpeh.Filter::With(v473, 0);\n\tv229 = Morpeh.Filter::With(&v147 @ stack_-70_v5 (Morpeh.World), 0);\n\tv481 = *([v473 @ X0_v42 (Morpeh.Filter)]) == 0;\n\tv231 = ~v481;\n\tif (v231) goto L_00F3;\nL_0095:\n\tv165 = Morpeh.FilterProvider::get_All(this.filter);\n\tv166 = Morpeh.Filter::With(v165, 1);\n\tv480 = Morpeh.Filter::GetEnumerator(v166);\n\tv147 = v480.world;\nL_00B0:\n\tv507 = Morpeh.Filter::With(&v147 @ stack_-70_v5 (Morpeh.World), 0);\n\tv508 = v507 & 1;\n\tv332 = v508 == 0;\n\tif (v332) goto L_00EC;\n\tgoto L_00E2;\n\tv517 = *([v511 @ X8_v16+B0]);\n\tv518 = 0;\n\tv519 = v517 + 8;\n\tv521 = *([v561 @ X11_v12-8]);\n\tv566 = v521 == v512;\n\tif (v566) goto L_00DB;\n\tv541 = v560 + 1;\n\tv571 = v541 < v513;\n\tv539 = ~v571;\n\tv543 = v561 + 0x10;\n\tv523 = ~v539;\n\tif (v523) goto L_FFFFFFFF;\n\tv544 = v180;\n\tv545 = 0;\n\tv546 = 0x8909C4(v544, v512, v545, v25, v26, v27, v28, v29, v113, v116, v32, v33, v34, v35, v36, v37);\n\tgoto L_00E2;\nL_00DB:\n\tv572 = *([v561 @ X11_v12]);\n\tv573 = v572 << 4;\n\tv574 = v511 + v573;\n\tv575 = v574 + 0x130;\nL_00E2:\n\tSystem.IDisposable::Dispose(v386);\n\tMorpeh.World::RemoveEntity(this.world, v386);\n\tgoto L_00B0;\nL_00EC:\n\tv330 = Morpeh.Filter::With(&v147 @ stack_-70_v5 (Morpeh.World), 0);\n\tgoto L_0112;\n\tv516 = new System.NullReferenceException();\n\tv162 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00F3:\n\tgoto L_0117;\n\tgoto L_00F8;\n\tgoto L_00F8;\n\tgoto L_00F8;\n\tgoto L_00F8;\nL_00F8:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0113;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = &stack[20];\n\tX1 = 0;\n\tX0 = 0x15F7664(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0114;\nL_0112:\n\treturn;\nL_0113:\n\tv474 = Morpeh.Filter::With(v439, 0);\nL_0114:\n\t;\nL_0117:\n\tthrow System.TypeLoadException;\n// 160 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Dispose()
		{
			Filter all = Filter.All;
			Filter filter = all.With<HandComponent>();
			World world = default(World);
			object obj = world;
			Filter.EntityEnumerator enumerator = filter.GetEnumerator();
			world = (World)obj;
			IDisposable disposable = default(IDisposable);
			while (true)
			{
				Filter filter2 = ((Filter)(object)world).With<HandComponent>(false);
				if ((int)((long)(IntPtr)filter2 & 1L) == 0)
				{
					Filter filter3 = ((Filter)(object)world).With<HandComponent>(false);
				}
				else
				{
					disposable.Dispose();
					if (World != null)
					{
						World.RemoveEntity((IEntity)disposable);
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if (0 != 1)
					{
						Filter filter4 = ((Filter)(object)ex).With<HandComponent>(false);
						break;
					}
					Filter filter5 = ((Filter)(object)ex).With<HandComponent>(false);
					Filter filter6 = filter5.With<HandComponent>(fillWithPreviousEntities: false);
					Filter filter7 = ((Filter)(object)world).With<HandComponent>(false);
					if (filter5 != null)
					{
						break;
					}
				}
				Filter all2 = Filter.All;
				Filter filter8 = all2.With<AttackComponent>();
				world = filter8.GetEnumerator().world;
				while (true)
				{
					Filter filter9 = ((Filter)(object)world).With<AttackComponent>(false);
					if ((int)((long)(IntPtr)filter9 & 1L) == 0)
					{
						break;
					}
					disposable.Dispose();
					World.RemoveEntity((IEntity)disposable);
				}
				Filter filter10 = ((Filter)(object)world).With<AttackComponent>(false);
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xCC6874", Offset = "0xCC6874", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InitializeWeaponsSystem()
		{
		}
	}
}
