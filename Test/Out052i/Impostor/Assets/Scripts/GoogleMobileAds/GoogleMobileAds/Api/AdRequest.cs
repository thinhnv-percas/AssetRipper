using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api.Mediation;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x200003B")]
	public class AdRequest
	{
		[Token(Token = "0x200003C")]
		public class Builder
		{
			[Token(Token = "0x1700001F")]
			[field: Token(Token = "0x40000D9")]
			[field: FieldOffset(Offset = "0x10")]
			internal List<string> TestDevices
			{
				[Token(Token = "0x60002C1")]
				[Address(RVA = "0x1357804", Offset = "0x1357804", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TestDevices>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60002C2")]
				[Address(RVA = "0x135780C", Offset = "0x135780C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TestDevices>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000020")]
			[field: Token(Token = "0x40000DA")]
			[field: FieldOffset(Offset = "0x18")]
			internal HashSet<string> Keywords
			{
				[Token(Token = "0x60002C3")]
				[Address(RVA = "0x1357814", Offset = "0x1357814", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Keywords>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60002C4")]
				[Address(RVA = "0x135781C", Offset = "0x135781C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Keywords>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000021")]
			[field: Token(Token = "0x40000DB")]
			[field: FieldOffset(Offset = "0x20")]
			internal DateTime? Birthday
			{
				[Token(Token = "0x60002C5")]
				[Address(RVA = "0x1357824", Offset = "0x1357824", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Birthday>k__BackingField;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60002C6")]
				[Address(RVA = "0x1357830", Offset = "0x1357830", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Birthday>k__BackingField = value;\n\t*([this @ X0 (GoogleMobileAds.Api.AdRequest+Builder)+28]) = methodInfo;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000022")]
			[field: Token(Token = "0x40000DC")]
			[field: FieldOffset(Offset = "0x30")]
			internal Gender? Gender
			{
				[Token(Token = "0x60002C7")]
				[Address(RVA = "0x1357838", Offset = "0x1357838", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Gender>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60002C8")]
				[Address(RVA = "0x1357840", Offset = "0x1357840", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Gender>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000023")]
			[field: Token(Token = "0x40000DD")]
			[field: FieldOffset(Offset = "0x38")]
			internal bool? ChildDirectedTreatmentTag
			{
				[Token(Token = "0x60002C9")]
				[Address(RVA = "0x1357848", Offset = "0x1357848", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ChildDirectedTreatmentTag>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60002CA")]
				[Address(RVA = "0x1357850", Offset = "0x1357850", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ChildDirectedTreatmentTag>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000024")]
			[field: Token(Token = "0x40000DE")]
			[field: FieldOffset(Offset = "0x40")]
			internal Dictionary<string, string> Extras
			{
				[Token(Token = "0x60002CB")]
				[Address(RVA = "0x1357858", Offset = "0x1357858", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Extras>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60002CC")]
				[Address(RVA = "0x1357860", Offset = "0x1357860", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Extras>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000025")]
			[field: Token(Token = "0x40000DF")]
			[field: FieldOffset(Offset = "0x48")]
			internal List<MediationExtras> MediationExtras
			{
				[Token(Token = "0x60002CD")]
				[Address(RVA = "0x1357868", Offset = "0x1357868", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MediationExtras>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x60002CE")]
				[Address(RVA = "0x1357870", Offset = "0x1357870", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MediationExtras>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x60002C0")]
			[Address(RVA = "0x13576A4", Offset = "0x13576A4", Length = "0x160")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv70 = System.Collections.Generic.Dictionary`2<System.String, System.String>;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv80 = System.Collections.Generic.HashSet`1<System.String>;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv95 = System.Collections.Generic.List`1<GoogleMobileAds.Api.Mediation.MediationExtras>;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv100 = System.Collections.Generic.List`1<System.String>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v100, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62);\n\tv66 = 1;\n\t*([1A368E8]) = v66;\nL_003F:\n\tSystem.Object::.ctor(this);\n\tv73 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v73);\n\tthis.<TestDevices>k__BackingField = v73;\n\tv83 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v83);\n\tthis.<Keywords>k__BackingField = v83;\n\tthis.<Birthday>k__BackingField = 0;\n\t*([this @ X0 (GoogleMobileAds.Api.AdRequest+Builder)+28]) = 0;\n\tthis.<Gender>k__BackingField = 0;\n\tthis.<ChildDirectedTreatmentTag>k__BackingField = 0;\n\tv93 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v93);\n\tthis.<Extras>k__BackingField = v93;\n\tv102 = new System.Collections.Generic.List`1<GoogleMobileAds.Api.Mediation.MediationExtras>();\n\tSystem.Collections.Generic.List`1<GoogleMobileAds.Api.Mediation.MediationExtras>::.ctor(v102);\n\tthis.<MediationExtras>k__BackingField = v102;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder()
			{
				List<string> list = new List<string>();
				TestDevices = list;
				Keywords = new HashSet<string>();
				Birthday = null;
				_ = 0;
				Gender = null;
				ChildDirectedTreatmentTag = null;
				Extras = new Dictionary<string, string>();
				MediationExtras = new List<MediationExtras>();
			}

			[Token(Token = "0x60002CF")]
			[Address(RVA = "0x1357878", Offset = "0x1357878", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, keyword, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A368E9]) = v36;\nL_0019:\n\tv43 = System.Collections.Generic.HashSet`1<System.String>::Add(this.<Keywords>k__BackingField, keyword);\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder AddKeyword(string keyword)
			{
				bool flag = Keywords.Add(keyword);
				return this;
			}

			[Token(Token = "0x60002D0")]
			[Address(RVA = "0x13578D8", Offset = "0x13578D8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, deviceId, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A368EA]) = v36;\nL_0012:\n\tv37 = this.<TestDevices>k__BackingField;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv53 = v37._size;\n\tv55 = v37._size < v42.Length;\n\tv56 = ~v55;\n\tif (v56) goto L_0034;\n\tv64 = v37._size + 1;\n\tv37._size = v64;\n\tv42[v53 @ X10_v4 (System.Int32)] = deviceId;\n\tgoto L_003B;\nL_0034:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v37, deviceId);\nL_003B:\n\treturn this;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder AddTestDevice(string deviceId)
			{
				List<string> list = TestDevices;
				string[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = deviceId;
				}
				else
				{
					list.Add(deviceId);
				}
				return this;
			}

			[Token(Token = "0x60002D1")]
			[Address(RVA = "0x135797C", Offset = "0x135797C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = GoogleMobileAds.Api.AdRequest;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368EB]) = v37;\nL_0014:\n\tv39 = new GoogleMobileAds.Api.AdRequest();\n\tGoogleMobileAds.Api.AdRequest::.ctor(v39, this);\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AdRequest Build()
			{
				return new AdRequest(this);
			}

			[Token(Token = "0x60002D2")]
			[Address(RVA = "0x13579D4", Offset = "0x13579D4", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, birthday, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A368EC]) = v40;\nL_0018:\n\tv43 = 0;\n\tSystem.Nullable`1<System.DateTime>::.ctor(&v43 @ stack_-40_v1 (System.Nullable`1<System.DateTime>), birthday);\n\tthis.<Birthday>k__BackingField = 0;\n\treturn this;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder SetBirthday(DateTime birthday)
			{
				DateTime? dateTime = null;
				dateTime = birthday;
				Birthday = null;
				return this;
			}

			[Token(Token = "0x60002D3")]
			[Address(RVA = "0x1357A48", Offset = "0x1357A48", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, gender, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A368ED]) = v40;\nL_0018:\n\tv43 = 0;\n\tSystem.Nullable`1<System.Int32Enum>::.ctor(&v43 @ stack_-28_v1 (System.Nullable`1<System.Int32Enum>), gender);\n\tthis.<Gender>k__BackingField = 0;\n\treturn this;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder SetGender(Gender gender)
			{
				System.Int32Enum? int32Enum = null;
				int32Enum = (System.Int32Enum)gender;
				Gender = null;
				return this;
			}

			[Token(Token = "0x60002D4")]
			[Address(RVA = "0x1357AB4", Offset = "0x1357AB4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, extras, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A368EE]) = v36;\nL_0012:\n\tv37 = this.<MediationExtras>k__BackingField;\n\tv42 = v37._items;\n\tv44 = v37._version + 1;\n\tv37._version = v44;\n\tv53 = v37._size;\n\tv55 = v37._size < v42.Length;\n\tv56 = ~v55;\n\tif (v56) goto L_0034;\n\tv64 = v37._size + 1;\n\tv37._size = v64;\n\tv42[v53 @ X10_v4 (System.Int32)] = extras;\n\tgoto L_003B;\nL_0034:\n\tSystem.Collections.Generic.List`1<GoogleMobileAds.Api.Mediation.MediationExtras>::AddWithResize(v37, extras);\nL_003B:\n\treturn this;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder AddMediationExtras(MediationExtras extras)
			{
				List<MediationExtras> list = MediationExtras;
				MediationExtras[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = extras;
				}
				else
				{
					list.Add(extras);
				}
				return this;
			}

			[Token(Token = "0x60002D5")]
			[Address(RVA = "0x1357B58", Offset = "0x1357B58", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, tagForChildDirectedTreatment, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A368EF]) = v40;\nL_0018:\n\tv44 = 0;\n\tSystem.Nullable`1<System.Boolean>::.ctor(&v44 @ stack_-24_v1 (System.Nullable`1<System.Boolean>), tagForChildDirectedTreatment);\n\tthis.<ChildDirectedTreatmentTag>k__BackingField = 0;\n\treturn this;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder TagForChildDirectedTreatment(bool tagForChildDirectedTreatment)
			{
				bool? flag = null;
				flag = tagForChildDirectedTreatment;
				ChildDirectedTreatmentTag = null;
				return this;
			}

			[Token(Token = "0x60002D6")]
			[Address(RVA = "0x1357BC4", Offset = "0x1357BC4", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, key, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A368F0]) = v39;\nL_001C:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(this.<Extras>k__BackingField, key, value);\n\treturn this;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder AddExtra(string key, string value)
			{
				Extras.Add(key, value);
				return this;
			}
		}

		[Token(Token = "0x40000D0")]
		public const string Version = "5.4.0";

		[Token(Token = "0x40000D1")]
		public const string TestDeviceSimulator = "SIMULATOR";

		[CompilerGenerated]
		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x10")]
		private List<string> _003CTestDevices_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x18")]
		private HashSet<string> _003CKeywords_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x30")]
		private Gender? _003CGender_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x38")]
		private bool? _003CTagForChildDirectedTreatment_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x40")]
		private Dictionary<string, string> _003CExtras_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x48")]
		private List<MediationExtras> _003CMediationExtras_003Ek__BackingField;

		[Token(Token = "0x17000018")]
		public List<string> TestDevices
		{
			[CompilerGenerated]
			[Token(Token = "0x60002B2")]
			[Address(RVA = "0x1357630", Offset = "0x1357630", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TestDevices>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TestDevices;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002B3")]
			[Address(RVA = "0x1357638", Offset = "0x1357638", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TestDevices>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTestDevices_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000019")]
		public HashSet<string> Keywords
		{
			[CompilerGenerated]
			[Token(Token = "0x60002B4")]
			[Address(RVA = "0x1357640", Offset = "0x1357640", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Keywords>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Keywords;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002B5")]
			[Address(RVA = "0x1357648", Offset = "0x1357648", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Keywords>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CKeywords_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001A")]
		[field: Token(Token = "0x40000D4")]
		[field: FieldOffset(Offset = "0x20")]
		public DateTime? Birthday
		{
			[Token(Token = "0x60002B6")]
			[Address(RVA = "0x1357650", Offset = "0x1357650", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Birthday>k__BackingField;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60002B7")]
			[Address(RVA = "0x135765C", Offset = "0x135765C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Birthday>k__BackingField = value;\n\t*([this @ X0 (GoogleMobileAds.Api.AdRequest)+28]) = methodInfo;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700001B")]
		public Gender? Gender
		{
			[CompilerGenerated]
			[Token(Token = "0x60002B8")]
			[Address(RVA = "0x1357664", Offset = "0x1357664", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Gender>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Gender;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002B9")]
			[Address(RVA = "0x135766C", Offset = "0x135766C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Gender>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CGender_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001C")]
		public bool? TagForChildDirectedTreatment
		{
			[CompilerGenerated]
			[Token(Token = "0x60002BA")]
			[Address(RVA = "0x1357674", Offset = "0x1357674", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TagForChildDirectedTreatment>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TagForChildDirectedTreatment;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002BB")]
			[Address(RVA = "0x135767C", Offset = "0x135767C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TagForChildDirectedTreatment>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTagForChildDirectedTreatment_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001D")]
		public Dictionary<string, string> Extras
		{
			[CompilerGenerated]
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0x1357684", Offset = "0x1357684", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Extras>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Extras;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0x135768C", Offset = "0x135768C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Extras>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CExtras_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001E")]
		public List<MediationExtras> MediationExtras
		{
			[CompilerGenerated]
			[Token(Token = "0x60002BE")]
			[Address(RVA = "0x1357694", Offset = "0x1357694", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MediationExtras>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MediationExtras;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002BF")]
			[Address(RVA = "0x135769C", Offset = "0x135769C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MediationExtras>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMediationExtras_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0x13574DC", Offset = "0x13574DC", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, builder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv51 = System.Collections.Generic.Dictionary`2<System.String, System.String>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, builder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, builder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv74 = System.Collections.Generic.HashSet`1<System.String>;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, builder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv80 = Il2CppMethodInfo;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, builder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv114 = System.Collections.Generic.List`1<System.String>;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, builder, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A368E7]) = v47;\nL_0028:\n\tSystem.Object::.ctor(this);\n\tv71 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v71, builder.<TestDevices>k__BackingField);\n\tthis.<TestDevices>k__BackingField = v71;\n\tv84 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v84, builder.<Keywords>k__BackingField);\n\tthis.<Keywords>k__BackingField = v84;\n\tthis.<Birthday>k__BackingField = builder.<Birthday>k__BackingField;\n\tthis.<Gender>k__BackingField = builder.<Gender>k__BackingField;\n\tthis.<TagForChildDirectedTreatment>k__BackingField = builder.<ChildDirectedTreatmentTag>k__BackingField;\n\tv104 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v104, builder.<Extras>k__BackingField);\n\tthis.<Extras>k__BackingField = v104;\n\tthis.<MediationExtras>k__BackingField = builder.<MediationExtras>k__BackingField;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AdRequest(Builder builder)
		{
			//IL_0013: Expected I4, but got O
			//IL_0084: Expected I4, but got O
			base._002Ector();
			TestDevices = new List<string>((int)builder.TestDevices);
			Keywords = new HashSet<string>((IEqualityComparer<string>)builder.Keywords);
			Birthday = builder.Birthday;
			Gender = builder.Gender;
			TagForChildDirectedTreatment = builder.ChildDirectedTreatmentTag;
			Extras = new Dictionary<string, string>((int)builder.Extras);
			MediationExtras = builder.MediationExtras;
		}
	}
}
