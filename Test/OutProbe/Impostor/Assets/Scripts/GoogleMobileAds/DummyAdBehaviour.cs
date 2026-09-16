using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000005")]
public class DummyAdBehaviour : MonoBehaviour
{
	[Token(Token = "0x600000E")]
	[Address(RVA = "0x133C8F0", Offset = "0x133C8F0", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = \"Pause Game\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36726]) = v35;\nL_0018:\n\tUnityEngine.Time::set_timeScale(0f);\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v17, v18, v19, v20, v21, v22, v38, v24, v25, v26, v27, v28, v29, v30);\nL_0025:\n\tUnityEngine.Debug::Log(\"Pause Game\");\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PauseGame()
	{
		Time.timeScale = 0f;
		Debug.Log("Pause Game");
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x133C964", Offset = "0x133C964", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = \"Resume Game\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36727]) = v35;\nL_0018:\n\tUnityEngine.Time::set_timeScale(1f);\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v17, v18, v19, v20, v21, v22, v38, v24, v25, v26, v27, v28, v29, v30);\nL_0025:\n\tUnityEngine.Debug::Log(\"Resume Game\");\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ResumeGame()
	{
		Time.timeScale = 1f;
		Debug.Log("Resume Game");
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0x133C9D8", Offset = "0x133C9D8", Length = "0xEC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, dummyAd, methodInfo, v39, v40, v41, v42, v43, position, v0, v2, v44, v45, v46, v47, v48);\n\tv61 = UnityEngine.Object;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, dummyAd, methodInfo, v39, v40, v41, v42, v43, position, v0, v2, v44, v45, v46, v47, v48);\n\tv53 = 1;\n\t*([1A36728]) = v53;\nL_0026:\n\tgoto L_003A;\n\tv63 = UnityEngine.Quaternion;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, dummyAd, methodInfo, v39, v40, v41, v42, v43, position, v0, v2, v44, v45, v46, v47, v48);\n\tv67 = 1;\n\t*([1A3551A]) = v67;\nL_003A:\n\tgoto L_0053;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v70, dummyAd, methodInfo, v39, v40, v41, v42, v43, position, v0, v2, v44, v45, v46, v47, v48);\nL_0053:\n\treturnVal1 = UnityEngine.Object::Instantiate(dummyAd, position, v74.identityQuaternion);\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GameObject ShowAd(GameObject dummyAd, Vector3 position)
	{
		return Object.Instantiate(dummyAd, position, Quaternion.identity);
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0x133CAC4", Offset = "0x133CAC4", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, dummyAd, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A36729]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, dummyAd, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0020:\n\tUnityEngine.Object::Destroy(dummyAd);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DestroyAd(GameObject dummyAd)
	{
		Object.Destroy(dummyAd);
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0x133CB1C", Offset = "0x133CB1C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DummyAdBehaviour()
	{
	}
}
