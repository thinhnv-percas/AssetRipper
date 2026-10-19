using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A3")]
	public readonly struct SandParticleParams
	{
		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0x0")]
		public readonly int ParticlesPerCube;

		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0x4")]
		public readonly float ParticleRadius;

		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0x8")]
		public readonly float ParticleVisualSize;

		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0xC")]
		public readonly float SpatialHashCellSize;

		[Token(Token = "0x6000295")]
		[Address(RVA = "0x3C79EF4", Offset = "0x3C79EF4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ParticlesPerCube = particlesPerCube;\n\tthis.ParticleRadius = particleRadius;\n\tthis.ParticleVisualSize = particleVisualSize;\n\tthis.SpatialHashCellSize = spatialHashCellSize;\n\treturn;\n")]
		public SandParticleParams(int particlesPerCube, float particleRadius, float particleVisualSize, float spatialHashCellSize)
		{
			ParticlesPerCube = particlesPerCube;
			ParticleRadius = particleRadius;
			ParticleVisualSize = particleVisualSize;
			SpatialHashCellSize = spatialHashCellSize;
		}
	}
}
