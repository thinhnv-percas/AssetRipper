using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces.HoveringTextSystem
{
	[Token(Token = "0x2000612")]
	public class HoveringTextInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x40014F7")]
		[FieldOffset(Offset = "0x18")]
		private HoveringTextController m_prefab;

		[Token(Token = "0x6001A10")]
		[Address(RVA = "0x3D4FF00", Offset = "0x3D4FF00", Length = "0xA8")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, HoveringTextController> factory = (Instancer instancer) => instancer.Instantiate(m_prefab);
			containerBuilder.AddSingleton(factory);
		}

		[Token(Token = "0x6001A11")]
		[Address(RVA = "0x3D4FFA8", Offset = "0x3D4FFA8", Length = "0x8")]
		public HoveringTextInstaller()
		{
		}
	}
}
