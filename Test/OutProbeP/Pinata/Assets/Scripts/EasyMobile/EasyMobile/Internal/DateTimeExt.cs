using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C4")]
	public static class DateTimeExt
	{
		[Token(Token = "0x600071F")]
		[Address(RVA = "0xBFB61C", Offset = "0xBFB61C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-8]) = minuend;\n\tminuend = &v5 @ stack_-10_v2 - 8;\n\tminuend = 0xE95E98(minuend, 0, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\tminuend = 0xE95E98(&subtrahend @ X1 (System.DateTime), 0, methodInfo, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\treturnVal1 = 0xE95DA0(&minuend @ X0 (System.DateTime), minuend, 0, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TimeSpan SameTimeZoneSubtract(this DateTime minuend, DateTime subtrahend)
		{
			//IL_001c: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			DateTime dateTime = (DateTime)((long)(IntPtr)obj2 - 8L);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E95E98 (inside System.DateTime::ParseExact +0x1D0)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E95E98 (inside System.DateTime::ParseExact +0x1D0)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E95DA0 (inside System.DateTime::ParseExact +0xD8)");
			TimeSpan result = default(TimeSpan);
			return result;
		}
	}
}
