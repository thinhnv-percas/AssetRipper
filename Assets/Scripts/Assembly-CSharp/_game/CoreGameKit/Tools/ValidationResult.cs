using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Tools
{
	[Token(Token = "0x20005A2")]
	public class ValidationResult
	{
		[Token(Token = "0x17000226")]
		[field: Token(Token = "0x4001356")]
		[field: FieldOffset(Offset = "0x10")]
		public bool IsValid
		{
			[Token(Token = "0x60017EC")]
			[Address(RVA = "0x3D30C88", Offset = "0x3D30C88", Length = "0x8")]
			get;
			[Token(Token = "0x60017ED")]
			[Address(RVA = "0x3D30C90", Offset = "0x3D30C90", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000227")]
		[field: Token(Token = "0x4001357")]
		[field: FieldOffset(Offset = "0x18")]
		public List<ValidationError> Errors
		{
			[Token(Token = "0x60017EE")]
			[Address(RVA = "0x3D30C98", Offset = "0x3D30C98", Length = "0x8")]
			get;
			[Token(Token = "0x60017EF")]
			[Address(RVA = "0x3D30CA0", Offset = "0x3D30CA0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000228")]
		[field: Token(Token = "0x4001358")]
		[field: FieldOffset(Offset = "0x20")]
		public List<ValidationWarning> Warnings
		{
			[Token(Token = "0x60017F0")]
			[Address(RVA = "0x3D30CA8", Offset = "0x3D30CA8", Length = "0x8")]
			get;
			[Token(Token = "0x60017F1")]
			[Address(RVA = "0x3D30CB0", Offset = "0x3D30CB0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60017F2")]
		[Address(RVA = "0x3D30CB8", Offset = "0x3D30CB8", Length = "0xE0")]
		public ValidationResult()
		{
			List<ValidationError> list = new List<ValidationError>();
			Errors = list;
			List<ValidationWarning> list2 = new List<ValidationWarning>();
			Warnings = list2;
		}
	}
}
