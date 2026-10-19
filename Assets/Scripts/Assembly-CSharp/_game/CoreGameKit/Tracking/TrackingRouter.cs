using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.ResourceSystem;
using Unco.Utils;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x2000585")]
	public class TrackingRouter
	{
		[Token(Token = "0x4001314")]
		[FieldOffset(Offset = "0x10")]
		internal readonly ITrackingSender[] _senders;

		[Token(Token = "0x4001315")]
		[FieldOffset(Offset = "0x18")]
		internal readonly ILevelProgressService _progressService;

		[Token(Token = "0x4001316")]
		[FieldOffset(Offset = "0x20")]
		internal readonly ILevelList _levelList;

		[Token(Token = "0x17000214")]
		private int CurrentLevel
		{
			[Token(Token = "0x600173D")]
			[Address(RVA = "0x3D296AC", Offset = "0x3D296AC", Length = "0xAC")]
			get
			{
				int currentLevelIndex = _progressService.CurrentLevelIndex;
				return currentLevelIndex + 1;
			}
		}

		[Token(Token = "0x600173C")]
		[Address(RVA = "0x3D28C20", Offset = "0x3D28C20", Length = "0x64")]
		public TrackingRouter(ITrackingSender[] senders, ILevelProgressService progressService, ILevelList levelList)
		{
			_senders = senders;
			_progressService = progressService;
			_levelList = levelList;
		}

		[Token(Token = "0x600173E")]
		[Address(RVA = "0x3D29758", Offset = "0x3D29758", Length = "0x174")]
		private string ResolveLevelName(string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingRouter::ResolveLevelName");
			return default;
		}

		[Token(Token = "0x600173F")]
		[Address(RVA = "0x3D298CC", Offset = "0x3D298CC", Length = "0x1E8")]
		private string GetCurrentLevelName()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingRouter::GetCurrentLevelName");
			return default;
		}

		[Token(Token = "0x6001740")]
		[Address(RVA = "0x3D28F4C", Offset = "0x3D28F4C", Length = "0x1F8")]
		public void Event(TrackingKey eventName, Params parameters = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingRouter::Event");
		}

		[Token(Token = "0x6001741")]
		[Address(RVA = "0x3D2915C", Offset = "0x3D2915C", Length = "0x1D8")]
		public void SendCustomEvent(string eventName, Params parameters)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFF]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if (parameters != null)
				{
					goto IL_0055;
				}
			}
			else
			{
				_ = 1;
				if (parameters != null)
				{
					goto IL_0055;
				}
			}
			Params obj2 = Params.New();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
			int num = (int)((nint)0 & (nint)1);
			bool flag = num == 0;
			bool flag2 = !flag;
			Params parameters2 = obj2;
			Params obj3 = obj2;
			if (flag2)
			{
				goto IL_0098;
			}
			goto IL_014e;
			IL_0208:
			ILevelProgressService progressService;
			int currentLevelIndex = progressService.CurrentLevelIndex;
			string currentLevelName = GetCurrentLevelName();
			ITrackingSender[] senders = _senders;
			if (senders.Length >= 1)
			{
				int num2 = 0;
				do
				{
					int level = currentLevelIndex + 1;
					senders[num2].SendEvent(eventName, level, currentLevelName, parameters2);
					num2++;
				}
				while (num2 < senders.Length);
			}
			return;
			IL_0098:
			progressService = _progressService;
			if (_progressService != null)
			{
				goto IL_0208;
			}
			throw new NullReferenceException();
			IL_014e:
			_ = 1;
			progressService = _progressService;
			parameters2 = obj3;
			goto IL_0208;
			IL_0055:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
			int num3 = (int)((nint)0 & (nint)1);
			bool flag3 = num3 == 0;
			parameters2 = parameters;
			obj3 = parameters;
			if (!flag3)
			{
				goto IL_0098;
			}
			goto IL_014e;
		}

		[Token(Token = "0x6001742")]
		[Address(RVA = "0x3D29AB4", Offset = "0x3D29AB4", Length = "0x1A8")]
		public void LevelComplete(string levelGuid, bool isLoop, int loopTurnId)
		{
			int currentLevelIndex = _progressService.CurrentLevelIndex;
			string levelName = ResolveLevelName(levelGuid);
			ITrackingSender[] senders = _senders;
			if (senders.Length >= 1)
			{
				int num = 0;
				do
				{
					senders[num].SendLevelComplete(currentLevelIndex, levelGuid, levelName, isLoop, loopTurnId);
					num++;
				}
				while (num < senders.Length);
			}
		}

		[Token(Token = "0x6001743")]
		[Address(RVA = "0x3D29C5C", Offset = "0x3D29C5C", Length = "0x1F0")]
		public void LevelStarted(string levelGuid, bool isLoop, int loopTurnId, int healthAmount = 0, int coinAmount = 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DC00]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			_ = 1;
			ILevelProgressService progressService = _progressService;
			goto IL_019d;
			IL_019d:
			int currentLevelIndex = progressService.CurrentLevelIndex;
			string levelName = ResolveLevelName(levelGuid);
			ITrackingSender[] senders = _senders;
			if (senders.Length >= 1)
			{
				int num = 0;
				do
				{
					int level = currentLevelIndex + 1;
					senders[num].SendLevelStarted(level, levelGuid, levelName, isLoop, loopTurnId, healthAmount, coinAmount);
					num++;
				}
				while (num < senders.Length);
			}
			return;
			IL_0066:
			progressService = _progressService;
			if (_progressService != null)
			{
				goto IL_019d;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001744")]
		[Address(RVA = "0x3D29E4C", Offset = "0x3D29E4C", Length = "0x1F0")]
		public void LevelFail(string levelGuid, bool isLoop, int loopTurnId, bool isRetry = false, int healthAmount = 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DC01]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0066;
				}
			}
			_ = 1;
			ILevelProgressService progressService = _progressService;
			goto IL_019d;
			IL_019d:
			int currentLevelIndex = progressService.CurrentLevelIndex;
			string levelName = ResolveLevelName(levelGuid);
			ITrackingSender[] senders = _senders;
			if (senders.Length >= 1)
			{
				int num = 0;
				do
				{
					int level = currentLevelIndex + 1;
					senders[num].SendLevelFail(level, isRetry, levelGuid, levelName, isLoop, loopTurnId, healthAmount);
					num++;
				}
				while (num < senders.Length);
			}
			return;
			IL_0066:
			progressService = _progressService;
			if (_progressService != null)
			{
				goto IL_019d;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001745")]
		[Address(RVA = "0x3D2934C", Offset = "0x3D2934C", Length = "0x1C8")]
		public void SendCustomEvent(string eventName, List<Pair<string, string>> pair)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DC02]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_006f;
				}
			}
			else
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBFD]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_006f;
				}
			}
			_ = 1;
			ILevelProgressService progressService = _progressService;
			goto IL_019a;
			IL_019a:
			int currentLevelIndex = progressService.CurrentLevelIndex;
			string currentLevelName = GetCurrentLevelName();
			ITrackingSender[] senders = _senders;
			if (senders.Length >= 1)
			{
				int num = 0;
				do
				{
					int level = currentLevelIndex + 1;
					senders[num].SendCustomEvent(eventName, level, currentLevelName, pair);
					num++;
				}
				while (num < senders.Length);
			}
			return;
			IL_006f:
			progressService = _progressService;
			if (_progressService != null)
			{
				goto IL_019a;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001746")]
		[Address(RVA = "0x3D2A03C", Offset = "0x3D2A03C", Length = "0x270")]
		public void SendMoveEvent(int moveNumber, int col, int row, string color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingRouter::SendMoveEvent");
		}

		[Token(Token = "0x6001747")]
		[Address(RVA = "0x3D29550", Offset = "0x3D29550", Length = "0x15C")]
		public unsafe void Transaction(string type, long delta, long newAmount, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingRouter::Transaction");
		}
	}
}
