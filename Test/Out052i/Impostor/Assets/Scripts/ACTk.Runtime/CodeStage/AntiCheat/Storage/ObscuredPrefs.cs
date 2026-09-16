using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Storage
{
	[Token(Token = "0x200000B")]
	public static class ObscuredPrefs
	{
		[Token(Token = "0x200000C")]
		internal enum DataType : byte
		{
			[Token(Token = "0x400003A")]
			Unknown = 0,
			[Token(Token = "0x400003B")]
			Int = 5,
			[Token(Token = "0x400003C")]
			UInt = 10,
			[Token(Token = "0x400003D")]
			String = 15,
			[Token(Token = "0x400003E")]
			Float = 20,
			[Token(Token = "0x400003F")]
			Double = 25,
			[Token(Token = "0x4000040")]
			Decimal = 27,
			[Token(Token = "0x4000041")]
			Long = 30,
			[Token(Token = "0x4000042")]
			ULong = 32,
			[Token(Token = "0x4000043")]
			Bool = 35,
			[Token(Token = "0x4000044")]
			ByteArray = 40,
			[Token(Token = "0x4000045")]
			Vector2 = 45,
			[Token(Token = "0x4000046")]
			Vector3 = 50,
			[Token(Token = "0x4000047")]
			Quaternion = 55,
			[Token(Token = "0x4000048")]
			Color = 60,
			[Token(Token = "0x4000049")]
			Rect = 65
		}

		[Token(Token = "0x200000D")]
		public enum DeviceLockLevel : byte
		{
			[Token(Token = "0x400004B")]
			None = 0,
			[Token(Token = "0x400004C")]
			Soft = 1,
			[Token(Token = "0x400004D")]
			Strict = 2
		}

		[Token(Token = "0x400001E")]
		internal const string PrefsKey = "9978e9f39c218d674463dab9dc728bd6";

		[Token(Token = "0x400001F")]
		private const string RawNotFound = "{not_found}";

		[Token(Token = "0x4000020")]
		private const string FinalLogPrefix = "[ACTk] ObscuredPrefs: ";

		[Token(Token = "0x4000021")]
		private const byte Version = 3;

		[Token(Token = "0x4000022")]
		private static bool alterationReported;

		[Token(Token = "0x4000023")]
		private static bool foreignSavesReported;

		[Token(Token = "0x4000024")]
		private static string deviceId;

		[Token(Token = "0x4000025")]
		private static string cryptoKeyObsolete = "e806f6";

		[Token(Token = "0x4000026")]
		private static string cryptoKeyObsoleteForMigration;

		[Token(Token = "0x4000027")]
		internal static uint deviceIdHash;

		[CompilerGenerated]
		[Token(Token = "0x4000028")]
		private static Action m_OnAlterationDetected;

		[CompilerGenerated]
		[Token(Token = "0x4000029")]
		private static Action m_OnPossibleForeignSavesDetected;

		[Token(Token = "0x400002A")]
		public static bool preservePlayerPrefs = false;

		[Token(Token = "0x400002B")]
		public static DeviceLockLevel lockToDevice;

		[Token(Token = "0x400002C")]
		public static bool readForeignSaves;

		[Token(Token = "0x400002D")]
		public static bool emergencyMode;

		[Token(Token = "0x400002E")]
		private static readonly Type IntType;

		[Token(Token = "0x400002F")]
		private static readonly Type UIntType;

		[Token(Token = "0x4000030")]
		private static readonly Type StringType;

		[Token(Token = "0x4000031")]
		private static readonly Type FloatType;

		[Token(Token = "0x4000032")]
		private static readonly Type DoubleType;

		[Token(Token = "0x4000033")]
		private static readonly Type DecimalType;

		[Token(Token = "0x4000034")]
		private static readonly Type LongType;

		[Token(Token = "0x4000035")]
		private static readonly Type ULongType;

		[Token(Token = "0x4000036")]
		private static readonly Type BoolType;

		[Token(Token = "0x4000037")]
		private static char[] generatedCryptoKey;

		[Token(Token = "0x4000038")]
		private static bool migratingFromACTkV1;

		[Obsolete("Custom crypto key is now obsolete, use only for data recovery from prefs saved with previous version. This property will be removed in future versions.")]
		[Token(Token = "0x17000007")]
		public static string CryptoKey
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0xBD6418", Offset = "0xBD6418", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353FB]) = v34;\nL_0015:\n\tgoto L_001E;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001E:\n\treturn v42.cryptoKeyObsolete;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cryptoKeyObsolete;
			}
			[Token(Token = "0x600003C")]
			[Address(RVA = "0xBD63BC", Offset = "0xBD63BC", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353FA]) = v37;\nL_0017:\n\tgoto L_001B;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001B:\n\tv45.cryptoKeyObsolete = value;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				cryptoKeyObsolete = value;
			}
		}

		[Token(Token = "0x17000008")]
		public static string DeviceId
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0xBD6470", Offset = "0xBD6470", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353FC]) = v34;\nL_0015:\n\tgoto L_001B;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001B:\n\tv65 = System.String::IsNullOrEmpty(v42.deviceId);\n\tv48 = v65 == 0;\n\tif (v48) goto L_002D;\n\tgoto L_0026;\n\tv63 = v46;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v63, v43, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0026:\n\tv56 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetDeviceId();\n\tv53.deviceId = v56;\nL_002D:\n\tgoto L_0037;\n\tv66 = v58;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v66, v43, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv70 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0037:\n\treturn v71.deviceId;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (string.IsNullOrEmpty(deviceId))
				{
					string text = GetDeviceId();
					deviceId = text;
				}
				return deviceId;
			}
			[Token(Token = "0x600003F")]
			[Address(RVA = "0xBD6578", Offset = "0xBD6578", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353FD]) = v37;\nL_0017:\n\tgoto L_001B;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001B:\n\tv45.deviceId = value;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				deviceId = value;
			}
		}

		[Token(Token = "0x17000009")]
		internal static uint DeviceIdHash
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0xBD65D4", Offset = "0xBD65D4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353FE]) = v34;\nL_0015:\n\tgoto L_001B;\n\tv39 = v35;\n\tv40 = \"il2cpp_codegen_runtime_class_init\"(v39, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001B:\n\tv46 = v44.deviceIdHash == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_002C;\n\tgoto L_0024;\n\tv61 = v42;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v61, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tv64 = CodeStage.AntiCheat.Storage.ObscuredPrefs::get_DeviceId();\n\tv54 = CodeStage.AntiCheat.Storage.ObscuredPrefs::CalculateChecksum(v64);\n\tv52.deviceIdHash = v54;\nL_002C:\n\tgoto L_0036;\n\tv65 = v56;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v65, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv69 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0036:\n\treturn v70.deviceIdHash;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (deviceIdHash == 0)
				{
					string input = DeviceId;
					uint num = CalculateChecksum(input);
					deviceIdHash = num;
				}
				return deviceIdHash;
			}
		}

		[Token(Token = "0x14000001")]
		public static event Action OnAlterationDetected
		{
			[CompilerGenerated]
			[Token(Token = "0x6000041")]
			[Address(RVA = "0xBD6784", Offset = "0xBD6784", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = System.Action;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A353FF]) = v42;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0026:\n\tv100 = System.Delegate::Combine(v95, value);\n\tv101 = v100 == 0;\n\tif (v101) goto L_003B;\n\tv113 = *([v100 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v113) goto L_0058;\nL_003B:\n\tgoto L_0041;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v125, v123, v99, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0041:\n\tv133 = v131.alterationReported + 0x28;\n\tv90 = 0xAF4130(v133, v100, v95, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = v95 != v90;\n\tif (v60) goto L_0026;\n\treturn;\nL_0058:\n\tthrow System.InvalidCastException;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_004f: Expected O, but got I4
				Delegate obj = ObscuredPrefs.m_OnAlterationDetected;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if ((object)obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (alterationReported ? 1 : 0) + 40;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000042")]
			[Address(RVA = "0xBD6860", Offset = "0xBD6860", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = System.Action;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35400]) = v42;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0026:\n\tv100 = System.Delegate::Remove(v95, value);\n\tv101 = v100 == 0;\n\tif (v101) goto L_003B;\n\tv113 = *([v100 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v113) goto L_0058;\nL_003B:\n\tgoto L_0041;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v125, v123, v99, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0041:\n\tv133 = v131.alterationReported + 0x28;\n\tv90 = 0xAF4130(v133, v100, v95, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = v95 != v90;\n\tif (v60) goto L_0026;\n\treturn;\nL_0058:\n\tthrow System.InvalidCastException;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_004f: Expected O, but got I4
				Delegate obj = ObscuredPrefs.m_OnAlterationDetected;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if ((object)obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (alterationReported ? 1 : 0) + 40;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000002")]
		public static event Action OnPossibleForeignSavesDetected
		{
			[CompilerGenerated]
			[Token(Token = "0x6000043")]
			[Address(RVA = "0xBD693C", Offset = "0xBD693C", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = System.Action;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35401]) = v42;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0026:\n\tv100 = System.Delegate::Combine(v95, value);\n\tv101 = v100 == 0;\n\tif (v101) goto L_003B;\n\tv113 = *([v100 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v113) goto L_0058;\nL_003B:\n\tgoto L_0041;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v125, v123, v99, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0041:\n\tv133 = v131.alterationReported + 0x30;\n\tv90 = 0xAF4130(v133, v100, v95, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = v95 != v90;\n\tif (v60) goto L_0026;\n\treturn;\nL_0058:\n\tthrow System.InvalidCastException;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_004f: Expected O, but got I4
				Delegate obj = ObscuredPrefs.m_OnPossibleForeignSavesDetected;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if ((object)obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (alterationReported ? 1 : 0) + 48;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000044")]
			[Address(RVA = "0xBD6A18", Offset = "0xBD6A18", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = System.Action;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35402]) = v42;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0026:\n\tv100 = System.Delegate::Remove(v95, value);\n\tv101 = v100 == 0;\n\tif (v101) goto L_003B;\n\tv113 = *([v100 @ X0_v6 (System.Delegate)]) != System.Action;\n\tif (v113) goto L_0058;\nL_003B:\n\tgoto L_0041;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v125, v123, v99, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0041:\n\tv133 = v131.alterationReported + 0x30;\n\tv90 = 0xAF4130(v133, v100, v95, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = v95 != v90;\n\tif (v60) goto L_0026;\n\treturn;\nL_0058:\n\tthrow System.InvalidCastException;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_004f: Expected O, but got I4
				Delegate obj = ObscuredPrefs.m_OnPossibleForeignSavesDetected;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if ((object)obj2 != null && (object)obj2.GetType() != typeof(Action))
					{
						break;
					}
					object obj3 = (alterationReported ? 1 : 0) + 48;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0xBD6AF4", Offset = "0xBD6AF4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = \"[ACTk] ObscuredPrefs: ForceLockToDeviceInit() is called, but device ID is already obtained!\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A35403]) = v35;\nL_001B:\n\tgoto L_0020;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv45 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0020:\n\tv48 = v46.deviceIdHash == 0;\n\tif (v48) goto L_0037;\n\tgoto L_0032;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] ObscuredPrefs: ForceLockToDeviceInit() is called, but device ID is already obtained!\");\n\treturn;\nL_0037:\n\tgoto L_0039;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v44, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tv71 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetDeviceId();\n\tv73.deviceId = v71;\n\tv74 = CodeStage.AntiCheat.Storage.ObscuredPrefs::CalculateChecksum(v71);\n\tv81.deviceIdHash = v74;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ForceLockToDeviceInit()
		{
			if (deviceIdHash != 0)
			{
				Debug.LogWarning("[ACTk] ObscuredPrefs: ForceLockToDeviceInit() is called, but device ID is already obtained!");
				return;
			}
			uint num = CalculateChecksum(deviceId = GetDeviceId());
			deviceIdHash = num;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0xBD6BC8", Offset = "0xBD6BC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::SetString(encryptedKey, encryptedValue);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetRawValue(string encryptedKey, string encryptedValue)
		{
			PlayerPrefs.SetString(encryptedKey, encryptedValue);
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0xBD6BD0", Offset = "0xBD6BD0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, encryptedKey, encryptedValue, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35404]) = v43;\nL_0017:\n\t*([encryptedValue @ X2 (System.String&)]) = 0;\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, encryptedKey, encryptedValue, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001F:\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\t*([encryptedKey @ X1 (System.String&)]) = v51;\n\tv53 = UnityEngine.PlayerPrefs::HasKey(v51);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tv59 = UnityEngine.PlayerPrefs::GetString(*([encryptedKey @ X1 (System.String&)]));\n\t*([encryptedValue @ X2 (System.String&)]) = v59;\nL_0033:\n\treturn v53;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool GetRawValue(string key, out string encryptedKey, out string encryptedValue)
		{
			encryptedKey = null;
			encryptedValue = null;
			ref string reference = ref *(string*)null;
			string text = EncryptKey(key);
			ref string reference2 = ref *(string*)text;
			bool flag = PlayerPrefs.HasKey(text);
			if (flag)
			{
				string text2 = PlayerPrefs.GetString(encryptedKey);
				reference = ref *(string*)text2;
			}
			return flag;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0xBD6CE4", Offset = "0xBD6CE4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A35405]) = v33;\nL_0012:\n\tv36 = UnityEngine.PlayerPrefs::HasKey(key);\n\tv38 = v36 == 0;\n\tif (v38) goto L_0022;\n\treturn 1;\nL_0022:\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v45, v35, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0025:\n\tv64 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\treturnVal2 = UnityEngine.PlayerPrefs::HasKey(v64);\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool HasKey(string key)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return true;
			}
			string key2 = EncryptKey(key);
			return PlayerPrefs.HasKey(key2);
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0xBD6D60", Offset = "0xBD6D60", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35406]) = v37;\nL_0017:\n\tgoto L_001A;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001A:\n\tv45 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tUnityEngine.PlayerPrefs::DeleteKey(v45);\n\tv50 = ~v48.preservePlayerPrefs;\n\tif (v50) goto L_002F;\n\treturn;\nL_002F:\n\tUnityEngine.PlayerPrefs::DeleteKey(key);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DeleteKey(string key)
		{
			string key2 = EncryptKey(key);
			PlayerPrefs.DeleteKey(key2);
			if (!preservePlayerPrefs)
			{
				PlayerPrefs.DeleteKey(key);
			}
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0xBD6DE4", Offset = "0xBD6DE4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = \"9978e9f39c218d674463dab9dc728bd6\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A35407]) = v39;\nL_0019:\n\tUnityEngine.PlayerPrefs::DeleteKey(\"9978e9f39c218d674463dab9dc728bd6\");\n\tgoto L_0024;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, v41, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv50 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0024:\n\tv51.generatedCryptoKey = 0;\n\tv51.deviceIdHash = 0;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DeleteCryptoKey()
		{
			PlayerPrefs.DeleteKey("9978e9f39c218d674463dab9dc728bd6");
			generatedCryptoKey = null;
			deviceIdHash = 0u;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0xBD6E60", Offset = "0xBD6E60", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35408]) = v34;\nL_0012:\n\tUnityEngine.PlayerPrefs::DeleteAll();\n\tgoto L_001D;\n\tv40 = \"il2cpp_codegen_runtime_class_init\"(v36, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv42 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001D:\n\tv43.generatedCryptoKey = 0;\n\tv43.deviceIdHash = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DeleteAll()
		{
			PlayerPrefs.DeleteAll();
			generatedCryptoKey = null;
			deviceIdHash = 0u;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0xBD6EC4", Offset = "0xBD6EC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::Save();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Save()
		{
			PlayerPrefs.Save();
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0xBD6ECC", Offset = "0xBD6ECC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35409]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v53, v58);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetInt(string key, int value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0xBD6F64", Offset = "0xBD6F64", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3540A]) = v41;\nL_001C:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv54 = UnityEngine.PlayerPrefs::HasKey(v51);\n\tv56 = v54 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0064;\n\tv60 = UnityEngine.PlayerPrefs::HasKey(key);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0057;\n\tv93 = UnityEngine.PlayerPrefs::GetInt(key, defaultValue);\n\tgoto L_003C;\n\tv130 = v97;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v130, v91, v92, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv133 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_003C:\n\tv136 = ~v134.preservePlayerPrefs;\n\tv137 = ~v136;\n\tif (v137) goto L_0052;\n\tgoto L_0047;\n\tv144 = v125;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v144, v91, v92, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0047:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetInt(key, v93);\n\tUnityEngine.PlayerPrefs::DeleteKey(key);\nL_0052:\n\treturn v93;\nL_0057:\n\tgoto L_005D;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, v59, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv104 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_005D:\n\tv64 = CodeStage.AntiCheat.Storage.ObscuredPrefs::MigrateFromACTkV1Internal(key, v68.cryptoKeyObsolete);\nL_0064:\n\tgoto L_0071;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v69, v61, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0071:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v51, defaultValue, 0);\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetInt(string key, int defaultValue = 0)
		{
			string text = EncryptKey(key);
			if (!PlayerPrefs.HasKey(text))
			{
				if (PlayerPrefs.HasKey(key))
				{
					int num = PlayerPrefs.GetInt(key, defaultValue);
					if (!preservePlayerPrefs)
					{
						SetInt(key, num);
						PlayerPrefs.DeleteKey(key);
					}
					return num;
				}
				bool flag = MigrateFromACTkV1(key, cryptoKeyObsolete);
			}
			return DecryptValue(key, text, defaultValue);
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0xBD7948", Offset = "0xBD7948", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3540B]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v53, v58);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetUInt(string key, uint value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0xBD79E0", Offset = "0xBD79E0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3540C]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v53, defaultValue, 0);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static uint GetUInt(string key, uint defaultValue = 0u)
		{
			string encryptedKey = EncryptKey(key);
			return DecryptValue(key, encryptedKey, defaultValue);
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0xBD7A6C", Offset = "0xBD7A6C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv50 = System.String;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3540D]) = v37;\nL_0018:\n\tv38 = key == 0;\n\tif (v38) goto L_0040;\n\tv44 = value == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_002A;\n\tv58 = v54.Empty;\nL_002A:\n\tgoto L_002D;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v59, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002D:\n\tv69 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv78 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, v58);\n\tUnityEngine.PlayerPrefs::SetString(v69, v78);\n\treturn;\nL_0040:\n\tv65 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v65, \"key\");\n\tthrow v65;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetString(string key, string value)
		{
			if (key != null)
			{
				bool flag = value == null;
				bool flag2 = !flag;
				string value2 = value;
				if (!flag2)
				{
					value2 = string.Empty;
				}
				string key2 = EncryptKey(key);
				string value3 = ObscuredPrefs.EncryptValue<object>(key, (object)value2);
				PlayerPrefs.SetString(key2, value3);
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("key");
			throw ex;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0xBD7B6C", Offset = "0xBD7B6C", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3540E]) = v41;\nL_001C:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv54 = UnityEngine.PlayerPrefs::HasKey(v51);\n\tv56 = v54 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0064;\n\tv60 = UnityEngine.PlayerPrefs::HasKey(key);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0057;\n\tv93 = UnityEngine.PlayerPrefs::GetString(key, defaultValue);\n\tgoto L_003C;\n\tv130 = v97;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v130, v91, v92, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv133 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_003C:\n\tv136 = ~v134.preservePlayerPrefs;\n\tv137 = ~v136;\n\tif (v137) goto L_0052;\n\tgoto L_0047;\n\tv144 = v125;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v144, v91, v92, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0047:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetString(key, v93);\n\tUnityEngine.PlayerPrefs::DeleteKey(key);\nL_0052:\n\treturn v93;\nL_0057:\n\tgoto L_005D;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, v59, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv104 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_005D:\n\tv64 = CodeStage.AntiCheat.Storage.ObscuredPrefs::MigrateFromACTkV1Internal(key, v68.cryptoKeyObsolete);\nL_0064:\n\tgoto L_0071;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v69, v61, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0071:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v51, defaultValue, 0);\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetString(string key, string defaultValue = "")
		{
			string text = EncryptKey(key);
			if (!PlayerPrefs.HasKey(text))
			{
				if (PlayerPrefs.HasKey(key))
				{
					string text2 = PlayerPrefs.GetString(key, defaultValue);
					if (!preservePlayerPrefs)
					{
						SetString(key, text2);
						PlayerPrefs.DeleteKey(key);
					}
					return text2;
				}
				bool flag = MigrateFromACTkV1(key, cryptoKeyObsolete);
			}
			return (string)DecryptValue(key, text, (object)defaultValue, (string)null);
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0xBD7CC0", Offset = "0xBD7CC0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3540F]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v53, v58);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetFloat(string key, float value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0xBD7D58", Offset = "0xBD7D58", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35410]) = v41;\nL_001C:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv54 = UnityEngine.PlayerPrefs::HasKey(v51);\n\tv56 = v54 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0062;\n\tv60 = UnityEngine.PlayerPrefs::HasKey(key);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0055;\n\tv93 = UnityEngine.PlayerPrefs::GetFloat(key, defaultValue);\n\tgoto L_003B;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v97, v92, v25, v26, v27, v28, v29, v30, v93, v31, v32, v33, v34, v35, v36, v37);\n\tv130 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_003B:\n\tv133 = ~v131.preservePlayerPrefs;\n\tv134 = ~v133;\n\tif (v134) goto L_0050;\n\tgoto L_0045;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v129, v92, v25, v26, v27, v28, v29, v30, v93, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetFloat(key, v93);\n\tUnityEngine.PlayerPrefs::DeleteKey(key);\nL_0050:\n\treturn v93;\nL_0055:\n\tgoto L_005B;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, v59, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\n\tv104 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_005B:\n\tv64 = CodeStage.AntiCheat.Storage.ObscuredPrefs::MigrateFromACTkV1Internal(key, v68.cryptoKeyObsolete);\nL_0062:\n\tgoto L_006F;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v69, v61, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\nL_006F:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v51, defaultValue, 0);\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float GetFloat(string key, float defaultValue = 0f)
		{
			string text = EncryptKey(key);
			if (!PlayerPrefs.HasKey(text))
			{
				if (PlayerPrefs.HasKey(key))
				{
					float num = PlayerPrefs.GetFloat(key, defaultValue);
					if (!preservePlayerPrefs)
					{
						SetFloat(key, num);
						PlayerPrefs.DeleteKey(key);
					}
					return num;
				}
				bool flag = MigrateFromACTkV1(key, cryptoKeyObsolete);
			}
			return DecryptValue(key, text, defaultValue);
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0xBD7EA4", Offset = "0xBD7EA4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35411]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, value, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v53, v58);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetDouble(string key, double value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0xBD7F3C", Offset = "0xBD7F3C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35412]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, defaultValue, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v53, defaultValue, 0);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static double GetDouble(string key, double defaultValue = 0.0)
		{
			string encryptedKey = EncryptKey(key);
			return DecryptValue(key, encryptedKey, defaultValue);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0xBD7FC8", Offset = "0xBD7FC8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35413]) = v44;\nL_0020:\n\tgoto L_0023;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0023:\n\tv56 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv62 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v56, v62);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetDecimal(string key, decimal value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0xBD8068", Offset = "0xBD8068", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, defaultValue, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, defaultValue, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35414]) = v44;\nL_0020:\n\tgoto L_0023;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, defaultValue, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0023:\n\tv56 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v56, defaultValue, methodInfo);\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static decimal GetDecimal(string key, decimal defaultValue = 0m)
		{
			//IL_0027: Expected O, but got I
			string encryptedKey = EncryptKey(key);
			IntPtr intPtr = default(IntPtr);
			return DecryptValue(key, encryptedKey, defaultValue, (string)(nint)intPtr);
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0xBD80FC", Offset = "0xBD80FC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35415]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v53, v58);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetLong(string key, long value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0xBD8194", Offset = "0xBD8194", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35416]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v53, defaultValue, 0);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long GetLong(string key, long defaultValue = 0L)
		{
			string encryptedKey = EncryptKey(key);
			return DecryptValue(key, encryptedKey, defaultValue);
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0xBD8220", Offset = "0xBD8220", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35417]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v53, v58);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetULong(string key, ulong value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0xBD82B8", Offset = "0xBD82B8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35418]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v53, defaultValue, 0);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ulong GetULong(string key, ulong defaultValue = 0uL)
		{
			string encryptedKey = EncryptKey(key);
			return DecryptValue(key, encryptedKey, defaultValue);
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0xBD8344", Offset = "0xBD8344", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35419]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v53, v58);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetBool(string key, bool value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0xBD83DC", Offset = "0xBD83DC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3541A]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v53, defaultValue, 0);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetBool(string key, bool defaultValue = false)
		{
			string encryptedKey = EncryptKey(key);
			return DecryptValue(key, encryptedKey, defaultValue);
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0xBD8468", Offset = "0xBD8468", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3541B]) = v40;\nL_0019:\n\tgoto L_001C;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001C:\n\tv48 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv52 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptByteArrayValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v48, v52);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetByteArray(string key, byte[] value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptByteArrayValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0xBD8550", Offset = "0xBD8550", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, defaultValue, defaultLength, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = \"{not_found}\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, defaultValue, defaultLength, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A3541C]) = v44;\nL_0020:\n\tgoto L_0023;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, defaultValue, defaultLength, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0023:\n\tv56 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv59 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetEncryptedPrefsString(key, v56);\n\tv63 = System.String::op_Equality(v59, \"{not_found}\");\n\tv64 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv67 = *([v64 @ X8_v4 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]) == 0;\n\tif (v67) goto L_0041;\n\tv69 = v63 == 0;\n\tif (v69) goto L_004F;\nL_003C:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::ConstructByteArray(defaultValue, defaultLength);\n\treturn returnVal1;\nL_0041:\n\tv98 = v63 == 0;\n\tv74 = ~v98;\n\tif (v74) goto L_003C;\nL_004F:\n\treturnVal2 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptByteArrayValue(key, v59, defaultValue, defaultLength);\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte[] GetByteArray(string key, byte defaultValue = 0, int defaultLength = 0)
		{
			//IL_0048: Expected I, but got O
			string encryptedKey = EncryptKey(key);
			string encryptedPrefsString = GetEncryptedPrefsString(key, encryptedKey);
			bool flag = encryptedPrefsString == "{not_found}";
			nint num = (nint)typeof(ObscuredPrefs);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v4 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]");
			if ((nint)0 != 0)
			{
				if (flag)
				{
					goto IL_008a;
				}
			}
			else if (flag)
			{
				goto IL_008a;
			}
			return DecryptByteArrayValue(key, encryptedPrefsString, defaultValue, defaultLength);
			IL_008a:
			return ConstructByteArray(defaultValue, defaultLength);
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0xBD84E8", Offset = "0xBD84E8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3541D]) = v40;\nL_0019:\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptData(key, value, 0x28);\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string EncryptByteArrayValue(string key, byte[] value)
		{
			return EncryptData(key, value, DataType.ByteArray);
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0xBD8810", Offset = "0xBD8810", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, encryptedInput, defaultValue, defaultLength, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A3541E]) = v46;\nL_001D:\n\tgoto L_0021;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, encryptedInput, defaultValue, defaultLength, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0021:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptData(key, encryptedInput);\n\tv56 = returnVal1 == 0;\n\tif (v56) goto L_0031;\n\treturn returnVal1;\nL_0031:\n\tgoto L_003D;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v64, v54, defaultValue, defaultLength, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003D:\n\treturnVal2 = CodeStage.AntiCheat.Storage.ObscuredPrefs::ConstructByteArray(defaultValue, defaultLength);\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static byte[] DecryptByteArrayValue(string key, string encryptedInput, byte defaultValue, int defaultLength)
		{
			byte[] array = DecryptData(key, encryptedInput);
			if (array != null)
			{
				return array;
			}
			return ConstructByteArray(defaultValue, defaultLength);
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0xBD877C", Offset = "0xBD877C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Byte[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, length, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3541F]) = v40;\nL_0017:\n\t// 23 NewArr returnVal1 @ X0_v3 (System.Byte[]), typeof(System.Byte[]), length @ X1 (System.Int32)\n\tv54 = length < 1;\n\tif (v54) goto L_0047;\nL_0034:\n\treturnVal1[v116 @ X8_v6 (System.Int32)] = value;\n\tv116 = v116 + 1;\n\tv66 = length != v116;\n\tif (v66) goto L_0034;\nL_0047:\n\treturn returnVal1;\n\tv114 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static byte[] ConstructByteArray(byte value, int length)
		{
			byte[] array = new byte[length];
			if (length >= 1)
			{
				int num = 0;
				do
				{
					array[num] = value;
					num++;
				}
				while (length != num);
			}
			return array;
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0xBD8FA0", Offset = "0xBD8FA0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, value, v0, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A35420]) = v43;\nL_001C:\n\tgoto L_001F;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v29, v30, v31, v32, v33, v34, value, v0, v35, v36, v37, v38, v39, v40);\nL_001F:\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv57 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptVector2Value(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v51, v57);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetVector2(string key, Vector2 value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptVector2Value(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0xBD9108", Offset = "0xBD9108", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A35421]) = v39;\nL_0019:\n\tgoto L_0029;\n\tv47 = UnityEngine.Vector2;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = 1;\n\t*([1A35518]) = v51;\nL_0029:\n\tgoto L_0036;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0036:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetVector2(key, v57.zeroVector);\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 GetVector2(string key)
		{
			return GetVector2(key, Vector2.zero);
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0xBD91A0", Offset = "0xBD91A0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv26 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, defaultValue, v0, v35, v36, v37, v38, v39, v40);\n\tv52 = \"{not_found}\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v29, v30, v31, v32, v33, v34, defaultValue, v0, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35422]) = v44;\nL_0021:\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v29, v30, v31, v32, v33, v34, defaultValue, v0, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tv56 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv59 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetEncryptedPrefsString(key, v56);\n\tv63 = System.String::op_Equality(v59, \"{not_found}\");\n\tv65 = v63 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0048;\n\tgoto L_003B;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v67, v60, v61, v30, v31, v32, v33, v34, defaultValue, v0, v35, v36, v37, v38, v39, v40);\nL_003B:\n\tv75 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptVector2Value(key, v59, defaultValue);\nL_0048:\n\treturn v81;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 GetVector2(string key, Vector2 defaultValue)
		{
			string encryptedKey = EncryptKey(key);
			string encryptedPrefsString = GetEncryptedPrefsString(key, encryptedKey);
			bool flag = encryptedPrefsString == "{not_found}";
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Vector2 result = defaultValue;
			if (!flag3)
			{
				Vector2 vector = DecryptVector2Value(key, encryptedPrefsString, defaultValue);
				result = vector;
			}
			return result;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0xBD9028", Offset = "0xBD9028", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = System.Byte[];\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v39, v40, v41, v42, v43, v44);\n\tv53 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A35423]) = v48;\nL_0020:\n\t// 32 NewArr v51 @ X0_v3 (System.Byte[]), typeof(System.Byte[]), 8\n\tv57 = System.BitConverter::GetBytes(value);\n\tSystem.Buffer::BlockCopy(v57, 0, v51, 0, 4);\n\tv65 = System.BitConverter::GetBytes(value.y);\n\tSystem.Buffer::BlockCopy(v65, 0, v51, 4, 4);\n\tgoto L_0045;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v71, v68, v69, v66, v67, v70, v37, v38, v63, v0, v39, v40, v41, v42, v43, v44);\nL_0045:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptData(key, v51, 0x2D);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string EncryptVector2Value(string key, Vector2 value)
		{
			byte[] array = new byte[8];
			Vector2 vector = default(Vector2);
			byte[] bytes = BitConverter.GetBytes(vector.x);
			Buffer.BlockCopy(bytes, 0, array, 0, 4);
			byte[] bytes2 = BitConverter.GetBytes(value.y);
			Buffer.BlockCopy(bytes2, 0, array, 4, 4);
			return EncryptData(key, array, DataType.Vector2);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0xBD9270", Offset = "0xBD9270", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, encryptedInput, methodInfo, v33, v34, v35, v36, v37, defaultValue, v0, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A35424]) = v46;\nL_001E:\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, encryptedInput, methodInfo, v33, v34, v35, v36, v37, defaultValue, v0, v38, v39, v40, v41, v42, v43);\nL_0022:\n\tv55 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptData(key, encryptedInput);\n\tv56 = v55 == 0;\n\tif (v56) goto L_0039;\n\tv60 = System.BitConverter::ToSingle(v55, 0);\n\tv62 = System.BitConverter::ToSingle(v55, 4);\nL_0039:\n\treturn v70;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Vector2 DecryptVector2Value(string key, string encryptedInput, Vector2 defaultValue)
		{
			//IL_006c: Expected O, but got F4
			byte[] array = DecryptData(key, encryptedInput);
			bool flag = array == null;
			Vector2 result = defaultValue;
			if (!flag)
			{
				float num = BitConverter.ToSingle(array, 0);
				float num2 = BitConverter.ToSingle(array, 4);
				result = (Vector2)num;
			}
			return result;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0xBD931C", Offset = "0xBD931C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v2, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A35425]) = v46;\nL_001F:\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v33, v34, v35, v36, v37, v38, value, v0, v2, v39, v40, v41, v42, v43);\nL_0022:\n\tv54 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv61 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptVector3Value(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v54, v61);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetVector3(string key, Vector3 value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptVector3Value(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0xBD94C4", Offset = "0xBD94C4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A35426]) = v41;\nL_001A:\n\tgoto L_002B;\n\tv49 = UnityEngine.Vector3;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = 1;\n\t*([1A35519]) = v53;\nL_002B:\n\tgoto L_003A;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003A:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetVector3(key, v59.zeroVector);\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 GetVector3(string key)
		{
			return GetVector3(key, Vector3.zero);
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0xBD956C", Offset = "0xBD956C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv30 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, defaultValue, v0, v2, v39, v40, v41, v42, v43);\n\tv55 = \"{not_found}\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v33, v34, v35, v36, v37, v38, defaultValue, v0, v2, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35427]) = v47;\nL_0024:\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v33, v34, v35, v36, v37, v38, defaultValue, v0, v2, v39, v40, v41, v42, v43);\nL_0027:\n\tv59 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv62 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetEncryptedPrefsString(key, v59);\n\tv66 = System.String::op_Equality(v62, \"{not_found}\");\n\tv68 = v66 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0050;\n\tgoto L_003F;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v70, v63, v64, v34, v35, v36, v37, v38, defaultValue, v0, v2, v39, v40, v41, v42, v43);\nL_003F:\n\tv78 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptVector3Value(key, v62, defaultValue);\nL_0050:\n\treturn v84;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 GetVector3(string key, Vector3 defaultValue)
		{
			string encryptedKey = EncryptKey(key);
			string encryptedPrefsString = GetEncryptedPrefsString(key, encryptedKey);
			bool flag = encryptedPrefsString == "{not_found}";
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Vector3 result = defaultValue;
			if (!flag3)
			{
				Vector3 vector = DecryptVector3Value(key, encryptedPrefsString, defaultValue);
				result = vector;
			}
			return result;
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0xBD93B4", Offset = "0xBD93B4", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = System.Byte[];\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v43, v44, v45, v46, v47);\n\tv56 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A35428]) = v51;\nL_0023:\n\t// 35 NewArr v54 @ X0_v3 (System.Byte[]), typeof(System.Byte[]), 12\n\tv60 = System.BitConverter::GetBytes(value);\n\tSystem.Buffer::BlockCopy(v60, 0, v54, 0, 4);\n\tv68 = System.BitConverter::GetBytes(value.y);\n\tSystem.Buffer::BlockCopy(v68, 0, v54, 4, 4);\n\tv76 = System.BitConverter::GetBytes(value.z);\n\tSystem.Buffer::BlockCopy(v76, 0, v54, 8, 4);\n\tgoto L_0052;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v82, v79, v80, v77, v78, v81, v41, v42, v74, v0, v2, v43, v44, v45, v46, v47);\nL_0052:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptData(key, v54, 0x32);\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string EncryptVector3Value(string key, Vector3 value)
		{
			byte[] array = new byte[12];
			Vector3 vector = default(Vector3);
			byte[] bytes = BitConverter.GetBytes(vector.x);
			Buffer.BlockCopy(bytes, 0, array, 0, 4);
			byte[] bytes2 = BitConverter.GetBytes(value.y);
			Buffer.BlockCopy(bytes2, 0, array, 4, 4);
			byte[] bytes3 = BitConverter.GetBytes(value.z);
			Buffer.BlockCopy(bytes3, 0, array, 8, 4);
			return EncryptData(key, array, DataType.Vector3);
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0xBD9654", Offset = "0xBD9654", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, encryptedInput, methodInfo, v37, v38, v39, v40, v41, defaultValue, v0, v2, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A35429]) = v49;\nL_0021:\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, encryptedInput, methodInfo, v37, v38, v39, v40, v41, defaultValue, v0, v2, v42, v43, v44, v45, v46);\nL_0025:\n\tv58 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptData(key, encryptedInput);\n\tv59 = v58 == 0;\n\tif (v59) goto L_0043;\n\tv63 = System.BitConverter::ToSingle(v58, 0);\n\tv93 = System.BitConverter::ToSingle(v58, 4);\n\tv65 = System.BitConverter::ToSingle(v58, 8);\nL_0043:\n\treturn v73;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Vector3 DecryptVector3Value(string key, string encryptedInput, Vector3 defaultValue)
		{
			//IL_007e: Expected O, but got F4
			byte[] array = DecryptData(key, encryptedInput);
			bool flag = array == null;
			Vector3 result = defaultValue;
			if (!flag)
			{
				float num = BitConverter.ToSingle(array, 0);
				float num2 = BitConverter.ToSingle(array, 4);
				float num3 = BitConverter.ToSingle(array, 8);
				result = (Vector3)num;
			}
			return result;
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0xBD9724", Offset = "0xBD9724", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A3542A]) = v49;\nL_0022:\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\nL_0025:\n\tv57 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv65 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptQuaternionValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v57, v65);\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetQuaternion(string key, Quaternion value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptQuaternionValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0xBD98FC", Offset = "0xBD98FC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A3542B]) = v43;\nL_001B:\n\tgoto L_002D;\n\tv51 = UnityEngine.Quaternion;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv55 = 1;\n\t*([1A3551A]) = v55;\nL_002D:\n\tgoto L_003E;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003E:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetQuaternion(key, v61.identityQuaternion);\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion GetQuaternion(string key)
		{
			return GetQuaternion(key, Quaternion.identity);
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0xBD99A8", Offset = "0xBD99A8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv34 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\n\tv58 = \"{not_found}\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v37, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A3542C]) = v50;\nL_0027:\n\tgoto L_002A;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v37, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\nL_002A:\n\tv62 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv65 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetEncryptedPrefsString(key, v62);\n\tv69 = System.String::op_Equality(v65, \"{not_found}\");\n\tv71 = v69 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0058;\n\tgoto L_0043;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v73, v66, v67, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\nL_0043:\n\tv81 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptQuaternionValue(key, v65, defaultValue);\nL_0058:\n\treturn v87;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Quaternion GetQuaternion(string key, Quaternion defaultValue)
		{
			string encryptedKey = EncryptKey(key);
			string encryptedPrefsString = GetEncryptedPrefsString(key, encryptedKey);
			bool flag = encryptedPrefsString == "{not_found}";
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Quaternion result = defaultValue;
			if (!flag3)
			{
				Quaternion quaternion = DecryptQuaternionValue(key, encryptedPrefsString, defaultValue);
				result = quaternion;
			}
			return result;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0xBD97C4", Offset = "0xBD97C4", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv38 = System.Byte[];\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, value, v0, v2, v3, v47, v48, v49, v50);\n\tv59 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v41, v42, v43, v44, v45, v46, value, v0, v2, v3, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A3542D]) = v54;\nL_0026:\n\t// 38 NewArr v57 @ X0_v3 (System.Byte[]), typeof(System.Byte[]), 16\n\tv63 = System.BitConverter::GetBytes(value);\n\tSystem.Buffer::BlockCopy(v63, 0, v57, 0, 4);\n\tv71 = System.BitConverter::GetBytes(value.y);\n\tSystem.Buffer::BlockCopy(v71, 0, v57, 4, 4);\n\tv79 = System.BitConverter::GetBytes(value.z);\n\tSystem.Buffer::BlockCopy(v79, 0, v57, 8, 4);\n\tv87 = System.BitConverter::GetBytes(value.w);\n\tSystem.Buffer::BlockCopy(v87, 0, v57, 0xC, 4);\n\tgoto L_005F;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v93, v90, v91, v88, v89, v92, v45, v46, v85, v0, v2, v3, v47, v48, v49, v50);\nL_005F:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptData(key, v57, System.Action`1<UnityEngine.CustomRenderTexture>);\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string EncryptQuaternionValue(string key, Quaternion value)
		{
			//IL_00ba: Expected I4, but got O
			byte[] array = new byte[16];
			Quaternion quaternion = default(Quaternion);
			byte[] bytes = BitConverter.GetBytes(quaternion.x);
			Buffer.BlockCopy(bytes, 0, array, 0, 4);
			byte[] bytes2 = BitConverter.GetBytes(value.y);
			Buffer.BlockCopy(bytes2, 0, array, 4, 4);
			byte[] bytes3 = BitConverter.GetBytes(value.z);
			Buffer.BlockCopy(bytes3, 0, array, 8, 4);
			byte[] bytes4 = BitConverter.GetBytes(value.w);
			Buffer.BlockCopy(bytes4, 0, array, 12, 4);
			return EncryptData(key, array, (DataType)(int)typeof(Action<CustomRenderTexture>));
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0xBD9AA0", Offset = "0xBD9AA0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv38 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, encryptedInput, methodInfo, v41, v42, v43, v44, v45, defaultValue, v0, v2, v3, v46, v47, v48, v49);\n\tv52 = 1;\n\t*([1A3542E]) = v52;\nL_0024:\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v53, encryptedInput, methodInfo, v41, v42, v43, v44, v45, defaultValue, v0, v2, v3, v46, v47, v48, v49);\nL_0028:\n\tv61 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptData(key, encryptedInput);\n\tv62 = v61 == 0;\n\tif (v62) goto L_004D;\n\tv66 = System.BitConverter::ToSingle(v61, 0);\n\tv100 = System.BitConverter::ToSingle(v61, 4);\n\tv104 = System.BitConverter::ToSingle(v61, 8);\n\tv68 = System.BitConverter::ToSingle(v61, 0xC);\nL_004D:\n\treturn v76;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Quaternion DecryptQuaternionValue(string key, string encryptedInput, Quaternion defaultValue)
		{
			//IL_0095: Expected O, but got F4
			byte[] array = DecryptData(key, encryptedInput);
			bool flag = array == null;
			Quaternion result = defaultValue;
			if (!flag)
			{
				float num = BitConverter.ToSingle(array, 0);
				float num2 = BitConverter.ToSingle(array, 4);
				float num3 = BitConverter.ToSingle(array, 8);
				float num4 = BitConverter.ToSingle(array, 12);
				result = (Quaternion)num;
			}
			return result;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0xBD9B8C", Offset = "0xBD9B8C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3542F]) = v40;\nL_0019:\n\tgoto L_001B;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001B:\n\tv47 = value & 0xFF00FF00;\n\tv48 = value & 0xFF;\n\tv49 = v48 << 0x10;\n\tv50 = v47 & 0xFFFFFFFFFF00FFFF;\n\tv51 = v50 | v49;\n\tv53 = value >> 0x10;\n\tv54 = v53 & 0xFF;\n\tv55 = v51 & 0xFFFFFFFFFFFFFF00;\n\tv56 = v55 | v54;\n\tv57 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv61 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptColorValue(key, v56);\n\tUnityEngine.PlayerPrefs::SetString(v57, v61);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetColor(string key, Color32 value)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected I4, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected I4, but got Unknown
			//IL_005c: Expected I4, but got O
			int num = (int)(value & 0xFF00FF00L);
			int num2 = value & 0xFF;
			int num3 = num2 << 16;
			int num4 = num & -16711681;
			int num5 = num4 | num3;
			int num6 = (object)value >> 16;
			int num7 = num6 & 0xFF;
			int num8 = num5 & -256;
			int value2 = num8 | num7;
			string key2 = EncryptKey(key);
			string value3 = EncryptColorValue(key, (uint)value2);
			PlayerPrefs.SetString(key2, value3);
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0xBD9C94", Offset = "0xBD9C94", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35430]) = v37;\nL_0017:\n\tgoto L_001B;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001B:\n\tv46 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetColor(key, 0x1000000);\n\treturnVal1 = v46 & 0xFFFFFFFF;\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color32 GetColor(string key)
		{
			//IL_0013: Expected O, but got I4
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			Color32 color = GetColor(key, (Color32)16777216);
			return (Color32)(color & 0xFFFFFFFFL);
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0xBD9CF4", Offset = "0xBD9CF4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, defaultValue, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, defaultValue, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv58 = \"{not_found}\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, defaultValue, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A35431]) = v43;\nL_0022:\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, defaultValue, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tv56 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv62 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetEncryptedPrefsString(key, v56);\n\tv66 = System.String::op_Equality(v62, \"{not_found}\");\n\tv68 = v66 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0049;\n\tgoto L_003F;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v70, v63, v64, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv85 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v56, 0x1000000, v62);\n\tv101 = v85 & 0xFF00FF00;\n\tv102 = v85 & 0xFF;\n\tv103 = v102 << 0x10;\n\tv104 = v101 & 0xFFFFFFFFFF00FFFF;\n\tv105 = v104 | v103;\n\tv106 = v85 >> 0x10;\n\tv87 = v106 & 0xFF;\n\tv107 = v105 & 0xFFFFFFFFFFFFFF00;\n\tv89 = v107 | v87;\nL_0049:\n\treturnVal1 = v88 & 0xFFFFFFFF;\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color32 GetColor(string key, Color32 defaultValue)
		{
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_009b: Expected I4, but got I8
			//IL_0111: Expected O, but got I4
			string encryptedKey = EncryptKey(key);
			string encryptedPrefsString = GetEncryptedPrefsString(key, encryptedKey);
			bool flag = encryptedPrefsString == "{not_found}";
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Color32 color = defaultValue;
			if (!flag3)
			{
				uint num = DecryptValue(key, encryptedKey, 16777216u, encryptedPrefsString);
				int num2 = (int)((int)num & 0xFF00FF00L);
				int num3 = (int)(num & 0xFF);
				int num4 = num3 << 16;
				int num5 = num2 & -16711681;
				int num6 = num5 | num4;
				int num7 = (int)num >> 16;
				int num8 = num7 & 0xFF;
				int num9 = num6 & -256;
				int num10 = num9 | num8;
				color = (Color32)num10;
			}
			return (Color32)(color & 0xFFFFFFFFL);
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0xBD9C18", Offset = "0xBD9C18", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35432]) = v40;\nL_0017:\n\tv43 = System.BitConverter::GetBytes(value);\n\tgoto L_0029;\n\tv49 = v44;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v49, v42, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0029:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptData(key, v43, 0x3C);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string EncryptColorValue(string key, uint value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			return EncryptData(key, bytes, DataType.Color);
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0xBD9DF0", Offset = "0xBD9DF0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A35433]) = v49;\nL_0022:\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v37, v38, v39, v40, v41, v42, value, v0, v2, v3, v43, v44, v45, v46);\nL_0025:\n\tv57 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv65 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptRectValue(key, value);\n\tUnityEngine.PlayerPrefs::SetString(v57, v65);\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetRect(string key, Rect value)
		{
			string key2 = EncryptKey(key);
			string value2 = EncryptRectValue(key, value);
			PlayerPrefs.SetString(key2, value2);
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0xBD9FC8", Offset = "0xBD9FC8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35434]) = v37;\nL_0017:\n\tgoto L_0023;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\t// 35 MakeStruct v53 @ AGGBDE028_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, 0, 0\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetRect(key, v53);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rect GetRect(string key)
		{
			Rect defaultValue = default(Rect);
			defaultValue.m_XMin = 0f;
			defaultValue.m_YMin = 0f;
			defaultValue.m_Width = 0f;
			defaultValue.m_Height = 0f;
			return GetRect(key, defaultValue);
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0xBDA02C", Offset = "0xBDA02C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv34 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\n\tv58 = \"{not_found}\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v37, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A35435]) = v50;\nL_0027:\n\tgoto L_002A;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v37, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\nL_002A:\n\tv62 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptKey(key);\n\tv65 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetEncryptedPrefsString(key, v62);\n\tv69 = System.String::op_Equality(v65, \"{not_found}\");\n\tv71 = v69 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0058;\n\tgoto L_0043;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v73, v66, v67, v38, v39, v40, v41, v42, defaultValue, v0, v2, v3, v43, v44, v45, v46);\nL_0043:\n\tv81 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptRectValue(key, v65, defaultValue);\nL_0058:\n\treturn v87;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rect GetRect(string key, Rect defaultValue)
		{
			string encryptedKey = EncryptKey(key);
			string encryptedPrefsString = GetEncryptedPrefsString(key, encryptedKey);
			bool flag = encryptedPrefsString == "{not_found}";
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Rect result = defaultValue;
			if (!flag3)
			{
				Rect rect = DecryptRectValue(key, encryptedPrefsString, defaultValue);
				result = rect;
			}
			return result;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0xBD9E90", Offset = "0xBD9E90", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv38 = System.Byte[];\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, value, v0, v2, v3, v47, v48, v49, v50);\n\tv59 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v41, v42, v43, v44, v45, v46, value, v0, v2, v3, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A35436]) = v54;\nL_0026:\n\t// 38 NewArr v57 @ X0_v3 (System.Byte[]), typeof(System.Byte[]), 16\n\tv63 = System.BitConverter::GetBytes(value);\n\tSystem.Buffer::BlockCopy(v63, 0, v57, 0, 4);\n\tv71 = System.BitConverter::GetBytes(value.m_YMin);\n\tSystem.Buffer::BlockCopy(v71, 0, v57, 4, 4);\n\tv79 = System.BitConverter::GetBytes(value.m_Width);\n\tSystem.Buffer::BlockCopy(v79, 0, v57, 8, 4);\n\tv87 = System.BitConverter::GetBytes(value.m_Height);\n\tSystem.Buffer::BlockCopy(v87, 0, v57, 0xC, 4);\n\tgoto L_005F;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v93, v90, v91, v88, v89, v92, v45, v46, v85, v0, v2, v3, v47, v48, v49, v50);\nL_005F:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptData(key, v57, 0x41);\n\treturn returnVal1;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string EncryptRectValue(string key, Rect value)
		{
			byte[] array = new byte[16];
			Rect rect = default(Rect);
			byte[] bytes = BitConverter.GetBytes(rect.m_XMin);
			Buffer.BlockCopy(bytes, 0, array, 0, 4);
			byte[] bytes2 = BitConverter.GetBytes(value.m_YMin);
			Buffer.BlockCopy(bytes2, 0, array, 4, 4);
			byte[] bytes3 = BitConverter.GetBytes(value.m_Width);
			Buffer.BlockCopy(bytes3, 0, array, 8, 4);
			byte[] bytes4 = BitConverter.GetBytes(value.m_Height);
			Buffer.BlockCopy(bytes4, 0, array, 12, 4);
			return EncryptData(key, array, DataType.Rect);
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0xBDA124", Offset = "0xBDA124", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv38 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, encryptedInput, methodInfo, v41, v42, v43, v44, v45, defaultValue, v0, v2, v3, v46, v47, v48, v49);\n\tv52 = 1;\n\t*([1A35437]) = v52;\nL_0024:\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v53, encryptedInput, methodInfo, v41, v42, v43, v44, v45, defaultValue, v0, v2, v3, v46, v47, v48, v49);\nL_0028:\n\tv61 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptData(key, encryptedInput);\n\tv62 = v61 == 0;\n\tif (v62) goto L_004D;\n\tv66 = System.BitConverter::ToSingle(v61, 0);\n\tv100 = System.BitConverter::ToSingle(v61, 4);\n\tv104 = System.BitConverter::ToSingle(v61, 8);\n\tv68 = System.BitConverter::ToSingle(v61, 0xC);\nL_004D:\n\treturn v76;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Rect DecryptRectValue(string key, string encryptedInput, Rect defaultValue)
		{
			//IL_0095: Expected O, but got F4
			byte[] array = DecryptData(key, encryptedInput);
			bool flag = array == null;
			Rect result = defaultValue;
			if (!flag)
			{
				float num = BitConverter.ToSingle(array, 0);
				float num2 = BitConverter.ToSingle(array, 4);
				float num3 = BitConverter.ToSingle(array, 8);
				float num4 = BitConverter.ToSingle(array, 12);
				result = (Rect)num;
			}
			return result;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0xBDA210", Offset = "0xBDA210", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, cryptoKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35438]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, cryptoKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::MigrateFromACTkV1Internal(key, cryptoKey);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool MigrateFromACTkV1(string key, string cryptoKey = "e806f6")
		{
			return MigrateFromACTkV1(key, cryptoKey);
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0xBDA274", Offset = "0xBDA274", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::EncryptDecryptObsolete(key, cryptoKey);\n\treturnVal1 = CodeStage.AntiCheat.Utils.Base64Utils::ToBase64(v2);\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string EncryptKeyWithACTkV1Algorithm(string key, string cryptoKey = "e806f6")
		{
			string value = ObscuredString.EncryptDecrypt(key, cryptoKey);
			return Base64Utils.ToBase64(value);
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0xBDA40C", Offset = "0xBDA40C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35439]) = v34;\nL_0015:\n\tgoto L_001A;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001A:\n\tv44 = v42.OnAlterationDetected == 0;\n\tif (v44) goto L_002A;\n\tgoto L_0024;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv60 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv61 = *([v60 @ X0_v11+B8]);\nL_0024:\n\tv53 = ~v55.alterationReported;\n\tif (v53) goto L_002E;\nL_002A:\n\treturn;\nL_002E:\n\tgoto L_0032;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v51, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv90 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv89 = *([v90 @ X8_v8+B8]);\nL_0032:\n\t;\n\tv79.alterationReported = 1;\n\tSystem.Action::Invoke(v79.OnAlterationDetected);\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SavesTampered()
		{
			if (ObscuredPrefs.OnAlterationDetected != null && !alterationReported)
			{
				alterationReported = true;
				ObscuredPrefs.OnAlterationDetected();
			}
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0xBDA4C4", Offset = "0xBDA4C4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3543A]) = v34;\nL_0015:\n\tgoto L_001A;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001A:\n\tv44 = v42.OnPossibleForeignSavesDetected == 0;\n\tif (v44) goto L_002A;\n\tgoto L_0024;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv60 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv61 = *([v60 @ X0_v11+B8]);\nL_0024:\n\tv53 = ~v55.foreignSavesReported;\n\tif (v53) goto L_002E;\nL_002A:\n\treturn;\nL_002E:\n\tgoto L_0032;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v51, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv90 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv89 = *([v90 @ X8_v8+B8]);\nL_0032:\n\t;\n\tv79.foreignSavesReported = 1;\n\tSystem.Action::Invoke(v79.OnPossibleForeignSavesDetected);\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PossibleForeignSavesDetected()
		{
			if (ObscuredPrefs.OnPossibleForeignSavesDetected != null && !foreignSavesReported)
			{
				foreignSavesReported = true;
				ObscuredPrefs.OnPossibleForeignSavesDetected();
			}
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0xBD6514", Offset = "0xBD6514", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = \"\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3543B]) = v34;\nL_0014:\n\tv38 = System.String::IsNullOrEmpty(\"\");\n\tv40 = v38 == 0;\n\tif (v40) goto L_0024;\n\treturnVal2 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\treturn returnVal2;\nL_0024:\n\treturn \"\";\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetDeviceId()
		{
			if (string.IsNullOrEmpty(""))
			{
				return SystemInfo.deviceUniqueIdentifier;
			}
			return "";
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0xBDA57C", Offset = "0xBDA57C", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv20 = System.Char[];\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv46 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = \"9978e9f39c218d674463dab9dc728bd6\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A3543C]) = v40;\nL_001E:\n\tgoto L_0023;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0023:\n\tv53 = v51.generatedCryptoKey == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0057;\n\tv61 = UnityEngine.PlayerPrefs::GetString(\"9978e9f39c218d674463dab9dc728bd6\");\n\tv88 = System.String::IsNullOrEmpty(v61);\n\tv92 = v88 == 0;\n\tif (v92) goto L_0049;\n\tv99 = CodeStage.AntiCheat.Utils.RandomUtils::GenerateCharArrayKey(0);\n\tgoto L_003E;\n\tv177 = v145;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v177, v69, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv181 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_003E:\n\tv182.generatedCryptoKey = v99;\n\tv184 = CodeStage.AntiCheat.Utils.Base64Utils::ToBase64(v99);\n\tUnityEngine.PlayerPrefs::SetString(\"9978e9f39c218d674463dab9dc728bd6\", v184);\n\tUnityEngine.PlayerPrefs::Save();\n\tgoto L_0057;\nL_0049:\n\tv101 = CodeStage.AntiCheat.Utils.Base64Utils::FromBase64ToChars(v61);\n\tgoto L_0054;\n\tv185 = v147;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v185, v69, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv188 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0054:\n\tv79.generatedCryptoKey = v101;\nL_0057:\n\tv86 = System.String::IsNullOrEmpty(dynamicSuffix);\n\tv90 = v86 == 0;\n\tif (v90) goto L_0069;\n\tgoto L_0063;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v93, v85, v62, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv104 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0063:\n\tv167 = v105.generatedCryptoKey;\n\tgoto L_00A1;\nL_0069:\n\tv109 = System.String::ToCharArray(dynamicSuffix);\n\tgoto L_0074;\n\tv204 = v174;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v204, v108, v62, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv207 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0074:\n\tv139 = v208.generatedCryptoKey;\n\tv125 = v109.Length + v139.Length;\n\t// 127 NewArr v129 @ X0_v15 (System.Char[]), typeof(System.Char[]), v125 @ X1_v6\n\tv140 = v214.generatedCryptoKey;\n\tSystem.Buffer::BlockCopy(v214.generatedCryptoKey, 0, v129, 0, *([v140 @ X8_v16 (System.Array)+18]));\n\tv141 = v216.generatedCryptoKey;\n\tv152 = v141.Length + 1;\n\tSystem.Buffer::BlockCopy(v109, 0, v129, v152, v109.Length);\nL_00A1:\n\treturn v167;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static char[] GetCryptoKey(string dynamicSuffix = null)
		{
			//IL_0090: Expected O, but got I4
			if (generatedCryptoKey == null)
			{
				string value = PlayerPrefs.GetString("9978e9f39c218d674463dab9dc728bd6");
				if (string.IsNullOrEmpty(value))
				{
					string value2 = Base64Utils.ToBase64(generatedCryptoKey = RandomUtils.GenerateCharArrayKey());
					PlayerPrefs.SetString("9978e9f39c218d674463dab9dc728bd6", value2);
					PlayerPrefs.Save();
				}
				else
				{
					char[] array = Base64Utils.FromBase64ToChars(value);
					generatedCryptoKey = array;
				}
			}
			if (!string.IsNullOrEmpty(dynamicSuffix))
			{
				char[] array2 = dynamicSuffix.ToCharArray();
				char[] array3 = generatedCryptoKey;
				object obj = array2.Length + array3.Length;
				char[] array4 = new char[obj];
				Array array5 = generatedCryptoKey;
				char[] src = generatedCryptoKey;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v16 (System.Array)+18]");
				Buffer.BlockCopy(src, 0, array4, 0, 0);
				char[] array6 = generatedCryptoKey;
				int dstOffset = array6.Length + 1;
				Buffer.BlockCopy(array2, 0, array4, dstOffset, array2.Length);
				return array4;
			}
			return generatedCryptoKey;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0xBD6C64", Offset = "0xBD6C64", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3543D]) = v33;\nL_0016:\n\tv39 = System.String::ToCharArray(key);\n\tgoto L_0020;\n\tv46 = v41;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv50 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetCryptoKey(0);\n\tv66 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::InternalEncryptDecrypt(v39, v50);\n\treturnVal2 = CodeStage.AntiCheat.Utils.Base64Utils::ToBase64(v66);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string EncryptKey(string key)
		{
			char[] value = key.ToCharArray();
			char[] cryptoKey = GetCryptoKey();
			char[] value2 = ObscuredString.InternalEncryptDecrypt(value, cryptoKey);
			return Base64Utils.ToBase64(value2);
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0xBD88B8", Offset = "0xBD88B8", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv32 = System.Byte[];\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, cleanBytes, type, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv53 = System.Convert;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, cleanBytes, type, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv167 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, cleanBytes, type, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A3543E]) = v50;\nL_002A:\n\tgoto L_002D;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v59, cleanBytes, type, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_002D:\n\tv171 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetCryptoKey(key);\n\tv175 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptDecryptBytes(cleanBytes, cleanBytes.Length, v171);\n\tv233 = CodeStage.AntiCheat.Utils.xxHash::CalculateHash(cleanBytes, cleanBytes.Length, 0);\n\t// 59 NewArr v147 @ X0_v13 (System.Byte[]), typeof(System.Byte[]), 4\n\tv147[0] = v233;\n\tv248 = v233 >> 8;\n\tv147[1] = v248;\n\tv87 = v233 >> 0x10;\n\tv147[2] = v87;\n\tv313 = v233 >> 0x18;\n\tv147[3] = v313;\n\tv317 = v315.lockToDevice == 0;\n\tif (v317) goto L_00A9;\n\tgoto L_0073;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v314, v136, v141, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0073:\n\tv325 = CodeStage.AntiCheat.Storage.ObscuredPrefs::get_DeviceIdHash();\n\t// 120 NewArr v148 @ X0_v35 (System.Byte[]), typeof(System.Byte[]), 4\n\tv148[0] = v325;\n\tv249 = v325 >> 8;\n\tv148[1] = v249;\n\tv250 = v325 >> 0x10;\n\tv148[2] = v250;\n\tv331 = v325 >> 0x18;\n\tv75 = cleanBytes.Length + 0xB;\n\tv148[3] = v331;\n\tgoto L_00AC;\nL_00A9:\n\tv75 = cleanBytes.Length + 7;\nL_00AC:\n\t// 172 NewArr v334 @ X0_v19 (System.Byte[]), typeof(System.Byte[]), v75 @ X24_v3 (System.Int32)\n\tSystem.Buffer::BlockCopy(v175, 0, v334, 0, cleanBytes.Length);\n\tv342 = v78 == 0;\n\tif (v342) goto L_00C1;\n\tSystem.Buffer::BlockCopy(v78, 0, v334, cleanBytes.Length, 4);\nL_00C1:\n\tv307 = v75 - 7;\n\tv334[v307 @ X8_v12 (System.Int32)] = type;\n\tv308 = v75 - 6;\n\tv334[v308 @ X8_v14 (System.Int32)] = 3;\n\tgoto L_00E4;\n\tv361 = \"il2cpp_codegen_runtime_class_init\"(v358, v138, v142, v72, v69, v66, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00E4:\n\tv309 = v75 - 5;\n\tv183 = v75 - 4;\n\tv334[v309 @ X8_v17 (System.Int32)] = v366.lockToDevice;\n\tSystem.Buffer::BlockCopy(v147, 0, v334, v183, 4);\n\tgoto L_0110;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v370, v368, v212, v183, v181, v179, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0110:\n\treturnVal2 = System.Convert::ToBase64String(v334);\n\treturn returnVal2;\n\tv146 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 217 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string EncryptData(string key, byte[] cleanBytes, DataType type)
		{
			char[] cryptoKey = GetCryptoKey(key);
			byte[] src = EncryptDecryptBytes(cleanBytes, cleanBytes.Length, cryptoKey);
			uint num = xxHash.CalculateHash(cleanBytes, cleanBytes.Length, 0u);
			byte[] array = new byte[4]
			{
				(byte)num,
				0,
				0,
				0
			};
			int num2 = (int)num >> 8;
			array[1] = (byte)num2;
			int num3 = (int)num >> 16;
			array[2] = (byte)num3;
			int num4 = (int)num >> 24;
			array[3] = (byte)num4;
			int num9;
			Array array2;
			if (lockToDevice != DeviceLockLevel.None)
			{
				uint num5 = DeviceIdHash;
				int num6 = (int)num5 >> 8;
				int num7 = (int)num5 >> 16;
				int num8 = (int)num5 >> 24;
				num9 = cleanBytes.Length + 11;
				array2 = new byte[4]
				{
					(byte)num5,
					(byte)num6,
					(byte)num7,
					(byte)num8
				};
			}
			else
			{
				num9 = cleanBytes.Length + 7;
				array2 = null;
			}
			byte[] array3 = new byte[num9];
			Buffer.BlockCopy(src, 0, array3, 0, cleanBytes.Length);
			if (array2 != null)
			{
				Buffer.BlockCopy(array2, 0, array3, cleanBytes.Length, 4);
			}
			int num10 = num9 - 7;
			array3[num10] = (byte)type;
			int num11 = num9 - 6;
			array3[num11] = 3;
			int num12 = num9 - 5;
			int dstOffset = num9 - 4;
			array3[num12] = (byte)lockToDevice;
			Buffer.BlockCopy(array, 0, array3, dstOffset, 4);
			return Convert.ToBase64String(array3);
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0xBD8B58", Offset = "0xBD8B58", Length = "0x448")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv34 = System.Byte[];\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, encryptedInput, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv59 = System.Convert;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, encryptedInput, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv67 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, encryptedInput, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A3543F]) = v53;\nL_0025:\n\tgoto L_0029;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v54, encryptedInput, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0029:\n\tv65 = System.Convert::FromBase64String(encryptedInput);\n\tv69 = v65 == 0;\n\tif (v69) goto L_01A0;\n\tv71 = v65.Length == 0;\n\tif (v71) goto L_FFFFFFFF;\n\tv213 = v65.Length << 0x20;\n\tv214 = 0xFFFFFFFA00000000 + v213;\n\tv196 = v214 >> 0x20;\n\tv207 = v65[v196 @ TEMPSHIFT_v9 (System.Int32)] & 0xFE;\n\tv118 = v207 != 2;\n\tif (v118) goto L_FFFFFFFF;\n\tv313 = v65.Length << 0x20;\n\tv314 = v313 + 0xFFFFFFFB00000000;\n\tv114 = v314 >> 0x20;\n\t// 90 NewArr v317 @ X0_v36 (System.Byte[]), typeof(System.Byte[]), 4\n\tv162 = v65.Length - 4;\n\tSystem.Buffer::BlockCopy(v65, v162, v317, 0, 4);\n\tv170 = v317 == 0;\n\tif (v170) goto L_01A0;\n\tv555 = v65[v114 @ TEMPSHIFT_v10 (System.Int32)] == 0;\n\tif (v555) goto L_00E6;\n\tv375 = v65.Length - 0xB;\n\tgoto L_009A;\n\tv562 = \"il2cpp_codegen_runtime_class_init\"(v557, v162, v94, v90, v98, v86, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv564 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_009A:\n\tv566 = v565.lockToDevice == 0;\n\tif (v566) goto L_FFFFFFFF;\n\t// 158 NewArr v605 @ X0_v82 (System.Byte[]), typeof(System.Byte[]), 4\n\tSystem.Buffer::BlockCopy(v65, v375, v605, 0, 4);\n\tv171 = v605 == 0;\n\tif (v171) goto L_01A0;\n\tv670 = v605[1] & 0xFF;\n\tv671 = v670 << 8;\n\tv672 = v605[0] & 0xFFFFFFFFFFFF00FF;\n\tv673 = v672 | v671;\n\tv674 = v605[2] & 0xFF;\n\tv675 = v674 << 0x10;\n\tv676 = v673 & 0xFFFFFFFFFF00FFFF;\n\tv677 = v676 | v675;\n\tv678 = v605[3] & 0xFF;\n\tv588 = v678 << 0x18;\n\tv679 = v677 & 0xFFFFFF;\n\tv336 = v679 | v588;\n\tgoto L_00EA;\nL_00E3:\n\tgoto L_018F;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v296, v294, v270, v269, v271, v268, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_018F;\nL_00E6:\n\tv375 = v65.Length - 7;\n\tgoto L_00EA;\nL_00EA:\n\tv593 = v317[1] & 0xFF;\n\tv594 = v593 << 8;\n\tv595 = v317[0] & 0xFFFFFFFFFFFF00FF;\n\tv596 = v595 | v594;\n\tv598 = v317[2] & 0xFF;\n\tv599 = v598 << 0x10;\n\tv600 = v596 & 0xFFFFFFFFFF00FFFF;\n\tv601 = v600 | v599;\n\t// 243 NewArr v602 @ X0_v40 (System.Byte[]), typeof(System.Byte[]), v375 @ X21_v10 (System.Int32)\n\tSystem.Buffer::BlockCopy(v65, 0, v602, 0, v375);\n\tv610 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv612 = *([v610 @ X0_v42 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]) == 0;\n\tif (v612) goto L_0118;\n\tv615 = ~v613.migratingFromACTkV1;\n\tif (v615) goto L_011E;\nL_010B:\n\tv632 = System.String::Concat(key, v630.cryptoKeyObsoleteForMigration);\n\tv659 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptDecryptBytesObsolete(v602, v375, v632);\n\tgoto L_0126;\nL_0118:\n\tgoto L_011A;\n\tv652 = \"il2cpp_codegen_runtime_class_init\"(v640, v607, v608, v330, v334, v328, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_011A:\n\tv653 = ~v626.migratingFromACTkV1;\n\tv622 = ~v653;\n\tif (v622) goto L_010B;\nL_011E:\n\tv639 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetCryptoKey(key);\n\tv659 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptDecryptBytes(v602, v375, v639);\nL_0126:\n\tv663 = v317[3] & 0xFF;\n\tv664 = v663 << 0x18;\n\tv665 = v601 & 0xFFFFFF;\n\tv326 = v665 | v664;\n\tv363 = CodeStage.AntiCheat.Utils.xxHash::CalculateHash(v659, v375, 0);\n\tgoto L_013C;\n\tv680 = v371;\n\tv681 = \"il2cpp_codegen_runtime_class_init\"(v680, v361, v332, v330, v334, v328, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_013C:\n\tv343 = v363 != v326;\n\tif (v343) goto L_018F;\n\tv684 = v336 == 0;\n\tv685 = ~v684;\n\tif (v685) goto L_0164;\n\tv408 = v686.lockToDevice != 2;\n\tif (v408) goto L_0164;\n\tgoto L_0157;\n\tv700 = \"il2cpp_codegen_runtime_class_init\"(v683, v361, v332, v330, v334, v328, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv701 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv702 = *([v701 @ X0_v62+B8]);\nL_0157:\n\tv703 = ~v693.emergencyMode;\n\tv692 = ~v703;\n\tif (v692) goto L_0164;\n\tgoto L_0162;\n\tv711 = \"il2cpp_codegen_runtime_class_init\"(v690, v361, v332, v330, v334, v328, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv712 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv714 = *([v712 @ X0_v60+B8]);\nL_0162:\n\tv439 = ~v713.readForeignSaves;\n\tif (v439) goto L_FFFFFFFF;\nL_0164:\n\tv488 = v336 == 0;\n\tif (v488) goto L_019E;\n\tgoto L_016E;\n\tv704 = \"il2cpp_codegen_runtime_class_init\"(v484, v361, v332, v330, v334, v328, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv705 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_016E:\n\tv707 = ~v706.emergencyMode;\n\tv490 = ~v707;\n\tif (v490) goto L_019E;\n\tgoto L_0176;\n\tv715 = \"il2cpp_codegen_runtime_class_init\"(v486, v361, v332, v330, v334, v328, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0176:\n\tv485 = CodeStage.AntiCheat.Storage.ObscuredPrefs::get_DeviceIdHash();\n\tv422 = v336 == v485;\n\tif (v422) goto L_019E;\n\tgoto L_0187;\n\tv722 = \"il2cpp_codegen_runtime_class_init\"(v718, v361, v332, v330, v334, v328, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0187:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::PossibleForeignSavesDetected();\n\tv725 = ~v724.readForeignSaves;\n\tv438 = ~v725;\n\tif (v438) goto L_019E;\n\tgoto L_FFFFFFFF;\nL_018F:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SavesTampered();\nL_019E:\n\treturn v491;\n\tv165 = new System.IndexOutOfRangeException();\nL_01A0:\n\tv183 = new System.NullReferenceException();\n\tgoto L_01AC;\nL_01AC:\n\tv277 = v380 != 1;\n\tif (v277) goto L_01CA;\n\tv377 = 0x1854E70(v183, v380, v378, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv303 = *([v377 @ X0_v17]);\n\tv511 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v303 @ X8_v9]), v378, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv543 = v511 & 1;\n\tv299 = v543 == 0;\n\tif (v299) goto L_01C0;\n\tv545 = 0x1854E80(v511, *([v303 @ X8_v9]), v378, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00E3;\nL_01C0:\n\tv547 = 0x1854E90(8, *([v303 @ X8_v9]), v378, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t*([v547 @ X0_v23]) = *([v377 @ X0_v17]);\n\tv380 = 0x185A000 + 0xF88;\n\tv553 = 0x1854EA0(v547, v380, 0, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv383 = 0x1854E80(v553, v380, 0, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_01CA:\n\tv390 = 0xBD3CD0(v385, v380, v378, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturnVal2 = 0x9DACB4(v390, v380, v378, v88, v96, v84, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn returnVal2;\n// 305 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static byte[] DecryptData(string key, string encryptedInput)
		{
			//IL_0070: Expected I4, but got I8
			//IL_00d7: Expected I4, but got I8
			//IL_0627: Expected O, but got I4
			//IL_014a: Expected O, but got I
			//IL_0737: Expected I, but got O
			//IL_01ea: Expected O, but got I4
			byte[] array = Convert.FromBase64String(encryptedInput);
			byte[] array2;
			int num14;
			int num26;
			int num34;
			byte[] array4;
			byte[] array5;
			int num13 = default(int);
			if (array != null)
			{
				if (array.Length != 0)
				{
					int num = array.Length << 32;
					int num2 = (int)(-25769803776L + num);
					int num3 = num2 >> 32;
					int num4 = array[num3] & 0xFE;
					if (num4 == 2)
					{
						int num5 = array.Length << 32;
						int num6 = (int)(num5 + -21474836480L);
						int num7 = num6 >> 32;
						array2 = new byte[4];
						int num8 = array.Length - 4;
						Buffer.BlockCopy(array, num8, array2, 0, 4);
						bool flag = array2 == null;
						object obj2 = default(object);
						object obj = obj2;
						int num10 = default(int);
						int num9 = num10;
						IntPtr intPtr = default(IntPtr);
						object obj3 = (nint)intPtr;
						int num12 = default(int);
						int num11 = num12;
						num13 = 0;
						if (!flag)
						{
							if (array[num7] != 0)
							{
								num14 = array.Length - 11;
								if (lockToDevice != DeviceLockLevel.None)
								{
									byte[] array3 = new byte[4];
									Buffer.BlockCopy(array, num14, array3, 0, 4);
									bool flag2 = array3 == null;
									obj = 0;
									num9 = 0;
									obj3 = array2;
									num11 = 4;
									num13 = num8;
									if (flag2)
									{
										goto IL_054c;
									}
									int num15 = array3[1] & 0xFF;
									int num16 = num15 << 8;
									int num17 = array3[0] & -65281;
									int num18 = num17 | num16;
									int num19 = array3[2] & 0xFF;
									int num20 = num19 << 16;
									int num21 = num18 & -16711681;
									int num22 = num21 | num20;
									int num23 = array3[3] & 0xFF;
									int num24 = num23 << 24;
									int num25 = num22 & 0xFFFFFF;
									num26 = num25 | num24;
								}
								else
								{
									num26 = 0;
								}
							}
							else
							{
								num14 = array.Length - 7;
								num26 = array[num7];
							}
							int num27 = array2[1] & 0xFF;
							int num28 = num27 << 8;
							int num29 = array2[0] & -65281;
							int num30 = num29 | num28;
							int num31 = array2[2] & 0xFF;
							int num32 = num31 << 16;
							int num33 = num30 & -16711681;
							num34 = num33 | num32;
							array4 = new byte[num14];
							Buffer.BlockCopy(array, 0, array4, 0, num14);
							nint num35 = (nint)typeof(ObscuredPrefs);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ X0_v42 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]");
							if ((nint)0 != 0)
							{
								if (migratingFromACTkV1)
								{
									goto IL_034c;
								}
							}
							else if (migratingFromACTkV1)
							{
								goto IL_034c;
							}
							char[] cryptoKey = GetCryptoKey(key);
							array5 = EncryptDecryptBytes(array4, num14, cryptoKey);
							goto IL_03ce;
						}
						goto IL_054c;
					}
				}
				goto IL_0538;
			}
			goto IL_054c;
			IL_079b:
			byte[] result;
			return result;
			IL_034c:
			string key2 = key + cryptoKeyObsoleteForMigration;
			array5 = EncryptDecryptBytesObsolete(array4, num14, key2);
			goto IL_03ce;
			IL_054c:
			NullReferenceException ex = new NullReferenceException();
			bool flag3 = num13 != 1;
			NullReferenceException ex2 = ex;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				object obj5 = default(object);
				object obj4 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj6 = default(object);
				if ((int)((nint)obj6 & 1) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					goto IL_0538;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E90 (native __cxa_allocate_exception)");
				object obj7 = obj5;
				num13 = 25534464 + 3976;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EA0 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				object obj3 = 0;
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			byte[] result2 = default(byte[]);
			return result2;
			IL_03ce:
			int num36 = array2[3] & 0xFF;
			int num37 = num36 << 24;
			int num38 = num34 & 0xFFFFFF;
			int num39 = num38 | num37;
			uint num40 = xxHash.CalculateHash(array5, num14, 0u);
			if (num40 != (uint)num39)
			{
				goto IL_0538;
			}
			if (num26 == 0 && lockToDevice == DeviceLockLevel.Strict && !emergencyMode && !readForeignSaves)
			{
				goto IL_0542;
			}
			bool flag4 = num26 == 0;
			result = array5;
			if (!flag4)
			{
				bool flag5 = !emergencyMode;
				bool flag6 = !flag5;
				result = array5;
				if (!flag6)
				{
					uint num41 = DeviceIdHash;
					bool flag7 = num26 == (int)num41;
					result = array5;
					if (!flag7)
					{
						PossibleForeignSavesDetected();
						bool flag8 = !readForeignSaves;
						bool flag9 = !flag8;
						result = array5;
						if (!flag9)
						{
							goto IL_0542;
						}
					}
				}
			}
			goto IL_079b;
			IL_0542:
			result = null;
			goto IL_079b;
			IL_0538:
			Save();
			goto IL_0542;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0xBDA95C", Offset = "0xBDA95C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.Convert;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35440]) = v37;\nL_0017:\n\tgoto L_001B;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001B:\n\tv46 = System.Convert::FromBase64String(value);\n\tv47 = v46 == 0;\n\tif (v47) goto L_004A;\n\tv59 = v46.Length < 7;\n\tif (v59) goto L_FFFFFFFF;\n\tv65 = v46.Length << 0x20;\n\tv66 = 0xFFFFFFFA00000000 + v65;\n\tv67 = v46.Length << 0x20;\n\tv68 = 0xFFFFFFF900000000 + v67;\n\tv69 = v66 >> 0x20;\n\tv71 = v68 >> 0x20;\n\tv74 = v46[v69 @ X9_v5 (System.Int32)] < 0xA;\n\tv75 = ~v74;\n\tv76 = v46[v69 @ X9_v5 (System.Int32)] - 0xA;\n\tv78 = v76 == 0;\n\tv83 = ~v78;\n\tv84 = v75 & v83;\n\tv85 = ~v84;\n\tif (v85) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006B;\nL_004A:\n\tv60 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_0077;\n\tv175 = 0x1854E70(v60, 0, v148, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv113 = *([v175 @ X0_v15]);\n\tv187 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v113 @ X8_v7]), v148, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv188 = v187 & 1;\n\tv109 = v188 == 0;\n\tif (v109) goto L_006D;\n\tv107 = 0x1854E80(v187, *([v113 @ X8_v7]), v148, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_006B:\n\treturn returnVal1;\nL_006D:\n\tv190 = 0x1854E90(8, *([v113 @ X8_v7]), v148, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\t*([v190 @ X0_v21]) = *([v175 @ X0_v15]);\n\tv163 = 0x185A000 + 0xF88;\n\tv192 = 0x1854EA0(v190, v163, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv179 = 0x1854E80(v192, v163, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0077:\n\tv183 = 0xBD3CD0(v169, v163, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal2 = 0x9DACB4(v183, v163, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal2;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static DataType GetRawValueType(string value)
		{
			//IL_0070: Expected I4, but got I8
			//IL_0092: Expected I4, but got I8
			byte[] array = Convert.FromBase64String(value);
			if (array != null)
			{
				if (array.Length >= 7)
				{
					int num = array.Length << 32;
					int num2 = (int)(-25769803776L + num);
					int num3 = array.Length << 32;
					int num4 = (int)(-30064771072L + num3);
					int num5 = num2 >> 32;
					int num6 = num4 >> 32;
					bool flag = array[num5] < 10;
					bool flag2 = !flag;
					int num7 = array[num5] - 10;
					bool flag3 = num7 == 0;
					bool flag4 = !flag3;
					return (DataType)((!(flag2 && flag4)) ? array[num6] : 0);
				}
				return default(DataType);
			}
			NullReferenceException ex = new NullReferenceException();
			int num8 = 0;
			NullReferenceException ex2 = ex;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			DataType result = default(DataType);
			return result;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0xC826BC", Offset = "0xC826BC", Length = "0x5B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = value & 1;\n\tgoto L_002A;\n\tgoto L_002A;\n\tv41 = 0xB3490C(methodInfo, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002A:\n\tgoto L_002E;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v51, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002E:\n\tv62 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_003E;\n\tv75 = v69;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v75, v61, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv79 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_003E:\n\tv84 = System.Type::op_Equality(v62, v80.IntType);\n\tv87 = v84 == 0;\n\tif (v87) goto L_0058;\n\tgoto L_004A;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v91, v83, v82, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004A:\n\t;\n\tv105 = System.Boolean::System.IConvertible.ToInt32(&v14 @ X8_v1 (System.Int32), 0);\n\tv116 = System.BitConverter::GetBytes(v105);\n\tgoto L_01B7;\nL_0058:\n\tgoto L_0061;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v95, v83, v82, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv108 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0061:\n\tgoto L_0067;\n\tv117 = v109;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v117, v83, v82, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0067:\n\tv123 = System.Type::op_Equality(v62, v110.UIntType);\n\tv127 = v123 == 0;\n\tif (v127) goto L_0081;\n\tgoto L_0073;\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v232, v121, v122, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0073:\n\t;\n\tv250 = System.Boolean::System.IConvertible.ToUInt32(&v14 @ X8_v1 (System.Int32), 0);\n\tv188 = System.BitConverter::GetBytes(v250);\n\tgoto L_01B7;\nL_0081:\n\tgoto L_008A;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v235, v121, v122, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv253 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_008A:\n\tgoto L_0090;\n\tv265 = v254;\n\tv266 = \"il2cpp_codegen_runtime_class_init\"(v265, v121, v122, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0090:\n\tv270 = System.Type::op_Equality(v62, v255.StringType);\n\tv272 = v270 == 0;\n\tif (v272) goto L_00B4;\n\tgoto L_009C;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v275, v269, v151, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_009C:\n\t;\n\tv288 = System.Boolean::ToString(&v14 @ X8_v1 (System.Int32));\n\tgoto L_00AC;\n\tv306 = v219;\n\tv307 = \"il2cpp_codegen_runtime_class_init\"(v306, v287, v151, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00AC:\n\tv189 = CodeStage.AntiCheat.Utils.StringUtils::StringToBytes(v288);\n\tgoto L_01B7;\nL_00B4:\n\tgoto L_00BD;\n\tv289 = \"il2cpp_codegen_runtime_class_init\"(v279, v269, v151, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv291 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_00BD:\n\tgoto L_00C3;\n\tv299 = v292;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v299, v269, v151, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00C3:\n\tv305 = System.Type::op_Equality(v62, v161.FloatType);\n\tv311 = v305 == 0;\n\tif (v311) goto L_00DD;\n\tgoto L_00CF;\n\tv321 = \"il2cpp_codegen_runtime_class_init\"(v314, v303, v304, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00CF:\n\t;\n\tv146 = System.Boolean::System.IConvertible.ToSingle(&v14 @ X8_v1 (System.Int32), 0);\n\tv190 = System.BitConverter::GetBytes(v146);\n\tgoto L_01B7;\nL_00DD:\n\tgoto L_00E6;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v317, v303, v304, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv326 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_00E6:\n\tgoto L_00EC;\n\tv331 = v327;\n\tv332 = \"il2cpp_codegen_runtime_class_init\"(v331, v303, v304, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00EC:\n\tv337 = System.Type::op_Equality(v62, v162.DoubleType);\n\tv339 = v337 == 0;\n\tif (v339) goto L_0106;\n\tgoto L_00F8;\n\tv349 = \"il2cpp_codegen_runtime_class_init\"(v342, v335, v336, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00F8:\n\t;\n\tv147 = System.Boolean::System.IConvertible.ToDouble(&v14 @ X8_v1 (System.Int32), 0);\n\tv191 = System.BitConverter::GetBytes(v147);\n\tgoto L_01B7;\nL_0106:\n\tgoto L_010F;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v345, v335, v336, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv354 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_010F:\n\tgoto L_0115;\n\tv359 = v355;\n\tv360 = \"il2cpp_codegen_runtime_class_init\"(v359, v335, v336, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0115:\n\tv365 = System.Type::op_Equality(v62, v163.DecimalType);\n\tv367 = v365 == 0;\n\tif (v367) goto L_0139;\n\tgoto L_0121;\n\tv378 = \"il2cpp_codegen_runtime_class_init\"(v370, v363, v364, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0121:\n\t;\n\tv384 = System.Boolean::System.IConvertible.ToDecimal(&v14 @ X8_v1 (System.Int32), 0);\n\tgoto L_0131;\n\tv402 = \"il2cpp_codegen_runtime_class_init\"(v392, v382, v383, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0131:\n\tv192 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecimalToBytes(v384);\n\tgoto L_01B7;\nL_0139:\n\tgoto L_0142;\n\tv385 = \"il2cpp_codegen_runtime_class_init\"(v374, v363, v364, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv387 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0142:\n\tgoto L_0148;\n\tv395 = v388;\n\tv396 = \"il2cpp_codegen_runtime_class_init\"(v395, v363, v364, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0148:\n\tv401 = System.Type::op_Equality(v62, v164.LongType);\n\tv406 = v401 == 0;\n\tif (v406) goto L_0162;\n\tgoto L_0154;\n\tv416 = \"il2cpp_codegen_runtime_class_init\"(v409, v399, v400, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0154:\n\t;\n\tv420 = System.Boolean::System.IConvertible.ToInt64(&v14 @ X8_v1 (System.Int32), 0);\n\tv193 = System.BitConverter::GetBytes(v420);\n\tgoto L_01B7;\nL_0162:\n\tgoto L_016B;\n\tv421 = \"il2cpp_codegen_runtime_class_init\"(v412, v399, v400, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv423 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_016B:\n\tgoto L_0171;\n\tv427 = v424;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v427, v399, v400, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0171:\n\tv433 = System.Type::op_Equality(v62, v165.ULongType);\n\tv435 = v433 == 0;\n\tif (v435) goto L_018B;\n\tgoto L_017D;\n\tv445 = \"il2cpp_codegen_runtime_class_init\"(v438, v431, v432, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_017D:\n\t;\n\tv449 = System.Boolean::System.IConvertible.ToUInt64(&v14 @ X8_v1 (System.Int32), 0);\n\tv194 = System.BitConverter::GetBytes(v449);\n\tgoto L_01B7;\nL_018B:\n\tgoto L_0194;\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v441, v431, v432, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv452 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0194:\n\tgoto L_019A;\n\tv455 = v217;\n\tv456 = \"il2cpp_codegen_runtime_class_init\"(v455, v431, v432, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_019A:\n\tv187 = System.Type::op_Equality(v62, v159.BoolType);\n\tv197 = v187 == 0;\n\tif (v197) goto L_FFFFFFFF;\n\tgoto L_01A6;\n\tv465 = \"il2cpp_codegen_runtime_class_init\"(v462, v177, v149, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_01A6:\n\t;\n\tv469 = System.Boolean::System.IConvertible.ToBoolean(&v14 @ X8_v1 (System.Int32), 0);\n\tv195 = System.BitConverter::GetBytes(v469);\n\tgoto L_01B7;\nL_01B7:\n\tgoto L_01BD;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v226, v176, v148, v27, v28, v29, v30, v31, v145, v33, v34, v35, v36, v37, v38, v39);\nL_01BD:\n\treturnVal1 = CodeStage.AntiCheat.Storage.ObscuredPrefs::EncryptData(key, v206, v166);\n\treturn returnVal1;\n// 306 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static string EncryptValue<T>(string key, T value) where T : IConvertible
		{
			int num = (int)((nint)value & 1);
			Type typeFromHandle = typeof(T);
			DataType type;
			byte[] cleanBytes;
			if (typeFromHandle == IntType)
			{
				int value2 = ((bool*)(&num))->System_002EIConvertible_002EToInt32((IFormatProvider)null);
				byte[] bytes = BitConverter.GetBytes(value2);
				type = DataType.Int;
				cleanBytes = bytes;
			}
			else if (typeFromHandle == UIntType)
			{
				uint value3 = ((bool*)(&num))->System_002EIConvertible_002EToUInt32((IFormatProvider)null);
				byte[] bytes2 = BitConverter.GetBytes(value3);
				type = DataType.UInt;
				cleanBytes = bytes2;
			}
			else if (typeFromHandle == StringType)
			{
				string input = ((bool*)(&num))->ToString();
				byte[] array = StringUtils.StringToBytes(input);
				type = DataType.String;
				cleanBytes = array;
			}
			else if (typeFromHandle == FloatType)
			{
				float value4 = ((bool*)(&num))->System_002EIConvertible_002EToSingle((IFormatProvider)null);
				byte[] bytes3 = BitConverter.GetBytes(value4);
				type = DataType.Float;
				cleanBytes = bytes3;
			}
			else if (typeFromHandle == DoubleType)
			{
				double value5 = ((bool*)(&num))->System_002EIConvertible_002EToDouble((IFormatProvider)null);
				byte[] bytes4 = BitConverter.GetBytes(value5);
				type = DataType.Double;
				cleanBytes = bytes4;
			}
			else if (typeFromHandle == DecimalType)
			{
				decimal dec = ((bool*)(&num))->System_002EIConvertible_002EToDecimal((IFormatProvider)null);
				byte[] array2 = DecimalToBytes(dec);
				type = DataType.Decimal;
				cleanBytes = array2;
			}
			else if (typeFromHandle == LongType)
			{
				long value6 = ((bool*)(&num))->System_002EIConvertible_002EToInt64((IFormatProvider)null);
				byte[] bytes5 = BitConverter.GetBytes(value6);
				type = DataType.Long;
				cleanBytes = bytes5;
			}
			else if (typeFromHandle == ULongType)
			{
				ulong value7 = ((bool*)(&num))->System_002EIConvertible_002EToUInt64((IFormatProvider)null);
				byte[] bytes6 = BitConverter.GetBytes(value7);
				type = DataType.ULong;
				cleanBytes = bytes6;
			}
			else if (typeFromHandle == BoolType)
			{
				bool value8 = ((bool*)(&num))->System_002EIConvertible_002EToBoolean((IFormatProvider)null);
				byte[] bytes7 = BitConverter.GetBytes(value8);
				type = DataType.Bool;
				cleanBytes = bytes7;
			}
			else
			{
				type = default(DataType);
				cleanBytes = null;
			}
			return EncryptData(key, cleanBytes, type);
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0xC7EBC0", Offset = "0xC7EBC0", Length = "0x5E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tgoto L_003C;\nL_003C:\n\tv53 = v375 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0051;\nL_0045:\n\tgoto L_004A;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v65, encryptedKey, defaultValue, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_004A:\n\tv74 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetEncryptedPrefsString(key, encryptedKey);\nL_0051:\n\tv84 = System.String::op_Equality(v76, \"{not_found}\");\n\tv92 = v84 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_00C2;\n\tgoto L_0061;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v99, v83, v82, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0061:\n\tv156 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptData(key, v76);\n\tv159 = v156 == 0;\n\tif (v159) goto L_00C2;\n\tgoto L_0071;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v284, v153, v150, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0071:\n\tv296 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_007F;\n\tv307 = v300;\n\tv308 = \"il2cpp_codegen_runtime_class_init\"(v307, v295, v150, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv311 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_007F:\n\tv84 = System.Type::op_Equality(v296, v312.IntType);\n\tv321 = v84 == 0;\n\tif (v321) goto L_00D3;\n\tv327 = System.BitConverter::ToInt32(v156, 0);\n\t// 141 Box v338 @ X0_v130 (System.String), typeof(System.Int32), &v327 @ X0_v128 (System.Int32)\n\tgoto L_FFFFFFFF;\n\tv364 = v351;\n\tv365 = 0xB348B0(v364, v351, v326, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv367 = v365;\n\tv207 = v207_asT == 0;\n\tif (v207) goto L_01EB;\n\tv84 = \"il2cpp_vm_object_unbox\"(v244, v232, v229, v375, methodInfo, v36, v37, v38, v647, v40, v41, v42, v43, v44, v45, v46);\n\tv170 = v84.m_value;\nL_00B0:\n\tv129 = v170 == 0;\n\tv114 = ~v129;\nL_00C2:\n\tv182 = *([v17 @ SYSREG+28]) != *([v17 @ SYSREG+28]);\n\tif (v182) goto L_01EC;\n\treturnVal1 = v163 & 1;\n\treturn returnVal1;\nL_00D3:\n\tgoto L_00DC;\n\tv339 = \"il2cpp_codegen_runtime_class_init\"(v328, v315, v314, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv341 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_00DC:\n\tgoto L_00E2;\n\tv356 = v342;\n\tv357 = \"il2cpp_codegen_runtime_class_init\"(v356, v315, v314, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00E2:\n\tv84 = System.Type::op_Equality(v296, v343.UIntType);\n\tv371 = v84 == 0;\n\tif (v371) goto L_00FB;\n\tv408 = System.BitConverter::ToUInt32(v156, 0);\nL_00ED:\n\tv541 = *([v489 @ X8_v16]);\n\tgoto L_015B;\n\tv84 = 0xB3490C(methodInfo, encryptedKey, defaultValue, v375, methodInfo, v36, v37, v38, v647, v40, v41, v42, v43, v44, v45, v46);\n\tv363 = v375 == 0;\n\tv61 = ~v363;\n\tif (v61) goto L_0051;\n\tgoto L_0045;\nL_00FB:\n\tgoto L_0104;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v409, v360, v361, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv444 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0104:\n\tgoto L_010A;\n\tv493 = v445;\n\tv494 = \"il2cpp_codegen_runtime_class_init\"(v493, v360, v361, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_010A:\n\tv84 = System.Type::op_Equality(v296, v446.StringType);\n\tv546 = v84 == 0;\n\tif (v546) goto L_0120;\n\tgoto L_0116;\n\tv602 = \"il2cpp_codegen_runtime_class_init\"(v576, v497, v498, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0116:\n\tv229 = v156.Length;\n\tv592 = CodeStage.AntiCheat.Utils.StringUtils::BytesToString(v156, 0, v156.Length);\n\tgoto L_FFFFFFFF;\nL_0120:\n\tgoto L_0129;\n\tv605 = \"il2cpp_codegen_runtime_class_init\"(v580, v497, v498, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv607 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0129:\n\tgoto L_012F;\n\tv626 = v608;\n\tv627 = \"il2cpp_codegen_runtime_class_init\"(v626, v497, v498, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_012F:\n\tv84 = System.Type::op_Equality(v296, v609.FloatType);\n\tv641 = v84 == 0;\n\tif (v641) goto L_013F;\n\tv647 = System.BitConverter::ToSingle(v156, 0);\n\tgoto L_0159;\nL_013F:\n\tgoto L_0148;\n\tv663 = \"il2cpp_codegen_runtime_class_init\"(v648, v630, v631, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv665 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0148:\n\tgoto L_014E;\n\tv687 = v434;\n\tv688 = \"il2cpp_codegen_runtime_class_init\"(v687, v630, v631, encryptedInput, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_014E:\n\tv84 = System.Type::op_Equality(v296, v421.DoubleType);\n\tv429 = v84 == 0;\n\tif (v429) goto L_016F;\n\tv679 = System.BitConverter::ToDouble(v156, 0);\nL_0159:\n\tv84 = *([v572 @ X8_v50]);\nL_015B:\n\tv592 = \"il2cpp_vm_object_box\"(v84, v562, v229, v375, methodInfo, v36, v37, v38, v647, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0167;\n\tv622 = v598;\n\tv623 = 0xB348B0(v622, v598, v379, v375, methodInfo, v36, v37, v38, v374, v40, v41, v42, v43, v44, v45, v46);\n\tv624 = v623;\nL_0167:\n\tv625 = v592 == 0;\n\tv383 = ~v625;\n\tif (v383) goto L_FFFFFFFF;\n\tthrow System.NullReferenceException;\nL_016F:\n\tgoto L_0178;\n\tv452 = \"il2cpp_codegen_runtime_class_init\"(v435, v424, v422, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\n\tv454 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_0178:\n\tgoto L_017E;\n\tv515 = v455;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v515, v424, v422, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\nL_017E:\n\tv84 = System.Type::op_Equality(v296, v456.DecimalType);\n\tgoto L_0188;\n\tv584 = v547;\n\tv585 = \"il2cpp_codegen_runtime_class_init\"(v584, v519, v474, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\nL_0188:\n\tv483 = v84 == 0;\n\tif (v483) goto L_0199;\n\tv480 = CodeStage.AntiCheat.Storage.ObscuredPrefs::BytesToDecimal(v156);\n\tgoto L_00ED;\nL_0199:\n\tgoto L_019E;\n\tv634 = \"il2cpp_codegen_runtime_class_init\"(v616, v519, v474, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\nL_019E:\n\tv84 = System.Type::op_Equality(v296, v617.LongType);\n\tv643 = v84 == 0;\n\tif (v643) goto L_01AD;\n\tv655 = System.BitConverter::ToInt64(v156, 0);\n\tgoto L_01C6;\nL_01AD:\n\tgoto L_01B6;\n\tv670 = \"il2cpp_codegen_runtime_class_init\"(v656, v637, v638, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\n\tv672 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_01B6:\n\tgoto L_01BC;\n\tv697 = v673;\n\tv698 = \"il2cpp_codegen_runtime_class_init\"(v697, v637, v638, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\nL_01BC:\n\tv84 = System.Type::op_Equality(v296, v674.ULongType);\n\tv694 = v84 == 0;\n\tif (v694) goto L_01CD;\n\tv693 = System.BitConverter::ToUInt64(v156, 0);\nL_01C6:\n\tv541 = *([v695 @ X8_v25]);\n\tgoto L_FFFFFFFF;\nL_01CD:\n\tgoto L_01D6;\n\tv713 = \"il2cpp_codegen_runtime_class_init\"(v707, v701, v702, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\n\tv715 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_01D6:\n\tgoto L_01DC;\n\tv719 = v716;\n\tv720 = \"il2cpp_codegen_runtime_class_init\"(v719, v701, v702, v418, methodInfo, v36, v37, v38, v417, v40, v41, v42, v43, v44, v45, v46);\nL_01DC:\n\tv84 = System.Type::op_Equality(v296, v509.BoolType);\n\tv484 = v84 == 0;\n\tif (v484) goto L_FFFFFFFF;\n\tv84 = System.BitConverter::ToBoolean(v156, 0);\n\tgoto L_00ED;\n\tgoto L_00B0;\nL_01EB:\n\tv233 = new System.InvalidCastException();\nL_01EC:\n\treturnVal2 = 0x1854EB0(v233, v231, v229, v375, methodInfo, v36, v37, v38, v647, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal2;\n// 341 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static T DecryptValue<T>(string key, string encryptedKey, T defaultValue, string encryptedInput = null)
		{
			//IL_05b8: Expected O, but got I4
			//IL_0155: Expected O, but got I
			//IL_055e: Expected O, but got I
			//IL_072a: Expected O, but got I4
			//IL_0732: Expected I4, but got O
			//IL_0141: Expected O, but got I
			//IL_0715: Expected O, but got I4
			//IL_071d: Expected O, but got I4
			//IL_0668: Expected I4, but got O
			//IL_0670: Expected O, but got F4
			//IL_03b3: Expected I4, but got O
			//IL_0426: Expected I4, but got I8
			//IL_0490: Expected I4, but got I8
			string text = default(string);
			bool flag = text == null;
			bool flag2 = !flag;
			string text2 = text;
			if (!flag2)
			{
				string encryptedPrefsString = GetEncryptedPrefsString(key, encryptedKey);
				text2 = encryptedPrefsString;
			}
			bool flag3 = text2 == "{not_found}";
			bool flag4 = !flag3;
			bool flag5 = !flag4;
			int num = 0;
			string text3 = "{not_found}";
			InvalidCastException ex = (InvalidCastException)flag3;
			T val = defaultValue;
			nint num3;
			string text5;
			uint num5;
			object typeFromHandle2;
			string text6 = default(string);
			Type type;
			bool flag7;
			object obj;
			object obj2;
			if (!flag5)
			{
				byte[] array = DecryptData(key, text2);
				bool flag6 = array == null;
				num = 0;
				text3 = text2;
				ex = (InvalidCastException)(object)array;
				val = defaultValue;
				if (!flag6)
				{
					Type typeFromHandle = typeof(T);
					flag3 = typeFromHandle == IntType;
					if (flag3)
					{
						int num2 = BitConverter.ToInt32(array, 0);
						string text4 = (string)(object)num2;
						num3 = 0;
						num = 0;
						text5 = text4;
						goto IL_00f8;
					}
					if (typeFromHandle == UIntType)
					{
						uint num4 = BitConverter.ToUInt32(array, 0);
						num5 = num4;
						num = 0;
						typeFromHandle2 = typeof(uint);
						goto IL_06af;
					}
					flag3 = typeFromHandle == StringType;
					if (flag3)
					{
						num = array.Length;
						text6 = StringUtils.BytesToString(array, 0, array.Length);
						text = null;
						goto IL_0344;
					}
					float num7;
					object typeFromHandle3;
					if (typeFromHandle == FloatType)
					{
						float num6 = BitConverter.ToSingle(array, 0);
						num7 = num6;
						num = 0;
						typeFromHandle3 = typeof(float);
					}
					else
					{
						float num6 = default(float);
						if (!(typeFromHandle == DoubleType))
						{
							if (typeFromHandle == DecimalType)
							{
								decimal num8 = BytesToDecimal(array);
								num6 = num6;
								text = text;
								num5 = (uint)(int)num8;
								num = 0;
								typeFromHandle2 = typeof(decimal);
								goto IL_06af;
							}
							uint num10;
							object typeFromHandle4;
							if (typeFromHandle == LongType)
							{
								long num9 = BitConverter.ToInt64(array, 0);
								num = 0;
								num10 = (uint)num9;
								typeFromHandle4 = typeof(long);
							}
							else
							{
								if (!(typeFromHandle == ULongType))
								{
									flag3 = typeFromHandle == BoolType;
									if (flag3)
									{
										flag3 = BitConverter.ToBoolean(array, 0);
										num6 = num6;
										text = text;
										num5 = (flag3 ? 1u : 0u);
										num = 0;
										typeFromHandle2 = typeof(bool);
										goto IL_06af;
									}
									num6 = num6;
									text = text;
									num = 0;
									type = BoolType;
									flag7 = false;
									goto IL_06eb;
								}
								ulong num11 = BitConverter.ToUInt64(array, 0);
								num = 0;
								num10 = (uint)num11;
								typeFromHandle4 = typeof(ulong);
							}
							obj = typeFromHandle4;
							num6 = num6;
							text = text;
							num5 = num10;
							goto IL_0722;
						}
						double num12 = BitConverter.ToDouble(array, 0);
						num6 = (float)num12;
						num7 = (float)num12;
						num = 0;
						typeFromHandle3 = typeof(double);
					}
					flag3 = (byte)(int)typeFromHandle3 != 0;
					obj2 = num7;
					goto IL_0647;
				}
			}
			goto IL_05ce;
			IL_0722:
			obj2 = num5;
			flag3 = (byte)(int)obj != 0;
			goto IL_0647;
			IL_05ce:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ SYSREG+28]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ SYSREG+28]");
			if (num13 == 0)
			{
				return (T)((nint)val & 1);
			}
			goto IL_0563;
			IL_06eb:
			bool flag8 = !flag7;
			bool flag9 = !flag8;
			text3 = (string)(object)type;
			ex = (InvalidCastException)flag3;
			val = (T)flag9;
			goto IL_05ce;
			IL_00f8:
			T val2 = (T)((text5 is T) ? text5 : null);
			if (val2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				flag7 = ((bool*)(flag3 ? 1 : 0))->m_value;
				type = (Type)num3;
				goto IL_06eb;
			}
			ex = new InvalidCastException();
			text3 = (string)num3;
			goto IL_0563;
			IL_0563:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			T result = default(T);
			return result;
			IL_0344:
			num3 = 0;
			bool flag10 = text6 == null;
			bool flag11 = !flag10;
			text5 = text6;
			if (!flag11)
			{
				throw new NullReferenceException();
			}
			goto IL_00f8;
			IL_06af:
			obj = typeFromHandle2;
			goto IL_0722;
			IL_0647:
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			goto IL_0344;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0xBDA79C", Offset = "0xBDA79C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Byte[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, dataLength, key, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A35441]) = v39;\nL_001B:\n\t// 27 NewArr returnVal2 @ X0_v5 (System.Byte[]), typeof(System.Byte[]), dataLength @ X1 (System.Int32)\n\tv69 = dataLength < 1;\n\tif (v69) goto L_006C;\nL_003A:\n\tv205 = v119 / key.Length;\n\tv206 = v205 * key.Length;\n\tv53 = v119 - v206;\n\tv127 = bytes[v119 @ X8_v8 (System.Int32)] ^ key[v53 @ X12_v7];\n\treturnVal2[v119 @ X8_v8 (System.Int32)] = v127;\n\tv119 = v119 + 1;\n\tv134 = dataLength != v119;\n\tif (v134) goto L_003A;\nL_006C:\n\treturn returnVal2;\n\tv113 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static byte[] EncryptDecryptBytes(byte[] bytes, int dataLength, char[] key)
		{
			//IL_005b: Expected O, but got I4
			//IL_0069: Expected O, but got I
			byte[] array = new byte[dataLength];
			if (dataLength >= 1)
			{
				int num = 0;
				do
				{
					int num2 = num / key.Length;
					object obj = num2 * key.Length;
					object obj2 = num - (nint)obj;
					int num3 = bytes[num] ^ key[obj2];
					array[num] = (byte)num3;
					num++;
				}
				while (dataLength != num);
			}
			return array;
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0xBDAA78", Offset = "0xBDAA78", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv24 = System.Decimal;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv74 = System.Collections.Generic.List`1<System.Byte>;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A35442]) = v43;\nL_002A:\n\tgoto L_002F;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv60 = System.Decimal::GetBits(dec);\n\tv67 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v67);\n\tv87 = v60.Length < 1;\n\tif (v87) goto L_0079;\nL_0057:\n\tv136 = System.BitConverter::GetBytes(v60[v146 @ X21_v9 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(v67, v136);\n\tv146 = v146 + 1;\n\tv155 = v146 < v60.Length;\n\tif (v155) goto L_0057;\nL_0079:\n\treturnVal2 = System.Collections.Generic.List`1<System.Byte>::ToArray(v67);\n\treturn returnVal2;\n\tv135 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static byte[] DecimalToBytes(decimal dec)
		{
			int[] bits = decimal.GetBits(dec);
			List<byte> list = new List<byte>();
			if (bits.Length >= 1)
			{
				int num = 0;
				do
				{
					byte[] bytes = BitConverter.GetBytes(bits[num]);
					list.AddRange(bytes);
					num++;
				}
				while (num < bits.Length);
			}
			return list.ToArray();
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0xBDABB8", Offset = "0xBDABB8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = System.Int32[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 1;\n\t*([1A35443]) = v45;\nL_0023:\n\tv57 = bytes.Length != 0x10;\n\tif (v57) goto L_0070;\n\t// 41 NewArr v108 @ X0_v23 (System.Int32[]), typeof(System.Int32[]), 4\n\tv61 = v108 + 0x20;\nL_0031:\n\tv96 = System.BitConverter::ToInt32(bytes, v63);\n\t*([v61 @ X24_v5+v63 @ X21_v6 (System.Int32)]) = v96;\n\tv188 = v63 < 0xC;\n\tv173 = ~v188;\n\tv63 = v63 + 4;\n\tv165 = ~v173;\n\tif (v165) goto L_0031;\n\tv193 = 0;\n\tSystem.Decimal::.ctor(&v193 @ stack_-58_v2 (System.Decimal), v108);\n\tv211 = *([v15 @ SYSREG+28]) != *([v15 @ SYSREG+28]);\n\tif (v211) goto L_007F;\n\treturn 0;\n\tv103 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0070:\n\tv160 = new System.Exception();\n\tSystem.Exception::.ctor(v160, \"[ACTk] A decimal must be created from exactly 16 bytes\");\n\tthrow v160;\nL_007F:\n\treturnVal1 = 0x1854EB0(0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static decimal BytesToDecimal(byte[] bytes)
		{
			//IL_0044: Expected O, but got I
			if (bytes.Length == 16)
			{
				int[] array = new int[4];
				object obj = (nint)array + 32;
				int num = 0;
				bool flag2;
				do
				{
					int num2 = BitConverter.ToInt32(bytes, num);
					bool flag = num < 12;
					flag2 = !flag;
					num += 4;
				}
				while (!flag2);
				decimal num3 = default(decimal);
				num3 = new decimal(array);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ SYSREG+28]");
				if (num4 == 0)
				{
					return default(decimal);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
				decimal result = default(decimal);
				return result;
			}
			Exception ex = new Exception("[ACTk] A decimal must be created from exactly 16 bytes");
			throw ex;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0xBD8630", Offset = "0xBD8630", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, encryptedKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, encryptedKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv54 = \"[ACTk] ObscuredPrefs: Are you trying to read regular PlayerPrefs data using ObscuredPrefs (key = \";\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, encryptedKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv59 = \")?\";\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, encryptedKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv88 = \"{not_found}\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, encryptedKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35444]) = v41;\nL_0024:\n\tv45 = UnityEngine.PlayerPrefs::GetString(encryptedKey, \"{not_found}\");\n\tv52 = System.String::op_Equality(v45, \"{not_found}\");\n\tv57 = v52 == 0;\n\tif (v57) goto L_004F;\n\tv63 = UnityEngine.PlayerPrefs::HasKey(key);\n\tv90 = v63 == 0;\n\tif (v90) goto L_0056;\n\tv119 = System.String::Concat(\"[ACTk] ObscuredPrefs: Are you trying to read regular PlayerPrefs data using ObscuredPrefs (key = \", key, \")?\");\n\tgoto L_0047;\n\tv134 = v80;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v134, v117, v70, v65, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0047:\n\tUnityEngine.Debug::LogWarning(v119);\nL_004F:\n\treturn v45;\nL_0056:\n\tgoto L_005C;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v122, v62, v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv130 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_005C:\n\tv133 = CodeStage.AntiCheat.Storage.ObscuredPrefs::MigrateFromACTkV1Internal(key, v108.cryptoKeyObsolete);\n\treturnVal2 = UnityEngine.PlayerPrefs::GetString(encryptedKey, \"{not_found}\");\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetEncryptedPrefsString(string key, string encryptedKey)
		{
			string text = PlayerPrefs.GetString(encryptedKey, "{not_found}");
			if (text == "{not_found}")
			{
				if (!PlayerPrefs.HasKey(key))
				{
					bool flag = MigrateFromACTkV1(key, cryptoKeyObsolete);
					return PlayerPrefs.GetString(encryptedKey, "{not_found}");
				}
				string message = "[ACTk] ObscuredPrefs: Are you trying to read regular PlayerPrefs data using ObscuredPrefs (key = " + key + ")?";
				Debug.LogWarning(message);
			}
			return text;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0xBD6674", Offset = "0xBD6674", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35445]) = v40;\nL_0017:\n\tv41 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]) == 0;\n\tif (v45) goto L_003E;\n\tv50 = ~v48.migratingFromACTkV1;\n\tif (v50) goto L_0048;\nL_0026:\n\tv79 = System.String::Concat(v69, v77.cryptoKeyObsoleteForMigration);\n\tgoto L_0030;\n\tv112 = v91;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v112, v78, v76, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0030:\n\tv130 = CodeStage.AntiCheat.Utils.StringUtils::StringToBytes(v79);\nL_003B:\n\treturnVal1 = CodeStage.AntiCheat.Utils.xxHash::CalculateHash(v130, v130.Length, 0);\n\treturn returnVal1;\nL_003E:\n\tv64 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv90 = *([v64 @ X0_v16 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]) == 0;\n\tif (v90) goto L_0058;\n\tv101 = ~v72.migratingFromACTkV1;\n\tv67 = ~v101;\n\tif (v67) goto L_0026;\nL_0048:\n\tv89 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetCryptoKey(v86);\n\tgoto L_0052;\n\tv117 = v96;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v117, v82, v83, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0052:\n\tv130 = CodeStage.AntiCheat.Utils.StringUtils::CharsToBytes(v89);\n\tv124 = v130 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_003B;\n\tv107 = new System.NullReferenceException();\nL_0058:\n\tv122 = ~v72.migratingFromACTkV1;\n\tv68 = ~v122;\n\tif (v68) goto L_0026;\n\tgoto L_0048;\n\treturn X0;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static uint CalculateChecksum(string input)
		{
			//IL_0182: Expected I, but got O
			//IL_0083: Expected I, but got O
			nint num = (nint)typeof(ObscuredPrefs);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X0_v2 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]");
			string text;
			string dynamicSuffix;
			if ((nint)0 != 0)
			{
				bool flag = !migratingFromACTkV1;
				text = input;
				dynamicSuffix = input;
				if (!flag)
				{
					goto IL_002f;
				}
			}
			else
			{
				nint num2 = (nint)typeof(ObscuredPrefs);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v16 (Il2CppClass<CodeStage.AntiCheat.Storage.ObscuredPrefs>)+E0]");
				bool flag2 = (nint)0 == 0;
				text = input;
				if (flag2)
				{
					goto IL_0142;
				}
				bool flag3 = !migratingFromACTkV1;
				bool flag4 = !flag3;
				text = input;
				dynamicSuffix = input;
				if (flag4)
				{
					goto IL_002f;
				}
			}
			goto IL_00e5;
			IL_0142:
			if (migratingFromACTkV1)
			{
				goto IL_002f;
			}
			dynamicSuffix = text;
			goto IL_00e5;
			IL_002f:
			string input2 = text + cryptoKeyObsoleteForMigration;
			byte[] array = StringUtils.StringToBytes(input2);
			goto IL_0058;
			IL_0058:
			return xxHash.CalculateHash(array, array.Length, 0u);
			IL_00e5:
			char[] cryptoKey = GetCryptoKey(dynamicSuffix);
			array = StringUtils.CharsToBytes(cryptoKey);
			bool flag5 = array == null;
			bool flag6 = !flag5;
			text = (string)(object)cryptoKey;
			if (flag6)
			{
				goto IL_0058;
			}
			NullReferenceException ex = new NullReferenceException();
			goto IL_0142;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0xBD9DDC", Offset = "0xBD9DDC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = encodedColor & 0xFF00FF00;\n\tv2 = encodedColor & 0xFF;\n\tv3 = v2 << 0x10;\n\tv4 = v0 & 0xFFFFFFFFFF00FFFF;\n\tv5 = v4 | v3;\n\tv6 = encodedColor >> 0x10;\n\tv7 = v6 & 0xFF;\n\tv8 = v5 & 0xFFFFFFFFFFFFFF00;\n\tv9 = v8 | v7;\n\treturn v9;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Color32 DecodeColor(uint encodedColor)
		{
			//IL_0012: Expected I4, but got I8
			//IL_0085: Expected O, but got I4
			int num = (int)((int)encodedColor & 0xFF00FF00L);
			int num2 = (int)(encodedColor & 0xFF);
			int num3 = num2 << 16;
			int num4 = num & -16711681;
			int num5 = num4 | num3;
			int num6 = (int)encodedColor >> 16;
			int num7 = num6 & 0xFF;
			int num8 = num5 & -256;
			int num9 = num8 | num7;
			return (Color32)num9;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0xBD70B8", Offset = "0xBD70B8", Length = "0x890")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tv32 = UnityEngine.Debug;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv56 = System.Decimal;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv128 = Il2CppMethodInfo;\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv233 = Il2CppMethodInfo;\n\tv234 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv241 = Il2CppMethodInfo;\n\tv242 = \"il2cpp_codegen_initialize_runtime_metadata\"(v241, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv245 = Il2CppMethodInfo;\n\tv246 = \"il2cpp_codegen_initialize_runtime_metadata\"(v245, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv260 = Il2CppMethodInfo;\n\tv261 = \"il2cpp_codegen_initialize_runtime_metadata\"(v260, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv285 = Il2CppMethodInfo;\n\tv286 = \"il2cpp_codegen_initialize_runtime_metadata\"(v285, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv334 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv335 = \"il2cpp_codegen_initialize_runtime_metadata\"(v334, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv404 = System.String;\n\tv405 = \"il2cpp_codegen_initialize_runtime_metadata\"(v404, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv517 = \"[ACTk] ObscuredPrefs: Couldn't migrate \";\n\tv518 = \"il2cpp_codegen_initialize_runtime_metadata\"(v517, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv637 = \" successfully migrated to the newer format.\";\n\tv638 = \"il2cpp_codegen_initialize_runtime_metadata\"(v637, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv768 = \"[ACTk] ObscuredPrefs: Obscured pref \";\n\tv769 = \"il2cpp_codegen_initialize_runtime_metadata\"(v768, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv827 = \" key from ACTk v1 prefs since its type is unknown!\";\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v827, cryptoKey, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A35446]) = v51;\nL_004B:\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::EncryptDecryptObsolete(key, cryptoKey);\n\tv58 = CodeStage.AntiCheat.Utils.Base64Utils::ToBase64(v54);\n\tv64 = UnityEngine.PlayerPrefs::HasKey(v58);\n\tv69 = v64 == 0;\n\tif (v69) goto L_FFFFFFFF;\n\tgoto L_005C;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v75, v62, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_005C:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetMigrationMode(1);\n\tv238.cryptoKeyObsoleteForMigration = cryptoKey;\n\tv239 = UnityEngine.PlayerPrefs::GetString(v58);\n\tv243 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetRawValueType(v239);\n\tv247 = v243 & 0xFF;\n\tv248 = v247 < 0x1E;\n\tv249 = ~v248;\n\tv250 = v247 - 0x1E;\n\tv252 = v250 == 0;\n\tv257 = ~v252;\n\tv258 = v249 & v257;\n\tif (v258) goto L_00B8;\n\tv262 = v247 < 0xF;\n\tv263 = ~v262;\n\tv264 = v247 - 0xF;\n\tv266 = v264 == 0;\n\tv271 = ~v266;\n\tv272 = v263 & v271;\n\tif (v272) goto L_00FB;\n\tv287 = v243 & 0xFF;\n\tv292 = v287 == 5;\n\tif (v292) goto L_023B;\n\tv340 = v287 == 0xA;\n\tif (v340) goto L_0250;\n\tv415 = v287 != 0xF;\n\tif (v415) goto L_0227;\n\tgoto L_00B0;\n\tv639 = \"il2cpp_codegen_runtime_class_init\"(v521, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00B0:\n\tv648 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v58, v524.Empty, v239);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetMigrationMode(0);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetString(key, v648);\n\tgoto L_0312;\nL_00B8:\n\tv273 = v247 < 0x2D;\n\tv274 = ~v273;\n\tv275 = v247 - 0x2D;\n\tv277 = v275 == 0;\n\tv282 = ~v277;\n\tv283 = v274 & v282;\n\tif (v283) goto L_0132;\n\tv309 = v243 & 0xFF;\n\tv310 = v309 < 0x23;\n\tv311 = ~v310;\n\tv312 = v309 - 0x23;\n\tv314 = v312 == 0;\n\tv319 = ~v314;\n\tv320 = v311 & v319;\n\tif (v320) goto L_0189;\n\tv371 = v309 == 0x20;\n\tif (v371) goto L_0265;\n\tv469 = v309 != 0x23;\n\tif (v469) goto L_0227;\n\tgoto L_00F3;\n\tv690 = \"il2cpp_codegen_runtime_class_init\"(v576, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00F3:\n\tv699 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v58, 0, v239);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetMigrationMode(0);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetBool(key, v699);\n\tgoto L_0312;\nL_00FB:\n\tv297 = v243 & 0xFF;\n\tv298 = v297 < 0x19;\n\tv299 = ~v298;\n\tv300 = v297 - 0x19;\n\tv302 = v300 == 0;\n\tv307 = ~v302;\n\tv308 = v299 & v307;\n\tif (v308) goto L_01C5;\n\tv353 = v297 == 0x14;\n\tif (v353) goto L_027A;\n\tv439 = v297 != 0x19;\n\tif (v439) goto L_0227;\n\tgoto L_012A;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v548, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_012A:\n\tv665 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v58, 0d, v239);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetMigrationMode(0);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetDouble(key, v665);\n\tgoto L_0312;\nL_0132:\n\tv321 = v243 & 0xFF;\n\tv322 = v321 < 0x37;\n\tv323 = ~v322;\n\tv324 = v321 - 0x37;\n\tv326 = v324 == 0;\n\tv331 = ~v326;\n\tv332 = v323 & v331;\n\tif (v332) goto L_01EF;\n\tv389 = v321 == 0x32;\n\tif (v389) goto L_028F;\n\tv497 = v321 != 0x37;\n\tif (v497) goto L_0227;\n\tgoto L_016A;\n\tv721 = UnityEngine.Quaternion;\n\tv722 = \"il2cpp_codegen_initialize_runtime_metadata\"(v721, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv725 = 1;\n\t*([1A3551A]) = v725;\nL_016A:\n\tgoto L_0173;\n\tv800 = \"il2cpp_codegen_runtime_class_init\"(v728, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0173:\n\tv809 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptQuaternionValue(key, v239, v731.identityQuaternion);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetMigrationMode(0);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetQuaternion(key, v809);\n\tgoto L_0312;\nL_0189:\n\tv380 = v309 == 0x28;\n\tif (v380) goto L_02BB;\n\tv483 = v309 != 0x2D;\n\tif (v483) goto L_0227;\n\tgoto L_01AE;\n\tv703 = UnityEngine.Vector2;\n\tv704 = \"il2cpp_codegen_initialize_runtime_metadata\"(v703, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv707 = 1;\n\t*([1A35518]) = v707;\nL_01AE:\n\tgoto L_01B5;\n\tv790 = \"il2cpp_codegen_runtime_class_init\"(v710, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_01B5:\n\tv797 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptVector2Value(key, v239, v713.zeroVector);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetMigrationMode(0);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetVector2(key, v797);\n\tgoto L_0312;\nL_01C5:\n\tv362 = v297 == 0x1B;\n\tif (v362) goto L_FFFFFFFF;\n\tv453 = v297 != 0x1E;\n\tif (v453) goto L_0227;\n\tgoto L_01E3;\n\tv668 = \"il2cpp_codegen_runtime_class_init\"(v562, v237, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_01E3:\n\tv677 = CodeStage.AntiCheat.Storage.ObscuredPrefs::DecryptValue(key, v58, 0, v239);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetMigrationMode(0);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetL\n// ... truncated")]
		private static bool MigrateFromACTkV1Internal(string key, string cryptoKey)
		{
			//IL_08c0: Expected I4, but got I8
			//IL_0847: Expected I, but got O
			//IL_094a: Expected O, but got I4
			//IL_09c6: Expected I, but got O
			//IL_0757: Expected I8, but got I4
			//IL_086a: Expected O, but got I
			//IL_05af: Expected I8, but got I4
			string value = ObscuredString.EncryptDecrypt(key, cryptoKey);
			string text = Base64Utils.ToBase64(value);
			if (PlayerPrefs.HasKey(text))
			{
				SetMigrationMode(enabled: true);
				cryptoKeyObsoleteForMigration = cryptoKey;
				string text2 = PlayerPrefs.GetString(text);
				DataType rawValueType = GetRawValueType(text2);
				int num = (int)(rawValueType & (DataType)255);
				bool flag = num < 30;
				bool flag2 = !flag;
				int num2 = num - 30;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					bool flag5 = num < 15;
					bool flag6 = !flag5;
					int num3 = num - 15;
					bool flag7 = num3 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						int num4 = (int)(rawValueType & (DataType)255);
						if (num4 != 5)
						{
							if (num4 != 10)
							{
								if (num4 != 15)
								{
									goto IL_0684;
								}
								object value2 = DecryptValue(key, text, (object)string.Empty, text2);
								SetMigrationMode(enabled: false);
								SetString(key, (string)value2);
							}
							else
							{
								uint value3 = DecryptValue(key, text, 0u, text2);
								SetMigrationMode(enabled: false);
								SetUInt(key, value3);
							}
						}
						else
						{
							int value4 = DecryptValue(key, text, 0, text2);
							SetMigrationMode(enabled: false);
							SetInt(key, value4);
						}
					}
					else
					{
						int num5 = (int)(rawValueType & (DataType)255);
						bool flag9 = num5 < 25;
						bool flag10 = !flag9;
						int num6 = num5 - 25;
						bool flag11 = num6 == 0;
						bool flag12 = !flag11;
						if (!(flag10 && flag12))
						{
							if (num5 != 20)
							{
								if (num5 != 25)
								{
									goto IL_0684;
								}
								double value5 = DecryptValue(key, text, 0.0, text2);
								SetMigrationMode(enabled: false);
								SetDouble(key, value5);
							}
							else
							{
								float value6 = DecryptValue(key, text, 0f, text2);
								SetMigrationMode(enabled: false);
								SetFloat(key, value6);
							}
						}
						else if (num5 != 27)
						{
							if (num5 != 30)
							{
								goto IL_0684;
							}
							long value7 = DecryptValue(key, text, 0L, text2);
							SetMigrationMode(enabled: false);
							SetLong(key, value7);
						}
						else
						{
							nint num7 = (nint)typeof(decimal);
							nint num8 = (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X9_v13 (Il2CppStaticFields<System.Decimal>)+8]");
							decimal value8 = DecryptValue(key, text, 0m, (string)0);
							SetMigrationMode(enabled: false);
							SetDecimal(key, value8);
						}
					}
				}
				else
				{
					bool flag13 = num < 45;
					bool flag14 = !flag13;
					int num9 = num - 45;
					bool flag15 = num9 == 0;
					bool flag16 = !flag15;
					if (!(flag14 && flag16))
					{
						int num10 = (int)(rawValueType & (DataType)255);
						bool flag17 = num10 < 35;
						bool flag18 = !flag17;
						int num11 = num10 - 35;
						bool flag19 = num11 == 0;
						bool flag20 = !flag19;
						if (!(flag18 && flag20))
						{
							if (num10 != 32)
							{
								if (num10 != 35)
								{
									goto IL_0684;
								}
								bool value9 = DecryptValue(key, text, defaultValue: false, text2);
								SetMigrationMode(enabled: false);
								SetBool(key, value9);
							}
							else
							{
								ulong value10 = DecryptValue(key, text, 0uL, text2);
								SetMigrationMode(enabled: false);
								SetULong(key, value10);
							}
						}
						else if (num10 != 40)
						{
							if (num10 != 45)
							{
								goto IL_0684;
							}
							Vector2 value11 = DecryptVector2Value(key, text2, Vector2.zero);
							SetMigrationMode(enabled: false);
							SetVector2(key, value11);
						}
						else
						{
							byte[] value12 = DecryptByteArrayValue(key, text2, 0, 0);
							SetMigrationMode(enabled: false);
							SetByteArray(key, value12);
						}
					}
					else
					{
						int num12 = (int)(rawValueType & (DataType)255);
						bool flag21 = num12 < 55;
						bool flag22 = !flag21;
						int num13 = num12 - 55;
						bool flag23 = num13 == 0;
						bool flag24 = !flag23;
						if (!(flag22 && flag24))
						{
							if (num12 != 50)
							{
								if (num12 != 55)
								{
									goto IL_0684;
								}
								Quaternion value13 = DecryptQuaternionValue(key, text2, Quaternion.identity);
								SetMigrationMode(enabled: false);
								SetQuaternion(key, value13);
							}
							else
							{
								Vector3 value14 = DecryptVector3Value(key, text2, Vector3.zero);
								SetMigrationMode(enabled: false);
								SetVector3(key, value14);
							}
						}
						else if (num12 != 60)
						{
							if (num12 != 65)
							{
								goto IL_0684;
							}
							Rect defaultValue = default(Rect);
							defaultValue.m_XMin = 0f;
							defaultValue.m_YMin = 0f;
							defaultValue.m_Width = 0f;
							defaultValue.m_Height = 0f;
							Rect value15 = DecryptRectValue(key, text2, defaultValue);
							SetMigrationMode(enabled: false);
							SetRect(key, value15);
						}
						else
						{
							uint num14 = DecryptValue(key, text, 16777216u, text2);
							int num15 = (int)((int)num14 & 0xFF00FF00L);
							int num16 = (int)(num14 & 0xFF);
							int num17 = num16 << 16;
							int num18 = num15 & -16711681;
							int num19 = num18 | num17;
							int num20 = (int)num14 >> 16;
							int num21 = num20 & 0xFF;
							int num22 = num19 & -256;
							int num23 = num22 | num21;
							SetMigrationMode(enabled: false);
							SetColor(key, (Color32)num23);
						}
					}
				}
				string message = "[ACTk] ObscuredPrefs: Obscured pref " + key + " successfully migrated to the newer format.";
				Debug.Log(message);
				cryptoKeyObsoleteForMigration = null;
				PlayerPrefs.DeleteKey(text);
				return true;
			}
			goto IL_06ae;
			IL_0684:
			string message2 = "[ACTk] ObscuredPrefs: Couldn't migrate " + key + " key from ACTk v1 prefs since its type is unknown!";
			Debug.LogWarning(message2);
			goto IL_06ae;
			IL_06ae:
			return false;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0xBDACF8", Offset = "0xBDACF8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35447]) = v37;\nL_0017:\n\tgoto L_001E;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\nL_001E:\n\tv45.migratingFromACTkV1 = enabled;\n\tv45.deviceIdHash = 0;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetMigrationMode(bool enabled)
		{
			migratingFromACTkV1 = enabled;
			deviceIdHash = 0u;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0xBDA874", Offset = "0xBDA874", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = System.Byte[];\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, dataLength, key, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 1;\n\t*([1A35448]) = v49;\nL_0020:\n\t// 32 NewArr v56 @ X0_v5 (System.Byte[]), typeof(System.Byte[]), dataLength @ X1 (System.Int32)\n\tv71 = dataLength < 1;\n\tif (v71) goto L_006D;\nL_0040:\n\tv128 = v68 / key._stringLength;\n\tv216 = v128 * key._stringLength;\n\tv115 = v68 - v216;\n\tv119 = System.String::get_Chars(key, v115);\n\tv163 = bytes[v68 @ X24_v5 (System.Int32)] ^ v119;\n\tv56[v68 @ X24_v5 (System.Int32)] = v163;\n\tv68 = v68 + 1;\n\tv141 = dataLength != v68;\n\tif (v141) goto L_0040;\nL_006D:\n\treturn v56;\n\tv118 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static byte[] EncryptDecryptBytesObsolete(byte[] bytes, int dataLength, string key)
		{
			byte[] array = new byte[dataLength];
			if (dataLength >= 1)
			{
				int num = 0;
				do
				{
					int num2 = num / key.Length;
					int num3 = num2 * key.Length;
					int index = num - num3;
					char c = key[index];
					int num4 = bytes[num] ^ c;
					array[num] = (byte)num4;
					num++;
				}
				while (dataLength != num);
			}
			return array;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0xBDAD5C", Offset = "0xBDAD5C", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tv36 = System.Boolean;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv83 = System.Decimal;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv91 = System.Double;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv99 = System.Int32;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv107 = System.Int64;\n\tv108 = \"il2cpp_codegen_initialize_runtime_metadata\"(v107, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv115 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv116 = \"il2cpp_codegen_initialize_runtime_metadata\"(v115, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv123 = System.Single;\n\tv124 = \"il2cpp_codegen_initialize_runtime_metadata\"(v123, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv131 = System.String;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv139 = System.Type;\n\tv140 = \"il2cpp_codegen_initialize_runtime_metadata\"(v139, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv147 = System.UInt32;\n\tv148 = \"il2cpp_codegen_initialize_runtime_metadata\"(v147, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv155 = System.UInt64;\n\tv156 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv171 = \"e806f6\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v171, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv57 = 1;\n\t*([1A35449]) = v57;\nL_0048:\n\tv62.cryptoKeyObsolete = \"e806f6\";\n\tv62.preservePlayerPrefs = 0;\n\tgoto L_005E;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v66, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_005E:\n\tv89 = System.Type::GetTypeFromHandle(System.Int32);\n\tv95.IntType = v89;\n\tv97 = System.Type::GetTypeFromHandle(System.UInt32);\n\tv103.UIntType = v97;\n\tv105 = System.Type::GetTypeFromHandle(System.String);\n\tv111.StringType = v105;\n\tv113 = System.Type::GetTypeFromHandle(System.Single);\n\tv119.FloatType = v113;\n\tv121 = System.Type::GetTypeFromHandle(System.Double);\n\tv127.DoubleType = v121;\n\tv129 = System.Type::GetTypeFromHandle(System.Decimal);\n\tv135.DecimalType = v129;\n\tv137 = System.Type::GetTypeFromHandle(System.Int64);\n\tv143.LongType = v137;\n\tv145 = System.Type::GetTypeFromHandle(System.UInt64);\n\tv151.ULongType = v145;\n\tv153 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv164.BoolType = v153;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObscuredPrefs()
		{
			Type typeFromHandle = typeof(int);
			IntType = typeFromHandle;
			Type typeFromHandle2 = typeof(uint);
			UIntType = typeFromHandle2;
			Type typeFromHandle3 = typeof(string);
			StringType = typeFromHandle3;
			Type typeFromHandle4 = typeof(float);
			FloatType = typeFromHandle4;
			Type typeFromHandle5 = typeof(double);
			DoubleType = typeFromHandle5;
			Type typeFromHandle6 = typeof(decimal);
			DecimalType = typeFromHandle6;
			Type typeFromHandle7 = typeof(long);
			LongType = typeFromHandle7;
			Type typeFromHandle8 = typeof(ulong);
			ULongType = typeFromHandle8;
			Type typeFromHandle9 = typeof(bool);
			BoolType = typeFromHandle9;
		}
	}
}
