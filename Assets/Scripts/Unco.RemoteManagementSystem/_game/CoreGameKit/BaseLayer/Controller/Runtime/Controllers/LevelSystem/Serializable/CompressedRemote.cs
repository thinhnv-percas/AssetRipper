using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.Controllers.LevelSystem.Serializable
{
	[Token(Token = "0x200000A")]
	public abstract class CompressedRemote : ScriptableObject
	{
		[Token(Token = "0x600001D")]
		[Address(RVA = "0x81C9248", Offset = "0x81C9248", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public CompressedRemote()
		{
		}
	}
}
