using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ProGrids
{
	[Token(Token = "0x200004F")]
	public static class PGExtensions
	{
		[Token(Token = "0x600023C")]
		[Address(RVA = "0xAFFB7C", Offset = "0xAFFB7C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EBBC70]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20224A7]) = v45;\nL_0019:\n\tv105 = t_arr.Length;\n\tv58 = t_arr.Length < 1;\n\tif (v58) goto L_FFFFFFFF;\nL_0029:\n\tv161 = v70 < v105;\n\tv98 = ~v161;\n\tif (v98) goto L_0062;\n\tgoto L_0043;\n\tv218 = *([v213 @ X0_v11+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_0043;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v213, v151, v150, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0043:\n\tv142 = UnityEngine.Object::op_Equality(t_arr[v70 @ X22_v6 (System.Int32)], t);\n\tv226 = v142 == 0;\n\tv144 = ~v226;\n\tif (v144) goto L_FFFFFFFF;\n\tv105 = t_arr.Length;\n\tv70 = v70 + 1;\n\tv124 = v70 < t_arr.Length;\n\tif (v124) goto L_0029;\n\tgoto L_0061;\nL_0061:\n\treturn returnVal2;\nL_0062:\n\tv217 = new System.IndexOutOfRangeException();\n\tthrow v217;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Contains(this Transform[] t_arr, Transform t)
		{
			int num = t_arr.Length;
			if (t_arr.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						if (!(t_arr[num2] == t))
						{
							num = t_arr.Length;
							num2++;
							continue;
						}
						return true;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < t_arr.Length);
			}
			return false;
		}

		[Token(Token = "0x600023D")]
		[Address(RVA = "0xAFFC5C", Offset = "0xAFFC5C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthrow System.TypeLoadException;\n\tthrow System.TypeLoadException;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Sum(this Vector3 v)
		{
			throw new TypeLoadException();
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0xAFFCC4", Offset = "0xAFFCC4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Camera::WorldToViewportPoint(cam, point);\n\tv39 = v13.y < 0;\n\tif (v39) goto L_0052;\n\tv50 = v13 < 0;\n\tif (v50) goto L_0052;\n\tv120 = v13 < 1f;\n\tv70 = ~v120;\n\tv68 = v13 - 1f;\n\tv64 = v68 == 0;\n\tv121 = ~v64;\n\tv54 = v70 & v121;\n\tif (v54) goto L_0052;\n\tv122 = v13.y < 1f;\n\tv123 = ~v122;\n\tv124 = v13.y - 1f;\n\tv126 = v124 == 0;\n\tv131 = ~v123;\n\tv132 = v131 | v126;\n\tv104 = v13.z < 0;\n\tv95 = v13.z ^ v13.z;\n\tv92 = v13.z & v95;\n\tv89 = v92 < 0;\n\tv86 = v104 == v89;\n\treturnVal3 = v132 & v86;\n\treturn returnVal3;\nL_0052:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool InFrustum(this Camera cam, Vector3 point)
		{
			//IL_0152: Expected O, but got F4
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected I4, but got Unknown
			Vector3 vector = cam.WorldToViewportPoint(point);
			if (!(vector.y < 0f) && !(vector.x < 0f))
			{
				bool flag = vector.x < 1f;
				bool flag2 = !flag;
				float num = vector.x - 1f;
				bool flag3 = num == 0f;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					bool flag5 = vector.y < 1f;
					bool flag6 = !flag5;
					float num2 = vector.y - 1f;
					bool flag7 = num2 == 0f;
					bool flag8 = !flag6;
					bool flag9 = flag8 || flag7;
					bool flag10 = vector.z < 0f;
					object obj = vector.z ^ vector.z;
					int num3 = vector.z & (long)(IntPtr)obj;
					bool flag11 = num3 < 0;
					bool flag12 = flag10 == flag11;
					return flag9 && flag12;
				}
			}
			return false;
		}
	}
}
