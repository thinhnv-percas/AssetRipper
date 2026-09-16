using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000055")]
	public class RewardedAd
	{
		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x10")]
		private IRewardedAdClient client;

		[CompilerGenerated]
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToShow;

		[CompilerGenerated]
		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<Reward> m_OnUserEarnedReward;

		[CompilerGenerated]
		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[Token(Token = "0x14000093")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x600037A")]
			[Address(RVA = "0x135C210", Offset = "0x135C210", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36947]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
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
			[Token(Token = "0x600037B")]
			[Address(RVA = "0x135C2C0", Offset = "0x135C2C0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36948]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
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

		[Token(Token = "0x14000094")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x600037C")]
			[Address(RVA = "0x135C370", Offset = "0x135C370", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36949]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
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
			[Token(Token = "0x600037D")]
			[Address(RVA = "0x135C420", Offset = "0x135C420", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3694A]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
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

		[Token(Token = "0x14000095")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToShow
		{
			[CompilerGenerated]
			[Token(Token = "0x600037E")]
			[Address(RVA = "0x135C4D0", Offset = "0x135C4D0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3694B]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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
			[Token(Token = "0x600037F")]
			[Address(RVA = "0x135C580", Offset = "0x135C580", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3694C]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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

		[Token(Token = "0x14000096")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x6000380")]
			[Address(RVA = "0x135C630", Offset = "0x135C630", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3694D]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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
			[Token(Token = "0x6000381")]
			[Address(RVA = "0x135C6E0", Offset = "0x135C6E0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3694E]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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

		[Token(Token = "0x14000097")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000382")]
			[Address(RVA = "0x135C790", Offset = "0x135C790", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3694F]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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
			[Token(Token = "0x6000383")]
			[Address(RVA = "0x135C840", Offset = "0x135C840", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36950]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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

		[Token(Token = "0x14000098")]
		public event EventHandler<Reward> OnUserEarnedReward
		{
			[CompilerGenerated]
			[Token(Token = "0x6000384")]
			[Address(RVA = "0x135C8F0", Offset = "0x135C8F0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36951]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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
			[Token(Token = "0x6000385")]
			[Address(RVA = "0x135C9A0", Offset = "0x135C9A0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36952]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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

		[Token(Token = "0x14000099")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000386")]
			[Address(RVA = "0x135CA50", Offset = "0x135CA50", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36953]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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
			[Token(Token = "0x6000387")]
			[Address(RVA = "0x135CB00", Offset = "0x135CB00", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36954]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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

		[Token(Token = "0x6000379")]
		[Address(RVA = "0x135BC50", Offset = "0x135BC50", Length = "0x5C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv26 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv54 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv58 = System.EventHandler`1<System.EventArgs>;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv284 = GoogleMobileAds.IClientFactory;\n\tv285 = \"il2cpp_codegen_initialize_runtime_metadata\"(v284, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv316 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv317 = \"il2cpp_codegen_initialize_runtime_metadata\"(v316, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv394 = Il2CppMethodInfo;\n\tv395 = \"il2cpp_codegen_initialize_runtime_metadata\"(v394, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv406 = Il2CppMethodInfo;\n\tv407 = \"il2cpp_codegen_initialize_runtime_metadata\"(v406, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv417 = Il2CppMethodInfo;\n\tv418 = \"il2cpp_codegen_initialize_runtime_metadata\"(v417, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv449 = Il2CppMethodInfo;\n\tv450 = \"il2cpp_codegen_initialize_runtime_metadata\"(v449, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv473 = Il2CppMethodInfo;\n\tv474 = \"il2cpp_codegen_initialize_runtime_metadata\"(v473, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv490 = Il2CppMethodInfo;\n\tv491 = \"il2cpp_codegen_initialize_runtime_metadata\"(v490, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv493 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v493, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A36946]) = v45;\nL_003C:\n\tSystem.Object::.ctor(this);\n\tv52 = GoogleMobileAds.Api.MobileAds::GetClientFactory();\n\tgoto L_006F;\n\tv286 = *([v61 @ X8_v4+B0]);\n\tv287 = v286 + 8;\n\tv289 = *([v329 @ X10_v56-8]);\n\tv334 = v289 == v65;\n\tif (v334) goto L_0067;\n\tv309 = v328 - 1;\n\tv311 = v329 + 0x10;\n\tv291 = v328 != 1;\n\tif (v291) goto L_FFFFFFFF;\n\tv312 = 3;\n\tv313 = v63;\n\tv314 = 0xB349B4(v313, v65, v312, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_006F;\nL_0067:\n\tv397 = *([v329 @ X10_v56]);\n\tv398 = v397 + 3;\n\tv399 = v398 << 4;\n\tv400 = v61 + v399;\n\tv401 = v400 + 0x138;\nL_006F:\n\tv247 = GoogleMobileAds.IClientFactory::BuildRewardedAdClient(v52);\n\tthis.client = v247;\n\tgoto L_00A6;\n\tv419 = *([v409 @ X8_v7+B0]);\n\tv420 = v419 + 8;\n\tv422 = *([v462 @ X10_v51-8]);\n\tv467 = v422 == v413;\n\tif (v467) goto L_009D;\n\tv442 = v461 - 1;\n\tv444 = v462 + 0x10;\n\tv424 = v461 != 1;\n\tif (v424) goto L_FFFFFFFF;\n\tv445 = 0xE;\n\tv446 = v414;\n\tv447 = 0xB349B4(v446, v413, v445, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00A6;\nL_009D:\n\tv476 = *([v462 @ X10_v51]);\n\tv477 = v476 + 0xE;\n\tv478 = v477 << 4;\n\tv479 = v409 + v478;\n\tv480 = v479 + 0x138;\nL_00A6:\n\tGoogleMobileAds.Common.IRewardedAdClient::CreateRewardedAd(v247, adUnitId);\n\tv240 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v240, this, Il2CppMethodInfo);\n\tgoto L_00E0;\n\tv500 = *([v494 @ X8_v10+B0]);\n\tv501 = v500 + 8;\n\tv503 = *([v540 @ X10_v46-8]);\n\tv545 = v503 == v497;\n\tif (v545) goto L_00D8;\n\tv523 = v539 - 1;\n\tv525 = v540 + 0x10;\n\tv505 = v539 != 1;\n\tif (v505) goto L_FFFFFFFF;\n\tv526 = v258;\n\tv527 = 0;\n\tv528 = 0xB349B4(v526, v497, v527, v81, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00E0;\nL_00D8:\n\tv551 = *([v540 @ X10_v46]);\n\tv552 = v551 << 4;\n\tv553 = v494 + v552;\n\tv554 = v553 + 0x138;\nL_00E0:\n\tGoogleMobileAds.Common.IRewardedAdClient::add_OnAdLoaded(this.client, v240);\n\tv241 = new System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>::.ctor(v241, this, Il2CppMethodInfo);\n\tgoto L_0119;\n\tv568 = *([v563 @ X8_v13+B0]);\n\tv569 = v568 + 8;\n\tv571 = *([v608 @ X10_v41-8]);\n\tv613 = v571 == v565;\n\tif (v613) goto L_0110;\n\tv591 = v607 - 1;\n\tv593 = v608 + 0x10;\n\tv573 = v607 != 1;\n\tif (v573) goto L_FFFFFFFF;\n\tv594 = 2;\n\tv595 = v259;\n\tv596 = 0xB349B4(v595, v565, v594, v82, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0119;\nL_0110:\n\tv619 = *([v608 @ X10_v41]);\n\tv620 = v619 + 2;\n\tv621 = v620 << 4;\n\tv622 = v563 + v621;\n\tv623 = v622 + 0x138;\nL_0119:\n\tGoogleMobileAds.Common.IRewardedAdClient::add_OnAdFailedToLoad(this.client, v241);\n\tv242 = new System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>::.ctor(v242, this, Il2CppMethodInfo);\n\tgoto L_0152;\n\tv637 = *([v632 @ X8_v16+B0]);\n\tv638 = v637 + 8;\n\tv640 = *([v677 @ X10_v36-8]);\n\tv682 = v640 == v634;\n\tif (v682) goto L_0149;\n\tv660 = v676 - 1;\n\tv662 = v677 + 0x10;\n\tv642 = v676 != 1;\n\tif (v642) goto L_FFFFFFFF;\n\tv663 = 4;\n\tv664 = v260;\n\tv665 = 0xB349B4(v664, v634, v663, v83, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0152;\nL_0149:\n\tv688 = *([v677 @ X10_v36]);\n\tv689 = v688 + 4;\n\tv690 = v689 << 4;\n\tv691 = v632 + v690;\n\tv692 = v691 + 0x138;\nL_0152:\n\tGoogleMobileAds.Common.IRewardedAdClient::add_OnAdFailedToShow(this.client, v242);\n\tv243 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v243, this, Il2CppMethodInfo);\n\tgoto L_018B;\n\tv706 = *([v701 @ X8_v19+B0]);\n\tv707 = v706 + 8;\n\tv709 = *([v746 @ X10_v31-8]);\n\tv751 = v709 == v703;\n\tif (v751) goto L_0182;\n\tv729 = v745 - 1;\n\tv731 = v746 + 0x10;\n\tv711 = v745 != 1;\n\tif (v711) goto L_FFFFFFFF;\n\tv732 = 6;\n\tv733 = v261;\n\tv734 = 0xB349B4(v733, v703, v732, v84, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_018B;\nL_0182:\n\tv757 = *([v746 @ X10_v31]);\n\tv758 = v757 + 6;\n\tv759 = v758 << 4;\n\tv760 = v701 + v759;\n\tv761 = v760 + 0x138;\nL_018B:\n\tGoogleMobileAds.Common.IRewardedAdClient::add_OnAdOpening(this.client, v243);\n\tv244 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v244, this, Il2CppMethodInfo);\n\tgoto L_01C6;\n\tv776 = *([v770 @ X8_v22+B0]);\n\tv777 = v776 + 8;\n\tv779 = *([v816 @ X10_v26-8]);\n\tv821 = v779 == v773;\n\tif (v821) goto L_01BD;\n\tv799 = v815 - 1;\n\tv801 = v816 + 0x10;\n\tv781 = v815 != 1;\n\tif (v781) goto L_FFFFFFFF;\n\tv802 = 0xA;\n\tv803 = v262;\n\tv804 = 0xB349B4(v803, v773, v802, v85, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_01C6;\nL_01BD:\n\tv827 = *([v816 @ X10_v26]);\n\tv828 = v827 + 0xA;\n\tv829 = v828 << 4;\n\tv830 = v770 + v829;\n\tv831 = v830 + 0x138;\nL_01C6:\n\tGoogleMobileAds.Common.IRewardedAdClient::add_OnAdClosed(this.client, v244);\n\tv245 = new System.EventHandler`1<GoogleMobileAds.Api.Reward>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.Reward>::.ctor(v245, this, Il2CppMethodInfo);\n\tgoto L_0201;\n\tv846 = *([v840 @ X8_v25+B0]);\n\tv847 = v846 + 8;\n\tv849 = *([v886 @ X10_v21-8]);\n\tv891 = v849 == v843;\n\tif (v891) goto L_01F8;\n\tv869 = v885 - 1;\n\tv871 = v886 + 0x10;\n\tv851 = v885 != 1;\n\tif (v851) goto L_FFFFFFFF;\n\tv872 = 8;\n\tv873 = v263;\n\tv874 = 0xB349B4(v873, v843, v872, v86, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0201;\nL_01F8:\n\tv897 = *([v886 @ X10_v21]);\n\tv898 = v897 + 8;\n\tv899 = v898 << 4;\n\tv900 = v840 + v899;\n\tv901 = v900 + 0x138;\nL_0201:\n\tGoogleMobileAds.Common.IRewardedAdClient::add_OnUserEarnedReward(this.client, v245);\n\tv246 = new System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>();\n\tSystem.Even\n// ... truncated")]
		public RewardedAd(string adUnitId)
		{
			IClientFactory clientFactory = MobileAds.GetClientFactory();
			(client = clientFactory.BuildRewardedAdClient()).CreateRewardedAd(adUnitId);
			EventHandler<EventArgs> value = delegate(object sender, EventArgs args)
			{
				if (this.OnAdLoaded != null)
				{
					this.OnAdLoaded(this, args);
				}
			};
			client.OnAdLoaded += value;
			EventHandler<AdErrorEventArgs> value2 = delegate(object sender, AdErrorEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
			client.OnAdFailedToLoad += value2;
			EventHandler<AdErrorEventArgs> value3 = delegate(object sender, AdErrorEventArgs args)
			{
				if (this.OnAdFailedToShow != null)
				{
					this.OnAdFailedToShow(this, args);
				}
			};
			client.OnAdFailedToShow += value3;
			EventHandler<EventArgs> value4 = delegate(object sender, EventArgs args)
			{
				if (this.OnAdOpening != null)
				{
					this.OnAdOpening(this, args);
				}
			};
			client.OnAdOpening += value4;
			EventHandler<EventArgs> value5 = delegate(object sender, EventArgs args)
			{
				if (this.OnAdClosed != null)
				{
					this.OnAdClosed(this, args);
				}
			};
			client.OnAdClosed += value5;
			EventHandler<Reward> value6 = delegate(object sender, Reward args)
			{
				if (this.OnUserEarnedReward != null)
				{
					this.OnUserEarnedReward(this, args);
				}
			};
			client.OnUserEarnedReward += value6;
			EventHandler<AdValueEventArgs> value7 = delegate(object sender, AdValueEventArgs args)
			{
				if (this.OnPaidEvent != null)
				{
					this.OnPaidEvent(this, args);
				}
			};
			client.OnPaidEvent += value7;
		}

		[Token(Token = "0x6000388")]
		[Address(RVA = "0x135CBB0", Offset = "0x135CBB0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, request, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36955]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 0xF;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 0xF;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IRewardedAdClient::LoadAd(this.client, request);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			client.LoadAd(request);
		}

		[Token(Token = "0x6000389")]
		[Address(RVA = "0x135CC5C", Offset = "0x135CC5C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36956]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x10;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x10;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IRewardedAdClient::IsLoaded(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsLoaded()
		{
			return client.IsLoaded();
		}

		[Token(Token = "0x600038A")]
		[Address(RVA = "0x135CD00", Offset = "0x135CD00", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36957]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x13;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x13;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tGoogleMobileAds.Common.IRewardedAdClient::Show(this.client);\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show()
		{
			client.Show();
		}

		[Token(Token = "0x600038B")]
		[Address(RVA = "0x135CDA4", Offset = "0x135CDA4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, serverSideVerificationOptions, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36958]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 0x14;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 0x14;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IRewardedAdClient::SetServerSideVerificationOptions(this.client, serverSideVerificationOptions);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions)
		{
			client.SetServerSideVerificationOptions(serverSideVerificationOptions);
		}

		[Token(Token = "0x600038C")]
		[Address(RVA = "0x135CE50", Offset = "0x135CE50", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv16 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A36959]) = v35;\nL_001A:\n\tgoto L_0041;\n\tv97 = *([v39 @ X8_v4+B0]);\n\tv98 = v97 + 8;\n\tv100 = *([v136 @ X10_v12-8]);\n\tv142 = v100 == v42;\n\tif (v142) goto L_0039;\n\tv122 = v137 - 1;\n\tv120 = v136 + 0x10;\n\tv102 = v137 != 1;\n\tif (v102) goto L_FFFFFFFF;\n\tv123 = 0x10;\n\tv124 = v36;\n\tv125 = 0xB349B4(v124, v42, v123, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tgoto L_0041;\nL_0039:\n\tv198 = *([v136 @ X10_v12]);\n\tv199 = v198 + 0x10;\n\tv200 = v199 << 4;\n\tv201 = v39 + v200;\n\tv202 = v201 + 0x138;\nL_0041:\n\tv89 = GoogleMobileAds.Common.IRewardedAdClient::IsLoaded(this.client);\n\tv187 = v89 == 0;\n\tif (v187) goto L_0071;\n\tgoto L_007F;\n\tv210 = *([v207 @ X8_v7+B0]);\n\tv211 = v210 + 8;\n\tv213 = *([v249 @ X10_v7-8]);\n\tv255 = v213 == v208;\n\tif (v255) goto L_0072;\n\tv235 = v250 - 1;\n\tv233 = v249 + 0x10;\n\tv215 = v250 != 1;\n\tif (v215) goto L_FFFFFFFF;\n\tv236 = 0x12;\n\tv237 = v93;\n\tv238 = 0xB349B4(v237, v208, v236, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tgoto L_007F;\nL_0071:\n\treturn 0;\nL_0072:\n\tv261 = *([v249 @ X10_v7]);\n\tv262 = v261 + 0x12;\n\tv263 = v262 << 4;\n\tv264 = v207 + v263;\n\tv265 = v264 + 0x138;\nL_007F:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IRewardedAdClient::GetRewardItem(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Reward GetRewardItem()
		{
			if (!client.IsLoaded())
			{
				return null;
			}
			return client.GetRewardItem();
		}

		[Obsolete("MediationAdapterClassName() is deprecated, use GetResponseInfo.MediationAdapterClassName() instead.")]
		[Token(Token = "0x600038D")]
		[Address(RVA = "0x135CF6C", Offset = "0x135CF6C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3695A]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x11;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x11;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IRewardedAdClient::MediationAdapterClassName(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
		{
			return client.MediationAdapterClassName();
		}

		[Token(Token = "0x600038E")]
		[Address(RVA = "0x135D010", Offset = "0x135D010", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = GoogleMobileAds.Common.IRewardedAdClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = ResponseInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3695B]) = v34;\nL_001E:\n\tgoto L_0045;\n\tv48 = *([v40 @ X8_v3+B0]);\n\tv49 = v48 + 8;\n\tv51 = *([v98 @ X10_v7-8]);\n\tv103 = v51 == v44;\n\tif (v103) goto L_003D;\n\tv81 = v97 - 1;\n\tv83 = v98 + 0x10;\n\tv54 = v97 != 1;\n\tif (v54) goto L_FFFFFFFF;\n\tv84 = 0x15;\n\tv85 = v35;\n\tv86 = 0xB349B4(v85, v44, v84, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0045;\nL_003D:\n\tv153 = *([v98 @ X10_v7]);\n\tv154 = v153 + 0x15;\n\tv155 = v154 << 4;\n\tv156 = v40 + v155;\n\tv157 = v156 + 0x138;\nL_0045:\n\tv164 = GoogleMobileAds.Common.IRewardedAdClient::GetResponseInfoClient(this.client);\n\tv167 = new ResponseInfo();\n\tResponseInfo::.ctor(v167, v164);\n\treturn v167;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResponseInfo GetResponseInfo()
		{
			IResponseInfoClient responseInfoClient = client.GetResponseInfoClient();
			return new ResponseInfo(responseInfoClient);
		}
	}
}
