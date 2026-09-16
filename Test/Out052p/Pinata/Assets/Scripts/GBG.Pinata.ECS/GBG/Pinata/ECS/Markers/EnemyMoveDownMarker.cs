using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;

namespace GBG.Pinata.ECS.Markers
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 1)]
	[Token(Token = "0x200007B")]
	public struct EnemyMoveDownMarker : IComponent
	{
	}
}
