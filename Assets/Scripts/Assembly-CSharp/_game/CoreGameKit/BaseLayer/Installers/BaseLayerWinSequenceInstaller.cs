using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006A4")]
	public class BaseLayerWinSequenceInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x4001695")]
		[FieldOffset(Offset = "0x18")]
		private BaseLayerWinSequenceController m_winSequenceControllerPrefab;

		[Token(Token = "0x6001C1C")]
		[Address(RVA = "0x3D685E0", Offset = "0x3D685E0", Length = "0x14")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_winSequenceControllerPrefab);
		}

		[Token(Token = "0x6001C1D")]
		[Address(RVA = "0x3D685F4", Offset = "0x3D685F4", Length = "0x8")]
		public BaseLayerWinSequenceInstaller()
		{
		}
	}
}
