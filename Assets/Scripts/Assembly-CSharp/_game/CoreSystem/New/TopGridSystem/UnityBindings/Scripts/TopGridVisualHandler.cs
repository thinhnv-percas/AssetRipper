using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;

namespace _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts
{
	[Token(Token = "0x2000139")]
	public class TopGridVisualHandler : MonoBehaviour, IDisposable
	{
		[Token(Token = "0x40003FC")]
		[FieldOffset(Offset = "0x20")]
		private IReadOnlyList<ITopGridVisualHandler> _handlers;

		[Inject(false)]
		[Token(Token = "0x40003FD")]
		[FieldOffset(Offset = "0x28")]
		private TopGridEntitySystemCreator _entityCreator;

		[Token(Token = "0x40003FE")]
		[FieldOffset(Offset = "0x30")]
		private TopGridVisualGridController _visualGridController;

		[Token(Token = "0x40003FF")]
		[FieldOffset(Offset = "0x38")]
		internal bool _ownedBySpawn;

		[Token(Token = "0x170000A2")]
		public Transform VisualParent
		{
			[Token(Token = "0x6000639")]
			[Address(RVA = "0x3DB31AC", Offset = "0x3DB31AC", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this._visualGridController, 0);\n\tv63 = ~v55;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv84 = this;\n\tgoto L_003B;\nL_FFFFFFFF:\n\tv84 = this._visualGridController;\nL_003B:\n\treturnVal1 = UnityEngine.Component::get_transform(v84);\n\treturn returnVal1;\n")]
			get
			{
				TopGridVisualHandler topGridVisualHandler = (TopGridVisualHandler)((_visualGridController != null) ? ((MonoBehaviour)_visualGridController) : ((MonoBehaviour)this));
				return topGridVisualHandler.transform;
			}
		}

		[Token(Token = "0x6000638")]
		[Address(RVA = "0x3DB31A0", Offset = "0x3DB31A0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._ownedBySpawn = 1;\n\treturn;\n")]
		public void MarkSpawned()
		{
			_ownedBySpawn = true;
		}

		[Inject(false)]
		[Token(Token = "0x600063A")]
		[Address(RVA = "0x3DB325C", Offset = "0x3DB325C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_0037;\nL_0037:\n\tv93 = UnityEngine.Object::op_Inequality(this._visualGridController, 0);\n\tv120 = ~v93;\n\tv99 = ~v120;\n\tif (v99) goto L_0047;\n\tgoto L_0078;\nL_0047:\n\tv138 = UnityEngine.Component::get_transform(this._visualGridController);\n\tv173 = UnityEngine.Transform::get_parent(v138);\n\tgoto L_0052;\nL_0052:\n\tv95 = UnityEngine.Object::op_Inequality(v173, 0);\n\tv177 = ~v95;\n\tv101 = ~v177;\n\tif (v101) goto L_0062;\n\tgoto L_0078;\nL_0062:\n\tv184 = UnityEngine.Component::get_transform(this);\n\tv148 = UnityEngine.Component::get_transform(this._visualGridController);\n\tv149 = UnityEngine.Transform::get_parent(v148);\n\tUnityEngine.Transform::SetParent(v184, v149, 0);\nL_0078:\n\tv113 = System.Linq.Enumerable::ToList(handlers);\n\tthis._handlers = v113;\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler::InitVisuals(this);\n\treturn;\nL_001D:\n\tthis._visualGridController = visualGridController;\n\tv66 = this._ownedBySpawn != 1;\n\tif (v66) goto L_0078;\n")]
		private void Construct(IEnumerable<ITopGridVisualHandler> handlers, TopGridVisualGridController visualGridController)
		{
			_visualGridController = visualGridController;
			if (_ownedBySpawn && _visualGridController != null)
			{
				Transform transform = _visualGridController.transform;
				Transform parent = transform.parent;
				if (parent != null)
				{
					Transform transform2 = base.transform;
					Transform transform3 = _visualGridController.transform;
					Transform parent2 = transform3.parent;
					transform2.SetParent(parent2, worldPositionStays: false);
				}
			}
			List<object> handlers2 = ((IEnumerable<object>)handlers).ToList();
			_handlers = (IReadOnlyList<ITopGridVisualHandler>)handlers2;
			InitVisuals();
		}

		[Token(Token = "0x600063B")]
		[Address(RVA = "0x3DB33F0", Offset = "0x3DB33F0", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = 0xB78E000;\n\tv26 = *([B78E0D5]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0107;\n\tv32 = *([B78E0D4]) & 1;\n\tv33 = v32 == 0;\n\tif (v33) goto L_0114;\nL_FFFFFFFF:\n\tv88 = this._visualGridController;\n\tgoto L_0021;\nL_0021:\n\tv94 = UnityEngine.Object::op_Inequality(v88, 0);\n\tv102 = ~v94;\nL_FFFFFFFF:\n\tv109 = this;\n\tif (v102) goto L_002A;\nL_FFFFFFFF:\n\tv109 = this._visualGridController;\nL_002A:\n\tv112 = UnityEngine.Component::get_transform(v109);\n\tv295 = this._handlers;\nL_FFFFFFFF:\n\tv298 = 0;\nL_FFFFFFFF:\n\tv235 = 0;\n\tgoto L_0045;\nL_003D:\n\tv298 = *([v471 @ X0_v30+8]);\n\tv228 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler::InitVisuals(v448, v112);\n\tv235 = v235 + 1;\n\tv295 = this._handlers;\nL_0045:\n\tv343 = *([v295 @ X22_v5 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv379 = *([v343 @ X8_v13 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv307 = *([v343 @ X8_v13 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v307) goto L_0069;\n\tv287 = *([v343 @ X8_v13 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv287 = v287 + 0x10;\n\tv366 = v379 - 1;\n\tv348 = v379 != 1;\nL_FFFFFFFF:\n\tv379 = v366;\n\tif (v348) goto L_0050;\nL_0069:\n\tv303 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Count(v295);\n\tv259 = v235 < v303;\n\tif (v259) goto L_008A;\n\tgoto L_00FC;\nL_0078:\n\tv257 = *([v287 @ X10_v19]) << 4;\n\tv393 = v343 + v257;\n\tv394 = v393 + 0x138;\n\t*([v394 @ X0_v44])(v304, v295, *([v394 @ X0_v44+8]), v298, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv260 = v235 >= v304;\n\tif (v260) goto L_00FC;\nL_008A:\n\tv213 = this._handlers;\n\tv398 = *([v213 @ X22_v6 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv426 = *([v398 @ X8_v15 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv400 = *([v398 @ X8_v15 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v400) goto L_00B3;\n\tv195 = *([v398 @ X8_v15 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv195 = v195 + 0x10;\n\tv413 = v426 - 1;\n\tv403 = v426 != 1;\nL_FFFFFFFF:\n\tv426 = v413;\n\tif (v403) goto L_0099;\nL_00B3:\n\tv448 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Item(v213, v235);\n\tv429 = v448 == 0;\n\tv241 = ~v429;\n\tif (v241) goto L_00C4;\n\tgoto L_00F0;\nL_00B9:\n\tv125 = *([v195 @ X10_v14]) << 4;\n\tv431 = v398 + v125;\n\tv432 = v431 + 0x138;\n\t*([v432 @ X0_v37])(v448, v213, v235, *([v432 @ X0_v37+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00C4:\n\tv452 = *([v448 @ X0_v28]);\n\tv481 = *([v452 @ X8_v17+12E]);\n\tv454 = *([v452 @ X8_v17+12E]) == 0;\n\tif (v454) goto L_003D;\n\tv190 = *([v452 @ X8_v17+B0]) + 8;\n\tv190 = v190 + 0x10;\n\tv468 = v481 - 1;\n\tv457 = v481 != 1;\nL_FFFFFFFF:\n\tv481 = v468;\n\tif (v457) goto L_00CF;\n\tgoto L_003D;\nL_00E4:\n\tv121 = *([v190 @ X10_v8]) << 4;\n\tv486 = v452 + v121;\n\tv244 = v486 + 0x138;\n\tv298 = *([v244 @ X8_v19+8]);\n\t*([v244 @ X8_v19])(v227, v448, v112, *([v244 @ X8_v19+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv235 = v235 + 1;\n\tv295 = this._handlers;\n\tv487 = this._handlers == 0;\n\tv237 = ~v487;\n\tif (v237) goto L_0045;\nL_00F0:\n\tthrow System.NullReferenceException;\nL_00FC:\n\treturn;\nL_0107:\n\t*([v24 @ X20_v1+D5]) = 1;\n\tv105 = *([B78E0D4]) & 1;\n\tv106 = v105 == 0;\n\tv57 = ~v106;\n\tif (v57) goto L_FFFFFFFF;\nL_0114:\n\t*([B78E0D4]) = 1;\nL_FFFFFFFF:\n\tv88 = this._visualGridController;\n\tgoto L_0021;\nL_0050:\n\tv384 = *([v287 @ X10_v19-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v384) goto L_0078;\nL_0099:\n\tv167 = *([v195 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v167) goto L_00B9;\nL_00CF:\n\tv162 = *([v190 @ X10_v8-8]) == _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler;\n\tif (v162) goto L_00E4;\n")]
		public void InitVisuals()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridVisualHandler::InitVisuals");
		}

		[Token(Token = "0x600063C")]
		[Address(RVA = "0x3DB368C", Offset = "0x3DB368C", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv156 = 0;\n\tgoto L_0038;\nL_0030:\n\tv136 = *([v409 @ X0_v9+8]);\n\tv215 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler::SyncWithData(v386, em);\n\tv156 = v156 + 1;\n\tv139 = this._handlers;\nL_0038:\n\tv226 = *([v139 @ X22_v4 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv262 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv149 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v149) goto L_005C;\n\tv122 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv122 = v122 + 0x10;\n\tv249 = v262 - 1;\n\tv231 = v262 != 1;\n\tv262 = v249;\n\tif (v231) goto L_0043;\nL_005C:\n\tv145 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Count(v139);\n\tv76 = v156 < v145;\n\tif (v76) goto L_007D;\n\tgoto L_00F0;\nL_006B:\n\tv72 = *([v122 @ X10_v19]) << 4;\n\tv276 = v226 + v72;\n\tv277 = v276 + 0x138;\n\t*([v277 @ X0_v23])(v146, v139, *([v277 @ X0_v23+8]), v136, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv77 = v156 >= v146;\n\tif (v77) goto L_00F0;\nL_007D:\n\tv297 = this._handlers;\n\tv300 = *([v297 @ X22_v5 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv364 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv302 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v302) goto L_00A6;\n\tv325 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv325 = v325 + 0x10;\n\tv351 = v364 - 1;\n\tv341 = v364 != 1;\n\tv364 = v351;\n\tif (v341) goto L_008C;\nL_00A6:\n\tv386 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Item(v297, v156);\n\tv367 = v386 == 0;\n\tv335 = ~v367;\n\tif (v335) goto L_00B7;\n\tgoto L_00E4;\nL_00AC:\n\tv305 = *([v325 @ X10_v14]) << 4;\n\tv369 = v300 + v305;\n\tv370 = v369 + 0x138;\n\t*([v370 @ X0_v16])(v386, v297, v156, *([v370 @ X0_v16+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00B7:\n\tv390 = *([v386 @ X0_v7]);\n\tv419 = *([v390 @ X8_v10+12E]);\n\tv392 = *([v390 @ X8_v10+12E]) == 0;\n\tif (v392) goto L_0030;\n\tv203 = *([v390 @ X8_v10+B0]) + 8;\n\tv203 = v203 + 0x10;\n\tv406 = v419 - 1;\n\tv395 = v419 != 1;\n\tv419 = v406;\n\tif (v395) goto L_00C2;\n\tgoto L_0030;\nL_00D7:\n\tv424 = *([v203 @ X10_v8]) + 2;\n\tv173 = v424 << 4;\n\tv425 = v390 + v173;\n\tv222 = v425 + 0x138;\n\tv136 = *([v222 @ X8_v12+8]);\n\t*([v222 @ X8_v12])(v216, v386, em, *([v222 @ X8_v12+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv156 = v156 + 1;\n\tv139 = this._handlers;\n\tv426 = this._handlers == 0;\n\tv219 = ~v426;\n\tif (v219) goto L_0038;\nL_00E4:\n\tthrow System.NullReferenceException;\nL_00F0:\n\treturn;\nL_001F:\n\tv139 = this._handlers;\n\tv53 = this._handlers == 0;\n\tif (v53) goto L_00F0;\nL_0043:\n\tv267 = *([v122 @ X10_v19-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v267) goto L_006B;\nL_008C:\n\tv317 = *([v325 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v317) goto L_00AC;\nL_00C2:\n\tv191 = *([v203 @ X10_v8-8]) == _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler;\n\tif (v191) goto L_00D7;\n")]
		public void SyncAll(EntityManager em)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridVisualHandler::SyncAll");
		}

		[Token(Token = "0x600063D")]
		[Address(RVA = "0x3DB389C", Offset = "0x3DB389C", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv156 = 0;\n\tgoto L_0038;\nL_0030:\n\tv136 = *([v409 @ X0_v9+8]);\n\tv215 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler::OnEntityRemoving(v386, entity);\n\tv156 = v156 + 1;\n\tv139 = this._handlers;\nL_0038:\n\tv226 = *([v139 @ X22_v4 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv262 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv149 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v149) goto L_005C;\n\tv122 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv122 = v122 + 0x10;\n\tv249 = v262 - 1;\n\tv231 = v262 != 1;\n\tv262 = v249;\n\tif (v231) goto L_0043;\nL_005C:\n\tv145 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Count(v139);\n\tv76 = v156 < v145;\n\tif (v76) goto L_007D;\n\tgoto L_00F0;\nL_006B:\n\tv72 = *([v122 @ X10_v19]) << 4;\n\tv276 = v226 + v72;\n\tv277 = v276 + 0x138;\n\t*([v277 @ X0_v23])(v146, v139, *([v277 @ X0_v23+8]), v136, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv77 = v156 >= v146;\n\tif (v77) goto L_00F0;\nL_007D:\n\tv297 = this._handlers;\n\tv300 = *([v297 @ X22_v5 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv364 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv302 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v302) goto L_00A6;\n\tv325 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv325 = v325 + 0x10;\n\tv351 = v364 - 1;\n\tv341 = v364 != 1;\n\tv364 = v351;\n\tif (v341) goto L_008C;\nL_00A6:\n\tv386 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Item(v297, v156);\n\tv367 = v386 == 0;\n\tv335 = ~v367;\n\tif (v335) goto L_00B7;\n\tgoto L_00E4;\nL_00AC:\n\tv305 = *([v325 @ X10_v14]) << 4;\n\tv369 = v300 + v305;\n\tv370 = v369 + 0x138;\n\t*([v370 @ X0_v16])(v386, v297, v156, *([v370 @ X0_v16+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00B7:\n\tv390 = *([v386 @ X0_v7]);\n\tv419 = *([v390 @ X8_v10+12E]);\n\tv392 = *([v390 @ X8_v10+12E]) == 0;\n\tif (v392) goto L_0030;\n\tv203 = *([v390 @ X8_v10+B0]) + 8;\n\tv203 = v203 + 0x10;\n\tv406 = v419 - 1;\n\tv395 = v419 != 1;\n\tv419 = v406;\n\tif (v395) goto L_00C2;\n\tgoto L_0030;\nL_00D7:\n\tv424 = *([v203 @ X10_v8]) + 3;\n\tv173 = v424 << 4;\n\tv425 = v390 + v173;\n\tv222 = v425 + 0x138;\n\tv136 = *([v222 @ X8_v12+8]);\n\t*([v222 @ X8_v12])(v216, v386, entity, *([v222 @ X8_v12+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv156 = v156 + 1;\n\tv139 = this._handlers;\n\tv426 = this._handlers == 0;\n\tv219 = ~v426;\n\tif (v219) goto L_0038;\nL_00E4:\n\tthrow System.NullReferenceException;\nL_00F0:\n\treturn;\nL_001F:\n\tv139 = this._handlers;\n\tv53 = this._handlers == 0;\n\tif (v53) goto L_00F0;\nL_0043:\n\tv267 = *([v122 @ X10_v19-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v267) goto L_006B;\nL_008C:\n\tv317 = *([v325 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v317) goto L_00AC;\nL_00C2:\n\tv191 = *([v203 @ X10_v8-8]) == _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler;\n\tif (v191) goto L_00D7;\n")]
		public void NotifyEntityRemoving(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridVisualHandler::NotifyEntityRemoving");
		}

		[Token(Token = "0x600063E")]
		[Address(RVA = "0x3DB3AAC", Offset = "0x3DB3AAC", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv203 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\tv244 = 0;\n\tgoto L_003E;\nL_0038:\n\tv214 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler::Cleanup(v475);\n\tv244 = v244 + 1;\n\tv270 = this._handlers;\nL_FFFFFFFF:\n\tv269 = 1;\nL_003E:\n\tv275 = *([v270 @ X21_v13 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv368 = *([v275 @ X8_v22 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv277 = *([v275 @ X8_v22 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v277) goto L_0062;\n\tv300 = *([v275 @ X8_v22 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv300 = v300 + 0x10;\n\tv346 = v368 - 1;\n\tv328 = v368 != 1;\nL_FFFFFFFF:\n\tv368 = v346;\n\tif (v328) goto L_0049;\nL_0062:\n\tv310 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Count(v270);\n\tv281 = v244 < v310;\n\tif (v281) goto L_0083;\nL_FFFFFFFF:\n\tv439 = this;\n\tgoto L_00EC;\nL_0071:\n\tv280 = *([v300 @ X10_v19]) << 4;\n\tv402 = v275 + v280;\n\tv403 = v402 + 0x138;\n\t*([v403 @ X0_v80])(v311, v270, *([v403 @ X0_v80+8]), v269, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv282 = v244 >= v311;\nL_FFFFFFFF:\n\tv439 = this;\n\tif (v282) goto L_00EC;\nL_0083:\n\tv200 = this._handlers;\n\tv413 = *([v200 @ X21_v14 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>)]);\n\tv452 = *([v413 @ X8_v24 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]);\n\tv415 = *([v413 @ X8_v24 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+12E]) == 0;\n\tif (v415) goto L_00A9;\n\tv166 = *([v413 @ X8_v24 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>>)+B0]) + 8;\n\tv166 = v166 + 0x10;\n\tv430 = v452 - 1;\n\tv420 = v452 != 1;\nL_FFFFFFFF:\n\tv452 = v430;\n\tif (v420) goto L_0092;\nL_00A9:\n\tv269 = *([v433 @ X0_v70+8]);\n\tv475 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>::get_Item(v200, v244);\n\tv455 = v475 == 0;\n\tv226 = ~v455;\n\tif (v226) goto L_00BD;\n\tgoto L_00E9;\nL_00B2:\n\tv77 = *([v166 @ X10_v14]) << 4;\n\tv459 = v413 + v77;\n\tv460 = v459 + 0x138;\n\tv269 = *([v460 @ X0_v73+8]);\n\t*([v460 @ X0_v73])(v475, v200, v244, *([v460 @ X0_v73+8]), v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00BD:\n\tv479 = *([v475 @ X0_v64]);\n\tv518 = *([v479 @ X8_v26+12E]);\n\tv481 = *([v479 @ X8_v26+12E]) == 0;\n\tif (v481) goto L_0038;\n\tv162 = *([v479 @ X8_v26+B0]) + 8;\n\tv162 = v162 + 0x10;\n\tv500 = v518 - 1;\n\tv489 = v518 != 1;\nL_FFFFFFFF:\n\tv518 = v500;\n\tif (v489) goto L_00C8;\n\tgoto L_0038;\nL_00DD:\n\tv527 = *([v162 @ X10_v8]) + 1;\n\tv74 = v527 << 4;\n\tv528 = v479 + v74;\n\tv233 = v528 + 0x138;\n\t*([v233 @ X8_v28])(v213, v475, *([v233 @ X8_v28+8]), v269, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv244 = v244 + 1;\n\tv270 = this._handlers;\n\tv529 = this._handlers == 0;\n\tv223 = ~v529;\nL_FFFFFFFF:\n\tv439 = this;\n\tif (v223) goto L_003E;\nL_00E9:\n\tthrow System.NullReferenceException;\nL_00EC:\n\tv320 = *([B78E0D4]) & 1;\n\tv321 = v320 == 0;\n\tif (v321) goto L_00FF;\n\tv393 = v439._visualGridController;\n\tv350 = *([v203 @ X22_v3 (System.Int32)]);\n\tv352 = *([v350 @ X8_v19+E4]) == 0;\nL_FFFFFFFF:\n\tv383 = v439._visualGridController;\n\tif (v352) goto L_010C;\nL_00F6:\n\tv391 = UnityEngine.Object::op_Inequality(v383, 0);\n\tv406 = ~v391;\n\tv407 = ~v406;\n\tif (v407) goto L_FFFFFFFF;\n\tgoto L_0114;\nL_00FF:\n\t*([B78E0D4]) = 1;\n\tv393 = v439._visualGridController;\n\tv388 = *([v203 @ X22_v3 (System.Int32)]);\n\tv400 = *([v388 @ X8_v17+E4]) == 0;\n\tv386 = ~v400;\nL_FFFFFFFF:\n\tv383 = v439._visualGridController;\n\tif (v386) goto L_00F6;\nL_010C:\n\tv411 = UnityEngine.Object::op_Inequality(v393, 0);\n\tv417 = ~v411;\n\tif (v417) goto L_0114;\nL_FFFFFFFF:\n\tv439 = v439._visualGridController;\nL_0114:\n\tv442 = UnityEngine.Component::get_transform(v439);\n\tv456 = *([v203 @ X22_v3 (System.Int32)]);\n\tv457 = *([v456 @ X0_v6+E4]) == 0;\n\tif (v457) goto L_0126;\n\tv485 = UnityEngine.Object::op_Equality(v442, 0);\n\tv504 = v485 == 0;\n\tif (v504) goto L_012F;\n\tgoto L_01A2;\nL_0126:\n\tv508 = UnityEngine.Object::op_Equality(v442, 0);\n\tv524 = v508 == 0;\n\tv522 = ~v524;\n\tif (v522) goto L_01A2;\nL_012F:\n\tv567 = UnityEngine.Transform::get_childCount(v442);\n\tv548 = v567 < 1;\n\tif (v548) goto L_01A2;\nL_FFFFFFFF:\n\tv594 = v567;\n\tgoto L_014D;\nL_013F:\n\tUnityEngine.Object::DestroyImmediate(v651);\nL_014B:\n\tv531 = v594 <= 0;\n\tif (v531) goto L_01A2;\nL_014D:\n\tv594 = v594 - 1;\n\tv598 = UnityEngine.Transform::GetChild(v442, v594);\n\tv599 = *([v203 @ X22_v3 (System.Int32)]);\n\tv601 = *([v599 @ X0_v14+E4]) == 0;\n\tif (v601) goto L_0164;\n\tv605 = UnityEngine.Object::op_Equality(v598, 0);\n\tv608 = v605 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_014B;\n\tgoto L_016C;\nL_0164:\n\tv613 = UnityEngine.Object::op_Equality(v598, 0);\n\tv631 = v613 == 0;\n\tv623 = ~v631;\n\tif (v623) goto L_014B;\nL_016C:\n\tgoto L_016E;\nL_016E:\n\tv637 = UnityEngine.Application::get_isPlaying();\n\tv639 = ~v637;\n\tif (v639) goto L_018C;\n\tv648 = UnityEngine.Component::get_gameObject(v598);\n\tgoto L_0180;\nL_018C:\n\tv651 = UnityEngine.Component::get_gameObject(v598);\n\tgoto L_013F;\nL_01A2:\n\treturn;\nL_0024:\n\tv270 = this._handlers;\nL_0049:\n\tv373 = *([v300 @ X10_v19-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v373) goto L_0071;\nL_0092:\n\tv130 = *([v166 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler>;\n\tif (v130) goto L_00B2;\nL_00C8:\n\tv126 = *([v162 @ X10_v8-8]) == _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler;\n\tif (v126) goto L_00DD;\nL_0180:\n\tUnityEngine.Object::Destroy(v648);\n\tgoto L_014B;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Cleanup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridVisualHandler::Cleanup");
		}

		[Token(Token = "0x600063F")]
		[Address(RVA = "0x3DB3EB4", Offset = "0x3DB3EB4", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_002E;\nL_002E:\n\tv70 = UnityEngine.Object::op_Equality(this, 0);\n\tv73 = v70 == 0;\n\tif (v73) goto L_0049;\nL_0039:\n\treturn;\nL_0049:\n\tgoto L_004C;\nL_004C:\n\tv149 = UnityEngine.Application::get_isPlaying();\n\tv110 = UnityEngine.Component::get_gameObject(this);\n\tv153 = ~v149;\n\tif (v153) goto L_0062;\n\tgoto L_005F;\nL_005F:\n\tUnityEngine.Object::Destroy(v110);\n\treturn;\nL_0062:\n\tgoto L_006B;\nL_006B:\n\tUnityEngine.Object::DestroyImmediate(v110);\n\treturn;\nL_0018:\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler::Cleanup(this);\n\tv56 = this._ownedBySpawn != 1;\n\tif (v56) goto L_0039;\n")]
		public void Dispose()
		{
			Cleanup();
			if (_ownedBySpawn && !(this == null))
			{
				bool isPlaying = Application.isPlaying;
				GameObject obj = base.gameObject;
				if (isPlaying)
				{
					UnityEngine.Object.Destroy(obj);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(obj);
				}
			}
		}

		[Token(Token = "0x6000640")]
		[Address(RVA = "0x3DB400C", Offset = "0x3DB400C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TopGridVisualHandler()
		{
		}
	}
}
