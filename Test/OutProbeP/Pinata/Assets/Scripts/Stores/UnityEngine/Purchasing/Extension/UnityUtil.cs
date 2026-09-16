using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;

namespace UnityEngine.Purchasing.Extension
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x72C7FC", Offset = "0x72C7FC")]
	[HideInInspector]
	[Token(Token = "0x2000098")]
	internal class UnityUtil : MonoBehaviour, IUtil
	{
		[Token(Token = "0x400021F")]
		private static List<Action> s_Callbacks;

		[Token(Token = "0x4000220")]
		private static bool s_CallbacksPending;

		[Token(Token = "0x4000221")]
		private static List<RuntimePlatform> s_PcControlledPlatforms;

		[Token(Token = "0x4000222")]
		[FieldOffset(Offset = "0x18")]
		private List<Action<bool>> pauseListeners;

		[Token(Token = "0x1700005A")]
		public DateTime currentTime
		{
			[Token(Token = "0x6000271")]
			[Address(RVA = "0xC5DB2C", Offset = "0xC5DB2C", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE2D40]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023311]) = v35;\nL_0017:\n\tgoto L_0022;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\treturnVal1 = System.DateTime::get_Now();\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DateTime.Now;
			}
		}

		[Token(Token = "0x1700005B")]
		public string persistentDataPath
		{
			[Token(Token = "0x6000272")]
			[Address(RVA = "0xC5DB8C", Offset = "0xC5DB8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_persistentDataPath();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Application.persistentDataPath;
			}
		}

		[Token(Token = "0x1700005C")]
		public string deviceUniqueIdentifier
		{
			[Token(Token = "0x6000273")]
			[Address(RVA = "0xC5DB94", Offset = "0xC5DB94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SystemInfo.deviceUniqueIdentifier;
			}
		}

		[Token(Token = "0x1700005D")]
		public string unityVersion
		{
			[Token(Token = "0x6000274")]
			[Address(RVA = "0xC5DB9C", Offset = "0xC5DB9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_unityVersion();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Application.unityVersion;
			}
		}

		[Token(Token = "0x1700005E")]
		public string cloudProjectId
		{
			[Token(Token = "0x6000275")]
			[Address(RVA = "0xC5DBA4", Offset = "0xC5DBA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_cloudProjectId();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Application.cloudProjectId;
			}
		}

		[Token(Token = "0x1700005F")]
		public string userId
		{
			[Token(Token = "0x6000276")]
			[Address(RVA = "0xC5DBAC", Offset = "0xC5DBAC", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = *([1ECCDB8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023312]) = v35;\nL_001E:\n\treturnVal1 = UnityEngine.PlayerPrefs::GetString(\"unity.cloud_userid\", v41.Empty);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PlayerPrefs.GetString("unity.cloud_userid", string.Empty);
			}
		}

		[Token(Token = "0x17000060")]
		public string gameVersion
		{
			[Token(Token = "0x6000277")]
			[Address(RVA = "0xC5DC0C", Offset = "0xC5DC0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_version();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Application.version;
			}
		}

		[Token(Token = "0x17000061")]
		public ulong sessionId
		{
			[Token(Token = "0x6000278")]
			[Address(RVA = "0xC5DC14", Offset = "0xC5DC14", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE7670]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023313]) = v35;\nL_0018:\n\tv43 = UnityEngine.PlayerPrefs::GetString(\"unity.player_sessionid\", \"0\");\n\treturnVal1 = System.UInt64::Parse(v43);\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string s = PlayerPrefs.GetString("unity.player_sessionid", "0");
				return ulong.Parse(s);
			}
		}

		[Token(Token = "0x17000062")]
		public RuntimePlatform platform
		{
			[Token(Token = "0x6000279")]
			[Address(RVA = "0xC5DC74", Offset = "0xC5DC74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_platform();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Application.platform;
			}
		}

		[Token(Token = "0x17000063")]
		public bool isEditor
		{
			[Token(Token = "0x600027A")]
			[Address(RVA = "0xC5DC7C", Offset = "0xC5DC7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_isEditor();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Application.isEditor;
			}
		}

		[Token(Token = "0x17000064")]
		public string deviceModel
		{
			[Token(Token = "0x600027B")]
			[Address(RVA = "0xC5DC84", Offset = "0xC5DC84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.SystemInfo::get_deviceModel();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SystemInfo.deviceModel;
			}
		}

		[Token(Token = "0x17000065")]
		public string deviceName
		{
			[Token(Token = "0x600027C")]
			[Address(RVA = "0xC5DC8C", Offset = "0xC5DC8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.SystemInfo::get_deviceName();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SystemInfo.deviceName;
			}
		}

		[Token(Token = "0x17000066")]
		public DeviceType deviceType
		{
			[Token(Token = "0x600027D")]
			[Address(RVA = "0xC5DC94", Offset = "0xC5DC94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.SystemInfo::get_deviceType();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SystemInfo.deviceType;
			}
		}

		[Token(Token = "0x17000067")]
		public string operatingSystem
		{
			[Token(Token = "0x600027E")]
			[Address(RVA = "0xC5DC9C", Offset = "0xC5DC9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.SystemInfo::get_operatingSystem();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SystemInfo.operatingSystem;
			}
		}

		[Token(Token = "0x17000068")]
		public int screenWidth
		{
			[Token(Token = "0x600027F")]
			[Address(RVA = "0xC5DCA4", Offset = "0xC5DCA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Screen::get_width();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Screen.width;
			}
		}

		[Token(Token = "0x17000069")]
		public int screenHeight
		{
			[Token(Token = "0x6000280")]
			[Address(RVA = "0xC5DCAC", Offset = "0xC5DCAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Screen::get_height();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Screen.height;
			}
		}

		[Token(Token = "0x1700006A")]
		public float screenDpi
		{
			[Token(Token = "0x6000281")]
			[Address(RVA = "0xC5DCB4", Offset = "0xC5DCB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Screen::get_dpi();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Screen.dpi;
			}
		}

		[Token(Token = "0x1700006B")]
		public string screenOrientation
		{
			[Token(Token = "0x6000282")]
			[Address(RVA = "0xC5DCBC", Offset = "0xC5DCBC", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv16 = *([1EE69D8]);\n\tv17 = *([v16 @ X8_v9]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023314]) = v37;\nL_0013:\n\tv39 = UnityEngine.Screen::get_orientation();\n\t// 26 Box v39 @ X0_v3 (UnityEngine.ScreenOrientation), typeof(UnityEngine.ScreenOrientation), &v39 @ X0_v3 (UnityEngine.ScreenOrientation)\n\tv49 = *([v39 @ X0_v3 (UnityEngine.ScreenOrientation)]);\n\t*([v49 @ X8_v6+160])(v53, v39, *([v49 @ X8_v6+168]), v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv39 = \"il2cpp_vm_object_unbox\"(v39, *([v49 @ X8_v6+168]), v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn v53;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0041: Expected I4, but got O
				//IL_000d: Expected O, but got I4
				ScreenOrientation orientation = Screen.orientation;
				orientation = (ScreenOrientation)(object)orientation;
				object obj = orientation;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ X8_v6+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string result = default(string);
				return result;
			}
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0xAE4E00", Offset = "0xAE4E00", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = *([1EC1800]);\n\tv35 = *([v34 @ X8_v46]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([2022407]) = v54;\nL_0024:\n\tgoto L_002C;\n\tv64 = *([v57 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_002C;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_002C:\n\tv73 = System.Type::GetTypeFromHandle(UnityEngine.GameObject);\n\tgoto L_003D;\n\tv81 = *([v77 @ X8_v10+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_003D;\n\tv91 = v77;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v91, v72, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_003D:\n\tv90 = UnityEngine.Object::FindObjectsOfType(v73);\n\tv93 = v90 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\t// 70 IsInst v99 @ X0_v56 (System.Int32), typeof(UnityEngine.GameObject[]), v90 @ X0_v8 (UnityEngine.Object[])\n\tv111 = v99 == 0;\n\tv106 = ~v111;\n\tif (v106) goto L_0055;\n\tthrow System.InvalidCastException;\nL_0055:\n\tgoto L_0059;\n\tv125 = v119;\n\tv126 = System.Collections.Generic.List`1<T>::Add(v125, v113, v37);\nL_0059:\n\tv129 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv134 = System.Collections.Generic.List`1<T>::.ctor(v129);\n\tv328 = *([v117 @ X20_v4 (System.Int32)+18]);\n\tv147 = *([v117 @ X20_v4 (System.Int32)+18]) < 1;\n\tif (v147) goto L_00FC;\nL_0071:\n\tv329 = v174 < v328;\n\tv330 = ~v329;\n\tif (v330) goto L_0108;\n\tv360 = v174 << 3;\n\tv383 = v117 + v360;\n\tv378 = UnityEngine.GameObject::GetComponents(*([v383 @ X8_v24 (System.Int32)+20]));\n\tv395 = v378.Length;\n\tv436 = v378.Length < 1;\n\tif (v436) goto L_00E6;\nL_0093:\n\tv477 = v166 < v395;\n\tv222 = ~v477;\n\tif (v222) goto L_0108;\n\tgoto L_00AB;\n\tv482 = v162;\n\tv483 = UnityEngine.GameObject::GetComponents(v482, v391);\nL_00AB:\n\t// 171 IsInst v238 @ X0_v34, typeof(T), v378[v166 @ X27_v10 (System.Int32)]\n\tv486 = v238 == 0;\n\tif (v486) goto L_00D8;\n\tgoto L_00BD;\n\tv502 = v497;\n\tv503 = System.Collections.Generic.List`1<T>::Add(v502, v234, v150);\nL_00BD:\n\t// 189 IsInst v507 @ X0_v38, typeof(T), v378[v166 @ X27_v10 (System.Int32)]\n\tgoto L_00C8;\n\tv513 = v278;\n\tv514 = System.Collections.Generic.List`1<T>::Add(v513, v506, v150);\nL_00C8:\n\tv516 = v507 == 0;\n\tif (v516) goto L_FFFFFFFF;\n\t// 204 IsInst v300 @ X0_v44 (T), typeof(T), v507 @ X0_v38\n\tv519 = v300 == 0;\n\tv302 = ~v519;\n\tif (v302) goto L_00D7;\n\tgoto L_0110;\nL_00D7:\n\tv490 = System.Collections.Generic.List`1<T>::Add(v129, v493);\nL_00D8:\n\tv395 = v378.Length;\n\tv166 = v166 + 1;\n\tv444 = v166 < v378.Length;\n\tif (v444) goto L_0093;\nL_00E6:\n\tv328 = *([v117 @ X20_v4 (System.Int32)+18]);\n\tv174 = v174 + 1;\n\tv259 = v174 < *([v117 @ X20_v4 (System.Int32)+18]);\n\tif (v259) goto L_0071;\nL_00FC:\n\tv344 = Il2CppMethodInfo;\n\tv351 = *([v344 @ X1_v10 (Il2CppMethodInfo)]);\n\t// 263 IndirectJump v351 @ X2_v5, v129 @ X0_v12 (System.Collections.Generic.List`1<T>), v129 @ X0_v12 (System.Collections.Generic.List`1<T>), methodof(System.Collections.Generic.List`1<T>::ToArray), v351 @ X2_v5, v38 @ X3, v39 @ X4, v40 @ X5, v41 @ X6, v42 @ X7, v43 @ V0, v44 @ V1, v45 @ V2, v46 @ V3, v47 @ V4, v48 @ V5, v49 @ V6, v50 @ V7\nL_0108:\n\tv396 = new System.IndexOutOfRangeException();\n\tthrow v396;\n\tthrow System.NullReferenceException;\nL_0110:\n\tv307 = new System.InvalidCastException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T[] GetAnyComponentsOfType<T>() where T : class
		{
			//IL_004f: Expected I4, but got O
			//IL_0267: Expected O, but got I
			//IL_0116: Expected O, but got I
			Type typeFromHandle = typeof(GameObject);
			Object[] array = Object.FindObjectsOfType(typeFromHandle);
			int num2;
			if (array != null)
			{
				int num = (int)(array as GameObject[]);
				bool flag = num == 0;
				bool flag2 = !flag;
				num2 = num;
				if (!flag2)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				num2 = 0;
			}
			List<T> list = new List<T>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X20_v4 (System.Int32)+18]");
			int num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X20_v4 (System.Int32)+18]");
			if (0L < 1L)
			{
				goto IL_0259;
			}
			int num4 = 0;
			while (num4 < num3)
			{
				int num5 = num4 << 3;
				int num6 = num2 + num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ X8_v24 (System.Int32)+20]");
				MonoBehaviour[] components = ((GameObject)0).GetComponents<MonoBehaviour>();
				int num7 = components.Length;
				if (components.Length >= 1)
				{
					int num8 = 0;
					while (num8 < num7)
					{
						object obj = components[num8] as T;
						if (obj != null)
						{
							object obj2 = components[num8] as T;
							T item;
							if (obj2 != null)
							{
								T val = obj2 as T;
								bool flag3 = val == null;
								bool flag4 = !flag3;
								item = val;
								if (!flag4)
								{
									InvalidCastException ex = new InvalidCastException();
									return (T[])(object)new NullReferenceException();
								}
							}
							else
							{
								item = null;
							}
							list.Add(item);
						}
						num7 = components.Length;
						num8++;
						if (num8 < components.Length)
						{
							continue;
						}
						goto IL_0217;
					}
					break;
				}
				goto IL_0217;
				IL_0217:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X20_v4 (System.Int32)+18]");
				num3 = 0;
				num4++;
				int num9 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X20_v4 (System.Int32)+18]");
				if ((long)num9 < 0L)
				{
					continue;
				}
				goto IL_0259;
			}
			goto IL_0271;
			IL_0259:
			IntPtr intPtr = (IntPtr)0;
			object obj3 = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v351 @ X2_v5 (should have been resolved before IL gen)");
			goto IL_0271;
			IL_0271:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0xC5DD50", Offset = "0xC5DD50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.MonoBehaviour::StartCoroutine(this, start);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		object IUtil.InitiateCoroutine(IEnumerator start)
		{
			return StartCoroutine(start);
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0xC5DD58", Offset = "0xC5DD58", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = UnityEngine.Purchasing.Extension.UnityUtil::DelayedCoroutine(this, start, delay);\n\treturn;\n")]
		void IUtil.InitiateCoroutine(IEnumerator start, int delay)
		{
			IEnumerator enumerator = DelayedCoroutine(start, delay);
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0xC5DDE8", Offset = "0xC5DDE8", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC5AF0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, runnable, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2023315]) = v40;\nL_001A:\n\tgoto L_0025;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, runnable, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = UnityEngine.Purchasing.Extension.UnityUtil;\nL_0025:\n\tSystem.Threading.Monitor::Enter(v54.s_Callbacks);\n\tgoto L_0033;\n\tv63 = *([v59 @ X0_v5 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v59, v55, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv67 = UnityEngine.Purchasing.Extension.UnityUtil;\nL_0033:\n\tv72 = v70.s_Callbacks == 0;\n\tif (v72) goto L_0049;\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v70.s_Callbacks, runnable);\n\tv79 = System.Collections.Generic.List`1<System.Action>::Add(v70.s_Callbacks, runnable);\n\tv84.s_CallbacksPending = 1;\n\tSystem.Threading.Monitor::Exit(v54.s_Callbacks);\n\treturn;\nL_0049:\n\tv78 = new System.NullReferenceException();\n\tgoto L_0055;\nL_0055:\n\tgoto L_0066;\n\tv100 = 0x6D2BC0(v78, 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv146 = 0x6D2490(v100, 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tSystem.Threading.Monitor::Exit(v54.s_Callbacks);\n\tv150 = *([v100 @ X0_v13]) == 0;\n\tv135 = ~v150;\n\tif (v135) goto L_006A;\n\treturn;\nL_0066:\n\tv101 = 0x6D2380(v78, 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_006A:\n\tthrow System.TypeLoadException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RunOnMainThread(Action runnable)
		{
			Monitor.Enter(s_Callbacks);
			if (s_Callbacks != null)
			{
				s_Callbacks.Add(runnable);
				s_Callbacks.Add(runnable);
				s_CallbacksPending = true;
				Monitor.Exit(s_Callbacks);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0xC5DF10", Offset = "0xC5DF10", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDED50]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, seconds, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2023316]) = v38;\nL_0016:\n\tv42 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v42, seconds);\n\treturn v42;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public object GetWaitForSeconds(int seconds)
		{
			return new WaitForSeconds(seconds);
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xC5DF74", Offset = "0xC5DF74", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF8DB0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023317]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv62 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v62, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Object::DontDestroyOnLoad(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			GameObject target = base.gameObject;
			Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xACD4E4", Offset = "0xACD4E4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1F096F0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20223C4]) = v38;\nL_001B:\n\tgoto L_0023;\n\tv47 = *([v41 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v41, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_0034;\n\tv64 = *([v60 @ X8_v9+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0034;\n\tv74 = v60;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v74, v55, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\tv73 = UnityEngine.Object::FindObjectOfType(v56);\n\tgoto L_003F;\n\tv82 = v77;\n\tv83 = 0x8907BC(v82, v72, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003F:\n\tv85 = v73 == 0;\n\tif (v85) goto L_FFFFFFFF;\n\t// 67 IsInst returnVal1 @ X0_v10 (T), typeof(T), v73 @ X0_v8 (UnityEngine.Object)\n\tv96 = returnVal1 == 0;\n\tv94 = ~v96;\n\tif (v94) goto L_0050;\n\tthrow System.InvalidCastException;\nL_0050:\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T FindInstanceOfType<T>() where T : MonoBehaviour
		{
			Type typeFromHandle = typeof(T);
			Object obj = Object.FindObjectOfType(typeFromHandle);
			T val;
			if ((object)obj != null)
			{
				val = obj as T;
				if ((object)val == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				val = null;
			}
			return val;
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xACD5CC", Offset = "0xACD5CC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EBB978]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20223C5]) = v42;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v45 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v45, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tv60 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv65 = System.Type::ToString(v60);\n\tv67 = UnityEngine.Resources::Load(v65);\n\tgoto L_003E;\n\tv111 = *([v77 @ X8_v12+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_003E;\n\tv118 = v77;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v118, v66, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003E:\n\tv73 = UnityEngine.Object::Instantiate(v67);\n\t// 71 IsInst v100 @ X0_v17, typeof(UnityEngine.GameObject), v73 @ X0_v15 (UnityEngine.Object)\n\tv103 = v100 == 0;\n\tif (v103) goto L_0062;\n\tv106 = Il2CppMethodInfo;\n\tv144 = *([v106 @ X8_v14 (Il2CppMethodInfo)]);\n\t// 81 IsInst v101 @ X0_v20, typeof(UnityEngine.GameObject), v73 @ X0_v15 (UnityEngine.Object)\n\tv104 = v101 == 0;\n\tif (v104) goto L_0062;\n\t// 94 IndirectJump v144 @ X0_v18, v101 @ X0_v20, v101 @ X0_v20, methodof(UnityEngine.GameObject::GetComponent), v144 @ X0_v18, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tthrow System.NullReferenceException;\nL_0062:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T LoadResourceInstanceOfType<T>() where T : MonoBehaviour
		{
			//IL_0081: Expected O, but got I
			Type typeFromHandle = typeof(T);
			string path = typeFromHandle.ToString();
			Object original = Resources.Load(path);
			Object obj = Object.Instantiate(original);
			object obj2 = obj as GameObject;
			if (obj2 != null)
			{
				IntPtr intPtr = (IntPtr)0;
				object obj3 = (long)intPtr;
				object obj4 = obj as GameObject;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v144 @ X0_v18 (should have been resolved before IL gen)");
				}
			}
			return (T)(object)new InvalidCastException();
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xC5DFF0", Offset = "0xC5DFF0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0DD30]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023318]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = UnityEngine.Purchasing.Extension.UnityUtil;\nL_0021:\n\tv52 = UnityEngine.Application::get_platform();\n\treturnVal1 = System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Contains(v49.s_PcControlledPlatforms, v52);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool PcPlatform()
		{
			RuntimePlatform item = Application.platform;
			return s_PcControlledPlatforms.Contains(item);
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xC5E080", Offset = "0xC5E080", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA4940]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, args, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023319]) = v41;\nL_0018:\n\tv45 = System.String::Format(message, args);\n\tv51 = System.String::Format(\"com.ballatergames.debug - {0}\", v45);\n\tgoto L_002E;\n\tv59 = *([v55 @ X0_v6+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002E;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, v46, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tUnityEngine.Debug::Log(v51);\n\treturn;\n\tgoto L_0038;\n\tgoto L_0038;\nL_0038:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_007D;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1ECC878]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0052;\n\tX20 = 0 | 1;\n\tgoto L_005C;\nL_0052:\n\tX9 = 0x1EFD000;\n\tX8 = *([X20]);\n\tX9 = *([1EFDB30]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0073;\n\tX20 = 0;\nL_005C:\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EBC820]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12E]);\n\tTEMP = X8 & 0x200;\n\tif (TEMP) goto L_0069;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0069;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0069:\n\tX0 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = 0;\n\tX21 = stack[0];\n\t// 112 ShiftStack 48\n\tUnityEngine.Debug::Log(X0, X1);\n\treturn;\nL_0073:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007D:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DebugLog(string message, params object[] args)
		{
			string arg = string.Format(message, args);
			string message2 = $"com.ballatergames.debug - {arg}";
			Debug.Log(message2);
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0xC5DD5C", Offset = "0xC5DD5C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1ECAC90]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, coroutine, delay, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202331A]) = v44;\nL_001A:\n\tv48 = new UnityEngine.Purchasing.Extension.UnityUtil+<DelayedCoroutine>d__49();\n\tSystem.Object::.ctor(v48);\n\tv48.<>1__state = 0;\n\tv48.<>4__this = this;\n\tv48.coroutine = coroutine;\n\tv48.delay = delay;\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator DelayedCoroutine(IEnumerator coroutine, int delay)
		{
			_003CDelayedCoroutine_003Ed__49 _003CDelayedCoroutine_003Ed__50 = null;
			_003CDelayedCoroutine_003Ed__50._003C_003E1__state = 0;
			_003CDelayedCoroutine_003Ed__50._003C_003E4__this = this;
			_003CDelayedCoroutine_003Ed__50.coroutine = coroutine;
			_003CDelayedCoroutine_003Ed__50.delay = delay;
			return _003CDelayedCoroutine_003Ed__50;
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xC5E224", Offset = "0xC5E224", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED9640]);\n\tv19 = *([v18 @ X8_v47]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202331B]) = v39;\nL_0019:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = UnityEngine.Purchasing.Extension.UnityUtil;\nL_0022:\n\tv55 = System.Collections.Generic.List`1<System.Action>::CopyTo(UnityEngine.Purchasing.Extension.UnityUtil, methodInfo);\n\tv57 = ~v53.s_CallbacksPending;\n\tif (v57) goto L_00AA;\n\tgoto L_0034;\n\tv131 = *([v58 @ X0_v6 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_0034;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv135 = UnityEngine.Purchasing.Extension.UnityUtil;\nL_0034:\n\tSystem.Threading.Monitor::Enter(v138.s_Callbacks);\n\tgoto L_0041;\n\tv197 = *([v193 @ X0_v9 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tgoto L_0041;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v193, v139, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv201 = UnityEngine.Purchasing.Extension.UnityUtil;\nL_0041:\n\tv283 = v204.s_Callbacks;\n\tv182 = v283._size == 0;\n\tif (v182) goto L_00B3;\n\tv248 = *([v200 @ X0_v10 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+12F]) & 2;\n\tv249 = v248 == 0;\n\tif (v249) goto L_0059;\n\tv277 = *([v200 @ X0_v10 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]) == 0;\n\tv278 = ~v277;\n\tif (v278) goto L_0059;\n\tv283 = v347.s_Callbacks;\n\tv282 = v347.s_Callbacks == 0;\n\tif (v282) goto L_00C1;\nL_0059:\n\t// 89 NewArr v288 @ X0_v40 (System.Action[]), typeof(System.Action[]), v283._size (System.Int32)\n\tSystem.Collections.Generic.List`1<System.Action>::CopyTo(v273.s_Callbacks, v288);\n\tSystem.Collections.Generic.List`1<System.Action>::Clear(v343.s_Callbacks);\n\tv368 = System.Collections.Generic.List`1<System.Action>::CopyTo(v343.s_Callbacks, Il2CppMethodInfo);\n\tv373.s_CallbacksPending = 0;\n\tSystem.Threading.Monitor::Exit(v138.s_Callbacks);\nL_0082:\n\tv71 = v107.Length < 1;\n\tif (v71) goto L_00AA;\nL_0095:\n\tSystem.Action::Invoke(v107[v398 @ X19_v14 (System.Collections.Generic.List`1<System.Action>)]);\n\tv398 = v398 + 1;\n\tv69 = v398 < v107.Length;\n\tif (v69) goto L_0095;\nL_00AA:\n\treturn;\nL_00B3:\n\tSystem.Threading.Monitor::Exit(v138.s_Callbacks);\n\treturn;\n\tv417 = new System.NullReferenceException();\n\tv412 = new System.IndexOutOfRangeException();\nL_00B9:\n\tthrow System.TypeLoadException;\n\tv246 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv319 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00C1:\n\tv362 = new System.NullReferenceException();\n\tgoto L_00D4;\n\tX20 = 0;\n\tgoto L_00D4;\n\tX20 = 0;\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tX20 = 0;\n\tgoto L_00D4;\nL_00D4:\n\tv150 = 0 != 1;\n\tif (v150) goto L_00E0;\n\tv369 = System.Collections.Generic.List`1<System.Action>::CopyTo(v362, 0);\n\tv375 = System.Collections.Generic.List`1<System.Action>::CopyTo(v369, 0);\n\tSystem.Threading.Monitor::Exit(v138.s_Callbacks);\n\tv379 = *([v369 @ X0_v15 (System.Collections.Generic.List`1<System.Action>)]) == 0;\n\tif (v379) goto L_0082;\n\tgoto L_00B9;\nL_00E0:\n\tv180 = System.Collections.Generic.List`1<System.Action>::CopyTo(v362, 0);\n\treturn;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0232: Expected O, but got I
			//IL_0264: Expected I, but got O
			//IL_00f6: Expected O, but got I
			//IL_0166: Expected O, but got I
			IntPtr intPtr = default(IntPtr);
			((List<Action>)(object)typeof(UnityUtil)).CopyTo((Action[])(long)intPtr);
			if (!s_CallbacksPending)
			{
				return;
			}
			Monitor.Enter(s_Callbacks);
			IntPtr intPtr2 = (IntPtr)typeof(UnityUtil);
			List<Action> list = s_Callbacks;
			Action[] array;
			if (list.Count != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ X0_v10 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ X0_v10 (Il2CppClass<UnityEngine.Purchasing.Extension.UnityUtil>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						list = s_Callbacks;
						if (s_Callbacks == null)
						{
							NullReferenceException ex = new NullReferenceException();
							if (0 == 1)
							{
								((List<Action>)(object)ex).CopyTo((Action[])null);
								List<Action> list2 = default(List<Action>);
								list2.CopyTo(null);
								Monitor.Exit(s_Callbacks);
								bool flag = list2 == null;
								array = null;
								if (!flag)
								{
									throw new TypeLoadException();
								}
								goto IL_011c;
							}
							((List<Action>)(object)ex).CopyTo((Action[])null);
							return;
						}
					}
				}
				Action[] array2 = new Action[list.Count];
				s_Callbacks.CopyTo(array2);
				s_Callbacks.Clear();
				s_Callbacks.CopyTo((Action[])0);
				s_CallbacksPending = false;
				Monitor.Exit(s_Callbacks);
				array = array2;
				goto IL_011c;
			}
			Monitor.Exit(s_Callbacks);
			return;
			IL_011c:
			if (array.Length >= 1)
			{
				List<Action> list3 = null;
				do
				{
					array[(object)list3]();
					list3 = (List<Action>)((long)(IntPtr)list3 + 1L);
				}
				while ((long)(IntPtr)list3 < (long)array.Length);
			}
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xC5E478", Offset = "0xC5E478", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1ECB9E0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, runnable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202331C]) = v41;\nL_0022:\n\tSystem.Collections.Generic.List`1<System.Action`1<System.Boolean>>::Add(this.pauseListeners, runnable);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddPauseListener(Action<bool> runnable)
		{
			pauseListeners.Add(runnable);
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xC5E4E0", Offset = "0xC5E4E0", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EBC900]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, paused, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202331D]) = v41;\nL_0017:\n\tv44 = 0;\n\tv46 = this.pauseListeners == 0;\n\tif (v46) goto L_0039;\n\tv51 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>::GetEnumerator(this.pauseListeners);\nL_0027:\n\tv77 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>+Enumerator<System.Action`1<System.Boolean>>::MoveNext(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Action`1<System.Boolean>>+Enumerator<System.Action`1<System.Boolean>>));\n\tv89 = v77 == 0;\n\tif (v89) goto L_0036;\n\tSystem.Action`1<System.Boolean>::Invoke(0, paused);\n\tgoto L_0027;\nL_0036:\n\tv96 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>+Enumerator<System.Action`1<System.Boolean>>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Action`1<System.Boolean>>+Enumerator<System.Action`1<System.Boolean>>));\n\tgoto L_0058;\n\tv57 = new System.NullReferenceException();\nL_0039:\n\tv67 = new System.NullReferenceException();\n\tgoto L_0045;\n\tgoto L_0045;\nL_0045:\n\tv87 = Il2CppMethodInfo != 1;\n\tif (v87) goto L_0059;\n\tv90 = 0x6D2BC0(v67, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv98 = 0x6D2490(v90, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv102 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>+Enumerator<System.Action`1<System.Boolean>>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Action`1<System.Boolean>>+Enumerator<System.Action`1<System.Boolean>>));\n\tv145 = *([v90 @ X0_v10]) == 0;\n\tv104 = ~v145;\n\tif (v104) goto L_005D;\nL_0058:\n\treturn;\nL_0059:\n\tv91 = 0x6D2380(v67, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005D:\n\tthrow System.TypeLoadException;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnApplicationPause(bool paused)
		{
			List<Action<bool>>.Enumerator enumerator = default(List<Action<bool>>.Enumerator);
			if (pauseListeners != null)
			{
				List<Action<bool>>.Enumerator enumerator2 = pauseListeners.GetEnumerator();
				while (enumerator.MoveNext())
				{
					null(paused);
					IntPtr intPtr = (IntPtr)0;
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0xC5E5FC", Offset = "0xC5E5FC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = System.Type::IsSubclassOf(potentialDescendant, potentialBase);\n\tv36 = potentialDescendant - potentialBase;\n\tv38 = v36 == 0;\n\tv46 = v38 | v20;\n\treturnVal1 = v46 & 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsClassOrSubclass(Type potentialBase, Type potentialDescendant)
		{
			//IL_0020: Expected O, but got I
			bool flag = potentialDescendant.IsSubclassOf(potentialBase);
			object obj = (long)(IntPtr)potentialDescendant - (long)(IntPtr)potentialBase;
			bool flag2 = obj == null;
			int num = ((flag2 || flag) ? 1 : 0);
			return (byte)(num & 1) != 0;
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0xC5E650", Offset = "0xC5E650", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEF3B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202331E]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<System.Action`1<System.Boolean>>();\n\tSystem.Collections.Generic.List`1<System.Action`1<System.Boolean>>::.ctor(v42);\n\tthis.pauseListeners = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UnityUtil()
		{
			List<Action<bool>> list = new List<Action<bool>>();
			pauseListeners = list;
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0xC5E6C0", Offset = "0xC5E6C0", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F10B30]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202331F]) = v39;\nL_0016:\n\tv43 = new System.Collections.Generic.List`1<System.Action>();\n\tSystem.Collections.Generic.List`1<System.Action>::.ctor(v43);\n\tv51.s_Callbacks = v43;\n\tv55 = new System.Collections.Generic.List`1<UnityEngine.RuntimePlatform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::.ctor(v55);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Add(v55, 0xD);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Add(v55, 4);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Add(v55, 0);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Add(v55, 1);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Add(v55, 7);\n\tSystem.Collections.Generic.List`1<UnityEngine.RuntimePlatform>::Add(v55, 2);\n\tv87.s_PcControlledPlatforms = v55;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static UnityUtil()
		{
			List<Action> list = new List<Action>();
			s_Callbacks = list;
			s_PcControlledPlatforms = new List<RuntimePlatform>
			{
				RuntimePlatform.LinuxPlayer,
				RuntimePlatform.OSXDashboardPlayer,
				default(RuntimePlatform),
				RuntimePlatform.OSXPlayer,
				RuntimePlatform.WindowsEditor,
				RuntimePlatform.WindowsPlayer
			};
		}
	}
}
