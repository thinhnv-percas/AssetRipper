using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using GBG.Pinata.ECS.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x200000E")]
public class SpawnWeaponsSystem : UpdateSystem
{
	[Token(Token = "0x400003E")]
	[FieldOffset(Offset = "0x28")]
	private Filter filterForInitialize;

	[Token(Token = "0x400003F")]
	[FieldOffset(Offset = "0x30")]
	private Filter filterInitialized;

	[Token(Token = "0x4000040")]
	[FieldOffset(Offset = "0x38")]
	private GameConfig config;

	[Token(Token = "0x600001D")]
	[Address(RVA = "0xCCA904", Offset = "0xCCA904", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFDAD0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023790]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tv69 = Morpeh.Filter::Without(v52, 1);\n\tthis.filterForInitialize = v69;\n\tv53 = Morpeh.FilterProvider::get_All(this.filter);\n\tv54 = Morpeh.Filter::With(v53, 1);\n\tv98 = Morpeh.Filter::With(v54, 1);\n\tthis.filterInitialized = v98;\n\tv84 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v84;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<HandComponent>();
		Filter filter2 = filter.Without<WeaponSpawnedMarker>();
		filterForInitialize = filter2;
		Filter all2 = Filter.All;
		Filter filter3 = all2.With<HandComponent>();
		Filter filter4 = filter3.With<WeaponSpawnedMarker>();
		filterInitialized = filter4;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x600001E")]
	[Address(RVA = "0xCCA9DC", Offset = "0xCCA9DC", Length = "0x470")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EAB400]);\n\tv31 = *([v30 @ X8_v49]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, deltaTime, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023791]) = v50;\nL_001F:\n\tv56 = &v174 @ stack_-90_v11 (Morpeh.World);\n\tv59 = Morpeh.Filter::GetEnumerator(this.filterForInitialize);\n\tv174 = *([v56 @ X8_v11]);\nL_0034:\n\tv292 = 0x15F75B8(&v174 @ stack_-90_v11 (Morpeh.World), 0, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tv334 = v292 & 1;\n\tv335 = v334 == 0;\n\tif (v335) goto L_00A3;\n\tv381 = v380 == 0;\n\tif (v381) goto L_00A6;\n\tv438 = Il2CppMethodInfo;\n\tv439 = *([v380 @ stack_-68]);\n\tv443 = *([v439 @ X8_v39+126]) == 0;\n\tif (v443) goto L_005E;\n\tv583 = *([v439 @ X8_v39+B0]) + 8;\nL_004A:\n\tv588 = *([v583 @ X11_v30-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v588) goto L_0061;\n\tv582 = v582 + 1;\n\tv639 = v582 < *([v439 @ X8_v39+126]);\n\tv512 = ~v639;\n\tv583 = v583 + 0x10;\n\tv496 = ~v512;\n\tif (v496) goto L_004A;\nL_005E:\n\tv659 = 0x8909C4(v380, Il2CppClass<Morpeh.IEntity>, *([v438 @ X21_v20 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tgoto L_0067;\nL_0061:\n\tv641 = *([v583 @ X11_v30]) + *([v438 @ X21_v20 (Il2CppMethodInfo)+48]);\n\tv642 = v641 << 4;\n\tv643 = v439 + v642;\n\tv659 = v643 + 0x130;\nL_0067:\n\tv663 = Morpeh.IEntity::GetComponent(*([v659 @ X0_v80+8]));\n\t*([v663 @ X0_v82 (GBG.Pinata.ECS.Components.HandComponent&)])(v672, v380, v663, *([v438 @ X21_v20 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tSpawnWeaponsSystem::<OnUpdate>g__Spawn|4_0(v672);\n\tv279 = Il2CppMethodInfo;\n\tv783 = *([v380 @ stack_-68]);\n\tv704 = *([v279 @ X21_v21 (Il2CppMethodInfo)+48]);\n\tv285 = *([v783 @ X8_v42+126]) == 0;\n\tif (v285) goto L_0091;\n\tv834 = *([v783 @ X8_v42+B0]) + 8;\nL_007D:\n\tv839 = *([v834 @ X11_v25-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v839) goto L_0094;\n\tv833 = v833 + 1;\n\tv852 = v833 < *([v783 @ X8_v42+126]);\n\tv812 = ~v852;\n\tv834 = v834 + 0x10;\n\tv796 = ~v812;\n\tif (v796) goto L_007D;\nL_0091:\n\tv859 = 0x8909C4(v380, Il2CppClass<Morpeh.IEntity>, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tgoto L_009A;\nL_0094:\n\tv854 = *([v834 @ X11_v25]) + v704;\n\tv855 = v854 << 4;\n\tv856 = v783 + v855;\n\tv859 = v856 + 0x130;\nL_009A:\n\tv863 = Morpeh.IEntity::AddComponent(*([v859 @ X0_v85+8]));\n\t*([v863 @ X0_v87 (WeaponSpawnedMarker&)])(v283, v380, v863, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tgoto L_0034;\nL_00A3:\n\tv384 = 0x15F7664(&v174 @ stack_-90_v11 (Morpeh.World), 0, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tgoto L_00BE;\nL_00A6:\n\tv445 = new System.NullReferenceException();\n\tgoto L_00B4;\n\tgoto L_00B4;\n\tgoto L_00B4;\nL_00B4:\n\tgoto L_01AE;\n\tv664 = 0x6D2BC0(v445, 0, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tv673 = 0x6D2490(v664, 0, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tv529 = 0x15F7664(&v174 @ stack_-90_v11 (Morpeh.World), 0, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\n\tv819 = *([v664 @ X0_v76]) == 0;\n\tv531 = ~v819;\n\tif (v531) goto L_017F;\nL_00BE:\n\tv486 = this.config;\n\tv596 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(v486.Weapon);\n\tv667 = v596 == 0;\n\tif (v667) goto L_01AD;\n\tv789 = Morpeh.Filter::GetEnumerator(this.filterInitialized);\n\tv174 = v789.world;\nL_00E3:\n\tv851 = 0x15F75B8(&v174 @ stack_-90_v11 (Morpeh.World), 0, v704, v35, v36, v37, v38, v39, v789.ids, v174, v42, v43, v44, v45, v46, v47);\n\tv864 = v851 & 1;\n\tv727 = v864 == 0;\n\tif (v727) goto L_016D;\n\tv869 = Il2CppMethodInfo;\n\tv870 = *([v380 @ stack_-68]);\n\tv874 = *([v870 @ X8_v21+126]) == 0;\n\tif (v874) goto L_010D;\n\tv945 = *([v870 @ X8_v21+B0]) + 8;\nL_00F9:\n\tv950 = *([v945 @ X11_v18-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v950) goto L_0110;\n\tv944 = v944 + 1;\n\tv958 = v944 < *([v870 @ X8_v21+126]);\n\tv899 = ~v958;\n\tv945 = v945 + 0x10;\n\tv883 = ~v899;\n\tif (v883) goto L_00F9;\nL_010D:\n\tv965 = 0x8909C4(v380, Il2CppClass<Morpeh.IEntity>, *([v869 @ X21_v15 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, v789.ids, v174, v42, v43, v44, v45, v46, v47);\n\tgoto L_0116;\nL_0110:\n\tv960 = *([v945 @ X11_v18]) + *([v869 @ X21_v15 (Il2CppMethodInfo)+48]);\n\tv961 = v960 << 4;\n\tv962 = v870 + v961;\n\tv965 = v962 + 0x130;\nL_0116:\n\tv969 = Morpeh.IEntity::GetComponent(*([v965 @ X0_v45+8]));\n\t*([v969 @ X0_v47 (GBG.Pinata.ECS.Components.HandComponent&)])(v973, v380, v969, *([v869 @ X21_v15 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, v789.ids, v174, v42, v43, v44, v45, v46, v47);\n\tgoto L_012B;\n\tv979 = *([v974 @ X0_v50+E0]);\n\tv980 = v979 == 0;\n\tv981 = ~v980;\n\tgoto L_012B;\n\tv983 = \"il2cpp_codegen_runtime_class_init\"(v974, v972, v873, v35, v36, v37, v38, v39, v140, v143, v42, v43, v44, v45, v46, v47);\nL_012B:\n\tv988 = UnityEngine.Object::op_Inequality(*([v973 @ X0_v49 (GBG.Pinata.ECS.Components.HandComponent&)+28]), 0);\n\tv990 = v988 == 0;\n\tif (v990) goto L_013D;\n\tgoto L_013C;\n\tv1002 = *([v991 @ X0_v62+E0]);\n\tv1003 = v1002 == 0;\n\tv1004 = ~v1003;\n\tif (v1004) goto L_013C;\n\tv1006 = \"il2cpp_codegen_runtime_class_init\"(v991, v987, v224, v35, v36, v37, v38, v39, v140, v143, v42, v43, v44, v45, v46, v47);\nL_013C:\n\tUnityEngine.Object::Destroy(*([v973 @ X0_v49 (GBG.Pinata.ECS.Components.HandComponent&)+28]));\nL_013D:\n\tv930 = this.config;\n\tv246 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v930.Weapon.Data);\n\tv250 = this.config;\n\tv373 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v250.Weapon);\n\tv1008 = *([v246 @ X0_v56 (GBG.Pinata.ECS.WeaponSetup)+18]) < v373;\n\tv408 = ~v1008;\n\tv406 = *([v246 @ X0_v56 (GBG.Pinata.ECS.WeaponSetup)+18]) - v373;\n\tv402 = v406 == 0;\n\tv1009 = ~v402;\n\tv392 = v408 & v1009;\n\tif (v392) goto L_0161;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0161:\n\tv390 = v373 << 3;\n\tv1012 = *([v246 @ X0_v56 (GBG.Pinata.ECS.WeaponSetup)+10]) + v390;\n\tv434 = *([v1012 @ X8_v31+20]);\n\t*([v973 @ X0_v49 (GBG.Pinata.ECS.Components.HandComponent&)+40]) = *([v434 @ X8_v32+20]);\n\tSpawnWeaponsSystem::<OnUpdate>g__Spawn|4_0(v973);\n\tgoto L_00E3;\nL_016D:\n\tv725 = 0x15F7664(&v174 @ stack_-90_v11 (Morpeh.World), 0, v704, v35, v36, v37, v38, v39, v789.ids, v174, v42, v43, v44, v45, v46, v47);\n\tgoto L_01AD;\n\tthrow System.NullReferenceException;\n\tv933 = new System.NullReferenceException();\n\tv180 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv254 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_017F:\n\tgoto L_01B2;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\nL_018E:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01AE;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = &stack[20];\n\tX1 = 0;\n\tX0 = 0x15F7664(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01AF;\nL_01AD:\n\treturn;\nL_01AE:\n\tv665 = 0x6D2380(v445, 0, v704, v35, v36, v37, v38, v39, *([v56 @ X8_v11+10]), v174, v42, v43, v44, v45, v46, v47);\nL_01AF:\n\t;\nL_01B2:\n\tthrow System.TypeLoadException;\n// 250 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnUpdate(float deltaTime)
	{
		//IL_05a4: Expected O, but got I
		//IL_05d9: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_0631: Expected O, but got I
		//IL_015f: Expected O, but got I
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0135: Expected O, but got I
		//IL_0144: Expected O, but got I
		//IL_00db: Expected O, but got I
		//IL_06ad: Expected O, but got I
		//IL_0327: Expected O, but got I
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01fe: Expected O, but got I
		//IL_020d: Expected O, but got I
		//IL_03f3: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Expected O, but got Unknown
		//IL_03cd: Expected O, but got I
		//IL_03dc: Expected O, but got I
		//IL_0373: Expected O, but got I
		//IL_042a: Expected O, but got I
		//IL_0514: Expected O, but got I
		//IL_0524: Expected O, but got I
		//IL_0548: Expected O, but got I4
		World world = default(World);
		object obj = world;
		Filter.EntityEnumerator enumerator = filterForInitialize.GetEnumerator();
		world = (World)obj;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj10 = default(object);
		ref HandComponent data = default(ref HandComponent);
		ref HandComponent data2 = default(ref HandComponent);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
			if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
			{
				if (obj3 == null)
				{
					break;
				}
				IntPtr intPtr = (IntPtr)0;
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X8_v39+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00f4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X8_v39+B0]");
				object obj5 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X11_v30-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X8_v39+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj5 = (long)(IntPtr)obj5 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00f4;
				}
				object obj6 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ X21_v20 (Il2CppMethodInfo)+48]");
				object obj7 = obj6 + 0;
				int num3 = (int)((long)(IntPtr)obj7 << 4);
				object obj8 = (long)(IntPtr)obj4 + (long)num3;
				object obj9 = (long)(IntPtr)obj8 + 304L;
				goto IL_0593;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
			GameConfig gameConfig = config;
			if (!(BaseGlobalEvent<int>)gameConfig.Weapon)
			{
				return;
			}
			world = filterInitialized.GetEnumerator().world;
			object obj19;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				if ((int)((long)(IntPtr)obj10 & 1L) == 0)
				{
					break;
				}
				IntPtr intPtr2 = (IntPtr)0;
				object obj11 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ X8_v21+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_038c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ X8_v21+B0]");
				object obj12 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v945 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ X8_v21+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj12 = (long)(IntPtr)obj12 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_038c;
				}
				object obj13 = obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ X21_v15 (Il2CppMethodInfo)+48]");
				object obj14 = obj13 + 0;
				int num6 = (int)((long)(IntPtr)obj14 << 4);
				object obj15 = (long)(IntPtr)obj11 + (long)num6;
				object obj16 = (long)(IntPtr)obj15 + 304L;
				goto IL_069c;
				IL_038c:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_069c;
				IL_069c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v965 @ X0_v45+8]");
				ref HandComponent component = ref ((IEntity)0).GetComponent<HandComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v969 @ X0_v47 (GBG.Pinata.ECS.Components.HandComponent&)] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ X0_v49 (GBG.Pinata.ECS.Components.HandComponent&)+28]");
				if ((UnityEngine.Object)0 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ X0_v49 (GBG.Pinata.ECS.Components.HandComponent&)+28]");
					UnityEngine.Object.Destroy((UnityEngine.Object)0);
				}
				GameConfig gameConfig2 = config;
				WeaponSetup value = gameConfig2.Weapon.Data.Value;
				GameConfig gameConfig3 = config;
				int value2 = ((BaseGlobalVariable<int>)gameConfig3.Weapon).Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X0_v56 (GBG.Pinata.ECS.WeaponSetup)+18]");
				bool flag5 = 0L < (long)value2;
				bool flag6 = !flag5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X0_v56 (GBG.Pinata.ECS.WeaponSetup)+18]");
				int num7 = (int)(-value2);
				bool flag7 = num7 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int num8 = value2 << 3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X0_v56 (GBG.Pinata.ECS.WeaponSetup)+10]");
				object obj17 = 0L + (long)num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ X8_v31+20]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ X8_v32+20]");
				_ = 0;
				Spawn(ref data);
				obj19 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
			return;
			IL_00f4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0593;
			IL_0593:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ X0_v80+8]");
			ref HandComponent component2 = ref ((IEntity)0).GetComponent<HandComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v663 @ X0_v82 (GBG.Pinata.ECS.Components.HandComponent&)] (should have been resolved before IL gen)");
			Spawn(ref data2);
			IntPtr intPtr3 = (IntPtr)0;
			object obj20 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ X21_v21 (Il2CppMethodInfo)+48]");
			obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ X8_v42+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ X8_v42+B0]");
				object obj21 = 0L + 8L;
				int num9 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ X11_v25-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num9++;
					int num10 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ X8_v42+126]");
					bool flag9 = (long)num10 < 0L;
					bool flag10 = !flag9;
					obj21 = (long)(IntPtr)obj21 + 16L;
					if (!flag10)
					{
						continue;
					}
					goto IL_01c4;
				}
				object obj22 = obj21 + (long)(IntPtr)obj19;
				int num11 = (int)((long)(IntPtr)obj22 << 4);
				object obj23 = (long)(IntPtr)obj20 + (long)num11;
				object obj24 = (long)(IntPtr)obj23 + 304L;
				goto IL_0620;
			}
			goto IL_01c4;
			IL_01c4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0620;
			IL_0620:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X0_v85+8]");
			ref WeaponSpawnedMarker reference = ref ((IEntity)0).AddComponent<WeaponSpawnedMarker>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v863 @ X0_v87 (WeaponSpawnedMarker&)] (should have been resolved before IL gen)");
		}
		NullReferenceException ex = new NullReferenceException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		throw new TypeLoadException();
		[Token(Token = "0x6000020")]
		[Address(RVA = "0xCCAE4C", Offset = "0xCCAE4C", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EC35E0]);\n\tv33 = *([v32 @ X8_v20]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2023792]) = v52;\nL_001F:\n\tv57 = UnityEngine.GameObject::get_transform(*([data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+40]));\n\tv102 = UnityEngine.Transform::get_position(v57);\n\tv115 = UnityEngine.GameObject::get_transform(*([data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+40]));\n\tv179 = UnityEngine.Transform::get_rotation(v115);\n\tgoto L_0052;\n\tv189 = *([v185 @ X0_v9+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0052;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v185, v178, v36, v37, v38, v39, v40, v41, v179, v180, v181, v182, v46, v47, v48, v49);\nL_0052:\n\tv116 = UnityEngine.Object::Instantiate(*([data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+40]), v102, v179);\n\tv117 = UnityEngine.GameObject::AddComponent(v116);\n\tv117.ID = data->klass;\n\tv118 = UnityEngine.GameObject::AddComponent(v116);\n\t*([data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+20]) = v118;\n\t// 107 MakeStruct v64 @ AGGCCAF88_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+58], [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+5C], [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+60]\n\tUnityEngine.BoxCollider::set_size(v118, v64);\n\tv119 = UnityEngine.GameObject::AddComponent(v116);\n\tUnityEngine.Rigidbody::set_isKinematic(v119, 1);\n\tv120 = UnityEngine.GameObject::get_transform(v116);\n\tUnityEngine.Transform::SetParent(v120, *([data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+50]), 0);\n\t*([data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+28]) = v116;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void Spawn(ref HandComponent reference2)
		{
			//IL_0016: Expected O, but got I
			//IL_0042: Expected O, but got I
			//IL_0076: Expected O, but got I
			//IL_00a3: Expected I4, but got O
			//IL_00cf: Expected F4, but got I
			//IL_00e4: Expected F4, but got I
			//IL_00f9: Expected F4, but got I
			//IL_0152: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+40]");
			Transform transform = ((GameObject)0).transform;
			Vector3 position = transform.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+40]");
			Transform transform2 = ((GameObject)0).transform;
			Quaternion rotation = transform2.rotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+40]");
			GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)0, position, rotation);
			WeaponObject weaponObject = gameObject.AddComponent<WeaponObject>();
			weaponObject.ID = (int)reference2;
			BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+58]");
			Vector3 size = default(Vector3);
			size.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+5C]");
			size.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+60]");
			size.z = 0f;
			boxCollider.size = size;
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			Transform transform3 = gameObject.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X0 (GBG.Pinata.ECS.Components.HandComponent&)+50]");
			transform3.SetParent((Transform)0, worldPositionStays: false);
		}
	}

	[Token(Token = "0x600001F")]
	[Address(RVA = "0xCCAFF8", Offset = "0xCCAFF8", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SpawnWeaponsSystem()
	{
	}
}
