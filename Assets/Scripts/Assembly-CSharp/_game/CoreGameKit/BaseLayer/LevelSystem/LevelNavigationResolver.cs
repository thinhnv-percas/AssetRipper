using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000671")]
	public class LevelNavigationResolver
	{
		[CompilerGenerated]
		[Token(Token = "0x2000672")]
		private sealed class _003CGetLevelRange_003Ed__12 : IEnumerable<ILevel>, IEnumerable, IEnumerator<ILevel>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400160D")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400160E")]
			[FieldOffset(Offset = "0x18")]
			private ILevel _003C_003E2__current;

			[Token(Token = "0x400160F")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4001610")]
			[FieldOffset(Offset = "0x28")]
			public LevelNavigationResolver _003C_003E4__this;

			[Token(Token = "0x4001611")]
			[FieldOffset(Offset = "0x30")]
			private int startIndex;

			[Token(Token = "0x4001612")]
			[FieldOffset(Offset = "0x34")]
			public int _003C_003E3__startIndex;

			[Token(Token = "0x4001613")]
			[FieldOffset(Offset = "0x38")]
			private int count;

			[Token(Token = "0x4001614")]
			[FieldOffset(Offset = "0x3C")]
			public int _003C_003E3__count;

			[Token(Token = "0x4001615")]
			[FieldOffset(Offset = "0x40")]
			private IEnumerator<ILevel> _003C_003E7__wrap1;

			[Token(Token = "0x170002A1")]
			ILevel IEnumerator<ILevel>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001B4B")]
				[Address(RVA = "0x3D5D8BC", Offset = "0x3D5D8BC", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002A2")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001B4D")]
				[Address(RVA = "0x3D5D904", Offset = "0x3D5D904", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B47")]
			[Address(RVA = "0x3D5D26C", Offset = "0x3D5D26C", Length = "0x38")]
			public _003CGetLevelRange_003Ed__12(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B48")]
			[Address(RVA = "0x3D5D344", Offset = "0x3D5D344", Length = "0xDC")]
			void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver._003CGetLevelRange_003Ed__12::Dispose");
			}

			[Token(Token = "0x6001B49")]
			[Address(RVA = "0x3D5D420", Offset = "0x3D5D420", Length = "0x3D8")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver._003CGetLevelRange_003Ed__12::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6001B4A")]
			[Address(RVA = "0x3D5D7F8", Offset = "0x3D5D7F8", Length = "0xC4")]
			private void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver._003CGetLevelRange_003Ed__12::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B4C")]
			[Address(RVA = "0x3D5D8C4", Offset = "0x3D5D8C4", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B4E")]
			[Address(RVA = "0x3D5D90C", Offset = "0x3D5D90C", Length = "0xB8")]
			IEnumerator<ILevel> IEnumerable<ILevel>.GetEnumerator()
			{
				_003CGetLevelRange_003Ed__12 _003CGetLevelRange_003Ed__13;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CGetLevelRange_003Ed__13 = this;
						goto IL_00a2;
					}
				}
				_003CGetLevelRange_003Ed__12 _003CGetLevelRange_003Ed__14 = (_003CGetLevelRange_003Ed__12)FormatterServices.GetUninitializedObject(typeof(_003CGetLevelRange_003Ed__12));
				_003CGetLevelRange_003Ed__14._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetLevelRange_003Ed__14._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetLevelRange_003Ed__14._003C_003E4__this = _003C_003E4__this;
				_003CGetLevelRange_003Ed__13 = _003CGetLevelRange_003Ed__14;
				goto IL_00a2;
				IL_00a2:
				_003CGetLevelRange_003Ed__13.startIndex = _003C_003E3__startIndex;
				_003CGetLevelRange_003Ed__13.count = _003C_003E3__count;
				return _003CGetLevelRange_003Ed__13;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B4F")]
			[Address(RVA = "0x3D5D9C4", Offset = "0x3D5D9C4", Length = "0x4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ILevel>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x400160A")]
		[FieldOffset(Offset = "0x10")]
		internal readonly ILevelList _levelList;

		[Token(Token = "0x400160B")]
		[FieldOffset(Offset = "0x18")]
		internal readonly ILevelProgressService _progressService;

		[Token(Token = "0x400160C")]
		[FieldOffset(Offset = "0x20")]
		internal ILevelNavigationHandler _handler;

		[Token(Token = "0x1700029E")]
		public int CurrentPosition
		{
			[Token(Token = "0x6001B3F")]
			[Address(RVA = "0x3D5CD04", Offset = "0x3D5CD04", Length = "0xC0")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver::get_CurrentPosition");
				return default;
			}
		}

		[Token(Token = "0x1700029F")]
		public bool CurrentIsLoop
		{
			[Token(Token = "0x6001B40")]
			[Address(RVA = "0x3D5CDC4", Offset = "0x3D5CDC4", Length = "0xC4")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver::get_CurrentIsLoop");
				return default;
			}
		}

		[Token(Token = "0x170002A0")]
		public LevelOrderAlgorithm Algorithm
		{
			[Token(Token = "0x6001B41")]
			[Address(RVA = "0x3D5CE88", Offset = "0x3D5CE88", Length = "0xB4")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver::get_Algorithm");
				return default;
			}
		}

		[Token(Token = "0x6001B3E")]
		[Address(RVA = "0x3D5CCB4", Offset = "0x3D5CCB4", Length = "0x50")]
		public LevelNavigationResolver(ILevelList levelList, ILevelProgressService progressService)
		{
			_levelList = levelList;
			_progressService = progressService;
		}

		[Token(Token = "0x6001B42")]
		[Address(RVA = "0x3D5CF3C", Offset = "0x3D5CF3C", Length = "0x1BC")]
		public void Initialize()
		{
			LevelOrderAlgorithm algorithm = _levelList.GetAlgorithm();
			int num = 187240448 + 936;
			int num2 = 187240448 + 1016;
			if (algorithm == LevelOrderAlgorithm.Linear)
			{
				int num3 = num;
			}
			else
			{
				int num3 = num2;
			}
			object handler = new object();
			_ = _levelList;
			_ = _progressService;
			_handler = (ILevelNavigationHandler)handler;
			_handler.Initialize();
		}

		[Token(Token = "0x6001B43")]
		[Address(RVA = "0x3D5D1A8", Offset = "0x3D5D1A8", Length = "0xC4")]
		public ILevel GetCurrentLevel()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver::GetCurrentLevel");
			return default;
		}

		[IteratorStateMachine(typeof(_003CGetLevelRange_003Ed__12))]
		[Token(Token = "0x6001B44")]
		[Address(RVA = "0x3D594E0", Offset = "0x3D594E0", Length = "0xA0")]
		public IEnumerable<ILevel> GetLevelRange(int startIndex, int count)
		{
			_003CGetLevelRange_003Ed__12 _003CGetLevelRange_003Ed__13 = new _003CGetLevelRange_003Ed__12(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetLevelRange_003Ed__13._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetLevelRange_003Ed__13._003C_003E4__this = this;
			_003CGetLevelRange_003Ed__13._003C_003E3__startIndex = startIndex;
			_003CGetLevelRange_003Ed__13._003C_003E3__count = count;
			return _003CGetLevelRange_003Ed__13;
		}

		[Token(Token = "0x6001B45")]
		[Address(RVA = "0x3D571BC", Offset = "0x3D571BC", Length = "0xC0")]
		public void AdvanceOnWin()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelNavigationResolver::AdvanceOnWin");
		}

		[Token(Token = "0x6001B46")]
		[Address(RVA = "0x3D5D0F8", Offset = "0x3D5D0F8", Length = "0xB0")]
		private ILevelNavigationHandler CreateHandler(LevelOrderAlgorithm algorithm)
		{
			int num = 187240448 + 936;
			int num2 = 187240448 + 1016;
			if (algorithm == LevelOrderAlgorithm.Linear)
			{
				int num3 = num;
			}
			else
			{
				int num3 = num2;
			}
			object result = new object();
			_ = _levelList;
			_ = _progressService;
			return (ILevelNavigationHandler)result;
		}
	}
}
