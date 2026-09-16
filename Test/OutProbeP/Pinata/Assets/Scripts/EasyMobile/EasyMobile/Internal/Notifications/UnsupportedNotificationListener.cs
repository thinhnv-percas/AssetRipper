using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Notifications
{
	[Token(Token = "0x20000E7")]
	internal class UnsupportedNotificationListener : INotificationListener
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001CA")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006E1")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006E2")]
			public static NativeNotificationHandler _003C_003E9__11_0;

			[Token(Token = "0x40006E3")]
			public static NativeNotificationHandler _003C_003E9__13_0;

			[Token(Token = "0x6000D30")]
			[Address(RVA = "0xC05DB4", Offset = "0xC05DB4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EDF858]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022FE5]) = v37;\nL_0015:\n\tv41 = new EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000D31")]
			[Address(RVA = "0xC05E18", Offset = "0xC05E18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003Cget_NativeNotificationFromForegroundHandler_003Eb__11_0(string param)
			{
			}

			internal void _003Cget_NativeNotificationFromBackgroundHandler_003Eb__13_0(string param)
			{
			}
		}

		[Token(Token = "0x4000425")]
		private static UnsupportedNotificationListener sInstance;

		[CompilerGenerated]
		[Token(Token = "0x4000426")]
		[FieldOffset(Offset = "0x10")]
		private Action<LocalNotification> m_LocalNotificationOpened;

		[CompilerGenerated]
		[Token(Token = "0x4000427")]
		[FieldOffset(Offset = "0x18")]
		private Action<RemoteNotification> m_RemoteNotificationOpened;

		[Token(Token = "0x17000246")]
		public string Name
		{
			[Token(Token = "0x600087D")]
			[Address(RVA = "0xC05BD4", Offset = "0xC05BD4", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1F08920]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022FE2]) = v35;\nL_001A:\n\treturn v41.Empty;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return string.Empty;
			}
		}

		[Token(Token = "0x17000247")]
		public unsafe NativeNotificationHandler NativeNotificationFromForegroundHandler
		{
			[Token(Token = "0x600087E")]
			[Address(RVA = "0xC05C24", Offset = "0xC05C24", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F0B600]);\n\tv17 = *([v16 @ X8_v16]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022FE3]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c;\nL_0020:\n\tv70 = v51.<>9__11_0;\n\tv53 = v51.<>9__11_0 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0045;\n\tgoto L_0033;\n\tv77 = *([v47 @ X0_v3 (Il2CppClass<EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0033;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv85 = EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c;\n\tv81 = *([v85 @ X8_v13+B8]);\nL_0033:\n\tv67 = new EasyMobile.Internal.Notifications.NativeNotificationHandler();\n\tv91 = Il2CppMethodInfo;\n\tv67.m_target = v80.<>9;\n\tv67.method = Il2CppMethodInfo;\n\tv67.method_ptr = *([v91 @ X9_v6 (Il2CppMethodInfo)]);\n\tv65.<>9__11_0 = v67;\nL_0045:\n\treturn v70;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NativeNotificationHandler result = _003C_003Ec._003C_003E9__11_0;
				if (_003C_003Ec._003C_003E9__11_0 == null)
				{
					NativeNotificationHandler nativeNotificationHandler = null;
					IntPtr method_ptr = (IntPtr)0;
					((Delegate)nativeNotificationHandler).m_target = _003C_003Ec._003C_003E9;
					((Delegate)nativeNotificationHandler).method = (IntPtr)__ldftn(_003C_003Ec._003Cget_NativeNotificationFromForegroundHandler_003Eb__11_0);
					((Delegate)nativeNotificationHandler).method_ptr = method_ptr;
					_003C_003Ec._003C_003E9__11_0 = nativeNotificationHandler;
					result = nativeNotificationHandler;
				}
				return result;
			}
		}

		[Token(Token = "0x17000248")]
		public unsafe NativeNotificationHandler NativeNotificationFromBackgroundHandler
		{
			[Token(Token = "0x600087F")]
			[Address(RVA = "0xC05CEC", Offset = "0xC05CEC", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EACBC8]);\n\tv17 = *([v16 @ X8_v16]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022FE4]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c;\nL_0020:\n\tv70 = v51.<>9__13_0;\n\tv53 = v51.<>9__13_0 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0045;\n\tgoto L_0033;\n\tv77 = *([v47 @ X0_v3 (Il2CppClass<EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0033;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv85 = EasyMobile.Internal.Notifications.UnsupportedNotificationListener+<>c;\n\tv81 = *([v85 @ X8_v13+B8]);\nL_0033:\n\tv67 = new EasyMobile.Internal.Notifications.NativeNotificationHandler();\n\tv91 = Il2CppMethodInfo;\n\tv67.m_target = v80.<>9;\n\tv67.method = Il2CppMethodInfo;\n\tv67.method_ptr = *([v91 @ X9_v6 (Il2CppMethodInfo)]);\n\tv65.<>9__13_0 = v67;\nL_0045:\n\treturn v70;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NativeNotificationHandler result = _003C_003Ec._003C_003E9__13_0;
				if (_003C_003Ec._003C_003E9__13_0 == null)
				{
					NativeNotificationHandler nativeNotificationHandler = null;
					IntPtr method_ptr = (IntPtr)0;
					((Delegate)nativeNotificationHandler).m_target = _003C_003Ec._003C_003E9;
					((Delegate)nativeNotificationHandler).method = (IntPtr)__ldftn(_003C_003Ec._003Cget_NativeNotificationFromBackgroundHandler_003Eb__13_0);
					((Delegate)nativeNotificationHandler).method_ptr = method_ptr;
					_003C_003Ec._003C_003E9__13_0 = nativeNotificationHandler;
					result = nativeNotificationHandler;
				}
				return result;
			}
		}

		[Token(Token = "0x1400004B")]
		public event Action<LocalNotification> LocalNotificationOpened
		{
			[CompilerGenerated]
			[Token(Token = "0x6000879")]
			[Address(RVA = "0xC05944", Offset = "0xC05944", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFC220]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FDE]) = v43;\nL_0017:\n\tv45 = this + 0x10;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.LocalNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 16L;
				Delegate obj2 = this.m_LocalNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<LocalNotification>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600087A")]
			[Address(RVA = "0xC059E8", Offset = "0xC059E8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDE650]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FDF]) = v43;\nL_0017:\n\tv45 = this + 0x10;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.LocalNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 16L;
				Delegate obj2 = this.m_LocalNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<LocalNotification>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400004C")]
		public event Action<RemoteNotification> RemoteNotificationOpened
		{
			[CompilerGenerated]
			[Token(Token = "0x600087B")]
			[Address(RVA = "0xC05A8C", Offset = "0xC05A8C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDA930]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FE0]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.RemoteNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_RemoteNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<RemoteNotification>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600087C")]
			[Address(RVA = "0xC05B30", Offset = "0xC05B30", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBFD90]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FE1]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.RemoteNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_RemoteNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<RemoteNotification>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000878")]
		[Address(RVA = "0xC058BC", Offset = "0xC058BC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EE8118]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022FDD]) = v37;\nL_0016:\n\tv49 = v41.sInstance;\n\tv43 = v41.sInstance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002A;\n\tv45 = new EasyMobile.Internal.Notifications.UnsupportedNotificationListener();\n\tSystem.Object::.ctor(v45);\n\tv59.sInstance = v45;\n\tv49 = v61.sInstance;\nL_002A:\n\treturn v49;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static UnsupportedNotificationListener GetListener()
		{
			UnsupportedNotificationListener result = sInstance;
			if (sInstance == null)
			{
				UnsupportedNotificationListener unsupportedNotificationListener = new UnsupportedNotificationListener();
				sInstance = unsupportedNotificationListener;
				result = sInstance;
			}
			return result;
		}

		[Token(Token = "0x6000880")]
		[Address(RVA = "0xC0593C", Offset = "0xC0593C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedNotificationListener()
		{
		}
	}
}
