using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x2000076")]
	public class EntityManager : IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x2000077")]
		private sealed class _003CGetAllComponents_003Ed__38 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000125")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000126")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000127")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000128")]
			[FieldOffset(Offset = "0x28")]
			public EntityManager _003C_003E4__this;

			[Token(Token = "0x4000129")]
			[FieldOffset(Offset = "0x30")]
			private Entity entity;

			[Token(Token = "0x400012A")]
			[FieldOffset(Offset = "0x38")]
			public Entity _003C_003E3__entity;

			[Token(Token = "0x400012B")]
			[FieldOffset(Offset = "0x40")]
			private int _003CentityIndex_003E5__2;

			[Token(Token = "0x400012C")]
			[FieldOffset(Offset = "0x48")]
			private List<IComponentPool>.Enumerator _003C_003E7__wrap2;

			[Token(Token = "0x17000049")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001F8")]
				[Address(RVA = "0x3C72C4C", Offset = "0x3C72C4C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700004A")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001FA")]
				[Address(RVA = "0x3C72C94", Offset = "0x3C72C94", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001F4")]
			[Address(RVA = "0x3C71314", Offset = "0x3C71314", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetAllComponents_003Ed__38(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001F5")]
			[Address(RVA = "0x3C72844", Offset = "0x3C72844", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = v76.<>1__state - 1;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\n\tv15 = v76.<>1__state - -3;\n\tv30 = v15 == 0;\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv30 = 1;\n\tgoto L_0037;\nL_0043:\n\treturn;\nL_001C:\n\tv34 = ~v30;\n\tif (v34) goto L_0043;\nL_0037:\n\tv76.<>1__state = -1;\n\tv83 = v76 + 0x48;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v83);\n\treturn;\n")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EntityManager._003CGetAllComponents_003Ed__38::Dispose");
			}

			[Token(Token = "0x60001F6")]
			[Address(RVA = "0x3C728BC", Offset = "0x3C728BC", Length = "0x334")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv61 = this.<>1__state == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0124;\n\tv67 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv69 = this.<>4__this == 0;\n\tif (v69) goto L_00FB;\n\tv137 = this.entity;\n\tv140 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this.<>4__this, this.entity);\n\tv143 = v140 == 0;\n\tif (v143) goto L_0124;\n\t*([v45 @ stack_-38_v2+40]) = *([v45 @ stack_-38_v2+30]);\n\tv342 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::GetEnumerator(v67._activePools);\n\t*([v342 @ X0_v50 (System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+48]) = v342._list;\n\t*([v342 @ X0_v50 (System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>+Enumerator<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+58]) = v342.Current;\n\tv342.Current = -3;\n\tgoto L_0061;\nL_005A:\n\tthis.<>1__state = -3;\n\tv332 = *([v45 @ stack_-38_v2+58]) == 0;\n\tif (v332) goto L_00F9;\n\tgoto L_0097;\n\tgoto L_00E8;\nL_00C5:\n\tgoto L_00CE;\nL_00F9:\n\tv328 = new System.NullReferenceException();\n\tv328 = v329;\n\tgoto L_00FE;\nL_00FB:\n\tv193 = new System.NullReferenceException();\n\tv137 = Il2CppMethodInfo;\n\tgoto L_00FE;\nL_00FE:\n\t// 254 Interrupt\n\tgoto L_0112;\nL_0112:\n\tv85 = v137 != 1;\n\tv198 = 0;\n\tv277 = v328;\n\tif (v85) goto L_012C;\n\tv362 = 0x8BF5BC4(v328, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x8BF5BF4(v362, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv421 = *([v362 @ X0_v39]) == 0;\n\tv142 = ~v421;\n\tif (v142) goto L_0125;\nL_0124:\n\treturn 0;\nL_0125:\n\tv365 = &v45 @ stack_-38_v2;\n\tv434 = 0x317A14C(*([v365 @ X8_v27]), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv364 = new System.OutOfMemoryException();\n\tv198 = *([v362 @ X0_v39]);\n\tv277 = v364;\n\treturn returnVal3;\nL_0026:\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_005A;\nL_0097:\n\tv299 = _game.BaseLayerSystems.EntitySystem.Core.IComponentPool::HasByIndex(*([v45 @ stack_-38_v2+58]), *([v45 @ stack_-38_v2+40]));\n\tv301 = v299 == 0;\n\tif (v301) goto L_0061;\nL_00E8:\n\tv503 = _game.BaseLayerSystems.EntitySystem.Core.IComponentPool::GetComponentByIndex(*([v45 @ stack_-38_v2+58]), *([v45 @ stack_-38_v2+40]));\n\tv505 = v45 + 0x18;\n\t*([v505 @ X0_v20]) = v503;\n\t*([v45 @ stack_-38_v2+10]) = 1;\n\treturn 1;\nL_00CE:\n\t*([v45 @ stack_-38_v2+10]) = -1;\n\tv357 = v45 + 0x48;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v357);\n\t*([v45 @ stack_-38_v2+50]) = 0;\n\t*([v45 @ stack_-38_v2+58]) = 0;\n\t*([v45 @ stack_-38_v2+48]) = 0;\n\treturn 0;\nL_012C:\n\tv368 = 0x3179F98(&v198 @ stack_-48_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv399 = 0x8BF0368(v277, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal3 = 0xA1B8(v399, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0061:\n\tv310 = v45 + 0x48;\n\tv311 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(v310);\n\tv315 = v311 == 0;\n\tif (v315) goto L_00C5;\n")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EntityManager._003CGetAllComponents_003Ed__38::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x60001F7")]
			[Address(RVA = "0x3C72BF0", Offset = "0x3C72BF0", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -1;\n\tv46 = this + 0x48;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EntityManager._003CGetAllComponents_003Ed__38::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x60001F9")]
			[Address(RVA = "0x3C72C54", Offset = "0x3C72C54", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001FB")]
			[Address(RVA = "0x3C72C9C", Offset = "0x3C72C9C", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_003B;\n\tthis.<>1__state = 0;\n\tthis.entity = this.<>3__entity;\n\treturn this;\nL_003B:\n\tv76 = new _game.BaseLayerSystems.EntitySystem.Core.EntityManager+<GetAllComponents>d__38();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv88 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v88;\n\tv76.<>4__this = this.<>4__this;\n\tv76.entity = this.<>3__entity;\n\treturn v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_003B;\n")]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						entity = _003C_003E3__entity;
						return this;
					}
				}
				_003CGetAllComponents_003Ed__38 _003CGetAllComponents_003Ed__39 = (_003CGetAllComponents_003Ed__38)FormatterServices.GetUninitializedObject(typeof(_003CGetAllComponents_003Ed__38));
				_003CGetAllComponents_003Ed__39._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetAllComponents_003Ed__39._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetAllComponents_003Ed__39._003C_003E4__this = _003C_003E4__this;
				_003CGetAllComponents_003Ed__39.entity = _003C_003E3__entity;
				return _003CGetAllComponents_003Ed__39;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001FC")]
			[Address(RVA = "0x3C72D60", Offset = "0x3C72D60", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager+<GetAllComponents>d__38::System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<object>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000078")]
		private sealed class _003CGetAllEntities_003Ed__35 : IEnumerable<Entity>, IEnumerable, IEnumerator<Entity>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400012D")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400012E")]
			[FieldOffset(Offset = "0x14")]
			private Entity _003C_003E2__current;

			[Token(Token = "0x400012F")]
			[FieldOffset(Offset = "0x1C")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000130")]
			[FieldOffset(Offset = "0x20")]
			public EntityManager _003C_003E4__this;

			[Token(Token = "0x4000131")]
			[FieldOffset(Offset = "0x28")]
			private HashSet<int>.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x1700004B")]
			Entity IEnumerator<Entity>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000201")]
				[Address(RVA = "0x3C7305C", Offset = "0x3C7305C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700004C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000203")]
				[Address(RVA = "0x3C730A4", Offset = "0x3C730A4", Length = "0x68")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = this.<>2__current;\n\t// 26 Box returnVal1 @ X0_v3 (System.Object), typeof(_game.BaseLayerSystems.EntitySystem.Core.Entity), &v45 @ stack_-38_v1 (_game.BaseLayerSystems.EntitySystem.Core.Entity)\n\treturn returnVal1;\n")]
				get
				{
					Entity entity = _003C_003E2__current;
					return entity;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001FD")]
			[Address(RVA = "0x3C71184", Offset = "0x3C71184", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetAllEntities_003Ed__35(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001FE")]
			[Address(RVA = "0x3C72D64", Offset = "0x3C72D64", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = v76.<>1__state - 1;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\n\tv15 = v76.<>1__state - -3;\n\tv30 = v15 == 0;\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv30 = 1;\n\tgoto L_0037;\nL_0043:\n\treturn;\nL_001C:\n\tv34 = ~v30;\n\tif (v34) goto L_0043;\nL_0037:\n\tv76.<>1__state = -1;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v76.<>7__wrap1 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				bool flag;
				if (_003C_003E1__state - 1 != 0)
				{
					int num = _003C_003E1__state - -3;
					flag = num == 0;
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					_003C_003E1__state = -1;
					_003C_003E7__wrap1.Dispose();
				}
			}

			[Token(Token = "0x60001FF")]
			[Address(RVA = "0x3C72DDC", Offset = "0x3C72DDC", Length = "0x224")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv58 = this.<>1__state == 0;\n\tv59 = ~v58;\nL_FFFFFFFF:\n\tv110 = 0;\n\tif (v59) goto L_FFFFFFFF;\n\tthis.<>1__state = -1;\n\tv109 = this.<>4__this == 0;\n\tif (v109) goto L_007F;\n\tv94 = v45._activeEntities == 0;\n\tif (v94) goto L_0081;\n\tv220 = System.Collections.Generic.HashSet`1<System.Int32>::GetEnumerator(v45._activeEntities);\n\t*([v220 @ X0_v36 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+28]) = v220._set;\n\t*([v220 @ X0_v36 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+38]) = v220._current;\nL_FFFFFFFF:\n\tv97 = v220;\n\tv212 = this.<>4__this == 0;\n\tif (v212) goto L_0083;\n\tv305 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::get_Item(v45._generations, *([v41 @ stack_-28_v2+38]));\n\tv203 = *([v41 @ stack_-28_v2+38]) | v305;\n\t*([v41 @ stack_-28_v2+14]) = v203;\n\t*([v41 @ stack_-28_v2+10]) = 1;\nL_FFFFFFFF:\n\tv110 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_00A2;\nL_006C:\n\tgoto L_0075;\nL_007F:\n\tv168 = new System.NullReferenceException();\n\tgoto L_0086;\nL_0081:\n\tv241 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv241 = v168;\n\tgoto L_0086;\nL_0083:\n\tv230 = new System.NullReferenceException();\n\tgoto L_0086;\nL_0086:\n\t// 134 Interrupt\n\tgoto L_0099;\nL_0099:\n\tv113 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv110 = 0;\nL_FFFFFFFF:\n\tv299 = v241;\n\tif (v113) goto L_00B2;\n\tv309 = 0x8BF5BC4(v241, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv154 = 0x8BF5BF4(v309, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv110 = *([v309 @ X0_v31]);\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\treturn returnVal1;\nL_00AB:\n\tv226 = &v41 @ stack_-28_v2;\n\tv228 = 0x317A1C4(*([v226 @ X8_v20]), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv302 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv299 = v302;\n\treturn returnVal2;\nL_0020:\n\tv45 = this.<>4__this;\n\tv50 = this.<>1__state == 1;\nL_FFFFFFFF:\n\tv97 = this;\n\tif (v50) goto L_004C;\nL_00A2:\n\tv210 = v110 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_00AB;\nL_0075:\n\t*([v41 @ stack_-28_v2+10]) = -1;\n\tv239 = v41 + 0x28;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(v239);\n\t*([v41 @ stack_-28_v2+30]) = 0;\n\t*([v41 @ stack_-28_v2+38]) = 0;\n\t*([v41 @ stack_-28_v2+28]) = 0;\nL_FFFFFFFF:\n\tv110 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_00A2;\nL_00B2:\n\tv312 = 0x3179FCC(&v110 @ stack_-38_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv314 = 0x8BF0368(v299, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v314, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004C:\n\tv97.<>1__state = -3;\n\tv104 = System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v97.<>7__wrap1 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv164 = v104 == 0;\n\tif (v164) goto L_006C;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EntityManager._003CGetAllEntities_003Ed__35::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000200")]
			[Address(RVA = "0x3C73000", Offset = "0x3C73000", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -1;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(&this.<>7__wrap1 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				_003C_003E7__wrap1.Dispose();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000202")]
			[Address(RVA = "0x3C73064", Offset = "0x3C73064", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000204")]
			[Address(RVA = "0x3C7310C", Offset = "0x3C7310C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0038;\n\tthis.<>1__state = 0;\n\treturn this;\nL_0038:\n\tv76 = new _game.BaseLayerSystems.EntitySystem.Core.EntityManager+<GetAllEntities>d__35();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv86 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v86;\n\tv76.<>4__this = this.<>4__this;\n\treturn v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0038;\n")]
			IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003CGetAllEntities_003Ed__35 _003CGetAllEntities_003Ed__36 = (_003CGetAllEntities_003Ed__35)FormatterServices.GetUninitializedObject(typeof(_003CGetAllEntities_003Ed__35));
				_003CGetAllEntities_003Ed__36._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetAllEntities_003Ed__36._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetAllEntities_003Ed__36._003C_003E4__this = _003C_003E4__this;
				return _003CGetAllEntities_003Ed__36;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000205")]
			[Address(RVA = "0x3C731C0", Offset = "0x3C731C0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager+<GetAllEntities>d__35::System.Collections.Generic.IEnumerable<_game.BaseLayerSystems.EntitySystem.Core.Entity>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Entity>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x10")]
		private int _nextId = 1;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x18")]
		private readonly Queue<int> _recycledIds;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x20")]
		internal readonly Dictionary<int, int> _generations;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x28")]
		internal readonly HashSet<int> _activeEntities;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x30")]
		private IComponentPool[] _poolsByIndex;

		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x38")]
		private readonly List<IComponentPool> _activePools;

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x40")]
		private readonly QueryCache _queryCache;

		[CompilerGenerated]
		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x48")]
		private Action<Entity> OnEntityCreated;

		[CompilerGenerated]
		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x50")]
		internal Action<Entity> OnEntityDestroyed;

		[Token(Token = "0x17000048")]
		public int EntityCount
		{
			[Token(Token = "0x60001D5")]
			[Address(RVA = "0x3C70EAC", Offset = "0x3C70EAC", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._activeEntities;\n")]
			get
			{
				HashSet<int> activeEntities = _activeEntities;
				return activeEntities.Count;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x60001D1")]
		[Address(RVA = "0x3C70BDC", Offset = "0x3C70BDC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnEntityCreated;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnEntityCreated (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnEntityCreated(Action<Entity> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::add_OnEntityCreated");
		}

		[CompilerGenerated]
		[Token(Token = "0x60001D2")]
		[Address(RVA = "0x3C70C90", Offset = "0x3C70C90", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnEntityCreated;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnEntityCreated (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnEntityCreated(Action<Entity> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::remove_OnEntityCreated");
		}

		[CompilerGenerated]
		[Token(Token = "0x60001D3")]
		[Address(RVA = "0x3C70D44", Offset = "0x3C70D44", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnEntityDestroyed;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnEntityDestroyed (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnEntityDestroyed(Action<Entity> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::add_OnEntityDestroyed");
		}

		[CompilerGenerated]
		[Token(Token = "0x60001D4")]
		[Address(RVA = "0x3C70DF8", Offset = "0x3C70DF8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnEntityDestroyed;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnEntityDestroyed (System.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnEntityDestroyed(Action<Entity> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::remove_OnEntityDestroyed");
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0x3C6CF40", Offset = "0x3C6CF40", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv65 = v47.Count < 1;\n\tif (v65) goto L_0051;\n\tv102 = System.Collections.Generic.Queue`1<System.Int32>::Dequeue(v47);\n\tv173 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::get_Item(this._generations, v102);\n\tv70 = v173 + 1;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::set_Item(this._generations, v102, v70);\n\tv179 = v70 << 0x20;\n\tv181 = this._activeEntities;\n\tv192 = this._activeEntities == 0;\n\tv108 = ~v192;\n\tv184 = v102;\n\tif (v108) goto L_0065;\n\tgoto L_0080;\nL_0051:\n\tv184 = this._nextId;\n\tv114 = this._nextId + 1;\n\tthis._nextId = v114;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::set_Item(this._generations, this._nextId, 1);\n\tv181 = this._activeEntities;\n\tv179 = 0x100000000;\nL_0065:\n\tv191 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v181, v184);\n\tgoto L_006D;\nL_006D:\n\t;\n\tv157 = this.OnEntityCreated == 0;\n\tif (v157) goto L_0075;\n\tv203 = v179 | v184;\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::Invoke(this.OnEntityCreated, v203);\nL_0080:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0025:\n\tv47 = this._recycledIds;\nL_0075:\n\treturnVal2 = v179 | v184;\n\treturn returnVal2;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Entity CreateEntity()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::CreateEntity");
			return default;
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0x3C7035C", Offset = "0x3C7035C", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv62 = this._activePools;\n\tv147 = v62.Count < 1;\n\tif (v147) goto L_0095;\n\tv171 = 0;\n\tgoto L_0057;\nL_0048:\n\tv285 = _game.BaseLayerSystems.EntitySystem.Core.IComponentPool::RemoveByIndex(v192, entity);\n\tv171 = v171 + 1;\n\tv276 = v171 == v62.Count;\n\tif (v276) goto L_0095;\nL_0057:\n\tv192 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(v62, v171);\n\tv298 = *([v192 @ X0_v14 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)]);\n\tv327 = *([v298 @ X8_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]);\n\tv287 = *([v298 @ X8_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]) == 0;\n\tif (v287) goto L_0048;\n\tv254 = *([v298 @ X8_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv254 = v254 + 0x10;\n\tv306 = v327 - 1;\n\tv307 = v327 != 1;\n\tv327 = v306;\n\tif (v307) goto L_0066;\n\tgoto L_0048;\nL_007B:\n\tv253 = *([v254 @ X10_v7]) << 4;\n\tv350 = v298 + v253;\n\tv288 = v350 + 0x138;\n\t*([v288 @ X8_v14])(v284, v192, entity, *([v288 @ X8_v14+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv171 = v171 + 1;\n\tv265 = v171 != v62.Count;\n\tif (v265) goto L_0057;\nL_0095:\n\tv296 = System.Collections.Generic.HashSet`1<System.Int32>::Remove(this._activeEntities, entity);\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Enqueue(this._recycledIds, entity);\n\tv120 = this.OnEntityDestroyed == 0;\n\tif (v120) goto L_00BC;\n\tSystem.Action`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::Invoke(this.OnEntityDestroyed, entity);\n\treturn;\nL_00BC:\n\treturn;\nL_0027:\n\tv54 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, entity);\n\tv58 = ~v54;\n\tif (v58) goto L_00BC;\nL_0066:\n\tv341 = *([v254 @ X10_v7-8]) == _game.BaseLayerSystems.EntitySystem.Core.IComponentPool;\n\tif (v341) goto L_007B;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyEntity(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::DestroyEntity");
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0x3C70590", Offset = "0x3C70590", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0020;\nL_0020:\n\tv63 = entity < 1;\n\tif (v63) goto L_0070;\n\treturnVal3 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(this._activeEntities, entity);\n\tv181 = ~returnVal3;\n\tif (v181) goto L_004A;\n\treturnVal3 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::TryGetValue(this._generations, entity, &v196 @ stack_-34_v6 (System.Int32));\n\tv197 = ~returnVal3;\n\tif (v197) goto L_004A;\n\tv198 = entity >> 0x20;\n\tv192 = v196 - v198;\n\tv190 = v192 == 0;\n\treturnVal3 = v190;\nL_0070:\n\treturn 0;\nL_004A:\n\treturn returnVal3;\n")]
		public bool IsValid(Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::IsValid");
			return default;
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0x3C70EF8", Offset = "0x3C70EF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, id);\n\treturn returnVal1;\n")]
		public bool EntityExists(EntityId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::EntityExists");
			return default;
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0x3C70EFC", Offset = "0x3C70EFC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\treturnVal2 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(this._activeEntities, index);\n\tv61 = ~returnVal2;\n\tif (v61) goto L_0039;\n\treturnVal3 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::ContainsKey(this._generations, index);\n\treturn returnVal3;\nL_0039:\n\treturn returnVal2;\n")]
		public bool IsValidByIndex(int index)
		{
			bool flag = _activeEntities.Contains(index);
			if (flag)
			{
				return _generations.ContainsKey(index);
			}
			return flag;
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0x3C70F9C", Offset = "0x3C70F9C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv55 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::TryGetValue(this._generations, index, &v53 @ stack_-34_v2 (System.Int32));\n\tv58 = v55 == 0;\n\tif (v58) goto L_0036;\n\treturnVal2 = index | v53;\n\treturn returnVal2;\nL_0036:\n\tgoto L_0042;\nL_0042:\n\treturn v88.Invalid;\n")]
		public Entity GetEntityByIndex(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::GetEntityByIndex");
			return default;
		}

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0x48FD6D4", Offset = "0x48FD6D4", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000D;\nL_000D:\n\tv20 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv23 = *([v20 @ X0_v29 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv24 = v23 == 0;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v24) goto L_0084;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\tv63 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv66 = *([v63 @ X0_v27 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv67 = v66 == 0;\nL_FFFFFFFF:\n\tv81 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v67) goto L_0092;\nL_001D:\n\tv92 = this._poolsByIndex;\nL_0021:\n\tv95 = v94.Id;\n\tv106 = v94.Id >= v92.Length;\n\tif (v106) goto L_0078;\n\tv183 = v92[v95 @ X1_v3 (System.Int32)] == 0;\n\tif (v183) goto L_0078;\n\tgoto L_0055;\nL_FFFFFFFF:\n\t// -1 IsInst v133_asT @ TEMPCOND_v5 (_game.BaseLayerSystems.EntitySystem.Core.ComponentPoolWithInterface`1<T>), typeof(_game.BaseLayerSystems.EntitySystem.Core.ComponentPoolWithInterface`1<T>), v92[v95 @ X1_v3 (System.Int32)]\n\tv133 = v133_asT == 0;\n\tif (v133) goto L_0099;\n\treturn v92[v95 @ X1_v3 (System.Int32)];\n\tv26 = 0x220C2B8(methodInfo, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv42 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv55 = *([v42 @ X0_v17 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv56 = v55 == 0;\n\tv44 = ~v56;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v44) goto L_0015;\nL_0084:\n\tv52 = 0x220C238(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv72 = *([v52 @ X0_v14+E4]) == 0;\n\tv59 = ~v72;\n\tif (v59) goto L_0017;\n\tv74 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv87 = *([v74 @ X0_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv88 = v87 == 0;\n\tv76 = ~v88;\nL_FFFFFFFF:\n\tv81 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v76) goto L_001D;\nL_0092:\n\tv84 = 0x220C238(v81, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv92 = this._poolsByIndex;\n\tv111 = this._poolsByIndex == 0;\n\tv91 = ~v111;\n\tif (v91) goto L_0021;\n\tthrow System.NullReferenceException;\nL_0099:\n\tv180 = new System.InvalidCastException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\nL_0078:\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::CreatePool(this, v94.Id);\n\treturn returnVal2;\nL_0055:\n\tgoto L_FFFFFFFF;\n")]
		public ComponentPoolWithInterface<T> GetPool<T>() where T : struct
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X0_v29 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			nint num6;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X0_v14+E4]");
				if ((nint)0 == 0)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X0_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
					int num5 = (int)((nint)0 & (nint)1);
					bool flag2 = num5 == 0;
					bool flag3 = !flag2;
					num6 = 0;
					if (flag3)
					{
						goto IL_0088;
					}
					goto IL_0208;
				}
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X0_v27 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag4 = num8 == 0;
			num6 = 0;
			if (!flag4)
			{
				goto IL_0088;
			}
			goto IL_0208;
			IL_0097:
			int id = ComponentTypeIndex<T>.Id;
			IComponentPool[] poolsByIndex;
			if (ComponentTypeIndex<T>.Id < poolsByIndex.Length && poolsByIndex[id] != null)
			{
				if (poolsByIndex[id] is ComponentPoolWithInterface<T>)
				{
					return (ComponentPoolWithInterface<T>)poolsByIndex[id];
				}
				InvalidCastException ex = new InvalidCastException();
				return (ComponentPoolWithInterface<T>)(object)new IndexOutOfRangeException();
			}
			return CreatePool<T>(ComponentTypeIndex<T>.Id);
			IL_0088:
			poolsByIndex = _poolsByIndex;
			goto IL_0097;
			IL_0208:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			poolsByIndex = _poolsByIndex;
			if (_poolsByIndex == null)
			{
				throw new NullReferenceException();
			}
			goto IL_0097;
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0x48F219C", Offset = "0x48F219C", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tgoto L_001B;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001B:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::EnsurePoolCapacity(this, idx);\n\tgoto L_0025;\nL_0025:\n\tv59 = new Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentPoolWithInterface`1<T>>();\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPoolWithInterface`1<T>::.ctor(v59);\n\tv63 = this._poolsByIndex;\n\tv65 = v59 == 0;\n\tif (v65) goto L_0045;\n\tv113 = 0x21C11D0(v59, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv117 = v113 == 0;\n\tif (v117) goto L_0081;\nL_0045:\n\tv63[idx @ X1 (System.Int32)] = v59;\n\tv102 = this._activePools;\n\tgoto L_0075;\nL_0075:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::Add(v102, v59);\n\treturn v59;\nL_0081:\n\tv155 = new System.ArrayTypeMismatchException();\n\tthrow v155;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ComponentPoolWithInterface<T> CreatePool<T>(int idx) where T : struct
		{
			EnsurePoolCapacity(idx);
			ComponentPoolWithInterface<T> componentPoolWithInterface = new ComponentPoolWithInterface<T>();
			IComponentPool[] poolsByIndex = _poolsByIndex;
			if (componentPoolWithInterface != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			poolsByIndex[idx] = componentPoolWithInterface;
			List<IComponentPool> activePools = _activePools;
			activePools.Add(componentPoolWithInterface);
			return componentPoolWithInterface;
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0x3C71068", Offset = "0x3C71068", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv89 = v47.Length;\n\tv61 = v47.Length <= idx;\n\tif (v61) goto L_0032;\n\treturn;\nL_0032:\n\tv90 = v89 << 1;\n\tv72 = v89 <= idx;\n\tv89 = v90;\n\tif (v72) goto L_0032;\n\tSystem.Array::Resize(v46, v90);\n\treturn;\nL_0017:\n\tv46 = v41 + 0x30;\n\tv47 = *([v46 @ X0_v2 (System.Object[]&)]);\n")]
		private unsafe void EnsurePoolCapacity(int idx)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::EnsurePoolCapacity");
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0x48ED4D4", Offset = "0x48ED4D4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv27 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, entity);\n\tv42 = ~v27;\n\tif (v42) goto L_0038;\nL_0018:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tv73 = component & 0xFF;\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>::Add(v55, entity, v73);\n\treturn;\n\tv29 = 0x220C2B8(methodInfo, entity, component, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv46 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, entity);\n\tv66 = ~v46;\n\tv51 = ~v66;\n\tif (v51) goto L_0018;\nL_0038:\n\treturn;\n")]
		public void AddComponent<T>(Entity entity, T component) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::AddComponent");
		}

		[Token(Token = "0x60001E0")]
		[Address(RVA = "0x48FC2E0", Offset = "0x48FC2E0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = 0x220C2B8(methodInfo, entity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.MoldSystem.Core.Components.BoundMoldComponent>::Get(v44, entity);\n\treturn returnVal1;\nL_0014:\n\tv44 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(v38);\n")]
		public T GetComponent<T>(Entity entity) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::GetComponent");
			return default;
		}

		[Token(Token = "0x60001E1")]
		[Address(RVA = "0x4913620", Offset = "0x4913620", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv26 = 0x220C2B8(methodInfo, entity, component, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.Shared.Components.ColorComponent>::TryGet(v45, entity, component);\n\treturn returnVal1;\nL_0015:\n\tv45 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(v39);\n")]
		public bool TryGetComponent<T>(Entity entity, out T component) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::TryGetComponent");
			component = default;
			return default;
		}

		[Token(Token = "0x60001E2")]
		[Address(RVA = "0x4908060", Offset = "0x4908060", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = 0x220C2B8(methodInfo, entity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Tags.BlockedByFrozenTag>::Has(v44, entity);\n\treturn returnVal1;\nL_0014:\n\tv44 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(v38);\n")]
		public bool HasComponent<T>(Entity entity) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::HasComponent");
			return default;
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0x4910B00", Offset = "0x4910B00", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = 0x220C2B8(methodInfo, entity, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>::Remove(v44, entity);\n\treturn;\nL_0014:\n\tv44 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(v38);\n")]
		public void RemoveComponent<T>(Entity entity) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::RemoveComponent");
		}

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0x4912728", Offset = "0x4912728", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv27 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, entity);\n\tv42 = ~v27;\n\tif (v42) goto L_0038;\nL_0018:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<_game.CoreSystem.New.MoldSystem.Core.Components.BoundMoldComponent>::Set(v55, entity, component);\n\treturn;\n\tv29 = 0x220C2B8(methodInfo, entity, component, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv46 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, entity);\n\tv66 = ~v46;\n\tv51 = ~v66;\n\tif (v51) goto L_0018;\nL_0038:\n\treturn;\n")]
		public void SetComponent<T>(Entity entity, T component) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::SetComponent");
		}

		[Token(Token = "0x60001E5")]
		[Address(RVA = "0x48FD260", Offset = "0x48FD260", Length = "0x474")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tgoto L_0039;\n\tv47 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv68 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>::get_Count(v59);\n\tv73 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v73, v68);\n\tv148 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>::GetEntityIndices(v59);\n\tv241 = *([v148 @ X0_v29 (System.Collections.Generic.IEnumerable`1<System.Int32>)]);\n\tv304 = *([v241 @ X8_v25 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Int32>>)+12E]);\n\tv243 = *([v241 @ X8_v25 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Int32>>)+12E]) == 0;\n\tif (v243) goto L_0076;\n\tv303 = *([v241 @ X8_v25 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Int32>>)+B0]) + 8;\n\tv303 = v303 + 0x10;\n\tv282 = v304 - 1;\n\tv262 = v304 != 1;\nL_FFFFFFFF:\n\tv304 = v282;\n\tif (v262) goto L_0061;\nL_0076:\n\tv285 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::.ctor(v148, System.Collections.Generic.IEnumerable`1<System.Int32>);\n\t*([v285 @ X0_v58 (System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)])(v366, v148, *([v285 @ X0_v58 (System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>)+8]), 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv324 = v366 == 0;\n\tv325 = ~v324;\nL_FFFFFFFF:\n\tv477 = &v321 @ stack_-58_v10 (System.Collections.Generic.IEnumerator`1<System.Int32>);\nL_FFFFFFFF:\n\tv351 = 0;\n\tif (v325) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv351 = 0;\n\tgoto L_017A;\nL_0085:\n\tv336 = *([v303 @ X10_v32]) << 4;\n\tv337 = v241 + v336;\n\tv338 = v337 + 0x138;\n\tv216 = *([v338 @ X8_v49+8]);\n\t*([v338 @ X8_v49])(v366, v148, *([v338 @ X8_v49+8]), Il2CppMethodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv347 = v366 == 0;\nL_FFFFFFFF:\n\tv477 = &v321 @ stack_-58_v10 (System.Collections.Generic.IEnumerator`1<System.Int32>);\nL_FFFFFFFF:\n\tv351 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv351 = 0;\n\tif (v347) goto L_017A;\nL_FFFFFFFF:\n\tv462 = v366;\n\tgoto L_00A9;\nL_00A9:\n\tgoto L_00CF;\n\tv678 = v321 == 0;\n\tif (v678) goto L_017E;\n\tgoto L_0100;\n\tv809 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(this._activeEntities, v807);\n\tv811 = v809 == 0;\nL_FFFFFFFF:\n\tv216 = v807;\n\tif (v811) goto L_00A3;\n\tv832 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::TryGetValue(this._generations, v807, &v651 @ stack_-5C_v10 (System.Int32));\n\tv836 = v832 == 0;\nL_FFFFFFFF:\n\tv216 = v807;\n\tif (v836) goto L_00A3;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityId::.ctor(&v650 @ stack_-78_v10 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), v807, v651);\n\tv842 = v73 == 0;\n\tif (v842) goto L_0180;\n\tv845 = v73._version + 1;\n\tv73._version = v845;\n\tv835 = v73._items == 0;\n\tif (v835) goto L_0180;\n\tgoto L_0136;\nL_0136:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.Entity>::Add(v73, v650);\nL_FFFFFFFF:\n\tv216 = v650;\n\tgoto L_00A3;\nL_0139:\n\tv514 = &v321 @ stack_-58_v10 (System.Collections.Generic.IEnumerator`1<System.Int32>);\n\tv517 = *([v514 @ X8_v33]);\n\tv512 = *([v514 @ X8_v33]) == 0;\nL_FFFFFFFF:\n\tv504 = v73;\nL_FFFFFFFF:\n\tv515 = 0;\nL_FFFFFFFF:\n\tv181 = v477;\nL_FFFFFFFF:\n\tv210 = v73;\nL_FFFFFFFF:\n\tv216 = 0;\nL_FFFFFFFF:\n\tv225 = 0;\n\tif (v512) goto L_016A;\nL_0143:\n\tgoto L_0169;\n\treturn v210;\nL_017A:\n\tv440 = new System.NullReferenceException();\n\tgoto L_0183;\nL_017C:\n\tv673 = new System.NullReferenceException();\n\tgoto L_0183;\nL_017E:\n\tv674 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv216 = 0;\n\tgoto L_0183;\nL_0180:\n\tv675 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv216 = 0;\n\tgoto L_0183;\nL_0183:\n\t// 387 Interrupt\nL_0186:\n\tv229 = new System.OutOfMemoryException();\n\tgoto L_019A;\nL_019A:\n\tv253 = v216 != 1;\n\tif (v253) goto L_01A8;\n\tv286 = 0x8BF5BC4(v229, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv515 = *([v286 @ X0_v16]);\n\tv328 = 0x8BF5BF4(v286, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv517 = *([v181 @ stack_-68_v1]);\n\tv383 = *([v181 @ stack_-68_v1]) == 0;\n\tv384 = ~v383;\nL_FFFFFFFF:\n\tv351 = *([v286 @ X0_v16]);\nL_FFFFFFFF:\n\tv504 = v210;\n\tif (v384) goto L_0143;\nL_FFFFFFFF:\n\tv181 = v181;\nL_FFFFFFFF:\n\tv351 = *([v286 @ X0_v16]);\nL_FFFFFFFF:\n\tv225 = *([v286 @ X0_v16]);\n\tgoto L_016A;\nL_01A8:\n\tv289 = 0x3175484(&v351 @ stack_-70_v8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv330 = 0x8BF0368(v229, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v330, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0039:\n\tv59 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tthrow System.NullReferenceException;\nL_0061:\n\tv309 = *([v303 @ X10_v32-8]) == System.Collections.Generic.IEnumerable`1<System.Int32>;\n\tif (v309) goto L_0085;\nL_00CF:\n\tv510 = System.Collections.IEnumerator::MoveNext(v462);\n\tv736 = v510 == 0;\n\tif (v736) goto L_0139;\nL_0100:\n\tv807 = System.Collections.Generic.IEnumerator`1<System.Int32>::get_Current(v321);\n\tv677 = this._activeEntities == 0;\n\tif (v677) goto L_017C;\nL_00A3:\n\tv435 = v321 == 0;\nL_FFFFFFFF:\n\tv462 = v321;\n\tif (v435) goto L_017A;\nL_016A:\n\tv573 = v225 == 0;\n\tv221 = ~v573;\nL_FFFFFFFF:\n\tv477 = v181;\n\tif (v221) goto L_0186;\nL_0169:\n\tSystem.IDisposable::Dispose(v517);\nL_FFFFFFFF:\n\tv181 = v477;\nL_FFFFFFFF:\n\tv210 = v504;\nL_FFFFFFFF:\n\tv216 = 0;\nL_FFFFFFFF:\n\tv225 = v515;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IReadOnlyList<Entity> GetEntitiesWithComponent<T>() where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::GetEntitiesWithComponent");
			return default;
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0x490A948", Offset = "0x490A948", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000D;\nL_000D:\n\tv20 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv23 = *([v20 @ X0_v21 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv24 = v23 == 0;\n\tv49 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v24) goto L_0040;\nL_0015:\n\tgoto L_001D;\nL_001D:\n\tgoto L_0025;\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.QueryCache::GetOrUpdate1(this._queryCache, this, v88.Id, v93);\n\treturn returnVal1;\n\tv26 = 0x220C2B8(methodInfo, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv42 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv55 = *([v42 @ X0_v15 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv56 = v55 == 0;\n\tv44 = ~v56;\n\tv49 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v44) goto L_0015;\nL_0040:\n\tv52 = 0x220C238(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv73 = *([v52 @ X0_v12+E4]) == 0;\n\tv59 = ~v73;\n\tif (v59) goto L_001D;\n\tgoto L_004D;\nL_004D:\n\tgoto L_0025;\nL_0025:\n\tv93 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n")]
		public IReadOnlyList<Entity> Query<T>() where T : struct
		{
			//IL_0063: Expected I8, but got I4
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X0_v21 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X0_v12+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			ComponentPoolWithInterface<BottomGridShiftComponent> pool = GetPool<BottomGridShiftComponent>();
			return _queryCache.GetOrUpdate1(this, ComponentTypeIndex<T>.Id, pool);
		}

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0x490E72C", Offset = "0x490E72C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000F;\nL_000F:\n\tv24 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv27 = *([v24 @ X0_v38 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv28 = v27 == 0;\nL_FFFFFFFF:\n\tv53 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v28) goto L_0060;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\tv67 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv70 = *([v67 @ X0_v36 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv71 = v70 == 0;\nL_FFFFFFFF:\n\tv93 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v71) goto L_006E;\nL_0020:\n\tv152 = v85.Id;\n\tv87 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv90 = *([v87 @ X0_v34 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv91 = v90 == 0;\nL_FFFFFFFF:\n\tv136 = v85.Id;\nL_FFFFFFFF:\n\tv114 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v91) goto L_0079;\nL_0029:\n\tgoto L_0031;\nL_0031:\n\tgoto L_0037;\nL_0037:\n\tv161 = _game.BaseLayerSystems.EntitySystem.Core.QueryCache::MakeKey2(v152, v157.Id);\n\tv170 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tv175 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.QueryCache::GetOrUpdate2(this._queryCache, this, v161, v170, v175);\n\treturn returnVal1;\n\tv30 = 0x220C2B8(methodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv46 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv59 = *([v46 @ X0_v16 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv60 = v59 == 0;\n\tv48 = ~v60;\nL_FFFFFFFF:\n\tv53 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v48) goto L_0017;\nL_0060:\n\tv56 = 0x220C238(v53, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv76 = *([v56 @ X0_v13+E4]) == 0;\n\tv63 = ~v76;\n\tif (v63) goto L_0019;\n\tv80 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv98 = *([v80 @ X0_v11 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv99 = v98 == 0;\n\tv82 = ~v99;\nL_FFFFFFFF:\n\tv93 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v82) goto L_0020;\nL_006E:\n\tv96 = 0x220C238(v93, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv103 = *([v96 @ X0_v7+B8]);\n\tv152 = *([v103 @ X9_v4]);\n\tv105 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv120 = *([v105 @ X0_v8 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv121 = v120 == 0;\n\tv107 = ~v121;\nL_FFFFFFFF:\n\tv136 = *([v103 @ X9_v4]);\nL_FFFFFFFF:\n\tv114 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v107) goto L_0029;\nL_0079:\n\tv117 = 0x220C238(v114, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv142 = *([v117 @ X0_v5+E4]) == 0;\n\tv126 = ~v142;\nL_FFFFFFFF:\n\tv152 = v136;\n\tif (v126) goto L_0031;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv152 = v136;\n\tgoto L_0037;\n")]
		public IReadOnlyList<Entity> Query<T1, T2>() where T1 : struct where T2 : struct
		{
			//IL_0235: Expected O, but got I
			//IL_023d: Expected I4, but got O
			//IL_027b: Expected I4, but got O
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X0_v38 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			nint num6;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v13+E4]");
				if ((nint)0 == 0)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X0_v11 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
					int num5 = (int)((nint)0 & (nint)1);
					bool flag2 = num5 == 0;
					bool flag3 = !flag2;
					num6 = 0;
					if (flag3)
					{
						goto IL_0088;
					}
					goto IL_0216;
				}
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X0_v36 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag4 = num8 == 0;
			num6 = 0;
			if (!flag4)
			{
				goto IL_0088;
			}
			goto IL_0216;
			IL_028f:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X0_v5+E4]");
			bool flag5 = (nint)0 == 0;
			bool flag6 = !flag5;
			int num9;
			int a = num9;
			if (!flag6)
			{
				a = num9;
			}
			goto IL_00e3;
			IL_00e3:
			long key = QueryCache.MakeKey2(a, ComponentTypeIndex<T2>.Id);
			ComponentPoolWithInterface<BrokenThisTickTag> pool = GetPool<BrokenThisTickTag>();
			ComponentPoolWithInterface<SandCubeTag> pool2 = GetPool<SandCubeTag>();
			return _queryCache.GetOrUpdate2(this, key, pool, pool2);
			IL_0088:
			a = ComponentTypeIndex<T1>.Id;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v34 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num11 = (int)((nint)0 & (nint)1);
			bool flag7 = num11 == 0;
			num9 = ComponentTypeIndex<T1>.Id;
			nint num12 = 0;
			if (!flag7)
			{
				goto IL_00e3;
			}
			goto IL_028f;
			IL_0216:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X0_v7+B8]");
			object obj = 0;
			a = (int)obj;
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X0_v8 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num14 = (int)((nint)0 & (nint)1);
			bool flag8 = num14 == 0;
			bool flag9 = !flag8;
			num9 = (int)obj;
			num12 = 0;
			if (flag9)
			{
				goto IL_00e3;
			}
			goto IL_028f;
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0x4910400", Offset = "0x4910400", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000F;\nL_000F:\n\tv24 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv27 = *([v24 @ X0_v53 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv28 = v27 == 0;\nL_FFFFFFFF:\n\tv53 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v28) goto L_0079;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\tv67 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv70 = *([v67 @ X0_v51 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv71 = v70 == 0;\nL_FFFFFFFF:\n\tv93 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v71) goto L_0087;\nL_0020:\n\tv225 = v85.Id;\n\tv87 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv90 = *([v87 @ X0_v49 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv91 = v90 == 0;\nL_FFFFFFFF:\n\tv207 = v85.Id;\nL_FFFFFFFF:\n\tv114 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v91) goto L_0092;\nL_0029:\n\tgoto L_002B;\nL_002B:\n\tv130 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv133 = *([v130 @ X0_v46 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv134 = v133 == 0;\nL_FFFFFFFF:\n\tv207 = v225;\nL_FFFFFFFF:\n\tv160 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v134) goto L_00A0;\nL_0032:\n\tv224 = v151.Id;\n\tv153 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tv156 = *([v153 @ X0_v44 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]) & 1;\n\tv157 = v156 == 0;\nL_FFFFFFFF:\n\tv206 = v151.Id;\nL_FFFFFFFF:\n\tv207 = v225;\nL_FFFFFFFF:\n\tv183 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tif (v157) goto L_00AB;\nL_003B:\n\tgoto L_0043;\nL_0043:\n\tgoto L_004A;\nL_004A:\n\tv235 = _game.BaseLayerSystems.EntitySystem.Core.QueryCache::MakeKey3(v225, v224, v230.Id);\n\tv244 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tv249 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tv254 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.QueryCache::GetOrUpdate3(this._queryCache, this, v235, v244, v249, v254);\n\treturn returnVal1;\n\tv30 = 0x220C2B8(methodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv46 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv59 = *([v46 @ X0_v24 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv60 = v59 == 0;\n\tv48 = ~v60;\nL_FFFFFFFF:\n\tv53 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v48) goto L_0017;\nL_0079:\n\tv56 = 0x220C238(v53, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv76 = *([v56 @ X0_v21+E4]) == 0;\n\tv63 = ~v76;\n\tif (v63) goto L_0019;\n\tv80 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv98 = *([v80 @ X0_v19 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv99 = v98 == 0;\n\tv82 = ~v99;\nL_FFFFFFFF:\n\tv93 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v82) goto L_0020;\nL_0087:\n\tv96 = 0x220C238(v93, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv103 = *([v96 @ X0_v15+B8]);\n\tv225 = *([v103 @ X9_v10]);\n\tv105 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv120 = *([v105 @ X0_v16 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv121 = v120 == 0;\n\tv107 = ~v121;\nL_FFFFFFFF:\n\tv207 = *([v103 @ X9_v10]);\nL_FFFFFFFF:\n\tv114 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v107) goto L_0029;\nL_0092:\n\tv117 = 0x220C238(v114, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv141 = *([v117 @ X0_v13+E4]) == 0;\n\tv126 = ~v141;\nL_FFFFFFFF:\n\tv225 = v207;\n\tif (v126) goto L_002B;\n\tv146 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv165 = *([v146 @ X0_v11 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv166 = v165 == 0;\n\tv148 = ~v166;\nL_FFFFFFFF:\n\tv225 = v207;\nL_FFFFFFFF:\n\tv160 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v148) goto L_0032;\nL_00A0:\n\tv163 = 0x220C238(v160, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv171 = *([v163 @ X0_v7+B8]);\n\tv224 = *([v171 @ X9_v4]);\n\tv173 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tv189 = *([v173 @ X0_v8 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]) & 1;\n\tv190 = v189 == 0;\n\tv175 = ~v190;\nL_FFFFFFFF:\n\tv225 = v207;\nL_FFFFFFFF:\n\tv206 = *([v171 @ X9_v4]);\nL_FFFFFFFF:\n\tv183 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tif (v175) goto L_003B;\nL_00AB:\n\tv186 = 0x220C238(v183, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv213 = *([v186 @ X0_v5+E4]) == 0;\n\tv196 = ~v213;\nL_FFFFFFFF:\n\tv224 = v206;\nL_FFFFFFFF:\n\tv225 = v207;\n\tif (v196) goto L_0043;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv224 = v206;\nL_FFFFFFFF:\n\tv225 = v207;\n\tgoto L_004A;\n")]
		public IReadOnlyList<Entity> Query<T1, T2, T3>() where T1 : struct where T2 : struct where T3 : struct
		{
			//IL_02ec: Expected O, but got I
			//IL_02f4: Expected I4, but got O
			//IL_0332: Expected I4, but got O
			//IL_03fe: Expected O, but got I
			//IL_0406: Expected I4, but got O
			//IL_044c: Expected I4, but got O
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X0_v53 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			nint num6;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v21+E4]");
				if ((nint)0 == 0)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X0_v19 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
					int num5 = (int)((nint)0 & (nint)1);
					bool flag2 = num5 == 0;
					bool flag3 = !flag2;
					num6 = 0;
					if (flag3)
					{
						goto IL_0088;
					}
					goto IL_02cd;
				}
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X0_v51 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag4 = num8 == 0;
			num6 = 0;
			if (!flag4)
			{
				goto IL_0088;
			}
			goto IL_02cd;
			IL_0125:
			int b = ComponentTypeIndex<T2>.Id;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X0_v44 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]");
			int num10 = (int)((nint)0 & (nint)1);
			bool flag5 = num10 == 0;
			int num11 = ComponentTypeIndex<T2>.Id;
			int num13;
			int num12 = num13;
			nint num14 = 0;
			if (!flag5)
			{
				goto IL_0188;
			}
			goto IL_0460;
			IL_0460:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X0_v5+E4]");
			bool flag6 = (nint)0 == 0;
			bool flag7 = !flag6;
			b = num11;
			num13 = num12;
			if (!flag7)
			{
				b = num11;
				num13 = num12;
			}
			goto IL_0188;
			IL_03df:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v7+B8]");
			object obj = 0;
			b = (int)obj;
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v8 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]");
			int num16 = (int)((nint)0 & (nint)1);
			bool flag8 = num16 == 0;
			bool flag9 = !flag8;
			num13 = num12;
			num11 = (int)obj;
			num14 = 0;
			if (flag9)
			{
				goto IL_0188;
			}
			goto IL_0460;
			IL_02cd:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X0_v15+B8]");
			object obj2 = 0;
			num13 = (int)obj2;
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X0_v16 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num18 = (int)((nint)0 & (nint)1);
			bool flag10 = num18 == 0;
			bool flag11 = !flag10;
			num12 = (int)obj2;
			nint num19 = 0;
			if (flag11)
			{
				goto IL_00de;
			}
			goto IL_0346;
			IL_0088:
			num13 = ComponentTypeIndex<T1>.Id;
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v49 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num21 = (int)((nint)0 & (nint)1);
			bool flag12 = num21 == 0;
			num12 = ComponentTypeIndex<T1>.Id;
			num19 = 0;
			if (!flag12)
			{
				goto IL_00de;
			}
			goto IL_0346;
			IL_0346:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X0_v13+E4]");
			bool flag13 = (nint)0 == 0;
			bool flag14 = !flag13;
			num13 = num12;
			if (flag14)
			{
				goto IL_00de;
			}
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X0_v11 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num23 = (int)((nint)0 & (nint)1);
			bool flag15 = num23 == 0;
			bool flag16 = !flag15;
			num13 = num12;
			nint num24 = 0;
			if (flag16)
			{
				goto IL_0125;
			}
			goto IL_03df;
			IL_0188:
			long key = QueryCache.MakeKey3(num13, b, ComponentTypeIndex<T3>.Id);
			ComponentPoolWithInterface<SandCubeTag> pool = GetPool<SandCubeTag>();
			ComponentPoolWithInterface<CoverOpenTag> pool2 = GetPool<CoverOpenTag>();
			ComponentPoolWithInterface<ColorHiddenComponent> pool3 = GetPool<ColorHiddenComponent>();
			return _queryCache.GetOrUpdate3(this, key, pool, pool2, pool3);
			IL_00de:
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X0_v46 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num26 = (int)((nint)0 & (nint)1);
			bool flag17 = num26 == 0;
			num12 = num13;
			num24 = 0;
			if (!flag17)
			{
				goto IL_0125;
			}
			goto IL_03df;
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0x491083C", Offset = "0x491083C", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv28 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv31 = *([v28 @ X0_v68 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv32 = v31 == 0;\nL_FFFFFFFF:\n\tv57 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v32) goto L_009A;\nL_0019:\n\tgoto L_001B;\nL_001B:\n\tv71 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv74 = *([v71 @ X0_v66 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv75 = v74 == 0;\nL_FFFFFFFF:\n\tv97 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v75) goto L_00A8;\nL_0022:\n\tv308 = v89.Id;\n\tv91 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv94 = *([v91 @ X0_v64 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv95 = v94 == 0;\nL_FFFFFFFF:\n\tv288 = v89.Id;\nL_FFFFFFFF:\n\tv118 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v95) goto L_00B3;\nL_002B:\n\tgoto L_002D;\nL_002D:\n\tv134 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv137 = *([v134 @ X0_v61 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv138 = v137 == 0;\nL_FFFFFFFF:\n\tv288 = v308;\nL_FFFFFFFF:\n\tv164 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v138) goto L_00C1;\nL_0034:\n\tv307 = v155.Id;\n\tv157 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tv160 = *([v157 @ X0_v59 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]) & 1;\n\tv161 = v160 == 0;\nL_FFFFFFFF:\n\tv287 = v155.Id;\nL_FFFFFFFF:\n\tv288 = v308;\nL_FFFFFFFF:\n\tv187 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tif (v161) goto L_00CC;\nL_003D:\n\tgoto L_003F;\nL_003F:\n\tv204 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tv207 = *([v204 @ X0_v56 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]) & 1;\n\tv208 = v207 == 0;\nL_FFFFFFFF:\n\tv287 = v307;\nL_FFFFFFFF:\n\tv288 = v308;\nL_FFFFFFFF:\n\tv237 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tif (v208) goto L_00DA;\nL_0046:\n\tv306 = v227.Id;\n\tv229 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T4>>;\n\tv232 = *([v229 @ X0_v54 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T4>>)+135]) & 1;\n\tv233 = v232 == 0;\nL_FFFFFFFF:\n\tv286 = v227.Id;\nL_FFFFFFFF:\n\tv287 = v307;\nL_FFFFFFFF:\n\tv288 = v308;\nL_FFFFFFFF:\n\tv262 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T4>>;\n\tif (v233) goto L_00E5;\nL_004F:\n\tgoto L_0057;\nL_0057:\n\tgoto L_005F;\nL_005F:\n\tv319 = _game.BaseLayerSystems.EntitySystem.Core.QueryCache::MakeKey4(v308, v307, v306, v313.Id);\n\tv329 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tv335 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tv341 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\tv347 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetPool(this);\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.QueryCache::GetOrUpdate4(this._queryCache, this, v319, v329, v335, v341, v347);\n\treturn returnVal1;\n\tv34 = 0x220C2B8(methodInfo, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv50 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv63 = *([v50 @ X0_v32 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv64 = v63 == 0;\n\tv52 = ~v64;\nL_FFFFFFFF:\n\tv57 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v52) goto L_0019;\nL_009A:\n\tv60 = 0x220C238(v57, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv80 = *([v60 @ X0_v29+E4]) == 0;\n\tv67 = ~v80;\n\tif (v67) goto L_001B;\n\tv84 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tv102 = *([v84 @ X0_v27 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]) & 1;\n\tv103 = v102 == 0;\n\tv86 = ~v103;\nL_FFFFFFFF:\n\tv97 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>;\n\tif (v86) goto L_0022;\nL_00A8:\n\tv100 = 0x220C238(v97, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv107 = *([v100 @ X0_v23+B8]);\n\tv308 = *([v107 @ X9_v16]);\n\tv109 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv124 = *([v109 @ X0_v24 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv125 = v124 == 0;\n\tv111 = ~v125;\nL_FFFFFFFF:\n\tv288 = *([v107 @ X9_v16]);\nL_FFFFFFFF:\n\tv118 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v111) goto L_002B;\nL_00B3:\n\tv121 = 0x220C238(v118, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv145 = *([v121 @ X0_v21+E4]) == 0;\n\tv130 = ~v145;\nL_FFFFFFFF:\n\tv308 = v288;\n\tif (v130) goto L_002D;\n\tv150 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tv169 = *([v150 @ X0_v19 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]) & 1;\n\tv170 = v169 == 0;\n\tv152 = ~v170;\nL_FFFFFFFF:\n\tv308 = v288;\nL_FFFFFFFF:\n\tv164 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>;\n\tif (v152) goto L_0034;\nL_00C1:\n\tv167 = 0x220C238(v164, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = *([v167 @ X0_v15+B8]);\n\tv307 = *([v175 @ X9_v10]);\n\tv177 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tv193 = *([v177 @ X0_v16 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]) & 1;\n\tv194 = v193 == 0;\n\tv179 = ~v194;\nL_FFFFFFFF:\n\tv308 = v288;\nL_FFFFFFFF:\n\tv287 = *([v175 @ X9_v10]);\nL_FFFFFFFF:\n\tv187 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tif (v179) goto L_003D;\nL_00CC:\n\tv190 = 0x220C238(v187, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = *([v190 @ X0_v13+E4]) == 0;\n\tv200 = ~v216;\nL_FFFFFFFF:\n\tv307 = v287;\nL_FFFFFFFF:\n\tv308 = v288;\n\tif (v200) goto L_003F;\n\tv222 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tv242 = *([v222 @ X0_v11 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]) & 1;\n\tv243 = v242 == 0;\n\tv224 = ~v243;\nL_FFFFFFFF:\n\tv307 = v287;\nL_FFFFFFFF:\n\tv308 = v288;\nL_FFFFFFFF:\n\tv237 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>;\n\tif (v224) goto L_0046;\nL_00DA:\n\tv240 = 0x220C238(v237, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv249 = *([v240 @ X0_v7+B8]);\n\tv306 = *([v249 @ X9_v4]);\n\tv251 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T4>>;\n\tv268 = *([v251 @ X0_v8 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T4>>)+135]) & 1;\n\tv269 = v268 == 0;\n\tv253 = ~v269;\nL_FFFFFFFF:\n\tv307 = v2\n// ... truncated")]
		public IReadOnlyList<Entity> Query<T1, T2, T3, T4>() where T1 : struct where T2 : struct where T3 : struct where T4 : struct
		{
			//IL_03ae: Expected O, but got I
			//IL_03b6: Expected I4, but got O
			//IL_03f4: Expected I4, but got O
			//IL_04c0: Expected O, but got I
			//IL_04c8: Expected I4, but got O
			//IL_050e: Expected I4, but got O
			//IL_05ea: Expected O, but got I
			//IL_05f2: Expected I4, but got O
			//IL_0640: Expected I4, but got O
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X0_v68 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			nint num6;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X0_v29+E4]");
				if ((nint)0 == 0)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X0_v27 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
					int num5 = (int)((nint)0 & (nint)1);
					bool flag2 = num5 == 0;
					bool flag3 = !flag2;
					num6 = 0;
					if (flag3)
					{
						goto IL_0088;
					}
					goto IL_038f;
				}
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v66 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T1>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag4 = num8 == 0;
			num6 = 0;
			if (!flag4)
			{
				goto IL_0088;
			}
			goto IL_038f;
			IL_05cb:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X0_v7+B8]");
			object obj = 0;
			int c = (int)obj;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X0_v8 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T4>>)+135]");
			int num10 = (int)((nint)0 & (nint)1);
			bool flag5 = num10 == 0;
			bool flag6 = !flag5;
			int num12;
			int num11 = num12;
			int num14;
			int num13 = num14;
			int num15 = (int)obj;
			nint num16 = 0;
			if (flag6)
			{
				goto IL_023d;
			}
			goto IL_0654;
			IL_01d2:
			c = ComponentTypeIndex<T3>.Id;
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X0_v54 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T4>>)+135]");
			int num18 = (int)((nint)0 & (nint)1);
			bool flag7 = num18 == 0;
			num15 = ComponentTypeIndex<T3>.Id;
			num12 = num11;
			num14 = num13;
			num16 = 0;
			if (!flag7)
			{
				goto IL_023d;
			}
			goto IL_0654;
			IL_0183:
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X0_v56 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]");
			int num20 = (int)((nint)0 & (nint)1);
			bool flag8 = num20 == 0;
			num12 = num11;
			num14 = num13;
			nint num21 = 0;
			if (!flag8)
			{
				goto IL_01d2;
			}
			goto IL_05cb;
			IL_038f:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X0_v23+B8]");
			object obj2 = 0;
			num13 = (int)obj2;
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X0_v24 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num23 = (int)((nint)0 & (nint)1);
			bool flag9 = num23 == 0;
			bool flag10 = !flag9;
			num14 = (int)obj2;
			nint num24 = 0;
			if (flag10)
			{
				goto IL_00de;
			}
			goto IL_0408;
			IL_0088:
			num13 = ComponentTypeIndex<T1>.Id;
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X0_v64 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num26 = (int)((nint)0 & (nint)1);
			bool flag11 = num26 == 0;
			num14 = ComponentTypeIndex<T1>.Id;
			num24 = 0;
			if (!flag11)
			{
				goto IL_00de;
			}
			goto IL_0408;
			IL_0408:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X0_v21+E4]");
			bool flag12 = (nint)0 == 0;
			bool flag13 = !flag12;
			num13 = num14;
			if (flag13)
			{
				goto IL_00de;
			}
			nint num27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X0_v19 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num28 = (int)((nint)0 & (nint)1);
			bool flag14 = num28 == 0;
			bool flag15 = !flag14;
			num13 = num14;
			nint num29 = 0;
			if (flag15)
			{
				goto IL_0125;
			}
			goto IL_04a1;
			IL_0654:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X0_v5+E4]");
			bool flag16 = (nint)0 == 0;
			bool flag17 = !flag16;
			c = num15;
			num11 = num12;
			num13 = num14;
			if (!flag17)
			{
				c = num15;
				num11 = num12;
				num13 = num14;
			}
			goto IL_023d;
			IL_00de:
			nint num30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v61 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T2>>)+135]");
			int num31 = (int)((nint)0 & (nint)1);
			bool flag18 = num31 == 0;
			num14 = num13;
			num29 = 0;
			if (!flag18)
			{
				goto IL_0125;
			}
			goto IL_04a1;
			IL_04a1:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X0_v15+B8]");
			object obj3 = 0;
			num11 = (int)obj3;
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X0_v16 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]");
			int num33 = (int)((nint)0 & (nint)1);
			bool flag19 = num33 == 0;
			bool flag20 = !flag19;
			num13 = num14;
			num12 = (int)obj3;
			nint num34 = 0;
			if (flag20)
			{
				goto IL_0183;
			}
			goto IL_0522;
			IL_0125:
			num11 = ComponentTypeIndex<T2>.Id;
			nint num35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X0_v59 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]");
			int num36 = (int)((nint)0 & (nint)1);
			bool flag21 = num36 == 0;
			num12 = ComponentTypeIndex<T2>.Id;
			num14 = num13;
			num34 = 0;
			if (!flag21)
			{
				goto IL_0183;
			}
			goto IL_0522;
			IL_0522:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v13+E4]");
			bool flag22 = (nint)0 == 0;
			bool flag23 = !flag22;
			num11 = num12;
			num13 = num14;
			if (flag23)
			{
				goto IL_0183;
			}
			nint num37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X0_v11 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T3>>)+135]");
			int num38 = (int)((nint)0 & (nint)1);
			bool flag24 = num38 == 0;
			bool flag25 = !flag24;
			num11 = num12;
			num13 = num14;
			num21 = 0;
			if (flag25)
			{
				goto IL_01d2;
			}
			goto IL_05cb;
			IL_023d:
			long key = QueryCache.MakeKey4(num13, num11, c, ComponentTypeIndex<T4>.Id);
			IComponentPool pool = GetPool<T1>();
			IComponentPool pool2 = GetPool<T2>();
			IComponentPool pool3 = GetPool<T3>();
			IComponentPool pool4 = GetPool<T4>();
			return _queryCache.GetOrUpdate4(this, key, pool, pool2, pool3, pool4);
		}

		[IteratorStateMachine(typeof(_003CGetAllEntities_003Ed__35))]
		[Token(Token = "0x60001EA")]
		[Address(RVA = "0x3C710FC", Offset = "0x3C710FC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.<>l__initialThreadId = v50;\n\tv45.<>4__this = this;\n\treturn v45;\nL_0017:\n\tv45 = new _game.BaseLayerSystems.EntitySystem.Core.EntityManager+<GetAllEntities>d__35();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = -2;\n\tv50 = System.Environment::get_CurrentManagedThreadId();\n")]
		public IEnumerable<Entity> GetAllEntities()
		{
			_003CGetAllEntities_003Ed__35 _003CGetAllEntities_003Ed__36 = new _003CGetAllEntities_003Ed__35(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetAllEntities_003Ed__36._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetAllEntities_003Ed__36._003C_003E4__this = this;
			return _003CGetAllEntities_003Ed__36;
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0x3C711BC", Offset = "0x3C711BC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB78D000;\n\tv18 = *([B78D67E]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0023;\n\tv21 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, id);\n\tv43 = v21 == 0;\n\tif (v43) goto L_0030;\nL_001B:\n\treturn id;\nL_0023:\n\t*([v16 @ X20_v1+67E]) = 1;\n\tv47 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, id);\n\tv73 = v47 == 0;\n\tv52 = ~v73;\n\tif (v52) goto L_001B;\nL_0030:\n\tgoto L_003D;\nL_003D:\n\treturn v85.Invalid;\n")]
		public Entity GetEntity(EntityId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::GetEntity");
			return default;
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0x3C71260", Offset = "0x3C71260", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB78D000;\n\tv18 = *([B78D67F]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0024;\n\tentity.Id = id;\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, id);\n\tv43 = returnVal1 == 0;\n\treturnVal2 = returnVal1;\n\tif (v43) goto L_0031;\nL_001A:\n\treturn returnVal1;\nL_0024:\n\t*([v16 @ X20_v1+67F]) = 1;\n\tentity.Id = id;\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(this, id);\n\tv74 = returnVal1 == 0;\n\tv53 = ~v74;\n\treturnVal2 = returnVal1;\n\tif (v53) goto L_001A;\nL_0031:\n\tgoto L_0039;\nL_0039:\n\tentity.Id = v102.Invalid;\n\treturn returnVal2;\n")]
		public bool TryGetEntity(EntityId id, out Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::TryGetEntity");
			entity = default;
			return default;
		}

		[IteratorStateMachine(typeof(_003CGetAllComponents_003Ed__38))]
		[Token(Token = "0x60001ED")]
		[Address(RVA = "0x3C6EA08", Offset = "0x3C6EA08", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.<>l__initialThreadId = v51;\n\tv46.<>4__this = this;\n\tv46.<>3__entity = entity;\n\treturn v46;\nL_0018:\n\tv46 = new _game.BaseLayerSystems.EntitySystem.Core.EntityManager+<GetAllComponents>d__38();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = -2;\n\tv51 = System.Environment::get_CurrentManagedThreadId();\n")]
		public IEnumerable<object> GetAllComponents(Entity entity)
		{
			_003CGetAllComponents_003Ed__38 _003CGetAllComponents_003Ed__39 = new _003CGetAllComponents_003Ed__38(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetAllComponents_003Ed__39._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetAllComponents_003Ed__39._003C_003E4__this = this;
			_003CGetAllComponents_003Ed__39._003C_003E3__entity = entity;
			return _003CGetAllComponents_003Ed__39;
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0x3C7134C", Offset = "0x3C7134C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._activePools;\n")]
		public IReadOnlyList<IComponentPool> GetAllPools()
		{
			return _activePools;
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0x3C71354", Offset = "0x3C71354", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv67 = v51.Count < 1;\n\tif (v67) goto L_0090;\n\tv103 = 0;\n\tgoto L_0053;\nL_0044:\n\tv205 = _game.BaseLayerSystems.EntitySystem.Core.IComponentPool::Clear(v144);\n\tv103 = v103 + 1;\n\tv196 = v103 == v51.Count;\n\tif (v196) goto L_0090;\nL_0053:\n\tv144 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(v51, v103);\n\tv265 = *([v144 @ X0_v15 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)]);\n\tv292 = *([v265 @ X8_v18 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]);\n\tv207 = *([v265 @ X8_v18 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]) == 0;\n\tif (v207) goto L_0044;\n\tv175 = *([v265 @ X8_v18 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv175 = v175 + 0x10;\n\tv272 = v292 - 1;\n\tv273 = v292 != 1;\n\tv292 = v272;\n\tif (v273) goto L_0062;\n\tgoto L_0044;\nL_0077:\n\tv316 = *([v175 @ X10_v6]) + 1;\n\tv174 = v316 << 4;\n\tv317 = v265 + v174;\n\tv208 = v317 + 0x138;\n\t*([v208 @ X8_v20])(v204, v144, *([v208 @ X8_v20+8]), Il2CppMethodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv103 = v103 + 1;\n\tv185 = v103 != v51.Count;\n\tif (v185) goto L_0053;\nL_0090:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._activeEntities);\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Clear(this._recycledIds);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::Clear(this._generations);\n\tv164 = this._queryCache;\n\tgoto L_00B3;\nL_00B3:\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::Clear(v164._cache);\n\tthis._nextId = 1;\n\treturn;\nL_0027:\n\tv51 = this._activePools;\nL_0062:\n\tv306 = *([v175 @ X10_v6-8]) == _game.BaseLayerSystems.EntitySystem.Core.IComponentPool;\n\tif (v306) goto L_0077;\n")]
		public void Clear()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::Clear");
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0x3C71588", Offset = "0x3C71588", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::Clear(this);\n\treturn;\n")]
		public void Dispose()
		{
			Clear();
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0x3C7158C", Offset = "0x3C7158C", Length = "0x70C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0065;\n\tv67._nextId = this._nextId;\n\tv363 = 0xB2A2000 + 0x778;\n\tv299 = 0xB28F000 + 0x6D0;\n\tv389 = System.Collections.Generic.Queue`1<System.Int32>::GetEnumerator(this._recycledIds);\n\tv448 = v389;\n\tv574 = System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>::get_Current(&v448 @ stack_-80_v8 (System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>));\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Enqueue(v67._recycledIds, v574);\n\tgoto L_0093;\nL_00A5:\n\tSystem.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v448 @ stack_-80_v8 (System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>));\nL_FFFFFFFF:\n\tv283 = 0;\n\tv660 = &v283 @ stack_-E0_v8 (System.Int32);\n\tv661 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::GetEnumerator(this._generations);\n\tv225 = v283.m_value;\n\tv433 = v67._generations == 0;\n\tif (v433) goto L_0247;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::set_Item(v67._generations, *([v660 @ X8_v14+10]), v709);\n\tgoto L_00BF;\nL_00CF:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>+Enumerator<System.Int32, System.Int32>::Dispose(&v225 @ stack_-A0_v8 (System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>+Enumerator<System.Int32, System.Int32>));\n\tv718 = System.Collections.Generic.HashSet`1<System.Int32>::GetEnumerator(this._activeEntities);\n\tv216 = v718;\n\tv512 = v67._activeEntities == 0;\n\tif (v512) goto L_0249;\n\tv810 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v67._activeEntities, v718._current);\n\tgoto L_00E5;\nL_00F6:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v216 @ stack_-C0_v8 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv352 = this._activePools;\n\tv837 = v352.Count < 1;\n\tif (v837) goto L_0245;\nL_FFFFFFFF:\n\tv364 = 0;\n\tgoto L_0123;\nL_0110:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::Add(v334, v930);\n\tv364 = v364 + 1;\n\tv853 = v364 == v352.Count;\n\tif (v853) goto L_0245;\nL_0123:\n\tv329 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(this._activePools, v364);\n\tv879 = *([v329 @ X0_v43 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)]);\n\tv898 = *([v879 @ X8_v30 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]);\n\tv881 = *([v879 @ X8_v30 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]) == 0;\n\tif (v881) goto L_0147;\n\tv105 = *([v879 @ X8_v30 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv105 = v105 + 0x10;\n\tv886 = v898 - 1;\n\tv887 = v898 != 1;\nL_FFFFFFFF:\n\tv898 = v886;\n\tif (v887) goto L_012D;\nL_0147:\n\tv896 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(v329, *([v299 @ X26_v6 (System.Int32)]));\n\t*([v896 @ X0_v75 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)])(v930, v329, *([v896 @ X0_v75 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)+8]), 7, v363.m_value, v41, v42, v43, v44, v718._set, *([v660 @ X8_v14+10]), v47, v48, v49, v50, v51, v52);\n\tv909 = v930 == 0;\n\tv342 = ~v909;\nL_FFFFFFFF:\n\tv245 = 7;\n\tif (v342) goto L_015C;\n\tgoto L_0246;\nL_0151:\n\t;\n\tv912 = *([v105 @ X10_v27]) + 7;\n\tv96 = v912 << 4;\n\tv913 = v879 + v96;\n\tv356 = v913 + 0x138;\n\t*([v356 @ X8_v60])(v930, v329, *([v356 @ X8_v60+8]), Il2CppMethodInfo, v363.m_value, v41, v42, v43, v44, v718._set, *([v660 @ X8_v14+10]), v47, v48, v49, v50, v51, v52);\nL_FFFFFFFF:\n\tv245 = Il2CppMethodInfo;\nL_015C:\n\t;\n\tv934 = *([v930 @ X0_v44 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)]);\n\tv968 = *([v934 @ X8_v32 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]);\n\tv936 = *([v934 @ X8_v32 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]) == 0;\n\tif (v936) goto L_017D;\n\tv967 = *([v934 @ X8_v32 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv967 = v967 + 0x10;\n\tv944 = v968 - 1;\n\tv946 = v968 != 1;\nL_FFFFFFFF:\n\tv968 = v944;\n\tif (v946) goto L_0163;\nL_017D:\n\tv965 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(v930, *([v299 @ X26_v6 (System.Int32)]));\n\t*([v965 @ X0_v69 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)])(v990, v930, *([v965 @ X0_v69 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)+8]), 5, v363.m_value, v41, v42, v43, v44, v718._set, *([v660 @ X8_v14+10]), v47, v48, v49, v50, v51, v52);\nL_FFFFFFFF:\n\tv245 = 5;\nL_FFFFFFFF:\n\tv303 = v990;\n\tgoto L_018C;\n\tv1065 = v322.Length;\n\tv1044 = v303 < v322.Length;\n\tif (v1044) goto L_01AF;\nL_019D:\n\tv1066 = v1065 << 1;\n\tv1046 = v1065 <= v303;\nL_FFFFFFFF:\n\tv1065 = v1066;\n\tif (v1046) goto L_019D;\n\tv1083 = v67 + 0x30;\n\tSystem.Array::Resize(v1083, v1066);\n\tv322 = v67._poolsByIndex;\nL_FFFFFFFF:\n\tv245 = Il2CppMethodInfo;\n\tv107 = *([v1086 @ X8_v36 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv107 = v107 + 0x10;\n\tv1092 = v1105 - 1;\n\tv1093 = v1105 != 1;\nL_FFFFFFFF:\n\tv1105 = v1092;\n\tif (v1093) goto L_01B6;\nL_01D0:\n\tv1103 = System.Collections.Generic.Queue`1<System.Int32>::Enqueue(v930, *([v299 @ X26_v6 (System.Int32)]));\n\t*([v1103 @ X0_v58])(v1123, v930, *([v1103 @ X0_v58+8]), 5, v363.m_value, v41, v42, v43, v44, v718._set, *([v660 @ X8_v14+10]), v47, v48, v49, v50, v51, v52);\n\tv1116 = v322 == 0;\n\tv344 = ~v1116;\n\tif (v344) goto L_01F7;\n\tgoto L_0246;\nL_01D9:\n\t;\n\tv998 = *([v967 @ X10_v22]) + 5;\n\tv999 = v998 << 4;\n\tv1000 = v934 + v999;\n\tv1001 = v1000 + 0x138;\n\t*([v1001 @ X0_v72])(v1005, v930, *([v1001 @ X0_v72+8]), v245, v363.m_value, v41, v42, v43, v44, v718._set, *([v660 @ X8_v14+10]), v47, v48, v49, v50, v51, v52);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv303 = v1005;\n\tgoto L_018C;\nL_01E8:\n\t;\n\tv117 = *([v107 @ X10_v16]) + 5;\n\tv98 = v117 << 4;\n\tv1119 = v1086 + v98;\n\tv1120 = v1119 + 0x138;\n\t*([v1120 @ X0_v61])(v1123, v930, *([v1120 @ X0_v61+8]), v245, v363.m_value, v41, v42, v43, v44, v718._set, *([v660 @ X8_v14+10]), v47, v48, v49, v50, v51, v52);\nL_01F7:\n\tv563 = 0x21C11D0(v930, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv565 = v563 == 0;\n\tif (v565) goto L_024E;\n\tv322[v1123 @ X0_v47 (System.Int32)] = v930;\n\tv334 = v67._activePools;\n\tgoto L_0110;\nL_0245:\n\treturn v67;\nL_0246:\n\tv365 = new System.NullReferenceException();\nL_0247:\n\tv437 = new System.NullReferenceException();\n\tgoto L_024C;\nL_0249:\n\tv510 = new System.NullReferenceException();\n\tgoto L_024C;\nL_024C:\n\t// 588 Interrupt\nL_024E:\n\tv631 = new System.ArrayTypeMismatchException();\n\tthrow v631;\nL_0065:\n\tv67 = new _game.BaseLayerSystems.EntitySystem.Core.EntityManager();\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::.ctor(v67);\nL_0093:\n\tv467 = System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v448 @ stack_-80_v8 (System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>));\n\tv520 = v467 == 0;\n\tif (v520) goto L_00A5;\nL_00BF:\n\tv679 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>+Enumerator<System.Int32, System.Int32>::MoveNext(&v225 @ stack_-A0_v8 (System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>+Enumerator<System.Int32, System.Int32>));\n\tv696 = v679 == 0;\n\tif (v696) goto L_00CF;\nL_00E5:\n\t;\n\tv813 = System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v216 @ stack_-C0_v8 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv818 = v813 == 0;\n\tif (v818) goto L_00F6;\nL_012D:\n\t;\n\tv176 = *([v105 @ X10_v27-8]) == *([v299 @ X26_v6 (System.Int32)]);\n\tif (v176) goto L_0151;\nL_0163:\n\t;\n\tv982 = *([v967 @ X10_v22-8]) == *([v299 @ X26_v6 (System.Int32)]);\n\tif (v982) goto L_01D9;\nL_018C:\n\tv322 = v67._poolsByIndex;\nL_01AF:\n\t;\n\tv1086 = *([v930 @ X0_v44 (_game.BaseLayerSys\n// ... truncated")]
		public unsafe EntityManager Clone()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::Clone");
			return default;
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0x3C71EF0", Offset = "0x3C71EF0", Length = "0x8C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006D;\n\tv75 = source == this;\n\tif (v75) goto L_0309;\n\tv244 = this._activePools;\n\tv351 = v244.Count < 1;\n\tif (v351) goto L_00E0;\nL_FFFFFFFF:\n\tv491 = 0;\n\tgoto L_00A8;\nL_0092:\n\tv933 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(v602, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool);\n\t*([v933 @ X0_v108 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)])(v704, v602, *([v933 @ X0_v108 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)+8]), 1, v39, v40, v41, v42, v43, 0, v45, v46, v47, v48, v49, v50, v51);\n\tv491 = v491 + 1;\n\tv695 = v491 == v244.Count;\n\tif (v695) goto L_00E0;\nL_00A8:\n\tv602 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(this._activePools, v491);\n\tv900 = *([v602 @ X0_v106 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)]);\n\tv955 = *([v900 @ X8_v90 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]);\n\tv706 = *([v900 @ X8_v90 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]) == 0;\n\tif (v706) goto L_0092;\n\tv673 = *([v900 @ X8_v90 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv673 = v673 + 0x10;\n\tv915 = v955 - 1;\n\tv916 = v955 != 1;\nL_FFFFFFFF:\n\tv955 = v915;\n\tif (v916) goto L_00B7;\n\tgoto L_0092;\nL_00CC:\n\tv981 = *([v673 @ X10_v33]) + 1;\n\tv672 = v981 << 4;\n\tv982 = v900 + v672;\n\tv707 = v982 + 0x138;\n\t*([v707 @ X8_v92])(v703, v602, *([v707 @ X8_v92+8]), Il2CppMethodInfo, v39, v40, v41, v42, v43, 0, v45, v46, v47, v48, v49, v50, v51);\n\tv491 = v491 + 1;\n\tv684 = v491 != v244.Count;\n\tif (v684) goto L_00A8;\nL_00E0:\n\tv308 = this + 0x30;\n\tv603 = this._poolsByIndex;\n\tSystem.Array::Clear(this._poolsByIndex, 0, *([v603 @ X0_v83 (System.Array)+18]));\n\tv642 = this._activePools;\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::Clear(v642);\n\tv496 = v642.Count < 1;\nL_FFFFFFFF:\n\tv290 = 0;\n\tif (v496) goto L_0106;\nL_FFFFFFFF:\n\tv290 = 0;\nL_0106:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this._activeEntities);\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Clear(this._recycledIds);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::Clear(this._generations);\n\tv660 = this._queryCache;\n\tgoto L_0129;\nL_0129:\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::Clear(v660._cache);\n\tthis._nextId = source._nextId;\n\tv1062 = System.Collections.Generic.Queue`1<System.Int32>::GetEnumerator(source._recycledIds);\n\tv782 = v1062;\n\tv1107 = System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>::get_Current(&v782 @ stack_-80_v9 (System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>));\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Enqueue(this._recycledIds, v1107);\n\tgoto L_014A;\nL_015C:\n\tSystem.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v782 @ stack_-80_v9 (System.Collections.Generic.Queue`1<System.Int32>+Enumerator<System.Int32>));\nL_FFFFFFFF:\n\tv406 = 0;\nL_0164:\n\tv1046 = &v406 @ stack_-E0_v9 (System.Int32);\n\tv1047 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::GetEnumerator(source._generations);\n\tv102 = v406.m_value;\n\tv754 = this._generations == 0;\n\tif (v754) goto L_030B;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::set_Item(this._generations, *([v1046 @ X8_v19+10]), v1101);\nL_FFFFFFFF:\n\tv290 = Il2CppMethodInfo;\n\tgoto L_017B;\nL_018B:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>+Enumerator<System.Int32, System.Int32>::Dispose(&v102 @ stack_-A0_v9 (System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>+Enumerator<System.Int32, System.Int32>));\n\tv1113 = System.Collections.Generic.HashSet`1<System.Int32>::GetEnumerator(source._activeEntities);\n\tv98 = v1113;\n\tv826 = this._activeEntities == 0;\n\tif (v826) goto L_030D;\n\tv1125 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this._activeEntities, v1113._current);\n\tgoto L_01A8;\nL_01B7:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v98 @ stack_-C0_v9 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv224 = source._activePools;\n\tv173 = v224.Count < 1;\n\tif (v173) goto L_0309;\nL_FFFFFFFF:\n\tv481 = 0;\n\tgoto L_01E8;\nL_01D4:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::Add(v218, v1196);\n\tv481 = v481 + 1;\n\tv198 = v481 == v224.Count;\n\tif (v198) goto L_0309;\nL_01E8:\n\tv611 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(source._activePools, v481);\n\tv1145 = *([v611 @ X0_v42 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)]);\n\tv1164 = *([v1145 @ X8_v37 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]);\n\tv1147 = *([v1145 @ X8_v37 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]) == 0;\n\tif (v1147) goto L_020C;\n\tv424 = *([v1145 @ X8_v37 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv424 = v424 + 0x10;\n\tv1152 = v1164 - 1;\n\tv1153 = v1164 != 1;\nL_FFFFFFFF:\n\tv1164 = v1152;\n\tif (v1153) goto L_01F2;\nL_020C:\n\tv1162 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(v611, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool);\n\t*([v1162 @ X0_v74 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)])(v1196, v611, *([v1162 @ X0_v74 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)+8]), 7, v290, v40, v41, v42, v43, v1113._set, *([v1046 @ X8_v19+10]), v46, v47, v48, v49, v50, v51);\n\tv1175 = v1196 == 0;\n\tv632 = ~v1175;\nL_FFFFFFFF:\n\tv473 = 7;\n\tif (v632) goto L_0222;\n\tgoto L_030A;\nL_0216:\n\t;\n\tv1178 = *([v424 @ X10_v27]) + 7;\n\tv416 = v1178 << 4;\n\tv1179 = v1145 + v416;\n\tv652 = v1179 + 0x138;\n\t*([v652 @ X8_v67])(v1196, v611, *([v652 @ X8_v67+8]), Il2CppMethodInfo, v290, v40, v41, v42, v43, v1113._set, *([v1046 @ X8_v19+10]), v46, v47, v48, v49, v50, v51);\nL_FFFFFFFF:\n\tv473 = Il2CppMethodInfo;\nL_0222:\n\tv1200 = *([v1196 @ X0_v43 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)]);\n\tv1234 = *([v1200 @ X8_v39 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]);\n\tv1202 = *([v1200 @ X8_v39 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+12E]) == 0;\n\tif (v1202) goto L_0242;\n\tv1233 = *([v1200 @ X8_v39 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv1233 = v1233 + 0x10;\n\tv1210 = v1234 - 1;\n\tv1212 = v1234 != 1;\nL_FFFFFFFF:\n\tv1234 = v1210;\n\tif (v1212) goto L_0228;\nL_0242:\n\tv1231 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::get_Item(v1196, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool);\n\t*([v1231 @ X0_v68 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)])(v1256, v1196, *([v1231 @ X0_v68 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool)+8]), 5, v290, v40, v41, v42, v43, v1113._set, *([v1046 @ X8_v19+10]), v46, v47, v48, v49, v50, v51);\nL_FFFFFFFF:\n\tv367 = v1256;\nL_FFFFFFFF:\n\tv473 = 5;\n\tgoto L_0251;\n\tv1331 = v85.Length;\n\tv1310 = v367 < v85.Length;\n\tif (v1310) goto L_0275;\nL_0262:\n\tv1332 = v1331 << 1;\n\tv1314 = v1331 <= v367;\nL_FFFFFFFF:\n\tv1331 = v1332;\n\tif (v1314) goto L_0262;\n\tSystem.Array::Resize(v308, v1332);\n\tv85 = this._poolsByIndex;\nL_FFFFFFFF:\n\tv473 = Il2CppMethodInfo;\n\tv426 = *([v1352 @ X8_v43 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>)+B0]) + 8;\n\tv426 = v426 + 0x10;\n\tv1358 = v1371 - 1;\n\tv1359 = v1371 != 1;\nL_FFFFFFFF:\n\tv1371 = v1358;\n\tif (v1359) goto L_027B;\nL_0297:\n\t;\n\tv1389 = _game.BaseLayerSystems.EntitySystem.Core.IComponentPool::get_TypeIndex(v1196);\n\tv1382 = v85 == 0;\n\tv634 = ~v1382;\n\tif (v634) goto L_02BC;\n\tgoto L_030A;\nL_029E:\n\t;\n\tv1264 = *([v1233 @ X10_v22]) + 5;\n\tv1265 = v1264 << 4;\n\tv1266 = v1200 + v1265;\n\tv1267 = v1266 + 0x138;\n\t*([v1267 @ X0_v71])(v1271, v1196, *([v1267 @ X0_v71+8]), v473, v290, v40, v41, v42, v43, v\n// ... truncated")]
		public unsafe void RestoreFrom(EntityManager source)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::RestoreFrom");
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0x3C71C98", Offset = "0x3C71C98", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0046;\n\tv90 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::.ctor(v90);\n\tthis._generations = v90;\n\tv107 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v107);\n\tthis._activeEntities = v107;\n\t// 103 NewArr v124 @ X0_v18 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), typeof(_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), 16\n\tthis._poolsByIndex = v124;\n\tv130 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Core.IComponentPool>::.ctor(v130);\n\tthis._activePools = v130;\n\tv142 = new _game.BaseLayerSystems.EntitySystem.Core.QueryCache();\n\tgoto L_0090;\n\tSystem.Object::.ctor(v142);\n\tthis._queryCache = v142;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0046:\n\tthis._nextId = 1;\n\tv73 = new System.Collections.Generic.Queue`1<System.Int32>();\n\tSystem.Collections.Generic.Queue`1<System.Int32>::.ctor(v73);\n\tthis._recycledIds = v73;\nL_0090:\n\tv159 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::.ctor(v159);\n\tv142._cache = v159;\n")]
		public EntityManager()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityManager::.ctor");
		}
	}
}
