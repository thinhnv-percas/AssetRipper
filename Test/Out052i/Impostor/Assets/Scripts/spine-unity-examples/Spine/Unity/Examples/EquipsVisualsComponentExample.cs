using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000039")]
	public class EquipsVisualsComponentExample : MonoBehaviour
	{
		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation skeletonAnimation;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x28")]
		public string templateSkinName;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x30")]
		private Skin equipsSkin;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x38")]
		private Skin collectedSkin;

		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x40")]
		public Material runtimeMaterial;

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x48")]
		public Texture2D runtimeAtlas;

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x1511568", Offset = "0x1511568", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Spine.Skin;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = \"Equips\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A42]) = v42;\nL_001A:\n\tv44 = new Spine.Skin();\n\tSpine.Skin::.ctor(v44, \"Equips\");\n\tthis.equipsSkin = v44;\n\tv53 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv88 = Spine.SkeletonData::FindSkin(v53.data, this.templateSkinName);\n\tv89 = v88 == 0;\n\tif (v89) goto L_0037;\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(this.equipsSkin, v88);\nL_0037:\n\tv62 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tSpine.Skeleton::set_Skin(v62, this.equipsSkin);\n\tSpine.Unity.Examples.EquipsVisualsComponentExample::RefreshSkeletonAttachments(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Skin skin = new Skin("Equips");
			equipsSkin = skin;
			Skeleton skeleton = skeletonAnimation.Skeleton;
			Skin skin2 = skeleton.Data.FindSkin(templateSkinName);
			if (skin2 != null)
			{
				equipsSkin.AddAttachments(skin2);
			}
			Skeleton skeleton2 = skeletonAnimation.Skeleton;
			skeleton2.Skin = equipsSkin;
			RefreshSkeletonAttachments();
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x1511698", Offset = "0x1511698", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Skin::SetAttachment(this.equipsSkin, slotIndex, attachmentName, attachment);\n\tv21 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tSpine.Skeleton::SetSkin(v21, this.equipsSkin);\n\tSpine.Unity.Examples.EquipsVisualsComponentExample::RefreshSkeletonAttachments(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Equip(int slotIndex, string attachmentName, Attachment attachment)
		{
			equipsSkin.SetAttachment(slotIndex, attachmentName, attachment);
			Skeleton skeleton = skeletonAnimation.Skeleton;
			skeleton.SetSkin(equipsSkin);
			RefreshSkeletonAttachments();
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x15116E0", Offset = "0x15116E0", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = UnityEngine.Object;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv67 = Spine.Skin;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv73 = \"Repacked skin\";\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv157 = \"Collected skin\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v157, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A43]) = v42;\nL_0020:\n\tv62 = this.collectedSkin;\n\tv44 = this.collectedSkin == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0033;\n\tv52 = new Spine.Skin();\n\tSpine.Skin::.ctor(v52, \"Collected skin\");\n\tthis.collectedSkin = v52;\nL_0033:\n\tSpine.Skin::Clear(v62);\n\tv77 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv147 = v77.data;\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(this.collectedSkin, v147.defaultSkin);\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(this.collectedSkin, this.equipsSkin);\n\tv153 = this + 0x40;\n\tgoto L_0054;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v226, v222, v128, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0054:\n\tv234 = UnityEngine.Object::op_Implicit(*([v153 @ X20_v8 (UnityEngine.Material&)]));\n\tv236 = v234 == 0;\n\tif (v236) goto L_0063;\n\tgoto L_0061;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v237, v233, v128, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0061:\n\tUnityEngine.Object::Destroy(*([v153 @ X20_v8 (UnityEngine.Material&)]));\nL_0063:\n\tv118 = this + 0x48;\n\tgoto L_006D;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v251, v243, v128, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tv261 = UnityEngine.Object::op_Implicit(*([v118 @ X21_v6 (UnityEngine.Texture2D&)]));\n\tv263 = v261 == 0;\n\tif (v263) goto L_007B;\n\tgoto L_007A;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v264, v260, v128, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_007A:\n\tUnityEngine.Object::Destroy(*([v118 @ X21_v6 (UnityEngine.Texture2D&)]));\nL_007B:\n\tv148 = this.skeletonAnimation;\n\tv149 = v148.skeletonDataAsset;\n\tv150 = v149.atlasAssets;\n\tv281 = Spine.Unity.AtlasAssetBase::get_PrimaryMaterial(v150[0]);\n\tgoto L_00AB;\n\tv285 = v282;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v285, v279, v128, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AB:\n\tv133 = Spine.Unity.AttachmentTools.AtlasUtilities::GetRepackedSkin(this.collectedSkin, \"Repacked skin\", v281, v153, v118, 0x400, 2, 4, 0, 1, 0, 0, v290, 0, v291);\n\tSpine.Skin::Clear(this.collectedSkin);\n\tv135 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tSpine.Skeleton::set_Skin(v135, v133);\n\tSpine.Unity.Examples.EquipsVisualsComponentExample::RefreshSkeletonAttachments(this);\n\treturn;\n\tv155 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OptimizeSkin()
		{
			Skin skin = collectedSkin;
			if (collectedSkin == null)
			{
				skin = (collectedSkin = new Skin("Collected skin"));
			}
			skin.Clear();
			Skeleton skeleton = this.skeletonAnimation.Skeleton;
			SkeletonData data = skeleton.Data;
			collectedSkin.AddAttachments(data.DefaultSkin);
			collectedSkin.AddAttachments(equipsSkin);
			ref Material reference = ref *(Material*)((nint)this + 64);
			if ((bool)reference)
			{
				Object.Destroy(reference);
			}
			ref Texture2D reference2 = ref *(Texture2D*)((nint)this + 72);
			if ((bool)reference2)
			{
				Object.Destroy(reference2);
			}
			SkeletonAnimation skeletonAnimation = this.skeletonAnimation;
			SkeletonDataAsset skeletonDataAsset = skeletonAnimation.skeletonDataAsset;
			AtlasAssetBase[] atlasAssets = skeletonDataAsset.atlasAssets;
			Material primaryMaterial = atlasAssets[0].PrimaryMaterial;
			Texture2D[] additionalOutputTextures = default(Texture2D[]);
			bool[] additionalTextureIsLinear = default(bool[]);
			Skin repackedSkin = collectedSkin.GetRepackedSkin("Repacked skin", primaryMaterial, out reference, out reference2, 1024, 2, TextureFormat.RGBA32, mipmaps: false, useOriginalNonrenderables: true, clearCache: false, null, additionalOutputTextures, null, additionalTextureIsLinear);
			collectedSkin.Clear();
			Skeleton skeleton2 = this.skeletonAnimation.Skeleton;
			skeleton2.Skin = repackedSkin;
			RefreshSkeletonAttachments();
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x1511644", Offset = "0x1511644", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tSpine.Skeleton::SetSlotsToSetupPose(v9);\n\tv19 = this.skeletonAnimation;\n\tv20 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv46 = Spine.AnimationState::Apply(*([v19 @ X0_v5 (Spine.Unity.SkeletonRenderer)+E8]), v20);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RefreshSkeletonAttachments()
		{
			//IL_0055: Expected O, but got I
			Skeleton skeleton = skeletonAnimation.Skeleton;
			skeleton.SetSlotsToSetupPose();
			SkeletonRenderer skeletonRenderer = skeletonAnimation;
			Skeleton skeleton2 = skeletonAnimation.Skeleton;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X0_v5 (Spine.Unity.SkeletonRenderer)+E8]");
			bool flag = ((AnimationState)0).Apply(skeleton2);
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x1511960", Offset = "0x1511960", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EquipsVisualsComponentExample()
		{
		}
	}
}
