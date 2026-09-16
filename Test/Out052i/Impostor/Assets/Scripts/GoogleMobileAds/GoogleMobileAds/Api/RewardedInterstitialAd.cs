using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000056")]
	public class RewardedInterstitialAd
	{
		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x10")]
		private IRewardedInterstitialAdClient rewardedInterstitialAdClient;

		[Token(Token = "0x4000139")]
		private static HashSet<IRewardedInterstitialAdClient> loadingClients;

		[CompilerGenerated]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[CompilerGenerated]
		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToPresentFullScreenContent;

		[CompilerGenerated]
		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<EventArgs> m_OnAdDidPresentFullScreenContent;

		[CompilerGenerated]
		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<EventArgs> m_OnAdDidDismissFullScreenContent;

		[Token(Token = "0x1400009A")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000397")]
			[Address(RVA = "0x135D420", Offset = "0x135D420", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3695D]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
				Delegate obj2 = this.m_OnPaidEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdValueEventArgs>);
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
			[Token(Token = "0x6000398")]
			[Address(RVA = "0x135D4D0", Offset = "0x135D4D0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3695E]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
				Delegate obj2 = this.m_OnPaidEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdValueEventArgs>);
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

		[Token(Token = "0x1400009B")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToPresentFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000399")]
			[Address(RVA = "0x135D580", Offset = "0x135D580", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3695F]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnAdFailedToPresentFullScreenContent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdErrorEventArgs>);
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
			[Token(Token = "0x600039A")]
			[Address(RVA = "0x135D630", Offset = "0x135D630", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36960]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnAdFailedToPresentFullScreenContent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdErrorEventArgs>);
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

		[Token(Token = "0x1400009C")]
		public event EventHandler<EventArgs> OnAdDidPresentFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x600039B")]
			[Address(RVA = "0x135D6E0", Offset = "0x135D6E0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36961]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
				Delegate obj2 = this.m_OnAdDidPresentFullScreenContent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
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
			[Token(Token = "0x600039C")]
			[Address(RVA = "0x135D790", Offset = "0x135D790", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36962]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
				Delegate obj2 = this.m_OnAdDidPresentFullScreenContent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
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

		[Token(Token = "0x1400009D")]
		public event EventHandler<EventArgs> OnAdDidDismissFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x600039D")]
			[Address(RVA = "0x135D840", Offset = "0x135D840", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36963]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnAdDidDismissFullScreenContent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
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
			[Token(Token = "0x600039E")]
			[Address(RVA = "0x135D8F0", Offset = "0x135D8F0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36964]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnAdDidDismissFullScreenContent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
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

		[Token(Token = "0x6000396")]
		[Address(RVA = "0x135D1D0", Offset = "0x135D1D0", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv28 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, client, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv51 = System.EventHandler`1<System.EventArgs>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, client, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv56 = GoogleMobileAds.Common.IRewardedInterstitialAdClient;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, client, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, client, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, client, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv161 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v161, client, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3695C]) = v47;\nL_002A:\n\tSystem.Object::.ctor(this);\n\tthis.rewardedInterstitialAdClient = client;\n\tv54 = new System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>::.ctor(v54, this, Il2CppMethodInfo);\n\tgoto L_0067;\n\tv162 = *([v70 @ X8_v4+B0]);\n\tv163 = v162 + 8;\n\tv165 = *([v201 @ X10_v18-8]);\n\tv207 = v165 == v75;\n\tif (v207) goto L_005E;\n\tv187 = v202 - 1;\n\tv185 = v201 + 0x10;\n\tv167 = v202 != 1;\n\tif (v167) goto L_FFFFFFFF;\n\tv188 = 8;\n\tv189 = v20;\n\tv190 = 0xB349B4(v189, v75, v188, v60, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0067;\nL_005E:\n\tv265 = *([v201 @ X10_v18]);\n\tv266 = v265 + 8;\n\tv267 = v266 << 4;\n\tv268 = v70 + v267;\n\tv269 = v268 + 0x138;\nL_0067:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::add_OnAdFailedToPresentFullScreenContent(client, v54);\n\tv143 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v143, this, Il2CppMethodInfo);\n\tgoto L_00A0;\n\tv283 = *([v278 @ X8_v7+B0]);\n\tv284 = v283 + 8;\n\tv286 = *([v322 @ X10_v13-8]);\n\tv328 = v286 == v280;\n\tif (v328) goto L_0097;\n\tv308 = v323 - 1;\n\tv306 = v322 + 0x10;\n\tv288 = v323 != 1;\n\tif (v288) goto L_FFFFFFFF;\n\tv309 = 0xA;\n\tv310 = v149;\n\tv311 = 0xB349B4(v310, v280, v309, v134, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A0;\nL_0097:\n\tv334 = *([v322 @ X10_v13]);\n\tv335 = v334 + 0xA;\n\tv336 = v335 << 4;\n\tv337 = v278 + v336;\n\tv338 = v337 + 0x138;\nL_00A0:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::add_OnAdDidPresentFullScreenContent(this.rewardedInterstitialAdClient, v143);\n\tv144 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v144, this, Il2CppMethodInfo);\n\tgoto L_00DF;\n\tv350 = *([v347 @ X8_v10+B0]);\n\tv351 = v350 + 8;\n\tv353 = *([v389 @ X10_v8-8]);\n\tv395 = v353 == v348;\n\tif (v395) goto L_00CE;\n\tv375 = v390 - 1;\n\tv373 = v389 + 0x10;\n\tv355 = v390 != 1;\n\tif (v355) goto L_FFFFFFFF;\n\tv376 = 0xC;\n\tv377 = v150;\n\tv378 = 0xB349B4(v377, v348, v376, v135, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00DF;\nL_00CE:\n\tv401 = *([v389 @ X10_v8]);\n\tv402 = v401 + 0xC;\n\tv403 = v402 << 4;\n\tv404 = v347 + v403;\n\tv405 = v404 + 0x138;\nL_00DF:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::add_OnAdDidDismissFullScreenContent(this.rewardedInterstitialAdClient, v144);\n\tthrow System.NullReferenceException;\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private RewardedInterstitialAd(IRewardedInterstitialAdClient client)
		{
			rewardedInterstitialAdClient = client;
			EventHandler<AdErrorEventArgs> value = delegate(object sender, AdErrorEventArgs args)
			{
				if (this.OnAdFailedToPresentFullScreenContent != null)
				{
					this.OnAdFailedToPresentFullScreenContent(this, args);
				}
			};
			client.OnAdFailedToPresentFullScreenContent += value;
			EventHandler<EventArgs> value2 = delegate(object sender, EventArgs args)
			{
				if (this.OnAdDidPresentFullScreenContent != null)
				{
					this.OnAdDidPresentFullScreenContent(this, args);
				}
			};
			rewardedInterstitialAdClient.OnAdDidPresentFullScreenContent += value2;
			EventHandler<EventArgs> value3 = delegate(object sender, EventArgs args)
			{
				if (this.OnAdDidDismissFullScreenContent != null)
				{
					this.OnAdDidDismissFullScreenContent(this, args);
				}
			};
			rewardedInterstitialAdClient.OnAdDidDismissFullScreenContent += value3;
		}

		[Token(Token = "0x600039F")]
		[Address(RVA = "0x135D9A0", Offset = "0x135D9A0", Length = "0x38C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv32 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = System.EventHandler`1<System.EventArgs>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv63 = GoogleMobileAds.IClientFactory;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv199 = GoogleMobileAds.Common.IRewardedInterstitialAdClient;\n\tv200 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv202 = GoogleMobileAds.Api.RewardedInterstitialAd;\n\tv203 = \"il2cpp_codegen_initialize_runtime_metadata\"(v202, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv270 = Il2CppMethodInfo;\n\tv271 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv302 = Il2CppMethodInfo;\n\tv303 = \"il2cpp_codegen_initialize_runtime_metadata\"(v302, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv326 = GoogleMobileAds.Api.RewardedInterstitialAd+<>c__DisplayClass15_0;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v326, request, adLoadCallback, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A36965]) = v50;\nL_0033:\n\tv52 = new GoogleMobileAds.Api.RewardedInterstitialAd+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v52);\n\tv52.adLoadCallback = adLoadCallback;\n\tv66 = GoogleMobileAds.Api.MobileAds::GetClientFactory();\n\tgoto L_006E;\n\tv272 = *([v205 @ X8_v4+B0]);\n\tv273 = v272 + 8;\n\tv275 = *([v315 @ X10_v32-8]);\n\tv320 = v275 == v209;\n\tif (v320) goto L_0066;\n\tv295 = v314 - 1;\n\tv297 = v315 + 0x10;\n\tv277 = v314 != 1;\n\tif (v277) goto L_FFFFFFFF;\n\tv298 = 4;\n\tv299 = v181;\n\tv300 = 0xB349B4(v299, v209, v298, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_006E;\nL_0066:\n\tv328 = *([v315 @ X10_v32]);\n\tv329 = v328 + 4;\n\tv330 = v329 << 4;\n\tv331 = v205 + v330;\n\tv332 = v331 + 0x138;\nL_006E:\n\tv337 = GoogleMobileAds.IClientFactory::BuildRewardedInterstitialAdClient(v66);\n\tv52.client = v337;\n\tgoto L_007F;\n\tv342 = \"il2cpp_codegen_runtime_class_init\"(v338, v162, v90, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv344 = GoogleMobileAds.Api.RewardedInterstitialAd;\nL_007F:\n\tv169 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Common.IRewardedInterstitialAdClient>::Add(v186.loadingClients, v52.client);\n\tgoto L_00B4;\n\tv354 = *([v347 @ X8_v11+B0]);\n\tv355 = v354 + 8;\n\tv357 = *([v394 @ X10_v27-8]);\n\tv399 = v357 == v351;\n\tif (v399) goto L_00AC;\n\tv377 = v393 - 1;\n\tv379 = v394 + 0x10;\n\tv359 = v393 != 1;\n\tif (v359) goto L_FFFFFFFF;\n\tv380 = 0xE;\n\tv381 = v182;\n\tv382 = 0xB349B4(v381, v351, v380, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00B4;\nL_00AC:\n\tv405 = *([v394 @ X10_v27]);\n\tv406 = v405 + 0xE;\n\tv407 = v406 << 4;\n\tv408 = v347 + v407;\n\tv409 = v408 + 0x138;\nL_00B4:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::CreateRewardedInterstitialAd(v52.client);\n\tv170 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v170, v52, Il2CppMethodInfo);\n\tgoto L_00EE;\n\tv423 = *([v417 @ X8_v14+B0]);\n\tv424 = v423 + 8;\n\tv426 = *([v463 @ X10_v22-8]);\n\tv468 = v426 == v420;\n\tif (v468) goto L_00E6;\n\tv446 = v462 - 1;\n\tv448 = v463 + 0x10;\n\tv428 = v462 != 1;\n\tif (v428) goto L_FFFFFFFF;\n\tv449 = v183;\n\tv450 = 0;\n\tv451 = 0xB349B4(v449, v420, v450, v76, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00EE;\nL_00E6:\n\tv474 = *([v463 @ X10_v22]);\n\tv475 = v474 << 4;\n\tv476 = v417 + v475;\n\tv477 = v476 + 0x138;\nL_00EE:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::add_OnAdLoaded(v52.client, v170);\n\tv171 = new System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>::.ctor(v171, v52, Il2CppMethodInfo);\n\tgoto L_0125;\n\tv490 = *([v486 @ X8_v17+B0]);\n\tv491 = v490 + 8;\n\tv493 = *([v530 @ X10_v17-8]);\n\tv535 = v493 == v487;\n\tif (v535) goto L_011C;\n\tv513 = v529 - 1;\n\tv515 = v530 + 0x10;\n\tv495 = v529 != 1;\n\tif (v495) goto L_FFFFFFFF;\n\tv516 = 2;\n\tv517 = v184;\n\tv518 = 0xB349B4(v517, v487, v516, v77, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0125;\nL_011C:\n\tv541 = *([v530 @ X10_v17]);\n\tv542 = v541 + 2;\n\tv543 = v542 << 4;\n\tv544 = v486 + v543;\n\tv545 = v544 + 0x138;\nL_0125:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::add_OnAdFailedToLoad(v52.client, v171);\n\tgoto L_0160;\n\tv553 = *([v550 @ X8_v20+B0]);\n\tv554 = v553 + 8;\n\tv556 = *([v593 @ X10_v12-8]);\n\tv598 = v556 == v551;\n\tif (v598) goto L_014C;\n\tv576 = v592 - 1;\n\tv578 = v593 + 0x10;\n\tv558 = v592 != 1;\n\tif (v558) goto L_FFFFFFFF;\n\tv579 = 0xF;\n\tv580 = v196;\n\tv581 = 0xB349B4(v580, v551, v579, v77, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0160;\nL_014C:\n\tv604 = *([v593 @ X10_v12]);\n\tv605 = v604 + 0xF;\n\tv606 = v605 << 4;\n\tv607 = v550 + v606;\n\tv608 = v607 + 0x138;\nL_0160:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::LoadAd(v52.client, adUnitID, request);\n\tthrow System.NullReferenceException;\n\treturn;\n// 220 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadAd(string adUnitID, AdRequest request, Action<RewardedInterstitialAd, string> adLoadCallback)
		{
			IClientFactory clientFactory = MobileAds.GetClientFactory();
			IRewardedInterstitialAdClient rewardedInterstitialAdClient = clientFactory.BuildRewardedInterstitialAdClient();
			IRewardedInterstitialAdClient client = rewardedInterstitialAdClient;
			bool flag = loadingClients.Add(client);
			client.CreateRewardedInterstitialAd();
			EventHandler<EventArgs> value = delegate
			{
				if (adLoadCallback != null)
				{
					RewardedInterstitialAd arg = new RewardedInterstitialAd(client);
					adLoadCallback(arg, null);
					bool flag2 = loadingClients.Remove(client);
				}
			};
			client.OnAdLoaded += value;
			EventHandler<AdFailedToLoadEventArgs> value2 = delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (adLoadCallback != null)
				{
					adLoadCallback(null, args.Message);
					bool flag2 = loadingClients.Remove(client);
				}
			};
			client.OnAdFailedToLoad += value2;
			client.LoadAd(adUnitID, request);
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0x135DD34", Offset = "0x135DD34", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, userEarnedRewardCallback, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = GoogleMobileAds.Common.IRewardedInterstitialAdClient;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, userEarnedRewardCallback, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, userEarnedRewardCallback, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = GoogleMobileAds.Api.RewardedInterstitialAd+<>c__DisplayClass16_0;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, userEarnedRewardCallback, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A36966]) = v43;\nL_0020:\n\tv45 = new GoogleMobileAds.Api.RewardedInterstitialAd+<>c__DisplayClass16_0();\n\tSystem.Object::.ctor(v45);\n\tv45.userEarnedRewardCallback = userEarnedRewardCallback;\n\tv58 = this.rewardedInterstitialAdClient == 0;\n\tif (v58) goto L_0061;\n\tv124 = new System.EventHandler`1<GoogleMobileAds.Api.Reward>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.Reward>::.ctor(v124, v45, Il2CppMethodInfo);\n\tgoto L_006B;\n\tv186 = *([v182 @ X8_v6+B0]);\n\tv187 = v186 + 8;\n\tv189 = *([v225 @ X10_v12-8]);\n\tv231 = v189 == v183;\n\tif (v231) goto L_0062;\n\tv211 = v226 - 1;\n\tv209 = v225 + 0x10;\n\tv191 = v226 != 1;\n\tif (v191) goto L_FFFFFFFF;\n\tv212 = 6;\n\tv213 = v57;\n\tv214 = 0xB349B4(v213, v183, v212, v99, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_006B;\nL_0061:\n\treturn;\nL_0062:\n\tv237 = *([v225 @ X10_v12]);\n\tv238 = v237 + 6;\n\tv239 = v238 << 4;\n\tv240 = v182 + v239;\n\tv241 = v240 + 0x138;\nL_006B:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::add_OnUserEarnedReward(this.rewardedInterstitialAdClient, v124);\n\tgoto L_00A1;\n\tv249 = *([v246 @ X8_v9+B0]);\n\tv250 = v249 + 8;\n\tv252 = *([v288 @ X10_v7-8]);\n\tv294 = v252 == v247;\n\tif (v294) goto L_0092;\n\tv274 = v289 - 1;\n\tv272 = v288 + 0x10;\n\tv254 = v289 != 1;\n\tif (v254) goto L_FFFFFFFF;\n\tv275 = 0x11;\n\tv276 = v111;\n\tv277 = 0xB349B4(v276, v247, v275, v99, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00A1;\nL_0092:\n\tv300 = *([v288 @ X10_v7]);\n\tv301 = v300 + 0x11;\n\tv302 = v301 << 4;\n\tv303 = v246 + v302;\n\tv304 = v303 + 0x138;\nL_00A1:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::Show(this.rewardedInterstitialAdClient);\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show(Action<Reward> userEarnedRewardCallback)
		{
			if (rewardedInterstitialAdClient == null)
			{
				return;
			}
			EventHandler<Reward> value = delegate(object sender, Reward args)
			{
				if (userEarnedRewardCallback != null)
				{
					userEarnedRewardCallback(args);
				}
			};
			rewardedInterstitialAdClient.OnUserEarnedReward += value;
			rewardedInterstitialAdClient.Show();
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0x135DED8", Offset = "0x135DED8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.IRewardedInterstitialAdClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, serverSideVerificationOptions, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36967]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 0x12;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 0x12;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IRewardedInterstitialAdClient::SetServerSideVerificationOptions(this.rewardedInterstitialAdClient, serverSideVerificationOptions);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions)
		{
			rewardedInterstitialAdClient.SetServerSideVerificationOptions(serverSideVerificationOptions);
		}

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0x135DF84", Offset = "0x135DF84", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IRewardedInterstitialAdClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36968]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x10;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x10;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IRewardedInterstitialAdClient::GetRewardItem(this.rewardedInterstitialAdClient);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Reward GetRewardItem()
		{
			return rewardedInterstitialAdClient.GetRewardItem();
		}

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0x135E028", Offset = "0x135E028", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = GoogleMobileAds.Common.IRewardedInterstitialAdClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = ResponseInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36969]) = v34;\nL_001E:\n\tgoto L_0045;\n\tv48 = *([v40 @ X8_v3+B0]);\n\tv49 = v48 + 8;\n\tv51 = *([v98 @ X10_v7-8]);\n\tv103 = v51 == v44;\n\tif (v103) goto L_003D;\n\tv81 = v97 - 1;\n\tv83 = v98 + 0x10;\n\tv54 = v97 != 1;\n\tif (v54) goto L_FFFFFFFF;\n\tv84 = 0x13;\n\tv85 = v35;\n\tv86 = 0xB349B4(v85, v44, v84, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0045;\nL_003D:\n\tv153 = *([v98 @ X10_v7]);\n\tv154 = v153 + 0x13;\n\tv155 = v154 << 4;\n\tv156 = v40 + v155;\n\tv157 = v156 + 0x138;\nL_0045:\n\tv164 = GoogleMobileAds.Common.IRewardedInterstitialAdClient::GetResponseInfoClient(this.rewardedInterstitialAdClient);\n\tv167 = new ResponseInfo();\n\tResponseInfo::.ctor(v167, v164);\n\treturn v167;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResponseInfo GetResponseInfo()
		{
			IResponseInfoClient responseInfoClient = rewardedInterstitialAdClient.GetResponseInfoClient();
			return new ResponseInfo(responseInfoClient);
		}

		[Token(Token = "0x60003A4")]
		[Address(RVA = "0x135E108", Offset = "0x135E108", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.Collections.Generic.HashSet`1<GoogleMobileAds.Common.IRewardedInterstitialAdClient>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = GoogleMobileAds.Api.RewardedInterstitialAd;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A3696A]) = v43;\nL_001E:\n\tv45 = new System.Collections.Generic.HashSet`1<GoogleMobileAds.Common.IRewardedInterstitialAdClient>();\n\tSystem.Collections.Generic.HashSet`1<GoogleMobileAds.Common.IRewardedInterstitialAdClient>::.ctor(v45);\n\tv56.loadingClients = v45;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static RewardedInterstitialAd()
		{
			HashSet<IRewardedInterstitialAdClient> hashSet = new HashSet<IRewardedInterstitialAdClient>();
			loadingClients = hashSet;
		}
	}
}
