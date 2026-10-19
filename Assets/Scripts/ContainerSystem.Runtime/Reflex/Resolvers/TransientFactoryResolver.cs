using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Enums;
using Reflex.Generics;
using Unco.ContainerSystem.Runtime;

namespace Reflex.Resolvers
{
	[Token(Token = "0x2000016")]
	internal sealed class TransientFactoryResolver : IResolver, IDisposable
	{
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x10")]
		private readonly Func<Instancer, object> _factory;

		[Token(Token = "0x1700000E")]
		public Lifetime Lifetime
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x3F315C4", Offset = "0x3F315C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
			get
			{
				return Lifetime.Transient;
			}
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3F315CC", Offset = "0x3F315CC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._factory = factory;\n\treturn;\n")]
		public TransientFactoryResolver(Func<Instancer, object> factory)
		{
			_factory = factory;
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x3F31600", Offset = "0x3F31600", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv48 = Reflex.Core.Container::Resolve(container);\n\tv60 = System.Func`2<Unco.ContainerSystem.Runtime.Instancer, System.Object>::Invoke(this._factory, v48);\n\tv74 = container.<Disposables>k__BackingField;\n\tgoto L_003A;\n\tSystem.Collections.Generic.Stack`1<System.IDisposable>::Push(v74._stack, v113);\nL_004D:\n\treturn v60;\nL_003A:\n\tv113 = 0x21C11D0(v60, System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv116 = v113 == 0;\n\tif (v116) goto L_004D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public object Resolve(Container container)
		{
			Instancer arg = container.Resolve<Instancer>();
			object result = _factory(arg);
			DisposableCollection disposableCollection = container.Disposables;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			IDisposable disposable = default(IDisposable);
			if (disposable != null)
			{
				disposableCollection._stack.Push(disposable);
			}
			return result;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x3F316F0", Offset = "0x3F316F0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Dispose()
		{
		}
	}
}
