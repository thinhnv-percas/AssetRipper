using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace Spine.Unity
{
	[ExecuteAlways]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRenderSeparator")]
	[Token(Token = "0x2000094")]
	public class SkeletonRenderSeparator : MonoBehaviour
	{
		[Token(Token = "0x40003A7")]
		public const int DefaultSortingOrderIncrement = 5;

		[SerializeField]
		[Token(Token = "0x40003A8")]
		[FieldOffset(Offset = "0x20")]
		protected SkeletonRenderer skeletonRenderer;

		[Token(Token = "0x40003A9")]
		[FieldOffset(Offset = "0x28")]
		private MeshRenderer mainMeshRenderer;

		[Token(Token = "0x40003AA")]
		[FieldOffset(Offset = "0x30")]
		public bool copyPropertyBlock;

		[Tooltip("Copies MeshRenderer flags into each parts renderer")]
		[Token(Token = "0x40003AB")]
		[FieldOffset(Offset = "0x31")]
		public bool copyMeshRendererFlags;

		[Token(Token = "0x40003AC")]
		[FieldOffset(Offset = "0x38")]
		public List<SkeletonPartsRenderer> partsRenderers;

		[CompilerGenerated]
		[Token(Token = "0x40003AD")]
		[FieldOffset(Offset = "0x40")]
		private SkeletonRenderer.SkeletonRendererDelegate m_OnMeshAndMaterialsUpdated;

		[Token(Token = "0x40003AE")]
		[FieldOffset(Offset = "0x48")]
		private MaterialPropertyBlock copiedBlock;

		[Token(Token = "0x170001AC")]
		public SkeletonRenderer SkeletonRenderer
		{
			[Token(Token = "0x600060E")]
			[Address(RVA = "0x1567BB4", Offset = "0x1567BB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonRenderer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SkeletonRenderer;
			}
			[Token(Token = "0x600060F")]
			[Address(RVA = "0x1567BBC", Offset = "0x1567BBC", Length = "0x118")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = Spine.Unity.SkeletonRenderer+InstructionDelegate;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv50 = UnityEngine.Object;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv59 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37C8F]) = v43;\nL_0021:\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv57 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv61 = v57 == 0;\n\tif (v61) goto L_003C;\n\tv66 = new Spine.Unity.SkeletonRenderer+InstructionDelegate();\n\tSpine.Unity.SkeletonRenderer+InstructionDelegate::.ctor(v66, this, Il2CppMethodInfo);\n\tv78 = this.skeletonRenderer == 0;\n\tif (v78) goto L_005E;\n\tSpine.Unity.SkeletonRenderer::remove_GenerateMeshOverride(this.skeletonRenderer, v66);\nL_003C:\n\tthis.skeletonRenderer = value;\n\tgoto L_0046;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v82, v73, v71, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0046:\n\tv94 = UnityEngine.Object::op_Equality(value, 0);\n\tv96 = v94 == 0;\n\tif (v96) goto L_005D;\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\treturn;\nL_005D:\n\treturn;\nL_005E:\n\tthrow v66;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (SkeletonRenderer != null)
				{
					SkeletonRenderer.InstructionDelegate instructionDelegate = HandleRender;
					if ((object)SkeletonRenderer == null)
					{
						throw instructionDelegate;
					}
					SkeletonRenderer.GenerateMeshOverride -= instructionDelegate;
				}
				skeletonRenderer = value;
				if (value == null)
				{
					base.enabled = false;
				}
			}
		}

		[Token(Token = "0x1400002D")]
		public event SkeletonRenderer.SkeletonRendererDelegate OnMeshAndMaterialsUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x6000610")]
			[Address(RVA = "0x1567CD4", Offset = "0x1567CD4", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C90]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnMeshAndMaterialsUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonRenderer.SkeletonRendererDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000611")]
			[Address(RVA = "0x1567D70", Offset = "0x1567D70", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C91]) = v38;\nL_0014:\n\tv40 = this + 0x40;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnMeshAndMaterialsUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonRenderer.SkeletonRendererDelegate))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000612")]
		[Address(RVA = "0x1567E0C", Offset = "0x1567E0C", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv42 = UnityEngine.Debug;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, sortingLayerID, extraPartsRenderers, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, sortingLayerID, extraPartsRenderers, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, sortingLayerID, extraPartsRenderers, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, sortingLayerID, extraPartsRenderers, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv89 = UnityEngine.Object;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, sortingLayerID, extraPartsRenderers, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv189 = \"Tried to add SkeletonRenderSeparator to a null SkeletonRenderer reference.\";\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, sortingLayerID, extraPartsRenderers, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A37C92]) = v57;\nL_0032:\n\tgoto L_0037;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v58, sortingLayerID, extraPartsRenderers, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0037:\n\tv70 = UnityEngine.Object::op_Equality(skeletonRenderer, 0);\n\tv75 = v70 == 0;\n\tif (v75) goto L_004E;\n\tgoto L_0047;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v82, v68, v69, sortingOrderIncrement, baseSortingOrder, addMinimumPartsRenderers, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0047:\n\tUnityEngine.Debug::Log(\"Tried to add SkeletonRenderSeparator to a null SkeletonRenderer reference.\");\n\tgoto L_00D3;\nL_004E:\n\tv97 = UnityEngine.Component::get_gameObject(skeletonRenderer);\n\tv158 = UnityEngine.GameObject::AddComponent(v97);\n\tv158.skeletonRenderer = skeletonRenderer;\n\tv159 = Spine.Unity.SkeletonRenderer::Initialize(skeletonRenderer, 0);\n\tv287 = addMinimumPartsRenderers == 0;\n\tif (v287) goto L_006A;\n\tv178 = skeletonRenderer.separatorSlots;\n\tv291 = extraPartsRenderers + v178._size;\n\tv173 = v291 + 1;\nL_006A:\n\tv294 = UnityEngine.Component::get_transform(skeletonRenderer);\n\tv175 = v158.partsRenderers;\n\tv307 = v173 < 1;\n\tif (v307) goto L_00C5;\nL_007E:\n\tv335 = System.Int32::ToString(&v118 @ stack_-54_v6 (System.Int32));\n\tv160 = Spine.Unity.SkeletonPartsRenderer::NewPartsRendererGameObject(v294, v335, 0);\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(v160);\n\tUnityEngine.Renderer::set_sortingLayerID(v160.meshRenderer, sortingLayerID);\n\tv340 = v118 * sortingOrderIncrement;\n\tv156 = baseSortingOrder + v340;\n\tUnityEngine.Renderer::set_sortingOrder(v160.meshRenderer, v156);\n\tv181 = v175._items;\n\tv107 = v175._version + 1;\n\tv175._version = v107;\n\tv311 = v175._size;\n\tv342 = v175._size < v181.Length;\n\tv343 = ~v342;\n\tif (v343) goto L_00B4;\n\tv351 = v175._size + 1;\n\tv175._size = v351;\n\tv181[v311 @ X10_v7 (System.Int32)] = v160;\n\tgoto L_00B6;\nL_00B4:\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::AddWithResize(v175, v160);\nL_00B6:\n\tv327 = v118 + 1;\n\tv312 = v327 < v173;\n\tif (v312) goto L_007E;\nL_00C5:\n\tSpine.Unity.SkeletonRenderSeparator::OnEnable(v158);\nL_00D3:\n\treturn v240;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonRenderSeparator AddToSkeletonRenderer(SkeletonRenderer skeletonRenderer, int sortingLayerID = 0, int extraPartsRenderers = 0, int sortingOrderIncrement = 5, int baseSortingOrder = 0, bool addMinimumPartsRenderers = true)
		{
			//IL_01ed: Expected I4, but got O
			if (skeletonRenderer == null)
			{
				Debug.Log("Tried to add SkeletonRenderSeparator to a null SkeletonRenderer reference.");
				return null;
			}
			GameObject gameObject = skeletonRenderer.gameObject;
			SkeletonRenderSeparator skeletonRenderSeparator = gameObject.AddComponent<SkeletonRenderSeparator>();
			skeletonRenderSeparator.skeletonRenderer = skeletonRenderer;
			skeletonRenderer.Initialize(overwrite: false);
			bool flag = !addMinimumPartsRenderers;
			int num = extraPartsRenderers;
			if (!flag)
			{
				List<Slot> separatorSlots = skeletonRenderer.separatorSlots;
				int num2 = extraPartsRenderers + separatorSlots.Count;
				num = num2 + 1;
			}
			Transform parent = skeletonRenderer.transform;
			List<SkeletonPartsRenderer> list = skeletonRenderSeparator.partsRenderers;
			bool flag2 = num < 1;
			int num3 = 0;
			if (!flag2)
			{
				int num4 = default(int);
				int num6;
				do
				{
					string text = num4.ToString();
					SkeletonPartsRenderer skeletonPartsRenderer = SkeletonPartsRenderer.NewPartsRendererGameObject(parent, text);
					skeletonPartsRenderer.LazyIntialize();
					skeletonPartsRenderer.meshRenderer.sortingLayerID = sortingLayerID;
					int num5 = num4 * sortingOrderIncrement;
					num3 = baseSortingOrder + num5;
					skeletonPartsRenderer.meshRenderer.sortingOrder = num3;
					SkeletonPartsRenderer[] items = list._items;
					int version = list._version + 1;
					list._version = version;
					int count = list.Count;
					if (list.Count < items.Length)
					{
						int size = list.Count + 1;
						list._size = size;
						items[count] = skeletonPartsRenderer;
					}
					else
					{
						list.Add(skeletonPartsRenderer);
						num3 = (int)skeletonPartsRenderer;
					}
					num6 = num4 + 1;
				}
				while (num6 < num);
			}
			skeletonRenderSeparator.OnEnable();
			return skeletonRenderSeparator;
		}

		[Token(Token = "0x6000613")]
		[Address(RVA = "0x156836C", Offset = "0x156836C", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, sortingOrderIncrement, name, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, sortingOrderIncrement, name, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv154 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v154, sortingOrderIncrement, name, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C93]) = v42;\nL_001C:\n\tv44 = this.partsRenderers;\n\tv49 = v44._size;\n\tv59 = v44._size - 1;\n\tv61 = v44._size < 1;\n\tif (v61) goto L_FFFFFFFF;\n\tv122 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::get_Item(v44, v59);\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(v122);\n\tv213 = UnityEngine.Renderer::get_sortingLayerID(v122.meshRenderer);\n\tv161 = UnityEngine.Renderer::get_sortingOrder(v122.meshRenderer);\n\tv140 = v161 + sortingOrderIncrement;\n\tgoto L_0045;\nL_0045:\n\tv123 = System.String::IsNullOrEmpty(name);\n\tv203 = v123 == 0;\n\tif (v203) goto L_0056;\n\tv146 = this.partsRenderers;\n\tv49 = v146._size;\n\tv207 = System.Int32::ToString(&v49 @ X8_v4 (System.Int32));\nL_0056:\n\tv216 = UnityEngine.Component::get_transform(this.skeletonRenderer);\n\tv124 = Spine.Unity.SkeletonPartsRenderer::NewPartsRendererGameObject(v216, v142, 0);\n\tv147 = this.partsRenderers;\n\tv70 = v147._items;\n\tv74 = v147._version + 1;\n\tv147._version = v74;\n\tv75 = v147._size;\n\tv221 = v147._size < v70.Length;\n\tv119 = ~v221;\n\tif (v119) goto L_007E;\n\tv222 = v147._size + 1;\n\tv147._size = v222;\n\tv70[v75 @ X11_v4 (System.Int32)] = v124;\n\tgoto L_0082;\nL_007E:\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::AddWithResize(v147, v124);\nL_0082:\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(v124);\n\tUnityEngine.Renderer::set_sortingLayerID(v124.meshRenderer, v151);\n\tUnityEngine.Renderer::set_sortingOrder(v124.meshRenderer, v140);\n\treturn v124;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonPartsRenderer AddPartsRenderer(int sortingOrderIncrement = 5, string name = null)
		{
			List<SkeletonPartsRenderer> list = partsRenderers;
			int count = list.Count;
			int index = list.Count - 1;
			int sortingOrder2;
			int sortingLayerID2;
			if (list.Count >= 1)
			{
				SkeletonPartsRenderer skeletonPartsRenderer = list[index];
				skeletonPartsRenderer.LazyIntialize();
				int sortingLayerID = skeletonPartsRenderer.meshRenderer.sortingLayerID;
				int sortingOrder = skeletonPartsRenderer.meshRenderer.sortingOrder;
				sortingOrder2 = sortingOrder + sortingOrderIncrement;
				sortingLayerID2 = sortingLayerID;
			}
			else
			{
				sortingOrder2 = 0;
				sortingLayerID2 = 0;
			}
			bool flag = string.IsNullOrEmpty(name);
			bool flag2 = !flag;
			string text = name;
			if (!flag2)
			{
				List<SkeletonPartsRenderer> list2 = partsRenderers;
				string text2 = list2.Count.ToString();
				text = text2;
			}
			Transform parent = SkeletonRenderer.transform;
			SkeletonPartsRenderer skeletonPartsRenderer2 = SkeletonPartsRenderer.NewPartsRendererGameObject(parent, text);
			List<SkeletonPartsRenderer> list3 = partsRenderers;
			SkeletonPartsRenderer[] items = list3._items;
			int version = list3._version + 1;
			list3._version = version;
			int count2 = list3.Count;
			if (list3.Count < items.Length)
			{
				int size = list3.Count + 1;
				list3._size = size;
				items[count2] = skeletonPartsRenderer2;
			}
			else
			{
				list3.Add(skeletonPartsRenderer2);
			}
			skeletonPartsRenderer2.LazyIntialize();
			skeletonPartsRenderer2.meshRenderer.sortingLayerID = sortingLayerID2;
			skeletonPartsRenderer2.meshRenderer.sortingOrder = sortingOrder2;
			return skeletonPartsRenderer2;
		}

		[Token(Token = "0x6000614")]
		[Address(RVA = "0x1568068", Offset = "0x1568068", Length = "0x304")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv61 = Spine.Unity.SkeletonRenderer+InstructionDelegate;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv188 = UnityEngine.MaterialPropertyBlock;\n\tv189 = \"il2cpp_codegen_initialize_runtime_metadata\"(v188, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv203 = UnityEngine.Object;\n\tv204 = \"il2cpp_codegen_initialize_runtime_metadata\"(v203, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv266 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37C94]) = v54;\nL_0032:\n\tgoto L_0037;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0037:\n\tv68 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv73 = v68 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_00F5;\n\tv79 = this.copiedBlock == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_004E;\n\tv193 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v193);\n\tthis.copiedBlock = v193;\nL_004E:\n\tv208 = UnityEngine.Component::GetComponent(this.skeletonRenderer);\n\tthis.mainMeshRenderer = v208;\n\tv233 = new Spine.Unity.SkeletonRenderer+InstructionDelegate();\n\tSpine.Unity.SkeletonRenderer+InstructionDelegate::.ctor(v233, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::remove_GenerateMeshOverride(this.skeletonRenderer, v233);\n\tv234 = new Spine.Unity.SkeletonRenderer+InstructionDelegate();\n\tSpine.Unity.SkeletonRenderer+InstructionDelegate::.ctor(v234, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::add_GenerateMeshOverride(this.skeletonRenderer, v234);\n\tv165 = ~this.copyMeshRendererFlags;\n\tif (v165) goto L_00F5;\n\tv236 = UnityEngine.Renderer::get_lightProbeUsage(this.mainMeshRenderer);\n\tv237 = UnityEngine.Renderer::get_receiveShadows(this.mainMeshRenderer);\n\tv238 = UnityEngine.Renderer::get_reflectionProbeUsage(this.mainMeshRenderer);\n\tv239 = UnityEngine.Renderer::get_shadowCastingMode(this.mainMeshRenderer);\n\tv240 = UnityEngine.Renderer::get_motionVectorGenerationMode(this.mainMeshRenderer);\n\tv241 = UnityEngine.Renderer::get_probeAnchor(this.mainMeshRenderer);\n\tv170 = this.partsRenderers;\nL_00AD:\n\tv84 = v126 >= v170._size;\n\tif (v84) goto L_00F5;\n\tv295 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::get_Item(v170, v126);\n\tgoto L_00BE;\n\tv298 = v263;\n\tv299 = \"il2cpp_codegen_runtime_class_init\"(v298, v294, v292, v142, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00BE:\n\tv242 = UnityEngine.Object::op_Equality(v295, 0);\n\tv303 = v242 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_00E2;\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(v295);\n\tUnityEngine.Renderer::set_lightProbeUsage(*([v295 @ X0_v32 (UnityEngine.Object)+28]), v236);\n\tUnityEngine.Renderer::set_receiveShadows(*([v295 @ X0_v32 (UnityEngine.Object)+28]), v237);\n\tUnityEngine.Renderer::set_reflectionProbeUsage(*([v295 @ X0_v32 (UnityEngine.Object)+28]), v238);\n\tUnityEngine.Renderer::set_shadowCastingMode(*([v295 @ X0_v32 (UnityEngine.Object)+28]), v239);\n\tUnityEngine.Renderer::set_motionVectorGenerationMode(*([v295 @ X0_v32 (UnityEngine.Object)+28]), v240);\n\tUnityEngine.Renderer::set_probeAnchor(*([v295 @ X0_v32 (UnityEngine.Object)+28]), v241);\nL_00E2:\n\tv170 = this.partsRenderers;\n\tv126 = v126 + 1;\n\tv309 = this.partsRenderers == 0;\n\tv244 = ~v309;\n\tif (v244) goto L_00AD;\n\tthrow System.NullReferenceException;\nL_00F5:\n\treturn;\n// 176 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			//IL_020c: Expected O, but got I
			//IL_0221: Expected O, but got I
			//IL_023b: Expected O, but got I
			//IL_0250: Expected O, but got I
			//IL_026a: Expected O, but got I
			//IL_027f: Expected O, but got I
			if (SkeletonRenderer == null)
			{
				return;
			}
			if (copiedBlock == null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				copiedBlock = materialPropertyBlock;
			}
			MeshRenderer component = SkeletonRenderer.GetComponent<MeshRenderer>();
			mainMeshRenderer = component;
			SkeletonRenderer.InstructionDelegate value = HandleRender;
			SkeletonRenderer.GenerateMeshOverride -= value;
			SkeletonRenderer.InstructionDelegate value2 = HandleRender;
			SkeletonRenderer.GenerateMeshOverride += value2;
			if (!copyMeshRendererFlags)
			{
				return;
			}
			LightProbeUsage lightProbeUsage = mainMeshRenderer.lightProbeUsage;
			bool receiveShadows = mainMeshRenderer.receiveShadows;
			ReflectionProbeUsage reflectionProbeUsage = mainMeshRenderer.reflectionProbeUsage;
			ShadowCastingMode shadowCastingMode = mainMeshRenderer.shadowCastingMode;
			MotionVectorGenerationMode motionVectorGenerationMode = mainMeshRenderer.motionVectorGenerationMode;
			Transform probeAnchor = mainMeshRenderer.probeAnchor;
			List<SkeletonPartsRenderer> list = partsRenderers;
			int num = 0;
			while (num < list.Count)
			{
				UnityEngine.Object obj = list[num];
				if (!(obj == null))
				{
					((SkeletonPartsRenderer)obj).LazyIntialize();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v32 (UnityEngine.Object)+28]");
					((Renderer)0).lightProbeUsage = lightProbeUsage;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v32 (UnityEngine.Object)+28]");
					((Renderer)0).receiveShadows = receiveShadows;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v32 (UnityEngine.Object)+28]");
					((Renderer)0).reflectionProbeUsage = reflectionProbeUsage;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v32 (UnityEngine.Object)+28]");
					((Renderer)0).shadowCastingMode = shadowCastingMode;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v32 (UnityEngine.Object)+28]");
					((Renderer)0).motionVectorGenerationMode = motionVectorGenerationMode;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v32 (UnityEngine.Object)+28]");
					((Renderer)0).probeAnchor = probeAnchor;
				}
				list = partsRenderers;
				num++;
				if (partsRenderers == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x6000615")]
		[Address(RVA = "0x156852C", Offset = "0x156852C", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv65 = Spine.Unity.SkeletonRenderer+InstructionDelegate;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv134 = Il2CppMethodInfo;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv167 = UnityEngine.Object;\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv171 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v171, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C95]) = v40;\nL_0027:\n\tv42 = 0;\n\tgoto L_0033;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0033:\n\tv57 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv62 = v57 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_007F;\n\tv71 = new Spine.Unity.SkeletonRenderer+InstructionDelegate();\n\tSpine.Unity.SkeletonRenderer+InstructionDelegate::.ctor(v71, this, Il2CppMethodInfo);\n\tv169 = this.skeletonRenderer == 0;\n\tif (v169) goto L_0081;\n\tSpine.Unity.SkeletonRenderer::remove_GenerateMeshOverride(this.skeletonRenderer, v71);\n\tv185 = this.skeletonRenderer == 0;\n\tif (v185) goto L_0081;\n\tv194 = Spine.Unity.SkeletonRenderer::LateUpdate(this.skeletonRenderer);\n\tv186 = this.partsRenderers == 0;\n\tif (v186) goto L_0081;\n\tv200 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::GetEnumerator(this.partsRenderers);\nL_005D:\n\tv222 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v42 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv117 = v222 == 0;\n\tif (v117) goto L_0078;\n\tgoto L_006B;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v231, v220, v108, v106, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_006B:\n\tv215 = UnityEngine.Object::op_Inequality(0, 0);\n\tv218 = v215 == 0;\n\tif (v218) goto L_005D;\n\tSpine.Unity.SkeletonPartsRenderer::ClearMesh(0);\n\tgoto L_005D;\nL_0078:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_007F:\n\treturn;\n\tv180 = new System.NullReferenceException();\nL_0081:\n\tv193 = new System.NullReferenceException();\n\tgoto L_0090;\n\tgoto L_0090;\n\tgoto L_0090;\n\tgoto L_0090;\nL_0090:\n\tv74 = v176 != 1;\n\tif (v74) goto L_00A0;\n\tv202 = Spine.Unity.SkeletonRenderSeparator::HandleRender(v193, v176);\n\tv210 = Spine.Unity.SkeletonRenderSeparator::HandleRender(v202, v176);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv118 = *([v202 @ X0_v20 (Spine.Unity.SkeletonRenderSeparator)]) == 0;\n\tif (v118) goto L_007F;\n\tthrow System.OutOfMemoryException;\nL_00A0:\n\tgoto L_00A6;\n\tX19 = X0;\nL_00A6:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00AD;\n\tv227 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>+Enumerator<Spine.Unity.SkeletonPartsRenderer>::Dispose(v193);\nL_00AD:\n\tv230 = new System.OutOfMemoryException();\n\tv157 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>+Enumerator<Spine.Unity.SkeletonPartsRenderer>::Dispose(v230);\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnDisable()
		{
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			if (SkeletonRenderer == null)
			{
				return;
			}
			SkeletonRenderer.InstructionDelegate instructionDelegate = HandleRender;
			bool flag = (object)SkeletonRenderer == null;
			SkeletonRendererInstruction skeletonRendererInstruction = null;
			if (!flag)
			{
				SkeletonRenderer.GenerateMeshOverride -= instructionDelegate;
				bool flag2 = (object)SkeletonRenderer == null;
				skeletonRendererInstruction = (SkeletonRendererInstruction)(object)this;
				if (!flag2)
				{
					SkeletonRenderer.LateUpdate();
					bool flag3 = partsRenderers == null;
					skeletonRendererInstruction = (SkeletonRendererInstruction)(object)instructionDelegate;
					if (!flag3)
					{
						List<SkeletonPartsRenderer>.Enumerator enumerator2 = partsRenderers.GetEnumerator();
						while (enumerator.MoveNext())
						{
							if ((UnityEngine.Object)null != (UnityEngine.Object)null)
							{
								((SkeletonPartsRenderer)null).ClearMesh();
							}
						}
						enumerator.Dispose();
						return;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if ((nint)skeletonRendererInstruction == 1)
			{
				((SkeletonRenderSeparator)(object)ex).HandleRender(skeletonRendererInstruction);
				SkeletonRenderSeparator skeletonRenderSeparator = default(SkeletonRenderSeparator);
				skeletonRenderSeparator.HandleRender(skeletonRendererInstruction);
				enumerator.Dispose();
				if ((object)skeletonRenderSeparator != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((List<SkeletonPartsRenderer>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x6000616")]
		[Address(RVA = "0x1568758", Offset = "0x1568758", Length = "0x304")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, instruction, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, instruction, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv266 = UnityEngine.Object;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, instruction, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37C96]) = v55;\nL_0021:\n\tv56 = this.partsRenderers;\n\tv72 = v56._size < 1;\n\tif (v72) goto L_012D;\n\tv267 = ~this.copyPropertyBlock;\n\tif (v267) goto L_003C;\n\tUnityEngine.Renderer::GetPropertyBlock(this.mainMeshRenderer, this.copiedBlock);\nL_003C:\n\tv252 = this.skeletonRenderer;\n\tv253 = instruction.submeshInstructions;\n\tv106 = v253.Count - 1;\n\tv455 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::get_Item(this.partsRenderers, 0);\n\tv456 = v106 & 0x80000000;\n\tv457 = v456 == 0;\n\tv458 = ~v457;\n\tif (v458) goto L_FFFFFFFF;\nL_006B:\n\tgoto L_0070;\n\tv514 = \"il2cpp_codegen_runtime_class_init\"(v494, v476, v474, v74, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0070:\n\tv227 = UnityEngine.Object::op_Equality(v471, 0);\n\tv524 = v227 == 0;\n\tv525 = ~v524;\n\tif (v525) goto L_00D9;\n\tv400 = v93 - 1;\n\tv200 = v253.Count == v93;\n\tif (v200) goto L_0096;\n\tv556 = v400 * 0x30;\n\tv557 = v253.Items + v556;\n\tv542 = *([v557 @ X8_v22+38]) == 0;\n\tif (v542) goto L_00D9;\nL_0096:\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(v471);\n\tv256 = *([v471 @ X23_v8 (UnityEngine.Object)+20]);\n\t*([v256 @ X8_v19+10]) = 1;\n\t*([v256 @ X8_v19+18]) = v252.pmaVertexColors;\n\t*([v256 @ X8_v19+14]) = v252.zSpacing;\n\t*([v256 @ X8_v19+1A]) = 0;\n\t*([v256 @ X8_v19+1D]) = 0;\n\t*([v256 @ X8_v19+19]) = v252.tintBlack;\n\t*([v256 @ X8_v19+13]) = 0;\n\t*([v256 @ X8_v19+11]) = 0;\n\t*([v256 @ X8_v19+1E]) = 0;\n\t*([v256 @ X8_v19+1B]) = v252.calculateTangents;\n\t*([v256 @ X8_v19+1C]) = v252.addNormals;\n\tv512 = ~this.copyPropertyBlock;\n\tif (v512) goto L_00BB;\n\tSpine.Unity.SkeletonPartsRenderer::SetPropertyBlock(v471, this.copiedBlock);\nL_00BB:\n\tSpine.Unity.SkeletonPartsRenderer::RenderParts(v471, instruction.submeshInstructions, v470, v93);\n\tv249 = v249 + 1;\n\tv171 = v249 >= v56._size;\n\tif (v171) goto L_00E0;\n\tv541 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::get_Item(this.partsRenderers, v249);\nL_00D9:\n\tv469 = v93 + 1;\n\tv478 = v93 <= v106;\n\tif (v478) goto L_006B;\n\tgoto L_00E0;\nL_00E0:\n\t;\n\tv331 = this.OnMeshAndMaterialsUpdated == 0;\n\tif (v331) goto L_00F1;\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::Invoke(this.OnMeshAndMaterialsUpdated, this.skeletonRenderer);\nL_00F1:\n\tv301 = v249 >= v56._size;\n\tif (v301) goto L_012D;\nL_00FA:\n\tv552 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::get_Item(this.partsRenderers, v249);\n\tgoto L_0106;\n\tv559 = v259;\n\tv560 = \"il2cpp_codegen_runtime_class_init\"(v559, v551, v550, v76, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0106:\n\tv563 = UnityEngine.Object::op_Inequality(v552, 0);\n\tv565 = v563 == 0;\n\tif (v565) goto L_0113;\n\tv232 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::get_Item(this.partsRenderers, v249);\n\tSpine.Unity.SkeletonPartsRenderer::ClearMesh(v232);\nL_0113:\n\tv249 = v249 + 1;\n\tv300 = v56._size != v249;\n\tif (v300) goto L_00FA;\nL_012D:\n\treturn;\n\tv264 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 222 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleRender(SkeletonRendererInstruction instruction)
		{
			//IL_00b2: Expected I4, but got I8
			//IL_01cb: Expected O, but got I
			//IL_018d: Expected O, but got I
			List<SkeletonPartsRenderer> list = partsRenderers;
			if (list.Count < 1)
			{
				return;
			}
			if (copyPropertyBlock)
			{
				mainMeshRenderer.GetPropertyBlock(copiedBlock);
			}
			SkeletonRenderer skeletonRenderer = SkeletonRenderer;
			ExposedList<SubmeshInstruction> submeshInstructions = instruction.submeshInstructions;
			int num = submeshInstructions.Count - 1;
			SkeletonPartsRenderer skeletonPartsRenderer = partsRenderers[0];
			int num3;
			if ((int)(num & 0x80000000L) == 0)
			{
				int num2 = 1;
				int startSubmesh = 0;
				UnityEngine.Object obj = skeletonPartsRenderer;
				num3 = 0;
				bool flag;
				do
				{
					if (!(obj == null))
					{
						int num4 = num2 - 1;
						if (submeshInstructions.Count != num2)
						{
							int num5 = num4 * 48;
							object obj2 = (nint)submeshInstructions.Items + num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ X8_v22+38]");
							if ((nint)0 == 0)
							{
								goto IL_039f;
							}
						}
						((SkeletonPartsRenderer)obj).LazyIntialize();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X23_v8 (UnityEngine.Object)+20]");
						object obj3 = 0;
						_ = 1;
						_ = skeletonRenderer.pmaVertexColors;
						_ = skeletonRenderer.zSpacing;
						_ = 0;
						_ = 0;
						_ = skeletonRenderer.tintBlack;
						_ = 0;
						_ = 0;
						_ = 0;
						_ = skeletonRenderer.calculateTangents;
						_ = skeletonRenderer.addNormals;
						if (copyPropertyBlock)
						{
							((SkeletonPartsRenderer)obj).SetPropertyBlock(copiedBlock);
						}
						((SkeletonPartsRenderer)obj).RenderParts(instruction.submeshInstructions, startSubmesh, num2);
						num3++;
						if (num3 >= list.Count)
						{
							break;
						}
						SkeletonPartsRenderer skeletonPartsRenderer2 = partsRenderers[num3];
						startSubmesh = num2;
						obj = skeletonPartsRenderer2;
					}
					goto IL_039f;
					IL_039f:
					int num6 = num2 + 1;
					flag = num2 <= num;
					num2 = num6;
				}
				while (flag);
			}
			else
			{
				num3 = 0;
			}
			if (this.OnMeshAndMaterialsUpdated != null)
			{
				this.OnMeshAndMaterialsUpdated(SkeletonRenderer);
			}
			if (num3 >= list.Count)
			{
				return;
			}
			do
			{
				UnityEngine.Object obj4 = partsRenderers[num3];
				if (obj4 != null)
				{
					SkeletonPartsRenderer skeletonPartsRenderer3 = partsRenderers[num3];
					skeletonPartsRenderer3.ClearMesh();
				}
				num3++;
			}
			while (list.Count != num3);
		}

		[Token(Token = "0x6000617")]
		[Address(RVA = "0x1568A5C", Offset = "0x1568A5C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C97]) = v42;\nL_001A:\n\tthis.copyPropertyBlock = 0x101;\n\tv45 = new System.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.SkeletonPartsRenderer>::.ctor(v45);\n\tthis.partsRenderers = v45;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonRenderSeparator()
		{
			copyPropertyBlock = true;
			copyMeshRendererFlags = true;
			List<SkeletonPartsRenderer> list = new List<SkeletonPartsRenderer>();
			partsRenderers = list;
		}
	}
}
