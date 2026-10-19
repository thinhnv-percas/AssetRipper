using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x200037D")]
	public sealed class LlmUsageLedger
	{
		[Token(Token = "0x200037E")]
		public sealed class Entry
		{
			[Token(Token = "0x4000AB7")]
			[FieldOffset(Offset = "0x10")]
			public string Role;

			[Token(Token = "0x4000AB8")]
			[FieldOffset(Offset = "0x18")]
			public string Model;

			[Token(Token = "0x4000AB9")]
			[FieldOffset(Offset = "0x20")]
			public int Calls;

			[Token(Token = "0x4000ABA")]
			[FieldOffset(Offset = "0x28")]
			public double Seconds;

			[Token(Token = "0x4000ABB")]
			[FieldOffset(Offset = "0x30")]
			public long InputTokens;

			[Token(Token = "0x4000ABC")]
			[FieldOffset(Offset = "0x38")]
			public long OutputTokens;

			[Token(Token = "0x4000ABD")]
			[FieldOffset(Offset = "0x40")]
			public long CacheReadTokens;

			[Token(Token = "0x4000ABE")]
			[FieldOffset(Offset = "0x48")]
			public long CacheCreationTokens;

			[Token(Token = "0x1700011E")]
			public long TotalTokens
			{
				[Token(Token = "0x6000EA8")]
				[Address(RVA = "0x3F16790", Offset = "0x3F16790", Length = "0x14")]
				get
				{
					long result = InputTokens + CacheReadTokens;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction ADDP not yet implemented.\"");
					return result;
				}
			}

			[Token(Token = "0x6000EA9")]
			[Address(RVA = "0x3F16690", Offset = "0x3F16690", Length = "0x74")]
			public Entry()
			{
				Role = "";
				Model = "";
			}
		}

		[Token(Token = "0x4000AB6")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<Entry> _entries;

		[Token(Token = "0x1700011D")]
		public IReadOnlyList<Entry> Entries
		{
			[Token(Token = "0x6000EA5")]
			[Address(RVA = "0x3F163F0", Offset = "0x3F163F0", Length = "0x8")]
			get
			{
				return _entries;
			}
		}

		[Token(Token = "0x6000EA6")]
		[Address(RVA = "0x3F163F8", Offset = "0x3F163F8", Length = "0x290")]
		public void Record(string role, string model, int calls, double seconds, TokenUsage tokens)
		{
			Predicate<Entry> match = (Entry x) => x.Role == role;
			Entry entry = _entries.Find(match);
			bool flag = entry == null;
			bool flag2 = !flag;
			Entry entry2 = entry;
			Entry entry4;
			if (!flag2)
			{
				Entry entry3 = new Entry();
				entry3.Role = "";
				entry3.Model = "";
				entry3.Role = role;
				List<Entry> entries = _entries;
				entries.Add(entry3);
				bool flag3 = string.IsNullOrEmpty(model);
				bool flag4 = !flag3;
				entry2 = entry3;
				if (flag4)
				{
					goto IL_00eb;
				}
				entry4 = entry3;
			}
			else
			{
				bool flag5 = string.IsNullOrEmpty(model);
				bool flag6 = !flag5;
				bool flag7 = !flag6;
				entry4 = entry2;
				if (!flag7)
				{
					goto IL_00eb;
				}
			}
			goto IL_0105;
			IL_0105:
			int calls2 = entry4.Calls + calls;
			entry4.Calls = calls2;
			double seconds2 = entry4.Seconds + seconds;
			entry4.Seconds = seconds2;
			if (tokens != null)
			{
				entry4.OutputTokens = (long)((ulong)(entry4.InputTokens = tokens.InputTokens + entry4.InputTokens) >> 64);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction EXT not yet implemented.\"");
				entry4.CacheCreationTokens = (long)((ulong)(entry4.CacheReadTokens = tokens.CacheCreationTokens + entry4.CacheReadTokens) >> 64);
			}
			return;
			IL_00eb:
			entry2.Model = model;
			entry4 = entry2;
			goto IL_0105;
		}

		[Token(Token = "0x6000EA7")]
		[Address(RVA = "0x3F16704", Offset = "0x3F16704", Length = "0x8C")]
		public LlmUsageLedger()
		{
			List<Entry> entries = new List<Entry>();
			_entries = entries;
		}
	}
}
