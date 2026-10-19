using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts
{
	[Token(Token = "0x2000149")]
	public class MovingCubeTracker : MonoBehaviour
	{
		[Token(Token = "0x400042E")]
		[FieldOffset(Offset = "0x20")]
		internal Entity _entity;

		[Token(Token = "0x600066E")]
		[Address(RVA = "0x3DB648C", Offset = "0x3DB648C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._entity = entity;\n\treturn;\n")]
		public void Init(Entity entity)
		{
			_entity = entity;
		}

		[Token(Token = "0x600066F")]
		[Address(RVA = "0x3DB6494", Offset = "0x3DB6494", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0014;\nL_0014:\n\t;\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&this._entity (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv58 = ~v51;\n\tv59 = ~v58;\n\tif (v59) goto L_0032;\n\tgoto L_005B;\nL_0032:\n\tgoto L_003A;\n\tv133 = UnityEngine.Component::get_transform(this);\n\tv111 = UnityEngine.Transform::get_position(v133);\n\t// 81 MakeStruct v98 @ AGG3DB6578_2_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v111 @ V0_v2 (UnityEngine.Vector3), v111.y (System.Single)\n\t_game.CoreSystem.SandPhysics.Services.MovingCubeRegistry::Update(v84.MovingCubes, this._entity, v98);\n\treturn;\nL_005B:\n\treturn;\nL_003A:\n\tv84 = v82.<Current>k__BackingField;\n\tv79 = v82.<Current>k__BackingField == 0;\n\tif (v79) goto L_005B;\n")]
		private void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubeTracker::Update");
		}

		[Token(Token = "0x6000670")]
		[Address(RVA = "0x3DB6590", Offset = "0x3DB6590", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0014;\nL_0014:\n\t;\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&this._entity (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv58 = ~v51;\n\tv59 = ~v58;\n\tif (v59) goto L_0039;\n\treturn;\nL_0039:\n\tgoto L_0041;\n\t_game.CoreSystem.SandPhysics.Services.MovingCubeRegistry::Unregister(v101.MovingCubes, this._entity);\nL_004D:\n\tgoto L_0052;\nL_0041:\n\tv101 = v115.<Current>k__BackingField;\n\tv116 = v115.<Current>k__BackingField == 0;\n\tif (v116) goto L_004D;\nL_0052:\n\tthis._entity = v126.Invalid;\n\treturn;\n")]
		private void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubeTracker::OnDestroy");
		}

		[Token(Token = "0x6000671")]
		[Address(RVA = "0x3DB6694", Offset = "0x3DB6694", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001F;\nL_001F:\n\tthis._entity = v51.Invalid;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MovingCubeTracker()
		{
			_entity = Entity.Invalid;
		}
	}
}
