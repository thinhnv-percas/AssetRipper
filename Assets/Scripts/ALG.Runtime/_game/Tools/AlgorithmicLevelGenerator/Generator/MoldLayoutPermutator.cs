using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000051")]
	public static class MoldLayoutPermutator
	{
		[CompilerGenerated]
		[Token(Token = "0x2000052")]
		private sealed class _003CBuildSwapSchedule_003Ed__1 : IEnumerable<(int, int)>, IEnumerable, IEnumerator<(int, int)>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000156")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000157")]
			[FieldOffset(Offset = "0x14")]
			private (int swapCount, int seed) _003C_003E2__current;

			[Token(Token = "0x4000158")]
			[FieldOffset(Offset = "0x1C")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000159")]
			[FieldOffset(Offset = "0x20")]
			private int budget;

			[Token(Token = "0x400015A")]
			[FieldOffset(Offset = "0x24")]
			public int _003C_003E3__budget;

			[Token(Token = "0x400015B")]
			[FieldOffset(Offset = "0x28")]
			private int baseSeed;

			[Token(Token = "0x400015C")]
			[FieldOffset(Offset = "0x2C")]
			public int _003C_003E3__baseSeed;

			[Token(Token = "0x400015D")]
			[FieldOffset(Offset = "0x30")]
			private float moldRandomization;

			[Token(Token = "0x400015E")]
			[FieldOffset(Offset = "0x34")]
			public float _003C_003E3__moldRandomization;

			[Token(Token = "0x400015F")]
			[FieldOffset(Offset = "0x38")]
			private int sourceLength;

			[Token(Token = "0x4000160")]
			[FieldOffset(Offset = "0x3C")]
			public int _003C_003E3__sourceLength;

			[Token(Token = "0x4000161")]
			[FieldOffset(Offset = "0x40")]
			private int _003CmaxSwap_003E5__2;

			[Token(Token = "0x4000162")]
			[FieldOffset(Offset = "0x44")]
			private int _003Cremaining_003E5__3;

			[Token(Token = "0x4000163")]
			[FieldOffset(Offset = "0x48")]
			private int _003Ci_003E5__4;

			[Token(Token = "0x17000005")]
			(int, int) IEnumerator<(int, int)>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000D7")]
				[Address(RVA = "0x3C1A67C", Offset = "0x3C1A67C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000006")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000D9")]
				[Address(RVA = "0x3C1A6C4", Offset = "0x3C1A6C4", Length = "0x68")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = this.<>2__current;\n\t// 26 Box returnVal1 @ X0_v3 (System.Object), typeof(System.ValueTuple`2<System.Int32, System.Int32>), &v45 @ stack_-38_v1 (System.ValueTuple`2<System.Int32, System.Int32>)\n\treturn returnVal1;\n")]
				get
				{
					(int, int) tuple = _003C_003E2__current;
					return tuple;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x3C1A3A0", Offset = "0x3C1A3A0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CBuildSwapSchedule_003Ed__1(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x3C1A3D8", Offset = "0x3C1A3D8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x3C1A3DC", Offset = "0x3C1A3DC", Length = "0x2A0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv63 = this.<>1__state == 1;\n\tif (v63) goto L_0057;\n\tv82 = this.<>1__state == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_00C8;\n\tthis.<>1__state = -1;\n\tv157 = this.budget < 1;\n\tif (v157) goto L_00C8;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v265 @ stack_-48_v3 (System.ValueTuple`2<System.Int32, System.Int32>), 0, this.baseSeed);\n\tthis.<>2__current = v265;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_0057:\n\tthis.<>1__state = -1;\n\tv96 = this.budget < 2;\n\tif (v96) goto L_00C8;\n\tv175 = this.moldRandomization == 0;\n\tv207 = this.moldRandomization < 0;\n\tv187 = ~v207;\n\tv208 = ~v187;\n\tv158 = v208 | v175;\n\tif (v158) goto L_00C8;\n\tv159 = this.sourceLength < 2;\n\tif (v159) goto L_00C8;\n\tgoto L_0086;\nL_0086:\n\tv108 = this.moldRandomization * this.sourceLength;\n\tv130 = 0x3176680(System.Math, methodInfo, v29, v30, v31, v32, v33, v34, v108, this.moldRandomization, v37, v38, v39, v40, v41, v42);\n\tv378 = v108 - 1;\n\tv379 = v378 < 0;\n\tv380 = v378 == 0;\n\tv381 = v108 ^ 1;\n\tv382 = v108 ^ v378;\n\tv383 = v381 & v382;\n\tv384 = v383 < 0;\n\tv385 = v379 == v384;\n\tv104 = ~v380;\n\tv386 = v385 & v104;\n\tv387 = ~v386;\n\tif (v387) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv430 = v108;\n\tgoto L_009F;\nL_FFFFFFFF:\n\tv430 = 1;\nL_FFFFFFFF:\n\tv98 = v430;\n\tgoto L_00AE;\nL_FFFFFFFF:\n\tv98 = 1;\nL_00C8:\n\treturn 0;\nL_00CA:\n\tthis.<>1__state = -1;\n\tv133 = this.<remaining>5__3;\n\tv254 = this.<i>5__4 + 1;\n\tthis.<i>5__4 = v254;\n\tv81 = v254 >= this.<remaining>5__3;\n\tif (v81) goto L_00C8;\nL_00DA:\n\tv329 = this.<maxSwap>5__2;\n\tv142 = v133 == 1;\n\tv147 = v133 - 1;\n\tif (v142) goto L_0146;\n\tgoto L_00F0;\n\tv357 = v226 == -0.5d;\n\tv364 = ~v357;\n\tif (v364) goto L_012B;\nL_FFFFFFFF:\n\tv400 = -1d;\nL_FFFFFFFF:\n\tv224 = v232;\nL_FFFFFFFF:\n\tv409 = v232;\n\tgoto L_011E;\nL_0112:\n\tv367 = v226 == 0.5d;\n\tv374 = ~v367;\n\tif (v374) goto L_012E;\nL_FFFFFFFF:\n\tv400 = 1d;\nL_FFFFFFFF:\n\tv224 = v232;\nL_FFFFFFFF:\n\tv409 = v232;\n\tgoto L_012A;\nL_FFFFFFFF:\n\tv224 = v410;\nL_012B:\n\tv391 = v226 + -0.5d;\n\tv224 = System.Math::Ceiling(v391);\n\tgoto L_0134;\nL_012E:\n\tv396 = v226 + 0.5d;\n\tv224 = System.Math::Floor(v396);\nL_0134:\n\tv241 = v224 == 0x7FF0000000000000;\n\tv220 = ~v241;\n\tif (v220) goto L_0140;\nL_FFFFFFFF:\n\tv230 = 0xFFFFFFFF80000001;\n\tgoto L_0142;\nL_0140:\n\tv230 = v224 + 1;\nL_001E:\n\tv52 = this.<>1__state == 2;\n\tif (v52) goto L_00CA;\nL_009F:\n\tv433 = v108 == 0x7FF0000000000000;\n\tv440 = ~v433;\n\tv101 = ~v440;\n\tif (v101) goto L_FFFFFFFF;\nL_00AE:\n\tv133 = this.budget - 1;\n\tthis.<maxSwap>5__2 = v98;\n\tthis.<remaining>5__3 = v133;\n\tthis.<i>5__4 = 0;\n\tv112 = 0 < v133;\nL_FFFFFFFF:\n\tv254 = 0;\n\tif (v112) goto L_00DA;\nL_0146:\n\tv259 = v254 * 0x65;\n\tv260 = this.baseSeed + v259;\n\tv266 = v260 + 0x65;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v265 @ stack_-48_v3 (System.ValueTuple`2<System.Int32, System.Int32>), v329, v266);\n\tthis.<>2__current = v265;\n\tthis.<>1__state = 2;\n\treturn 1;\nL_00F0:\n\tv332 = this.<maxSwap>5__2 - 1;\n\tv335 = v254 / v147;\n\tv226 = v335 * v332;\n\tv249 = 0x8BF6AF4(&v232 @ stack_-48_v4 (System.Double), this.<maxSwap>5__2, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v226, v335, v147, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv344 = v226 < 0;\n\tv348 = v226 == v226;\n\tv349 = ~v348;\n\tv350 = v344 == v349;\n\tif (v350) goto L_0112;\nL_011E:\n\tv410 = v224 + v400;\n\tv411 = v409 & 1;\n\tv413 = v411 == 0;\n\tv416 = ~v413;\n\tif (v416) goto L_FFFFFFFF;\nL_012A:\n\tgoto L_0134;\nL_0142:\n\tv254 = this.<i>5__4;\nL_FFFFFFFF:\n\tv329 = v230;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MoldLayoutPermutator._003CBuildSwapSchedule_003Ed__1::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x3C1A684", Offset = "0x3C1A684", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000DA")]
			[Address(RVA = "0x3C1A72C", Offset = "0x3C1A72C", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\treturnVal1 = this;\n\tgoto L_003E;\nL_0033:\n\tv76 = new _game.Tools.AlgorithmicLevelGenerator.Generator.MoldLayoutPermutator+<BuildSwapSchedule>d__1();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\treturnVal1 = v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\nL_003E:\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<System.ValueTuple`2<System.Int32, System.Int32>>)+20]) = this.<>3__budget;\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<System.ValueTuple`2<System.Int32, System.Int32>>)+38]) = this.<>3__sourceLength;\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<System.ValueTuple`2<System.Int32, System.Int32>>)+30]) = this.<>3__moldRandomization;\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<System.ValueTuple`2<System.Int32, System.Int32>>)+28]) = this.<>3__baseSeed;\n\treturn returnVal1;\n")]
			IEnumerator<(int, int)> IEnumerable<(int, int)>.GetEnumerator()
			{
				IEnumerator<(int, int)> result;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						result = this;
						goto IL_00b5;
					}
				}
				_003CBuildSwapSchedule_003Ed__1 _003CBuildSwapSchedule_003Ed__2 = (_003CBuildSwapSchedule_003Ed__1)FormatterServices.GetUninitializedObject(typeof(_003CBuildSwapSchedule_003Ed__1));
				_003CBuildSwapSchedule_003Ed__2._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CBuildSwapSchedule_003Ed__2._003C_003El__initialThreadId = currentManagedThreadId2;
				result = _003CBuildSwapSchedule_003Ed__2;
				goto IL_00b5;
				IL_00b5:
				_ = _003C_003E3__budget;
				_ = _003C_003E3__sourceLength;
				_ = _003C_003E3__moldRandomization;
				_ = _003C_003E3__baseSeed;
				return result;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000DB")]
			[Address(RVA = "0x3C1A7E8", Offset = "0x3C1A7E8", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\treturnVal1 = this;\n\tgoto L_003E;\nL_0033:\n\tv76 = new _game.Tools.AlgorithmicLevelGenerator.Generator.MoldLayoutPermutator+<BuildSwapSchedule>d__1();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\treturnVal1 = v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\nL_003E:\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+20]) = this.<>3__budget;\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+38]) = this.<>3__sourceLength;\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+30]) = this.<>3__moldRandomization;\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+28]) = this.<>3__baseSeed;\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				IEnumerator result;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						result = this;
						goto IL_00b5;
					}
				}
				_003CBuildSwapSchedule_003Ed__1 _003CBuildSwapSchedule_003Ed__2 = (_003CBuildSwapSchedule_003Ed__1)FormatterServices.GetUninitializedObject(typeof(_003CBuildSwapSchedule_003Ed__1));
				_003CBuildSwapSchedule_003Ed__2._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CBuildSwapSchedule_003Ed__2._003C_003El__initialThreadId = currentManagedThreadId2;
				result = _003CBuildSwapSchedule_003Ed__2;
				goto IL_00b5;
				IL_00b5:
				_ = _003C_003E3__budget;
				_ = _003C_003E3__sourceLength;
				_ = _003C_003E3__moldRandomization;
				_ = _003C_003E3__baseSeed;
				return result;
			}
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x3C1A1B0", Offset = "0x3C1A1B0", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv58 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::ToArray(v46);\n\tv136 = swapCount < 1;\n\tif (v136) goto L_0097;\n\tv68 = v58.Length < 2;\n\tif (v68) goto L_0097;\n\tv107 = new System.Random();\n\tSystem.Random::.ctor(v107, seed);\n\tv63 = v58 + 0x20;\n\tv119 = swapCount;\n\tgoto L_005E;\nL_0052:\n\tv192 = v119 == 1;\n\tv119 = v119 - 1;\n\tif (v192) goto L_0097;\nL_005E:\n\tv228 = System.Random::Next(v107, v58.Length);\n\tv198 = System.Random::Next(v107, v58.Length);\n\tv235 = v228 == v198;\n\tif (v235) goto L_0052;\n\t*([v63 @ X23_v4+v228 @ X0_v12 (System.Int32)*4]) = *([v63 @ X23_v4+v198 @ X0_v14 (System.Int32)*4]);\n\t*([v63 @ X23_v4+v198 @ X0_v14 (System.Int32)*4]) = *([v63 @ X23_v4+v228 @ X0_v12 (System.Int32)*4]);\n\tgoto L_0052;\nL_0097:\n\treturnVal2 = System.Linq.Enumerable::ToList(v58);\n\treturn returnVal2;\n")]
		public static List<SolverColor> PartialSwap(List<SolverColor> source, int swapCount, int seed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLayoutPermutator::PartialSwap");
			return default;
		}

		[IteratorStateMachine(typeof(_003CBuildSwapSchedule_003Ed__1))]
		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x3C1A2FC", Offset = "0x3C1A2FC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv56.<>l__initialThreadId = v61;\n\tv56.<>3__budget = budget;\n\tv56.<>3__sourceLength = sourceLength;\n\tv56.<>3__moldRandomization = moldRandomization;\n\tv56.<>3__baseSeed = baseSeed;\n\treturn v56;\nL_001E:\n\tv56 = new _game.Tools.AlgorithmicLevelGenerator.Generator.MoldLayoutPermutator+<BuildSwapSchedule>d__1();\n\tSystem.Object::.ctor(v56);\n\tv56.<>1__state = -2;\n\tv61 = System.Environment::get_CurrentManagedThreadId();\n")]
		public static IEnumerable<(int, int)> BuildSwapSchedule(int budget, int sourceLength, float moldRandomization, int baseSeed)
		{
			_003CBuildSwapSchedule_003Ed__1 _003CBuildSwapSchedule_003Ed__2 = new _003CBuildSwapSchedule_003Ed__1(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CBuildSwapSchedule_003Ed__2._003C_003El__initialThreadId = currentManagedThreadId;
			_003CBuildSwapSchedule_003Ed__2._003C_003E3__budget = budget;
			_003CBuildSwapSchedule_003Ed__2._003C_003E3__sourceLength = sourceLength;
			_003CBuildSwapSchedule_003Ed__2._003C_003E3__moldRandomization = moldRandomization;
			_003CBuildSwapSchedule_003Ed__2._003C_003E3__baseSeed = baseSeed;
			return _003CBuildSwapSchedule_003Ed__2;
		}
	}
}
