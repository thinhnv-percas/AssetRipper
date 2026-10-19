using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x200043E")]
	public struct AtGateTag_Headless : IEntityData
	{
		[Token(Token = "0x60011AC")]
		[Address(RVA = "0x3CC35BC", Offset = "0x3CC35BC", Length = "0x64")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AtGateTag_Headless::Apply");
		}
	}
}
