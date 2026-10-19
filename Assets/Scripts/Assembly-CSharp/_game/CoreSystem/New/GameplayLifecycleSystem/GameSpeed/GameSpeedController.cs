using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Token(Token = "0x200040C")]
	public class GameSpeedController : IDisposable
	{
		[Token(Token = "0x200040D")]
		private sealed class Handle : IGameSpeedHandle, IDisposable
		{
			[Token(Token = "0x4000CD1")]
			[FieldOffset(Offset = "0x10")]
			private GameSpeedController _owner;

			[Token(Token = "0x4000CD2")]
			[FieldOffset(Offset = "0x18")]
			private readonly string _key;

			[Token(Token = "0x60010FB")]
			[Address(RVA = "0x3CBB454", Offset = "0x3CBB454", Length = "0x50")]
			public Handle(GameSpeedController owner, string key)
			{
				_owner = owner;
				_key = key;
			}

			[Token(Token = "0x60010FC")]
			[Address(RVA = "0x3CBB8F4", Offset = "0x3CBB8F4", Length = "0x18")]
			public void SetMultiplier(float multiplier)
			{
				if (_owner != null)
				{
					_owner.UpdateRequest(_key, multiplier);
				}
			}

			[Token(Token = "0x60010FD")]
			[Address(RVA = "0x3CBB90C", Offset = "0x3CBB90C", Length = "0xA4")]
			public void Dispose()
			{
				GameSpeedController owner = _owner;
				if (_owner != null)
				{
					_owner = null;
					if (!owner._disposed && owner._activeRequests.Remove(_key))
					{
						_owner.Apply();
					}
				}
			}
		}

		[Token(Token = "0x4000CCD")]
		private const float BaselineMultiplier = 1f;

		[Token(Token = "0x4000CCE")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Dictionary<string, float> _activeRequests;

		[Token(Token = "0x4000CCF")]
		[FieldOffset(Offset = "0x18")]
		internal float _appliedMultiplier;

		[Token(Token = "0x4000CD0")]
		[FieldOffset(Offset = "0x1C")]
		private bool _disposed;

		[Token(Token = "0x17000157")]
		public float CurrentMultiplier
		{
			[Token(Token = "0x60010F1")]
			[Address(RVA = "0x3CBB21C", Offset = "0x3CBB21C", Length = "0x8")]
			get
			{
				return _appliedMultiplier;
			}
		}

		[Token(Token = "0x60010F2")]
		[Address(RVA = "0x3CB3C7C", Offset = "0x3CB3C7C", Length = "0x1B4")]
		public IGameSpeedHandle RequestSpeed(string key, float multiplier)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameSpeedController::RequestSpeed");
			return default;
		}

		[Token(Token = "0x60010F3")]
		[Address(RVA = "0x3CBB4A4", Offset = "0x3CBB4A4", Length = "0x12C")]
		public void SetRequest(string key, float multiplier)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameSpeedController::SetRequest");
		}

		[Token(Token = "0x60010F4")]
		[Address(RVA = "0x3CBB5D0", Offset = "0x3CBB5D0", Length = "0x98")]
		public void ClearRequest(string key)
		{
			if (!_disposed && !string.IsNullOrEmpty(key) && _activeRequests.Remove(key))
			{
				Apply();
			}
		}

		[Token(Token = "0x60010F5")]
		[Address(RVA = "0x3CBB668", Offset = "0x3CBB668", Length = "0x7C")]
		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_activeRequests.Clear();
				Time.timeScale = 1f;
				_appliedMultiplier = 1f;
			}
		}

		[Token(Token = "0x60010F6")]
		[Address(RVA = "0x3CBB6E4", Offset = "0x3CBB6E4", Length = "0xF4")]
		private void UpdateRequest(string key, float multiplier)
		{
			if (_disposed || !_activeRequests.ContainsKey(key))
			{
				return;
			}
			float num = Mathf.Abs(multiplier);
			bool flag = num == 1f / 0f;
			float value = 1f;
			if (!flag)
			{
				bool flag2 = num < 1f / 0f;
				bool flag3 = !flag2;
				float num2 = num - 1f / 0f;
				bool flag4 = num2 == 0f;
				bool flag5 = !flag4;
				bool flag6 = flag3 && flag5;
				value = 1f;
				if (!flag6)
				{
					bool flag7 = multiplier < 0f;
					value = 0f;
					if (!flag7)
					{
						value = multiplier;
					}
				}
			}
			_activeRequests[key] = value;
			Apply();
		}

		[Token(Token = "0x60010F7")]
		[Address(RVA = "0x3CBB7D8", Offset = "0x3CBB7D8", Length = "0x88")]
		private void ReleaseRequest(string key)
		{
			string key2 = default(string);
			if (!_disposed && _activeRequests.Remove(key2))
			{
				Apply();
			}
		}

		[Token(Token = "0x60010F8")]
		[Address(RVA = "0x3CBB258", Offset = "0x3CBB258", Length = "0x1FC")]
		private unsafe void Apply()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameSpeedController::Apply");
		}

		[Token(Token = "0x60010F9")]
		[Address(RVA = "0x3CBB224", Offset = "0x3CBB224", Length = "0x34")]
		private static float SanitizeMultiplier(float m)
		{
			float num = Mathf.Abs(m);
			bool flag2;
			bool flag3;
			if (num != 1f / 0f)
			{
				bool flag = num < 1f / 0f;
				flag2 = !flag;
				float num2 = num - 1f / 0f;
				flag3 = num2 == 0f;
			}
			else
			{
				flag2 = true;
				flag3 = false;
			}
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			float result = 1f;
			if (!flag5)
			{
				result = ((!(m < 0f)) ? m : 0f);
			}
			return result;
		}

		[Token(Token = "0x60010FA")]
		[Address(RVA = "0x3CBB860", Offset = "0x3CBB860", Length = "0x94")]
		public GameSpeedController()
		{
			Dictionary<string, float> activeRequests = new Dictionary<string, float>();
			_activeRequests = activeRequests;
			_appliedMultiplier = 1f;
		}
	}
}
