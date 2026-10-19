using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Enums;
using Unco.ContainerSystem.Runtime;

namespace Reflex.Resolvers
{
	[Token(Token = "0x2000014")]
	internal sealed class SingletonFactoryResolver : IResolver, IDisposable
	{
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Func<Instancer, object> _factory;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x18")]
		internal readonly object _lock;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x20")]
		private object _instance;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x28")]
		private bool _isResolved;

		[Token(Token = "0x1700000C")]
		public Lifetime Lifetime
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x3F30F6C", Offset = "0x3F30F6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return default(Lifetime);
			}
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x3F30F74", Offset = "0x3F30F74", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tSystem.Object::.ctor(this);\n\tthis._factory = factory;\n\treturn;\nL_0018:\n\tv46 = new System.Object();\n\tSystem.Object::.ctor(v46);\n\tthis._lock = v46;\n")]
		public SingletonFactoryResolver(Func<Instancer, object> factory)
		{
			object obj = new object();
			_lock = obj;
			_factory = factory;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x3F31000", Offset = "0x3F31000", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv48 = this._lock;\n\tv49 = 0;\n\tSystem.Threading.Monitor::Enter(this._lock, &v49 @ stack_-39_v3 (System.Boolean));\n\tv126 = this._isResolved == 0;\n\tif (v126) goto L_0039;\n\tv251 = this._instance;\n\tv165 = v49.m_value == 1;\n\tv249 = 0;\n\tv259 = 4;\n\tv262 = 0;\n\tif (v165) goto L_005F;\n\tv249 = 0;\n\treturnVal1 = this._instance;\n\tv120 = 4;\n\tv122 = 0;\n\tgoto L_0066;\nL_0039:\n\tv170 = container == 0;\n\tv249 = 0;\n\tif (v170) goto L_0081;\n\tv274 = Reflex.Core.Container::Resolve(container);\n\tv304 = System.Func`2<Unco.ContainerSystem.Runtime.Instancer, System.Object>::Invoke(this._factory, v274);\n\tthis._instance = v304;\n\tthis._isResolved = 1;\n\tv218 = v49.m_value != 1;\n\tv249 = 0;\n\tv251 = 0;\n\tv259 = 5;\n\tv262 = 0;\n\tv249 = 0;\n\treturnVal1 = 0;\n\tv120 = 5;\n\tv122 = 0;\n\tif (v218) goto L_0066;\nL_005F:\n\tv265 = &v48 @ stack_-38_v3 (System.Object);\n\tSystem.Threading.Monitor::Exit(*([v265 @ X8_v15]));\n\treturnVal1 = v251;\n\tv120 = v259;\n\tv122 = v262;\n\tv116 = v120 == 0;\n\tif (v116) goto L_0076;\n\tv60 = v120 != 5;\n\tif (v60) goto L_007E;\nL_0076:\n\treturnVal1 = this._instance;\nL_0080:\n\tv290 = new System.OutOfMemoryException();\nL_0081:\n\tv296 = new System.NullReferenceException();\n\tv249 = 0;\n\tgoto L_0084;\nL_0084:\n\t// 132 Interrupt\n\tgoto L_0093;\nL_0093:\n\tv175 = v274 != 1;\n\tif (v175) goto L_00AB;\n\tv326 = 0x8BF5BC4(v318, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv262 = *([v326 @ X0_v16]);\n\tv329 = 0x8BF5BF4(v326, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv332 = &v49 @ stack_-39_v3 (System.Boolean);\n\tv235 = *([v332 @ X8_v11]) == 1;\n\tv249 = *([v326 @ X0_v16]);\n\tv251 = 0;\n\tv259 = 0;\n\tif (v235) goto L_005F;\n\tv249 = *([v326 @ X0_v16]);\n\treturnVal1 = 0;\n\tv120 = 0;\n\tv122 = *([v326 @ X0_v16]);\n\tgoto L_0066;\n\treturn returnVal2;\nL_0017:\n\tv45 = this._isResolved == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0076;\nL_0066:\n\tv299 = v122 == 0;\n\tv292 = ~v299;\n\tif (v292) goto L_0080;\nL_007E:\n\treturn returnVal1;\nL_00AB:\n\tv328 = 0x3173B6C(&v249 @ stack_-58_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv331 = 0x8BF0368(v318, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v331, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe object Resolve(Container container)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SingletonFactoryResolver::Resolve");
			return default;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x3F311BC", Offset = "0x3F311BC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_0048;\nL_001A:\n\tv48 = 0x21C11D0(this._instance, System.IDisposable, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv49 = v48 == 0;\n\tif (v49) goto L_0049;\nL_0049:\n\tthis._instance = 0;\n\tthis._isResolved = 0;\n\treturn;\nL_0048:\n\tv98 = System.IDisposable::Dispose(0);\n")]
		public void Dispose()
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			object obj = default(object);
			if (obj != null)
			{
				((IDisposable)null).Dispose();
			}
			_instance = null;
			_isResolved = false;
		}
	}
}
