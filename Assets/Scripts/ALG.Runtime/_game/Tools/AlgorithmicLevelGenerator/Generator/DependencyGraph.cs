using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000043")]
	public class DependencyGraph
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000044")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000131")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000132")]
			public static Func<KeyValuePair<(int Col, int Row), int>, (int Col, int Row)> _003C_003E9__5_1;

			[Token(Token = "0x4000133")]
			public static Func<KeyValuePair<(int Col, int Row), int>, int> _003C_003E9__6_0;

			[Token(Token = "0x4000134")]
			public static Func<KeyValuePair<(int Col, int Row), int>, int> _003C_003E9__6_1;

			[Token(Token = "0x4000135")]
			public static Func<KeyValuePair<(int Col, int Row), int>, int> _003C_003E9__6_2;

			[Token(Token = "0x4000136")]
			public static Func<KeyValuePair<(int Col, int Row), int>, (int Col, int Row)> _003C_003E9__6_3;

			[Token(Token = "0x4000137")]
			public static Func<CubeSlot, (int Col, int Row)> _003C_003E9__7_0;

			[Token(Token = "0x60000B9")]
			[Address(RVA = "0x3C1974C", Offset = "0x3C1974C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000BA")]
			[Address(RVA = "0x3C197B0", Offset = "0x3C197B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal (int, int) _003CCubesInLayer_003Eb__5_1(KeyValuePair<(int Col, int Row), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph._003C_003Ec::_003CCubesInLayer_003Eb__5_1");
				return default;
			}

			internal int _003CTopologicallyOrdered_003Eb__6_0(KeyValuePair<(int Col, int Row), int> kv)
			{
				int result = default(int);
				return result;
			}

			internal int _003CTopologicallyOrdered_003Eb__6_1(KeyValuePair<(int Col, int Row), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph._003C_003Ec::_003CTopologicallyOrdered_003Eb__6_1");
				return default;
			}

			internal int _003CTopologicallyOrdered_003Eb__6_2(KeyValuePair<(int Col, int Row), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph._003C_003Ec::_003CTopologicallyOrdered_003Eb__6_2");
				return default;
			}

			internal (int, int) _003CTopologicallyOrdered_003Eb__6_3(KeyValuePair<(int Col, int Row), int> kv)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph._003C_003Ec::_003CTopologicallyOrdered_003Eb__6_3");
				return default;
			}

			internal (int, int) _003CCompute_003Eb__7_0(CubeSlot c)
			{
				return (c.Col, c.Row);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000046")]
		private sealed class _003C_003Ec__DisplayClass7_0
		{
			[Token(Token = "0x4000139")]
			[FieldOffset(Offset = "0x10")]
			public Template t;

			[Token(Token = "0x400013A")]
			[FieldOffset(Offset = "0x18")]
			public Dictionary<(int Col, int Row), CubeSlot> cubes;

			[Token(Token = "0x400013B")]
			[FieldOffset(Offset = "0x20")]
			public HashSet<(int Col, int Row)> unassigned;

			[Token(Token = "0x400013C")]
			[FieldOffset(Offset = "0x28")]
			public HashSet<(int Col, int Row)> tunnelCells;

			[Token(Token = "0x400013D")]
			[FieldOffset(Offset = "0x30")]
			public Dictionary<SolverColor, (int Col, int Row)> keyOwners;

			[Token(Token = "0x400013E")]
			[FieldOffset(Offset = "0x38")]
			public int currentLayer;

			[Token(Token = "0x400013F")]
			[FieldOffset(Offset = "0x40")]
			public DependencyGraph g;

			[Token(Token = "0x4000140")]
			[FieldOffset(Offset = "0x48")]
			public Func<(int Col, int Row), string> _003C_003E9__1;

			[Token(Token = "0x60000C3")]
			[Address(RVA = "0x3C18670", Offset = "0x3C18670", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass7_0()
			{
			}

			internal string _003CCompute_003Eb__1((int Col, int Row) p)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph._003C_003Ec__DisplayClass7_0::_003CCompute_003Eb__1");
				return default;
			}
		}

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Dictionary<(int Col, int Row), int> _layer;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x18")]
		private int _maxLayer;

		[Token(Token = "0x17000004")]
		public int MaxLayer
		{
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0x3C175AC", Offset = "0x3C175AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MaxLayer;\n")]
			get
			{
				return _maxLayer;
			}
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x3C16840", Offset = "0x3C16840", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv54 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>::TryGetValue(this._layer, v40, &v53 @ stack_-34_v2 (System.Int32));\n\tv61 = v54 == 0;\n\tv66 = ~v61;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = v53;\n\tgoto L_0037;\nL_FFFFFFFF:\n\treturnVal2 = -1;\nL_0037:\n\treturn returnVal2;\n")]
		public int LayerOf((int Col, int Row) pos)
		{
			(int, int) key = default((int, int));
			if (_layer.TryGetValue(key, out var value))
			{
				return value;
			}
			return -1;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x3C175B4", Offset = "0x3C175B4", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv51.layer = layer;\n\tv74 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Boolean>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Boolean>::.ctor(v74, v51, Il2CppMethodInfo);\n\tv89 = System.Linq.Enumerable::Where(this._layer, v74);\n\tgoto L_0050;\nL_0050:\n\t;\n\tv155 = v132.<>9__5_1;\n\tv134 = v132.<>9__5_1 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0085;\n\tgoto L_0063;\nL_0063:\n\tgoto L_006B;\nL_0085:\n\treturnVal2 = System.Linq.Enumerable::Select(v89, v155);\n\treturn returnVal2;\nL_002F:\n\tv51 = new _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v51);\nL_006B:\n\tv173 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v173, v168.<>9, Il2CppMethodInfo);\n\tv178.<>9__5_1 = v173;\n\tv155 = v173;\n")]
		public IEnumerable<(int, int)> CubesInLayer(int layer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph::CubesInLayer");
			return default;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x3C17780", Offset = "0x3C17780", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_0018;\nL_0018:\n\t;\n\tv93 = v58.<>9__6_0;\n\tv60 = v58.<>9__6_0 == 0;\n\tv61 = ~v60;\n\tv96 = this._layer;\n\tif (v61) goto L_006D;\n\tgoto L_0054;\nL_0054:\n\tgoto L_005C;\nL_006D:\n\tv101 = System.Linq.Enumerable::OrderBy(v96, v93);\n\tgoto L_0074;\nL_0074:\n\t;\n\tv163 = v129.<>9__6_1;\n\tv131 = v129.<>9__6_1 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_00A0;\n\tgoto L_0087;\nL_0087:\n\tgoto L_008F;\nL_00A0:\n\tv169 = System.Linq.Enumerable::ThenBy(v101, v163);\n\tgoto L_00A7;\nL_00A7:\n\tv228 = v197.<>9__6_2;\n\tv199 = v197.<>9__6_2 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_00CF;\n\tgoto L_00B6;\nL_00B6:\n\tgoto L_00BE;\nL_00CF:\n\tv234 = System.Linq.Enumerable::ThenBy(v169, v228);\n\tgoto L_00DD;\n\tgoto L_00EC;\nL_00FD:\n\tv302 = System.Linq.Enumerable::Select(v234, v297);\n\treturnVal1 = System.Linq.Enumerable::ToList(v302);\n\treturn returnVal1;\nL_005C:\n\tv126 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Int32>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Int32>::.ctor(v126, v121.<>9, Il2CppMethodInfo);\n\tv175.<>9__6_0 = v126;\n\tv93 = v126;\n\tv96 = this._layer;\nL_008F:\n\tv196 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Int32>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Int32>::.ctor(v196, v191.<>9, Il2CppMethodInfo);\n\tv239.<>9__6_1 = v196;\n\tv163 = v196;\nL_00BE:\n\tv261 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Int32>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Int32>::.ctor(v261, v256.<>9, Il2CppMethodInfo);\n\tv305.<>9__6_2 = v261;\n\tv228 = v261;\nL_00DD:\n\tv297 = v269.<>9__6_3;\n\tv271 = v269.<>9__6_3 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_00FD;\nL_00EC:\n\tv314 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v314, v309.<>9, Il2CppMethodInfo);\n\tv329.<>9__6_3 = v314;\n\tv297 = v314;\n")]
		public List<(int, int)> TopologicallyOrdered()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph::TopologicallyOrdered");
			return default;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x3C17AF0", Offset = "0x3C17AF0", Length = "0xB80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_008F;\n\tv70.t = t;\n\tv367 = new _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph();\n\tgoto L_00BE;\n\tv367.MaxLayer = -1;\n\tSystem.Object::.ctor(v367);\n\tv361 = v70 + 0x40;\n\tv70.g = v367;\n\tv344 = v70.t;\n\tgoto L_00DD;\nL_00DD:\n\tv735 = 0xB2C8000 + 0x4C0;\n\tv293 = v720.<>9__7_0;\n\tv722 = v720.<>9__7_0 == 0;\n\tv723 = ~v722;\n\tif (v723) goto L_0109;\n\tgoto L_00F0;\nL_00F0:\n\tgoto L_00F8;\nL_0109:\n\tv752 = System.Linq.Enumerable::ToDictionary /* +1 sharing this address */(v344.CubeSlots, v293, *([v735 @ X25_v13 (System.Int32)]));\n\tv70.cubes = v752;\n\tv823 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::get_Keys(v70.cubes);\n\tv833 = new System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v833, v823);\n\tv358 = v70 + 0x20;\n\tv70.unassigned = v833;\n\tv864 = new System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v864);\n\tv70.tunnelCells = v864;\n\tv346 = v70.t;\n\tv903 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.TunnelSlot>::GetEnumerator(v346.TunnelSlots);\n\tv214 = v241.Current;\n\tv197 = v241._list;\nL_FFFFFFFF:\n\t;\n\tv584 = v241.Current == 0;\n\tif (v584) goto L_02EF;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v512 @ stack_-100_v12 (System.ValueTuple`2<System.Int32, System.Int32>), *([v214 @ stack_-E8_v10+10]), *([v214 @ stack_-E8_v10+14]));\n\tv585 = v70.tunnelCells == 0;\n\tif (v585) goto L_02F1;\n\tv955 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Add(v70.tunnelCells, v512);\nL_FFFFFFFF:\n\t;\n\tgoto L_0159;\nL_0176:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v197 @ stack_-80_v8 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>));\n\tv347 = v70.t;\n\tv1074 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::GetEnumerator(v347.CubeSlots);\n\tv402 = v1074.Current;\n\tv392 = v1074._list;\n\tv431 = v1074.Current == 0;\n\tif (v431) goto L_02ED;\n\tv1110 = v402.HasKeySlot == 0;\n\tif (v1110) goto L_01A0;\n\tv1111 = v402.FrozenKeyColor == 0;\n\tif (v1111) goto L_01A0;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v512 @ stack_-100_v12 (System.ValueTuple`2<System.Int32, System.Int32>), v402.Col, v402.Row);\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.ValueTuple`2<System.Int32, System.Int32>>::set_Item(v70.keyOwners, v402.FrozenKeyColor, v512);\nL_FFFFFFFF:\n\t;\n\tgoto L_01A0;\nL_01C9:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v392 @ stack_-A0_v8 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>));\nL_FFFFFFFF:\n\tv241 = 0;\n\t*([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+38]) = 0;\n\tv348 = *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+10]);\n\tv275 = *([v348 @ X8_v13+20]);\n\tv913 = *([v358 @ X21_v7 (System.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Object>)]);\n\tv655 = *([v275 @ X9_v7+18]) + 2;\n\tv889 = v655 & v655;\n\tv890 = v889 - 1;\n\tv139 = v655 <= 0;\n\tif (v139) goto L_FFFFFFFF;\n\tv964 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v964);\n\tv655 = v655 - 1;\n\tv1002 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::GetEnumerator(*([v358 @ X21_v7 (System.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Object>)]));\n\tv135 = v241._list;\n\tgoto L_0218;\n\tv1039 = _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph::IsPourableAtLayer(v241.Current, *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+10]), *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+18]), *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+20]), *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+28]), *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+30]), *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+38]), *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+40]));\n\tv1043 = v1039 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v1043) goto L_0218;\n\tv1075 = v964 == 0;\n\tif (v1075) goto L_0290;\n\tv1088 = v964._version + 1;\n\tv964._version = v1088;\n\tv1042 = v964._items == 0;\n\tif (v1042) goto L_0290;\n\tgoto L_0248;\nL_0248:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::Add(v964, v241.Current);\nL_FFFFFFFF:\n\t;\n\tgoto L_0218;\nL_024E:\n\tSystem.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>+Enumerator<System.ValueTuple`2<System.Int32, System.Int32>>::Dispose(&v135 @ stack_-C0_v9 (System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>+Enumerator<System.ValueTuple`2<System.Int32, System.Int32>>));\n\tv1077 = v964.Count == 0;\n\tif (v1077) goto L_02F5;\n\tv1094 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::GetEnumerator(v964);\n\tv96 = v1094;\n\tv591 = *([v361 @ X20_v7 (_game.Tools.AlgorithmicLevelGenerator.Generator.TemplateInvalidException)]);\n\tv582 = *([v361 @ X20_v7 (_game.Tools.AlgorithmicLevelGenerator.Generator.TemplateInvalidException)]) == 0;\n\tif (v582) goto L_0294;\n\tv583 = *([v591 @ X8_v44 (Il2CppClass<_game.Tools.AlgorithmicLevelGenerator.Generator.TemplateInvalidException>)+10]) == 0;\n\tif (v583) goto L_0296;\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>::set_Item(*([v591 @ X8_v44 (Il2CppClass<_game.Tools.AlgorithmicLevelGenerator.Generator.TemplateInvalidException>)+10]), *([v1094 @ X0_v93 (System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>+Enumerator<System.ValueTuple`2<System.Int32, System.Int32>>)+10]), *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+38]));\n\tv581 = *([v358 @ X21_v7 (System.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Object>)]) == 0;\n\tif (v581) goto L_0292;\n\tv1132 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Remove(*([v358 @ X21_v7 (System.Func`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Object>)]), *([v1094 @ X0_v93 (System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>+Enumerator<System.ValueTuple`2<System.Int32, System.Int32>>)+10]));\n\tgoto L_0267;\nL_0283:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>+Enumerator<System.ValueTuple`2<System.Int32, System.Int32>>::Dispose(&v96 @ stack_-E0_v9 (System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>+Enumerator<System.ValueTuple`2<System.Int32, System.Int32>>));\n\tv352 = *([v361 @ X20_v7 (_game.Tools.AlgorithmicLevelGenerator.Generator.TemplateInvalidException)]);\n\t*([v352 @ X8_v41 (Il2CppClass<_game.Tools.AlgorithmicLevelGenerator.Generator.TemplateInvalidException>)+18]) = *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+38]);\n\tv1185 = *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+38]) + 1;\n\t*([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass7_0)+38]) = v1185;\n\tv913 = *([v70 @ X0_v3 (_game.Tools.AlgorithmicLevelGenerator.Gener\n// ... truncated")]
		public unsafe static DependencyGraph Compute(Template t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph::Compute");
			return default;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x3C1870C", Offset = "0x3C1870C", Length = "0x60C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tv68.currentLayer = currentLayer;\n\tv243 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::get_Item(cubes, pos);\n\tv137 = v243.HasLockSlot != 1;\n\tif (v137) goto L_00C2;\n\tv480 = v243.FrozenLockColor == 0;\n\tif (v480) goto L_00C2;\n\treturnVal2 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.ValueTuple`2<System.Int32, System.Int32>>::TryGetValue(keyOwners, v243.FrozenLockColor, &v125 @ stack_-68_v7 (System.ValueTuple`2<System.Int32, System.Int32>));\n\tv616 = ~returnVal2;\n\tif (v616) goto L_0250;\n\tv245 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(stillUnassigned, v125);\n\tv795 = v245 == 0;\n\tv796 = ~v795;\n\tif (v796) goto L_FFFFFFFF;\n\tgoto L_0096;\nL_0096:\n\tv507 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>::TryGetValue(g._layer, v125, &v483 @ stack_-80_v13 (System.Int32));\n\tv813 = v507 == 0;\n\tv803 = ~v813;\n\tv482 = ~v803;\n\tif (v482) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv511 = v483;\n\tgoto L_00A8;\nL_FFFFFFFF:\n\tv511 = -1;\n\tv486 = v511 >= v68.currentLayer;\n\tif (v486) goto L_FFFFFFFF;\nL_00C2:\n\tv523 = v243.CoverGroupId != 1;\nL_FFFFFFFF:\n\tv299 = stillUnassigned;\nL_FFFFFFFF:\n\tv303 = tunnelCells;\n\tif (v523) goto L_0117;\n\tv306 = v243 + 0x40;\n\tv538 = v306.HasValue != 1;\nL_FFFFFFFF:\n\tv299 = stillUnassigned;\nL_FFFFFFFF:\n\tv303 = tunnelCells;\n\tif (v538) goto L_0117;\n\tv246 = System.Nullable`1<System.Int32>::get_Value(&v243.FrozenCoverCounter (System.Nullable`1<System.Int32>));\n\tv138 = v246 < 1;\nL_FFFFFFFF:\n\tv299 = stillUnassigned;\nL_FFFFFFFF:\n\tv303 = tunnelCells;\n\tif (v138) goto L_0117;\n\tv791 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Boolean>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Boolean>::.ctor(v791, v68, Il2CppMethodInfo);\n\tv827 = System.Linq.Enumerable::Count(g._layer, v791);\n\tv564 = System.Nullable`1<System.Int32>::get_Value(&v243.FrozenCoverCounter (System.Nullable`1<System.Int32>));\n\tv542 = v827 < v564;\nL_FFFFFFFF:\n\tv299 = stillUnassigned;\nL_FFFFFFFF:\n\tv303 = tunnelCells;\n\tif (v542) goto L_FFFFFFFF;\nL_0117:\n\tv139 = v243.FrozenSnakeId != 1;\n\tif (v139) goto L_0175;\n\tv581 = v243.FrozenSnakeNextCol & 0x80000000;\n\tv582 = v581 == 0;\n\tv583 = ~v582;\n\tif (v583) goto L_0175;\n\tv619 = v243.FrozenSnakeNextRow & 0x80000000;\n\tv620 = v619 == 0;\n\tv608 = ~v620;\n\tif (v608) goto L_0175;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v100 @ stack_-70_v7 (System.ValueTuple`2<System.Int32, System.Int32>), v243.FrozenSnakeNextCol, v243.FrozenSnakeNextRow);\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::ContainsKey(cubes, v100);\n\tv756 = ~returnVal2;\n\tif (v756) goto L_0250;\n\tv248 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(v299, v100);\n\tv847 = v248 == 0;\n\tv822 = ~v847;\n\tif (v822) goto L_FFFFFFFF;\n\tgoto L_0153;\nL_0153:\n\tv605 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>::TryGetValue(g._layer, v100, &v587 @ stack_-80_v11 (System.Int32));\n\tv814 = v605 == 0;\n\tv804 = ~v814;\n\tv585 = ~v804;\n\tif (v585) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv611 = v587;\n\tgoto L_0165;\nL_FFFFFFFF:\n\tv611 = -1;\n\tv590 = v611 >= v68.currentLayer;\n\tif (v590) goto L_FFFFFFFF;\nL_0175:\n\tv276 = pos >> 0x20;\n\tv612 = v276 == 0;\n\tif (v612) goto L_FFFFFFFF;\n\t// 380 NewArr v624 @ X0_v19 (System.ValueTuple`2<System.Int32, System.Int32>[]), typeof(System.ValueTuple`2<System.Int32, System.Int32>[]), 4\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v121 @ stack_-80_v9 (System.ValueTuple`2<System.Int32, System.Int32>), -1, 0);\n\tv313 = v624 + 0x20;\n\t*([v313 @ X26_v11]) = v121;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v98 @ stack_-88_v7 (System.ValueTuple`2<System.Int32, System.Int32>), 1, 0);\n\t*([v624 @ X0_v19 (System.ValueTuple`2<System.Int32, System.Int32>[])+28]) = v98;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v95 @ stack_-90_v7 (System.ValueTuple`2<System.Int32, System.Int32>), 0, -1);\n\t*([v624 @ X0_v19 (System.ValueTuple`2<System.Int32, System.Int32>[])+30]) = v95;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v92 @ stack_-98_v7 (System.ValueTuple`2<System.Int32, System.Int32>), 0, 1);\n\t*([v624 @ X0_v19 (System.ValueTuple`2<System.Int32, System.Int32>[])+38]) = v92;\n\tv142 = v624.Length < 1;\n\tif (v142) goto L_FFFFFFFF;\n\tv878 = t == 0;\n\tif (v878) goto L_023B;\n\tv881 = v303 == 0;\n\tif (v881) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv308 = 0;\n\tgoto L_01E6;\nL_01D9:\n\tv308 = v308 + 1;\n\tv722 = v308 >= v624.Length;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tif (v722) goto L_0250;\nL_01E6:\n\tv88 = v308 << 3;\n\tv900 = v313 + v88;\n\tv901 = *([v900 @ X8_v34]);\n\tv237 = *([v900 @ X8_v34]) + pos;\n\tv224 = *([v901 @ X8_v35+4]) + v276;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v84 @ stack_-78_v6 (System.ValueTuple`2<System.Int32, System.Int32>), v237, v224);\n\tv913 = v84 & 0x80000000;\n\tv914 = v913 == 0;\n\tv693 = ~v914;\n\tif (v693) goto L_FFFFFFFF;\n\tv640 = v84 >= t.GridCols;\n\tif (v640) goto L_FFFFFFFF;\n\tv920 = v919 & 0x80000000;\n\tv921 = v920 == 0;\n\tv694 = ~v921;\n\tif (v694) goto L_FFFFFFFF;\n\tv141 = v919 >= t.GridRows;\n\tif (v141) goto L_FFFFFFFF;\n\tv928 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(t.Walls, v84);\n\tv930 = v928 == 0;\n\tv931 = ~v930;\n\tif (v931) goto L_01D9;\n\tv935 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(v303, v84);\n\tv943 = v935 == 0;\n\tv937 = ~v943;\n\tif (v937) goto L_01D9;\n\tv689 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::ContainsKey(cubes, v84);\n\tv695 = ~v689;\n\tif (v695) goto L_FFFFFFFF;\n\tv690 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(v299, v84);\n\tv946 = ~v690;\n\tv696 = ~v946;\n\tif (v696) goto L_01D9;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_0250;\nL_023B:\n\tv239 = *([v313 @ X26_v11]) + pos;\n\tv226 = *([v313 @ X26_v11+4]) + v276;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v84 @ stack_-78_v6 (System.ValueTuple`2<System.Int32, System.Int32>), v239, v226);\nL_FFFFFFFF:\n\treturnVal2 = 1;\nL_FFFFFFFF:\n\tv301 = 0;\n\tv642 = v84 >= t.GridCols;\n\tif (v642) goto L_FFFFFFFF;\n\tv922 = v919 & 0x80000000;\n\tv923 = v922 == 0;\n\tv698 = ~v923;\n\tif (v698) goto L_FFFFFFFF;\n\tv143 = v919 >= t.GridRows;\n\tif (v143) goto L_FFFFFFFF;\n\tv254 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(t.Walls, v84);\n\tv301 = v301 + 1;\n\tv724 = v301 < v624.Length;\n\tif (v724) goto L_0254;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_0250;\nL_0048:\n\tv68 = new _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v68);\nL_0250:\n\treturn returnVal2;\nL_00A8:\n\tv869 = v511 & 0x80000000;\n\tv870 = v869 == 0;\n\tv509 = ~v870;\n\tif (v509) goto L_FFFFFFFF;\nL_0165:\n\tv883 = v611 & 0x80000000;\n\tv884 = v883 == 0;\n\tv607 = ~v884;\n\tif (v607) goto L_FFFFFFFF;\nL_0254:\n\tv89 = v301 << 3;\n\tv911 = v313 + v89;\n\tv912 = *([v911 @ X8_v28]);\n\tv240 = *([v911 @ X8_v28]) + pos;\n\tv227 = *([v912 @ X8_v29+4]) + v276;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v84 @ stack_-78_v6 (System.ValueTuple`2<System.Int32, System.Int32>), v240, v227);\n\tv915 = v84 & 0x80000000;\n\tv916 = v915 == 0;\n\tv697 = ~v916;\n\tif (v697) goto L_FFFFFFFF;\n")]
		private static bool IsPourableAtLayer((int Col, int Row) pos, Template t, Dictionary<(int Col, int Row), CubeSlot> cubes, HashSet<(int Col, int Row)> stillUnassigned, HashSet<(int Col, int Row)> tunnelCells, Dictionary<SolverColor, (int Col, int Row)> keyOwners, int currentLayer, DependencyGraph g)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph::IsPourableAtLayer");
			return default;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x3C18D8C", Offset = "0x3C18D8C", Length = "0x9B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_008D;\n\tv68.currentLayer = currentLayer;\n\tv251 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::get_Item(cubes, pos);\n\tv155 = v251.HasLockSlot != 1;\n\tif (v155) goto L_00EB;\n\tv512 = v251.FrozenLockColor == 0;\n\tif (v512) goto L_00EB;\n\tv252 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.ValueTuple`2<System.Int32, System.Int32>>::TryGetValue(keyOwners, v251.FrozenLockColor, &v143 @ stack_-68_v6 (System.ValueTuple`2<System.Int32, System.Int32>));\n\tv611 = v252 == 0;\n\tif (v611) goto L_0301;\n\tv517 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(stillUnassigned, v143);\n\tv519 = ~v517;\n\tif (v519) goto L_00EB;\n\tv626 = v251.FrozenLockColor;\n\t// 201 Box v818 @ X0_v108 (System.Object), typeof(_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor), &v626 @ stack_-90_v17 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor)\n\tv730 = v143;\n\tv779 = 0xB7D5000 + 0x538;\n\tv837 = \"il2cpp_vm_object_box\"(*([v779 @ X21_v17 (System.Int32)+48]), &v730 @ stack_-A0_v17 (System.ValueTuple`2<System.Int32, System.Int32>), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv728 = v852;\n\tv855 = \"il2cpp_vm_object_box\"(*([v779 @ X21_v17 (System.Int32)+48]), &v728 @ stack_-B0_v7, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = System.String::Format(\"locked({0}):key-at({1},{2})-unassigned\", v818, v837, v855);\n\tgoto L_0340;\nL_00EB:\n\tv532 = v251.CoverGroupId != 1;\n\tv308 = stillUnassigned;\n\tif (v532) goto L_014E;\n\tv311 = v251 + 0x40;\n\tv546 = v311.HasValue != 1;\n\tv308 = stillUnassigned;\n\tif (v546) goto L_014E;\n\tv253 = System.Nullable`1<System.Int32>::get_Value(&v251.FrozenCoverCounter (System.Nullable`1<System.Int32>));\n\tv156 = v253 < 1;\n\tv308 = stillUnassigned;\n\tif (v156) goto L_014E;\n\tv717 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Boolean>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>, System.Boolean>::.ctor(v717, v68, Il2CppMethodInfo);\n\tv822 = System.Linq.Enumerable::Count(g._layer, v717);\n\tv572 = System.Nullable`1<System.Int32>::get_Value(&v251.FrozenCoverCounter (System.Nullable`1<System.Int32>));\n\tv550 = v822 >= v572;\n\tv308 = stillUnassigned;\n\tif (v550) goto L_014E;\n\tv871 = System.Nullable`1<System.Int32>::get_Value(&v251.FrozenCoverCounter (System.Nullable`1<System.Int32>));\n\tv881 = v871;\n\tv891 = 0xB7D5000 + 0x538;\n\tv906 = \"il2cpp_vm_object_box\"(*([v891 @ X20_v25 (System.Int32)+48]), &v881 @ stack_-90_v16 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv879 = v822;\n\tv889 = \"il2cpp_vm_object_box\"(*([v891 @ X20_v25 (System.Int32)+48]), &v879 @ stack_-A0_v16 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv774 = 0xB309000 + 0x1B0;\n\tv756 = v889;\n\tv782 = v906;\n\tgoto L_0332;\nL_014E:\n\tv157 = v251.FrozenSnakeId != 1;\n\tif (v157) goto L_0184;\n\tv589 = v251.FrozenSnakeNextCol & 0x80000000;\n\tv590 = v589 == 0;\n\tv591 = ~v590;\n\tif (v591) goto L_0184;\n\tv614 = v251.FrozenSnakeNextRow & 0x80000000;\n\tv615 = v614 == 0;\n\tv601 = ~v615;\n\tif (v601) goto L_0184;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v122 @ stack_-70_v7 (System.ValueTuple`2<System.Int32, System.Int32>), v251.FrozenSnakeNextCol, v251.FrozenSnakeNextRow);\n\tv254 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::ContainsKey(cubes, v122);\n\tv806 = v254 == 0;\n\tif (v806) goto L_0320;\n\tv599 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(v308, v122);\n\tv602 = ~v599;\n\tif (v602) goto L_0184;\n\tv873 = v122;\n\tv875 = 0xB7D5000 + 0x538;\n\tv878 = \"il2cpp_vm_object_box\"(*([v875 @ X20_v21 (System.Int32)+48]), &v873 @ stack_-90_v15 (System.ValueTuple`2<System.Int32, System.Int32>), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv730 = v843;\n\tv890 = \"il2cpp_vm_object_box\"(*([v875 @ X20_v21 (System.Int32)+48]), &v730 @ stack_-A0_v17 (System.ValueTuple`2<System.Int32, System.Int32>), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv774 = 0xB310000 + 0x420;\n\tv756 = v890;\n\tv782 = v878;\n\tgoto L_0332;\nL_0184:\n\tv309 = pos >> 0x20;\n\tv605 = v309 == 0;\n\tv606 = ~v605;\n\tif (v606) goto L_018E;\n\tv690 = 0xB311000 + 0xDA8;\n\tgoto L_031D;\nL_018E:\n\tv621 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v621);\n\t// 408 NewArr v796 @ X0_v22 (System.ValueTuple`3<System.String, System.Int32, System.Int32>[]), typeof(System.ValueTuple`3<System.String, System.Int32, System.Int32>[]), 4\n\tSystem.ValueTuple`3<System.Object, System.Int32, System.Int32>::.ctor(&v626 @ stack_-90_v17 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor), \"L\", -1, 0);\n\tv407 = v796 + 0x20;\n\t*([v407 @ X26_v9]) = v626;\n\tSystem.ValueTuple`3<System.Object, System.Int32, System.Int32>::.ctor(&v730 @ stack_-A0_v17 (System.ValueTuple`2<System.Int32, System.Int32>), \"R\", 1, 0);\n\tv408 = v796 + 0x30;\n\t*([v408 @ X26_v11]) = v730;\n\tSystem.ValueTuple`3<System.Object, System.Int32, System.Int32>::.ctor(&v728 @ stack_-B0_v7, \"D\", 0, -1);\n\tv409 = v796 + 0x40;\n\t*([v409 @ X26_v13]) = v728;\n\tSystem.ValueTuple`3<System.Object, System.Int32, System.Int32>::.ctor(&v106 @ stack_-C0_v6, \"U\", 0, 1);\n\tv317 = v796 + 0x50;\n\t*([v317 @ X26_v15]) = v106;\n\tv159 = *([v317 @ X26_v15-38]) < 1;\n\tif (v159) goto L_02F5;\n\tv962 = t == 0;\n\tif (v962) goto L_0314;\n\tv286 = v796 + 0x28;\n\tv1004 = tunnelCells;\n\tv306 = 0;\n\tgoto L_0225;\nL_0216:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v621, v1002);\n\tv286 = v286 + 0x10;\n\tv306 = v306 + 1;\n\tv980 = v306 >= v796.Length;\n\tif (v980) goto L_02F5;\nL_0225:\n\t;\n\tv237 = *([v286 @ X20_v15]) + pos;\n\tv222 = *([v286 @ X20_v15+4]) + v309;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v90 @ stack_-78_v8 (System.ValueTuple`2<System.Int32, System.Int32>), v237, v222);\n\tv1065 = v90 & 0x80000000;\n\tv1066 = v1065 == 0;\n\tv1067 = ~v1066;\n\tif (v1067) goto L_031C;\n\tv1069 = v90 >= t.GridCols;\n\tif (v1069) goto L_031C;\n\tv1089 = v1088 & 0x80000000;\n\tv1090 = v1089 == 0;\n\tv1078 = ~v1090;\n\tif (v1078) goto L_031C;\n\tv158 = v1088 >= t.GridRows;\n\tif (v158) goto L_031C;\n\tv258 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(t.Walls, v90);\n\tv1098 = ~v258;\n\tif (v1098) goto L_026C;\n\tv263 = System.String::Concat(*([v286 @ X20_v15-8]), \"=wall\");\n\tv1101 = v621 == 0;\n\tv273 = ~v1101;\n\tif (v273) goto L_02C8;\n\tgoto L_0341;\nL_026C:\n\tv1107 = System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::Contains(v1004, v90);\n\tv1114 = ~v1107;\n\tif (v1114) goto L_027E;\n\tv263 = System.String::Concat(*([v286 @ X20_v15-8]), \"=tunnel\");\n\tv1170 = v621 == 0;\n\tv275 = ~v1170;\n\tif (v275) goto L_02C8;\n\tgoto L_0341;\nL_027E:\n\tv1131 = System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, _game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::ContainsKey(cubes, v90);\n\tv1171 = ~v1131;\n\tif (v1171) goto L_02C\n// ... truncated")]
		private unsafe static string DiagnoseBlocker((int Col, int Row) pos, Template t, Dictionary<(int Col, int Row), CubeSlot> cubes, HashSet<(int Col, int Row)> stillUnassigned, HashSet<(int Col, int Row)> tunnelCells, Dictionary<SolverColor, (int Col, int Row)> keyOwners, int currentLayer, DependencyGraph g)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DependencyGraph::DiagnoseBlocker");
			return default;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x3C18678", Offset = "0x3C18678", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tthis.MaxLayer = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.ValueTuple`2<System.Int32, System.Int32>, System.Int32>::.ctor(v48);\n\tthis._layer = v48;\n")]
		public DependencyGraph()
		{
			Dictionary<(int, int), int> layer = new Dictionary<(int, int), int>();
			_layer = layer;
			_maxLayer = -1;
		}
	}
}
