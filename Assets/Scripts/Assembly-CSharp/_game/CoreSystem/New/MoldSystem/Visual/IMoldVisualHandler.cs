using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.Visual
{
	[Token(Token = "0x20002AB")]
	public interface IMoldVisualHandler
	{
		[Token(Token = "0x6000BDF")]
		void InitVisuals(Transform visualParent);

		[Token(Token = "0x6000BE0")]
		void Cleanup();

		[Token(Token = "0x6000BE1")]
		[Address(RVA = "0x3ECCF48", Offset = "0x3ECCF48", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void SyncWithData(EntityManager oldData)
		{
		}
	}
}
