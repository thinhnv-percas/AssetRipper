using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreGameKit.UiControllers.ScriptableObjects
{
	[Serializable]
	[Token(Token = "0x2000023")]
	public class ConfigOrderPair
	{
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x10")]
		public UIConfig Config;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x18")]
		public int Order;

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x81A620C", Offset = "0x81A620C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Config = pair.Config;\n\tthis.Order = pair.Order;\n\treturn;\n")]
		public ConfigOrderPair(ConfigOrderPair pair)
		{
			Config = pair.Config;
			Order = pair.Order;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x81A610C", Offset = "0x81A610C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Config = config;\n\tthis.Order = order;\n\treturn;\n")]
		public ConfigOrderPair(UIConfig config, int order)
		{
			Config = config;
			Order = order;
		}
	}
}
