using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.CollisionSystem.ECS.Tags;
using _game.CoreSystem.FrameSystem;
using _game.CoreSystem.FrameSystem.MeshGen;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using Debug = UnityEngine.Debug;

namespace _game.CoreSystem.CollisionSystem
{
	[Token(Token = "0x2000511")]
	public static class CollisionGeometryBuilder
	{
		[Token(Token = "0x2000512")]
		public class WallGeometry
		{
			[Token(Token = "0x4001120")]
			[FieldOffset(Offset = "0x10")]
			public readonly List<float2> vertices;

			[Token(Token = "0x4001121")]
			[FieldOffset(Offset = "0x18")]
			public readonly List<CollisionShape> shapes;

			[Token(Token = "0x4001122")]
			[FieldOffset(Offset = "0x20")]
			public readonly List<float2> edgeNormals;

			[Token(Token = "0x4001123")]
			[FieldOffset(Offset = "0x28")]
			public readonly List<float4> aabbs;

			[Token(Token = "0x6001540")]
			[Address(RVA = "0x3D0D8A0", Offset = "0x3D0D8A0", Length = "0x158")]
			public WallGeometry()
			{
				List<float2> list = new List<float2>();
				vertices = list;
				List<CollisionShape> list2 = new List<CollisionShape>();
				shapes = list2;
				List<float2> list3 = new List<float2>();
				edgeNormals = list3;
				List<float4> list4 = new List<float4>();
				aabbs = list4;
			}
		}

		[Token(Token = "0x2000513")]
		public struct BlockerQuad
		{
			[Token(Token = "0x4001124")]
			[FieldOffset(Offset = "0x0")]
			public float2 v0;

			[Token(Token = "0x4001125")]
			[FieldOffset(Offset = "0x8")]
			public float2 v1;

			[Token(Token = "0x4001126")]
			[FieldOffset(Offset = "0x10")]
			public float2 v2;

			[Token(Token = "0x4001127")]
			[FieldOffset(Offset = "0x18")]
			public float2 v3;
		}

		[CompilerGenerated]
		[Token(Token = "0x2000514")]
		private sealed class _003CEnumerateBlockerCoords_003Ed__4 : IEnumerable<GridCoord>, IEnumerable, IEnumerator<GridCoord>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001128")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4001129")]
			[FieldOffset(Offset = "0x14")]
			private GridCoord _003C_003E2__current;

			[Token(Token = "0x400112A")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x400112B")]
			[FieldOffset(Offset = "0x28")]
			private EntityManager entityManager;

			[Token(Token = "0x400112C")]
			[FieldOffset(Offset = "0x30")]
			public EntityManager _003C_003E3__entityManager;

			[Token(Token = "0x400112D")]
			[FieldOffset(Offset = "0x38")]
			private IReadOnlyList<Entity> _003Cblockers_003E5__2;

			[Token(Token = "0x400112E")]
			[FieldOffset(Offset = "0x40")]
			private HashSet<GridCoord> _003Cseen_003E5__3;

			[Token(Token = "0x400112F")]
			[FieldOffset(Offset = "0x48")]
			private int _003Ci_003E5__4;

			[Token(Token = "0x170001E4")]
			GridCoord IEnumerator<GridCoord>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001544")]
				[Address(RVA = "0x3D0F200", Offset = "0x3D0F200", Length = "0x10")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170001E5")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001546")]
				[Address(RVA = "0x3D0F250", Offset = "0x3D0F250", Length = "0x70")]
				get
				{
					GridCoord gridCoord = _003C_003E2__current;
					return gridCoord;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001541")]
			[Address(RVA = "0x3D0EB20", Offset = "0x3D0EB20", Length = "0x38")]
			public _003CEnumerateBlockerCoords_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001542")]
			[Address(RVA = "0x3D0EF1C", Offset = "0x3D0EF1C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001543")]
			[Address(RVA = "0x3D0EF20", Offset = "0x3D0EF20", Length = "0x2E0")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder._003CEnumerateBlockerCoords_003Ed__4::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001545")]
			[Address(RVA = "0x3D0F210", Offset = "0x3D0F210", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001547")]
			[Address(RVA = "0x3D0F2C0", Offset = "0x3D0F2C0", Length = "0xA8")]
			IEnumerator<GridCoord> IEnumerable<GridCoord>.GetEnumerator()
			{
				_003CEnumerateBlockerCoords_003Ed__4 _003CEnumerateBlockerCoords_003Ed__5;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CEnumerateBlockerCoords_003Ed__5 = this;
						goto IL_00b5;
					}
				}
				_003CEnumerateBlockerCoords_003Ed__4 _003CEnumerateBlockerCoords_003Ed__6 = (_003CEnumerateBlockerCoords_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CEnumerateBlockerCoords_003Ed__4));
				_003CEnumerateBlockerCoords_003Ed__6._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CEnumerateBlockerCoords_003Ed__6._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CEnumerateBlockerCoords_003Ed__5 = _003CEnumerateBlockerCoords_003Ed__6;
				goto IL_00b5;
				IL_00b5:
				_003CEnumerateBlockerCoords_003Ed__5.entityManager = _003C_003E3__entityManager;
				return _003CEnumerateBlockerCoords_003Ed__5;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001548")]
			[Address(RVA = "0x3D0F368", Offset = "0x3D0F368", Length = "0x4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<GridCoord>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x6001538")]
		[Address(RVA = "0x3D0D7D4", Offset = "0x3D0D7D4", Length = "0xCC")]
		public unsafe static WallGeometry BuildWalls(FrameController frameController)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder::BuildWalls");
			return default;
		}

		[Token(Token = "0x6001539")]
		[Address(RVA = "0x3D0E87C", Offset = "0x3D0E87C", Length = "0x21C")]
		public static bool TryBuildBlockerQuad(TopGridHandler topGridHandler, TopGridVisualGridController gridController, GridCoord coord, float extraInset, out BlockerQuad quad)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder::TryBuildBlockerQuad");
			quad = default;
			return default;
		}

		[IteratorStateMachine(typeof(_003CEnumerateBlockerCoords_003Ed__4))]
		[Token(Token = "0x600153A")]
		[Address(RVA = "0x3D0EA98", Offset = "0x3D0EA98", Length = "0x88")]
		public static IEnumerable<GridCoord> EnumerateBlockerCoords(EntityManager entityManager)
		{
			_003CEnumerateBlockerCoords_003Ed__4 _003CEnumerateBlockerCoords_003Ed__5 = new _003CEnumerateBlockerCoords_003Ed__4(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CEnumerateBlockerCoords_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId;
			_003CEnumerateBlockerCoords_003Ed__5._003C_003E3__entityManager = entityManager;
			return _003CEnumerateBlockerCoords_003Ed__5;
		}

		[Token(Token = "0x600153B")]
		[Address(RVA = "0x3D0D9F8", Offset = "0x3D0D9F8", Length = "0x340")]
		private static void AddWallSegments(WallSegment[] walls, WallGeometry geom)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder::AddWallSegments");
		}

		[Token(Token = "0x600153C")]
		[Address(RVA = "0x3D0DD38", Offset = "0x3D0DD38", Length = "0x710")]
		private static void BuildLoopPolygons(FrameData frameData, out float2[][] playablePolygons, out float2[][] blockedPolygons)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder::BuildLoopPolygons");
			playablePolygons = default;
			blockedPolygons = default;
		}

		[Token(Token = "0x600153D")]
		[Address(RVA = "0x3D0E448", Offset = "0x3D0E448", Length = "0x434")]
		private static void ComputeWallNormals(WallGeometry geom, float2[][] playablePolygons, float2[][] blockedPolygons)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder::ComputeWallNormals");
		}

		[Token(Token = "0x600153E")]
		[Address(RVA = "0x3D0ED18", Offset = "0x3D0ED18", Length = "0x204")]
		private static float2 ComputeNormalFromCentroid(float2 mid, float2 candidateA, float2 candidateB, float2[][] playablePolygons)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder::ComputeNormalFromCentroid");
			return default;
		}

		[Token(Token = "0x600153F")]
		[Address(RVA = "0x3D0EB58", Offset = "0x3D0EB58", Length = "0x1C0")]
		private static bool IsActualPlayable(float2 point, float2[][] playablePolygons, float2[][] blockedPolygons)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollisionGeometryBuilder::IsActualPlayable");
			return default;
		}
	}
}
