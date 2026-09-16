using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000070")]
	public class FirebaseMessage
	{
		[CompilerGenerated]
		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0x10")]
		private string _003CError_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000291")]
		[FieldOffset(Offset = "0x18")]
		private string _003CPriority_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000292")]
		[FieldOffset(Offset = "0x20")]
		private string _003CMessageType_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000294")]
		[FieldOffset(Offset = "0x30")]
		private string _003CRawData_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000296")]
		[FieldOffset(Offset = "0x40")]
		private string _003CCollapseKey_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000298")]
		[FieldOffset(Offset = "0x50")]
		private string _003CFrom_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000299")]
		[FieldOffset(Offset = "0x58")]
		private Uri _003CLink_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400029A")]
		[FieldOffset(Offset = "0x60")]
		private FirebaseNotification _003CNotification_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400029B")]
		[FieldOffset(Offset = "0x68")]
		private TimeSpan _003CTimeToLive_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400029C")]
		[FieldOffset(Offset = "0x70")]
		private string _003CErrorDescription_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400029D")]
		[FieldOffset(Offset = "0x78")]
		private bool _003CNotificationOpened_003Ek__BackingField;

		[Token(Token = "0x1700017E")]
		public string Error
		{
			[CompilerGenerated]
			[Token(Token = "0x6000527")]
			[Address(RVA = "0xA56334", Offset = "0xA56334", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Error>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Error;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000528")]
			[Address(RVA = "0xA5633C", Offset = "0xA5633C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Error>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CError_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700017F")]
		public string Priority
		{
			[CompilerGenerated]
			[Token(Token = "0x6000529")]
			[Address(RVA = "0xA56344", Offset = "0xA56344", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Priority>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Priority;
			}
			[CompilerGenerated]
			[Token(Token = "0x600052A")]
			[Address(RVA = "0xA5634C", Offset = "0xA5634C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Priority>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CPriority_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000180")]
		public string MessageType
		{
			[CompilerGenerated]
			[Token(Token = "0x600052B")]
			[Address(RVA = "0xA56354", Offset = "0xA56354", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MessageType>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MessageType;
			}
			[CompilerGenerated]
			[Token(Token = "0x600052C")]
			[Address(RVA = "0xA5635C", Offset = "0xA5635C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MessageType>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMessageType_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000181")]
		public string MessageId
		{
			[CompilerGenerated]
			[Token(Token = "0x600052D")]
			[Address(RVA = "0xA56364", Offset = "0xA56364", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MessageId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MessageId;
			}
			[CompilerGenerated]
			[Token(Token = "0x600052E")]
			[Address(RVA = "0xA5636C", Offset = "0xA5636C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MessageId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				MessageId = value;
			}
		}

		[Token(Token = "0x17000182")]
		public string RawData
		{
			[CompilerGenerated]
			[Token(Token = "0x600052F")]
			[Address(RVA = "0xA56374", Offset = "0xA56374", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RawData>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RawData;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000530")]
			[Address(RVA = "0xA5637C", Offset = "0xA5637C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RawData>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CRawData_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000183")]
		public IDictionary<string, string> Data
		{
			[CompilerGenerated]
			[Token(Token = "0x6000531")]
			[Address(RVA = "0xA56384", Offset = "0xA56384", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Data>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000532")]
			[Address(RVA = "0xA5638C", Offset = "0xA5638C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Data>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Data = value;
			}
		}

		[Token(Token = "0x17000184")]
		public string CollapseKey
		{
			[CompilerGenerated]
			[Token(Token = "0x6000533")]
			[Address(RVA = "0xA56394", Offset = "0xA56394", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CollapseKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CollapseKey;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000534")]
			[Address(RVA = "0xA5639C", Offset = "0xA5639C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CollapseKey>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CCollapseKey_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000185")]
		public string To
		{
			[CompilerGenerated]
			[Token(Token = "0x6000535")]
			[Address(RVA = "0xA563A4", Offset = "0xA563A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<To>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return To;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000536")]
			[Address(RVA = "0xA563AC", Offset = "0xA563AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<To>k__BackingField = value;\n\treturn;\n")]
			set
			{
				To = value;
			}
		}

		[Token(Token = "0x17000186")]
		public string From
		{
			[CompilerGenerated]
			[Token(Token = "0x6000537")]
			[Address(RVA = "0xA563B4", Offset = "0xA563B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<From>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return From;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000538")]
			[Address(RVA = "0xA563BC", Offset = "0xA563BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<From>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CFrom_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000187")]
		public Uri Link
		{
			[CompilerGenerated]
			[Token(Token = "0x6000539")]
			[Address(RVA = "0xA563C4", Offset = "0xA563C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Link>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Link;
			}
			[CompilerGenerated]
			[Token(Token = "0x600053A")]
			[Address(RVA = "0xA563CC", Offset = "0xA563CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Link>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLink_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000188")]
		public FirebaseNotification Notification
		{
			[CompilerGenerated]
			[Token(Token = "0x600053B")]
			[Address(RVA = "0xA563D4", Offset = "0xA563D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Notification>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Notification;
			}
			[CompilerGenerated]
			[Token(Token = "0x600053C")]
			[Address(RVA = "0xA563DC", Offset = "0xA563DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Notification>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CNotification_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000189")]
		public TimeSpan TimeToLive
		{
			[CompilerGenerated]
			[Token(Token = "0x600053D")]
			[Address(RVA = "0xA563E4", Offset = "0xA563E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TimeToLive>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TimeToLive;
			}
			[CompilerGenerated]
			[Token(Token = "0x600053E")]
			[Address(RVA = "0xA563EC", Offset = "0xA563EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TimeToLive>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTimeToLive_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700018A")]
		public string ErrorDescription
		{
			[CompilerGenerated]
			[Token(Token = "0x600053F")]
			[Address(RVA = "0xA563F4", Offset = "0xA563F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ErrorDescription>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ErrorDescription;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000540")]
			[Address(RVA = "0xA563FC", Offset = "0xA563FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ErrorDescription>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CErrorDescription_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700018B")]
		public bool NotificationOpened
		{
			[CompilerGenerated]
			[Token(Token = "0x6000541")]
			[Address(RVA = "0xA56404", Offset = "0xA56404", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<NotificationOpened>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return NotificationOpened;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000542")]
			[Address(RVA = "0xA5640C", Offset = "0xA5640C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<NotificationOpened>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CNotificationOpened_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000543")]
		[Address(RVA = "0xA56418", Offset = "0xA56418", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC6698]);\n\tv27 = *([v26 @ X8_v45]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021FB0]) = v46;\nL_001A:\n\tv50 = new EasyMobile.NotificationContent();\n\tEasyMobile.NotificationContent::.ctor(v50);\n\tv53 = this.<Notification>k__BackingField;\n\tv54 = this.<Notification>k__BackingField == 0;\n\tif (v54) goto L_0038;\n\tv50.title = v53.<Title>k__BackingField;\n\tv65 = this.<Notification>k__BackingField;\n\tv50.body = v65.<Body>k__BackingField;\n\tv57 = EasyMobile.FirebaseMessage::GetNotificationContentBadge(this);\n\tv50.badge = v57;\n\tv137 = this.<Notification>k__BackingField;\n\tv50.largeIcon = v137.<Icon>k__BackingField;\n\tv138 = this.<Notification>k__BackingField;\n\tv50.smallIcon = v138.<Icon>k__BackingField;\nL_0038:\n\tv63 = this.<Data>k__BackingField == 0;\n\tif (v63) goto L_0146;\n\tv127 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v127);\n\tgoto L_0073;\n\tv300 = *([v295 @ X8_v13+B0]);\n\tv301 = 0;\n\tv302 = v300 + 8;\n\tv304 = *([v340 @ X11_v28-8]);\n\tv346 = v304 == v298;\n\tif (v346) goto L_006C;\n\tv326 = v341 + 1;\n\tv351 = v326 < v297;\n\tv322 = ~v351;\n\tv324 = v340 + 0x10;\n\tv306 = ~v322;\n\tif (v306) goto L_FFFFFFFF;\n\tv327 = v134;\n\tv328 = 0;\n\tv329 = 0x8909C4(v327, v298, v328, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0073;\nL_006C:\n\tv352 = *([v340 @ X11_v28]);\n\tv353 = v352 << 4;\n\tv354 = v295 + v353;\n\tv355 = v354 + 0x130;\nL_0073:\n\tv376 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::GetEnumerator(this.<Data>k__BackingField);\nL_0081:\n\tgoto L_00A8;\n\tv428 = *([v422 @ X8_v24+B0]);\n\tv429 = 0;\n\tv430 = v428 + 8;\n\tv432 = *([v482 @ X11_v23-8]);\n\tv488 = v432 == v423;\n\tif (v488) goto L_00A1;\n\tv454 = v483 + 1;\n\tv493 = v454 < v424;\n\tv450 = ~v493;\n\tv452 = v482 + 0x10;\n\tv434 = ~v450;\n\tif (v434) goto L_FFFFFFFF;\n\tv455 = v135;\n\tv456 = 0;\n\tv457 = 0x8909C4(v455, v423, v456, v79, v380, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A8;\nL_00A1:\n\tv494 = *([v482 @ X11_v23]);\n\tv495 = v494 << 4;\n\tv496 = v422 + v495;\n\tv497 = v496 + 0x130;\nL_00A8:\n\tv518 = System.Collections.IEnumerator::MoveNext(v376);\n\tv520 = v518 == 0;\n\tif (v520) goto L_00E4;\n\tgoto L_00D7;\n\tv531 = *([v522 @ X8_v27+B0]);\n\tv532 = 0;\n\tv533 = v531 + 8;\n\tv535 = *([v603 @ X11_v18-8]);\n\tv609 = v535 == v523;\n\tif (v609) goto L_00D0;\n\tv557 = v604 + 1;\n\tv669 = v557 < v524;\n\tv553 = ~v669;\n\tv555 = v603 + 0x10;\n\tv537 = ~v553;\n\tif (v537) goto L_FFFFFFFF;\n\tv558 = v135;\n\tv559 = 0;\n\tv560 = 0x8909C4(v558, v523, v559, v79, v380, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00D7;\nL_00D0:\n\tv670 = *([v603 @ X11_v18]);\n\tv671 = v670 << 4;\n\tv672 = v522 + v671;\n\tv673 = v672 + 0x130;\nL_00D7:\n\tv470 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Current(v376);\n\tv418 = v127 == 0;\n\tif (v418) goto L_00EB;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v127, v470, 0);\n\tgoto L_0081;\nL_00E4:\n\tv528 = v376 == 0;\n\tv529 = ~v528;\n\tif (v529) goto L_0107;\n\tgoto L_012F;\n\tthrow System.NullReferenceException;\nL_00EB:\n\tv290 = new System.NullReferenceException();\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\nL_00F9:\n\tv276 = v259 != 1;\n\tif (v276) goto L_014D;\n\tv530 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v290, v259, v387);\n\tv563 = *([v530 @ X0_v24]);\n\tv583 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v530, v259, v387);\n\tv585 = v376 == 0;\n\tif (v585) goto L_012F;\nL_0107:\n\tgoto L_012E;\n\tv639 = *([v588 @ X8_v19+B0]);\n\tv640 = 0;\n\tv641 = v639 + 8;\n\tv643 = *([v690 @ X11_v10-8]);\n\tv696 = v643 == v591;\n\tif (v696) goto L_0127;\n\tv665 = v691 + 1;\n\tv701 = v665 < v590;\n\tv661 = ~v701;\n\tv663 = v690 + 0x10;\n\tv645 = ~v661;\n\tif (v645) goto L_FFFFFFFF;\n\tv666 = v135;\n\tv667 = 0;\n\tv668 = 0x8909C4(v666, v591, v667, v79, v561, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_012E;\nL_0127:\n\tv702 = *([v690 @ X11_v10]);\n\tv703 = v702 << 4;\n\tv704 = v588 + v703;\n\tv705 = v704 + 0x130;\nL_012E:\n\tSystem.IDisposable::Dispose(v376);\nL_012F:\n\tv638 = v77 + 1;\n\tv102 = v638 == 0;\n\tv87 = ~v102;\n\tif (v87) goto L_013B;\n\tv678 = v75 == 0;\n\tv207 = ~v678;\n\tif (v207) goto L_014C;\nL_013B:\n\tv50.userInfo = v127;\nL_0146:\n\treturn v50;\n\tthrow System.NullReferenceException;\nL_014C:\n\tv213 = new System.TypeLoadException();\nL_014D:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v290, v259, v231);\n\treturn returnVal2;\n// 187 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NotificationContent ToNotificationContent()
		{
			//IL_016d: Expected I4, but got O
			//IL_01a3: Expected I4, but got O
			NotificationContent notificationContent = new NotificationContent();
			FirebaseNotification notification = Notification;
			if (Notification != null)
			{
				notificationContent.title = notification.Title;
				FirebaseNotification notification2 = Notification;
				notificationContent.body = notification2.Body;
				int notificationContentBadge = GetNotificationContentBadge();
				notificationContent.badge = notificationContentBadge;
				FirebaseNotification notification3 = Notification;
				notificationContent.largeIcon = notification3.Icon;
				FirebaseNotification notification4 = Notification;
				notificationContent.smallIcon = notification4.Icon;
			}
			if (Data != null)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				IEnumerator<KeyValuePair<string, string>> enumerator = Data.GetEnumerator();
				object obj = null;
				string text = null;
				object obj2 = default(object);
				NotificationContent result = default(NotificationContent);
				while (true)
				{
					int num;
					int num2;
					int num3;
					int num4;
					KeyValuePair<string, string> value;
					NullReferenceException ex;
					if (!enumerator.MoveNext())
					{
						bool flag = enumerator == null;
						bool flag2 = !flag;
						num = 0;
						num2 = 0;
						if (!flag2)
						{
							num3 = 0;
							num4 = 0;
							goto IL_0301;
						}
					}
					else
					{
						KeyValuePair<string, string> current = enumerator.Current;
						bool flag3 = dictionary == null;
						value = (KeyValuePair<string, string>)obj;
						if (!flag3)
						{
							dictionary.Add((string)current, null);
							obj = null;
							text = (string)current;
							continue;
						}
						ex = new NullReferenceException();
						if ((IntPtr)text != (IntPtr)1)
						{
							goto IL_021f;
						}
						((Dictionary<string, object>)(object)ex).Add(text, obj);
						num = (int)obj2;
						((Dictionary<string, object>)obj2).Add(text, obj);
						bool flag4 = enumerator == null;
						num2 = -1;
						num3 = (int)obj2;
						num4 = -1;
						if (flag4)
						{
							goto IL_0301;
						}
					}
					enumerator.Dispose();
					num3 = num;
					num4 = num2;
					goto IL_0301;
					IL_0301:
					if (num4 + 1 != 0 || num3 == 0)
					{
						break;
					}
					TypeLoadException ex2 = new TypeLoadException();
					value = default(KeyValuePair<string, string>);
					text = null;
					ex = (NullReferenceException)(object)ex2;
					goto IL_021f;
					IL_021f:
					((Dictionary<string, object>)(object)ex).Add(text, (object)value);
					return result;
				}
				notificationContent.userInfo = dictionary;
			}
			return notificationContent;
		}

		[Token(Token = "0x6000544")]
		[Address(RVA = "0xA56760", Offset = "0xA56760", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-4]) = 0;\n\tv6 = this.<Notification>k__BackingField;\n\tv9 = this.<Notification>k__BackingField == 0;\n\tif (v9) goto L_001E;\n\t*([v4 @ X29_v1-4]) = 0xFFFFFFFF;\n\tv11 = &v5 @ stack_-10_v2 - 4;\n\tv13 = System.Int32::TryParse(v6.<Badge>k__BackingField, v11);\n\tv28 = v13 == 0;\n\tv19 = ~v28;\n\tv16 = ~v19;\n\tif (v16) goto L_FFFFFFFF;\n\tgoto L_001E;\nL_001E:\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int GetNotificationContentBadge()
		{
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			FirebaseNotification notification = Notification;
			bool flag = Notification == null;
			int result = -1;
			if (!flag)
			{
				_ = 4294967295L;
				if (int.TryParse(notification.Badge, out *(int*)((long)(IntPtr)obj2 - 4L)))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1-4]");
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			return result;
		}

		[Token(Token = "0x6000545")]
		[Address(RVA = "0xA567A8", Offset = "0xA567A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FirebaseMessage()
		{
		}
	}
}
