using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Utils;
using UnityEngine;

namespace Morpeh.Globals
{
	[CreateAssetMenu]
	[Token(Token = "0x2000024")]
	public class GlobalEventSceneReference : BaseGlobalEvent<SceneReference>
	{
		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x15F7B18", Offset = "0x15F7B18", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0D468]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, level, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A058]) = v41;\nL_0018:\n\tv45 = new Morpeh.Utils.SceneReference();\n\tMorpeh.Utils.SceneReference::.ctor(v45);\n\tv45.scenePath = level;\n\tMorpeh.Globals.BaseGlobalEvent`1<Morpeh.Utils.SceneReference>::Publish(this, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Publish(string level)
		{
			SceneReference sceneReference = new SceneReference();
			sceneReference.ScenePath = level;
			base.Publish(sceneReference);
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x15F7C00", Offset = "0x15F7C00", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0CDB8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A059]) = v38;\nL_001C:\n\tMorpeh.Globals.BaseGlobalEvent`1<Morpeh.Utils.SceneReference>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalEventSceneReference()
		{
		}
	}
}
