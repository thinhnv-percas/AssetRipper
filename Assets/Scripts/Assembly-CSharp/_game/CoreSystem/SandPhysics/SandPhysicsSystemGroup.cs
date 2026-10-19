using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Core;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace _game.CoreSystem.SandPhysics
{
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateBefore(typeof(TransformSystemGroup))]
	[Token(Token = "0x20000AA")]
	public class SandPhysicsSystemGroup : ComponentSystemGroup
	{
		[Token(Token = "0x4000228")]
		[FieldOffset(Offset = "0xA8")]
		internal float _accumulator;

		[Token(Token = "0x4000229")]
		[FieldOffset(Offset = "0xAC")]
		internal float _fixedDt;

		[Token(Token = "0x400022A")]
		[FieldOffset(Offset = "0xB0")]
		internal int _maxSubSteps;

		[Token(Token = "0x400022B")]
		[FieldOffset(Offset = "0xB4")]
		internal float _timeMultiplier;

		[Token(Token = "0x400022C")]
		[FieldOffset(Offset = "0xB8")]
		internal bool _configured;

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0x3C7AB8C", Offset = "0x3C7AB8C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._fixedDt = fixedDt;\n\tv5 = maxSubSteps - 1;\n\tv6 = v5 < 0;\n\tv7 = v5 == 0;\n\tv8 = maxSubSteps ^ 1;\n\tv9 = maxSubSteps ^ v5;\n\tv10 = v8 & v9;\n\tv11 = v10 < 0;\n\tv12 = v6 == v11;\n\tv13 = ~v7;\n\tv14 = v12 & v13;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv18 = maxSubSteps;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv18 = 1;\nL_0013:\n\tthis._maxSubSteps = v18;\n\tthis._configured = 1;\n\tthis._accumulator = 0f;\n\treturn;\n")]
		public void Configure(float fixedDt, int maxSubSteps)
		{
			_fixedDt = fixedDt;
			int num = maxSubSteps - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = maxSubSteps ^ 1;
			int num3 = maxSubSteps ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int maxSubSteps2 = ((!(flag4 && flag5)) ? 1 : maxSubSteps);
			_maxSubSteps = maxSubSteps2;
			_configured = true;
			_accumulator = 0f;
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0x3C7ABAC", Offset = "0x3C7ABAC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = v38 & 0x7FFFFFFF;\n\tv4 = v2 < 0x7F800000;\n\tv5 = ~v4;\n\tv6 = v2 - 0x7F800000;\n\tv8 = v6 == 0;\n\tv14 = ~v5;\n\tv15 = v14 | v8;\n\tv16 = ~v15;\n\tif (v16) goto L_FFFFFFFF;\n\tv32 = v38 < 0;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv32 = 1;\n\tgoto L_0025;\nL_001F:\n\tv35 = ~v32;\n\tif (v35) goto L_0025;\nL_0025:\n\tthis._timeMultiplier = 0f;\n\treturn;\n")]
		public void SetTimeMultiplier(float multiplier)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsSystemGroup::SetTimeMultiplier");
		}

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0x3C7BE4C", Offset = "0x3C7BE4C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = maxSubSteps - 1;\n\tv4 = v3 < 0;\n\tv5 = v3 == 0;\n\tv6 = maxSubSteps ^ 1;\n\tv7 = maxSubSteps ^ v3;\n\tv8 = v6 & v7;\n\tv9 = v8 < 0;\n\tv10 = v4 == v9;\n\tv11 = ~v5;\n\tv12 = v10 & v11;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = maxSubSteps;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv16 = 1;\nL_0012:\n\tthis._maxSubSteps = v16;\n\treturn;\n")]
		public void SetMaxSubSteps(int maxSubSteps)
		{
			int num = maxSubSteps - 1;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = maxSubSteps ^ 1;
			int num3 = maxSubSteps ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int maxSubSteps2 = ((!(flag4 && flag5)) ? 1 : maxSubSteps);
			_maxSubSteps = maxSubSteps2;
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x3C7AB84", Offset = "0x3C7AB84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._accumulator = 0f;\n\treturn;\n")]
		public void ResetAccumulator()
		{
			_accumulator = 0f;
		}

		[Preserve]
		[Token(Token = "0x60002D8")]
		[Address(RVA = "0x3C7BE5C", Offset = "0x3C7BE5C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this._configured == 0;\n\tif (v18) goto L_00A2;\n\tv21 = Unity.Entities.ComponentSystemBase::get_World(this);\n\tv32 = Unity.Entities.World::get_Time(v21);\n\tv183 = v32.DeltaTime * this._timeMultiplier;\n\tv201 = this._accumulator + v183;\n\tthis._accumulator = v201;\n\tv188 = this._fixedDt * this._maxSubSteps;\n\tv189 = v201 < v188;\n\tv190 = v201 == v188;\n\tv193 = v201 == v201;\n\tv194 = v188 == v188;\n\tv195 = v193 & v194;\n\tv196 = ~v195;\n\tv197 = v189 == v196;\n\tv198 = ~v197;\n\tv199 = v198 | v190;\n\tif (v199) goto L_002C;\n\tthis._accumulator = v188;\nL_FFFFFFFF:\n\tv201 = v188;\nL_FFFFFFFF:\n\tv70 = 0xFFFFFFFF80000000;\n\tgoto L_0041;\nL_FFFFFFFF:\n\tv70 = v202;\nL_FFFFFFFF:\n\tv67 = this._maxSubSteps;\n\tgoto L_005A;\nL_FFFFFFFF:\n\tv67 = v70;\n\tv241 = this._fixedDt * v67;\n\tv242 = v201 - v241;\n\tv244 = UnityEngine.Mathf::Max(v242, 0f);\n\tthis._accumulator = v244;\n\tv267 = Unity.Entities.World::get_Time(v108);\n\tUnity.Core.TimeData::.ctor(&v63 @ stack_-40_v5 (Unity.Core.TimeData), v267.ElapsedTime, this._fixedDt);\n\tUnity.Entities.World::PushTime(v264, v63);\n\tUnity.Entities.ComponentSystemGroup::OnUpdate(this);\n\tv110 = Unity.Entities.ComponentSystemBase::get_World(this);\n\tUnity.Entities.World::PopTime(v110);\n\tv249 = v67 - 1;\n\tv250 = v67 != 1;\nL_FFFFFFFF:\n\tv67 = v249;\n\tif (v250) goto L_0064;\nL_0098:\n\treturn;\nL_00A2:\n\tUnity.Entities.ComponentSystemGroup::OnUpdate(this);\n\treturn;\nL_002C:\n\tv202 = v201 / this._fixedDt;\n\tv206 = v202 == 0x7F800000;\n\tv213 = ~v206;\n\tif (v213) goto L_FFFFFFFF;\nL_0041:\n\tv218 = this._maxSubSteps - v70;\n\tv219 = v218 < 0;\n\tv221 = this._maxSubSteps ^ v70;\n\tv222 = this._maxSubSteps ^ v218;\n\tv223 = v221 & v222;\n\tv224 = v223 < 0;\n\tv225 = v219 == v224;\n\tv226 = ~v225;\n\tv35 = ~v226;\n\tif (v35) goto L_FFFFFFFF;\nL_005A:\n\tv240 = v67 < 1;\n\tif (v240) goto L_0098;\nL_0064:\n\tv264 = Unity.Entities.ComponentSystemBase::get_World(this);\n\tv108 = Unity.Entities.ComponentSystemBase::get_World(this);\n")]
		protected override void OnUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsSystemGroup::OnUpdate");
		}

		[Preserve]
		[Token(Token = "0x60002D9")]
		[Address(RVA = "0x3C7BFC0", Offset = "0x3C7BFC0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._fixedDt = 0.016666668f;\n\tthis._timeMultiplier = 1f;\n\tUnity.Entities.ComponentSystemGroup::.ctor(this);\n\treturn;\n")]
		public SandPhysicsSystemGroup()
		{
			_fixedDt = 1f / 60f;
			_timeMultiplier = 1f;
		}
	}
}
