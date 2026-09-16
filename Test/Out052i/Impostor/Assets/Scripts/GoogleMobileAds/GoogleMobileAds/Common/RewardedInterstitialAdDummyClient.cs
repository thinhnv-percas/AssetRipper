using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000031")]
	public class RewardedInterstitialAdDummyClient : IRewardedInterstitialAdClient
	{
		[CompilerGenerated]
		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x10")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<Reward> m_OnUserEarnedReward;

		[CompilerGenerated]
		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[CompilerGenerated]
		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToPresentFullScreenContent;

		[CompilerGenerated]
		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<EventArgs> m_OnAdDidPresentFullScreenContent;

		[CompilerGenerated]
		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<EventArgs> m_OnAdDidDismissFullScreenContent;

		[Token(Token = "0x14000076")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000251")]
			[Address(RVA = "0x1353D60", Offset = "0x1353D60", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368AA]) = v42;\nL_0016:\n\tv44 = this + 0x10;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 16;
				Delegate obj2 = this.m_OnAdLoaded;
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
			[Token(Token = "0x6000252")]
			[Address(RVA = "0x1353E10", Offset = "0x1353E10", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368AB]) = v42;\nL_0016:\n\tv44 = this + 0x10;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 16;
				Delegate obj2 = this.m_OnAdLoaded;
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

		[Token(Token = "0x14000077")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000253")]
			[Address(RVA = "0x1353EC0", Offset = "0x1353EC0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368AC]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000254")]
			[Address(RVA = "0x1353F70", Offset = "0x1353F70", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368AD]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000078")]
		public event EventHandler<Reward> OnUserEarnedReward
		{
			[CompilerGenerated]
			[Token(Token = "0x6000255")]
			[Address(RVA = "0x1354020", Offset = "0x1354020", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368AE]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnUserEarnedReward;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<Reward>);
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
			[Token(Token = "0x6000256")]
			[Address(RVA = "0x13540D0", Offset = "0x13540D0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368AF]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnUserEarnedReward;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<Reward>);
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

		[Token(Token = "0x14000079")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000257")]
			[Address(RVA = "0x1354180", Offset = "0x1354180", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B0]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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
			[Token(Token = "0x6000258")]
			[Address(RVA = "0x1354230", Offset = "0x1354230", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B1]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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

		[Token(Token = "0x1400007A")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToPresentFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000259")]
			[Address(RVA = "0x13542E0", Offset = "0x13542E0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B2]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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
			[Token(Token = "0x600025A")]
			[Address(RVA = "0x1354390", Offset = "0x1354390", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B3]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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

		[Token(Token = "0x1400007B")]
		public event EventHandler<EventArgs> OnAdDidPresentFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x600025B")]
			[Address(RVA = "0x1354440", Offset = "0x1354440", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B4]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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
			[Token(Token = "0x600025C")]
			[Address(RVA = "0x13544F0", Offset = "0x13544F0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B5]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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

		[Token(Token = "0x1400007C")]
		public event EventHandler<EventArgs> OnAdDidDismissFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x600025D")]
			[Address(RVA = "0x13545A0", Offset = "0x13545A0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B6]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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
			[Token(Token = "0x600025E")]
			[Address(RVA = "0x1354650", Offset = "0x1354650", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368B7]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x133E3F0", Offset = "0x133E3F0", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = \"Dummy \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A368A9]) = v38;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tv44 = Il2CppMethodInfo;\n\tv46 = *([v44 @ X0_v3 (Il2CppMethodInfo)+53]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_0023;\n\tv51 = 0xAD94B0(Il2CppMethodInfo, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv53 = 0xAD947C(v51, Il2CppClass<GoogleMobileAds.Common.RewardedInterstitialAdDummyClient>, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = *([v53 @ X0_v5]);\n\t*([v55 @ X8_v4+1A8])(v62, v53, *([v55 @ X8_v4+1B0]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv67 = System.String::Concat(\"Dummy \", v62);\n\tgoto L_0042;\n\tv74 = v69;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v74, v64, v65, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tUnityEngine.Debug::Log(v67);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RewardedInterstitialAdDummyClient()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v3 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v55 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			Debug.Log("Dummy " + text);
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0x1354700", Offset = "0x1354700", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368B8]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedInterstitialAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateRewardedInterstitialAd()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0x13547C4", Offset = "0x13547C4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, adUnitID, request, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, adUnitID, request, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adUnitID, request, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368B9]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, adUnitID, request, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedInterstitialAdDummyClient>, request, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), request, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(string adUnitID, AdRequest request)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0x1354888", Offset = "0x1354888", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368BA]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedInterstitialAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Reward GetRewardItem()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return null;
		}

		[Token(Token = "0x6000262")]
		[Address(RVA = "0x1354954", Offset = "0x1354954", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368BB]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedInterstitialAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0x1354A18", Offset = "0x1354A18", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368BC]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedInterstitialAdDummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0x1354ADC", Offset = "0x1354ADC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368BD]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedInterstitialAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IResponseInfoClient GetResponseInfoClient()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return null;
		}
	}
}
