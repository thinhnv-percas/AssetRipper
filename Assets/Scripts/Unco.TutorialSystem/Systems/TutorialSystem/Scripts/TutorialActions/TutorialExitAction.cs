using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.TutorialSystem.Scripts.TutorialActions
{
	[Serializable]
	[Token(Token = "0x200001D")]
	public class TutorialExitAction
	{
		[Token(Token = "0x6000091")]
		[Address(RVA = "0x81E2E80", Offset = "0x81E2E80", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Apply()
		{
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x81E2E84", Offset = "0x81E2E84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TutorialExitAction()
		{
		}
	}
}
