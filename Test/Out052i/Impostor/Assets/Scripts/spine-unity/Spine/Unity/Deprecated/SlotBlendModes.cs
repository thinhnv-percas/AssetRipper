using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Deprecated
{
	[DisallowMultipleComponent]
	[Obsolete("The spine-unity 3.7 runtime introduced SkeletonDataModifierAssets BlendModeMaterials which replaced SlotBlendModes. Will be removed in spine-unity 3.9.", false)]
	[Token(Token = "0x20000CC")]
	public class SlotBlendModes : MonoBehaviour
	{
		[Token(Token = "0x20000CD")]
		public struct MaterialTexturePair
		{
			[Token(Token = "0x4000459")]
			[FieldOffset(Offset = "0x0")]
			public Texture2D texture2D;

			[Token(Token = "0x400045A")]
			[FieldOffset(Offset = "0x8")]
			public Material material;
		}

		[Token(Token = "0x20000CE")]
		internal class MaterialWithRefcount
		{
			[Token(Token = "0x400045B")]
			[FieldOffset(Offset = "0x10")]
			public Material materialClone;

			[Token(Token = "0x400045C")]
			[FieldOffset(Offset = "0x18")]
			public int refcount;

			[Token(Token = "0x6000750")]
			[Address(RVA = "0x15795F0", Offset = "0x15795F0", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.refcount = 1;\n\tSystem.Object::.ctor(this);\n\tthis.materialClone = mat;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public MaterialWithRefcount(Material mat)
			{
				refcount = 1;
				materialClone = mat;
			}
		}

		[Token(Token = "0x20000CF")]
		internal struct SlotMaterialTextureTuple
		{
			[Token(Token = "0x400045D")]
			[FieldOffset(Offset = "0x0")]
			public Slot slot;

			[Token(Token = "0x400045E")]
			[FieldOffset(Offset = "0x8")]
			public Texture2D texture2D;

			[Token(Token = "0x400045F")]
			[FieldOffset(Offset = "0x10")]
			public Material material;

			[Token(Token = "0x6000751")]
			[Address(RVA = "0x157A048", Offset = "0x157A048", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.texture2D = texture;\n\tthis.material = material;\n\tthis.slot = slot;\n\treturn;\n")]
			public SlotMaterialTextureTuple(Slot slot, Material material, Texture2D texture)
			{
				texture2D = texture;
				this.material = material;
				this.slot = slot;
			}
		}

		[Token(Token = "0x4000453")]
		private static Dictionary<MaterialTexturePair, MaterialWithRefcount> materialTable;

		[Token(Token = "0x4000454")]
		[FieldOffset(Offset = "0x20")]
		public Material multiplyMaterialSource;

		[Token(Token = "0x4000455")]
		[FieldOffset(Offset = "0x28")]
		public Material screenMaterialSource;

		[Token(Token = "0x4000456")]
		[FieldOffset(Offset = "0x30")]
		private Texture2D texture;

		[Token(Token = "0x4000457")]
		[FieldOffset(Offset = "0x38")]
		private SlotMaterialTextureTuple[] slotsWithCustomMaterial;

		[CompilerGenerated]
		[Token(Token = "0x4000458")]
		[FieldOffset(Offset = "0x40")]
		private bool _003CApplied_003Ek__BackingField;

		[Token(Token = "0x170001C1")]
		internal static Dictionary<MaterialTexturePair, MaterialWithRefcount> MaterialTable
		{
			[Token(Token = "0x6000744")]
			[Address(RVA = "0x1579324", Offset = "0x1579324", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv42 = System.Collections.Generic.Dictionary`2<Spine.Unity.Deprecated.SlotBlendModes+MaterialTexturePair, Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv60 = Spine.Unity.Deprecated.SlotBlendModes;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A37D28]) = v35;\nL_0019:\n\treturnVal1 = v37.materialTable;\n\tv39 = v37.materialTable == 0;\n\tv40 = ~v39;\n\tif (v40) goto L_0030;\n\tv47 = new System.Collections.Generic.Dictionary`2<Spine.Unity.Deprecated.SlotBlendModes+MaterialTexturePair, Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.Unity.Deprecated.SlotBlendModes+MaterialTexturePair, Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount>::.ctor(v47);\n\tv64.materialTable = v47;\n\treturnVal1 = v53.materialTable;\nL_0030:\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Dictionary<MaterialTexturePair, MaterialWithRefcount> result = materialTable;
				if (materialTable == null)
				{
					Dictionary<MaterialTexturePair, MaterialWithRefcount> dictionary = new Dictionary<MaterialTexturePair, MaterialWithRefcount>();
					materialTable = dictionary;
					result = materialTable;
				}
				return result;
			}
		}

		[Token(Token = "0x170001C2")]
		public bool Applied
		{
			[CompilerGenerated]
			[Token(Token = "0x6000748")]
			[Address(RVA = "0x1579764", Offset = "0x1579764", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Applied>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Applied;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000749")]
			[Address(RVA = "0x157976C", Offset = "0x157976C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Applied>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CApplied_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000745")]
		[Address(RVA = "0x15793C4", Offset = "0x15793C4", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv59 = Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv67 = UnityEngine.Material;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv110 = UnityEngine.Object;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv144 = \"-\";\n\tv145 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv149 = \"(Clone)\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v149, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37D29]) = v43;\nL_002D:\n\tgoto L_0032;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, texture, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0032:\n\tv57 = UnityEngine.Object::op_Equality(materialSource, 0);\n\tv64 = v57 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_00A4;\n\tgoto L_0042;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v69, v55, v56, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv115 = UnityEngine.Object::op_Equality(texture, 0);\n\tv147 = v115 == 0;\n\tv95 = ~v147;\n\tif (v95) goto L_00A4;\n\tv150 = Spine.Unity.Deprecated.SlotBlendModes::get_MaterialTable();\n\tv159 = System.Collections.Generic.Dictionary`2<Spine.Unity.Deprecated.SlotBlendModes+MaterialTexturePair, Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount>::TryGetValue(v150, texture, materialSource);\n\tv191 = v159 == 0;\n\tif (v191) goto L_0061;\n\tv197 = v155.refcount + 1;\n\tv155.refcount = v197;\n\tgoto L_009C;\nL_0061:\n\tv195 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v195, materialSource);\n\tv176 = new Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount();\n\tv176.refcount = 1;\n\tSystem.Object::.ctor(v176);\n\tv176.materialClone = v195;\n\tv177 = UnityEngine.Object::get_name(texture);\n\tv206 = UnityEngine.Object::get_name(materialSource);\n\tv178 = System.String::Concat(\"(Clone)\", v177, \"-\", v206);\n\tUnityEngine.Object::set_name(v195, v178);\n\tUnityEngine.Material::set_mainTexture(v195, texture);\n\tSystem.Collections.Generic.Dictionary`2<Spine.Unity.Deprecated.SlotBlendModes+MaterialTexturePair, Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount>::set_Item(v150, texture, materialSource);\nL_009C:\n\treturnVal1 = v97.materialClone;\nL_00A4:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static Material GetOrAddMaterialFor(Material materialSource, Texture2D texture)
		{
			bool flag = materialSource == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Material result = null;
			if (!flag3)
			{
				bool flag4 = texture == null;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = null;
				if (!flag6)
				{
					Dictionary<MaterialTexturePair, MaterialWithRefcount> dictionary = MaterialTable;
					MaterialWithRefcount materialWithRefcount2;
					if (dictionary.TryGetValue((MaterialTexturePair)texture, out *(MaterialWithRefcount*)materialSource))
					{
						MaterialWithRefcount materialWithRefcount = default(MaterialWithRefcount);
						int refcount = materialWithRefcount.refcount + 1;
						materialWithRefcount.refcount = refcount;
						materialWithRefcount2 = materialWithRefcount;
					}
					else
					{
						Material material = new Material(materialSource);
						MaterialWithRefcount materialWithRefcount3 = null;
						materialWithRefcount3.refcount = 1;
						materialWithRefcount3.materialClone = material;
						string text = texture.name;
						string text2 = materialSource.name;
						string text3 = "(Clone)" + text + "-" + text2;
						material.name = text3;
						material.mainTexture = texture;
						dictionary[(MaterialTexturePair)texture] = (MaterialWithRefcount)(object)materialSource;
						materialWithRefcount2 = materialWithRefcount3;
					}
					result = materialWithRefcount2.materialClone;
				}
			}
			return result;
		}

		[Token(Token = "0x6000746")]
		[Address(RVA = "0x1579620", Offset = "0x1579620", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, texture, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv48 = UnityEngine.Object;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, texture, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37D2A]) = v41;\nL_001D:\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, texture, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0022:\n\tv54 = UnityEngine.Object::op_Equality(materialSource, 0);\n\tv58 = v54 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0056;\n\tgoto L_0032;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v60, v52, v53, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0032:\n\tv112 = UnityEngine.Object::op_Equality(texture, 0);\n\tv135 = v112 == 0;\n\tv99 = ~v135;\n\tif (v99) goto L_0056;\n\tv136 = Spine.Unity.Deprecated.SlotBlendModes::get_MaterialTable();\n\tv139 = System.Collections.Generic.Dictionary`2<Spine.Unity.Deprecated.SlotBlendModes+MaterialTexturePair, Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount>::TryGetValue(v136, texture, materialSource);\n\tv78 = v139 == 0;\n\tv69 = ~v78;\n\tv66 = ~v69;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_0056;\nL_0056:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static MaterialWithRefcount GetExistingMaterialFor(Material materialSource, Texture2D texture)
		{
			bool flag = materialSource == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			MaterialWithRefcount result = null;
			if (!flag3)
			{
				bool flag4 = texture == null;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = null;
				if (!flag6)
				{
					Dictionary<MaterialTexturePair, MaterialWithRefcount> dictionary = MaterialTable;
					MaterialWithRefcount materialWithRefcount = default(MaterialWithRefcount);
					result = ((!dictionary.TryGetValue((MaterialTexturePair)texture, out *(MaterialWithRefcount*)materialSource)) ? null : materialWithRefcount);
				}
			}
			return result;
		}

		[Token(Token = "0x6000747")]
		[Address(RVA = "0x1579708", Offset = "0x1579708", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, texture, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37D2B]) = v36;\nL_0012:\n\tv37 = Spine.Unity.Deprecated.SlotBlendModes::get_MaterialTable();\n\tv48 = System.Collections.Generic.Dictionary`2<Spine.Unity.Deprecated.SlotBlendModes+MaterialTexturePair, Spine.Unity.Deprecated.SlotBlendModes+MaterialWithRefcount>::Remove(v37, texture);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void RemoveMaterialFromTable(Material materialSource, Texture2D texture)
		{
			Dictionary<MaterialTexturePair, MaterialWithRefcount> dictionary = MaterialTable;
			bool flag = dictionary.Remove((MaterialTexturePair)texture);
		}

		[Token(Token = "0x600074A")]
		[Address(RVA = "0x1579778", Offset = "0x1579778", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.<Applied>k__BackingField;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tSpine.Unity.Deprecated.SlotBlendModes::Apply(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (!Applied)
			{
				Apply();
			}
		}

		[Token(Token = "0x600074B")]
		[Address(RVA = "0x1579CA0", Offset = "0x1579CA0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.<Applied>k__BackingField;\n\tif (v2) goto L_0005;\n\tSpine.Unity.Deprecated.SlotBlendModes::Remove(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (Applied)
			{
				Remove();
			}
		}

		[Token(Token = "0x600074C")]
		[Address(RVA = "0x1579788", Offset = "0x1579788", Length = "0x518")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv176 = Il2CppMethodInfo;\n\tv177 = \"il2cpp_codegen_initialize_runtime_metadata\"(v176, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv241 = UnityEngine.Object;\n\tv242 = \"il2cpp_codegen_initialize_runtime_metadata\"(v241, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv248 = SlotMaterialTextureTuple[];\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v248, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37D2C]) = v52;\nL_0033:\n\tSpine.Unity.Deprecated.SlotBlendModes::GetTexture(this);\n\tgoto L_003E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_003E:\n\tv73 = UnityEngine.Object::op_Equality(this.texture, 0);\n\tv78 = v73 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0162;\n\tv87 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0053;\n\tv243 = v161;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v243, v86, v72, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0053:\n\tv155 = UnityEngine.Object::op_Equality(v87, 0);\n\tv250 = v155 == 0;\n\tv158 = ~v250;\n\tif (v158) goto L_0162;\n\tv255 = Spine.Unity.SkeletonRenderer::get_Skeleton(v87);\n\tv443 = Spine.ExposedList`1<Spine.Slot>::GetEnumerator(v255.slots);\nL_0073:\n\tv569 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v380 @ stack_-98_v13 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv621 = v569 == 0;\n\tif (v621) goto L_00CA;\n\tv652 = v491.data;\n\tv411 = v652.blendMode == 2;\n\tif (v411) goto L_00B1;\n\tv348 = v652.blendMode != 3;\n\tif (v348) goto L_0073;\n\tgoto L_009D;\n\tv734 = \"il2cpp_codegen_runtime_class_init\"(v723, v564, v561, v344, v37, v38, v39, v40, v378, v42, v43, v44, v45, v46, v47, v48);\nL_009D:\n\tv570 = UnityEngine.Object::op_Inequality(this.screenMaterialSource, 0);\n\tv575 = v570 == 0;\n\tif (v575) goto L_0073;\n\tv390 = Spine.Unity.Deprecated.SlotBlendModes::GetOrAddMaterialFor(this.screenMaterialSource, this.texture);\n\tSystem.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::set_Item(v87.customSlotMaterials, v491, v390);\n\tgoto L_00C4;\nL_00B1:\n\tgoto L_00B6;\n\tv726 = \"il2cpp_codegen_runtime_class_init\"(v683, v564, v561, v344, v37, v38, v39, v40, v378, v42, v43, v44, v45, v46, v47, v48);\nL_00B6:\n\tv571 = UnityEngine.Object::op_Inequality(this.multiplyMaterialSource, 0);\n\tv576 = v571 == 0;\n\tif (v576) goto L_0073;\n\tv434 = Spine.Unity.Deprecated.SlotBlendModes::GetOrAddMaterialFor(this.multiplyMaterialSource, this.texture);\n\tSystem.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::set_Item(v87.customSlotMaterials, v491, v434);\nL_00C4:\n\tv296 = v296 + 1;\n\tgoto L_0073;\nL_00CA:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v380 @ stack_-98_v13 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00CF:\n\t// 207 NewArr v666 @ X0_v47 (SlotMaterialTextureTuple[]), typeof(SlotMaterialTextureTuple[]), v296 @ X21_v12 (UnityEngine.Object)\n\tthis.slotsWithCustomMaterial = v666;\n\tv330 = Spine.Unity.SkeletonRenderer::get_Skeleton(v87);\n\tv740 = Spine.ExposedList`1<Spine.Slot>::GetEnumerator(v330.slots);\nL_00E4:\n\tv714 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v380 @ stack_-98_v13 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv157 = v714 == 0;\n\tif (v157) goto L_014E;\n\tv731 = v491.data;\n\tv508 = v731.blendMode == 2;\n\tif (v508) goto L_0128;\n\tv449 = v731.blendMode != 3;\n\tif (v449) goto L_00E4;\n\tgoto L_010E;\n\tv803 = \"il2cpp_codegen_runtime_class_init\"(v797, v712, v148, v92, v37, v38, v39, v40, v135, v42, v43, v44, v45, v46, v47, v48);\nL_010E:\n\tv484 = UnityEngine.Object::op_Inequality(this.screenMaterialSource, 0);\n\tv771 = v484 == 0;\n\tif (v771) goto L_00E4;\n\tv814 = this.slotsWithCustomMaterial;\n\tv486 = this.slotsWithCustomMaterial == 0;\n\tif (v486) goto L_016D;\n\tv775 = this.screenMaterialSource;\n\tv752 = this.texture;\n\tgoto L_0142;\nL_0128:\n\tgoto L_012D;\n\tv800 = \"il2cpp_codegen_runtime_class_init\"(v794, v712, v148, v92, v37, v38, v39, v40, v135, v42, v43, v44, v45, v46, v47, v48);\nL_012D:\n\tv533 = UnityEngine.Object::op_Inequality(this.multiplyMaterialSource, 0);\n\tv772 = v533 == 0;\n\tif (v772) goto L_00E4;\n\tv814 = this.slotsWithCustomMaterial;\n\tv752 = this.texture;\n\tv775 = this.multiplyMaterialSource;\nL_0142:\n\tv773 = v142 * 0x18;\n\tv816 = v814 + v773;\n\tv142 = v142 + 1;\n\t*([v816 @ X9_v16+20]) = v491;\n\tv814[v142 @ X22_v15 (System.Int32)].texture2D = v752;\n\tv764 = v816 + 0x30;\n\t*([v764 @ X9_v17]) = v775;\n\tgoto L_00E4;\nL_014E:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v380 @ stack_-98_v13 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_014F:\n\t;\n\tthis.<Applied>k__BackingField = 1;\n\tv154 = Spine.Unity.SkeletonRenderer::LateUpdate(v87);\nL_0162:\n\treturn;\n\tv653 = new System.NullReferenceException();\n\tv672 = new System.NullReferenceException();\n\tv719 = new System.NullReferenceException();\n\tv328 = new System.NullReferenceException();\n\tv341 = new System.NullReferenceException();\n\tv395 = new System.NullReferenceException();\n\tv439 = new System.NullReferenceException();\n\tv489 = new System.IndexOutOfRangeException();\n\tv538 = new System.NullReferenceException();\n\tv619 = new System.IndexOutOfRangeException();\nL_016D:\n\tv646 = new System.NullReferenceException();\n\tgoto L_01AF;\n\tgoto L_01AF;\n\tgoto L_01AF;\n\tgoto L_01AF;\n\tgoto L_0180;\n\tgoto L_0180;\n\tgoto L_0180;\n\tgoto L_0180;\n\tgoto L_01AF;\n\tgoto L_01AF;\n\tgoto L_0180;\n\tgoto L_0180;\n\tgoto L_01AF;\n\tgoto L_01AF;\n\tgoto L_0180;\n\tgoto L_0180;\n\tgoto L_01AF;\n\tgoto L_01AF;\nL_0180:\n\tX22 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0199;\n\tX0 = X22;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1946438]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tif (TEMP) goto L_014F;\n\tX0 = X21;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0199:\n\tX21 = 0;\n\tgoto L_019C;\n\tX22 = X0;\nL_019C:\n\tX8 = 0x1946000;\n\tX8 = *([1946438]);\n\tX1 = *([X8]);\n\tX0 = &stack[20];\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tif (TEMP) goto L_01CA;\n\tX0 = X21;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01AF:\n\tv188 = v641 != 1;\n\tif (v188) goto L_01BF;\n\tv675 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::set_Item(v646, v641, v228);\n\tv720 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::set_Item(v675, v641, v228);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v606 @ stack_-80_v4 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv660 = *([v675 @ X0_v24 (System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>)]) == 0;\n\tif (v660) goto L_00CF;\n\tthrow System.OutOfMemoryException;\nL_01BF:\n\tgoto L_01C5;\n\tX22 = X0;\nL_01C5:\n\tSpine.E\n// ... truncated")]
		public unsafe void Apply()
		{
			//IL_01ed: Expected O, but got I
			//IL_04ca: Expected O, but got I
			//IL_0502: Expected O, but got I
			GetTexture();
			if (texture == null)
			{
				return;
			}
			SkeletonRenderer component = GetComponent<SkeletonRenderer>();
			if (component == null)
			{
				return;
			}
			Skeleton skeleton = component.Skeleton;
			ExposedList<Slot>.Enumerator enumerator = skeleton.Slots.GetEnumerator();
			UnityEngine.Object obj = null;
			ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
			Slot slot = default(Slot);
			while (enumerator2.MoveNext())
			{
				SlotData data = slot.Data;
				if (data.BlendMode != BlendMode.Multiply)
				{
					if (data.BlendMode != BlendMode.Screen || !(screenMaterialSource != null))
					{
						continue;
					}
					Material orAddMaterialFor = GetOrAddMaterialFor(screenMaterialSource, texture);
					component.CustomSlotMaterials[slot] = orAddMaterialFor;
				}
				else
				{
					if (!(multiplyMaterialSource != null))
					{
						continue;
					}
					Material orAddMaterialFor2 = GetOrAddMaterialFor(multiplyMaterialSource, texture);
					component.CustomSlotMaterials[slot] = orAddMaterialFor2;
				}
				obj = (UnityEngine.Object)((nint)obj + 1);
			}
			enumerator2.Dispose();
			UnityEngine.Object obj4 = default(UnityEngine.Object);
			Material value = default(Material);
			Dictionary<Slot, Material> dictionary = default(Dictionary<Slot, Material>);
			ExposedList<object>.Enumerator enumerator4 = default(ExposedList<object>.Enumerator);
			UnityEngine.Object obj5 = default(UnityEngine.Object);
			while (true)
			{
				SlotMaterialTextureTuple[] array = new SlotMaterialTextureTuple[(object)obj];
				slotsWithCustomMaterial = array;
				Skeleton skeleton2 = component.Skeleton;
				ExposedList<Slot>.Enumerator enumerator3 = skeleton2.Slots.GetEnumerator();
				int num = 0;
				while (true)
				{
					if (enumerator2.MoveNext())
					{
						SlotData data2 = slot.Data;
						SlotMaterialTextureTuple[] array2;
						Material material;
						Texture2D texture2D;
						if (data2.BlendMode != BlendMode.Multiply)
						{
							if (data2.BlendMode != BlendMode.Screen || !(screenMaterialSource != null))
							{
								continue;
							}
							array2 = slotsWithCustomMaterial;
							if (slotsWithCustomMaterial == null)
							{
								break;
							}
							material = screenMaterialSource;
							texture2D = texture;
						}
						else
						{
							if (!(multiplyMaterialSource != null))
							{
								continue;
							}
							array2 = slotsWithCustomMaterial;
							texture2D = texture;
							material = multiplyMaterialSource;
						}
						int num2 = num * 24;
						object obj2 = (nint)array2 + num2;
						num++;
						array2[num].texture2D = texture2D;
						object obj3 = (nint)obj2 + 48;
						obj3 = material;
						continue;
					}
					enumerator2.Dispose();
					Applied = true;
					component.LateUpdate();
					return;
				}
				NullReferenceException ex = new NullReferenceException();
				if ((nint)obj4 == 1)
				{
					((Dictionary<Slot, Material>)(object)ex)[(Slot)(object)obj4] = value;
					dictionary[(Slot)(object)obj4] = value;
					enumerator4.Dispose();
					bool flag = dictionary == null;
					obj = obj5;
					if (!flag)
					{
						throw new OutOfMemoryException();
					}
					continue;
				}
				break;
			}
			enumerator4.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((ExposedList<Slot>.Enumerator*)ex2)->Dispose();
		}

		[Token(Token = "0x600074D")]
		[Address(RVA = "0x1579CB0", Offset = "0x1579CB0", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv75 = UnityEngine.Object;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37D2D]) = v54;\nL_0026:\n\tSpine.Unity.Deprecated.SlotBlendModes::GetTexture(this);\n\tgoto L_0031;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0031:\n\tv73 = UnityEngine.Object::op_Equality(this.texture, 0);\n\tv77 = v73 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_00CA;\n\tv83 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0046;\n\tv227 = v152;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v227, v82, v72, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0046:\n\tv145 = UnityEngine.Object::op_Equality(v83, 0);\n\tv232 = v145 == 0;\n\tv149 = ~v232;\n\tif (v149) goto L_00CA;\n\tv130 = this.slotsWithCustomMaterial;\n\tv312 = v130.Length < 1;\n\tif (v312) goto L_00B3;\n\tv249 = v130 + 0x30;\nL_0072:\n\tv290 = Spine.Unity.Deprecated.SlotBlendModes::GetExistingMaterialFor(*([v249 @ X28_v7]), *([v249 @ X28_v7-8]));\n\tv297 = v290.refcount - 1;\n\tv290.refcount = v297;\n\tv256 = v290.refcount != 1;\n\tif (v256) goto L_008D;\n\tSpine.Unity.Deprecated.SlotBlendModes::RemoveMaterialFromTable(*([v249 @ X28_v7]), *([v249 @ X28_v7-8]));\nL_008D:\n\tv363 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::TryGetValue(v83.customSlotMaterials, *([v249 @ X28_v7-10]), &v324 @ stack_-68_v7 (System.Object));\n\tv342 = v363 == 0;\n\tif (v342) goto L_00A5;\n\tv376 = v324 != v290.materialClone;\n\tif (v376) goto L_00A5;\n\tv388 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::Remove(v83.customSlotMaterials, *([v249 @ X28_v7-10]));\nL_00A5:\n\tv251 = v251 + 1;\n\tv249 = v249 + 0x18;\n\tv328 = v251 < v130.Length;\n\tif (v328) goto L_0072;\nL_00B3:\n\tthis.slotsWithCustomMaterial = 0;\n\tthis.<Applied>k__BackingField = 0;\n\tv148 = ~v83.valid;\n\tif (v148) goto L_00CA;\n\tv144 = Spine.Unity.SkeletonRenderer::LateUpdate(v83);\nL_00CA:\n\treturn;\n\tv300 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Remove()
		{
			//IL_00bf: Expected O, but got I
			//IL_00e3: Expected O, but got I
			//IL_0169: Expected O, but got I
			//IL_01f1: Expected O, but got I
			//IL_0146: Expected O, but got I
			//IL_01ca: Expected O, but got I
			GetTexture();
			if (texture == null)
			{
				return;
			}
			SkeletonRenderer component = GetComponent<SkeletonRenderer>();
			if (component == null)
			{
				return;
			}
			SlotMaterialTextureTuple[] array = slotsWithCustomMaterial;
			if (array.Length >= 1)
			{
				object obj = (nint)array + 48;
				int num = 0;
				do
				{
					object materialSource = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X28_v7-8]");
					MaterialWithRefcount existingMaterialFor = GetExistingMaterialFor((Material)materialSource, (Texture2D)0);
					int refcount = existingMaterialFor.refcount - 1;
					existingMaterialFor.refcount = refcount;
					if (existingMaterialFor.refcount == 1)
					{
						object materialSource2 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X28_v7-8]");
						RemoveMaterialFromTable((Material)materialSource2, (Texture2D)0);
					}
					Dictionary<Slot, Material> customSlotMaterials = component.CustomSlotMaterials;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X28_v7-10]");
					object value;
					if (customSlotMaterials.TryGetValue((Slot)0, out *(Material*)(&value)) && value == existingMaterialFor.materialClone)
					{
						Dictionary<Slot, Material> customSlotMaterials2 = component.CustomSlotMaterials;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X28_v7-10]");
						bool flag = customSlotMaterials2.Remove((Slot)0);
					}
					num++;
					obj = (nint)obj + 24;
				}
				while (num < array.Length);
			}
			slotsWithCustomMaterial = null;
			Applied = false;
			if (component.valid)
			{
				component.LateUpdate();
			}
		}

		[Token(Token = "0x600074E")]
		[Address(RVA = "0x1579EA0", Offset = "0x1579EA0", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = UnityEngine.Texture2D;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37D2E]) = v38;\nL_001E:\n\tgoto L_0023;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv52 = UnityEngine.Object::op_Equality(this.texture, 0);\n\tv56 = v52 == 0;\n\tif (v56) goto L_009D;\n\tv61 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0037;\n\tv161 = v120;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v161, v60, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tv108 = UnityEngine.Object::op_Equality(v61, 0);\n\tv166 = v108 == 0;\n\tv114 = ~v166;\n\tif (v114) goto L_009D;\n\tv127 = v61.skeletonDataAsset;\n\tgoto L_0048;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v168, v102, v97, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0048:\n\tv109 = UnityEngine.Object::op_Equality(v61.skeletonDataAsset, 0);\n\tv190 = v109 == 0;\n\tv115 = ~v190;\n\tif (v115) goto L_009D;\n\tv122 = *([v127 @ X20_v8 (UnityEngine.Object)+18]);\n\tv128 = *([v122 @ X8_v11+20]);\n\tgoto L_005F;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v191, v103, v98, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_005F:\n\tv110 = UnityEngine.Object::op_Equality(*([v122 @ X8_v11+20]), 0);\n\tv198 = v110 == 0;\n\tv116 = ~v198;\n\tif (v116) goto L_009D;\n\tv199 = *([v128 @ X20_v9 (UnityEngine.Object)]);\n\t*([v199 @ X8_v12 (Il2CppClass<UnityEngine.Object>)+178])(v203, *([v122 @ X8_v11+20]), *([v199 @ X8_v12 (Il2CppClass<UnityEngine.Object>)+180]), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0076;\n\tv206 = v119;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v206, v202, v99, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0076:\n\tv111 = UnityEngine.Object::op_Equality(v203, 0);\n\tv211 = v111 == 0;\n\tv117 = ~v211;\n\tif (v117) goto L_009D;\n\tv107 = UnityEngine.Material::get_mainTexture(v203);\n\tv113 = v107 == 0;\n\tif (v113) goto L_0097;\n\tv64 = *([v107 @ X0_v30 (UnityEngine.Texture)]) != UnityEngine.Texture2D;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_0095;\nL_0095:\n\tthis.texture = v123;\n\tgoto L_009D;\nL_0097:\n\tthis.texture = 0;\nL_009D:\n\treturn;\n\tv182 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GetTexture()
		{
			//IL_00d4: Expected O, but got I
			//IL_00e9: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_0134: Expected I, but got O
			if (!(this.texture == null))
			{
				return;
			}
			SkeletonRenderer component = GetComponent<SkeletonRenderer>();
			if (component == null)
			{
				return;
			}
			UnityEngine.Object skeletonDataAsset = component.skeletonDataAsset;
			if (component.skeletonDataAsset == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X20_v8 (UnityEngine.Object)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v11+20]");
			UnityEngine.Object obj2 = (UnityEngine.Object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v11+20]");
			if ((UnityEngine.Object)0 == null)
			{
				return;
			}
			nint num = (nint)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v199 @ X8_v12 (Il2CppClass<UnityEngine.Object>)+178] (should have been resolved before IL gen)");
			UnityEngine.Object obj3 = default(UnityEngine.Object);
			if (!(obj3 == null))
			{
				Texture mainTexture = ((Material)obj3).mainTexture;
				if ((object)mainTexture == null)
				{
					this.texture = null;
					return;
				}
				Texture texture = (((object)mainTexture.GetType() != typeof(Texture2D)) ? null : mainTexture);
				this.texture = (Texture2D)texture;
			}
		}

		[Token(Token = "0x600074F")]
		[Address(RVA = "0x157A054", Offset = "0x157A054", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = SlotMaterialTextureTuple[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37D2F]) = v37;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (SlotMaterialTextureTuple[]), typeof(SlotMaterialTextureTuple[]), 0\n\tthis.slotsWithCustomMaterial = v40;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SlotBlendModes()
		{
			SlotMaterialTextureTuple[] array = new SlotMaterialTextureTuple[0];
			slotsWithCustomMaterial = array;
		}
	}
}
