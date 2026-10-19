using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000384")]
	public sealed class StreamJsonEvent
	{
		[Token(Token = "0x1700011F")]
		[field: Token(Token = "0x4000ACB")]
		[field: FieldOffset(Offset = "0x10")]
		public StreamJsonEventKind Kind
		{
			[Token(Token = "0x6000EB1")]
			[Address(RVA = "0x3F17234", Offset = "0x3F17234", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000120")]
		[field: Token(Token = "0x4000ACC")]
		[field: FieldOffset(Offset = "0x18")]
		public string Text
		{
			[Token(Token = "0x6000EB2")]
			[Address(RVA = "0x3F1723C", Offset = "0x3F1723C", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000121")]
		[field: Token(Token = "0x4000ACD")]
		[field: FieldOffset(Offset = "0x20")]
		public string ToolName
		{
			[Token(Token = "0x6000EB3")]
			[Address(RVA = "0x3F17244", Offset = "0x3F17244", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000122")]
		[field: Token(Token = "0x4000ACE")]
		[field: FieldOffset(Offset = "0x28")]
		public TokenUsage Usage
		{
			[Token(Token = "0x6000EB4")]
			[Address(RVA = "0x3F1724C", Offset = "0x3F1724C", Length = "0x8")]
			get;
		}

		[Token(Token = "0x6000EB5")]
		[Address(RVA = "0x3F17254", Offset = "0x3F17254", Length = "0xBC")]
		private StreamJsonEvent(StreamJsonEventKind kind, string text, string toolName = null, TokenUsage usage = null)
		{
			Kind = kind;
			string text2;
			if (text != null)
			{
				Text = text;
				bool flag = toolName == null;
				text2 = toolName;
				if (!flag)
				{
					goto IL_0054;
				}
			}
			else
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v7 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v8+B8]");
				object obj2 = 0;
				Text = (string)obj2;
				bool flag2 = toolName == null;
				bool flag3 = !flag2;
				text2 = toolName;
				if (flag3)
				{
					goto IL_0054;
				}
			}
			int num2 = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v3 (System.Int32)+90]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v4+B8]");
			object obj4 = 0;
			text2 = (string)obj4;
			goto IL_0054;
			IL_0054:
			ToolName = text2;
			Usage = usage;
		}

		[Token(Token = "0x6000EB6")]
		[Address(RVA = "0x3F17310", Offset = "0x3F17310", Length = "0xD2C")]
		public static StreamJsonEvent Parse(string line)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("StreamJsonEvent::Parse");
			return default;
		}
	}
}
