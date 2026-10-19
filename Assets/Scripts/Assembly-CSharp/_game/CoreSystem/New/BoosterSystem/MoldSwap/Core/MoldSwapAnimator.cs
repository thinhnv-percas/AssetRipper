using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using HighlightPlus;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Core
{
	[Token(Token = "0x2000484")]
	public class MoldSwapAnimator
	{
		[Inject(false)]
		[Token(Token = "0x4000E9A")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x60012B0")]
		[Address(RVA = "0x3CD7CD4", Offset = "0x3CD7CD4", Length = "0x428")]
		public unsafe Sequence PlaySwapArc(EntityId entityId, Vector3 toLocalPos, TweenSettings xS, TweenSettings yS, TweenSettings zS)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapAnimator::PlaySwapArc");
			return default;
		}

		[Token(Token = "0x60012B1")]
		[Address(RVA = "0x3CD82C4", Offset = "0x3CD82C4", Length = "0x290")]
		public unsafe Sequence PlayScaleTo(EntityId entityId, float targetScale, TweenSettings settings)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapAnimator::PlayScaleTo");
			return default;
		}

		[Token(Token = "0x60012B2")]
		[Address(RVA = "0x3CD8554", Offset = "0x3CD8554", Length = "0x1E4")]
		public void SetHighlight(EntityId entityId, bool enabled, HighlightProfile profile = null)
		{
			EntityId id = default(EntityId);
			Entity entity = _em.GetEntity(id);
			EntityMono entityMono;
			if (!_em.IsValid(entity))
			{
				entityMono = null;
			}
			else
			{
				EntityMono monoBinding = entity.GetMonoBinding();
				entityMono = monoBinding;
			}
			if (entityMono == null)
			{
				return;
			}
			HighlightEffect[] componentsInChildren = entityMono.GetComponentsInChildren<HighlightEffect>(includeInactive: true);
			if (enabled)
			{
				if (componentsInChildren.Length < 1)
				{
					return;
				}
				int num = 0;
				do
				{
					if (profile != null)
					{
						componentsInChildren[num].ProfileLoad(profile);
					}
					componentsInChildren[num].SetHighlighted(state: true);
					num++;
				}
				while (num < componentsInChildren.Length);
			}
			else if (componentsInChildren.Length >= 1)
			{
				int num2 = 0;
				do
				{
					componentsInChildren[num2].SetHighlighted(state: false);
					num2++;
				}
				while (num2 < componentsInChildren.Length);
			}
		}

		[Token(Token = "0x60012B3")]
		[Address(RVA = "0x3CD80FC", Offset = "0x3CD80FC", Length = "0x1C8")]
		private List<Transform> CollectTransforms(EntityId entityId)
		{
			EntityId id = default(EntityId);
			Entity entity = _em.GetEntity(id);
			EntityMono entityMono;
			if (!_em.IsValid(entity))
			{
				entityMono = null;
			}
			else
			{
				EntityMono monoBinding = entity.GetMonoBinding();
				entityMono = monoBinding;
			}
			if (entityMono == null)
			{
				return null;
			}
			List<Transform> list = new List<Transform>();
			Transform transform = entityMono.transform;
			list.Add(transform);
			return list;
		}

		[Token(Token = "0x60012B4")]
		[Address(RVA = "0x3CD8738", Offset = "0x3CD8738", Length = "0x64")]
		private Component ResolveBinding(EntityId entityId)
		{
			Entity entity = _em.GetEntity(entityId);
			if (_em.IsValid(entity))
			{
				return entity.GetMonoBinding();
			}
			return null;
		}

		[Token(Token = "0x60012B5")]
		[Address(RVA = "0x3CD79FC", Offset = "0x3CD79FC", Length = "0x8")]
		public MoldSwapAnimator()
		{
		}
	}
}
