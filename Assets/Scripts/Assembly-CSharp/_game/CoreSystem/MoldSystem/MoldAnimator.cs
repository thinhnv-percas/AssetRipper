using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004A1")]
	public class MoldAnimator : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000F58")]
		[FieldOffset(Offset = "0x20")]
		private float m_completeDuration;

		[SerializeField]
		[Token(Token = "0x4000F59")]
		[FieldOffset(Offset = "0x24")]
		private float m_shiftDuration;

		[SerializeField]
		[Token(Token = "0x4000F5A")]
		[FieldOffset(Offset = "0x28")]
		private float m_openDuration;

		[SerializeField]
		[Token(Token = "0x4000F5B")]
		[FieldOffset(Offset = "0x2C")]
		private float m_revealDuration;

		[SerializeField]
		[Token(Token = "0x4000F5C")]
		[FieldOffset(Offset = "0x30")]
		private float m_completeScale;

		[SerializeField]
		[Token(Token = "0x4000F5D")]
		[FieldOffset(Offset = "0x38")]
		private ShakeSettings m_punchScaleSettings;

		[Inject(false)]
		[Token(Token = "0x4000F5E")]
		[FieldOffset(Offset = "0x78")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000F5F")]
		[FieldOffset(Offset = "0x80")]
		private MoldLinkVisualController _linkVisualController;

		[Token(Token = "0x600133C")]
		[Address(RVA = "0x3CE8244", Offset = "0x3CE8244", Length = "0x3C")]
		private GameObject GetGoByEntityId(int entityId)
		{
			Entity entityByIndex = _em.GetEntityByIndex(entityId);
			GameObject monoBinding = (GameObject)(object)entityByIndex.GetMonoBinding();
			if ((object)monoBinding != null)
			{
				return ((Component)(object)monoBinding).gameObject;
			}
			return monoBinding;
		}

		[Token(Token = "0x600133D")]
		[Address(RVA = "0x3CE8280", Offset = "0x3CE8280", Length = "0x154")]
		public Sequence PlayShiftTween(Entity entity, Vector3 to)
		{
			EntityMono monoBinding = entity.GetMonoBinding();
			GameObject gameObject2;
			if ((object)monoBinding != null)
			{
				GameObject gameObject = monoBinding.gameObject;
				gameObject2 = gameObject;
			}
			else
			{
				gameObject2 = null;
			}
			bool flag = gameObject2 == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Sequence result = default(Sequence);
			if (!flag3)
			{
				Sequence sequence = Sequence.Create();
				Sequence sequence2 = sequence;
				Transform target = gameObject2.transform;
				Tween tween = Tween.Position(target, to, m_shiftDuration, Ease.OutQuad);
				return sequence2.Chain(tween);
			}
			return result;
		}

		[Token(Token = "0x600133E")]
		[Address(RVA = "0x3CE83D4", Offset = "0x3CE83D4", Length = "0xD0")]
		public Sequence PlayCoverOpen(int entityId)
		{
			int index = default(int);
			Entity entityByIndex = _em.GetEntityByIndex(index);
			entityByIndex.GetMonoBinding()?.gameObject?.GetComponent<MoldMonoBase>()?.PlayCoverOpen();
			Sequence sequence = Sequence.Create();
			Sequence sequence2 = sequence;
			return sequence2.ChainDelay(m_openDuration);
		}

		[Token(Token = "0x600133F")]
		[Address(RVA = "0x3CE84A4", Offset = "0x3CE84A4", Length = "0xBC")]
		public Sequence PlayCoverOpen(Entity entity)
		{
			entity.GetMonoBinding()?.gameObject?.GetComponent<MoldMonoBase>()?.PlayCoverOpen();
			Sequence sequence = Sequence.Create();
			Sequence sequence2 = sequence;
			return sequence2.ChainDelay(m_openDuration);
		}

		[Token(Token = "0x6001340")]
		[Address(RVA = "0x3CE8560", Offset = "0x3CE8560", Length = "0x80")]
		public Sequence SetCoverOpenInstant(Entity entity)
		{
			entity.GetMonoBinding()?.gameObject?.GetComponent<MoldMonoBase>()?.SetOpen();
			return default(Sequence);
		}

		[Token(Token = "0x6001341")]
		[Address(RVA = "0x3CE85E0", Offset = "0x3CE85E0", Length = "0x84")]
		public Sequence PlayOnlyCoverClose(Entity entity)
		{
			entity.GetMonoBinding()?.gameObject?.GetComponent<MoldMonoBase>()?.PlayOnlyCoverClose();
			return default(Sequence);
		}

		[Token(Token = "0x6001342")]
		[Address(RVA = "0x3CE8664", Offset = "0x3CE8664", Length = "0x264")]
		public Sequence PlayComplete(Entity entity, Sequence seq = default(Sequence))
		{
			EntityMono monoBinding = entity.GetMonoBinding();
			bool flag = (object)monoBinding == null;
			GameObject gameObject = null;
			if (!flag)
			{
				GameObject gameObject2 = monoBinding.gameObject;
				gameObject = gameObject2;
			}
			GameObject go = gameObject;
			bool flag2 = go == null;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			Sequence result = default(Sequence);
			if (!flag4)
			{
				Sequence result2 = default(Sequence);
				if (!result2.isAlive)
				{
					Sequence sequence = Sequence.Create();
				}
				Transform target = go.transform;
				ShakeSettings punchScaleSettings = m_punchScaleSettings;
				Tween tween = Tween.PunchScale(target, punchScaleSettings);
				Sequence sequence2 = result2.Chain(tween);
				Action callback = delegate
				{
					if (go != null)
					{
						MoldMonoBase component = go.GetComponent<MoldMonoBase>();
						if ((object)component != null)
						{
							component.PlayCoverClose();
							MoldMonoBase moldMonoBase = default(MoldMonoBase);
							moldMonoBase.PlayCompleteVfx();
						}
					}
				};
				Sequence sequence3 = result2.ChainCallback(callback);
				Transform target2 = go.transform;
				Vector3 endValue = default(Vector3);
				endValue.x = Vector3.zero.x;
				endValue.y = Vector3.zero.y;
				endValue.z = Vector3.zero.z;
				Tween tween2 = Tween.Scale(target2, endValue, m_completeDuration, Ease.InBack);
				Sequence sequence4 = result2.Chain(tween2);
				return result2;
			}
			return result;
		}

		[Token(Token = "0x6001343")]
		[Address(RVA = "0x3CE88D0", Offset = "0x3CE88D0", Length = "0x150")]
		public Sequence PlayReveal(Entity entity, GameColor color)
		{
			EntityMono monoBinding = entity.GetMonoBinding();
			GameObject gameObject2;
			if ((object)monoBinding != null)
			{
				GameObject gameObject = monoBinding.gameObject;
				gameObject2 = gameObject;
			}
			else
			{
				gameObject2 = null;
			}
			if (!(gameObject2 == null))
			{
				MoldMonoBase component = gameObject2.GetComponent<MoldMonoBase>();
				if (!(component == null))
				{
					return component.BuildRevealSequence(color);
				}
			}
			return default(Sequence);
		}

		[Token(Token = "0x6001344")]
		[Address(RVA = "0x3CE8A20", Offset = "0x3CE8A20", Length = "0x1C")]
		public Sequence PlayLinkDisappear(Entity entityA, Entity entityB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAnimator::PlayLinkDisappear");
			return default;
		}

		[Token(Token = "0x6001345")]
		[Address(RVA = "0x3CE8A3C", Offset = "0x3CE8A3C", Length = "0x20")]
		public MoldAnimator()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9307EE0]");
			m_completeDuration = 0f;
			m_completeScale = 1.3f;
		}
	}
}
