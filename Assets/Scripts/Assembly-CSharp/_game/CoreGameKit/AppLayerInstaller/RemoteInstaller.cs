using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.RemoteManagementSystem;
using Unco.RemoteManagementSystem.ScriptableObjects;
using Unco.ResourceSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Data;
using _game.Systems.ElephantStorage;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Token(Token = "0x20006FA")]
	public class RemoteInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006FB")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001765")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001766")]
			public static Func<Instancer, RemoteConfigManager> _003C_003E9__2_0;

			[Token(Token = "0x6001D71")]
			[Address(RVA = "0x3D78B98", Offset = "0x3D78B98", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001D72")]
			[Address(RVA = "0x3D78BFC", Offset = "0x3D78BFC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal RemoteConfigManager _003CInstallBindings_003Eb__2_0(Instancer instancer)
			{
				RemoteConfigManager instance = new RemoteConfigManager();
				return instancer.InjectInstance(instance);
			}
		}

		[SerializeReference]
		[Token(Token = "0x4001763")]
		[FieldOffset(Offset = "0x18")]
		private IRemoteConfig m_remoteConfig;

		[SerializeField]
		[Token(Token = "0x4001764")]
		[FieldOffset(Offset = "0x20")]
		private BaseRemoteConfig m_remoteConfigScriptableObject;

		[Token(Token = "0x6001D6F")]
		[Address(RVA = "0x3D78414", Offset = "0x3D78414", Length = "0x77C")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			GameStorage gameStorage = new GameStorage();
			IPlayerDataHandler playerDataHandler;
			if (ElephantCore.Instance != null)
			{
				ElephantStorageDataHandler elephantStorageDataHandler = new ElephantStorageDataHandler();
				playerDataHandler = elephantStorageDataHandler;
			}
			else
			{
				PlayerPrefDataHandler playerPrefDataHandler = new PlayerPrefDataHandler();
				playerDataHandler = playerPrefDataHandler;
			}
			playerDataHandler.Load(gameStorage);
			Type type = playerDataHandler.GetType();
			string text = type.Name;
			LevelProgressPref progress = gameStorage.Progress;
			int currentLevel = progress.CurrentLevel;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string text2 = $"afterLoad CurrentLevel={arg}, ";
			bool migrationDone = gameStorage.MigrationDone;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg2 = default(object);
			string text3 = $"MigrationDone={arg2}, ";
			ResourceStorageData resources = gameStorage.Resources;
			int count = resources.Amounts.Count;
			int num2 = count;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg3 = default(object);
			string text4 = $"resourceEntries={arg3}";
			string message = "[RemoteInstaller] dataHandler=" + text + ", " + text2 + text3 + text4;
			Debug.Log(message);
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(IPlayerDataHandler);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_04cd;
				}
			}
			array[0] = typeFromHandle;
			containerBuilder.AddSingleton(playerDataHandler, array);
			containerBuilder.AddSingleton(gameStorage);
			containerBuilder.AddSingleton(gameStorage.Health);
			containerBuilder.AddSingleton(gameStorage.Boosters);
			containerBuilder.AddSingleton(gameStorage.Progress);
			containerBuilder.AddSingleton(gameStorage.Resources);
			containerBuilder.AddSingleton(gameStorage.Monetization);
			containerBuilder.AddSingleton(gameStorage.Settings);
			containerBuilder.AddSingleton(gameStorage.Tutorials);
			containerBuilder.AddSingleton(gameStorage.Flows);
			containerBuilder.AddSingleton(gameStorage.Shop);
			containerBuilder.AddSingleton(gameStorage.RealTime);
			Type[] array2 = new Type[1];
			Type typeFromHandle2 = typeof(IRemoteConfig);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_04cd;
				}
			}
			array2[0] = typeFromHandle2;
			containerBuilder.AddSingleton(m_remoteConfig, array2);
			Type[] array3 = new Type[1];
			Type typeFromHandle3 = typeof(BaseRemoteConfig);
			if ((object)typeFromHandle3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_04cd;
				}
			}
			array3[0] = typeFromHandle3;
			containerBuilder.AddSingleton(m_remoteConfigScriptableObject, array3);
			int num3 = 187441152 + 3288;
			Func<Instancer, RemoteConfigManager> _003C_003E9__2_ = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				_003C_003E9__2_ = (_003C_003Ec._003C_003E9__2_0 = delegate(Instancer instancer)
				{
					RemoteConfigManager instance = new RemoteConfigManager();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			ElephantStorageMigration.MigrateIfNeeded(gameStorage, playerDataHandler);
			return;
			IL_04cd:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6001D70")]
		[Address(RVA = "0x3D78B90", Offset = "0x3D78B90", Length = "0x8")]
		public RemoteInstaller()
		{
		}
	}
}
