using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.StateSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.BaseLayer.States;
using _game.CoreGameKit.BaseLayer.States.Behaviors;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006A1")]
	public class BaseLayerStateInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006A2")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001692")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001693")]
			public static Func<Instancer, BaseLayerStateMachine> _003C_003E9__1_0;

			[Token(Token = "0x6001C17")]
			[Address(RVA = "0x3D684EC", Offset = "0x3D684EC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001C18")]
			[Address(RVA = "0x3D68550", Offset = "0x3D68550", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal BaseLayerStateMachine _003CInstallBindings_003Eb__1_0(Instancer instancer)
			{
				BaseLayerStateMachine instance = new BaseLayerStateMachine();
				return instancer.InjectInstance(instance);
			}
		}

		[Token(Token = "0x4001691")]
		[FieldOffset(Offset = "0x18")]
		private List<BaseLayerState> m_states;

		[Token(Token = "0x6001C14")]
		[Address(RVA = "0x3D67AC4", Offset = "0x3D67AC4", Length = "0xA20")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerStateInstaller::InstallBindings");
		}

		[Token(Token = "0x6001C15")]
		[Address(RVA = "0x472EA4C", Offset = "0x472EA4C", Length = "0x1DC")]
		private static void Inject<T>(ref ContainerInstanceBuilder containerBuilder, T state) where T : BaseLayerState
		{
			nint num = 0;
			Func<Instancer, T> factory = (Instancer instancer) => instancer.InjectInstance(state);
			Type[] array = new Type[2];
			Type typeFromHandle = typeof(T);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_016c;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle2 = typeof(BaseLayerState);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_016c;
				}
			}
			array[1] = typeFromHandle2;
			containerBuilder.AddSingleton(factory, array);
			return;
			IL_016c:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6001C16")]
		[Address(RVA = "0x3D684E4", Offset = "0x3D684E4", Length = "0x8")]
		public BaseLayerStateInstaller()
		{
		}
	}
}
