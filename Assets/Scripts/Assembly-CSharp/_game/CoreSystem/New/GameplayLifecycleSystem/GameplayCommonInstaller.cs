using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.FrameSystem;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.New.GameplayLifecycleSystem
{
	[Token(Token = "0x20003E8")]
	public class GameplayCommonInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x4000C6B")]
		[FieldOffset(Offset = "0x18")]
		private SandPhysicsConfig m_sandPhysicsConfig;

		[SerializeField]
		[Token(Token = "0x4000C6C")]
		[FieldOffset(Offset = "0x20")]
		private MoldConceptRegistry m_moldConceptRegistry;

		[SerializeField]
		[Token(Token = "0x4000C6D")]
		[FieldOffset(Offset = "0x28")]
		private FramePresetRegistry m_presetRegistry;

		[SerializeField]
		[Token(Token = "0x4000C6E")]
		[FieldOffset(Offset = "0x30")]
		private MoldConfigSO m_moldConfigSO;

		[Token(Token = "0x6001076")]
		[Address(RVA = "0x3CB440C", Offset = "0x3CB440C", Length = "0x1AC")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_sandPhysicsConfig);
			EntityManager entityManager = new EntityManager();
			EntityExtensions.Initialize(entityManager);
			containerBuilder.AddSingleton(entityManager);
			Type typeFromHandle = typeof(SandParticleParams);
			Func<Instancer, object> factory = delegate(Instancer x)
			{
				bool flag = x.TryResolve<LevelCreatorData>(out var result);
				float effectiveCubeSize = result.sandCubeGrid.EffectiveCubeSize;
				SandParticleParams sandParticleParams = m_sandPhysicsConfig.ComputeForCellSize(effectiveCubeSize);
				SandParticleParams sandParticleParams2 = sandParticleParams;
				return sandParticleParams2;
			};
			containerBuilder.AddSingletonFactory(typeFromHandle, factory);
			if (m_presetRegistry != null)
			{
				containerBuilder.AddSingleton(m_presetRegistry);
			}
		}

		[Token(Token = "0x6001077")]
		[Address(RVA = "0x3CB45B8", Offset = "0x3CB45B8", Length = "0x8")]
		public GameplayCommonInstaller()
		{
		}
	}
}
