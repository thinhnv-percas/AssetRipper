using System;
using System.Collections.Generic;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[CreateAssetMenu(fileName = "New Spine Atlas Asset", menuName = "Spine/Spine Atlas Asset")]
	[Token(Token = "0x2000071")]
	public class SpineAtlasAsset : AtlasAssetBase
	{
		[Token(Token = "0x40002B8")]
		[FieldOffset(Offset = "0x18")]
		public TextAsset atlasFile;

		[Token(Token = "0x40002B9")]
		[FieldOffset(Offset = "0x20")]
		public Material[] materials;

		[Token(Token = "0x40002BA")]
		[FieldOffset(Offset = "0x28")]
		protected Atlas atlas;

		[Token(Token = "0x17000176")]
		public override bool IsLoaded
		{
			[Token(Token = "0x60004AA")]
			[Address(RVA = "0x15524B4", Offset = "0x15524B4", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.atlas == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = atlas == null;
				return !flag;
			}
		}

		[Token(Token = "0x17000177")]
		public override IEnumerable<Material> Materials
		{
			[Token(Token = "0x60004AB")]
			[Address(RVA = "0x15524C4", Offset = "0x15524C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.materials;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return materials;
			}
		}

		[Token(Token = "0x17000178")]
		public override int MaterialCount
		{
			[Token(Token = "0x60004AC")]
			[Address(RVA = "0x15524CC", Offset = "0x15524CC", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.materials;\n\tv2 = this.materials == 0;\n\tif (v2) goto L_0006;\n\treturn v0.Length;\nL_0006:\n\treturn 0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Material[] array = materials;
				if (materials != null)
				{
					return array.Length;
				}
				return 0;
			}
		}

		[Token(Token = "0x17000179")]
		public override Material PrimaryMaterial
		{
			[Token(Token = "0x60004AD")]
			[Address(RVA = "0x15524E4", Offset = "0x15524E4", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.materials;\n\treturn v2[0];\n\tv7 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Material[] array = materials;
				return array[0];
			}
		}

		[Token(Token = "0x60004AE")]
		[Address(RVA = "0x155250C", Offset = "0x155250C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, materials, initialize, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37BDD]) = v43;\nL_0018:\n\tv45 = UnityEngine.ScriptableObject::CreateInstance();\n\tv51 = Spine.Unity.SpineAtlasAsset::Clear(v45);\n\tv45.atlasFile = atlasText;\n\tv45.materials = materials;\n\tv53 = initialize == 0;\n\tif (v53) goto L_0032;\n\tv59 = Spine.Unity.SpineAtlasAsset::GetAtlas(v45);\nL_0032:\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpineAtlasAsset CreateRuntimeInstance(TextAsset atlasText, Material[] materials, bool initialize)
		{
			SpineAtlasAsset spineAtlasAsset = ScriptableObject.CreateInstance<SpineAtlasAsset>();
			spineAtlasAsset.Clear();
			spineAtlasAsset.atlasFile = atlasText;
			spineAtlasAsset.materials = materials;
			if (initialize)
			{
				Atlas atlas = spineAtlasAsset.GetAtlas();
			}
			return spineAtlasAsset;
		}

		[Token(Token = "0x60004AF")]
		[Address(RVA = "0x15525A4", Offset = "0x15525A4", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv285 = Il2CppMethodInfo;\n\tv286 = \"il2cpp_codegen_initialize_runtime_metadata\"(v285, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv363 = Il2CppMethodInfo;\n\tv364 = \"il2cpp_codegen_initialize_runtime_metadata\"(v363, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv403 = System.Collections.Generic.List`1<System.String>;\n\tv404 = \"il2cpp_codegen_initialize_runtime_metadata\"(v403, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv407 = UnityEngine.Material[];\n\tv408 = \"il2cpp_codegen_initialize_runtime_metadata\"(v407, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv418 = UnityEngine.Material;\n\tv419 = \"il2cpp_codegen_initialize_runtime_metadata\"(v418, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv425 = UnityEngine.Object;\n\tv426 = \"il2cpp_codegen_initialize_runtime_metadata\"(v425, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv431 = \".png\";\n\tv432 = \"il2cpp_codegen_initialize_runtime_metadata\"(v431, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv437 = \"\";\n\tv438 = \"il2cpp_codegen_initialize_runtime_metadata\"(v437, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv489 = \"\\r\";\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v489, textures, materialPropertySource, initialize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37BDE]) = v55;\nL_003E:\n\tv62 = UnityEngine.TextAsset::get_text(atlasText);\n\tv227 = System.String::Replace(v62, \"\\r\", \"\");\n\tv412 = System.String::Split(v227, 0xA, 0);\n\tv228 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v228);\n\tv440 = v412.Length - 1;\n\tv451 = v440 < 1;\n\tif (v451) goto L_00D6;\n\tv89 = v412 + 0x28;\nL_0082:\n\tv230 = System.String::Trim(v412[v262 @ X22_v16 (System.Int32)]);\n\tv78 = v262 + 1;\n\tv635 = v230._stringLength == 0;\n\tv348 = ~v635;\n\tif (v348) goto L_00C3;\n\tv232 = System.String::Trim(*([v89 @ X27_v8+v262 @ X22_v16 (System.Int32)*8]));\n\tv233 = System.String::Replace(v232, \".png\", \"\");\n\tv272 = *([v228 @ X0_v28+10]);\n\tv74 = *([v228 @ X0_v28+1C]) + 1;\n\t*([v228 @ X0_v28+1C]) = v74;\n\tv724 = *([v228 @ X0_v28+18]) < *([v272 @ X8_v36+18]);\n\tv655 = ~v724;\n\tif (v655) goto L_00C0;\n\tv657 = *([v228 @ X0_v28+18]) + 1;\n\tv639 = *([v228 @ X0_v28+18]) << 3;\n\tv663 = v272 + v639;\n\t*([v228 @ X0_v28+18]) = v657;\n\t*([v663 @ X8_v39+20]) = v233;\n\tgoto L_00C3;\nL_00C0:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v228, v233);\nL_00C3:\n\tv505 = v412.Length - 1;\n\tv496 = v78 < v505;\n\tif (v496) goto L_0082;\nL_00D6:\n\t// 214 NewArr v529 @ X0_v31 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), [v228 @ X0_v28+18]\n\tv540 = *([v228 @ X0_v28+18]) < 1;\n\tif (v540) goto L_0188;\nL_00ED:\n\tv235 = System.Collections.Generic.List`1<System.Object>::get_Item(v228, v213);\n\tv190 = textures.Length - 1;\n\tv295 = textures.Length < 1;\n\tif (v295) goto L_FFFFFFFF;\nL_0102:\n\tv86 = v265 << 3;\n\tv712 = textures + v86;\n\tv65 = v712 + 0x20;\n\tv717 = UnityEngine.Object::get_name(*([v65 @ X29_v12]));\n\tv344 = System.String::Equals(v235, v717, 5);\n\tv722 = v344 == 0;\n\tv350 = ~v722;\n\tif (v350) goto L_0130;\n\tv680 = v190 == v265;\n\tif (v680) goto L_FFFFFFFF;\n\tv265 = v265 + 1;\n\tv733 = v265 < textures.Length;\n\tv327 = ~v733;\n\tv296 = ~v327;\n\tif (v296) goto L_0102;\n\tgoto L_018B;\n\tgoto L_014A;\nL_0130:\n\tv237 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v237, materialPropertySource);\n\tUnityEngine.Material::set_mainTexture(v237, *([v65 @ X29_v12]));\nL_014A:\n\tgoto L_014F;\n\tv713 = \"il2cpp_codegen_runtime_class_init\"(v705, v699, v697, v210, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_014F:\n\tv238 = UnityEngine.Object::op_Inequality(v260, 0);\n\tv394 = v238 == 0;\n\tif (v394) goto L_018F;\n\tv723 = v260 == 0;\n\tif (v723) goto L_016A;\n\t// 346 IsInst v479 @ X0_v45, typeof(UnityEngine.Material), v260 @ X26_v10 (UnityEngine.Object)\n\tv481 = v479 == 0;\n\tif (v481) goto L_019E;\nL_016A:\n\tv620 = v213 + 1;\n\tv529[v213 @ X25_v10 (System.Int32)] = v260;\n\tv608 = v620 != *([v228 @ X0_v28+18]);\n\tif (v608) goto L_00ED;\nL_0188:\n\treturnVal2 = Spine.Unity.SpineAtlasAsset::CreateRuntimeInstance(atlasText, v529, initialize);\n\treturn returnVal2;\n\tv283 = new System.NullReferenceException();\nL_018B:\n\tthrow System.IndexOutOfRangeException;\nL_018F:\n\tv405 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v405, \"Could not find matching atlas page in the texture array.\");\n\tthrow v405;\nL_019E:\n\tv487 = new System.ArrayTypeMismatchException();\n\tthrow v487;\n\treturn returnVal1;\n// 310 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpineAtlasAsset CreateRuntimeInstance(TextAsset atlasText, Texture2D[] textures, Material materialPropertySource, bool initialize)
		{
			//IL_0077: Expected O, but got I4
			//IL_00a5: Expected O, but got I
			//IL_011c: Expected O, but got I
			//IL_04dd: Expected O, but got I
			//IL_04ec: Expected O, but got I
			//IL_0151: Expected O, but got I
			//IL_0167: Expected O, but got I
			//IL_01be: Expected O, but got I
			//IL_01e2: Expected O, but got I
			string text = atlasText.text;
			string text2 = text.Replace("\r", "");
			string[] array = text2.Split('\n');
			object obj = new List<string>();
			object obj2 = array.Length - 1;
			if ((nint)obj2 >= 1)
			{
				object obj3 = (nint)array + 40;
				int num = 0;
				bool flag;
				do
				{
					string text3 = array[num].Trim();
					int num2 = num + 1;
					if (text3.Length == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X27_v8+v262 @ X22_v16 (System.Int32)*8]");
						string text4 = ((string)0).Trim();
						string item = text4.Replace(".png", "");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+10]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+1C]");
						object obj5 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X8_v36+18]");
						if (num3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+18]");
							object obj6 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+18]");
							int num4 = (int)((nint)0 << 3);
							object obj7 = (nint)obj4 + num4;
						}
						else
						{
							((List<object>)obj).Add((object)item);
						}
					}
					int num5 = array.Length - 1;
					flag = num2 < num5;
					num = num2;
				}
				while (flag);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+18]");
			Material[] array2 = new Material[0];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+18]");
			if ((nint)0 >= (nint)1)
			{
				int num6 = 0;
				bool flag2;
				do
				{
					string a = (string)((List<object>)obj)[num6];
					int num7 = textures.Length - 1;
					if (textures.Length < 1)
					{
						goto IL_0377;
					}
					int num8 = 0;
					object obj9;
					while (true)
					{
						int num9 = num8 << 3;
						object obj8 = (nint)textures + num9;
						obj9 = (nint)obj8 + 32;
						string b = ((UnityEngine.Object)obj9).name;
						if (string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
						{
							break;
						}
						if (num7 != num8)
						{
							num8++;
							if (num8 >= textures.Length)
							{
								throw new IndexOutOfRangeException();
							}
							continue;
						}
						goto IL_0377;
					}
					Material material = new Material(materialPropertySource);
					material.mainTexture = (Texture)obj9;
					UnityEngine.Object obj10 = material;
					goto IL_03b4;
					IL_03b4:
					if (obj10 != null)
					{
						if ((object)obj10 != null)
						{
							object obj11 = obj10 as Material;
							if (obj11 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						int num10 = num6 + 1;
						array2[num6] = (Material)obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X0_v28+18]");
						flag2 = (nint)num10 != 0;
						num6 = num10;
						continue;
					}
					ArgumentException ex2 = new ArgumentException("Could not find matching atlas page in the texture array.");
					throw ex2;
					IL_0377:
					obj10 = null;
					goto IL_03b4;
				}
				while (flag2);
			}
			return CreateRuntimeInstance(atlasText, array2, initialize);
		}

		[Token(Token = "0x60004B0")]
		[Address(RVA = "0x15529BC", Offset = "0x15529BC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = UnityEngine.Material;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, textures, shader, initialize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = UnityEngine.Object;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, textures, shader, initialize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv64 = \"Spine/Skeleton\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, textures, shader, initialize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37BDF]) = v47;\nL_0023:\n\tgoto L_002A;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v48, textures, shader, initialize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002A:\n\tv62 = UnityEngine.Object::op_Equality(shader, 0);\n\tv66 = v62 == 0;\n\tif (v66) goto L_0035;\n\tv71 = UnityEngine.Shader::Find(\"Spine/Skeleton\");\nL_0035:\n\tv78 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v78, v74);\n\treturnVal1 = Spine.Unity.SpineAtlasAsset::CreateRuntimeInstance(atlasText, textures, v78, initialize);\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SpineAtlasAsset CreateRuntimeInstance(TextAsset atlasText, Texture2D[] textures, Shader shader, bool initialize)
		{
			bool flag = shader == null;
			bool flag2 = !flag;
			Shader shader2 = shader;
			if (!flag2)
			{
				Shader shader3 = Shader.Find("Spine/Skeleton");
				shader2 = shader3;
			}
			Material materialPropertySource = new Material(shader2);
			return CreateRuntimeInstance(atlasText, textures, materialPropertySource, initialize);
		}

		[Token(Token = "0x60004B1")]
		[Address(RVA = "0x1552598", Offset = "0x1552598", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[8];\n\tv3 = this->klass->vtable[8];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (Spine.Unity.SpineAtlasAsset), this @ X0 (Spine.Unity.SpineAtlasAsset), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		private void Reset()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Spine.Unity.SpineAtlasAsset>)+1B8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Spine.Unity.SpineAtlasAsset>)+1C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60004B2")]
		[Address(RVA = "0x1552A9C", Offset = "0x1552A9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.atlas = 0;\n\treturn;\n")]
		public override void Clear()
		{
			atlas = null;
		}

		[Token(Token = "0x60004B3")]
		[Address(RVA = "0x1552AA4", Offset = "0x1552AA4", Length = "0x3A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv20 = Spine.Atlas;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = UnityEngine.Debug;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv58 = Spine.Unity.MaterialsTextureLoader;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv63 = UnityEngine.Object;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv73 = System.IO.StringReader;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv84 = \"Materials not set for atlas asset: \";\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv102 = \"Atlas file not set for atlas asset: \";\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv177 = \"\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v177, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37BE0]) = v40;\nL_002E:\n\tgoto L_0035;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0035:\n\tv56 = UnityEngine.Object::op_Equality(this.atlasFile, 0);\n\tv61 = v56 == 0;\n\tif (v61) goto L_0040;\n\tv87 = UnityEngine.Object::get_name(this);\n\tgoto L_007D;\nL_0040:\n\tv70 = this.materials;\n\tv71 = this.materials == 0;\n\tif (v71) goto L_0076;\n\tv77 = v70.Length == 0;\n\tif (v77) goto L_0076;\n\treturnVal1 = this.atlas;\n\tv97 = this.atlas == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0096;\n\tv185 = UnityEngine.TextAsset::get_text(this.atlasFile);\n\tv238 = new System.IO.StringReader();\n\tSystem.IO.StringReader::.ctor(v238, v185);\n\tv272 = new Spine.Unity.MaterialsTextureLoader();\n\tSystem.Object::.ctor(v272);\n\tv272.atlasAsset = this;\n\tv243 = new Spine.Atlas();\n\tSpine.Atlas::.ctor(v243, v238, \"\", v272);\n\tthis.atlas = v243;\n\tv161 = v243 == 0;\n\tif (v161) goto L_0098;\n\tSpine.Atlas::FlipV(v243);\n\treturnVal1 = this.atlas;\n\tgoto L_0096;\nL_0076:\n\tv87 = UnityEngine.Object::get_name(this);\nL_007D:\n\tv95 = System.String::Concat(v89, v87);\n\tgoto L_0089;\n\tv178 = v104;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v178, v92, v94, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0089:\n\tUnityEngine.Debug::LogError(v95, this);\n\tv233 = Spine.Unity.SpineAtlasAsset::Clear(this);\nL_0096:\n\treturn returnVal1;\n\tv186 = new System.NullReferenceException();\nL_0098:\n\tthrow v242;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\nL_00A8:\n\tv283 = v240 != 1;\n\tif (v283) goto L_0140;\n\tv286 = 0x1854E70(v248, v240, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv315 = *([v286 @ X0_v29]);\n\tv316 = *([v315 @ X8_v17]);\n\tv317 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v316, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv318 = v317 & 1;\n\tv319 = v318 == 0;\n\tif (v319) goto L_0136;\n\tv321 = *([v286 @ X0_v29]);\n\tv322 = 0x1854E80(v317, v316, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv350 = \"SzArrayNew\"(System.String[], 6, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\t*([v350 @ X0_v43 (System.String[])+20]) = \"Error reading atlas file for atlas asset: \";\n\tv386 = UnityEngine.Object::get_name(this, 0);\n\t*([v350 @ X0_v43 (System.String[])+28]) = v386;\n\t*([v350 @ X0_v43 (System.String[])+30]) = \"\\n\";\n\tv431 = *([v321 @ X20_v15]);\n\tv414 = *([v431 @ X8_v25+188]);\n\tv415 = *([v431 @ X8_v25+190]);\n\tv414(v418, v321, v415, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\t*([v350 @ X0_v43 (System.String[])+38]) = v418;\n\t*([v350 @ X0_v43 (System.String[])+40]) = \"\\n\";\n\tv439 = *([v321 @ X20_v15]);\n\tv258 = *([v439 @ X8_v28+1C8]);\n\tv416 = *([v439 @ X8_v28+1D0]);\n\tv258(v420, v321, v416, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\t*([v350 @ X0_v43 (System.String[])+48]) = v420;\n\tv445 = System.String::Concat(v350, 0);\n\tgoto L_0131;\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v448, v444, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0131:\n\tUnityEngine.Debug::LogError(v445, this, 0);\n\tgoto L_FFFFFFFF;\n\tv377 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_0136:\n\tv343 = 0x1854E90(8, v333, v239, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv302 = *([v340 @ X20_v13]);\n\t*([v343 @ X0_v36]) = v302;\n\tv298 = 0x185A000 + 0xF88;\n\tv348 = 0x1854EA0(v343, v298, 0, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv300 = 0x1854E80(v348, v298, 0, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0140:\n\tv306 = 0xBD3CD0(v226, v217, v215, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturnVal2 = 0x9DACB4(v306, v217, v215, v211, v209, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturn returnVal2;\n// 217 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Atlas GetAtlas()
		{
			string text;
			string text2;
			Atlas result;
			if (atlasFile == null)
			{
				text = base.name;
				text2 = "Atlas file not set for atlas asset: ";
			}
			else
			{
				Material[] array = materials;
				if (materials != null && array.Length != 0)
				{
					result = this.atlas;
					if (this.atlas == null)
					{
						string text3 = atlasFile.text;
						StringReader reader = new StringReader(text3);
						MaterialsTextureLoader textureLoader = new MaterialsTextureLoader(this);
						Atlas atlas = (this.atlas = new Atlas(reader, "", textureLoader));
						if (atlas == null)
						{
							Atlas atlas2 = default(Atlas);
							throw atlas2;
						}
						atlas.FlipV();
						result = this.atlas;
					}
					goto IL_01a1;
				}
				text = base.name;
				text2 = "Materials not set for atlas asset: ";
			}
			string message = text2 + text;
			Debug.LogError(message, this);
			Clear();
			result = null;
			goto IL_01a1;
			IL_01a1:
			return result;
		}

		[Token(Token = "0x60004B4")]
		[Address(RVA = "0x1552E6C", Offset = "0x1552E6C", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv36 = UnityEngine.Color[];\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv56 = System.Int32[];\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv198 = UnityEngine.Material;\n\tv199 = \"il2cpp_codegen_initialize_runtime_metadata\"(v198, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv202 = UnityEngine.Mesh;\n\tv203 = \"il2cpp_codegen_initialize_runtime_metadata\"(v202, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv288 = UnityEngine.Object;\n\tv289 = \"il2cpp_codegen_initialize_runtime_metadata\"(v288, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv337 = Il2CppFieldInfo;\n\tv338 = \"il2cpp_codegen_initialize_runtime_metadata\"(v337, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv342 = UnityEngine.Vector2[];\n\tv343 = \"il2cpp_codegen_initialize_runtime_metadata\"(v342, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv362 = UnityEngine.Vector3[];\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v362, name, mesh, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37BE1]) = v52;\nL_0035:\n\tv60 = Spine.Atlas::FindRegion(this.atlas, name);\n\t*([material @ X3 (UnityEngine.Material&)]) = 0;\n\tv200 = v60 == 0;\n\tif (v200) goto L_FFFFFFFF;\n\tgoto L_0045;\n\tv290 = \"il2cpp_codegen_runtime_class_init\"(v206, v58, v59, material, methodInfo, v39, v40, v41, scale, v42, v43, v44, v45, v46, v47, v48);\nL_0045:\n\tv294 = UnityEngine.Object::op_Equality(mesh, 0);\n\tv340 = v294 == 0;\n\tif (v340) goto L_005E;\n\tv164 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v164);\n\tUnityEngine.Object::set_name(v164, name);\nL_005E:\n\t// 94 NewArr v360 @ X0_v14 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 4\n\t// 99 NewArr v366 @ X0_v16 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), 4\n\t// 104 NewArr v165 @ X0_v18 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), 4\n\t*([v165 @ X0_v18 (UnityEngine.Color[])+20]) = 0;\n\t*([v165 @ X0_v18 (UnityEngine.Color[])+30]) = 0;\n\t*([v165 @ X0_v18 (UnityEngine.Color[])+40]) = 0;\n\t*([v165 @ X0_v18 (UnityEngine.Color[])+50]) = 0;\n\t// 154 NewArr v166 @ X0_v22 (System.Int32[]), typeof(System.Int32[]), 6\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v166, Il2CppFieldInfo);\n\tv478 = v60.width * -0.5f;\n\tv479 = v60.height * 0.5f;\n\tv63 = -v479;\n\tv378 = scale * 0;\n\tv78 = v478 * scale;\n\tv381 = v63 * scale;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+20]) = v78;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+24]) = v381;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+28]) = v378;\n\tv481 = v60.height * 0.5f;\n\tv380 = v481 * scale;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+2C]) = v78;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+30]) = v380;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+34]) = v378;\n\tv484 = v60.width * -0.5f;\n\tv485 = -v484;\n\tv459 = v485 * scale;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+38]) = v459;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+3C]) = v380;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+40]) = v378;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+44]) = v459;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+48]) = v381;\n\t*([v360 @ X0_v14 (UnityEngine.Vector3[])+4C]) = v378;\n\tv82 = v60.v2;\n\tv487 = ~v60.rotate;\n\tif (v487) goto L_0127;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+20]) = v60.u2;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+24]) = v60.v2;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+28]) = v60.u;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+2C]) = v60.v2;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+30]) = v60.u;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+34]) = v60.v;\n\tv384 = v366.Length != 3;\n\tif (v384) goto L_0144;\n\tgoto L_01B8;\n\tgoto L_01B7;\nL_0127:\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+20]) = v60.u;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+24]) = v60.v2;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+28]) = v60.u;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+2C]) = v60.v;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+30]) = v60.u2;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+34]) = v60.v;\nL_0144:\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+38]) = v60.u2;\n\t*([v366 @ X0_v16 (UnityEngine.Vector2[])+3C]) = v82;\n\t// 328 NewArr v167 @ X0_v24 (System.Int32[]), typeof(System.Int32[]), 0\n\tUnityEngine.Mesh::set_triangles(v332, v167);\n\tUnityEngine.Mesh::set_vertices(v332, v360);\n\tUnityEngine.Mesh::set_uv(v332, v366);\n\tUnityEngine.Mesh::set_colors(v332, v165);\n\tUnityEngine.Mesh::set_triangles(v332, v166);\n\tUnityEngine.Mesh::RecalculateNormals(v332);\n\tUnityEngine.Mesh::RecalculateBounds(v332);\n\tv192 = v60.page;\n\tv329 = v192.rendererObject == 0;\n\tif (v329) goto L_01AA;\n\tgoto L_FFFFFFFF;\n\tv557 = v557_asT == 0;\n\tif (v557) goto L_01A9;\n\t*([material @ X3 (UnityEngine.Material&)]) = v192.rendererObject;\n\tgoto L_FFFFFFFF;\n\tv316 = v316_asT != 0;\n\tif (v316) goto L_01B7;\nL_01A9:\n\tthrow System.InvalidCastException;\nL_01AA:\n\t*([material @ X3 (UnityEngine.Material&)]) = 0;\nL_01B7:\n\treturn v332;\nL_01B8:\n\tv163 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 335 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Mesh GenerateMesh(string name, Mesh mesh, out Material material, float scale = 0.01f)
		{
			//IL_015a: Expected O, but got F4
			//IL_01f2: Expected O, but got F4
			material = null;
			AtlasRegion atlasRegion = atlas.FindRegion(name);
			ref Material reference = ref *(Material*)null;
			Mesh mesh2;
			if (atlasRegion != null)
			{
				bool flag = mesh == null;
				bool flag2 = !flag;
				mesh2 = mesh;
				if (!flag2)
				{
					Mesh mesh3 = new Mesh();
					mesh3.name = name;
					mesh2 = mesh3;
				}
				Vector3[] vertices = new Vector3[4];
				Vector2[] array = new Vector2[4];
				Color[] colors = new Color[4];
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				int[] triangles = new int[6] { 0, 1, 2, 2, 3, 0 };
				float num = (float)atlasRegion.width * -0.5f;
				float num2 = (float)atlasRegion.height * 0.5f;
				object obj = 0f - num2;
				float num3 = scale * 0f;
				float num4 = num * scale;
				float num5 = (float)obj * scale;
				float num6 = (float)atlasRegion.height * 0.5f;
				float num7 = num6 * scale;
				float num8 = (float)atlasRegion.width * -0.5f;
				object obj2 = 0f - num8;
				float num9 = (float)obj2 * scale;
				float v = atlasRegion.v2;
				if (atlasRegion.rotate)
				{
					_ = atlasRegion.u2;
					_ = atlasRegion.v2;
					_ = atlasRegion.u;
					_ = atlasRegion.v2;
					_ = atlasRegion.u;
					_ = atlasRegion.v;
					bool flag3 = array.Length != 3;
					v = atlasRegion.v;
					if (!flag3)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						return (Mesh)(object)new NullReferenceException();
					}
				}
				else
				{
					_ = atlasRegion.u;
					_ = atlasRegion.v2;
					_ = atlasRegion.u;
					_ = atlasRegion.v;
					_ = atlasRegion.u2;
					_ = atlasRegion.v;
				}
				_ = atlasRegion.u2;
				int[] triangles2 = new int[0];
				mesh2.triangles = triangles2;
				mesh2.vertices = vertices;
				mesh2.uv = array;
				mesh2.colors = colors;
				mesh2.triangles = triangles;
				mesh2.RecalculateNormals();
				mesh2.RecalculateBounds();
				AtlasPage page = atlasRegion.page;
				if (page.rendererObject != null)
				{
					Material material2 = page.rendererObject as Material;
					if ((object)material2 != null)
					{
						reference = ref *(Material*)page.rendererObject;
						Material material3 = page.rendererObject as Material;
						if ((object)material3 != null)
						{
							goto IL_047e;
						}
					}
					throw new InvalidCastException();
				}
				reference = ref *(Material*)null;
			}
			else
			{
				mesh2 = null;
			}
			goto IL_047e;
			IL_047e:
			return mesh2;
		}

		[Token(Token = "0x60004B5")]
		[Address(RVA = "0x155325C", Offset = "0x155325C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineAtlasAsset()
		{
		}
	}
}
