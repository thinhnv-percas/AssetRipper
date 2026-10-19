using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using HighlightPlus;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Shared.Blocker;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker
{
	[Token(Token = "0x2000181")]
	public class SnakeBlockerVisualHandler : ITopGridVisualHandler
	{
		[Token(Token = "0x2000182")]
		private class TrackedPiece
		{
			[Token(Token = "0x40004C7")]
			[FieldOffset(Offset = "0x10")]
			public GameObject go;

			[Token(Token = "0x40004C8")]
			[FieldOffset(Offset = "0x18")]
			public GridCoord requiredA;

			[Token(Token = "0x40004C9")]
			[FieldOffset(Offset = "0x24")]
			public GridCoord? requiredB;

			[Token(Token = "0x6000748")]
			[Address(RVA = "0x3E676B8", Offset = "0x3E676B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public TrackedPiece()
			{
			}
		}

		[Token(Token = "0x2000183")]
		private class ChainData
		{
			[Token(Token = "0x40004CA")]
			[FieldOffset(Offset = "0x10")]
			public Transform root;

			[Token(Token = "0x40004CB")]
			[FieldOffset(Offset = "0x18")]
			public HighlightEffect highlight;

			[Token(Token = "0x40004CC")]
			[FieldOffset(Offset = "0x20")]
			public readonly List<TrackedPiece> pieces;

			[Token(Token = "0x40004CD")]
			[FieldOffset(Offset = "0x28")]
			public List<GridCoord> path;

			[Token(Token = "0x6000749")]
			[Address(RVA = "0x3E67560", Offset = "0x3E67560", Length = "0x158")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>::.ctor(v48);\n\tthis.pieces = v48;\n")]
			public ChainData()
			{
				List<TrackedPiece> list = new List<TrackedPiece>();
				pieces = list;
			}
		}

		[Inject(false)]
		[Token(Token = "0x40004C1")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40004C2")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x40004C3")]
		[FieldOffset(Offset = "0x20")]
		private SnakeBlockerConfig _config;

		[Token(Token = "0x40004C4")]
		[FieldOffset(Offset = "0x28")]
		private readonly Dictionary<int, ChainData> _chainBySnakeId;

		[Token(Token = "0x40004C5")]
		[FieldOffset(Offset = "0x30")]
		private readonly Dictionary<int, Tween> _pendingRebuilds;

		[Token(Token = "0x40004C6")]
		[FieldOffset(Offset = "0x38")]
		private Transform _parent;

		[Token(Token = "0x170000A4")]
		public SnakeBlockerConfig Config
		{
			[Token(Token = "0x6000732")]
			[Address(RVA = "0x3E62588", Offset = "0x3E62588", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Config;\n")]
			get
			{
				return _config;
			}
		}

		[Token(Token = "0x170000A5")]
		public float FallZDuration
		{
			[Token(Token = "0x6000733")]
			[Address(RVA = "0x3E62590", Offset = "0x3E62590", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.Config, 0);\n\tv64 = ~v55;\n\tv65 = ~v64;\n\tif (v65) goto L_0038;\n\treturn 0;\nL_0038:\n\tv92 = this.Config;\n\treturn v92.fallMoveZSettings;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::get_FallZDuration");
				return default;
			}
		}

		[Token(Token = "0x6000734")]
		[Address(RVA = "0x3E62650", Offset = "0x3E62650", Length = "0x56C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\n\tv83.cubeTransform = cubeTransform;\n\tv83.startWorldPos.x = startWorldPos;\n\tv83.startWorldPos.y = startWorldPos.y;\n\tv83.startWorldPos.z = startWorldPos.z;\n\tv83.targetWorldPos.x = targetWorldPos;\n\tv83.targetWorldPos.y = targetWorldPos.y;\n\tv83.targetWorldPos.z = targetWorldPos.z;\n\tgoto L_0063;\nL_0063:\n\tv321 = UnityEngine.Object::op_Equality(v83.cubeTransform, 0);\n\tv433 = v321 == 0;\n\tif (v433) goto L_0075;\n\tgoto L_01CD;\nL_0075:\n\tgoto L_0079;\nL_0079:\n\tv479 = UnityEngine.Object::op_Equality(this.Config, 0);\n\tv484 = v479 == 0;\n\tif (v484) goto L_008E;\n\tgoto L_01CD;\nL_008E:\n\t// 142 MakeStruct v209 @ AGG3E627F8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v83.startWorldPos (UnityEngine.Vector3), v83.startWorldPos.y (System.Single), v83.startWorldPos.z (System.Single)\n\tUnityEngine.Transform::set_position(v83.cubeTransform, v209);\n\tv275 = this.Config;\n\tv204 = v275.fallMoveXYSettings;\n\tv244 = PrimeTween.Tween::PositionX(v83.cubeTransform, v83.targetWorldPos, &v204 @ stack_-E0_v3 (PrimeTween.TweenSettings));\n\tv276 = this.Config;\n\tv204 = v276.fallMoveXYSettings;\n\tv245 = PrimeTween.Tween::PositionY(v83.cubeTransform, v83.targetWorldPos.y, &v204 @ stack_-E0_v3 (PrimeTween.TweenSettings));\n\tv277 = this.Config;\n\tv83.zCurve = v277.fallZCurve;\n\tv278 = this.Config;\n\tv83.zMultiplier = v278.fallZMultiplier;\n\tv520 = new System.Action`1<System.Single>();\n\tSystem.Action`1<System.Single>::.ctor(v520, v83, Il2CppMethodInfo);\n\tv174 = v278.fallMoveZSettings;\n\tv530 = PrimeTween.Tween::Custom(0f, 1f, &v174 @ stack_-110_v3 (PrimeTween.TweenSettings), v520);\n\tgoto L_00E8;\n\tv300 = v154.one.z * targetScale;\n\tv305 = v154.one.y * targetScale;\n\tv214 = v154.one * targetScale;\n\tv174 = v286.fallScaleSettings;\n\t// 254 MakeStruct v149 @ AGG3E62964_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v214 @ V0_v13 (System.Single), v305 @ V1_v13 (System.Single), v300 @ V2_v7 (System.Single)\n\tv247 = PrimeTween.Tween::Scale(v83.cubeTransform, v149, &v174 @ stack_-110_v3 (PrimeTween.TweenSettings));\n\tv279 = this.Config;\n\tgoto L_010A;\nL_010A:\n\tv552 = UnityEngine.Object::op_Inequality(v279.fallParticle, 0);\n\tv556 = ~v552;\n\tv557 = ~v556;\n\tif (v557) goto L_011E;\n\tv564 = outPositionTweens == 0;\n\tv486 = ~v564;\n\tif (v486) goto L_014C;\n\tgoto L_01CD;\nL_011E:\n\tv248 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+<>c__DisplayClass12_1();\n\tSystem.Object::.ctor(v248);\n\tv248.CS$<>8__locals1 = v83;\n\tv281 = this.Config;\n\tv248.particlePrefab = v281.fallParticle;\n\tv282 = this.Config;\n\tv618 = new System.Action();\n\tSystem.Action::.ctor(v618, v248, Il2CppMethodInfo);\n\tv482 = PrimeTween.Tween::Delay(v282.fallParticleInsertTime, v618, 0, 1);\n\tv487 = outPositionTweens == 0;\n\tif (v487) goto L_01CD;\nL_014C:\n\t;\n\tgoto L_016D;\nL_016D:\n\tSystem.Collections.Generic.List`1<PrimeTween.Tween>::Add(outPositionTweens, v244);\n\tgoto L_0193;\nL_0193:\n\tSystem.Collections.Generic.List`1<PrimeTween.Tween>::Add(outPositionTweens, v245);\n\tgoto L_01B7;\nL_01B7:\n\tSystem.Collections.Generic.List`1<PrimeTween.Tween>::Add(outPositionTweens, v530);\nL_01CD:\n\treturn;\nL_0047:\n\tv83 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v83);\nL_00E8:\n\tv286 = this.Config;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayFall(Transform cubeTransform, Vector3 startWorldPos, Vector3 targetWorldPos, float targetScale, List<Tween> outPositionTweens = null)
		{
			Vector3 startWorldPos2 = default(Vector3);
			startWorldPos2.x = startWorldPos.x;
			startWorldPos2.y = startWorldPos.y;
			startWorldPos2.z = startWorldPos.z;
			Vector3 targetWorldPos2 = default(Vector3);
			targetWorldPos2.x = targetWorldPos.x;
			targetWorldPos2.y = targetWorldPos.y;
			targetWorldPos2.z = targetWorldPos.z;
			if (cubeTransform == null || Config == null)
			{
				return;
			}
			Vector3 position = default(Vector3);
			position.x = startWorldPos2.x;
			position.y = startWorldPos2.y;
			position.z = startWorldPos2.z;
			cubeTransform.position = position;
			SnakeBlockerConfig config = Config;
			TweenSettings fallMoveXYSettings = config.fallMoveXYSettings;
			Tween item = Tween.PositionX(cubeTransform, targetWorldPos2.x, fallMoveXYSettings);
			SnakeBlockerConfig config2 = Config;
			fallMoveXYSettings = config2.fallMoveXYSettings;
			Tween item2 = Tween.PositionY(cubeTransform, targetWorldPos2.y, fallMoveXYSettings);
			SnakeBlockerConfig config3 = Config;
			AnimationCurve zCurve = config3.fallZCurve;
			SnakeBlockerConfig config4 = Config;
			float zMultiplier = config4.fallZMultiplier;
			Action<float> onValueChange = delegate(float t)
			{
				if (!(cubeTransform == null))
				{
					Vector3 position2 = cubeTransform.position;
					float num = zCurve.Evaluate(t);
					float num2 = targetWorldPos2.z - startWorldPos2.z;
					bool flag = t < 1f;
					bool flag2 = t == 1f;
					bool flag3 = t == t;
					bool flag4 = 1f == 1f;
					bool flag5 = flag3 && flag4;
					bool flag6 = !flag5;
					bool flag7 = flag == flag6;
					bool flag8 = !flag2;
					float num3 = ((!(flag7 && flag8)) ? t : 1f);
					if (t < 0f)
					{
						num3 = 0f;
					}
					float num4 = num3 * num2;
					float num5 = startWorldPos2.z + num4;
					float num6 = num * zMultiplier;
					float z2 = num5 + num6;
					Vector3 position3 = default(Vector3);
					position3.x = position2.x;
					position3.y = position2.y;
					position3.z = z2;
					cubeTransform.position = position3;
				}
			};
			TweenSettings fallMoveZSettings = config4.fallMoveZSettings;
			Tween item3 = Tween.Custom(0f, 1f, fallMoveZSettings, onValueChange);
			SnakeBlockerConfig config5 = Config;
			float z = Vector3.one.z * targetScale;
			float y = Vector3.one.y * targetScale;
			float x = Vector3.one.x * targetScale;
			fallMoveZSettings = config5.fallScaleSettings;
			Vector3 endValue = default(Vector3);
			endValue.x = x;
			endValue.y = y;
			endValue.z = z;
			Tween tween = Tween.Scale(cubeTransform, endValue, fallMoveZSettings);
			SnakeBlockerConfig config6 = Config;
			if (!(config6.fallParticle != null))
			{
				if (outPositionTweens == null)
				{
					return;
				}
			}
			else
			{
				SnakeBlockerConfig config7 = Config;
				GameObject particlePrefab = config7.fallParticle;
				SnakeBlockerConfig config8 = Config;
				Action onComplete = delegate
				{
					Vector3 position2 = default(Vector3);
					position2.x = targetWorldPos2.x;
					position2.y = targetWorldPos2.y;
					position2.z = targetWorldPos2.z;
					Quaternion rotation = default(Quaternion);
					rotation.x = Quaternion.identity.x;
					rotation.y = Quaternion.identity.y;
					rotation.z = Quaternion.identity.z;
					rotation.w = Quaternion.identity.w;
					GameObject gameObject = UnityEngine.Object.Instantiate(particlePrefab, position2, rotation);
				};
				Tween tween2 = Tween.Delay(config8.fallParticleInsertTime, onComplete);
				if (outPositionTweens == null)
				{
					return;
				}
			}
			outPositionTweens.Add(item);
			outPositionTweens.Add(item2);
			outPositionTweens.Add(item3);
		}

		[Token(Token = "0x6000735")]
		[Address(RVA = "0x3E62BCC", Offset = "0x3E62BCC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._parent = visualParent;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::ResyncAll(this);\n\treturn;\n")]
		public void InitVisuals(Transform visualParent)
		{
			_parent = visualParent;
			ResyncAll();
		}

		[Token(Token = "0x6000736")]
		[Address(RVA = "0x3E62BF4", Offset = "0x3E62BF4", Length = "0x3DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004A;\n\tv71 = System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>::get_Values(this._pendingRebuilds);\n\tv212 = v71 == 0;\n\tv200 = Il2CppMethodInfo;\n\tif (v212) goto L_010B;\n\tv181 = 0xB2A8000 + 0x918;\n\tv243 = &v173 @ stack_-E8 (System.Int32);\n\tv244 = System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>+ValueCollection<System.Int32, PrimeTween.Tween>::GetEnumerator(v71);\n\tv126 = v173.m_value;\n\tv268 = *([v243 @ X8_v9+10]);\n\tv274 = PrimeTween.Tween::get_isAlive(&v268 @ stack_-90_v5 (PrimeTween.Tween));\n\tv277 = v274 == 0;\n\tif (v277) goto L_007A;\n\tPrimeTween.Tween::Stop(&v268 @ stack_-90_v5 (PrimeTween.Tween));\n\tgoto L_007A;\nL_008C:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>+ValueCollection<System.Int32, PrimeTween.Tween>+Enumerator<System.Int32, PrimeTween.Tween>::Dispose(&v126 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>+ValueCollection<System.Int32, PrimeTween.Tween>+Enumerator<System.Int32, PrimeTween.Tween>));\n\tv213 = this._pendingRebuilds == 0;\n\tv165 = &v126 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>+ValueCollection<System.Int32, PrimeTween.Tween>+Enumerator<System.Int32, PrimeTween.Tween>);\n\tv173 = 0;\n\tv200 = Il2CppMethodInfo;\n\tif (v213) goto L_010B;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>::Clear(this._pendingRebuilds);\n\tv214 = this._chainBySnakeId == 0;\n\tv165 = &v126 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>+ValueCollection<System.Int32, PrimeTween.Tween>+Enumerator<System.Int32, PrimeTween.Tween>);\n\tv173 = 0;\n\tv200 = Il2CppMethodInfo;\n\tif (v214) goto L_010B;\n\tv389 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::GetEnumerator(this._chainBySnakeId);\n\tv109 = v389._dictionary;\n\tgoto L_00B1;\nL_00AE:\n\tUnityEngine.Object::DestroyImmediate(v454);\nL_00B1:\n\tv421 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v109 @ stack_-C0_v4 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>));\n\tv316 = v421 == 0;\n\tif (v316) goto L_00F1;\n\tv425 = v424 == 0;\n\tif (v425) goto L_0105;\n\tgoto L_00C2;\nL_00C2:\n\tv407 = UnityEngine.Object::op_Equality(*([v424 @ stack_-A8+10]), 0);\n\tv434 = v407 == 0;\n\tv411 = ~v434;\n\tif (v411) goto L_00B1;\n\tgoto L_00CE;\nL_00CE:\n\tv446 = UnityEngine.Application::get_isPlaying();\n\tv448 = v446 == 0;\n\tif (v448) goto L_00E6;\n\tv438 = *([v424 @ stack_-A8+10]) == 0;\n\tif (v438) goto L_0107;\n\tv451 = UnityEngine.Component::get_gameObject(*([v424 @ stack_-A8+10]));\n\tgoto L_00E0;\nL_00E0:\n\tUnityEngine.Object::Destroy(v451);\n\tgoto L_00B1;\nL_00E6:\n\tv454 = UnityEngine.Component::get_gameObject(*([v424 @ stack_-A8+10]));\n\tgoto L_00AE;\nL_00F1:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v109 @ stack_-C0_v4 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>));\n\tv165 = &v109 @ stack_-C0_v4 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\n\tv173 = 0;\n\tv200 = Il2CppMethodInfo;\nL_00F3:\n\tv215 = this._chainBySnakeId == 0;\n\tif (v215) goto L_010B;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::Clear(this._chainBySnakeId);\n\treturn;\nL_0105:\n\tv429 = new System.NullReferenceException();\n\tv200 = 0;\n\tgoto L_010A;\nL_0107:\n\tv436 = new System.NullReferenceException();\n\tv200 = Il2CppMethodInfo;\n\tgoto L_010A;\nL_010A:\n\t// 266 Interrupt\n\tv165 = &v109 @ stack_-C0_v4 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\n\tv173 = 0;\nL_0120:\n\tv254 = v200 != 1;\n\tif (v254) goto L_012E;\n\tv261 = 0x8BF5BC4(v224, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv173 = *([v261 @ X0_v11]);\n\tv283 = 0x8BF5BF4(v261, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv200 = *([v181 @ X22_v2 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(v165);\n\tv296 = *([v261 @ X0_v11]) == 0;\n\tv173 = *([v261 @ X0_v11]);\n\tif (v296) goto L_00F3;\n\tgoto L_0147;\nL_012E:\n\tv264 = 0x318D9C4(&v173 @ stack_-E8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv297 = v224;\n\tgoto L_014C;\nL_0147:\n\tv323 = new System.OutOfMemoryException();\nL_014C:\n\tv300 = 0x8BF0368(v297, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv306 = 0xA1B8(v300, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_004A:\n\tv64 = this._pendingRebuilds == 0;\n\tif (v64) goto L_010B;\nL_010B:\n\tv224 = new System.NullReferenceException();\n\tgoto L_0120;\nL_007A:\n\tv280 = System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>+ValueCollection<System.Int32, PrimeTween.Tween>+Enumerator<System.Int32, PrimeTween.Tween>::MoveNext(&v126 @ stack_-80_v4 (System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>+ValueCollection<System.Int32, PrimeTween.Tween>+Enumerator<System.Int32, PrimeTween.Tween>));\n\tv288 = v280 == 0;\n\tif (v288) goto L_008C;\n\tv294 = 0x318D984(&v173 @ stack_-E8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv297 = v323;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::Cleanup");
		}

		[Token(Token = "0x6000737")]
		[Address(RVA = "0x3E62FD0", Offset = "0x3E62FD0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::ResyncAll(this);\n\treturn;\n")]
		public void SyncWithData(EntityManager oldData)
		{
			ResyncAll();
		}

		[Token(Token = "0x6000738")]
		[Address(RVA = "0x3E5B340", Offset = "0x3E5B340", Length = "0x4C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv147 = 0xB2AA000 + 0x730;\n\tgoto L_005F;\n\tv91 = &v156 @ stack_-E8_v7 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\n\tv93 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>>::GetEnumerator(v78);\n\tv156 = *([v91 @ X8_v16]);\n\tv105 = *([v91 @ X8_v16]);\n\tv159 = v67 == 0;\n\tif (v159) goto L_009F;\n\tv365 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::BuildPathHeadToTail(this, v449);\n\tv368 = v365 == 0;\nL_FFFFFFFF:\n\tv147 = *([v91 @ X8_v16+10]);\n\tif (v368) goto L_008A;\n\tv476 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v67, *([v91 @ X8_v16+10]));\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::RebuildChainImmediate(this, *([v91 @ X8_v16+10]), v365);\nL_FFFFFFFF:\n\tv147 = *([v91 @ X8_v16+10]);\n\tgoto L_008A;\nL_009F:\n\tv147 = 0xB2A8000 + 0x548;\n\tv379 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::BuildPathHeadToTail(this, v449);\n\tv381 = v379 == 0;\n\tif (v381) goto L_00A2;\n\tv432 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv240 = &v105 @ stack_-90_v7 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\nL_FFFFFFFF:\n\tv427 = 0;\nL_FFFFFFFF:\n\tv342 = v449;\nL_FFFFFFFF:\n\tv348 = v147;\n\tgoto L_015F;\nL_00AE:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v105 @ stack_-90_v7 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>));\n\tv482 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::GetEnumerator(this._chainBySnakeId);\n\tv306 = v482._dictionary;\n\tv493 = v67 == 0;\n\tif (v493) goto L_0114;\nL_FFFFFFFF:\n\tv348 = 0;\n\tv530 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v67, *([v482 @ X0_v33 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>+Enumerator<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>)+10]));\n\tv638 = v530 == 0;\n\tv533 = ~v638;\n\tif (v533) goto L_00D9;\n\tv671 = v348 == 0;\n\tv672 = ~v671;\nL_FFFFFFFF:\n\tv342 = *([v482 @ X0_v33 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>+Enumerator<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>)+10]);\n\tif (v672) goto L_00F2;\n\tv678 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v678);\n\tv437 = v678 == 0;\nL_FFFFFFFF:\n\tv342 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv348 = v678;\n\tif (v437) goto L_FFFFFFFF;\nL_00F2:\n\tv681 = v348._version + 1;\n\tv348._version = v681;\n\tv347 = v348._items == 0;\nL_FFFFFFFF:\n\tv240 = &v306 @ stack_-C0_v6 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\nL_FFFFFFFF:\n\tv427 = 0;\n\tif (v347) goto L_015A;\n\tgoto L_010E;\nL_010E:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(v348, *([v482 @ X0_v33 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>+Enumerator<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>)+10]));\n\tgoto L_00D9;\nL_FFFFFFFF:\n\tv240 = &v306 @ stack_-C0_v6 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\nL_FFFFFFFF:\n\tv256 = 0;\n\tgoto L_011E;\nL_0114:\n\tv508 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v306 @ stack_-C0_v6 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>));\n\tv541 = ~v508;\n\tv438 = ~v541;\n\tif (v438) goto L_015C;\nL_FFFFFFFF:\n\tv240 = &v306 @ stack_-C0_v6 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\nL_FFFFFFFF:\n\tv348 = 0;\nL_FFFFFFFF:\n\tv256 = 0;\n\tv617 = v348 == 0;\n\tif (v617) goto L_0156;\n\tv650 = v348.Count < 1;\n\tif (v650) goto L_0156;\nL_FFFFFFFF:\n\tv694 = 0;\nL_0156:\n\treturn;\nL_0159:\n\tv262 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv240 = v239;\nL_FFFFFFFF:\n\tv427 = v243;\nL_FFFFFFFF:\n\tv342 = v247;\nL_FFFFFFFF:\n\tv348 = v253;\nL_015A:\n\tv432 = new System.NullReferenceException();\n\tgoto L_015F;\nL_015C:\n\tv432 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv240 = &v306 @ stack_-C0_v6 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\nL_FFFFFFFF:\n\tv427 = 0;\nL_FFFFFFFF:\n\tv342 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv348 = v147;\n\tgoto L_015F;\nL_FFFFFFFF:\n\tv240 = &v306 @ stack_-C0_v6 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>);\nL_FFFFFFFF:\n\tv427 = 0;\nL_FFFFFFFF:\n\tv342 = Il2CppMethodInfo;\n\tthrow v678;\nL_015F:\n\t// 351 Interrupt\n\tgoto L_0194;\n\tv484 = 0x8BF5BC4(v432, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv256 = *([v484 @ X0_v20]);\n\tv496 = 0x8BF5BF4(v484, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_011E;\n\treturn;\nL_005F:\n\tv67 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v67);\n\tv78 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::CollectSnakesById(this, -1);\nL_008A:\n\tv375 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v105 @ stack_-90_v7 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>));\n\tv389 = v375 == 0;\n\tif (v389) goto L_00AE;\nL_00A2:\n\tv384 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v105 @ stack_-90_v7 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>));\n\tv390 = ~v384;\n\tif (v390) goto L_00AE;\nL_00D9:\n\tv540 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v306 @ stack_-C0_v6 (System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>));\n\tv545 = v540 == 0;\n\tif (v545) goto L_FFFFFFFF;\nL_011E:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(v240);\n\tv555 = v256 == 0;\n\tv252 = ~v555;\n\tif (v252) goto L_0159;\nL_0137:\n\tv698 = System.Collections.Generic.List`1<System.Int32>::get_Item(v348, v694);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::RemoveChainImmediate(this, v698);\n\tv694 = v694 + 1;\n\tv651 = v694 < v348.Count;\n\tif (v651) goto L_0137;\nL_0194:\n\tv469 = v342 != \n// ... truncated")]
		public unsafe void ResyncAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::ResyncAll");
		}

		[Token(Token = "0x6000739")]
		[Address(RVA = "0x3E63D24", Offset = "0x3E63D24", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::RemoveChainFor(this, snakeId);\n\treturn;\nL_0028:\n\tgoto L_0031;\n\tv112 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>>::TryGetValue(v67, snakeId, &v70 @ stack_-38_v2 (System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>));\n\tv114 = v112 == 0;\n\tif (v114) goto L_0053;\n\tv117 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::BuildPathHeadToTail(this, v70);\n\tv120 = v117 == 0;\n\tif (v120) goto L_0053;\n\tv87 = v117.Count == 0;\n\tif (v87) goto L_0053;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::RebuildChainFor(this, snakeId, v117);\n\treturn;\nL_0053:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::RemoveChainFor(this, snakeId);\n\treturn;\nL_0016:\n\tv44 = ~snakeRemoved;\n\tif (v44) goto L_0028;\nL_0031:\n\tv67 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::CollectSnakesById(this, snakeId);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RebuildChainForSnake(int snakeId, bool snakeRemoved)
		{
			if (snakeRemoved)
			{
				RemoveChainFor(snakeId);
				return;
			}
			Dictionary<int, List<(Entity, GridCoord)>> dictionary = CollectSnakesById(snakeId);
			if (dictionary.TryGetValue(snakeId, out var value))
			{
				List<GridCoord> list = BuildPathHeadToTail(value);
				if (list != null && list.Count != 0)
				{
					RebuildChainFor(snakeId, list);
					return;
				}
			}
			RemoveChainFor(snakeId);
		}

		[Token(Token = "0x600073A")]
		[Address(RVA = "0x3E6408C", Offset = "0x3E6408C", Length = "0x45C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv65.<>4__this = this;\n\tv65.snakeId = snakeId;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::CancelPending(this, snakeId);\n\tv208 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::TryGetValue(this._chainBySnakeId, v65.snakeId, &v186 @ stack_-78_v3 (_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData));\n\tv326 = ~v208;\n\tif (v326) goto L_006B;\n\tv333 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::IsTailRecede(v186.path, path);\n\tv354 = v333 == 0;\n\tv335 = ~v354;\n\tif (v335) goto L_00B2;\nL_006B:\n\tgoto L_006F;\nL_006F:\n\tv349 = UnityEngine.Object::op_Inequality(this.Config, 0);\n\tv355 = ~v349;\n\tv356 = ~v355;\n\tif (v356) goto L_007B;\n\tgoto L_00B2;\nL_007B:\n\tv225 = this.Config;\n\tv171 = v225.rebuildDelay == 0;\n\tv392 = v225.rebuildDelay < 0;\n\tv164 = ~v392;\n\tv393 = ~v164;\n\tv143 = v393 | v171;\n\tif (v143) goto L_00B2;\n\tgoto L_00CA;\nL_00B2:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::RebuildChainImmediate(this, v65.snakeId, path);\nL_00C2:\n\treturn;\n\tv515 = Il2CppMethodInfo;\n\tv517 = Il2CppMethodInfo;\n\tv231 = 0;\n\tgoto L_00EC;\nL_00E9:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::AddWithResize(v65.pathSnapshot, v212);\n\tv516 = v204;\n\tv517 = Il2CppMethodInfo;\nL_00EA:\n\tv231 = v231 + 1;\n\tv515 = v516;\n\tv564 = *([v528 @ X8_v21 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv564 = v564 + 0x10;\n\tv544 = v565 - 1;\n\tv546 = v565 != 1;\n\tv565 = v544;\n\tif (v546) goto L_00F7;\nL_0110:\n\tv584 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(path);\n\tv595 = v231 < v584;\n\tif (v595) goto L_0131;\n\tgoto L_0186;\nL_011F:\n\tv598 = *([v564 @ X10_v19]) << 4;\n\tv599 = v528 + v598;\n\tv600 = v599 + 0x138;\n\t*([v600 @ X0_v46])(v604, path, *([v600 @ X0_v46+8]), v515, v517, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv614 = v231 >= v604;\n\tif (v614) goto L_0186;\nL_0131:\n\tv107 = v65.pathSnapshot;\n\tv632 = path->klass;\n\tv667 = path->klass->interface_offsets_count;\n\tv634 = *([v632 @ X8_v30 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v634) goto L_0155;\n\tv130 = *([v632 @ X8_v30 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv130 = v130 + 0x10;\n\tv649 = v667 - 1;\n\tv650 = v667 != 1;\n\tv667 = v649;\n\tif (v650) goto L_013E;\nL_0155:\n\tv516 = *([v658 @ X0_v36+8]);\n\tv212 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(path, v231);\n\tv675 = v65.pathSnapshot == 0;\n\tv219 = ~v675;\n\tv204 = v231;\n\tif (v219) goto L_016A;\n\tgoto L_019F;\nL_015E:\n\tv97 = *([v130 @ X10_v14]) << 4;\n\tv680 = v632 + v97;\n\tv681 = v680 + 0x138;\n\tv516 = *([v681 @ X0_v39+8]);\n\t*([v681 @ X0_v39])(v212, path, v231, *([v681 @ X0_v39+8]), v517, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv204 = v231;\nL_016A:\n\tv687 = v107._version + 1;\n\tv107._version = v687;\n\tv131 = v107._items;\n\tv688 = v107.Count < v131.Length;\n\tv510 = ~v688;\n\tif (v510) goto L_00E9;\n\tv690 = v107.Count + 1;\n\tv107.Count = v690;\n\tv691 = v107.Count * 0xC;\n\tv692 = v131 + v691;\n\t*([v692 @ X9_v13+20]) = v212;\n\tv131[v493 @ X11_v8 (System.Int32)].IsValid = v204;\n\tgoto L_00EA;\nL_0186:\n\tv642 = new System.Action();\n\tSystem.Action::.ctor(v642, v65, Il2CppMethodInfo);\n\tv678 = PrimeTween.Tween::Delay(v225.rebuildDelay, v642, 0, 1);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>::set_Item(this._pendingRebuilds, v65.snakeId, v678);\n\tgoto L_00C2;\nL_019F:\n\tthrow System.NullReferenceException;\nL_0040:\n\tv65 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v65);\nL_00CA:\n\tv473 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(path);\n\tv478 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v478, v473);\n\tv65.pathSnapshot = v478;\nL_00EC:\n\tv528 = path->klass;\n\tv565 = path->klass->interface_offsets_count;\n\tv530 = *([v528 @ X8_v21 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v530) goto L_0110;\nL_00F7:\n\tv576 = *([v564 @ X10_v19-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v576) goto L_011F;\nL_013E:\n\tv173 = *([v130 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v173) goto L_015E;\n")]
		public void RebuildChainFor(int snakeId, IReadOnlyList<GridCoord> path)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::RebuildChainFor");
		}

		[Token(Token = "0x600073B")]
		[Address(RVA = "0x3E63E34", Offset = "0x3E63E34", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv55.<>4__this = this;\n\tv55.snakeId = snakeId;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::CancelPending(this, snakeId);\n\tgoto L_0042;\nL_0042:\n\tv189 = UnityEngine.Object::op_Inequality(this.Config, 0);\n\tv191 = ~v189;\n\tv192 = ~v191;\n\tif (v192) goto L_004E;\n\tgoto L_008F;\nL_004E:\n\tv114 = this.Config;\n\tv93 = v114.rebuildDelay == 0;\n\tv202 = v114.rebuildDelay < 0;\n\tv90 = ~v202;\n\tv203 = ~v90;\n\tv81 = v203 | v93;\n\tif (v81) goto L_008F;\n\tv207 = new System.Action();\n\tSystem.Action::.ctor(v207, v55, Il2CppMethodInfo);\n\tv214 = PrimeTween.Tween::Delay(v114.rebuildDelay, v207, 0, 1);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>::set_Item(this._pendingRebuilds, v55.snakeId, v214);\n\treturn;\nL_008F:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::RemoveChainImmediate(this, v55.snakeId);\n\treturn;\nL_0028:\n\tv55 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v55);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveChainFor(int snakeId)
		{
			int snakeId2 = snakeId;
			CancelPending(snakeId);
			if (Config != null)
			{
				SnakeBlockerConfig config = Config;
				bool flag = config.rebuildDelay == 0f;
				bool flag2 = config.rebuildDelay < 0f;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				if (!(flag4 || flag))
				{
					Action onComplete = delegate
					{
						SnakeBlockerVisualHandler snakeBlockerVisualHandler = this;
						bool flag5 = snakeBlockerVisualHandler._pendingRebuilds.Remove(snakeId2);
						RemoveChainImmediate(snakeId2);
					};
					Tween value = Tween.Delay(config.rebuildDelay, onComplete);
					_pendingRebuilds[snakeId2] = value;
					return;
				}
			}
			RemoveChainImmediate(snakeId2);
		}

		[Token(Token = "0x600073C")]
		[Address(RVA = "0x3E6394C", Offset = "0x3E6394C", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002A:\n\tv61 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::TryGetValue(this._chainBySnakeId, snakeId, &v59 @ stack_-48_v3 (_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData));\n\tv108 = ~v61;\n\tif (v108) goto L_00A4;\n\tv81 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::PathsEqual(v59.path, path);\n\tv166 = v81 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_004D;\n\tv82 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::IsTailRecede(v59.path, path);\n\tv171 = ~v82;\n\tif (v171) goto L_0056;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::HandleTailRecede(this, snakeId, v59, path);\nL_004D:\n\treturn;\nL_0056:\n\tgoto L_0059;\nL_0059:\n\tv179 = UnityEngine.Object::op_Inequality(v59.root, 0);\n\tv183 = ~v179;\n\tv184 = ~v183;\n\tif (v184) goto L_006D;\n\tgoto L_00A0;\nL_006D:\n\tgoto L_0070;\nL_0070:\n\tv83 = UnityEngine.Application::get_isPlaying();\n\tv216 = ~v83;\n\tif (v216) goto L_008D;\n\tv218 = UnityEngine.Component::get_gameObject(v59.root);\n\tgoto L_0085;\nL_008D:\n\tv220 = UnityEngine.Component::get_gameObject(v59.root);\n\tgoto L_0098;\nL_00A0:\n\tv118 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::Remove(this._chainBySnakeId, snakeId);\nL_00A4:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::SpawnChainFor(this, snakeId, path);\n\treturn;\nL_0085:\n\tUnityEngine.Object::Destroy(v218);\n\tgoto L_00A0;\nL_0098:\n\tUnityEngine.Object::DestroyImmediate(v220);\n")]
		private void RebuildChainImmediate(int snakeId, IReadOnlyList<GridCoord> path)
		{
			if (_chainBySnakeId.TryGetValue(snakeId, out var value))
			{
				if (PathsEqual(value.path, path))
				{
					return;
				}
				if (IsTailRecede(value.path, path))
				{
					HandleTailRecede(snakeId, value, path);
					return;
				}
				if (value.root != null)
				{
					if (Application.isPlaying)
					{
						GameObject gameObject = value.root.gameObject;
						UnityEngine.Object.Destroy(gameObject);
					}
					else
					{
						GameObject gameObject2 = value.root.gameObject;
						UnityEngine.Object.DestroyImmediate(gameObject2);
					}
				}
				bool flag = _chainBySnakeId.Remove(snakeId);
			}
			SpawnChainFor(snakeId, path);
		}

		[Token(Token = "0x600073D")]
		[Address(RVA = "0x3E65A88", Offset = "0x3E65A88", Length = "0x1AD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006E;\nL_0072:\n\tv98 = UnityEngine.Object::op_Equality(this.Config, 0);\n\tv87 = path == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_007F;\n\tgoto L_076B;\nL_007F:\n\tv102 = v98 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_076B;\n\tv390 = path->klass;\n\tv574 = path->klass->interface_offsets_count;\n\tv392 = *([v390 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v392) goto L_00A9;\n\tv315 = *([v390 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv315 = v315 + 0x10;\n\tv559 = v574 - 1;\n\tv549 = v574 != 1;\nL_FFFFFFFF:\n\tv574 = v559;\n\tif (v549) goto L_0090;\nL_00A9:\n\tv340 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(path);\n\tv577 = v340 == 0;\n\tv348 = ~v577;\n\tif (v348) goto L_00BE;\n\tgoto L_076B;\nL_00AF:\n\tv255 = *([v315 @ X10_v107]) << 4;\n\tv582 = v390 + v255;\n\tv583 = v582 + 0x138;\n\t*([v583 @ X0_v439])(v341, path, *([v583 @ X0_v439+8]), 0, methodInfo, v180, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv349 = v341 == 0;\n\tif (v349) goto L_076B;\nL_00BE:\n\tgoto L_00C1;\nL_00C1:\n\tv342 = UnityEngine.Object::op_Equality(this._parent, 0);\n\tv350 = v342 == 0;\n\tif (v350) goto L_00D7;\n\tgoto L_076B;\nL_00D7:\n\tgoto L_00DB;\nL_00DB:\n\tv627 = UnityEngine.Object::op_Inequality(this._visualGrid, 0);\n\tv633 = ~v627;\n\tv634 = ~v633;\n\tif (v634) goto L_00ED;\nL_FFFFFFFF:\n\tv251 = 1f;\n\tgoto L_00EF;\nL_00ED:\n\tv655 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(this._visualGrid);\nL_FFFFFFFF:\n\tv251 = v655;\n\tgoto L_0100;\n\tv1274 = this.Config;\n\tgoto L_0119;\nL_0119:\n\tv1562 = UnityEngine.Object::Instantiate(v1274.chainRootPrefab, this._parent, 0);\n\tv874 = snakeId;\n\tv1574 = \"il2cpp_vm_object_box\"(*([v897 @ X26_v4 (System.Int32)+48]), &v874 @ stack_-C0_v12 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1182 = System.String::Format(\"SnakeBlockerChain_{0}\", v1574);\n\tUnityEngine.Object::set_name(v1562, v1182);\nL_FFFFFFFF:\n\tv2596 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv1321 = v1562;\nL_FFFFFFFF:\n\tv1333 = this;\n\tgoto L_016C;\nL_012D:\n\tv874 = snakeId;\n\tv1535 = \"il2cpp_vm_object_box\"(*([v897 @ X26_v4 (System.Int32)+48]), &v874 @ stack_-C0_v12 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1551 = System.String::Format(\"chain {0} spawns without highlight.\", v1535);\n\tv1588 = System.String::Concat(\"[SnakeBlocker] SnakeBlockerConfig.chainRootPrefab is not assigned; \", v1551);\n\tgoto L_0149;\n\tv1183 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v1183, v1605);\n\tv1184 = UnityEngine.GameObject::get_transform(v1183);\n\tUnityEngine.Transform::SetParent(v1184, this._parent, 0);\nL_FFFFFFFF:\n\tv2596 = 0;\nL_FFFFFFFF:\n\tv1321 = v1183;\nL_FFFFFFFF:\n\tv1333 = this;\nL_016C:\n\tUnityEngine.Object::set_hideFlags(v1321, 0x34);\n\tv1185 = UnityEngine.GameObject::get_transform(v1321);\n\tv1277 = v1333.Config;\n\t// 377 MakeStruct v229 @ AGG3E65F58_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v1277.pieceZOffset (System.Single)\n\tUnityEngine.Transform::set_localPosition(v1185, v229);\n\tv1218 = UnityEngine.GameObject::get_transform(v1321);\n\tgoto L_0198;\nL_0198:\n\t// 408 MakeStruct v222 @ AGG3E65FB8_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v1639.identity (UnityEngine.Quaternion), v1639.identity.y (System.Single), v1639.identity.z (System.Single), v1639.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v1218, v222);\n\tv1186 = UnityEngine.GameObject::get_transform(v1321);\n\tgoto L_01AD;\n\tv814 = v251 * v1278.pieceScaleMultiplier;\n\tv855 = v1661.one.z * v814;\n\tv836 = v1661.one.y * v814;\n\tv903 = v814 * v1661.one;\n\t// 447 MakeStruct v217 @ AGG3E66038_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v903 @ V0_v6 (System.Single), v836 @ V1_v9 (System.Single), v855 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::set_localScale(v1186, v217);\n\tv1668 = UnityEngine.GameObject::get_transform(v1321);\n\tv1672 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData();\n\tgoto L_01DD;\n\tSystem.Object::.ctor(v1672);\n\tv1672.root = v1668;\n\tv1709 = UnityEngine.GameObject::GetComponent(v1321);\n\tv818 = v1672 + 0x18;\n\tv1672.highlight = v1709;\n\tv1716 = path->klass;\n\tv1759 = path->klass->interface_offsets_count;\n\tv1718 = *([v1716 @ X8_v41 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v1718) goto L_021F;\n\tv1758 = *([v1716 @ X8_v41 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv1758 = v1758 + 0x10;\n\tv1744 = v1759 - 1;\n\tv1724 = v1759 != 1;\nL_FFFFFFFF:\n\tv1759 = v1744;\n\tif (v1724) goto L_0205;\nL_021F:\n\tv1747 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>::Add(path, System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>);\n\t*([v1747 @ X0_v367])(v1772, path, *([v1747 @ X0_v367+8]), 0, v2596, v180, v54, v55, v56, v903, v836, v855, v814, v1661.one, v62, v63, v64);\n\tv1782 = v1772 >= 2;\n\tif (v1782) goto L_0244;\nL_FFFFFFFF:\n\tv1884 = v903;\nL_FFFFFFFF:\n\tv1909 = 0;\nL_FFFFFFFF:\n\tv2492 = this;\nL_FFFFFFFF:\n\tv1851 = snakeId;\n\tgoto L_FFFFFFFF;\nL_0231:\n\tv1785 = *([v1758 @ X10_v99]) << 4;\n\tv1786 = v1716 + v1785;\n\tv1787 = v1786 + 0x138;\n\t*([v1787 @ X0_v370])(v1791, path, *([v1787 @ X0_v370+8]), 0, v2596, v180, v54, v55, v56, v903, v836, v855, v814, v1661.one, v62, v63, v64);\n\tv1802 = v1791 < 2;\nL_FFFFFFFF:\n\tv1884 = v903;\nL_FFFFFFFF:\n\tv1909 = 0;\nL_FFFFFFFF:\n\tv2492 = this;\nL_FFFFFFFF:\n\tv1851 = snakeId;\n\tif (v1802) goto L_FFFFFFFF;\nL_0244:\n\tv1279 = this.Config;\n\tgoto L_0255;\n\tv2003 = 0x318DA44(0, System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>, path, 0, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv2039 = 0x318DA44(0, System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>, path, 1, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv2042 = v2003 - v2039;\n\tv2044 = v2039 >> 0x20;\n\tv2045 = v2003.y - v2044;\n\tv777 = v2042;\n\tv2049 = 0x3E675EC(&v777 @ stack_-A0_v7, 0, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v2042, v2045, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv2057 = 0x8BF5E94(v2049, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v2045, v2042, v2042, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0283;\nL_0283:\n\tv2110 = UnityEngine.Object::op_Inequality(this._visualGrid, 0);\n\tv2128 = v2110 == 0;\n\tif (v2128) goto L_0293;\n\tv2278 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v2003);\n\tv842 = v2278.y;\n\tv861 = v2278.z;\nL_FFFFFFFF:\n\tv2219 = v2278;\nL_FFFFFFFF:\n\tv1337 = this;\n\tgoto L_029C;\nL_0293:\n\tv2219 = v251 * v2003;\n\tv842 = v251 * v2003.y;\nL_FFFFFFFF:\n\tv861 = 0;\nL_FFFFFFFF:\n\tv1337 = this;\nL_029C:\n\t// 668 MakeStruct v762 @ AGG3E662B8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v2219 @ V0_v57 (System.Single), v842 @ V1_v41 (System.Single), v861 @ V2_v32 (System.Single)\n\tv905 = UnityEngine.Transform::InverseTransformPoint(v1668, v762);\n\tv1281 = v1337.Config;\n\tgoto L_02B3;\nL_02B3:\n\tv1190 = UnityEngine.Object::Instantiate(v1281.rampPrefab, v1668);\n\tUnityEngine.Object::set_hideFlags(v1190,\n// ... truncated")]
		private void SpawnChainFor(int snakeId, IReadOnlyList<GridCoord> path)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::SpawnChainFor");
		}

		[Token(Token = "0x600073E")]
		[Address(RVA = "0x3E64A84", Offset = "0x3E64A84", Length = "0x1004")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv47 = *([A4731E0]);\n\tgoto L_0082;\nL_0082:\n\tv86 = oldChain + 0x28;\n\tv718 = oldChain.path;\n\tv492 = v718.Count - 1;\n\tv532 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(v718, v492);\n\tgoto L_00C0;\n\tv1457 = *([v1409 @ X8_v23 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv1457 = v1457 + 0x10;\n\tv1440 = v1458 - 1;\n\tv1420 = v1458 != 1;\nL_FFFFFFFF:\n\tv1458 = v1440;\n\tif (v1420) goto L_015F;\nL_0178:\n\tv964 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(newPath);\n\tv617 = v718.Count;\n\tv1483 = v964 < v718.Count;\n\tif (v1483) goto L_019C;\nL_FFFFFFFF:\n\tv1933 = newPath;\n\tgoto L_01BB;\nL_0188:\n\tv1489 = *([v1457 @ X10_v46]) << 4;\n\tv1490 = v1409 + v1489;\n\tv1491 = v1490 + 0x138;\n\t*([v1491 @ X0_v207])(v964, newPath, *([v1491 @ X0_v207+8]), 0, newPath, v1934, v172, v60, v61, v62, v1928, v1927, v1917, v1916, v67, v68, v69);\n\tv617 = v718.Count;\n\tv1506 = v964 >= v718.Count;\nL_FFFFFFFF:\n\tv1933 = newPath;\n\tif (v1506) goto L_01BB;\nL_019C:\n\tv966 = v1400 == 0;\n\tif (v966) goto L_061F;\nL_FFFFFFFF:\n\tv1564 = v964;\nL_01BB:\n\tv822 = 0xB2A1000 + 0xDD0;\n\tv819 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::.ctor(v819, v617);\n\tv787 = v718.Count < 1;\nL_FFFFFFFF:\n\tv2082 = Il2CppMethodInfo;\n\tif (v787) goto L_01F3;\n\tv821 = v819 == 0;\n\tif (v821) goto L_061A;\n\tv617 = 0xB2A1000 + 0xDF8;\nL_FFFFFFFF:\n\tv1628 = 0;\nL_01F3:\n\tv1604 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>::.ctor(v1604);\n\tv538 = oldChain.pieces;\nL_FFFFFFFF:\n\tv264 = 0;\nL_FFFFFFFF:\n\tv528 = 0;\n\tgoto L_021F;\nL_020F:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>::Add(v1604, v535);\nL_FFFFFFFF:\n\tv252 = v254;\nL_FFFFFFFF:\n\tv1933 = v279;\nL_FFFFFFFF:\n\tv287 = v290;\nL_FFFFFFFF:\n\tv2082 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv614 = v617;\nL_0210:\n\tv528 = v528 + 1;\n\tv538 = oldChain.pieces;\nL_FFFFFFFF:\n\tv254 = v252;\nL_FFFFFFFF:\n\tv1934 = v287;\nL_FFFFFFFF:\n\tv617 = v614;\nL_021F:\n\tv314 = v528 >= v538.Count;\n\tif (v314) goto L_02A2;\n\tv535 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>::get_Item(v538, v528);\n\tv581 = v535 + 0x24;\n\tv313 = v581.HasValue != 1;\n\tif (v313) goto L_0258;\n\tv1710 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v1400, v535.requiredA);\n\tv1745 = v1710 == 0;\n\tv1746 = ~v1745;\nL_FFFFFFFF:\n\tv279 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv290 = v1934;\nL_FFFFFFFF:\n\t;\n\tif (v1746) goto L_0287;\n\tv1808 = System.Nullable`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Value(&v535.requiredB (System.Nullable`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1824 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v1400, v1808);\n\tv1828 = ~v1824;\nL_FFFFFFFF:\n\tv252 = v254;\nL_FFFFFFFF:\n\tv1933 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv287 = v1808;\nL_FFFFFFFF:\n\tv2082 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv614 = v617;\n\tif (v1828) goto L_0210;\nL_FFFFFFFF:\n\tv279 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv290 = v1808;\nL_FFFFFFFF:\n\t;\n\tgoto L_0287;\nL_0258:\n\tv595 = v617 & 0xFFFFFFFF00000000;\n\tv614 = v595 | v492;\n\tv536 = _game.CoreSystem.New.GridEcsBinding.GridCoord::op_Equality(v535.requiredA, v532);\n\tv1712 = v536 == 0;\n\tif (v1712) goto L_026D;\nL_FFFFFFFF:\n\tv252 = v254;\nL_FFFFFFFF:\n\tv264 = v535;\nL_FFFFFFFF:\n\tv1933 = v614;\nL_FFFFFFFF:\n\tv287 = 0;\nL_FFFFFFFF:\n\tv2082 = v532;\n\tgoto L_0210;\nL_026D:\n\tv1825 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v1400, v535.requiredA);\n\tv1909 = ~v1825;\n\tv1829 = ~v1909;\nL_FFFFFFFF:\n\tv279 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv290 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv617 = v614;\n\tif (v1829) goto L_0287;\n\tv1830 = v254 & 0xFFFFFFFF00000000;\n\tv1933 = v1830 | v1032;\n\tv1823 = _game.CoreSystem.New.GridEcsBinding.GridCoord::op_Equality(v535.requiredA, v1217);\n\tv1827 = ~v1823;\nL_FFFFFFFF:\n\tv252 = v1933;\nL_FFFFFFFF:\n\tv287 = 0;\nL_FFFFFFFF:\n\tv2082 = v1217;\nL_FFFFFFFF:\n\tv254 = v1933;\nL_FFFFFFFF:\n\tv279 = v1933;\nL_FFFFFFFF:\n\tv290 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv617 = v614;\n\tif (v1827) goto L_0210;\nL_0287:\n\t;\n\tgoto L_020F;\nL_02A2:\n\tv598 = this.Config;\n\tv1668 = newPath->klass;\n\tv1700 = newPath->klass->interface_offsets_count;\n\tv1670 = *([v1668 @ X8_v46 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v1670) goto L_02D2;\n\tv432 = *([v1668 @ X8_v46 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv432 = v432 + 0x10;\n\tv1685 = v1700 - 1;\n\tv1675 = v1700 != 1;\nL_FFFFFFFF:\n\tv1700 = v1685;\n\tif (v1675) goto L_02BD;\nL_02D2:\n\tv1687 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::.ctor(newPath, System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>);\n\t*([v1687 @ X0_v167 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>)])(v1729, newPath, *([v1687 @ X0_v167 (System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>)+8]), 0, v1933, v1934, v172, v60, v61, v598.cubeShiftTween.endDelay, v1928, v1927, v1917, v1916, v67, v68, v69);\n\tv1703 = v1604 == 0;\n\tv564 = ~v1703;\nL_FFFFFFFF:\n\tv2082 = 0;\n\tif (v564) goto L_02F0;\nL_FFFFFFFF:\n\tv822 = 0xB78E000;\n\tgoto L_0615;\nL_02DC:\n\tv305 = *([v432 @ X10_v38]) << 4;\n\tv1714 = v1668 + v305;\n\tv1715 = v1714 + 0x138;\n\t*([v1715 @ X0_v170])(v1729, newPath, *([v1715 @ X0_v170+8]), v2082, v1933, v1934, v172, v60, v61, v598.cubeShiftTween.endDelay, v1928, v1927, v1917, v1916, v67, v68, v69);\nL_02F0:\n\tv1743 = v1604.Count < 1;\nL_FFFFFFFF:\n\tv1759 = v598.cubeShiftTween.endDelay;\n\tif (v1743) goto L_03E1;\n\tv459 = v1729 - 1;\n\tv627 = v718.Count - v1729;\nL_FFFFFFFF:\n\tv2230 = v172;\nL_FFFFFFFF:\n\tv1754 = v1928;\nL_FFFFFFFF:\n\tv1760 = v598.cubeShiftTween.endDelay;\nL_FFFFFFFF:\n\tv1761 = v1933;\nL_FFFFFFFF:\n\tv1762 = v1934;\nL_FFFFFFFF:\n\tv583 = 0;\n\tgoto L_035C;\nL_0304:\n\tv2560 = v627 < 1;\n\tif (v2560) goto L_FFFFFFFF;\n\tv2572 = v2486 - v2636;\n\tv2573 = v2572 < 0;\n\tv2574 = v2572 == 0;\n\tv2575 = v2486 ^ v2636;\n\tv2576 = v2486 ^ v2572;\n\tv2577 = v2575 & v2576;\n\tv2578 = v2577 < 0;\n\tv2579 = v2573 == v2578;\n\tv2580 = ~v2574;\n\tv2581 = v2579 & v2580;\n\tv2582 = ~v2581;\n\tif (v2582) goto L_0318;\nL_FFFFFFFF:\n\tv2636 = v2486;\n\tgoto L_0318;\nL_FFFFFFFF:\n\tv1754 = 1f;\n\tgoto L_032E;\nL_FFFFFFFF:\n\tv1754 = v2596;\nL_FFFFFFFF:\n\tv2232 = 0;\n\tgoto L_033D;\nL_FFFFFFFF:\n\tv2232 = v1754;\nL_034C:\n\tv583 = v583 + 1;\n\tv1764 = v583 >= v1604.Count;\nL_FFFFFFFF:\n\tv1928 = v1754;\nL_FFFFFFFF:\n\tv1759 = v1760;\nL_FFFFFFFF:\n\tv1933 = v1761;\nL_FFFFFFFF:\n\tv1934 = v1762;\nL_FFFFFFFF:\n\tv2082 = v1783;\n\tif (v1764) goto L_03E1;\nL_035C:\n\tv1866 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+<>c__DisplayClass22_0();\n\tSystem.Object::.ctor(v1866);\n\tv2028 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>::get_Item(v1604, v583);\n\tv542 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+TrackedPiece>::Remove(oldChain.pieces, v2028);\n\tgoto L_037C;\nL_037C:\n\tv2134 = UnityEngine.Object::op_Equality(v2028.go, 0);\n\tv2188 = v2134 == 0;\n\tv2189 = ~v2188;\nL_FFFFFFFF:\n\tv1783 = 0;\n\tif (v2189) goto L_034C;\n\tgoto L_0390;\nL_0390:\n\tv1866.capturedGo = v2028.go;\n\tv2436 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Int32>::TryGetValue(v819, v2028.requiredA,\n// ... truncated")]
		private void HandleTailRecede(int snakeId, ChainData oldChain, IReadOnlyList<GridCoord> newPath)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::HandleTailRecede");
		}

		[Token(Token = "0x600073F")]
		[Address(RVA = "0x3E645B0", Offset = "0x3E645B0", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv57 = newPath == 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v57) goto L_00AF;\n\tv173 = newPath->klass;\n\tv277 = newPath->klass->interface_offsets_count;\n\tv150 = *([v173 @ X8_v4 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v150) goto L_004E;\n\tv276 = *([v173 @ X8_v4 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv276 = v276 + 0x10;\n\tv262 = v277 - 1;\n\tv242 = v277 != 1;\nL_FFFFFFFF:\n\tv277 = v262;\n\tif (v242) goto L_0035;\nL_004E:\n\tv290 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(newPath);\n\tv301 = v290 < 2;\nL_FFFFFFFF:\n\tv462 = 0;\n\tif (v301) goto L_FFFFFFFF;\nL_005D:\n\tv340 = newPath->klass;\n\tv384 = newPath->klass->interface_offsets_count;\n\tv342 = *([v340 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v342) goto L_0081;\n\tv383 = *([v340 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv383 = v383 + 0x10;\n\tv369 = v384 - 1;\n\tv349 = v384 != 1;\nL_FFFFFFFF:\n\tv384 = v369;\n\tif (v349) goto L_0068;\nL_0081:\n\tv397 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(newPath);\n\tv409 = oldPath.Count <= v397;\n\tif (v409) goto L_0160;\nL_FFFFFFFF:\n\tv462 = 0;\n\tgoto L_FFFFFFFF;\nL_0091:\n\tv304 = *([v276 @ X10_v27]) << 4;\n\tv305 = v173 + v304;\n\tv306 = v305 + 0x138;\n\t*([v306 @ X0_v42])(v310, newPath, *([v306 @ X0_v42+8]), v462, v68, v66, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv320 = v310 >= 2;\n\tif (v320) goto L_005D;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_00B1:\n\tv412 = *([v383 @ X10_v22]) << 4;\n\tv413 = v340 + v412;\n\tv414 = v413 + 0x138;\n\t*([v414 @ X0_v35])(v418, newPath, *([v414 @ X0_v35+8]), v462, v68, v66, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv430 = oldPath.Count <= v418;\n\tif (v430) goto L_0160;\nL_FFFFFFFF:\n\tv157 = 0;\n\tgoto L_00E0;\nL_00D3:\n\tv641 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(newPath, v157);\n\tv455 = _game.CoreSystem.New.GridEcsBinding.GridCoord::op_Inequality(v575, v641);\n\tv459 = v157 + 1;\n\tv645 = v455 == 0;\n\tv456 = ~v645;\nL_FFFFFFFF:\n\tv462 = v641;\nL_FFFFFFFF:\n\tv157 = v459;\n\tif (v456) goto L_0160;\nL_00E0:\n\tv497 = newPath->klass;\n\tv533 = newPath->klass->interface_offsets_count;\n\tv151 = *([v497 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v151) goto L_0102;\n\tv133 = *([v497 @ X8_v11 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv133 = v133 + 0x10;\n\tv520 = v533 - 1;\n\tv502 = v533 != 1;\nL_FFFFFFFF:\n\tv533 = v520;\n\tif (v502) goto L_00E6;\nL_0102:\n\t;\n\tv544 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(newPath);\n\tv122 = v157 - v544;\n\tv117 = v122 < 0;\n\tv107 = v157 ^ v544;\n\tv102 = v157 ^ v122;\n\tv97 = v107 & v102;\n\tv92 = v97 < 0;\n\tv546 = v117 == v92;\n\tv87 = v157 < v544;\n\tif (v87) goto L_012C;\nL_FFFFFFFF:\n\treturnVal1 = v546;\n\tgoto L_00AF;\nL_0114:\n\t;\n\tv79 = *([v133 @ X10_v17]) << 4;\n\tv549 = v497 + v79;\n\tv550 = v549 + 0x138;\n\t*([v550 @ X0_v27])(v552, newPath, *([v550 @ X0_v27+8]), v462, v157, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv123 = v157 - v552;\n\tv118 = v123 < 0;\n\tv108 = v157 ^ v552;\n\tv103 = v157 ^ v123;\n\tv98 = v108 & v103;\n\tv93 = v98 < 0;\n\tv554 = v118 == v93;\n\tv88 = v157 >= v552;\nL_FFFFFFFF:\n\treturnVal1 = v554;\n\tif (v88) goto L_00AF;\nL_012C:\n\tv575 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(oldPath, v157);\n\tgoto L_00D3;\nL_0160:\n\treturn 0;\nL_0023:\n\tv53 = oldPath == 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v53) goto L_00AF;\nL_00AF:\n\treturn returnVal1;\nL_0035:\n\tv282 = *([v276 @ X10_v27-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v282) goto L_0091;\nL_0068:\n\tv389 = *([v383 @ X10_v22-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v389) goto L_00B1;\nL_00E6:\n\t;\n\tv538 = *([v133 @ X10_v17-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v538) goto L_0114;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsTailRecede(List<GridCoord> oldPath, IReadOnlyList<GridCoord> newPath)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::IsTailRecede");
			return default;
		}

		[Token(Token = "0x6000740")]
		[Address(RVA = "0x3E64880", Offset = "0x3E64880", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv57 = b == 0;\n\treturnVal1 = 0;\n\tif (v57) goto L_00C4;\n\tv138 = b->klass;\n\tv267 = b->klass->interface_offsets_count;\n\tv140 = *([v138 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v140) goto L_004F;\n\tv266 = *([v138 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv266 = v266 + 0x10;\n\tv252 = v267 - 1;\n\tv232 = v267 != 1;\n\tv267 = v252;\n\tif (v232) goto L_0036;\nL_004F:\n\tv280 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(b);\n\tv290 = a.Count != v280;\n\tif (v290) goto L_00E3;\nL_0066:\n\tv172 = a.Count < 1;\n\tif (v172) goto L_00F0;\n\tv359 = 0;\n\tv359 = v359 + 1;\n\tv334 = v359 < a.Count;\n\tif (v334) goto L_0070;\nL_00B8:\n\tv114 = v355 ^ 1;\n\treturnVal1 = v114;\nL_00C6:\n\tv293 = *([v266 @ X10_v14]) << 4;\n\tv294 = v138 + v293;\n\tv295 = v294 + 0x138;\n\t*([v295 @ X0_v24])(v299, b, *([v295 @ X0_v24+8]), methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv304 = a.Count == v299;\n\tif (v304) goto L_0066;\nL_00E3:\n\treturn 0;\nL_00F0:\n\treturn 1;\nL_0023:\n\tv53 = a == 0;\n\treturnVal1 = 0;\n\tif (v53) goto L_00C4;\nL_00C4:\n\treturn returnVal1;\nL_0036:\n\tv272 = *([v266 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v272) goto L_00C6;\nL_009F:\n\tv441 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(b, v359);\n\tv355 = _game.CoreSystem.New.GridEcsBinding.GridCoord::op_Inequality(v364, v441);\n\tv444 = v355 == 0;\n\tv116 = ~v444;\n\tif (v116) goto L_00B8;\nL_0070:\n\tv364 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(a, v359);\n\tgoto L_009F;\n")]
		private static bool PathsEqual(List<GridCoord> a, IReadOnlyList<GridCoord> b)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::PathsEqual");
			return default;
		}

		[Token(Token = "0x6000741")]
		[Address(RVA = "0x3E63B6C", Offset = "0x3E63B6C", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv56 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::TryGetValue(this._chainBySnakeId, snakeId, &v54 @ stack_-38_v3 (_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData));\n\tv95 = ~v56;\n\tif (v95) goto L_0089;\n\tgoto L_0037;\nL_0037:\n\tv137 = UnityEngine.Object::op_Inequality(v54.root, 0);\n\tv139 = ~v137;\n\tv140 = ~v139;\n\tif (v140) goto L_0048;\n\tgoto L_0081;\nL_0048:\n\tgoto L_004A;\nL_004A:\n\tv168 = UnityEngine.Application::get_isPlaying();\n\tv172 = ~v168;\n\tif (v172) goto L_006E;\n\tv181 = UnityEngine.Component::get_gameObject(v54.root);\n\tgoto L_005F;\nL_006E:\n\tv183 = UnityEngine.Component::get_gameObject(v54.root);\n\tgoto L_0079;\nL_0081:\n\tv105 = System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::Remove(this._chainBySnakeId, snakeId);\nL_0089:\n\treturn;\nL_005F:\n\tUnityEngine.Object::Destroy(v181);\n\tgoto L_0081;\nL_0079:\n\tUnityEngine.Object::DestroyImmediate(v183);\n")]
		private void RemoveChainImmediate(int snakeId)
		{
			if (!_chainBySnakeId.TryGetValue(snakeId, out var value))
			{
				return;
			}
			if (value.root != null)
			{
				if (Application.isPlaying)
				{
					GameObject gameObject = value.root.gameObject;
					UnityEngine.Object.Destroy(gameObject);
				}
				else
				{
					GameObject gameObject2 = value.root.gameObject;
					UnityEngine.Object.DestroyImmediate(gameObject2);
				}
			}
			bool flag = _chainBySnakeId.Remove(snakeId);
		}

		[Token(Token = "0x6000742")]
		[Address(RVA = "0x3E644F0", Offset = "0x3E644F0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv55 = System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>::TryGetValue(this._pendingRebuilds, snakeId, &v44 @ stack_-40_v1 (PrimeTween.Tween));\n\tv66 = ~v55;\n\tif (v66) goto L_003C;\n\tv69 = PrimeTween.Tween::get_isAlive(&v44 @ stack_-40_v1 (PrimeTween.Tween));\n\tv97 = ~v69;\n\tif (v97) goto L_0034;\n\tPrimeTween.Tween::Stop(&v44 @ stack_-40_v1 (PrimeTween.Tween));\nL_0034:\n\tv75 = System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>::Remove(this._pendingRebuilds, snakeId);\nL_003C:\n\treturn;\nL_0018:\n\tv44 = 0;\n")]
		private void CancelPending(int snakeId)
		{
			Tween value = default(Tween);
			if (_pendingRebuilds.TryGetValue(snakeId, out value))
			{
				if (value.isAlive)
				{
					value.Stop();
				}
				bool flag = _pendingRebuilds.Remove(snakeId);
			}
		}

		[Token(Token = "0x6000743")]
		[Address(RVA = "0x3E63FE4", Offset = "0x3E63FE4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv54 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>>::TryGetValue(v46, snakeId, &v52 @ stack_-38_v2 (System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>));\n\tv56 = ~v54;\n\tif (v56) goto L_0036;\n\treturnVal3 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::BuildPathHeadToTail(this, v52);\n\treturn returnVal3;\nL_0036:\n\treturn 0;\nL_0018:\n\tv46 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler::CollectSnakesById(this, snakeId);\n")]
		private List<GridCoord> CollectPath(int snakeId)
		{
			Dictionary<int, List<(Entity, GridCoord)>> dictionary = CollectSnakesById(snakeId);
			if (dictionary.TryGetValue(snakeId, out var value))
			{
				return BuildPathHeadToTail(value);
			}
			return null;
		}

		[Token(Token = "0x6000744")]
		[Address(RVA = "0x3E62FD4", Offset = "0x3E62FD4", Length = "0x42C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tv79 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv210 = 0xB285000 + 0x5F8;\n\tv348 = 0xB285000 + 0x780;\n\tv347 = 0xB2C6000 + 0x8D0;\n\tv181 = 0;\n\tgoto L_006C;\nL_0065:\n\tv575 = v99;\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::Add(v610, &v575 @ stack_-80_v3 (System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv312 = Il2CppMethodInfo;\n\tv317 = v546;\n\tv344 = v99;\n\tv345 = Il2CppMethodInfo;\nL_006B:\n\tv181 = v181 + 1;\n\tv409 = *([v361 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv409 = v409 + 0x10;\n\tv373 = v400 - 1;\n\tv371 = v400 != 1;\n\tv400 = v373;\n\tif (v371) goto L_0073;\nL_008D:\n\tv394 = 0x220C5E0(v79, *([v210 @ X19_v8 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v394 @ X0_v38])(v422, v79, *([v394 @ X0_v38+8]), 0, v317, v312, v45, v46, v47, v344, v49, v50, v51, v52, v53, v54, v55);\n\tv433 = v181 < v422;\n\tif (v433) goto L_00B2;\n\tgoto L_017C;\nL_009F:\n\t;\n\tv439 = *([v409 @ X10_v16]) << 4;\n\tv440 = v361 + v439;\n\tv441 = v440 + 0x138;\n\t*([v441 @ X0_v41])(v445, v79, *([v441 @ X0_v41+8]), v345, v317, v312, v45, v46, v47, v344, v49, v50, v51, v52, v53, v54, v55);\n\tv455 = v181 >= v445;\n\tif (v455) goto L_017C;\nL_00B2:\n\t;\n\tv474 = *([v79 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv515 = *([v474 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv476 = *([v474 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v476) goto L_00D3;\n\tv524 = *([v474 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv524 = v524 + 0x10;\n\tv488 = v515 - 1;\n\tv486 = v515 != 1;\n\tv515 = v488;\n\tif (v486) goto L_00B9;\nL_00D3:\n\tv543 = 0x220C5E0(v79, *([v348 @ X26_v9 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00D9;\nL_00D5:\n\t;\n\tv539 = *([v524 @ X10_v11]) << 4;\n\tv540 = v474 + v539;\n\tv543 = v540 + 0x138;\n\tv550 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v546);\n\tv553 = ~v550;\n\tv345 = 0;\n\tif (v553) goto L_006B;\n\tv345 = *([v347 @ X27_v9 (System.Int32)]);\n\tv581 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v546);\n\tv584 = ~v581;\n\tif (v584) goto L_006B;\n\tv582 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v546);\n\tv585 = ~v582;\n\tv345 = Il2CppMethodInfo;\n\tif (v585) goto L_006B;\n\tv583 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v546);\n\tv592 = filterSnakeId & 0x80000000;\n\tv593 = v592 == 0;\n\tv586 = ~v593;\n\tif (v586) goto L_0118;\n\tv555 = v583 != filterSnakeId;\n\tv345 = Il2CppMethodInfo;\n\tif (v555) goto L_006B;\nL_0118:\n\tv195 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v546);\n\tv603 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>>::TryGetValue(v62, v583, &v600 @ stack_-88_v4 (System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>));\n\tv605 = v603 == 0;\n\tv606 = ~v605;\n\tif (v606) goto L_0148;\n\tv610 = new System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::.ctor(v610);\n\tv210 = 0xB285000 + 0x5F8;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>>::set_Item(v62, v583, v610);\n\tv600 = v610;\nL_0148:\n\tSystem.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(&v99 @ stack_-A0_v4 (System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>), v546, v195);\n\tv348 = 0xB285000 + 0x780;\n\tv347 = 0xB2C6000 + 0x8D0;\n\tgoto L_0065;\nL_017C:\n\treturn v62;\nL_004B:\n\tv62 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>>::.ctor(v62);\nL_006C:\n\t;\n\tv361 = *([v79 @ X0_v7 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv400 = *([v361 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv291 = *([v361 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v291) goto L_008D;\nL_0073:\n\t;\n\tv414 = *([v409 @ X10_v16-8]) == *([v210 @ X19_v8 (System.Int32)]);\n\tif (v414) goto L_009F;\nL_00B9:\n\t;\n\tv529 = *([v524 @ X10_v11-8]) == *([v348 @ X26_v9 (System.Int32)]);\n\tif (v529) goto L_00D5;\nL_00D9:\n\t;\n\t*([v543 @ X0_v12])(v546, v79, v181, *([v543 @ X0_v12+8]), v317, v312, v45, v46, v47, v344, v49, v50, v51, v52, v53, v54, v55);\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Dictionary<int, List<(Entity, GridCoord)>> CollectSnakesById(int filterSnakeId = -1)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::CollectSnakesById");
			return default;
		}

		[Token(Token = "0x6000745")]
		[Address(RVA = "0x3E63400", Offset = "0x3E63400", Length = "0x54C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004D;\n\tv66 = members.Count == 0;\n\tif (v66) goto L_FFFFFFFF;\n\tv187 = members.Count < 1;\n\tif (v187) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv257 = 0;\nL_FFFFFFFF:\n\tv276 = 0;\n\tgoto L_007E;\nL_006C:\n\tv276 = v276 + 1;\n\tv189 = v276 >= members.Count;\n\tif (v189) goto L_00AA;\nL_007E:\n\tv484 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(members, v276);\n\tv155 = v155.Id;\n\tv261 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v155.Id);\n\tv645 = v261 & 0x8000000000000000;\n\tv646 = v645 == 0;\n\tv647 = ~v646;\n\tif (v647) goto L_0092;\n\tv701 = v155.Id & 0x80000000;\n\tv702 = v701 == 0;\n\tif (v702) goto L_006C;\nL_0092:\n\tv704 = 0 & 1;\n\tv705 = v704 == 0;\n\tv266 = ~v705;\n\tif (v266) goto L_FFFFFFFF;\n\tv730 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(members, v276);\n\tv155 = v730.Item1;\n\tSystem.Nullable`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::.ctor(&v257 @ stack_-98_v4 (System.Nullable`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>), &v155 @ stack_-80 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv155 = v730.Item1;\n\tgoto L_006C;\nL_00AA:\n\tv738 = 0 & 1;\n\tv267 = v738 == 0;\n\tif (v267) goto L_FFFFFFFF;\n\tv685 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::.ctor(v685, members.Count);\n\tv671 = members.Count;\n\tv570 = members.Count < 1;\nL_FFFFFFFF:\n\tv275 = v685;\n\tif (v570) goto L_014D;\n\tv764 = v685 == 0;\n\tif (v764) goto L_0114;\nL_FFFFFFFF:\n\tv173 = 0;\n\tgoto L_00DE;\nL_00CC:\n\tv173 = v173 + 1;\n\tv671 = members.Count;\n\tv675 = v173 >= members.Count;\nL_FFFFFFFF:\n\tv275 = v685;\n\tif (v675) goto L_014D;\nL_00DE:\n\tv615 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(members, v173);\n\tv155 = v155.Id;\n\tv815 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v155.Id);\n\tv826 = v815 & 0x8000000000000000;\n\tv827 = v826 == 0;\n\tv828 = ~v827;\n\tif (v828) goto L_00CC;\n\tv842 = v155.Id & 0x80000000;\n\tv843 = v842 == 0;\n\tv844 = ~v843;\n\tif (v844) goto L_00CC;\n\tv263 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::ContainsKey(v685, v871);\n\tv881 = v263 == 0;\n\tv268 = ~v881;\n\tif (v268) goto L_FFFFFFFF;\n\tv888 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(members, v173);\n\tv155 = v888.Item1;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::set_Item(v685, v871, &v155 @ stack_-80 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv155 = v888.Item1;\n\tgoto L_00CC;\nL_0114:\n\tv565 = this._em;\n\tv616 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(members, 0);\n\tv155 = v155.Id;\nL_FFFFFFFF:\n\tv544 = v155.Id;\nL_FFFFFFFF:\n\tv558 = 1;\nL_012D:\n\tv671 = members.Count;\n\tv569 = v558 >= members.Count;\nL_FFFFFFFF:\n\tv275 = v685;\n\tif (v569) goto L_014D;\n\tv565 = this._em;\n\tv614 = System.Collections.Generic.List`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(members, v558);\n\tv558 = v558 + 1;\n\tv882 = this._em == 0;\n\tv622 = ~v882;\nL_FFFFFFFF:\n\tv671 = this._em;\nL_FFFFFFFF:\n\tv275 = v685;\nL_FFFFFFFF:\n\tv544 = v614.Item1;\n\tif (v622) goto L_0125;\n\tthrow System.NullReferenceException;\nL_014D:\n\treturnVal1 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(returnVal1, v671);\n\tv734 = new System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v734);\n\tv618 = System.Nullable`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Value(&v257 @ stack_-98_v4 (System.Nullable`1<System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>));\n\tv760 = returnVal1 == 0;\n\tif (v760) goto L_01BC;\n\tv620 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v734, v618.Item2);\n\tv776 = v275 == 0;\n\tif (v776) goto L_01D0;\n\tv793 = ~v620;\n\tif (v793) goto L_01D4;\nL_FFFFFFFF:\n\tv560 = v618.Item2;\nL_FFFFFFFF:\n\t;\n\tgoto L_019E;\nL_019E:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(returnVal1, v560);\n\tv805 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(v275, v560, &v58 @ stack_-C0_v1 (System.ValueTuple`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, _game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv806 = v805 == 0;\n\tif (v806) goto L_01D4;\n\tv890 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v734, 0);\n\tv892 = v890 == 0;\n\tv371 = ~v892;\nL_FFFFFFFF:\n\tv560 = 0;\nL_FFFFFFFF:\n\t;\n\tif (v371) goto L_0181;\n\tgoto L_01CF;\nL_01BC:\n\tv260 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v734, v618.Item2);\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_01D0:\n\tv794 = ~v620;\n\tv795 = ~v794;\n\tif (v795) goto L_01D9;\nL_01D4:\n\tgoto L_01CF;\nL_01D9:\n\t;\n\tgoto L_01F8;\nL_01F8:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(returnVal1, v618.Item2);\n\tthrow returnVal1;\nL_004D:\n\tv58 = 0;\n\tv61 = members == 0;\n\tif (v61) goto L_FFFFFFFF;\nL_0125:\n\tv617 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v565, v544);\n\tv829 = v617 & 0x8000000000000000;\n\tv830 = v829 == 0;\n\tv831 = ~v830;\n\tif (v831) goto L_012D;\nL_0181:\n\t;\nL_01CF:\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe List<GridCoord> BuildPathHeadToTail(List<(Entity entity, GridCoord coord)> members)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeBlockerVisualHandler::BuildPathHeadToTail");
			return default;
		}

		[Token(Token = "0x6000746")]
		[Address(RVA = "0x3E676C0", Offset = "0x3E676C0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = type == 2;\n\tif (v11) goto L_002D;\n\tv20 = type == 1;\n\tif (v20) goto L_0024;\n\tv28 = type == 0;\n\tv29 = ~v28;\n\tif (v29) goto L_003A;\n\tv37 = this.Config;\n\treturn v37.tailendPrefab;\nL_0024:\n\tv30 = this.Config;\n\treturn v30.middlePrefab;\nL_002D:\n\tv25 = this.Config;\n\treturn v25.cornerPrefab;\nL_003A:\n\treturn 0;\n")]
		private GameObject GetPrefab(PathSegmentType type)
		{
			switch (type)
			{
			case PathSegmentType.Endpoint:
			{
				SnakeBlockerConfig config3 = Config;
				return config3.tailendPrefab;
			}
			case PathSegmentType.Straight:
			{
				SnakeBlockerConfig config2 = Config;
				return config2.middlePrefab;
			}
			case PathSegmentType.Corner:
			{
				SnakeBlockerConfig config = Config;
				return config.cornerPrefab;
			}
			default:
				return null;
			}
		}

		[Token(Token = "0x6000747")]
		[Address(RVA = "0x3E58DA8", Offset = "0x3E58DA8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, PrimeTween.Tween>::.ctor(v72);\n\tthis._pendingRebuilds = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler+ChainData>::.ctor(v56);\n\tthis._chainBySnakeId = v56;\n")]
		public SnakeBlockerVisualHandler()
		{
			Dictionary<int, ChainData> chainBySnakeId = new Dictionary<int, ChainData>();
			_chainBySnakeId = chainBySnakeId;
			Dictionary<int, Tween> pendingRebuilds = new Dictionary<int, Tween>();
			_pendingRebuilds = pendingRebuilds;
		}
	}
}
