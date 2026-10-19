using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Entities;
using UnityEngine;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Token(Token = "0x200040F")]
	public class GameplaySpeedController : IDisposable
	{
		[Token(Token = "0x2000410")]
		private sealed class Handle : IGameplaySpeedHandle, IDisposable
		{
			[Token(Token = "0x4000CDC")]
			[FieldOffset(Offset = "0x10")]
			internal GameplaySpeedController _owner;

			[Token(Token = "0x4000CDD")]
			[FieldOffset(Offset = "0x18")]
			internal readonly string _key;

			[Token(Token = "0x6001111")]
			[Address(RVA = "0x3CBC3B8", Offset = "0x3CBC3B8", Length = "0x50")]
			public Handle(GameplaySpeedController owner, string key)
			{
				_owner = owner;
				_key = key;
			}

			[Token(Token = "0x6001112")]
			[Address(RVA = "0x3CBC928", Offset = "0x3CBC928", Length = "0xA4")]
			public void Dispose()
			{
				GameplaySpeedController owner = _owner;
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

		[Inject(false)]
		[Token(Token = "0x4000CD3")]
		[FieldOffset(Offset = "0x10")]
		private GameSpeedConfig _config;

		[Token(Token = "0x4000CD4")]
		[FieldOffset(Offset = "0x18")]
		internal readonly Dictionary<SpeedProfileId, SpeedProfile> _profiles;

		[Token(Token = "0x4000CD5")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<string, SpeedProfileId> _activeRequests;

		[Token(Token = "0x4000CD6")]
		[FieldOffset(Offset = "0x28")]
		private readonly List<SpeedProfile> _scratch;

		[Token(Token = "0x4000CD7")]
		[FieldOffset(Offset = "0x30")]
		private float _appliedClock;

		[Token(Token = "0x4000CD8")]
		[FieldOffset(Offset = "0x34")]
		private int _appliedMaxSubSteps;

		[Token(Token = "0x4000CD9")]
		[FieldOffset(Offset = "0x38")]
		internal bool _disposed;

		[Token(Token = "0x4000CDA")]
		[FieldOffset(Offset = "0x40")]
		private SandPhysicsSystemGroup _group;

		[Token(Token = "0x4000CDB")]
		[FieldOffset(Offset = "0x48")]
		private float _baselineConveyor;

		[Token(Token = "0x17000158")]
		public float CurrentClock
		{
			[Token(Token = "0x60010FF")]
			[Address(RVA = "0x3CBB9B8", Offset = "0x3CBB9B8", Length = "0x8")]
			get
			{
				return _appliedClock;
			}
		}

		[Token(Token = "0x17000159")]
		public int CurrentMaxSubSteps
		{
			[Token(Token = "0x6001100")]
			[Address(RVA = "0x3CBB9C0", Offset = "0x3CBB9C0", Length = "0x8")]
			get
			{
				return _appliedMaxSubSteps;
			}
		}

		[Token(Token = "0x1700015A")]
		public float CurrentSandScale
		{
			[Token(Token = "0x6001101")]
			[Address(RVA = "0x3CBB9C8", Offset = "0x3CBB9C8", Length = "0x7C")]
			get
			{
				return SandSpeedScales.Sand;
			}
		}

		[Token(Token = "0x1700015B")]
		public float CurrentConveyorScale
		{
			[Token(Token = "0x6001102")]
			[Address(RVA = "0x3CBBA44", Offset = "0x3CBBA44", Length = "0x7C")]
			get
			{
				return SandSpeedScales.Conveyor;
			}
		}

		[Token(Token = "0x1700015C")]
		public float CurrentMoldScale
		{
			[Token(Token = "0x6001103")]
			[Address(RVA = "0x3CBBAC0", Offset = "0x3CBBAC0", Length = "0x7C")]
			get
			{
				return SandSpeedScales.Mold;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001104")]
		[Address(RVA = "0x3CBBB3C", Offset = "0x3CBBB3C", Length = "0x54")]
		private void Initialize()
		{
			GameSpeedConfig config = _config;
			SpeedProfile speedProfile;
			if (_config != null)
			{
				speedProfile = SpeedProfile.Sanitized(config.defaultProfile);
			}
			else
			{
				speedProfile = SpeedProfile.Sanitized(null);
				if (speedProfile == null)
				{
					throw new NullReferenceException();
				}
			}
			_baselineConveyor = speedProfile.conveyor;
			ResetProfilesToConfig();
		}

		[Token(Token = "0x6001105")]
		[Address(RVA = "0x3CBBCAC", Offset = "0x3CBBCAC", Length = "0xC0")]
		public SpeedProfile GetProfile(SpeedProfileId id)
		{
			if (_profiles.TryGetValue(id, out var value))
			{
				return value;
			}
			return new SpeedProfile();
		}

		[Token(Token = "0x6001106")]
		[Address(RVA = "0x3CB782C", Offset = "0x3CB782C", Length = "0x9C")]
		public void SetProfile(SpeedProfileId id, SpeedProfile profile)
		{
			if (!_disposed)
			{
				SpeedProfile value = SpeedProfile.Sanitized(profile);
				_profiles[id] = value;
				Apply();
			}
		}

		[Token(Token = "0x6001107")]
		[Address(RVA = "0x3CBBB90", Offset = "0x3CBBB90", Length = "0x11C")]
		public void ResetProfilesToConfig()
		{
			GameSpeedConfig config = _config;
			SpeedProfile value;
			if (_config != null)
			{
				value = SpeedProfile.Sanitized(config.defaultProfile);
				if (_profiles == null)
				{
					goto IL_018a;
				}
			}
			else
			{
				value = SpeedProfile.Sanitized(null);
			}
			_profiles[default(SpeedProfileId)] = value;
			GameSpeedConfig config2 = _config;
			SpeedProfile value2;
			if (_config != null)
			{
				value2 = SpeedProfile.Sanitized(config2.tapSpeed);
				if (_profiles == null)
				{
					goto IL_018a;
				}
			}
			else
			{
				value2 = SpeedProfile.Sanitized(null);
			}
			_profiles[SpeedProfileId.TapSpeed] = value2;
			GameSpeedConfig config3 = _config;
			SpeedProfile value3;
			if (_config != null)
			{
				value3 = SpeedProfile.Sanitized(config3.certainWin);
			}
			else
			{
				value3 = SpeedProfile.Sanitized(null);
				if (_profiles == null)
				{
					goto IL_018a;
				}
			}
			_profiles[SpeedProfileId.CertainWin] = value3;
			_appliedClock = 0f / 0f;
			Apply();
			return;
			IL_018a:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001108")]
		[Address(RVA = "0x3CB7D60", Offset = "0x3CB7D60", Length = "0x184")]
		public IGameplaySpeedHandle RequestProfile(string key, SpeedProfileId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplaySpeedController::RequestProfile");
			return default;
		}

		[Token(Token = "0x6001109")]
		[Address(RVA = "0x3CBC408", Offset = "0x3CBC408", Length = "0xF8")]
		public void SetActiveProfile(string key, SpeedProfileId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplaySpeedController::SetActiveProfile");
		}

		[Token(Token = "0x600110A")]
		[Address(RVA = "0x3CBC500", Offset = "0x3CBC500", Length = "0x98")]
		public void ClearRequest(string key)
		{
			if (!_disposed && !string.IsNullOrEmpty(key) && _activeRequests.Remove(key))
			{
				Apply();
			}
		}

		[Token(Token = "0x600110B")]
		[Address(RVA = "0x3CBC3A8", Offset = "0x3CBC3A8", Length = "0x10")]
		public void Reapply()
		{
			_appliedClock = 0f / 0f;
			Apply();
		}

		[Token(Token = "0x600110C")]
		[Address(RVA = "0x3CBC598", Offset = "0x3CBC598", Length = "0x84")]
		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_activeRequests.Clear();
				_appliedClock = 0f / 0f;
				Apply();
			}
		}

		[Token(Token = "0x600110D")]
		[Address(RVA = "0x3CBC61C", Offset = "0x3CBC61C", Length = "0x88")]
		private void ReleaseRequest(string key)
		{
			string key2 = default(string);
			if (!_disposed && _activeRequests.Remove(key2))
			{
				Apply();
			}
		}

		[Token(Token = "0x600110E")]
		[Address(RVA = "0x3CBBD6C", Offset = "0x3CBBD6C", Length = "0x63C")]
		internal unsafe void Apply()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplaySpeedController::Apply");
		}

		[Token(Token = "0x600110F")]
		[Address(RVA = "0x3CBC6A4", Offset = "0x3CBC6A4", Length = "0x13C")]
		private SandPhysicsSystemGroup ResolveGroup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplaySpeedController::ResolveGroup");
			return default;
		}

		[Token(Token = "0x6001110")]
		[Address(RVA = "0x3CBC7E0", Offset = "0x3CBC7E0", Length = "0x148")]
		public GameplaySpeedController()
		{
			Dictionary<SpeedProfileId, SpeedProfile> profiles = new Dictionary<SpeedProfileId, SpeedProfile>();
			_profiles = profiles;
			Dictionary<string, SpeedProfileId> activeRequests = new Dictionary<string, SpeedProfileId>();
			_activeRequests = activeRequests;
			List<SpeedProfile> scratch = new List<SpeedProfile>();
			_scratch = scratch;
			_appliedClock = 0f / 0f;
			_baselineConveyor = 1f;
		}
	}
}
