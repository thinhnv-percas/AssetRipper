using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.Notifications
{
	[Token(Token = "0x2000022")]
	public abstract class NotificationScheduler
	{
		[Token(Token = "0x400007B")]
		private static readonly TimeSpan[] NotificationTimes;

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x81BDFB0", Offset = "0x81BDFB0", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_002B:\n\tv67 = System.DateTime::get_Now();\n\tv70 = v67;\n\tv74 = System.DateTime::AddSeconds(&v70 @ stack_-60_v1 (System.DateTime), delayInSeconds);\n\tv75 = v74;\n\tv78 = System.DateTime::get_TimeOfDay(&v75 @ stack_-58_v2 (System.DateTime));\n\tgoto L_003E;\n\tgoto L_004E;\nL_004E:\n\tv202 = System.TimeSpan::op_LessThan(v78, &v88[0]);\n\tv205 = v202 == 0;\n\tif (v205) goto L_0060;\n\tgoto L_00C2;\nL_0060:\n\tgoto L_0064;\n\tgoto L_007B;\nL_007B:\n\tv304 = System.TimeSpan::op_GreaterThanOrEqual(v78, &v162[4]);\n\tv308 = ~v304;\n\tif (v308) goto L_008C;\n\tgoto L_00C2;\nL_008C:\n\tgoto L_0090;\n\tv278 = v93.Length < 1;\n\tif (v278) goto L_00C2;\n\tv275 = v93 + 0x20;\n\tv359 = 0;\nL_00AC:\n\tv303 = System.TimeSpan::op_LessThan(v78, *([v275 @ X26_v6+v359 @ X25_v7 (System.Int32)*8]));\n\tv409 = ~v303;\n\tv307 = ~v409;\n\tif (v307) goto L_0100;\n\tv359 = v359 + 1;\n\tv277 = v359 < v93.Length;\n\tif (v277) goto L_00A2;\nL_00C2:\n\tgoto L_00C6;\nL_00C6:\n\tv327 = System.DateTime::get_Date(&v75 @ stack_-58_v2 (System.DateTime));\n\tv70 = v327;\n\tv332 = System.DateTime::AddDays(&v70 @ stack_-60_v1 (System.DateTime), 1d);\n\tv70 = v332;\n\tgoto L_00D5;\n\tv370 = *([v164 @ X8_v16 (System.TimeSpan[])+20]);\n\tv374 = &v70 @ stack_-60_v1 (System.DateTime);\n\tv217 = v391;\n\tgoto L_00EF;\nL_00EF:\n\treturnVal2 = System.TimeSpan::get_TotalSeconds(&v217 @ stack_-68_v2 (System.TimeSpan));\n\treturn returnVal2;\nL_0100:\n\tgoto L_0104;\nL_0104:\n\tv418 = System.DateTime::get_Date(&v75 @ stack_-58_v2 (System.DateTime));\n\tv70 = v418;\n\tv370 = *([v275 @ X26_v6+v359 @ X25_v7 (System.Int32)*8]);\n\tv374 = &v70 @ stack_-60_v1 (System.DateTime);\n\tgoto L_00DE;\nL_0028:\n\tgoto L_002B;\nL_003E:\n\tv88 = v87.NotificationTimes;\nL_0064:\n\tv162 = v322.NotificationTimes;\nL_0090:\n\tv93 = v163.NotificationTimes;\nL_00A2:\n\t;\n\tgoto L_00AC;\nL_00D5:\n\tv164 = v343.NotificationTimes;\nL_00DE:\n\tv382 = System.DateTime::Add(v374, v370);\n\tv387 = System.DateTime::get_Now();\n\tv391 = System.DateTime::op_Subtraction(v382, v387);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static double ScheduleNotification(int delayInSeconds)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotificationScheduler::ScheduleNotification");
			return default;
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x81BE2A0", Offset = "0x81BE2A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected NotificationScheduler()
		{
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x81BE2A8", Offset = "0x81BE2A8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_0029:\n\tv63 = System.TimeSpan::FromHours(8.00000000023283d);\n\t*([v48 @ X0_v3 (System.TimeSpan[])+20]) = v63;\n\tv105 = System.TimeSpan::FromHours(8.000000000931323d);\n\t*([v48 @ X0_v3 (System.TimeSpan[])+28]) = v105;\n\tv136 = System.TimeSpan::FromHours(8.000000001629815d);\n\t*([v48 @ X0_v3 (System.TimeSpan[])+30]) = v136;\n\tv137 = System.TimeSpan::FromHours(16.00000000046566d);\n\t*([v48 @ X0_v3 (System.TimeSpan[])+38]) = v137;\n\tv138 = System.TimeSpan::FromHours(16.000000001164153d);\n\t*([v48 @ X0_v3 (System.TimeSpan[])+40]) = v138;\n\tv183.NotificationTimes = v48;\n\treturn;\nL_001F:\n\t// 31 NewArr v48 @ X0_v3 (System.TimeSpan[]), typeof(System.TimeSpan[]), 5\n\tgoto L_0029;\n")]
		static NotificationScheduler()
		{
			TimeSpan[] notificationTimes = new TimeSpan[5];
			TimeSpan timeSpan = TimeSpan.FromHours(8.00000000023283);
			TimeSpan timeSpan2 = TimeSpan.FromHours(8.000000000931323);
			TimeSpan timeSpan3 = TimeSpan.FromHours(8.000000001629815);
			TimeSpan timeSpan4 = TimeSpan.FromHours(16.00000000046566);
			TimeSpan timeSpan5 = TimeSpan.FromHours(16.000000001164153);
			NotificationTimes = notificationTimes;
		}
	}
}
