using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000035")]
	public class BannerView
	{
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x10")]
		private IBannerClient client;

		[CompilerGenerated]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		[CompilerGenerated]
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[Token(Token = "0x1400007F")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000287")]
			[Address(RVA = "0x13564C0", Offset = "0x13564C0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368CE]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000288")]
			[Address(RVA = "0x1356570", Offset = "0x1356570", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368CF]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000080")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000289")]
			[Address(RVA = "0x1356620", Offset = "0x1356620", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D0]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600028A")]
			[Address(RVA = "0x13566D0", Offset = "0x13566D0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D1]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000081")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x600028B")]
			[Address(RVA = "0x1356780", Offset = "0x1356780", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D2]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600028C")]
			[Address(RVA = "0x1356830", Offset = "0x1356830", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D3]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000082")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x600028D")]
			[Address(RVA = "0x13568E0", Offset = "0x13568E0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D4]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600028E")]
			[Address(RVA = "0x1356990", Offset = "0x1356990", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D5]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000083")]
		public event EventHandler<EventArgs> OnAdLeavingApplication
		{
			[CompilerGenerated]
			[Token(Token = "0x600028F")]
			[Address(RVA = "0x1356A40", Offset = "0x1356A40", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D6]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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
			[Token(Token = "0x6000290")]
			[Address(RVA = "0x1356AF0", Offset = "0x1356AF0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D7]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
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

		[Token(Token = "0x14000084")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000291")]
			[Address(RVA = "0x1356BA0", Offset = "0x1356BA0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D8]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000292")]
			[Address(RVA = "0x1356C50", Offset = "0x1356C50", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A368D9]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000285")]
		[Address(RVA = "0x1355DF0", Offset = "0x1355DF0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = GoogleMobileAds.Common.IBannerClient;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, adUnitId, adSize, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = GoogleMobileAds.IClientFactory;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, adUnitId, adSize, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A368CC]) = v43;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tv48 = GoogleMobileAds.Api.MobileAds::GetClientFactory();\n\tgoto L_004C;\n\tv108 = *([v51 @ X8_v4+B0]);\n\tv109 = v108 + 8;\n\tv111 = *([v148 @ X10_v16-8]);\n\tv153 = v111 == v55;\n\tif (v153) goto L_0045;\n\tv131 = v147 - 1;\n\tv133 = v148 + 0x10;\n\tv113 = v147 != 1;\n\tif (v113) goto L_FFFFFFFF;\n\tv134 = v53;\n\tv135 = 0;\n\tv136 = 0xB349B4(v134, v55, v135, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_004C;\nL_0045:\n\tv211 = *([v148 @ X10_v16]);\n\tv212 = v211 << 4;\n\tv213 = v51 + v212;\n\tv214 = v213 + 0x138;\nL_004C:\n\tv101 = GoogleMobileAds.IClientFactory::BuildBannerClient(v48);\n\tthis.client = v101;\n\tgoto L_0081;\n\tv224 = *([v219 @ X8_v7+B0]);\n\tv225 = v224 + 8;\n\tv227 = *([v264 @ X10_v11-8]);\n\tv269 = v227 == v223;\n\tif (v269) goto L_0076;\n\tv247 = v263 - 1;\n\tv249 = v264 + 0x10;\n\tv229 = v263 != 1;\n\tif (v229) goto L_FFFFFFFF;\n\tv250 = 0xC;\n\tv251 = v221;\n\tv252 = 0xB349B4(v251, v223, v250, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0081;\nL_0076:\n\tv275 = *([v264 @ X10_v11]);\n\tv276 = v275 + 0xC;\n\tv277 = v276 << 4;\n\tv278 = v219 + v277;\n\tv279 = v278 + 0x138;\nL_0081:\n\tGoogleMobileAds.Common.IBannerClient::CreateBannerView(v101, adUnitId, adSize, position);\n\tGoogleMobileAds.Api.BannerView::ConfigureBannerEvents(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			IClientFactory clientFactory = MobileAds.GetClientFactory();
			(client = clientFactory.BuildBannerClient()).CreateBannerView(adUnitId, adSize, position);
			ConfigureBannerEvents();
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0x135635C", Offset = "0x135635C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = GoogleMobileAds.Common.IBannerClient;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, adUnitId, adSize, x, y, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = GoogleMobileAds.IClientFactory;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, adUnitId, adSize, x, y, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A368CD]) = v46;\nL_001D:\n\tSystem.Object::.ctor(this);\n\tv51 = GoogleMobileAds.Api.MobileAds::GetClientFactory();\n\tgoto L_004E;\n\tv111 = *([v54 @ X8_v4+B0]);\n\tv112 = v111 + 8;\n\tv114 = *([v151 @ X10_v16-8]);\n\tv156 = v114 == v58;\n\tif (v156) goto L_0047;\n\tv134 = v150 - 1;\n\tv136 = v151 + 0x10;\n\tv116 = v150 != 1;\n\tif (v116) goto L_FFFFFFFF;\n\tv137 = v56;\n\tv138 = 0;\n\tv139 = 0xB349B4(v137, v58, v138, x, y, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004E;\nL_0047:\n\tv218 = *([v151 @ X10_v16]);\n\tv219 = v218 << 4;\n\tv220 = v54 + v219;\n\tv221 = v220 + 0x138;\nL_004E:\n\tv104 = GoogleMobileAds.IClientFactory::BuildBannerClient(v51);\n\tthis.client = v104;\n\tgoto L_0084;\n\tv231 = *([v226 @ X8_v7+B0]);\n\tv232 = v231 + 8;\n\tv234 = *([v271 @ X10_v11-8]);\n\tv276 = v234 == v230;\n\tif (v276) goto L_0078;\n\tv254 = v270 - 1;\n\tv256 = v271 + 0x10;\n\tv236 = v270 != 1;\n\tif (v236) goto L_FFFFFFFF;\n\tv257 = 0xD;\n\tv258 = v228;\n\tv259 = 0xB349B4(v258, v230, v257, x, y, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0084;\nL_0078:\n\tv282 = *([v271 @ X10_v11]);\n\tv283 = v282 + 0xD;\n\tv284 = v283 << 4;\n\tv285 = v226 + v284;\n\tv286 = v285 + 0x138;\nL_0084:\n\tGoogleMobileAds.Common.IBannerClient::CreateBannerView(v104, adUnitId, adSize, x, y);\n\tGoogleMobileAds.Api.BannerView::ConfigureBannerEvents(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			IClientFactory clientFactory = MobileAds.GetClientFactory();
			(client = clientFactory.BuildBannerClient()).CreateBannerView(adUnitId, adSize, x, y);
			ConfigureBannerEvents();
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0x1356D00", Offset = "0x1356D00", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.IBannerClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, request, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A368DA]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 0xE;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 0xE;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IBannerClient::LoadAd(this.client, request);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			client.LoadAd(request);
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0x1356DAC", Offset = "0x1356DAC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IBannerClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A368DB]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x10;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x10;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tGoogleMobileAds.Common.IBannerClient::HideBannerView(this.client);\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Hide()
		{
			client.HideBannerView();
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0x1356E50", Offset = "0x1356E50", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IBannerClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A368DC]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0xF;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0xF;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tGoogleMobileAds.Common.IBannerClient::ShowBannerView(this.client);\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show()
		{
			client.ShowBannerView();
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0x1356EF4", Offset = "0x1356EF4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IBannerClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A368DD]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x11;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x11;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tGoogleMobileAds.Common.IBannerClient::DestroyBannerView(this.client);\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Destroy()
		{
			client.DestroyBannerView();
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0x1356F98", Offset = "0x1356F98", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IBannerClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A368DE]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x12;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x12;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IBannerClient::GetHeightInPixels(this.client);\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetHeightInPixels()
		{
			return client.GetHeightInPixels();
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0x135703C", Offset = "0x135703C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IBannerClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A368DF]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x13;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x13;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IBannerClient::GetWidthInPixels(this.client);\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetWidthInPixels()
		{
			return client.GetWidthInPixels();
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0x13570E0", Offset = "0x13570E0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = GoogleMobileAds.Common.IBannerClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, adPosition, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A368E0]) = v36;\nL_001B:\n\tgoto L_0048;\n\tv46 = *([v40 @ X8_v3+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v96 @ X10_v7-8]);\n\tv101 = v49 == v43;\n\tif (v101) goto L_003A;\n\tv79 = v95 - 1;\n\tv81 = v96 + 0x10;\n\tv52 = v95 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = 0x14;\n\tv83 = v37;\n\tv84 = 0xB349B4(v83, v43, v82, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tgoto L_0048;\nL_003A:\n\tv155 = *([v96 @ X10_v7]);\n\tv156 = v155 + 0x14;\n\tv157 = v156 << 4;\n\tv158 = v40 + v157;\n\tv159 = v158 + 0x138;\nL_0048:\n\tGoogleMobileAds.Common.IBannerClient::SetPosition(this.client, adPosition);\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(AdPosition adPosition)
		{
			client.SetPosition(adPosition);
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0x135718C", Offset = "0x135718C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = GoogleMobileAds.Common.IBannerClient;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, x, y, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A368E1]) = v39;\nL_001D:\n\tgoto L_004C;\n\tv49 = *([v43 @ X8_v3+B0]);\n\tv50 = v49 + 8;\n\tv52 = *([v99 @ X10_v7-8]);\n\tv104 = v52 == v46;\n\tif (v104) goto L_003C;\n\tv82 = v98 - 1;\n\tv84 = v99 + 0x10;\n\tv55 = v98 != 1;\n\tif (v55) goto L_FFFFFFFF;\n\tv85 = 0x15;\n\tv86 = v40;\n\tv87 = 0xB349B4(v86, v46, v85, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_004C;\nL_003C:\n\tv162 = *([v99 @ X10_v7]);\n\tv163 = v162 + 0x15;\n\tv164 = v163 << 4;\n\tv165 = v43 + v164;\n\tv166 = v165 + 0x138;\nL_004C:\n\tGoogleMobileAds.Common.IBannerClient::SetPosition(this.client, x, y);\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(int x, int y)
		{
			client.SetPosition(x, y);
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0x1355F44", Offset = "0x1355F44", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv226 = Il2CppMethodInfo;\n\tv227 = \"il2cpp_codegen_initialize_runtime_metadata\"(v226, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv258 = Il2CppMethodInfo;\n\tv259 = \"il2cpp_codegen_initialize_runtime_metadata\"(v258, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv336 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv337 = \"il2cpp_codegen_initialize_runtime_metadata\"(v336, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv352 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv353 = \"il2cpp_codegen_initialize_runtime_metadata\"(v352, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv355 = System.EventHandler`1<System.EventArgs>;\n\tv356 = \"il2cpp_codegen_initialize_runtime_metadata\"(v355, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv358 = GoogleMobileAds.Common.IBannerClient;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v358, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A368E2]) = v48;\nL_0036:\n\tv51 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v51, this, Il2CppMethodInfo);\n\tgoto L_006F;\n\tv228 = *([v67 @ X8_v4+B0]);\n\tv229 = v228 + 8;\n\tv231 = *([v270 @ X10_v36-8]);\n\tv276 = v231 == v72;\n\tif (v276) goto L_0067;\n\tv253 = v271 - 1;\n\tv251 = v270 + 0x10;\n\tv233 = v271 != 1;\n\tif (v233) goto L_FFFFFFFF;\n\tv254 = v50;\n\tv255 = 0;\n\tv256 = 0xB349B4(v254, v72, v255, v57, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_006F;\nL_0067:\n\tv339 = *([v270 @ X10_v36]);\n\tv340 = v339 << 4;\n\tv341 = v67 + v340;\n\tv342 = v341 + 0x138;\nL_006F:\n\tGoogleMobileAds.Common.IBannerClient::add_OnAdLoaded(this.client, v51);\n\tv193 = new System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>::.ctor(v193, this, Il2CppMethodInfo);\n\tgoto L_00A8;\n\tv364 = *([v359 @ X8_v7+B0]);\n\tv365 = v364 + 8;\n\tv367 = *([v403 @ X10_v31-8]);\n\tv409 = v367 == v361;\n\tif (v409) goto L_009F;\n\tv389 = v404 - 1;\n\tv387 = v403 + 0x10;\n\tv369 = v404 != 1;\n\tif (v369) goto L_FFFFFFFF;\n\tv390 = 2;\n\tv391 = v219;\n\tv392 = 0xB349B4(v391, v361, v390, v175, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00A8;\nL_009F:\n\tv415 = *([v403 @ X10_v31]);\n\tv416 = v415 + 2;\n\tv417 = v416 << 4;\n\tv418 = v359 + v417;\n\tv419 = v418 + 0x138;\nL_00A8:\n\tGoogleMobileAds.Common.IBannerClient::add_OnAdFailedToLoad(this.client, v193);\n\tv194 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v194, this, Il2CppMethodInfo);\n\tgoto L_00E1;\n\tv433 = *([v428 @ X8_v10+B0]);\n\tv434 = v433 + 8;\n\tv436 = *([v472 @ X10_v26-8]);\n\tv478 = v436 == v430;\n\tif (v478) goto L_00D8;\n\tv458 = v473 - 1;\n\tv456 = v472 + 0x10;\n\tv438 = v473 != 1;\n\tif (v438) goto L_FFFFFFFF;\n\tv459 = 4;\n\tv460 = v220;\n\tv461 = 0xB349B4(v460, v430, v459, v176, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00E1;\nL_00D8:\n\tv484 = *([v472 @ X10_v26]);\n\tv485 = v484 + 4;\n\tv486 = v485 << 4;\n\tv487 = v428 + v486;\n\tv488 = v487 + 0x138;\nL_00E1:\n\tGoogleMobileAds.Common.IBannerClient::add_OnAdOpening(this.client, v194);\n\tv195 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v195, this, Il2CppMethodInfo);\n\tgoto L_011A;\n\tv502 = *([v497 @ X8_v13+B0]);\n\tv503 = v502 + 8;\n\tv505 = *([v541 @ X10_v21-8]);\n\tv547 = v505 == v499;\n\tif (v547) goto L_0111;\n\tv527 = v542 - 1;\n\tv525 = v541 + 0x10;\n\tv507 = v542 != 1;\n\tif (v507) goto L_FFFFFFFF;\n\tv528 = 6;\n\tv529 = v221;\n\tv530 = 0xB349B4(v529, v499, v528, v177, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_011A;\nL_0111:\n\tv553 = *([v541 @ X10_v21]);\n\tv554 = v553 + 6;\n\tv555 = v554 << 4;\n\tv556 = v497 + v555;\n\tv557 = v556 + 0x138;\nL_011A:\n\tGoogleMobileAds.Common.IBannerClient::add_OnAdClosed(this.client, v195);\n\tv196 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v196, this, Il2CppMethodInfo);\n\tgoto L_0155;\n\tv572 = *([v566 @ X8_v16+B0]);\n\tv573 = v572 + 8;\n\tv575 = *([v611 @ X10_v16-8]);\n\tv617 = v575 == v569;\n\tif (v617) goto L_014C;\n\tv597 = v612 - 1;\n\tv595 = v611 + 0x10;\n\tv577 = v612 != 1;\n\tif (v577) goto L_FFFFFFFF;\n\tv598 = 8;\n\tv599 = v222;\n\tv600 = 0xB349B4(v599, v569, v598, v178, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0155;\nL_014C:\n\tv623 = *([v611 @ X10_v16]);\n\tv624 = v623 + 8;\n\tv625 = v624 << 4;\n\tv626 = v566 + v625;\n\tv627 = v626 + 0x138;\nL_0155:\n\tGoogleMobileAds.Common.IBannerClient::add_OnAdLeavingApplication(this.client, v196);\n\tv197 = new System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>::.ctor(v197, this, Il2CppMethodInfo);\n\tgoto L_0195;\n\tv639 = *([v636 @ X8_v19+B0]);\n\tv640 = v639 + 8;\n\tv642 = *([v678 @ X10_v11-8]);\n\tv684 = v642 == v637;\n\tif (v684) goto L_0183;\n\tv664 = v679 - 1;\n\tv662 = v678 + 0x10;\n\tv644 = v679 != 1;\n\tif (v644) goto L_FFFFFFFF;\n\tv665 = 0xA;\n\tv666 = v223;\n\tv667 = 0xB349B4(v666, v637, v665, v179, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0195;\nL_0183:\n\tv690 = *([v678 @ X10_v11]);\n\tv691 = v690 + 0xA;\n\tv692 = v691 << 4;\n\tv693 = v636 + v692;\n\tv694 = v693 + 0x138;\nL_0195:\n\tGoogleMobileAds.Common.IBannerClient::add_OnPaidEvent(this.client, v197);\n\tthrow System.NullReferenceException;\n\treturn;\n// 252 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ConfigureBannerEvents()
		{
			EventHandler<EventArgs> value = delegate(object sender, EventArgs args)
			{
				if (this.OnAdLoaded != null)
				{
					this.OnAdLoaded(this, args);
				}
			};
			client.OnAdLoaded += value;
			EventHandler<AdFailedToLoadEventArgs> value2 = delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
			client.OnAdFailedToLoad += value2;
			EventHandler<EventArgs> value3 = delegate(object sender, EventArgs args)
			{
				if (this.OnAdOpening != null)
				{
					this.OnAdOpening(this, args);
				}
			};
			client.OnAdOpening += value3;
			EventHandler<EventArgs> value4 = delegate(object sender, EventArgs args)
			{
				if (this.OnAdClosed != null)
				{
					this.OnAdClosed(this, args);
				}
			};
			client.OnAdClosed += value4;
			EventHandler<EventArgs> value5 = delegate(object sender, EventArgs args)
			{
				if (this.OnAdLeavingApplication != null)
				{
					this.OnAdLeavingApplication(this, args);
				}
			};
			client.OnAdLeavingApplication += value5;
			EventHandler<AdValueEventArgs> value6 = delegate(object sender, AdValueEventArgs args)
			{
				if (this.OnPaidEvent != null)
				{
					this.OnPaidEvent(this, args);
				}
			};
			client.OnPaidEvent += value6;
		}

		[Obsolete("MediationAdapterClassName() is deprecated, use GetResponseInfo.MediationAdapterClassName() instead.")]
		[Token(Token = "0x600029C")]
		[Address(RVA = "0x1357248", Offset = "0x1357248", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IBannerClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A368E3]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 0x16;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 0x16;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IBannerClient::MediationAdapterClassName(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
		{
			return client.MediationAdapterClassName();
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0x13572EC", Offset = "0x13572EC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv14 = GoogleMobileAds.Common.IBannerClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = ResponseInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A368E4]) = v34;\nL_001E:\n\tgoto L_0045;\n\tv48 = *([v40 @ X8_v3+B0]);\n\tv49 = v48 + 8;\n\tv51 = *([v98 @ X10_v7-8]);\n\tv103 = v51 == v44;\n\tif (v103) goto L_003D;\n\tv81 = v97 - 1;\n\tv83 = v98 + 0x10;\n\tv54 = v97 != 1;\n\tif (v54) goto L_FFFFFFFF;\n\tv84 = 0x17;\n\tv85 = v35;\n\tv86 = 0xB349B4(v85, v44, v84, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0045;\nL_003D:\n\tv153 = *([v98 @ X10_v7]);\n\tv154 = v153 + 0x17;\n\tv155 = v154 << 4;\n\tv156 = v40 + v155;\n\tv157 = v156 + 0x138;\nL_0045:\n\tv163 = GoogleMobileAds.Common.IBannerClient::GetResponseInfoClient(this.client);\n\tv166 = new ResponseInfo();\n\tSystem.Object::.ctor(v166);\n\t*([v166 @ X0_v7 (System.Object)+10]) = v163;\n\treturn v166;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResponseInfo GetResponseInfo()
		{
			IResponseInfoClient responseInfoClient = client.GetResponseInfoClient();
			return null;
		}
	}
}
