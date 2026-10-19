using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x200000D")]
	internal class FastAction : FastActionBase<Action>
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400000D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400000E")]
			public static Action<Action> _003C_003E9__0_0;

			[Token(Token = "0x6000030")]
			[Address(RVA = "0x3F1FB2C", Offset = "0x3F1FB2C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Coffee.UIParticleInternal.FastAction+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000031")]
			[Address(RVA = "0x3F1FB90", Offset = "0x3F1FB90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CInvoke_003Eb__0_0(Action action)
			{
				action();
			}
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x3F1F968", Offset = "0x3F1F968", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv95 = v49.<>9__0_0;\n\tv51 = v49.<>9__0_0 == 0;\n\tif (v51) goto L_0045;\nL_0026:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Invoke(this, v95);\n\treturn;\nL_0045:\n\tgoto L_004D;\n\tv150 = this == 0;\n\tv92 = ~v150;\n\tv95 = v125;\n\tif (v92) goto L_0026;\n\tthrow System.NullReferenceException;\nL_004D:\n\tv125 = new System.Action`1<System.Action>();\n\tSystem.Action`1<System.Action>::.ctor(v125, v120.<>9, Il2CppMethodInfo);\n\tv148.<>9__0_0 = v125;\n")]
		public void Invoke()
		{
			Action<Action> callback = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				Action<Action> action = (_003C_003Ec._003C_003E9__0_0 = delegate(Action action2)
				{
					action2();
				});
				bool flag = this == null;
				bool flag2 = !flag;
				callback = action;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			Invoke(callback);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x3F1FA88", Offset = "0x3F1FA88", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB2A9000 + 0xA28;\n\tgoto L_001F;\nL_001F:\n\tCoffee.UIParticleInternal.FastActionBase`1::.ctor /* +1 sharing this address */(this, *([v51 @ X21_v6 (System.Int32)]));\n\treturn;\n")]
		public FastAction()
		{
			int num = 187338752 + 2600;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @52A1E94 (Coffee.UIParticleInternal.FastActionBase`1::.ctor, and 1 more at this address)");
		}
	}
}
