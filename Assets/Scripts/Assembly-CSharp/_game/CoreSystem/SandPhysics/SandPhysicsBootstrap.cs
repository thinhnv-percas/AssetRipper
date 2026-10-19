using System;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Collections;
using Unity.Entities;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed;
using _game.CoreSystem.SandPhysics.Collision;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.SandPhysics.SDF;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A4")]
	public class SandPhysicsBootstrap : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x10")]
		private SandPhysicsConfig _config;

		[Inject(false)]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x18")]
		private SandParticleParams _params;

		[Inject(false)]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x28")]
		private SandRenderingAssetsSO _renderAssets;

		[Inject(false)]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x30")]
		private SandPhysicsBuffers _buffers;

		[Inject(false)]
		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x38")]
		private SandCollisionService _collision;

		[Inject(false)]
		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x40")]
		private SandSDFService _sdf;

		[Inject(false)]
		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x48")]
		private MovingCubeRegistry _movingCubes;

		[Inject(false)]
		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x50")]
		private SandBreakEventQueue _breakQueue;

		[Inject(false)]
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x58")]
		private SandParticleQueries _queries;

		[Inject(false)]
		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x60")]
		private SandPrototypeEntityFactory _prototypeFactory;

		[Inject(true)]
		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x68")]
		private ConveyorController _conveyor;

		[Inject(true)]
		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x70")]
		private GameplaySpeedController _gameplaySpeed;

		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0x78")]
		private Entity _singletonEntity;

		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0x80")]
		private Entity _prototypeEntity;

		[Inject(false)]
		[Token(Token = "0x6000296")]
		[Address(RVA = "0x3C79F04", Offset = "0x3C79F04", Length = "0x468")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = *([A4731E0]);\n\tgoto L_001D;\nL_001D:\n\tgoto L_0022;\nL_0022:\n\tgoto L_0026;\nL_0026:\n\tgoto L_0029;\nL_0029:\n\tv107 = v105.<DefaultGameObjectInjectionWorld>k__BackingField == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0067;\n\tgoto L_0146;\nL_0067:\n\tv127 = Unity.Entities.World::get_EntityManager(v105.<DefaultGameObjectInjectionWorld>k__BackingField);\n\t_game.CoreSystem.SandPhysics.Services.SandCollisionService::Build(this._collision);\n\t_game.CoreSystem.SandPhysics.SDF.SandSDFLogger::BeginSession(\"level-load\");\n\tv401 = _game.CoreSystem.SandPhysics.Services.SandCollisionService::GetBoundaryData(this._collision);\n\t_game.CoreSystem.SandPhysics.SDF.SandSDFService::Bake(this._sdf, v401);\n\tgoto L_0091;\nL_0091:\n\tv503 = Unity.Entities.EntityManager::CreateEntity(&v501 @ stack_-F8_v5 (Unity.Entities.EntityManager));\n\tthis._singletonEntity = v503;\n\tv508 = Unity.Entities.EntityManager::AddBuffer(&v501 @ stack_-F8_v5 (Unity.Entities.EntityManager), v503);\n\tv513 = Unity.Entities.EntityManager::AddBuffer(&v501 @ stack_-F8_v5 (Unity.Entities.EntityManager), this._singletonEntity);\n\tv518 = Unity.Entities.EntityManager::AddBuffer(&v501 @ stack_-F8_v5 (Unity.Entities.EntityManager), this._singletonEntity);\n\tv522 = Unity.Collections.FixedString64Bytes::op_Implicit(\"SandPhysicsSingleton\");\n\tv166 = v522.utf8LengthInBytes;\n\tUnity.Entities.EntityManager::SetName(&v501 @ stack_-F8_v5 (Unity.Entities.EntityManager), this._singletonEntity, &v166 @ stack_-F0_v4 (System.UInt16));\n\tv416 = this._breakQueue;\n\tv416._singletonEntity = this._singletonEntity;\n\tv525 = _game.CoreSystem.SandPhysics.Services.SandPrototypeEntityFactory::CreatePrototype(this._prototypeFactory, v501, this._renderAssets, this._params);\n\tthis._prototypeEntity = v525;\n\t_game.CoreSystem.SandPhysics.Services.MovingCubeRegistry::Init(this._movingCubes);\n\tgoto L_00DE;\nL_00DE:\n\tv533 = UnityEngine.Object::op_Inequality(this._conveyor, 0);\n\tv537 = ~v533;\n\tv538 = ~v537;\n\tif (v538) goto L_016E;\n\t_game.CoreSystem.SandPhysics.SandPhysicsBootstrap::ConfigurePhysicsSystemGroup(this);\n\tv557 = this._gameplaySpeed;\n\tv553 = this._gameplaySpeed == 0;\n\tif (v553) goto L_00FB;\nL_00E8:\n\t_game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.GameplaySpeedController::Reapply(v557);\nL_00FB:\n\tv574 = new _game.CoreSystem.SandPhysics.SandPhysicsContext();\n\tSystem.Object::.ctor(v574);\n\tv574.Collision = this._collision;\n\tv574.MovingCubes = this._movingCubes;\n\tv574.BreakQueue = this._breakQueue;\n\tv574.Queries = this._queries;\n\tv574.RenderAssets = this._renderAssets;\n\tv574.<Params>k__BackingField = this._params;\n\tv574.<Params>k__BackingField.ParticleVisualSize = this._params.ParticleVisualSize;\n\tv574.Config = this._config;\n\tv574.PrototypeEntity = this._prototypeEntity;\n\tv574.Buffers = this._buffers;\n\tv574.Conveyor = this._conveyor;\n\tv574.SDF = this._sdf;\n\tgoto L_0141;\nL_0146:\n\tv249 = *([A4731E0]);\n\tv260 = *([v249 @ X9_v4]) != *([v29 @ X8_v2]);\n\tif (v260) goto L_0177;\n\treturn;\nL_016E:\n\t_game.CoreSystem.ConveyorSystem.ConveyorController::Initialize(this._conveyor);\n\t_game.CoreSystem.SandPhysics.SandPhysicsBootstrap::ConfigurePhysicsSystemGroup(this);\n\tv557 = this._gameplaySpeed;\n\tv577 = this._gameplaySpeed == 0;\n\tv560 = ~v577;\n\tif (v560) goto L_00E8;\n\tgoto L_00FB;\nL_0177:\n\tv380 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0141:\n\tv627.<Current>k__BackingField = v574;\n")]
		private unsafe void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsBootstrap::Construct");
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0x3C7A5B8", Offset = "0x3C7A5B8", Length = "0x3CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001D;\nL_001D:\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv117 = this._buffers == 0;\n\tv148 = v114.<DefaultGameObjectInjectionWorld>k__BackingField;\n\tif (v117) goto L_0029;\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::Dispose(this._buffers);\n\tv148 = v114.<DefaultGameObjectInjectionWorld>k__BackingField;\nL_0029:\n\tv152 = this._conveyor == 0;\n\tif (v152) goto L_002E;\n\t_game.CoreSystem.ConveyorSystem.ConveyorController::Cleanup(this._conveyor);\nL_002E:\n\tv161 = this._movingCubes == 0;\n\tif (v161) goto L_0033;\n\t_game.CoreSystem.SandPhysics.Services.MovingCubeRegistry::Dispose(this._movingCubes);\nL_0033:\n\tv168 = this._sdf == 0;\n\tif (v168) goto L_0038;\n\t_game.CoreSystem.SandPhysics.SDF.SandSDFService::Dispose(this._sdf);\nL_0038:\n\t_game.CoreSystem.SandPhysics.SDF.SandSDFLogger::EndSession();\n\tv175 = this._collision == 0;\n\tif (v175) goto L_003E;\n\t_game.CoreSystem.SandPhysics.Services.SandCollisionService::Dispose(this._collision);\nL_003E:\n\tv178 = v148 == 0;\n\tif (v178) goto L_0096;\n\tv181 = Unity.Entities.World::get_IsCreated(v148);\n\tv212 = ~v181;\n\tif (v212) goto L_0096;\n\tv229 = Unity.Entities.World::get_EntityManager(v148);\n\tv207 = v229;\n\t// 77 NewArr v241 @ X0_v53 (Unity.Entities.ComponentType[]), typeof(Unity.Entities.ComponentType[]), 1\n\tgoto L_005A;\nL_005A:\n\tv272 = Unity.Entities.ComponentType::ReadOnly();\n\t*([v241 @ X0_v53 (Unity.Entities.ComponentType[])+20]) = v272;\n\tgoto L_006C;\nL_006C:\n\tv308 = Unity.Entities.EntityManager::CreateEntityQuery(&v207 @ stack_-48_v7 (Unity.Entities.EntityManager), v241);\n\tv312 = Unity.Entities.EntityQuery::get_IsEmptyIgnoreFilter(&v205 @ stack_-58_v8 (Unity.Entities.EntityQuery));\n\tv314 = v312 == 0;\n\tif (v314) goto L_00F3;\n\tv338 = this._singletonEntity;\n\tgoto L_007D;\nL_007D:\n\tv343 = Unity.Entities.EntityManager::Exists(&v207 @ stack_-48_v7 (Unity.Entities.EntityManager), v338);\n\tv356 = ~v343;\n\tv357 = ~v356;\n\tif (v357) goto L_010C;\n\tv401 = this._prototypeEntity;\n\tgoto L_0089;\nL_0089:\n\tv406 = Unity.Entities.EntityManager::Exists(&v207 @ stack_-48_v7 (Unity.Entities.EntityManager), v401);\n\tv419 = ~v406;\n\tv420 = ~v419;\n\tif (v420) goto L_0124;\n\tv201 = Unity.Entities.World::GetExistingSystemManaged(v148);\n\tv213 = v201 == 0;\n\tif (v213) goto L_0096;\nL_0094:\n\tv201._accumulator = 0f;\nL_00F3:\n\tgoto L_00F9;\nL_00F9:\n\tUnity.Entities.EntityManager::DestroyEntity(&v207 @ stack_-48_v7 (Unity.Entities.EntityManager), v205);\n\tv338 = *([B193078]);\n\tgoto L_007D;\nL_010C:\n\tgoto L_0111;\nL_0111:\n\tUnity.Entities.EntityManager::DestroyEntity(&v207 @ stack_-48_v7 (Unity.Entities.EntityManager), *([B193078]));\n\tv401 = *([B193080]);\n\tgoto L_0089;\nL_0124:\n\tgoto L_0129;\nL_0129:\n\tUnity.Entities.EntityManager::DestroyEntity(&v207 @ stack_-48_v7 (Unity.Entities.EntityManager), *([B193080]));\n\tv201 = Unity.Entities.World::GetExistingSystemManaged(v148);\n\tv449 = v201 == 0;\n\tv214 = ~v449;\n\tif (v214) goto L_0094;\n\tgoto L_0096;\nL_0096:\n\tv224 = Unity.Entities.Entity::get_Null();\n\tthis._singletonEntity = v224;\n\tv226 = Unity.Entities.Entity::get_Null();\n\tthis._prototypeEntity = v226;\n\tgoto L_00AA;\nL_00AA:\n\tv249.<Current>k__BackingField = 0;\n\treturn;\n")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsBootstrap::Dispose");
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0x3C7A36C", Offset = "0x3C7A36C", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_001F;\nL_001F:\n\tv90 = v88.<DefaultGameObjectInjectionWorld>k__BackingField == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0051;\nL_0029:\n\treturn;\nL_0051:\n\tv103 = Unity.Entities.World::GetExistingSystemManaged(v88.<DefaultGameObjectInjectionWorld>k__BackingField);\n\tv106 = v103 == 0;\n\tif (v106) goto L_0029;\n\tv176 = this._config;\n\tv159 = 1f / v176.PhysicsTickRate;\n\tv103._fixedDt = v159;\n\tv152 = v176.MaxSubSteps - 1;\n\tv149 = v152 < 0;\n\tv146 = v152 == 0;\n\tv143 = v176.MaxSubSteps ^ 1;\n\tv140 = v176.MaxSubSteps ^ v152;\n\tv137 = v143 & v140;\n\tv134 = v137 < 0;\n\tv187 = v149 == v134;\n\tv128 = ~v146;\n\tv131 = v187 & v128;\n\tv125 = ~v131;\n\tif (v125) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv175 = v176.MaxSubSteps;\n\tgoto L_0070;\nL_FFFFFFFF:\n\tv175 = 1;\nL_0070:\n\tv103._configured = 1;\n\tv103._accumulator = 0f;\n\tv103._maxSubSteps = v175;\n\tv103._timeMultiplier = 1f;\n\treturn;\n")]
		private void ConfigurePhysicsSystemGroup()
		{
			if (World.DefaultGameObjectInjectionWorld != null)
			{
				SandPhysicsSystemGroup existingSystemManaged = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<SandPhysicsSystemGroup>();
				if (existingSystemManaged != null)
				{
					SandPhysicsConfig config = _config;
					float fixedDt = 1f / (float)config.PhysicsTickRate;
					existingSystemManaged._fixedDt = fixedDt;
					int num = config.MaxSubSteps - 1;
					bool flag = num < 0;
					bool flag2 = num == 0;
					int num2 = config.MaxSubSteps ^ 1;
					int num3 = config.MaxSubSteps ^ num;
					int num4 = num2 & num3;
					bool flag3 = num4 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					int maxSubSteps = ((!(flag4 && flag5)) ? 1 : config.MaxSubSteps);
					existingSystemManaged._configured = true;
					existingSystemManaged._accumulator = 0f;
					existingSystemManaged._maxSubSteps = maxSubSteps;
					existingSystemManaged._timeMultiplier = 1f;
				}
			}
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0x3C7ABD0", Offset = "0x3C7ABD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandPhysicsBootstrap()
		{
		}
	}
}
