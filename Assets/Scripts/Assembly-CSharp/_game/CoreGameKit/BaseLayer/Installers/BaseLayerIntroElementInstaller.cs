using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x200068B")]
	public class BaseLayerIntroElementInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200068C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001668")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001669")]
			public static Func<Instancer, IntroSequenceController> _003C_003E9__1_0;

			[Token(Token = "0x6001BCA")]
			[Address(RVA = "0x3D65288", Offset = "0x3D65288", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001BCB")]
			[Address(RVA = "0x3D652EC", Offset = "0x3D652EC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal IntroSequenceController _003CInstallBindings_003Eb__1_0(Instancer instancer)
			{
				IntroSequenceController introSequenceController = new IntroSequenceController();
				IntroSequenceController introSequenceController2 = instancer.InjectInstance(introSequenceController);
				return introSequenceController;
			}
		}

		[SerializeReference]
		[Token(Token = "0x4001667")]
		[FieldOffset(Offset = "0x18")]
		private IBaseLayerIntroElement[] m_introElements;

		[Token(Token = "0x6001BC8")]
		[Address(RVA = "0x3D64FBC", Offset = "0x3D64FBC", Length = "0x2BC")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerIntroElementInstaller::InstallBindings");
		}

		[Token(Token = "0x6001BC9")]
		[Address(RVA = "0x3D65280", Offset = "0x3D65280", Length = "0x8")]
		public BaseLayerIntroElementInstaller()
		{
		}
	}
}
