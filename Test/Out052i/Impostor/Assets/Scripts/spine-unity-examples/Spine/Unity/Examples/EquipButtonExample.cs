using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000038")]
	public class EquipButtonExample : MonoBehaviour
	{
		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x20")]
		public EquipAssetExample asset;

		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x28")]
		public EquipSystemExample equipSystem;

		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x30")]
		public Image inventoryImage;

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x15112B4", Offset = "0x15112B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.EquipButtonExample::MatchImage(this);\n\treturn;\n")]
		private void OnValidate()
		{
			MatchImage();
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x15112B8", Offset = "0x15112B8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A40]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.inventoryImage, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_0035;\n\tv51 = this.asset;\n\tUnityEngine.UI.Image::set_sprite(this.inventoryImage, v51.sprite);\n\treturn;\nL_0035:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void MatchImage()
		{
			if (inventoryImage != null)
			{
				EquipAssetExample equipAssetExample = asset;
				inventoryImage.sprite = equipAssetExample.sprite;
			}
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x1511348", Offset = "0x1511348", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = UnityEngine.Events.UnityAction;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A41]) = v38;\nL_001A:\n\tSpine.Unity.Examples.EquipButtonExample::MatchImage(this);\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv55 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v55, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v45.m_OnClick, v55);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			MatchImage();
			Button component = GetComponent<Button>();
			UnityAction call = delegate
			{
				equipSystem.Equip(asset);
			};
			component.onClick.AddListener(call);
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x15113FC", Offset = "0x15113FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EquipButtonExample()
		{
		}
	}
}
