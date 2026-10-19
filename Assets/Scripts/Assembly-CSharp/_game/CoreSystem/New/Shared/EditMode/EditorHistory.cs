using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.Shared.EditMode
{
	[Token(Token = "0x2000287")]
	public class EditorHistory
	{
		[Token(Token = "0x2000288")]
		private sealed class BatchScope : IDisposable
		{
			[Token(Token = "0x40007FD")]
			[FieldOffset(Offset = "0x10")]
			private EditorHistory _owner;

			[Token(Token = "0x6000B4C")]
			[Address(RVA = "0x3EC581C", Offset = "0x3EC581C", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._owner = owner;\n\treturn;\n")]
			public BatchScope(EditorHistory owner)
			{
				_owner = owner;
			}

			[Token(Token = "0x6000B4D")]
			[Address(RVA = "0x3EC5850", Offset = "0x3EC5850", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._owner = 0;\n\tv29 = this._owner == 0;\n\tif (v29) goto L_001B;\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::EndBatch(this._owner);\n\treturn;\nL_001B:\n\treturn;\n")]
			public void Dispose()
			{
				_owner = null;
				if (_owner != null)
				{
					_owner.EndBatch();
				}
			}
		}

		[Token(Token = "0x2000289")]
		private sealed class NullScope : IDisposable
		{
			[Token(Token = "0x40007FE")]
			public static readonly NullScope Instance;

			[Token(Token = "0x6000B4E")]
			[Address(RVA = "0x3EC5890", Offset = "0x3EC5890", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			public void Dispose()
			{
			}

			[Token(Token = "0x6000B4F")]
			[Address(RVA = "0x3EC5894", Offset = "0x3EC5894", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public NullScope()
			{
			}

			[Token(Token = "0x6000B50")]
			[Address(RVA = "0x3EC589C", Offset = "0x3EC589C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.Shared.EditMode.EditorHistory+NullScope();\n\tSystem.Object::.ctor(v40);\n\tv44.Instance = v40;\n")]
			static NullScope()
			{
				NullScope instance = new NullScope();
				Instance = instance;
			}
		}

		[Token(Token = "0x40007F4")]
		private const int MaxUndoSteps = 100;

		[Inject(false)]
		[Token(Token = "0x40007F5")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Token(Token = "0x40007F6")]
		[FieldOffset(Offset = "0x18")]
		private readonly LinkedList<EntityManager> _undo;

		[Token(Token = "0x40007F7")]
		[FieldOffset(Offset = "0x20")]
		private readonly Stack<EntityManager> _redo;

		[Token(Token = "0x40007F8")]
		[FieldOffset(Offset = "0x28")]
		private int _batchDepth;

		[Token(Token = "0x40007F9")]
		[FieldOffset(Offset = "0x30")]
		private EntityManager _batchSnapshot;

		[Token(Token = "0x40007FA")]
		[FieldOffset(Offset = "0x38")]
		private string _batchLabel;

		[CompilerGenerated]
		[Token(Token = "0x40007FB")]
		[FieldOffset(Offset = "0x40")]
		internal Action<string> HistoryPushed;

		[CompilerGenerated]
		[Token(Token = "0x40007FC")]
		[FieldOffset(Offset = "0x48")]
		internal Action<EntityManager> Restored;

		[Token(Token = "0x170000D5")]
		public int UndoCount
		{
			[Token(Token = "0x6000B44")]
			[Address(RVA = "0x3EC5368", Offset = "0x3EC5368", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._undo;\n")]
			get
			{
				LinkedList<EntityManager> undo = _undo;
				return undo.Count;
			}
		}

		[Token(Token = "0x170000D6")]
		public int RedoCount
		{
			[Token(Token = "0x6000B45")]
			[Address(RVA = "0x3EC53B4", Offset = "0x3EC53B4", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._redo;\n")]
			get
			{
				Stack<EntityManager> redo = _redo;
				return redo.Count;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6000B40")]
		[Address(RVA = "0x3EBE880", Offset = "0x3EBE880", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<System.String>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.HistoryPushed;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.HistoryPushed (System.Action`1<System.String>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_HistoryPushed(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::add_HistoryPushed");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000B41")]
		[Address(RVA = "0x3EBE718", Offset = "0x3EBE718", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<System.String>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.HistoryPushed;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.HistoryPushed (System.Action`1<System.String>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_HistoryPushed(Action<string> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::remove_HistoryPushed");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000B42")]
		[Address(RVA = "0x3EBE934", Offset = "0x3EBE934", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.Restored;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.Restored (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_Restored(Action<EntityManager> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::add_Restored");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000B43")]
		[Address(RVA = "0x3EBE7CC", Offset = "0x3EBE7CC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.Restored;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.Restored (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_Restored(Action<EntityManager> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::remove_Restored");
		}

		[Token(Token = "0x6000B46")]
		[Address(RVA = "0x3EC5400", Offset = "0x3EC5400", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv61 = this._batchDepth <= 0;\n\tif (v61) goto L_0042;\nL_003F:\n\treturn;\nL_0042:\n\tv112 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Clone(this._em);\n\tv156 = System.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::AddFirst(this._undo, v112);\n\tv193 = this._undo;\n\tv166 = v193.Count < 0x65;\n\tif (v166) goto L_006D;\n\tv194 = System.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::get_Last(v193);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Dispose(v194.item);\n\tSystem.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::RemoveLast(this._undo);\nL_006D:\n\tv218 = this._redo;\n\tv198 = System.Collections.Generic.Stack`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::Pop(v218);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Dispose(v198);\n\tv218 = this._redo;\n\tv247 = this._redo == 0;\n\tv200 = ~v247;\n\tif (v200) goto L_007E;\n\tthrow System.NullReferenceException;\nL_008B:\n\t;\n\tv96 = this.HistoryPushed == 0;\n\tif (v96) goto L_003F;\n\tSystem.Action`1<System.String>::Invoke(this.HistoryPushed, label);\n\treturn;\nL_0028:\n\tv45 = this._em == 0;\n\tif (v45) goto L_003F;\nL_007E:\n\tv165 = v218.Count <= 0;\n\tif (v165) goto L_008B;\n")]
		public void Push(string label)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::Push");
		}

		[Token(Token = "0x6000B47")]
		[Address(RVA = "0x3EC5580", Offset = "0x3EC5580", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv65 = this._batchDepth;\n\tv51 = this._batchDepth == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_002F;\n\tv60 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Clone(this._em);\n\tthis._batchSnapshot = v60;\n\tthis._batchLabel = label;\n\tv65 = this._batchDepth;\nL_0046:\n\tgoto L_0053;\nL_0019:\n\tv45 = this._em == 0;\n\tif (v45) goto L_0046;\nL_002F:\n\tv69 = v65 + 1;\n\tthis._batchDepth = v69;\n\tv71 = new _game.CoreSystem.New.Shared.EditMode.EditorHistory+BatchScope();\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory+BatchScope::.ctor(v71, this);\n\treturn v71;\nL_0053:\n\treturn v75.Instance;\n")]
		public IDisposable Batch(string label)
		{
			if (_em != null)
			{
				int batchDepth = _batchDepth;
				if (_batchDepth == 0)
				{
					EntityManager batchSnapshot = _em.Clone();
					_batchSnapshot = batchSnapshot;
					_batchLabel = label;
					batchDepth = _batchDepth;
				}
				int batchDepth2 = batchDepth + 1;
				_batchDepth = batchDepth2;
				return new BatchScope(this);
			}
			return NullScope.Instance;
		}

		[Token(Token = "0x6000B48")]
		[Address(RVA = "0x3EC5678", Offset = "0x3EC5678", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv48 = this._batchDepth - 1;\n\tthis._batchDepth = v48;\n\tv60 = v48 <= 0;\n\tif (v60) goto L_0041;\nL_003F:\n\treturn;\nL_0041:\n\tv118 = this + 0x30;\n\tv70 = v118 + 8;\n\tthis._batchSnapshot = 0;\n\t*([v70 @ X22_v4]) = 0;\n\tv102 = this._batchSnapshot == 0;\n\tif (v102) goto L_003F;\n\tv171 = System.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::AddFirst(this._undo, this._batchSnapshot);\n\tv210 = this._undo;\n\tv183 = v210.Count < 0x65;\n\tif (v183) goto L_0079;\n\tv211 = System.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::get_Last(v210);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Dispose(v211.item);\n\tSystem.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::RemoveLast(this._undo);\nL_0079:\n\tv230 = this._redo;\n\tv215 = System.Collections.Generic.Stack`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::Pop(v230);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Dispose(v215);\n\tv230 = this._redo;\n\tv257 = this._redo == 0;\n\tv217 = ~v257;\n\tif (v217) goto L_008A;\n\tthrow System.NullReferenceException;\nL_0097:\n\t;\n\tv103 = this.HistoryPushed == 0;\n\tif (v103) goto L_003F;\n\tSystem.Action`1<System.String>::Invoke(this.HistoryPushed, *([v70 @ X22_v4]));\n\treturn;\nL_0027:\n\tv44 = this._batchDepth == 0;\n\tif (v44) goto L_003F;\nL_008A:\n\tv182 = v230.Count <= 0;\n\tif (v182) goto L_0097;\n")]
		private void EndBatch()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::EndBatch");
		}

		[Token(Token = "0x6000B49")]
		[Address(RVA = "0x3EBF33C", Offset = "0x3EBF33C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv48 = this._undo;\n\tv77 = v48.Count == 0;\n\tif (v77) goto L_0063;\n\tv125 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Clone(this._em);\n\tSystem.Collections.Generic.Stack`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::Push(this._redo, v125);\n\tv89 = this._undo;\n\tv99 = v89.First;\n\tSystem.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::RemoveFirst(v89);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RestoreFrom(this._em, v99.item);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Dispose(v99.item);\n\tv62 = this.Restored == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::Invoke(this.Restored, v125);\nL_0063:\n\treturn 0;\nL_0021:\n\tv44 = this._em == 0;\nL_FFFFFFFF:\n\treturnVal1 = this._em;\n\tif (v44) goto L_005A;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_005A:\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Undo()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::Undo");
			return default;
		}

		[Token(Token = "0x6000B4A")]
		[Address(RVA = "0x3EBF470", Offset = "0x3EBF470", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv48 = this._redo;\n\tv104 = v48.Count == 0;\n\tif (v104) goto L_0088;\n\tv181 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Clone(this._em);\n\tv189 = System.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::AddFirst(this._undo, v181);\n\tv128 = this._undo;\n\tv56 = v128.Count < 0x65;\n\tif (v56) goto L_0062;\n\tv129 = System.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::get_Last(v128);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Dispose(v129.item);\n\tSystem.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::RemoveLast(this._undo);\nL_0062:\n\tv201 = System.Collections.Generic.Stack`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::Pop(this._redo);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RestoreFrom(this._em, v201);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Dispose(v201);\n\tv89 = this.Restored == 0;\n\tif (v89) goto L_FFFFFFFF;\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::Invoke(this.Restored, v181);\nL_0088:\n\treturn 0;\nL_0027:\n\tv44 = this._em == 0;\nL_FFFFFFFF:\n\treturnVal1 = this._em;\n\tif (v44) goto L_007F;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_007F:\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Redo()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EditorHistory::Redo");
			return default;
		}

		[Token(Token = "0x6000B4B")]
		[Address(RVA = "0x3EC5288", Offset = "0x3EC5288", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.Stack`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Collections.Generic.Stack`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v72);\n\tthis._redo = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Collections.Generic.LinkedList`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v56);\n\tthis._undo = v56;\n")]
		public EditorHistory()
		{
			LinkedList<EntityManager> undo = new LinkedList<EntityManager>();
			_undo = undo;
			Stack<EntityManager> redo = new Stack<EntityManager>();
			_redo = redo;
		}
	}
}
