using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.EditMode;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core;
using _game.CoreSystem.New.MoldSystem.Visual;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation.EditMode
{
	[ExecuteAlways]
	[Token(Token = "0x20002F7")]
	public class MoldReconcileTick_Editor : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x4000918")]
		[FieldOffset(Offset = "0x20")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000919")]
		[FieldOffset(Offset = "0x28")]
		private MoldLinkedHandler _linkedHandler;

		[Inject(false)]
		[Token(Token = "0x400091A")]
		[FieldOffset(Offset = "0x30")]
		private MoldGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x400091B")]
		[FieldOffset(Offset = "0x38")]
		private MoldVisualStateInitSystem _initSystem;

		[Inject(false)]
		[Token(Token = "0x400091C")]
		[FieldOffset(Offset = "0x40")]
		private IMoldCmdProcessor _cmdProcessor;

		[Inject(false)]
		[Token(Token = "0x400091D")]
		[FieldOffset(Offset = "0x48")]
		private EditorHistory _history;

		[Inject(false)]
		[Token(Token = "0x400091E")]
		[FieldOffset(Offset = "0x50")]
		private MoldEditorMutations _mutations;

		[Inject(false)]
		[Token(Token = "0x400091F")]
		[FieldOffset(Offset = "0x58")]
		private MoldFillDisplayCore m_fillDisplayCore;

		[Token(Token = "0x4000920")]
		[FieldOffset(Offset = "0x60")]
		private MoldReconcileCore _core;

		[Token(Token = "0x4000921")]
		[FieldOffset(Offset = "0x68")]
		private bool _isConstructed;

		[Token(Token = "0x4000922")]
		[FieldOffset(Offset = "0x70")]
		private IReadOnlyList<IMoldVisualHandler> _visualHandlers;

		[Token(Token = "0x170000FC")]
		public MoldEditorMutations Mutations
		{
			[Token(Token = "0x6000D1B")]
			[Address(RVA = "0x3EEA498", Offset = "0x3EEA498", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Mutations;\n")]
			get
			{
				return _mutations;
			}
		}

		[Token(Token = "0x170000FD")]
		public MoldGridHandler GridHandler
		{
			[Token(Token = "0x6000D1C")]
			[Address(RVA = "0x3EEA4A0", Offset = "0x3EEA4A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.GridHandler;\n")]
			get
			{
				return _gridHandler;
			}
		}

		[Token(Token = "0x170000FE")]
		public EditorHistory History
		{
			[Token(Token = "0x6000D1D")]
			[Address(RVA = "0x3EEA4A8", Offset = "0x3EEA4A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.History;\n")]
			get
			{
				return _history;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6000D1E")]
		[Address(RVA = "0x3EEA4B0", Offset = "0x3EEA4B0", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv88 = new System.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>::.ctor(v88, visualHandlers);\n\tthis._visualHandlers = v88;\n\tthis._isConstructed = 1;\n\tv101 = this.History == 0;\n\tif (v101) goto L_0088;\n\tv107 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v107, this, Il2CppMethodInfo);\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::remove_Restored(this.History, v107);\n\tv167 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v167, this, Il2CppMethodInfo);\n\tv146 = this.History == 0;\n\tif (v146) goto L_0089;\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::add_Restored(this.History, v167);\n\treturn;\nL_0088:\n\treturn;\nL_0089:\n\tthrow v167;\nL_0032:\n\tv67 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore();\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore::.ctor(v67, this._em, this._linkedHandler, this.GridHandler, this._cmdProcessor);\n\tthis._core = v67;\n")]
		private void Construct(IEnumerable<IMoldVisualHandler> visualHandlers)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcileTick_Editor::Construct");
		}

		[Token(Token = "0x6000D1F")]
		[Address(RVA = "0x3EEA660", Offset = "0x3EEA660", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_deltaTime();\n\tv24 = this._isConstructed != 1;\n\tif (v24) goto L_002A;\n\tv26 = this._core == 0;\n\tif (v26) goto L_0023;\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore::Tick(this._core, v13);\nL_0023:\n\t_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayCore::Update(this.m_fillDisplayCore);\n\treturn;\nL_002A:\n\treturn;\n")]
		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (_isConstructed)
			{
				if (_core != null)
				{
					_core.Tick(deltaTime);
				}
				m_fillDisplayCore.Update();
			}
		}

		[Token(Token = "0x6000D20")]
		[Address(RVA = "0x3EEA6BC", Offset = "0x3EEA6BC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = v34._isConstructed != 1;\n\tif (v21) goto L_002A;\n\tv23 = v34._core == 0;\n\tif (v23) goto L_0023;\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileCore::Tick(v34._core, dt);\nL_0023:\n\t_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayCore::Update(v34.m_fillDisplayCore);\n\treturn;\nL_002A:\n\treturn;\n")]
		public void Tick(float dt)
		{
			if (_isConstructed)
			{
				if (_core != null)
				{
					_core.Tick(dt);
				}
				m_fillDisplayCore.Update();
			}
		}

		[Token(Token = "0x6000D21")]
		[Address(RVA = "0x3EEA718", Offset = "0x3EEA718", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv156 = 0;\n\tgoto L_0038;\nL_0030:\n\tv136 = *([v409 @ X0_v9+8]);\n\tv215 = _game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler::SyncWithData(v386, from);\n\tv156 = v156 + 1;\n\tv139 = this._visualHandlers;\nL_0038:\n\tv226 = *([v139 @ X22_v4 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>)]);\n\tv262 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>>)+12E]);\n\tv149 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>>)+12E]) == 0;\n\tif (v149) goto L_005C;\n\tv122 = *([v226 @ X8_v5 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>>)+B0]) + 8;\n\tv122 = v122 + 0x10;\n\tv249 = v262 - 1;\n\tv231 = v262 != 1;\n\tv262 = v249;\n\tif (v231) goto L_0043;\nL_005C:\n\tv145 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>::get_Count(v139);\n\tv76 = v156 < v145;\n\tif (v76) goto L_007D;\n\tgoto L_00F0;\nL_006B:\n\tv72 = *([v122 @ X10_v19]) << 4;\n\tv276 = v226 + v72;\n\tv277 = v276 + 0x138;\n\t*([v277 @ X0_v23])(v146, v139, *([v277 @ X0_v23+8]), v136, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv77 = v156 >= v146;\n\tif (v77) goto L_00F0;\nL_007D:\n\tv297 = this._visualHandlers;\n\tv300 = *([v297 @ X22_v5 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>)]);\n\tv364 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>>)+12E]);\n\tv302 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>>)+12E]) == 0;\n\tif (v302) goto L_00A6;\n\tv325 = *([v300 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>>)+B0]) + 8;\n\tv325 = v325 + 0x10;\n\tv351 = v364 - 1;\n\tv341 = v364 != 1;\n\tv364 = v351;\n\tif (v341) goto L_008C;\nL_00A6:\n\tv386 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>::get_Item(v297, v156);\n\tv367 = v386 == 0;\n\tv335 = ~v367;\n\tif (v335) goto L_00B7;\n\tgoto L_00E4;\nL_00AC:\n\tv305 = *([v325 @ X10_v14]) << 4;\n\tv369 = v300 + v305;\n\tv370 = v369 + 0x138;\n\t*([v370 @ X0_v16])(v386, v297, v156, *([v370 @ X0_v16+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00B7:\n\tv390 = *([v386 @ X0_v7]);\n\tv419 = *([v390 @ X8_v10+12E]);\n\tv392 = *([v390 @ X8_v10+12E]) == 0;\n\tif (v392) goto L_0030;\n\tv203 = *([v390 @ X8_v10+B0]) + 8;\n\tv203 = v203 + 0x10;\n\tv406 = v419 - 1;\n\tv395 = v419 != 1;\n\tv419 = v406;\n\tif (v395) goto L_00C2;\n\tgoto L_0030;\nL_00D7:\n\tv424 = *([v203 @ X10_v8]) + 2;\n\tv173 = v424 << 4;\n\tv425 = v390 + v173;\n\tv222 = v425 + 0x138;\n\tv136 = *([v222 @ X8_v12+8]);\n\t*([v222 @ X8_v12])(v216, v386, from, *([v222 @ X8_v12+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv156 = v156 + 1;\n\tv139 = this._visualHandlers;\n\tv426 = this._visualHandlers == 0;\n\tv219 = ~v426;\n\tif (v219) goto L_0038;\nL_00E4:\n\tthrow System.NullReferenceException;\nL_00F0:\n\treturn;\nL_001F:\n\tv139 = this._visualHandlers;\n\tv53 = this._visualHandlers == 0;\n\tif (v53) goto L_00F0;\nL_0043:\n\tv267 = *([v122 @ X10_v19-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>;\n\tif (v267) goto L_006B;\nL_008C:\n\tv317 = *([v325 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler>;\n\tif (v317) goto L_00AC;\nL_00C2:\n\tv191 = *([v203 @ X10_v8-8]) == _game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler;\n\tif (v191) goto L_00D7;\n")]
		private void OnHistoryRestored(EntityManager from)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcileTick_Editor::OnHistoryRestored");
		}

		[Token(Token = "0x6000D22")]
		[Address(RVA = "0x3EEA928", Offset = "0x3EEA928", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv52 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.EntityManager>::.ctor(v52, this, Il2CppMethodInfo);\n\t_game.CoreSystem.New.Shared.EditMode.EditorHistory::remove_Restored(this.History, v52);\n\treturn;\nL_0038:\n\treturn;\nL_0018:\n\tv44 = this.History == 0;\n\tif (v44) goto L_0038;\n")]
		private void OnDestroy()
		{
			if (History != null)
			{
				Action<EntityManager> value = OnHistoryRestored;
				History.remove_Restored(value);
			}
		}

		[Token(Token = "0x6000D23")]
		[Address(RVA = "0x3EEA9C8", Offset = "0x3EEA9C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MoldReconcileTick_Editor()
		{
		}
	}
}
