using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x200000A")]
	public class ShareOnlyActivate : MonoBehaviour
	{
		[Token(Token = "0x6000012")]
		[Address(RVA = "0x3C2EBA0", Offset = "0x3C2EBA0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v7, 0);\n\treturn;\n")]
		private void Start()
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x3C2EBD0", Offset = "0x3C2EBD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ShareOnlyActivate()
		{
		}
	}
}
