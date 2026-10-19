using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x2000582")]
	public class TrackingInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x40012F1")]
		[FieldOffset(Offset = "0x18")]
		private TrackingConfig m_trackingConfig;

		[Token(Token = "0x6001732")]
		[Address(RVA = "0x3D28618", Offset = "0x3D28618", Length = "0x190")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingInstaller::InstallBindings");
		}

		[Token(Token = "0x6001733")]
		[Address(RVA = "0x3D28828", Offset = "0x3D28828", Length = "0x8")]
		public TrackingInstaller()
		{
		}
	}
}
