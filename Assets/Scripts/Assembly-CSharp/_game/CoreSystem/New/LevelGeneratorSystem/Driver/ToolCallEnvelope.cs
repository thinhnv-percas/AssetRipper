using Cpp2ILInjected;
using Newtonsoft.Json.Linq;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000388")]
	public sealed class ToolCallEnvelope
	{
		[Token(Token = "0x17000125")]
		[field: Token(Token = "0x4000AD7")]
		[field: FieldOffset(Offset = "0x10")]
		public int Seq
		{
			[Token(Token = "0x6000ECF")]
			[Address(RVA = "0x3F1D7FC", Offset = "0x3F1D7FC", Length = "0x8")]
			get;
			[Token(Token = "0x6000ED0")]
			[Address(RVA = "0x3F1D804", Offset = "0x3F1D804", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000126")]
		[field: Token(Token = "0x4000AD8")]
		[field: FieldOffset(Offset = "0x18")]
		public string Tool
		{
			[Token(Token = "0x6000ED1")]
			[Address(RVA = "0x3F1D80C", Offset = "0x3F1D80C", Length = "0x8")]
			get;
			[Token(Token = "0x6000ED2")]
			[Address(RVA = "0x3F1D814", Offset = "0x3F1D814", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000127")]
		[field: Token(Token = "0x4000AD9")]
		[field: FieldOffset(Offset = "0x20")]
		public JObject Args
		{
			[Token(Token = "0x6000ED3")]
			[Address(RVA = "0x3F1D81C", Offset = "0x3F1D81C", Length = "0x8")]
			get;
			[Token(Token = "0x6000ED4")]
			[Address(RVA = "0x3F1D824", Offset = "0x3F1D824", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6000ED5")]
		[Address(RVA = "0x3F1D82C", Offset = "0x3F1D82C", Length = "0x8")]
		public ToolCallEnvelope()
		{
		}
	}
}
