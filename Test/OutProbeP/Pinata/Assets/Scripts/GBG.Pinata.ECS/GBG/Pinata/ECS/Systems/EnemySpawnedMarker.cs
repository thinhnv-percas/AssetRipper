using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;

namespace GBG.Pinata.ECS.Systems
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x2000072")]
	public struct EnemySpawnedMarker : IComponent
	{
	}
}
