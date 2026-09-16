using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using GBG.Pinata.ECS.Markers;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000071")]
	public class ShowHideEnemySystem : UpdateSystem
	{
		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x28")]
		private Filter filterUp;

		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x30")]
		private Filter filterDown;

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0xCC6DE0", Offset = "0xCC6DE0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0C4B8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202376E]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tv69 = Morpeh.Filter::With(v52, 1);\n\tthis.filterUp = v69;\n\tv53 = Morpeh.FilterProvider::get_All(this.filter);\n\tv54 = Morpeh.Filter::With(v53, 1);\n\tv84 = Morpeh.Filter::With(v54, 1);\n\tthis.filterDown = v84;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<EnemyHolderComponent>();
			Filter filter2 = filter.With<EnemyMoveUpMarker>();
			filterUp = filter2;
			Filter all2 = Filter.All;
			Filter filter3 = all2.With<EnemyHolderComponent>();
			Filter filter4 = filter3.With<EnemyMoveDownMarker>();
			filterDown = filter4;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0xCC6EB0", Offset = "0xCC6EB0", Length = "0x5C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = *([1EBB248]);\n\tv39 = *([v38 @ X8_v37]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, deltaTime, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([202376F]) = v57;\nL_0027:\n\tv67 = &v262 @ stack_-D0_v4 (System.Single);\n\tv70 = Morpeh.Filter::GetEnumerator(this.filterUp);\n\tv262 = *([v67 @ X8_v6]);\nL_003E:\n\tv438 = 0x15F75B8(&v262 @ stack_-D0_v4 (System.Single), 0, v319, v43, v44, v45, v46, v47, v209, v212, v132, v120, v117, v114, v53, v54);\n\tv504 = v438 & 1;\n\tv505 = v504 == 0;\n\tif (v505) goto L_0100;\n\tv605 = Il2CppMethodInfo;\n\tv606 = *([v506 @ stack_-88]);\n\tv609 = *([v606 @ X8_v24+126]) == 0;\n\tif (v609) goto L_0068;\n\tv679 = *([v606 @ X8_v24+B0]) + 8;\nL_004F:\n\t;\n\tv684 = *([v679 @ X11_v31-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v684) goto L_006A;\n\tv678 = v678 + 1;\n\tv692 = v678 < *([v606 @ X8_v24+126]);\n\tv634 = ~v692;\n\tv679 = v679 + 0x10;\n\tv618 = ~v634;\n\tif (v618) goto L_004F;\nL_0068:\n\tv699 = 0x8909C4(v506, Il2CppClass<Morpeh.IEntity>, *([v605 @ X21_v11 (Il2CppMethodInfo)+48]), v43, v44, v45, v46, v47, v209, v212, v132, v120, v117, v114, v53, v54);\n\tgoto L_006F;\nL_006A:\n\t;\n\tv694 = *([v679 @ X11_v31]) + *([v605 @ X21_v11 (Il2CppMethodInfo)+48]);\n\tv695 = v694 << 4;\n\tv696 = v606 + v695;\n\tv699 = v696 + 0x130;\nL_006F:\n\t;\n\tv703 = Morpeh.IEntity::GetComponent(*([v699 @ X0_v68+8]));\n\t*([v703 @ X0_v70 (GBG.Pinata.ECS.Components.EnemyHolderComponent&)])(v661, v506, v703, *([v605 @ X21_v11 (Il2CppMethodInfo)+48]), v43, v44, v45, v46, v47, v209, v212, v132, v120, v117, v114, v53, v54);\n\tv662 = *([v661 @ X0_v72]) == 0;\n\tif (v662) goto L_0105;\n\tv786 = UnityEngine.Transform::get_localPosition(*([v661 @ X0_v72]));\n\tv375 = v786.y >= *([v661 @ X0_v72+C]);\n\tif (v375) goto L_00BA;\n\tv798 = UnityEngine.Transform::get_localPosition(*([v661 @ X0_v72]));\n\tv814 = *([v661 @ X0_v72+8]) * deltaTime;\n\tv819 = 0x1586898(&v262 @ stack_-D0_v4 (System.Single), 0, *([v605 @ X21_v11 (Il2CppMethodInfo)+48]), v43, v44, v45, v46, v47, 0, v814, 0, v120, v117, v114, v53, v54);\n\tgoto L_00AF;\n\tv898 = *([v871 @ X0_v89+E0]);\n\tv899 = v898 == 0;\n\tv900 = ~v899;\n\tif (v900) goto L_00AF;\n\tv902 = \"il2cpp_codegen_runtime_class_init\"(v871, v818, v408, v43, v44, v45, v46, v47, v816, v814, v817, v121, v118, v115, v53, v54);\nL_00AF:\n\t// 175 MakeStruct v359 @ AGGCC7070_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v67 @ X8_v6], [v67 @ X8_v6+4], 0\n\tv209 = UnityEngine.Vector3::op_Addition(v798, v359);\n\tv212 = v209.y;\n\tv132 = v209.z;\n\tUnityEngine.Transform::set_localPosition(*([v661 @ X0_v72]), v209);\n\tgoto L_003E;\nL_00BA:\n\tv801 = UnityEngine.Transform::get_localPosition(*([v661 @ X0_v72]));\n\tv212 = v801.y;\n\tv132 = v801.z;\n\tv826 = 0x1586898(&v357 @ stack_-A0_v7 (UnityEngine.Vector3), 0, *([v605 @ X21_v11 (Il2CppMethodInfo)+48]), v43, v44, v45, v46, v47, v801, *([v661 @ X0_v72+C]), v801.z, v120, v117, v114, v53, v54);\n\t// 201 MakeStruct v354 @ AGGCC70B8_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v357 @ stack_-A0_v7 (UnityEngine.Vector3), v801.y (System.Single), v801.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(*([v661 @ X0_v72]), v354);\n\tv415 = Il2CppMethodInfo;\n\tv907 = *([v506 @ stack_-88]);\n\tv319 = *([v415 @ X21_v13 (Il2CppMethodInfo)+48]);\n\tv430 = *([v907 @ X8_v27+126]) == 0;\n\tif (v430) goto L_00EE;\n\tv963 = *([v907 @ X8_v27+B0]) + 8;\nL_00D5:\n\t;\n\tv968 = *([v963 @ X11_v26-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v968) goto L_00F0;\n\tv962 = v962 + 1;\n\tv976 = v962 < *([v907 @ X8_v27+126]);\n\tv944 = ~v976;\n\tv963 = v963 + 0x10;\n\tv928 = ~v944;\n\tif (v928) goto L_00D5;\nL_00EE:\n\tv983 = 0x8909C4(v506, Il2CppClass<Morpeh.IEntity>, v319, v43, v44, v45, v46, v47, v357, v212, v132, v120, v117, v114, v53, v54);\n\tgoto L_00F5;\nL_00F0:\n\t;\n\tv978 = *([v963 @ X11_v26]) + v319;\n\tv979 = v978 << 4;\n\tv980 = v907 + v979;\n\tv983 = v980 + 0x130;\nL_00F5:\n\t;\n\tv987 = Morpeh.IEntity::RemoveComponent(*([v983 @ X0_v78+8]));\n\tv987.m_value(v427, v506, v987, v319, v43, v44, v45, v46, v47, v357, v212, v132, v120, v117, v114, v53, v54);\n\tgoto L_003E;\nL_0100:\n\tv510 = 0x15F7664(&v262 @ stack_-D0_v4 (System.Single), 0, v319, v43, v44, v45, v46, v47, v209, v212, v132, v120, v117, v114, v53, v54);\n\tgoto L_012A;\n\tthrow System.NullReferenceException;\nL_0105:\n\tv665 = new System.NullReferenceException();\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\nL_011A:\n\tv297 = 0 != 1;\n\tif (v297) goto L_0236;\n\tv711 = 0x6D2BC0(v665, 0, v319, v43, v44, v45, v46, v47, v209, v212, v132, v120, v117, v114, v53, v54);\n\tv787 = 0x6D2490(v711, 0, v319, v43, v44, v45, v46, v47, v209, v212, v132, v120, v117, v114, v53, v54);\n\tv342 = 0x15F7664(&v262 @ stack_-D0_v4 (System.Single), 0, v319, v43, v44, v45, v46, v47, v209, v212, v132, v120, v117, v114, v53, v54);\n\tv802 = *([v711 @ X0_v62]) == 0;\n\tv344 = ~v802;\n\tif (v344) goto L_0207;\nL_012A:\n\tv691 = Morpeh.Filter::GetEnumerator(this.filterDown);\n\tv705 = v691.world;\nL_013B:\n\tv783 = 0x15F75B8(&v705 @ stack_-D0_v6 (Morpeh.World), 0, v319, v43, v44, v45, v46, v47, v760, v211, v132, v120, v117, v114, v53, v54);\n\tv788 = v783 & 1;\n\tv594 = v788 == 0;\n\tif (v594) goto L_01FF;\n\tv803 = Il2CppMethodInfo;\n\tv804 = *([v506 @ stack_-88]);\n\tv319 = *([v803 @ X20_v10 (Il2CppMethodInfo)+48]);\n\tv807 = *([v804 @ X8_v12+126]) == 0;\n\tif (v807) goto L_0165;\n\tv888 = *([v804 @ X8_v12+B0]) + 8;\nL_014C:\n\t;\n\tv893 = *([v888 @ X11_v18-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v893) goto L_0167;\n\tv887 = v887 + 1;\n\tv910 = v887 < *([v804 @ X8_v12+126]);\n\tv849 = ~v910;\n\tv888 = v888 + 0x10;\n\tv833 = ~v849;\n\tif (v833) goto L_014C;\nL_0165:\n\tv917 = 0x8909C4(v506, Il2CppClass<Morpeh.IEntity>, v319, v43, v44, v45, v46, v47, v760, v211, v132, v120, v117, v114, v53, v54);\n\tgoto L_016C;\nL_0167:\n\t;\n\tv912 = *([v888 @ X11_v18]) + v319;\n\tv913 = v912 << 4;\n\tv914 = v804 + v913;\n\tv917 = v914 + 0x130;\nL_016C:\n\t;\n\tv921 = Morpeh.IEntity::GetComponent(*([v917 @ X0_v26+8]));\n\t*([v921 @ X0_v28 (GBG.Pinata.ECS.Components.EnemyHolderComponent&)])(v867, v506, v921, v319, v43, v44, v45, v46, v47, v760, v211, v132, v120, v117, v114, v53, v54);\n\tv975 = UnityEngine.Transform::get_localPosition(*([v867 @ X0_v30]));\n\tv732 = v975.y <= *([v867 @ X0_v30+10]);\n\tif (v732) goto L_01B9;\n\tv997 = UnityEngine.Transform::get_localPosition(*([v867 @ X0_v30]));\n\tv1005 = *([v867 @ X0_v30+8]) * deltaTime;\n\tv1010 = 0x1586898(&v262 @ stack_-D0_v4 (System.Single), 0, v319, v43, v44, v45, v46, v47, 0, v1005, 0, v120, v117, v114, v53, v54);\n\tgoto L_01AE;\n\tv1024 = *([v1018 @ X0_v47+E0]);\n\tv1025 = v1024 == 0;\n\tv1026 = ~v1025;\n\tif (v1026) goto L_01AE;\n\tv1028 = \"il2cpp_codegen_runtime_class_init\"(v1018, v1009, v754, v43, v44, v45, v46, v47, v1007, v1005, v1008, v120, v117, v114, v53, v54);\nL_01AE:\n\t// 430 MakeStruct v720 @ AGGCC72F4_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v67 @ X8_v6], [v691 @ X0_v15 (Morpeh.Filter+EntityEnumerator)+4], 0\n\tv760 = UnityEngine.Vector3::op_Subtraction(v997, v720);\n\tv132 = v760.z;\n\tUnityEngine.Transform::set_localPosition(*([v867 @ X0_v30]), v760);\n\tgoto L_013B;\nL_01B9:\n\tv1000 = UnityEngine.Transform::get_localPosition(*([v867 @ X0_v30]));\n\tv132 = v1000.z;\n\tv1017 = 0x1586898(&v718 @ stack_-B0_v7, 0, v319, v43, v44, v45, v46, v47, v1000, *([v867 @ X0_v30+10]), v1000.z, v120, v117, v114, v53, v54);\n\t// 456 MakeStruct v715 @ AGGCC733C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v718 @ stack_-B0_v7, v1000.y (System.Single), v1000.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(*([v867 @ X0_v30]), v715);\n\tv780 = Il2CppMethodInfo;\n\tv1033 = *([v506 @ stack_-88]);\n\tv319 = *([v780 @ X20_v12 (Il2CppMethodInfo)+48]);\n\tv774 = *([v1033 @ X8_v15+126]) == 0;\n\tif (v774) goto L_01ED;\n\tv1076 = *([v1033 @ X8_v15+B0]) + 8;\nL_01D4:\n\t;\n\tv1081 = *([v1076 @ X11_v13-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v1081) goto L_01EF;\n\tv1075 = v1075 + 1;\n\tv1086 = v1075 < *([v1033 @ X8_v15+126]);\n\tv1058 = ~v1086;\n\tv1076 = v1076 + 0x10;\n\tv1042 = ~v1058;\n\tif (v1042) goto L_01D4;\nL_01ED:\n\tv1093 = 0x8909C4(v506, Il2CppClass<Morpeh.IEntity>, v319, v43, v44, v45, v46, v47, v718, v1000.y, v132, v120, v1\n// ... truncated")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_000d: Expected O, but got F4
			//IL_0024: Expected F4, but got O
			//IL_0034: Expected O, but got I
			//IL_003c: Expected F4, but got O
			//IL_0894: Expected O, but got I
			//IL_008d: Expected O, but got I
			//IL_04cc: Expected O, but got I
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			//IL_0134: Expected O, but got I
			//IL_0143: Expected O, but got I
			//IL_097c: Expected O, but got I
			//IL_0508: Expected O, but got I
			//IL_00d9: Expected O, but got I
			//IL_02f9: Expected O, but got I
			//IL_0586: Unknown result type (might be due to invalid IL or missing references)
			//IL_058b: Expected O, but got Unknown
			//IL_05a8: Expected O, but got I
			//IL_05b7: Expected O, but got I
			//IL_06fb: Expected F4, but got O
			//IL_074b: Expected O, but got I
			//IL_0554: Expected O, but got I
			//IL_092c: Expected O, but got I
			//IL_0335: Expected O, but got I
			//IL_01ca: Expected F4, but got O
			//IL_01df: Expected F4, but got I
			//IL_0243: Expected O, but got I
			//IL_024b: Expected F4, but got O
			//IL_025b: Expected O, but got I
			//IL_09fc: Expected O, but got I
			//IL_0a1f: Expected O, but got F4
			//IL_0787: Expected O, but got I
			//IL_063e: Expected F4, but got O
			//IL_0653: Expected F4, but got I
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b8: Expected O, but got Unknown
			//IL_03d5: Expected O, but got I
			//IL_03e4: Expected O, but got I
			//IL_06aa: Expected O, but got I
			//IL_06b2: Expected F4, but got O
			//IL_06bf: Expected O, but got F4
			//IL_0381: Expected O, but got I
			//IL_0805: Unknown result type (might be due to invalid IL or missing references)
			//IL_080a: Expected O, but got Unknown
			//IL_0827: Expected O, but got I
			//IL_0836: Expected O, but got I
			//IL_07d3: Expected O, but got I
			float num = default(float);
			object obj = num;
			Filter.EntityEnumerator enumerator = filterUp.GetEnumerator();
			num = (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v6+10]");
			Vector3 vector = (Vector3)0;
			float num2 = (float)obj;
			object obj2 = default(object);
			object obj4 = default(object);
			object obj10 = default(object);
			Vector3 vector2 = default(Vector3);
			Vector3 localPosition3 = default(Vector3);
			Vector3 vector3 = default(Vector3);
			object obj18 = default(object);
			object obj19 = default(object);
			object obj25 = default(object);
			Vector3 vector4 = default(Vector3);
			Vector3 localPosition6 = default(Vector3);
			object obj26 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
				{
					IntPtr intPtr = (IntPtr)0;
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ X8_v24+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00f2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ X8_v24+B0]");
					object obj5 = 0L + 8L;
					int num3 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ X11_v31-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ X8_v24+126]");
						bool flag = (long)num4 < 0L;
						bool flag2 = !flag;
						obj5 = (long)(IntPtr)obj5 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00f2;
					}
					object obj6 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ X21_v11 (Il2CppMethodInfo)+48]");
					object obj7 = obj6 + 0;
					int num5 = (int)((long)(IntPtr)obj7 << 4);
					object obj8 = (long)(IntPtr)obj3 + (long)num5;
					object obj9 = (long)(IntPtr)obj8 + 304L;
					goto IL_0882;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				goto IL_0472;
				IL_0882:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ X0_v68+8]");
				ref EnemyHolderComponent component = ref ((IEntity)0).GetComponent<EnemyHolderComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v703 @ X0_v70 (GBG.Pinata.ECS.Components.EnemyHolderComponent&)] (should have been resolved before IL gen)");
				if (obj10 != null)
				{
					float num6 = ((Transform)obj10).localPosition.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ X0_v72+C]");
					float z;
					object obj12;
					if (num6 < 0f)
					{
						Vector3 localPosition = ((Transform)obj10).localPosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ X0_v72+8]");
						float num7 = 0f * deltaTime;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
						vector2.x = (float)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v6+4]");
						vector2.y = 0f;
						vector2.z = 0f;
						vector = localPosition + vector2;
						num2 = vector.y;
						z = vector.z;
						((Transform)obj10).localPosition = vector;
						int num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v6+4]");
						object obj11 = 0;
						float num9 = (float)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ X21_v11 (Il2CppMethodInfo)+48]");
						obj12 = 0;
						continue;
					}
					Vector3 localPosition2 = ((Transform)obj10).localPosition;
					num2 = localPosition2.y;
					z = localPosition2.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					localPosition3.x = vector3.x;
					localPosition3.y = localPosition2.y;
					localPosition3.z = localPosition2.z;
					((Transform)obj10).localPosition = localPosition3;
					IntPtr intPtr2 = (IntPtr)0;
					object obj13 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ X21_v13 (Il2CppMethodInfo)+48]");
					obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ X8_v27+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_039a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ X8_v27+B0]");
					object obj14 = 0L + 8L;
					int num10 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ X11_v26-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num10++;
						int num11 = num10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ X8_v27+126]");
						bool flag3 = (long)num11 < 0L;
						bool flag4 = !flag3;
						obj14 = (long)(IntPtr)obj14 + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_039a;
					}
					object obj15 = obj14 + (long)(IntPtr)obj12;
					int num12 = (int)((long)(IntPtr)obj15 << 4);
					object obj16 = (long)(IntPtr)obj13 + (long)num12;
					object obj17 = (long)(IntPtr)obj16 + 304L;
					goto IL_091a;
				}
				NullReferenceException ex = new NullReferenceException();
				if (0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
					if (obj18 == null)
					{
						goto IL_0472;
					}
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				break;
				IL_039a:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_091a;
				IL_091a:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v983 @ X0_v78+8]");
				bool flag5 = ((IEntity)0).RemoveComponent<EnemyMoveUpMarker>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v987.m_value (System.Boolean) (should have been resolved before IL gen)");
				vector = vector3;
				continue;
				IL_0472:
				Filter.EntityEnumerator enumerator2 = filterDown.GetEnumerator();
				World world = enumerator2.world;
				Vector3 ids = (Vector3)enumerator2.ids;
				World world2 = enumerator2.world;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj19 & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr3 = (IntPtr)0;
					object obj20 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ X20_v10 (Il2CppMethodInfo)+48]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ X8_v12+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_056d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ X8_v12+B0]");
					object obj21 = 0L + 8L;
					int num13 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ X11_v18-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num13++;
						int num14 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ X8_v12+126]");
						bool flag6 = (long)num14 < 0L;
						bool flag7 = !flag6;
						obj21 = (long)(IntPtr)obj21 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_056d;
					}
					object obj22 = obj21 + (long)(IntPtr)obj12;
					int num15 = (int)((long)(IntPtr)obj22 << 4);
					object obj23 = (long)(IntPtr)obj20 + (long)num15;
					object obj24 = (long)(IntPtr)obj23 + 304L;
					goto IL_096a;
					IL_056d:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_096a;
					IL_096a:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ X0_v26+8]");
					ref EnemyHolderComponent component2 = ref ((IEntity)0).GetComponent<EnemyHolderComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v921 @ X0_v28 (GBG.Pinata.ECS.Components.EnemyHolderComponent&)] (should have been resolved before IL gen)");
					float num16 = ((Transform)obj25).localPosition.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X0_v30+10]");
					float z;
					if (num16 > 0f)
					{
						Vector3 localPosition4 = ((Transform)obj25).localPosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X0_v30+8]");
						float num17 = 0f * deltaTime;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
						vector4.x = (float)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ X0_v15 (Morpeh.Filter+EntityEnumerator)+4]");
						vector4.y = 0f;
						vector4.z = 0f;
						ids = localPosition4 - vector4;
						z = ids.z;
						((Transform)obj25).localPosition = ids;
						int num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v691 @ X0_v15 (Morpeh.Filter+EntityEnumerator)+4]");
						object obj11 = 0;
						float num9 = (float)obj;
						world2 = (World)ids.y;
						continue;
					}
					Vector3 localPosition5 = ((Transform)obj25).localPosition;
					z = localPosition5.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					localPosition6.x = (float)obj26;
					localPosition6.y = localPosition5.y;
					localPosition6.z = localPosition5.z;
					((Transform)obj25).localPosition = localPosition6;
					IntPtr intPtr4 = (IntPtr)0;
					object obj27 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X20_v12 (Il2CppMethodInfo)+48]");
					obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1033 @ X8_v15+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_07ec;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1033 @ X8_v15+B0]");
					object obj28 = 0L + 8L;
					int num18 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ X11_v13-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num18++;
						int num19 = num18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1033 @ X8_v15+126]");
						bool flag8 = (long)num19 < 0L;
						bool flag9 = !flag8;
						obj28 = (long)(IntPtr)obj28 + 16L;
						if (!flag9)
						{
							continue;
						}
						goto IL_07ec;
					}
					object obj29 = obj28 + (long)(IntPtr)obj12;
					int num20 = (int)((long)(IntPtr)obj29 << 4);
					object obj30 = (long)(IntPtr)obj27 + (long)num20;
					object obj31 = (long)(IntPtr)obj30 + 304L;
					goto IL_09ea;
					IL_09ea:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ X0_v36+8]");
					bool flag10 = ((IEntity)0).RemoveComponent<EnemyMoveDownMarker>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1097.m_value (System.Boolean) (should have been resolved before IL gen)");
					ids = (Vector3)obj26;
					world2 = (World)localPosition5.y;
					continue;
					IL_07ec:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_09ea;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
				IL_00f2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0882;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0xCC7474", Offset = "0xCC7474", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ShowHideEnemySystem()
		{
		}
	}
}
