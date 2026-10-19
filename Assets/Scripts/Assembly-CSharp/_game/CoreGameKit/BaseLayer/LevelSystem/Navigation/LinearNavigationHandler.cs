using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using Debug = UnityEngine.Debug;

namespace _game.CoreGameKit.BaseLayer.LevelSystem.Navigation
{
	[Token(Token = "0x2000679")]
	public class LinearNavigationHandler : ILevelNavigationHandler
	{
		[CompilerGenerated]
		[Token(Token = "0x200067A")]
		private sealed class _003CGetLevelRange_003Ed__11 : IEnumerable<ILevel>, IEnumerable, IEnumerator<ILevel>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001633")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4001634")]
			[FieldOffset(Offset = "0x18")]
			private ILevel _003C_003E2__current;

			[Token(Token = "0x4001635")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4001636")]
			[FieldOffset(Offset = "0x28")]
			public LinearNavigationHandler _003C_003E4__this;

			[Token(Token = "0x4001637")]
			[FieldOffset(Offset = "0x30")]
			private int startIndex;

			[Token(Token = "0x4001638")]
			[FieldOffset(Offset = "0x34")]
			public int _003C_003E3__startIndex;

			[Token(Token = "0x4001639")]
			[FieldOffset(Offset = "0x38")]
			private int count;

			[Token(Token = "0x400163A")]
			[FieldOffset(Offset = "0x3C")]
			public int _003C_003E3__count;

			[Token(Token = "0x400163B")]
			[FieldOffset(Offset = "0x40")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x170002C2")]
			ILevel IEnumerator<ILevel>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001B80")]
				[Address(RVA = "0x3D5F3CC", Offset = "0x3D5F3CC", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002C3")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001B82")]
				[Address(RVA = "0x3D5F414", Offset = "0x3D5F414", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B7D")]
			[Address(RVA = "0x3D5F018", Offset = "0x3D5F018", Length = "0x38")]
			public _003CGetLevelRange_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B7E")]
			[Address(RVA = "0x3D5F320", Offset = "0x3D5F320", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001B7F")]
			[Address(RVA = "0x3D5F324", Offset = "0x3D5F324", Length = "0xA8")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				if (_003C_003E1__state != 1)
				{
					if (num == 0)
					{
						_003C_003E1__state = -1;
						_003Ci_003E5__2 = 0;
						if (num < count)
						{
							goto IL_0088;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					num = ++_003Ci_003E5__2;
					if (num < count)
					{
						goto IL_0088;
					}
				}
				return false;
				IL_0088:
				int idx = startIndex + num;
				ILevel level = _003C_003E4__this.ResolveFlatIndex(idx);
				_003C_003E2__current = level;
				_003C_003E1__state = 1;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B81")]
			[Address(RVA = "0x3D5F3D4", Offset = "0x3D5F3D4", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B83")]
			[Address(RVA = "0x3D5F41C", Offset = "0x3D5F41C", Length = "0xB8")]
			IEnumerator<ILevel> IEnumerable<ILevel>.GetEnumerator()
			{
				_003CGetLevelRange_003Ed__11 _003CGetLevelRange_003Ed__12;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CGetLevelRange_003Ed__12 = this;
						goto IL_00a2;
					}
				}
				_003CGetLevelRange_003Ed__11 _003CGetLevelRange_003Ed__13 = (_003CGetLevelRange_003Ed__11)FormatterServices.GetUninitializedObject(typeof(_003CGetLevelRange_003Ed__11));
				_003CGetLevelRange_003Ed__13._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetLevelRange_003Ed__13._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetLevelRange_003Ed__13._003C_003E4__this = _003C_003E4__this;
				_003CGetLevelRange_003Ed__12 = _003CGetLevelRange_003Ed__13;
				goto IL_00a2;
				IL_00a2:
				_003CGetLevelRange_003Ed__12.startIndex = _003C_003E3__startIndex;
				_003CGetLevelRange_003Ed__12.count = _003C_003E3__count;
				return _003CGetLevelRange_003Ed__12;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B84")]
			[Address(RVA = "0x3D5F4D4", Offset = "0x3D5F4D4", Length = "0x4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ILevel>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x400162F")]
		private const string LogTag = "[LevelReason]";

		[Token(Token = "0x4001630")]
		[FieldOffset(Offset = "0x10")]
		private readonly ILevelList _levelList;

		[Token(Token = "0x4001631")]
		[FieldOffset(Offset = "0x18")]
		private readonly ILevelProgressService _progressService;

		[Token(Token = "0x4001632")]
		[FieldOffset(Offset = "0x20")]
		private int _currentPosition;

		[Token(Token = "0x170002C0")]
		public int CurrentPosition
		{
			[Token(Token = "0x6001B74")]
			[Address(RVA = "0x3D5DF00", Offset = "0x3D5DF00", Length = "0x8")]
			get
			{
				return _currentPosition;
			}
		}

		[Token(Token = "0x170002C1")]
		public bool CurrentIsLoop
		{
			[Token(Token = "0x6001B75")]
			[Address(RVA = "0x3D5DF08", Offset = "0x3D5DF08", Length = "0xB8")]
			get
			{
				int uniqueLength = _levelList.GetUniqueLength();
				int num = CurrentPosition - uniqueLength;
				bool flag = num < 0;
				int num2 = CurrentPosition ^ uniqueLength;
				int num3 = CurrentPosition ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				return flag == flag2;
			}
		}

		[Token(Token = "0x6001B73")]
		[Address(RVA = "0x3D5D2A4", Offset = "0x3D5D2A4", Length = "0x50")]
		public LinearNavigationHandler(ILevelList levelList, ILevelProgressService progressService)
		{
			_levelList = levelList;
			_progressService = progressService;
		}

		[Token(Token = "0x6001B76")]
		[Address(RVA = "0x3D5DFC0", Offset = "0x3D5DFC0", Length = "0x280")]
		public void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinearNavigationHandler::Initialize");
		}

		[Token(Token = "0x6001B77")]
		[Address(RVA = "0x3D5E240", Offset = "0x3D5E240", Length = "0x8")]
		public ILevel GetCurrentLevel()
		{
			return ResolveFlatIndex(CurrentPosition);
		}

		[IteratorStateMachine(typeof(_003CGetLevelRange_003Ed__11))]
		[Token(Token = "0x6001B78")]
		[Address(RVA = "0x3D5EF78", Offset = "0x3D5EF78", Length = "0xA0")]
		public IEnumerable<ILevel> GetLevelRange(int startIndex, int count)
		{
			_003CGetLevelRange_003Ed__11 _003CGetLevelRange_003Ed__12 = new _003CGetLevelRange_003Ed__11(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetLevelRange_003Ed__12._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetLevelRange_003Ed__12._003C_003E4__this = this;
			_003CGetLevelRange_003Ed__12._003C_003E3__startIndex = startIndex;
			_003CGetLevelRange_003Ed__12._003C_003E3__count = count;
			return _003CGetLevelRange_003Ed__12;
		}

		[Token(Token = "0x6001B79")]
		[Address(RVA = "0x3D5ECB0", Offset = "0x3D5ECB0", Length = "0x2C8")]
		private ILevel ResolveFlatIndex(int idx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinearNavigationHandler::ResolveFlatIndex");
			return default;
		}

		[Token(Token = "0x6001B7A")]
		[Address(RVA = "0x3D5F050", Offset = "0x3D5F050", Length = "0x2D0")]
		public void AdvanceOnWin()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinearNavigationHandler::AdvanceOnWin");
		}

		[Token(Token = "0x6001B7B")]
		[Address(RVA = "0x3D5E248", Offset = "0x3D5E248", Length = "0x31C")]
		private void MaintainLoopTurnId()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinearNavigationHandler::MaintainLoopTurnId");
		}

		[Token(Token = "0x6001B7C")]
		[Address(RVA = "0x3D5E564", Offset = "0x3D5E564", Length = "0x74C")]
		private void LogResolution(string phase, ILevel level)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinearNavigationHandler::LogResolution");
		}
	}
}
