using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000041")]
	public class MixAndMatch : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000042")]
		private sealed class _003CStart_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000157")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000158")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000159")]
			[FieldOffset(Offset = "0x20")]
			public MixAndMatch _003C_003E4__this;

			[Token(Token = "0x17000018")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600010B")]
				[Address(RVA = "0x1512D28", Offset = "0x1512D28", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000019")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600010D")]
				[Address(RVA = "0x1512D68", Offset = "0x1512D68", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000108")]
			[Address(RVA = "0x1512818", Offset = "0x1512818", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__14(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000109")]
			[Address(RVA = "0x1512C88", Offset = "0x1512C88", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600010A")]
			[Address(RVA = "0x1512C8C", Offset = "0x1512C8C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = UnityEngine.WaitForSeconds;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37A51]) = v33;\nL_0015:\n\tv39 = this.<>1__state == 1;\n\tif (v39) goto L_002E;\n\tv44 = this.<>1__state == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv53 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v53, 1f);\n\tthis.<>2__current = v53;\n\tthis.<>1__state = 1;\n\tgoto L_0037;\nL_002E:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tSpine.Unity.Examples.MixAndMatch::Apply(this.<>4__this);\nL_0037:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
						_003C_003E2__current = waitForSeconds;
						_003C_003E1__state = 1;
						return true;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					_003C_003E4__this.Apply();
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600010C")]
			[Address(RVA = "0x1512D30", Offset = "0x1512D30", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x20")]
		public string templateAttachmentsSkin;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x28")]
		public Material sourceMaterial;

		[Header("Visor")]
		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x30")]
		public Sprite visorSprite;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x38")]
		public string visorSlot;

		[SpineAttachment(true, false, false, "visorSlot", null, "baseSkinName", true, false)]
		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x40")]
		public string visorKey;

		[Header("Gun")]
		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x48")]
		public Sprite gunSprite;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x50")]
		public string gunSlot;

		[SpineAttachment(true, false, false, "gunSlot", null, "baseSkinName", true, false)]
		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x58")]
		public string gunKey;

		[Header("Runtime Repack")]
		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x60")]
		public bool repack;

		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x68")]
		public BoundingBoxFollower bbFollower;

		[Header("Do not assign")]
		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x70")]
		public Texture2D runtimeAtlas;

		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x78")]
		public Material runtimeMaterial;

		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x80")]
		private Skin customSkin;

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x15126C8", Offset = "0x15126C8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A4D]) = v38;\nL_001B:\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = UnityEngine.Object::op_Equality(this.sourceMaterial, 0);\n\tv53 = v51 == 0;\n\tif (v53) goto L_0050;\n\tv58 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0034;\n\tv99 = v76;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v99, v57, v50, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tv70 = UnityEngine.Object::op_Inequality(v58, 0);\n\tv73 = v70 == 0;\n\tif (v73) goto L_0050;\n\tv105 = v58.skeletonDataAsset;\n\tv114 = v105.atlasAssets;\n\tv69 = Spine.Unity.AtlasAssetBase::get_PrimaryMaterial(v114[0]);\n\tthis.sourceMaterial = v69;\nL_0050:\n\treturn;\n\tv115 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			if (sourceMaterial == null)
			{
				SkeletonAnimation component = GetComponent<SkeletonAnimation>();
				if (component != null)
				{
					SkeletonDataAsset skeletonDataAsset = component.skeletonDataAsset;
					AtlasAssetBase[] atlasAssets = skeletonDataAsset.atlasAssets;
					Material primaryMaterial = atlasAssets[0].PrimaryMaterial;
					sourceMaterial = primaryMaterial;
				}
			}
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__14))]
		[Token(Token = "0x6000105")]
		[Address(RVA = "0x15127B8", Offset = "0x15127B8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.MixAndMatch+<Start>d__14;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A4E]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.MixAndMatch+<Start>d__14();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__14 _003CStart_003Ed__15 = null;
			_003CStart_003Ed__15._003C_003E1__state = 0;
			_003CStart_003Ed__15._003C_003E4__this = this;
			return _003CStart_003Ed__15;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x1512840", Offset = "0x1512840", Length = "0x3B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv32 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv61 = UnityEngine.Object;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv169 = Spine.Skin;\n\tv170 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv175 = \"repacked skin\";\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv240 = \"custom skin\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37A4F]) = v52;\nL_002B:\n\tv55 = UnityEngine.Component::GetComponent(this);\n\tv67 = Spine.Unity.SkeletonRenderer::get_Skeleton(v55);\n\tv130 = this.customSkin;\n\tv172 = this.customSkin == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0040;\n\tv178 = new Spine.Skin();\n\tSpine.Skin::.ctor(v178, \"custom skin\");\nL_0040:\n\tthis.customSkin = v130;\n\tv244 = Spine.SkeletonData::FindSkin(v67.data, this.templateAttachmentsSkin);\n\tv146 = Spine.Skeleton::FindSlotIndex(v67, this.visorSlot);\n\tv250 = Spine.Skin::GetAttachment(v244, v146, this.visorKey);\n\tv147 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetRemappedClone(v250, this.visorSprite, this.sourceMaterial, 1, 1, 0, 0);\n\tSpine.Skin::SetAttachment(this.customSkin, v146, this.visorKey, v147);\n\tv259 = Spine.Skeleton::FindSlotIndex(v67, this.gunSlot);\n\tv264 = Spine.Skin::GetAttachment(v244, v259, this.gunKey);\n\tv266 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetRemappedClone(v264, this.gunSprite, this.sourceMaterial, 1, 1, 0, 0);\n\tv267 = v266 == 0;\n\tif (v267) goto L_0084;\n\tSpine.Skin::SetAttachment(this.customSkin, v259, this.gunKey, v266);\nL_0084:\n\tv276 = ~this.repack;\n\tif (v276) goto L_0103;\n\tv149 = new Spine.Skin();\n\tSpine.Skin::.ctor(v149, \"repacked skin\");\n\tv162 = v67.data;\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(v149, v162.defaultSkin);\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(v149, this.customSkin);\n\tv121 = this + 0x78;\n\tgoto L_00A6;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v309, v304, v306, v116, v111, v106, v102, v98, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00A6:\n\tv317 = UnityEngine.Object::op_Implicit(*([v121 @ X23_v7 (UnityEngine.Material&)]));\n\tv319 = v317 == 0;\n\tif (v319) goto L_00B5;\n\tgoto L_00B3;\n\tv338 = \"il2cpp_codegen_runtime_class_init\"(v320, v316, v306, v116, v111, v106, v102, v98, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00B3:\n\tUnityEngine.Object::Destroy(*([v121 @ X23_v7 (UnityEngine.Material&)]));\nL_00B5:\n\tv142 = this + 0x70;\n\tgoto L_00C1;\n\tv340 = \"il2cpp_codegen_runtime_class_init\"(v334, v325, v306, v116, v111, v106, v102, v98, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00C1:\n\tv345 = UnityEngine.Object::op_Implicit(*([v142 @ X24_v9 (UnityEngine.Texture2D&)]));\n\tv347 = v345 == 0;\n\tif (v347) goto L_00D4;\n\tgoto L_00CE;\n\tv364 = \"il2cpp_codegen_runtime_class_init\"(v348, v344, v306, v116, v111, v106, v102, v98, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00CE:\n\tUnityEngine.Object::Destroy(*([v142 @ X24_v9 (UnityEngine.Texture2D&)]));\nL_00D4:\n\tgoto L_00E6;\n\tv366 = \"il2cpp_codegen_runtime_class_init\"(v360, v354, v306, v116, v111, v106, v102, v98, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00E6:\n\tv372 = Spine.Unity.AttachmentTools.AtlasUtilities::GetRepackedSkin(v149, \"repacked skin\", this.sourceMaterial, v121, v142, 0x400, 2, 4, 0, 1, 0, 0, v373, 0, v374);\n\tSpine.Skeleton::SetSkin(v67, v372);\n\tgoto L_00F5;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v378, v375, v377, v117, v112, v107, v103, v99, v87, v42, v43, v44, v45, v46, v47, v48);\nL_00F5:\n\tv294 = UnityEngine.Object::op_Inequality(this.bbFollower, 0);\n\tv295 = v294 == 0;\n\tif (v295) goto L_0106;\n\tSpine.Unity.BoundingBoxFollower::Initialize(this.bbFollower, 1);\n\tgoto L_0106;\nL_0103:\n\tSpine.Skeleton::SetSkin(v67, this.customSkin);\nL_0106:\n\tSpine.Skeleton::SetSlotsToSetupPose(v67);\n\tSpine.Unity.SkeletonAnimation::Update(v55, 0f);\n\tv228 = UnityEngine.Resources::UnloadUnusedAssets();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 206 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Apply()
		{
			SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			Skeleton skeleton = component.Skeleton;
			Skin skin = customSkin;
			if (customSkin == null)
			{
				Skin skin2 = new Skin("custom skin");
				skin = skin2;
			}
			customSkin = skin;
			Skin skin3 = skeleton.Data.FindSkin(templateAttachmentsSkin);
			int slotIndex = skeleton.FindSlotIndex(visorSlot);
			Attachment attachment = skin3.GetAttachment(slotIndex, visorKey);
			Attachment remappedClone = attachment.GetRemappedClone(visorSprite, sourceMaterial, premultiplyAlpha: true, cloneMeshAsLinked: true, useOriginalRegionSize: false, pivotShiftsMeshUVCoords: false);
			customSkin.SetAttachment(slotIndex, visorKey, remappedClone);
			int slotIndex2 = skeleton.FindSlotIndex(gunSlot);
			Attachment attachment2 = skin3.GetAttachment(slotIndex2, gunKey);
			Attachment remappedClone2 = attachment2.GetRemappedClone(gunSprite, sourceMaterial, premultiplyAlpha: true, cloneMeshAsLinked: true, useOriginalRegionSize: false, pivotShiftsMeshUVCoords: false);
			if (remappedClone2 != null)
			{
				customSkin.SetAttachment(slotIndex2, gunKey, remappedClone2);
			}
			if (repack)
			{
				Skin skin4 = new Skin("repacked skin");
				SkeletonData data = skeleton.Data;
				skin4.AddAttachments(data.DefaultSkin);
				skin4.AddAttachments(customSkin);
				ref Material reference = ref *(Material*)((nint)this + 120);
				if ((bool)reference)
				{
					UnityEngine.Object.Destroy(reference);
				}
				ref Texture2D reference2 = ref *(Texture2D*)((nint)this + 112);
				if ((bool)reference2)
				{
					UnityEngine.Object.Destroy(reference2);
				}
				Texture2D[] additionalOutputTextures = default(Texture2D[]);
				bool[] additionalTextureIsLinear = default(bool[]);
				Skin repackedSkin = skin4.GetRepackedSkin("repacked skin", sourceMaterial, out reference, out reference2, 1024, 2, TextureFormat.RGBA32, mipmaps: false, useOriginalNonrenderables: true, clearCache: false, null, additionalOutputTextures, null, additionalTextureIsLinear);
				skeleton.SetSkin(repackedSkin);
				if (bbFollower != null)
				{
					bbFollower.Initialize(overwrite: true);
				}
			}
			else
			{
				skeleton.SetSkin(customSkin);
			}
			skeleton.SetSlotsToSetupPose();
			component.Update(0f);
			AsyncOperation asyncOperation = Resources.UnloadUnusedAssets();
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x1512BF0", Offset = "0x1512BF0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = \"base\";\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv60 = \"goggles\";\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv63 = \"gun\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A50]) = v46;\nL_0023:\n\tthis.templateAttachmentsSkin = \"base\";\n\tthis.visorKey = \"goggles\";\n\tthis.repack = 1;\n\tthis.gunKey = \"gun\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MixAndMatch()
		{
			templateAttachmentsSkin = "base";
			visorKey = "goggles";
			repack = true;
			gunKey = "gun";
		}
	}
}
