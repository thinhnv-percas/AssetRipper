using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using GBG.Pinata.ECS.UI.Components;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200006A")]
	public class EnemyHealthSystem : UpdateSystem
	{
		[Required]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEvent EnemyIsDead;

		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x30")]
		private Filter filterNonInitialized;

		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x38")]
		private Filter filterInitializedAndAlive;

		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x40")]
		private Filter filterProgressBar;

		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x48")]
		private GameConfig config;

		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x50")]
		private GlobalEventInt enemyIsKicked;

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0xCC4EB8", Offset = "0xCC4EB8", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC6D70]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023764]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv56 = Morpeh.Filter::With(v42, 1);\n\tv57 = Morpeh.Filter::With(v56, 1);\n\tv117 = Morpeh.Filter::Without(v57, 1);\n\tthis.filterNonInitialized = v117;\n\tv58 = Morpeh.Filter::With(v57, 1);\n\tv83 = Morpeh.Filter::Without(v58, 1);\n\tthis.filterInitializedAndAlive = v83;\n\tv59 = Morpeh.FilterProvider::get_All(this.filter);\n\tv124 = Morpeh.Filter::With(v59, 1);\n\tthis.filterProgressBar = v124;\n\tv60 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v60;\n\tv101 = System.Collections.Generic.Dictionary`2<System.String, Morpeh.Globals.GlobalEventInt>::get_Item(v60.GlobalEventsInt, \"EnemyIsKicked\");\n\tthis.enemyIsKicked = v101;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<EnemyComponent>();
			Filter filter2 = filter.With<HealthComponent>();
			Filter filter3 = filter2.Without<InitEnemyHealthMarker>();
			filterNonInitialized = filter3;
			Filter filter4 = filter2.With<InitEnemyHealthMarker>();
			Filter filter5 = filter4.Without<EnemyDeadMarker>();
			filterInitializedAndAlive = filter5;
			Filter all2 = Filter.All;
			Filter filter6 = all2.With<ProgressIndicatorComponent>();
			filterProgressBar = filter6;
			GlobalEventInt globalEventInt = ((Dictionary<string, GlobalEventInt>)(config = GameConfig.Instance).GlobalEventsInt).get_Item("EnemyIsKicked");
			enemyIsKicked = globalEventInt;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0xCC5000", Offset = "0xCC5000", Length = "0x8BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EE58D0]);\n\tv37 = *([v36 @ X8_v108]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, deltaTime, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2023765]) = v56;\nL_001F:\n\tv60 = this.filterProgressBar;\n\tv62 = v60.world;\n\tv63 = v60.entitiesCacheForBags;\n\tv64 = v62.Entities;\n\tv65 = v63[0];\n\tv68 = v64[v65 @ X8_v75 (System.Int32)];\n\tv227 = *([v68 @ X20_v27 (Morpeh.Entity)]);\n\tv184 = Il2CppMethodInfo;\n\tv170 = *([v184 @ X21_v28 (Il2CppMethodInfo)+48]);\n\tv230 = *([v227 @ X8_v77 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v230) goto L_0050;\n\tv352 = *([v227 @ X8_v77 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_003C:\n\tv357 = *([v352 @ X11_v67-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v357) goto L_0053;\n\tv351 = v351 + 1;\n\tv462 = v351 < *([v227 @ X8_v77 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv294 = ~v462;\n\tv352 = v352 + 0x10;\n\tv278 = ~v294;\n\tif (v278) goto L_003C;\nL_0050:\n\tv469 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v64[v65 @ X8_v75 (System.Int32)], Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0059;\nL_0053:\n\tv464 = *([v352 @ X11_v67]) + v170;\n\tv465 = v464 << 4;\n\tv466 = v227 + v465;\n\tv469 = v466 + 0x130;\nL_0059:\n\tv473 = Morpeh.IEntity::GetComponent(*([v469 @ X0_v126+8]));\n\t*([v473 @ X0_v128 (GBG.Pinata.ECS.UI.Components.ProgressIndicatorComponent&)])(v200, v64[v65 @ X8_v75 (System.Int32)], v473, v170, v41, v42, v43, v44, v45, 0, v47, v48, v49, v50, v51, v52, v53);\n\tv729 = this.filterNonInitialized;\n\tv240 = v729.Length < 1;\n\tif (v240) goto L_0132;\nL_0075:\n\tv730 = v729.world;\n\tv195 = v730.Entities;\n\tv183 = v195[v731[v88 @ X25_v30 (System.Int32)]];\n\tv911 = Il2CppMethodInfo;\n\tv912 = *([v183 @ X21_v30 (Morpeh.Entity)]);\n\tv915 = *([v912 @ X8_v88 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v915) goto L_00A5;\n\tv1146 = *([v912 @ X8_v88 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0091:\n\tv1151 = *([v1146 @ X11_v62-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1151) goto L_00A8;\n\tv1145 = v1145 + 1;\n\tv1227 = v1145 < *([v912 @ X8_v88 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv1055 = ~v1227;\n\tv1146 = v1146 + 0x10;\n\tv1039 = ~v1055;\n\tif (v1039) goto L_0091;\nL_00A5:\n\tv1234 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v195[v731[v88 @ X25_v30 (System.Int32)]], Il2CppClass<Morpeh.IEntity>);\n\tgoto L_00AE;\nL_00A8:\n\tv1229 = *([v1146 @ X11_v62]) + *([v911 @ X22_v32 (Il2CppMethodInfo)+48]);\n\tv1230 = v1229 << 4;\n\tv1231 = v912 + v1230;\n\tv1234 = v1231 + 0x130;\nL_00AE:\n\tv1238 = Morpeh.IEntity::GetComponent(*([v1234 @ X0_v132+8]));\n\t*([v1238 @ X0_v134 (GBG.Pinata.ECS.Components.HealthComponent&)])(v202, v195[v731[v88 @ X25_v30 (System.Int32)]], v1238, *([v911 @ X22_v32 (Il2CppMethodInfo)+48]), v41, v42, v43, v44, v45, 0, v47, v48, v49, v50, v51, v52, v53);\n\tv217 = this.config;\n\tv80 = v217.Enemy.EnemiesSetup;\n\tv203 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v217.Enemy);\n\tv1555 = v80._size < v203;\n\tv157 = ~v1555;\n\tv150 = v80._size - v203;\n\tv136 = v150 == 0;\n\tv1556 = ~v136;\n\tv101 = v157 & v1556;\n\tif (v101) goto L_00D2;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00D2:\n\tv1603 = v80._items;\n\tv219 = v1603[v203 @ X0_v138 (System.Int32)];\n\t*([v202 @ X0_v136]) = v219.Health;\n\t*([v202 @ X0_v136+4]) = v219.Health;\n\tv220 = this.config;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v220.Enemy.CurrentEnemyHealth, v219.Health);\n\tUnityEngine.UI.Image::set_sprite(*([v200 @ X0_v130 (Morpeh.Entity)+8]), v200.InternalID);\n\tv83 = Il2CppMethodInfo;\n\tv1952 = *([v183 @ X21_v30 (Morpeh.Entity)]);\n\tv170 = *([v83 @ X22_v34 (Il2CppMethodInfo)+48]);\n\tv266 = *([v1952 @ X8_v99 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v266) goto L_010C;\n\tv2000 = *([v1952 @ X8_v99 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00F8:\n\tv2005 = *([v2000 @ X11_v57-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v2005) goto L_010F;\n\tv1999 = v1999 + 1;\n\tv2014 = v1999 < *([v1952 @ X8_v99 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv1978 = ~v2014;\n\tv2000 = v2000 + 0x10;\n\tv1962 = ~v1978;\n\tif (v1962) goto L_00F8;\nL_010C:\n\tv2030 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v195[v731[v88 @ X25_v30 (System.Int32)]], Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0115;\nL_010F:\n\tv2016 = *([v2000 @ X11_v57]) + v170;\n\tv2017 = v2016 << 4;\n\tv2018 = v1952 + v2017;\n\tv2030 = v2018 + 0x130;\nL_0115:\n\tv2034 = Morpeh.IEntity::AddComponent(*([v2030 @ X0_v142+8]));\n\t*([v2034 @ X0_v144 (GBG.Pinata.ECS.Systems.InitEnemyHealthMarker&)])(v199, v195[v731[v88 @ X25_v30 (System.Int32)]], v2034, v170, v41, v42, v43, v44, v45, 0, v47, v48, v49, v50, v51, v52, v53);\n\tv88 = v88 + 1;\n\tv96 = v88 >= v729.Length;\n\tif (v96) goto L_0132;\n\tv729 = this.filterNonInitialized;\n\tv2049 = this.filterNonInitialized == 0;\n\tv206 = ~v2049;\n\tif (v206) goto L_0075;\n\tthrow System.NullReferenceException;\nL_0132:\n\tv304 = Morpeh.Filter::GetEnumerator(this.filterInitializedAndAlive);\n\tv362 = v304.world;\nL_0147:\n\tv454 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(&v362 @ stack_-B0_v22 (Morpeh.World), 0);\n\tv595 = v454 & 1;\n\tv596 = v595 == 0;\n\tif (v596) goto L_02FA;\n\tv656 = *([v420 @ X24_v27 (Il2CppMethodInfo)]);\n\tv657 = *([v602 @ stack_-88 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv661 = *([v657 @ X8_v29 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v661) goto L_0171;\n\tv927 = *([v657 @ X8_v29 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_0158:\n\t;\n\tv932 = *([v927 @ X11_v47-8]) == *([v656 @ X22_v26+18]);\n\tif (v932) goto L_0173;\n\tv926 = v926 + 1;\n\tv1062 = v926 < *([v657 @ X8_v29 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv757 = ~v1062;\n\tv927 = v927 + 0x10;\n\tv741 = ~v757;\n\tif (v741) goto L_0158;\nL_0171:\n\tv1082 = 0x8909C4(v602, *([v656 @ X22_v26+18]), *([v656 @ X22_v26+48]), v41, v42, v43, v44, v45, v390, v392, v48, v49, v50, v51, v52, v53);\n\tgoto L_0178;\nL_0173:\n\t;\n\tv1064 = *([v927 @ X11_v47]) + *([v656 @ X22_v26+48]);\n\tv1065 = v1064 << 4;\n\tv1066 = v657 + v1065;\n\tv1082 = v1066 + 0x130;\nL_0178:\n\t;\n\tv1086 = 0x8D8294(*([v1082 @ X0_v70+8]), v656, *([v656 @ X22_v26+48]), v41, v42, v43, v44, v45, v390, v392, v48, v49, v50, v51, v52, v53);\n\t*([v1086 @ X0_v72])(v1160, v602, v1086, *([v656 @ X22_v26+48]), v41, v42, v43, v44, v45, v390, v392, v48, v49, v50, v51, v52, v53);\n\tv1161 = Il2CppMethodInfo;\n\tv1162 = *([v602 @ stack_-88 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv1165 = *([v1162 @ X8_v32 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v1165) goto L_01A4;\n\tv1339 = *([v1162 @ X8_v32 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_018B:\n\t;\n\tv1344 = *([v1339 @ X11_v42-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1344) goto L_01A6;\n\tv1338 = v1338 + 1;\n\tv1397 = v1338 < *([v1162 @ X8_v32 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv1261 = ~v1397;\n\tv1339 = v1339 + 0x10;\n\tv1245 = ~v1261;\n\tif (v1245) goto L_018B;\nL_01A4:\n\tv1404 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v602, Il2CppClass<Morpeh.IEntity>);\n\tgoto L_01AB;\nL_01A6:\n\t;\n\tv1399 = *([v1339 @ X11_v42]) + *([v1161 @ X22_v27 (Il2CppMethodInfo)+48]);\n\tv1400 = v1399 << 4;\n\tv1401 = v1162 + v1400;\n\tv1404 = v1401 + 0x130;\nL_01AB:\n\t;\n\tv1408 = Morpeh.IEntity::GetComponent(*([v1404 @ X0_v75+8]));\n\t*([v1408 @ X0_v77 (GBG.Pinata.ECS.Components.HealthComponent&)])(v1459, v602, v1408, *([v1161 @ X22_v27 (Il2CppMethodInfo)+48]), v41, v42, v43, v44, v45, v390, v392, v48, v49, v50, v51, v52, v53);\n\tv1027 = UnityEngine.GameObject::GetComponent /* +53 sharing this address */(*([v1160 @ X0_v74]), *([v485 @ X28_v29 (Il2CppMethodInfo)]));\n\tv1128 = Morpeh.EntityProvider::get_Entity(v1027);\n\tv1713 = Il2CppMethodInfo;\n\tv1714 = *([v1128 @ X0_v82 (Morpeh.IEntity)]);\n\tv170 = *([v1713 @ X25_v26 (Il2CppMethodInfo)+48]);\n\tv1717 = *([v1714 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v1717) goto L_01E5;\n\tv1849 = *([v1714 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_01CC:\n\t;\n\tv1854 = *([v1849 @ X11_v37-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1854) goto L_01E7;\n\tv1848 = v1848 + 1;\n\tv1924 = v1848 < *([v1714 @ X8_\n// ... truncated")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_005c: Expected I, but got O
			//IL_0ecd: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_055f: Expected F4, but got O
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected O, but got Unknown
			//IL_0156: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_00f9: Expected O, but got I
			//IL_0585: Expected O, but got I
			//IL_058d: Expected I, but got O
			//IL_01b0: Expected I, but got O
			//IL_103f: Expected I, but got O
			//IL_05cc: Expected O, but got I
			//IL_0f1d: Expected O, but got I
			//IL_01eb: Expected O, but got I
			//IL_109b: Expected O, but got I
			//IL_069e: Expected O, but got I
			//IL_0651: Unknown result type (might be due to invalid IL or missing references)
			//IL_0656: Expected O, but got Unknown
			//IL_0673: Expected O, but got I
			//IL_0682: Expected O, but got I
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Expected O, but got Unknown
			//IL_02a4: Expected O, but got I
			//IL_02b3: Expected O, but got I
			//IL_0618: Expected O, but got I
			//IL_0237: Expected O, but got I
			//IL_0724: Unknown result type (might be due to invalid IL or missing references)
			//IL_0729: Expected O, but got Unknown
			//IL_0746: Expected O, but got I
			//IL_0755: Expected O, but got I
			//IL_0381: Expected O, but got I4
			//IL_078a: Expected I, but got O
			//IL_06ea: Expected O, but got I
			//IL_03d5: Expected O, but got I4
			//IL_03d5: Expected O, but got I
			//IL_03e3: Expected I, but got O
			//IL_10e5: Expected O, but got I
			//IL_07d7: Expected O, but got I
			//IL_0f6d: Expected O, but got I
			//IL_042e: Expected O, but got I
			//IL_0b11: Expected O, but got I
			//IL_0856: Unknown result type (might be due to invalid IL or missing references)
			//IL_085b: Expected O, but got Unknown
			//IL_0878: Expected O, but got I
			//IL_0887: Expected O, but got I
			//IL_0823: Expected O, but got I
			//IL_04be: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Expected O, but got Unknown
			//IL_04e0: Expected O, but got I
			//IL_04ef: Expected O, but got I
			//IL_08d6: Expected O, but got I
			//IL_047a: Expected O, but got I
			//IL_0b98: Expected O, but got I
			//IL_0ba6: Expected I, but got O
			//IL_09bd: Expected O, but got I
			//IL_09cd: Expected O, but got I
			//IL_1176: Expected O, but got I
			//IL_0bf3: Expected O, but got I
			//IL_09e2: Expected O, but got I
			//IL_09f9: Expected O, but got I
			//IL_0a09: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a0e: Expected O, but got Unknown
			//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a34: Expected O, but got Unknown
			//IL_0c8d: Expected O, but got I
			//IL_0d98: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d9d: Expected O, but got Unknown
			//IL_0dba: Expected O, but got I
			//IL_0dc9: Expected O, but got I
			//IL_0c3f: Expected O, but got I
			//IL_0af7: Expected I4, but got O
			//IL_0d25: Expected O, but got I
			//IL_0d3c: Expected O, but got I
			//IL_0d62: Expected O, but got I
			//IL_0d89: Expected I, but got O
			Filter filter = filterProgressBar;
			World world = filter.world;
			int[] entitiesCacheForBags = filter.entitiesCacheForBags;
			Entity[] entities = world.Entities;
			int num = entitiesCacheForBags[0];
			Entity entity = entities[num];
			IntPtr intPtr = (IntPtr)entity;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X21_v28 (Il2CppMethodInfo)+48]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v77 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0112;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v77 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ X11_v67-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ X8_v77 (Il2CppClass<Morpeh.Entity>)+126]");
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
			goto IL_0ebc;
			IL_0112:
			((BaseGlobalVariable<int>)(object)entities[num]).Value = 0;
			goto IL_0ebc;
			IL_0ebc:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ X0_v126+8]");
			ref ProgressIndicatorComponent component = ref ((IEntity)0).GetComponent<ProgressIndicatorComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v473 @ X0_v128 (GBG.Pinata.ECS.UI.Components.ProgressIndicatorComponent&)] (should have been resolved before IL gen)");
			Filter filter2 = filterNonInitialized;
			bool flag3 = filter2.Length < 1;
			Entity entity3 = default(Entity);
			Entity entity2 = entity3;
			if (!flag3)
			{
				int num5 = 0;
				int[] array = default(int[]);
				while (true)
				{
					World world2 = filter2.world;
					Entity[] entities2 = world2.Entities;
					Entity entity4 = entities2[array[num5]];
					IntPtr intPtr4 = (IntPtr)0;
					IntPtr intPtr5 = (IntPtr)entity4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ X8_v88 (Il2CppClass<Morpeh.Entity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0250;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ X8_v88 (Il2CppClass<Morpeh.Entity>)+B0]");
					object obj5 = 0L + 8L;
					int num6 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1146 @ X11_v62-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num6++;
						int num7 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ X8_v88 (Il2CppClass<Morpeh.Entity>)+126]");
						bool flag4 = (long)num7 < 0L;
						bool flag5 = !flag4;
						obj5 = (long)(IntPtr)obj5 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_0250;
					}
					object obj6 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ X22_v32 (Il2CppMethodInfo)+48]");
					object obj7 = obj6 + 0;
					int num8 = (int)((long)(IntPtr)obj7 << 4);
					object obj8 = (long)intPtr5 + (long)num8;
					object obj9 = (long)(IntPtr)obj8 + 304L;
					goto IL_0f0c;
					IL_0f0c:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1234 @ X0_v132+8]");
					ref HealthComponent component2 = ref ((IEntity)0).GetComponent<HealthComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1238 @ X0_v134 (GBG.Pinata.ECS.Components.HealthComponent&)] (should have been resolved before IL gen)");
					GameConfig gameConfig = config;
					List<EnemySetupClass> enemiesSetup = gameConfig.Enemy.EnemiesSetup;
					int value = ((BaseGlobalVariable<int>)gameConfig.Enemy).Value;
					bool flag6 = enemiesSetup.Count < value;
					bool flag7 = !flag6;
					int num9 = enemiesSetup.Count - value;
					bool flag8 = num9 == 0;
					bool flag9 = !flag8;
					if (!(flag7 && flag9))
					{
						throw new ArgumentOutOfRangeException();
					}
					EnemySetupClass[] items = enemiesSetup._items;
					EnemySetupClass enemySetupClass = items[value];
					object obj10 = enemySetupClass.Health;
					_ = enemySetupClass.Health;
					GameConfig gameConfig2 = config;
					gameConfig2.Enemy.CurrentEnemyHealth.Value = enemySetupClass.Health;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ X0_v130 (Morpeh.Entity)+8]");
					((Image)0).sprite = (Sprite)entity3.ID;
					IntPtr intPtr6 = (IntPtr)0;
					IntPtr intPtr7 = (IntPtr)entity4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X22_v34 (Il2CppMethodInfo)+48]");
					intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1952 @ X8_v99 (Il2CppClass<Morpeh.Entity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0493;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1952 @ X8_v99 (Il2CppClass<Morpeh.Entity>)+B0]");
					object obj11 = 0L + 8L;
					int num10 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2000 @ X11_v57-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num10++;
						int num11 = num10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1952 @ X8_v99 (Il2CppClass<Morpeh.Entity>)+126]");
						bool flag10 = (long)num11 < 0L;
						bool flag11 = !flag10;
						obj11 = (long)(IntPtr)obj11 + 16L;
						if (!flag11)
						{
							continue;
						}
						goto IL_0493;
					}
					object obj12 = obj11 + (long)intPtr3;
					int num12 = (int)((long)(IntPtr)obj12 << 4);
					object obj13 = (long)intPtr7 + (long)num12;
					object obj14 = (long)(IntPtr)obj13 + 304L;
					goto IL_0f5c;
					IL_0f5c:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2030 @ X0_v142+8]");
					ref InitEnemyHealthMarker reference = ref ((IEntity)0).AddComponent<InitEnemyHealthMarker>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2034 @ X0_v144 (GBG.Pinata.ECS.Systems.InitEnemyHealthMarker&)] (should have been resolved before IL gen)");
					num5++;
					bool flag12 = num5 >= filter2.Length;
					entity2 = entity3;
					if (flag12)
					{
						break;
					}
					filter2 = filterNonInitialized;
					bool flag13 = filterNonInitialized == null;
					bool flag14 = !flag13;
					entity2 = entity3;
					if (!flag14)
					{
						throw new NullReferenceException();
					}
					continue;
					IL_0493:
					((BaseGlobalVariable<int>)(object)entities2[array[num5]]).Value = 0;
					goto IL_0f5c;
					IL_0250:
					((BaseGlobalVariable<int>)(object)entities2[array[num5]]).Value = 0;
					goto IL_0f0c;
				}
			}
			Filter.EntityEnumerator enumerator = filterInitializedAndAlive.GetEnumerator();
			World world3 = enumerator.world;
			float num13 = (float)enumerator.ids;
			World world4 = enumerator.world;
			IntPtr intPtr8 = (IntPtr)0;
			IntPtr intPtr9 = (IntPtr)0;
			object obj15 = default(object);
			BaseGlobalVariable<int> baseGlobalVariable = default(BaseGlobalVariable<int>);
			object obj23 = default(object);
			object obj27 = default(object);
			IntPtr intPtr12;
			World world7;
			EntityProvider entityProvider = default(EntityProvider);
			while (true)
			{
				((BaseGlobalVariable<int>)(object)world3).Value = 0;
				if ((uint)((ulong)(long)(IntPtr)obj15 & 1uL) != 0)
				{
					object obj16 = (long)intPtr9;
					IntPtr intPtr10 = (IntPtr)baseGlobalVariable;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ X8_v29 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0631;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ X8_v29 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
					object obj17 = 0L + 8L;
					int num14 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v927 @ X11_v47-8]");
						IntPtr intPtr11 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ X22_v26+18]");
						if (intPtr11 == (IntPtr)0)
						{
							break;
						}
						num14++;
						int num15 = num14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ X8_v29 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
						bool flag15 = (long)num15 < 0L;
						bool flag16 = !flag15;
						obj17 = (long)(IntPtr)obj17 + 16L;
						if (!flag16)
						{
							continue;
						}
						goto IL_0631;
					}
					object obj18 = obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ X22_v26+48]");
					object obj19 = obj18 + 0;
					int num16 = (int)((long)(IntPtr)obj19 << 4);
					object obj20 = (long)intPtr10 + (long)num16;
					object obj21 = (long)(IntPtr)obj20 + 304L;
					goto IL_101b;
				}
				((BaseGlobalVariable<int>)(object)world3).Value = 0;
				return;
				IL_10d3:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1931 @ X0_v83+8]");
				ref EnemyPartsComponent component3 = ref ((IEntity)0).GetComponent<EnemyPartsComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1935 @ X0_v85 (GBG.Pinata.ECS.Components.EnemyPartsComponent&)] (should have been resolved before IL gen)");
				object obj22 = obj23;
				object obj26;
				if ((bool)enemyIsKicked)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ X0_v74+20]");
					((ParticleSystem)0).Play(withChildren: true);
					GameConfig gameConfig3 = config;
					WeaponSetup value2 = gameConfig3.Weapon.Data.Value;
					GameConfig gameConfig4 = config;
					int value3 = ((BaseGlobalVariable<int>)gameConfig4.Weapon).Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1546 @ X0_v104 (GBG.Pinata.ECS.WeaponSetup)+18]");
					bool flag17 = 0L < (long)value3;
					bool flag18 = !flag17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1546 @ X0_v104 (GBG.Pinata.ECS.WeaponSetup)+18]");
					int num17 = (int)(-value3);
					bool flag19 = num17 == 0;
					bool flag20 = !flag19;
					if (!(flag18 && flag20))
					{
						throw new ArgumentOutOfRangeException();
					}
					int num18 = value3 << 3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1546 @ X0_v104 (GBG.Pinata.ECS.WeaponSetup)+10]");
					object obj24 = 0L + (long)num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2101 @ X8_v59+20]");
					object obj25 = 0;
					obj26 = (long)(IntPtr)obj27 + 4L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X25_v27+18]");
					object obj28 = 0L + 1L;
					object obj29 = obj26;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ X8_v60+30]");
					World world5 = (World)(obj29 - 0);
					obj26 = world5;
					float num19 = (float)obj27 / (float)obj28;
					World world6 = (World)(obj27 - (long)(IntPtr)world5);
					bool flag21 = num19 < (float)world6;
					bool flag22 = !flag21;
					float num20 = num19 - (float)world6;
					bool flag23 = num20 == 0f;
					bool flag24 = !flag22;
					bool flag25 = flag24 || flag23;
					intPtr12 = (IntPtr)0;
					if (flag25)
					{
						float num21 = (float)world5 / num19;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X25_v27+18]");
						object obj30 = -1;
						bool flag26 = (float)obj30 < num21;
						intPtr12 = (IntPtr)0;
						if (!flag26)
						{
							bool flag27 = num21 < float.Epsilon;
							intPtr12 = (IntPtr)0;
							if (!flag27)
							{
								do
								{
									object obj31 = obj30;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X25_v27+18]");
									if ((long)(IntPtr)obj31 < 0L)
									{
										int num22 = (int)((long)(IntPtr)obj30 << 3);
										object obj32 = (long)(IntPtr)obj22 + (long)num22;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ X8_v65+20]");
										GameObject gameObject = ((Component)0).gameObject;
										gameObject.SetActive(value: false);
										obj30 = (long)(IntPtr)obj30 - 1L;
										continue;
									}
									IndexOutOfRangeException ex = new IndexOutOfRangeException();
									throw ex;
								}
								while (!((float)obj30 < num21));
								intPtr12 = (IntPtr)null;
							}
						}
					}
					GameConfig gameConfig5 = config;
					bool flag28 = (object)gameConfig5.Enemy.CurrentEnemyHealth == null;
					world7 = enumerator.world;
					if (flag28)
					{
						break;
					}
					gameConfig5.Enemy.CurrentEnemyHealth.Value = (int)obj26;
					intPtr3 = (IntPtr)0;
				}
				else
				{
					obj26 = (long)(IntPtr)obj27 + 4L;
				}
				object obj33 = obj27 - obj26;
				num13 = (float)obj33 / (float)obj27;
				((Image)(object)entity2).fillAmount = num13;
				bool flag29 = (long)(IntPtr)obj26 > 0L;
				world4 = (World)obj27;
				intPtr9 = (IntPtr)0;
				if (flag29)
				{
					continue;
				}
				EnemyIsDead.Publish();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ X20_v25 (Morpeh.Entity)+8]");
				((Image)0).sprite = (Sprite)entity2.ComponentsMask;
				IntPtr intPtr13 = (IntPtr)0;
				IntPtr intPtr14 = (IntPtr)baseGlobalVariable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ X22_v29 (Il2CppMethodInfo)+48]");
				intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2064 @ X8_v47 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0c58;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2064 @ X8_v47 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
				object obj34 = 0L + 8L;
				int num23 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2113 @ X11_v32-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num23++;
					int num24 = num23;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2064 @ X8_v47 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					bool flag30 = (long)num24 < 0L;
					bool flag31 = !flag30;
					obj34 = (long)(IntPtr)obj34 + 16L;
					if (!flag31)
					{
						continue;
					}
					goto IL_0c58;
				}
				object obj35 = obj34 + (long)intPtr3;
				int num25 = (int)((long)(IntPtr)obj35 << 4);
				object obj36 = (long)intPtr14 + (long)num25;
				object obj37 = (long)(IntPtr)obj36 + 304L;
				goto IL_1164;
				IL_1089:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1404 @ X0_v75+8]");
				ref HealthComponent component4 = ref ((IEntity)0).GetComponent<HealthComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1408 @ X0_v77 (GBG.Pinata.ECS.Components.HealthComponent&)] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @ACCB14 (UnityEngine.GameObject::GetComponent, and 53 more at this address)");
				IEntity entity5 = entityProvider.Entity;
				IntPtr intPtr15 = (IntPtr)0;
				IntPtr intPtr16 = (IntPtr)entity5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1713 @ X25_v26 (Il2CppMethodInfo)+48]");
				intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1714 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_083c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1714 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+B0]");
				object obj38 = 0L + 8L;
				int num26 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1849 @ X11_v37-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num26++;
					int num27 = num26;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1714 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+126]");
					bool flag32 = (long)num27 < 0L;
					bool flag33 = !flag32;
					obj38 = (long)(IntPtr)obj38 + 16L;
					if (!flag33)
					{
						continue;
					}
					goto IL_083c;
				}
				object obj39 = obj38 + (long)intPtr3;
				int num28 = (int)((long)(IntPtr)obj39 << 4);
				object obj40 = (long)intPtr16 + (long)num28;
				object obj41 = (long)(IntPtr)obj40 + 304L;
				goto IL_10d3;
				IL_0703:
				baseGlobalVariable.Value = 0;
				goto IL_1089;
				IL_0c58:
				baseGlobalVariable.Value = 0;
				goto IL_1164;
				IL_0631:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_101b;
				IL_101b:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1086 @ X0_v72] (should have been resolved before IL gen)");
				IntPtr intPtr17 = (IntPtr)0;
				IntPtr intPtr18 = (IntPtr)baseGlobalVariable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ X8_v32 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0703;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ X8_v32 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
				object obj42 = 0L + 8L;
				int num29 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1339 @ X11_v42-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num29++;
					int num30 = num29;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1162 @ X8_v32 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
					bool flag34 = (long)num30 < 0L;
					bool flag35 = !flag34;
					obj42 = (long)(IntPtr)obj42 + 16L;
					if (!flag35)
					{
						continue;
					}
					goto IL_0703;
				}
				object obj43 = obj42;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1161 @ X22_v27 (Il2CppMethodInfo)+48]");
				object obj44 = obj43 + 0;
				int num31 = (int)((long)(IntPtr)obj44 << 4);
				object obj45 = (long)intPtr18 + (long)num31;
				object obj46 = (long)(IntPtr)obj45 + 304L;
				goto IL_1089;
				IL_1164:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2150 @ X0_v94+8]");
				ref EnemyDeadMarker reference2 = ref ((IEntity)0).AddComponent<EnemyDeadMarker>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2154 @ X0_v96 (GBG.Pinata.ECS.Systems.EnemyDeadMarker&)] (should have been resolved before IL gen)");
				world4 = (World)obj27;
				intPtr9 = (IntPtr)0;
				continue;
				IL_083c:
				((BaseGlobalVariable<int>)entity5).Value = 0;
				goto IL_10d3;
			}
			NullReferenceException ex2 = new NullReferenceException();
			if (intPtr12 == (IntPtr)1)
			{
				((BaseGlobalVariable<int>)(object)ex2).Value = (int)(long)intPtr12;
				BaseGlobalVariable<int> baseGlobalVariable2 = default(BaseGlobalVariable<int>);
				baseGlobalVariable2.Value = (int)(long)intPtr12;
				((BaseGlobalVariable<int>)(object)world7).Value = 0;
				if ((object)baseGlobalVariable2 == null)
				{
					return;
				}
			}
			else
			{
				((BaseGlobalVariable<int>)(object)ex2).Value = (int)(long)intPtr12;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0xCC58BC", Offset = "0xCC58BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnemyHealthSystem()
		{
		}
	}
}
