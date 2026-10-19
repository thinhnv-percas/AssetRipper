using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Pooling
{
	[Token(Token = "0x2000017")]
	internal sealed class SizeSpecificArrayPool<T> where T : new()
	{
		[Token(Token = "0x4000027")]
		public const int InitialBucketSize = 4;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x0")]
		private readonly T[][][] _buckets;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x0")]
		private int[] _rentals;

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x626DDF4", Offset = "0x626DDF4", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002D:\n\t// 45 NewArr v72 @ X0_v5 (T[][][]), typeof(Il2CppClass<T[][][]>), v60 @ X20_v2 (System.Int32)\n\tthis._buckets = v72;\n\t// 54 NewArr v80 @ X0_v9 (System.Int32[]), typeof(System.Int32[]), v60 @ X20_v2 (System.Int32)\n\tthis._rentals = v80;\n\tv86 = maxLength < 0x7FFFFFFE;\n\tv87 = ~v86;\n\tv88 = maxLength - 0x7FFFFFFE;\n\tv90 = v88 == 0;\n\tv95 = ~v90;\n\tv96 = v87 & v95;\n\tif (v96) goto L_00D0;\n\tv170 = 0;\nL_0055:\n\t// 85 NewArr v226 @ X0_v16 (System.Int32[]), typeof(Il2CppClass<T[][]>), 4\n\tv239 = v226.Length < 1;\n\tif (v239) goto L_009D;\n\tv294 = v226 + 0x20;\n\tv295 = 0;\nL_0073:\n\t// 115 NewArr v324 @ X0_v33 (Il2CppClass<T[]>), typeof(Il2CppClass<T[]>), v170 @ X22_v5 (System.Int32)\n\tv325 = v324 == 0;\n\tif (v325) goto L_0089;\n\tv353 = 0x21C11D0(v324, System.Int32, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv355 = v353 == 0;\n\tif (v355) goto L_00D2;\nL_0089:\n\t*([v294 @ X24_v12]) = v324;\n\tv273 = v294 + 8;\n\tv295 = v295 + 1;\n\tv278 = v295 < v226.Length;\n\tv294 = v273;\n\tif (v278) goto L_0070;\nL_009D:\n\tv106 = this._buckets;\n\tv320 = 0x21C11D0(v226, T[][], clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv132 = v320 == 0;\n\tif (v132) goto L_00D2;\n\tv106[v170 @ X22_v5 (System.Int32)] = v226;\n\tv170 = v170 + 1;\n\tv110 = v170 != v60;\n\tif (v110) goto L_0052;\nL_00D0:\n\treturn;\nL_00D2:\n\tv358 = new System.ArrayTypeMismatchException();\n\tthrow v358;\nL_0020:\n\tSystem.Object::.ctor(this);\n\tv60 = maxLength + 1;\n\tgoto L_002D;\nL_0070:\n\tgoto L_0073;\nL_0052:\n\tgoto L_0055;\n")]
		public SizeSpecificArrayPool(int maxLength)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SizeSpecificArrayPool::.ctor");
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x626DFE0", Offset = "0x626DFE0", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = this._buckets;\n\tv34 = v26.Length - 1;\n\tv44 = v34 >= length;\n\tif (v44) goto L_004A;\n\tgoto L_0038;\nL_0038:\n\t// 56 NewArr returnVal1 @ X0_v23 (T[]), typeof(Il2CppClass<T[]>), length @ X1 (System.Int32)\n\treturn returnVal1;\nL_004A:\n\tv169 = v26[length @ X1 (System.Int32)];\n\tv156 = this._rentals;\n\tv366 = v156[length @ X1 (System.Int32)] < v169.Length;\n\tv55 = v26[length @ X1 (System.Int32)];\n\tif (v366) goto L_00CB;\n\tv367 = v169.Length << 1;\n\tSystem.Array::Resize(&v55 @ stack_-68_v5 (System.Object[]), v367);\n\tv378 = v156[length @ X1 (System.Int32)] >= v367;\n\tif (v378) goto L_00CB;\n\tv157 = v156[length @ X1 (System.Int32)] << 3;\n\tv69 = v157 + 0x20;\n\tv61 = v367 - v156[length @ X1 (System.Int32)];\nL_0094:\n\t// 148 NewArr v85 @ X0_v14 (Il2CppClass<T[]>), typeof(Il2CppClass<T[]>), length @ X1 (System.Int32)\n\tv422 = v85 == 0;\n\tif (v422) goto L_00AB;\n\tv282 = 0x21C11D0(v85, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv297 = v282 == 0;\n\tif (v297) goto L_00F4;\nL_00AB:\n\t*([v55 @ stack_-68_v5 (System.Object[])+v69 @ X26_v7 (System.Int32)]) = v85;\n\tv69 = v69 + 8;\n\tv372 = v61 - 1;\n\tv377 = v61 != 1;\n\tv61 = v372;\n\tif (v377) goto L_0091;\nL_00CB:\n\tv159 = this._rentals;\n\tv343 = v159[length @ X1 (System.Int32)] + 1;\n\tv159[length @ X1 (System.Int32)] = v343;\n\treturn v55[v156[length @ X1 (System.Int32)]];\nL_00F4:\n\tv300 = new System.ArrayTypeMismatchException();\n\tthrow v300;\nL_0091:\n\tgoto L_0094;\n")]
		public T[] Rent(int length)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SizeSpecificArrayPool::Rent");
			return default;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x626E1D8", Offset = "0x626E1D8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._buckets;\n\tv75 = v14.Length - 1;\n\tv28 = v75 < array.Length;\n\tif (v28) goto L_0039;\n\tSystem.Array::Clear(array, 0, array.Length);\n\tv153 = array.Length << 0x20;\n\tv108 = v153 >> 0x1E;\n\tv125 = this._rentals + v108;\n\tv111 = *([v125 @ X8_v8+20]) - 1;\n\t*([v125 @ X8_v8+20]) = v111;\nL_0039:\n\treturn;\n")]
		public void Return(T[] array)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SizeSpecificArrayPool::Return");
		}
	}
}
