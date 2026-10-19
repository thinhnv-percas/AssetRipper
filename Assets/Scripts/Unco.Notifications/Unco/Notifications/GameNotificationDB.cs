using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Notifications.Notifications;
using Unco.Utils;
using UnityEngine;
using _game.Scripts.Notifications;

namespace Unco.Notifications
{
	[CreateAssetMenu(fileName = "NotificationDatabase", menuName = "PushNotification/NotificationDatabase")]
	[Token(Token = "0x2000019")]
	public class GameNotificationDB : SoDatabase<GameNotificationSo, GameNotificationDB>, IGameNotificationConfig
	{
		[SerializeField]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x20")]
		private bool _ignoreElephantNotifsIos;

		[SerializeField]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x21")]
		private bool _enablePushNotifications;

		[SerializeField]
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x28")]
		private List<Pair<string, int>> _comeBackTimes;

		[Token(Token = "0x1700002F")]
		public List<Pair<string, int>> ComeBackTimes
		{
			[Token(Token = "0x60000AD")]
			[Address(RVA = "0x81B9714", Offset = "0x81B9714", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ComeBackTimes;\n")]
			get
			{
				return _comeBackTimes;
			}
		}

		[Token(Token = "0x17000030")]
		public bool EnablePushNotifications
		{
			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x81B971C", Offset = "0x81B971C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.EnablePushNotifications;\n")]
			get
			{
				return _enablePushNotifications;
			}
		}

		[Token(Token = "0x17000031")]
		public bool IgnoreElephantNotifsIos
		{
			[Token(Token = "0x60000AF")]
			[Address(RVA = "0x81B9724", Offset = "0x81B9724", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IgnoreElephantNotifsIos;\n")]
			get
			{
				return _ignoreElephantNotifsIos;
			}
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x81B972C", Offset = "0x81B972C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.type = type;\n\tv79 = new System.Predicate`1<Unco.Notifications.GameNotificationSo>();\n\tSystem.Predicate`1<Unco.Notifications.GameNotificationSo>::.ctor(v79, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>::Find(this.DataList, v79);\n\treturn returnVal2;\nL_0023:\n\tv51 = new Unco.Notifications.GameNotificationDB+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v51);\n")]
		public GameNotificationSo GetNotificationSoByType(string type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationDB::GetNotificationSoByType");
			return default;
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x81B9824", Offset = "0x81B9824", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\treturnVal1 = Unco.Notifications.GameNotificationSo::GetNotificationInfo(v55);\nL_002C:\n\treturn returnVal1;\nL_0019:\n\tv47 = _game.Scripts.Notifications.IGameNotification+GameNotificationType;\n\tv52 = System.Enum::ToString(&v47 @ stack_-48_v1 (Il2CppClass<_game.Scripts.Notifications.IGameNotification+GameNotificationType>));\n\tv55 = Unco.Notifications.GameNotificationDB::GetNotificationSoByType(this, v52);\n\tv56 = v55 == 0;\n\treturnVal1 = v55;\n\tif (v56) goto L_002C;\n")]
		public NotificationInfo GetNotificationInfo(IGameNotification.GameNotificationType type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationDB::GetNotificationInfo");
			return default;
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x81B994C", Offset = "0x81B994C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.Notifications.GameNotificationDB::GetNotificationSoByType(this, type);\n\tv10 = returnVal1 == 0;\n\tif (v10) goto L_000F;\n\treturnVal2 = Unco.Notifications.GameNotificationSo::GetNotificationInfo(returnVal1);\n\treturn returnVal2;\nL_000F:\n\treturn returnVal1;\n")]
		public NotificationInfo GetNotificationInfo(string type)
		{
			NotificationInfo notificationSoByType = (NotificationInfo)(object)GetNotificationSoByType(type);
			if (notificationSoByType != null)
			{
				return ((GameNotificationSo)(object)notificationSoByType).GetNotificationInfo();
			}
			return notificationSoByType;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x81B996C", Offset = "0x81B996C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_0047;\nL_0047:\n\tSystem.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>::Add(v46, v40);\n\treturn;\nL_0016:\n\tv46 = this.DataList;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(GameNotificationSo so)
		{
			List<GameNotificationSo> dataList = DataList;
			GameNotificationSo item = default(GameNotificationSo);
			dataList.Add(item);
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x81B9A20", Offset = "0x81B9A20", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv66 = System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>::GetEnumerator(this.DataList);\n\tv87 = v66._list;\n\tv156 = UnityEngine.Object::get_name(v66.Current);\n\tgoto L_0051;\nL_0051:\n\tUnityEngine.Debug::Log(v156);\n\tUnco.Notifications.GameNotificationSo::Test(v66.Current);\n\tgoto L_003E;\nL_0057:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v87 @ stack_-58_v4 (System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>));\nL_0061:\n\treturn;\nL_0070:\n\tv130 = Il2CppMethodInfo != 1;\n\tif (v130) goto L_007F;\n\tv135 = System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>+Enumerator<Unco.Notifications.GameNotificationSo>::MoveNext(v103);\n\tv151 = 0x8BF5BF4(v135, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v87 @ stack_-58_v4 (System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>));\n\tv143 = ~v135.m_value;\n\tif (v143) goto L_0061;\n\tv141 = new System.OutOfMemoryException();\n\tv70 = v135.m_value;\n\tv103 = v141;\nL_007F:\n\tv148 = 0x396788C(&v70 @ stack_-68_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv153 = 0x8BF0368(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv201 = 0x7C03E68(v153, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0022:\n\tv87 = 0;\n\tv51 = this.DataList == 0;\n\tv70 = 0;\n\tif (v51) goto L_0064;\nL_003E:\n\tv120 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v87 @ stack_-58_v4 (System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>));\n\tv134 = v120 == 0;\n\tif (v134) goto L_0057;\nL_0064:\n\tv103 = new System.NullReferenceException();\n\tgoto L_0070;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void TestNotifProcessData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationDB::TestNotifProcessData");
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x81B9CEC", Offset = "0x81B9CEC", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv64 = System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>::GetEnumerator(this.DataList);\n\tv125 = v64._list;\n\tv115 = v64.Current;\n\tgoto L_004C;\n\tSystem.Collections.Generic.List`1<Unco.Notifications.NotificationInfo>::Clear(v166);\n\tv146 = v166.Count < 1;\n\tif (v146) goto L_003D;\n\tgoto L_003D;\nL_0067:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v125 @ stack_-58_v4 (System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>));\nL_0071:\n\treturn;\nL_0080:\n\tv178 = Il2CppMethodInfo != 1;\n\tif (v178) goto L_008F;\n\tv181 = System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>+Enumerator<Unco.Notifications.GameNotificationSo>::MoveNext(v138);\n\tv198 = 0x8BF5BF4(v181, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v125 @ stack_-58_v4 (System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>));\n\tv189 = ~v181.m_value;\n\tif (v189) goto L_0071;\n\tv187 = new System.OutOfMemoryException();\n\tv108 = v181.m_value;\n\tv138 = v187;\nL_008F:\n\tv194 = 0x396788C(&v108 @ stack_-68_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv200 = 0x8BF0368(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv245 = 0x7C03E68(v200, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001F:\n\tv125 = 0;\n\tv51 = this.DataList == 0;\n\tv108 = 0;\n\tif (v51) goto L_0074;\nL_004C:\n\tv166 = v115.m_infoList;\nL_003D:\n\tv168 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v125 @ stack_-58_v4 (System.Collections.Generic.List`1<Unco.Notifications.GameNotificationSo>));\n\tv180 = v168 == 0;\n\tif (v180) goto L_0067;\nL_0074:\n\tv138 = new System.NullReferenceException();\n\tgoto L_0080;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Clear()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationDB::Clear");
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x81B9EE8", Offset = "0x81B9EE8", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tgoto L_006A;\nL_006A:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>::Add(v57, v71);\n\tUnco.Utils.Pair`2<System.Object, System.Int32>::.ctor(&v99 @ stack_-60_v3 (Unco.Utils.Pair`2<System.Object, System.Int32>), \"Comeback3\", 3);\n\tgoto L_0097;\nL_0097:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>::Add(v57, v99);\n\tUnco.Utils.Pair`2<System.Object, System.Int32>::.ctor(&v93 @ stack_-70_v3 (Unco.Utils.Pair`2<System.Object, System.Int32>), \"Comeback7\", 7);\n\tgoto L_00C4;\nL_00C4:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Object, System.Int32>>::Add(v57, v93);\n\tthis.ComeBackTimes = v57;\n\tUnco.Notifications.SoDatabase`2<Unco.Notifications.GameNotificationSo, Unco.Notifications.GameNotificationDB>::.ctor(this);\n\treturn;\nL_0034:\n\tthis.EnablePushNotifications = 1;\n\tv57 = new System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.String, System.Int32>>();\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.String, System.Int32>>::.ctor(v57);\n\tUnco.Utils.Pair`2<System.Object, System.Int32>::.ctor(&v71 @ stack_-50_v2 (Unco.Utils.Pair`2<System.Object, System.Int32>), \"Comeback1\", 1);\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameNotificationDB()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationDB::.ctor");
		}
	}
}
