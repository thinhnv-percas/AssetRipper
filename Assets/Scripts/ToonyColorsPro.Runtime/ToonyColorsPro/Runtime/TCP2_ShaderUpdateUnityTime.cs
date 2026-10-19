using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ToonyColorsPro.Runtime
{
	[Token(Token = "0x2000009")]
	public class TCP2_ShaderUpdateUnityTime : MonoBehaviour
	{
		[Token(Token = "0x4000046")]
		private static readonly int UnityTime;

		[Token(Token = "0x4000047")]
		private static readonly int CustomTime;

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x819AEC8", Offset = "0x819AEC8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv67 = UnityEngine.Time::get_time();\n\tv70 = UnityEngine.Time::get_time();\n\tv73 = UnityEngine.Time::get_time();\n\tv75 = v64 / 20f;\n\tv76 = v70 + v70;\n\tv78 = v73 * 3f;\n\t// 69 MakeStruct v91 @ AGG819AFA0_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v75 @ V1_v2 (System.Single), v67 @ V0_v3 (System.Single), v76 @ V2_v1 (System.Single), v78 @ V3_v2 (System.Single)\n\tUnityEngine.Shader::SetGlobalVector(v61.CustomTime, v91);\n\treturn;\nL_001B:\n\tgoto L_0021;\nL_0021:\n\tv57 = UnityEngine.Time::get_time();\n\tUnityEngine.Shader::SetGlobalFloat(v54.UnityTime, v57);\n\tv64 = UnityEngine.Time::get_time();\n")]
		private void LateUpdate()
		{
			float time = Time.time;
			Shader.SetGlobalFloat(UnityTime, time);
			float time2 = Time.time;
			float time3 = Time.time;
			float time4 = Time.time;
			float time5 = Time.time;
			float x = time2 / 20f;
			float z = time4 + time4;
			float w = time5 * 3f;
			Vector4 value = default(Vector4);
			value.x = x;
			value.y = time3;
			value.z = z;
			value.w = w;
			Shader.SetGlobalVector(CustomTime, value);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x819AFA4", Offset = "0x819AFA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TCP2_ShaderUpdateUnityTime()
		{
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x819AFAC", Offset = "0x819AFAC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv50 = UnityEngine.Shader::PropertyToID(\"unityTime\");\n\tv55.UnityTime = v50;\n\tv58 = UnityEngine.Shader::PropertyToID(\"_CustomTime\");\n\tv62.CustomTime = v58;\n\treturn;\n")]
		static TCP2_ShaderUpdateUnityTime()
		{
			int unityTime = Shader.PropertyToID("unityTime");
			UnityTime = unityTime;
			int customTime = Shader.PropertyToID("_CustomTime");
			CustomTime = customTime;
		}
	}
}
