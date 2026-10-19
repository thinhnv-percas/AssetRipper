using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Examples
{
	[Token(Token = "0x2000008")]
	public class MenuController : MonoBehaviour
	{
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x20")]
		public CameraController m_Player;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x3C2E7B8", Offset = "0x3C2E7B8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_Player, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0044;\n\treturn;\nL_0044:\n\tUnityEngine.Behaviour::set_enabled(this.m_Player, 0);\n\treturn;\n")]
		private void Awake()
		{
			if (!(m_Player == null))
			{
				m_Player.enabled = false;
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x3C2E874", Offset = "0x3C2E874", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_Player, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_003D;\n\treturn;\nL_003D:\n\tUnityEngine.Behaviour::set_enabled(this.m_Player, 1);\n\tv103 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v103, 0);\n\treturn;\n")]
		public void OnButtonClickCallback()
		{
			if (!(m_Player == null))
			{
				m_Player.enabled = true;
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			}
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x3C2E94C", Offset = "0x3C2E94C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MenuController()
		{
		}
	}
}
