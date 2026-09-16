using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.Storage;
using Cpp2ILInjected;
using Zitga.CsvTools.Tutorials;

[Token(Token = "0x2000030")]
public class GameManager : SingletonMonoDontDestroy<GameManager>
{
	[NonSerialized]
	[Token(Token = "0x40000BC")]
	[FieldOffset(Offset = "0x28")]
	public DataCreatePlayer dataCreatePlayer;

	[Token(Token = "0x40000BD")]
	[FieldOffset(Offset = "0x30")]
	public bool isRemoveAds;

	[Token(Token = "0x40000BE")]
	[FieldOffset(Offset = "0x31")]
	public bool isTest;

	[Token(Token = "0x40000BF")]
	[FieldOffset(Offset = "0x34")]
	public int currentLevel;

	[Token(Token = "0x40000C0")]
	[FieldOffset(Offset = "0x38")]
	public FirstLevels firstLevels;

	[Token(Token = "0x40000C1")]
	[FieldOffset(Offset = "0x40")]
	public RandomLevels randomLevels;

	[Token(Token = "0x40000C2")]
	[FieldOffset(Offset = "0x48")]
	public bool isAddBox;

	[Token(Token = "0x1700001B")]
	public int numberRewinds
	{
		[Token(Token = "0x600013C")]
		[Address(RVA = "0xC004EC", Offset = "0xC004EC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"Rewind\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35634]) = v35;\nL_001A:\n\tgoto L_0023;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetInt(\"Rewind\", 5);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return ObscuredPrefs.GetInt("Rewind", 5);
		}
		[Token(Token = "0x600013D")]
		[Address(RVA = "0xC00558", Offset = "0xC00558", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv46 = \"Rewind\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv38 = 1;\n\t*([1A35635]) = v38;\nL_001C:\n\tgoto L_0021;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0021:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetInt(\"Rewind\", value);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::Save();\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			ObscuredPrefs.SetInt("Rewind", value);
			ObscuredPrefs.Save();
		}
	}

	[Token(Token = "0x1700001C")]
	public bool IsEditor
	{
		[Token(Token = "0x600013E")]
		[Address(RVA = "0xC02470", Offset = "0xC02470", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return false;
		}
	}

	[Token(Token = "0x600013F")]
	[Address(RVA = "0xC02478", Offset = "0xC02478", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35636]) = v37;\nL_0014:\n\tUtilityGame::SaveUserData(this.dataCreatePlayer);\n\tgoto L_0021;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0021:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::Save();\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SaveDataCreatePlayer()
	{
		UtilityGame.SaveUserData(dataCreatePlayer);
		ObscuredPrefs.Save();
	}

	[Token(Token = "0x6000140")]
	[Address(RVA = "0xC024D4", Offset = "0xC024D4", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameManager::SaveDataCreatePlayer(this);\n\treturn;\n")]
	private void OnApplicationQuit()
	{
		SaveDataCreatePlayer();
	}

	[Token(Token = "0x6000141")]
	[Address(RVA = "0xC024D8", Offset = "0xC024D8", Length = "0xC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = pauseStatus == 0;\n\tif (v2) goto L_0005;\n\tGameManager::SaveDataCreatePlayer(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			SaveDataCreatePlayer();
		}
	}

	[Token(Token = "0x6000142")]
	[Address(RVA = "0xC024E4", Offset = "0xC024E4", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = SingletonMonoDontDestroy`1<GameManager>;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35637]) = v38;\nL_001C:\n\tgoto L_0025;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tSingletonMonoDontDestroy`1<GameManager>::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GameManager()
	{
	}
}
