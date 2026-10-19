using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.MenuLayer
{
	[CreateAssetMenu(fileName = "UiControllerInstaller", menuName = "Installers/UiControllerInstaller")]
	[Token(Token = "0x20005E2")]
	public class UiControllerInstaller : InstallerSO
	{
		[SerializeField]
		[TypeSelector(typeof(UIController))]
		[Token(Token = "0x4001451")]
		[FieldOffset(Offset = "0x18")]
		private string _controllerTypeName;

		[Token(Token = "0x17000263")]
		private Type ControllerType
		{
			[Token(Token = "0x6001940")]
			[Address(RVA = "0x3D4666C", Offset = "0x3D4666C", Length = "0xAC")]
			get
			{
				if (string.IsNullOrEmpty(_controllerTypeName))
				{
					return null;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1544");
				Type result = default(Type);
				return result;
			}
		}

		[Token(Token = "0x6001941")]
		[Address(RVA = "0x3D46718", Offset = "0x3D46718", Length = "0x1B8")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			//IL_0043: Expected O, but got I
			bool flag = string.IsNullOrEmpty(_controllerTypeName);
			int num = 192761856 + 1336;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Type type = null;
			if (!flag3)
			{
				Type controllerType = ((UiControllerInstaller)(object)_controllerTypeName).ControllerType;
				type = controllerType;
			}
			Type type2 = type;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X22_v5 (System.Int32)+E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v11+E4]");
			if ((nint)0 != 0)
			{
				if (type2 == null)
				{
					return;
				}
			}
			else if (type2 == null)
			{
				return;
			}
			Func<Instancer, UIController> factory = delegate(Instancer instancer)
			{
				bool flag4 = instancer.TryResolve<UiManager>(out var result);
				return result.Show(type2);
			};
			containerBuilder.AddSingleton(factory);
		}

		[Token(Token = "0x6001942")]
		[Address(RVA = "0x3D468D8", Offset = "0x3D468D8", Length = "0x8")]
		public UiControllerInstaller()
		{
		}
	}
	[Token(Token = "0x20005E4")]
	public abstract class UIControllerInstaller<T> : InstallerSO where T : UIController
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005E5")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001453")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001454")]
			public static Func<Instancer, T> _003C_003E9__0_0;

			[Token(Token = "0x6001947")]
			[Address(RVA = "0x4F96360", Offset = "0x4F96360", Length = "0x15C")]
			static _003C_003Ec()
			{
				//IL_01af: Expected O, but got I
				//IL_01b7: Expected I, but got O
				//IL_0247: Expected O, but got I
				//IL_0325: Expected O, but got I
				//IL_02b4: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X0_v1 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X0_v37 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1<T>+<>c<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					nint num4 = 0;
					nint num5 = 0;
					if (!flag)
					{
						goto IL_007e;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X0_v6+C0]");
					object obj = 0;
					nint num4 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X0_v34 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1<T>+<>c<T>>)+135]");
					int num6 = (int)((nint)0 & (nint)1);
					bool flag2 = num6 == 0;
					bool flag3 = !flag2;
					nint num5 = num4;
					if (flag3)
					{
						goto IL_007e;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				_003C_003Ec _003C_003Ec2 = null;
				_003C_003Ec _003C_003Ec3 = _003C_003Ec2;
				goto IL_0090;
				IL_0108:
				_003C_003E9 = _003C_003Ec3;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X0_v29 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1+<>c>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				nint num9 = 0;
				if (!flag4)
				{
					goto IL_0150;
				}
				goto IL_0306;
				IL_0306:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v16+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v14+10]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X0_v11 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1<T>+<>c<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0373;
				IL_0150:
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v27 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1<T>+<>c<T>>)+135]");
				int num12 = (int)((nint)0 & (nint)1);
				bool flag5 = num12 == 0;
				num10 = 0;
				if (!flag5)
				{
					return;
				}
				goto IL_0373;
				IL_007e:
				_003C_003Ec _003C_003Ec4 = null;
				_003C_003Ec3 = _003C_003Ec4;
				goto IL_0090;
				IL_0090:
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X0_v10 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v30 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1<T>+<>c<T>>)+135]");
					int num15 = (int)((nint)0 & (nint)1);
					bool flag6 = num15 == 0;
					nint num16 = 0;
					if (!flag6)
					{
						goto IL_0108;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v21+C0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X8_v21+10]");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X0_v18 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1<T>+<>c<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0108;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X0_v19+B8]");
				object obj4 = 0;
				obj4 = _003C_003Ec3;
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X0_v20 (Il2CppClass<_game.CoreGameKit.MenuLayer.UIControllerInstaller`1+<>c>)+135]");
				int num18 = (int)((nint)0 & (nint)1);
				bool flag7 = num18 == 0;
				bool flag8 = !flag7;
				num9 = 0;
				if (flag8)
				{
					goto IL_0150;
				}
				goto IL_0306;
				IL_0373:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}

			[Token(Token = "0x6001948")]
			[Address(RVA = "0x4F964BC", Offset = "0x4F964BC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal T _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				bool flag = instancer.TryResolve<UiManager>(out var result);
				return result.Show<T>();
			}
		}

		[Token(Token = "0x6001945")]
		[Address(RVA = "0x66345CC", Offset = "0x66345CC", Length = "0x304")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIControllerInstaller::InstallBindings");
		}

		[Token(Token = "0x6001946")]
		[Address(RVA = "0x66348D0", Offset = "0x66348D0", Length = "0x8")]
		protected internal UIControllerInstaller()
		{
		}
	}
}
