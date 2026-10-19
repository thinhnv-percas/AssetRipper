using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Serializable]
	[Token(Token = "0x20003C7")]
	public sealed class ActionError
	{
		[Token(Token = "0x1700013E")]
		[field: Token(Token = "0x4000BE2")]
		[field: FieldOffset(Offset = "0x10")]
		public string Code
		{
			[Token(Token = "0x6000FA1")]
			[Address(RVA = "0x3CA317C", Offset = "0x3CA317C", Length = "0x8")]
			get;
		}

		[Token(Token = "0x1700013F")]
		[field: Token(Token = "0x4000BE3")]
		[field: FieldOffset(Offset = "0x18")]
		public string Message
		{
			[Token(Token = "0x6000FA2")]
			[Address(RVA = "0x3CA3184", Offset = "0x3CA3184", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000140")]
		[field: Token(Token = "0x4000BE4")]
		[field: FieldOffset(Offset = "0x20")]
		public string FixHint
		{
			[Token(Token = "0x6000FA3")]
			[Address(RVA = "0x3CA318C", Offset = "0x3CA318C", Length = "0x8")]
			get;
		}

		[Token(Token = "0x6000FA4")]
		[Address(RVA = "0x3CA3194", Offset = "0x3CA3194", Length = "0x7C")]
		public ActionError(string code, string message, string fixHint = "")
		{
			Code = code;
			Message = message;
			bool flag = fixHint == null;
			bool flag2 = !flag;
			string text = fixHint;
			if (!flag2)
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v4+B8]");
				object obj2 = 0;
				text = (string)obj2;
			}
			FixHint = text;
		}

		[Token(Token = "0x6000FA5")]
		[Address(RVA = "0x3CA3210", Offset = "0x3CA3210", Length = "0x1C8")]
		public override string ToString()
		{
			if (string.IsNullOrEmpty(FixHint))
			{
				return "[" + Code + "] " + Message;
			}
			return "[" + Code + "] " + Message + " (hint: " + FixHint + ")";
		}
	}
}
