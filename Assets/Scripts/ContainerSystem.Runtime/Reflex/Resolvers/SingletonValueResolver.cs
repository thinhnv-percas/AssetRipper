using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Enums;
using Reflex.Generics;

namespace Reflex.Resolvers
{
	[Token(Token = "0x2000015")]
	internal sealed class SingletonValueResolver : IResolver, IDisposable
	{
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x10")]
		private readonly object _value;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x18")]
		private readonly DisposableCollection _disposables;

		[Token(Token = "0x1700000D")]
		public Lifetime Lifetime
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x3F3128C", Offset = "0x3F3128C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return default(Lifetime);
			}
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x3F31294", Offset = "0x3F31294", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tSystem.Object::.ctor(v50);\n\tthis._disposables = v50;\n\tSystem.Object::.ctor(this);\n\tthis._value = value;\n\tv91 = this._disposables;\n\tgoto L_005E;\n\tSystem.Collections.Generic.Stack`1<System.IDisposable>::Push(v91._stack, v119);\n\treturn;\nL_007C:\n\treturn;\nL_001A:\n\tv50 = new Reflex.Generics.DisposableCollection();\n\tgoto L_002F;\nL_002F:\n\tv69 = new System.Collections.Generic.Stack`1<System.IDisposable>();\n\tSystem.Collections.Generic.Stack`1<System.IDisposable>::.ctor(v69);\n\tv50._stack = v69;\nL_005E:\n\tv119 = 0x21C11D0(value, System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv122 = v119 == 0;\n\tif (v122) goto L_007C;\n")]
		public SingletonValueResolver(object value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SingletonValueResolver::.ctor");
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x3F3149C", Offset = "0x3F3149C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._value;\n")]
		public object Resolve(Container container)
		{
			return _value;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x3F314A4", Offset = "0x3F314A4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tReflex.Generics.DisposableCollection::Dispose(this._disposables);\n\treturn;\n")]
		public void Dispose()
		{
			_disposables.Dispose();
		}
	}
}
