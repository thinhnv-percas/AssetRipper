using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000066")]
	public class CandyPotSystem : UpdateSystem
	{
		[Token(Token = "0x60000C6")]
		[Address(RVA = "0xCC4A00", Offset = "0xCC4A00", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnAwake()
		{
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0xCC4A04", Offset = "0xCC4A04", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnUpdate(float deltaTime)
		{
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0xCC4A08", Offset = "0xCC4A08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CandyPotSystem()
		{
		}
	}
}
