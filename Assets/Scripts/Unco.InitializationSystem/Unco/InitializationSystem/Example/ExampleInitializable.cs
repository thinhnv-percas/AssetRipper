using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.InitializationSystem.Runtime;
using UnityEngine;

namespace Unco.InitializationSystem.Example
{
	[Token(Token = "0x2000012")]
	public class ExampleInitializable : MonoBehaviour, IInitializable
	{
		[Token(Token = "0x400001A")]
		public static ExampleInitializable Instance;

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81B1C28", Offset = "0x81B1C28", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.Instance = this;\n\treturn;\n")]
		private void Awake()
		{
			Instance = this;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81B1C84", Offset = "0x81B1C84", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.InitializationSystem.Runtime.Extensions::InitSystem(this);\n\treturn;\n")]
		public void InitializeMethod()
		{
			this.InitSystem();
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81B1C88", Offset = "0x81B1C88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ExampleInitializable()
		{
		}
	}
}
