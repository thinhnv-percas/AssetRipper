using System.Collections.Generic;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[Token(Token = "0x20007EB")]
	public class InstallerGroupSo : ScriptableObject
	{
		[Tooltip("ScriptableObject installer references. All installers must inherit from InstallerSO.")]
		[SerializeField]
		[Token(Token = "0x4001A74")]
		[FieldOffset(Offset = "0x18")]
		private InstallerSO[] m_installerSoReferences;

		[SerializeField]
		[Token(Token = "0x4001A75")]
		[FieldOffset(Offset = "0x20")]
		private string m_installerGroupId;

		[Token(Token = "0x17000348")]
		public IContainerInstaller[] Installers
		{
			[Token(Token = "0x600217A")]
			[Address(RVA = "0x3DC696C", Offset = "0x3DC696C", Length = "0x4")]
			get
			{
				return GetAllInstallers();
			}
		}

		[Token(Token = "0x17000349")]
		public string InstallerGroupId
		{
			[Token(Token = "0x600217B")]
			[Address(RVA = "0x3DC6C34", Offset = "0x3DC6C34", Length = "0x8")]
			get
			{
				return m_installerGroupId;
			}
		}

		[Token(Token = "0x600217C")]
		[Address(RVA = "0x3DC6A5C", Offset = "0x3DC6A5C", Length = "0x1D8")]
		internal IContainerInstaller[] GetAllInstallers()
		{
			List<IContainerInstaller> list = new List<IContainerInstaller>();
			InstallerSO[] installerSoReferences = m_installerSoReferences;
			if (m_installerSoReferences != null && installerSoReferences.Length >= 1)
			{
				bool flag = list == null;
				int num = 0;
				if (!flag)
				{
					int num2 = 0;
					do
					{
						if (installerSoReferences[num2] != null)
						{
							list.Add(installerSoReferences[num2]);
						}
						num2++;
					}
					while (num2 < installerSoReferences.Length);
				}
				else
				{
					do
					{
						bool flag2 = installerSoReferences[num] != null;
						num++;
					}
					while (num < installerSoReferences.Length);
				}
			}
			return list.ToArray();
		}

		[Token(Token = "0x600217D")]
		[Address(RVA = "0x3DC6978", Offset = "0x3DC6978", Length = "0x94")]
		public InstallRequest CreateInstallRequest()
		{
			InstallRequest installRequest = (InstallRequest)FormatterServices.GetUninitializedObject(typeof(InstallRequest));
			IContainerInstaller[] allInstallers = GetAllInstallers();
			installRequest._installers = allInstallers;
			installRequest._installerId = InstallerGroupId;
			return installRequest;
		}

		[Token(Token = "0x600217E")]
		[Address(RVA = "0x3DC6C3C", Offset = "0x3DC6C3C", Length = "0x8")]
		public InstallerGroupSo()
		{
		}
	}
}
