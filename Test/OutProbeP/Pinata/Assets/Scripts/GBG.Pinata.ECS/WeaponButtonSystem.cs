using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
[Token(Token = "0x200002A")]
public class WeaponButtonSystem : UpdateSystem
{
	[Required]
	[Token(Token = "0x4000091")]
	[FieldOffset(Offset = "0x28")]
	public GlobalVariableInt Coins;

	[Token(Token = "0x4000092")]
	[FieldOffset(Offset = "0x30")]
	private Filter filter;

	[Token(Token = "0x4000093")]
	[FieldOffset(Offset = "0x38")]
	private Filter filterInited;

	[Token(Token = "0x4000094")]
	[FieldOffset(Offset = "0x40")]
	private Filter filterParameterComponent;

	[Token(Token = "0x4000095")]
	[FieldOffset(Offset = "0x48")]
	private GameConfig config;

	[Token(Token = "0x4000096")]
	[FieldOffset(Offset = "0x50")]
	public GlobalEventInt OnSelectWeaponClick;

	[Token(Token = "0x4000097")]
	[FieldOffset(Offset = "0x58")]
	public GlobalEventInt OnAmmoUpgradeClick;

	[Token(Token = "0x4000098")]
	[FieldOffset(Offset = "0x60")]
	public GlobalEventInt OnPowerUpgradeClick;

	[Token(Token = "0x4000099")]
	[FieldOffset(Offset = "0x68")]
	public GlobalEventInt OnBuyWeaponClick;

	[Token(Token = "0x6000052")]
	[Address(RVA = "0xCCCBBC", Offset = "0xCCCBBC", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDBE18]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20237A9]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv54 = Morpeh.Filter::With(v42, 1);\n\tv75 = Morpeh.Filter::Without(v54, 1);\n\tthis.filter = v75;\n\tv55 = Morpeh.FilterProvider::get_All(this.filter);\n\tv56 = Morpeh.Filter::With(v55, 1);\n\tv76 = Morpeh.Filter::With(v56, 1);\n\tthis.filterInited = v76;\n\tv57 = Morpeh.FilterProvider::get_All(this.filter);\n\tv109 = Morpeh.Filter::With(v57, 1);\n\tthis.filterParameterComponent = v109;\n\tv92 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v92;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<WeaponButtonComponent>();
		Filter filter2 = filter.Without<InitializeMarker>();
		this.filter = filter2;
		Filter all2 = Filter.All;
		Filter filter3 = all2.With<WeaponButtonComponent>();
		Filter filter4 = filter3.With<InitializeMarker>();
		filterInited = filter4;
		Filter all3 = Filter.All;
		Filter filter5 = all3.With<WeaponButtonParametersOpacityComponent>();
		filterParameterComponent = filter5;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x6000053")]
	[Address(RVA = "0xCCCCC4", Offset = "0xCCCCC4", Length = "0xB28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EBE488]);\n\tv35 = *([v34 @ X8_v134]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20237AA]) = v54;\nL_001E:\n\tv560 = this.filter;\n\tv71 = v560.Length < 1;\n\tif (v71) goto L_011A;\nL_0037:\n\tv562 = v560.world;\n\tv153 = v562.Entities;\n\tv492 = v153[v563[v204 @ X28_v25 (System.Int32)]];\n\tv617 = Il2CppMethodInfo;\n\tv765 = *([v492 @ X20_v29 (Morpeh.Entity)]);\n\tv768 = *([v765 @ X8_v109 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v768) goto L_0065;\n\tv1028 = *([v765 @ X8_v109 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0051:\n\tv1042 = *([v1028 @ X11_v45-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1042) goto L_0068;\n\tv1027 = v1027 + 1;\n\tv1103 = v1027 < *([v765 @ X8_v109 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv892 = ~v1103;\n\tv1028 = v1028 + 0x10;\n\tv876 = ~v892;\n\tif (v876) goto L_0051;\nL_0065:\n\tv1110 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v153[v563[v204 @ X28_v25 (System.Int32)]], Il2CppClass<Morpeh.IEntity>);\n\tgoto L_006E;\nL_0068:\n\tv1105 = *([v1028 @ X11_v45]) + *([v617 @ X21_v31 (Il2CppMethodInfo)+48]);\n\tv1106 = v1105 << 4;\n\tv1107 = v765 + v1106;\n\tv1110 = v1107 + 0x130;\nL_006E:\n\tv1114 = Morpeh.IEntity::GetComponent(*([v1110 @ X0_v159+8]));\n\t*([v1114 @ X0_v161 (WeaponButtonComponent&)])(v1199, v153[v563[v204 @ X28_v25 (System.Int32)]], v1114, *([v617 @ X21_v31 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, 0, v82, v46, v906, v2071, v49, v50, v51);\n\tv1274 = UnityEngine.Transform::GetSiblingIndex(*([v1199 @ X0_v163+20]));\n\tv333 = *([v1199 @ X0_v163+78]) == v1274;\n\tif (v333) goto L_008B;\n\tv1599 = UnityEngine.Transform::GetSiblingIndex(*([v1199 @ X0_v163+20]));\n\t*([v1199 @ X0_v163+78]) = v1599;\nL_008B:\n\tv489 = *([v1199 @ X0_v163+28]);\n\tgoto L_009C;\n\tv1717 = *([v1661 @ X0_v167+E0]);\n\tv1718 = v1717 == 0;\n\tv1719 = ~v1718;\n\tif (v1719) goto L_009C;\n\tv1721 = \"il2cpp_codegen_runtime_class_init\"(v1661, v188, v150, v39, v40, v41, v42, v43, v55, v45, v46, v47, v48, v49, v50, v51);\nL_009C:\n\tv413 = UnityEngine.Object::op_Equality(*([v489 @ X8_v112+C0]), 0);\n\tv1776 = v413 == 0;\n\tif (v1776) goto L_00C8;\n\tv470 = this.config;\n\tv711 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v470.Weapon.Data);\n\tv1997 = *([v711 @ X0_v181 (GBG.Pinata.ECS.WeaponSetup)+18]) < *([v1199 @ X0_v163+78]);\n\tv391 = ~v1997;\n\tv372 = *([v711 @ X0_v181 (GBG.Pinata.ECS.WeaponSetup)+18]) - *([v1199 @ X0_v163+78]);\n\tv334 = v372 == 0;\n\tv1998 = ~v334;\n\tv244 = v391 & v1998;\n\tif (v244) goto L_00BD;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00BD:\n\tv110 = *([v1199 @ X0_v163+78]) << 3;\n\tv2028 = *([v711 @ X0_v181 (GBG.Pinata.ECS.WeaponSetup)+10]) + v110;\n\tv471 = *([v2028 @ X8_v128+20]);\n\tUnityEngine.UI.Image::set_sprite(*([v1199 @ X0_v163+28]), *([v471 @ X8_v129+18]));\nL_00C8:\n\tv472 = this.filter;\n\tv1886 = v472.world;\n\tv155 = v1886.Entities;\n\tv496 = v155[v1887[v204 @ X28_v25 (System.Int32)]];\n\tv195 = Il2CppMethodInfo;\n\tv1940 = *([v496 @ X20_v32 (Morpeh.Entity)]);\n\tv1359 = *([v195 @ X21_v35 (Il2CppMethodInfo)+48]);\n\tv507 = *([v1940 @ X8_v120 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v507) goto L_00FA;\n\tv2001 = *([v1940 @ X8_v120 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00E6:\n\tv2015 = *([v2001 @ X11_v40-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v2015) goto L_00FD;\n\tv2000 = v2000 + 1;\n\tv2029 = v2000 < *([v1940 @ X8_v120 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv1986 = ~v2029;\n\tv2001 = v2001 + 0x10;\n\tv1970 = ~v1986;\n\tif (v1970) goto L_00E6;\nL_00FA:\n\tv2045 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v155[v1887[v204 @ X28_v25 (System.Int32)]], Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0103;\nL_00FD:\n\tv2031 = *([v2001 @ X11_v40]) + v1359;\n\tv2032 = v2031 << 4;\n\tv2033 = v1940 + v2032;\n\tv2045 = v2033 + 0x130;\nL_0103:\n\tv2049 = Morpeh.IEntity::AddComponent(*([v2045 @ X0_v172+8]));\n\t*([v2049 @ X0_v174 (InitializeMarker&)])(v416, v155[v1887[v204 @ X28_v25 (System.Int32)]], v2049, v1359, v39, v40, v41, v42, v43, 0, v82, v46, v906, v2071, v49, v50, v51);\n\tv204 = v204 + 1;\n\tv246 = v204 >= v560.Length;\n\tif (v246) goto L_011A;\n\tv560 = this.filter;\n\tv2061 = this.filter == 0;\n\tv443 = ~v2061;\n\tif (v443) goto L_0037;\n\tgoto L_035A;\nL_011A:\n\tv898 = this.filterInited;\n\tv530 = v898.Length < 1;\n\tif (v530) goto L_0360;\nL_012F:\n\tv900 = v898.world;\n\tv158 = v900.Entities;\n\tv498 = v158[v901[v207 @ X28_v22 (System.Int32)]];\n\tv198 = Il2CppMethodInfo;\n\tv1049 = *([v498 @ X20_v26 (Morpeh.Entity)]);\n\tv149 = *([v198 @ X21_v26 (Il2CppMethodInfo)+48]);\n\tv1052 = *([v1049 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v1052) goto L_015F;\n\tv1202 = *([v1049 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_014B:\n\tv1216 = *([v1202 @ X11_v32-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1216) goto L_0162;\n\tv1201 = v1201 + 1;\n\tv1275 = v1201 < *([v1049 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv1141 = ~v1275;\n\tv1202 = v1202 + 0x10;\n\tv1125 = ~v1141;\n\tif (v1125) goto L_014B;\nL_015F:\n\tv1282 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v158[v901[v207 @ X28_v22 (System.Int32)]], Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0168;\nL_0162:\n\tv1277 = *([v1202 @ X11_v32]) + v149;\n\tv1278 = v1277 << 4;\n\tv1279 = v1049 + v1278;\n\tv1282 = v1279 + 0x130;\nL_0168:\n\tv1286 = Morpeh.IEntity::GetComponent(*([v1282 @ X0_v84+8]));\n\t*([v1286 @ X0_v86 (WeaponButtonComponent&)])(v419, v158[v901[v207 @ X28_v22 (System.Int32)]], v1286, v149, v39, v40, v41, v42, v43, v87, *([v2208 @ X0_v125 (Morpeh.Globals.BaseGlobalEvent`1<System.Int32>)]), v46, v906, v2071, v49, v50, v51);\n\tv477 = v465.config;\n\tv712 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v477.Weapon.Data);\n\tv1778 = *([v712 @ X0_v90 (GBG.Pinata.ECS.WeaponSetup)+18]) < *([v419 @ X0_v88+78]);\n\tv397 = ~v1778;\n\tv378 = *([v712 @ X0_v90 (GBG.Pinata.ECS.WeaponSetup)+18]) - *([v419 @ X0_v88+78]);\n\tv340 = v378 == 0;\n\tv1779 = ~v340;\n\tv250 = v397 & v1779;\n\tif (v250) goto L_018D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_018D:\n\tv117 = *([v419 @ X0_v88+78]) << 3;\n\tv478 = *([v712 @ X0_v90 (GBG.Pinata.ECS.WeaponSetup)+10]) + v117;\n\tv209 = *([v478 @ X8_v54+20]);\n\tv713 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v477.Weapon.Data);\n\tv1991 = *([v713 @ X0_v93 (GBG.Pinata.ECS.WeaponSetup)+18]) < *([v419 @ X0_v88+78]);\n\tv398 = ~v1991;\n\tv379 = *([v713 @ X0_v93 (GBG.Pinata.ECS.WeaponSetup)+18]) - *([v419 @ X0_v88+78]);\n\tv341 = v379 == 0;\n\tv1992 = ~v341;\n\tv251 = v398 & v1992;\n\tif (v251) goto L_01AB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01AB:\n\tv107 = *([v419 @ X0_v88+78]) << 3;\n\tv479 = *([v713 @ X0_v93 (GBG.Pinata.ECS.WeaponSetup)+10]) + v107;\n\tv105 = *([v479 @ X8_v57+20]);\n\tv422 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v465.Coins);\n\tv423 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v419 @ X0_v88]));\n\tv2070 = v423 == 0;\n\tif (v2070) goto L_01D8;\n\tv2073 = *([v209 @ X27_v22+28]) == 0;\n\tif (v2073) goto L_01D8;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v477.Weapon, *([v419 @ X0_v88+78]));\n\tMorpeh.Globals.BaseGlobalEvent`1<System.Int32>::Publish(v465.OnSelectWeaponClick, *([v419 @ X0_v88+78]));\nL_01D8:\n\tv2083 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v419 @ X0_v88+8]));\n\tv2090 = v2083 == 0;\n\tif (v2090) goto L_FFFFFFFF;\n\tv624 = *([v105 @ X22_v26+3C]) <= *([v105 @ X22_v26+40]);\n\tif (v624) goto L_0205;\n\tv2099 = *([v105 @ X22_v26+40]) + 1;\n\t*([v105 @ X22_v26+40]) = v2099;\n\tv2101 = *([v105 @ X22_v26+50]) + *([v209 @ X27_v22+2C]);\n\t*([v209 @ X27_v22+2C]) = v2101;\n\tv595 = *([v105 @ X22_v26+4C]) << 1;\n\t*([v105 @ X22_v26+4C]) = v595;\n\tv407 = v422 - *([v105 @ X22_v26+4C]);\n\tMorpeh.Globals.BaseGlobalEvent`1<System.Int32>::Publish(v465.OnAmmoUpgradeClick, *([v419 @ X0_v88+78]));\n\tgoto L_0205;\nL_0205:\n\tv2110 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v419 @ X0_v88+10]));\n\tv2112 = v2110 == 0;\n\tif (v2112) goto L_022F;\n\tv625 = *([v105 @ X22_v26+3C]) <= *([v105 @ X22_v26+44]);\n\tif (v625) goto L_022F;\n\tv2124 = *([v105 @ X22_v26+44]) + 1;\n\t*([v105 @ X22_v26+44])\n// ... truncated")]
	public override void OnUpdate(float deltaTime)
	{
		//IL_0043: Expected I, but got O
		//IL_112a: Expected I, but got O
		//IL_04ef: Expected I, but got O
		//IL_15f4: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_015c: Expected O, but got I
		//IL_1789: Expected O, but got I
		//IL_1177: Expected O, but got I
		//IL_16fb: Expected O, but got I
		//IL_053a: Expected O, but got I
		//IL_1617: Expected O, but got I
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0137: Expected O, but got I
		//IL_0146: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_11f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fb: Expected O, but got Unknown
		//IL_1218: Expected O, but got I
		//IL_1227: Expected O, but got I
		//IL_0662: Expected O, but got I
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected O, but got Unknown
		//IL_05ec: Expected O, but got I
		//IL_05fb: Expected O, but got I
		//IL_01ba: Expected O, but got I
		//IL_11c3: Expected O, but got I
		//IL_06cd: Expected O, but got I
		//IL_06dd: Expected O, but got I
		//IL_0586: Expected O, but got I
		//IL_12f6: Expected O, but got I
		//IL_1306: Expected O, but got I
		//IL_0744: Expected O, but got I
		//IL_0344: Expected I, but got O
		//IL_13dc: Expected O, but got I
		//IL_07af: Expected O, but got I
		//IL_07bf: Expected O, but got I
		//IL_024c: Expected O, but got I
		//IL_164f: Expected O, but got I
		//IL_038f: Expected O, but got I
		//IL_02b7: Expected O, but got I
		//IL_02c7: Expected O, but got I
		//IL_02e9: Expected O, but got I
		//IL_02e9: Expected O, but got I
		//IL_136a: Expected O, but got I
		//IL_087f: Expected O, but got I
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0441: Expected O, but got I
		//IL_0450: Expected O, but got I
		//IL_1845: Expected O, but got I
		//IL_03db: Expected O, but got I
		//IL_14bf: Expected O, but got F4
		//IL_0991: Expected O, but got I
		//IL_0a89: Expected O, but got I
		//IL_0aff: Expected O, but got I
		//IL_08ed: Expected O, but got I
		//IL_0912: Expected O, but got I
		//IL_1830: Expected O, but got I
		//IL_1482: Expected O, but got F4
		//IL_0b1a: Expected O, but got I
		//IL_0b34: Expected O, but got I
		//IL_09f7: Expected O, but got I
		//IL_0a19: Expected O, but got I
		//IL_0b92: Expected O, but got I
		//IL_0ba8: Expected O, but got I
		//IL_0bc2: Expected O, but got I
		//IL_0c22: Expected O, but got I
		//IL_0b78: Expected O, but got I
		//IL_0b7d: Expected I, but got O
		//IL_0c38: Expected O, but got I
		//IL_0c52: Expected O, but got I
		//IL_0cb2: Expected O, but got I
		//IL_0c08: Expected O, but got I
		//IL_0c0d: Expected I, but got O
		//IL_0ccd: Expected O, but got I
		//IL_0ce7: Expected O, but got I
		//IL_0c98: Expected O, but got I
		//IL_0c9d: Expected I, but got O
		//IL_0d45: Expected O, but got I
		//IL_0d5b: Expected O, but got I
		//IL_0d75: Expected O, but got I
		//IL_0d2b: Expected O, but got I
		//IL_0d30: Expected I, but got O
		//IL_0ea6: Expected O, but got I
		//IL_0ded: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df2: Expected O, but got Unknown
		//IL_0e09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0e: Expected I4, but got Unknown
		//IL_0dbb: Expected O, but got I
		//IL_0f5c: Expected O, but got I
		//IL_0ed3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed8: Expected O, but got Unknown
		//IL_0eef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef4: Expected I4, but got Unknown
		//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcc: Expected O, but got Unknown
		//IL_0fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe8: Expected I4, but got Unknown
		//IL_1042: Expected O, but got I
		//IL_1055: Expected I, but got O
		Filter filter = this.filter;
		if (filter.Length >= 1)
		{
			int num = 0;
			int[] array = default(int[]);
			int[] array2 = default(int[]);
			while (true)
			{
				World world = filter.world;
				Entity[] entities = world.Entities;
				Entity entity = entities[array[num]];
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)entity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ X8_v109 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00e3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ X8_v109 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ X11_v45-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ X8_v109 (Il2CppClass<Morpeh.Entity>)+126]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ X21_v31 (Il2CppMethodInfo)+48]");
				object obj3 = obj2 + 0;
				int num4 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr2 + (long)num4;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_15e3;
				IL_15e3:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1110 @ X0_v159+8]");
				ref WeaponButtonComponent component = ref ((IEntity)0).GetComponent<WeaponButtonComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1114 @ X0_v161 (WeaponButtonComponent&)] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+20]");
				int siblingIndex = ((Transform)0).GetSiblingIndex();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+78]");
				if ((IntPtr)0 != (IntPtr)siblingIndex)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+20]");
					int siblingIndex2 = ((Transform)0).GetSiblingIndex();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+28]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ X8_v112+C0]");
				if ((UnityEngine.Object)0 == null)
				{
					GameConfig gameConfig = config;
					WeaponSetup value = gameConfig.Weapon.Data.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ X0_v181 (GBG.Pinata.ECS.WeaponSetup)+18]");
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+78]");
					bool flag3 = (long)intPtr3 < 0L;
					bool flag4 = !flag3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ X0_v181 (GBG.Pinata.ECS.WeaponSetup)+18]");
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+78]");
					object obj7 = (long)intPtr4 - 0L;
					bool flag5 = obj7 == null;
					bool flag6 = !flag5;
					if (!(flag4 && flag6))
					{
						throw new ArgumentOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+78]");
					int num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ X0_v181 (GBG.Pinata.ECS.WeaponSetup)+10]");
					object obj8 = 0L + (long)num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2028 @ X8_v128+20]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1199 @ X0_v163+28]");
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X8_v129+18]");
					((Image)(long)intPtr5).sprite = (Sprite)0;
				}
				Filter filter2 = this.filter;
				World world2 = filter2.world;
				Entity[] entities2 = world2.Entities;
				Entity entity2 = entities2[array2[num]];
				IntPtr intPtr6 = (IntPtr)0;
				IntPtr intPtr7 = (IntPtr)entity2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X21_v35 (Il2CppMethodInfo)+48]");
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1940 @ X8_v120 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_03f4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1940 @ X8_v120 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj10 = 0L + 8L;
				int num6 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2001 @ X11_v40-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num6++;
					int num7 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1940 @ X8_v120 (Il2CppClass<Morpeh.Entity>)+126]");
					bool flag7 = (long)num7 < 0L;
					bool flag8 = !flag7;
					obj10 = (long)(IntPtr)obj10 + 16L;
					if (!flag8)
					{
						continue;
					}
					goto IL_03f4;
				}
				object obj11 = obj10 + (long)intPtr8;
				int num8 = (int)((long)(IntPtr)obj11 << 4);
				object obj12 = (long)intPtr7 + (long)num8;
				object obj13 = (long)(IntPtr)obj12 + 304L;
				goto IL_163e;
				IL_163e:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2045 @ X0_v172+8]");
				ref InitializeMarker reference = ref ((IEntity)0).AddComponent<InitializeMarker>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2049 @ X0_v174 (InitializeMarker&)] (should have been resolved before IL gen)");
				num++;
				if (num >= filter.Length)
				{
					break;
				}
				filter = this.filter;
				if (this.filter != null)
				{
					continue;
				}
				goto IL_10f2;
				IL_03f4:
				((BaseGlobalVariable<int>)(object)entities2[array2[num]]).Value = 0;
				goto IL_163e;
				IL_00e3:
				((BaseGlobalVariable<int>)(object)entities[array[num]]).Value = 0;
				goto IL_15e3;
			}
		}
		Filter filter3 = filterInited;
		bool flag9 = filter3.Length < 1;
		WeaponButtonSystem weaponButtonSystem = this;
		if (!flag9)
		{
			float num9 = 0f;
			int num10 = 0;
			WeaponButtonSystem weaponButtonSystem2 = this;
			int[] array3 = default(int[]);
			object obj24 = default(object);
			string text = default(string);
			string text2 = default(string);
			string text3 = default(string);
			string text4 = default(string);
			string text5 = default(string);
			while (true)
			{
				World world3 = filter3.world;
				Entity[] entities3 = world3.Entities;
				Entity entity3 = entities3[array3[num10]];
				IntPtr intPtr9 = (IntPtr)0;
				IntPtr intPtr10 = (IntPtr)entity3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X21_v26 (Il2CppMethodInfo)+48]");
				IntPtr intPtr11 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_059f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj14 = 0L + 8L;
				int num11 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ X11_v32-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num11++;
					int num12 = num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]");
					bool flag10 = (long)num12 < 0L;
					bool flag11 = !flag10;
					obj14 = (long)(IntPtr)obj14 + 16L;
					if (!flag11)
					{
						continue;
					}
					goto IL_059f;
				}
				object obj15 = obj14 + (long)intPtr11;
				int num13 = (int)((long)(IntPtr)obj15 << 4);
				object obj16 = (long)intPtr10 + (long)num13;
				object obj17 = (long)(IntPtr)obj16 + 304L;
				goto IL_16ea;
				IL_059f:
				((BaseGlobalVariable<int>)(object)entities3[array3[num10]]).Value = 0;
				goto IL_16ea;
				IL_16ea:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1282 @ X0_v84+8]");
				ref WeaponButtonComponent component2 = ref ((IEntity)0).GetComponent<WeaponButtonComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1286 @ X0_v86 (WeaponButtonComponent&)] (should have been resolved before IL gen)");
				GameConfig gameConfig2 = weaponButtonSystem2.config;
				WeaponSetup value2 = gameConfig2.Weapon.Data.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X0_v90 (GBG.Pinata.ECS.WeaponSetup)+18]");
				IntPtr intPtr12 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
				bool flag12 = (long)intPtr12 < 0L;
				bool flag13 = !flag12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X0_v90 (GBG.Pinata.ECS.WeaponSetup)+18]");
				IntPtr intPtr13 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
				object obj18 = (long)intPtr13 - 0L;
				bool flag14 = obj18 == null;
				bool flag15 = !flag14;
				if (!(flag13 && flag15))
				{
					throw new ArgumentOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
				int num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X0_v90 (GBG.Pinata.ECS.WeaponSetup)+10]");
				object obj19 = 0L + (long)num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ X8_v54+20]");
				object obj20 = 0;
				WeaponSetup value3 = gameConfig2.Weapon.Data.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ X0_v93 (GBG.Pinata.ECS.WeaponSetup)+18]");
				IntPtr intPtr14 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
				bool flag16 = (long)intPtr14 < 0L;
				bool flag17 = !flag16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ X0_v93 (GBG.Pinata.ECS.WeaponSetup)+18]");
				IntPtr intPtr15 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
				object obj21 = (long)intPtr15 - 0L;
				bool flag18 = obj21 == null;
				bool flag19 = !flag18;
				if (!(flag17 && flag19))
				{
					throw new ArgumentOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
				int num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ X0_v93 (GBG.Pinata.ECS.WeaponSetup)+10]");
				object obj22 = 0L + (long)num15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ X8_v57+20]");
				object obj23 = 0;
				int value4 = weaponButtonSystem2.Coins.Value;
				if (((BaseGlobalEvent<int>)obj24).IsPublished)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X27_v22+28]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						WeaponSettings weapon = gameConfig2.Weapon;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
						((BaseGlobalVariable<int>)weapon).Value = 0;
						GlobalEventInt onSelectWeaponClick = weaponButtonSystem2.OnSelectWeaponClick;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
						onSelectWeaponClick.Publish(0);
						intPtr11 = (IntPtr)0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+8]");
				int num16;
				if (((BaseGlobalEvent<int>)0).IsPublished)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+3C]");
					IntPtr intPtr16 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+40]");
					bool flag20 = (long)intPtr16 <= 0L;
					num16 = value4;
					if (!flag20)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+40]");
						object obj25 = 0L + 1L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+50]");
						IntPtr intPtr17 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X27_v22+2C]");
						object obj26 = (long)intPtr17 + 0L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+4C]");
						int num17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+4C]");
						num16 = (int)((long)value4 - 0L);
						GlobalEventInt onAmmoUpgradeClick = weaponButtonSystem2.OnAmmoUpgradeClick;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
						onAmmoUpgradeClick.Publish(0);
						intPtr11 = (IntPtr)0;
					}
				}
				else
				{
					num16 = value4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+10]");
				if (((BaseGlobalEvent<int>)0).IsPublished)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+3C]");
					IntPtr intPtr18 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+44]");
					if ((long)intPtr18 > 0L)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+44]");
						object obj27 = 0L + 1L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+58]");
						IntPtr intPtr19 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X27_v22+30]");
						object obj28 = (long)intPtr19 + 0L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+54]");
						int num18 = 0;
						int num19 = num16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+54]");
						num16 = (int)((long)num19 - 0L);
						GlobalEventInt onPowerUpgradeClick = weaponButtonSystem2.OnPowerUpgradeClick;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
						onPowerUpgradeClick.Publish(0);
						intPtr11 = (IntPtr)0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+18]");
				if (((BaseGlobalEvent<int>)0).IsPublished)
				{
					_ = 1;
					int num20 = num16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X22_v26+48]");
					num16 = (int)((long)num20 - 0L);
					GlobalEventInt onBuyWeaponClick = weaponButtonSystem2.OnBuyWeaponClick;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+78]");
					onBuyWeaponClick.Publish(0);
					intPtr11 = (IntPtr)0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+58]");
				object obj29 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ X8_v65+C0]");
				int num21 = Convert.ToInt32((string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ X8_v57+20]");
				BaseGlobalEvent<int> baseGlobalEvent = (BaseGlobalEvent<int>)(0L + 76L);
				if ((IntPtr)num21 != (IntPtr)baseGlobalEvent)
				{
					baseGlobalEvent.Publish(0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+58]");
					((TMP_Text)0).text = text;
					intPtr11 = (IntPtr)null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+60]");
				object obj30 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X8_v68+C0]");
				float num22 = float.Parse((string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ X8_v57+20]");
				BaseGlobalEvent<int> baseGlobalEvent2 = (BaseGlobalEvent<int>)(0L + 84L);
				if (num22 != (float)baseGlobalEvent2)
				{
					baseGlobalEvent2.Publish(0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+60]");
					((TMP_Text)0).text = text2;
					intPtr11 = (IntPtr)null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+50]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X8_v69+C0]");
				float num23 = float.Parse((string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ X8_v57+20]");
				BaseGlobalEvent<int> baseGlobalEvent3 = (BaseGlobalEvent<int>)(0L + 72L);
				if (num23 != (float)baseGlobalEvent3)
				{
					baseGlobalEvent3.Publish(0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+50]");
					((TMP_Text)0).text = text3;
					intPtr11 = (IntPtr)null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+68]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ X8_v70+C0]");
				int num24 = Convert.ToInt32((string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ X8_v54+20]");
				BaseGlobalEvent<int> baseGlobalEvent4 = (BaseGlobalEvent<int>)(0L + 44L);
				if ((IntPtr)num24 != (IntPtr)baseGlobalEvent4)
				{
					baseGlobalEvent4.Publish(0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+68]");
					((TMP_Text)0).text = text4;
					intPtr11 = (IntPtr)null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+70]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v74+C0]");
				num9 = float.Parse((string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ X8_v54+20]");
				BaseGlobalEvent<int> baseGlobalEvent5 = (BaseGlobalEvent<int>)(0L + 48L);
				if (num9 != (float)baseGlobalEvent5)
				{
					baseGlobalEvent5.Publish(0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+70]");
					((TMP_Text)0).text = text5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X27_v22+28]");
				bool interactable;
				if ((IntPtr)0 != (IntPtr)0)
				{
					object obj34 = num16 - baseGlobalEvent;
					bool flag21 = (long)(IntPtr)obj34 < 0L;
					int num25 = num16 ^ baseGlobalEvent;
					int num26 = (int)((long)num16 ^ (long)(IntPtr)obj34);
					int num27 = num25 & num26;
					bool flag22 = num27 < 0;
					bool flag23 = flag21 == flag22;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+38]");
					bool flag24 = (IntPtr)0 == (IntPtr)0;
					bool flag25 = !flag24;
					interactable = flag23;
					if (!flag25)
					{
						goto IL_14f0;
					}
				}
				else
				{
					interactable = false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+38]");
				((Selectable)0).interactable = interactable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X27_v22+28]");
				bool interactable2;
				if ((IntPtr)0 != (IntPtr)0)
				{
					object obj35 = num16 - baseGlobalEvent2;
					bool flag26 = (long)(IntPtr)obj35 < 0L;
					int num28 = num16 ^ baseGlobalEvent2;
					int num29 = (int)((long)num16 ^ (long)(IntPtr)obj35);
					int num30 = num28 & num29;
					bool flag27 = num30 < 0;
					bool flag28 = flag26 == flag27;
					interactable2 = flag28;
				}
				else
				{
					interactable2 = false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+40]");
				((Selectable)0).interactable = interactable2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X27_v22+28]");
				bool interactable3;
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+48]");
					bool flag29 = (IntPtr)0 == (IntPtr)0;
					bool flag30 = !flag29;
					interactable3 = false;
					if (!flag30)
					{
						goto IL_14f0;
					}
				}
				else
				{
					object obj36 = num16 - baseGlobalEvent3;
					bool flag31 = (long)(IntPtr)obj36 < 0L;
					int num31 = num16 ^ baseGlobalEvent3;
					int num32 = (int)((long)num16 ^ (long)(IntPtr)obj36);
					int num33 = num31 & num32;
					bool flag32 = num33 < 0;
					bool flag33 = flag31 == flag32;
					interactable3 = flag33;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X0_v88+48]");
				((Selectable)0).interactable = interactable3;
				bool flag34 = value4 == num16;
				IntPtr intPtr8 = (IntPtr)null;
				if (!flag34)
				{
					Coins.Value = num16;
					intPtr8 = (IntPtr)0;
				}
				num10++;
				bool flag35 = num10 >= filter3.Length;
				weaponButtonSystem = this;
				if (flag35)
				{
					break;
				}
				filter3 = filterInited;
				bool flag36 = filterInited == null;
				bool flag37 = !flag36;
				weaponButtonSystem = this;
				weaponButtonSystem2 = this;
				if (flag37)
				{
					continue;
				}
				goto IL_10f2;
				IL_14f0:
				throw new NullReferenceException();
			}
		}
		World world4 = weaponButtonSystem.filterParameterComponent.GetEnumerator().world;
		object obj37 = default(object);
		BaseGlobalVariable<int> baseGlobalVariable = default(BaseGlobalVariable<int>);
		object obj42 = default(object);
		World world5;
		object obj47 = default(object);
		while (true)
		{
			((BaseGlobalVariable<int>)(object)world4).Value = 0;
			if ((uint)((ulong)(long)(IntPtr)obj37 & 1uL) != 0)
			{
				IntPtr intPtr20 = (IntPtr)0;
				IntPtr intPtr21 = (IntPtr)baseGlobalVariable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ X21_v20 (Il2CppMethodInfo)+48]");
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ X8_v23 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_11dc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ X8_v23 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
				object obj38 = 0L + 8L;
				int num34 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1479 @ X11_v23-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num34++;
					int num35 = num34;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1221 @ X8_v23 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					bool flag38 = (long)num35 < 0L;
					bool flag39 = !flag38;
					obj38 = (long)(IntPtr)obj38 + 16L;
					if (!flag39)
					{
						continue;
					}
					goto IL_11dc;
				}
				object obj39 = obj38 + (long)intPtr8;
				int num36 = (int)((long)(IntPtr)obj39 << 4);
				object obj40 = (long)intPtr21 + (long)num36;
				object obj41 = (long)(IntPtr)obj40 + 304L;
				goto IL_1777;
			}
			((BaseGlobalVariable<int>)(object)world4).Value = 0;
			return;
			IL_1777:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1608 @ X0_v57+8]");
			ref WeaponButtonParametersOpacityComponent component3 = ref ((IEntity)0).GetComponent<WeaponButtonParametersOpacityComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1612 @ X0_v59 (WeaponButtonParametersOpacityComponent&)] (should have been resolved before IL gen)");
			GameConfig gameConfig3 = weaponButtonSystem.config;
			WeaponSetup value5 = gameConfig3.Weapon.Data.Value;
			int siblingIndex3 = ((Transform)obj42).GetSiblingIndex();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1780 @ X0_v63 (GBG.Pinata.ECS.WeaponSetup)+18]");
			bool flag40 = 0L < (long)siblingIndex3;
			bool flag41 = !flag40;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1780 @ X0_v63 (GBG.Pinata.ECS.WeaponSetup)+18]");
			int num37 = (int)(-siblingIndex3);
			bool flag42 = num37 == 0;
			bool flag43 = !flag42;
			if (!(flag41 && flag43))
			{
				throw new ArgumentOutOfRangeException();
			}
			int num38 = siblingIndex3 << 3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1780 @ X0_v63 (GBG.Pinata.ECS.WeaponSetup)+10]");
			object obj43 = 0L + (long)num38;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2024 @ X8_v29+20]");
			object obj44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1017 @ X0_v61+8]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1017 @ X0_v61+8]");
				if ((IntPtr)0 != (IntPtr)1)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1017 @ X0_v61+18]");
				object obj45 = 0;
				object obj46 = obj45;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2066 @ X8_v34+290] (should have been resolved before IL gen)");
				GameConfig gameConfig4 = weaponButtonSystem.config;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ X8_v30+28]");
				float num39;
				if ((IntPtr)0 != (IntPtr)0)
				{
					num39 = gameConfig4.UI.MaximumOpacity;
				}
				else
				{
					bool flag44 = (object)gameConfig4 == null;
					world5 = world4;
					if (flag44)
					{
						break;
					}
					num39 = gameConfig4.UI.MinimumOpacity;
				}
				if ((float)obj47 != num39)
				{
					obj47 = num39;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1017 @ X0_v61+18]");
				object obj48 = 0;
				object obj49 = obj48;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v958 @ X8_v36+2A0] (should have been resolved before IL gen)");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1017 @ X0_v61+10]");
				object obj50 = 0;
				object obj51 = obj50;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2062 @ X8_v31+290] (should have been resolved before IL gen)");
				GameConfig gameConfig5 = weaponButtonSystem.config;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ X8_v30+28]");
				float num39 = (((IntPtr)0 == (IntPtr)0) ? gameConfig5.UI.MinimumOpacity : gameConfig5.UI.MaximumOpacity);
				if ((float)obj47 != num39)
				{
					obj47 = num39;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1017 @ X0_v61+10]");
				object obj52 = 0;
				object obj53 = obj52;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v959 @ X8_v33+2A0] (should have been resolved before IL gen)");
			}
			continue;
			IL_11dc:
			baseGlobalVariable.Value = 0;
			goto IL_1777;
		}
		NullReferenceException ex = new NullReferenceException();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2066 @ X8_v34+298]");
		if ((IntPtr)0 == (IntPtr)1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2066 @ X8_v34+298]");
			((BaseGlobalVariable<int>)(object)ex).Value = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2066 @ X8_v34+298]");
			BaseGlobalVariable<int> baseGlobalVariable2 = default(BaseGlobalVariable<int>);
			baseGlobalVariable2.Value = 0;
			((BaseGlobalVariable<int>)(object)world5).Value = 0;
			if ((object)baseGlobalVariable2 == null)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2066 @ X8_v34+298]");
			((BaseGlobalVariable<int>)(object)ex).Value = 0;
		}
		throw new TypeLoadException();
		IL_10f2:
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000054")]
	[Address(RVA = "0xCCD7EC", Offset = "0xCCD7EC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn color;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private Color ChangeOpacity(Color color, float opacity)
	{
		return color;
	}

	[Token(Token = "0x6000055")]
	[Address(RVA = "0xCCD7F4", Offset = "0xCCD7F4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public WeaponButtonSystem()
	{
	}
}
