using Cpp2ILInjected;

namespace Systems.FlowSystem.Scripts.Core
{
	[Token(Token = "0x2000006")]
	public enum FlowId
	{
		[Token(Token = "0x400000A")]
		None = 0,
		[Token(Token = "0x400000B")]
		HealthProtectFlow = 1,
		[Token(Token = "0x400000C")]
		ExampleFollowFlow = 1000,
		[Token(Token = "0x400000D")]
		ExampleRotateTutorial = 1001,
		[Token(Token = "0x400000E")]
		ExampleZoomTutorial = 1002,
		[Token(Token = "0x400000F")]
		ExampleMultipleMaskFlow = 1003,
		[Token(Token = "0x4000010")]
		ExampleTapTutorialWithMaskFlow = 1004,
		[Token(Token = "0x4000011")]
		ForcePourTutorial = 2000,
		[Token(Token = "0x4000012")]
		SwapTutorial = 2001,
		[Token(Token = "0x4000013")]
		VacuumTutorial = 2002
	}
}
