using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000033")]
	public class AdLoader
	{
		[Token(Token = "0x2000034")]
		public class Builder
		{
			[Token(Token = "0x1700000F")]
			[field: Token(Token = "0x40000B5")]
			[field: FieldOffset(Offset = "0x10")]
			internal string AdUnitId
			{
				[Token(Token = "0x600027A")]
				[Address(RVA = "0x1355C10", Offset = "0x1355C10", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdUnitId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x600027B")]
				[Address(RVA = "0x1355C18", Offset = "0x1355C18", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdUnitId>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000010")]
			[field: Token(Token = "0x40000B6")]
			[field: FieldOffset(Offset = "0x18")]
			internal HashSet<NativeAdType> AdTypes
			{
				[Token(Token = "0x600027C")]
				[Address(RVA = "0x1355C20", Offset = "0x1355C20", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdTypes>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x600027D")]
				[Address(RVA = "0x1355C28", Offset = "0x1355C28", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdTypes>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000011")]
			[field: Token(Token = "0x40000B7")]
			[field: FieldOffset(Offset = "0x20")]
			internal HashSet<string> TemplateIds
			{
				[Token(Token = "0x600027E")]
				[Address(RVA = "0x1355C30", Offset = "0x1355C30", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TemplateIds>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x600027F")]
				[Address(RVA = "0x1355C38", Offset = "0x1355C38", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TemplateIds>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000012")]
			[field: Token(Token = "0x40000B8")]
			[field: FieldOffset(Offset = "0x28")]
			internal Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers
			{
				[Token(Token = "0x6000280")]
				[Address(RVA = "0x1355C40", Offset = "0x1355C40", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CustomNativeTemplateClickHandlers>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x6000281")]
				[Address(RVA = "0x1355C48", Offset = "0x1355C48", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CustomNativeTemplateClickHandlers>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x6000279")]
			[Address(RVA = "0x1355AF8", Offset = "0x1355AF8", Length = "0x118")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, adUnitId, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv65 = System.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, adUnitId, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, adUnitId, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, adUnitId, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv80 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, adUnitId, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv85 = System.Collections.Generic.HashSet`1<System.String>;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, adUnitId, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A368C8]) = v61;\nL_0035:\n\tSystem.Object::.ctor(this);\n\tthis.<AdUnitId>k__BackingField = adUnitId;\n\tv68 = new System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>();\n\tSystem.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::.ctor(v68);\n\tthis.<AdTypes>k__BackingField = v68;\n\tv78 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v78);\n\tthis.<TemplateIds>k__BackingField = v78;\n\tv87 = new System.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>::.ctor(v87);\n\tthis.<CustomNativeTemplateClickHandlers>k__BackingField = v87;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder(string adUnitId)
			{
				AdUnitId = adUnitId;
				HashSet<NativeAdType> hashSet = new HashSet<NativeAdType>();
				AdTypes = hashSet;
				TemplateIds = new HashSet<string>();
				CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>();
			}

			[Token(Token = "0x6000282")]
			[Address(RVA = "0x1355C50", Offset = "0x1355C50", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, templateId, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, templateId, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A368C9]) = v37;\nL_001C:\n\tv46 = System.Collections.Generic.HashSet`1<System.String>::Add(this.<TemplateIds>k__BackingField, templateId);\n\tv59 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::Add(this.<AdTypes>k__BackingField, 0);\n\treturn this;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder ForCustomNativeAd(string templateId)
			{
				bool flag = TemplateIds.Add(templateId);
				bool flag2 = AdTypes.Add(default(NativeAdType));
				return this;
			}

			[Token(Token = "0x6000283")]
			[Address(RVA = "0x1355CD8", Offset = "0x1355CD8", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, templateId, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, templateId, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv67 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, templateId, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A368CA]) = v40;\nL_0021:\n\tv50 = System.Collections.Generic.HashSet`1<System.String>::Add(this.<TemplateIds>k__BackingField, templateId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>::set_Item(this.<CustomNativeTemplateClickHandlers>k__BackingField, templateId, callback);\n\tv90 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::Add(this.<AdTypes>k__BackingField, 0);\n\treturn this;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder ForCustomNativeAd(string templateId, Action<CustomNativeTemplateAd, string> callback)
			{
				bool flag = TemplateIds.Add(templateId);
				CustomNativeTemplateClickHandlers[templateId] = callback;
				bool flag2 = AdTypes.Add(default(NativeAdType));
				return this;
			}

			[Token(Token = "0x6000284")]
			[Address(RVA = "0x1355D98", Offset = "0x1355D98", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = GoogleMobileAds.Api.AdLoader;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368CB]) = v37;\nL_0014:\n\tv39 = new GoogleMobileAds.Api.AdLoader();\n\tGoogleMobileAds.Api.AdLoader::.ctor(v39, this);\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AdLoader Build()
			{
				return new AdLoader(this);
			}
		}

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x10")]
		private IAdLoaderClient adLoaderClient;

		[CompilerGenerated]
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<CustomNativeEventArgs> m_OnCustomNativeTemplateAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary<string, Action<CustomNativeTemplateAd, string>> _003CCustomNativeTemplateClickHandlers_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x30")]
		private string _003CAdUnitId_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x38")]
		private HashSet<NativeAdType> _003CAdTypes_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x40")]
		private HashSet<string> _003CTemplateIds_003Ek__BackingField;

		[Token(Token = "0x1700000B")]
		public Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers
		{
			[CompilerGenerated]
			[Token(Token = "0x600026D")]
			[Address(RVA = "0x135570C", Offset = "0x135570C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CustomNativeTemplateClickHandlers>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomNativeTemplateClickHandlers;
			}
			[CompilerGenerated]
			[Token(Token = "0x600026E")]
			[Address(RVA = "0x1355714", Offset = "0x1355714", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CustomNativeTemplateClickHandlers>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CCustomNativeTemplateClickHandlers_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000C")]
		public string AdUnitId
		{
			[CompilerGenerated]
			[Token(Token = "0x600026F")]
			[Address(RVA = "0x135571C", Offset = "0x135571C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdUnitId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdUnitId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000270")]
			[Address(RVA = "0x1355724", Offset = "0x1355724", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdUnitId>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CAdUnitId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000D")]
		public HashSet<NativeAdType> AdTypes
		{
			[CompilerGenerated]
			[Token(Token = "0x6000271")]
			[Address(RVA = "0x135572C", Offset = "0x135572C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdTypes>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdTypes;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000272")]
			[Address(RVA = "0x1355734", Offset = "0x1355734", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdTypes>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CAdTypes_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000E")]
		public HashSet<string> TemplateIds
		{
			[CompilerGenerated]
			[Token(Token = "0x6000273")]
			[Address(RVA = "0x135573C", Offset = "0x135573C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TemplateIds>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TemplateIds;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000274")]
			[Address(RVA = "0x1355744", Offset = "0x1355744", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TemplateIds>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTemplateIds_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1400007D")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000269")]
			[Address(RVA = "0x135544C", Offset = "0x135544C", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368C1]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
				Delegate obj2 = this.m_OnAdFailedToLoad;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdFailedToLoadEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600026A")]
			[Address(RVA = "0x13554FC", Offset = "0x13554FC", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368C2]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
				Delegate obj2 = this.m_OnAdFailedToLoad;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdFailedToLoadEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400007E")]
		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x600026B")]
			[Address(RVA = "0x13555AC", Offset = "0x13555AC", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.CustomNativeEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368C3]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.CustomNativeEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600026C")]
			[Address(RVA = "0x135565C", Offset = "0x135565C", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.CustomNativeEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368C4]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.CustomNativeEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000268")]
		[Address(RVA = "0x1354D14", Offset = "0x1354D14", Length = "0x6AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006E;\n\tv34 = GoogleMobileAds.Common.AdLoaderClientArgs;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv326 = Il2CppMethodInfo;\n\tv327 = \"il2cpp_codegen_initialize_runtime_metadata\"(v326, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv332 = Il2CppMethodInfo;\n\tv333 = \"il2cpp_codegen_initialize_runtime_metadata\"(v332, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv349 = Il2CppMethodInfo;\n\tv350 = \"il2cpp_codegen_initialize_runtime_metadata\"(v349, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv366 = Il2CppMethodInfo;\n\tv367 = \"il2cpp_codegen_initialize_runtime_metadata\"(v366, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv374 = Il2CppMethodInfo;\n\tv375 = \"il2cpp_codegen_initialize_runtime_metadata\"(v374, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv382 = System.Collections.Generic.Dictionary`2<System.String, System.Boolean>;\n\tv383 = \"il2cpp_codegen_initialize_runtime_metadata\"(v382, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv418 = System.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>;\n\tv419 = \"il2cpp_codegen_initialize_runtime_metadata\"(v418, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv459 = Il2CppMethodInfo;\n\tv460 = \"il2cpp_codegen_initialize_runtime_metadata\"(v459, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv472 = Il2CppMethodInfo;\n\tv473 = \"il2cpp_codegen_initialize_runtime_metadata\"(v472, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv476 = Il2CppMethodInfo;\n\tv477 = \"il2cpp_codegen_initialize_runtime_metadata\"(v476, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv575 = Il2CppMethodInfo;\n\tv576 = \"il2cpp_codegen_initialize_runtime_metadata\"(v575, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv583 = Il2CppMethodInfo;\n\tv584 = \"il2cpp_codegen_initialize_runtime_metadata\"(v583, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv612 = Il2CppMethodInfo;\n\tv613 = \"il2cpp_codegen_initialize_runtime_metadata\"(v612, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv648 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv649 = \"il2cpp_codegen_initialize_runtime_metadata\"(v648, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv673 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv674 = \"il2cpp_codegen_initialize_runtime_metadata\"(v673, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv702 = Il2CppMethodInfo;\n\tv703 = \"il2cpp_codegen_initialize_runtime_metadata\"(v702, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv708 = Il2CppMethodInfo;\n\tv709 = \"il2cpp_codegen_initialize_runtime_metadata\"(v708, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv712 = Il2CppMethodInfo;\n\tv713 = \"il2cpp_codegen_initialize_runtime_metadata\"(v712, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv715 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>;\n\tv716 = \"il2cpp_codegen_initialize_runtime_metadata\"(v715, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv722 = System.Collections.Generic.HashSet`1<System.String>;\n\tv723 = \"il2cpp_codegen_initialize_runtime_metadata\"(v722, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv754 = GoogleMobileAds.Common.IAdLoaderClient;\n\tv755 = \"il2cpp_codegen_initialize_runtime_metadata\"(v754, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv778 = GoogleMobileAds.IClientFactory;\n\tv779 = \"il2cpp_codegen_initialize_runtime_metadata\"(v778, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv796 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v796, builder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A368C0]) = v53;\nL_006E:\n\tSystem.Object::.ctor(this);\n\tv66 = builder == 0;\n\tif (v66) goto L_01EB;\n\tv88 = System.String::Copy(builder.<AdUnitId>k__BackingField);\n\tthis.<AdUnitId>k__BackingField = v88;\n\tv330 = new System.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>::.ctor(v330, builder.<CustomNativeTemplateClickHandlers>k__BackingField);\n\tthis.<CustomNativeTemplateClickHandlers>k__BackingField = v330;\n\tv353 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v353, builder.<TemplateIds>k__BackingField);\n\tthis.<TemplateIds>k__BackingField = v353;\n\tv378 = new System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>();\n\tSystem.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::.ctor(v378, builder.<AdTypes>k__BackingField);\n\tthis.<AdTypes>k__BackingField = v378;\n\tv421 = new System.Collections.Generic.Dictionary`2<System.String, System.Boolean>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Boolean>::.ctor(v421);\n\tv293 = this.<TemplateIds>k__BackingField == 0;\n\tif (v293) goto L_01EB;\n\tv501 = System.Collections.Generic.HashSet`1<System.String>::GetEnumerator(this.<TemplateIds>k__BackingField);\nL_00C2:\n\tv597 = System.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>::MoveNext(&v500 @ stack_-D8_v6 (System.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>));\n\tv610 = v597 == 0;\n\tif (v610) goto L_00D0;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Boolean>::set_Item(v421, v579, 0);\n\tgoto L_00C2;\nL_00D0:\n\tSystem.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>::Dispose(&v500 @ stack_-D8_v6 (System.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>));\nL_00D2:\n\tv294 = this.<CustomNativeTemplateClickHandlers>k__BackingField == 0;\n\tif (v294) goto L_01EB;\n\tv646 = System.Collections.Generic.Dictionary`2<System.String, System.Action`2<GoogleMobileAds.Api.CustomNativeTemplateAd, System.String>>::GetEnumerator(this.<CustomNativeTemplateClickHandlers>k__BackingField);\nL_00DF:\n\tv700 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v429 @ stack_-D8_v5 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv436 = v700 == 0;\n\tif (v436) goto L_00ED;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Boolean>::set_Item(v303, v579, 1);\n\tgoto L_00DF;\nL_00ED:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v429 @ stack_-D8_v5 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_00EF:\n\tv286 = new *([v281 @ X22_v3 (Il2CppClass<GoogleMobileAds.Common.AdLoaderClientArgs>)])();\n\tSystem.Object::.ctor(v286);\n\tv295 = v286 == 0;\n\tif (v295) goto L_01EB;\n\t*([v286 @ X0_v34 (System.O\n// ... truncated")]
		private AdLoader(Builder builder)
		{
			//IL_002f: Expected I4, but got O
			//IL_0b75: Expected O, but got I
			//IL_0772: Expected O, but got I
			//IL_0783: Expected O, but got I
			//IL_00db: Expected I, but got O
			//IL_03a8: Expected I, but got O
			//IL_03da: Expected I, but got O
			//IL_0199: Expected I, but got O
			//IL_01aa: Expected I, but got O
			//IL_01b8: Expected I, but got O
			//IL_021d: Expected I, but got O
			//IL_0233: Expected I, but got O
			//IL_0243: Expected I, but got O
			//IL_014f: Expected I, but got O
			//IL_09b7: Expected I, but got O
			//IL_041c: Expected I, but got O
			//IL_044e: Expected I, but got O
			//IL_0464: Expected I, but got O
			//IL_0475: Expected O, but got I
			//IL_0510: Expected O, but got I
			//IL_0a08: Expected I, but got O
			//IL_0a44: Expected I, but got O
			//IL_04b1: Expected O, but got I
			//IL_055c: Expected I, but got O
			//IL_056d: Expected O, but got I
			//IL_051e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0523: Expected O, but got Unknown
			//IL_0540: Expected O, but got I
			//IL_054f: Expected O, but got I
			//IL_0608: Expected O, but got I
			//IL_04c5: Expected O, but got I
			//IL_04d4: Expected O, but got I
			//IL_0afc: Expected I, but got O
			//IL_05a9: Expected O, but got I
			//IL_0654: Expected I, but got O
			//IL_0664: Expected O, but got I
			//IL_0616: Unknown result type (might be due to invalid IL or missing references)
			//IL_061b: Expected O, but got Unknown
			//IL_0638: Expected O, but got I
			//IL_0647: Expected O, but got I
			//IL_06fe: Expected O, but got I
			//IL_05bd: Expected O, but got I
			//IL_05cc: Expected O, but got I
			//IL_069f: Expected O, but got I
			//IL_0711: Expected I4, but got O
			//IL_071f: Expected O, but got I
			//IL_072e: Expected O, but got I
			//IL_06b3: Expected O, but got I
			//IL_06c2: Expected O, but got I
			base._002Ector();
			string text = default(string);
			HashSet<object>.Enumerator enumerator3 = default(HashSet<object>.Enumerator);
			nint num = default(nint);
			nint num2 = default(nint);
			nint num3 = default(nint);
			nint num4 = default(nint);
			nint num5 = default(nint);
			nint num6 = default(nint);
			Builder builder2 = default(Builder);
			nint num7 = default(nint);
			nint num8 = default(nint);
			Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
			string text4 = default(string);
			HashSet<object>.Enumerator enumerator6 = default(HashSet<object>.Enumerator);
			nint num9 = default(nint);
			nint num10 = default(nint);
			nint num11 = default(nint);
			nint num12 = default(nint);
			nint num13 = default(nint);
			Builder builder3 = default(Builder);
			nint num14 = default(nint);
			nint num15;
			string text5;
			HashSet<object>.Enumerator enumerator9;
			IntPtr intPtr6;
			IntPtr intPtr7;
			IntPtr intPtr8;
			IntPtr intPtr9;
			Builder builder4;
			if (builder != null)
			{
				AdUnitId = string.Copy(builder.AdUnitId);
				CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>((int)builder.CustomNativeTemplateClickHandlers);
				HashSet<string> hashSet = (TemplateIds = new HashSet<string>((IEqualityComparer<string>)builder.TemplateIds));
				HashSet<NativeAdType> hashSet2 = (AdTypes = new HashSet<NativeAdType>((IEqualityComparer<NativeAdType>)builder.AdTypes));
				Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
				bool flag = TemplateIds == null;
				enumerator = default(Dictionary<object, object>.Enumerator);
				string text2 = default(string);
				text = text2;
				HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
				enumerator3 = default(HashSet<object>.Enumerator);
				IntPtr intPtr = default(IntPtr);
				num = intPtr;
				num2 = unchecked((nint)null);
				IntPtr intPtr2 = default(IntPtr);
				num3 = intPtr2;
				IntPtr intPtr3 = default(IntPtr);
				num4 = intPtr3;
				IntPtr intPtr4 = default(IntPtr);
				num5 = intPtr4;
				IntPtr intPtr5 = default(IntPtr);
				num6 = intPtr5;
				builder2 = builder;
				num7 = 27484160;
				if (!flag)
				{
					HashSet<string>.Enumerator enumerator4 = TemplateIds.GetEnumerator();
					num8 = 0;
					HashSet<object>.Enumerator enumerator5 = default(HashSet<object>.Enumerator);
					string text3 = default(string);
					while (enumerator5.MoveNext())
					{
						dictionary[text3] = false;
						num8 = unchecked((nint)null);
					}
					enumerator5.Dispose();
					enumerator = default(Dictionary<object, object>.Enumerator);
					text4 = text2;
					enumerator2 = enumerator5;
					enumerator6 = enumerator5;
					num9 = 0;
					num10 = 0;
					num11 = (nint)typeof(EventHandler<CustomNativeClientEventArgs>);
					num12 = (nint)typeof(IAdLoaderClient);
					num13 = (nint)typeof(AdLoaderClientArgs);
					builder3 = (Builder)(object)dictionary;
					num14 = 0;
					bool flag2 = CustomNativeTemplateClickHandlers == null;
					enumerator = default(Dictionary<object, object>.Enumerator);
					text = text2;
					enumerator2 = default(HashSet<object>.Enumerator);
					enumerator3 = default(HashSet<object>.Enumerator);
					num = 0;
					num2 = 0;
					num3 = (nint)typeof(Dictionary<string, bool>);
					num4 = 0;
					num5 = 0;
					num6 = (nint)hashSet;
					builder2 = (Builder)(object)dictionary;
					num7 = (nint)hashSet2;
					if (!flag2)
					{
						Dictionary<string, Action<CustomNativeTemplateAd, string>>.Enumerator enumerator7 = CustomNativeTemplateClickHandlers.GetEnumerator();
						num15 = num8;
						Dictionary<object, object>.Enumerator enumerator8 = default(Dictionary<object, object>.Enumerator);
						while (enumerator8.MoveNext())
						{
							((Dictionary<object, bool>)(object)builder3)[(object)text3] = true;
							num15 = 1;
						}
						enumerator8.Dispose();
						enumerator = enumerator8;
						text5 = text3;
						enumerator9 = (HashSet<object>.Enumerator)enumerator8;
						intPtr6 = num10;
						intPtr7 = num11;
						intPtr8 = num12;
						intPtr9 = num13;
						builder4 = builder3;
						goto IL_02e0;
					}
				}
			}
			goto IL_0733;
			IL_09ef:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v787 @ X0_v41] (should have been resolved before IL gen)");
			IAdLoaderClient adLoaderClient = this.adLoaderClient;
			nint num16 = unchecked((nint)null);
			Il2CppRuntime.Boundary("MANAGED", "Method not found @F456D0 (System.EventHandler`1::.ctor, and 1 more at this address)");
			bool flag3 = this.adLoaderClient == null;
			text = text5;
			enumerator3 = enumerator9;
			num = 0;
			num2 = (nint)this;
			num3 = intPtr6;
			num4 = intPtr7;
			num5 = intPtr8;
			num6 = intPtr9;
			builder2 = (Builder)this.adLoaderClient;
			nint num17;
			num7 = num17;
			if (flag3)
			{
				goto IL_0733;
			}
			nint num18 = (nint)adLoaderClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ X8_v18 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+12E]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ X8_v18 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+12E]");
			if ((nint)0 == 0)
			{
				goto IL_05f4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ X8_v18 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+B0]");
			object obj2 = (nint)0 + (nint)8;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ X10_v18-8]");
				if ((IntPtr)0 == intPtr8)
				{
					break;
				}
				object obj3 = (nint)obj - 1;
				obj2 = (nint)obj2 + 16;
				bool flag4 = (nint)obj != 1;
				obj = obj3;
				if (flag4)
				{
					continue;
				}
				goto IL_05f4;
			}
			object obj4 = (nint)(object)(num18 + (int)((nint)(object)(obj2 + 4) << 4)) + 312;
			goto IL_0aaa;
			IL_04fc:
			((Dictionary<string, bool>)this.adLoaderClient)[(string)(nint)intPtr8] = true;
			goto IL_09ef;
			IL_0733:
			NullReferenceException ex = new NullReferenceException();
			if (num2 == 1)
			{
				((Dictionary<string, bool>)(object)ex)[(string)num2] = (byte)num != 0;
				Dictionary<string, bool> dictionary2 = default(Dictionary<string, bool>);
				dictionary2[(string)num2] = (byte)num != 0;
				enumerator.Dispose();
				bool flag5 = dictionary2 == null;
				text5 = text;
				enumerator9 = enumerator3;
				num15 = num;
				intPtr6 = num3;
				intPtr7 = num4;
				intPtr8 = num5;
				intPtr9 = num6;
				builder4 = builder2;
				if (!flag5)
				{
					throw new OutOfMemoryException();
				}
				goto IL_02e0;
			}
			string key = (string)num7;
			enumerator.Dispose();
			NullReferenceException ex2 = ex;
			((Dictionary<string, bool>)(object)ex2)[key] = (byte)num != 0;
			((Dictionary<string, bool>)(object)new OutOfMemoryException())[key] = (byte)num != 0;
			return;
			IL_06ea:
			((Dictionary<string, bool>)this.adLoaderClient)[(string)(nint)intPtr8] = false;
			goto IL_0b62;
			IL_05f4:
			((Dictionary<string, bool>)this.adLoaderClient)[(string)(nint)intPtr8] = true;
			goto IL_0aaa;
			IL_0aaa:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v859 @ X0_v46] (should have been resolved before IL gen)");
			IAdLoaderClient adLoaderClient2 = this.adLoaderClient;
			EventHandler<AdFailedToLoadEventArgs> eventHandler = delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
			bool flag6 = this.adLoaderClient == null;
			text = text5;
			enumerator3 = enumerator9;
			num = 0;
			num2 = (nint)this;
			num3 = intPtr6;
			num4 = intPtr7;
			num5 = intPtr8;
			num6 = intPtr9;
			builder2 = (Builder)this.adLoaderClient;
			num7 = num16;
			if (flag6)
			{
				goto IL_0733;
			}
			nint num19 = (nint)adLoaderClient2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ X8_v25 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+12E]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ X8_v25 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+12E]");
			if ((nint)0 == 0)
			{
				goto IL_06ea;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ X8_v25 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+B0]");
			object obj6 = (nint)0 + (nint)8;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ X10_v13-8]");
				if ((IntPtr)0 == intPtr8)
				{
					break;
				}
				object obj7 = (nint)obj5 - 1;
				obj6 = (nint)obj6 + 16;
				bool flag7 = (nint)obj5 != 1;
				obj5 = obj7;
				if (flag7)
				{
					continue;
				}
				goto IL_06ea;
			}
			object obj8 = (nint)(object)(num19 + (obj6 << 4)) + 312;
			goto IL_0b62;
			IL_0b62:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v929 @ X0_v51] (should have been resolved before IL gen)");
			return;
			IL_02e0:
			object obj9 = new object();
			bool flag8 = obj9 == null;
			text = text4;
			enumerator3 = enumerator6;
			num = num8;
			num2 = num9;
			num3 = num10;
			num4 = num11;
			num5 = num12;
			num6 = num13;
			builder2 = builder3;
			num7 = num14;
			if (!flag8)
			{
				_ = AdUnitId;
				_ = AdTypes;
				IClientFactory clientFactory = MobileAds.GetClientFactory();
				bool flag9 = clientFactory == null;
				text = text5;
				enumerator3 = enumerator9;
				num = num15;
				num2 = unchecked((nint)null);
				num3 = intPtr6;
				num4 = intPtr7;
				num5 = intPtr8;
				num6 = intPtr9;
				builder2 = builder4;
				num7 = (nint)obj9;
				if (!flag9)
				{
					IAdLoaderClient adLoaderClient3 = clientFactory.BuildAdLoaderClient((AdLoaderClientArgs)obj9);
					this.adLoaderClient = adLoaderClient3;
					Utils.CheckInitialization();
					IAdLoaderClient adLoaderClient4 = this.adLoaderClient;
					num17 = unchecked((nint)null);
					Il2CppRuntime.Boundary("MANAGED", "Method not found @F456D0 (System.EventHandler`1::.ctor, and 1 more at this address)");
					bool flag10 = this.adLoaderClient == null;
					text = text5;
					enumerator3 = enumerator9;
					num = num15;
					num2 = unchecked((nint)null);
					num3 = intPtr6;
					num4 = intPtr7;
					num5 = intPtr8;
					num6 = intPtr9;
					builder2 = builder4;
					num7 = (nint)obj9;
					if (!flag10)
					{
						nint num20 = (nint)adLoaderClient4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X8_v13 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+12E]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X8_v13 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+12E]");
						if ((nint)0 == 0)
						{
							goto IL_04fc;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ X8_v13 (Il2CppClass<GoogleMobileAds.Common.IAdLoaderClient>)+B0]");
						object obj11 = (nint)0 + (nint)8;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ X10_v23-8]");
							if ((IntPtr)0 == intPtr8)
							{
								break;
							}
							object obj12 = (nint)obj10 - 1;
							obj11 = (nint)obj11 + 16;
							bool flag11 = (nint)obj10 != 1;
							obj10 = obj12;
							if (flag11)
							{
								continue;
							}
							goto IL_04fc;
						}
						object obj13 = (nint)(object)(num20 + (int)((nint)(object)(obj11 + 2) << 4)) + 312;
						goto IL_09ef;
					}
				}
			}
			goto IL_0733;
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0x135574C", Offset = "0x135574C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.IAdLoaderClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, request, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A368C5]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 6;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 6;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IAdLoaderClient::LoadAd(this.adLoaderClient, request);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			adLoaderClient.LoadAd(request);
		}
	}
}
