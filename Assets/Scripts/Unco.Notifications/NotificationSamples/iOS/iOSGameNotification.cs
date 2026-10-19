using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Notifications.iOS;
using UnityEngine;
using _game.Scripts.Notifications;

namespace NotificationSamples.iOS
{
	[Token(Token = "0x2000004")]
	public class iOSGameNotification : IGameNotification
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		internal readonly iOSNotification internalNotification;

		[Token(Token = "0x17000001")]
		public iOSNotification InternalNotification
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x81B22BC", Offset = "0x81B22BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.InternalNotification;\n")]
			get
			{
				return internalNotification;
			}
		}

		[Token(Token = "0x17000002")]
		[field: Token(Token = "0x4000007")]
		[field: FieldOffset(Offset = "0x18")]
		public IGameNotification.GameNotificationType? Type
		{
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x81B22C4", Offset = "0x81B22C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Type;\n")]
			get;
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x81B22CC", Offset = "0x81B22CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Type = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000003")]
		public int? Id
		{
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x81B22D4", Offset = "0x81B22D4", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv46 = Unity.Notifications.iOS.iOSNotification::get_Identifier(this.InternalNotification);\n\tv53 = System.Int32::TryParse(v46, &v51 @ stack_-2C_v2 (System.Int32));\n\tv55 = v53 == 0;\n\tif (v55) goto L_0038;\n\tSystem.Nullable`1<System.Int32>::.ctor(&v60 @ stack_-28_v2 (System.Nullable`1<System.Int32>), v51);\n\treturn v60;\nL_0038:\n\tgoto L_003E;\nL_003E:\n\tUnityEngine.Debug::LogWarning(\"Internal iOS notification's identifier isn't a number.\");\n\treturn 0;\n")]
			get
			{
				string identifier = InternalNotification.Identifier;
				if (int.TryParse(identifier, out var result))
				{
					return result;
				}
				Debug.LogWarning("Internal iOS notification's identifier isn't a number.");
				return null;
			}
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x81B23B8", Offset = "0x81B23B8", Length = "0xEC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = value;\n\tgoto L_0019;\n\tv54 = System.Nullable`1<System.Int32>::get_Value(&v18 @ stack_-38_v1 (System.Nullable`1<System.Int32>));\n\tv58 = v54;\n\tv61 = System.Int32::ToString(&v58 @ stack_-3C_v2 (System.Int32));\n\tUnity.Notifications.iOS.iOSNotification::set_Identifier(this.InternalNotification, v61);\n\treturn;\nL_0035:\n\tv56 = 0xB28B000 + 0x600;\n\tv62 = new v56();\n\tv66 = 0xB312000 + 0x1F0;\n\tSystem.ArgumentNullException::.ctor(v62, v66);\n\tthrow v62;\nL_0019:\n\tv45 = value & 1;\n\tv46 = v45 == 0;\n\tif (v46) goto L_0035;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSGameNotification::set_Id");
			}
		}

		[Token(Token = "0x17000004")]
		public string Title
		{
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x81B24A4", Offset = "0x81B24A4", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unity.Notifications.iOS.iOSNotification::get_Title(this.InternalNotification);\n\treturn returnVal1;\n")]
			get
			{
				return InternalNotification.Title;
			}
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x81B24C0", Offset = "0x81B24C0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnity.Notifications.iOS.iOSNotification::set_Title(this.InternalNotification, value);\n\treturn;\n")]
			set
			{
				InternalNotification.Title = value;
			}
		}

		[Token(Token = "0x17000005")]
		public string Body
		{
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x81B24DC", Offset = "0x81B24DC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unity.Notifications.iOS.iOSNotification::get_Body(this.InternalNotification);\n\treturn returnVal1;\n")]
			get
			{
				return InternalNotification.Body;
			}
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x81B24F8", Offset = "0x81B24F8", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnity.Notifications.iOS.iOSNotification::set_Body(this.InternalNotification, value);\n\treturn;\n")]
			set
			{
				InternalNotification.Body = value;
			}
		}

		[Token(Token = "0x17000006")]
		public string Subtitle
		{
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x81B2514", Offset = "0x81B2514", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unity.Notifications.iOS.iOSNotification::get_Subtitle(this.InternalNotification);\n\treturn returnVal1;\n")]
			get
			{
				return InternalNotification.Subtitle;
			}
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x81B2530", Offset = "0x81B2530", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnity.Notifications.iOS.iOSNotification::set_Subtitle(this.InternalNotification, value);\n\treturn;\n")]
			set
			{
				InternalNotification.Subtitle = value;
			}
		}

		[Token(Token = "0x17000007")]
		public string Data
		{
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x81B254C", Offset = "0x81B254C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unity.Notifications.iOS.iOSNotification::get_Data(this.InternalNotification);\n\treturn returnVal1;\n")]
			get
			{
				return InternalNotification.Data;
			}
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x81B2568", Offset = "0x81B2568", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnity.Notifications.iOS.iOSNotification::set_Data(this.InternalNotification, value);\n\treturn;\n")]
			set
			{
				InternalNotification.Data = value;
			}
		}

		[Token(Token = "0x17000008")]
		[field: Token(Token = "0x4000008")]
		[field: FieldOffset(Offset = "0x20")]
		public string notification_id
		{
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x81B2584", Offset = "0x81B2584", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.notification_id;\n")]
			get;
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x81B258C", Offset = "0x81B258C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.notification_id = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000009")]
		[field: Token(Token = "0x4000009")]
		[field: FieldOffset(Offset = "0x28")]
		public string message_id
		{
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x81B2594", Offset = "0x81B2594", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.message_id;\n")]
			get;
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x81B259C", Offset = "0x81B259C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.message_id = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x1700000A")]
		[field: Token(Token = "0x400000A")]
		[field: FieldOffset(Offset = "0x30")]
		public string job_id
		{
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x81B25A4", Offset = "0x81B25A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.job_id;\n")]
			get;
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x81B25AC", Offset = "0x81B25AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.job_id = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x1700000B")]
		[field: Token(Token = "0x400000B")]
		[field: FieldOffset(Offset = "0x38")]
		public string scheduled_at
		{
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x81B25B4", Offset = "0x81B25B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scheduled_at;\n")]
			get;
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x81B25BC", Offset = "0x81B25BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scheduled_at = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x1700000C")]
		public string Group
		{
			[Token(Token = "0x6000018")]
			[Address(RVA = "0x81B25C4", Offset = "0x81B25C4", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unity.Notifications.iOS.iOSNotification::get_CategoryIdentifier(this.InternalNotification);\n\treturn returnVal1;\n")]
			get
			{
				return InternalNotification.CategoryIdentifier;
			}
			[Token(Token = "0x6000019")]
			[Address(RVA = "0x81B25FC", Offset = "0x81B25FC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnity.Notifications.iOS.iOSNotification::set_CategoryIdentifier(this.InternalNotification, value);\n\treturn;\n")]
			set
			{
				InternalNotification.CategoryIdentifier = value;
			}
		}

		[Token(Token = "0x1700000D")]
		public int? BadgeNumber
		{
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x81B2634", Offset = "0x81B2634", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = Unity.Notifications.iOS.iOSNotification::get_Badge(this.InternalNotification);\n\tv55 = v41 == -1;\n\tif (v55) goto L_003B;\n\tv108 = Unity.Notifications.iOS.iOSNotification::get_Badge(this.InternalNotification);\n\tSystem.Nullable`1<System.Int32>::.ctor(&v84 @ stack_-28_v2 (System.Nullable`1<System.Int32>), v108);\n\treturn v84;\nL_003B:\n\treturn 0;\n")]
			get
			{
				int badge = InternalNotification.Badge;
				if (badge != -1)
				{
					return InternalNotification.Badge;
				}
				return null;
			}
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x81B26D8", Offset = "0x81B26D8", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv48 = value >> 0x20;\n\tv49 = value & 1;\n\tv51 = v49 == 0;\n\tv54 = ~v51;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv59 = v48;\n\tgoto L_0030;\nL_FFFFFFFF:\n\tv59 = -1;\nL_0030:\n\tUnity.Notifications.iOS.iOSNotification::set_Badge(this.InternalNotification, v59);\n\treturn;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSGameNotification::set_BadgeNumber");
			}
		}

		[Token(Token = "0x1700000E")]
		[field: Token(Token = "0x400000C")]
		[field: FieldOffset(Offset = "0x40")]
		public bool ShouldAutoCancel
		{
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x81B2748", Offset = "0x81B2748", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ShouldAutoCancel;\n")]
			get;
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x81B2750", Offset = "0x81B2750", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ShouldAutoCancel = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x1700000F")]
		[field: Token(Token = "0x400000D")]
		[field: FieldOffset(Offset = "0x41")]
		public bool Scheduled
		{
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x81B2758", Offset = "0x81B2758", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Scheduled;\n")]
			get;
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x81B2760", Offset = "0x81B2760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Scheduled = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000010")]
		public DateTime? DeliveryTime
		{
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x81B2768", Offset = "0x81B2768", Length = "0x2B4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv58 = Unity.Notifications.iOS.iOSNotification::get_Trigger(this.InternalNotification);\n\tv63 = v58 == 0;\n\tif (v63) goto L_003C;\n\tv111 = *([v58 @ X0_v6 (Unity.Notifications.iOS.iOSNotificationTrigger)]) == Unity.Notifications.iOS.iOSNotificationCalendarTrigger;\n\tif (v111) goto L_FFFFFFFF;\nL_003C:\n\tgoto L_0111;\nL_FFFFFFFF:\n\t// -1 IsInst v66_asT @ TEMPCOND_v3 (Unity.Notifications.iOS.iOSNotificationCalendarTrigger), typeof(Unity.Notifications.iOS.iOSNotificationCalendarTrigger), v58 @ X0_v6 (Unity.Notifications.iOS.iOSNotificationTrigger)\n\tv66 = v66_asT == 0;\n\tif (v66) goto L_0113;\n\tv243 = \"il2cpp_vm_object_unbox\"(v58, Unity.Notifications.iOS.iOSNotificationCalendarTrigger, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0059;\nL_0059:\n\tv256 = System.DateTime::get_Now();\n\tv259 = *([v243 @ X0_v9]) & 1;\n\tv260 = v259 == 0;\nL_FFFFFFFF:\n\tv263 = v256;\nL_FFFFFFFF:\n\tv263 = v256;\n\tif (v260) goto L_00C3;\n\tv433 = *([v243 @ X0_v9]) >> 0x20;\n\tv269 = *([v243 @ X0_v9+8]) & 1;\n\tv270 = v269 == 0;\n\tv271 = ~v270;\nL_FFFFFFFF:\n\tv193 = v433;\n\tif (v271) goto L_00CC;\nL_0067:\n\tgoto L_006B;\nL_006B:\n\tv311 = System.DateTime::get_Month(&v263 @ stack_-68_v16 (System.DateTime));\n\tv336 = *([v243 @ X0_v9+10]) & 1;\n\tv337 = v336 == 0;\n\tv316 = ~v337;\nL_FFFFFFFF:\n\tv191 = v311;\nL_FFFFFFFF:\n\tv193 = v433;\nL_FFFFFFFF:\n\tv432 = v311;\n\tif (v316) goto L_00D0;\nL_0075:\n\tgoto L_0079;\nL_0079:\n\tv344 = System.DateTime::get_Day(&v263 @ stack_-68_v16 (System.DateTime));\n\tv400 = *([v243 @ X0_v9+18]) & 1;\n\tv401 = v400 == 0;\n\tv346 = ~v401;\nL_FFFFFFFF:\n\tv427 = v344;\nL_FFFFFFFF:\n\tv432 = v191;\nL_FFFFFFFF:\n\tv433 = v193;\nL_FFFFFFFF:\n\tv163 = v344;\n\tif (v346) goto L_00D4;\nL_0083:\n\tgoto L_0087;\nL_0087:\n\tv375 = System.DateTime::get_Hour(&v263 @ stack_-68_v16 (System.DateTime));\n\tv441 = *([v243 @ X0_v9+20]) & 1;\n\tv442 = v441 == 0;\n\tv377 = ~v442;\nL_FFFFFFFF:\n\tv161 = v375;\nL_FFFFFFFF:\n\tv163 = v427;\nL_FFFFFFFF:\n\tv191 = v432;\nL_FFFFFFFF:\n\tv193 = v433;\nL_FFFFFFFF:\n\tv426 = v375;\n\tif (v377) goto L_00D8;\nL_0091:\n\tgoto L_0095;\nL_0095:\n\tv410 = System.DateTime::get_Minute(&v263 @ stack_-68_v16 (System.DateTime));\n\tv450 = *([v243 @ X0_v9+28]) & 1;\n\tv451 = v450 == 0;\n\tv412 = ~v451;\nL_FFFFFFFF:\n\tv425 = v410;\nL_FFFFFFFF:\n\tv426 = v161;\nL_FFFFFFFF:\n\tv427 = v163;\nL_FFFFFFFF:\n\tv432 = v191;\nL_FFFFFFFF:\n\tv433 = v193;\nL_FFFFFFFF:\n\tv159 = v410;\n\tif (v412) goto L_00DC;\nL_009F:\n\tgoto L_00A3;\nL_00A3:\n\tv449 = System.DateTime::get_Second(&v263 @ stack_-68_v16 (System.DateTime));\n\tv458 = *([v243 @ X0_v9+30]) & 1;\n\tv460 = v458 == 0;\n\tv464 = ~v460;\n\tif (v464) goto L_FFFFFFFF;\n\tv155 = 1 + 1;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv155 = 1;\nL_00C3:\n\tgoto L_00C7;\nL_00C7:\n\tv285 = System.DateTime::get_Year(&v263 @ stack_-68_v16 (System.DateTime));\n\tv335 = *([v243 @ X0_v9+8]) & 1;\n\tv287 = v335 == 0;\nL_FFFFFFFF:\n\tv433 = v285;\nL_FFFFFFFF:\n\tv193 = v285;\n\tif (v287) goto L_0067;\nL_00CC:\n\tv191 = *([v243 @ X0_v9+8]) >> 0x20;\n\tv302 = *([v243 @ X0_v9+10]) & 1;\n\tv303 = v302 == 0;\nL_FFFFFFFF:\n\tv432 = v191;\nL_FFFFFFFF:\n\tv433 = v193;\n\tif (v303) goto L_0075;\nL_00D0:\n\tv427 = *([v243 @ X0_v9+10]) >> 0x20;\n\tv322 = *([v243 @ X0_v9+18]) & 1;\n\tv323 = v322 == 0;\nL_FFFFFFFF:\n\tv163 = v427;\nL_FFFFFFFF:\n\tv191 = v432;\nL_FFFFFFFF:\n\tv193 = v433;\n\tif (v323) goto L_0083;\nL_00D4:\n\tv161 = *([v243 @ X0_v9+18]) >> 0x20;\n\tv351 = *([v243 @ X0_v9+20]) & 1;\n\tv352 = v351 == 0;\nL_FFFFFFFF:\n\tv426 = v161;\nL_FFFFFFFF:\n\tv427 = v163;\nL_FFFFFFFF:\n\tv432 = v191;\nL_FFFFFFFF:\n\tv433 = v193;\n\tif (v352) goto L_0091;\nL_00D8:\n\tv425 = *([v243 @ X0_v9+20]) >> 0x20;\n\tv382 = *([v243 @ X0_v9+28]) & 1;\n\tv383 = v382 == 0;\nL_FFFFFFFF:\n\tv159 = v425;\nL_FFFFFFFF:\n\tv161 = v426;\nL_FFFFFFFF:\n\tv163 = v427;\nL_FFFFFFFF:\n\tv191 = v432;\nL_FFFFFFFF:\n\tv193 = v433;\n\tif (v383) goto L_009F;\nL_00DC:\n\tv157 = *([v243 @ X0_v9+28]) >> 0x20;\n\tv417 = *([v243 @ X0_v9+30]) & 1;\n\tv419 = v417 == 0;\n\tv423 = ~v419;\n\tif (v423) goto L_FFFFFFFF;\n\tv155 = 1 + 1;\n\tgoto L_00ED;\nL_FFFFFFFF:\n\tv155 = 1;\nL_00F8:\n\tSystem.DateTime::.ctor(&v51 @ stack_-70_v1 (System.DateTime), v193, v191, v163, v161, v159, v157, v155);\n\tv497 = System.DateTime::ToLocalTime(&v51 @ stack_-70_v1 (System.DateTime));\n\tSystem.Nullable`1<System.DateTime>::.ctor(&v168 @ stack_-60_v1 (System.Nullable`1<System.DateTime>), v497);\nL_0111:\n\treturn 0;\nL_0113:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_0024:\n\tv51 = 0;\nL_FFFFFFFF:\n\tv157 = v449;\nL_FFFFFFFF:\n\tv159 = v425;\nL_FFFFFFFF:\n\tv161 = v426;\nL_FFFFFFFF:\n\tv163 = v427;\nL_FFFFFFFF:\n\tv191 = v432;\nL_FFFFFFFF:\n\tv193 = v433;\n\tgoto L_00F8;\nL_00ED:\n\tgoto L_00F8;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSGameNotification::get_DeliveryTime");
				return default;
			}
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x81B2A1C", Offset = "0x81B2A1C", Length = "0x1F8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = value;\n\tv27 = v28;\n\tgoto L_0027;\n\tv69 = System.Nullable`1<System.DateTime>::get_Value(&v26 @ stack_-60_v1 (System.Nullable`1<System.DateTime>));\n\tv123 = v69;\n\tgoto L_003E;\nL_003E:\n\tv196 = System.DateTime::ToLocalTime(&v123 @ stack_-70_v2 (System.DateTime));\n\tv120 = v196;\n\tv201 = System.DateTime::get_Year(&v120 @ stack_-68_v2 (System.DateTime));\n\tSystem.Nullable`1<System.Int32>::.ctor(&v117 @ stack_-78_v3 (System.Nullable`1<System.Int32>), v201);\n\tv208 = System.DateTime::get_Month(&v120 @ stack_-68_v2 (System.DateTime));\n\tSystem.Nullable`1<System.Int32>::.ctor(&v112 @ stack_-80_v3 (System.Nullable`1<System.Int32>), v208);\n\tv215 = System.DateTime::get_Day(&v120 @ stack_-68_v2 (System.DateTime));\n\tSystem.Nullable`1<System.Int32>::.ctor(&v107 @ stack_-88_v3 (System.Nullable`1<System.Int32>), v215);\n\tv222 = System.DateTime::get_Hour(&v120 @ stack_-68_v2 (System.DateTime));\n\tSystem.Nullable`1<System.Int32>::.ctor(&v102 @ stack_-90_v3 (System.Nullable`1<System.Int32>), v222);\n\tv229 = System.DateTime::get_Minute(&v120 @ stack_-68_v2 (System.DateTime));\n\tSystem.Nullable`1<System.Int32>::.ctor(&v97 @ stack_-98_v3 (System.Nullable`1<System.Int32>), v229);\n\tv236 = System.DateTime::get_Second(&v120 @ stack_-68_v2 (System.DateTime));\n\tSystem.Nullable`1<System.Int32>::.ctor(&v92 @ stack_-A0_v3 (System.Nullable`1<System.Int32>), v236);\n\tv89 = v117;\n\t// 128 Box v241 @ X0_v28 (Unity.Notifications.iOS.iOSNotificationTrigger), typeof(Unity.Notifications.iOS.iOSNotificationCalendarTrigger), &v89 @ stack_-D8_v2 (System.Nullable`1<System.Int32>)\n\tUnity.Notifications.iOS.iOSNotification::set_Trigger(this.InternalNotification, v241);\nL_0092:\n\treturn;\nL_0027:\n\tv54 = value & 1;\n\tv55 = v54 == 0;\n\tif (v55) goto L_0092;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("iOSGameNotification::set_DeliveryTime");
			}
		}

		[Token(Token = "0x17000011")]
		public string CategoryIdentifier
		{
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x81B25E0", Offset = "0x81B25E0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unity.Notifications.iOS.iOSNotification::get_CategoryIdentifier(this.InternalNotification);\n\treturn returnVal1;\n")]
			get
			{
				return InternalNotification.CategoryIdentifier;
			}
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x81B2618", Offset = "0x81B2618", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnity.Notifications.iOS.iOSNotification::set_CategoryIdentifier(this.InternalNotification, value);\n\treturn;\n")]
			set
			{
				InternalNotification.CategoryIdentifier = value;
			}
		}

		[Token(Token = "0x17000012")]
		public string SmallIcon
		{
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x81B2C14", Offset = "0x81B2C14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x81B2C1C", Offset = "0x81B2C1C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x17000013")]
		public string LargeIcon
		{
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x81B2C20", Offset = "0x81B2C20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x81B2C28", Offset = "0x81B2C28", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x81B2C2C", Offset = "0x81B2C2C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv50 = v47 == 0;\n\tif (v50) goto L_0031;\n\tUnity.Notifications.iOS.iOSNotification::set_ShowInForeground(v47, 0);\n\tthis.InternalNotification = v47;\n\treturn;\nL_0031:\n\tthrow v47;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv47 = new Unity.Notifications.iOS.iOSNotification();\n\tUnity.Notifications.iOS.iOSNotification::.ctor(v47);\n")]
		public iOSGameNotification()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("iOSGameNotification::.ctor");
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x81B2CBC", Offset = "0x81B2CBC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.InternalNotification = internalNotification;\n\treturn;\n")]
		internal iOSGameNotification(iOSNotification internalNotification)
		{
			this.internalNotification = internalNotification;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x81B2CF0", Offset = "0x81B2CF0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Scheduled = 1;\n\treturn;\n")]
		internal void OnScheduled()
		{
			Scheduled = true;
		}
	}
}
