using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000008")]
	public static class DOCurve
	{
		[Token(Token = "0x2000009")]
		public static class CubicBezier
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0xC05AC4", Offset = "0xC05AC4", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 1f - v7;\n\tv17 = v15 * v15;\n\tv24 = v7 * v7;\n\tv25 = v15 * 3f;\n\tv26 = v17 * 3f;\n\tv27 = v15 * v17;\n\tv28 = v24 * v7;\n\tv29 = v26 * v7;\n\tv30 = v24 * v25;\n\tv31 = startPoint * v27;\n\tv34 = startControlPoint * v29;\n\tv37 = v14 * v30;\n\tv40 = v31 + v34;\n\tv43 = endPoint * v28;\n\tv46 = v37 + v40;\n\treturnVal1 = v43 + v46;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static Vector3 GetPointOnSegment(Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, float factor)
			{
				//IL_002e: Expected O, but got I
				//IL_006c: Expected O, but got I
				object obj = default(object);
				float num = 1f - (float)obj;
				float num2 = num * num;
				object obj2 = (nint)obj * (nint)obj;
				float num3 = num * 3f;
				float num4 = num2 * 3f;
				float num5 = num * num2;
				object obj3 = (nint)obj2 * (nint)obj;
				float num6 = num4 * (float)obj;
				float num7 = (float)obj2 * num3;
				Vector3 vector = default(Vector3);
				float num8 = vector.x * num5;
				Vector3 vector2 = default(Vector3);
				float num9 = vector2.x * num6;
				object obj4 = default(object);
				float num10 = (float)obj4 * num7;
				float num11 = num8 + num9;
				Vector3 vector3 = default(Vector3);
				float num12 = vector3.x * (float)obj3;
				float num13 = num10 + num11;
				float x = num12 + num13;
				Vector3 result = default(Vector3);
				result.x = x;
				return result;
			}

			[Token(Token = "0x6000012")]
			[Address(RVA = "0xC05B5C", Offset = "0xC05B5C", Length = "0x128")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv50 = UnityEngine.Vector3[];\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, startPoint, v0, v2, startControlPoint, v3, v5, v59, v60);\n\tv63 = 1;\n\t*([1A3565A]) = v63;\nL_002A:\n\tv67 = resolution - 2;\n\tv68 = v67 < 0;\n\tv69 = v67 == 0;\n\tv70 = resolution ^ 2;\n\tv71 = resolution ^ v67;\n\tv72 = v70 & v71;\n\tv73 = v72 < 0;\n\tv75 = v68 == v73;\n\tv76 = ~v69;\n\tv77 = v75 & v76;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\t// 60 NewArr v83 @ X0_v3 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v81 @ X20_v3 (System.Int32)\n\tv154 = v83 + 0x28;\nL_005F:\n\tv157 = DG.Tweening.DOCurve+CubicBezier::GetPointOnSegment(startPoint, startControlPoint, endPoint, endControlPoint, v59);\n\tv171 = v171 + 1;\n\t*([v154 @ X23_v3-8]) = v157;\n\t*([v154 @ X23_v3-4]) = v157.y;\n\t*([v154 @ X23_v3]) = v157.z;\n\tv154 = v154 + 0xC;\n\tv191 = v81 != v171;\n\tif (v191) goto L_005F;\n\treturn v83;\n\tv166 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static Vector3[] GetSegmentPointCloud(Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, int resolution = 10)
			{
				//IL_002f: Expected O, but got I
				//IL_0067: Expected O, but got F4
				//IL_0076: Expected O, but got I
				int num = resolution - 2;
				bool flag = num < 0;
				bool flag2 = num == 0;
				int num2 = resolution ^ 2;
				int num3 = resolution ^ num;
				int num4 = num2 & num3;
				bool flag3 = num4 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				int num5 = ((!(flag4 && flag5)) ? 2 : resolution);
				Vector3[] array = new Vector3[num5];
				object obj = (nint)array + 40;
				int num6 = 0;
				float factor = default(float);
				do
				{
					Vector3 pointOnSegment = GetPointOnSegment(startPoint, startControlPoint, endPoint, endControlPoint, factor);
					num6++;
					_ = pointOnSegment.y;
					obj = pointOnSegment.z;
					obj = (nint)obj + 12;
				}
				while (num5 != num6);
				return array;
			}

			[Token(Token = "0x6000013")]
			[Address(RVA = "0xC05C84", Offset = "0xC05C84", Length = "0x150")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, resolution, methodInfo, v53, v54, v55, v56, v57, startPoint, v0, v2, startControlPoint, v3, v5, v58, v59);\n\tv62 = 1;\n\t*([1A3565B]) = v62;\nL_0028:\n\tv65 = resolution - 2;\n\tv66 = v65 < 0;\n\tv67 = v65 == 0;\n\tv68 = resolution ^ 2;\n\tv69 = resolution ^ v65;\n\tv70 = v68 & v69;\n\tv71 = v70 < 0;\n\tv73 = v66 == v71;\n\tv74 = ~v67;\n\tv75 = v73 & v74;\n\tv76 = ~v75;\n\tif (v76) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_005A:\n\tv165 = DG.Tweening.DOCurve+CubicBezier::GetPointOnSegment(startPoint, startControlPoint, endPoint, endControlPoint, v58);\n\tv178 = v60._items;\n\tv160 = v60._version + 1;\n\tv60._version = v160;\n\tv293 = v60._size < v178.Length;\n\tv294 = ~v293;\n\tif (v294) goto L_007D;\n\tv302 = v60._size + 1;\n\tv303 = v60._size * 0xC;\n\tv304 = v178 + v303;\n\tv60._size = v302;\n\t*([v304 @ X8_v11+20]) = v165;\n\tv178[v60._size (System.Int32)].y = v165.y;\n\tv178[v60._size (System.Int32)].z = v165.z;\n\tgoto L_007E;\nL_007D:\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v60, v165);\nL_007E:\n\tv180 = v180 + 1;\n\tv200 = v79 != v180;\n\tif (v200) goto L_005A;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static void GetSegmentPointCloud(List<Vector3> addToList, Vector3 startPoint, Vector3 startControlPoint, Vector3 endPoint, Vector3 endControlPoint, int resolution = 10)
			{
				//IL_0092: Expected O, but got I
				int num = resolution - 2;
				bool flag = num < 0;
				bool flag2 = num == 0;
				int num2 = resolution ^ 2;
				int num3 = resolution ^ num;
				int num4 = num2 & num3;
				bool flag3 = num4 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				int num5 = ((!(flag4 && flag5)) ? 2 : resolution);
				int num6 = 0;
				float factor = default(float);
				List<Vector3> list = default(List<Vector3>);
				do
				{
					Vector3 pointOnSegment = GetPointOnSegment(startPoint, startControlPoint, endPoint, endControlPoint, factor);
					Vector3[] items = list._items;
					int version = list._version + 1;
					list._version = version;
					if (list.Count < items.Length)
					{
						int size = list.Count + 1;
						int num7 = list.Count * 12;
						object obj = (nint)items + num7;
						list._size = size;
						items[list.Count].y = pointOnSegment.y;
						items[list.Count].z = pointOnSegment.z;
					}
					else
					{
						list.Add(pointOnSegment);
					}
					num6++;
				}
				while (num5 != num6);
			}
		}
	}
}
