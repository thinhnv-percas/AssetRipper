using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.AttachmentTools
{
	[Token(Token = "0x20000C9")]
	public static class AttachmentCloneExtensions
	{
		[Token(Token = "0x6000723")]
		[Address(RVA = "0x1576C64", Offset = "0x1576C64", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = Spine.MeshAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, cloneMeshesAsLinked, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37D17]) = v36;\nL_0016:\n\tv40 = o->klass;\n\tgoto L_FFFFFFFF;\n\tv68 = v68_asT == 0;\n\tif (v68) goto L_FFFFFFFF;\n\tgoto L_0038;\nL_0038:\n\tv87 = v84 == 0;\n\tif (v87) goto L_0045;\n\tv86 = cloneMeshesAsLinked == 0;\n\tif (v86) goto L_0045;\n\treturnVal2 = Spine.MeshAttachment::NewLinkedMesh(v84);\n\treturn returnVal2;\nL_0045:\n\tv88 = o->klass->vtable[4];\n\tv89 = o->klass->vtable[4];\n\t// 77 IndirectJump v88 @ X2_v1, o @ X0 (Spine.Attachment), o @ X0 (Spine.Attachment), v89 @ X1_v1, v88 @ X2_v1, v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Attachment GetCopy(this Attachment o, bool cloneMeshesAsLinked)
		{
			//IL_000d: Expected I, but got O
			//IL_0092: Expected O, but got I
			//IL_00a2: Expected O, but got I
			nint num = (nint)o;
			MeshAttachment meshAttachment = o as MeshAttachment;
			MeshAttachment meshAttachment2 = (MeshAttachment)((meshAttachment == null) ? null : o);
			while (meshAttachment2 == null || !cloneMeshesAsLinked)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<Spine.Attachment>)+178]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<Spine.Attachment>)+180]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v88 @ X2_v1 (should have been resolved before IL gen)");
			}
			return meshAttachment2.NewLinkedMesh();
		}

		[Token(Token = "0x6000724")]
		[Address(RVA = "0x1576CFC", Offset = "0x1576CFC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = region == 0;\n\tif (v6) goto L_0018;\n\tv29 = Spine.MeshAttachment::NewLinkedMesh(o);\n\tSpine.Unity.AttachmentTools.AttachmentRegionExtensions::SetRegion(v29, region, 0);\n\treturn v29;\nL_0018:\n\tv40 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v40, \"region\");\n\tthrow v40;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static MeshAttachment GetLinkedMesh(this MeshAttachment o, string newLinkedMeshName, AtlasRegion region)
		{
			if (region != null)
			{
				MeshAttachment meshAttachment = o.NewLinkedMesh();
				meshAttachment.SetRegion(region, updateUVs: false);
				return meshAttachment;
			}
			ArgumentNullException ex = new ArgumentNullException("region");
			throw ex;
		}

		[Token(Token = "0x6000725")]
		[Address(RVA = "0x1576E28", Offset = "0x1576E28", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, sprite, shader, materialPropertySource, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv55 = UnityEngine.Material;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, sprite, shader, materialPropertySource, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv61 = UnityEngine.Object;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, sprite, shader, materialPropertySource, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37D18]) = v51;\nL_0023:\n\tv53 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v53, shader);\n\tgoto L_0031;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v62, v57, v58, materialPropertySource, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0031:\n\tv71 = UnityEngine.Object::op_Inequality(materialPropertySource, 0);\n\tv73 = v71 == 0;\n\tif (v73) goto L_004A;\n\tUnityEngine.Material::CopyPropertiesFromMaterial(v53, materialPropertySource);\n\tv103 = UnityEngine.Material::get_shaderKeywords(materialPropertySource);\n\tUnityEngine.Material::set_shaderKeywords(v53, v103);\nL_004A:\n\tv96 = UnityEngine.Object::get_name(sprite);\n\tgoto L_0054;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v97, v95, v75, materialPropertySource, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0054:\n\tv132 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(sprite, 0);\n\treturnVal2 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetLinkedMesh(o, 0, v132);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static MeshAttachment GetLinkedMesh(this MeshAttachment o, Sprite sprite, Shader shader, Material materialPropertySource = null)
		{
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				string[] shaderKeywords = materialPropertySource.shaderKeywords;
				material.shaderKeywords = shaderKeywords;
			}
			string name = sprite.name;
			AtlasRegion region = sprite.ToAtlasRegion();
			return o.GetLinkedMesh(null, region);
		}

		[Token(Token = "0x6000726")]
		[Address(RVA = "0x1576F58", Offset = "0x1576F58", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.Material::get_shader(materialPropertySource);\n\treturnVal2 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetLinkedMesh(o, sprite, v17, materialPropertySource);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static MeshAttachment GetLinkedMesh(this MeshAttachment o, Sprite sprite, Material materialPropertySource)
		{
			Shader shader = materialPropertySource.shader;
			return o.GetLinkedMesh(sprite, shader, materialPropertySource);
		}

		[Token(Token = "0x6000727")]
		[Address(RVA = "0x1576F9C", Offset = "0x1576F9C", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, sprite, sourceMaterial, premultiplyAlpha, cloneMeshAsLinked, useOriginalRegionSize, pivotShiftsMeshUVCoords, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv56 = UnityEngine.Material;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, sprite, sourceMaterial, premultiplyAlpha, cloneMeshAsLinked, useOriginalRegionSize, pivotShiftsMeshUVCoords, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv69 = Spine.MeshAttachment;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, sprite, sourceMaterial, premultiplyAlpha, cloneMeshAsLinked, useOriginalRegionSize, pivotShiftsMeshUVCoords, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37D19]) = v52;\nL_0023:\n\tv54 = premultiplyAlpha == 0;\n\tif (v54) goto L_0037;\n\tgoto L_0032;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v60, sprite, sourceMaterial, premultiplyAlpha, cloneMeshAsLinked, useOriginalRegionSize, pivotShiftsMeshUVCoords, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0032:\n\tv88 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegionPMAClone(sprite, sourceMaterial, 4, 0);\n\tgoto L_0055;\nL_0037:\n\tv67 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v67, sourceMaterial);\n\tv101 = UnityEngine.Sprite::get_texture(sprite);\n\tUnityEngine.Material::set_mainTexture(v67, v101);\n\tgoto L_0052;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v242, v187, v189, premultiplyAlpha, cloneMeshAsLinked, useOriginalRegionSize, pivotShiftsMeshUVCoords, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0052:\n\tv88 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(sprite, v67);\nL_0055:\n\tv97 = pivotShiftsMeshUVCoords == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0081;\n\tv169 = o == 0;\n\tif (v169) goto L_0081;\n\tgoto L_FFFFFFFF;\n\tv108 = v108_asT == 0;\n\tif (v108) goto L_0081;\n\tv88.offsetX = 0f;\nL_0081:\n\tv186 = UnityEngine.Sprite::get_pixelsPerUnit(sprite);\n\tv195 = 1f / v186;\n\treturnVal2 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetRemappedClone(o, v88, cloneMeshAsLinked, useOriginalRegionSize, v195);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Attachment GetRemappedClone(this Attachment o, Sprite sprite, Material sourceMaterial, bool premultiplyAlpha = true, bool cloneMeshAsLinked = true, bool useOriginalRegionSize = false, bool pivotShiftsMeshUVCoords = true)
		{
			AtlasRegion atlasRegion;
			if (premultiplyAlpha)
			{
				atlasRegion = sprite.ToAtlasRegionPMAClone(sourceMaterial);
			}
			else
			{
				Material material = new Material(sourceMaterial);
				Texture2D texture = sprite.texture;
				material.mainTexture = texture;
				atlasRegion = sprite.ToAtlasRegion(material);
			}
			if (!pivotShiftsMeshUVCoords && o != null)
			{
				MeshAttachment meshAttachment = o as MeshAttachment;
				if (meshAttachment != null)
				{
					atlasRegion.offsetX = 0f;
				}
			}
			float pixelsPerUnit = sprite.pixelsPerUnit;
			float scale = 1f / pixelsPerUnit;
			return o.GetRemappedClone(atlasRegion, cloneMeshAsLinked, useOriginalRegionSize, scale);
		}

		[Token(Token = "0x6000728")]
		[Address(RVA = "0x1577134", Offset = "0x1577134", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = Spine.MeshAttachment;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, atlasRegion, cloneMeshAsLinked, useOriginalRegionSize, methodInfo, v31, v32, v33, scale, v34, v35, v36, v37, v38, v39, v40);\n\tv47 = Spine.RegionAttachment;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, atlasRegion, cloneMeshAsLinked, useOriginalRegionSize, methodInfo, v31, v32, v33, scale, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37D1A]) = v44;\nL_001A:\n\tv45 = o == 0;\n\tif (v45) goto L_0061;\n\tgoto L_FFFFFFFF;\n\tv136 = v136_asT != 0;\n\tif (v136) goto L_0066;\n\tgoto L_FFFFFFFF;\n\tv91 = v91_asT != 0;\n\tif (v91) goto L_009C;\nL_0061:\n\treturnVal1 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetCopy(o, 1);\n\treturn returnVal1;\nL_0066:\n\tv155 = Spine.Attachment::Copy(o);\n\tv157 = v155 == 0;\n\tif (v157) goto L_00DA;\n\tgoto L_FFFFFFFF;\n\tv308 = v308_asT == 0;\n\tif (v308) goto L_00D6;\n\tSpine.Unity.AttachmentTools.AttachmentRegionExtensions::SetRegion(v155, atlasRegion, 0);\n\tv372 = useOriginalRegionSize == 0;\n\tv373 = ~v372;\n\tif (v373) goto L_0099;\n\t// 148 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv386 = atlasRegion.width * v388;\n\tv155.width = v386;\nL_0099:\n\tSpine.RegionAttachment::UpdateOffset(v155);\n\tgoto L_00D4;\nL_009C:\n\tv294 = cloneMeshAsLinked == 0;\n\tif (v294) goto L_00A6;\n\tv345 = Spine.MeshAttachment::NewLinkedMesh(o);\n\tgoto L_00CB;\nL_00A6:\n\tv332 = Spine.Attachment::Copy(o);\n\tv333 = v332 == 0;\n\tif (v333) goto L_00CB;\n\tgoto L_FFFFFFFF;\n\tv312 = v312_asT == 0;\n\tif (v312) goto L_00D6;\nL_00CB:\n\tSpine.Unity.AttachmentTools.AttachmentRegionExtensions::SetRegion(v366, atlasRegion, 1);\nL_00D4:\n\treturn v383;\nL_00D6:\n\tthrow System.InvalidCastException;\nL_00DA:\n\tSpine.Unity.AttachmentTools.AttachmentRegionExtensions::SetRegion(v155, atlasRegion, 0);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Attachment GetRemappedClone(this Attachment o, AtlasRegion atlasRegion, bool cloneMeshAsLinked = true, bool useOriginalRegionSize = false, float scale = 0.01f)
		{
			//IL_0130: Expected O, but got I
			//IL_013d: Expected F4, but got O
			if (o != null)
			{
				RegionAttachment regionAttachment = o as RegionAttachment;
				if (regionAttachment != null)
				{
					Attachment attachment = o.Copy();
					if (attachment != null)
					{
						RegionAttachment regionAttachment2 = attachment as RegionAttachment;
						if (regionAttachment2 != null)
						{
							((RegionAttachment)attachment).SetRegion(atlasRegion, updateOffset: false);
							if (!useOriginalRegionSize)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
								object obj2 = default(object);
								object obj = atlasRegion.width * (nint)obj2;
								((RegionAttachment)attachment).Width = (float)obj;
							}
							((RegionAttachment)attachment).UpdateOffset();
							return attachment;
						}
						goto IL_0206;
					}
					((RegionAttachment)attachment).SetRegion(atlasRegion, updateOffset: false);
					return (Attachment)(object)new NullReferenceException();
				}
				MeshAttachment meshAttachment = o as MeshAttachment;
				if (meshAttachment != null)
				{
					MeshAttachment meshAttachment3;
					if (cloneMeshAsLinked)
					{
						MeshAttachment meshAttachment2 = ((MeshAttachment)o).NewLinkedMesh();
						meshAttachment3 = meshAttachment2;
					}
					else
					{
						Attachment attachment2 = o.Copy();
						bool flag = attachment2 == null;
						meshAttachment3 = (MeshAttachment)attachment2;
						if (!flag)
						{
							MeshAttachment meshAttachment4 = attachment2 as MeshAttachment;
							bool flag2 = meshAttachment4 == null;
							meshAttachment3 = (MeshAttachment)attachment2;
							if (flag2)
							{
								goto IL_0206;
							}
						}
					}
					meshAttachment3.SetRegion(atlasRegion);
					return meshAttachment3;
				}
			}
			return o.GetCopy(cloneMeshesAsLinked: true);
			IL_0206:
			throw new InvalidCastException();
		}
	}
}
