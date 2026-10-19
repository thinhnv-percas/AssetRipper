using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.TimeSystems.Core
{
	[Token(Token = "0x200002D")]
	public static class ServerTimeUtility
	{
		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x3C6743C", Offset = "0x3C6743C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001A:\n\tv46 = System.DateTime::get_UtcNow();\n\tv51 = System.DateTime::get_Date(&v49 @ stack_-28_v2 (System.DateTime));\n\tv52 = v51;\n\tv56 = System.DateTime::AddDays(&v52 @ stack_-30_v1 (System.DateTime), 1d);\n\treturnVal1 = System.DateTime::op_Subtraction(v56, v49);\n\treturn returnVal1;\nL_0017:\n\tgoto L_001A;\n")]
		public static TimeSpan GetNetworkRemainedToNextDay()
		{
			DateTime utcNow = DateTime.UtcNow;
			DateTime dateTime = default(DateTime);
			DateTime date = dateTime.Date;
			DateTime dateTime2 = date;
			DateTime dateTime3 = dateTime2.AddDays(1.0);
			return dateTime3 - dateTime;
		}
	}
}
