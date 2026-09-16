using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000007")]
public class ParticleCollison : MonoBehaviour
{
	[Token(Token = "0x4000010")]
	[FieldOffset(Offset = "0x18")]
	public GameObject candyBar;

	[Token(Token = "0x6000008")]
	[Address(RVA = "0xCC97E0", Offset = "0xCC97E0", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void OnParticleCollision(GameObject other)
	{
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0xCC97E4", Offset = "0xCC97E4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ParticleCollison()
	{
	}
}
