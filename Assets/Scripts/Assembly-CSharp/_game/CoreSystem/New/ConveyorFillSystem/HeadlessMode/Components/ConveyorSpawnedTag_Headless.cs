using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x200043F")]
	public struct ConveyorSpawnedTag_Headless : IEntityData
	{
		[Token(Token = "0x60011AD")]
		[Address(RVA = "0x3CC3620", Offset = "0x3CC3620", Length = "0x64")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSpawnedTag_Headless::Apply");
		}
	}
}
