using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000376")]
	public sealed class LlmPromptLedger
	{
		[Token(Token = "0x2000377")]
		public sealed class Entry
		{
			[Token(Token = "0x4000A7D")]
			[FieldOffset(Offset = "0x10")]
			public string Role = "";

			[Token(Token = "0x4000A7E")]
			[FieldOffset(Offset = "0x18")]
			public string Label = "";

			[Token(Token = "0x4000A7F")]
			[FieldOffset(Offset = "0x20")]
			public string Text = "";

			[Token(Token = "0x6000E57")]
			[Address(RVA = "0x3F09F5C", Offset = "0x3F09F5C", Length = "0x84")]
			public Entry()
			{
			}
		}

		[Token(Token = "0x4000A7C")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<Entry> _entries;

		[Token(Token = "0x1700011C")]
		public IReadOnlyList<Entry> Entries
		{
			[Token(Token = "0x6000E54")]
			[Address(RVA = "0x3F09C78", Offset = "0x3F09C78", Length = "0x8")]
			get
			{
				return _entries;
			}
		}

		[Token(Token = "0x6000E55")]
		[Address(RVA = "0x3F09C80", Offset = "0x3F09C80", Length = "0x2D4")]
		public void Record(string role, string label, string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				Predicate<Entry> match = (Entry e) => e.Role == role && e.Label == label && e.Text == text;
				if (!_entries.Exists(match))
				{
					List<Entry> entries = _entries;
					Entry entry = new Entry();
					entry.Role = "";
					entry.Label = "";
					entry.Text = "";
					string role2 = ((role != null) ? role : "");
					entry.Role = role2;
					string label2 = ((label != null) ? label : "");
					entry.Label = label2;
					entry.Text = text;
					entries.Add(entry);
				}
			}
		}

		[Token(Token = "0x6000E56")]
		[Address(RVA = "0x3F09FE0", Offset = "0x3F09FE0", Length = "0x8C")]
		public LlmPromptLedger()
		{
			List<Entry> entries = new List<Entry>();
			_entries = entries;
		}
	}
}
