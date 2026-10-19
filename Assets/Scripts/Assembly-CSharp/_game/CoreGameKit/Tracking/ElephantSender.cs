using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.ResourceSystem;
using Unco.Utils;
using UnityEngine;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x200057B")]
	public class ElephantSender : ITrackingSender
	{
		[Token(Token = "0x600170E")]
		[Address(RVA = "0x3D2573C", Offset = "0x3D2573C", Length = "0x16C")]
		public void SendEvent(string eventName, int level, string levelName, Params parameters)
		{
			Params obj = parameters.Set("level_name", levelName);
			if (ElephantCore.Instance != null)
			{
				Elephant.Event(eventName, level, parameters);
			}
		}

		[Token(Token = "0x600170F")]
		[Address(RVA = "0x3D258A8", Offset = "0x3D258A8", Length = "0xA8")]
		private static string BuildTrackingId(string levelName, bool isLoop, int loopTurnId)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBEE]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if (!isLoop)
				{
					goto IL_0060;
				}
			}
			else
			{
				_ = 1;
				if (!isLoop)
				{
					goto IL_0060;
				}
			}
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"loop{arg}_{levelName}";
			IL_0060:
			return levelName;
		}

		[Token(Token = "0x6001710")]
		[Address(RVA = "0x3D25950", Offset = "0x3D25950", Length = "0x1E8")]
		public unsafe void SendLevelComplete(int level, string originalLevelId, string levelName, bool isLoop, int loopTurnId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantSender::SendLevelComplete");
		}

		[Token(Token = "0x6001711")]
		[Address(RVA = "0x3D25B38", Offset = "0x3D25B38", Length = "0x23C")]
		public unsafe void SendLevelStarted(int level, string originalLevelId, string levelName, bool isLoop, int loopTurnId, int healthAmount, int coinAmount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantSender::SendLevelStarted");
		}

		[Token(Token = "0x6001712")]
		[Address(RVA = "0x3D25D74", Offset = "0x3D25D74", Length = "0x23C")]
		public unsafe void SendLevelFail(int level, bool isRetry, string originalLevelId, string levelName, bool isLoop, int loopTurnId, int healthAmount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantSender::SendLevelFail");
		}

		[Token(Token = "0x6001713")]
		[Address(RVA = "0x3D25FB0", Offset = "0x3D25FB0", Length = "0x2A8")]
		public unsafe void SendCustomEvent(string eventName, int level, string levelName, List<Pair<string, string>> pair)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantSender::SendCustomEvent");
		}

		[Token(Token = "0x6001714")]
		[Address(RVA = "0x3D26258", Offset = "0x3D26258", Length = "0x268")]
		public void SendMoveEvent(int level, string levelName, string levelGuid, int moveNumber, int col, int row, string color)
		{
			Params obj = Params.New();
			Params obj2 = obj.Set("move_number", moveNumber);
			Params obj3 = obj.Set("col", col);
			Params obj4 = obj.Set("row", row);
			Params obj5 = obj.Set("color", color);
			Params obj6 = obj.Set("level_name", levelName);
			Params obj7 = obj.Set("level_unique_id", levelGuid);
			if (ElephantCore.Instance != null)
			{
				Elephant.Event("move", level, obj);
			}
		}

		[Token(Token = "0x6001715")]
		[Address(RVA = "0x3D264C0", Offset = "0x3D264C0", Length = "0xA8")]
		public void SendTransaction(string type, long delta, long newAmount, string levelName, TransactionContext context)
		{
			string source = context.Source.ToString();
			Elephant.Transaction(type, context.Level, delta, newAmount, source);
		}

		[Token(Token = "0x6001716")]
		[Address(RVA = "0x3D26568", Offset = "0x3D26568", Length = "0x8")]
		public ElephantSender()
		{
		}
	}
}
