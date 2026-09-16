using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000067")]
	public class CollisionEnemiesSystem : UpdateSystem
	{
		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x30")]
		private GlobalEventInt enemyIsKicked;

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0xCC4A10", Offset = "0xCC4A10", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED4170]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023762]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv58 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v58;\n\tv48 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tv69 = System.Collections.Generic.Dictionary`2<System.String, Morpeh.Globals.GlobalEventInt>::get_Item(v48.GlobalEventsInt, \"EnemyIsKicked\");\n\tthis.enemyIsKicked = v69;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<EnemyComponent>();
			this.filter = filter;
			GameConfig instance = GameConfig.Instance;
			GlobalEventInt globalEventInt = ((Dictionary<string, GlobalEventInt>)instance.GlobalEventsInt).get_Item("EnemyIsKicked");
			enemyIsKicked = globalEventInt;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0xCC4AB0", Offset = "0xCC4AB0", Length = "0x400")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = *([1EC07A0]);\n\tv39 = *([v38 @ X8_v34]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, deltaTime, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2023763]) = v57;\nL_0027:\n\tv68 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv165 = v68.world;\n\tv128 = 0x3F000000;\nL_0041:\n\tv310 = 0x15F75B8(&v165 @ stack_-B0_v4 (Morpeh.World), 0, v288, 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\tv311 = v310 & 1;\n\tv312 = v311 == 0;\n\tif (v312) goto L_0150;\n\tv330 = Il2CppMethodInfo;\n\tv331 = *([v323 @ stack_-88]);\n\tv335 = *([v331 @ X8_v9+126]) == 0;\n\tif (v335) goto L_006B;\n\tv468 = *([v331 @ X8_v9+B0]) + 8;\nL_0057:\n\tv473 = *([v468 @ X11_v29-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v473) goto L_006E;\n\tv467 = v467 + 1;\n\tv526 = v467 < *([v331 @ X8_v9+126]);\n\tv373 = ~v526;\n\tv468 = v468 + 0x10;\n\tv357 = ~v373;\n\tif (v357) goto L_0057;\nL_006B:\n\tv533 = 0x8909C4(v323, Il2CppClass<Morpeh.IEntity>, *([v330 @ X21_v7 (Il2CppMethodInfo)+48]), 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\tgoto L_0074;\nL_006E:\n\tv528 = *([v468 @ X11_v29]) + *([v330 @ X21_v7 (Il2CppMethodInfo)+48]);\n\tv529 = v528 << 4;\n\tv530 = v331 + v529;\n\tv533 = v530 + 0x130;\nL_0074:\n\tv537 = Morpeh.IEntity::GetComponent(*([v533 @ X0_v26+8]));\n\t*([v537 @ X0_v28 (GBG.Pinata.ECS.Components.EnemyComponent&)])(v540, v323, v537, *([v330 @ X21_v7 (Il2CppMethodInfo)+48]), 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\tv542 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.enemyIsKicked);\n\tv544 = v542 == 0;\n\tif (v544) goto L_00BB;\n\tUnityEngine.ParticleSystem::Play(*([v540 @ X0_v30+18]), 1);\n\tv548 = Il2CppMethodInfo;\n\tv622 = *([v323 @ stack_-88]);\n\tv583 = *([v622 @ X8_v27+126]) == 0;\n\tif (v583) goto L_00AB;\n\tv699 = *([v622 @ X8_v27+B0]) + 8;\nL_0097:\n\tv704 = *([v699 @ X11_v24-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v704) goto L_00AE;\n\tv698 = v698 + 1;\n\tv711 = v698 < *([v622 @ X8_v27+126]);\n\tv669 = ~v711;\n\tv699 = v699 + 0x10;\n\tv653 = ~v669;\n\tif (v653) goto L_0097;\nL_00AB:\n\tv718 = 0x8909C4(v323, Il2CppClass<Morpeh.IEntity>, *([v548 @ X22_v9 (Il2CppMethodInfo)+48]), 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\tgoto L_00B4;\nL_00AE:\n\tv713 = *([v699 @ X11_v24]) + *([v548 @ X22_v9 (Il2CppMethodInfo)+48]);\n\tv714 = v713 << 4;\n\tv715 = v622 + v714;\n\tv718 = v715 + 0x130;\nL_00B4:\n\tv722 = 0x8D8294(*([v718 @ X0_v58+8]), Il2CppMethodInfo, *([v548 @ X22_v9 (Il2CppMethodInfo)+48]), 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\t*([v722 @ X0_v60])(v581, v323, &v128 @ X25_v5 (System.Int32), v722, 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\nL_00BB:\n\tv254 = Il2CppMethodInfo;\n\tv586 = *([v323 @ stack_-88]);\n\tv590 = *([v586 @ X8_v13+126]) == 0;\n\tif (v590) goto L_00DE;\n\tv637 = *([v586 @ X8_v13+B0]) + 8;\nL_00CA:\n\tv642 = *([v637 @ X11_v18-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v642) goto L_00E1;\n\tv636 = v636 + 1;\n\tv676 = v636 < *([v586 @ X8_v13+126]);\n\tv615 = ~v676;\n\tv637 = v637 + 0x10;\n\tv599 = ~v615;\n\tif (v599) goto L_00CA;\nL_00DE:\n\tv683 = 0x8909C4(v323, Il2CppClass<Morpeh.IEntity>, *([v254 @ X22_v7 (Il2CppMethodInfo)+48]), 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\tgoto L_00E7;\nL_00E1:\n\tv678 = *([v637 @ X11_v18]) + *([v254 @ X22_v7 (Il2CppMethodInfo)+48]);\n\tv679 = v678 << 4;\n\tv680 = v586 + v679;\n\tv683 = v680 + 0x130;\nL_00E7:\n\tv687 = 0x8D8294(*([v683 @ X0_v34+8]), Il2CppMethodInfo, *([v254 @ X22_v7 (Il2CppMethodInfo)+48]), 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\t*([v687 @ X0_v36])(v299, v323, &v187 @ stack_-64_v6, v687, 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\tv302 = v187 == 0;\n\tif (v302) goto L_0041;\n\tv231 = *([v299 @ X0_v38]) - deltaTime;\n\tv724 = v231 < 0;\n\tv211 = ~v724;\n\tv205 = v231 == 0;\n\t*([v299 @ X0_v38]) = v231;\n\tv725 = ~v205;\n\tv195 = v211 & v725;\n\tif (v195) goto L_0041;\n\tgoto L_010E;\n\tv731 = *([v727 @ X0_v39+E0]);\n\tv732 = v731 == 0;\n\tv733 = ~v732;\n\tif (v733) goto L_010E;\n\tv735 = \"il2cpp_codegen_runtime_class_init\"(v727, v296, v289, v73, v44, v45, v46, v47, v231, v142, v49, v50, v51, v52, v53, v54);\nL_010E:\n\tv738 = UnityEngine.Object::op_Inequality(*([v540 @ X0_v30+18]), 0);\n\tv740 = v738 == 0;\n\tif (v740) goto L_011B;\n\tv246 = *([v540 @ X0_v30+18]) == 0;\n\tif (v246) goto L_0156;\n\tUnityEngine.ParticleSystem::Stop(*([v540 @ X0_v30+18]), 1, 1);\nL_011B:\n\tv294 = Il2CppMethodInfo;\n\tv750 = *([v323 @ stack_-88]);\n\tv288 = *([v294 @ X21_v9 (Il2CppMethodInfo)+48]);\n\tv303 = *([v750 @ X8_v21+126]) == 0;\n\tif (v303) goto L_013E;\n\tv793 = *([v750 @ X8_v21+B0]) + 8;\nL_012A:\n\tv798 = *([v793 @ X11_v13-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v798) goto L_0141;\n\tv792 = v792 + 1;\n\tv803 = v792 < *([v750 @ X8_v21+126]);\n\tv775 = ~v803;\n\tv793 = v793 + 0x10;\n\tv759 = ~v775;\n\tif (v759) goto L_012A;\nL_013E:\n\tv810 = 0x8909C4(v323, Il2CppClass<Morpeh.IEntity>, v288, 0, v44, v45, v46, v47, v231, v68.world, v49, v50, v51, v52, v53, v54);\n\tgoto L_0147;\nL_0141:\n\tv805 = *([v793 @ X11_v13]) + v288;\n\tv806 = v805 << 4;\n\tv807 = v750 + v806;\n\tv810 = v807 + 0x130;\nL_0147:\n\tv814 = Morpeh.IEntity::RemoveComponent(*([v810 @ X0_v44+8]));\n\tv814.m_value(v300, v323, v814, v288, 0, v44, v45, v46, v47, v231, v68.world, v49, v50, v51, v52, v53, v54);\n\tgoto L_0041;\nL_0150:\n\tv327 = 0x15F7664(&v165 @ stack_-B0_v4 (Morpeh.World), 0, v288, 0, v44, v45, v46, v47, v140, v68.world, v49, v50, v51, v52, v53, v54);\n\tgoto L_0184;\n\tv337 = new System.NullReferenceException();\n\tv169 = new System.NullReferenceException();\n\tv176 = new System.NullReferenceException();\nL_0156:\n\tv250 = new System.NullReferenceException();\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\n\tgoto L_016B;\nL_016B:\n\tv322 = v241 != 1;\n\tif (v322) goto L_0185;\n\tv328 = 0x6D2BC0(v250, v241, v216, v185, v44, v45, v46, v47, v230, v232, v49, v50, v51, v52, v53, v54);\n\tv339 = 0x6D2490(v328, v241, v216, v185, v44, v45, v46, v47, v230, v232, v49, v50, v51, v52, v53, v54);\n\tv343 = 0x15F7664(&v125 @ stack_-90_v4 (Morpeh.World), 0, v216, v185, v44, v45, v46, v47, v230, v232, v49, v50, v51, v52, v53, v54);\n\tv525 = *([v328 @ X0_v10]) == 0;\n\tv345 = ~v525;\n\tif (v345) goto L_0189;\nL_0184:\n\treturn;\nL_0185:\n\tv329 = 0x6D2380(v250, v241, v216, v185, v44, v45, v46, v47, v230, v232, v49, v50, v51, v52, v53, v54);\nL_0189:\n\tthrow System.TypeLoadException;\n// 242 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_062c: Expected O, but got I
			//IL_0085: Expected O, but got I
			//IL_015a: Expected O, but got I
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_0130: Expected O, but got I
			//IL_013f: Expected O, but got I
			//IL_0278: Expected O, but got I
			//IL_00d1: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_037c: Expected O, but got F4
			//IL_03a4: Expected O, but got F4
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0306: Expected O, but got Unknown
			//IL_0323: Expected O, but got I
			//IL_0332: Expected O, but got I
			//IL_02c4: Expected O, but got I
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Expected O, but got Unknown
			//IL_024e: Expected O, but got I
			//IL_025d: Expected O, but got I
			//IL_01ef: Expected O, but got I
			//IL_03ca: Expected O, but got I
			//IL_044f: Expected O, but got I
			//IL_07a7: Expected O, but got I
			//IL_07bd: Expected O, but got F4
			//IL_048a: Expected O, but got I
			//IL_042c: Expected O, but got I
			//IL_050c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0511: Expected O, but got Unknown
			//IL_052e: Expected O, but got I
			//IL_053d: Expected O, but got I
			//IL_04d6: Expected O, but got I
			Filter.EntityEnumerator enumerator = filter.GetEnumerator();
			World world = enumerator.world;
			int num = 1056964608;
			int[] ids = enumerator.ids;
			object obj = default(object);
			object obj3 = default(object);
			object obj9 = default(object);
			object obj11 = default(object);
			object obj12 = default(object);
			while (true)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ X8_v9+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00ea;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ X8_v9+B0]");
					object obj4 = 0L + 8L;
					int num2 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ X11_v29-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num2++;
						int num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ X8_v9+126]");
						bool flag = (long)num3 < 0L;
						bool flag2 = !flag;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00ea;
					}
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X21_v7 (Il2CppMethodInfo)+48]");
					object obj6 = obj5 + 0;
					int num4 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)(IntPtr)obj2 + (long)num4;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_061b;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
				IL_06fb:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v687 @ X0_v36] (should have been resolved before IL gen)");
				bool flag3 = obj9 == null;
				object obj10 = obj11;
				if (flag3)
				{
					continue;
				}
				float num5 = (float)obj12 - deltaTime;
				bool flag4 = num5 < 0f;
				bool flag5 = !flag4;
				bool flag6 = num5 == 0f;
				obj12 = num5;
				bool flag7 = !flag6;
				bool flag8 = flag5 && flag7;
				obj10 = obj11;
				ids = (int[])num5;
				if (flag8)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X0_v30+18]");
				if ((UnityEngine.Object)0 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X0_v30+18]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X0_v30+18]");
					((ParticleSystem)0).Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
				}
				IntPtr intPtr2 = (IntPtr)0;
				object obj13 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X21_v9 (Il2CppMethodInfo)+48]");
				obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ X8_v21+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_04ef;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ X8_v21+B0]");
				object obj14 = 0L + 8L;
				int num6 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v793 @ X11_v13-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num6++;
					int num7 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ X8_v21+126]");
					bool flag9 = (long)num7 < 0L;
					bool flag10 = !flag9;
					obj14 = (long)(IntPtr)obj14 + 16L;
					if (!flag10)
					{
						continue;
					}
					goto IL_04ef;
				}
				object obj15 = obj14 + (long)(IntPtr)obj10;
				int num8 = (int)((long)(IntPtr)obj15 << 4);
				object obj16 = (long)(IntPtr)obj13 + (long)num8;
				object obj17 = (long)(IntPtr)obj16 + 304L;
				goto IL_0796;
				IL_06bb:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v722 @ X0_v60] (should have been resolved before IL gen)");
				goto IL_0666;
				IL_0666:
				IntPtr intPtr3 = (IntPtr)0;
				object obj18 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X8_v13+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_02dd;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X8_v13+B0]");
				object obj19 = 0L + 8L;
				int num9 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num9++;
					int num10 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X8_v13+126]");
					bool flag11 = (long)num10 < 0L;
					bool flag12 = !flag11;
					obj19 = (long)(IntPtr)obj19 + 16L;
					if (!flag12)
					{
						continue;
					}
					goto IL_02dd;
				}
				object obj20 = obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X22_v7 (Il2CppMethodInfo)+48]");
				object obj21 = obj20 + 0;
				int num11 = (int)((long)(IntPtr)obj21 << 4);
				object obj22 = (long)(IntPtr)obj18 + (long)num11;
				object obj23 = (long)(IntPtr)obj22 + 304L;
				goto IL_06fb;
				IL_0208:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_06bb;
				IL_00ea:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_061b;
				IL_061b:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ X0_v26+8]");
				ref EnemyComponent component = ref ((IEntity)0).GetComponent<EnemyComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v537 @ X0_v28 (GBG.Pinata.ECS.Components.EnemyComponent&)] (should have been resolved before IL gen)");
				if (!enemyIsKicked)
				{
					goto IL_0666;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ X0_v30+18]");
				((ParticleSystem)0).Play(withChildren: true);
				IntPtr intPtr4 = (IntPtr)0;
				object obj24 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ X8_v27+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0208;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ X8_v27+B0]");
				object obj25 = 0L + 8L;
				int num12 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ X11_v24-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num12++;
					int num13 = num12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ X8_v27+126]");
					bool flag13 = (long)num13 < 0L;
					bool flag14 = !flag13;
					obj25 = (long)(IntPtr)obj25 + 16L;
					if (!flag14)
					{
						continue;
					}
					goto IL_0208;
				}
				object obj26 = obj25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ X22_v9 (Il2CppMethodInfo)+48]");
				object obj27 = obj26 + 0;
				int num14 = (int)((long)(IntPtr)obj27 << 4);
				object obj28 = (long)(IntPtr)obj24 + (long)num14;
				object obj29 = (long)(IntPtr)obj28 + 304L;
				goto IL_06bb;
				IL_04ef:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0796;
				IL_0796:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v810 @ X0_v44+8]");
				bool flag15 = ((IEntity)0).RemoveComponent<TimerComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v814.m_value (System.Boolean) (should have been resolved before IL gen)");
				ids = (int[])num5;
				continue;
				IL_02dd:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_06fb;
			}
			NullReferenceException ex = new NullReferenceException();
			UnityEngine.Object obj30 = default(UnityEngine.Object);
			if ((IntPtr)obj30 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj31 = default(object);
				if (obj31 == null)
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

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0xCC4EB0", Offset = "0xCC4EB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CollisionEnemiesSystem()
		{
		}
	}
}
