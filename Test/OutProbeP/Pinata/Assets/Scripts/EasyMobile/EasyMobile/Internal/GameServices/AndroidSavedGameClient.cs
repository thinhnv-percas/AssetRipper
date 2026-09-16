using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.GameServices
{
	[Token(Token = "0x2000105")]
	internal class AndroidSavedGameClient : ISavedGameClient
	{
		[Token(Token = "0x4000477")]
		private const string SDK_MISSING_MESSAGE = "SDK missing. Please import Google Play Games plugin for Unity.";

		[Token(Token = "0x600091F")]
		[Address(RVA = "0xBFB6FC", Offset = "0xBFB6FC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFE088]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, name, callback, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F28]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, name, callback, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OpenWithAutomaticConflictResolution(string name, Action<SavedGame, string> callback)
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000920")]
		[Address(RVA = "0xBFB768", Offset = "0xBFB768", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED12A8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, name, prefetchDataOnConflict, resolverFunction, completedCallback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F29]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, name, prefetchDataOnConflict, resolverFunction, completedCallback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OpenWithManualConflictResolution(string name, bool prefetchDataOnConflict, SavedGameConflictResolver resolverFunction, Action<SavedGame, string> completedCallback)
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000921")]
		[Address(RVA = "0xBFB7D4", Offset = "0xBFB7D4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEE5A8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, savedGame, callback, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F2A]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, savedGame, callback, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ReadSavedGameData(SavedGame savedGame, Action<SavedGame, byte[], string> callback)
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000922")]
		[Address(RVA = "0xBFB840", Offset = "0xBFB840", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0;\n\tv14 = 0xFD47C8(&v10 @ stack_-40_v1, 0, data, callback, methodInfo, v18, v19, v20, 0, v21, v22, v23, v24, v25, v26, v27);\n\tEasyMobile.Internal.GameServices.AndroidSavedGameClient::WriteSavedGameData(v14, 0, data, callback, methodInfo);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void WriteSavedGameData(SavedGame savedGame, byte[] data, Action<SavedGame, string> callback)
		{
			//IL_0009: Expected O, but got I4
			//IL_002e: Expected O, but got I
			object obj = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @FD47C8 (inside EasyMobile.SavedGameConflictResolver::EndInvoke +0x120)");
			AndroidSavedGameClient androidSavedGameClient = default(AndroidSavedGameClient);
			IntPtr intPtr = default(IntPtr);
			androidSavedGameClient.WriteSavedGameData(null, data, (SavedGameInfoUpdate)callback, (Action<SavedGame, string>)(long)intPtr);
		}

		[Token(Token = "0x6000923")]
		[Address(RVA = "0xBFB878", Offset = "0xBFB878", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED56C0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, savedGame, data, infoUpdate, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F2B]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, savedGame, data, infoUpdate, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void WriteSavedGameData(SavedGame savedGame, byte[] data, SavedGameInfoUpdate infoUpdate, Action<SavedGame, string> callback)
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000924")]
		[Address(RVA = "0xBFB8E4", Offset = "0xBFB8E4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED4B58]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F2C]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, callback, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FetchAllSavedGames(Action<SavedGame[], string> callback)
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000925")]
		[Address(RVA = "0xBFB950", Offset = "0xBFB950", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F00A68]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, savedGame, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F2D]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, savedGame, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DeleteSavedGame(SavedGame savedGame)
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000926")]
		[Address(RVA = "0xBFB9BC", Offset = "0xBFB9BC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBC2A8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, uiTitle, maxDisplayedSavedGames, showCreateSaveUI, showDeleteSaveUI, callback, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022F2E]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, uiTitle, maxDisplayedSavedGames, showCreateSaveUI, showDeleteSaveUI, callback, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import Google Play Games plugin for Unity.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowSelectSavedGameUI(string uiTitle, uint maxDisplayedSavedGames, bool showCreateSaveUI, bool showDeleteSaveUI, Action<SavedGame, string> callback)
		{
			Debug.LogError("SDK missing. Please import Google Play Games plugin for Unity.");
		}

		[Token(Token = "0x6000927")]
		[Address(RVA = "0xBFBA28", Offset = "0xBFBA28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidSavedGameClient()
		{
		}
	}
}
