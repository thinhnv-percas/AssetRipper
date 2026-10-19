using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Enums;
using Reflex.Generics;
using Unco.ContainerSystem.Runtime;

namespace Reflex.Resolvers
{
	[Token(Token = "0x2000013")]
	internal sealed class ScopedFactoryResolver : IResolver, IDisposable
	{
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x10")]
		private readonly Func<Instancer, object> _factory;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x18")]
		private readonly ConditionalWeakTable<Container, object> _instances;

		[Token(Token = "0x1700000B")]
		public Lifetime Lifetime
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x3F30CC4", Offset = "0x3F30CC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 2;\n")]
			get
			{
				return Lifetime.Scoped;
			}
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x3F30CCC", Offset = "0x3F30CCC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tSystem.Object::.ctor(this);\n\tthis._factory = factory;\n\treturn;\nL_001F:\n\tv53 = new System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, System.Object>();\n\tSystem.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, System.Object>::.ctor(v53);\n\tthis._instances = v53;\n")]
		public ScopedFactoryResolver(Func<Instancer, object> factory)
		{
			ConditionalWeakTable<Container, object> instances = new ConditionalWeakTable<Container, object>();
			_instances = instances;
			_factory = factory;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x3F30D74", Offset = "0x3F30D74", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, System.Object>::TryGetValue(this._instances, container, &v54 @ stack_-38_v3 (System.Object));\n\tv97 = v56 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_006B;\n\tv74 = Reflex.Core.Container::Resolve(container);\n\tv142 = System.Func`2<Unco.ContainerSystem.Runtime.Instancer, System.Object>::Invoke(this._factory, v74);\n\tSystem.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, System.Object>::Add(this._instances, container, v142);\n\tv90 = container.<Disposables>k__BackingField;\n\tgoto L_0058;\n\tSystem.Collections.Generic.Stack`1<System.IDisposable>::Push(v90._stack, v108);\n\tv54 = v142;\nL_006B:\n\treturn v54;\nL_0058:\n\tv108 = 0x21C11D0(v142, System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv110 = v108 == 0;\n\tv54 = v142;\n\tif (v110) goto L_006B;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public object Resolve(Container container)
		{
			if (!_instances.TryGetValue(container, out var value))
			{
				Instancer arg = container.Resolve<Instancer>();
				object obj = _factory(arg);
				_instances.Add(container, obj);
				DisposableCollection disposableCollection = container.Disposables;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				IDisposable disposable = default(IDisposable);
				bool flag = disposable == null;
				value = obj;
				if (!flag)
				{
					disposableCollection._stack.Push(disposable);
					value = obj;
				}
			}
			return value;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x3F30F68", Offset = "0x3F30F68", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Dispose()
		{
		}
	}
}
