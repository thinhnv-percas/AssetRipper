using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.SandPhysics.Components
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x2000117")]
	public struct OnConveyorTag : IComponentData, IQueryTypeParameter, IEnableableComponent
	{
	}
}
