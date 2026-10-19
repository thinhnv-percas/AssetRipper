using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.Pooling
{
	[Token(Token = "0x2000126")]
	public class PooledVfxBehaviour : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000127")]
		private sealed class _003CWatchUntilStopped_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40003D3")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40003D4")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40003D5")]
			[FieldOffset(Offset = "0x20")]
			public PooledVfxBehaviour _003C_003E4__this;

			[Token(Token = "0x1700008F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60005FB")]
				[Address(RVA = "0x3DB0C10", Offset = "0x3DB0C10", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000090")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60005FD")]
				[Address(RVA = "0x3DB0C58", Offset = "0x3DB0C58", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60005F8")]
			[Address(RVA = "0x3DB0888", Offset = "0x3DB0888", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CWatchUntilStopped_003Ed__14(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60005F9")]
			[Address(RVA = "0x3DB0AA0", Offset = "0x3DB0AA0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60005FA")]
			[Address(RVA = "0x3DB0AA4", Offset = "0x3DB0AA4", Length = "0x16C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv49 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv55 = _game.CoreSystem.Pooling.PooledVfxBehaviour::IsAnyAlive(this.<>4__this);\n\tv113 = v55 == 0;\n\tif (v113) goto L_004A;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 2;\n\treturn 1;\nL_0036:\n\tv52 = this.<>1__state == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0097;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = -1;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_004A:\n\tv49._watchdog = 0;\n\tv80 = v49.AutoReturnOnStopped != 1;\n\tif (v80) goto L_0097;\n\tv114 = v49._owner == 0;\n\tif (v114) goto L_0097;\n\tv172 = UnityEngine.Component::get_gameObject(this.<>4__this);\n\tgoto L_0090;\nL_0013:\n\tv39 = this.<>1__state - 1;\n\tv40 = v39 < 2;\n\tv41 = ~v40;\n\tif (v41) goto L_0036;\nL_0097:\n\treturn 0;\nL_0090:\n\t_game.CoreSystem.Pooling.IVfxPool::Return(v49._owner, v172, 0f);\n")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state - 1;
				if ((uint)num < 2u)
				{
					PooledVfxBehaviour pooledVfxBehaviour = _003C_003E4__this;
					_003C_003E1__state = -1;
					if (_003C_003E4__this.IsAnyAlive())
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						return true;
					}
					pooledVfxBehaviour._watchdog = null;
					if (pooledVfxBehaviour.AutoReturnOnStopped && pooledVfxBehaviour._owner != null)
					{
						GameObject gameObject = _003C_003E4__this.gameObject;
						pooledVfxBehaviour._owner.Return(gameObject);
					}
				}
				else if (_003C_003E1__state == 0)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = -1;
					_003C_003E1__state = 1;
					return true;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60005FC")]
			[Address(RVA = "0x3DB0C18", Offset = "0x3DB0C18", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40003CE")]
		[FieldOffset(Offset = "0x20")]
		internal IVfxPool _owner;

		[Token(Token = "0x40003CF")]
		[FieldOffset(Offset = "0x28")]
		internal GameObject _prefabKey;

		[Token(Token = "0x40003D0")]
		[FieldOffset(Offset = "0x30")]
		private bool _autoReturnOnStopped;

		[Token(Token = "0x40003D1")]
		[FieldOffset(Offset = "0x38")]
		internal ParticleSystem[] _systems;

		[Token(Token = "0x40003D2")]
		[FieldOffset(Offset = "0x40")]
		private Coroutine _watchdog;

		[Token(Token = "0x1700008D")]
		public GameObject PrefabKey
		{
			[Token(Token = "0x60005ED")]
			[Address(RVA = "0x3DB05A0", Offset = "0x3DB05A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.PrefabKey;\n")]
			get
			{
				return _prefabKey;
			}
		}

		[Token(Token = "0x1700008E")]
		public bool AutoReturnOnStopped
		{
			[Token(Token = "0x60005EE")]
			[Address(RVA = "0x3DB05A8", Offset = "0x3DB05A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.AutoReturnOnStopped;\n")]
			get
			{
				return _autoReturnOnStopped;
			}
			[Token(Token = "0x60005EF")]
			[Address(RVA = "0x3DB05B0", Offset = "0x3DB05B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.AutoReturnOnStopped = value;\n\treturn;\n")]
			set
			{
				_autoReturnOnStopped = value;
			}
		}

		[Token(Token = "0x60005F0")]
		[Address(RVA = "0x3DB05B8", Offset = "0x3DB05B8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis._systems = v63;\n\treturn;\nL_001D:\n\tthis._owner = v47;\n\tthis.PrefabKey = prefabKey;\n\tv63 = UnityEngine.Component::GetComponentsInChildren(this, 1);\n")]
		public void Init(IVfxPool owner, GameObject prefabKey)
		{
			IVfxPool owner2 = default(IVfxPool);
			_owner = owner2;
			_prefabKey = prefabKey;
			ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>(includeInactive: true);
			_systems = componentsInChildren;
		}

		[Token(Token = "0x60005F1")]
		[Address(RVA = "0x3DB0650", Offset = "0x3DB0650", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.AutoReturnOnStopped = 1;\n\treturn;\n")]
		public void ResetForRent()
		{
			AutoReturnOnStopped = true;
		}

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0x3DB065C", Offset = "0x3DB065C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv86 = 0;\n\tgoto L_0029;\nL_001B:\n\tv86 = v86 + 1;\n\tv126 = this._systems;\nL_0029:\n\tv105 = v86 >= v126.Length;\n\tif (v105) goto L_0059;\n\tgoto L_0035;\nL_0035:\n\tv177 = UnityEngine.Object::op_Equality(v126[v86 @ X21_v4 (System.Int32)], 0);\n\tv186 = v177 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_001B;\n\tgoto L_0049;\nL_0049:\n\tUnityEngine.ParticleSystem::Clear(v126[v86 @ X21_v4 (System.Int32)], 1);\n\tUnityEngine.ParticleSystem::Play(v126[v86 @ X21_v4 (System.Int32)], 1);\n\tgoto L_001B;\nL_0059:\n\tv55 = this.AutoReturnOnStopped != 1;\n\tif (v55) goto L_008B;\n\tgoto L_0069;\n\tv223 = UnityEngine.MonoBehaviour::StartCoroutine(this, v198);\n\tthis._watchdog = v223;\n\treturn;\nL_008B:\n\treturn;\nL_0014:\n\tv126 = this._systems;\n\tv43 = this._systems == 0;\n\tif (v43) goto L_008B;\nL_0069:\n\tv198 = new _game.CoreSystem.Pooling.PooledVfxBehaviour+<WatchUntilStopped>d__14();\n\tSystem.Object::.ctor(v198);\n\tv198.<>1__state = 0;\n\tv198.<>4__this = this;\n")]
		private void OnEnable()
		{
			ParticleSystem[] systems = _systems;
			if (_systems == null)
			{
				return;
			}
			int num = 0;
			while (num < systems.Length)
			{
				if (!(systems[num] == null))
				{
					systems[num].Clear(withChildren: true);
					systems[num].Play(withChildren: true);
				}
				num++;
				systems = _systems;
			}
			if (AutoReturnOnStopped)
			{
				_003CWatchUntilStopped_003Ed__14 _003CWatchUntilStopped_003Ed__15 = (_003CWatchUntilStopped_003Ed__14)FormatterServices.GetUninitializedObject(typeof(_003CWatchUntilStopped_003Ed__14));
				_003CWatchUntilStopped_003Ed__15._003C_003E1__state = 0;
				_003CWatchUntilStopped_003Ed__15._003C_003E4__this = this;
				Coroutine watchdog = StartCoroutine(_003CWatchUntilStopped_003Ed__15);
				_watchdog = watchdog;
			}
		}

		[Token(Token = "0x60005F3")]
		[Address(RVA = "0x3DB0840", Offset = "0x3DB0840", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._watchdog == 0;\n\tif (v14) goto L_001D;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this._watchdog);\n\tthis._watchdog = 0;\n\treturn;\nL_001D:\n\treturn;\n")]
		private void OnDisable()
		{
			if (_watchdog != null)
			{
				StopCoroutine(_watchdog);
				_watchdog = null;
			}
		}

		[IteratorStateMachine(typeof(_003CWatchUntilStopped_003Ed__14))]
		[Token(Token = "0x60005F4")]
		[Address(RVA = "0x3DB07C8", Offset = "0x3DB07C8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new _game.CoreSystem.Pooling.PooledVfxBehaviour+<WatchUntilStopped>d__14();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator WatchUntilStopped()
		{
			_003CWatchUntilStopped_003Ed__14 _003CWatchUntilStopped_003Ed__15 = (_003CWatchUntilStopped_003Ed__14)FormatterServices.GetUninitializedObject(typeof(_003CWatchUntilStopped_003Ed__14));
			_003CWatchUntilStopped_003Ed__15._003C_003E1__state = 0;
			_003CWatchUntilStopped_003Ed__15._003C_003E4__this = this;
			return _003CWatchUntilStopped_003Ed__15;
		}

		[Token(Token = "0x60005F5")]
		[Address(RVA = "0x3DB08B4", Offset = "0x3DB08B4", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv100 = 0;\n\tgoto L_0024;\nL_001D:\n\tv100 = v100 + 1;\n\tv106 = this._systems;\nL_0024:\n\tv92 = v100 - v106.Length;\n\tv89 = v92 < 0;\n\tv83 = v100 ^ v106.Length;\n\tv80 = v100 ^ v92;\n\tv77 = v83 & v80;\n\tv74 = v77 < 0;\n\tv111 = v89 == v74;\n\tv112 = ~v111;\n\tv71 = v100 >= v106.Length;\n\tv165 = v112;\n\tif (v71) goto L_005D;\n\tgoto L_003A;\nL_003A:\n\tv174 = UnityEngine.Object::op_Equality(v106[v100 @ X22_v3 (System.Int32)], 0);\n\tv177 = v174 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_001D;\n\tgoto L_004F;\nL_004F:\n\tv168 = UnityEngine.ParticleSystem::IsAlive(v106[v100 @ X22_v3 (System.Int32)], 1);\n\tv169 = v168 == 0;\n\tv165 = 1;\n\tif (v169) goto L_001D;\nL_005D:\n\treturn v165;\nL_0069:\n\treturn 0;\nL_0016:\n\tv106 = this._systems;\n\tv47 = this._systems == 0;\n\tif (v47) goto L_0069;\n")]
		private bool IsAnyAlive()
		{
			ParticleSystem[] systems = _systems;
			if (_systems != null)
			{
				int num = 0;
				bool result;
				while (true)
				{
					int num2 = num - systems.Length;
					bool flag = num2 < 0;
					int num3 = num ^ systems.Length;
					int num4 = num ^ num2;
					int num5 = num3 & num4;
					bool flag2 = num5 < 0;
					bool flag3 = flag == flag2;
					bool flag4 = !flag3;
					bool flag5 = num >= systems.Length;
					result = flag4;
					if (flag5)
					{
						break;
					}
					if (!(systems[num] == null))
					{
						bool flag6 = systems[num].IsAlive(withChildren: true);
						bool flag7 = !flag6;
						result = true;
						if (!flag7)
						{
							break;
						}
					}
					num++;
					systems = _systems;
				}
				return result;
			}
			return false;
		}

		[Token(Token = "0x60005F6")]
		[Address(RVA = "0x3DB09B8", Offset = "0x3DB09B8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv88 = 0;\n\tgoto L_0029;\nL_001B:\n\tv88 = v88 + 1;\n\tv94 = this._systems;\nL_0029:\n\tv57 = v88 >= v94.Length;\n\tif (v57) goto L_0053;\n\tgoto L_0035;\nL_0035:\n\tv160 = UnityEngine.Object::op_Equality(v94[v88 @ X21_v4 (System.Int32)], 0);\n\tv163 = v160 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_001B;\n\tgoto L_004A;\nL_004A:\n\tUnityEngine.ParticleSystem::Stop(v94[v88 @ X21_v4 (System.Int32)], 1, 0);\n\tgoto L_001B;\nL_0053:\n\treturn;\nL_0014:\n\tv94 = this._systems;\n\tv43 = this._systems == 0;\n\tif (v43) goto L_0053;\n")]
		public void StopAllSystems()
		{
			ParticleSystem[] systems = _systems;
			if (_systems == null)
			{
				return;
			}
			int num = 0;
			while (num < systems.Length)
			{
				if (!(systems[num] == null))
				{
					systems[num].Stop(withChildren: true, default(ParticleSystemStopBehavior));
				}
				num++;
				systems = _systems;
			}
		}

		[Token(Token = "0x60005F7")]
		[Address(RVA = "0x3DB0A90", Offset = "0x3DB0A90", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.AutoReturnOnStopped = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public PooledVfxBehaviour()
		{
			AutoReturnOnStopped = true;
		}
	}
}
