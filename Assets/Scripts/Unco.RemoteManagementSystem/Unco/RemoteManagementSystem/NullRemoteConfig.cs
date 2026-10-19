using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RemoteManagementSystem
{
	[Token(Token = "0x200000D")]
	public class NullRemoteConfig : IRemoteConfig
	{
		[Token(Token = "0x6000027")]
		[Address(RVA = "0x81CC9B8", Offset = "0x81CC9B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn def;\n")]
		public string Get(string key, string def = null)
		{
			return def;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x81CC9C0", Offset = "0x81CC9C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn def;\n")]
		public float GetFloat(string key, float def = 0f)
		{
			return def;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x81CC9C4", Offset = "0x81CC9C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn def;\n")]
		public int GetInt(string key, int def = 0)
		{
			return def;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x81CC9CC", Offset = "0x81CC9CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn def;\n")]
		public bool GetBool(string key, bool def = false)
		{
			return def;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x81CC9D4", Offset = "0x81CC9D4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv47 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v47);\n\treturn v47;\n")]
		public List<string> GetKeys()
		{
			return new List<string>();
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x81CCA48", Offset = "0x81CCA48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NullRemoteConfig()
		{
		}
	}
}
