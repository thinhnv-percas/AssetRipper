using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Hypercasual
{
	[CreateAssetMenu]
	[Token(Token = "0x2000006")]
	public class SaveSystem : LateUpdateSystem
	{
		[Serializable]
		[StructLayout((LayoutKind)0, Size = 16)]
		[Token(Token = "0x2000015")]
		private struct Data
		{
			[Token(Token = "0x400003A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public SaveIntComponent[] Integers;

			[Token(Token = "0x400003B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public SaveStringComponent[] Strings;
		}

		[Token(Token = "0x2000016")]
		private class FocusCallback : MonoBehaviour
		{
			[Token(Token = "0x400003C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			internal SaveSystem system;

			[Token(Token = "0x6000024")]
			[Address(RVA = "0x1633E40", Offset = "0x1633E40", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = hasFocus == 0;\n\tif (v2) goto L_0007;\n\treturn;\nL_0007:\n\tMorpeh.Hypercasual.SaveSystem::LostFocus(this.system);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void OnApplicationFocus(bool hasFocus)
			{
				if (!hasFocus)
				{
					system.LostFocus();
				}
			}

			[Token(Token = "0x6000025")]
			[Address(RVA = "0x1633E60", Offset = "0x1633E60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public FocusCallback()
			{
			}
		}

		[Token(Token = "0x4000018")]
		private const string KEY = "MORPEH__SAVED_DATA";

		[Token(Token = "0x4000019")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private GameObject tempGO;

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x163384C", Offset = "0x163384C", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EE7B00]);\n\tv33 = *([v32 @ X8_v37]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202A4DD]) = v52;\nL_001E:\n\tv57 = UnityEngine.PlayerPrefs::HasKey(\"MORPEH__SAVED_DATA\");\n\tv59 = v57 == 0;\n\tif (v59) goto L_0100;\n\tv62 = UnityEngine.PlayerPrefs::GetString(\"MORPEH__SAVED_DATA\");\n\tv163 = UnityEngine.JsonUtility::FromJson(v62);\n\tv182 = *([v163 @ X0_v24 (Morpeh.Hypercasual.SaveSystem+Data)+18]) < 1;\n\tif (v182) goto L_00A1;\nL_0042:\n\tv255 = Morpeh.World::CreateEntity(this.world);\n\tv453 = v215 < *([v163 @ X0_v24 (Morpeh.Hypercasual.SaveSystem+Data)+18]);\n\tv379 = ~v453;\n\tif (v379) goto L_0134;\n\tv348 = Il2CppMethodInfo;\n\tv454 = *([v255 @ X0_v39 (Morpeh.IEntity)]);\n\tv455 = v215 << 4;\n\tv456 = v163 + v455;\n\tv345 = v456 + 0x20;\n\tv362 = *([v454 @ X8_v31 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v362) goto L_0077;\n\tv491 = *([v454 @ X8_v31 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0063:\n\tv506 = *([v491 @ X11_v18-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v506) goto L_007A;\n\tv492 = v492 + 1;\n\tv517 = v492 < *([v454 @ X8_v31 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv486 = ~v517;\n\tv491 = v491 + 0x10;\n\tv470 = ~v486;\n\tif (v470) goto L_0063;\nL_0077:\n\tv533 = 0x8909C4(v255, Il2CppClass<Morpeh.IEntity>, *([v348 @ X23_v10 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0080;\nL_007A:\n\tv519 = *([v491 @ X11_v18]) + *([v348 @ X23_v10 (Il2CppMethodInfo)+48]);\n\tv520 = v519 << 4;\n\tv521 = v454 + v520;\n\tv533 = v521 + 0x130;\nL_0080:\n\tv537 = 0x8D8294(*([v533 @ X0_v40+8]), Il2CppMethodInfo, *([v348 @ X23_v10 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t*([v537 @ X0_v42])(v360, v255, v345, v537, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv215 = v215 + 1;\n\tv350 = v215 < *([v163 @ X0_v24 (Morpeh.Hypercasual.SaveSystem+Data)+18]);\n\tif (v350) goto L_0042;\nL_00A1:\n\tv106 = Il2CppClass<UnityEngine.JsonUtility> < 1;\n\tif (v106) goto L_0100;\nL_00AB:\n\tv257 = Morpeh.World::CreateEntity(this.world);\n\tv489 = v198 < Il2CppClass<UnityEngine.JsonUtility>;\n\tv380 = ~v489;\n\tif (v380) goto L_0134;\n\tv93 = Il2CppMethodInfo;\n\tv511 = *([v257 @ X0_v28 (Morpeh.IEntity)]);\n\tv512 = v198 << 4;\n\tv513 = Il2CppMethodInfo + v512;\n\tv90 = v513 + 0x20;\n\tv149 = *([v511 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v149) goto L_00E0;\n\tv571 = *([v511 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_00CC:\n\tv586 = *([v571 @ X11_v11-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v586) goto L_00E3;\n\tv572 = v572 + 1;\n\tv591 = v572 < *([v511 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv564 = ~v591;\n\tv571 = v571 + 0x10;\n\tv548 = ~v564;\n\tif (v548) goto L_00CC;\nL_00E0:\n\tv607 = 0x8909C4(v257, Il2CppClass<Morpeh.IEntity>, *([v93 @ X22_v8 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00E9;\nL_00E3:\n\tv593 = *([v571 @ X11_v11]) + *([v93 @ X22_v8 (Il2CppMethodInfo)+48]);\n\tv594 = v593 << 4;\n\tv595 = v511 + v594;\n\tv607 = v595 + 0x130;\nL_00E9:\n\tv611 = 0x8D8294(*([v607 @ X0_v29+8]), Il2CppMethodInfo, *([v93 @ X22_v8 (Il2CppMethodInfo)+48]), v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t*([v611 @ X0_v31])(v146, v257, v90, v611, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv198 = v198 + 1;\n\tv104 = v198 < Il2CppClass<UnityEngine.JsonUtility>;\n\tif (v104) goto L_00AB;\nL_0100:\n\tv159 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v159, \"MORPEH__SAVE_CALLBACK\");\n\tUnityEngine.Object::set_hideFlags(v159, 0x3D);\n\tthis.tempGO = v159;\n\tv258 = UnityEngine.GameObject::AddComponent(v159);\n\tv258.system = this;\n\tgoto L_0131;\n\tv448 = *([v442 @ X0_v18+E0]);\n\tv449 = v448 == 0;\n\tv450 = ~v449;\n\tif (v450) goto L_0131;\n\tv452 = \"il2cpp_codegen_runtime_class_init\"(v442, v252, v192, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0131:\n\tUnityEngine.Object::DontDestroyOnLoad(this.tempGO);\n\treturn;\n\tv270 = new System.NullReferenceException();\nL_0134:\n\tv385 = new System.IndexOutOfRangeException();\n\tthrow v385;\n\tthrow System.NullReferenceException;\n// 220 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			//IL_00a9: Expected I, but got O
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00d3: Expected O, but got I
			//IL_0238: Expected I, but got O
			//IL_0251: Expected O, but got I
			//IL_0260: Expected O, but got I
			//IL_010e: Expected O, but got I
			//IL_029b: Expected O, but got I
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Expected O, but got Unknown
			//IL_01b4: Expected O, but got I
			//IL_01c3: Expected O, but got I
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Expected O, but got Unknown
			//IL_0341: Expected O, but got I
			//IL_0350: Expected O, but got I
			//IL_015a: Expected O, but got I
			//IL_02e7: Expected O, but got I
			if (!PlayerPrefs.HasKey("MORPEH__SAVED_DATA"))
			{
				goto IL_0355;
			}
			string json = PlayerPrefs.GetString("MORPEH__SAVED_DATA");
			Data data = JsonUtility.FromJson<Data>(json);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v24 (Morpeh.Hypercasual.SaveSystem+Data)+18]");
			if (0L < 1L)
			{
				goto IL_01c8;
			}
			int num = 0;
			while (true)
			{
				IEntity entity = World.CreateEntity();
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v24 (Morpeh.Hypercasual.SaveSystem+Data)+18]");
				if ((long)num2 >= 0L)
				{
					break;
				}
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)entity;
				int num3 = num << 4;
				object obj = data + num3;
				object obj2 = (long)(IntPtr)obj + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X8_v31 (Il2CppClass<Morpeh.IEntity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0173;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X8_v31 (Il2CppClass<Morpeh.IEntity>)+B0]");
				object obj3 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ X11_v18-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X8_v31 (Il2CppClass<Morpeh.IEntity>)+126]");
					bool flag = (long)num5 < 0L;
					bool flag2 = !flag;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_0173;
				}
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ X23_v10 (Il2CppMethodInfo)+48]");
				object obj5 = obj4 + 0;
				int num6 = (int)((long)(IntPtr)obj5 << 4);
				object obj6 = (long)intPtr2 + (long)num6;
				object obj7 = (long)(IntPtr)obj6 + 304L;
				goto IL_0409;
				IL_0173:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0409;
				IL_0409:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v537 @ X0_v42] (should have been resolved before IL gen)");
				num++;
				int num7 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v24 (Morpeh.Hypercasual.SaveSystem+Data)+18]");
				if ((long)num7 < 0L)
				{
					continue;
				}
				goto IL_01c8;
			}
			goto IL_03ae;
			IL_03ae:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0355:
			GameObject gameObject = new GameObject("MORPEH__SAVE_CALLBACK");
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			tempGO = gameObject;
			FocusCallback focusCallback = gameObject.AddComponent<FocusCallback>();
			focusCallback.system = this;
			UnityEngine.Object.DontDestroyOnLoad(tempGO);
			return;
			IL_01c8:
			if (0L < 1L)
			{
				goto IL_0355;
			}
			int num8 = 0;
			while (true)
			{
				IEntity entity2 = World.CreateEntity();
				if ((long)num8 >= 0L)
				{
					break;
				}
				IntPtr intPtr3 = (IntPtr)0;
				IntPtr intPtr4 = (IntPtr)entity2;
				int num9 = num8 << 4;
				object obj8 = 0L + (long)num9;
				object obj9 = (long)(IntPtr)obj8 + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0300;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+B0]");
				object obj10 = 0L + 8L;
				int num10 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ X11_v11-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num10++;
					int num11 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]");
					bool flag3 = (long)num11 < 0L;
					bool flag4 = !flag3;
					obj10 = (long)(IntPtr)obj10 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0300;
				}
				object obj11 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X22_v8 (Il2CppMethodInfo)+48]");
				object obj12 = obj11 + 0;
				int num12 = (int)((long)(IntPtr)obj12 << 4);
				object obj13 = (long)intPtr4 + (long)num12;
				object obj14 = (long)(IntPtr)obj13 + 304L;
				goto IL_0471;
				IL_0300:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0471;
				IL_0471:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v611 @ X0_v31] (should have been resolved before IL gen)");
				num8++;
				if ((long)num8 < 0L)
				{
					continue;
				}
				goto IL_0355;
			}
			goto IL_03ae;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x1633B3C", Offset = "0x1633B3C", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EF6F00]);\n\tv31 = *([v30 @ X8_v36]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202A4DE]) = v50;\nL_001D:\n\tv54 = Morpeh.FilterProvider::get_All(this.filter);\n\tv135 = Morpeh.Filter::With(v54, 1);\n\tv119 = Morpeh.FilterProvider::get_All(this.filter);\n\tv265 = Morpeh.Filter::With(v119, 1);\n\tv285 = Morpeh.Filter::Select(v135);\n\tv290 = Morpeh.Filter::Select(v135);\n\t// 72 NewArr this @ X0 (Morpeh.Hypercasual.SaveIntComponent[]), typeof(Morpeh.Hypercasual.SaveIntComponent[]), v135.Length (System.Int32)\n\t// 80 NewArr this @ X0 (Morpeh.Hypercasual.SaveIntComponent[]), typeof(Morpeh.Hypercasual.SaveStringComponent[]), v265.Length (System.Int32)\n\tv225 = v135.Length < 1;\n\tif (v225) goto L_008C;\n\tv302 = *([v285 @ X0_v14 (ComponentsBag`1<Morpeh.Hypercasual.SaveIntComponent>&)+8]) + 0x20;\n\tv301 = this + 0x20;\nL_0065:\n\tv363 = v352 < this.Length;\n\tv364 = ~v363;\n\tif (v364) goto L_00F2;\n\tv299 = *([v302 @ X10_v7+v352 @ X9_v13 (System.Int32)*4]) << 4;\n\tv300 = *([v285 @ X0_v14 (ComponentsBag`1<Morpeh.Hypercasual.SaveIntComponent>&)]) + v299;\n\t*([v301 @ X11_v7+v352 @ X9_v13 (System.Int32)*16]) = *([v300 @ X12_v13+20]);\n\tv352 = v352 + 1;\n\tv305 = v352 < v135.Length;\n\tif (v305) goto L_0065;\nL_008C:\n\tv226 = v265.Length < 1;\n\tif (v226) goto L_00B1;\n\tv330 = *([v290 @ X0_v16 (ComponentsBag`1<Morpeh.Hypercasual.SaveStringComponent>&)+8]) + 0x20;\n\tv329 = this + 0x20;\nL_0094:\n\tv404 = v384 < this.Length;\n\tv393 = ~v404;\n\tif (v393) goto L_00F2;\n\tv327 = *([v330 @ X10_v6+v384 @ X9_v10 (System.Int32)*4]) << 4;\n\tv328 = *([v290 @ X0_v16 (ComponentsBag`1<Morpeh.Hypercasual.SaveStringComponent>&)]) + v327;\n\t*([v329 @ X11_v6+v384 @ X9_v10 (System.Int32)*16]) = *([v328 @ X12_v9+20]);\n\tv384 = v384 + 1;\n\tv333 = v384 < v265.Length;\n\tif (v333) goto L_0094;\nL_00B1:\n\tv344 = v135.Length;\n\t// 182 Box v348 @ X0_v24 (System.Object), typeof(System.Int32), &v344 @ X8_v21 (System.Int32)\n\tv374 = v265.Length;\n\t// 188 Box v377 @ X0_v26 (System.Object), typeof(System.Int32), &v374 @ X8_v22 (System.Int32)\n\tv411 = System.String::Format(\"SAVED INTS {0} STRINGS {1}\", v348, v377);\n\tgoto L_00D5;\n\tv422 = *([v418 @ X8_v28+E0]);\n\tv423 = v422 == 0;\n\tv424 = ~v423;\n\tif (v424) goto L_00D5;\n\tv429 = v418;\n\tv426 = \"il2cpp_codegen_runtime_class_init\"(v429, v408, v407, v145, v36, v37, v38, v39, v153, v41, v42, v43, v44, v45, v46, v47);\nL_00D5:\n\tUnityEngine.Debug::Log(v411);\n\t// 220 Box v434 @ X0_v32 (System.Object), typeof(Morpeh.Hypercasual.SaveSystem+Data), &this @ X0 (Morpeh.Hypercasual.SaveIntComponent[])\n\tv436 = UnityEngine.JsonUtility::ToJson(v434);\n\tUnityEngine.PlayerPrefs::SetString(\"MORPEH__SAVED_DATA\", v436);\n\treturn;\nL_00F2:\n\tv394 = new System.IndexOutOfRangeException();\n\tthrow v394;\n\tv118 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LostFocus()
		{
			//IL_00db: Expected O, but got I
			//IL_00e7: Expected O, but got I
			//IL_0191: Expected O, but got I
			//IL_019d: Expected O, but got I
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Expected O, but got Unknown
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Expected O, but got Unknown
			Filter all = Filter.All;
			Filter filter = all.With<SaveIntComponent>();
			Filter all2 = Filter.All;
			Filter filter2 = all2.With<SaveStringComponent>();
			ref Filter.ComponentsBag<SaveIntComponent> reference = ref filter.Select<SaveIntComponent>();
			ref Filter.ComponentsBag<SaveStringComponent> reference2 = ref filter.Select<SaveStringComponent>();
			SaveIntComponent[] array = new SaveIntComponent[filter.Length];
			array = (SaveIntComponent[])(object)new SaveStringComponent[filter2.Length];
			if (filter.Length < 1)
			{
				goto IL_0159;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X0_v14 (ComponentsBag`1<Morpeh.Hypercasual.SaveIntComponent>&)+8]");
			object obj = 0L + 32L;
			object obj2 = (long)(IntPtr)this + 32L;
			int num = 0;
			while (num < ((Array)(object)this).Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ X10_v7+v352 @ X9_v13 (System.Int32)*4]");
				int num2 = 0;
				object obj3 = reference + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ X12_v13+20]");
				_ = 0;
				num++;
				if (num < filter.Length)
				{
					continue;
				}
				goto IL_0159;
			}
			goto IL_029c;
			IL_0159:
			if (filter2.Length < 1)
			{
				goto IL_020f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ X0_v16 (ComponentsBag`1<Morpeh.Hypercasual.SaveStringComponent>&)+8]");
			object obj4 = 0L + 32L;
			object obj5 = (long)(IntPtr)this + 32L;
			int num3 = 0;
			while (num3 < ((Array)(object)this).Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X10_v6+v384 @ X9_v10 (System.Int32)*4]");
				int num4 = 0;
				object obj6 = reference2 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X12_v9+20]");
				_ = 0;
				num3++;
				if (num3 < filter2.Length)
				{
					continue;
				}
				goto IL_020f;
			}
			goto IL_029c;
			IL_029c:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_020f:
			int length = filter.Length;
			object arg = length;
			int length2 = filter2.Length;
			object arg2 = length2;
			string message = $"SAVED INTS {arg} STRINGS {arg2}";
			Debug.Log(message);
			object obj7 = (Data)this;
			string value = JsonUtility.ToJson(obj7);
			PlayerPrefs.SetString("MORPEH__SAVED_DATA", value);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x1633DC8", Offset = "0x1633DC8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate(float deltaTime)
		{
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1633DCC", Offset = "0x1633DCC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC0CF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A4DF]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Object::DestroyImmediate(this.tempGO);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Dispose()
		{
			UnityEngine.Object.DestroyImmediate(tempGO);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x1633E38", Offset = "0x1633E38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.LateUpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SaveSystem()
		{
		}
	}
}
