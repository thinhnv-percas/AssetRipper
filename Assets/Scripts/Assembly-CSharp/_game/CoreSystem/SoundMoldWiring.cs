using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreSystem.New.MoldSystem;

namespace _game.CoreSystem
{
	[Token(Token = "0x2000088")]
	public class SoundMoldWiring : IDisposable
	{
		[Inject(true)]
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x10")]
		private GameplaySoundController _sound;

		[Inject(false)]
		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x18")]
		private MoldAbsorptionBridge _bridge;

		[Inject(false)]
		[Token(Token = "0x6000258")]
		[Address(RVA = "0x3C767C4", Offset = "0x3C767C4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._sound == 0;\n\tif (v3) goto L_0007;\n\t_game.CoreSystem.GameplaySoundController::BindMoldEvents(this._sound, this._bridge);\n\treturn;\nL_0007:\n\treturn;\n")]
		private void Construct()
		{
			if (_sound != null)
			{
				_sound.BindMoldEvents(_bridge);
			}
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0x3C767DC", Offset = "0x3C767DC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._sound == 0;\n\tif (v2) goto L_0005;\n\t_game.CoreSystem.GameplaySoundController::UnbindMoldEvents(this._sound);\n\treturn;\nL_0005:\n\treturn;\n")]
		public void Dispose()
		{
			if (_sound != null)
			{
				_sound.UnbindMoldEvents();
			}
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0x3C7564C", Offset = "0x3C7564C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SoundMoldWiring()
		{
		}
	}
}
