using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[Token(Token = "0x20007EC")]
	public abstract class InstallerSO : ScriptableObject, IContainerInstaller
	{
		[Token(Token = "0x600217F")]
		public abstract void InstallBindings(ref ContainerInstanceBuilder containerBuilder);

		[Token(Token = "0x6002180")]
		[Address(RVA = "0x3DC0CBC", Offset = "0x3DC0CBC", Length = "0x8")]
		protected internal InstallerSO()
		{
		}
	}
}
