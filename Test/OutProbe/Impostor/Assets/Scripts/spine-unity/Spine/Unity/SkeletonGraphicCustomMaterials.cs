using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteAlways]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonGraphicCustomMaterials")]
	[Token(Token = "0x200008C")]
	public class SkeletonGraphicCustomMaterials : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x200008D")]
		public struct AtlasMaterialOverride : IEquatable<AtlasMaterialOverride>
		{
			[Token(Token = "0x4000392")]
			[FieldOffset(Offset = "0x0")]
			public bool overrideEnabled;

			[Token(Token = "0x4000393")]
			[FieldOffset(Offset = "0x8")]
			public Texture originalTexture;

			[Token(Token = "0x4000394")]
			[FieldOffset(Offset = "0x10")]
			public Material replacementMaterial;

			[Token(Token = "0x60005F4")]
			[Address(RVA = "0x15634FC", Offset = "0x15634FC", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37C79]) = v40;\nL_0020:\n\tv53 = this.overrideEnabled != other.overrideEnabled;\n\tif (v53) goto L_004F;\n\tgoto L_002F;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v58, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv69 = UnityEngine.Object::op_Equality(this.originalTexture, other.originalTexture);\n\tv71 = v69 == 0;\n\tif (v71) goto L_004F;\n\tgoto L_0045;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v107, v65, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\treturnVal2 = UnityEngine.Object::op_Equality(this.replacementMaterial, other.replacementMaterial);\n\treturn returnVal2;\nL_004F:\n\treturn 0;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool Equals(AtlasMaterialOverride other)
			{
				if (overrideEnabled == other.overrideEnabled && originalTexture == other.originalTexture)
				{
					return replacementMaterial == other.replacementMaterial;
				}
				return false;
			}
		}

		[Serializable]
		[Token(Token = "0x200008E")]
		public struct AtlasTextureOverride : IEquatable<AtlasTextureOverride>
		{
			[Token(Token = "0x4000395")]
			[FieldOffset(Offset = "0x0")]
			public bool overrideEnabled;

			[Token(Token = "0x4000396")]
			[FieldOffset(Offset = "0x8")]
			public Texture originalTexture;

			[Token(Token = "0x4000397")]
			[FieldOffset(Offset = "0x10")]
			public Texture replacementTexture;

			[Token(Token = "0x60005F5")]
			[Address(RVA = "0x15635C0", Offset = "0x15635C0", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37C7C]) = v40;\nL_0020:\n\tv53 = this.overrideEnabled != other.overrideEnabled;\n\tif (v53) goto L_004F;\n\tgoto L_002F;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v58, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv69 = UnityEngine.Object::op_Equality(this.originalTexture, other.originalTexture);\n\tv71 = v69 == 0;\n\tif (v71) goto L_004F;\n\tgoto L_0045;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v107, v65, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\treturnVal2 = UnityEngine.Object::op_Equality(this.replacementTexture, other.replacementTexture);\n\treturn returnVal2;\nL_004F:\n\treturn 0;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool Equals(AtlasTextureOverride other)
			{
				if (overrideEnabled == other.overrideEnabled && originalTexture == other.originalTexture)
				{
					return replacementTexture == other.replacementTexture;
				}
				return false;
			}
		}

		[Token(Token = "0x400038F")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonGraphic skeletonGraphic;

		[SerializeField]
		[Token(Token = "0x4000390")]
		[FieldOffset(Offset = "0x28")]
		protected List<AtlasMaterialOverride> customMaterialOverrides;

		[SerializeField]
		[Token(Token = "0x4000391")]
		[FieldOffset(Offset = "0x30")]
		protected List<AtlasTextureOverride> customTextureOverrides;

		[Token(Token = "0x60005ED")]
		[Address(RVA = "0x1562C20", Offset = "0x1562C20", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv20 = UnityEngine.Debug;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv74 = UnityEngine.Object;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv162 = \"skeletonGraphic == null\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v162, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C70]) = v40;\nL_0028:\n\tgoto L_002D;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002D:\n\tv54 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv59 = v54 == 0;\n\tif (v59) goto L_0045;\n\tgoto L_0043;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v66, v52, v53, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0043:\n\tUnityEngine.Debug::LogError(\"skeletonGraphic == null\");\n\treturn;\nL_0045:\n\tv180 = this.customMaterialOverrides;\nL_0057:\n\tv91 = v158 >= v180._size;\n\tif (v91) goto L_007D;\n\tv147 = System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasMaterialOverride>::get_Item(v180, v158);\n\tv243 = v147.overrideEnabled == 0;\n\tif (v243) goto L_0071;\n\tv155 = this.skeletonGraphic;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>::set_Item(v155.customMaterialOverride, v147.originalTexture, v147.replacementMaterial);\nL_0071:\n\tv180 = this.customMaterialOverrides;\n\tv158 = v158 + 1;\n\tv249 = this.customMaterialOverrides == 0;\n\tv150 = ~v249;\n\tif (v150) goto L_0057;\n\tthrow System.NullReferenceException;\nL_007D:\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetCustomMaterialOverrides()
		{
			if (this.skeletonGraphic == null)
			{
				Debug.LogError("skeletonGraphic == null");
				return;
			}
			List<AtlasMaterialOverride> list = customMaterialOverrides;
			int num = 0;
			while (num < list.Count)
			{
				AtlasMaterialOverride atlasMaterialOverride = list[num];
				if (atlasMaterialOverride.overrideEnabled)
				{
					SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
					skeletonGraphic.CustomMaterialOverride[atlasMaterialOverride.originalTexture] = atlasMaterialOverride.replacementMaterial;
				}
				list = customMaterialOverrides;
				num++;
				if (customMaterialOverrides == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x60005EE")]
		[Address(RVA = "0x1562D7C", Offset = "0x1562D7C", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv30 = UnityEngine.Debug;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv191 = UnityEngine.Object;\n\tv192 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv256 = \"skeletonGraphic == null\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C71]) = v50;\nL_0031:\n\tgoto L_0036;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0036:\n\tv65 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv70 = v65 == 0;\n\tif (v70) goto L_0053;\n\tgoto L_0046;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v77, v63, v64, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0046:\n\tUnityEngine.Debug::LogError(\"skeletonGraphic == null\");\nL_0052:\n\treturn;\nL_0053:\n\tv227 = this.customMaterialOverrides;\nL_0067:\n\tv99 = v188 >= v227._size;\n\tif (v99) goto L_0052;\n\tv172 = System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasMaterialOverride>::get_Item(v227, v188);\n\tv184 = this.skeletonGraphic;\n\tv292 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>::TryGetValue(v184.customMaterialOverride, v172.originalTexture, &v126 @ stack_-58_v4 (System.Object));\n\tv294 = v292 == 0;\n\tif (v294) goto L_009A;\n\tgoto L_008C;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v295, v291, v290, v129, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_008C:\n\tv174 = UnityEngine.Object::op_Inequality(v126, v172.replacementMaterial);\n\tv310 = v174 == 0;\n\tv304 = ~v310;\n\tif (v304) goto L_009A;\n\tv185 = this.skeletonGraphic;\n\tv302 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>::Remove(v185.customMaterialOverride, v172.originalTexture);\nL_009A:\n\tv227 = this.customMaterialOverrides;\n\tv188 = v188 + 1;\n\tv305 = this.customMaterialOverrides == 0;\n\tv177 = ~v305;\n\tif (v177) goto L_0067;\n\tthrow System.NullReferenceException;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RemoveCustomMaterialOverrides()
		{
			if (this.skeletonGraphic == null)
			{
				Debug.LogError("skeletonGraphic == null");
				return;
			}
			List<AtlasMaterialOverride> list = customMaterialOverrides;
			int num = 0;
			do
			{
				if (num >= list.Count)
				{
					return;
				}
				AtlasMaterialOverride atlasMaterialOverride = list[num];
				SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
				object value;
				if (skeletonGraphic.CustomMaterialOverride.TryGetValue(atlasMaterialOverride.originalTexture, out *(Material*)(&value)) && !((UnityEngine.Object)value != atlasMaterialOverride.replacementMaterial))
				{
					SkeletonGraphic skeletonGraphic2 = this.skeletonGraphic;
					bool flag = skeletonGraphic2.CustomMaterialOverride.Remove(atlasMaterialOverride.originalTexture);
				}
				list = customMaterialOverrides;
				num++;
			}
			while (customMaterialOverrides != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x60005EF")]
		[Address(RVA = "0x1562F38", Offset = "0x1562F38", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv20 = UnityEngine.Debug;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv74 = UnityEngine.Object;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv162 = \"skeletonGraphic == null\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v162, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C72]) = v40;\nL_0028:\n\tgoto L_002D;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002D:\n\tv54 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv59 = v54 == 0;\n\tif (v59) goto L_0045;\n\tgoto L_0043;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v66, v52, v53, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0043:\n\tUnityEngine.Debug::LogError(\"skeletonGraphic == null\");\n\treturn;\nL_0045:\n\tv180 = this.customTextureOverrides;\nL_0057:\n\tv91 = v158 >= v180._size;\n\tif (v91) goto L_007D;\n\tv147 = System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasTextureOverride>::get_Item(v180, v158);\n\tv243 = v147.overrideEnabled == 0;\n\tif (v243) goto L_0071;\n\tv155 = this.skeletonGraphic;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Texture>::set_Item(v155.customTextureOverride, v147.originalTexture, v147.replacementTexture);\nL_0071:\n\tv180 = this.customTextureOverrides;\n\tv158 = v158 + 1;\n\tv249 = this.customTextureOverrides == 0;\n\tv150 = ~v249;\n\tif (v150) goto L_0057;\n\tthrow System.NullReferenceException;\nL_007D:\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetCustomTextureOverrides()
		{
			if (this.skeletonGraphic == null)
			{
				Debug.LogError("skeletonGraphic == null");
				return;
			}
			List<AtlasTextureOverride> list = customTextureOverrides;
			int num = 0;
			while (num < list.Count)
			{
				AtlasTextureOverride atlasTextureOverride = list[num];
				if (atlasTextureOverride.overrideEnabled)
				{
					SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
					skeletonGraphic.CustomTextureOverride[atlasTextureOverride.originalTexture] = atlasTextureOverride.replacementTexture;
				}
				list = customTextureOverrides;
				num++;
				if (customTextureOverrides == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x60005F0")]
		[Address(RVA = "0x1563094", Offset = "0x1563094", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv30 = UnityEngine.Debug;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv191 = UnityEngine.Object;\n\tv192 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv256 = \"skeletonGraphic == null\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C73]) = v50;\nL_0031:\n\tgoto L_0036;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0036:\n\tv65 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv70 = v65 == 0;\n\tif (v70) goto L_0053;\n\tgoto L_0046;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v77, v63, v64, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0046:\n\tUnityEngine.Debug::LogError(\"skeletonGraphic == null\");\nL_0052:\n\treturn;\nL_0053:\n\tv227 = this.customTextureOverrides;\nL_0067:\n\tv99 = v188 >= v227._size;\n\tif (v99) goto L_0052;\n\tv172 = System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasTextureOverride>::get_Item(v227, v188);\n\tv184 = this.skeletonGraphic;\n\tv292 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Texture>::TryGetValue(v184.customTextureOverride, v172.originalTexture, &v126 @ stack_-58_v4 (System.Object));\n\tv294 = v292 == 0;\n\tif (v294) goto L_009A;\n\tgoto L_008C;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v295, v291, v290, v129, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_008C:\n\tv174 = UnityEngine.Object::op_Inequality(v126, v172.replacementTexture);\n\tv310 = v174 == 0;\n\tv304 = ~v310;\n\tif (v304) goto L_009A;\n\tv185 = this.skeletonGraphic;\n\tv302 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Texture>::Remove(v185.customTextureOverride, v172.originalTexture);\nL_009A:\n\tv227 = this.customTextureOverrides;\n\tv188 = v188 + 1;\n\tv305 = this.customTextureOverrides == 0;\n\tv177 = ~v305;\n\tif (v177) goto L_0067;\n\tthrow System.NullReferenceException;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RemoveCustomTextureOverrides()
		{
			if (this.skeletonGraphic == null)
			{
				Debug.LogError("skeletonGraphic == null");
				return;
			}
			List<AtlasTextureOverride> list = customTextureOverrides;
			int num = 0;
			do
			{
				if (num >= list.Count)
				{
					return;
				}
				AtlasTextureOverride atlasTextureOverride = list[num];
				SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
				object value;
				if (skeletonGraphic.CustomTextureOverride.TryGetValue(atlasTextureOverride.originalTexture, out *(Texture*)(&value)) && !((UnityEngine.Object)value != atlasTextureOverride.replacementTexture))
				{
					SkeletonGraphic skeletonGraphic2 = this.skeletonGraphic;
					bool flag = skeletonGraphic2.CustomTextureOverride.Remove(atlasTextureOverride.originalTexture);
				}
				list = customTextureOverrides;
				num++;
			}
			while (customTextureOverrides != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x60005F1")]
		[Address(RVA = "0x1563250", Offset = "0x1563250", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Debug;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = UnityEngine.Object;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = \"skeletonGraphic == null\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C74]) = v38;\nL_0021:\n\tgoto L_0026;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_0032;\n\tv64 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonGraphic = v64;\n\tgoto L_0037;\nL_0032:\n\tv70 = this.skeletonGraphic;\nL_0037:\n\tgoto L_003C;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v71, v67, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003C:\n\tv80 = UnityEngine.Object::op_Equality(v70, 0);\n\tv82 = v80 == 0;\n\tif (v82) goto L_0057;\n\tgoto L_0051;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v85, v78, v79, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0051:\n\tUnityEngine.Debug::LogError(\"skeletonGraphic == null\");\n\treturn;\nL_0057:\n\tSpine.Unity.SkeletonGraphic::Initialize(this.skeletonGraphic, 0);\n\tSpine.Unity.SkeletonGraphicCustomMaterials::SetCustomMaterialOverrides(this);\n\tSpine.Unity.SkeletonGraphicCustomMaterials::SetCustomTextureOverrides(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			SkeletonGraphic skeletonGraphic = ((!(this.skeletonGraphic == null)) ? this.skeletonGraphic : (this.skeletonGraphic = GetComponent<SkeletonGraphic>()));
			if (skeletonGraphic == null)
			{
				Debug.LogError("skeletonGraphic == null");
				return;
			}
			this.skeletonGraphic.Initialize(overwrite: false);
			SetCustomMaterialOverrides();
			SetCustomTextureOverrides();
		}

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0x1563378", Offset = "0x1563378", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = \"skeletonGraphic == null\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C75]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_003B;\n\tgoto L_0038;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v60, v50, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0038:\n\tUnityEngine.Debug::LogError(\"skeletonGraphic == null\");\n\treturn;\nL_003B:\n\tSpine.Unity.SkeletonGraphicCustomMaterials::RemoveCustomMaterialOverrides(this);\n\tSpine.Unity.SkeletonGraphicCustomMaterials::RemoveCustomTextureOverrides(this);\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (skeletonGraphic == null)
			{
				Debug.LogError("skeletonGraphic == null");
				return;
			}
			RemoveCustomMaterialOverrides();
			RemoveCustomTextureOverrides();
		}

		[Token(Token = "0x60005F3")]
		[Address(RVA = "0x1563438", Offset = "0x1563438", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasTextureOverride>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasMaterialOverride>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C76]) = v50;\nL_0026:\n\tv52 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasMaterialOverride>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasMaterialOverride>::.ctor(v52);\n\tthis.customMaterialOverrides = v52;\n\tv62 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasTextureOverride>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonGraphicCustomMaterials+AtlasTextureOverride>::.ctor(v62);\n\tthis.customTextureOverrides = v62;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonGraphicCustomMaterials()
		{
			List<AtlasMaterialOverride> list = new List<AtlasMaterialOverride>();
			customMaterialOverrides = list;
			List<AtlasTextureOverride> list2 = new List<AtlasTextureOverride>();
			customTextureOverrides = list2;
		}
	}
}
