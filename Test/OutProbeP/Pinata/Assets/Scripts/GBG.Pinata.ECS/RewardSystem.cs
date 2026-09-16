using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using GBG.Pinata.ECS.Components;
using GBG.Pinata.ECS.Systems;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x200000C")]
public class RewardSystem : UpdateSystem
{
	[Required]
	[Token(Token = "0x4000036")]
	[FieldOffset(Offset = "0x28")]
	public GlobalVariableInt Coins;

	[Required]
	[Token(Token = "0x4000037")]
	[FieldOffset(Offset = "0x30")]
	public GlobalVariableInt LevelCoinReward;

	[Required]
	[Token(Token = "0x4000038")]
	[FieldOffset(Offset = "0x38")]
	public GlobalEventInt EnemyIsKicked;

	[Required]
	[Token(Token = "0x4000039")]
	[FieldOffset(Offset = "0x40")]
	public GlobalEvent EnemyIsDead;

	[Required]
	[Token(Token = "0x400003A")]
	[FieldOffset(Offset = "0x48")]
	public GlobalEvent EnemyIsNotDead;

	[Token(Token = "0x400003B")]
	[FieldOffset(Offset = "0x50")]
	private Filter filterHealth;

	[Token(Token = "0x400003C")]
	[FieldOffset(Offset = "0x58")]
	private Filter filterDead;

	[Token(Token = "0x400003D")]
	[FieldOffset(Offset = "0x60")]
	private GameConfig config;

	[Token(Token = "0x600001A")]
	[Address(RVA = "0xCC97EC", Offset = "0xCC97EC", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB3B18]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023787]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tv69 = Morpeh.Filter::Without(v52, 1);\n\tthis.filterHealth = v69;\n\tv53 = Morpeh.FilterProvider::get_All(this.filter);\n\tv54 = Morpeh.Filter::With(v53, 1);\n\tv98 = Morpeh.Filter::With(v54, 1);\n\tthis.filterDead = v98;\n\tv84 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v84;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<HealthComponent>();
		Filter filter2 = filter.Without<EnemyDeadMarker>();
		filterHealth = filter2;
		Filter all2 = Filter.All;
		Filter filter3 = all2.With<HealthComponent>();
		Filter filter4 = filter3.With<EnemyDeadMarker>();
		filterDead = filter4;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x600001B")]
	[Address(RVA = "0xCC98C4", Offset = "0xCC98C4", Length = "0x374")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = *([1ED50E0]);\n\tv31 = *([v30 @ X8_v37]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, deltaTime, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023788]) = v50;\nL_0021:\n\tv59 = Morpeh.Filter::GetEnumerator(this.filterHealth);\n\tv171 = v59.world;\nL_0038:\n\tv318 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(&v171 @ stack_-90_v4 (Morpeh.World), 0);\n\tv367 = v318 & 1;\n\tv368 = v367 == 0;\n\tif (v368) goto L_00AB;\n\tv442 = Il2CppMethodInfo;\n\tv443 = *([v370 @ stack_-68 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv293 = *([v442 @ X21_v16 (Il2CppMethodInfo)+48]);\n\tv446 = *([v443 @ X8_v25 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v446) goto L_0062;\n\tv531 = *([v443 @ X8_v25 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_0049:\n\t;\n\tv536 = *([v531 @ X11_v15-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v536) goto L_0064;\n\tv530 = v530 + 1;\n\tv567 = v530 < *([v443 @ X8_v25 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv471 = ~v567;\n\tv531 = v531 + 0x10;\n\tv455 = ~v471;\n\tif (v455) goto L_0049;\nL_0062:\n\tv574 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v370, Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0069;\nL_0064:\n\t;\n\tv569 = *([v531 @ X11_v15]) + v293;\n\tv570 = v569 << 4;\n\tv571 = v443 + v570;\n\tv574 = v571 + 0x130;\nL_0069:\n\t;\n\tv578 = Morpeh.IEntity::GetComponent(*([v574 @ X0_v61+8]));\n\t*([v578 @ X0_v63 (GBG.Pinata.ECS.Components.HealthComponent&)])(v507, v370, v578, v293, v35, v36, v37, v38, v39, v146, v148, v313, v43, v44, v45, v46, v47);\n\tv297 = this.config;\n\tv268 = v297.Enemy.EnemiesSetup;\n\tv599 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v297.Enemy);\n\tv695 = v268._size < v599;\n\tv288 = ~v695;\n\tv286 = v268._size - v599;\n\tv282 = v286 == 0;\n\tv696 = ~v282;\n\tv272 = v288 & v696;\n\tif (v272) goto L_008E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_008E:\n\tv706 = v268._items;\n\tv315 = v706[v599 @ X0_v67 (System.Int32)];\n\tv306 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.EnemyIsKicked);\n\tv309 = v306 == 0;\n\tif (v309) goto L_0038;\n\tv310 = this.LevelCoinReward == 0;\n\tif (v310) goto L_00B7;\n\tv714 = *([v507 @ X0_v65]) >> 0x20;\n\tv313 = *([v507 @ X0_v65]) - v714;\n\tv716 = v313 / *([v507 @ X0_v65]);\n\tv300 = v716 * v315.BaseReward;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.LevelCoinReward, v300);\n\tgoto L_0038;\nL_00AB:\n\tv374 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(&v171 @ stack_-90_v4 (Morpeh.World), 0);\n\tgoto L_00D9;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv651 = new System.NullReferenceException();\nL_00B7:\n\tv255 = new System.NullReferenceException();\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\nL_00CC:\n\tv209 = v253 != 1;\n\tif (v209) goto L_013C;\n\tv697 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(v255);\n\tv708 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(v697);\n\tv356 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(&v171 @ stack_-90_v4 (Morpeh.World), 0);\n\tv711 = ~v697.m_value;\n\tv358 = ~v711;\n\tif (v358) goto L_0140;\nL_00D9:\n\tv519 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.EnemyIsDead);\n\tv566 = v519 == 0;\n\tif (v566) goto L_0118;\n\tv188 = this.config;\n\tv132 = v188.Enemy.EnemiesSetup;\n\tv657 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v188.Enemy);\n\tv692 = v132._size < v657;\n\tv115 = ~v692;\n\tv110 = v132._size - v657;\n\tv100 = v110 == 0;\n\tv693 = ~v100;\n\tv75 = v115 & v693;\n\tif (v75) goto L_00F8;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00F8:\n\tv699 = v132._items;\n\tv189 = v699[v657 @ X0_v30 (System.Int32)];\n\tv653 = v189.BaseReward << 1;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.LevelCoinReward, v653);\n\tv659 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.Coins);\n\tv719 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.LevelCoinReward);\n\tv613 = v719 + v659;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.Coins, v613);\nL_0118:\n\tv624 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.EnemyIsNotDead);\n\tv672 = v624 == 0;\n\tif (v672) goto L_0138;\n\tv660 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.Coins);\n\tv703 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.LevelCoinReward);\n\tv684 = v703 + v660;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(this.Coins, v684);\nL_0138:\n\treturn;\n\tv177 = new System.NullReferenceException();\n\tv194 = new System.NullReferenceException();\nL_013C:\n\tv263 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(v254);\nL_0140:\n\tthrow System.TypeLoadException;\n// 200 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void OnUpdate(float deltaTime)
	{
		//IL_004e: Expected I, but got O
		//IL_0575: Expected O, but got I
		//IL_009b: Expected O, but got I
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_013c: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_0261: Expected I4, but got O
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_02ac: Expected O, but got I4
		//IL_02b9: Expected O, but got I4
		//IL_0315: Expected O, but got I4
		Filter.EntityEnumerator enumerator = filterHealth.GetEnumerator();
		World world = enumerator.world;
		int[] ids = enumerator.ids;
		World world2 = enumerator.world;
		object obj = default(object);
		BaseGlobalVariable<int> baseGlobalVariable = default(BaseGlobalVariable<int>);
		object obj6 = default(object);
		IntPtr intPtr4 = default(IntPtr);
		NullReferenceException ex2 = default(NullReferenceException);
		while (true)
		{
			((BaseGlobalVariable<int>)(object)world).Value = 0;
			if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
			{
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)baseGlobalVariable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ X21_v16 (Il2CppMethodInfo)+48]");
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ X8_v25 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0100;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ X8_v25 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
				object obj2 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ X11_v15-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ X8_v25 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj2 = (long)(IntPtr)obj2 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_0100;
				}
				object obj3 = obj2 + (long)intPtr3;
				int num3 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr2 + (long)num3;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_0563;
			}
			((BaseGlobalVariable<int>)(object)world).Value = 0;
			goto IL_0355;
			IL_0100:
			baseGlobalVariable.Value = 0;
			goto IL_0563;
			IL_0563:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ X0_v61+8]");
			ref HealthComponent component = ref ((IEntity)0).GetComponent<HealthComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v578 @ X0_v63 (GBG.Pinata.ECS.Components.HealthComponent&)] (should have been resolved before IL gen)");
			GameConfig gameConfig = config;
			List<EnemySetupClass> enemiesSetup = gameConfig.Enemy.EnemiesSetup;
			int value = ((BaseGlobalVariable<int>)gameConfig.Enemy).Value;
			bool flag3 = enemiesSetup.Count < value;
			bool flag4 = !flag3;
			int num4 = enemiesSetup.Count - value;
			bool flag5 = num4 == 0;
			bool flag6 = !flag5;
			if (!(flag4 && flag6))
			{
				throw new ArgumentOutOfRangeException();
			}
			EnemySetupClass[] items = enemiesSetup._items;
			EnemySetupClass enemySetupClass = items[value];
			if (!EnemyIsKicked)
			{
				continue;
			}
			if ((object)LevelCoinReward != null)
			{
				int num5 = obj6 >> 32;
				object obj7 = obj6 - num5;
				object obj8 = (long)(IntPtr)obj7 / obj6;
				int num6 = (int)((long)(IntPtr)obj8 * (long)enemySetupClass.BaseReward);
				LevelCoinReward.Value = num6;
				IntPtr intPtr3 = (IntPtr)0;
				ids = (int[])num6;
				world2 = (World)enemySetupClass.BaseReward;
				continue;
			}
			NullReferenceException ex = new NullReferenceException();
			if (intPtr4 == (IntPtr)1)
			{
				bool flag7 = (BaseGlobalEvent<int>)(object)ex;
				bool flag8 = (BaseGlobalEvent<int>)flag7;
				((BaseGlobalVariable<int>)(object)world).Value = 0;
				if (((bool*)(flag7 ? 1 : 0))->m_value)
				{
					break;
				}
				goto IL_0355;
			}
			bool flag9 = (BaseGlobalEvent<int>)(object)ex2;
			break;
			IL_0355:
			if ((bool)EnemyIsDead)
			{
				GameConfig gameConfig2 = config;
				List<EnemySetupClass> enemiesSetup2 = gameConfig2.Enemy.EnemiesSetup;
				int value2 = ((BaseGlobalVariable<int>)gameConfig2.Enemy).Value;
				bool flag10 = enemiesSetup2.Count < value2;
				bool flag11 = !flag10;
				int num7 = enemiesSetup2.Count - value2;
				bool flag12 = num7 == 0;
				bool flag13 = !flag12;
				if (!(flag11 && flag13))
				{
					throw new ArgumentOutOfRangeException();
				}
				EnemySetupClass[] items2 = enemiesSetup2._items;
				EnemySetupClass enemySetupClass2 = items2[value2];
				int value3 = enemySetupClass2.BaseReward << 1;
				LevelCoinReward.Value = value3;
				int value4 = Coins.Value;
				int value5 = LevelCoinReward.Value;
				int value6 = value5 + value4;
				Coins.Value = value6;
			}
			if ((bool)EnemyIsNotDead)
			{
				int value7 = Coins.Value;
				int value8 = LevelCoinReward.Value;
				int value9 = value8 + value7;
				Coins.Value = value9;
			}
			return;
		}
		throw new TypeLoadException();
	}

	[Token(Token = "0x600001C")]
	[Address(RVA = "0xCC9C38", Offset = "0xCC9C38", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public RewardSystem()
	{
	}
}
