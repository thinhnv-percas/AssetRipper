using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Utils
{
	[Token(Token = "0x2000004")]
	public class AutoDestroyer : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private float lifetime;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81E37DC", Offset = "0x81E37DC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv50 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0030;\nL_0030:\n\tUnityEngine.Object::Destroy(v50, this.lifetime);\n\treturn;\n")]
		private void Start()
		{
			GameObject obj = base.gameObject;
			Object.Destroy(obj, lifetime);
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81E3864", Offset = "0x81E3864", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lifetime = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AutoDestroyer()
		{
			lifetime = 1f;
		}
	}
}
