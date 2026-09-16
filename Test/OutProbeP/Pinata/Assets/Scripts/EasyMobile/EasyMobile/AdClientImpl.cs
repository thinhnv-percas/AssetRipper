using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000024")]
	public abstract class AdClientImpl : IAdClient, IConsentRequirable
	{
		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x10")]
		protected internal bool mIsInitialized;

		[CompilerGenerated]
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x18")]
		private Action<IAdClient, AdPlacement> m_InterstitialAdCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x20")]
		private Action<IAdClient, AdPlacement> m_RewardedAdSkipped;

		[CompilerGenerated]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x28")]
		private Action<IAdClient, AdPlacement> m_RewardedAdCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x30")]
		private Action<ConsentStatus> m_DataPrivacyConsentUpdated;

		[Token(Token = "0x1700003C")]
		public abstract bool IsSdkAvail
		{
			[Token(Token = "0x6000112")]
			get;
		}

		[Token(Token = "0x1700003D")]
		protected abstract string NoSdkMessage
		{
			[Token(Token = "0x6000114")]
			get;
		}

		[Token(Token = "0x1700003E")]
		public abstract AdNetwork Network
		{
			[Token(Token = "0x6000125")]
			get;
		}

		[Token(Token = "0x1700003F")]
		public abstract bool IsBannerAdSupported
		{
			[Token(Token = "0x6000126")]
			get;
		}

		[Token(Token = "0x17000040")]
		public abstract bool IsInterstitialAdSupported
		{
			[Token(Token = "0x6000127")]
			get;
		}

		[Token(Token = "0x17000041")]
		public abstract bool IsRewardedAdSupported
		{
			[Token(Token = "0x6000128")]
			get;
		}

		[Token(Token = "0x17000042")]
		public List<AdPlacement> DefinedCustomInterstitialAdPlacements
		{
			[Token(Token = "0x6000129")]
			[Address(RVA = "0xA42B30", Offset = "0xA42B30", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.AdClientImpl::get_CustomInterstitialAdsDict(this);\n\treturnVal1 = EasyMobile.AdClientImpl::GetCustomPlacementsFromDefinedDict(v10, v10);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				AdClientImpl customInterstitialAdsDict = (AdClientImpl)(object)CustomInterstitialAdsDict;
				return customInterstitialAdsDict.GetCustomPlacementsFromDefinedDict((Dictionary<AdPlacement, AdId>)(object)customInterstitialAdsDict);
			}
		}

		[Token(Token = "0x17000043")]
		public List<AdPlacement> DefinedCustomRewardedAdPlacements
		{
			[Token(Token = "0x600012A")]
			[Address(RVA = "0xA42D64", Offset = "0xA42D64", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.AdClientImpl::get_CustomRewardedAdsDict(this);\n\treturnVal1 = EasyMobile.AdClientImpl::GetCustomPlacementsFromDefinedDict(v10, v10);\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				AdClientImpl customRewardedAdsDict = (AdClientImpl)(object)CustomRewardedAdsDict;
				return customRewardedAdsDict.GetCustomPlacementsFromDefinedDict((Dictionary<AdPlacement, AdId>)(object)customRewardedAdsDict);
			}
		}

		[Token(Token = "0x17000044")]
		protected abstract Dictionary<AdPlacement, AdId> CustomInterstitialAdsDict
		{
			[Token(Token = "0x600012B")]
			get;
		}

		[Token(Token = "0x17000045")]
		protected abstract Dictionary<AdPlacement, AdId> CustomRewardedAdsDict
		{
			[Token(Token = "0x600012C")]
			get;
		}

		[Token(Token = "0x17000046")]
		public virtual bool IsInitialized
		{
			[Token(Token = "0x600012D")]
			[Address(RVA = "0xA42D88", Offset = "0xA42D88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsInitialized;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsInitialized;
			}
		}

		[Token(Token = "0x17000047")]
		public virtual ConsentStatus DataPrivacyConsent
		{
			[Token(Token = "0x6000149")]
			[Address(RVA = "0xA44CF0", Offset = "0xA44CF0", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[91];\n\tv3 = this->klass->vtable[91];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn X0;\n")]
			get
			{
				//IL_0005: Expected I, but got O
				//IL_0015: Expected O, but got I
				//IL_0025: Expected O, but got I
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+6E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+6E8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
				return ConsentStatus.Unknown;
			}
			[Token(Token = "0x600014A")]
			[Address(RVA = "0xA44D00", Offset = "0xA44D00", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC89D8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EA8]) = v41;\nL_0019:\n\tv46 = EasyMobile.AdClientImpl::get_DataPrivacyConsent(this);\n\tv51 = v46 == value;\n\tif (v51) goto L_0045;\n\tv61 = EasyMobile.AdClientImpl::SaveDataPrivacyConsent(this, value);\n\tv67 = EasyMobile.AdClientImpl::ApplyDataPrivacyConsent(this, value);\n\tv69 = this.DataPrivacyConsentUpdated == 0;\n\tif (v69) goto L_0045;\n\tSystem.Action`1<EasyMobile.ConsentStatus>::Invoke(this.DataPrivacyConsentUpdated, value);\n\treturn;\nL_0045:\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				int dataPrivacyConsent = (int)DataPrivacyConsent;
				if (dataPrivacyConsent != (int)value)
				{
					SaveDataPrivacyConsent(value);
					ApplyDataPrivacyConsent(value);
					if (this.DataPrivacyConsentUpdated != null)
					{
						this.DataPrivacyConsentUpdated(value);
					}
				}
			}
		}

		[Token(Token = "0x17000048")]
		protected abstract string DataPrivacyConsentSaveKey
		{
			[Token(Token = "0x600014D")]
			get;
		}

		[Token(Token = "0x14000006")]
		public event Action<IAdClient, AdPlacement> InterstitialAdCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x600011F")]
			[Address(RVA = "0xA42758", Offset = "0xA42758", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB26D0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E87]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_InterstitialAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IAdClient, AdPlacement>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000120")]
			[Address(RVA = "0xA427FC", Offset = "0xA427FC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB5018]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E88]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_InterstitialAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IAdClient, AdPlacement>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x14000007")]
		public event Action<IAdClient, AdPlacement> RewardedAdSkipped
		{
			[CompilerGenerated]
			[Token(Token = "0x6000121")]
			[Address(RVA = "0xA428A0", Offset = "0xA428A0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF7278]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E89]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_RewardedAdSkipped;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IAdClient, AdPlacement>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000122")]
			[Address(RVA = "0xA42944", Offset = "0xA42944", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED93F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E8A]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_RewardedAdSkipped;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IAdClient, AdPlacement>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x14000008")]
		public event Action<IAdClient, AdPlacement> RewardedAdCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x6000123")]
			[Address(RVA = "0xA429E8", Offset = "0xA429E8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF35F0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E8B]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_RewardedAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IAdClient, AdPlacement>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000124")]
			[Address(RVA = "0xA42A8C", Offset = "0xA42A8C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED3110]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E8C]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`2<EasyMobile.IAdClient, EasyMobile.AdPlacement>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_RewardedAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<IAdClient, AdPlacement>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x14000009")]
		public event Action<ConsentStatus> DataPrivacyConsentUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x6000147")]
			[Address(RVA = "0xA44BA8", Offset = "0xA44BA8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EADCF0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021EA6]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.ConsentStatus>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_DataPrivacyConsentUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<ConsentStatus>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000148")]
			[Address(RVA = "0xA44C4C", Offset = "0xA44C4C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F09350]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021EA7]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action`1<EasyMobile.ConsentStatus>;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_DataPrivacyConsentUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action<ConsentStatus>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x6000113")]
		public abstract bool IsValidPlacement(AdPlacement placement, AdType type);

		[Token(Token = "0x6000115")]
		protected abstract void InternalInit();

		[Token(Token = "0x6000116")]
		protected abstract void InternalShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size);

		[Token(Token = "0x6000117")]
		protected abstract void InternalHideBannerAd(AdPlacement placement);

		[Token(Token = "0x6000118")]
		protected abstract void InternalDestroyBannerAd(AdPlacement placement);

		[Token(Token = "0x6000119")]
		protected abstract void InternalLoadInterstitialAd(AdPlacement placement);

		[Token(Token = "0x600011A")]
		protected abstract bool InternalIsInterstitialAdReady(AdPlacement placement);

		[Token(Token = "0x600011B")]
		protected abstract void InternalShowInterstitialAd(AdPlacement placement);

		[Token(Token = "0x600011C")]
		protected abstract void InternalLoadRewardedAd(AdPlacement placement);

		[Token(Token = "0x600011D")]
		protected abstract bool InternalIsRewardedAdReady(AdPlacement placement);

		[Token(Token = "0x600011E")]
		protected abstract void InternalShowRewardedAd(AdPlacement placement);

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xA42D90", Offset = "0xA42D90", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F10008]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E8D]) = v38;\nL_0018:\n\tv44 = EasyMobile.AdClientImpl::get_IsSdkAvail(this);\n\tv47 = v44 == 0;\n\tif (v47) goto L_0047;\n\tv51 = EasyMobile.AdClientImpl::get_IsInitialized(this);\n\tv54 = v51 == 0;\n\tif (v54) goto L_005D;\n\tv62 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 47 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v62 @ X0_v17 (EasyMobile.AdNetwork)\n\tv121 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v121 @ X8_v14+160])(v125, this, *([v121 @ X8_v14+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v121 @ X8_v14+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv82 = System.String::Concat(v125, \" client is already initialized. Ignoring this call.\");\n\tgoto L_004F;\nL_0047:\n\tv82 = EasyMobile.AdClientImpl::get_NoSdkMessage(this);\nL_004F:\n\tgoto L_0058;\n\tv116 = *([v95 @ X8_v9+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tgoto L_0058;\n\tv140 = v95;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v140, v78, v74, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0058:\n\tUnityEngine.Debug::Log(v82);\n\tgoto L_0063;\nL_005D:\n\tthis = EasyMobile.AdClientImpl::InternalInit(this);\nL_0063:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Init()
		{
			string message;
			if (IsSdkAvail)
			{
				if (!IsInitialized)
				{
					InternalInit();
					return;
				}
				AdNetwork network = Network;
				AdClientImpl adClientImpl = (AdClientImpl)(object)network;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v121 @ X8_v14+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string text = default(string);
				message = text + " client is already initialized. Ignoring this call.";
			}
			else
			{
				message = NoSdkMessage;
			}
			Debug.Log(message);
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0xA42EE0", Offset = "0xA42EE0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ED9EC0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, position, size, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021E8E]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v47, position, size, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.AdPlacement;\nL_0025:\n\tv59 = this->klass;\n\tv62 = v58.Default;\n\tv63 = this->klass->vtable[65];\n\tv64 = this->klass->vtable[65];\n\t// 51 IndirectJump v63 @ X5_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v62 @ X1_v1 (EasyMobile.AdPlacement), position @ X1 (EasyMobile.BannerAdPosition), size @ X2 (EasyMobile.BannerAdSize), v64 @ X4_v1, v63 @ X5_v1, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void ShowBannerAd(BannerAdPosition position, BannerAdSize size)
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+540]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+548]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0xA42F74", Offset = "0xA42F74", Length = "0x344")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EE56E8]);\n\tv31 = *([v30 @ X8_v70]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, placement, position, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021E8F]) = v47;\nL_001E:\n\tv53 = EasyMobile.AdClientImpl::get_IsSdkAvail(this);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0077;\n\tv58 = EasyMobile.AdPlacement;\n\tv60 = *([v58 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv61 = v60 == 0;\n\tif (v61) goto L_002C;\n\tv75 = *([v58 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v75) goto L_00EA;\nL_002C:\n\tv78 = placement == 0;\n\tif (v78) goto L_003B;\nL_002E:\n\tv93 = placement->klass;\n\tv219 = placement->klass->vtable[0];\n\tv98 = EasyMobile.AdPlacement::Equals(placement, 0);\n\tv100 = v98 == 0;\n\tif (v100) goto L_0090;\nL_003B:\n\t// 59 NewArr v111 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv125 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 72 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v125 @ X0_v29 (EasyMobile.AdNetwork)\n\tv230 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v230 @ X8_v25+160])(this, this, *([v230 @ X8_v25+168]), v219, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v230 @ X8_v25+168]), v219, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv288 = this == 0;\n\tif (v288) goto L_0061;\n\t// 93 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_0061:\n\tv299 = v111.Length == 0;\n\tif (v299) goto L_0103;\n\tv111[0] = this;\n\tgoto L_FFFFFFFF;\n\tv344 = *([v321 @ X0_v37+E0]);\n\tv345 = v344 == 0;\n\tv346 = ~v345;\n\tif (v346) goto L_FFFFFFFF;\n\tv348 = \"il2cpp_codegen_runtime_class_init\"(v321, v293, v101, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00DF;\nL_0077:\n\tv66 = EasyMobile.AdClientImpl::get_NoSdkMessage(this);\n\tgoto L_0088;\n\tv79 = *([v70 @ X8_v8+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0088;\n\tv112 = v70;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v112, v65, position, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0088:\n\tUnityEngine.Debug::Log(v66);\n\tgoto L_00E8;\nL_0090:\n\tgoto L_0096;\n\tv175 = *([v116 @ X0_v45+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0096;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v116, v95, v97, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0096:\n\tv182 = size == 0;\n\tif (v182) goto L_00A5;\n\tv211 = size->klass;\n\tv219 = size->klass->vtable[0];\n\tv216 = EasyMobile.BannerAdSize::Equals(size, 0);\n\tv218 = v216 == 0;\n\tif (v218) goto L_00F3;\nL_00A5:\n\t// 165 NewArr v229 @ X0_v49 (System.Object[]), typeof(System.Object[]), 1\n\tv261 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 178 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v261 @ X0_v51 (EasyMobile.AdNetwork)\n\tv308 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v308 @ X8_v50+160])(this, this, *([v308 @ X8_v50+168]), v219, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v308 @ X8_v50+168]), v219, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv338 = this == 0;\n\tif (v338) goto L_00CB;\n\t// 199 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_00CB:\n\tv300 = v229.Length == 0;\n\tif (v300) goto L_0103;\n\tv229[0] = this;\n\tgoto L_FFFFFFFF;\n\tv368 = *([v364 @ X0_v59+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_FFFFFFFF;\n\tv371 = \"il2cpp_codegen_runtime_class_init\"(v364, v294, v219, size, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00DF:\n\tUnityEngine.Debug::LogFormat(*([v165 @ X8_v12 (System.String)]), v163);\nL_00E8:\n\treturn;\nL_00EA:\n\tv113 = placement == 0;\n\tv91 = ~v113;\n\tif (v91) goto L_002E;\n\tgoto L_003B;\nL_00F3:\n\tv153 = EasyMobile.AdClientImpl::CheckInitialize(this, 1);\n\tv157 = v153 == 0;\n\tif (v157) goto L_00E8;\n\tthis = EasyMobile.AdClientImpl::InternalShowBannerAd(this, placement, position, size);\n\tgoto L_00E8;\n\tthrow System.NullReferenceException;\n\tv286 = new System.NullReferenceException();\nL_0103:\n\tv307 = new System.IndexOutOfRangeException();\n\tgoto L_0108;\n\tv332 = new System.ArrayTypeMismatchException();\nL_0108:\n\tthrow v331;\n// 167 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void ShowBannerAd(AdPlacement placement, BannerAdPosition position, BannerAdSize size)
		{
			//IL_0013: Expected I, but got O
			//IL_0098: Expected I, but got O
			//IL_01d9: Expected I, but got O
			BannerAdPosition bannerAdPosition;
			if (IsSdkAvail)
			{
				IntPtr intPtr = (IntPtr)typeof(AdPlacement);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if ((object)placement != null)
						{
							goto IL_0090;
						}
						bannerAdPosition = position;
						goto IL_00d3;
					}
				}
				bool flag = (object)placement == null;
				bannerAdPosition = position;
				if (!flag)
				{
					goto IL_0090;
				}
				goto IL_00d3;
			}
			string noSdkMessage = NoSdkMessage;
			Debug.Log(noSdkMessage);
			return;
			IL_0090:
			IntPtr intPtr2 = (IntPtr)placement;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v38 (Il2CppClass<EasyMobile.AdPlacement>)+138]");
			bannerAdPosition = BannerAdPosition.Top;
			if (placement.Equals(null))
			{
				goto IL_00d3;
			}
			if ((object)size != null)
			{
				IntPtr intPtr3 = (IntPtr)size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X8_v62 (Il2CppClass<EasyMobile.BannerAdSize>)+138]");
				bannerAdPosition = BannerAdPosition.Top;
				if (!size.Equals(null))
				{
					if (CheckInitialize())
					{
						InternalShowBannerAd(placement, position, size);
					}
					return;
				}
			}
			object[] array = new object[1];
			AdNetwork network = Network;
			AdClientImpl adClientImpl = (AdClientImpl)(object)network;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v308 @ X8_v50+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			if (array.Length == 0)
			{
				goto IL_034c;
			}
			array[0] = this;
			object[] args = array;
			string format = "Cannot show {0} banner ad with ad size: null";
			goto IL_0386;
			IL_00d3:
			object[] array2 = new object[1];
			AdNetwork network2 = Network;
			adClientImpl = (AdClientImpl)(object)network2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v230 @ X8_v25+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			if (array2.Length == 0)
			{
				goto IL_034c;
			}
			array2[0] = this;
			args = array2;
			format = "Cannot show {0} banner ad at placement: null";
			goto IL_0386;
			IL_034c:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0386:
			Debug.LogFormat(format, args);
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0xA432F0", Offset = "0xA432F0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF4B38]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E90]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[67];\n\tv59 = this->klass->vtable[67];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void HideBannerAd()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+560]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+568]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0xA4336C", Offset = "0xA4336C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB3E00]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E91]) = v41;\nL_0015:\n\t;\n\tv47 = EasyMobile.AdClientImpl::CheckInitialize(this, 1);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0042;\n\tgoto L_002C;\n\tv69 = *([v52 @ X0_v5+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_002C;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v52, v43, v46, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv59 = EasyMobile.AdPlacement::op_Inequality(placement, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0042;\n\tv92 = this->klass;\n\tv79 = this->klass->vtable[48];\n\tv77 = this->klass->vtable[48];\n\t// 59 IndirectJump v79 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), placement @ X1 (EasyMobile.AdPlacement), v77 @ X2_v2, v79 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0042:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void HideBannerAd(AdPlacement placement)
		{
			//IL_003a: Expected I, but got O
			//IL_004a: Expected O, but got I
			//IL_005a: Expected O, but got I
			if (CheckInitialize() && placement != null)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+430]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+438]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v79 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0xA434C4", Offset = "0xA434C4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFB468]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E92]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[69];\n\tv59 = this->klass->vtable[69];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void DestroyBannerAd()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+580]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+588]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0xA43540", Offset = "0xA43540", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB7E20]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E93]) = v41;\nL_0015:\n\t;\n\tv47 = EasyMobile.AdClientImpl::CheckInitialize(this, 1);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0042;\n\tgoto L_002C;\n\tv69 = *([v52 @ X0_v5+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_002C;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v52, v43, v46, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv59 = EasyMobile.AdPlacement::op_Inequality(placement, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0042;\n\tv92 = this->klass;\n\tv79 = this->klass->vtable[49];\n\tv77 = this->klass->vtable[49];\n\t// 59 IndirectJump v79 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), placement @ X1 (EasyMobile.AdPlacement), v77 @ X2_v2, v79 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0042:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void DestroyBannerAd(AdPlacement placement)
		{
			//IL_003a: Expected I, but got O
			//IL_004a: Expected O, but got I
			//IL_005a: Expected O, but got I
			if (CheckInitialize() && placement != null)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+440]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+448]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v79 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0xA435FC", Offset = "0xA435FC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDD2F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E94]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[71];\n\tv59 = this->klass->vtable[71];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LoadInterstitialAd()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+5A0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+5A8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0xA43678", Offset = "0xA43678", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EFC7E8]);\n\tv23 = *([v22 @ X8_v43]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E95]) = v41;\nL_001A:\n\tv47 = EasyMobile.AdClientImpl::get_IsSdkAvail(this);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0077;\n\tv52 = EasyMobile.AdPlacement;\n\tv54 = *([v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv55 = v54 == 0;\n\tif (v55) goto L_0028;\n\tv69 = *([v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v69) goto L_00AB;\nL_0028:\n\tv72 = placement == 0;\n\tif (v72) goto L_0037;\nL_002A:\n\tv87 = placement->klass;\n\tv92 = EasyMobile.AdPlacement::Equals(placement, 0);\n\tv94 = v92 == 0;\n\tif (v94) goto L_0095;\nL_0037:\n\t// 55 NewArr v105 @ X0_v14 (System.Object[]), typeof(System.Object[]), 1\n\tv156 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 68 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v156 @ X0_v16 (EasyMobile.AdNetwork)\n\tv189 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v189 @ X8_v22+160])(this, this, *([v189 @ X8_v22+168]), *([v87 @ X8_v35 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v189 @ X8_v22+168]), *([v87 @ X8_v35 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv207 = this == 0;\n\tif (v207) goto L_005D;\n\t// 89 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_005D:\n\tv215 = v105.Length == 0;\n\tif (v215) goto L_00B2;\n\tv105[0] = this;\n\tgoto L_0071;\n\tv236 = *([v229 @ X0_v32+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_0071;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v229, v211, v95, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0071:\n\tUnityEngine.Debug::LogFormat(\"Cannot load {0} interstitial ad at placement: null\", v105);\n\tgoto L_008F;\nL_0077:\n\tv60 = EasyMobile.AdClientImpl::get_NoSdkMessage(this);\n\tgoto L_0088;\n\tv73 = *([v64 @ X8_v8+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0088;\n\tv106 = v64;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v106, v59, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0088:\n\tUnityEngine.Debug::Log(v60);\nL_008F:\n\treturn;\nL_0095:\n\tv126 = EasyMobile.AdClientImpl::CheckInitialize(this, 1);\n\tv131 = v126 == 0;\n\tif (v131) goto L_008F;\n\tv127 = EasyMobile.AdClientImpl::IsInterstitialAdReady(this, placement);\n\tv186 = v127 == 0;\n\tv132 = ~v186;\n\tif (v132) goto L_008F;\n\tthis = EasyMobile.AdClientImpl::InternalLoadInterstitialAd(this, placement);\n\tgoto L_008F;\nL_00AB:\n\tv149 = placement == 0;\n\tv85 = ~v149;\n\tif (v85) goto L_002A;\n\tgoto L_0037;\n\tthrow System.NullReferenceException;\n\tv206 = new System.NullReferenceException();\nL_00B2:\n\tv219 = new System.IndexOutOfRangeException();\n\tgoto L_00B7;\n\tv235 = new System.ArrayTypeMismatchException();\nL_00B7:\n\tthrow v234;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LoadInterstitialAd(AdPlacement placement)
		{
			//IL_0013: Expected I, but got O
			//IL_0090: Expected I, but got O
			if (IsSdkAvail)
			{
				IntPtr intPtr = (IntPtr)typeof(AdPlacement);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if ((object)placement != null)
						{
							goto IL_0088;
						}
						goto IL_00bb;
					}
				}
				if ((object)placement != null)
				{
					goto IL_0088;
				}
				goto IL_00bb;
			}
			string noSdkMessage = NoSdkMessage;
			Debug.Log(noSdkMessage);
			return;
			IL_00bb:
			object[] array = new object[1];
			AdNetwork network = Network;
			AdClientImpl adClientImpl = (AdClientImpl)(object)network;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v189 @ X8_v22+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			if (array.Length != 0)
			{
				array[0] = this;
				Debug.LogFormat("Cannot load {0} interstitial ad at placement: null", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0088:
			IntPtr intPtr2 = (IntPtr)placement;
			if (placement.Equals(null))
			{
				goto IL_00bb;
			}
			if (CheckInitialize() && !IsInterstitialAdReady(placement))
			{
				InternalLoadInterstitialAd(placement);
			}
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0xA438BC", Offset = "0xA438BC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA67E0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E96]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[73];\n\tv59 = this->klass->vtable[73];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn X0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool IsInterstitialAdReady()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+5C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+5C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0xA43938", Offset = "0xA43938", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB4C10]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E97]) = v41;\nL_0015:\n\t;\n\tv47 = EasyMobile.AdClientImpl::CheckInitialize(this, 0);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0043;\n\tgoto L_002C;\n\tv70 = *([v52 @ X0_v6+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002C;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v52, v44, v46, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv59 = EasyMobile.AdPlacement::op_Inequality(placement, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0043;\n\tv93 = this->klass;\n\tv80 = this->klass->vtable[51];\n\tv78 = this->klass->vtable[51];\n\t// 59 IndirectJump v80 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), placement @ X1 (EasyMobile.AdPlacement), v78 @ X2_v2, v80 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0043:\n\treturn 0;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool IsInterstitialAdReady(AdPlacement placement)
		{
			//IL_003a: Expected I, but got O
			//IL_004a: Expected O, but got I
			//IL_005a: Expected O, but got I
			if (CheckInitialize(logMessage: false) && placement != null)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+460]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+468]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v80 @ X3_v1 (should have been resolved before IL gen)");
			}
			return false;
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0xA439F8", Offset = "0xA439F8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE9B18]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E98]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[75];\n\tv59 = this->klass->vtable[75];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void ShowInterstitialAd()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+5E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+5E8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0xA43A74", Offset = "0xA43A74", Length = "0x364")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EAB478]);\n\tv27 = *([v26 @ X8_v68]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, placement, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021E99]) = v45;\nL_001C:\n\tv51 = EasyMobile.AdClientImpl::get_IsSdkAvail(this);\n\tv53 = v51 == 0;\n\tif (v53) goto L_0079;\n\tv56 = EasyMobile.AdPlacement;\n\tv58 = *([v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv59 = v58 == 0;\n\tif (v59) goto L_002A;\n\tv73 = *([v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v73) goto L_00AE;\nL_002A:\n\tv76 = placement == 0;\n\tif (v76) goto L_0039;\nL_002C:\n\tv91 = placement->klass;\n\tv96 = EasyMobile.AdPlacement::Equals(placement, 0);\n\tv98 = v96 == 0;\n\tif (v98) goto L_0099;\nL_0039:\n\t// 57 NewArr v109 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv188 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 70 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v188 @ X0_v29 (EasyMobile.AdNetwork)\n\tv254 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v254 @ X8_v23+160])(this, this, *([v254 @ X8_v23+168]), *([v91 @ X8_v36 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v254 @ X8_v23+168]), *([v91 @ X8_v36 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv311 = this == 0;\n\tif (v311) goto L_005F;\n\t// 91 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_005F:\n\tv347 = v109.Length == 0;\n\tif (v347) goto L_0112;\n\tv109[0] = this;\n\tgoto L_FFFFFFFF;\n\tv396 = *([v373 @ X0_v37+E0]);\n\tv397 = v396 == 0;\n\tv398 = ~v397;\n\tif (v398) goto L_FFFFFFFF;\n\tv400 = \"il2cpp_codegen_runtime_class_init\"(v373, v342, v99, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0073:\n\tUnityEngine.Debug::LogFormat(*([v168 @ X8_v10 (System.String)]), v151);\n\tgoto L_0093;\nL_0079:\n\tv64 = EasyMobile.AdClientImpl::get_NoSdkMessage(this);\n\tgoto L_008A;\n\tv77 = *([v68 @ X8_v8+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_008A;\n\tv110 = v68;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v110, v63, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_008A:\n\tUnityEngine.Debug::Log(v64);\nL_0093:\n\treturn;\nL_0099:\n\tv157 = EasyMobile.AdClientImpl::CheckInitialize(this, 1);\n\tv161 = v157 == 0;\n\tif (v161) goto L_0093;\n\tv239 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\tv244 = EasyMobile.AdClientImpl::IsInterstitialAdReady(this, placement);\n\tv162 = v244 == 0;\n\tif (v162) goto L_00B6;\n\tthis = EasyMobile.AdClientImpl::InternalShowInterstitialAd(this, placement);\n\tgoto L_0093;\nL_00AE:\n\tv180 = placement == 0;\n\tv89 = ~v180;\n\tif (v89) goto L_002C;\n\tgoto L_0039;\nL_00B6:\n\t// 182 NewArr v253 @ X0_v50 (System.Object[]), typeof(System.Object[]), 2\n\tv284 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 195 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v284 @ X0_v52 (EasyMobile.AdNetwork)\n\tv337 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v337 @ X8_v45+160])(this, this, *([v337 @ X8_v45+168]), *([v239 @ X8_v38 (Il2CppClass<EasyMobile.AdClientImpl>)+5C8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v337 @ X8_v45+168]), *([v239 @ X8_v38 (Il2CppClass<EasyMobile.AdClientImpl>)+5C8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv395 = this == 0;\n\tif (v395) goto L_00DC;\n\t// 216 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_00DC:\n\tv391 = v253.Length == 0;\n\tif (v391) goto L_0112;\n\tv253[0] = this;\n\tgoto L_00EA;\n\tv419 = *([v415 @ X0_v60+E0]);\n\tv420 = v419 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_00EA;\n\tv423 = \"il2cpp_codegen_runtime_class_init\"(v415, v386, v243, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00EA:\n\tv427 = EasyMobile.AdPlacement::GetPrintableName(placement);\n\tv428 = v427 == 0;\n\tif (v428) goto L_00F5;\n\t// 241 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), v427 @ X0_v63 (System.String)\nL_00F5:\n\tv431 = v253.Length < 1;\n\tv385 = ~v431;\n\tv384 = v253.Length - 1;\n\tv382 = v384 == 0;\n\tv432 = ~v385;\n\tv377 = v432 | v382;\n\tif (v377) goto L_0112;\n\tv253[1] = v427;\n\tgoto L_FFFFFFFF;\n\tv439 = *([v435 @ X0_v65+E0]);\n\tv440 = v439 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_FFFFFFFF;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v435, v387, v243, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0073;\nL_0112:\n\tv365 = new System.IndexOutOfRangeException();\n\tgoto L_011A;\n\tthrow System.NullReferenceException;\n\tv310 = new System.NullReferenceException();\n\tv336 = new System.ArrayTypeMismatchException();\nL_011A:\n\tthrow v364;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void ShowInterstitialAd(AdPlacement placement)
		{
			//IL_0013: Expected I, but got O
			//IL_0090: Expected I, but got O
			//IL_01c9: Expected I, but got O
			//IL_0343: Expected O, but got I4
			if (IsSdkAvail)
			{
				IntPtr intPtr = (IntPtr)typeof(AdPlacement);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if ((object)placement != null)
						{
							goto IL_0088;
						}
						goto IL_00bb;
					}
				}
				if ((object)placement != null)
				{
					goto IL_0088;
				}
				goto IL_00bb;
			}
			string noSdkMessage = NoSdkMessage;
			Debug.Log(noSdkMessage);
			return;
			IL_0088:
			IntPtr intPtr2 = (IntPtr)placement;
			if (placement.Equals(null))
			{
				goto IL_00bb;
			}
			if (!CheckInitialize())
			{
				return;
			}
			IntPtr intPtr3 = (IntPtr)this;
			if (IsInterstitialAdReady(placement))
			{
				InternalShowInterstitialAd(placement);
				return;
			}
			object[] array = new object[2];
			AdNetwork network = Network;
			AdClientImpl adClientImpl = (AdClientImpl)(object)network;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v337 @ X8_v45+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			object[] args;
			string format;
			if (array.Length != 0)
			{
				array[0] = this;
				string printableName = AdPlacement.GetPrintableName(placement);
				if (printableName != null)
				{
					adClientImpl = (AdClientImpl)(printableName as object);
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj = array.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = printableName;
					args = array;
					format = "Cannot show {0} interstitial ad at placement {1}: ad is not loaded.";
					goto IL_03df;
				}
			}
			goto IL_03a5;
			IL_03a5:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_00bb:
			object[] array2 = new object[1];
			AdNetwork network2 = Network;
			adClientImpl = (AdClientImpl)(object)network2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v254 @ X8_v23+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			if (array2.Length == 0)
			{
				goto IL_03a5;
			}
			array2[0] = this;
			args = array2;
			format = "Cannot show {0} interstitial ad at placement: null";
			goto IL_03df;
			IL_03df:
			Debug.LogFormat(format, args);
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0xA43EC4", Offset = "0xA43EC4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAAEB8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E9A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[77];\n\tv59 = this->klass->vtable[77];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LoadRewardedAd()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+600]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+608]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0xA43F40", Offset = "0xA43F40", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F004A0]);\n\tv23 = *([v22 @ X8_v43]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E9B]) = v41;\nL_001A:\n\tv47 = EasyMobile.AdClientImpl::get_IsSdkAvail(this);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0077;\n\tv52 = EasyMobile.AdPlacement;\n\tv54 = *([v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv55 = v54 == 0;\n\tif (v55) goto L_0028;\n\tv69 = *([v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v69) goto L_00AB;\nL_0028:\n\tv72 = placement == 0;\n\tif (v72) goto L_0037;\nL_002A:\n\tv87 = placement->klass;\n\tv92 = EasyMobile.AdPlacement::Equals(placement, 0);\n\tv94 = v92 == 0;\n\tif (v94) goto L_0095;\nL_0037:\n\t// 55 NewArr v105 @ X0_v14 (System.Object[]), typeof(System.Object[]), 1\n\tv156 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 68 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v156 @ X0_v16 (EasyMobile.AdNetwork)\n\tv189 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v189 @ X8_v22+160])(this, this, *([v189 @ X8_v22+168]), *([v87 @ X8_v35 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v189 @ X8_v22+168]), *([v87 @ X8_v35 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv207 = this == 0;\n\tif (v207) goto L_005D;\n\t// 89 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_005D:\n\tv215 = v105.Length == 0;\n\tif (v215) goto L_00B2;\n\tv105[0] = this;\n\tgoto L_0071;\n\tv236 = *([v229 @ X0_v32+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_0071;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v229, v211, v95, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0071:\n\tUnityEngine.Debug::LogFormat(\"Cannot load {0} rewarded ad at placement: null\", v105);\n\tgoto L_008F;\nL_0077:\n\tv60 = EasyMobile.AdClientImpl::get_NoSdkMessage(this);\n\tgoto L_0088;\n\tv73 = *([v64 @ X8_v8+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0088;\n\tv106 = v64;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v106, v59, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0088:\n\tUnityEngine.Debug::Log(v60);\nL_008F:\n\treturn;\nL_0095:\n\tv126 = EasyMobile.AdClientImpl::CheckInitialize(this, 1);\n\tv131 = v126 == 0;\n\tif (v131) goto L_008F;\n\tv127 = EasyMobile.AdClientImpl::IsRewardedAdReady(this, placement);\n\tv186 = v127 == 0;\n\tv132 = ~v186;\n\tif (v132) goto L_008F;\n\tthis = EasyMobile.AdClientImpl::InternalLoadRewardedAd(this, placement);\n\tgoto L_008F;\nL_00AB:\n\tv149 = placement == 0;\n\tv85 = ~v149;\n\tif (v85) goto L_002A;\n\tgoto L_0037;\n\tthrow System.NullReferenceException;\n\tv206 = new System.NullReferenceException();\nL_00B2:\n\tv219 = new System.IndexOutOfRangeException();\n\tgoto L_00B7;\n\tv235 = new System.ArrayTypeMismatchException();\nL_00B7:\n\tthrow v234;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LoadRewardedAd(AdPlacement placement)
		{
			//IL_0013: Expected I, but got O
			//IL_0090: Expected I, but got O
			if (IsSdkAvail)
			{
				IntPtr intPtr = (IntPtr)typeof(AdPlacement);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if ((object)placement != null)
						{
							goto IL_0088;
						}
						goto IL_00bb;
					}
				}
				if ((object)placement != null)
				{
					goto IL_0088;
				}
				goto IL_00bb;
			}
			string noSdkMessage = NoSdkMessage;
			Debug.Log(noSdkMessage);
			return;
			IL_00bb:
			object[] array = new object[1];
			AdNetwork network = Network;
			AdClientImpl adClientImpl = (AdClientImpl)(object)network;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v189 @ X8_v22+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			if (array.Length != 0)
			{
				array[0] = this;
				Debug.LogFormat("Cannot load {0} rewarded ad at placement: null", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0088:
			IntPtr intPtr2 = (IntPtr)placement;
			if (placement.Equals(null))
			{
				goto IL_00bb;
			}
			if (CheckInitialize() && !IsRewardedAdReady(placement))
			{
				InternalLoadRewardedAd(placement);
			}
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0xA44184", Offset = "0xA44184", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0F3B8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E9C]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[79];\n\tv59 = this->klass->vtable[79];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn X0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool IsRewardedAdReady()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+620]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+628]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0xA44200", Offset = "0xA44200", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAA840]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E9D]) = v41;\nL_0015:\n\t;\n\tv47 = EasyMobile.AdClientImpl::CheckInitialize(this, 0);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0043;\n\tgoto L_002C;\n\tv70 = *([v52 @ X0_v6+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002C;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v52, v44, v46, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv59 = EasyMobile.AdPlacement::op_Inequality(placement, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0043;\n\tv93 = this->klass;\n\tv80 = this->klass->vtable[54];\n\tv78 = this->klass->vtable[54];\n\t// 59 IndirectJump v80 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), placement @ X1 (EasyMobile.AdPlacement), v78 @ X2_v2, v80 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0043:\n\treturn 0;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool IsRewardedAdReady(AdPlacement placement)
		{
			//IL_003a: Expected I, but got O
			//IL_004a: Expected O, but got I
			//IL_005a: Expected O, but got I
			if (CheckInitialize(logMessage: false) && placement != null)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+490]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v9 (Il2CppClass<EasyMobile.AdClientImpl>)+498]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v80 @ X3_v1 (should have been resolved before IL gen)");
			}
			return false;
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0xA442C0", Offset = "0xA442C0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB2830]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E9E]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.AdPlacement;\nL_0021:\n\tv53 = this->klass;\n\tv57 = v52.Default;\n\tv58 = this->klass->vtable[81];\n\tv59 = this->klass->vtable[81];\n\t// 43 IndirectJump v58 @ X3_v1, this @ X0 (EasyMobile.AdClientImpl), this @ X0 (EasyMobile.AdClientImpl), v57 @ X1_v1 (EasyMobile.AdPlacement), v59 @ X2_v1, v58 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void ShowRewardedAd()
		{
			//IL_000f: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			AdPlacement adPlacement = AdPlacement.Default;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+640]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v1 (Il2CppClass<EasyMobile.AdClientImpl>)+648]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0xA4433C", Offset = "0xA4433C", Length = "0x364")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1F0DC30]);\n\tv27 = *([v26 @ X8_v68]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, placement, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021E9F]) = v45;\nL_001C:\n\tv51 = EasyMobile.AdClientImpl::get_IsSdkAvail(this);\n\tv53 = v51 == 0;\n\tif (v53) goto L_0079;\n\tv56 = EasyMobile.AdPlacement;\n\tv58 = *([v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv59 = v58 == 0;\n\tif (v59) goto L_002A;\n\tv73 = *([v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v73) goto L_00AE;\nL_002A:\n\tv76 = placement == 0;\n\tif (v76) goto L_0039;\nL_002C:\n\tv91 = placement->klass;\n\tv96 = EasyMobile.AdPlacement::Equals(placement, 0);\n\tv98 = v96 == 0;\n\tif (v98) goto L_0099;\nL_0039:\n\t// 57 NewArr v109 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv188 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 70 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v188 @ X0_v29 (EasyMobile.AdNetwork)\n\tv254 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v254 @ X8_v23+160])(this, this, *([v254 @ X8_v23+168]), *([v91 @ X8_v36 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v254 @ X8_v23+168]), *([v91 @ X8_v36 (Il2CppClass<EasyMobile.AdPlacement>)+138]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv311 = this == 0;\n\tif (v311) goto L_005F;\n\t// 91 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_005F:\n\tv347 = v109.Length == 0;\n\tif (v347) goto L_0112;\n\tv109[0] = this;\n\tgoto L_FFFFFFFF;\n\tv396 = *([v373 @ X0_v37+E0]);\n\tv397 = v396 == 0;\n\tv398 = ~v397;\n\tif (v398) goto L_FFFFFFFF;\n\tv400 = \"il2cpp_codegen_runtime_class_init\"(v373, v342, v99, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0073:\n\tUnityEngine.Debug::LogFormat(*([v168 @ X8_v10 (System.String)]), v151);\n\tgoto L_0093;\nL_0079:\n\tv64 = EasyMobile.AdClientImpl::get_NoSdkMessage(this);\n\tgoto L_008A;\n\tv77 = *([v68 @ X8_v8+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_008A;\n\tv110 = v68;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v110, v63, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_008A:\n\tUnityEngine.Debug::Log(v64);\nL_0093:\n\treturn;\nL_0099:\n\tv157 = EasyMobile.AdClientImpl::CheckInitialize(this, 1);\n\tv161 = v157 == 0;\n\tif (v161) goto L_0093;\n\tv239 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\tv244 = EasyMobile.AdClientImpl::IsRewardedAdReady(this, placement);\n\tv162 = v244 == 0;\n\tif (v162) goto L_00B6;\n\tthis = EasyMobile.AdClientImpl::InternalShowRewardedAd(this, placement);\n\tgoto L_0093;\nL_00AE:\n\tv180 = placement == 0;\n\tv89 = ~v180;\n\tif (v89) goto L_002C;\n\tgoto L_0039;\nL_00B6:\n\t// 182 NewArr v253 @ X0_v50 (System.Object[]), typeof(System.Object[]), 2\n\tv284 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 195 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v284 @ X0_v52 (EasyMobile.AdNetwork)\n\tv337 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v337 @ X8_v45+160])(this, this, *([v337 @ X8_v45+168]), *([v239 @ X8_v38 (Il2CppClass<EasyMobile.AdClientImpl>)+628]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v337 @ X8_v45+168]), *([v239 @ X8_v38 (Il2CppClass<EasyMobile.AdClientImpl>)+628]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv395 = this == 0;\n\tif (v395) goto L_00DC;\n\t// 216 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), this @ X0 (EasyMobile.AdClientImpl)\nL_00DC:\n\tv391 = v253.Length == 0;\n\tif (v391) goto L_0112;\n\tv253[0] = this;\n\tgoto L_00EA;\n\tv419 = *([v415 @ X0_v60+E0]);\n\tv420 = v419 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_00EA;\n\tv423 = \"il2cpp_codegen_runtime_class_init\"(v415, v386, v243, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00EA:\n\tv427 = EasyMobile.AdPlacement::GetPrintableName(placement);\n\tv428 = v427 == 0;\n\tif (v428) goto L_00F5;\n\t// 241 IsInst this @ X0 (EasyMobile.AdClientImpl), typeof(System.Object), v427 @ X0_v63 (System.String)\nL_00F5:\n\tv431 = v253.Length < 1;\n\tv385 = ~v431;\n\tv384 = v253.Length - 1;\n\tv382 = v384 == 0;\n\tv432 = ~v385;\n\tv377 = v432 | v382;\n\tif (v377) goto L_0112;\n\tv253[1] = v427;\n\tgoto L_FFFFFFFF;\n\tv439 = *([v435 @ X0_v65+E0]);\n\tv440 = v439 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_FFFFFFFF;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v435, v387, v243, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0073;\nL_0112:\n\tv365 = new System.IndexOutOfRangeException();\n\tgoto L_011A;\n\tthrow System.NullReferenceException;\n\tv310 = new System.NullReferenceException();\n\tv336 = new System.ArrayTypeMismatchException();\nL_011A:\n\tthrow v364;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void ShowRewardedAd(AdPlacement placement)
		{
			//IL_0013: Expected I, but got O
			//IL_0090: Expected I, but got O
			//IL_01c9: Expected I, but got O
			//IL_0343: Expected O, but got I4
			if (IsSdkAvail)
			{
				IntPtr intPtr = (IntPtr)typeof(AdPlacement);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v11 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if ((object)placement != null)
						{
							goto IL_0088;
						}
						goto IL_00bb;
					}
				}
				if ((object)placement != null)
				{
					goto IL_0088;
				}
				goto IL_00bb;
			}
			string noSdkMessage = NoSdkMessage;
			Debug.Log(noSdkMessage);
			return;
			IL_0088:
			IntPtr intPtr2 = (IntPtr)placement;
			if (placement.Equals(null))
			{
				goto IL_00bb;
			}
			if (!CheckInitialize())
			{
				return;
			}
			IntPtr intPtr3 = (IntPtr)this;
			if (IsRewardedAdReady(placement))
			{
				InternalShowRewardedAd(placement);
				return;
			}
			object[] array = new object[2];
			AdNetwork network = Network;
			AdClientImpl adClientImpl = (AdClientImpl)(object)network;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v337 @ X8_v45+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			object[] args;
			string format;
			if (array.Length != 0)
			{
				array[0] = this;
				string printableName = AdPlacement.GetPrintableName(placement);
				if (printableName != null)
				{
					adClientImpl = (AdClientImpl)(printableName as object);
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj = array.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = printableName;
					args = array;
					format = "Cannot show {0} rewarded ad at placement {1}: ad is not loaded.";
					goto IL_03df;
				}
			}
			goto IL_03a5;
			IL_03a5:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_00bb:
			object[] array2 = new object[1];
			AdNetwork network2 = Network;
			adClientImpl = (AdClientImpl)(object)network2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v254 @ X8_v23+160] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			if (this != null)
			{
				adClientImpl = (AdClientImpl)(this as object);
			}
			if (array2.Length == 0)
			{
				goto IL_03a5;
			}
			array2[0] = this;
			args = array2;
			format = "Cannot show {0} rewarded ad at placement: null";
			goto IL_03df;
			IL_03df:
			Debug.LogFormat(format, args);
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0xA446A0", Offset = "0xA446A0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED9400]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EA0]) = v41;\nL_0018:\n\tv45 = new EasyMobile.AdClientImpl+<>c__DisplayClass62_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.placement = placement;\n\tv52 = new System.Action();\n\tSystem.Action::.ctor(v52, v45, Il2CppMethodInfo);\n\tgoto L_003F;\n\tv87 = *([v63 @ X0_v8+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_003F;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v63, v57, v60, v58, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v52);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual void OnInterstitialAdCompleted(AdPlacement placement)
		{
			Action action = delegate
			{
				//IL_0045: Expected O, but got I
				IAdClient arg = this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X1_v1 (EasyMobile.IAdClient)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X1_v1 (EasyMobile.IAdClient)+18]");
					((Action<IAdClient, AdPlacement>)0)(arg, placement);
				}
			};
			RuntimeHelper.RunOnMainThread(action);
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0xA44774", Offset = "0xA44774", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA4650]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EA1]) = v41;\nL_0018:\n\tv45 = new EasyMobile.AdClientImpl+<>c__DisplayClass63_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.placement = placement;\n\tv52 = new System.Action();\n\tSystem.Action::.ctor(v52, v45, Il2CppMethodInfo);\n\tgoto L_003F;\n\tv87 = *([v63 @ X0_v8+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_003F;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v63, v57, v60, v58, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v52);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnRewardedAdSkipped(AdPlacement placement)
		{
			Action action = delegate
			{
				//IL_0045: Expected O, but got I
				IAdClient arg = this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X1_v1 (EasyMobile.IAdClient)+20]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X1_v1 (EasyMobile.IAdClient)+20]");
					((Action<IAdClient, AdPlacement>)0)(arg, placement);
				}
			};
			RuntimeHelper.RunOnMainThread(action);
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0xA44848", Offset = "0xA44848", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED0860]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EA2]) = v41;\nL_0018:\n\tv45 = new EasyMobile.AdClientImpl+<>c__DisplayClass64_0();\n\tSystem.Object::.ctor(v45);\n\tv45.<>4__this = this;\n\tv45.placement = placement;\n\tv52 = new System.Action();\n\tSystem.Action::.ctor(v52, v45, Il2CppMethodInfo);\n\tgoto L_003F;\n\tv87 = *([v63 @ X0_v8+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_003F;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v63, v57, v60, v58, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\tEasyMobile.Internal.RuntimeHelper::RunOnMainThread(v52);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnRewardedAdCompleted(AdPlacement placement)
		{
			Action action = delegate
			{
				//IL_0045: Expected O, but got I
				IAdClient arg = this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X1_v1 (EasyMobile.IAdClient)+28]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X1_v1 (EasyMobile.IAdClient)+28]");
					((Action<IAdClient, AdPlacement>)0)(arg, placement);
				}
			};
			RuntimeHelper.RunOnMainThread(action);
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0xA4491C", Offset = "0xA4491C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1ED2668]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, dict, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2021EA3]) = v41;\nL_001C:\n\tgoto L_0024;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, dict, placement, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = EasyMobile.AdPlacement::op_Inequality(placement, 0);\n\tv59 = dict == 0;\n\tif (v59) goto L_004D;\n\tv61 = v58 == 0;\n\tif (v61) goto L_004D;\n\tv96 = System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>::TryGetValue(dict, placement, &v69 @ stack_-28_v4 (EasyMobile.AdId));\n\tv83 = v69 == 0;\n\tif (v83) goto L_004D;\n\tv80 = EasyMobile.CrossPlatformId::Equals(v69, 0);\n\tv134 = v80 == 0;\n\tv84 = ~v134;\n\tif (v84) goto L_004D;\n\tv138 = EasyMobile.CrossPlatformId::get_Id(v69);\n\tv78 = System.String::IsNullOrEmpty(v138);\n\tv82 = v78 == 0;\n\tif (v82) goto L_005B;\nL_004D:\n\treturnVal1 = v92.Empty;\nL_0054:\n\treturn returnVal1;\nL_005B:\n\treturnVal1 = EasyMobile.CrossPlatformId::get_Id(v69);\n\tgoto L_0054;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual string FindIdForPlacement(Dictionary<AdPlacement, AdId> dict, AdPlacement placement)
		{
			bool flag = placement != null;
			if (dict != null && flag)
			{
				bool flag2 = dict.TryGetValue(placement, out var value);
				if ((object)value != null && !value.Equals(null))
				{
					string id = value.Id;
					if (!string.IsNullOrEmpty(id))
					{
						return value.Id;
					}
				}
			}
			return string.Empty;
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0xA44A5C", Offset = "0xA44A5C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE5AF8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, logMessage, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EA4]) = v41;\nL_001A:\n\tv47 = EasyMobile.AdClientImpl::get_Network(this);\n\tv48 = v47 == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv53 = EasyMobile.AdClientImpl::get_IsInitialized(this);\n\tv56 = v53 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0066;\n\tv60 = logMessage == 0;\n\tif (v60) goto L_0066;\n\tv95 = EasyMobile.AdClientImpl::get_Network(this);\n\t// 53 Box this @ X0 (EasyMobile.AdClientImpl), typeof(EasyMobile.AdNetwork), &v95 @ X0_v9 (EasyMobile.AdNetwork)\n\tv120 = *([this @ X0 (EasyMobile.AdClientImpl)]);\n\t*([v120 @ X8_v10+160])(v124, this, *([v120 @ X8_v10+168]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v120 @ X8_v10+168]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv133 = System.String::Concat(\"Please initialize the \", v124, \" client first.\");\n\tgoto L_005C;\n\tv139 = *([v83 @ X8_v14+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_005C;\n\tv144 = v83;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v144, v131, v62, v64, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005C:\n\tUnityEngine.Debug::Log(v133);\n\tgoto L_0066;\nL_0066:\n\treturn v84;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual bool CheckInitialize(bool logMessage = true)
		{
			bool result;
			if (Network != AdNetwork.None)
			{
				bool isInitialized = IsInitialized;
				bool flag = !isInitialized;
				bool flag2 = !flag;
				result = isInitialized;
				if (!flag2)
				{
					bool flag3 = !logMessage;
					result = isInitialized;
					if (!flag3)
					{
						AdNetwork network = Network;
						AdClientImpl adClientImpl = (AdClientImpl)(object)network;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v120 @ X8_v10+160] (should have been resolved before IL gen)");
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						string text = default(string);
						string message = "Please initialize the " + text + " client first.";
						Debug.Log(message);
						result = isInitialized;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xA42B54", Offset = "0xA42B54", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EC2CB8]);\n\tv27 = *([v26 @ X8_v30]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, dict, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([2021EA5]) = v46;\nL_001B:\n\tv51 = dict == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv56 = System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>::get_Count(dict);\n\tv58 = v56 < 1;\n\tif (v58) goto L_FFFFFFFF;\n\tv160 = new System.Collections.Generic.List`1<EasyMobile.AdPlacement>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::.ctor(v160);\n\tv203 = System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>::GetEnumerator(dict);\nL_004D:\n\tv233 = System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>+Enumerator<EasyMobile.AdPlacement, EasyMobile.AdId>::MoveNext(&v111 @ stack_-98_v2 (System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>+Enumerator<EasyMobile.AdPlacement, EasyMobile.AdId>));\n\tv139 = v233 == 0;\n\tif (v139) goto L_0089;\n\tgoto L_005E;\n\tv241 = *([v235 @ X0_v16+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_005E;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v235, v231, v91, v30, v31, v32, v33, v34, v109, v107, v37, v38, v39, v40, v41, v42);\nL_005E:\n\tv219 = EasyMobile.AdPlacement::op_Inequality(v206, 0);\n\tv224 = v219 == 0;\n\tif (v224) goto L_004D;\n\tgoto L_0070;\n\tv253 = *([v249 @ X0_v20 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv254 = v253 == 0;\n\tv255 = ~v254;\n\tif (v255) goto L_0070;\n\tv261 = \"il2cpp_codegen_runtime_class_init\"(v249, v214, v91, v30, v31, v32, v33, v34, v109, v107, v37, v38, v39, v40, v41, v42);\n\tv257 = EasyMobile.AdPlacement;\nL_0070:\n\tv220 = EasyMobile.AdPlacement::op_Inequality(v206, v230.Default);\n\tv225 = v220 == 0;\n\tif (v225) goto L_004D;\n\tv263 = v160 == 0;\n\tif (v263) goto L_008C;\n\tv221 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::Contains(v160, v206);\n\tv268 = v221 == 0;\n\tv226 = ~v268;\n\tif (v226) goto L_004D;\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::Add(v160, v206);\n\tgoto L_004D;\n\tgoto L_00B3;\nL_0089:\n\tv136 = System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>+Enumerator<EasyMobile.AdPlacement, EasyMobile.AdId>::Dispose(&v111 @ stack_-98_v2 (System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>+Enumerator<EasyMobile.AdPlacement, EasyMobile.AdId>));\n\tgoto L_00B3;\nL_008C:\n\tv266 = new System.NullReferenceException();\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\nL_009C:\n\tv114 = v230.Default != 1;\n\tif (v114) goto L_00B4;\n\tv270 = 0x6D2BC0(v266, v230.Default, v91, v30, v31, v32, v33, v34, v206, v111, v37, v38, v39, v40, v41, v42);\n\tv272 = 0x6D2490(v270, v230.Default, v91, v30, v31, v32, v33, v34, v206, v111, v37, v38, v39, v40, v41, v42);\n\tv135 = System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>+Enumerator<EasyMobile.AdPlacement, EasyMobile.AdId>::Dispose(&v111 @ stack_-98_v2 (System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>+Enumerator<EasyMobile.AdPlacement, EasyMobile.AdId>));\n\tv278 = *([v270 @ X0_v30]) == 0;\n\tv138 = ~v278;\n\tif (v138) goto L_00B8;\nL_00B3:\n\treturn v146;\nL_00B4:\n\tv271 = 0x6D2380(v266, v230.Default, v91, v30, v31, v32, v33, v34, v206, v111, v37, v38, v39, v40, v41, v42);\nL_00B8:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected List<AdPlacement> GetCustomPlacementsFromDefinedDict(Dictionary<AdPlacement, AdId> dict)
		{
			List<AdPlacement> result;
			if (dict != null)
			{
				int count = dict.Count;
				if (count >= 1)
				{
					List<AdPlacement> list = new List<AdPlacement>();
					Dictionary<AdPlacement, AdId>.Enumerator enumerator = dict.GetEnumerator();
					Dictionary<AdPlacement, AdId>.Enumerator enumerator2 = default(Dictionary<AdPlacement, AdId>.Enumerator);
					AdPlacement adPlacement = default(AdPlacement);
					object obj = default(object);
					while (true)
					{
						if (enumerator2.MoveNext())
						{
							if (!(adPlacement != null) || !(adPlacement != AdPlacement.Default))
							{
								continue;
							}
							if (list != null)
							{
								bool flag = list.Contains(adPlacement);
								bool flag2 = !flag;
								bool flag3 = !flag2;
								IntPtr intPtr = (IntPtr)0;
								if (!flag3)
								{
									list.Add(adPlacement);
									intPtr = (IntPtr)0;
								}
								continue;
							}
							NullReferenceException ex = new NullReferenceException();
							if ((IntPtr)AdPlacement.Default == (IntPtr)1)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								enumerator2.Dispose();
								bool flag4 = obj == null;
								bool flag5 = !flag4;
								result = list;
								if (!flag5)
								{
									break;
								}
							}
							else
							{
								Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							}
							return (List<AdPlacement>)(object)new TypeLoadException();
						}
						enumerator2.Dispose();
						result = list;
						break;
					}
					goto IL_01a4;
				}
			}
			result = null;
			goto IL_01a4;
			IL_01a4:
			return result;
		}

		[Token(Token = "0x600014B")]
		[Address(RVA = "0xA44DC0", Offset = "0xA44DC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.AdClientImpl::set_DataPrivacyConsent(this, 1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void GrantDataPrivacyConsent()
		{
			DataPrivacyConsent = ConsentStatus.Granted;
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0xA44DC8", Offset = "0xA44DC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.AdClientImpl::set_DataPrivacyConsent(this, 2);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void RevokeDataPrivacyConsent()
		{
			DataPrivacyConsent = ConsentStatus.Revoked;
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0xA44DD0", Offset = "0xA44DD0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.AdClientImpl::get_DataPrivacyConsentSaveKey(this);\n\tv27 = EasyMobile.Internal.StorageUtil::GetInt(v10, 0xFFFFFFFF);\n\tv38 = v27 != 0;\n\tif (v38) goto L_FFFFFFFF;\n\tv41 = 1 + 1;\n\tgoto L_001B;\nL_001B:\n\tv42 = v27 + 1;\n\tv44 = v42 == 0;\n\tv47 = ~v44;\n\tif (v47) goto L_FFFFFFFF;\n\tgoto L_0029;\nL_0029:\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual ConsentStatus ReadDataPrivacyConsent()
		{
			string dataPrivacyConsentSaveKey = DataPrivacyConsentSaveKey;
			int num = StorageUtil.GetInt(dataPrivacyConsentSaveKey, -1);
			int result = ((num != 0) ? 1 : (1 + 1));
			if (num + 1 == 0)
			{
				return default(ConsentStatus);
			}
			return (ConsentStatus)result;
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0xA44E4C", Offset = "0xA44E4C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = EasyMobile.AdClientImpl::get_DataPrivacyConsentSaveKey(this);\n\tv34 = consent - 2;\n\tv36 = v34 == 0;\n\tv41 = ~v36;\n\tv47 = consent == 0;\n\tv52 = ~v47;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_002B;\nL_002B:\n\tEasyMobile.Internal.StorageUtil::SetInt(v15, v56);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SaveDataPrivacyConsent(ConsentStatus consent)
		{
			string dataPrivacyConsentSaveKey = DataPrivacyConsentSaveKey;
			int num = (int)(consent - 2);
			bool flag = num == 0;
			bool flag2 = !flag;
			int value = ((consent == ConsentStatus.Unknown) ? (-1) : (flag2 ? 1 : 0));
			StorageUtil.SetInt(dataPrivacyConsentSaveKey, value);
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0xA44EA8", Offset = "0xA44EA8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = EasyMobile.AdClientImpl::get_DataPrivacyConsent(v38);\n\tv28 = v13 == 0;\n\tif (v28) goto L_0011;\n\tv29 = *([v38 @ X0_v2 (EasyMobile.AdClientImpl)]);\n\tv34 = *([v29 @ X8_v6 (Il2CppClass<EasyMobile.AdClientImpl>)+6A0]);\n\tv40 = *([v29 @ X8_v6 (Il2CppClass<EasyMobile.AdClientImpl>)+6A8]);\n\tgoto L_0024;\nL_0011:\n\tv33 = EasyMobile.AdvertisingConsentManager::get_Instance();\n\tv66 = EasyMobile.ConsentManager::get_DataPrivacyConsent(v33);\n\tv67 = v66 == 0;\n\tif (v67) goto L_0026;\n\tv72 = EasyMobile.AdvertisingConsentManager::get_Instance();\nL_001D:\n\tv45 = *([v38 @ X0_v2 (EasyMobile.AdClientImpl)]);\n\tv34 = *([v45 @ X8_v5 (Il2CppClass<EasyMobile.AdClientImpl>)+1C0]);\n\tv40 = *([v45 @ X8_v5 (Il2CppClass<EasyMobile.AdClientImpl>)+1C8]);\nL_0024:\n\t// 36 IndirectJump v34 @ X2_v1, v38 @ X0_v2 (EasyMobile.AdClientImpl), v38 @ X0_v2 (EasyMobile.AdClientImpl), v40 @ X1_v2, v34 @ X2_v1, v15 @ X3, v16 @ X4, v17 @ X5, v18 @ X6, v19 @ X7, v20 @ V0, v21 @ V1, v22 @ V2, v23 @ V3, v24 @ V4, v25 @ V5, v26 @ V6, v27 @ V7\nL_0026:\n\tv71 = EasyMobile.GlobalConsentManager::get_Instance();\n\tv74 = v71 == 0;\n\tv68 = ~v74;\n\tif (v68) goto L_001D;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual ConsentStatus GetApplicableDataPrivacyConsent()
		{
			//IL_002c: Expected I, but got O
			//IL_003c: Expected O, but got I
			//IL_004c: Expected O, but got I
			//IL_00a4: Expected I, but got O
			//IL_00b4: Expected O, but got I
			//IL_00c4: Expected O, but got I
			//IL_0110: Expected I4, but got O
			if (DataPrivacyConsent != ConsentStatus.Unknown)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X8_v6 (Il2CppClass<EasyMobile.AdClientImpl>)+6A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X8_v6 (Il2CppClass<EasyMobile.AdClientImpl>)+6A8]");
				object obj2 = 0;
			}
			else
			{
				AdvertisingConsentManager instance = AdvertisingConsentManager.Instance;
				if (instance.DataPrivacyConsent != ConsentStatus.Unknown)
				{
					AdvertisingConsentManager instance2 = AdvertisingConsentManager.Instance;
					AdClientImpl adClientImpl = (AdClientImpl)(object)instance2;
				}
				else
				{
					GlobalConsentManager instance3 = GlobalConsentManager.Instance;
					bool flag = instance3 == null;
					bool flag2 = !flag;
					AdClientImpl adClientImpl = (AdClientImpl)(object)instance3;
					if (!flag2)
					{
						NullReferenceException ex = new NullReferenceException();
						return (ConsentStatus)ex;
					}
				}
				IntPtr intPtr2 = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v5 (Il2CppClass<EasyMobile.AdClientImpl>)+1C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v5 (Il2CppClass<EasyMobile.AdClientImpl>)+1C8]");
				object obj2 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v34 @ X2_v1 (should have been resolved before IL gen)");
			return ConsentStatus.Unknown;
		}

		[Token(Token = "0x6000151")]
		protected abstract void ApplyDataPrivacyConsent(ConsentStatus consent);

		[Token(Token = "0x6000152")]
		[Address(RVA = "0xA44FBC", Offset = "0xA44FBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal AdClientImpl()
		{
		}
	}
}
