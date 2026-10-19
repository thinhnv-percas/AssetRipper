using System;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Tracking.Trackers
{
	[Serializable]
	[Token(Token = "0x200058B")]
	public class UITracker : ITracker
	{
		[Inject(false)]
		[Token(Token = "0x4001328")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Token(Token = "0x4001329")]
		[FieldOffset(Offset = "0x18")]
		private TrackingRouter _router;

		[Token(Token = "0x600177C")]
		[Address(RVA = "0x3D2D0F4", Offset = "0x3D2D0F4", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new UITracker();
		}

		[Token(Token = "0x600177D")]
		[Address(RVA = "0x3D2D154", Offset = "0x3D2D154", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Token(Token = "0x600177E")]
		[Address(RVA = "0x3D2D15C", Offset = "0x3D2D15C", Length = "0x120")]
		public void BeginTracking()
		{
			Action<UventUiShown> observer = OnUiShown;
			_eventBus.ListenEvent(observer);
			Action<UventUiHidden> observer2 = OnUiHide;
			_eventBus.ListenEvent(observer2);
		}

		[Token(Token = "0x600177F")]
		[Address(RVA = "0x3D2D27C", Offset = "0x3D2D27C", Length = "0x120")]
		public void EndTracking()
		{
			Action<UventUiShown> observer = OnUiShown;
			_eventBus.RemoveListener(observer);
			Action<UventUiHidden> observer2 = OnUiHide;
			_eventBus.RemoveListener(observer2);
		}

		[Token(Token = "0x6001780")]
		[Address(RVA = "0x3D2D39C", Offset = "0x3D2D39C", Length = "0xB0")]
		private void OnUiShown(UventUiShown obj)
		{
			if (obj.sendToAnalytics)
			{
				Params obj2 = Params.New();
				Type uiControllerType = obj.uiControllerType;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v91 @ X8_v4 (System.Type)+1B8] (should have been resolved before IL gen)");
				string value = default(string);
				Params obj3 = obj2.Set("uiControllerType", value);
				_router.Event(TrackingKey.ui_show, obj2);
			}
		}

		[Token(Token = "0x6001781")]
		[Address(RVA = "0x3D2D4D0", Offset = "0x3D2D4D0", Length = "0xB0")]
		private void OnUiHide(UventUiHidden obj)
		{
			if (obj.sendToAnalytics)
			{
				Params obj2 = Params.New();
				Type uiControllerType = obj.uiControllerType;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v91 @ X8_v4 (System.Type)+1B8] (should have been resolved before IL gen)");
				string value = default(string);
				Params obj3 = obj2.Set("uiControllerType", value);
				_router.Event(TrackingKey.ui_hide, obj2);
			}
		}

		[Token(Token = "0x6001782")]
		[Address(RVA = "0x3D2D44C", Offset = "0x3D2D44C", Length = "0x84")]
		private Params GetParams(Type objUIControllerType)
		{
			Params obj = Params.New();
			string name = objUIControllerType.Name;
			Params obj2 = obj.Set("uiControllerType", name);
			return obj;
		}

		[Token(Token = "0x6001783")]
		[Address(RVA = "0x3D2D14C", Offset = "0x3D2D14C", Length = "0x8")]
		public UITracker()
		{
		}
	}
}
