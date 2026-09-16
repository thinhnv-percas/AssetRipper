using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Collections;

namespace Spine.Unity.AttachmentTools
{
	[Token(Token = "0x20000CB")]
	public static class SkinUtilities
	{
		[Token(Token = "0x6000739")]
		[Address(RVA = "0x1577CCC", Offset = "0x1577CCC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = \"cloned skin\";\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, includeDefaultSkin, unshareAttachments, state, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A37D23]) = v46;\nL_001E:\n\tv52 = Spine.Unity.AttachmentTools.SkinUtilities::GetClonedSkin(skeleton, \"cloned skin\", includeDefaultSkin, unshareAttachments, 1);\n\tSpine.Skeleton::SetSkin(skeleton, v52);\n\tv59 = state == 0;\n\tif (v59) goto L_0038;\n\tSpine.Skeleton::SetToSetupPose(skeleton);\n\tv67 = Spine.AnimationState::Apply(state, skeleton);\nL_0038:\n\treturn v52;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Skin UnshareSkin(this Skeleton skeleton, bool includeDefaultSkin, bool unshareAttachments, AnimationState state = null)
		{
			Skin clonedSkin = skeleton.GetClonedSkin("cloned skin", includeDefaultSkin, unshareAttachments);
			skeleton.SetSkin(clonedSkin);
			if (state != null)
			{
				skeleton.SetToSetupPose();
				bool flag = state.Apply(skeleton);
			}
			return clonedSkin;
		}

		[Token(Token = "0x600073A")]
		[Address(RVA = "0x1577D80", Offset = "0x1577D80", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = Spine.Skin;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, newSkinName, includeDefaultSkin, cloneAttachments, cloneMeshesAsLinked, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A37D24]) = v49;\nL_001C:\n\tv51 = new Spine.Skin();\n\tSpine.Skin::.ctor(v51, newSkinName);\n\tv56 = skeleton.data;\n\tv63 = includeDefaultSkin == 0;\n\tif (v63) goto L_0030;\n\tSpine.Unity.AttachmentTools.SkinUtilities::CopyTo(v56.defaultSkin, v51, 1, cloneAttachments, cloneMeshesAsLinked);\nL_0030:\n\tv74 = skeleton.skin == 0;\n\tif (v74) goto L_0042;\n\tSpine.Unity.AttachmentTools.SkinUtilities::CopyTo(skeleton.skin, v51, 1, cloneAttachments, cloneMeshesAsLinked);\nL_0042:\n\treturn v51;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Skin GetClonedSkin(this Skeleton skeleton, string newSkinName, bool includeDefaultSkin = false, bool cloneAttachments = false, bool cloneMeshesAsLinked = true)
		{
			Skin skin = new Skin(newSkinName);
			SkeletonData data = skeleton.Data;
			if (includeDefaultSkin)
			{
				data.DefaultSkin.CopyTo(skin, overwrite: true, cloneAttachments, cloneMeshesAsLinked);
			}
			if (skeleton.Skin != null)
			{
				skeleton.Skin.CopyTo(skin, overwrite: true, cloneAttachments, cloneMeshesAsLinked);
			}
			return skin;
		}

		[Token(Token = "0x600073B")]
		[Address(RVA = "0x1578C94", Offset = "0x1578C94", Length = "0x3B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv205 = System.IDisposable;\n\tv206 = \"il2cpp_codegen_initialize_runtime_metadata\"(v205, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv250 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<Spine.Skin+SkinEntry, Spine.Attachment>>;\n\tv251 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv292 = System.Collections.IEnumerator;\n\tv293 = \"il2cpp_codegen_initialize_runtime_metadata\"(v292, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv295 = Il2CppMethodInfo;\n\tv296 = \"il2cpp_codegen_initialize_runtime_metadata\"(v295, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv308 = Il2CppMethodInfo;\n\tv309 = \"il2cpp_codegen_initialize_runtime_metadata\"(v308, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv316 = Il2CppMethodInfo;\n\tv317 = \"il2cpp_codegen_initialize_runtime_metadata\"(v316, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv322 = Il2CppMethodInfo;\n\tv323 = \"il2cpp_codegen_initialize_runtime_metadata\"(v322, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv369 = Spine.Skin;\n\tv370 = \"il2cpp_codegen_initialize_runtime_metadata\"(v369, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv480 = \" clone\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v480, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37D25]) = v50;\nL_003F:\n\tv62 = System.String::Concat(original.name, \" clone\");\n\tv184 = new Spine.Skin();\n\tSpine.Skin::.ctor(v184, v62);\n\tv162 = v184.bones;\n\tv159 = v184.constraints;\n\tv242 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::GetEnumerator(original.attachments);\nL_0063:\n\tgoto L_0089;\n\tv481 = *([v403 @ X8_v27+B0]);\n\tv482 = v481 + 8;\n\tv484 = *([v566 @ X10_v30-8]);\n\tv571 = v484 == v404;\n\tif (v571) goto L_0082;\n\tv488 = v557 - 1;\n\tv506 = v566 + 0x10;\n\tv486 = v557 != 1;\n\tif (v486) goto L_FFFFFFFF;\n\tv507 = v200;\n\tv508 = 0;\n\tv509 = 0xB349B4(v507, v404, v508, v92, v35, v36, v37, v38, v382, v380, v41, v42, v43, v44, v45, v46);\n\tgoto L_0089;\nL_0082:\n\tv614 = *([v566 @ X10_v30]);\n\tv615 = v614 << 4;\n\tv616 = v403 + v615;\n\tv617 = v616 + 0x138;\nL_0089:\n\tv439 = System.Collections.IEnumerator::MoveNext(v242);\n\tv441 = v439 == 0;\n\tif (v441) goto L_FFFFFFFF;\n\tgoto L_00B8;\n\tv709 = *([v697 @ X8_v30+B0]);\n\tv710 = v709 + 8;\n\tv712 = *([v751 @ X10_v25-8]);\n\tv756 = v712 == v698;\n\tif (v756) goto L_00B0;\n\tv716 = v742 - 1;\n\tv734 = v751 + 0x10;\n\tv714 = v742 != 1;\n\tif (v714) goto L_FFFFFFFF;\n\tv735 = v200;\n\tv736 = 0;\n\tv737 = 0xB349B4(v735, v698, v736, v92, v35, v36, v37, v38, v382, v380, v41, v42, v43, v44, v45, v46);\n\tgoto L_00B8;\nL_00B0:\n\tv762 = *([v751 @ X10_v25]);\n\tv763 = v762 << 4;\n\tv764 = v697 + v763;\n\tv765 = v764 + 0x138;\nL_00B8:\n\tv771 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<Spine.Skin+SkinEntry, Spine.Attachment>>::get_Current(v242);\n\tSpine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(v184.attachments, &v378 @ stack_-B0_v8, v772);\n\tgoto L_0063;\nL_00CC:\n\tv444 = v202 == 0;\n\tif (v444) goto L_00F9;\n\tv510 = *([v202 @ X20_v2 (System.Collections.IEnumerator)]);\n\tv624 = *([v510 @ X8_v9 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv513 = *([v510 @ X8_v9 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v513) goto L_00EF;\n\tv633 = *([v510 @ X8_v9 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00DA:\n\tv638 = *([v633 @ X10_v7-8]) == *([v168 @ X25_v1 (Il2CppClass<System.IDisposable>)]);\n\tif (v638) goto L_00F2;\n\tv583 = v624 - 1;\n\tv633 = v633 + 0x10;\n\tv581 = v624 != 1;\n\tif (v581) goto L_00DA;\nL_00EF:\n\tv706 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(v202, *([v168 @ X25_v1 (Il2CppClass<System.IDisposable>)]), 0);\n\tgoto L_00F8;\nL_00F2:\n\tv703 = *([v633 @ X10_v7]) << 4;\n\tv704 = v510 + v703;\n\tv706 = v704 + 0x138;\nL_00F8:\n\t*([v706 @ X0_v7])(v529, v202, *([v706 @ X0_v7+8]), v180, v93, v35, v36, v37, v38, v99, v96, v41, v42, v43, v44, v45, v46);\nL_00F9:\n\tv532 = v165 == 0;\n\tv286 = ~v532;\n\tif (v286) goto L_011E;\n\tSpine.ExposedList`1<Spine.BoneData>::AddRange(v162, original.bones);\n\tSpine.ExposedList`1<Spine.ConstraintData>::AddRange(v159, original.constraints);\n\treturn v171;\n\tv183 = new System.NullReferenceException();\n\tv203 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_011E:\n\tv290 = new System.OutOfMemoryException();\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\nL_012C:\n\tv306 = v357 != 1;\n\tif (v306) goto L_0134;\n\tv312 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(v290, v357, v359);\n\tv165 = *([v312 @ X0_v29 (Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>)]);\n\tv319 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(v312, v357, v359);\n\tgoto L_00CC;\nL_0134:\n\tgoto L_0136;\n\tX19 = X0;\nL_0136:\n\tv320 = v288 == 0;\n\tif (v320) goto L_0165;\n\tv327 = *([v288 @ X20_v4 (System.Collections.IEnumerator)]);\n\tv535 = *([v327 @ X8_v15 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv330 = *([v327 @ X8_v15 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v330) goto L_0159;\n\tv544 = *([v327 @ X8_v15 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0144:\n\tv549 = *([v544 @ X10_v15-8]) == *([v280 @ X25_v3 (Il2CppClass<System.IDisposable>)]);\n\tif (v549) goto L_015C;\n\tv452 = v535 - 1;\n\tv544 = v544 + 0x10;\n\tv450 = v535 != 1;\n\tif (v450) goto L_0144;\nL_0159:\n\tv610 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(v288, *([v280 @ X25_v3 (Il2CppClass<System.IDisposable>)]), 0);\n\tgoto L_0162;\nL_015C:\n\tv607 = *([v544 @ X10_v15]) << 4;\n\tv608 = v327 + v607;\n\tv610 = v608 + 0x138;\nL_0162:\n\t*([v610 @ X0_v23])(v362, v288, *([v610 @ X0_v23+8]), 0, v259, v35, v36, v37, v38, v261, v260, v41, v42, v43, v44, v45, v46);\nL_0165:\n\tgoto L_0169;\n\tv475 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(v290, *([v610 @ X0_v23+8]), 0);\nL_0169:\n\tv478 = new System.OutOfMemoryException();\n\treturnVal1 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(v478, *([v610 @ X0_v23+8]), 0);\n\treturn returnVal1;\n// 226 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Skin GetClone(this Skin original)
		{
			//IL_00a0: Expected I, but got O
			//IL_00ae: Expected I, but got O
			//IL_00d1: Expected I, but got O
			//IL_00e1: Expected O, but got I
			//IL_0080: Expected O, but got Ref
			//IL_0175: Expected O, but got I
			//IL_011c: Expected O, but got I
			//IL_0224: Expected I, but got O
			//IL_018d: Expected I4, but got O
			//IL_019b: Expected O, but got I
			//IL_01aa: Expected O, but got I
			//IL_03a7: Expected O, but got I
			//IL_0294: Expected I, but got O
			//IL_02a4: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_013f: Expected O, but got I
			//IL_0338: Expected O, but got I
			//IL_02df: Expected O, but got I
			//IL_034b: Expected I4, but got O
			//IL_0359: Expected O, but got I
			//IL_0368: Expected O, but got I
			//IL_02f3: Expected O, but got I
			//IL_0302: Expected O, but got I
			string name = original.Name + " clone";
			Skin skin = new Skin(name);
			ExposedList<BoneData> exposedList = skin.Bones;
			ExposedList<ConstraintData> exposedList2 = skin.Constraints;
			IEnumerator enumerator = original.Attachments.GetEnumerator();
			object obj = default(object);
			Attachment value = default(Attachment);
			object obj3 = default(object);
			while (enumerator.MoveNext())
			{
				KeyValuePair<Skin.SkinEntry, Attachment> current = ((IEnumerator<KeyValuePair<Skin.SkinEntry, Attachment>>)enumerator).Current;
				skin.Attachments[(Skin.SkinEntry)(&obj)] = value;
				nint num = 0;
				object obj2 = obj3;
				object obj4 = obj;
			}
			nint num2 = unchecked((nint)null);
			nint num3 = (nint)typeof(IDisposable);
			Skin result = skin;
			Attachment attachment = null;
			IEnumerator enumerator2 = enumerator;
			Skin.SkinEntry skinEntry = default(Skin.SkinEntry);
			Attachment attachment2 = default(Attachment);
			OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary = default(OrderedDictionary<Skin.SkinEntry, Attachment>);
			IntPtr intPtr = default(IntPtr);
			object obj10 = default(object);
			object obj11 = default(object);
			ExposedList<ConstraintData> exposedList3 = default(ExposedList<ConstraintData>);
			ExposedList<BoneData> exposedList4 = default(ExposedList<BoneData>);
			IntPtr intPtr2 = default(IntPtr);
			Skin skin2 = default(Skin);
			IEnumerator enumerator3 = default(IEnumerator);
			while (true)
			{
				if (enumerator2 == null)
				{
					goto IL_03f2;
				}
				nint num4 = (nint)enumerator2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v9 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v9 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_0167;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v9 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj6 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ X10_v7-8]");
					if (0 == num3)
					{
						break;
					}
					object obj7 = (nint)obj5 - 1;
					obj6 = (nint)obj6 + 16;
					bool flag = (nint)obj5 != 1;
					obj5 = obj7;
					if (flag)
					{
						continue;
					}
					goto IL_0167;
				}
				int num5 = obj6 << 4;
				object obj8 = num4 + num5;
				object obj9 = (nint)obj8 + 312;
				goto IL_043e;
				IL_03f2:
				if (num2 == 0)
				{
					exposedList.AddRange(original.Bones);
					exposedList2.AddRange(original.Constraints);
					return result;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if ((nint)skinEntry == 1)
				{
					((OrderedDictionary<Skin.SkinEntry, Attachment>)(object)ex)[skinEntry] = attachment2;
					num2 = (nint)orderedDictionary;
					orderedDictionary[skinEntry] = attachment2;
					nint num = intPtr;
					object obj2 = obj10;
					object obj4 = obj11;
					exposedList2 = exposedList3;
					exposedList = exposedList4;
					num3 = intPtr2;
					result = skin2;
					attachment = attachment2;
					enumerator2 = enumerator3;
					continue;
				}
				break;
				IL_0167:
				((OrderedDictionary<Skin.SkinEntry, Attachment>)(object)enumerator2)[(Skin.SkinEntry)num3] = null;
				attachment = null;
				goto IL_043e;
				IL_043e:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v706 @ X0_v7] (should have been resolved before IL gen)");
				goto IL_03f2;
			}
			if (enumerator3 != null)
			{
				nint num6 = (nint)enumerator3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ X8_v15 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ X8_v15 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_032a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ X8_v15 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj13 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ X10_v15-8]");
					if ((IntPtr)0 == intPtr2)
					{
						break;
					}
					object obj14 = (nint)obj12 - 1;
					obj13 = (nint)obj13 + 16;
					bool flag2 = (nint)obj12 != 1;
					obj12 = obj14;
					if (flag2)
					{
						continue;
					}
					goto IL_032a;
				}
				int num7 = obj13 << 4;
				object obj15 = num6 + num7;
				object obj16 = (nint)obj15 + 312;
				goto IL_04ab;
			}
			goto IL_0388;
			IL_032a:
			((OrderedDictionary<Skin.SkinEntry, Attachment>)(object)enumerator3)[(Skin.SkinEntry)(nint)intPtr2] = null;
			goto IL_04ab;
			IL_0388:
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ X0_v23+8]");
			((OrderedDictionary<Skin.SkinEntry, Attachment>)(object)ex2)[(Skin.SkinEntry)0] = null;
			Skin result2 = default(Skin);
			return result2;
			IL_04ab:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v610 @ X0_v23] (should have been resolved before IL gen)");
			goto IL_0388;
		}

		[Token(Token = "0x600073C")]
		[Address(RVA = "0x1579044", Offset = "0x1579044", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Spine.Skeleton::FindSlotIndex(skeleton, slotName);\n\tv55 = v22 + 1;\n\tv31 = v55 == 0;\n\tif (v31) goto L_002A;\n\tSpine.Skin::SetAttachment(skin, v22, keyName, attachment);\n\treturn;\n\tthrow System.NullReferenceException;\nL_002A:\n\tv72 = System.String::Format(\"Slot '{0}' does not exist in skeleton.\", v60);\n\tv87 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v87, v72, \"slotName\");\n\tthrow v87;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAttachment(this Skin skin, string slotName, string keyName, Attachment attachment, Skeleton skeleton)
		{
			int num = skeleton.FindSlotIndex(slotName);
			if (num + 1 != 0)
			{
				skin.SetAttachment(num, keyName, attachment);
				return;
			}
			string arg = default(string);
			string message = $"Slot '{arg}' does not exist in skeleton.";
			ArgumentException ex = new ArgumentException(message, "slotName");
			throw ex;
		}

		[Token(Token = "0x600073D")]
		[Address(RVA = "0x157910C", Offset = "0x157910C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = otherSkin == 0;\n\tif (v0) goto L_000A;\n\tSpine.Unity.AttachmentTools.SkinUtilities::CopyTo(otherSkin, skin, 1, 0, 1);\n\treturn;\nL_000A:\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddAttachments(this Skin skin, Skin otherSkin)
		{
			otherSkin?.CopyTo(skin, overwrite: true, cloneAttachments: false);
		}

		[Token(Token = "0x600073E")]
		[Address(RVA = "0x1579130", Offset = "0x1579130", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = Spine.Skeleton::FindSlotIndex(skeleton, slotName);\n\tv51 = v18 + 1;\n\tv27 = v51 == 0;\n\tif (v27) goto L_0026;\n\treturnVal1 = Spine.Skin::GetAttachment(skin, v18, keyName);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0026:\n\tv67 = System.String::Format(\"Slot '{0}' does not exist in skeleton.\", v56);\n\tv81 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v81, v67, \"slotName\");\n\tthrow v81;\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Attachment GetAttachment(this Skin skin, string slotName, string keyName, Skeleton skeleton)
		{
			int num = skeleton.FindSlotIndex(slotName);
			if (num + 1 != 0)
			{
				return skin.GetAttachment(num, keyName);
			}
			string arg = default(string);
			string message = $"Slot '{arg}' does not exist in skeleton.";
			ArgumentException ex = new ArgumentException(message, "slotName");
			throw ex;
		}

		[Token(Token = "0x600073F")]
		[Address(RVA = "0x15791E8", Offset = "0x15791E8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Skin::SetAttachment(skin, slotIndex, keyName, attachment);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAttachment(this Skin skin, int slotIndex, string keyName, Attachment attachment)
		{
			skin.SetAttachment(slotIndex, keyName, attachment);
		}

		[Token(Token = "0x6000740")]
		[Address(RVA = "0x15791FC", Offset = "0x15791FC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = Spine.SkeletonData::FindSlotIndex(skeletonData, slotName);\n\tv51 = v18 + 1;\n\tv27 = v51 == 0;\n\tif (v27) goto L_0026;\n\tSpine.Skin::RemoveAttachment(skin, v18, keyName);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0026:\n\tv67 = System.String::Format(\"Slot '{0}' does not exist in skeleton.\", v56);\n\tv80 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v80, v67, \"slotName\");\n\tthrow v80;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoveAttachment(this Skin skin, string slotName, string keyName, SkeletonData skeletonData)
		{
			int num = skeletonData.FindSlotIndex(slotName);
			if (num + 1 != 0)
			{
				skin.RemoveAttachment(num, keyName);
				return;
			}
			string arg = default(string);
			string message = $"Slot '{arg}' does not exist in skeleton.";
			ArgumentException ex = new ArgumentException(message, "slotName");
			throw ex;
		}

		[Token(Token = "0x6000741")]
		[Address(RVA = "0x15792B4", Offset = "0x15792B4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37D26]) = v33;\nL_001C:\n\tSpine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::Clear(skin.attachments);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Clear(this Skin skin)
		{
			skin.Attachments.Clear();
		}

		[Token(Token = "0x6000742")]
		[Address(RVA = "0x1579308", Offset = "0x1579308", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.AttachmentTools.SkinUtilities::CopyTo(source, destination, 1, 0, 1);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Append(this Skin destination, Skin source)
		{
			source.CopyTo(destination, overwrite: true, cloneAttachments: false);
		}

		[Token(Token = "0x6000743")]
		[Address(RVA = "0x1577E48", Offset = "0x1577E48", Length = "0xE4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005F;\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv481 = Il2CppMethodInfo;\n\tv482 = \"il2cpp_codegen_initialize_runtime_metadata\"(v481, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv647 = Il2CppMethodInfo;\n\tv648 = \"il2cpp_codegen_initialize_runtime_metadata\"(v647, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv725 = Il2CppMethodInfo;\n\tv726 = \"il2cpp_codegen_initialize_runtime_metadata\"(v725, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv900 = Il2CppMethodInfo;\n\tv901 = \"il2cpp_codegen_initialize_runtime_metadata\"(v900, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv978 = Il2CppMethodInfo;\n\tv979 = \"il2cpp_codegen_initialize_runtime_metadata\"(v978, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1039 = Il2CppMethodInfo;\n\tv1040 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1039, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1096 = Il2CppMethodInfo;\n\tv1097 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1096, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1331 = Il2CppMethodInfo;\n\tv1332 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1331, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1553 = Il2CppMethodInfo;\n\tv1554 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1553, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1630 = Il2CppMethodInfo;\n\tv1631 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1630, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1716 = System.IDisposable;\n\tv1717 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1716, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1743 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<Spine.Skin+SkinEntry, Spine.Attachment>>;\n\tv1744 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1743, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv2170 = System.Collections.IEnumerator;\n\tv2171 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2170, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv2466 = Il2CppMethodInfo;\n\tv2467 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2466, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv2659 = Il2CppMethodInfo;\n\tv2660 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2659, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv2927 = Il2CppMethodInfo;\n\tv2928 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2927, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv2949 = Il2CppMethodInfo;\n\tv2950 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2949, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv2974 = Il2CppMethodInfo;\n\tv2975 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2974, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv3011 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3011, destination, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37D27]) = v56;\nL_005F:\n\tv63 = 0;\n\tv2000 = source.attachments;\n\tv1999 = destination.attachments;\n\tv2134 = destination.bones;\n\tv2136 = destination.constraints;\n\tv484 = cloneAttachments == 0;\n\tif (v484) goto L_0223;\n\tv650 = overwrite == 0;\n\tif (v650) goto L_0147;\n\tv907 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::GetEnumerator(source.attachments);\n\tv1046 = 0x1854DB0(v907, Il2CppMethodInfo, overwrite, cloneAttachments, cloneMeshesAsLinked, methodInfo, v43, v44, 0, v46, v47, v48, v49, v50, v51, v52);\n\treturn;\nL_0088:\n\tX8 = *([X27]);\n\tX1 = *([X19]);\n\tX9 = *([X8+12E]);\n\tif (TEMP) goto L_00A7;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_008F:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00AB;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_008F;\nL_00A7:\n\tX0 = X27;\n\tX2 = 0;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00AF;\nL_00AB:\n\tX9 = *([X10]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_00AF:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X27;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00FE;\n\tX8 = *([X27]);\n\tX1 = *([X23]);\n\tX9 = *([X8+12E]);\n\tif (TEMP) goto L_00D5;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_00BD:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00D9;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00BD;\nL_00D5:\n\tX0 = X27;\n\tX2 = 0;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00DD;\nL_00D9:\n\tX9 = *([X10]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_00DD:\n\tX9 = *([X0]);\n\tX1 = *([X0+8]);\n\tX8 = &stack[60];\n\tX0 = X27;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX28 = stack[60];\n\tX29 = stack[68];\n\tX0 = stack[80];\n\tX8 = stack[2C];\n\tX1 = X8 & 1;\n\tX0 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetCopy(X0, X1, X2);\n\tX26 = X0;\n\tV0 = 0;\n\tstack[60] = V0;\n\tstack[70] = V0;\n\tX0 = &stack[60];\n\tX1 = X28;\n\tX2 = X29;\n\tX3 = X26;\n\tX4 = 0;\n\tSpine.Skin+SkinEntry::.ctor(X0, X1, X2, X3, X4);\n\tif (TEMP) goto L_0419;\n\tV0 = stack[60];\n\tV1 = stack[70];\n\tX3 = *([1947000]);\n\tstack[110] = V0;\n\tstack[120] = V1;\n\tX1 = &stack[110];\n\tX0 = X22;\n\tX2 = X26;\n\tSpine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, System.Object>::set_Item(X0, X1, X2, X3);\n\tgoto L_0088;\nL_00FE:\n\tX26 = 0;\n\tX19 = 6;\n\tif (TEMP) goto L_012F;\nL_0108:\n\tgoto L_012E;\n\tv2487 = *([v2173 @ X8_v38+B0]);\n\tv2488 = v2487 + 8;\n\tv2490 = *([v2673 @ X10_v51-8]);\n\tv2678 = v2490 == v2176;\n\tif (v2678) goto L_0127;\n\tv2510 = v2672 - 1;\n\tv2512 = v2673 + 0x10;\n\tv2492 = v2672 != 1;\n\tif (v2492) goto L_FFFFFFFF;\n\tv2513 = v1063;\n\tv2514 = 0;\n\tv2515 = 0xB349B4(v2513, v2176, v2514, v742, v741, methodInfo, v43, v44, v748, v740, v47, v48, v49, v50, v51, v52);\n\tgoto L_012E;\nL_0127:\n\tv2931 = *([v2673 @ X10_v51]);\n\tv2932 = v2931 << 4;\n\tv2933 = v2173 + v2932;\n\tv2934 = v2933 + 0x138;\nL_012E:\n\tSystem.IDisposable::Dis\n// ... truncated")]
		public unsafe static void CopyTo(this Skin source, Skin destination, bool overwrite, bool cloneAttachments, bool cloneMeshesAsLinked = true)
		{
			//IL_00df: Expected O, but got I
			//IL_02dc: Expected I, but got O
			//IL_01a5: Expected I, but got O
			//IL_03c1: Expected O, but got Ref
			//IL_03e7: Expected O, but got I4
			//IL_0779: Expected I, but got O
			//IL_0406: Expected O, but got Ref
			//IL_040e: Expected O, but got I4
			//IL_02b3: Expected O, but got Ref
			//IL_06a4: Expected I, but got O
			//IL_00f6: Expected O, but got I4
			//IL_0103: Expected O, but got Ref
			//IL_016b: Expected O, but got Ref
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary = source.Attachments;
			OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary2 = destination.Attachments;
			ExposedList<BoneData> exposedList = destination.Bones;
			ExposedList<ConstraintData> exposedList2 = destination.Constraints;
			bool flag = !cloneAttachments;
			Skin skin = source;
			bool flag2 = overwrite;
			int num = default(int);
			Attachment attachment = default(Attachment);
			int num2 = default(int);
			BoneData boneData;
			BoneData boneData2 = default(BoneData);
			Skin skin2;
			ExposedList<BoneData> exposedList3;
			ExposedList<ConstraintData> exposedList4;
			if (!flag)
			{
				if (overwrite)
				{
					IEnumerator<KeyValuePair<Skin.SkinEntry, Attachment>> enumerator2 = source.Attachments.GetEnumerator();
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1854DB0 (inside System.__Il2CppComDelegate::Finalize +0x19C)");
					return;
				}
				IEnumerator enumerator3 = source.Attachments.GetEnumerator();
				bool flag3 = (byte)((nuint)num + (nuint)16u) != 0;
				Skin.SkinEntry skinEntry = default(Skin.SkinEntry);
				object obj = (nint)skinEntry + 16;
				string name = default(string);
				while (enumerator3.MoveNext())
				{
					KeyValuePair<Skin.SkinEntry, Attachment> current = ((IEnumerator<KeyValuePair<Skin.SkinEntry, Attachment>>)enumerator3).Current;
					obj = ((bool*)(flag3 ? 1 : 0))->m_value;
					if (!orderedDictionary2.ContainsKey((Skin.SkinEntry)(&num)))
					{
						Attachment copy = attachment.GetCopy(cloneMeshesAsLinked);
						Skin.SkinEntry skinEntry2 = new Skin.SkinEntry(num, name, copy);
						orderedDictionary2.Add((Skin.SkinEntry)(&skinEntry2), copy);
						num2 = 0;
					}
				}
				bool flag4 = enumerator3 == null;
				boneData = boneData2;
				int num3 = num2;
				OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary3 = orderedDictionary;
				nint num4 = unchecked((nint)null);
				bool flag5 = overwrite;
				OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary4 = orderedDictionary2;
				skin2 = source;
				exposedList3 = exposedList;
				exposedList4 = exposedList2;
				int num5 = 6;
				if (!flag4)
				{
					((IDisposable)enumerator3).Dispose();
					boneData = boneData2;
					num3 = num2;
					orderedDictionary3 = orderedDictionary;
					num4 = unchecked((nint)null);
					flag5 = overwrite;
					orderedDictionary4 = orderedDictionary2;
					skin2 = source;
					exposedList3 = exposedList;
					exposedList4 = exposedList2;
					num5 = 6;
				}
				if (num4 != 0)
				{
					goto IL_05c2;
				}
				if (num5 == 6)
				{
					goto IL_04a8;
				}
				bool flag6 = num5 == 0;
				bool flag7 = !flag6;
				boneData2 = boneData;
				num2 = num3;
				orderedDictionary2 = orderedDictionary4;
				orderedDictionary = orderedDictionary3;
				skin = skin2;
				exposedList = exposedList3;
				exposedList2 = exposedList4;
				flag2 = flag5;
				if (flag7)
				{
					return;
				}
			}
			if (flag2)
			{
				IEnumerator enumerator4 = orderedDictionary.GetEnumerator();
				Skin.SkinEntry skinEntry3 = default(Skin.SkinEntry);
				while (enumerator4.MoveNext())
				{
					KeyValuePair<Skin.SkinEntry, Attachment> current2 = ((IEnumerator<KeyValuePair<Skin.SkinEntry, Attachment>>)enumerator4).Current;
					if (orderedDictionary2 != null)
					{
						orderedDictionary2[(Skin.SkinEntry)(&skinEntry3)] = attachment;
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					throw ex;
				}
				bool flag8 = enumerator4 == null;
				boneData = boneData2;
				int num6 = num2;
				nint num7 = unchecked((nint)null);
				OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary5 = orderedDictionary2;
				OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary6 = orderedDictionary;
				skin2 = skin;
				exposedList3 = exposedList;
				exposedList4 = exposedList2;
				int num8 = 6;
				if (!flag8)
				{
					((IDisposable)enumerator4).Dispose();
					boneData = boneData2;
					num6 = num2;
					num7 = unchecked((nint)null);
					orderedDictionary5 = orderedDictionary2;
					orderedDictionary6 = orderedDictionary;
					skin2 = skin;
					exposedList3 = exposedList;
					exposedList4 = exposedList2;
					num8 = 6;
				}
				if (num7 != 0)
				{
					goto IL_05c2;
				}
				if (num8 == 6)
				{
					goto IL_04a8;
				}
				bool flag9 = num8 == 0;
				bool flag10 = !flag9;
				boneData2 = boneData;
				num2 = num6;
				orderedDictionary2 = orderedDictionary5;
				orderedDictionary = orderedDictionary6;
				skin = skin2;
				exposedList = exposedList3;
				exposedList2 = exposedList4;
				if (flag10)
				{
					return;
				}
			}
			IEnumerator enumerator5 = orderedDictionary.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				KeyValuePair<Skin.SkinEntry, Attachment> current3 = ((IEnumerator<KeyValuePair<Skin.SkinEntry, Attachment>>)enumerator5).Current;
				bool flag11 = orderedDictionary2.ContainsKey((Skin.SkinEntry)(&num));
				bool flag12 = !flag11;
				bool flag13 = !flag12;
				boneData2 = (BoneData)num2;
				if (!flag13)
				{
					orderedDictionary2.Add((Skin.SkinEntry)(&num), attachment);
					boneData2 = (BoneData)num2;
				}
			}
			bool flag14 = enumerator5 == null;
			boneData = boneData2;
			OrderedDictionary<Skin.SkinEntry, Attachment> orderedDictionary7 = null;
			skin2 = skin;
			exposedList3 = exposedList;
			exposedList4 = exposedList2;
			int num9 = 6;
			if (!flag14)
			{
				((IDisposable)enumerator5).Dispose();
				boneData = boneData2;
				orderedDictionary7 = null;
				skin2 = skin;
				exposedList3 = exposedList;
				exposedList4 = exposedList2;
				num9 = 6;
			}
			if (orderedDictionary7 == null)
			{
				if (num9 == 6 || num9 == 0)
				{
					goto IL_04a8;
				}
				return;
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			NullReferenceException ex3 = new NullReferenceException();
			NullReferenceException ex4 = new NullReferenceException();
			throw new NullReferenceException();
			IL_04a8:
			ExposedList<BoneData>.Enumerator enumerator6 = skin2.Bones.GetEnumerator();
			ExposedList<object>.Enumerator enumerator7 = default(ExposedList<object>.Enumerator);
			while (enumerator7.MoveNext())
			{
				if (!exposedList3.Contains(boneData))
				{
					exposedList3.Add(boneData);
				}
			}
			enumerator7.Dispose();
			ExposedList<ConstraintData>.Enumerator enumerator8 = skin2.Constraints.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!exposedList4.Contains(null))
				{
					exposedList4.Add(null);
				}
			}
			enumerator.Dispose();
			return;
			IL_05c2:
			OutOfMemoryException ex5 = new OutOfMemoryException();
			throw new NullReferenceException();
		}
	}
}
