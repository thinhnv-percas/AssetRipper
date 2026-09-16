using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000009")]
public class YandexAppMetricaCounterAttribute
{
	[Token(Token = "0x4000013")]
	private const string AttributeName = "customCounter";

	[Token(Token = "0x4000014")]
	[FieldOffset(Offset = "0x10")]
	internal readonly string Key;

	[Token(Token = "0x600004C")]
	[Address(RVA = "0x15C13CC", Offset = "0x15C13CC", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Key = key;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaCounterAttribute(string key)
	{
		Key = key;
	}

	[Token(Token = "0x600004D")]
	[Address(RVA = "0x15C1EF4", Offset = "0x15C1EF4", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1ECE0C0]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, value, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029960]) = v47;\nL_001D:\n\t// 29 NewArr v53 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 36 Box v60 @ X0_v5 (YandexAppMetricaUserProfileUpdate), typeof(System.Double), &value @ V0 (System.Double)\n\tv63 = v60 == 0;\n\tif (v63) goto L_0031;\n\t// 45 IsInst returnVal1 @ X0_v12 (YandexAppMetricaUserProfileUpdate), typeof(System.Object), v60 @ X0_v5 (YandexAppMetricaUserProfileUpdate)\nL_0031:\n\tv76 = v53.Length == 0;\n\tif (v76) goto L_0049;\n\tv53[0] = v60;\n\treturnBuffer.<Key>k__BackingField = this.Key;\n\treturnBuffer.<Values>k__BackingField = v53;\n\treturnBuffer.<AttributeName>k__BackingField = \"customCounter\";\n\treturnBuffer.<MethodName>k__BackingField = \"withDelta\";\n\treturn returnVal1;\n\tv65 = new System.NullReferenceException();\nL_0049:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004E;\n\tv95 = new System.ArrayTypeMismatchException();\nL_004E:\n\tthrow v115;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfileUpdate WithDelta(double value)
	{
		//IL_0077: Expected native int or pointer, but got O
		//IL_0084: Expected native int or pointer, but got O
		//IL_0092: Expected native int or pointer, but got O
		//IL_00a0: Expected native int or pointer, but got O
		object[] array = new object[1];
		YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate = (YandexAppMetricaUserProfileUpdate)(object)value;
		bool flag = (object)yandexAppMetricaUserProfileUpdate == null;
		YandexAppMetricaUserProfileUpdate result = yandexAppMetricaUserProfileUpdate;
		if (!flag)
		{
			result = (YandexAppMetricaUserProfileUpdate)(yandexAppMetricaUserProfileUpdate as object);
		}
		if (array.Length != 0)
		{
			array[0] = yandexAppMetricaUserProfileUpdate;
			YandexAppMetricaUserProfileUpdate yandexAppMetricaUserProfileUpdate2 = default(YandexAppMetricaUserProfileUpdate);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Key, Key);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->Values, array);
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->AttributeName, "customCounter");
			System.Runtime.CompilerServices.Unsafe.Write(&((YandexAppMetricaUserProfileUpdate*)(IntPtr)yandexAppMetricaUserProfileUpdate2)->MethodName, "withDelta");
			return result;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}
}
