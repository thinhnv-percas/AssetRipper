using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Config
{
	[Token(Token = "0x200062E")]
	public class BoosterUnlockHandler
	{
		[Token(Token = "0x4001555")]
		[FieldOffset(Offset = "0x10")]
		private IBoosterService _boosterService;

		[Token(Token = "0x4001556")]
		[FieldOffset(Offset = "0x18")]
		internal Dictionary<string, BoosterRemoteConfigData> _boosterIdToConfigMap;

		[Token(Token = "0x4001557")]
		[FieldOffset(Offset = "0x20")]
		internal BoosterRemoteConfigData[] _allConfigs;

		[Inject(false)]
		[Token(Token = "0x6001A76")]
		[Address(RVA = "0x3D5381C", Offset = "0x3D5381C", Length = "0x178")]
		private void Inject(IBoosterService boosterService, RemoteConfigManager remoteConfigManager)
		{
			IBoosterService boosterService2 = default(IBoosterService);
			_boosterService = boosterService2;
			Dictionary<string, BoosterRemoteConfigData> boosterIdToConfigMap = new Dictionary<string, BoosterRemoteConfigData>();
			_boosterIdToConfigMap = boosterIdToConfigMap;
			BoosterRemoteConfigWrapper json = remoteConfigManager.GetJson<BoosterRemoteConfigWrapper>(RemoteKey.booster_config);
			BoosterRemoteConfigData[] allConfigs;
			if (json != null)
			{
				_allConfigs = json.Boosters;
				allConfigs = _allConfigs;
				if (_allConfigs == null)
				{
					return;
				}
			}
			else
			{
				_allConfigs = null;
				allConfigs = _allConfigs;
				if (_allConfigs == null)
				{
					return;
				}
			}
			if (allConfigs.Length < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				BoosterRemoteConfigData boosterRemoteConfigData = allConfigs[num];
				if (!string.IsNullOrEmpty(boosterRemoteConfigData.BoosterId))
				{
					if (_boosterIdToConfigMap == null)
					{
						throw new NullReferenceException();
					}
					_boosterIdToConfigMap[boosterRemoteConfigData.BoosterId] = allConfigs[num];
				}
				num++;
			}
			while (num < allConfigs.Length);
		}

		[Token(Token = "0x6001A77")]
		[Address(RVA = "0x3D53994", Offset = "0x3D53994", Length = "0x2CC")]
		public void TryUnlockByProgress(int currentLevelIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterUnlockHandler::TryUnlockByProgress");
		}

		[Token(Token = "0x6001A78")]
		[Address(RVA = "0x3D51CAC", Offset = "0x3D51CAC", Length = "0x78")]
		public BoosterRemoteConfigData GetConfigForBooster(string boosterId)
		{
			bool flag = _boosterIdToConfigMap == null;
			BoosterRemoteConfigData result = (BoosterRemoteConfigData)(object)_boosterIdToConfigMap;
			if (!flag)
			{
				string key = default(string);
				bool flag2 = _boosterIdToConfigMap.TryGetValue(key, out var value);
				result = value;
			}
			return result;
		}

		[Token(Token = "0x6001A79")]
		[Address(RVA = "0x3D53C60", Offset = "0x3D53C60", Length = "0x8")]
		public BoosterRemoteConfigData[] GetAllConfigs()
		{
			return _allConfigs;
		}

		[Token(Token = "0x6001A7A")]
		[Address(RVA = "0x3D526D0", Offset = "0x3D526D0", Length = "0x8")]
		public BoosterUnlockHandler()
		{
		}
	}
}
