using System;
using Cpp2ILInjected;
using Unco.AdSystem;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.Systems.MonetizationCore
{
	[Token(Token = "0x200076A")]
	public class AdSystemInstaller : InstallerSO
	{
		[Token(Token = "0x6001F41")]
		[Address(RVA = "0x3D8D834", Offset = "0x3D8D834", Length = "0x124")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			AdManager instance = new AdManager();
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(IAdManager);
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

		[Token(Token = "0x6001F42")]
		[Address(RVA = "0x3D8D958", Offset = "0x3D8D958", Length = "0x8")]
		public AdSystemInstaller()
		{
		}
	}
}
