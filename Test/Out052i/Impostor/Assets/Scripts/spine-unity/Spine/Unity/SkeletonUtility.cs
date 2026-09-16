using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteAlways]
	[RequireComponent(typeof(ISkeletonAnimation))]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonUtility")]
	[Token(Token = "0x2000099")]
	public sealed class SkeletonUtility : MonoBehaviour
	{
		[Token(Token = "0x200009A")]
		public delegate void SkeletonUtilityDelegate();

		[CompilerGenerated]
		[Token(Token = "0x40003BF")]
		[FieldOffset(Offset = "0x20")]
		private SkeletonUtilityDelegate m_OnReset;

		[Token(Token = "0x40003C0")]
		[FieldOffset(Offset = "0x28")]
		public Transform boneRoot;

		[Token(Token = "0x40003C1")]
		[FieldOffset(Offset = "0x30")]
		public bool flipBy180DegreeRotation;

		[HideInInspector]
		[Token(Token = "0x40003C2")]
		[FieldOffset(Offset = "0x38")]
		public SkeletonRenderer skeletonRenderer;

		[HideInInspector]
		[Token(Token = "0x40003C3")]
		[FieldOffset(Offset = "0x40")]
		public SkeletonGraphic skeletonGraphic;

		[Token(Token = "0x40003C4")]
		[FieldOffset(Offset = "0x48")]
		private Canvas canvas;

		[NonSerialized]
		[Token(Token = "0x40003C5")]
		[FieldOffset(Offset = "0x50")]
		public ISkeletonAnimation skeletonAnimation;

		[Token(Token = "0x40003C6")]
		[FieldOffset(Offset = "0x58")]
		private ISkeletonComponent skeletonComponent;

		[NonSerialized]
		[Token(Token = "0x40003C7")]
		[FieldOffset(Offset = "0x60")]
		public List<SkeletonUtilityBone> boneComponents;

		[NonSerialized]
		[Token(Token = "0x40003C8")]
		[FieldOffset(Offset = "0x68")]
		public List<SkeletonUtilityConstraint> constraintComponents;

		[Token(Token = "0x40003C9")]
		[FieldOffset(Offset = "0x70")]
		private float positionScale;

		[Token(Token = "0x40003CA")]
		[FieldOffset(Offset = "0x74")]
		private bool hasOverrideBones;

		[Token(Token = "0x40003CB")]
		[FieldOffset(Offset = "0x75")]
		private bool hasConstraints;

		[Token(Token = "0x40003CC")]
		[FieldOffset(Offset = "0x76")]
		private bool needToReprocessBones;

		[Token(Token = "0x170001AD")]
		public ISkeletonComponent SkeletonComponent
		{
			[Token(Token = "0x6000632")]
			[Address(RVA = "0x156A160", Offset = "0x156A160", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv41 = UnityEngine.Object;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37CA4]) = v36;\nL_0014:\n\treturnVal1 = this.skeletonComponent;\n\tv38 = this.skeletonComponent == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_004B;\n\tgoto L_0024;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0024:\n\tv71 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0032;\n\tv75 = this.skeletonRenderer == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0044;\n\tgoto L_003F;\nL_0032:\n\tgoto L_0037;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v77, v69, v70, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0037:\n\tv99 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv108 = v99 == 0;\n\tif (v108) goto L_FFFFFFFF;\n\tv110 = this.skeletonGraphic == 0;\n\tv91 = ~v110;\n\tif (v91) goto L_0044;\nL_003F:\n\tthrow System.NullReferenceException;\nL_0044:\n\treturnVal1 = UnityEngine.Component::GetComponent(v87);\n\tthis.skeletonComponent = returnVal1;\nL_004B:\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ISkeletonComponent result = skeletonComponent;
				if (skeletonComponent == null)
				{
					Component component;
					if (skeletonRenderer != null)
					{
						bool flag = (object)skeletonRenderer == null;
						bool flag2 = !flag;
						component = skeletonRenderer;
						if (!flag2)
						{
							goto IL_00d6;
						}
					}
					else if (skeletonGraphic != null)
					{
						bool flag3 = (object)skeletonGraphic == null;
						bool flag4 = !flag3;
						component = skeletonGraphic;
						if (!flag4)
						{
							goto IL_00d6;
						}
					}
					else
					{
						component = this;
					}
					result = (skeletonComponent = component.GetComponent<ISkeletonComponent>());
				}
				return result;
				IL_00d6:
				throw new NullReferenceException();
			}
		}

		[Token(Token = "0x170001AE")]
		public Skeleton Skeleton
		{
			[Token(Token = "0x6000633")]
			[Address(RVA = "0x156A234", Offset = "0x156A234", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Spine.Unity.ISkeletonComponent;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CA5]) = v33;\nL_0011:\n\treturnVal1 = Spine.Unity.SkeletonUtility::get_SkeletonComponent(this);\n\tv36 = returnVal1 == 0;\n\tif (v36) goto L_0040;\n\tgoto L_004D;\n\tv103 = *([v43 @ X8_v3+B0]);\n\tv104 = v103 + 8;\n\tv106 = *([v143 @ X10_v7-8]);\n\tv148 = v106 == v46;\n\tif (v148) goto L_0041;\n\tv126 = v142 - 1;\n\tv128 = v143 + 0x10;\n\tv108 = v142 != 1;\n\tif (v108) goto L_FFFFFFFF;\n\tv129 = 1;\n\tv130 = v37;\n\tv131 = 0xB349B4(v130, v46, v129, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_004D;\nL_0040:\n\treturn returnVal1;\nL_0041:\n\tv154 = *([v143 @ X10_v7]);\n\tv155 = v154 + 1;\n\tv156 = v155 << 4;\n\tv157 = v43 + v156;\n\tv158 = v157 + 0x138;\nL_004D:\n\tinterfaceTailCallResult = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Skeleton skeleton = (Skeleton)SkeletonComponent;
				if (skeleton == null)
				{
					return skeleton;
				}
				return skeletonComponent.Skeleton;
			}
		}

		[Token(Token = "0x170001AF")]
		public bool IsValid
		{
			[Token(Token = "0x6000634")]
			[Address(RVA = "0x156A2F0", Offset = "0x156A2F0", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37CA6]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_002E;\n\tv51 = this.skeletonRenderer;\n\tv54 = ~v51.valid;\n\tif (v54) goto L_002E;\n\tgoto L_0048;\nL_002E:\n\tgoto L_0033;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v57, v46, v47, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0033:\n\tv76 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv79 = v76 == 0;\n\tif (v79) goto L_FFFFFFFF;\n\treturnVal3 = Spine.Unity.SkeletonGraphic::get_IsValid(this.skeletonGraphic);\n\treturn returnVal3;\nL_0048:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (this.skeletonRenderer != null)
				{
					SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
					if (skeletonRenderer.valid)
					{
						return true;
					}
				}
				if (skeletonGraphic != null)
				{
					return skeletonGraphic.IsValid;
				}
				return false;
			}
		}

		[Token(Token = "0x170001B0")]
		public float PositionScale
		{
			[Token(Token = "0x6000635")]
			[Address(RVA = "0x156A3B8", Offset = "0x156A3B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.positionScale;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PositionScale;
			}
		}

		[Token(Token = "0x1400002E")]
		public event SkeletonUtilityDelegate OnReset
		{
			[CompilerGenerated]
			[Token(Token = "0x600062F")]
			[Address(RVA = "0x1569E54", Offset = "0x1569E54", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37CA1]) = v38;\nL_0014:\n\tv40 = this + 0x20;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnReset;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonUtilityDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000630")]
			[Address(RVA = "0x1569EF0", Offset = "0x1569EF0", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37CA2]) = v38;\nL_0014:\n\tv40 = this + 0x20;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnReset;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonUtilityDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000629")]
		[Address(RVA = "0x1569330", Offset = "0x1569330", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = Spine.BoundingBoxAttachment;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, skinName, slotName, attachmentName, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv54 = UnityEngine.Debug;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, skinName, slotName, attachmentName, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv58 = System.Object[];\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, skinName, slotName, attachmentName, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv124 = \"Skin \";\n\tv125 = \"il2cpp_codegen_initialize_runtime_metadata\"(v124, skinName, slotName, attachmentName, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv191 = \"Attachment in slot '{0}' named '{1}' not found in skin '{2}'.\";\n\tv192 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, skinName, slotName, attachmentName, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv240 = \" not found!\";\n\tv241 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, skinName, slotName, attachmentName, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv270 = \"Attachment '{0}' was not a Bounding Box.\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, skinName, slotName, attachmentName, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A37C9C]) = v49;\nL_002E:\n\tv52 = System.String::IsNullOrEmpty(skinName);\n\tv61 = skeleton.data;\n\tv127 = v52 == 0;\n\tif (v127) goto L_0088;\n\tv121 = v61.defaultSkin;\n\tv194 = v61.defaultSkin == 0;\n\tif (v194) goto L_0095;\nL_003E:\n\tv251 = Spine.Skeleton::FindSlotIndex(skeleton, slotName);\n\tv273 = Spine.Skin::GetAttachment(v121, v251, attachmentName);\n\tv281 = v273 == 0;\n\tif (v281) goto L_00A8;\n\tgoto L_FFFFFFFF;\n\tv311 = v311_asT != 0;\n\tif (v311) goto L_0101;\n\t// 106 NewArr v110 @ X0_v44 (System.Object[]), typeof(System.Object[]), 1\n\tv420 = attachmentName == 0;\n\tif (v420) goto L_0079;\n\t// 115 IsInst v219 @ X0_v50, typeof(System.Object), attachmentName @ X3 (System.String)\n\tv224 = v219 == 0;\n\tif (v224) goto L_0115;\nL_0079:\n\tv110[0] = attachmentName;\n\tgoto L_FFFFFFFF;\n\tv438 = \"il2cpp_codegen_runtime_class_init\"(v430, v162, v105, v103, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00F2;\nL_0088:\n\tv197 = Spine.SkeletonData::FindSkin(skeleton.data, skinName);\n\tv266 = v197 == 0;\n\tv246 = ~v266;\n\tif (v246) goto L_003E;\nL_0095:\n\tv265 = System.String::Concat(\"Skin \", skinName, \" not found!\");\n\tgoto L_00A2;\n\tv282 = v277;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v282, v261, v264, v262, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00A2:\n\tUnityEngine.Debug::LogError(v265);\n\tgoto L_00FD;\nL_00A8:\n\t// 168 NewArr v111 @ X0_v30 (System.Object[]), typeof(System.Object[]), 3\n\tv418 = slotName == 0;\n\tif (v418) goto L_00B7;\n\t// 177 IsInst v220 @ X0_v42, typeof(System.Object), slotName @ X2 (System.String)\n\tv225 = v220 == 0;\n\tif (v225) goto L_0115;\nL_00B7:\n\tv111[0] = slotName;\n\tv427 = attachmentName == 0;\n\tif (v427) goto L_00CD;\n\t// 189 IsInst v221 @ X0_v40, typeof(System.Object), attachmentName @ X3 (System.String)\n\tv226 = v221 == 0;\n\tif (v226) goto L_0115;\nL_00CD:\n\tv111[1] = attachmentName;\n\tv443 = v121.name == 0;\n\tif (v443) goto L_00E4;\n\t// 212 IsInst v222 @ X0_v38, typeof(System.Object), v121.name (System.String)\n\tv227 = v222 == 0;\n\tif (v227) goto L_0115;\nL_00E4:\n\tv111[2] = v121.name;\n\tgoto L_FFFFFFFF;\n\tv458 = \"il2cpp_codegen_runtime_class_init\"(v455, v165, v105, v103, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00F2:\n\tUnityEngine.Debug::LogFormat(*([v412 @ X8_v13 (System.String)]), v400);\nL_00FD:\n\treturn 0;\nL_0101:\n\tv417 = Spine.Skeleton::FindSlot(skeleton, slotName);\n\treturnVal3 = Spine.Unity.SkeletonUtility::AddBoundingBoxGameObject(v273.<Name>k__BackingField, v273, v417, parent, isTrigger);\n\treturn returnVal3;\n\tv122 = new System.NullReferenceException();\n\tv189 = new System.IndexOutOfRangeException();\nL_0115:\n\tv238 = new System.ArrayTypeMismatchException();\n\tthrow v238;\n\treturn returnVal1;\n// 199 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PolygonCollider2D AddBoundingBoxGameObject(Skeleton skeleton, string skinName, string slotName, string attachmentName, Transform parent, bool isTrigger = true)
		{
			bool flag = string.IsNullOrEmpty(skinName);
			SkeletonData data = skeleton.Data;
			Skin skin;
			if (flag)
			{
				skin = data.DefaultSkin;
				if (data.DefaultSkin != null)
				{
					goto IL_0063;
				}
			}
			else
			{
				Skin skin2 = skeleton.Data.FindSkin(skinName);
				bool flag2 = skin2 == null;
				bool flag3 = !flag2;
				skin = skin2;
				if (flag3)
				{
					goto IL_0063;
				}
			}
			string message = "Skin " + skinName + " not found!";
			Debug.LogError(message);
			goto IL_031c;
			IL_031c:
			return null;
			IL_035b:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
			IL_0063:
			int slotIndex = skeleton.FindSlotIndex(slotName);
			Attachment attachment = skin.GetAttachment(slotIndex, attachmentName);
			object[] args;
			string format;
			if (attachment != null)
			{
				BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
				if (boundingBoxAttachment != null)
				{
					Slot slot = skeleton.FindSlot(slotName);
					return AddBoundingBoxGameObject(attachment.Name, (BoundingBoxAttachment)attachment, slot, parent, isTrigger);
				}
				object[] array = new object[1];
				if (attachmentName != null)
				{
					object obj = attachmentName as object;
					if (obj == null)
					{
						goto IL_035b;
					}
				}
				array[0] = attachmentName;
				args = array;
				format = "Attachment '{0}' was not a Bounding Box.";
			}
			else
			{
				object[] array2 = new object[3];
				if (slotName != null)
				{
					object obj2 = slotName as object;
					if (obj2 == null)
					{
						goto IL_035b;
					}
				}
				array2[0] = slotName;
				if (attachmentName != null)
				{
					object obj3 = attachmentName as object;
					if (obj3 == null)
					{
						goto IL_035b;
					}
				}
				array2[1] = attachmentName;
				if (skin.Name != null)
				{
					object obj4 = skin.Name as object;
					if (obj4 == null)
					{
						goto IL_035b;
					}
				}
				array2[2] = skin.Name;
				args = array2;
				format = "Attachment in slot '{0}' named '{1}' not found in skin '{2}'.";
			}
			Debug.LogFormat(format, args);
			goto IL_031c;
		}

		[Token(Token = "0x600062A")]
		[Address(RVA = "0x1569644", Offset = "0x1569644", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = UnityEngine.GameObject;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, box, slot, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv55 = \"[BoundingBox]\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, box, slot, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C9D]) = v50;\nL_0020:\n\tv53 = System.String::IsNullOrEmpty(name);\n\tv58 = v53 == 0;\n\tif (v58) goto L_002D;\n\tv61 = box.<Name>k__BackingField;\nL_002D:\n\tv68 = System.String::Concat(\"[BoundingBox]\", v61);\n\tv75 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v75, v68);\n\tv76 = UnityEngine.GameObject::get_transform(v75);\n\tUnityEngine.Transform::set_parent(v76, parent);\n\tgoto L_0055;\n\tv142 = UnityEngine.Vector3;\n\tv143 = \"il2cpp_codegen_initialize_runtime_metadata\"(v142, v134, v135, parent, isTrigger, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv146 = 1;\n\t*([1A35519]) = v146;\nL_0055:\n\tUnityEngine.Transform::set_localPosition(v76, v152.zeroVector);\n\tgoto L_006B;\n\tv161 = UnityEngine.Quaternion;\n\tv162 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, v150, v135, parent, isTrigger, methodInfo, v37, v38, v153, v154, v155, v42, v43, v44, v45, v46);\n\tv165 = 1;\n\t*([1A3551A]) = v165;\nL_006B:\n\tUnityEngine.Transform::set_localRotation(v76, v171.identityQuaternion);\n\tgoto L_007E;\n\tv179 = UnityEngine.Vector3;\n\tv180 = \"il2cpp_codegen_initialize_runtime_metadata\"(v179, v169, v135, parent, isTrigger, methodInfo, v37, v38, v172, v173, v174, v95, v43, v44, v45, v46);\n\tv183 = 1;\n\t*([1A35658]) = v183;\nL_007E:\n\tUnityEngine.Transform::set_localScale(v76, v128.oneVector);\n\treturnVal2 = Spine.Unity.SkeletonUtility::AddBoundingBoxAsComponent(box, slot, v75, isTrigger);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PolygonCollider2D AddBoundingBoxGameObject(string name, BoundingBoxAttachment box, Slot slot, Transform parent, bool isTrigger = true)
		{
			bool flag = string.IsNullOrEmpty(name);
			bool flag2 = !flag;
			string text = name;
			if (!flag2)
			{
				text = box.Name;
			}
			string text2 = "[BoundingBox]" + text;
			GameObject gameObject = new GameObject(text2);
			Transform transform = gameObject.transform;
			transform.parent = parent;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			return AddBoundingBoxAsComponent(box, slot, gameObject, isTrigger);
		}

		[Token(Token = "0x600062B")]
		[Address(RVA = "0x1569800", Offset = "0x1569800", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, slot, gameObject, isTrigger, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37C9E]) = v42;\nL_0016:\n\tv43 = box == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv50 = UnityEngine.GameObject::AddComponent(gameObject);\n\tUnityEngine.Collider2D::set_isTrigger(v50, isTrigger);\n\tSpine.Unity.SkeletonUtility::SetColliderPointsLocal(v50, slot, box, 1f);\n\tgoto L_0034;\nL_0034:\n\treturn v66;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PolygonCollider2D AddBoundingBoxAsComponent(BoundingBoxAttachment box, Slot slot, GameObject gameObject, bool isTrigger = true)
		{
			if (box != null)
			{
				PolygonCollider2D polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
				polygonCollider2D.isTrigger = isTrigger;
				SetColliderPointsLocal(polygonCollider2D, slot, box);
				return polygonCollider2D;
			}
			return null;
		}

		[Token(Token = "0x600062C")]
		[Address(RVA = "0x15698A0", Offset = "0x15698A0", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = UnityEngine.Debug;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, slot, box, methodInfo, v27, v28, v29, v30, scale, v31, v32, v33, v34, v35, v36, v37);\n\tv44 = \"UnityEngine.PolygonCollider2D does not support weighted or animated points. Collider points will not be animated and may have incorrect orientation. If you want to use it as a collider, please remove weights and animations from the bounding box in Spine editor.\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, slot, box, methodInfo, v27, v28, v29, v30, scale, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37C9F]) = v41;\nL_0018:\n\tv42 = box == 0;\n\tif (v42) goto L_007E;\n\tv47 = Spine.SpineSkeletonExtensions::IsWeighted(box);\n\tv54 = v47 == 0;\n\tif (v54) goto L_0030;\n\tgoto L_002C;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v133, v46, box, methodInfo, v27, v28, v29, v30, scale, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tUnityEngine.Debug::LogWarning(\"UnityEngine.PolygonCollider2D does not support weighted or animated points. Collider points will not be animated and may have incorrect orientation. If you want to use it as a collider, please remove weights and animations from the bounding box in Spine editor.\");\nL_0030:\n\tv146 = Spine.Unity.SkeletonExtensions::GetLocalVertices(box, slot, 0);\n\tv156 = scale == 1f;\n\tif (v156) goto L_0076;\n\tv164 = v146.Length < 1;\n\tif (v164) goto L_0076;\n\tv165 = v146.Length & 0xFFFFFFFF;\n\tv162 = v146 + 0x20;\n\t// 81 NotImplemented \"Instruction DUP not yet implemented.\"\nL_005D:\n\tv184 = *([v162 @ X10_v3+v201 @ X8_v7 (System.Int32)*8]) * scale;\n\t*([v162 @ X10_v3+v201 @ X8_v7 (System.Int32)*8]) = v184;\n\tv201 = v201 + 1;\n\tv163 = v165 != v201;\n\tif (v163) goto L_005D;\nL_0076:\n\tUnityEngine.PolygonCollider2D::SetPath(collider, 0, v146);\n\treturn;\nL_007E:\n\treturn;\n\tv200 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColliderPointsLocal(PolygonCollider2D collider, Slot slot, BoundingBoxAttachment box, float scale = 1f)
		{
			//IL_00a7: Expected I4, but got I8
			//IL_00b6: Expected O, but got I
			if (box == null)
			{
				return;
			}
			if (box.IsWeighted())
			{
				Debug.LogWarning("UnityEngine.PolygonCollider2D does not support weighted or animated points. Collider points will not be animated and may have incorrect orientation. If you want to use it as a collider, please remove weights and animations from the bounding box in Spine editor.");
			}
			Vector2[] localVertices = box.GetLocalVertices(slot, null);
			if (scale != 1f && localVertices.Length >= 1)
			{
				int num = (int)(localVertices.Length & 0xFFFFFFFFL);
				object obj = (nint)localVertices + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				int num2 = 0;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X10_v3+v201 @ X8_v7 (System.Int32)*8]");
					float num3 = 0f * scale;
					num2++;
				}
				while (num != num2);
			}
			collider.SetPath(0, localVertices);
		}

		[Token(Token = "0x600062D")]
		[Address(RVA = "0x1569C74", Offset = "0x1569C74", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = boundingBox.vertices;\n\tv114 = v4[0];\n\tv113 = v4[1];\n\tv197 = v4.Length < 3;\n\tif (v197) goto L_00A1;\nL_0031:\n\tv107 = v109 + 1;\n\tv203 = v113 - v111;\n\tv296 = v113 + v111;\n\tv202 = v114 - v108;\n\tv282 = v114 + v108;\n\tv252 = v202 >= v4[v109 @ X11_v5 (System.Int32)];\n\tif (v252) goto L_FFFFFFFF;\n\tgoto L_005E;\nL_005E:\n\tv264 = v203 >= v4[v107 @ X12_v5 (System.Int32)];\n\tif (v264) goto L_FFFFFFFF;\n\tgoto L_0066;\nL_0066:\n\tv269 = v282 - v4[v109 @ X11_v5 (System.Int32)];\n\tv270 = v269 < 0;\n\tv271 = v269 == 0;\n\tv272 = v282 ^ v4[v109 @ X11_v5 (System.Int32)];\n\tv273 = v282 ^ v269;\n\tv274 = v272 & v273;\n\tv275 = v274 < 0;\n\tv276 = v270 == v275;\n\tv277 = ~v271;\n\tv278 = v276 & v277;\n\tv279 = ~v278;\n\tif (v279) goto L_FFFFFFFF;\n\tgoto L_0078;\nL_0078:\n\tv285 = v296 - v4[v107 @ X12_v5 (System.Int32)];\n\tv286 = v285 < 0;\n\tv287 = v285 == 0;\n\tv288 = v296 ^ v4[v107 @ X12_v5 (System.Int32)];\n\tv289 = v296 ^ v285;\n\tv290 = v288 & v289;\n\tv291 = v290 < 0;\n\tv292 = v286 == v291;\n\tv200 = ~v287;\n\tv293 = v292 & v200;\n\tv201 = ~v293;\n\tif (v201) goto L_FFFFFFFF;\n\tgoto L_0088;\nL_0088:\n\tv297 = v282 - v202;\n\tv298 = v296 - v203;\n\tv109 = v107 + 1;\n\tv108 = v297 * 0.5f;\n\tv111 = v298 * 0.5f;\n\tv114 = v202 + v108;\n\tv113 = v203 + v111;\n\tv209 = v109 < v4.Length;\n\tif (v209) goto L_0031;\n\tv301 = v108 + v108;\n\tv302 = v111 + v111;\n\tv211 = v301 * 0.5f;\n\tv157 = v302 * 0.5f;\nL_00A1:\n\tv136 = depth * 0.5f;\n\treturnBuffer.m_Center = v114;\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+4]) = v113;\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+8]) = 0;\n\treturnBuffer.m_Extents = v159;\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+10]) = v157;\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+14]) = v136;\n\treturn boundingBox;\n\tv10 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Bounds GetBoundingBoxBounds(BoundingBoxAttachment boundingBox, float depth = 0f)
		{
			//IL_01d5: Expected O, but got F4
			//IL_01d0: Expected native int or pointer, but got O
			//IL_01e8: Expected native int or pointer, but got O
			//IL_0276: Expected O, but got F4
			//IL_0283: Expected O, but got F4
			//IL_0330: Expected O, but got F4
			//IL_033d: Expected O, but got F4
			//IL_01b3: Expected O, but got F4
			float[] vertices = boundingBox.Vertices;
			float num = vertices[0];
			float num2 = vertices[1];
			bool flag = vertices.Length < 3;
			float num3 = 0f;
			Vector3 extents = default(Vector3);
			if (!flag)
			{
				float num4 = 0f;
				int num5 = 2;
				float num6 = 0f;
				do
				{
					int num7 = num5 + 1;
					float num8 = num2 - num6;
					float num9 = num2 + num6;
					float num10 = num - num4;
					float num11 = num + num4;
					if (!(num10 < vertices[num5]))
					{
						num10 = vertices[num5];
					}
					if (!(num8 < vertices[num7]))
					{
						num8 = vertices[num7];
					}
					float num12 = num11 - vertices[num5];
					bool flag2 = num12 < 0f;
					bool flag3 = num12 == 0f;
					object obj = num11 ^ vertices[num5];
					object obj2 = num11 ^ num12;
					int num13 = (int)((nint)obj & (nint)obj2);
					bool flag4 = num13 < 0;
					bool flag5 = flag2 == flag4;
					bool flag6 = !flag3;
					if (!(flag5 && flag6))
					{
						num11 = vertices[num5];
					}
					float num14 = num9 - vertices[num7];
					bool flag7 = num14 < 0f;
					bool flag8 = num14 == 0f;
					object obj3 = num9 ^ vertices[num7];
					object obj4 = num9 ^ num14;
					int num15 = (int)((nint)obj3 & (nint)obj4);
					bool flag9 = num15 < 0;
					bool flag10 = flag7 == flag9;
					bool flag11 = !flag8;
					if (!(flag10 && flag11))
					{
						num9 = vertices[num7];
					}
					float num16 = num11 - num10;
					float num17 = num9 - num8;
					num5 = num7 + 1;
					num4 = num16 * 0.5f;
					num6 = num17 * 0.5f;
					num = num10 + num4;
					num2 = num8 + num6;
				}
				while (num5 < vertices.Length);
				float num18 = num4 + num4;
				float num19 = num6 + num6;
				float num20 = num18 * 0.5f;
				num3 = num19 * 0.5f;
				extents = (Vector3)num20;
			}
			float num21 = depth * 0.5f;
			Bounds bounds = default(Bounds);
			((Bounds*)(nint)bounds)->m_Center = (Vector3)num;
			_ = 0;
			((Bounds*)(nint)bounds)->m_Extents = extents;
			return (Bounds)boundingBox;
		}

		[Token(Token = "0x600062E")]
		[Address(RVA = "0x1569D68", Offset = "0x1569D68", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, isKinematic, methodInfo, v25, v26, v27, v28, v29, gravityScale, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, isKinematic, methodInfo, v25, v26, v27, v28, v29, gravityScale, v30, v31, v32, v33, v34, v35, v36);\n\tv69 = UnityEngine.Object;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, isKinematic, methodInfo, v25, v26, v27, v28, v29, gravityScale, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37CA0]) = v40;\nL_0022:\n\tv51 = UnityEngine.GameObject::GetComponent(gameObject);\n\tgoto L_002E;\n\tv73 = v70;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v73, v49, methodInfo, v25, v26, v27, v28, v29, gravityScale, v30, v31, v32, v33, v34, v35, v36);\nL_002E:\n\tv78 = UnityEngine.Object::op_Equality(v51, 0);\n\tv103 = v78 == 0;\n\tif (v103) goto L_0048;\n\tv60 = UnityEngine.GameObject::AddComponent(gameObject);\n\tUnityEngine.Rigidbody2D::set_isKinematic(v60, isKinematic);\n\tUnityEngine.Rigidbody2D::set_gravityScale(v60, gravityScale);\nL_0048:\n\treturn v111;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rigidbody2D AddBoneRigidbody2D(GameObject gameObject, bool isKinematic = true, float gravityScale = 0f)
		{
			Rigidbody2D component = gameObject.GetComponent<Rigidbody2D>();
			bool flag = component == null;
			bool flag2 = !flag;
			Rigidbody2D result = component;
			if (!flag2)
			{
				Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
				rigidbody2D.isKinematic = isKinematic;
				rigidbody2D.gravityScale = gravityScale;
				result = rigidbody2D;
			}
			return result;
		}

		[Token(Token = "0x6000631")]
		[Address(RVA = "0x1569F8C", Offset = "0x1569F8C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Spine.Unity.ISkeletonComponent;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = UnityEngine.Object;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37CA3]) = v42;\nL_0020:\n\tgoto L_0049;\n\tv165 = *([v48 @ X8_v4+B0]);\n\tv166 = v165 + 8;\n\tv168 = *([v205 @ X10_v8-8]);\n\tv210 = v168 == v51;\n\tif (v210) goto L_003F;\n\tv188 = v204 - 1;\n\tv190 = v205 + 0x10;\n\tv170 = v204 != 1;\n\tif (v170) goto L_FFFFFFFF;\n\tv191 = 1;\n\tv192 = v43;\n\tv193 = 0xB349B4(v192, v51, v191, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0049;\nL_003F:\n\tv261 = *([v205 @ X10_v8]);\n\tv262 = v261 + 1;\n\tv263 = v262 << 4;\n\tv264 = v48 + v263;\n\tv265 = v264 + 0x138;\nL_0049:\n\tv273 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv274 = v273 == 0;\n\tif (v274) goto L_00AE;\n\tgoto L_0057;\n\tv315 = \"il2cpp_codegen_runtime_class_init\"(v275, v270, v266, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0057:\n\tv305 = UnityEngine.Object::op_Inequality(this.boneRoot, 0);\n\tv308 = v305 == 0;\n\tif (v308) goto L_00AE;\n\tv84 = Spine.Skeleton::get_ScaleY(v273);\n\tv327 = ~this.flipBy180DegreeRotation;\n\tif (v327) goto L_00A7;\n\tv81 = UnityEngine.Mathf::Abs(v84);\n\tv328 = UnityEngine.Mathf::Abs(v273.scaleX);\n\t// 107 MakeStruct v74 @ AGG156E0A8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v328 @ V0_v7 (System.Single), v81 @ V1_v4 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(this.boneRoot, v74);\n\tv85 = Spine.Skeleton::get_ScaleY(v273);\n\tv336 = v273.scaleX < 0;\n\tv337 = v273.scaleX == 0;\n\tv339 = v273.scaleX ^ v273.scaleX;\n\tv340 = v273.scaleX & v339;\n\tv341 = v340 < 0;\n\tv342 = v336 == v341;\n\tv343 = ~v337;\n\tv344 = v342 & v343;\n\tv345 = ~v344;\n\tif (v345) goto L_FFFFFFFF;\n\tgoto L_008C;\nL_008C:\n\tv296 = v85 < 0;\n\tv295 = v85 == 0;\n\tv293 = v85 ^ v85;\n\tv292 = v85 & v293;\n\tv291 = v292 < 0;\n\tv349 = v296 == v291;\n\tv282 = ~v295;\n\tv290 = v349 & v282;\n\tv281 = ~v290;\n\tif (v281) goto L_FFFFFFFF;\n\tgoto L_009E;\nL_009E:\n\t// 158 MakeStruct v279 @ AGG156E0EC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v288 @ V0_v9 (System.Int32), v286 @ V1_v6 (System.Int32), 0\n\tUnityEngine.Transform::set_eulerAngles(this.boneRoot, v279);\n\tgoto L_00AE;\nL_00A7:\n\t// 167 MakeStruct v280 @ AGG156E108_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v273.scaleX (System.Single), v84 @ V0_v5 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(this.boneRoot, v280);\nL_00AE:\n\tgoto L_00B3;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v312, v299, v289, v26, v27, v28, v29, v30, v86, v82, v78, v71, v35, v36, v37, v38);\nL_00B3:\n\tv321 = UnityEngine.Object::op_Inequality(this.canvas, 0);\n\tv324 = v321 == 0;\n\tif (v324) goto L_00C5;\n\tv325 = UnityEngine.Canvas::get_referencePixelsPerUnit(this.canvas);\n\tthis.positionScale = v325;\nL_00C5:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0114: Expected I4, but got F4
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Expected I4, but got Unknown
			//IL_0298: Expected O, but got F4
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Expected I4, but got Unknown
			Skeleton skeleton = skeletonComponent.Skeleton;
			if (skeleton != null && boneRoot != null)
			{
				float scaleY = skeleton.ScaleY;
				if (flipBy180DegreeRotation)
				{
					float y = Mathf.Abs(scaleY);
					float x = Mathf.Abs(skeleton.ScaleX);
					Vector3 localScale = default(Vector3);
					localScale.x = x;
					localScale.y = y;
					localScale.z = 1f;
					boneRoot.localScale = localScale;
					float scaleY2 = skeleton.ScaleY;
					bool flag = skeleton.ScaleX < 0f;
					bool flag2 = skeleton.ScaleX == 0f;
					int num = skeleton.ScaleX ^ skeleton.ScaleX;
					int num2 = skeleton.ScaleX & num;
					bool flag3 = num2 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					int num3 = ((!(flag4 && flag5)) ? 1127481344 : 0);
					bool flag6 = scaleY2 < 0f;
					bool flag7 = scaleY2 == 0f;
					object obj = scaleY2 ^ scaleY2;
					int num4 = scaleY2 & (nint)obj;
					bool flag8 = num4 < 0;
					bool flag9 = flag6 == flag8;
					bool flag10 = !flag7;
					int num5 = ((!(flag9 && flag10)) ? 1127481344 : 0);
					Vector3 eulerAngles = default(Vector3);
					eulerAngles.x = num5;
					eulerAngles.y = num3;
					eulerAngles.z = 0f;
					boneRoot.eulerAngles = eulerAngles;
				}
				else
				{
					Vector3 localScale2 = default(Vector3);
					localScale2.x = skeleton.ScaleX;
					localScale2.y = scaleY;
					localScale2.z = 1f;
					boneRoot.localScale = localScale2;
				}
			}
			if (canvas != null)
			{
				float referencePixelsPerUnit = canvas.referencePixelsPerUnit;
				positionScale = referencePixelsPerUnit;
			}
		}

		[Token(Token = "0x6000636")]
		[Address(RVA = "0x156A3C0", Offset = "0x156A3C0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonUtility::OnDisable(this);\n\tSpine.Unity.SkeletonUtility::OnEnable(this);\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResubscribeEvents()
		{
			OnDisable();
			OnEnable();
		}

		[Token(Token = "0x6000637")]
		[Address(RVA = "0x156A728", Offset = "0x156A728", Length = "0x560")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv90 = Spine.Unity.ISkeletonAnimation;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv95 = UnityEngine.Object;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv109 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv110 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv132 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv133 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv163 = Il2CppMethodInfo;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv180 = Il2CppMethodInfo;\n\tv181 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv195 = Il2CppMethodInfo;\n\tv196 = \"il2cpp_codegen_initialize_runtime_metadata\"(v195, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv230 = Spine.Unity.UpdateBonesDelegate;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37CA7]) = v44;\nL_003F:\n\tgoto L_0044;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0044:\n\tv58 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv63 = v58 == 0;\n\tif (v63) goto L_0053;\n\tv71 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonRenderer = v71;\nL_0053:\n\tgoto L_0058;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v75, v72, v57, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0058:\n\tv88 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv93 = v88 == 0;\n\tif (v93) goto L_0063;\n\tv101 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonGraphic = v101;\nL_0063:\n\tv106 = this.skeletonAnimation == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0093;\n\tgoto L_0070;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v111, v102, v87, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0070:\n\tv139 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv166 = v139 == 0;\n\tif (v166) goto L_007E;\n\tv183 = this.skeletonRenderer == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0090;\n\tgoto L_01C9;\nL_007E:\n\tgoto L_0083;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v185, v137, v138, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0083:\n\tv210 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv203 = v210 == 0;\n\tif (v203) goto L_FFFFFFFF;\n\tv354 = this.skeletonGraphic == 0;\n\tv204 = ~v354;\n\tif (v204) goto L_0090;\n\tgoto L_01C9;\nL_0090:\n\tv121 = UnityEngine.Component::GetComponent(v200);\n\tthis.skeletonAnimation = v121;\nL_0093:\n\tv129 = this.skeletonComponent == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_00C7;\n\tgoto L_00A0;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v140, v118, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A0:\n\tv172 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv191 = v172 == 0;\n\tif (v191) goto L_00AE;\n\tv212 = this.skeletonRenderer == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_00C0;\n\tgoto L_01C9;\nL_00AE:\n\tgoto L_00B3;\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v214, v170, v171, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00B3:\n\tv346 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv340 = v346 == 0;\n\tif (v340) goto L_FFFFFFFF;\n\tv409 = this.skeletonGraphic == 0;\n\tv316 = ~v409;\n\tif (v316) goto L_00C0;\n\tgoto L_01C9;\nL_00C0:\n\tv150 = UnityEngine.Component::GetComponent(v338);\n\tthis.skeletonComponent = v150;\nL_00C7:\n\tgoto L_00CC;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v157, v147, v145, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00CC:\n\tv178 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv193 = v178 == 0;\n\tif (v193) goto L_00F6;\n\tv223 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v223, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v223);\n\tv309 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v309, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::add_OnRebuild(this.skeletonRenderer, v309);\n\tgoto L_014E;\nL_00F6:\n\tgoto L_00FB;\n\tv348 = \"il2cpp_codegen_runtime_class_init\"(v224, v176, v177, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00FB:\n\tv353 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv357 = v353 == 0;\n\tif (v357) goto L_014E;\n\tv310 = new Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::.ctor(v310, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonGraphic::remove_OnRebuild(this.skeletonGraphic, v310);\n\tv311 = new Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::.ctor(v311, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonGraphic::add_OnRebuild(this.skeletonGraphic, v311);\n\tv545 = UnityEngine.UI.Graphic::get_canvas(this.skeletonGraphic);\n\tthis.canvas = v545;\n\tgoto L_012F;\n\tv581 = \"il2cpp_codegen_runtime_class_init\"(v549, v544, v295, v283, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_012F:\n\tv584 = UnityEngine.Object::op_Equality(v545, 0);\n\tv607 = v584 == 0;\n\tif (v607) goto L_013D;\n\tv621 = UnityEngine.Component::GetComponentInParent(this.skeletonGraphic);\n\tthis.canvas = v621;\n\tgoto L_0142;\nL_013D:\n\tv434 = this.canvas;\nL_0142:\n\tgoto L_0147;\n\tv630 = \"il2cpp_codegen_runtime_class_init\"(v627, v622, v296, v283, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0147:\n\tv425 = UnityEngine.Object::op_Equality(v434, 0);\n\tv428 = v425 == 0;\n\tif (v428) goto L_014E;\n\tthis.positionScale = 100f;\nL_014E:\n\tv436 = this.skeletonAnimation == 0;\n\tif (v436) goto L_01C7;\n\tv443 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v443, this, Il2CppMethodInfo);\n\tgoto L_0188;\n\tv479 = *([v474 @ X8_v14+B0]);\n\tv480 = v479 + 8;\n\tv482 = *([v518 @ X10_v12-8]);\n\tv524 = v482 == v475;\n\tif (v524) goto L_017F;\n\tv504 = v519 - 1;\n\tv502 = v518 + 0x10;\n\tv484 = v519 != 1;\n\tif (v484) goto L_FFFFFFFF;\n\tv505 = 1;\n\tv506 = v435;\n\tv507 = 0xB349B4(v506, v475, v505, v284, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0188;\nL_017F:\n\tv530 = *([v518 @ X10_v12]);\n\tv531 = v530 + 1;\n\tv532 = v531 << 4;\n\tv533 = v474 + v532;\n\tv534 = v533 + 0x138;\nL_0188:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateLocal(this.skeletonAnimation, v443);\n\tv314 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v314, this, Il2CppMethodInfo);\n\tgoto L_01BD;\n\tv552 = *([v546 @ X8_v17+B0]);\n\tv553 = v552 + 8;\n\tv555 = *([v595 @ X10_v7-8]);\n\tv601 = v555 == v547;\n\tif (v601) goto L_01B5;\n\tv577 = v596 - 1;\n\tv575 = v595 + 0x10;\n\tv557 = v596 != 1;\n\tif (v557) goto \n// ... truncated")]
		private void OnEnable()
		{
			if (skeletonRenderer == null)
			{
				SkeletonRenderer component = GetComponent<SkeletonRenderer>();
				skeletonRenderer = component;
			}
			if (skeletonGraphic == null)
			{
				SkeletonGraphic component2 = GetComponent<SkeletonGraphic>();
				skeletonGraphic = component2;
			}
			if (skeletonAnimation == null)
			{
				Component component3;
				if (skeletonRenderer != null)
				{
					bool flag = (object)skeletonRenderer == null;
					bool flag2 = !flag;
					component3 = skeletonRenderer;
					if (!flag2)
					{
						goto IL_0438;
					}
				}
				else if (skeletonGraphic != null)
				{
					bool flag3 = (object)skeletonGraphic == null;
					bool flag4 = !flag3;
					component3 = skeletonGraphic;
					if (!flag4)
					{
						goto IL_0438;
					}
				}
				else
				{
					component3 = this;
				}
				ISkeletonAnimation component4 = component3.GetComponent<ISkeletonAnimation>();
				skeletonAnimation = component4;
			}
			if (skeletonComponent == null)
			{
				Component component5;
				if (skeletonRenderer != null)
				{
					bool flag5 = (object)skeletonRenderer == null;
					bool flag6 = !flag5;
					component5 = skeletonRenderer;
					if (!flag6)
					{
						goto IL_0438;
					}
				}
				else if (skeletonGraphic != null)
				{
					bool flag7 = (object)skeletonGraphic == null;
					bool flag8 = !flag7;
					component5 = skeletonGraphic;
					if (!flag8)
					{
						goto IL_0438;
					}
				}
				else
				{
					component5 = this;
				}
				ISkeletonComponent component6 = component5.GetComponent<ISkeletonComponent>();
				skeletonComponent = component6;
			}
			if (skeletonRenderer != null)
			{
				SkeletonRenderer.SkeletonRendererDelegate value = HandleRendererReset;
				skeletonRenderer.OnRebuild -= value;
				SkeletonRenderer.SkeletonRendererDelegate value2 = HandleRendererReset;
				skeletonRenderer.OnRebuild += value2;
			}
			else if (skeletonGraphic != null)
			{
				SkeletonGraphic.SkeletonRendererDelegate value3 = HandleRendererReset;
				skeletonGraphic.OnRebuild -= value3;
				SkeletonGraphic.SkeletonRendererDelegate value4 = HandleRendererReset;
				skeletonGraphic.OnRebuild += value4;
				Canvas canvas = ((!((this.canvas = skeletonGraphic.canvas) == null)) ? this.canvas : (this.canvas = skeletonGraphic.GetComponentInParent<Canvas>()));
				if (canvas == null)
				{
					positionScale = 100f;
				}
			}
			if (skeletonAnimation != null)
			{
				UpdateBonesDelegate value5 = UpdateLocal;
				skeletonAnimation.UpdateLocal -= value5;
				UpdateBonesDelegate value6 = UpdateLocal;
				skeletonAnimation.UpdateLocal += value6;
			}
			CollectBones();
			return;
			IL_0438:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000638")]
		[Address(RVA = "0x156B3FC", Offset = "0x156B3FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonUtility::CollectBones(this);\n\treturn;\n")]
		private void Start()
		{
			CollectBones();
		}

		[Token(Token = "0x6000639")]
		[Address(RVA = "0x156A3D8", Offset = "0x156A3D8", Length = "0x350")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv24 = Spine.Unity.ISkeletonAnimation;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = UnityEngine.Object;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv65 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv94 = Il2CppMethodInfo;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv105 = Il2CppMethodInfo;\n\tv106 = \"il2cpp_codegen_initialize_runtime_metadata\"(v105, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv110 = Il2CppMethodInfo;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv219 = Il2CppMethodInfo;\n\tv220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv237 = Il2CppMethodInfo;\n\tv238 = \"il2cpp_codegen_initialize_runtime_metadata\"(v237, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv295 = Spine.Unity.UpdateBonesDelegate;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v295, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37CA8]) = v44;\nL_0036:\n\tgoto L_003B;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003B:\n\tv58 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv63 = v58 == 0;\n\tif (v63) goto L_0056;\n\tv73 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v73, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v73);\nL_0056:\n\tgoto L_005B;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v88, v80, v78, v74, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_005B:\n\tv103 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv108 = v103 == 0;\n\tif (v108) goto L_0072;\n\tv185 = new Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::.ctor(v185, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonGraphic::remove_OnRebuild(this.skeletonGraphic, v185);\nL_0072:\n\tv217 = this.skeletonAnimation == 0;\n\tif (v217) goto L_00AD;\n\tv228 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v228, this, Il2CppMethodInfo);\n\tgoto L_00B7;\n\tv300 = *([v296 @ X8_v8+B0]);\n\tv301 = v300 + 8;\n\tv303 = *([v339 @ X10_v18-8]);\n\tv345 = v303 == v297;\n\tif (v345) goto L_00AE;\n\tv325 = v340 - 1;\n\tv323 = v339 + 0x10;\n\tv305 = v340 != 1;\n\tif (v305) goto L_FFFFFFFF;\n\tv326 = 1;\n\tv327 = v216;\n\tv328 = 0xB349B4(v327, v297, v326, v171, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00B7;\nL_00AD:\n\treturn;\nL_00AE:\n\tv351 = *([v339 @ X10_v18]);\n\tv352 = v351 + 1;\n\tv353 = v352 << 4;\n\tv354 = v296 + v353;\n\tv355 = v354 + 0x138;\nL_00B7:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateLocal(this.skeletonAnimation, v228);\n\tv186 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v186, this, Il2CppMethodInfo);\n\tgoto L_00EF;\n\tv369 = *([v364 @ X8_v11+B0]);\n\tv370 = v369 + 8;\n\tv372 = *([v408 @ X10_v13-8]);\n\tv414 = v372 == v366;\n\tif (v414) goto L_00E6;\n\tv394 = v409 - 1;\n\tv392 = v408 + 0x10;\n\tv374 = v409 != 1;\n\tif (v374) goto L_FFFFFFFF;\n\tv395 = 3;\n\tv396 = v200;\n\tv397 = 0xB349B4(v396, v366, v395, v171, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00EF;\nL_00E6:\n\tv420 = *([v408 @ X10_v13]);\n\tv421 = v420 + 3;\n\tv422 = v421 << 4;\n\tv423 = v364 + v422;\n\tv424 = v423 + 0x138;\nL_00EF:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateWorld(this.skeletonAnimation, v186);\n\tv187 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v187, this, Il2CppMethodInfo);\n\tgoto L_012D;\n\tv436 = *([v433 @ X8_v14+B0]);\n\tv437 = v436 + 8;\n\tv439 = *([v475 @ X10_v8-8]);\n\tv481 = v439 == v434;\n\tif (v481) goto L_011C;\n\tv461 = v476 - 1;\n\tv459 = v475 + 0x10;\n\tv441 = v476 != 1;\n\tif (v441) goto L_FFFFFFFF;\n\tv462 = 5;\n\tv463 = v201;\n\tv464 = 0xB349B4(v463, v434, v462, v171, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_012D;\nL_011C:\n\tv487 = *([v475 @ X10_v8]);\n\tv488 = v487 + 5;\n\tv489 = v488 << 4;\n\tv490 = v433 + v489;\n\tv491 = v490 + 0x138;\nL_012D:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateComplete(this.skeletonAnimation, v187);\n\tthrow System.NullReferenceException;\n\treturn;\n// 194 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (skeletonRenderer != null)
			{
				SkeletonRenderer.SkeletonRendererDelegate value = HandleRendererReset;
				skeletonRenderer.OnRebuild -= value;
			}
			if (skeletonGraphic != null)
			{
				SkeletonGraphic.SkeletonRendererDelegate value2 = HandleRendererReset;
				skeletonGraphic.OnRebuild -= value2;
			}
			if (skeletonAnimation != null)
			{
				UpdateBonesDelegate value3 = UpdateLocal;
				skeletonAnimation.UpdateLocal -= value3;
				UpdateBonesDelegate value4 = UpdateWorld;
				skeletonAnimation.UpdateWorld -= value4;
				UpdateBonesDelegate value5 = UpdateComplete;
				skeletonAnimation.UpdateComplete -= value5;
			}
		}

		[Token(Token = "0x600063A")]
		[Address(RVA = "0x156B400", Offset = "0x156B400", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.OnReset == 0;\n\tif (v7) goto L_000F;\n\tSpine.Unity.SkeletonUtility+SkeletonUtilityDelegate::Invoke(this.OnReset);\nL_000F:\n\tSpine.Unity.SkeletonUtility::CollectBones(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleRendererReset(SkeletonRenderer r)
		{
			if (this.OnReset != null)
			{
				this.OnReset();
			}
			CollectBones();
		}

		[Token(Token = "0x600063B")]
		[Address(RVA = "0x156B42C", Offset = "0x156B42C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.OnReset == 0;\n\tif (v7) goto L_000F;\n\tSpine.Unity.SkeletonUtility+SkeletonUtilityDelegate::Invoke(this.OnReset);\nL_000F:\n\tSpine.Unity.SkeletonUtility::CollectBones(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleRendererReset(SkeletonGraphic g)
		{
			if (this.OnReset != null)
			{
				this.OnReset();
			}
			CollectBones();
		}

		[Token(Token = "0x600063C")]
		[Address(RVA = "0x156B458", Offset = "0x156B458", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, bone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, bone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37CA9]) = v37;\nL_001C:\n\tv46 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>::Contains(this.boneComponents, bone);\n\tv64 = v46 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_004B;\n\tv56 = this.boneComponents;\n\tv61 = v56._items;\n\tv49 = v56._version + 1;\n\tv56._version = v49;\n\tv97 = v56._size;\n\tv136 = v56._size < v61.Length;\n\tv91 = ~v136;\n\tif (v91) goto L_0043;\n\tv137 = v56._size + 1;\n\tv56._size = v137;\n\tv61[v97 @ X10_v5 (System.Int32)] = bone;\n\tgoto L_0045;\nL_0043:\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>::AddWithResize(v56, bone);\nL_0045:\n\tthis.needToReprocessBones = 1;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RegisterBone(SkeletonUtilityBone bone)
		{
			if (!boneComponents.Contains(bone))
			{
				List<SkeletonUtilityBone> list = boneComponents;
				SkeletonUtilityBone[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = bone;
				}
				else
				{
					list.Add(bone);
				}
				needToReprocessBones = true;
			}
		}

		[Token(Token = "0x600063D")]
		[Address(RVA = "0x156B52C", Offset = "0x156B52C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, bone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37CAA]) = v36;\nL_001E:\n\tv47 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>::Remove(this.boneComponents, bone);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UnregisterBone(SkeletonUtilityBone bone)
		{
			bool flag = boneComponents.Remove(bone);
		}

		[Token(Token = "0x600063E")]
		[Address(RVA = "0x156B584", Offset = "0x156B584", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, constraint, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, constraint, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37CAB]) = v37;\nL_001C:\n\tv46 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityConstraint>::Contains(this.constraintComponents, constraint);\n\tv64 = v46 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_004B;\n\tv56 = this.constraintComponents;\n\tv61 = v56._items;\n\tv49 = v56._version + 1;\n\tv56._version = v49;\n\tv97 = v56._size;\n\tv136 = v56._size < v61.Length;\n\tv91 = ~v136;\n\tif (v91) goto L_0043;\n\tv137 = v56._size + 1;\n\tv56._size = v137;\n\tv61[v97 @ X10_v5 (System.Int32)] = constraint;\n\tgoto L_0045;\nL_0043:\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityConstraint>::AddWithResize(v56, constraint);\nL_0045:\n\tthis.needToReprocessBones = 1;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RegisterConstraint(SkeletonUtilityConstraint constraint)
		{
			if (!constraintComponents.Contains(constraint))
			{
				List<SkeletonUtilityConstraint> list = constraintComponents;
				SkeletonUtilityConstraint[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = constraint;
				}
				else
				{
					list.Add(constraint);
				}
				needToReprocessBones = true;
			}
		}

		[Token(Token = "0x600063F")]
		[Address(RVA = "0x156B658", Offset = "0x156B658", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, constraint, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37CAC]) = v36;\nL_001E:\n\tv47 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityConstraint>::Remove(this.constraintComponents, constraint);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UnregisterConstraint(SkeletonUtilityConstraint constraint)
		{
			bool flag = constraintComponents.Remove(constraint);
		}

		[Token(Token = "0x6000640")]
		[Address(RVA = "0x156AD88", Offset = "0x156AD88", Length = "0x674")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0049;\n\tv26 = Spine.Unity.ISkeletonAnimation;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = Spine.Unity.ISkeletonComponent;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv381 = Il2CppMethodInfo;\n\tv382 = \"il2cpp_codegen_initialize_runtime_metadata\"(v381, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv441 = Il2CppMethodInfo;\n\tv442 = \"il2cpp_codegen_initialize_runtime_metadata\"(v441, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv465 = Il2CppMethodInfo;\n\tv466 = \"il2cpp_codegen_initialize_runtime_metadata\"(v465, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv563 = Il2CppMethodInfo;\n\tv564 = \"il2cpp_codegen_initialize_runtime_metadata\"(v563, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv603 = Il2CppMethodInfo;\n\tv604 = \"il2cpp_codegen_initialize_runtime_metadata\"(v603, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv609 = Il2CppMethodInfo;\n\tv610 = \"il2cpp_codegen_initialize_runtime_metadata\"(v609, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv614 = Il2CppMethodInfo;\n\tv615 = \"il2cpp_codegen_initialize_runtime_metadata\"(v614, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv620 = Il2CppMethodInfo;\n\tv621 = \"il2cpp_codegen_initialize_runtime_metadata\"(v620, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv627 = System.Collections.Generic.List`1<System.Object>;\n\tv628 = \"il2cpp_codegen_initialize_runtime_metadata\"(v627, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv633 = UnityEngine.Object;\n\tv634 = \"il2cpp_codegen_initialize_runtime_metadata\"(v633, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv650 = Il2CppMethodInfo;\n\tv651 = \"il2cpp_codegen_initialize_runtime_metadata\"(v650, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv673 = Il2CppMethodInfo;\n\tv674 = \"il2cpp_codegen_initialize_runtime_metadata\"(v673, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv689 = Spine.Unity.UpdateBonesDelegate;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v689, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37CAD]) = v46;\nL_0049:\n\tgoto L_0070;\n\tv383 = *([v53 @ X8_v5+B0]);\n\tv384 = v383 + 8;\n\tv386 = *([v454 @ X10_v45-8]);\n\tv459 = v386 == v56;\n\tif (v459) goto L_0068;\n\tv406 = v453 - 1;\n\tv408 = v454 + 0x10;\n\tv388 = v453 != 1;\n\tif (v388) goto L_FFFFFFFF;\n\tv409 = 1;\n\tv410 = v47;\n\tv411 = 0xB349B4(v410, v56, v409, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0070;\nL_0068:\n\tv468 = *([v454 @ X10_v45]);\n\tv469 = v468 + 1;\n\tv470 = v469 << 4;\n\tv471 = v53 + v470;\n\tv472 = v471 + 0x138;\nL_0070:\n\tv479 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv480 = v479 == 0;\n\tif (v480) goto L_02BF;\n\tgoto L_0080;\n\tv605 = \"il2cpp_codegen_runtime_class_init\"(v567, v477, v473, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0080:\n\tv330 = UnityEngine.Object::op_Inequality(this.boneRoot, 0);\n\tv612 = v330 == 0;\n\tif (v612) goto L_01C1;\n\tv322 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v322);\n\tv98 = v479.ikConstraints;\n\tv645 = v98.Count < 1;\n\tif (v645) goto L_00E0;\nL_00A0:\n\tv357 = v98.Items;\n\tv358 = v357[v77 @ X24_v15 (System.Int32)];\n\tv359 = v322._items;\n\tv312 = v322._version + 1;\n\tv322._version = v312;\n\tv668 = v322._size;\n\tv772 = v322._size < v359.Length;\n\tv773 = ~v772;\n\tif (v773) goto L_00D3;\n\tv811 = v322._size + 1;\n\tv322._size = v811;\n\tv359[v668 @ X10_v41 (System.Int32)] = v358.target;\n\tgoto L_00D4;\nL_00D3:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v322, v358.target);\nL_00D4:\n\tv77 = v77 + 1;\n\tv658 = v98.Count != v77;\n\tif (v658) goto L_00A0;\nL_00E0:\n\tv105 = v479.transformConstraints;\n\tv687 = v105.Count < 1;\n\tif (v687) goto L_0133;\nL_00F3:\n\tv361 = v105.Items;\n\tv362 = v361[v91 @ X23_v17 (System.Int32)];\n\tv363 = v322._items;\n\tv315 = v322._version + 1;\n\tv322._version = v315;\n\tv707 = v322._size;\n\tv827 = v322._size < v363.Length;\n\tv828 = ~v827;\n\tif (v828) goto L_0126;\n\tv848 = v322._size + 1;\n\tv322._size = v848;\n\tv363[v707 @ X10_v37 (System.Int32)] = v362.target;\n\tgoto L_0127;\nL_0126:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v322, v362.target);\nL_0127:\n\tv91 = v91 + 1;\n\tv697 = v105.Count != v91;\n\tif (v697) goto L_00F3;\nL_0133:\n\tv106 = this.boneComponents;\n\tv724 = v106._size < 1;\n\tif (v724) goto L_017B;\nL_014B:\n\tv327 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>::get_Item(v106, v100);\n\tv284 = v327.bone;\n\tv820 = v327.bone == 0;\n\tv821 = ~v820;\n\tif (v821) goto L_015C;\n\tSpine.Unity.SkeletonUtilityBone::DoUpdate(v327, v327.bone);\n\tv839 = v327.bone == 0;\n\tif (v839) goto L_016F;\nL_015C:\n\tv252 = v327.mode - 1;\n\tv220 = v252 == 0;\n\tv366 = this.hasOverrideBones | v220;\n\tthis.hasOverrideBones = v366;\n\tv858 = System.Collections.Generic.List`1<System.Object>::Contains(v322, v284);\n\tv897 = this.hasConstraints | v858;\n\tthis.hasConstraints = v897;\nL_016F:\n\tv100 = v100 + 1;\n\tv732 = v106._size != v100;\n\tif (v732) goto L_014B;\nL_017B:\n\tv367 = this.constraintComponents;\n\tv761 = v367._size < 0;\n\tv762 = v367._size == 0;\n\tv764 = v367._size ^ v367._size;\n\tv765 = v367._size & v764;\n\tv766 = v765 < 0;\n\tv767 = v761 == v766;\n\tv62 = ~v762;\n\tv768 = v767 & v62;\n\tv770 = this.hasConstraints | v768;\n\tthis.hasConstraints = v770;\n\tv771 = this.skeletonAnimation == 0;\n\tif (v771) goto L_02B4;\n\tv783 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v783, this, Il2CppMethodInfo);\n\tgoto L_0205;\n\tv859 = *([v844 @ X8_v26+B0]);\n\tv860 = v859 + 8;\n\tv862 = *([v911 @ X10_v32-8]);\n\tv916 = v862 == v846;\n\tif (v916) goto L_01FC;\n\tv882 = v910 - 1;\n\tv884 = v911 + 0x10;\n\tv864 = v910 != 1;\n\tif (v864) goto L_FFFFFFFF;\n\tv885 = 3;\n\tv886 = v757;\n\tv887 = 0xB349B4(v886, v846, v885, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0205;\nL_01C1:\n\tv368 = this.boneComponents;\n\tv304 = v368._version + 1;\n\tv368._size = 0;\n\tv368._version = v304;\n\tv142 = v368._size < 1;\n\tif (v142) goto L_01D9;\n\tSystem.Array::Clear(v368._items, 0, v368._size);\nL_01D9:\n\tv369 = this.constraintComponents;\n\tv545 = v369._version + 1;\n\tv369._size = 0;\n\tv369._version = v545;\n\tv515 = v369._size < 1;\n\tif (v515) goto L_02BF;\n\tSystem.Array::Clear(v369._items, 0, v369._size);\n\treturn;\nL_01FC:\n\tv922 = *([v911 @ X10_v32]);\n\tv923 = v922 + 3;\n\tv924 = v923 << 4;\n\tv925 = v844 + v924;\n\tv926 = v925 + 0x138;\nL_0205:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateWorld(this.skeletonAnimation, v783);\n\tv332 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v332, this, Il2CppMethodInfo);\n\tgoto L_023D;\n\tv940 = *([v936 @ X8_v29+B0]);\n\tv941 = v940 + 8;\n\tv943 = *([v980 @ X10_v27-8]);\n\tv985 = v943 == v937;\n\tif (v985) goto L_0234;\n\tv963 = v979 - 1;\n\tv965 = v980 + 0x10;\n\tv945 = v979 != 1;\n\tif (v945) goto L_FFFFFFFF;\n\tv966 = 5;\n\tv967 = v376;\n\tv968 = 0xB349B4(v967, v937, v966, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_023D;\nL_0234:\n\tv991 = *([v980 @ X10_v27]);\n\tv992 = v991 + 5;\n\tv993 = v992 << 4;\n\tv994 = v936 + v993;\n\tv995 = v994 + 0x138;\nL_023D:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateComplete(this.skeletonAnimation, v332);\n\tv1002 = ~this.hasOverrideBones;\n\tv1003 = ~v1002;\n\tif (v1003) goto L_0247;\n\tv807 = ~this.hasConstraints;\n\tif (v807) goto L_02B4;\nL_0247:\n\tv333 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v333, this, Il2CppMethodInfo);\n\tgoto L_027A;\n\tv1010 = *([v1006 @ X8_v34+B0]);\n\tv1011 = v1010 + 8;\n\tv1013 = *([v1050 @ X10_v22-8]);\n\tv1055 = v1013 == v1007;\n\tif (v1055) goto L_0271;\n\tv10\n// ... truncated")]
		public void CollectBones()
		{
			//IL_0329: Expected I4, but got O
			//IL_03e4: Expected O, but got I4
			//IL_0368: Expected I4, but got O
			//IL_0389: Expected I4, but got O
			Skeleton skeleton = skeletonComponent.Skeleton;
			if (skeleton == null)
			{
				return;
			}
			if (boneRoot != null)
			{
				List<object> list = new List<object>();
				ExposedList<IkConstraint> ikConstraints = skeleton.IkConstraints;
				if (ikConstraints.Count >= 1)
				{
					int num = 0;
					do
					{
						IkConstraint[] items = ikConstraints.Items;
						IkConstraint ikConstraint = items[num];
						object[] items2 = list._items;
						int version = list._version + 1;
						list._version = version;
						int count = list.Count;
						if (list.Count < items2.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items2[count] = ikConstraint.Target;
						}
						else
						{
							list.Add(ikConstraint.Target);
						}
						num++;
					}
					while (ikConstraints.Count != num);
				}
				ExposedList<TransformConstraint> transformConstraints = skeleton.TransformConstraints;
				if (transformConstraints.Count >= 1)
				{
					int num2 = 0;
					do
					{
						TransformConstraint[] items3 = transformConstraints.Items;
						TransformConstraint transformConstraint = items3[num2];
						object[] items4 = list._items;
						int version2 = list._version + 1;
						list._version = version2;
						int count2 = list.Count;
						if (list.Count < items4.Length)
						{
							int size2 = list.Count + 1;
							list._size = size2;
							items4[count2] = transformConstraint.Target;
						}
						else
						{
							list.Add(transformConstraint.Target);
						}
						num2++;
					}
					while (transformConstraints.Count != num2);
				}
				List<SkeletonUtilityBone> list2 = boneComponents;
				if (list2.Count >= 1)
				{
					int num3 = 0;
					do
					{
						SkeletonUtilityBone skeletonUtilityBone = list2[num3];
						SkeletonUtilityBone.UpdatePhase updatePhase = (SkeletonUtilityBone.UpdatePhase)skeletonUtilityBone.bone;
						if (skeletonUtilityBone.bone == null)
						{
							skeletonUtilityBone.DoUpdate((SkeletonUtilityBone.UpdatePhase)skeletonUtilityBone.bone);
							bool flag = skeletonUtilityBone.bone == null;
							updatePhase = (SkeletonUtilityBone.UpdatePhase)skeletonUtilityBone.bone;
							if (flag)
							{
								goto IL_0690;
							}
						}
						int num4 = (int)(skeletonUtilityBone.mode - 1);
						bool flag2 = num4 == 0;
						int num5 = ((hasOverrideBones || flag2) ? 1 : 0);
						hasOverrideBones = (byte)num5 != 0;
						bool flag3 = list.Contains(updatePhase);
						int num6 = ((hasConstraints || flag3) ? 1 : 0);
						hasConstraints = (byte)num6 != 0;
						goto IL_0690;
						IL_0690:
						num3++;
					}
					while (list2.Count != num3);
				}
				List<SkeletonUtilityConstraint> list3 = constraintComponents;
				bool flag4 = list3.Count < 0;
				bool flag5 = list3.Count == 0;
				int num7 = list3.Count ^ list3.Count;
				int num8 = list3.Count & num7;
				bool flag6 = num8 < 0;
				bool flag7 = flag4 == flag6;
				bool flag8 = !flag5;
				bool flag9 = flag7 && flag8;
				int num9 = ((hasConstraints || flag9) ? 1 : 0);
				hasConstraints = (byte)num9 != 0;
				if (skeletonAnimation != null)
				{
					UpdateBonesDelegate value = UpdateWorld;
					skeletonAnimation.UpdateWorld -= value;
					UpdateBonesDelegate value2 = UpdateComplete;
					skeletonAnimation.UpdateComplete -= value2;
					if (hasOverrideBones || hasConstraints)
					{
						UpdateBonesDelegate value3 = UpdateWorld;
						skeletonAnimation.UpdateWorld += value3;
						if (hasConstraints)
						{
							UpdateBonesDelegate value4 = UpdateComplete;
							skeletonAnimation.UpdateComplete += value4;
						}
					}
				}
				needToReprocessBones = false;
			}
			else
			{
				List<SkeletonUtilityBone> list4 = boneComponents;
				int version3 = list4._version + 1;
				list4._size = 0;
				list4._version = version3;
				if (list4.Count >= 1)
				{
					Array.Clear(list4._items, 0, list4.Count);
				}
				List<SkeletonUtilityConstraint> list5 = constraintComponents;
				int version4 = list5._version + 1;
				list5._size = 0;
				list5._version = version4;
				if (list5.Count >= 1)
				{
					Array.Clear(list5._items, 0, list5.Count);
				}
			}
		}

		[Token(Token = "0x6000641")]
		[Address(RVA = "0x156BEB4", Offset = "0x156BEB4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, anim, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, anim, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37CAE]) = v40;\nL_0017:\n\tv42 = ~this.needToReprocessBones;\n\tif (v42) goto L_001B;\n\tSpine.Unity.SkeletonUtility::CollectBones(this);\nL_001B:\n\tv47 = this.boneComponents;\n\tv48 = this.boneComponents == 0;\n\tif (v48) goto L_0053;\n\tv60 = v47._size < 1;\n\tif (v60) goto L_004A;\nL_0031:\n\tv96 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>::get_Item(this.boneComponents, v111);\n\tv111 = v111 + 1;\n\tv96.transformLerpComplete = 0;\n\tv78 = v47._size != v111;\n\tif (v78) goto L_0031;\nL_004A:\n\tSpine.Unity.SkeletonUtility::UpdateAllBones(this, 0);\n\treturn;\nL_0053:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateLocal(ISkeletonAnimation anim)
		{
			if (needToReprocessBones)
			{
				CollectBones();
			}
			List<SkeletonUtilityBone> list = boneComponents;
			if (boneComponents == null)
			{
				return;
			}
			if (list.Count >= 1)
			{
				int num = 0;
				do
				{
					SkeletonUtilityBone skeletonUtilityBone = boneComponents[num];
					num++;
					skeletonUtilityBone.transformLerpComplete = false;
				}
				while (list.Count != num);
			}
			UpdateAllBones(default(SkeletonUtilityBone.UpdatePhase));
		}

		[Token(Token = "0x6000642")]
		[Address(RVA = "0x156C050", Offset = "0x156C050", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, anim, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, anim, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37CAF]) = v38;\nL_0017:\n\tSpine.Unity.SkeletonUtility::UpdateAllBones(this, 1);\n\tv144 = this.constraintComponents;\n\tv56 = v144._size < 1;\n\tif (v56) goto L_004A;\nL_002D:\n\tv105 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityConstraint>::get_Item(v144, v114);\n\tv133 = Spine.Unity.SkeletonUtilityConstraint::DoUpdate(v105);\n\tv114 = v114 + 1;\n\tv87 = v144._size == v114;\n\tif (v87) goto L_004A;\n\tv144 = this.constraintComponents;\n\tv147 = this.constraintComponents == 0;\n\tv107 = ~v147;\n\tif (v107) goto L_002D;\n\tthrow System.NullReferenceException;\nL_004A:\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateWorld(ISkeletonAnimation anim)
		{
			UpdateAllBones(SkeletonUtilityBone.UpdatePhase.World);
			List<SkeletonUtilityConstraint> list = constraintComponents;
			if (list.Count < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				SkeletonUtilityConstraint skeletonUtilityConstraint = list[num];
				skeletonUtilityConstraint.DoUpdate();
				num++;
				if (list.Count != num)
				{
					list = constraintComponents;
					if (constraintComponents == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000643")]
		[Address(RVA = "0x156C0FC", Offset = "0x156C0FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonUtility::UpdateAllBones(this, 2);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateComplete(ISkeletonAnimation anim)
		{
			UpdateAllBones(SkeletonUtilityBone.UpdatePhase.Complete);
		}

		[Token(Token = "0x6000644")]
		[Address(RVA = "0x156BF70", Offset = "0x156BF70", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, phase, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, phase, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv59 = UnityEngine.Object;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, phase, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37CB0]) = v43;\nL_0021:\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, phase, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv57 = UnityEngine.Object::op_Equality(this.boneRoot, 0);\n\tv61 = v57 == 0;\n\tif (v61) goto L_002C;\n\tSpine.Unity.SkeletonUtility::CollectBones(this);\nL_002C:\n\tv64 = this.boneComponents;\n\tv65 = this.boneComponents == 0;\n\tif (v65) goto L_005A;\n\tv77 = v64._size < 1;\n\tif (v77) goto L_005A;\nL_0042:\n\tv112 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>::get_Item(this.boneComponents, v155);\n\tSpine.Unity.SkeletonUtilityBone::DoUpdate(v112, phase);\n\tv155 = v155 + 1;\n\tv81 = v64._size != v155;\n\tif (v81) goto L_0042;\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateAllBones(SkeletonUtilityBone.UpdatePhase phase)
		{
			if (boneRoot == null)
			{
				CollectBones();
			}
			List<SkeletonUtilityBone> list = boneComponents;
			if (boneComponents != null && list.Count >= 1)
			{
				int num = 0;
				do
				{
					SkeletonUtilityBone skeletonUtilityBone = boneComponents[num];
					skeletonUtilityBone.DoUpdate(phase);
					num++;
				}
				while (list.Count != num);
			}
		}

		[Token(Token = "0x6000645")]
		[Address(RVA = "0x156C104", Offset = "0x156C104", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = UnityEngine.GameObject;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = UnityEngine.Object;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv62 = \"SkeletonUtility-SkeletonRoot\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37CB1]) = v40;\nL_0022:\n\tgoto L_0027;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0027:\n\tv54 = UnityEngine.Object::op_Inequality(this.boneRoot, 0);\n\tv59 = v54 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_00AA;\n\tv68 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v68, \"SkeletonUtility-SkeletonRoot\");\n\tgoto L_0040;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v142, v108, v109, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0040:\n\tv152 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv154 = v152 == 0;\n\tif (v154) goto L_0050;\n\tv161 = UnityEngine.GameObject::AddComponent(v68);\n\tgoto L_0050;\nL_0050:\n\tv194 = UnityEngine.GameObject::get_transform(v68);\n\tthis.boneRoot = v194;\n\tv174 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v194, v174);\n\tgoto L_0073;\n\tv201 = UnityEngine.Vector3;\n\tv202 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, v170, v89, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv203 = 1;\n\t*([1A35519]) = v203;\nL_0073:\n\tUnityEngine.Transform::set_localPosition(this.boneRoot, v207.zeroVector);\n\tgoto L_008C;\n\tv212 = UnityEngine.Quaternion;\n\tv213 = \"il2cpp_codegen_initialize_runtime_metadata\"(v212, v171, v89, v24, v25, v26, v27, v28, v163, v167, v165, v32, v33, v34, v35, v36);\n\tv214 = 1;\n\t*([1A3551A]) = v214;\nL_008C:\n\tUnityEngine.Transform::set_localRotation(this.boneRoot, v219.identityQuaternion);\n\tgoto L_00A2;\n\tv224 = UnityEngine.Vector3;\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, v172, v89, v24, v25, v26, v27, v28, v164, v168, v166, v76, v33, v34, v35, v36);\n\tv226 = 1;\n\t*([1A35658]) = v226;\nL_00A2:\n\tUnityEngine.Transform::set_localScale(this.boneRoot, v97.oneVector);\nL_00AA:\n\treturn this.boneRoot;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Transform GetBoneRoot()
		{
			if (!(boneRoot != null))
			{
				GameObject gameObject = new GameObject("SkeletonUtility-SkeletonRoot");
				if (skeletonGraphic != null)
				{
					RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
				}
				Transform transform = (boneRoot = gameObject.transform);
				Transform parent = base.transform;
				transform.SetParent(parent);
				boneRoot.localPosition = Vector3.zero;
				boneRoot.localRotation = Quaternion.identity;
				boneRoot.localScale = Vector3.one;
			}
			return boneRoot;
		}

		[Token(Token = "0x6000646")]
		[Address(RVA = "0x156C320", Offset = "0x156C320", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = Spine.Unity.ISkeletonComponent;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, mode, pos, rot, sca, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A37CB2]) = v45;\nL_0019:\n\tv47 = Spine.Unity.SkeletonUtility::GetBoneRoot(this);\n\tgoto L_004A;\n\tv106 = *([v51 @ X8_v4+B0]);\n\tv107 = v106 + 8;\n\tv109 = *([v146 @ X10_v8-8]);\n\tv151 = v109 == v54;\n\tif (v151) goto L_0042;\n\tv129 = v145 - 1;\n\tv131 = v146 + 0x10;\n\tv111 = v145 != 1;\n\tif (v111) goto L_FFFFFFFF;\n\tv132 = 1;\n\tv133 = v48;\n\tv134 = 0xB349B4(v133, v54, v132, rot, sca, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004A;\nL_0042:\n\tv200 = *([v146 @ X10_v8]);\n\tv201 = v200 + 1;\n\tv202 = v201 << 4;\n\tv203 = v51 + v202;\n\tv204 = v203 + 0x138;\nL_004A:\n\tv100 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv209 = Spine.Skeleton::get_RootBone(v100);\n\tv211 = Spine.Unity.SkeletonUtility::SpawnBone(this, v209, this.boneRoot, mode, pos, rot, sca);\n\tSpine.Unity.SkeletonUtility::CollectBones(this);\n\treturn v211;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObject SpawnRoot(SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			Transform transform = GetBoneRoot();
			Skeleton skeleton = skeletonComponent.Skeleton;
			Bone rootBone = skeleton.RootBone;
			GameObject result = SpawnBone(rootBone, boneRoot, mode, pos, rot, sca);
			CollectBones();
			return result;
		}

		[Token(Token = "0x6000647")]
		[Address(RVA = "0x156C648", Offset = "0x156C648", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = Spine.Unity.ISkeletonComponent;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, mode, pos, rot, sca, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A37CB3]) = v45;\nL_0019:\n\tv47 = Spine.Unity.SkeletonUtility::GetBoneRoot(this);\n\tgoto L_004A;\n\tv106 = *([v51 @ X8_v4+B0]);\n\tv107 = v106 + 8;\n\tv109 = *([v146 @ X10_v8-8]);\n\tv151 = v109 == v54;\n\tif (v151) goto L_0042;\n\tv129 = v145 - 1;\n\tv131 = v146 + 0x10;\n\tv111 = v145 != 1;\n\tif (v111) goto L_FFFFFFFF;\n\tv132 = 1;\n\tv133 = v48;\n\tv134 = 0xB349B4(v133, v54, v132, rot, sca, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004A;\nL_0042:\n\tv200 = *([v146 @ X10_v8]);\n\tv201 = v200 + 1;\n\tv202 = v201 << 4;\n\tv203 = v51 + v202;\n\tv204 = v203 + 0x138;\nL_004A:\n\tv100 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv209 = Spine.Skeleton::get_RootBone(v100);\n\tv211 = Spine.Unity.SkeletonUtility::SpawnBoneRecursively(this, v209, this.boneRoot, mode, pos, rot, sca);\n\tSpine.Unity.SkeletonUtility::CollectBones(this);\n\treturn v211;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObject SpawnHierarchy(SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			Transform transform = GetBoneRoot();
			Skeleton skeleton = skeletonComponent.Skeleton;
			Bone rootBone = skeleton.RootBone;
			GameObject result = SpawnBoneRecursively(rootBone, boneRoot, mode, pos, rot, sca);
			CollectBones();
			return result;
		}

		[Token(Token = "0x6000648")]
		[Address(RVA = "0x156C754", Offset = "0x156C754", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = Spine.Unity.SkeletonUtility::SpawnBone(this, bone, parent, mode, pos, rot, sca);\n\tv41 = bone.children;\n\tv139 = v41.Count < 1;\n\tif (v139) goto L_0064;\nL_002D:\n\tv51 = v41.Items;\n\tv263 = UnityEngine.GameObject::get_transform(v37);\n\tv203 = Spine.Unity.SkeletonUtility::SpawnBoneRecursively(this, v51[v60 @ X28_v6 (System.Int32)], v263, mode, pos, rot, sca);\n\tv60 = v60 + 1;\n\tv184 = v41.Count != v60;\n\tif (v184) goto L_002D;\nL_0064:\n\treturn v37;\n\tv120 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObject SpawnBoneRecursively(Bone bone, Transform parent, SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			GameObject gameObject = SpawnBone(bone, parent, mode, pos, rot, sca);
			ExposedList<Bone> children = bone.Children;
			if (children.Count >= 1)
			{
				int num = 0;
				do
				{
					Bone[] items = children.Items;
					Transform parent2 = gameObject.transform;
					GameObject gameObject2 = SpawnBoneRecursively(items[num], parent2, mode, pos, rot, sca);
					num++;
				}
				while (children.Count != num);
			}
			return gameObject;
		}

		[Token(Token = "0x6000649")]
		[Address(RVA = "0x156C42C", Offset = "0x156C42C", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, bone, parent, mode, pos, rot, sca, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, bone, parent, mode, pos, rot, sca, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv160 = UnityEngine.GameObject;\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, bone, parent, mode, pos, rot, sca, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv168 = UnityEngine.Object;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, bone, parent, mode, pos, rot, sca, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37CB4]) = v56;\nL_0029:\n\tv61 = bone.data;\n\tv166 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v166, v61.name);\n\tgoto L_0041;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v230, v169, v170, mode, pos, rot, sca, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0041:\n\tv133 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv237 = v133 == 0;\n\tif (v237) goto L_0051;\n\tv242 = UnityEngine.GameObject::AddComponent(v166);\n\tgoto L_0051;\nL_0051:\n\tv134 = UnityEngine.GameObject::get_transform(v166);\n\tUnityEngine.Transform::SetParent(v134, parent);\n\tv135 = UnityEngine.GameObject::AddComponent(v166);\n\tv135.hierarchy = this;\n\tv135.mode = mode;\n\tv135.position = pos;\n\tv135.rotation = rot;\n\tv135.scale = sca;\n\tv135.zPosition = 1;\n\tSpine.Unity.SkeletonUtilityBone::Reset(v135);\n\tv135.bone = bone;\n\tv153 = bone.data;\n\tv135.valid = 1;\n\tv135.boneName = v153.name;\n\tv85 = mode != 1;\n\tif (v85) goto L_00B7;\n\tv254 = rot == 0;\n\tif (v254) goto L_0091;\n\tv266 = bone.arotation * 0.017453292f;\n\t// 135 MakeStruct v269 @ AGG15705CC_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v266 @ V2_v8 (System.Single)\n\tv270 = UnityEngine.Quaternion::Internal_FromEulerRad(v269);\n\tUnityEngine.Transform::set_localRotation(v134, v270);\nL_0091:\n\tv279 = pos == 0;\n\tif (v279) goto L_00A0;\n\tv154 = v135.bone;\n\tv283 = v154.x * this.positionScale;\n\tv282 = this.positionScale * v154.y;\n\t// 158 MakeStruct v280 @ AGG1570604_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v283 @ V0_v7 (System.Single), v282 @ V1_v7 (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(v134, v280);\nL_00A0:\n\tv155 = v135.bone;\n\t// 168 MakeStruct v255 @ AGG1570620_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v155.scaleX (System.Single), v155.scaleY (System.Single), 0\n\tUnityEngine.Transform::set_localScale(v134, v255);\nL_00B7:\n\treturn v166;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObject SpawnBone(Bone bone, Transform parent, SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			BoneData data = bone.Data;
			GameObject gameObject = new GameObject(data.Name);
			if (skeletonGraphic != null)
			{
				RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			}
			Transform transform = gameObject.transform;
			transform.SetParent(parent);
			SkeletonUtilityBone skeletonUtilityBone = gameObject.AddComponent<SkeletonUtilityBone>();
			skeletonUtilityBone.hierarchy = this;
			skeletonUtilityBone.mode = mode;
			skeletonUtilityBone.position = pos;
			skeletonUtilityBone.rotation = rot;
			skeletonUtilityBone.scale = sca;
			skeletonUtilityBone.zPosition = true;
			skeletonUtilityBone.Reset();
			skeletonUtilityBone.bone = bone;
			BoneData data2 = bone.Data;
			skeletonUtilityBone.valid = true;
			skeletonUtilityBone.boneName = data2.Name;
			if (mode == SkeletonUtilityBone.Mode.Override)
			{
				if (rot)
				{
					float z = bone.AppliedRotation * ((float)Math.PI / 180f);
					Vector3 vector = default(Vector3);
					vector.x = 0f;
					vector.y = 0f;
					vector.z = z;
					Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
					transform.localRotation = localRotation;
				}
				if (pos)
				{
					Bone bone2 = skeletonUtilityBone.bone;
					float x = bone2.X * PositionScale;
					float y = PositionScale * bone2.Y;
					Vector3 localPosition = default(Vector3);
					localPosition.x = x;
					localPosition.y = y;
					localPosition.z = 0f;
					transform.localPosition = localPosition;
				}
				Bone bone3 = skeletonUtilityBone.bone;
				Vector3 localScale = default(Vector3);
				localScale.x = bone3.ScaleX;
				localScale.y = bone3.ScaleY;
				localScale.z = 0f;
				transform.localScale = localScale;
			}
			return gameObject;
		}

		[Token(Token = "0x600064A")]
		[Address(RVA = "0x156C990", Offset = "0x156C990", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityConstraint>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37CB5]) = v50;\nL_0026:\n\tv52 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityBone>::.ctor(v52);\n\tthis.boneComponents = v52;\n\tv62 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityConstraint>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonUtilityConstraint>::.ctor(v62);\n\tthis.constraintComponents = v62;\n\tthis.positionScale = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonUtility()
		{
			List<SkeletonUtilityBone> list = new List<SkeletonUtilityBone>();
			boneComponents = list;
			List<SkeletonUtilityConstraint> list2 = new List<SkeletonUtilityConstraint>();
			constraintComponents = list2;
			positionScale = 1f;
		}
	}
}
