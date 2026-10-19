using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.SoundSystem.Scripts.Runtime
{
	[Serializable]
	[Token(Token = "0x2000010")]
	public class SoundInstaller : IContainerInstaller
	{
		[SerializeField]
		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x10")]
		private string m_installerName;

		[SerializeField]
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x18")]
		private SoundManager m_soundManager;

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x7B9DE00", Offset = "0x7B9DE00", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\treturn;\nL_0024:\n\tv55 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, Unco.SoundSystem.Scripts.Runtime.SoundManager>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, Unco.SoundSystem.Scripts.Runtime.SoundManager>::.ctor(v55, this, Il2CppMethodInfo);\n\tv76 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v55);\n")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, SoundManager> factory = delegate(Instancer instancer)
			{
				SoundManager soundManager = instancer.Instantiate(m_soundManager);
				string name = "---" + m_installerName + "-SoundManager---";
				soundManager.name = name;
				return soundManager;
			};
			containerBuilder.AddSingleton(factory);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x7B9DEA8", Offset = "0x7B9DEA8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.m_installerName = \"Menu\";\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SoundInstaller()
		{
			m_installerName = "Menu";
		}
	}
}
