using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000004")]
	public interface IObiParticleCollection
	{
		[Token(Token = "0x17000001")]
		int particleCount
		{
			[Token(Token = "0x60000A9")]
			get;
		}

		[Token(Token = "0x17000002")]
		int activeParticleCount
		{
			[Token(Token = "0x60000AA")]
			get;
		}

		[Token(Token = "0x17000003")]
		bool usesOrientedParticles
		{
			[Token(Token = "0x60000AB")]
			get;
		}

		[Token(Token = "0x60000AC")]
		int GetParticleRuntimeIndex(int index);

		[Token(Token = "0x60000AD")]
		Vector3 GetParticlePosition(int index);

		[Token(Token = "0x60000AE")]
		Quaternion GetParticleOrientation(int index);

		[Token(Token = "0x60000AF")]
		void GetParticleAnisotropy(int index, ref Vector4 b1, ref Vector4 b2, ref Vector4 b3);

		[Token(Token = "0x60000B0")]
		float GetParticleMaxRadius(int index);

		[Token(Token = "0x60000B1")]
		Color GetParticleColor(int index);
	}
}
