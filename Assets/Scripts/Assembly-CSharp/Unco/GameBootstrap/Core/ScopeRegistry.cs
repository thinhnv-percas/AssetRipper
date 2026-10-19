using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.Notifications;
using UnityEngine;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007DD")]
	public class ScopeRegistry
	{
		[Token(Token = "0x20007DE")]
		private class LoadTaskInstaller : IContainerInstaller
		{
			[Token(Token = "0x4001A5C")]
			[FieldOffset(Offset = "0x10")]
			internal readonly ILoadTask _loadTask;

			[Token(Token = "0x6002162")]
			[Address(RVA = "0x3DC6420", Offset = "0x3DC6420", Length = "0x34")]
			public LoadTaskInstaller(ILoadTask loadTask)
			{
				_loadTask = loadTask;
			}

			[Token(Token = "0x6002163")]
			[Address(RVA = "0x3DC6454", Offset = "0x3DC6454", Length = "0x104")]
			public void InstallBindings(ref ContainerInstanceBuilder builder)
			{
				Type[] array = new Type[1];
				Type typeFromHandle = typeof(ILoadTask);
				if ((object)typeFromHandle != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = typeFromHandle;
				builder.AddSingleton(_loadTask, array);
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20007DF")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001A5D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001A5E")]
			public static Func<IContainerInstaller, bool> _003C_003E9__30_0;

			[Token(Token = "0x4001A5F")]
			public static Func<IContainerInstaller, bool> _003C_003E9__31_0;

			[Token(Token = "0x4001A60")]
			public static Func<IContainerInstaller, bool> _003C_003E9__32_0;

			[Token(Token = "0x4001A61")]
			public static Func<IContainerInstaller, bool> _003C_003E9__33_0;

			[Token(Token = "0x6002164")]
			[Address(RVA = "0x3DC6558", Offset = "0x3DC6558", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6002165")]
			[Address(RVA = "0x3DC65BC", Offset = "0x3DC65BC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CEnsureSceneContainer_003Eb__30_0(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}

			internal bool _003CEnsureFeatureContainer_003Eb__31_0(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}

			internal bool _003CEnsureFeatureStaticContainer_003Eb__32_0(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}

			internal bool _003CEnsureFeatureRuntimeContainer_003Eb__33_0(IContainerInstaller i)
			{
				bool flag = i == null;
				return !flag;
			}
		}

		[Token(Token = "0x4001A55")]
		[FieldOffset(Offset = "0x10")]
		private ContainerManager _containerManager;

		[Token(Token = "0x4001A56")]
		[FieldOffset(Offset = "0x18")]
		private Type _currentSceneContainerType;

		[Token(Token = "0x4001A57")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<Type, GameObject> _scopeGameObjects;

		[Token(Token = "0x4001A58")]
		[FieldOffset(Offset = "0x28")]
		private readonly Dictionary<string, Type> _featureContainerTypes;

		[Token(Token = "0x4001A59")]
		[FieldOffset(Offset = "0x30")]
		private Transform _globalScopeParent;

		[Token(Token = "0x4001A5A")]
		[FieldOffset(Offset = "0x38")]
		private string _currentSceneName;

		[Token(Token = "0x4001A5B")]
		[FieldOffset(Offset = "0x40")]
		internal ILoadTask _loadTask;

		[Token(Token = "0x1700033F")]
		public ContainerManager ContainerManager
		{
			[Token(Token = "0x6002149")]
			[Address(RVA = "0x3DC3D04", Offset = "0x3DC3D04", Length = "0x8")]
			get
			{
				return _containerManager;
			}
		}

		[Token(Token = "0x17000340")]
		public ContainerInstance GlobalScope
		{
			[Token(Token = "0x600214A")]
			[Address(RVA = "0x3DC3D0C", Offset = "0x3DC3D0C", Length = "0x54")]
			get
			{
				return ContainerManager.Get<GlobalContainer>();
			}
		}

		[Token(Token = "0x17000341")]
		public ContainerInstance CurrentSceneScope
		{
			[Token(Token = "0x600214B")]
			[Address(RVA = "0x3DC3D60", Offset = "0x3DC3D60", Length = "0xD0")]
			get
			{
				//IL_001f: Expected O, but got I
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X8_v2 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X0_v1+E4]");
				if ((nint)0 != 0)
				{
					if (_currentSceneContainerType != null)
					{
						goto IL_00ab;
					}
				}
				else if (_currentSceneContainerType != null)
				{
					goto IL_00ab;
				}
				goto IL_00f8;
				IL_00f8:
				return ContainerManager.Get<GlobalContainer>();
				IL_00ab:
				if (ContainerManager.Exists(_currentSceneContainerType))
				{
					return ContainerManager.Get(_currentSceneContainerType);
				}
				goto IL_00f8;
			}
		}

		[Token(Token = "0x600214C")]
		[Address(RVA = "0x3DBE5D0", Offset = "0x3DBE5D0", Length = "0x138")]
		public void Initialize(ContainerManager containerManager, Transform globalScopeParent = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopeRegistry::Initialize");
		}

		[Token(Token = "0x600214D")]
		[Address(RVA = "0x3DC3F2C", Offset = "0x3DC3F2C", Length = "0x8")]
		public void SetLoadTask(ILoadTask loadTask)
		{
			_loadTask = loadTask;
		}

		[Token(Token = "0x600214E")]
		[Address(RVA = "0x3DBD9AC", Offset = "0x3DBD9AC", Length = "0x180")]
		public ContainerInstance CreateSceneScope(string sceneName, IEnumerable<IContainerInstaller> installers = null)
		{
			//IL_0024: Expected O, but got I
			if (_currentSceneName != sceneName)
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v15 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v20+E4]");
				if ((nint)0 != 0)
				{
					if (_currentSceneContainerType != null)
					{
						goto IL_00b0;
					}
				}
				else if (_currentSceneContainerType != null)
				{
					goto IL_00b0;
				}
				goto IL_00e9;
			}
			goto IL_00f8;
			IL_00b0:
			if (ContainerManager.Exists(_currentSceneContainerType))
			{
				DisposeSceneScope();
			}
			goto IL_00e9;
			IL_00e9:
			_currentSceneName = sceneName;
			goto IL_00f8;
			IL_00f8:
			if (!ContainerManager.Exists<SceneContainer>())
			{
				EnsureSceneContainer(sceneName, installers);
			}
			Type typeFromHandle = typeof(SceneContainer);
			_currentSceneContainerType = typeFromHandle;
			return ContainerManager.Get<SceneContainer>();
		}

		[Token(Token = "0x600214F")]
		[Address(RVA = "0x3DC1E28", Offset = "0x3DC1E28", Length = "0x8")]
		public ContainerInstance CreateFeatureScope(string featureTag, LifetimeKind lifetimeKind, IEnumerable<IContainerInstaller> installers = null)
		{
			return CreateFeatureScope(featureTag, lifetimeKind, installers, null);
		}

		[Token(Token = "0x6002150")]
		[Address(RVA = "0x3DC453C", Offset = "0x3DC453C", Length = "0xFC")]
		public ContainerInstance CreateFeatureScope(string featureTag, LifetimeKind lifetimeKind, IEnumerable<IContainerInstaller> installers, Type parentContainerType)
		{
			//IL_0062: Expected O, but got I
			Type featureContainerType;
			if (!string.IsNullOrEmpty(featureTag))
			{
				featureContainerType = GetFeatureContainerType(featureTag);
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v4 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X0_v13+E4]");
				if ((nint)0 != 0)
				{
					if (featureContainerType != null)
					{
						goto IL_00ea;
					}
				}
				else if (featureContainerType != null)
				{
					goto IL_00ea;
				}
			}
			goto IL_0125;
			IL_00ea:
			if (ContainerManager.Exists(featureContainerType))
			{
				DisposeFeatureScope(featureTag);
			}
			goto IL_0125;
			IL_0125:
			EnsureFeatureContainer(featureTag, lifetimeKind, installers, parentContainerType);
			Type featureContainerType2 = GetFeatureContainerType(featureTag);
			return ContainerManager.Get(featureContainerType2);
		}

		[Token(Token = "0x6002151")]
		[Address(RVA = "0x3DC4E94", Offset = "0x3DC4E94", Length = "0x104")]
		public ContainerInstance CreateFeatureStaticScope(string featureTag, LifetimeKind lifetimeKind, IEnumerable<IContainerInstaller> installers = null, Type parentContainerType = null)
		{
			bool flag = string.IsNullOrEmpty(featureTag);
			Type typeFromHandle = typeof(FeatureStaticContainer);
			if (!string.IsNullOrEmpty(featureTag) && ContainerManager.Exists(typeFromHandle))
			{
				DisposeFeatureStaticScope(featureTag);
			}
			EnsureFeatureStaticContainer(featureTag, lifetimeKind, installers, parentContainerType);
			return ContainerManager.Get(typeFromHandle);
		}

		[Token(Token = "0x6002152")]
		[Address(RVA = "0x3DC58A4", Offset = "0x3DC58A4", Length = "0x104")]
		public ContainerInstance CreateFeatureRuntimeScope(string featureTag, LifetimeKind lifetimeKind, IEnumerable<IContainerInstaller> installers = null, Type parentContainerType = null)
		{
			bool flag = string.IsNullOrEmpty(featureTag);
			Type typeFromHandle = typeof(FeatureRuntimeContainer);
			if (!string.IsNullOrEmpty(featureTag) && ContainerManager.Exists(typeFromHandle))
			{
				DisposeFeatureRuntimeScope(featureTag);
			}
			EnsureFeatureRuntimeContainer(featureTag, lifetimeKind, installers, parentContainerType);
			return ContainerManager.Get(typeFromHandle);
		}

		[Token(Token = "0x6002153")]
		[Address(RVA = "0x3DBDBC8", Offset = "0x3DBDBC8", Length = "0x17C")]
		public unsafe void DisposeSceneScope()
		{
			//IL_013e: Expected O, but got I
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v4 (System.Int32)+E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X0_v2+E4]");
			if ((nint)0 != 0)
			{
				if (!(_currentSceneContainerType != null))
				{
					return;
				}
			}
			else if (!(_currentSceneContainerType != null))
			{
				return;
			}
			UnityEngine.Object value;
			if (_scopeGameObjects.TryGetValue(_currentSceneContainerType, out *(GameObject*)(&value)))
			{
				UnityEngine.Object.Destroy(value);
				bool flag = _scopeGameObjects.Remove(_currentSceneContainerType);
			}
			if (ContainerManager.Exists(_currentSceneContainerType))
			{
				ContainerManager.DisposeContainer(_currentSceneContainerType);
			}
			_currentSceneContainerType = null;
			_currentSceneName = null;
		}

		[Token(Token = "0x6002154")]
		[Address(RVA = "0x3DBD5AC", Offset = "0x3DBD5AC", Length = "0x1A0")]
		public unsafe void DisposeFeatureScope(string featureTag)
		{
			//IL_0032: Expected O, but got I
			if (string.IsNullOrEmpty(featureTag))
			{
				return;
			}
			Type featureContainerType = GetFeatureContainerType(featureTag);
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X8_v5 (System.Int32)+E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X0_v7+E4]");
			if ((nint)0 != 0)
			{
				if (featureContainerType == null)
				{
					return;
				}
			}
			else if (featureContainerType == null)
			{
				return;
			}
			if (ContainerManager.Exists(featureContainerType))
			{
				UnityEngine.Object value;
				if (_scopeGameObjects.TryGetValue(featureContainerType, out *(GameObject*)(&value)))
				{
					UnityEngine.Object.Destroy(value);
					bool flag = _scopeGameObjects.Remove(featureContainerType);
				}
				ContainerManager.DisposeContainer(featureContainerType);
			}
			bool flag2 = _featureContainerTypes.Remove(featureTag);
		}

		[Token(Token = "0x6002155")]
		[Address(RVA = "0x3DC62B4", Offset = "0x3DC62B4", Length = "0x16C")]
		public unsafe void DisposeAllFeatureScopes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopeRegistry::DisposeAllFeatureScopes");
		}

		[Token(Token = "0x6002156")]
		[Address(RVA = "0x3DC502C", Offset = "0x3DC502C", Length = "0x164")]
		public unsafe void DisposeFeatureStaticScope(string featureTag)
		{
			bool flag = string.IsNullOrEmpty(featureTag);
			Type typeFromHandle = typeof(FeatureStaticContainer);
			if (ContainerManager.Exists(typeFromHandle))
			{
				UnityEngine.Object value;
				if (_scopeGameObjects.TryGetValue(typeFromHandle, out *(GameObject*)(&value)))
				{
					UnityEngine.Object.Destroy(value);
					bool flag2 = _scopeGameObjects.Remove(typeFromHandle);
				}
				ContainerManager.DisposeContainer(typeFromHandle);
			}
		}

		[Token(Token = "0x6002157")]
		[Address(RVA = "0x3DC5A3C", Offset = "0x3DC5A3C", Length = "0x164")]
		public unsafe void DisposeFeatureRuntimeScope(string featureTag)
		{
			bool flag = string.IsNullOrEmpty(featureTag);
			Type typeFromHandle = typeof(FeatureRuntimeContainer);
			if (ContainerManager.Exists(typeFromHandle))
			{
				UnityEngine.Object value;
				if (_scopeGameObjects.TryGetValue(typeFromHandle, out *(GameObject*)(&value)))
				{
					UnityEngine.Object.Destroy(value);
					bool flag2 = _scopeGameObjects.Remove(typeFromHandle);
				}
				ContainerManager.DisposeContainer(typeFromHandle);
			}
		}

		[Token(Token = "0x6002158")]
		[Address(RVA = "0x3DC4638", Offset = "0x3DC4638", Length = "0x118")]
		public Type GetFeatureContainerType(string featureTag)
		{
			if (string.IsNullOrEmpty(featureTag))
			{
				return typeof(FeatureContainer);
			}
			if (_featureContainerTypes.TryGetValue(featureTag, out var value))
			{
				return value;
			}
			return typeof(FeatureContainer);
		}

		[Token(Token = "0x6002159")]
		[Address(RVA = "0x3DC4F98", Offset = "0x3DC4F98", Length = "0x94")]
		public Type GetFeatureStaticContainerType(string featureTag)
		{
			//IL_005c: Expected O, but got I
			bool flag = string.IsNullOrEmpty(featureTag);
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v4 (System.Int32)+E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v4+E4]");
			if ((nint)0 != 0)
			{
				return typeof(FeatureStaticContainer);
			}
			return typeof(FeatureStaticContainer);
		}

		[Token(Token = "0x600215A")]
		[Address(RVA = "0x3DC59A8", Offset = "0x3DC59A8", Length = "0x94")]
		public Type GetFeatureRuntimeContainerType(string featureTag)
		{
			//IL_005c: Expected O, but got I
			bool flag = string.IsNullOrEmpty(featureTag);
			int num = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v4 (System.Int32)+E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v4+E4]");
			if ((nint)0 != 0)
			{
				return typeof(FeatureRuntimeContainer);
			}
			return typeof(FeatureRuntimeContainer);
		}

		[Token(Token = "0x600215B")]
		[Address(RVA = "0x3DBFB08", Offset = "0x3DBFB08", Length = "0x238")]
		public unsafe void DisposeAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopeRegistry::DisposeAll");
		}

		[Token(Token = "0x600215C")]
		[Address(RVA = "0x3DC3E30", Offset = "0x3DC3E30", Length = "0xFC")]
		private GameObject CreateScopeGameObject(string name, Transform parent)
		{
			GameObject gameObject = new GameObject(name);
			if (!(parent != null))
			{
				return gameObject;
			}
			Transform transform = gameObject.transform;
			transform.SetParent(parent);
			return gameObject;
		}

		[Token(Token = "0x600215D")]
		[Address(RVA = "0x3DC3F34", Offset = "0x3DC3F34", Length = "0x608")]
		private unsafe void EnsureSceneContainer(string sceneName, IEnumerable<IContainerInstaller> installers)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopeRegistry::EnsureSceneContainer");
		}

		[Token(Token = "0x600215E")]
		[Address(RVA = "0x3DC4750", Offset = "0x3DC4750", Length = "0x744")]
		private unsafe void EnsureFeatureContainer(string featureTag, LifetimeKind lifetimeKind, IEnumerable<IContainerInstaller> installers, Type parentContainerType = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopeRegistry::EnsureFeatureContainer");
		}

		[Token(Token = "0x600215F")]
		[Address(RVA = "0x3DC5190", Offset = "0x3DC5190", Length = "0x714")]
		private unsafe void EnsureFeatureStaticContainer(string featureTag, LifetimeKind lifetimeKind, IEnumerable<IContainerInstaller> installers, Type parentContainerType = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopeRegistry::EnsureFeatureStaticContainer");
		}

		[Token(Token = "0x6002160")]
		[Address(RVA = "0x3DC5BA0", Offset = "0x3DC5BA0", Length = "0x714")]
		private unsafe void EnsureFeatureRuntimeContainer(string featureTag, LifetimeKind lifetimeKind, IEnumerable<IContainerInstaller> installers, Type parentContainerType = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopeRegistry::EnsureFeatureRuntimeContainer");
		}

		[Token(Token = "0x6002161")]
		[Address(RVA = "0x3DBE4F0", Offset = "0x3DBE4F0", Length = "0xE0")]
		public ScopeRegistry()
		{
			Dictionary<Type, GameObject> scopeGameObjects = new Dictionary<Type, GameObject>();
			_scopeGameObjects = scopeGameObjects;
			Dictionary<string, Type> featureContainerTypes = new Dictionary<string, Type>();
			_featureContainerTypes = featureContainerTypes;
		}
	}
}
