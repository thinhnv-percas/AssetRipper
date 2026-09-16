using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200007D")]
	public class NotificationsSettings : IAndroidPermissionRequired
	{
		[Token(Token = "0x40002E1")]
		public const string DEFAULT_CATEGORY_ID = "notification.category.default";

		[Token(Token = "0x40002E2")]
		public const string DEFAULT_CATEGORY_NAME = "Default";

		[SerializeField]
		[Token(Token = "0x40002E3")]
		[FieldOffset(Offset = "0x10")]
		private bool mAutoInit;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7332C8", Offset = "0x7332C8")]
		[Token(Token = "0x40002E4")]
		[FieldOffset(Offset = "0x14")]
		private float mAutoInitDelay;

		[SerializeField]
		[EnumFlags]
		[Token(Token = "0x40002E5")]
		[FieldOffset(Offset = "0x18")]
		private NotificationAuthOptions mIosAuthOptions;

		[SerializeField]
		[Token(Token = "0x40002E6")]
		[FieldOffset(Offset = "0x1C")]
		private PushNotificationProvider mPushNotificationService;

		[SerializeField]
		[Token(Token = "0x40002E7")]
		[FieldOffset(Offset = "0x20")]
		private string mOneSignalAppId;

		[SerializeField]
		[Token(Token = "0x40002E8")]
		[FieldOffset(Offset = "0x28")]
		private string[] mFirebaseTopics;

		[SerializeField]
		[Token(Token = "0x40002E9")]
		[FieldOffset(Offset = "0x30")]
		private NotificationCategoryGroup[] mCategoryGroups;

		[SerializeField]
		[Token(Token = "0x40002EA")]
		[FieldOffset(Offset = "0x38")]
		private NotificationCategory mDefaultCategory;

		[SerializeField]
		[Token(Token = "0x40002EB")]
		[FieldOffset(Offset = "0x40")]
		private NotificationCategory[] mUserCategories;

		[SerializeField]
		[Token(Token = "0x40002EC")]
		[FieldOffset(Offset = "0x48")]
		private List<AndroidPermission> mAndroidPermissions;

		[Token(Token = "0x1700019E")]
		public bool IsAutoInit
		{
			[Token(Token = "0x6000593")]
			[Address(RVA = "0xFD1534", Offset = "0xFD1534", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoInit;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsAutoInit;
			}
			[Token(Token = "0x6000594")]
			[Address(RVA = "0xFD153C", Offset = "0xFD153C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoInit = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mAutoInit = value;
			}
		}

		[Token(Token = "0x1700019F")]
		public float AutoInitDelay
		{
			[Token(Token = "0x6000595")]
			[Address(RVA = "0xFD1548", Offset = "0xFD1548", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoInitDelay;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AutoInitDelay;
			}
			[Token(Token = "0x6000596")]
			[Address(RVA = "0xFD1550", Offset = "0xFD1550", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoInitDelay = value;\n\treturn;\n")]
			set
			{
				AutoInitDelay = value;
			}
		}

		[Token(Token = "0x170001A0")]
		public NotificationAuthOptions iOSAuthOptions
		{
			[Token(Token = "0x6000597")]
			[Address(RVA = "0xFD1558", Offset = "0xFD1558", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIosAuthOptions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return iOSAuthOptions;
			}
			[Token(Token = "0x6000598")]
			[Address(RVA = "0xFD1560", Offset = "0xFD1560", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mIosAuthOptions = value;\n\treturn;\n")]
			set
			{
				iOSAuthOptions = value;
			}
		}

		[Token(Token = "0x170001A1")]
		public PushNotificationProvider PushNotificationService
		{
			[Token(Token = "0x6000599")]
			[Address(RVA = "0xFD1568", Offset = "0xFD1568", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mPushNotificationService;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PushNotificationService;
			}
			[Token(Token = "0x600059A")]
			[Address(RVA = "0xFD1570", Offset = "0xFD1570", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mPushNotificationService = value;\n\treturn;\n")]
			set
			{
				PushNotificationService = value;
			}
		}

		[Token(Token = "0x170001A2")]
		public string OneSignalAppId
		{
			[Token(Token = "0x600059B")]
			[Address(RVA = "0xFD1578", Offset = "0xFD1578", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mOneSignalAppId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OneSignalAppId;
			}
			[Token(Token = "0x600059C")]
			[Address(RVA = "0xFD1580", Offset = "0xFD1580", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mOneSignalAppId = value;\n\treturn;\n")]
			set
			{
				OneSignalAppId = value;
			}
		}

		[Token(Token = "0x170001A3")]
		public string[] FirebaseTopics
		{
			[Token(Token = "0x600059D")]
			[Address(RVA = "0xFD1588", Offset = "0xFD1588", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mFirebaseTopics;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FirebaseTopics;
			}
			[Token(Token = "0x600059E")]
			[Address(RVA = "0xFD1590", Offset = "0xFD1590", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mFirebaseTopics = value;\n\treturn;\n")]
			set
			{
				FirebaseTopics = value;
			}
		}

		[Token(Token = "0x170001A4")]
		public NotificationCategoryGroup[] CategoryGroups
		{
			[Token(Token = "0x600059F")]
			[Address(RVA = "0xFD1598", Offset = "0xFD1598", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCategoryGroups;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CategoryGroups;
			}
			[Token(Token = "0x60005A0")]
			[Address(RVA = "0xFD15A0", Offset = "0xFD15A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mCategoryGroups = value;\n\treturn;\n")]
			set
			{
				CategoryGroups = value;
			}
		}

		[Token(Token = "0x170001A5")]
		public NotificationCategory DefaultCategory
		{
			[Token(Token = "0x60005A1")]
			[Address(RVA = "0xFD15A8", Offset = "0xFD15A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultCategory;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultCategory;
			}
			[Token(Token = "0x60005A2")]
			[Address(RVA = "0xFD15B0", Offset = "0xFD15B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultCategory = value;\n\treturn;\n")]
			set
			{
				DefaultCategory = value;
			}
		}

		[Token(Token = "0x170001A6")]
		public NotificationCategory[] UserCategories
		{
			[Token(Token = "0x60005A3")]
			[Address(RVA = "0xFD15B8", Offset = "0xFD15B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mUserCategories;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UserCategories;
			}
			[Token(Token = "0x60005A4")]
			[Address(RVA = "0xFD15C0", Offset = "0xFD15C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mUserCategories = value;\n\treturn;\n")]
			set
			{
				UserCategories = value;
			}
		}

		[Token(Token = "0x60005A5")]
		[Address(RVA = "0xFD15C8", Offset = "0xFD15C8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = System.String::IsNullOrEmpty(categoryId);\n\tv23 = v20 == 0;\n\tv24 = ~v23;\n\tif (v24) goto L_005F;\n\tv25 = this.mDefaultCategory;\n\tv93 = System.String::Equals(categoryId, v25.id);\n\tv81 = v93 == 0;\n\tif (v81) goto L_0020;\n\tv83 = this.mDefaultCategory;\n\tgoto L_005F;\nL_0020:\n\tv96 = this.mUserCategories;\n\tv191 = this.mUserCategories == 0;\n\tif (v191) goto L_FFFFFFFF;\n\tv184 = v96.Length;\n\tv203 = v96.Length < 1;\n\tif (v203) goto L_FFFFFFFF;\nL_0031:\n\tv225 = v33 < v184;\n\tv69 = ~v225;\n\tif (v69) goto L_0062;\n\tv86 = v96[v33 @ X22_v7 (System.Int32)];\n\tv94 = System.String::Equals(categoryId, v86.id);\n\tv228 = v94 == 0;\n\tv82 = ~v228;\n\tif (v82) goto L_005F;\n\tv184 = v96.Length;\n\tv33 = v33 + 1;\n\tv205 = v33 < v96.Length;\n\tif (v205) goto L_0031;\nL_005F:\n\treturn v83;\n\tv128 = new System.NullReferenceException();\nL_0062:\n\tv189 = new System.IndexOutOfRangeException();\n\tthrow v189;\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NotificationCategory GetCategoryWithId(string categoryId)
		{
			bool flag = string.IsNullOrEmpty(categoryId);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			NotificationCategory result = null;
			if (!flag3)
			{
				NotificationCategory defaultCategory = DefaultCategory;
				if (!categoryId.Equals(defaultCategory.id))
				{
					NotificationCategory[] userCategories = UserCategories;
					if (UserCategories != null)
					{
						int num = userCategories.Length;
						if (userCategories.Length >= 1)
						{
							int num2 = 0;
							while (true)
							{
								if (num2 < num)
								{
									NotificationCategory notificationCategory = userCategories[num2];
									bool flag4 = categoryId.Equals(notificationCategory.id);
									bool flag5 = !flag4;
									bool flag6 = !flag5;
									result = userCategories[num2];
									if (flag6)
									{
										break;
									}
									num = userCategories.Length;
									num2++;
									if (num2 < userCategories.Length)
									{
										continue;
									}
									goto IL_0186;
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
							}
							goto IL_019e;
						}
					}
					goto IL_0186;
				}
				result = DefaultCategory;
			}
			goto IL_019e;
			IL_0186:
			result = null;
			goto IL_019e;
			IL_019e:
			return result;
		}

		[Token(Token = "0x60005A6")]
		[Address(RVA = "0xFD169C", Offset = "0xFD169C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAndroidPermissions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<AndroidPermission> GetAndroidPermissions()
		{
			return mAndroidPermissions;
		}

		[Token(Token = "0x60005A7")]
		[Address(RVA = "0xFD16A4", Offset = "0xFD16A4", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EAA6D8]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20256A0]) = v40;\nL_0016:\n\tthis.mAutoInit = 1;\n\tthis.mIosAuthOptions = 7;\n\tv46 = new EasyMobile.NotificationCategory();\n\tEasyMobile.NotificationCategory::.ctor(v46);\n\tv46.id = \"notification.category.default\";\n\tv46.name = \"Default\";\n\tthis.mDefaultCategory = v46;\n\tv58 = new System.Collections.Generic.List`1<EasyMobile.AndroidPermission>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::.ctor(v58);\n\tv70 = new EasyMobile.AndroidPermission();\n\tEasyMobile.AndroidPermission::.ctor(v70, \"uses-permission\", \"android.permission.RECEIVE_BOOT_COMPLETED\");\n\tSystem.Collections.Generic.List`1<EasyMobile.AndroidPermission>::Add(v58, v70);\n\tthis.mAndroidPermissions = v58;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NotificationsSettings()
		{
			mAutoInit = true;
			iOSAuthOptions = NotificationAuthOptions.Alert | NotificationAuthOptions.Badge | NotificationAuthOptions.Sound;
			DefaultCategory = new NotificationCategory
			{
				id = "notification.category.default",
				name = "Default"
			};
			List<AndroidPermission> list = new List<AndroidPermission>();
			AndroidPermission item = new AndroidPermission("uses-permission", "android.permission.RECEIVE_BOOT_COMPLETED");
			list.Add(item);
			mAndroidPermissions = list;
		}
	}
}
