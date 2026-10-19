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
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode
{
	[GridBrush("topgrid", 12)]
	[Token(Token = "0x20001AD")]
	public sealed class PinBrush : IOrderedPathBrush, IGridBrush
	{
		[CompilerGenerated]
		[Token(Token = "0x20001AE")]
		private sealed class _003CGetFootprint_003Ed__6 : IEnumerable<GridCoord>, IEnumerable, IEnumerator<GridCoord>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400053F")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000540")]
			[FieldOffset(Offset = "0x14")]
			private GridCoord _003C_003E2__current;

			[Token(Token = "0x4000541")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000542")]
			[FieldOffset(Offset = "0x24")]
			private GridCoord target;

			[Token(Token = "0x4000543")]
			[FieldOffset(Offset = "0x30")]
			public GridCoord _003C_003E3__target;

			[Token(Token = "0x170000AE")]
			GridCoord IEnumerator<GridCoord>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60007CF")]
				[Address(RVA = "0x3E6F10C", Offset = "0x3E6F10C", Length = "0x10")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170000AF")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60007D1")]
				[Address(RVA = "0x3E6F15C", Offset = "0x3E6F15C", Length = "0x70")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = this.<>2__current;\n\t// 28 Box returnVal1 @ X0_v3 (System.Object), typeof(_game.CoreSystem.New.GridEcsBinding.GridCoord), &v45 @ stack_-40_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord)\n\treturn returnVal1;\n")]
				get
				{
					GridCoord gridCoord = _003C_003E2__current;
					return gridCoord;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60007CC")]
			[Address(RVA = "0x3E6E370", Offset = "0x3E6E370", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetFootprint_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60007CD")]
			[Address(RVA = "0x3E6F0CC", Offset = "0x3E6F0CC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60007CE")]
			[Address(RVA = "0x3E6F0D0", Offset = "0x3E6F0D0", Length = "0x3C")]
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
			[Token(Token = "0x60007D0")]
			[Address(RVA = "0x3E6F11C", Offset = "0x3E6F11C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x60007D2")]
			[Address(RVA = "0x3E6F1CC", Offset = "0x3E6F1CC", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\treturnVal1 = this;\n\tgoto L_003F;\nL_0033:\n\tv76 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinBrush+<GetFootprint>d__6();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\treturnVal1 = v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\nL_003F:\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+2C]) = this.<>3__target.IsValid;\n\t*([returnVal1 @ X0_v2 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+24]) = this.<>3__target;\n\treturn returnVal1;\n")]
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
				_003CGetFootprint_003Ed__6 _003CGetFootprint_003Ed__7 = (_003CGetFootprint_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CGetFootprint_003Ed__6));
				_003CGetFootprint_003Ed__7._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetFootprint_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId2;
				result = _003CGetFootprint_003Ed__7;
				goto IL_00b5;
				IL_00b5:
				_ = _003C_003E3__target.IsValid;
				_ = _003C_003E3__target;
				return result;
			}

			[DebuggerHidden]
			[Token(Token = "0x60007D3")]
			[Address(RVA = "0x3E6F278", Offset = "0x3E6F278", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\treturnVal1 = this;\n\tgoto L_003F;\nL_0033:\n\tv76 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinBrush+<GetFootprint>d__6();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\treturnVal1 = v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\nL_003F:\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+2C]) = this.<>3__target.IsValid;\n\t*([returnVal1 @ X0_v2 (System.Collections.IEnumerator)+24]) = this.<>3__target;\n\treturn returnVal1;\n")]
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
				_003CGetFootprint_003Ed__6 _003CGetFootprint_003Ed__7 = (_003CGetFootprint_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CGetFootprint_003Ed__6));
				_003CGetFootprint_003Ed__7._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetFootprint_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId2;
				result = _003CGetFootprint_003Ed__7;
				goto IL_00b5;
				IL_00b5:
				_ = _003C_003E3__target.IsValid;
				_ = _003C_003E3__target;
				return result;
			}
		}

		[Token(Token = "0x170000AB")]
		public string DisplayName
		{
			[Token(Token = "0x60007C1")]
			[Address(RVA = "0x3E6E25C", Offset = "0x3E6E25C", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\treturn \"Pin\";\n")]
			get
			{
				return "Pin";
			}
		}

		[Token(Token = "0x170000AC")]
		public string CellLetter
		{
			[Token(Token = "0x60007C2")]
			[Address(RVA = "0x3E6E2A0", Offset = "0x3E6E2A0", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\treturn \"P\";\n")]
			get
			{
				return "P";
			}
		}

		[Token(Token = "0x170000AD")]
		public OrderedSelectionDrag DragMode
		{
			[Token(Token = "0x60007C3")]
			[Address(RVA = "0x3E6E2E4", Offset = "0x3E6E2E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return default(OrderedSelectionDrag);
			}
		}

		[IteratorStateMachine(typeof(_003CGetFootprint_003Ed__6))]
		[Token(Token = "0x60007C4")]
		[Address(RVA = "0x3E6E2EC", Offset = "0x3E6E2EC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv46.<>l__initialThreadId = v51;\n\tv46.<>3__target = target;\n\tv46.<>3__target.IsValid = target.IsValid;\n\treturn v46;\nL_0019:\n\tv46 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinBrush+<GetFootprint>d__6();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = -2;\n\tv51 = System.Environment::get_CurrentManagedThreadId();\n")]
		public IEnumerable<GridCoord> GetFootprint(GridCoord target, IPaintContext context)
		{
			_003CGetFootprint_003Ed__6 _003CGetFootprint_003Ed__7 = new _003CGetFootprint_003Ed__6(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetFootprint_003Ed__7._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetFootprint_003Ed__7._003C_003E3__target = target;
			_003CGetFootprint_003Ed__7._003C_003E3__target.IsValid = target.IsValid;
			return _003CGetFootprint_003Ed__7;
		}

		[Token(Token = "0x60007C5")]
		[Address(RVA = "0x3E6E3A8", Offset = "0x3E6E3A8", Length = "0x414")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv300 = target.IsValid;\n\tgoto L_0024;\nL_0024:\n\tv56 = context->klass;\n\tv312 = context->klass->interface_offsets_count;\n\tv58 = *([v56 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v58) goto L_0048;\n\tv167 = *([v56 @ X8_v5 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv167 = v167 + 0x10;\n\tv244 = v312 - 1;\n\tv234 = v312 != 1;\nL_FFFFFFFF:\n\tv312 = v244;\n\tif (v234) goto L_002F;\nL_0048:\n\tv335 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Surface(context);\n\tv315 = v335 == 0;\n\tv201 = ~v315;\n\tif (v201) goto L_005C;\n\tgoto L_01C9;\nL_004E:\n\tv176 = *([v167 @ X10_v40]) + 1;\n\tv78 = v176 << 4;\n\tv318 = v56 + v78;\n\tv319 = v318 + 0x138;\n\t*([v319 @ X0_v62])(v335, context, *([v319 @ X0_v62+8]), v300, context, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005C:\n\tv342 = *([v335 @ X0_v7]);\n\tv474 = *([v342 @ X8_v9+12E]);\n\tv344 = *([v342 @ X8_v9+12E]) == 0;\n\tif (v344) goto L_0080;\n\tv473 = *([v342 @ X8_v9+B0]) + 8;\n\tv473 = v473 + 0x10;\n\tv459 = v474 - 1;\n\tv439 = v474 != 1;\nL_FFFFFFFF:\n\tv474 = v459;\n\tif (v439) goto L_0067;\nL_0080:\n\tv72 = *([v462 @ X0_v54+8]);\n\treturnVal2 = _game.CoreSystem.New.Shared.EditMode.Brushes.IGridSurface::IsValidCoord(v335, target);\n\tv491 = ~returnVal2;\n\tv492 = ~v491;\n\tif (v492) goto L_009E;\nL_0090:\n\treturn returnVal2;\nL_0092:\n\tv495 = *([v473 @ X10_v35]) + 2;\n\tv496 = v495 << 4;\n\tv497 = v342 + v496;\n\tv498 = v497 + 0x138;\n\tv72 = *([v498 @ X8_v39+8]);\n\t*([v498 @ X8_v39])(returnVal2, v335, target, v300, *([v498 @ X8_v39+8]), methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv504 = ~returnVal2;\n\tif (v504) goto L_0090;\nL_009E:\n\tv526 = context->klass;\n\tv569 = context->klass->interface_offsets_count;\n\tv528 = *([v526 @ X8_v11 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v528) goto L_00C2;\n\tv568 = *([v526 @ X8_v11 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv568 = v568 + 0x10;\n\tv554 = v569 - 1;\n\tv534 = v569 != 1;\nL_FFFFFFFF:\n\tv569 = v554;\n\tif (v534) goto L_00A9;\nL_00C2:\n\tv582 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_GridHandler(context);\n\tv584 = v582 == 0;\n\tv585 = ~v584;\nL_FFFFFFFF:\n\tv296 = v582;\nL_FFFFFFFF:\n\tv300 = 2;\n\tif (v585) goto L_00E4;\nL_FFFFFFFF:\n\tv217 = v582;\nL_FFFFFFFF:\n\tv225 = 2;\n\tgoto L_00F5;\nL_00C9:\n\tv588 = *([v568 @ X10_v29]) + 2;\n\tv589 = v588 << 4;\n\tv590 = v526 + v589;\n\tv591 = v590 + 0x138;\n\t*([v591 @ X0_v50])(v595, context, *([v591 @ X0_v50+8]), v300, v72, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv597 = v595 == 0;\nL_FFFFFFFF:\n\tv296 = v595;\nL_FFFFFFFF:\n\tv217 = v595;\nL_FFFFFFFF:\n\tv225 = v300;\n\tif (v597) goto L_00F5;\nL_00E4:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v256_asT @ TEMPCOND_v20 (_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler), typeof(_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler), v296 @ X22_v9 (_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler)\n\tv256 = v256_asT == 0;\nL_FFFFFFFF:\n\tv217 = v296;\nL_FFFFFFFF:\n\tv225 = v300;\n\tif (v256) goto L_01CB;\nL_00F5:\n\tv631 = context->klass;\n\tv661 = context->klass->interface_offsets_count;\n\tv633 = *([v631 @ X8_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v633) goto L_0119;\n\tv169 = *([v631 @ X8_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv169 = v169 + 0x10;\n\tv649 = v661 - 1;\n\tv639 = v661 != 1;\nL_FFFFFFFF:\n\tv661 = v649;\n\tif (v639) goto L_0100;\nL_0119:\n\tv670 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Entities(context);\n\tv664 = v217 == 0;\n\tv203 = ~v664;\n\tif (v203) goto L_012D;\n\tgoto L_01C9;\nL_011F:\n\tv80 = *([v169 @ X10_v22]) << 4;\n\tv666 = v631 + v80;\n\tv667 = v666 + 0x138;\n\t*([v667 @ X0_v42])(v670, context, *([v667 @ X0_v42+8]), v225, v72, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_012D:\n\tv197 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetPinAt(v217, target);\n\tv675 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v670, v197);\n\tv400 = v675 == 0;\n\tif (v400) goto L_0146;\n\treturn 0;\nL_0146:\n\tgoto L_016C;\n\tv744 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v741, v198);\n\tv401 = v744 == 0;\n\tif (v401) goto L_018B;\n\treturn 0;\nL_018B:\n\tgoto L_01B1;\n\tv813 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v810, v199);\n\treturnVal5 = v813 ^ 1;\n\treturn returnVal5;\nL_01C9:\n\tthrow System.NullReferenceException;\nL_01CB:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_002F:\n\tv131 = *([v167 @ X10_v40-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v131) goto L_004E;\nL_0067:\n\tv479 = *([v473 @ X10_v35-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IGridSurface;\n\tif (v479) goto L_0092;\nL_00A9:\n\tv574 = *([v568 @ X10_v29-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v574) goto L_00C9;\nL_0100:\n\tv133 = *([v169 @ X10_v22-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v133) goto L_011F;\nL_016C:\n\tv741 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Entities(context);\n\tv198 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetNoPlaceAt(v217, target);\nL_01B1:\n\tv810 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Entities(context);\n\tv199 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::GetNoPlaceWallAt(v217, target);\n")]
		public bool CanPaint(GridCoord target, IPaintContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBrush::CanPaint");
			return default;
		}

		[Token(Token = "0x60007C6")]
		[Address(RVA = "0x3E6E7BC", Offset = "0x3E6E7BC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(em, v39);\n\treturn returnVal1;\n")]
		public bool Matches(Entity entity, EntityManager em)
		{
			Entity entity2 = default(Entity);
			return em.HasComponent<PinNodeComponent>(entity2);
		}

		[Token(Token = "0x60007C7")]
		[Address(RVA = "0x3E6E820", Offset = "0x3E6E820", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_FFFFFFFF:\n\tv134 = context;\nL_FFFFFFFF:\n\tv167 = 0;\n\tgoto L_0049;\nL_0033:\n\tv361 = 0x220C5E0(current, System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0038:\n\tv422 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(current, v167);\n\tv141 = v422;\n\tv234 = _game.CoreSystem.New.GridEcsBinding.GridCoord::Equals(&v141 @ stack_-60_v4 (_game.CoreSystem.New.GridEcsBinding.GridCoord), next);\n\tv167 = v167 + 1;\n\tv452 = v234 == 0;\n\tv156 = ~v452;\nL_FFFFFFFF:\n\tv134 = 0;\n\tif (v156) goto L_FFFFFFFF;\nL_0049:\n\tgoto L_006F;\n\tv330 = *([v317 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v330) goto L_0033;\n\tv401 = *([v317 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv401 = v401 + 0x10;\n\tv358 = v435 - 1;\n\tv338 = v435 != 1;\nL_FFFFFFFF:\n\tv435 = v358;\n\tif (v338) goto L_0082;\n\tgoto L_0033;\nL_009F:\n\tgoto L_0038;\nL_00A1:\n\tv332 = *([v317 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+12E]) == 0;\n\tif (v332) goto L_00C3;\n\tv434 = *([v317 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+B0]) + 8;\n\tv434 = v434 + 0x10;\n\tv387 = v435 - 1;\n\tv367 = v435 != 1;\nL_FFFFFFFF:\n\tv435 = v387;\n\tif (v367) goto L_00A5;\nL_00C3:\n\tv448 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(current);\n\tv449 = v448 == 0;\n\tif (v449) goto L_FFFFFFFF;\nL_00CA:\n\tgoto L_00FF;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0164;\nL_00EC:\n\tv455 = *([v434 @ X10_v21]) << 4;\n\tv456 = v317 + v455;\n\tv457 = v456 + 0x138;\n\t*([v457 @ X0_v29])(v461, current, *([v457 @ X0_v29+8]), 0, v134, context, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv462 = v461 == 0;\n\tv463 = ~v462;\n\tif (v463) goto L_00CA;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_0164;\n\tv129 = -v129;\n\tgoto L_0147;\n\tv661 = -v661;\n\tgoto L_014E;\nL_0025:\n\treturnVal1 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinBrush::CanPaint(v49, next, context);\n\tv63 = ~returnVal1;\n\tif (v63) goto L_0164;\nL_0164:\n\treturn returnVal1;\nL_006F:\n\tv316 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(current);\n\tv317 = current->klass;\n\tv435 = current->klass->interface_offsets_count;\n\tv328 = v167 >= v316;\n\tif (v328) goto L_00A1;\nL_0082:\n\t;\n\tv407 = *([v401 @ X10_v25-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v407) goto L_009F;\nL_00A5:\n\t;\n\tv440 = *([v434 @ X10_v21-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>;\n\tif (v440) goto L_00EC;\nL_00FF:\n\tv561 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Count(current);\n\tv165 = v561 - 1;\n\tgoto L_012C;\nL_012C:\n\tv634 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::get_Item(current, v165);\n\tv129 = next - v634;\n\tv646 = next >= v634;\n\tif (v646) goto L_0147;\nL_0147:\n\tv661 = next.y - v634.y;\n\tv66 = next.y >= v634.y;\n\tif (v66) goto L_014E;\nL_014E:\n\tv159 = v661 + v129;\n\tv114 = v159 - 1;\n\tv104 = v114 == 0;\nL_FFFFFFFF:\n\treturnVal1 = v104;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool CanAppend(GridCoord next, IReadOnlyList<GridCoord> current, IPaintContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBrush::CanAppend");
			return default;
		}

		[Token(Token = "0x60007C8")]
		[Address(RVA = "0x3E6EB04", Offset = "0x3E6EB04", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void DrawParameters()
		{
		}

		[Token(Token = "0x60007C9")]
		[Address(RVA = "0x3E6EB08", Offset = "0x3E6EB08", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinBrush::TryCommit(this, targets, context);\n\treturn;\n")]
		public void Paint(IReadOnlyList<GridCoord> targets, IPaintContext context)
		{
			bool flag = TryCommit(targets, context);
		}

		[Token(Token = "0x60007CA")]
		[Address(RVA = "0x3E6EB0C", Offset = "0x3E6EB0C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv50 = *([v140 @ X2_v3 (_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext)]);\n\tv191 = *([v50 @ X8_v7 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]);\n\tv52 = *([v50 @ X8_v7 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+12E]) == 0;\n\tif (v52) goto L_0041;\n\tv99 = *([v50 @ X8_v7 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext>)+B0]) + 8;\n\tv99 = v99 + 0x10;\n\tv131 = v191 - 1;\n\tv121 = v191 != 1;\nL_FFFFFFFF:\n\tv191 = v131;\n\tif (v121) goto L_0028;\nL_0041:\n\tv175 = _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext::get_Mutations(v140);\nL_0054:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v143_asT @ TEMPCOND_v5 (_game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations), typeof(_game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations), v175 @ X0_v6\n\tv143 = v143_asT == 0;\n\tif (v143) goto L_007F;\n\tv239 = *([v175 @ X0_v6+78]) == 0;\n\tif (v239) goto L_0071;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinEditorMutations::BuildPinFromSelection(*([v175 @ X0_v6+78]), selection);\nL_0071:\n\treturn 1;\nL_0073:\n\tv103 = *([v99 @ X10_v8]) + 3;\n\tv58 = v103 << 4;\n\tv196 = v50 + v58;\n\tv197 = v196 + 0x138;\n\t*([v197 @ X0_v13])(v175, v140, *([v197 @ X0_v13+8]), v140, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv199 = v175 == 0;\n\tv113 = ~v199;\n\tif (v113) goto L_0054;\n\tv118 = new System.NullReferenceException();\nL_007F:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_0028:\n\tv83 = *([v99 @ X10_v8-8]) == _game.CoreSystem.New.Shared.EditMode.Brushes.IPaintContext;\n\tif (v83) goto L_0073;\n")]
		public bool TryCommit(IReadOnlyList<GridCoord> selection, IPaintContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinBrush::TryCommit");
			return default;
		}

		[Token(Token = "0x60007CB")]
		[Address(RVA = "0x3E6F0C4", Offset = "0x3E6F0C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public PinBrush()
		{
		}
	}
}
