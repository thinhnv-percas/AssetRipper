using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.CommonManagers;
using Unco.ContainerSystem.Runtime;
using Unco.EventBusSystem.Runtime;
using Unco.GameBootstrap.Config;
using _game.CoreGameKit.Tools.AutoScreenshot;
using _game.CoreGameKit.Tracking.Tools.Logging;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Token(Token = "0x20006F0")]
	public class AppCommonManagerInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006F1")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001752")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001753")]
			public static Func<Instancer, CoroutineManager> _003C_003E9__0_0;

			[Token(Token = "0x4001754")]
			public static Func<Instancer, ULogger> _003C_003E9__0_1;

			[Token(Token = "0x6001D58")]
			[Address(RVA = "0x3D776F4", Offset = "0x3D776F4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001D59")]
			[Address(RVA = "0x3D77758", Offset = "0x3D77758", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal CoroutineManager _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				return instancer.AddComponent<CoroutineManager>();
			}

			internal ULogger _003CInstallBindings_003Eb__0_1(Instancer instancer)
			{
				ULogger uLogger = new ULogger();
				ULogger uLogger2 = instancer.InjectInstance(uLogger);
				return uLogger;
			}
		}

		[Token(Token = "0x6001D56")]
		[Address(RVA = "0x3D77474", Offset = "0x3D77474", Length = "0x278")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			//IL_0093: Expected O, but got I4
			//IL_0107: Expected O, but got I4
			//IL_00ea: Expected O, but got I
			Func<Instancer, CoroutineManager> factory = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__0_0 = (Instancer instancer) => instancer.AddComponent<CoroutineManager>());
			}
			containerBuilder.AddSingleton(factory);
			EventBus instance = new EventBus();
			containerBuilder.AddSingleton(instance);
			AutoScreenshotTool instance2 = new AutoScreenshotTool();
			containerBuilder.AddSingleton(instance2);
			int num = 187445248 + 256;
			Func<Instancer, ULogger> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_1;
			object obj2;
			Func<Instancer, ULogger> func;
			object obj;
			if (_003C_003Ec._003C_003E9__0_1 != null)
			{
				obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X21_v6+38]");
				bool flag = (nint)0 == 0;
				obj2 = obj;
				func = _003C_003E9__0_;
				if (!flag)
				{
					goto IL_00c8;
				}
			}
			else
			{
				Func<Instancer, ULogger> func2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer instancer)
				{
					ULogger uLogger = new ULogger();
					ULogger uLogger2 = instancer.InjectInstance(uLogger);
					return uLogger;
				});
				obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X21_v6+38]");
				bool flag2 = (nint)0 == 0;
				bool flag3 = !flag2;
				_003C_003E9__0_ = func2;
				obj2 = obj;
				func = func2;
				if (flag3)
				{
					goto IL_00c8;
				}
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C2B8");
			ContainerBuilder builder = containerBuilder._builder;
			bool flag4 = containerBuilder._builder == null;
			bool flag5 = !flag4;
			obj = obj2;
			_003C_003E9__0_ = func;
			if (!flag5)
			{
				throw new NullReferenceException();
			}
			goto IL_00da;
			IL_00da:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X21_v6+38]");
			object obj3 = 0;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4866318 (Reflex.Core.ContainerBuilder::AddTransient, and 1 more at this address)");
			return;
			IL_00c8:
			builder = containerBuilder._builder;
			goto IL_00da;
		}

		[Token(Token = "0x6001D57")]
		[Address(RVA = "0x3D776EC", Offset = "0x3D776EC", Length = "0x8")]
		public AppCommonManagerInstaller()
		{
		}
	}
}
