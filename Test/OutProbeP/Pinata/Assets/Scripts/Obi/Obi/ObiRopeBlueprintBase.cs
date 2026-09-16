using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Obi
{
	[Token(Token = "0x2000065")]
	public abstract class ObiRopeBlueprintBase : ObiActorBlueprint
	{
		[CompilerGenerated]
		[Token(Token = "0x20000C9")]
		private sealed class _003CInitialize_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400034D")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400034E")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x170000EE")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60005B0")]
				[Address(RVA = "0xC3ABE0", Offset = "0xC3ABE0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170000EF")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60005B2")]
				[Address(RVA = "0xC3AC4C", Offset = "0xC3AC4C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60005AD")]
			[Address(RVA = "0xC3AB74", Offset = "0xC3AB74", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CInitialize_003Ed__16(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60005AE")]
			[Address(RVA = "0xC3ABA0", Offset = "0xC3ABA0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60005AF")]
			[Address(RVA = "0xC3ABA4", Offset = "0xC3ABA4", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.<>1__state == 1;\n\tif (v7) goto L_FFFFFFFF;\n\tv12 = this.<>1__state == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0018;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tthis.<>2__current = 0;\n\tgoto L_0016;\nL_0016:\n\tthis.<>1__state = v23;\nL_0018:\n\treturn v20;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				bool result;
				int num;
				int num2;
				if (_003C_003E1__state != 1)
				{
					bool flag = _003C_003E1__state == 0;
					bool flag2 = !flag;
					result = false;
					if (flag2)
					{
						goto IL_0092;
					}
					_003C_003E1__state = -1;
					_003C_003E2__current = null;
					num = 1;
					num2 = 1;
				}
				else
				{
					num = 0;
					num2 = -1;
				}
				_003C_003E1__state = num2;
				result = (byte)num != 0;
				goto IL_0092;
				IL_0092:
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60005B1")]
			[Address(RVA = "0xC3ABE8", Offset = "0xC3ABE8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EE1528]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20231D0]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}
		}

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001D8")]
		[FieldOffset(Offset = "0x100")]
		public ObiPath path;

		[Token(Token = "0x40001D9")]
		[FieldOffset(Offset = "0x108")]
		public float thickness;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x74668C", Offset = "0x74668C")]
		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x10C")]
		public float resolution;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x110")]
		protected float m_InterParticleDistance;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x114")]
		protected internal int totalParticles;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x118")]
		protected internal float m_RestLength;

		[HideInInspector]
		[Token(Token = "0x40001DE")]
		[FieldOffset(Offset = "0x120")]
		public float[] restLengths;

		[Token(Token = "0x170000B1")]
		public float interParticleDistance
		{
			[Token(Token = "0x6000452")]
			[Address(RVA = "0xC3A888", Offset = "0xC3A888", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_InterParticleDistance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return interParticleDistance;
			}
		}

		[Token(Token = "0x170000B2")]
		public float restLength
		{
			[Token(Token = "0x6000453")]
			[Address(RVA = "0xC3A890", Offset = "0xC3A890", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_RestLength;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return restLength;
			}
		}

		[Token(Token = "0x6000454")]
		[Address(RVA = "0xC3A898", Offset = "0xC3A898", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB8938]);\n\tv27 = *([v26 @ X8_v25]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20231CD]) = v46;\nL_0017:\n\tv47 = this.path;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v47.OnPathChanged);\n\tv111 = this.path;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v111.OnControlPointAdded);\n\tv112 = this.path;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v112.OnControlPointRemoved);\n\tv113 = this.path;\n\tUnityEngine.Events.UnityEventBase::RemoveAllListeners(v113.OnControlPointRenamed);\n\tv114 = this.path;\n\tv91 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v91, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v114.OnPathChanged, v91);\n\tv116 = this.path;\n\tv93 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v93, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v116.OnControlPointAdded, v93);\n\tv118 = this.path;\n\tv95 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v95, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v118.OnControlPointRemoved, v95);\n\tv120 = this.path;\n\tv97 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v97, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v120.OnControlPointRenamed, v97);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ObiPath obiPath = path;
			obiPath.OnPathChanged.RemoveAllListeners();
			ObiPath obiPath2 = path;
			obiPath2.OnControlPointAdded.RemoveAllListeners();
			ObiPath obiPath3 = path;
			obiPath3.OnControlPointRemoved.RemoveAllListeners();
			ObiPath obiPath4 = path;
			obiPath4.OnControlPointRenamed.RemoveAllListeners();
			ObiPath obiPath5 = path;
			UnityAction call = base.GenerateImmediate;
			obiPath5.OnPathChanged.AddListener(call);
			ObiPath obiPath6 = path;
			UnityAction<int> call2 = ControlPointAdded;
			obiPath6.OnControlPointAdded.AddListener(call2);
			ObiPath obiPath7 = path;
			UnityAction<int> call3 = ControlPointRemoved;
			obiPath7.OnControlPointRemoved.AddListener(call3);
			ObiPath obiPath8 = path;
			UnityAction<int> call4 = ControlPointRenamed;
			obiPath8.OnControlPointRenamed.AddListener(call4);
		}

		[Token(Token = "0x6000455")]
		[Address(RVA = "0xC3AA7C", Offset = "0xC3AA7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActorBlueprint::GenerateImmediate(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnValidate()
		{
			GenerateImmediate();
		}

		[Token(Token = "0x6000456")]
		[Address(RVA = "0xC3AA84", Offset = "0xC3AA84", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Obi.ObiPath::GetName(this.path, index);\n\tv41 = Obi.ObiActorBlueprint::InsertNewParticleGroup(this, v17, index);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ControlPointAdded(int index)
		{
			string text = path.GetName(index);
			ObiParticleGroup obiParticleGroup = InsertNewParticleGroup(text, index);
		}

		[Token(Token = "0x6000457")]
		[Address(RVA = "0xC3AAC8", Offset = "0xC3AAC8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Obi.ObiPath::GetName(this.path, index);\n\tv41 = Obi.ObiActorBlueprint::SetParticleGroupName(this, index, v17);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ControlPointRenamed(int index)
		{
			string text = path.GetName(index);
			bool flag = SetParticleGroupName(index, text);
		}

		[Token(Token = "0x6000458")]
		[Address(RVA = "0xC3AB0C", Offset = "0xC3AB0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = Obi.ObiActorBlueprint::RemoveParticleGroupAt(this, index);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ControlPointRemoved(int index)
		{
			bool flag = RemoveParticleGroupAt(index);
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x74784C", Offset = "0x74784C")]
		[Token(Token = "0x6000459")]
		[Address(RVA = "0xC3AB14", Offset = "0xC3AB14", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC4A40]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20231CE]) = v35;\nL_0014:\n\tv39 = new Obi.ObiRopeBlueprintBase+<Initialize>d__16();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override IEnumerator Initialize()
		{
			//yield-return decompiler failed: Unable to find new state assignment for yield return
			return new _003CInitialize_003Ed__16(0);
		}

		[Token(Token = "0x600045A")]
		[Address(RVA = "0xC344D4", Offset = "0xC344D4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC7880]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231CF]) = v38;\nL_0016:\n\tv42 = new Obi.ObiPath();\n\tObi.ObiPath::.ctor(v42);\n\tthis.path = v42;\n\tthis.thickness = 0.1f;\n\tObi.ObiActorBlueprint::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiRopeBlueprintBase()
		{
			ObiPath obiPath = new ObiPath();
			path = obiPath;
			thickness = 0.1f;
		}
	}
}
