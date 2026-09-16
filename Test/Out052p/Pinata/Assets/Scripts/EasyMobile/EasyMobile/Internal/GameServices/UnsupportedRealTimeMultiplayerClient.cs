using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.GameServices
{
	[Token(Token = "0x2000103")]
	internal class UnsupportedRealTimeMultiplayerClient : IRealTimeMultiplayerClient
	{
		[Token(Token = "0x17000250")]
		protected virtual string mUnavailableMessage
		{
			[Token(Token = "0x60008FD")]
			[Address(RVA = "0xBFBA88", Offset = "0xBFBA88", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EBCED8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F30]) = v35;\nL_0018:\n\treturn \"Real-time multiplayer API is not available on this platform.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "Real-time multiplayer API is not available on this platform.";
			}
		}

		[Token(Token = "0x60008FE")]
		[Address(RVA = "0xBFBAD0", Offset = "0xBFBAD0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE49F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, invitation, showWaitingRoomUI, listener, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F31]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, showWaitingRoomUI, listener, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AcceptInvitation(Invitation invitation, bool showWaitingRoomUI, IRealTimeMultiplayerListener listener)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x60008FF")]
		[Address(RVA = "0xBFBB54", Offset = "0xBFBB54", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE0540]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, request, listener, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F32]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, listener, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateQuickMatch(MatchRequest request, IRealTimeMultiplayerListener listener)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000900")]
		[Address(RVA = "0xBFBBD8", Offset = "0xBFBBD8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB7F88]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, request, listener, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F33]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, listener, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateWithMatchmakerUI(MatchRequest request, IRealTimeMultiplayerListener listener)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000901")]
		[Address(RVA = "0xBFBC5C", Offset = "0xBFBC5C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC5590]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F34]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_0028;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv60 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v60, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn 0;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<Participant> GetConnectedParticipants()
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
			return null;
		}

		[Token(Token = "0x6000902")]
		[Address(RVA = "0xBFBCE8", Offset = "0xBFBCE8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0FBB8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, invitation, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F35]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DeclineInvitation(Invitation invitation)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000903")]
		[Address(RVA = "0xBFBD6C", Offset = "0xBFBD6C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC2658]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, participantId, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F36]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_0028;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv60 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v60, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn 0;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Participant GetParticipant(string participantId)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
			return null;
		}

		[Token(Token = "0x6000904")]
		[Address(RVA = "0xBFBDF8", Offset = "0xBFBDF8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECE888]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F37]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_0028;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv60 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v60, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn 0;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Participant GetSelf()
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
			return null;
		}

		[Token(Token = "0x6000905")]
		[Address(RVA = "0xBFBE84", Offset = "0xBFBE84", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDF2E8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F38]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_0028;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv60 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v60, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn 0;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsRoomConnected()
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
			return false;
		}

		[Token(Token = "0x6000906")]
		[Address(RVA = "0xBFBF10", Offset = "0xBFBF10", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA42C0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F39]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LeaveRoom()
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000907")]
		[Address(RVA = "0xBFBF94", Offset = "0xBFBF94", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F016A8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, reliable, participantId, data, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F3A]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, participantId, data, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SendMessage(bool reliable, string participantId, byte[] data)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000908")]
		[Address(RVA = "0xBFC018", Offset = "0xBFC018", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF7AB0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, reliable, participantId, data, offset, length, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F3B]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, participantId, data, offset, length, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SendMessage(bool reliable, string participantId, byte[] data, int offset, int length)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000909")]
		[Address(RVA = "0xBFC09C", Offset = "0xBFC09C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC6BA0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, reliable, data, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F3C]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, data, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SendMessageToAll(bool reliable, byte[] data)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600090A")]
		[Address(RVA = "0xBFC120", Offset = "0xBFC120", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDF9B8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, reliable, data, offset, length, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F3D]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, data, offset, length, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SendMessageToAll(bool reliable, byte[] data, int offset, int length)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600090B")]
		[Address(RVA = "0xBFC1A4", Offset = "0xBFC1A4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA4BE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, listener, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F3E]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedRealTimeMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowInvitationsUI(IRealTimeMultiplayerListener listener)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600090C")]
		[Address(RVA = "0xBFBA80", Offset = "0xBFBA80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedRealTimeMultiplayerClient()
		{
		}
	}
}
