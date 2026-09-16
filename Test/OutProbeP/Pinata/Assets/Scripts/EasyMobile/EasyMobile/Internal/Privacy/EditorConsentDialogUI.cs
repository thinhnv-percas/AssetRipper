using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000DF")]
	public class EditorConsentDialogUI : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001C4")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006CE")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006CF")]
			public static Action<string> _003C_003E9__40_0;

			[Token(Token = "0x40006D0")]
			public static Func<KeyValuePair<string, EditorConsentDialogToggleUI>, string> _003C_003E9__43_0;

			[Token(Token = "0x40006D1")]
			public static Func<KeyValuePair<string, EditorConsentDialogToggleUI>, bool> _003C_003E9__43_1;

			[Token(Token = "0x6000D1F")]
			[Address(RVA = "0xB4FA8C", Offset = "0xB4FA8C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EEE390]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022763]) = v37;\nL_0015:\n\tv41 = new EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000D20")]
			[Address(RVA = "0xB4FAF0", Offset = "0xB4FAF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CAddPlainText_003Eb__40_0(string link)
			{
				char[] array = new char[1];
				if (array.Length != 0)
				{
					array[0] = '"';
					string text = link.TrimStart(array);
					char[] array2 = new char[1];
					if (array2.Length != 0)
					{
						array2[0] = '"';
						string url = text.TrimEnd(array2);
						Application.OpenURL(url);
						return;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}

			internal string _003CGetTogglesResult_003Eb__43_0(KeyValuePair<string, EditorConsentDialogToggleUI> toggle)
			{
				return (string)toggle;
			}

			internal bool _003CGetTogglesResult_003Eb__43_1(KeyValuePair<string, EditorConsentDialogToggleUI> toggle)
			{
				//IL_000e: Expected O, but got I
				IntPtr intPtr = default(IntPtr);
				return ((EditorConsentDialogToggleUI)(long)intPtr).IsOn;
			}
		}

		[SerializeField]
		[Token(Token = "0x40003FD")]
		[FieldOffset(Offset = "0x18")]
		private RectTransform rootTransform;

		[SerializeField]
		[Token(Token = "0x40003FE")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform contentParent;

		[SerializeField]
		[Token(Token = "0x40003FF")]
		[FieldOffset(Offset = "0x28")]
		private Text titleText;

		[SerializeField]
		[Token(Token = "0x4000400")]
		[FieldOffset(Offset = "0x30")]
		private Button backButton;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x733D3C", Offset = "0x733D3C")]
		[SerializeField]
		[Token(Token = "0x4000401")]
		[FieldOffset(Offset = "0x38")]
		private EditorConsentDialogToggleUI togglePrefab;

		[SerializeField]
		[Token(Token = "0x4000402")]
		[FieldOffset(Offset = "0x40")]
		private EditorConsentDialogClickableText plainTextPrefab;

		[SerializeField]
		[Token(Token = "0x4000403")]
		[FieldOffset(Offset = "0x48")]
		private EditorConsentDialogButtonUI buttonPrefab;

		[CompilerGenerated]
		[Token(Token = "0x4000404")]
		[FieldOffset(Offset = "0x50")]
		private Action<string, Dictionary<string, bool>> m_OnCompleteted;

		[CompilerGenerated]
		[Token(Token = "0x4000405")]
		[FieldOffset(Offset = "0x58")]
		private Action m_OnDismissed;

		[CompilerGenerated]
		[Token(Token = "0x4000406")]
		[FieldOffset(Offset = "0x60")]
		private Action<string, bool> m_OnToggleStateUpdated;

		[CompilerGenerated]
		[Token(Token = "0x4000407")]
		[FieldOffset(Offset = "0x68")]
		private bool _003CIsShowing_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000408")]
		[FieldOffset(Offset = "0x69")]
		private bool _003CIsDismissible_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000409")]
		[FieldOffset(Offset = "0x6A")]
		private bool _003CIsConstructed_003Ek__BackingField;

		[Token(Token = "0x400040A")]
		[FieldOffset(Offset = "0x70")]
		private Dictionary<string, EditorConsentDialogButtonUI> createdButtons;

		[Token(Token = "0x400040B")]
		[FieldOffset(Offset = "0x78")]
		private Dictionary<string, EditorConsentDialogToggleUI> createdToggles;

		[Token(Token = "0x17000236")]
		public RectTransform RectTransform
		{
			[Token(Token = "0x6000808")]
			[Address(RVA = "0xB4ED04", Offset = "0xB4ED04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rootTransform;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RectTransform;
			}
		}

		[Token(Token = "0x17000237")]
		public bool IsShowing
		{
			[CompilerGenerated]
			[Token(Token = "0x6000809")]
			[Address(RVA = "0xB4ED0C", Offset = "0xB4ED0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsShowing>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsShowing;
			}
			[CompilerGenerated]
			[Token(Token = "0x600080A")]
			[Address(RVA = "0xB4ED14", Offset = "0xB4ED14", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsShowing>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CIsShowing_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000238")]
		public bool IsDismissible
		{
			[CompilerGenerated]
			[Token(Token = "0x600080B")]
			[Address(RVA = "0xB4ED20", Offset = "0xB4ED20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsDismissible>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsDismissible;
			}
			[CompilerGenerated]
			[Token(Token = "0x600080C")]
			[Address(RVA = "0xB4ED28", Offset = "0xB4ED28", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsDismissible>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CIsDismissible_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000239")]
		public bool IsConstructed
		{
			[CompilerGenerated]
			[Token(Token = "0x600080D")]
			[Address(RVA = "0xB4ED34", Offset = "0xB4ED34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsConstructed>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsConstructed;
			}
			[CompilerGenerated]
			[Token(Token = "0x600080E")]
			[Address(RVA = "0xB4ED3C", Offset = "0xB4ED3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsConstructed>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CIsConstructed_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x14000036")]
		public event Action<string, Dictionary<string, bool>> OnCompleteted
		{
			[CompilerGenerated]
			[Token(Token = "0x6000802")]
			[Address(RVA = "0xB4E92C", Offset = "0xB4E92C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC3628]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022753]) = v43;\nL_0017:\n\tv45 = this + 0x50;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 80L;
				Delegate obj2 = this.m_OnCompleteted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string, Dictionary<string, bool>>))
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
			[Token(Token = "0x6000803")]
			[Address(RVA = "0xB4E9D0", Offset = "0xB4E9D0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EEE0C0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022754]) = v43;\nL_0017:\n\tv45 = this + 0x50;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, System.Collections.Generic.Dictionary`2<System.String, System.Boolean>>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 80L;
				Delegate obj2 = this.m_OnCompleteted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string, Dictionary<string, bool>>))
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

		[Token(Token = "0x14000037")]
		public event Action OnDismissed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000804")]
			[Address(RVA = "0xB4EA74", Offset = "0xB4EA74", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDC460]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022755]) = v43;\nL_0017:\n\tv45 = this + 0x58;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 88L;
				Delegate obj2 = this.m_OnDismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action))
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
			[Token(Token = "0x6000805")]
			[Address(RVA = "0xB4EB18", Offset = "0xB4EB18", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA8CA8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022756]) = v43;\nL_0017:\n\tv45 = this + 0x58;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 88L;
				Delegate obj2 = this.m_OnDismissed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action))
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

		[Token(Token = "0x14000038")]
		public event Action<string, bool> OnToggleStateUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x6000806")]
			[Address(RVA = "0xB4EBBC", Offset = "0xB4EBBC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EABB28]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022757]) = v43;\nL_0017:\n\tv45 = this + 0x60;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 96L;
				Delegate obj2 = this.m_OnToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string, bool>))
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
			[Token(Token = "0x6000807")]
			[Address(RVA = "0xB4EC60", Offset = "0xB4EC60", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB9C40]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022758]) = v43;\nL_0017:\n\tv45 = this + 0x60;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 96L;
				Delegate obj2 = this.m_OnToggleStateUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string, bool>))
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

		[Token(Token = "0x600080F")]
		[Address(RVA = "0xB4ED48", Offset = "0xB4ED48", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFE788]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022759]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogButtonUI>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogButtonUI>::.ctor(v42);\n\tthis.createdButtons = v42;\n\tv50 = new System.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>::.ctor(v50);\n\tthis.createdToggles = v50;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Awake()
		{
			Dictionary<string, EditorConsentDialogButtonUI> dictionary = new Dictionary<string, EditorConsentDialogButtonUI>();
			createdButtons = dictionary;
			Dictionary<string, EditorConsentDialogToggleUI> dictionary2 = new Dictionary<string, EditorConsentDialogToggleUI>();
			createdToggles = dictionary2;
		}

		[Token(Token = "0x6000810")]
		[Address(RVA = "0xB4EDD8", Offset = "0xB4EDD8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1F090E8]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202275A]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(this.backButton, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_004A;\n\tv61 = this.backButton;\n\tv72 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v72, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v61.m_OnClick, v72);\n\treturn;\nL_004A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Start()
		{
			if (!(backButton != null))
			{
				return;
			}
			Button button = backButton;
			UnityAction call = delegate
			{
				if (IsDismissible)
				{
					Dismiss();
				}
			};
			button.onClick.AddListener(call);
		}

		[Token(Token = "0x6000811")]
		[Address(RVA = "0xB4EEB8", Offset = "0xB4EEB8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this.<IsConstructed>k__BackingField;\n\tif (v11) goto L_0020;\n\tv13 = ~this.<IsShowing>k__BackingField;\n\tif (v13) goto L_0020;\n\tv18 = UnityEngine.Input::GetKeyDown(0x1B);\n\tv20 = v18 == 0;\n\tif (v20) goto L_0020;\n\tv21 = ~this.<IsDismissible>k__BackingField;\n\tif (v21) goto L_0020;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogUI::Dismiss(this);\n\treturn;\nL_0020:\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Update()
		{
			if (IsConstructed && IsShowing && Input.GetKeyDown(KeyCode.Escape) && IsDismissible)
			{
				Dismiss();
			}
		}

		[Token(Token = "0x6000812")]
		[Address(RVA = "0xB4EF3C", Offset = "0xB4EF3C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F01358]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, buttonId, interactble, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202275B]) = v44;\nL_0017:\n\tv45 = buttonId == 0;\n\tif (v45) goto L_003F;\n\tv47 = this.createdButtons == 0;\n\tif (v47) goto L_003F;\n\tv53 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogButtonUI>::ContainsKey(this.createdButtons, buttonId);\n\tv55 = v53 == 0;\n\tif (v55) goto L_003F;\n\tv74 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogButtonUI>::get_Item(this.createdButtons, buttonId);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogButtonUI::set_Interactable(v74, interactble);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetButtonInteractable(string buttonId, bool interactble)
		{
			if (buttonId != null && createdButtons != null && createdButtons.ContainsKey(buttonId))
			{
				EditorConsentDialogButtonUI editorConsentDialogButtonUI = createdButtons.get_Item(buttonId);
				editorConsentDialogButtonUI.Interactable = interactble;
			}
		}

		[Token(Token = "0x6000813")]
		[Address(RVA = "0xB4EFE8", Offset = "0xB4EFE8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1EDA578]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, title, isDimissible, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202275C]) = v46;\nL_001F:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, title, isDimissible, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0028:\n\tv64 = UnityEngine.Object::op_Inequality(this.titleText, 0);\n\tv65 = title == 0;\n\tif (v65) goto L_003B;\n\tv67 = v64 == 0;\n\tif (v67) goto L_003B;\n\tv76 = UnityEngine.UI.Text::set_text(this.titleText, title);\nL_003B:\n\tgoto L_0044;\n\tv87 = *([v81 @ X0_v7+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0044;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v81, v73, v71, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0044:\n\tv97 = UnityEngine.Object::op_Inequality(this.backButton, 0);\n\tv112 = v97 == 0;\n\tif (v112) goto L_0054;\n\tv104 = UnityEngine.Component::get_gameObject(this.backButton);\n\tUnityEngine.GameObject::SetActive(v104, isDimissible);\nL_0054:\n\tthis.<IsConstructed>k__BackingField = 1;\n\tthis.<IsDismissible>k__BackingField = isDimissible;\n\treturn this;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogUI Construct(string title, bool isDimissible)
		{
			bool flag = titleText != null;
			if (title != null && flag)
			{
				titleText.text = title;
			}
			if (backButton != null)
			{
				GameObject gameObject = backButton.gameObject;
				gameObject.SetActive(isDimissible);
			}
			IsConstructed = true;
			IsDismissible = isDimissible;
			return this;
		}

		[Token(Token = "0x6000814")]
		[Address(RVA = "0xB4F100", Offset = "0xB4F100", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECD190]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202275D]) = v38;\nL_0014:\n\tv40 = ~this.<IsConstructed>k__BackingField;\n\tif (v40) goto L_0040;\n\tv42 = ~this.<IsShowing>k__BackingField;\n\tv43 = ~v42;\n\tif (v43) goto L_0040;\n\tgoto L_002A;\n\tv83 = *([v67 @ X0_v3+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002A;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv52 = UnityEngine.Object::op_Equality(this.rootTransform, 0);\n\tv91 = v52 == 0;\n\tv55 = ~v91;\n\tif (v55) goto L_0040;\n\tv51 = UnityEngine.Component::get_gameObject(this.rootTransform);\n\tUnityEngine.GameObject::SetActive(v51, 1);\n\tthis.<IsShowing>k__BackingField = 1;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show()
		{
			if (IsConstructed && !IsShowing && !(RectTransform == null))
			{
				GameObject gameObject = RectTransform.gameObject;
				gameObject.SetActive(value: true);
				IsShowing = true;
			}
		}

		[Token(Token = "0x6000815")]
		[Address(RVA = "0xB4F1B4", Offset = "0xB4F1B4", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC8258]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202275E]) = v38;\nL_0014:\n\tv40 = ~this.<IsConstructed>k__BackingField;\n\tif (v40) goto L_003E;\n\tv42 = ~this.<IsShowing>k__BackingField;\n\tif (v42) goto L_003E;\n\tgoto L_0029;\n\tv81 = *([v65 @ X0_v3+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0029;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv51 = UnityEngine.Object::op_Equality(this.rootTransform, 0);\n\tv89 = v51 == 0;\n\tv54 = ~v89;\n\tif (v54) goto L_003E;\n\tv50 = UnityEngine.Component::get_gameObject(this.rootTransform);\n\tUnityEngine.GameObject::SetActive(v50, 0);\n\tthis.<IsShowing>k__BackingField = 0;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Hide()
		{
			if (IsConstructed && IsShowing && !(RectTransform == null))
			{
				GameObject gameObject = RectTransform.gameObject;
				gameObject.SetActive(value: false);
				IsShowing = false;
			}
		}

		[Token(Token = "0x6000816")]
		[Address(RVA = "0xB4EF0C", Offset = "0xB4EF0C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.OnDismissed == 0;\n\tif (v11) goto L_0010;\n\tSystem.Action::Invoke(this.OnDismissed);\nL_0010:\n\tEasyMobile.Internal.Privacy.EditorConsentDialogUI::Hide(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dismiss()
		{
			if (this.OnDismissed != null)
			{
				this.OnDismissed();
			}
			Hide();
		}

		[Token(Token = "0x6000817")]
		[Address(RVA = "0xB4F264", Offset = "0xB4F264", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EFEE90]);\n\tv25 = *([v24 @ X8_v33]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202275F]) = v43;\nL_0016:\n\tv44 = text == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_0028;\n\tv53 = *([v48 @ X0_v4+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v48, text, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0028:\n\tv63 = UnityEngine.Object::op_Equality(this.plainTextPrefab, 0);\n\tv103 = v63 == 0;\n\tv81 = ~v103;\n\tif (v81) goto L_009F;\n\tgoto L_003C;\n\tv128 = *([v123 @ X0_v8+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_003C;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v123, v61, v62, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003C:\n\tv78 = UnityEngine.Object::op_Equality(this.contentParent, 0);\n\tv136 = v78 == 0;\n\tv82 = ~v136;\n\tif (v82) goto L_009F;\n\tgoto L_0051;\n\tv142 = *([v137 @ X0_v12+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0051;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v137, v73, v70, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0051:\n\tv153 = UnityEngine.Object::Instantiate(this.plainTextPrefab);\n\tv160 = UnityEngine.UI.Text::set_text(v153, text);\n\tv163 = UnityEngine.UI.Graphic::get_rectTransform(v153);\n\tUnityEngine.Transform::SetParent(v163, this.contentParent, 0);\n\tgoto L_0072;\n\tv174 = *([v170 @ X0_v22 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c>)+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_0072;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v170, v166, v167, v168, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv178 = EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c;\nL_0072:\n\tv85 = v181.<>9__40_0;\n\tv183 = v181.<>9__40_0 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0094;\n\tgoto L_0085;\n\tv200 = *([v177 @ X0_v23 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c>)+E0]);\n\tv201 = v200 == 0;\n\tv202 = ~v201;\n\tif (v202) goto L_0085;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v177, v166, v167, v168, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv214 = EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c;\n\tv207 = *([v214 @ X8_v25+B8]);\nL_0085:\n\tv195 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v195, v206.<>9, Il2CppMethodInfo);\n\tv199.<>9__40_0 = v195;\nL_0094:\n\tEasyMobile.Internal.Privacy.EditorConsentDialogClickableText::add_OnHyperlinkClicked(v153, v85);\n\tgoto L_009F;\nL_009F:\n\treturn v91;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogClickableText AddPlainText(string text)
		{
			EditorConsentDialogClickableText result;
			if (text != null)
			{
				bool flag = plainTextPrefab == null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = null;
				if (!flag3)
				{
					bool flag4 = contentParent == null;
					bool flag5 = !flag4;
					bool flag6 = !flag5;
					result = null;
					if (!flag6)
					{
						EditorConsentDialogClickableText editorConsentDialogClickableText = UnityEngine.Object.Instantiate(plainTextPrefab);
						editorConsentDialogClickableText.text = text;
						RectTransform rectTransform = editorConsentDialogClickableText.rectTransform;
						rectTransform.SetParent(contentParent, worldPositionStays: false);
						Action<string> value = _003C_003Ec._003C_003E9__40_0;
						if (_003C_003Ec._003C_003E9__40_0 == null)
						{
							value = (_003C_003Ec._003C_003E9__40_0 = delegate(string link)
							{
								char[] array = new char[1];
								if (array.Length != 0)
								{
									array[0] = '"';
									string text2 = link.TrimStart(array);
									char[] array2 = new char[1];
									if (array2.Length != 0)
									{
										array2[0] = '"';
										string url = text2.TrimEnd(array2);
										Application.OpenURL(url);
										return;
									}
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
							});
						}
						editorConsentDialogClickableText.OnHyperlinkClicked += value;
						result = editorConsentDialogClickableText;
					}
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		[Token(Token = "0x6000818")]
		[Address(RVA = "0xB4F440", Offset = "0xB4F440", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EFF3B0]);\n\tv25 = *([v24 @ X8_v39]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, buttonData, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022760]) = v43;\nL_0019:\n\tv47 = new EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c__DisplayClass41_0();\n\tSystem.Object::.ctor(v47);\n\tv47.<>4__this = this;\n\tv47.buttonData = buttonData;\n\tgoto L_0031;\n\tv109 = *([v54 @ X0_v8+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0031;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v54, v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0031:\n\tv119 = UnityEngine.Object::op_Equality(this.buttonPrefab, 0);\n\tv162 = v119 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_00DD;\n\tgoto L_0045;\n\tv227 = *([v164 @ X0_v14+E0]);\n\tv228 = v227 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0045;\n\tv231 = \"il2cpp_codegen_runtime_class_init\"(v164, v117, v118, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0045:\n\tv88 = UnityEngine.Object::op_Equality(this.contentParent, 0);\n\tv235 = v88 == 0;\n\tv191 = ~v235;\n\tif (v191) goto L_00DD;\n\tv103 = v47.buttonData;\n\tv89 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogButtonUI>::ContainsKey(this.createdButtons, v103.id);\n\tv239 = v89 == 0;\n\tif (v239) goto L_007D;\n\tv104 = v47.buttonData;\n\tv251 = System.String::Concat(\"Ignored a button with duplicated id: \", v104.id, \"!!!\");\n\tgoto L_0075;\n\tv266 = *([v200 @ X8_v34+E0]);\n\tv267 = v266 == 0;\n\tv268 = ~v267;\n\tif (v268) goto L_0075;\n\tv271 = v200;\n\tv270 = \"il2cpp_codegen_runtime_class_init\"(v271, v245, v183, v177, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0075:\n\tUnityEngine.Debug::LogWarning(v251);\n\tgoto L_00DD;\nL_007D:\n\tgoto L_0087;\n\tv252 = *([v240 @ X0_v20+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\tif (v254) goto L_0087;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v240, v83, v76, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0087:\n\tv90 = UnityEngine.Object::Instantiate(this.buttonPrefab);\n\tv105 = v47.buttonData;\n\tUnityEngine.UI.Selectable::set_interactable(v90.button, v105.interactable);\n\tv106 = v47.buttonData;\n\tEasyMobile.Internal.Privacy.EditorConsentDialogButtonUI::UpdateText(v90, v106.title);\n\tv129 = EasyMobile.ConsentDialog+Button::GetCurrentTitleColor(v47.buttonData);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogButtonUI::UpdateTextColor(v90, v129);\n\tv71 = EasyMobile.ConsentDialog+Button::GetCurrentBodyColor(v47.buttonData);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogButtonUI::UpdateBackgroundColor(v90, v71);\n\tv279 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v279, v47, Il2CppMethodInfo);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogButtonUI::AddListener(v90, v279);\n\tv92 = UnityEngine.Component::get_transform(v90.button);\n\tUnityEngine.Transform::SetParent(v92, this.contentParent, 0);\n\tv107 = v47.buttonData;\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogButtonUI>::Add(this.createdButtons, v107.id, v90);\nL_00DD:\n\treturn v195;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 155 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogButtonUI AddButton(ConsentDialog.Button buttonData)
		{
			bool flag = buttonPrefab == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			EditorConsentDialogButtonUI result = null;
			if (!flag3)
			{
				bool flag4 = contentParent == null;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = null;
				if (!flag6)
				{
					ConsentDialog.Button button = buttonData;
					if (createdButtons.ContainsKey(button.Id))
					{
						ConsentDialog.Button button2 = buttonData;
						string message = "Ignored a button with duplicated id: " + button2.Id + "!!!";
						Debug.LogWarning(message);
						result = null;
					}
					else
					{
						EditorConsentDialogButtonUI editorConsentDialogButtonUI = UnityEngine.Object.Instantiate(buttonPrefab);
						ConsentDialog.Button button3 = buttonData;
						editorConsentDialogButtonUI.Button.interactable = button3.IsInteractable;
						ConsentDialog.Button button4 = buttonData;
						editorConsentDialogButtonUI.UpdateText(button4.Title);
						Color currentTitleColor = buttonData.GetCurrentTitleColor();
						editorConsentDialogButtonUI.UpdateTextColor(currentTitleColor);
						Color currentBodyColor = buttonData.GetCurrentBodyColor();
						editorConsentDialogButtonUI.UpdateBackgroundColor(currentBodyColor);
						UnityAction action = delegate
						{
							Hide();
							EditorConsentDialogUI editorConsentDialogUI = this;
							if (editorConsentDialogUI.OnCompleteted != null)
							{
								ConsentDialog.Button button6 = buttonData;
								Dictionary<string, bool> togglesResult = editorConsentDialogUI.GetTogglesResult();
								editorConsentDialogUI.OnCompleteted(button6.Id, togglesResult);
							}
						};
						editorConsentDialogButtonUI.AddListener(action);
						Transform transform = editorConsentDialogButtonUI.Button.transform;
						transform.SetParent(contentParent, worldPositionStays: false);
						ConsentDialog.Button button5 = buttonData;
						createdButtons.Add(button5.Id, editorConsentDialogButtonUI);
						result = editorConsentDialogButtonUI;
					}
				}
			}
			return result;
		}

		[Token(Token = "0x6000819")]
		[Address(RVA = "0xB4F6E0", Offset = "0xB4F6E0", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EDE4E8]);\n\tv25 = *([v24 @ X8_v32]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, toggleData, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022761]) = v43;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, toggleData, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = UnityEngine.Object::op_Equality(this.togglePrefab, 0);\n\tv64 = v61 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_00AF;\n\tgoto L_003A;\n\tv137 = *([v66 @ X0_v8+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_003A;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v66, v59, v60, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003A:\n\tv114 = UnityEngine.Object::op_Equality(this.contentParent, 0);\n\tv183 = v114 == 0;\n\tv118 = ~v183;\n\tif (v118) goto L_00AF;\n\tv192 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>::ContainsKey(this.createdToggles, toggleData.id);\n\tv223 = v192 == 0;\n\tif (v223) goto L_006E;\n\tv244 = System.String::Concat(\"Ignored a toggle with duplicated id: \", toggleData.id, \"!!!\");\n\tgoto L_0066;\n\tv264 = *([v125 @ X8_v27+E0]);\n\tv265 = v264 == 0;\n\tv266 = ~v265;\n\tif (v266) goto L_0066;\n\tv269 = v125;\n\tv268 = \"il2cpp_codegen_runtime_class_init\"(v269, v240, v107, v100, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0066:\n\tUnityEngine.Debug::LogWarning(v244);\n\tgoto L_00AF;\nL_006E:\n\tgoto L_0078;\n\tv255 = *([v245 @ X0_v19+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_0078;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v245, v189, v191, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tv212 = UnityEngine.Object::Instantiate(this.togglePrefab);\n\tEasyMobile.Internal.Privacy.EditorConsentDialogToggleUI::UpdateSettings(v212, toggleData);\n\tv235 = System.Delegate::Combine(v212.OnToggleStateUpdated, this.OnToggleStateUpdated);\n\tv236 = v235 == 0;\n\tif (v236) goto L_0094;\n\tv224 = *([v235 @ X0_v25 (System.Delegate)]) != System.Action`2<System.String, System.Boolean>;\n\tif (v224) goto L_00B2;\nL_0094:\n\tv212.OnToggleStateUpdated = v235;\n\tv213 = UnityEngine.Component::get_transform(v212);\n\tUnityEngine.Transform::SetParent(v213, this.contentParent, 0);\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>::Add(this.createdToggles, toggleData.id, v212);\nL_00AF:\n\treturn v126;\n\tv221 = new System.NullReferenceException();\nL_00B2:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogToggleUI AddToggle(ConsentDialog.Toggle toggleData)
		{
			bool flag = togglePrefab == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			EditorConsentDialogToggleUI result = null;
			if (!flag3)
			{
				bool flag4 = contentParent == null;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				result = null;
				if (!flag6)
				{
					if (createdToggles.ContainsKey(toggleData.Id))
					{
						string message = "Ignored a toggle with duplicated id: " + toggleData.Id + "!!!";
						Debug.LogWarning(message);
						result = null;
					}
					else
					{
						EditorConsentDialogToggleUI editorConsentDialogToggleUI = UnityEngine.Object.Instantiate(togglePrefab);
						editorConsentDialogToggleUI.UpdateSettings(toggleData);
						Delegate obj = Delegate.Combine(editorConsentDialogToggleUI.OnToggleStateUpdated, this.OnToggleStateUpdated);
						if (obj != null && (object)obj.GetType() != typeof(Action<string, bool>))
						{
							return (EditorConsentDialogToggleUI)(object)new InvalidCastException();
						}
						editorConsentDialogToggleUI.OnToggleStateUpdated = (Action<string, bool>)obj;
						Transform transform = editorConsentDialogToggleUI.transform;
						transform.SetParent(contentParent, worldPositionStays: false);
						createdToggles.Add(toggleData.Id, editorConsentDialogToggleUI);
						result = editorConsentDialogToggleUI;
					}
				}
			}
			return result;
		}

		[Token(Token = "0x600081A")]
		[Address(RVA = "0xB4F8E4", Offset = "0xB4F8E4", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED5CB8]);\n\tv25 = *([v24 @ X8_v34]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022762]) = v44;\nL_0017:\n\tv46 = this.createdToggles == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_0027;\n\tv54 = *([v49 @ X0_v4 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0027;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv58 = EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c;\nL_0027:\n\tv86 = v61.<>9__43_0;\n\tv63 = v61.<>9__43_0 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_004A;\n\tgoto L_003A;\n\tv118 = *([v57 @ X0_v5 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_003A;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv164 = EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c;\n\tv125 = *([v164 @ X8_v30+B8]);\nL_003A:\n\tv129 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>, System.String>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>, System.String>::.ctor(v129, v124.<>9, Il2CppMethodInfo);\n\tv113.<>9__43_0 = v129;\nL_004A:\n\tgoto L_0052;\n\tv130 = *([v108 @ X0_v6 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c>)+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tgoto L_0052;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v108, v104, v102, v100, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv134 = EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c;\nL_0052:\n\tv68 = v137.<>9__43_1;\n\tv139 = v137.<>9__43_1 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0078;\n\tgoto L_0065;\n\tv165 = *([v133 @ X0_v7 (Il2CppClass<EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0065;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v133, v104, v102, v100, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv179 = EasyMobile.Internal.Privacy.EditorConsentDialogUI+<>c;\n\tv172 = *([v179 @ X8_v21+B8]);\nL_0065:\n\tv158 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>, System.Boolean>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, EasyMobile.Internal.Privacy.EditorConsentDialogToggleUI>, System.Boolean>::.ctor(v158, v171.<>9, Il2CppMethodInfo);\n\tv161.<>9__43_1 = v158;\nL_0078:\n\treturnVal1 = System.Linq.Enumerable::ToDictionary(this.createdToggles, v86, v68);\n\tgoto L_0083;\nL_0083:\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Dictionary<string, bool> GetTogglesResult()
		{
			if (createdToggles == null)
			{
				return null;
			}
			Func<KeyValuePair<string, EditorConsentDialogToggleUI>, string> keySelector = _003C_003Ec._003C_003E9__43_0;
			if (_003C_003Ec._003C_003E9__43_0 == null)
			{
				keySelector = (_003C_003Ec._003C_003E9__43_0 = (KeyValuePair<string, EditorConsentDialogToggleUI> toggle) => (string)toggle);
			}
			Func<KeyValuePair<string, EditorConsentDialogToggleUI>, bool> elementSelector = _003C_003Ec._003C_003E9__43_1;
			if (_003C_003Ec._003C_003E9__43_1 == null)
			{
				elementSelector = (_003C_003Ec._003C_003E9__43_1 = delegate
				{
					//IL_000e: Expected O, but got I
					IntPtr intPtr = default(IntPtr);
					return ((EditorConsentDialogToggleUI)(long)intPtr).IsOn;
				});
			}
			return createdToggles.ToDictionary(keySelector, elementSelector);
		}

		[Token(Token = "0x600081B")]
		[Address(RVA = "0xB4FA74", Offset = "0xB4FA74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorConsentDialogUI()
		{
		}
	}
}
