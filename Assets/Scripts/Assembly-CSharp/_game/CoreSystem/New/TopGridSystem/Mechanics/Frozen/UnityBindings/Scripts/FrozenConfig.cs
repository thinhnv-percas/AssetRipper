using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts
{
	[CreateAssetMenu(fileName = "FrozenConfig", menuName = "SandOut/FrozenConfig")]
	[Token(Token = "0x2000238")]
	public class FrozenConfig : ScriptableObject
	{
		[Tooltip("Central ice mesh spawned over the frozen cube. May expose a FrozenIceMono to render progressive state.")]
		[Token(Token = "0x40006D6")]
		[FieldOffset(Offset = "0x18")]
		public GameObject iceMeshPrefab;

		[Tooltip("One-shot ice-break VFX played at the frozen cube centre each time a freezer breaks.")]
		[Token(Token = "0x40006D7")]
		[FieldOffset(Offset = "0x20")]
		public GameObject breakVfxPrefab;

		[Tooltip("One-shot reveal VFX played at the frozen cube centre when the last freezer breaks.")]
		[Token(Token = "0x40006D8")]
		[FieldOffset(Offset = "0x28")]
		public GameObject revealPrefab;

		[Token(Token = "0x60009BA")]
		[Address(RVA = "0x3E99FF0", Offset = "0x3E99FF0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public FrozenConfig()
		{
		}
	}
}
