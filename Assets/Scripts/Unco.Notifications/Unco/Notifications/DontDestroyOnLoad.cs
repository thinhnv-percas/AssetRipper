using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Notifications
{
	[Token(Token = "0x2000018")]
	public class DontDestroyOnLoad : MonoBehaviour
	{
		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x81B9668", Offset = "0x81B9668", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB79A000;\n\tv18 = *([B79A001]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0026;\n\tv21 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v21;\n\tgoto L_001D;\nL_001D:\n\tUnityEngine.Object::DontDestroyOnLoad(v53);\n\treturn;\nL_0026:\n\t*([v14 @ X20_v1+1]) = 1;\n\tv49 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v49;\n\tgoto L_001D;\n")]
		private void Awake()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192520192;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B79A001]");
			Object target;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				GameObject gameObject = base.gameObject;
				target = gameObject;
			}
			else
			{
				_ = 1;
				GameObject gameObject2 = base.gameObject;
				target = gameObject2;
			}
			Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x81B970C", Offset = "0x81B970C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DontDestroyOnLoad()
		{
		}
	}
}
