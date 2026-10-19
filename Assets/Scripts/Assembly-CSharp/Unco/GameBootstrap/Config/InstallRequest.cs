using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[Serializable]
	[Token(Token = "0x20007E9")]
	public class InstallRequest
	{
		[SerializeReference]
		[Token(Token = "0x4001A70")]
		[FieldOffset(Offset = "0x10")]
		internal IEnumerable<IContainerInstaller> _installers;

		[SerializeField]
		[Token(Token = "0x4001A71")]
		[FieldOffset(Offset = "0x18")]
		internal string _installerId;

		[Token(Token = "0x17000344")]
		public IEnumerable<IContainerInstaller> Installers
		{
			[Token(Token = "0x6002174")]
			[Address(RVA = "0x3DC6910", Offset = "0x3DC6910", Length = "0x8")]
			get
			{
				return _installers;
			}
		}

		[Token(Token = "0x17000345")]
		public string InstallerId
		{
			[Token(Token = "0x6002175")]
			[Address(RVA = "0x3DC1C9C", Offset = "0x3DC1C9C", Length = "0x5C")]
			get
			{
				string result;
				if (string.IsNullOrEmpty(_installerId))
				{
					bool flag = Installers == null;
					result = (string)(object)Installers;
					if (!flag)
					{
						Type type = Installers.GetType();
						return type.Name;
					}
				}
				else
				{
					result = _installerId;
				}
				return result;
			}
		}

		[Token(Token = "0x6002176")]
		[Address(RVA = "0x3DC6918", Offset = "0x3DC6918", Length = "0x54")]
		public InstallRequest(InstallerGroupSo installerGroupSo)
		{
			IContainerInstaller[] allInstallers = installerGroupSo.GetAllInstallers();
			_installers = allInstallers;
			_installerId = installerGroupSo.InstallerGroupId;
		}
	}
}
