using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200003E")]
	public class MixAndMatchSkinsButtonExample : MonoBehaviour
	{
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonDataAsset skeletonDataAsset;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x28")]
		public MixAndMatchSkinsExample skinsSystem;

		[SpineSkin(null, "skeletonDataAsset", true, false, false)]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x30")]
		public string itemSkin;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x38")]
		public MixAndMatchSkinsExample.ItemType itemType;

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x1511BA0", Offset = "0x1511BA0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = UnityEngine.Events.UnityAction;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A47]) = v38;\nL_001B:\n\tv41 = UnityEngine.Component::GetComponent(this);\n\tv54 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v54, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v41.m_OnClick, v54);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Button component = GetComponent<Button>();
			UnityAction call = delegate
			{
				skinsSystem.Equip(itemSkin, itemType);
			};
			component.onClick.AddListener(call);
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x1511C4C", Offset = "0x1511C4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MixAndMatchSkinsButtonExample()
		{
		}
	}
}
