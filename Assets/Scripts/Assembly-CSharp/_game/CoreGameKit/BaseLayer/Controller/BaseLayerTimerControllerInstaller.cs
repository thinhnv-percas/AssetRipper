using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Controller
{
	[Serializable]
	[Token(Token = "0x20006C0")]
	public class BaseLayerTimerControllerInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x40016D5")]
		[FieldOffset(Offset = "0x18")]
		private float m_duration;

		[Token(Token = "0x6001CA4")]
		[Address(RVA = "0x3D70680", Offset = "0x3D70680", Length = "0x80")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			BaseLayerTimerController instance = new BaseLayerTimerController(m_duration);
			containerBuilder.AddSingleton(instance);
		}

		[Token(Token = "0x6001CA5")]
		[Address(RVA = "0x3D70700", Offset = "0x3D70700", Length = "0x8")]
		public BaseLayerTimerControllerInstaller()
		{
		}
	}
}
