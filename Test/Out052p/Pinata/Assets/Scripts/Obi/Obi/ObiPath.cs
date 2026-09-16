using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000078")]
	public class ObiPath
	{
		[CompilerGenerated]
		[Token(Token = "0x20000CA")]
		private sealed class _003CGetDataChannels_003Ed__17 : IEnumerable<IObiPathDataChannel>, IEnumerable, IEnumerator<IObiPathDataChannel>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400034F")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000350")]
			[FieldOffset(Offset = "0x18")]
			private IObiPathDataChannel _003C_003E2__current;

			[Token(Token = "0x4000351")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000352")]
			[FieldOffset(Offset = "0x28")]
			public ObiPath _003C_003E4__this;

			[Token(Token = "0x170000F0")]
			IObiPathDataChannel IEnumerator<IObiPathDataChannel>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60005B6")]
				[Address(RVA = "0xC2DB08", Offset = "0xC2DB08", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170000F1")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60005B8")]
				[Address(RVA = "0xC2DB74", Offset = "0xC2DB74", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60005B3")]
			[Address(RVA = "0xC2B1D0", Offset = "0xC2B1D0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGetDataChannels_003Ed__17(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60005B4")]
			[Address(RVA = "0xC2DA0C", Offset = "0xC2DA0C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60005B5")]
			[Address(RVA = "0xC2DA10", Offset = "0xC2DA10", Length = "0xF8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<>1__state;\n\tv9 = this.<>1__state < 7;\n\tv10 = ~v9;\n\tv11 = this.<>1__state - 7;\n\tv13 = v11 == 0;\n\tv18 = ~v13;\n\tv19 = v10 & v18;\n\tif (v19) goto L_0050;\n\tv21 = 0x181A000 + 0x1AC;\n\tv24 = *([v21 @ X11_v2 (System.Int32)+v6 @ X9_v1 (System.Int32)*4]) + v21;\n\t// 24 IndirectJump v24 @ X11_v3, this @ X0 (Obi.ObiPath+<GetDataChannels>d__17), this @ X0 (Obi.ObiPath+<GetDataChannels>d__17), methodInfo @ X1 (Il2CppMethodInfo), v27 @ X2, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X10+18]);\n\tX9 = 0 | 1;\n\tgoto L_0049;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X10+20]);\n\tX9 = 0 | 2;\n\tgoto L_0049;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X10+28]);\n\tX9 = 0 | 3;\n\tgoto L_0049;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X10+30]);\n\tX9 = 0 | 4;\n\tgoto L_0049;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X10+38]);\n\tX9 = 5;\n\tgoto L_0049;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X10+40]);\n\tX9 = 0 | 6;\n\tgoto L_0049;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\tif (TEMP) goto L_0051;\n\tX8 = *([X10+48]);\n\tX9 = 0 | 7;\nL_0049:\n\t*([X0+18]) = X8;\n\tX8 = 0 | 1;\n\t*([X0+10]) = X9;\nL_0050:\n\treturn 0;\nL_0051:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_008f: Expected O, but got I
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 7;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 7;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25272320 + 428;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X11_v2 (System.Int32)+v6 @ X9_v1 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v24 @ X11_v3 (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60005B7")]
			[Address(RVA = "0xC2DB10", Offset = "0xC2DB10", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED3E60]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023163]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x60005B9")]
			[Address(RVA = "0xC2DB7C", Offset = "0xC2DB7C", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F07E98]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023164]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_0041;\nL_002E:\n\tv76 = new Obi.ObiPath+<GetDataChannels>d__17();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\n\tv76.<>4__this = this.<>4__this;\nL_0041:\n\treturn v95;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<IObiPathDataChannel> IEnumerable<IObiPathDataChannel>.GetEnumerator()
			{
				if (_003C_003E1__state + 2 == 0)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003CGetDataChannels_003Ed__17 _003CGetDataChannels_003Ed__18 = null;
				_003CGetDataChannels_003Ed__18._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetDataChannels_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetDataChannels_003Ed__18._003C_003E4__this = _003C_003E4__this;
				return _003CGetDataChannels_003Ed__18;
			}

			[DebuggerHidden]
			[Token(Token = "0x60005BA")]
			[Address(RVA = "0xC2DC2C", Offset = "0xC2DC2C", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Obi.ObiPath+<GetDataChannels>d__17::System.Collections.Generic.IEnumerable<Obi.IObiPathDataChannel>.GetEnumerator(this);\n\treturn returnVal1;\n\tV7 = stack[2C];\n\tV6 = stack[30];\n\tV17 = stack[24];\n\tV16 = stack[28];\n\tV18 = stack[20];\n\tV20 = stack[14];\n\tV19 = stack[18];\n\tV21 = stack[10];\n\tV23 = stack[4];\n\tV22 = stack[8];\n\tV24 = stack[0];\n\t*([X0]) = V0;\n\t*([X0+4]) = V1;\n\t*([X0+8]) = V2;\n\t*([X0+C]) = V3;\n\t*([X0+10]) = V4;\n\t*([X0+14]) = V5;\n\t*([X0+18]) = V24;\n\t*([X0+1C]) = V23;\n\t*([X0+20]) = V22;\n\t*([X0+24]) = V21;\n\t*([X0+28]) = V20;\n\t*([X0+2C]) = V19;\n\t*([X0+30]) = V18;\n\t*([X0+34]) = V17;\n\t*([X0+38]) = V16;\n\t*([X0+3C]) = V7;\n\t*([X0+40]) = V6;\n\treturn X0;\n\t// 31 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([2023165]);\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0032;\n\tX8 = *([1F08FD0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023165]) = X8;\nL_0032:\n\tX8 = 0x1EE1000;\n\tX8 = *([1EE1550]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_003E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_003E:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector3::get_zero(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = 0;\n\t*([X19]) = V0;\n\t*([X19+4]) = V1;\n\t*([X19+8]) = V2;\n\tV0 = UnityEngine.Vector3::get_forward(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = 0;\n\t*([X19+C]) = V0;\n\t*([X19+10]) = V1;\n\t*([X19+14]) = V2;\n\tV0 = UnityEngine.Vector3::get_up(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = 0;\n\t*([X19+18]) = V0;\n\t*([X19+1C]) = V1;\n\t*([X19+20]) = V2;\n\tV0 = UnityEngine.Vector3::get_right(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = 0;\n\t*([X19+24]) = V0;\n\t*([X19+28]) = V1;\n\t*([X19+2C]) = V2;\n\tV0 = UnityEngine.Color::get_white(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = 0;\n\t// 96 MakeStruct AGGC2DD14_0, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tV0 = UnityEngine.Color::op_Implicit(AGGC2DD14_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\t*([X19+30]) = V0;\n\t*([X19+34]) = V1;\n\t*([X19+38]) = V2;\n\t*([X19+3C]) = V3;\n\t*([X19+40]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 110 ShiftStack 32\n\treturn X0;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IObiPathDataChannel>)this).GetEnumerator();
			}
		}

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x10")]
		private List<string> m_Names;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x18")]
		public ObiPointsDataChannel m_Points;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x20")]
		private ObiNormalDataChannel m_Normals;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x28")]
		private ObiColorDataChannel m_Colors;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x30")]
		private ObiThicknessDataChannel m_Thickness;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x38")]
		private ObiMassDataChannel m_Masses;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x40")]
		private ObiRotationalMassDataChannel m_RotationalMasses;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x48")]
		private ObiPhaseDataChannel m_Phases;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x50")]
		private bool m_Closed;

		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x51")]
		protected bool dirty;

		[Token(Token = "0x40001F6")]
		protected const int arcLenghtSamples = 20;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x58")]
		protected List<float> m_ArcLengthTable;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x60")]
		protected float m_TotalSplineLenght;

		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x68")]
		public UnityEvent OnPathChanged;

		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x70")]
		public PathControlPointEvent OnControlPointAdded;

		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x78")]
		public PathControlPointEvent OnControlPointRemoved;

		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x80")]
		public PathControlPointEvent OnControlPointRenamed;

		[Token(Token = "0x170000B9")]
		public ObiPointsDataChannel points
		{
			[Token(Token = "0x6000498")]
			[Address(RVA = "0xC2B208", Offset = "0xC2B208", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Points;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_Points;
			}
		}

		[Token(Token = "0x170000BA")]
		public ObiNormalDataChannel normals
		{
			[Token(Token = "0x6000499")]
			[Address(RVA = "0xC2B210", Offset = "0xC2B210", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Normals;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return normals;
			}
		}

		[Token(Token = "0x170000BB")]
		public ObiColorDataChannel colors
		{
			[Token(Token = "0x600049A")]
			[Address(RVA = "0xC2B218", Offset = "0xC2B218", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Colors;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return colors;
			}
		}

		[Token(Token = "0x170000BC")]
		public ObiThicknessDataChannel thicknesses
		{
			[Token(Token = "0x600049B")]
			[Address(RVA = "0xC2B220", Offset = "0xC2B220", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Thickness;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return thicknesses;
			}
		}

		[Token(Token = "0x170000BD")]
		public ObiMassDataChannel masses
		{
			[Token(Token = "0x600049C")]
			[Address(RVA = "0xC2B228", Offset = "0xC2B228", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Masses;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return masses;
			}
		}

		[Token(Token = "0x170000BE")]
		public ObiRotationalMassDataChannel rotationalMasses
		{
			[Token(Token = "0x600049D")]
			[Address(RVA = "0xC2B230", Offset = "0xC2B230", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_RotationalMasses;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return rotationalMasses;
			}
		}

		[Token(Token = "0x170000BF")]
		public ObiPhaseDataChannel phases
		{
			[Token(Token = "0x600049E")]
			[Address(RVA = "0xC2B238", Offset = "0xC2B238", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Phases;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return phases;
			}
		}

		[Token(Token = "0x170000C0")]
		public ReadOnlyCollection<float> ArcLengthTable
		{
			[Token(Token = "0x600049F")]
			[Address(RVA = "0xC2B240", Offset = "0xC2B240", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1ED0010]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023155]) = v38;\nL_001E:\n\treturnVal1 = System.Collections.Generic.List`1<System.Single>::AsReadOnly(this.m_ArcLengthTable);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_ArcLengthTable.AsReadOnly();
			}
		}

		[Token(Token = "0x170000C1")]
		public float Length
		{
			[Token(Token = "0x60004A0")]
			[Address(RVA = "0xC2B298", Offset = "0xC2B298", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_TotalSplineLenght;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Length;
			}
		}

		[Token(Token = "0x170000C2")]
		public int ArcLengthSamples
		{
			[Token(Token = "0x60004A1")]
			[Address(RVA = "0xC2B2A0", Offset = "0xC2B2A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x14;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 20;
			}
		}

		[Token(Token = "0x170000C3")]
		public int ControlPointCount
		{
			[Token(Token = "0x60004A2")]
			[Address(RVA = "0xC2B2A8", Offset = "0xC2B2A8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1ECB3A8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023156]) = v38;\nL_001E:\n\treturnVal1 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Count(this.m_Points);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_Points.Count;
			}
		}

		[Token(Token = "0x170000C4")]
		public bool Closed
		{
			[Token(Token = "0x60004A3")]
			[Address(RVA = "0xC2B300", Offset = "0xC2B300", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Closed;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Closed;
			}
			[Token(Token = "0x60004A4")]
			[Address(RVA = "0xC2B308", Offset = "0xC2B308", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_Closed == 0;\n\tv11 = ~v6;\n\tv13 = v11 ^ value;\n\tv16 = v13 == 0;\n\tif (v16) goto L_0014;\n\tthis.m_Closed = value;\n\tthis.dirty = 1;\nL_0014:\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = !Closed;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					m_Closed = value;
					dirty = true;
				}
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7478B0", Offset = "0x7478B0")]
		[Token(Token = "0x6000497")]
		[Address(RVA = "0xC2B14C", Offset = "0xC2B14C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAAC18]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023154]) = v38;\nL_0016:\n\tv42 = new Obi.ObiPath+<GetDataChannels>d__17();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerable<IObiPathDataChannel> GetDataChannels()
		{
			_003CGetDataChannels_003Ed__17 _003CGetDataChannels_003Ed__18 = new _003CGetDataChannels_003Ed__17(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetDataChannels_003Ed__18._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetDataChannels_003Ed__18._003C_003E4__this = this;
			return _003CGetDataChannels_003Ed__18;
		}

		[Token(Token = "0x60004A5")]
		[Address(RVA = "0xC2B330", Offset = "0xC2B330", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1ECC0F0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023157]) = v38;\nL_001F:\n\treturnVal1 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::GetSpanCount(this.m_Points, this.m_Closed);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetSpanCount()
		{
			return m_Points.GetSpanCount(Closed);
		}

		[Token(Token = "0x60004A6")]
		[Address(RVA = "0xC2B38C", Offset = "0xC2B38C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv26 = *([1EA4E58]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, spanMu, methodInfo, v30, v31, v32, v33, v34, mu, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023158]) = v44;\nL_0027:\n\treturnVal1 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::GetSpanControlPointAtMu(this.m_Points, this.m_Closed, mu, spanMu);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetSpanControlPointForMu(float mu, out float spanMu)
		{
			spanMu = default(float);
			return m_Points.GetSpanControlPointAtMu(Closed, mu, out spanMu);
		}

		[Token(Token = "0x60004A7")]
		[Address(RVA = "0xC2B408", Offset = "0xC2B408", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = 0;\n\tv16 = Obi.ObiPath::GetSpanControlPointForMu(this, mu, &v13 @ stack_-24_v1 (System.Single));\n\tv25 = 0 - 0.5f;\n\tv26 = v25 < 0;\n\tv27 = v25 == 0;\n\tv30 = 0.5f & v25;\n\tv31 = v30 < 0;\n\tv32 = v26 == v31;\n\tv33 = ~v27;\n\tv34 = v32 & v33;\n\tv36 = Obi.ObiPath::get_ControlPointCount(this);\n\tv37 = v16 + v34;\n\tv42 = v37 / v36;\n\tv43 = v42 * v36;\n\treturnVal1 = v37 - v43;\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetClosestControlPointIndex(float mu)
		{
			//IL_005c: Expected I4, but got F4
			//IL_00ad: Expected O, but got I4
			float spanMu = 0f;
			int spanControlPointForMu = GetSpanControlPointForMu(mu, out spanMu);
			float num = 0f - 0.5f;
			bool flag = num < 0f;
			bool flag2 = num == 0f;
			int num2 = 0.5f & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			bool flag6 = flag4 && flag5;
			int controlPointCount = ControlPointCount;
			object obj = spanControlPointForMu + (flag6 ? 1 : 0);
			int num3 = (int)((long)(IntPtr)obj / (long)controlPointCount);
			int num4 = num3 * controlPointCount;
			return (int)((long)(IntPtr)obj - (long)num4);
		}

		[Token(Token = "0x60004A8")]
		[Address(RVA = "0xC2B460", Offset = "0xC2B460", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = *([1F0EF00]);\n\tv39 = *([v38 @ X8_v25]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, length, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2023159]) = v57;\nL_001D:\n\tv58 = length < 0;\n\tv59 = ~v58;\n\tv62 = length == 0;\n\tv68 = ~v59;\n\tv69 = v68 | v62;\n\tif (v69) goto L_00D8;\n\tv71 = this.m_TotalSplineLenght < length;\n\tv72 = ~v71;\n\tv73 = this.m_TotalSplineLenght - length;\n\tv75 = v73 == 0;\n\tv80 = ~v72;\n\tv81 = v80 | v75;\n\tif (v81) goto L_FFFFFFFF;\n\tv118 = this.m_ArcLengthTable;\nL_0045:\n\tv279 = v160 >= v118._size;\n\tif (v279) goto L_0073;\n\tv280 = v118._size < v160;\n\tv281 = ~v280;\n\tv282 = v118._size - v160;\n\tv284 = v282 == 0;\n\tv289 = ~v284;\n\tv290 = v281 & v289;\n\tif (v290) goto L_0055;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0055:\n\tv305 = v118._items;\n\tv211 = v305[v160 @ X20_v7 (System.Int32)] > length;\n\tif (v211) goto L_006F;\n\tv118 = this.m_ArcLengthTable;\n\tv160 = v160 + 1;\n\tv310 = this.m_ArcLengthTable == 0;\n\tv244 = ~v310;\n\tif (v244) goto L_0045;\n\tthrow System.NullReferenceException;\n\tgoto L_00D8;\nL_006F:\n\tv118 = this.m_ArcLengthTable;\nL_0073:\n\tv104 = v160 - 1;\n\tv302 = v118._size < v104;\n\tv236 = ~v302;\n\tv233 = v118._size - v104;\n\tv227 = v233 == 0;\n\tv303 = ~v236;\n\tv212 = v303 | v227;\n\tif (v212) goto L_0084;\n\tv316 = v118._items;\n\tgoto L_008B;\nL_0084:\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv316 = v118._items;\nL_008B:\n\tv206 = v104 << 2;\n\tv318 = v316 + v206;\n\tv319 = v318 + 0x20;\n\tv320 = v118._size < v160;\n\tv237 = ~v320;\n\tv234 = v118._size - v160;\n\tv228 = v234 == 0;\n\tv321 = ~v237;\n\tv213 = v321 | v228;\n\tif (v213) goto L_00A1;\n\tv323 = v160 << 2;\n\tv331 = v118._items + v323;\n\tgoto L_00A9;\nL_00A1:\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv328 = v160 << 2;\n\tv331 = v118._items + v328;\nL_00A9:\n\tv333 = v331 + 0x20;\n\tv97 = v118._size - 1;\n\tv88 = v104 / v97;\n\tv337 = v118._size < v104;\n\tv145 = ~v337;\n\tv142 = v118._size - v104;\n\tv136 = v142 == 0;\n\tv90 = v160 / v97;\n\tv338 = ~v136;\n\tv121 = v145 & v338;\n\tif (v121) goto L_00C0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00C0:\n\tv340 = v118._items;\n\tv341 = length - *([v319 @ X8_v11]);\n\tv343 = *([v333 @ X8_v13]) - v340[v101 @ X24_v5 (System.Int32)];\n\tv344 = v341 / v343;\n\tv95 = v90 - v88;\n\tv345 = v95 * v344;\n\treturnVal1 = v88 + v345;\nL_00D8:\n\treturn returnVal1;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetMuAtLenght(float length)
		{
			//IL_03ce: Expected O, but got I
			//IL_03dd: Expected O, but got I
			//IL_026d: Expected O, but got I
			//IL_0451: Expected O, but got I
			bool flag = length < 0f;
			bool flag2 = !flag;
			bool flag3 = length == 0f;
			bool flag4 = !flag2;
			bool flag5 = flag4 || flag3;
			float result = 0f;
			if (!flag5)
			{
				bool flag6 = Length < length;
				bool flag7 = !flag6;
				float num = Length - length;
				bool flag8 = num == 0f;
				bool flag9 = !flag7;
				if (!(flag9 || flag8))
				{
					List<float> arcLengthTable = m_ArcLengthTable;
					int num2 = 1;
					while (num2 < arcLengthTable.Count)
					{
						bool flag10 = arcLengthTable.Count < num2;
						bool flag11 = !flag10;
						int num3 = arcLengthTable.Count - num2;
						bool flag12 = num3 == 0;
						bool flag13 = !flag12;
						if (!(flag11 && flag13))
						{
							throw new ArgumentOutOfRangeException();
						}
						float[] items = arcLengthTable._items;
						if (!(items[num2] > length))
						{
							arcLengthTable = m_ArcLengthTable;
							num2++;
							if (m_ArcLengthTable == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						arcLengthTable = m_ArcLengthTable;
						break;
					}
					int num4 = num2 - 1;
					bool flag14 = arcLengthTable.Count < num4;
					bool flag15 = !flag14;
					int num5 = arcLengthTable.Count - num4;
					bool flag16 = num5 == 0;
					bool flag17 = !flag15;
					if (flag17 || flag16)
					{
						throw new ArgumentOutOfRangeException();
					}
					float[] items2 = arcLengthTable._items;
					int num6 = num4;
					int num7 = num4 << 2;
					object obj = (long)(IntPtr)items2 + (long)num7;
					object obj2 = (long)(IntPtr)obj + 32L;
					bool flag18 = arcLengthTable.Count < num2;
					bool flag19 = !flag18;
					int num8 = arcLengthTable.Count - num2;
					bool flag20 = num8 == 0;
					bool flag21 = !flag19;
					if (flag21 || flag20)
					{
						throw new ArgumentOutOfRangeException();
					}
					int num9 = num2 << 2;
					object obj3 = (long)(IntPtr)arcLengthTable._items + (long)num9;
					object obj4 = (long)(IntPtr)obj3 + 32L;
					int num10 = arcLengthTable.Count - 1;
					int num11 = num4 / num10;
					bool flag22 = arcLengthTable.Count < num4;
					bool flag23 = !flag22;
					int num12 = arcLengthTable.Count - num4;
					bool flag24 = num12 == 0;
					int num13 = num2 / num10;
					bool flag25 = !flag24;
					if (!(flag23 && flag25))
					{
						throw new ArgumentOutOfRangeException();
					}
					float[] items3 = arcLengthTable._items;
					float num14 = length - (float)obj2;
					float num15 = (float)obj4 - items3[num6];
					float num16 = num14 / num15;
					int num17 = num13 - num11;
					float num18 = (float)num17 * num16;
					result = (float)num11 + num18;
				}
				else
				{
					result = 1f;
				}
			}
			return result;
		}

		[Token(Token = "0x60004A9")]
		[Address(RVA = "0xC2B614", Offset = "0xC2B614", Length = "0x410")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0027;\n\tv56 = *([1EC5B38]);\n\tv57 = *([v56 @ X8_v28]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, referenceFrame, maxevals, methodInfo, v60, v61, v62, v63, acc, v64, v65, v66, v67, v68, v69, v70);\n\tv73 = 0 | 1;\n\t*([202315A]) = v73;\nL_0027:\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-C0]) = 0;\n\t*([v40 @ X29_v1-B0]) = 0;\n\tthis.m_TotalSplineLenght = 0f;\n\tSystem.Collections.Generic.List`1<System.Single>::Clear(this.m_ArcLengthTable);\n\tSystem.Collections.Generic.List`1<System.Single>::Add(this.m_ArcLengthTable, 0f);\n\tv545 = Obi.ObiPath::get_ControlPointCount(this);\n\tv555 = v545 >= 2;\n\tif (v555) goto L_0060;\n\tgoto L_005D;\n\tv564 = *([v558 @ X0_v44+E0]);\n\tv565 = v564 == 0;\n\tv566 = ~v565;\n\tif (v566) goto L_005D;\n\tv568 = \"il2cpp_codegen_runtime_class_init\"(v558, v394, maxevals, methodInfo, v60, v61, v62, v63, v393, v64, v65, v66, v67, v68, v69, v70);\nL_005D:\n\tUnityEngine.Debug::LogWarning(\"A path needs at least 2 control points to be defined.\");\n\tgoto L_016C;\nL_0060:\n\tv563 = Obi.ObiPath::GetSpanCount(this);\n\tv585 = v563 < 1;\n\tif (v585) goto L_016C;\nL_007B:\n\t;\n\tv624 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this.m_Points, v302);\n\t*([v40 @ X29_v1-A0]) = v625;\n\t*([v40 @ X29_v1-C0]) = v295;\n\t*([v40 @ X29_v1-B0]) = v626;\n\tv302 = v302 + 1;\n\tv628 = v302 / v545;\n\tv629 = v628 * v545;\n\tv630 = v302 - v629;\n\tv632 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this.m_Points, v630);\n\treturnVal2 = *([v40 @ X29_v1-B0]);\n\tv643 = 0x10C27FC(referenceFrame, 0, *([v312 @ X23_v6 (Il2CppMethodInfo)]), methodInfo, v60, v61, v62, v63, *([v40 @ X29_v1-B0]), *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), v635, v281, *([v40 @ X29_v1-A8]), v69, v70);\n\tv644 = &v41 @ stack_-10_v2 - 0xC0;\n\tv646 = 0x10340E8(v644, 0, *([v312 @ X23_v6 (Il2CppMethodInfo)]), methodInfo, v60, v61, v62, v63, *([v40 @ X29_v1-B0]), *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), v635, v281, *([v40 @ X29_v1-A8]), v69, v70);\n\tv649 = 0x10C27FC(referenceFrame, 0, *([v312 @ X23_v6 (Il2CppMethodInfo)]), methodInfo, v60, v61, v62, v63, *([v40 @ X29_v1-B0]), *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), v635, v281, *([v40 @ X29_v1-A8]), v69, v70);\n\tv655 = 0x1034048(&v281 @ stack_-160_v4, 0, *([v312 @ X23_v6 (Il2CppMethodInfo)]), methodInfo, v60, v61, v62, v63, *([v40 @ X29_v1-B0]), *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), v635, v281, *([v40 @ X29_v1-A8]), v69, v70);\n\tv658 = 0x10C27FC(referenceFrame, 0, *([v312 @ X23_v6 (Il2CppMethodInfo)]), methodInfo, v60, v61, v62, v63, *([v40 @ X29_v1-B0]), *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), v635, v281, *([v40 @ X29_v1-A8]), v69, v70);\n\tv668 = 0x10C27FC(referenceFrame, 0, *([v312 @ X23_v6 (Il2CppMethodInfo)]), methodInfo, v60, v61, v62, v63, v635, v664, v660, v660, v281, *([v40 @ X29_v1-A8]), v69, v70);\n\tgoto L_012D;\nL_00C8:\n\tv191 = v313 * 0.04761905f;\n\tv712 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this.m_Points, Il2CppMethodInfo, 0, methodInfo, v60, returnVal2);\n\tv714 = 0x158AD58(&returnVal2 @ V0_v5 (System.Single), 0, 0, methodInfo, v60, v61, v62, v63, returnVal2, *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), v241, v237, v233, v69, v70);\n\tv736 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this.m_Points, Il2CppMethodInfo, 0, methodInfo, v60, returnVal2);\n\tv739 = 0x158AD58(&returnVal2 @ V0_v5 (System.Single), 0, 0, methodInfo, v60, v61, v62, v63, returnVal2, *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), returnVal2, *([v40 @ X29_v1-AC]), *([v40 @ X29_v1-A8]), v69, v70);\n\t// 286 MakeStruct v94 @ AGGC2B97C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), returnVal2 @ V0_v5 (System.Single), [v40 @ X29_v1-AC], [v40 @ X29_v1-A8]\n\t// 287 MakeStruct v89 @ AGGC2B97C_2_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), returnVal2 @ V0_v5 (System.Single), [v40 @ X29_v1-AC], [v40 @ X29_v1-A8]\n\treturnVal2 = Obi.ObiPath::GaussLobattoIntegrationStep(this, v94, v89, returnVal2, *([v40 @ X29_v1-A8]), v69, v70, v635, v660, 0, maxevals, v191);\n\treturnVal2 = returnVal2 + this.m_TotalSplineLenght;\n\tthis.m_TotalSplineLenght = returnVal2;\n\tSystem.Collections.Generic.List`1<System.Single>::Add(this.m_ArcLengthTable, returnVal2);\n\tv207 = v207 + 1;\nL_012D:\n\tv313 = v207 - 1;\n\tgoto L_013A;\n\tv694 = *([v690 @ X0_v29+E0]);\n\tv695 = v694 == 0;\n\tv696 = ~v695;\n\tgoto L_013A;\n\tv698 = \"il2cpp_codegen_runtime_class_init\"(v690, v685, v674, methodInfo, v60, v61, v62, v63, v359, v289, v265, v270, v275, v185, v69, v70);\nL_013A:\n\tv617 = UnityEngine.Mathf::Max(1, 0x14);\n\tv320 = v313 <= v617;\n\tif (v320) goto L_00C8;\n\tv607 = v302 < v563;\n\tif (v607) goto L_007B;\nL_016C:\n\treturn this.m_TotalSplineLenght;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 294 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float RecalculateLenght(Matrix4x4 referenceFrame, float acc, int maxevals)
		{
			//IL_012c: Expected F4, but got I
			//IL_014c: Expected O, but got I
			//IL_01a1: Expected O, but got I
			//IL_01b1: Expected O, but got I
			//IL_01c1: Expected F4, but got I
			//IL_01fe: Expected O, but got I
			//IL_01fe: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_026d: Expected F4, but got I
			//IL_0282: Expected F4, but got I
			//IL_02a4: Expected F4, but got I
			//IL_02b9: Expected F4, but got I
			//IL_02f4: Expected O, but got I
			//IL_02f4: Expected O, but got F4
			//IL_0345: Expected O, but got I
			//IL_0355: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			m_TotalSplineLenght = 0f;
			m_ArcLengthTable.Clear();
			m_ArcLengthTable.Add(0f);
			int controlPointCount = ControlPointCount;
			if (controlPointCount < 2)
			{
				Debug.LogWarning("A path needs at least 2 control points to be defined.");
			}
			else
			{
				int spanCount = GetSpanCount();
				if (spanCount >= 1)
				{
					int num = 0;
					IntPtr intPtr = (IntPtr)0;
					IntPtr intPtr2 = default(IntPtr);
					Vector3 v = default(Vector3);
					Vector3 vector4 = default(Vector3);
					Vector3 vector5 = default(Vector3);
					float a = default(float);
					float b = default(float);
					float fa = default(float);
					float fb = default(float);
					do
					{
						ObiWingedPoint obiWingedPoint = ((ObiPathDataChannel<ObiWingedPoint, Vector3>)m_Points).get_Item(num);
						num++;
						int num2 = num / controlPointCount;
						int num3 = num2 * controlPointCount;
						int i = num - num3;
						ObiWingedPoint obiWingedPoint2 = ((ObiPathDataChannel<ObiWingedPoint, Vector3>)m_Points).get_Item(i);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B0]");
						float num4 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
						object obj3 = (long)(IntPtr)obj2 - 192L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
						int num5 = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
						Vector3 vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-AC]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B0]");
						float num6 = 0f;
						while (true)
						{
							int num7 = num5 - 1;
							int num8 = Mathf.Max(1, 20);
							if (num7 <= num8)
							{
								float acc2 = (float)num7 * (1f / 21f);
								Vector3 vector2 = m_Points.EvaluateFirstDerivative((Vector3)0, default(Vector3), (Vector3)(long)intPtr2, v, num4);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
								Vector3 vector3 = m_Points.EvaluateFirstDerivative((Vector3)0, default(Vector3), (Vector3)(long)intPtr2, v, num4);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
								vector4.x = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-AC]");
								vector4.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
								vector4.z = 0f;
								vector5.x = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-AC]");
								vector5.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
								vector5.z = 0f;
								Vector3 p = vector4;
								Vector3 p2 = vector5;
								float num9 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
								num4 = GaussLobattoIntegrationStep(p, p2, (Vector3)num9, (Vector3)0, a, b, fa, fb, 0, maxevals, acc2);
								num4 = (m_TotalSplineLenght = num4 + Length);
								m_ArcLengthTable.Add(num4);
								num5++;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
								vector = (Vector3)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-AC]");
								obj4 = 0;
								num6 = num4;
								continue;
							}
							break;
						}
					}
					while (num < spanCount);
				}
			}
			return Length;
		}

		[Token(Token = "0x60004AA")]
		[Address(RVA = "0xC2BA24", Offset = "0xC2BA24", Length = "0x764")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = &v37 @ stack_-10_v2;\n\t*([v36 @ X29_v1-28]) = p2;\n\tgoto L_0034;\n\tv55 = *([1F10730]);\n\tv56 = *([v55 @ X8_v26]);\n\tv57 = \"il2cpp_codegen_initialize_method\"(v56, nevals, maxevals, methodInfo, v59, v60, v61, v62, p1, v0, v2, p2, v3, v5, a, b);\n\tv67 = 0 | 1;\n\t*([202315B]) = v67;\nL_0034:\n\t*([v36 @ X29_v1-78]) = 0;\n\t*([v36 @ X29_v1-80]) = 0;\n\tv78 = nevals >= maxevals;\n\tif (v78) goto L_0262;\n\tgoto L_004F;\n\tv349 = *([v81 @ X0_v3+E0]);\n\tv350 = v349 == 0;\n\tv351 = ~v350;\n\t// 66 ConditionalJump @b8, v351 @ TEMP_v20\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v81, nevals, maxevals, methodInfo, v59, v60, v61, v62, p1, v0, v2, p2, v3, v5, a, b);\nL_004F:\n\tv493 = *([v36 @ X29_v1+38]) - *([v36 @ X29_v1+30]);\n\tv494 = *([v36 @ X29_v1+30]) + *([v36 @ X29_v1+38]);\n\tv495 = v493 * 0.5f;\n\tv496 = v494 * 0.5f;\n\tv497 = v495 * 0.8164966f;\n\tv499 = v496 - v497;\n\t*([v36 @ X29_v1-24]) = p1;\n\t*([v36 @ X29_v1-90]) = *([v36 @ X29_v1+28]);\n\t*([v36 @ X29_v1-8C]) = *([v36 @ X29_v1+24]);\n\t*([v36 @ X29_v1-84]) = p2.z;\n\tv522 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this.m_Points, Il2CppMethodInfo, maxevals, methodInfo, v59, p1);\n\tv586 = &v37 @ stack_-10_v2 - 0x80;\n\t*([v36 @ X29_v1-80]) = p1;\n\t*([v36 @ X29_v1-7C]) = p1.y;\n\t*([v36 @ X29_v1-78]) = p1.z;\n\tv587 = 0x158AD58(v586, 0, maxevals, methodInfo, v59, v60, v61, v62, p1, p1.y, p1.z, *([v36 @ X29_v1-28]), p2.y, p2.z, *([v36 @ X29_v1+28]), *([v36 @ X29_v1+24]));\n\t*([v36 @ X29_v1-88]) = p2.y;\n\tv590 = v495 * 0.4472136f;\n\tv591 = v496 - v590;\n\tv594 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this.m_Points, Il2CppMethodInfo, maxevals, methodInfo, v59, *([v36 @ X29_v1-24]));\n\tv595 = &v37 @ stack_-10_v2 - 0x80;\n\t*([v36 @ X29_v1-80]) = *([v36 @ X29_v1-24]);\n\t*([v36 @ X29_v1-7C]) = p1.y;\n\t*([v36 @ X29_v1-78]) = p1.z;\n\tv596 = 0x158AD58(v595, 0, maxevals, methodInfo, v59, v60, v61, v62, *([v36 @ X29_v1-24]), p1.y, p1.z, *([v36 @ X29_v1-28]), *([v36 @ X29_v1-88]), *([v36 @ X29_v1-84]), *([v36 @ X29_v1+28]), *([v36 @ X29_v1+24]));\n\t*([v36 @ X29_v1-94]) = p1.y;\n\tv600 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this.m_Points, Il2CppMethodInfo, maxevals, methodInfo, v59, *([v36 @ X29_v1-24]));\n\tv601 = &v37 @ stack_-10_v2 - 0x80;\n\t*([v36 @ X29_v1-80]) = *([v36 @ X29_v1-24]);\n\t*([v36 @ X29_v1-7C]) = p1.y;\n\t*([v36 @ X29_v1-78]) = p1.z;\n\tv602 = 0x158AD58(v601, 0, maxevals, methodInfo, v59, v60, v61, v62, *([v36 @ X29_v1-24]), p1.y, p1.z, *([v36 @ X29_v1-28]), *([v36 @ X29_v1-88]), *([v36 @ X29_v1-84]), *([v36 @ X29_v1+28]), *([v36 @ X29_v1+24]));\n\tv606 = v496 + v590;\n\tv611 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this.m_Points, Il2CppMethodInfo, maxevals, methodInfo, v59, *([v36 @ X29_v1-24]));\n\tv612 = &v37 @ stack_-10_v2 - 0x80;\n\t*([v36 @ X29_v1-80]) = *([v36 @ X29_v1-24]);\n\t*([v36 @ X29_v1-7C]) = *([v36 @ X29_v1-94]);\n\t*([v36 @ X29_v1-78]) = p1.z;\n\tv613 = 0x158AD58(v612, 0, maxevals, methodInfo, v59, v60, v61, v62, *([v36 @ X29_v1-24]), *([v36 @ X29_v1-94]), p1.z, *([v36 @ X29_v1-28]), *([v36 @ X29_v1-88]), *([v36 @ X29_v1-84]), *([v36 @ X29_v1+28]), *([v36 @ X29_v1+24]));\n\tv312 = v496 + v497;\n\tv620 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::EvaluateFirstDerivative(this.m_Points, Il2CppMethodInfo, maxevals, methodInfo, v59, *([v36 @ X29_v1-24]));\n\tv621 = &v37 @ stack_-10_v2 - 0x80;\n\t*([v36 @ X29_v1-80]) = *([v36 @ X29_v1-24]);\n\t*([v36 @ X29_v1-7C]) = *([v36 @ X29_v1-94]);\n\t*([v36 @ X29_v1-78]) = p1.z;\n\tv295 = 0x158AD58(v621, 0, maxevals, methodInfo, v59, v60, v61, v62, *([v36 @ X29_v1-24]), *([v36 @ X29_v1-94]), p1.z, *([v36 @ X29_v1-28]), *([v36 @ X29_v1-88]), *([v36 @ X29_v1-84]), *([v36 @ X29_v1+28]), *([v36 @ X29_v1+24]));\n\tv627 = p1 + *([v36 @ X29_v1-24]);\n\tv632 = v627 * 432f;\n\tv634 = *([v36 @ X29_v1+40]) + *([v36 @ X29_v1+48]);\n\tv635 = *([v36 @ X29_v1-24]) + *([v36 @ X29_v1-24]);\n\tv636 = v634 * 77f;\n\tv637 = v636 + v632;\n\tv638 = v635 * 625f;\n\tv640 = v638 + v637;\n\tv642 = *([v36 @ X29_v1-24]) * 672f;\n\tv643 = v495 / 1470f;\n\tv644 = v642 + v640;\n\tv250 = v643 * v644;\n\tv655 = v312 >= *([v36 @ X29_v1+38]);\n\tif (v655) goto L_0233;\n\tv656 = v499 < *([v36 @ X29_v1+30]);\n\tv657 = ~v656;\n\tv658 = v499 - *([v36 @ X29_v1+30]);\n\tv660 = v658 == 0;\n\tv665 = ~v657;\n\tv143 = v665 | v660;\n\tif (v143) goto L_0233;\n\tv680 = v635 * 5f;\n\tv678 = v495 / 6f;\n\tv693 = v634 + v680;\n\tv694 = v678 * v693;\n\tv676 = v694 - v250;\n\tv166 = v676 < *([v36 @ X29_v1+50]);\n\tif (v166) goto L_0233;\n\tv315 = nevals + 5;\n\t// 372 MakeStruct v120 @ AGGC2BEA0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-24], [v36 @ X29_v1-94], p1.z (System.Single)\n\t// 373 MakeStruct v117 @ AGGC2BEA0_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-28], [v36 @ X29_v1-88], [v36 @ X29_v1-84]\n\tv732 = Obi.ObiPath::GaussLobattoIntegrationStep(this, v120, v117, *([v36 @ X29_v1+10]), *([v36 @ X29_v1+18]), v495, *([v36 @ X29_v1-24]), *([v36 @ X29_v1+20]), *([v36 @ X29_v1-90]), v315, maxevals, *([v36 @ X29_v1+30]));\n\t// 405 MakeStruct v114 @ AGGC2BF14_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-24], [v36 @ X29_v1-94], p1.z (System.Single)\n\t// 406 MakeStruct v111 @ AGGC2BF14_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-28], [v36 @ X29_v1-88], [v36 @ X29_v1-84]\n\tv769 = Obi.ObiPath::GaussLobattoIntegrationStep(this, v114, v111, *([v36 @ X29_v1+10]), *([v36 @ X29_v1+18]), v495, *([v36 @ X29_v1-24]), *([v36 @ X29_v1+20]), *([v36 @ X29_v1-90]), v315, maxevals, v499);\n\t// 438 MakeStruct v108 @ AGGC2BF88_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-24], [v36 @ X29_v1-94], p1.z (System.Single)\n\t// 439 MakeStruct v105 @ AGGC2BF88_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-28], [v36 @ X29_v1-88], [v36 @ X29_v1-84]\n\tv799 = Obi.ObiPath::GaussLobattoIntegrationStep(this, v108, v105, *([v36 @ X29_v1+10]), *([v36 @ X29_v1+18]), v495, *([v36 @ X29_v1-24]), *([v36 @ X29_v1+20]), *([v36 @ X29_v1-90]), v315, maxevals, v591);\n\t// 471 MakeStruct v102 @ AGGC2BFF4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-24], [v36 @ X29_v1-94], p1.z (System.Single)\n\t// 472 MakeStruct v99 @ AGGC2BFF4_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-28], [v36 @ X29_v1-88], [v36 @ X29_v1-84]\n\tv828 = Obi.ObiPath::GaussLobattoIntegrationStep(this, v102, v99, *([v36 @ X29_v1+10]), *([v36 @ X29_v1+18]), v495, *([v36 @ X29_v1-24]), *([v36 @ X29_v1+20]), *([v36 @ X29_v1-90]), v315, maxevals, v496);\n\t// 505 MakeStruct v96 @ AGGC2C06C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-24], [v36 @ X29_v1-94], p1.z (System.Single)\n\t// 506 MakeStruct v93 @ AGGC2C06C_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-28], [v36 @ X29_v1-88], [v36 @ X29_v1-84]\n\tv853 = Obi.ObiPath::GaussLobattoIntegrationStep(this, v96, v93, *([v36 @ X29_v1+10]), *([v36 @ X29_v1+18]), v495, *([v36 @ X29_v1-24]), *([v36 @ X29_v1+20]), *([v36 @ X29_v1-90]), v315, maxevals, v606);\n\t// 537 MakeStruct v90 @ AGGC2C0DC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-24], [v36 @ X29_v1-94], p1.z (System.Single)\n\t// 538 MakeStruct v87 @ AGGC2C0DC_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v36 @ X29_v1-28], [v36 @ X29_v1-88], [v36 @ X29_v1-84]\n\tv283 = Obi.ObiPath::GaussLobattoIntegrationStep(this, v90, v87, *([v36 @ X29_v1+10]), *([v36 @ X29_v1+18]), v495, *([v36 @ X29_v1-24]), *([v36 @ X29_v1+20]), *([v36 @ X29_v1-90]), v315, maxevals, v312);\n\tv867 = v732 + v769;\n\tv869 = v867 + v799;\n\tv871 = v869 + v828;\n\tv332 = v871 + v853;\n\tv250 = v332 + v283;\n\tgoto L_0262;\nL_0233:\n\tv142 = v496 <= *([v36 @ X29_v1+30]);\n\tif (v142) goto L_0246;\n\tv167 = v496 < *([v36 @ X29_v1+38]);\n\tif (v167) goto L_0262;\nL_0246:\n\tgoto L_0250;\n\tv733 = *([v699 @ X0_v27+E0]);\n\tv734 = v733 == 0;\n\tv735 = ~v734;\n\tif (v735) goto L_0250;\n\tv737 = \"il2cpp_codegen_runtime_class_init\"(v699, v249, maxevals, methodInfo, v59, v60, v61, v62, v282, v331, v328, v286, v325, v32\n// ... truncated")]
		private float GaussLobattoIntegrationStep(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float a, float b, float fa, float fb, int nevals, int maxevals, float acc)
		{
			//IL_00df: Expected O, but got I
			//IL_00df: Expected O, but got I4
			//IL_00df: Expected O, but got I
			//IL_00f2: Expected O, but got I
			//IL_016d: Expected F4, but got I
			//IL_016d: Expected O, but got I
			//IL_016d: Expected O, but got I4
			//IL_016d: Expected O, but got I
			//IL_0180: Expected O, but got I
			//IL_01df: Expected F4, but got I
			//IL_01df: Expected O, but got I
			//IL_01df: Expected O, but got I4
			//IL_01df: Expected O, but got I
			//IL_01f2: Expected O, but got I
			//IL_0256: Expected F4, but got I
			//IL_0256: Expected O, but got I
			//IL_0256: Expected O, but got I4
			//IL_0256: Expected O, but got I
			//IL_0269: Expected O, but got I
			//IL_02d0: Expected F4, but got I
			//IL_02d0: Expected O, but got I
			//IL_02d0: Expected O, but got I4
			//IL_02d0: Expected O, but got I
			//IL_02e3: Expected O, but got I
			//IL_035f: Expected O, but got I
			//IL_0534: Expected F4, but got I
			//IL_0549: Expected F4, but got I
			//IL_0570: Expected F4, but got I
			//IL_0585: Expected F4, but got I
			//IL_059a: Expected F4, but got I
			//IL_05fc: Expected F4, but got I
			//IL_05fc: Expected I4, but got F4
			//IL_05fc: Expected F4, but got I
			//IL_05fc: Expected F4, but got I
			//IL_05fc: Expected F4, but got I
			//IL_05fc: Expected O, but got I
			//IL_05fc: Expected O, but got I
			//IL_0615: Expected F4, but got I
			//IL_062a: Expected F4, but got I
			//IL_0651: Expected F4, but got I
			//IL_0666: Expected F4, but got I
			//IL_067b: Expected F4, but got I
			//IL_06d5: Expected I4, but got F4
			//IL_06d5: Expected F4, but got I
			//IL_06d5: Expected F4, but got I
			//IL_06d5: Expected F4, but got I
			//IL_06d5: Expected O, but got I
			//IL_06d5: Expected O, but got I
			//IL_06f3: Expected F4, but got I
			//IL_0708: Expected F4, but got I
			//IL_072f: Expected F4, but got I
			//IL_0744: Expected F4, but got I
			//IL_0759: Expected F4, but got I
			//IL_07b3: Expected I4, but got F4
			//IL_07b3: Expected F4, but got I
			//IL_07b3: Expected F4, but got I
			//IL_07b3: Expected F4, but got I
			//IL_07b3: Expected O, but got I
			//IL_07b3: Expected O, but got I
			//IL_07cc: Expected F4, but got I
			//IL_07e1: Expected F4, but got I
			//IL_0808: Expected F4, but got I
			//IL_081d: Expected F4, but got I
			//IL_0832: Expected F4, but got I
			//IL_088c: Expected I4, but got F4
			//IL_088c: Expected F4, but got I
			//IL_088c: Expected F4, but got I
			//IL_088c: Expected F4, but got I
			//IL_088c: Expected O, but got I
			//IL_088c: Expected O, but got I
			//IL_08aa: Expected F4, but got I
			//IL_08bf: Expected F4, but got I
			//IL_08e6: Expected F4, but got I
			//IL_08fb: Expected F4, but got I
			//IL_0910: Expected F4, but got I
			//IL_096a: Expected I4, but got F4
			//IL_096a: Expected F4, but got I
			//IL_096a: Expected F4, but got I
			//IL_096a: Expected F4, but got I
			//IL_096a: Expected O, but got I
			//IL_096a: Expected O, but got I
			//IL_0983: Expected F4, but got I
			//IL_0998: Expected F4, but got I
			//IL_09bf: Expected F4, but got I
			//IL_09d4: Expected F4, but got I
			//IL_09e9: Expected F4, but got I
			//IL_0a43: Expected I4, but got F4
			//IL_0a43: Expected F4, but got I
			//IL_0a43: Expected F4, but got I
			//IL_0a43: Expected F4, but got I
			//IL_0a43: Expected O, but got I
			//IL_0a43: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			bool flag = !((float)nevals < (float)maxevals);
			float num = 0f;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+38]");
				float num2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+30]");
				float num3 = num2 - 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+30]");
				float num4 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+38]");
				float num5 = num4 + 0f;
				float num6 = num3 * 0.5f;
				float num7 = num5 * 0.5f;
				float num8 = num6 * 0.8164966f;
				float num9 = num7 - num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+24]");
				_ = 0;
				_ = p2.z;
				IntPtr intPtr = default(IntPtr);
				Vector3 v = default(Vector3);
				Vector3 vector2 = default(Vector3);
				Vector3 vector = m_Points.EvaluateFirstDerivative((Vector3)0, (Vector3)maxevals, (Vector3)(long)intPtr, v, vector2.x);
				object obj3 = (long)(IntPtr)obj2 - 128L;
				_ = p1.y;
				_ = p1.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				_ = p2.y;
				float num10 = num6 * 0.4472136f;
				float acc2 = num7 - num10;
				ObiPointsDataChannel obiPointsDataChannel = m_Points;
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				Vector3 vector3 = obiPointsDataChannel.EvaluateFirstDerivative((Vector3)(long)intPtr2, (Vector3)maxevals, (Vector3)(long)intPtr, v, 0f);
				object obj4 = (long)(IntPtr)obj2 - 128L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				_ = 0;
				_ = p1.y;
				_ = p1.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				_ = p1.y;
				ObiPointsDataChannel obiPointsDataChannel2 = m_Points;
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				Vector3 vector4 = obiPointsDataChannel2.EvaluateFirstDerivative((Vector3)(long)intPtr3, (Vector3)maxevals, (Vector3)(long)intPtr, v, 0f);
				object obj5 = (long)(IntPtr)obj2 - 128L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				_ = 0;
				_ = p1.y;
				_ = p1.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				float acc3 = num7 + num10;
				ObiPointsDataChannel obiPointsDataChannel3 = m_Points;
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				Vector3 vector5 = obiPointsDataChannel3.EvaluateFirstDerivative((Vector3)(long)intPtr4, (Vector3)maxevals, (Vector3)(long)intPtr, v, 0f);
				object obj6 = (long)(IntPtr)obj2 - 128L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
				_ = 0;
				_ = p1.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				float num11 = num7 + num8;
				ObiPointsDataChannel obiPointsDataChannel4 = m_Points;
				IntPtr intPtr5 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				Vector3 vector6 = obiPointsDataChannel4.EvaluateFirstDerivative((Vector3)(long)intPtr5, (Vector3)maxevals, (Vector3)(long)intPtr, v, 0f);
				object obj7 = (long)(IntPtr)obj2 - 128L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
				_ = 0;
				_ = p1.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				float num12 = vector2.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				float num13 = num12 + 0f;
				float num14 = num13 * 432f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+40]");
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+48]");
				object obj8 = (long)intPtr6 + 0L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				float num15 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				float num16 = num15 + 0f;
				float num17 = (float)obj8 * 77f;
				float num18 = num17 + num14;
				float num19 = num16 * 625f;
				float num20 = num19 + num18;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
				float num21 = 0f * 672f;
				float num22 = num6 / 1470f;
				float num23 = num21 + num20;
				num = num22 * num23;
				float num24 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+38]");
				if (num24 < 0f)
				{
					float num25 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+30]");
					bool flag2 = num25 < 0f;
					bool flag3 = !flag2;
					float num26 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+30]");
					float num27 = num26 - 0f;
					bool flag4 = num27 == 0f;
					bool flag5 = !flag3;
					if (!(flag5 || flag4))
					{
						float num28 = num16 * 5f;
						float num29 = num6 / 6f;
						float num30 = (float)obj8 + num28;
						float num31 = num29 * num30;
						float num32 = num31 - num;
						float num33 = num32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+50]");
						if (!(num33 < 0f))
						{
							float num34 = (float)nevals + 7E-45f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							Vector3 vector7 = default(Vector3);
							vector7.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
							vector7.y = 0f;
							vector7.z = p1.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-28]");
							Vector3 vector8 = default(Vector3);
							vector8.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
							vector8.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-84]");
							vector8.z = 0f;
							Vector3 p5 = vector7;
							Vector3 p6 = vector8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
							IntPtr intPtr7 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
							IntPtr intPtr8 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							IntPtr intPtr9 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+20]");
							IntPtr intPtr10 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-90]");
							IntPtr intPtr11 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+30]");
							float num35 = GaussLobattoIntegrationStep(p5, p6, (Vector3)(long)intPtr7, (Vector3)(long)intPtr8, num6, (long)intPtr9, (long)intPtr10, (long)intPtr11, (int)num34, maxevals, 0f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							Vector3 vector9 = default(Vector3);
							vector9.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
							vector9.y = 0f;
							vector9.z = p1.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-28]");
							Vector3 vector10 = default(Vector3);
							vector10.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
							vector10.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-84]");
							vector10.z = 0f;
							Vector3 p7 = vector9;
							Vector3 p8 = vector10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
							IntPtr intPtr12 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
							IntPtr intPtr13 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							IntPtr intPtr14 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+20]");
							IntPtr intPtr15 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-90]");
							float num36 = GaussLobattoIntegrationStep(p7, p8, (Vector3)(long)intPtr12, (Vector3)(long)intPtr13, num6, (long)intPtr14, (long)intPtr15, 0f, (int)num34, maxevals, num9);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							Vector3 vector11 = default(Vector3);
							vector11.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
							vector11.y = 0f;
							vector11.z = p1.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-28]");
							Vector3 vector12 = default(Vector3);
							vector12.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
							vector12.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-84]");
							vector12.z = 0f;
							Vector3 p9 = vector11;
							Vector3 p10 = vector12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
							IntPtr intPtr16 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
							IntPtr intPtr17 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							IntPtr intPtr18 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+20]");
							IntPtr intPtr19 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-90]");
							float num37 = GaussLobattoIntegrationStep(p9, p10, (Vector3)(long)intPtr16, (Vector3)(long)intPtr17, num6, (long)intPtr18, (long)intPtr19, 0f, (int)num34, maxevals, acc2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							Vector3 vector13 = default(Vector3);
							vector13.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
							vector13.y = 0f;
							vector13.z = p1.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-28]");
							Vector3 vector14 = default(Vector3);
							vector14.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
							vector14.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-84]");
							vector14.z = 0f;
							Vector3 p11 = vector13;
							Vector3 p12 = vector14;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
							IntPtr intPtr20 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
							IntPtr intPtr21 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							IntPtr intPtr22 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+20]");
							IntPtr intPtr23 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-90]");
							float num38 = GaussLobattoIntegrationStep(p11, p12, (Vector3)(long)intPtr20, (Vector3)(long)intPtr21, num6, (long)intPtr22, (long)intPtr23, 0f, (int)num34, maxevals, num7);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							Vector3 vector15 = default(Vector3);
							vector15.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
							vector15.y = 0f;
							vector15.z = p1.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-28]");
							Vector3 vector16 = default(Vector3);
							vector16.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
							vector16.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-84]");
							vector16.z = 0f;
							Vector3 p13 = vector15;
							Vector3 p14 = vector16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
							IntPtr intPtr24 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
							IntPtr intPtr25 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							IntPtr intPtr26 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+20]");
							IntPtr intPtr27 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-90]");
							float num39 = GaussLobattoIntegrationStep(p13, p14, (Vector3)(long)intPtr24, (Vector3)(long)intPtr25, num6, (long)intPtr26, (long)intPtr27, 0f, (int)num34, maxevals, acc3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							Vector3 vector17 = default(Vector3);
							vector17.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
							vector17.y = 0f;
							vector17.z = p1.z;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-28]");
							Vector3 vector18 = default(Vector3);
							vector18.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
							vector18.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-84]");
							vector18.z = 0f;
							Vector3 p15 = vector17;
							Vector3 p16 = vector18;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+10]");
							IntPtr intPtr28 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+18]");
							IntPtr intPtr29 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-24]");
							IntPtr intPtr30 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+20]");
							IntPtr intPtr31 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-90]");
							float num40 = GaussLobattoIntegrationStep(p15, p16, (Vector3)(long)intPtr28, (Vector3)(long)intPtr29, num6, (long)intPtr30, (long)intPtr31, 0f, (int)num34, maxevals, num11);
							float num41 = num35 + num36;
							float num42 = num41 + num37;
							float num43 = num42 + num38;
							float num44 = num43 + num39;
							num = num44 + num40;
							goto IL_0aff;
						}
					}
				}
				float num45 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+30]");
				if (num45 > 0f)
				{
					float num46 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1+38]");
					if (num46 < 0f)
					{
						goto IL_0aff;
					}
				}
				Debug.LogError("Spline integration reached an interval with no more machine numbers");
			}
			goto IL_0aff;
			IL_0aff:
			return num;
		}

		[Token(Token = "0x60004AB")]
		[Address(RVA = "0xC2C188", Offset = "0xC2C188", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EDFAF0]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202315C]) = v44;\nL_001F:\n\tSystem.Collections.Generic.List`1<System.String>::set_Item(this.m_Names, index, name);\n\tv54 = this.OnControlPointRenamed == 0;\n\tif (v54) goto L_0029;\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::Invoke(this.OnControlPointRenamed, index);\nL_0029:\n\tthis.dirty = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetName(int index, string name)
		{
			m_Names.set_Item(index, name);
			if (OnControlPointRenamed != null)
			{
				OnControlPointRenamed.Invoke(index);
			}
			dirty = true;
		}

		[Token(Token = "0x60004AC")]
		[Address(RVA = "0xC2C220", Offset = "0xC2C220", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF6808]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202315D]) = v41;\nL_0015:\n\tv42 = this.m_Names;\n\tv45 = v42._size < index;\n\tv46 = ~v45;\n\tv47 = v42._size - index;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_0027;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0027:\n\tv60 = v42._items;\n\treturn v60[index @ X1 (System.Int32)];\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetName(int index)
		{
			List<string> names = m_Names;
			bool flag = names.Count < index;
			bool flag2 = !flag;
			int num = names.Count - index;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			string[] items = names._items;
			return items[index];
		}

		[Token(Token = "0x60004AD")]
		[Address(RVA = "0xC2C29C", Offset = "0xC2C29C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = &v33 @ stack_-10_v2;\n\t*([v32 @ X29_v1-18]) = inTangentVector.y;\n\t*([v32 @ X29_v1-14]) = inTangentVector.z;\n\tv62 = Obi.ObiPath::get_ControlPointCount(this);\n\t*([v32 @ X29_v1+40]) = *([v32 @ X29_v1+40]);\n\t*([v32 @ X29_v1+38]) = *([v32 @ X29_v1+38]);\n\t*([v32 @ X29_v1+30]) = *([v32 @ X29_v1+30]);\n\t*([v32 @ X29_v1+24]) = *([v32 @ X29_v1+24]);\n\t*([v32 @ X29_v1+28]) = *([v32 @ X29_v1+28]);\n\t*([v32 @ X29_v1+20]) = *([v32 @ X29_v1+20]);\n\t*([v32 @ X29_v1+14]) = *([v32 @ X29_v1+14]);\n\t*([v32 @ X29_v1+18]) = *([v32 @ X29_v1+18]);\n\t*([v32 @ X29_v1+10]) = *([v32 @ X29_v1+10]);\n\t*([v32 @ X29_v1+54]) = *([v32 @ X29_v1+54]);\n\t*([v32 @ X29_v1+50]) = *([v32 @ X29_v1+50]);\n\t*([v32 @ X29_v1+4C]) = *([v32 @ X29_v1+4C]);\n\t*([v32 @ X29_v1+48]) = *([v32 @ X29_v1+48]);\n\t// 90 MakeStruct v92 @ AGGC2C398_3_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), inTangentVector @ V3 (UnityEngine.Vector3), [v32 @ X29_v1-18], [v32 @ X29_v1-14]\n\tObi.ObiPath::InsertControlPoint(this, v62, position, v92, outTangentVector, normal, mass, rotationalMass, thickness, phase, color, name);\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddControlPoint(Vector3 position, Vector3 inTangentVector, Vector3 outTangentVector, Vector3 normal, float mass, float rotationalMass, float thickness, int phase, Color color, string name)
		{
			//IL_00f6: Expected F4, but got I
			//IL_010b: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = inTangentVector.y;
			_ = inTangentVector.z;
			int controlPointCount = ControlPointCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+24]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+14]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+18]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+54]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+4C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+48]");
			_ = 0;
			Vector3 inTangentVector2 = default(Vector3);
			Vector3 vector = default(Vector3);
			inTangentVector2.x = vector.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-18]");
			inTangentVector2.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-14]");
			inTangentVector2.z = 0f;
			InsertControlPoint(controlPointCount, position, inTangentVector2, outTangentVector, normal, mass, rotationalMass, thickness, phase, color, name);
		}

		[Token(Token = "0x60004AE")]
		[Address(RVA = "0xC2C39C", Offset = "0xC2C39C", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = &v33 @ stack_-10_v2;\n\tgoto L_0029;\n\tv54 = *([1EC2AF8]);\n\tv55 = *([v54 @ X8_v28]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, index, phase, name, methodInfo, v58, v59, v60, position, v0, v2, inTangentVector, v3, v5, mass, rotationalMass);\n\tv65 = 0 | 1;\n\t*([202315E]) = v65;\nL_0029:\n\tv66 = this.m_Points;\n\tv88 = 0x1034188(&v78 @ stack_-C8_v4, 0, phase, name, methodInfo, v58, v59, v60, inTangentVector, inTangentVector.y, inTangentVector.z, position, position.y, position.z, mass, rotationalMass);\n\tSystem.Collections.Generic.List`1<Obi.ObiWingedPoint>::Insert(v66.data, index, &v78 @ stack_-C8_v4);\n\tv160 = this.m_Colors;\n\t// 93 MakeStruct v94 @ AGGC2C4B8_2_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [v32 @ X29_v1+48], [v32 @ X29_v1+4C], [v32 @ X29_v1+50], [v32 @ X29_v1+54]\n\tSystem.Collections.Generic.List`1<UnityEngine.Color>::Insert(*([v160 @ X8_v8 (Obi.ObiColorDataChannel)+20]), index, v94);\n\tv161 = this.m_Normals;\n\t// 108 MakeStruct v91 @ AGGC2C4E4_2_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v32 @ X29_v1+20], [v32 @ X29_v1+24], [v32 @ X29_v1+28]\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Insert(*([v161 @ X8_v11 (Obi.ObiNormalDataChannel)+20]), index, v91);\n\tv162 = this.m_Thickness;\n\tSystem.Collections.Generic.List`1<System.Single>::Insert(*([v162 @ X8_v14 (Obi.ObiThicknessDataChannel)+20]), index, *([v32 @ X29_v1+40]));\n\tv163 = this.m_Masses;\n\tSystem.Collections.Generic.List`1<System.Single>::Insert(*([v163 @ X8_v15 (Obi.ObiMassDataChannel)+20]), index, *([v32 @ X29_v1+30]));\n\tv164 = this.m_RotationalMasses;\n\tSystem.Collections.Generic.List`1<System.Single>::Insert(*([v164 @ X8_v16 (Obi.ObiRotationalMassDataChannel)+20]), index, *([v32 @ X29_v1+38]));\n\tv165 = this.m_Phases;\n\tSystem.Collections.Generic.List`1<System.Int32>::Insert(*([v165 @ X8_v17 (Obi.ObiPhaseDataChannel)+20]), index, phase);\n\tSystem.Collections.Generic.List`1<System.String>::Insert(this.m_Names, index, name);\n\tv244 = this.OnControlPointAdded == 0;\n\tif (v244) goto L_00AC;\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::Invoke(this.OnControlPointAdded, index);\nL_00AC:\n\tthis.dirty = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void InsertControlPoint(int index, Vector3 position, Vector3 inTangentVector, Vector3 outTangentVector, Vector3 normal, float mass, float rotationalMass, float thickness, int phase, Color color, string name)
		{
			//IL_0032: Expected O, but got Ref
			//IL_0056: Expected F4, but got I
			//IL_006b: Expected F4, but got I
			//IL_0080: Expected F4, but got I
			//IL_0095: Expected F4, but got I
			//IL_00ae: Expected O, but got I
			//IL_00d2: Expected F4, but got I
			//IL_00e7: Expected F4, but got I
			//IL_00fc: Expected F4, but got I
			//IL_0115: Expected O, but got I
			//IL_0145: Expected F4, but got I
			//IL_0145: Expected O, but got I
			//IL_0175: Expected F4, but got I
			//IL_0175: Expected O, but got I
			//IL_01a5: Expected F4, but got I
			//IL_01a5: Expected O, but got I
			//IL_01cd: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			ObiPointsDataChannel obiPointsDataChannel = m_Points;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1034188 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x1F0)");
			object obj3 = default(object);
			obiPointsDataChannel.data.Insert(index, (ObiWingedPoint)(&obj3));
			ObiColorDataChannel obiColorDataChannel = colors;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+48]");
			Color item = default(Color);
			item.r = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+4C]");
			item.g = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+50]");
			item.b = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+54]");
			item.a = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v8 (Obi.ObiColorDataChannel)+20]");
			((List<Color>)0).Insert(index, item);
			ObiNormalDataChannel obiNormalDataChannel = normals;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+20]");
			Vector3 item2 = default(Vector3);
			item2.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+24]");
			item2.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+28]");
			item2.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ X8_v11 (Obi.ObiNormalDataChannel)+20]");
			((List<Vector3>)0).Insert(index, item2);
			ObiThicknessDataChannel obiThicknessDataChannel = thicknesses;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X8_v14 (Obi.ObiThicknessDataChannel)+20]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+40]");
			((List<float>)(long)intPtr).Insert(index, 0f);
			ObiMassDataChannel obiMassDataChannel = masses;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X8_v15 (Obi.ObiMassDataChannel)+20]");
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+30]");
			((List<float>)(long)intPtr2).Insert(index, 0f);
			ObiRotationalMassDataChannel obiRotationalMassDataChannel = rotationalMasses;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ X8_v16 (Obi.ObiRotationalMassDataChannel)+20]");
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1+38]");
			((List<float>)(long)intPtr3).Insert(index, 0f);
			ObiPhaseDataChannel obiPhaseDataChannel = phases;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v17 (Obi.ObiPhaseDataChannel)+20]");
			((List<int>)0).Insert(index, phase);
			m_Names.Insert(index, name);
			if (OnControlPointAdded != null)
			{
				OnControlPointAdded.Invoke(index);
			}
			dirty = true;
		}

		[Token(Token = "0x60004AF")]
		[Address(RVA = "0xC2C5E8", Offset = "0xC2C5E8", Length = "0xA2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0027;\n\tv52 = *([1EE55B0]);\n\tv53 = *([v52 @ X8_v29]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, methodInfo, v56, v57, v58, v59, v60, v61, mu, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([202315F]) = v71;\nL_0027:\n\t*([v40 @ X29_v1-C4]) = 0;\n\t*([v40 @ X29_v1-D0]) = 0;\n\t*([v40 @ X29_v1-F0]) = 0;\n\t*([v40 @ X29_v1-E0]) = 0;\n\tv77 = Obi.ObiPath::get_ControlPointCount(this);\n\tv89 = v77 < 2;\n\tif (v89) goto L_FFFFFFFF;\n\tv92 = System.Single::IsNaN(mu);\n\tv96 = v92 == 0;\n\tif (v96) goto L_0044;\n\tgoto L_035A;\nL_0044:\n\tv418 = &v41 @ stack_-10_v2 - 0xC4;\n\tv421 = Obi.ObiPath::GetSpanControlPointForMu(this, mu, v418);\n\tv642 = &v638 @ stack_-158;\n\tv643 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this.m_Points, v421);\n\t*([v40 @ X29_v1-D0]) = v886;\n\t*([v40 @ X29_v1-F0]) = *([v642 @ X23_v5]);\n\t*([v40 @ X29_v1-E0]) = *([v642 @ X23_v5+10]);\n\tv395 = v421 + 1;\n\tv1007 = v395 / v77;\n\tv1008 = v1007 * v77;\n\tv849 = v395 - v1008;\n\tv1011 = Obi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::get_Item(this.m_Points, v849);\n\tgoto L_007C;\n\tv1027 = *([v1023 @ X0_v19+E0]);\n\tv1028 = v1027 == 0;\n\tv1029 = ~v1028;\n\tif (v1029) goto L_007C;\n\tv1031 = \"il2cpp_codegen_runtime_class_init\"(v1023, v1010, v918, v57, v58, v59, v60, v61, v1013, v1014, v63, v64, v65, v66, v67, v68);\nL_007C:\n\tv1035 = 1f - *([v40 @ X29_v1-C4]);\n\t// 130 MakeStruct v347 @ AGGC2C750_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v40 @ X29_v1-E0], [v40 @ X29_v1-DC], [v40 @ X29_v1-D8]\n\tv1041 = UnityEngine.Vector3::op_Multiply(v1035, v347);\n\tv1045 = &v41 @ stack_-10_v2 - 0xF0;\n\tv1050 = 0x10340E8(v1045, 0, Il2CppMethodInfo, v57, v58, v59, v60, v61, v1041, v1041.y, v1041.z, *([v40 @ X29_v1-D8]), v65, v66, v67, v68);\n\tv1059 = UnityEngine.Vector3::op_Multiply(*([v40 @ X29_v1-C4]), v1041);\n\tv1069 = UnityEngine.Vector3::op_Addition(v1041, v1059);\n\tv1074 = &v41 @ stack_-10_v2 - 0xF0;\n\tv1076 = 0x10340E8(v1074, 0, Il2CppMethodInfo, v57, v58, v59, v60, v61, v1069, v1069.y, v1069.z, v1059, v1059.y, v1059.z, v67, v68);\n\tv1081 = 1f - *([v40 @ X29_v1-C4]);\n\tv1086 = UnityEngine.Vector3::op_Multiply(v1081, v1069);\n\tv1096 = 0x1034048(&v1091 @ stack_-130_v6, 0, Il2CppMethodInfo, v57, v58, v59, v60, v61, v1086, v1086.y, v1086.z, v1069.z, v1069.y, v1069.z, v67, v68);\n\tv1105 = UnityEngine.Vector3::op_Multiply(*([v40 @ X29_v1-C4]), v1086);\n\tv1115 = UnityEngine.Vector3::op_Addition(v1086, v1105);\n\tv1125 = 0x1034048(&v1091 @ stack_-130_v6, 0, Il2CppMethodInfo, v57, v58, v59, v60, v61, v1115, v1115.y, v1115.z, v1105, v1105.y, v1105.z, v67, v68);\n\tv1129 = 1f - *([v40 @ X29_v1-C4]);\n\tv1134 = UnityEngine.Vector3::op_Multiply(v1129, v1115);\n\t// 245 MakeStruct v301 @ AGGC2C8C0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1015 @ stack_-170, v1138 @ stack_-11C, v1144 @ stack_-118\n\tv1148 = UnityEngine.Vector3::op_Multiply(*([v40 @ X29_v1-C4]), v301);\n\tv1158 = UnityEngine.Vector3::op_Addition(v1134, v1148);\n\tv1165 = 1f - *([v40 @ X29_v1-C4]);\n\tv1167 = UnityEngine.Vector3::op_Multiply(v1165, v1069);\n\tv1178 = UnityEngine.Vector3::op_Multiply(*([v40 @ X29_v1-C4]), v1115);\n\tv1188 = UnityEngine.Vector3::op_Addition(v1167, v1178);\n\tv1195 = 1f - *([v40 @ X29_v1-C4]);\n\tv1200 = UnityEngine.Vector3::op_Multiply(v1195, v1115);\n\tv1211 = UnityEngine.Vector3::op_Multiply(*([v40 @ X29_v1-C4]), v1158);\n\tv1221 = UnityEngine.Vector3::op_Addition(v1200, v1211);\n\tv1228 = 1f - *([v40 @ X29_v1-C4]);\n\tv1233 = UnityEngine.Vector3::op_Multiply(v1228, v1188);\n\tv1244 = UnityEngine.Vector3::op_Multiply(*([v40 @ X29_v1-C4]), v1221);\n\tv1251 = UnityEngine.Vector3::op_Addition(v1233, v1244);\n\tv1257 = &v41 @ stack_-10_v2 - 0xF0;\n\tv1259 = 0x1034364(v1257, 0, Il2CppMethodInfo, v57, v58, v59, v60, v61, v1069, v1069.y, v1069.z, v1244, v1244.y, v1244.z, v67, v68);\n\tv1263 = 0x10341AC(&v1091 @ stack_-130_v6, 0, Il2CppMethodInfo, v57, v58, v59, v60, v61, v1158, v1158.y, v1158.z, v1244, v1244.y, v1244.z, v67, v68);\n\tv919 = &v41 @ stack_-10_v2 - 0xC0;\n\t*([v40 @ X29_v1-A0]) = *([v40 @ X29_v1-D0]);\n\t*([v40 @ X29_v1-C0]) = *([v40 @ X29_v1-F0]);\n\t*([v40 @ X29_v1-B0]) = *([v40 @ X29_v1-E0]);\n\tObi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::set_Item(this.m_Points, v421, v919);\n\tv821 = &v41 @ stack_-10_v2 - 0xC0;\n\t*([v40 @ X29_v1-A0]) = v1017;\n\t*([v40 @ X29_v1-C0]) = v1091;\n\t*([v40 @ X29_v1-B0]) = v1015;\n\tObi.ObiPathDataChannel`2<Obi.ObiWingedPoint, UnityEngine.Vector3>::set_Item(this.m_Points, v849, v821);\n\tv954 = Obi.ObiPathDataChannel`2<UnityEngine.Color, UnityEngine.Color>::get_Item(this.m_Colors, v421);\n\tv955 = Obi.ObiPathDataChannel`2<UnityEngine.Color, UnityEngine.Color>::get_Item(this.m_Colors, v421);\n\tv956 = Obi.ObiPathDataChannel`2<UnityEngine.Color, UnityEngine.Color>::get_Item(this.m_Colors, v849);\n\tv1271 = Obi.ObiPathDataChannel`2<UnityEngine.Color, UnityEngine.Color>::get_Item(this.m_Colors, v849);\n\tv843 = Obi.ObiPathDataChannel`2<UnityEngine.Color, UnityEngine.Color>::Evaluate(this.m_Colors, v954, v955, v956, v956.b, v1271);\n\tv957 = Obi.ObiPathDataChannel`2<UnityEngine.Vector3, UnityEngine.Vector3>::get_Item(this.m_Normals, v421);\n\tv958 = Obi.ObiPathDataChannel`2<UnityEngine.Vector3, UnityEngine.Vector3>::get_Item(this.m_Normals, v421);\n\tv959 = Obi.ObiPathDataChannel`2<UnityEngine.Vector3, UnityEngine.Vector3>::get_Item(this.m_Normals, v849);\n\tv1284 = Obi.ObiPathDataChannel`2<UnityEngine.Vector3, UnityEngine.Vector3>::get_Item(this.m_Normals, v849);\n\tv844 = Obi.ObiPathDataChannel`2<UnityEngine.Vector3, UnityEngine.Vector3>::Evaluate(this.m_Normals, v957, v958, v959, v959.z, v955.b);\n\tv960 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Thickness, v421);\n\tv961 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Thickness, v421);\n\tv962 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Thickness, v849);\n\tv1295 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Thickness, v849);\n\tv845 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::Evaluate(this.m_Thickness, v960, v961, v962, v1295, *([v40 @ X29_v1-C4]));\n\tv963 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Masses, v421);\n\tv964 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Masses, v421);\n\tv965 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Masses, v849);\n\tv1300 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_Masses, v849);\n\tv846 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::Evaluate(this.m_Masses, v963, v964, v965, v1300, *([v40 @ X29_v1-C4]));\n\tv966 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_RotationalMasses, v421);\n\tv967 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_RotationalMasses, v421);\n\tv968 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_RotationalMasses, v849);\n\tv1304 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::get_Item(this.m_RotationalMasses, v849);\n\tv847 = Obi.ObiPathDataChannel`2<System.Single, System.Single>::Evaluate(this.m_RotationalMasses, v966, v967, v968, v1304, *([v40 @ X29_v1-C4]));\n\tv857 = Obi.ObiPathDataChannel`2<System.Int32, System.Int32>::get_Item(this.m_Phases, v421);\n\tv858 = Obi.ObiPathDataChannel`2<System.Int32, System.Int32>::get_Item(this.m_Phases, v421);\n\tv859 = Obi.ObiPathDataChannel`2<System.Int32, System.Int32>::get_Item(this.m_Phases, v849);\n\tv1313 = Obi.ObiPathDataChannel`2<System.Int32, System.Int32>::get_Item(this.m_Phases, v849);\n\tv1320 = Obi.ObiPathDataChannel`2<System.Int32, System.Int32>::Evaluate(this.m_Phases, v857, v858, v859, v1313, *([v40 @ X29_v1-C4]));\n\tv1328 = UnityEngine.Vector3::op_Subtraction(v1188, v1251);\n\tv1338 = UnityEngine.Vector3::op_Subtraction(v1221, v1251);\n\tv1343 = Obi.ObiPath::GetName(this, v421);\n\tObi.ObiPath::InsertControlPoint(this, v395, v1251, v1328, v1338, v1338.z, v955.b, v955.a, v844, v1320, v844.z, v1343);\nL_035A:\n\treturn v395;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 744 bookkeeping instructions omi\n// ... truncated")]
		public unsafe int InsertControlPoint(float mu)
		{
			//IL_011c: Expected F4, but got I
			//IL_0131: Expected F4, but got I
			//IL_0146: Expected F4, but got I
			//IL_0166: Expected O, but got I
			//IL_018a: Expected F4, but got I
			//IL_01b3: Expected O, but got I
			//IL_020a: Expected F4, but got I
			//IL_0269: Expected F4, but got O
			//IL_0276: Expected F4, but got O
			//IL_0283: Expected F4, but got O
			//IL_0298: Expected F4, but got I
			//IL_02f5: Expected F4, but got I
			//IL_034d: Expected F4, but got I
			//IL_03aa: Expected F4, but got I
			//IL_03d3: Expected O, but got I
			//IL_03fb: Expected O, but got I
			//IL_0449: Expected O, but got I
			//IL_04f4: Expected O, but got F4
			//IL_0581: Expected O, but got F4
			//IL_060c: Expected F4, but got I
			//IL_0697: Expected F4, but got I
			//IL_0722: Expected F4, but got I
			//IL_07ad: Expected F4, but got I
			//IL_0836: Expected O, but got F4
			//IL_0836: Expected O, but got F4
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			int controlPointCount = ControlPointCount;
			int num;
			if (controlPointCount < 2 || float.IsNaN(mu))
			{
				num = -1;
			}
			else
			{
				int spanControlPointForMu = GetSpanControlPointForMu(mu, out *(float*)((long)(IntPtr)obj2 - 196L));
				object obj4 = default(object);
				object obj3 = obj4;
				ObiWingedPoint obiWingedPoint = ((ObiPathDataChannel<ObiWingedPoint, Vector3>)m_Points).get_Item(spanControlPointForMu);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ X23_v5+10]");
				_ = 0;
				num = spanControlPointForMu + 1;
				int num2 = num / controlPointCount;
				int num3 = num2 * controlPointCount;
				int i = num - num3;
				ObiWingedPoint obiWingedPoint2 = ((ObiPathDataChannel<ObiWingedPoint, Vector3>)m_Points).get_Item(i);
				float num4 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num5 = num4 - 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-E0]");
				Vector3 vector = default(Vector3);
				vector.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-DC]");
				vector.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-D8]");
				vector.z = 0f;
				Vector3 vector2 = num5 * vector;
				object obj5 = (long)(IntPtr)obj2 - 240L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				Vector3 vector3 = 0f * vector2;
				Vector3 vector4 = vector2 + vector3;
				object obj6 = (long)(IntPtr)obj2 - 240L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
				float num6 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num7 = num6 - 0f;
				Vector3 vector5 = num7 * vector4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				Vector3 vector6 = 0f * vector5;
				Vector3 vector7 = vector5 + vector6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
				float num8 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num9 = num8 - 0f;
				Vector3 vector8 = num9 * vector7;
				Vector3 vector9 = default(Vector3);
				object obj7 = default(object);
				vector9.x = (float)obj7;
				object obj8 = default(object);
				vector9.y = (float)obj8;
				object obj9 = default(object);
				vector9.z = (float)obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				Vector3 vector10 = 0f * vector9;
				Vector3 vector11 = vector8 + vector10;
				float num10 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num11 = num10 - 0f;
				Vector3 vector12 = num11 * vector4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				Vector3 vector13 = 0f * vector7;
				Vector3 vector14 = vector12 + vector13;
				float num12 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num13 = num12 - 0f;
				Vector3 vector15 = num13 * vector7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				Vector3 vector16 = 0f * vector11;
				Vector3 vector17 = vector15 + vector16;
				float num14 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num15 = num14 - 0f;
				Vector3 vector18 = num15 * vector14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				Vector3 vector19 = 0f * vector17;
				Vector3 vector20 = vector18 + vector19;
				object obj10 = (long)(IntPtr)obj2 - 240L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1034364 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x3CC)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10341AC (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x214)");
				ObiWingedPoint value = (ObiWingedPoint)((long)(IntPtr)obj2 - 192L);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-D0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-F0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-E0]");
				_ = 0;
				((ObiPathDataChannel<ObiWingedPoint, Vector3>)m_Points).set_Item(spanControlPointForMu, value);
				ObiWingedPoint value2 = (ObiWingedPoint)((long)(IntPtr)obj2 - 192L);
				((ObiPathDataChannel<ObiWingedPoint, Vector3>)m_Points).set_Item(i, value2);
				Color v = ((ObiPathDataChannel<Color, Color>)colors).get_Item(spanControlPointForMu);
				Color v2 = ((ObiPathDataChannel<Color, Color>)colors).get_Item(spanControlPointForMu);
				Color v3 = ((ObiPathDataChannel<Color, Color>)colors).get_Item(i);
				Color color = ((ObiPathDataChannel<Color, Color>)colors).get_Item(i);
				Color color2 = colors.Evaluate(v, v2, v3, (Color)v3.b, color.r);
				Vector3 v4 = ((ObiPathDataChannel<Vector3, Vector3>)normals).get_Item(spanControlPointForMu);
				Vector3 v5 = ((ObiPathDataChannel<Vector3, Vector3>)normals).get_Item(spanControlPointForMu);
				Vector3 v6 = ((ObiPathDataChannel<Vector3, Vector3>)normals).get_Item(i);
				Vector3 vector21 = ((ObiPathDataChannel<Vector3, Vector3>)normals).get_Item(i);
				Vector3 vector22 = normals.Evaluate(v4, v5, v6, (Vector3)v6.z, v2.b);
				float v7 = ((ObiPathDataChannel<float, float>)thicknesses).get_Item(spanControlPointForMu);
				float v8 = ((ObiPathDataChannel<float, float>)thicknesses).get_Item(spanControlPointForMu);
				float v9 = ((ObiPathDataChannel<float, float>)thicknesses).get_Item(i);
				float v10 = ((ObiPathDataChannel<float, float>)thicknesses).get_Item(i);
				ObiThicknessDataChannel obiThicknessDataChannel = thicknesses;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num16 = obiThicknessDataChannel.Evaluate(v7, v8, v9, v10, 0f);
				float v11 = ((ObiPathDataChannel<float, float>)masses).get_Item(spanControlPointForMu);
				float v12 = ((ObiPathDataChannel<float, float>)masses).get_Item(spanControlPointForMu);
				float v13 = ((ObiPathDataChannel<float, float>)masses).get_Item(i);
				float v14 = ((ObiPathDataChannel<float, float>)masses).get_Item(i);
				ObiMassDataChannel obiMassDataChannel = masses;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num17 = obiMassDataChannel.Evaluate(v11, v12, v13, v14, 0f);
				float v15 = ((ObiPathDataChannel<float, float>)rotationalMasses).get_Item(spanControlPointForMu);
				float v16 = ((ObiPathDataChannel<float, float>)rotationalMasses).get_Item(spanControlPointForMu);
				float v17 = ((ObiPathDataChannel<float, float>)rotationalMasses).get_Item(i);
				float v18 = ((ObiPathDataChannel<float, float>)rotationalMasses).get_Item(i);
				ObiRotationalMassDataChannel obiRotationalMassDataChannel = rotationalMasses;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				float num18 = obiRotationalMassDataChannel.Evaluate(v15, v16, v17, v18, 0f);
				int v19 = ((ObiPathDataChannel<int, int>)phases).get_Item(spanControlPointForMu);
				int v20 = ((ObiPathDataChannel<int, int>)phases).get_Item(spanControlPointForMu);
				int v21 = ((ObiPathDataChannel<int, int>)phases).get_Item(i);
				int v22 = ((ObiPathDataChannel<int, int>)phases).get_Item(i);
				ObiPhaseDataChannel obiPhaseDataChannel = phases;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-C4]");
				int phase = obiPhaseDataChannel.Evaluate(v19, v20, v21, v22, 0f);
				Vector3 inTangentVector = vector14 - vector20;
				Vector3 outTangentVector = vector17 - vector20;
				string name = GetName(spanControlPointForMu);
				InsertControlPoint(num, vector20, inTangentVector, outTangentVector, (Vector3)outTangentVector.z, v2.b, v2.a, vector22.x, phase, (Color)vector22.z, name);
			}
			return num;
		}

		[Token(Token = "0x60004B0")]
		[Address(RVA = "0xC2D014", Offset = "0xC2D014", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Obi.ObiPath::get_ControlPointCount(this);\n\tv22 = v12 - 1;\n\tv15 = v22 & 0x80000000;\n\tv16 = v15 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0019;\nL_000F:\n\tObi.ObiPath::RemoveControlPoint(this, v22);\n\tv22 = v22 - 1;\n\tv35 = v22 & 0x80000000;\n\tv21 = v35 == 0;\n\tif (v21) goto L_000F;\nL_0019:\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			//IL_002a: Expected I4, but got I8
			//IL_007c: Expected I4, but got I8
			int controlPointCount = ControlPointCount;
			int num = controlPointCount - 1;
			if ((int)(num & 0x80000000L) == 0)
			{
				do
				{
					RemoveControlPoint(num);
					num--;
				}
				while ((int)(num & 0x80000000L) == 0);
			}
		}

		[Token(Token = "0x60004B1")]
		[Address(RVA = "0xC2D050", Offset = "0xC2D050", Length = "0x344")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EEE220]);\n\tv31 = *([v30 @ X8_v38]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, index, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2023160]) = v49;\nL_001A:\n\tv51 = Obi.ObiPath::GetDataChannels(this);\n\tgoto L_004B;\n\tv123 = *([v55 @ X8_v6+B0]);\n\tv124 = 0;\n\tv125 = v123 + 8;\n\tv127 = *([v193 @ X11_v36-8]);\n\tv199 = v127 == v58;\n\tif (v199) goto L_0044;\n\tv149 = v194 + 1;\n\tv250 = v149 < v57;\n\tv145 = ~v250;\n\tv147 = v193 + 0x10;\n\tv129 = ~v145;\n\tif (v129) goto L_FFFFFFFF;\n\tv150 = v52;\n\tv151 = 0;\n\tv152 = 0x8909C4(v150, v58, v151, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_004B;\nL_0044:\n\tv251 = *([v193 @ X11_v36]);\n\tv252 = v251 << 4;\n\tv253 = v55 + v252;\n\tv254 = v253 + 0x130;\nL_004B:\n\tv275 = System.Collections.Generic.IEnumerable`1<Obi.IObiPathDataChannel>::GetEnumerator(v51);\nL_0059:\n\tgoto L_0080;\n\tv368 = *([v362 @ X8_v23+B0]);\n\tv369 = 0;\n\tv370 = v368 + 8;\n\tv372 = *([v438 @ X11_v31-8]);\n\tv444 = v372 == v363;\n\tif (v444) goto L_0079;\n\tv394 = v439 + 1;\n\tv449 = v394 < v364;\n\tv390 = ~v449;\n\tv392 = v438 + 0x10;\n\tv374 = ~v390;\n\tif (v374) goto L_FFFFFFFF;\n\tv395 = v121;\n\tv396 = 0;\n\tv397 = 0x8909C4(v395, v363, v396, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0080;\nL_0079:\n\tv450 = *([v438 @ X11_v31]);\n\tv451 = v450 << 4;\n\tv452 = v362 + v451;\n\tv453 = v452 + 0x130;\nL_0080:\n\tv474 = System.Collections.IEnumerator::MoveNext(v275);\n\tv476 = v474 == 0;\n\tif (v476) goto L_00E4;\n\tgoto L_00AF;\n\tv487 = *([v478 @ X8_v26+B0]);\n\tv488 = 0;\n\tv489 = v487 + 8;\n\tv491 = *([v558 @ X11_v26-8]);\n\tv564 = v491 == v479;\n\tif (v564) goto L_00A8;\n\tv513 = v559 + 1;\n\tv624 = v513 < v480;\n\tv509 = ~v624;\n\tv511 = v558 + 0x10;\n\tv493 = ~v509;\n\tif (v493) goto L_FFFFFFFF;\n\tv514 = v121;\n\tv515 = 0;\n\tv516 = 0x8909C4(v514, v479, v515, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00AF;\nL_00A8:\n\tv625 = *([v558 @ X11_v26]);\n\tv626 = v625 << 4;\n\tv627 = v478 + v626;\n\tv628 = v627 + 0x130;\nL_00AF:\n\tv424 = System.Collections.Generic.IEnumerator`1<Obi.IObiPathDataChannel>::get_Current(v275);\n\tv425 = v424 == 0;\n\tif (v425) goto L_00EB;\n\tv655 = *([v424 @ X0_v37 (Obi.IObiPathDataChannel)]);\n\tv316 = *([v655 @ X8_v29 (Il2CppClass<Obi.IObiPathDataChannel>)+126]) == 0;\n\tif (v316) goto L_00D5;\n\tv710 = *([v655 @ X8_v29 (Il2CppClass<Obi.IObiPathDataChannel>)+B0]) + 8;\nL_00C0:\n\tv716 = *([v710 @ X11_v21-8]) == Obi.IObiPathDataChannel;\n\tif (v716) goto L_00D8;\n\tv711 = v711 + 1;\n\tv726 = v711 < *([v655 @ X8_v29 (Il2CppClass<Obi.IObiPathDataChannel>)+126]);\n\tv692 = ~v726;\n\tv710 = v710 + 0x10;\n\tv676 = ~v692;\n\tif (v676) goto L_00C0;\nL_00D5:\n\tv733 = 0x8909C4(v424, Obi.IObiPathDataChannel, 3, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00DD;\nL_00D8:\n\tv728 = *([v710 @ X11_v21]) + 3;\n\tv729 = v728 << 4;\n\tv730 = v655 + v729;\n\tv733 = v730 + 0x130;\nL_00DD:\n\tv214 = *([v733 @ X0_v38+8]);\n\t*([v733 @ X0_v38])(v314, v424, index, *([v733 @ X0_v38+8]), v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0059;\nL_00E4:\n\tv484 = v275 == 0;\n\tv485 = ~v484;\n\tif (v485) goto L_0107;\n\tgoto L_012F;\n\tthrow System.NullReferenceException;\nL_00EB:\n\tv243 = new System.NullReferenceException();\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\n\tgoto L_00F9;\nL_00F9:\n\tv217 = v236 != 1;\n\tif (v217) goto L_015B;\n\tv486 = 0x6D2BC0(v243, v236, v214, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv518 = *([v486 @ X0_v28]);\n\tv538 = 0x6D2490(v486, v236, v214, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv540 = v275 == 0;\n\tif (v540) goto L_012F;\nL_0107:\n\tgoto L_012E;\n\tv594 = *([v543 @ X8_v18+B0]);\n\tv595 = 0;\n\tv596 = v594 + 8;\n\tv598 = *([v644 @ X11_v12-8]);\n\tv650 = v598 == v546;\n\tif (v650) goto L_0127;\n\tv620 = v645 + 1;\n\tv662 = v620 < v545;\n\tv616 = ~v662;\n\tv618 = v644 + 0x10;\n\tv600 = ~v616;\n\tif (v600) goto L_FFFFFFFF;\n\tv621 = v121;\n\tv622 = 0;\n\tv623 = 0x8909C4(v621, v546, v622, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_012E;\nL_0127:\n\tv663 = *([v644 @ X11_v12]);\n\tv664 = v663 << 4;\n\tv665 = v543 + v664;\n\tv666 = v665 + 0x130;\nL_012E:\n\tSystem.IDisposable::Dispose(v275);\nL_012F:\n\tv593 = v70 + 1;\n\tv93 = v593 == 0;\n\tv78 = ~v93;\n\tif (v78) goto L_0140;\n\tv632 = v68 == 0;\n\tv176 = ~v632;\n\tif (v176) goto L_015A;\nL_0140:\n\tSystem.Collections.Generic.List`1<System.String>::RemoveAt(this.m_Names, index);\n\tv351 = this.OnControlPointRemoved == 0;\n\tif (v351) goto L_014A;\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::Invoke(this.OnControlPointRemoved, index);\nL_014A:\n\tthis.dirty = 1;\n\treturn;\n\tthrow System.NullReferenceException;\nL_015A:\n\tv182 = new System.TypeLoadException();\nL_015B:\n\tv249 = 0x6D2380(v243, v236, v214, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\n// 195 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveControlPoint(int index)
		{
			//IL_001c: Expected I, but got O
			//IL_019b: Expected I4, but got O
			//IL_0057: Expected O, but got I
			//IL_01ca: Expected I4, but got O
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00f6: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_00a3: Expected O, but got I
			IEnumerable<IObiPathDataChannel> dataChannels = GetDataChannels();
			IEnumerator<IObiPathDataChannel> enumerator = dataChannels.GetEnumerator();
			int num = 0;
			int num2 = 0;
			object obj5 = default(object);
			while (true)
			{
				int num3;
				int num4;
				int num5;
				int num6;
				NullReferenceException ex;
				if (!enumerator.MoveNext())
				{
					bool flag = enumerator == null;
					bool flag2 = !flag;
					num3 = 0;
					num4 = 0;
					if (!flag2)
					{
						num5 = 0;
						num6 = 0;
						goto IL_0367;
					}
				}
				else
				{
					IObiPathDataChannel current = enumerator.Current;
					if (current != null)
					{
						IntPtr intPtr = (IntPtr)current;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ X8_v29 (Il2CppClass<Obi.IObiPathDataChannel>)+126]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ X8_v29 (Il2CppClass<Obi.IObiPathDataChannel>)+B0]");
							object obj = 0L + 8L;
							int num7 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ X11_v21-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IObiPathDataChannel))
								{
									break;
								}
								num7++;
								int num8 = num7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ X8_v29 (Il2CppClass<Obi.IObiPathDataChannel>)+126]");
								bool flag3 = (long)num8 < 0L;
								bool flag4 = !flag3;
								obj = (long)(IntPtr)obj + 16L;
								if (!flag4)
								{
									continue;
								}
								goto IL_00bc;
							}
							object obj2 = obj + 3;
							int num9 = (int)((long)(IntPtr)obj2 << 4);
							object obj3 = (long)intPtr + (long)num9;
							object obj4 = (long)(IntPtr)obj3 + 304L;
							goto IL_0340;
						}
						goto IL_00bc;
					}
					ex = new NullReferenceException();
					if (num2 != 1)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					num3 = (int)obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					bool flag5 = enumerator == null;
					num4 = -1;
					num5 = (int)obj5;
					num6 = -1;
					if (flag5)
					{
						goto IL_0367;
					}
				}
				enumerator.Dispose();
				num5 = num3;
				num6 = num4;
				goto IL_0367;
				IL_0367:
				if (num6 + 1 != 0 || num5 == 0)
				{
					m_Names.RemoveAt(index);
					if (OnControlPointRemoved != null)
					{
						OnControlPointRemoved.Invoke(index);
					}
					dirty = true;
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
				num = 0;
				num2 = 0;
				ex = (NullReferenceException)(object)ex2;
				break;
				IL_0340:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ X0_v38+8]");
				num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v733 @ X0_v38] (should have been resolved before IL gen)");
				num2 = index;
				continue;
				IL_00bc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0340;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60004B2")]
		[Address(RVA = "0xC2D394", Offset = "0xC2D394", Length = "0x3B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EC9118]);\n\tv31 = *([v30 @ X8_v38]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023161]) = v50;\nL_001F:\n\tv57 = this.dirty == 0;\n\tv62 = ~v57;\n\tv64 = Obi.ObiPath::GetDataChannels(this);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0126;\n\tgoto L_0057;\n\tv129 = *([v68 @ X8_v14+B0]);\n\tv130 = 0;\n\tv131 = v129 + 8;\n\tv133 = *([v169 @ X11_v41-8]);\n\tv175 = v133 == v71;\n\tif (v175) goto L_0050;\n\tv155 = v170 + 1;\n\tv190 = v155 < v70;\n\tv151 = ~v190;\n\tv153 = v169 + 0x10;\n\tv135 = ~v151;\n\tif (v135) goto L_FFFFFFFF;\n\tv156 = v65;\n\tv157 = 0;\n\tv158 = 0x8909C4(v156, v71, v157, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0057;\nL_0050:\n\tv191 = *([v169 @ X11_v41]);\n\tv192 = v191 << 4;\n\tv193 = v68 + v192;\n\tv194 = v193 + 0x130;\nL_0057:\n\tv215 = System.Collections.Generic.IEnumerable`1<Obi.IObiPathDataChannel>::GetEnumerator(v64);\nL_0066:\n\tgoto L_008D;\n\tv390 = *([v318 @ X8_v19+B0]);\n\tv391 = 0;\n\tv392 = v390 + 8;\n\tv394 = *([v530 @ X11_v36-8]);\n\tv536 = v394 == v319;\n\tif (v536) goto L_0086;\n\tv416 = v531 + 1;\n\tv584 = v416 < v320;\n\tv412 = ~v584;\n\tv414 = v530 + 0x10;\n\tv396 = ~v412;\n\tif (v396) goto L_FFFFFFFF;\n\tv417 = v127;\n\tv418 = 0;\n\tv419 = 0x8909C4(v417, v319, v418, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_008D;\nL_0086:\n\tv585 = *([v530 @ X11_v36]);\n\tv586 = v585 << 4;\n\tv587 = v318 + v586;\n\tv588 = v587 + 0x130;\nL_008D:\n\tv482 = System.Collections.IEnumerator::MoveNext(v215);\n\tv593 = v482 == 0;\n\tif (v593) goto L_011E;\n\tgoto L_00BC;\n\tv629 = *([v616 @ X8_v22+B0]);\n\tv630 = 0;\n\tv631 = v629 + 8;\n\tv633 = *([v669 @ X11_v31-8]);\n\tv675 = v633 == v617;\n\tif (v675) goto L_00B5;\n\tv655 = v670 + 1;\n\tv680 = v655 < v618;\n\tv651 = ~v680;\n\tv653 = v669 + 0x10;\n\tv635 = ~v651;\n\tif (v635) goto L_FFFFFFFF;\n\tv656 = v127;\n\tv657 = 0;\n\tv658 = 0x8909C4(v656, v617, v657, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00BC;\nL_00B5:\n\tv681 = *([v669 @ X11_v31]);\n\tv682 = v681 << 4;\n\tv683 = v616 + v682;\n\tv684 = v683 + 0x130;\nL_00BC:\n\tv437 = System.Collections.Generic.IEnumerator`1<Obi.IObiPathDataChannel>::get_Current(v215);\n\tv688 = *([v437 @ X0_v35 (Obi.IObiPathDataChannel)]);\n\tv691 = *([v688 @ X8_v25 (Il2CppClass<Obi.IObiPathDataChannel>)+126]) == 0;\n\tif (v691) goto L_00E2;\n\tv732 = *([v688 @ X8_v25 (Il2CppClass<Obi.IObiPathDataChannel>)+B0]) + 8;\nL_00C8:\n\t;\n\tv738 = *([v732 @ X11_v26-8]) == Obi.IObiPathDataChannel;\n\tif (v738) goto L_00E4;\n\tv733 = v733 + 1;\n\tv743 = v733 < *([v688 @ X8_v25 (Il2CppClass<Obi.IObiPathDataChannel>)+126]);\n\tv714 = ~v743;\n\tv732 = v732 + 0x10;\n\tv698 = ~v714;\n\tif (v698) goto L_00C8;\nL_00E2:\n\tv764 = 0x8909C4(v437, Obi.IObiPathDataChannel, 1, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00E9;\nL_00E4:\n\t;\n\tv745 = *([v732 @ X11_v26]) + 1;\n\tv746 = v745 << 4;\n\tv747 = v688 + v746;\n\tv764 = v747 + 0x130;\nL_00E9:\n\t;\n\t*([v764 @ X0_v36])(v769, v437, *([v764 @ X0_v36+8]), v282, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv770 = *([v437 @ X0_v35 (Obi.IObiPathDataChannel)]);\n\tv276 = v446 | v769;\n\tv312 = *([v770 @ X8_v28 (Il2CppClass<Obi.IObiPathDataChannel>)+126]) == 0;\n\tif (v312) goto L_0110;\n\tv813 = *([v770 @ X8_v28 (Il2CppClass<Obi.IObiPathDataChannel>)+B0]) + 8;\nL_00F6:\n\t;\n\tv819 = *([v813 @ X11_v21-8]) == Obi.IObiPathDataChannel;\n\tif (v819) goto L_0112;\n\tv814 = v814 + 1;\n\tv824 = v814 < *([v770 @ X8_v28 (Il2CppClass<Obi.IObiPathDataChannel>)+126]);\n\tv795 = ~v824;\n\tv813 = v813 + 0x10;\n\tv779 = ~v795;\n\tif (v779) goto L_00F6;\nL_0110:\n\tv830 = 0x8909C4(v437, Obi.IObiPathDataChannel, 2, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0117;\nL_0112:\n\t;\n\tv826 = *([v813 @ X11_v21]) + 2;\n\tv827 = v826 << 4;\n\tv828 = v770 + v827;\n\tv830 = v828 + 0x130;\nL_0117:\n\t;\n\t*([v830 @ X0_v39])(v310, v437, *([v830 @ X0_v39+8]), v282, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0066;\nL_011E:\n\tv620 = v215 == 0;\n\tv484 = ~v620;\n\tif (v484) goto L_0144;\n\tgoto L_016C;\n\tthrow System.NullReferenceException;\n\tv121 = new System.NullReferenceException();\nL_0126:\n\tv128 = new System.NullReferenceException();\n\tgoto L_0136;\n\tX22 = X23;\n\tgoto L_0136;\n\tgoto L_0136;\n\tgoto L_0136;\n\tgoto L_0136;\nL_0136:\n\tv189 = v259 != 1;\n\tif (v189) goto L_01AD;\n\tv220 = 0x6D2BC0(v128, v259, v237, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv447 = *([v220 @ X0_v19]);\n\tv317 = 0x6D2490(v220, v259, v237, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv325 = v215 == 0;\n\tif (v325) goto L_016C;\nL_0144:\n\tgoto L_016B;\n\tv541 = *([v489 @ X8_v9+B0]);\n\tv542 = 0;\n\tv543 = v541 + 8;\n\tv545 = *([v604 @ X11_v8-8]);\n\tv610 = v545 == v492;\n\tif (v610) goto L_0164;\n\tv567 = v605 + 1;\n\tv621 = v567 < v491;\n\tv563 = ~v621;\n\tv565 = v604 + 0x10;\n\tv547 = ~v563;\n\tif (v547) goto L_FFFFFFFF;\n\tv568 = v487;\n\tv569 = 0;\n\tv570 = 0x8909C4(v568, v492, v569, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_016B;\nL_0164:\n\tv622 = *([v604 @ X11_v8]);\n\tv623 = v622 << 4;\n\tv624 = v489 + v623;\n\tv625 = v624 + 0x130;\nL_016B:\n\tSystem.IDisposable::Dispose(v487);\nL_016C:\n\tv519 = v234 + 1;\n\tv250 = v519 == 0;\n\tv240 = ~v250;\n\tif (v240) goto L_017B;\n\tv571 = v232 == 0;\n\tv268 = ~v571;\n\tif (v268) goto L_01AC;\nL_017B:\n\tv576 = this.OnPathChanged == 0;\n\tv581 = ~v576;\n\tv383 = v230 & v581;\n\tv352 = v383 != 1;\n\tif (v352) goto L_01A8;\n\tthis.dirty = 0;\n\tUnityEngine.Events.UnityEvent::Invoke(this.OnPathChanged);\n\treturn;\nL_01A8:\n\treturn;\nL_01AC:\n\tv266 = new System.TypeLoadException();\nL_01AD:\n\tv273 = 0x6D2380(v128, 0, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\n// 245 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FlushEvents()
		{
			//IL_0294: Expected I4, but got O
			//IL_02d3: Expected I4, but got O
			//IL_001c: Expected I, but got O
			//IL_0471: Expected I, but got O
			//IL_0059: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0102: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_00a5: Expected O, but got I
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Expected O, but got Unknown
			//IL_01df: Expected O, but got I
			//IL_01ee: Expected O, but got I
			//IL_0182: Expected O, but got I
			bool flag = !dirty;
			bool flag2 = !flag;
			IEnumerable<IObiPathDataChannel> dataChannels = GetDataChannels();
			int num;
			int num2;
			IDisposable disposable;
			bool flag4;
			bool flag5 = default(bool);
			int num3;
			int num4;
			NullReferenceException ex;
			if (dataChannels == null)
			{
				ex = new NullReferenceException();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					goto IL_038e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num = (int)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator<IObiPathDataChannel> enumerator = default(IEnumerator<IObiPathDataChannel>);
				bool flag3 = enumerator == null;
				num2 = -1;
				disposable = enumerator;
				flag4 = flag5;
				num3 = (int)obj;
				num4 = -1;
				if (flag3)
				{
					goto IL_04e9;
				}
			}
			else
			{
				IEnumerator<IObiPathDataChannel> enumerator = dataChannels.GetEnumerator();
				int num9;
				object obj6 = default(object);
				for (flag5 = flag2; enumerator.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v830 @ X0_v39] (should have been resolved before IL gen)"), flag5 = (byte)num9 != 0)
				{
					IObiPathDataChannel current = enumerator.Current;
					IntPtr intPtr2 = (IntPtr)current;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ X8_v25 (Il2CppClass<Obi.IObiPathDataChannel>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00be;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ X8_v25 (Il2CppClass<Obi.IObiPathDataChannel>)+B0]");
					object obj2 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ X11_v26-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IObiPathDataChannel))
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ X8_v25 (Il2CppClass<Obi.IObiPathDataChannel>)+126]");
						bool flag6 = (long)num6 < 0L;
						bool flag7 = !flag6;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_00be;
					}
					object obj3 = obj2 + 1;
					int num7 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr2 + (long)num7;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					int num8 = 0;
					goto IL_045d;
					IL_00be:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num8 = 1;
					goto IL_045d;
					IL_045d:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v764 @ X0_v36] (should have been resolved before IL gen)");
					IntPtr intPtr3 = (IntPtr)current;
					num9 = (int)((long)(flag5 ? 1 : 0) | (long)(IntPtr)obj6);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ X8_v28 (Il2CppClass<Obi.IObiPathDataChannel>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ X8_v28 (Il2CppClass<Obi.IObiPathDataChannel>)+B0]");
						object obj7 = 0L + 8L;
						int num10 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v813 @ X11_v21-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiPathDataChannel))
							{
								break;
							}
							num10++;
							int num11 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ X8_v28 (Il2CppClass<Obi.IObiPathDataChannel>)+126]");
							bool flag8 = (long)num11 < 0L;
							bool flag9 = !flag8;
							obj7 = (long)(IntPtr)obj7 + 16L;
							if (!flag9)
							{
								continue;
							}
							goto IL_019b;
						}
						object obj8 = obj7 + 2;
						int num12 = (int)((long)(IntPtr)obj8 << 4);
						object obj9 = (long)intPtr3 + (long)num12;
						object obj10 = (long)(IntPtr)obj9 + 304L;
						continue;
					}
					goto IL_019b;
					IL_019b:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num8 = 2;
				}
				bool flag10 = enumerator == null;
				bool flag11 = !flag10;
				num = 0;
				num2 = 0;
				disposable = enumerator;
				if (!flag11)
				{
					flag4 = flag5;
					num3 = 0;
					num4 = 0;
					goto IL_04e9;
				}
			}
			disposable.Dispose();
			flag4 = flag5;
			num3 = num;
			num4 = num2;
			goto IL_04e9;
			IL_04e9:
			if (num4 + 1 != 0 || num3 == 0)
			{
				bool flag12 = OnPathChanged == null;
				bool flag13 = !flag12;
				bool flag14 = flag4 && flag13;
				if (flag14)
				{
					dirty = false;
					OnPathChanged.Invoke();
				}
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_038e;
			IL_038e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60004B3")]
		[Address(RVA = "0xC2D748", Offset = "0xC2D748", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1ED0230]);\n\tv21 = *([v20 @ X8_v28]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023162]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v44);\n\tthis.m_Names = v44;\n\tv52 = new Obi.ObiPointsDataChannel();\n\tObi.ObiPointsDataChannel::.ctor(v52);\n\tthis.m_Points = v52;\n\tv57 = new Obi.ObiNormalDataChannel();\n\tObi.ObiNormalDataChannel::.ctor(v57);\n\tthis.m_Normals = v57;\n\tv62 = new Obi.ObiColorDataChannel();\n\tObi.ObiColorDataChannel::.ctor(v62);\n\tthis.m_Colors = v62;\n\tv68 = new Obi.ObiThicknessDataChannel();\n\tObi.ObiThicknessDataChannel::.ctor(v68);\n\tthis.m_Thickness = v68;\n\tv74 = new Obi.ObiMassDataChannel();\n\tObi.ObiMassDataChannel::.ctor(v74);\n\tthis.m_Masses = v74;\n\tv80 = new Obi.ObiRotationalMassDataChannel();\n\tObi.ObiRotationalMassDataChannel::.ctor(v80);\n\tthis.m_RotationalMasses = v80;\n\tv86 = new Obi.ObiPhaseDataChannel();\n\tObi.ObiPhaseDataChannel::.ctor(v86);\n\tthis.m_Phases = v86;\n\tv91 = new System.Collections.Generic.List`1<System.Single>();\n\tSystem.Collections.Generic.List`1<System.Single>::.ctor(v91);\n\tthis.m_ArcLengthTable = v91;\n\tv99 = new UnityEngine.Events.UnityEvent();\n\tUnityEngine.Events.UnityEvent::.ctor(v99);\n\tthis.OnPathChanged = v99;\n\tv105 = new Obi.PathControlPointEvent();\n\tObi.PathControlPointEvent::.ctor(v105);\n\tthis.OnControlPointAdded = v105;\n\tv109 = new Obi.PathControlPointEvent();\n\tObi.PathControlPointEvent::.ctor(v109);\n\tthis.OnControlPointRemoved = v109;\n\tv113 = new Obi.PathControlPointEvent();\n\tObi.PathControlPointEvent::.ctor(v113);\n\tthis.OnControlPointRenamed = v113;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiPath()
		{
			List<string> names = new List<string>();
			m_Names = names;
			ObiPointsDataChannel obiPointsDataChannel = new ObiPointsDataChannel();
			m_Points = obiPointsDataChannel;
			ObiNormalDataChannel obiNormalDataChannel = new ObiNormalDataChannel();
			m_Normals = obiNormalDataChannel;
			ObiColorDataChannel obiColorDataChannel = new ObiColorDataChannel();
			m_Colors = obiColorDataChannel;
			ObiThicknessDataChannel thickness = new ObiThicknessDataChannel();
			m_Thickness = thickness;
			ObiMassDataChannel obiMassDataChannel = new ObiMassDataChannel();
			m_Masses = obiMassDataChannel;
			ObiRotationalMassDataChannel obiRotationalMassDataChannel = new ObiRotationalMassDataChannel();
			m_RotationalMasses = obiRotationalMassDataChannel;
			ObiPhaseDataChannel obiPhaseDataChannel = new ObiPhaseDataChannel();
			m_Phases = obiPhaseDataChannel;
			List<float> arcLengthTable = new List<float>();
			m_ArcLengthTable = arcLengthTable;
			UnityEvent onPathChanged = new UnityEvent();
			OnPathChanged = onPathChanged;
			PathControlPointEvent onControlPointAdded = new PathControlPointEvent();
			OnControlPointAdded = onControlPointAdded;
			PathControlPointEvent onControlPointRemoved = new PathControlPointEvent();
			OnControlPointRemoved = onControlPointRemoved;
			PathControlPointEvent onControlPointRenamed = new PathControlPointEvent();
			OnControlPointRenamed = onControlPointRenamed;
		}
	}
}
