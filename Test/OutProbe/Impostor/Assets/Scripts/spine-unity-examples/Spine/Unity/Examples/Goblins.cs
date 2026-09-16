using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000029")]
	public class Goblins : MonoBehaviour
	{
		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x20")]
		private SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x28")]
		private Bone headBone;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x30")]
		private bool girlSkin;

		[Range(-360f, 360f)]
		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x34")]
		public float extraRotation;

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x150DEEC", Offset = "0x150DEEC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Spine.Unity.UpdateBonesDelegate;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv74 = \"head\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37A1A]) = v40;\nL_001F:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v43;\n\tv52 = Spine.Unity.SkeletonRenderer::get_Skeleton(v43);\n\tv81 = Spine.Skeleton::FindBone(v52, \"head\");\n\tthis.headBone = v81;\n\tv62 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v62, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonAnimation::add_UpdateLocal(this.skeletonAnimation, v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			Skeleton skeleton = (skeletonAnimation = GetComponent<SkeletonAnimation>()).Skeleton;
			Bone bone = skeleton.FindBone("head");
			headBone = bone;
			UpdateBonesDelegate value = UpdateLocal;
			skeletonAnimation.UpdateLocal += value;
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x150DFD4", Offset = "0x150DFD4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.headBone;\n\tv7 = v2.rotation + this.extraRotation;\n\tv2.rotation = v7;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateLocal(ISkeletonAnimation skeletonRenderer)
		{
			Bone bone = headBone;
			float rotation = bone.Rotation + extraRotation;
			bone.Rotation = rotation;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x150DFFC", Offset = "0x150DFFC", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv14 = \"goblin\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = \"goblingirl\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv110 = \"left-hand-item\";\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv113 = \"spear\";\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv150 = \"dagger\";\n\tv151 = \"il2cpp_codegen_initialize_runtime_metadata\"(v150, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv155 = \"right-hand-item\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37A1B]) = v34;\nL_0023:\n\tv41 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tif (this.girlSkin) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tSpine.Skeleton::SetSkin(v41, *([v103 @ X8_v5 (System.String)]));\n\tv89 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tSpine.Skeleton::SetSlotsToSetupPose(v89);\n\tv104 = this.girlSkin ^ 1;\n\tthis.girlSkin = v104;\n\tv140 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv156 = ~this.girlSkin;\n\tif (v156) goto L_005A;\n\tgoto L_006D;\nL_005A:\n\tSpine.Skeleton::SetAttachment(v140, \"right-hand-item\", 0);\n\tv140 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\nL_006D:\n\tSpine.Skeleton::SetAttachment(v140, \"left-hand-item\", *([v146 @ X8_v7 (System.String)]));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnMouseDown()
		{
			Skeleton skeleton = skeletonAnimation.Skeleton;
			string skin = (girlSkin ? "goblin" : "goblingirl");
			skeleton.SetSkin(skin);
			Skeleton skeleton2 = skeletonAnimation.Skeleton;
			skeleton2.SetSlotsToSetupPose();
			int num = (girlSkin ? 1 : 0) ^ 1;
			girlSkin = (byte)num != 0;
			Skeleton skeleton3 = skeletonAnimation.Skeleton;
			string attachmentName;
			if (girlSkin)
			{
				attachmentName = "dagger";
			}
			else
			{
				skeleton3.SetAttachment("right-hand-item", null);
				skeleton3 = skeletonAnimation.Skeleton;
				attachmentName = "spear";
			}
			skeleton3.SetAttachment("left-hand-item", attachmentName);
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x150E144", Offset = "0x150E144", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Goblins()
		{
		}
	}
}
