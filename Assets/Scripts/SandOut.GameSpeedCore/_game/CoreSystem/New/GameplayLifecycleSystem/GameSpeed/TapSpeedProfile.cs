using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Serializable]
	[Token(Token = "0x2000007")]
	public class TapSpeedProfile : SpeedProfile
	{
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x1C")]
		public bool enabled;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x20")]
		public int unlockLevel;

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x7AF159C", Offset = "0x7AF159C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.enabled = 1;\n\tthis.conveyor = 0f;\n\tthis.mold = 1f;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TapSpeedProfile()
		{
			enabled = true;
			conveyor = 0f;
			mold = 1f;
		}
	}
}
