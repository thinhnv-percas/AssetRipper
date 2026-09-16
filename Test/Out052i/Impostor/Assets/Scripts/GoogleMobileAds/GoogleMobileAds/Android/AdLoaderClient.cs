using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x2000013")]
	public class AdLoaderClient : AndroidJavaProxy, IAdLoaderClient
	{
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x20")]
		private AndroidJavaObject adLoader;

		[CompilerGenerated]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<CustomNativeClientEventArgs> m_OnCustomNativeTemplateAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<CustomNativeClientEventArgs> m_OnCustomNativeTemplateAdClicked;

		[Token(Token = "0x1400001A")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x600008A")]
			[Address(RVA = "0x13432C4", Offset = "0x13432C4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3678C]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
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
			[Token(Token = "0x600008B")]
			[Address(RVA = "0x1343374", Offset = "0x1343374", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3678D]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
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

		[Token(Token = "0x1400001B")]
		public event EventHandler<CustomNativeClientEventArgs> OnCustomNativeTemplateAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x600008C")]
			[Address(RVA = "0x1343424", Offset = "0x1343424", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3678E]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
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
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
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
			[Token(Token = "0x600008D")]
			[Address(RVA = "0x13434D4", Offset = "0x13434D4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3678F]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
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
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
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

		[Token(Token = "0x1400001C")]
		public event EventHandler<CustomNativeClientEventArgs> OnCustomNativeTemplateAdClicked
		{
			[CompilerGenerated]
			[Token(Token = "0x600008E")]
			[Address(RVA = "0x1343584", Offset = "0x1343584", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36790]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdClicked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
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
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
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
			[Token(Token = "0x600008F")]
			[Address(RVA = "0x1343634", Offset = "0x1343634", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36791]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdClicked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
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
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
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

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x133E578", Offset = "0x133E578", Length = "0x510")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0064;\n\tv32 = UnityEngine.AndroidJavaClass;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv75 = UnityEngine.AndroidJavaObject;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv80 = UnityEngine.AndroidJavaProxy;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv86 = Il2CppMethodInfo;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv90 = System.Boolean;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv236 = Il2CppMethodInfo;\n\tv237 = \"il2cpp_codegen_initialize_runtime_metadata\"(v236, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv291 = Il2CppMethodInfo;\n\tv292 = \"il2cpp_codegen_initialize_runtime_metadata\"(v291, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv338 = Il2CppMethodInfo;\n\tv339 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv344 = Il2CppMethodInfo;\n\tv345 = \"il2cpp_codegen_initialize_runtime_metadata\"(v344, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv350 = Il2CppMethodInfo;\n\tv351 = \"il2cpp_codegen_initialize_runtime_metadata\"(v350, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv364 = Il2CppMethodInfo;\n\tv365 = \"il2cpp_codegen_initialize_runtime_metadata\"(v364, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv381 = Il2CppMethodInfo;\n\tv382 = \"il2cpp_codegen_initialize_runtime_metadata\"(v381, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv393 = System.Object[];\n\tv394 = \"il2cpp_codegen_initialize_runtime_metadata\"(v393, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv401 = \"com.google.unity.ads.UnityAdLoaderListener\";\n\tv402 = \"il2cpp_codegen_initialize_runtime_metadata\"(v401, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv413 = \"com.unity3d.player.UnityPlayer\";\n\tv414 = \"il2cpp_codegen_initialize_runtime_metadata\"(v413, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv453 = \"create\";\n\tv454 = \"il2cpp_codegen_initialize_runtime_metadata\"(v453, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv466 = \"com.google.unity.ads.NativeAdLoader\";\n\tv467 = \"il2cpp_codegen_initialize_runtime_metadata\"(v466, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv522 = \"configureCustomNativeTemplateAd\";\n\tv523 = \"il2cpp_codegen_initialize_runtime_metadata\"(v522, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv533 = \"configureReturnUrlsForImageAssets\";\n\tv534 = \"il2cpp_codegen_initialize_runtime_metadata\"(v533, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv538 = \"currentActivity\";\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v538, args, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A36792]) = v51;\nL_0064:\n\tgoto L_0069;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v52, args, methodInfo, v35, v36, v37, v38, v39, v53, v41, v42, v43, v44, v45, v46, v47);\nL_0069:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.google.unity.ads.UnityAdLoaderListener\");\n\tv78 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v78, \"com.unity3d.player.UnityPlayer\");\n\tv101 = UnityEngine.AndroidJavaObject::GetStatic(v78, \"currentActivity\");\n\t// 128 NewArr v201 @ X0_v44 (System.Object[]), typeof(System.Object[]), 3\n\tv340 = v101 == 0;\n\tif (v340) goto L_008F;\n\t// 137 IsInst v321 @ X0_v87, typeof(System.Object), v101 @ X0_v42 (System.Object)\n\tv325 = v321 == 0;\n\tif (v325) goto L_0179;\nL_008F:\n\tv201[0] = v101;\n\tv366 = args.<AdUnitId>k__BackingField == 0;\n\tif (v366) goto L_00A8;\n\t// 152 IsInst v322 @ X0_v85, typeof(System.Object), args.<AdUnitId>k__BackingField (System.String)\n\tv326 = v322 == 0;\n\tif (v326) goto L_0179;\nL_00A8:\n\tv201[1] = args.<AdUnitId>k__BackingField;\n\tv395 = this == 0;\n\tif (v395) goto L_00C0;\n\t// 174 IsInst v323 @ X0_v83, typeof(System.Object), this @ X0 (GoogleMobileAds.Android.AdLoaderClient)\n\tv327 = v323 == 0;\n\tif (v327) goto L_0179;\nL_00C0:\n\tv201[2] = this;\n\tv419 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v419, \"com.google.unity.ads.NativeAdLoader\", v201);\n\tthis.adLoader = v419;\n\tv435 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::Contains(args.<AdTypes>k__BackingField, 0);\n\tv438 = v435 == 0;\n\tif (v438) goto L_013F;\n\tv545 = System.Collections.Generic.Dictionary`2<System.String, System.Boolean>::GetEnumerator(args.<TemplateIds>k__BackingField);\nL_00EC:\n\tv575 = System.Collections.Generic.Dictionary`2<System.Object, System.Boolean>+Enumerator<System.Object, System.Boolean>::MoveNext(&v544 @ stack_-A8_v5 (System.Collections.Generic.Dictionary`2<System.Object, System.Boolean>+Enumerator<System.Object, System.Boolean>));\n\tv437 = v575 == 0;\n\tif (v437) goto L_0137;\n\tv585 = v578 == 0;\n\tv590 = ~v585;\n\t// 256 NewArr v592 @ X0_v59 (System.Object[]), typeof(System.Object[]), 2\n\tv595 = v546 == 0;\n\tif (v595) goto L_010F;\n\t// 265 IsInst v618 @ X0_v81, typeof(System.Object), v546 @ stack_-98\n\tv622 = v618 == 0;\n\tif (v622) goto L_0171;\nL_010F:\n\tv592[0] = v546;\n\t// 275 Box v644 @ X0_v72, typeof(System.Boolean), &v590 @ TEMPCOND_v11 (System.Boolean)\n\tv661 = v644 == 0;\n\tif (v661) goto L_012A;\n\t// 282 IsInst v667 @ X0_v79, typeof(System.Object), v644 @ X0_v72\n\tv670 = v667 == 0;\n\tif (v670) goto L_0174;\nL_012A:\n\tv592[1] = v644;\n\tUnityEngine.AndroidJavaObject::Call(this.adLoader, \"configureCustomNativeTemplateAd\", v592);\n\tgoto L_00EC;\nL_0137:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Boolean>+Enumerator<System.Object, System.Boolean>::Dispose(&v544 @ stack_-A8_v5 (System.Collections.Generic.Dictionary`2<System.Object, System.Boolean>+Enumerator<System.Object, System.Boolean>));\nL_013F:\n\tgoto L_0148;\n\tv456 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::Contains(Il2CppMethodInfo, v198);\nL_0148:\n\tgoto L_014D;\n\tv468 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::Contains(v460, v198, v191);\nL_014D:\n\tgoto L_0155;\n\tv525 = \"il2cpp_codegen_runtime_class_init\"(v469, v198, v191, v181, v36, v37, v38, v39, v173, v170, v42, v43, v44, v45, v46, v47);\nL_0155:\n\tgoto L_0160;\n\tv536 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Api.NativeAdType>::Contains(v528, v198, v191);\nL_0160:\n\tUnityEngine.AndroidJavaObject::Call(v439.adLoader, \"create\", v516.Value);\n\treturn;\n\tv677 = new System.IndexOutOfRangeException();\n\tv609 = new System.NullReferenceException();\n\tv614 = new System.NullReferenceException();\n\tv641 = new System.IndexOutOfRangeException();\nL_0171:\n\tv660 = new System.ArrayTypeMismatchException();\n\tthrow v660;\nL_0174:\n\tv676 = new System.ArrayTypeMismatchException();\n\tthrow v676;\n\tv234 = new System.NullReferenceException();\n\tv289 = new System.IndexOutOfRangeException();\nL_0179:\n\tv336 = new System.ArrayTypeMismatchException();\n\tthrow v336;\n\tgoto L_018C;\n\tgoto L_018C;\n\tgoto L_018C;\n\tgoto L_018C;\n\tgoto L_018C;\nL_018C:\n\tif (1) goto L_019B;\n\tv368 = UnityEngine.AndroidJavaObject::GetStatic(v342, 0, v315);\n\tv378 = *([v368 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv387 = UnityEngine.AndroidJavaObject::GetStatic(v368, 0, v315);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Boolean>+Enumerator<System.Ob\n// ... truncated")]
		public AdLoaderClient(AdLoaderClientArgs args)
			: base("com.google.unity.ads.UnityAdLoaderListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			object obj = androidJavaClass.GetStatic<object>("currentActivity");
			object[] array = new object[3];
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					goto IL_036e;
				}
			}
			array[0] = obj;
			if (args.AdUnitId != null)
			{
				object obj3 = args.AdUnitId as object;
				if (obj3 == null)
				{
					goto IL_036e;
				}
			}
			array[1] = args.AdUnitId;
			if (this != null)
			{
				object obj4 = this as object;
				if (obj4 == null)
				{
					goto IL_036e;
				}
			}
			array[2] = this;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.unity.ads.NativeAdLoader", array);
			adLoader = androidJavaObject;
			bool flag = args.AdTypes.Contains(default(NativeAdType));
			bool flag2 = !flag;
			NativeAdType nativeAdType = default(NativeAdType);
			AdLoaderClient adLoaderClient = this;
			if (!flag2)
			{
				Dictionary<string, bool>.Enumerator enumerator = args.TemplateIds.GetEnumerator();
				Dictionary<object, bool>.Enumerator enumerator2 = default(Dictionary<object, bool>.Enumerator);
				object obj5 = default(object);
				object obj6 = default(object);
				while (enumerator2.MoveNext())
				{
					bool flag3 = obj5 == null;
					bool flag4 = !flag3;
					object[] array2 = new object[2];
					if (obj6 != null)
					{
						object obj7 = obj6 as object;
						if (obj7 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					array2[0] = obj6;
					object obj8 = flag4;
					if (obj8 != null)
					{
						object obj9 = obj8 as object;
						if (obj9 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					array2[1] = obj8;
					adLoader.Call("configureCustomNativeTemplateAd", array2);
				}
				enumerator2.Dispose();
				nativeAdType = NativeAdType.CustomTemplate;
				adLoaderClient = this;
			}
			adLoaderClient.adLoader.Call("create");
			return;
			IL_036e:
			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
			throw ex3;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x13436E4", Offset = "0x13436E4", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Object[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, request, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = \"loadAd\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, request, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A36793]) = v41;\nL_001B:\n\t// 27 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = GoogleMobileAds.Android.Utils::GetAdRequestJavaObject(request);\n\tv53 = v50 == 0;\n\tif (v53) goto L_002D;\n\t// 39 IsInst v67 @ X0_v16, typeof(System.Object), v50 @ X0_v5 (UnityEngine.AndroidJavaObject)\n\tv69 = v67 == 0;\n\tif (v69) goto L_0040;\nL_002D:\n\tv45[0] = v50;\n\tUnityEngine.AndroidJavaObject::Call(this.adLoader, \"loadAd\", v45);\n\treturn;\n\tv63 = new System.NullReferenceException();\n\tv77 = new System.IndexOutOfRangeException();\nL_0040:\n\tv83 = new System.ArrayTypeMismatchException();\n\tthrow v83;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			object[] array = new object[1];
			AndroidJavaObject adRequestJavaObject = Utils.GetAdRequestJavaObject(request);
			if (adRequestJavaObject != null)
			{
				object obj = adRequestJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = adRequestJavaObject;
			adLoader.Call("loadAd", array);
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x1344E40", Offset = "0x1344E40", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = GoogleMobileAds.Common.CustomNativeClientEventArgs;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, ad, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv43 = GoogleMobileAds.Android.CustomNativeTemplateClient;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, ad, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A36794]) = v39;\nL_0017:\n\tv41 = this.OnCustomNativeTemplateAdLoaded == 0;\n\tif (v41) goto L_0040;\n\tv49 = new GoogleMobileAds.Common.CustomNativeClientEventArgs();\n\tGoogleMobileAds.Common.CustomNativeClientEventArgs::.ctor(v49);\n\tv86 = new GoogleMobileAds.Android.CustomNativeTemplateClient();\n\tSystem.Object::.ctor(v86);\n\tv86.customNativeAd = ad;\n\tv87 = v49 == 0;\n\tif (v87) goto L_0041;\n\tv49.<nativeAdClient>k__BackingField = v86;\n\tv49.<assetName>k__BackingField = 0;\n\tv74 = this.OnCustomNativeTemplateAdLoaded == 0;\n\tif (v74) goto L_0041;\n\tSystem.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>::Invoke(this.OnCustomNativeTemplateAdLoaded, this, v49);\nL_0040:\n\treturn;\nL_0041:\n\tthrow v86;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onCustomTemplateAdLoaded(AndroidJavaObject ad)
		{
			if (this.OnCustomNativeTemplateAdLoaded == null)
			{
				return;
			}
			CustomNativeClientEventArgs e = new CustomNativeClientEventArgs();
			CustomNativeTemplateClient customNativeTemplateClient = new CustomNativeTemplateClient(ad);
			if (e != null)
			{
				e.nativeAdClient = customNativeTemplateClient;
				e.assetName = null;
				if (this.OnCustomNativeTemplateAdLoaded != null)
				{
					this.OnCustomNativeTemplateAdLoaded(this, e);
					return;
				}
			}
			throw customNativeTemplateClient;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x1344F88", Offset = "0x1344F88", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = GoogleMobileAds.Api.AdFailedToLoadEventArgs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, errorReason, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A36795]) = v40;\nL_0016:\n\tv42 = new GoogleMobileAds.Api.AdFailedToLoadEventArgs();\n\tGoogleMobileAds.Api.AdFailedToLoadEventArgs::.ctor(v42);\n\tv42.<Message>k__BackingField = errorReason;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>::Invoke(this.OnAdFailedToLoad, this, v42);\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdFailedToLoad(string errorReason)
		{
			AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs();
			e.Message = errorReason;
			this.OnAdFailedToLoad(this, e);
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x134500C", Offset = "0x134500C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = GoogleMobileAds.Common.CustomNativeClientEventArgs;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, ad, assetName, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = GoogleMobileAds.Android.CustomNativeTemplateClient;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, ad, assetName, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A36796]) = v42;\nL_0019:\n\tv44 = this.OnCustomNativeTemplateAdClicked == 0;\n\tif (v44) goto L_0044;\n\tv52 = new GoogleMobileAds.Common.CustomNativeClientEventArgs();\n\tGoogleMobileAds.Common.CustomNativeClientEventArgs::.ctor(v52);\n\tv92 = new GoogleMobileAds.Android.CustomNativeTemplateClient();\n\tSystem.Object::.ctor(v92);\n\tv92.customNativeAd = ad;\n\tv93 = v52 == 0;\n\tif (v93) goto L_0045;\n\tv52.<nativeAdClient>k__BackingField = v92;\n\tv52.<assetName>k__BackingField = assetName;\n\tv78 = this.OnCustomNativeTemplateAdClicked == 0;\n\tif (v78) goto L_0045;\n\tSystem.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>::Invoke(this.OnCustomNativeTemplateAdClicked, this, v52);\nL_0044:\n\treturn;\nL_0045:\n\tthrow v92;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onCustomClick(AndroidJavaObject ad, string assetName)
		{
			if (this.OnCustomNativeTemplateAdClicked == null)
			{
				return;
			}
			CustomNativeClientEventArgs e = new CustomNativeClientEventArgs();
			CustomNativeTemplateClient customNativeTemplateClient = new CustomNativeTemplateClient(ad);
			if (e != null)
			{
				e.nativeAdClient = customNativeTemplateClient;
				e.assetName = assetName;
				if (this.OnCustomNativeTemplateAdClicked != null)
				{
					this.OnCustomNativeTemplateAdClicked(this, e);
					return;
				}
			}
			throw customNativeTemplateClient;
		}
	}
}
