using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(SandSpawnSystem))]
	[Token(Token = "0x20000DA")]
	public struct GravitySystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000DB")]
		private struct GravityJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000DC")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000DD")]
				public struct TypeHandle
				{
					[Token(Token = "0x40002D9")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x40002DA")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x40002DB")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

					[Token(Token = "0x40002DC")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleSpawnAge> ___game_CoreSystem_SandPhysics_Components_ParticleSpawnAge_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x6000472")]
					[Address(RVA = "0x3C89F1C", Offset = "0x3C89F1C", Length = "0x144")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle = *([v97 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v97 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v97 @ X8_v7+20]);\n\tv122 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSpawnAge_RW_ComponentTypeHandle = v122.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = v122.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = v122.m_Length;\n\treturn;\nL_002E:\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v70;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = v62;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v72;\n\tv75 = &v83 @ stack_-A0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>);\n\tv79 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle = *([v75 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v75 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v75 @ X8_v5+20]);\n\tv97 = &v104 @ stack_-C8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv101 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000473")]
					[Address(RVA = "0x3C88E38", Offset = "0x3C88E38", Length = "0xD8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSpawnAge>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSpawnAge_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSpawnAge>), state);\n\treturn;\nL_002D:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x40002D7")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x40002D8")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600046A")]
				[Address(RVA = "0x3C89934", Offset = "0x3C89934", Length = "0x2A8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv82 = v78;\n\tv86 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v86;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v93;\n\tv98 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v98;\n\tv103 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v103;\n\tv109 = Unity.Entities.EntityQueryBuilder::Build(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v109;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+A8]) = state;\n\tv112 = Unity.Entities.EntityQueryBuilder::Reset(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002F:\n\tv62 = 0;\n\tv66 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v66);\n\tv78 = Unity.Entities.EntityQueryBuilder::WithAll(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticlePosition>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<ParticleSpawnAge>();
					entityQueryBuilder3 = entityQueryBuilder7;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x600046B")]
				[Address(RVA = "0x3C89BDC", Offset = "0x3C89BDC", Length = "0x17C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3C89A88(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv69 = &v70 @ stack_-10_v3;\n\tgoto L_0043;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+50]) = *([v127 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+60]) = *([v127 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+70]) = *([v127 @ X8_v7+20]);\n\tv152 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+78]) = v152.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+88]) = v152.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+98]) = v152.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0020;\nL_0043:\n\tv97 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+20]) = *([v69 @ X29_v2-48]);\n\tv35.__TypeHandle = *([v69 @ X29_v2-68]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+10]) = *([v69 @ X29_v2-58]);\n\tv105 = &v106 @ stack_-A0;\n\tv109 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+28]) = *([v105 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+38]) = *([v105 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData)+48]) = *([v105 @ X8_v5+20]);\n\tv127 = &v128 @ stack_-C8;\n\tv131 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600046C")]
				[Address(RVA = "0x3C89D58", Offset = "0x3C89D58", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x48;\n\tv54 = 0x8BF6A34(v51, this, 0xA0, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref GravityJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600046D")]
				[Address(RVA = "0x3C89DD8", Offset = "0x3C89DD8", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x48;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref GravityJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600046E")]
				[Address(RVA = "0x3C89E70", Offset = "0x3C89E70", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x48;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref GravityJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600046F")]
				[Address(RVA = "0x3C89F08", Offset = "0x3C89F08", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref GravityJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000470")]
				[Address(RVA = "0x3C89F0C", Offset = "0x3C89F0C", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref GravityJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000471")]
				[Address(RVA = "0x3C89F18", Offset = "0x3C89F18", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref GravityJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000DE")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000474")]
				[Address(RVA = "0x3C8A060", Offset = "0x3C8A060", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x40002C7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float2 gravity;

			[Token(Token = "0x40002C8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public float dt;

			[Token(Token = "0x40002C9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public float maxSpeed;

			[Token(Token = "0x40002CA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public float damping;

			[Token(Token = "0x40002CB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
			public float subThresholdDamping;

			[Token(Token = "0x40002CC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public float settleThreshold;

			[Token(Token = "0x40002CD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
			public bool flowZoneEnabled;

			[Token(Token = "0x40002CE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public float flowZoneYBottom;

			[Token(Token = "0x40002CF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			public float flowZoneYTop;

			[Token(Token = "0x40002D0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public float flowZoneGravityMultiplier;

			[Token(Token = "0x40002D1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public float flowZoneDamping;

			[Token(Token = "0x40002D2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public float2 flowZoneConvergeForce;

			[Token(Token = "0x40002D3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public float convergeCenterX;

			[Token(Token = "0x40002D4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x3C")]
			public float sandScale;

			[Token(Token = "0x40002D5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public float conveyorScale;

			[Token(Token = "0x40002D6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x6000450")]
			[Address(RVA = "0x3C88FC8", Offset = "0x3C88FC8", Length = "0x300")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = state.flags;\n\tv38 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsSettled(&v33 @ stack_-54_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv40 = v38 == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_00FF;\n\tv33 = state.flags;\n\tv48 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(&v33 @ stack_-54_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv143 = v48 == 0;\n\tv106 = ~v143;\n\tif (v106) goto L_00FF;\n\tv33 = state.flags;\n\tv114 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(&v33 @ stack_-54_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv147 = v114 == 0;\n\tv107 = ~v147;\n\tif (v107) goto L_00FF;\n\tv154 = spawnAge.value == 0xFFFF;\n\tif (v154) goto L_004A;\n\tv159 = spawnAge.value + 1;\n\tspawnAge.value = v159;\n\tv174 = pos.value.y < this.flowZoneYBottom;\n\tv175 = pos.value.y == this.flowZoneYBottom;\n\tv178 = pos.value.y == pos.value.y;\n\tv179 = this.flowZoneYBottom == this.flowZoneYBottom;\n\tv180 = v178 & v179;\n\tv181 = ~v180;\n\tv182 = v174 == v181;\n\tv183 = ~v182;\n\tv184 = v183 | v175;\n\tif (v184) goto L_0066;\n\tv195 = pos.value.y == this.flowZoneYTop;\n\tv205 = pos.value.y < this.flowZoneYTop;\n\tv201 = ~v205;\n\tv207 = ~v201;\n\tv186 = v207 | v195;\n\tif (v186) goto L_013E;\nL_0066:\n\tv208 = this.gravity;\nL_FFFFFFFF:\n\tv131 = 1;\n\tgoto L_0087;\n\tv259 = *([B193A96]) & 1;\n\tv260 = v259 == 0;\nL_FFFFFFFF:\n\tv290 = v310;\n\tif (v260) goto L_0118;\nL_009A:\n\tgoto L_009B;\nL_009B:\n\tv327 = v310 * v310;\n\t// 156 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv328 = UnityEngine.Mathf::Sqrt(v327);\n\tv333 = this.settleThreshold + this.settleThreshold;\n\tv65 = vel.value.y;\n\tv339 = v328 < 0x358637BD;\n\tv340 = v328 == 0x358637BD;\n\tv343 = v328 == v328;\n\tv346 = ~v343;\n\tv347 = v339 == v346;\n\tv53 = ~v340;\n\tv348 = v347 & v53;\n\tv61 = ~v348;\n\tif (v61) goto L_FFFFFFFF;\n\tv364 = v328 < v333;\n\tgoto L_00C0;\nL_FFFFFFFF:\n\tv364 = 0;\n\tv368 = *([B193A96]) & 1;\n\tv369 = v368 == 0;\nL_FFFFFFFF:\n\tv59 = vel.value;\nL_FFFFFFFF:\n\tv393 = vel.value;\nL_FFFFFFFF:\n\tv394 = v65;\n\tif (v369) goto L_0133;\nL_00C8:\n\tgoto L_00C9;\nL_00C9:\n\tv415 = v59 * v59;\n\tv416 = v65 * v65;\n\tv417 = v415 + v416;\n\tv76 = UnityEngine.Mathf::Sqrt(v417);\n\tv93 = v76 < this.maxSpeed;\n\tv90 = v76 == this.maxSpeed;\n\tv422 = v76 == v76;\n\tv87 = this.maxSpeed == this.maxSpeed;\n\tv96 = v422 & v87;\n\tv78 = ~v96;\n\tv423 = v93 == v78;\n\tv424 = ~v423;\n\tv67 = v424 | v90;\n\tif (v67) goto L_00FF;\n\tgoto L_00E9;\nL_00EB:\n\tv438 = vel.value * vel.value;\n\t// 236 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv439 = UnityEngine.Mathf::Sqrt(v438);\n\tv442 = vel.value * v248;\n\tv74 = v442 * v229;\n\tvel.value = v74;\nL_0102:\n\tv263 = this.convergeCenterX - 0.044426754f;\n\tv266 = v263 * this.flowZoneConvergeForce;\n\t// 263 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv268 = v266 * v252;\n\tv269 = v268 * v248;\n\tv310 = v310 + v269;\n\tvel.value = v310;\n\tv275 = *([B193A96]) & 1;\n\tv276 = v275 == 0;\n\tv277 = ~v276;\nL_FFFFFFFF:\n\tv290 = v310;\n\tif (v277) goto L_009A;\nL_0118:\n\t*([B193A96]) = 1;\nL_FFFFFFFF:\n\tv310 = v290;\n\tgoto L_009B;\nL_0120:\n\tv370 = v328 / v333;\n\tv373 = 1f - this.subThresholdDamping;\n\tv374 = v370 * v373;\n\tv375 = this.subThresholdDamping + v374;\n\tv59 = vel.value * v375;\n\tv65 = v65 * v375;\n\tvel.value.x = v59;\n\tvel.value.y = v65;\n\tv379 = *([B193A96]) & 1;\n\tv380 = v379 == 0;\n\tv381 = ~v380;\nL_FFFFFFFF:\n\tv393 = v59;\nL_FFFFFFFF:\n\tv394 = v65;\n\tif (v381) goto L_00C8;\nL_0133:\n\t*([B193A96]) = 1;\nL_FFFFFFFF:\n\tv59 = v393;\nL_FFFFFFFF:\n\tv65 = v394;\n\tgoto L_00C9;\nL_013E:\n\tv209 = this.gravity * v229;\nL_FFFFFFFF:\n\tv208 = v209;\nL_FFFFFFFF:\n\tv131 = 0;\n\tgoto L_006C;\nL_00FF:\n\treturn;\nL_004A:\n\tv171 = this.flowZoneEnabled != 1;\n\tif (v171) goto L_0066;\nL_0087:\n\tv246 = v208 * v229;\n\tv247 = v246 * v248;\n\tv249 = vel.value + v247;\n\tv310 = v249 * v252;\n\tvel.value = v310;\n\tv253 = v131 & 1;\n\tv254 = v253 == 0;\n\tif (v254) goto L_0102;\nL_00C0:\n\tif (v364) goto L_0120;\nL_00E9:\n\tgoto L_00EB;\nL_006C:\n\tv33 = state.flags;\n\tv228 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsOnConveyor(&v33 @ stack_-54_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv234 = v228 == 0;\n\tv238 = ~v234;\n\tv239 = ~v238;\n\tif (v239) goto L_0087;\n")]
			private void Execute(ref ParticleVelocity vel, in ParticlePosition pos, in ParticleState state, ref ParticleSpawnAge spawnAge)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x6000451")]
			[Address(RVA = "0x3C892C8", Offset = "0x3C892C8", Length = "0x50C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0042;\n\tv101 = this + 0xC0;\n\tv102 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v101);\n\tv109 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv115 = useEnabledMask == 0;\n\tif (v115) goto L_00EC;\n\tv121 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv122 = v121 ^ chunkEnabledMask.Byte0;\n\t// 98 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 100 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 101 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 102 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv123 = v60 + v122;\n\tv125 = v123 < 5;\n\tv126 = ~v125;\n\tv127 = v123 - 5;\n\tv129 = v127 == 0;\n\tv134 = ~v129;\n\tv135 = v126 & v134;\n\tif (v135) goto L_011F;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = 0;\n\tgoto L_0080;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = v517;\n\tv452 = ~v443;\n\tv454 = ~v420;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v195 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v452, v454);\n\tv288 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v195);\n\tv293 = v288 == 0;\n\tif (v293) goto L_01B4;\n\tv541 = v420 + v297;\n\tv517 = v288 + v541;\n\tv527 = v541 >= v517;\nL_FFFFFFFF:\n\tv579 = v288;\n\tif (v527) goto L_FFFFFFFF;\nL_00B3:\n\t;\n\tv584 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v541);\n\tv617 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v541);\n\tv640 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v541);\n\tv652 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v541);\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::Execute(this, v584, v617, v640, v652);\n\tv541 = v541 + 1;\n\tv580 = v579 - 1;\n\tv546 = v579 != 1;\nL_FFFFFFFF:\n\tv579 = v580;\n\tif (v546) goto L_00B3;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_00EC:\n\tv146 = v109 < 1;\n\tif (v146) goto L_01B4;\nL_FFFFFFFF:\n\tv385 = 0;\n\tv488 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v385);\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::Execute(this, v403, v426, v449, v488);\n\tv385 = v385 + 1;\n\tv218 = v109 != v385;\n\tif (v218) goto L_00FA;\n\tgoto L_01B4;\nL_011F:\n\tv156 = v109 - 0x40;\n\tv157 = v156 < 0;\n\tv159 = v109 ^ 0x40;\n\tv160 = v109 ^ v156;\n\tv161 = v159 & v160;\n\tv162 = v161 < 0;\n\tv164 = v157 == v162;\n\tv165 = ~v164;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv298 = v109;\n\tgoto L_0139;\nL_FFFFFFFF:\n\tv298 = 0x40;\nL_FFFFFFFF:\n\tv302 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv483 = 0;\n\tgoto L_014C;\nL_0140:\n\tv302 = v302 >> 1;\n\tv483 = v483 + 1;\n\tv469 = v298 == v483;\n\tif (v469) goto L_017B;\nL_014C:\n\tv484 = v302 & 1;\n\tv294 = v484 == 0;\n\tif (v294) goto L_0140;\n\tv495 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v483);\n\tv511 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v483);\n\tv533 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v483);\n\tv592 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v483);\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::Execute(this, v495, v511, v533, v592);\n\tgoto L_0140;\nL_017B:\n\tv219 = v109 < 0x41;\n\tif (v219) goto L_01B4;\n\tv535 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv596 = 0x40;\n\tgoto L_018D;\nL_0181:\n\tv299 = v535 >> 1;\n\tv596 = v596 + 1;\n\tv249 = v109 == v596;\nL_FFFFFFFF:\n\tv535 = v299;\n\tif (v249) goto L_01B4;\nL_018D:\n\tv613 = v535 & 1;\n\tv295 = v613 == 0;\n\tif (v295) goto L_0181;\n\tv623 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v596);\n\tv646 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v596);\n\tv658 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v596);\n\tv663 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v596);\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::Execute(this, v623, v646, v658, v663);\n\tgoto L_0181;\nL_01B4:\n\tv324 = *([A4731E0]);\n\tv335 = *([v324 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v335) goto L_01CF;\n\treturn;\nL_01CF:\n\tv416 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0042:\n\tv74 = this + 0x48;\n\tv75 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v74);\n\tv83 = this + 0x70;\n\tv84 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v83);\n\tv92 = this + 0x98;\n\tv93 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v92);\nL_0080:\n\tv375 = v271;\n\tv379 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v297);\n\tv375 = v379;\n\tv420 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v379);\n\tv443 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v420);\nL_00FA:\n\tv403 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v385);\n\tv426 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v385);\n\tv449 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v385);\nL_0139:\n\tv220 = v109 < 1;\n\tif (v220) goto L_01B4;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob::Execute");
			}

			[Token(Token = "0x6000452")]
			[Address(RVA = "0x3C897D4", Offset = "0x3C897D4", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem.GravityJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x6000453")]
			[Address(RVA = "0x3C89828", Offset = "0x3C89828", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000454")]
			[Address(RVA = "0x3C89834", Offset = "0x3C89834", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000455")]
			[Address(RVA = "0x3C89840", Offset = "0x3C89840", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000456")]
			[Address(RVA = "0x3C8984C", Offset = "0x3C8984C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000457")]
			[Address(RVA = "0x3C89858", Offset = "0x3C89858", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000458")]
			[Address(RVA = "0x3C89864", Offset = "0x3C89864", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000459")]
			[Address(RVA = "0x3C89870", Offset = "0x3C89870", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600045A")]
			[Address(RVA = "0x3C8987C", Offset = "0x3C8987C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600045B")]
			[Address(RVA = "0x3C89888", Offset = "0x3C89888", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600045C")]
			[Address(RVA = "0x3C89894", Offset = "0x3C89894", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600045D")]
			[Address(RVA = "0x3C898A0", Offset = "0x3C898A0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600045E")]
			[Address(RVA = "0x3C898AC", Offset = "0x3C898AC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600045F")]
			[Address(RVA = "0x3C898B8", Offset = "0x3C898B8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000460")]
			[Address(RVA = "0x3C898C4", Offset = "0x3C898C4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000461")]
			[Address(RVA = "0x3C898D0", Offset = "0x3C898D0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000462")]
			[Address(RVA = "0x3C898DC", Offset = "0x3C898DC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000463")]
			[Address(RVA = "0x3C898E8", Offset = "0x3C898E8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000464")]
			[Address(RVA = "0x3C898F4", Offset = "0x3C898F4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000465")]
			[Address(RVA = "0x3C89900", Offset = "0x3C89900", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000466")]
			[Address(RVA = "0x3C8990C", Offset = "0x3C8990C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000467")]
			[Address(RVA = "0x3C89918", Offset = "0x3C89918", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000468")]
			[Address(RVA = "0x3C89924", Offset = "0x3C89924", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000469")]
			[Address(RVA = "0x3C89930", Offset = "0x3C89930", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000DF")]
		private struct TypeHandle
		{
			[Token(Token = "0x40002DD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public GravityJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_GravitySystem_GravityJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6000475")]
			[Address(RVA = "0x3C8A064", Offset = "0x3C8A064", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 0x3C89A88(this, state, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv36 = 0x3C89C14(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C89A88 (inside _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C89C14 (inside _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData::Init +0x38)");
			}
		}

		[Token(Token = "0x40002C6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x6000448")]
		[Address(RVA = "0x3C88958", Offset = "0x3C88958", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x6000449")]
		[Address(RVA = "0x3C889AC", Offset = "0x3C889AC", Length = "0x3EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv48 = *([B78D75E]) & 1;\n\tv49 = v48 == 0;\n\tif (v49) goto L_0035;\n\tv75 = 0xB293000 + 0xDC8;\n\tv54 = *([B193A9A]) & 1;\n\tv55 = v54 == 0;\nL_FFFFFFFF:\n\tv89 = v75;\n\tif (v55) goto L_0042;\nL_0024:\n\tv83 = *([v75 @ X22_v10 (System.Int32)]);\n\tv84 = *([v83 @ X8_v31+B8]);\n\tv100 = *([v84 @ X8_v32]);\n\tv86 = *([v84 @ X8_v32]) == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_004E;\n\tgoto L_0155;\nL_0035:\n\t*([B19375E]) = 1;\n\tv75 = 0xB293000 + 0xDC8;\n\tv304 = *([B193A9A]) & 1;\n\tv305 = v304 == 0;\n\tv78 = ~v305;\nL_FFFFFFFF:\n\tv89 = v75;\n\tif (v78) goto L_0024;\nL_0042:\n\t*([B193A9A]) = 1;\n\tv115 = *([v89 @ X22_v7 (System.Int32)]);\n\tv106 = *([v115 @ X8_v26+B8]);\n\tv100 = *([v106 @ X8_v27]);\n\tv104 = *([v106 @ X8_v27]) == 0;\n\tif (v104) goto L_0155;\nL_004E:\n\tgoto L_0052;\nL_0052:\n\tv266 = UnityEngine.Object::op_Equality(*([v100 @ X23_v3+48]), 0);\n\tv274 = v266 == 0;\n\tif (v274) goto L_0063;\n\tgoto L_0155;\nL_0063:\n\tv409 = Unity.Entities.SystemState::get_Dependency(state);\n\t_game.CoreSystem.SandPhysics.Services.SandCollisionService::FlushIfDirty(*([v100 @ X23_v3+10]), v409);\n\tv438 = *([v100 @ X23_v3+48]);\n\tv248 = state.WorldUnmanaged;\n\tgoto L_007D;\nL_007D:\n\tv454 = Unity.Entities.WorldUnmanaged::get_Time(&v248 @ stack_-A8_v3 (Unity.Entities.WorldUnmanaged));\n\tv456 = *([v438 @ X22_v5+8C]) * *([v100 @ X23_v3+3C]);\n\tv432 = v456 / v454.DeltaTime;\n\tv458 = v432 & 0x7FFFFFFF;\n\tv459 = v458 < 0x7F800000;\n\tv460 = ~v459;\n\tv461 = v458 - 0x7F800000;\n\tv463 = v461 == 0;\n\tv466 = ~v460;\n\tv467 = v466 | v463;\n\tv468 = ~v467;\n\tif (v468) goto L_FFFFFFFF;\n\tv483 = *([v438 @ X22_v5+34]) < v432;\n\tgoto L_00A2;\nL_FFFFFFFF:\n\tv483 = 1;\n\tgoto L_00AA;\n\tv442 = *([v100 @ X23_v3+60]);\n\tgoto L_00BD;\nL_00BD:\n\tv518 = UnityEngine.Object::op_Inequality(*([v100 @ X23_v3+60]), 0);\n\tv562 = ~v518;\n\tv522 = ~v562;\nL_FFFFFFFF:\n\t;\n\tif (v522) goto L_00D5;\nL_FFFFFFFF:\n\t;\n\tgoto L_00EC;\nL_00D5:\n\tv494 = *([v442 @ X21_v13 (UnityEngine.Object)+188]) != 1;\n\tif (v494) goto L_00EC;\n\tv580 = *([v442 @ X21_v13 (UnityEngine.Object)+194]) & 1;\n\tv521 = v580 == 0;\n\tif (v521) goto L_015A;\nL_00EE:\n\tgoto L_00F2;\nL_0155:\n\treturn;\nL_015A:\n\tv587 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMin(*([v100 @ X23_v3+60]));\n\tv606 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMax(*([v100 @ X23_v3+60]));\n\tgoto L_00EC;\nL_00A2:\n\tv207 = ~v483;\n\tif (v207) goto L_00AA;\nL_00AA:\n\tv428 = *([v438 @ X22_v5+6C]) < 0;\n\tv427 = *([v438 @ X22_v5+6C]) == 0;\n\tv429 = *([v438 @ X22_v5+6C]) == *([v438 @ X22_v5+6C]);\n\tv423 = ~v429;\n\tv489 = v428 == v423;\n\tv490 = ~v489;\n\tv422 = v490 | v427;\nL_FFFFFFFF:\n\t;\n\tif (v422) goto L_00EC;\nL_00F2:\n\tv147 = &v193 @ stack_-190_v2 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob);\n\tv573 = Unity.Entities.SystemState::get_Dependency(state);\n\tv193 = *([v438 @ X22_v5+2C]);\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_0120;\nL_0120:\n\t*([v147 @ X26_v3+A8]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem)+60]);\n\t*([v147 @ X26_v3+B8]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem)+70]);\n\t*([v147 @ X26_v3+C8]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem)+80]);\n\t*([v147 @ X26_v3+D8]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem)+90]);\n\t*([v147 @ X26_v3+88]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GravitySystem)+40]);\n\t*([v147 @ X26_v3+98]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_GravitySystem_GravityJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;\n\tv605 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v193 @ stack_-190_v2 (_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_GravitySystem_GravityJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v573);\n\tUnity.Entities.SystemState::set_Dependency(state, v605);\nL_00EC:\n\tgoto L_00EE;\n")]
		public void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600044A")]
		[Address(RVA = "0x3C88D98", Offset = "0x3C88D98", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_0023;\nL_0023:\n\tv58 = job + 0x48;\n\tv61 = 0x8BF6A34(v58, this, 0xA0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(GravityJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GravitySystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600044B")]
		[Address(RVA = "0x3C88F10", Offset = "0x3C88F10", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0x3C88F54", Offset = "0x3C88F54", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3C89A88(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3C89C14(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C89A88 (inside _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C89C14 (inside _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600044D")]
		[Address(RVA = "0x3C8888C", Offset = "0x3C8888C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600044E")]
		[Address(RVA = "0x3C888E0", Offset = "0x3C888E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.GravitySystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((GravitySystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600044F")]
		[Address(RVA = "0x3C888E4", Offset = "0x3C888E4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3C89A88(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3C89C14(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C89A88 (inside _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C89C14 (inside _game.CoreSystem.SandPhysics.Systems.GravitySystem+GravityJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}
	}
}
