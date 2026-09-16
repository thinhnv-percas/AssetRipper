using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePluginInternal;
using UnityEngine;

namespace LunarConsolePlugin
{
	[Token(Token = "0x2000015")]
	public sealed class LunarConsole : MonoBehaviour
	{
		[Token(Token = "0x200002F")]
		private interface IPlatform : ICRegistryDelegate
		{
			[Token(Token = "0x600016D")]
			void Update();

			[Token(Token = "0x600016E")]
			void OnLogMessageReceived(string message, string stackTrace, LogType type);

			[Token(Token = "0x600016F")]
			bool ShowConsole();

			[Token(Token = "0x6000170")]
			bool HideConsole();

			[Token(Token = "0x6000171")]
			void ClearConsole();

			[Token(Token = "0x6000172")]
			void Destroy();
		}

		[Token(Token = "0x2000030")]
		private class PlatformAndroid : IPlatform, ICRegistryDelegate
		{
			[Token(Token = "0x4000086")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			private readonly int m_mainThreadId;

			[Token(Token = "0x4000087")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private readonly jvalue[] m_args0;

			[Token(Token = "0x4000088")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private readonly jvalue[] m_args1;

			[Token(Token = "0x4000089")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private readonly jvalue[] m_args2;

			[Token(Token = "0x400008A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private readonly jvalue[] m_args3;

			[Token(Token = "0x400008B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			private readonly jvalue[] m_args9;

			[Token(Token = "0x400008C")]
			private static readonly string kPluginClassName = "spacemadness.com.lunarconsole.console.NativeBridge";

			[Token(Token = "0x400008D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private readonly AndroidJavaClass m_pluginClass;

			[Token(Token = "0x400008E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			private readonly IntPtr m_pluginClassRaw;

			[Token(Token = "0x400008F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			private readonly IntPtr m_methodLogMessage;

			[Token(Token = "0x4000090")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private readonly IntPtr m_methodShowConsole;

			[Token(Token = "0x4000091")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			private readonly IntPtr m_methodHideConsole;

			[Token(Token = "0x4000092")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
			private readonly IntPtr m_methodClearConsole;

			[Token(Token = "0x4000093")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			private readonly IntPtr m_methodRegisterAction;

			[Token(Token = "0x4000094")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
			private readonly IntPtr m_methodUnregisterAction;

			[Token(Token = "0x4000095")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
			private readonly IntPtr m_methodRegisterVariable;

			[Token(Token = "0x4000096")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
			private readonly IntPtr m_methodUpdateVariable;

			[Token(Token = "0x4000097")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x90")]
			private readonly IntPtr m_methodDestroy;

			[Token(Token = "0x4000098")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x98")]
			private readonly Queue<LogMessageEntry> m_messageQueue;

			[Token(Token = "0x6000173")]
			[Address(RVA = "0x13D7A74", Offset = "0x13D7A74", Length = "0x42C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv38 = *([1EEAFE8]);\n\tv39 = *([v38 @ X8_v45]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, targetName, methodName, version, settings, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2028A94]) = v54;\nL_0021:\n\t// 33 NewArr v59 @ X0_v3 (UnityEngine.jvalue[]), typeof(UnityEngine.jvalue[]), 0\n\tthis.m_args0 = v59;\n\t// 37 NewArr v62 @ X0_v5 (UnityEngine.jvalue[]), typeof(UnityEngine.jvalue[]), 1\n\tthis.m_args1 = v62;\n\t// 41 NewArr v65 @ X0_v7 (UnityEngine.jvalue[]), typeof(UnityEngine.jvalue[]), 2\n\tthis.m_args2 = v65;\n\t// 45 NewArr v68 @ X0_v9 (UnityEngine.jvalue[]), typeof(UnityEngine.jvalue[]), 3\n\tthis.m_args3 = v68;\n\t// 49 NewArr v71 @ X0_v11 (UnityEngine.jvalue[]), typeof(UnityEngine.jvalue[]), 9\n\tthis.m_args9 = v71;\n\tSystem.Object::.ctor(this);\n\tv76 = UnityEngine.JsonUtility::ToJson(settings);\n\tv79 = System.Threading.Thread::get_CurrentThread();\n\tv82 = System.Threading.Thread::get_ManagedThreadId(v79);\n\tthis.m_mainThreadId = v82;\n\tgoto L_0053;\n\tv138 = *([v134 @ X0_v20 (Il2CppClass<LunarConsolePlugin.LunarConsole+PlatformAndroid>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0053;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v134, v81, methodName, version, settings, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv142 = LunarConsolePlugin.LunarConsole+PlatformAndroid;\nL_0053:\n\tv150 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v150, v146.kPluginClassName);\n\tthis.m_pluginClass = v150;\n\tv212 = UnityEngine.AndroidJavaObject::GetRawClass(v150);\n\tthis.m_pluginClassRaw = v212;\n\tv244 = UnityEngine.AndroidJNIHelper::GetMethodID(v212, \"init\", \"(Ljava.lang.String;Ljava.lang.String;Ljava.lang.String;Ljava.lang.String;)V\", 1);\n\t// 108 NewArr v247 @ X0_v31 (UnityEngine.jvalue[]), typeof(UnityEngine.jvalue[]), 4\n\tv233 = UnityEngine.AndroidJNI::NewStringUTF(targetName);\n\tv250 = v247.Length == 0;\n\tif (v250) goto L_0158;\n\t*([v247 @ X0_v31 (UnityEngine.jvalue[])+20]) = v233;\n\tv253 = UnityEngine.AndroidJNI::NewStringUTF(methodName);\n\tv324 = v247.Length < 1;\n\tv294 = ~v324;\n\tv289 = v247.Length - 1;\n\tv279 = v289 == 0;\n\tv325 = ~v294;\n\tv254 = v325 | v279;\n\tif (v254) goto L_0158;\n\t*([v247 @ X0_v31 (UnityEngine.jvalue[])+28]) = v253;\n\tv310 = UnityEngine.AndroidJNI::NewStringUTF(version);\n\tv327 = v247.Length < 2;\n\tv295 = ~v327;\n\tv290 = v247.Length - 2;\n\tv280 = v290 == 0;\n\tv328 = ~v295;\n\tv255 = v328 | v280;\n\tif (v255) goto L_0158;\n\t*([v247 @ X0_v31 (UnityEngine.jvalue[])+30]) = v310;\n\tv311 = UnityEngine.AndroidJNI::NewStringUTF(v76);\n\tv330 = v247.Length < 3;\n\tv296 = ~v330;\n\tv291 = v247.Length - 3;\n\tv281 = v291 == 0;\n\tv331 = ~v296;\n\tv256 = v331 | v281;\n\tif (v256) goto L_0158;\n\t*([v247 @ X0_v31 (UnityEngine.jvalue[])+38]) = v311;\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, v244, v247);\n\tv188 = v247.Length == 0;\n\tif (v188) goto L_0158;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v247[0]);\n\tv332 = v247.Length < 1;\n\tv297 = ~v332;\n\tv292 = v247.Length - 1;\n\tv282 = v292 == 0;\n\tv333 = ~v297;\n\tv257 = v333 | v282;\n\tif (v257) goto L_0158;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v247[1]);\n\tv334 = v247.Length < 2;\n\tv298 = ~v334;\n\tv293 = v247.Length - 2;\n\tv283 = v293 == 0;\n\tv335 = ~v298;\n\tv258 = v335 | v283;\n\tif (v258) goto L_0158;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v247[2]);\n\tv336 = v247.Length < 3;\n\tv172 = ~v336;\n\tv170 = v247.Length - 3;\n\tv166 = v170 == 0;\n\tv337 = ~v172;\n\tv156 = v337 | v166;\n\tif (v156) goto L_0158;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v247[3]);\n\tv349 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"logMessage\", \"(Ljava.lang.String;Ljava.lang.String;I)V\", 1);\n\tthis.m_methodLogMessage = v349;\n\tv359 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"showConsole\", \"()V\", 1);\n\tthis.m_methodShowConsole = v359;\n\tv367 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"hideConsole\", \"()V\", 1);\n\tthis.m_methodHideConsole = v367;\n\tv375 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"clearConsole\", \"()V\", 1);\n\tthis.m_methodClearConsole = v375;\n\tv385 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"registerAction\", \"(ILjava.lang.String;)V\", 1);\n\tthis.m_methodRegisterAction = v385;\n\tv395 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"unregisterAction\", \"(I)V\", 1);\n\tthis.m_methodUnregisterAction = v395;\n\tv405 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"registerVariable\", \"(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;IZFF)V\", 1);\n\tthis.m_methodRegisterVariable = v405;\n\tv414 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"updateVariable\", \"(ILjava/lang/String;)V\", 1);\n\tthis.m_methodUpdateVariable = v414;\n\tv419 = UnityEngine.AndroidJNIHelper::GetMethodID(this.m_pluginClassRaw, \"destroy\", \"()V\", 1);\n\tthis.m_methodDestroy = v419;\n\tv186 = new System.Collections.Generic.Queue`1<LunarConsolePlugin.LunarConsole+LogMessageEntry>();\n\tSystem.Collections.Generic.Queue`1<LunarConsolePlugin.LunarConsole+LogMessageEntry>::.ctor(v186);\n\tthis.m_messageQueue = v186;\n\treturn;\nL_0158:\n\tv323 = new System.IndexOutOfRangeException();\n\tthrow v323;\n\tv124 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 232 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe PlatformAndroid(string targetName, string methodName, string version, LunarConsoleSettings settings)
			{
				//IL_013b: Expected O, but got I4
				//IL_01ae: Expected O, but got I4
				//IL_0221: Expected O, but got I4
				//IL_02cc: Expected O, but got I4
				//IL_0340: Expected O, but got I4
				//IL_03b4: Expected O, but got I4
				base._002Ector();
				jvalue[] args = new jvalue[0];
				m_args0 = args;
				jvalue[] args2 = new jvalue[1];
				m_args1 = args2;
				jvalue[] args3 = new jvalue[2];
				m_args2 = args3;
				jvalue[] args4 = new jvalue[3];
				m_args3 = args4;
				jvalue[] args5 = new jvalue[9];
				m_args9 = args5;
				string bytes = JsonUtility.ToJson(settings);
				Thread currentThread = Thread.CurrentThread;
				int managedThreadId = currentThread.ManagedThreadId;
				m_mainThreadId = managedThreadId;
				IntPtr methodID = AndroidJNIHelper.GetMethodID(m_pluginClassRaw = (m_pluginClass = new AndroidJavaClass(kPluginClassName)).GetRawClass(), "init", "(Ljava.lang.String;Ljava.lang.String;Ljava.lang.String;Ljava.lang.String;)V", isStatic: true);
				jvalue[] array = new jvalue[4];
				IntPtr intPtr = AndroidJNI.NewStringUTF(targetName);
				if (array.Length != 0)
				{
					IntPtr intPtr2 = AndroidJNI.NewStringUTF(methodName);
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj = array.Length - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						IntPtr intPtr3 = AndroidJNI.NewStringUTF(version);
						bool flag5 = array.Length < 2;
						bool flag6 = !flag5;
						object obj2 = array.Length - 2;
						bool flag7 = obj2 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							IntPtr intPtr4 = AndroidJNI.NewStringUTF(bytes);
							bool flag9 = array.Length < 3;
							bool flag10 = !flag9;
							object obj3 = array.Length - 3;
							bool flag11 = obj3 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, methodID, array);
								if (array.Length != 0)
								{
									AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[0]));
									bool flag13 = array.Length < 1;
									bool flag14 = !flag13;
									object obj4 = array.Length - 1;
									bool flag15 = obj4 == null;
									bool flag16 = !flag14;
									if (!(flag16 || flag15))
									{
										AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[1]));
										bool flag17 = array.Length < 2;
										bool flag18 = !flag17;
										object obj5 = array.Length - 2;
										bool flag19 = obj5 == null;
										bool flag20 = !flag18;
										if (!(flag20 || flag19))
										{
											AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[2]));
											bool flag21 = array.Length < 3;
											bool flag22 = !flag21;
											object obj6 = array.Length - 3;
											bool flag23 = obj6 == null;
											bool flag24 = !flag22;
											if (!(flag24 || flag23))
											{
												AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[3]));
												IntPtr methodID2 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "logMessage", "(Ljava.lang.String;Ljava.lang.String;I)V", isStatic: true);
												m_methodLogMessage = methodID2;
												IntPtr methodID3 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "showConsole", "()V", isStatic: true);
												m_methodShowConsole = methodID3;
												IntPtr methodID4 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "hideConsole", "()V", isStatic: true);
												m_methodHideConsole = methodID4;
												IntPtr methodID5 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "clearConsole", "()V", isStatic: true);
												m_methodClearConsole = methodID5;
												IntPtr methodID6 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "registerAction", "(ILjava.lang.String;)V", isStatic: true);
												m_methodRegisterAction = methodID6;
												IntPtr methodID7 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "unregisterAction", "(I)V", isStatic: true);
												m_methodUnregisterAction = methodID7;
												IntPtr methodID8 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "registerVariable", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;IZFF)V", isStatic: true);
												m_methodRegisterVariable = methodID8;
												IntPtr methodID9 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "updateVariable", "(ILjava/lang/String;)V", isStatic: true);
												m_methodUpdateVariable = methodID9;
												IntPtr methodID10 = AndroidJNIHelper.GetMethodID(m_pluginClassRaw, "destroy", "()V", isStatic: true);
												m_methodDestroy = methodID10;
												Queue<LogMessageEntry> messageQueue = new Queue<LogMessageEntry>();
												m_messageQueue = messageQueue;
												return;
											}
										}
									}
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}

			[Token(Token = "0x6000174")]
			[Address(RVA = "0x13DC3F0", Offset = "0x13DC3F0", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.m_pluginClass == 0;\n\tif (v13) goto L_0015;\n\tUnityEngine.AndroidJavaObject::Dispose(this.m_pluginClass);\n\tSystem.Object::Finalize(this);\n\treturn;\nL_0015:\n\tv15 = new System.NullReferenceException();\n\tv46 = methodInfo != 1;\n\tif (v46) goto L_0030;\n\tv47 = 0x6D2BC0(v15, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv88 = 0x6D2490(v47, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tSystem.Object::Finalize(this);\n\tv92 = *([v47 @ X0_v7]) == 0;\n\tv78 = ~v92;\n\tif (v78) goto L_0034;\n\treturn;\nL_0030:\n\tv48 = 0x6D2380(v15, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0034:\n\tthrow System.TypeLoadException;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			~PlatformAndroid()
			{
				if (m_pluginClass != null)
				{
					m_pluginClass.Dispose();
					base.Finalize();
					return;
				}
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr == (IntPtr)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					base.Finalize();
					object obj = default(object);
					if (obj == null)
					{
						return;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				}
				throw new TypeLoadException();
			}

			[Token(Token = "0x6000175")]
			[Address(RVA = "0x13DC46C", Offset = "0x13DC46C", Length = "0x114")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0015;\n\tv20 = *([1EDC230]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A95]) = v40;\nL_0015:\n\t*([v10 @ X29_v1-14]) = 0;\n\tv42 = &v11 @ stack_-10_v2 - 0x14;\n\tSystem.Threading.Monitor::Enter(this.m_messageQueue, v42);\n\tv127 = this.m_messageQueue;\nL_002A:\n\tv62 = v127._size < 1;\n\tif (v62) goto L_0042;\n\tv158 = System.Collections.Generic.Queue`1<LunarConsolePlugin.LunarConsole+LogMessageEntry>::Dequeue(v127);\n\tLunarConsolePlugin.LunarConsole+PlatformAndroid::OnLogMessageReceived(this, v158.message, v158.stackTrace, v158.type);\n\tv127 = this.m_messageQueue;\n\tv172 = this.m_messageQueue == 0;\n\tv104 = ~v172;\n\tif (v104) goto L_002A;\n\tthrow System.NullReferenceException;\nL_0042:\n\tgoto L_0056;\n\tgoto L_0046;\n\tgoto L_0046;\n\tgoto L_0046;\nL_0046:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0070;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = 0xFFFFFFFF;\nL_0056:\n\tv160 = *([v10 @ X29_v1-14]) == 0;\n\tif (v160) goto L_0061;\n\tSystem.Threading.Monitor::Exit(this.m_messageQueue);\nL_0061:\n\tgoto L_006B;\n\tgoto L_006F;\nL_006B:\n\treturn;\nL_006F:\n\tv184 = new System.TypeLoadException();\nL_0070:\n\tv190 = 0x6D2380(v184, 0, 0, v158.type, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void Update()
			{
				object obj2 = default(object);
				object obj = obj2;
				_ = 0;
				Monitor.Enter(m_messageQueue, ref *(bool*)((long)(IntPtr)obj2 - 20L));
				Queue<LogMessageEntry> messageQueue = m_messageQueue;
				while (messageQueue.Count >= 1)
				{
					LogMessageEntry logMessageEntry = messageQueue.Dequeue();
					OnLogMessageReceived(logMessageEntry.message, logMessageEntry.stackTrace, logMessageEntry.type);
					messageQueue = m_messageQueue;
					if (m_messageQueue == null)
					{
						throw new NullReferenceException();
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-14]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Monitor.Exit(m_messageQueue);
				}
			}

			[Token(Token = "0x6000176")]
			[Address(RVA = "0x13DC580", Offset = "0x13DC580", Length = "0x1E8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\tgoto L_001A;\n\tv30 = *([1ECFBC8]);\n\tv31 = *([v30 @ X8_v21]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, message, stackTrace, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028A96]) = v47;\nL_001A:\n\t*([v14 @ X29_v1-24]) = 0;\n\tv49 = System.Threading.Thread::get_CurrentThread();\n\tv52 = System.Threading.Thread::get_ManagedThreadId(v49);\n\tv124 = v52 != this.m_mainThreadId;\n\tif (v124) goto L_007F;\n\tv170 = this.m_args3;\n\tv173 = UnityEngine.AndroidJNI::NewStringUTF(message);\n\t*([v170 @ X21_v8 (UnityEngine.jvalue[])+20]) = v173;\n\tv254 = this.m_args3;\n\tv241 = UnityEngine.AndroidJNI::NewStringUTF(stackTrace);\n\t*([v254 @ X21_v11 (UnityEngine.jvalue[])+28]) = v241;\n\tv250 = this.m_args3;\n\t*([v250 @ X8_v16 (UnityEngine.jvalue[])+30]) = type;\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodLogMessage, this.m_args3);\n\tv251 = this.m_args3;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v251[0]);\n\tv252 = this.m_args3;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v252[1]);\n\tgoto L_00AA;\nL_007F:\n\t*([v14 @ X29_v1-24]) = 0;\n\tv174 = &v15 @ stack_-10_v2 - 0x24;\n\tSystem.Threading.Monitor::Enter(this.m_messageQueue, v174);\n\tv199 = this.m_messageQueue == 0;\n\tif (v199) goto L_00B4;\n\tSystem.Collections.Generic.Queue`1<LunarConsolePlugin.LunarConsole+LogMessageEntry>::Enqueue(this.m_messageQueue, &message @ X1 (System.String));\nL_0093:\n\tv303 = *([v14 @ X29_v1-24]) == 0;\n\tif (v303) goto L_0098;\n\tSystem.Threading.Monitor::Exit(this.m_messageQueue);\nL_0098:\n\tv309 = v164 + 1;\n\tv148 = v309 == 0;\n\tv138 = ~v148;\n\tif (v138) goto L_00AA;\n\tv312 = v162 == 0;\n\tv160 = ~v312;\n\tif (v160) goto L_00B3;\nL_00AA:\n\treturn;\n\tv256 = new System.NullReferenceException();\n\tv193 = new System.IndexOutOfRangeException();\nL_00B0:\n\tv102 = new System.TypeLoadException();\n\tthrow System.NullReferenceException;\nL_00B3:\n\tgoto L_00B0;\nL_00B4:\n\tv265 = new System.NullReferenceException();\n\tgoto L_00BF;\nL_00BF:\n\tv284 = v174 != 1;\n\tif (v284) goto L_00C6;\n\tv310 = 0x6D2BC0(v265, v174, 0, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv162 = *([v310 @ X0_v19]);\n\tv299 = 0x6D2490(v310, v174, 0, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0093;\nL_00C6:\n\tv311 = 0x6D2380(v265, v174, 0, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void OnLogMessageReceived(string message, string stackTrace, LogType type)
			{
				//IL_0143: Expected O, but got Ref
				//IL_0222: Expected I4, but got O
				object obj2 = default(object);
				object obj = obj2;
				_ = 0;
				Thread currentThread = Thread.CurrentThread;
				int managedThreadId = currentThread.ManagedThreadId;
				if (managedThreadId == m_mainThreadId)
				{
					jvalue[] args = m_args3;
					IntPtr intPtr = AndroidJNI.NewStringUTF(message);
					jvalue[] args2 = m_args3;
					IntPtr intPtr2 = AndroidJNI.NewStringUTF(stackTrace);
					jvalue[] args3 = m_args3;
					AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodLogMessage, m_args3);
					jvalue[] args4 = m_args3;
					AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args4[0]));
					jvalue[] args5 = m_args3;
					AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args5[1]));
					return;
				}
				_ = 0;
				ref bool reference = ref *(bool*)((long)(IntPtr)obj2 - 36L);
				Monitor.Enter(m_messageQueue, ref reference);
				int num;
				int num2;
				if (m_messageQueue != null)
				{
					string text = default(string);
					m_messageQueue.Enqueue((LogMessageEntry)(&text));
					num = 0;
					num2 = 0;
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
					if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) != (void*)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj3 = default(object);
					num = (int)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					num2 = -1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-24]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Monitor.Exit(m_messageQueue);
				}
				if (num2 + 1 != 0 || num == 0)
				{
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
				throw new NullReferenceException();
			}

			[Token(Token = "0x6000177")]
			[Address(RVA = "0x13DC770", Offset = "0x13DC770", Length = "0x138")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECBE10]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A97]) = v38;\nL_0017:\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodShowConsole, this.m_args0);\nL_001E:\n\treturn 1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0065;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0059;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0061;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDE360]);\n\tX1 = X0;\n\tX2 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0054;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0054;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0054:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\n\tX0 = 0;\n\tgoto L_001E;\nL_0059:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0061:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0065:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool ShowConsole()
			{
				AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodShowConsole, m_args0);
				return true;
			}

			[Token(Token = "0x6000178")]
			[Address(RVA = "0x13DC8A8", Offset = "0x13DC8A8", Length = "0x138")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE90D0]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A98]) = v38;\nL_0017:\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodHideConsole, this.m_args0);\nL_001E:\n\treturn 1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0065;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0059;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0061;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB31A8]);\n\tX1 = X0;\n\tX2 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0054;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0054;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0054:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\n\tX0 = 0;\n\tgoto L_001E;\nL_0059:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0061:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0065:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool HideConsole()
			{
				AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodHideConsole, m_args0);
				return true;
			}

			[Token(Token = "0x6000179")]
			[Address(RVA = "0x13DC9E0", Offset = "0x13DC9E0", Length = "0x134")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDFAC8]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A99]) = v38;\nL_0017:\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodClearConsole, this.m_args0);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0068;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_005C;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0064;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ECC988]);\n\tX1 = X0;\n\tX2 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0053;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0053;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0053:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX1 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 89 ShiftStack 32\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_005C:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0064:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0068:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void ClearConsole()
			{
				AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodClearConsole, m_args0);
			}

			[Token(Token = "0x600017A")]
			[Address(RVA = "0x13DCB14", Offset = "0x13DCB14", Length = "0x134")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC68B8]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A9A]) = v38;\nL_0017:\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodDestroy, this.m_args0);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0068;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_005C;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0064;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDB508]);\n\tX1 = X0;\n\tX2 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0053;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0053;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0053:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX1 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 89 ShiftStack 32\n\tUnityEngine.Debug::LogError(X0, X1);\n\treturn;\nL_005C:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0064:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0068:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Destroy()
			{
				AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodDestroy, m_args0);
			}

			[Token(Token = "0x600017B")]
			[Address(RVA = "0x13DCC48", Offset = "0x13DCC48", Length = "0x20C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED75F0]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, registry, action, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A9B]) = v41;\nL_0017:\n\tv43 = this.m_args2;\n\tv48 = v43.Length == 0;\n\tif (v48) goto L_0056;\n\t*([v43 @ X8_v21 (UnityEngine.jvalue[])+20]) = action.m_id;\n\tv55 = this.m_args2;\n\tv58 = UnityEngine.AndroidJNI::NewStringUTF(action.m_name);\n\tv70 = v55.Length < 1;\n\tv71 = ~v70;\n\tv72 = v55.Length - 1;\n\tv74 = v72 == 0;\n\tv79 = ~v71;\n\tv80 = v79 | v74;\n\tif (v80) goto L_005C;\n\t*([v55 @ X21_v7 (UnityEngine.jvalue[])+28]) = v58;\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodRegisterAction, this.m_args2);\n\tv120 = this.m_args2;\n\tv126 = v120.Length < 1;\n\tv127 = ~v126;\n\tv128 = v120.Length - 1;\n\tv130 = v128 == 0;\n\tv135 = ~v127;\n\tv136 = v135 | v130;\n\tif (v136) goto L_0062;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v120[1]);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv53 = new System.NullReferenceException();\nL_0056:\n\tv64 = new System.IndexOutOfRangeException();\n\tthrow v64;\n\tv89 = new System.NullReferenceException();\nL_005C:\n\tv119 = new System.IndexOutOfRangeException();\n\tthrow v119;\n\tv155 = new System.NullReferenceException();\nL_0062:\n\tv175 = new System.IndexOutOfRangeException();\n\tthrow v175;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_00B8;\n\tv235 = 0x6D2BC0(v183, 0, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v235 @ X0_v10]);\n\tv249 = *([v247 @ X19_v4]);\n\tv251 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v249, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv252 = v251 & 1;\n\tv253 = v252 == 0;\n\tif (v253) goto L_00AC;\n\tv254 = 0x6D2490(v251, v249, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv257 = v247 == 0;\n\tif (v257) goto L_00B4;\n\tv263 = *([v247 @ X19_v4]);\n\tv265 = *([v263 @ X8_v9+180]);\n\tv266 = *([v263 @ X8_v9+188]);\n\tv265(v267, v247, v266, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv273 = System.String::Concat(\"Exception while calling 'LunarConsole.OnActionRegistered': \", v267, 0);\n\tgoto L_00A9;\n\tv283 = *([v226 @ X8_v15+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_00A9;\n\tv288 = v226;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v288, v270, v188, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00A9:\n\tUnityEngine.Debug::LogError(v273, 0);\n\treturn;\nL_00AC:\n\tv256 = 0x6D1E60(8, v249, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv258 = *([v235 @ X0_v10]);\n\t*([v256 @ X0_v18]) = v258;\n\tv260 = 0x1E8A000 + 0x870;\n\tv262 = 0x6D2A00(v256, v260, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00B4:\n\tv276 = new System.NullReferenceException();\n\tv239 = 0x6D2490(v276, v237, v236, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00B8:\n\tv245 = 0x6D2380(v221, v210, v189, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv215 = 0x846AA4(v245, v210, v189, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void OnActionRegistered(CRegistry registry, CAction action)
			{
				//IL_008a: Expected O, but got I4
				//IL_0116: Expected O, but got I4
				jvalue[] args = m_args2;
				if (args.Length != 0)
				{
					_ = action.Id;
					jvalue[] args2 = m_args2;
					IntPtr intPtr = AndroidJNI.NewStringUTF(action.Name);
					bool flag = args2.Length < 1;
					bool flag2 = !flag;
					object obj = args2.Length - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodRegisterAction, m_args2);
						jvalue[] args3 = m_args2;
						bool flag5 = args3.Length < 1;
						bool flag6 = !flag5;
						object obj2 = args3.Length - 1;
						bool flag7 = obj2 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args3[1]));
							return;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}

			[Token(Token = "0x600017C")]
			[Address(RVA = "0x13DCE54", Offset = "0x13DCE54", Length = "0x188")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F0FEE0]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, registry, action, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A9C]) = v41;\nL_0017:\n\tv43 = this.m_args1;\n\tv48 = v43.Length == 0;\n\tif (v48) goto L_002F;\n\t*([v43 @ X8_v17 (UnityEngine.jvalue[])+20]) = action.m_id;\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodUnregisterAction, this.m_args1);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv53 = new System.NullReferenceException();\nL_002F:\n\tv64 = new System.IndexOutOfRangeException();\n\tthrow v64;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_0081;\n\tv133 = 0x6D2BC0(v72, 0, 0, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv145 = *([v133 @ X0_v10]);\n\tv147 = *([v145 @ X19_v4]);\n\tv149 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v147, 0, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv150 = v149 & 1;\n\tv151 = v150 == 0;\n\tif (v151) goto L_0075;\n\tv152 = 0x6D2490(v149, v147, 0, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv155 = v145 == 0;\n\tif (v155) goto L_007D;\n\tv161 = *([v145 @ X19_v4]);\n\tv163 = *([v161 @ X8_v9+180]);\n\tv164 = *([v161 @ X8_v9+188]);\n\tv163(v165, v145, v164, 0, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv171 = System.String::Concat(\"Exception while calling 'LunarConsole.OnActionUnregistered': \", v165, 0);\n\tgoto L_0072;\n\tv181 = *([v124 @ X8_v15+E0]);\n\tv182 = v181 == 0;\n\tv183 = ~v182;\n\tif (v183) goto L_0072;\n\tv186 = v124;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v186, v168, v104, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0072:\n\tUnityEngine.Debug::LogError(v171, 0);\n\treturn;\nL_0075:\n\tv154 = 0x6D1E60(8, v147, 0, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = *([v133 @ X0_v10]);\n\t*([v154 @ X0_v18]) = v156;\n\tv158 = 0x1E8A000 + 0x870;\n\tv160 = 0x6D2A00(v154, v158, 0, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_007D:\n\tv174 = new System.NullReferenceException();\n\tv137 = 0x6D2490(v174, v135, v134, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0081:\n\tv143 = 0x6D2380(v119, v108, v105, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv113 = 0x846AA4(v143, v108, v105, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void OnActionUnregistered(CRegistry registry, CAction action)
			{
				jvalue[] args = m_args1;
				if (args.Length != 0)
				{
					_ = action.Id;
					AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodUnregisterAction, m_args1);
					return;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}

			[Token(Token = "0x600017D")]
			[Address(RVA = "0x13DCFDC", Offset = "0x13DCFDC", Length = "0x4E0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F06360]);\n\tv27 = *([v26 @ X8_v62]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, registry, cvar, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2028A9D]) = v45;\nL_001A:\n\tv48 = this.m_args9;\n\tv53 = v48.Length == 0;\n\tif (v53) goto L_012E;\n\t*([v48 @ X8_v43 (UnityEngine.jvalue[])+20]) = cvar.m_id;\n\tv60 = this.m_args9;\n\tv63 = UnityEngine.AndroidJNI::NewStringUTF(cvar.m_name);\n\tv48 = v60.Length;\n\tv75 = v60.Length < 1;\n\tv76 = ~v75;\n\tv77 = v60.Length - 1;\n\tv79 = v77 == 0;\n\tv84 = ~v76;\n\tv85 = v84 | v79;\n\tif (v85) goto L_0134;\n\t*([v60 @ X21_v29 (UnityEngine.jvalue[])+28]) = v63;\n\tv96 = this.m_args9;\n\tv97 = cvar.m_type;\n\t// 61 Box v102 @ X0_v113, typeof(LunarConsolePlugin.CVarType), &v97 @ X8_v45 (LunarConsolePlugin.CVarType)\n\tv48 = *([v102 @ X0_v113]);\n\t*([v48 @ X8_v43 (UnityEngine.jvalue[])+160])(v138, v102, *([v48 @ X8_v43 (UnityEngine.jvalue[])+168]), cvar, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv141 = \"il2cpp_vm_object_unbox\"(v102, &v48[41], cvar, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv166 = UnityEngine.AndroidJNI::NewStringUTF(v138);\n\tv48 = v96.Length;\n\tv219 = v96.Length < 2;\n\tv210 = ~v219;\n\tv208 = v96.Length - 2;\n\tv204 = v208 == 0;\n\tv220 = ~v210;\n\tv194 = v220 | v204;\n\tif (v194) goto L_013C;\n\t*([v96 @ X23_v26 (UnityEngine.jvalue[])+30]) = v166;\n\tv224 = this.m_args9;\n\tv227 = UnityEngine.AndroidJNI::NewStringUTF(cvar.m_value);\n\tv48 = v224.Length;\n\tv280 = v224.Length < 3;\n\tv271 = ~v280;\n\tv269 = v224.Length - 3;\n\tv265 = v269 == 0;\n\tv281 = ~v271;\n\tv255 = v281 | v265;\n\tif (v255) goto L_0142;\n\t*([v224 @ X21_v31 (UnityEngine.jvalue[])+38]) = v227;\n\tv285 = this.m_args9;\n\tv288 = UnityEngine.AndroidJNI::NewStringUTF(cvar.m_defaultValue);\n\tv48 = v285.Length;\n\tv341 = v285.Length < 4;\n\tv332 = ~v341;\n\tv330 = v285.Length - 4;\n\tv326 = v330 == 0;\n\tv342 = ~v332;\n\tv316 = v342 | v326;\n\tif (v316) goto L_0148;\n\t*([v285 @ X21_v32 (UnityEngine.jvalue[])+40]) = v288;\n\tv48 = this.m_args9;\n\tv370 = v48.Length < 5;\n\tv371 = ~v370;\n\tv372 = v48.Length - 5;\n\tv374 = v372 == 0;\n\tv379 = ~v371;\n\tv380 = v379 | v374;\n\tif (v380) goto L_014E;\n\tv402 = cvar + 0x48;\n\t*([v48 @ X8_v43 (UnityEngine.jvalue[])+48]) = cvar.m_flags;\n\tv403 = this.m_args9;\n\tv404 = 0x13D4BA8(v402, 0, cvar, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv48 = v403.Length;\n\tv431 = v403.Length < 6;\n\tv432 = ~v431;\n\tv433 = v403.Length - 6;\n\tv435 = v433 == 0;\n\tv440 = ~v432;\n\tv441 = v440 | v435;\n\tif (v441) goto L_0154;\n\tv462 = v404 & 1;\n\t*([v403 @ X21_v33 (UnityEngine.jvalue[])+50]) = v462;\n\tv48 = this.m_args9;\n\tv469 = v48.Length < 7;\n\tv470 = ~v469;\n\tv471 = v48.Length - 7;\n\tv473 = v471 == 0;\n\tv478 = ~v470;\n\tv479 = v478 | v473;\n\tif (v479) goto L_015A;\n\t*([v48 @ X8_v43 (UnityEngine.jvalue[])+58]) = cvar.m_range;\n\tv48 = this.m_args9;\n\tv525 = v48.Length < 8;\n\tv526 = ~v525;\n\tv527 = v48.Length - 8;\n\tv529 = v527 == 0;\n\tv534 = ~v526;\n\tv535 = v534 | v529;\n\tif (v535) goto L_0160;\n\t*([v48 @ X8_v43 (UnityEngine.jvalue[])+60]) = cvar.m_range.max;\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodRegisterVariable, this.m_args9);\n\tv48 = this.m_args9;\n\tv591 = v48.Length < 1;\n\tv592 = ~v591;\n\tv593 = v48.Length - 1;\n\tv595 = v593 == 0;\n\tv600 = ~v592;\n\tv601 = v600 | v595;\n\tif (v601) goto L_0166;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v48[1]);\n\tv48 = this.m_args9;\n\tv653 = v48.Length < 2;\n\tv654 = ~v653;\n\tv655 = v48.Length - 2;\n\tv657 = v655 == 0;\n\tv662 = ~v654;\n\tv663 = v662 | v657;\n\tif (v663) goto L_016C;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v48[2]);\n\tv48 = this.m_args9;\n\tv715 = v48.Length < 3;\n\tv716 = ~v715;\n\tv717 = v48.Length - 3;\n\tv719 = v717 == 0;\n\tv724 = ~v716;\n\tv725 = v724 | v719;\n\tif (v725) goto L_0172;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v48[3]);\n\tv48 = this.m_args9;\n\tv777 = v48.Length < 4;\n\tv778 = ~v777;\n\tv779 = v48.Length - 4;\n\tv781 = v779 == 0;\n\tv786 = ~v778;\n\tv787 = v786 | v781;\n\tif (v787) goto L_0178;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v48[4]);\nL_0129:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv58 = new System.NullReferenceException();\nL_012E:\n\tv69 = new System.IndexOutOfRangeException();\n\tthrow v69;\n\tv94 = new System.NullReferenceException();\nL_0134:\n\tv128 = new System.IndexOutOfRangeException();\n\tthrow v128;\n\tthrow System.NullReferenceException;\n\tv188 = new System.NullReferenceException();\nL_013C:\n\tv218 = new System.IndexOutOfRangeException();\n\tthrow v218;\n\tv249 = new System.NullReferenceException();\nL_0142:\n\tv279 = new System.IndexOutOfRangeException();\n\tthrow v279;\n\tv310 = new System.NullReferenceException();\nL_0148:\n\tv340 = new System.IndexOutOfRangeException();\n\tthrow v340;\n\tv368 = new System.NullReferenceException();\nL_014E:\n\tv400 = new System.IndexOutOfRangeException();\n\tthrow v400;\n\tv429 = new System.NullReferenceException();\nL_0154:\n\tv461 = new System.IndexOutOfRangeException();\n\tthrow v461;\n\tv500 = new System.NullReferenceException();\nL_015A:\n\tv523 = new System.IndexOutOfRangeException();\n\tthrow v523;\n\tv559 = new System.NullReferenceException();\nL_0160:\n\tv584 = new System.IndexOutOfRangeException();\n\tthrow v584;\n\tv623 = new System.NullReferenceException();\nL_0166:\n\tv646 = new System.IndexOutOfRangeException();\n\tthrow v646;\n\tv685 = new System.NullReferenceException();\nL_016C:\n\tv708 = new System.IndexOutOfRangeException();\n\tthrow v708;\n\tv747 = new System.NullReferenceException();\nL_0172:\n\tv770 = new System.IndexOutOfRangeException();\n\tthrow v770;\n\tv809 = new System.NullReferenceException();\nL_0178:\n\tv832 = new System.IndexOutOfRangeException();\n\tthrow v832;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_01DB;\n\tv916 = 0x6D2BC0(v881, 0, 0, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv927 = *([v916 @ X0_v10]);\n\tv929 = *([v927 @ X19_v4]);\n\tv931 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v929, 0, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv932 = v931 & 1;\n\tv933 = v932 == 0;\n\tif (v933) goto L_01CF;\n\tv934 = 0x6D2490(v931, v929, 0, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv937 = v927 == 0;\n\tif (v937) goto L_01D7;\n\tv943 = *([v927 @ X19_v4]);\n\tv945 = *([v943 @ X8_v9+180]);\n\tv946 = *([v943 @ X8_v9+188]);\n\tv945(v947, v927, v946, 0, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv953 = System.String::Concat(\"Exception while calling 'LunarConsole.OnVariableRegistered': \", v947, 0);\n\tgoto L_01CC;\n\tv962 = *([v870 @ X8_v15+E0]);\n\tv963 = v962 == 0;\n\tv964 = ~v963;\n\tif (v964) goto L_01CC;\n\tv967 = v870;\n\tv966 = \"il2cpp_codegen_runtime_class_init\"(v967, v950, v835, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_01CC:\n\tUnityEngine.Debug::LogError(v953, 0);\n\tgoto L_0129;\nL_01CF:\n\tv936 = 0x6D1E60(8, v929, 0, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv938 = *([v916 @ X0_v10]);\n\t*([v936 @ X0_v18]) = v938;\n\tv940 = 0x1E8A000 + 0x870;\n\tv942 = 0x6D2A00(v936, v940, 0, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_01D7:\n\tv956 = new System.NullReferenceException();\n\tv920 = 0x6D2490(v956, v918, v917, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_01DB:\n\tv925 = 0x6D2380(v906, v899, v885, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv902 = 0x846AA4(v925, v899, v885, v812, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 240 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void OnVariableRegistered(CRegistry registry, CVar cvar)
			{
				//IL_0068: Expected O, but got I4
				//IL_0094: Expected O, but got I4
				//IL_012f: Expected O, but got I4
				//IL_015b: Expected O, but got I4
				//IL_01c0: Expected O, but got I4
				//IL_01ec: Expected O, but got I4
				//IL_0251: Expected O, but got I4
				//IL_027d: Expected O, but got I4
				//IL_02f2: Expected O, but got I4
				//IL_0336: Expected O, but got I
				//IL_0363: Expected O, but got I4
				//IL_038f: Expected O, but got I4
				//IL_0413: Expected O, but got I4
				//IL_048d: Expected O, but got I4
				//IL_0523: Expected O, but got I4
				//IL_05a6: Expected O, but got I4
				//IL_0629: Expected O, but got I4
				//IL_06ac: Expected O, but got I4
				jvalue[] args = m_args9;
				if (args.Length != 0)
				{
					_ = cvar.Id;
					jvalue[] args2 = m_args9;
					IntPtr intPtr = AndroidJNI.NewStringUTF(cvar.Name);
					args = (jvalue[])args2.Length;
					bool flag = args2.Length < 1;
					bool flag2 = !flag;
					object obj = args2.Length - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						jvalue[] args3 = m_args9;
						CVarType type = cvar.Type;
						object obj2 = type;
						args = (jvalue[])obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v48 @ X8_v43 (UnityEngine.jvalue[])+160] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						string bytes = default(string);
						IntPtr intPtr2 = AndroidJNI.NewStringUTF(bytes);
						args = (jvalue[])args3.Length;
						bool flag5 = args3.Length < 2;
						bool flag6 = !flag5;
						object obj3 = args3.Length - 2;
						bool flag7 = obj3 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							jvalue[] args4 = m_args9;
							IntPtr intPtr3 = AndroidJNI.NewStringUTF((string)cvar.m_value);
							args = (jvalue[])args4.Length;
							bool flag9 = args4.Length < 3;
							bool flag10 = !flag9;
							object obj4 = args4.Length - 3;
							bool flag11 = obj4 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								jvalue[] args5 = m_args9;
								IntPtr intPtr4 = AndroidJNI.NewStringUTF((string)cvar.m_defaultValue);
								args = (jvalue[])args5.Length;
								bool flag13 = args5.Length < 4;
								bool flag14 = !flag13;
								object obj5 = args5.Length - 4;
								bool flag15 = obj5 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									args = m_args9;
									bool flag17 = args.Length < 5;
									bool flag18 = !flag17;
									object obj6 = args.Length - 5;
									bool flag19 = obj6 == null;
									bool flag20 = !flag18;
									if (!(flag20 || flag19))
									{
										object obj7 = (long)(IntPtr)cvar + 72L;
										_ = cvar.Flags;
										jvalue[] args6 = m_args9;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13D4BA8 (inside LunarConsolePlugin.CVar::get_HasRange +0x8)");
										args = (jvalue[])args6.Length;
										bool flag21 = args6.Length < 6;
										bool flag22 = !flag21;
										object obj8 = args6.Length - 6;
										bool flag23 = obj8 == null;
										bool flag24 = !flag22;
										if (!(flag24 || flag23))
										{
											object obj9 = default(object);
											int num = (int)((long)(IntPtr)obj9 & 1L);
											args = m_args9;
											bool flag25 = args.Length < 7;
											bool flag26 = !flag25;
											object obj10 = args.Length - 7;
											bool flag27 = obj10 == null;
											bool flag28 = !flag26;
											if (!(flag28 || flag27))
											{
												_ = cvar.m_range;
												args = m_args9;
												bool flag29 = args.Length < 8;
												bool flag30 = !flag29;
												object obj11 = args.Length - 8;
												bool flag31 = obj11 == null;
												bool flag32 = !flag30;
												if (!(flag32 || flag31))
												{
													_ = cvar.m_range.max;
													AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodRegisterVariable, m_args9);
													args = m_args9;
													bool flag33 = args.Length < 1;
													bool flag34 = !flag33;
													object obj12 = args.Length - 1;
													bool flag35 = obj12 == null;
													bool flag36 = !flag34;
													if (!(flag36 || flag35))
													{
														AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args[1]));
														args = m_args9;
														bool flag37 = args.Length < 2;
														bool flag38 = !flag37;
														object obj13 = args.Length - 2;
														bool flag39 = obj13 == null;
														bool flag40 = !flag38;
														if (!(flag40 || flag39))
														{
															AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args[2]));
															args = m_args9;
															bool flag41 = args.Length < 3;
															bool flag42 = !flag41;
															object obj14 = args.Length - 3;
															bool flag43 = obj14 == null;
															bool flag44 = !flag42;
															if (!(flag44 || flag43))
															{
																AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args[3]));
																args = m_args9;
																bool flag45 = args.Length < 4;
																bool flag46 = !flag45;
																object obj15 = args.Length - 4;
																bool flag47 = obj15 == null;
																bool flag48 = !flag46;
																if (!(flag48 || flag47))
																{
																	AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args[4]));
																	return;
																}
																IndexOutOfRangeException ex = new IndexOutOfRangeException();
																throw ex;
															}
															IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
															throw ex2;
														}
														IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
														throw ex3;
													}
													IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
													throw ex4;
												}
												IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
												throw ex5;
											}
											IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
											throw ex6;
										}
										IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
										throw ex7;
									}
									IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
									throw ex8;
								}
								IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
								throw ex9;
							}
							IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
							throw ex10;
						}
						IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
						throw ex11;
					}
					IndexOutOfRangeException ex12 = new IndexOutOfRangeException();
					throw ex12;
				}
				IndexOutOfRangeException ex13 = new IndexOutOfRangeException();
				throw ex13;
			}

			[Token(Token = "0x600017E")]
			[Address(RVA = "0x13DD4CC", Offset = "0x13DD4CC", Length = "0x20C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F05A90]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, registry, cvar, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A9E]) = v41;\nL_0017:\n\tv43 = this.m_args2;\n\tv48 = v43.Length == 0;\n\tif (v48) goto L_0056;\n\t*([v43 @ X8_v21 (UnityEngine.jvalue[])+20]) = cvar.m_id;\n\tv55 = this.m_args2;\n\tv58 = UnityEngine.AndroidJNI::NewStringUTF(cvar.m_value);\n\tv70 = v55.Length < 1;\n\tv71 = ~v70;\n\tv72 = v55.Length - 1;\n\tv74 = v72 == 0;\n\tv79 = ~v71;\n\tv80 = v79 | v74;\n\tif (v80) goto L_005C;\n\t*([v55 @ X21_v7 (UnityEngine.jvalue[])+28]) = v58;\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, this.m_methodUpdateVariable, this.m_args2);\n\tv120 = this.m_args2;\n\tv126 = v120.Length < 1;\n\tv127 = ~v126;\n\tv128 = v120.Length - 1;\n\tv130 = v128 == 0;\n\tv135 = ~v127;\n\tv136 = v135 | v130;\n\tif (v136) goto L_0062;\n\tUnityEngine.AndroidJNI::DeleteLocalRef(&v120[1]);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv53 = new System.NullReferenceException();\nL_0056:\n\tv64 = new System.IndexOutOfRangeException();\n\tthrow v64;\n\tv89 = new System.NullReferenceException();\nL_005C:\n\tv119 = new System.IndexOutOfRangeException();\n\tthrow v119;\n\tv155 = new System.NullReferenceException();\nL_0062:\n\tv175 = new System.IndexOutOfRangeException();\n\tthrow v175;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_00B8;\n\tv235 = 0x6D2BC0(v183, 0, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv247 = *([v235 @ X0_v10]);\n\tv249 = *([v247 @ X19_v4]);\n\tv251 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v249, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv252 = v251 & 1;\n\tv253 = v252 == 0;\n\tif (v253) goto L_00AC;\n\tv254 = 0x6D2490(v251, v249, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv257 = v247 == 0;\n\tif (v257) goto L_00B4;\n\tv263 = *([v247 @ X19_v4]);\n\tv265 = *([v263 @ X8_v9+180]);\n\tv266 = *([v263 @ X8_v9+188]);\n\tv265(v267, v247, v266, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv273 = System.String::Concat(\"Exception while calling 'LunarConsole.OnVariableUpdated': \", v267, 0);\n\tgoto L_00A9;\n\tv283 = *([v226 @ X8_v15+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_00A9;\n\tv288 = v226;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v288, v270, v188, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00A9:\n\tUnityEngine.Debug::LogError(v273, 0);\n\treturn;\nL_00AC:\n\tv256 = 0x6D1E60(8, v249, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv258 = *([v235 @ X0_v10]);\n\t*([v256 @ X0_v18]) = v258;\n\tv260 = 0x1E8A000 + 0x870;\n\tv262 = 0x6D2A00(v256, v260, 0, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00B4:\n\tv276 = new System.NullReferenceException();\n\tv239 = 0x6D2490(v276, v237, v236, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00B8:\n\tv245 = 0x6D2380(v221, v210, v189, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv215 = 0x846AA4(v245, v210, v189, v158, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void OnVariableUpdated(CRegistry registry, CVar cvar)
			{
				//IL_008a: Expected O, but got I4
				//IL_0116: Expected O, but got I4
				jvalue[] args = m_args2;
				if (args.Length != 0)
				{
					_ = cvar.Id;
					jvalue[] args2 = m_args2;
					IntPtr intPtr = AndroidJNI.NewStringUTF((string)cvar.m_value);
					bool flag = args2.Length < 1;
					bool flag2 = !flag;
					object obj = args2.Length - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, m_methodUpdateVariable, m_args2);
						jvalue[] args3 = m_args2;
						bool flag5 = args3.Length < 1;
						bool flag6 = !flag5;
						object obj2 = args3.Length - 1;
						bool flag7 = obj2 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							AndroidJNI.DeleteLocalRef((IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref args3[1]));
							return;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}

			[Token(Token = "0x600017F")]
			[Address(RVA = "0x13DC3CC", Offset = "0x13DC3CC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.AndroidJNIHelper::GetMethodID(classRaw, name, signature, 1);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static IntPtr GetStaticMethod(IntPtr classRaw, string name, string signature)
			{
				return AndroidJNIHelper.GetMethodID(classRaw, name, signature, isStatic: true);
			}

			[Token(Token = "0x6000180")]
			[Address(RVA = "0x13DC3E4", Offset = "0x13DC3E4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.AndroidJNI::CallStaticVoidMethod(this.m_pluginClassRaw, method, args);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void CallStaticVoidMethod(IntPtr method, jvalue[] args)
			{
				AndroidJNI.CallStaticVoidMethod(m_pluginClassRaw, method, args);
			}

			[Token(Token = "0x6000181")]
			[Address(RVA = "0x13DD6D8", Offset = "0x13DD6D8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.AndroidJNI::CallStaticBooleanMethod(this.m_pluginClassRaw, method, args);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool CallStaticBoolMethod(IntPtr method, jvalue[] args)
			{
				return AndroidJNI.CallStaticBooleanMethod(m_pluginClassRaw, method, args);
			}

			[Token(Token = "0x6000182")]
			[Address(RVA = "0x13DC3D8", Offset = "0x13DC3D8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.AndroidJNI::NewStringUTF(value);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private jvalue jval(string value)
			{
				//IL_000d: Expected O, but got I
				return (jvalue)(long)AndroidJNI.NewStringUTF(value);
			}

			[Token(Token = "0x6000183")]
			[Address(RVA = "0x13DD4BC", Offset = "0x13DD4BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private jvalue jval(bool value)
			{
				//IL_0005: Expected O, but got I4
				return (jvalue)value;
			}

			[Token(Token = "0x6000184")]
			[Address(RVA = "0x13DC768", Offset = "0x13DC768", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private jvalue jval(int value)
			{
				//IL_0005: Expected O, but got I4
				return (jvalue)value;
			}

			[Token(Token = "0x6000185")]
			[Address(RVA = "0x13DD4C4", Offset = "0x13DD4C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private jvalue jval(float value)
			{
				//IL_0005: Expected O, but got F4
				return (jvalue)value;
			}
		}

		[StructLayout((LayoutKind)0, Size = 24)]
		[Token(Token = "0x2000031")]
		private struct LogMessageEntry
		{
			[Token(Token = "0x4000099")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public readonly string message;

			[Token(Token = "0x400009A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public readonly string stackTrace;

			[Token(Token = "0x400009B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public readonly LogType type;

			[Token(Token = "0x6000187")]
			[Address(RVA = "0x85E264", Offset = "0x85E264", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.type = message;\n\t*([this @ X0 (LunarConsolePlugin.LunarConsole+LogMessageEntry)+18]) = stackTrace;\n\t*([this @ X0 (LunarConsolePlugin.LunarConsole+LogMessageEntry)+20]) = type;\n\treturn;\n\t// 4 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([X0+28]);\n\tX0 = X1;\n\tX20 = *([X8]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX20(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 21 ShiftStack 32\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n")]
			public LogMessageEntry(string message, string stackTrace, LogType type)
			{
				//IL_000a: Expected I4, but got O
				this.type = (LogType)message;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000032")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400009C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400009D")]
			public static Func<Assembly, bool> _003C_003E9__22_0;

			[Token(Token = "0x6000188")]
			[Address(RVA = "0x13DC1D0", Offset = "0x13DC1D0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EC18E0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2028A92]) = v37;\nL_0015:\n\tv41 = new LunarConsolePlugin.LunarConsole+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000189")]
			[Address(RVA = "0x13DC234", Offset = "0x13DC234", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CListAssemblies_003Eb__22_0(Assembly assembly)
			{
				//IL_02b5: Expected I4, but got O
				//IL_000d: Expected I, but got O
				//IL_001d: Expected O, but got I
				Assembly assembly2;
				if ((object)assembly != null)
				{
					IntPtr intPtr = (IntPtr)assembly;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Reflection.Assembly>)+1B8]");
					assembly2 = (Assembly)0;
					string fullName = assembly.FullName;
					if (fullName != null)
					{
						if (fullName.StartsWith("Unity") || fullName.StartsWith("System") || fullName.StartsWith("Microsoft") || fullName.StartsWith("SyntaxTree") || fullName.StartsWith("Mono") || fullName.StartsWith("ExCSS") || fullName.StartsWith("nunit") || fullName.StartsWith("netstandard") || fullName.StartsWith("mscorlib"))
						{
							return false;
						}
						return fullName != "Accessibility";
					}
				}
				else
				{
					assembly2 = assembly;
				}
				NullReferenceException ex = new NullReferenceException();
				ex = (NullReferenceException)(object)assembly2;
				string className = default(string);
				((Exception)ex)._className = className;
				return (byte)(int)ex != 0;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000039")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private LunarConsoleSettings m_settings;

		[Token(Token = "0x400003A")]
		internal static LunarConsole s_instance;

		[Token(Token = "0x400003B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private CRegistry m_registry;

		[Token(Token = "0x400003C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private bool m_variablesDirty;

		[Token(Token = "0x400003D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private IPlatform m_platform;

		[Token(Token = "0x400003E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		private IDictionary<string, LunarConsoleNativeMessageHandler> m_nativeHandlerLookup;

		[Token(Token = "0x17000013")]
		private unsafe IDictionary<string, LunarConsoleNativeMessageHandler> nativeHandlerLookup
		{
			[Token(Token = "0x6000064")]
			[Address(RVA = "0x13D94F8", Offset = "0x13D94F8", Length = "0x3CC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EACDE8]);\n\tv27 = *([v26 @ X8_v46]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2028A76]) = v46;\nL_0017:\n\treturnVal1 = this.m_nativeHandlerLookup;\n\tv48 = this.m_nativeHandlerLookup == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_016D;\n\tv53 = new System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>::.ctor(v53);\n\tthis.m_nativeHandlerLookup = v53;\n\tv184 = new LunarConsolePlugin.LunarConsoleNativeMessageHandler();\n\tv188 = Il2CppMethodInfo;\n\tv184.m_target = this;\n\tv184.method = Il2CppMethodInfo;\n\tv184.method_ptr = *([v188 @ X8_v10 (Il2CppMethodInfo)]);\n\tv192 = *([v53 @ X0_v5 (System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>)]);\n\tv198 = *([v192 @ X8_v12 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]) == 0;\n\tif (v198) goto L_005A;\n\tv330 = *([v192 @ X8_v12 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]) + 8;\nL_0045:\n\tv336 = *([v330 @ X11_v31-8]) == System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>;\n\tif (v336) goto L_005D;\n\tv331 = v331 + 1;\n\tv341 = v331 < *([v192 @ X8_v12 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]);\n\tv312 = ~v341;\n\tv330 = v330 + 0x10;\n\tv296 = ~v312;\n\tif (v296) goto L_0045;\nL_005A:\n\tv349 = 0x8909C4(v53, System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>, 1, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0066;\nL_005D:\n\tv343 = *([v330 @ X11_v31]) + 1;\n\tv344 = v343 << 4;\n\tv345 = v192 + v344;\n\tv349 = v345 + 0x130;\nL_0066:\n\t*([v349 @ X0_v11])(v353, v53, \"console_open\", v184, *([v349 @ X0_v11+8]), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv286 = this.m_nativeHandlerLookup;\n\tv274 = new LunarConsolePlugin.LunarConsoleNativeMessageHandler();\n\tv282 = Il2CppMethodInfo;\n\tv274.m_target = this;\n\tv274.method = Il2CppMethodInfo;\n\tv274.method_ptr = *([v282 @ X8_v17 (Il2CppMethodInfo)]);\n\tv358 = *([v286 @ X20_v6 (System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>)]);\n\tv362 = *([v358 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]) == 0;\n\tif (v362) goto L_0099;\n\tv403 = *([v358 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]) + 8;\nL_0084:\n\tv409 = *([v403 @ X11_v26-8]) == System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>;\n\tif (v409) goto L_009C;\n\tv404 = v404 + 1;\n\tv414 = v404 < *([v358 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]);\n\tv385 = ~v414;\n\tv403 = v403 + 0x10;\n\tv369 = ~v385;\n\tif (v369) goto L_0084;\nL_0099:\n\tv422 = 0x8909C4(v286, System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>, 1, *([v349 @ X0_v11+8]), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A5;\nL_009C:\n\tv416 = *([v403 @ X11_v26]) + 1;\n\tv417 = v416 << 4;\n\tv418 = v358 + v417;\n\tv422 = v418 + 0x130;\nL_00A5:\n\t*([v422 @ X0_v16])(v426, v286, \"console_close\", v274, *([v422 @ X0_v16+8]), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv287 = this.m_nativeHandlerLookup;\n\tv275 = new LunarConsolePlugin.LunarConsoleNativeMessageHandler();\n\tv283 = Il2CppMethodInfo;\n\tv275.m_target = this;\n\tv275.method = Il2CppMethodInfo;\n\tv275.method_ptr = *([v283 @ X8_v23 (Il2CppMethodInfo)]);\n\tv431 = *([v287 @ X20_v7 (System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>)]);\n\tv435 = *([v431 @ X8_v24 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]) == 0;\n\tif (v435) goto L_00D8;\n\tv476 = *([v431 @ X8_v24 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]) + 8;\nL_00C3:\n\tv482 = *([v476 @ X11_v21-8]) == System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>;\n\tif (v482) goto L_00DB;\n\tv477 = v477 + 1;\n\tv487 = v477 < *([v431 @ X8_v24 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]);\n\tv458 = ~v487;\n\tv476 = v476 + 0x10;\n\tv442 = ~v458;\n\tif (v442) goto L_00C3;\nL_00D8:\n\tv495 = 0x8909C4(v287, System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>, 1, *([v422 @ X0_v16+8]), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00E4;\nL_00DB:\n\tv489 = *([v476 @ X11_v21]) + 1;\n\tv490 = v489 << 4;\n\tv491 = v431 + v490;\n\tv495 = v491 + 0x130;\nL_00E4:\n\t*([v495 @ X0_v21])(v499, v287, \"console_action\", v275, *([v495 @ X0_v21+8]), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv288 = this.m_nativeHandlerLookup;\n\tv276 = new LunarConsolePlugin.LunarConsoleNativeMessageHandler();\n\tv284 = Il2CppMethodInfo;\n\tv276.m_target = this;\n\tv276.method = Il2CppMethodInfo;\n\tv276.method_ptr = *([v284 @ X8_v29 (Il2CppMethodInfo)]);\n\tv504 = *([v288 @ X20_v8 (System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>)]);\n\tv508 = *([v504 @ X8_v30 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]) == 0;\n\tif (v508) goto L_0117;\n\tv549 = *([v504 @ X8_v30 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]) + 8;\nL_0102:\n\tv555 = *([v549 @ X11_v16-8]) == System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>;\n\tif (v555) goto L_011A;\n\tv550 = v550 + 1;\n\tv560 = v550 < *([v504 @ X8_v30 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]);\n\tv531 = ~v560;\n\tv549 = v549 + 0x10;\n\tv515 = ~v531;\n\tif (v515) goto L_0102;\nL_0117:\n\tv568 = 0x8909C4(v288, System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>, 1, *([v495 @ X0_v21+8]), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0123;\nL_011A:\n\tv562 = *([v549 @ X11_v16]) + 1;\n\tv563 = v562 << 4;\n\tv564 = v504 + v563;\n\tv568 = v564 + 0x130;\nL_0123:\n\t*([v568 @ X0_v26])(v572, v288, \"console_variable_set\", v276, *([v568 @ X0_v26+8]), v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv117 = this.m_nativeHandlerLookup;\n\tv277 = new LunarConsolePlugin.LunarConsoleNativeMessageHandler();\n\tv285 = Il2CppMethodInfo;\n\tv277.m_target = this;\n\tv277.method = Il2CppMethodInfo;\n\tv277.method_ptr = *([v285 @ X8_v35 (Il2CppMethodInfo)]);\n\tv577 = *([v117 @ X20_v9 (System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>)]);\n\tv113 = *([v577 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]) == 0;\n\tif (v113) goto L_0156;\n\tv621 = *([v577 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]) + 8;\nL_0141:\n\tv627 = *([v621 @ X11_v11-8]) == System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>;\n\tif (v627) goto L_0159;\n\tv622 = v622 + 1;\n\tv632 = v622 < *([v577 @ X8_v\n// ... truncated")]
			get
			{
				//IL_005c: Expected I, but got O
				//IL_0097: Expected O, but got I
				//IL_0152: Expected I, but got O
				//IL_0114: Unknown result type (might be due to invalid IL or missing references)
				//IL_0119: Expected O, but got Unknown
				//IL_0136: Expected O, but got I
				//IL_0145: Expected O, but got I
				//IL_018d: Expected O, but got I
				//IL_00e3: Expected O, but got I
				//IL_0248: Expected I, but got O
				//IL_020a: Unknown result type (might be due to invalid IL or missing references)
				//IL_020f: Expected O, but got Unknown
				//IL_022c: Expected O, but got I
				//IL_023b: Expected O, but got I
				//IL_0283: Expected O, but got I
				//IL_01d9: Expected O, but got I
				//IL_033e: Expected I, but got O
				//IL_0300: Unknown result type (might be due to invalid IL or missing references)
				//IL_0305: Expected O, but got Unknown
				//IL_0322: Expected O, but got I
				//IL_0331: Expected O, but got I
				//IL_0379: Expected O, but got I
				//IL_02cf: Expected O, but got I
				//IL_0434: Expected I, but got O
				//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_03fb: Expected O, but got Unknown
				//IL_0418: Expected O, but got I
				//IL_0427: Expected O, but got I
				//IL_046f: Expected O, but got I
				//IL_03c5: Expected O, but got I
				//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
				//IL_04f1: Expected O, but got Unknown
				//IL_050e: Expected O, but got I
				//IL_051d: Expected O, but got I
				//IL_04bb: Expected O, but got I
				IDictionary<string, LunarConsoleNativeMessageHandler> result = m_nativeHandlerLookup;
				if (m_nativeHandlerLookup == null)
				{
					Dictionary<string, LunarConsoleNativeMessageHandler> dictionary = (Dictionary<string, LunarConsoleNativeMessageHandler>)(m_nativeHandlerLookup = new Dictionary<string, LunarConsoleNativeMessageHandler>());
					LunarConsoleNativeMessageHandler lunarConsoleNativeMessageHandler = null;
					IntPtr method_ptr = (IntPtr)0;
					((Delegate)lunarConsoleNativeMessageHandler).m_target = this;
					((Delegate)lunarConsoleNativeMessageHandler).method = (IntPtr)__ldftn(LunarConsole.ConsoleOpenHandler);
					((Delegate)lunarConsoleNativeMessageHandler).method_ptr = method_ptr;
					IntPtr intPtr = (IntPtr)dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X8_v12 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00fc;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X8_v12 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ X11_v31-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, LunarConsoleNativeMessageHandler>))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X8_v12 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00fc;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_0580;
				}
				goto IL_0769;
				IL_01f2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_05f4;
				IL_05f4:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v422 @ X0_v16] (should have been resolved before IL gen)");
				IDictionary<string, LunarConsoleNativeMessageHandler> dictionary2 = m_nativeHandlerLookup;
				LunarConsoleNativeMessageHandler lunarConsoleNativeMessageHandler2 = null;
				IntPtr method_ptr2 = (IntPtr)0;
				((Delegate)lunarConsoleNativeMessageHandler2).m_target = this;
				((Delegate)lunarConsoleNativeMessageHandler2).method = (IntPtr)__ldftn(LunarConsole.ConsoleActionHandler);
				((Delegate)lunarConsoleNativeMessageHandler2).method_ptr = method_ptr2;
				IntPtr intPtr2 = (IntPtr)dictionary2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ X8_v24 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_02e8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ X8_v24 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]");
				object obj5 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ X11_v21-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, LunarConsoleNativeMessageHandler>))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ X8_v24 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj5 = (long)(IntPtr)obj5 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_02e8;
				}
				object obj6 = obj5 + 1;
				int num6 = (int)((long)(IntPtr)obj6 << 4);
				object obj7 = (long)intPtr2 + (long)num6;
				object obj8 = (long)(IntPtr)obj7 + 304L;
				goto IL_0668;
				IL_0668:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v495 @ X0_v21] (should have been resolved before IL gen)");
				IDictionary<string, LunarConsoleNativeMessageHandler> dictionary3 = m_nativeHandlerLookup;
				LunarConsoleNativeMessageHandler lunarConsoleNativeMessageHandler3 = null;
				IntPtr method_ptr3 = (IntPtr)0;
				((Delegate)lunarConsoleNativeMessageHandler3).m_target = this;
				((Delegate)lunarConsoleNativeMessageHandler3).method = (IntPtr)__ldftn(LunarConsole.ConsoleVariableSetHandler);
				((Delegate)lunarConsoleNativeMessageHandler3).method_ptr = method_ptr3;
				IntPtr intPtr3 = (IntPtr)dictionary3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X8_v30 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_03de;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X8_v30 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]");
				object obj9 = 0L + 8L;
				int num7 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ X11_v16-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, LunarConsoleNativeMessageHandler>))
					{
						break;
					}
					num7++;
					int num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X8_v30 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
					bool flag5 = (long)num8 < 0L;
					bool flag6 = !flag5;
					obj9 = (long)(IntPtr)obj9 + 16L;
					if (!flag6)
					{
						continue;
					}
					goto IL_03de;
				}
				object obj10 = obj9 + 1;
				int num9 = (int)((long)(IntPtr)obj10 << 4);
				object obj11 = (long)intPtr3 + (long)num9;
				object obj12 = (long)(IntPtr)obj11 + 304L;
				goto IL_06dc;
				IL_03de:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_06dc;
				IL_06dc:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v568 @ X0_v26] (should have been resolved before IL gen)");
				IDictionary<string, LunarConsoleNativeMessageHandler> dictionary4 = m_nativeHandlerLookup;
				LunarConsoleNativeMessageHandler lunarConsoleNativeMessageHandler4 = null;
				IntPtr method_ptr4 = (IntPtr)0;
				((Delegate)lunarConsoleNativeMessageHandler4).m_target = this;
				((Delegate)lunarConsoleNativeMessageHandler4).method = (IntPtr)__ldftn(LunarConsole.TrackEventHandler);
				((Delegate)lunarConsoleNativeMessageHandler4).method_ptr = method_ptr4;
				IntPtr intPtr4 = (IntPtr)dictionary4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_04d4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]");
				object obj13 = 0L + 8L;
				int num10 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ X11_v11-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, LunarConsoleNativeMessageHandler>))
					{
						break;
					}
					num10++;
					int num11 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
					bool flag7 = (long)num11 < 0L;
					bool flag8 = !flag7;
					obj13 = (long)(IntPtr)obj13 + 16L;
					if (!flag8)
					{
						continue;
					}
					goto IL_04d4;
				}
				object obj14 = obj13 + 1;
				int num12 = (int)((long)(IntPtr)obj14 << 4);
				object obj15 = (long)intPtr4 + (long)num12;
				object obj16 = (long)(IntPtr)obj15 + 304L;
				goto IL_0750;
				IL_00fc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0580;
				IL_0580:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v349 @ X0_v11] (should have been resolved before IL gen)");
				IDictionary<string, LunarConsoleNativeMessageHandler> dictionary5 = m_nativeHandlerLookup;
				LunarConsoleNativeMessageHandler lunarConsoleNativeMessageHandler5 = null;
				IntPtr method_ptr5 = (IntPtr)0;
				((Delegate)lunarConsoleNativeMessageHandler5).m_target = this;
				((Delegate)lunarConsoleNativeMessageHandler5).method = (IntPtr)__ldftn(LunarConsole.ConsoleCloseHandler);
				((Delegate)lunarConsoleNativeMessageHandler5).method_ptr = method_ptr5;
				IntPtr intPtr5 = (IntPtr)dictionary5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01f2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]");
				object obj17 = 0L + 8L;
				int num13 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ X11_v26-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, LunarConsoleNativeMessageHandler>))
					{
						break;
					}
					num13++;
					int num14 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
					bool flag9 = (long)num14 < 0L;
					bool flag10 = !flag9;
					obj17 = (long)(IntPtr)obj17 + 16L;
					if (!flag10)
					{
						continue;
					}
					goto IL_01f2;
				}
				object obj18 = obj17 + 1;
				int num15 = (int)((long)(IntPtr)obj18 << 4);
				object obj19 = (long)intPtr5 + (long)num15;
				object obj20 = (long)(IntPtr)obj19 + 304L;
				goto IL_05f4;
				IL_0750:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v639 @ X0_v31] (should have been resolved before IL gen)");
				result = m_nativeHandlerLookup;
				goto IL_0769;
				IL_04d4:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0750;
				IL_02e8:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0668;
				IL_0769:
				return result;
			}
		}

		[Token(Token = "0x17000014")]
		[field: Token(Token = "0x400003F")]
		public static Action onConsoleOpened
		{
			[Token(Token = "0x6000074")]
			[Address(RVA = "0x13DBB4C", Offset = "0x13DBB4C", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EB4BA0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028A85]) = v35;\nL_001A:\n\treturn v41.<onConsoleOpened>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000075")]
			[Address(RVA = "0x13DBB9C", Offset = "0x13DBB9C", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED8C98]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A86]) = v38;\nL_0017:\n\tv42.<onConsoleOpened>k__BackingField = value;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000015")]
		[field: Token(Token = "0x4000040")]
		public static Action onConsoleClosed
		{
			[Token(Token = "0x6000076")]
			[Address(RVA = "0x13DBBF0", Offset = "0x13DBBF0", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EDB308]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028A87]) = v35;\nL_001A:\n\treturn v41.<onConsoleClosed>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000077")]
			[Address(RVA = "0x13DBC40", Offset = "0x13DBC40", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED9B68]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A88]) = v38;\nL_0017:\n\tv42.<onConsoleClosed>k__BackingField = value;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000016")]
		public static LunarConsole instance
		{
			[Token(Token = "0x6000080")]
			[Address(RVA = "0x13DC070", Offset = "0x13DC070", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1ED54A8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028A90]) = v35;\nL_001A:\n\treturn v41.s_instance;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return s_instance;
			}
		}

		[Token(Token = "0x17000017")]
		public CRegistry registry
		{
			[Token(Token = "0x6000081")]
			[Address(RVA = "0x13DC0C0", Offset = "0x13DC0C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_registry;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return registry;
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x13D5AFC", Offset = "0x13D5AFC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.LunarConsole::InitInstance(this);\n\treturn;\n")]
		private void Awake()
		{
			InitInstance();
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x13D5C6C", Offset = "0x13D5C6C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.LunarConsole::EnablePlatform(this);\n\treturn;\n")]
		private void OnEnable()
		{
			EnablePlatform();
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x13D5D0C", Offset = "0x13D5D0C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.LunarConsole::DisablePlatform(this);\n\treturn;\n")]
		private void OnDisable()
		{
			DisablePlatform();
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x13D5DA8", Offset = "0x13D5DA8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECA230]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A64]) = v38;\nL_0014:\n\tv40 = this.m_platform == 0;\n\tif (v40) goto L_0045;\n\tgoto L_0043;\n\tv100 = *([v42 @ X8_v5+B0]);\n\tv101 = 0;\n\tv102 = v100 + 8;\n\tv104 = *([v149 @ X11_v6-8]);\n\tv155 = v104 == v45;\n\tif (v155) goto L_003C;\n\tv126 = v150 + 1;\n\tv165 = v126 < v44;\n\tv122 = ~v165;\n\tv124 = v149 + 0x10;\n\tv106 = ~v122;\n\tif (v106) goto L_FFFFFFFF;\n\tv127 = v39;\n\tv128 = 0;\n\tv129 = 0x8909C4(v127, v45, v128, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0043;\nL_003C:\n\tv166 = *([v149 @ X11_v6]);\n\tv167 = v166 << 4;\n\tv168 = v42 + v167;\n\tv169 = v168 + 0x130;\nL_0043:\n\tLunarConsolePlugin.LunarConsole+IPlatform::Update(this.m_platform);\nL_0045:\n\tv99 = ~this.m_variablesDirty;\n\tif (v99) goto L_0055;\n\tthis.m_variablesDirty = 0;\n\tLunarConsolePlugin.LunarConsole::SaveVariables(this);\n\treturn;\nL_0055:\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (m_platform != null)
			{
				m_platform.Update();
			}
			if (m_variablesDirty)
			{
				m_variablesDirty = false;
				SaveVariables();
			}
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x13D667C", Offset = "0x13D667C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePlugin.LunarConsole::DestroyInstance(this);\n\treturn;\n")]
		private void OnDestroy()
		{
			DestroyInstance();
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x13D5B00", Offset = "0x13D5B00", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EEBA90]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2028A65]) = v42;\nL_0020:\n\tgoto L_0029;\n\tv54 = *([v49 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tv64 = UnityEngine.Object::op_Equality(v48.s_instance, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_005E;\n\tv68 = UnityEngine.Application::get_platform();\n\tv85 = v68 != 0xB;\n\tif (v85) goto L_006D;\n\tv100.s_instance = this;\n\tv101 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0055;\n\tv148 = *([v132 @ X8_v14+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tif (v150) goto L_0055;\n\tv199 = v132;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v199, v99, v63, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0055:\n\tUnityEngine.Object::DontDestroyOnLoad(v101);\n\treturn;\nL_005E:\n\tgoto L_0067;\n\tv86 = *([v70 @ X0_v13+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0067;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v70, v62, v63, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0067:\n\tv96 = UnityEngine.Object::op_Inequality(v71.s_instance, this);\n\tv125 = v96 == 0;\n\tif (v125) goto L_008C;\nL_006D:\n\tv130 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0083;\n\tv163 = *([v137 @ X8_v7+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_0083;\n\tv200 = v137;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v200, v129, v121, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0083:\n\tUnityEngine.Object::Destroy(v130);\n\treturn;\nL_008C:\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitInstance()
		{
			if (s_instance == null)
			{
				RuntimePlatform platform = Application.platform;
				if (platform == RuntimePlatform.Android)
				{
					s_instance = this;
					GameObject target = base.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
					return;
				}
			}
			else if (!(s_instance != this))
			{
				return;
			}
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x13D5C70", Offset = "0x13D5C70", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EB6E40]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A66]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv50 = *([v45 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0027;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv60 = UnityEngine.Object::op_Inequality(v44.s_instance, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0039;\n\tv69 = LunarConsolePlugin.LunarConsole::InitPlatform(this, this.m_settings);\n\treturn;\nL_0039:\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EnablePlatform()
		{
			if (s_instance != null)
			{
				bool flag = InitPlatform(m_settings);
			}
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x13D5D10", Offset = "0x13D5D10", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EFA8D0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A67]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv50 = *([v45 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0027;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv60 = UnityEngine.Object::op_Inequality(v44.s_instance, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0038;\n\tv68 = LunarConsolePlugin.LunarConsole::DestroyPlatform(this);\n\treturn;\nL_0038:\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DisablePlatform()
		{
			if (s_instance != null)
			{
				bool flag = DestroyPlatform();
			}
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x13D6724", Offset = "0x13D6724", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Application::get_platform();\n\tv10 = v7 - 0xB;\n\tv12 = v10 == 0;\n\treturn v12;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsPlatformSupported()
		{
			RuntimePlatform platform = Application.platform;
			int num = (int)(platform - 11);
			return num == 0;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x13D6744", Offset = "0x13D6744", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F0D5F8]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, settings, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A68]) = v41;\nL_0016:\n\tv43 = this.m_platform == 0;\n\tif (v43) goto L_001C;\n\tgoto L_0046;\nL_001C:\n\tv86 = LunarConsolePlugin.LunarConsole::CreatePlatform(this, v131);\n\tthis.m_platform = v86;\n\tv106 = v86 == 0;\n\tif (v106) goto L_0046;\n\tv147 = new LunarConsolePluginInternal.CRegistry();\n\tLunarConsolePluginInternal.CRegistry::.ctor(v147);\n\tthis.m_registry = v147;\n\tv105 = v147 == 0;\n\tif (v105) goto L_0048;\n\tv147.m_delegate = this.m_platform;\n\tv154 = new UnityEngine.Application+LogCallback();\n\tUnityEngine.Application+LogCallback::.ctor(v154, this, Il2CppMethodInfo);\n\tUnityEngine.Application::add_logMessageReceivedThreaded(v154);\n\tLunarConsolePlugin.LunarConsole::ResolveVariables(this);\n\tLunarConsolePlugin.LunarConsole::LoadVariables(this);\nL_0046:\n\treturn returnVal1;\nL_0048:\n\tv156 = new System.NullReferenceException();\n\tgoto L_0057;\n\tgoto L_0057;\n\tgoto L_0057;\n\tgoto L_0057;\nL_0057:\n\tv46 = v131 != 1;\n\tif (v46) goto L_0083;\n\tv165 = 0x6D2BC0(v156, v131, v129, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = *([v165 @ X0_v15]);\n\tv180 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v78 @ X19_v6 (System.Exception)]), v129, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv181 = v180 & 1;\n\tv170 = v181 == 0;\n\tif (v170) goto L_0079;\n\tv182 = 0x6D2490(v180, *([v78 @ X19_v6 (System.Exception)]), v129, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0076;\n\tv193 = *([v187 @ X0_v23+E0]);\n\tv194 = v193 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_0076;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v187, v178, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0076:\n\tLunarConsolePluginInternal.Log::e(v78, \"Can't init platform\");\n\tgoto L_FFFFFFFF;\nL_0079:\n\tv184 = 0x6D1E60(8, *([v78 @ X19_v6 (System.Exception)]), v129, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v184 @ X0_v19]) = *([v165 @ X0_v15]);\n\tv131 = 0x1E8A000 + 0x870;\n\tv192 = 0x6D2A00(v184, v131, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv169 = 0x6D2490(v192, v131, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0083:\n\tv174 = 0x6D2380(v137, v131, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = 0x846AA4(v174, v131, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool InitPlatform(LunarConsoleSettings settings)
		{
			//IL_0042: Expected I4, but got O
			//IL_0199: Expected O, but got I4
			if (m_platform != null)
			{
				goto IL_0005;
			}
			LunarConsoleSettings lunarConsoleSettings = default(LunarConsoleSettings);
			IPlatform platform = (m_platform = CreatePlatform(lunarConsoleSettings));
			bool flag = platform == null;
			bool result = (byte)(int)platform != 0;
			if (!flag)
			{
				CRegistry cRegistry = (m_registry = new CRegistry());
				if (cRegistry == null)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag2 = (IntPtr)lunarConsoleSettings != (IntPtr)1;
					NullReferenceException ex2 = ex;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj = default(object);
						Exception exception = (Exception)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj2 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							Log.e(exception, "Can't init platform");
							goto IL_0005;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj3 = obj;
						lunarConsoleSettings = (LunarConsoleSettings)(32022528 + 2160);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					bool result2 = default(bool);
					return result2;
				}
				cRegistry.registryDelegate = m_platform;
				Application.LogCallback value = OnLogMessageReceived;
				Application.logMessageReceivedThreaded += value;
				ResolveVariables();
				LoadVariables();
				result = true;
			}
			goto IL_01fc;
			IL_0005:
			result = false;
			goto IL_01fc;
			IL_01fc:
			return result;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x13D68EC", Offset = "0x13D68EC", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB0D28]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A69]) = v38;\nL_0014:\n\tv40 = this.m_platform == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv44 = new UnityEngine.Application+LogCallback();\n\tUnityEngine.Application+LogCallback::.ctor(v44, this, Il2CppMethodInfo);\n\tUnityEngine.Application::remove_logMessageReceivedThreaded(v44);\n\tv140 = this.m_registry == 0;\n\tif (v140) goto L_0032;\n\tLunarConsolePluginInternal.CRegistry::Destroy(this.m_registry);\n\tthis.m_registry = 0;\nL_0032:\n\tgoto L_005C;\n\tv147 = *([v142 @ X8_v9+B0]);\n\tv148 = 0;\n\tv149 = v147 + 8;\n\tv151 = *([v187 @ X11_v6-8]);\n\tv193 = v151 == v145;\n\tif (v193) goto L_0054;\n\tv173 = v188 + 1;\n\tv198 = v173 < v144;\n\tv169 = ~v198;\n\tv171 = v187 + 0x10;\n\tv153 = ~v169;\n\tif (v153) goto L_FFFFFFFF;\n\tv174 = 5;\n\tv175 = v106;\n\tv176 = 0x8909C4(v175, v145, v174, v49, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_005C;\n\tgoto L_0064;\nL_0054:\n\tv199 = *([v187 @ X11_v6]);\n\tv200 = v199 + 5;\n\tv201 = v200 << 4;\n\tv202 = v142 + v201;\n\tv203 = v202 + 0x130;\nL_005C:\n\tLunarConsolePlugin.LunarConsole+IPlatform::Destroy(this.m_platform);\n\tthis.m_platform = 0;\nL_0064:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DestroyPlatform()
		{
			if (m_platform != null)
			{
				Application.LogCallback value = OnLogMessageReceived;
				Application.logMessageReceivedThreaded -= value;
				if (registry != null)
				{
					registry.Destroy();
					m_registry = null;
				}
				m_platform.Destroy();
				m_platform = null;
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x13D6A08", Offset = "0x13D6A08", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EE3620]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, settings, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2028A6A]) = v45;\nL_0018:\n\tv47 = UnityEngine.Application::get_platform();\n\tv58 = v47 != 0xB;\n\tif (v58) goto L_0068;\n\tv62 = new LunarConsolePlugin.LunarConsoleNativeMessageCallback();\n\tv101 = Il2CppMethodInfo;\n\tv62.m_target = this;\n\tv62.method = Il2CppMethodInfo;\n\tv62.method_ptr = *([v101 @ X8_v8 (Il2CppMethodInfo)]);\n\tv103 = UnityEngine.Component::get_gameObject(this);\n\tv125 = UnityEngine.Object::get_name(v103);\n\tv129 = System.Delegate::get_Method(v62);\n\tv141 = System.Reflection.MemberInfo::get_Name(v129);\n\tgoto L_0058;\n\tv148 = *([v144 @ X8_v10 (Il2CppClass<LunarConsolePluginInternal.Constants>)+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tif (v150) goto L_0058;\n\tv158 = v144;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v158, v140, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv155 = LunarConsolePluginInternal.Constants;\nL_0058:\n\tv79 = new LunarConsolePlugin.LunarConsole+PlatformAndroid();\n\tLunarConsolePlugin.LunarConsole+PlatformAndroid::.ctor(v79, v125, v141, v85.Version, settings);\nL_0068:\n\treturn v76;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe IPlatform CreatePlatform(LunarConsoleSettings settings)
		{
			RuntimePlatform platform = Application.platform;
			bool flag = platform != RuntimePlatform.Android;
			IPlatform result = null;
			if (!flag)
			{
				LunarConsoleNativeMessageCallback lunarConsoleNativeMessageCallback = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)lunarConsoleNativeMessageCallback).m_target = this;
				((Delegate)lunarConsoleNativeMessageCallback).method = (IntPtr)__ldftn(LunarConsole.NativeMessageCallback);
				((Delegate)lunarConsoleNativeMessageCallback).method_ptr = method_ptr;
				GameObject gameObject = base.gameObject;
				string targetName = gameObject.name;
				MethodInfo method = lunarConsoleNativeMessageCallback.Method;
				string methodName = method.Name;
				PlatformAndroid platformAndroid = new PlatformAndroid(targetName, methodName, Constants.Version, settings);
				result = platformAndroid;
			}
			return result;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x13D6680", Offset = "0x13D6680", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EE0C90]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A6B]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v47 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Equality(v46.s_instance, this);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0037;\n\tv66 = LunarConsolePlugin.LunarConsole::DestroyPlatform(this);\n\tv69.s_instance = 0;\nL_0037:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DestroyInstance()
		{
			if (s_instance == this)
			{
				bool flag = DestroyPlatform();
				s_instance = null;
			}
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x13D7EA0", Offset = "0x13D7EA0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECDA28]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A6C]) = v38;\nL_0017:\n\t// 23 Box gesture @ X0 (LunarConsolePlugin.Gesture), typeof(LunarConsolePlugin.Gesture), &gesture @ X0 (LunarConsolePlugin.Gesture)\n\tv46 = *([gesture @ X0 (LunarConsolePlugin.Gesture)]);\n\t*([v46 @ X8_v5+160])(v50, gesture, *([v46 @ X8_v5+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgesture = \"il2cpp_vm_object_unbox\"(gesture, *([v46 @ X8_v5+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn v50;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetGestureName(Gesture gesture)
		{
			//IL_0033: Expected I4, but got O
			//IL_000d: Expected O, but got I4
			Gesture gesture2 = (Gesture)(object)gesture;
			object obj = gesture;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ X8_v5+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x13D6BC4", Offset = "0x13D6BC4", Length = "0x5D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv33 = *([1EC4B00]);\n\tv34 = *([v33 @ X8_v60]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2028A6D]) = v53;\nL_001C:\n\tv54 = &v55 @ stack_-C0;\n\t*([v21 @ X29-68]) = 0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\tv57 = LunarConsolePlugin.LunarConsole::ListAssemblies();\n\tgoto L_0052;\n\tv68 = *([v61 @ X8_v26+B0]);\n\tv69 = 0;\n\tv70 = v68 + 8;\n\tv72 = *([v164 @ X11_v30-8]);\n\tv170 = v72 == v64;\n\tif (v170) goto L_004B;\n\tv105 = v165 + 1;\n\tv176 = v105 < v63;\n\tv99 = ~v176;\n\tv102 = v164 + 0x10;\n\tv75 = ~v99;\n\tif (v75) goto L_FFFFFFFF;\n\tv106 = v58;\n\tv107 = 0;\n\tv108 = 0x8909C4(v106, v64, v107, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0052;\nL_004B:\n\tv177 = *([v164 @ X11_v30]);\n\tv178 = v177 << 4;\n\tv179 = v61 + v178;\n\tv180 = v179 + 0x130;\nL_0052:\n\tv145 = System.Collections.Generic.IEnumerable`1<System.Reflection.Assembly>::GetEnumerator(v57);\nL_0060:\n\tgoto L_0087;\n\tv314 = *([v300 @ X8_v30+B0]);\n\tv315 = 0;\n\tv316 = v314 + 8;\n\tv318 = *([v422 @ X11_v25-8]);\n\tv428 = v318 == v301;\n\tif (v428) goto L_0080;\n\tv340 = v423 + 1;\n\tv455 = v340 < v302;\n\tv336 = ~v455;\n\tv338 = v422 + 0x10;\n\tv320 = ~v336;\n\tif (v320) goto L_FFFFFFFF;\n\tv341 = v151;\n\tv342 = 0;\n\tv343 = 0x8909C4(v341, v301, v342, v38, v39, v40, v41, v42, v201, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0087;\nL_0080:\n\tv456 = *([v422 @ X11_v25]);\n\tv457 = v456 << 4;\n\tv458 = v300 + v457;\n\tv459 = v458 + 0x130;\nL_0087:\n\tv480 = System.Collections.IEnumerator::MoveNext(v145);\n\tv482 = v480 == 0;\n\tif (v482) goto L_0166;\n\tgoto L_00B8;\n\tv573 = *([v490 @ X8_v34+B0]);\n\tv574 = 0;\n\tv575 = v573 + 8;\n\tv577 = *([v712 @ X11_v20-8]);\n\tv718 = v577 == v494;\n\tif (v718) goto L_00B1;\n\tv599 = v713 + 1;\n\tv785 = v599 < v492;\n\tv595 = ~v785;\n\tv597 = v712 + 0x10;\n\tv579 = ~v595;\n\tif (v579) goto L_FFFFFFFF;\n\tv600 = v151;\n\tv601 = 0;\n\tv602 = 0x8909C4(v600, v494, v601, v38, v39, v40, v41, v42, v201, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00B8;\nL_00B1:\n\tv786 = *([v712 @ X11_v20]);\n\tv787 = v786 << 4;\n\tv788 = v490 + v787;\n\tv789 = v788 + 0x130;\nL_00B8:\n\tv795 = System.Collections.Generic.IEnumerator`1<System.Reflection.Assembly>::get_Current(v145);\n\tgoto L_00CA;\n\tv817 = *([v798 @ X0_v53+E0]);\n\tv818 = v817 == 0;\n\tv819 = ~v818;\n\tgoto L_00CA;\n\tv821 = \"il2cpp_codegen_runtime_class_init\"(v798, v793, v214, v38, v39, v40, v41, v42, v201, v44, v45, v46, v47, v48, v49, v50);\nL_00CA:\n\tv826 = LunarConsolePluginInternal.ReflectionUtils::FindAttributeTypes(v795);\n\tv256 = v826 == 0;\n\tif (v256) goto L_00E5;\n\tv831 = System.Collections.Generic.List`1<System.Type>::GetEnumerator(v826);\n\tv504 = *([v21 @ X29-88]);\n\t*([v21 @ X29-60]) = *([v21 @ X29-78]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-88]);\nL_00D7:\n\tv840 = &v21 @ X29 - 0x70;\n\tv841 = System.Collections.Generic.List`1<System.Type>+Enumerator<System.Type>::MoveNext(v840);\n\tv838 = v841 == 0;\n\tif (v838) goto L_00E0;\n\tLunarConsolePlugin.LunarConsole::RegisterVariables(v51, *([v21 @ X29-60]));\n\tgoto L_00D7;\nL_00E0:\n\tv204 = v204 + 1;\n\t*([v54 @ X25_v1+v204 @ X26_v9*4]) = 0x4A;\n\tgoto L_00FF;\nL_00E5:\n\tv253 = new System.NullReferenceException();\n\tgoto L_0187;\n\tgoto L_00E8;\nL_00E8:\n\tX24 = X1;\n\tgoto L_0126;\n\tgoto L_00EB;\nL_00EB:\n\tX24 = X1;\n\tX23 = X0;\n\tC = X24 < 1;\n\tC = ~C;\n\tTEMP1 = X24 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X24 ^ 1;\n\tTEMP3 = X24 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0127;\n\tX0 = X23;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FF:\n\tv846 = &v21 @ X29 - 0x70;\n\tv295 = System.Collections.Generic.List`1<System.Type>+Enumerator<System.Type>::Dispose(v846);\n\tv297 = v204 + 1;\n\tv848 = v297 == 0;\n\tif (v848) goto L_0119;\n\tv272 = *([v54 @ X25_v1+v204 @ X26_v9*4]) != 0x4A;\n\tif (v272) goto L_0119;\n\tv299 = 0xFFFFFFFF ^ v204;\n\tv204 = v204 + v299;\n\tgoto L_0060;\nL_0119:\n\tv257 = v506 == 0;\n\tif (v257) goto L_0060;\n\tv254 = new System.TypeLoadException();\n\tgoto L_0187;\n\tX24 = X1;\n\tX23 = X0;\n\tX21 = 0;\n\tgoto L_0127;\n\tX24 = X1;\n\tX21 = X23;\nL_0126:\n\tX23 = X0;\nL_0127:\n\tC = X24 < 1;\n\tC = ~C;\n\tTEMP1 = X24 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X24 ^ 1;\n\tTEMP3 = X24 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_019D;\n\tX0 = X23;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = X0;\n\tX23 = *([X24]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X23]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_016D;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFE3C0]);\n\tX0 = *([X8]);\n\tX1 = 0 | 1;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = X0;\n\tif (TEMP) goto L_0176;\n\tif (TEMP) goto L_014F;\n\tX8 = *([X24]);\n\tX1 = *([X8+40]);\n\tX0 = X22;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0180;\nL_014F:\n\tX8 = *([X24+18]);\n\tif (TEMP) goto L_0178;\n\t*([X24+20]) = X22;\n\tX8 = *([1EB5228]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_015F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_015F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_015F:\n\tX8 = 0x1EA5000;\n\tX8 = *([1EA5AB8]);\n\tX1 = *([X8]);\n\tX0 = X23;\n\tX2 = X24;\n\tLunarConsolePluginInternal.Log::e(X0, X1, X2, X3);\n\tgoto L_0060;\nL_0166:\n\tv505 = v204 + 1;\n\t*([v54 @ X25_v1+v505 @ X26_v5*4]) = 0x76;\n\tv498 = v145 == 0;\n\tv499 = ~v498;\n\tif (v499) goto L_01AB;\n\tgoto L_01D3;\nL_016D:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X24]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0232;\nL_0176:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0178:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tthrow System.NullReferenceException;\n\tv153 = new System.NullReferenceException();\nL_0180:\n\tv175 = new System.ArrayTypeMismatchException();\n\tv184 = 0;\n\tv185 = 0;\n\tthrow v175;\nL_0187:\n\tgoto L_019D;\n\tgoto L_018B;\n\tgoto L_0192;\n\tgoto L_FFFFFFFF;\nL_018B:\n\tX24 = X1;\n\tX23 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_019D;\n\tgoto L_0192;\n\tgoto L_0192;\n\tgoto L_0192;\nL_0192:\n\tX24 = X1;\n\tX23 = X0;\nL_019D:\n\tv313 = v441 != 1;\n\tif (v313) goto L_01FA;\n\tv345 = LunarConsolePluginInternal.ReflectionUtils::FindAttributeTypes(v253);\n\tv506 = *([v345 @ X0_v34 (System.Collections.Generic.List`1<System.Type>)]);\n\tv434 = LunarConsolePluginInternal.ReflectionUtils::FindAttributeTypes(v345);\n\tv483 = v527 == 0;\n\tif (v483) goto L_01D3;\nL_01AB:\n\tgoto L_01D2;\n\tv603 = *([v529 @ X8_v20+B0]);\n\tv604 = 0;\n\tv605 = v603 + 8;\n\tv607 = *([v733 @ X11_v9-8]);\n\tv739 = v607 == v532;\n\tif (v739) goto L_01CB;\n\tv629 = v734 + 1;\n\tv802 = v629 < v531;\n\tv625 = ~v802;\n\tv627 = v733 + 0x10;\n\tv609 = ~v625;\n\tif (v609) goto L_FFFFFFFF;\n\tv630 = v527;\n\tv631 = 0;\n\tv632 = 0x8909C4(v630, v532, v631, v38, v39, v40, v41, v42, v504, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01D2;\nL_01CB:\n\tv803 = *([v733 @ X11_v9]);\n\tv804 = v803 << 4;\n\tv805 = v529 + v804;\n\tv806 = v805 + 0x130;\nL_01D2:\n\tSystem.IDisposable::Dispose(v527);\nL_01D3:\n\tv567 = v357 + 1;\n\tv569 = v567 == 0;\n\tif (v569) goto L_01E7;\n\tv633 = v359 == 0;\n\tif (v633) goto L_0228;\n\tv749 = *([v54 @ X25_v1+v357 @ X26_v2*4]) == 0x76;\n\tif (v749) goto L_0228;\n\tgoto L_01EC;\nL_01E7:\n\tv634 = v359 == 0;\n\tif (v634) goto L_0228;\nL_01EC:\n\tv395 = new System.TypeLoadException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_01FA:\n\tv411 = v350 != 1;\n\tif (v411) goto L_0234;\n\tv436 = LunarConsolePluginInternal.ReflectionUtils::FindAttributeTypes(v437);\n\tv452 = *([v436 @ X0_v9 (System.Collections.Generic.List`1<System.\n// ... truncated")]
		private unsafe void ResolveVariables()
		{
			//IL_0027: Expected O, but got I8
			//IL_002c: Expected I, but got O
			//IL_01cb: Expected O, but got I
			//IL_04cb: Expected O, but got I
			//IL_007d: Expected O, but got I
			//IL_048d: Expected O, but got I
			//IL_030d: Expected I, but got O
			//IL_0323: Expected I, but got O
			//IL_00c2: Expected O, but got I
			//IL_0238: Expected I, but got O
			//IL_00ea: Expected O, but got I
			//IL_0102: Expected O, but got I
			//IL_00ae: Expected O, but got I
			//IL_026e: Expected O, but got I8
			//IL_027b: Expected O, but got I8
			//IL_0283: Expected I, but got O
			//IL_0181: Expected I, but got O
			//IL_015a: Expected I4, but got I8
			//IL_0168: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			IList<Assembly> list = ListAssemblies();
			IEnumerator<Assembly> enumerator = list.GetEnumerator();
			object obj5 = default(object);
			object obj4 = obj5;
			object obj6 = 4294967295L;
			IntPtr intPtr = (IntPtr)null;
			IEnumerator<Assembly> enumerator2 = default(IEnumerator<Assembly>);
			NullReferenceException ex2 = default(NullReferenceException);
			IntPtr intPtr4;
			TypeLoadException assembly;
			IntPtr intPtr3 = default(IntPtr);
			while (true)
			{
				object obj7;
				object obj8;
				IntPtr intPtr2;
				int num2;
				if (!enumerator.MoveNext())
				{
					obj7 = (long)(IntPtr)obj6 + 1L;
					_ = 118;
					bool flag = enumerator == null;
					bool flag2 = !flag;
					enumerator2 = enumerator;
					if (!flag2)
					{
						obj5 = obj4;
						obj8 = obj7;
						intPtr2 = intPtr;
						goto IL_04bc;
					}
				}
				else
				{
					Assembly current = enumerator.Current;
					List<Type> list2 = ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>(current);
					if (list2 != null)
					{
						List<Type>.Enumerator enumerator3 = list2.GetEnumerator();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
						obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-78]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
						_ = 0;
						while (true)
						{
							List<Type>.Enumerator enumerator4 = (List<Type>.Enumerator)((long)(IntPtr)obj - 112L);
							if (!((List<Type>.Enumerator*)enumerator4)->MoveNext())
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
							RegisterVariables((Type)0);
						}
						obj6 = (long)(IntPtr)obj6 + 1L;
						_ = 74;
						List<Type>.Enumerator enumerator5 = (List<Type>.Enumerator)((long)(IntPtr)obj - 112L);
						((List<Type>.Enumerator*)enumerator5)->Dispose();
						object obj9 = (long)(IntPtr)obj6 + 1L;
						if (obj9 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X25_v1+v204 @ X26_v9*4]");
							if ((IntPtr)0 == (IntPtr)74)
							{
								int num = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj6);
								obj6 = (long)(IntPtr)obj6 + (long)num;
								continue;
							}
						}
						bool flag3 = intPtr == (IntPtr)0;
						intPtr = (IntPtr)null;
						if (flag3)
						{
							continue;
						}
						TypeLoadException ex = new TypeLoadException();
						obj5 = obj4;
						num2 = 0;
						intPtr3 = (IntPtr)0;
						enumerator2 = enumerator;
					}
					else
					{
						ex2 = new NullReferenceException();
					}
					bool flag4 = intPtr3 != (IntPtr)1;
					intPtr4 = intPtr3;
					assembly = (TypeLoadException)(object)ex2;
					if (flag4)
					{
						break;
					}
					List<Type> list3 = ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>((Assembly)(object)ex2);
					intPtr = (IntPtr)list3;
					List<Type> list4 = ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>((Assembly)(object)list3);
					bool flag5 = enumerator2 == null;
					obj4 = obj5;
					obj7 = 4294967295L;
					obj8 = 4294967295L;
					intPtr2 = (IntPtr)list3;
					if (flag5)
					{
						goto IL_04bc;
					}
				}
				enumerator2.Dispose();
				obj5 = obj4;
				obj8 = obj7;
				intPtr2 = intPtr;
				goto IL_04bc;
				IL_04bc:
				object obj10 = (long)(IntPtr)obj8 + 1L;
				if (obj10 != null)
				{
					if (intPtr2 == (IntPtr)0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X25_v1+v357 @ X26_v2*4]");
					if ((IntPtr)0 == (IntPtr)118)
					{
						return;
					}
				}
				else if (intPtr2 == (IntPtr)0)
				{
					return;
				}
				TypeLoadException ex3 = new TypeLoadException();
				intPtr4 = (IntPtr)null;
				assembly = ex3;
				num2 = 0;
				intPtr3 = (IntPtr)null;
				break;
			}
			if (intPtr4 == (IntPtr)1)
			{
				List<Type> list5 = ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>((Assembly)(object)assembly);
				Exception exception = (Exception)(object)list5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj11 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj11 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Log.e(exception, "Unable to register variables");
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				Assembly assembly2 = (Assembly)(object)list5;
				intPtr3 = (IntPtr)(32022528 + 2160);
				TypeLoadException ex4 = (TypeLoadException)(object)ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>(assembly2);
				List<Type> list6 = ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>((Assembly)(object)ex4);
				assembly = ex4;
			}
			List<Type> assembly3 = ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>((Assembly)(object)assembly);
			List<Type> list7 = ReflectionUtils.FindAttributeTypes<CVarContainerAttribute>((Assembly)(object)assembly3);
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x13D7F28", Offset = "0x13D7F28", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFCBB0]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2028A6E]) = v39;\nL_0019:\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<LunarConsolePlugin.LunarConsole+<>c>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = LunarConsolePlugin.LunarConsole+<>c;\nL_0021:\n\tv78 = v53.<>9__22_0;\n\tv55 = v53.<>9__22_0 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0047;\n\tgoto L_0034;\n\tv86 = *([v49 @ X0_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+<>c>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0034;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v49, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv114 = LunarConsolePlugin.LunarConsole+<>c;\n\tv93 = *([v114 @ X8_v19+B8]);\nL_0034:\n\tv73 = new System.Func`2<System.Reflection.Assembly, System.Boolean>();\n\tSystem.Func`2<System.Reflection.Assembly, System.Boolean>::.ctor(v73, v92.<>9, Il2CppMethodInfo);\n\tv77.<>9__22_0 = v73;\nL_0047:\n\tgoto L_0054;\n\tv97 = *([v82 @ X0_v5+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tgoto L_0054;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v82, v67, v65, v63, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0054:\n\treturnVal1 = LunarConsolePluginInternal.ReflectionUtils::ListAssemblies(v78);\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IList<Assembly> ListAssemblies()
		{
			Func<Assembly, bool> filter = _003C_003Ec._003C_003E9__22_0;
			if (_003C_003Ec._003C_003E9__22_0 == null)
			{
				filter = (_003C_003Ec._003C_003E9__22_0 = delegate(Assembly assembly)
				{
					//IL_02b5: Expected I4, but got O
					//IL_000d: Expected I, but got O
					//IL_001d: Expected O, but got I
					Assembly assembly2;
					if ((object)assembly != null)
					{
						IntPtr intPtr = (IntPtr)assembly;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Reflection.Assembly>)+1B8]");
						assembly2 = (Assembly)0;
						string fullName = assembly.FullName;
						if (fullName != null)
						{
							if (fullName.StartsWith("Unity") || fullName.StartsWith("System") || fullName.StartsWith("Microsoft") || fullName.StartsWith("SyntaxTree") || fullName.StartsWith("Mono") || fullName.StartsWith("ExCSS") || fullName.StartsWith("nunit") || fullName.StartsWith("netstandard") || fullName.StartsWith("mscorlib"))
							{
								return false;
							}
							return fullName != "Accessibility";
						}
					}
					else
					{
						assembly2 = assembly;
					}
					NullReferenceException ex = new NullReferenceException();
					ex = (NullReferenceException)(object)assembly2;
					string className = default(string);
					((Exception)ex)._className = className;
					return (byte)(int)ex != 0;
				});
			}
			return ReflectionUtils.ListAssemblies(filter);
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x13D8020", Offset = "0x13D8020", Length = "0x554")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv40 = *([1EEAC10]);\n\tv41 = *([v40 @ X8_v85]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, type, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2028A6F]) = v59;\nL_0026:\n\tv67 = System.Type::GetFields(type, 0x38);\n\tv69 = v67 == 0;\n\tif (v69) goto L_01D2;\n\tv429 = v67.Length;\n\tv150 = v67.Length == 0;\n\tif (v150) goto L_01D2;\n\tv198 = v67.Length < 1;\n\tif (v198) goto L_01D2;\nL_0040:\n\tv430 = v99 < v429;\n\tv131 = ~v430;\n\tif (v131) goto L_0145;\n\tv283 = v67[v99 @ X25_v15 (System.Int32)];\n\tv490 = System.Reflection.FieldInfo::get_FieldType(v67[v99 @ X25_v15 (System.Int32)]);\n\tgoto L_0062;\n\tv546 = *([v492 @ X0_v76+E0]);\n\tv547 = v546 == 0;\n\tv548 = ~v547;\n\tif (v548) goto L_0062;\n\tv550 = \"il2cpp_codegen_runtime_class_init\"(v492, v487, v425, v44, v45, v46, v47, v48, v82, v80, v51, v52, v53, v54, v55, v56);\nL_0062:\n\tv555 = System.Type::GetTypeFromHandle(LunarConsolePlugin.CVar);\n\tv604 = System.Type::IsAssignableFrom(v490, v555);\n\tv606 = v604 == 0;\n\tif (v606) goto L_00DB;\n\tv610 = *([v283 @ X23_v17 (System.Reflection.FieldInfo)]);\n\tv614 = System.Reflection.FieldInfo::GetValue(v67[v99 @ X25_v15 (System.Int32)], 0);\n\tv616 = v614 == 0;\n\tif (v616) goto L_0098;\n\tgoto L_FFFFFFFF;\n\tv710 = v710_asT != 0;\n\tif (v710) goto L_00EB;\nL_0098:\n\t// 152 NewArr v719 @ X0_v86 (System.Object[]), typeof(System.Object[]), 2\n\tv315 = System.Reflection.MemberInfo::get_Name(type);\n\tv814 = v315 == 0;\n\tif (v814) goto L_00AB;\n\t// 167 IsInst v539 @ X0_v100, typeof(System.Object), v315 @ X0_v88 (System.String)\n\tv541 = v539 == 0;\n\tif (v541) goto L_0159;\nL_00AB:\n\tv400 = v719.Length == 0;\n\tif (v400) goto L_0151;\n\tv719[0] = v315;\n\tv865 = System.Reflection.MemberInfo::get_Name(v67[v99 @ X25_v15 (System.Int32)]);\n\tv866 = v865 == 0;\n\tif (v866) goto L_00BD;\n\t// 185 IsInst v593 @ X0_v98, typeof(System.Object), v865 @ X0_v91 (System.String)\n\tv595 = v593 == 0;\n\tif (v595) goto L_015D;\nL_00BD:\n\tv897 = v719.Length < 1;\n\tv465 = ~v897;\n\tv463 = v719.Length - 1;\n\tv459 = v463 == 0;\n\tv898 = ~v465;\n\tv449 = v898 | v459;\n\tif (v449) goto L_0155;\n\tv719[1] = v865;\n\tgoto L_00DA;\n\tv916 = *([v907 @ X0_v93+E0]);\n\tv917 = v916 == 0;\n\tv918 = ~v917;\n\tif (v918) goto L_00DA;\n\tv920 = \"il2cpp_codegen_runtime_class_init\"(v907, v467, v311, v44, v45, v46, v47, v48, v82, v80, v51, v52, v53, v54, v55, v56);\nL_00DA:\n\tLunarConsolePluginInternal.Log::w(\"Unable to register variable {0}.{0}\", v719);\nL_00DB:\n\tv429 = v67.Length;\n\tv99 = v99 + 1;\n\tv199 = v99 < v67.Length;\n\tif (v199) goto L_0040;\n\tgoto L_01D2;\nL_00EB:\n\tv49 = LunarConsolePlugin.LunarConsole::ResolveVariableRange(v67[v99 @ X25_v15 (System.Int32)]);\n\tv853 = 0x13D4BA8(&v49 @ V0 (LunarConsolePlugin.CVarValueRange), 0, *([v610 @ X8_v46 (Il2CppClass<System.Reflection.FieldInfo>)+268]), v44, v45, v46, v47, v48, v49, v49.max, v51, v52, v53, v54, v55, v56);\n\tv860 = v853 & 1;\n\tv861 = v860 == 0;\n\tif (v861) goto L_0143;\n\tv739 = v614.m_type != 2;\n\tif (v739) goto L_0107;\n\tv614.m_range = v49;\n\tv614.m_range.max = v49.max;\n\tgoto L_0143;\nL_0107:\n\t// 263 NewArr v904 @ X0_v107 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_0118;\n\tv925 = *([v911 @ X0_v108+E0]);\n\tv926 = v925 == 0;\n\tv927 = ~v926;\n\tif (v927) goto L_0118;\n\tv929 = \"il2cpp_codegen_runtime_class_init\"(v911, v903, v311, v44, v45, v46, v47, v48, v622, v621, v51, v52, v53, v54, v55, v56);\nL_0118:\n\tv762 = System.Type::GetTypeFromHandle(LunarConsolePlugin.CVarRangeAttribute);\n\tv805 = System.Reflection.MemberInfo::get_Name(v762);\n\tv952 = v805 == 0;\n\tif (v952) goto L_012B;\n\t// 295 IsInst v880 @ X0_v119, typeof(System.Object), v805 @ X0_v112 (System.String)\n\tv882 = v880 == 0;\n\tif (v882) goto L_0169;\nL_012B:\n\tv847 = v904.Length == 0;\n\tif (v847) goto L_0165;\n\tv904[0] = v805;\n\tgoto L_013E;\n\tv983 = *([v971 @ X0_v114+E0]);\n\tv984 = v983 == 0;\n\tv985 = ~v984;\n\tif (v985) goto L_013E;\n\tv987 = \"il2cpp_codegen_runtime_class_init\"(v971, v841, v311, v44, v45, v46, v47, v48, v622, v621, v51, v52, v53, v54, v55, v56);\nL_013E:\n\tLunarConsolePluginInternal.Log::w(\"'{0}' attribute is only available with 'float' variables\", v904);\nL_0143:\n\tLunarConsolePluginInternal.CRegistry::Register(this.m_registry, v614);\n\tgoto L_00DB;\nL_0145:\n\tv482 = new System.IndexOutOfRangeException();\n\tthrow v482;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv322 = new System.NullReferenceException();\nL_0151:\n\tv404 = new System.IndexOutOfRangeException();\n\tthrow v404;\nL_0155:\n\tv478 = new System.IndexOutOfRangeException();\n\tthrow v478;\nL_0159:\n\tv545 = new System.ArrayTypeMismatchException();\n\tthrow v545;\nL_015D:\n\tv599 = new System.ArrayTypeMismatchException();\n\tthrow v599;\n\tv691 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv812 = new System.NullReferenceException();\nL_0165:\n\tv851 = new System.IndexOutOfRangeException();\n\tthrow v851;\nL_0169:\n\tv886 = new System.ArrayTypeMismatchException();\n\tthrow v886;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_01E5;\n\tv933 = 0x6D2BC0(v901, 0, 0, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\tv248 = *([v933 @ X0_v11]);\n\tv947 = *([v248 @ X20_v6 (System.Exception)]);\n\tv949 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v947, 0, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\tv950 = v949 & 1;\n\tv951 = v950 == 0;\n\tif (v951) goto L_01D4;\n\tv953 = 0x6D2490(v949, v947, 0, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\tv963 = \"SzArrayNew\"(System.Object[], 1, 0, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\tv990 = type == 0;\n\tif (v990) goto L_01AD;\n\t// 426 IsInst v1005 @ X0_v33, typeof(System.Object), type @ X1 (System.Type)\nL_01AD:\n\tv999 = *([v963 @ X0_v26 (System.Object[])+18]);\n\tv997 = v999 == 0;\n\tif (v997) goto L_01DC;\n\t*([v963 @ X0_v26 (System.Object[])+20]) = type;\n\tgoto L_01C2;\n\tv1020 = *([v1011 @ X0_v28+E0]);\n\tv1021 = v1020 == 0;\n\tv1022 = ~v1021;\n\tif (v1022) goto L_01C2;\n\tv1024 = \"il2cpp_codegen_runtime_class_init\"(v1011, v992, v900, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\nL_01C2:\n\tLunarConsolePluginInternal.Log::e(v248, \"Unable to initialize cvar container: {0}\", v963, v44);\nL_01D2:\n\treturn;\nL_01D4:\n\tv955 = 0x6D1E60(8, v947, 0, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\tv964 = *([v933 @ X0_v11]);\n\t*([v955 @ X0_v22]) = v964;\n\tv966 = 0x1E8A000 + 0x870;\n\tv968 = 0x6D2A00(v955, v966, 0, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\tv982 = new System.NullReferenceException();\nL_01DC:\n\tv1001 = new System.IndexOutOfRangeException();\n\tgoto L_01E1;\n\tv1018 = new System.ArrayTypeMismatchException();\nL_01E1:\n\tthrow v1017;\nL_01E5:\n\tv943 = 0x6D2380(v361, v352, v354, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\tv357 = 0x846AA4(v943, v352, v354, v44, v45, v46, v47, v48, v167, v164, v51, v52, v53, v54, v55, v56);\n\treturn;\n// 298 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RegisterVariables(Type type)
		{
			//IL_0104: Expected I, but got O
			//IL_028b: Expected O, but got I4
			FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (fields == null)
			{
				return;
			}
			int num = fields.Length;
			if (fields.Length == 0 || fields.Length < 1)
			{
				return;
			}
			int num2 = 0;
			object obj = default(object);
			while (true)
			{
				if (num2 < num)
				{
					FieldInfo fieldInfo = fields[num2];
					Type fieldType = fields[num2].FieldType;
					Type typeFromHandle = typeof(CVar);
					if (fieldType.IsAssignableFrom(typeFromHandle))
					{
						IntPtr intPtr = (IntPtr)fieldInfo;
						CVar value = (CVar)fields[num2].GetValue(null);
						if (value != null)
						{
							CVar cVar = value as CVar;
							if (cVar != null)
							{
								CVarValueRange range = ResolveVariableRange(fields[num2]);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13D4BA8 (inside LunarConsolePlugin.CVar::get_HasRange +0x8)");
								if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
								{
									if (value.Type == CVarType.Float)
									{
										value.m_range = range;
										value.m_range.max = range.max;
									}
									else
									{
										object[] array = new object[1];
										Type typeFromHandle2 = typeof(CVarRangeAttribute);
										string text = typeFromHandle2.Name;
										if (text != null)
										{
											object obj2 = text as object;
											if (obj2 == null)
											{
												break;
											}
										}
										if (array.Length == 0)
										{
											IndexOutOfRangeException ex = new IndexOutOfRangeException();
											throw ex;
										}
										array[0] = text;
										Log.w("'{0}' attribute is only available with 'float' variables", array);
									}
								}
								registry.Register(value);
								goto IL_02ea;
							}
						}
						object[] array2 = new object[2];
						string text2 = type.Name;
						if (text2 != null)
						{
							object obj3 = text2 as object;
							if (obj3 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						if (array2.Length == 0)
						{
							IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
							throw ex3;
						}
						array2[0] = text2;
						string text3 = fields[num2].Name;
						if (text3 != null)
						{
							object obj4 = text3 as object;
							if (obj4 == null)
							{
								ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
								throw ex4;
							}
						}
						bool flag = array2.Length < 1;
						bool flag2 = !flag;
						object obj5 = array2.Length - 1;
						bool flag3 = obj5 == null;
						bool flag4 = !flag2;
						if (flag4 || flag3)
						{
							IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
							throw ex5;
						}
						array2[1] = text3;
						Log.w("Unable to register variable {0}.{0}", array2);
					}
					goto IL_02ea;
				}
				IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
				throw ex6;
				IL_02ea:
				num = fields.Length;
				num2++;
				if (num2 >= fields.Length)
				{
					return;
				}
			}
			ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
			throw ex7;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x13D873C", Offset = "0x13D873C", Length = "0x40C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv20 = *([1F073D8]);\n\tv21 = *([v20 @ X8_v78]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A70]) = v40;\nL_001E:\n\tgoto L_0026;\n\tv51 = *([v44 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tv60 = System.Type::GetTypeFromHandle(LunarConsolePlugin.CVarRangeAttribute);\n\tv63 = field->klass;\n\tv68 = System.Reflection.MemberInfo::GetCustomAttributes(field, v60, 1);\n\tv69 = v68 == 0;\n\tif (v69) goto L_004E;\n\tv73 = v68.Length == 0;\n\tif (v73) goto L_004E;\n\tv160 = v68.Length == 0;\n\tif (v160) goto L_00E2;\n\tv145 = v68[0];\n\tv140 = v68[0] == 0;\n\tif (v140) goto L_004E;\n\tv109 = *([v145 @ X8_v50 (System.Object)]) == LunarConsolePlugin.CVarRangeAttribute;\n\tif (v109) goto L_0061;\nL_004E:\n\tgoto L_0058;\n\tv163 = *([v151 @ X0_v68+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_0058;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v151, v135, v128, v130, v26, v27, v28, v29, v90, v88, v83, v81, v34, v35, v36, v37);\nL_0058:\n\treturnVal1 = v221.Undefined;\nL_0060:\n\treturn returnVal1;\nL_0061:\n\tv256 = *([v145 @ X8_v50 (System.Object)+10]);\n\tv179 = *([v145 @ X8_v50 (System.Object)+14]);\n\tv173 = *([v145 @ X8_v50 (System.Object)+14]) - *([v145 @ X8_v50 (System.Object)+10]);\n\tv229 = v173 >= 1E-05f;\n\tif (v229) goto L_0060;\n\t// 120 NewArr v378 @ X0_v73 (System.Object[]), typeof(System.Object[]), 3\n\tv293 = 0xBCCEC8(&v256 @ X9_v23 (LunarConsolePlugin.CVarValueRange), 0, 1, *([v63 @ X8_v48 (Il2CppClass<System.Reflection.FieldInfo>)+1E8]), v26, v27, v28, v29, *([v145 @ X8_v50 (System.Object)+10]), *([v145 @ X8_v50 (System.Object)+14]), 1E-05f, v173, v34, v35, v36, v37);\n\tv453 = v293 == 0;\n\tif (v453) goto L_0089;\n\t// 133 IsInst v460 @ X0_v94, typeof(System.Object), v293 @ X0_v75\n\tv462 = v460 == 0;\n\tif (v462) goto L_00F4;\nL_0089:\n\tv366 = v378.Length == 0;\n\tif (v366) goto L_00E8;\n\tv378[0] = v293;\n\tv492 = 0xBCCEC8(&v179 @ V1_v12, 0, 1, *([v63 @ X8_v48 (Il2CppClass<System.Reflection.FieldInfo>)+1E8]), v26, v27, v28, v29, *([v145 @ X8_v50 (System.Object)+10]), *([v145 @ X8_v50 (System.Object)+14]), 1E-05f, v173, v34, v35, v36, v37);\n\tv496 = v492 == 0;\n\tif (v496) goto L_0099;\n\t// 149 IsInst v520 @ X0_v92, typeof(System.Object), v492 @ X0_v78\n\tv522 = v520 == 0;\n\tif (v522) goto L_00F8;\nL_0099:\n\tv529 = v378.Length < 1;\n\tv404 = ~v529;\n\tv402 = v378.Length - 1;\n\tv398 = v402 == 0;\n\tv530 = ~v404;\n\tv382 = v530 | v398;\n\tif (v382) goto L_00EC;\n\tv378[1] = v492;\n\tv537 = System.Reflection.MemberInfo::get_Name(field);\n\tv538 = v537 == 0;\n\tif (v538) goto L_00B5;\n\t// 177 IsInst v554 @ X0_v90, typeof(System.Object), v537 @ X0_v81 (System.String)\n\tv556 = v554 == 0;\n\tif (v556) goto L_00FC;\nL_00B5:\n\tv563 = v378.Length < 2;\n\tv197 = ~v563;\n\tv195 = v378.Length - 2;\n\tv191 = v195 == 0;\n\tv564 = ~v197;\n\tv169 = v564 | v191;\n\tif (v169) goto L_00F0;\n\tv378[2] = v537;\n\tgoto L_00D2;\n\tv574 = *([v570 @ X0_v83+E0]);\n\tv575 = v574 == 0;\n\tv576 = ~v575;\n\tif (v576) goto L_00D2;\n\tv578 = \"il2cpp_codegen_runtime_class_init\"(v570, v444, v66, v65, v26, v27, v28, v29, v181, v179, v175, v173, v34, v35, v36, v37);\nL_00D2:\n\tLunarConsolePluginInternal.Log::w(\"Invalid range [{0}, {1}] for variable '{2}'\", v378);\n\tgoto L_0058;\n\tv215 = *([v207 @ X0_v86+E0]);\n\tv603 = v215 == 0;\n\tv211 = ~v603;\n\tif (v211) goto L_0058;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v207, v204, v66, v65, v26, v27, v28, v29, v181, v179, v175, v173, v34, v35, v36, v37);\n\tgoto L_0058;\n\tv71 = new System.NullReferenceException();\nL_00E2:\n\tv162 = new System.IndexOutOfRangeException();\n\tthrow v162;\n\tv300 = new System.NullReferenceException();\nL_00E8:\n\tv370 = new System.IndexOutOfRangeException();\n\tthrow v370;\nL_00EC:\n\tv418 = new System.IndexOutOfRangeException();\n\tthrow v418;\nL_00F0:\n\tv452 = new System.IndexOutOfRangeException();\n\tthrow v452;\nL_00F4:\n\tv489 = new System.ArrayTypeMismatchException();\n\tthrow v489;\nL_00F8:\n\tv526 = new System.ArrayTypeMismatchException();\n\tthrow v526;\nL_00FC:\n\tv560 = new System.ArrayTypeMismatchException();\n\tthrow v560;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_0164;\n\tv590 = 0x6D2BC0(v567, 0, 0, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\n\tv148 = *([v590 @ X0_v15 (System.Object[])]);\n\tv607 = *([v148 @ X20_v8 (System.Exception)]);\n\tv609 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v607, 0, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\n\tv610 = v609 & 1;\n\tv611 = v610 == 0;\n\tif (v611) goto L_0154;\n\tv612 = 0x6D2490(v609, v607, 0, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\n\tv632 = \"SzArrayNew\"(System.Object[], 1, 0, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\n\tv655 = System.Reflection.MemberInfo::get_Name(field, Il2CppMethodInfo);\n\tv659 = v655 == 0;\n\tif (v659) goto L_013A;\n\t// 311 IsInst v669 @ X0_v41, typeof(System.Object), v655 @ X0_v34 (System.String)\nL_013A:\n\tv650 = *([v632 @ X0_v29 (System.Object[])+18]);\n\tv647 = v650 == 0;\n\tif (v647) goto L_015B;\n\t*([v632 @ X0_v29 (System.Object[])+20]) = v655;\n\tgoto L_014F;\n\tv678 = *([v674 @ X0_v36+E0]);\n\tv679 = v678 == 0;\n\tv680 = ~v679;\n\tif (v680) goto L_014F;\n\tv682 = \"il2cpp_codegen_runtime_class_init\"(v674, v643, v566, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\nL_014F:\n\tLunarConsolePluginInternal.Log::e(v148, \"Exception while resolving variable's range: {0}\", v632, v131);\n\tgoto L_004E;\n\tthrow System.NullReferenceException;\nL_0154:\n\tv627 = 0x6D1E60(8, v616, 0, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\n\tv633 = *([v613 @ X21_v8 (System.Object[])]);\n\t*([v627 @ X0_v25]) = v633;\n\tv635 = 0x1E8A000 + 0x870;\n\tv637 = 0x6D2A00(v627, v635, 0, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\nL_015B:\n\tv651 = new System.IndexOutOfRangeException();\n\tgoto L_0160;\n\tv664 = new System.ArrayTypeMismatchException();\nL_0160:\n\tthrow v663;\nL_0164:\n\tv602 = 0x6D2380(v339, v329, v324, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\n\tv331 = 0x846AA4(v602, v329, v324, v131, v26, v27, v28, v29, returnVal2, v89, v84, v82, v34, v35, v36, v37);\n\treturn returnVal2;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static CVarValueRange ResolveVariableRange(FieldInfo field)
		{
			//IL_0020: Expected I, but got O
			//IL_0114: Expected O, but got I
			//IL_0124: Expected O, but got I
			//IL_0167: Expected O, but got I
			//IL_0287: Expected O, but got I4
			//IL_034e: Expected O, but got I4
			Type typeFromHandle = typeof(CVarRangeAttribute);
			IntPtr intPtr = (IntPtr)field;
			object[] customAttributes = field.GetCustomAttributes(typeFromHandle, inherit: true);
			CVarValueRange result;
			if (customAttributes != null && customAttributes.Length != 0)
			{
				if (customAttributes.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				object obj = customAttributes[0];
				if (customAttributes[0] != null && (object)obj.GetType() == typeof(CVarRangeAttribute))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X8_v50 (System.Object)+10]");
					CVarValueRange cVarValueRange = (CVarValueRange)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X8_v50 (System.Object)+14]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X8_v50 (System.Object)+14]");
					float num = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X8_v50 (System.Object)+10]");
					float num2 = num - 0f;
					bool flag = !(num2 < 1E-05f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X8_v50 (System.Object)+10]");
					result = (CVarValueRange)0;
					if (flag)
					{
						goto IL_0414;
					}
					object[] array = new object[3];
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
					object obj3 = default(object);
					if (obj3 != null)
					{
						object obj4 = obj3 as object;
						if (obj4 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					if (array.Length == 0)
					{
						IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
						throw ex3;
					}
					array[0] = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
					object obj5 = default(object);
					if (obj5 != null)
					{
						object obj6 = obj5 as object;
						if (obj6 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					bool flag2 = array.Length < 1;
					bool flag3 = !flag2;
					object obj7 = array.Length - 1;
					bool flag4 = obj7 == null;
					bool flag5 = !flag3;
					if (flag5 || flag4)
					{
						IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
						throw ex5;
					}
					array[1] = obj5;
					string text = field.Name;
					if (text != null)
					{
						object obj8 = text as object;
						if (obj8 == null)
						{
							ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
							throw ex6;
						}
					}
					bool flag6 = array.Length < 2;
					bool flag7 = !flag6;
					object obj9 = array.Length - 2;
					bool flag8 = obj9 == null;
					bool flag9 = !flag7;
					if (flag9 || flag8)
					{
						IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
						throw ex7;
					}
					array[2] = text;
					Log.w("Invalid range [{0}, {1}] for variable '{2}'", array);
				}
			}
			result = CVarValueRange.Undefined;
			goto IL_0414;
			IL_0414:
			return result;
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x13D8C30", Offset = "0x13D8C30", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF6410]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, var, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A71]) = v41;\nL_0015:\n\tv42 = this.m_platform;\n\tv45 = *([v42 @ X20_v2 (LunarConsolePlugin.LunarConsole+IPlatform)]);\n\tv46 = this.m_registry;\n\tv50 = *([v45 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]) == 0;\n\tif (v50) goto L_003D;\n\tv104 = *([v45 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]) + 8;\nL_0028:\n\tv110 = *([v104 @ X11_v5-8]) == LunarConsolePluginInternal.ICRegistryDelegate;\n\tif (v110) goto L_0040;\n\tv105 = v105 + 1;\n\tv169 = v105 < *([v45 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]);\n\tv84 = ~v169;\n\tv104 = v104 + 0x10;\n\tv60 = ~v84;\n\tif (v60) goto L_0028;\nL_003D:\n\tv176 = 0x8909C4(v42, LunarConsolePluginInternal.ICRegistryDelegate, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0044;\nL_0040:\n\tv171 = *([v104 @ X11_v5]) + 3;\n\tv172 = v171 << 4;\n\tv173 = v45 + v172;\n\tv176 = v173 + 0x130;\nL_0044:\n\tv120 = *([v176 @ X0_v4]);\n\tv118 = *([v176 @ X0_v4+8]);\n\t// 79 IndirectJump v120 @ X4_v1, v42 @ X20_v2 (LunarConsolePlugin.LunarConsole+IPlatform), v42 @ X20_v2 (LunarConsolePlugin.LunarConsole+IPlatform), v46 @ X21_v2 (LunarConsolePluginInternal.CRegistry), var @ X1 (LunarConsolePlugin.CVar), v118 @ X3_v1, v120 @ X4_v1, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateVariable(CVar var)
		{
			//IL_000d: Expected I, but got O
			//IL_0156: Expected O, but got I
			//IL_0052: Expected O, but got I
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00f1: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_009e: Expected O, but got I
			IPlatform platform = m_platform;
			IntPtr intPtr = (IntPtr)platform;
			CRegistry cRegistry = registry;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICRegistryDelegate))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b7;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_013e;
			IL_00b7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_013e;
			IL_013e:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v120 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x13D719C", Offset = "0x13D719C", Length = "0x570")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EF7B58]);\n\tv35 = *([v34 @ X8_v76]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2028A72]) = v54;\nL_001B:\n\tv55 = &v56 @ stack_-70;\n\tv59 = UnityEngine.Application::get_persistentDataPath();\n\tgoto L_0031;\n\tv67 = *([v63 @ X0_v4+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_0031;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0031:\n\tv79 = System.IO.Path::Combine(v59, \"lunar-mobile-console-variables.bin\");\n\tv83 = System.IO.File::Exists(v79);\n\tv85 = v83 == 0;\n\tif (v85) goto L_01B5;\n\tv88 = System.IO.File::OpenRead(v79);\n\tv199 = new System.IO.BinaryReader();\n\tSystem.IO.BinaryReader::.ctor(v199, v88);\n\tv286 = System.IO.BinaryReader::ReadInt32(v199);\n\tv298 = v286 < 1;\n\tif (v298) goto L_00DD;\nL_0061:\n\tv454 = System.IO.BinaryReader::ReadString(v199);\n\tv458 = System.IO.BinaryReader::ReadString(v199);\n\tv512 = LunarConsolePluginInternal.CRegistry::FindVariable(this.m_registry, v454);\n\tv595 = v512 == 0;\n\tif (v595) goto L_00A0;\n\tLunarConsolePlugin.CVar::set_Value(v512, v458);\n\tv597 = this.m_platform;\n\tv753 = *([v597 @ X24_v17 (LunarConsolePlugin.LunarConsole+IPlatform)]);\n\tv757 = *([v753 @ X8_v69 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]) == 0;\n\tif (v757) goto L_009A;\n\tv885 = *([v753 @ X8_v69 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]) + 8;\nL_0085:\n\tv899 = *([v885 @ X11_v28-8]) == LunarConsolePluginInternal.ICRegistryDelegate;\n\tif (v899) goto L_00C3;\n\tv884 = v884 + 1;\n\tv941 = v884 < *([v753 @ X8_v69 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]);\n\tv818 = ~v941;\n\tv885 = v885 + 0x10;\n\tv802 = ~v818;\n\tif (v802) goto L_0085;\nL_009A:\n\tv962 = 0x8909C4(v597, LunarConsolePluginInternal.ICRegistryDelegate, 3, v300, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00C8;\nL_00A0:\n\t// 160 NewArr v657 @ X0_v90 (System.Object[]), typeof(System.Object[]), 1\n\tv758 = v454 == 0;\n\tif (v758) goto L_00AD;\n\t// 169 IsInst v436 @ X0_v97, typeof(System.Object), v454 @ X0_v73 (System.String)\n\tv438 = v436 == 0;\n\tif (v438) goto L_00ED;\nL_00AD:\n\tv702 = v657.Length == 0;\n\tif (v702) goto L_00E7;\n\tv657[0] = v454;\n\tgoto L_00C0;\n\tv970 = *([v906 @ X0_v92+E0]);\n\tv971 = v970 == 0;\n\tv972 = ~v971;\n\tif (v972) goto L_00C0;\n\tv974 = \"il2cpp_codegen_runtime_class_init\"(v906, v699, v432, v300, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00C0:\n\tLunarConsolePluginInternal.Log::w(\"Variable '{0}' not registered. Ignoring...\", v657);\n\tgoto L_00CD;\nL_00C3:\n\tv943 = *([v885 @ X11_v28]) + 3;\n\tv944 = v943 << 4;\n\tv945 = v753 + v944;\n\tv962 = v945 + 0x130;\nL_00C8:\n\tv201 = *([v962 @ X0_v99+8]);\n\t*([v962 @ X0_v99])(v969, v597, this.m_registry, v512, *([v962 @ X0_v99+8]), v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00CD:\n\tv316 = v316 + 1;\n\tv374 = v316 < v286;\n\tif (v374) goto L_0061;\nL_00DD:\n\t*([v55 @ X26_v1]) = 0xA2;\n\tv406 = v199 == 0;\n\tv407 = ~v406;\n\tif (v407) goto L_011A;\n\tgoto L_0142;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv666 = new System.NullReferenceException();\nL_00E7:\n\tv704 = new System.IndexOutOfRangeException();\n\tthrow v704;\n\tv351 = new System.NullReferenceException();\nL_00ED:\n\tv441 = new System.ArrayTypeMismatchException();\n\tthrow v441;\n\tgoto L_010C;\n\tgoto L_010C;\n\tgoto L_010C;\n\tgoto L_010C;\n\tgoto L_01BC;\n\tgoto L_01BC;\n\tgoto L_01D3;\n\tgoto L_01D3;\n\tgoto L_01D3;\n\tgoto L_010C;\n\tgoto L_010C;\n\tgoto L_010C;\n\tgoto L_010C;\n\tgoto L_010C;\n\tgoto L_010C;\nL_010C:\n\tif (1) goto L_FFFFFFFF;\n\tv696 = 0x6D2BC0(v510, 0, 0, v408, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv501 = *([v696 @ X0_v63]);\n\tv497 = 0x6D2490(v696, 0, 0, v408, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv499 = v199 == 0;\n\tif (v499) goto L_0142;\nL_011A:\n\tgoto L_0141;\n\tv564 = *([v505 @ X8_v41+B0]);\n\tv565 = 0;\n\tv566 = v564 + 8;\n\tv568 = *([v632 @ X11_v17-8]);\n\tv646 = v568 == v508;\n\tif (v646) goto L_013A;\n\tv570 = v631 + 1;\n\tv687 = v570 < v507;\n\tv590 = ~v687;\n\tv572 = v632 + 0x10;\n\tv574 = ~v590;\n\tif (v574) goto L_FFFFFFFF;\n\tv591 = v162;\n\tv592 = 0;\n\tv593 = 0x8909C4(v591, v508, v592, v461, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0141;\nL_013A:\n\tv688 = *([v632 @ X11_v17]);\n\tv689 = v688 << 4;\n\tv690 = v505 + v689;\n\tv691 = v690 + 0x130;\nL_0141:\n\tSystem.IDisposable::Dispose(v199);\nL_0142:\n\tv559 = v157 + 1;\n\tv561 = v559 == 0;\n\tif (v561) goto L_0156;\n\tv617 = *([v55 @ X26_v1+v157 @ X22_v5 (System.Int32)*4]) != 0xA2;\n\tif (v617) goto L_0156;\n\tgoto L_015A;\nL_0156:\n\tv628 = v176 == 0;\n\tv629 = ~v628;\n\tif (v629) goto L_01B9;\nL_015A:\n\tv157 = v157 + 1;\n\t*([v55 @ X26_v1+v157 @ X22_v5 (System.Int32)*4]) = 0xAE;\nL_015D:\n\tv738 = v88 == 0;\n\tif (v738) goto L_018D;\n\tgoto L_018C;\n\tv825 = *([v760 @ X8_v29+B0]);\n\tv826 = 0;\n\tv827 = v825 + 8;\n\tv829 = *([v912 @ X11_v9-8]);\n\tv926 = v829 == v763;\n\tif (v926) goto L_0185;\n\tv831 = v911 + 1;\n\tv981 = v831 < v762;\n\tv851 = ~v981;\n\tv833 = v912 + 0x10;\n\tv835 = ~v851;\n\tif (v835) goto L_FFFFFFFF;\n\tv852 = v182;\n\tv853 = 0;\n\tv854 = 0x8909C4(v852, v763, v853, v90, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_018C;\nL_0185:\n\tv982 = *([v912 @ X11_v9]);\n\tv983 = v982 << 4;\n\tv984 = v760 + v983;\n\tv985 = v984 + 0x130;\nL_018C:\n\tSystem.IDisposable::Dispose(v88);\nL_018D:\n\tv788 = v157 + 1;\n\tv139 = v788 == 0;\n\tif (v139) goto L_01A4;\n\tv174 = v176 == 0;\n\tif (v174) goto L_01B5;\n\tv140 = *([v55 @ X26_v1+v157 @ X22_v5 (System.Int32)*4]) == 0xAE;\n\tif (v140) goto L_01B5;\nL_01A3:\n\tthrow System.TypeLoadException;\nL_01A4:\n\tv869 = v176 == 0;\n\tv173 = ~v869;\n\tif (v173) goto L_01A3;\nL_01B5:\n\treturn;\nL_01B9:\n\tv686 = new System.TypeLoadException();\n\tgoto L_FFFFFFFF;\n\tgoto L_01D3;\nL_01BC:\n\tX8 = X1;\n\tX21 = X0;\nL_01C8:\n\tv710 = 0 != 1;\n\tif (v710) goto L_01DE;\n\tv790 = 0x6D2BC0(v269, v260, v257, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv176 = *([v790 @ X0_v35]);\n\tv732 = 0x6D2490(v790, v260, v257, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_015D;\n\tgoto L_01C8;\n\tgoto L_01D3;\nL_01D3:\n\tX8 = X1;\n\tX21 = X0;\nL_01DE:\n\tv230 = 0 != 1;\n\tif (v230) goto L_0218;\n\tv871 = 0x6D2BC0(v686, 0, 0, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv880 = *([v871 @ X0_v22]);\n\tv940 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v880 @ X19_v8 (System.Exception)]), 0, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv989 = v940 & 1;\n\tv877 = v989 == 0;\n\tif (v877) goto L_020E;\n\tv1001 = 0x6D2490(v940, *([v880 @ X19_v8 (System.Exception)]), v257, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_020B;\n\tv1012 = *([v1006 @ X0_v30+E0]);\n\tv1013 = v1012 == 0;\n\tv1014 = ~v1013;\n\tif (v1014) goto L_020B;\n\tv1016 = \"il2cpp_codegen_runtime_class_init\"(v1006, v938, v256, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_020B:\n\tLunarConsolePluginInternal.Log::e(v880, \"Error while loading variables\");\n\treturn;\nL_020E:\n\tv1003 = 0x6D1E60(8, *([v880 @ X19_v8 (System.Exception)]), 0, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([v1003 @ X0_v26]) = *([v871 @ X0_v22]);\n\tv260 = 0x1E8A000 + 0x870;\n\tv1011 = 0x6D2A00(v1003, v260, 0, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv876 = 0x6D2490(v1011, v260, 0, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0218:\n\tv882 = 0x6D2380(v269, v260, v257, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv263 = 0x846AA4(v882, v260, v257, v201, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\treturn;\n// 325 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LoadVariables()
		{
			//IL_02a2: Expected O, but got I4
			//IL_0100: Expected I, but got O
			//IL_0579: Expected O, but got I
			//IL_013b: Expected O, but got I
			//IL_0421: Expected I4, but got O
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_0285: Expected O, but got I
			//IL_0294: Expected O, but got I
			//IL_0187: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			string persistentDataPath = Application.persistentDataPath;
			string path = Path.Combine(persistentDataPath, "lunar-mobile-console-variables.bin");
			if (!File.Exists(path))
			{
				return;
			}
			FileStream fileStream = File.OpenRead(path);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			int num = binaryReader.ReadInt32();
			if (num >= 1)
			{
				object obj4 = default(object);
				object obj3 = obj4;
				int num2 = 0;
				bool flag3;
				do
				{
					string text = binaryReader.ReadString();
					string value = binaryReader.ReadString();
					CVar cVar = registry.FindVariable(text);
					if (cVar != null)
					{
						cVar.Value = value;
						IPlatform platform = m_platform;
						IntPtr intPtr = (IntPtr)platform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ X8_v69 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_01a0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ X8_v69 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]");
						object obj5 = 0L + 8L;
						int num3 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ X11_v28-8]");
							if ((IntPtr)0 == (IntPtr)typeof(ICRegistryDelegate))
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ X8_v69 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
							bool flag = (long)num4 < 0L;
							bool flag2 = !flag;
							obj5 = (long)(IntPtr)obj5 + 16L;
							if (!flag2)
							{
								continue;
							}
							goto IL_01a0;
						}
						object obj6 = obj5 + 3;
						int num5 = (int)((long)(IntPtr)obj6 << 4);
						object obj7 = (long)intPtr + (long)num5;
						object obj8 = (long)(IntPtr)obj7 + 304L;
						goto IL_0569;
					}
					object[] array = new object[1];
					if (text != null)
					{
						object obj9 = text as object;
						if (obj9 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					if (array.Length != 0)
					{
						array[0] = text;
						Log.w("Variable '{0}' not registered. Ignoring...", array);
						obj4 = obj3;
						goto IL_0589;
					}
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
					IL_0589:
					num2++;
					flag3 = num2 < num;
					obj3 = obj4;
					continue;
					IL_0569:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v962 @ X0_v99+8]");
					obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v962 @ X0_v99] (should have been resolved before IL gen)");
					goto IL_0589;
					IL_01a0:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0569;
				}
				while (flag3);
			}
			obj = 162;
			bool flag4 = binaryReader == null;
			bool flag5 = !flag4;
			int num6 = 0;
			int num7 = 0;
			if (!flag5)
			{
				num6 = 0;
				num7 = 0;
			}
			else
			{
				((IDisposable)binaryReader).Dispose();
			}
			if (num6 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v157 @ X22_v5 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)162)
				{
					num6 = -1;
					goto IL_0372;
				}
			}
			if (num7 == 0)
			{
				goto IL_0372;
			}
			TypeLoadException ex3 = new TypeLoadException();
			int num8 = 0;
			int num9 = 0;
			TypeLoadException ex4 = ex3;
			if (0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj10 = default(object);
				num7 = (int)obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				goto IL_062d;
			}
			if (0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj11 = default(object);
				Exception exception = (Exception)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj12 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj12 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Log.e(exception, "Error while loading variables");
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj13 = obj11;
				num9 = 32022528 + 2160;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num8 = 0;
				TypeLoadException ex5 = default(TypeLoadException);
				ex4 = ex5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			return;
			IL_0372:
			num6++;
			_ = 174;
			goto IL_062d;
			IL_062d:
			((IDisposable)fileStream)?.Dispose();
			if (num6 + 1 != 0)
			{
				if (num7 == 0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v157 @ X22_v5 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)174)
				{
					return;
				}
			}
			else if (num7 == 0)
			{
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x13D5E74", Offset = "0x13D5E74", Length = "0x808")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1F0A0A8]);\n\tv33 = *([v32 @ X8_v102]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2028A73]) = v52;\nL_001A:\n\tv53 = &v54 @ stack_-80;\n\tv57 = UnityEngine.Application::get_persistentDataPath();\n\tgoto L_0030;\n\tv65 = *([v61 @ X0_v4+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0030;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0030:\n\tv77 = System.IO.Path::Combine(v57, \"lunar-mobile-console-variables.bin\");\n\tv79 = System.IO.File::OpenWrite(v77);\n\tv84 = new System.IO.BinaryWriter();\n\tSystem.IO.BinaryWriter::.ctor(v84, v79);\n\tv89 = this.m_registry;\n\tv420 = v89.m_vars;\n\tv96 = LunarConsolePlugin.CVarList::GetEnumerator(v89.m_vars);\n\tv103 = v96 == 0;\n\tif (v103) goto L_00BB;\n\tgoto L_0082;\nL_0052:\n\tgoto L_0079;\n\tv494 = *([v400 @ X8_v93+B0]);\n\tv495 = 0;\n\tv496 = v494 + 8;\n\tv498 = *([v611 @ X11_v57-8]);\n\tv616 = v498 == v401;\n\tif (v616) goto L_0072;\n\tv518 = v610 + 1;\n\tv797 = v518 < v402;\n\tv516 = ~v797;\n\tv520 = v611 + 0x10;\n\tv500 = ~v516;\n\tif (v500) goto L_FFFFFFFF;\n\tv521 = v102;\n\tv522 = 0;\n\tv523 = 0x8909C4(v521, v401, v522, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0079;\nL_0072:\n\tv798 = *([v611 @ X11_v57]);\n\tv799 = v798 << 4;\n\tv800 = v400 + v799;\n\tv801 = v800 + 0x130;\nL_0079:\n\tv807 = System.Collections.Generic.IEnumerator`1<LunarConsolePlugin.CVar>::get_Current(v96);\n\tv167 = LunarConsolePlugin.LunarConsole::ShouldSaveVar(v807, v807);\n\tv417 = v417 + v167;\nL_0082:\n\tgoto L_00A9;\n\tv186 = *([v172 @ X8_v89+B0]);\n\tv187 = 0;\n\tv188 = v186 + 8;\n\tv190 = *([v230 @ X11_v62-8]);\n\tv235 = v190 == v173;\n\tif (v235) goto L_00A2;\n\tv210 = v229 + 1;\n\tv303 = v210 < v174;\n\tv208 = ~v303;\n\tv212 = v230 + 0x10;\n\tv192 = ~v208;\n\tif (v192) goto L_FFFFFFFF;\n\tv213 = v102;\n\tv214 = 0;\n\tv215 = 0x8909C4(v213, v173, v214, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00A9;\nL_00A2:\n\tv304 = *([v230 @ X11_v62]);\n\tv305 = v304 << 4;\n\tv306 = v172 + v305;\n\tv307 = v306 + 0x130;\nL_00A9:\n\tv328 = System.Collections.IEnumerator::MoveNext(v96);\n\tv330 = v328 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_0052;\n\t*([v53 @ X25_v1]) = 0x62;\n\tv398 = v96 == 0;\n\tv399 = ~v398;\n\tif (v399) goto L_00E7;\n\tgoto L_0111;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00BB:\n\tv109 = new System.NullReferenceException();\n\tgoto L_00D8;\n\tgoto L_00C1;\nL_00C1:\n\tX8 = X1;\n\tX21 = X0;\n\tgoto L_FFFFFFFF;\n\tgoto L_00C5;\nL_00C5:\n\tX8 = X1;\n\tX21 = X0;\n\tX26 = 0xFFFFFFFF;\n\tgoto L_02F6;\n\tgoto L_02FE;\n\tgoto L_02FE;\n\tgoto L_00CD;\n\tgoto L_00CD;\nL_00CD:\n\tX8 = X1;\n\tX21 = X0;\nL_00D8:\n\tv185 = v79 != 1;\n\tif (v185) goto L_FFFFFFFF;\n\tv217 = 0x6D2BC0(v109, v79, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv425 = *([v217 @ X0_v115]);\n\tv242 = 0x6D2490(v217, v79, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv332 = v419 == 0;\n\tif (v332) goto L_0111;\nL_00E7:\n\tgoto L_0110;\n\tv524 = *([v428 @ X8_v83+B0]);\n\tv525 = 0;\n\tv526 = v524 + 8;\n\tv528 = *([v632 @ X11_v49-8]);\n\tv637 = v528 == v431;\n\tif (v637) goto L_0109;\n\tv548 = v631 + 1;\n\tv808 = v548 < v430;\n\tv546 = ~v808;\n\tv550 = v632 + 0x10;\n\tv530 = ~v546;\n\tif (v530) goto L_FFFFFFFF;\n\tv551 = v419;\n\tv552 = 0;\n\tv553 = 0x8909C4(v551, v431, v552, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0110;\n\tgoto L_023A;\nL_0109:\n\tv809 = *([v632 @ X11_v49]);\n\tv810 = v809 << 4;\n\tv811 = v428 + v810;\n\tv812 = v811 + 0x130;\nL_0110:\n\tSystem.IDisposable::Dispose(v96);\nL_0111:\n\tv475 = v950 + 1;\n\tv477 = v475 == 0;\n\tif (v477) goto L_0128;\n\tv564 = *([v53 @ X25_v1+v950 @ X26_v1 (System.Int32)*4]) != 0x62;\n\tif (v564) goto L_0128;\n\tv643 = v84 == 0;\n\tv644 = ~v643;\n\tif (v644) goto L_0132;\n\tgoto L_01B7;\nL_0128:\n\tv575 = v744 == 0;\n\tv576 = ~v575;\n\tif (v576) goto L_01BD;\nL_0132:\n\tv833 = System.IO.BinaryWriter::Write(v84, v461);\n\tv835 = LunarConsolePlugin.CVarList::GetEnumerator(v464);\nL_0140:\n\tgoto L_0167;\n\tv1281 = *([v1233 @ X8_v52+B0]);\n\tv1282 = 0;\n\tv1283 = v1281 + 8;\n\tv1285 = *([v1330 @ X11_v35-8]);\n\tv1335 = v1285 == v1234;\n\tif (v1335) goto L_0160;\n\tv1305 = v1329 + 1;\n\tv1340 = v1305 < v1235;\n\tv1303 = ~v1340;\n\tv1307 = v1330 + 0x10;\n\tv1287 = ~v1303;\n\tif (v1287) goto L_FFFFFFFF;\n\tv1308 = v735;\n\tv1309 = 0;\n\tv1310 = 0x8909C4(v1308, v1234, v1309, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0167;\nL_0160:\n\tv1341 = *([v1330 @ X11_v35]);\n\tv1342 = v1341 << 4;\n\tv1343 = v1233 + v1342;\n\tv1344 = v1343 + 0x130;\nL_0167:\n\tv1365 = System.Collections.IEnumerator::MoveNext(v835);\n\tv1367 = v1365 == 0;\n\tif (v1367) goto L_01AD;\n\tgoto L_0196;\n\tv1376 = *([v1368 @ X8_v68+B0]);\n\tv1377 = 0;\n\tv1378 = v1376 + 8;\n\tv1380 = *([v1423 @ X11_v30-8]);\n\tv1428 = v1380 == v1369;\n\tif (v1428) goto L_018F;\n\tv1400 = v1422 + 1;\n\tv1497 = v1400 < v1370;\n\tv1398 = ~v1497;\n\tv1402 = v1423 + 0x10;\n\tv1382 = ~v1398;\n\tif (v1382) goto L_FFFFFFFF;\n\tv1403 = v735;\n\tv1404 = 0;\n\tv1405 = 0x8909C4(v1403, v1369, v1404, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0196;\nL_018F:\n\tv1498 = *([v1423 @ X11_v30]);\n\tv1499 = v1498 << 4;\n\tv1500 = v1368 + v1499;\n\tv1501 = v1500 + 0x130;\nL_0196:\n\tv1506 = System.Collections.Generic.IEnumerator`1<LunarConsolePlugin.CVar>::get_Current(v835);\n\tv1227 = LunarConsolePlugin.LunarConsole::ShouldSaveVar(v1506, v1506);\n\tv1230 = v1227 == 0;\n\tif (v1230) goto L_0140;\n\tv1562 = System.IO.BinaryWriter::Write(v84, v1506.m_name);\n\tv1228 = System.IO.BinaryWriter::Write(v84, v1506.m_value);\n\tgoto L_0140;\nL_01AD:\n\tv950 = v950 + 1;\n\t*([v53 @ X25_v1+v950 @ X26_v1 (System.Int32)*4]) = 0xB7;\n\tv1374 = v835 == 0;\n\tv1375 = ~v1374;\n\tif (v1375) goto L_01E1;\n\tgoto L_0209;\n\tthrow System.NullReferenceException;\nL_01B7:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_01BD:\n\tv286 = new System.TypeLoadException();\n\tgoto L_FFFFFFFF;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\nL_01C8:\n\tX8 = X1;\n\tX21 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_023A;\n\tX0 = X21;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0209;\nL_01E1:\n\tgoto L_0208;\n\tv1467 = *([v1407 @ X8_v64+B0]);\n\tv1468 = 0;\n\tv1469 = v1467 + 8;\n\tv1471 = *([v1530 @ X11_v24-8]);\n\tv1535 = v1471 == v1410;\n\tif (v1535) goto L_0201;\n\tv1491 = v1529 + 1;\n\tv1549 = v1491 < v1409;\n\tv1489 = ~v1549;\n\tv1493 = v1530 + 0x10;\n\tv1473 = ~v1489;\n\tif (v1473) goto L_FFFFFFFF;\n\tv1494 = v735;\n\tv1495 = 0;\n\tv1496 = 0x8909C4(v1494, v1410, v1495, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0208;\nL_0201:\n\tv1550 = *([v1530 @ X11_v24]);\n\tv1551 = v1550 << 4;\n\tv1552 = v1407 + v1551;\n\tv1553 = v1552 + 0x130;\nL_0208:\n\tSystem.IDisposable::Dispose(v835);\nL_0209:\n\tv1462 = v950 + 1;\n\tv1464 = v1462 == 0;\n\tif (v1464) goto L_021F;\n\tv1517 = *([v53 @ X25_v1+v950 @ X26_v1 (System.Int32)*4]) != 0xB7;\n\tif (v1517) goto L_021F;\n\tv1542 = 0xFFFFFFFF ^ v950;\n\tv950 = v950 + v1542;\n\tgoto L_0222;\nL_021F:\n\tv1518 = v744 == 0;\n\tv980 = ~v1518;\n\tif (v980) goto L_022C;\nL_0222:\n\tv950 = v950 + 1;\n\t*([v53 @ X25_v1+v950 @ X26_v1 (System.Int32)*4]) = 0xC3;\n\tv1547 = v84 == 0;\n\tv743 = ~v1547;\n\tif (v743) goto L_0248;\n\tgoto L_0270;\nL_022C:\n\tv286 = new System.TypeLoadException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_023A:\n\tv302 = v383 != 1;\n\tif (v302) goto L_02F6;\n\tv334 = 0x6D2BC0(v592, v586, v584, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv744 = *([v334 @ X0_v30]);\n\tv481 = 0x6D2490(v334, v586, v584, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv577 = v84 == 0;\n\tif (v577) goto L_0270;\nL_0248:\n\tgoto L_026F;\n\tv882 = *([v748 @ X8_v78+B0]);\n\tv883 = 0;\n\tv884 = v882 + 8;\n\tv886 = *([v994 @ X11_v42-8]);\n\tv999 = v886 == v751;\n\tif (v999) goto L_0268;\n\tv906 = v993 + 1;\n\n// ... truncated")]
		private void SaveVariables()
		{
			//IL_0129: Expected I4, but got O
			//IL_017b: Expected I4, but got O
			//IL_0400: Expected I4, but got O
			//IL_00a8: Expected O, but got I4
			//IL_058c: Expected I4, but got O
			//IL_042e: Expected I4, but got O
			//IL_062c: Expected O, but got I4
			//IL_047b: Expected I4, but got I8
			//IL_0332: Expected I4, but got I8
			object obj2 = default(object);
			object obj = obj2;
			string persistentDataPath = Application.persistentDataPath;
			string path = Path.Combine(persistentDataPath, "lunar-mobile-console-variables.bin");
			FileStream fileStream = File.OpenWrite(path);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			CRegistry cRegistry = registry;
			CVarList cVarList = cRegistry.cvars;
			IEnumerator<CVar> enumerator = cRegistry.cvars.GetEnumerator();
			int num;
			int num2;
			int num3;
			int value;
			int num4;
			CVarList cVarList2 = default(CVarList);
			int num5;
			Stream stream2;
			Stream stream;
			NullReferenceException ex2;
			int num6;
			if (enumerator != null)
			{
				num = 0;
				while (enumerator.MoveNext())
				{
					CVar current = enumerator.Current;
					bool flag = ((LunarConsole)(object)current).ShouldSaveVar(current);
					num += (flag ? 1 : 0);
				}
				obj = 98;
				bool flag2 = enumerator == null;
				bool flag3 = !flag2;
				num2 = 0;
				num3 = 0;
				if (!flag3)
				{
					value = num;
					num4 = 0;
					cVarList2 = cVarList;
					num5 = 0;
					goto IL_06f5;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)fileStream != (IntPtr)1)
				{
					num4 = -1;
					num6 = 0;
					stream = fileStream;
					ex2 = ex;
					stream2 = fileStream;
					goto IL_078e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				num3 = (int)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator<CVar> enumerator2 = default(IEnumerator<CVar>);
				bool flag4 = enumerator2 == null;
				num = 0;
				num2 = -1;
				cVarList = cVarList2;
				value = 0;
				num4 = -1;
				num5 = (int)obj3;
				if (flag4)
				{
					goto IL_06f5;
				}
			}
			enumerator.Dispose();
			value = num;
			num4 = num2;
			cVarList2 = cVarList;
			num5 = num3;
			goto IL_06f5;
			IL_03d9:
			TypeLoadException ex3;
			ex2 = (NullReferenceException)(object)ex3;
			stream2 = stream;
			goto IL_078e;
			IL_036c:
			num4++;
			_ = 195;
			int num7;
			int num8;
			if (binaryWriter == null)
			{
				num7 = num4;
				num8 = num5;
				goto IL_0851;
			}
			goto IL_087c;
			IL_08d3:
			((IDisposable)fileStream)?.Dispose();
			if (num4 + 1 != 0)
			{
				if (num8 == 0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X25_v1+v950 @ X26_v1 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)207)
				{
					return;
				}
			}
			else if (num8 == 0)
			{
				return;
			}
			throw new TypeLoadException();
			IL_0851:
			if (num7 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X25_v1+v1007 @ X26_v4 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)195)
				{
					int num9 = (int)(0xFFFFFFFFL ^ num7);
					num7 += num9;
					goto IL_04b5;
				}
			}
			if (num8 == 0)
			{
				goto IL_04b5;
			}
			TypeLoadException ex4 = new TypeLoadException();
			num4 = num7;
			num6 = 0;
			stream = null;
			ex2 = (NullReferenceException)(object)ex4;
			stream2 = null;
			goto IL_0740;
			IL_087c:
			((IDisposable)binaryWriter).Dispose();
			num7 = num4;
			num8 = num5;
			goto IL_0851;
			IL_04b5:
			num4 = num7 + 1;
			_ = 207;
			goto IL_08d3;
			IL_0243:
			binaryWriter.Write(value);
			IEnumerator<CVar> enumerator3 = cVarList2.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				CVar current2 = enumerator3.Current;
				if (((LunarConsole)(object)current2).ShouldSaveVar(current2))
				{
					binaryWriter.Write(current2.Name);
					binaryWriter.Write((string)current2.m_value);
				}
			}
			num4++;
			_ = 183;
			enumerator3?.Dispose();
			if (num4 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X25_v1+v950 @ X26_v1 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)183)
				{
					int num10 = (int)(0xFFFFFFFFL ^ num4);
					num4 += num10;
					goto IL_036c;
				}
			}
			if (num5 == 0)
			{
				goto IL_036c;
			}
			ex3 = new TypeLoadException();
			num6 = 0;
			stream = null;
			goto IL_03d9;
			IL_0740:
			if ((IntPtr)stream2 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj4 = default(object);
				num8 = (int)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				goto IL_08d3;
			}
			if ((IntPtr)stream2 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj5 = default(object);
				Exception exception = (Exception)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj6 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Log.e(exception, "Error while saving variables");
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj7 = obj5;
				stream = (Stream)(32022528 + 2160);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num6 = 0;
				NullReferenceException ex5 = default(NullReferenceException);
				ex2 = ex5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			return;
			IL_078e:
			if ((IntPtr)stream2 != (IntPtr)1)
			{
				goto IL_0740;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj8 = default(object);
			num5 = (int)obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			bool flag5 = binaryWriter == null;
			num7 = num4;
			num8 = (int)obj8;
			if (flag5)
			{
				goto IL_0851;
			}
			goto IL_087c;
			IL_06f5:
			if (num4 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X25_v1+v950 @ X26_v1 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)98)
				{
					bool flag6 = binaryWriter == null;
					bool flag7 = !flag6;
					num4 = -1;
					if (!flag7)
					{
						throw new NullReferenceException();
					}
					goto IL_0243;
				}
			}
			if (num5 == 0)
			{
				goto IL_0243;
			}
			ex3 = new TypeLoadException();
			num6 = 0;
			stream = null;
			goto IL_03d9;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x13D8D18", Offset = "0x13D8D18", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = LunarConsolePlugin.CVar::get_IsDefault(cvar);\n\tv30 = v12 == 0;\n\tif (v30) goto L_0010;\n\tgoto L_001A;\nL_0010:\n\tv33 = cvar.m_flags & 4;\n\tv35 = v33 == 0;\nL_001A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool ShouldSaveVar(CVar cvar)
		{
			if (cvar.IsDefault)
			{
				return false;
			}
			int num = (int)(cvar.Flags & CFlags.NoArchive);
			return num == 0;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x13D8D60", Offset = "0x13D8D60", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EA9630]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, message, stackTrace, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028A74]) = v47;\nL_0019:\n\tv48 = this.m_settings;\n\tv51 = ~v48.removeRichTextTags;\n\tif (v51) goto L_002E;\n\tgoto L_002C;\n\tv75 = *([v66 @ X0_v11+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_002C;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v66, message, stackTrace, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002C:\n\tv70 = LunarConsolePluginInternal.StringUtils::RemoveRichTextTags(message);\nL_002E:\n\tv57 = this.m_platform;\n\tv82 = *([v57 @ X22_v3 (LunarConsolePlugin.LunarConsole+IPlatform)]);\n\tv86 = *([v82 @ X8_v7 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]) == 0;\n\tif (v86) goto L_0055;\n\tv198 = *([v82 @ X8_v7 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]) + 8;\nL_0040:\n\tv204 = *([v198 @ X11_v5-8]) == LunarConsolePlugin.LunarConsole+IPlatform;\n\tif (v204) goto L_0058;\n\tv199 = v199 + 1;\n\tv209 = v199 < *([v82 @ X8_v7 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]);\n\tv180 = ~v209;\n\tv198 = v198 + 0x10;\n\tv164 = ~v180;\n\tif (v164) goto L_0040;\nL_0055:\n\tv216 = 0x8909C4(v57, LunarConsolePlugin.LunarConsole+IPlatform, 1, type, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_005C;\nL_0058:\n\tv211 = *([v198 @ X11_v5]) + 1;\n\tv212 = v211 << 4;\n\tv213 = v82 + v212;\n\tv216 = v213 + 0x130;\nL_005C:\n\tv94 = *([v216 @ X0_v6]);\n\tv92 = *([v216 @ X0_v6+8]);\n\t// 106 IndirectJump v94 @ X5_v1, v57 @ X22_v3 (LunarConsolePlugin.LunarConsole+IPlatform), v57 @ X22_v3 (LunarConsolePlugin.LunarConsole+IPlatform), v59 @ X21_v3 (System.String), stackTrace @ X2 (System.String), type @ X3 (UnityEngine.LogType), v92 @ X4_v1, v94 @ X5_v1, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnLogMessageReceived(string message, string stackTrace, LogType type)
		{
			//IL_0042: Expected I, but got O
			//IL_0190: Expected O, but got I
			//IL_007d: Expected O, but got I
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			//IL_011c: Expected O, but got I
			//IL_012b: Expected O, but got I
			//IL_00c9: Expected O, but got I
			LunarConsoleSettings settings = m_settings;
			if (settings.removeRichTextTags)
			{
				string text = StringUtils.RemoveRichTextTags(message);
			}
			IPlatform platform = m_platform;
			IntPtr intPtr = (IntPtr)platform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v7 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v7 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IPlatform))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v7 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e2;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0178;
			IL_0178:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X5_v1 (should have been resolved before IL gen)");
			return;
			IL_00e2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0178;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x13D8F0C", Offset = "0x13D8F0C", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EA9090]);\n\tv23 = *([v22 @ X8_v52]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, param, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A75]) = v41;\nL_001C:\n\tgoto L_0023;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0023;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, param, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = LunarConsolePluginInternal.StringUtils::DeserializeString(param);\n\tgoto L_0058;\n\tv152 = *([v61 @ X8_v13+B0]);\n\tv153 = 0;\n\tv154 = v152 + 8;\n\tv156 = *([v223 @ X11_v18-8]);\n\tv229 = v156 == v64;\n\tif (v229) goto L_0050;\n\tv178 = v224 + 1;\n\tv239 = v178 < v66;\n\tv174 = ~v239;\n\tv176 = v223 + 0x10;\n\tv158 = ~v174;\n\tif (v158) goto L_FFFFFFFF;\n\tv179 = v58;\n\tv180 = 0;\n\tv181 = 0x8909C4(v179, v64, v180, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0058;\nL_0050:\n\tv240 = *([v223 @ X11_v18]);\n\tv241 = v240 << 4;\n\tv242 = v61 + v241;\n\tv243 = v242 + 0x130;\nL_0058:\n\tv249 = System.Collections.Generic.IDictionary`2<System.String, System.String>::get_Item(v57, \"name\");\n\tv250 = System.String::IsNullOrEmpty(v249);\n\tv281 = v250 == 0;\n\tif (v281) goto L_0070;\n\tgoto L_FFFFFFFF;\n\tv320 = *([v284 @ X0_v58+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_FFFFFFFF;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v284, v125, v82, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00C6;\nL_0070:\n\tv136 = LunarConsolePlugin.LunarConsole::get_nativeHandlerLookup(this);\n\tv373 = *([v136 @ X0_v28 (System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>)]);\n\tv377 = *([v373 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]) == 0;\n\tif (v377) goto L_0098;\n\tv512 = *([v373 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]) + 8;\nL_0083:\n\tv518 = *([v512 @ X11_v13-8]) == System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>;\n\tif (v518) goto L_009B;\n\tv513 = v513 + 1;\n\tv523 = v513 < *([v373 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]);\n\tv467 = ~v523;\n\tv512 = v512 + 0x10;\n\tv451 = ~v467;\n\tif (v451) goto L_0083;\nL_0098:\n\tv530 = 0x8909C4(v136, System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>, 6, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00A4;\nL_009B:\n\tv525 = *([v512 @ X11_v13]) + 6;\n\tv526 = v525 << 4;\n\tv527 = v373 + v526;\n\tv530 = v527 + 0x130;\nL_00A4:\n\t*([v530 @ X0_v29])(v533, v136, v249, &v74 @ stack_-28_v9 (LunarConsolePlugin.LunarConsoleNativeMessageHandler), *([v530 @ X0_v29+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv534 = v533 & 1;\n\tv535 = v534 == 0;\n\tif (v535) goto L_00B6;\n\tv400 = v74 == 0;\n\tif (v400) goto L_00CE;\n\tLunarConsolePlugin.LunarConsoleNativeMessageHandler::Invoke(v74, v57);\n\tgoto L_00CD;\nL_00B6:\n\tv363 = System.String::Concat(\"Can't handle native callback: handler not found '\", v249, \"'\");\n\tgoto L_FFFFFFFF;\n\tv548 = *([v371 @ X8_v25+E0]);\n\tv549 = v548 == 0;\n\tv550 = ~v549;\n\tif (v550) goto L_FFFFFFFF;\n\tv555 = v371;\n\tv552 = \"il2cpp_codegen_runtime_class_init\"(v555, v359, v338, v335, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00C6:\n\tLunarConsolePluginInternal.Log::w(v363);\nL_00CD:\n\treturn;\nL_00CE:\n\tv398 = new System.NullReferenceException();\n\tv87 = v249 != 1;\n\tif (v87) goto L_0121;\n\tv554 = 0x6D2BC0(v398, v249, &v74 @ stack_-28_v9 (LunarConsolePlugin.LunarConsoleNativeMessageHandler), *([v530 @ X0_v29+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv150 = *([v554 @ X0_v41]);\n\tv202 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v150 @ X20_v12 (System.Exception)]), &v74 @ stack_-28_v9 (LunarConsolePlugin.LunarConsoleNativeMessageHandler), *([v530 @ X0_v29+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv558 = v202 & 1;\n\tv204 = v558 == 0;\n\tif (v204) goto L_0111;\n\tv559 = 0x6D2490(v202, *([v150 @ X20_v12 (System.Exception)]), &v74 @ stack_-28_v9 (LunarConsolePlugin.LunarConsoleNativeMessageHandler), *([v530 @ X0_v29+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t// 236 NewArr v137 @ X0_v46 (System.Object[]), typeof(System.Object[]), 1\n\tv562 = v249 == 0;\n\tif (v562) goto L_00F9;\n\t// 245 IsInst v564 @ X0_v53, typeof(System.Object), v249 @ X0_v23 (System.String)\nL_00F9:\n\tv273 = v137.Length == 0;\n\tif (v273) goto L_0118;\n\tv137[0] = v249;\n\tgoto L_010D;\n\tv573 = *([v569 @ X0_v48+E0]);\n\tv574 = v573 == 0;\n\tv575 = ~v574;\n\tif (v575) goto L_010D;\n\tv577 = \"il2cpp_codegen_runtime_class_init\"(v569, v267, v83, v76, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_010D:\n\tLunarConsolePluginInternal.Log::e(v150, \"Exception while handling native callback '{0}'\", v137);\n\tgoto L_00CD;\n\tthrow System.NullReferenceException;\nL_0111:\n\tv212 = 0x6D1E60(8, v197, v186, v184, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v212 @ X0_v17]) = *([v205 @ X21_v5]);\n\tv236 = 0x1E8A000 + 0x870;\n\tv238 = 0x6D2A00(v212, v236, 0, v184, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0118:\n\tv279 = new System.IndexOutOfRangeException();\n\tgoto L_011D;\n\tv309 = new System.ArrayTypeMismatchException();\nL_011D:\n\tthrow v308;\nL_0121:\n\tv408 = 0x6D2380(v398, v249, &v74 @ stack_-28_v9 (LunarConsolePlugin.LunarConsoleNativeMessageHandler), *([v530 @ X0_v29+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv475 = 0x846AA4(v408, v249, &v74 @ stack_-28_v9 (LunarConsolePlugin.LunarConsoleNativeMessageHandler), *([v530 @ X0_v29+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void NativeMessageCallback(string param)
		{
			//IL_0047: Expected I, but got O
			//IL_0082: Expected O, but got I
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_0121: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_00ce: Expected O, but got I
			IDictionary<string, string> dictionary = StringUtils.DeserializeString(param);
			string text = dictionary.get_Item("name");
			string message;
			if (string.IsNullOrEmpty(text))
			{
				message = "Can't handle native callback: 'name' is undefined";
				goto IL_0334;
			}
			IDictionary<string, LunarConsoleNativeMessageHandler> dictionary2 = nativeHandlerLookup;
			IntPtr intPtr = (IntPtr)dictionary2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ X11_v13-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, LunarConsoleNativeMessageHandler>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ X8_v18 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, LunarConsolePlugin.LunarConsoleNativeMessageHandler>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e7;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_036c;
			IL_0334:
			Log.w(message);
			return;
			IL_00e7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_036c;
			IL_036c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v530 @ X0_v29] (should have been resolved before IL gen)");
			object obj5 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
			{
				LunarConsoleNativeMessageHandler lunarConsoleNativeMessageHandler = default(LunarConsoleNativeMessageHandler);
				if (lunarConsoleNativeMessageHandler != null)
				{
					lunarConsoleNativeMessageHandler(dictionary);
					return;
				}
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)text == (IntPtr)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj6 = default(object);
					Exception exception = (Exception)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj7 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						object[] array = new object[1];
						if (text != null)
						{
							object obj8 = text as object;
						}
						if (array.Length != 0)
						{
							array[0] = text;
							Log.e(exception, "Exception while handling native callback '{0}'", array);
							return;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj10 = default(object);
						object obj9 = obj10;
						int num4 = 32022528 + 2160;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
					}
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
					throw ex3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				return;
			}
			message = "Can't handle native callback: handler not found '" + text + "'";
			goto IL_0334;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x13D9C88", Offset = "0x13D9C88", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFBFE0]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, data, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A77]) = v38;\nL_0017:\n\tgoto L_0023;\n\tv44 = *([1EB9C88]);\n\tv45 = *([v44 @ X8_v12]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, data, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = 0 | 1;\n\t*([2028B27]) = v49;\nL_0023:\n\tv55 = v53.<onConsoleOpened>k__BackingField == 0;\n\tif (v55) goto L_0034;\n\tSystem.Action::Invoke(v53.<onConsoleOpened>k__BackingField);\nL_0034:\n\tLunarConsolePlugin.LunarConsole::TrackEvent(this, \"Console\", \"console_open\", 0x80000000);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ConsoleOpenHandler(IDictionary<string, string> data)
		{
			if (onConsoleOpened != null)
			{
				onConsoleOpened();
			}
			TrackEvent("Console", "console_open");
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x13D9DC4", Offset = "0x13D9DC4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDC780]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, data, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A78]) = v38;\nL_0017:\n\tgoto L_0023;\n\tv44 = *([1EE5310]);\n\tv45 = *([v44 @ X8_v12]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, data, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = 0 | 1;\n\t*([2028B28]) = v49;\nL_0023:\n\tv55 = v53.<onConsoleClosed>k__BackingField == 0;\n\tif (v55) goto L_0034;\n\tSystem.Action::Invoke(v53.<onConsoleClosed>k__BackingField);\nL_0034:\n\tLunarConsolePlugin.LunarConsole::TrackEvent(this, \"Console\", \"console_close\", 0x80000000);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ConsoleCloseHandler(IDictionary<string, string> data)
		{
			if (onConsoleClosed != null)
			{
				onConsoleClosed();
			}
			TrackEvent("Console", "console_close");
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x13D9E68", Offset = "0x13D9E68", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED0798]);\n\tv23 = *([v22 @ X8_v47]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, data, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A79]) = v41;\nL_0017:\n\tv44 = data == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tv46 = data->klass;\n\tv53 = *([v46 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]) == 0;\n\tif (v53) goto L_0040;\n\tv137 = *([v46 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]) + 8;\nL_002B:\n\tv143 = *([v137 @ X11_v6-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v143) goto L_0043;\n\tv138 = v138 + 1;\n\tv150 = v138 < *([v46 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]);\n\tv86 = ~v150;\n\tv137 = v137 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_002B;\nL_0040:\n\tv172 = 0x8909C4(data, System.Collections.Generic.IDictionary`2<System.String, System.String>, 6, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_0043:\n\tv152 = *([v137 @ X11_v6]) + 6;\n\tv153 = v152 << 4;\n\tv154 = v46 + v153;\n\tv172 = v154 + 0x130;\nL_004C:\n\t*([v172 @ X0_v33])(v180, data, \"id\", &v177 @ stack_-28_v3 (System.String), *([v172 @ X0_v33+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv181 = v180 & 1;\n\tv182 = v181 == 0;\n\tif (v182) goto L_0068;\n\tv207 = System.Int32::TryParse(v177, &v205 @ stack_-34_v4 (System.Int32));\n\tv222 = v207 == 0;\n\tif (v222) goto L_FFFFFFFF;\n\tv235 = this.m_registry == 0;\n\tif (v235) goto L_0091;\n\tv302 = LunarConsolePluginInternal.CRegistry::FindAction(this.m_registry, v205);\n\tv308 = v302 == 0;\n\tif (v308) goto L_FFFFFFFF;\n\tv344 = LunarConsolePluginInternal.CAction::Execute(v302);\n\tgoto L_008E;\nL_0068:\n\tgoto L_FFFFFFFF;\n\tv223 = *([v210 @ X0_v37+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\t// 108 ConditionalJump @b21, v225 @ TEMP_v30\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v210, v179, v176, v175, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0087;\nL_0077:\n\tv321 = System.String::Concat(*([v311 @ X8_v34 (System.String)]), v318);\n\tgoto L_0087;\n\tv366 = *([v329 @ X8_v37+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\t// 131 Jump @b26\n\tv372 = v329;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v372, v304, v314, v175, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0087:\n\tLunarConsolePluginInternal.Log::w(v321);\nL_008E:\n\treturn;\nL_0091:\n\tv287 = 0x13E8374(this.m_registry, &v205 @ stack_-34_v4 (System.Int32), 0, *([v172 @ X0_v33+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_009C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009C:\n\tX8 = 0x1F04000;\n\tX8 = *([1F04B30]);\n\tgoto L_FFFFFFFF;\n\tgoto L_0077;\nL_00A4:\n\tv126 = new System.NullReferenceException();\n\tv97 = v187 != 1;\n\tif (v97) goto L_00F7;\n\tv184 = 0x6D2BC0(v126, v187, v185, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv121 = *([v184 @ X0_v10]);\n\tv219 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v121 @ X19_v5 (System.Exception)]), v185, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv232 = v219 & 1;\n\tv233 = v232 == 0;\n\tif (v233) goto L_00E7;\n\tv240 = 0x6D2490(v219, *([v121 @ X19_v5 (System.Exception)]), v185, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t// 194 NewArr v117 @ X0_v23 (System.Object[]), typeof(System.Object[]), 1\n\tv119 = v117 == 0;\n\tif (v119) goto L_00A4;\n\tv371 = *([data @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>)+18]) == 0;\n\tif (v371) goto L_00D0;\n\t// 204 IsInst v376 @ X0_v30, typeof(System.Object), [data @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>)+18]\nL_00D0:\n\tv358 = v117.Length == 0;\n\tif (v358) goto L_00EE;\n\tv117[0] = *([data @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>)+18]);\n\tgoto L_00E4;\n\tv391 = *([v387 @ X0_v25+E0]);\n\tv392 = v391 == 0;\n\tv393 = ~v392;\n\tif (v393) goto L_00E4;\n\tv395 = \"il2cpp_codegen_runtime_class_init\"(v387, v354, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00E4:\n\tLunarConsolePluginInternal.Log::e(v121, \"Can't run action {0}\", v117);\n\tgoto L_008E;\nL_00E7:\n\tv242 = 0x6D1E60(8, *([v121 @ X19_v5 (System.Exception)]), v185, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v242 @ X0_v19]) = *([v184 @ X0_v10]);\n\tv334 = 0x1E8A000 + 0x870;\n\tv336 = 0x6D2A00(v242, v334, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00EE:\n\tv363 = new System.IndexOutOfRangeException();\n\tgoto L_00F3;\n\tv383 = new System.ArrayTypeMismatchException();\nL_00F3:\n\tthrow v382;\nL_00F7:\n\tv202 = 0x6D2380(v126, v187, v185, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv220 = 0x846AA4(v202, v187, v185, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ConsoleActionHandler(IDictionary<string, string> data)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0257: Expected O, but got I4
			//IL_029b: Expected O, but got I
			//IL_02dd: Expected O, but got I
			if (data != null)
			{
				IntPtr intPtr = (IntPtr)data;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 6;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_039d;
			}
			IDictionary<string, string> dictionary = data;
			object obj5 = default(object);
			object obj6 = default(object);
			IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
			while (true)
			{
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)dictionary != (IntPtr)1)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Exception exception = (Exception)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					object[] array = new object[1];
					bool flag3 = array == null;
					dictionary = (IDictionary<string, string>)1;
					if (flag3)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>)+18]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>)+18]");
						object obj7 = 0 as object;
					}
					if (array.Length != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [data @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>)+18]");
						array[0] = 0;
						Log.e(exception, "Can't run action {0}", array);
						return;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj8 = obj5;
					int num4 = 32022528 + 2160;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				}
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			return;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_039d;
			IL_039d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v172 @ X0_v33] (should have been resolved before IL gen)");
			object obj9 = default(object);
			string message;
			if ((uint)((ulong)(long)(IntPtr)obj9 & 1uL) != 0)
			{
				string text = default(string);
				string text2;
				string text3;
				if (int.TryParse(text, out var result))
				{
					if (registry == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13E8374 (inside LunarConsolePluginInternal.StringUtils::.cctor +0x114)");
						return;
					}
					CAction cAction = registry.FindAction(result);
					if (cAction != null)
					{
						bool flag4 = cAction.Execute();
						return;
					}
					text2 = text;
					text3 = "Can't run action: ID not found ";
				}
				else
				{
					text2 = text;
					text3 = "Can't run action: invalid ID ";
				}
				message = text3 + text2;
			}
			else
			{
				string text2 = "id";
				message = "Can't run action: data is not properly formatted";
			}
			Log.w(message);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x13DA348", Offset = "0x13DA348", Length = "0x708")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F0A138]);\n\tv25 = *([v24 @ X8_v83]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, data, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028A7A]) = v43;\nL_0016:\n\tv44 = 0;\n\tv50 = data->klass;\n\tv57 = *([v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]) == 0;\n\tif (v57) goto L_0043;\n\tv171 = *([v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]) + 8;\nL_002E:\n\tv177 = *([v171 @ X11_v17-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v177) goto L_0046;\n\tv172 = v172 + 1;\n\tv214 = v172 < *([v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]);\n\tv91 = ~v214;\n\tv171 = v171 + 0x10;\n\tv67 = ~v91;\n\tif (v67) goto L_002E;\nL_0043:\n\tv235 = 0x8909C4(data, System.Collections.Generic.IDictionary`2<System.String, System.String>, 6, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_004A;\nL_0046:\n\tv216 = *([v171 @ X11_v17]) + 6;\n\tv217 = v216 << 4;\n\tv50 = v50 + v217;\n\tv235 = v50 + 0x130;\nL_004A:\n\tv50 = *([v235 @ X0_v61]);\n\t*([v235 @ X0_v61])(v242, data, \"id\", &v106 @ stack_-38_v6 (System.String), *([v235 @ X0_v61+8]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv243 = v242 & 1;\n\tv244 = v243 == 0;\n\tif (v244) goto L_0080;\n\tv50 = data->klass;\n\tv254 = *([v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]) == 0;\n\tif (v254) goto L_0078;\n\tv313 = *([v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]) + 8;\nL_0063:\n\tv319 = *([v313 @ X11_v12-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v319) goto L_008A;\n\tv314 = v314 + 1;\n\tv369 = v314 < *([v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]);\n\tv285 = ~v369;\n\tv313 = v313 + 0x10;\n\tv269 = ~v285;\n\tif (v269) goto L_0063;\nL_0078:\n\tv376 = 0x8909C4(data, System.Collections.Generic.IDictionary`2<System.String, System.String>, 6, *([v235 @ X0_v61+8]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_008E;\nL_0080:\n\tgoto L_FFFFFFFF;\n\tv293 = *([v257 @ X0_v67+E0]);\n\tv294 = v293 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_FFFFFFFF;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v257, v241, v239, v238, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_FFFFFFFF;\nL_008A:\n\tv371 = *([v313 @ X11_v12]) + 6;\n\tv372 = v371 << 4;\n\tv50 = v50 + v372;\n\tv376 = v50 + 0x130;\nL_008E:\n\tv50 = *([v376 @ X0_v70]);\n\t*([v376 @ X0_v70])(v380, data, \"value\", &v44 @ stack_-40_v1, *([v376 @ X0_v70+8]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv381 = v380 & 1;\n\tv382 = v381 == 0;\n\tif (v382) goto L_00D6;\n\tv446 = System.Int32::TryParse(v106, &v112 @ stack_-44_v7 (System.Int32));\n\tv511 = v446 == 0;\n\tif (v511) goto L_FFFFFFFF;\n\tv563 = this.m_registry == 0;\n\tif (v563) goto L_0104;\n\tv545 = LunarConsolePluginInternal.CRegistry::FindVariable(this.m_registry, v112);\n\tv548 = v545 == 0;\n\tif (v548) goto L_FFFFFFFF;\n\tv598 = v545.m_type;\n\tv599 = v545.m_type < 3;\n\tv135 = ~v599;\n\tv133 = v545.m_type - 3;\n\tv129 = v133 == 0;\n\tv600 = ~v129;\n\tv119 = v135 & v600;\n\tif (v119) goto L_0131;\n\tv538 = 0x1835000 + 0x7FC;\n\tv50 = *([v538 @ X9_v17 (System.Int32)+v598 @ X8_v63 (LunarConsolePlugin.CVarType)*4]);\n\tv50 = v50 + v538;\n\t// 183 IndirectJump v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>), v545 @ X0_v89 (LunarConsolePlugin.CVar), v545 @ X0_v89 (LunarConsolePlugin.CVar), v112 @ stack_-44_v7 (System.Int32), 0, [v376 @ X0_v70+8], v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tX0 = stack[20];\n\tX1 = &stack[18];\n\tX2 = 0;\n\tX0 = System.Int32::TryParse(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_015B;\n\tX8 = stack[18];\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_015B;\n\tX1 = Z;\n\tX0 = X19;\n\tLunarConsolePlugin.CVar::set_BoolValue(X0, X1, X2);\n\tgoto L_012A;\nL_00D6:\n\tgoto L_FFFFFFFF;\n\tv512 = *([v449 @ X0_v73+E0]);\n\tv513 = v512 == 0;\n\tv514 = ~v513;\n\tif (v514) goto L_FFFFFFFF;\n\tv515 = \"il2cpp_codegen_runtime_class_init\"(v449, v352, v329, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00DF:\n\tLunarConsolePluginInternal.Log::w(v404);\nL_00E7:\n\treturn;\nL_00ED:\n\tv404 = System.String::Concat(*([v579 @ X8_v48 (System.String)]), v401);\n\tgoto L_00FD;\n\tv602 = *([v411 @ X8_v51+E0]);\n\tv603 = v602 == 0;\n\tv604 = ~v603;\n\tgoto L_00FD;\n\tv615 = v411;\n\tv606 = \"il2cpp_codegen_runtime_class_init\"(v615, v402, v388, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00FD:\n\tgoto L_00DF;\nL_0104:\n\tgoto L_FFFFFFFF;\n\tv584 = *([v571 @ X0_v86+E0]);\n\tv585 = v584 == 0;\n\tv586 = ~v585;\n\tif (v586) goto L_FFFFFFFF;\n\tv587 = \"il2cpp_codegen_runtime_class_init\"(v571, v353, v117, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_FFFFFFFF;\n\tgoto L_00ED;\n\tX0 = stack[20];\n\tX1 = &stack[10];\n\tX2 = 0;\n\tX0 = System.Single::TryParse(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0182;\n\tV0 = stack[10];\n\tX0 = X19;\n\tLunarConsolePlugin.CVar::set_FloatValue(X0, V0, X1);\n\tgoto L_012A;\n\tX1 = stack[20];\n\tX0 = X19;\n\tLunarConsolePlugin.CVar::set_Value(X0, X1, X2);\n\tgoto L_012A;\n\tX0 = stack[20];\n\tX1 = &stack[14];\n\tX2 = 0;\n\tX0 = System.Int32::TryParse(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_01A9;\n\tX1 = stack[14];\n\tX0 = X19;\n\tLunarConsolePlugin.CVar::set_IntValue(X0, X1, X2);\nL_012A:\n\tX8 = 0 | 1;\n\t*([X20+28]) = X8;\n\tgoto L_00E7;\nL_0131:\n\t// 305 NewArr v614 @ X0_v91 (System.Object[]), typeof(System.Object[]), 1\n\tv156 = v545.m_type;\n\t// 313 Box v148 @ X0_v93, typeof(LunarConsolePlugin.CVarType), &v156 @ X8_v66 (LunarConsolePlugin.CVarType)\n\tv625 = v148 == 0;\n\tif (v625) goto L_0146;\n\t// 322 IsInst v436 @ X0_v100, typeof(System.Object), v148 @ X0_v93\n\tv438 = v436 == 0;\n\tif (v438) goto L_01DE;\nL_0146:\n\tv207 = v614.Length == 0;\n\tif (v207) goto L_01D4;\n\tv614[0] = v148;\n\tgoto L_0159;\n\tv640 = *([v635 @ X0_v95+E0]);\n\tv641 = v640 == 0;\n\tv642 = ~v641;\n\tif (v642) goto L_0159;\n\tv644 = \"il2cpp_codegen_runtime_class_init\"(v635, v201, v117, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0159:\n\tLunarConsolePluginInternal.Log::e(\"Unexpected variable type: {0}\", v614);\n\tgoto L_00E7;\nL_015B:\n\tX8 = 0x1EFE000;\n\tX8 = *([1EFE3C0]);\n\tX0 = *([X8]);\n\tX1 = 0 | 1;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_01D9;\n\tX21 = stack[20];\n\tif (TEMP) goto L_016C;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = X21;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_01EE;\nL_016C:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_01DA;\n\t*([X20+20]) = X21;\n\tX8 = *([1EB5228]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_017C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_017C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_017C:\n\tX8 = 0x1EE0000;\n\tX8 = *([1EE0880]);\n\tX0 = *([X8]);\n\tX1 = X20;\n\tLunarConsolePluginInternal.Log::e(X0, X1, X2);\n\tgoto L_00E7;\nL_0182:\n\tX8 = 0x1EFE000;\n\tX8 = *([1EFE3C0]);\n\tX0 = *([X8]);\n\tX1 = 0 | 1;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_01E3;\n\tX21 = stack[20];\n\tif (TEMP) goto L_0193;\n\tX8 = *([X20]);\n\tX1 = *([X8+40]);\n\tX0 = X21;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_01F2;\nL_0193:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_01E6;\n\t*([X20+20]) = X21;\n\tX8 = *([1EB5228]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01A3;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A3;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01A3:\n\tX8 = 0x1EE6000;\n\tX8 = *([1EE6390]);\n\tX0 = \n// ... truncated")]
		private unsafe void ConsoleVariableSetHandler(IDictionary<string, string> data)
		{
			//IL_0480: Expected O, but got I4
			//IL_000d: Expected I, but got O
			//IL_04b7: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0103: Expected I, but got O
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_051f: Expected I, but got O
			//IL_013e: Expected O, but got I
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Expected O, but got Unknown
			//IL_0208: Expected O, but got I
			//IL_018a: Expected O, but got I
			//IL_037a: Expected O, but got I4
			object obj = 0;
			IntPtr intPtr = (IntPtr)data;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]");
			object obj2 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X11_v17-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj3 = obj2 + 6;
			int num3 = (int)((long)(IntPtr)obj3 << 4);
			intPtr = (IntPtr)(void*)((long)intPtr + (long)num3);
			object obj4 = (long)intPtr + 304L;
			goto IL_04af;
			IL_033a:
			string text = "value";
			string text2 = "Can't set variable: missing 'value' property";
			goto IL_0555;
			IL_01a3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0517;
			IL_0517:
			object obj5 = default(object);
			intPtr = (IntPtr)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v376 @ X0_v70] (should have been resolved before IL gen)");
			object obj6 = default(object);
			string message;
			if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
			{
				string text3 = default(string);
				string text4;
				if (int.TryParse(text3, out var result))
				{
					if (registry == null)
					{
						text = (string)result;
						text2 = "Can't set variable: registry is not property initialized";
						goto IL_0555;
					}
					CVar cVar = registry.FindVariable(result);
					if (cVar != null)
					{
						CVarType type = cVar.Type;
						bool flag3 = cVar.Type < CVarType.String;
						bool flag4 = !flag3;
						int num4 = (int)(cVar.Type - 3);
						bool flag5 = num4 == 0;
						bool flag6 = !flag5;
						if (!(flag4 && flag6))
						{
							int num5 = 25382912 + 2044;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ X9_v17 (System.Int32)+v598 @ X8_v63 (LunarConsolePlugin.CVarType)*4]");
							intPtr = (IntPtr)0;
							intPtr = (IntPtr)(void*)((long)intPtr + (long)num5);
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>) (should have been resolved before IL gen)");
							goto IL_033a;
						}
						object[] array = new object[1];
						CVarType type2 = cVar.Type;
						object obj7 = type2;
						if (obj7 != null)
						{
							object obj8 = obj7 as object;
							if (obj8 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						if (array.Length != 0)
						{
							array[0] = obj7;
							Log.e("Unexpected variable type: {0}", array);
							return;
						}
						IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
						throw ex2;
					}
					text = text3;
					text4 = "Can't set variable: ID not found ";
				}
				else
				{
					text = text3;
					text4 = "Can't set variable: invalid ID ";
				}
				message = text4 + text;
				goto IL_0562;
			}
			goto IL_033a;
			IL_0555:
			message = text2;
			goto IL_0562;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_04af;
			IL_04af:
			intPtr = (IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v235 @ X0_v61] (should have been resolved before IL gen)");
			object obj9 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj9 & 1uL) != 0)
			{
				intPtr = (IntPtr)data;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01a3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]");
				object obj10 = 0L + 8L;
				int num6 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X11_v12-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
					{
						break;
					}
					num6++;
					int num7 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v26 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
					bool flag7 = (long)num7 < 0L;
					bool flag8 = !flag7;
					obj10 = (long)(IntPtr)obj10 + 16L;
					if (!flag8)
					{
						continue;
					}
					goto IL_01a3;
				}
				object obj11 = obj10 + 6;
				int num8 = (int)((long)(IntPtr)obj11 << 4);
				intPtr = (IntPtr)(void*)((long)intPtr + (long)num8);
				obj5 = (long)intPtr + 304L;
				goto IL_0517;
			}
			text = "id";
			text2 = "Can't set variable: missing 'id' property";
			goto IL_0555;
			IL_0562:
			Log.w(message);
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x13DAB0C", Offset = "0x13DAB0C", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0014;\n\tv20 = *([1EA5D88]);\n\tv21 = *([v20 @ X8_v61]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, data, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2028A7B]) = v40;\nL_0014:\n\t*([v10 @ X29_v1-18]) = 0;\n\tv46 = data->klass;\n\tv53 = *([v46 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]) == 0;\n\tif (v53) goto L_0041;\n\tv225 = *([v46 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]) + 8;\nL_002C:\n\tv231 = *([v225 @ X11_v23-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v231) goto L_0044;\n\tv226 = v226 + 1;\n\tv268 = v226 < *([v46 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]);\n\tv156 = ~v268;\n\tv225 = v225 + 0x10;\n\tv140 = ~v156;\n\tif (v140) goto L_002C;\nL_0041:\n\tv275 = 0x8909C4(data, System.Collections.Generic.IDictionary`2<System.String, System.String>, 6, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_004A;\nL_0044:\n\tv270 = *([v225 @ X11_v23]) + 6;\n\tv271 = v270 << 4;\n\tv272 = v46 + v271;\n\tv275 = v272 + 0x130;\nL_004A:\n\tv68 = &v11 @ stack_-10_v2 - 0x18;\n\t*([v275 @ X0_v10])(v123, data, \"category\", v68, *([v275 @ X0_v10+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv279 = v123 & 1;\n\tv280 = v279 == 0;\n\tif (v280) goto L_0084;\n\tv129 = *([v10 @ X29_v1-18]);\n\tv282 = *([v129 @ X8_v20+10]) == 0;\n\tif (v282) goto L_0084;\n\tv334 = data->klass;\n\tv338 = *([v334 @ X8_v22 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]) == 0;\n\tif (v338) goto L_007C;\n\tv477 = *([v334 @ X8_v22 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]) + 8;\nL_0067:\n\tv483 = *([v477 @ X11_v18-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v483) goto L_008E;\n\tv478 = v478 + 1;\n\tv488 = v478 < *([v334 @ X8_v22 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]);\n\tv443 = ~v488;\n\tv477 = v477 + 0x10;\n\tv427 = ~v443;\n\tif (v427) goto L_0067;\nL_007C:\n\tv495 = 0x8909C4(data, System.Collections.Generic.IDictionary`2<System.String, System.String>, 6, *([v275 @ X0_v10+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0097;\nL_0084:\n\tgoto L_FFFFFFFF;\n\tv324 = *([v287 @ X0_v16+E0]);\n\tv325 = v324 == 0;\n\tv326 = ~v325;\n\tif (v326) goto L_FFFFFFFF;\n\tv328 = \"il2cpp_codegen_runtime_class_init\"(v287, v115, v68, v55, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_00D9;\nL_008E:\n\tv490 = *([v477 @ X11_v18]) + 6;\n\tv491 = v490 << 4;\n\tv492 = v334 + v491;\n\tv495 = v492 + 0x130;\nL_0097:\n\t*([v495 @ X0_v19])(v124, data, \"action\", &v62 @ stack_-38_v8 (System.String), *([v495 @ X0_v19+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv499 = v124 & 1;\n\tv500 = v499 == 0;\n\tif (v500) goto L_00D0;\n\tv502 = v62.m_stringLength == 0;\n\tif (v502) goto L_00D0;\n\tv520 = data->klass;\n\tv524 = *([v520 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]) == 0;\n\tif (v524) goto L_00C8;\n\tv565 = *([v520 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]) + 8;\nL_00B3:\n\tv571 = *([v565 @ X11_v13-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v571) goto L_00E2;\n\tv566 = v566 + 1;\n\tv576 = v566 < *([v520 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]);\n\tv547 = ~v576;\n\tv565 = v565 + 0x10;\n\tv531 = ~v547;\n\tif (v531) goto L_00B3;\nL_00C8:\n\tv583 = 0x8909C4(data, System.Collections.Generic.IDictionary`2<System.String, System.String>, 6, *([v495 @ X0_v19+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_00EB;\nL_00D0:\n\tgoto L_FFFFFFFF;\n\tv511 = *([v507 @ X0_v22+E0]);\n\tv512 = v511 == 0;\n\tv513 = ~v512;\n\tif (v513) goto L_FFFFFFFF;\n\tv514 = \"il2cpp_codegen_runtime_class_init\"(v507, v116, v69, v56, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00D9:\n\tLunarConsolePluginInternal.Log::w(*([v361 @ X8_v10 (System.String)]));\nL_00E0:\n\treturn;\nL_00E2:\n\tv578 = *([v565 @ X11_v13]) + 6;\n\tv579 = v578 << 4;\n\tv580 = v520 + v579;\n\tv583 = v580 + 0x130;\nL_00EB:\n\t*([v583 @ X0_v25])(v589, data, \"value\", &v169 @ stack_-48_v6 (System.String), *([v583 @ X0_v25+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv590 = v589 & 1;\n\tv591 = v590 == 0;\n\tif (v591) goto L_00FF;\n\tv594 = System.Int32::TryParse(v169, &v451 @ stack_-3C_v7 (System.Int32));\n\tv599 = v594 == 0;\n\tif (v599) goto L_010E;\nL_00FF:\n\tgoto L_0108;\n\tv607 = *([v602 @ X0_v29+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_0108;\n\tv611 = \"il2cpp_codegen_runtime_class_init\"(v602, v596, v595, v165, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0108:\n\tv457 = LunarConsolePluginInternal.LunarConsoleAnalytics::TrackEvent(*([v10 @ X29_v1-18]), v62, 0x80000000);\n\tgoto L_00E0;\nL_010E:\n\t// 270 NewArr v205 @ X0_v37 (System.Object[]), typeof(System.Object[]), 1\n\tv615 = v169 == 0;\n\tif (v615) goto L_011C;\n\t// 280 IsInst v617 @ X0_v44, typeof(System.Object), v169 @ stack_-48_v6 (System.String)\nL_011C:\n\tv261 = v205.Length == 0;\n\tif (v261) goto L_0133;\n\tv205[0] = v169;\n\tgoto L_012F;\n\tv626 = *([v622 @ X0_v39+E0]);\n\tv627 = v626 == 0;\n\tv628 = ~v627;\n\tif (v628) goto L_012F;\n\tv630 = \"il2cpp_codegen_runtime_class_init\"(v622, v255, v176, v165, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_012F:\n\tLunarConsolePluginInternal.Log::w(\"Can't track event: invalid 'value' parameter: {0}\", v205);\n\tgoto L_00E0;\n\tv214 = new System.NullReferenceException();\nL_0133:\n\tv267 = new System.IndexOutOfRangeException();\n\tgoto L_0138;\n\tv314 = new System.ArrayTypeMismatchException();\nL_0138:\n\tthrow v313;\n// 188 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TrackEventHandler(IDictionary<string, string> data)
		{
			//IL_0015: Expected I, but got O
			//IL_04ac: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_0113: Expected O, but got I
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00ef: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_009c: Expected O, but got I
			//IL_0145: Expected I, but got O
			//IL_0180: Expected O, but got I
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected O, but got Unknown
			//IL_0233: Expected O, but got I
			//IL_0242: Expected O, but got I
			//IL_01cc: Expected O, but got I
			//IL_0271: Expected I, but got O
			//IL_02ac: Expected O, but got I
			//IL_03c1: Expected O, but got I
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0343: Expected O, but got Unknown
			//IL_0360: Expected O, but got I
			//IL_036f: Expected O, but got I
			//IL_02f8: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			IntPtr intPtr = (IntPtr)data;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]");
			object obj3 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X11_v23-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v7 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b5;
			}
			object obj4 = obj3 + 6;
			int num3 = (int)((long)(IntPtr)obj4 << 4);
			object obj5 = (long)intPtr + (long)num3;
			object obj6 = (long)(IntPtr)obj5 + 304L;
			goto IL_049d;
			IL_050c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v495 @ X0_v19] (should have been resolved before IL gen)");
			object obj7 = default(object);
			string text = default(string);
			if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0 && text.Length != 0)
			{
				IntPtr intPtr2 = (IntPtr)data;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0311;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]");
				object obj8 = 0L + 8L;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X11_v13-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
					{
						break;
					}
					num4++;
					int num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ X8_v36 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
					bool flag3 = (long)num5 < 0L;
					bool flag4 = !flag3;
					obj8 = (long)(IntPtr)obj8 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0311;
				}
				object obj9 = obj8 + 6;
				int num6 = (int)((long)(IntPtr)obj9 << 4);
				object obj10 = (long)intPtr2 + (long)num6;
				object obj11 = (long)(IntPtr)obj10 + 304L;
				goto IL_057a;
			}
			string message = "Can't track event: missing 'action' parameter";
			goto IL_0542;
			IL_057a:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v583 @ X0_v25] (should have been resolved before IL gen)");
			object obj12 = default(object);
			int num7 = (int)((long)(IntPtr)obj12 & 1L);
			bool flag5 = num7 == 0;
			int result = int.MinValue;
			string text2 = default(string);
			if (flag5 || int.TryParse(text2, out result))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-18]");
				IEnumerator enumerator = LunarConsoleAnalytics.TrackEvent((string)0, text);
				return;
			}
			object[] array = new object[1];
			if (text2 != null)
			{
				object obj13 = text2 as object;
			}
			if (array.Length != 0)
			{
				array[0] = text2;
				Log.w("Can't track event: invalid 'value' parameter: {0}", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_01e5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_050c;
			IL_0311:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_057a;
			IL_00b5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_049d;
			IL_049d:
			object obj14 = (long)(IntPtr)obj2 - 24L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v275 @ X0_v10] (should have been resolved before IL gen)");
			object obj15 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj15 & 1uL) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-18]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v20+10]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					IntPtr intPtr3 = (IntPtr)data;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X8_v22 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01e5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X8_v22 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+B0]");
					object obj17 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ X11_v18-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X8_v22 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.String>>)+126]");
						bool flag6 = (long)num9 < 0L;
						bool flag7 = !flag6;
						obj17 = (long)(IntPtr)obj17 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_01e5;
					}
					object obj18 = obj17 + 6;
					int num10 = (int)((long)(IntPtr)obj18 << 4);
					object obj19 = (long)intPtr3 + (long)num10;
					object obj20 = (long)(IntPtr)obj19 + 304L;
					goto IL_050c;
				}
			}
			message = "Can't track event: missing 'category' parameter";
			goto IL_0542;
			IL_0542:
			Log.w(message);
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x13D9D2C", Offset = "0x13D9D2C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EDA5C8]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, category, action, value, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028A7C]) = v47;\nL_001F:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, category, action, value, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0028:\n\tv64 = LunarConsolePluginInternal.LunarConsoleAnalytics::TrackEvent(category, action, value);\n\tv75 = UnityEngine.MonoBehaviour::StartCoroutine(this, v64);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TrackEvent(string category, string action, int value = int.MinValue)
		{
			IEnumerator routine = LunarConsoleAnalytics.TrackEvent(category, action, value);
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x13DAEE8", Offset = "0x13DAEE8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1F10AE0]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2028A7D]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v43.s_instance, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003C;\n\tLunarConsolePlugin.LunarConsole::ShowConsole(v63.s_instance);\n\treturn;\nL_003C:\n\tgoto L_004A;\n\tv77 = *([v68 @ X0_v6+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_004A;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v68, v57, v58, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_004A:\n\tLunarConsolePluginInternal.Log::w(\"Can't show console: instance is not initialized. Make sure you've installed it correctly\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Show()
		{
			if (s_instance != null)
			{
				s_instance.ShowConsole();
			}
			else
			{
				Log.w("Can't show console: instance is not initialized. Make sure you've installed it correctly");
			}
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x13DB074", Offset = "0x13DB074", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1EED960]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2028A7E]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v43.s_instance, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003C;\n\tLunarConsolePlugin.LunarConsole::HideConsole(v63.s_instance);\n\treturn;\nL_003C:\n\tgoto L_004A;\n\tv77 = *([v68 @ X0_v6+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_004A;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v68, v57, v58, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_004A:\n\tLunarConsolePluginInternal.Log::w(\"Can't hide console: instance is not initialized. Make sure you've installed it correctly\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Hide()
		{
			if (s_instance != null)
			{
				s_instance.HideConsole();
			}
			else
			{
				Log.w("Can't hide console: instance is not initialized. Make sure you've installed it correctly");
			}
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x13DB200", Offset = "0x13DB200", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1EDEB38]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2028A7F]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v43.s_instance, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003C;\n\tLunarConsolePlugin.LunarConsole::ClearConsole(v63.s_instance);\n\treturn;\nL_003C:\n\tgoto L_004A;\n\tv77 = *([v68 @ X0_v6+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_004A;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v68, v57, v58, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_004A:\n\tLunarConsolePluginInternal.Log::w(\"Can't clear console: instance is not initialized. Make sure you've installed it correctly\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Clear()
		{
			if (s_instance != null)
			{
				s_instance.ClearConsole();
			}
			else
			{
				Log.w("Can't clear console: instance is not initialized. Make sure you've installed it correctly");
			}
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x13DB38C", Offset = "0x13DB38C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = *([1EE9598]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, action, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2028A80]) = v43;\nL_0021:\n\tgoto L_002A;\n\tv55 = *([v50 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002A;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v50, action, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002A:\n\tv65 = UnityEngine.Object::op_Inequality(v49.s_instance, 0);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0044;\n\tLunarConsolePlugin.LunarConsole::RegisterConsoleAction(v69.s_instance, name, action);\n\treturn;\nL_0044:\n\tgoto L_0054;\n\tv87 = *([v74 @ X0_v6+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0054;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v74, v63, v64, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0054:\n\tLunarConsolePluginInternal.Log::w(\"Can't register action: instance is not initialized. Make sure you've installed it correctly\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RegisterAction(string name, Action action)
		{
			if (s_instance != null)
			{
				s_instance.RegisterConsoleAction(name, action);
			}
			else
			{
				Log.w("Can't register action: instance is not initialized. Make sure you've installed it correctly");
			}
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x13DB574", Offset = "0x13DB574", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EF1788]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A81]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v47 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Inequality(v46.s_instance, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0040;\n\tLunarConsolePlugin.LunarConsole::UnregisterConsoleAction(v66.s_instance, action);\n\treturn;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UnregisterAction(Action action)
		{
			if (s_instance != null)
			{
				s_instance.UnregisterConsoleAction(action);
			}
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x13DB720", Offset = "0x13DB720", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EA59F8]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A82]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v47 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Inequality(v46.s_instance, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0040;\n\tLunarConsolePlugin.LunarConsole::UnregisterConsoleAction(v66.s_instance, name);\n\treturn;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UnregisterAction(string name)
		{
			if (s_instance != null)
			{
				s_instance.UnregisterConsoleAction(name);
			}
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x13DB8CC", Offset = "0x13DB8CC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EB0690]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A83]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v47 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Inequality(v46.s_instance, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0040;\n\tLunarConsolePlugin.LunarConsole::UnregisterAllConsoleActions(v66.s_instance, target);\n\treturn;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void UnregisterAllActions(object target)
		{
			if (s_instance != null)
			{
				s_instance.UnregisterAllConsoleActions(target);
			}
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x13DBA78", Offset = "0x13DBA78", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EFFFF0]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028A84]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v47 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Inequality(v46.s_instance, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0041;\n\tUnityEngine.Behaviour::set_enabled(v66.s_instance, enabled);\n\treturn;\nL_0041:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetConsoleEnabled(bool enabled)
		{
			if (s_instance != null)
			{
				s_instance.enabled = enabled;
			}
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x13DBB40", Offset = "0x13DBB40", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_variablesDirty = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void MarkVariablesDirty()
		{
			m_variablesDirty = true;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x13DAFB8", Offset = "0x13DAFB8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF6D80]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A89]) = v38;\nL_0013:\n\tv39 = this.m_platform;\n\tv40 = this.m_platform == 0;\n\tif (v40) goto L_0041;\n\tv42 = *([v39 @ X19_v2 (LunarConsolePlugin.LunarConsole+IPlatform)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv150 = *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]) + 8;\nL_0025:\n\tv156 = *([v150 @ X11_v5-8]) == LunarConsolePlugin.LunarConsole+IPlatform;\n\tif (v156) goto L_0043;\n\tv151 = v151 + 1;\n\tv161 = v151 < *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]);\n\tv82 = ~v161;\n\tv150 = v150 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_0025;\nL_003A:\n\tv168 = 0x8909C4(this.m_platform, LunarConsolePlugin.LunarConsole+IPlatform, 2, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\nL_0041:\n\treturn;\nL_0043:\n\tv163 = *([v150 @ X11_v5]) + 2;\n\tv164 = v163 << 4;\n\tv165 = v42 + v164;\n\tv168 = v165 + 0x130;\nL_004F:\n\t// 79 IndirectJump [v168 @ X0_v2], this.m_platform (LunarConsolePlugin.LunarConsole+IPlatform), this.m_platform (LunarConsolePlugin.LunarConsole+IPlatform), [v168 @ X0_v2+8], [v168 @ X0_v2], v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ShowConsole()
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00e8: Expected O, but got I
			//IL_00f7: Expected O, but got I
			//IL_0094: Expected O, but got I
			IPlatform platform = m_platform;
			if (m_platform == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)platform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IPlatform))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014f;
			IL_014f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v168 @ X0_v2] (should have been resolved before IL gen)");
			return;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014f;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x13DB144", Offset = "0x13DB144", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB5248]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A8A]) = v38;\nL_0013:\n\tv39 = this.m_platform;\n\tv40 = this.m_platform == 0;\n\tif (v40) goto L_0041;\n\tv42 = *([v39 @ X19_v2 (LunarConsolePlugin.LunarConsole+IPlatform)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv150 = *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]) + 8;\nL_0025:\n\tv156 = *([v150 @ X11_v5-8]) == LunarConsolePlugin.LunarConsole+IPlatform;\n\tif (v156) goto L_0043;\n\tv151 = v151 + 1;\n\tv161 = v151 < *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]);\n\tv82 = ~v161;\n\tv150 = v150 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_0025;\nL_003A:\n\tv168 = 0x8909C4(this.m_platform, LunarConsolePlugin.LunarConsole+IPlatform, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\nL_0041:\n\treturn;\nL_0043:\n\tv163 = *([v150 @ X11_v5]) + 3;\n\tv164 = v163 << 4;\n\tv165 = v42 + v164;\n\tv168 = v165 + 0x130;\nL_004F:\n\t// 79 IndirectJump [v168 @ X0_v2], this.m_platform (LunarConsolePlugin.LunarConsole+IPlatform), this.m_platform (LunarConsolePlugin.LunarConsole+IPlatform), [v168 @ X0_v2+8], [v168 @ X0_v2], v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HideConsole()
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00e8: Expected O, but got I
			//IL_00f7: Expected O, but got I
			//IL_0094: Expected O, but got I
			IPlatform platform = m_platform;
			if (m_platform == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)platform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IPlatform))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014f;
			IL_014f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v168 @ X0_v2] (should have been resolved before IL gen)");
			return;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014f;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x13DB2D0", Offset = "0x13DB2D0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECB550]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A8B]) = v38;\nL_0013:\n\tv39 = this.m_platform;\n\tv40 = this.m_platform == 0;\n\tif (v40) goto L_0041;\n\tv42 = *([v39 @ X19_v2 (LunarConsolePlugin.LunarConsole+IPlatform)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv150 = *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]) + 8;\nL_0025:\n\tv156 = *([v150 @ X11_v5-8]) == LunarConsolePlugin.LunarConsole+IPlatform;\n\tif (v156) goto L_0043;\n\tv151 = v151 + 1;\n\tv161 = v151 < *([v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]);\n\tv82 = ~v161;\n\tv150 = v150 + 0x10;\n\tv58 = ~v82;\n\tif (v58) goto L_0025;\nL_003A:\n\tv168 = 0x8909C4(this.m_platform, LunarConsolePlugin.LunarConsole+IPlatform, 4, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\nL_0041:\n\treturn;\nL_0043:\n\tv163 = *([v150 @ X11_v5]) + 4;\n\tv164 = v163 << 4;\n\tv165 = v42 + v164;\n\tv168 = v165 + 0x130;\nL_004F:\n\t// 79 IndirectJump [v168 @ X0_v2], this.m_platform (LunarConsolePlugin.LunarConsole+IPlatform), this.m_platform (LunarConsolePlugin.LunarConsole+IPlatform), [v168 @ X0_v2+8], [v168 @ X0_v2], v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearConsole()
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00e8: Expected O, but got I
			//IL_00f7: Expected O, but got I
			//IL_0094: Expected O, but got I
			IPlatform platform = m_platform;
			if (m_platform == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)platform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IPlatform))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<LunarConsolePlugin.LunarConsole+IPlatform>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_014f;
			IL_014f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v168 @ X0_v2] (should have been resolved before IL gen)");
			return;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_014f;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x13DB478", Offset = "0x13DB478", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ECDF90]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, actionDelegate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2028A8C]) = v44;\nL_0018:\n\tv46 = this.m_registry == 0;\n\tif (v46) goto L_0029;\n\tv55 = LunarConsolePluginInternal.CRegistry::RegisterAction(this.m_registry, name, actionDelegate);\n\treturn;\nL_0029:\n\t// 41 NewArr v60 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv89 = name == 0;\n\tif (v89) goto L_0036;\n\t// 50 IsInst v94 @ X0_v16, typeof(System.Object), name @ X1 (System.String)\nL_0036:\n\tv101 = v60.Length == 0;\n\tif (v101) goto L_0053;\n\tv60[0] = name;\n\tgoto L_0050;\n\tv114 = *([v109 @ X0_v11+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0050;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v109, v95, actionDelegate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0050:\n\tLunarConsolePluginInternal.Log::w(\"Can't register action '{0}': registry is not property initialized\", v60);\n\treturn;\n\tv90 = new System.NullReferenceException();\nL_0053:\n\tv106 = new System.IndexOutOfRangeException();\n\tgoto L_0058;\n\tv113 = new System.ArrayTypeMismatchException();\nL_0058:\n\tthrow v122;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RegisterConsoleAction(string name, Action actionDelegate)
		{
			if (registry != null)
			{
				CAction cAction = registry.RegisterAction(name, actionDelegate);
				return;
			}
			object[] array = new object[1];
			if (name != null)
			{
				object obj = name as object;
			}
			if (array.Length != 0)
			{
				array[0] = name;
				Log.w("Can't register action '{0}': registry is not property initialized", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x13DB62C", Offset = "0x13DB62C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EFC5F0]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, actionDelegate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A8D]) = v41;\nL_0016:\n\tv43 = this.m_registry == 0;\n\tif (v43) goto L_0025;\n\tv50 = LunarConsolePluginInternal.CRegistry::Unregister(this.m_registry, actionDelegate);\n\treturn;\nL_0025:\n\t// 37 NewArr v55 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv82 = actionDelegate == 0;\n\tif (v82) goto L_0032;\n\t// 46 IsInst v87 @ X0_v16, typeof(System.Object), actionDelegate @ X1 (System.Action)\nL_0032:\n\tv94 = v55.Length == 0;\n\tif (v94) goto L_004E;\n\tv55[0] = actionDelegate;\n\tgoto L_004B;\n\tv107 = *([v102 @ X0_v11+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_004B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v102, v88, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004B:\n\tLunarConsolePluginInternal.Log::w(\"Can't unregister action '{0}': registry is not property initialized\", v55);\n\treturn;\n\tv83 = new System.NullReferenceException();\nL_004E:\n\tv99 = new System.IndexOutOfRangeException();\n\tgoto L_0053;\n\tv106 = new System.ArrayTypeMismatchException();\nL_0053:\n\tthrow v115;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UnregisterConsoleAction(Action actionDelegate)
		{
			if (registry != null)
			{
				bool flag = registry.Unregister(actionDelegate);
				return;
			}
			object[] array = new object[1];
			if (actionDelegate != null)
			{
				object obj = actionDelegate as object;
			}
			if (array.Length != 0)
			{
				array[0] = actionDelegate;
				Log.w("Can't unregister action '{0}': registry is not property initialized", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x13DB7D8", Offset = "0x13DB7D8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EC6D28]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A8E]) = v41;\nL_0016:\n\tv43 = this.m_registry == 0;\n\tif (v43) goto L_0025;\n\tv50 = LunarConsolePluginInternal.CRegistry::Unregister(this.m_registry, name);\n\treturn;\nL_0025:\n\t// 37 NewArr v55 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv82 = name == 0;\n\tif (v82) goto L_0032;\n\t// 46 IsInst v87 @ X0_v16, typeof(System.Object), name @ X1 (System.String)\nL_0032:\n\tv94 = v55.Length == 0;\n\tif (v94) goto L_004E;\n\tv55[0] = name;\n\tgoto L_004B;\n\tv107 = *([v102 @ X0_v11+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_004B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v102, v88, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004B:\n\tLunarConsolePluginInternal.Log::w(\"Can't unregister action '{0}': registry is not property initialized\", v55);\n\treturn;\n\tv83 = new System.NullReferenceException();\nL_004E:\n\tv99 = new System.IndexOutOfRangeException();\n\tgoto L_0053;\n\tv106 = new System.ArrayTypeMismatchException();\nL_0053:\n\tthrow v115;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UnregisterConsoleAction(string name)
		{
			if (registry != null)
			{
				bool flag = registry.Unregister(name);
				return;
			}
			object[] array = new object[1];
			if (name != null)
			{
				object obj = name as object;
			}
			if (array.Length != 0)
			{
				array[0] = name;
				Log.w("Can't unregister action '{0}': registry is not property initialized", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x13DB984", Offset = "0x13DB984", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED3BD8]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, target, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A8F]) = v41;\nL_0016:\n\tv43 = this.m_registry == 0;\n\tif (v43) goto L_0025;\n\tv50 = LunarConsolePluginInternal.CRegistry::UnregisterAll(this.m_registry, target);\n\treturn;\nL_0025:\n\t// 37 NewArr v55 @ X0_v4 (System.Object[]), typeof(System.Object[]), 1\n\tv82 = target == 0;\n\tif (v82) goto L_0032;\n\t// 46 IsInst v87 @ X0_v16, typeof(System.Object), target @ X1 (System.Object)\nL_0032:\n\tv94 = v55.Length == 0;\n\tif (v94) goto L_004E;\n\tv55[0] = target;\n\tgoto L_004B;\n\tv107 = *([v102 @ X0_v11+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_004B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v102, v88, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004B:\n\tLunarConsolePluginInternal.Log::w(\"Can't unregister actions for target '{0}': registry is not property initialized\", v55);\n\treturn;\n\tv83 = new System.NullReferenceException();\nL_004E:\n\tv99 = new System.IndexOutOfRangeException();\n\tgoto L_0053;\n\tv106 = new System.ArrayTypeMismatchException();\nL_0053:\n\tthrow v115;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UnregisterAllConsoleActions(object target)
		{
			if (registry != null)
			{
				bool flag = registry.UnregisterAll(target);
				return;
			}
			object[] array = new object[1];
			if (target != null)
			{
				object obj = target as object;
			}
			if (array.Length != 0)
			{
				array[0] = target;
				Log.w("Can't unregister actions for target '{0}': registry is not property initialized", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x13DBB34", Offset = "0x13DBB34", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Behaviour::set_enabled(this, enabled);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetConsoleInstanceEnabled(bool enabled)
		{
			base.enabled = enabled;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x13DC0C8", Offset = "0x13DC0C8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEC018]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A91]) = v38;\nL_0016:\n\tv42 = new LunarConsolePlugin.LunarConsoleSettings();\n\tLunarConsolePlugin.LunarConsoleSettings::.ctor(v42);\n\tthis.m_settings = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LunarConsole()
		{
			LunarConsoleSettings settings = new LunarConsoleSettings();
			m_settings = settings;
		}
	}
}
