using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x200002E")]
	public class ScreenshotProcess : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200002F")]
		private sealed class _003CProcessCoroutine_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000119")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400011A")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400011B")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotProcess _003C_003E4__this;

			[Token(Token = "0x17000013")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000CA")]
				[Address(RVA = "0x3C3A63C", Offset = "0x3C3A63C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000014")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000CC")]
				[Address(RVA = "0x3C3A684", Offset = "0x3C3A684", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0x3C3A554", Offset = "0x3C3A554", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CProcessCoroutine_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000C8")]
			[Address(RVA = "0x3C3A58C", Offset = "0x3C3A58C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000C9")]
			[Address(RVA = "0x3C3A590", Offset = "0x3C3A590", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv53 = this.<>1__state != 1;\n\tif (v53) goto L_003B;\n\tv86 = -1;\n\tgoto L_0036;\nL_0026:\n\tthis.<>1__state = -1;\n\tv108 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v108);\n\tthis.<>2__current = v108;\n\tv86 = 1;\nL_0015:\n\tv43 = this.<>1__state == 0;\n\tif (v43) goto L_0026;\nL_003B:\n\tv93 = this.<>1__state == 0;\n\treturn v93;\nL_0036:\n\tthis.<>1__state = v86;\n")]
			private bool MoveNext()
			{
				int num;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_008b;
					}
					num = -1;
				}
				else
				{
					_003C_003E1__state = -1;
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					num = 1;
				}
				_003C_003E1__state = num;
				goto IL_008b;
				IL_008b:
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000CB")]
			[Address(RVA = "0x3C3A644", Offset = "0x3C3A644", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[HideInInspector]
		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x20")]
		public ScreenshotBatch m_Batch;

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x3C3A4D8", Offset = "0x3C3A4D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Process(ScreenshotResolution res)
		{
		}

		[IteratorStateMachine(typeof(_003CProcessCoroutine_003Ed__2))]
		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x3C3A4DC", Offset = "0x3C3A4DC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.ScreenshotProcess+<ProcessCoroutine>d__2();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public virtual IEnumerator ProcessCoroutine(ScreenshotResolution res)
		{
			_003CProcessCoroutine_003Ed__2 _003CProcessCoroutine_003Ed__3 = (_003CProcessCoroutine_003Ed__2)FormatterServices.GetUninitializedObject(typeof(_003CProcessCoroutine_003Ed__2));
			_003CProcessCoroutine_003Ed__3._003C_003E1__state = 0;
			_003CProcessCoroutine_003Ed__3._003C_003E4__this = this;
			return _003CProcessCoroutine_003Ed__3;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x3C3A580", Offset = "0x3C3A580", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected void ForceGameViewRepaint()
		{
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x3C3A584", Offset = "0x3C3A584", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ScreenshotProcess()
		{
		}
	}
}
