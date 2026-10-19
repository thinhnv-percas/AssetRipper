using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller
{
	[Token(Token = "0x20006C2")]
	public class MouseInputProvider : IRawInputProvider, IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x20006C3")]
		private sealed class _003CGetOrbitInput_003Ed__7 : IEnumerable<ScreenPointInput>, IEnumerable, IEnumerator<ScreenPointInput>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40016D9")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40016DA")]
			[FieldOffset(Offset = "0x14")]
			private ScreenPointInput _003C_003E2__current;

			[Token(Token = "0x40016DB")]
			[FieldOffset(Offset = "0x1C")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x40016DC")]
			[FieldOffset(Offset = "0x20")]
			private float2 mousePos;

			[Token(Token = "0x40016DD")]
			[FieldOffset(Offset = "0x28")]
			public float2 _003C_003E3__mousePos;

			[Token(Token = "0x170002D8")]
			ScreenPointInput IEnumerator<ScreenPointInput>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001CB1")]
				[Address(RVA = "0x3D70CF4", Offset = "0x3D70CF4", Length = "0x8")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("MouseInputProvider._003CGetOrbitInput_003Ed__7::get_Current");
					return default;
				}
			}

			[Token(Token = "0x170002D9")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001CB3")]
				[Address(RVA = "0x3D70D3C", Offset = "0x3D70D3C", Length = "0x68")]
				get
				{
					ScreenPointInput screenPointInput = _003C_003E2__current;
					return screenPointInput;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CAE")]
			[Address(RVA = "0x3D70C14", Offset = "0x3D70C14", Length = "0x38")]
			public _003CGetOrbitInput_003Ed__7(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CAF")]
			[Address(RVA = "0x3D70CBC", Offset = "0x3D70CBC", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001CB0")]
			[Address(RVA = "0x3D70CC0", Offset = "0x3D70CC0", Length = "0x34")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MouseInputProvider._003CGetOrbitInput_003Ed__7::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CB2")]
			[Address(RVA = "0x3D70CFC", Offset = "0x3D70CFC", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CB4")]
			[Address(RVA = "0x3D70DA4", Offset = "0x3D70DA4", Length = "0xB4")]
			IEnumerator<ScreenPointInput> IEnumerable<ScreenPointInput>.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						mousePos = _003C_003E3__mousePos;
						return this;
					}
				}
				_003CGetOrbitInput_003Ed__7 _003CGetOrbitInput_003Ed__8 = (_003CGetOrbitInput_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CGetOrbitInput_003Ed__7));
				_003CGetOrbitInput_003Ed__8._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetOrbitInput_003Ed__8._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetOrbitInput_003Ed__8.mousePos = _003C_003E3__mousePos;
				return _003CGetOrbitInput_003Ed__8;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CB5")]
			[Address(RVA = "0x3D70E58", Offset = "0x3D70E58", Length = "0xB4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						mousePos = _003C_003E3__mousePos;
						return this;
					}
				}
				_003CGetOrbitInput_003Ed__7 _003CGetOrbitInput_003Ed__8 = (_003CGetOrbitInput_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CGetOrbitInput_003Ed__7));
				_003CGetOrbitInput_003Ed__8._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetOrbitInput_003Ed__8._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetOrbitInput_003Ed__8.mousePos = _003C_003E3__mousePos;
				return _003CGetOrbitInput_003Ed__8;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20006C4")]
		private sealed class _003CGetPanInput_003Ed__6 : IEnumerable<ScreenPointInput>, IEnumerable, IEnumerator<ScreenPointInput>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40016DE")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40016DF")]
			[FieldOffset(Offset = "0x14")]
			private ScreenPointInput _003C_003E2__current;

			[Token(Token = "0x40016E0")]
			[FieldOffset(Offset = "0x1C")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x40016E1")]
			[FieldOffset(Offset = "0x20")]
			public MouseInputProvider _003C_003E4__this;

			[Token(Token = "0x40016E2")]
			[FieldOffset(Offset = "0x28")]
			private float2 mousePos;

			[Token(Token = "0x40016E3")]
			[FieldOffset(Offset = "0x30")]
			public float2 _003C_003E3__mousePos;

			[Token(Token = "0x40016E4")]
			[FieldOffset(Offset = "0x38")]
			private float2 _003Cdelta_003E5__2;

			[Token(Token = "0x170002DA")]
			ScreenPointInput IEnumerator<ScreenPointInput>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001CB9")]
				[Address(RVA = "0x3D7103C", Offset = "0x3D7103C", Length = "0x8")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("MouseInputProvider._003CGetPanInput_003Ed__6::get_Current");
					return default;
				}
			}

			[Token(Token = "0x170002DB")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001CBB")]
				[Address(RVA = "0x3D71084", Offset = "0x3D71084", Length = "0x68")]
				get
				{
					ScreenPointInput screenPointInput = _003C_003E2__current;
					return screenPointInput;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CB6")]
			[Address(RVA = "0x3D70BDC", Offset = "0x3D70BDC", Length = "0x38")]
			public _003CGetPanInput_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CB7")]
			[Address(RVA = "0x3D70F0C", Offset = "0x3D70F0C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001CB8")]
			[Address(RVA = "0x3D70F10", Offset = "0x3D70F10", Length = "0x12C")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MouseInputProvider._003CGetPanInput_003Ed__6::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CBA")]
			[Address(RVA = "0x3D71044", Offset = "0x3D71044", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CBC")]
			[Address(RVA = "0x3D710EC", Offset = "0x3D710EC", Length = "0xC4")]
			IEnumerator<ScreenPointInput> IEnumerable<ScreenPointInput>.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						mousePos = _003C_003E3__mousePos;
						return this;
					}
				}
				_003CGetPanInput_003Ed__6 _003CGetPanInput_003Ed__7 = (_003CGetPanInput_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CGetPanInput_003Ed__6));
				_003CGetPanInput_003Ed__7._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetPanInput_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetPanInput_003Ed__7._003C_003E4__this = _003C_003E4__this;
				_003CGetPanInput_003Ed__7.mousePos = _003C_003E3__mousePos;
				return _003CGetPanInput_003Ed__7;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001CBD")]
			[Address(RVA = "0x3D711B0", Offset = "0x3D711B0", Length = "0x4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ScreenPointInput>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x40016D6")]
		[FieldOffset(Offset = "0x10")]
		private readonly UiManager _uiManager;

		[Token(Token = "0x40016D7")]
		[FieldOffset(Offset = "0x18")]
		private bool _panMode;

		[Token(Token = "0x40016D8")]
		[FieldOffset(Offset = "0x1C")]
		private float _zoomAmount;

		[Token(Token = "0x6001CA7")]
		[Address(RVA = "0x3D70708", Offset = "0x3D70708", Length = "0x3C")]
		public MouseInputProvider(UiManager uiManager)
		{
			_uiManager = uiManager;
			TouchSimulation.Enable();
		}

		[Token(Token = "0x6001CA8")]
		[Address(RVA = "0x3D70744", Offset = "0x3D70744", Length = "0x8")]
		public void Dispose()
		{
			TouchSimulation.Disable();
		}

		[Token(Token = "0x6001CA9")]
		[Address(RVA = "0x3D7074C", Offset = "0x3D7074C", Length = "0x374")]
		public IReadOnlyList<ScreenPointInput> GetScreenPoints()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MouseInputProvider::GetScreenPoints");
			return default;
		}

		[IteratorStateMachine(typeof(_003CGetPanInput_003Ed__6))]
		[Token(Token = "0x6001CAA")]
		[Address(RVA = "0x3D70B40", Offset = "0x3D70B40", Length = "0x9C")]
		private IEnumerable<ScreenPointInput> GetPanInput(float2 mousePos)
		{
			_003CGetPanInput_003Ed__6 _003CGetPanInput_003Ed__7 = new _003CGetPanInput_003Ed__6(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetPanInput_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetPanInput_003Ed__7._003C_003E4__this = this;
			_003CGetPanInput_003Ed__7._003C_003E3__mousePos.x = mousePos.x;
			_003CGetPanInput_003Ed__7._003C_003E3__mousePos.y = mousePos.y;
			return _003CGetPanInput_003Ed__7;
		}

		[IteratorStateMachine(typeof(_003CGetOrbitInput_003Ed__7))]
		[Token(Token = "0x6001CAB")]
		[Address(RVA = "0x3D70AC0", Offset = "0x3D70AC0", Length = "0x80")]
		private IEnumerable<ScreenPointInput> GetOrbitInput(float2 mousePos)
		{
			_003CGetOrbitInput_003Ed__7 _003CGetOrbitInput_003Ed__8 = new _003CGetOrbitInput_003Ed__7(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetOrbitInput_003Ed__8._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetOrbitInput_003Ed__8._003C_003E3__mousePos.x = mousePos.x;
			_003CGetOrbitInput_003Ed__8._003C_003E3__mousePos.y = mousePos.y;
			return _003CGetOrbitInput_003Ed__8;
		}

		[Token(Token = "0x6001CAC")]
		[Address(RVA = "0x3D70C4C", Offset = "0x3D70C4C", Length = "0x34")]
		private bool IsOverUI(float2 position)
		{
			Vector2 mousePosition = position;
			return _uiManager.IsOverUI(mousePosition);
		}
	}
}
