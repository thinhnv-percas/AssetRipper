using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using GBG.Pinata.ECS.Components;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x2000028")]
public class UIActiveWindowSystem : UpdateSystem
{
	[Required]
	[Token(Token = "0x4000084")]
	[FieldOffset(Offset = "0x28")]
	public GlobalEvent ShowMainMenu;

	[Required]
	[Token(Token = "0x4000085")]
	[FieldOffset(Offset = "0x30")]
	public GlobalEvent ShowWinScreen;

	[Required]
	[Token(Token = "0x4000086")]
	[FieldOffset(Offset = "0x38")]
	public GlobalEvent ShowLoseScreen;

	[Required]
	[Token(Token = "0x4000087")]
	[FieldOffset(Offset = "0x40")]
	public GlobalEvent ShowNoInternet;

	[Token(Token = "0x4000088")]
	[FieldOffset(Offset = "0x48")]
	private Filter filterA;

	[Token(Token = "0x4000089")]
	[FieldOffset(Offset = "0x50")]
	private Filter filterB;

	[Token(Token = "0x400008A")]
	[FieldOffset(Offset = "0x58")]
	private Filter filterWeaponButtonInitialized;

	[Token(Token = "0x400008B")]
	[FieldOffset(Offset = "0x60")]
	private Filter filterWeaponButtonUninitialized;

	[Token(Token = "0x400008C")]
	[FieldOffset(Offset = "0x68")]
	private Filter filterMainMenu;

	[Token(Token = "0x400008D")]
	[FieldOffset(Offset = "0x70")]
	private GameConfig config;

	[Token(Token = "0x6000046")]
	[Address(RVA = "0xCCB218", Offset = "0xCCB218", Length = "0x1B0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EC3980]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023799]) = v40;\nL_0018:\n\tv44 = Morpeh.FilterProvider::get_All(this.filter);\n\tv71 = Morpeh.Filter::With(v44, 1);\n\tv109 = Morpeh.Filter::Without(v71, 1);\n\tthis.filterA = v109;\n\tv72 = Morpeh.FilterProvider::get_All(this.filter);\n\tv73 = Morpeh.Filter::With(v72, 1);\n\tv74 = Morpeh.Filter::With(v73, 1);\n\tv110 = Morpeh.Filter::Without(v74, 1);\n\tthis.filterB = v110;\n\tv75 = Morpeh.FilterProvider::get_All(this.filter);\n\tv76 = Morpeh.Filter::With(v75, 1);\n\tv77 = Morpeh.Filter::With(v76, 1);\n\tv111 = Morpeh.Filter::With(v77, 1);\n\tthis.filterWeaponButtonInitialized = v111;\n\tv78 = Morpeh.FilterProvider::get_All(this.filter);\n\tv79 = Morpeh.Filter::With(v78, 1);\n\tv112 = Morpeh.Filter::With(v79, 1);\n\tthis.filterWeaponButtonUninitialized = v112;\n\tv80 = Morpeh.FilterProvider::get_All(this.filter);\n\tv153 = Morpeh.Filter::With(v80, 1);\n\tthis.filterMainMenu = v153;\n\tv132 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v132;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<ActivateGameObjectComponent>();
		Filter filter2 = filter.Without<InitializeMarker>();
		filterA = filter2;
		Filter all2 = Filter.All;
		Filter filter3 = all2.With<ActivateGameObjectComponent>();
		Filter filter4 = filter3.With<InitializeMarker>();
		Filter filter5 = filter4.Without<WeaponButtonComponent>();
		filterB = filter5;
		Filter all3 = Filter.All;
		Filter filter6 = all3.With<ActivateGameObjectComponent>();
		Filter filter7 = filter6.With<InitializeMarker>();
		Filter filter8 = filter7.With<WeaponButtonComponent>();
		filterWeaponButtonInitialized = filter8;
		Filter all4 = Filter.All;
		Filter filter9 = all4.With<ActivateGameObjectComponent>();
		Filter filter10 = filter9.With<WeaponButtonComponent>();
		filterWeaponButtonUninitialized = filter10;
		Filter all5 = Filter.All;
		Filter filter11 = all5.With<UICanvasComponent>();
		filterMainMenu = filter11;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0xCCB3C8", Offset = "0xCCB3C8", Length = "0x4F8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EBBFB8]);\n\tv33 = *([v32 @ X8_v53]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, deltaTime, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202379A]) = v52;\nL_001D:\n\tv56 = this.filterA;\n\tv69 = v56.Length < 1;\n\tif (v69) goto L_002F;\n\tUIActiveWindowSystem::Initialize(this);\nL_002F:\n\tv496 = this.filterB;\n\tv382 = v496.Length < 1;\n\tif (v382) goto L_00A3;\nL_0044:\n\tv498 = v496.world;\n\tv151 = v498.Entities;\n\tv306 = v151[v499[v175 @ X23_v12 (System.Int32)]];\n\tv168 = Il2CppMethodInfo;\n\tv543 = *([v306 @ X20_v18 (Morpeh.Entity)]);\n\tv568 = *([v168 @ X21_v15 (Il2CppMethodInfo)+48]);\n\tv546 = *([v543 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v546) goto L_0072;\n\tv658 = *([v543 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_005E:\n\tv672 = *([v658 @ X11_v32-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v672) goto L_0075;\n\tv657 = v657 + 1;\n\tv680 = v657 < *([v543 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv626 = ~v680;\n\tv658 = v658 + 0x10;\n\tv610 = ~v626;\n\tif (v610) goto L_005E;\nL_0072:\n\tv687 = 0x8909C4(v151[v499[v175 @ X23_v12 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, v568, v37, v38, v39, v40, v41, 0, v90, v44, v45, v46, v47, v48, v49);\n\tgoto L_007B;\nL_0075:\n\tv682 = *([v658 @ X11_v32]) + v568;\n\tv683 = v682 << 4;\n\tv684 = v543 + v683;\n\tv687 = v684 + 0x130;\nL_007B:\n\tv691 = Morpeh.IEntity::GetComponent(*([v687 @ X0_v66+8]));\n\t*([v691 @ X0_v68 (ActivateGameObjectComponent&)])(v700, v151[v499[v175 @ X23_v12 (System.Int32)]], v691, v568, v37, v38, v39, v40, v41, 0, v90, v44, v45, v46, v47, v48, v49);\n\tv277 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(*([v700 @ X0_v70]));\n\tv487 = v277 == 0;\n\tif (v487) goto L_008D;\n\tUIActiveWindowSystem::SetActive(v277, *([v700 @ X0_v70+8]));\nL_008D:\n\tv175 = v175 + 1;\n\tv195 = v175 >= v496.Length;\n\tif (v195) goto L_00A3;\n\tv496 = this.filterB;\n\tv789 = this.filterB == 0;\n\tv286 = ~v789;\n\tif (v286) goto L_0044;\n\tgoto L_01F8;\nL_00A3:\n\tv505 = Morpeh.Filter::GetEnumerator(this.filterMainMenu);\n\tv547 = v505.world;\nL_00B6:\n\tv592 = 0x15F75B8(&v547 @ stack_-A0_v5 (Morpeh.World), 0, v568, v37, v38, v39, v40, v41, v505.ids, v505.world, v44, v45, v46, v47, v48, v49);\n\tv677 = v592 & 1;\n\tv678 = v677 == 0;\n\tif (v678) goto L_0114;\n\tv594 = v692 == 0;\n\tif (v594) goto L_0118;\n\tv638 = Il2CppMethodInfo;\n\tv701 = *([v692 @ stack_-78]);\n\tv568 = *([v638 @ X21_v13 (Il2CppMethodInfo)+48]);\n\tv704 = *([v701 @ X8_v36+126]) == 0;\n\tif (v704) goto L_00E0;\n\tv749 = *([v701 @ X8_v36+B0]) + 8;\nL_00CC:\n\tv763 = *([v749 @ X11_v25-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v763) goto L_00E3;\n\tv748 = v748 + 1;\n\tv773 = v748 < *([v701 @ X8_v36+126]);\n\tv740 = ~v773;\n\tv749 = v749 + 0x10;\n\tv724 = ~v740;\n\tif (v724) goto L_00CC;\nL_00E0:\n\tv780 = 0x8909C4(v692, Il2CppClass<Morpeh.IEntity>, v568, v37, v38, v39, v40, v41, v505.ids, v505.world, v44, v45, v46, v47, v48, v49);\n\tgoto L_00E9;\nL_00E3:\n\tv775 = *([v749 @ X11_v25]) + v568;\n\tv776 = v775 << 4;\n\tv777 = v701 + v776;\n\tv780 = v777 + 0x130;\nL_00E9:\n\tv784 = Morpeh.IEntity::GetComponent(*([v780 @ X0_v48+8]));\n\t*([v784 @ X0_v50 (GBG.Pinata.ECS.Components.UICanvasComponent&)])(v792, v692, v784, v568, v37, v38, v39, v40, v41, v505.ids, v505.world, v44, v45, v46, v47, v48, v49);\n\tv795 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.ShowMainMenu);\n\tv807 = v795 == 0;\n\tif (v807) goto L_00FA;\n\tUIActiveWindowSystem::SetActive(v795, *([v792 @ X0_v52]));\nL_00FA:\n\tv816 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.ShowWinScreen);\n\tv847 = v816 == 0;\n\tif (v847) goto L_0103;\n\tUIActiveWindowSystem::SetActive(v816, *([v792 @ X0_v52+8]));\n\tgoto L_010B;\nL_0103:\n\tv872 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.ShowLoseScreen);\n\tv886 = v872 == 0;\n\tif (v886) goto L_010B;\n\tUIActiveWindowSystem::SetActive(v872, *([v792 @ X0_v52+10]));\nL_010B:\n\tv649 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.ShowNoInternet);\n\tv651 = v649 == 0;\n\tif (v651) goto L_00B6;\n\tUIActiveWindowSystem::SetActive(v649, *([v792 @ X0_v52+18]));\n\tgoto L_00B6;\nL_0114:\n\tv695 = 0x15F7664(&v547 @ stack_-A0_v5 (Morpeh.World), 0, v568, v37, v38, v39, v40, v41, v505.ids, v505.world, v44, v45, v46, v47, v48, v49);\n\tgoto L_0137;\n\tthrow System.NullReferenceException;\nL_0118:\n\tv599 = new System.NullReferenceException();\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\nL_012C:\n\tv435 = v570 != 1;\n\tif (v435) goto L_0206;\n\tv696 = 0x6D2BC0(v599, v570, v567, v37, v38, v39, v40, v41, 0, v90, v44, v45, v46, v47, v48, v49);\n\tv706 = 0x6D2490(v696, v570, v567, v37, v38, v39, v40, v41, 0, v90, v44, v45, v46, v47, v48, v49);\n\tv710 = 0x15F7664(&v391 @ stack_-80_v5 (Morpeh.World), 0, v567, v37, v38, v39, v40, v41, 0, v90, v44, v45, v46, v47, v48, v49);\n\tv770 = *([v696 @ X0_v34]) == 0;\n\tv711 = ~v770;\n\tif (v711) goto L_020A;\nL_0137:\n\tv799 = this.filterWeaponButtonInitialized;\n\tv340 = v799.Length < 1;\n\tif (v340) goto L_0205;\nL_014E:\n\tv801 = v799.world;\n\tv154 = v801.Entities;\n\tv309 = v154[v802[v190 @ X22_v7 (System.Int32)]];\n\tv171 = Il2CppMethodInfo;\n\tv808 = *([v309 @ X20_v7 (Morpeh.Entity)]);\n\tv811 = *([v808 @ X8_v15 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v811) goto L_017C;\n\tv850 = *([v808 @ X8_v15 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0163:\n\t;\n\tv864 = *([v850 @ X11_v15-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v864) goto L_017E;\n\tv849 = v849 + 1;\n\tv873 = v849 < *([v808 @ X8_v15 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv843 = ~v873;\n\tv850 = v850 + 0x10;\n\tv827 = ~v843;\n\tif (v827) goto L_0163;\nL_017C:\n\tv880 = 0x8909C4(v154[v802[v190 @ X22_v7 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v171 @ X21_v6 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v88, v505.world, v44, v45, v46, v47, v48, v49);\n\tgoto L_0183;\nL_017E:\n\t;\n\tv875 = *([v850 @ X11_v15]) + *([v171 @ X21_v6 (Il2CppMethodInfo)+48]);\n\tv876 = v875 << 4;\n\tv877 = v808 + v876;\n\tv880 = v877 + 0x130;\nL_0183:\n\t;\n\tv884 = Morpeh.IEntity::GetComponent(*([v880 @ X0_v9+8]));\n\t*([v884 @ X0_v11 (ActivateGameObjectComponent&)])(v280, v154[v802[v190 @ X22_v7 (System.Int32)]], v884, *([v171 @ X21_v6 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v88, v505.world, v44, v45, v46, v47, v48, v49);\n\tv300 = this.filterWeaponButtonInitialized;\n\tv894 = v300.world;\n\tv156 = v894.Entities;\n\tv172 = v156[v895[v190 @ X22_v7 (System.Int32)]];\n\tv191 = Il2CppMethodInfo;\n\tv900 = *([v172 @ X21_v7 (Morpeh.Entity)]);\n\tv903 = *([v900 @ X8_v23 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v903) goto L_01BE;\n\tv935 = *([v900 @ X8_v23 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_01A5:\n\t;\n\tv949 = *([v935 @ X11_v10-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v949) goto L_01C0;\n\tv934 = v934 + 1;\n\tv954 = v934 < *([v900 @ X8_v23 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv930 = ~v954;\n\tv935 = v935 + 0x10;\n\tv914 = ~v930;\n\tif (v914) goto L_01A5;\nL_01BE:\n\tv961 = 0x8909C4(v156[v895[v190 @ X22_v7 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v191 @ X22_v8 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v88, v505.world, v44, v45, v46, v47, v48, v49);\n\tgoto L_01C5;\nL_01C0:\n\t;\n\tv956 = *([v935 @ X11_v10]) + *([v191 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv957 = v956 << 4;\n\tv958 = v900 + v957;\n\tv961 = v958 + 0x130;\nL_01C5:\n\t;\n\tv965 = Morpeh.IEntity::GetComponent(*([v961 @ X0_v14+8]));\n\t*([v965 @ X0_v16 (WeaponButtonComponent&)])(v281, v156[v895[v190 @ X22_v7 (System.Int32)]], v965, *([v191 @ X22_v8 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v88, v505.world, v44, v45, v46, v47, v48, v49);\n\tv302 = this.config;\n\tv274 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v302.Weapon);\n\tv979 = *([v281 @ X0_v18+78]) != v274;\n\tif (v979) goto L_FFFFFFFF;\n\tgoto L_01E6;\nL_01E6:\n\tUIActiveWindowSystem::SetActive(v274, *([v280 @ X0_v13+8]), v141);\n\tv190 = v190 + 1;\n\tv193 = v190 >= v799.Length;\n\tif (v193) goto L_0205;\n\tv799 = this.filterWeaponButtonInitialized;\n\tv983 = this.filterWeaponButtonInitialized == 0;\n\tv283 = ~v983;\n\tif (v283) goto L_014E;\nL_01F8:\n\tthrow System.NullReferenceException;\nL_0205:\n\treturn;\nL_0206:\n\tv697 = 0x6D2380(v599, v570, v567, v37, v38, \n// ... truncated")]
	public override void OnUpdate(float deltaTime)
	{
		//IL_007f: Expected I, but got O
		//IL_008f: Expected O, but got I
		//IL_0297: Expected O, but got I
		//IL_0895: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_0914: Expected O, but got I
		//IL_02d2: Expected O, but got I
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_016e: Expected O, but got I
		//IL_017d: Expected O, but got I
		//IL_0564: Expected I, but got O
		//IL_01c1: Expected O, but got I
		//IL_01c1: Expected O, but got I4
		//IL_0116: Expected O, but got I
		//IL_0397: Expected O, but got I4
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_0376: Expected O, but got I
		//IL_0385: Expected O, but got I
		//IL_09be: Expected O, but got I
		//IL_05a2: Expected O, but got I
		//IL_03dd: Expected O, but got I
		//IL_03dd: Expected O, but got I4
		//IL_031e: Expected O, but got I
		//IL_0423: Expected O, but got I
		//IL_0423: Expected O, but got I4
		//IL_06a9: Expected I, but got O
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Expected O, but got Unknown
		//IL_064e: Expected O, but got I
		//IL_065d: Expected O, but got I
		//IL_0469: Expected O, but got I
		//IL_0469: Expected O, but got I4
		//IL_05ee: Expected O, but got I
		//IL_0a11: Expected O, but got I
		//IL_06e7: Expected O, but got I
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		//IL_0776: Expected O, but got Unknown
		//IL_0793: Expected O, but got I
		//IL_07a2: Expected O, but got I
		//IL_0a48: Expected O, but got I
		//IL_0a48: Expected O, but got I4
		//IL_0733: Expected O, but got I
		Filter filter = filterA;
		if (filter.Length >= 1)
		{
			Initialize();
		}
		Filter filter2 = filterB;
		if (filter2.Length >= 1)
		{
			int num = 0;
			int[] array = default(int[]);
			object obj6 = default(object);
			while (true)
			{
				World world = filter2.world;
				Entity[] entities = world.Entities;
				Entity entity = entities[array[num]];
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)entity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X21_v15 (Il2CppMethodInfo)+48]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_012f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj2 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ X11_v32-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]");
					bool flag = (long)num3 < 0L;
					bool flag2 = !flag;
					obj2 = (long)(IntPtr)obj2 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_012f;
				}
				object obj3 = obj2 + (long)(IntPtr)obj;
				int num4 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr2 + (long)num4;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_0884;
				IL_0884:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ X0_v66+8]");
				ref ActivateGameObjectComponent component = ref ((IEntity)0).GetComponent<ActivateGameObjectComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v691 @ X0_v68 (ActivateGameObjectComponent&)] (should have been resolved before IL gen)");
				bool isPublished = ((BaseGlobalEvent<int>)obj6).IsPublished;
				if (isPublished)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ X0_v70+8]");
					((UIActiveWindowSystem)isPublished).SetActive((CanvasGroup)0);
				}
				num++;
				if (num >= filter2.Length)
				{
					break;
				}
				filter2 = filterB;
				if (filterB != null)
				{
					continue;
				}
				goto IL_0832;
				IL_012f:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0884;
			}
		}
		Filter.EntityEnumerator enumerator = filterMainMenu.GetEnumerator();
		World world2 = enumerator.world;
		object obj7 = default(object);
		object obj8 = default(object);
		object obj14 = default(object);
		object obj15 = default(object);
		object active = default(object);
		while (true)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
			int[] array2;
			if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
			{
				bool flag3 = obj8 == null;
				World world3 = null;
				array2 = null;
				if (!flag3)
				{
					IntPtr intPtr3 = (IntPtr)0;
					object obj9 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ X21_v13 (Il2CppMethodInfo)+48]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ X8_v36+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0337;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ X8_v36+B0]");
					object obj10 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ X11_v25-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ X8_v36+126]");
						bool flag4 = (long)num6 < 0L;
						bool flag5 = !flag4;
						obj10 = (long)(IntPtr)obj10 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_0337;
					}
					object obj11 = obj10 + (long)(IntPtr)obj;
					int num7 = (int)((long)(IntPtr)obj11 << 4);
					object obj12 = (long)(IntPtr)obj9 + (long)num7;
					object obj13 = (long)(IntPtr)obj12 + 304L;
					goto IL_0903;
				}
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)obj14 == (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
					if (obj15 == null)
					{
						break;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				}
				throw new TypeLoadException();
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
			array2 = enumerator.ids;
			break;
			IL_0903:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X0_v48+8]");
			ref UICanvasComponent component2 = ref ((IEntity)0).GetComponent<UICanvasComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v784 @ X0_v50 (GBG.Pinata.ECS.Components.UICanvasComponent&)] (should have been resolved before IL gen)");
			bool flag6 = ShowMainMenu;
			if (flag6)
			{
				((UIActiveWindowSystem)flag6).SetActive((CanvasGroup)active);
			}
			bool flag7 = ShowWinScreen;
			if (flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X0_v52+8]");
				((UIActiveWindowSystem)flag7).SetActive((CanvasGroup)0);
			}
			else
			{
				bool flag8 = ShowLoseScreen;
				if (flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X0_v52+10]");
					((UIActiveWindowSystem)flag8).SetActive((CanvasGroup)0);
				}
			}
			bool flag9 = ShowNoInternet;
			if (flag9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X0_v52+18]");
				((UIActiveWindowSystem)flag9).SetActive((CanvasGroup)0);
			}
			continue;
			IL_0337:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0903;
		}
		Filter filter3 = filterWeaponButtonInitialized;
		if (filter3.Length < 1)
		{
			return;
		}
		int num8 = 0;
		int[] array3 = default(int[]);
		int[] array4 = default(int[]);
		do
		{
			World world4 = filter3.world;
			Entity[] entities2 = world4.Entities;
			Entity entity2 = entities2[array3[num8]];
			IntPtr intPtr4 = (IntPtr)0;
			IntPtr intPtr5 = (IntPtr)entity2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ X8_v15 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0607;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ X8_v15 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj16 = 0L + 8L;
			int num9 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v850 @ X11_v15-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num9++;
				int num10 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ X8_v15 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag10 = (long)num10 < 0L;
				bool flag11 = !flag10;
				obj16 = (long)(IntPtr)obj16 + 16L;
				if (!flag11)
				{
					continue;
				}
				goto IL_0607;
			}
			object obj17 = obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X21_v6 (Il2CppMethodInfo)+48]");
			object obj18 = obj17 + 0;
			int num11 = (int)((long)(IntPtr)obj18 << 4);
			object obj19 = (long)intPtr5 + (long)num11;
			object obj20 = (long)(IntPtr)obj19 + 304L;
			goto IL_09ac;
			IL_09ac:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v880 @ X0_v9+8]");
			ref ActivateGameObjectComponent component3 = ref ((IEntity)0).GetComponent<ActivateGameObjectComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v884 @ X0_v11 (ActivateGameObjectComponent&)] (should have been resolved before IL gen)");
			Filter filter4 = filterWeaponButtonInitialized;
			World world5 = filter4.world;
			Entity[] entities3 = world5.Entities;
			Entity entity3 = entities3[array4[num8]];
			IntPtr intPtr6 = (IntPtr)0;
			IntPtr intPtr7 = (IntPtr)entity3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ X8_v23 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_074c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ X8_v23 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj21 = 0L + 8L;
			int num12 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ X11_v10-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num12++;
				int num13 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ X8_v23 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag12 = (long)num13 < 0L;
				bool flag13 = !flag12;
				obj21 = (long)(IntPtr)obj21 + 16L;
				if (!flag13)
				{
					continue;
				}
				goto IL_074c;
			}
			object obj22 = obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X22_v8 (Il2CppMethodInfo)+48]");
			object obj23 = obj22 + 0;
			int num14 = (int)((long)(IntPtr)obj23 << 4);
			object obj24 = (long)intPtr7 + (long)num14;
			object obj25 = (long)(IntPtr)obj24 + 304L;
			goto IL_09ff;
			IL_09ff:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ X0_v14+8]");
			ref WeaponButtonComponent component4 = ref ((IEntity)0).GetComponent<WeaponButtonComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v965 @ X0_v16 (WeaponButtonComponent&)] (should have been resolved before IL gen)");
			GameConfig gameConfig = config;
			int value = ((BaseGlobalVariable<int>)gameConfig.Weapon).Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X0_v18+78]");
			bool setActive = (((IntPtr)0 == (IntPtr)value) ? true : false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X0_v13+8]");
			((UIActiveWindowSystem)value).SetActive((CanvasGroup)0, setActive);
			num8++;
			if (num8 < filter3.Length)
			{
				filter3 = filterWeaponButtonInitialized;
				continue;
			}
			return;
			IL_074c:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_09ff;
			IL_0607:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_09ac;
		}
		while (filterWeaponButtonInitialized != null);
		goto IL_0832;
		IL_0832:
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000048")]
	[Address(RVA = "0xCCB8C0", Offset = "0xCCB8C0", Length = "0x410")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EEAE60]);\n\tv35 = *([v34 @ X8_v57]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202379B]) = v54;\nL_001B:\n\tv375 = this.filterA;\n\tv68 = v375.Length < 1;\n\tif (v68) goto L_00C7;\nL_0030:\n\tv377 = v375.world;\n\tv127 = v377.Entities;\n\tv325 = v127[v378[v160 @ X25_v9 (System.Int32)]];\n\tv150 = Il2CppMethodInfo;\n\tv435 = *([v325 @ X20_v11 (Morpeh.Entity)]);\n\tv439 = *([v435 @ X8_v41 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v439) goto L_005E;\n\tv486 = *([v435 @ X8_v41 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_004A:\n\tv500 = *([v486 @ X11_v29-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v500) goto L_0061;\n\tv485 = v485 + 1;\n\tv509 = v485 < *([v435 @ X8_v41 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv471 = ~v509;\n\tv486 = v486 + 0x10;\n\tv455 = ~v471;\n\tif (v455) goto L_004A;\nL_005E:\n\tv516 = 0x8909C4(v127[v378[v160 @ X25_v9 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v150 @ X21_v13 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0067;\nL_0061:\n\tv511 = *([v486 @ X11_v29]) + *([v150 @ X21_v13 (Il2CppMethodInfo)+48]);\n\tv512 = v511 << 4;\n\tv513 = v435 + v512;\n\tv516 = v513 + 0x130;\nL_0067:\n\tv520 = Morpeh.IEntity::GetComponent(*([v516 @ X0_v33+8]));\n\t*([v520 @ X0_v35 (ActivateGameObjectComponent&)])(v289, v127[v378[v160 @ X25_v9 (System.Int32)]], v520, *([v150 @ X21_v13 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv554 = v289.filter == 0;\n\tif (v554) goto L_FFFFFFFF;\n\tgoto L_0074;\nL_0074:\n\tUIActiveWindowSystem::SetActive(v289, *([v289 @ X0_v37 (UIActiveWindowSystem)+8]), v119);\n\tv313 = this.filterA;\n\tv597 = v313.world;\n\tv129 = v597.Entities;\n\tv326 = v129[v598[v160 @ X25_v9 (System.Int32)]];\n\tv151 = Il2CppMethodInfo;\n\tv606 = *([v326 @ X20_v12 (Morpeh.Entity)]);\n\tv334 = *([v606 @ X8_v50 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v334) goto L_00A7;\n\tv690 = *([v606 @ X8_v50 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0093:\n\tv704 = *([v690 @ X11_v24-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v704) goto L_00AA;\n\tv689 = v689 + 1;\n\tv721 = v689 < *([v606 @ X8_v50 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv664 = ~v721;\n\tv690 = v690 + 0x10;\n\tv648 = ~v664;\n\tif (v648) goto L_0093;\nL_00A7:\n\tv737 = 0x8909C4(v129[v598[v160 @ X25_v9 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v151 @ X21_v14 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00B0;\nL_00AA:\n\tv723 = *([v690 @ X11_v24]) + *([v151 @ X21_v14 (Il2CppMethodInfo)+48]);\n\tv724 = v723 << 4;\n\tv725 = v606 + v724;\n\tv737 = v725 + 0x130;\nL_00B0:\n\tv741 = Morpeh.IEntity::AddComponent(*([v737 @ X0_v38+8]));\n\t*([v741 @ X0_v40 (InitializeMarker&)])(v290, v129[v598[v160 @ X25_v9 (System.Int32)]], v741, *([v151 @ X21_v14 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv160 = v160 + 1;\n\tv176 = v160 >= v375.Length;\n\tif (v176) goto L_00C7;\n\tv375 = this.filterA;\n\tv746 = this.filterA == 0;\n\tv302 = ~v746;\n\tif (v302) goto L_0030;\n\tgoto L_01AC;\nL_00C7:\n\tv477 = this.filterWeaponButtonUninitialized;\n\tv392 = v477.Length < 1;\n\tif (v392) goto L_01BA;\nL_00E0:\n\tv479 = v477.world;\n\tv132 = v479.Entities;\n\tv328 = v132[v480[v282 @ X22_v7 (System.Int32)]];\n\tv154 = Il2CppMethodInfo;\n\tv505 = *([v328 @ X20_v8 (Morpeh.Entity)]);\n\tv508 = *([v505 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v508) goto L_010E;\n\tv557 = *([v505 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00FA:\n\tv571 = *([v557 @ X11_v16-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v571) goto L_0111;\n\tv556 = v556 + 1;\n\tv578 = v556 < *([v505 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv547 = ~v578;\n\tv557 = v557 + 0x10;\n\tv531 = ~v547;\n\tif (v531) goto L_00FA;\nL_010E:\n\tv585 = 0x8909C4(v132[v480[v282 @ X22_v7 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v154 @ X21_v7 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0117;\nL_0111:\n\tv580 = *([v557 @ X11_v16]) + *([v154 @ X21_v7 (Il2CppMethodInfo)+48]);\n\tv581 = v580 << 4;\n\tv582 = v505 + v581;\n\tv585 = v582 + 0x130;\nL_0117:\n\tv589 = Morpeh.IEntity::GetComponent(*([v585 @ X0_v9+8]));\n\t*([v589 @ X0_v11 (ActivateGameObjectComponent&)])(v293, v132[v480[v282 @ X22_v7 (System.Int32)]], v589, *([v154 @ X21_v7 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv318 = this.filterWeaponButtonUninitialized;\n\tv592 = v318.world;\n\tv134 = v592.Entities;\n\tv155 = v134[v593[v282 @ X22_v7 (System.Int32)]];\n\tv283 = Il2CppMethodInfo;\n\tv602 = *([v155 @ X21_v8 (Morpeh.Entity)]);\n\tv605 = *([v602 @ X8_v22 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v605) goto L_0150;\n\tv669 = *([v602 @ X8_v22 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_013C:\n\tv683 = *([v669 @ X11_v11-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v683) goto L_0153;\n\tv668 = v668 + 1;\n\tv709 = v668 < *([v602 @ X8_v22 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv635 = ~v709;\n\tv669 = v669 + 0x10;\n\tv619 = ~v635;\n\tif (v619) goto L_013C;\nL_0150:\n\tv716 = 0x8909C4(v134[v593[v282 @ X22_v7 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v283 @ X22_v8 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0159;\nL_0153:\n\tv711 = *([v669 @ X11_v11]) + *([v283 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv712 = v711 << 4;\n\tv713 = v602 + v712;\n\tv716 = v713 + 0x130;\nL_0159:\n\tv720 = Morpeh.IEntity::GetComponent(*([v716 @ X0_v14+8]));\n\t*([v720 @ X0_v16 (WeaponButtonComponent&)])(v294, v134[v593[v282 @ X22_v7 (System.Int32)]], v720, *([v283 @ X22_v8 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv320 = this.config;\n\tv295 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v320.Weapon);\n\tv181 = *([v294 @ X0_v18+78]) != v295;\n\tif (v181) goto L_019B;\n\tv321 = this.config;\n\tv364 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v321.Weapon.Data);\n\tv765 = *([v364 @ X0_v23 (GBG.Pinata.ECS.WeaponSetup)+18]) < *([v294 @ X0_v18+78]);\n\tv278 = ~v765;\n\tv266 = *([v364 @ X0_v23 (GBG.Pinata.ECS.WeaponSetup)+18]) - *([v294 @ X0_v18+78]);\n\tv242 = v266 == 0;\n\tv766 = ~v242;\n\tv182 = v278 & v766;\n\tif (v182) goto L_0190;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0190:\n\tv96 = *([v294 @ X0_v18+78]) << 3;\n\tv769 = *([v364 @ X0_v23 (GBG.Pinata.ECS.WeaponSetup)+10]) + v96;\n\tv322 = *([v769 @ X8_v31+20]);\n\tv760 = *([v322 @ X8_v32+28]) == 0;\n\tif (v760) goto L_019B;\n\tUIActiveWindowSystem::SetActive(v296, *([v293 @ X0_v13+8]), 1);\nL_019B:\n\tv282 = v282 + 1;\n\tv173 = v282 >= v477.Length;\n\tif (v173) goto L_01BA;\n\tv477 = this.filterWeaponButtonUninitialized;\n\tv763 = this.filterWeaponButtonUninitialized == 0;\n\tv298 = ~v763;\n\tif (v298) goto L_00E0;\nL_01AC:\n\tthrow System.NullReferenceException;\nL_01BA:\n\treturn;\n// 292 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Initialize()
	{
		//IL_0043: Expected I, but got O
		//IL_0320: Expected I, but got O
		//IL_077f: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_08b6: Expected O, but got I
		//IL_035b: Expected O, but got I
		//IL_07c8: Expected O, but got I
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0129: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_0461: Expected I, but got O
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_0406: Expected O, but got I
		//IL_0415: Expected O, but got I
		//IL_01a0: Expected I, but got O
		//IL_03a7: Expected O, but got I
		//IL_0906: Expected O, but got I
		//IL_049c: Expected O, but got I
		//IL_080a: Expected O, but got I
		//IL_01db: Expected O, but got I
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Expected O, but got Unknown
		//IL_0547: Expected O, but got I
		//IL_0556: Expected O, but got I
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0286: Expected O, but got I
		//IL_0295: Expected O, but got I
		//IL_04e8: Expected O, but got I
		//IL_0227: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_067d: Expected O, but got I
		//IL_068d: Expected O, but got I
		//IL_06d1: Expected O, but got I
		Filter filter = filterA;
		if (filter.Length >= 1)
		{
			int num = 0;
			int[] array = default(int[]);
			UIActiveWindowSystem uIActiveWindowSystem = default(UIActiveWindowSystem);
			int[] array2 = default(int[]);
			while (true)
			{
				World world = filter.world;
				Entity[] entities = world.Entities;
				Entity entity = entities[array[num]];
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)entity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v41 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00e3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v41 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ X11_v29-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v41 (Il2CppClass<Morpeh.Entity>)+126]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X21_v13 (Il2CppMethodInfo)+48]");
				object obj3 = obj2 + 0;
				int num4 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr2 + (long)num4;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_076e;
				IL_076e:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ X0_v33+8]");
				ref ActivateGameObjectComponent component = ref ((IEntity)0).GetComponent<ActivateGameObjectComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v520 @ X0_v35 (ActivateGameObjectComponent&)] (should have been resolved before IL gen)");
				bool setActive = ((uIActiveWindowSystem.Filter != null) ? true : false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X0_v37 (UIActiveWindowSystem)+8]");
				uIActiveWindowSystem.SetActive((CanvasGroup)0, setActive);
				Filter filter2 = filterA;
				World world2 = filter2.world;
				Entity[] entities2 = world2.Entities;
				Entity entity2 = entities2[array2[num]];
				IntPtr intPtr3 = (IntPtr)0;
				IntPtr intPtr4 = (IntPtr)entity2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ X8_v50 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0240;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ X8_v50 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj6 = 0L + 8L;
				int num5 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ X11_v24-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num5++;
					int num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ X8_v50 (Il2CppClass<Morpeh.Entity>)+126]");
					bool flag3 = (long)num6 < 0L;
					bool flag4 = !flag3;
					obj6 = (long)(IntPtr)obj6 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0240;
				}
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X21_v14 (Il2CppMethodInfo)+48]");
				object obj8 = obj7 + 0;
				int num7 = (int)((long)(IntPtr)obj8 << 4);
				object obj9 = (long)intPtr4 + (long)num7;
				object obj10 = (long)(IntPtr)obj9 + 304L;
				goto IL_07f9;
				IL_07f9:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X0_v38+8]");
				ref InitializeMarker reference = ref ((IEntity)0).AddComponent<InitializeMarker>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v741 @ X0_v40 (InitializeMarker&)] (should have been resolved before IL gen)");
				num++;
				if (num >= filter.Length)
				{
					break;
				}
				filter = filterA;
				if (filterA != null)
				{
					continue;
				}
				goto IL_0923;
				IL_0240:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_07f9;
				IL_00e3:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_076e;
			}
		}
		Filter filter3 = filterWeaponButtonUninitialized;
		if (filter3.Length < 1)
		{
			return;
		}
		int num8 = 0;
		int[] array3 = default(int[]);
		int[] array4 = default(int[]);
		do
		{
			World world3 = filter3.world;
			Entity[] entities3 = world3.Entities;
			Entity entity3 = entities3[array3[num8]];
			IntPtr intPtr5 = (IntPtr)0;
			IntPtr intPtr6 = (IntPtr)entity3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_03c0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj11 = 0L + 8L;
			int num9 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ X11_v16-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num9++;
				int num10 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag5 = (long)num10 < 0L;
				bool flag6 = !flag5;
				obj11 = (long)(IntPtr)obj11 + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_03c0;
			}
			object obj12 = obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X21_v7 (Il2CppMethodInfo)+48]");
			object obj13 = obj12 + 0;
			int num11 = (int)((long)(IntPtr)obj13 << 4);
			object obj14 = (long)intPtr6 + (long)num11;
			object obj15 = (long)(IntPtr)obj14 + 304L;
			goto IL_08a5;
			IL_08a5:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ X0_v9+8]");
			ref ActivateGameObjectComponent component2 = ref ((IEntity)0).GetComponent<ActivateGameObjectComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v589 @ X0_v11 (ActivateGameObjectComponent&)] (should have been resolved before IL gen)");
			Filter filter4 = filterWeaponButtonUninitialized;
			World world4 = filter4.world;
			Entity[] entities4 = world4.Entities;
			Entity entity4 = entities4[array4[num8]];
			IntPtr intPtr7 = (IntPtr)0;
			IntPtr intPtr8 = (IntPtr)entity4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X8_v22 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0501;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X8_v22 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj16 = 0L + 8L;
			int num12 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ X11_v11-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num12++;
				int num13 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X8_v22 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag7 = (long)num13 < 0L;
				bool flag8 = !flag7;
				obj16 = (long)(IntPtr)obj16 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_0501;
			}
			object obj17 = obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ X22_v8 (Il2CppMethodInfo)+48]");
			object obj18 = obj17 + 0;
			int num14 = (int)((long)(IntPtr)obj18 << 4);
			object obj19 = (long)intPtr8 + (long)num14;
			object obj20 = (long)(IntPtr)obj19 + 304L;
			goto IL_08f5;
			IL_08f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ X0_v14+8]");
			ref WeaponButtonComponent component3 = ref ((IEntity)0).GetComponent<WeaponButtonComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v720 @ X0_v16 (WeaponButtonComponent&)] (should have been resolved before IL gen)");
			GameConfig gameConfig = config;
			int value = ((BaseGlobalVariable<int>)gameConfig.Weapon).Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X0_v18+78]");
			if ((IntPtr)0 == (IntPtr)value)
			{
				GameConfig gameConfig2 = config;
				WeaponSetup value2 = gameConfig2.Weapon.Data.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X0_v23 (GBG.Pinata.ECS.WeaponSetup)+18]");
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X0_v18+78]");
				bool flag9 = (long)intPtr9 < 0L;
				bool flag10 = !flag9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X0_v23 (GBG.Pinata.ECS.WeaponSetup)+18]");
				IntPtr intPtr10 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X0_v18+78]");
				object obj21 = (long)intPtr10 - 0L;
				bool flag11 = obj21 == null;
				bool flag12 = !flag11;
				bool flag13 = flag10 && flag12;
				UIActiveWindowSystem uIActiveWindowSystem2 = (UIActiveWindowSystem)value2;
				if (!flag13)
				{
					throw new ArgumentOutOfRangeException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X0_v18+78]");
				int num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X0_v23 (GBG.Pinata.ECS.WeaponSetup)+10]");
				object obj22 = 0L + (long)num15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ X8_v31+20]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ X8_v32+28]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ X0_v13+8]");
					uIActiveWindowSystem2.SetActive((CanvasGroup)0, setActive: true);
				}
			}
			num8++;
			if (num8 < filter3.Length)
			{
				filter3 = filterWeaponButtonUninitialized;
				continue;
			}
			return;
			IL_0501:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_08f5;
			IL_03c0:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_08a5;
		}
		while (filterWeaponButtonUninitialized != null);
		goto IL_0923;
		IL_0923:
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000049")]
	[Address(RVA = "0xCCBD5C", Offset = "0xCCBD5C", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = setActive == 0;\n\tv22 = ~v17;\n\tv23 = ~v22;\n\tif (v23) goto L_FFFFFFFF;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.CanvasGroup::set_alpha(canvasGroup, v41);\n\tUnityEngine.CanvasGroup::set_interactable(canvasGroup, setActive);\n\tUnityEngine.CanvasGroup::set_blocksRaycasts(canvasGroup, setActive);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SetActive(CanvasGroup canvasGroup, bool setActive)
	{
		float alpha = ((!setActive) ? 0f : 1f);
		canvasGroup.alpha = alpha;
		canvasGroup.interactable = setActive;
		canvasGroup.blocksRaycasts = setActive;
	}

	[Token(Token = "0x600004A")]
	[Address(RVA = "0xCCBCD0", Offset = "0xCCBCD0", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.CanvasGroup::get_interactable(canvasGroup);\n\tv30 = ~v13;\n\tUnityEngine.CanvasGroup::set_interactable(canvasGroup, v30);\n\tv37 = UnityEngine.CanvasGroup::get_blocksRaycasts(canvasGroup);\n\tv77 = ~v37;\n\tUnityEngine.CanvasGroup::set_blocksRaycasts(canvasGroup, v77);\n\tv82 = UnityEngine.CanvasGroup::get_interactable(canvasGroup);\n\tv55 = v82 == 0;\n\tv42 = ~v55;\n\tv39 = ~v42;\n\tif (v39) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_0031:\n\tUnityEngine.CanvasGroup::set_alpha(canvasGroup, v47);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SetActive(CanvasGroup canvasGroup)
	{
		bool interactable = canvasGroup.interactable;
		bool interactable2 = !interactable;
		canvasGroup.interactable = interactable2;
		bool blocksRaycasts = canvasGroup.blocksRaycasts;
		bool blocksRaycasts2 = !blocksRaycasts;
		canvasGroup.blocksRaycasts = blocksRaycasts2;
		float alpha = ((!canvasGroup.interactable) ? 0f : 1f);
		canvasGroup.alpha = alpha;
	}

	[Token(Token = "0x600004B")]
	[Address(RVA = "0xCCBDC4", Offset = "0xCCBDC4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UIActiveWindowSystem()
	{
	}
}
