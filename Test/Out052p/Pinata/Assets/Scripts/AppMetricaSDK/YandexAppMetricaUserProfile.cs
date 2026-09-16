using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000F")]
public class YandexAppMetricaUserProfile
{
	[Token(Token = "0x400001C")]
	[FieldOffset(Offset = "0x10")]
	private readonly List<YandexAppMetricaUserProfileUpdate> Updates;

	[Token(Token = "0x600005F")]
	[Address(RVA = "0x15C2830", Offset = "0x15C2830", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE39A8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202997B]) = v38;\nL_0017:\n\tv43 = new System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>();\n\tSystem.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>::.ctor(v43, this.Updates);\n\treturn v43;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public List<YandexAppMetricaUserProfileUpdate> GetUserProfileUpdates()
	{
		//IL_0010: Expected I4, but got O
		return new List<YandexAppMetricaUserProfileUpdate>((int)Updates);
	}

	[Token(Token = "0x6000060")]
	[Address(RVA = "0x15C3D10", Offset = "0x15C3D10", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBFAE8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, update, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202997C]) = v41;\nL_0018:\n\tv45 = update.<AttributeName>k__BackingField;\n\tSystem.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>::Add(this.Updates, &v45 @ V0_v2 (System.String));\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe YandexAppMetricaUserProfile Apply(YandexAppMetricaUserProfileUpdate update)
	{
		//IL_0014: Expected O, but got Ref
		string attributeName = update.AttributeName;
		Updates.Add((YandexAppMetricaUserProfileUpdate)(&attributeName));
		return this;
	}

	[Token(Token = "0x6000061")]
	[Address(RVA = "0x15C3DA0", Offset = "0x15C3DA0", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EA5B48]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, updates, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202997D]) = v41;\nL_001C:\n\tSystem.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>::AddRange(this.Updates, updates);\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaUserProfile ApplyFromArray(List<YandexAppMetricaUserProfileUpdate> updates)
	{
		Updates.AddRange(updates);
		return this;
	}

	[Token(Token = "0x6000062")]
	[Address(RVA = "0x15C3E10", Offset = "0x15C3E10", Length = "0x10B0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0BC28]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202997E]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>();\n\tSystem.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>::.ctor(v42);\n\tthis.Updates = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tX0 = *([X0]);\n\treturn;\n\t*([X0]) = X1;\n\treturn;\n\tX0 = *([X0+8]);\n\treturn;\n\t*([X0+8]) = X1;\n\treturn;\n\tX0 = *([X0+10]);\n\treturn;\n\t*([X0+10]) = X1;\n\treturn;\n\tX0 = *([X0+18]);\n\treturn;\n\t*([X0+18]) = X1;\n\treturn;\n\tUnityEngine.UDP.Analytics.AnalyticsClient::Initialize(X0, X1, X2, X3);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x15C1004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1048 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaUserProfile()
	{
		List<YandexAppMetricaUserProfileUpdate> updates = new List<YandexAppMetricaUserProfileUpdate>();
		Updates = updates;
	}
}
