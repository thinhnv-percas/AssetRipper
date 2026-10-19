using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.New.MoldSystem;

namespace _game.CoreSystem
{
	[Token(Token = "0x2000087")]
	public class HapticGameplayWiring : IDisposable
	{
		[Inject(true)]
		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x10")]
		private GameplayHapticController _haptic;

		[Inject(false)]
		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x18")]
		private MoldAbsorptionBridge _bridge;

		[Inject(true)]
		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x20")]
		private ConveyorController _conveyor;

		[Inject(false)]
		[Token(Token = "0x6000255")]
		[Address(RVA = "0x3C76744", Offset = "0x3C76744", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this._haptic == 0;\n\tif (v13) goto L_001C;\n\t_game.CoreSystem.GameplayHapticController::BindMoldEvents(this._haptic, this._bridge);\n\tv19 = this._haptic == 0;\n\tif (v19) goto L_001C;\n\t_game.CoreSystem.GameplayHapticController::BindConveyor(this._haptic, this._conveyor);\n\treturn;\nL_001C:\n\treturn;\n")]
		private void Construct()
		{
			if (_haptic != null)
			{
				_haptic.BindMoldEvents(_bridge);
				if (_haptic != null)
				{
					_haptic.BindConveyor(_conveyor);
				}
			}
		}

		[Token(Token = "0x6000256")]
		[Address(RVA = "0x3C76788", Offset = "0x3C76788", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this._haptic == 0;\n\tif (v13) goto L_001A;\n\t_game.CoreSystem.GameplayHapticController::UnbindMoldEvents(this._haptic);\n\tv16 = this._haptic == 0;\n\tif (v16) goto L_001A;\n\t_game.CoreSystem.GameplayHapticController::UnbindConveyor(this._haptic);\n\treturn;\nL_001A:\n\treturn;\n")]
		public void Dispose()
		{
			if (_haptic != null)
			{
				_haptic.UnbindMoldEvents();
				if (_haptic != null)
				{
					_haptic.UnbindConveyor();
				}
			}
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x3C756DC", Offset = "0x3C756DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HapticGameplayWiring()
		{
		}
	}
}
