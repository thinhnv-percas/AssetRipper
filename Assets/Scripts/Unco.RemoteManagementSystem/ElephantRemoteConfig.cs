using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using ElephantSDK;
using JetBrains.Annotations;
using Unco.RemoteManagementSystem;

[Token(Token = "0x2000002")]
public class ElephantRemoteConfig : IRemoteConfig
{
	[CanBeNull]
	[Token(Token = "0x4000001")]
	[FieldOffset(Offset = "0x10")]
	private List<string> _keys;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x81C6D10", Offset = "0x81C6D10", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = ElephantSDK.RemoteConfig::GetInstance();\n\treturnVal1 = ElephantSDK.RemoteConfig::Get(v15, key, def);\n\treturn returnVal1;\n")]
	public string Get(string key, string def = null)
	{
		RemoteConfig instance = RemoteConfig.GetInstance();
		return instance.Get(key, def);
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x81C6D4C", Offset = "0x81C6D4C", Length = "0x44")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = ElephantSDK.RemoteConfig::GetInstance();\n\treturnVal1 = ElephantSDK.RemoteConfig::GetFloat(v19, key, def);\n\treturn returnVal1;\n")]
	public float GetFloat(string key, float def = 0f)
	{
		RemoteConfig instance = RemoteConfig.GetInstance();
		return instance.GetFloat(key, def);
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x81C6D90", Offset = "0x81C6D90", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = ElephantSDK.RemoteConfig::GetInstance();\n\treturnVal1 = ElephantSDK.RemoteConfig::GetInt(v15, key, def);\n\treturn returnVal1;\n")]
	public int GetInt(string key, int def = 0)
	{
		RemoteConfig instance = RemoteConfig.GetInstance();
		return instance.GetInt(key, def);
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x81C6DCC", Offset = "0x81C6DCC", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = ElephantSDK.RemoteConfig::GetInstance();\n\treturnVal1 = ElephantSDK.RemoteConfig::GetBool(v15, key, def);\n\treturn returnVal1;\n")]
	public bool GetBool(string key, bool def = false)
	{
		RemoteConfig instance = RemoteConfig.GetInstance();
		return instance.GetBool(key, def);
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x81C6E08", Offset = "0x81C6E08", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturn this._keys;\nL_0026:\n\tv55 = ElephantSDK.RemoteConfig::GetInstance();\n\tv88 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Keys(v55.variables);\n\tv93 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v93, v88);\n\tthis._keys = v93;\n\treturn this._keys;\nL_001C:\n\tv45 = this._keys == 0;\n\tif (v45) goto L_0026;\n")]
	public List<string> GetKeys()
	{
		global::AssetRipperInjected.RecoveryStub.Missing("ElephantRemoteConfig::GetKeys");
		return default;
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x81C6EE0", Offset = "0x81C6EE0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
	public ElephantRemoteConfig()
	{
	}
}
