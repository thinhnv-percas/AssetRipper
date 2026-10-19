using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PlayReport
{
	[Token(Token = "0x2000354")]
	public sealed class WinPollLatch
	{
		[Token(Token = "0x40009C8")]
		[FieldOffset(Offset = "0x10")]
		private readonly float _intervalSeconds;

		[Token(Token = "0x40009C9")]
		[FieldOffset(Offset = "0x14")]
		private float _accumulator;

		[Token(Token = "0x40009CA")]
		[FieldOffset(Offset = "0x18")]
		private bool _fired;

		[Token(Token = "0x6000DF5")]
		[Address(RVA = "0x3F00C68", Offset = "0x3F00C68", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._intervalSeconds = intervalSeconds;\n\treturn;\n")]
		public WinPollLatch(float intervalSeconds)
		{
			_intervalSeconds = intervalSeconds;
		}

		[Token(Token = "0x6000DF6")]
		[Address(RVA = "0x3F00C9C", Offset = "0x3F00C9C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this._fired == 0;\n\tif (v13) goto L_0013;\n\treturnVal1 = 0;\nL_0013:\n\tv17 = this._accumulator + deltaSeconds;\n\tthis._accumulator = v17;\n\tv19 = v17 < this._intervalSeconds;\n\tv27 = ~v19;\n\tif (v27) goto L_0026;\n\treturn 0;\nL_0026:\n\tthis._accumulator = 0f;\n\treturnVal1 = System.Func`1<System.Boolean>::Invoke(isWon);\n\tv55 = ~returnVal1;\n\tif (v55) goto L_0010;\n\tthis._fired = 1;\n\treturn 1;\nL_0010:\n\treturn returnVal1;\n")]
		public bool Tick(float deltaSeconds, Func<bool> isWon)
		{
			bool flag;
			if (_fired)
			{
				flag = false;
			}
			else
			{
				if ((_accumulator += deltaSeconds) < _intervalSeconds)
				{
					return false;
				}
				_accumulator = 0f;
				flag = isWon();
				if (flag)
				{
					_fired = true;
					return true;
				}
			}
			return flag;
		}
	}
}
