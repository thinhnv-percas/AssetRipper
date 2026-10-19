using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000012")]
	public class CameraUiFactory : UIFactory
	{
		[Token(Token = "0x6000065")]
		[Address(RVA = "0x81A5598", Offset = "0x81A5598", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.LocationData>();\n\tSystem.Collections.Generic.List`1<_game.CoreGameKit.UiControllers.LocationData>::.ctor(v48);\n\tthis.LocationDataList = v48;\n")]
		public CameraUiFactory()
		{
			List<LocationData> locationDataList = new List<LocationData>();
			LocationDataList = locationDataList;
		}
	}
}
