using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts
{
	[Token(Token = "0x2000447")]
	public class VacuumSpawner : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000D81")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_vacuumPos;

		[SerializeField]
		[Token(Token = "0x4000D82")]
		[FieldOffset(Offset = "0x28")]
		private Transform m_spitPos;

		[SerializeField]
		[Token(Token = "0x4000D83")]
		[FieldOffset(Offset = "0x30")]
		private VacuumMono m_vacuumPrefab;

		[SerializeField]
		[Token(Token = "0x4000D84")]
		[FieldOffset(Offset = "0x38")]
		private TweenSettings m_moveToSpitPosTweenSettings;

		[Token(Token = "0x4000D85")]
		[FieldOffset(Offset = "0x68")]
		private VacuumMono _instance;

		[Token(Token = "0x17000189")]
		public VacuumMono ActiveInstance
		{
			[Token(Token = "0x60011F2")]
			[Address(RVA = "0x3CC70C0", Offset = "0x3CC70C0", Length = "0x8")]
			get
			{
				return _instance;
			}
		}

		[Token(Token = "0x1700018A")]
		public Vector3 MouthWorldPosition
		{
			[Token(Token = "0x60011F3")]
			[Address(RVA = "0x3CC6FEC", Offset = "0x3CC6FEC", Length = "0xC0")]
			get
			{
				if (ActiveInstance != null)
				{
					return ActiveInstance.MouthWorldPosition;
				}
				return m_vacuumPos.position;
			}
		}

		[Token(Token = "0x60011F4")]
		[Address(RVA = "0x3CC70C8", Offset = "0x3CC70C8", Length = "0x19C")]
		public VacuumMono SpawnVacuum()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumSpawner::SpawnVacuum");
			return default;
		}

		[Token(Token = "0x60011F5")]
		[Address(RVA = "0x3CC7264", Offset = "0x3CC7264", Length = "0xEC")]
		public void DestroyVacuum()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumSpawner::DestroyVacuum");
		}

		[Token(Token = "0x60011F6")]
		[Address(RVA = "0x3CC7350", Offset = "0x3CC7350", Length = "0x114")]
		public Sequence MoveVacuumToSpitPos()
		{
			Sequence sequence = Sequence.Create();
			Transform target = ActiveInstance.transform;
			Vector3 position = m_spitPos.position;
			TweenSettings moveToSpitPosTweenSettings = m_moveToSpitPosTweenSettings;
			Tween tween = Tween.Position(target, position, moveToSpitPosTweenSettings);
			Sequence result = default(Sequence);
			Sequence sequence2 = result.Group(tween);
			Transform target2 = ActiveInstance.transform;
			Quaternion rotation = m_spitPos.rotation;
			moveToSpitPosTweenSettings = m_moveToSpitPosTweenSettings;
			Tween tween2 = Tween.Rotation(target2, rotation, moveToSpitPosTweenSettings);
			Sequence sequence3 = result.Group(tween2);
			return result;
		}

		[Token(Token = "0x60011F7")]
		[Address(RVA = "0x3CC7464", Offset = "0x3CC7464", Length = "0x8")]
		public VacuumSpawner()
		{
		}
	}
}
