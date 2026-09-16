using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200005D")]
	public static class ObiVectorMath
	{
		[Token(Token = "0x60003ED")]
		[Address(RVA = "0x1033704", Offset = "0x1033704", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = a.y * b.z;\n\tv7 = a.z * b.y;\n\tv8 = a.z * b;\n\tv9 = a * b.z;\n\tv10 = a * b.y;\n\tv11 = a.y * b;\n\tv12 = v6 - v7;\n\tv13 = v8 - v9;\n\tv14 = v10 - v11;\n\t*([x @ X0 (System.Single&)]) = v12;\n\t*([y @ X1 (System.Single&)]) = v13;\n\t*([z @ X2 (System.Single&)]) = v14;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Cross(Vector3 a, Vector3 b, ref float x, ref float y, ref float z)
		{
			//IL_00cb: Expected Ref, but got F4
			//IL_00d3: Expected Ref, but got F4
			//IL_00db: Expected Ref, but got F4
			float num = a.y * b.z;
			float num2 = a.z * b.y;
			Vector3 vector = default(Vector3);
			float num3 = a.z * vector.x;
			Vector3 vector2 = default(Vector3);
			float num4 = vector2.x * b.z;
			float num5 = vector2.x * b.y;
			float num6 = a.y * vector.x;
			float num7 = num - num2;
			float num8 = num3 - num4;
			float num9 = num5 - num6;
			ref float reference = ref *(float*)num7;
			ref float reference2 = ref *(float*)num8;
			ref float reference3 = ref *(float*)num9;
		}

		[Token(Token = "0x60003EE")]
		[Address(RVA = "0x1033738", Offset = "0x1033738", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = a.y * b.z;\n\tv7 = a.z * b.y;\n\tv8 = a.z * b;\n\tv9 = a * b.z;\n\tv10 = a * b.y;\n\tv11 = a.y * b;\n\tv12 = v6 - v7;\n\tv13 = v8 - v9;\n\tv14 = v10 - v11;\n\t*([res @ X0 (UnityEngine.Vector3&)]) = v12;\n\t*([res @ X0 (UnityEngine.Vector3&)+4]) = v13;\n\t*([res @ X0 (UnityEngine.Vector3&)+8]) = v14;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Cross(Vector3 a, Vector3 b, ref Vector3 res)
		{
			//IL_00cb: Expected Ref, but got F4
			float num = a.y * b.z;
			float num2 = a.z * b.y;
			Vector3 vector = default(Vector3);
			float num3 = a.z * vector.x;
			Vector3 vector2 = default(Vector3);
			float num4 = vector2.x * b.z;
			float num5 = vector2.x * b.y;
			float num6 = a.y * vector.x;
			float num7 = num - num2;
			float num8 = num3 - num4;
			float num9 = num5 - num6;
			ref Vector3 reference = ref *(Vector3*)num7;
		}

		[Token(Token = "0x60003EF")]
		[Address(RVA = "0x1033768", Offset = "0x1033768", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ay * bz;\n\tv3 = az * by;\n\tv6 = az * bx;\n\tv8 = ax * bz;\n\tv10 = ax * by;\n\tv11 = ay * bx;\n\tv12 = v0 - v3;\n\tv13 = v6 - v8;\n\tv14 = v10 - v11;\n\t*([x @ X0 (System.Single&)]) = v12;\n\t*([y @ X1 (System.Single&)]) = v13;\n\t*([z @ X2 (System.Single&)]) = v14;\n\treturn;\n")]
		public unsafe static void Cross(float ax, float ay, float az, float bx, float by, float bz, ref float x, ref float y, ref float z)
		{
			//IL_008f: Expected Ref, but got F4
			//IL_0097: Expected Ref, but got F4
			//IL_009f: Expected Ref, but got F4
			float num = ay * bz;
			float num2 = az * by;
			float num3 = az * bx;
			float num4 = ax * bz;
			float num5 = ax * by;
			float num6 = ay * bx;
			float num7 = num - num2;
			float num8 = num3 - num4;
			float num9 = num5 - num6;
			ref float reference = ref *(float*)num7;
			ref float reference2 = ref *(float*)num8;
			ref float reference3 = ref *(float*)num9;
		}

		[Token(Token = "0x60003F0")]
		[Address(RVA = "0x103379C", Offset = "0x103379C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = b - a;\n\tv7 = b.y - a.y;\n\tv8 = b.z - a.z;\n\t*([res @ X0 (UnityEngine.Vector3&)]) = v6;\n\t*([res @ X0 (UnityEngine.Vector3&)+4]) = v7;\n\t*([res @ X0 (UnityEngine.Vector3&)+8]) = v8;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Subtract(Vector3 a, Vector3 b, ref Vector3 res)
		{
			//IL_0053: Expected Ref, but got F4
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			float num2 = b.y - a.y;
			float num3 = b.z - a.z;
			ref Vector3 reference = ref *(Vector3*)num;
		}

		[Token(Token = "0x60003F1")]
		[Address(RVA = "0x10337B4", Offset = "0x10337B4", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = p1 * v21;\n\tv39 = p2 * v17;\n\tv40 = n2 * v21;\n\tv41 = coords * v17;\n\tv42 = p1.y * v21;\n\tv43 = p2.y * v17;\n\tv44 = v11 * v21;\n\tv45 = v7 * v17;\n\tv46 = p1.z * v21;\n\tv47 = p2.z * v17;\n\tv48 = n3 * v21;\n\tv49 = v9 * v17;\n\tv50 = v29 * v19;\n\tv51 = v25 * v19;\n\tv52 = v27 * v19;\n\tv53 = v38 + v39;\n\tv54 = v40 + v41;\n\tv55 = v42 + v43;\n\tv56 = v44 + v45;\n\tv57 = v46 + v47;\n\tv58 = v48 + v49;\n\tv59 = p3 * v19;\n\tv60 = v31 * v19;\n\tv61 = n1 * v19;\n\tv62 = v50 + v54;\n\tv63 = v51 + v56;\n\tv64 = v52 + v58;\n\tv65 = v59 + v53;\n\tv66 = v60 + v55;\n\tv67 = v61 + v57;\n\tv68 = v62 * v37;\n\tv69 = v63 * v37;\n\tv70 = v64 * v37;\n\tv71 = v65 + v68;\n\tv72 = v66 + v69;\n\tv73 = v67 + v70;\n\tres.m_value = v71;\n\t*([res @ X0 (System.Single)+4]) = v72;\n\t*([res @ X0 (System.Single)+8]) = v73;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void BarycentricInterpolation(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 n1, Vector3 n2, Vector3 n3, Vector3 coords, float height, ref Vector3 res)
		{
			//IL_0087: Expected O, but got I
			//IL_0096: Expected O, but got I
			//IL_00e1: Expected O, but got I
			//IL_00f0: Expected O, but got I
			//IL_00ff: Expected O, but got I
			//IL_010e: Expected O, but got I
			//IL_014a: Expected O, but got I
			//IL_018b: Expected O, but got I
			//IL_01bd: Expected O, but got I
			//IL_0217: Expected O, but got I
			Vector3 vector = default(Vector3);
			object obj = default(object);
			float num = vector.x * (float)obj;
			Vector3 vector2 = default(Vector3);
			object obj2 = default(object);
			float num2 = vector2.x * (float)obj2;
			Vector3 vector3 = default(Vector3);
			float num3 = vector3.x * (float)obj;
			Vector3 vector4 = default(Vector3);
			float num4 = vector4.x * (float)obj2;
			float num5 = p1.y * (float)obj;
			float num6 = p2.y * (float)obj2;
			object obj4 = default(object);
			object obj3 = (long)(IntPtr)obj4 * (long)(IntPtr)obj;
			object obj6 = default(object);
			object obj5 = (long)(IntPtr)obj6 * (long)(IntPtr)obj2;
			float num7 = p1.z * (float)obj;
			float num8 = p2.z * (float)obj2;
			Vector3 vector5 = default(Vector3);
			float num9 = vector5.x * (float)obj;
			object obj8 = default(object);
			object obj7 = (long)(IntPtr)obj8 * (long)(IntPtr)obj2;
			object obj10 = default(object);
			object obj11 = default(object);
			object obj9 = (long)(IntPtr)obj10 * (long)(IntPtr)obj11;
			object obj13 = default(object);
			object obj12 = (long)(IntPtr)obj13 * (long)(IntPtr)obj11;
			object obj15 = default(object);
			object obj14 = (long)(IntPtr)obj15 * (long)(IntPtr)obj11;
			float num10 = num + num2;
			float num11 = num3 + num4;
			float num12 = num5 + num6;
			object obj16 = (long)(IntPtr)obj3 + (long)(IntPtr)obj5;
			float num13 = num7 + num8;
			float num14 = num9 + (float)obj7;
			Vector3 vector6 = default(Vector3);
			float num15 = vector6.x * (float)obj11;
			object obj18 = default(object);
			object obj17 = (long)(IntPtr)obj18 * (long)(IntPtr)obj11;
			Vector3 vector7 = default(Vector3);
			float num16 = vector7.x * (float)obj11;
			float num17 = (float)obj9 + num11;
			object obj19 = (long)(IntPtr)obj12 + (long)(IntPtr)obj16;
			float num18 = (float)obj14 + num14;
			float num19 = num15 + num10;
			float num20 = (float)obj17 + num12;
			float num21 = num16 + num13;
			object obj20 = default(object);
			float num22 = num17 * (float)obj20;
			object obj21 = (long)(IntPtr)obj19 * (long)(IntPtr)obj20;
			float num23 = num18 * (float)obj20;
			float value = num19 + num22;
			float num24 = num20 + (float)obj21;
			float num25 = num21 + num23;
			System.Runtime.CompilerServices.Unsafe.As<Vector3, float>(ref res).m_value = value;
		}
	}
}
