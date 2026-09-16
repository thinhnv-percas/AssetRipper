using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x200001E")]
	public class RewardedAdClient : AndroidJavaProxy, IRewardedAdClient
	{
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x20")]
		private AndroidJavaObject androidRewardedAd;

		[CompilerGenerated]
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToShow;

		[CompilerGenerated]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<Reward> m_OnUserEarnedReward;

		[CompilerGenerated]
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x50")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x58")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[Token(Token = "0x14000031")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000120")]
			[Address(RVA = "0x134CD78", Offset = "0x134CD78", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3680F]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x134CE28", Offset = "0x134CE28", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36810]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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

		[Token(Token = "0x14000032")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000122")]
			[Address(RVA = "0x134CED8", Offset = "0x134CED8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36811]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnAdFailedToLoad;
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
			[Token(Token = "0x6000123")]
			[Address(RVA = "0x134CF88", Offset = "0x134CF88", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36812]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnAdFailedToLoad;
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

		[Token(Token = "0x14000033")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToShow
		{
			[CompilerGenerated]
			[Token(Token = "0x6000124")]
			[Address(RVA = "0x134D038", Offset = "0x134D038", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36813]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_OnAdFailedToShow;
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
			[Token(Token = "0x6000125")]
			[Address(RVA = "0x134D0E8", Offset = "0x134D0E8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36814]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_OnAdFailedToShow;
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

		[Token(Token = "0x14000034")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x6000126")]
			[Address(RVA = "0x134D198", Offset = "0x134D198", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36815]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnAdOpening;
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
			[Token(Token = "0x6000127")]
			[Address(RVA = "0x134D248", Offset = "0x134D248", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36816]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnAdOpening;
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

		[Token(Token = "0x14000035")]
		public event EventHandler<Reward> OnUserEarnedReward
		{
			[CompilerGenerated]
			[Token(Token = "0x6000128")]
			[Address(RVA = "0x134D2F8", Offset = "0x134D2F8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36817]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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
			[Token(Token = "0x6000129")]
			[Address(RVA = "0x134D3A8", Offset = "0x134D3A8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36818]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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

		[Token(Token = "0x14000036")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x600012A")]
			[Address(RVA = "0x134D458", Offset = "0x134D458", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36819]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_OnAdClosed;
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
			[Token(Token = "0x600012B")]
			[Address(RVA = "0x134D508", Offset = "0x134D508", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3681A]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_OnAdClosed;
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

		[Token(Token = "0x14000037")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x600012C")]
			[Address(RVA = "0x134D5B8", Offset = "0x134D5B8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3681B]) = v42;\nL_0016:\n\tv44 = this + 0x58;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 88;
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
			[Token(Token = "0x600012D")]
			[Address(RVA = "0x134D668", Offset = "0x134D668", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3681C]) = v42;\nL_0016:\n\tv44 = this + 0x58;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 88;
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

		[Token(Token = "0x600011F")]
		[Address(RVA = "0x133DDC4", Offset = "0x133DDC4", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv20 = UnityEngine.AndroidJavaClass;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv60 = UnityEngine.AndroidJavaObject;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv65 = UnityEngine.AndroidJavaProxy;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv71 = System.Object[];\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv75 = \"com.google.unity.ads.UnityRewardedAdCallback\";\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv102 = \"com.unity3d.player.UnityPlayer\";\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv151 = \"com.google.unity.ads.UnityRewardedAd\";\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv180 = \"currentActivity\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A3680E]) = v40;\nL_0036:\n\tgoto L_003B;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003B:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.google.unity.ads.UnityRewardedAdCallback\");\n\tv63 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v63, \"com.unity3d.player.UnityPlayer\");\n\tv86 = UnityEngine.AndroidJavaObject::GetStatic(v63, \"currentActivity\");\n\t// 82 NewArr v93 @ X0_v17 (System.Object[]), typeof(System.Object[]), 2\n\tv181 = v86 == 0;\n\tif (v181) goto L_0061;\n\t// 91 IsInst v168 @ X0_v25, typeof(System.Object), v86 @ X0_v15 (System.Object)\n\tv171 = v168 == 0;\n\tif (v171) goto L_008D;\nL_0061:\n\tv93[0] = v86;\n\tv187 = this == 0;\n\tif (v187) goto L_0079;\n\t// 103 IsInst v169 @ X0_v23, typeof(System.Object), this @ X0 (GoogleMobileAds.Android.RewardedAdClient)\n\tv172 = v169 == 0;\n\tif (v172) goto L_008D;\nL_0079:\n\tv93[1] = this;\n\tv209 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v209, \"com.google.unity.ads.UnityRewardedAd\", v93);\n\tthis.androidRewardedAd = v209;\n\treturn;\n\tv100 = new System.NullReferenceException();\n\tv149 = new System.IndexOutOfRangeException();\nL_008D:\n\tv178 = new System.ArrayTypeMismatchException();\n\tthrow v178;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RewardedAdClient()
			: base("com.google.unity.ads.UnityRewardedAdCallback")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			object obj = androidJavaClass.GetStatic<object>("currentActivity");
			object[] array = new object[2];
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					goto IL_011a;
				}
			}
			array[0] = obj;
			if (this != null)
			{
				object obj3 = this as object;
				if (obj3 == null)
				{
					goto IL_011a;
				}
			}
			array[1] = this;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.unity.ads.UnityRewardedAd", array);
			androidRewardedAd = androidJavaObject;
			return;
			IL_011a:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x134D718", Offset = "0x134D718", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Object[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, adUnitId, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = \"create\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, adUnitId, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3681D]) = v41;\nL_001B:\n\t// 27 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = adUnitId == 0;\n\tif (v50) goto L_002A;\n\t// 36 IsInst v64 @ X0_v14, typeof(System.Object), adUnitId @ X1 (System.String)\n\tv66 = v64 == 0;\n\tif (v66) goto L_003D;\nL_002A:\n\tv45[0] = adUnitId;\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"create\", v45);\n\treturn;\n\tv60 = new System.NullReferenceException();\n\tv74 = new System.IndexOutOfRangeException();\nL_003D:\n\tv80 = new System.ArrayTypeMismatchException();\n\tthrow v80;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateRewardedAd(string adUnitId)
		{
			object[] array = new object[1];
			if (adUnitId != null)
			{
				object obj = adUnitId as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = adUnitId;
			androidRewardedAd.Call("create", array);
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0x134D7DC", Offset = "0x134D7DC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Object[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, request, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = \"loadAd\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, request, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3681E]) = v41;\nL_001B:\n\t// 27 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = GoogleMobileAds.Android.Utils::GetAdRequestJavaObject(request);\n\tv53 = v50 == 0;\n\tif (v53) goto L_002D;\n\t// 39 IsInst v67 @ X0_v16, typeof(System.Object), v50 @ X0_v5 (UnityEngine.AndroidJavaObject)\n\tv69 = v67 == 0;\n\tif (v69) goto L_0040;\nL_002D:\n\tv45[0] = v50;\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"loadAd\", v45);\n\treturn;\n\tv63 = new System.NullReferenceException();\n\tv77 = new System.IndexOutOfRangeException();\nL_0040:\n\tv83 = new System.ArrayTypeMismatchException();\n\tthrow v83;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			androidRewardedAd.Call("loadAd", array);
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x134D8AC", Offset = "0x134D8AC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"isLoaded\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3681F]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"isLoaded\", v77.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsLoaded()
		{
			return androidRewardedAd.Call<bool>("isLoaded", Array.Empty<object>());
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x134D97C", Offset = "0x134D97C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"show\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36820]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"show\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show()
		{
			androidRewardedAd.Call("show");
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0x134DA38", Offset = "0x134DA38", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Object[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, serverSideVerificationOptions, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = \"setServerSideVerificationOptions\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, serverSideVerificationOptions, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A36821]) = v41;\nL_001B:\n\t// 27 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = GoogleMobileAds.Android.Utils::GetServerSideVerificationOptionsJavaObject(serverSideVerificationOptions);\n\tv53 = v50 == 0;\n\tif (v53) goto L_002D;\n\t// 39 IsInst v67 @ X0_v16, typeof(System.Object), v50 @ X0_v5 (UnityEngine.AndroidJavaObject)\n\tv69 = v67 == 0;\n\tif (v69) goto L_0040;\nL_002D:\n\tv45[0] = v50;\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"setServerSideVerificationOptions\", v45);\n\treturn;\n\tv63 = new System.NullReferenceException();\n\tv77 = new System.IndexOutOfRangeException();\nL_0040:\n\tv83 = new System.ArrayTypeMismatchException();\n\tthrow v83;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions)
		{
			object[] array = new object[1];
			AndroidJavaObject serverSideVerificationOptionsJavaObject = Utils.GetServerSideVerificationOptionsJavaObject(serverSideVerificationOptions);
			if (serverSideVerificationOptionsJavaObject != null)
			{
				object obj = serverSideVerificationOptionsJavaObject as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = serverSideVerificationOptionsJavaObject;
			androidRewardedAd.Call("setServerSideVerificationOptions", array);
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0x134DD68", Offset = "0x134DD68", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"destroy\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36822]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"destroy\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyRewardBasedVideoAd()
		{
			androidRewardedAd.Call("destroy");
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x134DE24", Offset = "0x134DE24", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv81 = GoogleMobileAds.Api.Reward;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv87 = \"getType\";\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv127 = \"getRewardItem\";\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = \"getAmount\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A36823]) = v42;\nL_002F:\n\tgoto L_0038;\n\tv52 = 0xB3490C(Il2CppMethodInfo, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0038:\n\tgoto L_003D;\n\tv64 = 0xB348B0(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\tgoto L_0045;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0045:\n\tgoto L_0052;\n\tv83 = 0xB348B0(v75, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0052:\n\tv98 = UnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"getRewardItem\", v91.Value);\n\tv130 = v98 == 0;\n\tif (v130) goto L_00B8;\n\tgoto L_0063;\n\tv173 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getRewardItem\", v91.Value);\nL_0063:\n\tgoto L_0068;\n\tv182 = UnityEngine.AndroidJavaObject::Call(v177, v96, v95, v97);\nL_0068:\n\tgoto L_FFFFFFFF;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v183, v96, v95, v97, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0076;\n\tv199 = UnityEngine.AndroidJavaObject::Call(v192, v96, v95, v97);\nL_0076:\n\tv201 = *([v200 @ X0_v19+B8]);\n\tv206 = UnityEngine.AndroidJavaObject::Call(v98, \"getType\", *([v201 @ X8_v18]));\n\tgoto L_008A;\n\tv212 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getType\", *([v201 @ X8_v18]));\nL_008A:\n\tgoto L_008F;\n\tv221 = UnityEngine.AndroidJavaObject::Call(v216, v202, v205, v203);\nL_008F:\n\tgoto L_FFFFFFFF;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v222, v202, v205, v203, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_009F;\n\tv238 = UnityEngine.AndroidJavaObject::Call(v232, v202, v205, v203);\nL_009F:\n\tv240 = *([v239 @ X0_v27+B8]);\n\tv242 = UnityEngine.AndroidJavaObject::Call(v98, \"getAmount\", *([v240 @ X8_v25]));\n\tv114 = new GoogleMobileAds.Api.Reward();\n\tGoogleMobileAds.Api.Reward::.ctor(v114);\n\tv114.<Type>k__BackingField = v206;\n\tv114.<Amount>k__BackingField = v242;\nL_00B8:\n\treturn v146;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Reward GetRewardItem()
		{
			//IL_0086: Expected O, but got I
			//IL_009b: Expected O, but got I
			//IL_00da: Expected O, but got I
			//IL_00ef: Expected O, but got I
			object obj = androidRewardedAd.Call<object>("getRewardItem", Array.Empty<object>());
			bool flag = obj == null;
			object result = obj;
			if (!flag)
			{
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ X0_v19+B8]");
				object args = 0;
				object type = ((AndroidJavaObject)obj).Call<object>("getType", (object[])args);
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ X0_v27+B8]");
				object args2 = 0;
				int num = ((AndroidJavaObject)obj).Call<int>("getAmount", (object[])args2);
				Reward reward = new Reward();
				reward.Type = (string)type;
				reward.Amount = num;
				result = reward;
			}
			return (Reward)result;
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x134E05C", Offset = "0x134E05C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"getMediationAdapterClassName\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36824]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.androidRewardedAd, \"getMediationAdapterClassName\", v77.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
		{
			return (string)androidRewardedAd.Call<object>("getMediationAdapterClassName", Array.Empty<object>());
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x134E12C", Offset = "0x134E12C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = GoogleMobileAds.Android.ResponseInfoClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36825]) = v37;\nL_0015:\n\tv40 = new GoogleMobileAds.Android.ResponseInfoClient();\n\tGoogleMobileAds.Android.ResponseInfoClient::.ctor(v40, this.androidRewardedAd);\n\treturn v40;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IResponseInfoClient GetResponseInfoClient()
		{
			return new ResponseInfoClient(androidRewardedAd);
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x134E188", Offset = "0x134E188", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A36826]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdLoaded == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdLoaded, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onRewardedAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x134E208", Offset = "0x134E208", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = GoogleMobileAds.Api.AdErrorEventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, errorReason, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36827]) = v36;\nL_0013:\n\tv38 = this.OnAdFailedToLoad == 0;\n\tif (v38) goto L_0031;\n\tv42 = new GoogleMobileAds.Api.AdErrorEventArgs();\n\tGoogleMobileAds.Api.AdErrorEventArgs::.ctor(v42);\n\tv73 = v42 == 0;\n\tif (v73) goto L_0032;\n\tv42.<Message>k__BackingField = errorReason;\n\tv62 = this.OnAdFailedToLoad == 0;\n\tif (v62) goto L_0032;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>::Invoke(this.OnAdFailedToLoad, this, v42);\nL_0031:\n\treturn;\nL_0032:\n\tthrow v42;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onRewardedAdFailedToLoad(string errorReason)
		{
			if (this.OnAdFailedToLoad == null)
			{
				return;
			}
			AdErrorEventArgs e = new AdErrorEventArgs();
			if (e != null)
			{
				e.Message = errorReason;
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, e);
					return;
				}
			}
			throw e;
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x134E298", Offset = "0x134E298", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = GoogleMobileAds.Api.AdErrorEventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, errorReason, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36828]) = v36;\nL_0013:\n\tv38 = this.OnAdFailedToShow == 0;\n\tif (v38) goto L_0031;\n\tv42 = new GoogleMobileAds.Api.AdErrorEventArgs();\n\tGoogleMobileAds.Api.AdErrorEventArgs::.ctor(v42);\n\tv73 = v42 == 0;\n\tif (v73) goto L_0032;\n\tv42.<Message>k__BackingField = errorReason;\n\tv62 = this.OnAdFailedToShow == 0;\n\tif (v62) goto L_0032;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>::Invoke(this.OnAdFailedToShow, this, v42);\nL_0031:\n\treturn;\nL_0032:\n\tthrow v42;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onRewardedAdFailedToShow(string errorReason)
		{
			if (this.OnAdFailedToShow == null)
			{
				return;
			}
			AdErrorEventArgs e = new AdErrorEventArgs();
			if (e != null)
			{
				e.Message = errorReason;
				if (this.OnAdFailedToShow != null)
				{
					this.OnAdFailedToShow(this, e);
					return;
				}
			}
			throw e;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x134E328", Offset = "0x134E328", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A36829]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdOpening == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdOpening, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onRewardedAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0x134E3A8", Offset = "0x134E3A8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A3682A]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdClosed == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdClosed, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onRewardedAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0x134E428", Offset = "0x134E428", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = GoogleMobileAds.Api.Reward;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, type, methodInfo, v25, v26, v27, v28, v29, amount, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3682B]) = v39;\nL_0015:\n\tv41 = this.OnUserEarnedReward == 0;\n\tif (v41) goto L_0037;\n\tv45 = new GoogleMobileAds.Api.Reward();\n\tGoogleMobileAds.Api.Reward::.ctor(v45);\n\tv82 = v45 == 0;\n\tif (v82) goto L_0038;\n\tv45.<Type>k__BackingField = type;\n\tv45.<Amount>k__BackingField = amount;\n\tv69 = this.OnUserEarnedReward == 0;\n\tif (v69) goto L_0038;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.Reward>::Invoke(this.OnUserEarnedReward, this, v45);\nL_0037:\n\treturn;\nL_0038:\n\tthrow v45;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onUserEarnedReward(string type, float amount)
		{
			if (this.OnUserEarnedReward == null)
			{
				return;
			}
			Reward reward = new Reward();
			if (reward != null)
			{
				reward.Type = type;
				reward.Amount = amount;
				if (this.OnUserEarnedReward != null)
				{
					this.OnUserEarnedReward(this, reward);
					return;
				}
			}
			throw reward;
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0x134E4D0", Offset = "0x134E4D0", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = GoogleMobileAds.Api.AdValueEventArgs;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, precision, valueInMicros, currencyCode, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = GoogleMobileAds.Api.AdValue;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, precision, valueInMicros, currencyCode, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A3682C]) = v43;\nL_001A:\n\tv45 = this.OnPaidEvent == 0;\n\tif (v45) goto L_0048;\n\tv51 = new GoogleMobileAds.Api.AdValue();\n\tSystem.Object::.ctor(v51);\n\tv51.<Precision>k__BackingField = precision;\n\tv51.<Value>k__BackingField = valueInMicros;\n\tv51.<CurrencyCode>k__BackingField = currencyCode;\n\tv94 = new GoogleMobileAds.Api.AdValueEventArgs();\n\tGoogleMobileAds.Api.AdValueEventArgs::.ctor(v94);\n\tv94.<AdValue>k__BackingField = v51;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>::Invoke(this.OnPaidEvent, this, v94);\nL_0048:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onPaidEvent(int precision, long valueInMicros, string currencyCode)
		{
			if (this.OnPaidEvent != null)
			{
				AdValue adValue = new AdValue();
				adValue.Precision = (AdValue.PrecisionType)precision;
				adValue.Value = valueInMicros;
				adValue.CurrencyCode = currencyCode;
				AdValueEventArgs e = new AdValueEventArgs();
				e.AdValue = adValue;
				this.OnPaidEvent(this, e);
			}
		}
	}
}
