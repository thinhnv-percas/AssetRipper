using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x2000014")]
	public class BannerClient : AndroidJavaProxy, IBannerClient
	{
		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x20")]
		private AndroidJavaObject bannerView;

		[CompilerGenerated]
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		[CompilerGenerated]
		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x50")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[Token(Token = "0x1400001D")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000096")]
			[Address(RVA = "0x13450D8", Offset = "0x13450D8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36798]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000097")]
			[Address(RVA = "0x1345188", Offset = "0x1345188", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36799]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400001E")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000098")]
			[Address(RVA = "0x1345238", Offset = "0x1345238", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3679A]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000099")]
			[Address(RVA = "0x13452E8", Offset = "0x13452E8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3679B]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400001F")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x600009A")]
			[Address(RVA = "0x1345398", Offset = "0x1345398", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3679C]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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
			[Token(Token = "0x600009B")]
			[Address(RVA = "0x1345448", Offset = "0x1345448", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3679D]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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

		[Token(Token = "0x14000020")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x600009C")]
			[Address(RVA = "0x13454F8", Offset = "0x13454F8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3679E]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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
			[Token(Token = "0x600009D")]
			[Address(RVA = "0x13455A8", Offset = "0x13455A8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3679F]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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

		[Token(Token = "0x14000021")]
		public event EventHandler<EventArgs> OnAdLeavingApplication
		{
			[CompilerGenerated]
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x1345658", Offset = "0x1345658", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367A0]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_OnAdLeavingApplication;
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
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x1345708", Offset = "0x1345708", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367A1]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_OnAdLeavingApplication;
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

		[Token(Token = "0x14000022")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x13457B8", Offset = "0x13457B8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367A2]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
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
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x1345868", Offset = "0x1345868", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367A3]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
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

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x133CD00", Offset = "0x133CD00", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv20 = UnityEngine.AndroidJavaClass;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv60 = UnityEngine.AndroidJavaObject;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv65 = UnityEngine.AndroidJavaProxy;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv71 = System.Object[];\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv75 = \"com.google.unity.ads.Banner\";\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv102 = \"com.google.unity.ads.UnityAdListener\";\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv151 = \"com.unity3d.player.UnityPlayer\";\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv180 = \"currentActivity\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A36797]) = v40;\nL_0036:\n\tgoto L_003B;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003B:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.google.unity.ads.UnityAdListener\");\n\tv63 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v63, \"com.unity3d.player.UnityPlayer\");\n\tv86 = UnityEngine.AndroidJavaObject::GetStatic(v63, \"currentActivity\");\n\t// 82 NewArr v93 @ X0_v17 (System.Object[]), typeof(System.Object[]), 2\n\tv181 = v86 == 0;\n\tif (v181) goto L_0061;\n\t// 91 IsInst v168 @ X0_v25, typeof(System.Object), v86 @ X0_v15 (System.Object)\n\tv171 = v168 == 0;\n\tif (v171) goto L_008D;\nL_0061:\n\tv93[0] = v86;\n\tv187 = this == 0;\n\tif (v187) goto L_0079;\n\t// 103 IsInst v169 @ X0_v23, typeof(System.Object), this @ X0 (GoogleMobileAds.Android.BannerClient)\n\tv172 = v169 == 0;\n\tif (v172) goto L_008D;\nL_0079:\n\tv93[1] = this;\n\tv209 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v209, \"com.google.unity.ads.Banner\", v93);\n\tthis.bannerView = v209;\n\treturn;\n\tv100 = new System.NullReferenceException();\n\tv149 = new System.IndexOutOfRangeException();\nL_008D:\n\tv178 = new System.ArrayTypeMismatchException();\n\tthrow v178;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BannerClient()
			: base("com.google.unity.ads.UnityAdListener")
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
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.unity.ads.Banner", array);
			bannerView = androidJavaObject;
			return;
			IL_011a:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x1345918", Offset = "0x1345918", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = System.Int32;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, adUnitId, adSize, position, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = System.Object[];\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, adUnitId, adSize, position, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = \"create\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, adUnitId, adSize, position, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A367A4]) = v47;\nL_0022:\n\t// 34 NewArr v51 @ X0_v3 (System.Object[]), typeof(System.Object[]), 3\n\tv59 = adUnitId == 0;\n\tif (v59) goto L_0032;\n\t// 43 IsInst v123 @ X0_v24, typeof(System.Object), adUnitId @ X1 (System.String)\n\tv127 = v123 == 0;\n\tif (v127) goto L_007B;\nL_0032:\n\tv51[0] = adUnitId;\n\tv132 = GoogleMobileAds.Android.Utils::GetAdSizeJavaObject(adSize);\n\tv210 = v132 == 0;\n\tif (v210) goto L_004C;\n\t// 58 IsInst v203 @ X0_v22, typeof(System.Object), v132 @ X0_v13 (UnityEngine.AndroidJavaObject)\n\tv205 = v203 == 0;\n\tif (v205) goto L_007B;\nL_004C:\n\tv51[1] = v132;\n\t// 80 Box v219 @ X0_v16, typeof(System.Int32), &position @ X3 (GoogleMobileAds.Api.AdPosition)\n\tv220 = v219 == 0;\n\tif (v220) goto L_0067;\n\t// 87 IsInst v204 @ X0_v20, typeof(System.Object), v219 @ X0_v16\n\tv206 = v204 == 0;\n\tif (v206) goto L_007B;\nL_0067:\n\tv51[2] = v219;\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"create\", v51);\n\treturn;\n\tv163 = new System.IndexOutOfRangeException();\nL_007B:\n\tv209 = new System.ArrayTypeMismatchException();\n\tthrow v209;\n\tthrow System.NullReferenceException;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			object[] array = new object[3];
			if (adUnitId != null)
			{
				object obj = adUnitId as object;
				if (obj == null)
				{
					goto IL_0146;
				}
			}
			array[0] = adUnitId;
			AndroidJavaObject adSizeJavaObject = Utils.GetAdSizeJavaObject(adSize);
			if (adSizeJavaObject != null)
			{
				object obj2 = adSizeJavaObject as object;
				if (obj2 == null)
				{
					goto IL_0146;
				}
			}
			array[1] = adSizeJavaObject;
			object obj3 = (int)position;
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
				if (obj4 == null)
				{
					goto IL_0146;
				}
			}
			array[2] = obj3;
			bannerView.Call("create", array);
			return;
			IL_0146:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x1345FBC", Offset = "0x1345FBC", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = System.Int32;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, adUnitId, adSize, x, y, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv56 = System.Object[];\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, adUnitId, adSize, x, y, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = \"create\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, adUnitId, adSize, x, y, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A367A5]) = v50;\nL_0024:\n\t// 36 NewArr v54 @ X0_v3 (System.Object[]), typeof(System.Object[]), 4\n\tv62 = adUnitId == 0;\n\tif (v62) goto L_0034;\n\t// 45 IsInst v136 @ X0_v29, typeof(System.Object), adUnitId @ X1 (System.String)\n\tv140 = v136 == 0;\n\tif (v140) goto L_0099;\nL_0034:\n\tv54[0] = adUnitId;\n\tv145 = GoogleMobileAds.Android.Utils::GetAdSizeJavaObject(adSize);\n\tv246 = v145 == 0;\n\tif (v246) goto L_004E;\n\t// 60 IsInst v236 @ X0_v27, typeof(System.Object), v145 @ X0_v13 (UnityEngine.AndroidJavaObject)\n\tv239 = v236 == 0;\n\tif (v239) goto L_0099;\nL_004E:\n\tv54[1] = v145;\n\t// 82 Box v254 @ X0_v16, typeof(System.Int32), &x @ X3 (System.Int32)\n\tv255 = v254 == 0;\n\tif (v255) goto L_0069;\n\t// 89 IsInst v237 @ X0_v25, typeof(System.Object), v254 @ X0_v16\n\tv240 = v237 == 0;\n\tif (v240) goto L_0099;\nL_0069:\n\tv54[2] = v254;\n\t// 109 Box v262 @ X0_v19, typeof(System.Int32), &y @ X4 (System.Int32)\n\tv263 = v262 == 0;\n\tif (v263) goto L_0084;\n\t// 116 IsInst v238 @ X0_v23, typeof(System.Object), v262 @ X0_v19\n\tv241 = v238 == 0;\n\tif (v241) goto L_0099;\nL_0084:\n\tv54[3] = v262;\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"create\", v54);\n\treturn;\n\tv192 = new System.IndexOutOfRangeException();\nL_0099:\n\tv245 = new System.ArrayTypeMismatchException();\n\tthrow v245;\n\tthrow System.NullReferenceException;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			object[] array = new object[4];
			if (adUnitId != null)
			{
				object obj = adUnitId as object;
				if (obj == null)
				{
					goto IL_01ac;
				}
			}
			array[0] = adUnitId;
			AndroidJavaObject adSizeJavaObject = Utils.GetAdSizeJavaObject(adSize);
			if (adSizeJavaObject != null)
			{
				object obj2 = adSizeJavaObject as object;
				if (obj2 == null)
				{
					goto IL_01ac;
				}
			}
			array[1] = adSizeJavaObject;
			object obj3 = x;
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
				if (obj4 == null)
				{
					goto IL_01ac;
				}
			}
			array[2] = obj3;
			object obj5 = y;
			if (obj5 != null)
			{
				object obj6 = obj5 as object;
				if (obj6 == null)
				{
					goto IL_01ac;
				}
			}
			array[3] = obj5;
			bannerView.Call("create", array);
			return;
			IL_01ac:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x1346160", Offset = "0x1346160", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Object[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, request, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = \"loadAd\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, request, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A367A6]) = v41;\nL_001B:\n\t// 27 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = GoogleMobileAds.Android.Utils::GetAdRequestJavaObject(request);\n\tv53 = v50 == 0;\n\tif (v53) goto L_002D;\n\t// 39 IsInst v67 @ X0_v16, typeof(System.Object), v50 @ X0_v5 (UnityEngine.AndroidJavaObject)\n\tv69 = v67 == 0;\n\tif (v69) goto L_0040;\nL_002D:\n\tv45[0] = v50;\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"loadAd\", v45);\n\treturn;\n\tv63 = new System.NullReferenceException();\n\tv77 = new System.IndexOutOfRangeException();\nL_0040:\n\tv83 = new System.ArrayTypeMismatchException();\n\tthrow v83;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			bannerView.Call("loadAd", array);
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x1346230", Offset = "0x1346230", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"show\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367A7]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"show\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowBannerView()
		{
			bannerView.Call("show");
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x13462EC", Offset = "0x13462EC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"hide\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367A8]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"hide\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void HideBannerView()
		{
			bannerView.Call("hide");
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x13463A8", Offset = "0x13463A8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"destroy\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367A9]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"destroy\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyBannerView()
		{
			bannerView.Call("destroy");
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x1346464", Offset = "0x1346464", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"getHeightInPixels\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367AA]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.bannerView, \"getHeightInPixels\", v77.Value);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetHeightInPixels()
		{
			return bannerView.Call<float>("getHeightInPixels", Array.Empty<object>());
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x1346534", Offset = "0x1346534", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"getWidthInPixels\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367AB]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, returnVal2, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.bannerView, \"getWidthInPixels\", v77.Value);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetWidthInPixels()
		{
			return bannerView.Call<float>("getWidthInPixels", Array.Empty<object>());
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x1346604", Offset = "0x1346604", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv26 = System.Int32;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, adPosition, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv51 = System.Object[];\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, adPosition, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv59 = \"setPosition\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, adPosition, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A367AC]) = v45;\nL_0021:\n\t// 33 NewArr v49 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\t// 38 Box v57 @ X0_v5, typeof(System.Int32), &adPosition @ X1 (GoogleMobileAds.Api.AdPosition)\n\tv62 = v57 == 0;\n\tif (v62) goto L_0035;\n\t// 47 IsInst v76 @ X0_v16, typeof(System.Object), v57 @ X0_v5\n\tv78 = v76 == 0;\n\tif (v78) goto L_0049;\nL_0035:\n\tv49[0] = v57;\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"setPosition\", v49);\n\treturn;\n\tv72 = new System.NullReferenceException();\n\tv86 = new System.IndexOutOfRangeException();\nL_0049:\n\tv92 = new System.ArrayTypeMismatchException();\n\tthrow v92;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(AdPosition adPosition)
		{
			object[] array = new object[1];
			object obj = (int)adPosition;
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = obj;
			bannerView.Call("setPosition", array);
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x13466FC", Offset = "0x13466FC", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv30 = System.Int32;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, x, y, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv54 = System.Object[];\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, x, y, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv62 = \"setPosition\";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, x, y, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A367AD]) = v48;\nL_0023:\n\t// 35 NewArr v52 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\t// 40 Box v60 @ X0_v5, typeof(System.Int32), &x @ X1 (System.Int32)\n\tv65 = v60 == 0;\n\tif (v65) goto L_0037;\n\t// 49 IsInst v126 @ X0_v21, typeof(System.Object), v60 @ X0_v5\n\tv130 = v126 == 0;\n\tif (v130) goto L_0067;\nL_0037:\n\tv52[0] = v60;\n\t// 59 Box v157 @ X0_v15, typeof(System.Int32), &y @ X2 (System.Int32)\n\tv162 = v157 == 0;\n\tif (v162) goto L_0052;\n\t// 66 IsInst v147 @ X0_v19, typeof(System.Object), v157 @ X0_v15\n\tv149 = v147 == 0;\n\tif (v149) goto L_0067;\nL_0052:\n\tv52[1] = v157;\n\tUnityEngine.AndroidJavaObject::Call(this.bannerView, \"setPosition\", v52);\n\treturn;\n\tv110 = new System.IndexOutOfRangeException();\n\tv122 = new System.NullReferenceException();\nL_0067:\n\tv154 = new System.ArrayTypeMismatchException();\n\tthrow v154;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(int x, int y)
		{
			object[] array = new object[2];
			object obj = x;
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					goto IL_00de;
				}
			}
			array[0] = obj;
			object obj3 = y;
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
				if (obj4 == null)
				{
					goto IL_00de;
				}
			}
			array[1] = obj3;
			bannerView.Call("setPosition", array);
			return;
			IL_00de:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x1346834", Offset = "0x1346834", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"getMediationAdapterClassName\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367AE]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.bannerView, \"getMediationAdapterClassName\", v77.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
		{
			return (string)bannerView.Call<object>("getMediationAdapterClassName", Array.Empty<object>());
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x1346904", Offset = "0x1346904", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = GoogleMobileAds.Android.ResponseInfoClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A367AF]) = v37;\nL_0015:\n\tv40 = new GoogleMobileAds.Android.ResponseInfoClient();\n\tGoogleMobileAds.Android.ResponseInfoClient::.ctor(v40, this.bannerView);\n\treturn v40;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IResponseInfoClient GetResponseInfoClient()
		{
			return new ResponseInfoClient(bannerView);
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x1346A50", Offset = "0x1346A50", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A367B0]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdLoaded == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdLoaded, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x1346AD0", Offset = "0x1346AD0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = GoogleMobileAds.Api.AdFailedToLoadEventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, errorReason, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A367B1]) = v36;\nL_0013:\n\tv38 = this.OnAdFailedToLoad == 0;\n\tif (v38) goto L_0031;\n\tv42 = new GoogleMobileAds.Api.AdFailedToLoadEventArgs();\n\tGoogleMobileAds.Api.AdFailedToLoadEventArgs::.ctor(v42);\n\tv73 = v42 == 0;\n\tif (v73) goto L_0032;\n\tv42.<Message>k__BackingField = errorReason;\n\tv62 = this.OnAdFailedToLoad == 0;\n\tif (v62) goto L_0032;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>::Invoke(this.OnAdFailedToLoad, this, v42);\nL_0031:\n\treturn;\nL_0032:\n\tthrow v42;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onAdFailedToLoad(string errorReason)
		{
			if (this.OnAdFailedToLoad == null)
			{
				return;
			}
			AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs();
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

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x1346B60", Offset = "0x1346B60", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A367B2]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdOpening == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdOpening, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x1346BE0", Offset = "0x1346BE0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A367B3]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdClosed == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdClosed, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x1346C60", Offset = "0x1346C60", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A367B4]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdLeavingApplication == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdLeavingApplication, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x1346CE0", Offset = "0x1346CE0", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = GoogleMobileAds.Api.AdValueEventArgs;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, precision, valueInMicros, currencyCode, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = GoogleMobileAds.Api.AdValue;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, precision, valueInMicros, currencyCode, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A367B5]) = v43;\nL_001A:\n\tv45 = this.OnPaidEvent == 0;\n\tif (v45) goto L_0048;\n\tv51 = new GoogleMobileAds.Api.AdValue();\n\tSystem.Object::.ctor(v51);\n\tv51.<Precision>k__BackingField = precision;\n\tv51.<Value>k__BackingField = valueInMicros;\n\tv51.<CurrencyCode>k__BackingField = currencyCode;\n\tv94 = new GoogleMobileAds.Api.AdValueEventArgs();\n\tGoogleMobileAds.Api.AdValueEventArgs::.ctor(v94);\n\tv94.<AdValue>k__BackingField = v51;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>::Invoke(this.OnPaidEvent, this, v94);\nL_0048:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
