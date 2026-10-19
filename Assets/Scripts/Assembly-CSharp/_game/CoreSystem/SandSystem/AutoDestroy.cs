using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.SandSystem
{
	[Token(Token = "0x200008C")]
	public class AutoDestroy : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x20")]
		private float m_lifetime;

		[Token(Token = "0x600026B")]
		[Address(RVA = "0x3C76F28", Offset = "0x3C76F28", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv50 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0030;\nL_0030:\n\tUnityEngine.Object::Destroy(v50, this.m_lifetime);\n\treturn;\n")]
		private void OnEnable()
		{
			GameObject obj = base.gameObject;
			Object.Destroy(obj, m_lifetime);
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0x3C76FB0", Offset = "0x3C76FB0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_lifetime = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AutoDestroy()
		{
			m_lifetime = 1f;
		}
	}
}
