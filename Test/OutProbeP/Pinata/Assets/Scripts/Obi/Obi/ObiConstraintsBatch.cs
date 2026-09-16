using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200000C")]
	public abstract class ObiConstraintsBatch : IObiConstraintsBatch
	{
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x10")]
		protected internal ObiConstraintsBatch source;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x18")]
		protected IntPtr batch;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x20")]
		protected List<int> m_IDs;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x28")]
		protected List<int> m_IDToIndex;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x30")]
		protected int m_ConstraintCount;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x34")]
		protected int m_ActiveConstraintCount;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x38")]
		protected int m_InitialActiveConstraintCount;

		[HideInInspector]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x40")]
		public ObiNativeIntList particleIndices;

		[Token(Token = "0x17000018")]
		public int constraintCount
		{
			[Token(Token = "0x6000138")]
			[Address(RVA = "0xE42BC0", Offset = "0xE42BC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ConstraintCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return constraintCount;
			}
		}

		[Token(Token = "0x17000019")]
		public int activeConstraintCount
		{
			[Token(Token = "0x6000139")]
			[Address(RVA = "0xE42BC8", Offset = "0xE42BC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ActiveConstraintCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return activeConstraintCount;
			}
			[Token(Token = "0x600013A")]
			[Address(RVA = "0xE42BD0", Offset = "0xE42BD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_ActiveConstraintCount = value;\n\treturn;\n")]
			set
			{
				activeConstraintCount = value;
			}
		}

		[Token(Token = "0x1700001A")]
		public virtual int initialActiveConstraintCount
		{
			[Token(Token = "0x600013B")]
			[Address(RVA = "0xE42BD8", Offset = "0xE42BD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_InitialActiveConstraintCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return initialActiveConstraintCount;
			}
			[Token(Token = "0x600013C")]
			[Address(RVA = "0xE42BE0", Offset = "0xE42BE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_InitialActiveConstraintCount = value;\n\treturn;\n")]
			set
			{
				initialActiveConstraintCount = value;
			}
		}

		[Token(Token = "0x1700001B")]
		public abstract Oni.ConstraintType constraintType
		{
			[Token(Token = "0x600013D")]
			get;
		}

		[Token(Token = "0x1700001C")]
		public IntPtr oniBatch
		{
			[Token(Token = "0x600013E")]
			[Address(RVA = "0xE42BE8", Offset = "0xE42BE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.batch;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return oniBatch;
			}
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0xE3D0EC", Offset = "0xE3D0EC", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ED1DC8]);\n\tv29 = *([v28 @ X8_v10]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, source, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202472D]) = v47;\nL_001B:\n\tv51 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v51);\n\tthis.m_IDs = v51;\n\tv57 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v57);\n\tthis.m_IDToIndex = v57;\n\tv63 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v63, 8, 0x10);\n\tthis.particleIndices = v63;\n\tSystem.Object::.ctor(this);\n\tthis.source = source;\n\tv69 = source == 0;\n\tif (v69) goto L_0058;\n\tthis.m_ConstraintCount = source.m_ConstraintCount;\n\tthis.m_ActiveConstraintCount = source.m_ActiveConstraintCount;\n\tthis.m_InitialActiveConstraintCount = source.m_InitialActiveConstraintCount;\n\tv75 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v75, source.m_IDs);\n\tthis.m_IDs = v75;\n\tv85 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v85, source.m_IDToIndex);\n\tthis.m_IDToIndex = v85;\nL_0058:\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiConstraintsBatch(ObiConstraintsBatch source)
		{
			//IL_009f: Expected I4, but got O
			//IL_00c1: Expected I4, but got O
			base._002Ector();
			List<int> iDs = new List<int>();
			m_IDs = iDs;
			List<int> iDToIndex = new List<int>();
			m_IDToIndex = iDToIndex;
			ObiNativeIntList obiNativeIntList = new ObiNativeIntList();
			particleIndices = obiNativeIntList;
			this.source = source;
			if (source != null)
			{
				m_ConstraintCount = source.constraintCount;
				activeConstraintCount = source.activeConstraintCount;
				initialActiveConstraintCount = source.initialActiveConstraintCount;
				List<int> iDs2 = new List<int>((int)source.m_IDs);
				m_IDs = iDs2;
				List<int> iDToIndex2 = new List<int>((int)source.m_IDToIndex);
				m_IDToIndex = iDToIndex2;
			}
		}

		[Token(Token = "0x6000140")]
		public abstract IObiConstraintsBatch Clone();

		[Token(Token = "0x6000141")]
		protected abstract void SwapConstraints(int sourceIndex, int destIndex);

		[Token(Token = "0x6000142")]
		public abstract void GetParticlesInvolved(int index, List<int> particles);

		[Token(Token = "0x6000143")]
		[Address(RVA = "0xE42BF0", Offset = "0xE42BF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void CopyConstraint(ObiConstraintsBatch batch, int constraintIndex)
		{
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0xE42BF4", Offset = "0xE42BF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnAddToSolver(IObiConstraints constraints)
		{
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0xE42BF8", Offset = "0xE42BF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnRemoveFromSolver(IObiConstraints constraints)
		{
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xE42BFC", Offset = "0xE42BFC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EE3098]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, sourceIndex, destIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202472E]) = v48;\nL_0019:\n\tv49 = this.m_IDs;\n\tv53 = v49._size < sourceIndex;\n\tv54 = ~v53;\n\tv55 = v49._size - sourceIndex;\n\tv57 = v55 == 0;\n\tv62 = ~v57;\n\tv63 = v54 & v62;\n\tif (v63) goto L_002E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002E:\n\tv120 = v49._items;\n\tSystem.Collections.Generic.List`1<System.Int32>::set_Item(this.m_IDToIndex, v120[sourceIndex @ X1 (System.Int32)], destIndex);\n\tv65 = this.m_IDs;\n\tv163 = v65._size < destIndex;\n\tv102 = ~v163;\n\tv99 = v65._size - destIndex;\n\tv93 = v99 == 0;\n\tv164 = ~v93;\n\tv78 = v102 & v164;\n\tif (v78) goto L_004D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004D:\n\tv166 = v65._items;\n\tSystem.Collections.Generic.List`1<System.Int32>::set_Item(this.m_IDToIndex, v166[destIndex @ X2 (System.Int32)], sourceIndex);\n\tgoto L_0068;\n\tv179 = *([v175 @ X0_v9+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0068;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v175, v171, v169, v167, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0068:\n\tObi.ObiUtils::Swap(this.m_IDs, sourceIndex, destIndex);\n\tv158 = this->klass;\n\tv125 = this->klass->vtable[25];\n\tv131 = this->klass->vtable[25];\n\t// 120 IndirectJump v125 @ X4_v1, this @ X0 (Obi.ObiConstraintsBatch), this @ X0 (Obi.ObiConstraintsBatch), sourceIndex @ X1 (System.Int32), destIndex @ X2 (System.Int32), v131 @ X3_v5, v125 @ X4_v1, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InnerSwapConstraints(int sourceIndex, int destIndex)
		{
			//IL_0163: Expected I, but got O
			//IL_0173: Expected O, but got I
			//IL_0183: Expected O, but got I
			while (true)
			{
				List<int> iDs = m_IDs;
				bool flag = iDs.Count < sourceIndex;
				bool flag2 = !flag;
				int num = iDs.Count - sourceIndex;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items = iDs._items;
				m_IDToIndex.set_Item(items[sourceIndex], destIndex);
				List<int> iDs2 = m_IDs;
				bool flag5 = iDs2.Count < destIndex;
				bool flag6 = !flag5;
				int num2 = iDs2.Count - destIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					break;
				}
				int[] items2 = iDs2._items;
				m_IDToIndex.set_Item(items2[destIndex], sourceIndex);
				m_IDs.Swap(sourceIndex, destIndex);
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X8_v16 (Il2CppClass<Obi.ObiConstraintsBatch>)+2C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X8_v16 (Il2CppClass<Obi.ObiConstraintsBatch>)+2C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v125 @ X4_v1 (should have been resolved before IL gen)");
			}
			throw new ArgumentOutOfRangeException();
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0xE3D3D4", Offset = "0xE3D3D4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC0290]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202472F]) = v38;\nL_001A:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.m_IDs, this.m_ConstraintCount);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.m_IDToIndex, this.m_ConstraintCount);\n\tv64 = this.m_ConstraintCount + 1;\n\tthis.m_ConstraintCount = v64;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void RegisterConstraint()
		{
			m_IDs.Add(constraintCount);
			m_IDToIndex.Add(constraintCount);
			int num = constraintCount + 1;
			m_ConstraintCount = num;
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0xE3D558", Offset = "0xE3D558", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0C478]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024730]) = v38;\nL_0014:\n\tthis.m_ConstraintCount = 0;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.m_IDs);\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.m_IDToIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Clear()
		{
			m_ConstraintCount = 0;
			m_ActiveConstraintCount = 0;
			m_IDs.Clear();
			m_IDToIndex.Clear();
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0xE42D3C", Offset = "0xE42D3C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB31D8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, constraintId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024731]) = v41;\nL_0015:\n\tv42 = constraintId & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\n\tv57 = this.m_ConstraintCount <= constraintId;\n\tif (v57) goto L_FFFFFFFF;\n\tv78 = this.m_IDToIndex;\n\tv113 = v78._size < constraintId;\n\tv100 = ~v113;\n\tv98 = v78._size - constraintId;\n\tv94 = v98 == 0;\n\tv114 = ~v94;\n\tv84 = v100 & v114;\n\tif (v84) goto L_0039;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0039:\n\tv137 = v78._items;\n\tgoto L_0045;\nL_0045:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetConstraintIndex(int constraintId)
		{
			//IL_00e8: Expected I4, but got I8
			if ((int)(constraintId & 0x80000000L) == 0 && constraintCount > constraintId)
			{
				List<int> iDToIndex = m_IDToIndex;
				bool flag = iDToIndex.Count < constraintId;
				bool flag2 = !flag;
				int num = iDToIndex.Count - constraintId;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items = iDToIndex._items;
				return items[constraintId];
			}
			return -1;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0xE42DD0", Offset = "0xE42DD0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.m_ActiveConstraintCount - index;\n\tv6 = v5 < 0;\n\tv7 = v5 == 0;\n\tv8 = this.m_ActiveConstraintCount ^ index;\n\tv9 = this.m_ActiveConstraintCount ^ v5;\n\tv10 = v8 & v9;\n\tv11 = v10 < 0;\n\tv12 = v6 == v11;\n\tv13 = ~v7;\n\tv14 = v12 & v13;\n\treturn v14;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsConstraintActive(int index)
		{
			int num = activeConstraintCount - index;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = activeConstraintCount ^ index;
			int num3 = activeConstraintCount ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x600014B")]
		[Address(RVA = "0xE42DE0", Offset = "0xE42DE0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = this.m_ActiveConstraintCount <= constraintIndex;\n\tif (v23) goto L_0017;\n\tgoto L_0023;\nL_0017:\n\tObi.ObiConstraintsBatch::InnerSwapConstraints(this, constraintIndex, this.m_ActiveConstraintCount);\n\tv28 = this.m_ActiveConstraintCount + 1;\n\tthis.m_ActiveConstraintCount = v28;\n\tOni::SetActiveConstraints(this.batch, v28);\nL_0023:\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ActivateConstraint(int constraintIndex)
		{
			if (activeConstraintCount > constraintIndex)
			{
				return false;
			}
			InnerSwapConstraints(constraintIndex, activeConstraintCount);
			Oni.SetActiveConstraints(num: ++activeConstraintCount, batch: oniBatch);
			return true;
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0xE42E34", Offset = "0xE42E34", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = this.m_ActiveConstraintCount <= constraintIndex;\n\tif (v23) goto L_FFFFFFFF;\n\tv24 = this.m_ActiveConstraintCount - 1;\n\tthis.m_ActiveConstraintCount = v24;\n\tObi.ObiConstraintsBatch::InnerSwapConstraints(this, constraintIndex, v24);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\tgoto L_0023;\nL_0023:\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool DeactivateConstraint(int constraintIndex)
		{
			if (activeConstraintCount > constraintIndex)
			{
				InnerSwapConstraints(constraintIndex, --activeConstraintCount);
				Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
				return true;
			}
			return false;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0xE42E88", Offset = "0xE42E88", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_ActiveConstraintCount = 0;\n\tOni::SetActiveConstraints(this.batch, 0);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DeactivateAllConstraints()
		{
			activeConstraintCount = 0;
			Oni.SetActiveConstraints(oniBatch, 0);
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0xE42EA0", Offset = "0xE42EA0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Obi.ObiConstraintsBatch::CopyConstraint(destBatch, this, constraintIndex);\n\tObi.ObiConstraintsBatch::RemoveConstraint(this, constraintIndex);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void MoveConstraintToBatch(int constraintIndex, ObiConstraintsBatch destBatch)
		{
			destBatch.CopyConstraint(this, constraintIndex);
			RemoveConstraint(constraintIndex);
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0xE42EF0", Offset = "0xE42EF0", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC2198]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, constraintIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024732]) = v41;\nL_001B:\n\tv48 = this.m_ConstraintCount - 1;\n\tv49 = Obi.ObiConstraintsBatch::SwapConstraints(this, constraintIndex, v48);\n\tv55 = this.m_ConstraintCount - 1;\n\tSystem.Collections.Generic.List`1<System.Int32>::RemoveAt(this.m_IDs, v55);\n\tv68 = this.m_ConstraintCount - 1;\n\tSystem.Collections.Generic.List`1<System.Int32>::RemoveAt(this.m_IDToIndex, v68);\n\tv91 = this.m_ConstraintCount - 1;\n\tthis.m_ConstraintCount = v91;\n\tgoto L_0040;\n\tv98 = *([v94 @ X0_v8+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0040;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, v68, v67, v47, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0040:\n\tv107 = UnityEngine.Mathf::Min(this.m_ActiveConstraintCount, v91);\n\tthis.m_ActiveConstraintCount = v107;\n\tOni::SetConstraintCount(this.batch, this.m_ConstraintCount);\n\tOni::SetActiveConstraints(this.batch, this.m_ActiveConstraintCount);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveConstraint(int constraintIndex)
		{
			int destIndex = constraintCount - 1;
			SwapConstraints(constraintIndex, destIndex);
			int index = constraintCount - 1;
			m_IDs.RemoveAt(index);
			int index2 = constraintCount - 1;
			m_IDToIndex.RemoveAt(index2);
			int num = Mathf.Min(b: m_ConstraintCount = constraintCount - 1, a: activeConstraintCount);
			activeConstraintCount = num;
			Oni.SetConstraintCount(oniBatch, constraintCount);
			Oni.SetActiveConstraints(oniBatch, activeConstraintCount);
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0xE42FF8", Offset = "0xE42FF8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF6208]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, newIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024733]) = v44;\nL_0017:\n\tv126 = this.particleIndices;\nL_0025:\n\tv57 = v112 >= v126.m_Count;\n\tif (v57) goto L_0069;\n\tv103 = Obi.ObiNativeIntList::get_Item(v126, v112);\n\tv199 = v103 != newIndex;\n\tif (v199) goto L_0046;\n\tv205 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v112, index);\n\tgoto L_005B;\nL_0046:\n\tv207 = Obi.ObiNativeIntList::get_Item(this.particleIndices, v112);\n\tv135 = v207 != index;\n\tif (v135) goto L_005B;\n\tv214 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v112, newIndex);\nL_005B:\n\tv126 = this.particleIndices;\n\tv112 = v112 + 1;\n\tv217 = this.particleIndices == 0;\n\tv105 = ~v217;\n\tif (v105) goto L_0025;\n\tthrow System.NullReferenceException;\nL_0069:\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ParticlesSwapped(int index, int newIndex)
		{
			ObiNativeIntList obiNativeIntList = particleIndices;
			int num = 0;
			do
			{
				if (num >= obiNativeIntList.count)
				{
					return;
				}
				int num2 = obiNativeIntList.get_Item(num);
				if (num2 == newIndex)
				{
					particleIndices.set_Item(num, index);
				}
				else
				{
					int num3 = particleIndices.get_Item(num);
					if (num3 == index)
					{
						particleIndices.set_Item(num, newIndex);
					}
				}
				obiNativeIntList = particleIndices;
				num++;
			}
			while (particleIndices != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000151")]
		[Address(RVA = "0xE430E4", Offset = "0xE430E4", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE0D78]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, constraints, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024734]) = v41;\nL_0019:\n\tv46 = Obi.ObiConstraintsBatch::get_constraintType(this);\n\tv48 = Oni::CreateBatch(v46);\n\tthis.batch = v48;\n\tgoto L_004C;\n\tv108 = *([v51 @ X8_v6+B0]);\n\tv109 = 0;\n\tv110 = v108 + 8;\n\tv112 = *([v170 @ X11_v7-8]);\n\tv176 = v112 == v54;\n\tif (v176) goto L_0045;\n\tv134 = v171 + 1;\n\tv181 = v134 < v53;\n\tv130 = ~v181;\n\tv132 = v170 + 0x10;\n\tv114 = ~v130;\n\tif (v114) goto L_FFFFFFFF;\n\tv135 = v14;\n\tv136 = 0;\n\tv137 = 0x8909C4(v135, v54, v136, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_0045:\n\tv182 = *([v170 @ X11_v7]);\n\tv183 = v182 << 4;\n\tv184 = v51 + v183;\n\tv185 = v184 + 0x130;\nL_004C:\n\tv102 = Obi.IObiConstraints::GetActor(constraints);\n\tv106 = v102.m_Solver;\n\tv227 = Oni::AddBatch(v106.oniSolver, this.batch);\n\tv219 = this->klass;\n\tv191 = this->klass->vtable[28];\n\tv196 = this->klass->vtable[28];\n\t// 97 IndirectJump v191 @ X3_v1, this @ X0 (Obi.ObiConstraintsBatch), this @ X0 (Obi.ObiConstraintsBatch), constraints @ X1 (Obi.IObiConstraints), v196 @ X2_v5, v191 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddToSolver(IObiConstraints constraints)
		{
			//IL_0039: Expected I, but got O
			//IL_0049: Expected O, but got I
			//IL_0059: Expected O, but got I
			while (true)
			{
				int type = (int)constraintType;
				IntPtr intPtr = Oni.CreateBatch(type);
				batch = intPtr;
				ObiActor actor = constraints.GetActor();
				ObiSolver solver = actor.solver;
				IntPtr intPtr2 = Oni.AddBatch(solver.OniSolver, oniBatch);
				IntPtr intPtr3 = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v10 (Il2CppClass<Obi.ObiConstraintsBatch>)+2F0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v10 (Il2CppClass<Obi.ObiConstraintsBatch>)+2F8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v191 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0xE431F4", Offset = "0xE431F4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE6480]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, constraints, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024735]) = v41;\nL_001A:\n\tv47 = Obi.ObiConstraintsBatch::OnRemoveFromSolver(this, constraints);\n\tgoto L_004A;\n\tv107 = *([v50 @ X8_v6+B0]);\n\tv108 = 0;\n\tv109 = v107 + 8;\n\tv111 = *([v169 @ X11_v7-8]);\n\tv175 = v111 == v53;\n\tif (v175) goto L_0043;\n\tv133 = v170 + 1;\n\tv180 = v133 < v52;\n\tv129 = ~v180;\n\tv131 = v169 + 0x10;\n\tv113 = ~v129;\n\tif (v113) goto L_FFFFFFFF;\n\tv134 = v14;\n\tv135 = 0;\n\tv136 = 0x8909C4(v134, v53, v135, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004A;\nL_0043:\n\tv181 = *([v169 @ X11_v7]);\n\tv182 = v181 << 4;\n\tv183 = v50 + v182;\n\tv184 = v183 + 0x130;\nL_004A:\n\tv101 = Obi.IObiConstraints::GetActor(constraints);\n\tv105 = v101.m_Solver;\n\tOni::RemoveBatch(v105.oniSolver, this.batch);\n\tthis.batch = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveFromSolver(IObiConstraints constraints)
		{
			OnRemoveFromSolver(constraints);
			ObiActor actor = constraints.GetActor();
			ObiSolver solver = actor.solver;
			Oni.RemoveBatch(solver.OniSolver, oniBatch);
			batch = (IntPtr)0;
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0xE32BBC", Offset = "0xE32BBC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Oni::EnableBatch(this.batch, enabled);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetEnabled(bool enabled)
		{
			bool flag = Oni.EnableBatch(oniBatch, enabled);
		}
	}
}
