using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Objects;
using UnityEngine;

namespace _game.CoreGameKit.UiControllers.ScriptableObjects
{
	[CreateAssetMenu(fileName = "BaseUIConfig", menuName = "PowerSlap/UI/BaseUIConfig", order = 0)]
	[Token(Token = "0x200001F")]
	public class BaseUIConfig : ScriptableDatabase<BaseUIConfig>
	{
		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x18")]
		public List<UIConfig> UIConfigList;

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x81A6004", Offset = "0x81A6004", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tUnco.Objects.ScriptableDatabase`1<_game.CoreGameKit.UiControllers.ScriptableObjects.BaseUIConfig>::.ctor(this);\n\treturn;\n")]
		public BaseUIConfig()
		{
		}
	}
}
