using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.UiControllers
{
	[RequireComponent(typeof(Canvas))]
	[Token(Token = "0x2000018")]
	public class CanvasCameraSetter : MonoBehaviour
	{
		[Token(Token = "0x6000091")]
		[Address(RVA = "0x81A56B0", Offset = "0x81A56B0", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB799000;\n\tv20 = *([B799F34]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0047;\n\tv23 = UnityEngine.Camera::get_main();\n\tv92 = v23;\n\tgoto L_001A;\nL_001A:\n\tv60 = UnityEngine.Object::op_Equality(v92, 0);\n\tv69 = ~v60;\n\tif (v69) goto L_005C;\n\tv86 = UnityEngine.Component::get_gameObject(this);\n\tv106 = UnityEngine.Object::get_name(v86);\n\tv127 = System.String::Concat(\"[CanvasCameraSetter] Main camera not found on \", v106);\n\tgoto L_0038;\nL_0038:\n\tUnityEngine.Debug::LogWarning(v127);\n\treturn;\nL_0047:\n\t*([v16 @ X20_v1+F34]) = 1;\n\tv101 = UnityEngine.Camera::get_main();\n\tv92 = v101;\n\tgoto L_001A;\nL_005C:\n\tv97 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.Canvas::set_worldCamera(v97, v92);\n\treturn;\n")]
		private void Start()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192516096;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799F34]");
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
			if (camera == null)
			{
				GameObject gameObject = base.gameObject;
				string text = gameObject.name;
				string message = "[CanvasCameraSetter] Main camera not found on " + text;
				Debug.LogWarning(message);
			}
			else
			{
				Canvas component = GetComponent<Canvas>();
				component.worldCamera = camera;
			}
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x81A581C", Offset = "0x81A581C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CanvasCameraSetter()
		{
		}
	}
}
