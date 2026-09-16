using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000066")]
	public class SlotTintBlackFollower : MonoBehaviour
	{
		[SpineSlot(null, null, false, true, false)]
		[SerializeField]
		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x20")]
		protected string slotName;

		[SerializeField]
		[Token(Token = "0x4000234")]
		[FieldOffset(Offset = "0x28")]
		protected string colorPropertyName;

		[SerializeField]
		[Token(Token = "0x4000235")]
		[FieldOffset(Offset = "0x30")]
		protected string blackPropertyName;

		[Token(Token = "0x4000236")]
		[FieldOffset(Offset = "0x38")]
		public Slot slot;

		[Token(Token = "0x4000237")]
		[FieldOffset(Offset = "0x40")]
		private MeshRenderer mr;

		[Token(Token = "0x4000238")]
		[FieldOffset(Offset = "0x48")]
		private MaterialPropertyBlock mb;

		[Token(Token = "0x4000239")]
		[FieldOffset(Offset = "0x50")]
		private int colorPropertyId;

		[Token(Token = "0x400023A")]
		[FieldOffset(Offset = "0x54")]
		private int blackPropertyId;

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0x151E57C", Offset = "0x151E57C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.SlotTintBlackFollower::Initialize(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Initialize(overwrite: false);
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0x151E584", Offset = "0x151E584", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv60 = Spine.Unity.ISkeletonComponent;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv123 = UnityEngine.MaterialPropertyBlock;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v123, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A37AA9]) = v39;\nL_001D:\n\tv41 = overwrite == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_002B;\n\tv47 = this.mb == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_007E;\nL_002B:\n\tv58 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v58);\n\tthis.mb = v58;\n\tv168 = UnityEngine.Component::GetComponent(this);\n\tthis.mr = v168;\n\tv171 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0067;\n\tv184 = *([v174 @ X8_v8+B0]);\n\tv185 = v184 + 8;\n\tv187 = *([v224 @ X10_v9-8]);\n\tv229 = v187 == v177;\n\tif (v229) goto L_005F;\n\tv207 = v223 - 1;\n\tv209 = v224 + 0x10;\n\tv189 = v223 != 1;\n\tif (v189) goto L_FFFFFFFF;\n\tv210 = 1;\n\tv211 = v111;\n\tv212 = 0xB349B4(v211, v177, v210, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0067;\nL_005F:\n\tv235 = *([v224 @ X10_v9]);\n\tv236 = v235 + 1;\n\tv237 = v236 << 4;\n\tv238 = v174 + v237;\n\tv239 = v238 + 0x138;\nL_0067:\n\tv182 = Spine.Unity.ISkeletonComponent::get_Skeleton(v171);\n\tv244 = Spine.Skeleton::FindSlot(v182, this.slotName);\n\tthis.slot = v244;\n\tv248 = UnityEngine.Shader::PropertyToID(this.colorPropertyName);\n\tthis.colorPropertyId = v248;\n\tv107 = UnityEngine.Shader::PropertyToID(this.blackPropertyName);\n\tthis.blackPropertyId = v107;\nL_007E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(bool overwrite)
		{
			if (overwrite || mb == null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				mb = materialPropertyBlock;
				MeshRenderer component = GetComponent<MeshRenderer>();
				mr = component;
				ISkeletonComponent component2 = GetComponent<ISkeletonComponent>();
				Skeleton skeleton = component2.Skeleton;
				Slot slot = skeleton.FindSlot(slotName);
				this.slot = slot;
				int num = Shader.PropertyToID(colorPropertyName);
				colorPropertyId = num;
				int num2 = Shader.PropertyToID(blackPropertyName);
				blackPropertyId = num2;
			}
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0x151E6F0", Offset = "0x151E6F0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.slot == 0;\n\tif (v12) goto L_003B;\n\tv18 = Spine.Unity.SkeletonExtensions::GetColor(this.slot);\n\tUnityEngine.MaterialPropertyBlock::SetColor(this.mb, this.colorPropertyId, v18);\n\tv55 = Spine.Unity.SkeletonExtensions::GetColorTintBlack(this.slot);\n\tUnityEngine.MaterialPropertyBlock::SetColor(this.mb, this.blackPropertyId, v55);\n\tUnityEngine.Renderer::SetPropertyBlock(this.mr, this.mb);\n\treturn;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			if (slot != null)
			{
				Color color = slot.GetColor();
				mb.SetColor(colorPropertyId, color);
				Color colorTintBlack = slot.GetColorTintBlack();
				mb.SetColor(blackPropertyId, colorTintBlack);
				mr.SetPropertyBlock(mb);
			}
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0x151E78C", Offset = "0x151E78C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MaterialPropertyBlock::Clear(this.mb);\n\tUnityEngine.Renderer::SetPropertyBlock(this.mr, this.mb);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			mb.Clear();
			mr.SetPropertyBlock(mb);
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0x151E7C0", Offset = "0x151E7C0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = \"_Color\";\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = \"_Black\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37AAA]) = v42;\nL_001F:\n\tthis.colorPropertyName = \"_Color\";\n\tthis.blackPropertyName = \"_Black\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SlotTintBlackFollower()
		{
			colorPropertyName = "_Color";
			blackPropertyName = "_Black";
		}
	}
}
