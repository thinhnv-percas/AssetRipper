using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000018")]
	public class SetAllIn1VfxCustomGlobalTime : MonoBehaviour
	{
		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x20")]
		private int globalTime;

		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x24")]
		private Vector4 timeVector;

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3C285E0", Offset = "0x3C285E0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Shader::PropertyToID(\"globalCustomTime\");\n\tthis.globalTime = v46;\n\treturn;\n")]
		private void Start()
		{
			int num = Shader.PropertyToID("globalCustomTime");
			globalTime = num;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3C2863C", Offset = "0x3C2863C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_unscaledTime();\n\tv15 = v13 / 20f;\n\tthis.timeVector.x = v15;\n\tv17 = UnityEngine.Time::get_unscaledTime();\n\tthis.timeVector.y = v17;\n\tv19 = UnityEngine.Time::get_unscaledTime();\n\tv20 = v19 + v19;\n\tthis.timeVector.z = v20;\n\tv22 = UnityEngine.Time::get_unscaledTime();\n\tv24 = v22 * 3f;\n\tthis.timeVector.w = v24;\n\t// 34 MakeStruct v34 @ AGG3C286A8_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), this.timeVector (UnityEngine.Vector4), this.timeVector.y (System.Single), this.timeVector.z (System.Single), v24 @ V3_v1 (System.Single)\n\tUnityEngine.Shader::SetGlobalVector(this.globalTime, v34);\n\treturn;\n")]
		private void Update()
		{
			float unscaledTime = Time.unscaledTime;
			float x = unscaledTime / 20f;
			timeVector.x = x;
			float unscaledTime2 = Time.unscaledTime;
			timeVector.y = unscaledTime2;
			float unscaledTime3 = Time.unscaledTime;
			float z = unscaledTime3 + unscaledTime3;
			timeVector.z = z;
			float unscaledTime4 = Time.unscaledTime;
			float w = unscaledTime4 * 3f;
			timeVector.w = w;
			Vector4 value = default(Vector4);
			value.x = timeVector.x;
			value.y = timeVector.y;
			value.z = timeVector.z;
			value.w = w;
			Shader.SetGlobalVector(globalTime, value);
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x3C286AC", Offset = "0x3C286AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SetAllIn1VfxCustomGlobalTime()
		{
		}
	}
}
