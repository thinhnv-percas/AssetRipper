using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.PlayMode
{
	[Token(Token = "0x20002CB")]
	public class RuntimeMoldFillDisplayCreator : MoldFillDisplayCreatorBase
	{
		[Token(Token = "0x6000C65")]
		[Address(RVA = "0x3ED5DE8", Offset = "0x3ED5DE8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv47 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v47, \"FillText\");\n\treturn v47;\n")]
		protected override GameObject InstantiateTextGameObject()
		{
			return new GameObject("FillText");
		}

		[Token(Token = "0x6000C66")]
		[Address(RVA = "0x3ED5860", Offset = "0x3ED5860", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RuntimeMoldFillDisplayCreator()
		{
		}
	}
}
