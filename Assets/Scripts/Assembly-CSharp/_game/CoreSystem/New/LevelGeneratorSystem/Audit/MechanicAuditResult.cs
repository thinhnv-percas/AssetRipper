using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Audit
{
	[Token(Token = "0x20003BC")]
	public sealed class MechanicAuditResult
	{
		[Token(Token = "0x4000BC2")]
		[FieldOffset(Offset = "0x10")]
		public MechanicAuditRow[] Rows;

		[Token(Token = "0x4000BC3")]
		[FieldOffset(Offset = "0x18")]
		public bool AnyGrossMismatch;

		[Token(Token = "0x6000F86")]
		[Address(RVA = "0x3C9F42C", Offset = "0x3C9F42C", Length = "0xF4")]
		public MechanicAuditResult()
		{
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D7DC]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v24 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Audit.MechanicAuditRow>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			Rows = Array.Empty<MechanicAuditRow>();
		}
	}
}
