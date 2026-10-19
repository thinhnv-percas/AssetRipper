using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000019")]
	public class SetGlobalTimeNew : MonoBehaviour
	{
		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x20")]
		private int globalTime;

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x3C24344", Offset = "0x3C24344", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Shader::PropertyToID(\"globalUnscaledTime\");\n\tthis.globalTime = v46;\n\treturn;\n")]
		private void Start()
		{
			int num = Shader.PropertyToID("globalUnscaledTime");
			globalTime = num;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x3C243A0", Offset = "0x3C243A0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_unscaledTime();\n\tv15 = v13 / 20f;\n\tUnityEngine.Shader::SetGlobalFloat(this.globalTime, v15);\n\treturn;\n")]
		private void Update()
		{
			float unscaledTime = Time.unscaledTime;
			float value = unscaledTime / 20f;
			Shader.SetGlobalFloat(globalTime, value);
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x3C243D4", Offset = "0x3C243D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SetGlobalTimeNew()
		{
		}
	}
}
