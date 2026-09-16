using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GoogleMobileAds.Unity
{
	[Token(Token = "0x200000A")]
	public class BannerClient : BaseAdDummyClient, IBannerClient
	{
		[CompilerGenerated]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		[CompilerGenerated]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x50")]
		private Dictionary<AdSize, string> prefabAds;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x58")]
		private ButtonBehaviour buttonBehaviour;

		[Token(Token = "0x14000003")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x133EB78", Offset = "0x133EB78", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36733]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
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
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x133EC28", Offset = "0x133EC28", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36734]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
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

		[Token(Token = "0x14000004")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x133ECD8", Offset = "0x133ECD8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36735]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x133ED88", Offset = "0x133ED88", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36736]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000005")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x133EE38", Offset = "0x133EE38", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36737]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x133EEE8", Offset = "0x133EEE8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36738]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000006")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x133EF98", Offset = "0x133EF98", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36739]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x133F048", Offset = "0x133F048", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3673A]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000007")]
		public event EventHandler<EventArgs> OnAdLeavingApplication
		{
			[CompilerGenerated]
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x133F0F8", Offset = "0x133F0F8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3673B]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x133F1A8", Offset = "0x133F1A8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3673C]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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

		[Token(Token = "0x14000008")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x600002E")]
			[Address(RVA = "0x133F258", Offset = "0x133F258", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3673D]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x133F308", Offset = "0x133F308", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3673E]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x133F3B8", Offset = "0x133F3B8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, dummyAd, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, dummyAd, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, dummyAd, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv73 = UnityEngine.Events.UnityAction;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, dummyAd, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3673F]) = v37;\nL_0021:\n\tv46 = UnityEngine.GameObject::GetComponentInChildren(dummyAd);\n\tv55 = UnityEngine.Component::GetComponentInChildren(v46);\n\tv56 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v56, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v55.m_OnClick, v56);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddClickBehavior(GameObject dummyAd)
		{
			Image componentInChildren = dummyAd.GetComponentInChildren<Image>();
			Button componentInChildren2 = componentInChildren.GetComponentInChildren<Button>();
			UnityAction call = delegate
			{
				buttonBehaviour.OpenURL();
			};
			componentInChildren2.onClick.AddListener(call);
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x133F48C", Offset = "0x133F48C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = UnityEngine.GameObject;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36740]) = v38;\nL_0017:\n\tv40 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v40);\n\tv50 = UnityEngine.GameObject::AddComponent(v40);\n\tthis.buttonBehaviour = v50;\n\tButtonBehaviour::add_OnAdOpening(v50, this.OnAdOpening);\n\tButtonBehaviour::add_OnLeavingApplication(this.buttonBehaviour, this.OnAdLeavingApplication);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreateButtonBehavior()
		{
			GameObject gameObject = new GameObject();
			(buttonBehaviour = gameObject.AddComponent<ButtonBehaviour>()).OnAdOpening += this.OnAdOpening;
			buttonBehaviour.OnLeavingApplication += this.OnAdLeavingApplication;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x133F524", Offset = "0x133F524", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv22 = GoogleMobileAds.Api.AdSize;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, adUnitId, adSize, position, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, adUnitId, adSize, position, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv81 = UnityEngine.Object;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, adUnitId, adSize, position, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv87 = \"DummyAds/Banners/ADAPTIVE\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, adUnitId, adSize, position, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A36741]) = v40;\nL_0029:\n\tv55 = adSize.type != 2;\n\tif (v55) goto L_0036;\n\tgoto L_0039;\nL_0036:\n\tv93 = System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::get_Item(this.prefabAds, adSize);\nL_0039:\n\tGoogleMobileAds.Unity.BaseAdDummyClient::LoadAndSetPrefabAd(this, v90);\n\tgoto L_0046;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v174, v90, v88, position, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0046:\n\tv146 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\tv150 = v146 == 0;\n\tif (v150) goto L_007C;\n\tgoto L_0059;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v183, v115, v111, position, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv189 = GoogleMobileAds.Api.AdSize;\nL_0059:\n\tv147 = GoogleMobileAds.Api.AdSize::Equals(adSize, v190.SmartBanner);\n\tv195 = v147 & 1;\n\tv196 = v195 == 0;\n\tv149 = ~v196;\n\tif (v149) goto L_0074;\n\tv119 = adSize.type != 2;\n\tif (v119) goto L_0085;\nL_0074:\n\tGoogleMobileAds.Unity.BannerClient::SetAndStretchAd(this, this.prefabAd, position, adSize);\n\treturn;\nL_007C:\n\treturn;\nL_0085:\n\tGoogleMobileAds.Unity.BannerClient::AnchorAd(v147, this.prefabAd, position);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			//IL_00fc: Expected O, but got I4
			string prefabName;
			if (adSize.AdType == AdSize.Type.AnchoredAdaptive)
			{
				prefabName = "DummyAds/Banners/ADAPTIVE";
			}
			else
			{
				string text = prefabAds[adSize];
				prefabName = text;
			}
			LoadAndSetPrefabAd(prefabName);
			if (prefabAd != null)
			{
				BannerClient bannerClient = (BannerClient)adSize.Equals(AdSize.SmartBanner);
				if ((int)((nint)bannerClient & 1) != 0 || adSize.AdType == AdSize.Type.AnchoredAdaptive)
				{
					SetAndStretchAd(prefabAd, position, adSize);
				}
				else
				{
					bannerClient.AnchorAd(prefabAd, position);
				}
			}
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x133FE20", Offset = "0x133FE20", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv28 = GoogleMobileAds.Api.AdSize;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, adUnitId, adSize, x, y, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adUnitId, adSize, x, y, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv127 = UnityEngine.Object;\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, adUnitId, adSize, x, y, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv133 = \"DummyAds/Banners/ADAPTIVE\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v133, adUnitId, adSize, x, y, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A36742]) = v45;\nL_002C:\n\tv60 = adSize.type != 2;\n\tif (v60) goto L_0039;\n\tgoto L_003C;\nL_0039:\n\tv139 = System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::get_Item(this.prefabAds, adSize);\nL_003C:\n\tGoogleMobileAds.Unity.BaseAdDummyClient::LoadAndSetPrefabAd(this, v136);\n\tgoto L_0049;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v213, v136, v134, x, y, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0049:\n\tv187 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\tv190 = v187 == 0;\n\tif (v190) goto L_0083;\n\tv221 = GoogleMobileAds.Unity.BaseAdDummyClient::getRectTransform(v187, this.prefabAd);\n\tgoto L_0060;\n\tv227 = v223;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v227, v220, v163, x, y, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv231 = GoogleMobileAds.Api.AdSize;\nL_0060:\n\tv115 = GoogleMobileAds.Api.AdSize::Equals(adSize, v232.SmartBanner);\n\tv236 = v115 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0075;\n\tv78 = adSize.type != 2;\n\tif (v78) goto L_FFFFFFFF;\nL_0075:\n\tGoogleMobileAds.Unity.BannerClient::SetAndStretchAd(this, this.prefabAd, 0, adSize);\n\tv239 = v221 == 0;\n\tv118 = ~v239;\n\tif (v118) goto L_0092;\n\tgoto L_0095;\nL_0083:\n\treturn;\nL_0092:\n\t// 146 MakeStruct v148 @ AGG1343FA8_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v155 @ V0_v2 (System.Int32), y @ X4 (System.Int32)\n\tUnityEngine.RectTransform::set_anchoredPosition(v221, v148);\n\treturn;\nL_0095:\n\tthrow System.NullReferenceException;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			//IL_0096: Expected O, but got I4
			string prefabName;
			if (adSize.AdType == AdSize.Type.AnchoredAdaptive)
			{
				prefabName = "DummyAds/Banners/ADAPTIVE";
			}
			else
			{
				string text = prefabAds[adSize];
				prefabName = text;
			}
			LoadAndSetPrefabAd(prefabName);
			bool flag = prefabAd != null;
			if (!flag)
			{
				return;
			}
			RectTransform rectTransform = ((BaseAdDummyClient)flag).getRectTransform(prefabAd);
			int num;
			if (adSize.Equals(AdSize.SmartBanner) || adSize.AdType == AdSize.Type.AnchoredAdaptive)
			{
				SetAndStretchAd(prefabAd, default(AdPosition), adSize);
				bool flag2 = (object)rectTransform == null;
				bool flag3 = !flag2;
				num = 0;
				if (!flag3)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				num = x;
			}
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = num;
			anchoredPosition.y = y;
			rectTransform.anchoredPosition = anchoredPosition;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x1340020", Offset = "0x1340020", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = GoogleMobileAds.Api.AdFailedToLoadEventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.EventArgs;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = UnityEngine.Object;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = \"Prefab Ad is Null\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36743]) = v38;\nL_0021:\n\tgoto L_0026;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, request, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv52 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_003F;\n\tGoogleMobileAds.Unity.BannerClient::ShowBannerView(this);\n\tv63 = this.OnAdLoaded;\n\tv64 = this.OnAdLoaded == 0;\n\tif (v64) goto L_005E;\n\tgoto L_0039;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v79, v50, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv110 = System.EventArgs;\nL_0039:\n\tv89 = v63.invoke_impl;\n\tv95 = v63.method_code;\n\tv87 = v63.method;\n\tgoto L_0058;\nL_003F:\n\tv61 = this.OnAdFailedToLoad;\n\tv62 = this.OnAdFailedToLoad == 0;\n\tif (v62) goto L_005E;\n\tv68 = new GoogleMobileAds.Api.AdFailedToLoadEventArgs();\n\tGoogleMobileAds.Api.AdFailedToLoadEventArgs::.ctor(v68);\n\tv99 = v68 == 0;\n\tif (v99) goto L_005F;\n\tv68.<Message>k__BackingField = \"Prefab Ad is Null\";\n\tv89 = v61.invoke_impl;\n\tv95 = v61.method_code;\n\tv87 = v61.method;\nL_0058:\n\t// 88 IndirectJump v89 @ X4_v1 (System.IntPtr), v95 @ X0_v6 (System.IntPtr), v95 @ X0_v6 (System.IntPtr), v93 @ X1_v2 (GoogleMobileAds.Unity.BannerClient), v91 @ X2_v2 (GoogleMobileAds.Api.AdFailedToLoadEventArgs), v87 @ X3_v1 (System.IntPtr), v89 @ X4_v1 (System.IntPtr), v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_005E:\n\treturn;\nL_005F:\n\tthrow v68;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			if (prefabAd != null)
			{
				ShowBannerView();
				EventHandler<EventArgs> eventHandler = this.OnAdLoaded;
				if (this.OnAdLoaded == null)
				{
					return;
				}
				IntPtr invoke_impl = eventHandler.invoke_impl;
				IntPtr method_code = eventHandler.method_code;
				IntPtr method = eventHandler.method;
			}
			else
			{
				EventHandler<AdFailedToLoadEventArgs> eventHandler2 = this.OnAdFailedToLoad;
				if (this.OnAdFailedToLoad == null)
				{
					return;
				}
				AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs();
				if (e == null)
				{
					throw e;
				}
				e.Message = "Prefab Ad is Null";
				IntPtr invoke_impl = eventHandler2.invoke_impl;
				IntPtr method_code = eventHandler2.method_code;
				IntPtr method = eventHandler2.method;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ X4_v1 (System.IntPtr) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x134014C", Offset = "0x134014C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36744]) = v37;\nL_0017:\n\tgoto L_001E;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = GoogleMobileAds.Unity.BaseAdDummyClient;\nL_001E:\n\tv49 = GoogleMobileAds.Unity.BaseAdDummyClient::getRectTransform(GoogleMobileAds.Unity.BaseAdDummyClient, this.prefabAd);\n\tv52 = UnityEngine.RectTransform::get_anchoredPosition(v49);\n\t// 40 MakeStruct v62 @ AGG13441C0_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v52 @ V0_v2 (UnityEngine.Vector2), v52.y (System.Single), 0\n\tv63 = DummyAdBehaviour::ShowAd(v49, this.prefabAd, v62);\n\tthis.dummyAd = v63;\n\tGoogleMobileAds.Unity.BannerClient::CreateButtonBehavior(this);\n\tGoogleMobileAds.Unity.BannerClient::AddClickBehavior(this, this.dummyAd);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowBannerView()
		{
			RectTransform rectTransform = ((BaseAdDummyClient)(object)typeof(BaseAdDummyClient)).getRectTransform(prefabAd);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			Vector3 position = default(Vector3);
			position.x = anchoredPosition.x;
			position.y = anchoredPosition.y;
			position.z = 0f;
			GameObject gameObject = ((DummyAdBehaviour)(object)rectTransform).ShowAd(prefabAd, position);
			dummyAd = gameObject;
			CreateButtonBehavior();
			AddClickBehavior(dummyAd);
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x1340240", Offset = "0x1340240", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36745]) = v37;\nL_0017:\n\tgoto L_0024;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = GoogleMobileAds.Unity.BaseAdDummyClient;\nL_0024:\n\tDummyAdBehaviour::DestroyAd(GoogleMobileAds.Unity.BaseAdDummyClient, this.dummyAd);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void HideBannerView()
		{
			((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).DestroyAd(dummyAd);
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x13402A8", Offset = "0x13402A8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36746]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = GoogleMobileAds.Unity.BaseAdDummyClient;\nL_001F:\n\tDummyAdBehaviour::DestroyAd(GoogleMobileAds.Unity.BaseAdDummyClient, this.dummyAd);\n\tthis.prefabAd = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyBannerView()
		{
			((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).DestroyAd(dummyAd);
			prefabAd = null;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x1340318", Offset = "0x1340318", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36747]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\tv51 = v48 == 0;\n\tif (v51) goto L_002F;\n\tv53 = GoogleMobileAds.Unity.BaseAdDummyClient::getRectTransform(v48, this.prefabAd);\n\tv77 = UnityEngine.RectTransform::get_sizeDelta(v53);\nL_002F:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetHeightInPixels()
		{
			//IL_004a: Expected O, but got I4
			bool flag = prefabAd != null;
			bool flag2 = !flag;
			float result = 0f;
			if (!flag2)
			{
				RectTransform rectTransform = ((BaseAdDummyClient)flag).getRectTransform(prefabAd);
				result = rectTransform.sizeDelta.y;
			}
			return result;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x13403A0", Offset = "0x13403A0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36748]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\tv51 = v48 == 0;\n\tif (v51) goto L_002E;\n\tv53 = GoogleMobileAds.Unity.BaseAdDummyClient::getRectTransform(v48, this.prefabAd);\n\tv57 = UnityEngine.RectTransform::get_sizeDelta(v53);\nL_002E:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetWidthInPixels()
		{
			//IL_004a: Expected O, but got I4
			bool flag = prefabAd != null;
			bool flag2 = !flag;
			float result = 0f;
			if (!flag2)
			{
				RectTransform rectTransform = ((BaseAdDummyClient)flag).getRectTransform(prefabAd);
				result = rectTransform.sizeDelta.x;
			}
			return result;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x1340424", Offset = "0x1340424", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, adPosition, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv48 = UnityEngine.Object;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adPosition, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv57 = \"No existing banner in game\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, adPosition, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A36749]) = v41;\nL_0020:\n\tgoto L_0025;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, adPosition, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv55 = UnityEngine.Object::op_Inequality(this.dummyAd, 0);\n\tv59 = v55 == 0;\n\tif (v59) goto L_003B;\n\tGoogleMobileAds.Unity.BannerClient::AnchorAd(v55, this.dummyAd, adPosition);\n\treturn;\nL_003B:\n\tgoto L_0045;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v70, v53, v54, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tUnityEngine.Debug::Log(\"No existing banner in game\");\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(AdPosition adPosition)
		{
			//IL_0045: Expected O, but got I4
			bool flag = dummyAd != null;
			if (flag)
			{
				((BannerClient)flag).AnchorAd(dummyAd, adPosition);
			}
			else
			{
				Debug.Log("No existing banner in game");
			}
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x13404F0", Offset = "0x13404F0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv26 = UnityEngine.Debug;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, x, y, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = UnityEngine.Object;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, x, y, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = \"No existing banner in game\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, x, y, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A3674A]) = v44;\nL_0022:\n\tgoto L_0027;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, x, y, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0027:\n\tv58 = UnityEngine.Object::op_Inequality(this.dummyAd, 0);\n\tv62 = v58 == 0;\n\tif (v62) goto L_0042;\n\tv64 = GoogleMobileAds.Unity.BaseAdDummyClient::getRectTransform(v58, this.dummyAd);\n\t// 57 MakeStruct v93 @ AGG1344594_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), x @ X1 (System.Int32), y @ X2 (System.Int32)\n\tUnityEngine.RectTransform::set_anchoredPosition(v64, v93);\n\treturn;\nL_0042:\n\tgoto L_004F;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v67, v56, v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004F:\n\tUnityEngine.Debug::Log(\"No existing banner in game\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(int x, int y)
		{
			//IL_0041: Expected O, but got I4
			bool flag = dummyAd != null;
			if (flag)
			{
				RectTransform rectTransform = ((BaseAdDummyClient)flag).getRectTransform(dummyAd);
				Vector2 anchoredPosition = default(Vector2);
				anchoredPosition.x = x;
				anchoredPosition.y = y;
				rectTransform.anchoredPosition = anchoredPosition;
			}
			else
			{
				Debug.Log("No existing banner in game");
			}
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x133F798", Offset = "0x133F798", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv30 = GoogleMobileAds.Api.AdSize;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv67 = UnityEngine.Debug;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv190 = UnityEngine.Object;\n\tv191 = \"il2cpp_codegen_initialize_runtime_metadata\"(v190, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv193 = \"This is a Test Smart Banner\";\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv266 = \"This is a Test Adaptive Banner\";\n\tv267 = \"il2cpp_codegen_initialize_runtime_metadata\"(v266, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv269 = \"DummyAds/Banners/CENTER\";\n\tv270 = \"il2cpp_codegen_initialize_runtime_metadata\"(v269, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv273 = \"Invalid Dummy Ad\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v273, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A3674B]) = v47;\nL_0038:\n\tgoto L_003D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v48, dummyAd, pos, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003D:\n\tv60 = UnityEngine.Object::op_Inequality(dummyAd, 0);\n\tv65 = v60 == 0;\n\tif (v65) goto L_008A;\n\tv85 = UnityEngine.GameObject::GetComponentInChildren(dummyAd);\n\tv145 = UnityEngine.Component::GetComponentInChildren(v85);\n\t// 84 MakeStruct v128 @ AGG13438B0_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tUnityEngine.RectTransform::set_pivot(v145, v128);\n\tv274 = pos < 6;\n\tv275 = ~v274;\n\tv120 = pos - 6;\n\tv277 = v120 == 0;\n\tv279 = ~v277;\n\tv280 = v275 & v279;\n\tif (v280) goto L_00B7;\n\tv169 = 1 << pos;\n\tv283 = v169 & 0xD;\n\tv285 = v283 == 0;\n\tv92 = ~v285;\n\tif (v92) goto L_009A;\n\tv291 = v169 & 0x32;\n\tv112 = v291 == 0;\n\tif (v112) goto L_00BF;\n\tv299 = UnityEngine.RectTransform::get_sizeDelta(v145);\n\tUnityEngine.RectTransform::SetInsetAndSizeFromParentEdge(v145, 3, 0f, v299.y);\n\tv336 = UnityEngine.RectTransform::get_sizeDelta(v145);\n\tv348 = v336.y;\n\tgoto L_00A6;\nL_008A:\n\tgoto L_0096;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v73, v58, v59, adSize, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0096:\n\tUnityEngine.Debug::Log(\"Invalid Dummy Ad\");\n\treturn;\nL_009A:\n\tv294 = UnityEngine.RectTransform::get_sizeDelta(v145);\n\tUnityEngine.RectTransform::SetInsetAndSizeFromParentEdge(v145, 2, 0f, v294.y);\n\tv333 = UnityEngine.RectTransform::get_sizeDelta(v145);\n\tv348 = v333.y;\nL_00A6:\n\tv229 = v348 * v349;\nL_00B2:\n\t// 178 MakeStruct v200 @ AGG134399C_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v231 @ V0_v3 (UnityEngine.Vector3), v229 @ V1_v3 (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition(v145, v200);\n\treturn;\nL_00B7:\n\tv231 = UnityEngine.Transform::get_position(v145);\n\tv229 = v231.y;\n\tgoto L_00B2;\nL_00BF:\n\tGoogleMobileAds.Unity.BaseAdDummyClient::LoadAndSetPrefabAd(this, \"DummyAds/Banners/CENTER\");\n\tv93 = adSize.type != 2;\n\tif (v93) goto L_00E8;\n\tGoogleMobileAds.Unity.BaseAdDummyClient::LoadAndSetPrefabAd(this, \"DummyAds/Banners/CENTER\");\n\tv148 = UnityEngine.GameObject::GetComponentInChildren(this.prefabAd);\n\tv240 = UnityEngine.Component::GetComponentInChildren(v148);\n\tv258 = *([v240 @ X0_v23 (UnityEngine.UI.Text)]);\n\tgoto L_0108;\nL_00E8:\n\tgoto L_00EC;\n\tv350 = \"il2cpp_codegen_runtime_class_init\"(v344, v137, v59, adSize, methodInfo, v33, v34, v35, v132, v130, v38, v39, v40, v41, v42, v43);\n\tv352 = GoogleMobileAds.Api.AdSize;\nL_00EC:\n\t;\n\tv321 = GoogleMobileAds.Api.AdSize::Equals(adSize, v353.SmartBanner);\n\tv323 = v321 == 0;\n\tif (v323) goto L_FFFFFFFF;\n\tGoogleMobileAds.Unity.BaseAdDummyClient::LoadAndSetPrefabAd(this, \"DummyAds/Banners/CENTER\");\n\tv151 = UnityEngine.GameObject::GetComponentInChildren(this.prefabAd);\n\tv240 = UnityEngine.Component::GetComponentInChildren(v151);\n\tv258 = *([v240 @ X0_v23 (UnityEngine.UI.Text)]);\nL_0108:\n\tv237 = *([v208 @ X9_v6 (System.String)]);\n\tv197 = *([v258 @ X8_v14 (Il2CppClass<UnityEngine.UI.Text>)+5E8]);\n\tv234 = *([v258 @ X8_v14 (Il2CppClass<UnityEngine.UI.Text>)+5F0]);\n\t// 275 IndirectJump v197 @ X3_v1, v240 @ X0_v23 (UnityEngine.UI.Text), v240 @ X0_v23 (UnityEngine.UI.Text), v237 @ X1_v16 (Il2CppClass<System.String>), v234 @ X2_v7, v197 @ X3_v1, methodInfo @ X4 (Il2CppMethodInfo), v33 @ X5, v34 @ X6, v35 @ X7, 0.5f, 0.5f, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tgoto L_00B2;\n\tthrow System.NullReferenceException;\n\treturn;\n// 188 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetAndStretchAd(GameObject dummyAd, AdPosition pos, AdSize adSize)
		{
			//IL_0297: Expected I, but got O
			//IL_0366: Expected I, but got O
			//IL_0376: Expected O, but got I
			//IL_0386: Expected O, but got I
			//IL_02e8: Expected I, but got O
			RectTransform componentInChildren2;
			string text;
			float y2;
			Vector3 vector;
			if (dummyAd != null)
			{
				Image componentInChildren = dummyAd.GetComponentInChildren<Image>();
				componentInChildren2 = componentInChildren.GetComponentInChildren<RectTransform>();
				Vector2 pivot = default(Vector2);
				pivot.x = 0.5f;
				pivot.y = 0.5f;
				componentInChildren2.pivot = pivot;
				bool flag = pos < AdPosition.Center;
				bool flag2 = !flag;
				int num = (int)(pos - 6);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num2 = 1 << (int)pos;
					float y;
					float num4;
					if ((num2 & 0xD) == 0)
					{
						if ((num2 & 0x32) == 0)
						{
							LoadAndSetPrefabAd("DummyAds/Banners/CENTER");
							if (adSize.AdType == AdSize.Type.AnchoredAdaptive)
							{
								LoadAndSetPrefabAd("DummyAds/Banners/CENTER");
								Image componentInChildren3 = prefabAd.GetComponentInChildren<Image>();
								Text componentInChildren4 = componentInChildren3.GetComponentInChildren<Text>();
								nint num3 = (nint)componentInChildren4;
								text = "This is a Test Adaptive Banner";
								goto IL_035e;
							}
							goto IL_0390;
						}
						componentInChildren2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0f, componentInChildren2.sizeDelta.y);
						y = componentInChildren2.sizeDelta.y;
						num4 = 0.5f;
					}
					else
					{
						componentInChildren2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0f, componentInChildren2.sizeDelta.y);
						y = componentInChildren2.sizeDelta.y;
						num4 = -0.5f;
					}
					y2 = y * num4;
					vector = default(Vector3);
				}
				else
				{
					vector = componentInChildren2.position;
					y2 = vector.y;
				}
				goto IL_0331;
			}
			Debug.Log("Invalid Dummy Ad");
			return;
			IL_0390:
			if (adSize.Equals(AdSize.SmartBanner))
			{
				LoadAndSetPrefabAd("DummyAds/Banners/CENTER");
				Image componentInChildren5 = prefabAd.GetComponentInChildren<Image>();
				Text componentInChildren4 = componentInChildren5.GetComponentInChildren<Text>();
				nint num3 = (nint)componentInChildren4;
				text = "This is a Test Smart Banner";
				goto IL_035e;
			}
			y2 = 0f;
			vector = default(Vector3);
			goto IL_0331;
			IL_035e:
			nint num5 = (nint)text;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ X8_v14 (Il2CppClass<UnityEngine.UI.Text>)+5E8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ X8_v14 (Il2CppClass<UnityEngine.UI.Text>)+5F0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v197 @ X3_v1 (should have been resolved before IL gen)");
			goto IL_0390;
			IL_0331:
			Vector2 anchoredPosition = default(Vector2);
			anchoredPosition.x = vector.x;
			anchoredPosition.y = y2;
			componentInChildren2.anchoredPosition = anchoredPosition;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x133FAC0", Offset = "0x133FAC0", Length = "0x360")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, dummyAd, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = UnityEngine.Debug;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, dummyAd, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, dummyAd, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv65 = UnityEngine.Object;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, dummyAd, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv77 = \"Invalid Dummy Ad\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, dummyAd, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv45 = 1;\n\t*([1A3674C]) = v45;\nL_0027:\n\tgoto L_002C;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v46, dummyAd, position, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002C:\n\tv58 = UnityEngine.Object::op_Inequality(dummyAd, 0);\n\tv63 = v58 == 0;\n\tif (v63) goto L_007C;\n\tv82 = UnityEngine.GameObject::GetComponentInChildren(dummyAd);\n\tv86 = UnityEngine.Component::GetComponentInChildren(v82);\n\tv189 = UnityEngine.RectTransform::get_sizeDelta(v86);\n\tv192 = UnityEngine.RectTransform::get_sizeDelta(v86);\n\tv165 = v192.y;\n\tv193 = position < 5;\n\tv159 = ~v193;\n\tv156 = position - 5;\n\tv150 = v156 == 0;\n\tv194 = ~v150;\n\tv135 = v159 & v194;\n\tif (v135) goto L_008D;\n\tv132 = 0x424000 + 0x29C;\n\tv123 = *([v132 @ X9_v2 (System.Int32)+position @ X2 (GoogleMobileAds.Api.AdPosition)]) << 2;\n\tv129 = 0x1343BD0 + v123;\n\t// 94 IndirectJump v129 @ X10_v2 (System.Int32), v86 @ X0_v14 (UnityEngine.RectTransform), v86 @ X0_v14 (UnityEngine.RectTransform), 0, 0, methodInfo @ X3 (Il2CppMethodInfo), v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, 0.5f, v165 @ V1_v2 (System.Single), v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tV0 = 0.5f;\n\tV1 = 0.5f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 99 MakeStruct AGG1343BE0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_pivot(X0, AGG1343BE0_1, X1);\n\tV0 = 0.5f;\n\tV1 = 1f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 105 MakeStruct AGG1343BF4_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1343BF4_1, X1);\n\tV0 = 0.5f;\n\tV1 = 1f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 111 MakeStruct AGG1343C08_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1343C08_1, X1);\n\tV1 = -V8;\n\tV0 = 0;\n\tgoto L_00DD;\nL_007C:\n\tgoto L_0088;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v71, v56, v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0088:\n\tUnityEngine.Debug::Log(\"Invalid Dummy Ad\");\n\treturn;\nL_008D:\n\t// 141 MakeStruct v116 @ AGG1343C60_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tUnityEngine.RectTransform::set_pivot(v86, v116);\n\t// 147 MakeStruct v113 @ AGG1343C74_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tUnityEngine.RectTransform::set_anchorMin(v86, v113);\n\t// 153 MakeStruct v110 @ AGG1343C88_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tUnityEngine.RectTransform::set_anchorMax(v86, v110);\n\tgoto L_00DD;\n\tV0 = 0.5f;\n\tV1 = 0.5f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 162 MakeStruct AGG1343CA8_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_pivot(X0, AGG1343CA8_1, X1);\n\tV0 = 0.5f;\n\tV1 = 0;\n\tX0 = X19;\n\tX1 = 0;\n\t// 168 MakeStruct AGG1343CBC_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1343CBC_1, X1);\n\tV0 = 0.5f;\n\tV1 = 0;\n\tX0 = X19;\n\tX1 = 0;\n\t// 174 MakeStruct AGG1343CD0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1343CD0_1, X1);\n\tV0 = 0;\n\tgoto L_0106;\n\tV0 = 0.5f;\n\tV1 = 0.5f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 182 MakeStruct AGG1343CEC_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_pivot(X0, AGG1343CEC_1, X1);\n\tV0 = 0;\n\tV1 = 1f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 188 MakeStruct AGG1343D00_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1343D00_1, X1);\n\tV0 = 0;\n\tV1 = 1f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 194 MakeStruct AGG1343D14_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1343D14_1, X1);\n\tV1 = -V8;\n\tX0 = X19;\n\tV0 = V9;\n\tgoto L_0111;\n\tV0 = 0.5f;\n\tV1 = 0.5f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 204 MakeStruct AGG1343D38_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_pivot(X0, AGG1343D38_1, X1);\n\tV0 = 1f;\n\tV1 = 1f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 210 MakeStruct AGG1343D4C_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1343D4C_1, X1);\n\tV0 = 1f;\n\tV1 = 1f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 216 MakeStruct AGG1343D60_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1343D60_1, X1);\n\tV0 = -V9;\n\tV1 = -V8;\nL_00DD:\n\tgoto L_0111;\n\tV0 = 0.5f;\n\tV1 = 0.5f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 226 MakeStruct AGG1343D84_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_pivot(X0, AGG1343D84_1, X1);\n\tV0 = 0;\n\tV1 = 0;\n\tX0 = X19;\n\tX1 = 0;\n\t// 232 MakeStruct AGG1343D98_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1343D98_1, X1);\n\tV0 = 0;\n\tV1 = 0;\n\tX0 = X19;\n\tX1 = 0;\n\t// 238 MakeStruct AGG1343DAC_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1343DAC_1, X1);\n\tX0 = X19;\n\tV0 = V9;\n\tgoto L_0107;\n\tV0 = 0.5f;\n\tV1 = 0.5f;\n\tX0 = X19;\n\tX1 = 0;\n\t// 247 MakeStruct AGG1343DCC_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_pivot(X0, AGG1343DCC_1, X1);\n\tV0 = 1f;\n\tV1 = 0;\n\tX0 = X19;\n\tX1 = 0;\n\t// 253 MakeStruct AGG1343DE0_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMin(X0, AGG1343DE0_1, X1);\n\tV0 = 1f;\n\tV1 = 0;\n\tX0 = X19;\n\tX1 = 0;\n\t// 259 MakeStruct AGG1343DF4_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.RectTransform::set_anchorMax(X0, AGG1343DF4_1, X1);\n\tV0 = -V9;\nL_0106:\n\tX0 = X19;\nL_0107:\n\tV1 = V8;\nL_0111:\n\t// 273 MakeStruct v107 @ AGG1343E18_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 0\n\tUnityEngine.RectTransform::set_anchoredPosition(v86, v107);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AnchorAd(GameObject dummyAd, AdPosition position)
		{
			if (dummyAd != null)
			{
				Image componentInChildren = dummyAd.GetComponentInChildren<Image>();
				RectTransform componentInChildren2 = componentInChildren.GetComponentInChildren<RectTransform>();
				Vector2 sizeDelta = componentInChildren2.sizeDelta;
				float y = componentInChildren2.sizeDelta.y;
				bool flag = position < AdPosition.BottomRight;
				bool flag2 = !flag;
				int num = (int)(position - 5);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					Vector2 pivot = default(Vector2);
					pivot.x = 0.5f;
					pivot.y = 0.5f;
					componentInChildren2.pivot = pivot;
					Vector2 anchorMin = default(Vector2);
					anchorMin.x = 0.5f;
					anchorMin.y = 0.5f;
					componentInChildren2.anchorMin = anchorMin;
					Vector2 anchorMax = default(Vector2);
					anchorMax.x = 0.5f;
					anchorMax.y = 0.5f;
					componentInChildren2.anchorMax = anchorMax;
					Vector2 anchoredPosition = default(Vector2);
					anchoredPosition.x = 0f;
					anchoredPosition.y = 0f;
					componentInChildren2.anchoredPosition = anchoredPosition;
					return;
				}
				int num2 = 4341760 + 668;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X9_v2 (System.Int32)+position @ X2 (GoogleMobileAds.Api.AdPosition)]");
				int num3 = (int)((nint)0 << 2);
				int num4 = 20200400 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			Debug.Log("Invalid Dummy Ad");
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x133CED0", Offset = "0x133CED0", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tv36 = GoogleMobileAds.Api.AdSize;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv78 = System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv104 = \"DummyAds/Banners/FULL_BANNER\";\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv113 = \"DummyAds/Banners/LARGE_BANNER\";\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv160 = \"DummyAds/Banners/SMART_BANNER\";\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv169 = \"DummyAds/Banners/LEADERBOARD\";\n\tv170 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv178 = \"DummyAds/Banners/MEDIUM_RECTANGLE\";\n\tv179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v178, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv183 = \"DummyAds/Banners/BANNER\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v183, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A3674D]) = v56;\nL_003D:\n\tv58 = new System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::.ctor(v58);\n\tgoto L_005F;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v67, v62, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_005F:\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v58, v87.Banner, \"DummyAds/Banners/BANNER\");\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v58, v110.SmartBanner, \"DummyAds/Banners/SMART_BANNER\");\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v58, v119.MediumRectangle, \"DummyAds/Banners/MEDIUM_RECTANGLE\");\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v58, v166.IABBanner, \"DummyAds/Banners/FULL_BANNER\");\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v58, v175.Leaderboard, \"DummyAds/Banners/LEADERBOARD\");\n\tv181 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v181);\n\tv181.type = *([407CC0]);\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v58, v181, \"DummyAds/Banners/LARGE_BANNER\");\n\tthis.prefabAds = v58;\n\tgoto L_009E;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v189, v188, v132, v130, v41, v42, v43, v44, v124, v46, v47, v48, v49, v50, v51, v52);\nL_009E:\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BannerClient()
		{
			Dictionary<AdSize, string> dictionary = new Dictionary<AdSize, string>
			{
				{
					AdSize.Banner,
					"DummyAds/Banners/BANNER"
				},
				{
					AdSize.SmartBanner,
					"DummyAds/Banners/SMART_BANNER"
				},
				{
					AdSize.MediumRectangle,
					"DummyAds/Banners/MEDIUM_RECTANGLE"
				},
				{
					AdSize.IABBanner,
					"DummyAds/Banners/FULL_BANNER"
				},
				{
					AdSize.Leaderboard,
					"DummyAds/Banners/LEADERBOARD"
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407CC0]");
			dictionary.Add(new AdSize(0, 0, AdSize.Type.Standard), "DummyAds/Banners/LARGE_BANNER");
			prefabAds = dictionary;
			base._002Ector();
		}
	}
}
