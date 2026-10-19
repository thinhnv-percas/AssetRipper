using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[Serializable]
	[Token(Token = "0x20007ED")]
	public class InstallerSoReference : IContainerInstaller
	{
		[SerializeField]
		[Token(Token = "0x4001A76")]
		[FieldOffset(Offset = "0x10")]
		private InstallerSO _installerSo;

		[Token(Token = "0x1700034A")]
		public InstallerSO InstallerSo
		{
			[Token(Token = "0x6002181")]
			[Address(RVA = "0x3DC6C44", Offset = "0x3DC6C44", Length = "0x8")]
			get
			{
				return _installerSo;
			}
		}

		[Token(Token = "0x6002182")]
		[Address(RVA = "0x3DC6C4C", Offset = "0x3DC6C4C", Length = "0xC4")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			if (InstallerSo != null)
			{
				InstallerSO installerSO = default(InstallerSO);
				installerSO.InstallBindings(ref containerBuilder);
			}
		}

		[Token(Token = "0x6002183")]
		[Address(RVA = "0x3DC6D10", Offset = "0x3DC6D10", Length = "0x8")]
		public InstallerSoReference()
		{
		}
	}
}
