using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[Token(Token = "0x2000029")]
public class UITabSystem : UpdateSystem
{
	[Token(Token = "0x400008E")]
	[FieldOffset(Offset = "0x28")]
	public Filter filter;

	[Token(Token = "0x400008F")]
	[FieldOffset(Offset = "0x30")]
	public Filter filterWeaponButton;

	[Token(Token = "0x4000090")]
	[FieldOffset(Offset = "0x38")]
	public GameConfig config;

	[Token(Token = "0x600004C")]
	[Address(RVA = "0xCCBDCC", Offset = "0xCCBDCC", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDA060]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202379C]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv54 = Morpeh.Filter::With(v42, 1);\n\tv74 = Morpeh.Filter::Without(v54, 1);\n\tthis.filter = v74;\n\tv55 = Morpeh.FilterProvider::get_All(this.filter);\n\tv56 = Morpeh.Filter::With(v55, 1);\n\tv57 = Morpeh.Filter::With(v56, 1);\n\tv104 = Morpeh.Filter::With(v57, 1);\n\tthis.filterWeaponButton = v104;\n\tv89 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v89;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<TabComponent>();
		Filter filter2 = filter.Without<WeaponButtonComponent>();
		this.filter = filter2;
		Filter all2 = Filter.All;
		Filter filter3 = all2.With<TabComponent>();
		Filter filter4 = filter3.With<ActivateGameObjectComponent>();
		Filter filter5 = filter4.With<WeaponButtonComponent>();
		filterWeaponButton = filter5;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x600004D")]
	[Address(RVA = "0xCCBEBC", Offset = "0xCCBEBC", Length = "0x2CC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EC1040]);\n\tv33 = *([v32 @ X8_v39]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202379D]) = v52;\nL_0020:\n\tv58 = Morpeh.Filter::Select(this.filter);\n\tv110 = this.filter;\n\tv122 = v110.Length < 1;\n\tif (v122) goto L_0054;\n\tv65 = *([v58 @ X0_v5 (ComponentsBag`1<TabComponent>&)+8]) + 0x20;\nL_0038:\n\tv62 = *([v65 @ X23_v7+v67 @ X21_v11 (System.Int32)*4]) << 5;\n\tv106 = *([v58 @ X0_v5 (ComponentsBag`1<TabComponent>&)]) + v62;\n\tv400 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v106 @ X8_v34+20]));\n\tv372 = v400 == 0;\n\tif (v372) goto L_0047;\n\tv416 = *([v65 @ X23_v7+v67 @ X21_v11 (System.Int32)*4]) << 5;\n\tv417 = *([v58 @ X0_v5 (ComponentsBag`1<TabComponent>&)]) + v416;\n\tUITabSystem::SetTabsColor(this, *([v417 @ X8_v36+38]));\nL_0047:\n\tv67 = v67 + 1;\n\tv360 = v67 < v110.Length;\n\tif (v360) goto L_0038;\nL_0054:\n\tv409 = this.filterWeaponButton;\n\tv382 = v409.Length < 1;\n\tif (v382) goto L_012A;\nL_006B:\n\tv411 = v409.world;\n\tv167 = v411.Entities;\n\tv282 = v167[v412[v196 @ X22_v7 (System.Int32)]];\n\tv188 = Il2CppMethodInfo;\n\tv422 = *([v282 @ X20_v8 (Morpeh.Entity)]);\n\tv425 = *([v422 @ X8_v16 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v425) goto L_0099;\n\tv457 = *([v422 @ X8_v16 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0085:\n\tv471 = *([v457 @ X11_v14-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v471) goto L_009C;\n\tv456 = v456 + 1;\n\tv476 = v456 < *([v422 @ X8_v16 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv452 = ~v476;\n\tv457 = v457 + 0x10;\n\tv436 = ~v452;\n\tif (v436) goto L_0085;\nL_0099:\n\tv483 = 0x8909C4(v167[v412[v196 @ X22_v7 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v188 @ X21_v7 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00A2;\nL_009C:\n\tv478 = *([v457 @ X11_v14]) + *([v188 @ X21_v7 (Il2CppMethodInfo)+48]);\n\tv479 = v478 << 4;\n\tv480 = v422 + v479;\n\tv483 = v480 + 0x130;\nL_00A2:\n\tv487 = Morpeh.IEntity::GetComponent(*([v483 @ X0_v12+8]));\n\t*([v487 @ X0_v14 (TabComponent&)])(v262, v167[v412[v196 @ X22_v7 (System.Int32)]], v487, *([v188 @ X21_v7 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv276 = this.filterWeaponButton;\n\tv490 = v276.world;\n\tv169 = v490.Entities;\n\tv189 = v169[v491[v196 @ X22_v7 (System.Int32)]];\n\tv197 = Il2CppMethodInfo;\n\tv495 = *([v189 @ X21_v8 (Morpeh.Entity)]);\n\tv498 = *([v495 @ X8_v24 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v498) goto L_00DB;\n\tv530 = *([v495 @ X8_v24 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00C7:\n\tv544 = *([v530 @ X11_v9-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v544) goto L_00DE;\n\tv529 = v529 + 1;\n\tv549 = v529 < *([v495 @ X8_v24 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv525 = ~v549;\n\tv530 = v530 + 0x10;\n\tv509 = ~v525;\n\tif (v509) goto L_00C7;\nL_00DB:\n\tv556 = 0x8909C4(v169[v491[v196 @ X22_v7 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v197 @ X22_v8 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00E4;\nL_00DE:\n\tv551 = *([v530 @ X11_v9]) + *([v197 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv552 = v551 << 4;\n\tv553 = v495 + v552;\n\tv556 = v553 + 0x130;\nL_00E4:\n\tv560 = Morpeh.IEntity::GetComponent(*([v556 @ X0_v17+8]));\n\t*([v560 @ X0_v19 (WeaponButtonComponent&)])(v263, v169[v491[v196 @ X22_v7 (System.Int32)]], v560, *([v197 @ X22_v8 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv278 = this.config;\n\tv259 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v278.Weapon);\n\tv574 = *([v263 @ X0_v21+78]) != v259;\n\tif (v574) goto L_0109;\n\tdeltaTime = *([v262 @ X0_v16]);\n\tUITabSystem::SetTabsColor(v259, &deltaTime @ V0 (System.Single));\n\tgoto L_010C;\nL_0109:\n\tdeltaTime = *([v262 @ X0_v16]);\n\tUITabSystem::ResetTabsColor(v259, &deltaTime @ V0 (System.Single));\nL_010C:\n\tv196 = v196 + 1;\n\tv199 = v196 >= v409.Length;\n\tif (v199) goto L_012A;\n\tv409 = this.filterWeaponButton;\n\tv586 = this.filterWeaponButton == 0;\n\tv265 = ~v586;\n\tif (v265) goto L_006B;\n\tthrow System.NullReferenceException;\nL_012A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 207 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void OnUpdate(float deltaTime)
	{
		//IL_005b: Expected O, but got I
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_007a: Expected O, but got I
		//IL_0156: Expected I, but got O
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_04c1: Expected O, but got I
		//IL_0191: Expected O, but got I
		//IL_0292: Expected I, but got O
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_0237: Expected O, but got I
		//IL_0246: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_0511: Expected O, but got I
		//IL_02cd: Expected O, but got I
		//IL_03e2: Expected F4, but got O
		//IL_03ef: Expected O, but got Ref
		//IL_03ef: Expected O, but got I4
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0373: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_03c8: Expected F4, but got O
		//IL_03d5: Expected O, but got Ref
		//IL_03d5: Expected O, but got I4
		//IL_0319: Expected O, but got I
		ref Filter.ComponentsBag<TabComponent> reference = ref this.filter.Select<TabComponent>();
		Filter filter = this.filter;
		if (filter.Length >= 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v5 (ComponentsBag`1<TabComponent>&)+8]");
			object obj = 0L + 32L;
			int num = 0;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X23_v7+v67 @ X21_v11 (System.Int32)*4]");
				int num2 = 0;
				object obj2 = reference + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X8_v34+20]");
				if (((BaseGlobalEvent<int>)0).IsPublished)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X23_v7+v67 @ X21_v11 (System.Int32)*4]");
					int num3 = 0;
					object obj3 = reference + num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X8_v36+38]");
					SetTabsColor(0);
				}
				num++;
			}
			while (num < filter.Length);
		}
		Filter filter2 = filterWeaponButton;
		if (filter2.Length < 1)
		{
			return;
		}
		int num4 = 0;
		int[] array = default(int[]);
		int[] array2 = default(int[]);
		object obj14 = default(object);
		while (true)
		{
			World world = filter2.world;
			Entity[] entities = world.Entities;
			Entity entity = entities[array[num4]];
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)entity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ X8_v16 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01f6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ X8_v16 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj4 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ X11_v14-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ X8_v16 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag = (long)num6 < 0L;
				bool flag2 = !flag;
				obj4 = (long)(IntPtr)obj4 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_01f6;
			}
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ X21_v7 (Il2CppMethodInfo)+48]");
			object obj6 = obj5 + 0;
			int num7 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num7;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_04b0;
			IL_04b0:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ X0_v12+8]");
			ref TabComponent component = ref ((IEntity)0).GetComponent<TabComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v487 @ X0_v14 (TabComponent&)] (should have been resolved before IL gen)");
			Filter filter3 = filterWeaponButton;
			World world2 = filter3.world;
			Entity[] entities2 = world2.Entities;
			Entity entity2 = entities2[array2[num4]];
			IntPtr intPtr3 = (IntPtr)0;
			IntPtr intPtr4 = (IntPtr)entity2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ X8_v24 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0332;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ X8_v24 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj9 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X11_v9-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ X8_v24 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag3 = (long)num9 < 0L;
				bool flag4 = !flag3;
				obj9 = (long)(IntPtr)obj9 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0332;
			}
			object obj10 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X22_v8 (Il2CppMethodInfo)+48]");
			object obj11 = obj10 + 0;
			int num10 = (int)((long)(IntPtr)obj11 << 4);
			object obj12 = (long)intPtr4 + (long)num10;
			object obj13 = (long)(IntPtr)obj12 + 304L;
			goto IL_0500;
			IL_0500:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ X0_v17+8]");
			ref WeaponButtonComponent component2 = ref ((IEntity)0).GetComponent<WeaponButtonComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v560 @ X0_v19 (WeaponButtonComponent&)] (should have been resolved before IL gen)");
			GameConfig gameConfig = config;
			int value = ((BaseGlobalVariable<int>)gameConfig.Weapon).Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X0_v21+78]");
			float num11;
			if ((IntPtr)0 == (IntPtr)value)
			{
				num11 = (float)obj14;
				((UITabSystem)value).SetTabsColor((TabComponent)(&num11));
			}
			else
			{
				num11 = (float)obj14;
				((UITabSystem)value).ResetTabsColor((TabComponent)(&num11));
			}
			num4++;
			if (num4 < filter2.Length)
			{
				filter2 = filterWeaponButton;
				if (filterWeaponButton == null)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			break;
			IL_0332:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0500;
			IL_01f6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_04b0;
		}
	}

	[Token(Token = "0x600004E")]
	[Address(RVA = "0xCCC188", Offset = "0xCCC188", Length = "0x198")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EE6A68]);\n\tv33 = *([v32 @ X8_v19]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, id, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202379E]) = v51;\nL_001A:\n\tv262 = this.filter;\n\tv65 = v262.Length < 1;\n\tif (v65) goto L_00AB;\nL_002F:\n\tv264 = v262.world;\n\tv106 = v264.Entities;\n\tv169 = v106[v265[v116 @ X24_v6 (System.Int32)]];\n\tv112 = Il2CppMethodInfo;\n\tv269 = *([v169 @ X21_v7 (Morpeh.Entity)]);\n\tv272 = *([v269 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v272) goto L_005D;\n\tv304 = *([v269 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0049:\n\tv318 = *([v304 @ X11_v9-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v318) goto L_0060;\n\tv303 = v303 + 1;\n\tv323 = v303 < *([v269 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv299 = ~v323;\n\tv304 = v304 + 0x10;\n\tv283 = ~v299;\n\tif (v283) goto L_0049;\nL_005D:\n\tv339 = 0x8909C4(v106[v265[v116 @ X24_v6 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v112 @ X22_v6 (Il2CppMethodInfo)+48]), v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0066;\nL_0060:\n\tv325 = *([v304 @ X11_v9]) + *([v112 @ X22_v6 (Il2CppMethodInfo)+48]);\n\tv326 = v325 << 4;\n\tv327 = v269 + v326;\n\tv339 = v327 + 0x130;\nL_0066:\n\tv343 = Morpeh.IEntity::GetComponent(*([v339 @ X0_v8+8]));\n\t*([v343 @ X0_v10 (TabComponent&)])(v346, v106[v265[v116 @ X24_v6 (System.Int32)]], v343, *([v112 @ X22_v6 (Il2CppMethodInfo)+48]), v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv247 = *([v346 @ X0_v12+18]) != id;\n\tif (v247) goto L_008E;\n\tv356 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v346 @ X0_v12]));\n\tv357 = v356 == 0;\n\tif (v357) goto L_008B;\n\tv41 = *([v346 @ X0_v12]);\n\tUITabSystem::SetTabsColor(v356, &v41 @ V0);\n\tgoto L_008E;\nL_008B:\n\tv41 = *([v346 @ X0_v12]);\n\tUITabSystem::ResetTabsColor(v356, &v41 @ V0);\nL_008E:\n\tv116 = v116 + 1;\n\tv122 = v116 >= v262.Length;\n\tif (v122) goto L_00AB;\n\tv262 = this.filter;\n\tv360 = this.filter == 0;\n\tv162 = ~v360;\n\tif (v162) goto L_002F;\n\tthrow System.NullReferenceException;\nL_00AB:\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void SetTabsColor(int id)
	{
		//IL_0043: Expected I, but got O
		//IL_023f: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0124: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_0191: Expected O, but got Ref
		//IL_0191: Expected O, but got I4
		//IL_00ca: Expected O, but got I
		//IL_0177: Expected O, but got Ref
		//IL_0177: Expected O, but got I4
		Filter filter = this.filter;
		if (filter.Length < 1)
		{
			return;
		}
		int num = 0;
		int[] array = default(int[]);
		object obj6 = default(object);
		do
		{
			World world = filter.world;
			Entity[] entities = world.Entities;
			Entity entity = entities[array[num]];
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)entity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ X11_v9-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e3;
			}
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X22_v6 (Il2CppMethodInfo)+48]");
			object obj3 = obj2 + 0;
			int num4 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr2 + (long)num4;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_022e;
			IL_022e:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X0_v8+8]");
			ref TabComponent component = ref ((IEntity)0).GetComponent<TabComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v343 @ X0_v10 (TabComponent&)] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ X0_v12+18]");
			if ((IntPtr)0 == (IntPtr)id)
			{
				bool isPublished = ((BaseGlobalEvent<int>)obj6).IsPublished;
				object obj7;
				if (isPublished)
				{
					obj7 = obj6;
					((UITabSystem)isPublished).SetTabsColor((TabComponent)(&obj7));
				}
				else
				{
					obj7 = obj6;
					((UITabSystem)isPublished).ResetTabsColor((TabComponent)(&obj7));
				}
			}
			num++;
			if (num < filter.Length)
			{
				filter = this.filter;
				continue;
			}
			return;
			IL_00e3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_022e;
		}
		while (this.filter != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x600004F")]
	[Address(RVA = "0xCCC320", Offset = "0xCCC320", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0x6D26F0(&v13 @ stack_-68, 0, 0x48, v17, v18, v19, v20, v21, v50, v23, v24, v25, v26, v27, v28, v29);\n\tv30 = component.Button;\n\tv33 = ~component.SpriteSwap;\n\tif (v33) goto L_001A;\n\tv37 = UnityEngine.UI.Selectable::get_image(component.Button);\n\tUnityEngine.UI.Image::set_sprite(v37, v30.m_SpriteState.m_SelectedSprite);\n\tgoto L_0035;\nL_001A:\n\tv38 = component.Button + 0x54;\n\tv41 = 0x6D2410(&v13 @ stack_-68, v38, 0x48, v17, v18, v19, v20, v21, v50, v23, v24, v25, v26, v27, v28, v29);\n\tv50 = UnityEngine.Color::get_white();\n\tv58 = &v57 @ stack_-C0 + 0x10;\n\tv65 = 0x6D2410(v58, &v13 @ stack_-68, 0x48, v17, v18, v19, v20, v21, v50, v50.g, v50.b, v50.a, v26, v27, v28, v29);\n\tUnityEngine.UI.Selectable::set_colors(component.Button, &v50 @ V0_v2 (UnityEngine.Color));\nL_0035:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void SetTabsColor(TabComponent component)
	{
		//IL_0081: Expected O, but got I
		//IL_00a8: Expected O, but got I
		//IL_00c4: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
		Selectable button = component.Button;
		if (component.SpriteSwap)
		{
			Image image = component.Button.image;
			image.sprite = button.m_SpriteState.selectedSprite;
			return;
		}
		object obj = (long)(IntPtr)component.Button + 84L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
		Color white = Color.white;
		object obj3 = default(object);
		object obj2 = (long)(IntPtr)obj3 + 16L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
		component.Button.colors = (ColorBlock)(&white);
	}

	[Token(Token = "0x6000050")]
	[Address(RVA = "0xCCC3D0", Offset = "0xCCC3D0", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-10_v2;\n\tv20 = &v17 @ stack_-10_v2 - 0x78;\n\tv23 = 0x6D26F0(v20, 0, 0x48, v24, v25, v26, v27, v28, v67, v30, v31, v32, v33, v34, v35, v36);\n\tv38 = component.Button;\n\tv39 = ~component.SpriteSwap;\n\tif (v39) goto L_0020;\n\tv44 = UnityEngine.UI.Selectable::get_image(component.Button);\n\tUnityEngine.UI.Image::set_sprite(v44, v38.m_SpriteState.m_DisabledSprite);\n\tgoto L_0050;\nL_0020:\n\tv47 = component.Button + 0x54;\n\tv48 = &v17 @ stack_-10_v2 - 0x78;\n\tv50 = 0x6D2410(v48, v47, 0x48, v24, v25, v26, v27, v28, v67, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = &v17 @ stack_-10_v2 - 0x80;\n\t*([v16 @ X29_v1-80]) = 0;\n\tv62 = 0x1010E50(v56, 0xC3, 0xC3, 0xC3, 0xFF, 0, v27, v28, v67, v30, v31, v32, v33, v34, v35, v36);\n\tv67 = UnityEngine.Color32::op_Implicit(*([v16 @ X29_v1-80]));\n\tv125 = &v17 @ stack_-10_v2 - 0x78;\n\tv131 = 0x6D2410(&v124 @ stack_-D8, v125, 0x48, 0xC3, 0xFF, 0, v27, v28, v67, v67.g, v67.b, v67.a, v33, v34, v35, v36);\n\tv144 = &v83 @ stack_-130 + 0x10;\n\tv147 = 0x6D2410(v144, &v124 @ stack_-D8, 0x48, 0xC3, 0xFF, 0, v27, v28, v67, v67.g, v67.b, v67.a, v33, v34, v35, v36);\n\tUnityEngine.UI.Selectable::set_colors(component.Button, &v67 @ V0_v2 (UnityEngine.Color));\nL_0050:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void ResetTabsColor(TabComponent component)
	{
		//IL_0017: Expected O, but got I
		//IL_0093: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_00bb: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_012e: Expected O, but got Ref
		object obj2 = default(object);
		object obj = obj2;
		object obj3 = (long)(IntPtr)obj2 - 120L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
		Selectable button = component.Button;
		if (component.SpriteSwap)
		{
			Image image = component.Button.image;
			image.sprite = button.m_SpriteState.disabledSprite;
			return;
		}
		object obj4 = (long)(IntPtr)component.Button + 84L;
		object obj5 = (long)(IntPtr)obj2 - 120L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
		object obj6 = (long)(IntPtr)obj2 - 128L;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-80]");
		Color color = (Color32)0;
		object obj7 = (long)(IntPtr)obj2 - 120L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
		object obj9 = default(object);
		object obj8 = (long)(IntPtr)obj9 + 16L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
		component.Button.colors = (ColorBlock)(&color);
	}

	[Token(Token = "0x6000051")]
	[Address(RVA = "0xCCC4D8", Offset = "0xCCC4D8", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UITabSystem()
	{
	}
}
