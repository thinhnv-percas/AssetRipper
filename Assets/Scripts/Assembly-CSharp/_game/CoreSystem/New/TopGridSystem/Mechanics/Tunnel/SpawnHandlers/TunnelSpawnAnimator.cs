using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers
{
	[Token(Token = "0x2000156")]
	public class TunnelSpawnAnimator : ITunnelSpawnAnimator
	{
		[Inject(false)]
		[Token(Token = "0x4000452")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000453")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController _visualGrid;

		[Inject(false)]
		[Token(Token = "0x4000454")]
		[FieldOffset(Offset = "0x20")]
		private TunnelConfig _config;

		[Token(Token = "0x600069C")]
		[Address(RVA = "0x3DB99F8", Offset = "0x3DB99F8", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_0035:\n\tv84 = UnityEngine.Object::op_Equality(v71, 0);\n\tv87 = v84 == 0;\n\tif (v87) goto L_004A;\n\tgoto L_FFFFFFFF;\nL_004A:\n\tv106 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, tunnel);\n\tv108 = ~v106;\n\tif (v108) goto L_FFFFFFFF;\n\tv198 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, tunnel);\n\tv178 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(this._visualGrid, v198);\n\tv200 = UnityEngine.Component::get_transform(v71);\n\tv341 = UnityEngine.Transform::get_position(v200);\n\tv346 = UnityEngine.Transform::get_localScale(v200);\n\tUnityEngine.Transform::set_position(v200, v178);\n\tgoto L_0094;\n\tv128 = v215.tunnelTweenSettings;\n\tv376 = PrimeTween.Tween::Position(v200, v341, &v128 @ stack_-F0_v3 (PrimeTween.TweenSettings));\n\tv202 = PrimeTween.Sequence::Chain(&v142 @ stack_-90_v5 (PrimeTween.Sequence), v376);\n\tv216 = this._config;\n\tv234 = v216.tunnelTweenSettings;\n\tv386 = PrimeTween.Tween::Scale(v200, v346, &v234 @ stack_-120_v2 (PrimeTween.TweenSettings));\n\tv391 = PrimeTween.Sequence::Group(&v142 @ stack_-90_v5 (PrimeTween.Sequence), v386);\nL_FFFFFFFF:\n\treturnVal1 = v142;\n\tgoto L_00EB;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_002C:\n\tv71 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n\tgoto L_0035;\nL_0094:\n\t// 148 MakeStruct v116 @ AGG3DB9BBC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v366.zero (UnityEngine.Vector3), v366.zero.y (System.Single), v366.zero.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v200, v116);\n\tv201 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\n\tv215 = this._config;\nL_00EB:\n\treturn returnVal1;\n")]
		public Sequence Animate(Entity entity, Entity tunnel)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelSpawnAnimator::Animate");
			return default;
		}

		[Token(Token = "0x600069D")]
		[Address(RVA = "0x3DB9CCC", Offset = "0x3DB9CCC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelSpawnAnimator()
		{
		}
	}
}
