using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.Shared.EditMode.Brushes;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.ECS.IdentifierTags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode
{
	[GridBrush("topgrid", 71)]
	[Token(Token = "0x20001C8")]
	public sealed class NoPlaceWallBrush : IGridBrush
	{
		[CompilerGenerated]
		[Token(Token = "0x20001C9")]
		private sealed class _003CGetFootprint_003Ed__4 : IEnumerable<GridCoord>, IEnumerable, IEnumerator<GridCoord>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000581")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000582")]
			[FieldOffset(Offset = "0x14")]
			private GridCoord _003C_003E2__current;

			[Token(Token = "0x4000583")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000584")]
			[FieldOffset(Offset = "0x24")]
			private GridCoord target;

			[Token(Token = "0x4000585")]
			[FieldOffset(Offset = "0x30")]
			public GridCoord _003C_003E3__target;

			[Token(Token = "0x170000B7")]
			GridCoord IEnumerator<GridCoord>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000836")]
				[Address(RVA = "0x3E77600", Offset = "0x3E77600", Length = "0x10")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170000B8")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000838")]
				[Address(RVA = "0x3E77650", Offset = "0x3E77650", Length = "0x70")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = this.<>2__current;\n\t// 28 Box returnVal1 @ X0_v3 (System.Object), typeof(_game.CoreSystem.New.GridEcsBinding.GridCoord), &v45 @ stack_-40_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord)\n\treturn returnVal1;\n")]
				get
				{
					GridCoord gridCoord = _003C_003E2__current;
					return gridCoord;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000833")]
			[Address(RVA = "0x3E76B0C", Offset = "0x3E76B0C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetFootprint_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000834")]
			[Address(RVA = "0x3E775C0", Offset = "0x3E775C0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000835")]
			[Address(RVA = "0x3E775C4", Offset = "0x3E775C4", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.<>1__state == 0;\n\tif (v2) goto L_0011;\n\tv12 = this.<>1__state != 1;\n\tif (v12) goto L_001A;\n\tv18 = -1;\n\tgoto L_0015;\nL_0011:\n\tthis.<>2__current = this.target;\n\tthis.<>2__current.IsValid = this.target.IsValid;\n\tv18 = 1;\nL_001A:\n\tv42 = this.<>1__state == 0;\n\treturn v42;\nL_0015:\n\tthis.<>1__state = v18;\n")]
			private bool MoveNext()
			{
				int num;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_007f;
					}
					num = -1;
				}
				else
				{
					_003C_003E2__current = target;
					_003C_003E2__current.IsValid = target.IsValid;
					num = 1;
				}
				_003C_003E1__state = num;
				goto IL_007f;
				IL_007f:
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000837")]
			[Address(RVA = "0x3E77610", Offset = "0x3E77610", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000839")]
			[Address(RVA = "0x3E776C0", Offset = "0x3E776C0", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\treturnVal1 = this;\n\tgoto L_003F;\nL_0033:\n\tv76 = new _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode.NoPlaceWallBrush+<GetFootprint>d__4();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\treturnVal1 = v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\nL_003F:\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+2C]) = this.<>3__target.IsValid;\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+24]) = this.<>3__target;\n\treturn returnVal1;\n")]
			IEnumerator<GridCoord> IEnumerable<GridCoord>.GetEnumerator()
			{
				IEnumerator<GridCoord> result;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						result = this;
						goto IL_00b5;
					}
				}
				_003CGetFootprint_003Ed__4 _003CGetFootprint_003Ed__5 = (_003CGetFootprint_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CGetFootprint_003Ed__4));
				_003CGetFootprint_003Ed__5._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetFootprint_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId2;
				result = _003CGetFootprint_003Ed__5;
				goto IL_00b5;
				IL_00b5:
				_ = _003C_003E3__target.IsValid;
				_ = _003C_003E3__target;
				return result;
			}

			[DebuggerHidden]
			[Token(Token = "0x600083A")]
			[Address(RVA = "0x3E7776C", Offset = "0x3E7776C", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\treturnVal1 = this;\n\tgoto L_003F;\nL_0033:\n\tv76 = new _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode.NoPlaceWallBrush+<GetFootprint>d__4();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\treturnVal1 = v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\nL_003F:\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+2C]) = this.<>3__target.IsValid;\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+24]) = this.<>3__target;\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				IEnumerator result;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						result = this;
						goto IL_00b5;
					}
				}
				_003CGetFootprint_003Ed__4 _003CGetFootprint_003Ed__5 = (_003CGetFootprint_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CGetFootprint_003Ed__4));
				_003CGetFootprint_003Ed__5._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetFootprint_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId2;
				result = _003CGetFootprint_003Ed__5;
				goto IL_00b5;
				IL_00b5:
				_ = _003C_003E3__target.IsValid;
				_ = _003C_003E3__target;
				return result;
			}
		}

		[Token(Token = "0x170000B5")]
		public string DisplayName
		{
			[Token(Token = "0x600082B")]
			[Address(RVA = "0x3E76A00", Offset = "0x3E76A00", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\treturn \"No-Place (Wall)\";\n")]
			get
			{
				return "No-Place (Wall)";
			}
		}

		[Token(Token = "0x170000B6")]
		public string CellLetter
		{
			[Token(Token = "0x600082C")]
			[Address(RVA = "0x3E76A44", Offset = "0x3E76A44", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\treturn \"X\";\n")]
			get
			{
				return "X";
			}
		}

		[IteratorStateMachine(typeof(_003CGetFootprint_003Ed__4))]
		[Token(Token = "0x600082D")]
		[Address(RVA = "0x3E76A88", Offset = "0x3E76A88", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv46.<>l__initialThreadId = v51;\n\tv46.<>3__target = target;\n\tv46.<>3__target.IsValid = target.IsValid;\n\treturn v46;\nL_0019:\n\tv46 = new _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode.NoPlaceWallBrush+<GetFootprint>d__4();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = -2;\n\tv51 = System.Environment::get_CurrentManagedThreadId();\n")]
		public IEnumerable<GridCoord> GetFootprint(GridCoord target, IPaintContext context)
		{
			_003CGetFootprint_003Ed__4 _003CGetFootprint_003Ed__5 = new _003CGetFootprint_003Ed__4(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetFootprint_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetFootprint_003Ed__5._003C_003E3__target = target;
			_003CGetFootprint_003Ed__5._003C_003E3__target.IsValid = target.IsValid;
			return _003CGetFootprint_003Ed__5;
		}

		[Token(Token = "0x600082E")]
		[Address(RVA = "0x3E76B44", Offset = "0x3E76B44", Length = "0x374")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv280 = target.IsValid;\n\tgoto L_0024;\nL_0024:\n\tv56 = context->klass;\n\tv292 = context->klass->interface_offsets_count;\n\tv58 = *([v56 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v58) goto L_0048;\n\tv154 = *([v56 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv154 = v154 + 0x10;\n\tv224 = v292 - 1;\n\tv214 = v292 != 1;\nL_FFFFFFFF:\n\tv292 = v224;\n\tif (v214) goto L_002F;\nL_0048:\n\tv315 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Surface(context);\n\tv295 = v315 == 0;\n\tv184 = ~v295;\n\tif (v184) goto L_005C;\n\tgoto L_0184;\nL_004E:\n\tv162 = *([v154 @ X10_v34]) + 1;\n\tv75 = v162 << 4;\n\tv298 = v56 + v75;\n\tv299 = v298 + 0x138;\n\t*([v299 @ X0_v51])(v315, context, *([v299 @ X0_v51+8]), v280, context, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005C:\n\tv322 = *([v315 @ X0_v7]);\n\tv442 = *([v322 @ X8_v9+12E]);\n\tv324 = *([v322 @ X8_v9+12E]) == 0;\n\tif (v324) goto L_0080;\n\tv441 = *([v322 @ X8_v9+B0]) + 8;\n\tv441 = v441 + 0x10;\n\tv427 = v442 - 1;\n\tv407 = v442 != 1;\nL_FFFFFFFF:\n\tv442 = v427;\n\tif (v407) goto L_0067;\nL_0080:\n\tv70 = *([v430 @ X0_v43+8]);\n\treturnVal2 = _game.CoreSystem.New.Shared.EditMode.Brushes.IGridSurface::IsValidCoord(v315, target);\n\tv459 = ~returnVal2;\n\tv460 = ~v459;\n\tif (v460) goto L_009E;\nL_0090:\n\treturn returnVal2;\nL_0092:\n\tv463 = *([v441 @ X10_v29]) + 2;\n\tv464 = v463 << 4;\n\tv465 = v322 + v464;\n\tv466 = v465 + 0x138;\n\tv70 = *([v466 @ X8_v35+8]);\n\t*([v466 @ X8_v35])(returnVal2, v315, target, v280, *([v466 @ X8_v35+8]), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv472 = ~returnVal2;\n\tif (v472) goto L_0090;\nL_009E:\n\tv494 = context->klass;\n\tv537 = context->klass->interface_offsets_count;\n\tv496 = *([v494 @ X8_v11 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v496) goto L_00C2;\n\tv536 = *([v494 @ X8_v11 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv536 = v536 + 0x10;\n\tv522 = v537 - 1;\n\tv502 = v537 != 1;\nL_FFFFFFFF:\n\tv537 = v522;\n\tif (v502) goto L_00A9;\nL_00C2:\n\tv550 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_GridHandler(context);\n\tv552 = v550 == 0;\n\tv553 = ~v552;\nL_FFFFFFFF:\n\tv276 = v550;\nL_FFFFFFFF:\n\tv280 = 2;\n\tif (v553) goto L_00E4;\nL_FFFFFFFF:\n\tv198 = v550;\nL_FFFFFFFF:\n\tv206 = 2;\n\tgoto L_00F5;\nL_00C9:\n\tv556 = *([v536 @ X10_v23]) + 2;\n\tv557 = v556 << 4;\n\tv558 = v494 + v557;\n\tv559 = v558 + 0x138;\n\t*([v559 @ X0_v39])(v563, context, *([v559 @ X0_v39+8]), v280, v70, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv565 = v563 == 0;\nL_FFFFFFFF:\n\tv276 = v563;\nL_FFFFFFFF:\n\tv198 = v563;\nL_FFFFFFFF:\n\tv206 = v280;\n\tif (v565) goto L_00F5;\nL_00E4:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v236_asT @ TEMPCOND_v16 (_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler), typeof(_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler), v276 @ X22_v8 (_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler)\n\tv236 = v236_asT == 0;\nL_FFFFFFFF:\n\tv198 = v276;\nL_FFFFFFFF:\n\tv206 = v280;\n\tif (v236) goto L_0186;\nL_00F5:\n\tv599 = context->klass;\n\tv629 = context->klass->interface_offsets_count;\n\tv601 = *([v599 @ X8_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v601) goto L_0119;\n\tv156 = *([v599 @ X8_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv156 = v156 + 0x10;\n\tv617 = v629 - 1;\n\tv607 = v629 != 1;\nL_FFFFFFFF:\n\tv629 = v617;\n\tif (v607) goto L_0100;\nL_0119:\n\tv638 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Entities(context);\n\tv632 = v198 == 0;\n\tv186 = ~v632;\n\tif (v186) goto L_012D;\n\tgoto L_0184;\nL_011F:\n\tv77 = *([v156 @ X10_v16]) << 4;\n\tv634 = v599 + v77;\n\tv635 = v634 + 0x138;\n\t*([v635 @ X0_v31])(v638, context, *([v635 @ X0_v31+8]), v206, v70, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_012D:\n\tv181 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetNoPlaceWallAt(v198, target);\n\tv643 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v638, v181);\n\tv375 = v643 == 0;\n\tif (v375) goto L_0146;\n\treturn 0;\nL_0146:\n\tgoto L_016C;\n\tv712 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v709, v182);\n\treturnVal4 = v712 ^ 1;\n\treturn returnVal4;\nL_0184:\n\tthrow System.NullReferenceException;\nL_0186:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_002F:\n\tv122 = *([v154 @ X10_v34-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v122) goto L_004E;\nL_0067:\n\tv447 = *([v441 @ X10_v29-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IGridSurface;\n\tif (v447) goto L_0092;\nL_00A9:\n\tv542 = *([v536 @ X10_v23-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v542) goto L_00C9;\nL_0100:\n\tv124 = *([v156 @ X10_v16-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v124) goto L_011F;\nL_016C:\n\tv709 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Entities(context);\n\tv182 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetPinAt(v198, target);\n")]
		public bool CanPaint(GridCoord target, IPaintContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoPlaceWallBrush::CanPaint");
			return default;
		}

		[Token(Token = "0x600082F")]
		[Address(RVA = "0x3E76EB8", Offset = "0x3E76EB8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v39);\n\treturn returnVal1;\n")]
		public bool Matches(Entity entity, EntityManager em)
		{
			Entity entity2 = default(Entity);
			return em.HasComponent<NoPlaceWallTag>(entity2);
		}

		[Token(Token = "0x6000830")]
		[Address(RVA = "0x3E76F1C", Offset = "0x3E76F1C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void DrawParameters()
		{
		}

		[Token(Token = "0x6000831")]
		[Address(RVA = "0x3E76F20", Offset = "0x3E76F20", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv50 = *([v140 @ X2_v3 (_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext)]);\n\tv191 = *([v50 @ X8_v7 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]);\n\tv52 = *([v50 @ X8_v7 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v52) goto L_0041;\n\tv99 = *([v50 @ X8_v7 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv99 = v99 + 0x10;\n\tv131 = v191 - 1;\n\tv121 = v191 != 1;\nL_FFFFFFFF:\n\tv191 = v131;\n\tif (v121) goto L_0028;\nL_0041:\n\tv175 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Mutations(v140);\nL_0054:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v143_asT @ TEMPCOND_v5 (_game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations), typeof(_game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations), v175 @ X0_v6\n\tv143 = v143_asT == 0;\n\tif (v143) goto L_0086;\n\tv241 = *([v175 @ X0_v6+88]) == 0;\n\tif (v241) goto L_0078;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode.NoPlaceWallEditorMutations::AddAt(*([v175 @ X0_v6+88]), targets);\n\treturn;\nL_0078:\n\treturn;\nL_007A:\n\tv103 = *([v99 @ X10_v8]) + 3;\n\tv58 = v103 << 4;\n\tv196 = v50 + v58;\n\tv197 = v196 + 0x138;\n\t*([v197 @ X0_v12])(v175, v140, *([v197 @ X0_v12+8]), v140, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv199 = v175 == 0;\n\tv113 = ~v199;\n\tif (v113) goto L_0054;\n\tv118 = new System.NullReferenceException();\nL_0086:\n\tthrow System.InvalidCastException;\nL_0028:\n\tv83 = *([v99 @ X10_v8-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v83) goto L_007A;\n")]
		public void Paint(IReadOnlyList<GridCoord> targets, IPaintContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoPlaceWallBrush::Paint");
		}

		[Token(Token = "0x6000832")]
		[Address(RVA = "0x3E775B8", Offset = "0x3E775B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NoPlaceWallBrush()
		{
		}
	}
}
