using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000003")]
public abstract class BaseYandexAppMetrica : IYandexAppMetrica
{
	[Token(Token = "0x400000E")]
	[FieldOffset(Offset = "0x10")]
	private YandexAppMetricaConfig? _metricaConfig;

	[CompilerGenerated]
	[Token(Token = "0x400000F")]
	[FieldOffset(Offset = "0x78")]
	private ConfigUpdateHandler m_OnActivation;

	[Token(Token = "0x17000002")]
	public YandexAppMetricaConfig? ActivationConfig
	{
		[Token(Token = "0x600000E")]
		[Address(RVA = "0x15BB678", Offset = "0x15BB678", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0x6D2410(v4, v0, 0x68, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 16L;
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
			YandexAppMetricaConfig? result = default(YandexAppMetricaConfig?);
			return result;
		}
	}

	[Token(Token = "0x17000003")]
	public abstract string LibraryVersion
	{
		[Token(Token = "0x6000018")]
		get;
	}

	[Token(Token = "0x17000004")]
	public abstract int LibraryApiLevel
	{
		[Token(Token = "0x6000019")]
		get;
	}

	[Token(Token = "0x14000001")]
	public event ConfigUpdateHandler OnActivation
	{
		[CompilerGenerated]
		[Token(Token = "0x600000C")]
		[Address(RVA = "0x15BB530", Offset = "0x15BB530", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F09FD8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029922]) = v43;\nL_0017:\n\tv45 = this + 0x78;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != ConfigUpdateHandler;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 120L;
			Delegate obj2 = this.m_OnActivation;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(ConfigUpdateHandler))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600000D")]
		[Address(RVA = "0x15BB5D4", Offset = "0x15BB5D4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE5888]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029923]) = v43;\nL_0017:\n\tv45 = this + 0x78;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != ConfigUpdateHandler;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0078: Expected O, but got I
			object obj = (long)(IntPtr)this + 120L;
			Delegate obj2 = this.m_OnActivation;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if (obj3 != null && (object)obj3.GetType() != typeof(ConfigUpdateHandler))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj2 != obj4;
				obj2 = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x15BB688", Offset = "0x15BB688", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = 0x6D2410(&v11 @ stack_-80, config, 0x60, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tBaseYandexAppMetrica::UpdateConfiguration(this, &v11 @ stack_-80);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe virtual void ActivateWithConfiguration(YandexAppMetricaConfig config)
	{
		//IL_0019: Expected O, but got Ref
		Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
		object obj = default(object);
		UpdateConfiguration((YandexAppMetricaConfig)(&obj));
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0x15BB6C4", Offset = "0x15BB6C4", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F04C18]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, config, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029924]) = v43;\nL_0019:\n\tv48 = 0x6D2410(&v45 @ stack_-158, config, 0x60, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv53 = 0x6D26F0(&v50 @ stack_-F8 (System.Nullable`1<YandexAppMetricaConfig>), 0, 0x68, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv56 = &v13 @ stack_-10_v2 - 0x80;\n\tv60 = 0x6D2410(v56, &v45 @ stack_-158, 0x60, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv62 = &v13 @ stack_-10_v2 - 0x80;\n\tv64 = System.Nullable`1<YandexAppMetricaConfig>::.ctor(&v50 @ stack_-F8 (System.Nullable`1<YandexAppMetricaConfig>), v62);\n\tv65 = this + 0x10;\n\tv68 = 0x6D2410(v65, &v50 @ stack_-F8 (System.Nullable`1<YandexAppMetricaConfig>), 0x68, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv70 = this.OnActivation == 0;\n\tif (v70) goto L_003E;\n\tv75 = 0x6D2410(&v72 @ stack_-1B8, config, 0x60, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tConfigUpdateHandler::Invoke(this.OnActivation, &v72 @ stack_-1B8);\nL_003E:\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	internal unsafe void UpdateConfiguration(YandexAppMetricaConfig config)
	{
		//IL_00b1: Expected O, but got I
		//IL_0014: Expected O, but got I
		//IL_002d: Expected O, but got I
		//IL_007e: Expected O, but got Ref
		Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
		Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
		object obj2 = default(object);
		object obj = (long)(IntPtr)obj2 - 128L;
		Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
		YandexAppMetricaConfig value = (YandexAppMetricaConfig)((long)(IntPtr)obj2 - 128L);
		YandexAppMetricaConfig? yandexAppMetricaConfig = value;
		object obj3 = (long)(IntPtr)this + 16L;
		Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
		if (this.OnActivation != null)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
			object obj4 = default(object);
			this.OnActivation((YandexAppMetricaConfig)(&obj4));
		}
	}

	[Token(Token = "0x6000011")]
	public abstract void ResumeSession();

	[Token(Token = "0x6000012")]
	public abstract void PauseSession();

	[Token(Token = "0x6000013")]
	public abstract void ReportEvent(string message);

	[Token(Token = "0x6000014")]
	public abstract void ReportEvent(string message, Dictionary<string, object> parameters);

	[Token(Token = "0x6000015")]
	public abstract void ReportError(string condition, string stackTrace);

	[Token(Token = "0x6000016")]
	public abstract void SetLocationTracking(bool enabled);

	[Token(Token = "0x6000017")]
	public abstract void SetLocation(YandexAppMetricaConfig.Coordinates? coordinates);

	[Token(Token = "0x600001A")]
	public abstract void SetUserProfileID(string userProfileID);

	[Token(Token = "0x600001B")]
	public abstract void ReportUserProfile(YandexAppMetricaUserProfile userProfile);

	[Token(Token = "0x600001C")]
	public abstract void ReportRevenue(YandexAppMetricaRevenue revenue);

	[Token(Token = "0x600001D")]
	public abstract void SetStatisticsSending(bool enabled);

	[Token(Token = "0x600001E")]
	public abstract void SendEventsBuffer();

	[Token(Token = "0x600001F")]
	public abstract void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action);

	[Token(Token = "0x6000020")]
	[Address(RVA = "0x15BBAAC", Offset = "0x15BBAAC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected internal BaseYandexAppMetrica()
	{
	}
}
