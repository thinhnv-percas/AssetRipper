using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;

namespace EasyMobile
{
	[Token(Token = "0x2000082")]
	public abstract class ConsentManager : IConsentRequirable
	{
		[Token(Token = "0x4000316")]
		[FieldOffset(Offset = "0x10")]
		protected internal string mDataPrivacyConsentKey;

		[CompilerGenerated]
		[Token(Token = "0x4000317")]
		[FieldOffset(Offset = "0x18")]
		private Action<ConsentStatus> m_DataPrivacyConsentUpdated;

		[Token(Token = "0x170001AE")]
		public virtual ConsentStatus DataPrivacyConsent
		{
			[Token(Token = "0x60005DD")]
			[Address(RVA = "0xA53F38", Offset = "0xA53F38", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.Internal.StorageUtil::GetInt(this.mDataPrivacyConsentKey, 0xFFFFFFFF);\n\tv21 = v10 != 0;\n\tif (v21) goto L_FFFFFFFF;\n\tv24 = 1 + 1;\n\tgoto L_0018;\nL_0018:\n\tv25 = v10 + 1;\n\tv27 = v25 == 0;\n\tv30 = ~v27;\n\tif (v30) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = StorageUtil.GetInt(mDataPrivacyConsentKey, -1);
				int result = ((num != 0) ? 1 : (1 + 1));
				if (num + 1 == 0)
				{
					return default(ConsentStatus);
				}
				return (ConsentStatus)result;
			}
			[Token(Token = "0x60005DE")]
			[Address(RVA = "0xA53F6C", Offset = "0xA53F6C", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EB1A90]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F8F]) = v41;\nL_0019:\n\tv46 = EasyMobile.ConsentManager::get_DataPrivacyConsent(this);\n\tv51 = v46 == value;\n\tif (v51) goto L_0057;\n\tv59 = value - 2;\n\tv61 = v59 == 0;\n\tv66 = ~v61;\n\tv72 = value == 0;\n\tv77 = ~v72;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tEasyMobile.Internal.StorageUtil::SetInt(this.mDataPrivacyConsentKey, v82);\n\tv98 = this.DataPrivacyConsentUpdated == 0;\n\tif (v98) goto L_0057;\n\tSystem.Action`1<EasyMobile.ConsentStatus>::Invoke(this.DataPrivacyConsentUpdated, value);\n\treturn;\nL_0057:\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				int dataPrivacyConsent = (int)DataPrivacyConsent;
				if (dataPrivacyConsent != (int)value)
				{
					int num = (int)(value - 2);
					bool flag = num == 0;
					bool flag2 = !flag;
					int value2 = ((value == ConsentStatus.Unknown) ? (-1) : (flag2 ? 1 : 0));
					StorageUtil.SetInt(mDataPrivacyConsentKey, value2);
					if (this.DataPrivacyConsentUpdated != null)
					{
						this.DataPrivacyConsentUpdated(value);
					}
				}
			}
		}

		[Token(Token = "0x14000033")]
		public event Action<ConsentStatus> DataPrivacyConsentUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x60005DB")]
			[Address(RVA = "0xA489D0", Offset = "0xA489D0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBF080]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F8D]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.ConsentStatus>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_DataPrivacyConsentUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<ConsentStatus>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005DC")]
			[Address(RVA = "0xA48AA0", Offset = "0xA48AA0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC11F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F8E]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.ConsentStatus>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_DataPrivacyConsentUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<ConsentStatus>))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60005DF")]
		[Address(RVA = "0xA54014", Offset = "0xA54014", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ConsentManager::set_DataPrivacyConsent(this, 1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void GrantDataPrivacyConsent()
		{
			DataPrivacyConsent = ConsentStatus.Granted;
		}

		[Token(Token = "0x60005E0")]
		[Address(RVA = "0xA5401C", Offset = "0xA5401C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ConsentManager::set_DataPrivacyConsent(this, 2);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void RevokeDataPrivacyConsent()
		{
			DataPrivacyConsent = ConsentStatus.Revoked;
		}

		[Token(Token = "0x60005E1")]
		[Address(RVA = "0xA4D6AC", Offset = "0xA4D6AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ConsentManager()
		{
		}
	}
}
