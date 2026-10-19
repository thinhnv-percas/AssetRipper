using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.MenuLayer
{
	[Serializable]
	[Token(Token = "0x20005D9")]
	public struct TabData
	{
		[SerializeField]
		[Token(Token = "0x4001445")]
		[FieldOffset(Offset = "0x0")]
		private InstallerSO[] m_installers;

		[Token(Token = "0x17000260")]
		public IContainerInstaller[] Installers
		{
			[Token(Token = "0x6001929")]
			[Address(RVA = "0x3D45794", Offset = "0x3D45794", Length = "0x9C")]
			get
			{
				if (m_installers != null)
				{
					IEnumerable<object> source = m_installers.Cast<object>();
					IContainerInstaller[] array = (IContainerInstaller[])source.ToArray();
					if (array != null)
					{
						return array;
					}
				}
				return new IContainerInstaller[0];
			}
		}
	}
}
