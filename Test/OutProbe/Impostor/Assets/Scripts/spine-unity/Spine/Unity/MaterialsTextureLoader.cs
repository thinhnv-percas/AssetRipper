using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x2000072")]
	public class MaterialsTextureLoader : TextureLoader
	{
		[Token(Token = "0x40002BB")]
		[FieldOffset(Offset = "0x10")]
		private SpineAtlasAsset atlasAsset;

		[Token(Token = "0x60004B6")]
		[Address(RVA = "0x1552E44", Offset = "0x1552E44", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.atlasAsset = atlasAsset;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MaterialsTextureLoader(SpineAtlasAsset atlasAsset)
		{
			this.atlasAsset = atlasAsset;
		}

		[Token(Token = "0x60004B7")]
		[Address(RVA = "0x1553264", Offset = "0x1553264", Length = "0x2CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv32 = UnityEngine.Debug;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, page, path, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv56 = UnityEngine.Object;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, page, path, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = System.IO.Path;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, page, path, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv69 = \"Material with texture name \\\"\";\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, page, path, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv167 = \"Material is missing texture: \";\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, page, path, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv210 = \"\\\" not found for atlas asset: \";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v210, page, path, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37BE2]) = v50;\nL_002D:\n\tgoto L_0031;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v51, page, path, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0031:\n\tv62 = System.IO.Path::GetFileNameWithoutExtension(path);\n\tv66 = this.atlasAsset;\n\tv71 = v66.materials;\n\tv181 = v71.Length < 1;\n\tif (v181) goto L_FFFFFFFF;\nL_005A:\n\tv337 = UnityEngine.Material::get_mainTexture(v71[v88 @ X26_v9 (System.Int32)]);\n\tgoto L_0066;\n\tv342 = v155;\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v342, v336, v74, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0066:\n\tv347 = UnityEngine.Object::op_Equality(v337, 0);\n\tv353 = v347 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00E0;\n\tv137 = UnityEngine.Material::get_mainTexture(v71[v88 @ X26_v9 (System.Int32)]);\n\tv400 = UnityEngine.Object::get_name(v137);\n\tv239 = System.String::op_Equality(v400, v62);\n\tv423 = v239 == 0;\n\tv241 = ~v423;\n\tif (v241) goto L_008C;\n\tv88 = v88 + 1;\n\tv219 = v88 < v71.Length;\n\tif (v219) goto L_005A;\nL_008C:\n\tgoto L_0091;\n\tv332 = \"il2cpp_codegen_runtime_class_init\"(v261, v257, v256, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0091:\n\tv139 = UnityEngine.Object::op_Equality(v152, 0);\n\tv339 = v139 == 0;\n\tif (v339) goto L_00B6;\n\tv349 = UnityEngine.Object::get_name(this.atlasAsset);\n\tv310 = System.String::Concat(\"Material with texture name \\\"\", v62, \"\\\" not found for atlas asset: \", v349);\n\tgoto L_FFFFFFFF;\n\tv394 = v378;\n\tv395 = \"il2cpp_codegen_runtime_class_init\"(v394, v361, v362, v359, v363, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00FF;\nL_00B6:\n\tpage.rendererObject = v152;\n\tv351 = page.width == 0;\n\tif (v351) goto L_00C1;\n\tv367 = page.height == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_00DD;\nL_00C1:\n\tv140 = UnityEngine.Material::get_mainTexture(v152);\n\tv417 = UnityEngine.Texture::get_width(v140);\n\tpage.width = v417;\n\tv141 = UnityEngine.Material::get_mainTexture(v152);\n\tv384 = UnityEngine.Texture::get_height(v141);\n\tpage.height = v384;\nL_00DD:\n\treturn;\nL_00E0:\n\tv373 = UnityEngine.Object::get_name(v71[v88 @ X26_v9 (System.Int32)]);\n\tv310 = System.String::Concat(\"Material is missing texture: \", v373);\n\tgoto L_FFFFFFFF;\n\tv419 = v404;\n\tv420 = \"il2cpp_codegen_runtime_class_init\"(v419, v389, v390, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00FF:\n\tUnityEngine.Debug::LogError(v310, v307);\n\treturn;\n\tv165 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 187 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Load(AtlasPage page, string path)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			SpineAtlasAsset spineAtlasAsset = atlasAsset;
			Material[] materials = spineAtlasAsset.materials;
			if (materials.Length < 1)
			{
				goto IL_0154;
			}
			int num = 0;
			Object obj;
			while (true)
			{
				Texture mainTexture = materials[num].mainTexture;
				if (mainTexture == null)
				{
					break;
				}
				Texture mainTexture2 = materials[num].mainTexture;
				string name = mainTexture2.name;
				bool flag = name == fileNameWithoutExtension;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				obj = materials[num];
				if (!flag3)
				{
					num++;
					if (num < materials.Length)
					{
						continue;
					}
					goto IL_0154;
				}
				goto IL_015e;
			}
			string name2 = materials[num].name;
			string message = "Material is missing texture: " + name2;
			Object context = materials[num];
			goto IL_02d7;
			IL_02d7:
			Debug.LogError(message, context);
			return;
			IL_015e:
			if (obj == null)
			{
				string name3 = atlasAsset.name;
				message = "Material with texture name \"" + fileNameWithoutExtension + "\" not found for atlas asset: " + name3;
				context = atlasAsset;
				goto IL_02d7;
			}
			page.rendererObject = obj;
			if (page.width == 0 || page.height == 0)
			{
				Texture mainTexture3 = ((Material)obj).mainTexture;
				int width = mainTexture3.width;
				page.width = width;
				Texture mainTexture4 = ((Material)obj).mainTexture;
				int height = mainTexture4.height;
				page.height = height;
			}
			return;
			IL_0154:
			obj = null;
			goto IL_015e;
		}

		[Token(Token = "0x60004B8")]
		[Address(RVA = "0x1553530", Offset = "0x1553530", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Unload(object texture)
		{
		}
	}
}
