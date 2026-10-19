using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Ui.Animations
{
	[Token(Token = "0x2000578")]
	public class MonoRotator : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40012DC")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_target;

		[SerializeField]
		[Token(Token = "0x40012DD")]
		[FieldOffset(Offset = "0x28")]
		private Vector3 m_rotation;

		[SerializeField]
		[Token(Token = "0x40012DE")]
		[FieldOffset(Offset = "0x34")]
		private bool m_enabled;

		[SerializeField]
		[Token(Token = "0x40012DF")]
		[FieldOffset(Offset = "0x35")]
		private bool m_useUnscaledTime;

		[Token(Token = "0x60016FC")]
		[Address(RVA = "0x3D24FEC", Offset = "0x3D24FEC", Length = "0xC8")]
		private void Awake()
		{
			if (m_target == null)
			{
				Transform target = base.transform;
				m_target = target;
			}
		}

		[Token(Token = "0x60016FD")]
		[Address(RVA = "0x3D250B4", Offset = "0x3D250B4", Length = "0x74")]
		private void Update()
		{
			if (m_enabled)
			{
				float num = ((!m_useUnscaledTime) ? Time.deltaTime : Time.unscaledDeltaTime);
				float z = num * m_rotation.z;
				float y = num * m_rotation.y;
				float x = num * m_rotation.x;
				Vector3 eulers = default(Vector3);
				eulers.x = x;
				eulers.y = y;
				eulers.z = z;
				m_target.Rotate(eulers);
			}
		}

		[Token(Token = "0x60016FE")]
		[Address(RVA = "0x3D25128", Offset = "0x3D25128", Length = "0x10")]
		public MonoRotator()
		{
			m_useUnscaledTime = true;
		}
	}
}
