using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GoogleMobileAds.Unity
{
	[Token(Token = "0x2000011")]
	public class RewardingAdBaseClient : BaseAdDummyClient
	{
		[CompilerGenerated]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[CompilerGenerated]
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<Reward> m_OnUserEarnedReward;

		[CompilerGenerated]
		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<AdErrorEventArgs> m_OnAdFailedToPresentFullScreenContent;

		[CompilerGenerated]
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<EventArgs> m_OnAdDidPresentFullScreenContent;

		[CompilerGenerated]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x50")]
		private EventHandler<EventArgs> m_OnAdDidDismissFullScreenContent;

		[Token(Token = "0x400002B")]
		internal static readonly Dictionary<AdSize, string> prefabAds;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x58")]
		internal ButtonBehaviour buttonBehaviour;

		[Token(Token = "0x14000013")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000070")]
			[Address(RVA = "0x13422F0", Offset = "0x13422F0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36775]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000071")]
			[Address(RVA = "0x13423A0", Offset = "0x13423A0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36776]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000014")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000072")]
			[Address(RVA = "0x1342450", Offset = "0x1342450", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36777]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x1342500", Offset = "0x1342500", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36778]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000015")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000074")]
			[Address(RVA = "0x13425B0", Offset = "0x13425B0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36779]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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
			[Token(Token = "0x6000075")]
			[Address(RVA = "0x1342660", Offset = "0x1342660", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3677A]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
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

		[Token(Token = "0x14000016")]
		public event EventHandler<Reward> OnUserEarnedReward
		{
			[CompilerGenerated]
			[Token(Token = "0x6000076")]
			[Address(RVA = "0x1342710", Offset = "0x1342710", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3677B]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			[Token(Token = "0x6000077")]
			[Address(RVA = "0x13427C0", Offset = "0x13427C0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3677C]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x14000017")]
		public event EventHandler<AdErrorEventArgs> OnAdFailedToPresentFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x6000078")]
			[Address(RVA = "0x13421DC", Offset = "0x13421DC", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3677D]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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
			[Token(Token = "0x6000079")]
			[Address(RVA = "0x1342870", Offset = "0x1342870", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3677E]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdErrorEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
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

		[Token(Token = "0x14000018")]
		public event EventHandler<EventArgs> OnAdDidPresentFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x134207C", Offset = "0x134207C", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3677F]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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
			[Token(Token = "0x600007B")]
			[Address(RVA = "0x1342920", Offset = "0x1342920", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36780]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
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

		[Token(Token = "0x14000019")]
		public event EventHandler<EventArgs> OnAdDidDismissFullScreenContent
		{
			[CompilerGenerated]
			[Token(Token = "0x600007C")]
			[Address(RVA = "0x134212C", Offset = "0x134212C", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36781]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
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
			[Token(Token = "0x600007D")]
			[Address(RVA = "0x13429D0", Offset = "0x13429D0", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36782]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
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

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x1342A80", Offset = "0x1342A80", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv54 = UnityEngine.Debug;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv144 = Il2CppMethodInfo;\n\tv145 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv170 = Il2CppMethodInfo;\n\tv171 = \"il2cpp_codegen_initialize_runtime_metadata\"(v170, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv173 = GoogleMobileAds.Unity.RewardingAdBaseClient+<>c__DisplayClass23_0;\n\tv174 = \"il2cpp_codegen_initialize_runtime_metadata\"(v173, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv221 = UnityEngine.Events.UnityAction;\n\tv222 = \"il2cpp_codegen_initialize_runtime_metadata\"(v221, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv224 = \"Invalid Prefab\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, dummyAd, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A36783]) = v45;\nL_0030:\n\tv47 = new GoogleMobileAds.Unity.RewardingAdBaseClient+<>c__DisplayClass23_0();\n\tSystem.Object::.ctor(v47);\n\tv47.<>4__this = this;\n\tv47.dummyAd = dummyAd;\n\tv115 = UnityEngine.GameObject::GetComponentsInChildren(dummyAd);\n\tv116 = UnityEngine.Component::GetComponentInChildren(v115[1]);\n\tv117 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v117, v47, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v116.m_OnClick, v117);\n\tv118 = UnityEngine.Component::GetComponentsInChildren(v115[1]);\n\tv75 = v118.Length <= 1;\n\tif (v75) goto L_00A1;\n\tv138 = v118[1];\n\tv119 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v119, v47, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v138.m_OnClick, v119);\n\treturn;\nL_00A1:\n\tgoto L_00AF;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v241, v112, v68, v64, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00AF:\n\tUnityEngine.Debug::Log(\"Invalid Prefab\");\n\treturn;\n\tv142 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void AddClickBehavior(GameObject dummyAd)
		{
			GameObject dummyAd2 = dummyAd;
			Image[] componentsInChildren = dummyAd.GetComponentsInChildren<Image>();
			Button componentInChildren = componentsInChildren[1].GetComponentInChildren<Button>();
			UnityAction call = delegate
			{
				RewardingAdBaseClient rewardingAdBaseClient = this;
				rewardingAdBaseClient.buttonBehaviour.OpenURL();
			};
			componentInChildren.onClick.AddListener(call);
			Button[] componentsInChildren2 = componentsInChildren[1].GetComponentsInChildren<Button>();
			if (componentsInChildren2.Length > 1)
			{
				Button button = componentsInChildren2[1];
				UnityAction call2 = delegate
				{
					((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).DestroyAd(dummyAd2);
					RewardingAdBaseClient rewardingAdBaseClient = this;
					rewardingAdBaseClient.prefabAd = null;
					if (rewardingAdBaseClient.OnAdDidDismissFullScreenContent != null)
					{
						rewardingAdBaseClient.OnAdDidDismissFullScreenContent(rewardingAdBaseClient, EventArgs.Empty);
					}
					((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).ResumeGame();
					RewardingAdBaseClient rewardingAdBaseClient2 = this;
					if (rewardingAdBaseClient2.OnUserEarnedReward != null)
					{
						Reward rewardItem = ((RewardingAdBaseClient)(object)typeof(BaseAdDummyClient)).GetRewardItem();
						rewardingAdBaseClient2.OnUserEarnedReward(rewardingAdBaseClient2, rewardItem);
					}
				};
				button.onClick.AddListener(call2);
			}
			else
			{
				Debug.Log("Invalid Prefab");
			}
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x1342C8C", Offset = "0x1342C8C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = UnityEngine.GameObject;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36784]) = v38;\nL_0017:\n\tv40 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v40);\n\tv50 = UnityEngine.GameObject::AddComponent(v40);\n\tthis.buttonBehaviour = v50;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void CreateButtonBehavior()
		{
			GameObject gameObject = new GameObject();
			ButtonBehaviour buttonBehaviour = gameObject.AddComponent<ButtonBehaviour>();
			this.buttonBehaviour = buttonBehaviour;
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x1341E74", Offset = "0x1341E74", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv22 = GoogleMobileAds.Api.AdFailedToLoadEventArgs;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = GoogleMobileAds.Api.AdSize;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv62 = System.EventArgs;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv74 = UnityEngine.Object;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv79 = GoogleMobileAds.Unity.RewardingAdBaseClient;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv94 = \"Prefab Ad is Null\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A36785]) = v42;\nL_002A:\n\tv46 = UnityEngine.Screen::get_width();\n\tv52 = UnityEngine.Screen::get_height();\n\tgoto L_003A;\n\tv64 = v56;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v64, request, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv68 = GoogleMobileAds.Unity.RewardingAdBaseClient;\nL_003A:\n\tv72 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v72);\n\tv72.type = 0;\n\tv92 = v46 <= v52;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_0053;\nL_0053:\n\tv72.height = v102;\n\tv72.orientation = v101;\n\tv111 = System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::get_Item(v69.prefabAds, v72);\n\tGoogleMobileAds.Unity.BaseAdDummyClient::LoadAndSetPrefabAd(this, v111);\n\tgoto L_006C;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v129, v127, v109, v26, v27, v28, v29, v30, v101, v32, v33, v34, v35, v36, v37, v38);\nL_006C:\n\tv153 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\tv172 = v153 == 0;\n\tif (v172) goto L_0083;\n\tv173 = this.OnAdLoaded;\n\tv174 = this.OnAdLoaded == 0;\n\tif (v174) goto L_00A6;\n\tgoto L_007D;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v178, v115, v113, v26, v27, v28, v29, v30, v101, v32, v33, v34, v35, v36, v37, v38);\n\tv188 = System.EventArgs;\nL_007D:\n\tv140 = v173.invoke_impl;\n\tv152 = v173.method_code;\n\tv138 = v173.method;\n\tgoto L_009E;\nL_0083:\n\tv123 = this.OnAdFailedToLoad;\n\tv175 = this.OnAdFailedToLoad == 0;\n\tif (v175) goto L_00A6;\n\tv117 = new GoogleMobileAds.Api.AdFailedToLoadEventArgs();\n\tGoogleMobileAds.Api.AdFailedToLoadEventArgs::.ctor(v117);\n\tv117.<Message>k__BackingField = \"Prefab Ad is Null\";\n\tv140 = v123.invoke_impl;\n\tv152 = v123.method_code;\n\tv138 = v123.method;\nL_009E:\n\t// 158 IndirectJump v140 @ X4_v1 (System.IntPtr), v152 @ X0_v18 (System.IntPtr), v152 @ X0_v18 (System.IntPtr), v147 @ X1_v6 (GoogleMobileAds.Unity.RewardingAdBaseClient), v142 @ X2_v4 (GoogleMobileAds.Api.AdFailedToLoadEventArgs), v138 @ X3_v1 (System.IntPtr), v140 @ X4_v1 (System.IntPtr), v28 @ X5, v29 @ X6, v30 @ X7, v101 @ V0_v1 (System.Double), v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_00A6:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LoadAd(AdRequest request)
		{
			//IL_019a: Expected I4, but got F8
			int width = Screen.width;
			int height = Screen.height;
			AdSize adSize = new AdSize(0, 0, default(AdSize.Type));
			double num;
			int height2;
			if (width > height)
			{
				num = 2.1729236899484E-311;
				height2 = 768;
			}
			else
			{
				num = 1.6296927674613E-311;
				height2 = 1024;
			}
			adSize.height = height2;
			adSize.orientation = (Orientation)num;
			string prefabName = prefabAds[adSize];
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
				e.Message = "Prefab Ad is Null";
				IntPtr invoke_impl = eventHandler2.invoke_impl;
				IntPtr method_code = eventHandler2.method_code;
				IntPtr method = eventHandler2.method;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v140 @ X4_v1 (System.IntPtr) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x1342D0C", Offset = "0x1342D0C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36786]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\treturnVal1 = UnityEngine.Object::op_Inequality(this.prefabAd, 0);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsLoaded()
		{
			return prefabAd != null;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x1342D6C", Offset = "0x1342D6C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = GoogleMobileAds.Api.Reward;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = \"Reward\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36787]) = v35;\nL_0015:\n\tv37 = new GoogleMobileAds.Api.Reward();\n\tGoogleMobileAds.Api.Reward::.ctor(v37);\n\tv37.<Type>k__BackingField = \"Reward\";\n\tv37.<Amount>k__BackingField = 10d;\n\treturn v37;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Reward GetRewardItem()
		{
			Reward reward = new Reward();
			reward.Type = "Reward";
			reward.Amount = 10.0;
			return reward;
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x1342E3C", Offset = "0x1342E3C", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv16 = GoogleMobileAds.Api.AdErrorEventArgs;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv40 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv45 = System.EventArgs;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv93 = \"No Ad Loaded\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A36788]) = v36;\nL_001E:\n\tv38 = GoogleMobileAds.Unity.RewardingAdBaseClient::IsLoaded(this);\n\tv43 = v38 == 0;\n\tif (v43) goto L_005B;\n\tgoto L_0033;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv60 = GoogleMobileAds.Unity.BaseAdDummyClient;\nL_0033:\n\t// 51 MakeStruct v70 @ AGG1346EDC_2_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, 1f\n\tv95 = DummyAdBehaviour::ShowAd(GoogleMobileAds.Unity.BaseAdDummyClient, this.prefabAd, v70);\n\tthis.dummyAd = v95;\n\tDummyAdBehaviour::PauseGame(v95);\n\tGoogleMobileAds.Unity.RewardingAdBaseClient::CreateButtonBehavior(this);\n\tGoogleMobileAds.Unity.RewardingAdBaseClient::AddClickBehavior(this, this.dummyAd);\n\tv81 = UnityEngine.GameObject::AddComponent(this.dummyAd);\n\tv87 = this.OnAdDidPresentFullScreenContent;\n\tv83 = this.OnAdDidPresentFullScreenContent == 0;\n\tif (v83) goto L_007A;\n\tgoto L_0055;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v168, v79, v19, v20, v21, v22, v23, v24, v77, v75, v73, v28, v29, v30, v31, v32);\n\tv173 = System.EventArgs;\nL_0055:\n\tv119 = v87.invoke_impl;\n\tv135 = v87.method_code;\n\tv117 = v87.method;\n\tgoto L_0074;\nL_005B:\n\tv53 = this.OnAdFailedToPresentFullScreenContent;\n\tv54 = this.OnAdFailedToPresentFullScreenContent == 0;\n\tif (v54) goto L_007A;\n\tv67 = new GoogleMobileAds.Api.AdErrorEventArgs();\n\tGoogleMobileAds.Api.AdErrorEventArgs::.ctor(v67);\n\tv67.<Message>k__BackingField = \"No Ad Loaded\";\n\tv119 = v53.invoke_impl;\n\tv135 = v53.method_code;\n\tv117 = v53.method;\nL_0074:\n\t// 116 IndirectJump v119 @ X4_v1 (System.IntPtr), v135 @ X0_v4 (System.IntPtr), v135 @ X0_v4 (System.IntPtr), v133 @ X1_v1 (GoogleMobileAds.Unity.RewardingAdBaseClient), v121 @ X2_v1 (GoogleMobileAds.Api.AdErrorEventArgs), v117 @ X3_v1 (System.IntPtr), v119 @ X4_v1 (System.IntPtr), v22 @ X5, v23 @ X6, v24 @ X7, v131 @ V0_v1, v129 @ V1_v1, v127 @ V2_v1 (System.Single), v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\nL_007A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Show()
		{
			//IL_0196: Expected O, but got I4
			//IL_019f: Expected O, but got I4
			if (IsLoaded())
			{
				Vector3 position = default(Vector3);
				position.x = 0f;
				position.y = 0f;
				position.z = 1f;
				((DummyAdBehaviour)(object)(dummyAd = ((DummyAdBehaviour)(object)typeof(BaseAdDummyClient)).ShowAd(prefabAd, position))).PauseGame();
				CreateButtonBehavior();
				AddClickBehavior(dummyAd);
				Countdown countdown = dummyAd.AddComponent<Countdown>();
				EventHandler<EventArgs> eventHandler = this.OnAdDidPresentFullScreenContent;
				if (this.OnAdDidPresentFullScreenContent == null)
				{
					return;
				}
				IntPtr invoke_impl = eventHandler.invoke_impl;
				IntPtr method_code = eventHandler.method_code;
				IntPtr method = eventHandler.method;
				float num = 1f;
				object obj = 0;
				object obj2 = 0;
			}
			else
			{
				EventHandler<AdErrorEventArgs> eventHandler2 = this.OnAdFailedToPresentFullScreenContent;
				if (this.OnAdFailedToPresentFullScreenContent == null)
				{
					return;
				}
				AdErrorEventArgs e = new AdErrorEventArgs();
				e.Message = "No Ad Loaded";
				IntPtr invoke_impl = eventHandler2.invoke_impl;
				IntPtr method_code = eventHandler2.method_code;
				IntPtr method = eventHandler2.method;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X4_v1 (System.IntPtr) (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x1343020", Offset = "0x1343020", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetServerSideVerificationOptions(ServerSideVerificationOptions serverSideVerificationOptions)
		{
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x1342290", Offset = "0x1342290", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Unity.BaseAdDummyClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36789]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RewardingAdBaseClient()
		{
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x1343024", Offset = "0x1343024", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv26 = GoogleMobileAds.Api.AdSize;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv61 = System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv66 = GoogleMobileAds.Unity.RewardingAdBaseClient;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv72 = \"DummyAds/Rewarded/1024x768\";\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv88 = \"DummyAds/Rewarded/768x1024\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv47 = 1;\n\t*([1A3678A]) = v47;\nL_002C:\n\tv49 = new System.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::.ctor(v49);\n\tv59 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v59);\n\tv59.type = *([407B40]);\n\tv70 = v49 == 0;\n\tif (v70) goto L_0060;\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v49, v59, \"DummyAds/Rewarded/768x1024\");\n\tv90 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v90);\n\tv90.type = *([407C30]);\n\tSystem.Collections.Generic.Dictionary`2<GoogleMobileAds.Api.AdSize, System.String>::Add(v49, v90, \"DummyAds/Rewarded/1024x768\");\n\tv110.prefabAds = v49;\n\treturn;\nL_0060:\n\tthrow v59;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static RewardingAdBaseClient()
		{
			Dictionary<AdSize, string> dictionary = new Dictionary<AdSize, string>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B40]");
			AdSize adSize = new AdSize(0, 0, AdSize.Type.Standard);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B40]");
			adSize.type = AdSize.Type.Standard;
			if (dictionary != null)
			{
				dictionary.Add(adSize, "DummyAds/Rewarded/768x1024");
				AdSize adSize2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407C30]");
				adSize2.type = AdSize.Type.Standard;
				dictionary.Add(adSize2, "DummyAds/Rewarded/1024x768");
				prefabAds = dictionary;
				return;
			}
			throw adSize;
		}
	}
}
