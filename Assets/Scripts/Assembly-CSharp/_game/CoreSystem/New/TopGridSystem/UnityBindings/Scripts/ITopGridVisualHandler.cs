using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts
{
	[Token(Token = "0x2000136")]
	public interface ITopGridVisualHandler
	{
		[Token(Token = "0x600062B")]
		void InitVisuals(Transform visualParent);

		[Token(Token = "0x600062C")]
		void Cleanup();

		[Token(Token = "0x600062D")]
		[Address(RVA = "0x3DB2CF4", Offset = "0x3DB2CF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void SyncWithData(EntityManager oldData)
		{
		}

		[Token(Token = "0x600062E")]
		[Address(RVA = "0x3DB2CF8", Offset = "0x3DB2CF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void OnEntityRemoving(Entity entity)
		{
		}
	}
}
