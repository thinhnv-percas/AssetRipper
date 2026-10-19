using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.EditMode;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode
{
	[ExecuteAlways]
	[Token(Token = "0x2000273")]
	public class TopGridReconcileTick_Editor : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x40007A5")]
		[FieldOffset(Offset = "0x20")]
		private ITopGridCmdProcessor _cmdProcessor;

		[Inject(false)]
		[Token(Token = "0x40007A6")]
		[FieldOffset(Offset = "0x28")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x40007A7")]
		[FieldOffset(Offset = "0x30")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x40007A8")]
		[FieldOffset(Offset = "0x38")]
		private LockGroupHandler _lockGroups;

		[Inject(false)]
		[Token(Token = "0x40007A9")]
		[FieldOffset(Offset = "0x40")]
		private TopGridVisualHandler _visualCoordinator;

		[Inject(false)]
		[Token(Token = "0x40007AA")]
		[FieldOffset(Offset = "0x48")]
		private TopGridEntitySystemCreator _entityCreator;

		[Inject(false)]
		[Token(Token = "0x40007AB")]
		[FieldOffset(Offset = "0x50")]
		private EditorHistory _history;

		[Inject(false)]
		[Token(Token = "0x40007AC")]
		[FieldOffset(Offset = "0x58")]
		private TopGridEditorMutations _mutations;

		[Inject(false)]
		[Token(Token = "0x40007AD")]
		[FieldOffset(Offset = "0x60")]
		private LinkedCubeEditorMutations _linkedCubeMutations;

		[Inject(false)]
		[Token(Token = "0x40007AE")]
		[FieldOffset(Offset = "0x68")]
		private TopGridReconcile_RespCleanupSystem _respCleanup;

		[Inject(false)]
		[Token(Token = "0x40007AF")]
		[FieldOffset(Offset = "0x70")]
		private TopGridReconcile_BlockerCheckSystem _blockerCheck;

		[Inject(false)]
		[Token(Token = "0x40007B0")]
		[FieldOffset(Offset = "0x78")]
		private SandReconcile_NeighborDirtySystem _neighborDirty;

		[Inject(false)]
		[Token(Token = "0x40007B1")]
		[FieldOffset(Offset = "0x80")]
		private SandReconcile_GridReleaseSystem _gridRelease;

		[Inject(false)]
		[Token(Token = "0x40007B2")]
		[FieldOffset(Offset = "0x88")]
		private SandReconcile_LinkedBreakSystem _linkedBreak;

		[Inject(false)]
		[Token(Token = "0x40007B3")]
		[FieldOffset(Offset = "0x90")]
		private SandReconcile_PinTriggerSystem _pinTrigger;

		[Inject(false)]
		[Token(Token = "0x40007B4")]
		[FieldOffset(Offset = "0x98")]
		private SandReconcile_PinResolveSystem _pinResolve;

		[Inject(false)]
		[Token(Token = "0x40007B5")]
		[FieldOffset(Offset = "0xA0")]
		private SandReconcile_CellStateSystem _cellState;

		[Inject(false)]
		[Token(Token = "0x40007B6")]
		[FieldOffset(Offset = "0xA8")]
		private SandReconcile_TunnelSystem _tunnel;

		[Inject(false)]
		[Token(Token = "0x40007B7")]
		[FieldOffset(Offset = "0xB0")]
		private SandReconcile_UnlockSystem _unlock;

		[Inject(false)]
		[Token(Token = "0x40007B8")]
		[FieldOffset(Offset = "0xB8")]
		private SandReconcile_GarageCounterSystem _garageCounter;

		[Inject(false)]
		[Token(Token = "0x40007B9")]
		[FieldOffset(Offset = "0xC0")]
		private TopGridReconcile_CoverSystem _cover;

		[Inject(false)]
		[Token(Token = "0x40007BA")]
		[FieldOffset(Offset = "0xC8")]
		private TopGridReconcile_RevealSystem _reveal;

		[Inject(false)]
		[Token(Token = "0x40007BB")]
		[FieldOffset(Offset = "0xD0")]
		private SandReconcile_PourableEvaluatorSystem _pourableEvaluator;

		[Inject(false)]
		[Token(Token = "0x40007BC")]
		[FieldOffset(Offset = "0xD8")]
		private SandReconcile_MaterialSystem _material;

		[SerializeField]
		[Token(Token = "0x40007BD")]
		[FieldOffset(Offset = "0xE0")]
		private int m_undoVersion;

		[Token(Token = "0x40007BE")]
		[FieldOffset(Offset = "0xE4")]
		private int _lastSeenVersion;

		[Token(Token = "0x40007BF")]
		[FieldOffset(Offset = "0xE8")]
		private bool _isConstructed;

		[Token(Token = "0x170000C8")]
		public TopGridEditorMutations Mutations
		{
			[Token(Token = "0x6000AC9")]
			[Address(RVA = "0x3EBE3E0", Offset = "0x3EBE3E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Mutations;\n")]
			get
			{
				return _mutations;
			}
		}

		[Token(Token = "0x170000C9")]
		public LinkedCubeEditorMutations LinkedCubeMutations
		{
			[Token(Token = "0x6000ACA")]
			[Address(RVA = "0x3EBE3E8", Offset = "0x3EBE3E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.LinkedCubeMutations;\n")]
			get
			{
				return _linkedCubeMutations;
			}
		}

		[Token(Token = "0x170000CA")]
		public TopGridHandler GridHandler
		{
			[Token(Token = "0x6000ACB")]
			[Address(RVA = "0x3EBE3F0", Offset = "0x3EBE3F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.GridHandler;\n")]
			get
			{
				return _gridHandler;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6000ACC")]
		[Address(RVA = "0x3EBE3F8", Offset = "0x3EBE3F8", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv66 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v66, this, Il2CppMethodInfo);\n\tgoto L_0043;\nL_FFFFFFFF:\n\tv240 = 0;\nL_0058:\n\tv250 = System.Delegate::Remove(v237, v66);\n\tv251 = v250 == 0;\n\tif (v251) goto L_FFFFFFFF;\n\tv255 = 0x21C11D0(v250, System.Action`1<System.String>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv258 = v255 == 0;\n\tv259 = ~v258;\nL_FFFFFFFF:\n\tv240 = v255;\n\tif (v259) goto L_0049;\n\tgoto L_00D1;\nL_0064:\n\tv323 = this._history;\n\tv325 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v325, this, Il2CppMethodInfo);\n\tv366 = this._history == 0;\n\tif (v366) goto L_0118;\n\tgoto L_0079;\nL_FFFFFFFF:\n\tv410 = 0;\nL_008E:\n\tv419 = System.Delegate::Remove(v295, v325);\n\tv429 = v419 == 0;\n\tif (v429) goto L_FFFFFFFF;\n\tv310 = 0x21C11D0(v419, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv436 = v310 == 0;\n\tv313 = ~v436;\nL_FFFFFFFF:\n\tv410 = v310;\n\tif (v313) goto L_007F;\n\tgoto L_00D1;\nL_009A:\n\tv389 = this._history;\n\tv387 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v387, this, Il2CppMethodInfo);\n\tv388 = this._history == 0;\nL_FFFFFFFF:\n\tv325 = v387;\n\tif (v388) goto L_0118;\n\tgoto L_00AF;\nL_FFFFFFFF:\n\tv349 = 0;\nL_00C4:\n\tv466 = System.Delegate::Combine(v294, v387);\n\tv467 = v466 == 0;\n\tif (v467) goto L_FFFFFFFF;\n\tv309 = 0x21C11D0(v466, System.Action`1<System.String>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv470 = v309 == 0;\n\tv312 = ~v470;\nL_FFFFFFFF:\n\tv349 = v309;\n\tif (v312) goto L_00B5;\nL_00D1:\n\tthrow System.InvalidCastException;\nL_00D2:\n\tv359 = this._history;\n\tv325 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v325, this, Il2CppMethodInfo);\n\tv367 = this._history == 0;\n\tif (v367) goto L_0118;\n\tgoto L_00E7;\nL_FFFFFFFF:\n\tv115 = 0;\nL_00FC:\n\tv428 = System.Delegate::Combine(v134, v325);\n\tv430 = v428 == 0;\n\tif (v430) goto L_FFFFFFFF;\n\tv434 = 0x21C11D0(v428, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv440 = v434 == 0;\n\tv127 = ~v440;\nL_FFFFFFFF:\n\tv115 = v434;\n\tif (v127) goto L_00ED;\n\tthrow System.InvalidCastException;\nL_0117:\n\treturn;\nL_0118:\n\tthrow v325;\nL_0024:\n\tthis._isConstructed = 1;\n\tthis.m_undoVersion = 0;\n\tv56 = this._history;\n\tv57 = this._history == 0;\n\tif (v57) goto L_0117;\nL_0043:\n\tv215 = this._history + 0x40;\nL_FFFFFFFF:\n\tv237 = v56.HistoryPushed;\n\tgoto L_0058;\nL_0049:\n\tv244 = 0x220BDA0(v215, v240, v237, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv230 = v244 == v237;\nL_FFFFFFFF:\n\tv237 = v244;\n\tif (v230) goto L_0064;\nL_0079:\n\tv319 = this._history + 0x48;\nL_FFFFFFFF:\n\tv295 = v323.Restored;\n\tgoto L_008E;\nL_007F:\n\tv414 = 0x220BDA0(v319, v410, v295, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv379 = v414 == v295;\nL_FFFFFFFF:\n\tv295 = v414;\n\tif (v379) goto L_009A;\nL_00AF:\n\tv318 = this._history + 0x40;\nL_FFFFFFFF:\n\tv294 = v389.HistoryPushed;\n\tgoto L_00C4;\nL_00B5:\n\tv354 = 0x220BDA0(v318, v349, v294, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv338 = v354 == v294;\nL_FFFFFFFF:\n\tv294 = v354;\n\tif (v338) goto L_00D2;\nL_00E7:\n\tv132 = this._history + 0x48;\nL_FFFFFFFF:\n\tv134 = v359.Restored;\n\tgoto L_00FC;\nL_00ED:\n\tv125 = 0x220BDA0(v132, v115, v134, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv94 = v125 == v134;\nL_FFFFFFFF:\n\tv134 = v125;\n\tif (v94) goto L_0117;\n")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcileTick_Editor::Construct");
		}

		[Token(Token = "0x6000ACD")]
		[Address(RVA = "0x3EBE9E8", Offset = "0x3EBE9E8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._isConstructed != 1;\n\tif (v11) goto L_001D;\n\tv24 = UnityEngine.Time::get_deltaTime();\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode.TopGridReconcileTick_Editor::Tick(this, v24);\n\treturn;\nL_001D:\n\treturn;\n")]
		private void Update()
		{
			if (_isConstructed)
			{
				float deltaTime = Time.deltaTime;
				Tick(deltaTime);
			}
		}

		[Token(Token = "0x6000ACE")]
		[Address(RVA = "0x3EBEA20", Offset = "0x3EBEA20", Length = "0x338")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0047;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RespCleanupSystem::Execute(this._respCleanup);\n\tv177 = this._blockerCheck == 0;\n\tif (v177) goto L_00D2;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_BlockerCheckSystem::Execute(this._blockerCheck);\n\tv178 = this._gridRelease == 0;\n\tif (v178) goto L_00D4;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_GridReleaseSystem::Execute(this._gridRelease);\n\tv179 = this._linkedBreak == 0;\n\tif (v179) goto L_00D6;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem::Execute(this._linkedBreak);\n\tv180 = this._pinTrigger == 0;\n\tif (v180) goto L_00D8;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem::Execute(this._pinTrigger);\n\tv181 = this._cellState == 0;\n\tif (v181) goto L_00DA;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_CellStateSystem::Execute(this._cellState);\n\tv182 = this._neighborDirty == 0;\n\tif (v182) goto L_00DC;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_NeighborDirtySystem::Execute(this._neighborDirty);\n\tv183 = this._reveal == 0;\n\tif (v183) goto L_00DE;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteRevealDoneCleanup(this._reveal);\n\tv184 = this._pinResolve == 0;\n\tif (v184) goto L_00E0;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinResolveSystem::Execute(this._pinResolve);\n\tv194 = this._pourableEvaluator;\n\tv273 = this._pourableEvaluator == 0;\n\tif (v273) goto L_00CC;\n\tgoto L_007E;\n\tv289 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v194._em);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_PourableEvaluatorSystem::CheckBlocking(this._pourableEvaluator, v289);\n\tv185 = this._cover == 0;\n\tif (v185) goto L_00E2;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_CoverSystem::Execute(this._cover);\n\tv186 = this._reveal == 0;\n\tif (v186) goto L_00E4;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteCmdRevealIssue(this._reveal);\n\tv187 = this._material == 0;\n\tif (v187) goto L_00E6;\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_MaterialSystem::Execute(this._material);\n\tv188 = this._cmdProcessor == 0;\n\tif (v188) goto L_00E8;\n\tgoto L_00C1;\nL_00CC:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00CE:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00D0:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00D2:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00D4:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00D6:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00D8:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00DA:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00DC:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00DE:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00E0:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00E2:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00E4:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00E6:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_00E8:\n\tv159 = new System.NullReferenceException();\n\tgoto L_0122;\nL_0122:\n\t// 290 Interrupt\n\tv198 = 0x8BF5BF4(v159, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv210 = 0x8BF0368(v159, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv211 = 0xA1B8(v210, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0018:\n\tv48 = this._cmdProcessor == 0;\n\tif (v48) goto L_00CE;\nL_0047:\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor::Tick(this._cmdProcessor, dt);\n\tv176 = this._respCleanup == 0;\n\tif (v176) goto L_00D0;\nL_007E:\n\tv280 = v194._em == 0;\n\tif (v280) goto L_00CC;\nL_00C1:\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor::ProcessCommands(this._cmdProcessor);\n\treturn;\n")]
		public void Tick(float dt)
		{
			if (_cmdProcessor == null)
			{
				NullReferenceException ex = new NullReferenceException();
			}
			else
			{
				_cmdProcessor.Tick(dt);
				if (_respCleanup != null)
				{
					_respCleanup.Execute();
					if (_blockerCheck != null)
					{
						_blockerCheck.Execute();
						if (_gridRelease != null)
						{
							_gridRelease.Execute();
							if (_linkedBreak != null)
							{
								_linkedBreak.Execute();
								if (_pinTrigger != null)
								{
									_pinTrigger.Execute();
									if (_cellState != null)
									{
										_cellState.Execute();
										if (_neighborDirty != null)
										{
											_neighborDirty.Execute();
											if (_reveal != null)
											{
												_reveal.ExecuteRevealDoneCleanup();
												if (_pinResolve != null)
												{
													_pinResolve.Execute();
													SandReconcile_PourableEvaluatorSystem pourableEvaluator = _pourableEvaluator;
													if (_pourableEvaluator != null && pourableEvaluator._em != null)
													{
														IReadOnlyList<Entity> entities = pourableEvaluator._em.Query<SandRevealTag, SandCubeTag>();
														_pourableEvaluator.CheckBlocking(entities);
														if (_cover != null)
														{
															_cover.Execute();
															if (_reveal != null)
															{
																_reveal.ExecuteCmdRevealIssue();
																if (_material != null)
																{
																	_material.Execute();
																	if (_cmdProcessor != null)
																	{
																		_cmdProcessor.ProcessCommands();
																		return;
																	}
																	NullReferenceException ex = new NullReferenceException();
																}
																else
																{
																	NullReferenceException ex = new NullReferenceException();
																}
															}
															else
															{
																NullReferenceException ex = new NullReferenceException();
															}
														}
														else
														{
															NullReferenceException ex = new NullReferenceException();
														}
													}
													else
													{
														NullReferenceException ex = new NullReferenceException();
													}
												}
												else
												{
													NullReferenceException ex = new NullReferenceException();
												}
											}
											else
											{
												NullReferenceException ex = new NullReferenceException();
											}
										}
										else
										{
											NullReferenceException ex = new NullReferenceException();
										}
									}
									else
									{
										NullReferenceException ex = new NullReferenceException();
									}
								}
								else
								{
									NullReferenceException ex = new NullReferenceException();
								}
							}
							else
							{
								NullReferenceException ex = new NullReferenceException();
							}
						}
						else
						{
							NullReferenceException ex = new NullReferenceException();
						}
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
					}
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
				}
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
		}

		[Token(Token = "0x6000ACF")]
		[Address(RVA = "0x3EBED58", Offset = "0x3EBED58", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_undoVersion + 1;\n\tthis.m_undoVersion = v2;\n\tthis._lastSeenVersion = v2;\n\treturn;\n")]
		private void OnHistoryPushed(string label)
		{
			_lastSeenVersion = ++m_undoVersion;
		}

		[Token(Token = "0x6000AD0")]
		[Address(RVA = "0x3EBED68", Offset = "0x3EBED68", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this.GridHandler == 0;\n\tif (v15) goto L_000D;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::RebuildIndices(this.GridHandler);\nL_000D:\n\tv17 = this._visualCoordinator == 0;\n\tif (v17) goto L_001D;\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler::SyncAll(this._visualCoordinator, from);\n\treturn;\nL_001D:\n\treturn;\n")]
		private void OnHistoryRestored(EntityManager from)
		{
			if (GridHandler != null)
			{
				GridHandler.RebuildIndices();
			}
			if ((object)_visualCoordinator != null)
			{
				_visualCoordinator.SyncAll(from);
			}
		}

		[Token(Token = "0x6000AD1")]
		[Address(RVA = "0x3EBF0D8", Offset = "0x3EBF0D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnEnable()
		{
		}

		[Token(Token = "0x6000AD2")]
		[Address(RVA = "0x3EBF0DC", Offset = "0x3EBF0DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnDisable()
		{
		}

		[Token(Token = "0x6000AD3")]
		[Address(RVA = "0x3EBF0E0", Offset = "0x3EBF0E0", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv65 = new System.Action`1<System.String>();\n\tSystem.Action`1<System.String>::.ctor(v65, this, Il2CppMethodInfo);\n\tgoto L_0040;\nL_FFFFFFFF:\n\tv232 = 0;\nL_0055:\n\tv244 = System.Delegate::Remove(v235, v65);\n\tv245 = v244 == 0;\n\tif (v245) goto L_FFFFFFFF;\n\tv249 = 0x21C11D0(v244, System.Action`1<System.String>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv252 = v249 == 0;\n\tv253 = ~v252;\nL_FFFFFFFF:\n\tv232 = v249;\n\tif (v253) goto L_0046;\n\tthrow System.InvalidCastException;\nL_0063:\n\tv192 = this._history;\n\tv265 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v265, this, Il2CppMethodInfo);\n\tv188 = this._history == 0;\n\tif (v188) goto L_00A9;\n\tgoto L_0078;\nL_FFFFFFFF:\n\tv111 = 0;\nL_008D:\n\tv285 = System.Delegate::Remove(v132, v265);\n\tv286 = v285 == 0;\n\tif (v286) goto L_FFFFFFFF;\n\tv288 = 0x21C11D0(v285, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv291 = v288 == 0;\n\tv125 = ~v291;\nL_FFFFFFFF:\n\tv111 = v288;\n\tif (v125) goto L_007E;\n\tthrow System.InvalidCastException;\nL_00A8:\n\treturn;\nL_00A9:\n\tthrow v265;\nL_0023:\n\tv55 = this._history;\n\tv56 = this._history == 0;\n\tif (v56) goto L_00A8;\nL_0040:\n\tv209 = this._history + 0x40;\nL_FFFFFFFF:\n\tv235 = v55.HistoryPushed;\n\tgoto L_0055;\nL_0046:\n\tv238 = 0x220BDA0(v209, v232, v235, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv224 = v238 == v235;\nL_FFFFFFFF:\n\tv235 = v238;\n\tif (v224) goto L_0063;\nL_0078:\n\tv130 = this._history + 0x48;\nL_FFFFFFFF:\n\tv132 = v192.Restored;\n\tgoto L_008D;\nL_007E:\n\tv123 = 0x220BDA0(v130, v111, v132, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv93 = v123 == v132;\nL_FFFFFFFF:\n\tv132 = v123;\n\tif (v93) goto L_00A8;\n")]
		private void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcileTick_Editor::OnDestroy");
		}

		[Token(Token = "0x6000AD4")]
		[Address(RVA = "0x3EBF2C4", Offset = "0x3EBF2C4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this._history == 0;\n\tif (v12) goto L_004D;\n\tv19 = this.m_undoVersion < this._lastSeenVersion;\n\tv20 = this.m_undoVersion == this._lastSeenVersion;\n\tv113 = this.m_undoVersion - this._lastSeenVersion;\n\tif (v19) goto L_0029;\n\tif (v20) goto L_0047;\nL_001B:\n\tv112 = _game.CoreSystem.New.Shared.EditMode.EditorHistory::Redo(this._history);\n\tv114 = v113 - 1;\n\tv110 = v113 != 1;\n\tv113 = v114;\n\tif (v110) goto L_001B;\n\tgoto L_0047;\nL_0029:\n\tv148 = 0 - v113;\n\tv79 = v148 < 1;\n\tif (v79) goto L_0047;\nL_0039:\n\tv135 = _game.CoreSystem.New.Shared.EditMode.EditorHistory::Undo(this._history);\n\tv136 = v148 - 1;\n\tv134 = v148 != 1;\n\tv148 = v136;\n\tif (v134) goto L_0039;\nL_0047:\n\tthis._lastSeenVersion = this.m_undoVersion;\nL_004D:\n\treturn;\n")]
		private void HandleUndoRedo()
		{
			if (_history == null)
			{
				return;
			}
			bool flag = m_undoVersion < _lastSeenVersion;
			bool flag2 = m_undoVersion == _lastSeenVersion;
			int num = m_undoVersion - _lastSeenVersion;
			if (!flag)
			{
				if (!flag2)
				{
					bool flag4;
					do
					{
						bool flag3 = _history.Redo();
						int num2 = num - 1;
						flag4 = num != 1;
						num = num2;
					}
					while (flag4);
				}
			}
			else
			{
				int num3 = -num;
				if (num3 >= 1)
				{
					bool flag6;
					do
					{
						bool flag5 = _history.Undo();
						int num4 = num3 - 1;
						flag6 = num3 != 1;
						num3 = num4;
					}
					while (flag6);
				}
			}
			_lastSeenVersion = m_undoVersion;
		}

		[Token(Token = "0x6000AD5")]
		[Address(RVA = "0x3EBF604", Offset = "0x3EBF604", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TopGridReconcileTick_Editor()
		{
		}
	}
}
