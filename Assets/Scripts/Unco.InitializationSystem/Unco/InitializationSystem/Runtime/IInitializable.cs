using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[Token(Token = "0x2000005")]
	public interface IInitializable
	{
		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81AFF30", Offset = "0x81AFF30", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tUnco.InitializationSystem.Runtime.InitializationManager::Initialize(this);\n\treturn;\n")]
		void InitializeSystem()
		{
			InitializationManager.Initialize(this);
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81B0234", Offset = "0x81B0234", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tUnco.InitializationSystem.Runtime.InitializationManager::DeInitialize(this);\n\treturn;\n")]
		void DeInitialize()
		{
			InitializationManager.DeInitialize(this);
		}
	}
}
