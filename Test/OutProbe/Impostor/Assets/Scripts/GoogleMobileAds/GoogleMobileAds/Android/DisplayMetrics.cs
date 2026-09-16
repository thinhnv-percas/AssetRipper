using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x2000016")]
	public class DisplayMetrics
	{
		[CompilerGenerated]
		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x10")]
		private float _003CDensity_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x14")]
		private int _003CHeightPixels_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x18")]
		private int _003CWidthPixels_003Ek__BackingField;

		[Token(Token = "0x17000001")]
		public float Density
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BB")]
			[Address(RVA = "0x1347388", Offset = "0x1347388", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Density>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Density;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000BC")]
			[Address(RVA = "0x1347390", Offset = "0x1347390", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Density>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CDensity_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000002")]
		public int HeightPixels
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0x1347398", Offset = "0x1347398", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<HeightPixels>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HeightPixels;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000BE")]
			[Address(RVA = "0x13473A0", Offset = "0x13473A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<HeightPixels>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CHeightPixels_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000003")]
		public int WidthPixels
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BF")]
			[Address(RVA = "0x13473A8", Offset = "0x13473A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<WidthPixels>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return WidthPixels;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000C0")]
			[Address(RVA = "0x13473B0", Offset = "0x13473B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<WidthPixels>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CWidthPixels_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x13473B8", Offset = "0x13473B8", Length = "0xA98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0053;\n\tv34 = UnityEngine.AndroidJavaClass;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv84 = UnityEngine.AndroidJavaObject;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv106 = System.IDisposable;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv114 = System.Object[];\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv125 = \"density\";\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv136 = \"getWindowManager\";\n\tv137 = \"il2cpp_codegen_initialize_runtime_metadata\"(v136, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv143 = \"getMetrics\";\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv147 = \"com.unity3d.player.UnityPlayer\";\n\tv148 = \"il2cpp_codegen_initialize_runtime_metadata\"(v147, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv227 = \"android.util.DisplayMetrics\";\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv293 = \"heightPixels\";\n\tv294 = \"il2cpp_codegen_initialize_runtime_metadata\"(v293, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv338 = \"getDefaultDisplay\";\n\tv339 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv404 = \"widthPixels\";\n\tv405 = \"il2cpp_codegen_initialize_runtime_metadata\"(v404, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv453 = \"currentActivity\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v453, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A367BC]) = v54;\nL_0053:\n\tSystem.Object::.ctor(this);\n\tv63 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v63, \"com.unity3d.player.UnityPlayer\");\n\tv74 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v74, \"android.util.DisplayMetrics\");\n\tgoto L_0071;\n\tv96 = System.Array::Empty();\nL_0071:\n\tgoto L_0076;\n\tv108 = 0xB348B0(v100, v81, v82, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0076:\n\tgoto L_007E;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v109, v81, v82, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_007E:\n\tgoto L_0085;\n\tv127 = 0xB348B0(v119, v81, v82, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0085:\n\tv134 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v134, \"android.util.DisplayMetrics\", v130.Value);\n\tv145 = v63 == 0;\n\tif (v145) goto L_0251;\n\tv156 = UnityEngine.AndroidJavaObject::GetStatic(v63, \"currentActivity\");\n\tgoto L_00A3;\n\tv296 = UnityEngine.AndroidJavaObject::GetStatic(Il2CppMethodInfo, \"currentActivity\");\nL_00A3:\n\tgoto L_00A8;\n\tv340 = UnityEngine.AndroidJavaObject::GetStatic(v300, v153, v154);\nL_00A8:\n\tgoto L_FFFFFFFF;\n\tv406 = \"il2cpp_codegen_runtime_class_init\"(v341, v153, v154, v141, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00B5;\n\tv454 = UnityEngine.AndroidJavaObject::GetStatic(v409, v153, v154);\nL_00B5:\n\tv514 = *([v328 @ X0_v185+B8]);\n\tv517 = UnityEngine.AndroidJavaObject::Call(v156, \"getWindowManager\", *([v514 @ X8_v102]));\n\tgoto L_00CC;\n\tv618 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getWindowManager\", *([v514 @ X8_v102]));\nL_00CC:\n\tgoto L_00D1;\n\tv660 = UnityEngine.AndroidJavaObject::Call(v622, v441, v439, v430);\nL_00D1:\n\tgoto L_FFFFFFFF;\n\tv695 = \"il2cpp_codegen_runtime_class_init\"(v661, v441, v439, v430, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00DE;\n\tv737 = UnityEngine.AndroidJavaObject::Call(v698, v441, v439, v430);\nL_00DE:\n\tv797 = *([v443 @ X0_v193+B8]);\n\tv800 = UnityEngine.AndroidJavaObject::Call(v517, \"getDefaultDisplay\", *([v797 @ X8_v109]));\n\t// 234 NewArr v547 @ X0_v197 (System.Object[]), typeof(System.Object[]), 1\n\tv838 = v134 == 0;\n\tif (v838) goto L_00F9;\n\t// 243 IsInst v825 @ X0_v206, typeof(System.Object), v134 @ X0_v14 (UnityEngine.AndroidJavaObject)\n\tv827 = v825 == 0;\n\tif (v827) goto L_0262;\nL_00F9:\n\tv547[0] = v134;\n\tUnityEngine.AndroidJavaObject::Call(v800, \"getMetrics\", v547);\n\tv1008 = UnityEngine.AndroidJavaObject::Get(v134, \"density\");\n\tthis.<Density>k__BackingField = v1008;\n\tv1224 = UnityEngine.AndroidJavaObject::Get(v134, \"heightPixels\");\n\tthis.<HeightPixels>k__BackingField = v1224;\n\tv1022 = UnityEngine.AndroidJavaObject::Get(v134, \"widthPixels\");\n\tthis.<WidthPixels>k__BackingField = v1022;\nL_0123:\n\tgoto L_0149;\n\tv1133 = *([v1029 @ X8_v42+B0]);\n\tv1134 = v1133 + 8;\n\tv1136 = *([v1236 @ X10_v47-8]);\n\tv1242 = v1136 == v1030;\n\tif (v1242) goto L_0142;\n\tv1158 = v1237 - 1;\n\tv1156 = v1236 + 0x10;\n\tv1138 = v1237 != 1;\n\tif (v1138) goto L_FFFFFFFF;\n\tv1159 = v1009;\n\tv1160 = 0;\n\tv1161 = 0xB349B4(v1159, v1030, v1160, v1010, v39, v40, v41, v42, v1007, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0149;\nL_0142:\n\tv1388 = *([v1236 @ X10_v47]);\n\tv1389 = v1388 << 4;\n\tv1390 = v1029 + v1389;\n\tv1391 = v1390 + 0x138;\nL_0149:\n\tSystem.IDisposable::Dispose(v800);\nL_014A:\n\tv1132 = 0 == 0;\n\tv785 = ~v1132;\n\tif (v785) goto L_0261;\nL_014E:\n\tv1386 = v517 == 0;\n\tif (v1386) goto L_017B;\n\tgoto L_017A;\n\tv1575 = *([v1488 @ X8_v36+B0]);\n\tv1576 = v1575 + 8;\n\tv1578 = *([v1657 @ X10_v39-8]);\n\tv1663 = v1578 == v1489;\n\tif (v1663) goto L_0173;\n\tv1600 = v1658 - 1;\n\tv1598 = v1657 + 0x10;\n\tv1580 = v1658 != 1;\n\tif (v1580) goto L_FFFFFFFF;\n\tv1601 = v598;\n\tv1602 = 0;\n\tv1603 = 0xB349B4(v1601, v1489, v1602, v590, v39, v40, v41, v42, v586, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_017A;\nL_0173:\n\tv1736 = *([v1657 @ X10_v39]);\n\tv1737 = v1736 << 4;\n\tv1738 = v1488 + v1737;\n\tv1739 = v1738 + 0x138;\nL_017A:\n\tSystem.IDisposable::Dispose(v517);\nL_017B:\n\tv1510 = 0 == 0;\n\tv606 = ~v1510;\n\tif (v606) goto L_025C;\nL_017F:\n\tv1686 = v156 == 0;\n\tif (v1686) goto L_01AC;\n\tgoto L_01AB;\n\tv1815 = *([v1743 @ X8_v30+B0]);\n\tv1816 = v1815 + 8;\n\tv1818 = *([v1899 @ X10_v31-8]);\n\tv1905 = v1818 == v1744;\n\tif (v1905) goto L_01A4;\n\tv1840 = v1900 - 1;\n\tv1838 = v1899 + 0x10;\n\tv1820 = v1900 != 1;\n\tif (v1820) goto L_FFFFFFFF;\n\tv1841 = v488;\n\tv1842 = 0;\n\tv1843 = 0xB349B4(v1841, v1744, v1842, v486, v39, v40, v41, v42, v482, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01AB;\nL_01A4:\n\tv1964 = *([v1899 @ X10_v31]);\n\tv1965 = v1964 << 4;\n\tv1966 = v1743 + v1965;\n\tv1967 = v1966 + 0x138;\nL_01AB:\n\tSystem.IDisposable::Dispose(v156);\nL_01AC:\n\tv1765 = 0 == 0;\n\tv502 = ~v1765;\n\tif (v502) goto L_0259;\nL_01B0:\n\tv1928 = v134 == 0;\n\tif (v1928) goto L_01DD;\n\tgoto L_01DC;\n\tv2065 = *([v1971 @ X8_v24+B0]);\n\tv2066 = v2065 + 8;\n\tv2068 = *([v2178 @ X10_v23-8]);\n\tv2184 = v2068 == v1972;\n\tif (v2184) goto L_01D5;\n\tv2090 = v2179 - 1;\n\tv2088 = v2178 + 0x10;\n\tv2070 = v2179 != 1;\n\tif (v2070) goto L_FFFFFFFF;\n\tv20\n// ... truncated")]
		public DisplayMetrics()
		{
			//IL_00a3: Expected O, but got I
			//IL_00b8: Expected O, but got I
			//IL_00f7: Expected O, but got I
			//IL_010c: Expected O, but got I
			base._002Ector();
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("android.util.DisplayMetrics");
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.util.DisplayMetrics");
			if (androidJavaClass != null)
			{
				object obj = androidJavaClass.GetStatic<object>("currentActivity");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X0_v185+B8]");
				object obj3 = ((AndroidJavaObject)obj).Call<object>("getWindowManager", (object[])0);
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ X0_v193+B8]");
				object obj5 = ((AndroidJavaObject)obj3).Call<object>("getDefaultDisplay", (object[])0);
				object[] array = new object[1];
				if (androidJavaObject == null || androidJavaObject is object)
				{
					array[0] = androidJavaObject;
					((AndroidJavaObject)obj5).Call("getMetrics", array);
					Density = androidJavaObject.Get<float>("density");
					HeightPixels = androidJavaObject.Get<int>("heightPixels");
					WidthPixels = androidJavaObject.Get<int>("widthPixels");
					((IDisposable)obj5).Dispose();
					if (0 == 0)
					{
						((IDisposable)obj3)?.Dispose();
						if (false)
						{
							OutOfMemoryException ex = new OutOfMemoryException();
							IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
							NullReferenceException ex3 = new NullReferenceException();
							throw new NullReferenceException();
						}
						((IDisposable)obj)?.Dispose();
						if (false)
						{
							OutOfMemoryException ex4 = new OutOfMemoryException();
							throw new NullReferenceException();
						}
						((IDisposable)androidJavaObject)?.Dispose();
						if (false)
						{
							OutOfMemoryException ex5 = new OutOfMemoryException();
							throw new NullReferenceException();
						}
						((IDisposable)androidJavaClass2)?.Dispose();
						if (false)
						{
							OutOfMemoryException ex6 = new OutOfMemoryException();
							throw new NullReferenceException();
						}
						((IDisposable)androidJavaClass)?.Dispose();
						if (0 == 0)
						{
							return;
						}
						OutOfMemoryException ex7 = new OutOfMemoryException();
						goto IL_0230;
					}
					OutOfMemoryException ex8 = new OutOfMemoryException();
				}
				throw new ArrayTypeMismatchException();
			}
			goto IL_0230;
			IL_0230:
			throw androidJavaObject;
		}
	}
}
