using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200003A")]
	public class EquipSystemExample : MonoBehaviour, IHasSkeletonDataAsset
	{
		[Serializable]
		[Token(Token = "0x200003B")]
		public class EquipHook
		{
			[Token(Token = "0x4000129")]
			[FieldOffset(Offset = "0x10")]
			public EquipType type;

			[SpineSlot(null, null, false, true, false)]
			[Token(Token = "0x400012A")]
			[FieldOffset(Offset = "0x18")]
			public string slot;

			[SpineSkin(null, null, true, false, false)]
			[Token(Token = "0x400012B")]
			[FieldOffset(Offset = "0x20")]
			public string templateSkin;

			[SpineAttachment(true, false, false, null, null, "templateSkin", true, false)]
			[Token(Token = "0x400012C")]
			[FieldOffset(Offset = "0x28")]
			public string templateAttachment;

			[Token(Token = "0x60000F0")]
			[Address(RVA = "0x1511B74", Offset = "0x1511B74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public EquipHook()
			{
			}
		}

		[Token(Token = "0x200003C")]
		public enum EquipType
		{
			[Token(Token = "0x400012E")]
			Gun = 0,
			[Token(Token = "0x400012F")]
			Goggles = 1
		}

		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonDataAsset skeletonDataAsset;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x28")]
		public Material sourceMaterial;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x30")]
		public bool applyPMA;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x38")]
		public List<EquipHook> equippables;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x40")]
		public EquipsVisualsComponentExample target;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x48")]
		public Dictionary<EquipAssetExample, Attachment> cachedAttachments;

		[Token(Token = "0x17000017")]
		SkeletonDataAsset IHasSkeletonDataAsset.SkeletonDataAsset
		{
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x1511968", Offset = "0x1511968", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonDataAsset;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonDataAsset;
			}
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x1511424", Offset = "0x1511424", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, asset, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = System.Predicate`1<Spine.Unity.Examples.EquipSystemExample+EquipHook>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, asset, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, asset, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = Spine.Unity.Examples.EquipSystemExample+<>c__DisplayClass10_0;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, asset, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37A44]) = v43;\nL_0020:\n\tv45 = new Spine.Unity.Examples.EquipSystemExample+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v45);\n\tv45.equipType = asset.equipType;\n\tv79 = new System.Predicate`1<Spine.Unity.Examples.EquipSystemExample+EquipHook>();\n\tSystem.Predicate`1<Spine.Unity.Examples.EquipSystemExample+EquipHook>::.ctor(v79, v45, Il2CppMethodInfo);\n\tv80 = System.Collections.Generic.List`1<Spine.Unity.Examples.EquipSystemExample+EquipHook>::Find(this.equippables, v79);\n\tv81 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 1);\n\tv133 = Spine.SkeletonData::FindSlotIndex(v81, v80.slot);\n\tv82 = Spine.Unity.Examples.EquipSystemExample::GenerateAttachmentFromEquipAsset(this, asset, v133, v80.templateSkin, v80.templateAttachment);\n\tSpine.Unity.Examples.EquipsVisualsComponentExample::Equip(this.target, v133, v80.templateAttachment, v82);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Equip(EquipAssetExample asset)
		{
			EquipType equipType = asset.equipType;
			Predicate<EquipHook> match = delegate(EquipHook x)
			{
				int num = x.type - equipType;
				return num == 0;
			};
			EquipHook equipHook = equippables.Find(match);
			SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: true);
			int slotIndex = skeletonData.FindSlotIndex(equipHook.slot);
			Attachment attachment = GenerateAttachmentFromEquipAsset(asset, slotIndex, equipHook.templateSkin, equipHook.templateAttachment);
			target.Equip(slotIndex, equipHook.templateAttachment, attachment);
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x1511978", Offset = "0x1511978", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, asset, slotIndex, templateSkinName, templateAttachmentName, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, asset, slotIndex, templateSkinName, templateAttachmentName, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A45]) = v46;\nL_0024:\n\tv58 = System.Collections.Generic.Dictionary`2<Spine.Unity.Examples.EquipAssetExample, Spine.Attachment>::TryGetValue(this.cachedAttachments, asset, &v55 @ stack_-38_v3 (System.Object));\n\tv97 = v55 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0057;\n\tv84 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 1);\n\tv85 = Spine.SkeletonData::FindSkin(v84, templateSkinName);\n\tv86 = Spine.Skin::GetAttachment(v85, slotIndex, templateAttachmentName);\n\treturnVal2 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetRemappedClone(v86, asset.sprite, this.sourceMaterial, this.applyPMA, 1, 0, 1);\n\tSystem.Collections.Generic.Dictionary`2<Spine.Unity.Examples.EquipAssetExample, Spine.Attachment>::Add(this.cachedAttachments, asset, returnVal2);\nL_0057:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe Attachment GenerateAttachmentFromEquipAsset(EquipAssetExample asset, int slotIndex, string templateSkinName, string templateAttachmentName)
		{
			object value;
			bool flag = cachedAttachments.TryGetValue(asset, out *(Attachment*)(&value));
			bool flag2 = value == null;
			bool flag3 = !flag2;
			Attachment attachment = (Attachment)value;
			if (!flag3)
			{
				SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: true);
				Skin skin = skeletonData.FindSkin(templateSkinName);
				Attachment attachment2 = skin.GetAttachment(slotIndex, templateAttachmentName);
				attachment = attachment2.GetRemappedClone(asset.sprite, sourceMaterial, applyPMA);
				cachedAttachments.Add(asset, attachment);
			}
			return attachment;
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x1511A90", Offset = "0x1511A90", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.EquipsVisualsComponentExample::OptimizeSkin(this.target);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Done()
		{
			target.OptimizeSkin();
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x1511AA8", Offset = "0x1511AA8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv55 = System.Collections.Generic.Dictionary`2<Spine.Unity.Examples.EquipAssetExample, Spine.Attachment>;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = System.Collections.Generic.List`1<Spine.Unity.Examples.EquipSystemExample+EquipHook>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37A46]) = v50;\nL_0026:\n\tthis.applyPMA = 1;\n\tv53 = new System.Collections.Generic.List`1<Spine.Unity.Examples.EquipSystemExample+EquipHook>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.EquipSystemExample+EquipHook>::.ctor(v53);\n\tthis.equippables = v53;\n\tv63 = new System.Collections.Generic.Dictionary`2<Spine.Unity.Examples.EquipAssetExample, Spine.Attachment>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.Unity.Examples.EquipAssetExample, Spine.Attachment>::.ctor(v63);\n\tthis.cachedAttachments = v63;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EquipSystemExample()
		{
			applyPMA = true;
			List<EquipHook> list = new List<EquipHook>();
			equippables = list;
			Dictionary<EquipAssetExample, Attachment> dictionary = new Dictionary<EquipAssetExample, Attachment>();
			cachedAttachments = dictionary;
		}
	}
}
