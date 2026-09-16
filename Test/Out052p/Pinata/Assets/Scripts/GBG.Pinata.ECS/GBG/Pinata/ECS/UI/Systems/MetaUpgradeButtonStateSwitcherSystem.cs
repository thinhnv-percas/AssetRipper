using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.UI.Components;
using GBG.Pinata.ECS.UI.Markers;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.UI.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200003D")]
	public class MetaUpgradeButtonStateSwitcherSystem : UpdateSystem
	{
		[SerializeField]
		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x28")]
		private GlobalVariableInt metaLevel;

		[SerializeField]
		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x30")]
		private GlobalVariableInt coins;

		[SerializeField]
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x38")]
		private string metaUpgradeType;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x40")]
		private Filter activeEntities;

		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x48")]
		private Filter noMoneyEntities;

		[Token(Token = "0x600006C")]
		[Address(RVA = "0xCC7B0C", Offset = "0xCC7B0C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EABAB0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023776]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tv69 = Morpeh.Filter::With(v52, 1);\n\tthis.activeEntities = v69;\n\tv53 = Morpeh.FilterProvider::get_All(this.filter);\n\tv54 = Morpeh.Filter::With(v53, 1);\n\tv98 = Morpeh.Filter::With(v54, 1);\n\tthis.noMoneyEntities = v98;\n\tGBG.Pinata.ECS.UI.Systems.MetaUpgradeButtonStateSwitcherSystem::CheckCoinsEnough(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<MetaUpgradeButtonComponent>();
			Filter filter2 = filter.With<ActiveStateUIMarker>();
			activeEntities = filter2;
			Filter all2 = Filter.All;
			Filter filter3 = all2.With<MetaUpgradeButtonComponent>();
			Filter filter4 = filter3.With<NoMoneyStateUIMarker>();
			noMoneyEntities = filter4;
			CheckCoinsEnough();
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0xCC7CE0", Offset = "0xCC7CE0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFC8F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, deltaTime, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023777]) = v38;\nL_0017:\n\tv43 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.coins);\n\tv45 = v43 == 0;\n\tif (v45) goto L_0028;\n\tGBG.Pinata.ECS.UI.Systems.MetaUpgradeButtonStateSwitcherSystem::CheckCoinsEnough(this);\n\treturn;\nL_0028:\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			if ((bool)coins)
			{
				CheckCoinsEnough();
			}
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0xCC7BE0", Offset = "0xCC7BE0", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA7308]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023778]) = v42;\nL_0015:\n\tv43 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tv87 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.MetaUpgradeConfig>::get_Item(v43.MetaUpgradeConfigs, v40.metaUpgradeType);\n\tv78 = v87.Data;\n\tv117 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v40.metaLevel);\n\tv167 = v78._size < v117;\n\tv76 = ~v167;\n\tv73 = v78._size - v117;\n\tv67 = v73 == 0;\n\tv168 = ~v67;\n\tv52 = v76 & v168;\n\tif (v52) goto L_003D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003D:\n\tv170 = v78._items;\n\tv96 = v170[v117 @ X0_v11 (System.Int32)];\n\tv174 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v40.coins);\n\tv144 = v174 - v96.NextUpgradeCost;\n\tv142 = v144 < 0;\n\tv138 = v174 ^ v96.NextUpgradeCost;\n\tv136 = v174 ^ v144;\n\tv134 = v138 & v136;\n\tv132 = v134 < 0;\n\tv177 = v142 == v132;\n\tv180 = v142 == v132;\n\tv130 = ~v180;\n\tGBG.Pinata.ECS.UI.Systems.MetaUpgradeButtonStateSwitcherSystem::FindAndSetActive(v40, v40.activeEntities, v177);\n\tGBG.Pinata.ECS.UI.Systems.MetaUpgradeButtonStateSwitcherSystem::FindAndSetActive(v40, v40.noMoneyEntities, v130);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckCoinsEnough()
		{
			GameConfig instance = GameConfig.Instance;
			MetaUpgradeConfig metaUpgradeConfig = ((Dictionary<string, MetaUpgradeConfig>)instance.MetaUpgradeConfigs).get_Item(metaUpgradeType);
			List<MetaUpgradeData> data = metaUpgradeConfig.Data;
			int value = metaLevel.Value;
			bool flag = data.Count < value;
			bool flag2 = !flag;
			int num = data.Count - value;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			MetaUpgradeData[] items = data._items;
			MetaUpgradeData metaUpgradeData = items[value];
			int value2 = coins.Value;
			int num2 = value2 - metaUpgradeData.NextUpgradeCost;
			bool flag5 = num2 < 0;
			int num3 = value2 ^ metaUpgradeData.NextUpgradeCost;
			int num4 = value2 ^ num2;
			int num5 = num3 & num4;
			bool flag6 = num5 < 0;
			bool activeValue = flag5 == flag6;
			bool flag7 = flag5 == flag6;
			bool activeValue2 = !flag7;
			FindAndSetActive(activeEntities, activeValue);
			FindAndSetActive(noMoneyEntities, activeValue2);
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0xCC7D48", Offset = "0xCC7D48", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EEB8B8]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, entities, activeValue, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023779]) = v46;\nL_001B:\n\tv50 = entities == 0;\n\tif (v50) goto L_0085;\n\tv55 = Morpeh.Filter::GetEnumerator(entities);\n\tv132 = v55.world;\nL_0032:\n\tv198 = 0x15F75B8(&v132 @ stack_-80_v3 (Morpeh.World), 0, v176, methodInfo, v32, v33, v34, v35, v55.ids, v55.world, v38, v39, v40, v41, v42, v43);\n\tv209 = v198 & 1;\n\tv210 = v209 == 0;\n\tif (v210) goto L_007E;\n\tv195 = Il2CppMethodInfo;\n\tv232 = *([v214 @ stack_-58]);\n\tv236 = *([v232 @ X8_v9+126]) == 0;\n\tif (v236) goto L_005C;\n\tv387 = *([v232 @ X8_v9+B0]) + 8;\nL_0043:\n\t;\n\tv392 = *([v387 @ X11_v10-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v392) goto L_005E;\n\tv386 = v386 + 1;\n\tv398 = v386 < *([v232 @ X8_v9+126]);\n\tv262 = ~v398;\n\tv387 = v387 + 0x10;\n\tv246 = ~v262;\n\tif (v246) goto L_0043;\nL_005C:\n\tv405 = 0x8909C4(v214, Il2CppClass<Morpeh.IEntity>, *([v195 @ X22_v8 (Il2CppMethodInfo)+48]), methodInfo, v32, v33, v34, v35, v55.ids, v55.world, v38, v39, v40, v41, v42, v43);\n\tgoto L_0063;\nL_005E:\n\t;\n\tv400 = *([v387 @ X11_v10]) + *([v195 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv401 = v400 << 4;\n\tv402 = v232 + v401;\n\tv405 = v402 + 0x130;\nL_0063:\n\t;\n\tv409 = 0x8D8294(*([v405 @ X0_v27+8]), Il2CppMethodInfo, *([v195 @ X22_v8 (Il2CppMethodInfo)+48]), methodInfo, v32, v33, v34, v35, v55.ids, v55.world, v38, v39, v40, v41, v42, v43);\n\t*([v409 @ X0_v29])(v411, v214, v409, *([v195 @ X22_v8 (Il2CppMethodInfo)+48]), methodInfo, v32, v33, v34, v35, v55.ids, v55.world, v38, v39, v40, v41, v42, v43);\n\tv185 = System.String::Equals(this.metaUpgradeType, *([v411 @ X0_v31+18]));\n\tv188 = v185 == 0;\n\tif (v188) goto L_0032;\n\tUnityEngine.GameObject::SetActive(*([v411 @ X0_v31]), activeValue);\n\tgoto L_0032;\nL_007E:\n\tv218 = 0x15F7664(&v132 @ stack_-80_v3 (Morpeh.World), 0, v176, methodInfo, v32, v33, v34, v35, v55.ids, v55.world, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A8;\n\tv238 = new System.NullReferenceException();\n\tv293 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0085:\n\tv148 = new System.NullReferenceException();\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\nL_0095:\n\tv208 = v133 != 1;\n\tif (v208) goto L_00A9;\n\tv211 = 0x6D2BC0(v148, v133, v95, methodInfo, v32, v33, v34, v35, v120, v132, v38, v39, v40, v41, v42, v43);\n\tv220 = 0x6D2490(v211, v133, v95, methodInfo, v32, v33, v34, v35, v120, v132, v38, v39, v40, v41, v42, v43);\n\tv224 = 0x15F7664(&v102 @ stack_-60_v3 (Morpeh.World), 0, v95, methodInfo, v32, v33, v34, v35, v120, v132, v38, v39, v40, v41, v42, v43);\n\tv337 = *([v211 @ X0_v10]) == 0;\n\tv226 = ~v337;\n\tif (v226) goto L_00AD;\nL_00A8:\n\treturn;\nL_00A9:\n\tv212 = 0x6D2380(v148, v133, v95, methodInfo, v32, v33, v34, v35, v120, v132, v38, v39, v40, v41, v42, v43);\nL_00AD:\n\tthrow System.TypeLoadException;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FindAndSetActive(Filter entities, bool activeValue)
		{
			//IL_0078: Expected O, but got I
			//IL_014b: Expected O, but got I
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_011f: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_00c4: Expected O, but got I
			bool flag = entities == null;
			World world2 = default(World);
			World world = world2;
			if (!flag)
			{
				world2 = entities.GetEnumerator().world;
				bool flag2 = activeValue;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X8_v9+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00dd;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X8_v9+B0]");
					object obj4 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X11_v10-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X8_v9+126]");
						bool flag3 = (long)num2 < 0L;
						bool flag4 = !flag3;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_00dd;
					}
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X22_v8 (Il2CppMethodInfo)+48]");
					object obj6 = obj5 + 0;
					int num3 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)(IntPtr)obj2 + (long)num3;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_027c;
					IL_00dd:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_027c;
					IL_027c:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v409 @ X0_v29] (should have been resolved before IL gen)");
					string text = metaUpgradeType;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X0_v31+18]");
					bool flag5 = text.Equals((string)0);
					bool flag6 = !flag5;
					flag2 = false;
					if (!flag6)
					{
						((GameObject)obj9).SetActive(activeValue);
						flag2 = false;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			Filter filter = default(Filter);
			if ((IntPtr)filter == (IntPtr)1)
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

		[Token(Token = "0x6000070")]
		[Address(RVA = "0xCC7F18", Offset = "0xCC7F18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MetaUpgradeButtonStateSwitcherSystem()
		{
		}
	}
}
