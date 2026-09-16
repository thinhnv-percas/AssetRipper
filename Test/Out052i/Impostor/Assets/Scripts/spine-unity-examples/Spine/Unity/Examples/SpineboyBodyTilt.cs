using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200006D")]
	public class SpineboyBodyTilt : MonoBehaviour
	{
		[Header("Settings")]
		[Token(Token = "0x400024D")]
		[FieldOffset(Offset = "0x20")]
		public SpineboyFootplanter planter;

		[SpineBone(null, null, true, false)]
		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x28")]
		public string hip;

		[SpineBone(null, null, true, false)]
		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x30")]
		public string head;

		[Token(Token = "0x4000250")]
		[FieldOffset(Offset = "0x38")]
		public float hipTiltScale;

		[Token(Token = "0x4000251")]
		[FieldOffset(Offset = "0x3C")]
		public float headTiltScale;

		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x40")]
		public float hipRotationMoveScale;

		[Header("Debug")]
		[Token(Token = "0x4000253")]
		[FieldOffset(Offset = "0x44")]
		public float hipRotationTarget;

		[Token(Token = "0x4000254")]
		[FieldOffset(Offset = "0x48")]
		public float hipRotationSmoothed;

		[Token(Token = "0x4000255")]
		[FieldOffset(Offset = "0x4C")]
		public float baseHeadRotation;

		[Token(Token = "0x4000256")]
		[FieldOffset(Offset = "0x50")]
		private Bone hipBone;

		[Token(Token = "0x4000257")]
		[FieldOffset(Offset = "0x58")]
		private Bone headBone;

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0x151F3B0", Offset = "0x151F3B0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = Spine.Unity.UpdateBonesDelegate;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37AB5]) = v38;\nL_001B:\n\tv41 = UnityEngine.Component::GetComponent(this);\n\tv50 = Spine.Unity.SkeletonRenderer::get_Skeleton(v41);\n\tv66 = Spine.Skeleton::FindBone(v50, this.hip);\n\tthis.hipBone = v66;\n\tv56 = Spine.Skeleton::FindBone(v50, this.head);\n\tthis.headBone = v56;\n\tthis.baseHeadRotation = v56.rotation;\n\tv93 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v93, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonAnimation::add_UpdateLocal(v41, v93);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			Skeleton skeleton = component.Skeleton;
			Bone bone = skeleton.FindBone(hip);
			hipBone = bone;
			baseHeadRotation = (headBone = skeleton.FindBone(head)).Rotation;
			UpdateBonesDelegate value = UpdateLocal;
			component.UpdateLocal += value;
		}

		[Token(Token = "0x60001E5")]
		[Address(RVA = "0x151F498", Offset = "0x151F498", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.planter;\n\tv15 = v8.balance * this.hipTiltScale;\n\tthis.hipRotationTarget = v15;\n\tv17 = UnityEngine.Time::get_deltaTime();\n\tv72 = this.planter;\n\tv50 = v15 - this.hipRotationSmoothed;\n\tv88 = v72.balance + v72.balance;\n\tv89 = v17 * this.hipRotationMoveScale;\n\tv90 = v88 / v72.offBalanceThreshold;\n\tv63 = UnityEngine.Mathf::Abs(v90);\n\tv74 = this.hipBone;\n\tv56 = v89 * v63;\n\tv129 = v89 * v63;\n\tv135 = -v129;\n\t// 40 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv132 = v50 < 0;\n\tif (v132) goto L_0030;\n\tgoto L_0030;\nL_0030:\n\tv66 = this.hipRotationSmoothed + v135;\n\tv137 = v50 < v56;\n\tv47 = ~v137;\n\tv44 = v50 - v56;\n\tv38 = v44 == 0;\n\tv138 = ~v38;\n\tv23 = v47 & v138;\n\tv20 = ~v23;\n\tif (v20) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tthis.hipRotationSmoothed = v66;\n\tv74.rotation = v66;\n\tv73 = this.headBone;\n\tv141 = v66 * this.headTiltScale;\n\tv117 = this.baseHeadRotation - v141;\n\tv73.rotation = v117;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateLocal(ISkeletonAnimation animated)
		{
			SpineboyFootplanter spineboyFootplanter = planter;
			float num = (hipRotationTarget = spineboyFootplanter.Balance * hipTiltScale);
			float deltaTime = Time.deltaTime;
			SpineboyFootplanter spineboyFootplanter2 = planter;
			float num2 = num - hipRotationSmoothed;
			float num3 = spineboyFootplanter2.Balance + spineboyFootplanter2.Balance;
			float num4 = deltaTime * hipRotationMoveScale;
			float f = num3 / spineboyFootplanter2.offBalanceThreshold;
			float num5 = Mathf.Abs(f);
			Bone bone = hipBone;
			float num6 = num4 * num5;
			float num7 = num4 * num5;
			float num8 = 0f - num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (!(num2 < 0f))
			{
				num8 = num6;
			}
			float num9 = hipRotationSmoothed + num8;
			bool flag = num2 < num6;
			bool flag2 = !flag;
			float num10 = num2 - num6;
			bool flag3 = num10 == 0f;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				num9 = num;
			}
			hipRotationSmoothed = num9;
			bone.Rotation = num9;
			Bone bone2 = headBone;
			float num11 = num9 * headTiltScale;
			float rotation = baseHeadRotation - num11;
			bone2.Rotation = rotation;
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0x151F54C", Offset = "0x151F54C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = \"hip\";\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = \"head\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37AB6]) = v42;\nL_001E:\n\tthis.hipRotationMoveScale = 60f;\n\tthis.hipTiltScale = 0.00029296876243734005d;\n\tthis.hip = \"hip\";\n\tthis.head = \"head\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyBodyTilt()
		{
			hipRotationMoveScale = 60f;
			hipTiltScale = 7f;
			headTiltScale = 0.7f;
			hip = "hip";
			head = "head";
		}
	}
}
