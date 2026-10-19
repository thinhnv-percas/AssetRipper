using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime
{
	[Serializable]
	[Token(Token = "0x2000006")]
	public struct GridBounds
	{
		[SerializeField]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x0")]
		internal float3 m_alignment;

		[SerializeField]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0xC")]
		internal float3 m_constantOffset;

		[NonSerialized]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x18")]
		public int3 Min;

		[NonSerialized]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x24")]
		public int3 Max;

		[Token(Token = "0x17000007")]
		public int3 Size
		{
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x3F2D3EC", Offset = "0x3F2D3EC", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.Min & 0xFFFFFFFF00000000;\n\tv6 = this.Max - v5;\n\tv7 = this.Max - this.Min;\n\tv8 = v7 + 1;\n\tv11 = v6 & 0xFFFFFFFF00000000;\n\tv12 = v11 | v8;\n\treturnVal1 = v12 + 0x100000000;\n\treturn returnVal1;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::get_Size");
				return default;
			}
		}

		[Token(Token = "0x17000008")]
		public float3 Center
		{
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x3F2D428", Offset = "0x3F2D428", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.Min + this.Max;\n\treturn v6;\n")]
			get
			{
				return Min + Max;
			}
		}

		[Token(Token = "0x17000009")]
		public int3 Offset
		{
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x3F2D45C", Offset = "0x3F2D45C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.Min & 0xFFFFFFFF00000000;\n\tv4 = 0 - this.Min;\n\treturnVal1 = v4 - v3;\n\treturn returnVal1;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::get_Offset");
				return default;
			}
		}

		[Token(Token = "0x1700000A")]
		public float XAxis
		{
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x3F2D478", Offset = "0x3F2D478", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_alignment;\n")]
			get
			{
				return m_alignment.x;
			}
		}

		[Token(Token = "0x1700000B")]
		public float YAxis
		{
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x3F2D480", Offset = "0x3F2D480", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_alignment.y;\n")]
			get
			{
				return m_alignment.y;
			}
		}

		[Token(Token = "0x1700000C")]
		public float ZAxis
		{
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x3F2D488", Offset = "0x3F2D488", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_alignment.z;\n")]
			get
			{
				return m_alignment.z;
			}
		}

		[Token(Token = "0x1700000D")]
		public float3 ConstantOffset
		{
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x3F2D490", Offset = "0x3F2D490", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ConstantOffset;\n")]
			get
			{
				return m_constantOffset;
			}
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x3F2D49C", Offset = "0x3F2D49C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv106 = zAxis < 1f;\n\tv105 = zAxis == 1f;\n\tv93 = zAxis == zAxis;\n\tv94 = 1f == 1f;\n\tv95 = v93 & v94;\n\tv101 = ~v95;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv101 = 0;\nL_FFFFFFFF:\n\tv105 = 0;\nL_FFFFFFFF:\n\tv106 = 0;\nL_FFFFFFFF:\n\tv124 = zAxis;\n\tgoto L_0059;\nL_FFFFFFFF:\n\tv124 = 1f;\nL_FFFFFFFF:\n\tv124 = 0;\n\tgoto L_0066;\nL_0025:\n\t// 37 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 39 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 42 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 43 NotImplemented \"Instruction CMHI not yet implemented.\"\n\t// 46 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 47 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv74 = v55 & -1;\n\tthis.m_alignment = v74;\n\tv76 = zAxis & 0x7FFFFFFF;\n\tv77 = v76 < 0x7F800001;\n\tv78 = ~v77;\n\tv87 = ~v78;\n\tv88 = ~v87;\n\tif (v88) goto L_FFFFFFFF;\nL_0050:\n\tv107 = v106 == v101;\n\tv108 = ~v107;\n\tv109 = v108 | v105;\n\tv110 = ~v109;\n\tif (v110) goto L_FFFFFFFF;\nL_0059:\n\tv114 = v124 < 0;\n\tv121 = ~v114;\n\tif (v121) goto L_0066;\nL_0066:\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+8]) = v124;\n\tthis.ConstantOffset = constantOffset;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+10]) = constantOffset.y;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+14]) = constantOffset.z;\n\tthis.Min = v126.zero;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = v126.zero.z;\n\tthis.Max = v129.zero;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+2C]) = v129.zero.z;\n\treturn;\n")]
		private GridBounds(float xAxis, float yAxis, float zAxis, float3 constantOffset = default(float3))
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::.ctor");
			this = default;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x3F2D5A4", Offset = "0x3F2D5A4", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_FFFFFFFF:\n\treturnVal2 = positions;\n\tgoto L_0016;\n\tv56 = v15 < 1;\n\tif (v56) goto L_FFFFFFFF;\n\tv64 = v15 & 0x7FFFFFFF;\n\tv65 = v64 < 7;\n\tv66 = ~v65;\n\tv67 = v64 - 7;\n\tv69 = v67 == 0;\n\tv74 = ~v69;\n\tv75 = v66 & v74;\n\tif (v75) goto L_004B;\nL_FFFFFFFF:\n\tv381 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv383 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv385 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv387 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv389 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv391 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv307 = 0;\n\tgoto L_00A9;\nL_003A:\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+10]) = 0;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = 0;\n\treturnBuffer.m_alignment = 0;\n\treturn returnBuffer;\nL_FFFFFFFF:\n\tv142 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv157 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv160 = 0x8000000080000000;\nL_FFFFFFFF:\n\tv193 = 0x7FFFFFFF7FFFFFFF;\n\tgoto L_012A;\nL_004B:\n\tv212 = v15 & 7;\n\tv307 = v64 - v212;\n\tv352 = positions + 0x30;\nL_FFFFFFFF:\n\tv350 = v307;\nL_FFFFFFFF:\n\tv350 = v153;\nL_FFFFFFFF:\n\tv352 = v156;\n\t// 148 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 149 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 151 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 152 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 154 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 155 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 157 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 158 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 160 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 161 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 163 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 164 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv329 = v212 == 0;\nL_FFFFFFFF:\n\tv381 = 0x80;\nL_FFFFFFFF:\n\tv383 = 0x80;\nL_FFFFFFFF:\n\tv385 = 0x80;\nL_FFFFFFFF:\n\tv387 = 0x80;\nL_FFFFFFFF:\n\tv389 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv391 = 0x80;\nL_FFFFFFFF:\n\tv142 = 0x80;\nL_FFFFFFFF:\n\tv250 = 0x80;\nL_FFFFFFFF:\n\tv251 = 0x80;\nL_FFFFFFFF:\n\tv252 = 0x80;\nL_FFFFFFFF:\n\tv253 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv157 = 0x80;\n\tif (v329) goto L_0127;\nL_00A9:\n\tv331 = v307 * 0xC;\n\tv332 = positions + v331;\n\tv378 = v332 + 8;\n\tv414 = v64 - v307;\n\tgoto L_00C4;\nL_FFFFFFFF:\n\tv389 = *([v378 @ X11_v7-8]);\n\tgoto L_00D5;\nL_FFFFFFFF:\n\tv383 = *([v378 @ X11_v7-4]);\n\tgoto L_00E6;\nL_FFFFFFFF:\n\tv381 = returnVal2;\n\tgoto L_00F8;\nL_FFFFFFFF:\n\tv385 = *([v378 @ X11_v7-8]);\n\tgoto L_010A;\nL_FFFFFFFF:\n\tv387 = *([v378 @ X11_v7-4]);\n\tgoto L_0123;\nL_FFFFFFFF:\n\tv391 = returnVal2;\nL_0127:\n\tv193 = v253 | v250;\n\tv160 = v251 | v252;\nL_0016:\n\tv45 = v15 == 0;\n\tif (v45) goto L_003A;\nL_012A:\n\treturnBuffer.m_alignment = 0;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+8]) = 0;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+10]) = 0;\n\treturnBuffer.Min = v193;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = v142;\n\treturnBuffer.Max = v160;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+2C]) = v157;\n\treturn returnBuffer;\nL_0061:\n\t// 97 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 101 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\treturnVal2 = *([v352 @ X10_v10-28]);\n\t// 111 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 113 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 114 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 116 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 117 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 118 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 119 NotImplemented \"Instruction UZP1 not yet implemented.\"\n\t// 120 NotImplemented \"Instruction UZP1 not yet implemented.\"\n\t// 121 NotImplemented \"Instruction UZP2 not yet implemented.\"\n\t// 122 NotImplemented \"Instruction UZP2 not yet implemented.\"\n\t// 123 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 124 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 125 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 126 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 127 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 128 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 129 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 130 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 131 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 132 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 133 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 134 NotImplemented \"Instruction SMAX not yet implemented.\"\n\tv352 = v352 + 0x60;\n\tv351 = v350 - 8;\n\tv309 = v350 != 8;\nL_FFFFFFFF:\n\tv350 = v351;\n\tif (v309) goto L_0061;\nL_00C4:\n\tv436 = v383 - *([v378 @ X11_v7-4]);\n\tv437 = v436 < 0;\n\tv439 = v383 ^ *([v378 @ X11_v7-4]);\n\tv440 = v383 ^ v436;\n\tv441 = v439 & v440;\n\tv442 = v441 < 0;\n\tv443 = v437 == v442;\n\tv444 = ~v443;\n\tv445 = ~v444;\n\tif (v445) goto L_FFFFFFFF;\nL_00D5:\n\tv450 = v381 - returnVal2;\n\tv451 = v450 < 0;\n\tv453 = v381 ^ returnVal2;\n\tv454 = v381 ^ v450;\n\tv455 = v453 & v454;\n\tv456 = v455 < 0;\n\tv457 = v451 == v456;\n\tv458 = ~v457;\n\tv459 = ~v458;\n\tif (v459) goto L_FFFFFFFF;\nL_00E6:\n\tv464 = v385 - *([v378 @ X11_v7-8]);\n\tv465 = v464 < 0;\n\tv466 = v464 == 0;\n\tv467 = v385 ^ *([v378 @ X11_v7-8]);\n\tv468 = v385 ^ v464;\n\tv469 = v467 & v468;\n\tv470 = v469 < 0;\n\tv471 = v465 == v470;\n\tv472 = ~v466;\n\tv473 = v471 & v472;\n\tv474 = ~v473;\n\tif (v474) goto L_FFFFFFFF;\nL_00F8:\n\tv479 = v387 - *([v378 @ X11_v7-4]);\n\tv480 = v479 < 0;\n\tv481 = v479 == 0;\n\tv482 = v387 ^ *([v378 @ X11_v7-4]);\n\tv483 = v387 ^ v479;\n\tv484 = v482 & v483;\n\tv485 = v484 < 0;\n\tv486 = v480 == v485;\n\tv487 = ~v481;\n\tv488 = v486 & v487;\n\tv489 = ~v488;\n\tif (v489) goto L_FFFFFFFF;\nL_010A:\n\tv494 = v391 - returnVal2;\n\tv495 = v494 < 0;\n\tv496 = v494 == 0;\n\tv497 = v391 ^ returnVal2;\n\tv498 = v391 ^ v494;\n\tv499 = v497 & v498;\n\tv500 = v499 < 0;\n\tv501 = v495 == v500;\n\tv373 = ~v496;\n\tv502 = v501 & v373;\n\tv375 = ~v502;\n\tif (v375) goto L_FFFFFFFF;\nL_0123:\n\tv415 = v414 - 1;\n\tv395 = v414 != 1;\nL_FFFFFFFF:\n\tv142 = v381;\nL_FFFFFFFF:\n\tv250 = v383;\nL_FFFFFFFF:\n\tv251 = v385;\nL_FFFFFFFF:\n\tv252 = v387;\nL_FFFFFFFF:\n\tv253 = v389;\nL_FFFFFFFF:\n\tv157 = v391;\nL_FFFFFFFF:\n\tv414 = v415;\n\tif (v395) goto L_00AF;\nL_00AF:\n\treturnVal2 = *([v378 @ X11_v7]);\n\tv378 = v378 + 0xC;\n\tv418 = v389 - *([v378 @ X11_v7-8]);\n\tv419 = v418 < 0;\n\tv421 = v389 ^ *([v378 @ X11_v7-8]);\n\tv422 = v389 ^ v418;\n\tv423 = v421 & v422;\n\tv424 = v423 < 0;\n\tv425 = v419 == v424;\n\tv426 = ~v425;\n\tv427 = ~v426;\n\tif (v427) goto L_FFFFFFFF;\n")]
		public static GridBounds CalculateBounds(Span<int3> positions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::CalculateBounds");
			return default;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x3F2D818", Offset = "0x3F2D818", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tthis.Min = v51.zero;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = v51.zero.z;\n\tv54 = size - 1;\n\tv55 = size.z - 1;\n\tv56 = size & 0xFFFFFFFF00000000;\n\tv57 = v56 | v54;\n\tv59 = v57 + 0xFFFFFFFF00000000;\n\tthis.Max = v59;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+2C]) = v55;\n\treturn;\n")]
		public void InitializeFromSize(int3 size)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::InitializeFromSize");
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x3F2D8AC", Offset = "0x3F2D8AC", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv55 = v15 < 1;\n\tif (v55) goto L_FFFFFFFF;\n\tv174 = v15 & 0x7FFFFFFF;\n\tv175 = v174 < 8;\n\tv176 = ~v175;\n\tif (v176) goto L_003D;\nL_FFFFFFFF:\n\tv365 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv367 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv369 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv371 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv373 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv375 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv291 = 0;\n\tgoto L_009B;\nL_FFFFFFFF:\n\tv121 = 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv130 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv133 = 0x8000000080000000;\nL_FFFFFFFF:\n\tv167 = 0x7FFFFFFF7FFFFFFF;\n\tgoto L_011C;\nL_003D:\n\tv196 = v15 & 7;\n\tv291 = v174 - v196;\nL_FFFFFFFF:\n\tv330 = v291;\nL_FFFFFFFF:\n\tv330 = v122;\n\t// 134 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 135 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 137 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 138 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 140 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 141 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 143 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 144 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 146 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 147 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 149 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 150 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv313 = v196 == 0;\nL_FFFFFFFF:\n\tv365 = 0x80;\nL_FFFFFFFF:\n\tv367 = 0x80;\nL_FFFFFFFF:\n\tv369 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv371 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv373 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv375 = 0x80;\nL_FFFFFFFF:\n\tv233 = 0x80;\nL_FFFFFFFF:\n\tv234 = 0x80;\nL_FFFFFFFF:\n\tv121 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv236 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv237 = 0xFFFFFFFFFFFFFF7F;\nL_FFFFFFFF:\n\tv130 = 0x80;\n\tif (v313) goto L_0119;\nL_009B:\n\tv315 = v291 * 0xC;\n\tv316 = positions + v315;\n\tv362 = v316 + 8;\n\tv398 = v174 - v291;\n\tgoto L_00B6;\nL_FFFFFFFF:\n\tv373 = *([v362 @ X10_v8-8]);\n\tgoto L_00C7;\nL_FFFFFFFF:\n\tv371 = *([v362 @ X10_v8-4]);\n\tgoto L_00D8;\nL_FFFFFFFF:\n\tv369 = *([v362 @ X10_v8]);\n\tgoto L_00EA;\nL_FFFFFFFF:\n\tv365 = *([v362 @ X10_v8-8]);\n\tgoto L_00FC;\nL_FFFFFFFF:\n\tv367 = *([v362 @ X10_v8-4]);\n\tgoto L_0115;\nL_FFFFFFFF:\n\tv375 = *([v362 @ X10_v8]);\nL_0119:\n\tv167 = v237 | v236;\n\tv133 = v233 | v234;\nL_0016:\n\tv44 = v15 == 0;\n\tif (v44) goto L_0127;\nL_011C:\n\tthis.Min = v167;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = v121;\n\tthis.Max = v133;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+2C]) = v130;\nL_0053:\n\t// 83 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 85 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 87 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 89 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 97 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 100 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 102 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 104 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 105 NotImplemented \"Instruction UZP1 not yet implemented.\"\n\t// 106 NotImplemented \"Instruction UZP1 not yet implemented.\"\n\t// 107 NotImplemented \"Instruction UZP2 not yet implemented.\"\n\t// 108 NotImplemented \"Instruction UZP2 not yet implemented.\"\n\t// 109 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 110 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 111 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 112 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 113 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 114 NotImplemented \"Instruction SMIN not yet implemented.\"\n\t// 115 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 116 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 117 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 118 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 119 NotImplemented \"Instruction SMAX not yet implemented.\"\n\t// 120 NotImplemented \"Instruction SMAX not yet implemented.\"\n\tv331 = v330 - 8;\n\tv293 = v330 != 8;\nL_FFFFFFFF:\n\tv330 = v331;\n\tif (v293) goto L_0053;\nL_00B6:\n\tv420 = v371 - *([v362 @ X10_v8-4]);\n\tv421 = v420 < 0;\n\tv423 = v371 ^ *([v362 @ X10_v8-4]);\n\tv424 = v371 ^ v420;\n\tv425 = v423 & v424;\n\tv426 = v425 < 0;\n\tv427 = v421 == v426;\n\tv428 = ~v427;\n\tv429 = ~v428;\n\tif (v429) goto L_FFFFFFFF;\nL_00C7:\n\tv434 = v369 - *([v362 @ X10_v8]);\n\tv435 = v434 < 0;\n\tv437 = v369 ^ *([v362 @ X10_v8]);\n\tv438 = v369 ^ v434;\n\tv439 = v437 & v438;\n\tv440 = v439 < 0;\n\tv441 = v435 == v440;\n\tv442 = ~v441;\n\tv443 = ~v442;\n\tif (v443) goto L_FFFFFFFF;\nL_00D8:\n\tv448 = v365 - *([v362 @ X10_v8-8]);\n\tv449 = v448 < 0;\n\tv450 = v448 == 0;\n\tv451 = v365 ^ *([v362 @ X10_v8-8]);\n\tv452 = v365 ^ v448;\n\tv453 = v451 & v452;\n\tv454 = v453 < 0;\n\tv455 = v449 == v454;\n\tv456 = ~v450;\n\tv457 = v455 & v456;\n\tv458 = ~v457;\n\tif (v458) goto L_FFFFFFFF;\nL_00EA:\n\tv463 = v367 - *([v362 @ X10_v8-4]);\n\tv464 = v463 < 0;\n\tv465 = v463 == 0;\n\tv466 = v367 ^ *([v362 @ X10_v8-4]);\n\tv467 = v367 ^ v463;\n\tv468 = v466 & v467;\n\tv469 = v468 < 0;\n\tv470 = v464 == v469;\n\tv471 = ~v465;\n\tv472 = v470 & v471;\n\tv473 = ~v472;\n\tif (v473) goto L_FFFFFFFF;\nL_00FC:\n\tv478 = v375 - *([v362 @ X10_v8]);\n\tv479 = v478 < 0;\n\tv480 = v478 == 0;\n\tv481 = v375 ^ *([v362 @ X10_v8]);\n\tv482 = v375 ^ v478;\n\tv483 = v481 & v482;\n\tv484 = v483 < 0;\n\tv485 = v479 == v484;\n\tv357 = ~v480;\n\tv486 = v485 & v357;\n\tv359 = ~v486;\n\tif (v359) goto L_FFFFFFFF;\nL_0115:\n\tv399 = v398 - 1;\n\tv379 = v398 != 1;\nL_FFFFFFFF:\n\tv233 = v365;\nL_FFFFFFFF:\n\tv234 = v367;\nL_FFFFFFFF:\n\tv121 = v369;\nL_FFFFFFFF:\n\tv236 = v371;\nL_FFFFFFFF:\n\tv237 = v373;\nL_FFFFFFFF:\n\tv130 = v375;\nL_FFFFFFFF:\n\tv398 = v399;\n\tif (v379) goto L_00A2;\nL_0127:\n\treturn;\nL_00A2:\n\tv362 = v362 + 0xC;\n\tv402 = v373 - *([v362 @ X10_v8-8]);\n\tv403 = v402 < 0;\n\tv405 = v373 ^ *([v362 @ X10_v8-8]);\n\tv406 = v373 ^ v402;\n\tv407 = v405 & v406;\n\tv408 = v407 < 0;\n\tv409 = v403 == v408;\n\tv410 = ~v409;\n\tv411 = ~v410;\n\tif (v411) goto L_FFFFFFFF;\n")]
		public void InitializeFromPositions(Span<int3> positions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::InitializeFromPositions");
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x3F2DB00", Offset = "0x3F2DB00", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.Max - this.Min;\n\tv7 = v6 + 1;\n\tv27 = v7 + -1;\n\t// 26 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv28 = this.m_alignment * v27;\n\tv29 = v28 * v30;\n\tv32 = this.ConstantOffset * v30;\n\tv33 = v32 - v29;\n\t// 33 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv35 = this.Min * v30;\n\treturnVal1 = v35 + v33;\n\treturn returnVal1;\n")]
		public float3 CalculateOffset(float voxelSize)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::CalculateOffset");
			return default;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x3F2DB9C", Offset = "0x3F2DB9C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.Min;\n\tv36 = this.Min.y;\n\tv9 = this.Min - bounds.Min;\n\tv10 = v9 < 0;\n\tv12 = this.Min ^ bounds.Min;\n\tv13 = this.Min ^ v9;\n\tv14 = v12 & v13;\n\tv15 = v14 < 0;\n\tv16 = v10 == v15;\n\tv17 = ~v16;\n\tv18 = ~v17;\n\tif (v18) goto L_FFFFFFFF;\n\tgoto L_0018;\nL_FFFFFFFF:\n\tv21 = bounds.Min;\n\tgoto L_0027;\nL_FFFFFFFF:\n\tv36 = bounds.Min.y;\n\tgoto L_003A;\nL_FFFFFFFF:\n\tv53 = bounds.Min.z;\n\tgoto L_0056;\nL_FFFFFFFF:\n\tv75 = bounds.Max;\n\tgoto L_0068;\nL_FFFFFFFF:\n\tv91 = bounds.Max.y;\n\tgoto L_0078;\nL_FFFFFFFF:\n\tv107 = bounds.Max.z;\nL_0018:\n\tv24 = v36 - bounds.Min.y;\n\tv25 = v24 < 0;\n\tv27 = v36 ^ bounds.Min.y;\n\tv28 = v36 ^ v24;\n\tv29 = v27 & v28;\n\tv30 = v29 < 0;\n\tv31 = v25 == v30;\n\tv32 = ~v31;\n\tv33 = ~v32;\n\tif (v33) goto L_FFFFFFFF;\nL_0027:\n\tv53 = this.Min.z;\n\tv75 = this.Max;\n\tv41 = this.Min.z - bounds.Min.z;\n\tv42 = v41 < 0;\n\tv44 = this.Min.z ^ bounds.Min.z;\n\tv45 = this.Min.z ^ v41;\n\tv46 = v44 & v45;\n\tv47 = v46 < 0;\n\tv48 = v42 == v47;\n\tv49 = ~v48;\n\tv50 = ~v49;\n\tif (v50) goto L_FFFFFFFF;\nL_003A:\n\tv54 = v21 | v36;\n\tthis.Min = v54;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = v53;\n\tv91 = this.Max.y;\n\tv107 = this.Max.z;\n\tv62 = v75 - bounds.Max;\n\tv63 = v62 < 0;\n\tv64 = v62 == 0;\n\tv65 = v75 ^ bounds.Max;\n\tv66 = v75 ^ v62;\n\tv67 = v65 & v66;\n\tv68 = v67 < 0;\n\tv69 = v63 == v68;\n\tv70 = ~v64;\n\tv71 = v69 & v70;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\nL_0056:\n\tv78 = v91 - bounds.Max.y;\n\tv79 = v78 < 0;\n\tv80 = v78 == 0;\n\tv81 = v91 ^ bounds.Max.y;\n\tv82 = v91 ^ v78;\n\tv83 = v81 & v82;\n\tv84 = v83 < 0;\n\tv85 = v79 == v84;\n\tv86 = ~v80;\n\tv87 = v85 & v86;\n\tv88 = ~v87;\n\tif (v88) goto L_FFFFFFFF;\nL_0068:\n\tv94 = v107 - bounds.Max.z;\n\tv95 = v94 < 0;\n\tv96 = v94 == 0;\n\tv97 = v107 ^ bounds.Max.z;\n\tv98 = v107 ^ v94;\n\tv99 = v97 & v98;\n\tv100 = v99 < 0;\n\tv101 = v95 == v100;\n\tv102 = ~v96;\n\tv103 = v101 & v102;\n\tv104 = ~v103;\n\tif (v104) goto L_FFFFFFFF;\nL_0078:\n\tv108 = v75 | v91;\n\tthis.Max = v108;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.GridBounds)+2C]) = v107;\n\treturnBuffer.m_alignment = this.m_alignment;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+10]) = this.m_constantOffset.y;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = this.Min.z;\n\treturn returnBuffer;\n")]
		public GridBounds Encapsulate(GridBounds bounds)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::Encapsulate");
			return default;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x3F2DC14", Offset = "0x3F2DC14", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.Min & 0xFFFFFFFF00000000;\n\tv6 = logicalPos - this.Min;\n\tv7 = logicalPos - v5;\n\tv8 = v7 & 0xFFFFFFFF00000000;\n\treturnVal1 = v8 | v6;\n\treturn returnVal1;\n")]
		public int3 WorldToGrid(int3 logicalPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::WorldToGrid");
			return default;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x3F2DC38", Offset = "0x3F2DC38", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.Min & 0xFFFFFFFF00000000;\n\tv6 = this.Min + arrayPos;\n\tv7 = v5 + arrayPos;\n\tv8 = v7 & 0xFFFFFFFF00000000;\n\treturnVal1 = v8 | v6;\n\treturn returnVal1;\n")]
		public int3 GridToWorld(int3 arrayPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::GridToWorld");
			return default;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x3F2DC5C", Offset = "0x3F2DC5C", Length = "0x49C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv65 = this.m_constantOffset.y == 0;\n\tv70 = ~v65;\n\tif (v70) goto L_00DD;\n\tv80 = this.m_constantOffset.z == 0;\n\tv72 = ~v80;\n\tif (v72) goto L_00DD;\n\t// 67 NewArr v103 @ X0_v62 (System.Object[]), typeof(System.Object[]), 5\n\tv109 = this.m_alignment;\n\tv111 = 0xB7D5000 + 0x538;\n\tv114 = \"il2cpp_vm_object_box\"(*([v111 @ X22_v11 (System.Int32)+78]), &v109 @ stack_-78_v6 (Unity.Mathematics.float3), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, this.m_alignment, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv199 = v114 == 0;\n\tif (v199) goto L_005C;\n\tv430 = 0x21C11D0(v114, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv432 = v430 == 0;\n\tif (v432) goto L_01A8;\nL_005C:\n\tv103[0] = v114;\n\tv243 = this.m_alignment.y;\n\tv483 = \"il2cpp_vm_object_box\"(*([v111 @ X22_v11 (System.Int32)+78]), &v243 @ stack_-44_v6 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, this.m_alignment.y, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv487 = v483 == 0;\n\tif (v487) goto L_0076;\n\tv445 = 0x21C11D0(v483, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv454 = v445 == 0;\n\tif (v454) goto L_01A8;\nL_0076:\n\tv103[1] = v483;\n\tv241 = this.m_alignment.z;\n\tv505 = \"il2cpp_vm_object_box\"(*([v111 @ X22_v11 (System.Int32)+78]), &v241 @ stack_-48_v5 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, this.m_alignment.z, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv510 = v505 == 0;\n\tif (v510) goto L_0096;\n\tv446 = 0x21C11D0(v505, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv455 = v446 == 0;\n\tif (v455) goto L_01A8;\nL_0096:\n\tv103[2] = v505;\n\tv219 = this.Min;\n\t// 161 Box v536 @ X0_v82, typeof(Unity.Mathematics.int3), &v219 @ stack_-58_v6 (Unity.Mathematics.int3)\n\tv540 = v536 == 0;\n\tif (v540) goto L_00B4;\n\tv447 = 0x21C11D0(v536, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv456 = v447 == 0;\n\tif (v456) goto L_01A8;\nL_00B4:\n\tv103[3] = v536;\n\tv559 = this.Max;\n\tv214 = this.Max;\n\tv559.z = this.Max.z;\n\t// 189 Box v563 @ X0_v88, typeof(Unity.Mathematics.int3), &v214 @ stack_-68_v5 (Unity.Mathematics.int3)\n\tv568 = v563 == 0;\n\tif (v568) goto L_00D6;\n\tv448 = 0x21C11D0(v563, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv457 = v448 == 0;\n\tif (v457) goto L_01A8;\nL_00D6:\n\tv103[4] = v563;\n\tv420 = 0xB2F4000 + 0x40;\n\tv599 = v103;\n\tgoto L_019C;\nL_00DD:\n\t// 221 NewArr v86 @ X0_v13 (System.Object[]), typeof(System.Object[]), 6\n\tv93 = this.m_alignment;\n\tv95 = 0xB7D5000 + 0x538;\n\tv98 = \"il2cpp_vm_object_box\"(*([v95 @ X23_v7 (System.Int32)+78]), &v93 @ stack_-44_v5 (Unity.Mathematics.float3), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, this.m_alignment, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv116 = v98 == 0;\n\tif (v116) goto L_00F6;\n\tv190 = 0x21C11D0(v98, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv194 = v190 == 0;\n\tif (v194) goto L_01A8;\nL_00F6:\n\tv86[0] = v98;\n\tv241 = this.m_alignment.y;\n\tv475 = \"il2cpp_vm_object_box\"(*([v95 @ X23_v7 (System.Int32)+78]), &v241 @ stack_-48_v5 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, this.m_alignment.y, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv480 = v475 == 0;\n\tif (v480) goto L_0110;\n\tv449 = 0x21C11D0(v475, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv458 = v449 == 0;\n\tif (v458) goto L_01A8;\nL_0110:\n\tv86[1] = v475;\n\tv207 = this.m_alignment.z;\n\tv497 = \"il2cpp_vm_object_box\"(*([v95 @ X23_v7 (System.Int32)+78]), &v207 @ stack_-6C_v5 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, this.m_alignment.z, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv502 = v497 == 0;\n\tif (v502) goto L_0130;\n\tv450 = 0x21C11D0(v497, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv459 = v450 == 0;\n\tif (v459) goto L_01A8;\nL_0130:\n\tv86[2] = v497;\n\tv220 = this.ConstantOffset;\n\t// 315 Box v525 @ X0_v33, typeof(Unity.Mathematics.float3), &v220 @ stack_-58_v5 (Unity.Mathematics.float3)\n\tv530 = v525 == 0;\n\tif (v530) goto L_014E;\n\tv451 = 0x21C11D0(v525, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv460 = v451 == 0;\n\tif (v460) goto L_01A8;\nL_014E:\n\tv86[3] = v525;\n\tv214 = this.Min;\n\tv559.z = this.Min.z;\n\t// 345 Box v553 @ X0_v39, typeof(Unity.Mathematics.int3), &v214 @ stack_-68_v5 (Unity.Mathematics.int3)\n\tv558 = v553 == 0;\n\tif (v558) goto L_0172;\n\tv452 = 0x21C11D0(v553, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv461 = v452 == 0;\n\tif (v461) goto L_01A8;\nL_0172:\n\tv86[4] = v553;\n\tv248 = this.Max;\n\t// 379 Box v581 @ X0_v45, typeof(Unity.Mathematics.int3), &v248 @ stack_-78_v5 (Unity.Mathematics.int3)\n\tv586 = v581 == 0;\n\tif (v586) goto L_0194;\n\tv453 = 0x21C11D0(v581, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv462 = v453 == 0;\n\tif (v462) goto L_01A8;\nL_0194:\n\tv86[5] = v581;\n\tv420 = 0xB2F4000 + 0x48;\n\tv599 = v86;\nL_01A8:\n\tv472 = new System.ArrayTypeMismatchException();\n\tthrow v472;\nL_0026:\n\t;\n\tv54 = this.ConstantOffset == 0;\n\tv59 = ~v54;\n\tif (v59) goto L_00DD;\nL_019C:\n\treturnVal2 = System.String::Format(*([v420 @ X8_v3 (System.Int32)]), v599);\n\treturn returnVal2;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBounds::ToString");
			return default;
		}
	}
}
