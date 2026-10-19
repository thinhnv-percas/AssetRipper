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
	[Token(Token = "0x200067B")]
	public class LinkedListNavigationHandler : ILevelNavigationHandler
	{
		[Token(Token = "0x200067C")]
		private struct SimState
		{
			[Token(Token = "0x4001643")]
			[FieldOffset(Offset = "0x0")]
			public int Pos;

			[Token(Token = "0x4001644")]
			[FieldOffset(Offset = "0x4")]
			public bool IsLoop;

			[Token(Token = "0x4001645")]
			[FieldOffset(Offset = "0x8")]
			public int LastCompletedUnique;

			[Token(Token = "0x4001646")]
			[FieldOffset(Offset = "0xC")]
			public int NextLoopPos;
		}

		[CompilerGenerated]
		[Token(Token = "0x200067D")]
		private sealed class _003CGetLevelRange_003Ed__19 : IEnumerable<ILevel>, IEnumerable, IEnumerator<ILevel>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001647")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4001648")]
			[FieldOffset(Offset = "0x18")]
			private ILevel _003C_003E2__current;

			[Token(Token = "0x4001649")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x400164A")]
			[FieldOffset(Offset = "0x24")]
			private int count;

			[Token(Token = "0x400164B")]
			[FieldOffset(Offset = "0x28")]
			public int _003C_003E3__count;

			[Token(Token = "0x400164C")]
			[FieldOffset(Offset = "0x30")]
			public LinkedListNavigationHandler _003C_003E4__this;

			[Token(Token = "0x400164D")]
			[FieldOffset(Offset = "0x38")]
			private int startIndex;

			[Token(Token = "0x400164E")]
			[FieldOffset(Offset = "0x3C")]
			public int _003C_003E3__startIndex;

			[Token(Token = "0x400164F")]
			[FieldOffset(Offset = "0x40")]
			private int _003CuniqueLength_003E5__2;

			[Token(Token = "0x4001650")]
			[FieldOffset(Offset = "0x44")]
			private int _003CloopLength_003E5__3;

			[Token(Token = "0x4001651")]
			[FieldOffset(Offset = "0x48")]
			private int _003CcurrentCounter_003E5__4;

			[Token(Token = "0x4001652")]
			[FieldOffset(Offset = "0x4C")]
			private int _003Cidx_003E5__5;

			[Token(Token = "0x4001653")]
			[FieldOffset(Offset = "0x50")]
			private int _003Cremaining_003E5__6;

			[Token(Token = "0x4001654")]
			[FieldOffset(Offset = "0x54")]
			private SimState _003Csim_003E5__7;

			[Token(Token = "0x4001655")]
			[FieldOffset(Offset = "0x64")]
			private int _003CsimCounter_003E5__8;

			[Token(Token = "0x170002C8")]
			ILevel IEnumerator<ILevel>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001B99")]
				[Address(RVA = "0x3D64B30", Offset = "0x3D64B30", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170002C9")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001B9B")]
				[Address(RVA = "0x3D64B78", Offset = "0x3D64B78", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B96")]
			[Address(RVA = "0x3D62BF4", Offset = "0x3D62BF4", Length = "0x38")]
			public _003CGetLevelRange_003Ed__19(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B97")]
			[Address(RVA = "0x3D64620", Offset = "0x3D64620", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001B98")]
			[Address(RVA = "0x3D64624", Offset = "0x3D64624", Length = "0x50C")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler._003CGetLevelRange_003Ed__19::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B9A")]
			[Address(RVA = "0x3D64B38", Offset = "0x3D64B38", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B9C")]
			[Address(RVA = "0x3D64B80", Offset = "0x3D64B80", Length = "0xB8")]
			IEnumerator<ILevel> IEnumerable<ILevel>.GetEnumerator()
			{
				_003CGetLevelRange_003Ed__19 _003CGetLevelRange_003Ed__20;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CGetLevelRange_003Ed__20 = this;
						goto IL_00a2;
					}
				}
				_003CGetLevelRange_003Ed__19 _003CGetLevelRange_003Ed__21 = (_003CGetLevelRange_003Ed__19)FormatterServices.GetUninitializedObject(typeof(_003CGetLevelRange_003Ed__19));
				_003CGetLevelRange_003Ed__21._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetLevelRange_003Ed__21._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetLevelRange_003Ed__21._003C_003E4__this = _003C_003E4__this;
				_003CGetLevelRange_003Ed__20 = _003CGetLevelRange_003Ed__21;
				goto IL_00a2;
				IL_00a2:
				_003CGetLevelRange_003Ed__20.startIndex = _003C_003E3__startIndex;
				_003CGetLevelRange_003Ed__20.count = _003C_003E3__count;
				return _003CGetLevelRange_003Ed__20;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001B9D")]
			[Address(RVA = "0x3D64C38", Offset = "0x3D64C38", Length = "0x4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ILevel>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x400163C")]
		private const string LogTag = "[LevelReason]";

		[Token(Token = "0x400163D")]
		[FieldOffset(Offset = "0x10")]
		private readonly ILevelList _levelList;

		[Token(Token = "0x400163E")]
		[FieldOffset(Offset = "0x18")]
		private readonly ILevelProgressService _progressService;

		[Token(Token = "0x400163F")]
		[FieldOffset(Offset = "0x20")]
		private int _currentPosition;

		[Token(Token = "0x4001640")]
		[FieldOffset(Offset = "0x24")]
		private bool _currentIsLoop;

		[Token(Token = "0x4001641")]
		[FieldOffset(Offset = "0x28")]
		private int _lastCompletedUniquePosition;

		[Token(Token = "0x4001642")]
		[FieldOffset(Offset = "0x2C")]
		private int _nextLoopPosition;

		[Token(Token = "0x170002C4")]
		public int CurrentPosition
		{
			[Token(Token = "0x6001B86")]
			[Address(RVA = "0x3D5F4D8", Offset = "0x3D5F4D8", Length = "0x8")]
			get
			{
				return _currentPosition;
			}
		}

		[Token(Token = "0x170002C5")]
		public bool CurrentIsLoop
		{
			[Token(Token = "0x6001B87")]
			[Address(RVA = "0x3D5F4E0", Offset = "0x3D5F4E0", Length = "0x8")]
			get
			{
				return _currentIsLoop;
			}
		}

		[Token(Token = "0x170002C6")]
		public int LastCompletedUniquePosition
		{
			[Token(Token = "0x6001B88")]
			[Address(RVA = "0x3D5F4E8", Offset = "0x3D5F4E8", Length = "0x8")]
			get
			{
				return _lastCompletedUniquePosition;
			}
		}

		[Token(Token = "0x170002C7")]
		public int NextLoopPosition
		{
			[Token(Token = "0x6001B89")]
			[Address(RVA = "0x3D5F4F0", Offset = "0x3D5F4F0", Length = "0x8")]
			get
			{
				return _nextLoopPosition;
			}
		}

		[Token(Token = "0x6001B85")]
		[Address(RVA = "0x3D5D2F4", Offset = "0x3D5D2F4", Length = "0x50")]
		public LinkedListNavigationHandler(ILevelList levelList, ILevelProgressService progressService)
		{
			_levelList = levelList;
			_progressService = progressService;
		}

		[Token(Token = "0x6001B8A")]
		[Address(RVA = "0x3D5F4F8", Offset = "0x3D5F4F8", Length = "0x19B8")]
		public void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::Initialize");
		}

		[Token(Token = "0x6001B8B")]
		[Address(RVA = "0x3D6264C", Offset = "0x3D6264C", Length = "0x508")]
		private void MigrateLoopTurnIfNeeded()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::MigrateLoopTurnIfNeeded");
		}

		[Token(Token = "0x6001B8C")]
		[Address(RVA = "0x3D61038", Offset = "0x3D61038", Length = "0x120")]
		public ILevel GetCurrentLevel()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::GetCurrentLevel");
			return default;
		}

		[IteratorStateMachine(typeof(_003CGetLevelRange_003Ed__19))]
		[Token(Token = "0x6001B8D")]
		[Address(RVA = "0x3D62B54", Offset = "0x3D62B54", Length = "0xA0")]
		public IEnumerable<ILevel> GetLevelRange(int startIndex, int count)
		{
			_003CGetLevelRange_003Ed__19 _003CGetLevelRange_003Ed__20 = new _003CGetLevelRange_003Ed__19(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetLevelRange_003Ed__20._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetLevelRange_003Ed__20._003C_003E4__this = this;
			_003CGetLevelRange_003Ed__20._003C_003E3__startIndex = startIndex;
			_003CGetLevelRange_003Ed__20._003C_003E3__count = count;
			return _003CGetLevelRange_003Ed__20;
		}

		[Token(Token = "0x6001B8E")]
		[Address(RVA = "0x3D62C2C", Offset = "0x3D62C2C", Length = "0x1C8")]
		private ILevel ResolveFlatIndex(int idx, int uniqueLength, int loopLength)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::ResolveFlatIndex");
			return default;
		}

		[Token(Token = "0x6001B8F")]
		[Address(RVA = "0x3D62DF4", Offset = "0x3D62DF4", Length = "0x84")]
		private void AdvanceSim(ref SimState s, int uniqueLength, int loopLength)
		{
			if (s.IsLoop)
			{
				if (loopLength >= 1)
				{
					int num = s.Pos + 1;
					int num2 = num / loopLength;
					int num3 = num2 * loopLength;
					int num4 = num - num3;
					int num5 = 12;
				}
			}
			else
			{
				int num4 = s.Pos;
				int num5 = 8;
			}
			int num6 = s.LastCompletedUnique + 1;
			if (num6 < uniqueLength)
			{
				s.IsLoop = false;
				s.Pos = num6;
				return;
			}
			if (loopLength >= 1)
			{
				s.IsLoop = true;
				s.Pos = s.NextLoopPos;
				return;
			}
			s.IsLoop = false;
			int num7 = uniqueLength - 1;
			int num8 = ~num7;
			int pos = num7 & num8;
			s.Pos = pos;
		}

		[Token(Token = "0x6001B90")]
		[Address(RVA = "0x3D62E78", Offset = "0x3D62E78", Length = "0x17A8")]
		public void AdvanceOnWin()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::AdvanceOnWin");
		}

		[Token(Token = "0x6001B91")]
		[Address(RVA = "0x3D61CD0", Offset = "0x3D61CD0", Length = "0x97C")]
		private unsafe void RecoverFromMissingGuid()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::RecoverFromMissingGuid");
		}

		[Token(Token = "0x6001B92")]
		[Address(RVA = "0x3D60F48", Offset = "0x3D60F48", Length = "0xF0")]
		private bool TryApplyEditorPlayOverride(int uniqueLength, int loopLength)
		{
			return false;
		}

		[Token(Token = "0x6001B93")]
		[Address(RVA = "0x3D61B4C", Offset = "0x3D61B4C", Length = "0x184")]
		private int ComputeNextLoopPosition(string lastCompletedLoopGuid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::ComputeNextLoopPosition");
			return default;
		}

		[Token(Token = "0x6001B94")]
		[Address(RVA = "0x3D61158", Offset = "0x3D61158", Length = "0x9F4")]
		private void MigrateIfNeeded()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedListNavigationHandler::MigrateIfNeeded");
		}

		[Token(Token = "0x6001B95")]
		[Address(RVA = "0x3D60EB0", Offset = "0x3D60EB0", Length = "0x98")]
		private static string TruncGuid(string guid)
		{
			if (string.IsNullOrEmpty(guid))
			{
				return "<empty>";
			}
			if (guid.Length < 9)
			{
				return guid;
			}
			int startIndex = guid.Length - 8;
			return guid.Substring(startIndex);
		}
	}
}
