using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x2000532")]
	public class CameraTrackingHandler
	{
		[Token(Token = "0x400118D")]
		[FieldOffset(Offset = "0x10")]
		internal Camera _camera;

		[Token(Token = "0x400118E")]
		[FieldOffset(Offset = "0x18")]
		private Transform _target;

		[Token(Token = "0x400118F")]
		[FieldOffset(Offset = "0x20")]
		private Vector3 _offset;

		[Token(Token = "0x170001F8")]
		public bool IsTracking
		{
			[Token(Token = "0x60015B3")]
			[Address(RVA = "0x3D13E48", Offset = "0x3D13E48", Length = "0x6C")]
			get
			{
				return Target != null;
			}
		}

		[Token(Token = "0x170001F9")]
		public Transform Target
		{
			[Token(Token = "0x60015B4")]
			[Address(RVA = "0x3D13EB4", Offset = "0x3D13EB4", Length = "0x8")]
			get
			{
				return _target;
			}
		}

		[Token(Token = "0x170001FA")]
		[field: Token(Token = "0x4001190")]
		[field: FieldOffset(Offset = "0x2C")]
		public float FollowSpeed
		{
			[Token(Token = "0x60015B5")]
			[Address(RVA = "0x3D13EBC", Offset = "0x3D13EBC", Length = "0x8")]
			get;
			[Token(Token = "0x60015B6")]
			[Address(RVA = "0x3D13EC4", Offset = "0x3D13EC4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001FB")]
		[field: Token(Token = "0x4001191")]
		[field: FieldOffset(Offset = "0x30")]
		public LayerMask RaycastMask
		{
			[Token(Token = "0x60015B7")]
			[Address(RVA = "0x3D13ECC", Offset = "0x3D13ECC", Length = "0x8")]
			get;
			[Token(Token = "0x60015B8")]
			[Address(RVA = "0x3D13ED4", Offset = "0x3D13ED4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60015B9")]
		[Address(RVA = "0x3D13EDC", Offset = "0x3D13EDC", Length = "0x8")]
		public void SetCamera(Camera camera)
		{
			_camera = camera;
		}

		[Token(Token = "0x60015BA")]
		[Address(RVA = "0x3D13EE4", Offset = "0x3D13EE4", Length = "0x158")]
		public unsafe bool TryAcquireTarget()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraTrackingHandler::TryAcquireTarget");
			return default;
		}

		[Token(Token = "0x60015BB")]
		[Address(RVA = "0x3D1403C", Offset = "0x3D1403C", Length = "0x158")]
		public void SetTarget(Transform target)
		{
			Transform target2 = default(Transform);
			_target = target2;
			if (Target != null && _camera != null)
			{
				Transform transform = _camera.transform;
				Vector3 position = transform.position;
				Vector3 position2 = Target.position;
				float x = position.x - position2.x;
				float y = position.y - position2.y;
				float z = position.z - position2.z;
				_offset.x = x;
				_offset.y = y;
				_offset.z = z;
			}
		}

		[Token(Token = "0x60015BC")]
		[Address(RVA = "0x3D14194", Offset = "0x3D14194", Length = "0xC")]
		public void ClearTarget()
		{
			_target = null;
		}

		[Token(Token = "0x60015BD")]
		[Address(RVA = "0x3D141A0", Offset = "0x3D141A0", Length = "0x1FC")]
		public void UpdateFollow()
		{
			if (!(Target == null) && !(_camera == null))
			{
				Vector3 position = Target.position;
				Transform transform = _camera.transform;
				Transform transform2 = _camera.transform;
				Vector3 position2 = transform2.position;
				float deltaTime = Time.deltaTime;
				float num = position.x + _offset.x;
				float num2 = position.y + _offset.y;
				float num3 = position.z + _offset.z;
				float num4 = num3 - position2.z;
				float num5 = FollowSpeed * deltaTime;
				bool flag = num5 < 1f;
				bool flag2 = num5 == 1f;
				bool flag3 = num5 == num5;
				bool flag4 = 1f == 1f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				float num6 = ((!(flag7 && flag8)) ? num5 : 1f);
				float num7 = ((!(num5 < 0f)) ? num6 : 0f);
				float num8 = num4 * num7;
				float z = position2.z + num8;
				float num9 = num2 - position2.y;
				float num10 = num9 * num7;
				float y = position2.y + num10;
				float num11 = num - position2.x;
				float num12 = num11 * num7;
				float x = position2.x + num12;
				Vector3 position3 = default(Vector3);
				position3.x = x;
				position3.y = y;
				position3.z = z;
				transform.position = position3;
			}
		}

		[Token(Token = "0x60015BE")]
		[Address(RVA = "0x3D1439C", Offset = "0x3D1439C", Length = "0x3C")]
		public CameraTrackingHandler()
		{
			FollowSpeed = 5f;
			LayerMask raycastMask = -1;
			RaycastMask = raycastMask;
		}
	}
}
