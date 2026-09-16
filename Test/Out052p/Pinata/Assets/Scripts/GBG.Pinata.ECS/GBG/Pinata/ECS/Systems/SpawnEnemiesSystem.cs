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
	[Token(Token = "0x2000073")]
	public class SpawnEnemiesSystem : UpdateSystem
	{
		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x28")]
		private Filter filter;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x30")]
		private GameConfig config;

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0xCC747C", Offset = "0xCC747C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F089B0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023770]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv48 = Morpeh.Filter::With(v42, 1);\n\tv74 = Morpeh.Filter::Without(v48, 1);\n\tthis.filter = v74;\n\tv63 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v63;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<EnemyComponent>();
			Filter filter2 = filter.Without<EnemySpawnedMarker>();
			this.filter = filter2;
			GameConfig instance = GameConfig.Instance;
			config = instance;
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0xCC750C", Offset = "0xCC750C", Length = "0x4B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv48 = *([1F06988]);\n\tv49 = *([v48 @ X8_v53]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, methodInfo, v52, v53, v54, v55, v56, v57, deltaTime, v59, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([2023771]) = v68;\nL_0026:\n\tv73 = this.filter == 0;\n\tif (v73) goto L_0176;\n\tv77 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv206 = v77.world;\nL_0043:\n\tv310 = 0x15F75B8(&v206 @ stack_-E0_v3 (Morpeh.World), 0, *([v294 @ X21_v16 (Il2CppMethodInfo)+48]), 0, v54, v55, v56, v57, v295, v297, v935.z, v950, v950.y, v950.z, v950.w, v65);\n\tv321 = v310 & 1;\n\tv322 = v321 == 0;\n\tif (v322) goto L_0164;\n\tv343 = Il2CppMethodInfo;\n\tv344 = *([v325 @ stack_-B8]);\n\tv348 = *([v344 @ X8_v16+126]) == 0;\n\tif (v348) goto L_006D;\n\tv579 = *([v344 @ X8_v16+B0]) + 8;\nL_0054:\n\t;\n\tv584 = *([v579 @ X11_v23-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v584) goto L_006F;\n\tv578 = v578 + 1;\n\tv623 = v578 < *([v344 @ X8_v16+126]);\n\tv374 = ~v623;\n\tv579 = v579 + 0x10;\n\tv358 = ~v374;\n\tif (v358) goto L_0054;\nL_006D:\n\tv630 = 0x8909C4(v325, Il2CppClass<Morpeh.IEntity>, *([v343 @ X21_v14 (Il2CppMethodInfo)+48]), 0, v54, v55, v56, v57, v295, v297, v935.z, v950, v950.y, v950.z, v950.w, v65);\n\tgoto L_0074;\nL_006F:\n\t;\n\tv625 = *([v579 @ X11_v23]) + *([v343 @ X21_v14 (Il2CppMethodInfo)+48]);\n\tv626 = v625 << 4;\n\tv627 = v344 + v626;\n\tv630 = v627 + 0x130;\nL_0074:\n\t;\n\tv634 = Morpeh.IEntity::GetComponent(*([v630 @ X0_v45+8]));\n\t*([v634 @ X0_v47 (GBG.Pinata.ECS.Components.EnemyComponent&)])(v671, v325, v634, *([v343 @ X21_v14 (Il2CppMethodInfo)+48]), 0, v54, v55, v56, v57, v295, v297, v935.z, v950, v950.y, v950.z, v950.w, v65);\n\tgoto L_0089;\n\tv705 = *([v672 @ X0_v50+E0]);\n\tv706 = v705 == 0;\n\tv707 = ~v706;\n\tgoto L_0089;\n\tv709 = \"il2cpp_codegen_runtime_class_init\"(v672, v421, v347, v227, v54, v55, v56, v57, v295, v297, v261, v247, v237, v235, v233, v65);\nL_0089:\n\tv417 = UnityEngine.Vector3::get_zero();\n\tUnityEngine.Rigidbody::set_velocity(*([v671 @ X0_v49+10]), v417);\n\tv611 = UnityEngine.Vector3::get_zero();\n\tUnityEngine.Rigidbody::set_angularVelocity(*([v671 @ X0_v49+10]), v611);\n\tgoto L_00AB;\n\tv890 = *([v885 @ X0_v56+E0]);\n\tv891 = v890 == 0;\n\tv892 = ~v891;\n\tif (v892) goto L_00AB;\n\tv894 = \"il2cpp_codegen_runtime_class_init\"(v885, v884, v347, v227, v54, v55, v56, v57, v611, v613, v592, v247, v237, v235, v233, v65);\nL_00AB:\n\tv899 = UnityEngine.Object::op_Inequality(*([v671 @ X0_v49]), 0);\n\tv901 = v899 == 0;\n\tif (v901) goto L_00BD;\n\tgoto L_00BC;\n\tv913 = *([v902 @ X0_v88+E0]);\n\tv914 = v913 == 0;\n\tv915 = ~v914;\n\tif (v915) goto L_00BC;\n\tv917 = \"il2cpp_codegen_runtime_class_init\"(v902, v898, v654, v227, v54, v55, v56, v57, v611, v613, v592, v247, v237, v235, v233, v65);\nL_00BC:\n\tUnityEngine.Object::Destroy(*([v671 @ X0_v49]));\nL_00BD:\n\tv666 = this.config;\n\tv256 = v666.Enemy.EnemiesSetup;\n\tv738 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v666.Enemy);\n\tv919 = v256._size < v738;\n\tv769 = ~v919;\n\tv767 = v256._size - v738;\n\tv763 = v767 == 0;\n\tv920 = ~v763;\n\tv753 = v769 & v920;\n\tif (v753) goto L_00D8;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00D8:\n\tv922 = v256._items;\n\tv783 = v922[v738 @ X0_v62 (System.Int32)];\n\tgoto L_00EA;\n\tv927 = *([v924 @ X0_v64+E0]);\n\tv928 = v927 == 0;\n\tv929 = ~v928;\n\tif (v929) goto L_00EA;\n\tv931 = \"il2cpp_codegen_runtime_class_init\"(v924, v736, v654, v227, v54, v55, v56, v57, v611, v613, v592, v247, v237, v235, v233, v65);\nL_00EA:\n\tv935 = UnityEngine.Vector3::get_zero();\n\tgoto L_00FB;\n\tv942 = *([v938 @ X0_v67+E0]);\n\tv943 = v942 == 0;\n\tv944 = ~v943;\n\tif (v944) goto L_00FB;\n\tv946 = \"il2cpp_codegen_runtime_class_init\"(v938, v736, v654, v227, v54, v55, v56, v57, v935, v936, v937, v247, v237, v235, v233, v65);\nL_00FB:\n\tv950 = UnityEngine.Quaternion::get_identity();\n\tgoto L_011A;\n\tv958 = *([v954 @ X0_v70+E0]);\n\tv959 = v958 == 0;\n\tv960 = ~v959;\n\tif (v960) goto L_011A;\n\tv962 = \"il2cpp_codegen_runtime_class_init\"(v954, v736, v654, v227, v54, v55, v56, v57, v950, v951, v952, v953, v237, v235, v233, v65);\nL_011A:\n\tv827 = UnityEngine.Object::Instantiate(v783.EnemyPrefab, v935, v950);\n\t*([v671 @ X0_v49]) = v827;\n\tv872 = UnityEngine.GameObject::get_transform(v827);\n\tUnityEngine.Transform::SetParent(v872, *([v671 @ X0_v49+8]), 0);\n\tUnityEngine.ParticleSystem::Stop(*([v671 @ X0_v49+18]), 1, 1);\n\tv294 = Il2CppMethodInfo;\n\tv971 = *([v325 @ stack_-B8]);\n\tv304 = *([v971 @ X8_v38+126]) == 0;\n\tif (v304) goto L_0152;\n\tv1014 = *([v971 @ X8_v38+B0]) + 8;\nL_0139:\n\t;\n\tv1019 = *([v1014 @ X11_v18-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1019) goto L_0154;\n\tv1013 = v1013 + 1;\n\tv1024 = v1013 < *([v971 @ X8_v38+126]);\n\tv996 = ~v1024;\n\tv1014 = v1014 + 0x10;\n\tv980 = ~v996;\n\tif (v980) goto L_0139;\nL_0152:\n\tv1031 = 0x8909C4(v325, Il2CppClass<Morpeh.IEntity>, *([v294 @ X21_v16 (Il2CppMethodInfo)+48]), 0, v54, v55, v56, v57, v935, v935.y, v935.z, v950, v950.y, v950.z, v950.w, v65);\n\tgoto L_0159;\nL_0154:\n\t;\n\tv1026 = *([v1014 @ X11_v18]) + *([v294 @ X21_v16 (Il2CppMethodInfo)+48]);\n\tv1027 = v1026 << 4;\n\tv1028 = v971 + v1027;\n\tv1031 = v1028 + 0x130;\nL_0159:\n\t;\n\tv1035 = Morpeh.IEntity::AddComponent(*([v1031 @ X0_v76+8]));\n\t*([v1035 @ X0_v78 (GBG.Pinata.ECS.Systems.EnemySpawnedMarker&)])(v302, v325, v1035, *([v294 @ X21_v16 (Il2CppMethodInfo)+48]), 0, v54, v55, v56, v57, v935, v935.y, v935.z, v950, v950.y, v950.z, v950.w, v65);\n\tgoto L_0043;\nL_0164:\n\tv329 = 0x15F7664(&v206 @ stack_-E0_v3 (Morpeh.World), 0, *([v294 @ X21_v16 (Il2CppMethodInfo)+48]), 0, v54, v55, v56, v57, v295, v297, v935.z, v950, v950.y, v950.z, v950.w, v65);\n\tgoto L_01B8;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv668 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv785 = new System.NullReferenceException();\n\tv832 = new System.NullReferenceException();\n\tv876 = new System.NullReferenceException();\n\tv210 = new System.NullReferenceException();\nL_0176:\n\tv217 = new System.NullReferenceException();\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\n\tgoto L_0199;\nL_0199:\n\tv320 = v207 != 1;\n\tif (v320) goto L_01B9;\n\tv323 = 0x6D2BC0(v217, v207, v159, v81, v54, v55, v56, v57, v180, v182, v119, v103, v93, v91, v89, v65);\n\tv331 = 0x6D2490(v323, v207, v159, v81, v54, v55, v56, v57, v180, v182, v119, v103, v93, v91, v89, v65);\n\tv335 = 0x15F7664(&v168 @ stack_-C0_v3 (Morpeh.World), 0, v159, v81, v54, v55, v56, v57, v180, v182, v119, v103, v93, v91, v89, v65);\n\tv507 = *([v323 @ X0_v10]) == 0;\n\tv337 = ~v507;\n\tif (v337) goto L_01BD;\nL_01B8:\n\treturn;\nL_01B9:\n\tv324 = 0x6D2380(v217, v207, v159, v81, v54, v55, v56, v57, v180, v182, v119, v103, v93, v91, v89, v65);\nL_01BD:\n\tthrow System.TypeLoadException;\n// 271 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_0535: Expected O, but got I
			//IL_008c: Expected O, but got I
			//IL_016a: Expected O, but got I
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Expected O, but got Unknown
			//IL_0133: Expected O, but got I
			//IL_0142: Expected O, but got I
			//IL_018e: Expected O, but got I
			//IL_00d8: Expected O, but got I
			//IL_0313: Expected O, but got I
			//IL_0334: Expected O, but got I
			//IL_057f: Expected O, but got I
			//IL_05a3: Expected O, but got F4
			//IL_0380: Expected O, but got I
			//IL_0405: Unknown result type (might be due to invalid IL or missing references)
			//IL_040a: Expected O, but got Unknown
			//IL_0427: Expected O, but got I
			//IL_0436: Expected O, but got I
			//IL_03cc: Expected O, but got I
			bool flag = filter == null;
			World world2 = default(World);
			World world = world2;
			if (!flag)
			{
				Filter.EntityEnumerator enumerator = filter.GetEnumerator();
				world2 = enumerator.world;
				int[] ids = enumerator.ids;
				World world3 = enumerator.world;
				object obj = default(object);
				object obj3 = default(object);
				object obj9 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)0;
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ X8_v16+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00f1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ X8_v16+B0]");
					object obj4 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ X11_v23-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ X8_v16+126]");
						bool flag2 = (long)num2 < 0L;
						bool flag3 = !flag2;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_00f1;
					}
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ X21_v14 (Il2CppMethodInfo)+48]");
					object obj6 = obj5 + 0;
					int num3 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)(IntPtr)obj2 + (long)num3;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					goto IL_0523;
					IL_00f1:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0523;
					IL_0523:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ X0_v45+8]");
					ref EnemyComponent component = ref ((IEntity)0).GetComponent<EnemyComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v634 @ X0_v47 (GBG.Pinata.ECS.Components.EnemyComponent&)] (should have been resolved before IL gen)");
					Vector3 zero = Vector3.zero;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ X0_v49+10]");
					((Rigidbody)0).velocity = zero;
					Vector3 zero2 = Vector3.zero;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ X0_v49+10]");
					((Rigidbody)0).angularVelocity = zero2;
					if ((UnityEngine.Object)obj9 != null)
					{
						UnityEngine.Object.Destroy((UnityEngine.Object)obj9);
					}
					GameConfig gameConfig = config;
					List<EnemySetupClass> enemiesSetup = gameConfig.Enemy.EnemiesSetup;
					int value = ((BaseGlobalVariable<int>)gameConfig.Enemy).Value;
					bool flag4 = enemiesSetup.Count < value;
					bool flag5 = !flag4;
					int num4 = enemiesSetup.Count - value;
					bool flag6 = num4 == 0;
					bool flag7 = !flag6;
					if (!(flag5 && flag7))
					{
						throw new ArgumentOutOfRangeException();
					}
					EnemySetupClass[] items = enemiesSetup._items;
					EnemySetupClass enemySetupClass = items[value];
					Vector3 zero3 = Vector3.zero;
					Quaternion identity = Quaternion.identity;
					GameObject gameObject = UnityEngine.Object.Instantiate(enemySetupClass.EnemyPrefab, zero3, identity);
					obj9 = gameObject;
					Transform transform = gameObject.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ X0_v49+8]");
					transform.SetParent((Transform)0, worldPositionStays: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ X0_v49+18]");
					((ParticleSystem)0).Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
					IntPtr intPtr2 = (IntPtr)0;
					object obj10 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ X8_v38+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ X8_v38+B0]");
						object obj11 = 0L + 8L;
						int num5 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ X11_v18-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ X8_v38+126]");
							bool flag8 = (long)num6 < 0L;
							bool flag9 = !flag8;
							obj11 = (long)(IntPtr)obj11 + 16L;
							if (!flag9)
							{
								continue;
							}
							goto IL_03e5;
						}
						object obj12 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X21_v16 (Il2CppMethodInfo)+48]");
						object obj13 = obj12 + 0;
						int num7 = (int)((long)(IntPtr)obj13 << 4);
						object obj14 = (long)(IntPtr)obj10 + (long)num7;
						object obj15 = (long)(IntPtr)obj14 + 304L;
						goto IL_056d;
					}
					goto IL_03e5;
					IL_03e5:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_056d;
					IL_056d:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ X0_v76+8]");
					ref EnemySpawnedMarker reference = ref ((IEntity)0).AddComponent<EnemySpawnedMarker>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1035 @ X0_v78 (GBG.Pinata.ECS.Systems.EnemySpawnedMarker&)] (should have been resolved before IL gen)");
					ids = (int[])zero3;
					world3 = (World)zero3.y;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr3 = default(IntPtr);
			if (intPtr3 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj16 = default(object);
				if (obj16 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0xCC79C4", Offset = "0xCC79C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpawnEnemiesSystem()
		{
		}
	}
}
