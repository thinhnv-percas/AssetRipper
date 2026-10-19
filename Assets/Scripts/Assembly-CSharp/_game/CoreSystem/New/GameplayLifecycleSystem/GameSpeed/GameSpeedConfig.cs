using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Serializable]
	[Token(Token = "0x200040B")]
	public class GameSpeedConfig
	{
		[Token(Token = "0x4000CCA")]
		[FieldOffset(Offset = "0x10")]
		public SpeedProfile defaultProfile;

		[Token(Token = "0x4000CCB")]
		[FieldOffset(Offset = "0x18")]
		public TapSpeedProfile tapSpeed;

		[Token(Token = "0x4000CCC")]
		[FieldOffset(Offset = "0x20")]
		public SpeedProfile certainWin;

		[Token(Token = "0x60010F0")]
		[Address(RVA = "0x3CB765C", Offset = "0x3CB765C", Length = "0x12C")]
		public GameSpeedConfig()
		{
			SpeedProfile speedProfile = new SpeedProfile();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj = default(object);
			speedProfile.conveyor = (float)obj;
			speedProfile.mold = 1.8f;
			defaultProfile = speedProfile;
			TapSpeedProfile tapSpeedProfile = new TapSpeedProfile();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			tapSpeedProfile.conveyor = (float)obj;
			tapSpeedProfile.mold = 2.7f;
			tapSpeedProfile.enabled = true;
			tapSpeedProfile.unlockLevel = 0;
			tapSpeed = tapSpeedProfile;
			SpeedProfile speedProfile2 = new SpeedProfile();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			speedProfile2.conveyor = (float)obj;
			speedProfile2.mold = 3.6f;
			certainWin = speedProfile2;
		}
	}
}
