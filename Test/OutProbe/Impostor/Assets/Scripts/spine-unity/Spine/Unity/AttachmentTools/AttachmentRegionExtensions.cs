using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.AttachmentTools
{
	[Token(Token = "0x20000CA")]
	public static class AttachmentRegionExtensions
	{
		[Token(Token = "0x6000729")]
		[Address(RVA = "0x15773E4", Offset = "0x15773E4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Spine.AtlasRegion;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = Spine.IHasRendererObject;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37D1B]) = v38;\nL_0018:\n\t// 24 IsInst v41 @ X0_v3 (Spine.IHasRendererObject), typeof(Spine.IHasRendererObject), attachment @ X0 (Spine.Attachment)\n\tv44 = v41 == 0;\n\tif (v44) goto L_0073;\n\tgoto L_0046;\n\tv132 = *([v45 @ X8_v4+B0]);\n\tv133 = v132 + 8;\n\tv135 = *([v171 @ X10_v7-8]);\n\tv177 = v135 == v46;\n\tif (v177) goto L_003F;\n\tv157 = v172 - 1;\n\tv155 = v171 + 0x10;\n\tv137 = v172 != 1;\n\tif (v137) goto L_FFFFFFFF;\n\tv158 = v47;\n\tv159 = 0;\n\tv160 = 0xB349B4(v158, v46, v159, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0046;\nL_003F:\n\tv183 = *([v171 @ X10_v7]);\n\tv184 = v183 << 4;\n\tv185 = v45 + v184;\n\tv186 = v185 + 0x138;\nL_0046:\n\tv119 = Spine.IHasRendererObject::get_RendererObject(v41);\n\tv123 = v119 == 0;\n\tif (v123) goto L_0073;\n\tgoto L_FFFFFFFF;\n\tgoto L_0073;\n\tv52 = v52_asT == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tgoto L_0073;\nL_0073:\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion GetRegion(this Attachment attachment)
		{
			IHasRendererObject hasRendererObject = attachment as IHasRendererObject;
			bool flag = hasRendererObject == null;
			AtlasRegion result = (AtlasRegion)hasRendererObject;
			if (!flag)
			{
				object rendererObject = hasRendererObject.RendererObject;
				bool flag2 = rendererObject == null;
				result = (AtlasRegion)rendererObject;
				if (!flag2)
				{
					AtlasRegion atlasRegion = rendererObject as AtlasRegion;
					result = (AtlasRegion)((atlasRegion == null) ? null : rendererObject);
				}
			}
			return result;
		}

		[Token(Token = "0x600072A")]
		[Address(RVA = "0x15774DC", Offset = "0x15774DC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = Spine.AtlasRegion;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37D1C]) = v33;\nL_0013:\n\tv36 = regionAttachment.<RendererObject>k__BackingField == 0;\n\tif (v36) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003E;\n\tv91 = v91_asT == 0;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion GetRegion(this RegionAttachment regionAttachment)
		{
			if (regionAttachment.RendererObject == null)
			{
				return null;
			}
			AtlasRegion atlasRegion = regionAttachment.RendererObject as AtlasRegion;
			if (atlasRegion != null)
			{
				return (AtlasRegion)regionAttachment.RendererObject;
			}
			return null;
		}

		[Token(Token = "0x600072B")]
		[Address(RVA = "0x1577560", Offset = "0x1577560", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = Spine.AtlasRegion;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37D1D]) = v33;\nL_0013:\n\tv36 = meshAttachment.<RendererObject>k__BackingField == 0;\n\tif (v36) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003E;\n\tv91 = v91_asT == 0;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion GetRegion(this MeshAttachment meshAttachment)
		{
			if (meshAttachment.RendererObject == null)
			{
				return null;
			}
			AtlasRegion atlasRegion = meshAttachment.RendererObject as AtlasRegion;
			if (atlasRegion != null)
			{
				return (AtlasRegion)meshAttachment.RendererObject;
			}
			return null;
		}

		[Token(Token = "0x600072C")]
		[Address(RVA = "0x15775E4", Offset = "0x15775E4", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = Spine.MeshAttachment;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, region, updateOffset, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Spine.RegionAttachment;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, region, updateOffset, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37D1E]) = v40;\nL_0017:\n\tv41 = attachment == 0;\n\tif (v41) goto L_0062;\n\tv121 = attachment->klass;\n\tv115 = attachment->klass->typeHierarchyDepth;\n\tgoto L_FFFFFFFF;\n\tv141 = v141_asT == 0;\n\tif (v141) goto L_0041;\n\tSpine.Unity.AttachmentTools.AttachmentRegionExtensions::SetRegion(attachment, region, updateOffset);\n\tv121 = attachment->klass;\n\tv115 = attachment->klass->typeHierarchyDepth;\nL_0041:\n\tv112 = Spine.MeshAttachment;\n\tv157 = v115 < *([v112 @ X10_v3 (Il2CppClass<Spine.MeshAttachment>)+130]);\n\tv107 = ~v157;\n\tv74 = ~v107;\n\tif (v74) goto L_0062;\n\tv67 = *([v112 @ X10_v3 (Il2CppClass<Spine.MeshAttachment>)+130]) << 3;\n\tv190 = *([v121 @ X8_v5 (Il2CppClass<Spine.Attachment>)+C8]) + v67;\n\tv93 = *([v190 @ X8_v7-8]) == Spine.MeshAttachment;\n\tif (v93) goto L_006C;\nL_0062:\n\treturn;\nL_006C:\n\tSpine.Unity.AttachmentTools.AttachmentRegionExtensions::SetRegion(attachment, region, updateOffset);\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetRegion(this Attachment attachment, AtlasRegion region, bool updateOffset = true)
		{
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_010d: Expected I, but got O
			//IL_0065: Expected I, but got O
			//IL_0075: Expected O, but got I
			//IL_00a5: Expected O, but got I
			if (attachment == null)
			{
				return;
			}
			nint num = (nint)attachment;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X8_v5 (Il2CppClass<Spine.Attachment>)+130]");
			object obj = 0;
			RegionAttachment regionAttachment = attachment as RegionAttachment;
			if (regionAttachment != null)
			{
				((RegionAttachment)attachment).SetRegion(region, updateOffset);
				num = (nint)attachment;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X8_v5 (Il2CppClass<Spine.Attachment>)+130]");
				obj = 0;
			}
			nint num2 = (nint)typeof(MeshAttachment);
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X10_v3 (Il2CppClass<Spine.MeshAttachment>)+130]");
			if ((nint)obj2 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X10_v3 (Il2CppClass<Spine.MeshAttachment>)+130]");
				int num3 = (int)((nint)0 << 3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X8_v5 (Il2CppClass<Spine.Attachment>)+C8]");
				object obj3 = (nint)0 + (nint)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X8_v7-8]");
				if (0 == (nint)typeof(MeshAttachment))
				{
					((MeshAttachment)attachment).SetRegion(region, updateOffset);
				}
			}
		}

		[Token(Token = "0x600072D")]
		[Address(RVA = "0x157731C", Offset = "0x157731C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = region == 0;\n\tif (v8) goto L_0032;\n\tattachment.<RendererObject>k__BackingField = region;\n\tSpine.RegionAttachment::SetUVs(attachment, region.u, region.v, region.u2, region.v2, region.rotate);\n\tattachment.regionOffsetX = region.offsetX;\n\t// 24 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tattachment.regionWidth = region.width;\n\t// 27 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tattachment.regionOriginalWidth = region.originalWidth;\n\tv54 = updateOffset == 0;\n\tif (v54) goto L_002E;\n\tSpine.RegionAttachment::UpdateOffset(attachment);\n\treturn;\nL_002E:\n\treturn;\nL_0032:\n\tv49 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v49, \"region\");\n\tthrow v49;\n\tthrow System.NullReferenceException;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetRegion(this RegionAttachment attachment, AtlasRegion region, bool updateOffset = true)
		{
			//IL_008e: Expected F4, but got I4
			//IL_00aa: Expected F4, but got I4
			if (region != null)
			{
				attachment.RendererObject = region;
				attachment.SetUVs(region.u, region.v, region.u2, region.v2, region.rotate);
				attachment.RegionOffsetX = region.offsetX;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				attachment.RegionWidth = region.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				attachment.RegionOriginalWidth = region.originalWidth;
				if (updateOffset)
				{
					attachment.UpdateOffset();
				}
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("region");
			throw ex;
		}

		[Token(Token = "0x600072E")]
		[Address(RVA = "0x1576D84", Offset = "0x1576D84", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = region == 0;\n\tif (v4) goto L_0024;\n\tattachment.<RendererObject>k__BackingField = region;\n\tattachment.<RegionU>k__BackingField = region.u;\n\tattachment.<RegionRotate>k__BackingField = region.rotate;\n\tattachment.regionOffsetX = region.offsetX;\n\t// 15 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tattachment.regionWidth = region.width;\n\t// 18 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tattachment.regionOriginalWidth = region.originalWidth;\n\tv31 = updateUVs == 0;\n\tif (v31) goto L_0020;\n\tSpine.MeshAttachment::UpdateUVs(attachment);\n\treturn;\nL_0020:\n\treturn;\nL_0024:\n\tv42 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v42, \"region\");\n\tthrow v42;\n\tthrow System.NullReferenceException;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetRegion(this MeshAttachment attachment, AtlasRegion region, bool updateUVs = true)
		{
			//IL_007c: Expected F4, but got I4
			//IL_0098: Expected F4, but got I4
			if (region != null)
			{
				attachment.RendererObject = region;
				attachment.RegionU = region.u;
				attachment.RegionRotate = region.rotate;
				attachment.RegionOffsetX = region.offsetX;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				attachment.RegionWidth = region.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				attachment.RegionOriginalWidth = region.originalWidth;
				if (updateUVs)
				{
					attachment.UpdateUVs();
				}
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("region");
			throw ex;
		}

		[Token(Token = "0x600072F")]
		[Address(RVA = "0x15776D0", Offset = "0x15776D0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, material, methodInfo, v29, v30, v31, v32, v33, rotation, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37D1F]) = v43;\nL_001B:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, material, methodInfo, v29, v30, v31, v32, v33, rotation, v34, v35, v36, v37, v38, v39, v40);\nL_001F:\n\tv52 = Spine.Unity.AttachmentTools.AtlasUtilities::ToSpineAtlasPage(material);\n\treturnVal1 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachment(sprite, v52, rotation);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment ToRegionAttachment(this Sprite sprite, Material material, float rotation = 0f)
		{
			AtlasPage page = material.ToSpineAtlasPage();
			return sprite.ToRegionAttachment(page, rotation);
		}

		[Token(Token = "0x6000730")]
		[Address(RVA = "0x1577750", Offset = "0x1577750", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, page, methodInfo, v31, v32, v33, v34, v35, rotation, v36, v37, v38, v39, v40, v41, v42);\n\tv52 = UnityEngine.Object;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, page, methodInfo, v31, v32, v33, v34, v35, rotation, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37D20]) = v46;\nL_001F:\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v47, page, methodInfo, v31, v32, v33, v34, v35, rotation, v36, v37, v38, v39, v40, v41, v42);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(sprite, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0053;\n\tv62 = page == 0;\n\tif (v62) goto L_005B;\n\tgoto L_0036;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, v56, v57, v31, v32, v33, v34, v35, rotation, v36, v37, v38, v39, v40, v41, v42);\nL_0036:\n\tv81 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(sprite, page);\n\tv97 = UnityEngine.Sprite::get_pixelsPerUnit(sprite);\n\tv113 = 1f / v97;\n\tv114 = UnityEngine.Object::get_name(sprite);\n\treturnVal2 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachment(v81, v114, v113, rotation);\n\treturn returnVal2;\nL_0053:\n\tv75 = new System.ArgumentNullException();\n\tgoto L_0063;\nL_005B:\n\tv82 = new System.ArgumentNullException();\nL_0063:\n\tSystem.ArgumentNullException::.ctor(v92, v90);\n\tthrow v92;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment ToRegionAttachment(this Sprite sprite, AtlasPage page, float rotation = 0f)
		{
			ArgumentNullException ex2;
			if (!(sprite == null))
			{
				if (page != null)
				{
					AtlasRegion region = sprite.ToAtlasRegion(page);
					float pixelsPerUnit = sprite.pixelsPerUnit;
					float scale = 1f / pixelsPerUnit;
					string name = sprite.name;
					return region.ToRegionAttachment(name, scale, rotation);
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "page";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "sprite";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x6000731")]
		[Address(RVA = "0x1577A58", Offset = "0x1577A58", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv40 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v43, v44, rotation, v45, v46, v47, v48, v49, v50, v51);\n\tv61 = UnityEngine.Object;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v43, v44, rotation, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37D21]) = v55;\nL_0025:\n\tgoto L_002A;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v56, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v43, v44, rotation, v45, v46, v47, v48, v49, v50, v51);\nL_002A:\n\tv67 = UnityEngine.Object::op_Equality(sprite, 0);\n\tv69 = v67 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_006B;\n\tgoto L_0038;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v71, v65, v66, mipmaps, materialPropertySource, methodInfo, v43, v44, rotation, v45, v46, v47, v48, v49, v50, v51);\nL_0038:\n\tv83 = UnityEngine.Object::op_Equality(shader, 0);\n\tv86 = v83 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0073;\n\tgoto L_004B;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v93, v81, v82, mipmaps, materialPropertySource, methodInfo, v43, v44, rotation, v45, v46, v47, v48, v49, v50, v51);\nL_004B:\n\tv117 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegionPMAClone(sprite, shader, textureFormat, mipmaps, materialPropertySource);\n\tv130 = UnityEngine.Sprite::get_pixelsPerUnit(sprite);\n\tv147 = 1f / v130;\n\tv148 = UnityEngine.Object::get_name(sprite);\n\treturnVal2 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachment(v117, v148, v147, rotation);\n\treturn returnVal2;\nL_006B:\n\tv84 = new System.ArgumentNullException();\n\tgoto L_007B;\nL_0073:\n\tv118 = new System.ArgumentNullException();\nL_007B:\n\tSystem.ArgumentNullException::.ctor(v105, v102);\n\tthrow v105;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment ToRegionAttachmentPMAClone(this Sprite sprite, Shader shader, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, Material materialPropertySource = null, float rotation = 0f)
		{
			ArgumentNullException ex2;
			if (!(sprite == null))
			{
				if (!(shader == null))
				{
					AtlasRegion region = sprite.ToAtlasRegionPMAClone(shader, textureFormat, mipmaps, materialPropertySource);
					float pixelsPerUnit = sprite.pixelsPerUnit;
					float scale = 1f / pixelsPerUnit;
					string name = sprite.name;
					return region.ToRegionAttachment(name, scale, rotation);
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "shader";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "sprite";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x6000732")]
		[Address(RVA = "0x1577BF0", Offset = "0x1577BF0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = UnityEngine.Material::get_shader(materialPropertySource);\n\treturnVal2 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachmentPMAClone(sprite, v25, textureFormat, mipmaps, materialPropertySource, rotation);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment ToRegionAttachmentPMAClone(this Sprite sprite, Material materialPropertySource, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, float rotation = 0f)
		{
			Shader shader = materialPropertySource.shader;
			return sprite.ToRegionAttachmentPMAClone(shader, textureFormat, mipmaps, materialPropertySource, rotation);
		}

		[Token(Token = "0x6000733")]
		[Address(RVA = "0x15778A8", Offset = "0x15778A8", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = Spine.RegionAttachment;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, attachmentName, methodInfo, v27, v28, v29, v30, v31, scale, rotation, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37D22]) = v40;\nL_0017:\n\tv43 = System.String::IsNullOrEmpty(attachmentName);\n\tv45 = v43 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0059;\n\tv47 = region == 0;\n\tif (v47) goto L_006B;\n\tv54 = new Spine.RegionAttachment();\n\tSpine.RegionAttachment::.ctor(v54, attachmentName);\n\tv54.<RendererObject>k__BackingField = region;\n\tSpine.RegionAttachment::SetUVs(v54, region.u, region.v, region.u2, region.v2, region.rotate);\n\tv54.regionOffsetX = region.offsetX;\n\t// 57 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv54.regionWidth = region.width;\n\t// 60 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv54.regionOriginalWidth = region.originalWidth;\n\tv115 = region.originalWidth * v116;\n\tv54.scaleX = 0f;\n\tv54.r = 0f;\n\tv54.width = v115;\n\tv54.rotation = rotation;\n\tv54.<Path>k__BackingField = region.name;\n\t// 73 MakeStruct v121 @ AGG157B99C_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 1f, 1f, 1f, 1f\n\tSpine.Unity.SkeletonExtensions::SetColor(v54, v121);\n\tSpine.RegionAttachment::UpdateOffset(v54);\n\treturn v54;\nL_0059:\n\tv58 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v58, \"attachmentName can't be null or empty.\", \"attachmentName\");\n\tgoto L_0079;\nL_006B:\n\tv62 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v62, \"region\");\nL_0079:\n\tthrow v94;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RegionAttachment ToRegionAttachment(this AtlasRegion region, string attachmentName, float scale = 0.01f, float rotation = 0f)
		{
			//IL_00a6: Expected F4, but got I4
			//IL_00c2: Expected F4, but got I4
			//IL_00d5: Expected O, but got I
			//IL_00fe: Expected F4, but got O
			if (!string.IsNullOrEmpty(attachmentName))
			{
				if (region != null)
				{
					RegionAttachment regionAttachment = new RegionAttachment(attachmentName);
					regionAttachment.RendererObject = region;
					regionAttachment.SetUVs(region.u, region.v, region.u2, region.v2, region.rotate);
					regionAttachment.RegionOffsetX = region.offsetX;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					regionAttachment.RegionWidth = region.width;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					regionAttachment.RegionOriginalWidth = region.originalWidth;
					object obj2 = default(object);
					object obj = region.originalWidth * (nint)obj2;
					regionAttachment.ScaleX = 0f;
					regionAttachment.R = 0f;
					regionAttachment.Width = (float)obj;
					regionAttachment.Rotation = rotation;
					regionAttachment.Path = region.name;
					Color color = default(Color);
					color.r = 1f;
					color.g = 1f;
					color.b = 1f;
					color.a = 1f;
					regionAttachment.SetColor(color);
					regionAttachment.UpdateOffset();
					return regionAttachment;
				}
				ArgumentNullException ex = new ArgumentNullException("region");
			}
			else
			{
				ArgumentException ex2 = new ArgumentException("attachmentName can't be null or empty.", "attachmentName");
			}
			object obj3 = default(object);
			throw obj3;
		}

		[Token(Token = "0x6000734")]
		[Address(RVA = "0x1577C54", Offset = "0x1577C54", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tregionAttachment.scaleX = scale;\n\tregionAttachment.scaleY = scale.y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetScale(this RegionAttachment regionAttachment, Vector2 scale)
		{
			Vector2 vector = default(Vector2);
			regionAttachment.ScaleX = vector.x;
			regionAttachment.ScaleY = scale.y;
		}

		[Token(Token = "0x6000735")]
		[Address(RVA = "0x1577C6C", Offset = "0x1577C6C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tregionAttachment.scaleX = x;\n\tregionAttachment.scaleY = y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetScale(this RegionAttachment regionAttachment, float x, float y)
		{
			regionAttachment.ScaleX = x;
			regionAttachment.ScaleY = y;
		}

		[Token(Token = "0x6000736")]
		[Address(RVA = "0x1577C84", Offset = "0x1577C84", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tregionAttachment.x = offset;\n\tregionAttachment.y = offset.y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetPositionOffset(this RegionAttachment regionAttachment, Vector2 offset)
		{
			Vector2 vector = default(Vector2);
			regionAttachment.X = vector.x;
			regionAttachment.Y = offset.y;
		}

		[Token(Token = "0x6000737")]
		[Address(RVA = "0x1577C9C", Offset = "0x1577C9C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tregionAttachment.x = x;\n\tregionAttachment.y = y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetPositionOffset(this RegionAttachment regionAttachment, float x, float y)
		{
			regionAttachment.X = x;
			regionAttachment.Y = y;
		}

		[Token(Token = "0x6000738")]
		[Address(RVA = "0x1577CB4", Offset = "0x1577CB4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tregionAttachment.rotation = rotation;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetRotation(this RegionAttachment regionAttachment, float rotation)
		{
			regionAttachment.Rotation = rotation;
		}
	}
}
