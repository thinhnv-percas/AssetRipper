using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.InitializationSystem.Runtime;
using UnityEngine;

namespace Unco.InitializationSystem.Example
{
	[Token(Token = "0x2000014")]
	public class SecondExampleInitializable : MonoBehaviour, IInitializable
	{
		[Token(Token = "0x400001B")]
		public static SecondExampleInitializable Instance;

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x81B203C", Offset = "0x81B203C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.Instance = this;\n\treturn;\n")]
		private void Awake()
		{
			Instance = this;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x81B2030", Offset = "0x81B2030", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.InitializationSystem.Runtime.Extensions::InitSystem(this);\n\treturn;\n")]
		public void InitializeMethod()
		{
			this.InitSystem();
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x81B2098", Offset = "0x81B2098", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SecondExampleInitializable()
		{
		}
	}
}
