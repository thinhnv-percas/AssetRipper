using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ProGrids
{
	[Token(Token = "0x200004E")]
	public static class pg_Util
	{
		[Token(Token = "0x200046A")]
		private abstract class SnapEnabledOverride
		{
			[Token(Token = "0x6001577")]
			public abstract bool IsEnabled();

			[Token(Token = "0x6001578")]
			[Address(RVA = "0xB02638", Offset = "0xB02638", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected internal SnapEnabledOverride()
			{
			}
		}

		[Token(Token = "0x200046B")]
		private class SnapIsEnabledOverride : SnapEnabledOverride
		{
			[Token(Token = "0x40020D2")]
			[FieldOffset(Offset = "0x10")]
			internal bool m_SnapIsEnabled;

			[Token(Token = "0x6001579")]
			[Address(RVA = "0xB021CC", Offset = "0xB021CC", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_SnapIsEnabled = snapIsEnabled;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SnapIsEnabledOverride(bool snapIsEnabled)
			{
				m_SnapIsEnabled = snapIsEnabled;
			}

			[Token(Token = "0x600157A")]
			[Address(RVA = "0xB02698", Offset = "0xB02698", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_SnapIsEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override bool IsEnabled()
			{
				return m_SnapIsEnabled;
			}
		}

		[Token(Token = "0x200046C")]
		private class ConditionalSnapOverride : SnapEnabledOverride
		{
			[Token(Token = "0x40020D3")]
			[FieldOffset(Offset = "0x10")]
			public Func<bool> m_IsEnabledDelegate;

			[Token(Token = "0x600157B")]
			[Address(RVA = "0xB021FC", Offset = "0xB021FC", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_IsEnabledDelegate = d;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ConditionalSnapOverride(Func<bool> d)
			{
				m_IsEnabledDelegate = d;
			}

			[Token(Token = "0x600157C")]
			[Address(RVA = "0xB02640", Offset = "0xB02640", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EE30C8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224C4]) = v38;\nL_001E:\n\treturnVal1 = System.Func`1<System.Boolean>::Invoke(this.m_IsEnabledDelegate);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override bool IsEnabled()
			{
				return m_IsEnabledDelegate();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200046E")]
		private sealed class _003C_003Ec__DisplayClass7_0
		{
			[Token(Token = "0x40020D5")]
			[FieldOffset(Offset = "0x10")]
			public string assembly;

			[Token(Token = "0x600157F")]
			[Address(RVA = "0xB00FD0", Offset = "0xB00FD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass7_0()
			{
			}

			internal bool _003CGetType_003Eb__0(Assembly x)
			{
				string fullName = x.FullName;
				return fullName.Contains(assembly);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200046F")]
		private sealed class _003C_003Ec__DisplayClass26_0
		{
			[Token(Token = "0x40020D6")]
			[FieldOffset(Offset = "0x10")]
			public Component c;

			[Token(Token = "0x6001581")]
			[Address(RVA = "0xB021BC", Offset = "0xB021BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass26_0()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000470")]
		private sealed class _003C_003Ec__DisplayClass26_1
		{
			[Token(Token = "0x40020D7")]
			[FieldOffset(Offset = "0x10")]
			public MethodInfo mi;

			[Token(Token = "0x40020D8")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals1;

			[Token(Token = "0x6001582")]
			[Address(RVA = "0xB021C4", Offset = "0xB021C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass26_1()
			{
			}

			internal bool _003CSnapIsEnabled_003Eb__1()
			{
				//IL_0030: Expected I4, but got O
				//IL_006b: Expected I4, but got O
				//IL_005d: Expected I4, but got O
				_003C_003Ec__DisplayClass26_0 _003C_003Ec__DisplayClass26_2 = CS_0024_003C_003E8__locals1;
				object obj = mi.Invoke(_003C_003Ec__DisplayClass26_2.c, null);
				if ((int)((obj is bool) ? obj : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					return (byte)(int)obj2 != 0;
				}
				InvalidCastException ex = new InvalidCastException();
				return (byte)(int)ex != 0;
			}

			internal bool _003CSnapIsEnabled_003Eb__3()
			{
				//IL_0030: Expected I4, but got O
				//IL_006b: Expected I4, but got O
				//IL_005d: Expected I4, but got O
				_003C_003Ec__DisplayClass26_0 _003C_003Ec__DisplayClass26_2 = CS_0024_003C_003E8__locals1;
				object obj = mi.Invoke(_003C_003Ec__DisplayClass26_2.c, null);
				if ((int)((obj is bool) ? obj : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					return (byte)(int)obj2 != 0;
				}
				InvalidCastException ex = new InvalidCastException();
				return (byte)(int)ex != 0;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000471")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40020D9")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40020DA")]
			public static Func<object, bool> _003C_003E9__26_0;

			[Token(Token = "0x40020DB")]
			public static Func<object, bool> _003C_003E9__26_2;

			[Token(Token = "0x6001585")]
			[Address(RVA = "0xB022FC", Offset = "0xB022FC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED8348]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20224BE]) = v37;\nL_0015:\n\tv41 = new ProGrids.pg_Util+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001586")]
			[Address(RVA = "0xB02360", Offset = "0xB02360", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CSnapIsEnabled_003Eb__26_0(object x)
			{
				if (x != null)
				{
					string text = x.ToString();
					return text.Contains("ProGridsNoSnap");
				}
				return false;
			}

			internal bool _003CSnapIsEnabled_003Eb__26_2(object x)
			{
				if (x != null)
				{
					string text = x.ToString();
					return text.Contains("ProGridsConditionalSnap");
				}
				return false;
			}
		}

		[Token(Token = "0x400023C")]
		private const float EPSILON = 0.0001f;

		[Token(Token = "0x400023D")]
		private static Dictionary<Transform, SnapEnabledOverride> m_SnapOverrideCache;

		[Token(Token = "0x400023E")]
		private static Dictionary<Type, bool> m_NoSnapAttributeTypeCache;

		[Token(Token = "0x400023F")]
		private static Dictionary<Type, MethodInfo> m_ConditionalSnapAttributeCache;

		[Token(Token = "0x6000227")]
		[Address(RVA = "0xAFFFE0", Offset = "0xAFFFE0", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EEB3E0]);\n\tv27 = *([v26 @ X8_v30]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20224AA]) = v46;\nL_001A:\n\tv50 = new ProGrids.pg_Util+<>c__DisplayClass0_0();\n\tSystem.Object::.ctor(v50);\n\tv50.valid = \"01234567890.,\";\n\tv60 = new System.Func`2<System.Char, System.Boolean>();\n\tSystem.Func`2<System.Char, System.Boolean>::.ctor(v60, v50, Il2CppMethodInfo);\n\tv163 = System.Linq.Enumerable::Where(value, v60);\n\tv167 = System.Linq.Enumerable::ToArray(v163);\n\tv228 = System.String::CreateString(0, v167);\n\t// 69 NewArr v112 @ X0_v16 (System.Char[]), typeof(System.Char[]), 1\n\tv234 = v112.Length == 0;\n\tif (v234) goto L_00BA;\n\tv112[0] = 0x2C;\n\tv150 = System.String::Split(v228, v112);\n\tv294 = v150.Length <= 3;\n\tif (v294) goto L_FFFFFFFF;\n\tv238 = System.Single::Parse(v150[0]);\n\tv303 = v150.Length < 1;\n\tv265 = ~v303;\n\tv262 = v150.Length - 1;\n\tv256 = v262 == 0;\n\tv304 = ~v265;\n\tv241 = v304 | v256;\n\tif (v241) goto L_00BA;\n\tv239 = System.Single::Parse(v150[1]);\n\tv324 = v150.Length < 2;\n\tv266 = ~v324;\n\tv263 = v150.Length - 2;\n\tv257 = v263 == 0;\n\tv325 = ~v266;\n\tv242 = v325 | v257;\n\tif (v242) goto L_00BA;\n\tv240 = System.Single::Parse(v150[2]);\n\tv326 = v150.Length < 3;\n\tv267 = ~v326;\n\tv264 = v150.Length - 3;\n\tv258 = v264 == 0;\n\tv327 = ~v267;\n\tv243 = v327 | v258;\n\tif (v243) goto L_00BA;\n\tv329 = System.Single::Parse(v150[3]);\n\tv299 = 0;\n\tgoto L_00AB;\nL_00AB:\n\tv216 = System.Func`2<System.Char, System.Boolean>::.ctor(v320, 0, 0);\n\treturn v299;\nL_00BA:\n\tv280 = new System.IndexOutOfRangeException();\n\tthrow v280;\n\tthrow System.NullReferenceException;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Color ColorWithString(string value)
		{
			//IL_0122: Expected O, but got I4
			//IL_019a: Expected O, but got I4
			//IL_0212: Expected O, but got I4
			string valid = "01234567890.,";
			Func<char, bool> predicate = (char c) => valid.Contains(c);
			IEnumerable<char> source = value.Where(predicate);
			char[] val = source.ToArray();
			string text = ((string)null).CreateString(val);
			char[] array = new char[1];
			Color color = default(Color);
			if (array.Length != 0)
			{
				array[0] = ',';
				string[] array2 = text.Split(array);
				if (array2.Length <= 3)
				{
					Func<char, bool> func = (Func<char, bool>)color;
					goto IL_02a9;
				}
				float num = float.Parse(array2[0]);
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj = array2.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					float num2 = float.Parse(array2[1]);
					bool flag5 = array2.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array2.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						float num3 = float.Parse(array2[2]);
						bool flag9 = array2.Length < 3;
						bool flag10 = !flag9;
						object obj3 = array2.Length - 3;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							float num4 = float.Parse(array2[3]);
							color = default(Color);
							color = default(Color);
							Func<char, bool> func = (Func<char, bool>)color;
							goto IL_02a9;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_02a9:
			return color;
		}

		[Token(Token = "0x6000228")]
		[Address(RVA = "0xB001FC", Offset = "0xB001FC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EF2910]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, vec, v0, v2, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([20224AB]) = v48;\nL_001D:\n\tv51 = UnityEngine.Mathf;\n\tgoto L_002A;\n\tv55 = *([v51 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002A;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v51, v33, v34, v35, v36, v37, v38, v39, vec, v0, v2, v40, v41, v42, v43, v44);\n\tv61 = UnityEngine.Mathf;\n\tv64 = *([v61 @ X0_v12+12E]);\nL_002A:\n\tv66 = UnityEngine.Mathf::Abs(vec);\n\tv73 = v66 - v65.Epsilon;\n\tv74 = v73 < 0;\n\tv75 = v73 == 0;\n\tv76 = v66 ^ v65.Epsilon;\n\tv77 = v66 ^ v73;\n\tv78 = v76 & v77;\n\tv79 = v78 < 0;\n\tv80 = v74 == v79;\n\tv81 = ~v75;\n\tv82 = v80 & v81;\n\tv83 = ~v82;\n\tif (v83) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_0040:\n\tv87 = *([v51 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]) & 0x200;\n\tv88 = v87 == 0;\n\tif (v88) goto L_004C;\n\tgoto L_004C;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v60, v33, v34, v35, v36, v37, v38, v39, v70, v66, v2, v40, v41, v42, v43, v44);\n\tv96 = UnityEngine.Mathf;\n\tv115 = *([v96 @ X0_v10+B8]);\n\tv93 = *([v115 @ X8_v10]);\n\tv99 = *([v96 @ X0_v10+12E]);\nL_004C:\n\tv100 = UnityEngine.Mathf::Abs(vec.y);\n\tv104 = v100 - v65.Epsilon;\n\tv105 = v104 < 0;\n\tv106 = v104 == 0;\n\tv107 = v100 ^ v65.Epsilon;\n\tv108 = v100 ^ v104;\n\tv109 = v107 & v108;\n\tv110 = v109 < 0;\n\tv111 = v105 == v110;\n\tv112 = ~v106;\n\tv113 = v111 & v112;\n\tv114 = ~v113;\n\tif (v114) goto L_FFFFFFFF;\n\tgoto L_005F;\nL_005F:\n\tv119 = *([v51 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]) & 0x200;\n\tv120 = v119 == 0;\n\tif (v120) goto L_006A;\n\tgoto L_006A;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v95, v33, v34, v35, v36, v37, v38, v39, v92, v100, v2, v40, v41, v42, v43, v44);\n\tv146 = UnityEngine.Mathf;\n\tv130 = *([v146 @ X8_v8+B8]);\n\tv125 = *([v130 @ X8_v9]);\nL_006A:\n\tv131 = UnityEngine.Mathf::Abs(vec.z);\n\tv135 = v131 - v65.Epsilon;\n\tv136 = v135 < 0;\n\tv137 = v135 == 0;\n\tv138 = v131 ^ v65.Epsilon;\n\tv139 = v131 ^ v135;\n\tv140 = v138 & v139;\n\tv141 = v140 < 0;\n\tv142 = v136 == v141;\n\tv143 = ~v137;\n\tv144 = v142 & v143;\n\tv145 = ~v144;\n\tif (v145) goto L_FFFFFFFF;\n\tgoto L_0083;\nL_0083:\n\tv151 = 0;\n\tv156 = 0x1586898(&v151 @ stack_-50_v1 (UnityEngine.Vector3), 0, v34, v35, v36, v37, v38, v39, v86, v118, v149, v40, v41, v42, v43, v44);\n\treturn 0;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Vector3 VectorToMask(Vector3 vec)
		{
			//IL_0071: Expected I, but got O
			//IL_00c8: Expected O, but got F4
			//IL_00d5: Expected O, but got F4
			//IL_01b7: Expected O, but got F4
			//IL_01c4: Expected O, but got F4
			//IL_02a6: Expected O, but got F4
			//IL_02b3: Expected O, but got F4
			IntPtr intPtr = (IntPtr)typeof(Mathf);
			Vector3 vector = default(Vector3);
			float num = Mathf.Abs(vector.x);
			float num2 = num - Mathf.Epsilon;
			bool flag = num2 < 0f;
			bool flag2 = num2 == 0f;
			object obj = num ^ Mathf.Epsilon;
			object obj2 = num ^ num2;
			int num3 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag3 = num3 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (flag4 && flag5)
			{
				float num4 = 1f;
			}
			else
			{
				float num4 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]");
			if (0u != 0)
			{
			}
			float num5 = Mathf.Abs(vec.y);
			float num6 = num5 - Mathf.Epsilon;
			bool flag6 = num6 < 0f;
			bool flag7 = num6 == 0f;
			object obj3 = num5 ^ Mathf.Epsilon;
			object obj4 = num5 ^ num6;
			int num7 = (int)((long)(IntPtr)obj3 & (long)(IntPtr)obj4);
			bool flag8 = num7 < 0;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			if (flag9 && flag10)
			{
				float num8 = 1f;
			}
			else
			{
				float num8 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]");
			if (0u != 0)
			{
			}
			float num9 = Mathf.Abs(vec.z);
			float num10 = num9 - Mathf.Epsilon;
			bool flag11 = num10 < 0f;
			bool flag12 = num10 == 0f;
			object obj5 = num9 ^ Mathf.Epsilon;
			object obj6 = num9 ^ num10;
			int num11 = (int)((long)(IntPtr)obj5 & (long)(IntPtr)obj6);
			bool flag13 = num11 < 0;
			bool flag14 = flag11 == flag13;
			bool flag15 = !flag12;
			if (flag14 && flag15)
			{
				float num12 = 1f;
			}
			else
			{
				float num12 = 0f;
			}
			Vector3 vector2 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x6000229")]
		[Address(RVA = "0xB00324", Offset = "0xB00324", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1ED0258]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, v31, v32, v33, v34, v35, v36, v37, vec, v0, v2, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([20224AC]) = v46;\nL_001C:\n\tv49 = UnityEngine.Mathf;\n\tgoto L_002B;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002B;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v49, v31, v32, v33, v34, v35, v36, v37, vec, v0, v2, v38, v39, v40, v41, v42);\n\tv59 = UnityEngine.Mathf;\n\tv62 = *([v59 @ X0_v13+12E]);\nL_002B:\n\tv66 = vec < 0;\n\tv67 = vec == 0;\n\tv69 = vec ^ vec;\n\tv70 = vec & v69;\n\tv71 = v70 < 0;\n\tv73 = v66 == v71;\n\tv74 = ~v73;\n\tv75 = v74 | v67;\n\tv76 = ~v75;\n\tif (v76) goto L_FFFFFFFF;\n\tgoto L_003B;\nL_003B:\n\tv81 = *([v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]) & 0x200;\n\tv82 = v81 == 0;\n\tif (v82) goto L_0045;\n\tgoto L_0045;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v58, v31, v32, v33, v34, v35, v36, v37, vec, v0, v2, v38, v39, v40, v41, v42);\n\tv88 = UnityEngine.Mathf;\n\tv91 = *([v88 @ X0_v11+12E]);\nL_0045:\n\tv92 = v80 | 2;\n\tv99 = vec.y ^ vec.y;\n\tv100 = vec.y & v99;\n\tv101 = v100 < 0;\n\tv102 = vec.y != 0;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\tv107 = ~v101;\n\tif (v107) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\tv111 = *([v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]) & 0x200;\n\tv112 = v111 == 0;\n\tif (v112) goto L_0063;\n\tgoto L_0063;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v87, v31, v32, v33, v34, v35, v36, v37, vec, v0, v2, v38, v39, v40, v41, v42);\nL_0063:\n\tv120 = v110 | 4;\n\tv124 = vec.z < 0;\n\tv125 = vec.z == 0;\n\tv127 = vec.z ^ vec.z;\n\tv128 = vec.z & v127;\n\tv129 = v128 < 0;\n\tv130 = vec.z >= 0;\n\tif (v130) goto L_FFFFFFFF;\n\tgoto L_0079;\nL_0079:\n\tv140 = v124 == v129;\n\tv141 = ~v125;\n\tv142 = v140 & v141;\n\tv143 = ~v142;\n\tif (v143) goto L_FFFFFFFF;\n\tgoto L_0084;\nL_0084:\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Axis MaskToAxis(Vector3 vec)
		{
			//IL_013a: Expected I, but got O
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected I4, but got Unknown
			//IL_022c: Expected O, but got F4
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Expected I4, but got Unknown
			//IL_00af: Expected O, but got F4
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected I4, but got Unknown
			IntPtr intPtr = (IntPtr)typeof(Mathf);
			Vector3 vector = default(Vector3);
			bool flag = vector.x < 0f;
			bool flag2 = vector.x == 0f;
			object obj = (object)vec ^ (object)vec;
			int num = (int)(vec & (long)(IntPtr)obj);
			bool flag3 = num < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag4;
			bool flag6 = !(flag5 || flag2) || flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]");
			if (0u != 0)
			{
			}
			int num2 = (flag6 ? 1 : 0) | 2;
			object obj2 = vec.y ^ vec.y;
			int num3 = vec.y & (long)(IntPtr)obj2;
			bool flag7 = num3 < 0;
			bool flag8 = ((vec.y != 0f) ? ((byte)num2 != 0) : flag6);
			bool flag9 = ((!flag7) ? flag8 : flag6);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+12E]");
			if (0u != 0)
			{
			}
			int num4 = (flag9 ? 1 : 0) | 4;
			bool flag10 = vec.z < 0f;
			bool flag11 = vec.z == 0f;
			object obj3 = vec.z ^ vec.z;
			int num5 = vec.z & (long)(IntPtr)obj3;
			bool flag12 = num5 < 0;
			Axis result = ((!(vec.z < 0f)) ? (flag9 ? Axis.X : Axis.None) : ((Axis)num4));
			bool flag13 = flag10 == flag12;
			bool flag14 = !flag11;
			if (flag13 && flag14)
			{
				return (Axis)num4;
			}
			return result;
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0xB003F8", Offset = "0xB003F8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EC0830]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, vec, v0, v2, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20224AD]) = v44;\nL_001F:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, v29, v30, v31, v32, v33, v34, v35, vec, v0, v2, v36, v37, v38, v39, v40);\nL_0025:\n\tv58 = UnityEngine.Mathf::Abs(vec);\n\tv59 = UnityEngine.Mathf::Abs(vec.y);\n\tv69 = UnityEngine.Mathf::Abs(vec.z);\n\tv72 = v58 <= v59;\n\tif (v72) goto L_0050;\n\tv84 = v58 <= v69;\n\tif (v84) goto L_0050;\n\tgoto L_006C;\nL_0050:\n\tv106 = v59 <= v58;\n\tif (v106) goto L_006C;\n\tv110 = v59 - v69;\n\tv111 = v110 < 0;\n\tv112 = v110 == 0;\n\tv113 = v59 ^ v69;\n\tv114 = v59 ^ v110;\n\tv115 = v113 & v114;\n\tv116 = v115 < 0;\n\tv118 = v111 == v116;\n\tv119 = ~v112;\n\tv120 = v118 & v119;\n\tv121 = ~v120;\n\tif (v121) goto L_FFFFFFFF;\n\tgoto L_006C;\nL_006C:\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Axis BestAxis(Vector3 vec)
		{
			//IL_00f8: Expected O, but got F4
			//IL_0105: Expected O, but got F4
			Vector3 vector = default(Vector3);
			float num = Mathf.Abs(vector.x);
			float num2 = Mathf.Abs(vec.y);
			float num3 = Mathf.Abs(vec.z);
			Axis result;
			if (num > num2 && num > num3)
			{
				result = Axis.X;
			}
			else
			{
				bool flag = !(num2 > num);
				result = Axis.Z;
				if (!flag)
				{
					float num4 = num2 - num3;
					bool flag2 = num4 < 0f;
					bool flag3 = num4 == 0f;
					object obj = num2 ^ num3;
					object obj2 = num2 ^ num4;
					int num5 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
					bool flag4 = num5 < 0;
					bool flag5 = flag2 == flag4;
					bool flag6 = !flag3;
					result = ((!(flag5 && flag6)) ? Axis.Z : Axis.Y);
				}
			}
			return result;
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0xB004AC", Offset = "0xB004AC", Length = "0x460")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv32 = *([1EAF5C0]);\n\tv33 = *([v32 @ X8_v55]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, movement, v0, v2, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20224AE]) = v49;\nL_0022:\n\tgoto L_002C;\n\tv56 = *([v52 @ X0_v2 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_002C;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v36, v37, v38, v39, v40, v41, movement, v0, v2, v42, v43, v44, v45, v46);\nL_002C:\n\tv67 = ProGrids.pg_Util::VectorToMask(movement);\n\tv73 = v67 + v67.y;\n\tv74 = v67.z + v73;\n\tv85 = v74 != 2f;\n\tif (v85) goto L_0079;\n\tgoto L_004D;\n\tv96 = *([v88 @ X0_v62+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_004D;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v88, methodInfo, v36, v37, v38, v39, v40, v41, v74, v75, v69, v42, v43, v44, v45, v46);\nL_004D:\n\tv104 = UnityEngine.Vector3::get_one();\n\tv125 = UnityEngine.Vector3::op_Subtraction(v104, v67);\n\tgoto L_0073;\n\tv154 = *([v137 @ X0_v66 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0073;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v137, methodInfo, v36, v37, v38, v39, v40, v41, v125, v135, v136, v119, v120, v121, v45, v46);\nL_0073:\n\treturnVal1 = ProGrids.pg_Util::MaskToAxis(v125);\n\treturn returnVal1;\nL_0079:\n\tgoto L_0083;\n\tv105 = *([v92 @ X0_v4 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0083;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v92, methodInfo, v36, v37, v38, v39, v40, v41, v74, v75, v69, v42, v43, v44, v45, v46);\nL_0083:\n\tv116 = ProGrids.pg_Util::MaskToAxis(v67);\n\tv130 = v116 == 4;\n\tif (v130) goto L_010B;\n\tv148 = v116 == 2;\n\tif (v148) goto L_0167;\n\tv183 = v116 != 1;\n\tif (v183) goto L_FFFFFFFF;\n\tv254 = UnityEngine.Component::get_transform(cam);\n\tv463 = UnityEngine.Transform::get_forward(v254);\n\tgoto L_00BE;\n\tv504 = *([v487 @ X0_v46+E0]);\n\tv505 = v504 == 0;\n\tv506 = ~v505;\n\tif (v506) goto L_00BE;\n\tv508 = \"il2cpp_codegen_runtime_class_init\"(v487, v462, v36, v37, v38, v39, v40, v41, v463, v482, v483, v42, v43, v44, v45, v46);\nL_00BE:\n\tv512 = UnityEngine.Vector3::get_up();\n\tv250 = UnityEngine.Vector3::Dot(v463, v512);\n\tgoto L_00DA;\n\tv553 = *([v542 @ X0_v50+E0]);\n\tv554 = v553 == 0;\n\tv555 = ~v554;\n\tif (v555) goto L_00DA;\n\tv557 = \"il2cpp_codegen_runtime_class_init\"(v542, v462, v36, v37, v38, v39, v40, v41, v250, v285, v281, v237, v233, v229, v45, v46);\nL_00DA:\n\tv255 = UnityEngine.Component::get_transform(cam);\n\tv404 = UnityEngine.Mathf::Abs(v250);\n\tv573 = UnityEngine.Transform::get_forward(v255);\n\tv596 = UnityEngine.Vector3::get_forward();\n\tv614 = UnityEngine.Vector3::Dot(v573, v596);\n\tv429 = UnityEngine.Mathf::Abs(v614);\n\tv425 = v404 - v429;\n\tv423 = v425 < 0;\n\tv412 = ~v423;\n\tv396 = ~v412;\n\tif (v396) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_01CF;\nL_010B:\n\tv187 = UnityEngine.Component::get_transform(cam);\n\tv450 = UnityEngine.Transform::get_forward(v187);\n\tgoto L_0122;\n\tv473 = *([v458 @ X0_v17+E0]);\n\tv474 = v473 == 0;\n\tv475 = ~v474;\n\tif (v475) goto L_0122;\n\tv477 = \"il2cpp_codegen_runtime_class_init\"(v458, v449, v36, v37, v38, v39, v40, v41, v450, v453, v454, v42, v43, v44, v45, v46);\nL_0122:\n\tv481 = UnityEngine.Vector3::get_right();\n\tv251 = UnityEngine.Vector3::Dot(v450, v481);\n\tgoto L_013E;\n\tv533 = *([v519 @ X0_v21+E0]);\n\tv534 = v533 == 0;\n\tv535 = ~v534;\n\tif (v535) goto L_013E;\n\tv537 = \"il2cpp_codegen_runtime_class_init\"(v519, v449, v36, v37, v38, v39, v40, v41, v251, v286, v282, v238, v234, v230, v45, v46);\nL_013E:\n\tv256 = UnityEngine.Component::get_transform(cam);\n\tv561 = UnityEngine.Mathf::Abs(v251);\n\tv564 = UnityEngine.Transform::get_forward(v256);\n\tv572 = UnityEngine.Vector3::get_up();\n\tv592 = UnityEngine.Vector3::Dot(v564, v572);\n\tv609 = UnityEngine.Mathf::Abs(v592);\n\tv618 = v561 - v609;\n\tv424 = v618 < 0;\n\tgoto L_01BE;\nL_0167:\n\tv203 = UnityEngine.Component::get_transform(cam);\n\tv452 = UnityEngine.Transform::get_forward(v203);\n\tgoto L_017E;\n\tv491 = *([v469 @ X0_v31+E0]);\n\tv492 = v491 == 0;\n\tv493 = ~v492;\n\tif (v493) goto L_017E;\n\tv495 = \"il2cpp_codegen_runtime_class_init\"(v469, v451, v36, v37, v38, v39, v40, v41, v452, v464, v465, v42, v43, v44, v45, v46);\nL_017E:\n\tv499 = UnityEngine.Vector3::get_right();\n\tv252 = UnityEngine.Vector3::Dot(v452, v499);\n\tgoto L_019A;\n\tv546 = *([v529 @ X0_v35+E0]);\n\tv547 = v546 == 0;\n\tv548 = ~v547;\n\tif (v548) goto L_019A;\n\tv550 = \"il2cpp_codegen_runtime_class_init\"(v529, v451, v36, v37, v38, v39, v40, v41, v252, v287, v283, v239, v235, v231, v45, v46);\nL_019A:\n\tv257 = UnityEngine.Component::get_transform(cam);\n\tv563 = UnityEngine.Mathf::Abs(v252);\n\tv565 = UnityEngine.Transform::get_forward(v257);\n\tv580 = UnityEngine.Vector3::get_forward();\n\tv608 = UnityEngine.Vector3::Dot(v565, v580);\n\tv615 = UnityEngine.Mathf::Abs(v608);\n\tv628 = v563 - v615;\n\tv424 = v628 < 0;\nL_01BE:\n\tv397 = ~v424;\n\tif (v397) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_01CF;\nL_01CF:\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 336 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Axis CalcDragAxis(Vector3 movement, Camera cam)
		{
			Vector3 vector = VectorToMask(movement);
			float num = vector.x + vector.y;
			float num2 = vector.z + num;
			if (num2 == 2f)
			{
				Vector3 one = Vector3.one;
				Vector3 vec = one - vector;
				return MaskToAxis(vec);
			}
			bool flag;
			int num6;
			switch (MaskToAxis(vector))
			{
			case Axis.X:
			{
				Transform transform5 = cam.transform;
				Vector3 forward6 = transform5.forward;
				Vector3 up2 = Vector3.up;
				float f5 = Vector3.Dot(forward6, up2);
				Transform transform6 = cam.transform;
				float num10 = Mathf.Abs(f5);
				Vector3 forward7 = transform6.forward;
				Vector3 forward8 = Vector3.forward;
				float f6 = Vector3.Dot(forward7, forward8);
				float num11 = Mathf.Abs(f6);
				float num12 = num10 - num11;
				return (num12 < 0f) ? Axis.Z : Axis.Y;
			}
			case Axis.Z:
			{
				Transform transform3 = cam.transform;
				Vector3 forward4 = transform3.forward;
				Vector3 right2 = Vector3.right;
				float f3 = Vector3.Dot(forward4, right2);
				Transform transform4 = cam.transform;
				float num7 = Mathf.Abs(f3);
				Vector3 forward5 = transform4.forward;
				Vector3 up = Vector3.up;
				float f4 = Vector3.Dot(forward5, up);
				float num8 = Mathf.Abs(f4);
				float num9 = num7 - num8;
				flag = num9 < 0f;
				num6 = 2;
				break;
			}
			case Axis.Y:
			{
				Transform transform = cam.transform;
				Vector3 forward = transform.forward;
				Vector3 right = Vector3.right;
				float f = Vector3.Dot(forward, right);
				Transform transform2 = cam.transform;
				float num3 = Mathf.Abs(f);
				Vector3 forward2 = transform2.forward;
				Vector3 forward3 = Vector3.forward;
				float f2 = Vector3.Dot(forward2, forward3);
				float num4 = Mathf.Abs(f2);
				float num5 = num3 - num4;
				flag = num5 < 0f;
				num6 = 4;
				break;
			}
			default:
				return default(Axis);
			}
			return (!flag) ? Axis.X : ((Axis)num6);
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0xB0090C", Offset = "0xB0090C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv37 = *([1EB8200]);\n\tv38 = *([v37 @ X8_v12]);\n\tv39 = \"il2cpp_codegen_initialize_method\"(v38, v40, v41, v42, v43, v44, v45, v46, val, v0, v2, mask, v3, v5, v47, v48);\n\tv52 = 0 | 1;\n\t*([20224AF]) = v52;\nL_0026:\n\tgoto L_002E;\n\tv59 = *([v55 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002E;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, v40, v41, v42, v43, v44, v45, v46, val, v0, v2, mask, v3, v5, v47, v48);\nL_002E:\n\tv68 = UnityEngine.Mathf::Abs(mask);\n\tv80 = v68 <= 0.0001f;\n\tif (v80) goto L_0042;\n\tgoto L_0065;\nL_0042:\n\tgoto L_0048;\n\tv128 = *([v82 @ X0_v5+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0048;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v82, v40, v41, v42, v43, v44, v45, v46, v68, v0, v2, mask, v3, v5, v47, v48);\nL_0048:\n\tv132 = UnityEngine.Mathf::Abs(mask.y);\n\tv107 = v132 - 0.0001f;\n\tv105 = v107 < 0;\n\tv103 = v107 == 0;\n\tv101 = v132 ^ 0.0001f;\n\tv99 = v132 ^ v107;\n\tv97 = v101 & v99;\n\tv95 = v97 < 0;\n\tv134 = v105 == v95;\n\tv91 = ~v103;\n\tv93 = v134 & v91;\n\tv88 = ~v93;\n\tif (v88) goto L_FFFFFFFF;\n\tgoto L_0065;\nL_0065:\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ValueFromMask(Vector3 val, Vector3 mask)
		{
			//IL_00a2: Expected O, but got F4
			//IL_00af: Expected O, but got F4
			Vector3 vector = default(Vector3);
			float num = Mathf.Abs(vector.x);
			Vector3 vector2 = default(Vector3);
			if (num > 0.0001f)
			{
				return vector2.x;
			}
			float num2 = Mathf.Abs(mask.y);
			float num3 = num2 - 0.0001f;
			bool flag = num3 < 0f;
			bool flag2 = num3 == 0f;
			object obj = num2 ^ 0.0001f;
			object obj2 = num2 ^ num3;
			int num4 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (flag4 && flag5)
			{
				return val.y;
			}
			return val.z;
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0xB009D4", Offset = "0xB009D4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = *([1EEAF50]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, val, v0, v2, snapValue, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20224B0]) = v47;\nL_0021:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, val, v0, v2, snapValue, v40, v41, v42, v43);\nL_0029:\n\tv63 = ProGrids.pg_Util::Snap(val, snapValue);\n\tv67 = ProGrids.pg_Util::Snap(val.y, snapValue);\n\tv71 = ProGrids.pg_Util::Snap(val.z, snapValue);\n\tv74 = 0;\n\tv79 = 0x1586898(&v74 @ stack_-50_v1 (UnityEngine.Vector3), 0, v34, v35, v36, v37, v38, v39, v63, v67, v71, snapValue, v40, v41, v42, v43);\n\treturn 0;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 SnapValue(Vector3 val, float snapValue)
		{
			Vector3 vector = default(Vector3);
			float num = Snap(vector.x, snapValue);
			float num2 = Snap(val.y, snapValue);
			float num3 = Snap(val.z, snapValue);
			Vector3 vector2 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x600022E")]
		[Address(RVA = "0xB00B94", Offset = "0xB00B94", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EF74F0]);\n\tv35 = *([v34 @ X8_v50]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, assembly, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20224B1]) = v53;\nL_001B:\n\tv54 = &v55 @ stack_-70;\n\tv60 = new ProGrids.pg_Util+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v60);\n\tv63 = v60 == 0;\n\tif (v63) goto L_FFFFFFFF;\n\tv60.assembly = assembly;\n\tgoto L_0034;\n\tv146 = *([v66 @ X0_v24+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0034;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v66, v61, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0034:\n\tv154 = 0x1819000 + 0x33C;\n\tv156 = System.Func`2<System.Reflection.Assembly, System.Boolean>::.ctor(type, v154, methodInfo);\n\tv189 = System.Type::GetType(v156);\n\tv191 = v189 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_0042;\n\tv204 = System.Type::GetType(type);\nL_0042:\n\tv208 = System.Type::op_Equality(v139, 0);\n\tv212 = v208 == 0;\n\tif (v212) goto L_FFFFFFFF;\n\tv182 = System.AppDomain::get_CurrentDomain();\n\tv184 = v182 == 0;\n\tif (v184) goto L_0129;\n\tv458 = System.AppDomain::GetAssemblies(v182);\n\tv492 = v60.assembly == 0;\n\tif (v492) goto L_0064;\n\tv532 = new System.Func`2<System.Reflection.Assembly, System.Boolean>();\n\tSystem.Func`2<System.Reflection.Assembly, System.Boolean>::.ctor(v532, v60, Il2CppMethodInfo);\n\tv539 = System.Linq.Enumerable::Where(v458, v532);\nL_0064:\n\tv137 = v127 == 0;\n\tif (v137) goto L_FFFFFFFF;\n\tgoto L_0095;\n\tv564 = *([v557 @ X8_v21+B0]);\n\tv565 = 0;\n\tv566 = v564 + 8;\n\tv568 = *([v604 @ X11_v30-8]);\n\tv610 = v568 == v560;\n\tif (v610) goto L_008E;\n\tv590 = v605 + 1;\n\tv615 = v590 < v559;\n\tv586 = ~v615;\n\tv588 = v604 + 0x10;\n\tv570 = ~v586;\n\tif (v570) goto L_FFFFFFFF;\n\tv591 = v127;\n\tv592 = 0;\n\tv593 = 0x8909C4(v591, v560, v592, v114, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0095;\n\tgoto L_01A6;\nL_008E:\n\tv616 = *([v604 @ X11_v30]);\n\tv617 = v616 << 4;\n\tv618 = v557 + v617;\n\tv619 = v618 + 0x130;\nL_0095:\n\tv640 = System.Collections.Generic.IEnumerable`1<System.Reflection.Assembly>::GetEnumerator(v127);\nL_00A2:\n\tgoto L_00C9;\n\tv673 = *([v667 @ X8_v26+B0]);\n\tv674 = 0;\n\tv675 = v673 + 8;\n\tv677 = *([v720 @ X11_v25-8]);\n\tv726 = v677 == v668;\n\tif (v726) goto L_00C2;\n\tv699 = v721 + 1;\n\tv731 = v699 < v669;\n\tv695 = ~v731;\n\tv697 = v720 + 0x10;\n\tv679 = ~v695;\n\tif (v679) goto L_FFFFFFFF;\n\tv700 = v144;\n\tv701 = 0;\n\tv702 = 0x8909C4(v700, v668, v701, v114, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00C9;\nL_00C2:\n\tv732 = *([v720 @ X11_v25]);\n\tv733 = v732 << 4;\n\tv734 = v667 + v733;\n\tv735 = v734 + 0x130;\nL_00C9:\n\tv414 = System.Collections.IEnumerator::MoveNext(v640);\n\tv741 = v414 == 0;\n\tif (v741) goto L_0120;\n\tgoto L_00F8;\n\tv747 = *([v742 @ X8_v30+B0]);\n\tv748 = 0;\n\tv749 = v747 + 8;\n\tv751 = *([v787 @ X11_v20-8]);\n\tv793 = v751 == v743;\n\tif (v793) goto L_00F1;\n\tv773 = v788 + 1;\n\tv798 = v773 < v744;\n\tv769 = ~v798;\n\tv771 = v787 + 0x10;\n\tv753 = ~v769;\n\tif (v753) goto L_FFFFFFFF;\n\tv774 = v144;\n\tv775 = 0;\n\tv776 = 0x8909C4(v774, v743, v775, v114, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00F8;\nL_00F1:\n\tv799 = *([v787 @ X11_v20]);\n\tv800 = v799 << 4;\n\tv801 = v742 + v800;\n\tv802 = v801 + 0x130;\nL_00F8:\n\tv707 = System.Collections.Generic.IEnumerator`1<System.Reflection.Assembly>::get_Current(v640);\n\tv809 = System.Reflection.Assembly::GetType(v707, type);\n\tgoto L_010E;\n\tv814 = *([v810 @ X0_v51+E0]);\n\tv815 = v814 == 0;\n\tv816 = ~v815;\n\tif (v816) goto L_010E;\n\tv818 = \"il2cpp_codegen_runtime_class_init\"(v810, v808, v807, v114, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_010E:\n\tv413 = System.Type::op_Inequality(v809, 0);\n\tv663 = v413 == 0;\n\tif (v663) goto L_00A2;\n\t*([v54 @ X24_v1]) = 0x7D;\n\tv822 = v640 == 0;\n\tv416 = ~v822;\n\tif (v416) goto L_0149;\n\tgoto L_0171;\nL_0120:\n\t*([v54 @ X24_v1]) = 0x7B;\n\tv746 = v640 == 0;\n\tv417 = ~v746;\n\tif (v417) goto L_0149;\n\tgoto L_0171;\n\tv672 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0129:\n\tv188 = new System.NullReferenceException();\n\tgoto L_013A;\n\tX23 = X21;\n\tgoto L_013A;\n\tgoto L_013A;\n\tX23 = X22;\n\tgoto L_013A;\n\tgoto L_013A;\nL_013A:\n\tv202 = v179 != 1;\n\tif (v202) goto L_01A7;\n\tv209 = System.Func`2<System.Reflection.Assembly, System.Boolean>::.ctor(v188, v179, v173);\n\tv418 = *([v209 @ X0_v13 (System.Func`2<System.Reflection.Assembly, System.Boolean>)]);\n\tv214 = System.Func`2<System.Reflection.Assembly, System.Boolean>::.ctor(v209, v179, v173);\n\tv219 = v427 == 0;\n\tif (v219) goto L_0171;\nL_0149:\n\tgoto L_0170;\n\tv459 = *([v429 @ X8_v12+B0]);\n\tv460 = 0;\n\tv461 = v459 + 8;\n\tv463 = *([v503 @ X11_v9-8]);\n\tv509 = v463 == v432;\n\tif (v509) goto L_0169;\n\tv485 = v504 + 1;\n\tv541 = v485 < v431;\n\tv481 = ~v541;\n\tv483 = v503 + 0x10;\n\tv465 = ~v481;\n\tif (v465) goto L_FFFFFFFF;\n\tv486 = v427;\n\tv487 = 0;\n\tv488 = 0x8909C4(v486, v432, v487, v396, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0170;\nL_0169:\n\tv542 = *([v503 @ X11_v9]);\n\tv543 = v542 << 4;\n\tv544 = v429 + v543;\n\tv545 = v544 + 0x130;\nL_0170:\n\tSystem.IDisposable::Dispose(v427);\nL_0171:\n\tv343 = v349 + 1;\n\tv308 = v343 == 0;\n\tif (v308) goto L_0191;\n\tv306 = *([v54 @ X24_v1+v349 @ X21_v2 (System.Int32)*4]) == 0x7D;\n\tif (v306) goto L_01A6;\n\tv344 = v347 == 0;\n\tif (v344) goto L_FFFFFFFF;\n\tv307 = *([v54 @ X24_v1+v349 @ X21_v2 (System.Int32)*4]) == 0x7B;\n\tif (v307) goto L_01A6;\n\tgoto L_0196;\nL_0191:\n\tv345 = v347 == 0;\n\tif (v345) goto L_01A6;\nL_0196:\n\tthrow System.TypeLoadException;\nL_01A6:\n\treturn v329;\nL_01A7:\n\treturnVal1 = System.Func`2<System.Reflection.Assembly, System.Boolean>::.ctor(v188, v179, v173);\n\treturn returnVal1;\n// 242 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Type GetType(string type, string assembly = null)
		{
			//IL_0026: Expected O, but got I4
			//IL_02b0: Expected I, but got O
			//IL_02e7: Expected I, but got O
			//IL_00a0: Expected I, but got O
			//IL_021b: Expected O, but got I4
			//IL_023f: Expected I, but got O
			//IL_0270: Expected I, but got O
			//IL_01a1: Expected O, but got I4
			//IL_01d0: Expected I, but got O
			//IL_0204: Expected I, but got O
			object obj2 = default(object);
			object obj = obj2;
			_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass7_0();
			bool flag = CS_0024_003C_003E8__locals6 == null;
			IEnumerator<Assembly> enumerator = default(IEnumerator<Assembly>);
			_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_1 = (_003C_003Ec__DisplayClass7_0)(object)enumerator;
			Type result;
			IntPtr method = default(IntPtr);
			Type type5 = default(Type);
			Type type6;
			Type type7;
			Type type8;
			IntPtr intPtr2;
			int num;
			Type type9;
			IntPtr intPtr3;
			int num2;
			if (!flag)
			{
				CS_0024_003C_003E8__locals6.assembly = assembly;
				object obj3 = 25268224 + 828;
				string typeName = default(string);
				Type type2 = Type.GetType(typeName);
				bool flag2 = (object)type2 == null;
				bool flag3 = !flag2;
				Type type3 = type2;
				if (!flag3)
				{
					Type type4 = Type.GetType(type);
					type3 = type4;
				}
				if (!(type3 == null))
				{
					result = type3;
					goto IL_047c;
				}
				AppDomain currentDomain = AppDomain.CurrentDomain;
				bool flag4 = currentDomain == null;
				method = (IntPtr)null;
				Func<Assembly, bool> func = default(Func<Assembly, bool>);
				type5 = (Type)(object)func;
				type6 = null;
				_003C_003Ec__DisplayClass7_1 = CS_0024_003C_003E8__locals6;
				if (flag4)
				{
					goto IL_0416;
				}
				Assembly[] assemblies = currentDomain.GetAssemblies();
				bool flag5 = CS_0024_003C_003E8__locals6.assembly == null;
				Assembly[] array = assemblies;
				if (!flag5)
				{
					Func<Assembly, bool> predicate = delegate(Assembly x)
					{
						string fullName = x.FullName;
						return fullName.Contains(CS_0024_003C_003E8__locals6.assembly);
					};
					IEnumerable<Assembly> enumerable = assemblies.Where(predicate);
					array = (Assembly[])enumerable;
				}
				bool flag6 = array == null;
				IntPtr intPtr = default(IntPtr);
				method = intPtr;
				type5 = (Type)(object)func;
				_003C_003Ec__DisplayClass7_1 = CS_0024_003C_003E8__locals6;
				if (!flag6)
				{
					enumerator = ((IEnumerable<Assembly>)array).GetEnumerator();
					type5 = type3;
					while (enumerator.MoveNext())
					{
						Assembly current = enumerator.Current;
						type7 = current.GetType(type);
						bool flag7 = type7 != null;
						bool flag8 = !flag7;
						type5 = type7;
						if (flag8)
						{
							continue;
						}
						goto IL_0198;
					}
					obj = 123;
					bool flag9 = enumerator == null;
					bool flag10 = !flag9;
					type8 = null;
					intPtr2 = (IntPtr)null;
					num = 0;
					_003C_003Ec__DisplayClass7_1 = (_003C_003Ec__DisplayClass7_0)(object)enumerator;
					if (!flag10)
					{
						type9 = type5;
						result = null;
						intPtr3 = (IntPtr)null;
						num2 = 0;
						goto IL_04bd;
					}
					goto IL_04e8;
				}
			}
			type6 = null;
			goto IL_0416;
			IL_039c:
			throw new TypeLoadException();
			IL_0416:
			NullReferenceException ex = (NullReferenceException)(object)new Func<Assembly, bool>(type6, method);
			if ((IntPtr)type6 == (IntPtr)1)
			{
				Func<Assembly, bool> func2 = default(Func<Assembly, bool>);
				intPtr2 = (IntPtr)func2;
				bool flag11 = _003C_003Ec__DisplayClass7_1 == null;
				type8 = null;
				num = -1;
				type9 = type5;
				result = null;
				intPtr3 = (IntPtr)func2;
				num2 = -1;
				if (flag11)
				{
					goto IL_04bd;
				}
				goto IL_04e8;
			}
			Type result2 = default(Type);
			return result2;
			IL_0198:
			obj = 125;
			bool flag12 = enumerator == null;
			bool flag13 = !flag12;
			type5 = type7;
			type8 = type7;
			intPtr2 = (IntPtr)null;
			num = 0;
			_003C_003Ec__DisplayClass7_1 = (_003C_003Ec__DisplayClass7_0)(object)enumerator;
			if (!flag13)
			{
				type9 = type7;
				result = type7;
				intPtr3 = (IntPtr)null;
				num2 = 0;
				goto IL_04bd;
			}
			goto IL_04e8;
			IL_04bd:
			if (num2 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v349 @ X21_v2 (System.Int32)*4]");
				if ((IntPtr)0 != (IntPtr)125)
				{
					if (intPtr3 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v349 @ X21_v2 (System.Int32)*4]");
						bool flag14 = (IntPtr)0 == (IntPtr)123;
						result = type9;
						if (!flag14)
						{
							goto IL_039c;
						}
					}
					else
					{
						result = type9;
					}
				}
			}
			else
			{
				bool flag15 = intPtr3 == (IntPtr)0;
				result = type9;
				if (!flag15)
				{
					goto IL_039c;
				}
			}
			goto IL_047c;
			IL_047c:
			return result;
			IL_04e8:
			((IDisposable)(object)_003C_003Ec__DisplayClass7_1).Dispose();
			type9 = type5;
			result = type8;
			intPtr3 = intPtr2;
			num2 = num;
			goto IL_04bd;
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0xB00FD8", Offset = "0xB00FD8", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([20224B2]) & 1;\n\tv15 = v14 == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_001A;\n\tisEnabled = 0xB178C8(isEnabled, methodInfo, v112, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20224B2]) = X8;\nL_001A:\n\tgoto L_0024;\n\tv41 = *([v37 @ X0_v1+E0]);\n\tv42 = v41 == 0;\n\tv43 = ~v42;\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v37, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tv52 = ProGrids.pg_Util::GetType(\"UnityEditor.AnnotationUtility\", 0);\n\tv139 = System.Type::GetProperty(v52, \"showGrid\", 0x28);\n\t// 52 Box v148 @ X0_v25 (System.Object), typeof(System.Boolean), &isEnabled @ X0 (System.Boolean)\n\tv154 = v139 == 0;\n\tif (v154) goto L_004A;\n\tisEnabled = System.Reflection.PropertyInfo::SetValue(v139, 0, v148, 0x28, 0, 0, 0);\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\nL_004A:\n\tv157 = new System.NullReferenceException();\n\tgoto L_0058;\n\tgoto L_0058;\n\tgoto L_0058;\nL_0058:\n\tv58 = 0 != 1;\n\tif (v58) goto L_0073;\n\tisEnabled = 0x6D2BC0(v157, 0, v112, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv176 = *([isEnabled @ X0 (System.Boolean)]);\n\tisEnabled = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v176 @ X8_v11]), v112, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv191 = isEnabled & 1;\n\tv173 = v191 == 0;\n\tif (v173) goto L_0069;\n\tisEnabled = 0x6D2490(isEnabled, *([v176 @ X8_v11]), v112, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0047;\nL_0069:\n\tisEnabled = 0x6D1E60(8, *([v176 @ X8_v11]), v112, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\t*([isEnabled @ X0 (System.Boolean)]) = *([isEnabled @ X0 (System.Boolean)]);\n\tv115 = 0x1E8A000 + 0x870;\n\tv195 = 0x6D2A00(isEnabled, v115, 0, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tisEnabled = 0x6D2490(v195, v115, 0, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0073:\n\tisEnabled = 0x6D2380(v124, v115, 0, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tisEnabled = 0x846AA4(isEnabled, v115, 0, v109, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetUnityGridEnabled(bool isEnabled)
		{
			//IL_0116: Expected O, but got I4
			//IL_018f: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20224B2]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B178C8 (inside Tayx.Graphy.Ram.G_RamGraph::.ctor +0x1C)");
				return;
			}
			Type type = GetType("UnityEditor.AnnotationUtility");
			PropertyInfo property = type.GetProperty("showGrid", BindingFlags.Static | BindingFlags.NonPublic);
			object value = isEnabled;
			bool flag = (object)property == null;
			string text = null;
			if (!flag)
			{
				property.SetValue(null, value, BindingFlags.Static | BindingFlags.NonPublic, null, null, null);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag2 = 0 != 1;
			NullReferenceException ex2 = ex;
			if (!flag2)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = isEnabled;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				if (((isEnabled ? 1u : 0u) & 1u) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					return;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
				bool flag3 = isEnabled;
				text = (string)(32022528 + 2160);
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0xB01148", Offset = "0xB01148", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA98A0]);\n\tv15 = *([v14 @ X8_v26]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20224B3]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tv53 = ProGrids.pg_Util::GetType(\"UnityEditor.AnnotationUtility\", 0);\n\tv60 = System.Type::GetProperty(v53, \"showGrid\", 0x28);\n\tv70 = *([v60 @ X0_v28 (System.Reflection.PropertyInfo)]);\n\tv75 = System.Reflection.PropertyInfo::GetValue(v60, 0, 0);\n\tv101 = ~v101_asT;\n\tif (v101) goto L_005A;\n\tv128 = \"il2cpp_vm_object_unbox\"(v75, System.Boolean, 0, *([v70 @ X8_v18 (Il2CppClass<System.Reflection.PropertyInfo>)+2C8]), v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv134 = *([v128 @ X0_v30]) == 0;\n\tv139 = ~v134;\nL_0056:\n\treturn returnVal1;\n\tv61 = new System.NullReferenceException();\n\tv69 = new System.NullReferenceException();\n\tv85 = new System.NullReferenceException();\nL_005A:\n\tv127 = new System.InvalidCastException();\n\tgoto L_0068;\n\tgoto L_0068;\n\tgoto L_0068;\nL_0068:\n\tv151 = v183 != 1;\n\tif (v151) goto L_0084;\n\tv179 = 0x6D2BC0(v127, v183, v181, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv172 = *([v179 @ X0_v14]);\n\tv216 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v172 @ X8_v12]), v181, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv217 = v216 & 1;\n\tv170 = v217 == 0;\n\tif (v170) goto L_007A;\n\tv218 = 0x6D2490(v216, *([v172 @ X8_v12]), v181, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0056;\nL_007A:\n\tv220 = 0x6D1E60(8, *([v172 @ X8_v12]), v181, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\t*([v220 @ X0_v18]) = *([v179 @ X0_v14]);\n\tv183 = 0x1E8A000 + 0x870;\n\tv222 = 0x6D2A00(v220, v183, 0, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv186 = 0x6D2490(v222, v183, 0, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0084:\n\tv193 = 0x6D2380(v190, v183, 0, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturnVal2 = 0x846AA4(v193, v183, 0, v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetUnityGridEnabled()
		{
			//IL_003d: Expected I, but got O
			//IL_005e: Expected I4, but got O
			Type type = GetType("UnityEditor.AnnotationUtility");
			PropertyInfo property = type.GetProperty("showGrid", BindingFlags.Static | BindingFlags.NonPublic);
			IntPtr intPtr = (IntPtr)property;
			object value = property.GetValue(null, null);
			if ((int)((value is bool) ? value : null) != 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				bool flag = obj == null;
				return !flag;
			}
			InvalidCastException ex = new InvalidCastException();
			IntPtr intPtr2 = default(IntPtr);
			bool flag2 = intPtr2 != (IntPtr)1;
			InvalidCastException ex2 = ex;
			if (!flag2)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				object obj2 = obj3;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj4 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					return false;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj5 = obj3;
				intPtr2 = (IntPtr)(32022528 + 2160);
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				InvalidCastException ex3 = default(InvalidCastException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x6000231")]
		[Address(RVA = "0xB012B4", Offset = "0xB012B4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv44 = *([1EDE380]);\n\tv45 = *([v44 @ X8_v32]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, v47, v48, v49, v50, v51, v52, v53, val, v0, v2, mask, v3, v5, snapValue, v54);\n\tv58 = 0 | 1;\n\t*([20224B4]) = v58;\nL_002A:\n\tgoto L_0032;\n\tv65 = *([v61 @ X0_v2+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0032;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v61, v47, v48, v49, v50, v51, v52, v53, val, v0, v2, mask, v3, v5, snapValue, v54);\nL_0032:\n\tv74 = UnityEngine.Mathf::Abs(mask);\n\tv78 = v74 < 0.0001f;\n\tif (v78) goto L_0051;\n\tgoto L_004B;\n\tv106 = *([v86 @ X0_v21 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_004B;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v86, v47, v48, v49, v50, v51, v52, v53, v74, v0, v2, mask, v3, v5, snapValue, v54);\nL_004B:\n\tv91 = ProGrids.pg_Util::Snap(val, snapValue);\nL_0051:\n\tgoto L_0057;\n\tv111 = *([v102 @ X0_v5+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tgoto L_0057;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v102, v47, v48, v49, v50, v51, v52, v53, v90, v100, v2, mask, v3, v5, snapValue, v54);\nL_0057:\n\tv118 = UnityEngine.Mathf::Abs(mask.y);\n\tv122 = v118 < 0.0001f;\n\tif (v122) goto L_0076;\n\tgoto L_0070;\n\tv150 = *([v130 @ X0_v17 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0070;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v130, v47, v48, v49, v50, v51, v52, v53, v118, v100, v2, mask, v3, v5, snapValue, v54);\nL_0070:\n\tv135 = ProGrids.pg_Util::Snap(val.y, snapValue);\nL_0076:\n\tgoto L_007C;\n\tv155 = *([v146 @ X0_v8+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tgoto L_007C;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v146, v47, v48, v49, v50, v51, v52, v53, v134, v144, v2, mask, v3, v5, snapValue, v54);\nL_007C:\n\tv162 = UnityEngine.Mathf::Abs(mask.z);\n\tv166 = v162 < 0.0001f;\n\tif (v166) goto L_009D;\n\tgoto L_0095;\n\tv198 = *([v174 @ X0_v13 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_0095;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v174, v47, v48, v49, v50, v51, v52, v53, v162, v144, v2, mask, v3, v5, snapValue, v54);\nL_0095:\n\tv179 = ProGrids.pg_Util::Snap(val.z, snapValue);\nL_009D:\n\tv191 = 0;\n\tv197 = 0x1586898(&v191 @ stack_-70_v1 (UnityEngine.Vector3), 0, v48, v49, v50, v51, v52, v53, v96, v140, v184, mask, mask.y, mask.z, snapValue, v54);\n\treturn 0;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 SnapValue(Vector3 val, Vector3 mask, float snapValue)
		{
			//IL_0061: Expected O, but got F4
			Vector3 vector = default(Vector3);
			float num = Mathf.Abs(vector.x);
			bool flag = num < 0.0001f;
			Vector3 vector2 = val;
			if (!flag)
			{
				Vector3 vector3 = default(Vector3);
				float num2 = Snap(vector3.x, snapValue);
				vector2 = (Vector3)num2;
			}
			float num3 = Mathf.Abs(mask.y);
			bool flag2 = num3 < 0.0001f;
			float y = val.y;
			if (!flag2)
			{
				float num4 = Snap(val.y, snapValue);
				y = num4;
			}
			float num5 = Mathf.Abs(mask.z);
			bool flag3 = num5 < 0.0001f;
			float z = val.z;
			if (!flag3)
			{
				float num6 = Snap(val.z, snapValue);
				z = num6;
			}
			Vector3 vector4 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0xB01468", Offset = "0xB01468", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv44 = *([1EE9160]);\n\tv45 = *([v44 @ X8_v32]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, v47, v48, v49, v50, v51, v52, v53, val, v0, v2, mask, v3, v5, snapValue, v54);\n\tv58 = 0 | 1;\n\t*([20224B5]) = v58;\nL_002A:\n\tgoto L_0032;\n\tv65 = *([v61 @ X0_v2+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0032;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v61, v47, v48, v49, v50, v51, v52, v53, val, v0, v2, mask, v3, v5, snapValue, v54);\nL_0032:\n\tv74 = UnityEngine.Mathf::Abs(mask);\n\tv78 = v74 < 0.0001f;\n\tif (v78) goto L_0051;\n\tgoto L_004B;\n\tv106 = *([v86 @ X0_v21 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_004B;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v86, v47, v48, v49, v50, v51, v52, v53, v74, v0, v2, mask, v3, v5, snapValue, v54);\nL_004B:\n\tv91 = ProGrids.pg_Util::SnapToCeil(val, snapValue);\nL_0051:\n\tgoto L_0057;\n\tv111 = *([v102 @ X0_v5+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tgoto L_0057;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v102, v47, v48, v49, v50, v51, v52, v53, v90, v100, v2, mask, v3, v5, snapValue, v54);\nL_0057:\n\tv118 = UnityEngine.Mathf::Abs(mask.y);\n\tv122 = v118 < 0.0001f;\n\tif (v122) goto L_0076;\n\tgoto L_0070;\n\tv150 = *([v130 @ X0_v17 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0070;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v130, v47, v48, v49, v50, v51, v52, v53, v118, v100, v2, mask, v3, v5, snapValue, v54);\nL_0070:\n\tv135 = ProGrids.pg_Util::SnapToCeil(val.y, snapValue);\nL_0076:\n\tgoto L_007C;\n\tv155 = *([v146 @ X0_v8+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tgoto L_007C;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v146, v47, v48, v49, v50, v51, v52, v53, v134, v144, v2, mask, v3, v5, snapValue, v54);\nL_007C:\n\tv162 = UnityEngine.Mathf::Abs(mask.z);\n\tv166 = v162 < 0.0001f;\n\tif (v166) goto L_009D;\n\tgoto L_0095;\n\tv198 = *([v174 @ X0_v13 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_0095;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v174, v47, v48, v49, v50, v51, v52, v53, v162, v144, v2, mask, v3, v5, snapValue, v54);\nL_0095:\n\tv179 = ProGrids.pg_Util::SnapToCeil(val.z, snapValue);\nL_009D:\n\tv191 = 0;\n\tv197 = 0x1586898(&v191 @ stack_-70_v1 (UnityEngine.Vector3), 0, v48, v49, v50, v51, v52, v53, v96, v140, v184, mask, mask.y, mask.z, snapValue, v54);\n\treturn 0;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 SnapToCeil(Vector3 val, Vector3 mask, float snapValue)
		{
			//IL_0061: Expected O, but got F4
			Vector3 vector = default(Vector3);
			float num = Mathf.Abs(vector.x);
			bool flag = num < 0.0001f;
			Vector3 vector2 = val;
			if (!flag)
			{
				Vector3 vector3 = default(Vector3);
				float num2 = SnapToCeil(vector3.x, snapValue);
				vector2 = (Vector3)num2;
			}
			float num3 = Mathf.Abs(mask.y);
			bool flag2 = num3 < 0.0001f;
			float y = val.y;
			if (!flag2)
			{
				float num4 = SnapToCeil(val.y, snapValue);
				y = num4;
			}
			float num5 = Mathf.Abs(mask.z);
			bool flag3 = num5 < 0.0001f;
			float z = val.z;
			if (!flag3)
			{
				float num6 = SnapToCeil(val.z, snapValue);
				z = num6;
			}
			Vector3 vector4 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0xB01694", Offset = "0xB01694", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv30 = *([1ECCE50]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, val, v0, v2, snapValue, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20224B6]) = v47;\nL_0021:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, val, v0, v2, snapValue, v40, v41, v42, v43);\nL_0029:\n\tv63 = ProGrids.pg_Util::SnapToFloor(val, snapValue);\n\tv67 = ProGrids.pg_Util::SnapToFloor(val.y, snapValue);\n\tv71 = ProGrids.pg_Util::SnapToFloor(val.z, snapValue);\n\tv74 = 0;\n\tv79 = 0x1586898(&v74 @ stack_-50_v1 (UnityEngine.Vector3), 0, v34, v35, v36, v37, v38, v39, v63, v67, v71, snapValue, v40, v41, v42, v43);\n\treturn 0;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 SnapToFloor(Vector3 val, float snapValue)
		{
			Vector3 vector = default(Vector3);
			float num = SnapToFloor(vector.x, snapValue);
			float num2 = SnapToFloor(val.y, snapValue);
			float num3 = SnapToFloor(val.z, snapValue);
			Vector3 vector2 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x6000234")]
		[Address(RVA = "0xB017E4", Offset = "0xB017E4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv44 = *([1EE3360]);\n\tv45 = *([v44 @ X8_v32]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, v47, v48, v49, v50, v51, v52, v53, val, v0, v2, mask, v3, v5, snapValue, v54);\n\tv58 = 0 | 1;\n\t*([20224B7]) = v58;\nL_002A:\n\tgoto L_0032;\n\tv65 = *([v61 @ X0_v2+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0032;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v61, v47, v48, v49, v50, v51, v52, v53, val, v0, v2, mask, v3, v5, snapValue, v54);\nL_0032:\n\tv74 = UnityEngine.Mathf::Abs(mask);\n\tv78 = v74 < 0.0001f;\n\tif (v78) goto L_0051;\n\tgoto L_004B;\n\tv106 = *([v86 @ X0_v21 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_004B;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v86, v47, v48, v49, v50, v51, v52, v53, v74, v0, v2, mask, v3, v5, snapValue, v54);\nL_004B:\n\tv91 = ProGrids.pg_Util::SnapToFloor(val, snapValue);\nL_0051:\n\tgoto L_0057;\n\tv111 = *([v102 @ X0_v5+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tgoto L_0057;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v102, v47, v48, v49, v50, v51, v52, v53, v90, v100, v2, mask, v3, v5, snapValue, v54);\nL_0057:\n\tv118 = UnityEngine.Mathf::Abs(mask.y);\n\tv122 = v118 < 0.0001f;\n\tif (v122) goto L_0076;\n\tgoto L_0070;\n\tv150 = *([v130 @ X0_v17 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0070;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v130, v47, v48, v49, v50, v51, v52, v53, v118, v100, v2, mask, v3, v5, snapValue, v54);\nL_0070:\n\tv135 = ProGrids.pg_Util::SnapToFloor(val.y, snapValue);\nL_0076:\n\tgoto L_007C;\n\tv155 = *([v146 @ X0_v8+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tgoto L_007C;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v146, v47, v48, v49, v50, v51, v52, v53, v134, v144, v2, mask, v3, v5, snapValue, v54);\nL_007C:\n\tv162 = UnityEngine.Mathf::Abs(mask.z);\n\tv166 = v162 < 0.0001f;\n\tif (v166) goto L_009D;\n\tgoto L_0095;\n\tv198 = *([v174 @ X0_v13 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_0095;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v174, v47, v48, v49, v50, v51, v52, v53, v162, v144, v2, mask, v3, v5, snapValue, v54);\nL_0095:\n\tv179 = ProGrids.pg_Util::SnapToFloor(val.z, snapValue);\nL_009D:\n\tv191 = 0;\n\tv197 = 0x1586898(&v191 @ stack_-70_v1 (UnityEngine.Vector3), 0, v48, v49, v50, v51, v52, v53, v96, v140, v184, mask, mask.y, mask.z, snapValue, v54);\n\treturn 0;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 SnapToFloor(Vector3 val, Vector3 mask, float snapValue)
		{
			//IL_0061: Expected O, but got F4
			Vector3 vector = default(Vector3);
			float num = Mathf.Abs(vector.x);
			bool flag = num < 0.0001f;
			Vector3 vector2 = val;
			if (!flag)
			{
				Vector3 vector3 = default(Vector3);
				float num2 = SnapToFloor(vector3.x, snapValue);
				vector2 = (Vector3)num2;
			}
			float num3 = Mathf.Abs(mask.y);
			bool flag2 = num3 < 0.0001f;
			float y = val.y;
			if (!flag2)
			{
				float num4 = SnapToFloor(val.y, snapValue);
				y = num4;
			}
			float num5 = Mathf.Abs(mask.z);
			bool flag3 = num5 < 0.0001f;
			float z = val.z;
			if (!flag3)
			{
				float num6 = SnapToFloor(val.z, snapValue);
				z = num6;
			}
			Vector3 vector4 = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x6000235")]
		[Address(RVA = "0xB00AAC", Offset = "0xB00AAC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_001B;\n\tv22 = *([1F0D6F0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, val, round, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20224B8]) = v41;\nL_001B:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v25, v26, v27, v28, v29, v30, v31, val, round, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv55 = val / round;\n\tv57 = &v11 @ stack_-10_v2 - 8;\n\tv58 = 0x6D1ED0(v57, v25, v26, v27, v28, v29, v30, v31, v55, round, v32, v33, v34, v35, v36, v37);\n\tv68 = v55 >= 0;\n\tif (v68) goto L_0049;\n\tv79 = v55 != -0.5d;\n\tif (v79) goto L_005D;\n\tv133 = *([v10 @ X29_v1-8]);\n\tgoto L_004F;\nL_0049:\n\tv90 = v55 != 0.5d;\n\tif (v90) goto L_0061;\n\tv133 = *([v10 @ X29_v1-8]);\nL_004F:\n\tv114 = v133 + v101;\n\tv115 = v133 & 1;\n\tv117 = v115 == 0;\n\tv120 = ~v117;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\tgoto L_0066;\nL_005D:\n\tv94 = v55 + -0.5f;\n\tv133 = UnityEngine.Mathf::Ceil(v94);\n\tgoto L_0066;\nL_0061:\n\tv99 = v55 + 0.5f;\n\tv133 = UnityEngine.Mathf::Floor(v99);\nL_0066:\n\treturnVal1 = v133 * round;\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Snap(float val, float round)
		{
			//IL_002b: Expected O, but got I
			//IL_00d6: Expected F4, but got I
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected I4, but got Unknown
			//IL_0092: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			float num = val / round;
			object obj3 = (long)(IntPtr)obj2 - 8L;
			Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @6D1ED0 (native modf)");
			float num2;
			float num3;
			if (num < 0f)
			{
				if ((double)num != -0.5)
				{
					float f = num + -0.5f;
					num2 = Mathf.Ceil(f);
					goto IL_013a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-8]");
				num2 = 0f;
				num3 = -1f;
			}
			else
			{
				if ((double)num != 0.5)
				{
					float f2 = num + 0.5f;
					num2 = Mathf.Floor(f2);
					goto IL_013a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-8]");
				num2 = 0f;
				num3 = 1f;
			}
			float num4 = num2 + num3;
			if ((num2 & 1) != 0)
			{
				num2 = num4;
			}
			goto IL_013a;
			IL_013a:
			return num2 * round;
		}

		[Token(Token = "0x6000236")]
		[Address(RVA = "0xB0176C", Offset = "0xB0176C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF4140]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, val, snapValue, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20224B9]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v25, v26, v27, v28, v29, v30, v31, val, snapValue, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = val / snapValue;\n\tv59 = UnityEngine.Mathf::Floor(v58);\n\treturnVal1 = v59 * snapValue;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float SnapToFloor(float val, float snapValue)
		{
			float f = val / snapValue;
			float num = Mathf.Floor(f);
			return num * snapValue;
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xB0161C", Offset = "0xB0161C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EAC9E8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, val, snapValue, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20224BA]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v25, v26, v27, v28, v29, v30, v31, val, snapValue, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = val / snapValue;\n\tv59 = UnityEngine.Mathf::Ceil(v58);\n\treturnVal1 = v59 * snapValue;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float SnapToCeil(float val, float snapValue)
		{
			float f = val / snapValue;
			float num = Mathf.Ceil(f);
			return num * snapValue;
		}

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xB01998", Offset = "0xB01998", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = v >= 0;\n\tif (v14) goto L_FFFFFFFF;\n\tgoto L_001C;\nL_001C:\n\tv27 = v.y >= 0;\n\tif (v27) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\tv40 = v.z >= 0;\n\tif (v40) goto L_0031;\n\tgoto L_0031;\nL_0031:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 CeilFloor(Vector3 v)
		{
			//IL_003e: Expected O, but got F4
			//IL_0030: Expected O, but got F4
			Vector3 vector = default(Vector3);
			Vector3 result = ((!(vector.x < 0f)) ? ((Vector3)1f) : ((Vector3)(-1f)));
			if (v.y < 0f)
			{
			}
			if (v.z < 0f)
			{
			}
			return result;
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0xB019BC", Offset = "0xB019BC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EAEC48]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20224BB]) = v35;\nL_0017:\n\tgoto L_0029;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\t// 27 Jump @b13\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = ProGrids.pg_Util;\nL_0029:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Transform, ProGrids.pg_Util+SnapEnabledOverride>::Clear(v49.m_SnapOverrideCache);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ClearSnapEnabledCache()
		{
			m_SnapOverrideCache.Clear();
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0xB01A38", Offset = "0xB01A38", Length = "0x784")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = *([1ED6F40]);\n\tv35 = *([v34 @ X8_v152]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20224BC]) = v54;\nL_0023:\n\tgoto L_0033;\n\tv63 = *([v59 @ X0_v2 (Il2CppClass<ProGrids.pg_Util>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\t// 39 Jump @b135\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv67 = ProGrids.pg_Util;\nL_0033:\n\tv80 = System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ProGrids.pg_Util+SnapEnabledOverride>::TryGetValue(v70.m_SnapOverrideCache, t, &v77 @ stack_-68_v5 (ProGrids.pg_Util+SnapEnabledOverride));\n\tv262 = v80 == 0;\n\tif (v262) goto L_0045;\n\tv310 = ProGrids.pg_Util+SnapEnabledOverride::IsEnabled(v77);\n\tgoto L_01F8;\nL_0045:\n\tv219 = UnityEngine.Component::GetComponents(t);\n\tv550 = v219.Length < 1;\n\tif (v550) goto L_01CC;\nL_005E:\n\t;\n\tv295 = new *([v259 @ X19_v18 (Il2CppClass<ProGrids.pg_Util+<>c__DisplayClass26_0>)])();\n\tSystem.Object::.ctor(v295);\n\tv620 = v117 < v219.Length;\n\tv172 = ~v620;\n\tif (v172) goto L_0284;\n\t*([v295 @ X0_v32 (System.Object)+10]) = v219[v117 @ X28_v10 (System.Int32)];\n\tv351 = new *([v130 @ X22_v15 (Il2CppClass<ProGrids.pg_Util+<>c__DisplayClass26_1>)])();\n\tSystem.Object::.ctor(v351);\n\t*([v351 @ X0_v34 (System.Object)+18]) = v295;\n\tgoto L_008A;\n\tv634 = *([v630 @ X0_v35+E0]);\n\tv635 = v634 == 0;\n\tv636 = ~v635;\n\tif (v636) goto L_008A;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v630, v342, v293, v188, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_008A:\n\tv352 = UnityEngine.Object::op_Equality(*([v295 @ X0_v32 (System.Object)+10]), 0);\n\tv643 = v352 == 0;\n\tv644 = ~v643;\n\tif (v644) goto L_01BE;\n\tv248 = *([v351 @ X0_v34 (System.Object)+18]);\n\tv664 = System.Object::GetType(*([v248 @ X8_v33+10]));\n\tv675 = *([v85 @ X27_v14 (Il2CppClass<ProGrids.pg_Util>)]);\n\tgoto L_00A4;\n\tv669 = *([v665 @ X8_v34+E0]);\n\tv670 = v669 == 0;\n\tv671 = ~v670;\n\tif (v671) goto L_00A4;\n\tv677 = v665;\n\tv673 = \"il2cpp_codegen_runtime_class_init\"(v677, v201, v209, v188, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv676 = *([v83 @ X27_v11 (Il2CppClass<ProGrids.pg_Util>)]);\nL_00A4:\n\tv250 = *([v675 @ X8_v35+B8]);\n\tv353 = System.Collections.Generic.Dictionary`2<System.Type, System.Boolean>::TryGetValue(*([v250 @ X8_v36+8]), v664, &v316 @ stack_-6C_v11 (System.Boolean));\n\tv680 = v353 == 0;\n\tv681 = ~v680;\n\tif (v681) goto L_0112;\n\tv697 = System.Reflection.MemberInfo::GetCustomAttributes(v664, 1);\n\tgoto L_00CC;\n\tv712 = *([v700 @ X8_v118 (Il2CppClass<ProGrids.pg_Util+<>c>)+E0]);\n\tv713 = v712 == 0;\n\tv714 = ~v713;\n\tif (v714) goto L_00CC;\n\tv737 = v700;\n\tv717 = \"il2cpp_codegen_runtime_class_init\"(v737, v693, v696, v339, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv720 = ProGrids.pg_Util+<>c;\nL_00CC:\n\tv90 = v721.<>9__26_0;\n\tv723 = v721.<>9__26_0 == 0;\n\tv724 = ~v723;\n\tif (v724) goto L_00F8;\n\tgoto L_00E2;\n\tv777 = *([v719 @ X8_v119 (Il2CppClass<ProGrids.pg_Util+<>c>)+E0]);\n\tv778 = v777 == 0;\n\tv779 = ~v778;\n\tif (v779) goto L_00E2;\n\tv796 = v719;\n\tv782 = \"il2cpp_codegen_runtime_class_init\"(v796, v693, v696, v339, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv784 = ProGrids.pg_Util+<>c;\n\tv780 = *([v784 @ X8_v142+B8]);\nL_00E2:\n\tv752 = new System.Func`2<System.Object, System.Boolean>();\n\tSystem.Func`2<System.Object, System.Boolean>::.ctor(v752, v745.<>9, Il2CppMethodInfo);\n\tv756.<>9__26_0 = v752;\nL_00F8:\n\tv760 = System.Linq.Enumerable::Any(v697, v90);\n\tv807 = *([v85 @ X27_v14 (Il2CppClass<ProGrids.pg_Util>)]);\n\tgoto L_0107;\n\tv801 = *([v789 @ X8_v123+E0]);\n\tv802 = v801 == 0;\n\tv803 = ~v802;\n\tgoto L_0107;\n\tv823 = v789;\n\tv805 = \"il2cpp_codegen_runtime_class_init\"(v823, v202, v212, v191, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv808 = *([v83 @ X27_v11 (Il2CppClass<ProGrids.pg_Util>)]);\nL_0107:\n\tv251 = *([v807 @ X8_v124+B8]);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Boolean>::Add(*([v251 @ X8_v125+8]), v664, v760);\nL_0112:\n\tv690 = ~v760;\n\tv691 = ~v690;\n\tif (v691) goto L_01FB;\n\tv728 = *([v85 @ X27_v14 (Il2CppClass<ProGrids.pg_Util>)]);\n\tgoto L_0120;\n\tv725 = *([v704 @ X0_v52+E0]);\n\tv726 = v725 == 0;\n\tv727 = ~v726;\n\tif (v727) goto L_0120;\n\tv761 = \"il2cpp_codegen_runtime_class_init\"(v704, v203, v213, v192, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv729 = *([v83 @ X27_v11 (Il2CppClass<ProGrids.pg_Util>)]);\nL_0120:\n\tv252 = *([v728 @ X0_v53+B8]);\n\tv89 = v351 + 0x10;\n\tv765 = System.Collections.Generic.Dictionary`2<System.Type, System.Reflection.MethodInfo>::TryGetValue(*([v252 @ X8_v49+10]), v664, v89);\n\tv795 = v765 == 0;\n\tif (v795) goto L_FFFFFFFF;\n\tv654 = System.Reflection.MethodInfo::op_Inequality(*([v89 @ X24_v12 (System.Reflection.MethodInfo&)]), 0);\n\tv656 = v654 == 0;\n\tif (v656) goto L_01BE;\n\tgoto L_0212;\n\tgoto L_0146;\n\tv826 = *([v812 @ X0_v64 (Il2CppClass<ProGrids.pg_Util+<>c>)+E0]);\n\tv827 = v826 == 0;\n\tv828 = ~v827;\n\tif (v828) goto L_0146;\n\tv838 = \"il2cpp_codegen_runtime_class_init\"(v812, v763, v764, v646, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv830 = ProGrids.pg_Util+<>c;\nL_0146:\n\tv846 = v834.<>9__26_2;\n\tv836 = v834.<>9__26_2 == 0;\n\tv837 = ~v836;\n\tif (v837) goto L_017A;\n\tv842 = *([v829 @ X0_v65 (Il2CppClass<ProGrids.pg_Util+<>c>)+12F]) & 2;\n\tv843 = v842 == 0;\n\tv844 = ~v843;\n\tif (v844) goto L_FFFFFFFF;\n\tgoto L_0161;\n\tgoto L_0161;\n\tv891 = \"il2cpp_codegen_runtime_class_init\"(v829, v763, v764, v646, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv914 = ProGrids.pg_Util+<>c;\n\tv893 = *([v914 @ X8_v103+B8]);\nL_0161:\n\tv856 = new System.Func`2<System.Object, System.Boolean>();\n\tSystem.Func`2<System.Object, System.Boolean>::.ctor(v856, v892.<>9, Il2CppMethodInfo);\n\tv861.<>9__26_2 = v856;\nL_017A:\n\tv354 = System.Linq.Enumerable::Any(v135, v846);\n\tv876 = v354 == 0;\n\tif (v876) goto L_01A7;\n\tv918 = System.Type::GetMethod(v664, \"IsSnapEnabled\", 0x74);\n\t*([v89 @ X24_v12 (System.Reflection.MethodInfo&)]) = v918;\n\tv956 = *([v85 @ X27_v14 (Il2CppClass<ProGrids.pg_Util>)]);\n\tgoto L_0195;\n\tv953 = *([v945 @ X0_v76+E0]);\n\tv954 = v953 == 0;\n\tv955 = ~v954;\n\tif (v955) goto L_0195;\n\tv960 = \"il2cpp_codegen_runtime_class_init\"(v945, v204, v214, v193, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv957 = *([v85 @ X27_v14 (Il2CppClass<ProGrids.pg_Util>)]);\nL_0195:\n\tv253 = *([v956 @ X0_v77+B8]);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Reflection.MethodInfo>::Add(*([v253 @ X8_v80+10]), v664, *([v89 @ X24_v12 (System.Reflection.MethodInfo&)]));\n\tv655 = System.Reflection.MethodInfo::op_Inequality(*([v89 @ X24_v12 (System.Reflection.MethodInfo&)]), 0);\n\tv657 = v655 == 0;\n\tif (v657) goto L_01BE;\n\tgoto L_0226;\nL_01A7:\n\tv922 = *([v85 @ X27_v14 (Il2CppClass<ProGrids.pg_Util>)]);\n\tgoto L_01B4;\n\tv919 = *([v900 @ X0_v69+E0]);\n\tv920 = v919 == 0;\n\tv921 = ~v920;\n\tif (v921) goto L_01B4;\n\tv949 = \"il2cpp_codegen_runtime_class_init\"(v900, v205, v215, v194, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv923 = *([v85 @ X27_v14 (Il2CppClass<ProGrids.pg_Util>)]);\nL_01B4:\n\tv254 = *([v922 @ X0_v70+B8]);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Reflection.MethodInfo>::Add(*([v254 @ X8_v72+10]), v664, 0);\nL_01BE:\n\t;\n\tv117 = v117 + 1;\n\tv569 = v117 < v219.Length;\n\tif (v569) goto L_005E;\nL_01CC:\n\tv612 = *([v313 @ X27_v10 (Il2CppClass<ProGrids.pg_Util>)]);\n\tgoto L_01D8;\n\tv609 = *([v592 @ X0_v24+E0]);\n\tv610 = v609 == 0;\n\tv611 = ~v610;\n\tif (v611) goto L_01D8;\n\tv619 = \"il2cpp_codegen_runtime_class_init\"(v592, v581, v348, v340, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv613 = *([v313 @ X27_v10 (Il2CppClass<ProGrids.pg_Util>)]);\nL_01D8:\n\tv617 = *([v612 @ X0_v25+B8]);\n\tv431 = *([v617 @ X8_v22]);\n\tv355 = new ProGrids.pg_Util+SnapIsEnabledOverride();\n\tSystem.Object::.ctor(v355);\n\tv355.m_SnapIsEnabled = 1;\nL_01EA:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Transform, ProGrids.pg_Util+SnapEnabledOverride>::Add(v431, v487, v472);\nL_01F8:\n\treturnVal1 = v310 & 1;\n\treturn returnVal1;\nL_01FB:\n\tv767 =\n// ... truncated")]
		public unsafe static bool SnapIsEnabled(Transform t)
		{
			//IL_007b: Expected I, but got O
			//IL_040c: Expected O, but got I
			//IL_0766: Expected O, but got I
			//IL_009f: Expected I, but got O
			//IL_00b6: Expected I, but got O
			//IL_00d1: Expected I, but got O
			//IL_0111: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_0169: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_05f3: Expected O, but got I
			//IL_0193: Expected O, but got I
			//IL_0438: Expected O, but got I
			//IL_0235: Expected O, but got I
			//IL_0805: Expected O, but got I
			//IL_067c: Expected O, but got I
			//IL_0870: Expected O, but got I
			//IL_0580: Expected O, but got I
			//IL_0262: Expected O, but got I
			//IL_0666: Expected O, but got I
			//IL_02c3: Expected I, but got O
			//IL_01f4: Expected O, but got I
			//IL_03a7: Expected O, but got I
			//IL_071b: Expected O, but got I
			//IL_0348: Expected O, but got I
			//IL_04ab: Expected O, but got I
			//IL_03c2: Expected O, but got I
			//IL_0705: Expected O, but got I
			//IL_06e0: Expected I, but got O
			//IL_079e: Expected O, but got I
			//IL_0368: Expected O, but got I
			//IL_04f0: Expected O, but got I
			//IL_0513: Expected O, but got I
			//IL_0513: Expected O, but got I
			//IL_04b8: Expected O, but got I
			//IL_0529: Expected I4, but got O
			//IL_07dd: Expected O, but got I
			//IL_05cb: Expected I4, but got O
			bool flag;
			IntPtr intPtr;
			Transform key;
			Dictionary<Transform, SnapEnabledOverride> dictionary2;
			SnapIsEnabledOverride value3;
			if (m_SnapOverrideCache.TryGetValue(t, out var value))
			{
				flag = value.IsEnabled();
			}
			else
			{
				MonoBehaviour[] components = t.GetComponents<MonoBehaviour>();
				bool flag2 = components.Length < 1;
				intPtr = (IntPtr)typeof(pg_Util);
				key = t;
				if (flag2)
				{
					goto IL_0404;
				}
				IntPtr intPtr2 = (IntPtr)typeof(pg_Util);
				int num = 0;
				IntPtr intPtr3 = (IntPtr)typeof(_003C_003Ec__DisplayClass26_1);
				IEnumerable<object> source = null;
				Transform transform = t;
				IntPtr intPtr4 = (IntPtr)typeof(_003C_003Ec__DisplayClass26_0);
				bool flag3 = default(bool);
				IntPtr method = default(IntPtr);
				while (true)
				{
					object obj = new object();
					int snapIsEnabled;
					Dictionary<Transform, SnapEnabledOverride> dictionary;
					Func<bool> isEnabledDelegate;
					if (num < components.Length)
					{
						_ = components[num];
						object obj2 = new object();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X0_v32 (System.Object)+10]");
						if (!((UnityEngine.Object)0 == null))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X0_v34 (System.Object)+18]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X8_v33+10]");
							Type type = 0.GetType();
							object obj4 = (long)intPtr2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ X8_v35+B8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ X8_v36+8]");
							if (!((Dictionary<Type, bool>)0).TryGetValue(type, out var value2))
							{
								object[] customAttributes = type.GetCustomAttributes(inherit: true);
								Func<object, bool> predicate = _003C_003Ec._003C_003E9__26_0;
								if (_003C_003Ec._003C_003E9__26_0 == null)
								{
									predicate = (_003C_003Ec._003C_003E9__26_0 = delegate(object x)
									{
										if (x != null)
										{
											string text = x.ToString();
											return text.Contains("ProGridsNoSnap");
										}
										return false;
									});
								}
								flag3 = customAttributes.Any(predicate);
								object obj6 = (long)intPtr2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ X8_v124+B8]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X8_v125+8]");
								((Dictionary<Type, bool>)0).Add(type, flag3);
								value2 = flag3;
								source = customAttributes;
							}
							if (flag3)
							{
								object obj8 = (long)intPtr2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ X0_v47+12F]");
								if (0u != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ X0_v47+E0]");
									if ((IntPtr)0 == (IntPtr)0)
									{
										obj8 = (long)intPtr2;
										snapIsEnabled = (flag3 ? 1 : 0) ^ 1;
										goto IL_07f5;
									}
								}
								snapIsEnabled = 0;
								goto IL_07f5;
							}
							object obj9 = (long)intPtr2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ X0_v53+B8]");
							object obj10 = 0;
							ref MethodInfo reference = ref *(MethodInfo*)((long)(IntPtr)obj2 + 16L);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ X8_v49+10]");
							if (((Dictionary<Type, MethodInfo>)0).TryGetValue(type, out reference))
							{
								if (reference != null)
								{
									object obj11 = (long)intPtr2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v880 @ X0_v98+B8]");
									object obj12 = 0;
									dictionary = (Dictionary<Transform, SnapEnabledOverride>)obj12;
									isEnabledDelegate = new Func<bool>(obj2, method);
									method = (IntPtr)0;
									goto IL_07c2;
								}
							}
							else
							{
								IntPtr intPtr5 = (IntPtr)typeof(_003C_003Ec);
								Func<object, bool> predicate2 = _003C_003Ec._003C_003E9__26_2;
								if (_003C_003Ec._003C_003E9__26_2 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ X0_v65 (Il2CppClass<ProGrids.pg_Util+<>c>)+12F]");
									Transform transform2 = ((0u != 0) ? transform : transform);
									Func<object, bool> func = (_003C_003Ec._003C_003E9__26_2 = delegate(object x)
									{
										if (x != null)
										{
											string text = x.ToString();
											return text.Contains("ProGridsConditionalSnap");
										}
										return false;
									});
									intPtr2 = (IntPtr)typeof(pg_Util);
									predicate2 = func;
									transform = transform2;
								}
								if (source.Any(predicate2))
								{
									MethodInfo method2 = type.GetMethod("IsSnapEnabled", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
									reference = ref *(MethodInfo*)method2;
									object obj13 = (long)intPtr2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X0_v77+B8]");
									object obj14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X8_v80+10]");
									((Dictionary<Type, MethodInfo>)0).Add(type, reference);
									if (reference != null)
									{
										object obj15 = (long)intPtr2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v975 @ X0_v82+B8]");
										object obj16 = 0;
										dictionary = (Dictionary<Transform, SnapEnabledOverride>)obj16;
										isEnabledDelegate = null;
										method = (IntPtr)0;
										goto IL_07c2;
									}
								}
								else
								{
									object obj17 = (long)intPtr2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ X0_v70+B8]");
									object obj18 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X8_v72+10]");
									((Dictionary<Type, MethodInfo>)0).Add(type, null);
								}
							}
						}
						num++;
						bool flag4 = num < components.Length;
						intPtr = intPtr2;
						key = transform;
						if (flag4)
						{
							continue;
						}
						goto IL_0404;
					}
					goto IL_05af;
					IL_07c2:
					ConditionalSnapOverride conditionalSnapOverride = null;
					conditionalSnapOverride.m_IsEnabledDelegate = isEnabledDelegate;
					dictionary.Add(transform, conditionalSnapOverride);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X0_v34 (System.Object)+18]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X0_v34 (System.Object)+10]");
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X8_v57+10]");
					object obj20 = ((MethodBase)(long)intPtr6).Invoke(0, null);
					if ((int)((obj20 is bool) ? obj20 : null) != 0)
					{
						break;
					}
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
					IL_07f5:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ X0_v47+B8]");
					object obj21 = 0;
					dictionary2 = (Dictionary<Transform, SnapEnabledOverride>)obj21;
					SnapIsEnabledOverride snapIsEnabledOverride = null;
					snapIsEnabledOverride.m_SnapIsEnabled = (byte)snapIsEnabled != 0;
					bool flag5 = obj21 == null;
					bool flag6 = !flag5;
					value3 = snapIsEnabledOverride;
					key = transform;
					if (flag6)
					{
						goto IL_0411;
					}
					NullReferenceException ex2 = new NullReferenceException();
					NullReferenceException ex3 = new NullReferenceException();
					goto IL_05af;
					IL_05af:
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj22 = default(object);
				bool flag7 = obj22 == null;
				bool flag8 = !flag7;
				flag = flag8;
			}
			goto IL_05d0;
			IL_05d0:
			return (byte)((flag ? 1u : 0u) & 1u) != 0;
			IL_0411:
			dictionary2.Add(key, value3);
			flag = true;
			goto IL_05d0;
			IL_0404:
			object obj23 = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X0_v25+B8]");
			object obj24 = 0;
			dictionary2 = (Dictionary<Transform, SnapEnabledOverride>)obj24;
			SnapIsEnabledOverride snapIsEnabledOverride2 = null;
			snapIsEnabledOverride2.m_SnapIsEnabled = true;
			value3 = snapIsEnabledOverride2;
			goto IL_0411;
		}

		[Token(Token = "0x600023B")]
		[Address(RVA = "0xB02228", Offset = "0xB02228", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EEF8E0]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20224BD]) = v37;\nL_0015:\n\tv41 = new System.Collections.Generic.Dictionary`2<UnityEngine.Transform, ProGrids.pg_Util+SnapEnabledOverride>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Transform, ProGrids.pg_Util+SnapEnabledOverride>::.ctor(v41);\n\tv49.m_SnapOverrideCache = v41;\n\tv53 = new System.Collections.Generic.Dictionary`2<System.Type, System.Boolean>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Boolean>::.ctor(v53);\n\tv59.m_NoSnapAttributeTypeCache = v53;\n\tv63 = new System.Collections.Generic.Dictionary`2<System.Type, System.Reflection.MethodInfo>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Reflection.MethodInfo>::.ctor(v63);\n\tv69.m_ConditionalSnapAttributeCache = v63;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static pg_Util()
		{
			Dictionary<Transform, SnapEnabledOverride> snapOverrideCache = new Dictionary<Transform, SnapEnabledOverride>();
			m_SnapOverrideCache = snapOverrideCache;
			Dictionary<Type, bool> noSnapAttributeTypeCache = new Dictionary<Type, bool>();
			m_NoSnapAttributeTypeCache = noSnapAttributeTypeCache;
			Dictionary<Type, MethodInfo> conditionalSnapAttributeCache = new Dictionary<Type, MethodInfo>();
			m_ConditionalSnapAttributeCache = conditionalSnapAttributeCache;
		}
	}
}
