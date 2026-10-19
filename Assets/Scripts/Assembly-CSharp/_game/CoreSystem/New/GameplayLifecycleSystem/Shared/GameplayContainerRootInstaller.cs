using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Core;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.Shared
{
	[Token(Token = "0x20003FE")]
	public sealed class GameplayContainerRootInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003FF")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CA9")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CAA")]
			public static Func<Instancer, ScopeContext> _003C_003E9__3_1;

			[Token(Token = "0x60010CC")]
			[Address(RVA = "0x3CB891C", Offset = "0x3CB891C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010CD")]
			[Address(RVA = "0x3CB8980", Offset = "0x3CB8980", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal ScopeContext _003CInstallBindings_003Eb__3_1(Instancer instancer)
			{
				bool flag = instancer.TryResolve<GameplayContainerRoot>(out var result);
				return new ScopeContext(result.Transform, instancer, "GameplayContainer");
			}
		}

		[Token(Token = "0x4000CA7")]
		[FieldOffset(Offset = "0x10")]
		private readonly bool _isPlaying;

		[Token(Token = "0x4000CA8")]
		[FieldOffset(Offset = "0x18")]
		private readonly string _rootName;

		[Token(Token = "0x60010C9")]
		[Address(RVA = "0x3CB04E4", Offset = "0x3CB04E4", Length = "0x44")]
		public GameplayContainerRootInstaller(bool isPlaying, string rootName = "GameplayContainerRoot")
		{
			_rootName = rootName;
			_isPlaying = isPlaying;
		}

		[Token(Token = "0x60010CA")]
		[Address(RVA = "0x3CB8684", Offset = "0x3CB8684", Length = "0x228")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, GameplayContainerRoot> factory = (Instancer _) => new GameplayContainerRoot(_rootName, _isPlaying);
			containerBuilder.AddSingleton(factory);
			Func<Instancer, ScopeContext> factory2 = _003C_003Ec._003C_003E9__3_1;
			if (_003C_003Ec._003C_003E9__3_1 == null)
			{
				factory2 = (_003C_003Ec._003C_003E9__3_1 = delegate(Instancer instancer)
				{
					bool flag = instancer.TryResolve<GameplayContainerRoot>(out var result);
					return new ScopeContext(result.Transform, instancer, "GameplayContainer");
				});
			}
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(ScopeContext);
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
			containerBuilder.AddSingleton(factory2, array);
		}
	}
}
