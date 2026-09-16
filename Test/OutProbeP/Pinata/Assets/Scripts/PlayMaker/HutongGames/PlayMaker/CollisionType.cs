using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200001F")]
	public enum CollisionType
	{
		[Token(Token = "0x4000045")]
		OnCollisionEnter = 0,
		[Token(Token = "0x4000046")]
		OnCollisionStay = 1,
		[Token(Token = "0x4000047")]
		OnCollisionExit = 2,
		[Token(Token = "0x4000048")]
		OnControllerColliderHit = 3,
		[Token(Token = "0x4000049")]
		OnParticleCollision = 4
	}
}
