using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Serialization
{
	[Token(Token = "0x2000065")]
	public static class ComponentTypeRegistry
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000066")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000FA")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000FB")]
			public static Func<Type, bool> _003C_003E9__3_0;

			[Token(Token = "0x600016D")]
			[Address(RVA = "0x3C6E2EC", Offset = "0x3C6E2EC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.BaseLayerSystems.EntitySystem.Serialization.ComponentTypeRegistry+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600016E")]
			[Address(RVA = "0x3C6E350", Offset = "0x3C6E350", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CInitialize_003Eb__3_0(Type t)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ComponentTypeRegistry._003C_003Ec::_003CInitialize_003Eb__3_0");
				return default;
			}
		}

		[Token(Token = "0x40000F7")]
		private static readonly Dictionary<string, Type> _typeByName;

		[Token(Token = "0x40000F8")]
		private static readonly Dictionary<Type, string> _nameByType;

		[Token(Token = "0x40000F9")]
		private static bool _isInitialized;

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x3C6D880", Offset = "0x3C6D880", Length = "0x578")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001E;\nL_001E:\n\tv68 = v65._isInitialized == 0;\n\tif (v68) goto L_004E;\n\tgoto L_0211;\nL_004E:\n\tv87 = System.AppDomain::get_CurrentDomain();\n\tv184 = v87 == 0;\n\tif (v184) goto L_0212;\n\tv255 = System.AppDomain::GetAssemblies(v87);\n\tv259 = v255 == 0;\n\tif (v259) goto L_0212;\n\tv280 = v255.Length < 1;\n\tif (v280) goto L_01FE;\n\tv359 = 0;\n\tv431 = System.Reflection.Assembly::GetTypes(v255[v359 @ X25_v6 (System.Int32)]);\n\tgoto L_007B;\nL_007B:\n\tv440 = v438.<>9__3_0 == 0;\n\tv441 = ~v440;\n\tv306 = v438.<>9__3_0;\n\tif (v441) goto L_00A4;\n\tgoto L_0089;\nL_0089:\n\tgoto L_0091;\nL_00A4:\n\tv463 = System.Linq.Enumerable::Where(v431, v306);\n\tv410 = v463 == 0;\n\tif (v410) goto L_014C;\n\tgoto L_00D4;\nL_00E0:\n\tgoto L_0106;\n\tv408 = v324 == 0;\n\tif (v408) goto L_0148;\n\tgoto L_0137;\nL_0141:\n\t_game.BaseLayerSystems.EntitySystem.Serialization.ComponentTypeRegistry::Register(v821, 0);\n\tv836 = v324 == 0;\n\tv608 = ~v836;\n\tv581 = v324;\n\tif (v608) goto L_00E0;\nL_0146:\n\tv403 = new System.NullReferenceException();\n\tgoto L_021B;\nL_0148:\n\tv403 = new System.NullReferenceException();\n\tgoto L_021B;\nL_014A:\n\tv403 = new System.NullReferenceException();\n\tgoto L_021B;\nL_014C:\n\tv403 = new System.NullReferenceException();\n\tgoto L_021B;\nL_0178:\n\tv677 = &v324 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<System.Type>);\n\tv678 = *([v677 @ X8_v24]) == 0;\n\tif (v678) goto L_01AC;\n\tgoto L_01A8;\n\tv359 = v359 + 1;\n\tv312 = v359 < v255.Length;\n\tif (v312) goto L_006E;\n\tgoto L_01FE;\nL_01BC:\n\tv405 = new System.OutOfMemoryException();\n\tv403 = v405;\n\tgoto L_021B;\nL_01FE:\n\tgoto L_0203;\nL_0212:\n\tthrow System.NullReferenceException;\nL_021B:\n\t// 539 Interrupt\n\tv416 = 0xA1B8(v403, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_021F;\nL_021F:\n\tv435 = 0x8BF5BF4(v416, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv444 = 0x8BF0368(v416, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv242 = 0xA1B8(v444, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0211:\n\treturn;\nL_0091:\n\tv478 = new System.Func`2<System.Type, System.Boolean>();\n\tSystem.Func`2<System.Type, System.Boolean>::.ctor(v478, v472.<>9, Il2CppMethodInfo);\n\tv518.<>9__3_0 = v478;\n\tv306 = v478;\nL_00D4:\n\tv568 = System.Collections.Generic.IEnumerable`1<System.Type>::GetEnumerator(0);\n\tv572 = v568 == 0;\n\tv581 = v568;\n\tif (v572) goto L_0146;\nL_0106:\n\tv674 = System.Collections.IEnumerator::MoveNext(v581);\n\tv676 = v674 == 0;\n\tif (v676) goto L_0178;\nL_0137:\n\tv821 = System.Collections.Generic.IEnumerator`1<System.Type>::get_Current(v324);\n\tgoto L_0141;\nL_01AC:\n\tgoto L_01BC;\nL_01A8:\n\tSystem.IDisposable::Dispose(*([v677 @ X8_v24]));\nL_006E:\n\tv409 = v255[v359 @ X25_v6 (System.Int32)] == 0;\n\tif (v409) goto L_014A;\nL_0203:\n\tv169._isInitialized = 1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentTypeRegistry::Initialize");
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x4861980", Offset = "0x4861980", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv56 = Il2CppClass<T>;\n\tgoto L_001C;\nL_001C:\n\tv61 = System.Type::GetTypeFromHandle(v56);\n\tgoto L_002A;\nL_002A:\n\t_game.BaseLayerSystems.EntitySystem.Serialization.ComponentTypeRegistry::Register(v61, 0);\n\treturn;\n\tv63 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv56 = Il2CppClass<T>;\n\tgoto L_001C;\n")]
		public static void Register<T>() where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentTypeRegistry::Register");
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x3C6DDF8", Offset = "0x3C6DDF8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv112 = 0xB28C000 + 0x958;\n\tv114 = name;\n\tgoto L_0028;\nL_0028:\n\tv74 = v72._typeByName == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0045;\n\tgoto L_0075;\nL_0032:\n\tv86 = System.Type::get_FullName(type);\n\tv112 = 0xB28C000 + 0x958;\n\tv114 = v86;\n\tgoto L_0028;\nL_0045:\n\tv124 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::ContainsKey(v72._typeByName, v114);\n\tv127 = v124 == 0;\n\tif (v127) goto L_0051;\n\treturn;\nL_0051:\n\tv162 = *([v112 @ X21_v3 (System.Int32)]);\n\tgoto L_0058;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::set_Item(*([v110 @ X8_v8]), v114, type);\n\tv166 = *([v112 @ X21_v3 (System.Int32)]);\n\tv109 = *([v166 @ X8_v11+B8]);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::set_Item(*([v109 @ X8_v12+8]), type, v114);\n\treturn;\nL_0075:\n\tthrow System.NullReferenceException;\nL_001E:\n\tv44 = name == 0;\n\tif (v44) goto L_0032;\nL_0058:\n\tv110 = *([v162 @ X0_v7+B8]);\n")]
		public static void Register(Type type, string name = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentTypeRegistry::Register");
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x3C6DF58", Offset = "0x3C6DF58", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0015;\nL_0015:\n\t_game.BaseLayerSystems.EntitySystem.Serialization.ComponentTypeRegistry::Initialize();\n\tv79 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(v61._typeByName, name, &v77 @ stack_-38_v5 (System.Type));\n\tv92 = v79 == 0;\n\tv97 = ~v92;\n\tv98 = ~v97;\n\tif (v98) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = v77;\n\tgoto L_0039;\nL_FFFFFFFF:\n\treturnVal2 = 0;\nL_0039:\n\treturn returnVal2;\n")]
		public static Type GetType(string name)
		{
			Initialize();
			if (_typeByName.TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0x3C6E02C", Offset = "0x3C6E02C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0015;\nL_0015:\n\t_game.BaseLayerSystems.EntitySystem.Serialization.ComponentTypeRegistry::Initialize();\n\tv63 = v61._nameByType == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0037;\n\tgoto L_0053;\nL_0037:\n\tv80 = System.Collections.Generic.Dictionary`2<System.Type, System.String>::TryGetValue(v61._nameByType, type, &v78 @ stack_-38_v3 (System.String));\n\tv92 = v80 == 0;\n\tif (v92) goto L_004A;\n\treturn v78;\nL_004A:\n\treturnVal3 = System.Type::get_FullName(type);\n\treturn returnVal3;\nL_0053:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n")]
		public static string GetTypeName(Type type)
		{
			Initialize();
			if (_nameByType != null)
			{
				if (_nameByType.TryGetValue(type, out var value))
				{
					return value;
				}
				return type.FullName;
			}
			return (string)(object)new NullReferenceException();
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x48618C0", Offset = "0x48618C0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv56 = Il2CppClass<T>;\n\tgoto L_001C;\nL_001C:\n\tv61 = System.Type::GetTypeFromHandle(v56);\n\tgoto L_0029;\nL_0029:\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Serialization.ComponentTypeRegistry::GetTypeName(v61);\n\treturn returnVal1;\n\tv63 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv56 = Il2CppClass<T>;\n\tgoto L_001C;\n")]
		public static string GetTypeName<T>() where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentTypeRegistry::GetTypeName");
			return default;
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0x3C6E12C", Offset = "0x3C6E12C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0013;\nL_0013:\n\tv45 = v43._typeByName == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0030;\n\tgoto L_0043;\nL_0030:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Type>::Clear(v43._typeByName);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.String>::Clear(v73._nameByType);\n\tv89._isInitialized = 0;\n\treturn;\nL_0043:\n\tthrow System.NullReferenceException;\n")]
		public static void Reset()
		{
			if (_typeByName != null)
			{
				_typeByName.Clear();
				_nameByType.Clear();
				_isInitialized = false;
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x3C6E200", Offset = "0x3C6E200", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv74 = new System.Collections.Generic.Dictionary`2<System.Type, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.String>::.ctor(v74);\n\tv80._nameByType = v74;\n\treturn;\nL_002C:\n\tv57 = new System.Collections.Generic.Dictionary`2<System.String, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Type>::.ctor(v57);\n\tv67._typeByName = v57;\n")]
		static ComponentTypeRegistry()
		{
			Dictionary<string, Type> typeByName = new Dictionary<string, Type>();
			_typeByName = typeByName;
			Dictionary<Type, string> nameByType = new Dictionary<Type, string>();
			_nameByType = nameByType;
		}
	}
}
