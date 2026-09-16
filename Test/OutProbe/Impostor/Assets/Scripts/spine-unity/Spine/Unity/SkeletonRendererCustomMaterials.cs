using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteAlways]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRendererCustomMaterials")]
	[Token(Token = "0x200008F")]
	public class SkeletonRendererCustomMaterials : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000090")]
		public struct SlotMaterialOverride : IEquatable<SlotMaterialOverride>
		{
			[Token(Token = "0x400039B")]
			[FieldOffset(Offset = "0x0")]
			public bool overrideDisabled;

			[SpineSlot(null, null, false, true, false)]
			[Token(Token = "0x400039C")]
			[FieldOffset(Offset = "0x8")]
			public string slotName;

			[Token(Token = "0x400039D")]
			[FieldOffset(Offset = "0x10")]
			public Material material;

			[Token(Token = "0x60005FD")]
			[Address(RVA = "0x1563FD8", Offset = "0x1563FD8", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37C86]) = v36;\nL_001E:\n\tv49 = this.overrideDisabled != other.overrideDisabled;\n\tif (v49) goto L_0041;\n\tv53 = System.String::op_Equality(this.slotName, other.slotName);\n\tv58 = v53 == 0;\n\tif (v58) goto L_0041;\n\tgoto L_0039;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v87, v51, v52, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0039:\n\treturnVal2 = UnityEngine.Object::op_Equality(this.material, other.material);\n\treturn returnVal2;\nL_0041:\n\treturn 0;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool Equals(SlotMaterialOverride other)
			{
				if (overrideDisabled == other.overrideDisabled && slotName == other.slotName)
				{
					return material == other.material;
				}
				return false;
			}
		}

		[Serializable]
		[Token(Token = "0x2000091")]
		public struct AtlasMaterialOverride : IEquatable<AtlasMaterialOverride>
		{
			[Token(Token = "0x400039E")]
			[FieldOffset(Offset = "0x0")]
			public bool overrideDisabled;

			[Token(Token = "0x400039F")]
			[FieldOffset(Offset = "0x8")]
			public Material originalMaterial;

			[Token(Token = "0x40003A0")]
			[FieldOffset(Offset = "0x10")]
			public Material replacementMaterial;

			[Token(Token = "0x60005FE")]
			[Address(RVA = "0x1564078", Offset = "0x1564078", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37C89]) = v40;\nL_0020:\n\tv53 = this.overrideDisabled != other.overrideDisabled;\n\tif (v53) goto L_004F;\n\tgoto L_002F;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v58, other, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv69 = UnityEngine.Object::op_Equality(this.originalMaterial, other.originalMaterial);\n\tv71 = v69 == 0;\n\tif (v71) goto L_004F;\n\tgoto L_0045;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v107, v65, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\treturnVal2 = UnityEngine.Object::op_Equality(this.replacementMaterial, other.replacementMaterial);\n\treturn returnVal2;\nL_004F:\n\treturn 0;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool Equals(AtlasMaterialOverride other)
			{
				if (overrideDisabled == other.overrideDisabled && originalMaterial == other.originalMaterial)
				{
					return replacementMaterial == other.replacementMaterial;
				}
				return false;
			}
		}

		[Token(Token = "0x4000398")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonRenderer skeletonRenderer;

		[SerializeField]
		[Token(Token = "0x4000399")]
		[FieldOffset(Offset = "0x28")]
		protected List<SlotMaterialOverride> customSlotMaterials;

		[SerializeField]
		[Token(Token = "0x400039A")]
		[FieldOffset(Offset = "0x30")]
		protected List<AtlasMaterialOverride> customMaterialOverrides;

		[Token(Token = "0x60005F6")]
		[Address(RVA = "0x1563684", Offset = "0x1563684", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv24 = UnityEngine.Debug;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv78 = UnityEngine.Object;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv182 = \"skeletonRenderer == null\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v182, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37C7D]) = v44;\nL_002A:\n\tgoto L_002F;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002F:\n\tv58 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv63 = v58 == 0;\n\tif (v63) goto L_0049;\n\tgoto L_0047;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v70, v56, v57, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0047:\n\tUnityEngine.Debug::LogError(\"skeletonRenderer == null\");\n\treturn;\nL_0049:\n\tv201 = this.customSlotMaterials;\nL_005B:\n\tv97 = v176 >= v201._size;\n\tif (v97) goto L_0096;\n\tv270 = System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+SlotMaterialOverride>::get_Item(v201, v176);\n\tv273 = v270.overrideDisabled == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_0088;\n\tv160 = System.String::IsNullOrEmpty(v270.slotName);\n\tv283 = v160 == 0;\n\tv280 = ~v283;\n\tif (v280) goto L_0088;\n\tv172 = this.skeletonRenderer;\n\tv162 = Spine.Skeleton::FindSlot(v172.skeleton, v270.slotName);\n\tv173 = this.skeletonRenderer;\n\tSystem.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::set_Item(v173.customSlotMaterials, v162, v270.material);\nL_0088:\n\tv201 = this.customSlotMaterials;\n\tv176 = v176 + 1;\n\tv281 = this.customSlotMaterials == 0;\n\tv165 = ~v281;\n\tif (v165) goto L_005B;\n\tthrow System.NullReferenceException;\nL_0096:\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetCustomSlotMaterials()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			List<SlotMaterialOverride> list = customSlotMaterials;
			int num = 0;
			while (num < list.Count)
			{
				SlotMaterialOverride slotMaterialOverride = list[num];
				if (!slotMaterialOverride.overrideDisabled && !string.IsNullOrEmpty(slotMaterialOverride.slotName))
				{
					SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
					Slot key = skeletonRenderer.skeleton.FindSlot(slotMaterialOverride.slotName);
					SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
					skeletonRenderer2.CustomSlotMaterials[key] = slotMaterialOverride.material;
				}
				list = customSlotMaterials;
				num++;
				if (customSlotMaterials == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x60005F7")]
		[Address(RVA = "0x1563820", Offset = "0x1563820", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv30 = UnityEngine.Debug;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv200 = UnityEngine.Object;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv266 = \"skeletonRenderer == null\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C7E]) = v50;\nL_0031:\n\tgoto L_0036;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0036:\n\tv65 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv70 = v65 == 0;\n\tif (v70) goto L_0053;\n\tgoto L_0046;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v76, v63, v64, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0046:\n\tUnityEngine.Debug::LogError(\"skeletonRenderer == null\");\nL_0052:\n\treturn;\nL_0053:\n\tv238 = this.customSlotMaterials;\nL_0067:\n\tv99 = v197 >= v238._size;\n\tif (v99) goto L_0052;\n\tv301 = System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+SlotMaterialOverride>::get_Item(v238, v197);\n\tv176 = System.String::IsNullOrEmpty(v301.slotName);\n\tv304 = v176 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_00AB;\n\tv192 = this.skeletonRenderer;\n\tv178 = Spine.Skeleton::FindSlot(v192.skeleton, v301.slotName);\n\tv193 = this.skeletonRenderer;\n\tv312 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::TryGetValue(v193.customSlotMaterials, v178, &v128 @ stack_-58_v5 (System.Object));\n\tv314 = v312 == 0;\n\tif (v314) goto L_00AB;\n\tgoto L_009D;\n\tv322 = \"il2cpp_codegen_runtime_class_init\"(v319, v309, v307, v132, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_009D:\n\tv180 = UnityEngine.Object::op_Inequality(v128, v301.material);\n\tv326 = v180 == 0;\n\tv315 = ~v326;\n\tif (v315) goto L_00AB;\n\tv194 = this.skeletonRenderer;\n\tv311 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::Remove(v194.customSlotMaterials, v178);\nL_00AB:\n\tv238 = this.customSlotMaterials;\n\tv197 = v197 + 1;\n\tv317 = this.customSlotMaterials == 0;\n\tv183 = ~v317;\n\tif (v183) goto L_0067;\n\tthrow System.NullReferenceException;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RemoveCustomSlotMaterials()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			List<SlotMaterialOverride> list = customSlotMaterials;
			int num = 0;
			do
			{
				if (num >= list.Count)
				{
					return;
				}
				SlotMaterialOverride slotMaterialOverride = list[num];
				if (!string.IsNullOrEmpty(slotMaterialOverride.slotName))
				{
					SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
					Slot key = skeletonRenderer.skeleton.FindSlot(slotMaterialOverride.slotName);
					SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
					object value;
					if (skeletonRenderer2.CustomSlotMaterials.TryGetValue(key, out *(Material*)(&value)) && !((UnityEngine.Object)value != slotMaterialOverride.material))
					{
						SkeletonRenderer skeletonRenderer3 = this.skeletonRenderer;
						bool flag = skeletonRenderer3.CustomSlotMaterials.Remove(key);
					}
				}
				list = customSlotMaterials;
				num++;
			}
			while (customSlotMaterials != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x60005F8")]
		[Address(RVA = "0x1563A0C", Offset = "0x1563A0C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv20 = UnityEngine.Debug;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv74 = UnityEngine.Object;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv162 = \"skeletonRenderer == null\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v162, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C7F]) = v40;\nL_0028:\n\tgoto L_002D;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002D:\n\tv54 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv59 = v54 == 0;\n\tif (v59) goto L_0045;\n\tgoto L_0043;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v66, v52, v53, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0043:\n\tUnityEngine.Debug::LogError(\"skeletonRenderer == null\");\n\treturn;\nL_0045:\n\tv180 = this.customMaterialOverrides;\nL_0057:\n\tv91 = v158 >= v180._size;\n\tif (v91) goto L_007E;\n\tv147 = System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+AtlasMaterialOverride>::get_Item(v180, v158);\n\tv243 = v147.overrideDisabled == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_0072;\n\tv155 = this.skeletonRenderer;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::set_Item(v155.customMaterialOverride, v147.originalMaterial, v147.replacementMaterial);\nL_0072:\n\tv180 = this.customMaterialOverrides;\n\tv158 = v158 + 1;\n\tv250 = this.customMaterialOverrides == 0;\n\tv150 = ~v250;\n\tif (v150) goto L_0057;\n\tthrow System.NullReferenceException;\nL_007E:\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetCustomMaterialOverrides()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			List<AtlasMaterialOverride> list = customMaterialOverrides;
			int num = 0;
			while (num < list.Count)
			{
				AtlasMaterialOverride atlasMaterialOverride = list[num];
				if (!atlasMaterialOverride.overrideDisabled)
				{
					SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
					skeletonRenderer.CustomMaterialOverride[atlasMaterialOverride.originalMaterial] = atlasMaterialOverride.replacementMaterial;
				}
				list = customMaterialOverrides;
				num++;
				if (customMaterialOverrides == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x60005F9")]
		[Address(RVA = "0x1563B68", Offset = "0x1563B68", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv30 = UnityEngine.Debug;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv191 = UnityEngine.Object;\n\tv192 = \"il2cpp_codegen_initialize_runtime_metadata\"(v191, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv256 = \"skeletonRenderer == null\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C80]) = v50;\nL_0031:\n\tgoto L_0036;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0036:\n\tv65 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv70 = v65 == 0;\n\tif (v70) goto L_0053;\n\tgoto L_0046;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v77, v63, v64, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0046:\n\tUnityEngine.Debug::LogError(\"skeletonRenderer == null\");\nL_0052:\n\treturn;\nL_0053:\n\tv227 = this.customMaterialOverrides;\nL_0067:\n\tv99 = v188 >= v227._size;\n\tif (v99) goto L_0052;\n\tv172 = System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+AtlasMaterialOverride>::get_Item(v227, v188);\n\tv184 = this.skeletonRenderer;\n\tv292 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::TryGetValue(v184.customMaterialOverride, v172.originalMaterial, &v126 @ stack_-58_v4 (System.Object));\n\tv294 = v292 == 0;\n\tif (v294) goto L_009A;\n\tgoto L_008C;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v295, v291, v290, v129, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_008C:\n\tv174 = UnityEngine.Object::op_Inequality(v126, v172.replacementMaterial);\n\tv310 = v174 == 0;\n\tv304 = ~v310;\n\tif (v304) goto L_009A;\n\tv185 = this.skeletonRenderer;\n\tv302 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::Remove(v185.customMaterialOverride, v172.originalMaterial);\nL_009A:\n\tv227 = this.customMaterialOverrides;\n\tv188 = v188 + 1;\n\tv305 = this.customMaterialOverrides == 0;\n\tv177 = ~v305;\n\tif (v177) goto L_0067;\n\tthrow System.NullReferenceException;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RemoveCustomMaterialOverrides()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
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
				SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
				object value;
				if (skeletonRenderer.CustomMaterialOverride.TryGetValue(atlasMaterialOverride.originalMaterial, out *(Material*)(&value)) && !((UnityEngine.Object)value != atlasMaterialOverride.replacementMaterial))
				{
					SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
					bool flag = skeletonRenderer2.CustomMaterialOverride.Remove(atlasMaterialOverride.originalMaterial);
				}
				list = customMaterialOverrides;
				num++;
			}
			while (customMaterialOverrides != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x60005FA")]
		[Address(RVA = "0x1563D24", Offset = "0x1563D24", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Debug;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = UnityEngine.Object;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = \"skeletonRenderer == null\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C81]) = v38;\nL_0021:\n\tgoto L_0026;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_0032;\n\tv64 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonRenderer = v64;\n\tgoto L_0037;\nL_0032:\n\tv70 = this.skeletonRenderer;\nL_0037:\n\tgoto L_003C;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v71, v67, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003C:\n\tv80 = UnityEngine.Object::op_Equality(v70, 0);\n\tv82 = v80 == 0;\n\tif (v82) goto L_005A;\n\tgoto L_0051;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v85, v78, v79, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0051:\n\tUnityEngine.Debug::LogError(\"skeletonRenderer == null\");\n\treturn;\nL_005A:\n\tv105 = Spine.Unity.SkeletonRenderer::Initialize(this.skeletonRenderer, 0);\n\tSpine.Unity.SkeletonRendererCustomMaterials::SetCustomMaterialOverrides(this);\n\tSpine.Unity.SkeletonRendererCustomMaterials::SetCustomSlotMaterials(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			SkeletonRenderer skeletonRenderer = ((!(this.skeletonRenderer == null)) ? this.skeletonRenderer : (this.skeletonRenderer = GetComponent<SkeletonRenderer>()));
			if (skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			this.skeletonRenderer.Initialize(overwrite: false);
			SetCustomMaterialOverrides();
			SetCustomSlotMaterials();
		}

		[Token(Token = "0x60005FB")]
		[Address(RVA = "0x1563E54", Offset = "0x1563E54", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = \"skeletonRenderer == null\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C82]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_003B;\n\tgoto L_0038;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v60, v50, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0038:\n\tUnityEngine.Debug::LogError(\"skeletonRenderer == null\");\n\treturn;\nL_003B:\n\tSpine.Unity.SkeletonRendererCustomMaterials::RemoveCustomMaterialOverrides(this);\n\tSpine.Unity.SkeletonRendererCustomMaterials::RemoveCustomSlotMaterials(this);\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			RemoveCustomMaterialOverrides();
			RemoveCustomSlotMaterials();
		}

		[Token(Token = "0x60005FC")]
		[Address(RVA = "0x1563F14", Offset = "0x1563F14", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+AtlasMaterialOverride>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+SlotMaterialOverride>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C83]) = v50;\nL_0026:\n\tv52 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+SlotMaterialOverride>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+SlotMaterialOverride>::.ctor(v52);\n\tthis.customSlotMaterials = v52;\n\tv62 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+AtlasMaterialOverride>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonRendererCustomMaterials+AtlasMaterialOverride>::.ctor(v62);\n\tthis.customMaterialOverrides = v62;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonRendererCustomMaterials()
		{
			List<SlotMaterialOverride> list = new List<SlotMaterialOverride>();
			customSlotMaterials = list;
			List<AtlasMaterialOverride> list2 = new List<AtlasMaterialOverride>();
			customMaterialOverrides = list2;
		}
	}
}
