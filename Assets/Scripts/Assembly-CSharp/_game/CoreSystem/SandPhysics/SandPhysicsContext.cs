using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Entities;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.SandPhysics.SDF;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A8")]
	public class SandPhysicsContext
	{
		[Token(Token = "0x17000073")]
		[field: Token(Token = "0x4000205")]
		public static SandPhysicsContext Current
		{
			[Token(Token = "0x60002C5")]
			[Address(RVA = "0x3C7B7E0", Offset = "0x3C7B7E0", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<Current>k__BackingField;\n")]
			get;
			[Token(Token = "0x60002C6")]
			[Address(RVA = "0x3C7B82C", Offset = "0x3C7B82C", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.<Current>k__BackingField = value;\n\treturn;\n")]
			internal set;
		}

		[Token(Token = "0x17000074")]
		[field: Token(Token = "0x4000206")]
		[field: FieldOffset(Offset = "0x10")]
		public SandCollisionService Collision
		{
			[Token(Token = "0x60002C7")]
			[Address(RVA = "0x3C7B888", Offset = "0x3C7B888", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Collision;\n")]
			get;
		}

		[Token(Token = "0x17000075")]
		[field: Token(Token = "0x4000207")]
		[field: FieldOffset(Offset = "0x18")]
		public MovingCubeRegistry MovingCubes
		{
			[Token(Token = "0x60002C8")]
			[Address(RVA = "0x3C7B890", Offset = "0x3C7B890", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MovingCubes;\n")]
			get;
		}

		[Token(Token = "0x17000076")]
		[field: Token(Token = "0x4000208")]
		[field: FieldOffset(Offset = "0x20")]
		public SandBreakEventQueue BreakQueue
		{
			[Token(Token = "0x60002C9")]
			[Address(RVA = "0x3C7B898", Offset = "0x3C7B898", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.BreakQueue;\n")]
			get;
		}

		[Token(Token = "0x17000077")]
		[field: Token(Token = "0x4000209")]
		[field: FieldOffset(Offset = "0x28")]
		public SandParticleQueries Queries
		{
			[Token(Token = "0x60002CA")]
			[Address(RVA = "0x3C7B8A0", Offset = "0x3C7B8A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Queries;\n")]
			get;
		}

		[Token(Token = "0x17000078")]
		[field: Token(Token = "0x400020A")]
		[field: FieldOffset(Offset = "0x30")]
		public SandRenderingAssetsSO RenderAssets
		{
			[Token(Token = "0x60002CB")]
			[Address(RVA = "0x3C7B8A8", Offset = "0x3C7B8A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.RenderAssets;\n")]
			get;
		}

		[Token(Token = "0x17000079")]
		[field: Token(Token = "0x400020B")]
		[field: FieldOffset(Offset = "0x38")]
		public SandParticleParams Params
		{
			[Token(Token = "0x60002CC")]
			[Address(RVA = "0x3C7B8B0", Offset = "0x3C7B8B0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Params>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x1700007A")]
		[field: Token(Token = "0x400020C")]
		[field: FieldOffset(Offset = "0x48")]
		public SandPhysicsConfig Config
		{
			[Token(Token = "0x60002CD")]
			[Address(RVA = "0x3C7B8BC", Offset = "0x3C7B8BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Config;\n")]
			get;
		}

		[Token(Token = "0x1700007B")]
		[field: Token(Token = "0x400020D")]
		[field: FieldOffset(Offset = "0x50")]
		public Entity PrototypeEntity
		{
			[Token(Token = "0x60002CE")]
			[Address(RVA = "0x3C7B8C4", Offset = "0x3C7B8C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.PrototypeEntity;\n")]
			get;
		}

		[Token(Token = "0x1700007C")]
		[field: Token(Token = "0x400020E")]
		[field: FieldOffset(Offset = "0x58")]
		public SandPhysicsBuffers Buffers
		{
			[Token(Token = "0x60002CF")]
			[Address(RVA = "0x3C7B8CC", Offset = "0x3C7B8CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Buffers;\n")]
			get;
		}

		[Token(Token = "0x1700007D")]
		[field: Token(Token = "0x400020F")]
		[field: FieldOffset(Offset = "0x60")]
		public ConveyorController Conveyor
		{
			[Token(Token = "0x60002D0")]
			[Address(RVA = "0x3C7B8D4", Offset = "0x3C7B8D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Conveyor;\n")]
			get;
		}

		[Token(Token = "0x1700007E")]
		[field: Token(Token = "0x4000210")]
		[field: FieldOffset(Offset = "0x68")]
		public SandSDFService SDF
		{
			[Token(Token = "0x60002D1")]
			[Address(RVA = "0x3C7B8DC", Offset = "0x3C7B8DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SDF;\n")]
			get;
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0x3C7A4A8", Offset = "0x3C7A4A8", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Collision = collision;\n\tthis.MovingCubes = movingCubes;\n\tthis.BreakQueue = breakQueue;\n\tthis.Queries = queries;\n\tthis.RenderAssets = renderAssets;\n\tthis.<Params>k__BackingField = resolvedParams;\n\tthis.<Params>k__BackingField.ParticleVisualSize = v29;\n\tthis.Config = config;\n\tthis.PrototypeEntity = prototypeEntity;\n\tthis.Buffers = buffers;\n\tthis.Conveyor = conveyor;\n\tthis.SDF = sdf;\n\treturn;\n")]
		public SandPhysicsContext(SandCollisionService collision, MovingCubeRegistry movingCubes, SandBreakEventQueue breakQueue, SandParticleQueries queries, SandRenderingAssetsSO renderAssets, SandParticleParams resolvedParams, SandPhysicsConfig config, Entity prototypeEntity, SandPhysicsBuffers buffers, ConveyorController conveyor, SandSDFService sdf)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsContext::.ctor");
		}
	}
}
