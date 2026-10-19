using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.EventBusSystem.Runtime
{
	[Token(Token = "0x200000C")]
	public class EventBus : IDisposable
	{
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Dictionary<Type, Event> _events;

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x49624F4", Offset = "0x49624F4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv24 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v23 @ stack_-38_v6 (Unco.EventBusSystem.Runtime.Event`1<T>));\n\tv42 = ~v24;\n\tv43 = ~v42;\n\tif (v43) goto L_002D;\nL_001B:\n\treturn;\n\tv28 = 0x220C2B8(methodInfo, args, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv50 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v23 @ stack_-38_v6 (Unco.EventBusSystem.Runtime.Event`1<T>));\n\tv57 = ~v50;\n\tif (v57) goto L_001B;\nL_002D:\n\tUnco.EventBusSystem.Runtime.Event`1<T>::Invoke(v23, args);\n\treturn;\n")]
		public void InvokeEvent<T>(T args) where T : IEvent
		{
			if (TryGetEvent(out Event<T> e))
			{
				e.Invoke(args);
			}
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x4962168", Offset = "0x4962168", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000D;\nL_000D:\n\tv18 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v17 @ stack_-28_v6 (Unco.EventBusSystem.Runtime.Event`1<_game.CoreGameKit.Ui.UiControllers.UventHeartRefillCantAfford>));\n\tv37 = ~v18;\n\tv38 = ~v37;\n\tif (v38) goto L_0025;\nL_0016:\n\treturn;\n\tv22 = 0x220C2B8(methodInfo, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v17 @ stack_-28_v6 (Unco.EventBusSystem.Runtime.Event`1<_game.CoreGameKit.Ui.UiControllers.UventHeartRefillCantAfford>));\n\tv52 = ~v45;\n\tif (v52) goto L_0016;\nL_0025:\n\tv68 = System.Activator::CreateInstance();\n\tv77 = v68 & 0xFF;\n\tUnco.EventBusSystem.Runtime.Event`1<_game.CoreGameKit.Ui.UiControllers.UventHeartRefillCantAfford>::Invoke(v17, v77);\n\treturn;\n")]
		public void InvokeEvent<TArg>() where TArg : struct, IEvent
		{
			InvokeEvent(Activator.CreateInstance<TArg>());
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x4963EEC", Offset = "0x4963EEC", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tgoto L_0019;\nL_0019:\n\tv49 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v47 @ stack_-38_v6 (Unco.EventBusSystem.Runtime.Event`1<TArg>));\n\tv51 = v49 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_004A;\nL_0025:\n\tgoto L_0027;\nL_0027:\n\tv98 = new Il2CppClass<Unco.EventBusSystem.Runtime.Event`1<TArg>>();\n\tUnco.EventBusSystem.Runtime.Event`1<TArg>::.ctor(v98);\n\tgoto L_003A;\nL_003A:\n\tv109 = System.Type::GetTypeFromHandle(Il2CppClass<TArg>);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Unco.EventBusSystem.Runtime.Event>::set_Item(this._events, v109, v98);\nL_004A:\n\tUnco.EventBusSystem.Runtime.Event`1<TArg>::AddObserver(v98, observer);\n\treturn;\n\tv54 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv62 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v47 @ stack_-38_v6 (Unco.EventBusSystem.Runtime.Event`1<TArg>));\n\tv64 = v62 == 0;\n\tif (v64) goto L_0025;\n\tgoto L_004A;\n")]
		public void ListenEvent<TArg>(Action<TArg> observer) where TArg : IEvent
		{
			if (!TryGetEvent(out Event<TArg> e))
			{
				e = new Event<TArg>();
				_events[typeof(TArg)] = e;
			}
			e.AddObserver(observer);
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x4966A38", Offset = "0x4966A38", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv24 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v23 @ stack_-38_v6 (Unco.EventBusSystem.Runtime.Event`1<TArg>));\n\tv42 = ~v24;\n\tv43 = ~v42;\n\tif (v43) goto L_002D;\nL_001B:\n\treturn;\n\tv28 = 0x220C2B8(methodInfo, observer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv50 = Unco.EventBusSystem.Runtime.EventBus::TryGetEvent(this, &v23 @ stack_-38_v6 (Unco.EventBusSystem.Runtime.Event`1<TArg>));\n\tv57 = ~v50;\n\tif (v57) goto L_001B;\nL_002D:\n\tUnco.EventBusSystem.Runtime.Event`1<TArg>::RemoveObserver(v23, observer);\n\treturn;\n")]
		public void RemoveListener<TArg>(Action<TArg> observer) where TArg : IEvent
		{
			if (TryGetEvent(out Event<TArg> e))
			{
				e.RemoveObserver(observer);
			}
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x49681F8", Offset = "0x49681F8", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tgoto L_0019;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0019:\n\t*([e @ X1 (Unco.EventBusSystem.Runtime.Event`1<TArg>&)]) = 0;\n\tgoto L_002A;\nL_002A:\n\tv64 = System.Type::GetTypeFromHandle(Il2CppClass<TArg>);\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.Type, Unco.EventBusSystem.Runtime.Event>::TryGetValue(this._events, v64, &v71 @ stack_-38_v2 (Unco.EventBusSystem.Runtime.Event));\n\tv75 = ~returnVal2;\n\tif (v75) goto L_00A5;\n\tgoto L_0041;\nL_0041:\n\tv164 = v71 == 0;\n\tif (v164) goto L_0051;\n\tgoto L_FFFFFFFF;\nL_0051:\n\t*([e @ X1 (Unco.EventBusSystem.Runtime.Event`1<TArg>&)]) = 0;\n\tgoto L_005B;\nL_005B:\n\tv127 = v71 == 0;\n\tif (v127) goto L_006B;\n\tgoto L_FFFFFFFF;\nL_006B:\n\tgoto L_00A5;\nL_FFFFFFFF:\n\t// -1 IsInst v209_asT @ TEMPCSEL_v6 (Unco.EventBusSystem.Runtime.Event`1<TArg>), typeof(Unco.EventBusSystem.Runtime.Event`1<TArg>), v71 @ stack_-38_v2 (Unco.EventBusSystem.Runtime.Event)\n\tv209 = v209_asT == 0;\n\tif (v209) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv270 = v71;\n\tgoto L_007F;\nL_FFFFFFFF:\n\tv270 = 0;\nL_0087:\n\tgoto L_005B;\nL_FFFFFFFF:\n\t// -1 IsInst v287_asT @ TEMPCSEL_v4 (Unco.EventBusSystem.Runtime.Event`1<TArg>), typeof(Unco.EventBusSystem.Runtime.Event`1<TArg>), v71 @ stack_-38_v2 (Unco.EventBusSystem.Runtime.Event)\n\tv287 = v287_asT == 0;\n\tif (v287) goto L_00A5;\n\tgoto L_00A5;\nL_00A5:\n\treturn returnVal2;\nL_007F:\n\t*([e @ X1 (Unco.EventBusSystem.Runtime.Event`1<TArg>&)]) = v270;\n\tgoto L_0087;\n")]
		private bool TryGetEvent<TArg>(out Event<TArg> e) where TArg : IEvent
		{
			if (_events.TryGetValue(typeof(TArg), out var value))
			{
				e = value as Event<TArg>;
				return true;
			}
			e = null;
			return false;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x81A8CF0", Offset = "0x81A8CF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Dispose()
		{
			_events.Clear();
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x81A8CF4", Offset = "0x81A8CF4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.Type, Unco.EventBusSystem.Runtime.Event>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Unco.EventBusSystem.Runtime.Event>::.ctor(v48);\n\tthis._events = v48;\n")]
		public EventBus()
		{
			Dictionary<Type, Event> events = new Dictionary<Type, Event>();
			_events = events;
		}
	}
}
