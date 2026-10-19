using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.EditMode
{
	[Token(Token = "0x20002CF")]
	public class EditorMoldFillDisplayCreator : MoldFillDisplayCreatorBase
	{
		[Token(Token = "0x6000C6F")]
		[Address(RVA = "0x3ED65D4", Offset = "0x3ED65D4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tUnityEngine.Object::set_hideFlags(v47, 4);\n\treturn v47;\nL_001B:\n\tv47 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v47, \"FillText\");\n")]
		protected override GameObject InstantiateTextGameObject()
		{
			GameObject gameObject = new GameObject("FillText");
			gameObject.hideFlags = HideFlags.DontSaveInEditor;
			return gameObject;
		}

		[Token(Token = "0x6000C70")]
		[Address(RVA = "0x3ED62D8", Offset = "0x3ED62D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public EditorMoldFillDisplayCreator()
		{
		}
	}
}
