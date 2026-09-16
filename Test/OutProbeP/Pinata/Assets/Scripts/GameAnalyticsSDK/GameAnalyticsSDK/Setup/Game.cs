using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GameAnalyticsSDK.Setup
{
	[Token(Token = "0x200000F")]
	public class Game
	{
		[CompilerGenerated]
		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x10")]
		private string _003CName_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x18")]
		private int _003CID_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x20")]
		private string _003CGameKey_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x28")]
		private string _003CSecretKey_003Ek__BackingField;

		[Token(Token = "0x17000005")]
		public string Name
		{
			[CompilerGenerated]
			[Token(Token = "0x60000AA")]
			[Address(RVA = "0x15A50F8", Offset = "0x15A50F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Name>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000AB")]
			[Address(RVA = "0x15A5100", Offset = "0x15A5100", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Name>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000006")]
		public int ID
		{
			[CompilerGenerated]
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x15A5108", Offset = "0x15A5108", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ID;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000AD")]
			[Address(RVA = "0x15A5110", Offset = "0x15A5110", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ID>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000007")]
		public string GameKey
		{
			[CompilerGenerated]
			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x15A5118", Offset = "0x15A5118", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<GameKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GameKey;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000AF")]
			[Address(RVA = "0x15A5120", Offset = "0x15A5120", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<GameKey>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CGameKey_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000008")]
		public string SecretKey
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x15A5128", Offset = "0x15A5128", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SecretKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SecretKey;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B1")]
			[Address(RVA = "0x15A5130", Offset = "0x15A5130", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SecretKey>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CSecretKey_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x15A5138", Offset = "0x15A5138", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Name>k__BackingField = name;\n\tthis.<ID>k__BackingField = id;\n\tthis.<GameKey>k__BackingField = gameKey;\n\tthis.<SecretKey>k__BackingField = secretKey;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Game(string name, int id, string gameKey, string secretKey)
		{
			Name = name;
			ID = id;
			GameKey = gameKey;
			SecretKey = secretKey;
		}
	}
}
