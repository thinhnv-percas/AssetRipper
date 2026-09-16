using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000030")]
	public class RewardedAdDummyClient : IRewardedAdClient
	{
		[CompilerGenerated]
		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x10")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToShow;

		[CompilerGenerated]
		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<Reward> m_OnUserEarnedReward;

		[CompilerGenerated]
		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[Token(Token = "0x1400006F")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x600023A")]
			[Address(RVA = "0x1352D24", Offset = "0x1352D24", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36893]) = v42;\nL_0016:\n\tv44 = this + 0x10;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600023B")]
			[Address(RVA = "0x1352DD4", Offset = "0x1352DD4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36894]) = v42;\nL_0016:\n\tv44 = this + 0x10;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000070")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x600023C")]
			[Address(RVA = "0x1352E84", Offset = "0x1352E84", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36895]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600023D")]
			[Address(RVA = "0x1352F34", Offset = "0x1352F34", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36896]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000071")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToShow
		{
			[CompilerGenerated]
			[Token(Token = "0x600023E")]
			[Address(RVA = "0x1352FE4", Offset = "0x1352FE4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36897]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
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
			[Token(Token = "0x600023F")]
			[Address(RVA = "0x1353094", Offset = "0x1353094", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36898]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
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

		[Token(Token = "0x14000072")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x6000240")]
			[Address(RVA = "0x1353144", Offset = "0x1353144", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36899]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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
			[Token(Token = "0x6000241")]
			[Address(RVA = "0x13531F4", Offset = "0x13531F4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3689A]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
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

		[Token(Token = "0x14000073")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000242")]
			[Address(RVA = "0x13532A4", Offset = "0x13532A4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3689B]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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
			[Token(Token = "0x6000243")]
			[Address(RVA = "0x1353354", Offset = "0x1353354", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3689C]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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

		[Token(Token = "0x14000074")]
		public event EventHandler<Reward> OnUserEarnedReward
		{
			[CompilerGenerated]
			[Token(Token = "0x6000244")]
			[Address(RVA = "0x1353404", Offset = "0x1353404", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3689D]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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
			[Token(Token = "0x6000245")]
			[Address(RVA = "0x13534B4", Offset = "0x13534B4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3689E]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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

		[Token(Token = "0x14000075")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000246")]
			[Address(RVA = "0x1353564", Offset = "0x1353564", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3689F]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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
			[Token(Token = "0x6000247")]
			[Address(RVA = "0x1353614", Offset = "0x1353614", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368A0]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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

		[Token(Token = "0x6000239")]
		[Address(RVA = "0x133DFE8", Offset = "0x133DFE8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = \"Dummy \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36892]) = v38;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tv44 = Il2CppMethodInfo;\n\tv46 = *([v44 @ X0_v3 (Il2CppMethodInfo)+53]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_0023;\n\tv51 = 0xAD94B0(Il2CppMethodInfo, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv53 = 0xAD947C(v51, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = *([v53 @ X0_v5]);\n\t*([v55 @ X8_v4+1A8])(v62, v53, *([v55 @ X8_v4+1B0]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv67 = System.String::Concat(\"Dummy \", v62);\n\tgoto L_0042;\n\tv74 = v69;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v74, v64, v65, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tUnityEngine.Debug::Log(v67);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RewardedAdDummyClient()
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

		[Token(Token = "0x6000248")]
		[Address(RVA = "0x13536C4", Offset = "0x13536C4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368A1]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateRewardedAd(string adUnitId)
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

		[Token(Token = "0x6000249")]
		[Address(RVA = "0x1353788", Offset = "0x1353788", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = System.EventArgs;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = \"Dummy \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A368A2]) = v38;\nL_001C:\n\tv39 = Il2CppMethodInfo;\n\tv41 = *([v39 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0023;\n\tv47 = 0xAD94B0(Il2CppMethodInfo, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv49 = 0xAD947C(v47, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv56 = *([v49 @ X0_v4]);\n\t*([v56 @ X8_v4+1A8])(v63, v49, *([v56 @ X8_v4+1B0]), methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv68 = System.String::Concat(\"Dummy \", v63);\n\tgoto L_003D;\n\tv75 = v70;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v75, v65, v66, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003D:\n\tUnityEngine.Debug::Log(v68);\n\tv97 = this.OnAdLoaded == 0;\n\tif (v97) goto L_005B;\n\tgoto L_0055;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v112, v79, v66, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv117 = System.EventArgs;\nL_0055:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdLoaded, this, v102.Empty);\nL_005B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X0_v2 (Il2CppMethodInfo)+53]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v56 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0x13538A8", Offset = "0x13538A8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368A3]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 1;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsLoaded()
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
			return true;
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x1353974", Offset = "0x1353974", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368A4]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x1353A38", Offset = "0x1353A38", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368A5]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
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

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x1353B04", Offset = "0x1353B04", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368A6]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600024E")]
		[Address(RVA = "0x1353BD0", Offset = "0x1353BD0", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368A7]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, serverSideVerificationOptions, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600024F")]
		[Address(RVA = "0x1353C94", Offset = "0x1353C94", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A368A8]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.RewardedAdDummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
