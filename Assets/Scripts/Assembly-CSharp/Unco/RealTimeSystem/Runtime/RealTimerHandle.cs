using Cpp2ILInjected;
using Unco.TimeTaskSystem.Runtime;

namespace Unco.RealTimeSystem.Runtime
{
	[Token(Token = "0x20007F4")]
	public readonly struct RealTimerHandle
	{
		[Token(Token = "0x4001A83")]
		[FieldOffset(Offset = "0x0")]
		internal readonly RealTimeTaskController _controller;

		[Token(Token = "0x4001A84")]
		[FieldOffset(Offset = "0x8")]
		private readonly string _key;

		[Token(Token = "0x60021A2")]
		[Address(RVA = "0x3DC7838", Offset = "0x3DC7838", Length = "0x34")]
		internal RealTimerHandle(RealTimeTaskController controller, string key)
		{
			_controller = controller;
			_key = key;
		}

		[Token(Token = "0x60021A3")]
		[Address(RVA = "0x3DC86E8", Offset = "0x3DC86E8", Length = "0xA8")]
		public void AddTime(float duration)
		{
			RealTimeTaskController controller = _controller;
			if (_controller != null)
			{
				RealTimeTaskController.RealTimerEntry value = default(RealTimeTaskController.RealTimerEntry);
				if (!controller._activeTimers.TryGetValue(_key, out value))
				{
				}
			}
		}

		[Token(Token = "0x60021A4")]
		[Address(RVA = "0x3DC8790", Offset = "0x3DC8790", Length = "0x18")]
		public void Cancel()
		{
			if (_controller != null)
			{
				_controller.Cancel(_key);
			}
		}

		[Token(Token = "0x60021A5")]
		[Address(RVA = "0x3DC87A8", Offset = "0x3DC87A8", Length = "0x18")]
		public void Detach()
		{
			if (_controller != null)
			{
				_controller.Detach(_key);
			}
		}

		[Token(Token = "0x60021A6")]
		[Address(RVA = "0x3DC87C0", Offset = "0x3DC87C0", Length = "0xB4")]
		public float GetRemainingTime()
		{
			RealTimeTaskController controller = _controller;
			if (_controller != null)
			{
				RealTimeTaskController.RealTimerEntry value = default(RealTimeTaskController.RealTimerEntry);
				bool flag = controller._activeTimers.TryGetValue(_key, out value);
				bool flag2 = !flag;
				float result = 0f;
				if (!flag2)
				{
					result = 0f;
				}
				return result;
			}
			return 0f;
		}

		[Token(Token = "0x60021A7")]
		[Address(RVA = "0x3DC8874", Offset = "0x3DC8874", Length = "0xB4")]
		public float GetProgress()
		{
			RealTimeTaskController controller = _controller;
			if (_controller != null)
			{
				RealTimeTaskController.RealTimerEntry value = default(RealTimeTaskController.RealTimerEntry);
				bool flag = controller._activeTimers.TryGetValue(_key, out value);
				bool flag2 = !flag;
				float result = 0f;
				if (!flag2)
				{
					result = 0f;
				}
				return result;
			}
			return 0f;
		}

		[Token(Token = "0x60021A8")]
		[Address(RVA = "0x3DC8928", Offset = "0x3DC8928", Length = "0xA8")]
		public float GetDuration()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimerHandle::GetDuration");
			return default;
		}

		[Token(Token = "0x60021A9")]
		[Address(RVA = "0x3DC89D0", Offset = "0x3DC89D0", Length = "0xB4")]
		public float GetElapsedTime()
		{
			RealTimeTaskController controller = _controller;
			if (_controller != null)
			{
				RealTimeTaskController.RealTimerEntry value = default(RealTimeTaskController.RealTimerEntry);
				bool flag = controller._activeTimers.TryGetValue(_key, out value);
				bool flag2 = !flag;
				float result = 0f;
				if (!flag2)
				{
					result = 0f;
				}
				return result;
			}
			return 0f;
		}

		[Token(Token = "0x60021AA")]
		[Address(RVA = "0x3DC8A84", Offset = "0x3DC8A84", Length = "0xAC")]
		public bool IsActive()
		{
			RealTimeTaskController controller = _controller;
			if (_controller != null)
			{
				RealTimeTaskController.RealTimerEntry value = default(RealTimeTaskController.RealTimerEntry);
				bool flag = controller._activeTimers.TryGetValue(_key, out value);
				if (flag)
				{
					flag = value.TimerHandle.IsValid;
				}
				return flag;
			}
			return false;
		}

		[Token(Token = "0x60021AB")]
		[Address(RVA = "0x3DC8B30", Offset = "0x3DC8B30", Length = "0xA0")]
		public void SubscribeUpdate(OnTimerUpdate callback)
		{
			RealTimeTaskController controller = _controller;
			if (_controller != null)
			{
				RealTimeTaskController.RealTimerEntry value = default(RealTimeTaskController.RealTimerEntry);
				if (!controller._activeTimers.TryGetValue(_key, out value))
				{
				}
			}
		}

		[Token(Token = "0x60021AC")]
		[Address(RVA = "0x3DC8BD0", Offset = "0x3DC8BD0", Length = "0xA0")]
		public void UnsubscribeUpdate(OnTimerUpdate callback)
		{
			RealTimeTaskController controller = _controller;
			if (_controller != null)
			{
				RealTimeTaskController.RealTimerEntry value = default(RealTimeTaskController.RealTimerEntry);
				if (!controller._activeTimers.TryGetValue(_key, out value))
				{
				}
			}
		}
	}
}
