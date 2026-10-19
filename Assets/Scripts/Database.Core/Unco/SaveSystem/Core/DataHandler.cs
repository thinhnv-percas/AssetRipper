using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core
{
	[Token(Token = "0x2000005")]
	public static class DataHandler
	{
		[CompilerGenerated]
		[Token(Token = "0x2000009")]
		private sealed class _003C_003Ec__DisplayClass20_0<T>
		{
			[Token(Token = "0x400000C")]
			[FieldOffset(Offset = "0x0")]
			public T o;

			[Token(Token = "0x6000020")]
			[Address(RVA = "0x5DB9498", Offset = "0x5DB9498", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass20_0()
			{
			}

			internal void _003CGetJsonLocal_003Eb__0(T obj)
			{
				o = obj;
			}
		}

		[Token(Token = "0x4000006")]
		public static readonly IDataHandler _localDataHandler;

		[Token(Token = "0x17000001")]
		[field: Token(Token = "0x4000007")]
		public static IDataHandler RemoteDataHandler
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x3F3C490", Offset = "0x3F3C490", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0018;\nL_0018:\n\treturn v43.<RemoteDataHandler>k__BackingField;\n")]
			get;
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x3F3C50C", Offset = "0x3F3C50C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001F;\nL_001F:\n\tv51.<RemoteDataHandler>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000002")]
		[field: Token(Token = "0x4000008")]
		public static bool BlockSave
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x3F3C578", Offset = "0x3F3C578", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0018;\nL_0018:\n\treturn v43.<BlockSave>k__BackingField;\n")]
			get;
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x3F3C5F4", Offset = "0x3F3C5F4", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv49.<BlockSave>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x3F3C680", Offset = "0x3F3C680", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_002A;\n\tv316 = *([v317 @ X21_v4 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv192 = *([v316 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv80 = *([v316 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v80) goto L_0082;\n\tv309 = *([v316 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv309 = v309 + 0x10;\n\tv149 = v192 - 1;\n\tv110 = v192 != 1;\n\tv192 = v149;\n\tif (v110) goto L_003B;\n\tgoto L_0082;\nL_0050:\n\tgoto L_0055;\nL_0055:\n\tgoto L_0059;\nL_0059:\n\tgoto L_005B;\nL_005B:\n\tv317 = v171.<RemoteDataHandler>k__BackingField;\n\tv173 = v171.<RemoteDataHandler>k__BackingField == 0;\n\tif (v173) goto L_00BC;\n\tv316 = *([v317 @ X21_v4 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv312 = *([v316 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv156 = *([v316 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v156) goto L_0082;\n\tv309 = *([v316 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv309 = v309 + 0x10;\n\tv148 = v312 - 1;\n\tv108 = v312 != 1;\n\tv312 = v148;\n\tif (v108) goto L_006C;\nL_0082:\n\tgoto L_0098;\nL_0084:\n\tv319 = *([v309 @ X10_v2]) << 4;\n\tv320 = v316 + v319;\n\tv324 = v320 + 0x138;\nL_00BC:\n\treturn;\nL_0022:\n\tv58 = ~isLocal;\n\tif (v58) goto L_0050;\nL_002A:\n\tv317 = v67._localDataHandler;\nL_003B:\n\tv197 = *([v309 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataLoader;\n\tif (v197) goto L_0084;\nL_006C:\n\tv302 = *([v309 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataLoader;\n\tif (v302) goto L_0084;\nL_0098:\n\tUnco.SaveSystem.Core.IDataLoader::LoadFloat(v317, key, onComplete, *([v324 @ X0_v3+8]));\nL_0098:\n\treturn;\n")]
		public static void LoadFloat(string key, Action<float> onComplete, float defaultValue = 0f, bool isLocal = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::LoadFloat");
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x3F3C844", Offset = "0x3F3C844", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_0028;\n\tv306 = *([v307 @ X22_v4 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv188 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv76 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v76) goto L_0080;\n\tv299 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv299 = v299 + 0x10;\n\tv145 = v188 - 1;\n\tv106 = v188 != 1;\n\tv188 = v145;\n\tif (v106) goto L_0039;\n\tgoto L_0080;\nL_004E:\n\tgoto L_0053;\nL_0053:\n\tgoto L_0057;\nL_0057:\n\tgoto L_0059;\nL_0059:\n\tv307 = v167.<RemoteDataHandler>k__BackingField;\n\tv169 = v167.<RemoteDataHandler>k__BackingField == 0;\n\tif (v169) goto L_00B7;\n\tv306 = *([v307 @ X22_v4 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv302 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv152 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v152) goto L_0080;\n\tv299 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv299 = v299 + 0x10;\n\tv144 = v302 - 1;\n\tv104 = v302 != 1;\n\tv302 = v144;\n\tif (v104) goto L_006A;\nL_0080:\n\tgoto L_0095;\nL_0082:\n\t;\nL_00B7:\n\treturn;\nL_0020:\n\tv54 = ~isLocal;\n\tif (v54) goto L_004E;\nL_0028:\n\tv307 = v63._localDataHandler;\nL_0039:\n\tv193 = *([v299 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataLoader;\n\tif (v193) goto L_0082;\nL_006A:\n\tv292 = *([v299 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataLoader;\n\tif (v292) goto L_0082;\nL_0095:\n\tUnco.SaveSystem.Core.IDataLoader::LoadInt(v307, key, onComplete, defaultValue);\nL_0095:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadInt(string key, Action<int> onComplete, int defaultValue = 0, bool isLocal = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::LoadInt");
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x3F3CA00", Offset = "0x3F3CA00", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_0028;\n\tv306 = *([v307 @ X22_v4 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv188 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv76 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v76) goto L_0080;\n\tv299 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv299 = v299 + 0x10;\n\tv145 = v188 - 1;\n\tv106 = v188 != 1;\n\tv188 = v145;\n\tif (v106) goto L_0039;\n\tgoto L_0080;\nL_004E:\n\tgoto L_0053;\nL_0053:\n\tgoto L_0057;\nL_0057:\n\tgoto L_0059;\nL_0059:\n\tv307 = v167.<RemoteDataHandler>k__BackingField;\n\tv169 = v167.<RemoteDataHandler>k__BackingField == 0;\n\tif (v169) goto L_00B7;\n\tv306 = *([v307 @ X22_v4 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv302 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv152 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v152) goto L_0080;\n\tv299 = *([v306 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv299 = v299 + 0x10;\n\tv144 = v302 - 1;\n\tv104 = v302 != 1;\n\tv302 = v144;\n\tif (v104) goto L_006A;\nL_0080:\n\tgoto L_0095;\nL_0082:\n\t;\nL_00B7:\n\treturn;\nL_0020:\n\tv54 = ~isLocal;\n\tif (v54) goto L_004E;\nL_0028:\n\tv307 = v63._localDataHandler;\nL_0039:\n\tv193 = *([v299 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataLoader;\n\tif (v193) goto L_0082;\nL_006A:\n\tv292 = *([v299 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataLoader;\n\tif (v292) goto L_0082;\nL_0095:\n\tUnco.SaveSystem.Core.IDataLoader::LoadString(v307, key, onComplete, defaultValue);\nL_0095:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadString(string key, Action<string> onComplete, string defaultValue = "", bool isLocal = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::LoadString");
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x4889C80", Offset = "0x4889C80", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = *([A4731E0]);\n\tv40 = defaultValue;\n\tgoto L_0027;\n\tgoto L_0027;\n\tv59 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv88 = Il2CppClass<T>;\n\tgoto L_003C;\nL_FFFFFFFF:\n\tv132 = defaultValue;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv132 = &v40 @ stack_-88_v1 (T);\n\tv180 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv289 = v71;\n\tgoto L_005F;\n\tv409 = *([v309 @ X8_v35 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv409 = v409 + 0x10;\n\tv335 = v400 - 1;\n\tv333 = v400 != 1;\nL_FFFFFFFF:\n\tv400 = v335;\n\tif (v333) goto L_0065;\nL_007E:\n\tv445 = 0x220C5E0(v91, Il2CppClass<Unco.SaveSystem.Core.IDataLoader>, *([v180 @ X22_v7 (Il2CppMethodInfo)+50]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00F2;\nL_0081:\n\tgoto L_0086;\nL_0086:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv291 = Unco.SaveSystem.Core.DataHandler;\n\tgoto L_008C;\nL_008C:\n\tv161 = v143.<RemoteDataHandler>k__BackingField;\n\tv145 = v143.<RemoteDataHandler>k__BackingField == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_00A9;\n\tgoto L_0110;\nL_00A9:\n\tv164 = Il2CppClass<T>;\n\tv169 = *([v164 @ X8_v10 (Il2CppClass<T>)+28]) < 0;\n\tv172 = *([v164 @ X8_v10 (Il2CppClass<T>)+28]) ^ *([v164 @ X8_v10 (Il2CppClass<T>)+28]);\n\tv173 = *([v164 @ X8_v10 (Il2CppClass<T>)+28]) & v172;\n\tv174 = v173 < 0;\n\tv176 = v169 == v174;\n\tv177 = ~v176;\n\tv178 = ~v177;\n\tif (v178) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv324 = defaultValue;\n\tgoto L_00BF;\nL_FFFFFFFF:\n\tv324 = &v40 @ stack_-88_v1 (T);\n\tv497 = *([v423 @ X8_v15 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv497 = v497 + 0x10;\n\tv457 = v488 - 1;\n\tv455 = v488 != 1;\nL_FFFFFFFF:\n\tv488 = v457;\n\tif (v455) goto L_00D0;\nL_00E9:\n\tv535 = 0x220C5E0(v143.<RemoteDataHandler>k__BackingField, Il2CppClass<Unco.SaveSystem.Core.IDataLoader>, *([v393 @ X22_v6 (Il2CppMethodInfo)+50]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0103;\nL_00EC:\n\tv428 = *([v409 @ X10_v16]) + *([v180 @ X22_v7 (Il2CppMethodInfo)+50]);\n\tv429 = v428 << 4;\n\tv430 = v309 + v429;\n\tv445 = v430 + 0x138;\nL_00FD:\n\tv531 = *([v497 @ X10_v10]) + *([v393 @ X22_v6 (Il2CppMethodInfo)+50]);\n\tv532 = v531 << 4;\n\tv533 = v423 + v532;\n\tv535 = v533 + 0x138;\n\treturn;\nL_012C:\n\tv235 = 0x8BF5CF0(v291, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthrow System.NullReferenceException;\nL_0027:\n\tv65 = Il2CppClass<T>;\n\tv69 = *([v65 @ X8_v4 (Il2CppClass<T>)+FC]) + 0xF;\n\tv70 = v69 & 0x1FFFFFFF0;\n\t// 44 StackAlloc v71 @ X21_v1 (System.Byte*), v70 @ X10_v2 (System.Int32)\n\tv77 = ~isLocal;\n\tif (v77) goto L_0081;\nL_003C:\n\tv91 = v90._localDataHandler;\n\tv96 = *([v88 @ X8_v30 (Il2CppClass<T>)+28]) < 0;\n\tv99 = *([v88 @ X8_v30 (Il2CppClass<T>)+28]) ^ *([v88 @ X8_v30 (Il2CppClass<T>)+28]);\n\tv100 = *([v88 @ X8_v30 (Il2CppClass<T>)+28]) & v99;\n\tv101 = v100 < 0;\n\tv103 = v96 == v101;\n\tv104 = ~v103;\n\tv105 = ~v104;\n\tif (v105) goto L_FFFFFFFF;\nL_0052:\n\tv135 = 0x8BF6A1C(v71, v132, *([v65 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_005F:\n\tv309 = *([v91 @ X23_v7 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv400 = *([v309 @ X8_v35 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv311 = *([v309 @ X8_v35 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v311) goto L_007E;\nL_0065:\n\t;\n\tv414 = *([v409 @ X10_v16-8]) == Il2CppClass<Unco.SaveSystem.Core.IDataLoader>;\n\tif (v414) goto L_00EC;\nL_00F2:\n\tv449 = 0x21C11C8(*([v445 @ X0_v34+8]), Il2CppMethodInfo, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv479 = key;\n\tv480 = onComplete;\n\tv481 = v289;\n\tv526 = *([v449 @ X0_v36 (System.Action`1<T>)+8]);\n\tv296 = *([v526 @ X0_v3+10]);\nL_FFFFFFFF:\n\tv251 = v91;\nL_FFFFFFFF:\n\tv252 = &v479 @ stack_-80_v5 (System.String);\nL_FFFFFFFF:\n\tv290 = v449;\n\tgoto L_010D;\nL_0110:\n\tv301 = *([A4731E0]);\n\tv209 = *([v301 @ X9_v6]) != *([v37 @ X8_v2]);\n\tif (v209) goto L_012C;\nL_00BF:\n\tv327 = 0x8BF6A1C(v71, v324, *([v65 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv393 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv289 = v71;\n\tgoto L_00CA;\nL_00CA:\n\tv423 = *([v161 @ X25_v6 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv488 = *([v423 @ X8_v15 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv425 = *([v423 @ X8_v15 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v425) goto L_00E9;\nL_00D0:\n\t;\n\tv502 = *([v497 @ X10_v10-8]) == Il2CppClass<Unco.SaveSystem.Core.IDataLoader>;\n\tif (v502) goto L_00FD;\nL_0103:\n\tv539 = 0x21C11C8(*([v535 @ X0_v12+8]), Il2CppMethodInfo, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv479 = key;\n\tv511 = onComplete;\n\tv510 = v289;\n\tv526 = *([v539 @ X0_v14 (System.Action`1<T>)+8]);\n\tv296 = *([v526 @ X0_v3+10]);\nL_FFFFFFFF:\n\tv251 = v143.<RemoteDataHandler>k__BackingField;\nL_FFFFFFFF:\n\tv252 = &v479 @ stack_-80_v5 (System.String);\nL_FFFFFFFF:\n\tv290 = v539;\nL_010D:\n\tv296(v291, v526, v290, v251, v252, v289, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n")]
		public unsafe static void LoadJson<T>(string key, Action<T> onComplete, T defaultValue = default(T), bool isLocal = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::LoadJson");
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x3F3CBBC", Offset = "0x3F3CBBC", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001F;\nL_001F:\n\tgoto L_0023;\nL_0023:\n\tgoto L_0027;\nL_0027:\n\tv102 = v99.<BlockSave>k__BackingField == 0;\n\tif (v102) goto L_0051;\n\tgoto L_00EB;\nL_0051:\n\tv120 = ~isLocal;\n\tif (v120) goto L_007F;\n\tgoto L_0059;\n\tv380 = *([v381 @ X21_v6 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv338 = *([v380 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv242 = *([v380 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v242) goto L_00B1;\n\tv373 = *([v380 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv373 = v373 + 0x10;\n\tv301 = v338 - 1;\n\tv269 = v338 != 1;\n\tv338 = v301;\n\tif (v269) goto L_006A;\n\tgoto L_00B1;\nL_007F:\n\tgoto L_0084;\nL_0084:\n\tgoto L_0088;\nL_0088:\n\tgoto L_008A;\nL_008A:\n\tv381 = v132.<RemoteDataHandler>k__BackingField;\n\tv129 = v132.<RemoteDataHandler>k__BackingField == 0;\n\tif (v129) goto L_00EB;\n\tv380 = *([v381 @ X21_v6 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv377 = *([v380 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv306 = *([v380 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v306) goto L_00B1;\n\tv373 = *([v380 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv373 = v373 + 0x10;\n\tv300 = v377 - 1;\n\tv268 = v377 != 1;\n\tv377 = v300;\n\tif (v268) goto L_009B;\nL_00B1:\n\tgoto L_00C7;\nL_00B3:\n\tv383 = *([v373 @ X10_v2]) << 4;\n\tv384 = v380 + v383;\n\tv388 = v384 + 0x138;\nL_00EB:\n\treturn;\nL_0059:\n\tv381 = v214._localDataHandler;\nL_006A:\n\tv343 = *([v373 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataSaver;\n\tif (v343) goto L_00B3;\nL_009B:\n\tv366 = *([v373 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataSaver;\n\tif (v366) goto L_00B3;\nL_00C7:\n\tUnco.SaveSystem.Core.IDataSaver::SaveFloat(v381, key, onSaveComplete, *([v388 @ X0_v3+8]));\nL_00C7:\n\treturn;\n")]
		public static void SaveFloat(string key, float value, bool isLocal = false, Action<float> onSaveComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::SaveFloat");
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x3F3CE00", Offset = "0x3F3CE00", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001D;\nL_001D:\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv98 = v95.<BlockSave>k__BackingField == 0;\n\tif (v98) goto L_004F;\n\tgoto L_00E6;\nL_004F:\n\tv116 = ~isLocal;\n\tif (v116) goto L_007D;\n\tgoto L_0057;\n\tv370 = *([v371 @ X22_v6 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv328 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv232 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v232) goto L_00AF;\n\tv363 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv363 = v363 + 0x10;\n\tv291 = v328 - 1;\n\tv259 = v328 != 1;\n\tv328 = v291;\n\tif (v259) goto L_0068;\n\tgoto L_00AF;\nL_007D:\n\tgoto L_0082;\nL_0082:\n\tgoto L_0086;\nL_0086:\n\tgoto L_0088;\nL_0088:\n\tv371 = v128.<RemoteDataHandler>k__BackingField;\n\tv125 = v128.<RemoteDataHandler>k__BackingField == 0;\n\tif (v125) goto L_00E6;\n\tv370 = *([v371 @ X22_v6 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv367 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv296 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v296) goto L_00AF;\n\tv363 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv363 = v363 + 0x10;\n\tv290 = v367 - 1;\n\tv258 = v367 != 1;\n\tv367 = v290;\n\tif (v258) goto L_0099;\nL_00AF:\n\tgoto L_00C4;\nL_00B1:\n\t;\nL_00E6:\n\treturn;\nL_0057:\n\tv371 = v204._localDataHandler;\nL_0068:\n\tv333 = *([v363 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataSaver;\n\tif (v333) goto L_00B1;\nL_0099:\n\tv356 = *([v363 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataSaver;\n\tif (v356) goto L_00B1;\nL_00C4:\n\tUnco.SaveSystem.Core.IDataSaver::SaveInt(v371, key, value, onSaveComplete);\nL_00C4:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SaveInt(string key, int value, bool isLocal = false, Action<int> onSaveComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::SaveInt");
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x3F3D03C", Offset = "0x3F3D03C", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001D;\nL_001D:\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv98 = v95.<BlockSave>k__BackingField == 0;\n\tif (v98) goto L_004F;\n\tgoto L_00E6;\nL_004F:\n\tv116 = ~isLocal;\n\tif (v116) goto L_007D;\n\tgoto L_0057;\n\tv370 = *([v371 @ X22_v6 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv328 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv232 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v232) goto L_00AF;\n\tv363 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv363 = v363 + 0x10;\n\tv291 = v328 - 1;\n\tv259 = v328 != 1;\n\tv328 = v291;\n\tif (v259) goto L_0068;\n\tgoto L_00AF;\nL_007D:\n\tgoto L_0082;\nL_0082:\n\tgoto L_0086;\nL_0086:\n\tgoto L_0088;\nL_0088:\n\tv371 = v128.<RemoteDataHandler>k__BackingField;\n\tv125 = v128.<RemoteDataHandler>k__BackingField == 0;\n\tif (v125) goto L_00E6;\n\tv370 = *([v371 @ X22_v6 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv367 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv296 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v296) goto L_00AF;\n\tv363 = *([v370 @ X8_v5 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv363 = v363 + 0x10;\n\tv290 = v367 - 1;\n\tv258 = v367 != 1;\n\tv367 = v290;\n\tif (v258) goto L_0099;\nL_00AF:\n\tgoto L_00C4;\nL_00B1:\n\t;\nL_00E6:\n\treturn;\nL_0057:\n\tv371 = v204._localDataHandler;\nL_0068:\n\tv333 = *([v363 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataSaver;\n\tif (v333) goto L_00B1;\nL_0099:\n\tv356 = *([v363 @ X10_v2-8]) == Unco.SaveSystem.Core.IDataSaver;\n\tif (v356) goto L_00B1;\nL_00C4:\n\tUnco.SaveSystem.Core.IDataSaver::SaveString(v371, key, value, onSaveComplete);\nL_00C4:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SaveString(string key, string value, bool isLocal = false, Action<string> onSaveComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::SaveString");
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x4889F44", Offset = "0x4889F44", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_001C;\nL_001C:\n\tv124 = 0xB28D000 + 0x80;\n\tgoto L_0023;\nL_0023:\n\tv69 = *([B193B8E]) & 1;\n\tv70 = v69 == 0;\n\tv114 = v124;\n\tif (v70) goto L_0044;\n\tv125 = *([v124 @ X24_v3 (System.Int32)]);\n\tv88 = *([v125 @ X0_v2+E4]) == 0;\n\tv114 = v124;\n\tif (v88) goto L_004B;\nL_002A:\n\tv227 = *([v125 @ X0_v2+B8]);\n\tv111 = *([v227 @ X8_v22+10]) & 1;\n\tv112 = v111 == 0;\n\tif (v112) goto L_0053;\n\tgoto L_00F2;\n\tv77 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv124 = 0xB28D000 + 0x80;\n\tgoto L_0023;\nL_0044:\n\t*([B193B8E]) = 1;\n\tv125 = *([v124 @ X24_v3 (System.Int32)]);\n\tv120 = *([v125 @ X0_v2+E4]) == 0;\n\tv106 = ~v120;\n\tv124 = v124;\n\tif (v106) goto L_002A;\nL_004B:\n\tv125 = *([v114 @ X24_v5 (System.Int32)]);\n\tv227 = *([v125 @ X0_v2+B8]);\n\tv133 = *([v227 @ X8_v22+10]) & 1;\n\tv134 = v133 == 0;\n\tv128 = ~v134;\n\tv124 = v114;\n\tif (v128) goto L_00F2;\nL_0053:\n\tv132 = ~isLocal;\n\tif (v132) goto L_0081;\n\tgoto L_005B;\n\tv251 = Il2CppMethodInfo;\n\tv391 = *([v251 @ X22_v8 (Il2CppMethodInfo)+50]);\n\tv397 = *([v398 @ X23_v6]);\n\tv355 = *([v397 @ X8_v5+12E]);\n\tv256 = *([v397 @ X8_v5+12E]) == 0;\n\tv313 = Il2CppClass<Unco.SaveSystem.Core.IDataSaver>;\n\tv409 = Il2CppMethodInfo;\n\tif (v256) goto L_00B3;\n\tv389 = *([v397 @ X8_v5+B0]) + 8;\n\tv389 = v389 + 0x10;\n\tv317 = v355 - 1;\n\tv283 = v355 != 1;\n\tv355 = v317;\n\tif (v283) goto L_006D;\n\tv313 = Il2CppClass<Unco.SaveSystem.Core.IDataSaver>;\n\tv409 = Il2CppMethodInfo;\n\tgoto L_00B3;\nL_0081:\n\tv162 = *([v125 @ X0_v2+E4]) == 0;\n\tif (v162) goto L_00D2;\n\tv246 = *([B193B8D]) & 1;\n\tv247 = v246 == 0;\n\tif (v247) goto L_00DA;\nL_0088:\n\tv140 = *([v124 @ X24_v3 (System.Int32)]);\n\tv266 = *([v140 @ X0_v22+E4]) == 0;\n\tif (v266) goto L_00E1;\nL_008C:\n\tv146 = *([v140 @ X0_v22+B8]);\n\tv398 = *([v146 @ X8_v18+8]);\n\tv143 = *([v146 @ X8_v18+8]) == 0;\n\tif (v143) goto L_00F2;\nL_0091:\n\tv328 = Il2CppMethodInfo;\n\tv391 = *([v328 @ X22_v7 (Il2CppMethodInfo)+50]);\n\tv397 = *([v398 @ X23_v6]);\n\tv394 = *([v397 @ X8_v5+12E]);\n\tv322 = *([v397 @ X8_v5+12E]) == 0;\n\tv313 = Il2CppClass<Unco.SaveSystem.Core.IDataSaver>;\n\tv409 = Il2CppMethodInfo;\n\tif (v322) goto L_00B3;\n\tv389 = *([v397 @ X8_v5+B0]) + 8;\n\tv389 = v389 + 0x10;\n\tv316 = v394 - 1;\n\tv282 = v394 != 1;\n\tv313 = Il2CppClass<Unco.SaveSystem.Core.IDataSaver>;\n\tv409 = Il2CppMethodInfo;\n\tv394 = v316;\n\tif (v282) goto L_009F;\nL_00B3:\n\tv407 = 0x220C5E0(v398, v313, v391, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00BC;\nL_00B6:\n\tv401 = *([v389 @ X10_v2]) + v391;\n\tv402 = v401 << 4;\n\tv403 = v397 + v402;\n\tv407 = v403 + 0x138;\nL_00D2:\n\tv274 = *([B193B8D]) & 1;\n\tv275 = v274 == 0;\n\tv259 = ~v275;\n\tif (v259) goto L_0088;\nL_00DA:\n\t*([B193B8D]) = 1;\n\tv140 = *([v124 @ X24_v3 (System.Int32)]);\n\tv343 = *([v140 @ X0_v22+E4]) == 0;\n\tv333 = ~v343;\n\tif (v333) goto L_008C;\nL_00E1:\n\tv139 = *([v124 @ X24_v3 (System.Int32)]);\n\tv145 = *([v139 @ X0_v14+B8]);\n\tv398 = *([v145 @ X8_v9+8]);\n\tv368 = *([v145 @ X8_v9+8]) == 0;\n\tv142 = ~v368;\n\tif (v142) goto L_0091;\nL_00F2:\n\treturn;\nL_005B:\n\tv398 = *([v227 @ X8_v22]);\nL_006D:\n\tv360 = *([v389 @ X10_v2-8]) == Il2CppClass<Unco.SaveSystem.Core.IDataSaver>;\n\tv409 = Il2CppMethodInfo;\n\tif (v360) goto L_00B6;\nL_009F:\n\tv382 = *([v389 @ X10_v2-8]) == Il2CppClass<Unco.SaveSystem.Core.IDataSaver>;\n\tv409 = Il2CppMethodInfo;\n\tif (v382) goto L_00B6;\nL_00BC:\n\tv412 = 0x21C11C8(*([v407 @ X0_v3+8]), v409, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv173 = *([v412 @ X0_v5+8]);\n\t// 206 IndirectJump v173 @ X5_v1, v398 @ X23_v6, v398 @ X23_v6, key @ X0 (System.String), value @ X1 (T), onSaveComplete @ X3 (System.Action`1<T>), v412 @ X0_v5, v173 @ X5_v1, v39 @ X6, v40 @ X7, v41 @ V0, v42 @ V1, v43 @ V2, v44 @ V3, v45 @ V4, v46 @ V5, v47 @ V6, v48 @ V7\n")]
		public static void SaveJson<T>(string key, T value, bool isLocal = false, Action<T> onSaveComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::SaveJson");
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x3F3D278", Offset = "0x3F3D278", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv50.value = 0f;\n\tgoto L_003C;\n\tgoto L_0073;\nL_0025:\n\tv50 = new Unco.SaveSystem.Core.DataHandler+<>c__DisplayClass17_0();\n\tSystem.Object::.ctor(v50);\nL_003C:\n\tv83 = new System.Action`1<System.Single>();\n\tSystem.Action`1<System.Single>::.ctor(v83, v50, Il2CppMethodInfo);\nL_0073:\n\tUnco.SaveSystem.Core.IDataLoader::LoadFloat(v89._localDataHandler, key, v83, 0f);\n\treturn v50.value;\n")]
		public static float GetFloatLocal(string key)
		{
			float value = 0f;
			Action<float> onComplete = delegate(float f)
			{
				value = f;
			};
			_localDataHandler.LoadFloat(key, onComplete);
			return value;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x3F3D3E8", Offset = "0x3F3D3E8", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv51.value = 0;\n\tgoto L_003D;\n\tgoto L_0075;\nL_0026:\n\tv51 = new Unco.SaveSystem.Core.DataHandler+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v51);\nL_003D:\n\tv84 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v84, v51, Il2CppMethodInfo);\nL_0075:\n\tUnco.SaveSystem.Core.IDataLoader::LoadInt(v90._localDataHandler, key, v84, defaultValue);\n\treturn v51.value;\n")]
		public static int GetIntLocal(string key, int defaultValue = 0)
		{
			int value = 0;
			Action<int> onComplete = delegate(int i)
			{
				value = i;
			};
			_localDataHandler.LoadInt(key, onComplete, defaultValue);
			return value;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x3F3D560", Offset = "0x3F3D560", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv54.value = \"\";\n\tgoto L_0048;\n\tgoto L_0081;\nL_002A:\n\tv54 = new Unco.SaveSystem.Core.DataHandler+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v54);\nL_0048:\n\tv91 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v91, v54, Il2CppMethodInfo);\nL_0081:\n\tUnco.SaveSystem.Core.IDataLoader::LoadString(v97._localDataHandler, key, v91, \"\");\n\treturn v54.value;\n")]
		public static string GetStringLocal(string key)
		{
			string value = "";
			Action<string> onComplete = delegate(string f)
			{
				value = f;
			};
			_localDataHandler.LoadString(key, onComplete);
			return value;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x48898BC", Offset = "0x48898BC", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv61 = Il2CppClass<Unco.SaveSystem.Core.DataHandler+<>c__DisplayClass20_0`1<T>>;\n\tgoto L_001F;\nL_001F:\n\tv64 = new v61();\n\tUnco.SaveSystem.Core.DataHandler+<>c__DisplayClass20_0`1<T>::.ctor(v64);\n\tv73 = v64 == 0;\nL_FFFFFFFF:\n\tv90 = v64;\n\tif (v73) goto L_008D;\n\tv64.o = 0;\n\tgoto L_0031;\nL_003B:\n\tv90 = new Il2CppClass<System.Action`1<T>>();\n\tSystem.Action`1<System.Object>::.ctor(v90, v64, Il2CppMethodInfo);\n\tv93 = v100._localDataHandler == 0;\n\tif (v93) goto L_008D;\n\tv180 = Il2CppMethodInfo;\n\tv183 = *([v87 @ X23_v4 (Unco.SaveSystem.Core.IDataHandler)]);\n\tv224 = *([v183 @ X8_v12 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]);\n\tv168 = *([v183 @ X8_v12 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+12E]) == 0;\n\tif (v168) goto L_0067;\n\tv223 = *([v183 @ X8_v12 (Il2CppClass<Unco.SaveSystem.Core.IDataHandler>)+B0]) + 8;\n\tv223 = v223 + 0x10;\n\tv210 = v224 - 1;\n\tv190 = v224 != 1;\nL_FFFFFFFF:\n\tv224 = v210;\n\tif (v190) goto L_0053;\nL_0067:\n\tv212 = 0x220C5E0(v100._localDataHandler, Il2CppClass<Unco.SaveSystem.Core.IDataLoader>, *([v180 @ X22_v2 (Il2CppMethodInfo)+50]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0077;\n\tv66 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv61 = Il2CppClass<Unco.SaveSystem.Core.DataHandler+<>c__DisplayClass20_0`1<T>>;\n\tgoto L_001F;\nL_008D:\n\tthrow v90;\nL_0031:\n\tv87 = v100._localDataHandler;\n\tgoto L_003B;\nL_0053:\n\tv229 = *([v223 @ X10_v5-8]) == Il2CppClass<Unco.SaveSystem.Core.IDataLoader>;\n\tif (v229) goto L_0077;\nL_0077:\n\tv246 = Unco.SaveSystem.Core.IDataLoader::LoadJson(v100._localDataHandler, key, v90, defaultValue);\n\treturn v64.o;\n")]
		public static T GetJsonLocal<T>(string key, T defaultValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DataHandler::GetJsonLocal");
			return default;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x3F3D704", Offset = "0x3F3D704", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = v49._localDataHandler == 0;\n\tif (v51) goto L_0058;\n\tgoto L_0068;\nL_0058:\n\treturn;\nL_0068:\n\tUnco.SaveSystem.Core.IDataHandler::DeleteData(v49._localDataHandler, key);\n\treturn;\n")]
		public static void DeleteLocal(string key)
		{
			if (_localDataHandler != null)
			{
				_localDataHandler.DeleteData(key);
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x3F3D804", Offset = "0x3F3D804", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_001F;\nL_001F:\n\tv90 = v88.<RemoteDataHandler>k__BackingField == 0;\n\tif (v90) goto L_0072;\n\tgoto L_0082;\nL_0072:\n\treturn;\nL_0082:\n\tUnco.SaveSystem.Core.IDataHandler::DeleteData(v88.<RemoteDataHandler>k__BackingField, key);\n\treturn;\n")]
		public static void DeleteRemote(string key)
		{
			if (RemoteDataHandler != null)
			{
				RemoteDataHandler.DeleteData(key);
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x3F3D94C", Offset = "0x3F3D94C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\treturn;\nL_001B:\n\tv47 = new Unco.SaveSystem.Core.LocalDataHandler();\n\tSystem.Object::.ctor(v47);\n\tv53._localDataHandler = v47;\n")]
		static DataHandler()
		{
			LocalDataHandler localDataHandler = new LocalDataHandler();
			_localDataHandler = localDataHandler;
		}
	}
}
