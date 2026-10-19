using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.Pooling
{
	[Token(Token = "0x2000125")]
	public interface IVfxPool
	{
		[Token(Token = "0x60005EA")]
		GameObject Rent(GameObject prefab, Vector3 worldPos, Quaternion worldRot, Transform parent);

		[Token(Token = "0x60005EB")]
		void Return(GameObject instance, float delay = 0f);

		[Token(Token = "0x60005EC")]
		void Prewarm(GameObject prefab, int count);
	}
}
