using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000006")]
	public interface IStructuralConstraintBatch
	{
		[Token(Token = "0x6000100")]
		float GetRestLength(int index);

		[Token(Token = "0x6000101")]
		void SetRestLength(int index, float restLength);

		[Token(Token = "0x6000102")]
		ParticlePair GetParticleIndices(int index);
	}
}
