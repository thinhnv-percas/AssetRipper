using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.EventBusSystem.Runtime
{
	[Token(Token = "0x2000005")]
	public class Event<T> : Event where T : IEvent
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<Action<T>> _observers;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x0")]
		private bool _isInvoking;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<Action<T>> _pendingRemovals;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<Action<T>> _pendingAdd;

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x525813C", Offset = "0x525813C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this._isInvoking != 1;\n\tif (v17) goto L_0015;\n\tv24 = this._pendingAdd;\n\tv19 = this._pendingAdd == 0;\n\tv20 = ~v19;\n\tif (v20) goto L_001C;\n\tgoto L_0040;\nL_0015:\n\tv24 = this._observers;\nL_001C:\n\t;\n\tgoto L_003E;\nL_003E:\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::Add(v24, observer);\n\treturn;\nL_0040:\n\tthrow System.NullReferenceException;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddObserver(Action<T> observer)
		{
			List<Action<T>> list;
			if (_isInvoking)
			{
				list = _pendingAdd;
			}
			else
			{
				list = _observers;
			}
			list.Add(observer);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x52581C4", Offset = "0x52581C4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this._isInvoking != 1;\n\tif (v17) goto L_003C;\n\tv18 = this._pendingRemovals;\n\tgoto L_0044;\nL_003C:\n\tv55 = System.Collections.Generic.List`1<System.Action`1<T>>::Remove(this._observers, observer);\n\treturn;\nL_0044:\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::Add(v18, observer);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveObserver(Action<T> observer)
		{
			if (_isInvoking)
			{
				List<Action<T>> pendingRemovals = _pendingRemovals;
				pendingRemovals.Add(observer);
			}
			else
			{
				bool flag = _observers.Remove(observer);
			}
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x525825C", Offset = "0x525825C", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._isInvoking = 1;\n\tv23 = this._observers == 0;\n\tif (v23) goto L_0126;\n\tv31 = System.Collections.Generic.List`1<System.Action`1<T>>::GetEnumerator(this._observers);\n\tv222 = v31._list;\n\tv239 = v31.Current == 0;\n\tif (v239) goto L_0028;\n\tSystem.Action`1<T>::Invoke(v31.Current, v159);\n\tgoto L_0028;\nL_003C:\n\tv269 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv271 = *([v269 @ X8_v65]);\n\tv272 = *([v271 @ X8_v66+20]);\n\tv273 = *([v272 @ X8_v67+C0]);\n\tv159 = *([v273 @ X8_v68+60]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>));\n\tv104 = 5;\n\tv133 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv145 = &v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>);\n\tv30 = 0;\n\tv30 = 0;\n\tgoto L_0187;\nL_0049:\n\tv82 = v104 == 5;\n\tif (v82) goto L_0052;\n\tv381 = v104 == 0;\n\tv382 = ~v381;\n\tif (v382) goto L_0121;\nL_0052:\n\tthis._isInvoking = 0;\n\tv172 = this._pendingRemovals == 0;\n\tif (v172) goto L_0126;\n\tv440 = &v30 @ stack_-68 (System.Int32);\n\tv441 = System.Collections.Generic.List`1<System.Action`1<T>>::GetEnumerator(this._pendingRemovals);\n\tv222 = v30.m_value;\n\tv491 = System.Collections.Generic.List`1<System.Action`1<T>>::Remove(this._observers, *([v440 @ X8_v14+10]));\n\tgoto L_0070;\nL_0080:\n\tv503 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv504 = *([v503 @ X8_v23]);\n\tv505 = *([v504 @ X8_v24+20]);\n\tv185 = *([v505 @ X8_v25+C0]);\n\tv159 = *([v185 @ X8_v26+60]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>));\n\tv30 = 0;\n\tgoto L_0187;\n\tv173 = this._pendingAdd == 0;\n\tv133 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv145 = &v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>);\n\tv30 = 0;\n\tif (v173) goto L_0126;\n\tv521 = System.Collections.Generic.List`1<System.Action`1<T>>::GetEnumerator(this._pendingAdd);\n\tv222 = v521._list;\n\tgoto L_00AB;\nL_00A5:\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::Add(this._observers, v521.Current);\nL_00AB:\n\tv556 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>));\n\tv558 = v556 == 0;\n\tif (v558) goto L_00D4;\n\tv546 = this._observers;\n\tv559 = this._observers == 0;\n\tif (v559) goto L_0122;\n\tv568 = v546._version + 1;\n\tv546._version = v568;\n\tv544 = v546._items == 0;\n\tif (v544) goto L_0122;\n\tgoto L_00A5;\nL_00D4:\n\tv560 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv561 = *([v560 @ X8_v38]);\n\tv562 = *([v561 @ X8_v39+20]);\n\tv377 = *([v562 @ X8_v40+C0]);\n\tv159 = *([v377 @ X8_v41+60]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>));\n\tv30 = 0;\n\tgoto L_0187;\n\tgoto L_00EA;\n\tgoto L_0121;\nL_00EA:\n\tv186 = this._pendingAdd;\n\tv174 = this._pendingAdd == 0;\n\tv133 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv145 = &v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>);\n\tv30 = 0;\n\tif (v174) goto L_0126;\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::Clear(v186);\n\tv39 = v186.Count < 1;\n\tv164 = v159;\n\tif (v39) goto L_0102;\n\tv164 = 0;\nL_0102:\n\tv187 = this._pendingRemovals;\n\tv175 = this._pendingRemovals == 0;\n\tv133 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv145 = &v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>);\n\tv30 = 0;\n\tv159 = v164;\n\tif (v175) goto L_0126;\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::Clear(v187);\n\tv387 = v187.Count < 1;\n\tif (v387) goto L_0121;\nL_0121:\n\treturn;\nL_0122:\n\tv513 = new System.NullReferenceException();\n\tv133 = &v270 @ stack_-38_v13 (Il2CppMethodInfo);\n\tv145 = &v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>);\n\tv30 = 0;\n\tgoto L_0125;\nL_0125:\n\t// 293 Interrupt\n\tv159 = Il2CppMethodInfo;\nL_0155:\n\tv259 = v159 != 1;\n\tif (v259) goto L_0169;\n\tv263 = 0x8BF5BC4(v203, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv277 = 0x8BF5BF4(v263, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv284 = *([v133 @ stack_-58_v4]);\n\tv285 = *([v284 @ X8_v4+20]);\n\tv286 = *([v285 @ X8_v5+C0]);\n\tv159 = *([v286 @ X8_v6+60]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v145);\n\tv361 = *([v263 @ X0_v7]) == 0;\n\tv104 = 0;\n\tv30 = *([v263 @ X0_v7]);\n\tif (v361) goto L_0049;\n\tv30 = *([v263 @ X0_v7]);\n\tgoto L_0187;\nL_0187:\n\tv379 = new System.OutOfMemoryException();\nL_018C:\n\tv351 = 0x8BF0368(v336, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv380 = 0xA1B8(v351, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0126:\n\tv203 = new System.NullReferenceException();\n\tgoto L_0155;\nL_0028:\n\t;\n\tv241 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>));\n\tv261 = v241 == 0;\n\tif (v261) goto L_003C;\nL_0070:\n\tv499 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v222 @ stack_-50_v10 (System.Collections.Generic.List`1<System.Action`1<T>>));\n\tv501 = v499 == 0;\n\tif (v501) goto L_0080;\nL_0169:\n\tv265 = 0x31D905C(&v30 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv336 = v203;\n\tgoto L_018C;\n\tv341 = 0x31D905C(&v30 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv336 = v379;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Invoke(T args)
		{
			_isInvoking = true;
			try
			{
				for (int i = 0; i < _observers.Count; i++)
				{
					_observers[i]?.Invoke(args);
				}
			}
			finally
			{
				_isInvoking = false;
			}
			if (_pendingRemovals.Count > 0)
			{
				foreach (Action<T> removed in _pendingRemovals)
				{
					_observers.Remove(removed);
				}
				_pendingRemovals.Clear();
			}
			if (_pendingAdd.Count > 0)
			{
				_observers.AddRange(_pendingAdd);
				_pendingAdd.Clear();
			}
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x5258674", Offset = "0x5258674", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<System.Collections.Generic.List`1<System.Action`1<T>>>();\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::.ctor(v42);\n\tthis._observers = v42;\n\tgoto L_0029;\nL_0029:\n\tv61 = new Il2CppClass<System.Collections.Generic.List`1<System.Action`1<T>>>();\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::.ctor(v61);\n\tthis._pendingRemovals = v61;\n\tgoto L_003E;\nL_003E:\n\tv80 = new Il2CppClass<System.Collections.Generic.List`1<System.Action`1<T>>>();\n\tSystem.Collections.Generic.List`1<System.Action`1<T>>::.ctor(v80);\n\tthis._pendingAdd = v80;\n\tUnco.EventBusSystem.Runtime.Event::.ctor(this);\n\treturn;\n")]
		public Event()
		{
			List<Action<T>> observers = new List<Action<T>>();
			_observers = observers;
			List<Action<T>> pendingRemovals = new List<Action<T>>();
			_pendingRemovals = pendingRemovals;
			List<Action<T>> pendingAdd = new List<Action<T>>();
			_pendingAdd = pendingAdd;
		}
	}
	[Token(Token = "0x2000006")]
	public class Event : IEvent
	{
		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81A8958", Offset = "0x81A8958", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Event()
		{
		}
	}
}
