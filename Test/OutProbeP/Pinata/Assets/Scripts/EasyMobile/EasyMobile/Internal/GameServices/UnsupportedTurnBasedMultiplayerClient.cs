using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.GameServices
{
	[Token(Token = "0x2000104")]
	internal class UnsupportedTurnBasedMultiplayerClient : ITurnBasedMultiplayerClient
	{
		[Token(Token = "0x17000251")]
		protected virtual string mUnavailableMessage
		{
			[Token(Token = "0x600090D")]
			[Address(RVA = "0xBFC674", Offset = "0xBFC674", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EF8490]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F49]) = v35;\nL_0018:\n\treturn \"Turn-based multiplayer is not available on this platform.\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "Turn-based multiplayer is not available on this platform.";
			}
		}

		[Token(Token = "0x600090E")]
		[Address(RVA = "0xBFC6BC", Offset = "0xBFC6BC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0CAA8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, invitation, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F4A]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AcceptInvitation(Invitation invitation, Action<bool, TurnBasedMatch> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600090F")]
		[Address(RVA = "0xBFC740", Offset = "0xBFC740", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0C880]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, request, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F4B]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateQuickMatch(MatchRequest request, Action<bool, TurnBasedMatch> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000910")]
		[Address(RVA = "0xBFC7C4", Offset = "0xBFC7C4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECF048]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, request, cancelCallback, errorCallback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F4C]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, cancelCallback, errorCallback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateWithMatchmakerUI(MatchRequest request, Action cancelCallback, Action<string> errorCallback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000911")]
		[Address(RVA = "0xBFC848", Offset = "0xBFC848", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF3D38]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, invitation, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F4D]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DeclineInvitation(Invitation invitation)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000912")]
		[Address(RVA = "0xBFC8CC", Offset = "0xBFC8CC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBFC10]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, callback, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F4E]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GetAllMatches(Action<TurnBasedMatch[]> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000913")]
		[Address(RVA = "0xBFC950", Offset = "0xBFC950", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEAD48]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F4F]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowMatchesUI()
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000914")]
		[Address(RVA = "0xBFC9D4", Offset = "0xBFC9D4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF4880]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, del, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F50]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RegisterMatchDelegate(MatchDelegate del)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000915")]
		[Address(RVA = "0xBFCA58", Offset = "0xBFCA58", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEC458]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, data, nextParticipantId, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F51]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, data, nextParticipantId, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TakeTurn(TurnBasedMatch match, byte[] data, string nextParticipantId, Action<bool> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000916")]
		[Address(RVA = "0xBFCADC", Offset = "0xBFCADC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F011E0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, data, nextParticipant, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F52]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, data, nextParticipant, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TakeTurn(TurnBasedMatch match, byte[] data, Participant nextParticipant, Action<bool> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000917")]
		[Address(RVA = "0xBFCB60", Offset = "0xBFCB60", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetMaxMatchDataSize()
		{
			return 0;
		}

		[Token(Token = "0x6000918")]
		[Address(RVA = "0xBFCB68", Offset = "0xBFCB68", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFE408]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, data, outcome, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F53]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, data, outcome, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Finish(TurnBasedMatch match, byte[] data, MatchOutcome outcome, Action<bool> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x6000919")]
		[Address(RVA = "0xBFCBEC", Offset = "0xBFCBEC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECF468]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F54]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AcknowledgeFinished(TurnBasedMatch match, Action<bool> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600091A")]
		[Address(RVA = "0xBFCC70", Offset = "0xBFCC70", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE1028]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F55]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LeaveMatch(TurnBasedMatch match, Action<bool> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600091B")]
		[Address(RVA = "0xBFCCF4", Offset = "0xBFCCF4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB9BC8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, pendingParticipantId, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F56]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, pendingParticipantId, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LeaveMatchInTurn(TurnBasedMatch match, string pendingParticipantId, Action<bool> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600091C")]
		[Address(RVA = "0xBFCD78", Offset = "0xBFCD78", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFD848]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, pendingParticipant, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F57]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, pendingParticipant, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LeaveMatchInTurn(TurnBasedMatch match, Participant pendingParticipant, Action<bool> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600091D")]
		[Address(RVA = "0xBFCDFC", Offset = "0xBFCDFC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEFA58]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, match, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F58]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.GameServices.UnsupportedTurnBasedMultiplayerClient::get_mUnavailableMessage(this);\n\tgoto L_002D;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv64 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v64, v42, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogWarning(v43);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Rematch(TurnBasedMatch match, Action<bool, TurnBasedMatch> callback)
		{
			string message = mUnavailableMessage;
			Debug.LogWarning(message);
		}

		[Token(Token = "0x600091E")]
		[Address(RVA = "0xBFCE80", Offset = "0xBFCE80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedTurnBasedMultiplayerClient()
		{
		}
	}
}
