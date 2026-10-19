using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;
using UnityEngine;
using _game.Scripts.Notifications;

namespace Unco.Notifications
{
	[CreateAssetMenu(fileName = "GameNotificationSo", menuName = "PowerSlap/Notification/GameNotificationSo")]
	[Token(Token = "0x200001B")]
	public class GameNotificationSo : ScriptableObject
	{
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x18")]
		public IGameNotification.GameNotificationType Type;

		[SerializeField]
		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x20")]
		internal List<NotificationInfo> m_infoList;

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x81B98AC", Offset = "0x81B98AC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = Unco.Notifications.GameNotificationSo::ProcessData(v46, v46.Title);\n\tv46.Title = v52;\n\tv60 = Unco.Notifications.GameNotificationSo::ProcessData(v56, v46.Body);\n\tv46.Body = v60;\n\treturn v46;\nL_0018:\n\tv46 = Unco.Extensions.ListExtension::GetRandom(this.m_infoList);\n")]
		public NotificationInfo GetNotificationInfo()
		{
			NotificationInfo random = m_infoList.GetRandom();
			string title = ((GameNotificationSo)(object)random).ProcessData(random.Title);
			random.Title = title;
			GameNotificationSo gameNotificationSo = default(GameNotificationSo);
			string body = gameNotificationSo.ProcessData(random.Body);
			random.Body = body;
			return random;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x81BA4B4", Offset = "0x81BA4B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_infoList;\n")]
		public List<NotificationInfo> GetAllNotificationInfos()
		{
			return m_infoList;
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x81BA210", Offset = "0x81BA210", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\nL_003F:\n\tv55 = System.String::Replace(text, \"[emoji_surprisebox]\", \"\ud83c\udf81\");\n\tv112 = System.String::Replace(v55, \"[emoji_zap]\", \"⚡\ufe0f\");\n\tv113 = System.String::Replace(v112, \"[emoji_warning]\", \"⚠\ufe0f\");\n\tv114 = System.String::Replace(v113, \"[emoji_shield]\", \"\ud83d\udee1\ufe0f\");\n\tv115 = System.String::Replace(v114, \"[emoji_loop]\", \"\ud83d\udd04\");\n\tv116 = System.String::Replace(v115, \"[emoji_alarmclock]\", \"⏰\");\n\tv248 = System.String::Contains(v116, 0x5B);\n\tv249 = ~v248;\n\tif (v249) goto L_00CF;\n\tv253 = System.String::Contains(v116, 0x5D);\n\tv255 = ~v253;\n\tif (v255) goto L_00CF;\n\tv117 = System.String::Split(v116, 0x5B, 0);\n\tv118 = System.String::Split(v116, 0x5D, 0);\n\tv119 = System.String::Split(v116, 0x5B, 0);\n\tv121 = System.String::Split(v119[1], 0x5D, 0);\n\tv261 = System.String::Split(v121[0], 0x2F, 0);\n\treturnVal3 = System.String::Concat(v117[0], v118[1]);\n\treturn returnVal3;\nL_00CF:\n\treturn v116;\n")]
		private string ProcessData(string text)
		{
			string text2 = text.Replace("[emoji_surprisebox]", "\ud83c\udf81");
			string text3 = text2.Replace("[emoji_zap]", "⚡\ufe0f");
			string text4 = text3.Replace("[emoji_warning]", "⚠\ufe0f");
			string text5 = text4.Replace("[emoji_shield]", "\ud83d\udee1\ufe0f");
			string text6 = text5.Replace("[emoji_loop]", "\ud83d\udd04");
			string text7 = text6.Replace("[emoji_alarmclock]", "⏰");
			if (text7.Contains('[') && text7.Contains(']'))
			{
				string[] array = text7.Split('[');
				string[] array2 = text7.Split(']');
				string[] array3 = text7.Split('[');
				string[] array4 = array3[1].Split(']');
				string[] array5 = array4[0].Split('/');
				return array[0] + array2[1];
			}
			return text7;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x81B9BA0", Offset = "0x81B9BA0", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv60 = System.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>::GetEnumerator(this.m_infoList);\n\tv81 = v60._list;\n\tv71 = v60.Current;\n\tv141 = Unco.Notifications.GameNotificationSo::ProcessData(v106, v71.Body);\n\tv103 = Unco.Notifications.GameNotificationSo::ProcessData(v141, v71.Title);\n\tgoto L_0037;\nL_0045:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>));\nL_004D:\n\treturn;\nL_005E:\n\tv117 = Il2CppMethodInfo != 1;\n\tv130 = v93;\n\tif (v117) goto L_006E;\n\tv121 = System.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>+Enumerator<Unco.Notifications.NotificationInfo>::MoveNext(v93);\n\tv137 = 0x8BF5BF4(v121, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>));\n\tv129 = ~v121.m_value;\n\tif (v129) goto L_004D;\n\tv127 = new System.OutOfMemoryException();\n\tv64 = v121.m_value;\n\tv130 = v127;\n\treturn;\nL_001D:\n\tv81 = 0;\n\tv47 = this.m_infoList == 0;\n\tv64 = 0;\n\tif (v47) goto L_0050;\nL_0037:\n\tv106 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>));\n\tv119 = v106 == 0;\n\tif (v119) goto L_0045;\nL_006E:\n\tv133 = 0x39678CC(&v64 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x8BF0368(v130, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv182 = 0x7C03E68(v139, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0050:\n\tv93 = new System.NullReferenceException();\n\tgoto L_005E;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Test()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationSo::Test");
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x81BA4BC", Offset = "0x81BA4BC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.title = title;\n\tv79 = new System.Predicate`1<Unco.Notifications.NotificationInfo>();\n\tSystem.Predicate`1<Unco.Notifications.NotificationInfo>::.ctor(v79, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>::Find(this.m_infoList, v79);\n\treturn returnVal2;\nL_0023:\n\tv51 = new Unco.Notifications.GameNotificationSo+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v51);\n")]
		public NotificationInfo IsExist(string title)
		{
			Predicate<NotificationInfo> match = (NotificationInfo x) => x.Title == title;
			return m_infoList.Find(match);
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x81BA5B4", Offset = "0x81BA5B4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_0047;\nL_0047:\n\tSystem.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>::Add(v46, v40);\n\treturn;\nL_0016:\n\tv46 = this.m_infoList;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(NotificationInfo info)
		{
			List<NotificationInfo> infoList = m_infoList;
			NotificationInfo item = default(NotificationInfo);
			infoList.Add(item);
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x81B9E74", Offset = "0x81B9E74", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tSystem.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>::Clear(v38);\n\tv53 = v38.Count < 1;\n\tif (v53) goto L_0035;\n\treturn;\nL_0035:\n\treturn;\nL_0012:\n\tv38 = this.m_infoList;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			List<NotificationInfo> infoList = m_infoList;
			infoList.Clear();
			if (infoList.Count < 1)
			{
			}
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x81BA668", Offset = "0x81BA668", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>();\n\tSystem.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>::.ctor(v48);\n\tthis.m_infoList = v48;\n")]
		public GameNotificationSo()
		{
			List<NotificationInfo> infoList = new List<NotificationInfo>();
			m_infoList = infoList;
		}
	}
}
