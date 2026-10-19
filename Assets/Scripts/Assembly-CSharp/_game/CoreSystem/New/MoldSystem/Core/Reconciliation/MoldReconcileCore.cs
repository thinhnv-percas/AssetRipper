using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.Mechanics.Hammer;

namespace _game.CoreSystem.New.MoldSystem.Core.Reconciliation
{
	[Token(Token = "0x20002E1")]
	public class MoldReconcileCore
	{
		[Token(Token = "0x40008D1")]
		[FieldOffset(Offset = "0x10")]
		private readonly IMoldCmdProcessor _cmdProcessor;

		[Token(Token = "0x40008D2")]
		[FieldOffset(Offset = "0x18")]
		private readonly MoldReconcile_RespCleanupSystem _respCleanup;

		[Token(Token = "0x40008D3")]
		[FieldOffset(Offset = "0x20")]
		private readonly MoldReconcile_DataCascadeSystem _dataCascade;

		[Token(Token = "0x40008D4")]
		[FieldOffset(Offset = "0x28")]
		private readonly HammerReconcile_FireSystem _hammerFire;

		[Token(Token = "0x40008D5")]
		[FieldOffset(Offset = "0x30")]
		private readonly MoldReconcile_LinkedResolveSystem _linkedResolve;

		[Token(Token = "0x40008D6")]
		[FieldOffset(Offset = "0x38")]
		private readonly MoldReconcile_RevealSystem _reveal;

		[Token(Token = "0x40008D7")]
		[FieldOffset(Offset = "0x40")]
		private readonly MoldReconcile_MaterialSystem _material;

		[Token(Token = "0x40008D8")]
		[FieldOffset(Offset = "0x48")]
		private readonly MoldReconcile_ShiftSystem _shift;

		[Token(Token = "0x40008D9")]
		[FieldOffset(Offset = "0x50")]
		private readonly MoldReconcile_CoverSystem _cover;

		[Token(Token = "0x40008DA")]
		[FieldOffset(Offset = "0x58")]
		private readonly MoldReconcile_FillTextSystem _fillText;

		[Token(Token = "0x40008DB")]
		[FieldOffset(Offset = "0x60")]
		private readonly MoldReconcile_CompleteSystem _complete;

		[Token(Token = "0x6000CAB")]
		[Address(RVA = "0x3EDD204", Offset = "0x3EDD204", Length = "0x388")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\n\tSystem.Object::.ctor(v80);\n\tv80._em = em;\n\tv80._linkedHandler = linkedHandler;\n\tthis._respCleanup = v80;\n\tv111 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_DataCascadeSystem();\n\tSystem.Object::.ctor(v111);\n\tv111._em = em;\n\tv111._gridHandler = gridHandler;\n\tthis._dataCascade = v111;\n\tv132 = new _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.HammerReconcile_FireSystem();\n\tSystem.Object::.ctor(v132);\n\tv132._em = em;\n\tv132._gridHandler = gridHandler;\n\tthis._hammerFire = v132;\n\tv148 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_LinkedResolveSystem();\n\tSystem.Object::.ctor(v148);\n\tv148._em = em;\n\tv148._linkedHandler = linkedHandler;\n\tthis._linkedResolve = v148;\n\tv166 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RevealSystem();\n\tSystem.Object::.ctor(v166);\n\tv166._em = em;\n\tthis._reveal = v166;\n\tv180 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_MaterialSystem();\n\tSystem.Object::.ctor(v180);\n\tv180._em = em;\n\tthis._material = v180;\n\tv194 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_ShiftSystem();\n\tSystem.Object::.ctor(v194);\n\tv194._em = em;\n\tthis._shift = v194;\n\tv208 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_CoverSystem();\n\tSystem.Object::.ctor(v208);\n\tv208._em = em;\n\tthis._cover = v208;\n\tv222 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_FillTextSystem();\n\tSystem.Object::.ctor(v222);\n\tv222._em = em;\n\tthis._fillText = v222;\n\tv236 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_CompleteSystem();\n\tSystem.Object::.ctor(v236);\n\tv236._em = em;\n\tthis._complete = v236;\n\treturn;\nL_0043:\n\tSystem.Object::.ctor(this);\n\tthis._cmdProcessor = cmdProcessor;\n\tv80 = new _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem();\n")]
		public MoldReconcileCore(EntityManager em, MoldLinkedHandler linkedHandler, MoldGridHandler gridHandler, IMoldCmdProcessor cmdProcessor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcileCore::.ctor");
		}

		[Token(Token = "0x6000CAC")]
		[Address(RVA = "0x3EDD7B4", Offset = "0x3EDD7B4", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv52 = *([v47 @ X20_v2 (_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor)]);\n\tv192 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor>)+12E]);\n\tv54 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor>)+12E]) == 0;\n\tif (v54) goto L_003F;\n\tv118 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor>)+B0]) + 8;\n\tv118 = v118 + 0x10;\n\tv180 = v192 - 1;\n\tv170 = v192 != 1;\n\tv192 = v180;\n\tif (v170) goto L_0028;\nL_003F:\n\t;\n\tv132 = _game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor::Tick(v47, *([v182 @ X0_v29+8]));\n\tv162 = this._respCleanup;\n\tv195 = this._respCleanup == 0;\n\tv143 = ~v195;\n\tif (v143) goto L_0056;\n\tgoto L_00C4;\nL_0049:\n\tv123 = *([v118 @ X10_v12]) + 1;\n\tv62 = v123 << 4;\n\tv251 = v52 + v62;\n\tv252 = v251 + 0x138;\n\t*([v252 @ X0_v32])(v133, v47, *([v252 @ X0_v32+8]), v31, v32, v33, v34, v35, v36, dt, v37, v38, v39, v40, v41, v42, v43);\n\tv162 = this._respCleanup;\nL_0056:\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem::ProcessMaterialApplied(v162);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem::ProcessCoverOpened(v162);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem::ProcessCoverClosed(v162);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem::ProcessShiftDone(v162);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem::ProcessRevealDone(v162);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem::ProcessLinkedResolveDone(v162);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RespCleanupSystem::ProcessCompleteDone(v162);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_DataCascadeSystem::Execute(this._dataCascade);\n\t_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.HammerReconcile_FireSystem::Execute(this._hammerFire);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_LinkedResolveSystem::BreakLinksOnFill(this._linkedResolve);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_LinkedResolveSystem::ResolveLinksAtFront(this._linkedResolve);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RevealSystem::ClearHiddenAtFront(this._reveal);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_RevealSystem::IssueRevealCommands(this._reveal);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_MaterialSystem::Execute(this._material);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_ShiftSystem::Execute(this._shift);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_CoverSystem::Execute(this._cover);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_FillTextSystem::Execute(this._fillText);\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcile_CompleteSystem::Execute(this._complete);\n\tgoto L_00C3;\nL_00C4:\n\tthrow System.NullReferenceException;\nL_0017:\n\tv47 = this._cmdProcessor;\nL_0028:\n\tv98 = *([v118 @ X10_v12-8]) == _game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor;\n\tif (v98) goto L_0049;\nL_00C3:\n\t_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor::ProcessCommands(this._cmdProcessor);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Tick(float dt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldReconcileCore::Tick");
		}
	}
}
