using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006A9")]
	public class LevelFactoryInstaller : InstallerSO
	{
		[Token(Token = "0x6001C2C")]
		[Address(RVA = "0x3D699D8", Offset = "0x3D699D8", Length = "0x150")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			SandLevelFactory instance = new SandLevelFactory();
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(ILevelFactory);
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
			containerBuilder.AddSingleton(instance, array);
		}

		[Token(Token = "0x6001C2D")]
		[Address(RVA = "0x3D69B80", Offset = "0x3D69B80", Length = "0x8")]
		public LevelFactoryInstaller()
		{
		}
	}
}
