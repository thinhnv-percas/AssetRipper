using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem
{
	[Token(Token = "0x2000007")]
	public abstract class TweenRootElement : MonoBehaviour
	{
		[Token(Token = "0x600000E")]
		internal abstract void Prepare(Sequence sequence, SequenceOperation operation, float insertTime);

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x819F4A0", Offset = "0x819F4A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal TweenRootElement()
		{
		}
	}
}
