using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x200006D")]
	public class ComponentPool<T> where T : struct
	{
		[CompilerGenerated]
		[Token(Token = "0x200006E")]
		private sealed class _003CGetEntityIndices_003Ed__18 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400010D")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x400010E")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E2__current;

			[Token(Token = "0x400010F")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x4000110")]
			[FieldOffset(Offset = "0x0")]
			public ComponentPool<T> _003C_003E4__this;

			[Token(Token = "0x4000111")]
			[FieldOffset(Offset = "0x0")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x1700003B")]
			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000193")]
				[Address(RVA = "0x7268800", Offset = "0x7268800", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700003C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000195")]
				[Address(RVA = "0x7268840", Offset = "0x7268840", Length = "0x34")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.<>2__current;\n\tv10 = 0xB7D5000 + 0x538;\n\treturnVal1 = \"il2cpp_vm_object_box\"(*([v10 @ X8_v3 (System.Int32)+48]), &v8 @ stack_-14_v1 (System.Int32), v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\treturn returnVal1;\n")]
				get
				{
					int num = _003C_003E2__current;
					int num2 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object result = default(object);
					return result;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000190")]
			[Address(RVA = "0x7268730", Offset = "0x7268730", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetEntityIndices_003Ed__18(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000191")]
			[Address(RVA = "0x7268768", Offset = "0x7268768", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000192")]
			[Address(RVA = "0x726876C", Offset = "0x726876C", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv49 = this.<>1__state;\n\tv8 = this.<>4__this;\n\tv13 = this.<>1__state == 1;\n\tif (v13) goto L_0018;\n\tv18 = v49 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0047;\n\tthis.<>1__state = -1;\n\tthis.<i>5__2 = 0;\n\tgoto L_0028;\nL_0018:\n\tthis.<>1__state = -1;\n\tv49 = this.<i>5__2 + 1;\n\tthis.<i>5__2 = v49;\nL_0028:\n\tv26 = v49 >= v8.Count;\n\tif (v26) goto L_0047;\n\tv116 = v8._denseToEntity;\n\tthis.<>1__state = 1;\n\tthis.<>2__current = v116[v49 @ X9_v2 (System.Int32)];\n\treturn 1;\nL_0047:\n\treturn 0;\n")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				ComponentPool<T> componentPool = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (num != 0)
					{
						goto IL_00fa;
					}
					_003C_003E1__state = -1;
					_003Ci_003E5__2 = 0;
				}
				else
				{
					_003C_003E1__state = -1;
					num = ++_003Ci_003E5__2;
				}
				if (num < componentPool.Count)
				{
					int[] denseToEntity = componentPool._denseToEntity;
					_003C_003E1__state = 1;
					_003C_003E2__current = denseToEntity[num];
					return true;
				}
				goto IL_00fa;
				IL_00fa:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000194")]
			[Address(RVA = "0x7268808", Offset = "0x7268808", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000196")]
			[Address(RVA = "0x7268874", Offset = "0x7268874", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = this.<>1__state != -2;\n\tif (v29) goto L_0037;\n\tv32 = System.Environment::get_CurrentManagedThreadId();\n\tv36 = this.<>l__initialThreadId != v32;\n\tif (v36) goto L_0037;\n\tthis.<>1__state = 0;\n\treturn this;\nL_0037:\n\tgoto L_0039;\nL_0039:\n\tv78 = new Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>+<GetEntityIndices>d__18<T>>();\n\tSystem.Object::.ctor(v78);\n\t*([v78 @ X0_v4 (System.Object)+10]) = 0;\n\tv116 = System.Environment::get_CurrentManagedThreadId();\n\t*([v78 @ X0_v4 (System.Object)+18]) = v116;\n\t*([v78 @ X0_v4 (System.Object)+20]) = this.<>4__this;\n\treturn v78;\n")]
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				//IL_0076: Expected O, but got I
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				object result = (nint)(IntPtr)FormatterServices.GetUninitializedObject(typeof(IntPtr));
				_ = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_ = _003C_003E4__this;
				return (IEnumerator<int>)result;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000197")]
			[Address(RVA = "0x7268928", Offset = "0x7268928", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>+<GetEntityIndices>d__18<T>::System.Collections.Generic.IEnumerable<System.Int32>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<int>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x4000107")]
		private const int DefaultCapacity = 64;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x0")]
		private int[] _sparse;

		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x0")]
		private T[] _dense;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x0")]
		private int[] _denseToEntity;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x0")]
		private int _count;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x0")]
		private int _version;

		[Token(Token = "0x17000039")]
		public int Count
		{
			[Token(Token = "0x6000180")]
			[Address(RVA = "0x70D15B0", Offset = "0x70D15B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Count;\n")]
			get
			{
				return _count;
			}
		}

		[Token(Token = "0x1700003A")]
		public int Version
		{
			[Token(Token = "0x6000181")]
			[Address(RVA = "0x70D15B8", Offset = "0x70D15B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Version;\n")]
			get
			{
				return _version;
			}
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x70D15C0", Offset = "0x70D15C0", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xB794000;\n\tv22 = *([B79437D]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_005B;\n\tSystem.Object::.ctor(this);\n\tgoto L_0018;\nL_0018:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tv62 = *([v59 @ X0_v38 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv83 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tif (v63) goto L_006E;\nL_0020:\n\tgoto L_0028;\nL_0028:\n\tgoto L_0030;\nL_0030:\n\tthis._sparse = v130.Value;\n\tgoto L_003D;\nL_003D:\n\t// 61 NewArr v149 @ X0_v23 (T[]), typeof(Il2CppClass<T[]>), 64\n\tthis._dense = v149;\n\t// 69 NewArr v156 @ X0_v28 (System.Int32[]), typeof(System.Int32[]), 64\n\tthis._denseToEntity = v156;\n\tthis.Count = 0;\n\treturn;\nL_005B:\n\t*([v18 @ X22_v1+37D]) = 1;\n\tSystem.Object::.ctor(this);\n\tgoto L_0018;\n\tv70 = System.Array::Empty();\n\tv74 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tv90 = *([v74 @ X0_v9 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]) & 1;\n\tv91 = v90 == 0;\n\tv76 = ~v91;\n\tv83 = Il2CppClass<System.EmptyArray`1<System.Int32>>;\n\tif (v76) goto L_0020;\nL_006E:\n\tv87 = 0x220C238(v83, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv113 = *([v87 @ X0_v5+E4]) == 0;\n\tv96 = ~v113;\n\tif (v96) goto L_0028;\n\tgoto L_007B;\nL_007B:\n\tgoto L_0030;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ComponentPool()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192495616;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B79437D]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
			}
			else
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v38 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]");
			bool flag = (int)((nint)0 & (nint)1) == 0;
			nint num2 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			_sparse = Array.Empty<int>();
			_dense = null;
			_denseToEntity = new int[64];
			_count = 0;
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x70D1730", Offset = "0x70D1730", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1::EnsureSparseCapacity /* +1 sharing this address */(this, id, component);\n\tv28 = id & 0x80000000;\n\tv29 = v28 == 0;\n\tv30 = ~v29;\n\tif (v30) goto L_0074;\n\tv31 = this._sparse;\n\tv42 = id >= v31.Length;\n\tif (v42) goto L_0074;\n\tv88 = id & 0x7FFFFFFF;\n\tv193 = v31[v88 @ X10_v8 (System.Int32)] & 0x80000000;\n\tv194 = v193 == 0;\n\tv95 = ~v194;\n\tif (v95) goto L_0074;\n\tv43 = v31[v88 @ X10_v8 (System.Int32)] >= this.Count;\n\tif (v43) goto L_0074;\n\tv152 = this._denseToEntity;\n\tv44 = v152[v31[v88 @ X10_v8 (System.Int32)]] != id;\n\tif (v44) goto L_0074;\n\tv291 = this._dense + v31[v88 @ X10_v8 (System.Int32)];\n\t*([v291 @ X8_v20+20]) = component;\n\treturn;\nL_0074:\n\tgoto L_007B;\n\tv171 = this.Count;\n\tv118 = this.Count < v158.Length;\n\tif (v118) goto L_009B;\n\tv249 = v158.Length << 1;\n\tSystem.Array::Resize(v173, v249);\n\tv257 = this + 0x20;\n\tSystem.Array::Resize(v257, v249);\n\tv171 = this.Count;\n\tv159[id @ X1 (_game.BaseLayerSystems.EntitySystem.Core.EntityId)] = v171;\n\tv315 = *([v173 @ X22_v6 (_game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components.AtGateTag_Headless[]&)]) + this.Count;\n\t*([v315 @ X8_v10+20]) = component;\n\tv169 = this._denseToEntity;\n\tv239 = this.Count;\n\tv169[v239 @ X9_v9 (System.Int32)] = id;\n\tv262 = this.Count + 1;\n\tthis.Count = v262;\n\treturn;\nL_007B:\n\tv173 = this + 0x18;\n\tv158 = *([v173 @ X22_v6 (_game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components.AtGateTag_Headless[]&)]);\nL_009B:\n\tv159 = this._sparse;\n")]
		public unsafe void Add(EntityId id, T component)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::Add");
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x70D18E8", Offset = "0x70D18E8", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = id & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_00A6;\n\tv103 = this._sparse;\n\tv48 = id >= v103.Length;\n\tif (v48) goto L_00A6;\n\tv44 = id & 0x7FFFFFFF;\n\tv36 = v103[v44 @ X8_v4 (System.Int32)];\n\tv224 = v103[v44 @ X8_v4 (System.Int32)] & 0x80000000;\n\tv225 = v224 == 0;\n\tv107 = ~v225;\n\tif (v107) goto L_00A6;\n\tv49 = v103[v44 @ X8_v4 (System.Int32)] >= this.Count;\n\tif (v49) goto L_00A6;\n\tv115 = this._denseToEntity;\n\tv46 = v115[v103[v44 @ X8_v4 (System.Int32)]] != id;\n\tif (v46) goto L_00A6;\n\tv30 = this.Count - 1;\n\tv249 = v103[v44 @ X8_v4 (System.Int32)] < v30;\n\tv250 = ~v249;\n\tif (v250) goto L_009D;\n\tv273 = this._dense + 0x20;\n\t*([v273 @ X10_v7+v36 @ X9_v5 (System.Int32)]) = *([v273 @ X10_v7+v30 @ X13_v5 (System.Int32)]);\n\tv160 = this._denseToEntity;\n\tv160[v103[v44 @ X8_v4 (System.Int32)]] = v115[v30 @ X13_v5 (System.Int32)];\n\tv161 = this._sparse;\n\tv161[v115[v30 @ X13_v5 (System.Int32)]] = v103[v44 @ X8_v4 (System.Int32)];\n\tv103 = v161;\nL_009D:\n\tv103[v44 @ X8_v4 (System.Int32)] = -1;\n\tv17 = this.Count + 4.2439915814E-314d;\n\tthis.Count = v17;\nL_00A6:\n\treturn;\n")]
		public void Remove(EntityId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::Remove");
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x70D19F4", Offset = "0x70D19F4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = id & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_005F;\n\tv10 = this._sparse;\n\tv22 = id >= v10.Length;\n\tif (v22) goto L_005F;\n\tv68 = id & 0x7FFFFFFF;\n\tv159 = v10[v68 @ X9_v5 (System.Int32)] & 0x80000000;\n\tv160 = v159 == 0;\n\tv75 = ~v160;\n\tif (v75) goto L_005F;\n\tv23 = v10[v68 @ X9_v5 (System.Int32)] >= this.Count;\n\tif (v23) goto L_005F;\n\tv93 = this._denseToEntity;\n\tv24 = v93[v10[v68 @ X9_v5 (System.Int32)]] != id;\n\tif (v24) goto L_005F;\n\tv152 = this._dense + v10[v68 @ X9_v5 (System.Int32)];\n\treturn *([v152 @ X8_v7+20]);\nL_005F:\n\treturn 0;\n")]
		public T Get(EntityId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::Get");
			return default;
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x70D1A8C", Offset = "0x70D1A8C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = id & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_005F;\n\tv10 = this._sparse;\n\tv22 = id >= v10.Length;\n\tif (v22) goto L_005F;\n\tv68 = id & 0x7FFFFFFF;\n\tv160 = v10[v68 @ X9_v5 (System.Int32)] & 0x80000000;\n\tv161 = v160 == 0;\n\tv75 = ~v161;\n\tif (v75) goto L_005F;\n\tv23 = v10[v68 @ X9_v5 (System.Int32)] >= this.Count;\n\tif (v23) goto L_005F;\n\tv95 = this._denseToEntity;\n\tv24 = v95[v10[v68 @ X9_v5 (System.Int32)]] != id;\n\tif (v24) goto L_005F;\n\tv176 = this._dense + v10[v68 @ X9_v5 (System.Int32)];\n\t*([component @ X2 (T&)]) = *([v176 @ X8_v8+20]);\n\treturn 1;\nL_005F:\n\t*([component @ X2 (T&)]) = 0;\n\treturn 0;\n")]
		public bool TryGet(EntityId id, out T component)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::TryGet");
			component = default;
			return default;
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x70D1B34", Offset = "0x70D1B34", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = id & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_004E;\n\tv10 = this._sparse;\n\tv18 = id >= v10.Length;\n\tif (v18) goto L_004E;\n\tv55 = id & 0x7FFFFFFF;\n\tv144 = v10[v55 @ X9_v5 (System.Int32)] & 0x80000000;\n\tv145 = v144 == 0;\n\tv61 = ~v145;\n\tif (v61) goto L_004E;\n\tv19 = v10[v55 @ X9_v5 (System.Int32)] >= this.Count;\n\tif (v19) goto L_004E;\n\tv77 = this._denseToEntity;\n\tv129 = v77[v10[v55 @ X9_v5 (System.Int32)]] - id;\n\tv123 = v129 == 0;\n\treturn v123;\nL_004E:\n\treturn 0;\n")]
		public bool Has(EntityId id)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::Has");
			return default;
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0x70D1BB0", Offset = "0x70D1BB0", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = id & 0x80000000;\n\tv19 = v17 == 0;\n\tv20 = ~v19;\n\tif (v20) goto L_0068;\n\tv21 = this._sparse;\n\tv33 = id >= v21.Length;\n\tif (v33) goto L_0068;\n\tv79 = id & 0x7FFFFFFF;\n\tv155 = v21[v79 @ X10_v5 (System.Int32)] & 0x80000000;\n\tv156 = v155 == 0;\n\tv86 = ~v156;\n\tif (v86) goto L_0068;\n\tv34 = v21[v79 @ X10_v5 (System.Int32)] >= this.Count;\n\tif (v34) goto L_0068;\n\tv142 = this._denseToEntity;\n\tv35 = v142[v21[v79 @ X10_v5 (System.Int32)]] != id;\n\tif (v35) goto L_0068;\n\tv241 = this._dense + v21[v79 @ X10_v5 (System.Int32)];\n\t*([v241 @ X8_v9+20]) = component;\n\treturn;\nL_0068:\n\tv91 = 0xB7D5000 + 0x538;\n\tv95 = 0x317666C(*([v91 @ X8_v6 (System.Int32)+E0]), id, component, methodInfo, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107, v108);\n\tv153 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv201 = 0x3175AC4(v153, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv205 = System.Reflection.MemberInfo::get_Name(v153);\n\tv118 = id;\n\tid.Generation = id.Generation;\n\tv208 = 0xB28D000 + 0xE20;\n\tv245 = \"il2cpp_vm_object_box\"(v208, &v118 @ stack_-38_v3 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv249 = 0xB2ED000 + 0xFE8;\n\tv255 = System.String::Format(v249, v205, v245);\n\tv257 = 0xB290000 + 0xB18;\n\tv260 = new v257();\n\tSystem.InvalidOperationException::.ctor(v260, v255);\n\tthrow v260;\n")]
		public void Set(EntityId id, T component)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::Set");
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x70D1D0C", Offset = "0x70D1D0C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv42 = this.Count < v38.Length;\n\tv43 = ~v42;\n\tv44 = this.Count - v38.Length;\n\tv46 = v44 == 0;\n\tv51 = ~v43;\n\tv52 = v51 | v46;\n\tif (v52) goto L_0027;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002E:\n\tv53 = this.Count == 0;\n\tif (v53) goto L_0039;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0039:\n\treturn 0;\nL_0012:\n\tv38 = this._denseToEntity;\n\tv40 = this._denseToEntity == 0;\n\tif (v40) goto L_002E;\nL_0027:\n\treturnVal1 = this._denseToEntity + 0x20;\n\treturn returnVal1;\n")]
		public ReadOnlySpan<int> GetEntityIndicesSpan()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::GetEntityIndicesSpan");
			return default;
		}

		[IteratorStateMachine(typeof(ComponentPool<>._003CGetEntityIndices_003Ed__18))]
		[Token(Token = "0x600018A")]
		[Address(RVA = "0x70D1D94", Offset = "0x70D1D94", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>+<GetEntityIndices>d__18<T>>();\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>+<GetEntityIndices>d__18<T>::.ctor(v42, -2);\n\tv48 = v42 == 0;\n\tif (v48) goto L_002B;\n\t*([v42 @ X0_v3 (System.Collections.Generic.IEnumerable`1<System.Int32>)+20]) = this;\n\treturn v42;\nL_002B:\n\tthrow v42;\n")]
		public IEnumerable<int> GetEntityIndices()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::GetEntityIndices");
			return default;
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x70D1E10", Offset = "0x70D1E10", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv85 = this.Count;\n\tv18 = this.Count < 1;\n\tif (v18) goto L_0050;\n\tv19 = this._denseToEntity;\n\tv46 = 0;\n\tgoto L_0033;\nL_001B:\n\tv34[v19[v46 @ X9_v4 (System.Int32)]] = -1;\n\tv85 = this.Count;\nL_0033:\n\tv34 = this._sparse;\n\tv188 = v19[v46 @ X9_v4 (System.Int32)] >= v34.Length;\n\tif (v188) goto L_001D;\n\tv189 = v19[v46 @ X9_v4 (System.Int32)] < v34.Length;\n\tv178 = ~v189;\n\tv170 = ~v178;\n\tif (v170) goto L_001B;\n\tv22 = new System.IndexOutOfRangeException();\nL_0050:\n\tv87 = *([v22 @ X0_v3 (System.IndexOutOfRangeException)+2C]) + 1;\n\t*([v22 @ X0_v3 (System.IndexOutOfRangeException)+28]) = 0;\n\t*([v22 @ X0_v3 (System.IndexOutOfRangeException)+2C]) = v87;\n\treturn;\nL_001D:\n\tv46 = v46 + 1;\n\tv58 = v46 >= v85;\n\tif (v58) goto L_0050;\n")]
		public void Clear()
		{
			//IL_010a: Expected O, but got I
			int count = Count;
			if (Count >= 1)
			{
				int[] denseToEntity = _denseToEntity;
				int num = 0;
				do
				{
					int[] sparse = _sparse;
					if (denseToEntity[num] < sparse.Length)
					{
						if ((uint)denseToEntity[num] >= (uint)sparse.Length)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							break;
						}
						sparse[denseToEntity[num]] = -1;
						count = Count;
					}
					num++;
				}
				while (num < count);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X0_v3 (System.IndexOutOfRangeException)+2C]");
			object obj = (nint)0 + (nint)1;
			_ = 0;
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0x70D1E9C", Offset = "0x70D1E9C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\t// 31 NewArr v54 @ X0_v5 (System.Int32[]), typeof(System.Int32[]), v48.Length\n\ttarget._sparse = v54;\n\tv69 = this._sparse;\n\tSystem.Array::Copy(this._sparse, target._sparse, *([v69 @ X0_v8 (System.Array)+18]));\n\tv84 = this._dense;\n\tgoto L_003D;\nL_003D:\n\t// 61 NewArr v127 @ X0_v11 (T[]), typeof(Il2CppClass<T[]>), v84.Length\n\ttarget._dense = v127;\n\tv70 = this._dense;\n\tSystem.Array::Copy(this._dense, target._dense, *([v70 @ X0_v14 (System.Array)+18]));\n\tv81 = this._denseToEntity;\n\t// 80 NewArr v133 @ X0_v16 (System.Int32[]), typeof(System.Int32[]), v81.Length\n\ttarget._denseToEntity = v133;\n\tv71 = this._denseToEntity;\n\tSystem.Array::Copy(this._denseToEntity, target._denseToEntity, *([v71 @ X0_v20 (System.Array)+18]));\n\ttarget.Count = this.Count;\n\ttarget.Version = 0;\n\treturn;\nL_0018:\n\tv48 = this._sparse;\n")]
		public void CopyTo(ComponentPool<T> target)
		{
			int[] sparse = _sparse;
			int[] sparse2 = new int[sparse.Length];
			target._sparse = sparse2;
			Array sparse3 = _sparse;
			int[] sparse4 = _sparse;
			int[] sparse5 = target._sparse;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X0_v8 (System.Array)+18]");
			Array.Copy(sparse4, sparse5, 0);
			T[] dense = _dense;
			T[] dense2 = null;
			target._dense = dense2;
			Array dense3 = _dense;
			T[] dense4 = _dense;
			T[] dense5 = target._dense;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X0_v14 (System.Array)+18]");
			Array.Copy(dense4, dense5, 0);
			int[] denseToEntity = _denseToEntity;
			int[] denseToEntity2 = new int[denseToEntity.Length];
			target._denseToEntity = denseToEntity2;
			Array denseToEntity3 = _denseToEntity;
			int[] denseToEntity4 = _denseToEntity;
			int[] denseToEntity5 = target._denseToEntity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v20 (System.Array)+18]");
			Array.Copy(denseToEntity4, denseToEntity5, 0);
			target._count = Count;
			target._version = 0;
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x70D1FDC", Offset = "0x70D1FDC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv62 = v45.Length <= index;\n\tif (v62) goto L_003F;\n\treturn;\nL_003F:\n\tv68 = v45.Length != 0;\n\tif (v68) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv106 = 0x40;\n\tgoto L_004B;\nL_FFFFFFFF:\n\tv106 = v45.Length;\nL_004D:\n\tv164 = index + 1;\n\tv167 = System.Math::Max(v106, v164);\n\tv168 = v167 - 1;\n\tv169 = v168 | v168;\n\tv170 = v169 | v169;\n\tv171 = v170 | v170;\n\tv172 = v171 | v171;\n\tv173 = v172 | v172;\n\tv176 = v173 + 1;\n\t// 91 NewArr v177 @ X0_v9 (System.Int32[]), typeof(System.Int32[]), v176 @ X1_v3 (System.Int32)\n\tSystem.Array::Fill(v177, -1);\n\tv100 = this._sparse;\n\tv144 = *([v100 @ X0_v10 (System.Array)+18]) == 0;\n\tif (v144) goto L_006B;\n\tSystem.Array::Copy(v100, v177, *([v100 @ X0_v10 (System.Array)+18]));\nL_006B:\n\tthis._sparse = v177;\n\treturn;\nL_001C:\n\tv45 = this._sparse;\nL_004B:\n\tgoto L_004D;\n")]
		private void EnsureSparseCapacity(int index)
		{
			int[] sparse = _sparse;
			if (sparse.Length <= index)
			{
				int val = ((sparse.Length != 0) ? sparse.Length : 64);
				int val2 = index + 1;
				int num = Math.Max(val, val2);
				int num2 = num - 1;
				int num3 = num2 | num2;
				int num4 = num3 | num3;
				int num5 = num4 | num4;
				int num6 = num5 | num5;
				int num7 = num6 | num6;
				int num8 = num7 + 1;
				int[] array = new int[num8];
				Array.Fill(array, -1);
				Array sparse2 = _sparse;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X0_v10 (System.Array)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X0_v10 (System.Array)+18]");
					Array.Copy(sparse2, array, 0);
				}
				_sparse = array;
			}
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0x70D2104", Offset = "0x70D2104", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv58 = this.Count >= v45.Length;\n\tif (v58) goto L_002F;\n\treturn;\nL_002F:\n\tv66 = v45.Length << 1;\n\tSystem.Array::Resize(v44, v66);\n\tv100 = this + 0x20;\n\tSystem.Array::Resize(v100, v66);\n\treturn;\nL_0016:\n\tv44 = this + 0x18;\n\tv45 = *([v44 @ X0_v3 (_game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Components.AtGateTag_Headless[]&)]);\n")]
		private unsafe void EnsureDenseCapacity()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPool::EnsureDenseCapacity");
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0x70D21A8", Offset = "0x70D21A8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = v - 1;\n\tv2 = v0 | v0;\n\tv3 = v2 | v2;\n\tv4 = v3 | v3;\n\tv5 = v4 | v4;\n\tv6 = v5 | v5;\n\treturnVal1 = v6 + 1;\n\treturn returnVal1;\n")]
		private static int NextPowerOfTwo(int v)
		{
			int num = v - 1;
			int num2 = num | num;
			int num3 = num2 | num2;
			int num4 = num3 | num3;
			int num5 = num4 | num4;
			int num6 = num5 | num5;
			return num6 + 1;
		}
	}
}
