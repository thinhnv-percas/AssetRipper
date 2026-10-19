using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.DomainReload.Runtime;

namespace Unco.SoundSystem.Scripts.Runtime
{
	[Token(Token = "0x2000011")]
	public static class SoundTester
	{
		[ClearOnReload(SoundManager.AudioType.CardMerge)]
		[Token(Token = "0x4000046")]
		public static SoundManager.AudioType MergeSound;

		[ClearOnReload(SoundManager.AudioType.CardReveal)]
		[Token(Token = "0x4000047")]
		public static SoundManager.AudioType RevealSound;

		[ClearOnReload(SoundManager.AudioType.CardFlipper)]
		[Token(Token = "0x4000048")]
		public static SoundManager.AudioType CardFlipper;

		[ClearOnReload(SoundManager.AudioType.HoldCard)]
		[Token(Token = "0x4000049")]
		public static SoundManager.AudioType HoldSound;

		[ClearOnReload(SoundManager.AudioType.MoveCardToEmptySlot)]
		[Token(Token = "0x400004A")]
		public static SoundManager.AudioType MoveEmptySound;

		[ClearOnReload(SoundManager.AudioType.MoveCardBack)]
		[Token(Token = "0x400004B")]
		public static SoundManager.AudioType MoveBack;

		[ClearOnReload(SoundManager.AudioType.WrongMove)]
		[Token(Token = "0x400004C")]
		public static SoundManager.AudioType FailSound;

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x7B9DFD0", Offset = "0x7B9DFD0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv40.MergeSound = *([93B0420]);\n\tv40.MoveEmptySound = 1.44295713799E-312d;\n\tv40.FailSound = 0x45;\n\treturn;\n")]
		static SoundTester()
		{
			//IL_0024: Expected I4, but got F8
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [93B0420]");
			MergeSound = SoundManager.AudioType.None;
			MoveEmptySound = SoundManager.AudioType.None;
			FailSound = SoundManager.AudioType.WrongMove;
		}
	}
}
