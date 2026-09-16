using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000016")]
public class YandexAppMetricaDummy : BaseYandexAppMetrica
{
	[Token(Token = "0x1700001B")]
	public override string LibraryVersion
	{
		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x15C2344", Offset = "0x15C2344", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700001C")]
	public override int LibraryApiLevel
	{
		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x15C234C", Offset = "0x15C234C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return 0;
		}
	}

	[Token(Token = "0x60000A7")]
	[Address(RVA = "0x15C2324", Offset = "0x15C2324", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void ActivateWithConfiguration(YandexAppMetricaConfig config)
	{
	}

	[Token(Token = "0x60000A8")]
	[Address(RVA = "0x15C2328", Offset = "0x15C2328", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void ResumeSession()
	{
	}

	[Token(Token = "0x60000A9")]
	[Address(RVA = "0x15C232C", Offset = "0x15C232C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void PauseSession()
	{
	}

	[Token(Token = "0x60000AA")]
	[Address(RVA = "0x15C2330", Offset = "0x15C2330", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void ReportEvent(string message)
	{
	}

	[Token(Token = "0x60000AB")]
	[Address(RVA = "0x15C2334", Offset = "0x15C2334", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void ReportEvent(string message, Dictionary<string, object> parameters)
	{
	}

	[Token(Token = "0x60000AC")]
	[Address(RVA = "0x15C2338", Offset = "0x15C2338", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void ReportError(string condition, string stackTrace)
	{
	}

	[Token(Token = "0x60000AD")]
	[Address(RVA = "0x15C233C", Offset = "0x15C233C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void SetLocationTracking(bool enabled)
	{
	}

	[Token(Token = "0x60000AE")]
	[Address(RVA = "0x15C2340", Offset = "0x15C2340", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void SetLocation(YandexAppMetricaConfig.Coordinates? coordinates)
	{
	}

	[Token(Token = "0x60000B1")]
	[Address(RVA = "0x15C2354", Offset = "0x15C2354", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void SetUserProfileID(string userProfileID)
	{
	}

	[Token(Token = "0x60000B2")]
	[Address(RVA = "0x15C2358", Offset = "0x15C2358", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void ReportUserProfile(YandexAppMetricaUserProfile userProfile)
	{
	}

	[Token(Token = "0x60000B3")]
	[Address(RVA = "0x15C235C", Offset = "0x15C235C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void ReportRevenue(YandexAppMetricaRevenue revenue)
	{
	}

	[Token(Token = "0x60000B4")]
	[Address(RVA = "0x15C2360", Offset = "0x15C2360", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void SetStatisticsSending(bool enabled)
	{
	}

	[Token(Token = "0x60000B5")]
	[Address(RVA = "0x15C2364", Offset = "0x15C2364", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void SendEventsBuffer()
	{
	}

	[Token(Token = "0x60000B6")]
	[Address(RVA = "0x15C2368", Offset = "0x15C2368", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public override void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action)
	{
	}

	[Token(Token = "0x60000B7")]
	[Address(RVA = "0x15BAA50", Offset = "0x15BAA50", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaDummy()
	{
	}
}
