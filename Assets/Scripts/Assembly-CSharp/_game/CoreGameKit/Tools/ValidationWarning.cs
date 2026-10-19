using Cpp2ILInjected;

namespace _game.CoreGameKit.Tools
{
	[Token(Token = "0x20005A4")]
	public class ValidationWarning
	{
		[Token(Token = "0x1700022C")]
		[field: Token(Token = "0x400135C")]
		[field: FieldOffset(Offset = "0x10")]
		public string Code
		{
			[Token(Token = "0x60017FA")]
			[Address(RVA = "0x3D30DD0", Offset = "0x3D30DD0", Length = "0x8")]
			get;
			[Token(Token = "0x60017FB")]
			[Address(RVA = "0x3D30DD8", Offset = "0x3D30DD8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700022D")]
		[field: Token(Token = "0x400135D")]
		[field: FieldOffset(Offset = "0x18")]
		public string Message
		{
			[Token(Token = "0x60017FC")]
			[Address(RVA = "0x3D30DE0", Offset = "0x3D30DE0", Length = "0x8")]
			get;
			[Token(Token = "0x60017FD")]
			[Address(RVA = "0x3D30DE8", Offset = "0x3D30DE8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60017FE")]
		[Address(RVA = "0x3D30DF0", Offset = "0x3D30DF0", Length = "0x8")]
		public ValidationWarning()
		{
		}
	}
}
