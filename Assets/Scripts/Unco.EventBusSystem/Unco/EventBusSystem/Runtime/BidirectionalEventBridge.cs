using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.EventBusSystem.Runtime
{
	[Token(Token = "0x200000B")]
	public class BidirectionalEventBridge : IDisposable
	{
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x10")]
		private readonly EventBridge _forwardBridge;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x18")]
		private readonly EventBridge _reverseBridge;

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x81A8C00", Offset = "0x81A8C00", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tthis._forwardBridge = v53;\n\tv62 = new Unco.EventBusSystem.Runtime.EventBridge();\n\tUnco.EventBusSystem.Runtime.EventBridge::.ctor(v62, eventBusB, eventBusA);\n\tthis._reverseBridge = v62;\n\treturn;\nL_001C:\n\tSystem.Object::.ctor(this);\n\tv53 = new Unco.EventBusSystem.Runtime.EventBridge();\n\tUnco.EventBusSystem.Runtime.EventBridge::.ctor(v53, eventBusA, eventBusB);\n")]
		public BidirectionalEventBridge(EventBus eventBusA, EventBus eventBusB)
		{
			EventBridge forwardBridge = new EventBridge(eventBusA, eventBusB);
			_forwardBridge = forwardBridge;
			_reverseBridge = new EventBridge(eventBusB, eventBusA);
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x472F3D0", Offset = "0x472F3D0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = 0x220C2B8(methodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0014:\n\tv39 = Unco.EventBusSystem.Runtime.EventBridge::BridgeEvent(this._forwardBridge);\n\tv40 = Unco.EventBusSystem.Runtime.EventBridge::BridgeEvent(v40);\n\treturn;\n")]
		public void BridgeEvent<TEvent>() where TEvent : IEvent
		{
			_forwardBridge.BridgeEvent<TEvent>();
			EventBridge eventBridge = default(EventBridge);
			eventBridge.BridgeEvent<TEvent>();
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x472F430", Offset = "0x472F430", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = 0x220C2B8(methodInfo, v39, bToA, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0019:\n\tv48 = Unco.EventBusSystem.Runtime.EventBridge::BridgeEvent(this._forwardBridge, v39);\n\tv49 = Unco.EventBusSystem.Runtime.EventBridge::BridgeEvent(v49, bToA);\n\treturn;\n")]
		public void BridgeEvents<TEventA, TEventB>(Func<TEventA, TEventB> aToB, Func<TEventB, TEventA> bToA) where TEventA : IEvent where TEventB : IEvent
		{
			Func<TEventA, TEventB> converter = default(Func<TEventA, TEventB>);
			_forwardBridge.BridgeEvent(converter);
			EventBridge eventBridge = default(EventBridge);
			eventBridge.BridgeEvent(bToA);
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x81A8CB4", Offset = "0x81A8CB4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this._forwardBridge == 0;\n\tif (v13) goto L_000C;\n\tUnco.EventBusSystem.Runtime.EventBridge::Dispose(this._forwardBridge);\nL_000C:\n\tv16 = this._reverseBridge == 0;\n\tif (v16) goto L_001A;\n\tUnco.EventBusSystem.Runtime.EventBridge::Dispose(this._reverseBridge);\n\treturn;\nL_001A:\n\treturn;\n")]
		public void Dispose()
		{
			if (_forwardBridge != null)
			{
				_forwardBridge.Dispose();
			}
			if (_reverseBridge != null)
			{
				_reverseBridge.Dispose();
			}
		}
	}
}
