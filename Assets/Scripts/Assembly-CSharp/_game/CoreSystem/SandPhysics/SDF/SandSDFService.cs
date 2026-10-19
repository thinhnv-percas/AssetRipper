using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.SandPhysics.Collision;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[Token(Token = "0x2000112")]
	public class SandSDFService : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000389")]
		[FieldOffset(Offset = "0x10")]
		private SandSDFConfig _config;

		[Token(Token = "0x400038A")]
		[FieldOffset(Offset = "0x18")]
		internal SandSDFData _sdf;

		[Token(Token = "0x17000087")]
		public bool IsBuilt
		{
			[Token(Token = "0x60005C7")]
			[Address(RVA = "0x3DA67EC", Offset = "0x3DA67EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._sdf.IsBuilt;\n")]
			get
			{
				return _sdf.IsBuilt;
			}
		}

		[Token(Token = "0x60005C6")]
		[Address(RVA = "0x3DA67F4", Offset = "0x3DA67F4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = &this._sdf (_game.CoreSystem.SandPhysics.SDF.SandSDFData);\n\treturn returnVal1;\n")]
		public ref SandSDFData GetSDFData()
		{
			return ref _sdf;
		}

		[Token(Token = "0x60005C8")]
		[Address(RVA = "0x3DAE648", Offset = "0x3DAE648", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xB78E000;\n\tv20 = *([B78E0CC]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0058;\n\tv72 = 0xB292000 + 0x5A0;\n\tv29 = this._sdf.IsBuilt == 1;\n\tv90 = v72;\n\tif (v29) goto L_006C;\nL_001D:\n\tv77 = *([v72 @ X22_v15 (System.Int32)]);\n\tv79 = *([v77 @ X0_v56+E4]) == 0;\n\tv118 = this._config;\n\tv138 = this._config;\n\tif (v79) goto L_0088;\nL_0024:\n\tv123 = UnityEngine.Object::op_Equality(v118, 0);\n\tv151 = ~v123;\n\tif (v151) goto L_008D;\nL_002F:\n\tgoto L_003D;\nL_004C:\n\tUnityEngine.Debug::LogError(v284);\n\treturn;\nL_0058:\n\t*([v18 @ X21_v1+CC]) = 1;\n\tv72 = 0xB292000 + 0x5A0;\n\tv53 = this._sdf.IsBuilt != 1;\n\tv90 = v72;\n\tif (v53) goto L_001D;\nL_006C:\n\tgoto L_0076;\n\tv161 = this + 0x18;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.half>::Dispose(v161);\nL_007D:\n\tthis._sdf.IsBuilt = 0;\n\tv104 = *([v90 @ X22_v8 (System.Int32)]);\n\tv164 = *([v104 @ X0_v24+E4]) == 0;\n\tv115 = ~v164;\n\tv118 = this._config;\n\tv138 = this._config;\n\tif (v115) goto L_0024;\nL_0088:\n\tv155 = UnityEngine.Object::op_Equality(v138, 0);\n\tv211 = ~v155;\n\tv182 = ~v211;\n\tif (v182) goto L_002F;\nL_008D:\n\tv210 = boundary.loopCount == 0;\n\tif (v210) goto L_00B7;\n\tv229 = _game.CoreSystem.SandPhysics.SDF.SandSDFBuilder::Bake(boundary, this._config);\n\tthis._sdf.values = v229.values;\n\tthis._sdf.origin = v229.origin;\n\tthis._sdf.gridHeight = v229.gridHeight;\n\treturn;\nL_00B7:\n\tgoto L_00C3;\nL_003D:\n\tv284 = System.String::Concat(\"[SDF] \", \"Bake aborted: SandSDFConfig is null (Reflex injection missing?)\");\n\tgoto L_004C;\nL_0076:\n\tv148 = this._sdf == 0;\n\tif (v148) goto L_007D;\nL_00C3:\n\tv284 = System.String::Concat(\"[SDF] \", \"Bake aborted: NativeBoundaryData has zero playable loops\");\n\tgoto L_004C;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Bake(in NativeBoundaryData boundary)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFService::Bake");
		}

		[Token(Token = "0x60005C9")]
		[Address(RVA = "0x3DAE8A8", Offset = "0x3DAE8A8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._sdf.IsBuilt != 1;\n\tif (v11) goto L_002F;\n\tgoto L_0022;\n\tv81 = this + 0x18;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.half>::Dispose(v81);\nL_0029:\n\tthis._sdf.IsBuilt = 0;\nL_002F:\n\treturn;\nL_0022:\n\tv36 = this._sdf == 0;\n\tif (v36) goto L_0029;\n")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFService::Dispose");
		}

		[Token(Token = "0x60005CA")]
		[Address(RVA = "0x3DAE91C", Offset = "0x3DAE91C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandSDFService()
		{
		}
	}
}
