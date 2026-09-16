using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace Spine.Unity.AttachmentTools
{
	[Token(Token = "0x20000C7")]
	public static class AtlasUtilities
	{
		[Token(Token = "0x20000C8")]
		private struct IntAndAtlasRegionKey
		{
			[Token(Token = "0x4000451")]
			[FieldOffset(Offset = "0x0")]
			private int i;

			[Token(Token = "0x4000452")]
			[FieldOffset(Offset = "0x8")]
			private AtlasRegion region;

			[Token(Token = "0x6000721")]
			[Address(RVA = "0x1576C14", Offset = "0x1576C14", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.i = i;\n\tthis.region = region;\n\treturn;\n")]
			public IntAndAtlasRegionKey(int i, AtlasRegion region)
			{
				this.i = i;
				this.region = region;
			}

			[Token(Token = "0x6000722")]
			[Address(RVA = "0x1576C20", Offset = "0x1576C20", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = System.Int32::GetHashCode(this);\n\tv15 = System.Object::GetHashCode(this.region);\n\tv31 = v7 * 0x17;\n\treturnVal1 = v15 ^ v31;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override int GetHashCode()
			{
				int hashCode = ((int)this).GetHashCode();
				int hashCode2 = region.GetHashCode();
				int num = hashCode * 23;
				return hashCode2 ^ num;
			}
		}

		[Token(Token = "0x400044A")]
		internal const TextureFormat SpineTextureFormat = TextureFormat.RGBA32;

		[Token(Token = "0x400044B")]
		internal const float DefaultMipmapBias = -0.5f;

		[Token(Token = "0x400044C")]
		internal const bool UseMipMaps = false;

		[Token(Token = "0x400044D")]
		internal const float DefaultScale = 0.01f;

		[Token(Token = "0x400044E")]
		private const int NonrenderingRegion = -1;

		[Token(Token = "0x400044F")]
		private static Dictionary<IntAndAtlasRegionKey, Texture2D> CachedRegionTextures;

		[Token(Token = "0x4000450")]
		private static List<Texture2D> CachedRegionTexturesList;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		[Token(Token = "0x60006FE")]
		[Address(RVA = "0x1572AE0", Offset = "0x1572AE0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37CF8]) = v34;\nL_0015:\n\tgoto L_001B;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001B:\n\tSpine.Unity.AttachmentTools.AtlasUtilities::ClearCache();\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Init()
		{
			ClearCache();
		}

		[Token(Token = "0x60006FF")]
		[Address(RVA = "0x1572D38", Offset = "0x1572D38", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, materialPropertySource, methodInfo, v25, v26, v27, v28, v29, scale, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37CF9]) = v39;\nL_001A:\n\tv45 = UnityEngine.Material::get_shader(materialPropertySource);\n\tgoto L_002D;\n\tv52 = v47;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v52, v44, methodInfo, v25, v26, v27, v28, v29, scale, v30, v31, v32, v33, v34, v35, v36);\nL_002D:\n\treturnVal2 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(t, v45, scale, materialPropertySource);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegion(this Texture2D t, Material materialPropertySource, float scale = 0.01f)
		{
			Shader shader = materialPropertySource.shader;
			return t.ToAtlasRegion(shader, scale, materialPropertySource);
		}

		[Token(Token = "0x6000700")]
		[Address(RVA = "0x1572DC4", Offset = "0x1572DC4", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv34 = Spine.AtlasRegion;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, shader, materialPropertySource, methodInfo, v37, v38, v39, v40, scale, v41, v42, v43, v44, v45, v46, v47);\n\tv55 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, shader, materialPropertySource, methodInfo, v37, v38, v39, v40, scale, v41, v42, v43, v44, v45, v46, v47);\n\tv61 = UnityEngine.Material;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, shader, materialPropertySource, methodInfo, v37, v38, v39, v40, scale, v41, v42, v43, v44, v45, v46, v47);\n\tv68 = UnityEngine.Object;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, shader, materialPropertySource, methodInfo, v37, v38, v39, v40, scale, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37CFA]) = v51;\nL_0026:\n\tv53 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v53, shader);\n\tgoto L_0034;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v63, v57, v58, methodInfo, v37, v38, v39, v40, scale, v41, v42, v43, v44, v45, v46, v47);\nL_0034:\n\tv74 = UnityEngine.Object::op_Inequality(materialPropertySource, 0);\n\tv76 = v74 == 0;\n\tif (v76) goto L_004F;\n\tUnityEngine.Material::CopyPropertiesFromMaterial(v53, materialPropertySource);\n\tv124 = UnityEngine.Material::get_shaderKeywords(materialPropertySource);\n\tUnityEngine.Material::set_shaderKeywords(v53, v124);\n\tgoto L_004F;\nL_004F:\n\tUnityEngine.Material::set_mainTexture(v53, t);\n\tgoto L_0057;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v119, v88, v86, methodInfo, v37, v38, v39, v40, scale, v41, v42, v43, v44, v45, v46, v47);\nL_0057:\n\tv91 = Spine.Unity.AttachmentTools.AtlasUtilities::ToSpineAtlasPage(v53);\n\tv169 = UnityEngine.Texture::get_width(t);\n\tv173 = UnityEngine.Texture::get_height(t);\n\tv175 = new Spine.AtlasRegion();\n\tSpine.AtlasRegion::.ctor(v175);\n\tv92 = UnityEngine.Object::get_name(t);\n\tv175.name = v92;\n\tv175.rotate = 0;\n\tv175.index = 0xFFFFFFFF;\n\t// 124 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tgoto L_008E;\n\tv184 = UnityEngine.Vector2;\n\tv185 = \"il2cpp_codegen_initialize_runtime_metadata\"(v184, v89, v86, methodInfo, v37, v38, v39, v40, v181, v41, v42, v43, v44, v45, v46, v47);\n\tv188 = 1;\n\t*([1A35518]) = v188;\nL_008E:\n\tv132 = v1 * v194;\n\tv175.u = *([407EE0]);\n\tv175.x = 0;\n\tv197 = 0 - v153.zeroVector;\n\tv198 = v132 - v153.zeroVector;\n\tv199 = v197 / v198;\n\tv200 = 0x3F - v199;\n\t// 154 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv137 = v200 * v1;\n\tv175.width = v132;\n\tv175.offsetX = v137;\n\tv175.originalWidth = v132;\n\tv175.page = v91;\n\treturn v175;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegion(this Texture2D t, Shader shader, float scale = 0.01f, Material materialPropertySource = null)
		{
			//IL_0134: Expected F4, but got I
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				string[] shaderKeywords = materialPropertySource.shaderKeywords;
				material.shaderKeywords = shaderKeywords;
			}
			material.mainTexture = t;
			AtlasPage page = material.ToSpineAtlasPage();
			int width = t.width;
			int height = t.height;
			AtlasRegion atlasRegion = new AtlasRegion();
			string name = t.name;
			atlasRegion.name = name;
			atlasRegion.rotate = false;
			atlasRegion.index = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			object obj = default(object);
			object obj2 = default(object);
			int num = (int)((nint)obj * (nint)obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407EE0]");
			atlasRegion.u = 0f;
			atlasRegion.x = 0;
			atlasRegion.y = 0;
			float num2 = 0f - Vector2.zero.x;
			float num3 = (float)num - Vector2.zero.x;
			float num4 = num2 / num3;
			float num5 = 8.8E-44f - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			float offsetX = num5 * (float)obj;
			atlasRegion.width = num;
			atlasRegion.height = (int)((uint)num >> 32);
			atlasRegion.offsetX = offsetX;
			atlasRegion.originalWidth = num;
			atlasRegion.page = page;
			return atlasRegion;
		}

		[Token(Token = "0x6000701")]
		[Address(RVA = "0x1573100", Offset = "0x1573100", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, materialPropertySource, textureFormat, mipmaps, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37CFB]) = v42;\nL_001C:\n\tv48 = UnityEngine.Material::get_shader(materialPropertySource);\n\tgoto L_0031;\n\tv55 = v50;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v55, v47, textureFormat, mipmaps, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0031:\n\treturnVal2 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegionPMAClone(t, v48, textureFormat, mipmaps, materialPropertySource);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegionPMAClone(this Texture2D t, Material materialPropertySource, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false)
		{
			Shader shader = materialPropertySource.shader;
			return t.ToAtlasRegionPMAClone(shader, textureFormat, mipmaps, materialPropertySource);
		}

		[Token(Token = "0x6000702")]
		[Address(RVA = "0x1573194", Offset = "0x1573194", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv38 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = UnityEngine.Material;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv64 = UnityEngine.Object;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv71 = \"-pma-\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37CFC]) = v54;\nL_0028:\n\tv56 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v56, shader);\n\tgoto L_0036;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v66, v60, v61, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0036:\n\tv77 = UnityEngine.Object::op_Inequality(materialPropertySource, 0);\n\tv79 = v77 == 0;\n\tif (v79) goto L_004F;\n\tUnityEngine.Material::CopyPropertiesFromMaterial(v56, materialPropertySource);\n\tv144 = UnityEngine.Material::get_shaderKeywords(materialPropertySource);\n\tUnityEngine.Material::set_shaderKeywords(v56, v144);\nL_004F:\n\tgoto L_0056;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v91, v83, v81, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0056:\n\tv117 = Spine.Unity.AttachmentTools.AtlasUtilities::GetClone(t, textureFormat, mipmaps, 0, 1);\n\tv174 = UnityEngine.Object::get_name(t);\n\tv118 = System.String::Concat(v174, \"-pma-\");\n\tUnityEngine.Object::set_name(v117, v118);\n\tv119 = UnityEngine.Object::get_name(t);\n\tv180 = UnityEngine.Object::get_name(shader);\n\tv120 = System.String::Concat(v119, v180);\n\tUnityEngine.Object::set_name(v56, v120);\n\tUnityEngine.Material::set_mainTexture(v56, v117);\n\tv189 = Spine.Unity.AttachmentTools.AtlasUtilities::ToSpineAtlasPage(v56);\n\treturnVal2 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(v117, shader, 0.01f, 0);\n\treturnVal2.page = v189;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegionPMAClone(this Texture2D t, Shader shader, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, Material materialPropertySource = null)
		{
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				string[] shaderKeywords = materialPropertySource.shaderKeywords;
				material.shaderKeywords = shaderKeywords;
			}
			Texture2D clone = t.GetClone(textureFormat, mipmaps, linear: false, applyPMA: true);
			string name = t.name;
			string name2 = name + "-pma-";
			clone.name = name2;
			string name3 = t.name;
			string name4 = shader.name;
			string name5 = name3 + name4;
			material.name = name5;
			material.mainTexture = clone;
			AtlasPage page = material.ToSpineAtlasPage();
			AtlasRegion atlasRegion = clone.ToAtlasRegion(shader);
			atlasRegion.page = page;
			return atlasRegion;
		}

		[Token(Token = "0x6000703")]
		[Address(RVA = "0x1573000", Offset = "0x1573000", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Spine.AtlasPage;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37CFD]) = v38;\nL_0017:\n\tv40 = new Spine.AtlasPage();\n\tSpine.AtlasPage::.ctor(v40);\n\tv40.rendererObject = m;\n\tv68 = UnityEngine.Object::get_name(m);\n\tv40.name = v68;\n\tv71 = UnityEngine.Material::get_mainTexture(m);\n\tgoto L_0034;\n\tv93 = v61;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v93, v70, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tv55 = UnityEngine.Object::op_Inequality(v71, 0);\n\tv98 = v55 == 0;\n\tif (v98) goto L_004C;\n\tv108 = UnityEngine.Texture::get_width(v71);\n\tv40.width = v108;\n\tv102 = UnityEngine.Texture::get_height(v71);\n\tv40.height = v102;\nL_004C:\n\treturn v40;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasPage ToSpineAtlasPage(this Material m)
		{
			AtlasPage atlasPage = new AtlasPage();
			atlasPage.rendererObject = m;
			string name = m.name;
			atlasPage.name = name;
			Texture mainTexture = m.mainTexture;
			if (mainTexture != null)
			{
				int width = mainTexture.width;
				atlasPage.width = width;
				int height = mainTexture.height;
				atlasPage.height = height;
			}
			return atlasPage;
		}

		[Token(Token = "0x6000704")]
		[Address(RVA = "0x1573510", Offset = "0x1573510", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, page, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37CFE]) = v36;\nL_0012:\n\tv37 = page == 0;\n\tif (v37) goto L_002B;\n\tgoto L_001E;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v40, page, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\treturnVal1 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(s, 0);\n\treturnVal1.page = page;\n\treturn returnVal1;\nL_002B:\n\tv52 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v52, \"page\", \"page cannot be null. AtlasPage determines which texture region belongs and how it should be rendered. You can use material.ToSpineAtlasPage() to get a shareable AtlasPage from a Material, or use the sprite.ToAtlasRegion(material) overload.\");\n\tthrow v52;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegion(this Sprite s, AtlasPage page)
		{
			if (page != null)
			{
				AtlasRegion atlasRegion = s.ToAtlasRegion();
				atlasRegion.page = page;
				return atlasRegion;
			}
			ArgumentNullException ex = new ArgumentNullException("page", "page cannot be null. AtlasPage determines which texture region belongs and how it should be rendered. You can use material.ToSpineAtlasPage() to get a shareable AtlasPage from a Material, or use the sprite.ToAtlasRegion(material) overload.");
			throw ex;
		}

		[Token(Token = "0x6000705")]
		[Address(RVA = "0x157387C", Offset = "0x157387C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, material, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37CFF]) = v40;\nL_0019:\n\tgoto L_001D;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, material, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001D:\n\tv49 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(s, 0);\n\tv52 = Spine.Unity.AttachmentTools.AtlasUtilities::ToSpineAtlasPage(material);\n\tv49.page = v52;\n\treturn v49;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegion(this Sprite s, Material material)
		{
			AtlasRegion atlasRegion = s.ToAtlasRegion();
			AtlasPage page = material.ToSpineAtlasPage();
			atlasRegion.page = page;
			return atlasRegion;
		}

		[Token(Token = "0x6000706")]
		[Address(RVA = "0x1573900", Offset = "0x1573900", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, materialPropertySource, textureFormat, mipmaps, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37D00]) = v42;\nL_001C:\n\tv48 = UnityEngine.Material::get_shader(materialPropertySource);\n\tgoto L_0031;\n\tv55 = v50;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v55, v47, textureFormat, mipmaps, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0031:\n\treturnVal2 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegionPMAClone(s, v48, textureFormat, mipmaps, materialPropertySource);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegionPMAClone(this Sprite s, Material materialPropertySource, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false)
		{
			Shader shader = materialPropertySource.shader;
			return s.ToAtlasRegionPMAClone(shader, textureFormat, mipmaps, materialPropertySource);
		}

		[Token(Token = "0x6000707")]
		[Address(RVA = "0x1573994", Offset = "0x1573994", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv38 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = UnityEngine.Material;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv64 = UnityEngine.Object;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv71 = \"-pma-\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, shader, textureFormat, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37D01]) = v54;\nL_0028:\n\tv56 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v56, shader);\n\tgoto L_0036;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v66, v60, v61, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0036:\n\tv77 = UnityEngine.Object::op_Inequality(materialPropertySource, 0);\n\tv79 = v77 == 0;\n\tif (v79) goto L_004F;\n\tUnityEngine.Material::CopyPropertiesFromMaterial(v56, materialPropertySource);\n\tv140 = UnityEngine.Material::get_shaderKeywords(materialPropertySource);\n\tUnityEngine.Material::set_shaderKeywords(v56, v140);\nL_004F:\n\tgoto L_0056;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v91, v83, v81, mipmaps, materialPropertySource, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0056:\n\tv115 = Spine.Unity.AttachmentTools.AtlasUtilities::ToTexture(s, textureFormat, mipmaps, 0, 1);\n\tv169 = UnityEngine.Object::get_name(s);\n\tv116 = System.String::Concat(v169, \"-pma-\");\n\tUnityEngine.Object::set_name(v115, v116);\n\tv117 = UnityEngine.Object::get_name(v115);\n\tv175 = UnityEngine.Object::get_name(shader);\n\tv118 = System.String::Concat(v117, v175);\n\tUnityEngine.Object::set_name(v56, v118);\n\tUnityEngine.Material::set_mainTexture(v56, v115);\n\tv183 = Spine.Unity.AttachmentTools.AtlasUtilities::ToSpineAtlasPage(v56);\n\treturnVal2 = Spine.Unity.AttachmentTools.AtlasUtilities::ToAtlasRegion(s, 1);\n\treturnVal2.page = v183;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AtlasRegion ToAtlasRegionPMAClone(this Sprite s, Shader shader, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, Material materialPropertySource = null)
		{
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				string[] shaderKeywords = materialPropertySource.shaderKeywords;
				material.shaderKeywords = shaderKeywords;
			}
			Texture2D texture2D = s.ToTexture(textureFormat, mipmaps, linear: false, applyPMA: true);
			string name = s.name;
			string name2 = name + "-pma-";
			texture2D.name = name2;
			string name3 = texture2D.name;
			string name4 = shader.name;
			string name5 = name3 + name4;
			material.name = name5;
			material.mainTexture = texture2D;
			AtlasPage page = material.ToSpineAtlasPage();
			AtlasRegion atlasRegion = s.ToAtlasRegion(isolatedTexture: true);
			atlasRegion.page = page;
			return atlasRegion;
		}

		[Token(Token = "0x6000708")]
		[Address(RVA = "0x15735DC", Offset = "0x15735DC", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = Spine.AtlasRegion;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, isolatedTexture, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv59 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, isolatedTexture, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37D02]) = v55;\nL_0020:\n\tv57 = new Spine.AtlasRegion();\n\tSpine.AtlasRegion::.ctor(v57);\n\tv65 = UnityEngine.Object::get_name(s);\n\tv57.name = v65;\n\tv57.index = 0xFFFFFFFF;\n\tv185 = UnityEngine.Sprite::get_packed(s);\n\tv263 = v185 == 0;\n\tif (v263) goto L_FFFFFFFF;\n\tv266 = UnityEngine.Sprite::get_packingRotation(s);\n\tv272 = v266 == 0;\n\tv277 = ~v272;\n\tgoto L_0044;\nL_0044:\n\tv57.rotate = v281;\n\tv284 = UnityEngine.Sprite::get_bounds(s);\n\tv104 = UnityEngine.Sprite::get_rect(s);\n\tv168 = UnityEngine.Sprite::get_texture(s);\n\tv81 = v284.m_Center - v284.m_Extents;\n\tv110 = v284.m_Center + v284.m_Extents;\n\tv292 = UnityEngine.Texture::get_height(v168);\n\tgoto L_007F;\n\tv297 = v293;\n\tv298 = \"il2cpp_codegen_runtime_class_init\"(v297, v291, methodInfo, v39, v40, v41, v42, v43, v104, v101, v98, v95, v48, v49, v50, v51);\nL_007F:\n\tv313 = v104.m_Width != 0x7F800000;\n\tif (v313) goto L_FFFFFFFF;\n\tgoto L_008F;\nL_008F:\n\tv318 = v110 - v81;\n\tv319 = 0 - v81;\n\tv321 = v319 / v318;\n\tv324 = 0x3F - v321;\n\tv71 = v104.m_Height != 0x7F800000;\n\tif (v71) goto L_FFFFFFFF;\n\tgoto L_009C;\nL_009C:\n\tv327 = v104.m_Width * v324;\n\tv57.width = v178;\n\tv57.height = v79;\n\tv57.originalWidth = v178;\n\tv57.originalHeight = v79;\n\tv57.offsetX = v327;\n\tv329 = isolatedTexture == 0;\n\tif (v329) goto L_00AD;\n\tv57.x = 0;\n\tv57.u = *([407EE0]);\n\tgoto L_0107;\nL_00AD:\n\tv335 = UnityEngine.Sprite::get_texture(s);\n\tv105 = UnityEngine.Sprite::get_textureRect(s);\n\tv376 = v292 - v104.m_YMin;\n\tv345 = v376 - v104.m_Height;\n\tv378 = UnityEngine.Texture::get_width(v335);\n\tv383 = UnityEngine.Texture::get_height(v335);\n\tgoto L_00D9;\n\tv387 = v384;\n\tv388 = \"il2cpp_codegen_runtime_class_init\"(v387, v382, methodInfo, v39, v40, v41, v42, v43, v376, v372, v99, v96, v76, v49, v50, v51);\nL_00D9:\n\tv349 = Spine.Unity.AttachmentTools.AtlasUtilities::TextureRectToUVRect(v105, v378, v383);\n\tv408 = v104 != 0x7F800000;\n\tif (v408) goto L_FFFFFFFF;\n\tgoto L_00F0;\nL_00F0:\n\tv57.x = v411;\n\tv346 = v349.m_Height + v349.m_YMin;\n\tv347 = v349.m_Width + v349;\n\tv339 = v345 != 0x7F800000;\n\tif (v339) goto L_FFFFFFFF;\n\tgoto L_0103;\nL_0103:\n\tv57.u = v349;\n\tv57.v = v346;\n\tv57.u2 = v347;\n\tv57.v2 = v349.m_YMin;\nL_0107:\n\tv57.y = v257;\n\treturn v57;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AtlasRegion ToAtlasRegion(this Sprite s, bool isolatedTexture = false)
		{
			//IL_0339: Expected I4, but got F4
			//IL_0346: Expected I4, but got F4
			//IL_0353: Expected I4, but got F4
			//IL_0360: Expected I4, but got F4
			//IL_0180: Expected F4, but got I
			//IL_0397: Expected I4, but got F4
			//IL_03a9: Expected I4, but got O
			//IL_023e: Expected O, but got I8
			AtlasRegion atlasRegion = new AtlasRegion();
			string name = s.name;
			atlasRegion.name = name;
			atlasRegion.index = -1;
			bool rotate;
			if (s.packed)
			{
				SpritePackingRotation packingRotation = s.packingRotation;
				bool flag = packingRotation == SpritePackingRotation.None;
				bool flag2 = !flag;
				rotate = flag2;
			}
			else
			{
				rotate = false;
			}
			atlasRegion.rotate = rotate;
			Bounds bounds = s.bounds;
			Rect rect = s.rect;
			Texture2D texture = s.texture;
			float num = bounds.m_Center.x - bounds.m_Extents.x;
			float num2 = bounds.m_Center.x + bounds.m_Extents.x;
			int height = texture.height;
			float num3 = ((rect.m_Width != float.PositiveInfinity) ? rect.m_Width : -0f);
			float num4 = num2 - num;
			float num5 = 0f - num;
			float num6 = num5 / num4;
			float num7 = 8.8E-44f - num6;
			float num8 = ((rect.m_Height != float.PositiveInfinity) ? rect.m_Height : -0f);
			float offsetX = rect.m_Width * num7;
			atlasRegion.width = (int)num3;
			atlasRegion.height = (int)num8;
			atlasRegion.originalWidth = (int)num3;
			atlasRegion.originalHeight = (int)num8;
			atlasRegion.offsetX = offsetX;
			float num9;
			if (isolatedTexture)
			{
				atlasRegion.x = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407EE0]");
				atlasRegion.u = 0f;
				num9 = 0f;
			}
			else
			{
				Texture2D texture2 = s.texture;
				Rect textureRect = s.textureRect;
				float num10 = (float)height - rect.m_YMin;
				float num11 = num10 - rect.m_Height;
				int width = texture2.width;
				int height2 = texture2.height;
				Rect rect2 = TextureRectToUVRect(textureRect, width, height2);
				Rect rect3 = ((rect.m_XMin != float.PositiveInfinity) ? rect : ((Rect)2147483648L));
				atlasRegion.x = (int)rect3;
				float v = rect2.m_Height + rect2.m_YMin;
				float u = rect2.m_Width + rect2.m_XMin;
				num9 = ((num11 != float.PositiveInfinity) ? num11 : -0f);
				atlasRegion.u = rect2.m_XMin;
				atlasRegion.v = v;
				atlasRegion.u2 = u;
				atlasRegion.v2 = rect2.m_YMin;
			}
			atlasRegion.y = (int)num9;
			return atlasRegion;
		}

		[Token(Token = "0x6000709")]
		[Address(RVA = "0x1573F84", Offset = "0x1573F84", Length = "0xA84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0079;\n\tv54 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv197 = Il2CppMethodInfo;\n\tv198 = \"il2cpp_codegen_initialize_runtime_metadata\"(v197, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv224 = Il2CppMethodInfo;\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv233 = System.Collections.Generic.Dictionary`2<Spine.AtlasRegion, System.Int32>;\n\tv234 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv291 = Il2CppMethodInfo;\n\tv292 = \"il2cpp_codegen_initialize_runtime_metadata\"(v291, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv298 = Il2CppMethodInfo;\n\tv299 = \"il2cpp_codegen_initialize_runtime_metadata\"(v298, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv306 = Il2CppMethodInfo;\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv314 = Il2CppMethodInfo;\n\tv315 = \"il2cpp_codegen_initialize_runtime_metadata\"(v314, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv319 = Il2CppMethodInfo;\n\tv320 = \"il2cpp_codegen_initialize_runtime_metadata\"(v319, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv420 = Il2CppMethodInfo;\n\tv421 = \"il2cpp_codegen_initialize_runtime_metadata\"(v420, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv437 = Il2CppMethodInfo;\n\tv438 = \"il2cpp_codegen_initialize_runtime_metadata\"(v437, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv452 = Il2CppMethodInfo;\n\tv453 = \"il2cpp_codegen_initialize_runtime_metadata\"(v452, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv467 = Il2CppMethodInfo;\n\tv468 = \"il2cpp_codegen_initialize_runtime_metadata\"(v467, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv531 = Il2CppMethodInfo;\n\tv532 = \"il2cpp_codegen_initialize_runtime_metadata\"(v531, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv573 = Il2CppMethodInfo;\n\tv574 = \"il2cpp_codegen_initialize_runtime_metadata\"(v573, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv584 = Il2CppMethodInfo;\n\tv585 = \"il2cpp_codegen_initialize_runtime_metadata\"(v584, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv855 = Il2CppMethodInfo;\n\tv856 = \"il2cpp_codegen_initialize_runtime_metadata\"(v855, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv862 = Il2CppMethodInfo;\n\tv863 = \"il2cpp_codegen_initialize_runtime_metadata\"(v862, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv872 = Il2CppMethodInfo;\n\tv873 = \"il2cpp_codegen_initialize_runtime_metadata\"(v872, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv890 = Il2CppMethodInfo;\n\tv891 = \"il2cpp_codegen_initialize_runtime_metadata\"(v890, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv915 = Il2CppMethodInfo;\n\tv916 = \"il2cpp_codegen_initialize_runtime_metadata\"(v915, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv930 = System.Collections.Generic.List`1<System.Int32>;\n\tv931 = \"il2cpp_codegen_initialize_runtime_metadata\"(v930, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv951 = System.Collections.Generic.List`1<UnityEngine.Texture2D>;\n\tv952 = \"il2cpp_codegen_initialize_runtime_metadata\"(v951, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv967 = System.Collections.Generic.List`1<Spine.AtlasRegion>;\n\tv968 = \"il2cpp_codegen_initialize_runtime_metadata\"(v967, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv1008 = UnityEngine.Material;\n\tv1009 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1008, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv1028 = UnityEngine.Object;\n\tv1029 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1028, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv1049 = UnityEngine.Texture2D;\n\tv1050 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1049, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv1093 = \"Spine/Skeleton\";\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1093, outputAttachments, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv67 = 1;\n\t*([1A37D03]) = v67;\nL_0079:\n\tv69 = sourceAttachments == 0;\n\tif (v69) goto L_036C;\n\tv74 = outputAttachments == 0;\n\tif (v74) goto L_0374;\n\tv218 = new System.Collections.Generic.Dictionary`2<Spine.AtlasRegion, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.AtlasRegion, System.Int32>::.ctor(v218);\n\tv236 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v236);\n\tv301 = new System.Collections.Generic.List`1<UnityEngine.Texture2D>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Texture2D>::.ctor(v301);\n\tv317 = new System.Collections.Generic.List`1<Spine.AtlasRegion>();\n\tSystem.Collections.Generic.List`1<Spine.AtlasRegion>::.ctor(v317);\n\tv424 = outputAttachments._version + 1;\n\toutputAttachments._size = 0;\n\toutputAttachments._version = v424;\n\tv435 = outputAttachments._size < 1;\n\tif (v435) goto L_00C3;\n\tSystem.Array::Clear(outputAttachments._items, 0, outputAttachments._size);\nL_00C3:\n\tSystem.Colle\n// ... truncated")]
		public unsafe static void GetRepackedAttachments(List<Attachment> sourceAttachments, List<Attachment> outputAttachments, Material materialPropertySource, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, string newAssetName = "Repacked Attachments", bool clearCache = false, bool useOriginalNonrenderables = true)
		{
			//IL_0812: Expected O, but got I
			//IL_083a: Expected F4, but got I
			//IL_084f: Expected F4, but got I
			//IL_0864: Expected F4, but got I
			//IL_0871: Expected F4, but got O
			//IL_095d: Expected O, but got I
			outputMaterial = null;
			outputTexture = null;
			ArgumentNullException ex2;
			if (sourceAttachments != null)
			{
				if (outputAttachments != null)
				{
					Dictionary<AtlasRegion, int> dictionary = new Dictionary<AtlasRegion, int>();
					List<int> list = new List<int>();
					List<Texture2D> list2 = new List<Texture2D>();
					List<AtlasRegion> list3 = new List<AtlasRegion>();
					int version = outputAttachments._version + 1;
					outputAttachments._size = 0;
					outputAttachments._version = version;
					if (outputAttachments.Count >= 1)
					{
						Array.Clear(outputAttachments._items, 0, outputAttachments.Count);
					}
					outputAttachments.AddRange(sourceAttachments);
					if (sourceAttachments.Count >= 1)
					{
						int num = 0;
						int num2 = 0;
						do
						{
							Attachment attachment = sourceAttachments[num];
							if (IsRenderable(attachment))
							{
								Attachment copy = attachment.GetCopy(cloneMeshesAsLinked: true);
								AtlasRegion region = copy.GetRegion();
								if (dictionary.TryGetValue(region, out var value))
								{
									int[] items = list._items;
									int version2 = list._version + 1;
									list._version = version2;
									int count = list.Count;
									if (list.Count < items.Length)
									{
										int size = list.Count + 1;
										list._size = size;
										items[count] = value;
									}
									else
									{
										list.Add(value);
									}
								}
								else
								{
									AtlasRegion[] items2 = list3._items;
									int version3 = list3._version + 1;
									list3._version = version3;
									int count2 = list3.Count;
									if (list3.Count < items2.Length)
									{
										int size2 = list3.Count + 1;
										list3._size = size2;
										items2[count2] = region;
									}
									else
									{
										list3.Add(region);
									}
									Texture2D texture2D = region.ToTexture(textureFormat, mipmaps);
									Texture2D[] items3 = list2._items;
									int version4 = list2._version + 1;
									list2._version = version4;
									int count3 = list2.Count;
									if (list2.Count < items3.Length)
									{
										int size3 = list2.Count + 1;
										list2._size = size3;
										items3[count3] = texture2D;
									}
									else
									{
										list2.Add(texture2D);
									}
									dictionary.Add(region, num2);
									int[] items4 = list._items;
									int version5 = list._version + 1;
									list._version = version5;
									int count4 = list.Count;
									if (list.Count < items4.Length)
									{
										int size4 = list.Count + 1;
										list._size = size4;
										items4[count4] = num2;
									}
									else
									{
										list.Add(num2);
									}
									num2++;
								}
								outputAttachments[num] = copy;
							}
							else
							{
								bool flag = !useOriginalNonrenderables;
								bool flag2 = !flag;
								Attachment value2 = attachment;
								if (!flag2)
								{
									Attachment copy2 = attachment.GetCopy(cloneMeshesAsLinked: true);
									value2 = copy2;
								}
								outputAttachments[num] = value2;
								int[] items5 = list._items;
								int version6 = list._version + 1;
								list._version = version6;
								int count5 = list.Count;
								if (list.Count < items5.Length)
								{
									int size5 = list.Count + 1;
									list._size = size5;
									items5[count5] = -1;
								}
								else
								{
									list.Add(-1);
								}
							}
							num++;
						}
						while (sourceAttachments.Count != num);
					}
					Texture2D texture2D2 = new Texture2D(maxAtlasSize, maxAtlasSize, textureFormat, mipmaps);
					texture2D2.mipMapBias = -0.5f;
					texture2D2.name = newAssetName;
					if (list2.Count >= 1)
					{
						Texture2D source = list2[0];
						texture2D2.CopyTextureAttributesFrom(source);
					}
					Texture2D[] textures = list2.ToArray();
					Rect[] array = texture2D2.PackTextures(textures, padding, maxAtlasSize);
					Shader shader = ((!(materialPropertySource == null)) ? materialPropertySource.shader : Shader.Find("Spine/Skeleton"));
					Material material = new Material(shader);
					if (materialPropertySource != null)
					{
						material.CopyPropertiesFromMaterial(materialPropertySource);
						string[] shaderKeywords = materialPropertySource.shaderKeywords;
						material.shaderKeywords = shaderKeywords;
					}
					material.name = newAssetName;
					material.mainTexture = texture2D2;
					AtlasPage atlasPage = material.ToSpineAtlasPage();
					atlasPage.name = newAssetName;
					List<AtlasRegion> list4 = new List<AtlasRegion>();
					if (list3.Count >= 1)
					{
						object obj = (nint)array + 44;
						int num3 = 0;
						Rect uvRect = default(Rect);
						do
						{
							AtlasRegion referenceRegion = list3[num3];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ X28_v10-C]");
							uvRect.m_XMin = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ X28_v10-8]");
							uvRect.m_YMin = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ X28_v10-4]");
							uvRect.m_Width = 0f;
							uvRect.m_Height = (float)obj;
							AtlasRegion atlasRegion = UVRectToAtlasRegion(uvRect, referenceRegion, atlasPage);
							AtlasRegion[] items6 = list4._items;
							int version7 = list4._version + 1;
							list4._version = version7;
							int count6 = list4.Count;
							if (list4.Count < items6.Length)
							{
								int size6 = list4.Count + 1;
								list4._size = size6;
								items6[count6] = atlasRegion;
							}
							else
							{
								list4.Add(atlasRegion);
							}
							num3++;
							obj = (nint)obj + 16;
						}
						while (list3.Count != num3);
					}
					if (outputAttachments.Count >= 1)
					{
						int num4 = 0;
						do
						{
							Attachment attachment2 = outputAttachments[num4];
							if (IsRenderable(attachment2))
							{
								int index = list[num4];
								AtlasRegion region2 = list4[index];
								attachment2.SetRegion(region2);
							}
							num4++;
						}
						while (outputAttachments.Count != num4);
					}
					if (clearCache)
					{
						ClearCache();
					}
					ref Texture2D reference = ref *(Texture2D*)texture2D2;
					ref Material reference2 = ref *(Material*)material;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "outputAttachments";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "sourceAttachments";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x600070A")]
		[Address(RVA = "0x15752D4", Offset = "0x15752D4", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv46 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, newName, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 1;\n\t*([1A37D04]) = v58;\nL_002C:\n\tv76 = UnityEngine.Material::get_shader(materialPropertySource);\n\tgoto L_0047;\n\tv83 = v78;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v83, v75, materialPropertySource, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0047:\n\treturnVal2 = Spine.Unity.AttachmentTools.AtlasUtilities::GetRepackedSkin(o, newName, v76, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, mipmaps, materialPropertySource, clearCache, useOriginalNonrenderables, additionalTexturePropertyIDsToCopy, v105, additionalTextureFormats, additionalTextureIsLinear);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Skin GetRepackedSkin(this Skin o, string newName, Material materialPropertySource, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, bool useOriginalNonrenderables = true, bool clearCache = false, int[] additionalTexturePropertyIDsToCopy = null, Texture2D[] additionalOutputTextures = null, TextureFormat[] additionalTextureFormats = null, bool[] additionalTextureIsLinear = null)
		{
			outputMaterial = null;
			outputTexture = null;
			Shader shader = materialPropertySource.shader;
			Texture2D[] additionalOutputTextures2 = default(Texture2D[]);
			return o.GetRepackedSkin(newName, shader, out outputMaterial, out outputTexture, maxAtlasSize, padding, textureFormat, mipmaps, materialPropertySource, clearCache, useOriginalNonrenderables, additionalTexturePropertyIDsToCopy, additionalOutputTextures2, additionalTextureFormats, additionalTextureIsLinear);
		}

		[Token(Token = "0x600070B")]
		[Address(RVA = "0x15753D8", Offset = "0x15753D8", Length = "0x1118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_009E;\n\tv59 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv79 = System.Boolean[];\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv143 = Il2CppMethodInfo;\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv303 = Il2CppMethodInfo;\n\tv304 = \"il2cpp_codegen_initialize_runtime_metadata\"(v303, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv782 = Il2CppMethodInfo;\n\tv783 = \"il2cpp_codegen_initialize_runtime_metadata\"(v782, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv916 = System.Collections.Generic.Dictionary`2<Spine.AtlasRegion, System.Int32>;\n\tv917 = \"il2cpp_codegen_initialize_runtime_metadata\"(v916, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv993 = Il2CppMethodInfo;\n\tv994 = \"il2cpp_codegen_initialize_runtime_metadata\"(v993, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv1003 = Il2CppMethodInfo;\n\tv1004 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1003, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv1121 = System.IDisposable;\n\tv1122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1121, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv1281 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<Spine.Skin+SkinEntry, Spine.Attachment>>;\n\tv1282 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1281, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv1442 = System.Collections.IEnumerator;\n\tv1443 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1442, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv1607 = Il2CppMethodInfo;\n\tv1608 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1607, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv1770 = Il2CppMethodInfo;\n\tv1771 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1770, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv1943 = System.Collections.Generic.List`1<UnityEngine.Texture2D>[];\n\tv1944 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1943, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2114 = Il2CppMethodInfo;\n\tv2115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2114, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2252 = Il2CppMethodInfo;\n\tv2253 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2252, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2344 = Il2CppMethodInfo;\n\tv2345 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2344, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2424 = Il2CppMethodInfo;\n\tv2425 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2424, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2501 = Il2CppMethodInfo;\n\tv2502 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2501, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2601 = Il2CppMethodInfo;\n\tv2602 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2601, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2622 = Il2CppMethodInfo;\n\tv2623 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2622, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2637 = Il2CppMethodInfo;\n\tv2638 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2637, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2651 = Il2CppMethodInfo;\n\tv2652 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2651, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2658 = Il2CppMethodInfo;\n\tv2659 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2658, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2674 = Il2CppMethodInfo;\n\tv2675 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2674, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2724 = Il2CppMethodInfo;\n\tv2725 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2724, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2857 = Il2CppMethodInfo;\n\tv2858 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2857, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv2981 = Il2CppMethodInfo;\n\tv2982 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2981, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3043 = Il2CppMethodInfo;\n\tv3044 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3043, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3196 = Il2CppMethodInfo;\n\tv3197 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3196, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3249 = System.Collections.Generic.List`1<System.Int32>;\n\tv3250 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3249, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3261 = System.Collections.Generic.List`1<UnityEngine.Texture2D>;\n\tv3262 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3261, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3296 = System.Collections.Generic.List`1<Spine.AtlasRegion>;\n\tv3297 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3296, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3322 = System.Collections.Generic.List`1<Spine.Attachment>;\n\tv3323 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3322, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3343 = UnityEngine.Material;\n\tv3344 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3343, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv3360 = UnityEngine.Object;\n\tv3361 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3360, newName, shader, outputMaterial, outputTexture, maxAtlasSize, padding, textureFormat, v61, v62, v63, v64, v65, v66, v6\n// ... truncated")]
		public unsafe static Skin GetRepackedSkin(this Skin o, string newName, Shader shader, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, Material materialPropertySource = null, bool clearCache = false, bool useOriginalNonrenderables = true, int[] additionalTexturePropertyIDsToCopy = null, Texture2D[] additionalOutputTextures = null, TextureFormat[] additionalTextureFormats = null, bool[] additionalTextureIsLinear = null)
		{
			//IL_0096: Expected O, but got I
			//IL_01d9: Expected I4, but got O
			//IL_02a2: Expected O, but got I
			//IL_0200: Expected I4, but got O
			//IL_0b8a: Expected I, but got O
			//IL_0c10: Expected I, but got O
			//IL_0523: Expected O, but got I4
			//IL_1071: Expected O, but got I
			//IL_10a5: Expected F4, but got I
			//IL_10ba: Expected F4, but got I
			//IL_10cf: Expected F4, but got I
			//IL_10dc: Expected F4, but got O
			//IL_139a: Expected I, but got O
			//IL_081f: Expected O, but got I
			//IL_082f: Expected O, but got I
			//IL_0eb5: Expected O, but got I
			//IL_0ec5: Expected O, but got I
			//IL_0e4b: Expected O, but got I
			//IL_0845: Expected O, but got I
			//IL_085b: Expected O, but got I
			//IL_0765: Expected O, but got I
			//IL_1472: Expected I, but got O
			//IL_11c9: Expected O, but got I
			//IL_072f: Expected O, but got I
			//IL_0e05: Expected O, but got I
			//IL_08b4: Expected O, but got I
			//IL_08d8: Expected O, but got I
			outputMaterial = null;
			outputTexture = null;
			ref Texture2D reference = ref *(Texture2D*)null;
			bool flag = additionalTextureIsLinear == null;
			bool flag2 = !flag;
			TextureFormat[] array = (TextureFormat[])(object)additionalTextureIsLinear;
			if (!flag2)
			{
				bool flag3 = additionalTexturePropertyIDsToCopy == null;
				array = (TextureFormat[])(object)additionalTextureIsLinear;
				if (!flag3)
				{
					TextureFormat[] array2 = (TextureFormat[])(object)new bool[additionalTexturePropertyIDsToCopy.Length];
					int num = array2.Length << 32;
					bool flag4 = num < 1;
					array = array2;
					if (!flag4)
					{
						object obj = (nint)array2 + 32;
						int num2 = 0;
						bool flag5;
						do
						{
							_ = 1;
							num2++;
							flag5 = array2.Length != num2;
							array = array2;
						}
						while (flag5);
					}
				}
			}
			Skin skin;
			Dictionary<AtlasRegion, int> dictionary;
			List<int> list;
			List<Attachment> list2;
			int num3;
			int num4;
			object obj2;
			int num5;
			if (o != null)
			{
				skin = new Skin(newName);
				skin.Bones.AddRange(o.Bones);
				skin.Constraints.AddRange(o.Constraints);
				dictionary = new Dictionary<AtlasRegion, int>();
				list = new List<int>();
				list2 = new List<Attachment>();
				if (additionalTexturePropertyIDsToCopy != null)
				{
					num3 = additionalTexturePropertyIDsToCopy.Length + 1;
					Texture2D[] array3 = new Texture2D[additionalTexturePropertyIDsToCopy.Length];
					List<Texture2D>[] array4 = new List<Texture2D>[num3];
					bool flag6 = num3 >= 1;
					num4 = (int)array3;
					obj2 = array4;
					if (!flag6)
					{
						num5 = 0;
						num4 = (int)array3;
						obj2 = array4;
						goto IL_150a;
					}
				}
				else
				{
					List<Texture2D>[] array5 = new List<Texture2D>[1];
					num4 = 0;
					num3 = 1;
					obj2 = array5;
				}
				int num6 = 0;
				object obj4 = default(object);
				do
				{
					List<Texture2D> list3 = new List<Texture2D>();
					if (list3 != null)
					{
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
						if (obj4 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					int num7 = num6 << 3;
					object obj5 = (nint)obj2 + num7;
					num6++;
				}
				while (num3 != num6);
				num5 = 1;
				goto IL_150a;
			}
			NullReferenceException ex2 = new NullReferenceException("Skin was null");
			throw ex2;
			IL_150a:
			List<AtlasRegion> list4 = new List<AtlasRegion>();
			IEnumerator enumerator = o.Attachments.GetEnumerator();
			int num8 = 0;
			Skin skin2 = skin;
			int[] array6 = additionalTexturePropertyIDsToCopy;
			Attachment attachment = default(Attachment);
			int slotIndex = default(int);
			string name = default(string);
			int num17;
			AtlasRegion key;
			Dictionary<AtlasRegion, int> dictionary2 = default(Dictionary<AtlasRegion, int>);
			bool linear2 = default(bool);
			Rect uvRect = default(Rect);
			OutOfMemoryException ex4 = default(OutOfMemoryException);
			while (true)
			{
				int num10;
				nint num11;
				IEnumerator enumerator2;
				int num12;
				int[] array9;
				bool mipChain;
				Texture2D[] array10;
				List<AtlasRegion> list8;
				int num13;
				int num14;
				List<Attachment> list9;
				List<int> list10;
				Skin result;
				Skin skin4;
				Shader shader3;
				object obj6;
				TextureFormat textureFormat3;
				int num15;
				nint num16;
				TextureFormat[] array11;
				int num9;
				int[] array7;
				bool flag8;
				Texture2D[] array8;
				List<AtlasRegion> list5;
				List<Attachment> list6;
				List<int> list7;
				Skin skin3;
				Shader shader2;
				TextureFormat textureFormat2;
				if (!enumerator.MoveNext())
				{
					bool flag7 = enumerator == null;
					num9 = num3;
					array7 = additionalTexturePropertyIDsToCopy;
					flag8 = mipmaps;
					array8 = (Texture2D[])(object)additionalTextureFormats;
					list5 = list4;
					list6 = list2;
					list7 = list;
					skin3 = skin;
					shader2 = shader;
					textureFormat2 = textureFormat;
					num10 = 28;
					num11 = unchecked((nint)null);
					enumerator2 = enumerator;
					num12 = num3;
					array9 = additionalTexturePropertyIDsToCopy;
					mipChain = mipmaps;
					array10 = (Texture2D[])(object)additionalTextureFormats;
					list8 = list4;
					num13 = num5;
					num14 = num4;
					list9 = list2;
					list10 = list;
					result = skin2;
					skin4 = skin;
					shader3 = shader;
					obj6 = obj2;
					textureFormat3 = textureFormat;
					num15 = 28;
					num16 = unchecked((nint)null);
					array11 = array;
					if (flag7)
					{
						goto IL_15bd;
					}
					goto IL_15e5;
				}
				KeyValuePair<Skin.SkinEntry, Attachment> current = ((IEnumerator<KeyValuePair<Skin.SkinEntry, Attachment>>)enumerator).Current;
				if (!IsRenderable(attachment))
				{
					bool flag9 = !useOriginalNonrenderables;
					bool flag10 = !flag9;
					Attachment attachment2 = attachment;
					if (!flag10)
					{
						Attachment copy = attachment.GetCopy(cloneMeshesAsLinked: true);
						attachment2 = copy;
					}
					skin2.SetAttachment(slotIndex, name, attachment2);
					continue;
				}
				Attachment copy2 = attachment.GetCopy(cloneMeshesAsLinked: true);
				AtlasRegion region = copy2.GetRegion();
				if (dictionary != null)
				{
					Attachment attachment3;
					if (dictionary.TryGetValue(region, out var value))
					{
						bool flag11 = list == null;
						num9 = num3;
						array7 = additionalTexturePropertyIDsToCopy;
						flag8 = mipmaps;
						array8 = (Texture2D[])(object)additionalTextureFormats;
						list5 = list4;
						list6 = list2;
						list7 = list;
						skin3 = skin;
						shader2 = shader;
						num17 = (int)(&value);
						textureFormat2 = textureFormat;
						if (flag11)
						{
							throw list;
						}
						int[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						bool flag12 = list._items == null;
						num9 = num3;
						array7 = additionalTexturePropertyIDsToCopy;
						flag8 = mipmaps;
						array8 = (Texture2D[])(object)additionalTextureFormats;
						list5 = list4;
						list6 = list2;
						list7 = list;
						skin3 = skin;
						shader2 = shader;
						num17 = (int)(&value);
						key = (AtlasRegion)value;
						textureFormat2 = textureFormat;
						if (flag12)
						{
							NullReferenceException ex3 = new NullReferenceException();
							if (value == 1)
							{
								((Dictionary<AtlasRegion, int>)(object)ex3).Add(key, num17);
								num11 = (nint)dictionary2;
								dictionary2.Add(key, num17);
								bool flag13 = enumerator == null;
								bool flag14 = !flag13;
								skin2 = skin;
								num10 = 0;
								enumerator2 = enumerator;
								if (flag14)
								{
									goto IL_15e5;
								}
								num12 = num3;
								array9 = additionalTexturePropertyIDsToCopy;
								mipChain = mipmaps;
								array10 = (Texture2D[])(object)additionalTextureFormats;
								list8 = list4;
								num13 = num5;
								num14 = num4;
								list9 = list2;
								list10 = list;
								result = skin;
								skin4 = skin;
								shader3 = shader;
								obj6 = obj2;
								textureFormat3 = textureFormat;
								num15 = 0;
								num16 = (nint)dictionary2;
								array11 = array;
								goto IL_15bd;
							}
							break;
						}
						int count = list.Count;
						if (list.Count < items.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items[count] = value;
							attachment3 = copy2;
						}
						else
						{
							list.Add(value);
							attachment3 = copy2;
						}
					}
					else
					{
						AtlasRegion[] items2 = list4._items;
						int version2 = list4._version + 1;
						list4._version = version2;
						int count2 = list4.Count;
						if (list4.Count < items2.Length)
						{
							int size2 = list4.Count + 1;
							list4._size = size2;
							items2[count2] = region;
						}
						else
						{
							list4.Add(region);
						}
						if (num5 != 0)
						{
							int num18 = 0;
							int[] array12 = array6;
							bool flag18;
							do
							{
								Texture2D item;
								if (num18 != 0)
								{
									bool flag15 = additionalTextureFormats == null;
									TextureFormat textureFormat4 = textureFormat;
									if (!flag15)
									{
										int num19 = num18 - 1;
										bool flag16 = num19 >= additionalTextureFormats.Length;
										textureFormat4 = textureFormat;
										if (!flag16)
										{
											int num20 = num19 << 2;
											object obj7 = (nint)additionalTextureFormats + num20;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3764 @ X8_v160+20]");
											textureFormat4 = (TextureFormat)0;
										}
									}
									int num21 = num18 - 1;
									object obj8 = (nint)array + num21;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3873 @ X8_v156+20]");
									bool flag17 = (nint)0 == 0;
									bool linear = !flag17;
									Texture2D texture2D = region.ToTexture(textureFormat4, mipmaps, array12[num21], linear);
									item = texture2D;
									array12 = additionalTexturePropertyIDsToCopy;
								}
								else
								{
									Texture2D texture2D2 = region.ToTexture(textureFormat, mipmaps);
									item = texture2D2;
								}
								int num22 = num18 << 3;
								object obj9 = (nint)obj2 + num22;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1115 @ X8_v143+20]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ X0_v201+10]");
								object obj11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ X0_v201+1C]");
								object obj12 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ X0_v201+18]");
								nint num23 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1511 @ X8_v144+18]");
								if (num23 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ X0_v201+18]");
									object obj13 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ X0_v201+18]");
									int num24 = (int)((nint)0 << 3);
									object obj14 = (nint)obj11 + num24;
								}
								else
								{
									((List<object>)obj10).Add((object)item);
								}
								num18++;
								flag18 = num3 != num18;
								array6 = array12;
							}
							while (flag18);
						}
						dictionary.Add(region, num8);
						if (list == null)
						{
							throw list;
						}
						int[] items3 = list._items;
						int version3 = list._version + 1;
						list._version = version3;
						int count3 = list.Count;
						int num25;
						if (list.Count < items3.Length)
						{
							int size3 = list.Count + 1;
							list._size = size3;
							items3[count3] = num8;
							num25 = num8;
						}
						else
						{
							list.Add(num8);
							num25 = num8;
						}
						int num26 = num25 + 1;
						attachment3 = copy2;
						num8 = num26;
						skin2 = skin;
					}
					if (list2 != null)
					{
						Attachment[] items4 = list2._items;
						int version4 = list2._version + 1;
						list2._version = version4;
						int count4 = list2.Count;
						if (list2.Count < items4.Length)
						{
							int size4 = list2.Count + 1;
							list2._size = size4;
							items4[count4] = attachment3;
						}
						else
						{
							list2.Add(attachment3);
						}
						skin2.SetAttachment(slotIndex, name, attachment3);
						continue;
					}
					goto IL_133a;
				}
				throw dictionary;
				IL_15e5:
				((IDisposable)enumerator2).Dispose();
				num12 = num9;
				array9 = array7;
				mipChain = flag8;
				array10 = array8;
				list8 = list5;
				num13 = num5;
				num14 = num4;
				list9 = list6;
				list10 = list7;
				result = skin2;
				skin4 = skin3;
				shader3 = shader2;
				obj6 = obj2;
				textureFormat3 = textureFormat2;
				num15 = num10;
				num16 = num11;
				array11 = array;
				goto IL_15bd;
				IL_15bd:
				if (num16 == 0)
				{
					if (num15 == 28 || num15 == 0)
					{
						Material material = new Material(shader3);
						if (materialPropertySource != null)
						{
							material.CopyPropertiesFromMaterial(materialPropertySource);
							string[] shaderKeywords = materialPropertySource.shaderKeywords;
							material.shaderKeywords = shaderKeywords;
						}
						material.name = newName;
						bool flag19 = num13 == 0;
						Rect[] array13 = null;
						if (!flag19)
						{
							int num27 = 0;
							int num28 = 0;
							Rect[] array14 = null;
							int num29 = 0;
							int num30 = maxAtlasSize;
							bool flag23;
							do
							{
								if (num28 != 0)
								{
									num27 = num30;
								}
								if (num28 != 0)
								{
									num29 = num30;
								}
								int height;
								int width;
								TextureFormat textureFormat5;
								int num34;
								if (num28 != 0)
								{
									bool flag20 = array10 == null;
									height = num30;
									width = num30;
									textureFormat5 = textureFormat3;
									if (!flag20)
									{
										bool flag21 = num28 > array10.Length;
										height = num29;
										width = num27;
										textureFormat5 = textureFormat3;
										if (!flag21)
										{
											int num31 = num28 - 1;
											int num32 = num31 << 2;
											object obj15 = (nint)array10 + num32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3541 @ X8_v64+20]");
											textureFormat5 = (TextureFormat)0;
											height = num29;
											width = num27;
										}
									}
									int num33 = num28 - 1;
									object obj16 = (nint)array11 + num33;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3554 @ X8_v60+20]");
									num34 = 0;
								}
								else
								{
									height = num30;
									width = num30;
									textureFormat5 = textureFormat3;
									num34 = 0;
								}
								Texture2D texture2D3 = new Texture2D(width, height, textureFormat5, mipChain, linear2);
								bool flag22 = num34 == 0;
								linear2 = !flag22;
								texture2D3.mipMapBias = -0.5f;
								int num35 = num28 << 3;
								object obj17 = (nint)obj6 + num35;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ X8_v40+20]");
								object obj18 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ X21_v13+18]");
								if ((nint)0 > (nint)0)
								{
									Texture2D source = (Texture2D)((List<object>)obj18)[0];
									texture2D3.CopyTextureAttributesFrom(source);
								}
								texture2D3.name = newName;
								Texture2D[] textures = (Texture2D[])((List<object>)obj18).ToArray();
								Rect[] array15 = texture2D3.PackTextures(textures, padding, maxAtlasSize);
								ref Texture2D reference2;
								if (num28 != 0)
								{
									int num36 = num28 - 1;
									material.SetTexture(array9[num36], texture2D3);
									int num37 = num36 << 3;
									int num38 = num14 + num37;
									reference2 = ref *(Texture2D*)(num38 + 32);
									array13 = array14;
									num30 = maxAtlasSize;
								}
								else
								{
									material.mainTexture = texture2D3;
									array13 = array15;
									num30 = maxAtlasSize;
									reference2 = ref outputTexture;
								}
								num28++;
								reference2 = ref *(Texture2D*)texture2D3;
								flag23 = num12 != num28;
								array14 = array13;
							}
							while (flag23);
						}
						AtlasPage atlasPage = material.ToSpineAtlasPage();
						atlasPage.name = newName;
						List<AtlasRegion> list11 = new List<AtlasRegion>();
						if (list8.Count >= 1)
						{
							object obj19 = (nint)array13 + 44;
							int num39 = 0;
							List<AtlasRegion> list12 = list8;
							bool flag24;
							do
							{
								AtlasRegion referenceRegion = list12[num39];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ X26_v11-C]");
								uvRect.m_XMin = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ X26_v11-8]");
								uvRect.m_YMin = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ X26_v11-4]");
								uvRect.m_Width = 0f;
								uvRect.m_Height = (float)obj19;
								AtlasRegion atlasRegion = UVRectToAtlasRegion(uvRect, referenceRegion, atlasPage);
								AtlasRegion[] items5 = list11._items;
								int version5 = list11._version + 1;
								list11._version = version5;
								int count5 = list11.Count;
								if (list11.Count < items5.Length)
								{
									int size5 = list11.Count + 1;
									list11._size = size5;
									items5[count5] = atlasRegion;
								}
								else
								{
									list11.Add(atlasRegion);
								}
								num39++;
								obj19 = (nint)obj19 + 16;
								flag24 = list8.Count != num39;
								list12 = list8;
							}
							while (flag24);
						}
						if (list9.Count >= 1)
						{
							int num40 = 0;
							do
							{
								Attachment attachment4 = list9[num40];
								if (IsRenderable(attachment4))
								{
									int index = list10[num40];
									AtlasRegion region2 = list11[index];
									attachment4.SetRegion(region2);
								}
								num40++;
							}
							while (list9.Count != num40);
						}
						if (clearCache)
						{
							ClearCache();
						}
						ref Material reference3 = ref *(Material*)material;
						result = skin4;
					}
					return result;
				}
				ex4 = new OutOfMemoryException();
				goto IL_133a;
				IL_133a:
				throw ex4;
			}
			if (enumerator != null)
			{
				((IDisposable)enumerator).Dispose();
				num17 = 0;
				key = null;
			}
			OutOfMemoryException ex5 = new OutOfMemoryException();
			((Dictionary<AtlasRegion, int>)(object)ex5).Add(key, num17);
			Skin result2 = default(Skin);
			return result2;
		}

		[Token(Token = "0x600070C")]
		[Address(RVA = "0x15764F0", Offset = "0x15764F0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, pixelsPerUnit, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37D06]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v25, v26, v27, v28, v29, v30, pixelsPerUnit, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = Spine.Unity.AttachmentTools.AtlasUtilities::GetMainTexture(ar);\n\tv51 = Spine.Unity.AttachmentTools.AtlasUtilities::GetUnityRect(ar);\n\t// 47 MakeStruct v66 @ AGG157A570_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\treturnVal1 = UnityEngine.Sprite::Create(v48, v51, v66, pixelsPerUnit);\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Sprite ToSprite(this AtlasRegion ar, float pixelsPerUnit = 100f)
		{
			Texture2D mainTexture = ar.GetMainTexture();
			Rect unityRect = ar.GetUnityRect();
			Vector2 pivot = default(Vector2);
			pivot.x = 0.5f;
			pivot.y = 0.5f;
			return Sprite.Create(mainTexture, unityRect, pivot, pixelsPerUnit);
		}

		[Token(Token = "0x600070D")]
		[Address(RVA = "0x1572B2C", Offset = "0x1572B2C", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv126 = Il2CppMethodInfo;\n\tv127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv142 = Il2CppMethodInfo;\n\tv143 = \"il2cpp_codegen_initialize_runtime_metadata\"(v142, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv158 = Il2CppMethodInfo;\n\tv159 = \"il2cpp_codegen_initialize_runtime_metadata\"(v158, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv176 = Il2CppMethodInfo;\n\tv177 = \"il2cpp_codegen_initialize_runtime_metadata\"(v176, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv192 = UnityEngine.Object;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v192, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A37D07]) = v43;\nL_002B:\n\tv45 = 0;\n\tgoto L_0036;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = Spine.Unity.AttachmentTools.AtlasUtilities;\nL_0036:\n\tv59 = v57.CachedRegionTexturesList == 0;\n\tif (v59) goto L_0089;\n\tv75 = System.Collections.Generic.List`1<UnityEngine.Texture2D>::GetEnumerator(v57.CachedRegionTexturesList);\nL_0047:\n\tv140 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v45 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv145 = v140 == 0;\n\tif (v145) goto L_0058;\n\tgoto L_0054;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v160, v138, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0054:\n\tUnityEngine.Object::Destroy(0);\n\tgoto L_0047;\nL_0058:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v45 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_005D:\n\tgoto L_0062;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v184, v109, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv195 = Spine.Unity.AttachmentTools.AtlasUtilities;\nL_0062:\n\tv118 = v121.CachedRegionTextures == 0;\n\tif (v118) goto L_0089;\n\tv107 = *([v106 @ X22_v2 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.Dictionary`2<Spine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey, UnityEngine.Texture2D>::Clear(v121.CachedRegionTextures);\n\tv120 = v204.CachedRegionTexturesList;\n\tv117 = v204.CachedRegionTexturesList == 0;\n\tif (v117) goto L_0089;\n\tv209 = v120._version + 1;\n\tv120._size = 0;\n\tv120._version = v209;\n\tv220 = v120._size < 1;\n\tif (v220) goto L_0088;\n\tSystem.Array::Clear(v120._items, 0, v120._size);\nL_0088:\n\treturn;\nL_0089:\n\tv124 = new System.NullReferenceException();\n\tgoto L_0095;\nL_0095:\n\tv156 = v107 != 1;\n\tif (v156) goto L_00A3;\n\tv165 = System.Collections.Generic.List`1<UnityEngine.Texture2D>+Enumerator<UnityEngine.Texture2D>::Dispose(v124);\n\tv188 = System.Collections.Generic.List`1<UnityEngine.Texture2D>+Enumerator<UnityEngine.Texture2D>::Dispose(v165);\n\tv107 = *([v104 @ X23_v2 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v45 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv171 = *([v165 @ X0_v16 (System.Collections.Generic.List`1<UnityEngine.Texture2D>+Enumerator<UnityEngine.Texture2D>)]) == 0;\n\tif (v171) goto L_005D;\n\tthrow System.OutOfMemoryException;\nL_00A3:\n\tgoto L_00A7;\n\tX20 = X0;\nL_00A7:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v45 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00AE;\n\tv199 = 0xBD3CD0(v124, *([v104 @ X23_v2 (Il2CppMethodInfo)]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AE:\n\tv202 = new System.OutOfMemoryException();\n\tv206 = 0x9DACB4(v202, *([v104 @ X23_v2 (Il2CppMethodInfo)]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void ClearCache()
		{
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			if (CachedRegionTexturesList == null)
			{
				goto IL_0122;
			}
			List<Texture2D>.Enumerator enumerator2 = CachedRegionTexturesList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null);
			}
			enumerator.Dispose();
			nint num = 0;
			nint num2 = 0;
			nint num3 = 0;
			goto IL_01d7;
			IL_0122:
			NullReferenceException ex = new NullReferenceException();
			if (num3 == 1)
			{
				((List<Texture2D>.Enumerator*)ex)->Dispose();
				List<Texture2D>.Enumerator enumerator3 = default(List<Texture2D>.Enumerator);
				((List<Texture2D>.Enumerator*)enumerator3)->Dispose();
				num3 = num;
				enumerator.Dispose();
				if ((object)enumerator3 == null)
				{
					goto IL_01d7;
				}
				throw new OutOfMemoryException();
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			return;
			IL_01d7:
			if (CachedRegionTextures != null)
			{
				num3 = num2;
				CachedRegionTextures.Clear();
				List<Texture2D> cachedRegionTexturesList = CachedRegionTexturesList;
				if (CachedRegionTexturesList != null)
				{
					int version = cachedRegionTexturesList._version + 1;
					cachedRegionTexturesList._size = 0;
					cachedRegionTexturesList._version = version;
					if (cachedRegionTexturesList.Count >= 1)
					{
						Array.Clear(cachedRegionTexturesList._items, 0, cachedRegionTexturesList.Count);
					}
					return;
				}
			}
			goto IL_0122;
		}

		[Token(Token = "0x600070E")]
		[Address(RVA = "0x1574A5C", Offset = "0x1574A5C", Length = "0x304")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv52 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, textureFormat, mipmaps, texturePropertyId, linear, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, textureFormat, mipmaps, texturePropertyId, linear, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, textureFormat, mipmaps, texturePropertyId, linear, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, textureFormat, mipmaps, texturePropertyId, linear, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv215 = UnityEngine.Object;\n\tv216 = \"il2cpp_codegen_initialize_runtime_metadata\"(v215, textureFormat, mipmaps, texturePropertyId, linear, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv223 = UnityEngine.Texture2D;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v223, textureFormat, mipmaps, texturePropertyId, linear, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv67 = 1;\n\t*([1A37D08]) = v67;\nL_0039:\n\tv69 = 0;\n\tSpine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey::.ctor(&v69 @ stack_-98_v1 (Spine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey), texturePropertyId, ar);\n\tgoto L_004E;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v78, v70, v71, v72, linear, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv87 = Spine.Unity.AttachmentTools.AtlasUtilities;\nL_004E:\n\tv103 = System.Collections.Generic.Dictionary`2<Spine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey, UnityEngine.Texture2D>::TryGetValue(v88.CachedRegionTextures, 0, 0);\n\tgoto L_0059;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v217, v96, v97, v99, v101, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_0059:\n\tv229 = UnityEngine.Object::op_Equality(v100, 0);\n\tv323 = v229 == 0;\n\tif (v323) goto L_0112;\n\tgoto L_0064;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v324, v227, v228, v99, v101, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_0064:\n\tv357 = texturePropertyId == 0;\n\tif (v357) goto L_0069;\n\tv362 = Spine.Unity.AttachmentTools.AtlasUtilities::GetTexture(ar, texturePropertyId);\n\tgoto L_006F;\nL_0069:\n\tv362 = Spine.Unity.AttachmentTools.AtlasUtilities::GetMainTexture(ar);\nL_006F:\n\tgoto L_0072;\n\tv367 = \"il2cpp_codegen_runtime_class_init\"(v363, v361, v228, v99, v101, applyPMA, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_0072:\n\tv173 = Spine.Unity.AttachmentTools.AtlasUtilities::GetUnityRect(ar);\n\tv382 = v173.m_Height != 0x7F800000;\n\tif (v382) goto L_FFFFFFFF;\n\tgoto L_0090;\nL_0090:\n\tv193 = new UnityEngine.Texture2D();\n\tv117 = v173.m_Width != 0x7F800000;\n\tif (v117) goto L_FFFFFFFF;\n\tgoto L_00A7;\nL_00A7:\n\tUnityEngine.Texture2D::.ctor(v193, v188, v115, textureFormat, mipmaps, linear);\n\tUnityEngine.Object::set_name(v193, ar.name);\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTextureAttributesFrom(v193, v362);\n\tgoto L_00C2;\n\tv396 = \"il2cpp_codegen_runtime_class_init\"(v392, v391, v186, v181, v176, v107, v105, v55, v173, v170, v167, v164, v60, v61, v62, v63);\nL_00C2:\n\tv400 = applyPMA == 0;\n\tif (v400) goto L_00C8;\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTextureApplyPMA(v362, v173, v193);\n\tgoto L_00CD;\nL_00C8:\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTexture(v362, v173, v193);\nL_00CD:\n\tgoto L_00DA;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v403, v191, v186, v181, v176, v107, v105, v55, v174, v171, v168, v165, v60, v61, v62, v63);\n\tv409 = Spine.Unity.AttachmentTools.AtlasUtilities;\nL_00DA:\n\tSystem.Collections.Generic.Dictionary`2<Spine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey, UnityEngine.Texture2D>::Add(v210.CachedRegionTextures, 0, 0);\n\tv194 = v208.CachedRegionTexturesList;\n\tv209 = v194._items;\n\tv161 = v194._version + 1;\n\tv194._version = v161;\n\tv346 = v194._size;\n\tv416 = v194._size < v209.Length;\n\tv343 = ~v416;\n\tif (v343) goto L_00FF;\n\tv345 = v194._size + 1;\n\tv194._size = v345;\n\tv209[v346 @ X10_v7 (System.Int32)] = v193;\n\tgoto L_0112;\nL_00FF:\n\tSystem.Collections.Generic.List`1<UnityEngine.Texture2D>::AddWithResize(v194, v193);\nL_0112:\n\treturn v293;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Texture2D ToTexture(this AtlasRegion ar, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, int texturePropertyId = 0, bool linear = false, bool applyPMA = false)
		{
			//IL_02c0: Expected I4, but got F4
			//IL_011a: Expected I4, but got F4
			IntAndAtlasRegionKey intAndAtlasRegionKey = default(IntAndAtlasRegionKey);
			intAndAtlasRegionKey = new IntAndAtlasRegionKey(texturePropertyId, ar);
			bool flag = CachedRegionTextures.TryGetValue(default(IntAndAtlasRegionKey), out *(Texture2D*)null);
			UnityEngine.Object obj = default(UnityEngine.Object);
			bool flag2 = obj == null;
			bool flag3 = !flag2;
			Texture2D result = (Texture2D)obj;
			if (!flag3)
			{
				Texture2D source = ((texturePropertyId == 0) ? ar.GetMainTexture() : ar.GetTexture(texturePropertyId));
				Rect unityRect = ar.GetUnityRect();
				float num = ((unityRect.m_Height != float.PositiveInfinity) ? unityRect.m_Height : -0f);
				int width = default(int);
				Texture2D texture2D = new Texture2D(width, (int)num, textureFormat, mipmaps, linear);
				if (unityRect.m_Width == float.PositiveInfinity)
				{
					width = int.MinValue;
				}
				else
				{
					width = (int)unityRect.m_Width;
				}
				texture2D.name = ar.name;
				texture2D.CopyTextureAttributesFrom(source);
				if (applyPMA)
				{
					CopyTextureApplyPMA(source, unityRect, texture2D);
				}
				else
				{
					CopyTexture(source, unityRect, texture2D);
				}
				CachedRegionTextures.Add(default(IntAndAtlasRegionKey), null);
				List<Texture2D> cachedRegionTexturesList = CachedRegionTexturesList;
				Texture2D[] items = cachedRegionTexturesList._items;
				int version = cachedRegionTexturesList._version + 1;
				cachedRegionTexturesList._version = version;
				int count = cachedRegionTexturesList.Count;
				if (cachedRegionTexturesList.Count < items.Length)
				{
					int size = cachedRegionTexturesList.Count + 1;
					cachedRegionTexturesList._size = size;
					items[count] = texture2D;
					result = texture2D;
				}
				else
				{
					cachedRegionTexturesList.Add(texture2D);
					result = texture2D;
				}
			}
			return result;
		}

		[Token(Token = "0x600070F")]
		[Address(RVA = "0x1573B7C", Offset = "0x1573B7C", Length = "0x364")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv46 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, textureFormat, mipmaps, linear, applyPMA, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv65 = System.Math;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, textureFormat, mipmaps, linear, applyPMA, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv199 = UnityEngine.Texture2D;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, textureFormat, mipmaps, linear, applyPMA, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv62 = 1;\n\t*([1A37D09]) = v62;\nL_002A:\n\tv69 = UnityEngine.Sprite::get_texture(s);\n\tv202 = UnityEngine.Sprite::get_packed(s);\n\tv247 = v202 == 0;\n\tif (v247) goto L_0042;\n\tv250 = UnityEngine.Sprite::get_packingMode(s);\n\tv104 = v250 != 1;\n\tif (v104) goto L_004D;\nL_0042:\n\tv264 = UnityEngine.Sprite::get_textureRect(s);\n\tgoto L_00FD;\nL_004D:\n\tv167 = UnityEngine.Sprite::get_uv(s);\n\tv168 = UnityEngine.Sprite::get_uv(s);\n\tgoto L_0073;\n\tv437 = v188;\n\tv438 = \"il2cpp_codegen_runtime_class_init\"(v437, v159, mipmaps, linear, applyPMA, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_0073:\n\tv100 = System.Math::Min(&v167[0], &v168[1]);\n\tv450 = UnityEngine.Texture::get_width(v69);\n\tv170 = UnityEngine.Sprite::get_uv(s);\n\tv171 = UnityEngine.Sprite::get_uv(s);\n\tv101 = System.Math::Max(&v170[0], &v171[1]);\n\tv465 = UnityEngine.Texture::get_width(v69);\n\tv172 = UnityEngine.Sprite::get_uv(s);\n\tv173 = UnityEngine.Sprite::get_uv(s);\n\tv102 = System.Math::Min(*([v172 @ X0_v42 (UnityEngine.Vector2[])+24]), *([v173 @ X0_v44 (UnityEngine.Vector2[])+34]));\n\tv474 = UnityEngine.Texture::get_height(v69);\n\tv174 = UnityEngine.Sprite::get_uv(s);\n\tv175 = UnityEngine.Sprite::get_uv(s);\n\tv378 = v100 * v450;\n\tv480 = v101 * v465;\n\tv373 = v480 - v378;\n\tv375 = v102 * v474;\n\tv484 = System.Math::Max(*([v174 @ X0_v49 (UnityEngine.Vector2[])+24]), *([v175 @ X0_v51 (UnityEngine.Vector2[])+34]));\n\tv397 = UnityEngine.Texture::get_height(v69);\n\tv385 = v484 * v397;\n\tv371 = v385 - v375;\nL_00FD:\n\tv406 = new UnityEngine.Texture2D();\n\tv418 = v373 != 0x7F800000;\n\tif (v418) goto L_FFFFFFFF;\n\tgoto L_011B;\nL_011B:\n\tv284 = v371 != 0x7F800000;\n\tif (v284) goto L_FFFFFFFF;\n\tgoto L_0126;\nL_0126:\n\tUnityEngine.Texture2D::.ctor(v406, v422, v282, textureFormat, mipmaps, linear);\n\tgoto L_012F;\n\tv441 = \"il2cpp_codegen_runtime_class_init\"(v433, v422, v282, v268, v272, v270, v266, v50, v407, v382, v380, v379, v55, v56, v57, v58);\nL_012F:\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTextureAttributesFrom(v406, v69);\n\tgoto L_013D;\n\tv452 = \"il2cpp_codegen_runtime_class_init\"(v445, v444, v282, v268, v272, v270, v266, v50, v407, v382, v380, v379, v55, v56, v57, v58);\nL_013D:\n\tv341 = applyPMA == 0;\n\tif (v341) goto L_0142;\n\t// 319 MakeStruct v456 @ AGG1577EA4_1_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), v377 @ V9_v3 (UnityEngine.Rect), v375 @ V10_v3 (System.Single), v373 @ V8_v3 (System.Single), v371 @ V11_v3 (System.Single)\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTextureApplyPMA(v69, v456, v406);\n\tgoto L_0155;\nL_0142:\n\t// 322 MakeStruct v457 @ AGG1577EAC_1_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), v377 @ V9_v3 (UnityEngine.Rect), v375 @ V10_v3 (System.Single), v373 @ V8_v3 (System.Single), v371 @ V11_v3 (System.Single)\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTexture(v69, v457, v406);\nL_0155:\n\treturn v406;\n\tv197 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 278 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static Texture2D ToTexture(this Sprite s, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, bool linear = false, bool applyPMA = false)
		{
			//IL_028a: Expected I4, but got F4
			//IL_02a5: Expected I4, but got F4
			//IL_00f9: Expected F4, but got Ref
			//IL_00f9: Expected F4, but got Ref
			//IL_0154: Expected F4, but got Ref
			//IL_0154: Expected F4, but got Ref
			//IL_01a6: Expected F4, but got I
			//IL_01a6: Expected F4, but got I
			//IL_0237: Expected F4, but got I
			//IL_0237: Expected F4, but got I
			//IL_026f: Expected O, but got F4
			Texture2D texture = s.texture;
			float num7;
			float num8;
			float num12;
			Rect rect;
			if (s.packed)
			{
				SpritePackingMode packingMode = s.packingMode;
				if (packingMode != SpritePackingMode.Rectangle)
				{
					Vector2[] uv = s.uv;
					Vector2[] uv2 = s.uv;
					float num = Math.Min((float)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref uv[0]), (float)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref uv2[1]));
					int width = texture.width;
					Vector2[] uv3 = s.uv;
					Vector2[] uv4 = s.uv;
					float num2 = Math.Max((float)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref uv3[0]), (float)(nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref uv4[1]));
					int width2 = texture.width;
					Vector2[] uv5 = s.uv;
					Vector2[] uv6 = s.uv;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X0_v42 (UnityEngine.Vector2[])+24]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v44 (UnityEngine.Vector2[])+34]");
					float num4 = Math.Min(num3, 0f);
					int height = texture.height;
					Vector2[] uv7 = s.uv;
					Vector2[] uv8 = s.uv;
					float num5 = num * (float)width;
					float num6 = num2 * (float)width2;
					num7 = num6 - num5;
					num8 = num4 * (float)height;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X0_v49 (UnityEngine.Vector2[])+24]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X0_v51 (UnityEngine.Vector2[])+34]");
					float num10 = Math.Max(num9, 0f);
					int height2 = texture.height;
					float num11 = num10 * (float)height2;
					num12 = num11 - num8;
					rect = (Rect)num5;
					goto IL_037c;
				}
			}
			Rect textureRect = s.textureRect;
			num12 = textureRect.m_Height;
			num7 = textureRect.m_Width;
			num8 = textureRect.m_YMin;
			rect = textureRect;
			goto IL_037c;
			IL_037c:
			int width3 = default(int);
			int height3 = default(int);
			Texture2D texture2D = new Texture2D(width3, height3, textureFormat, mipmaps, linear);
			if (num7 == float.PositiveInfinity)
			{
				width3 = int.MinValue;
			}
			else
			{
				width3 = (int)num7;
			}
			if (num12 == float.PositiveInfinity)
			{
				height3 = int.MinValue;
			}
			else
			{
				height3 = (int)num12;
			}
			texture2D.CopyTextureAttributesFrom(texture);
			if (applyPMA)
			{
				Rect sourceRect = default(Rect);
				sourceRect.m_XMin = rect.m_XMin;
				sourceRect.m_YMin = num8;
				sourceRect.m_Width = num7;
				sourceRect.m_Height = num12;
				CopyTextureApplyPMA(texture, sourceRect, texture2D);
			}
			else
			{
				Rect sourceRect2 = default(Rect);
				sourceRect2.m_XMin = rect.m_XMin;
				sourceRect2.m_YMin = num8;
				sourceRect2.m_Width = num7;
				sourceRect2.m_Height = num12;
				CopyTexture(texture, sourceRect2, texture2D);
			}
			return texture2D;
		}

		[Token(Token = "0x6000710")]
		[Address(RVA = "0x1573388", Offset = "0x1573388", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv40 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, textureFormat, mipmaps, linear, applyPMA, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv59 = UnityEngine.Texture2D;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, textureFormat, mipmaps, linear, applyPMA, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37D0A]) = v56;\nL_002A:\n\tv68 = UnityEngine.Texture::get_width(t);\n\tv74 = UnityEngine.Texture::get_height(t);\n\tv78 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v78, v68, v74, textureFormat, mipmaps, linear);\n\tgoto L_0045;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v87, v82, v83, v84, v80, v81, v85, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0045:\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTextureAttributesFrom(v78, t);\n\tv153 = UnityEngine.Texture::get_width(t);\n\tv159 = UnityEngine.Texture::get_height(t);\n\tv164 = applyPMA == 0;\n\tif (v164) goto L_0068;\n\tgoto L_0063;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v160, v158, v83, v84, v80, v81, v85, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0063:\n\t// 99 MakeStruct v177 @ AGG15774C0_1_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v153 @ X0_v13 (System.Int32), v159 @ X0_v15 (System.Int32)\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTextureApplyPMA(t, v177, v78);\n\tgoto L_0080;\nL_0068:\n\tgoto L_0070;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v160, v158, v83, v84, v80, v81, v85, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0070:\n\t// 112 MakeStruct v186 @ AGG15774E8_1_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v153 @ X0_v13 (System.Int32), v159 @ X0_v15 (System.Int32)\n\tSpine.Unity.AttachmentTools.AtlasUtilities::CopyTexture(t, v186, v78);\nL_0080:\n\treturn v78;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Texture2D GetClone(this Texture2D t, TextureFormat textureFormat = TextureFormat.RGBA32, bool mipmaps = false, bool linear = false, bool applyPMA = false)
		{
			int width = t.width;
			int height = t.height;
			Texture2D texture2D = new Texture2D(width, height, textureFormat, mipmaps, linear);
			texture2D.CopyTextureAttributesFrom(t);
			int width2 = t.width;
			int height2 = t.height;
			if (applyPMA)
			{
				Rect sourceRect = default(Rect);
				sourceRect.m_XMin = 0f;
				sourceRect.m_YMin = 0f;
				sourceRect.m_Width = width2;
				sourceRect.m_Height = height2;
				CopyTextureApplyPMA(t, sourceRect, texture2D);
			}
			else
			{
				Rect sourceRect2 = default(Rect);
				sourceRect2.m_XMin = 0f;
				sourceRect2.m_YMin = 0f;
				sourceRect2.m_Width = width2;
				sourceRect2.m_Height = height2;
				CopyTexture(t, sourceRect2, texture2D);
			}
			return texture2D;
		}

		[Token(Token = "0x6000711")]
		[Address(RVA = "0x1576828", Offset = "0x1576828", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = UnityEngine.Graphics;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, destination, methodInfo, v37, v38, v39, v40, v41, sourceRect, v0, v2, v3, v42, v43, v44, v45);\n\tv48 = 1;\n\t*([1A37D0B]) = v48;\nL_001E:\n\tv50 = UnityEngine.SystemInfo::get_copyTextureSupport();\n\tv51 = v50 == 0;\n\tif (v51) goto L_0090;\n\tgoto L_0037;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v54, destination, methodInfo, v37, v38, v39, v40, v41, sourceRect, v0, v2, v3, v42, v43, v44, v45);\nL_0037:\n\tv75 = sourceRect != 0x7F800000;\n\tif (v75) goto L_FFFFFFFF;\n\tgoto L_0047;\nL_0047:\n\tv162 = sourceRect.m_YMin != 0x7F800000;\n\tif (v162) goto L_FFFFFFFF;\n\tgoto L_0057;\nL_0057:\n\tv270 = sourceRect.m_Width != 0x7F800000;\n\tif (v270) goto L_FFFFFFFF;\n\tgoto L_0066;\nL_0066:\n\tv210 = sourceRect.m_Height != 0x7F800000;\n\tif (v210) goto L_FFFFFFFF;\n\tgoto L_0075;\nL_0075:\n\tUnityEngine.Graphics::CopyTexture(source, 0, 0, v151, v207, v205, v203, destination, 0, 0, 0, 0);\n\treturn;\nL_0090:\n\tv90 = sourceRect != 0x7F800000;\n\tif (v90) goto L_FFFFFFFF;\n\tgoto L_00A0;\nL_00A0:\n\tv172 = sourceRect.m_YMin != 0x7F800000;\n\tif (v172) goto L_FFFFFFFF;\n\tgoto L_00B0;\nL_00B0:\n\tv280 = sourceRect.m_Width != 0x7F800000;\n\tif (v280) goto L_FFFFFFFF;\n\tgoto L_00BF;\nL_00BF:\n\tv109 = sourceRect.m_Height != 0x7F800000;\n\tif (v109) goto L_FFFFFFFF;\n\tgoto L_00C7;\nL_00C7:\n\tv142 = UnityEngine.Texture2D::GetPixels(source, v100, v98, v106, v104);\n\tUnityEngine.Texture2D::SetPixels(destination, v142);\n\tUnityEngine.Texture2D::Apply(destination);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 179 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void CopyTexture(Texture2D source, Rect sourceRect, Texture2D destination)
		{
			//IL_00e9: Expected I4, but got O
			//IL_0109: Expected I4, but got F4
			//IL_0047: Expected I4, but got O
			//IL_0129: Expected I4, but got F4
			//IL_0067: Expected I4, but got F4
			//IL_0149: Expected I4, but got F4
			//IL_0087: Expected I4, but got F4
			//IL_00a7: Expected I4, but got F4
			Rect rect = default(Rect);
			if (SystemInfo.copyTextureSupport == CopyTextureSupport.None)
			{
				int x = ((rect.m_XMin != float.PositiveInfinity) ? ((int)sourceRect) : int.MinValue);
				int y = ((sourceRect.m_YMin != float.PositiveInfinity) ? ((int)sourceRect.m_YMin) : int.MinValue);
				int blockWidth = ((sourceRect.m_Width != float.PositiveInfinity) ? ((int)sourceRect.m_Width) : int.MinValue);
				int blockHeight = ((sourceRect.m_Height != float.PositiveInfinity) ? ((int)sourceRect.m_Height) : int.MinValue);
				Color[] pixels = source.GetPixels(x, y, blockWidth, blockHeight);
				destination.SetPixels(pixels);
				destination.Apply();
			}
			else
			{
				int srcX = ((rect.m_XMin != float.PositiveInfinity) ? ((int)sourceRect) : int.MinValue);
				int srcY = ((sourceRect.m_YMin != float.PositiveInfinity) ? ((int)sourceRect.m_YMin) : int.MinValue);
				int srcWidth = ((sourceRect.m_Width != float.PositiveInfinity) ? ((int)sourceRect.m_Width) : int.MinValue);
				int srcHeight = ((sourceRect.m_Height != float.PositiveInfinity) ? ((int)sourceRect.m_Height) : int.MinValue);
				Graphics.CopyTexture(source, 0, 0, srcX, srcY, srcWidth, srcHeight, destination, 0, 0, 0, 0);
			}
		}

		[Token(Token = "0x6000712")]
		[Address(RVA = "0x1576760", Offset = "0x1576760", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = sourceRect != 0x7F800000;\n\tif (v26) goto L_FFFFFFFF;\n\tgoto L_0027;\nL_0027:\n\tv144 = sourceRect.m_YMin != 0x7F800000;\n\tif (v144) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv190 = sourceRect.m_Width != 0x7F800000;\n\tif (v190) goto L_FFFFFFFF;\n\tgoto L_0046;\nL_0046:\n\tv59 = sourceRect.m_Height != 0x7F800000;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tv38 = UnityEngine.Texture2D::GetPixels(source, v57, v53, v50, v47);\n\tv207 = v38.Length < 1;\n\tif (v207) goto L_0083;\n\tv115 = v38.Length & 0xFFFFFFFF;\n\tv105 = v38 + 0x20;\nL_006E:\n\tv109 = v109 + 1;\n\tv210 = *([v105 @ X10_v5]) * v237;\n\tv223 = *([v105 @ X10_v5+8]) * *([v105 @ X10_v5+C]);\n\t*([v105 @ X10_v5]) = v210;\n\t*([v105 @ X10_v5+8]) = v223;\n\tv105 = v105 + 0x10;\n\tv211 = v115 != v109;\n\tif (v211) goto L_006E;\nL_0083:\n\tUnityEngine.Texture2D::SetPixels(destination, v38);\n\tUnityEngine.Texture2D::Apply(destination);\n\treturn;\n\tv37 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void CopyTextureApplyPMA(Texture2D source, Rect sourceRect, Texture2D destination)
		{
			//IL_003d: Expected I4, but got O
			//IL_005d: Expected I4, but got F4
			//IL_007d: Expected I4, but got F4
			//IL_009d: Expected I4, but got F4
			//IL_00d5: Expected I4, but got I8
			//IL_00e4: Expected O, but got I
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_012b: Expected O, but got I
			//IL_0147: Expected O, but got I
			Rect rect = default(Rect);
			int x = ((rect.m_XMin != float.PositiveInfinity) ? ((int)sourceRect) : int.MinValue);
			int y = ((sourceRect.m_YMin != float.PositiveInfinity) ? ((int)sourceRect.m_YMin) : int.MinValue);
			int blockWidth = ((sourceRect.m_Width != float.PositiveInfinity) ? ((int)sourceRect.m_Width) : int.MinValue);
			int blockHeight = ((sourceRect.m_Height != float.PositiveInfinity) ? ((int)sourceRect.m_Height) : int.MinValue);
			Color[] pixels = source.GetPixels(x, y, blockWidth, blockHeight);
			if (pixels.Length >= 1)
			{
				int num = (int)(pixels.Length & 0xFFFFFFFFL);
				object obj = (nint)pixels + 32;
				int num2 = 0;
				object obj3 = default(object);
				do
				{
					num2++;
					object obj2 = obj * (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X10_v5+8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X10_v5+C]");
					object obj4 = num3 * 0;
					obj = obj2;
					obj = (nint)obj + 16;
				}
				while (num != num2);
			}
			destination.SetPixels(pixels);
			destination.Apply();
		}

		[Token(Token = "0x6000713")]
		[Address(RVA = "0x1574A08", Offset = "0x1574A08", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.IHasRendererObject;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37D0C]) = v37;\nL_0015:\n\t// 21 IsInst v40 @ X0_v3, typeof(Spine.IHasRendererObject), a @ X0 (Spine.Attachment)\n\tv47 = v40 == 0;\n\tv52 = ~v47;\n\treturn v52;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsRenderable(Attachment a)
		{
			object obj = a as IHasRendererObject;
			bool flag = obj == null;
			return !flag;
		}

		[Token(Token = "0x6000714")]
		[Address(RVA = "0x1573EE0", Offset = "0x1573EE0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn rect;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Rect SpineUnityFlipRect(this Rect rect, int textureHeight)
		{
			return rect;
		}

		[Token(Token = "0x6000715")]
		[Address(RVA = "0x1576628", Offset = "0x1576628", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37D0D]) = v37;\nL_0017:\n\tgoto L_001B;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001B:\n\treturnVal2 = Spine.Unity.AttachmentTools.AtlasUtilities::GetSpineAtlasRect(region, 1);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Rect GetUnityRect(this AtlasRegion region)
		{
			return region.GetSpineAtlasRect();
		}

		[Token(Token = "0x6000716")]
		[Address(RVA = "0x15769EC", Offset = "0x15769EC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, textureHeight, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37D0E]) = v40;\nL_0019:\n\tgoto L_001D;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, textureHeight, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001D:\n\treturnVal1 = Spine.Unity.AttachmentTools.AtlasUtilities::GetSpineAtlasRect(region, 1);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Rect GetUnityRect(this AtlasRegion region, int textureHeight)
		{
			return region.GetSpineAtlasRect();
		}

		[Token(Token = "0x6000717")]
		[Address(RVA = "0x1576998", Offset = "0x1576998", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = includeRotate == 0;\n\tif (v4) goto L_001B;\n\tv9 = ~region.rotate;\n\tif (v9) goto L_001B;\n\tgoto L_001B;\nL_001B:\n\treturn region.x;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Rect GetSpineAtlasRect(this AtlasRegion region, bool includeRotate = true)
		{
			//IL_004a: Expected O, but got I4
			if (!includeRotate || region.rotate)
			{
			}
			return (Rect)region.x;
		}

		[Token(Token = "0x6000718")]
		[Address(RVA = "0x1576A60", Offset = "0x1576A60", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = uvRect * texWidth;\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Rect UVRectToTextureRect(Rect uvRect, int texWidth, int texHeight)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			return (Rect)(uvRect * texWidth);
		}

		[Token(Token = "0x6000719")]
		[Address(RVA = "0x1573EF0", Offset = "0x1573EF0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = texWidth == 0;\n\tif (v10) goto L_0019;\n\tv11 = textureRect / texWidth;\n\tv15 = v11 < 0;\n\tif (v15) goto L_0019;\n\tv39 = UnityEngine.Mathf::Min(v11, 1f);\nL_0019:\n\tv43 = texHeight == 0;\n\tif (v43) goto L_002A;\n\tv45 = textureRect.m_YMin / texHeight;\n\tv49 = v45 < 0;\n\tif (v49) goto L_002A;\n\tv65 = UnityEngine.Mathf::Min(v45, 1f);\nL_002A:\n\tv68 = texWidth == 0;\n\tif (v68) goto L_003A;\n\tv70 = textureRect.m_Width / texWidth;\n\tv74 = v70 < 0;\n\tif (v74) goto L_003A;\n\tv90 = UnityEngine.Mathf::Min(v70, 1f);\nL_003A:\n\tv92 = texHeight == 0;\n\tif (v92) goto L_004B;\n\tv94 = textureRect.m_Height / texHeight;\n\tv98 = v94 < 0;\n\tif (v98) goto L_004B;\n\tv113 = UnityEngine.Mathf::Min(v94, 1f);\nL_004B:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Rect TextureRectToUVRect(Rect textureRect, int texWidth, int texHeight)
		{
			//IL_007f: Expected O, but got F4
			bool flag = texWidth == 0;
			Rect result = default(Rect);
			if (!flag)
			{
				Rect rect = default(Rect);
				float num = rect.m_XMin / (float)texWidth;
				bool flag2 = num < 0f;
				result = default(Rect);
				if (!flag2)
				{
					float num2 = Mathf.Min(num, 1f);
					result = (Rect)num2;
				}
			}
			if (texHeight != 0)
			{
				float num3 = textureRect.m_YMin / (float)texHeight;
				if (!(num3 < 0f))
				{
					float num4 = Mathf.Min(num3, 1f);
				}
			}
			if (texWidth != 0)
			{
				float num5 = textureRect.m_Width / (float)texWidth;
				if (!(num5 < 0f))
				{
					float num6 = Mathf.Min(num5, 1f);
				}
			}
			if (texHeight != 0)
			{
				float num7 = textureRect.m_Height / (float)texHeight;
				if (!(num7 < 0f))
				{
					float num8 = Mathf.Min(num7, 1f);
				}
			}
			return result;
		}

		[Token(Token = "0x600071A")]
		[Address(RVA = "0x1574E10", Offset = "0x1574E10", Length = "0x4C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv50 = Spine.AtlasRegion;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, page, methodInfo, v53, v54, v55, v56, v57, uvRect, v0, v2, v3, v58, v59, v60, v61);\n\tv68 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, page, methodInfo, v53, v54, v55, v56, v57, uvRect, v0, v2, v3, v58, v59, v60, v61);\n\tv65 = 1;\n\t*([1A37D0F]) = v65;\nL_0033:\n\tgoto L_003E;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v73, page, methodInfo, v53, v54, v55, v56, v57, uvRect, v0, v2, v3, v58, v59, v60, v61);\n\tv169 = *([v38 @ X20_v1 (Spine.AtlasPage)+3C]);\nL_003E:\n\tv289 = uvRect.m_Width * page.width;\n\tv133 = uvRect.m_Height * page.height;\n\tif (referenceRegion.rotate) goto L_FFFFFFFF;\n\tgoto L_0053;\nL_0053:\n\tif (referenceRegion.rotate) goto L_0063;\n\tgoto L_0063;\nL_0063:\n\tv300 = v285 != 0x7F800000;\n\tif (v300) goto L_FFFFFFFF;\n\tgoto L_0075;\nL_0075:\n\tv315 = v289 != 0x7F800000;\n\tif (v315) goto L_FFFFFFFF;\n\tgoto L_007F;\nL_007F:\n\tv322 = referenceRegion.originalWidth / referenceRegion.width;\n\tgoto L_008A;\n\tv326 = System.Math;\n\tv327 = \"il2cpp_codegen_initialize_runtime_metadata\"(v326, page, methodInfo, v53, v54, v55, v56, v57, v319, v320, v164, v3, v58, v59, v60, v61);\n\tv330 = 1;\n\t*([1A36454]) = v330;\nL_008A:\n\tv332 = v322 * v148;\n\tgoto L_0094;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v333, page, methodInfo, v53, v54, v55, v56, v57, v319, v320, v164, v3, v58, v59, v60, v61);\nL_0094:\n\tv343 = 0x1854ED0(&v341 @ stack_-88_v2 (System.Double), page, methodInfo, v53, v54, v55, v56, v57, v332, referenceRegion.width, referenceRegion.originalWidth, uvRect.m_Height, v58, v59, v60, v61);\n\tv353 = v332 >= 0;\n\tif (v353) goto L_00BA;\n\tv364 = v332 != -0.5d;\n\tif (v364) goto L_00CC;\n\tgoto L_00BF;\nL_00BA:\n\tv375 = v332 != 0.5d;\n\tif (v375) goto L_00CF;\nL_00BF:\n\tv396 = v393 + v394;\n\tv397 = v393 & 1;\n\tv399 = v397 == 0;\n\tv402 = ~v399;\n\tif (v402) goto L_FFFFFFFF;\n\tgoto L_00CB;\nL_00CB:\n\tgoto L_00D7;\nL_00CC:\n\tv378 = v332 + -0.5d;\n\tv156 = System.Math::Ceiling(v378);\n\tgoto L_00D7;\nL_00CF:\n\tv382 = v332 + 0.5d;\n\tv156 = System.Math::Floor(v382);\nL_00D7:\n\tv424 = referenceRegion.originalHeight / referenceRegion.height;\n\tgoto L_00E1;\n\tv430 = System.Math;\n\tv431 = \"il2cpp_codegen_initialize_runtime_metadata\"(v430, page, methodInfo, v53, v54, v55, v56, v57, v422, v423, v164, v3, v58, v59, v60, v61);\n\tv434 = 1;\n\t*([1A36454]) = v434;\nL_00E1:\n\tv436 = v424 * v101;\n\tgoto L_00EA;\n\tv440 = \"il2cpp_codegen_runtime_class_init\"(v435, page, methodInfo, v53, v54, v55, v56, v57, v422, v423, v164, v3, v58, v59, v60, v61);\nL_00EA:\n\tv446 = 0x1854ED0(&v341 @ stack_-88_v2 (System.Double), page, methodInfo, v53, v54, v55, v56, v57, v436, referenceRegion.height, referenceRegion.originalWidth, uvRect.m_Height, v58, v59, v60, v61);\n\tv456 = v436 >= 0;\n\tif (v456) goto L_010F;\n\tv467 = v436 != -0.5d;\n\tif (v467) goto L_0121;\n\tgoto L_0114;\nL_010F:\n\tv478 = v436 != 0.5d;\n\tif (v478) goto L_0124;\nL_0114:\n\tv520 = v496 + v497;\n\tv500 = v496 & 1;\n\tv502 = v500 == 0;\n\tv505 = ~v502;\n\tif (v505) goto L_FFFFFFFF;\n\tgoto L_0120;\nL_0120:\n\tgoto L_012A;\nL_0121:\n\tv481 = v436 + -0.5d;\n\tv158 = System.Math::Ceiling(v481);\n\tgoto L_012A;\nL_0124:\n\tv485 = v436 + 0.5d;\n\tv158 = System.Math::Floor(v485);\nL_012A:\n\tv525 = v148 / referenceRegion.width;\n\tgoto L_0134;\n\tv531 = System.Math;\n\tv532 = \"il2cpp_codegen_initialize_runtime_metadata\"(v531, page, methodInfo, v53, v54, v55, v56, v57, v524, v520, v164, v3, v58, v59, v60, v61);\n\tv535 = 1;\n\t*([1A36454]) = v535;\nL_0134:\n\tv537 = referenceRegion.offsetX * v525;\n\tgoto L_013D;\n\tv541 = \"il2cpp_codegen_runtime_class_init\"(v536, page, methodInfo, v53, v54, v55, v56, v57, v524, v520, v164, v3, v58, v59, v60, v61);\nL_013D:\n\tv547 = 0x1854ED0(&v341 @ stack_-88_v2 (System.Double), page, methodInfo, v53, v54, v55, v56, v57, v537, v520, referenceRegion.originalWidth, uvRect.m_Height, v58, v59, v60, v61);\n\tv557 = v537 >= 0;\n\tif (v557) goto L_0162;\n\tv568 = v537 != -0.5d;\n\tif (v568) goto L_0174;\n\tgoto L_0167;\nL_0162:\n\tv579 = v537 != 0.5d;\n\tif (v579) goto L_0177;\nL_0167:\n\tv621 = v597 + v598;\n\tv601 = v597 & 1;\n\tv603 = v601 == 0;\n\tv606 = ~v603;\n\tif (v606) goto L_FFFFFFFF;\n\tgoto L_0173;\nL_0173:\n\tgoto L_017D;\nL_0174:\n\tv582 = v537 + -0.5d;\n\tv86 = System.Math::Ceiling(v582);\n\tgoto L_017D;\nL_0177:\n\tv586 = v537 + 0.5d;\n\tv86 = System.Math::Floor(v586);\nL_017D:\n\tv626 = v101 / referenceRegion.height;\n\tgoto L_0187;\n\tv632 = System.Math;\n\tv633 = \"il2cpp_codegen_initialize_runtime_metadata\"(v632, page, methodInfo, v53, v54, v55, v56, v57, v625, v621, v164, v3, v58, v59, v60, v61);\n\tv636 = 1;\n\t*([1A36454]) = v636;\nL_0187:\n\tv88 = referenceRegion.offsetY * v626;\n\tgoto L_0192;\n\tv641 = \"il2cpp_codegen_runtime_class_init\"(v637, page, methodInfo, v53, v54, v55, v56, v57, v625, v621, v164, v3, v58, v59, v60, v61);\nL_0192:\n\tv648 = 0x1854ED0(&v341 @ stack_-88_v2 (System.Double), page, methodInfo, v53, v54, v55, v56, v57, v88, v621, referenceRegion.originalWidth, uvRect.m_Height, v58, v59, v60, v61);\n\tv658 = v88 >= 0;\n\tif (v658) goto L_01B7;\n\tv669 = v88 != -0.5d;\n\tif (v669) goto L_01C9;\n\tgoto L_01BC;\nL_01B7:\n\tv680 = v88 != 0.5d;\n\tif (v680) goto L_01CC;\nL_01BC:\n\tv701 = v698 + v699;\n\tv702 = v698 & 1;\n\tv704 = v702 == 0;\n\tv707 = ~v704;\n\tif (v707) goto L_FFFFFFFF;\n\tgoto L_01C8;\nL_01C8:\n\tgoto L_01CF;\nL_01C9:\n\tv683 = v88 + -0.5d;\n\tv99 = System.Math::Ceiling(v683);\n\tgoto L_01CF;\nL_01CC:\n\tv687 = v88 + 0.5d;\n\tv99 = System.Math::Floor(v687);\nL_01CF:\n\tv150 = new Spine.AtlasRegion();\n\tSpine.AtlasRegion::.ctor(v150);\n\tv719 = uvRect.m_YMin * page.height;\n\tv720 = page.height - v719;\n\tv150.page = page;\n\tv735 = uvRect.m_Width + uvRect;\n\tv736 = v720 - v133;\n\tv737 = v158 != 0x7FF0000000000000;\n\tif (v737) goto L_FFFFFFFF;\n\tgoto L_0201;\nL_0201:\n\tv280 = uvRect * page.width;\n\tv150.u2 = v735;\n\tv150.v2 = uvRect.m_YMin;\n\tv750 = v156 != 0x7FF0000000000000;\n\tif (v750) goto L_FFFFFFFF;\n\tgoto L_0216;\nL_0216:\n\tv763 = uvRect.m_Height + uvRect.m_YMin;\n\tv764 = v736 != 0x7F800000;\n\tif (v764) goto L_FFFFFFFF;\n\tgoto L_0229;\nL_0229:\n\tv150.u = uvRect;\n\tv150.v = v763;\n\tv150.originalHeight = v740;\n\tv150.index = 0xFFFFFFFF;\n\tv776 = v280 != 0x7F800000;\n\tif (v776) goto L_FFFFFFFF;\n\tgoto L_023D;\nL_023D:\n\tv789 = v86 != 0x7FF0000000000000;\n\tif (v789) goto L_FFFFFFFF;\n\tgoto L_024C;\nL_024C:\n\tv228 = v99 != 0x7FF0000000000000;\n\tif (v228) goto L_FFFFFFFF;\n\tgoto L_0252;\nL_0252:\n\tv150.width = v148;\n\tv150.height = v101;\n\tv150.originalWidth = v251;\n\tv150.name = referenceRegion.name;\n\tv150.offsetX = v253;\n\tv150.offsetY = v282;\n\tv150.x = v779;\n\tv150.y = v209;\n\tv150.rotate = referenceRegion.rotate;\n\treturn v150;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 442 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AtlasRegion UVRectToAtlasRegion(Rect uvRect, AtlasRegion referenceRegion, AtlasPage page)
		{
			//IL_074a: Unknown result type (might be due to invalid IL or missing references)
			//IL_074f: Expected I4, but got Unknown
			//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ae: Expected I4, but got Unknown
			//IL_080c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0811: Expected I4, but got Unknown
			//IL_086f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0874: Expected I4, but got Unknown
			//IL_0966: Expected I4, but got F8
			//IL_09ef: Expected I4, but got F4
			//IL_09fc: Expected I4, but got F4
			//IL_0a09: Expected I4, but got F8
			//IL_0a42: Expected I4, but got F4
			//IL_0a4f: Expected I4, but got F4
			float num = uvRect.m_Width * (float)page.width;
			float num2 = uvRect.m_Height * (float)page.height;
			float num3 = (referenceRegion.rotate ? num2 : num);
			if (!referenceRegion.rotate)
			{
				num = num2;
			}
			float num4 = ((num3 != float.PositiveInfinity) ? num3 : -0f);
			float num5 = ((num != float.PositiveInfinity) ? num : -0f);
			int num6 = referenceRegion.originalWidth / referenceRegion.width;
			float num7 = (float)num6 * num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num8;
			double num9;
			double num10 = default(double);
			double num11;
			if (num7 < 0f)
			{
				if ((double)num7 != -0.5)
				{
					double a = (double)num7 + -0.5;
					num8 = Math.Ceiling(a);
					goto IL_01be;
				}
				num9 = num10;
				num11 = -1.0;
			}
			else
			{
				if ((double)num7 != 0.5)
				{
					double d = (double)num7 + 0.5;
					num8 = Math.Floor(d);
					goto IL_01be;
				}
				num9 = num10;
				num11 = 1.0;
			}
			double num12 = num9 + num11;
			num8 = (((num9 & 1) != 0) ? num12 : num9);
			goto IL_01be;
			IL_044b:
			float num13 = num5 / (float)referenceRegion.height;
			float num14 = referenceRegion.offsetY * num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num15;
			double num16;
			double num17;
			if (num14 < 0f)
			{
				if ((double)num14 != -0.5)
				{
					double a2 = (double)num14 + -0.5;
					num15 = Math.Ceiling(a2);
					goto IL_0576;
				}
				num16 = num10;
				num17 = -1.0;
			}
			else
			{
				if ((double)num14 != 0.5)
				{
					double d2 = (double)num14 + 0.5;
					num15 = Math.Floor(d2);
					goto IL_0576;
				}
				num16 = num10;
				num17 = 1.0;
			}
			double num18 = num16 + num17;
			num15 = (((num16 & 1) != 0) ? num18 : num16);
			goto IL_0576;
			IL_0306:
			float num19 = num4 / (float)referenceRegion.width;
			float num20 = referenceRegion.offsetX * num19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num21;
			double num23;
			double num24;
			double num22;
			if (num20 < 0f)
			{
				if ((double)num20 != -0.5)
				{
					double a3 = (double)num20 + -0.5;
					num21 = Math.Ceiling(a3);
					num22 = -0.5;
					goto IL_044b;
				}
				num23 = num10;
				num24 = -1.0;
			}
			else
			{
				if ((double)num20 != 0.5)
				{
					double d3 = (double)num20 + 0.5;
					num21 = Math.Floor(d3);
					num22 = 0.5;
					goto IL_044b;
				}
				num23 = num10;
				num24 = 1.0;
			}
			num22 = num23 + num24;
			num21 = (((num23 & 1) != 0) ? num22 : num23);
			goto IL_044b;
			IL_01be:
			int num25 = referenceRegion.originalHeight / referenceRegion.height;
			float num26 = (float)num25 * num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num27;
			double num29;
			double num30;
			double num28;
			if (num26 < 0f)
			{
				if ((double)num26 != -0.5)
				{
					double a4 = (double)num26 + -0.5;
					num27 = Math.Ceiling(a4);
					num28 = -0.5;
					goto IL_0306;
				}
				num29 = num10;
				num30 = -1.0;
			}
			else
			{
				if ((double)num26 != 0.5)
				{
					double d4 = (double)num26 + 0.5;
					num27 = Math.Floor(d4);
					num28 = 0.5;
					goto IL_0306;
				}
				num29 = num10;
				num30 = 1.0;
			}
			num28 = num29 + num30;
			num27 = (((num29 & 1) != 0) ? num28 : num29);
			goto IL_0306;
			IL_0576:
			AtlasRegion atlasRegion = new AtlasRegion();
			float num31 = uvRect.m_YMin * (float)page.height;
			float num32 = (float)page.height - num31;
			atlasRegion.page = page;
			Rect rect = default(Rect);
			float u = uvRect.m_Width + rect.m_XMin;
			float num33 = num32 - num2;
			double num34 = ((num27 != 9.218868437227405E+18) ? num27 : 1.0609978955E-314);
			float num35 = rect.m_XMin * (float)page.width;
			atlasRegion.u2 = u;
			atlasRegion.v2 = uvRect.m_YMin;
			double num36 = ((num8 != 9.218868437227405E+18) ? num8 : 1.0609978955E-314);
			float v = uvRect.m_Height + uvRect.m_YMin;
			float num37 = ((num33 != float.PositiveInfinity) ? num33 : -0f);
			atlasRegion.u = rect.m_XMin;
			atlasRegion.v = v;
			atlasRegion.originalHeight = (int)num34;
			atlasRegion.index = -1;
			float num38 = ((num35 != float.PositiveInfinity) ? num35 : -0f);
			double num39 = ((num21 != 9.218868437227405E+18) ? num21 : 1.715832534E-314);
			double num40 = ((num15 != 9.218868437227405E+18) ? num15 : 1.715832534E-314);
			atlasRegion.width = (int)num4;
			atlasRegion.height = (int)num5;
			atlasRegion.originalWidth = (int)num36;
			atlasRegion.name = referenceRegion.name;
			atlasRegion.offsetX = (float)num39;
			atlasRegion.offsetY = (float)num40;
			atlasRegion.x = (int)num38;
			atlasRegion.y = (int)num37;
			atlasRegion.rotate = referenceRegion.rotate;
			return atlasRegion;
		}

		[Token(Token = "0x600071B")]
		[Address(RVA = "0x1576574", Offset = "0x1576574", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = UnityEngine.Material;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv37 = UnityEngine.Texture2D;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37D10]) = v34;\nL_0015:\n\tv38 = region.page;\n\tgoto L_FFFFFFFF;\n\tv141 = UnityEngine.Material::get_mainTexture(v38.rendererObject);\n\tv131 = v141 == 0;\n\tif (v131) goto L_0056;\n\tv155 = *([v141 @ X0_v5 (UnityEngine.Texture)]) != UnityEngine.Texture2D;\n\tif (v155) goto L_FFFFFFFF;\n\tgoto L_0056;\nL_0056:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Texture2D GetMainTexture(this AtlasRegion region)
		{
			AtlasPage page = region.page;
			Material material = page.rendererObject as Material;
			Texture mainTexture = ((Material)page.rendererObject).mainTexture;
			bool flag = (object)mainTexture == null;
			Texture2D result = (Texture2D)mainTexture;
			if (!flag)
			{
				result = (Texture2D)(((object)mainTexture.GetType() != typeof(Texture2D)) ? null : mainTexture);
			}
			return result;
		}

		[Token(Token = "0x600071C")]
		[Address(RVA = "0x1576A7C", Offset = "0x1576A7C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Material;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, texturePropertyName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = UnityEngine.Texture2D;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, texturePropertyName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37D11]) = v37;\nL_0017:\n\tv41 = region.page;\n\tgoto L_FFFFFFFF;\n\tv148 = UnityEngine.Material::GetTexture(v41.rendererObject, texturePropertyName);\n\tv136 = v148 == 0;\n\tif (v136) goto L_005A;\n\tv162 = *([v148 @ X0_v5 (UnityEngine.Texture)]) != UnityEngine.Texture2D;\n\tif (v162) goto L_FFFFFFFF;\n\tgoto L_005A;\nL_005A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Texture2D GetTexture(this AtlasRegion region, string texturePropertyName)
		{
			AtlasPage page = region.page;
			Material material = page.rendererObject as Material;
			Texture texture = ((Material)page.rendererObject).GetTexture(texturePropertyName);
			bool flag = (object)texture == null;
			Texture2D result = (Texture2D)texture;
			if (!flag)
			{
				result = (Texture2D)(((object)texture.GetType() != typeof(Texture2D)) ? null : texture);
			}
			return result;
		}

		[Token(Token = "0x600071D")]
		[Address(RVA = "0x15766A4", Offset = "0x15766A4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Material;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, texturePropertyId, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = UnityEngine.Texture2D;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, texturePropertyId, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37D12]) = v37;\nL_0017:\n\tv41 = region.page;\n\tgoto L_FFFFFFFF;\n\tv148 = UnityEngine.Material::GetTexture(v41.rendererObject, texturePropertyId);\n\tv136 = v148 == 0;\n\tif (v136) goto L_005A;\n\tv162 = *([v148 @ X0_v5 (UnityEngine.Texture)]) != UnityEngine.Texture2D;\n\tif (v162) goto L_FFFFFFFF;\n\tgoto L_005A;\nL_005A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Texture2D GetTexture(this AtlasRegion region, int texturePropertyId)
		{
			AtlasPage page = region.page;
			Material material = page.rendererObject as Material;
			Texture texture = ((Material)page.rendererObject).GetTexture(texturePropertyId);
			bool flag = (object)texture == null;
			Texture2D result = (Texture2D)texture;
			if (!flag)
			{
				result = (Texture2D)(((object)texture.GetType() != typeof(Texture2D)) ? null : texture);
			}
			return result;
		}

		[Token(Token = "0x600071E")]
		[Address(RVA = "0x1574D60", Offset = "0x1574D60", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Texture::get_filterMode(source);\n\tUnityEngine.Texture::set_filterMode(destination, v13);\n\tv53 = UnityEngine.Texture::get_anisoLevel(source);\n\tUnityEngine.Texture::set_anisoLevel(destination, v53);\n\tv59 = UnityEngine.Texture::get_wrapModeU(source);\n\tUnityEngine.Texture::set_wrapModeU(destination, v59);\n\tv65 = UnityEngine.Texture::get_wrapModeV(source);\n\tUnityEngine.Texture::set_wrapModeV(destination, v65);\n\tv71 = UnityEngine.Texture::get_wrapModeW(source);\n\tUnityEngine.Texture::set_wrapModeW(destination, v71);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void CopyTextureAttributesFrom(this Texture2D destination, Texture2D source)
		{
			FilterMode filterMode = source.filterMode;
			destination.filterMode = filterMode;
			int anisoLevel = source.anisoLevel;
			destination.anisoLevel = anisoLevel;
			TextureWrapMode wrapModeU = source.wrapModeU;
			destination.wrapModeU = wrapModeU;
			TextureWrapMode wrapModeV = source.wrapModeV;
			destination.wrapModeV = wrapModeV;
			TextureWrapMode wrapModeW = source.wrapModeW;
			destination.wrapModeW = wrapModeW;
		}

		[Token(Token = "0x600071F")]
		[Address(RVA = "0x15730F0", Offset = "0x15730F0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value - a;\n\tv3 = b - a;\n\treturnVal1 = v0 / v3;\n\treturn returnVal1;\n")]
		private static float InverseLerp(float a, float b, float value)
		{
			float num = value - a;
			float num2 = b - a;
			return num / num2;
		}

		[Token(Token = "0x6000720")]
		[Address(RVA = "0x1576B38", Offset = "0x1576B38", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv30 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = System.Collections.Generic.Dictionary`2<Spine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey, UnityEngine.Texture2D>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv72 = System.Collections.Generic.List`1<UnityEngine.Texture2D>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv51 = 1;\n\t*([1A37D13]) = v51;\nL_002A:\n\tv53 = new System.Collections.Generic.Dictionary`2<Spine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey, UnityEngine.Texture2D>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.Unity.AttachmentTools.AtlasUtilities+IntAndAtlasRegionKey, UnityEngine.Texture2D>::.ctor(v53);\n\tv63.CachedRegionTextures = v53;\n\tv65 = new System.Collections.Generic.List`1<UnityEngine.Texture2D>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Texture2D>::.ctor(v65);\n\tv78.CachedRegionTexturesList = v65;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AtlasUtilities()
		{
			Dictionary<IntAndAtlasRegionKey, Texture2D> cachedRegionTextures = new Dictionary<IntAndAtlasRegionKey, Texture2D>();
			CachedRegionTextures = cachedRegionTextures;
			List<Texture2D> cachedRegionTexturesList = new List<Texture2D>();
			CachedRegionTexturesList = cachedRegionTexturesList;
		}
	}
}
