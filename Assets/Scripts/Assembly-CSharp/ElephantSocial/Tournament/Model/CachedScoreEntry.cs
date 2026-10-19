using System;
using Cpp2ILInjected;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000861")]
	public class CachedScoreEntry
	{
		[Token(Token = "0x170003C3")]
		[field: Token(Token = "0x4001C28")]
		[field: FieldOffset(Offset = "0x10")]
		public int Score
		{
			[Token(Token = "0x60023FC")]
			[Address(RVA = "0x3DE9264", Offset = "0x3DE9264", Length = "0x8")]
			get;
			[Token(Token = "0x60023FD")]
			[Address(RVA = "0x3DE926C", Offset = "0x3DE926C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170003C4")]
		[field: Token(Token = "0x4001C29")]
		[field: FieldOffset(Offset = "0x14")]
		public int TournamentId
		{
			[Token(Token = "0x60023FE")]
			[Address(RVA = "0x3DE9274", Offset = "0x3DE9274", Length = "0x8")]
			get;
			[Token(Token = "0x60023FF")]
			[Address(RVA = "0x3DE927C", Offset = "0x3DE927C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170003C5")]
		[field: Token(Token = "0x4001C2A")]
		[field: FieldOffset(Offset = "0x18")]
		public int ScheduleId
		{
			[Token(Token = "0x6002400")]
			[Address(RVA = "0x3DE9284", Offset = "0x3DE9284", Length = "0x8")]
			get;
			[Token(Token = "0x6002401")]
			[Address(RVA = "0x3DE928C", Offset = "0x3DE928C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170003C6")]
		[field: Token(Token = "0x4001C2B")]
		[field: FieldOffset(Offset = "0x20")]
		public long Date
		{
			[Token(Token = "0x6002402")]
			[Address(RVA = "0x3DE9294", Offset = "0x3DE9294", Length = "0x8")]
			get;
			[Token(Token = "0x6002403")]
			[Address(RVA = "0x3DE929C", Offset = "0x3DE929C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170003C7")]
		[field: Token(Token = "0x4001C2C")]
		[field: FieldOffset(Offset = "0x28")]
		public bool Online
		{
			[Token(Token = "0x6002404")]
			[Address(RVA = "0x3DE92A4", Offset = "0x3DE92A4", Length = "0x8")]
			get;
			[Token(Token = "0x6002405")]
			[Address(RVA = "0x3DE92AC", Offset = "0x3DE92AC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002406")]
		[Address(RVA = "0x3DE92B4", Offset = "0x3DE92B4", Length = "0xE4")]
		public override bool Equals(object obj)
		{
			//IL_00eb: Expected O, but got I
			if (obj != null && obj is CachedScoreEntry)
			{
				int score = Score;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
				if ((nint)score == 0)
				{
					int tournamentId = TournamentId;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+14]");
					if ((nint)tournamentId == 0)
					{
						int scheduleId = ScheduleId;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+18]");
						if ((nint)scheduleId == 0)
						{
							long date = Date;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+20]");
							if (date == 0)
							{
								bool online = Online;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+28]");
								object obj2 = (nint)(online ? 1 : 0) - (nint)0;
								return obj2 == null;
							}
						}
					}
				}
			}
			return false;
		}

		[Token(Token = "0x6002407")]
		[Address(RVA = "0x3DE9398", Offset = "0x3DE9398", Length = "0xA8")]
		public override int GetHashCode()
		{
			return HashCode.Combine(Score, TournamentId, ScheduleId, Date, Online);
		}

		[Token(Token = "0x6002408")]
		[Address(RVA = "0x3DE9440", Offset = "0x3DE9440", Length = "0x8")]
		public CachedScoreEntry()
		{
		}
	}
}
