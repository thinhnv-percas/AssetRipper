using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal.Notifications.Android;
using UnityEngine;

namespace EasyMobile.Internal.Notifications
{
	[Token(Token = "0x20000E4")]
	internal class AndroidNotificationListener : MonoBehaviour, INotificationListener
	{
		[Token(Token = "0x4000421")]
		private const string ANDROID_NOTIFICATION_LISTENER_GAMEOBJECT = "EM_AndroidNotificationListener";

		[Token(Token = "0x4000422")]
		private static AndroidNotificationListener sInstance;

		[CompilerGenerated]
		[Token(Token = "0x4000423")]
		[FieldOffset(Offset = "0x18")]
		private Action<LocalNotification> m_LocalNotificationOpened;

		[CompilerGenerated]
		[Token(Token = "0x4000424")]
		[FieldOffset(Offset = "0x20")]
		private Action<RemoteNotification> m_RemoteNotificationOpened;

		[Token(Token = "0x17000240")]
		public string Name
		{
			[Token(Token = "0x6000865")]
			[Address(RVA = "0xC04EB8", Offset = "0xC04EB8", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_gameObject(this);\n\treturnVal1 = UnityEngine.Object::get_name(v7);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GameObject gameObject = base.gameObject;
				return gameObject.name;
			}
		}

		[Token(Token = "0x17000241")]
		public unsafe NativeNotificationHandler NativeNotificationFromForegroundHandler
		{
			[Token(Token = "0x6000866")]
			[Address(RVA = "0xC04EDC", Offset = "0xC04EDC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAF818]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FD5]) = v38;\nL_0016:\n\treturnVal1 = new EasyMobile.Internal.Notifications.NativeNotificationHandler();\n\tv45 = Il2CppMethodInfo;\n\treturnVal1.m_target = this;\n\treturnVal1.method = Il2CppMethodInfo;\n\treturnVal1.method_ptr = *([v45 @ X8_v7 (Il2CppMethodInfo)]);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NativeNotificationHandler nativeNotificationHandler = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)nativeNotificationHandler).m_target = this;
				((Delegate)nativeNotificationHandler).method = (IntPtr)__ldftn(AndroidNotificationListener._OnLocalNotificationFromForeground);
				((Delegate)nativeNotificationHandler).method_ptr = method_ptr;
				return nativeNotificationHandler;
			}
		}

		[Token(Token = "0x17000242")]
		public unsafe NativeNotificationHandler NativeNotificationFromBackgroundHandler
		{
			[Token(Token = "0x6000867")]
			[Address(RVA = "0xC04F54", Offset = "0xC04F54", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA6DD0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FD6]) = v38;\nL_0016:\n\treturnVal1 = new EasyMobile.Internal.Notifications.NativeNotificationHandler();\n\tv45 = Il2CppMethodInfo;\n\treturnVal1.m_target = this;\n\treturnVal1.method = Il2CppMethodInfo;\n\treturnVal1.method_ptr = *([v45 @ X8_v7 (Il2CppMethodInfo)]);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NativeNotificationHandler nativeNotificationHandler = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)nativeNotificationHandler).m_target = this;
				((Delegate)nativeNotificationHandler).method = (IntPtr)__ldftn(AndroidNotificationListener._OnLocalNotificationFromBackground);
				((Delegate)nativeNotificationHandler).method_ptr = method_ptr;
				return nativeNotificationHandler;
			}
		}

		[Token(Token = "0x14000047")]
		public event Action<LocalNotification> LocalNotificationOpened
		{
			[CompilerGenerated]
			[Token(Token = "0x6000861")]
			[Address(RVA = "0xC04C28", Offset = "0xC04C28", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC84F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FD1]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.LocalNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_LocalNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<LocalNotification>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
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
			[Token(Token = "0x6000862")]
			[Address(RVA = "0xC04CCC", Offset = "0xC04CCC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFE8B8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FD2]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.LocalNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_LocalNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<LocalNotification>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
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

		[Token(Token = "0x14000048")]
		public event Action<RemoteNotification> RemoteNotificationOpened
		{
			[CompilerGenerated]
			[Token(Token = "0x6000863")]
			[Address(RVA = "0xC04D70", Offset = "0xC04D70", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB7CF8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FD3]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.RemoteNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_RemoteNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<RemoteNotification>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
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
			[Token(Token = "0x6000864")]
			[Address(RVA = "0xC04E14", Offset = "0xC04E14", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE70E0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022FD4]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.RemoteNotification>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_RemoteNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<RemoteNotification>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
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

		[Token(Token = "0x600085E")]
		[Address(RVA = "0xC049F0", Offset = "0xC049F0", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EE4450]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2022FCE]) = v39;\nL_001E:\n\tgoto L_0027;\n\tv51 = *([v46 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v46, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv61 = UnityEngine.Object::op_Equality(v45.sInstance, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_0059;\n\tv67 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v67, \"EM_AndroidNotificationListener\");\n\tUnityEngine.Object::set_hideFlags(v67, 0x3D);\n\tv111 = UnityEngine.GameObject::AddComponent(v67);\n\tv113.sInstance = v111;\n\tgoto L_004F;\n\tv118 = *([v114 @ X0_v15+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_004F;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v114, v110, v69, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004F:\n\tUnityEngine.Object::DontDestroyOnLoad(v67);\nL_0059:\n\treturn v85.sInstance;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidNotificationListener GetListener()
		{
			if (sInstance == null)
			{
				GameObject gameObject = new GameObject("EM_AndroidNotificationListener");
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				AndroidNotificationListener androidNotificationListener = gameObject.AddComponent<AndroidNotificationListener>();
				sInstance = androidNotificationListener;
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
			return sInstance;
		}

		[Token(Token = "0x600085F")]
		[Address(RVA = "0xC04B10", Offset = "0xC04B10", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBFFB0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FCF]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv62 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v62, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Object::DontDestroyOnLoad(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x6000860")]
		[Address(RVA = "0xC04B8C", Offset = "0xC04B8C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EC1058]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022FD0]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v47 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Equality(v46.sInstance, this);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0035;\n\tv66.sInstance = 0;\nL_0035:\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (sInstance == this)
			{
				sInstance = null;
			}
		}

		[Token(Token = "0x6000868")]
		[Address(RVA = "0xC04FBC", Offset = "0xC04FBC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Notifications.AndroidNotificationListener::InternalOnLocalNotificationHandler(this, 1, jsonResponse);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _OnLocalNotificationFromForeground(string jsonResponse)
		{
			InternalOnLocalNotificationHandler(isForeground: true, jsonResponse);
		}

		[Token(Token = "0x6000869")]
		[Address(RVA = "0xC05090", Offset = "0xC05090", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Notifications.AndroidNotificationListener::InternalOnLocalNotificationHandler(this, 0, jsonResponse);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _OnLocalNotificationFromBackground(string jsonResponse)
		{
			InternalOnLocalNotificationHandler(isForeground: false, jsonResponse);
		}

		[Token(Token = "0x600086A")]
		[Address(RVA = "0xC04FCC", Offset = "0xC04FCC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EF9610]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, isForeground, jsonResponse, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022FD7]) = v44;\nL_0018:\n\tv46 = EasyMobile.Internal.Notifications.Android.AndroidNotificationResponse::FromJson(jsonResponse);\n\tv48 = v46 == 0;\n\tif (v48) goto L_0035;\n\tv50 = v46.request == 0;\n\tif (v50) goto L_0035;\n\tv63 = EasyMobile.Internal.Notifications.AndroidNotificationListener::CRRaiseLocalNotificationEvent(this, v46, isForeground);\n\tv90 = UnityEngine.MonoBehaviour::StartCoroutine(this, v63);\n\treturn;\nL_0035:\n\tgoto L_0046;\n\tv64 = *([v56 @ X0_v4+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0046;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v56, isForeground, jsonResponse, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0046:\n\tUnityEngine.Debug::Log(\"Ignoring local Android notification due to invalid JSON response data.\");\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InternalOnLocalNotificationHandler(bool isForeground, string jsonResponse)
		{
			AndroidNotificationResponse androidNotificationResponse = AndroidNotificationResponse.FromJson(jsonResponse);
			if (androidNotificationResponse != null && androidNotificationResponse.request != null)
			{
				IEnumerator routine = CRRaiseLocalNotificationEvent(androidNotificationResponse, isForeground);
				Coroutine coroutine = StartCoroutine(routine);
			}
			else
			{
				Debug.Log("Ignoring local Android notification due to invalid JSON response data.");
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7386F0", Offset = "0x7386F0")]
		[Token(Token = "0x600086B")]
		[Address(RVA = "0xC050A0", Offset = "0xC050A0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC7BB0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, response, isForeground, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022FD8]) = v44;\nL_001A:\n\tv48 = new EasyMobile.Internal.Notifications.AndroidNotificationListener+<CRRaiseLocalNotificationEvent>d__20();\n\tSystem.Object::.ctor(v48);\n\tv48.<>1__state = 0;\n\tv48.<>4__this = this;\n\tv48.response = response;\n\tv48.isForeground = isForeground;\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CRRaiseLocalNotificationEvent(AndroidNotificationResponse response, bool isForeground)
		{
			_003CCRRaiseLocalNotificationEvent_003Ed__20 _003CCRRaiseLocalNotificationEvent_003Ed__21 = null;
			_003CCRRaiseLocalNotificationEvent_003Ed__21._003C_003E1__state = 0;
			_003CCRRaiseLocalNotificationEvent_003Ed__21._003C_003E4__this = this;
			_003CCRRaiseLocalNotificationEvent_003Ed__21.response = response;
			_003CCRRaiseLocalNotificationEvent_003Ed__21.isForeground = isForeground;
			return _003CCRRaiseLocalNotificationEvent_003Ed__21;
		}

		[Token(Token = "0x600086C")]
		[Address(RVA = "0xC0515C", Offset = "0xC0515C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidNotificationListener()
		{
		}
	}
}
