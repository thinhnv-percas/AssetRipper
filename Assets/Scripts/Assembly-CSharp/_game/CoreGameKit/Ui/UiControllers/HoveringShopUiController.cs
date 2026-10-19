using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.Tracking.Events;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000549")]
	public class HoveringShopUiController : UIController
	{
		[Token(Token = "0x40011D8")]
		[FieldOffset(Offset = "0x48")]
		private float _cachedTimeScale;

		[Token(Token = "0x40011D9")]
		[FieldOffset(Offset = "0x4C")]
		private bool _hasCachedTimeScale;

		[Inject(false)]
		[Token(Token = "0x600161E")]
		[Address(RVA = "0x3D18C70", Offset = "0x3D18C70", Length = "0x9C")]
		private void Construct(EventBus eventBus)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HoveringShopUiController::Construct");
		}

		[Token(Token = "0x600161F")]
		[Address(RVA = "0x3D18D50", Offset = "0x3D18D50", Length = "0x48")]
		public override void Hide(Action onComplete)
		{
			bool flag = !_hasCachedTimeScale;
			UIController uIController = this;
			if (!flag)
			{
				Time.timeScale = _cachedTimeScale;
				_hasCachedTimeScale = false;
				uIController = this;
			}
			Action onComplete2 = default(Action);
			uIController.Hide(onComplete2);
		}

		[Token(Token = "0x6001620")]
		[Address(RVA = "0x3D18D0C", Offset = "0x3D18D0C", Length = "0x44")]
		private void CacheAndPauseTimeScale()
		{
			if (!_hasCachedTimeScale)
			{
				float timeScale = Time.timeScale;
				_cachedTimeScale = timeScale;
				_hasCachedTimeScale = true;
				Time.timeScale = 0f;
			}
		}

		[Token(Token = "0x6001621")]
		[Address(RVA = "0x3D18D98", Offset = "0x3D18D98", Length = "0x38")]
		private void RestoreTimeScale()
		{
			if (_hasCachedTimeScale)
			{
				Time.timeScale = _cachedTimeScale;
				_hasCachedTimeScale = false;
			}
		}

		[Token(Token = "0x6001622")]
		[Address(RVA = "0x3D18DD0", Offset = "0x3D18DD0", Length = "0x8")]
		public HoveringShopUiController()
		{
		}
	}
}
