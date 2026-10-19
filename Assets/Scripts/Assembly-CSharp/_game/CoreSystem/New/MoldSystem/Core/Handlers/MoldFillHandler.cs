using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Results;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.MoldSystem.Core.Handlers
{
	[Token(Token = "0x20002FB")]
	public class MoldFillHandler
	{
		[Inject(false)]
		[Token(Token = "0x400092C")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400092D")]
		[FieldOffset(Offset = "0x18")]
		private SandParticleParams _resolvedParams;

		[Token(Token = "0x6000D2D")]
		[Address(RVA = "0x3EEBD9C", Offset = "0x3EEBD9C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv65 = v52.dataFill + 1;\n\tv77 = v65 & 0xFFFFFFFF;\n\tv78 = v77 << 0x20;\n\tv79 = v52 & 0xFFFFFFFF;\n\tv80 = v79 | v78;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entity, v80);\n\treturn;\n")]
		public void ClaimSlot(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillHandler::ClaimSlot");
		}

		[Token(Token = "0x6000D2E")]
		[Address(RVA = "0x3EEBE48", Offset = "0x3EEBE48", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv66 = entity + 1;\n\tv70 = v66 - v52;\n\tv71 = v70 < 0;\n\tv73 = v66 ^ v52;\n\tv74 = v66 ^ v70;\n\tv75 = v73 & v74;\n\tv76 = v75 < 0;\n\tv77 = v71 == v76;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entity, v52);\n\treturn v77;\n")]
		public FillResult Fill(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillHandler::Fill");
			return default;
		}

		[Token(Token = "0x6000D2F")]
		[Address(RVA = "0x3EEBEFC", Offset = "0x3EEBEFC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv52 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, entity);\n\tv96 = entity & 0x100000000;\n\tv98 = v96 == 0;\n\tv72 = ~v98;\n\tif (v72) goto L_FFFFFFFF;\n\tv168 = v52.dataFill < 0;\n\tv167 = v52.dataFill == 0;\n\tv108 = v52.dataFill ^ v52.dataFill;\n\tv109 = v52.dataFill & v108;\n\tv165 = v109 < 0;\n\tgoto L_0037;\nL_FFFFFFFF:\n\tv165 = 0;\nL_FFFFFFFF:\n\tv167 = 1;\nL_FFFFFFFF:\n\tv168 = 0;\n\tv182 = v52 & 0xFFFFFFFF00000000;\n\tv175 = v182 | v52;\n\tv178 = v175 + 0xFFFFFFFF00000000;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entity, v178);\nL_005D:\n\treturn v170;\nL_0037:\n\tv169 = v168 == v165;\n\tv54 = ~v167;\n\tv170 = v169 & v54;\n\tv57 = v170 != 1;\n\tif (v57) goto L_005D;\n")]
		public bool ReleaseSlot(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillHandler::ReleaseSlot");
			return default;
		}

		[Token(Token = "0x6000D30")]
		[Address(RVA = "0x3EEBFC4", Offset = "0x3EEBFC4", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv60 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv207 = *([v60 @ X0_v23 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv266 = *([v207 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv209 = *([v207 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v209) goto L_005C;\n\tv265 = *([v207 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv265 = v265 + 0x10;\n\tv238 = v266 - 1;\n\tv218 = v266 != 1;\nL_FFFFFFFF:\n\tv266 = v238;\n\tif (v218) goto L_0042;\nL_005C:\n\tv324 = System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::GetEnumerator(v60);\n\tv285 = v324 == 0;\n\tv286 = ~v285;\nL_FFFFFFFF:\n\tv308 = v324;\nL_FFFFFFFF:\n\tv466 = &v308 @ stack_-58_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv310 = 0;\n\tif (v286) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv310 = 0;\n\tgoto L_0146;\nL_0066:\n\tv295 = *([v265 @ X10_v32]) << 4;\n\tv296 = v207 + v295;\n\tv297 = v296 + 0x138;\n\tv187 = *([v297 @ X8_v36+8]);\n\t*([v297 @ X8_v36])(v324, v60, *([v297 @ X8_v36+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv305 = v324 == 0;\nL_FFFFFFFF:\n\tv308 = v324;\nL_FFFFFFFF:\n\tv466 = &v308 @ stack_-58_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\nL_FFFFFFFF:\n\tv310 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv310 = 0;\n\tif (v305) goto L_0146;\nL_FFFFFFFF:\n\tv415 = v324;\n\tgoto L_0085;\nL_007F:\n\tv389 = v308 == 0;\nL_FFFFFFFF:\n\tv415 = v308;\n\tif (v389) goto L_0146;\nL_0085:\n\tgoto L_00AB;\n\tv537 = v308 == 0;\n\tif (v537) goto L_014A;\n\tgoto L_00DC;\n\tv758 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v755);\n\tv520 = v755 == v758.dataFill;\nL_FFFFFFFF:\n\tv187 = v755;\n\tif (v520) goto L_007F;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v755, v758);\nL_FFFFFFFF:\n\tv187 = v755;\n\tgoto L_007F;\nL_0106:\n\tv499 = &v308 @ stack_-58_v8 (System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>);\n\tv500 = *([v499 @ X8_v26]);\n\tv497 = *([v499 @ X8_v26]) == 0;\nL_FFFFFFFF:\n\tv502 = 0;\nL_FFFFFFFF:\n\tv160 = v466;\nL_FFFFFFFF:\n\tv187 = 0;\nL_FFFFFFFF:\n\tv198 = 0;\n\tif (v497) goto L_0137;\nL_0110:\n\tgoto L_0136;\n\treturn;\nL_0146:\n\tv394 = new System.NullReferenceException();\n\tgoto L_014D;\nL_0148:\n\tv533 = new System.NullReferenceException();\n\tgoto L_014D;\nL_014A:\n\tv534 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv187 = 0;\n\tgoto L_014D;\nL_014D:\n\t// 333 Interrupt\nL_0150:\n\tv200 = new System.OutOfMemoryException();\n\tgoto L_0161;\nL_0161:\n\tv251 = v187 != 1;\n\tif (v251) goto L_016F;\n\tv287 = 0x8BF5BC4(v200, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv502 = *([v287 @ X0_v14]);\n\tv341 = 0x8BF5BF4(v287, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv500 = *([v160 @ stack_-60_v1]);\n\tv422 = *([v160 @ stack_-60_v1]) == 0;\n\tv423 = ~v422;\nL_FFFFFFFF:\n\tv310 = *([v287 @ X0_v14]);\n\tif (v423) goto L_0110;\nL_FFFFFFFF:\n\tv160 = v160;\nL_FFFFFFFF:\n\tv310 = *([v287 @ X0_v14]);\nL_FFFFFFFF:\n\tv198 = *([v287 @ X0_v14]);\n\tgoto L_0137;\nL_016F:\n\tv290 = 0x3175484(&v310 @ stack_-68_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv343 = 0x8BF0368(v200, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv424 = 0xA1B8(v343, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_002A:\n\tv308 = 0;\n\tthrow System.NullReferenceException;\nL_0042:\n\tv271 = *([v265 @ X10_v32-8]) == System.Collections.Generic.IEnumerable`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v271) goto L_0066;\nL_00AB:\n\tv495 = System.Collections.IEnumerator::MoveNext(v415);\n\tv663 = v495 == 0;\n\tif (v663) goto L_0106;\nL_00DC:\n\tv755 = System.Collections.Generic.IEnumerator`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Current(v308);\n\tv536 = this._em == 0;\n\tif (v536) goto L_0148;\nL_0137:\n\tv581 = v198 == 0;\n\tv192 = ~v581;\nL_FFFFFFFF:\n\tv466 = v160;\n\tif (v192) goto L_0150;\nL_0136:\n\tSystem.IDisposable::Dispose(v500);\nL_FFFFFFFF:\n\tv160 = v466;\nL_FFFFFFFF:\n\tv187 = 0;\nL_FFFFFFFF:\n\tv198 = v502;\n")]
		public void SyncVisualFillToData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillHandler::SyncVisualFillToData");
		}

		[Token(Token = "0x6000D31")]
		[Address(RVA = "0x3EEB0B0", Offset = "0x3EEB0B0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv52 = _game.CoreSystem.LevelCreator.MoldCellData::GetComponent(data);\n\tv58 = v52 == 0;\n\tif (v58) goto L_003E;\n\tv56 = _game.CoreSystem.LevelCreator.MoldCellData::GetComponent(data);\n\tv59 = v56 == 0;\n\tif (v59) goto L_003E;\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::InitEntity(this, entity, v52.gameColor, v56.amount);\n\treturn;\nL_003E:\n\treturn;\nL_0019:\n\tv45 = data == 0;\n\tif (v45) goto L_003E;\n")]
		public void InitEntity(Entity entity, MoldCellData data)
		{
			if (data == null)
			{
				return;
			}
			GameColorComponent component = data.GetComponent<GameColorComponent>();
			if (component != null)
			{
				MoldAmountComponent component2 = data.GetComponent<MoldAmountComponent>();
				if (component2 != null)
				{
					InitEntity(entity, component.gameColor, component2.amount);
				}
			}
		}

		[Token(Token = "0x6000D32")]
		[Address(RVA = "0x3EEBA60", Offset = "0x3EEBA60", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_0027:\n\tv71 = this._resolvedParams * amount;\n\tgoto L_002F;\nL_002F:\n\tv83 = 0x8BF6AF4(&v81 @ stack_-58_v6 (System.Double), entity, color, methodInfo, v39, v40, v41, v42, v71, v43, v44, v45, v46, v47, v48, v49);\n\tv91 = v71 < 0;\n\tv95 = v71 == v71;\n\tv96 = ~v95;\n\tv97 = v91 == v96;\n\tif (v97) goto L_0062;\n\tv124 = v71 == -0.5d;\n\tv131 = ~v124;\n\tif (v131) goto L_007B;\nL_FFFFFFFF:\n\tv168 = -1d;\nL_FFFFFFFF:\n\tv199 = v81;\nL_FFFFFFFF:\n\tv180 = v81;\n\tgoto L_006E;\nL_0062:\n\tv147 = v71 == 0.5d;\n\tv154 = ~v147;\n\tif (v154) goto L_007E;\nL_FFFFFFFF:\n\tv168 = 1d;\nL_FFFFFFFF:\n\tv199 = v81;\nL_FFFFFFFF:\n\tv180 = v81;\n\tgoto L_007A;\nL_FFFFFFFF:\n\tv199 = v182;\nL_007B:\n\tv160 = v71 + -0.5d;\n\tv199 = System.Math::Ceiling(v160);\n\tgoto L_0088;\nL_007E:\n\tv165 = v71 + 0.5d;\n\tv199 = System.Math::Floor(v165);\nL_0088:\n\tv216 = v199 - 1;\n\tv217 = v216 < 0;\n\tv218 = v216 == 0;\n\tv219 = v199 ^ 1;\n\tv220 = v199 ^ v216;\n\tv221 = v219 & v220;\n\tv222 = v221 < 0;\n\tv223 = v217 == v222;\n\tv224 = ~v218;\n\tv225 = v223 & v224;\n\tv226 = ~v225;\n\tif (v226) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv248 = v199;\n\tgoto L_009B;\nL_FFFFFFFF:\n\tv248 = 1;\nL_FFFFFFFF:\n\tv237 = v248;\n\tgoto L_00AC;\nL_FFFFFFFF:\n\tv237 = 1;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, color);\n\treturn;\nL_0026:\n\tgoto L_0027;\nL_006E:\n\tv182 = v199 + v168;\n\tv183 = v180 & 1;\n\tv185 = v183 == 0;\n\tv188 = ~v185;\n\tif (v188) goto L_FFFFFFFF;\nL_007A:\n\tgoto L_0088;\nL_009B:\n\tv262 = v199 == 0x7FF0000000000000;\n\tv254 = ~v262;\n\tv239 = ~v254;\n\tif (v239) goto L_FFFFFFFF;\nL_00AC:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, v237);\n")]
		public void InitEntity(Entity entity, GameColor color, float amount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldFillHandler::InitEntity");
		}

		[Token(Token = "0x6000D33")]
		[Address(RVA = "0x3EEC354", Offset = "0x3EEC354", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldFillHandler()
		{
		}
	}
}
