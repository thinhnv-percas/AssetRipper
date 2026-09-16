using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000065")]
	public class AttackSystem : UpdateSystem
	{
		[Required]
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEventInt EnemyIsKicked;

		[Required]
		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x30")]
		public GlobalVariableInt CurrentWeaponAmmo;

		[Token(Token = "0x4000133")]
		private static readonly int Attack;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x38")]
		private Filter filterAttacks;

		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x40")]
		private Filter filterPinata;

		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x48")]
		private Filter filterHands;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x50")]
		private GameConfig config;

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0xCC39B0", Offset = "0xCC39B0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDE098]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202375D]) = v38;\nL_0015:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv41 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v41;\n\tv46 = Morpeh.FilterProvider::get_All(this.filter);\n\tv54 = Morpeh.Filter::With(v46, 1);\n\tthis.filterAttacks = v54;\n\tv71 = Morpeh.FilterProvider::get_All(this.filter);\n\tv55 = Morpeh.Filter::With(v71, 1);\n\tthis.filterHands = v55;\n\tv72 = Morpeh.FilterProvider::get_All(this.filter);\n\tv73 = Morpeh.Filter::With(v72, 1);\n\tv90 = Morpeh.Filter::With(v73, 1);\n\tthis.filterPinata = v90;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Application.targetFrameRate = 60;
			GameConfig instance = GameConfig.Instance;
			config = instance;
			Filter all = Filter.All;
			Filter filter = all.With<AttackComponent>();
			filterAttacks = filter;
			Filter all2 = Filter.All;
			Filter filter2 = all2.With<HandComponent>();
			filterHands = filter2;
			Filter all3 = Filter.All;
			Filter filter3 = all3.With<EnemyComponent>();
			Filter filter4 = filter3.With<EnemySpawnedMarker>();
			filterPinata = filter4;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0xCC3AB4", Offset = "0xCC3AB4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBA4D0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, deltaTime, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202375E]) = v41;\nL_001B:\n\tv47 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.CurrentWeaponAmmo);\n\tv59 = v47 < 1;\n\tif (v59) goto L_0032;\n\tGBG.Pinata.ECS.Systems.AttackSystem::GetInputs(this);\nL_0032:\n\tGBG.Pinata.ECS.Systems.AttackSystem::MoveHands(this, deltaTime);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			int value = CurrentWeaponAmmo.Value;
			if (value >= 1)
			{
				GetInputs();
			}
			MoveHands(deltaTime);
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0xCC3B34", Offset = "0xCC3B34", Length = "0x460")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = &v31 @ X29;\n\tgoto L_0022;\n\tv43 = *([1F05530]);\n\tv44 = *([v43 @ X8_v38]);\n\tv45 = \"il2cpp_codegen_initialize_method\"(v44, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([202375F]) = v63;\nL_0022:\n\tv65 = &v66 @ stack_-100;\n\t*([v31 @ X29-A0]) = 0;\n\t*([v31 @ X29-90]) = 0;\n\t*([v31 @ X29-C0]) = 0;\n\t*([v31 @ X29-B0]) = 0;\n\tv72 = Morpeh.Filter::GetEnumerator(this.filterAttacks);\n\tv416 = *([v31 @ X29-E0]);\n\tv415 = *([v31 @ X29-D0]);\n\t*([v31 @ X29-90]) = *([v31 @ X29-D0]);\n\t*([v31 @ X29-A0]) = *([v31 @ X29-E0]);\nL_003F:\n\tv275 = &v31 @ X29 - 0xA0;\n\tv276 = 0x15F75B8(v275, 0, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tv333 = v276 & 1;\n\tv334 = v333 == 0;\n\tif (v334) goto L_0155;\n\tv123 = *([v31 @ X29-98]);\n\tv199 = Il2CppMethodInfo;\n\tv382 = *([v123 @ X21_v8]);\n\tv249 = *([v199 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv385 = *([v382 @ X8_v17+126]) == 0;\n\tif (v385) goto L_006B;\n\tv474 = *([v382 @ X8_v17+B0]) + 8;\nL_0057:\n\tv479 = *([v474 @ X11_v19-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v479) goto L_006E;\n\tv473 = v473 + 1;\n\tv582 = v473 < *([v382 @ X8_v17+126]);\n\tv451 = ~v582;\n\tv474 = v474 + 0x10;\n\tv435 = ~v451;\n\tif (v435) goto L_0057;\nL_006B:\n\tv589 = 0x8909C4(v123, Il2CppClass<Morpeh.IEntity>, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tgoto L_0074;\nL_006E:\n\tv584 = *([v474 @ X11_v19]) + v249;\n\tv585 = v584 << 4;\n\tv586 = v382 + v585;\n\tv589 = v586 + 0x130;\nL_0074:\n\tv593 = Morpeh.IEntity::GetComponent(*([v589 @ X0_v27+8]));\n\t*([v593 @ X0_v29 (GBG.Pinata.ECS.Components.AttackComponent&)])(v263, v123, v593, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tv623 = *([v263 @ X0_v31+4]) == 0;\n\tv267 = ~v623;\n\tif (v267) goto L_003F;\n\tv264 = UnityEngine.Input::GetKey(0x143);\n\tv268 = v264 == 0;\n\tif (v268) goto L_003F;\n\tv628 = Morpeh.Filter::GetEnumerator(this.filterHands);\n\tv416 = *([v31 @ X29-E0]);\n\tv415 = *([v31 @ X29-D0]);\n\t*([v31 @ X29-C0]) = *([v31 @ X29-E0]);\n\t*([v31 @ X29-B0]) = *([v31 @ X29-D0]);\n\tgoto L_00C3;\nL_0091:\n\tv415 = UnityEngine.Time::get_time();\n\tv227 = *([v672 @ X0_v50+68]);\n\tv416 = *([v263 @ X0_v31]) + *([v672 @ X0_v50+68]);\n\tv648 = v415 < v416;\n\tif (v648) goto L_00C3;\n\t*([v672 @ X0_v50+6]) = 0;\n\tv791 = UnityEngine.Random::Range(0.025f, 0.2f);\n\t*([v672 @ X0_v50+8]) = v791;\n\tv795 = UnityEngine.Random::Range(0.2f, 3f);\n\tv799 = UnityEngine.Random::Range(0.2f, 3f);\n\tv803 = UnityEngine.Random::Range(0.2f, 3f);\n\t*([v31 @ X29-D8]) = 0;\n\t*([v31 @ X29-E0]) = 0;\n\tv804 = &v31 @ X29 - 0xE0;\n\tv806 = 0x1586898(v804, 0, v249, v48, v49, v50, v51, v52, v795, v799, v803, v56, v57, v58, v59, v60);\n\t*([v672 @ X0_v50+4]) = 1;\n\t*([v672 @ X0_v50+C]) = *([v31 @ X29-E0]);\n\t*([v672 @ X0_v50+14]) = *([v31 @ X29-D8]);\n\tv415 = UnityEngine.Time::get_time();\n\t*([v263 @ X0_v31]) = v415;\nL_00C3:\n\tv679 = &v31 @ X29 - 0xC0;\n\tv680 = 0x15F75B8(v679, 0, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tv681 = v680 & 1;\n\tv682 = v681 == 0;\n\tif (v682) goto L_0111;\n\tv309 = *([v31 @ X29-B8]);\n\tv329 = *([v31 @ X29-B8]) == 0;\n\tif (v329) goto L_0117;\n\tv697 = Il2CppMethodInfo;\n\tv698 = *([v309 @ X22_v11]);\n\tv249 = *([v697 @ X23_v11 (Il2CppMethodInfo)+48]);\n\tv675 = *([v698 @ X8_v28+126]) == 0;\n\tif (v675) goto L_00EF;\n\tv747 = *([v698 @ X8_v28+B0]) + 8;\nL_00DB:\n\tv752 = *([v747 @ X11_v14-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v752) goto L_00F2;\n\tv746 = v746 + 1;\n\tv759 = v746 < *([v698 @ X8_v28+126]);\n\tv725 = ~v759;\n\tv747 = v747 + 0x10;\n\tv709 = ~v725;\n\tif (v709) goto L_00DB;\nL_00EF:\n\tv775 = 0x8909C4(*([v31 @ X29-B8]), Il2CppClass<Morpeh.IEntity>, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tgoto L_00F8;\nL_00F2:\n\tv761 = *([v747 @ X11_v14]) + v249;\n\tv762 = v761 << 4;\n\tv763 = v698 + v762;\n\tv775 = v763 + 0x130;\nL_00F8:\n\tv779 = Morpeh.IEntity::GetComponent(*([v775 @ X0_v46+8]));\n\t*([v779 @ X0_v48 (GBG.Pinata.ECS.Components.HandComponent&)])(v672, *([v31 @ X29-B8]), v779, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tv637 = *([v672 @ X0_v50]) != *([v263 @ X0_v31+8]);\n\tif (v637) goto L_00C3;\n\tv785 = *([v672 @ X0_v50+5]) == 0;\n\tv674 = ~v785;\n\tif (v674) goto L_0091;\nL_0111:\n\tv357 = v357 + 1;\n\t*([v65 @ X24_v1+v357 @ X25_v8*4]) = 0x111;\n\tgoto L_0135;\nL_0117:\n\tv327 = new System.NullReferenceException();\n\tgoto L_015D;\n\tgoto L_0123;\n\tgoto L_0120;\n\tgoto L_0120;\n\tgoto L_0120;\n\tgoto L_0120;\n\tgoto L_0120;\n\tgoto L_0120;\nL_0120:\n\tX8 = X1;\n\tX2 = X0;\n\tgoto L_0126;\nL_0123:\n\tX8 = X1;\n\tX2 = X0;\n\tX23 = 0xFFFFFFFF;\nL_0126:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_016F;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0135:\n\tv702 = &v31 @ X29 - 0xC0;\n\tv265 = 0x15F7664(v702, 0, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tv269 = v357 + 1;\n\tv733 = v269 == 0;\n\tif (v733) goto L_014F;\n\tv229 = *([v65 @ X24_v1+v357 @ X25_v8*4]) != 0x111;\n\tif (v229) goto L_014F;\n\tv271 = v255 ^ v357;\n\tv357 = v357 + v271;\n\tgoto L_003F;\nL_014F:\n\tv270 = v422 == 0;\n\tif (v270) goto L_003F;\n\tthrow System.TypeLoadException;\nL_0155:\n\tv406 = v357 + 1;\n\t*([v65 @ X24_v1+v406 @ X25_v1*4]) = 0x12D;\n\tgoto L_0174;\n\tv150 = new System.NullReferenceException();\n\tv157 = new System.NullReferenceException();\n\tv223 = new System.NullReferenceException();\nL_015D:\n\tgoto L_016F;\n\t// 350 Jump @b70\n\t// 351 Jump @b70\n\t// 352 Jump @b70\n\t// 353 Jump @b70\n\t// 354 Jump @b70\nL_016F:\n\tv381 = v324 != 1;\n\tif (v381) goto L_01A5;\n\tv427 = 0x6D2BC0(v326, v324, v326, v48, v49, v50, v51, v52, v322, v323, v281, v56, v57, v58, v59, v60);\n\tv422 = *([v427 @ X0_v14]);\n\tv419 = 0x6D2490(v427, v324, v326, v48, v49, v50, v51, v52, v322, v323, v281, v56, v57, v58, v59, v60);\nL_0174:\n\tv424 = &v31 @ X29 - 0xA0;\n\tv426 = 0x15F7664(v424, 0, v249, v48, v49, v50, v51, v52, v415, v416, v227, v56, v57, v58, v59, v60);\n\tv458 = v406 + 1;\n\tv460 = v458 == 0;\n\tif (v460) goto L_018E;\n\tv484 = v422 == 0;\n\tif (v484) goto L_01A4;\n\tv599 = *([v65 @ X24_v1+v406 @ X25_v1*4]) == 0x12D;\n\tif (v599) goto L_01A4;\nL_018D:\n\tthrow System.TypeLoadException;\nL_018E:\n\tv511 = v422 == 0;\n\tv512 = ~v511;\n\tif (v512) goto L_018D;\nL_01A4:\n\treturn;\nL_01A5:\n\tv428 = 0x6D2380(v326, v324, v326, v48, v49, v50, v51, v52, v322, v323, v281, v56, v57, v58, v59, v60);\n\treturn;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetInputs()
		{
			//IL_002c: Expected F4, but got I
			//IL_003c: Expected F4, but got I
			//IL_0063: Expected O, but got I8
			//IL_0070: Expected O, but got I8
			//IL_0786: Expected O, but got I
			//IL_05cf: Expected O, but got I
			//IL_062f: Expected O, but got I
			//IL_0648: Expected O, but got I
			//IL_008e: Expected O, but got I
			//IL_00b1: Expected O, but got I
			//IL_0739: Expected O, but got I
			//IL_00ec: Expected O, but got I
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			//IL_018b: Expected O, but got I
			//IL_019a: Expected O, but got I
			//IL_0138: Expected O, but got I
			//IL_01e9: Expected F4, but got I
			//IL_01f9: Expected F4, but got I
			//IL_07cb: Expected O, but got I
			//IL_04de: Expected O, but got I
			//IL_0506: Expected O, but got I
			//IL_051f: Expected O, but got I
			//IL_0361: Expected O, but got I
			//IL_03a4: Expected O, but got I
			//IL_0581: Expected O, but got I
			//IL_0834: Expected O, but got I
			//IL_0868: Expected O, but got I8
			//IL_03df: Expected O, but got I
			//IL_05f1: Expected I4, but got O
			//IL_04c1: Expected O, but got I8
			//IL_045c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0461: Expected O, but got Unknown
			//IL_047e: Expected O, but got I
			//IL_048d: Expected O, but got I
			//IL_0231: Expected F4, but got I
			//IL_0265: Expected O, but got I8
			//IL_042b: Expected O, but got I
			//IL_02ef: Expected O, but got I
			//IL_032f: Expected O, but got F4
			//IL_0344: Expected O, but got I8
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Filter.EntityEnumerator enumerator = filterAttacks.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-E0]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-D0]");
			float num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-D0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-E0]");
			_ = 0;
			object obj4 = 4294967295L;
			object obj5 = 4294967295L;
			int num3 = 0;
			object obj7 = default(object);
			object obj14 = default(object);
			object obj15 = default(object);
			object obj16 = default(object);
			float num8 = default(float);
			NullReferenceException ex3 = default(NullReferenceException);
			float num9 = default(float);
			float num10 = default(float);
			object obj20 = default(object);
			object obj27 = default(object);
			object obj28 = default(object);
			while (true)
			{
				object obj6 = (long)(IntPtr)obj - 160L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				NullReferenceException ex;
				if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-98]");
					object obj8 = 0;
					IntPtr intPtr = (IntPtr)0;
					object obj9 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ X22_v8 (Il2CppMethodInfo)+48]");
					ex = (NullReferenceException)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X8_v17+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0151;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X8_v17+B0]");
					object obj10 = 0L + 8L;
					int num4 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X8_v17+126]");
						bool flag = (long)num5 < 0L;
						bool flag2 = !flag;
						obj10 = (long)(IntPtr)obj10 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0151;
					}
					object obj11 = obj10 + (long)(IntPtr)ex;
					int num6 = (int)((long)(IntPtr)obj11 << 4);
					object obj12 = (long)(IntPtr)obj9 + (long)num6;
					object obj13 = (long)(IntPtr)obj12 + 304L;
					goto IL_0728;
				}
				obj14 = (long)(IntPtr)obj4 + 1L;
				_ = 301;
				goto IL_0620;
				IL_0151:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0728;
				IL_04e9:
				NullReferenceException ex2 = new NullReferenceException();
				if ((IntPtr)obj15 != (IntPtr)1)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				num3 = (int)obj16;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				float num7 = num8;
				ex = ex3;
				num2 = num9;
				num = num10;
				goto IL_0620;
				IL_0620:
				object obj17 = (long)(IntPtr)obj - 160L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj18 = (long)(IntPtr)obj14 + 1L;
				if (obj18 != null)
				{
					if (num3 == 0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X24_v1+v406 @ X25_v1*4]");
					if ((IntPtr)0 == (IntPtr)301)
					{
						return;
					}
				}
				else if (num3 == 0)
				{
					return;
				}
				throw new TypeLoadException();
				IL_0728:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ X0_v27+8]");
				ref AttackComponent component = ref ((IEntity)0).GetComponent<AttackComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v593 @ X0_v29 (GBG.Pinata.ECS.Components.AttackComponent&)] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X0_v31+4]");
				if ((IntPtr)0 != (IntPtr)0 || !Input.GetKey(KeyCode.Mouse0))
				{
					continue;
				}
				Filter.EntityEnumerator enumerator2 = filterHands.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-E0]");
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-D0]");
				num2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-E0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-D0]");
				_ = 0;
				while (true)
				{
					object obj19 = (long)(IntPtr)obj - 192L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj20 & 1L) == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-B8]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-B8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_04e9;
					}
					IntPtr intPtr2 = (IntPtr)0;
					object obj22 = obj21;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ X23_v11 (Il2CppMethodInfo)+48]");
					ex = (NullReferenceException)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X8_v28+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0444;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X8_v28+B0]");
					object obj23 = 0L + 8L;
					int num11 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ X11_v14-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num11++;
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X8_v28+126]");
						bool flag3 = (long)num12 < 0L;
						bool flag4 = !flag3;
						obj23 = (long)(IntPtr)obj23 + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_0444;
					}
					object obj24 = obj23 + (long)(IntPtr)ex;
					int num13 = (int)((long)(IntPtr)obj24 << 4);
					object obj25 = (long)(IntPtr)obj22 + (long)num13;
					object obj26 = (long)(IntPtr)obj25 + 304L;
					goto IL_0823;
					IL_0823:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ X0_v46+8]");
					ref HandComponent component2 = ref ((IEntity)0).GetComponent<HandComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v779 @ X0_v48 (GBG.Pinata.ECS.Components.HandComponent&)] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X0_v31+8]");
					bool flag5 = obj27 != null;
					obj5 = 4294967295L;
					if (!flag5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ X0_v50+5]");
						bool flag6 = (IntPtr)0 == (IntPtr)0;
						bool flag7 = !flag6;
						obj5 = 4294967295L;
						if (!flag7)
						{
							break;
						}
						num2 = Time.time;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ X0_v50+68]");
						num7 = 0f;
						float num14 = (float)obj28;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ X0_v50+68]");
						num = num14 + 0f;
						bool flag8 = num2 < num;
						obj5 = 4294967295L;
						if (!flag8)
						{
							_ = 0;
							float num15 = UnityEngine.Random.Range(0.025f, 0.2f);
							float num16 = UnityEngine.Random.Range(0.2f, 3f);
							float num17 = UnityEngine.Random.Range(0.2f, 3f);
							float num18 = UnityEngine.Random.Range(0.2f, 3f);
							_ = 0;
							_ = 0;
							object obj29 = (long)(IntPtr)obj - 224L;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-E0]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X29-D8]");
							_ = 0;
							num2 = Time.time;
							obj28 = num2;
							num7 = num18;
							obj5 = 4294967295L;
							num = num17;
						}
					}
					continue;
					IL_0444:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0823;
				}
				obj4 = (long)(IntPtr)obj4 + 1L;
				_ = 273;
				object obj30 = (long)(IntPtr)obj - 192L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj31 = (long)(IntPtr)obj4 + 1L;
				if (obj31 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X24_v1+v357 @ X25_v8*4]");
					if ((IntPtr)0 == (IntPtr)273)
					{
						int num19 = (int)((long)(IntPtr)obj5 ^ (long)(IntPtr)obj4);
						obj4 = (long)(IntPtr)obj4 + (long)num19;
						continue;
					}
				}
				bool flag9 = num3 == 0;
				num3 = 0;
				if (!flag9)
				{
					ex = null;
					num3 = 0;
					throw new TypeLoadException();
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0xCC3F94", Offset = "0xCC3F94", Length = "0xA00")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = &v37 @ X29;\n\tgoto L_0027;\n\tv51 = *([1F0A348]);\n\tv52 = *([v51 @ X8_v125]);\n\tv53 = \"il2cpp_codegen_initialize_method\"(v52, methodInfo, v55, v56, v57, v58, v59, v60, deltaTime, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([2023760]) = v70;\nL_0027:\n\tv74 = &v37 @ X29 - 0x28;\n\t*([v37 @ X29-C0]) = 0;\n\t*([v37 @ X29-B0]) = 0;\n\t*([v37 @ X29-E0]) = 0;\n\t*([v37 @ X29-D0]) = 0;\n\t*([v74 @ X30_v1-100]) = &v73 @ stack_-160;\n\tv80 = Morpeh.Filter::GetEnumerator(this.filterAttacks);\n\t*([v37 @ X29-B0]) = *([v37 @ X29-F0]);\n\t*([v37 @ X29-C0]) = *([v37 @ X29-100]);\n\tv251 = &v37 @ X29 - 0x34;\n\t*([v251 @ X30_v15-100]) = 0.1f;\n\tv253 = &v37 @ X29 - 0x30;\n\t*([v253 @ X30_v16-100]) = deltaTime;\n\tgoto L_035B;\nL_004F:\n\tv625 = *([v37 @ X29-B8]);\n\tv865 = *([v342 @ X25_v12 (Il2CppMethodInfo)]);\n\tv866 = *([v625 @ X20_v12]);\n\tv870 = *([v866 @ X8_v27+126]) == 0;\n\tif (v870) goto L_0075;\n\tv1288 = *([v866 @ X8_v27+B0]) + 8;\nL_005C:\n\t;\n\tv1293 = *([v1288 @ X11_v42-8]) == *([v865 @ X22_v16+18]);\n\tif (v1293) goto L_0077;\n\tv1287 = v1287 + 1;\n\tv1432 = v1287 < *([v866 @ X8_v27+126]);\n\tv1055 = ~v1432;\n\tv1288 = v1288 + 0x10;\n\tv1039 = ~v1055;\n\tif (v1039) goto L_005C;\nL_0075:\n\tv1439 = 0x8909C4(v625, *([v865 @ X22_v16+18]), *([v865 @ X22_v16+48]), v56, v57, v58, v59, v60, v454, v403, v298, v280, v278, v276, v282, v67);\n\tgoto L_007C;\nL_0077:\n\t;\n\tv1434 = *([v1288 @ X11_v42]) + *([v865 @ X22_v16+48]);\n\tv1435 = v1434 << 4;\n\tv1436 = v866 + v1435;\n\tv1439 = v1436 + 0x130;\nL_007C:\n\t;\n\tv1443 = 0x8D8294(*([v1439 @ X0_v49+8]), v865, *([v865 @ X22_v16+48]), v56, v57, v58, v59, v60, v454, v403, v298, v280, v278, v276, v282, v67);\n\t*([v1443 @ X0_v51])(v1131, v625, v1443, *([v865 @ X22_v16+48]), v56, v57, v58, v59, v60, v454, v403, v298, v280, v278, v276, v282, v67);\n\tv1136 = this.filterPinata;\n\tv1619 = v1136.world;\n\tv1620 = v1136.entitiesCacheForBags;\n\tv1337 = v1619.Entities;\n\tv1621 = v1620[0];\n\tv1339 = v1337[v1621 @ X8_v32 (System.Int32)];\n\tv1469 = *([v340 @ X28_v12 (Il2CppMethodInfo)]);\n\tv1622 = *([v1339 @ X22_v17 (Morpeh.Entity)]);\n\tv1606 = *([v1469 @ X23_v16 (System.Int32)+48]);\n\tv1625 = *([v1622 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v1625) goto L_00B4;\n\tv1666 = *([v1622 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_009B:\n\t;\n\tv1671 = *([v1666 @ X11_v37-8]) == *([v1469 @ X23_v16 (System.Int32)+18]);\n\tif (v1671) goto L_00B6;\n\tv1665 = v1665 + 1;\n\tv1676 = v1665 < *([v1622 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv1648 = ~v1676;\n\tv1666 = v1666 + 0x10;\n\tv1632 = ~v1648;\n\tif (v1632) goto L_009B;\nL_00B4:\n\tv1683 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v1337[v1621 @ X8_v32 (System.Int32)], *([v1469 @ X23_v16 (System.Int32)+18]));\n\tgoto L_00BB;\nL_00B6:\n\t;\n\tv1678 = *([v1666 @ X11_v37]) + v1606;\n\tv1679 = v1678 << 4;\n\tv1680 = v1622 + v1679;\n\tv1683 = v1680 + 0x130;\nL_00BB:\n\t;\n\tv1687 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(*([v1683 @ X0_v54+8]), v1469);\n\t*([v1687 @ X0_v56])(v1690, v1337[v1621 @ X8_v32 (System.Int32)], v1687, v1606, v56, v57, v58, v59, v60, v454, v403, v298, v280, v278, v276, v282, v67);\n\tv1693 = Morpeh.Filter::GetEnumerator(this.filterHands);\n\tv403 = *([v37 @ X29-100]);\n\tv454 = *([v37 @ X29-F0]);\n\t*([v37 @ X29-E0]) = *([v37 @ X29-100]);\n\t*([v37 @ X29-D0]) = *([v37 @ X29-F0]);\n\tgoto L_0174;\nL_00DA:\n\tv1977 = UnityEngine.Transform::get_position(*([v1740 @ X0_v109+18]));\n\tgoto L_00F0;\n\tv2034 = *([v2000 @ X0_v117+E0]);\n\tv2035 = v2034 == 0;\n\tv2036 = ~v2035;\n\tif (v2036) goto L_00F0;\n\tv2038 = \"il2cpp_codegen_runtime_class_init\"(v2000, v1976, v1205, v56, v57, v58, v59, v60, v1977, v1996, v1997, v280, v278, v276, v282, v67);\nL_00F0:\n\tv282 = *([v1740 @ X0_v109+64]) * v368;\n\t// 249 MakeStruct v1702 @ AGGCC421C_1_v16 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1740 @ X0_v109+30], [v1740 @ X0_v109+34], [v1740 @ X0_v109+38]\n\tv1730 = UnityEngine.Vector3::MoveTowards(v1977, v1702, v282);\n\tv403 = v1730.y;\n\tv298 = v1730.z;\n\tUnityEngine.Transform::set_position(*([v1740 @ X0_v109+18]), v1730);\n\tgoto L_0174;\nL_0102:\n\t;\n\tv1858 = *([v1740 @ X0_v109+6]) == 0;\n\tv1859 = ~v1858;\n\tif (v1859) goto L_0126;\n\tv1237 = *([v1740 @ X0_v109+18]) == 0;\n\tif (v1237) goto L_0207;\n\tv1873 = UnityEngine.Component::GetComponent(*([v1740 @ X0_v109+18]));\n\tgoto L_011A;\n\tv1926 = *([v1896 @ X0_v141+E0]);\n\tv1927 = v1926 == 0;\n\tv1928 = ~v1927;\n\tif (v1928) goto L_011A;\n\tv1930 = \"il2cpp_codegen_runtime_class_init\"(v1896, v1221, v1205, v56, v57, v58, v59, v60, v1213, v300, v298, v280, v278, v276, v282, v67);\nL_011A:\n\tv1238 = v1873 == 0;\n\tif (v1238) goto L_020A;\n\tv1217 = v1962.Attack;\n\tUnityEngine.Animator::SetTrigger(v1873, v1962.Attack);\n\t*([v1740 @ X0_v109+6]) = 1;\nL_0126:\n\t;\n\tv1233 = *([v1740 @ X0_v109+18]) == 0;\n\tif (v1233) goto L_01FE;\n\tv1214 = UnityEngine.Transform::get_position(*([v1740 @ X0_v109+18]));\n\tv1234 = *([v1690 @ X0_v58]) == 0;\n\tif (v1234) goto L_0201;\n\tv1933 = UnityEngine.GameObject::get_transform(*([v1690 @ X0_v58]));\n\tv1235 = v1933 == 0;\n\tif (v1235) goto L_0203;\n\tv1973 = UnityEngine.Transform::get_position(v1933);\n\tv1729 = &v37 @ X29 - 0x2C;\n\t*([v1729 @ X30_v38-100]) = v1214;\n\tgoto L_0158;\n\tv2021 = *([v1992 @ X0_v132+E0]);\n\tv2022 = v2021 == 0;\n\tv2023 = ~v2022;\n\tif (v2023) goto L_0158;\n\tv2025 = \"il2cpp_codegen_runtime_class_init\"(v1992, v1972, v1206, v56, v57, v58, v59, v60, v1973, v1987, v1988, v280, v278, v276, v282, v67);\nL_0158:\n\t// 344 MakeStruct v1699 @ AGGCC4334_1_v16 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1740 @ X0_v109+C], [v1740 @ X0_v109+10], [v1740 @ X0_v109+14]\n\tv2033 = UnityEngine.Vector3::op_Addition(v1973, v1699);\n\tv2050 = &v37 @ X29 - 0x30;\n\tv368 = *([v2050 @ X23_v25-100]);\n\tv282 = *([v1740 @ X0_v109+64]) * *([v2050 @ X23_v25-100]);\n\tv1728 = &v37 @ X29 - 0x2C;\n\t// 360 MakeStruct v1698 @ AGGCC4368_0_v16 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1728 @ X23_v26-100], v1214.y (System.Single), v1214.z (System.Single)\n\tv1731 = UnityEngine.Vector3::MoveTowards(v1698, v2033, v282);\n\tv403 = v1731.y;\n\tv298 = v1731.z;\n\tUnityEngine.Transform::set_position(*([v1740 @ X0_v109+18]), v1731);\n\tgoto L_0174;\nL_0173:\n\t*([v1740 @ X0_v109+5]) = 1;\nL_0174:\n\tv1752 = &v37 @ X29 - 0xE0;\n\tv1753 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v1752, 0);\n\tv1754 = v1753 & 1;\n\tv1755 = v1754 == 0;\n\tif (v1755) goto L_01F4;\n\tv1155 = *([v37 @ X29-D8]);\n\tv1232 = *([v37 @ X29-D8]) == 0;\n\tif (v1232) goto L_01FB;\n\tv1143 = Il2CppMethodInfo;\n\tv1758 = *([v1155 @ X23_v23 (Morpeh.Globals.BaseGlobalVariable`1<System.Int32>)]);\n\tv1606 = *([v1143 @ X24_v18 (Il2CppMethodInfo)+48]);\n\tv1761 = *([v1758 @ X8_v85 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]) == 0;\n\tif (v1761) goto L_01A0;\n\tv1809 = *([v1758 @ X8_v85 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]) + 8;\nL_0187:\n\t;\n\tv1814 = *([v1809 @ X11_v32-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1814) goto L_01A2;\n\tv1808 = v1808 + 1;\n\tv1833 = v1808 < *([v1758 @ X8_v85 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]);\n\tv1786 = ~v1833;\n\tv1809 = v1809 + 0x10;\n\tv1770 = ~v1786;\n\tif (v1770) goto L_0187;\nL_01A0:\n\tv1840 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(*([v37 @ X29-D8]), Il2CppClass<Morpeh.IEntity>);\n\tgoto L_01A7;\nL_01A2:\n\t;\n\tv1835 = *([v1809 @ X11_v32]) + v1606;\n\tv1836 = v1835 << 4;\n\tv1837 = v1758 + v1836;\n\tv1840 = v1837 + 0x130;\nL_01A7:\n\t;\n\tv1844 = Morpeh.IEntity::GetComponent(*([v1840 @ X0_v105+8]));\n\t*([v1844 @ X0_v107 (GBG.Pinata.ECS.Components.HandComponent&)])(v1740, *([v37 @ X29-D8]), v1844, v1606, v56, v57, v58, v59, v60, v454, v403, v298, v280, v278, v276, v282, v67);\n\tv1745 = *([v1740 @ X0_v109+4]) == 0;\n\tif (v1745) goto L_01C3;\n\tv1855 = *([v1740 @ X0_v109+8]) < 0;\n\tv1200 = ~v1855;\n\tv1185 = *([v1740 @ X0_v109+8]) == 0;\n\tv1856 = ~v1200;\n\tv1160 = v1856 | v1185;\n\tif (v1160) goto L_0102;\n\tv454 = *([v1740 @ X0_v109+8]) - v368;\n\t*([v1740 @ X0_v109+8]) = v454;\n\tgoto L_0174;\nL_01C3:\n\t;\n\tv1857 = *([v1740 @ X0_v109+5]) == 0;\n\tv1746 = ~v1857;\n\tif (v1746) goto L_0174;\n\tv1236 = *([v1740 @ X0_v109+18]) == 0;\n\tif (v1236) goto L_0205;\n\tv1870 = UnityEngine.Transform::get_position(*([v1740 @ X0_v109+18]));\n\tv298 = v1870.z\n// ... truncated")]
		private unsafe void MoveHands(float deltaTime)
		{
			//IL_116f: Expected O, but got I
			//IL_0045: Expected O, but got I
			//IL_005a: Expected O, but got I
			//IL_006c: Expected O, but got I8
			//IL_11a0: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_00ab: Expected O, but got I
			//IL_0fe0: Expected O, but got I
			//IL_0ff0: Expected O, but got I
			//IL_0fff: Expected O, but got I
			//IL_100a: Expected I, but got O
			//IL_1088: Expected O, but got I
			//IL_10a5: Expected O, but got I
			//IL_00f2: Expected O, but got I
			//IL_020c: Expected I, but got O
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Expected O, but got Unknown
			//IL_0199: Expected O, but got I
			//IL_01a8: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_10ee: Expected O, but got I
			//IL_10fe: Expected O, but got I
			//IL_127a: Expected O, but got I
			//IL_025a: Expected O, but got I
			//IL_0342: Expected F4, but got I
			//IL_0352: Expected F4, but got I
			//IL_1299: Expected O, but got I
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Expected O, but got Unknown
			//IL_030e: Expected O, but got I
			//IL_031d: Expected O, but got I
			//IL_0a23: Expected O, but got I
			//IL_0a33: Expected O, but got I
			//IL_0a42: Expected O, but got I
			//IL_02a6: Expected O, but got I
			//IL_0aeb: Expected O, but got I
			//IL_0b08: Expected O, but got I
			//IL_0722: Expected O, but got I
			//IL_0a5b: Expected I, but got O
			//IL_0b34: Expected O, but got I
			//IL_0b44: Expected O, but got I
			//IL_0755: Expected I, but got O
			//IL_081a: Expected O, but got I
			//IL_0b80: Expected I4, but got I8
			//IL_0b8e: Expected O, but got I
			//IL_132e: Expected O, but got I
			//IL_07a2: Expected O, but got I
			//IL_105f: Expected I, but got O
			//IL_1074: Expected I, but got O
			//IL_0829: Unknown result type (might be due to invalid IL or missing references)
			//IL_082e: Expected O, but got Unknown
			//IL_084b: Expected O, but got I
			//IL_085a: Expected O, but got I
			//IL_07ee: Expected O, but got I
			//IL_0948: Expected O, but got I
			//IL_096e: Expected O, but got I
			//IL_097e: Expected F4, but got I
			//IL_053e: Expected O, but got I
			//IL_0a84: Expected I, but got O
			//IL_04e0: Expected O, but got I
			//IL_0c91: Expected O, but got I
			//IL_0ca1: Expected F4, but got I
			//IL_0cb0: Expected O, but got I
			//IL_0cc0: Expected F4, but got I
			//IL_0382: Expected O, but got I
			//IL_0a97: Expected I, but got O
			//IL_1438: Expected O, but got I
			//IL_03bb: Expected F4, but got I
			//IL_03d0: Expected F4, but got I
			//IL_03e5: Expected F4, but got I
			//IL_0429: Expected O, but got I
			//IL_0a0f: Expected I, but got O
			//IL_05a5: Expected O, but got I
			//IL_0528: Expected I, but got O
			//IL_1392: Expected O, but got I
			//IL_13a2: Expected O, but got I
			//IL_13b1: Expected O, but got I
			//IL_043e: Expected F4, but got I
			//IL_044e: Expected F4, but got I
			//IL_045e: Expected O, but got I
			//IL_05c7: Expected F4, but got I
			//IL_05dc: Expected F4, but got I
			//IL_05f1: Expected F4, but got I
			//IL_0612: Expected O, but got I
			//IL_0622: Expected F4, but got I
			//IL_0650: Expected O, but got I
			//IL_0666: Expected F4, but got I
			//IL_0e4c: Expected O, but got I
			//IL_0e69: Expected O, but got I
			//IL_0cef: Expected O, but got I
			//IL_06d3: Expected O, but got I
			//IL_0e95: Expected O, but got I
			//IL_0ea5: Expected O, but got I
			//IL_0d22: Expected I, but got O
			//IL_0de7: Expected O, but got I
			//IL_0ee1: Expected I4, but got I8
			//IL_0eef: Expected O, but got I
			//IL_13f1: Expected O, but got I
			//IL_0d6f: Expected O, but got I
			//IL_0df6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dfb: Expected O, but got Unknown
			//IL_0e18: Expected O, but got I
			//IL_0e27: Expected O, but got I
			//IL_0dbb: Expected O, but got I
			object obj = obj;
			object obj2 = (long)(IntPtr)obj - 40L;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Filter.EntityEnumerator enumerator = filterAttacks.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-F0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-100]");
			_ = 0;
			object obj3 = (long)(IntPtr)obj - 52L;
			_ = 0.1f;
			object obj4 = (long)(IntPtr)obj - 48L;
			object obj5 = 4294967295L;
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)0;
			float num = 0.1f;
			float num2 = deltaTime;
			object obj6 = default(object);
			IntPtr intPtr4;
			object obj21 = default(object);
			Vector3 target = default(Vector3);
			object obj27 = default(object);
			Vector3 vector2 = default(Vector3);
			Vector3 current = default(Vector3);
			object obj39 = default(object);
			object obj44 = default(object);
			while (true)
			{
				BaseGlobalVariable<int> baseGlobalVariable = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 192L);
				baseGlobalVariable.Value = 0;
				if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-B8]");
					object obj7 = 0;
					object obj8 = (long)intPtr2;
					object obj9 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ X8_v27+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0157;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ X8_v27+B0]");
					object obj10 = 0L + 8L;
					int num3 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ X11_v42-8]");
						IntPtr intPtr3 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v865 @ X22_v16+18]");
						if (intPtr3 == (IntPtr)0)
						{
							break;
						}
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ X8_v27+126]");
						bool flag = (long)num4 < 0L;
						bool flag2 = !flag;
						obj10 = (long)(IntPtr)obj10 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0157;
					}
					object obj11 = obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v865 @ X22_v16+48]");
					object obj12 = obj11 + 0;
					int num5 = (int)((long)(IntPtr)obj12 << 4);
					object obj13 = (long)(IntPtr)obj9 + (long)num5;
					object obj14 = (long)(IntPtr)obj13 + 304L;
					goto IL_1212;
				}
				object obj15 = (long)(IntPtr)obj - 40L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ X30_v18-100]");
				object obj16 = 0;
				obj5 = (long)(IntPtr)obj5 + 1L;
				_ = 603;
				intPtr4 = (IntPtr)null;
				break;
				IL_0157:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_1212;
				IL_1212:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1443 @ X0_v51] (should have been resolved before IL gen)");
				Filter filter = filterPinata;
				World world = filter.world;
				int[] entitiesCacheForBags = filter.entitiesCacheForBags;
				Entity[] entities = world.Entities;
				int num6 = entitiesCacheForBags[0];
				Entity entity = entities[num6];
				int value = (int)(long)intPtr;
				IntPtr intPtr5 = (IntPtr)entity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1469 @ X23_v16 (System.Int32)+48]");
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1622 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_02bf;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1622 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+B0]");
				object obj17 = 0L + 8L;
				int num7 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1666 @ X11_v37-8]");
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1469 @ X23_v16 (System.Int32)+18]");
					if (intPtr7 == (IntPtr)0)
					{
						break;
					}
					num7++;
					int num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1622 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]");
					bool flag3 = (long)num8 < 0L;
					bool flag4 = !flag3;
					obj17 = (long)(IntPtr)obj17 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_02bf;
				}
				object obj18 = obj17 + (long)intPtr6;
				int num9 = (int)((long)(IntPtr)obj18 << 4);
				object obj19 = (long)intPtr5 + (long)num9;
				object obj20 = (long)(IntPtr)obj19 + 304L;
				goto IL_1264;
				IL_02bf:
				Entity entity2 = entities[num6];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1469 @ X23_v16 (System.Int32)+18]");
				((BaseGlobalVariable<int>)(object)entity2).Value = 0;
				goto IL_1264;
				IL_1264:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1683 @ X0_v54+8]");
				((BaseGlobalVariable<int>)0).Value = value;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1687 @ X0_v56] (should have been resolved before IL gen)");
				Filter.EntityEnumerator enumerator2 = filterHands.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-100]");
				float num10 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-F0]");
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-100]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-F0]");
				_ = 0;
				NullReferenceException ex;
				while (true)
				{
					BaseGlobalVariable<int> baseGlobalVariable2 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 224L);
					baseGlobalVariable2.Value = 0;
					if ((int)((long)(IntPtr)obj21 & 1L) == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-D8]");
					BaseGlobalVariable<int> baseGlobalVariable3 = (BaseGlobalVariable<int>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-D8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						IntPtr intPtr8 = (IntPtr)0;
						IntPtr intPtr9 = (IntPtr)baseGlobalVariable3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1143 @ X24_v18 (Il2CppMethodInfo)+48]");
						intPtr6 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1758 @ X8_v85 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0807;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1758 @ X8_v85 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
						object obj22 = 0L + 8L;
						int num11 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1809 @ X11_v32-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num11++;
							int num12 = num11;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1758 @ X8_v85 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
							bool flag5 = (long)num12 < 0L;
							bool flag6 = !flag5;
							obj22 = (long)(IntPtr)obj22 + 16L;
							if (!flag6)
							{
								continue;
							}
							goto IL_0807;
						}
						object obj23 = obj22 + (long)intPtr6;
						int num13 = (int)((long)(IntPtr)obj23 << 4);
						object obj24 = (long)intPtr9 + (long)num13;
						object obj25 = (long)(IntPtr)obj24 + 304L;
						goto IL_131c;
					}
					ex = new NullReferenceException();
					IntPtr intPtr10 = (IntPtr)null;
					goto IL_1363;
					IL_1363:
					if (intPtr10 != (IntPtr)1)
					{
						Animator component = ((Component)(object)ex).GetComponent<Animator>();
						return;
					}
					goto IL_104a;
					IL_0807:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-D8]");
					((BaseGlobalVariable<int>)0).Value = 0;
					goto IL_131c;
					IL_131c:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1840 @ X0_v105+8]");
					ref HandComponent component2 = ref ((IEntity)0).GetComponent<HandComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1844 @ X0_v107 (GBG.Pinata.ECS.Components.HandComponent&)] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+4]");
					int num14;
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+8]");
						bool flag7 = 0L < 0L;
						bool flag8 = !flag7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+8]");
						bool flag9 = (IntPtr)0 == (IntPtr)0;
						bool flag10 = !flag8;
						if (!(flag10 || flag9))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+8]");
							num = 0f - num2;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+6]");
						bool flag11 = (IntPtr)0 == (IntPtr)0;
						bool flag12 = !flag11;
						num14 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref component2);
						if (flag12)
						{
							goto IL_12d3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
							Animator component3 = ((Component)0).GetComponent<Animator>();
							if ((object)component3 != null)
							{
								num14 = Attack;
								component3.SetTrigger(Attack);
								_ = 1;
								intPtr6 = (IntPtr)null;
								goto IL_12d3;
							}
							ex = new NullReferenceException();
							intPtr10 = (IntPtr)0;
						}
						else
						{
							ex = new NullReferenceException();
							intPtr10 = (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref component2);
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+5]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
							Vector3 position = ((Transform)0).position;
							float z = position.z;
							object obj26 = (long)(IntPtr)obj - 52L;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1210 @ X30_v37-100]");
							num10 = 0f;
							float num15 = position.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+38]");
							float f = num15 - 0f;
							num = Mathf.Abs(f);
							float num16 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1210 @ X30_v37-100]");
							if (!(num16 > 0f))
							{
								_ = 1;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
								Vector3 position2 = ((Transform)0).position;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+64]");
								float maxDistanceDelta = 0f * num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+30]");
								target.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+34]");
								target.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+38]");
								target.z = 0f;
								Vector3 position3 = Vector3.MoveTowards(position2, target, maxDistanceDelta);
								num10 = position3.y;
								z = position3.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
								((Transform)0).position = position3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+38]");
								float num17 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+34]");
								float num18 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+30]");
								Vector3 vector = (Vector3)0;
								num = position3.x;
								continue;
							}
							ex = new NullReferenceException();
							intPtr10 = (IntPtr)null;
						}
						else
						{
							ex = new NullReferenceException();
							intPtr10 = (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref component2);
						}
					}
					goto IL_1363;
					IL_12d3:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
						Vector3 position4 = ((Transform)0).position;
						if (obj27 != null)
						{
							Transform transform = ((GameObject)obj27).transform;
							if ((object)transform != null)
							{
								Vector3 position5 = transform.position;
								object obj28 = (long)(IntPtr)obj - 44L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+C]");
								vector2.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+10]");
								vector2.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+14]");
								vector2.z = 0f;
								Vector3 vector3 = position5 + vector2;
								object obj29 = (long)(IntPtr)obj - 48L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2050 @ X23_v25-100]");
								num2 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+64]");
								float num19 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2050 @ X23_v25-100]");
								float maxDistanceDelta = num19 * 0f;
								object obj30 = (long)(IntPtr)obj - 44L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1728 @ X23_v26-100]");
								current.x = 0f;
								current.y = position4.y;
								current.z = position4.z;
								Vector3 position6 = Vector3.MoveTowards(current, vector3, maxDistanceDelta);
								num10 = position6.y;
								float z = position6.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1740 @ X0_v109+18]");
								((Transform)0).position = position6;
								float num17 = vector3.z;
								float num18 = vector3.y;
								Vector3 vector = vector3;
								num = position6.x;
								continue;
							}
							ex = new NullReferenceException();
							intPtr10 = (IntPtr)null;
						}
						else
						{
							ex = new NullReferenceException();
							intPtr10 = (IntPtr)null;
						}
					}
					else
					{
						ex = new NullReferenceException();
						intPtr10 = (IntPtr)num14;
					}
					goto IL_1363;
				}
				object obj31 = (long)(IntPtr)obj - 40L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1756 @ X30_v25-100]");
				object obj32 = 0;
				obj5 = (long)(IntPtr)obj5 + 1L;
				_ = 369;
				BaseGlobalVariable<int> baseGlobalVariable4 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 224L);
				baseGlobalVariable4.Value = 0;
				object obj33 = (long)(IntPtr)obj5 + 1L;
				if (obj33 != null)
				{
					object obj34 = (long)(IntPtr)obj - 40L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1819 @ X30_v36-100]");
					object obj35 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1820 @ X8_v81+v446 @ X26_v20*4]");
					if ((IntPtr)0 == (IntPtr)369)
					{
						int num20 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj5);
						obj5 = (long)(IntPtr)obj5 + (long)num20;
						if (!EnemyIsKicked)
						{
							continue;
						}
						List<int> batchedChanges = EnemyIsKicked.BatchedChanges;
						if (batchedChanges.Count >= 1)
						{
							object obj36 = obj5;
							int num21 = 0;
							while (true)
							{
								List<int> batchedChanges2 = EnemyIsKicked.BatchedChanges;
								if (num21 >= batchedChanges2.Count)
								{
									throw new ArgumentOutOfRangeException();
								}
								int[] items = batchedChanges2._items;
								Filter.EntityEnumerator enumerator3 = filterHands.GetEnumerator();
								object obj37 = (long)(IntPtr)obj - 16L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2061 @ X30_v29-100]");
								num = 0f;
								object obj38 = (long)(IntPtr)obj - 32L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ X30_v30-100]");
								num10 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ X30_v30-100]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2061 @ X30_v29-100]");
								_ = 0;
								while (true)
								{
									BaseGlobalVariable<int> baseGlobalVariable5 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 224L);
									baseGlobalVariable5.Value = 0;
									if ((int)((long)(IntPtr)obj39 & 1L) == 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-D8]");
									BaseGlobalVariable<int> baseGlobalVariable6 = (BaseGlobalVariable<int>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-D8]");
									if ((IntPtr)0 != (IntPtr)0)
									{
										IntPtr intPtr11 = (IntPtr)0;
										IntPtr intPtr12 = (IntPtr)baseGlobalVariable6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2063 @ X23_v22 (Il2CppMethodInfo)+48]");
										intPtr6 = (IntPtr)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2106 @ X8_v75 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
										if ((IntPtr)0 == (IntPtr)0)
										{
											goto IL_0dd4;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2106 @ X8_v75 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+B0]");
										object obj40 = 0L + 8L;
										int num22 = 0;
										while (true)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2156 @ X11_v26-8]");
											if ((IntPtr)0 == (IntPtr)0)
											{
												break;
											}
											num22++;
											int num23 = num22;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2106 @ X8_v75 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<System.Int32>>)+126]");
											bool flag13 = (long)num23 < 0L;
											bool flag14 = !flag13;
											obj40 = (long)(IntPtr)obj40 + 16L;
											if (!flag14)
											{
												continue;
											}
											goto IL_0dd4;
										}
										object obj41 = obj40 + (long)intPtr6;
										int num24 = (int)((long)(IntPtr)obj41 << 4);
										object obj42 = (long)intPtr12 + (long)num24;
										object obj43 = (long)(IntPtr)obj42 + 304L;
										goto IL_13df;
									}
									throw new NullReferenceException();
									IL_0dd4:
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X29-D8]");
									((BaseGlobalVariable<int>)0).Value = 0;
									goto IL_13df;
									IL_13df:
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2196 @ X0_v94+8]");
									ref HandComponent component4 = ref ((IEntity)0).GetComponent<HandComponent>();
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2200 @ X0_v96 (GBG.Pinata.ECS.Components.HandComponent&)] (should have been resolved before IL gen)");
									if ((IntPtr)obj44 == (IntPtr)items[num21])
									{
										_ = 0;
										break;
									}
								}
								object obj45 = (long)(IntPtr)obj - 40L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2104 @ X30_v31-100]");
								object obj46 = 0;
								obj5 = (long)(IntPtr)obj36 + 1L;
								_ = 503;
								BaseGlobalVariable<int> baseGlobalVariable7 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 224L);
								baseGlobalVariable7.Value = 0;
								object obj47 = (long)(IntPtr)obj5 + 1L;
								if (obj47 != null)
								{
									object obj48 = (long)(IntPtr)obj - 40L;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2166 @ X30_v34-100]");
									object obj49 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2167 @ X8_v71+v446 @ X26_v20*4]");
									if ((IntPtr)0 == (IntPtr)503)
									{
										int num25 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj5);
										obj5 = (long)(IntPtr)obj5 + (long)num25;
										num21++;
										bool flag15 = num21 < batchedChanges.Count;
										obj36 = obj5;
										if (!flag15)
										{
											break;
										}
										continue;
									}
								}
								TypeLoadException ex2 = new TypeLoadException();
								throw new NullReferenceException();
							}
						}
						int value2 = CurrentWeaponAmmo.Value;
						int value3 = value2 - 1;
						CurrentWeaponAmmo.Value = value3;
						Filter filter2 = filterHands;
						int num26 = filter2.Length - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1131 @ X0_v53+8]");
						if (0L >= (long)num26)
						{
							int num27 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1131 @ X0_v53+8]");
							int num27 = 1;
						}
						intPtr6 = (IntPtr)0;
						intPtr = (IntPtr)0;
						intPtr2 = (IntPtr)0;
						continue;
					}
				}
				TypeLoadException ex3 = new TypeLoadException();
				NullReferenceException ex4 = new NullReferenceException();
				throw new NullReferenceException();
				IL_104a:
				Animator component5 = ((Component)(object)ex).GetComponent<Animator>();
				intPtr4 = (IntPtr)component5;
				Animator component6 = component5.GetComponent<Animator>();
				intPtr6 = (IntPtr)ex;
				break;
			}
			BaseGlobalVariable<int> baseGlobalVariable8 = (BaseGlobalVariable<int>)((long)(IntPtr)obj - 192L);
			baseGlobalVariable8.Value = 0;
			object obj50 = (long)(IntPtr)obj5 + 1L;
			if (obj50 != null)
			{
				if (intPtr4 == (IntPtr)0)
				{
					return;
				}
				object obj51 = (long)(IntPtr)obj - 40L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1363 @ X30_v7-100]");
				object obj52 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1364 @ X8_v8+v446 @ X26_v20*4]");
				if ((IntPtr)0 == (IntPtr)603)
				{
					return;
				}
			}
			else if (intPtr4 == (IntPtr)0)
			{
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0xCC4994", Offset = "0xCC4994", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AttackSystem()
		{
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0xCC499C", Offset = "0xCC499C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EAF830]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023761]) = v35;\nL_0015:\n\tv40 = UnityEngine.Animator::StringToHash(\"attack\");\n\tv44.Attack = v40;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AttackSystem()
		{
			int attack = Animator.StringToHash("attack");
			Attack = attack;
		}
	}
}
