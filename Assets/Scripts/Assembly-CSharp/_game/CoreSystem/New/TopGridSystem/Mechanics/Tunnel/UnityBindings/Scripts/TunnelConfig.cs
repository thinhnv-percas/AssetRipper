using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts
{
	[Token(Token = "0x200014A")]
	public class TunnelConfig : ScriptableObject
	{
		[Token(Token = "0x400042F")]
		[FieldOffset(Offset = "0x18")]
		public GameObject tunnelPrefab;

		[Token(Token = "0x4000430")]
		[FieldOffset(Offset = "0x20")]
		public TweenSettings tunnelTweenSettings;

		[Token(Token = "0x6000672")]
		[Address(RVA = "0x3DB6708", Offset = "0x3DB6708", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public TunnelConfig()
		{
		}
	}
}
