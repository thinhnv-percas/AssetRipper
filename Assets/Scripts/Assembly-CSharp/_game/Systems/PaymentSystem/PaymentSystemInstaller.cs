using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.RewardSystem;
using _game.Systems.PaymentSystem.Core;
using _game.Systems.PaymentSystem.Flow;
using _game.Systems.PaymentSystem.PurchaseHandlers;
using _game.Systems.ShopSystem.Scripts.Core;

namespace _game.Systems.PaymentSystem
{
	[Token(Token = "0x200073E")]
	public class PaymentSystemInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200073F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001848")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001849")]
			public static Func<Instancer, PaymentFlowController> _003C_003E9__0_0;

			[Token(Token = "0x6001E8E")]
			[Address(RVA = "0x3D86C34", Offset = "0x3D86C34", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001E8F")]
			[Address(RVA = "0x3D86C98", Offset = "0x3D86C98", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal PaymentFlowController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				bool flag = instancer.TryResolve<PaymentExecutor>(out var result);
				return new PaymentFlowController(result, instancer);
			}
		}

		[Token(Token = "0x6001E8C")]
		[Address(RVA = "0x3D866B4", Offset = "0x3D866B4", Length = "0x550")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			//IL_0234: Expected O, but got I4
			//IL_02b1: Expected O, but got I4
			//IL_033a: Expected O, but got I
			FreePaymentExecutor freePaymentExecutor = new FreePaymentExecutor();
			AdPaymentExecutor adPaymentExecutor = new AdPaymentExecutor();
			IAPPaymentExecutor iAPPaymentExecutor = new IAPPaymentExecutor();
			ResourcePaymentExecutor resourcePaymentExecutor = new ResourcePaymentExecutor();
			containerBuilder.AddSingleton(freePaymentExecutor);
			containerBuilder.AddSingleton(adPaymentExecutor);
			containerBuilder.AddSingleton(iAPPaymentExecutor);
			containerBuilder.AddSingleton(resourcePaymentExecutor);
			IPaymentInnerExecutor[] array = new IPaymentInnerExecutor[4];
			if (freePaymentExecutor != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0443;
				}
			}
			array[0] = freePaymentExecutor;
			if (adPaymentExecutor != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0443;
				}
			}
			array[1] = adPaymentExecutor;
			if (iAPPaymentExecutor != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_0443;
				}
			}
			array[2] = iAPPaymentExecutor;
			if (resourcePaymentExecutor != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_0443;
				}
			}
			array[3] = resourcePaymentExecutor;
			PaymentExecutor instance = new PaymentExecutor(array);
			containerBuilder.AddSingleton(instance);
			int num = 187441152 + 2488;
			Func<Instancer, PaymentFlowController> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			Func<Instancer, PaymentFlowController> func;
			object obj6;
			object obj5;
			if (_003C_003Ec._003C_003E9__0_0 != null)
			{
				obj5 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ X21_v8+38]");
				bool flag = (nint)0 == 0;
				func = _003C_003E9__0_;
				obj6 = obj5;
				if (!flag)
				{
					goto IL_0269;
				}
			}
			else
			{
				Func<Instancer, PaymentFlowController> func2 = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					bool flag4 = instancer.TryResolve<PaymentExecutor>(out var result);
					return new PaymentFlowController(result, instancer);
				});
				obj5 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ X21_v8+38]");
				bool flag2 = (nint)0 == 0;
				bool flag3 = !flag2;
				_003C_003E9__0_ = func2;
				func = func2;
				obj6 = obj5;
				if (flag3)
				{
					goto IL_0269;
				}
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C2B8");
			ContainerBuilder builder = containerBuilder._builder;
			_003C_003E9__0_ = func;
			obj5 = obj6;
			goto IL_032a;
			IL_0443:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
			IL_032a:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ X21_v8+38]");
			object obj7 = 0;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4865FA8 (Reflex.Core.ContainerBuilder::AddScoped, and 1 more at this address)");
			ResourcePurchaseHandler resourcePurchaseHandler = new ResourcePurchaseHandler();
			BoosterPurchaseHandler boosterPurchaseHandler = new BoosterPurchaseHandler();
			HealthPurchaseHandler healthPurchaseHandler = new HealthPurchaseHandler();
			IAPPurchaseHandler iAPPurchaseHandler = new IAPPurchaseHandler();
			containerBuilder.AddSingleton(resourcePurchaseHandler);
			containerBuilder.AddSingleton(boosterPurchaseHandler);
			containerBuilder.AddSingleton(healthPurchaseHandler);
			containerBuilder.AddSingleton(iAPPurchaseHandler);
			PurchaseHandlerRegistry purchaseHandlerRegistry = new PurchaseHandlerRegistry();
			purchaseHandlerRegistry.Register<ResourceItemData>(resourcePurchaseHandler);
			purchaseHandlerRegistry.Register<ShopResourceItemData>(resourcePurchaseHandler);
			purchaseHandlerRegistry.Register<BoosterShopItemData>(boosterPurchaseHandler);
			purchaseHandlerRegistry.Register<HealthShopItemData>(healthPurchaseHandler);
			purchaseHandlerRegistry.Register<IAPShopItemData>(iAPPurchaseHandler);
			containerBuilder.AddSingleton(purchaseHandlerRegistry);
			return;
			IL_0269:
			builder = containerBuilder._builder;
			if (containerBuilder._builder != null)
			{
				goto IL_032a;
			}
			NullReferenceException ex2 = new NullReferenceException();
			goto IL_0443;
		}

		[Token(Token = "0x6001E8D")]
		[Address(RVA = "0x3D86C2C", Offset = "0x3D86C2C", Length = "0x8")]
		public PaymentSystemInstaller()
		{
		}
	}
}
