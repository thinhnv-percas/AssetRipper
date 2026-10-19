using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SnappingDemo
{
	[Token(Token = "0x2000060")]
	public class PlayWin : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000061")]
		private sealed class _003CPlayHold_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400018A")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400018B")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400018C")]
			[FieldOffset(Offset = "0x20")]
			public PlayWin _003C_003E4__this;

			[Token(Token = "0x17000027")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001E7")]
				[Address(RVA = "0x402DBFC", Offset = "0x402DBFC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000028")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001E9")]
				[Address(RVA = "0x402DC44", Offset = "0x402DC44", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001E4")]
			[Address(RVA = "0x402DA1C", Offset = "0x402DA1C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CPlayHold_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001E5")]
			[Address(RVA = "0x402DAF4", Offset = "0x402DAF4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001E6")]
			[Address(RVA = "0x402DAF8", Offset = "0x402DAF8", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.<>1__state < 2;\n\tv21 = ~v20;\n\tif (v21) goto L_0064;\n\tv29 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv61 = v29._timeLeft < 0;\n\tv59 = v29._timeLeft == 0;\n\tv63 = v29._timeLeft == v29._timeLeft;\n\tv57 = ~v63;\n\tv78 = v61 == v57;\n\tv79 = ~v78;\n\tv48 = v79 | v59;\n\tif (v48) goto L_003D;\n\tv126 = UnityEngine.Time::get_deltaTime();\n\tv105 = v29._timeLeft - v126;\n\tv29._timeLeft = v105;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_003D:\n\tv29._timeLeft = v29.unZoomTime;\n\tgoto L_004C;\n\tv44 = UnityEngine.MonoBehaviour::StartCoroutine(v29, v142);\nL_0064:\n\treturn 0;\nL_004C:\n\tv142 = new EnhancedScrollerDemos.SnappingDemo.PlayWin+<PlayUnZoom>d__10();\n\tSystem.Object::.ctor(v142);\n\tv142.<>1__state = 0;\n\tv142.<>4__this = v29;\n")]
			private bool MoveNext()
			{
				if ((uint)_003C_003E1__state < 2u)
				{
					PlayWin playWin = _003C_003E4__this;
					_003C_003E1__state = -1;
					bool flag = playWin._timeLeft < 0f;
					bool flag2 = playWin._timeLeft == 0f;
					bool flag3 = playWin._timeLeft == playWin._timeLeft;
					bool flag4 = !flag3;
					bool flag5 = flag == flag4;
					bool flag6 = !flag5;
					if (!(flag6 || flag2))
					{
						float deltaTime = Time.deltaTime;
						float timeLeft = playWin._timeLeft - deltaTime;
						playWin._timeLeft = timeLeft;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					playWin._timeLeft = playWin.unZoomTime;
					_003CPlayUnZoom_003Ed__10 _003CPlayUnZoom_003Ed__11 = (_003CPlayUnZoom_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CPlayUnZoom_003Ed__10));
					_003CPlayUnZoom_003Ed__11._003C_003E1__state = 0;
					_003CPlayUnZoom_003Ed__11._003C_003E4__this = playWin;
					Coroutine coroutine = playWin.StartCoroutine(_003CPlayUnZoom_003Ed__11);
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001E8")]
			[Address(RVA = "0x402DC04", Offset = "0x402DC04", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000062")]
		private sealed class _003CPlayUnZoom_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400018D")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400018E")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400018F")]
			[FieldOffset(Offset = "0x20")]
			public PlayWin _003C_003E4__this;

			[Token(Token = "0x17000029")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001ED")]
				[Address(RVA = "0x402DE14", Offset = "0x402DE14", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700002A")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001EF")]
				[Address(RVA = "0x402DE5C", Offset = "0x402DE5C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001EA")]
			[Address(RVA = "0x402DAC0", Offset = "0x402DAC0", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CPlayUnZoom_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001EB")]
			[Address(RVA = "0x402DC4C", Offset = "0x402DC4C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001EC")]
			[Address(RVA = "0x402DC50", Offset = "0x402DC50", Length = "0x1C4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.<>1__state < 2;\n\tv25 = ~v24;\n\tif (v25) goto L_00BA;\n\tv33 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv70 = v33._timeLeft < 0;\n\tv68 = v33._timeLeft == 0;\n\tv72 = v33._timeLeft == v33._timeLeft;\n\tv66 = ~v72;\n\tv89 = v70 == v66;\n\tv90 = ~v89;\n\tv56 = v90 | v68;\n\tif (v56) goto L_0093;\n\tv191 = UnityEngine.Time::get_deltaTime();\n\tv102 = v33._timeLeft - v191;\n\tv33._timeLeft = v102;\n\tgoto L_0043;\nL_004E:\n\tv232 = v187.zero.z - v211.one.z;\n\tv235 = v33.unZoomTime - v33._timeLeft;\n\tv236 = v235 / v33.unZoomTime;\n\tv238 = v236 < 1f;\n\tv239 = v236 == 1f;\n\tv242 = v236 == v236;\n\tv177 = 1f == 1f;\n\tv243 = v242 & v177;\n\tv244 = ~v243;\n\tv245 = v238 == v244;\n\tv151 = ~v239;\n\tv168 = v245 & v151;\n\tv246 = ~v168;\n\tif (v246) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv249 = 1f;\n\tgoto L_0065;\nL_FFFFFFFF:\n\tv249 = v236;\nL_FFFFFFFF:\n\tv254 = 0;\n\tgoto L_0072;\nL_FFFFFFFF:\n\tv254 = v249;\nL_0093:\n\tv54 = UnityEngine.Component::get_transform(v33);\n\tgoto L_00AC;\nL_00AC:\n\t// 172 MakeStruct v37 @ AGG402DDF0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v76.zero (UnityEngine.Vector3), v76.zero.y (System.Single), v76.zero.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v54, v37);\nL_00BA:\n\treturn 0;\nL_0043:\n\tgoto L_004E;\nL_0065:\n\tv181 = v236 < 0;\n\tv148 = ~v181;\n\tif (v148) goto L_FFFFFFFF;\nL_0072:\n\tv255 = v232 * v254;\n\tv154 = v211.one.z + v255;\n\tv257 = v187.zero - v211.one;\n\tv258 = v257 * v259;\n\tv162 = v211.one + v258;\n\t// 123 MakeStruct v134 @ AGG402DD60_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v162 @ V0_v12 (System.Single), v260 @ V0.S1, v154 @ V2_v7 (System.Single)\n\tUnityEngine.Transform::set_localScale(v33._transform, v134);\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\treturn 1;\n")]
			private bool MoveNext()
			{
				//IL_0320: Expected F4, but got O
				if ((uint)_003C_003E1__state < 2u)
				{
					PlayWin playWin = _003C_003E4__this;
					_003C_003E1__state = -1;
					bool flag = playWin._timeLeft < 0f;
					bool flag2 = playWin._timeLeft == 0f;
					bool flag3 = playWin._timeLeft == playWin._timeLeft;
					bool flag4 = !flag3;
					bool flag5 = flag == flag4;
					bool flag6 = !flag5;
					if (!(flag6 || flag2))
					{
						float deltaTime = Time.deltaTime;
						float timeLeft = playWin._timeLeft - deltaTime;
						playWin._timeLeft = timeLeft;
						float num = Vector3.zero.z - Vector3.one.z;
						float num2 = playWin.unZoomTime - playWin._timeLeft;
						float num3 = num2 / playWin.unZoomTime;
						bool flag7 = num3 < 1f;
						bool flag8 = num3 == 1f;
						bool flag9 = num3 == num3;
						bool flag10 = 1f == 1f;
						bool flag11 = flag9 && flag10;
						bool flag12 = !flag11;
						bool flag13 = flag7 == flag12;
						bool flag14 = !flag8;
						float num4 = ((!(flag13 && flag14)) ? num3 : 1f);
						float num5 = ((!(num3 < 0f)) ? num4 : 0f);
						float num6 = num * num5;
						float z = Vector3.one.z + num6;
						float num7 = Vector3.zero.x - Vector3.one.x;
						object obj = default(object);
						float num8 = num7 * (float)obj;
						float x = Vector3.one.x + num8;
						Vector3 localScale = default(Vector3);
						localScale.x = x;
						object obj2 = default(object);
						localScale.y = (float)obj2;
						localScale.z = z;
						playWin._transform.localScale = localScale;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					Transform transform = playWin.transform;
					Vector3 localScale2 = default(Vector3);
					localScale2.x = Vector3.zero.x;
					localScale2.y = Vector3.zero.y;
					localScale2.z = Vector3.zero.z;
					transform.localScale = localScale2;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001EE")]
			[Address(RVA = "0x402DE1C", Offset = "0x402DE1C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000063")]
		private sealed class _003CPlayZoom_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000190")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000191")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000192")]
			[FieldOffset(Offset = "0x20")]
			public PlayWin _003C_003E4__this;

			[Token(Token = "0x1700002B")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001F3")]
				[Address(RVA = "0x402E094", Offset = "0x402E094", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700002C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001F5")]
				[Address(RVA = "0x402E0DC", Offset = "0x402E0DC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001F0")]
			[Address(RVA = "0x402D978", Offset = "0x402D978", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CPlayZoom_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001F1")]
			[Address(RVA = "0x402DE64", Offset = "0x402DE64", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001F2")]
			[Address(RVA = "0x402DE68", Offset = "0x402DE68", Length = "0x22C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.<>1__state < 2;\n\tv25 = ~v24;\n\tif (v25) goto L_00D8;\n\tv33 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv74 = v33._timeLeft < 0;\n\tv72 = v33._timeLeft == 0;\n\tv76 = v33._timeLeft == v33._timeLeft;\n\tv70 = ~v76;\n\tv93 = v74 == v70;\n\tv94 = ~v93;\n\tv61 = v94 | v72;\n\tif (v61) goto L_0093;\n\tv198 = UnityEngine.Time::get_deltaTime();\n\tv107 = v33._timeLeft - v198;\n\tv33._timeLeft = v107;\n\tgoto L_0043;\nL_004E:\n\tv242 = v194.one.z - v218.zero.z;\n\tv245 = v33.zoomTime - v33._timeLeft;\n\tv246 = v245 / v33.zoomTime;\n\tv248 = v246 < 1f;\n\tv249 = v246 == 1f;\n\tv252 = v246 == v246;\n\tv184 = 1f == 1f;\n\tv253 = v252 & v184;\n\tv254 = ~v253;\n\tv255 = v248 == v254;\n\tv158 = ~v249;\n\tv175 = v255 & v158;\n\tv256 = ~v175;\n\tif (v256) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv271 = 1f;\n\tgoto L_0065;\nL_FFFFFFFF:\n\tv271 = v246;\nL_FFFFFFFF:\n\tv281 = 0;\n\tgoto L_0072;\nL_FFFFFFFF:\n\tv281 = v271;\nL_0093:\n\tv110 = UnityEngine.Component::get_transform(v33);\n\tgoto L_00AC;\nL_00AC:\n\t// 172 MakeStruct v40 @ AGG402E008_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v237.one (UnityEngine.Vector3), v237.one.y (System.Single), v237.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v110, v40);\n\tv33._timeLeft = v33.holdTime;\n\tgoto L_00BE;\n\tv57 = UnityEngine.MonoBehaviour::StartCoroutine(v33, v270);\nL_00D8:\n\treturn 0;\nL_0043:\n\tgoto L_004E;\nL_0065:\n\tv188 = v246 < 0;\n\tv155 = ~v188;\n\tif (v155) goto L_FFFFFFFF;\nL_0072:\n\tv282 = v242 * v281;\n\tv161 = v218.zero.z + v282;\n\tv284 = v194.one - v218.zero;\n\tv285 = v284 * v286;\n\tv169 = v218.zero + v285;\n\t// 123 MakeStruct v140 @ AGG402DF78_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v169 @ V0_v13 (System.Single), v287 @ V0.S1, v161 @ V2_v7 (System.Single)\n\tUnityEngine.Transform::set_localScale(v33._transform, v140);\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_00BE:\n\tv270 = new EnhancedScrollerDemos.SnappingDemo.PlayWin+<PlayHold>d__9();\n\tSystem.Object::.ctor(v270);\n\tv270.<>1__state = 0;\n\tv270.<>4__this = v33;\n")]
			private bool MoveNext()
			{
				//IL_0348: Expected F4, but got O
				if ((uint)_003C_003E1__state < 2u)
				{
					PlayWin playWin = _003C_003E4__this;
					_003C_003E1__state = -1;
					bool flag = playWin._timeLeft < 0f;
					bool flag2 = playWin._timeLeft == 0f;
					bool flag3 = playWin._timeLeft == playWin._timeLeft;
					bool flag4 = !flag3;
					bool flag5 = flag == flag4;
					bool flag6 = !flag5;
					if (!(flag6 || flag2))
					{
						float deltaTime = Time.deltaTime;
						float timeLeft = playWin._timeLeft - deltaTime;
						playWin._timeLeft = timeLeft;
						float num = Vector3.one.z - Vector3.zero.z;
						float num2 = playWin.zoomTime - playWin._timeLeft;
						float num3 = num2 / playWin.zoomTime;
						bool flag7 = num3 < 1f;
						bool flag8 = num3 == 1f;
						bool flag9 = num3 == num3;
						bool flag10 = 1f == 1f;
						bool flag11 = flag9 && flag10;
						bool flag12 = !flag11;
						bool flag13 = flag7 == flag12;
						bool flag14 = !flag8;
						float num4 = ((!(flag13 && flag14)) ? num3 : 1f);
						float num5 = ((!(num3 < 0f)) ? num4 : 0f);
						float num6 = num * num5;
						float z = Vector3.zero.z + num6;
						float num7 = Vector3.one.x - Vector3.zero.x;
						object obj = default(object);
						float num8 = num7 * (float)obj;
						float x = Vector3.zero.x + num8;
						Vector3 localScale = default(Vector3);
						localScale.x = x;
						object obj2 = default(object);
						localScale.y = (float)obj2;
						localScale.z = z;
						playWin._transform.localScale = localScale;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					Transform transform = playWin.transform;
					Vector3 localScale2 = default(Vector3);
					localScale2.x = Vector3.one.x;
					localScale2.y = Vector3.one.y;
					localScale2.z = Vector3.one.z;
					transform.localScale = localScale2;
					playWin._timeLeft = playWin.holdTime;
					_003CPlayHold_003Ed__9 _003CPlayHold_003Ed__10 = (_003CPlayHold_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CPlayHold_003Ed__9));
					_003CPlayHold_003Ed__10._003C_003E1__state = 0;
					_003CPlayHold_003Ed__10._003C_003E4__this = playWin;
					Coroutine coroutine = playWin.StartCoroutine(_003CPlayHold_003Ed__10);
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001F4")]
			[Address(RVA = "0x402E09C", Offset = "0x402E09C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x20")]
		private Transform _transform;

		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x28")]
		private float _timeLeft;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x30")]
		public Text scoreText;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x38")]
		public float zoomTime;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x3C")]
		public float holdTime;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x40")]
		public float unZoomTime;

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0x402D718", Offset = "0x402D718", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_transform(this);\n\tthis._transform = v13;\n\tgoto L_002A;\nL_002A:\n\t// 42 MakeStruct v58 @ AGG402D790_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v48.zero (UnityEngine.Vector3), v48.zero.y (System.Single), v48.zero.z (System.Single)\n\tUnityEngine.Transform::set_localScale(this._transform, v58);\n\treturn;\n")]
		private void Awake()
		{
			Transform transform = base.transform;
			_transform = transform;
			Vector3 localScale = default(Vector3);
			localScale.x = Vector3.zero.x;
			localScale.y = Vector3.zero.y;
			localScale.z = Vector3.zero.z;
			_transform.localScale = localScale;
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0x402D798", Offset = "0x402D798", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv62 = UnityEngine.UI.Text::set_text(this.scoreText, v55);\n\tv71 = UnityEngine.Component::get_transform(this);\n\tgoto L_0045;\nL_0045:\n\t// 69 MakeStruct v95 @ AGG402D87C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v127.zero (UnityEngine.Vector3), v127.zero.y (System.Single), v127.zero.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v71, v95);\n\tthis._timeLeft = this.zoomTime;\n\tgoto L_0057;\n\tv109 = UnityEngine.MonoBehaviour::StartCoroutine(this, v142);\n\treturn;\nL_0018:\n\tv46 = score;\n\tv48 = 0xB7D5000 + 0x538;\n\tv51 = \"il2cpp_vm_object_box\"(*([v48 @ X8_v4 (System.Int32)+48]), &v46 @ stack_-34_v1 (System.Int32), methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = System.String::Format(\"{0:n0}\", v51);\nL_0057:\n\tv142 = new EnhancedScrollerDemos.SnappingDemo.PlayWin+<PlayZoom>d__8();\n\tSystem.Object::.ctor(v142);\n\tv142.<>1__state = 0;\n\tv142.<>4__this = this;\n")]
		public void Play(int score)
		{
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string text = $"{arg:n0}";
			scoreText.text = text;
			Transform transform = base.transform;
			Vector3 localScale = default(Vector3);
			localScale.x = Vector3.zero.x;
			localScale.y = Vector3.zero.y;
			localScale.z = Vector3.zero.z;
			transform.localScale = localScale;
			_timeLeft = zoomTime;
			_003CPlayZoom_003Ed__8 _003CPlayZoom_003Ed__9 = (_003CPlayZoom_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CPlayZoom_003Ed__8));
			_003CPlayZoom_003Ed__9._003C_003E1__state = 0;
			_003CPlayZoom_003Ed__9._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CPlayZoom_003Ed__9);
		}

		[IteratorStateMachine(typeof(_003CPlayZoom_003Ed__8))]
		[Token(Token = "0x60001E0")]
		[Address(RVA = "0x402D900", Offset = "0x402D900", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new EnhancedScrollerDemos.SnappingDemo.PlayWin+<PlayZoom>d__8();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator PlayZoom()
		{
			_003CPlayZoom_003Ed__8 _003CPlayZoom_003Ed__9 = (_003CPlayZoom_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CPlayZoom_003Ed__8));
			_003CPlayZoom_003Ed__9._003C_003E1__state = 0;
			_003CPlayZoom_003Ed__9._003C_003E4__this = this;
			return _003CPlayZoom_003Ed__9;
		}

		[IteratorStateMachine(typeof(_003CPlayHold_003Ed__9))]
		[Token(Token = "0x60001E1")]
		[Address(RVA = "0x402D9A4", Offset = "0x402D9A4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new EnhancedScrollerDemos.SnappingDemo.PlayWin+<PlayHold>d__9();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator PlayHold()
		{
			_003CPlayHold_003Ed__9 _003CPlayHold_003Ed__10 = (_003CPlayHold_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CPlayHold_003Ed__9));
			_003CPlayHold_003Ed__10._003C_003E1__state = 0;
			_003CPlayHold_003Ed__10._003C_003E4__this = this;
			return _003CPlayHold_003Ed__10;
		}

		[IteratorStateMachine(typeof(_003CPlayUnZoom_003Ed__10))]
		[Token(Token = "0x60001E2")]
		[Address(RVA = "0x402DA48", Offset = "0x402DA48", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new EnhancedScrollerDemos.SnappingDemo.PlayWin+<PlayUnZoom>d__10();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator PlayUnZoom()
		{
			_003CPlayUnZoom_003Ed__10 _003CPlayUnZoom_003Ed__11 = (_003CPlayUnZoom_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CPlayUnZoom_003Ed__10));
			_003CPlayUnZoom_003Ed__11._003C_003E1__state = 0;
			_003CPlayUnZoom_003Ed__11._003C_003E4__this = this;
			return _003CPlayUnZoom_003Ed__11;
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0x402DAEC", Offset = "0x402DAEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public PlayWin()
		{
		}
	}
}
