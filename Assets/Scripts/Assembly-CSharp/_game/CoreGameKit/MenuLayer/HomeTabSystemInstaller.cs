using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.UiFactory.TabUiSystem.Core;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.MenuLayer
{
	[Token(Token = "0x20005D6")]
	public class HomeTabSystemInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005D7")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400143E")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400143F")]
			public static Func<Instancer, object> _003C_003E9__1_1;

			[Token(Token = "0x6001926")]
			[Address(RVA = "0x3D45660", Offset = "0x3D45660", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001927")]
			[Address(RVA = "0x3D456C4", Offset = "0x3D456C4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal object _003CInstallBindings_003Eb__1_1(Instancer instancer)
			{
				bool flag = instancer.TryResolve<UiManager>(out var result);
				Type typeFromHandle = typeof(TabUiController);
				return result.Show(typeFromHandle, instancer);
			}
		}

		[SerializeField]
		[Token(Token = "0x400143D")]
		[FieldOffset(Offset = "0x18")]
		private Pair<HomeTabId, TabData>[] m_tabs;

		[Token(Token = "0x6001923")]
		[Address(RVA = "0x3D453CC", Offset = "0x3D453CC", Length = "0x1B8")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, HomeTabContainerSystem> factory = delegate(Instancer x)
			{
				HomeTabContainerSystem instance = new HomeTabContainerSystem(m_tabs);
				return x.InjectInstance(instance);
			};
			containerBuilder.AddSingleton(factory);
			Type typeFromHandle = typeof(TabUiController);
			Func<Instancer, object> factory2 = _003C_003Ec._003C_003E9__1_1;
			if (_003C_003Ec._003C_003E9__1_1 == null)
			{
				factory2 = (_003C_003Ec._003C_003E9__1_1 = delegate(Instancer instancer)
				{
					bool flag = instancer.TryResolve<UiManager>(out var result);
					Type typeFromHandle2 = typeof(TabUiController);
					return result.Show(typeFromHandle2, instancer);
				});
			}
			containerBuilder.AddSingletonFactory(typeFromHandle, factory2);
		}

		[Token(Token = "0x6001924")]
		[Address(RVA = "0x3D45584", Offset = "0x3D45584", Length = "0x8")]
		public HomeTabSystemInstaller()
		{
		}
	}
}
