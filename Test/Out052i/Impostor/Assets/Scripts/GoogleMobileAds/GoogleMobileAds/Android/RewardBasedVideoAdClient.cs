using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x200001C")]
	public class RewardBasedVideoAdClient : AndroidJavaProxy, IRewardBasedVideoAdClient
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200001D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000054")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000055")]
			public static EventHandler<EventArgs> _003C_003E9__25_0;

			[Token(Token = "0x4000056")]
			public static EventHandler<AdFailedToLoadEventArgs> _003C_003E9__25_1;

			[Token(Token = "0x4000057")]
			public static EventHandler<EventArgs> _003C_003E9__25_2;

			[Token(Token = "0x4000058")]
			public static EventHandler<EventArgs> _003C_003E9__25_3;

			[Token(Token = "0x4000059")]
			public static EventHandler<EventArgs> _003C_003E9__25_4;

			[Token(Token = "0x400005A")]
			public static EventHandler<Reward> _003C_003E9__25_5;

			[Token(Token = "0x400005B")]
			public static EventHandler<EventArgs> _003C_003E9__25_6;

			[Token(Token = "0x400005C")]
			public static EventHandler<EventArgs> _003C_003E9__25_7;

			[Token(Token = "0x6000115")]
			[Address(RVA = "0x134CCF4", Offset = "0x134CCF4", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3680D]) = v34;\nL_0012:\n\tv36 = new GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000116")]
			[Address(RVA = "0x134CD50", Offset = "0x134CD50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003C_002Ector_003Eb__25_0(object _003Cp0_003E, EventArgs _003Cp1_003E)
			{
			}

			internal void _003C_002Ector_003Eb__25_1(object _003Cp0_003E, AdFailedToLoadEventArgs _003Cp1_003E)
			{
			}

			internal void _003C_002Ector_003Eb__25_2(object _003Cp0_003E, EventArgs _003Cp1_003E)
			{
			}

			internal void _003C_002Ector_003Eb__25_3(object _003Cp0_003E, EventArgs _003Cp1_003E)
			{
			}

			internal void _003C_002Ector_003Eb__25_4(object _003Cp0_003E, EventArgs _003Cp1_003E)
			{
			}

			internal void _003C_002Ector_003Eb__25_5(object _003Cp0_003E, Reward _003Cp1_003E)
			{
			}

			internal void _003C_002Ector_003Eb__25_6(object _003Cp0_003E, EventArgs _003Cp1_003E)
			{
			}

			internal void _003C_002Ector_003Eb__25_7(object _003Cp0_003E, EventArgs _003Cp1_003E)
			{
			}
		}

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x20")]
		private AndroidJavaObject androidRewardBasedVideo;

		[CompilerGenerated]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<EventArgs> m_OnAdStarted;

		[CompilerGenerated]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x50")]
		private EventHandler<Reward> m_OnAdRewarded;

		[CompilerGenerated]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x58")]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		[CompilerGenerated]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x60")]
		private EventHandler<EventArgs> m_OnAdCompleted;

		[Token(Token = "0x14000029")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F5")]
			[Address(RVA = "0x134B828", Offset = "0x134B828", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367ED]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x60000F6")]
			[Address(RVA = "0x134B8D8", Offset = "0x134B8D8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367EE]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400002A")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F7")]
			[Address(RVA = "0x134B988", Offset = "0x134B988", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367EF]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x60000F8")]
			[Address(RVA = "0x134BA38", Offset = "0x134BA38", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F0]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400002B")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0x134BAE8", Offset = "0x134BAE8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F1]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x134BB98", Offset = "0x134BB98", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F2]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400002C")]
		public event EventHandler<EventArgs> OnAdStarted
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FB")]
			[Address(RVA = "0x134BC48", Offset = "0x134BC48", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F3]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnAdStarted;
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
			[Token(Token = "0x60000FC")]
			[Address(RVA = "0x134BCF8", Offset = "0x134BCF8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F4]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnAdStarted;
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

		[Token(Token = "0x1400002D")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0x134BDA8", Offset = "0x134BDA8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F5]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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
			[Token(Token = "0x60000FE")]
			[Address(RVA = "0x134BE58", Offset = "0x134BE58", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F6]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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

		[Token(Token = "0x1400002E")]
		public event EventHandler<Reward> OnAdRewarded
		{
			[CompilerGenerated]
			[Token(Token = "0x60000FF")]
			[Address(RVA = "0x134BF08", Offset = "0x134BF08", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F7]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_OnAdRewarded;
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
			[Token(Token = "0x6000100")]
			[Address(RVA = "0x134BFB8", Offset = "0x134BFB8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F8]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_OnAdRewarded;
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

		[Token(Token = "0x1400002F")]
		public event EventHandler<EventArgs> OnAdLeavingApplication
		{
			[CompilerGenerated]
			[Token(Token = "0x6000101")]
			[Address(RVA = "0x134C068", Offset = "0x134C068", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367F9]) = v42;\nL_0016:\n\tv44 = this + 0x58;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 88;
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
			[Token(Token = "0x6000102")]
			[Address(RVA = "0x134C118", Offset = "0x134C118", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367FA]) = v42;\nL_0016:\n\tv44 = this + 0x58;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 88;
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

		[Token(Token = "0x14000030")]
		public event EventHandler<EventArgs> OnAdCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x6000103")]
			[Address(RVA = "0x134C1C8", Offset = "0x134C1C8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367FB]) = v42;\nL_0016:\n\tv44 = this + 0x60;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 96;
				Delegate obj2 = this.m_OnAdCompleted;
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
			[Token(Token = "0x6000104")]
			[Address(RVA = "0x134C278", Offset = "0x134C278", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A367FC]) = v42;\nL_0016:\n\tv44 = this + 0x60;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 96;
				Delegate obj2 = this.m_OnAdCompleted;
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

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x133D6C8", Offset = "0x133D6C8", Length = "0x5EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0055;\n\tv22 = UnityEngine.AndroidJavaClass;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = UnityEngine.AndroidJavaObject;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv83 = UnityEngine.AndroidJavaProxy;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv126 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv186 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv187 = \"il2cpp_codegen_initialize_runtime_metadata\"(v186, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv238 = System.EventHandler`1<System.EventArgs>;\n\tv239 = \"il2cpp_codegen_initialize_runtime_metadata\"(v238, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv257 = System.Object[];\n\tv258 = \"il2cpp_codegen_initialize_runtime_metadata\"(v257, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv285 = Il2CppMethodInfo;\n\tv286 = \"il2cpp_codegen_initialize_runtime_metadata\"(v285, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv335 = Il2CppMethodInfo;\n\tv336 = \"il2cpp_codegen_initialize_runtime_metadata\"(v335, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv363 = Il2CppMethodInfo;\n\tv364 = \"il2cpp_codegen_initialize_runtime_metadata\"(v363, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv380 = Il2CppMethodInfo;\n\tv381 = \"il2cpp_codegen_initialize_runtime_metadata\"(v380, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv408 = Il2CppMethodInfo;\n\tv409 = \"il2cpp_codegen_initialize_runtime_metadata\"(v408, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv425 = Il2CppMethodInfo;\n\tv426 = \"il2cpp_codegen_initialize_runtime_metadata\"(v425, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv453 = Il2CppMethodInfo;\n\tv454 = \"il2cpp_codegen_initialize_runtime_metadata\"(v453, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv470 = Il2CppMethodInfo;\n\tv471 = \"il2cpp_codegen_initialize_runtime_metadata\"(v470, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv498 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\n\tv499 = \"il2cpp_codegen_initialize_runtime_metadata\"(v498, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv516 = \"com.google.unity.ads.UnityRewardBasedVideoAdListener\";\n\tv517 = \"il2cpp_codegen_initialize_runtime_metadata\"(v516, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv546 = \"com.unity3d.player.UnityPlayer\";\n\tv547 = \"il2cpp_codegen_initialize_runtime_metadata\"(v546, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv560 = \"com.google.unity.ads.RewardBasedVideo\";\n\tv561 = \"il2cpp_codegen_initialize_runtime_metadata\"(v560, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv566 = \"currentActivity\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v566, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A367FD]) = v42;\nL_0055:\n\tgoto L_0059;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_0059:\n\tv79 = v53.<>9__25_0;\n\tv55 = v53.<>9__25_0 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0075;\n\tgoto L_0068;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv87 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_0068:\n\tv91 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v91, v89.<>9, Il2CppMethodInfo);\n\tv78.<>9__25_0 = v91;\nL_0075:\n\tthis.OnAdLoaded = v79;\n\tgoto L_007D;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v74, v72, v68, v70, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_007D:\n\tv206 = v133.<>9__25_1;\n\tv135 = v133.<>9__25_1 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_0097;\n\tgoto L_008C;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v131, v72, v68, v70, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv242 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_008C:\n\tv246 = new System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>::.ctor(v246, v244.<>9, Il2CppMethodInfo);\n\tv205.<>9__25_1 = v246;\nL_0097:\n\tthis.OnAdFailedToLoad = v206;\n\tgoto L_009F;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v201, v199, v195, v197, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv249 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_009F:\n\tv279 = v250.<>9__25_2;\n\tv252 = v250.<>9__25_2 == 0;\n\tv253 = ~v252;\n\tif (v253) goto L_00B9;\n\tgoto L_00AE;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v248, v199, v195, v197, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv289 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_00AE:\n\tv293 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v293, v291.<>9, Il2CppMethodInfo);\n\tv278.<>9__25_2 = v293;\nL_00B9:\n\tthis.OnAdOpening = v279;\n\tgoto L_00C1;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v274, v272, v268, v270, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv296 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_00C1:\n\tv357 = v297.<>9__25_3;\n\tv299 = v297.<>9__25_3 == 0;\n\tv300 = ~v299;\n\tif (v300) goto L_00DB;\n\tgoto L_00D0;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v295, v272, v268, v270, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv367 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_00D0:\n\tv371 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v371, v369.<>9, Il2CppMethodInfo);\n\tv356.<>9__25_3 = v371;\nL_00DB:\n\tthis.OnAdStarted = v357;\n\tgoto L_00E3;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v352, v350, v346, v348, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv374 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_00E3:\n\tv402 = v375.<>9__25_4;\n\tv377 = v375.<>9__25_4 == 0;\n\tv378 = ~v377;\n\tif (v378) goto L_00FD;\n\tgoto L_00F2;\n\tv410 = \"il2cpp_codegen_runtime_class_init\"(v373, v350, v346, v348, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv412 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_00F2:\n\tv416 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v416, v414.<>9, Il2CppMethodInfo);\n\tv401.<>9__25_4 = v416;\nL_00FD:\n\tthis.OnAdClosed = v402;\n\tgoto L_0105;\n\tv417 = \"il2cpp_codegen_runtime_class_init\"(v397, v395, v391, v393, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv419 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_0105:\n\tv447 = v420.<>9__25_5;\n\tv422 = v420.<>9__25_5 == 0;\n\tv423 = ~v422;\n\tif (v423) goto L_011F;\n\tgoto L_0114;\n\tv455 = \"il2cpp_codegen_runtime_class_init\"(v418, v395, v391, v393, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv457 = GoogleMobileAds.Android.RewardBasedVideoAdClient+<>c;\nL_0114:\n\tv461 = new System.EventHandler`1<GoogleMobileAds.Api.Reward>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.Reward>::.ctor(v461, v459.<>9, Il2CppMethodInfo);\n\tv44\n// ... truncated")]
		public RewardBasedVideoAdClient()
		{
			EventHandler<EventArgs> eventHandler = _003C_003Ec._003C_003E9__25_0;
			if (_003C_003Ec._003C_003E9__25_0 == null)
			{
				eventHandler = (_003C_003Ec._003C_003E9__25_0 = delegate
				{
				});
			}
			this.OnAdLoaded = eventHandler;
			EventHandler<AdFailedToLoadEventArgs> eventHandler2 = _003C_003Ec._003C_003E9__25_1;
			if (_003C_003Ec._003C_003E9__25_1 == null)
			{
				eventHandler2 = (_003C_003Ec._003C_003E9__25_1 = delegate
				{
				});
			}
			this.OnAdFailedToLoad = eventHandler2;
			EventHandler<EventArgs> onAdOpening = _003C_003Ec._003C_003E9__25_2;
			if (_003C_003Ec._003C_003E9__25_2 == null)
			{
				onAdOpening = (_003C_003Ec._003C_003E9__25_2 = delegate
				{
				});
			}
			this.OnAdOpening = onAdOpening;
			EventHandler<EventArgs> eventHandler3 = _003C_003Ec._003C_003E9__25_3;
			if (_003C_003Ec._003C_003E9__25_3 == null)
			{
				eventHandler3 = (_003C_003Ec._003C_003E9__25_3 = delegate
				{
				});
			}
			this.OnAdStarted = eventHandler3;
			EventHandler<EventArgs> eventHandler4 = _003C_003Ec._003C_003E9__25_4;
			if (_003C_003Ec._003C_003E9__25_4 == null)
			{
				eventHandler4 = (_003C_003Ec._003C_003E9__25_4 = delegate
				{
				});
			}
			this.OnAdClosed = eventHandler4;
			EventHandler<Reward> eventHandler5 = _003C_003Ec._003C_003E9__25_5;
			if (_003C_003Ec._003C_003E9__25_5 == null)
			{
				eventHandler5 = (_003C_003Ec._003C_003E9__25_5 = delegate
				{
				});
			}
			this.OnAdRewarded = eventHandler5;
			EventHandler<EventArgs> onAdLeavingApplication = _003C_003Ec._003C_003E9__25_6;
			if (_003C_003Ec._003C_003E9__25_6 == null)
			{
				onAdLeavingApplication = (_003C_003Ec._003C_003E9__25_6 = delegate
				{
				});
			}
			this.OnAdLeavingApplication = onAdLeavingApplication;
			EventHandler<EventArgs> eventHandler6 = _003C_003Ec._003C_003E9__25_7;
			if (_003C_003Ec._003C_003E9__25_7 == null)
			{
				eventHandler6 = (_003C_003Ec._003C_003E9__25_7 = delegate
				{
				});
			}
			this.OnAdCompleted = eventHandler6;
			base._002Ector("com.google.unity.ads.UnityRewardBasedVideoAdListener");
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			object obj = androidJavaClass.GetStatic<object>("currentActivity");
			object[] array = new object[2];
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					goto IL_0137;
				}
			}
			array[0] = obj;
			object obj3 = this as object;
			if (obj3 != null)
			{
				array[1] = this;
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.unity.ads.RewardBasedVideo", array);
				androidRewardBasedVideo = androidJavaObject;
				return;
			}
			goto IL_0137;
			IL_0137:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x134C328", Offset = "0x134C328", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"create\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A367FE]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardBasedVideo, \"create\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateRewardBasedVideoAd()
		{
			androidRewardBasedVideo.Call("create");
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x134C3E4", Offset = "0x134C3E4", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = System.Object[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, request, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = \"loadAd\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, request, adUnitId, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A367FF]) = v44;\nL_001D:\n\t// 29 NewArr v48 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv53 = GoogleMobileAds.Android.Utils::GetAdRequestJavaObject(request);\n\tv56 = v53 == 0;\n\tif (v56) goto L_002F;\n\t// 41 IsInst v110 @ X0_v19, typeof(System.Object), v53 @ X0_v5 (UnityEngine.AndroidJavaObject)\n\tv114 = v110 == 0;\n\tif (v114) goto L_0059;\nL_002F:\n\tv48[0] = v53;\n\tv137 = adUnitId == 0;\n\tif (v137) goto L_0045;\n\t// 53 IsInst v130 @ X0_v17, typeof(System.Object), adUnitId @ X2 (System.String)\n\tv132 = v130 == 0;\n\tif (v132) goto L_0059;\nL_0045:\n\tv48[1] = adUnitId;\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardBasedVideo, \"loadAd\", v48);\n\treturn;\n\tv97 = new System.IndexOutOfRangeException();\n\tv106 = new System.NullReferenceException();\nL_0059:\n\tv136 = new System.ArrayTypeMismatchException();\n\tthrow v136;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request, string adUnitId)
		{
			object[] array = new object[2];
			AndroidJavaObject adRequestJavaObject = Utils.GetAdRequestJavaObject(request);
			if (adRequestJavaObject != null)
			{
				object obj = adRequestJavaObject as object;
				if (obj == null)
				{
					goto IL_00d1;
				}
			}
			array[0] = adRequestJavaObject;
			if (adUnitId != null)
			{
				object obj2 = adUnitId as object;
				if (obj2 == null)
				{
					goto IL_00d1;
				}
			}
			array[1] = adUnitId;
			androidRewardBasedVideo.Call("loadAd", array);
			return;
			IL_00d1:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x134C4E0", Offset = "0x134C4E0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"isLoaded\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36800]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.androidRewardBasedVideo, \"isLoaded\", v77.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsLoaded()
		{
			return androidRewardBasedVideo.Call<bool>("isLoaded", Array.Empty<object>());
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x134C5B0", Offset = "0x134C5B0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"show\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36801]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardBasedVideo, \"show\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowRewardBasedVideoAd()
		{
			androidRewardBasedVideo.Call("show");
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x134C66C", Offset = "0x134C66C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Object[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, userId, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = \"setUserId\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, userId, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A36802]) = v41;\nL_001B:\n\t// 27 NewArr v45 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = userId == 0;\n\tif (v50) goto L_002A;\n\t// 36 IsInst v64 @ X0_v14, typeof(System.Object), userId @ X1 (System.String)\n\tv66 = v64 == 0;\n\tif (v66) goto L_003D;\nL_002A:\n\tv45[0] = userId;\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardBasedVideo, \"setUserId\", v45);\n\treturn;\n\tv60 = new System.NullReferenceException();\n\tv74 = new System.IndexOutOfRangeException();\nL_003D:\n\tv80 = new System.ArrayTypeMismatchException();\n\tthrow v80;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetUserId(string userId)
		{
			object[] array = new object[1];
			if (userId != null)
			{
				object obj = userId as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = userId;
			androidRewardBasedVideo.Call("setUserId", array);
		}

		[Token(Token = "0x600010B")]
		[Address(RVA = "0x134C730", Offset = "0x134C730", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = \"destroy\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36803]) = v38;\nL_001B:\n\tgoto L_0024;\n\tv47 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tgoto L_0029;\n\tv56 = 0xB348B0(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0031;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tgoto L_0041;\n\tv69 = 0xB348B0(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tUnityEngine.AndroidJavaObject::Call(this.androidRewardBasedVideo, \"destroy\", v73.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyRewardBasedVideoAd()
		{
			androidRewardBasedVideo.Call("destroy");
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0x134C7EC", Offset = "0x134C7EC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = \"getMediationAdapterClassName\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36804]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv48 = 0xB3490C(Il2CppMethodInfo, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0027:\n\tgoto L_002C;\n\tv59 = 0xB348B0(v52, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002C:\n\tgoto L_0034;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0034:\n\tgoto L_0046;\n\tv72 = 0xB348B0(v67, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0046:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.androidRewardBasedVideo, \"getMediationAdapterClassName\", v77.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
		{
			return (string)androidRewardBasedVideo.Call<object>("getMediationAdapterClassName", Array.Empty<object>());
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0x134C8BC", Offset = "0x134C8BC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A36805]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdLoaded == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdLoaded, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x134C93C", Offset = "0x134C93C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = GoogleMobileAds.Api.AdFailedToLoadEventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, errorReason, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A36806]) = v36;\nL_0013:\n\tv38 = this.OnAdFailedToLoad == 0;\n\tif (v38) goto L_0031;\n\tv42 = new GoogleMobileAds.Api.AdFailedToLoadEventArgs();\n\tGoogleMobileAds.Api.AdFailedToLoadEventArgs::.ctor(v42);\n\tv73 = v42 == 0;\n\tif (v73) goto L_0032;\n\tv42.<Message>k__BackingField = errorReason;\n\tv62 = this.OnAdFailedToLoad == 0;\n\tif (v62) goto L_0032;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>::Invoke(this.OnAdFailedToLoad, this, v42);\nL_0031:\n\treturn;\nL_0032:\n\tthrow v42;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdFailedToLoad(string errorReason)
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

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x134C9CC", Offset = "0x134C9CC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A36807]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdOpening == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdOpening, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x134CA4C", Offset = "0x134CA4C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A36808]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdStarted == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdStarted, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdStarted()
		{
			if (this.OnAdStarted != null)
			{
				this.OnAdStarted(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x134CACC", Offset = "0x134CACC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A36809]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdClosed == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdClosed, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x134CB4C", Offset = "0x134CB4C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = GoogleMobileAds.Api.Reward;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, type, methodInfo, v25, v26, v27, v28, v29, amount, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3680A]) = v39;\nL_0015:\n\tv41 = this.OnAdRewarded == 0;\n\tif (v41) goto L_0037;\n\tv45 = new GoogleMobileAds.Api.Reward();\n\tGoogleMobileAds.Api.Reward::.ctor(v45);\n\tv82 = v45 == 0;\n\tif (v82) goto L_0038;\n\tv45.<Type>k__BackingField = type;\n\tv45.<Amount>k__BackingField = amount;\n\tv69 = this.OnAdRewarded == 0;\n\tif (v69) goto L_0038;\n\tSystem.EventHandler`1<GoogleMobileAds.Api.Reward>::Invoke(this.OnAdRewarded, this, v45);\nL_0037:\n\treturn;\nL_0038:\n\tthrow v45;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdRewarded(string type, float amount)
		{
			if (this.OnAdRewarded == null)
			{
				return;
			}
			Reward reward = new Reward();
			if (reward != null)
			{
				reward.Type = type;
				reward.Amount = amount;
				if (this.OnAdRewarded != null)
				{
					this.OnAdRewarded(this, reward);
					return;
				}
			}
			throw reward;
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x134CBF4", Offset = "0x134CBF4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A3680B]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdLeavingApplication == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdLeavingApplication, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x134CC74", Offset = "0x134CC74", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.EventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A3680C]) = v35;\nL_0011:\n\t;\n\tv37 = this.OnAdCompleted == 0;\n\tif (v37) goto L_002E;\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = System.EventArgs;\nL_0028:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdCompleted, this, v51.Empty);\nL_002E:\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onAdCompleted()
		{
			if (this.OnAdCompleted != null)
			{
				this.OnAdCompleted(this, EventArgs.Empty);
			}
		}
	}
}
