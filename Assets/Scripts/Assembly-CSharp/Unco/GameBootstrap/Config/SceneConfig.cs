using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[CreateAssetMenu(fileName = "SceneConfig", menuName = "GameBootstrap/SceneConfig")]
	[Token(Token = "0x20007EE")]
	public class SceneConfig : ScriptableObject
	{
		[Header("Scene Settings")]
		[SerializeField]
		[Token(Token = "0x4001A77")]
		[FieldOffset(Offset = "0x18")]
		private string _sceneName;

		[Header("Installers")]
		[Tooltip("Installers that will be executed when this scene loads. Each installer must inherit from InstallerSO.")]
		[SerializeField]
		[Token(Token = "0x4001A78")]
		[FieldOffset(Offset = "0x20")]
		private List<InstallerSO> _installers;

		[Token(Token = "0x1700034B")]
		public string SceneName
		{
			[Token(Token = "0x6002184")]
			[Address(RVA = "0x3DC6D18", Offset = "0x3DC6D18", Length = "0x8")]
			get
			{
				return _sceneName;
			}
		}

		[Token(Token = "0x1700034C")]
		public List<IContainerInstaller> Installers
		{
			[Token(Token = "0x6002185")]
			[Address(RVA = "0x3DC66EC", Offset = "0x3DC66EC", Length = "0xC0")]
			get
			{
				if (_installers != null)
				{
					IEnumerable<object> source = _installers.Cast<object>();
					List<IContainerInstaller> list = (List<IContainerInstaller>)(object)source.ToList();
					if (list != null)
					{
						return list;
					}
				}
				return new List<IContainerInstaller>();
			}
		}

		[Token(Token = "0x6002186")]
		[Address(RVA = "0x3DC6D20", Offset = "0x3DC6D20", Length = "0x8C")]
		public SceneConfig()
		{
			List<InstallerSO> installers = new List<InstallerSO>();
			_installers = installers;
		}
	}
}
