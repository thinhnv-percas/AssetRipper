using Cpp2ILInjected;
using GBG.Pinata.ECS.Schemes;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Token(Token = "0x2000082")]
	public struct HandComponent : IComponent
	{
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x0")]
		public int ID;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x4")]
		public bool IsAttacking;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x5")]
		public bool CanAttack;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x6")]
		public bool IsAnimated;

		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x8")]
		public float Delay;

		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0xC")]
		public Vector3 Offset;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x18")]
		public Transform Transform;

		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x20")]
		public BoxCollider BoxCollider;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x28")]
		public GameObject CurrentWeapon;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x30")]
		public Vector3 DefaultPosition;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x40")]
		public GameObject Prefab;

		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x48")]
		public SpawnConfig SpawnConfig;

		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x58")]
		public Vector3 BoxColliderSize;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x64")]
		public float WeaponSpeed;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x68")]
		public float AttackCooldown;
	}
}
