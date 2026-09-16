using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000052")]
	public static class SpriteAttachmentExtensions
	{
		[Obsolete]
		[Token(Token = "0x6000159")]
		[Address(RVA = "0x1517900", Offset = "0x1517900", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = UnityEngine.Shader::Find(shaderName);\n\treturnVal1 = Spine.Unity.Examples.SpriteAttachmentExtensions::AttachUnitySprite(skeleton, slotName, sprite, v25, applyPMA, rotation);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment AttachUnitySprite(this Skeleton skeleton, string slotName, Sprite sprite, string shaderName = "Spine/Skeleton", bool applyPMA = true, float rotation = 0f)
		{
			Shader shader = Shader.Find(shaderName);
			return skeleton.AttachUnitySprite(slotName, sprite, shader, applyPMA, rotation);
		}

		[Obsolete]
		[Token(Token = "0x600015A")]
		[Address(RVA = "0x1517A4C", Offset = "0x1517A4C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = UnityEngine.Shader::Find(shaderName);\n\treturnVal1 = Spine.Unity.Examples.SpriteAttachmentExtensions::AddUnitySprite(skeletonData, slotName, sprite, skinName, v29, applyPMA, rotation);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment AddUnitySprite(this SkeletonData skeletonData, string slotName, Sprite sprite, string skinName = "", string shaderName = "Spine/Skeleton", bool applyPMA = true, float rotation = 0f)
		{
			Shader shader = Shader.Find(shaderName);
			return skeletonData.AddUnitySprite(slotName, sprite, skinName, shader, applyPMA, rotation);
		}

		[Obsolete]
		[Token(Token = "0x600015B")]
		[Address(RVA = "0x151795C", Offset = "0x151795C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = UnityEngine.Material;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, slotName, sprite, shader, applyPMA, methodInfo, v37, v38, rotation, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 1;\n\t*([1A37A75]) = v48;\nL_001B:\n\tv50 = applyPMA == 0;\n\tif (v50) goto L_0029;\n\tv75 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachmentPMAClone(sprite, shader, 4, 0, 0, rotation);\n\tgoto L_0039;\nL_0029:\n\tv62 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v62, shader);\n\tv75 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachment(sprite, v62, rotation);\nL_0039:\n\tv85 = Spine.Skeleton::FindSlot(skeleton, slotName);\n\tSpine.Slot::set_Attachment(v85, v75);\n\treturn v75;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment AttachUnitySprite(this Skeleton skeleton, string slotName, Sprite sprite, Shader shader, bool applyPMA, float rotation = 0f)
		{
			RegionAttachment regionAttachment;
			if (applyPMA)
			{
				regionAttachment = sprite.ToRegionAttachmentPMAClone(shader, TextureFormat.RGBA32, mipmaps: false, null, rotation);
			}
			else
			{
				Material material = new Material(shader);
				regionAttachment = sprite.ToRegionAttachment(material, rotation);
			}
			Slot slot = skeleton.FindSlot(slotName);
			slot.Attachment = regionAttachment;
			return regionAttachment;
		}

		[Obsolete]
		[Token(Token = "0x600015C")]
		[Address(RVA = "0x1517AB0", Offset = "0x1517AB0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = UnityEngine.Material;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, slotName, sprite, skinName, shader, applyPMA, methodInfo, v41, rotation, v42, v43, v44, v45, v46, v47, v48);\n\tv56 = \"\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, slotName, sprite, skinName, shader, applyPMA, methodInfo, v41, rotation, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37A76]) = v52;\nL_0020:\n\tv54 = applyPMA == 0;\n\tif (v54) goto L_002E;\n\tv81 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachmentPMAClone(sprite, shader, 4, 0, 0, rotation);\n\tgoto L_0040;\nL_002E:\n\tv68 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v68, shader);\n\tv81 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachment(sprite, v68, rotation);\nL_0040:\n\tv93 = Spine.SkeletonData::FindSlotIndex(skeletonData, slotName);\n\tv105 = skeletonData.defaultSkin;\n\tv112 = System.String::op_Inequality(skinName, \"\");\n\tv114 = v112 == 0;\n\tif (v114) goto L_004F;\n\tv148 = Spine.SkeletonData::FindSkin(skeletonData, skinName);\nL_004F:\n\tv150 = v105 == 0;\n\tif (v150) goto L_0064;\n\tSpine.Skin::SetAttachment(v105, v93, v81.<Name>k__BackingField, v81);\nL_0064:\n\treturn v81;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment AddUnitySprite(this SkeletonData skeletonData, string slotName, Sprite sprite, string skinName, Shader shader, bool applyPMA, float rotation = 0f)
		{
			RegionAttachment regionAttachment;
			if (applyPMA)
			{
				regionAttachment = sprite.ToRegionAttachmentPMAClone(shader, TextureFormat.RGBA32, mipmaps: false, null, rotation);
			}
			else
			{
				Material material = new Material(shader);
				regionAttachment = sprite.ToRegionAttachment(material, rotation);
			}
			int slotIndex = skeletonData.FindSlotIndex(slotName);
			Skin skin = skeletonData.DefaultSkin;
			if (skinName != "")
			{
				Skin skin2 = skeletonData.FindSkin(skinName);
				skin = skin2;
			}
			skin?.SetAttachment(slotIndex, regionAttachment.Name, regionAttachment);
			return regionAttachment;
		}
	}
}
