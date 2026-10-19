using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.BaseLayerSystems.EntitySystem.Serialization;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.LevelData;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.LevelData;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Commands;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Responds;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.TopGridSystem.EditMode
{
	[Token(Token = "0x2000250")]
	public static class TopGridSaveConverter
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000251")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400071F")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000720")]
			public static Comparison<GridCoord> _003C_003E9__3_0;

			[Token(Token = "0x6000A31")]
			[Address(RVA = "0x3EAB5E8", Offset = "0x3EAB5E8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000A32")]
			[Address(RVA = "0x3EAB64C", Offset = "0x3EAB64C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal unsafe int _003CMergeEcsGroupBonds_003Eb__3_0(GridCoord a, GridCoord b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TopGridSaveConverter._003C_003Ec::_003CMergeEcsGroupBonds_003Eb__3_0");
				return default;
			}
		}

		[Token(Token = "0x6000A28")]
		[Address(RVA = "0x3EA8770", Offset = "0x3EA8770", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv65 = handler == 0;\nL_FFFFFFFF:\n\tv139 = previous;\n\tif (v65) goto L_00E4;\n\tv131 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(handler, &v125 @ stack_-70_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv134 = ~v131;\nL_FFFFFFFF:\n\tv139 = previous;\n\tif (v134) goto L_00E4;\n\tv225 = new _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>();\n\t_game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>::.ctor(v225);\n\t// 63 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv225.columns = v125;\n\tv225.cellSize = 0f;\n\tv232 = previous == 0;\n\tif (v232) goto L_FFFFFFFF;\n\tv120 = previous.cellHeight;\n\tgoto L_0049;\nL_FFFFFFFF:\n\tv120 = 0;\n\tv356 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::MergeEcsGroupBonds(v346, v353);\n\tv368 = v350 < 1;\n\tif (v368) goto L_FFFFFFFF;\n\tv380 = v125 < 1;\n\tif (v380) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv251 = 0;\nL_FFFFFFFF:\n\tv399 = v350;\nL_FFFFFFFF:\n\tv405 = v125;\n\tgoto L_0090;\nL_FFFFFFFF:\n\tv399 = v350;\nL_FFFFFFFF:\n\tv405 = v125;\nL_0090:\n\tv442 = v405 < 1;\n\tif (v442) goto L_007A;\nL_FFFFFFFF:\n\tv249 = 0;\n\tv493 = v280 == 0;\n\tif (v493) goto L_00C3;\n\tv340 = 0x21C11D0(v280, _game.CoreSystem.LevelCreator.SandCubeCellData, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv341 = v340 == 0;\n\tif (v341) goto L_00E7;\nL_00C3:\n\tv247[v491 @ X0_v28 (System.Int32)] = v280;\n\tv249 = v249 + 1;\n\tv447 = v249 < v125;\n\tif (v447) goto L_0097;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv139 = v225;\nL_00E7:\n\tv343 = new System.ArrayTypeMismatchException();\n\tthrow v343;\nL_0029:\n\tv61 = em == 0;\nL_FFFFFFFF:\n\tv139 = previous;\n\tif (v61) goto L_00E4;\nL_00E4:\n\treturn v139;\nL_0049:\n\tv225.cellHeight = v120;\n\tv225.padding = v332;\n\t_game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>::EnsureCellsArray(v225);\n\tv346 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::BuildBondsByCoord(previous, handler);\n\tv353 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::CollectEcsLinkGroups(em, handler, v350, v125);\nL_007A:\n\tv251 = v251 + 1;\n\tv390 = v251 >= v399;\n\tif (v390) goto L_FFFFFFFF;\nL_0097:\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v235 @ stack_-80_v10 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v251, v249);\n\tv247 = v225.cells;\n\tv491 = _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>::GetIndex(v225, v251, v249);\n\tv280 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::BuildCell(em, handler, v235, v356);\n")]
		public static GridData<SandCubeCellData> PullGridData(EntityManager em, TopGridHandler handler, GridData<SandCubeCellData> previous)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridSaveConverter::PullGridData");
			return default;
		}

		[Token(Token = "0x6000A29")]
		[Address(RVA = "0x3EA89C4", Offset = "0x3EA89C4", Length = "0x4D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tv67 = source.cells == 0;\n\tif (v67) goto L_FFFFFFFF;\n\treturnVal1 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::.ctor(returnVal1);\n\tv339 = source.rows < 1;\n\tif (v339) goto L_01B7;\n\tv397 = source.columns;\n\tv354 = source.columns < 1;\n\tif (v354) goto L_01B7;\nL_FFFFFFFF:\n\tv95 = 0;\nL_FFFFFFFF:\n\tv112 = 0;\n\tgoto L_0092;\nL_007B:\n\tv112 = v112 + 1;\n\tv373 = v112 >= source.rows;\n\tif (v373) goto L_01B7;\nL_0092:\n\tv541 = v397 < 1;\n\tif (v541) goto L_007B;\n\tv547 = handler == 0;\n\tif (v547) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv456 = 0;\n\tgoto L_00AA;\nL_0099:\n\tv456 = v456 + 1;\n\tv397 = source.columns;\n\tv570 = v456 >= source.columns;\n\tif (v570) goto L_007B;\nL_00AA:\n\tv628 = _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>::GetCell(source, v456, v112);\n\tv639 = v628 == 0;\n\tif (v639) goto L_0099;\n\tv645 = v628.components == 0;\n\tif (v645) goto L_0099;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v95 @ stack_-70_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v456, v112);\n\tv701 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(handler, v95);\n\tv439 = v701;\n\tgoto L_00C7;\nL_00C7:\n\tv677 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v439 @ stack_-78_v8 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv680 = ~v677;\n\tif (v680) goto L_0099;\n\tgoto L_00D1;\nL_00D1:\n\tv679 = v628.components;\nL_FFFFFFFF:\n\tv438 = 0;\n\tgoto L_00E8;\nL_00D9:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v813, v422);\nL_00DA:\n\tv438 = v438 + 1;\n\tv679 = v628.components;\nL_00E8:\n\tv657 = v438 >= v679.Count;\n\tif (v657) goto L_0099;\n\tv725 = System.Collections.Generic.List`1<_game.CoreSystem.LevelCreator.ICellComponent>::get_Item(v679, v438);\n\tv726 = v725 == 0;\n\tif (v726) goto L_00DA;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v463_asT @ TEMPCOND_v18 (_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent), typeof(_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent), v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)\n\tv463 = v463_asT == 0;\n\tif (v463) goto L_00DA;\n\tv775 = *([v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+10]) & 0x80000000;\n\tv776 = v775 == 0;\n\tv762 = ~v776;\n\tif (v762) goto L_00DA;\n\tv777 = *([v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+14]) & 0x80000000;\n\tv778 = v777 == 0;\n\tv763 = ~v778;\n\tif (v763) goto L_00DA;\n\tv757 = _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>::IsValidCell(source, *([v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+10]), *([v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+14]));\n\tv764 = ~v757;\n\tif (v764) goto L_00DA;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v422 @ stack_-88_v9 (_game.CoreSystem.New.GridEcsBinding.GridCoord), *([v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+10]), *([v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+14]));\n\tv789 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(handler, v422);\n\tv439 = v789;\n\tgoto L_0136;\nL_0136:\n\tv758 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v439 @ stack_-78_v8 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv765 = ~v758;\n\tif (v765) goto L_00DA;\n\tgoto L_0149;\nL_0149:\n\tv806 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(returnVal1, v95, &v805 @ stack_-90_v9 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv808 = v806 == 0;\n\tv809 = ~v808;\n\tif (v809) goto L_0168;\n\tv813 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v813);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::set_Item(returnVal1, v95, v813);\nL_FFFFFFFF:\n\tv805 = v813;\nL_0168:\n\tv760 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v813, v422);\n\tv829 = v760 == 0;\n\tv767 = ~v829;\n\tif (v767) goto L_00DA;\n\tgoto L_00D9;\nL_FFFFFFFF:\n\tv103 = 0;\n\tgoto L_01A2;\nL_0191:\n\tv103 = v103 + 1;\n\tv397 = source.columns;\n\tv571 = v103 >= source.columns;\n\tif (v571) goto L_007B;\nL_01A2:\n\tv599 = _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.SandCubeCellData>::GetCell(source, v103, v112);\n\tv640 = v599 == 0;\n\tif (v640) goto L_0191;\n\tv148 = v599.components == 0;\n\tif (v148) goto L_0191;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v95 @ stack_-70_v6 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v103, v112);\n\tthrow System.NullReferenceException;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_01D4;\nL_01B7:\n\tv408 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Count(returnVal1);\n\tv163 = v408 != 0;\n\tif (v163) goto L_01D4;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_01D4;\nL_004B:\n\tv62 = source == 0;\n\tif (v62) goto L_FFFFFFFF;\nL_01D4:\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Dictionary<GridCoord, List<GridCoord>> BuildBondsByCoord(GridData<SandCubeCellData> source, TopGridHandler handler)
		{
			//IL_02e1: Expected I4, but got I8
			//IL_0324: Expected I4, but got I8
			Dictionary<GridCoord, List<GridCoord>> dictionary;
			if (source != null && source.cells != null)
			{
				dictionary = new Dictionary<GridCoord, List<GridCoord>>();
				if (source.rows >= 1)
				{
					int columns = source.columns;
					if (source.columns >= 1)
					{
						GridCoord gridCoord = default(GridCoord);
						int num = 0;
						List<GridCoord> list = default(List<GridCoord>);
						do
						{
							if (columns >= 1)
							{
								if (handler != null)
								{
									int num2 = 0;
									do
									{
										SandCubeCellData cell = source.GetCell(num2, num);
										if (cell != null && cell.components != null)
										{
											gridCoord = new GridCoord(num2, num);
											Entity sandCubeAt = handler.GetSandCubeAt(gridCoord);
											Entity entity = sandCubeAt;
											if (entity.IsValid)
											{
												List<ICellComponent> components = cell.components;
												int num3 = 0;
												while (num3 < components.Count)
												{
													ICellComponent cellComponent = components[num3];
													if (cellComponent != null && cellComponent is LinkedSandCubeComponent)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+10]");
														if (0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+14]");
															if (0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+10]");
																nint num4 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+14]");
																if (source.IsValidCell((int)num4, 0))
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+10]");
																	nint num5 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ X0_v30 (_game.CoreSystem.LevelCreator.ICellComponent)+14]");
																	GridCoord gridCoord2 = new GridCoord((int)num5, 0);
																	Entity sandCubeAt2 = handler.GetSandCubeAt(gridCoord2);
																	entity = sandCubeAt2;
																	if (entity.IsValid)
																	{
																		if (!dictionary.TryGetValue(gridCoord, out var value))
																		{
																			list = (dictionary[gridCoord] = new List<GridCoord>());
																			value = list;
																		}
																		if (!list.Contains(gridCoord2))
																		{
																			list.Add(gridCoord2);
																		}
																	}
																}
															}
														}
													}
													num3++;
													components = cell.components;
												}
											}
										}
										num2++;
										columns = source.columns;
									}
									while (num2 < source.columns);
								}
								else
								{
									int num6 = 0;
									do
									{
										SandCubeCellData cell2 = source.GetCell(num6, num);
										if (cell2 == null || cell2.components == null)
										{
											num6++;
											columns = source.columns;
											continue;
										}
										gridCoord = new GridCoord(num6, num);
										throw new NullReferenceException();
									}
									while (num6 < source.columns);
								}
							}
							num++;
						}
						while (num < source.rows);
					}
				}
				if (dictionary.Count == 0)
				{
					dictionary = null;
				}
			}
			else
			{
				dictionary = null;
			}
			return dictionary;
		}

		[Token(Token = "0x6000A2A")]
		[Address(RVA = "0x3EA8E9C", Offset = "0x3EA8E9C", Length = "0x3B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv89 = columns < 1;\n\tif (v89) goto L_FFFFFFFF;\n\tv139 = handler == 0;\n\tif (v139) goto L_0168;\n\tv229 = em == 0;\n\tif (v229) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv393 = 0;\nL_FFFFFFFF:\n\tv611 = 0;\n\tgoto L_FFFFFFFF;\nL_0064:\n\tv393 = v339 + 1;\n\tv195 = v393 == rows;\nL_FFFFFFFF:\n\tv182 = v611;\n\tif (v195) goto L_0163;\nL_FFFFFFFF:\n\tv335 = 0;\nL_FFFFFFFF:\n\tv339 = v393;\n\tgoto L_008A;\nL_008A:\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v60 @ stack_-70_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v335, v339);\n\tv501 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(handler, v60);\n\tgoto L_009A;\nL_009A:\n\tv518 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v91 @ stack_-78_v7 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv523 = ~v518;\n\tif (v523) goto L_007A;\n\tgoto L_00A8;\nL_00A8:\n\tv551 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::TryGetComponent(em, v91, &v323 @ stack_-7C_v7 (_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data.LinkedCubeGroupComponent));\n\tv570 = v551 == 0;\n\tv575 = ~v570;\n\tv322 = ~v575;\n\tif (v322) goto L_FFFFFFFF;\n\tv578 = v323 - 1;\n\tv356 = v578 < 0;\n\tv581 = v323 ^ 1;\n\tv582 = v323 ^ v578;\n\tv583 = v581 & v582;\n\tv346 = v583 < 0;\n\tgoto L_00C5;\nL_FFFFFFFF:\n\tv346 = 0;\nL_FFFFFFFF:\n\tv356 = 1;\n\tv590 = v611 == 0;\n\tif (v590) goto L_010A;\n\tv595 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(v611, v323, &v593 @ stack_-88_v11 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv600 = v595 == 0;\n\tv601 = ~v600;\nL_FFFFFFFF:\n\tv342 = v611;\n\tif (v601) goto L_00F0;\nL_00D7:\n\tv622 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v622);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::set_Item(v611, v323, v622);\nL_FFFFFFFF:\n\tv593 = v622;\nL_FFFFFFFF:\n\tv339 = v393;\nL_FFFFFFFF:\n\tv342 = v611;\nL_00F0:\n\t;\n\tgoto L_0105;\nL_0105:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v622, v60);\nL_FFFFFFFF:\n\tv611 = v342;\n\tgoto L_007A;\nL_010A:\n\tv364 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::.ctor(v364);\n\tv613 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(v364, v323, &v593 @ stack_-88_v11 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv615 = v613 == 0;\nL_FFFFFFFF:\n\tv611 = v364;\n\tif (v615) goto L_00D7;\nL_FFFFFFFF:\n\tv342 = v364;\n\tgoto L_00F0;\nL_FFFFFFFF:\n\tv338 = 0;\nL_0135:\n\tv128 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v91 @ stack_-78_v7 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv341 = v341 + 1;\n\tv476 = columns != v341;\n\tif (v476) goto L_0123;\n\tv338 = v338 + 1;\n\tv110 = v338 != rows;\n\tif (v110) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv182 = 0;\nL_0168:\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v60 @ stack_-70_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord), 0, 0);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0037:\n\tv60 = 0;\n\tv74 = rows < 1;\n\tif (v74) goto L_FFFFFFFF;\nL_0163:\n\treturn v182;\nL_007A:\n\tv335 = v335 + 1;\n\tv454 = columns == v335;\n\tif (v454) goto L_0064;\nL_00C5:\n\tv589 = v356 == v346;\n\tv344 = ~v589;\n\tif (v344) goto L_007A;\nL_0123:\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v60 @ stack_-70_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v341, v338);\n\tv505 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(handler, v60);\n\tv91 = v505;\n\tgoto L_0135;\nL_FFFFFFFF:\n\tv341 = 0;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Dictionary<int, List<GridCoord>> CollectEcsLinkGroups(EntityManager em, TopGridHandler handler, int columns, int rows)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridSaveConverter::CollectEcsLinkGroups");
			return default;
		}

		[Token(Token = "0x6000A2B")]
		[Address(RVA = "0x3EA924C", Offset = "0x3EA924C", Length = "0xBCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006D;\n\tv79 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Count(groups);\n\tv251 = v79 == 0;\nL_FFFFFFFF:\n\tv256 = existing;\n\tif (v251) goto L_03CD;\n\tv425 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Keys(groups);\n\tv433 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v433, v425);\n\tv445 = v433 == 0;\n\tif (v445) goto L_0378;\n\tSystem.Collections.Generic.List`1<System.Int32>::Sort(v433);\n\tv462 = System.Collections.Generic.List`1<System.Int32>::GetEnumerator(v433);\n\tv240 = v240._list;\n\tv570 = v240._list;\nL_FFFFFFFF:\n\tv500 = 0;\nL_FFFFFFFF:\n\tv945 = existing;\n\tv980 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::get_Item(groups, v240.Current);\n\tv959 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v959, v980);\n\tv925 = v959 == 0;\n\tif (v925) goto L_0376;\n\tv538 = v959.Count < 2;\n\tif (v538) goto L_00B7;\n\tgoto L_00E2;\nL_00E2:\n\tv1083 = v1059.<>9__3_0;\n\tv1061 = v1059.<>9__3_0 == 0;\n\tv1062 = ~v1061;\n\tif (v1062) goto L_0112;\n\tgoto L_00F3;\nL_00F3:\n\tgoto L_00FD;\nL_0112:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Sort(v959, v1083);\n\tv1105 = new System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v1105, v959);\n\tv1133 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v1133, v959.Count);\n\tv1152 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v959);\n\tv524 = v240;\n\tv240 = 0;\n\tv1158 = v1133 == 0;\n\tif (v1158) goto L_0152;\nL_0142:\n\tv1179 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::MoveNext(&v524 @ stack_-B0_v8 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1174 = v1179 == 0;\n\tif (v1174) goto L_015B;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::set_Item(v1133, v240.Current, v240.Current);\nL_FFFFFFFF:\n\t;\n\tgoto L_0142;\nL_0152:\n\tv1181 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::MoveNext(&v524 @ stack_-B0_v8 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1183 = ~v1181;\n\tv924 = ~v1183;\n\tif (v924) goto L_0307;\n\tgoto L_016D;\nL_FFFFFFFF:\n\tv212 = &v570 @ stack_-90_v7 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>);\nL_FFFFFFFF:\n\tv216 = 0;\nL_FFFFFFFF:\n\tv256 = v945;\n\tgoto L_03BA;\nL_016D:\n\tv1196 = v945 == 0;\nL_FFFFFFFF:\n\tv1335 = v945;\n\tif (v1196) goto L_0243;\n\tv1202 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v959);\n\tv881 = v240._list;\n\tv524 = 0;\n\tv1258 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(v945, v524.Current, &v763 @ stack_-B8_v11 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1261 = v1258 == 0;\n\tif (v1261) goto L_0186;\n\tv923 = v763 == 0;\n\tif (v923) goto L_0305;\n\tv1421 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v763);\n\tv759 = v1421;\n\tv1430 = v1105 == 0;\n\tif (v1430) goto L_01EF;\nL_01B2:\n\tv1463 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::MoveNext(&v759 @ stack_-E0_v11 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1507 = v1463 == 0;\n\tif (v1507) goto L_01F9;\n\tv1451 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v1105, v1421.Current);\n\tv1455 = v1451 == 0;\n\tif (v1455) goto L_01B2;\n\tgoto L_01CF;\n\tv1601 = v1452 == 0;\n\tv1456 = ~v1601;\n\tif (v1456) goto L_01B2;\n\tv919 = v1133 == 0;\n\tif (v919) goto L_020B;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::set_Item(v1133, v750, v1585);\nL_FFFFFFFF:\n\t;\n\tgoto L_01B2;\nL_01EF:\n\tv1465 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::MoveNext(&v759 @ stack_-E0_v11 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1508 = ~v1465;\n\tv920 = ~v1508;\n\tif (v920) goto L_020D;\nL_FFFFFFFF:\n\tv881 = 0;\n\tgoto L_0186;\nL_FFFFFFFF:\n\tv881 = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv881 = 0;\nL_FFFFFFFF:\n\tv936 = 0xB;\nL_FFFFFFFF:\n\tv1335 = v945;\n\tgoto L_022C;\nL_020B:\n\tv909 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv724 = v945;\nL_FFFFFFFF:\n\tv212 = &v570 @ stack_-90_v7 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>);\nL_FFFFFFFF:\n\tv216 = 0;\nL_FFFFFFFF:\n\tv240 = 0;\nL_FFFFFFFF:\n\tv898 = v1585;\nL_FFFFFFFF:\n\tv907 = v909;\n\tgoto L_037F;\nL_020D:\n\tv910 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv724 = v945;\nL_FFFFFFFF:\n\tv212 = &v570 @ stack_-90_v7 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>);\nL_FFFFFFFF:\n\tv216 = 0;\nL_FFFFFFFF:\n\tv240 = 0;\nL_FFFFFFFF:\n\tv898 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv907 = v910;\n\tgoto L_037F;\nL_FFFFFFFF:\n\tv936 = 0xA;\nL_FFFFFFFF:\n\tv1335 = v945;\n\tv996 = v936 == 0xA;\n\tif (v996) goto L_0243;\n\tv1431 = v936 == 0;\n\tv1013 = ~v1431;\nL_FFFFFFFF:\n\tv212 = &v570 @ stack_-90_v7 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>);\nL_FFFFFFFF:\n\tv216 = 0;\nL_FFFFFFFF:\n\tv256 = v1335;\n\tif (v1013) goto L_03BA;\nL_0243:\n\tv1227 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v959);\n\tv524 = v1227;\n\tv1242 = v1105 == 0;\n\tif (v1242) goto L_02F3;\nL_FFFFFFFF:\n\tv1332 = v1335;\n\tv1319 = v1227.Current;\n\tv1412 = v1227.Current + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v500 @ stack_-F0_v7 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v1412, v1319.y);\n\tv1427 = System.Collections.Generic.HashSet`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v1105, v500);\n\tv1433 = v1427 == 0;\n\tif (v1433) goto L_02A9;\n\tv1472 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::FindBond(v1133, v1227.Current);\n\tv1480 = v1472;\n\tv1513 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::FindBond(v1133, v500);\n\tv1495 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v1480 @ stack_-110_v13 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v1513);\n\tv1532 = v1495 == 0;\n\tv1497 = ~v1532;\n\tif (v1497) goto L_02A9;\n\tv1555 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::AddSymmetricBond(v1335, v1227.Current, v500);\n\t_game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::UnionBond(v1133, v1227.Current, v500);\nL_FFFFFFFF:\n\tv1335 = v1555;\n\tv1538 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::FindBond(v1133, v1227.Current);\n\tv1480 = v1538;\n\tv1560 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::FindBond(v1133, v1275);\n\tv1377 = _game.CoreSystem.New.GridEcsBinding.G\n// ... truncated")]
		public unsafe static Dictionary<GridCoord, List<GridCoord>> MergeEcsGroupBonds(Dictionary<GridCoord, List<GridCoord>> existing, Dictionary<int, List<GridCoord>> groups)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridSaveConverter::MergeEcsGroupBonds");
			return default;
		}

		[Token(Token = "0x6000A2C")]
		[Address(RVA = "0x3EAB1D4", Offset = "0x3EAB1D4", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv69 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::.ctor(v69);\n\tv77 = v69;\nL_004D:\n\tv88 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(v77, a, &v84 @ stack_-68_v3 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv94 = v88 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_006D;\n\tv102 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v102);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::set_Item(v77, a, v102);\nL_006D:\n\tv204 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v102, b);\n\tv210 = v204 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_009D;\n\tgoto L_0097;\nL_0097:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v102, b);\nL_009D:\n\tv305 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(v77, b, &v301 @ stack_-70_v3 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv313 = v305 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_00BA;\n\tv319 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v319);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::set_Item(v77, b, v319);\nL_00BA:\n\tv334 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Contains(v319, a);\n\tv337 = v334 == 0;\n\tv338 = ~v337;\n\tif (v338) goto L_00F3;\n\tgoto L_00E4;\nL_00E4:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v319, a);\nL_00F3:\n\treturn v77;\nL_0037:\n\tv61 = bonds == 0;\n\tv62 = ~v61;\n\tv77 = bonds;\n\tif (v62) goto L_004D;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Dictionary<GridCoord, List<GridCoord>> AddSymmetricBond(Dictionary<GridCoord, List<GridCoord>> bonds, GridCoord a, GridCoord b)
		{
			bool flag = bonds == null;
			bool flag2 = !flag;
			Dictionary<GridCoord, List<GridCoord>> dictionary = bonds;
			if (!flag2)
			{
				Dictionary<GridCoord, List<GridCoord>> dictionary2 = new Dictionary<GridCoord, List<GridCoord>>();
				dictionary = dictionary2;
			}
			List<GridCoord> list = default(List<GridCoord>);
			if (!dictionary.TryGetValue(a, out var _))
			{
				list = (dictionary[a] = new List<GridCoord>());
			}
			if (!list.Contains(b))
			{
				list.Add(b);
			}
			List<GridCoord> list3 = default(List<GridCoord>);
			if (!dictionary.TryGetValue(b, out var _))
			{
				list3 = (dictionary[b] = new List<GridCoord>());
			}
			if (!list3.Contains(a))
			{
				list3.Add(a);
			}
			return dictionary;
		}

		[Token(Token = "0x6000A2D")]
		[Address(RVA = "0x3EAB07C", Offset = "0x3EAB07C", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv59 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, c);\n\tv61 = v59;\n\tv67 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v61 @ stack_-50_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord), c);\n\tv69 = v67 == 0;\n\tv70 = ~v69;\n\tv120 = c;\n\tif (v70) goto L_0066;\n\tv133 = c;\n\tv155 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v133);\n\tv160 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v155);\n\tv61 = v160;\n\tv118 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v61 @ stack_-50_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v155);\n\tv119 = v118 == 0;\n\tv120 = v155;\n\tv133 = v155;\n\tif (v119) goto L_0037;\nL_0066:\n\treturn v120;\nL_0037:\n\tv140 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v133);\n\tv146 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(parent, v140);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::set_Item(parent, v133, v146);\n")]
		private static GridCoord FindBond(Dictionary<GridCoord, GridCoord> parent, GridCoord c)
		{
			GridCoord gridCoord = parent[c];
			GridCoord gridCoord2 = gridCoord;
			bool flag = gridCoord2.Equals(c);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			GridCoord result = c;
			if (!flag3)
			{
				GridCoord key = c;
				bool flag5;
				do
				{
					GridCoord key2 = parent[key];
					GridCoord value = parent[key2];
					parent[key] = value;
					GridCoord gridCoord3 = parent[key];
					GridCoord gridCoord4 = parent[gridCoord3];
					gridCoord2 = gridCoord4;
					bool flag4 = gridCoord2.Equals(gridCoord3);
					flag5 = !flag4;
					result = gridCoord3;
					key = gridCoord3;
				}
				while (flag5);
			}
			return result;
		}

		[Token(Token = "0x6000A2E")]
		[Address(RVA = "0x3EAAFA4", Offset = "0x3EAAFA4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv71 = v69 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0045;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.GridEcsBinding.GridCoord>::set_Item(parent, v65, v61);\nL_0045:\n\treturn;\nL_001F:\n\tv55 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::FindBond(parent, v47);\n\tv61 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSaveConverter::FindBond(parent, b);\n\tv69 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v65 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v61);\n")]
		private static void UnionBond(Dictionary<GridCoord, GridCoord> parent, GridCoord a, GridCoord b)
		{
			GridCoord c = default(GridCoord);
			GridCoord gridCoord = FindBond(parent, c);
			GridCoord gridCoord2 = FindBond(parent, b);
			GridCoord key = default(GridCoord);
			if (!key.Equals(gridCoord2))
			{
				parent[key] = gridCoord2;
			}
		}

		[Token(Token = "0x6000A2F")]
		[Address(RVA = "0x3EA9E18", Offset = "0x3EA9E18", Length = "0x118C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00AE;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.LevelCreator.ICellComponent>::.ctor(v98);\n\tv112 = v88 + 0x18;\n\tv88.components = v98;\n\tv860 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetSandCubeAt(handler, coord);\n\tgoto L_00D0;\nL_00D0:\n\tv884 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v882 @ stack_-70_v8 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv894 = ~v884;\n\tv895 = ~v894;\n\tif (v895) goto L_00E5;\nL_FFFFFFFF:\n\tv709 = v88;\nL_FFFFFFFF:\n\tv724 = handler;\n\tgoto L_0237;\nL_00E5:\n\tv950 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::TryGetComponent(em, v882, &v450 @ stack_-F4_v5 (_game.CoreSystem.New.Shared.Components.ColorComponent));\n\tv621 = *([v112 @ X0_v17]);\n\tv526 = new _game.CoreSystem.SandSystem.Components.GameColorComponent();\n\t_game.CoreSystem.SandSystem.Components.GameColorComponent::.ctor(v526);\n\tv371 = v950 == 0;\n\tv280 = ~v371;\n\tv276 = ~v280;\n\tif (v276) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv708 = v450;\n\tgoto L_0103;\nL_FFFFFFFF:\n\tv708 = 0;\n\tv1123 = *([v621 @ X20_v42+1C]) + 1;\n\t*([v621 @ X20_v42+1C]) = v1123;\n\tv248 = *([v621 @ X20_v42+10]);\n\tv1134 = *([v621 @ X20_v42+18]) < *([v248 @ X9_v40+18]);\n\tv432 = ~v1134;\n\tif (v432) goto L_012A;\n\tv1143 = *([v621 @ X20_v42+18]) + 1;\n\t*([v621 @ X20_v42+18]) = v1143;\n\tv1144 = *([v621 @ X20_v42+18]) << 3;\n\tv1145 = v248 + v1144;\n\tv1146 = v1145 + 0x20;\n\t*([v1146 @ X0_v251]) = v526;\n\tgoto L_012C;\nL_012A:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v621, v526);\nL_012C:\n\tv622 = *([v112 @ X0_v17]);\n\tv527 = new _game.CoreSystem.SandSystem.Components.SandCubeTagComponent();\n\t_game.CoreSystem.SandSystem.Components.SandCubeTagComponent::.ctor(v527);\n\tv1222 = *([v622 @ X20_v43+1C]) + 1;\n\t*([v622 @ X20_v43+1C]) = v1222;\n\tv249 = *([v622 @ X20_v43+10]);\n\tv1234 = *([v622 @ X20_v43+18]) < *([v249 @ X9_v43+18]);\n\tv433 = ~v1234;\n\tif (v433) goto L_0157;\n\tv1275 = *([v622 @ X20_v43+18]) + 1;\n\t*([v622 @ X20_v43+18]) = v1275;\n\tv1276 = *([v622 @ X20_v43+18]) << 3;\n\tv1277 = v249 + v1276;\n\tv1278 = v1277 + 0x20;\n\t*([v1278 @ X0_v247]) = v527;\n\tgoto L_015D;\nL_0157:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v622, v527);\nL_015D:\n\tv1312 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v882);\n\tv1366 = ~v1312;\nL_FFFFFFFF:\n\tv1446 = v527;\n\tif (v1366) goto L_0186;\n\tv623 = *([v112 @ X0_v17]);\n\tv528 = new _game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent();\n\t_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent::.ctor(v528);\n\tv1507 = *([v623 @ X20_v50+1C]) + 1;\n\t*([v623 @ X20_v50+1C]) = v1507;\n\tv250 = *([v623 @ X20_v50+10]);\n\tv1530 = *([v623 @ X20_v50+18]) < *([v250 @ X9_v56+18]);\n\tv1408 = ~v1530;\n\tif (v1408) goto L_01F1;\n\tv1417 = *([v623 @ X20_v50+18]) + 1;\n\t*([v623 @ X20_v50+18]) = v1417;\n\tv1387 = *([v623 @ X20_v50+18]) << 3;\n\tv1583 = v250 + v1387;\n\tv1584 = v1583 + 0x20;\n\t*([v1584 @ X0_v243]) = v528;\nL_FFFFFFFF:\n\tv1446 = v528;\nL_0186:\n\tv1418 = bondsByCoord == 0;\nL_FFFFFFFF:\n\t;\n\tif (v1418) goto L_01FB;\nL_018F:\n\tv529 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>::TryGetValue(bondsByCoord, coord, &v182 @ stack_-100_v6 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1443 = ~v529;\nL_FFFFFFFF:\n\t;\n\tif (v1443) goto L_01FB;\nL_FFFFFFFF:\n\tv1595 = v182;\nL_FFFFFFFF:\n\tv749 = 0;\n\tgoto L_01AF;\nL_01A0:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v1446, v1608);\n\tv749 = v749 + 1;\nL_FFFFFFFF:\n\tv1595 = v182;\nL_01AF:\n\tv281 = v749 >= v1595.Count;\n\tif (v281) goto L_01FB;\n\tv1446 = *([v112 @ X0_v17]);\n\tv1608 = new _game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent();\n\t_game.CoreSystem.SandSystem.Components.LinkedSandCubeComponent::.ctor(v1608);\n\tv532 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(v182, v749);\n\tv1608.linkedCol = v532;\n\tv534 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(v182, v749);\n\tv1608.linkedRow = v534.y;\n\tv1798 = *([v1446 @ X22_v27 (_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent)+1C]) + 1;\n\t*([v1446 @ X22_v27 (_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent)+1C]) = v1798;\n\tv252 = *([v1446 @ X22_v27 (_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent)+10]);\n\tv1808 = *([v1446 @ X22_v27 (_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent)+18]) < *([v252 @ X9_v52+18]);\n\tv435 = ~v1808;\n\tif (v435) goto L_01A0;\n\tv1821 = *([v1446 @ X22_v27 (_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent)+18]) + 1;\n\t*([v1446 @ X22_v27 (_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent)+18]) = v1821;\n\tv195 = *([v1446 @ X22_v27 (_game.CoreSystem.SandSystem.Components.HiddenColorCubeComponent)+18]) << 3;\n\tv1822 = v252 + v195;\n\tv1823 = v1822 + 0x20;\n\t*([v1823 @ X0_v235]) = v1608;\n\tv749 = v749 + 1;\n\tv1859 = v182 == 0;\n\tv572 = ~v1859;\nL_FFFFFFFF:\n\tv1595 = v182;\n\tif (v572) goto L_01AF;\n\tgoto L_05BE;\nL_01F1:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v623, v528);\n\tv1606 = bondsByCoord == 0;\n\tv1431 = ~v1606;\nL_FFFFFFFF:\n\tv1446 = v528;\n\tif (v1431) goto L_018F;\nL_01FB:\n\tv928 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::TryGetComponent(em, v882, &v179 @ stack_-110_v5 (_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data.SnakeSegmentComponent));\n\tv931 = ~v928;\nL_FFFFFFFF:\n\tv709 = v88;\nL_FFFFFFFF:\n\tv724 = handler;\n\tif (v931) goto L_0237;\n\tv626 = *([v112 @ X0_v17]);\n\tv536 = new _game.CoreSystem.SandSystem.Components.SnakeSegmentComponent();\n\t_game.CoreSystem.SandSystem.Components.SnakeSegmentComponent::.ctor(v536);\n\tv536.snakeId = v179;\n\tv536.nextRow = 0;\n\tv1659 = *([v626 @ X20_v45+1C]) + 1;\n\t*([v626 @ X20_v45+1C]) = v1659;\n\tv255 = *([v626 @ X20_v45+10]);\n\tv1675 = *([v626 @ X20_v45+18]) < *([v255 @ X9_v47+18]);\n\tv919 = ~v1675;\n\tif (v919) goto L_0231;\n\tv940 = *([v626 @ X20_v45+18]) + 1;\n\t*([v626 @ X20_v45+18]) = v940;\n\tv909 = *([v626 @ X20_v45+18]) << 3;\n\tv1690 = v255 + v909;\n\tv1691 = v1690 + 0x20;\n\t*([v1691 @ X0_v222]) = v536;\nL_FFFFFFFF:\n\tv709 = v88;\nL_FFFFFFFF:\n\tv724 = handler;\n\tgoto L_0237;\nL_0231:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v626, v536);\nL_FFFFFFFF:\n\tv709 = v88;\nL_FFFFFFFF:\n\tv724 = handler;\nL_0237:\n\tv945 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetWallAt(v724, coord);\n\tv169 = v945;\n\tv617 = 0xB28D000 + 0xDC0;\n\tgoto L_0241;\nL_0241:\n\tv1051 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v169 @ stack_-78_v4 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv1056 = ~v1051;\n\tv1057 = ~v1056;\n\tif (v1057) goto L_024D;\n\tgoto L_027F;\nL_024D:\n\tv627 = *([v112 @ X0_v17]);\n\tv537 = new _game.CoreSystem.SandSystem.Components.WallComponent();\n\t_game.CoreSystem.SandSystem.Components.WallComponent::.ctor(v537);\n\tv1120 = *([v627 @ X20_v41+1C]) + 1;\n\t*([v627 @ X20_v41+1C]) = v1120;\n\tv257 = *([v627 @ X20_v41+10]);\n\tv1133 = *([v627 @ X20_v41+18]) < *([v257 @ X9_v37+18]);\n\tv1085 = ~v1133;\n\tif (v1085) goto L_027A;\n\tv1097 = *([v627 @ X20_v41+18]) + 1;\n\t*([v627 @ X20_v41+18]) = v1097;\n\tv1075 = *([v627 @ X20_v41+18]) << 3;\n\tv1140 = v257 + v1075;\n\tv1141 = v1140 + 0x20;\n\t*([v1141 @ X0_v197]) = v537;\n\tgoto L_027F;\nL_027A:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v627, v537);\nL_027F:\n\tv1100 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetTunnelAt(v724, coord);\n\tgoto L_0287;\nL_0287:\n\tv1115 = _game.BaseLayerSystems.EntitySystem.Core.Entity::get_IsValid(&v1113 @ stack_-80_v8 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv1127 = ~v1115;\n\tv1128 = ~v1127;\n\tif (v1128) goto L_029A;\nL_FFFFFFFF:\n\tv719 = em;\nL_FFFFFFFF:\n\tv732 = coord;\n\tgoto L_03CE;\nL_029A:\n\tv1177 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::TryGetComponent(em, v1113, &v164 @ stack_-84_v5 (_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.TunnelQueueComponent));\n\tv1180 = ~v1177;\nL_FFFFFFFF:\n\tv719 = em;\nL_FFFFFFFF:\n\tv732 = coord;\n\tif (v1180) \n// ... truncated")]
		private static SandCubeCellData BuildCell(EntityManager em, TopGridHandler handler, GridCoord coord, Dictionary<GridCoord, List<GridCoord>> bondsByCoord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridSaveConverter::BuildCell");
			return default;
		}

		[Token(Token = "0x6000A30")]
		[Address(RVA = "0x3EAB4C4", Offset = "0x3EAB4C4", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv64 = *([component @ X0 (_game.BaseLayerSystems.EntitySystem.IEntityData)]) - _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data.InTunnelQueueComponent;\n\tv66 = v64 == 0;\n\tv71 = ~v66;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\n\tv83 = *([component @ X0 (_game.BaseLayerSystems.EntitySystem.IEntityData)]) - _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags.SandRevealTag;\n\tv168 = v83 == 0;\n\tgoto L_0054;\nL_FFFFFFFF:\n\tv168 = 1;\n\tv179 = *([component @ X0 (_game.BaseLayerSystems.EntitySystem.IEntityData)]) - _game.CoreSystem.New.Shared.Components.Tags.InitPendingTag;\n\tv197 = v179 == 0;\n\tgoto L_0066;\nL_FFFFFFFF:\n\tv197 = 1;\n\tv207 = *([component @ X0 (_game.BaseLayerSystems.EntitySystem.IEntityData)]) - _game.CoreSystem.New.Shared.Components.Tags.MaterialPendingTag;\n\tv222 = v207 == 0;\n\tgoto L_0078;\nL_FFFFFFFF:\n\tv222 = 1;\n\tv230 = *([component @ X0 (_game.BaseLayerSystems.EntitySystem.IEntityData)]) - _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Commands.Cmd_PinDisappear;\n\tv245 = v230 == 0;\n\tgoto L_008A;\nL_FFFFFFFF:\n\tv245 = 1;\n\tv252 = *([component @ X0 (_game.BaseLayerSystems.EntitySystem.IEntityData)]) - _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Responds.Resp_PinDisappeared;\n\tv120 = v252 == 0;\n\tgoto L_009C;\nL_FFFFFFFF:\n\tv120 = 1;\n\treturn 1;\nL_00AB:\n\treturn 0;\nL_00B1:\n\tv130 = *([component @ X0 (_game.BaseLayerSystems.EntitySystem.IEntityData)]) - _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags.BlockedByPinTag;\n\tv122 = v130 == 0;\n\treturn v122;\nL_0024:\n\tv39 = component == 0;\n\tif (v39) goto L_00AB;\nL_0054:\n\tv172 = ~v168;\n\tv173 = ~v172;\n\tif (v173) goto L_FFFFFFFF;\nL_0066:\n\tv201 = ~v197;\n\tv202 = ~v201;\n\tif (v202) goto L_FFFFFFFF;\nL_0078:\n\tv226 = ~v222;\n\tv227 = ~v226;\n\tif (v227) goto L_FFFFFFFF;\nL_008A:\n\tv249 = ~v245;\n\tv98 = ~v249;\n\tif (v98) goto L_FFFFFFFF;\nL_009C:\n\tv101 = ~v120;\n\tif (v101) goto L_00B1;\n")]
		private static bool IsRuntimeOnlyComponent(IEntityData component)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridSaveConverter::IsRuntimeOnlyComponent");
			return default;
		}
	}
}
