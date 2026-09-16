using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using GBG.Pinata.ECS.Components;
using GBG.Pinata.ECS.Markers;
using GBG.Pinata.ECS.Systems;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x200000A")]
public class GameStateSystem : UpdateSystem
{
	[Required]
	[Token(Token = "0x400001B")]
	[FieldOffset(Offset = "0x28")]
	public GlobalEvent BeginTransitionToMenu;

	[Required]
	[Token(Token = "0x400001C")]
	[FieldOffset(Offset = "0x30")]
	public GlobalEvent EndTransitionToMenu;

	[Required]
	[Token(Token = "0x400001D")]
	[FieldOffset(Offset = "0x38")]
	public GlobalEvent TapToPlay;

	[Required]
	[Token(Token = "0x400001E")]
	[FieldOffset(Offset = "0x40")]
	public GlobalEvent ShowMainMenu;

	[Required]
	[Token(Token = "0x400001F")]
	[FieldOffset(Offset = "0x48")]
	public GlobalEvent ShowWinScreen;

	[Required]
	[Token(Token = "0x4000020")]
	[FieldOffset(Offset = "0x50")]
	public GlobalEvent ShowLoseScreen;

	[Required]
	[Token(Token = "0x4000021")]
	[FieldOffset(Offset = "0x58")]
	public GlobalEvent EnemyIsNotDead;

	[Required]
	[Token(Token = "0x4000022")]
	[FieldOffset(Offset = "0x60")]
	public GlobalVariableInt Level;

	[Required]
	[Token(Token = "0x4000023")]
	[FieldOffset(Offset = "0x68")]
	public GlobalVariableInt NextLevel;

	[Required]
	[Token(Token = "0x4000024")]
	[FieldOffset(Offset = "0x70")]
	public GlobalVariableInt CurrentWeaponAmmo;

	[Required]
	[Token(Token = "0x4000025")]
	[FieldOffset(Offset = "0x78")]
	public GlobalVariableInt Coins;

	[Required]
	[Token(Token = "0x4000026")]
	[FieldOffset(Offset = "0x80")]
	public GlobalVariableInt LevelCoinReward;

	[Token(Token = "0x4000027")]
	[FieldOffset(Offset = "0x88")]
	private Filter filter;

	[Token(Token = "0x4000028")]
	[FieldOffset(Offset = "0x90")]
	private Filter filterAttacks;

	[Token(Token = "0x4000029")]
	[FieldOffset(Offset = "0x98")]
	private Filter filterEnemySpawned;

	[Token(Token = "0x400002A")]
	[FieldOffset(Offset = "0xA0")]
	private Filter filterEnemyHook;

	[Token(Token = "0x400002B")]
	[FieldOffset(Offset = "0xA8")]
	private GameConfig config;

	[Token(Token = "0x400002C")]
	[FieldOffset(Offset = "0xB0")]
	private Dictionary<GameStatesEnum, Action> logicAssociation;

	[Token(Token = "0x600000F")]
	[Address(RVA = "0xCC84DC", Offset = "0xCC84DC", Length = "0x21C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1F03AB8]);\n\tv25 = *([v24 @ X8_v30]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023781]) = v44;\nL_001A:\n\tv48 = Morpeh.FilterProvider::get_All(this.filter);\n\tv90 = Morpeh.Filter::With(v48, 1);\n\tthis.filter = v90;\n\tv60 = Morpeh.FilterProvider::get_All(this.filter);\n\tv91 = Morpeh.Filter::With(v60, 1);\n\tthis.filterAttacks = v91;\n\tv61 = Morpeh.FilterProvider::get_All(this.filter);\n\tv62 = Morpeh.Filter::With(v61, 1);\n\tv92 = Morpeh.Filter::With(v62, 1);\n\tthis.filterEnemySpawned = v92;\n\tv63 = Morpeh.FilterProvider::get_All(this.filter);\n\tv144 = Morpeh.Filter::With(v63, 1);\n\tthis.filterEnemyHook = v144;\n\tv145 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v145;\n\tv149 = new System.Collections.Generic.Dictionary`2<GameStatesEnum, System.Action>();\n\tSystem.Collections.Generic.Dictionary`2<GameStatesEnum, System.Action>::.ctor(v149);\n\tv93 = new System.Action();\n\tSystem.Action::.ctor(v93, this, Il2CppMethodInfo);\n\tSystem.Collections.Generic.Dictionary`2<GameStatesEnum, System.Action>::set_Item(v149, 0, v93);\n\tv163 = new System.Action();\n\tSystem.Action::.ctor(v163, this, Il2CppMethodInfo);\n\tSystem.Collections.Generic.Dictionary`2<GameStatesEnum, System.Action>::set_Item(v149, 0xA, v163);\n\tv175 = new System.Action();\n\tSystem.Action::.ctor(v175, this, Il2CppMethodInfo);\n\tSystem.Collections.Generic.Dictionary`2<GameStatesEnum, System.Action>::set_Item(v149, 0x14, v175);\n\tthis.logicAssociation = v149;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<GameStateComponent>();
		this.filter = filter;
		Filter all2 = Filter.All;
		Filter filter2 = all2.With<AttackComponent>();
		filterAttacks = filter2;
		Filter all3 = Filter.All;
		Filter filter3 = all3.With<EnemyComponent>();
		Filter filter4 = filter3.With<EnemySpawnedMarker>();
		filterEnemySpawned = filter4;
		Filter all4 = Filter.All;
		Filter filter5 = all4.With<EnemyHolderComponent>();
		filterEnemyHook = filter5;
		GameConfig instance = GameConfig.Instance;
		config = instance;
		Dictionary<GameStatesEnum, Action> dictionary = new Dictionary<GameStatesEnum, Action>();
		Action value = MenuLogic;
		dictionary.set_Item(default(GameStatesEnum), value);
		Action value2 = PlayingLogic;
		dictionary.set_Item(GameStatesEnum.Playing, value2);
		Action value3 = FinishedLogic;
		dictionary.set_Item(GameStatesEnum.Finished, value3);
		logicAssociation = dictionary;
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0xCC86F8", Offset = "0xCC86F8", Length = "0x158")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ED89F0]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, deltaTime, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023782]) = v48;\nL_0018:\n\tv230 = this.filter;\n\tv62 = v230.Length < 1;\n\tif (v62) goto L_0091;\nL_002D:\n\tv232 = v230.world;\n\tv85 = v232.Entities;\n\tv160 = v85[v233[v96 @ X23_v6 (System.Int32)]];\n\tv92 = Il2CppMethodInfo;\n\tv237 = *([v160 @ X20_v7 (Morpeh.Entity)]);\n\tv240 = *([v237 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v240) goto L_005B;\n\tv272 = *([v237 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0047:\n\tv286 = *([v272 @ X11_v9-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v286) goto L_005E;\n\tv271 = v271 + 1;\n\tv291 = v271 < *([v237 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv267 = ~v291;\n\tv272 = v272 + 0x10;\n\tv251 = ~v267;\n\tif (v251) goto L_0047;\nL_005B:\n\tv298 = 0x8909C4(v85[v233[v96 @ X23_v6 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, *([v92 @ X21_v6 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, deltaTime, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0064;\nL_005E:\n\tv293 = *([v272 @ X11_v9]) + *([v92 @ X21_v6 (Il2CppMethodInfo)+48]);\n\tv294 = v293 << 4;\n\tv295 = v237 + v294;\n\tv298 = v295 + 0x130;\nL_0064:\n\tv302 = Morpeh.IEntity::GetComponent(*([v298 @ X0_v8+8]));\n\t*([v302 @ X0_v10 (GameStateComponent&)])(v150, v85[v233[v96 @ X23_v6 (System.Int32)]], v302, *([v92 @ X21_v6 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, deltaTime, v39, v40, v41, v42, v43, v44, v45);\n\tv148 = System.Collections.Generic.Dictionary`2<GameStatesEnum, System.Action>::get_Item(this.logicAssociation, *([v150 @ X0_v12]));\n\tSystem.Action::Invoke(v148);\n\tv96 = v96 + 1;\n\tv102 = v96 >= v230.Length;\n\tif (v102) goto L_0091;\n\tv230 = this.filter;\n\tv307 = this.filter == 0;\n\tv152 = ~v307;\n\tif (v152) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0091:\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnUpdate(float deltaTime)
	{
		//IL_0043: Expected I, but got O
		//IL_0202: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_0147: Expected I4, but got O
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0124: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_00ca: Expected O, but got I
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X11_v9-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X21_v6 (Il2CppMethodInfo)+48]");
			object obj3 = obj2 + 0;
			int num4 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr2 + (long)num4;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_01f1;
			IL_01f1:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X0_v8+8]");
			ref GameStateComponent component = ref ((IEntity)0).GetComponent<GameStateComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v302 @ X0_v10 (GameStateComponent&)] (should have been resolved before IL gen)");
			Action action = logicAssociation.get_Item((GameStatesEnum)obj6);
			action();
			num++;
			if (num < filter.Length)
			{
				filter = this.filter;
				continue;
			}
			return;
			IL_00e3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01f1;
		}
		while (this.filter != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0xCC8850", Offset = "0xCC8850", Length = "0x3A4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EDBB70]);\n\tv35 = *([v34 @ X8_v41]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023783]) = v54;\nL_001E:\n\tv58 = this.filter;\n\tv59 = this.filter == 0;\n\tif (v59) goto L_017A;\n\tv71 = v58.Length < 1;\n\tif (v71) goto L_0178;\nL_0038:\n\tv328 = this.ShowMainMenu == 0;\n\tif (v328) goto L_017A;\n\tv169 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.ShowMainMenu);\n\tv468 = v169 == 0;\n\tif (v468) goto L_015E;\n\tv174 = this.filter;\n\tv171 = this.filter == 0;\n\tif (v171) goto L_017A;\n\tv484 = v174.world;\n\tv126 = v484.Entities;\n\tv119 = v126[v485[v133 @ X24_v7 (System.Int32)]];\n\tv172 = v126[v485[v133 @ X24_v7 (System.Int32)]] == 0;\n\tif (v172) goto L_017A;\n\tv291 = Il2CppMethodInfo;\n\tv491 = *([v119 @ X21_v8 (Morpeh.Entity)]);\n\tv384 = *([v291 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv494 = *([v491 @ X8_v17 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v494) goto L_0072;\n\tv526 = *([v491 @ X8_v17 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_005E:\n\tv540 = *([v526 @ X11_v30-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v540) goto L_0075;\n\tv525 = v525 + 1;\n\tv545 = v525 < *([v491 @ X8_v17 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv521 = ~v545;\n\tv526 = v526 + 0x10;\n\tv505 = ~v521;\n\tif (v505) goto L_005E;\nL_0072:\n\tv552 = 0x8909C4(v126[v485[v133 @ X24_v7 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, v384, v39, v40, v41, v42, v43, v191, v193, v46, v47, v48, v49, v50, v51);\n\tgoto L_007B;\nL_0075:\n\tv547 = *([v526 @ X11_v30]) + v384;\n\tv548 = v547 << 4;\n\tv549 = v491 + v548;\n\tv552 = v549 + 0x130;\nL_007B:\n\tv556 = Morpeh.IEntity::GetComponent(*([v552 @ X0_v15+8]));\n\t*([v556 @ X0_v17 (GameStateComponent&)])(v558, v126[v485[v133 @ X24_v7 (System.Int32)]], v556, v384, v39, v40, v41, v42, v43, v191, v193, v46, v47, v48, v49, v50, v51);\n\t*([v558 @ X0_v19]) = 0;\n\tv329 = this.filterEnemySpawned == 0;\n\tif (v329) goto L_017A;\n\tv561 = Morpeh.Filter::GetEnumerator(this.filterEnemySpawned);\n\tv375 = v561.world;\nL_0096:\n\tv586 = 0x15F75B8(&v375 @ stack_-A0_v7 (Morpeh.World), 0, v384, v39, v40, v41, v42, v43, v561.ids, v561.world, v46, v47, v48, v49, v50, v51);\n\tv587 = v586 & 1;\n\tv588 = v587 == 0;\n\tif (v588) goto L_0136;\n\tv444 = v589 == 0;\n\tif (v444) goto L_0139;\n\tv590 = Il2CppMethodInfo;\n\tv591 = *([v589 @ stack_-78]);\n\tv595 = *([v591 @ X8_v24+126]) == 0;\n\tif (v595) goto L_00C0;\n\tv629 = *([v591 @ X8_v24+B0]) + 8;\nL_00AC:\n\tv643 = *([v629 @ X11_v25-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v643) goto L_00C3;\n\tv628 = v628 + 1;\n\tv650 = v628 < *([v591 @ X8_v24+126]);\n\tv624 = ~v650;\n\tv629 = v629 + 0x10;\n\tv608 = ~v624;\n\tif (v608) goto L_00AC;\nL_00C0:\n\tv670 = 0x8909C4(v589, Il2CppClass<Morpeh.IEntity>, *([v590 @ X22_v10 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v561.ids, v561.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_00C9;\nL_00C3:\n\tv652 = *([v629 @ X11_v25]) + *([v590 @ X22_v10 (Il2CppMethodInfo)+48]);\n\tv653 = v652 << 4;\n\tv654 = v591 + v653;\n\tv670 = v654 + 0x130;\nL_00C9:\n\tv674 = Morpeh.IEntity::RemoveComponent(*([v670 @ X0_v29+8]));\n\tv674.m_value(v679, v589, v674, *([v590 @ X22_v10 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v561.ids, v561.world, v46, v47, v48, v49, v50, v51);\n\tv680 = Il2CppMethodInfo;\n\tv681 = *([v589 @ stack_-78]);\n\tv685 = *([v681 @ X8_v27+126]) == 0;\n\tif (v685) goto L_00F2;\n\tv717 = *([v681 @ X8_v27+B0]) + 8;\nL_00DE:\n\tv731 = *([v717 @ X11_v20-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v731) goto L_00F5;\n\tv716 = v716 + 1;\n\tv736 = v716 < *([v681 @ X8_v27+126]);\n\tv712 = ~v736;\n\tv717 = v717 + 0x10;\n\tv696 = ~v712;\n\tif (v696) goto L_00DE;\nL_00F2:\n\tv756 = 0x8909C4(v589, Il2CppClass<Morpeh.IEntity>, *([v680 @ X22_v11 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v561.ids, v561.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_00FB;\nL_00F5:\n\tv738 = *([v717 @ X11_v20]) + *([v680 @ X22_v11 (Il2CppMethodInfo)+48]);\n\tv739 = v738 << 4;\n\tv740 = v681 + v739;\n\tv756 = v740 + 0x130;\nL_00FB:\n\tv760 = Morpeh.IEntity::RemoveComponent(*([v756 @ X0_v34+8]));\n\tv760.m_value(v765, v589, v760, *([v680 @ X22_v11 (Il2CppMethodInfo)+48]), v39, v40, v41, v42, v43, v561.ids, v561.world, v46, v47, v48, v49, v50, v51);\n\tv566 = Il2CppMethodInfo;\n\tv768 = *([v589 @ stack_-78]);\n\tv384 = *([v566 @ X22_v12 (Il2CppMethodInfo)+48]);\n\tv583 = *([v768 @ X8_v32+126]) == 0;\n\tif (v583) goto L_0126;\n\tv802 = *([v768 @ X8_v32+B0]) + 8;\nL_0112:\n\tv816 = *([v802 @ X11_v15-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v816) goto L_0129;\n\tv801 = v801 + 1;\n\tv821 = v801 < *([v768 @ X8_v32+126]);\n\tv797 = ~v821;\n\tv802 = v802 + 0x10;\n\tv781 = ~v797;\n\tif (v781) goto L_0112;\nL_0126:\n\tv828 = 0x8909C4(v589, Il2CppClass<Morpeh.IEntity>, v384, v39, v40, v41, v42, v43, v561.ids, v561.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_012F;\nL_0129:\n\tv823 = *([v802 @ X11_v15]) + v384;\n\tv824 = v823 << 4;\n\tv825 = v768 + v824;\n\tv828 = v825 + 0x130;\nL_012F:\n\tv832 = Morpeh.IEntity::RemoveComponent(*([v828 @ X0_v39+8]));\n\tv832.m_value(v581, v589, v832, v384, v39, v40, v41, v42, v43, v561.ids, v561.world, v46, v47, v48, v49, v50, v51);\n\tgoto L_0096;\nL_0136:\n\tv458 = v227 + 1;\n\tgoto L_014F;\nL_0139:\n\tv441 = new System.NullReferenceException();\n\tGameStateSystem::MenuLogic(v441);\n\treturn;\n\tgoto L_013F;\n\tgoto L_013F;\n\tgoto L_013F;\nL_013F:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_017B;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014F:\n\tv464 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(&v375 @ stack_-A0_v7 (Morpeh.World));\n\tv480 = v458 + 1;\n\tv460 = v480 == 0;\n\tif (v460) goto L_015C;\n\tv481 = 0xFFFFFFFF ^ v458;\n\tv227 = v458 + v481;\n\tgoto L_015E;\nL_015C:\n\tgoto L_017F;\nL_015E:\n\tv133 = v133 + 1;\n\tv234 = v133 < v58.Length;\n\tif (v234) goto L_0038;\nL_0178:\n\treturn;\nL_017A:\n\tv334 = new System.NullReferenceException();\nL_017B:\n\tv453 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(v334);\nL_017F:\n\tthrow System.TypeLoadException;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void FinishedLogic()
	{
		//IL_0039: Expected O, but got I8
		//IL_0110: Expected I, but got O
		//IL_0120: Expected O, but got I
		//IL_066d: Expected O, but got I
		//IL_0684: Expected O, but got I4
		//IL_015b: Expected O, but got I
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01fa: Expected O, but got I
		//IL_0209: Expected O, but got I
		//IL_01a7: Expected O, but got I
		//IL_04f7: Expected O, but got I
		//IL_0530: Expected O, but got I
		//IL_0560: Expected I4, but got I8
		//IL_056e: Expected O, but got I
		//IL_06d7: Expected O, but got I
		//IL_0295: Expected O, but got I
		//IL_074b: Expected O, but got I
		//IL_0777: Expected O, but got I
		//IL_0365: Expected O, but got I
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_033b: Expected O, but got I
		//IL_034a: Expected O, but got I
		//IL_02e1: Expected O, but got I
		//IL_07cf: Expected O, but got I
		//IL_0435: Expected O, but got I
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_040b: Expected O, but got I
		//IL_041a: Expected O, but got I
		//IL_03b1: Expected O, but got I
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Expected O, but got Unknown
		//IL_04d4: Expected O, but got I
		//IL_04e3: Expected O, but got I
		//IL_0481: Expected O, but got I
		Filter filter = this.filter;
		if (this.filter != null)
		{
			if (filter.Length < 1)
			{
				return;
			}
			int[] array = null;
			object obj = 4294967295L;
			int num = 0;
			int[] array2 = default(int[]);
			object obj8 = default(object);
			object obj9 = default(object);
			while ((object)ShowMainMenu != null)
			{
				if (!ShowMainMenu.IsPublished)
				{
					goto IL_060b;
				}
				Filter filter2 = this.filter;
				if (this.filter == null)
				{
					break;
				}
				World world = filter2.world;
				Entity[] entities = world.Entities;
				Entity entity = entities[array2[num]];
				if (entities[array2[num]] == null)
				{
					break;
				}
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)entity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ X22_v8 (Il2CppMethodInfo)+48]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ X8_v17 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01c0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ X8_v17 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj3 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ X11_v30-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ X8_v17 (Il2CppClass<Morpeh.Entity>)+126]");
					bool flag = (long)num3 < 0L;
					bool flag2 = !flag;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_01c0;
				}
				object obj4 = obj3 + (long)(IntPtr)obj2;
				int num4 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr2 + (long)num4;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_065c;
				IL_060b:
				num++;
				if (num >= filter.Length)
				{
					return;
				}
				continue;
				IL_01c0:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_065c;
				IL_065c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X0_v15+8]");
				ref GameStateComponent component = ref ((IEntity)0).GetComponent<GameStateComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v556 @ X0_v17 (GameStateComponent&)] (should have been resolved before IL gen)");
				object obj7 = 0;
				if (filterEnemySpawned == null)
				{
					break;
				}
				Filter.EntityEnumerator enumerator = filterEnemySpawned.GetEnumerator();
				World world2 = enumerator.world;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj8 & 1L) == 0)
					{
						break;
					}
					if (obj9 != null)
					{
						IntPtr intPtr3 = (IntPtr)0;
						object obj10 = obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ X8_v24+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_02fa;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ X8_v24+B0]");
						object obj11 = 0L + 8L;
						int num5 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X11_v25-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ X8_v24+126]");
							bool flag3 = (long)num6 < 0L;
							bool flag4 = !flag3;
							obj11 = (long)(IntPtr)obj11 + 16L;
							if (!flag4)
							{
								continue;
							}
							goto IL_02fa;
						}
						object obj12 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ X22_v10 (Il2CppMethodInfo)+48]");
						object obj13 = obj12 + 0;
						int num7 = (int)((long)(IntPtr)obj13 << 4);
						object obj14 = (long)(IntPtr)obj10 + (long)num7;
						object obj15 = (long)(IntPtr)obj14 + 304L;
						goto IL_06c6;
					}
					NullReferenceException ex = new NullReferenceException();
					((GameStateSystem)(object)ex).MenuLogic();
					return;
					IL_06c6:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ X0_v29+8]");
					bool flag5 = ((IEntity)0).RemoveComponent<EnemyDeadMarker>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v674.m_value (System.Boolean) (should have been resolved before IL gen)");
					IntPtr intPtr4 = (IntPtr)0;
					object obj16 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ X8_v27+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_03ca;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ X8_v27+B0]");
					object obj17 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X11_v20-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ X8_v27+126]");
						bool flag6 = (long)num9 < 0L;
						bool flag7 = !flag6;
						obj17 = (long)(IntPtr)obj17 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_03ca;
					}
					object obj18 = obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ X22_v11 (Il2CppMethodInfo)+48]");
					object obj19 = obj18 + 0;
					int num10 = (int)((long)(IntPtr)obj19 << 4);
					object obj20 = (long)(IntPtr)obj16 + (long)num10;
					object obj21 = (long)(IntPtr)obj20 + 304L;
					goto IL_073a;
					IL_049a:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_07be;
					IL_07be:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ X0_v39+8]");
					bool flag8 = ((IEntity)0).RemoveComponent<InitEnemyHealthMarker>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v832.m_value (System.Boolean) (should have been resolved before IL gen)");
					continue;
					IL_03ca:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_073a;
					IL_073a:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ X0_v34+8]");
					bool flag9 = ((IEntity)0).RemoveComponent<EnemySpawnedMarker>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v760.m_value (System.Boolean) (should have been resolved before IL gen)");
					IntPtr intPtr5 = (IntPtr)0;
					object obj22 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ X22_v12 (Il2CppMethodInfo)+48]");
					obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ X8_v32+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ X8_v32+B0]");
						object obj23 = 0L + 8L;
						int num11 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ X11_v15-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num11++;
							int num12 = num11;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ X8_v32+126]");
							bool flag10 = (long)num12 < 0L;
							bool flag11 = !flag10;
							obj23 = (long)(IntPtr)obj23 + 16L;
							if (!flag11)
							{
								continue;
							}
							goto IL_049a;
						}
						object obj24 = obj23 + (long)(IntPtr)obj2;
						int num13 = (int)((long)(IntPtr)obj24 << 4);
						object obj25 = (long)(IntPtr)obj22 + (long)num13;
						object obj26 = (long)(IntPtr)obj25 + 304L;
						goto IL_07be;
					}
					goto IL_049a;
					IL_02fa:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_06c6;
				}
				object obj27 = (long)(IntPtr)obj + 1L;
				bool isPublished = ((BaseGlobalEvent<int>)(object)world2).IsPublished;
				object obj28 = (long)(IntPtr)obj27 + 1L;
				if (obj28 != null)
				{
					int num14 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj27);
					obj = (long)(IntPtr)obj27 + (long)num14;
					array = enumerator.ids;
					World world3 = enumerator.world;
					goto IL_060b;
				}
				goto IL_05c1;
			}
		}
		NullReferenceException ex2 = new NullReferenceException();
		bool isPublished2 = ((BaseGlobalEvent<int>)(object)ex2).IsPublished;
		goto IL_05c1;
		IL_05c1:
		throw new TypeLoadException();
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0xCC8BF4", Offset = "0xCC8BF4", Length = "0x550")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EDA520]);\n\tv29 = *([v28 @ X8_v64]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023784]) = v48;\nL_001B:\n\tv52 = this.filter;\n\tv54 = v52.world;\n\tv55 = v52.entitiesCacheForBags;\n\tv56 = v54.Entities;\n\tv57 = v55[0];\n\tv60 = v56[v57 @ X8_v10 (System.Int32)];\n\tv191 = *([v60 @ X19_v8 (Morpeh.Entity)]);\n\tv136 = Il2CppMethodInfo;\n\tv194 = *([v191 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v194) goto L_004C;\n\tv370 = *([v191 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0038:\n\tv375 = *([v370 @ X11_v35-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v375) goto L_004F;\n\tv369 = v369 + 1;\n\tv380 = v369 < *([v191 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv270 = ~v380;\n\tv370 = v370 + 0x10;\n\tv254 = ~v270;\n\tif (v254) goto L_0038;\nL_004C:\n\tv387 = 0x8909C4(v56[v57 @ X8_v10 (System.Int32)], Il2CppClass<Morpeh.IEntity>, *([v136 @ X21_v7 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, 0, v285, v40, v41, v42, v43, v44, v45);\n\tgoto L_0055;\nL_004F:\n\tv382 = *([v370 @ X11_v35]) + *([v136 @ X21_v7 (Il2CppMethodInfo)+48]);\n\tv383 = v382 << 4;\n\tv384 = v191 + v383;\n\tv387 = v384 + 0x130;\nL_0055:\n\tv391 = Morpeh.IEntity::GetComponent(*([v387 @ X0_v19+8]));\n\t*([v391 @ X0_v21 (GameStateComponent&)])(v153, v56[v57 @ X8_v10 (System.Int32)], v391, *([v136 @ X21_v7 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, 0, v285, v40, v41, v42, v43, v44, v45);\n\tv408 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.LevelCoinReward);\n\tv422 = v408 == 0;\n\tif (v422) goto L_006F;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.LevelCoinReward, 0);\nL_006F:\n\tv429 = *([v153 @ X0_v23+5]) == 0;\n\tif (v429) goto L_0087;\n\tv562 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.Level);\n\tv129 = v562 + 1;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.Level, v129);\n\tv513 = v562 + 2;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.NextLevel, v513);\n\t*([v153 @ X0_v23+5]) = 0;\nL_0087:\n\tv517 = *([v153 @ X0_v23+4]) == 0;\n\tif (v517) goto L_00C0;\n\tv178 = this.filterEnemyHook;\n\tv598 = v178.world;\n\tv599 = v178.entitiesCacheForBags;\n\tv149 = v598.Entities;\n\tv600 = v599[0];\n\tv139 = v149[v600 @ X8_v46 (System.Int32)];\n\tv604 = *([v139 @ X21_v10 (Morpeh.Entity)]);\n\tv200 = Il2CppMethodInfo;\n\tv339 = *([v200 @ X22_v9 (Il2CppMethodInfo)+48]);\n\tv607 = *([v604 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v607) goto L_00BA;\n\tv648 = *([v604 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00A6:\n\tv653 = *([v648 @ X11_v30-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v653) goto L_012E;\n\tv647 = v647 + 1;\n\tv660 = v647 < *([v604 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv630 = ~v660;\n\tv648 = v648 + 0x10;\n\tv614 = ~v630;\n\tif (v614) goto L_00A6;\nL_00BA:\n\tv667 = 0x8909C4(v149[v600 @ X8_v46 (System.Int32)], Il2CppClass<Morpeh.IEntity>, v339, v33, v34, v35, v36, v37, 0, v285, v40, v41, v42, v43, v44, v45);\n\tgoto L_0134;\nL_00C0:\n\tv157 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.TapToPlay);\n\tv589 = v157 == 0;\n\tif (v589) goto L_01FD;\n\tv180 = this.config;\n\tv158 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v180.Weapon.Data);\n\tv181 = this.config;\n\tv159 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v181.Weapon);\n\tv680 = *([v158 @ X0_v31 (GBG.Pinata.ECS.WeaponSetup)+18]) < v159;\n\tv113 = ~v680;\n\tv109 = *([v158 @ X0_v31 (GBG.Pinata.ECS.WeaponSetup)+18]) - v159;\n\tv101 = v109 == 0;\n\tv681 = ~v101;\n\tv81 = v113 & v681;\n\tif (v81) goto L_00EB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00EB:\n\tv144 = v159 << 3;\n\tv708 = *([v158 @ X0_v31 (GBG.Pinata.ECS.WeaponSetup)+10]) + v144;\n\tv182 = *([v708 @ X8_v27+20]);\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.CurrentWeaponAmmo, *([v182 @ X8_v28+2C]));\n\t*([v153 @ X0_v23+4]) = 1;\n\tv183 = this.filterEnemyHook;\n\tv748 = v183.world;\n\tv749 = v183.entitiesCacheForBags;\n\tv150 = v748.Entities;\n\tv750 = v749[0];\n\tv187 = v150[v750 @ X8_v34 (System.Int32)];\n\tv774 = *([v187 @ X19_v10 (Morpeh.Entity)]);\n\tv775 = Il2CppMethodInfo;\n\tv779 = *([v774 @ X8_v36 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v779) goto L_012B;\n\tv833 = *([v774 @ X8_v36 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0117:\n\tv838 = *([v833 @ X11_v17-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v838) goto L_0197;\n\tv832 = v832 + 1;\n\tv843 = v832 < *([v774 @ X8_v36 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv814 = ~v843;\n\tv833 = v833 + 0x10;\n\tv798 = ~v814;\n\tif (v798) goto L_0117;\nL_012B:\n\tv863 = 0x8909C4(v150[v750 @ X8_v34 (System.Int32)], Il2CppClass<Morpeh.IEntity>, *([v775 @ X20_v8 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, 0, v285, v40, v41, v42, v43, v44, v45);\n\tgoto L_019D;\nL_012E:\n\tv662 = *([v648 @ X11_v30]) + v339;\n\tv663 = v662 << 4;\n\tv664 = v604 + v663;\n\tv667 = v664 + 0x130;\nL_0134:\n\tv671 = Morpeh.IEntity::Has(*([v667 @ X0_v53+8]));\n\tv671.m_value(v587, v149[v600 @ X8_v46 (System.Int32)], v671, v339, v33, v34, v35, v36, v37, 0, v285, v40, v41, v42, v43, v44, v45);\n\tv673 = v587 & 1;\n\tv674 = v673 == 0;\n\tv590 = ~v674;\n\tif (v590) goto L_01FD;\n\t*([v153 @ X0_v23]) = 0xA;\n\tv677 = Morpeh.Filter::GetEnumerator(this.filterAttacks);\n\tv310 = v677.world;\n\tgoto L_018D;\nL_0156:\n\tv351 = v712 == 0;\n\tif (v351) goto L_01DB;\n\tv697 = Il2CppMethodInfo;\n\tv715 = *([v712 @ stack_-68]);\n\tv339 = *([v697 @ X21_v12 (Il2CppMethodInfo)+48]);\n\tv703 = *([v715 @ X8_v54+126]) == 0;\n\tif (v703) goto L_017B;\n\tv762 = *([v715 @ X8_v54+B0]) + 8;\nL_0167:\n\tv767 = *([v762 @ X11_v25-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v767) goto L_017E;\n\tv761 = v761 + 1;\n\tv780 = v761 < *([v715 @ X8_v54+126]);\n\tv741 = ~v780;\n\tv762 = v762 + 0x10;\n\tv725 = ~v741;\n\tif (v725) goto L_0167;\nL_017B:\n\tv787 = 0x8909C4(v712, Il2CppClass<Morpeh.IEntity>, v339, v33, v34, v35, v36, v37, v677.ids, v677.world, v40, v41, v42, v43, v44, v45);\n\tgoto L_0184;\nL_017E:\n\tv782 = *([v762 @ X11_v25]) + v339;\n\tv783 = v782 << 4;\n\tv784 = v715 + v783;\n\tv787 = v784 + 0x130;\nL_0184:\n\tv791 = Morpeh.IEntity::GetComponent(*([v787 @ X0_v65+8]));\n\t*([v791 @ X0_v67 (GBG.Pinata.ECS.Components.AttackComponent&)])(v701, v712, v791, v339, v33, v34, v35, v36, v37, v677.ids, v677.world, v40, v41, v42, v43, v44, v45);\n\t*([v701 @ X0_v69+4]) = 0;\nL_018D:\n\tv349 = 0x15F75B8(&v310 @ stack_-90_v4 (Morpeh.World), 0, v339, v33, v34, v35, v36, v37, v677.ids, v677.world, v40, v41, v42, v43, v44, v45);\n\tv709 = v349 & 1;\n\tv710 = v709 == 0;\n\tv555 = ~v710;\n\tif (v555) goto L_0156;\n\tv553 = 0x15F7664(&v310 @ stack_-90_v4 (Morpeh.World), 0, v339, v33, v34, v35, v36, v37, v677.ids, v677.world, v40, v41, v42, v43, v44, v45);\n\tgoto L_01F2;\nL_0197:\n\tv845 = *([v833 @ X11_v17]) + *([v775 @ X20_v8 (Il2CppMethodInfo)+48]);\n\tv846 = v845 << 4;\n\tv847 = v774 + v846;\n\tv863 = v847 + 0x130;\nL_019D:\n\tv867 = Morpeh.IEntity::RemoveComponent(*([v863 @ X0_v36+8]));\n\tv867.m_value(v872, v150[v750 @ X8_v34 (System.Int32)], v867, *([v775 @ X20_v8 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, 0, v285, v40, v41, v42, v43, v44, v45);\n\tv875 = *([v187 @ X19_v10 (Morpeh.Entity)]);\n\tv593 = Il2CppMethodInfo;\n\tv591 = *([v875 @ X8_v39 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v591) goto L_01C8;\n\tv918 = *([v875 @ X8_v39 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_01B4:\n\tv923 = *([v918 @ X11_v12-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v923) goto L_01CB;\n\tv917 = v917 + 1;\n\tv928 = v917 < *([v875 @ X8_v39 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv900 = ~v928;\n\tv918 = v918 + 0x10;\n\tv884 = ~v900;\n\tif (v884) goto L_01B4;\nL_01C8:\n\tv935 = 0x8909C4(v150[v750 @ X8_v34 (System.Int32)], Il2CppClass<Morpeh.IEntity>, *([v593 @ X20_v9 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, 0, v285, v40, v41, v42, v43, v44, v45);\n\tgoto L_01D1;\nL_01CB:\n\tv930 = *([v918 @ X11_v12]) + *([v593 @ X20_v9 (Il2CppMethodInfo)+48]);\n\tv931 = v930 << 4;\n\tv932 = v875 + v931;\n\tv935 = v932 + 0x130;\nL_01D1:\n\tv939 = Morpeh.IEntity::AddComponent(*([v935 @ X0_v41+8]));\n\t*([v939 @ X0_v43 (GBG.Pinata.ECS.Markers.EnemyMoveDownMarker&)])(v588, v150[v750 @ X8_v34 (System.Int32)], v939, *([v593 @ X20_v9 (Il2CppMethodInfo)+48]), v33, v34\n// ... truncated")]
	private void MenuLogic()
	{
		//IL_005c: Expected I, but got O
		//IL_093b: Expected O, but got I
		//IL_009d: Expected O, but got I
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0143: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_027c: Expected I, but got O
		//IL_0292: Expected O, but got I
		//IL_09a6: Expected O, but got I
		//IL_02cd: Expected O, but got I
		//IL_0452: Expected O, but got I
		//IL_0462: Expected O, but got I
		//IL_05e7: Expected O, but got I4
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected O, but got Unknown
		//IL_05ca: Expected O, but got I
		//IL_05d9: Expected O, but got I
		//IL_0319: Expected O, but got I
		//IL_04ea: Expected I, but got O
		//IL_0a1f: Expected O, but got I
		//IL_0a35: Expected I, but got O
		//IL_052b: Expected O, but got I
		//IL_064d: Expected O, but got I
		//IL_0b20: Expected O, but got I
		//IL_07a6: Expected O, but got I
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		//IL_077c: Expected O, but got I
		//IL_078b: Expected O, but got I
		//IL_0577: Expected O, but got I
		//IL_0ad4: Expected O, but got I
		//IL_0688: Expected O, but got I
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_082f: Expected O, but got Unknown
		//IL_084c: Expected O, but got I
		//IL_085b: Expected O, but got I
		//IL_07f2: Expected O, but got I
		//IL_0705: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Expected O, but got Unknown
		//IL_0727: Expected O, but got I
		//IL_0736: Expected O, but got I
		//IL_06d4: Expected O, but got I
		Filter filter = this.filter;
		World world = filter.world;
		int[] entitiesCacheForBags = filter.entitiesCacheForBags;
		Entity[] entities = world.Entities;
		int num = entitiesCacheForBags[0];
		Entity entity = entities[num];
		IntPtr intPtr = (IntPtr)entity;
		IntPtr intPtr2 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_0102;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+B0]");
		object obj = 0L + 8L;
		int num2 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ X11_v35-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num2++;
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v12 (Il2CppClass<Morpeh.Entity>)+126]");
			bool flag = (long)num3 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_0102;
		}
		object obj2 = obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X21_v7 (Il2CppMethodInfo)+48]");
		object obj3 = obj2 + 0;
		int num4 = (int)((long)(IntPtr)obj3 << 4);
		object obj4 = (long)intPtr + (long)num4;
		object obj5 = (long)(IntPtr)obj4 + 304L;
		goto IL_092a;
		IL_0590:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
		goto IL_0a0e;
		IL_0a0e:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v863 @ X0_v36+8]");
		bool flag3 = ((IEntity)0).RemoveComponent<EnemyMoveUpMarker>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v867.m_value (System.Boolean) (should have been resolved before IL gen)");
		Entity entity2;
		IntPtr intPtr3 = (IntPtr)entity2;
		IntPtr intPtr4 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v875 @ X8_v39 (Il2CppClass<Morpeh.Entity>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_080b;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v875 @ X8_v39 (Il2CppClass<Morpeh.Entity>)+B0]");
		object obj6 = 0L + 8L;
		int num5 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v918 @ X11_v12-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num5++;
			int num6 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v875 @ X8_v39 (Il2CppClass<Morpeh.Entity>)+126]");
			bool flag4 = (long)num6 < 0L;
			bool flag5 = !flag4;
			obj6 = (long)(IntPtr)obj6 + 16L;
			if (!flag5)
			{
				continue;
			}
			goto IL_080b;
		}
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ X20_v9 (Il2CppMethodInfo)+48]");
		object obj8 = obj7 + 0;
		int num7 = (int)((long)(IntPtr)obj8 << 4);
		object obj9 = (long)intPtr3 + (long)num7;
		object obj10 = (long)(IntPtr)obj9 + 304L;
		goto IL_0b0f;
		IL_0332:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
		goto IL_0995;
		IL_0995:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v667 @ X0_v53+8]");
		bool flag6 = ((IEntity)0).Has<EnemyMoveDownMarker>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v671.m_value (System.Boolean) (should have been resolved before IL gen)");
		object obj11 = default(object);
		if ((uint)((ulong)(long)(IntPtr)obj11 & 1uL) != 0)
		{
			return;
		}
		object obj12 = 10;
		World world2 = filterAttacks.GetEnumerator().world;
		object obj13 = default(object);
		object obj14 = default(object);
		object obj21 = default(object);
		object obj22 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
			if ((uint)((ulong)(long)(IntPtr)obj13 & 1uL) != 0)
			{
				bool flag7 = obj14 == null;
				World world3 = null;
				if (!flag7)
				{
					IntPtr intPtr5 = (IntPtr)0;
					object obj15 = obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ X21_v12 (Il2CppMethodInfo)+48]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ X8_v54+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_06ed;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ X8_v54+B0]");
					object obj17 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ X11_v25-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ X8_v54+126]");
						bool flag8 = (long)num9 < 0L;
						bool flag9 = !flag8;
						obj17 = (long)(IntPtr)obj17 + 16L;
						if (!flag9)
						{
							continue;
						}
						goto IL_06ed;
					}
					object obj18 = obj17 + (long)(IntPtr)obj16;
					int num10 = (int)((long)(IntPtr)obj18 << 4);
					object obj19 = (long)(IntPtr)obj15 + (long)num10;
					object obj20 = (long)(IntPtr)obj19 + 304L;
					goto IL_0ac3;
				}
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)obj21 != (IntPtr)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				if (obj22 != null)
				{
					break;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
			}
			_ = 0;
			return;
			IL_0ac3:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ X0_v65+8]");
			ref AttackComponent component = ref ((IEntity)0).GetComponent<AttackComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v791 @ X0_v67 (GBG.Pinata.ECS.Components.AttackComponent&)] (should have been resolved before IL gen)");
			_ = 0;
			continue;
			IL_06ed:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0ac3;
		}
		throw new TypeLoadException();
		IL_0102:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
		goto IL_092a;
		IL_092a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X0_v19+8]");
		ref GameStateComponent component2 = ref ((IEntity)0).GetComponent<GameStateComponent>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v391 @ X0_v21 (GameStateComponent&)] (should have been resolved before IL gen)");
		if (LevelCoinReward.Value != 0)
		{
			LevelCoinReward.Value = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X0_v23+5]");
		if ((IntPtr)0 != (IntPtr)0)
		{
			int value = Level.Value;
			int value2 = value + 1;
			Level.Value = value2;
			int value3 = value + 2;
			NextLevel.Value = value3;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X0_v23+4]");
		if ((IntPtr)0 != (IntPtr)0)
		{
			Filter filter2 = filterEnemyHook;
			World world4 = filter2.world;
			int[] entitiesCacheForBags2 = filter2.entitiesCacheForBags;
			Entity[] entities2 = world4.Entities;
			int num11 = entitiesCacheForBags2[0];
			Entity entity3 = entities2[num11];
			IntPtr intPtr6 = (IntPtr)entity3;
			IntPtr intPtr7 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ X22_v9 (Il2CppMethodInfo)+48]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0332;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj23 = 0L + 8L;
			int num12 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ X11_v30-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num12++;
				int num13 = num12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ X8_v48 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag10 = (long)num13 < 0L;
				bool flag11 = !flag10;
				obj23 = (long)(IntPtr)obj23 + 16L;
				if (!flag11)
				{
					continue;
				}
				goto IL_0332;
			}
			object obj24 = obj23 + (long)(IntPtr)obj16;
			int num14 = (int)((long)(IntPtr)obj24 << 4);
			object obj25 = (long)intPtr6 + (long)num14;
			object obj26 = (long)(IntPtr)obj25 + 304L;
			goto IL_0995;
		}
		if (!TapToPlay)
		{
			return;
		}
		GameConfig gameConfig = config;
		WeaponSetup value4 = gameConfig.Weapon.Data.Value;
		GameConfig gameConfig2 = config;
		int value5 = ((BaseGlobalVariable<int>)gameConfig2.Weapon).Value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X0_v31 (GBG.Pinata.ECS.WeaponSetup)+18]");
		bool flag12 = 0L < (long)value5;
		bool flag13 = !flag12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X0_v31 (GBG.Pinata.ECS.WeaponSetup)+18]");
		int num15 = (int)(-value5);
		bool flag14 = num15 == 0;
		bool flag15 = !flag14;
		if (!(flag13 && flag15))
		{
			throw new ArgumentOutOfRangeException();
		}
		int num16 = value5 << 3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X0_v31 (GBG.Pinata.ECS.WeaponSetup)+10]");
		object obj27 = 0L + (long)num16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ X8_v27+20]");
		object obj28 = 0;
		GlobalVariableInt currentWeaponAmmo = CurrentWeaponAmmo;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X8_v28+2C]");
		currentWeaponAmmo.Value = 0;
		_ = 1;
		Filter filter3 = filterEnemyHook;
		World world5 = filter3.world;
		int[] entitiesCacheForBags3 = filter3.entitiesCacheForBags;
		Entity[] entities3 = world5.Entities;
		int num17 = entitiesCacheForBags3[0];
		entity2 = entities3[num17];
		IntPtr intPtr8 = (IntPtr)entity2;
		IntPtr intPtr9 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ X8_v36 (Il2CppClass<Morpeh.Entity>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_0590;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ X8_v36 (Il2CppClass<Morpeh.Entity>)+B0]");
		object obj29 = 0L + 8L;
		int num18 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ X11_v17-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num18++;
			int num19 = num18;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ X8_v36 (Il2CppClass<Morpeh.Entity>)+126]");
			bool flag16 = (long)num19 < 0L;
			bool flag17 = !flag16;
			obj29 = (long)(IntPtr)obj29 + 16L;
			if (!flag17)
			{
				continue;
			}
			goto IL_0590;
		}
		object obj30 = obj29;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ X20_v8 (Il2CppMethodInfo)+48]");
		object obj31 = obj30 + 0;
		int num20 = (int)((long)(IntPtr)obj31 << 4);
		object obj32 = (long)intPtr8 + (long)num20;
		object obj33 = (long)(IntPtr)obj32 + 304L;
		goto IL_0a0e;
		IL_0b0f:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ X0_v41+8]");
		ref EnemyMoveDownMarker reference = ref ((IEntity)0).AddComponent<EnemyMoveDownMarker>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v939 @ X0_v43 (GBG.Pinata.ECS.Markers.EnemyMoveDownMarker&)] (should have been resolved before IL gen)");
		return;
		IL_080b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
		goto IL_0b0f;
	}

	[Token(Token = "0x6000013")]
	[Address(RVA = "0xCC9144", Offset = "0xCC9144", Length = "0x508")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EC47E0]);\n\tv31 = *([v30 @ X8_v54]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023785]) = v50;\nL_0019:\n\tv51 = this.filter;\n\tv53 = v51.world;\n\tv54 = v51.entitiesCacheForBags;\n\tv55 = v53.Entities;\n\tv56 = v54[0];\n\tv59 = v55[v56 @ X8_v7 (System.Int32)];\n\tv211 = *([v59 @ X20_v4 (Morpeh.Entity)]);\n\tv154 = Il2CppMethodInfo;\n\tv143 = *([v154 @ X21_v3 (Il2CppMethodInfo)+48]);\n\tv214 = *([v211 @ X8_v9 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v214) goto L_004A;\n\tv319 = *([v211 @ X8_v9 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0036:\n\tv324 = *([v319 @ X11_v30-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v324) goto L_004D;\n\tv318 = v318 + 1;\n\tv413 = v318 < *([v211 @ X8_v9 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv301 = ~v413;\n\tv319 = v319 + 0x10;\n\tv285 = ~v301;\n\tif (v285) goto L_0036;\nL_004A:\n\tv420 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v55[v56 @ X8_v7 (System.Int32)], Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0053;\nL_004D:\n\tv415 = *([v319 @ X11_v30]) + v143;\n\tv416 = v415 << 4;\n\tv417 = v211 + v416;\n\tv420 = v417 + 0x130;\nL_0053:\n\tv424 = Morpeh.IEntity::GetComponent(*([v420 @ X0_v6+8]));\n\t*([v424 @ X0_v8 (GameStateComponent&)])(v175, v55[v56 @ X8_v7 (System.Int32)], v424, v143, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv428 = *([v175 @ X0_v10 (GameStateComponent&)+4]) == 0;\n\tif (v428) goto L_00D7;\n\tv429 = *([v175 @ X0_v10 (GameStateComponent&)+5]) == 0;\n\tif (v429) goto L_0158;\n\tv432 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.EndTransitionToMenu);\n\tv445 = v432 == 0;\n\tif (v445) goto L_0153;\n\tMorpeh.Globals.GlobalEvent::Publish(this.ShowWinScreen);\n\tv196 = this.config;\n\tv480 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v196.Enemy);\n\tv146 = v480 + 1;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v196.Enemy, v146);\n\tv166 = this.config;\n\tv197 = v166.Enemy.EnemiesSetup;\n\tv156 = v197._size - 1;\n\tv173 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v166.Enemy);\n\tv82 = v173 <= v156;\n\tif (v82) goto L_00A2;\n\tv198 = this.config;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v198.Enemy, 0);\nL_00A2:\n\t*([v175 @ X0_v10 (GameStateComponent&)]) = 0x14;\n\t*([v175 @ X0_v10 (GameStateComponent&)+4]) = 0;\n\tv199 = this.filterEnemyHook;\n\tv772 = v199.world;\n\tv773 = v199.entitiesCacheForBags;\n\tv167 = v772.Entities;\n\tv774 = v773[0];\n\tv193 = v167[v774 @ X8_v43 (System.Int32)];\n\tv788 = *([v193 @ X19_v10 (Morpeh.Entity)]);\n\tv789 = Il2CppMethodInfo;\n\tv793 = *([v788 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v793) goto L_00D5;\n\tv834 = *([v788 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00C1:\n\tv839 = *([v834 @ X11_v25-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v839) goto L_01C7;\n\tv833 = v833 + 1;\n\tv844 = v833 < *([v788 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv816 = ~v844;\n\tv834 = v834 + 0x10;\n\tv800 = ~v816;\n\tif (v800) goto L_00C1;\nL_00D5:\n\tv851 = 0x8909C4(v167[v774 @ X8_v43 (System.Int32)], Il2CppClass<Morpeh.IEntity>, *([v789 @ X20_v13 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_01CD;\nL_00D7:\n\tv201 = this.filter;\n\tv443 = v201.Length < 1;\n\tif (v443) goto L_0153;\nL_00F1:\n\tv176 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.Level);\n\tv158 = v176 + 1;\n\tv476 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.NextLevel);\n\tv113 = v476 == v158;\n\tif (v113) goto L_0109;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.NextLevel, v158);\nL_0109:\n\tv203 = this.config;\n\tv569 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v203.Enemy.CurrentEnemyHealth);\n\tv223 = v569 <= 0;\n\tif (v223) goto L_0132;\n\tv685 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.CurrentWeaponAmmo);\n\tv756 = v685 > 0;\n\tif (v756) goto L_013B;\n\t*([v175 @ X0_v10 (GameStateComponent&)+5]) = 0;\n\tgoto L_013A;\nL_0132:\n\t*([v175 @ X0_v10 (GameStateComponent&)+5]) = 1;\n\tMorpeh.Globals.GlobalEvent::Publish(this.BeginTransitionToMenu);\nL_013A:\n\tGameStateSystem::ChangeState(this, v175);\nL_013B:\n\tv78 = v78 + 1;\n\tv456 = v78 < v201.Length;\n\tif (v456) goto L_00F1;\nL_0153:\n\treturn;\nL_0158:\n\tMorpeh.Globals.GlobalEvent::Publish(this.EnemyIsNotDead);\n\tMorpeh.Globals.GlobalEvent::Publish(this.ShowLoseScreen);\n\t*([v175 @ X0_v10 (GameStateComponent&)]) = 0x14;\n\t*([v175 @ X0_v10 (GameStateComponent&)+4]) = 0;\n\tv204 = this.filterEnemyHook;\n\tv472 = v204.world;\n\tv473 = v204.entitiesCacheForBags;\n\tv168 = v472.Entities;\n\tv474 = v473[0];\n\tv194 = v168[v474 @ X8_v27 (System.Int32)];\n\tv483 = *([v194 @ X19_v9 (Morpeh.Entity)]);\n\tv484 = Il2CppMethodInfo;\n\tv488 = *([v483 @ X8_v29 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v488) goto L_0192;\n\tv534 = *([v483 @ X8_v29 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_017E:\n\tv539 = *([v534 @ X11_v15-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v539) goto L_0195;\n\tv533 = v533 + 1;\n\tv544 = v533 < *([v483 @ X8_v29 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv513 = ~v544;\n\tv534 = v534 + 0x10;\n\tv497 = ~v513;\n\tif (v497) goto L_017E;\nL_0192:\n\tv564 = 0x8909C4(v168[v474 @ X8_v27 (System.Int32)], Il2CppClass<Morpeh.IEntity>, *([v484 @ X20_v11 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_019B;\nL_0195:\n\tv546 = *([v534 @ X11_v15]) + *([v484 @ X20_v11 (Il2CppMethodInfo)+48]);\n\tv547 = v546 << 4;\n\tv548 = v483 + v547;\n\tv564 = v548 + 0x130;\nL_019B:\n\tv568 = Morpeh.IEntity::RemoveComponent(*([v564 @ X0_v38+8]));\n\tv568.m_value(v574, v168[v474 @ X8_v27 (System.Int32)], v568, *([v484 @ X20_v11 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv726 = *([v194 @ X19_v9 (Morpeh.Entity)]);\n\tv578 = Il2CppMethodInfo;\n\tv718 = *([v578 @ X20_v12 (Il2CppMethodInfo)+48]);\n\tv582 = *([v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v582) goto L_01F8;\n\tv716 = *([v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_01B2:\n\tv679 = *([v716 @ X11_v5-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v679) goto L_01FB;\n\tv673 = v673 + 1;\n\tv692 = v673 < *([v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv630 = ~v692;\n\tv716 = v716 + 0x10;\n\tv598 = ~v630;\n\tif (v598) goto L_01B2;\n\tgoto L_01F8;\nL_01C7:\n\tv846 = *([v834 @ X11_v25]) + *([v789 @ X20_v13 (Il2CppMethodInfo)+48]);\n\tv847 = v846 << 4;\n\tv848 = v788 + v847;\n\tv851 = v848 + 0x130;\nL_01CD:\n\tv855 = Morpeh.IEntity::RemoveComponent(*([v851 @ X0_v55+8]));\n\tv855.m_value(v650, v167[v774 @ X8_v43 (System.Int32)], v855, *([v789 @ X20_v13 (Il2CppMethodInfo)+48]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv726 = *([v193 @ X19_v10 (Morpeh.Entity)]);\n\tv657 = Il2CppMethodInfo;\n\tv718 = *([v657 @ X20_v14 (Il2CppMethodInfo)+48]);\n\tv652 = *([v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v652) goto L_01F8;\n\tv716 = *([v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_01E4:\n\tv707 = *([v716 @ X11_v5-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v707) goto L_01FB;\n\tv715 = v715 + 1;\n\tv875 = v715 < *([v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv629 = ~v875;\n\tv716 = v716 + 0x10;\n\tv597 = ~v629;\n\tif (v597) goto L_01E4;\nL_01F8:\n\tv738 = 0x8909C4(v739, v642, v718, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0201;\nL_01FB:\n\tv729 = *([v716 @ X11_v5]) + v718;\n\tv730 = v729 << 4;\n\tv731 = v726 + v730;\n\tv738 = v731 + 0x130;\nL_0201:\n\tv744 = Morpeh.IEntity::AddComponent(*([v738 @ X0_v27+8]));\n\tv384 = *([v744 @ X0_v29 (GBG.Pinata.ECS.Markers.EnemyMoveUpMarker&)]);\n\t// 529 IndirectJump v384 @ X2_v9, v739 @ X19_v5 (Morpeh.Entity), v739 @ X19_v5 (Morpeh.Entity), v744 @ X0_v29 (GBG.Pinata.ECS.Markers.EnemyMoveUpMarker&), v384 @ X2_v9, v35 @ X3, v36 @ X4, v37 @ X5, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 354 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void PlayingLogic()
	{
		//IL_005c: Expected I, but got O
		//IL_08d0: Expected O, but got I
		//IL_00ad: Expected O, but got I
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0156: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_00f9: Expected O, but got I
		//IL_05d4: Expected I, but got O
		//IL_09d2: Expected O, but got I
		//IL_09e8: Expected I, but got O
		//IL_09fe: Expected O, but got I
		//IL_0615: Expected O, but got I
		//IL_0ab4: Expected O, but got I
		//IL_06e5: Expected O, but got I
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Expected O, but got Unknown
		//IL_06bb: Expected O, but got I
		//IL_06ca: Expected O, but got I
		//IL_0661: Expected O, but got I
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Expected O, but got Unknown
		//IL_087a: Expected O, but got I
		//IL_0889: Expected O, but got I
		//IL_0731: Expected O, but got I
		//IL_0312: Expected I, but got O
		//IL_0936: Expected O, but got I
		//IL_094c: Expected I, but got O
		//IL_0962: Expected O, but got I
		//IL_0353: Expected O, but got I
		//IL_07c3: Expected O, but got I
		//IL_0777: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected O, but got Unknown
		//IL_0799: Expected O, but got I
		//IL_07a8: Expected O, but got I
		//IL_039f: Expected O, but got I
		//IL_080f: Expected O, but got I
		Filter filter = this.filter;
		World world = filter.world;
		int[] entitiesCacheForBags = filter.entitiesCacheForBags;
		Entity[] entities = world.Entities;
		int num = entitiesCacheForBags[0];
		Entity entity = entities[num];
		IntPtr intPtr = (IntPtr)entity;
		IntPtr intPtr2 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X21_v3 (Il2CppMethodInfo)+48]");
		IntPtr intPtr3 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X8_v9 (Il2CppClass<Morpeh.Entity>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_0112;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X8_v9 (Il2CppClass<Morpeh.Entity>)+B0]");
		object obj = 0L + 8L;
		int num2 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X11_v30-8]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				break;
			}
			num2++;
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X8_v9 (Il2CppClass<Morpeh.Entity>)+126]");
			bool flag = (long)num3 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_0112;
		}
		object obj2 = obj + (long)intPtr3;
		int num4 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num4;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_08bf;
		IL_0840:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
		goto IL_0aa3;
		IL_0925:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ X0_v55+8]");
		bool flag3 = ((IEntity)0).RemoveComponent<EnemyMoveDownMarker>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v855.m_value (System.Boolean) (should have been resolved before IL gen)");
		Entity entity2;
		IntPtr intPtr4 = (IntPtr)entity2;
		IntPtr intPtr5 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ X20_v14 (Il2CppMethodInfo)+48]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]");
		bool flag4 = (IntPtr)0 == (IntPtr)0;
		IntPtr intPtr6 = (IntPtr)0;
		Entity[] entities2;
		int num5;
		Entity entity3 = entities2[num5];
		if (flag4)
		{
			goto IL_0840;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+B0]");
		object obj6 = 0L + 8L;
		int num6 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ X11_v5-8]");
			bool flag5 = (IntPtr)0 == (IntPtr)0;
			entity3 = entities2[num5];
			if (flag5)
			{
				break;
			}
			num6++;
			int num7 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]");
			bool flag6 = (long)num7 < 0L;
			bool flag7 = !flag6;
			obj6 = (long)(IntPtr)obj6 + 16L;
			bool flag8 = !flag7;
			intPtr6 = (IntPtr)0;
			entity3 = entities2[num5];
			if (flag8)
			{
				continue;
			}
			goto IL_0840;
		}
		goto IL_084f;
		IL_067a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
		goto IL_09c1;
		IL_074a:
		intPtr6 = (IntPtr)0;
		Entity[] entities3;
		int num8;
		entity3 = entities3[num8];
		goto IL_0840;
		IL_0112:
		((BaseGlobalVariable<int>)(object)entities[num]).Value = 0;
		goto IL_08bf;
		IL_08bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ X0_v6+8]");
		ref GameStateComponent component = ref ((IEntity)0).GetComponent<GameStateComponent>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v424 @ X0_v8 (GameStateComponent&)] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X0_v10 (GameStateComponent&)+4]");
		Entity entity4;
		ref GameStateComponent reference = default(ref GameStateComponent);
		if ((IntPtr)0 != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X0_v10 (GameStateComponent&)+5]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				if (!EndTransitionToMenu)
				{
					return;
				}
				ShowWinScreen.Publish();
				GameConfig gameConfig = config;
				int value = ((BaseGlobalVariable<int>)gameConfig.Enemy).Value;
				int value2 = value + 1;
				((BaseGlobalVariable<int>)gameConfig.Enemy).Value = value2;
				GameConfig gameConfig2 = config;
				List<EnemySetupClass> enemiesSetup = gameConfig2.Enemy.EnemiesSetup;
				int num9 = enemiesSetup.Count - 1;
				int value3 = ((BaseGlobalVariable<int>)gameConfig2.Enemy).Value;
				if (value3 > num9)
				{
					GameConfig gameConfig3 = config;
					((BaseGlobalVariable<int>)gameConfig3.Enemy).Value = 0;
				}
				reference = ref *(GameStateComponent*)20;
				_ = 0;
				Filter filter2 = filterEnemyHook;
				World world2 = filter2.world;
				int[] entitiesCacheForBags2 = filter2.entitiesCacheForBags;
				entities2 = world2.Entities;
				num5 = entitiesCacheForBags2[0];
				entity2 = entities2[num5];
				IntPtr intPtr7 = (IntPtr)entity2;
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_03b8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj7 = 0L + 8L;
				int num10 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ X11_v25-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num10++;
					int num11 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ X8_v45 (Il2CppClass<Morpeh.Entity>)+126]");
					bool flag9 = (long)num11 < 0L;
					bool flag10 = !flag9;
					obj7 = (long)(IntPtr)obj7 + 16L;
					if (!flag10)
					{
						continue;
					}
					goto IL_03b8;
				}
				object obj8 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v789 @ X20_v13 (Il2CppMethodInfo)+48]");
				object obj9 = obj8 + 0;
				int num12 = (int)((long)(IntPtr)obj9 << 4);
				object obj10 = (long)intPtr7 + (long)num12;
				object obj11 = (long)(IntPtr)obj10 + 304L;
				goto IL_0925;
			}
			EnemyIsNotDead.Publish();
			ShowLoseScreen.Publish();
			reference = ref *(GameStateComponent*)20;
			_ = 0;
			Filter filter3 = filterEnemyHook;
			World world3 = filter3.world;
			int[] entitiesCacheForBags3 = filter3.entitiesCacheForBags;
			entities3 = world3.Entities;
			num8 = entitiesCacheForBags3[0];
			entity4 = entities3[num8];
			IntPtr intPtr9 = (IntPtr)entity4;
			IntPtr intPtr10 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ X8_v29 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_067a;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ X8_v29 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj12 = 0L + 8L;
			int num13 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X11_v15-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num13++;
				int num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ X8_v29 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag11 = (long)num14 < 0L;
				bool flag12 = !flag11;
				obj12 = (long)(IntPtr)obj12 + 16L;
				if (!flag12)
				{
					continue;
				}
				goto IL_067a;
			}
			object obj13 = obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X20_v11 (Il2CppMethodInfo)+48]");
			object obj14 = obj13 + 0;
			int num15 = (int)((long)(IntPtr)obj14 << 4);
			object obj15 = (long)intPtr9 + (long)num15;
			object obj16 = (long)(IntPtr)obj15 + 304L;
			goto IL_09c1;
		}
		Filter filter4 = this.filter;
		if (filter4.Length < 1)
		{
			return;
		}
		int num16 = 0;
		do
		{
			int value4 = Level.Value;
			int num17 = value4 + 1;
			int value5 = NextLevel.Value;
			if (value5 != num17)
			{
				NextLevel.Value = num17;
				intPtr3 = (IntPtr)0;
			}
			GameConfig gameConfig4 = config;
			int value6 = gameConfig4.Enemy.CurrentEnemyHealth.Value;
			if (value6 > 0)
			{
				int value7 = CurrentWeaponAmmo.Value;
				if (value7 > 0)
				{
					goto IL_0514;
				}
				_ = 0;
			}
			else
			{
				_ = 1;
				BeginTransitionToMenu.Publish();
			}
			ChangeState(ref reference);
			goto IL_0514;
			IL_0514:
			num16++;
		}
		while (num16 < filter4.Length);
		return;
		IL_09c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X0_v38+8]");
		bool flag13 = ((IEntity)0).RemoveComponent<EnemyMoveDownMarker>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v568.m_value (System.Boolean) (should have been resolved before IL gen)");
		intPtr4 = (IntPtr)entity4;
		IntPtr intPtr11 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ X20_v12 (Il2CppMethodInfo)+48]");
		obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]");
		bool flag14 = (IntPtr)0 == (IntPtr)0;
		intPtr6 = (IntPtr)0;
		entity3 = entities3[num8];
		if (flag14)
		{
			goto IL_0840;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+B0]");
		obj6 = 0L + 8L;
		int num18 = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ X11_v5-8]");
			bool flag15 = (IntPtr)0 == (IntPtr)0;
			entity3 = entities3[num8];
			if (flag15)
			{
				break;
			}
			num18++;
			int num19 = num18;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X8_v21 (Il2CppClass<Morpeh.Entity>)+126]");
			bool flag16 = (long)num19 < 0L;
			bool flag17 = !flag16;
			obj6 = (long)(IntPtr)obj6 + 16L;
			if (!flag17)
			{
				continue;
			}
			goto IL_074a;
		}
		goto IL_084f;
		IL_03b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
		goto IL_0925;
		IL_084f:
		object obj17 = obj6 + (long)(IntPtr)obj5;
		int num20 = (int)((long)(IntPtr)obj17 << 4);
		object obj18 = (long)intPtr4 + (long)num20;
		object obj19 = (long)(IntPtr)obj18 + 304L;
		goto IL_0aa3;
		IL_0aa3:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X0_v27+8]");
		object obj20 = ((IEntity)0).AddComponent<EnemyMoveUpMarker>();
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v384 @ X2_v9 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0xCC964C", Offset = "0xCC964C", Length = "0x18C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EF0430]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, gs, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023786]) = v45;\nL_001B:\n\tv50 = this.filterAttacks == 0;\n\tif (v50) goto L_0073;\n\tv54 = Morpeh.Filter::GetEnumerator(this.filterAttacks);\n\tv133 = v54.world;\n\tgoto L_0068;\nL_0033:\n\tv171 = Il2CppMethodInfo;\n\tv206 = *([v192 @ stack_-58]);\n\tv94 = *([v171 @ X21_v6 (Il2CppMethodInfo)+48]);\n\tv168 = *([v206 @ X8_v8+126]) == 0;\n\tif (v168) goto L_0056;\n\tv333 = *([v206 @ X8_v8+B0]) + 8;\nL_003D:\n\t;\n\tv338 = *([v333 @ X11_v8-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v338) goto L_0058;\n\tv332 = v332 + 1;\n\tv343 = v332 < *([v206 @ X8_v8+126]);\n\tv276 = ~v343;\n\tv333 = v333 + 0x10;\n\tv260 = ~v276;\n\tif (v260) goto L_003D;\nL_0056:\n\tv350 = 0x8909C4(v192, Il2CppClass<Morpeh.IEntity>, v94, v30, v31, v32, v33, v34, v54.ids, v54.world, v37, v38, v39, v40, v41, v42);\n\tgoto L_005D;\nL_0058:\n\t;\n\tv345 = *([v333 @ X11_v8]) + v94;\n\tv346 = v345 << 4;\n\tv347 = v206 + v346;\n\tv350 = v347 + 0x130;\nL_005D:\n\t;\n\tv354 = Morpeh.IEntity::GetComponent(*([v350 @ X0_v22+8]));\n\t*([v354 @ X0_v24 (GBG.Pinata.ECS.Components.AttackComponent&)])(v166, v192, v354, v94, v30, v31, v32, v33, v34, v54.ids, v54.world, v37, v38, v39, v40, v41, v42);\n\t*([v166 @ X0_v26+4]) = 1;\nL_0068:\n\tv173 = 0x15F75B8(&v133 @ stack_-80_v3 (Morpeh.World), 0, v94, v30, v31, v32, v33, v34, v54.ids, v54.world, v37, v38, v39, v40, v41, v42);\n\tv184 = v173 & 1;\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_0033;\n\tv191 = 0x15F7664(&v133 @ stack_-80_v3 (Morpeh.World), 0, v94, v30, v31, v32, v33, v34, v54.ids, v54.world, v37, v38, v39, v40, v41, v42);\n\tgoto L_008B;\n\tv137 = new System.NullReferenceException();\nL_0073:\n\tv146 = new System.NullReferenceException();\n\tgoto L_007F;\n\tgoto L_007F;\nL_007F:\n\tv183 = 0 != 1;\n\tif (v183) goto L_0095;\n\tv187 = 0x6D2BC0(v146, 0, v94, v30, v31, v32, v33, v34, v121, v133, v37, v38, v39, v40, v41, v42);\n\tv194 = 0x6D2490(v187, 0, v94, v30, v31, v32, v33, v34, v121, v133, v37, v38, v39, v40, v41, v42);\n\tv198 = 0x15F7664(&v101 @ stack_-60_v3 (Morpeh.World), 0, v94, v30, v31, v32, v33, v34, v121, v133, v37, v38, v39, v40, v41, v42);\n\tv283 = *([v187 @ X0_v10]) == 0;\n\tv200 = ~v283;\n\tif (v200) goto L_0099;\nL_008B:\n\t*([gs @ X1 (GameStateComponent&)+4]) = 1;\n\treturn;\nL_0095:\n\tv188 = 0x6D2380(v146, 0, v94, v30, v31, v32, v33, v34, v121, v133, v37, v38, v39, v40, v41, v42);\nL_0099:\n\tthrow System.TypeLoadException;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void ChangeState(ref GameStateComponent gs)
	{
		//IL_027f: Expected O, but got I
		//IL_0089: Expected O, but got I
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0129: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_00d5: Expected O, but got I
		bool flag = filterAttacks == null;
		World world2 = default(World);
		World world = world2;
		if (!flag)
		{
			world2 = filterAttacks.GetEnumerator().world;
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr = intPtr2;
			object obj = default(object);
			object obj3 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				if ((int)((long)(IntPtr)obj & 1L) == 0)
				{
					break;
				}
				IntPtr intPtr3 = (IntPtr)0;
				object obj2 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X21_v6 (Il2CppMethodInfo)+48]");
				intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ X8_v8+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ee;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ X8_v8+B0]");
				object obj4 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X11_v8-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ X8_v8+126]");
					bool flag2 = (long)num2 < 0L;
					bool flag3 = !flag2;
					obj4 = (long)(IntPtr)obj4 + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_00ee;
				}
				object obj5 = obj4 + (long)intPtr;
				int num3 = (int)((long)(IntPtr)obj5 << 4);
				object obj6 = (long)(IntPtr)obj2 + (long)num3;
				object obj7 = (long)(IntPtr)obj6 + 304L;
				goto IL_026d;
				IL_00ee:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_026d;
				IL_026d:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ X0_v22+8]");
				ref AttackComponent component = ref ((IEntity)0).GetComponent<AttackComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v354 @ X0_v24 (GBG.Pinata.ECS.Components.AttackComponent&)] (should have been resolved before IL gen)");
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
			goto IL_01c6;
		}
		NullReferenceException ex = new NullReferenceException();
		if (0 == 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
			object obj8 = default(object);
			if (obj8 == null)
			{
				goto IL_01c6;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}
		throw new TypeLoadException();
		IL_01c6:
		_ = 1;
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0xCC97D8", Offset = "0xCC97D8", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GameStateSystem()
	{
	}
}
