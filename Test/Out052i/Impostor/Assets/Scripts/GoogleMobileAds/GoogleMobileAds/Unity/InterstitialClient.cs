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
	[Token(Token = "0x200000D")]
	public class InterstitialClient : BaseAdDummyClient, IInterstitialClient
	{
		[CompilerGenerated]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		[CompilerGenerated]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x50")]
		private Dictionary<AdSize, string> prefabAds;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x58")]
		private ButtonBehaviour buttonBehaviour;

		[Token(Token = "0x14000009")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x1340950", Offset = "0x1340950", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36755]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600004A")]
			[Address(RVA = "0x1340A00", Offset = "0x1340A00", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36756]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400000A")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x600004B")]
			[Address(RVA = "0x1340AB0", Offset = "0x1340AB0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36757]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600004C")]
			[Address(RVA = "0x1340B60", Offset = "0x1340B60", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36758]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400000B")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x600004D")]
			[Address(RVA = "0x1340C10", Offset = "0x1340C10", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36759]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x600004E")]
			[Address(RVA = "0x1340CC0", Offset = "0x1340CC0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3675A]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400000C")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x600004F")]
			[Address(RVA = "0x1340D70", Offset = "0x1340D70", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3675B]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x1340E20", Offset = "0x1340E20", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3675C]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400000D")]
		public event EventHandler<EventArgs> OnAdLeavingApplication
		{
			[CompilerGenerated]
			[Token(Token = "0x6000051")]
			[Address(RVA = "0x1340ED0", Offset = "0x1340ED0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3675D]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x1340F80", Offset = "0x1340F80", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3675E]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x1400000E")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x1341030", Offset = "0x1341030", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3675F]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x13410E0", Offset = "0x13410E0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36760]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x1341190", Offset = "0x1341190", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, dummyAd, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, dummyAd, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv132 = Il2CppMethodInfo;\n\tv133 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, dummyAd, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv157 = Il2CppMethodInfo;\n\tv158 = \"il2cpp_codegen_initialize_runtime_metadata\"(v157, dummyAd, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv162 = Il2CppMethodInfo;\n\tv163 = \"il2cpp_codegen_initialize_runtime_metadata\"(v162, dummyAd, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv197 = UnityEngine.Events.UnityAction;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v197, dummyAd, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A36761]) = v43;\nL_002A:\n\tv52 = UnityEngine.GameObject::GetComponentsInChildren(dummyAd);\n\tv108 = UnityEngine.Component::GetComponentInChildren(v52[1]);\n\tv109 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v109, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v108.m_OnClick, v109);\n\tv110 = UnityEngine.Component::GetComponentsInChildren(v52[1]);\n\tv126 = v110[1];\n\tv111 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v111, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v126.m_OnClick, v111);\n\treturn;\n\tv130 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddClickBehavior(GameObject dummyAd)
		{
			Image[] componentsInChildren = dummyAd.GetComponentsInChildren<Image>();
			Button componentInChildren = componentsInChildren[1].GetComponentInChildren<Button>();
			UnityAction call = delegate
			{
				buttonBehaviour.OpenURL();
			};
			componentInChildren.onClick.AddListener(call);
			Button[] componentsInChildren2 = componentsInChildren[1].GetComponentsInChildren<Button>();
			Button button = componentsInChildren2[1];
			UnityAction call2 = delegate
			{
				DestroyInterstitial();
				if (this.OnAdClosed != null)
				{
					EventArgs e = new EventArgs();
					this.OnAdClosed(this, e);
				}
				((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).ResumeGame();
			};
			button.onClick.AddListener(call2);
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x1341310", Offset = "0x1341310", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = UnityEngine.GameObject;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36762]) = v38;\nL_0017:\n\tv40 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v40);\n\tv50 = UnityEngine.GameObject::AddComponent(v40);\n\tthis.buttonBehaviour = v50;\n\tButtonBehaviour::add_OnLeavingApplication(v50, this.OnAdLeavingApplication);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreateButtonBehavior()
		{
			GameObject gameObject = new GameObject();
			(buttonBehaviour = gameObject.AddComponent<ButtonBehaviour>()).OnLeavingApplication += this.OnAdLeavingApplication;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x1341398", Offset = "0x1341398", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void CreateInterstitialAd(string adUnitId)
		{
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x134139C", Offset = "0x134139C", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv22 = GoogleMobileAds.Api.AdFailedToLoadEventArgs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = GoogleMobileAds.Api.AdSize;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = System.EventArgs;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv65 = UnityEngine.Object;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv80 = \"Prefab Ad is Null\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A36763]) = v42;\nL_0025:\n\tv44 = UnityEngine.Screen::get_width();\n\tv50 = UnityEngine.Screen::get_height();\n\tv58 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v58);\n\t*([v58 @ X0_v7 (System.Object)+10]) = 0;\n\tv78 = v44 <= v50;\n\tif (v78) goto L_FFFFFFFF;\n\tgoto L_0046;\nL_0046:\n\t*([v58 @ X0_v7 (System.Object)+1C]) = v88;\n\t*([v58 @ X0_v7 (System.Object)+14]) = v87;\n\tv89 = this.prefabAds == 0;\n\tif (v89) goto L_009A;\n\tv97 = System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::get_Item(this.prefabAds, v58);\n\tGoogleMobileAds.Unity.BaseAdDummyClient::LoadAndSetPrefabAd(this, v97);\n\tgoto L_005F;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v95, v26, v27, v28, v29, v30, v87, v32, v33, v34, v35, v36, v37, v38);\nL_005F:\n\tv140 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\tv159 = v140 == 0;\n\tif (v159) goto L_0076;\n\tv160 = this.OnAdLoaded;\n\tv161 = this.OnAdLoaded == 0;\n\tif (v161) goto L_0099;\n\tgoto L_0070;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v165, v101, v99, v26, v27, v28, v29, v30, v87, v32, v33, v34, v35, v36, v37, v38);\n\tv175 = System.EventArgs;\nL_0070:\n\tv127 = v160.invoke_impl;\n\tv139 = v160.method_code;\n\tv125 = v160.method;\n\tgoto L_0091;\nL_0076:\n\tv110 = this.OnAdFailedToLoad;\n\tv162 = this.OnAdFailedToLoad == 0;\n\tif (v162) goto L_0099;\n\tv104 = new GoogleMobileAds.Api.AdFailedToLoadEventArgs();\n\tGoogleMobileAds.Api.AdFailedToLoadEventArgs::.ctor(v104);\n\tv106 = v104 == 0;\n\tif (v106) goto L_009A;\n\tv104.<Message>k__BackingField = \"Prefab Ad is Null\";\n\tv127 = v110.invoke_impl;\n\tv139 = v110.method_code;\n\tv125 = v110.method;\nL_0091:\n\t// 145 IndirectJump v127 @ X4_v1 (System.IntPtr), v139 @ X0_v17 (System.IntPtr), v139 @ X0_v17 (System.IntPtr), v131 @ X1_v6 (GoogleMobileAds.Unity.InterstitialClient), v129 @ X2_v4 (GoogleMobileAds.Api.AdFailedToLoadEventArgs), v125 @ X3_v1 (System.IntPtr), v127 @ X4_v1 (System.IntPtr), v28 @ X5, v29 @ X6, v30 @ X7, v87 @ V0_v1 (System.Double), v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0099:\n\treturn;\nL_009A:\n\tthrow v58;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			int width = Screen.width;
			int height = Screen.height;
			object obj = null;
			_ = 0;
			if (width > height)
			{
				double num = 2.1729236899484E-311;
				int num2 = 768;
			}
			else
			{
				double num = 1.6296927674613E-311;
				int num2 = 1024;
			}
			if (prefabAds != null)
			{
				string prefabName = prefabAds[(AdSize)obj];
				LoadAndSetPrefabAd(prefabName);
				if (prefabAd != null)
				{
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
						goto IL_0172;
					}
					e.Message = "Prefab Ad is Null";
					IntPtr invoke_impl = eventHandler2.invoke_impl;
					IntPtr method_code = eventHandler2.method_code;
					IntPtr method = eventHandler2.method;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X4_v1 (System.IntPtr) (should have been resolved before IL gen)");
				return;
			}
			goto IL_0172;
			IL_0172:
			throw obj;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x1341578", Offset = "0x1341578", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36764]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\treturnVal1 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsLoaded()
		{
			return prefabAd != null;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x13415D8", Offset = "0x13415D8", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv16 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = UnityEngine.Debug;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv45 = System.EventArgs;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv62 = \"No Ad Loaded\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A36765]) = v36;\nL_001B:\n\tv38 = GoogleMobileAds.Unity.InterstitialClient::IsLoaded(this);\n\tv43 = v38 == 0;\n\tif (v43) goto L_005E;\n\tgoto L_0030;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv65 = GoogleMobileAds.Unity.BaseAdDummyClient;\nL_0030:\n\t// 48 MakeStruct v81 @ AGG134566C_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, 1f\n\tv82 = DummyAdBehaviour::ShowAd(GoogleMobileAds.Unity.BaseAdDummyClient, this.prefabAd, v81);\n\tthis.dummyAd = v82;\n\tGoogleMobileAds.Unity.InterstitialClient::CreateButtonBehavior(this);\n\tGoogleMobileAds.Unity.InterstitialClient::AddClickBehavior(this, this.dummyAd);\n\tDummyAdBehaviour::PauseGame(this);\n\tv120 = this.OnAdOpening == 0;\n\tif (v120) goto L_006E;\n\tgoto L_0055;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v134, v89, v19, v20, v21, v22, v23, v24, v78, v79, v80, v28, v29, v30, v31, v32);\n\tv139 = System.EventArgs;\nL_0055:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdOpening, this, v125.Empty);\nL_005E:\n\tgoto L_0067;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0067:\n\tUnityEngine.Debug::Log(\"No Ad Loaded\");\n\treturn;\nL_006E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowInterstitial()
		{
			if (IsLoaded())
			{
				Vector3 position = default(Vector3);
				position.x = 0f;
				position.y = 0f;
				position.z = 1f;
				GameObject gameObject = ((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).ShowAd(prefabAd, position);
				dummyAd = gameObject;
				CreateButtonBehavior();
				AddClickBehavior(dummyAd);
				((DummyAdBehaviour)(object)this).PauseGame();
				if (this.OnAdOpening != null)
				{
					this.OnAdOpening(this, EventArgs.Empty);
				}
			}
			else
			{
				Debug.Log("No Ad Loaded");
			}
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x1341728", Offset = "0x1341728", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36766]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = GoogleMobileAds.Unity.BaseAdDummyClient;\nL_001F:\n\tDummyAdBehaviour::DestroyAd(GoogleMobileAds.Unity.BaseAdDummyClient, this.dummyAd);\n\tthis.prefabAd = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyInterstitial()
		{
			((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).DestroyAd(dummyAd);
			prefabAd = null;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x133D4B4", Offset = "0x133D4B4", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv30 = GoogleMobileAds.Api.AdSize;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv69 = System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv75 = \"DummyAds/Interstitials/1024x768\";\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv91 = \"DummyAds/Interstitials/768x1024\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A36767]) = v50;\nL_002E:\n\tv52 = new System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::.ctor(v52);\n\tv62 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v62);\n\tv62.type = *([407B40]);\n\tv73 = v52 == 0;\n\tif (v73) goto L_006A;\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v52, v62, \"DummyAds/Interstitials/768x1024\");\n\tv93 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v93);\n\tv93.type = *([407C30]);\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v52, v93, \"DummyAds/Interstitials/1024x768\");\n\tthis.prefabAds = v52;\n\tgoto L_0068;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v129, v128, v101, v99, v35, v36, v37, v38, v107, v40, v41, v42, v43, v44, v45, v46);\nL_0068:\n\tSystem.Object::.ctor(this);\n\treturn;\nL_006A:\n\tthrow v62;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InterstitialClient()
		{
			Dictionary<AdSize, string> dictionary = new Dictionary<AdSize, string>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B40]");
			AdSize adSize = new AdSize(0, 0, AdSize.Type.Standard);
			((BaseAdDummyClient)(object)adSize)._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B40]");
			adSize.type = AdSize.Type.Standard;
			if (dictionary != null)
			{
				dictionary.Add(adSize, "DummyAds/Interstitials/768x1024");
				AdSize adSize2 = null;
				((BaseAdDummyClient)(object)adSize2)._002Ector();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407C30]");
				adSize2.type = AdSize.Type.Standard;
				dictionary.Add(adSize2, "DummyAds/Interstitials/1024x768");
				prefabAds = dictionary;
				base._002Ector();
				return;
			}
			throw adSize;
		}
	}
}
