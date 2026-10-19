using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.ResourceSystem.Visual;
using UnityEngine;
using _game.Systems.ShopSystem.Scripts.Core;

namespace Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x200004B")]
	public class ShopSystemInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x18")]
		private ShopVisualHub m_shopVisualHub;

		[SerializeField]
		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x20")]
		private ResourceVisualHub m_resourceVisualHub;

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x3C681C8", Offset = "0x3C681C8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\t_game.Systems.ShopSystem.Scripts.Core.IAPStoreService::.ctor(v66);\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v66);\n\tv73 = new _game.Systems.ShopSystem.Scripts.Core.ShopService();\n\t_game.Systems.ShopSystem.Scripts.Core.ShopService::.ctor(v73);\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v73);\n\tv80 = new _game.Systems.ShopSystem.Scripts.Core.IAPEventHelper();\n\t_game.Systems.ShopSystem.Scripts.Core.IAPEventHelper::.ctor(v80);\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v80);\n\treturn;\nL_0026:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_shopVisualHub);\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_resourceVisualHub);\n\tv66 = new _game.Systems.ShopSystem.Scripts.Core.IAPStoreService();\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_shopVisualHub);
			containerBuilder.AddSingleton(m_resourceVisualHub);
			IAPStoreService instance = new IAPStoreService();
			containerBuilder.AddSingleton(instance);
			ShopService instance2 = new ShopService();
			containerBuilder.AddSingleton(instance2);
			IAPEventHelper instance3 = new IAPEventHelper();
			containerBuilder.AddSingleton(instance3);
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x3C682D0", Offset = "0x3C682D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public ShopSystemInstaller()
		{
		}
	}
}
