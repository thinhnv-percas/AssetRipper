using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.ResourceSystem;
using Unco.Utils;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x200057C")]
	public class FirebaseSender : ITrackingSender
	{
		[Token(Token = "0x17000213")]
		private static IFirebaseElephantAdapter Adapter
		{
			[Token(Token = "0x6001717")]
			[Address(RVA = "0x3D26570", Offset = "0x3D26570", Length = "0x8C")]
			get
			{
				ElephantCore instance = ElephantCore.Instance;
				if ((object)ElephantCore.Instance != null)
				{
					return instance.FirebaseElephantAdapter;
				}
				return null;
			}
		}

		[Token(Token = "0x6001718")]
		[Address(RVA = "0x3D265FC", Offset = "0x3D265FC", Length = "0xAA0")]
		public void SendEvent(string eventName, int level, string levelName, Params parameters)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseSender::SendEvent");
		}

		[Token(Token = "0x6001719")]
		[Address(RVA = "0x3D2709C", Offset = "0x3D2709C", Length = "0xA8")]
		private static string BuildTrackingId(string levelName, bool isLoop, int loopTurnId)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DBF4]");
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

		[Token(Token = "0x600171A")]
		[Address(RVA = "0x3D27144", Offset = "0x3D27144", Length = "0x2D4")]
		public void SendLevelComplete(int level, string originalLevelId, string levelName, bool isLoop, int loopTurnId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseSender::SendLevelComplete");
		}

		[Token(Token = "0x600171B")]
		[Address(RVA = "0x3D27418", Offset = "0x3D27418", Length = "0x348")]
		public void SendLevelStarted(int level, string originalLevelId, string levelName, bool isLoop, int loopTurnId, int healthAmount, int coinAmount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseSender::SendLevelStarted");
		}

		[Token(Token = "0x600171C")]
		[Address(RVA = "0x3D27760", Offset = "0x3D27760", Length = "0x34C")]
		public void SendLevelFail(int level, bool isRetry, string originalLevelId, string levelName, bool isLoop, int loopTurnId, int healthAmount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseSender::SendLevelFail");
		}

		[Token(Token = "0x600171D")]
		[Address(RVA = "0x3D27AAC", Offset = "0x3D27AAC", Length = "0x328")]
		public unsafe void SendCustomEvent(string eventName, int level, string levelName, List<Pair<string, string>> pair)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseSender::SendCustomEvent");
		}

		[Token(Token = "0x600171E")]
		[Address(RVA = "0x3D27DD4", Offset = "0x3D27DD4", Length = "0x348")]
		public void SendMoveEvent(int level, string levelName, string levelGuid, int moveNumber, int col, int row, string color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseSender::SendMoveEvent");
		}

		[Token(Token = "0x600171F")]
		[Address(RVA = "0x3D2811C", Offset = "0x3D2811C", Length = "0x308")]
		public void SendTransaction(string type, long delta, long newAmount, string levelName, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FirebaseSender::SendTransaction");
		}

		[Token(Token = "0x6001720")]
		[Address(RVA = "0x3D28424", Offset = "0x3D28424", Length = "0x8")]
		public FirebaseSender()
		{
		}
	}
}
