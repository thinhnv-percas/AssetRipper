using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000021")]
	public enum Collision2DType
	{
		[Token(Token = "0x400004F")]
		OnCollisionEnter2D = 0,
		[Token(Token = "0x4000050")]
		OnCollisionStay2D = 1,
		[Token(Token = "0x4000051")]
		OnCollisionExit2D = 2,
		[Token(Token = "0x4000052")]
		OnParticleCollision = 3
	}
}
