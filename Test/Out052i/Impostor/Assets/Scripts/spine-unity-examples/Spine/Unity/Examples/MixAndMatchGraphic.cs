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
	[Token(Token = "0x2000043")]
	public class MixAndMatchGraphic : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000044")]
		private sealed class _003CStart_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000166")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000167")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000168")]
			[FieldOffset(Offset = "0x20")]
			public MixAndMatchGraphic _003C_003E4__this;

			[Token(Token = "0x1700001A")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000115")]
				[Address(RVA = "0x15133B0", Offset = "0x15133B0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001B")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000117")]
				[Address(RVA = "0x15133F0", Offset = "0x15133F0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000112")]
			[Address(RVA = "0x1512EC0", Offset = "0x1512EC0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__13(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000113")]
			[Address(RVA = "0x1513310", Offset = "0x1513310", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000114")]
			[Address(RVA = "0x1513314", Offset = "0x1513314", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = UnityEngine.WaitForSeconds;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37A56]) = v33;\nL_0015:\n\tv39 = this.<>1__state == 1;\n\tif (v39) goto L_002E;\n\tv44 = this.<>1__state == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv53 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v53, 1f);\n\tthis.<>2__current = v53;\n\tthis.<>1__state = 1;\n\tgoto L_0037;\nL_002E:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tSpine.Unity.Examples.MixAndMatchGraphic::Apply(this.<>4__this);\nL_0037:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000116")]
			[Address(RVA = "0x15133B8", Offset = "0x15133B8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x20")]
		public string baseSkinName;

		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x28")]
		public Material sourceMaterial;

		[Header("Visor")]
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x30")]
		public Sprite visorSprite;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x38")]
		public string visorSlot;

		[SpineAttachment(true, false, false, "visorSlot", null, "baseSkinName", true, false)]
		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x40")]
		public string visorKey;

		[Header("Gun")]
		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x48")]
		public Sprite gunSprite;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x50")]
		public string gunSlot;

		[SpineAttachment(true, false, false, "gunSlot", null, "baseSkinName", true, false)]
		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x58")]
		public string gunKey;

		[Header("Runtime Repack Required!!")]
		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x60")]
		public bool repack;

		[Header("Do not assign")]
		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x68")]
		public Texture2D runtimeAtlas;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x70")]
		public Material runtimeMaterial;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x78")]
		private Skin customSkin;

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x1512D70", Offset = "0x1512D70", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A52]) = v38;\nL_001B:\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = UnityEngine.Object::op_Equality(this.sourceMaterial, 0);\n\tv53 = v51 == 0;\n\tif (v53) goto L_0050;\n\tv58 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0034;\n\tv99 = v76;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v99, v57, v50, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tv70 = UnityEngine.Object::op_Inequality(v58, 0);\n\tv73 = v70 == 0;\n\tif (v73) goto L_0050;\n\tv105 = v58.skeletonDataAsset;\n\tv114 = v105.atlasAssets;\n\tv69 = Spine.Unity.AtlasAssetBase::get_PrimaryMaterial(v114[0]);\n\tthis.sourceMaterial = v69;\nL_0050:\n\treturn;\n\tv115 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			if (sourceMaterial == null)
			{
				SkeletonGraphic component = GetComponent<SkeletonGraphic>();
				if (component != null)
				{
					SkeletonDataAsset skeletonDataAsset = component.skeletonDataAsset;
					AtlasAssetBase[] atlasAssets = skeletonDataAsset.atlasAssets;
					Material primaryMaterial = atlasAssets[0].PrimaryMaterial;
					sourceMaterial = primaryMaterial;
				}
			}
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__13))]
		[Token(Token = "0x600010F")]
		[Address(RVA = "0x1512E60", Offset = "0x1512E60", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.MixAndMatchGraphic+<Start>d__13;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A53]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.MixAndMatchGraphic+<Start>d__13();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__13 _003CStart_003Ed__14 = null;
			_003CStart_003Ed__14._003C_003E1__state = 0;
			_003CStart_003Ed__14._003C_003E4__this = this;
			return _003CStart_003Ed__14;
		}

		[ContextMenu("Apply")]
		[Token(Token = "0x6000110")]
		[Address(RVA = "0x1512EE8", Offset = "0x1512EE8", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv34 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv63 = UnityEngine.Object;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv173 = Spine.Skin;\n\tv174 = \"il2cpp_codegen_initialize_runtime_metadata\"(v173, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv216 = \"repacked skin\";\n\tv217 = \"il2cpp_codegen_initialize_runtime_metadata\"(v216, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv222 = \"custom skin\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v222, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37A54]) = v54;\nL_002C:\n\tv57 = UnityEngine.Component::GetComponent(this);\n\tv144 = this.customSkin;\n\tv169 = v57.skeleton;\n\tv70 = this.customSkin == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_003F;\n\tv176 = new Spine.Skin();\n\tSpine.Skin::.ctor(v176, \"custom skin\");\nL_003F:\n\tthis.customSkin = v144;\n\tv225 = Spine.SkeletonData::FindSkin(v169.data, this.baseSkinName);\n\tv152 = Spine.Skeleton::FindSlotIndex(v169, this.visorSlot);\n\tv281 = Spine.Skin::GetAttachment(v225, v152, this.visorKey);\n\tv153 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetRemappedClone(v281, this.visorSprite, this.sourceMaterial, 1, 1, 0, 1);\n\tSpine.Skin::SetAttachment(this.customSkin, v152, this.visorKey, v153);\n\tv290 = Spine.Skeleton::FindSlotIndex(v169, this.gunSlot);\n\tv295 = Spine.Skin::GetAttachment(v225, v290, this.gunKey);\n\tv297 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetRemappedClone(v295, this.gunSprite, this.sourceMaterial, 1, 1, 0, 1);\n\tv298 = v297 == 0;\n\tif (v298) goto L_0083;\n\tSpine.Skin::SetAttachment(this.customSkin, v290, this.gunKey, v297);\nL_0083:\n\tv208 = ~this.repack;\n\tif (v208) goto L_00F4;\n\tv155 = new Spine.Skin();\n\tSpine.Skin::.ctor(v155, \"repacked skin\");\n\tv168 = v169.data;\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(v155, v168.defaultSkin);\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(v155, this.customSkin);\n\tv125 = this + 0x70;\n\tgoto L_00A5;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v314, v309, v311, v123, v118, v109, v113, v105, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00A5:\n\tv322 = UnityEngine.Object::op_Implicit(*([v125 @ X23_v8 (UnityEngine.Material&)]));\n\tv324 = v322 == 0;\n\tif (v324) goto L_00B4;\n\tgoto L_00B2;\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v325, v321, v311, v123, v118, v109, v113, v105, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00B2:\n\tUnityEngine.Object::Destroy(*([v125 @ X23_v8 (UnityEngine.Material&)]));\nL_00B4:\n\tv147 = this + 0x68;\n\tgoto L_00C0;\n\tv345 = \"il2cpp_codegen_runtime_class_init\"(v339, v330, v311, v123, v118, v109, v113, v105, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00C0:\n\tv350 = UnityEngine.Object::op_Implicit(*([v147 @ X24_v10 (UnityEngine.Texture2D&)]));\n\tv352 = v350 == 0;\n\tif (v352) goto L_00D3;\n\tgoto L_00CD;\n\tv369 = \"il2cpp_codegen_runtime_class_init\"(v353, v349, v311, v123, v118, v109, v113, v105, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00CD:\n\tUnityEngine.Object::Destroy(*([v147 @ X24_v10 (UnityEngine.Texture2D&)]));\nL_00D3:\n\tgoto L_00E5;\n\tv371 = \"il2cpp_codegen_runtime_class_init\"(v365, v359, v311, v123, v118, v109, v113, v105, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00E5:\n\tv376 = Spine.Unity.AttachmentTools.AtlasUtilities::GetRepackedSkin(v155, \"repacked skin\", this.sourceMaterial, v125, v147, 0x400, 2, 4, 0, 1, 0, 0, v377, 0, v378);\n\tSpine.Skeleton::SetSkin(v169, v376);\n\tSpine.Skeleton::SetToSetupPose(v169);\n\tv381 = ~this.repack;\n\tv157 = ~v381;\n\tif (v157) goto L_00FD;\n\tthrow System.NullReferenceException;\nL_00F4:\n\tSpine.Skeleton::SetSkin(v169, this.customSkin);\n\tSpine.Skeleton::SetToSetupPose(v169);\nL_00FD:\n\tv258 = Spine.Unity.SkeletonGraphic::Update(v252, 0f);\n\tSpine.Unity.SkeletonGraphic::set_OverrideTexture(v252, this.runtimeAtlas);\n\tv276 = UnityEngine.Resources::UnloadUnusedAssets();\n\treturn;\n// 199 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Apply()
		{
			SkeletonGraphic component = GetComponent<SkeletonGraphic>();
			Skin skin = customSkin;
			Skeleton skeleton = component.Skeleton;
			if (customSkin == null)
			{
				Skin skin2 = new Skin("custom skin");
				skin = skin2;
			}
			customSkin = skin;
			Skin skin3 = skeleton.Data.FindSkin(baseSkinName);
			int slotIndex = skeleton.FindSlotIndex(visorSlot);
			Attachment attachment = skin3.GetAttachment(slotIndex, visorKey);
			Attachment remappedClone = attachment.GetRemappedClone(visorSprite, sourceMaterial);
			customSkin.SetAttachment(slotIndex, visorKey, remappedClone);
			int slotIndex2 = skeleton.FindSlotIndex(gunSlot);
			Attachment attachment2 = skin3.GetAttachment(slotIndex2, gunKey);
			Attachment remappedClone2 = attachment2.GetRemappedClone(gunSprite, sourceMaterial);
			if (remappedClone2 != null)
			{
				customSkin.SetAttachment(slotIndex2, gunKey, remappedClone2);
			}
			bool flag = !repack;
			SkeletonGraphic skeletonGraphic = component;
			if (!flag)
			{
				Skin skin4 = new Skin("repacked skin");
				SkeletonData data = skeleton.Data;
				skin4.AddAttachments(data.DefaultSkin);
				skin4.AddAttachments(customSkin);
				ref Material reference = ref *(Material*)((nint)this + 112);
				if ((bool)reference)
				{
					UnityEngine.Object.Destroy(reference);
				}
				ref Texture2D reference2 = ref *(Texture2D*)((nint)this + 104);
				if ((bool)reference2)
				{
					UnityEngine.Object.Destroy(reference2);
				}
				Texture2D[] additionalOutputTextures = default(Texture2D[]);
				bool[] additionalTextureIsLinear = default(bool[]);
				Skin repackedSkin = skin4.GetRepackedSkin("repacked skin", sourceMaterial, out reference, out reference2, 1024, 2, TextureFormat.RGBA32, mipmaps: false, useOriginalNonrenderables: true, clearCache: false, null, additionalOutputTextures, null, additionalTextureIsLinear);
				skeleton.SetSkin(repackedSkin);
				skeleton.SetToSetupPose();
				bool flag2 = !repack;
				bool flag3 = !flag2;
				skeletonGraphic = component;
				if (!flag3)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				skeleton.SetSkin(customSkin);
				skeleton.SetToSetupPose();
			}
			skeletonGraphic.Update(0f);
			skeletonGraphic.OverrideTexture = runtimeAtlas;
			AsyncOperation asyncOperation = Resources.UnloadUnusedAssets();
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x1513278", Offset = "0x1513278", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = \"base\";\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv60 = \"goggles\";\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv63 = \"gun\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A55]) = v46;\nL_0023:\n\tthis.baseSkinName = \"base\";\n\tthis.visorKey = \"goggles\";\n\tthis.repack = 1;\n\tthis.gunKey = \"gun\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MixAndMatchGraphic()
		{
			baseSkinName = "base";
			visorKey = "goggles";
			repack = true;
			gunKey = "gun";
		}
	}
}
