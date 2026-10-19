using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x200038A")]
	public sealed class ResultError
	{
		[Token(Token = "0x1700012C")]
		[field: Token(Token = "0x4000ADE")]
		[field: FieldOffset(Offset = "0x10")]
		public string Code
		{
			[Token(Token = "0x6000EE2")]
			[Address(RVA = "0x3F1D964", Offset = "0x3F1D964", Length = "0x8")]
			get;
			[Token(Token = "0x6000EE3")]
			[Address(RVA = "0x3F1D96C", Offset = "0x3F1D96C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700012D")]
		[field: Token(Token = "0x4000ADF")]
		[field: FieldOffset(Offset = "0x18")]
		public string Message
		{
			[Token(Token = "0x6000EE4")]
			[Address(RVA = "0x3F1D974", Offset = "0x3F1D974", Length = "0x8")]
			get;
			[Token(Token = "0x6000EE5")]
			[Address(RVA = "0x3F1D97C", Offset = "0x3F1D97C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700012E")]
		[field: Token(Token = "0x4000AE0")]
		[field: FieldOffset(Offset = "0x20")]
		public string Hint
		{
			[Token(Token = "0x6000EE6")]
			[Address(RVA = "0x3F1D984", Offset = "0x3F1D984", Length = "0x8")]
			get;
			[Token(Token = "0x6000EE7")]
			[Address(RVA = "0x3F1D98C", Offset = "0x3F1D98C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6000EE8")]
		[Address(RVA = "0x3F1D87C", Offset = "0x3F1D87C", Length = "0x8")]
		public ResultError()
		{
		}
	}
}
