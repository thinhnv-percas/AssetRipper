using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000016")]
public class TCP2_ShaderUpdateUnityTime : MonoBehaviour
{
	[Token(Token = "0x6000098")]
	[Address(RVA = "0xB0AE0C", Offset = "0xB0AE0C", Length = "0x54")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1ED9858]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20224F3]) = v35;\nL_0012:\n\tv37 = UnityEngine.Time::get_time();\n\tUnityEngine.Shader::SetGlobalFloat(\"unityTime\", v37);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void LateUpdate()
	{
		float time = Time.time;
		Shader.SetGlobalFloat("unityTime", time);
	}

	[Token(Token = "0x6000099")]
	[Address(RVA = "0xB0AE60", Offset = "0xB0AE60", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_ShaderUpdateUnityTime()
	{
	}
}
