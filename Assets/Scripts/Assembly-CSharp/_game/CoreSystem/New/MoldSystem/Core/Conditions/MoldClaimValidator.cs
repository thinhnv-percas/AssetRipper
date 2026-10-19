using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.Core.Conditions
{
	[Token(Token = "0x2000303")]
	public class MoldClaimValidator
	{
		[Token(Token = "0x4000939")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<IClaimCondition> _conditions;

		[Token(Token = "0x6000D4A")]
		[Address(RVA = "0x3EED42C", Offset = "0x3EED42C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._conditions = conditions;\n\treturn;\n")]
		public MoldClaimValidator(List<IClaimCondition> conditions)
		{
			_conditions = conditions;
		}

		[Token(Token = "0x6000D4B")]
		[Address(RVA = "0x3EED460", Offset = "0x3EED460", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv233 = 0;\n\tv141 = System.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>::get_Item(v166, v233);\n\tv258 = *([v141 @ X0_v8 (_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition)]);\n\tv286 = *([v258 @ X8_v6 (Il2CppClass<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>)+12E]);\n\tv260 = *([v258 @ X8_v6 (Il2CppClass<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>)+12E]) == 0;\n\tif (v260) goto L_0065;\n\tv212 = *([v258 @ X8_v6 (Il2CppClass<_game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition>)+B0]) + 8;\n\tv212 = v212 + 0x10;\n\tv274 = v286 - 1;\n\tv263 = v286 != 1;\n\tv286 = v274;\n\tif (v263) goto L_0048;\nL_0065:\n\tv225 = _game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition::CanClaim(v141, em, entity, color);\n\tv289 = v225 == 0;\n\tv228 = ~v289;\n\tif (v228) goto L_0076;\n\tgoto L_007E;\nL_006B:\n\tv174 = *([v212 @ X10_v8]) << 4;\n\tv292 = v258 + v174;\n\tv232 = v292 + 0x138;\n\t*([v232 @ X8_v10])(v226, v141, em, entity, color, *([v232 @ X8_v10+8]), v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv229 = v226 == 0;\n\tif (v229) goto L_007E;\nL_0076:\n\tv148 = v233 + 1;\n\tv166 = this._conditions;\n\tv295 = this._conditions == 0;\n\tv143 = ~v295;\n\tv233 = v148;\n\tif (v143) goto L_0035;\n\tthrow System.NullReferenceException;\nL_007E:\n\tv236 = v233 - v166.Count;\n\tv237 = v236 < 0;\n\tv239 = v233 ^ v166.Count;\n\tv240 = v233 ^ v236;\n\tv241 = v239 & v240;\n\tv242 = v241 < 0;\n\tv243 = v237 == v242;\n\treturn v243;\nL_0023:\n\tv166 = this._conditions;\nL_0048:\n\tv200 = *([v212 @ X10_v8-8]) == _game.CoreSystem.New.MoldSystem.Core.Conditions.IClaimCondition;\n\tif (v200) goto L_006B;\nL_0035:\n\tv89 = v233 >= v166.Count;\n\tif (v89) goto L_007E;\n")]
		public bool CanClaim(EntityManager em, Entity entity, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldClaimValidator::CanClaim");
			return default;
		}
	}
}
