using Cpp2ILInjected;
using UnityEngine;

namespace _game.Scripts.Ui
{
	[Token(Token = "0x2000701")]
	public class AutoRotator : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400177B")]
		[FieldOffset(Offset = "0x20")]
		private Vector3 m_rotationSpeed;

		[Token(Token = "0x6001D89")]
		[Address(RVA = "0x3D7A558", Offset = "0x3D7A558", Length = "0x64")]
		private void Update()
		{
			Transform transform = base.transform;
			float deltaTime = Time.deltaTime;
			float z = m_rotationSpeed.z * deltaTime;
			float y = m_rotationSpeed.y * deltaTime;
			float x = m_rotationSpeed.x * deltaTime;
			Vector3 eulers = default(Vector3);
			eulers.x = x;
			eulers.y = y;
			eulers.z = z;
			transform.Rotate(eulers);
		}

		[Token(Token = "0x6001D8A")]
		[Address(RVA = "0x3D7A5BC", Offset = "0x3D7A5BC", Length = "0x10")]
		public AutoRotator()
		{
			m_rotationSpeed = default(Vector3);
			m_rotationSpeed.z = 0f;
		}
	}
}
