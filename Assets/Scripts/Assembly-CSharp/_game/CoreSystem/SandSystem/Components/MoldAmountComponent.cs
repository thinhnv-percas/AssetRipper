using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000097")]
	public class MoldAmountComponent : ICellComponent
	{
		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x10")]
		public float amount;

		[Token(Token = "0x600028D")]
		[Address(RVA = "0x3C79D0C", Offset = "0x3C79D0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldAmountComponent()
		{
		}
	}
}
