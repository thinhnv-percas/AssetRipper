using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace Reflex.Exceptions
{
	[Token(Token = "0x2000030")]
	public class SceneHasMultipleSceneScopesException : Exception
	{
		[Token(Token = "0x6000085")]
		[Address(RVA = "0x3F35420", Offset = "0x3F35420", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_003E:\n\tSystem.Exception::.ctor(this, v75);\n\treturn;\nL_0019:\n\tv49 = scene;\n\tgoto L_002E;\nL_002E:\n\tv68 = UnityEngine.SceneManagement.Scene::get_name(&v49 @ stack_-44_v1 (UnityEngine.SceneManagement.Scene));\n\tv75 = System.String::Concat(\"Scene '\", v68, \"' has multiple SceneScope instances. None or only one SceneScope is allowed per scene.\");\n\tgoto L_003E;\n")]
		public SceneHasMultipleSceneScopesException(Scene scene)
		{
			Scene scene2 = scene;
			string name = scene2.name;
			string message = "Scene '" + name + "' has multiple SceneScope instances. None or only one SceneScope is allowed per scene.";
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x3F35504", Offset = "0x3F35504", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = scene;\n\tgoto L_001D;\nL_001D:\n\tv49 = UnityEngine.SceneManagement.Scene::get_name(&v14 @ stack_-34_v1 (UnityEngine.SceneManagement.Scene));\n\treturnVal1 = System.String::Concat(\"Scene '\", v49, \"' has multiple SceneScope instances. None or only one SceneScope is allowed per scene.\");\n\treturn returnVal1;\n")]
		private static string GenerateMessage(Scene scene)
		{
			Scene scene2 = scene;
			string name = scene2.name;
			return "Scene '" + name + "' has multiple SceneScope instances. None or only one SceneScope is allowed per scene.";
		}
	}
}
