using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Entities;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.Services
{
	[Token(Token = "0x2000107")]
	public class SandBreakEventQueue
	{
		[Token(Token = "0x4000365")]
		[FieldOffset(Offset = "0x10")]
		internal Entity _singletonEntity;

		[Token(Token = "0x600059A")]
		[Address(RVA = "0x3DA90F0", Offset = "0x3DA90F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._singletonEntity = singletonEntity;\n\treturn;\n")]
		public void Bind(Entity singletonEntity)
		{
			_singletonEntity = singletonEntity;
		}

		[Token(Token = "0x600059B")]
		[Address(RVA = "0x3DA90F8", Offset = "0x3DA90F8", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001B;\nL_001B:\n\tgoto L_001F;\nL_001F:\n\tgoto L_0022;\nL_0022:\n\tv106 = v104.<DefaultGameObjectInjectionWorld>k__BackingField == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_005B;\nL_002C:\n\treturn;\nL_005B:\n\tv130 = Unity.Entities.World::get_IsCreated(v104.<DefaultGameObjectInjectionWorld>k__BackingField);\n\tv138 = ~v130;\n\tif (v138) goto L_002C;\n\tv201 = Unity.Entities.World::get_EntityManager(v104.<DefaultGameObjectInjectionWorld>k__BackingField);\n\tv124 = v201;\n\tgoto L_006E;\nL_006E:\n\tv131 = Unity.Entities.EntityManager::Exists(&v124 @ stack_-58_v1 (Unity.Entities.EntityManager), this._singletonEntity);\n\tv139 = ~v131;\n\tif (v139) goto L_002C;\n\tgoto L_007E;\nL_007E:\n\tv220 = Unity.Entities.EntityManager::GetBuffer(&v124 @ stack_-58_v1 (Unity.Entities.EntityManager), this._singletonEntity, 0);\n\tv184 = v220;\n\tv167 = evt.position;\n\tv180 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>::Add(&v184 @ stack_-68_v2 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>), &v167 @ stack_-50_v1 (Unity.Mathematics.float2));\n\treturn;\n")]
		public unsafe void EnqueueBreakEvent(CubeBreakEvent evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandBreakEventQueue::EnqueueBreakEvent");
		}

		[Token(Token = "0x600059C")]
		[Address(RVA = "0x3DA92BC", Offset = "0x3DA92BC", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tgoto L_0022;\nL_0022:\n\tgoto L_0026;\nL_0026:\n\tgoto L_0029;\nL_0029:\n\tv129 = v127.<DefaultGameObjectInjectionWorld>k__BackingField == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0066;\n\tgoto L_00F1;\nL_0066:\n\tv160 = Unity.Entities.World::get_IsCreated(v127.<DefaultGameObjectInjectionWorld>k__BackingField);\n\tv237 = ~v160;\n\tif (v237) goto L_00F1;\n\tv264 = Unity.Entities.World::get_EntityManager(v127.<DefaultGameObjectInjectionWorld>k__BackingField);\n\tv219 = v264;\n\tgoto L_0079;\nL_0079:\n\tv226 = Unity.Entities.EntityManager::Exists(&v219 @ stack_-88_v2 (Unity.Entities.EntityManager), this._singletonEntity);\n\tv238 = ~v226;\n\tif (v238) goto L_00F1;\n\tgoto L_0089;\nL_0089:\n\tv290 = Unity.Entities.EntityManager::GetBuffer(&v219 @ stack_-88_v2 (Unity.Entities.EntityManager), this._singletonEntity, 0);\n\tv234 = v290;\n\tv295 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>::get_Length(&v234 @ stack_-98_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>));\n\tevt.targetStartIndex = v295;\n\tv296 = targets == 0;\n\tif (v296) goto L_FFFFFFFF;\n\tv355 = targets.Length;\n\tv308 = targets.Length < 1;\n\tif (v308) goto L_00F3;\n\tv362 = targets + 0x24;\nL_FFFFFFFF:\n\tv363 = 0;\nL_FFFFFFFF:\n\tv353 = 0;\n\tgoto L_00B4;\nL_00A7:\n\tv363 = v363 + 1;\n\tv362 = v362 + 8;\n\tv329 = v363 >= v355;\nL_FFFFFFFF:\n\tv352 = v353;\n\tif (v329) goto L_00C9;\nL_00B4:\n\t;\n\tv388 = *([v362 @ X25_v7]) < 1;\n\tif (v388) goto L_00A7;\n\tv423 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>::Add(&v234 @ stack_-98_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>), *([v362 @ X25_v7-4]));\n\tv353 = v353 + 1;\n\tv355 = targets.Length;\n\tgoto L_00A7;\nL_FFFFFFFF:\n\tv352 = 0;\nL_00D7:\n\tv418 = Unity.Entities.EntityManager::GetBuffer(&v219 @ stack_-88_v2 (Unity.Entities.EntityManager), v248, 0);\n\tv230 = v418;\n\tv171 = evt.position;\n\tv225 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>::Add(&v230 @ stack_-A8_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>), &v171 @ stack_-80_v2 (Unity.Mathematics.float2));\nL_00F1:\n\treturn;\nL_00F3:\n\tevt.targetCount = 0;\n\tv248 = this._singletonEntity;\n\tgoto L_00D7;\nL_00C9:\n\tevt.targetCount = v352;\n\tv248 = this._singletonEntity;\n\tgoto L_00D7;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void EnqueueForceBreakEvent(ForceBreakEvent evt, ForceBreakTarget[] targets)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandBreakEventQueue::EnqueueForceBreakEvent");
		}

		[Token(Token = "0x600059D")]
		[Address(RVA = "0x3DA9580", Offset = "0x3DA9580", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandBreakEventQueue()
		{
		}
	}
}
