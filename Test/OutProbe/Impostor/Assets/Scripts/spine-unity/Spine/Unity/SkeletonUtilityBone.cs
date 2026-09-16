using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[AddComponentMenu("Spine/SkeletonUtilityBone")]
	[ExecuteAlways]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonUtilityBone")]
	[Token(Token = "0x200009B")]
	public class SkeletonUtilityBone : MonoBehaviour
	{
		[Token(Token = "0x200009C")]
		public enum Mode
		{
			[Token(Token = "0x40003DD")]
			Follow = 0,
			[Token(Token = "0x40003DE")]
			Override = 1
		}

		[Token(Token = "0x200009D")]
		public enum UpdatePhase
		{
			[Token(Token = "0x40003E0")]
			Local = 0,
			[Token(Token = "0x40003E1")]
			World = 1,
			[Token(Token = "0x40003E2")]
			Complete = 2
		}

		[Token(Token = "0x40003CD")]
		[FieldOffset(Offset = "0x20")]
		public string boneName;

		[Token(Token = "0x40003CE")]
		[FieldOffset(Offset = "0x28")]
		public Transform parentReference;

		[Token(Token = "0x40003CF")]
		[FieldOffset(Offset = "0x30")]
		public Mode mode;

		[Token(Token = "0x40003D0")]
		[FieldOffset(Offset = "0x34")]
		public bool position;

		[Token(Token = "0x40003D1")]
		[FieldOffset(Offset = "0x35")]
		public bool rotation;

		[Token(Token = "0x40003D2")]
		[FieldOffset(Offset = "0x36")]
		public bool scale;

		[Token(Token = "0x40003D3")]
		[FieldOffset(Offset = "0x37")]
		public bool zPosition;

		[Range(0f, 1f)]
		[Token(Token = "0x40003D4")]
		[FieldOffset(Offset = "0x38")]
		public float overrideAlpha;

		[Token(Token = "0x40003D5")]
		[FieldOffset(Offset = "0x40")]
		public SkeletonUtility hierarchy;

		[NonSerialized]
		[Token(Token = "0x40003D6")]
		[FieldOffset(Offset = "0x48")]
		public Bone bone;

		[NonSerialized]
		[Token(Token = "0x40003D7")]
		[FieldOffset(Offset = "0x50")]
		public bool transformLerpComplete;

		[NonSerialized]
		[Token(Token = "0x40003D8")]
		[FieldOffset(Offset = "0x51")]
		public bool valid;

		[Token(Token = "0x40003D9")]
		[FieldOffset(Offset = "0x58")]
		private Transform cachedTransform;

		[Token(Token = "0x40003DA")]
		[FieldOffset(Offset = "0x60")]
		private Transform skeletonTransform;

		[Token(Token = "0x40003DB")]
		[FieldOffset(Offset = "0x68")]
		private bool incompatibleTransformMode;

		[Token(Token = "0x170001B1")]
		public bool IncompatibleTransformMode
		{
			[Token(Token = "0x600064F")]
			[Address(RVA = "0x156CB24", Offset = "0x156CB24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.incompatibleTransformMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IncompatibleTransformMode;
			}
		}

		[Token(Token = "0x6000650")]
		[Address(RVA = "0x156C840", Offset = "0x156C840", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv55 = Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37CB6]) = v42;\nL_001D:\n\tthis.bone = 0;\n\tv45 = UnityEngine.Component::get_transform(this);\n\tthis.cachedTransform = v45;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v49, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tv61 = UnityEngine.Object::op_Inequality(this.hierarchy, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_0064;\n\tv66 = Spine.Unity.SkeletonUtility::get_IsValid(this.hierarchy);\n\tthis.valid = v66;\n\tv96 = v66 == 0;\n\tif (v96) goto L_006C;\n\tv125 = UnityEngine.Component::get_transform(this.hierarchy);\n\tthis.skeletonTransform = v125;\n\tv79 = new Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate();\n\tSpine.Unity.SkeletonUtility+SkeletonUtilityDelegate::.ctor(v79, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonUtility::remove_OnReset(this.hierarchy, v79);\n\tv80 = new Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate();\n\tSpine.Unity.SkeletonUtility+SkeletonUtilityDelegate::.ctor(v80, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonUtility::add_OnReset(this.hierarchy, v80);\n\tSpine.Unity.SkeletonUtilityBone::DoUpdate(this, 0);\n\treturn;\nL_0064:\n\tthis.valid = 0;\nL_006C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			bone = null;
			Transform transform = base.transform;
			cachedTransform = transform;
			if (hierarchy != null)
			{
				if (valid = hierarchy.IsValid)
				{
					Transform transform2 = hierarchy.transform;
					skeletonTransform = transform2;
					SkeletonUtility.SkeletonUtilityDelegate value = HandleOnReset;
					hierarchy.OnReset -= value;
					SkeletonUtility.SkeletonUtilityDelegate value2 = HandleOnReset;
					hierarchy.OnReset += value2;
					DoUpdate(default(UpdatePhase));
				}
			}
			else
			{
				valid = false;
			}
		}

		[Token(Token = "0x6000651")]
		[Address(RVA = "0x156CB2C", Offset = "0x156CB2C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37CB7]) = v38;\nL_0021:\n\tgoto L_0026;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv52 = UnityEngine.Object::op_Equality(this.hierarchy, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_0036;\n\tv62 = UnityEngine.Component::get_transform(this);\n\tv68 = UnityEngine.Component::GetComponentInParent(v62);\n\tthis.hierarchy = v68;\n\tgoto L_003B;\nL_0036:\n\tv72 = this.hierarchy;\nL_003B:\n\tgoto L_0040;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v74, v65, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0040:\n\tv101 = UnityEngine.Object::op_Equality(v72, 0);\n\tv103 = v101 == 0;\n\tif (v103) goto L_004E;\n\treturn;\nL_004E:\n\tSpine.Unity.SkeletonUtility::RegisterBone(this.hierarchy, this);\n\tv87 = new Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate();\n\tSpine.Unity.SkeletonUtility+SkeletonUtilityDelegate::.ctor(v87, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonUtility::add_OnReset(this.hierarchy, v87);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			SkeletonUtility skeletonUtility;
			if (hierarchy == null)
			{
				Transform transform = base.transform;
				skeletonUtility = (hierarchy = transform.GetComponentInParent<SkeletonUtility>());
			}
			else
			{
				skeletonUtility = hierarchy;
			}
			if (!(skeletonUtility == null))
			{
				hierarchy.RegisterBone(this);
				SkeletonUtility.SkeletonUtilityDelegate value = HandleOnReset;
				hierarchy.OnReset += value;
			}
		}

		[Token(Token = "0x6000652")]
		[Address(RVA = "0x156CC64", Offset = "0x156CC64", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonUtilityBone::Reset(this);\n\treturn;\n")]
		private void HandleOnReset()
		{
			Reset();
		}

		[Token(Token = "0x6000653")]
		[Address(RVA = "0x156CC68", Offset = "0x156CC68", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37CB8]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Inequality(this.hierarchy, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_0047;\n\tv63 = new Spine.Unity.SkeletonUtility+SkeletonUtilityDelegate();\n\tSpine.Unity.SkeletonUtility+SkeletonUtilityDelegate::.ctor(v63, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonUtility::remove_OnReset(this.hierarchy, v63);\n\tSpine.Unity.SkeletonUtility::UnregisterBone(this.hierarchy, this);\n\treturn;\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (hierarchy != null)
			{
				SkeletonUtility.SkeletonUtilityDelegate value = HandleOnReset;
				hierarchy.OnReset -= value;
				hierarchy.UnregisterBone(this);
			}
		}

		[Token(Token = "0x6000654")]
		[Address(RVA = "0x156B6B0", Offset = "0x156B6B0", Length = "0x804")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = UnityEngine.Debug;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, phase, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv51 = UnityEngine.Object;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, phase, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv66 = \"Bone not found: \";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, phase, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37CB9]) = v47;\nL_001E:\n\tv49 = ~this.valid;\n\tif (v49) goto L_00B0;\n\tv67 = Spine.Unity.SkeletonUtility::get_Skeleton(this.hierarchy);\n\tv683 = this.bone;\n\tv547 = this.bone == 0;\n\tif (v547) goto L_00B4;\nL_0029:\n\tv686 = ~v683.active;\n\tif (v686) goto L_0368;\n\tv512 = this.hierarchy;\n\tv779 = Spine.Skeleton::get_ScaleY(v67);\n\tv781 = v67.scaleX * v779;\n\tv241 = v781 < 0;\n\tif (v241) goto L_FFFFFFFF;\n\tgoto L_004F;\nL_004F:\n\tv324 = this.mode == 1;\n\tif (v324) goto L_00E4;\n\tv805 = this.mode == 0;\n\tv758 = ~v805;\n\tif (v758) goto L_0368;\n\tv759 = phase == 0;\n\tif (v759) goto L_01B2;\n\tv513 = phase - 1;\n\tv816 = v513 < 2;\n\tv353 = ~v816;\n\tif (v353) goto L_0368;\n\tv430 = this.bone;\n\tv836 = ~v430.appliedValid;\n\tv837 = ~v836;\n\tif (v837) goto L_006F;\n\tSpine.Bone::UpdateAppliedTransform(v430);\nL_006F:\n\tv850 = ~this.position;\n\tif (v850) goto L_0081;\n\tv514 = this.bone;\n\tv878 = v512.positionScale * v514.ay;\n\tv880 = v512.positionScale * v514.ax;\n\t// 126 MakeStruct v875 @ AGG156F7D4_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v880 @ V0_v95 (System.Single), v878 @ V1_v78 (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(this.cachedTransform, v875);\nL_0081:\n\tv885 = ~this.rotation;\n\tif (v885) goto L_0345;\n\tv515 = this.bone;\n\tv516 = v515.data;\n\tv432 = Spine.SpineSkeletonExtensions::InheritsRotation(v516.transformMode);\n\tv1023 = v432 == 0;\n\tif (v1023) goto L_0316;\n\tv517 = this.bone;\n\tv1066 = v517.arotation * 0.017453292f;\n\t// 153 MakeStruct v190 @ AGG156F824_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v1066 @ V2_v63 (System.Single)\n\tv405 = UnityEngine.Quaternion::Internal_FromEulerRad(v190);\n\tUnityEngine.Transform::set_localRotation(this.cachedTransform, v405);\n\tgoto L_0345;\nL_00B0:\n\tSpine.Unity.SkeletonUtilityBone::Reset(this);\n\treturn;\nL_00B4:\n\tv434 = System.String::IsNullOrEmpty(this.boneName);\n\tv777 = v434 == 0;\n\tv760 = ~v777;\n\tif (v760) goto L_0368;\n\tv680 = Spine.Skeleton::FindBone(v67, this.boneName);\n\tthis.bone = v680;\n\tv791 = v680 == 0;\n\tv682 = ~v791;\n\tif (v682) goto L_0029;\n\tv799 = System.String::Concat(\"Bone not found: \", this.boneName);\n\tgoto L_00E1;\n\tv807 = v673;\n\tv808 = \"il2cpp_codegen_runtime_class_init\"(v807, v795, v797, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00E1:\n\tUnityEngine.Debug::LogError(v799, this);\n\treturn;\nL_00E4:\n\tv806 = ~this.transformLerpComplete;\n\tv761 = ~v806;\n\tif (v761) goto L_0368;\n\tgoto L_00F3;\n\tv819 = \"il2cpp_codegen_runtime_class_init\"(v812, v366, v169, v31, v32, v33, v34, v35, v403, v258, v38, v39, v40, v41, v42, v43);\nL_00F3:\n\tv435 = UnityEngine.Object::op_Equality(this.parentReference, 0);\n\tv834 = v435 == 0;\n\tif (v834) goto L_01E9;\n\tv846 = ~this.position;\n\tif (v846) goto L_0122;\n\tv406 = UnityEngine.Transform::get_localPosition(this.cachedTransform);\n\tv521 = this.bone;\n\t// 265 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv978 = v406 / v512.positionScale;\n\tv979 = UnityEngine.Mathf::Min(this.overrideAlpha, 1f);\n\tv866 = this.overrideAlpha < 0;\n\tv859 = ~v866;\n\tv858 = ~v859;\n\tif (v858) goto L_011D;\n\tgoto L_011D;\nL_011D:\n\tv1049 = v978 - v521.x;\n\tv1050 = v1049 * v976;\n\tv869 = v521.x + v1050;\n\tv521.x = v869;\nL_0122:\n\tv873 = ~this.rotation;\n\tif (v873) goto L_018A;\n\tv522 = this.bone;\n\tv981 = UnityEngine.Transform::get_localRotation(this.cachedTransform);\n\tv998 = UnityEngine.Quaternion::Internal_ToEulerRad(v981);\n\tv1035 = v998 * 57.29578f;\n\tv1036 = v998.y * 57.29578f;\n\tv1037 = v998.z * 57.29578f;\n\t// 315 MakeStruct v141 @ AGG156F9C4_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1035 @ V0_v46 (System.Single), v1036 @ V1_v40 (System.Single), v1037 @ V2_v30 (System.Single)\n\tv1038 = UnityEngine.Quaternion::Internal_MakePositive(v141);\n\tv1054 = v1038.z - v522.rotation;\n\tv1057 = v1054 / 0x43B40000;\n\tv1058 = UnityEngine.Mathf::Floor(v1057);\n\tv1070 = v1058 * 0xC3B40000;\n\tv1072 = v1054 + v1070;\n\tv233 = UnityEngine.Mathf::Min(v1072, 360f);\n\tv1090 = v1072 < 0;\n\tv1097 = ~v1090;\n\tv1098 = ~v1097;\n\tif (v1098) goto L_FFFFFFFF;\n\tgoto L_015F;\nL_015F:\n\tv1140 = v233 - 0x43340000;\n\tv1141 = v1140 < 0;\n\tv1142 = v1140 == 0;\n\tv1143 = v233 ^ 0x43340000;\n\tv1144 = v233 ^ v1140;\n\tv1145 = v1143 & v1144;\n\tv1146 = v1145 < 0;\n\tv541 = this.bone;\n\tv158 = UnityEngine.Mathf::Min(this.overrideAlpha, 1f);\n\tv424 = v233 + 0xC3B40000;\n\tv1158 = v1141 == v1146;\n\tv136 = ~v1142;\n\tv1159 = v1158 & v136;\n\tv1160 = ~v1159;\n\tif (v1160) goto L_FFFFFFFF;\n\tgoto L_0176;\nL_0176:\n\tv339 = this.overrideAlpha < 0;\n\tv255 = ~v339;\n\tv246 = ~v255;\n\tif (v246) goto L_FFFFFFFF;\n\tgoto L_0185;\nL_0185:\n\tv1209 = v279 * v424;\n\tv887 = v522.rotation + v1209;\n\tv541.rotation = v887;\n\tv541.arotation = v887;\nL_018A:\n\tv890 = ~this.scale;\n\tif (v890) goto L_035D;\n\tv409 = UnityEngine.Transform::get_localScale(this.cachedTransform);\n\tv524 = this.bone;\n\tv1039 = UnityEngine.Mathf::Min(this.overrideAlpha, 1f);\n\tv951 = this.overrideAlpha < 0;\n\tv937 = ~v951;\n\tv935 = ~v937;\n\tif (v935) goto L_01AC;\n\tgoto L_01AC;\nL_01AC:\n\tv1099 = v409 - v524.scaleX;\n\tv1100 = v1099 * v976;\n\tv958 = v524.scaleX + v1100;\n\tv524.scaleX = v958;\n\tgoto L_035D;\nL_01B2:\n\tv818 = ~this.position;\n\tif (v818) goto L_01C4;\n\tv525 = this.bone;\n\tv825 = v512.positionScale * v525.y;\n\tv827 = v512.positionScale * v525.x;\n\t// 449 MakeStruct v822 @ AGG156FAC0_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v827 @ V0_v79 (System.Single), v825 @ V1_v65 (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(this.cachedTransform, v822);\nL_01C4:\n\tv832 = ~this.rotation;\n\tif (v832) goto L_0308;\n\tv526 = this.bone;\n\tv527 = v526.data;\n\tv442 = Spine.SpineSkeletonExtensions::InheritsRotation(v527.transformMode);\n\tv921 = v442 == 0;\n\tif (v921) goto L_02D9;\n\tv528 = this.bone;\n\tv988 = v528.rotation * 0.017453292f;\n\t// 476 MakeStruct v127 @ AGG156FB10_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v988 @ V2_v50 (System.Single)\n\tv411 = UnityEngine.Quaternion::Internal_FromEulerRad(v127);\n\tUnityEngine.Transform::set_localRotation(this.cachedTransform, v411);\n\tgoto L_0308;\nL_01E9:\n\tv847 = ~this.transformLerpComplete;\n\tv762 = ~v847;\n\tif (v762) goto L_0368;\n\tv874 = ~this.position;\n\tif (v874) goto L_0220;\n\tv412 = UnityEngine.Transform::get_position(this.cachedTransform);\n\tv413 = UnityEngine.Transform::InverseTransformPoint(this.parentReference, v412);\n\tv531 = this.bone;\n\t// 519 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv1061 = v413 / v512.positionScale;\n\tv1062 = UnityEngine.Mathf::Min(this.overrideAlpha, 1f);\n\tv904 = this.overrideAlpha < 0;\n\tv897 = ~v904;\n\tv896 = ~v897;\n\tif (v896) goto L_021B;\n\tgoto L_021B;\nL_021B:\n\tv1129 = v1061 - v531.x;\n\tv1130 = v1129 * v976;\n\tv907 = v531.x + v1130;\n\tv531.x = v907;\nL_0220:\n\tv911 = ~this.rotation;\n\tif (v911) goto L_02AE;\n\tv532 = this.bone;\n\tgoto L_023C;\n\tv1000 = UnityEngine.Vector3;\n\tv1001 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1000, v380, v170, v31, v32, v33, v34, v35, v414, v269, v223, v202, v149, v156, v42, v43);\n\tv1002 = 1;\n\t*([1A3559C]) = v1002;\nL_023C:\n\tv415 = UnityEngine.Transform::get_up(this.cachedTransform);\n\tv1079 = UnityEngine.Transform::InverseTransformDirection(this.parentReference, v415);\n\tv1112 = UnityEngine.Quaternion::LookRotation(v533.forwardVector, v1079);\n\tv1135 = UnityEngine.Quaternion::Internal_ToEulerRad(v1112);\n\tv1152 = v1135 * 57.29578f;\n\tv1153 = v1135.y * 57.29578f;\n\tv1154 = v1135.z * 57.29578f;\n\t// 607 MakeStruct v101 @ AGG156FC50_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1152 @ V0_v20 (System.Single), v1153 @ V1_v18 (System.Single), v1154 @ V2_v14 (System.Single)\n\tv1155 = UnityEngine.Quaternion::Internal_MakePositive(v101);\n\tv1164 = v1155.z - v532.rotation;\n\tv1167 = v1164 / 0x43B40\n// ... truncated")]
		public void DoUpdate(UpdatePhase phase)
		{
			//IL_0ff7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ffc: Expected I4, but got Unknown
			//IL_1009: Expected O, but got F4
			//IL_11c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_11cd: Expected I4, but got Unknown
			//IL_11da: Expected O, but got F4
			if (valid)
			{
				Skeleton skeleton = hierarchy.Skeleton;
				Bone bone = this.bone;
				if (this.bone == null)
				{
					if (string.IsNullOrEmpty(boneName))
					{
						return;
					}
					Bone bone2 = (this.bone = skeleton.FindBone(boneName));
					bool flag = bone2 == null;
					bool flag2 = !flag;
					bone = bone2;
					if (!flag2)
					{
						string message = "Bone not found: " + boneName;
						Debug.LogError(message, this);
						return;
					}
				}
				if (!bone.Active)
				{
					return;
				}
				SkeletonUtility skeletonUtility = hierarchy;
				float scaleY = skeleton.ScaleY;
				float num = skeleton.ScaleX * scaleY;
				float num2 = ((num < 0f) ? (-1f) : 1f);
				if (mode != Mode.Override)
				{
					if (mode != Mode.Follow)
					{
						return;
					}
					float x4;
					float y4;
					if (phase != UpdatePhase.Local)
					{
						int num3 = (int)(phase - 1);
						if (num3 >= 2)
						{
							return;
						}
						Bone bone3 = this.bone;
						if (!bone3.appliedValid)
						{
							bone3.Update();
						}
						if (position)
						{
							Bone bone4 = this.bone;
							float y = skeletonUtility.PositionScale * bone4.AY;
							float x = skeletonUtility.PositionScale * bone4.AX;
							Vector3 localPosition = default(Vector3);
							localPosition.x = x;
							localPosition.y = y;
							localPosition.z = 0f;
							cachedTransform.localPosition = localPosition;
						}
						if (rotation)
						{
							Bone bone5 = this.bone;
							BoneData data = bone5.Data;
							if (data.TransformMode.InheritsRotation())
							{
								Bone bone6 = this.bone;
								float z = bone6.AppliedRotation * ((float)Math.PI / 180f);
								Vector3 vector = default(Vector3);
								vector.x = 0f;
								vector.y = 0f;
								vector.z = z;
								Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
								cachedTransform.localRotation = localRotation;
							}
							else
							{
								Quaternion quaternion = skeletonTransform.rotation;
								Vector3 vector2 = Quaternion.Internal_ToEulerRad(quaternion);
								float x2 = vector2.x * 57.29578f;
								float y2 = vector2.y * 57.29578f;
								float z2 = vector2.z * 57.29578f;
								Vector3 euler = default(Vector3);
								euler.x = x2;
								euler.y = y2;
								euler.z = z2;
								Vector3 vector3 = Quaternion.Internal_MakePositive(euler);
								float worldRotationX = this.bone.WorldRotationX;
								float num4 = num2 * worldRotationX;
								float num5 = vector3.z + num4;
								float x3 = vector3.x * ((float)Math.PI / 180f);
								float y3 = vector3.y * ((float)Math.PI / 180f);
								float z3 = num5 * ((float)Math.PI / 180f);
								Vector3 vector4 = default(Vector3);
								vector4.x = x3;
								vector4.y = y3;
								vector4.z = z3;
								Quaternion quaternion2 = Quaternion.Euler(vector4 * 57.29578f);
								cachedTransform.rotation = quaternion2;
							}
						}
						if (!scale)
						{
							return;
						}
						Bone bone7 = this.bone;
						x4 = bone7.AScaleX;
						y4 = bone7.AScaleY;
					}
					else
					{
						if (position)
						{
							Bone bone8 = this.bone;
							float y5 = skeletonUtility.PositionScale * bone8.Y;
							float x5 = skeletonUtility.PositionScale * bone8.X;
							Vector3 localPosition2 = default(Vector3);
							localPosition2.x = x5;
							localPosition2.y = y5;
							localPosition2.z = 0f;
							cachedTransform.localPosition = localPosition2;
						}
						if (rotation)
						{
							Bone bone9 = this.bone;
							BoneData data2 = bone9.Data;
							if (data2.TransformMode.InheritsRotation())
							{
								Bone bone10 = this.bone;
								float z4 = bone10.Rotation * ((float)Math.PI / 180f);
								Vector3 vector5 = default(Vector3);
								vector5.x = 0f;
								vector5.y = 0f;
								vector5.z = z4;
								Quaternion localRotation2 = Quaternion.Euler(vector5 * 57.29578f);
								cachedTransform.localRotation = localRotation2;
							}
							else
							{
								Quaternion quaternion3 = skeletonTransform.rotation;
								Vector3 vector6 = Quaternion.Internal_ToEulerRad(quaternion3);
								float x6 = vector6.x * 57.29578f;
								float y6 = vector6.y * 57.29578f;
								float z5 = vector6.z * 57.29578f;
								Vector3 euler2 = default(Vector3);
								euler2.x = x6;
								euler2.y = y6;
								euler2.z = z5;
								Vector3 vector7 = Quaternion.Internal_MakePositive(euler2);
								float worldRotationX2 = this.bone.WorldRotationX;
								float num6 = num2 * worldRotationX2;
								float num7 = vector7.z + num6;
								float x7 = vector7.x * ((float)Math.PI / 180f);
								float y7 = vector7.y * ((float)Math.PI / 180f);
								float z6 = num7 * ((float)Math.PI / 180f);
								Vector3 vector8 = default(Vector3);
								vector8.x = x7;
								vector8.y = y7;
								vector8.z = z6;
								Quaternion quaternion4 = Quaternion.Euler(vector8 * 57.29578f);
								cachedTransform.rotation = quaternion4;
							}
						}
						if (!scale)
						{
							return;
						}
						Bone bone11 = this.bone;
						x4 = bone11.ScaleX;
						y4 = bone11.ScaleY;
					}
					Vector3 localScale = default(Vector3);
					localScale.x = x4;
					localScale.y = y4;
					localScale.z = 1f;
					cachedTransform.localScale = localScale;
					bool flag3 = BoneTransformModeIncompatible(this.bone);
					incompatibleTransformMode = flag3;
				}
				else
				{
					if (transformLerpComplete)
					{
						return;
					}
					object obj = default(object);
					if (parentReference == null)
					{
						if (position)
						{
							Vector3 localPosition3 = cachedTransform.localPosition;
							Bone bone12 = this.bone;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
							float num8 = localPosition3.x / skeletonUtility.PositionScale;
							float num9 = Mathf.Min(overrideAlpha, 1f);
							if (!(overrideAlpha < 0f))
							{
							}
							float num10 = num8 - bone12.X;
							float num11 = num10 * (float)obj;
							float x8 = bone12.X + num11;
							bone12.X = x8;
						}
						if (rotation)
						{
							Bone bone13 = this.bone;
							Quaternion localRotation3 = cachedTransform.localRotation;
							Vector3 vector9 = Quaternion.Internal_ToEulerRad(localRotation3);
							float x9 = vector9.x * 57.29578f;
							float y8 = vector9.y * 57.29578f;
							float z7 = vector9.z * 57.29578f;
							Vector3 euler3 = default(Vector3);
							euler3.x = x9;
							euler3.y = y8;
							euler3.z = z7;
							float num12 = Quaternion.Internal_MakePositive(euler3).z - bone13.Rotation;
							float f = num12 / 360f;
							float num13 = Mathf.Floor(f);
							float num14 = num13 * -360f;
							float num15 = num12 + num14;
							float num16 = Mathf.Min(num15, 360f);
							if (num15 < 0f)
							{
								num16 = 0f;
							}
							float num17 = num16 - 180f;
							bool flag4 = num17 < 0f;
							bool flag5 = num17 == 0f;
							int num18 = num16 ^ 0x43340000;
							object obj2 = num16 ^ num17;
							int num19 = (int)(num18 & (nint)obj2);
							bool flag6 = num19 < 0;
							Bone bone14 = this.bone;
							float num20 = Mathf.Min(overrideAlpha, 1f);
							float num21 = num16 + -360f;
							bool flag7 = flag4 == flag6;
							bool flag8 = !flag5;
							if (!(flag7 && flag8))
							{
								num21 = num16;
							}
							float num22 = ((overrideAlpha < 0f) ? 0f : num20);
							float num23 = num22 * num21;
							float appliedRotation = (bone14.Rotation = bone13.Rotation + num23);
							bone14.AppliedRotation = appliedRotation;
						}
						if (scale)
						{
							Vector3 localScale2 = cachedTransform.localScale;
							Bone bone15 = this.bone;
							float num25 = Mathf.Min(overrideAlpha, 1f);
							if (!(overrideAlpha < 0f))
							{
							}
							float num26 = localScale2.x - bone15.ScaleX;
							float num27 = num26 * (float)obj;
							float scaleX = bone15.ScaleX + num27;
							bone15.ScaleX = scaleX;
						}
					}
					else
					{
						if (transformLerpComplete)
						{
							return;
						}
						if (position)
						{
							Vector3 vector10 = cachedTransform.position;
							Vector3 vector11 = parentReference.InverseTransformPoint(vector10);
							Bone bone16 = this.bone;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
							float num28 = vector11.x / skeletonUtility.PositionScale;
							float num29 = Mathf.Min(overrideAlpha, 1f);
							if (!(overrideAlpha < 0f))
							{
							}
							float num30 = num28 - bone16.X;
							float num31 = num30 * (float)obj;
							float x10 = bone16.X + num31;
							bone16.X = x10;
						}
						if (rotation)
						{
							Bone bone17 = this.bone;
							Vector3 up = cachedTransform.up;
							Vector3 upwards = parentReference.InverseTransformDirection(up);
							Quaternion quaternion5 = Quaternion.LookRotation(Vector3.forward, upwards);
							Vector3 vector12 = Quaternion.Internal_ToEulerRad(quaternion5);
							float x11 = vector12.x * 57.29578f;
							float y9 = vector12.y * 57.29578f;
							float z8 = vector12.z * 57.29578f;
							Vector3 euler4 = default(Vector3);
							euler4.x = x11;
							euler4.y = y9;
							euler4.z = z8;
							float num32 = Quaternion.Internal_MakePositive(euler4).z - bone17.Rotation;
							float f2 = num32 / 360f;
							float num33 = Mathf.Floor(f2);
							float num34 = num33 * -360f;
							float num35 = num32 + num34;
							float num36 = Mathf.Min(num35, 360f);
							if (num35 < 0f)
							{
								num36 = 0f;
							}
							float num37 = num36 - 180f;
							bool flag9 = num37 < 0f;
							bool flag10 = num37 == 0f;
							int num38 = num36 ^ 0x43340000;
							object obj3 = num36 ^ num37;
							int num39 = (int)(num38 & (nint)obj3);
							bool flag11 = num39 < 0;
							Bone bone18 = this.bone;
							float num40 = Mathf.Min(overrideAlpha, 1f);
							float num41 = num36 + -360f;
							bool flag12 = flag9 == flag11;
							bool flag13 = !flag10;
							if (!(flag12 && flag13))
							{
								num41 = num36;
							}
							float num42 = ((overrideAlpha < 0f) ? 0f : num40);
							float num43 = num42 * num41;
							float appliedRotation2 = (bone18.Rotation = bone17.Rotation + num43);
							bone18.AppliedRotation = appliedRotation2;
						}
						Bone bone19;
						if (scale)
						{
							Vector3 localScale3 = cachedTransform.localScale;
							bone19 = this.bone;
							float num45 = Mathf.Min(overrideAlpha, 1f);
							if (!(overrideAlpha < 0f))
							{
							}
							float num46 = localScale3.x - bone19.ScaleX;
							float num47 = num46 * (float)obj;
							float scaleX2 = bone19.ScaleX + num47;
							bone19.ScaleX = scaleX2;
						}
						else
						{
							bone19 = this.bone;
						}
						bool flag14 = BoneTransformModeIncompatible(bone19);
						incompatibleTransformMode = flag14;
					}
					transformLerpComplete = true;
				}
			}
			else
			{
				Reset();
			}
		}

		[Token(Token = "0x6000655")]
		[Address(RVA = "0x156CD40", Offset = "0x156CD40", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = bone.data;\n\tv27 = Spine.SpineSkeletonExtensions::InheritsScale(v4.transformMode);\n\tv28 = ~v27;\n\treturn v28;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool BoneTransformModeIncompatible(Bone bone)
		{
			BoneData data = bone.Data;
			bool flag = data.TransformMode.InheritsScale();
			return !flag;
		}

		[Token(Token = "0x6000656")]
		[Address(RVA = "0x156CD70", Offset = "0x156CD70", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = UnityEngine.Component::get_transform(this);\n\tv24 = UnityEngine.Component::get_gameObject(v21);\n\tv34 = Spine.Unity.SkeletonUtility::AddBoneRigidbody2D(v24, 1, 0f);\n\tv27 = this.bone;\n\tv79 = UnityEngine.Component::get_transform(this);\n\tv65 = Spine.Unity.SkeletonUtility::AddBoundingBoxGameObject(v27.skeleton, skinName, slotName, attachmentName, v79, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddBoundingBox(string skinName, string slotName, string attachmentName)
		{
			Transform transform = base.transform;
			GameObject gameObject = transform.gameObject;
			Rigidbody2D rigidbody2D = SkeletonUtility.AddBoneRigidbody2D(gameObject);
			Bone bone = this.bone;
			Transform parent = base.transform;
			PolygonCollider2D polygonCollider2D = SkeletonUtility.AddBoundingBoxGameObject(bone.Skeleton, skinName, slotName, attachmentName, parent);
		}

		[Token(Token = "0x6000657")]
		[Address(RVA = "0x156CDF0", Offset = "0x156CDF0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.zPosition = 1;\n\tthis.overrideAlpha = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonUtilityBone()
		{
			zPosition = true;
			overrideAlpha = 1f;
		}
	}
}
