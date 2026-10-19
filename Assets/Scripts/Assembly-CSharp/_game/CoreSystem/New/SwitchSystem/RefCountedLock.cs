using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.SwitchSystem
{
	[Token(Token = "0x2000281")]
	public class RefCountedLock
	{
		[Token(Token = "0x40007F1")]
		[FieldOffset(Offset = "0x10")]
		private int _count;

		[Token(Token = "0x170000D4")]
		public bool IsLocked
		{
			[Token(Token = "0x6000B35")]
			[Address(RVA = "0x3EC4F90", Offset = "0x3EC4F90", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this._count < 0;\n\tv6 = this._count == 0;\n\tv8 = this._count ^ this._count;\n\tv9 = this._count & v8;\n\tv10 = v9 < 0;\n\tv11 = v5 == v10;\n\tv12 = ~v6;\n\tv13 = v11 & v12;\n\treturn v13;\n")]
			get
			{
				bool flag = _count < 0;
				bool flag2 = _count == 0;
				int num = _count ^ _count;
				int num2 = _count & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Token(Token = "0x6000B36")]
		[Address(RVA = "0x3EC4FA0", Offset = "0x3EC4FA0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturn v59;\nL_001C:\n\tv48 = this._count + 1;\n\tthis._count = v48;\n\tv50 = new System.Action();\n\tSystem.Action::.ctor(v50, this, Il2CppMethodInfo);\n")]
		public LockHandle Acquire()
		{
			int count = _count + 1;
			_count = count;
			Action action = delegate
			{
				int count2 = _count - 1;
				if (_count >= 1)
				{
					_count = count2;
				}
			};
			LockHandle result = default(LockHandle);
			return result;
		}

		[Token(Token = "0x6000B37")]
		[Address(RVA = "0x3EC5044", Offset = "0x3EC5044", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RefCountedLock()
		{
		}
	}
}
