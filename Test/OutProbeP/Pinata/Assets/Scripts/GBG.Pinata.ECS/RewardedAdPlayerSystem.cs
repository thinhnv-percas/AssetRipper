using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x200000B")]
public class RewardedAdPlayerSystem : UpdateSystem
{
	[Required]
	[Token(Token = "0x400002D")]
	[FieldOffset(Offset = "0x28")]
	public GlobalEvent InterstitialCompleted;

	[Required]
	[Token(Token = "0x400002E")]
	[FieldOffset(Offset = "0x30")]
	public GlobalEvent RewardedCompleted;

	[Required]
	[Token(Token = "0x400002F")]
	[FieldOffset(Offset = "0x38")]
	public GlobalEvent RewardedSkipped;

	[Required]
	[Token(Token = "0x4000030")]
	[FieldOffset(Offset = "0x40")]
	public GlobalVariableFloat Timer;

	[Required]
	[Token(Token = "0x4000031")]
	[FieldOffset(Offset = "0x48")]
	public GlobalVariableInt Coins;

	[Required]
	[Token(Token = "0x4000032")]
	[FieldOffset(Offset = "0x50")]
	public GlobalVariableInt LevelReward;

	[Token(Token = "0x4000033")]
	[FieldOffset(Offset = "0x58")]
	private Filter adButtonFilter;

	[Token(Token = "0x4000034")]
	[FieldOffset(Offset = "0x60")]
	private Filter gameStateFilter;

	[Token(Token = "0x4000035")]
	[FieldOffset(Offset = "0x68")]
	private GameConfig config;

	[Token(Token = "0x6000016")]
	[Address(RVA = "0xCC9C90", Offset = "0xCC9C90", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECE220]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202378A]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv59 = Morpeh.Filter::With(v42, 1);\n\tthis.adButtonFilter = v59;\n\tv48 = Morpeh.FilterProvider::get_All(this.filter);\n\tv86 = Morpeh.Filter::With(v48, 1);\n\tthis.gameStateFilter = v86;\n\tv74 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v74;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<RewardedAdButtonComponent>();
		adButtonFilter = filter;
		Filter all2 = Filter.All;
		Filter filter2 = all2.With<GameStateComponent>();
		gameStateFilter = filter2;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0xCC9D40", Offset = "0xCC9D40", Length = "0x744")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = &v23 @ X29;\n\tgoto L_0020;\n\tv37 = *([1EFF860]);\n\tv38 = *([v37 @ X8_v68]);\n\tv39 = \"il2cpp_codegen_initialize_method\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, deltaTime, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([202378B]) = v56;\nL_0020:\n\tv60 = &v23 @ X29 - 0x38;\n\t*([v23 @ X29-58]) = 0;\n\t*([v23 @ X29-90]) = 0;\n\t*([v23 @ X29-80]) = 0;\n\t*([v23 @ X29-B0]) = 0;\n\t*([v23 @ X29-A0]) = 0;\n\t*([v60 @ X30_v1-100]) = &v59 @ stack_-160;\n\tv67 = Morpeh.Globals.BaseGlobalVariable`1<System.Single>::get_Value(this.Timer);\n\tv127 = v67 <= 0;\n\tif (v127) goto L_004D;\n\tv282 = Morpeh.Globals.BaseGlobalVariable`1<System.Single>::get_Value(this.Timer);\n\tv274 = v282 - deltaTime;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Single>::set_Value(this.Timer, v274);\nL_004D:\n\tv367 = Morpeh.Filter::GetEnumerator(this.gameStateFilter);\n\t*([v23 @ X29-80]) = *([v23 @ X29-C0]);\n\tv534 = *([v23 @ X29-D0]);\n\t*([v23 @ X29-90]) = *([v23 @ X29-D0]);\nL_0062:\n\tv660 = &v23 @ X29 - 0x90;\n\tv662 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v660, 0);\n\tv664 = v662 & 1;\n\tv665 = v664 == 0;\n\tif (v665) goto L_0239;\n\tv668 = *([v23 @ X29-88]);\n\tv733 = Il2CppMethodInfo;\n\tv734 = *([v668 @ X21_v11 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv715 = *([v733 @ X22_v10 (Il2CppMethodInfo)+48]);\n\tv738 = *([v734 @ X8_v26 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v738) goto L_0090;\n\tv827 = *([v734 @ X8_v26 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_007C:\n\tv841 = *([v827 @ X11_v20-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v841) goto L_0093;\n\tv826 = v826 + 1;\n\tv864 = v826 < *([v734 @ X8_v26 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv772 = ~v864;\n\tv827 = v827 + 0x10;\n\tv756 = ~v772;\n\tif (v756) goto L_007C;\nL_0090:\n\tv871 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v668, Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0099;\nL_0093:\n\tv866 = *([v827 @ X11_v20]) + v715;\n\tv867 = v866 << 4;\n\tv868 = v734 + v867;\n\tv871 = v868 + 0x130;\nL_0099:\n\tv875 = Morpeh.IEntity::GetComponent(*([v871 @ X0_v36+8]));\n\t*([v875 @ X0_v38 (GameStateComponent&)])(v878, v668, v875, v715, v42, v43, v44, v45, v46, v534, v450, v48, v49, v50, v51, v52, v53);\n\tv883 = Morpeh.Filter::GetEnumerator(this.adButtonFilter);\n\tv450 = *([v23 @ X29-D0]);\n\tv534 = *([v23 @ X29-C0]);\n\t*([v23 @ X29-B0]) = *([v23 @ X29-D0]);\n\t*([v23 @ X29-A0]) = *([v23 @ X29-C0]);\nL_00B2:\n\tv916 = &v23 @ X29 - 0xB0;\n\tv917 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v916, 0);\n\tv918 = v917 & 1;\n\tv919 = v918 == 0;\n\tif (v919) goto L_01B4;\n\tv468 = *([v23 @ X29-A8]);\n\tv566 = *([v23 @ X29-A8]) == 0;\n\tif (v566) goto L_01BC;\n\tv440 = Il2CppMethodInfo;\n\tv924 = *([v468 @ X22_v12 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv927 = *([v924 @ X8_v39 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v927) goto L_00E0;\n\tv965 = *([v924 @ X8_v39 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_00CC:\n\tv979 = *([v965 @ X11_v15-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v979) goto L_00E3;\n\tv964 = v964 + 1;\n\tv987 = v964 < *([v924 @ X8_v39 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv956 = ~v987;\n\tv965 = v965 + 0x10;\n\tv940 = ~v956;\n\tif (v940) goto L_00CC;\nL_00E0:\n\tv994 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(*([v23 @ X29-A8]), Il2CppClass<Morpeh.IEntity>);\n\tgoto L_00E9;\nL_00E3:\n\tv989 = *([v965 @ X11_v15]) + *([v440 @ X23_v10 (Il2CppMethodInfo)+48]);\n\tv990 = v989 << 4;\n\tv991 = v924 + v990;\n\tv994 = v991 + 0x130;\nL_00E9:\n\tv998 = Morpeh.IEntity::GetComponent(*([v994 @ X0_v52+8]));\n\t*([v998 @ X0_v54 (RewardedAdButtonComponent&)])(v1003, *([v23 @ X29-A8]), v998, *([v440 @ X23_v10 (Il2CppMethodInfo)+48]), v42, v43, v44, v45, v46, v534, v450, v48, v49, v50, v51, v52, v53);\n\tv583 = this.config;\n\tv567 = this.config == 0;\n\tif (v567) goto L_01BF;\n\tv568 = v583.Enemy == 0;\n\tif (v568) goto L_01C1;\n\tv434 = v583.Enemy.EnemiesSetup;\n\tv1006 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v583.Enemy);\n\tv569 = v583.Enemy.EnemiesSetup == 0;\n\tif (v569) goto L_01C4;\n\tv1008 = v434._size < v1006;\n\tv529 = ~v1008;\n\tv523 = v434._size - v1006;\n\tv511 = v523 == 0;\n\tv1009 = ~v511;\n\tv481 = v529 & v1009;\n\tif (v481) goto L_010B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_010B:\n\tv1013 = v434._items;\n\tv584 = v1013[v1006 @ X0_v61 (System.Int32)];\n\tv570 = v1013[v1006 @ X0_v61 (System.Int32)] == 0;\n\tif (v570) goto L_01C7;\n\tv1015 = *([v1003 @ X0_v56+14]) == 0;\n\tif (v1015) goto L_012F;\n\tv572 = this.LevelReward == 0;\n\tif (v572) goto L_01CB;\n\tv1022 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.LevelReward);\n\tv573 = this.LevelReward == 0;\n\tif (v573) goto L_01CD;\n\tv1028 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.LevelReward);\n\tv586 = v1028 + v1022;\n\t*([v23 @ X29-58]) = v586;\n\tv1034 = &v23 @ X29 - 0x58;\n\tv1036 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v1034, 0);\n\tv574 = *([v1003 @ X0_v56+8]) == 0;\n\tif (v574) goto L_01D0;\n\tTMPro.TMP_Text::set_text(*([v1003 @ X0_v56+8]), v1036);\n\tgoto L_013D;\nL_012F:\n\tv534 = *([v1003 @ X0_v56+10]) * v584.BaseReward;\n\t*([v23 @ X29-54]) = v534;\n\tv1019 = &v23 @ X29 - 0x54;\n\tv1021 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v1019, 0);\n\tv577 = *([v1003 @ X0_v56+8]) == 0;\n\tif (v577) goto L_01D7;\n\tTMPro.TMP_Text::set_text(*([v1003 @ X0_v56+8]), v1021);\nL_013D:\n\tv571 = this.RewardedCompleted == 0;\n\tif (v571) goto L_01C9;\n\tv1037 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.RewardedCompleted);\n\tv1039 = v1037 == 0;\n\tif (v1039) goto L_0199;\n\tv575 = this.Timer == 0;\n\tif (v575) goto L_01D2;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Single>::set_Value(this.Timer, 60f);\n\tv1062 = *([v1003 @ X0_v56+14]) == 0;\n\tif (v1062) goto L_0174;\n\tv483 = *([v878 @ X0_v40]) != 0x14;\n\tif (v483) goto L_0199;\n\tv579 = this.Coins == 0;\n\tif (v579) goto L_01DC;\n\tv1075 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.Coins);\n\tv580 = this.LevelReward == 0;\n\tif (v580) goto L_01DE;\n\tv1092 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.LevelReward);\n\tv1095 = v1092 + v1075;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.Coins, v1095);\n\t*([v23 @ X29-E0]) = *([v1003 @ X0_v56+10]);\n\tv534 = *([v1003 @ X0_v56]);\n\t*([v23 @ X29-F0]) = *([v1003 @ X0_v56]);\n\tv1059 = &v23 @ X29 - 0xF0;\n\tRewardedAdPlayerSystem::RewardedAftermath(this.Coins, v1059);\n\tgoto L_0199;\nL_0174:\n\tv1072 = *([v878 @ X0_v40]) == 0;\n\tv1063 = ~v1072;\n\tif (v1063) goto L_0199;\n\tv581 = this.Coins == 0;\n\tif (v581) goto L_01E1;\n\tv1079 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.Coins);\n\tv1088 = *([v1003 @ X0_v56+10]) * v584.BaseReward;\n\tv1089 = v1079 + v1088;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.Coins, v1089);\n\tv1042 = &v23 @ X29 - 0x10;\n\t*([v23 @ X29-100]) = *([v1003 @ X0_v56+10]);\n\tv534 = *([v1003 @ X0_v56]);\n\t*([v1042 @ X23_v16-100]) = *([v1003 @ X0_v56]);\n\tv1058 = &v23 @ X29 - 0x110;\n\tRewardedAdPlayerSystem::RewardedAftermath(this.Coins, v1058);\nL_0199:\n\tv482 = *([v1003 @ X0_v56]) != *([v878 @ X0_v40]);\n\tif (v482) goto L_00B2;\n\tv576 = this.RewardedSkipped == 0;\n\tif (v576) goto L_01D4;\n\tv910 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::get_IsPublished(this.RewardedSkipped);\n\tv914 = v910 == 0;\n\tif (v914) goto L_00B2;\n\tv578 = this.Timer == 0;\n\tif (v578) goto L_01D9;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Single>::set_Value(this.Timer, 60f);\n\tv903 = &v23 @ X29 - 0x20;\n\t*([v903 @ X23_v14-100]) = *([v1003 @ X0_v56+10]);\n\tv534 = *([v1003 @ X0_v56]);\n\tv904 = &v23 @ X29 - 0x30;\n\t*([v904 @ X22_v14-100]) = *([v1003 @ X0_v56]);\n\tv907 = &v23 @ X29 - 0x130;\n\tRewardedAdPlayerSystem::RewardedAftermath(this.Timer, v907);\n\tgoto L_00B2;\nL_01B4:\n\tv920 = &v23 @ X29 - 0x38;\n\tv921 = *([v920 @ X30_v15-100]);\n\tv683 = v683 + 1;\n\t*([v921 @ X8_v31+v683 @ X28_v9*4]) = 0x1CD;\n\tgoto L_0216;\nL_01BC:\n\tv550 = new System.NullReferenceException();\n\tgoto L_0244;\nL_01BF:\n\tv262 = new System.NullReferen\n// ... truncated")]
	public unsafe override void OnUpdate(float deltaTime)
	{
		//IL_103a: Expected O, but got I
		//IL_009c: Expected F4, but got I
		//IL_00b6: Expected O, but got I8
		//IL_00bb: Expected I, but got O
		//IL_116a: Expected O, but got I
		//IL_0e7c: Expected O, but got I
		//IL_0e8c: Expected O, but got I
		//IL_0e9b: Expected O, but got I
		//IL_0f13: Expected O, but got I
		//IL_0f30: Expected O, but got I
		//IL_00d0: Expected O, but got I
		//IL_00e3: Expected I, but got O
		//IL_1095: Expected O, but got I
		//IL_012e: Expected O, but got I
		//IL_0f79: Expected O, but got I
		//IL_0f89: Expected O, but got I
		//IL_0211: Expected F4, but got I
		//IL_1121: Expected O, but got I
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01ce: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_0a0c: Expected O, but got I
		//IL_0a1c: Expected O, but got I
		//IL_0a2b: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_0d94: Expected O, but got I
		//IL_0db1: Expected O, but got I
		//IL_0240: Expected O, but got I
		//IL_0e4f: Expected I, but got O
		//IL_0ddd: Expected O, but got I
		//IL_0ded: Expected O, but got I
		//IL_0273: Expected I, but got O
		//IL_0e62: Expected I, but got O
		//IL_0e67: Expected I, but got O
		//IL_0326: Expected O, but got I
		//IL_0e28: Expected I4, but got I8
		//IL_0e36: Expected O, but got I
		//IL_10db: Expected O, but got I
		//IL_02ae: Expected O, but got I
		//IL_0eea: Expected I, but got O
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_035d: Expected O, but got I
		//IL_036c: Expected O, but got I
		//IL_02fa: Expected O, but got I
		//IL_05c3: Expected O, but got I
		//IL_060b: Expected O, but got I
		//IL_061d: Expected I, but got O
		//IL_0b8b: Expected I4, but got O
		//IL_0534: Expected O, but got I
		//IL_0c37: Expected I4, but got O
		//IL_0581: Expected O, but got I
		//IL_0586: Expected I, but got O
		//IL_0cdd: Expected I4, but got O
		//IL_09a4: Expected O, but got I
		//IL_09b9: Expected F4, but got O
		//IL_09c8: Expected O, but got I
		//IL_09dc: Expected O, but got I
		//IL_0861: Expected O, but got I
		//IL_0893: Expected O, but got I
		//IL_08a8: Expected F4, but got O
		//IL_08bc: Expected O, but got I
		//IL_08e6: Expected I4, but got O
		//IL_07a3: Expected F4, but got O
		//IL_07b7: Expected O, but got I
		//IL_07d4: Expected I4, but got O
		object obj = obj;
		object obj2 = (long)(IntPtr)obj - 56L;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		float value = Timer.Value;
		if (value > 0f)
		{
			float value2 = Timer.Value;
			float value3 = value2 - deltaTime;
			Timer.Value = value3;
		}
		Filter.EntityEnumerator enumerator = gameStateFilter.GetEnumerator();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-D0]");
		float num = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-D0]");
		_ = 0;
		object obj3 = 4294967295L;
		IntPtr intPtr = (IntPtr)null;
		object obj4 = default(object);
		object obj11 = default(object);
		float value4 = default(float);
		int num5 = default(int);
		BaseGlobalVariable<int> baseGlobalVariable3 = default(BaseGlobalVariable<int>);
		IntPtr intPtr5 = default(IntPtr);
		object obj12 = default(object);
		string text = default(string);
		IntPtr intPtr8 = default(IntPtr);
		string text2 = default(string);
		NullReferenceException ex4 = default(NullReferenceException);
		string text3 = default(string);
		IntPtr intPtr9 = default(IntPtr);
		int num12 = default(int);
		NullReferenceException ex7 = default(NullReferenceException);
		NullReferenceException ex2 = default(NullReferenceException);
		NullReferenceException ex8 = default(NullReferenceException);
		int value8 = default(int);
		object obj18 = default(object);
		object obj19 = default(object);
		NullReferenceException ex5 = default(NullReferenceException);
		NullReferenceException ex9 = default(NullReferenceException);
		NullReferenceException ex3 = default(NullReferenceException);
		NullReferenceException ex10 = default(NullReferenceException);
		NullReferenceException ex = default(NullReferenceException);
		NullReferenceException ex6 = default(NullReferenceException);
		while (true)
		{
			BaseGlobalVariable<int> baseGlobalVariable = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 144L);
			baseGlobalVariable.Value = 0;
			BaseGlobalVariable<int> baseGlobalVariable2;
			IntPtr intPtr4;
			if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-88]");
				baseGlobalVariable2 = (BaseGlobalVariable<int>)0;
				IntPtr intPtr2 = (IntPtr)0;
				IntPtr intPtr3 = (IntPtr)baseGlobalVariable2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ X22_v10 (Il2CppMethodInfo)+48]");
				intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X8_v26 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0193;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X8_v26 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
				object obj5 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v827 @ X11_v20-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X8_v26 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					bool flag = (long)num3 < 0L;
					bool flag2 = !flag;
					obj5 = (long)(IntPtr)obj5 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_0193;
				}
				object obj6 = obj5 + (long)intPtr4;
				int num4 = (int)((long)(IntPtr)obj6 << 4);
				object obj7 = (long)intPtr3 + (long)num4;
				object obj8 = (long)(IntPtr)obj7 + 304L;
				goto IL_1084;
			}
			object obj9 = (long)(IntPtr)obj - 56L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ X30_v14-100]");
			object obj10 = 0;
			obj11 = (long)(IntPtr)obj3 + 1L;
			_ = 489;
			value4 = 60f;
			break;
			IL_0ed5:
			((BaseGlobalVariable<int>)(object)ex).Value = num5;
			intPtr = (IntPtr)baseGlobalVariable3;
			baseGlobalVariable3.Value = num5;
			intPtr4 = intPtr5;
			break;
			IL_1084:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ X0_v36+8]");
			ref GameStateComponent component = ref ((IEntity)0).GetComponent<GameStateComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v875 @ X0_v38 (GameStateComponent&)] (should have been resolved before IL gen)");
			Filter.EntityEnumerator enumerator2 = adButtonFilter.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-D0]");
			int num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-C0]");
			num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-D0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-C0]");
			_ = 0;
			while (true)
			{
				BaseGlobalVariable<int> baseGlobalVariable4 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 176L);
				baseGlobalVariable4.Value = 0;
				if ((int)((long)(IntPtr)obj12 & 1L) == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-A8]");
				BaseGlobalVariable<int> baseGlobalVariable5 = (BaseGlobalVariable<int>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-A8]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					IntPtr intPtr6 = (IntPtr)0;
					IntPtr intPtr7 = (IntPtr)baseGlobalVariable5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ X8_v39 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0313;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ X8_v39 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
					object obj13 = 0L + 8L;
					int num7 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v965 @ X11_v15-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ X8_v39 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
						bool flag3 = (long)num8 < 0L;
						bool flag4 = !flag3;
						obj13 = (long)(IntPtr)obj13 + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_0313;
					}
					object obj14 = obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
					object obj15 = obj14 + 0;
					int num9 = (int)((long)(IntPtr)obj15 << 4);
					object obj16 = (long)intPtr7 + (long)num9;
					object obj17 = (long)(IntPtr)obj16 + 304L;
					goto IL_10ca;
				}
				ex2 = new NullReferenceException();
				goto IL_0eb5;
				IL_0313:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-A8]");
				((BaseGlobalVariable<int>)0).Value = 0;
				goto IL_10ca;
				IL_10ca:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ X0_v52+8]");
				ref RewardedAdButtonComponent component2 = ref ((IEntity)0).GetComponent<RewardedAdButtonComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v998 @ X0_v54 (RewardedAdButtonComponent&)] (should have been resolved before IL gen)");
				GameConfig gameConfig = config;
				EnemySetupClass enemySetupClass;
				if ((object)config != null)
				{
					if ((object)gameConfig.Enemy != null)
					{
						List<EnemySetupClass> enemiesSetup = gameConfig.Enemy.EnemiesSetup;
						int value5 = ((BaseGlobalVariable<int>)gameConfig.Enemy).Value;
						if (gameConfig.Enemy.EnemiesSetup != null)
						{
							bool flag5 = enemiesSetup.Count < value5;
							bool flag6 = !flag5;
							int num10 = enemiesSetup.Count - value5;
							bool flag7 = num10 == 0;
							bool flag8 = !flag7;
							if (!(flag6 && flag8))
							{
								throw new ArgumentOutOfRangeException();
							}
							EnemySetupClass[] items = enemiesSetup._items;
							enemySetupClass = items[value5];
							if (items[value5] != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+14]");
								if ((IntPtr)0 != (IntPtr)0)
								{
									if ((object)LevelReward != null)
									{
										int value6 = LevelReward.Value;
										if ((object)LevelReward != null)
										{
											int value7 = LevelReward.Value;
											int num11 = value7 + value6;
											BaseGlobalVariable<int> baseGlobalVariable6 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 88L);
											baseGlobalVariable6.Value = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+8]");
											if ((IntPtr)0 != (IntPtr)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+8]");
												((TMP_Text)0).text = text;
												intPtr8 = (IntPtr)null;
												text2 = text;
												goto IL_062a;
											}
											ex3 = new NullReferenceException();
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
											intPtr5 = (IntPtr)0;
											obj11 = obj3;
											num5 = 0;
											value4 = 60f;
										}
										else
										{
											ex = new NullReferenceException();
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
											intPtr5 = (IntPtr)0;
											obj11 = obj3;
											num5 = 0;
											ex = ex4;
											value4 = 60f;
										}
									}
									else
									{
										ex4 = new NullReferenceException();
										intPtr5 = intPtr8;
										obj11 = obj3;
										num5 = (int)text2;
										value4 = 60f;
									}
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+10]");
									num = 0f * (float)enemySetupClass.BaseReward;
									BaseGlobalVariable<int> baseGlobalVariable7 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 84L);
									baseGlobalVariable7.Value = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+8]");
									if ((IntPtr)0 != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+8]");
										((TMP_Text)0).text = text3;
										num6 = enemySetupClass.BaseReward;
										intPtr8 = (IntPtr)null;
										text2 = text3;
										goto IL_062a;
									}
									ex5 = new NullReferenceException();
									intPtr5 = intPtr9;
									obj11 = obj3;
									num5 = num12;
									value4 = 60f;
								}
							}
							else
							{
								ex6 = new NullReferenceException();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
								intPtr5 = (IntPtr)0;
								obj11 = obj3;
								num5 = 0;
								value4 = 60f;
							}
						}
						else
						{
							ex = new NullReferenceException();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
							intPtr5 = (IntPtr)0;
							obj11 = obj3;
							num5 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref component2);
							ex = ex7;
							value4 = 60f;
						}
					}
					else
					{
						ex7 = new NullReferenceException();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
						intPtr5 = (IntPtr)0;
						obj11 = obj3;
						num5 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref component2);
						value4 = 60f;
					}
				}
				else
				{
					ex = new NullReferenceException();
					intPtr5 = intPtr4;
					obj11 = obj3;
					num5 = 0;
					ex = ex2;
					value4 = 60f;
				}
				goto IL_0eb5;
				IL_0eb5:
				if (num5 == 1)
				{
					goto IL_0ed5;
				}
				((BaseGlobalVariable<int>)(object)ex8).Value = value8;
				return;
				IL_08eb:
				bool flag9 = obj18 != obj19;
				intPtr4 = intPtr9;
				if (flag9)
				{
					continue;
				}
				if ((object)RewardedSkipped != null)
				{
					bool isPublished = RewardedSkipped.IsPublished;
					bool flag10 = !isPublished;
					intPtr4 = intPtr9;
					if (flag10)
					{
						continue;
					}
					if ((object)Timer != null)
					{
						Timer.Value = 60f;
						object obj20 = (long)(IntPtr)obj - 32L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+10]");
						_ = 0;
						num = (float)obj18;
						object obj21 = (long)(IntPtr)obj - 48L;
						RewardedAdButtonComponent component3 = (RewardedAdButtonComponent)((long)(IntPtr)obj - 304L);
						((RewardedAdPlayerSystem)(object)Timer).RewardedAftermath(component3);
						intPtr4 = intPtr9;
						continue;
					}
					ex = new NullReferenceException();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
					intPtr5 = (IntPtr)0;
					obj11 = obj3;
					num5 = (int)text3;
					ex = ex5;
					value4 = 60f;
				}
				else
				{
					ex = new NullReferenceException();
					intPtr5 = intPtr8;
					obj11 = obj3;
					num5 = 0;
					ex = ex9;
					value4 = 60f;
				}
				goto IL_0eb5;
				IL_062a:
				if ((object)RewardedCompleted != null)
				{
					bool isPublished2 = RewardedCompleted.IsPublished;
					bool flag11 = !isPublished2;
					intPtr9 = intPtr8;
					num12 = 0;
					if (!flag11)
					{
						if ((object)Timer == null)
						{
							ex9 = new NullReferenceException();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
							intPtr5 = (IntPtr)0;
							obj11 = obj3;
							num5 = (int)text;
							ex = ex3;
							value4 = 60f;
							goto IL_0eb5;
						}
						Timer.Value = 60f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+14]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							bool flag12 = (IntPtr)obj19 != (IntPtr)20;
							intPtr9 = intPtr8;
							num = 60f;
							num12 = 0;
							if (!flag12)
							{
								if ((object)Coins != null)
								{
									int value9 = Coins.Value;
									if ((object)LevelReward != null)
									{
										int value10 = LevelReward.Value;
										int value11 = value10 + value9;
										Coins.Value = value11;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+10]");
										_ = 0;
										num = (float)obj18;
										RewardedAdButtonComponent rewardedAdButtonComponent = (RewardedAdButtonComponent)((long)(IntPtr)obj - 240L);
										((RewardedAdPlayerSystem)(object)Coins).RewardedAftermath(rewardedAdButtonComponent);
										intPtr9 = (IntPtr)0;
										num12 = (int)rewardedAdButtonComponent;
										goto IL_08eb;
									}
									ex = new NullReferenceException();
									intPtr5 = intPtr8;
									obj11 = obj3;
									num5 = 0;
									ex = ex10;
									value4 = 60f;
								}
								else
								{
									ex10 = new NullReferenceException();
									intPtr5 = intPtr8;
									obj11 = obj3;
									num5 = 0;
									value4 = 60f;
								}
								goto IL_0eb5;
							}
						}
						else
						{
							bool flag13 = obj19 == null;
							bool flag14 = !flag13;
							intPtr9 = intPtr8;
							num = 60f;
							num12 = 0;
							if (!flag14)
							{
								if ((object)Coins == null)
								{
									NullReferenceException ex11 = new NullReferenceException();
									intPtr5 = intPtr8;
									obj11 = obj3;
									num5 = 0;
									value4 = 60f;
									goto IL_0eb5;
								}
								int value12 = Coins.Value;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+10]");
								object obj22 = 0L * (long)enemySetupClass.BaseReward;
								int value13 = (int)((long)value12 + (long)(IntPtr)obj22);
								Coins.Value = value13;
								object obj23 = (long)(IntPtr)obj - 16L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X0_v56+10]");
								_ = 0;
								num = (float)obj18;
								RewardedAdButtonComponent rewardedAdButtonComponent2 = (RewardedAdButtonComponent)((long)(IntPtr)obj - 272L);
								((RewardedAdPlayerSystem)(object)Coins).RewardedAftermath(rewardedAdButtonComponent2);
								num6 = enemySetupClass.BaseReward;
								intPtr9 = (IntPtr)0;
								num12 = (int)rewardedAdButtonComponent2;
							}
						}
					}
					goto IL_08eb;
				}
				ex = new NullReferenceException();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ X23_v10 (Il2CppMethodInfo)+48]");
				intPtr5 = (IntPtr)0;
				obj11 = obj3;
				num5 = 0;
				ex = ex6;
				value4 = 60f;
				goto IL_0eb5;
			}
			object obj24 = (long)(IntPtr)obj - 56L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ X30_v15-100]");
			object obj25 = 0;
			obj3 = (long)(IntPtr)obj3 + 1L;
			_ = 461;
			BaseGlobalVariable<int> baseGlobalVariable8 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 176L);
			baseGlobalVariable8.Value = 0;
			object obj26 = (long)(IntPtr)obj3 + 1L;
			if (obj26 != null)
			{
				object obj27 = (long)(IntPtr)obj - 56L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ X30_v17-100]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ X8_v33+v683 @ X28_v9*4]");
				if ((IntPtr)0 == (IntPtr)461)
				{
					int num13 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj3);
					obj3 = (long)(IntPtr)obj3 + (long)num13;
					continue;
				}
			}
			bool flag15 = intPtr == (IntPtr)0;
			intPtr = (IntPtr)null;
			if (!flag15)
			{
				intPtr4 = (IntPtr)null;
				intPtr = (IntPtr)null;
				throw new TypeLoadException();
			}
			continue;
			IL_0193:
			baseGlobalVariable2.Value = 0;
			goto IL_1084;
		}
		BaseGlobalVariable<int> baseGlobalVariable9 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 144L);
		baseGlobalVariable9.Value = 0;
		object obj29 = (long)(IntPtr)obj11 + 1L;
		if (obj29 != null)
		{
			if (intPtr != (IntPtr)0)
			{
				object obj30 = (long)(IntPtr)obj - 56L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v846 @ X30_v9-100]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ X8_v13+v98 @ X28_v3*4]");
				if ((IntPtr)0 != (IntPtr)489)
				{
					goto IL_0fae;
				}
			}
		}
		else if (intPtr != (IntPtr)0)
		{
			goto IL_0fae;
		}
		if (InterstitialCompleted.IsPublished)
		{
			Timer.Value = value4;
		}
		return;
		IL_0fae:
		throw new TypeLoadException();
	}

	[Token(Token = "0x6000018")]
	[Address(RVA = "0xCCA484", Offset = "0xCCA484", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EFD428]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, component, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202378C]) = v38;\nL_0015:\n\tv41 = 0;\n\tv43 = component.SuccessEvent == 0;\n\tif (v43) goto L_0033;\n\tv48 = System.Collections.Generic.List`1<Morpeh.Globals.GlobalEvent>::GetEnumerator(component.SuccessEvent);\nL_0022:\n\tv66 = 0xEF9AB0(&v41 @ stack_-38_v1, Il2CppMethodInfo, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv77 = v66 & 1;\n\tv78 = v77 == 0;\n\tif (v78) goto L_0030;\n\tMorpeh.Globals.GlobalEvent::Publish(0);\n\tgoto L_0022;\nL_0030:\n\tv85 = 0xEF9AAC(&v41 @ stack_-38_v1, Il2CppMethodInfo, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0051;\n\tv52 = new System.NullReferenceException();\nL_0033:\n\tv58 = new System.NullReferenceException();\n\tgoto L_003F;\n\tgoto L_003F;\nL_003F:\n\tv76 = Il2CppMethodInfo != 1;\n\tif (v76) goto L_0052;\n\tv79 = 0x6D2BC0(v58, Il2CppMethodInfo, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv87 = 0x6D2490(v79, Il2CppMethodInfo, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv91 = 0xEF9AAC(&v41 @ stack_-38_v1, Il2CppMethodInfo, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv130 = *([v79 @ X0_v10]) == 0;\n\tv93 = ~v130;\n\tif (v93) goto L_0056;\nL_0051:\n\treturn;\nL_0052:\n\tv80 = 0x6D2380(v58, Il2CppMethodInfo, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0056:\n\tthrow System.TypeLoadException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void RewardedAftermath(RewardedAdButtonComponent component)
	{
		//IL_00e5: Expected O, but got I4
		object obj = 0;
		if (component.SuccessEvent != null)
		{
			List<GlobalEvent>.Enumerator enumerator = component.SuccessEvent.GetEnumerator();
			object obj2 = default(object);
			while (true)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EF9AB0");
				if ((int)((long)(IntPtr)obj2 & 1L) == 0)
				{
					break;
				}
				((GlobalEvent)null).Publish();
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EF9AAC");
			return;
		}
		NullReferenceException ex = new NullReferenceException();
		if ((IntPtr)0 == (IntPtr)1)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EF9AAC");
			object obj3 = default(object);
			if (obj3 == null)
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

	[Token(Token = "0x6000019")]
	[Address(RVA = "0xCCA584", Offset = "0xCCA584", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public RewardedAdPlayerSystem()
	{
	}
}
