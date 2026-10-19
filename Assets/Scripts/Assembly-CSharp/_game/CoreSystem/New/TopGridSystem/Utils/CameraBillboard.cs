using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Utils
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000134")]
	public class CameraBillboard : MonoBehaviour
	{
		[Token(Token = "0x6000627")]
		[Address(RVA = "0x3DB28E4", Offset = "0x3DB28E4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB78E000;\n\tv20 = *([B78E086]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_002A;\n\tv23 = UnityEngine.Camera::get_main();\n\tv91 = v23;\n\tgoto L_001A;\nL_001A:\n\tv60 = UnityEngine.Object::op_Equality(v91, 0);\n\tv68 = v60 == 0;\n\tif (v68) goto L_003E;\n\treturn;\nL_002A:\n\t*([v16 @ X20_v1+86]) = 1;\n\tv48 = UnityEngine.Camera::get_main();\n\tv91 = v48;\n\tgoto L_001A;\nL_003E:\n\tv94 = UnityEngine.Component::get_transform(this);\n\tv140 = UnityEngine.Component::get_transform(v91);\n\tv110 = UnityEngine.Transform::get_rotation(v140);\n\tUnityEngine.Transform::set_rotation(v94, v110);\n\treturn;\n")]
		private void Start()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E086]");
			Camera camera;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Camera main = Camera.main;
				camera = main;
			}
			else
			{
				_ = 1;
				Camera main2 = Camera.main;
				camera = main2;
			}
			if (!(camera == null))
			{
				Transform transform = base.transform;
				Transform transform2 = camera.transform;
				Quaternion rotation = transform2.rotation;
				transform.rotation = rotation;
			}
		}

		[Token(Token = "0x6000628")]
		[Address(RVA = "0x3DB29D8", Offset = "0x3DB29D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CameraBillboard()
		{
		}
	}
}
