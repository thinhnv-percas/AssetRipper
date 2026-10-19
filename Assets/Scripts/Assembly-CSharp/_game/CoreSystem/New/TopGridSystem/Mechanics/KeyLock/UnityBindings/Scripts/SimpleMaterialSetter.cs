using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001ED")]
	public class SimpleMaterialSetter : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000637")]
		[FieldOffset(Offset = "0x20")]
		internal Renderer m_renderer;

		[Token(Token = "0x60008D5")]
		[Address(RVA = "0x3E842DC", Offset = "0x3E842DC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Renderer::set_sharedMaterial(this.m_renderer, material);\n\treturn;\n")]
		public void SetMaterial(Material material)
		{
			m_renderer.sharedMaterial = material;
		}

		[Token(Token = "0x60008D6")]
		[Address(RVA = "0x3E88D54", Offset = "0x3E88D54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SimpleMaterialSetter()
		{
		}
	}
}
