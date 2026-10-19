using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	[Token(Token = "0x200001A")]
	public class SetGlobalTimeUnity2018 : MonoBehaviour
	{
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x20")]
		private int globalTime;

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x3C243DC", Offset = "0x3C243DC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Shader::PropertyToID(\"globalUnscaledTime\");\n\tthis.globalTime = v46;\n\treturn;\n")]
		private void Start()
		{
			int num = Shader.PropertyToID("globalUnscaledTime");
			globalTime = num;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x3C24438", Offset = "0x3C24438", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_time();\n\tv15 = v13 / 20f;\n\tUnityEngine.Shader::SetGlobalFloat(this.globalTime, v15);\n\treturn;\n")]
		private void Update()
		{
			float time = Time.time;
			float value = time / 20f;
			Shader.SetGlobalFloat(globalTime, value);
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x3C2446C", Offset = "0x3C2446C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SetGlobalTimeUnity2018()
		{
		}
	}
}
