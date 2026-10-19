using Cpp2ILInjected;

namespace _game.CoreGameKit.Tools
{
	[Token(Token = "0x20005A3")]
	public class ValidationError
	{
		[Token(Token = "0x17000229")]
		[field: Token(Token = "0x4001359")]
		[field: FieldOffset(Offset = "0x10")]
		public string Code
		{
			[Token(Token = "0x60017F3")]
			[Address(RVA = "0x3D30D98", Offset = "0x3D30D98", Length = "0x8")]
			get;
			[Token(Token = "0x60017F4")]
			[Address(RVA = "0x3D30DA0", Offset = "0x3D30DA0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700022A")]
		[field: Token(Token = "0x400135A")]
		[field: FieldOffset(Offset = "0x18")]
		public string Message
		{
			[Token(Token = "0x60017F5")]
			[Address(RVA = "0x3D30DA8", Offset = "0x3D30DA8", Length = "0x8")]
			get;
			[Token(Token = "0x60017F6")]
			[Address(RVA = "0x3D30DB0", Offset = "0x3D30DB0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700022B")]
		[field: Token(Token = "0x400135B")]
		[field: FieldOffset(Offset = "0x20")]
		public string Context
		{
			[Token(Token = "0x60017F7")]
			[Address(RVA = "0x3D30DB8", Offset = "0x3D30DB8", Length = "0x8")]
			get;
			[Token(Token = "0x60017F8")]
			[Address(RVA = "0x3D30DC0", Offset = "0x3D30DC0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60017F9")]
		[Address(RVA = "0x3D30DC8", Offset = "0x3D30DC8", Length = "0x8")]
		public ValidationError()
		{
		}
	}
}
