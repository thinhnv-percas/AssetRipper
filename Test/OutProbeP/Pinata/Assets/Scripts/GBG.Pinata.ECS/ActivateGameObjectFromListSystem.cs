using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using Morpeh;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x2000025")]
public class ActivateGameObjectFromListSystem : UpdateSystem
{
	[Token(Token = "0x400007F")]
	[FieldOffset(Offset = "0x28")]
	private Filter filter;

	[Token(Token = "0x4000080")]
	[FieldOffset(Offset = "0x30")]
	private GameConfig config;

	[Token(Token = "0x600003D")]
	[Address(RVA = "0xCBE08C", Offset = "0xCBE08C", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEBD40]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023707]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv48 = Morpeh.Filter::With(v42, 1);\n\tv74 = Morpeh.Filter::With(v48, 1);\n\tthis.filter = v74;\n\tv63 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v63;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<ActivateGameObjectFromListComponent>();
		Filter filter2 = filter.With<WeaponButtonComponent>();
		this.filter = filter2;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0xCBE204", Offset = "0xCBE204", Length = "0x2E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1F03890]);\n\tv33 = *([v32 @ X8_v38]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2023708]) = v52;\nL_001A:\n\tv333 = this.filter;\n\tv66 = v333.Length < 1;\n\tif (v66) goto L_0137;\nL_0031:\n\tv335 = v333.world;\n\tv101 = v335.Entities;\n\tv222 = v101[v336[v121 @ X22_v6 (System.Int32)]];\n\tv117 = Il2CppMethodInfo;\n\tv340 = *([v222 @ X20_v7 (Morpeh.Entity)]);\n\tv343 = *([v340 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v343) goto L_005F;\n\tv375 = *([v340 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_004B:\n\tv389 = *([v375 @ X11_v15-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v389) goto L_0062;\n\tv374 = v374 + 1;\n\tv394 = v374 < *([v340 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv370 = ~v394;\n\tv375 = v375 + 0x10;\n\tv354 = ~v370;\n\tif (v354) goto L_004B;\nL_005F:\n\tv401 = 0x8909C4(v101[v336[v121 @ X22_v6 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v117 @ X21_v6 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0068;\nL_0062:\n\tv396 = *([v375 @ X11_v15]) + *([v117 @ X21_v6 (Il2CppMethodInfo)+48]);\n\tv397 = v396 << 4;\n\tv398 = v340 + v397;\n\tv401 = v398 + 0x130;\nL_0068:\n\tv405 = Morpeh.IEntity::GetComponent(*([v401 @ X0_v8+8]));\n\t*([v405 @ X0_v10 (WeaponButtonComponent&)])(v198, v101[v336[v121 @ X22_v6 (System.Int32)]], v405, *([v117 @ X21_v6 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv215 = this.filter;\n\tv408 = v215.world;\n\tv103 = v408.Entities;\n\tv118 = v103[v409[v121 @ X22_v6 (System.Int32)]];\n\tv122 = Il2CppMethodInfo;\n\tv413 = *([v118 @ X21_v7 (Morpeh.Entity)]);\n\tv416 = *([v413 @ X8_v20 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v416) goto L_00A1;\n\tv448 = *([v413 @ X8_v20 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_008D:\n\tv462 = *([v448 @ X11_v10-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v462) goto L_00A4;\n\tv447 = v447 + 1;\n\tv467 = v447 < *([v413 @ X8_v20 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv443 = ~v467;\n\tv448 = v448 + 0x10;\n\tv427 = ~v443;\n\tif (v427) goto L_008D;\nL_00A1:\n\tv474 = 0x8909C4(v103[v409[v121 @ X22_v6 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v122 @ X22_v7 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00AA;\nL_00A4:\n\tv469 = *([v448 @ X11_v10]) + *([v122 @ X22_v7 (Il2CppMethodInfo)+48]);\n\tv470 = v469 << 4;\n\tv471 = v413 + v470;\n\tv474 = v471 + 0x130;\nL_00AA:\n\tv478 = Morpeh.IEntity::GetComponent(*([v474 @ X0_v13+8]));\n\t*([v478 @ X0_v15 (ActivateGameObjectFromListComponent&)])(v199, v103[v409[v121 @ X22_v6 (System.Int32)]], v478, *([v122 @ X22_v7 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv217 = this.config;\n\tv320 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v217.Weapon.Data);\n\tv482 = *([v320 @ X0_v19 (GBG.Pinata.ECS.WeaponSetup)+18]) < *([v198 @ X0_v12+78]);\n\tv192 = ~v482;\n\tv185 = *([v320 @ X0_v19 (GBG.Pinata.ECS.WeaponSetup)+18]) - *([v198 @ X0_v12+78]);\n\tv171 = v185 == 0;\n\tv483 = ~v171;\n\tv136 = v192 & v483;\n\tif (v136) goto L_00CD;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00CD:\n\tv76 = *([v198 @ X0_v12+78]) << 3;\n\tv486 = *([v320 @ X0_v19 (GBG.Pinata.ECS.WeaponSetup)+10]) + v76;\n\tv218 = *([v486 @ X8_v26+20]);\n\tv225 = *([v199 @ X0_v17]);\n\tv487 = *([v225 @ X20_v10+18]) == 0;\n\tv488 = ~v487;\n\tif (v488) goto L_00DC;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00DC:\n\tv219 = *([v225 @ X20_v10+10]);\n\tv491 = *([v218 @ X8_v27+28]) == 0;\n\tif (v491) goto L_00FF;\n\tUnityEngine.GameObject::SetActive(*([v219 @ X8_v28+20]), 0);\n\tv226 = *([v199 @ X0_v17]);\n\tv493 = *([v226 @ X20_v13+18]) < 1;\n\tv316 = ~v493;\n\tv314 = *([v226 @ X20_v13+18]) - 1;\n\tv310 = v314 == 0;\n\tv494 = ~v310;\n\tv300 = v316 & v494;\n\tif (v300) goto L_00F7;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00F7:\n\tv328 = *([v226 @ X20_v13+10]);\n\tv196 = *([v328 @ X8_v34+28]);\n\tgoto L_0118;\nL_00FF:\n\tUnityEngine.GameObject::SetActive(*([v219 @ X8_v28+20]), 1);\n\tv227 = *([v199 @ X0_v17]);\n\tv496 = *([v227 @ X20_v12+18]) < 1;\n\tv317 = ~v496;\n\tv315 = *([v227 @ X20_v12+18]) - 1;\n\tv311 = v315 == 0;\n\tv497 = ~v311;\n\tv301 = v317 & v497;\n\tif (v301) goto L_0112;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0112:\n\tv329 = *([v227 @ X20_v12+10]);\n\tv196 = *([v329 @ X8_v32+28]);\nL_0118:\n\tUnityEngine.GameObject::SetActive(v196, v107);\n\tv121 = v121 + 1;\n\tv132 = v121 >= v333.Length;\n\tif (v132) goto L_0137;\n\tv333 = this.filter;\n\tv515 = this.filter == 0;\n\tv203 = ~v515;\n\tif (v203) goto L_0031;\n\tthrow System.NullReferenceException;\nL_0137:\n\treturn;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnUpdate(float deltaTime)
	{
		//IL_0043: Expected I, but got O
		//IL_05f5: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_0184: Expected I, but got O
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0129: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_0645: Expected O, but got I
		//IL_01bf: Expected O, but got I
		//IL_02e0: Expected O, but got I
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_026a: Expected O, but got I
		//IL_0279: Expected O, but got I
		//IL_034b: Expected O, but got I
		//IL_035b: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_03b8: Expected O, but got I
		//IL_04c6: Expected O, but got I
		//IL_050b: Expected O, but got I
		//IL_03f8: Expected O, but got I
		//IL_055b: Expected O, but got I
		//IL_056b: Expected O, but got I
		//IL_043d: Expected O, but got I
		//IL_048d: Expected O, but got I
		//IL_049d: Expected O, but got I
		Filter filter = this.filter;
		if (filter.Length < 1)
		{
			return;
		}
		int num = 0;
		int[] array = default(int[]);
		int[] array2 = default(int[]);
		object obj15 = default(object);
		do
		{
			World world = filter.world;
			Entity[] entities = world.Entities;
			Entity entity = entities[array[num]];
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)entity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ X11_v15-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X21_v6 (Il2CppMethodInfo)+48]");
			object obj3 = obj2 + 0;
			int num4 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr2 + (long)num4;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_05e4;
			IL_05e4:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ X0_v8+8]");
			ref WeaponButtonComponent component = ref ((IEntity)0).GetComponent<WeaponButtonComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v405 @ X0_v10 (WeaponButtonComponent&)] (should have been resolved before IL gen)");
			Filter filter2 = this.filter;
			World world2 = filter2.world;
			Entity[] entities2 = world2.Entities;
			Entity entity2 = entities2[array2[num]];
			IntPtr intPtr3 = (IntPtr)0;
			IntPtr intPtr4 = (IntPtr)entity2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X8_v20 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0224;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X8_v20 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj6 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ X11_v10-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X8_v20 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag3 = (long)num6 < 0L;
				bool flag4 = !flag3;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0224;
			}
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X22_v7 (Il2CppMethodInfo)+48]");
			object obj8 = obj7 + 0;
			int num7 = (int)((long)(IntPtr)obj8 << 4);
			object obj9 = (long)intPtr4 + (long)num7;
			object obj10 = (long)(IntPtr)obj9 + 304L;
			goto IL_0634;
			IL_0634:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X0_v13+8]");
			ref ActivateGameObjectFromListComponent component2 = ref ((IEntity)0).GetComponent<ActivateGameObjectFromListComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v478 @ X0_v15 (ActivateGameObjectFromListComponent&)] (should have been resolved before IL gen)");
			GameConfig gameConfig = config;
			WeaponSetup value = gameConfig.Weapon.Data.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X0_v19 (GBG.Pinata.ECS.WeaponSetup)+18]");
			IntPtr intPtr5 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X0_v12+78]");
			bool flag5 = (long)intPtr5 < 0L;
			bool flag6 = !flag5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X0_v19 (GBG.Pinata.ECS.WeaponSetup)+18]");
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X0_v12+78]");
			object obj11 = (long)intPtr6 - 0L;
			bool flag7 = obj11 == null;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X0_v12+78]");
			int num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X0_v19 (GBG.Pinata.ECS.WeaponSetup)+10]");
			object obj12 = 0L + (long)num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ X8_v26+20]");
			object obj13 = 0;
			object obj14 = obj15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X20_v10+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X20_v10+10]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X8_v27+28]");
			GameObject gameObject;
			bool active;
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v28+20]");
				((GameObject)0).SetActive(value: false);
				object obj17 = obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X20_v13+18]");
				bool flag9 = 0L < 1L;
				bool flag10 = !flag9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X20_v13+18]");
				object obj18 = -1;
				bool flag11 = obj18 == null;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X20_v13+10]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v34+28]");
				gameObject = (GameObject)0;
				active = true;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v28+20]");
				((GameObject)0).SetActive(value: true);
				object obj20 = obj15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X20_v12+18]");
				bool flag13 = 0L < 1L;
				bool flag14 = !flag13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X20_v12+18]");
				object obj21 = -1;
				bool flag15 = obj21 == null;
				bool flag16 = !flag15;
				if (!(flag14 && flag16))
				{
					throw new ArgumentOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X20_v12+10]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X8_v32+28]");
				gameObject = (GameObject)0;
				active = false;
			}
			gameObject.SetActive(active);
			num++;
			if (num < filter.Length)
			{
				filter = this.filter;
				continue;
			}
			return;
			IL_0224:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0634;
			IL_00e3:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_05e4;
		}
		while (this.filter != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0xCBE4E4", Offset = "0xCBE4E4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ActivateGameObjectFromListSystem()
	{
	}
}
