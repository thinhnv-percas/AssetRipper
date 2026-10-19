using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;

namespace Unco.CommonManagers
{
	[Token(Token = "0x2000009")]
	public class GameManager : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x6000025")]
		[Address(RVA = "0x81A85B4", Offset = "0x81A85B4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F3000 + 0xA20;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::Log(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		private void Inject()
		{
			//IL_0022: Expected O, but got I4
			int num = 187641856 + 2592;
			Debug.Log(num);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x81A8648", Offset = "0x81A8648", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public GameManager()
		{
		}
	}
}
