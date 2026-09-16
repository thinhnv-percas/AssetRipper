using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Mycom.Tracker.Unity.Internal.Interfaces;

namespace Mycom.Tracker.Unity.Internal.Implementations.Fake
{
	[Token(Token = "0x200000D")]
	internal sealed class TrackerParams : ITrackerParams, IDisposable
	{
		[Token(Token = "0x6000097")]
		[Address(RVA = "0x1622B20", Offset = "0x1622B20", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Dispose()
		{
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x1622B24", Offset = "0x1622B24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetAge()
		{
			return 0;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x1622B2C", Offset = "0x1622B2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetBufferingPeriod()
		{
			return 0;
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x1622B34", Offset = "0x1622B34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetCustomUserIds()
		{
			return null;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x1622B3C", Offset = "0x1622B3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetEmails()
		{
			return null;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x1622B44", Offset = "0x1622B44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetForcingPeriod()
		{
			return 0;
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x1622B4C", Offset = "0x1622B4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xFFFF;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GenderEnum GetGender()
		{
			return GenderEnum.Unspecified;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x1622B54", Offset = "0x1622B54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetIcqIds()
		{
			return null;
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x1622B5C", Offset = "0x1622B5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetId()
		{
			return null;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x1622B64", Offset = "0x1622B64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetLang()
		{
			return null;
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x1622B6C", Offset = "0x1622B6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetLaunchTimeout()
		{
			return 0;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x1622B74", Offset = "0x1622B74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMrgsAppId()
		{
			return null;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x1622B7C", Offset = "0x1622B7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMrgsId()
		{
			return null;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x1622B84", Offset = "0x1622B84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMrgsUserId()
		{
			return null;
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x1622B8C", Offset = "0x1622B8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetOkIds()
		{
			return null;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x1622B94", Offset = "0x1622B94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetPhones()
		{
			return null;
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x1622B9C", Offset = "0x1622B9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string[] GetVkIds()
		{
			return null;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x1622BA4", Offset = "0x1622BA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsTrackingEnvironmentEnabled()
		{
			return false;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x1622BAC", Offset = "0x1622BAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsTrackingLaunchEnabled()
		{
			return false;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x1622BB4", Offset = "0x1622BB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsTrackingLocationEnabled()
		{
			return false;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x1622BBC", Offset = "0x1622BBC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetAge(int value)
		{
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x1622BC0", Offset = "0x1622BC0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetBufferingPeriod(int value)
		{
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x1622BC4", Offset = "0x1622BC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetCustomUserIds(string[] value)
		{
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x1622BC8", Offset = "0x1622BC8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEmails(string[] value)
		{
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x1622BCC", Offset = "0x1622BCC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetForcingPeriod(int value)
		{
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x1622BD0", Offset = "0x1622BD0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetGender(GenderEnum value)
		{
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x1622BD4", Offset = "0x1622BD4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetIcqIds(string[] value)
		{
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x1622BD8", Offset = "0x1622BD8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetLang(string value)
		{
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x1622BDC", Offset = "0x1622BDC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetLaunchTimeout(int value)
		{
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x1622BE0", Offset = "0x1622BE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetMrgsAppId(string value)
		{
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x1622BE4", Offset = "0x1622BE4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetMrgsId(string value)
		{
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x1622BE8", Offset = "0x1622BE8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetMrgsUserId(string value)
		{
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x1622BEC", Offset = "0x1622BEC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetOkIds(string[] value)
		{
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x1622BF0", Offset = "0x1622BF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetPhones(string[] value)
		{
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x1622BF4", Offset = "0x1622BF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetProxyHost(string value)
		{
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x1622BF8", Offset = "0x1622BF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetRegion(RegionEnum value)
		{
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x1622BFC", Offset = "0x1622BFC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetTrackingEnvironmentEnabled(bool value)
		{
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x1622C00", Offset = "0x1622C00", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetTrackingLaunchEnabled(bool value)
		{
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x1622C04", Offset = "0x1622C04", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetTrackingLocationEnabled(bool value)
		{
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x1622C08", Offset = "0x1622C08", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetVkIds(string[] value)
		{
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x1622A44", Offset = "0x1622A44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TrackerParams()
		{
		}
	}
}
