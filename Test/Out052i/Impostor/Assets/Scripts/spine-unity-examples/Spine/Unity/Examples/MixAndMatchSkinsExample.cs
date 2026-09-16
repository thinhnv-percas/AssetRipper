using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200003F")]
	public class MixAndMatchSkinsExample : MonoBehaviour
	{
		[Token(Token = "0x2000040")]
		public enum ItemType
		{
			[Token(Token = "0x4000146")]
			Cloth = 0,
			[Token(Token = "0x4000147")]
			Pants = 1,
			[Token(Token = "0x4000148")]
			Bag = 2,
			[Token(Token = "0x4000149")]
			Hat = 3
		}

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x20")]
		public string baseSkin;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x28")]
		public string eyelidsSkin;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x30")]
		public string[] hairSkins;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x38")]
		public int activeHairIndex;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x40")]
		public string[] eyesSkins;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x48")]
		public int activeEyesIndex;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x50")]
		public string[] noseSkins;

		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x58")]
		public int activeNoseIndex;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x60")]
		public string clothesSkin;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x68")]
		public string pantsSkin;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x70")]
		public string bagSkin;

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x78")]
		public string hatSkin;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x80")]
		private SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x88")]
		private Skin characterSkin;

		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x90")]
		public Material runtimeMaterial;

		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x98")]
		public Texture2D runtimeAtlas;

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x1511CC0", Offset = "0x1511CC0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A48]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v40;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			skeletonAnimation = component;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x1511D10", Offset = "0x1511D10", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCharacterSkin(this);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			UpdateCharacterSkin();
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x1511F94", Offset = "0x1511F94", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.hairSkins;\n\tv10 = this.activeHairIndex + 1;\n\tv11 = v10 / v4.Length;\n\tv12 = v11 * v4.Length;\n\tv13 = v10 - v12;\n\tthis.activeHairIndex = v13;\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCharacterSkin(this);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void NextHairSkin()
		{
			//IL_003d: Expected O, but got I4
			string[] array = hairSkins;
			int num = activeHairIndex + 1;
			int num2 = num / array.Length;
			object obj = num2 * array.Length;
			int num3 = (int)(num - (nint)obj);
			activeHairIndex = num3;
			UpdateCharacterSkin();
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x1511FD0", Offset = "0x1511FD0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.hairSkins;\n\tv10 = this.activeHairIndex + v4.Length;\n\tv11 = v10 - 1;\n\tv12 = v11 / v4.Length;\n\tv13 = v12 * v4.Length;\n\tv14 = v11 - v13;\n\tthis.activeHairIndex = v14;\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCharacterSkin(this);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PrevHairSkin()
		{
			//IL_0020: Expected O, but got I4
			//IL_002f: Expected O, but got I
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			string[] array = hairSkins;
			object obj = activeHairIndex + array.Length;
			object obj2 = (nint)obj - 1;
			object obj3 = (nint)obj2 / array.Length;
			object obj4 = (nint)obj3 * array.Length;
			int num = (int)((nint)obj2 - (nint)obj4);
			activeHairIndex = num;
			UpdateCharacterSkin();
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x1512010", Offset = "0x1512010", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.eyesSkins;\n\tv10 = this.activeEyesIndex + 1;\n\tv11 = v10 / v4.Length;\n\tv12 = v11 * v4.Length;\n\tv13 = v10 - v12;\n\tthis.activeEyesIndex = v13;\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCharacterSkin(this);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void NextEyesSkin()
		{
			//IL_003d: Expected O, but got I4
			string[] array = eyesSkins;
			int num = activeEyesIndex + 1;
			int num2 = num / array.Length;
			object obj = num2 * array.Length;
			int num3 = (int)(num - (nint)obj);
			activeEyesIndex = num3;
			UpdateCharacterSkin();
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x151204C", Offset = "0x151204C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.eyesSkins;\n\tv10 = this.activeEyesIndex + v4.Length;\n\tv11 = v10 - 1;\n\tv12 = v11 / v4.Length;\n\tv13 = v12 * v4.Length;\n\tv14 = v11 - v13;\n\tthis.activeEyesIndex = v14;\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCharacterSkin(this);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PrevEyesSkin()
		{
			//IL_0020: Expected O, but got I4
			//IL_002f: Expected O, but got I
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			string[] array = eyesSkins;
			object obj = activeEyesIndex + array.Length;
			object obj2 = (nint)obj - 1;
			object obj3 = (nint)obj2 / array.Length;
			object obj4 = (nint)obj3 * array.Length;
			int num = (int)((nint)obj2 - (nint)obj4);
			activeEyesIndex = num;
			UpdateCharacterSkin();
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x151208C", Offset = "0x151208C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.noseSkins;\n\tv10 = this.activeNoseIndex + 1;\n\tv11 = v10 / v4.Length;\n\tv12 = v11 * v4.Length;\n\tv13 = v10 - v12;\n\tthis.activeNoseIndex = v13;\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCharacterSkin(this);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void NextNoseSkin()
		{
			//IL_003d: Expected O, but got I4
			string[] array = noseSkins;
			int num = activeNoseIndex + 1;
			int num2 = num / array.Length;
			object obj = num2 * array.Length;
			int num3 = (int)(num - (nint)obj);
			activeNoseIndex = num3;
			UpdateCharacterSkin();
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x15120C8", Offset = "0x15120C8", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.noseSkins;\n\tv10 = this.activeNoseIndex + v4.Length;\n\tv11 = v10 - 1;\n\tv12 = v11 / v4.Length;\n\tv13 = v12 * v4.Length;\n\tv14 = v11 - v13;\n\tthis.activeNoseIndex = v14;\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCharacterSkin(this);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PrevNoseSkin()
		{
			//IL_0020: Expected O, but got I4
			//IL_002f: Expected O, but got I
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			string[] array = noseSkins;
			object obj = activeNoseIndex + array.Length;
			object obj2 = (nint)obj - 1;
			object obj3 = (nint)obj2 / array.Length;
			object obj4 = (nint)obj3 * array.Length;
			int num = (int)((nint)obj2 - (nint)obj4);
			activeNoseIndex = num;
			UpdateCharacterSkin();
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x1511C78", Offset = "0x1511C78", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = itemType < 3;\n\tv2 = ~v0;\n\tv3 = itemType - 3;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv11 = v2 & v10;\n\tif (v11) goto L_001C;\n\tv14 = 0x44C000 + 0xCDB;\n\tv17 = *([v14 @ X9_v2 (System.Int32)+itemType @ X2 (Spine.Unity.Examples.MixAndMatchSkinsExample+ItemType)]) << 2;\n\tv18 = 0x1515C9C + v17;\n\t// 19 IndirectJump v18 @ X10_v2 (System.Int32), this @ X0 (Spine.Unity.Examples.MixAndMatchSkinsExample), this @ X0 (Spine.Unity.Examples.MixAndMatchSkinsExample), itemSkin @ X1 (System.String), itemType @ X2 (Spine.Unity.Examples.MixAndMatchSkinsExample+ItemType), methodInfo @ X3 (Il2CppMethodInfo), v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\tX8 = X0 + 0x60;\n\tgoto L_001B;\n\tX8 = X0 + 0x68;\n\tgoto L_001B;\n\tX8 = X0 + 0x70;\n\tgoto L_001B;\n\tX8 = X0 + 0x78;\nL_001B:\n\t*([X8]) = X1;\nL_001C:\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::UpdateCombinedSkin(this);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Equip(string itemSkin, ItemType itemType)
		{
			bool flag = itemType < ItemType.Hat;
			bool flag2 = !flag;
			int num = (int)(itemType - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 4505600 + 3291;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X9_v2 (System.Int32)+itemType @ X2 (Spine.Unity.Examples.MixAndMatchSkinsExample+ItemType)]");
				int num3 = (int)((nint)0 << 2);
				int num4 = 22109340 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v18 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			UpdateCombinedSkin();
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x1512108", Offset = "0x1512108", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = UnityEngine.Object;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv141 = \"Repacked skin\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v141, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A49]) = v42;\nL_001E:\n\tv49 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv93 = this + 0x90;\n\tgoto L_002F;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v171, v48, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\tv179 = UnityEngine.Object::op_Implicit(*([v93 @ X21_v4 (UnityEngine.Material&)]));\n\tv216 = v179 == 0;\n\tif (v216) goto L_003E;\n\tgoto L_003C;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v217, v178, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003C:\n\tUnityEngine.Object::Destroy(*([v93 @ X21_v4 (UnityEngine.Material&)]));\nL_003E:\n\tv91 = this + 0x98;\n\tgoto L_0048;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v231, v223, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0048:\n\tv241 = UnityEngine.Object::op_Implicit(*([v91 @ X22_v6 (UnityEngine.Texture2D&)]));\n\tv243 = v241 == 0;\n\tif (v243) goto L_0056;\n\tgoto L_0055;\n\tv253 = \"il2cpp_codegen_runtime_class_init\"(v244, v240, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0055:\n\tUnityEngine.Object::Destroy(*([v91 @ X22_v6 (UnityEngine.Texture2D&)]));\nL_0056:\n\tv133 = this.skeletonAnimation;\n\tv134 = v133.skeletonDataAsset;\n\tv135 = v134.atlasAssets;\n\tv261 = Spine.Unity.AtlasAssetBase::get_PrimaryMaterial(v135[0]);\n\tgoto L_0085;\n\tv265 = v262;\n\tv266 = \"il2cpp_codegen_runtime_class_init\"(v265, v259, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0085:\n\tv110 = Spine.Unity.AttachmentTools.AtlasUtilities::GetRepackedSkin(v49.skin, \"Repacked skin\", v261, v93, v91, 0x400, 2, 4, 0, 1, 0, 0, v269, 0, v270);\n\tSpine.Skin::Clear(v49.skin);\n\tv112 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tSpine.Skeleton::set_Skin(v112, v110);\n\tv114 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tSpine.Skeleton::SetSlotsToSetupPose(v114);\n\tv115 = this.skeletonAnimation;\n\tv116 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv273 = Spine.AnimationState::Apply(*([v115 @ X0_v28 (Spine.Unity.SkeletonRenderer)+E8]), v116);\n\tSpine.Unity.AttachmentTools.AtlasUtilities::ClearCache();\n\treturn;\n\tv139 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OptimizeSkin()
		{
			//IL_01e6: Expected O, but got I
			Skeleton skeleton = this.skeletonAnimation.Skeleton;
			ref Material reference = ref *(Material*)((nint)this + 144);
			if ((bool)reference)
			{
				Object.Destroy(reference);
			}
			ref Texture2D reference2 = ref *(Texture2D*)((nint)this + 152);
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
			Skin repackedSkin = skeleton.Skin.GetRepackedSkin("Repacked skin", primaryMaterial, out reference, out reference2, 1024, 2, TextureFormat.RGBA32, mipmaps: false, useOriginalNonrenderables: true, clearCache: false, null, additionalOutputTextures, null, additionalTextureIsLinear);
			skeleton.Skin.Clear();
			Skeleton skeleton2 = this.skeletonAnimation.Skeleton;
			skeleton2.Skin = repackedSkin;
			Skeleton skeleton3 = this.skeletonAnimation.Skeleton;
			skeleton3.SetSlotsToSetupPose();
			SkeletonRenderer skeletonRenderer = this.skeletonAnimation;
			Skeleton skeleton4 = this.skeletonAnimation.Skeleton;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X0_v28 (Spine.Unity.SkeletonRenderer)+E8]");
			bool flag = ((AnimationState)0).Apply(skeleton4);
			AtlasUtilities.ClearCache();
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x1511D28", Offset = "0x1511D28", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = Spine.Skin;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = \"character-base\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37A4A]) = v36;\nL_0018:\n\tv42 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv124 = new Spine.Skin();\n\tSpine.Skin::.ctor(v124, \"character-base\");\n\tthis.characterSkin = v124;\n\tv125 = Spine.SkeletonData::FindSkin(v42.data, this.baseSkin);\n\tSpine.Skin::AddSkin(v124, v125);\n\tv148 = this.noseSkins;\n\tv95 = this.activeNoseIndex;\n\tv127 = Spine.SkeletonData::FindSkin(v42.data, v148[v95 @ X9_v3 (System.Int32)]);\n\tSpine.Skin::AddSkin(this.characterSkin, v127);\n\tv128 = Spine.SkeletonData::FindSkin(v42.data, this.eyelidsSkin);\n\tSpine.Skin::AddSkin(this.characterSkin, v128);\n\tv150 = this.eyesSkins;\n\tv96 = this.activeEyesIndex;\n\tv130 = Spine.SkeletonData::FindSkin(v42.data, v150[v96 @ X9_v4 (System.Int32)]);\n\tSpine.Skin::AddSkin(this.characterSkin, v130);\n\tv152 = this.hairSkins;\n\tv97 = this.activeHairIndex;\n\tv132 = Spine.SkeletonData::FindSkin(v42.data, v152[v97 @ X9_v5 (System.Int32)]);\n\tSpine.Skin::AddSkin(this.characterSkin, v132);\n\treturn;\n\tv156 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateCharacterSkin()
		{
			Skeleton skeleton = skeletonAnimation.Skeleton;
			Skin skin = (characterSkin = new Skin("character-base"));
			Skin skin2 = skeleton.Data.FindSkin(baseSkin);
			skin.AddSkin(skin2);
			string[] array = noseSkins;
			int num = activeNoseIndex;
			Skin skin3 = skeleton.Data.FindSkin(array[num]);
			characterSkin.AddSkin(skin3);
			Skin skin4 = skeleton.Data.FindSkin(eyelidsSkin);
			characterSkin.AddSkin(skin4);
			string[] array2 = eyesSkins;
			int num2 = activeEyesIndex;
			Skin skin5 = skeleton.Data.FindSkin(array2[num2]);
			characterSkin.AddSkin(skin5);
			string[] array3 = hairSkins;
			int num3 = activeHairIndex;
			Skin skin6 = skeleton.Data.FindSkin(array3[num3]);
			characterSkin.AddSkin(skin6);
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x1512344", Offset = "0x1512344", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv29 = Spine.SkeletonData::FindSkin(v15.data, this.clothesSkin);\n\tSpine.Skin::AddSkin(combinedSkin, v29);\n\tv74 = Spine.SkeletonData::FindSkin(v15.data, this.pantsSkin);\n\tSpine.Skin::AddSkin(combinedSkin, v74);\n\tv80 = System.String::IsNullOrEmpty(this.bagSkin);\n\tv82 = v80 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0034;\n\tv87 = Spine.SkeletonData::FindSkin(v15.data, this.bagSkin);\n\tSpine.Skin::AddSkin(combinedSkin, v87);\nL_0034:\n\tv62 = System.String::IsNullOrEmpty(this.hatSkin);\n\tv60 = v62 == 0;\n\tif (v60) goto L_0041;\n\treturn;\nL_0041:\n\tv98 = Spine.SkeletonData::FindSkin(v15.data, this.hatSkin);\n\tSpine.Skin::AddSkin(combinedSkin, v98);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddEquipmentSkinsTo(Skin combinedSkin)
		{
			Skeleton skeleton = skeletonAnimation.Skeleton;
			Skin skin = skeleton.Data.FindSkin(clothesSkin);
			combinedSkin.AddSkin(skin);
			Skin skin2 = skeleton.Data.FindSkin(pantsSkin);
			combinedSkin.AddSkin(skin2);
			if (!string.IsNullOrEmpty(bagSkin))
			{
				Skin skin3 = skeleton.Data.FindSkin(bagSkin);
				combinedSkin.AddSkin(skin3);
			}
			if (!string.IsNullOrEmpty(hatSkin))
			{
				Skin skin4 = skeleton.Data.FindSkin(hatSkin);
				combinedSkin.AddSkin(skin4);
			}
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x1511ED0", Offset = "0x1511ED0", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv16 = Spine.Skin;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = \"character-combined\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37A4B]) = v36;\nL_001C:\n\tv46 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv56 = new Spine.Skin();\n\tSpine.Skin::.ctor(v56, \"character-combined\");\n\tSpine.Skin::AddSkin(v56, this.characterSkin);\n\tSpine.Unity.Examples.MixAndMatchSkinsExample::AddEquipmentSkinsTo(this, v56);\n\tSpine.Skeleton::SetSkin(v46, v56);\n\tSpine.Skeleton::SetSlotsToSetupPose(v46);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateCombinedSkin()
		{
			Skeleton skeleton = skeletonAnimation.Skeleton;
			Skin skin = new Skin("character-combined");
			skin.AddSkin(characterSkin);
			AddEquipmentSkinsTo(skin);
			skeleton.SetSkin(skin);
			skeleton.SetSlotsToSetupPose();
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x151242C", Offset = "0x151242C", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004C;\n\tv26 = System.String[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = \"eyes/yellow\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = \"hair/brown\";\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv128 = \"hair/long-blue-with-scarf\";\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv185 = \"nose/long\";\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv225 = \"nose/short\";\n\tv226 = \"il2cpp_codegen_initialize_runtime_metadata\"(v225, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv231 = \"eyelids/girly\";\n\tv232 = \"il2cpp_codegen_initialize_runtime_metadata\"(v231, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv238 = \"skin-base\";\n\tv239 = \"il2cpp_codegen_initialize_runtime_metadata\"(v238, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv244 = \"hair/blue\";\n\tv245 = \"il2cpp_codegen_initialize_runtime_metadata\"(v244, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv247 = \"eyes/violet\";\n\tv248 = \"il2cpp_codegen_initialize_runtime_metadata\"(v247, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv250 = \"hair/short-red\";\n\tv251 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv256 = \"hair/pink\";\n\tv257 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv263 = \"legs/pants-jeans\";\n\tv264 = \"il2cpp_codegen_initialize_runtime_metadata\"(v263, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv269 = \"\";\n\tv270 = \"il2cpp_codegen_initialize_runtime_metadata\"(v269, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv272 = \"clothes/hoodie-orange\";\n\tv273 = \"il2cpp_codegen_initialize_runtime_metadata\"(v272, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv275 = \"eyes/green\";\n\tv276 = \"il2cpp_codegen_initialize_runtime_metadata\"(v275, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv281 = \"accessories/hat-red-yellow\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v281, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A4C]) = v46;\nL_004C:\n\tthis.baseSkin = \"skin-base\";\n\tthis.eyelidsSkin = \"eyelids/girly\";\n\t// 79 NewArr v51 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv51[0] = \"hair/brown\";\n\tv51[1] = \"hair/blue\";\n\tv51[2] = \"hair/pink\";\n\tv51[3] = \"hair/short-red\";\n\tv51[4] = \"hair/long-blue-with-scarf\";\n\tthis.hairSkins = v51;\n\t// 152 NewArr v116 @ X0_v9 (System.String[]), typeof(System.String[]), 3\n\tv116[0] = \"eyes/violet\";\n\tv116[1] = \"eyes/green\";\n\tv116[2] = \"eyes/yellow\";\n\tthis.eyesSkins = v116;\n\t// 195 NewArr v117 @ X0_v11 (System.String[]), typeof(System.String[]), 2\n\tv117[0] = \"nose/short\";\n\tv117[1] = \"nose/long\";\n\tthis.noseSkins = v117;\n\tthis.clothesSkin = \"clothes/hoodie-orange\";\n\tthis.pantsSkin = \"legs/pants-jeans\";\n\tthis.bagSkin = \"\";\n\tthis.hatSkin = \"accessories/hat-red-yellow\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\tv115 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MixAndMatchSkinsExample()
		{
			baseSkin = "skin-base";
			eyelidsSkin = "eyelids/girly";
			hairSkins = new string[5] { "hair/brown", "hair/blue", "hair/pink", "hair/short-red", "hair/long-blue-with-scarf" };
			eyesSkins = new string[3] { "eyes/violet", "eyes/green", "eyes/yellow" };
			noseSkins = new string[2] { "nose/short", "nose/long" };
			clothesSkin = "clothes/hoodie-orange";
			pantsSkin = "legs/pants-jeans";
			bagSkin = "";
			hatSkin = "accessories/hat-red-yellow";
		}
	}
}
