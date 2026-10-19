using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x200052B")]
	public class CameraMovementHandler
	{
		[Token(Token = "0x400116F")]
		[FieldOffset(Offset = "0x10")]
		internal Transform _cameraTransform;

		[Token(Token = "0x4001170")]
		[FieldOffset(Offset = "0x18")]
		internal Camera _camera;

		[Token(Token = "0x170001F2")]
		public bool IsOrthographic
		{
			[Token(Token = "0x6001592")]
			[Address(RVA = "0x3D10D34", Offset = "0x3D10D34", Length = "0xB8")]
			get
			{
				bool flag = _camera != null;
				if (flag)
				{
					return _camera.orthographic;
				}
				return flag;
			}
		}

		[Token(Token = "0x6001593")]
		[Address(RVA = "0x3D130AC", Offset = "0x3D130AC", Length = "0x8")]
		public void SetTarget(Transform cameraTransform)
		{
			_cameraTransform = cameraTransform;
		}

		[Token(Token = "0x6001594")]
		[Address(RVA = "0x3D130B4", Offset = "0x3D130B4", Length = "0x8")]
		public void SetCamera(Camera camera)
		{
			_camera = camera;
		}

		[Token(Token = "0x6001595")]
		[Address(RVA = "0x3D10E90", Offset = "0x3D10E90", Length = "0x1EC")]
		public void DepthMove(float speed)
		{
			if (_camera == null)
			{
				return;
			}
			if (_camera.orthographic)
			{
				float orthographicSize = _camera.orthographicSize;
				float deltaTime = Time.deltaTime;
				float num = deltaTime * speed;
				float num2 = orthographicSize - num;
				if (num2 < 0.1f)
				{
					num2 = 0.1f;
				}
				_camera.orthographicSize = num2;
			}
			else if (_cameraTransform != null)
			{
				Vector3 position = _cameraTransform.position;
				Vector3 forward = _cameraTransform.forward;
				float num3 = forward.x * speed;
				float num4 = forward.y * speed;
				float num5 = forward.z * speed;
				float deltaTime2 = Time.deltaTime;
				float num6 = deltaTime2 * num3;
				float num7 = deltaTime2 * num4;
				float num8 = deltaTime2 * num5;
				float x = position.x + num6;
				float y = position.y + num7;
				float z = position.z + num8;
				Vector3 position2 = default(Vector3);
				position2.x = x;
				position2.y = y;
				position2.z = z;
				_cameraTransform.position = position2;
			}
		}

		[Token(Token = "0x6001596")]
		[Address(RVA = "0x3D11B60", Offset = "0x3D11B60", Length = "0x8")]
		public CameraMovementHandler()
		{
		}
	}
}
