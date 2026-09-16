using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000CE")]
	public sealed class IronSourceAppStateHandler : MonoBehaviour
	{
		[Token(Token = "0x600077C")]
		[Address(RVA = "0xBFFF28", Offset = "0xBFFF28", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0B400]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F8C]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv62 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v62, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Object::DontDestroyOnLoad(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			GameObject target = base.gameObject;
			Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x600077D")]
		[Address(RVA = "0xBFFFA4", Offset = "0xBFFFA4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = IronSource::get_Agent();\n\tIronSource::onApplicationPause(v11, pause);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationPause(bool pause)
		{
			IronSource agent = IronSource.Agent;
			agent.onApplicationPause(pause);
		}

		[Token(Token = "0x600077E")]
		[Address(RVA = "0xBFFFD8", Offset = "0xBFFFD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IronSourceAppStateHandler()
		{
		}
	}
}
