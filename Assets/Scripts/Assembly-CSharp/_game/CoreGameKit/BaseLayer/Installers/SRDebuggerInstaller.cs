using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SRDebugger.Services;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.RemoteManagementSystem;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006B4")]
	public class SRDebuggerInstaller : InstallerSO
	{
		[Token(Token = "0x20006B5")]
		private class SRDebuggerRemoteControlService
		{
			[Token(Token = "0x6001C6C")]
			[Address(RVA = "0x3D6E284", Offset = "0x3D6E284", Length = "0x8")]
			public SRDebuggerRemoteControlService()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006B6")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40016BB")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40016BC")]
			public static Func<Instancer, SRDebuggerRemoteControlService> _003C_003E9__4_0;

			[Token(Token = "0x6001C6D")]
			[Address(RVA = "0x3D6E28C", Offset = "0x3D6E28C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001C6E")]
			[Address(RVA = "0x3D6E2F0", Offset = "0x3D6E2F0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal SRDebuggerRemoteControlService _003CInstallBindings_003Eb__4_0(Instancer instancer)
			{
				//IL_02cf: Expected O, but got I4
				//IL_00ad: Expected O, but got I4
				//IL_0169: Expected O, but got I4
				//IL_01e2: Expected O, but got I4
				//IL_019b: Expected O, but got I4
				SRDebuggerRemoteControlService result = new SRDebuggerRemoteControlService();
				bool _003CIsEnabled_003Ek__BackingField;
				if (instancer.TryResolve<RemoteConfigManager>(out var result2))
				{
					bool flag = result2.GetBool(RemoteKey.srdebugger_enabled);
					_003CIsEnabled_003Ek__BackingField = flag;
				}
				else
				{
					Debug.LogWarning("[SRDebugger] RemoteConfigManager not found, defaulting to disabled");
					_003CIsEnabled_003Ek__BackingField = false;
				}
				IsEnabled = _003CIsEnabled_003Ek__BackingField;
				object obj = 186200064;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193B10]");
				int num;
				int num2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					num = 187248640 + 3096;
					bool flag2 = IsEnabled;
					num2 = num;
					if (!flag2)
					{
						goto IL_00a5;
					}
				}
				else
				{
					_ = 1;
					num = 187248640 + 3096;
					bool flag3 = !IsEnabled;
					num2 = num;
					if (flag3)
					{
						goto IL_00a5;
					}
				}
				object obj2 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X0_v19+E4]");
				if ((nint)0 != 0)
				{
					SRDebug.Init();
					object obj3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X0_v24+E4]");
					if ((nint)0 != 0)
					{
						goto IL_00d2;
					}
				}
				else
				{
					SRDebug.Init();
					object obj4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X0_v22+E4]");
					if ((nint)0 != 0)
					{
						goto IL_00d2;
					}
				}
				goto IL_0212;
				IL_026e:
				_ = 1;
				IDebugService debugService;
				bool flag4 = debugService == null;
				bool flag5 = !flag4;
				IDebugService debugService2 = debugService;
				if (flag5)
				{
					goto IL_0302;
				}
				return (SRDebuggerRemoteControlService)(object)new NullReferenceException();
				IL_0302:
				debugService2.IsTriggerEnabled = IsEnabled;
				return result;
				IL_00a5:
				object obj5 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X0_v40+E4]");
				if ((nint)0 != 0)
				{
					goto IL_00d2;
				}
				goto IL_0212;
				IL_00d2:
				IDebugService instance = SRDebug.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193B10]");
				int num3 = (int)((nint)0 & (nint)1);
				bool flag6 = num3 == 0;
				debugService2 = instance;
				debugService = instance;
				if (flag6)
				{
					goto IL_026e;
				}
				goto IL_0302;
				IL_0212:
				IDebugService instance2 = SRDebug.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X22_v2+B10]");
				int num4 = (int)((nint)0 & (nint)1);
				bool flag7 = num4 == 0;
				bool flag8 = !flag7;
				debugService2 = instance2;
				debugService = instance2;
				if (flag8)
				{
					goto IL_0302;
				}
				goto IL_026e;
			}
		}

		[Token(Token = "0x170002D7")]
		[field: Token(Token = "0x40016BA")]
		public static bool IsEnabled
		{
			[Token(Token = "0x6001C68")]
			[Address(RVA = "0x3D6E068", Offset = "0x3D6E068", Length = "0x4C")]
			get;
			[Token(Token = "0x6001C69")]
			[Address(RVA = "0x3D6E0B4", Offset = "0x3D6E0B4", Length = "0x58")]
			private set;
		}

		[Token(Token = "0x6001C6A")]
		[Address(RVA = "0x3D6E10C", Offset = "0x3D6E10C", Length = "0x170")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerInstaller::InstallBindings");
		}

		[Token(Token = "0x6001C6B")]
		[Address(RVA = "0x3D6E27C", Offset = "0x3D6E27C", Length = "0x8")]
		public SRDebuggerInstaller()
		{
		}
	}
}
