using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[CreateAssetMenu(fileName = "GameModeConfig", menuName = "GameBootstrap/GameModeConfig")]
	[Token(Token = "0x20007E7")]
	public class GameModeConfig : ScriptableObject
	{
		[Header("Runtime Mode")]
		[SerializeField]
		[Token(Token = "0x4001A6B")]
		[FieldOffset(Offset = "0x18")]
		private RuntimeMode _runtimeMode = RuntimeMode.Production;

		[Tooltip("Global installers executed at the start. Each installer must inherit from InstallerSO.")]
		[SerializeField]
		[Token(Token = "0x4001A6C")]
		[FieldOffset(Offset = "0x20")]
		internal List<InstallerSO> _globalInstallers;

		[Header("Scene Flow")]
		[Tooltip("Sırayla çalışacak sahne config'leri. Her config sahne adını ve installer'larını içerir.")]
		[SerializeField]
		[Token(Token = "0x4001A6D")]
		[FieldOffset(Offset = "0x28")]
		internal List<SceneConfig> _sceneFlowConfigs;

		[Header("On-Demand Features")]
		[SerializeField]
		[Token(Token = "0x4001A6E")]
		[FieldOffset(Offset = "0x30")]
		private List<OnDemandFeature> _onDemandFeatures;

		[Token(Token = "0x17000342")]
		public RuntimeMode RuntimeMode
		{
			[Token(Token = "0x600216C")]
			[Address(RVA = "0x3DC66E4", Offset = "0x3DC66E4", Length = "0x8")]
			get
			{
				return _runtimeMode;
			}
		}

		[Token(Token = "0x17000343")]
		public List<SceneConfig> SceneFlowConfigs
		{
			[Token(Token = "0x600216D")]
			[Address(RVA = "0x3DC2C04", Offset = "0x3DC2C04", Length = "0x8C")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192471040;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E219]");
				List<SceneConfig> sceneFlowConfigs;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					sceneFlowConfigs = _sceneFlowConfigs;
					if (_sceneFlowConfigs != null)
					{
						goto IL_0061;
					}
				}
				else
				{
					_ = 1;
					sceneFlowConfigs = _sceneFlowConfigs;
					if (_sceneFlowConfigs != null)
					{
						goto IL_0061;
					}
				}
				return new List<SceneConfig>();
				IL_0061:
				return sceneFlowConfigs;
			}
		}

		[Token(Token = "0x600216E")]
		[Address(RVA = "0x3DBE44C", Offset = "0x3DBE44C", Length = "0x70")]
		public List<IContainerInstaller> GetInstallersForPhase()
		{
			IEnumerable<object> source = _globalInstallers.Cast<object>();
			return (List<IContainerInstaller>)(object)source.ToList();
		}

		[Token(Token = "0x600216F")]
		[Address(RVA = "0x3DC18B4", Offset = "0x3DC18B4", Length = "0xF8")]
		public List<IContainerInstaller> GetInstallersForSceneConfig(SceneConfig sceneConfig)
		{
			if (!(sceneConfig == null))
			{
				List<IContainerInstaller> installers = sceneConfig.Installers;
				if (installers != null)
				{
					return installers;
				}
			}
			return new List<IContainerInstaller>();
		}

		[Token(Token = "0x6002170")]
		[Address(RVA = "0x3DC1B7C", Offset = "0x3DC1B7C", Length = "0x108")]
		public OnDemandFeature GetOnDemandFeature(string tag)
		{
			if (_onDemandFeatures != null)
			{
				Func<OnDemandFeature, bool> predicate = (OnDemandFeature f) => f != null && f.Tag == tag;
				return (OnDemandFeature)_onDemandFeatures.FirstOrDefault((Func<object, bool>)predicate);
			}
			return null;
		}

		[Token(Token = "0x6002171")]
		[Address(RVA = "0x3DC67B4", Offset = "0x3DC67B4", Length = "0x13C")]
		public GameModeConfig()
		{
			List<InstallerSO> globalInstallers = new List<InstallerSO>();
			_globalInstallers = globalInstallers;
			_sceneFlowConfigs = new List<SceneConfig>();
			_onDemandFeatures = new List<OnDemandFeature>();
		}
	}
}
