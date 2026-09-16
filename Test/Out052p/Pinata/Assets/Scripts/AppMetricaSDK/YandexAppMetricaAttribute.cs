using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000006")]
public abstract class YandexAppMetricaAttribute
{
	[Token(Token = "0x6000038")]
	[Address(RVA = "0x15C1148", Offset = "0x15C1148", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EBF3C0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029950]) = v35;\nL_0014:\n\tv39 = new YandexAppMetricaBirthDateAttribute();\n\tSystem.Object::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaBirthDateAttribute BirthDate()
	{
		return new YandexAppMetricaBirthDateAttribute();
	}

	[Token(Token = "0x6000039")]
	[Address(RVA = "0x15C11AC", Offset = "0x15C11AC", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EEC4B0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029951]) = v35;\nL_0014:\n\tv39 = new YandexAppMetricaGenderAttribute();\n\tSystem.Object::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaGenderAttribute Gender()
	{
		return new YandexAppMetricaGenderAttribute();
	}

	[Token(Token = "0x600003A")]
	[Address(RVA = "0x15C1210", Offset = "0x15C1210", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC79A0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029952]) = v35;\nL_0014:\n\tv39 = new YandexAppMetricaNameAttribute();\n\tSystem.Object::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaNameAttribute Name()
	{
		return new YandexAppMetricaNameAttribute();
	}

	[Token(Token = "0x600003B")]
	[Address(RVA = "0x15C1274", Offset = "0x15C1274", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC11C0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029953]) = v35;\nL_0014:\n\tv39 = new YandexAppMetricaNotificationsEnabledAttribute();\n\tSystem.Object::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaNotificationsEnabledAttribute NotificationsEnabled()
	{
		return new YandexAppMetricaNotificationsEnabledAttribute();
	}

	[Token(Token = "0x600003C")]
	[Address(RVA = "0x15C12D8", Offset = "0x15C12D8", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF7090]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029954]) = v38;\nL_0016:\n\tv42 = new YandexAppMetricaBooleanAttribute();\n\tSystem.Object::.ctor(v42);\n\tv42.Key = key;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaBooleanAttribute CustomBoolean(string key)
	{
		YandexAppMetricaBooleanAttribute yandexAppMetricaBooleanAttribute = null;
		yandexAppMetricaBooleanAttribute.Key = key;
		return yandexAppMetricaBooleanAttribute;
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0x15C1368", Offset = "0x15C1368", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECFF88]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029955]) = v38;\nL_0016:\n\tv42 = new YandexAppMetricaCounterAttribute();\n\tSystem.Object::.ctor(v42);\n\tv42.Key = key;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaCounterAttribute CustomCounter(string key)
	{
		YandexAppMetricaCounterAttribute yandexAppMetricaCounterAttribute = null;
		yandexAppMetricaCounterAttribute.Key = key;
		return yandexAppMetricaCounterAttribute;
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0x15C13F8", Offset = "0x15C13F8", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE8D40]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029956]) = v38;\nL_0016:\n\tv42 = new YandexAppMetricaNumberAttribute();\n\tSystem.Object::.ctor(v42);\n\tv42.Key = key;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaNumberAttribute CustomNumber(string key)
	{
		YandexAppMetricaNumberAttribute yandexAppMetricaNumberAttribute = null;
		yandexAppMetricaNumberAttribute.Key = key;
		return yandexAppMetricaNumberAttribute;
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0x15C1488", Offset = "0x15C1488", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0DAD0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029957]) = v38;\nL_0016:\n\tv42 = new YandexAppMetricaStringAttribute();\n\tSystem.Object::.ctor(v42);\n\tv42.Key = key;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static YandexAppMetricaStringAttribute CustomString(string key)
	{
		YandexAppMetricaStringAttribute yandexAppMetricaStringAttribute = null;
		yandexAppMetricaStringAttribute.Key = key;
		return yandexAppMetricaStringAttribute;
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x15C1518", Offset = "0x15C1518", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected YandexAppMetricaAttribute()
	{
	}
}
