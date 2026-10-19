using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using _game.CoreGameKit.BaseLayer.Controller;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x2000687")]
	public class BaseLayerInputInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000688")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400165D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400165E")]
			public static Func<Instancer, BaseLayerInputProvider> _003C_003E9__0_0;

			[Token(Token = "0x6001BC4")]
			[Address(RVA = "0x3D64E58", Offset = "0x3D64E58", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001BC5")]
			[Address(RVA = "0x3D64EBC", Offset = "0x3D64EBC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal BaseLayerInputProvider _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				bool flag = instancer.TryResolve<UiManager>(out var result);
				TouchInputProvider rawProvider = new TouchInputProvider(result);
				return new BaseLayerInputProvider(rawProvider);
			}
		}

		[Token(Token = "0x6001BC2")]
		[Address(RVA = "0x3D64C44", Offset = "0x3D64C44", Length = "0x20C")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, BaseLayerInputProvider> factory = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					bool flag = instancer.TryResolve<UiManager>(out var result);
					TouchInputProvider rawProvider = new TouchInputProvider(result);
					return new BaseLayerInputProvider(rawProvider);
				});
			}
			Type[] array = new Type[2];
			Type typeFromHandle = typeof(IInputProvider);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0108;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle2 = typeof(IRequireUpdateCall);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0108;
				}
			}
			array[1] = typeFromHandle2;
			containerBuilder.AddSingleton(factory, array);
			return;
			IL_0108:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6001BC3")]
		[Address(RVA = "0x3D64E50", Offset = "0x3D64E50", Length = "0x8")]
		public BaseLayerInputInstaller()
		{
		}
	}
}
