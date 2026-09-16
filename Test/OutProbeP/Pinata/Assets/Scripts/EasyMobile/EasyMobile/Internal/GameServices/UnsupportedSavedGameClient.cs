using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.GameServices
{
	[Token(Token = "0x2000106")]
	internal class UnsupportedSavedGameClient : ISavedGameClient
	{
		[Token(Token = "0x4000478")]
		private const string DEFAULT_UNAVAILABLE_MESSAGE = "Saved Game feature is not available on this platform.";

		[Token(Token = "0x4000479")]
		[FieldOffset(Offset = "0x10")]
		private string mMessage;

		[Token(Token = "0x6000928")]
		[Address(RVA = "0xBFC228", Offset = "0xBFC228", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC5890]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F3F]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tthis.mMessage = \"Saved Game feature is not available on this platform.\";\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal UnsupportedSavedGameClient()
		{
			mMessage = "Saved Game feature is not available on this platform.";
		}

		[Token(Token = "0x6000929")]
		[Address(RVA = "0xBFC284", Offset = "0xBFC284", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EC3CB0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, msg, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022F40]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tgoto L_0028;\n\tv50 = *([v46 @ X0_v3+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0028;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0028:\n\tv61 = EasyMobile.Internal.Util::NullArgumentTest(msg);\n\tthis.mMessage = v61;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal UnsupportedSavedGameClient(string msg)
		{
			mMessage = Util.NullArgumentTest(msg);
		}

		[Token(Token = "0x600092A")]
		[Address(RVA = "0xBFC314", Offset = "0xBFC314", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F00508]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, name, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F41]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, name, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OpenWithAutomaticConflictResolution(string name, Action<SavedGame, string> callback)
		{
			Debug.LogWarning(mMessage);
		}

		[Token(Token = "0x600092B")]
		[Address(RVA = "0xBFC380", Offset = "0xBFC380", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EE2130]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, name, prefetchDataOnConflict, resolverFunction, completedCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F42]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, name, prefetchDataOnConflict, resolverFunction, completedCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OpenWithManualConflictResolution(string name, bool prefetchDataOnConflict, SavedGameConflictResolver resolverFunction, Action<SavedGame, string> completedCallback)
		{
			Debug.LogWarning(mMessage);
		}

		[Token(Token = "0x600092C")]
		[Address(RVA = "0xBFC3EC", Offset = "0xBFC3EC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F02820]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, savedGame, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F43]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, savedGame, callback, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ReadSavedGameData(SavedGame savedGame, Action<SavedGame, byte[], string> callback)
		{
			Debug.LogWarning(mMessage);
		}

		[Token(Token = "0x600092D")]
		[Address(RVA = "0xBFC458", Offset = "0xBFC458", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA8FF0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, savedGame, data, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F44]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, savedGame, data, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void WriteSavedGameData(SavedGame savedGame, byte[] data, Action<SavedGame, string> callback)
		{
			Debug.LogWarning(mMessage);
		}

		[Token(Token = "0x600092E")]
		[Address(RVA = "0xBFC4C4", Offset = "0xBFC4C4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F0D050]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, savedGame, data, infoUpdate, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F45]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, savedGame, data, infoUpdate, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void WriteSavedGameData(SavedGame savedGame, byte[] data, SavedGameInfoUpdate infoUpdate, Action<SavedGame, string> callback)
		{
			Debug.LogWarning(mMessage);
		}

		[Token(Token = "0x600092F")]
		[Address(RVA = "0xBFC530", Offset = "0xBFC530", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ED8F18]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, callback, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F46]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, callback, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FetchAllSavedGames(Action<SavedGame[], string> callback)
		{
			Debug.LogWarning(mMessage);
		}

		[Token(Token = "0x6000930")]
		[Address(RVA = "0xBFC59C", Offset = "0xBFC59C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA5940]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, savedGame, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F47]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, savedGame, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DeleteSavedGame(SavedGame savedGame)
		{
			Debug.LogWarning(mMessage);
		}

		[Token(Token = "0x6000931")]
		[Address(RVA = "0xBFC608", Offset = "0xBFC608", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EE1DE0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, uiTitle, maxDisplayedSavedGames, showCreateSaveUI, showDeleteSaveUI, callback, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F48]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, uiTitle, maxDisplayedSavedGames, showCreateSaveUI, showDeleteSaveUI, callback, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Debug::LogWarning(this.mMessage);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowSelectSavedGameUI(string uiTitle, uint maxDisplayedSavedGames, bool showCreateSaveUI, bool showDeleteSaveUI, Action<SavedGame, string> callback)
		{
			Debug.LogWarning(mMessage);
		}
	}
}
