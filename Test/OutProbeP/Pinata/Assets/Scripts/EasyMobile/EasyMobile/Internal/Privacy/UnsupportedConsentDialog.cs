using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000E3")]
	internal class UnsupportedConsentDialog : IPlatformConsentDialog
	{
		[Token(Token = "0x400041D")]
		private const string UNSUPPORTED_MSG = "Consent dialog is not supported on this platform.";

		[CompilerGenerated]
		[Token(Token = "0x400041E")]
		[FieldOffset(Offset = "0x10")]
		private Action<IPlatformConsentDialog, string, bool> m_ToggleStateUpdated;

		[CompilerGenerated]
		[Token(Token = "0x400041F")]
		[FieldOffset(Offset = "0x18")]
		private Action<IPlatformConsentDialog, string, Dictionary<string, bool>> m_Completed;

		[CompilerGenerated]
		[Token(Token = "0x4000420")]
		[FieldOffset(Offset = "0x20")]
		private Action<IPlatformConsentDialog> m_Dismissed;

		[Token(Token = "0x14000044")]
		public event Action<IPlatformConsentDialog, string, bool> ToggleStateUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x6000852")]
			[Address(RVA = "0xB506C8", Offset = "0xB506C8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFBDA8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022778]) = v43;\nL_0017:\n\tv45 = this + 0x10;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 16L;
				Delegate obj2 = this.m_ToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, bool>))
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
			[Token(Token = "0x6000853")]
			[Address(RVA = "0xB5076C", Offset = "0xB5076C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBE050]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022779]) = v43;\nL_0017:\n\tv45 = this + 0x10;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 16L;
				Delegate obj2 = this.m_ToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, bool>))
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

		[Token(Token = "0x14000045")]
		public event Action<IPlatformConsentDialog, string, Dictionary<string, bool>> Completed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000854")]
			[Address(RVA = "0xB50810", Offset = "0xB50810", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDDD90]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202277A]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_Completed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, Dictionary<string, bool>>))
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
			[Token(Token = "0x6000855")]
			[Address(RVA = "0xB508B4", Offset = "0xB508B4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA51C0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202277B]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`3<EasyMobile.Internal.Privacy.IPlatformConsentDialog, System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_Completed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog, string, Dictionary<string, bool>>))
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

		[Token(Token = "0x14000046")]
		public event Action<IPlatformConsentDialog> Dismissed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000856")]
			[Address(RVA = "0xB50958", Offset = "0xB50958", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED0A30]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202277C]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_Dismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog>))
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
			[Token(Token = "0x6000857")]
			[Address(RVA = "0xB509FC", Offset = "0xB509FC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F10D20]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202277D]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.Internal.Privacy.IPlatformConsentDialog>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_Dismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IPlatformConsentDialog>))
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

		[Token(Token = "0x6000858")]
		[Address(RVA = "0xB50AA0", Offset = "0xB50AA0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsShowing()
		{
			return false;
		}

		[Token(Token = "0x6000859")]
		[Address(RVA = "0xB50AA8", Offset = "0xB50AA8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB63A8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, title, content, isDimissible, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202277E]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, title, content, isDimissible, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Consent dialog is not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show(string title, string content, bool isDimissible)
		{
			Debug.Log("Consent dialog is not supported on this platform.");
		}

		[Token(Token = "0x600085A")]
		[Address(RVA = "0xB50B14", Offset = "0xB50B14", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB9AB0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, buttonId, interactble, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202277F]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, buttonId, interactble, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Consent dialog is not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetButtonInteractable(string buttonId, bool interactble)
		{
			Debug.Log("Consent dialog is not supported on this platform.");
		}

		[Token(Token = "0x600085B")]
		[Address(RVA = "0xB50B80", Offset = "0xB50B80", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEDE48]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, toggleId, isOn, animated, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022780]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, toggleId, isOn, animated, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Consent dialog is not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToggleIsOn(string toggleId, bool isOn, bool animated)
		{
			Debug.Log("Consent dialog is not supported on this platform.");
		}

		[Token(Token = "0x600085C")]
		[Address(RVA = "0xB50BEC", Offset = "0xB50BEC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEC180]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, toggleId, interactable, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022781]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, toggleId, interactable, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Consent dialog is not supported on this platform.\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetToggleInteractable(string toggleId, bool interactable)
		{
			Debug.Log("Consent dialog is not supported on this platform.");
		}

		[Token(Token = "0x600085D")]
		[Address(RVA = "0xB50C58", Offset = "0xB50C58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnsupportedConsentDialog()
		{
		}
	}
}
