using System;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.ConveyorSystem
{
	[Token(Token = "0x200050F")]
	public class ConveyorUpgradeAnimation : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001116")]
		[FieldOffset(Offset = "0x20")]
		private string m_anim;

		[SerializeField]
		[Token(Token = "0x4001117")]
		[FieldOffset(Offset = "0x28")]
		private Animator m_animator;

		[SerializeField]
		[Token(Token = "0x4001118")]
		[FieldOffset(Offset = "0x30")]
		private GameObject m_conveyor;

		[SerializeField]
		[Token(Token = "0x4001119")]
		[FieldOffset(Offset = "0x38")]
		private GameObject m_levelConveyor;

		[SerializeField]
		[Token(Token = "0x400111A")]
		[FieldOffset(Offset = "0x40")]
		private GameObject m_levelConveyorFrame;

		[SerializeField]
		[Token(Token = "0x400111B")]
		[FieldOffset(Offset = "0x48")]
		private float m_initialDelay;

		[SerializeField]
		[Token(Token = "0x400111C")]
		[FieldOffset(Offset = "0x50")]
		private ParticleSystem m_upgradeVfx;

		[Token(Token = "0x6001530")]
		[Address(RVA = "0x3D0D010", Offset = "0x3D0D010", Length = "0x128")]
		public Sequence PlayAnim()
		{
			Sequence sequence = Sequence.Create();
			Sequence result = default(Sequence);
			Sequence sequence2 = result.ChainDelay(m_initialDelay);
			Action callback = delegate
			{
				m_animator.Play(m_anim);
				GameObject gameObject = m_upgradeVfx.gameObject;
				gameObject.SetActive(value: true);
			};
			Sequence sequence3 = result.ChainCallback(callback);
			Sequence sequence4 = result.ChainDelay(1f);
			Action callback2 = delegate
			{
				m_levelConveyorFrame.SetActive(value: true);
				m_levelConveyor.SetActive(value: true);
				m_conveyor.SetActive(value: false);
			};
			Sequence sequence5 = result.ChainCallback(callback2);
			return result;
		}

		[Token(Token = "0x6001531")]
		[Address(RVA = "0x3D0D138", Offset = "0x3D0D138", Length = "0x58")]
		public void Setup()
		{
			m_levelConveyorFrame.SetActive(value: false);
			m_levelConveyor.SetActive(value: false);
			m_conveyor.SetActive(value: true);
		}

		[Token(Token = "0x6001532")]
		[Address(RVA = "0x3D0D190", Offset = "0x3D0D190", Length = "0x8")]
		public ConveyorUpgradeAnimation()
		{
		}
	}
}
