using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.IdentifierTags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Wall.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Core.Handlers
{
	[Token(Token = "0x2000277")]
	public class TopGridHandler
	{
		[CompilerGenerated]
		[Token(Token = "0x2000278")]
		private sealed class _003CGetEntitiesAt_003Ed__39 : IEnumerable<Entity>, IEnumerable, IEnumerator<Entity>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40007DE")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40007DF")]
			[FieldOffset(Offset = "0x14")]
			private Entity _003C_003E2__current;

			[Token(Token = "0x40007E0")]
			[FieldOffset(Offset = "0x1C")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x40007E1")]
			[FieldOffset(Offset = "0x20")]
			public TopGridHandler _003C_003E4__this;

			[Token(Token = "0x40007E2")]
			[FieldOffset(Offset = "0x28")]
			private GridCoord coord;

			[Token(Token = "0x40007E3")]
			[FieldOffset(Offset = "0x34")]
			public GridCoord _003C_003E3__coord;

			[Token(Token = "0x40007E4")]
			[FieldOffset(Offset = "0x40")]
			private Entity _003CnoPlace_003E5__2;

			[Token(Token = "0x170000CB")]
			Entity IEnumerator<Entity>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000B17")]
				[Address(RVA = "0x3EC4874", Offset = "0x3EC4874", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170000CC")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000B19")]
				[Address(RVA = "0x3EC48BC", Offset = "0x3EC48BC", Length = "0x68")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = this.<>2__current;\n\t// 26 Box returnVal1 @ X0_v3 (System.Object), typeof(_game.BaseLayerSystems.EntitySystem.Core.Entity), &v45 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity)\n\treturn returnVal1;\n")]
				get
				{
					Entity entity = _003C_003E2__current;
					return entity;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000B14")]
			[Address(RVA = "0x3EC3670", Offset = "0x3EC3670", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetEntitiesAt_003Ed__39(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000B15")]
			[Address(RVA = "0x3EC402C", Offset = "0x3EC402C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000B16")]
			[Address(RVA = "0x3EC4030", Offset = "0x3EC4030", Length = "0x844")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv73 = this.<>1__state > 7;\n\tif (v73) goto L_008F;\n\tv90 = this.<>1__state == 5;\n\tif (v90) goto L_01ED;\n\tv118 = this.<>1__state == 6;\n\tif (v118) goto L_0138;\n\tv168 = this.<>1__state != 7;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v168) goto L_031C;\n\tthis.<>1__state = -1;\n\tv594 = v49 == 0;\n\tv434 = ~v594;\n\tif (v434) goto L_025E;\n\tgoto L_0335;\nL_0064:\n\tv85 = this.<>1__state <= 1;\n\tif (v85) goto L_00AC;\n\tv108 = this.<>1__state == 2;\n\tif (v108) goto L_0144;\n\tv140 = this.<>1__state == 3;\n\tif (v140) goto L_0132;\n\tv322 = this.<>1__state != 4;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v322) goto L_031C;\n\tthis.<>1__state = -1;\n\tv636 = v49 == 0;\n\tv435 = ~v636;\n\tif (v435) goto L_01B5;\n\tgoto L_0335;\nL_008F:\n\tv99 = this.<>1__state == 8;\n\tif (v99) goto L_0296;\n\tv129 = this.<>1__state == 9;\n\tif (v129) goto L_013E;\n\tv514 = this.<>1__state != 0xA;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v514) goto L_031C;\nL_FFFFFFFF:\n\treturnVal3 = 0;\nL_FFFFFFFF:\n\tv719 = -1;\n\tgoto L_032A;\nL_00AC:\n\tv113 = this.<>1__state == 0;\n\tif (v113) goto L_00C0;\n\tv156 = this.<>1__state != 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v156) goto L_031C;\n\tthis.<>1__state = -1;\n\tv550 = v49 == 0;\n\tv436 = ~v550;\n\tif (v436) goto L_00FA;\n\tgoto L_0335;\nL_00C0:\n\tthis.<>1__state = -1;\n\tv298 = this.coord;\n\tgoto L_00D3;\n\tv359 = this.coord << 0x20;\n\tv270 = v298.y | v359;\n\tv839 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._sandCubeByCoord, v270, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv299 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_00F1;\nL_00F1:\n\tv783 = *([v299 @ X22_v54]);\n\tv664 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v299 @ X22_v54]));\n\tv666 = v664 == 0;\n\tif (v666) goto L_00FA;\nL_FFFFFFFF:\n\tv719 = 1;\n\tgoto L_0328;\nL_00FA:\n\tv300 = this.coord;\n\tgoto L_010A;\n\tv361 = this.coord << 0x20;\n\tv272 = v300.y | v361;\n\tv891 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._wallByCoord, v272, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv301 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_0128;\nL_0128:\n\tv783 = *([v301 @ X22_v50]);\n\tv540 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v301 @ X22_v50]));\n\tv542 = v540 == 0;\n\tif (v542) goto L_0147;\nL_FFFFFFFF:\n\tv719 = 2;\n\tgoto L_0328;\nL_0132:\n\tthis.<>1__state = -1;\n\tv533 = v49 == 0;\n\tv437 = ~v533;\n\tif (v437) goto L_017E;\n\tgoto L_0335;\nL_0138:\n\tthis.<>1__state = -1;\n\tv170 = v49 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0227;\n\tgoto L_0335;\nL_013E:\n\tthis.<>1__state = -1;\n\tv515 = v49 == 0;\n\tv438 = ~v515;\n\tif (v438) goto L_02D0;\n\tgoto L_0335;\nL_0144:\n\tthis.<>1__state = -1;\nL_0147:\n\tv302 = this.coord;\n\tgoto L_0157;\n\tv363 = this.coord << 0x20;\n\tv274 = v302.y | v363;\n\tv826 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._tunnelByCoord, v274, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv303 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_0175;\nL_0175:\n\tv783 = *([v303 @ X22_v45]);\n\tv643 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v303 @ X22_v45]));\n\tv645 = v643 == 0;\n\tif (v645) goto L_017E;\nL_FFFFFFFF:\n\tv719 = 3;\n\tgoto L_0328;\nL_017E:\n\tv304 = this.coord;\n\tgoto L_018E;\n\tv365 = this.coord << 0x20;\n\tv276 = v304.y | v365;\n\tv880 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._keyByCoord, v276, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv305 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_01AC;\nL_01AC:\n\tv783 = *([v305 @ X22_v40]);\n\tv804 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v305 @ X22_v40]));\n\tv806 = v804 == 0;\n\tif (v806) goto L_01B5;\nL_FFFFFFFF:\n\tv719 = 4;\n\tgoto L_0328;\nL_01B5:\n\tv306 = this.coord;\n\tgoto L_01C5;\n\tv196 = this.coord << 0x20;\n\tv278 = v306.y | v196;\n\tv936 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._lockByCoord, v278, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv184 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_01E3;\nL_01E3:\n\tv783 = *([v184 @ X22_v35]);\n\tv206 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v184 @ X22_v35]));\n\tv208 = v206 == 0;\n\tif (v208) goto L_01F0;\nL_FFFFFFFF:\n\tv719 = 5;\n\tgoto L_0328;\nL_01ED:\n\tthis.<>1__state = -1;\nL_01F0:\n\tv213 = this.coord;\n\tgoto L_0200;\n\tv367 = this.coord << 0x20;\n\tv279 = v213.y | v367;\n\tv759 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._garageCoverByCoord, v279, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv307 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_021E;\nL_021E:\n\tv783 = *([v307 @ X22_v30]);\n\tv601 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v307 @ X22_v30]));\n\tv603 = v601 == 0;\n\tif (v603) goto L_0227;\nL_FFFFFFFF:\n\tv719 = 6;\n\tgoto L_0328;\nL_0227:\n\tv308 = this.coord;\n\tgoto L_0237;\n\tv369 = this.coord << 0x20;\n\tv281 = v308.y | v369;\n\tv852 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._hammerAreaCoverByCoord, v281, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv309 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_0255;\nL_0255:\n\tv783 = *([v309 @ X22_v25]);\n\tv737 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v309 @ X22_v25]));\n\tv739 = v737 == 0;\n\tif (v739) goto L_025E;\nL_FFFFFFFF:\n\tv719 = 7;\n\tgoto L_0328;\nL_025E:\n\tv310 = this.coord;\n\tgoto L_026E;\n\tv371 = this.coord << 0x20;\n\tv283 = v310.y | v371;\n\tv902 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._pinByCoord, v283, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv311 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_028C;\nL_028C:\n\tv783 = *([v311 @ X22_v20]);\n\tv522 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v311 @ X22_v20]));\n\tv524 = v522 == 0;\n\tif (v524) goto L_0299;\nL_FFFFFFFF:\n\tv719 = 8;\n\tgoto L_0328;\nL_0296:\n\tthis.<>1__state = -1;\nL_0299:\n\tv312 = this.coord;\n\tgoto L_02A9;\n\tv373 = this.coord << 0x20;\n\tv792 = v312.y | v373;\n\tv797 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._noPlaceByCoord, v792, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv313 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_02C5;\n\tv622 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v313 @ X22_v15]));\n\tv624 = ~v622;\n\tif (v624) goto L_02D0;\n\tv783 = this.<noPlace>5__2;\nL_FFFFFFFF:\n\tv719 = 9;\n\tgoto L_0328;\nL_02D0:\n\tv314 = this.coord;\n\tgoto L_02E0;\n\tv375 = this.coord << 0x20;\n\tv861 = v314.y | v375;\n\tv864 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(v49._noPlaceWallByCoord, v861, &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\nL_FFFFFFFF:\n\tv315 = &v225 @ stack_-48_v14 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_0301;\nL_0301:\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v49._em, *([v315 @ X22_v10]));\n\tv577 = ~returnVal1;\n\tif (v577) goto L_031C;\n\tgoto L_030E;\nL_030E:\n\tv1083 = _game.BaseLayerSystems.EntitySystem.Core.Entity::Equals(&v1080 @ stack_-50_v10 (_\n// ... truncated")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler._003CGetEntitiesAt_003Ed__39::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000B18")]
			[Address(RVA = "0x3EC487C", Offset = "0x3EC487C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000B1A")]
			[Address(RVA = "0x3EC4924", Offset = "0x3EC4924", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\tv97 = this;\n\tgoto L_0042;\nL_0033:\n\tv76 = new _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler+<GetEntitiesAt>d__39();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\tv76.<>4__this = this.<>4__this;\n\tv97 = v76;\nL_0042:\n\tv97.coord.IsValid = this.<>3__coord.IsValid;\n\tv97.coord = this.<>3__coord;\n\treturn v97;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\n")]
			IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
			{
				_003CGetEntitiesAt_003Ed__39 _003CGetEntitiesAt_003Ed__40;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CGetEntitiesAt_003Ed__40 = this;
						goto IL_00a2;
					}
				}
				_003CGetEntitiesAt_003Ed__39 _003CGetEntitiesAt_003Ed__41 = (_003CGetEntitiesAt_003Ed__39)FormatterServices.GetUninitializedObject(typeof(_003CGetEntitiesAt_003Ed__39));
				_003CGetEntitiesAt_003Ed__41._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetEntitiesAt_003Ed__41._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetEntitiesAt_003Ed__41._003C_003E4__this = _003C_003E4__this;
				_003CGetEntitiesAt_003Ed__40 = _003CGetEntitiesAt_003Ed__41;
				goto IL_00a2;
				IL_00a2:
				_003CGetEntitiesAt_003Ed__40.coord.IsValid = _003C_003E3__coord.IsValid;
				_003CGetEntitiesAt_003Ed__40.coord = _003C_003E3__coord;
				return _003CGetEntitiesAt_003Ed__40;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000B1B")]
			[Address(RVA = "0x3EC49DC", Offset = "0x3EC49DC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler+<GetEntitiesAt>d__39::System.Collections.Generic.IEnumerable<_game.BaseLayerSystems.EntitySystem.Core.Entity>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Entity>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x40007CC")]
		public const uint GRID_ID = 11u;

		[Inject(false)]
		[Token(Token = "0x40007CD")]
		[FieldOffset(Offset = "0x10")]
		internal EntityManager _em;

		[Inject(true)]
		[Token(Token = "0x40007CE")]
		[FieldOffset(Offset = "0x18")]
		private TempTopGridVisualHolder _holder;

		[Token(Token = "0x40007CF")]
		[FieldOffset(Offset = "0x20")]
		internal ComponentPoolWithInterface<GridPositionComponent> _gridPosPool;

		[Token(Token = "0x40007D0")]
		[FieldOffset(Offset = "0x28")]
		internal readonly Dictionary<long, Entity> _sandCubeByCoord;

		[Token(Token = "0x40007D1")]
		[FieldOffset(Offset = "0x30")]
		private readonly Dictionary<long, Entity> _wallByCoord;

		[Token(Token = "0x40007D2")]
		[FieldOffset(Offset = "0x38")]
		private readonly Dictionary<long, Entity> _tunnelByCoord;

		[Token(Token = "0x40007D3")]
		[FieldOffset(Offset = "0x40")]
		private readonly Dictionary<long, Entity> _keyByCoord;

		[Token(Token = "0x40007D4")]
		[FieldOffset(Offset = "0x48")]
		internal readonly Dictionary<long, Entity> _lockByCoord;

		[Token(Token = "0x40007D5")]
		[FieldOffset(Offset = "0x50")]
		private readonly Dictionary<long, Entity> _garageByCoord;

		[Token(Token = "0x40007D6")]
		[FieldOffset(Offset = "0x58")]
		internal readonly Dictionary<long, Entity> _garageCoverByCoord;

		[Token(Token = "0x40007D7")]
		[FieldOffset(Offset = "0x60")]
		private readonly Dictionary<long, Entity> _hammerAreaByCoord;

		[Token(Token = "0x40007D8")]
		[FieldOffset(Offset = "0x68")]
		private readonly Dictionary<long, Entity> _hammerAreaCoverByCoord;

		[Token(Token = "0x40007D9")]
		[FieldOffset(Offset = "0x70")]
		private readonly Dictionary<long, Entity> _gridCellByCoord;

		[Token(Token = "0x40007DA")]
		[FieldOffset(Offset = "0x78")]
		private readonly Dictionary<long, Entity> _pinByCoord;

		[Token(Token = "0x40007DB")]
		[FieldOffset(Offset = "0x80")]
		private readonly Dictionary<long, Entity> _noPlaceByCoord;

		[Token(Token = "0x40007DC")]
		[FieldOffset(Offset = "0x88")]
		private readonly Dictionary<long, Entity> _noPlaceWallByCoord;

		[Token(Token = "0x40007DD")]
		[FieldOffset(Offset = "0x90")]
		private readonly Dictionary<int, long> _coordKeyByEntity;

		[Inject(false)]
		[Token(Token = "0x6000AF0")]
		[Address(RVA = "0x3EC242C", Offset = "0x3EC242C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv43.GridHandler = this;\nL_002B:\n\tv64 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this._em);\n\tthis._gridPosPool = v64;\n\tv75 = new System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v75, this, Il2CppMethodInfo);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::add_OnEntityDestroyed(this._em, v75);\n\treturn;\nL_001A:\n\tv43 = this._holder;\n\tv44 = this._holder == 0;\n\tif (v44) goto L_002B;\n")]
		private void Construct()
		{
			TempTopGridVisualHolder holder = _holder;
			if (_holder != null)
			{
				holder.GridHandler = this;
			}
			ComponentPoolWithInterface<GridPositionComponent> pool = _em.GetPool<GridPositionComponent>();
			_gridPosPool = pool;
			Action<Entity> value = OnEntityDestroyed;
			_em.add_OnEntityDestroyed(value);
		}

		[Token(Token = "0x6000AF1")]
		[Address(RVA = "0x3EC0EE8", Offset = "0x3EC0EE8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002A:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent>::TryGet(this._gridPosPool, entity, &v61 @ stack_-50_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent));\n\tv92 = ~v63;\n\tif (v92) goto L_003E;\n\tv94 = v61 >> 0x20;\n\tv95 = v61 << 0x20;\n\tv96 = v94 | v95;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::EvictFromSpatialIndicesByKey(this, entity, v96);\nL_003E:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, coord);\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, 0xB);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InsertIntoSpatialIndices(this, entity, coord);\n\treturn;\n")]
		public void InitEntity(Entity entity, GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::InitEntity");
		}

		[Token(Token = "0x6000AF2")]
		[Address(RVA = "0x3EAC6E4", Offset = "0x3EAC6E4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv57 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent>::TryGet(this._gridPosPool, entity, &v55 @ stack_-40_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent));\n\tv81 = ~v57;\n\tif (v81) goto L_0036;\n\tv83 = v55 >> 0x20;\n\tv84 = v55 << 0x20;\n\tv85 = v83 | v84;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::EvictFromSpatialIndicesByKey(this, entity, v85);\nL_0036:\n\tv116 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv117 = ~v116;\n\tif (v117) goto L_0048;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::RemoveComponent(this._em, entity);\nL_0048:\n\treturn;\n")]
		public void ReleaseSlot(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::ReleaseSlot");
		}

		[Token(Token = "0x6000AF3")]
		[Address(RVA = "0x3EC2968", Offset = "0x3EC2968", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tv63 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent>::TryGet(this._gridPosPool, entity, &v61 @ stack_-50_v3 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent));\n\tv89 = ~v63;\n\tif (v89) goto L_003E;\n\tv93 = v61 >> 0x20;\n\tv94 = v61 << 0x20;\n\tv95 = v93 | v94;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::EvictFromSpatialIndicesByKey(this, entity, v95);\nL_003E:\n\tv134 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv135 = ~v134;\n\tif (v135) goto L_0057;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::SetComponent(this._em, entity, newCoord);\n\tgoto L_005C;\nL_0057:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, entity, newCoord);\nL_005C:\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InsertIntoSpatialIndices(this, entity, newCoord);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RelocateEntity(Entity entity, GridCoord newCoord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::RelocateEntity");
		}

		[Token(Token = "0x6000AF4")]
		[Address(RVA = "0x3EACFF0", Offset = "0x3EACFF0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this, &v16 @ stack_-30_v2 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv21 = ~v17;\n\treturnVal1 = 0;\n\tif (v21) goto L_003A;\n\tv22 = coord & 0x80000000;\n\tv23 = v22 == 0;\n\tv24 = ~v23;\n\treturnVal1 = 0;\n\tif (v24) goto L_003A;\n\tv34 = v78 <= coord;\n\treturnVal1 = 0;\n\tif (v34) goto L_003A;\n\tv82 = coord & 0x8000000000000000;\n\tv83 = v82 == 0;\n\tv68 = ~v83;\n\treturnVal1 = 0;\n\tif (v68) goto L_003A;\n\tv60 = v16 - coord.y;\n\tv56 = v60 < 0;\n\tv52 = v60 == 0;\n\tv48 = v16 ^ coord.y;\n\tv44 = v16 ^ v60;\n\tv40 = v48 & v44;\n\tv36 = v40 < 0;\n\tv85 = v56 == v36;\n\tv26 = ~v52;\n\tv32 = v85 & v26;\n\treturnVal1 = v32;\nL_003A:\n\treturn returnVal1;\n")]
		public bool IsValidCoord(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::IsValidCoord");
			return default;
		}

		[Token(Token = "0x6000AF5")]
		[Address(RVA = "0x3EC2AB8", Offset = "0x3EC2AB8", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv52 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv121 = *([v52 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv224 = *([v121 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv123 = *([v121 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v123) goto L_0054;\n\tv223 = *([v121 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv223 = v223 + 0x10;\n\tv209 = v224 - 1;\n\tv189 = v224 != 1;\n\tv224 = v209;\n\tif (v189) goto L_003B;\nL_0054:\n\treturnVal2 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v52);\n\tv238 = ~returnVal2;\n\tv239 = ~v238;\n\tif (v239) goto L_0070;\nL_005F:\n\treturn returnVal2;\nL_0061:\n\tv242 = *([v223 @ X10_v13]) << 4;\n\tv243 = v121 + v242;\n\tv244 = v243 + 0x138;\n\t*([v244 @ X0_v23])(returnVal2, v52, *([v244 @ X0_v23+8]), methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv249 = ~returnVal2;\n\tif (v249) goto L_005F;\nL_0070:\n\tgoto L_0097;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v336);\n\tv251 = ~returnVal2;\n\tif (v251) goto L_005F;\n\tv339 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v336);\n\tgrid.rows = v339;\n\tgrid.cellSize = v336;\n\treturn 1;\nL_0021:\n\tgrid.rows = 0;\n\tgrid.cellSize = 0f;\nL_003B:\n\tv229 = *([v223 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v229) goto L_0061;\nL_0097:\n\tv336 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v52, 0);\n")]
		public bool TryGetGridComponent(out GridComponent grid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::TryGetGridComponent");
			grid = default;
			return default;
		}

		[Token(Token = "0x6000AF6")]
		[Address(RVA = "0x3EC2C84", Offset = "0x3EC2C84", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv47 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv63 = *([v47 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv219 = *([v63 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv65 = *([v63 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v65) goto L_004C;\n\tv218 = *([v63 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv218 = v218 + 0x10;\n\tv204 = v219 - 1;\n\tv184 = v219 != 1;\n\tv219 = v204;\n\tif (v184) goto L_0033;\nL_004C:\n\tv232 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v47);\n\tv244 = v232 <= 0;\n\tif (v244) goto L_00A2;\nL_005D:\n\tv160 = *([v47 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv318 = *([v160 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv157 = *([v160 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v157) goto L_0087;\n\tv140 = *([v160 @ X8_v16 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv140 = v140 + 0x10;\n\tv304 = v318 - 1;\n\tv294 = v318 != 1;\n\tv318 = v304;\n\tif (v294) goto L_0068;\nL_0087:\n\tinterfaceTailCallResult = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v47, 0);\nL_0087:\n\treturn interfaceTailCallResult;\nL_0089:\n\tv247 = *([v218 @ X10_v11]) << 4;\n\tv248 = v63 + v247;\n\tv249 = v248 + 0x138;\n\t*([v249 @ X0_v22])(v253, v47, *([v249 @ X0_v22+8]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv265 = v253 > 0;\n\tif (v265) goto L_005D;\nL_00A2:\n\tgoto L_00AA;\nL_00AA:\n\treturn v161.Invalid;\nL_00AC:\n\tv78 = *([v140 @ X10_v6]) << 4;\n\tv162 = v160 + v78;\n\tv322 = v162 + 0x138;\n\tv87 = *([v322 @ X0_v16]);\n\tv91 = *([v322 @ X0_v16+8]);\n\t// 184 IndirectJump v87 @ X3_v2, v47 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), v47 @ X0_v5 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), 0, v91 @ X2_v5, v87 @ X3_v2, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0033:\n\tv224 = *([v218 @ X10_v11-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v224) goto L_0089;\nL_0068:\n\tv120 = *([v140 @ X10_v6-8]) == System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v120) goto L_00AC;\n")]
		public Entity GetGridEntity()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetGridEntity");
			return default;
		}

		[Token(Token = "0x6000AF7")]
		[Address(RVA = "0x3EAD050", Offset = "0x3EAD050", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._sandCubeByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetSandCubeAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetSandCubeAt");
			return default;
		}

		[Token(Token = "0x6000AF8")]
		[Address(RVA = "0x3EC2EE8", Offset = "0x3EC2EE8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._wallByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetWallAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetWallAt");
			return default;
		}

		[Token(Token = "0x6000AF9")]
		[Address(RVA = "0x3EC2F98", Offset = "0x3EC2F98", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._tunnelByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetTunnelAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetTunnelAt");
			return default;
		}

		[Token(Token = "0x6000AFA")]
		[Address(RVA = "0x3EC3048", Offset = "0x3EC3048", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._keyByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetKeyAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetKeyAt");
			return default;
		}

		[Token(Token = "0x6000AFB")]
		[Address(RVA = "0x3EB3698", Offset = "0x3EB3698", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._lockByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetLockAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetLockAt");
			return default;
		}

		[Token(Token = "0x6000AFC")]
		[Address(RVA = "0x3EC30F8", Offset = "0x3EC30F8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._garageByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetGarageAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetGarageAt");
			return default;
		}

		[Token(Token = "0x6000AFD")]
		[Address(RVA = "0x3EB35E8", Offset = "0x3EB35E8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._garageCoverByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetGarageCoverAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetGarageCoverAt");
			return default;
		}

		[Token(Token = "0x6000AFE")]
		[Address(RVA = "0x3EC31A8", Offset = "0x3EC31A8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._hammerAreaByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetHammerAreaAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetHammerAreaAt");
			return default;
		}

		[Token(Token = "0x6000AFF")]
		[Address(RVA = "0x3EC3258", Offset = "0x3EC3258", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._hammerAreaCoverByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetHammerAreaCoverAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetHammerAreaCoverAt");
			return default;
		}

		[Token(Token = "0x6000B00")]
		[Address(RVA = "0x3EC3308", Offset = "0x3EC3308", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._gridCellByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetCellAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetCellAt");
			return default;
		}

		[Token(Token = "0x6000B01")]
		[Address(RVA = "0x3EC33B8", Offset = "0x3EC33B8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._pinByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetPinAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetPinAt");
			return default;
		}

		[Token(Token = "0x6000B02")]
		[Address(RVA = "0x3EC3468", Offset = "0x3EC3468", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._noPlaceByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetNoPlaceAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetNoPlaceAt");
			return default;
		}

		[Token(Token = "0x6000B03")]
		[Address(RVA = "0x3EC3518", Offset = "0x3EC3518", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._noPlaceWallByCoord, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		public Entity GetNoPlaceWallAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::GetNoPlaceWallAt");
			return default;
		}

		[Token(Token = "0x6000B04")]
		[Address(RVA = "0x3EAC2E4", Offset = "0x3EAC2E4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv48 = coord << 0x20;\n\tv49 = coord.y | v48;\n\tv52 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::ContainsKey(this._sandCubeByCoord, v49);\n\tv69 = v52 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0036;\n\tv73 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::ContainsKey(this._wallByCoord, v49);\n\tv75 = v73 == 0;\n\tif (v75) goto L_0043;\nL_0036:\n\treturn 1;\nL_0043:\n\treturnVal3 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::ContainsKey(this._tunnelByCoord, v49);\n\treturn returnVal3;\n")]
		public bool HasPrimaryAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::HasPrimaryAt");
			return default;
		}

		[IteratorStateMachine(typeof(_003CGetEntitiesAt_003Ed__39))]
		[Token(Token = "0x6000B05")]
		[Address(RVA = "0x3EC35D0", Offset = "0x3EC35D0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv51.<>l__initialThreadId = v56;\n\tv51.<>4__this = this;\n\tv51.<>3__coord = coord;\n\tv51.<>3__coord.IsValid = coord.IsValid;\n\treturn v51;\nL_001C:\n\tv51 = new _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler+<GetEntitiesAt>d__39();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = -2;\n\tv56 = System.Environment::get_CurrentManagedThreadId();\n")]
		public IEnumerable<Entity> GetEntitiesAt(GridCoord coord)
		{
			_003CGetEntitiesAt_003Ed__39 _003CGetEntitiesAt_003Ed__40 = new _003CGetEntitiesAt_003Ed__39(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetEntitiesAt_003Ed__40._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetEntitiesAt_003Ed__40._003C_003E4__this = this;
			_003CGetEntitiesAt_003Ed__40._003C_003E3__coord = coord;
			_003CGetEntitiesAt_003Ed__40._003C_003E3__coord.IsValid = coord.IsValid;
			return _003CGetEntitiesAt_003Ed__40;
		}

		[Token(Token = "0x6000B06")]
		[Address(RVA = "0x3EC36A8", Offset = "0x3EC36A8", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv51 = coord & 0x80000000;\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_00A2;\n\tv129 = coord & 0x8000000000000000;\n\tv130 = v129 == 0;\n\tv105 = ~v130;\n\tif (v105) goto L_00A2;\n\tv66 = v179 <= coord;\n\tif (v66) goto L_00A2;\n\tv67 = v47 <= coord.y;\n\tif (v67) goto L_00A2;\n\tv187 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::HasPrimaryAt(this, coord);\n\tv156 = v187 == 0;\n\tif (v156) goto L_0059;\n\treturn 0;\nL_0059:\n\tgoto L_0062;\n\tv84 = coord << 0x20;\n\tv206 = coord.y | v84;\n\tv210 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._gridCellByCoord, v206, &v55 @ stack_-40_v4 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv216 = &v55 @ stack_-40_v4 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_0083;\nL_0083:\n\tv102 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, *([v216 @ X20_v6]));\n\tv106 = ~v102;\n\tif (v106) goto L_00A2;\n\tv103 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, *([v216 @ X20_v6]));\n\tv107 = v103 == 0;\n\tif (v107) goto L_00A2;\n\treturn 0;\nL_00A2:\n\treturn 1;\nL_001B:\n\tv49 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this, &v47 @ stack_-40_v2 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv50 = ~v49;\n\tif (v50) goto L_00A2;\nL_0062:\n\tv55 = 0;\n")]
		public bool IsCoordOpen(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::IsCoordOpen");
			return default;
		}

		[Token(Token = "0x6000B07")]
		[Address(RVA = "0x3EC3838", Offset = "0x3EC3838", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = coord.y - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v30 @ stack_-40_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), coord, v27);\n\tv34 = coord.y + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v33 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), coord, v34);\n\tv37 = coord - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v39 @ stack_-60_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v37, coord.y);\n\tv44 = coord + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v43 @ stack_-70_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v44, coord.y);\n\tv50 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsCoordOpen(this, v30);\n\tv52 = v50 == 0;\n\tif (v52) goto L_003A;\n\treturn 1;\nL_003A:\n\tv63 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsCoordOpen(this, v33);\n\tv73 = v63 == 0;\n\tif (v73) goto L_004A;\n\treturn 1;\nL_004A:\n\tv103 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsCoordOpen(this, v39);\n\tv74 = v103 == 0;\n\tif (v74) goto L_005A;\n\treturn 1;\nL_005A:\n\treturnVal4 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::IsCoordOpen(this, v43);\n\treturn returnVal4;\n")]
		public bool IsCubePourableByNeighbours(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::IsCubePourableByNeighbours");
			return default;
		}

		[Token(Token = "0x6000B08")]
		[Address(RVA = "0x3EB7C6C", Offset = "0x3EB7C6C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = coord.y - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v24 @ stack_-40_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), coord, v22);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryMarkSandCubeForReeval(this, v24);\n\tv33 = coord.y + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v32 @ stack_-50_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), coord, v33);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryMarkSandCubeForReeval(this, v32);\n\tv41 = coord - 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v43 @ stack_-60_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v41, coord.y);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryMarkSandCubeForReeval(this, v43);\n\tv53 = coord + 1;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v52 @ stack_-70_v2 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v53, coord.y);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryMarkSandCubeForReeval(this, v52);\n\treturn;\n")]
		public void MarkNeighborsForReeval(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::MarkNeighborsForReeval");
		}

		[Token(Token = "0x6000B09")]
		[Address(RVA = "0x3EC3ADC", Offset = "0x3EC3ADC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryMarkSandCubeForReeval(this, coord);\n\treturn;\n")]
		public void MarkSandCubeForReevalAt(GridCoord coord)
		{
			TryMarkSandCubeForReeval(coord);
		}

		[Token(Token = "0x6000B0A")]
		[Address(RVA = "0x3EC396C", Offset = "0x3EC396C", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv53 = coord & 0x80000000;\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0094;\n\tv136 = coord & 0x8000000000000000;\n\tv137 = v136 == 0;\n\tv113 = ~v137;\n\tif (v113) goto L_0094;\n\tv73 = v169 <= coord;\n\tif (v73) goto L_0094;\n\tv71 = v47 <= coord.y;\n\tif (v71) goto L_0094;\n\tgoto L_0054;\n\tv87 = coord << 0x20;\n\tv193 = coord.y | v87;\n\tv197 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(this._sandCubeByCoord, v193, &v57 @ stack_-40_v4 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv203 = &v57 @ stack_-40_v4 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_0075;\nL_0075:\n\tv109 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, *([v203 @ X20_v6]));\n\tv114 = ~v109;\n\tif (v114) goto L_0094;\n\tv110 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, *([v203 @ X20_v6]));\n\tv221 = v110 == 0;\n\tv115 = ~v221;\n\tif (v115) goto L_0094;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._em, *([v203 @ X20_v6]), 0);\nL_0094:\n\treturn;\nL_001D:\n\tv49 = _game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryGetGridComponent(this, &v47 @ stack_-40_v2 (_game.CoreSystem.New.GridEcsBinding.Components.GridComponent));\n\tv52 = ~v49;\n\tif (v52) goto L_0094;\nL_0054:\n\tv57 = 0;\n")]
		private void TryMarkSandCubeForReeval(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::TryMarkSandCubeForReeval");
		}

		[Token(Token = "0x6000B0B")]
		[Address(RVA = "0x3EC2E38", Offset = "0x3EC2E38", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv51 = coord << 0x20;\n\tv52 = coord.y | v51;\n\tv57 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(map, v52, &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv73 = &v44 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity);\n\tgoto L_003C;\nL_0019:\n\tv44 = 0;\nL_003C:\n\treturn *([v73 @ X20_v3]);\n")]
		private Entity LookupAt(Dictionary<long, Entity> map, GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::LookupAt");
			return default;
		}

		[Token(Token = "0x6000B0C")]
		[Address(RVA = "0x3EBEDB0", Offset = "0x3EBEDB0", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._sandCubeByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._wallByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._tunnelByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._keyByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._lockByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._garageByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._garageCoverByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._hammerAreaByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._hammerAreaCoverByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._gridCellByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Clear(this._pinByCoord);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int64>::Clear(this._coordKeyByEntity);\n\tv164 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(this._em);\n\tv133 = 0;\n\tgoto L_0087;\nL_0085:\n\tv133 = v133 + 1;\n\tv358 = *([v316 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+B0]) + 8;\n\tv358 = v358 + 0x10;\n\tv325 = v349 - 1;\n\tv323 = v349 != 1;\n\tv349 = v325;\n\tif (v323) goto L_008D;\nL_00A9:\n\t;\n\tv371 = System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Count(v164);\n\tv382 = v133 < v371;\n\tif (v382) goto L_00D0;\n\tgoto L_0137;\nL_00B9:\n\t;\n\tv385 = *([v358 @ X10_v14]) << 4;\n\tv386 = v316 + v385;\n\tv387 = v386 + 0x138;\n\t*([v387 @ X0_v41])(v391, v164, *([v387 @ X0_v41+8]), v285, v283, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv401 = v133 >= v391;\n\tif (v401) goto L_0137;\nL_00D0:\n\tgoto L_00F7;\n\tv483 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this._em, v482);\n\tv484 = ~v483;\n\tv285 = 0;\n\tif (v484) goto L_0085;\n\tv489 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, v482);\n\tv492 = ~v489;\n\tv285 = Il2CppMethodInfo;\n\tif (v492) goto L_0085;\n\tv490 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v482);\n\tv83 = v490 != 0xB;\n\tv285 = Il2CppMethodInfo;\n\tif (v83) goto L_0085;\n\tv497 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(this._em, v482);\n\tv493 = v482 & 0xFFFFFFFF;\n\tv499 = v283 & 0xFFFFFFFF00000000;\n\tv283 = v499 | v493;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::InsertIntoSpatialIndices(this, v482, v497);\n\tv285 = v497;\n\tgoto L_0085;\nL_0137:\n\treturn;\nL_0087:\n\tv316 = *([v164 @ X0_v17 (System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)]);\n\tv349 = *([v316 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]);\n\tv252 = *([v316 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>>)+12E]) == 0;\n\tif (v252) goto L_00A9;\nL_008D:\n\t;\n\tv363 = *([v358 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>;\n\tif (v363) goto L_00B9;\nL_00F7:\n\tv482 = System.Collections.Generic.IReadOnlyList`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::get_Item(v164, v133);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RebuildIndices()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::RebuildIndices");
		}

		[Token(Token = "0x6000B0D")]
		[Address(RVA = "0x3EC2510", Offset = "0x3EC2510", Length = "0x458")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\nL_0047:\n\tv53 = coord << 0x20;\n\tv54 = coord.y | v53;\n\tv57 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv211 = ~v57;\n\tif (v211) goto L_005E;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._sandCubeByCoord, v54, entity);\nL_005E:\n\tv249 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv253 = ~v249;\n\tif (v253) goto L_0071;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._wallByCoord, v54, entity);\nL_0071:\n\tv268 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv272 = ~v268;\n\tif (v272) goto L_0084;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._tunnelByCoord, v54, entity);\nL_0084:\n\tv287 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv291 = ~v287;\n\tif (v291) goto L_0097;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._keyByCoord, v54, entity);\nL_0097:\n\tv306 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv309 = ~v306;\n\tif (v309) goto L_00AA;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._lockByCoord, v54, entity);\nL_00AA:\n\tv318 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv319 = ~v318;\n\tif (v319) goto L_00BD;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._garageByCoord, v54, entity);\nL_00BD:\n\tv328 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv329 = ~v328;\n\tif (v329) goto L_00D0;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._garageCoverByCoord, v54, entity);\nL_00D0:\n\tv338 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv339 = ~v338;\n\tif (v339) goto L_00E3;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._hammerAreaByCoord, v54, entity);\nL_00E3:\n\tv348 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv349 = ~v348;\n\tif (v349) goto L_00F6;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._hammerAreaCoverByCoord, v54, entity);\nL_00F6:\n\tv358 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv359 = ~v358;\n\tif (v359) goto L_0109;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._gridCellByCoord, v54, entity);\nL_0109:\n\tv368 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv369 = ~v368;\n\tif (v369) goto L_011C;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._pinByCoord, v54, entity);\nL_011C:\n\tv378 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv379 = ~v378;\n\tif (v379) goto L_012F;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._noPlaceByCoord, v54, entity);\nL_012F:\n\tv388 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::HasComponent(this._em, entity);\n\tv389 = ~v388;\n\tif (v389) goto L_014A;\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::set_Item(this._noPlaceWallByCoord, v54, entity);\nL_014A:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int64>::set_Item(this._coordKeyByEntity, entity, v54);\n\treturn;\n")]
		internal void InsertIntoSpatialIndices(Entity entity, GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::InsertIntoSpatialIndices");
		}

		[Token(Token = "0x6000B0E")]
		[Address(RVA = "0x3EC2508", Offset = "0x3EC2508", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = coord << 0x20;\n\tv4 = coord.y | v3;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::EvictFromSpatialIndicesByKey(this, entity, v4);\n\treturn;\n")]
		private void EvictFromSpatialIndices(Entity entity, GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::EvictFromSpatialIndices");
		}

		[Token(Token = "0x6000B0F")]
		[Address(RVA = "0x3EC3AE4", Offset = "0x3EC3AE4", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._keyByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._lockByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._garageByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._garageCoverByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._hammerAreaByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._hammerAreaCoverByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._gridCellByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._pinByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._noPlaceByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._noPlaceWallByCoord, key, entity);\n\tv95 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int64>::Remove(this._coordKeyByEntity, entity);\n\treturn;\nL_0019:\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._sandCubeByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._wallByCoord, key, entity);\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::TryEvict(this._tunnelByCoord, key, entity);\n")]
		internal void EvictFromSpatialIndicesByKey(Entity entity, long key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::EvictFromSpatialIndicesByKey");
		}

		[Token(Token = "0x6000B10")]
		[Address(RVA = "0x3EC3C1C", Offset = "0x3EC3C1C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv56 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::TryGetValue(map, key, &v45 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity));\n\tv60 = ~v56;\n\tif (v60) goto L_0041;\n\tgoto L_0031;\nL_0031:\n\tv76 = _game.BaseLayerSystems.EntitySystem.Core.Entity::Equals(&v45 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity), entity);\n\tv80 = ~v76;\n\tif (v80) goto L_0041;\n\tv75 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::Remove(map, key);\nL_0041:\n\treturn;\nL_001C:\n\tv45 = 0;\n")]
		private static void TryEvict(Dictionary<long, Entity> map, long key, Entity entity)
		{
			Entity value = default(Entity);
			if (map.TryGetValue(key, out value) && value.Equals(entity))
			{
				bool flag = map.Remove(key);
			}
		}

		[Token(Token = "0x6000B11")]
		[Address(RVA = "0x3EC3D10", Offset = "0x3EC3D10", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv52 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int64>::TryGetValue(this._coordKeyByEntity, entity, &v50 @ stack_-38_v2 (System.Int64));\n\tv54 = ~v52;\n\tif (v54) goto L_002C;\n\t_game.CoreSystem.New.TopGridSystem.Core.Handlers.TopGridHandler::EvictFromSpatialIndicesByKey(this, entity, v50);\nL_002C:\n\treturn;\n")]
		private void OnEntityDestroyed(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::OnEntityDestroyed");
		}

		[Token(Token = "0x6000B12")]
		[Address(RVA = "0x3EC35C8", Offset = "0x3EC35C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = coord << 0x20;\n\treturnVal1 = coord.y | v3;\n\treturn returnVal1;\n")]
		private static long PackCoord(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridHandler::PackCoord");
			return default;
		}

		[Token(Token = "0x6000B13")]
		[Address(RVA = "0x3EC3D9C", Offset = "0x3EC3D9C", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v72);\n\tthis._wallByCoord = v72;\n\tv80 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v80);\n\tthis._tunnelByCoord = v80;\n\tv88 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v88);\n\tthis._keyByCoord = v88;\n\tv96 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v96);\n\tthis._lockByCoord = v96;\n\tv104 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v104);\n\tthis._garageByCoord = v104;\n\tv112 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v112);\n\tthis._garageCoverByCoord = v112;\n\tv120 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v120);\n\tthis._hammerAreaByCoord = v120;\n\tv128 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v128);\n\tthis._hammerAreaCoverByCoord = v128;\n\tv136 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v136);\n\tthis._gridCellByCoord = v136;\n\tv144 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v144);\n\tthis._pinByCoord = v144;\n\tv152 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v152);\n\tthis._noPlaceByCoord = v152;\n\tv160 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v160);\n\tthis._noPlaceWallByCoord = v160;\n\tv168 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Int64>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int64>::.ctor(v168);\n\tthis._coordKeyByEntity = v168;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v56);\n\tthis._sandCubeByCoord = v56;\n")]
		public TopGridHandler()
		{
			Dictionary<long, Entity> sandCubeByCoord = new Dictionary<long, Entity>();
			_sandCubeByCoord = sandCubeByCoord;
			Dictionary<long, Entity> wallByCoord = new Dictionary<long, Entity>();
			_wallByCoord = wallByCoord;
			Dictionary<long, Entity> tunnelByCoord = new Dictionary<long, Entity>();
			_tunnelByCoord = tunnelByCoord;
			Dictionary<long, Entity> keyByCoord = new Dictionary<long, Entity>();
			_keyByCoord = keyByCoord;
			Dictionary<long, Entity> lockByCoord = new Dictionary<long, Entity>();
			_lockByCoord = lockByCoord;
			Dictionary<long, Entity> garageByCoord = new Dictionary<long, Entity>();
			_garageByCoord = garageByCoord;
			Dictionary<long, Entity> garageCoverByCoord = new Dictionary<long, Entity>();
			_garageCoverByCoord = garageCoverByCoord;
			Dictionary<long, Entity> hammerAreaByCoord = new Dictionary<long, Entity>();
			_hammerAreaByCoord = hammerAreaByCoord;
			Dictionary<long, Entity> hammerAreaCoverByCoord = new Dictionary<long, Entity>();
			_hammerAreaCoverByCoord = hammerAreaCoverByCoord;
			Dictionary<long, Entity> gridCellByCoord = new Dictionary<long, Entity>();
			_gridCellByCoord = gridCellByCoord;
			Dictionary<long, Entity> pinByCoord = new Dictionary<long, Entity>();
			_pinByCoord = pinByCoord;
			Dictionary<long, Entity> noPlaceByCoord = new Dictionary<long, Entity>();
			_noPlaceByCoord = noPlaceByCoord;
			Dictionary<long, Entity> noPlaceWallByCoord = new Dictionary<long, Entity>();
			_noPlaceWallByCoord = noPlaceWallByCoord;
			Dictionary<int, long> coordKeyByEntity = new Dictionary<int, long>();
			_coordKeyByEntity = coordKeyByEntity;
		}
	}
}
