using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.SandPhysics.Services
{
	[Token(Token = "0x2000106")]
	public class MovingCubeRegistry : IDisposable
	{
		[Token(Token = "0x4000364")]
		[FieldOffset(Offset = "0x10")]
		private NativeList<MovingCubeData> _movingCubes;

		[Token(Token = "0x17000082")]
		public NativeList<MovingCubeData> Buffer
		{
			[Token(Token = "0x6000593")]
			[Address(RVA = "0x3DA8A94", Offset = "0x3DA8A94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Buffer;\n")]
			get
			{
				return _movingCubes;
			}
		}

		[Token(Token = "0x6000594")]
		[Address(RVA = "0x3DA8A9C", Offset = "0x3DA8A9C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB78E000;\n\tv14 = *([B78E04C]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_001C;\n\tv17 = this.Buffer == 0;\n\tif (v17) goto L_0023;\nL_0014:\n\treturn;\nL_001C:\n\t*([v12 @ X20_v1+4C]) = 1;\n\tv80 = this.Buffer == 0;\n\tv39 = ~v80;\n\tif (v39) goto L_0014;\nL_0023:\n\tv51 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(4);\n\tUnity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>::.ctor(&v60 @ stack_-28_v2 (Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>), 4, v51);\n\tthis.Buffer = v60;\n\treturn;\n")]
		public void Init()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E04C]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if ((object)Buffer != null)
				{
					return;
				}
			}
			else
			{
				_ = 1;
				if ((object)Buffer != null)
				{
					return;
				}
			}
			AllocatorManager.AllocatorHandle allocator = Allocator.Persistent;
			NativeList<MovingCubeData> movingCubes = new NativeList<MovingCubeData>(4, allocator);
			_movingCubes = movingCubes;
		}

		[Token(Token = "0x6000595")]
		[Address(RVA = "0x3DA8B40", Offset = "0x3DA8B40", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tgoto L_0030;\nL_0030:\n\tv102 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::get_IsValid(&v114 @ stack_-58_v5 (_game.BaseLayerSystems.EntitySystem.Core.EntityId));\n\tv134 = ~v102;\n\tv106 = ~v134;\n\tif (v106) goto L_0043;\n\tgoto L_0087;\nL_0043:\n\t// 67 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv81 = center.y;\n\tgoto L_0053;\nL_005C:\n\tv164 = 0x8BF6080(System.Math, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v156, center, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_006E;\nL_0071:\n\tv182 = 0x8BF7490(System.Math, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v156, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tUnity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>::Add(&this._movingCubes (Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>), &v81 @ stack_-80_v2 (_game.CoreSystem.SandPhysics.MovingCubeData));\nL_0087:\n\treturn;\nL_0024:\n\tv56 = this + 0x10;\n\tv58 = v56.m_ListData == 0;\n\tif (v58) goto L_0087;\nL_0053:\n\tv156 = rotation * 0x3C8EFA35;\n\tgoto L_005C;\nL_006E:\n\tgoto L_0071;\n")]
		public unsafe void Register(EntityId entityId, float2 center, float halfSize, float rotation)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubeRegistry::Register");
		}

		[Token(Token = "0x6000596")]
		[Address(RVA = "0x3DA8CE0", Offset = "0x3DA8CE0", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv201 = -1;\n\tv161 = 0xFFFFFFFFFFFFFFDC;\n\tgoto L_0054;\nL_004A:\n\tgoto L_004B;\nL_004B:\n\tv161 = v161 + 0x24;\n\tv239 = &v68 @ stack_-D0_v1 (System.Int32) + 0x1C;\n\tv203 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::Equals(v239, entityId);\n\tv241 = ~v203;\n\tv206 = ~v241;\n\tif (v206) goto L_007E;\nL_0054:\n\tv124 = this.Buffer;\n\tgoto L_005D;\nL_005D:\n\t;\n\tv201 = v201 + 1;\n\tv96 = v201 >= *([v124 @ X27_v4 (Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>)+8]);\n\tif (v96) goto L_00B4;\n\tgoto L_004A;\nL_007E:\n\tv148 = this.Buffer;\n\tgoto L_008A;\nL_009B:\n\tv157 = v148.m_ListData + v161;\n\t*([v157 @ X8_v28]) = newCenter;\n\t*([v157 @ X8_v28+4]) = newCenter.y;\n\t*([v157 @ X8_v28+8]) = *([v257 @ X8_v21]);\n\t*([v157 @ X8_v28+10]) = *([v257 @ X8_v21+10]);\n\t*([v157 @ X8_v28+20]) = *([v257 @ X8_v21+20]);\nL_0030:\n\tv68 = 0;\n\tv71 = this.Buffer == 0;\n\tif (v71) goto L_00B4;\nL_00B4:\n\treturn;\nL_008A:\n\tv257 = v148.m_ListData + v161;\n\tgoto L_009B;\n")]
		public unsafe void Update(EntityId entityId, float2 newCenter)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubeRegistry::Update");
		}

		[Token(Token = "0x6000597")]
		[Address(RVA = "0x3DA8EF0", Offset = "0x3DA8EF0", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv149 = 0;\n\tgoto L_004B;\nL_004B:\n\tv107 = v149 >= *([v105 @ X27_v4 (Unity.Collections.LowLevel.Unsafe.UnsafeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>*)+8]);\n\tif (v107) goto L_008A;\n\tgoto L_0063;\nL_0063:\n\tgoto L_0065;\nL_0065:\n\tv230 = &v58 @ stack_-90_v1 (System.Int32) + 0x1C;\n\tv231 = _game.BaseLayerSystems.EntitySystem.Core.EntityId::Equals(v230, entityId);\n\tv232 = ~v231;\n\tv143 = ~v232;\n\tif (v143) goto L_007C;\n\tv149 = v149 + 1;\n\tv105 = v60.m_ListData;\n\tgoto L_0076;\nL_0076:\n\tgoto L_004B;\nL_007C:\n\tUnity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>::RemoveAtSwapBack(&this._movingCubes (Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>), v149);\nL_008A:\n\treturn;\nL_0029:\n\tv58 = 0;\n\tv60 = this + 0x10;\n\tv105 = v60.m_ListData;\n\tv62 = v60.m_ListData == 0;\n\tif (v62) goto L_008A;\n")]
		public unsafe void Unregister(EntityId entityId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubeRegistry::Unregister");
		}

		[Token(Token = "0x6000598")]
		[Address(RVA = "0x3DA9078", Offset = "0x3DA9078", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tUnity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>::Dispose(&v36._movingCubes (Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>));\n\treturn;\nL_002A:\n\treturn;\nL_0017:\n\tv41 = v36 + 0x10;\n\tv43 = v41.m_ListData == 0;\n\tif (v43) goto L_002A;\n")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubeRegistry::Dispose");
		}

		[Token(Token = "0x6000599")]
		[Address(RVA = "0x3DA90E8", Offset = "0x3DA90E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MovingCubeRegistry()
		{
		}
	}
}
