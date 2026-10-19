using System;
using System.Collections.Generic;
using System.Text;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.VacuumSystem;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts
{
	[Token(Token = "0x2000446")]
	public class VacuumScoreTesterMono : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000D7E")]
		[FieldOffset(Offset = "0x20")]
		private KeyCode m_key;

		[Tooltip("Cube capacity to simulate (keep-playing default = 2, button booster = 5).")]
		[SerializeField]
		[Token(Token = "0x4000D7F")]
		[FieldOffset(Offset = "0x24")]
		private int m_cubeCapacity;

		[Tooltip("Optional explicit mouth position. If unset, uses the live VacuumSpawner anchor, else this GameObject's position.")]
		[SerializeField]
		[Token(Token = "0x4000D80")]
		[FieldOffset(Offset = "0x28")]
		private Transform m_mouthOverride;

		[Token(Token = "0x60011ED")]
		[Address(RVA = "0x3CC5C74", Offset = "0x3CC5C74", Length = "0x3C")]
		private void Update()
		{
			if (Input.GetKeyDown(m_key))
			{
				RunDryRun();
			}
		}

		[Token(Token = "0x60011EE")]
		[Address(RVA = "0x3CC5CB0", Offset = "0x3CC5CB0", Length = "0x1E8")]
		private void RunDryRun()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumScoreTesterMono::RunDryRun");
		}

		[Token(Token = "0x60011EF")]
		[Address(RVA = "0x3CC5E98", Offset = "0x3CC5E98", Length = "0x15C")]
		private float2 ResolveMouth()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumScoreTesterMono::ResolveMouth");
			return default;
		}

		[Token(Token = "0x60011F0")]
		[Address(RVA = "0x3CC5FF4", Offset = "0x3CC5FF4", Length = "0xFF8")]
		private string FormatPlan(VacuumPlan plan, float2 mouth, int capacity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumScoreTesterMono::FormatPlan");
			return default;
		}

		[Token(Token = "0x60011F1")]
		[Address(RVA = "0x3CC70AC", Offset = "0x3CC70AC", Length = "0x14")]
		public VacuumScoreTesterMono()
		{
			m_key = KeyCode.None;
		}
	}
}
