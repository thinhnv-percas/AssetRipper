using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.Extensions;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.MoldSystem.Components;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.ECS;
using _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.LevelData;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.Shared.Components.Tags;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.MoldSystem.Core.Handlers
{
	[Token(Token = "0x20002F8")]
	public class MoldEntitySystemCreator
	{
		[Inject(false)]
		[Token(Token = "0x4000923")]
		[FieldOffset(Offset = "0x10")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x4000924")]
		[FieldOffset(Offset = "0x18")]
		private MoldGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x4000925")]
		[FieldOffset(Offset = "0x20")]
		private MoldFillHandler _fillHandler;

		[Inject(false)]
		[Token(Token = "0x4000926")]
		[FieldOffset(Offset = "0x28")]
		private MoldLinkedHandler _linkedHandler;

		[Inject(false)]
		[Token(Token = "0x4000927")]
		[FieldOffset(Offset = "0x30")]
		private GridData<MoldCellData> _gridData;

		[Inject(false)]
		[Token(Token = "0x6000D24")]
		[Address(RVA = "0x3EEA9D0", Offset = "0x3EEA9D0", Length = "0x630")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0045;\n\tv82 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v63, 0);\n\tv304 = this._gridData;\n\tv237 = v304.rows | v304.columns;\n\tv261 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v82, v237);\n\tv262 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v261, 0xA);\n\tv472 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v262.Entity);\n\tv143 = v472.columns < 1;\n\tif (v143) goto L_FFFFFFFF;\n\tv491 = v472 - 1;\n\tv509 = v491 < 0;\n\tv494 = v472 ^ 1;\n\tv495 = v472 ^ v491;\n\tv496 = v494 & v495;\n\tv504 = v496 < 0;\n\tgoto L_0094;\nL_FFFFFFFF:\n\tv504 = 0;\nL_FFFFFFFF:\n\tv509 = 1;\nL_009C:\n\tv264 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v330._em);\n\tv611 = *([v264 @ X0_v66 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv661 = *([v611 @ X8_v75 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv588 = *([v611 @ X8_v75 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\nL_FFFFFFFF:\n\tv604 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\nL_FFFFFFFF:\n\tv606 = 0;\nL_FFFFFFFF:\n\tv259 = 0;\n\tif (v588) goto L_00C8;\nL_00AA:\n\t;\n\tv660 = *([v611 @ X8_v75 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv660 = v660 + 0x10;\n\tv639 = v661 - 1;\n\tv619 = v661 != 1;\nL_FFFFFFFF:\n\tv259 = v606;\nL_FFFFFFFF:\n\tv661 = v639;\n\tif (v619) goto L_00AC;\nL_00C8:\n\t;\n\tv674 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v264);\n\tv685 = v259 < v674;\n\tif (v685) goto L_00EF;\n\tgoto L_0131;\nL_00D8:\n\t;\n\tv688 = *([v660 @ X10_v16]) << 4;\n\tv689 = v611 + v688;\n\tv690 = v689 + 0x138;\n\t*([v690 @ X0_v82])(v694, v264, *([v690 @ X0_v82+8]), v603, v201, v513, v40, v41, v42, v89, v44, v45, v46, v47, v48, v49, v50);\n\tv704 = v606 >= v694;\nL_FFFFFFFF:\n\tv259 = v606;\n\tif (v704) goto L_0131;\nL_00EF:\n\tgoto L_0116;\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldLinkedHandler::InitEntity(v330._linkedHandler, v809);\n\tv606 = v259 + 1;\n\tv611 = *([v264 @ X0_v66 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv661 = *([v611 @ X8_v75 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv819 = *([v611 @ X8_v75 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tv610 = ~v819;\nL_FFFFFFFF:\n\tv603 = 0;\nL_FFFFFFFF:\n\tv604 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v610) goto L_00AA;\nL_FFFFFFFF:\n\tv259 = v606;\n\tgoto L_00C8;\nL_0131:\n\treturn;\nL_0135:\n\tv130 = v472 & 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv89 = v87;\nL_FFFFFFFF:\n\tv513 = v91;\nL_FFFFFFFF:\n\tv527 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv529 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv563 = 0;\nL_FFFFFFFF:\n\tv538 = this;\n\tgoto L_FFFFFFFF;\nL_0138:\n\tv563 = v579 + 1;\n\tv523 = v563 == v472.columns;\nL_FFFFFFFF:\n\tv201 = v527;\nL_FFFFFFFF:\n\tv603 = v529;\nL_FFFFFFFF:\n\tv330 = v538;\n\tif (v523) goto L_009C;\nL_FFFFFFFF:\n\tv115 = 0;\nL_FFFFFFFF:\n\tv579 = v563;\nL_FFFFFFFF:\n\tv327 = v563;\n\tgoto L_015A;\nL_014C:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v255._em, v268.Entity, 0xA);\nL_FFFFFFFF:\n\tv513 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv527 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv529 = 0xA;\nL_FFFFFFFF:\n\tv579 = v563;\nL_FFFFFFFF:\n\tv538 = this;\nL_015A:\n\tv310 = v538._gridData;\n\tv311 = v310.cells;\n\tv119 = v311[v327 @ X20_v7 (System.Int32)];\n\tv729 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty(v119.components);\n\tv761 = v729 == 0;\n\tv762 = ~v761;\n\tif (v762) goto L_014E;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v98 @ stack_-70_v7 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v579, v115);\n\tv815 = _game.CoreSystem.LevelCreator.MoldCellData::TryGetComponent(v311[v327 @ X20_v7 (System.Int32)], &v56 @ stack_-78_v1 (_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.LevelData.HammerCellData));\n\tv266 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v266, v538._em);\n\tv821 = v815 == 0;\n\tif (v821) goto L_01CC;\n\tv267 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v266, 0);\n\tv268 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v267, 0);\n\tv255 = this._gridHandler;\n\tgoto L_01BF;\nL_01BF:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v255._em, v268.Entity, v98);\n\tv858 = v255._em == 0;\n\tv292 = ~v858;\n\tif (v292) goto L_014C;\n\tgoto L_023A;\nL_01CC:\n\tv270 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v266, 0);\n\tv271 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v270, 0);\n\tv257 = this._gridHandler;\n\tgoto L_01F5;\nL_01F5:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v257._em, v271.Entity, v98);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v257._em, v271.Entity, 0xA);\n\tgoto L_0217;\n\tv888 = _game.CoreSystem.LevelCreator.MoldCellData::GetComponent(v311[v327 @ X20_v7 (System.Int32)]);\n\tv897 = v888 == 0;\n\tif (v897) goto L_022C;\n\tv89 = v888.amount;\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::InitEntity(this._fillHandler, v271.Entity, v879.gameColor, v888.amount);\nL_022C:\n\tv794 = _game.CoreSystem.LevelCreator.MoldCellData::TryGetComponent(v311[v327 @ X20_v7 (System.Int32)], &v58 @ stack_-80_v1 (_game.CoreSystem.MoldSystem.Components.HiddenMoldComponent));\n\tv795 = ~v794;\nL_FFFFFFFF:\n\tv513 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv527 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv529 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv579 = v563;\nL_FFFFFFFF:\n\tv538 = this;\n\tif (v795) goto L_014E;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v271.Entity, 0);\nL_FFFFFFFF:\n\tv513 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv527 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv529 = 0;\nL_FFFFFFFF:\n\tv579 = v563;\nL_FFFFFFFF:\n\tv538 = this;\n\tgoto L_014E;\nL_023A:\n\tv337 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0045:\n\tv56 = 0;\n\tv58 = 0;\n\tv63 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v63, this._em);\nL_0094:\n\tv146 = v509 == v504;\nL_FFFFFFFF:\n\tv201 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv603 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv330 = this;\n\tif (v146) goto L_0135;\nL_00AC:\n\t;\n\tv666 = *([v660 @ X10_v16-8]) == v604;\n\tif (v666) goto L_00D8;\nL_0116:\n\tv809 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v264, v259);\nL_014E:\n\tv115 = v115 + 1;\n\tv327 = v327 + v472.columns;\n\tv575 = v130 == v115;\n\tif (v575) goto L_0138;\nL_0217:\n\tv879 = _game.CoreSystem.LevelCreator.MoldCellData::GetComponent(v311[v327 @ X20_v7 (System.Int32)]);\n\tv882 = v879 == 0;\n\tif (v882) goto L_022C;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldEntitySystemCreator::Construct");
		}

		[Token(Token = "0x6000D25")]
		[Address(RVA = "0x3EEB000", Offset = "0x3EEB000", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = columns * row;\n\treturnVal1 = col + v0;\n\treturn returnVal1;\n")]
		private int GetIndex(int col, int row, int columns)
		{
			int num = columns * row;
			return col + num;
		}

		[Token(Token = "0x6000D26")]
		[Address(RVA = "0x3EEB384", Offset = "0x3EEB384", Length = "0x304")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv56.<>4__this = this;\n\tv56.coord = coord;\n\tv56.coord.IsValid = coord.IsValid;\n\tv104 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v104, this._em);\n\tv105 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v104, 0);\n\tv106 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v105, 0);\n\tv90 = this._gridHandler;\n\tgoto L_0084;\nL_0084:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v90._em, v106.Entity, v56.coord);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v90._em, v106.Entity, 0xA);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v106.Entity, v56.coord);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v106.Entity, 0);\n\tv244 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv246 = new System.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>();\n\tSystem.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>::.ctor(v246, v56, Il2CppMethodInfo);\n\tv250 = System.Linq.Enumerable::FirstOrDefault(v244, v246);\n\tv251 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v250);\n\tv252 = ~v251;\n\tif (v252) goto L_00E1;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v250, v106.Entity);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v250, 1);\nL_00E1:\n\treturn v106.Entity;\nL_003F:\n\tv56 = new _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldEntitySystemCreator+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v56);\n")]
		public Entity CreateHammer(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldEntitySystemCreator::CreateHammer");
			return default;
		}

		[Token(Token = "0x6000D27")]
		[Address(RVA = "0x3EEB690", Offset = "0x3EEB690", Length = "0x3C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004C;\n\tv62.<>4__this = this;\n\tv62.coord = coord;\n\tv62.coord.IsValid = coord.IsValid;\n\tv119 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v119, this._em);\n\tv120 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v119, 0);\n\tv121 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(v120, 0);\n\tv100 = this._gridHandler;\n\tgoto L_0091;\nL_0091:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v100._em, v121.Entity, v62.coord);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(v100._em, v121.Entity, 0xA);\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler::InitEntity(this._fillHandler, v121.Entity, color, amount);\n\t_game.CoreSystem.New.MoldSystem.Core.Handlers.MoldLinkedHandler::InitEntity(this._linkedHandler, v121.Entity);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v121.Entity, v62.coord);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v121.Entity, 0);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v121.Entity, 0);\n\tv288 = v62.coord.y == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_00D8;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v121.Entity, 0);\nL_00D8:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, v121.Entity, 0);\n\tv304 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv306 = new System.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>();\n\tSystem.Func`2<_game.BaseLayerSystems.EntitySystem.Core.Entity, System.Boolean>::.ctor(v306, v62, Il2CppMethodInfo);\n\tv310 = System.Linq.Enumerable::FirstOrDefault(v304, v306);\n\tv311 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v310);\n\tv312 = ~v311;\n\tif (v312) goto L_011B;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v310, v121.Entity);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, v310, 1);\nL_011B:\n\treturn v121.Entity;\nL_004C:\n\tv62 = new _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldEntitySystemCreator+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v62);\n")]
		public Entity CreateMold(GridCoord coord, GameColor color, float amount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldEntitySystemCreator::CreateMold");
			return default;
		}

		[Token(Token = "0x6000D28")]
		[Address(RVA = "0x3EEBC0C", Offset = "0x3EEBC0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldEntitySystemCreator()
		{
		}
	}
}
