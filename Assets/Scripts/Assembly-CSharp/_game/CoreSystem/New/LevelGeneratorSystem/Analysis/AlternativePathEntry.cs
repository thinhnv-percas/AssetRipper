using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Analysis
{
	[Serializable]
	[Token(Token = "0x20003C5")]
	public class AlternativePathEntry
	{
		[Token(Token = "0x4000BDB")]
		[FieldOffset(Offset = "0x10")]
		public int steps;

		[Token(Token = "0x4000BDC")]
		[FieldOffset(Offset = "0x14")]
		public float avgFill;

		[Token(Token = "0x4000BDD")]
		[FieldOffset(Offset = "0x18")]
		public float peakFill;

		[Token(Token = "0x4000BDE")]
		[FieldOffset(Offset = "0x20")]
		public int[] tapX;

		[Token(Token = "0x4000BDF")]
		[FieldOffset(Offset = "0x28")]
		public int[] tapY;

		[Token(Token = "0x4000BE0")]
		[FieldOffset(Offset = "0x30")]
		public string[] tapColor;

		[Token(Token = "0x4000BE1")]
		[FieldOffset(Offset = "0x38")]
		public float[] perStepFill;

		[Token(Token = "0x6000F9B")]
		[Address(RVA = "0x3CA1F14", Offset = "0x3CA1F14", Length = "0x2B0")]
		public AlternativePathEntry()
		{
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D7E6]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v80 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			tapX = Array.Empty<int>();
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X0_v73 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]");
			int num5 = (int)((nint)0 & (nint)1);
			bool flag2 = num5 == 0;
			nint num6 = 0;
			if (flag2)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			tapY = Array.Empty<int>();
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X0_v70 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag3 = num8 == 0;
			nint num9 = 0;
			if (flag3)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			tapColor = Array.Empty<string>();
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X0_v67 (Il2CppClass<System.EmptyArray`1<System.Single>>)+135]");
			int num11 = (int)((nint)0 & (nint)1);
			bool flag4 = num11 == 0;
			nint num12 = 0;
			if (flag4)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X0_v53+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			perStepFill = Array.Empty<float>();
		}
	}
}
