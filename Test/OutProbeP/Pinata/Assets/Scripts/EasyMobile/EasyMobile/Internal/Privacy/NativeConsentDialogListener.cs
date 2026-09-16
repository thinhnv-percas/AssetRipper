using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000E0")]
	internal class NativeConsentDialogListener : MonoBehaviour
	{
		[Token(Token = "0x400040C")]
		private const string NATIVE_CONSENT_DIALOG_LISTENER_GO = "EM_NativeConsentDialogListener";

		[Token(Token = "0x400040D")]
		private static NativeConsentDialogListener sInstance;

		[CompilerGenerated]
		[Token(Token = "0x400040E")]
		[FieldOffset(Offset = "0x18")]
		private Action<string, bool> m_ToggleStateUpdated;

		[CompilerGenerated]
		[Token(Token = "0x400040F")]
		[FieldOffset(Offset = "0x20")]
		private Action<string> m_DialogCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000410")]
		[FieldOffset(Offset = "0x28")]
		private Action m_DialogDismissed;

		[Token(Token = "0x1700023A")]
		public string ListenerName
		{
			[Token(Token = "0x6000825")]
			[Address(RVA = "0xB501F8", Offset = "0xB501F8", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_gameObject(this);\n\treturnVal1 = UnityEngine.Object::get_name(v7);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GameObject gameObject = base.gameObject;
				return gameObject.name;
			}
		}

		[Token(Token = "0x1700023B")]
		public string ToggleBecameOnHandlerName
		{
			[Token(Token = "0x6000826")]
			[Address(RVA = "0xB5021C", Offset = "0xB5021C", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF92B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022770]) = v38;\nL_0016:\n\tv42 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v42, this, Il2CppMethodInfo);\n\treturnVal1 = EasyMobile.Internal.ReflectionUtil::GetMethodName(v42);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Action<string> method = _OnNativeToggleBecameOn;
				return ReflectionUtil.GetMethodName(method);
			}
		}

		[Token(Token = "0x1700023C")]
		public string ToggleBecameOffHandlerName
		{
			[Token(Token = "0x6000827")]
			[Address(RVA = "0xB502C0", Offset = "0xB502C0", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE7DA8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022771]) = v38;\nL_0016:\n\tv42 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v42, this, Il2CppMethodInfo);\n\treturnVal1 = EasyMobile.Internal.ReflectionUtil::GetMethodName(v42);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Action<string> method = _OnNativeToggleBecameOff;
				return ReflectionUtil.GetMethodName(method);
			}
		}

		[Token(Token = "0x1700023D")]
		public string DialogCompletedHandlerName
		{
			[Token(Token = "0x6000828")]
			[Address(RVA = "0xB50338", Offset = "0xB50338", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB6D08]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022772]) = v38;\nL_0016:\n\tv42 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v42, this, Il2CppMethodInfo);\n\treturnVal1 = EasyMobile.Internal.ReflectionUtil::GetMethodName(v42);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Action<string> method = _OnNativeDialogCompleted;
				return ReflectionUtil.GetMethodName(method);
			}
		}

		[Token(Token = "0x1700023E")]
		public string DialogDismissedHandlerName
		{
			[Token(Token = "0x6000829")]
			[Address(RVA = "0xB503B0", Offset = "0xB503B0", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC4120]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022773]) = v38;\nL_0016:\n\tv42 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v42, this, Il2CppMethodInfo);\n\treturnVal1 = EasyMobile.Internal.ReflectionUtil::GetMethodName(v42);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Action<string> method = _OnNativeDialogDismissed;
				return ReflectionUtil.GetMethodName(method);
			}
		}

		[Token(Token = "0x14000039")]
		public event Action<string, bool> ToggleStateUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x600081F")]
			[Address(RVA = "0xB4FE20", Offset = "0xB4FE20", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF8D68]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202276A]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_ToggleStateUpdated;
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
			[Token(Token = "0x6000820")]
			[Address(RVA = "0xB4FEC4", Offset = "0xB4FEC4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB7E70]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202276B]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, System.Boolean>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_ToggleStateUpdated;
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

		[Token(Token = "0x1400003A")]
		public event Action<string> DialogCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x6000821")]
			[Address(RVA = "0xB4FF68", Offset = "0xB4FF68", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F04330]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202276C]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_DialogCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string>))
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
			[Token(Token = "0x6000822")]
			[Address(RVA = "0xB5000C", Offset = "0xB5000C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF3318]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202276D]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_DialogCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<string>))
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

		[Token(Token = "0x1400003B")]
		public event Action DialogDismissed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000823")]
			[Address(RVA = "0xB500B0", Offset = "0xB500B0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDEE88]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202276E]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_DialogDismissed;
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
			[Token(Token = "0x6000824")]
			[Address(RVA = "0xB50154", Offset = "0xB50154", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF33E0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202276F]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_DialogDismissed;
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

		[Token(Token = "0x600081D")]
		[Address(RVA = "0xB4FD08", Offset = "0xB4FD08", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EECF40]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022768]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv62 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v62, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Object::DontDestroyOnLoad(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x600081E")]
		[Address(RVA = "0xB4FD84", Offset = "0xB4FD84", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EC0EB8]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022769]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v47 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Equality(v46.sInstance, this);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0035;\n\tv66.sInstance = 0;\nL_0035:\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (sInstance == this)
			{
				sInstance = null;
			}
		}

		[Token(Token = "0x600082A")]
		[Address(RVA = "0xB50428", Offset = "0xB50428", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EC8B60]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2022774]) = v39;\nL_001E:\n\tgoto L_0027;\n\tv51 = *([v46 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v46, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv61 = UnityEngine.Object::op_Equality(v45.sInstance, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_0059;\n\tv67 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v67, \"EM_NativeConsentDialogListener\");\n\tUnityEngine.Object::set_hideFlags(v67, 0x3D);\n\tv111 = UnityEngine.GameObject::AddComponent(v67);\n\tv113.sInstance = v111;\n\tgoto L_004F;\n\tv118 = *([v114 @ X0_v15+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_004F;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v114, v110, v69, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004F:\n\tUnityEngine.Object::DontDestroyOnLoad(v67);\nL_0059:\n\treturn v85.sInstance;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static NativeConsentDialogListener GetListener()
		{
			if (sInstance == null)
			{
				GameObject gameObject = new GameObject("EM_NativeConsentDialogListener");
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				NativeConsentDialogListener nativeConsentDialogListener = gameObject.AddComponent<NativeConsentDialogListener>();
				sInstance = nativeConsentDialogListener;
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
			return sInstance;
		}

		[Token(Token = "0x600082B")]
		[Address(RVA = "0xB50548", Offset = "0xB50548", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EFF950]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, toggleId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022775]) = v41;\nL_0016:\n\tv43 = this.ToggleStateUpdated == 0;\n\tif (v43) goto L_002B;\n\tSystem.Action`2<System.String, System.Boolean>::Invoke(this.ToggleStateUpdated, toggleId, 1);\n\treturn;\nL_002B:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _OnNativeToggleBecameOn(string toggleId)
		{
			if (this.ToggleStateUpdated != null)
			{
				this.ToggleStateUpdated(toggleId, arg2: true);
			}
		}

		[Token(Token = "0x600082C")]
		[Address(RVA = "0xB505C0", Offset = "0xB505C0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ECE800]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, toggleId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022776]) = v41;\nL_0016:\n\tv43 = this.ToggleStateUpdated == 0;\n\tif (v43) goto L_002B;\n\tSystem.Action`2<System.String, System.Boolean>::Invoke(this.ToggleStateUpdated, toggleId, 0);\n\treturn;\nL_002B:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _OnNativeToggleBecameOff(string toggleId)
		{
			if (this.ToggleStateUpdated != null)
			{
				this.ToggleStateUpdated(toggleId, arg2: false);
			}
		}

		[Token(Token = "0x600082D")]
		[Address(RVA = "0xB50638", Offset = "0xB50638", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED4928]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonResults, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022777]) = v41;\nL_0016:\n\tv43 = this.DialogCompleted == 0;\n\tif (v43) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(this.DialogCompleted, jsonResults);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _OnNativeDialogCompleted(string jsonResults)
		{
			if (this.DialogCompleted != null)
			{
				this.DialogCompleted(jsonResults);
			}
		}

		[Token(Token = "0x600082E")]
		[Address(RVA = "0xB506AC", Offset = "0xB506AC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.DialogDismissed == 0;\n\tif (v2) goto L_0006;\n\tSystem.Action::Invoke(this.DialogDismissed);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _OnNativeDialogDismissed(string s)
		{
			if (this.DialogDismissed != null)
			{
				this.DialogDismissed();
			}
		}

		[Token(Token = "0x600082F")]
		[Address(RVA = "0xB506C0", Offset = "0xB506C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NativeConsentDialogListener()
		{
		}
	}
}
