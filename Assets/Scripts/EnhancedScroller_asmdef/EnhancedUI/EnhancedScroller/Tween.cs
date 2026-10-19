using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EnhancedUI.EnhancedScroller
{
	[Token(Token = "0x2000018")]
	public class Tween : MonoBehaviour
	{
		[Token(Token = "0x2000019")]
		public enum TweenType
		{
			[Token(Token = "0x400009B")]
			immediate = 0,
			[Token(Token = "0x400009C")]
			linear = 1,
			[Token(Token = "0x400009D")]
			spring = 2,
			[Token(Token = "0x400009E")]
			easeInQuad = 3,
			[Token(Token = "0x400009F")]
			easeOutQuad = 4,
			[Token(Token = "0x40000A0")]
			easeInOutQuad = 5,
			[Token(Token = "0x40000A1")]
			easeInCubic = 6,
			[Token(Token = "0x40000A2")]
			easeOutCubic = 7,
			[Token(Token = "0x40000A3")]
			easeInOutCubic = 8,
			[Token(Token = "0x40000A4")]
			easeInQuart = 9,
			[Token(Token = "0x40000A5")]
			easeOutQuart = 10,
			[Token(Token = "0x40000A6")]
			easeInOutQuart = 11,
			[Token(Token = "0x40000A7")]
			easeInQuint = 12,
			[Token(Token = "0x40000A8")]
			easeOutQuint = 13,
			[Token(Token = "0x40000A9")]
			easeInOutQuint = 14,
			[Token(Token = "0x40000AA")]
			easeInSine = 15,
			[Token(Token = "0x40000AB")]
			easeOutSine = 16,
			[Token(Token = "0x40000AC")]
			easeInOutSine = 17,
			[Token(Token = "0x40000AD")]
			easeInExpo = 18,
			[Token(Token = "0x40000AE")]
			easeOutExpo = 19,
			[Token(Token = "0x40000AF")]
			easeInOutExpo = 20,
			[Token(Token = "0x40000B0")]
			easeInCirc = 21,
			[Token(Token = "0x40000B1")]
			easeOutCirc = 22,
			[Token(Token = "0x40000B2")]
			easeInOutCirc = 23,
			[Token(Token = "0x40000B3")]
			easeInBounce = 24,
			[Token(Token = "0x40000B4")]
			easeOutBounce = 25,
			[Token(Token = "0x40000B5")]
			easeInOutBounce = 26,
			[Token(Token = "0x40000B6")]
			easeInBack = 27,
			[Token(Token = "0x40000B7")]
			easeOutBack = 28,
			[Token(Token = "0x40000B8")]
			easeInOutBack = 29,
			[Token(Token = "0x40000B9")]
			easeInElastic = 30,
			[Token(Token = "0x40000BA")]
			easeOutElastic = 31,
			[Token(Token = "0x40000BB")]
			easeInOutElastic = 32
		}

		[CompilerGenerated]
		[Token(Token = "0x200001A")]
		private sealed class _003CTweenPosition_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000BC")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000BD")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000BE")]
			[FieldOffset(Offset = "0x20")]
			public TweenType tweenType;

			[Token(Token = "0x40000BF")]
			[FieldOffset(Offset = "0x24")]
			public float time;

			[Token(Token = "0x40000C0")]
			[FieldOffset(Offset = "0x28")]
			public Tween _003C_003E4__this;

			[Token(Token = "0x40000C1")]
			[FieldOffset(Offset = "0x30")]
			public float start;

			[Token(Token = "0x40000C2")]
			[FieldOffset(Offset = "0x34")]
			public float end;

			[Token(Token = "0x40000C3")]
			[FieldOffset(Offset = "0x38")]
			public Action<float, float> tweenUpdated;

			[Token(Token = "0x40000C4")]
			[FieldOffset(Offset = "0x40")]
			public Action tweenComplete;

			[Token(Token = "0x40000C5")]
			[FieldOffset(Offset = "0x48")]
			private float _003CnewPosition_003E5__2;

			[Token(Token = "0x40000C6")]
			[FieldOffset(Offset = "0x4C")]
			private float _003ClastPosition_003E5__3;

			[Token(Token = "0x1700001D")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000D8")]
				[Address(RVA = "0x40238A8", Offset = "0x40238A8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001E")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000DA")]
				[Address(RVA = "0x40238F0", Offset = "0x40238F0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x4022424", Offset = "0x4022424", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CTweenPosition_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x4023160", Offset = "0x4023160", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x4023164", Offset = "0x4023164", Length = "0x744")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = this.<>4__this;\n\tv30 = this.<>1__state == 1;\n\tif (v30) goto L_0057;\n\tv35 = this.<>1__state == 0;\n\tv36 = ~v35;\n\tif (v36) goto L_0055;\n\tthis.<>1__state = -1;\n\tv41 = this.tweenType == 0;\n\tif (v41) goto L_0039;\n\tv112 = this.time == 0;\n\tif (v112) goto L_0039;\n\tv25._tweenTimeLeft = 0f;\n\tthis.<newPosition>5__2 = 0f;\n\tthis.<lastPosition>5__3 = this.start;\n\tv140 = 0 < this.time;\n\tv246 = 0;\n\tv185 = this.time;\n\tif (v140) goto L_0067;\nL_0039:\n\tv144 = this.tweenUpdated;\n\tv145 = this.tweenUpdated == 0;\n\tif (v145) goto L_0042;\n\tSystem.Action`2<System.Single, System.Single>::Invoke(this.tweenUpdated, v144.method, v121);\n\tSystem.Action::Invoke(this.tweenComplete);\nL_0057:\n\tthis.<>1__state = -1;\n\tv246 = v25._tweenTimeLeft;\n\tv96 = v25._tweenTimeLeft < this.time;\n\tv104 = ~v96;\n\tv185 = this.time;\n\tif (v104) goto L_0039;\nL_0067:\n\tv208 = this.tweenType - 1;\n\tv223 = v208 < 0x1F;\n\tv204 = ~v223;\n\tv202 = v208 - 0x1F;\n\tv198 = v202 == 0;\n\tv224 = ~v198;\n\tv168 = v204 & v224;\n\tif (v168) goto L_025C;\n\tv176 = 0x9309000 + 0x65A;\n\tv160 = *([v176 @ X9_v5 (System.Int32)+v208 @ X8_v6 (System.Int32)*2]) << 2;\n\tv166 = 0x4023268 + v160;\n\t// 122 IndirectJump v166 @ X10_v2 (System.Int32), this @ X0 (EnhancedUI.EnhancedScroller.Tween+<TweenPosition>d__2), this @ X0 (EnhancedUI.EnhancedScroller.Tween+<TweenPosition>d__2), methodInfo @ X1 (Il2CppMethodInfo), v121 @ X2, v122 @ X3, v123 @ X4, v124 @ X5, v125 @ X6, v126 @ X7, v182 @ V0_v2 (System.Single), v46 @ V1_v5, v185 @ V2_v3 (System.Single), v127 @ V3, v128 @ V4, v129 @ V5, v130 @ V6, v131 @ V7\n\tSystem.Action`2<System.Single, System.Single>::Invoke(this.tweenUpdated, v209.method, v121);\n\tv246 = v25._tweenTimeLeft;\nL_0055:\n\treturn 0;\nL_0042:\n\t;\n\tv68 = this.tweenComplete == 0;\n\tif (v68) goto L_0055;\nL_025C:\n\tv209 = this.tweenUpdated;\n\tv188 = this.tweenUpdated == 0;\n\tif (v188) goto L_0268;\nL_0268:\n\tthis.<lastPosition>5__3 = this.<newPosition>5__2;\n\tv250 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv183 = v246 + v250;\n\tv25._tweenTimeLeft = v183;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\treturn 1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Tween._003CTweenPosition_003Ed__2::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x40238B0", Offset = "0x40238B0", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x20")]
		private float _tweenTimeLeft;

		[IteratorStateMachine(typeof(_003CTweenPosition_003Ed__2))]
		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x4022350", Offset = "0x4022350", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv63.tweenType = tweenType;\n\tv63.time = time;\n\tv63.start = start;\n\tv63.end = end;\n\tv63.tweenUpdated = tweenUpdated;\n\tv63.tweenComplete = tweenComplete;\n\treturn v63;\nL_0023:\n\tv63 = new EnhancedUI.EnhancedScroller.Tween+<TweenPosition>d__2();\n\tSystem.Object::.ctor(v63);\n\tv63.<>1__state = 0;\n\tv63.<>4__this = this;\n")]
		public IEnumerator TweenPosition(TweenType tweenType, float time, float start, float end, Action<float, float> tweenUpdated, Action tweenComplete)
		{
			_003CTweenPosition_003Ed__2 _003CTweenPosition_003Ed__3 = (_003CTweenPosition_003Ed__2)FormatterServices.GetUninitializedObject(typeof(_003CTweenPosition_003Ed__2));
			_003CTweenPosition_003Ed__3._003C_003E1__state = 0;
			_003CTweenPosition_003Ed__3._003C_003E4__this = this;
			_003CTweenPosition_003Ed__3.tweenType = tweenType;
			_003CTweenPosition_003Ed__3.time = time;
			_003CTweenPosition_003Ed__3.start = start;
			_003CTweenPosition_003Ed__3.end = end;
			_003CTweenPosition_003Ed__3.tweenUpdated = tweenUpdated;
			_003CTweenPosition_003Ed__3.tweenComplete = tweenComplete;
			return _003CTweenPosition_003Ed__3;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x4022450", Offset = "0x4022450", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val < 1f;\n\tv3 = val == 1f;\n\tv6 = val == val;\n\tv7 = 1f == 1f;\n\tv8 = v6 & v7;\n\tv9 = ~v8;\n\tv10 = v1 == v9;\n\tv11 = ~v3;\n\tv12 = v10 & v11;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = 1f;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv16 = val;\nL_FFFFFFFF:\n\tv27 = 0;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv27 = v16;\nL_0012:\n\tv17 = val < 0;\n\tv24 = ~v17;\n\tif (v24) goto L_FFFFFFFF;\nL_001F:\n\tv28 = end - start;\n\tv31 = v28 * v27;\n\treturnVal1 = v31 + start;\n\treturn returnVal1;\n")]
		private float linear(float start, float end, float val)
		{
			bool flag = val < 1f;
			bool flag2 = val == 1f;
			bool flag3 = val == val;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num = ((!(flag7 && flag8)) ? val : 1f);
			float num2 = ((!(val < 0f)) ? num : 0f);
			float num3 = end - start;
			float num4 = num3 * num2;
			return num4 + start;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x4022478", Offset = "0x4022478", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = val < 1f;\n\tv25 = val == 1f;\n\tv28 = val == val;\n\tv29 = 1f == 1f;\n\tv30 = v28 & v29;\n\tv31 = ~v30;\n\tv32 = v23 == v31;\n\tv33 = ~v25;\n\tv34 = v32 & v33;\n\tv35 = ~v34;\n\tif (v35) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv38 = 1f;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv38 = val;\nL_FFFFFFFF:\n\tv49 = 0;\n\tgoto L_002E;\nL_FFFFFFFF:\n\tv49 = v38;\nL_001E:\n\tv39 = val < 0;\n\tv46 = ~v39;\n\tif (v46) goto L_FFFFFFFF;\nL_002E:\n\tv53 = v49 * 0x40490FDB;\n\tv55 = v49 * 2.5f;\n\tv56 = v49 * v55;\n\tv57 = v49 * v56;\n\tv61 = v57 + 0x3E4CCCCD;\n\tv62 = v53 * v61;\n\tv63 = 0x8BF749C(methodInfo, v65, v66, v67, v68, v69, v70, v71, v62, v61, 0x3E4CCCCD, v72, v73, v74, v75, v76);\n\tv78 = 1f - v49;\n\tv83 = 0x8BF6F2C(v63, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v78, 0x400CCCCD, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv84 = v78 * v62;\n\tv85 = v49 + v84;\n\tv89 = v78 * 0x3F99999A;\n\tv90 = v89 + 1f;\n\tv91 = v90 * v85;\n\tv92 = end - start;\n\tv93 = v92 * v91;\n\treturnVal1 = v93 + start;\n\treturn returnVal1;\n")]
		private static float spring(float start, float end, float val)
		{
			bool flag = val < 1f;
			bool flag2 = val == 1f;
			bool flag3 = val == val;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num = ((!(flag7 && flag8)) ? val : 1f);
			float num2 = ((!(val < 0f)) ? num : 0f);
			float num3 = num2 * (float)Math.PI;
			float num4 = num2 * 2.5f;
			float num5 = num2 * num4;
			float num6 = num2 * num5;
			float num7 = num6 + 0.2f;
			float num8 = num3 * num7;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num9 = 1f - num2;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6F2C");
			float num10 = num9 * num8;
			float num11 = num2 + num10;
			float num12 = num9 * 1.2f;
			float num13 = num12 + 1f;
			float num14 = num13 * num11;
			float num15 = end - start;
			float num16 = num15 * num14;
			return num16 + start;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x4022540", Offset = "0x4022540", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\treturnVal1 = v5 + start;\n\treturn returnVal1;\n")]
		private static float easeInQuad(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			return num3 + start;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x4022554", Offset = "0x4022554", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv6 = val + -2f;\n\tv7 = v3 * v6;\n\treturnVal1 = start - v7;\n\treturn returnVal1;\n")]
		private static float easeOutQuad(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = val + -2f;
			float num4 = num2 * num3;
			return start - num4;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x4022570", Offset = "0x4022570", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -1f;\n\tv17 = v2 * -0.5f;\n\tv19 = v15 + -2f;\n\tv20 = v15 * v19;\n\tv21 = v20 + -1f;\n\tv22 = v17 * v21;\n\tv24 = v2 * 0.5f;\n\tv25 = v24 * v0;\n\tv31 = v0 * v25;\n\tv27 = ~v6;\n\tv28 = ~v27;\n\tif (v28) goto L_001F;\n\tv31 = v22;\n\tgoto L_001F;\nL_001F:\n\treturnVal1 = v31 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutQuad(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -1f;
			float num4 = num2 * -0.5f;
			float num5 = num3 + -2f;
			float num6 = num3 * num5;
			float num7 = num6 + -1f;
			float num8 = num4 * num7;
			float num9 = num2 * 0.5f;
			float num10 = num9 * num;
			float num11 = num * num10;
			if (!flag)
			{
				num11 = num8;
			}
			return num11 + start;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x40225C0", Offset = "0x40225C0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv6 = v5 * val;\n\treturnVal1 = v6 + start;\n\treturn returnVal1;\n")]
		private static float easeInCubic(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = num3 * val;
			return num4 + start;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x40225D8", Offset = "0x40225D8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv7 = v1 * v6;\n\tv9 = v7 + 1f;\n\tv10 = v3 * v9;\n\treturnVal1 = v10 + start;\n\treturn returnVal1;\n")]
		private static float easeOutCubic(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float num4 = num * num3;
			float num5 = num4 + 1f;
			float num6 = num2 * num5;
			return num6 + start;
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x4022600", Offset = "0x4022600", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -2f;\n\tv17 = v2 * 0.5f;\n\tv18 = v15 * v15;\n\tv19 = v15 * v18;\n\tv21 = v19 + 2f;\n\tv22 = v17 * v21;\n\tv23 = v17 * v0;\n\tv24 = v0 * v23;\n\tv30 = v0 * v24;\n\tv26 = ~v6;\n\tv27 = ~v26;\n\tif (v27) goto L_001E;\n\tv30 = v22;\n\tgoto L_001E;\nL_001E:\n\treturnVal1 = v30 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutCubic(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -2f;
			float num4 = num2 * 0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * num5;
			float num7 = num6 + 2f;
			float num8 = num4 * num7;
			float num9 = num4 * num;
			float num10 = num * num9;
			float num11 = num * num10;
			if (!flag)
			{
				num11 = num8;
			}
			return num11 + start;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x402264C", Offset = "0x402264C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv6 = v5 * val;\n\tv7 = v6 * val;\n\treturnVal1 = v7 + start;\n\treturn returnVal1;\n")]
		private static float easeInQuart(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = num3 * val;
			float num5 = num4 * val;
			return num5 + start;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x4022668", Offset = "0x4022668", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv7 = v1 * v6;\n\tv8 = v1 * v7;\n\tv9 = v8 + -1f;\n\tv10 = v3 * v9;\n\treturnVal1 = start - v10;\n\treturn returnVal1;\n")]
		private static float easeOutQuart(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float num4 = num * num3;
			float num5 = num * num4;
			float num6 = num5 + -1f;
			float num7 = num2 * num6;
			return start - num7;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x4022690", Offset = "0x4022690", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -2f;\n\tv17 = v2 * -0.5f;\n\tv18 = v15 * v15;\n\tv19 = v15 * v18;\n\tv20 = v15 * v19;\n\tv21 = v20 + -2f;\n\tv22 = v17 * v21;\n\tv24 = v2 * 0.5f;\n\tv25 = v24 * v0;\n\tv26 = v0 * v25;\n\tv27 = v0 * v26;\n\tv33 = v0 * v27;\n\tv29 = ~v6;\n\tv30 = ~v29;\n\tif (v30) goto L_0021;\n\tv33 = v22;\n\tgoto L_0021;\nL_0021:\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutQuart(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -2f;
			float num4 = num2 * -0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * num5;
			float num7 = num3 * num6;
			float num8 = num7 + -2f;
			float num9 = num4 * num8;
			float num10 = num2 * 0.5f;
			float num11 = num10 * num;
			float num12 = num * num11;
			float num13 = num * num12;
			float num14 = num * num13;
			if (!flag)
			{
				num14 = num9;
			}
			return num14 + start;
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x40226E8", Offset = "0x40226E8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv6 = v5 * val;\n\tv7 = v6 * val;\n\tv8 = v7 * val;\n\treturnVal1 = v8 + start;\n\treturn returnVal1;\n")]
		private static float easeInQuint(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = num3 * val;
			float num5 = num4 * val;
			float num6 = num5 * val;
			return num6 + start;
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x4022708", Offset = "0x4022708", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv7 = v1 * v6;\n\tv8 = v1 * v7;\n\tv9 = v1 * v8;\n\tv11 = v9 + 1f;\n\tv12 = v3 * v11;\n\treturnVal1 = v12 + start;\n\treturn returnVal1;\n")]
		private static float easeOutQuint(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float num4 = num * num3;
			float num5 = num * num4;
			float num6 = num * num5;
			float num7 = num6 + 1f;
			float num8 = num2 * num7;
			return num8 + start;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x4022738", Offset = "0x4022738", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -2f;\n\tv17 = v2 * 0.5f;\n\tv18 = v15 * v15;\n\tv19 = v15 * v18;\n\tv20 = v15 * v19;\n\tv21 = v15 * v20;\n\tv23 = v21 + 2f;\n\tv24 = v17 * v23;\n\tv25 = v17 * v0;\n\tv26 = v0 * v25;\n\tv27 = v0 * v26;\n\tv28 = v0 * v27;\n\tv34 = v0 * v28;\n\tv30 = ~v6;\n\tv31 = ~v30;\n\tif (v31) goto L_0022;\n\tv34 = v24;\n\tgoto L_0022;\nL_0022:\n\treturnVal1 = v34 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutQuint(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -2f;
			float num4 = num2 * 0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * num5;
			float num7 = num3 * num6;
			float num8 = num3 * num7;
			float num9 = num8 + 2f;
			float num10 = num4 * num9;
			float num11 = num4 * num;
			float num12 = num * num11;
			float num13 = num * num12;
			float num14 = num * num13;
			float num15 = num * num14;
			if (!flag)
			{
				num15 = num10;
			}
			return num15 + start;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x4022794", Offset = "0x4022794", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv17 = val * 0x3FC90FDB;\n\tv19 = 0x8BF608C(methodInfo, v21, v22, v23, v24, v25, v26, v27, v17, end, val, v28, v29, v30, v31, v32);\n\tv33 = v12 * v17;\n\tv34 = v12 - v33;\n\treturnVal1 = v34 + start;\n\treturn returnVal1;\n")]
		private static float easeInSine(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * ((float)Math.PI / 2f);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF608C");
			float num3 = num * num2;
			float num4 = num - num3;
			return num4 + start;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x40227D4", Offset = "0x40227D4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv17 = val * 0x3FC90FDB;\n\tv19 = 0x8BF749C(methodInfo, v21, v22, v23, v24, v25, v26, v27, v17, end, val, v28, v29, v30, v31, v32);\n\tv33 = v12 * v17;\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeOutSine(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * ((float)Math.PI / 2f);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num3 = num * num2;
			return num3 + start;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x4022810", Offset = "0x4022810", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv17 = val * 0x40490FDB;\n\tv19 = 0x8BF608C(methodInfo, v21, v22, v23, v24, v25, v26, v27, v17, end, val, v28, v29, v30, v31, v32);\n\tv34 = v12 * -0.5f;\n\tv36 = v17 + -1f;\n\tv37 = v34 * v36;\n\treturnVal1 = start + v37;\n\treturn returnVal1;\n")]
		private static float easeInOutSine(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * (float)Math.PI;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF608C");
			float num3 = num * -0.5f;
			float num4 = num2 + -1f;
			float num5 = num3 * num4;
			return start + num5;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x402285C", Offset = "0x402285C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv15 = val + -1f;\n\tv18 = v15 * 10f;\n\tv19 = 0x8BF63A4(methodInfo, v21, v22, v23, v24, v25, v26, v27, v18, 10f, val, v28, v29, v30, v31, v32);\n\tv33 = v12 * v18;\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeInExpo(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + -1f;
			float num3 = num2 * 10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x4022898", Offset = "0x4022898", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv15 = val * -10f;\n\tv17 = 0x8BF63A4(methodInfo, v19, v20, v21, v22, v23, v24, v25, v15, end, val, v26, v27, v28, v29, v30);\n\tv32 = 1f - v15;\n\tv33 = v12 * v32;\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeOutExpo(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * -10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num3 = 1f - num2;
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x40228D4", Offset = "0x40228D4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = val + val;\n\tv17 = v14 + -1f;\n\tv19 = v14 < 1f;\n\tv27 = ~v19;\n\tif (v27) goto L_001B;\n\tv50 = v17 * 10f;\n\tv30 = 0x8BF63A4(methodInfo, v32, v33, v34, v35, v36, v37, v38, v50, 10f, 1f, v39, v40, v41, v42, v43);\n\tgoto L_001F;\nL_001B:\n\tv45 = v17 * -10f;\n\tv46 = 0x8BF63A4(methodInfo, v32, v33, v34, v35, v36, v37, v38, v45, -10f, 1f, v39, v40, v41, v42, v43);\n\tv50 = 2f - v45;\nL_001F:\n\tv52 = end - start;\n\tv54 = v52 * 0.5f;\n\tv55 = v54 * v50;\n\treturnVal1 = v55 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutExpo(float start, float end, float val)
		{
			float num = val + val;
			float num2 = num + -1f;
			float num3;
			if (num < 1f)
			{
				num3 = num2 * 10f;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			}
			else
			{
				float num4 = num2 * -10f;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
				num3 = 2f - num4;
			}
			float num5 = end - start;
			float num6 = num5 * 0.5f;
			float num7 = num6 * num3;
			return num7 + start;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x4022944", Offset = "0x4022944", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = val * val;\n\tv6 = 1f - v3;\n\tv7 = UnityEngine.Mathf::Sqrt(v6);\n\tv9 = v7 + -1f;\n\tv10 = v0 * v9;\n\treturnVal1 = start - v10;\n\treturn returnVal1;\n")]
		private static float easeInCirc(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * val;
			float f = 1f - num2;
			float num3 = Mathf.Sqrt(f);
			float num4 = num3 + -1f;
			float num5 = num * num4;
			return start - num5;
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x402296C", Offset = "0x402296C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv8 = 1f - v6;\n\tv9 = UnityEngine.Mathf::Sqrt(v8);\n\tv10 = v3 * v9;\n\treturnVal1 = v10 + start;\n\treturn returnVal1;\n")]
		private static float easeOutCirc(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float f = 1f - num3;
			float num4 = Mathf.Sqrt(f);
			float num5 = num2 * num4;
			return num5 + start;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x4022994", Offset = "0x4022994", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 + -2f;\n\tv7 = v6 * v6;\n\tv8 = v0 * v0;\n\tv10 = v0 < 1f;\n\tv18 = ~v10;\n\tif (v18) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv21 = v8;\n\tgoto L_0017;\nL_FFFFFFFF:\n\tv21 = v7;\nL_FFFFFFFF:\n\tv27 = -0.5f;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv27 = 0.5f;\nL_FFFFFFFF:\n\tv32 = -1f;\n\tgoto L_0024;\nL_FFFFFFFF:\n\tv32 = 1f;\nL_0017:\n\tv24 = ~v10;\n\tif (v24) goto L_FFFFFFFF;\nL_001E:\n\tv29 = ~v10;\n\tif (v29) goto L_FFFFFFFF;\nL_0024:\n\tv33 = 1f - v21;\n\tv34 = UnityEngine.Mathf::Sqrt(v33);\n\tv35 = v2 * v27;\n\tv36 = v34 + v32;\n\tv37 = v35 * v36;\n\treturnVal1 = v37 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutCirc(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			float num3 = num + -2f;
			float num4 = num3 * num3;
			float num5 = num * num;
			bool flag = num < 1f;
			float num6 = ((!flag) ? num4 : num5);
			float num7 = ((!flag) ? 0.5f : (-0.5f));
			float num8 = ((!flag) ? 1f : (-1f));
			float f = 1f - num6;
			float num9 = Mathf.Sqrt(f);
			float num10 = num2 * num7;
			float num11 = num9 + num8;
			float num12 = num10 * num11;
			return num12 + start;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x40229E8", Offset = "0x40229E8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = 1f - val;\n\tv6 = v1 < 0x3EBA2E8C;\n\tv14 = ~v6;\n\tif (v14) goto L_0017;\n\tv17 = v1 * 0x40F20000;\n\tv50 = v1 * v17;\n\tgoto L_004D;\nL_0017:\n\tv22 = v1 < 0x3F3A2E8C;\n\tv30 = ~v22;\n\tif (v30) goto L_002E;\n\tv65 = v1 + 0xFFFFFFFFBF0BA2E9;\n\tv68 = v65 * 0x40F20000;\n\tv85 = v65 * v68;\n\tv53 = 0.75f;\n\tgoto L_004C;\nL_002E:\n\tv74 = v1 < 0.9090909090909091d;\n\tv82 = ~v74;\n\tif (v82) goto L_0045;\n\tv93 = v1 + 0xFFFFFFFFBF51745D;\n\tv95 = v93 * 0x40F20000;\n\tv85 = v93 * v95;\n\tv53 = 0.9375f;\n\tgoto L_004C;\nL_0045:\n\tv99 = v1 + 0xFFFFFFFFBF745D17;\n\tv102 = v99 * 0x40F20000;\n\tv85 = v99 * v102;\n\tv53 = 0x3F7C0000;\nL_004D:\n\tv54 = end - start;\n\tv57 = v54 * v50;\n\tv60 = v54 - v57;\n\treturnVal1 = v60 + start;\n\treturn returnVal1;\nL_004C:\n\tv50 = v85 + v53;\n")]
		private static float easeInBounce(float start, float end, float val)
		{
			float num = 1f - val;
			float num3;
			if (num < 0.36363637f)
			{
				float num2 = num * 7.5625f;
				num3 = num * num2;
			}
			else
			{
				float num6;
				float num7;
				if (num < 0.72727275f)
				{
					float num4 = num + -0.54545456f;
					float num5 = num4 * 7.5625f;
					num6 = num4 * num5;
					num7 = 0.75f;
				}
				else if ((double)num < 0.9090909090909091)
				{
					float num8 = num + -0.8181818f;
					float num9 = num8 * 7.5625f;
					num6 = num8 * num9;
					num7 = 0.9375f;
				}
				else
				{
					float num10 = num + -21f / 22f;
					float num11 = num10 * 7.5625f;
					num6 = num10 * num11;
					num7 = 63f / 64f;
				}
				num3 = num6 + num7;
			}
			float num12 = end - start;
			float num13 = num12 * num3;
			float num14 = num12 - num13;
			return num14 + start;
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x4022AD8", Offset = "0x4022AD8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = val < 0x3EBA2E8C;\n\tv12 = ~v3;\n\tif (v12) goto L_0018;\n\tv15 = val * 0x40F20000;\n\tv16 = v15 * val;\n\tv17 = end - start;\n\tv20 = v17 * v16;\n\treturnVal1 = v20 + start;\n\treturn returnVal1;\nL_0018:\n\tv25 = val < 0x3F3A2E8C;\n\tv33 = ~v25;\n\tif (v33) goto L_0033;\n\tv74 = val + 0xFFFFFFFFBF0BA2E9;\n\tv76 = v74 * 0x40F20000;\n\tv77 = v74 * v76;\n\tv46 = v77 + 0.75f;\n\tv78 = end - start;\n\tv42 = v78 * v46;\n\treturnVal2 = v42 + start;\n\treturn returnVal2;\nL_0033:\n\tv62 = val < 0.9090909090909091d;\n\tv50 = ~v62;\n\tif (v50) goto L_004E;\n\tv86 = val + 0xFFFFFFFFBF51745D;\n\tv88 = v86 * 0x40F20000;\n\tv89 = v86 * v88;\n\tv47 = v89 + 0.9375f;\n\tv90 = end - start;\n\tv43 = v90 * v47;\n\treturnVal3 = v43 + start;\n\treturn returnVal3;\nL_004E:\n\tv94 = val + 0xFFFFFFFFBF745D17;\n\tv97 = v94 * 0x40F20000;\n\tv98 = v94 * v97;\n\tv48 = v98 + 0x3F7C0000;\n\tv99 = end - start;\n\tv44 = v99 * v48;\n\treturnVal4 = v44 + start;\n\treturn returnVal4;\n")]
		private static float easeOutBounce(float start, float end, float val)
		{
			if (val < 0.36363637f)
			{
				float num = val * 7.5625f;
				float num2 = num * val;
				float num3 = end - start;
				float num4 = num3 * num2;
				return num4 + start;
			}
			if (val < 0.72727275f)
			{
				float num5 = val + -0.54545456f;
				float num6 = num5 * 7.5625f;
				float num7 = num5 * num6;
				float num8 = num7 + 0.75f;
				float num9 = end - start;
				float num10 = num9 * num8;
				return num10 + start;
			}
			if ((double)val < 0.9090909090909091)
			{
				float num11 = val + -0.8181818f;
				float num12 = num11 * 7.5625f;
				float num13 = num11 * num12;
				float num14 = num13 + 0.9375f;
				float num15 = end - start;
				float num16 = num15 * num14;
				return num16 + start;
			}
			float num17 = val + -21f / 22f;
			float num18 = num17 * 7.5625f;
			float num19 = num17 * num18;
			float num20 = num19 + 63f / 64f;
			float num21 = end - start;
			float num22 = num21 * num20;
			return num22 + start;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x4022BE0", Offset = "0x4022BE0", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = val + val;\n\tv6 = val < 0.5f;\n\tv14 = ~v6;\n\tif (v14) goto L_0022;\n\tv16 = 1f - v3;\n\tv20 = v16 < 0x3EBA2E8C;\n\tv28 = ~v20;\n\tif (v28) goto L_0038;\n\tv45 = v16 * 0x40F20000;\n\tv77 = v16 * v45;\n\tgoto L_009C;\nL_0022:\n\tv30 = v3 + -1f;\n\tv34 = v30 < 0x3EBA2E8C;\n\tv42 = ~v34;\n\tif (v42) goto L_004F;\n\tv61 = v30 * 0x40F20000;\n\tv128 = v30 * v61;\n\tgoto L_00B0;\nL_0038:\n\tv50 = v16 < 0x3F3A2E8C;\n\tv58 = ~v50;\n\tif (v58) goto L_0066;\n\tv108 = v16 + 0xFFFFFFFFBF0BA2E9;\n\tv111 = v108 * 0x40F20000;\n\tv192 = v108 * v111;\n\tv96 = 0.75f;\n\tgoto L_009B;\nL_004F:\n\tv66 = v30 < 0x3F3A2E8C;\n\tv74 = ~v66;\n\tif (v74) goto L_007D;\n\tv159 = v30 + 0xFFFFFFFFBF0BA2E9;\n\tv162 = v159 * 0x40F20000;\n\tv212 = v159 * v162;\n\tv147 = 0.75f;\n\tgoto L_00AF;\nL_0066:\n\tv117 = v16 < 0.9090909090909091d;\n\tv125 = ~v117;\n\tif (v125) goto L_0094;\n\tv200 = v16 + 0xFFFFFFFFBF51745D;\n\tv202 = v200 * 0x40F20000;\n\tv192 = v200 * v202;\n\tv96 = 0.9375f;\n\tgoto L_009B;\nL_007D:\n\tv168 = v30 < 0.9090909090909091d;\n\tv176 = ~v168;\n\tif (v176) goto L_00A8;\n\tv220 = v30 + 0xFFFFFFFFBF51745D;\n\tv222 = v220 * 0x40F20000;\n\tv212 = v220 * v222;\n\tv147 = 0.9375f;\n\tgoto L_00AF;\nL_0094:\n\tv206 = v16 + 0xFFFFFFFFBF745D17;\n\tv209 = v206 * 0x40F20000;\n\tv192 = v206 * v209;\n\tv96 = 0x3F7C0000;\nL_00A8:\n\tv226 = v30 + 0xFFFFFFFFBF745D17;\n\tv229 = v226 * 0x40F20000;\n\tv212 = v226 * v229;\n\tv147 = 0x3F7C0000;\nL_009C:\n\tv97 = v0 * v77;\n\tv100 = v0 - v97;\n\tv103 = v100 * 0.5f;\n\treturnVal1 = v103 + start;\n\treturn returnVal1;\nL_00B0:\n\tv148 = v0 * v128;\n\tv152 = v148 * 0.5f;\n\tv153 = v0 * 0.5f;\n\tv154 = v153 + v152;\n\treturnVal2 = v154 + start;\n\treturn returnVal2;\nL_009B:\n\tv77 = v192 + v96;\nL_00AF:\n\tv128 = v212 + v147;\n")]
		private static float easeInOutBounce(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + val;
			if (val < 0.5f)
			{
				float num3 = 1f - num2;
				float num5;
				if (num3 < 0.36363637f)
				{
					float num4 = num3 * 7.5625f;
					num5 = num3 * num4;
				}
				else
				{
					float num8;
					float num9;
					if (num3 < 0.72727275f)
					{
						float num6 = num3 + -0.54545456f;
						float num7 = num6 * 7.5625f;
						num8 = num6 * num7;
						num9 = 0.75f;
					}
					else if ((double)num3 < 0.9090909090909091)
					{
						float num10 = num3 + -0.8181818f;
						float num11 = num10 * 7.5625f;
						num8 = num10 * num11;
						num9 = 0.9375f;
					}
					else
					{
						float num12 = num3 + -21f / 22f;
						float num13 = num12 * 7.5625f;
						num8 = num12 * num13;
						num9 = 63f / 64f;
					}
					num5 = num8 + num9;
				}
				float num14 = num * num5;
				float num15 = num - num14;
				float num16 = num15 * 0.5f;
				return num16 + start;
			}
			float num17 = num2 + -1f;
			float num19;
			if (num17 < 0.36363637f)
			{
				float num18 = num17 * 7.5625f;
				num19 = num17 * num18;
			}
			else
			{
				float num22;
				float num23;
				if (num17 < 0.72727275f)
				{
					float num20 = num17 + -0.54545456f;
					float num21 = num20 * 7.5625f;
					num22 = num20 * num21;
					num23 = 0.75f;
				}
				else if ((double)num17 < 0.9090909090909091)
				{
					float num24 = num17 + -0.8181818f;
					float num25 = num24 * 7.5625f;
					num22 = num24 * num25;
					num23 = 0.9375f;
				}
				else
				{
					float num26 = num17 + -21f / 22f;
					float num27 = num26 * 7.5625f;
					num22 = num26 * num27;
					num23 = 63f / 64f;
				}
				num19 = num22 + num23;
			}
			float num28 = num * num19;
			float num29 = num28 * 0.5f;
			float num30 = num * 0.5f;
			float num31 = num30 + num29;
			return num31 + start;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x4022DE4", Offset = "0x4022DE4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv9 = val * 0x402CE6B0;\n\tv13 = v9 + 0xFFFFFFFFBFD9CD60;\n\tv14 = v5 * v13;\n\treturnVal1 = v14 + start;\n\treturn returnVal1;\n")]
		private static float easeInBack(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = val * 2.70158f;
			float num5 = num4 + -1.70158f;
			float num6 = num3 * num5;
			return num6 + start;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x4022E1C", Offset = "0x4022E1C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = val + -1f;\n\tv6 = v4 * v4;\n\tv10 = v4 * 0x402CE6B0;\n\tv14 = v10 + 0x3FD9CD60;\n\tv15 = v6 * v14;\n\tv17 = v15 + 1f;\n\tv18 = v0 * v17;\n\treturnVal1 = v18 + start;\n\treturn returnVal1;\n")]
		private static float easeOutBack(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + -1f;
			float num3 = num2 * num2;
			float num4 = num2 * 2.70158f;
			float num5 = num4 + 1.70158f;
			float num6 = num3 * num5;
			float num7 = num6 + 1f;
			float num8 = num * num7;
			return num8 + start;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x4022E64", Offset = "0x4022E64", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = val + val;\n\tv6 = v3 < 1f;\n\tv15 = v3 + -2f;\n\tv17 = v0 * 0.5f;\n\tv18 = v15 * v15;\n\tv22 = v15 * 0x406612FF;\n\tv26 = v22 + 0x402612FF;\n\tv27 = v18 * v26;\n\tv29 = v27 + 2f;\n\tv30 = v17 * v29;\n\tv31 = v3 * v3;\n\tv35 = v3 * 0x406612FF;\n\tv39 = v35 + 0xFFFFFFFFC02612FF;\n\tv40 = v31 * v39;\n\tv46 = v17 * v40;\n\tv42 = ~v6;\n\tv43 = ~v42;\n\tif (v43) goto L_002E;\n\tv46 = v30;\n\tgoto L_002E;\nL_002E:\n\treturnVal1 = v46 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutBack(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + val;
			bool flag = num2 < 1f;
			float num3 = num2 + -2f;
			float num4 = num * 0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * 3.5949094f;
			float num7 = num6 + 2.5949094f;
			float num8 = num5 * num7;
			float num9 = num8 + 2f;
			float num10 = num4 * num9;
			float num11 = num2 * num2;
			float num12 = num2 * 3.5949094f;
			float num13 = num12 + -2.5949094f;
			float num14 = num11 * num13;
			float num15 = num4 * num14;
			if (!flag)
			{
				num15 = num10;
			}
			return num15 + start;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x4022EF0", Offset = "0x4022EF0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = val == 0;\n\tv7 = ~v2;\n\tif (v7) goto L_0011;\n\treturn start;\nL_0011:\n\tv23 = end - start;\n\tv27 = val == 1f;\n\tv34 = ~v27;\n\tif (v34) goto L_0027;\n\treturnVal2 = v23 + start;\n\treturn returnVal2;\nL_0027:\n\tv87 = val + -1f;\n\tv89 = v87 * 10f;\n\tv92 = 0x8BF63A4(methodInfo, v93, v94, v95, v96, v97, v98, v99, v89, v89, val, v100, v101, v102, v103, v104);\n\tv109 = v87 + 0xFFFFFFFFBD99999A;\n\tv113 = v109 * 0xFFFFFFFFC0C90FDB;\n\tv116 = v113 / 0x3E99999A;\n\tv42 = 0x8BF749C(v92, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v116, 0x3E99999A, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv36 = v89 * v23;\n\tv61 = v36 * v116;\n\treturnVal3 = start + v61;\n\treturn returnVal3;\n")]
		private static float easeInElastic(float start, float end, float val)
		{
			if (val == 0f)
			{
				return start;
			}
			float num = end - start;
			if (val == 1f)
			{
				return num + start;
			}
			float num2 = val + -1f;
			float num3 = num2 * 10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num4 = num2 + -0.075f;
			float num5 = num4 * ((float)Math.PI * -2f);
			float num6 = num5 / 0.3f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num7 = num3 * num;
			float num8 = num7 * num6;
			return start + num8;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x4022FA0", Offset = "0x4022FA0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = val == 0;\n\tv7 = ~v2;\n\tif (v7) goto L_0011;\n\treturn start;\nL_0011:\n\tv23 = end - start;\n\tv27 = val == 1f;\n\tv34 = ~v27;\n\tif (v34) goto L_0027;\n\treturnVal2 = v23 + start;\n\treturn returnVal2;\nL_0027:\n\tv87 = val * -10f;\n\tv91 = 0x8BF63A4(methodInfo, v92, v93, v94, v95, v96, v97, v98, v87, v87, val, v99, v100, v101, v102, v103);\n\tv108 = val + 0xFFFFFFFFBD99999A;\n\tv112 = v108 * 0x40C90FDB;\n\tv115 = v112 / 0x3E99999A;\n\tv42 = 0x8BF749C(v91, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v115, 0x3E99999A, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv36 = v23 * v87;\n\tv116 = v36 * v115;\n\tv61 = v23 + v116;\n\treturnVal3 = v61 + start;\n\treturn returnVal3;\n")]
		private static float easeOutElastic(float start, float end, float val)
		{
			if (val == 0f)
			{
				return start;
			}
			float num = end - start;
			if (val == 1f)
			{
				return num + start;
			}
			float num2 = val * -10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num3 = val + -0.075f;
			float num4 = num3 * ((float)Math.PI * 2f);
			float num5 = num4 / 0.3f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num6 = num * num2;
			float num7 = num6 * num5;
			float num8 = num + num7;
			return num8 + start;
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x4023050", Offset = "0x4023050", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = val == 0;\n\tv7 = ~v2;\n\tif (v7) goto L_0013;\n\treturn start;\nL_0013:\n\tv27 = end - start;\n\tv29 = val + val;\n\tv32 = v29 == 2f;\n\tv39 = ~v32;\n\tif (v39) goto L_002D;\n\treturnVal2 = v27 + start;\n\treturn returnVal2;\nL_002D:\n\tv119 = v29 + -1f;\n\tv123 = v119 + 0xFFFFFFFFBD99999A;\n\tv127 = v123 * 0x40C90FDB;\n\tv130 = v127 / 0x3E99999A;\n\tv131 = 0x8BF749C(methodInfo, v132, v133, v134, v135, v136, v137, v138, v130, 0x3E99999A, val, v139, v140, v141, v142, v143);\n\tv116 = v29 < 1f;\n\tv106 = ~v116;\n\tif (v106) goto L_005A;\n\tv149 = v119 * 10f;\n\tv42 = 0x8BF63A4(v131, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v149, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv152 = v27 * v149;\n\tv153 = v152 * v130;\n\tv75 = v153 * -0.5f;\n\treturnVal3 = start + v75;\n\treturn returnVal3;\nL_005A:\n\tv151 = v119 * -10f;\n\tv43 = 0x8BF63A4(v131, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v151, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv155 = v27 * v151;\n\tv156 = v155 * v130;\n\tv158 = v156 * 0.5f;\n\tv76 = v27 + v158;\n\treturnVal4 = v76 + start;\n\treturn returnVal4;\n")]
		private static float easeInOutElastic(float start, float end, float val)
		{
			if (val == 0f)
			{
				return start;
			}
			float num = end - start;
			float num2 = val + val;
			if (num2 == 2f)
			{
				return num + start;
			}
			float num3 = num2 + -1f;
			float num4 = num3 + -0.075f;
			float num5 = num4 * ((float)Math.PI * 2f);
			float num6 = num5 / 0.3f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			if (num2 < 1f)
			{
				float num7 = num3 * 10f;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
				float num8 = num * num7;
				float num9 = num8 * num6;
				float num10 = num9 * -0.5f;
				return start + num10;
			}
			float num11 = num3 * -10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num12 = num * num11;
			float num13 = num12 * num6;
			float num14 = num13 * 0.5f;
			float num15 = num + num14;
			return num15 + start;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x4023158", Offset = "0x4023158", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Tween()
		{
		}
	}
}
