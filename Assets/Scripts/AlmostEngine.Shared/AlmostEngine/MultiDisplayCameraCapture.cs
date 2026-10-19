using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Debug = UnityEngine.Debug;

namespace AlmostEngine
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[Token(Token = "0x2000006")]
	public class MultiDisplayCameraCapture : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000007")]
		private sealed class _003CAsyncReadCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400000E")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400000F")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000010")]
			[FieldOffset(Offset = "0x20")]
			public MultiDisplayCameraCapture _003C_003E4__this;

			[Token(Token = "0x4000011")]
			[FieldOffset(Offset = "0x28")]
			private AsyncGPUReadbackRequest _003Crequest_003E5__2;

			[Token(Token = "0x17000001")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000012")]
				[Address(RVA = "0x3C456FC", Offset = "0x3C456FC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000002")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000014")]
				[Address(RVA = "0x3C45744", Offset = "0x3C45744", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x3C453B0", Offset = "0x3C453B0", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CAsyncReadCoroutine_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x3C45478", Offset = "0x3C45478", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000011")]
			[Address(RVA = "0x3C4547C", Offset = "0x3C4547C", Length = "0x280")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv59 = this.<>1__state == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0088;\n\tthis.<>1__state = -1;\n\tv192 = UnityEngine.Texture2D::get_format(v46.m_TargetTexture);\n\tv201 = UnityEngine.Rendering.AsyncGPUReadback::Request(v46.m_TempRenderTexture, 0, v192, 0);\n\tthis.<request>5__2.m_Ptr = v201;\n\tthis.<request>5__2.m_Version = 0;\n\tv173 = UnityEngine.Rendering.AsyncGPUReadbackRequest::get_done(&this.<request>5__2 (UnityEngine.Rendering.AsyncGPUReadbackRequest));\n\tv222 = ~v173;\n\tv175 = ~v222;\n\tif (v175) goto L_0069;\nL_004F:\n\tv187 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v187);\n\tthis.<>2__current = v187;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_0063:\n\tthis.<>1__state = -1;\n\tv64 = UnityEngine.Rendering.AsyncGPUReadbackRequest::get_done(&this.<request>5__2 (UnityEngine.Rendering.AsyncGPUReadbackRequest));\n\tv77 = ~v64;\n\tif (v77) goto L_004F;\nL_0069:\n\t;\n\tv180 = UnityEngine.Rendering.AsyncGPUReadbackRequest::get_hasError(&this.<request>5__2 (UnityEngine.Rendering.AsyncGPUReadbackRequest));\n\tv194 = v180 == 0;\n\tif (v194) goto L_008C;\n\tgoto L_007B;\nL_007B:\n\tUnityEngine.Debug::LogError(\"Error with async read request\");\n\tv223 = v46 == 0;\n\tv113 = ~v223;\n\tif (v113) goto L_00AC;\n\tgoto L_00D0;\nL_0088:\n\treturn 0;\nL_008C:\n\t;\n\tv212 = UnityEngine.Rendering.AsyncGPUReadbackRequest::GetData(&this.<request>5__2 (UnityEngine.Rendering.AsyncGPUReadbackRequest), 0);\n\tv90 = v212;\n\tv108 = Unity.Collections.NativeArray`1<System.Byte>::ToArray(&v90 @ stack_-40_v4 (Unity.Collections.NativeArray`1<System.Byte>));\n\tUnityEngine.Texture2D::LoadRawTextureData(v46.m_TargetTexture, v108);\n\tUnityEngine.Texture2D::Apply(v46.m_TargetTexture, 0);\nL_00AC:\n\tgoto L_00AF;\nL_00AF:\n\tv238 = UnityEngine.Object::op_Inequality(v46.m_TempRenderTexture, 0);\n\tv242 = ~v238;\n\tv243 = ~v242;\n\tif (v243) goto L_00C1;\n\tgoto L_00C7;\nL_00C1:\n\tUnityEngine.RenderTexture::Release(v46.m_TempRenderTexture);\n\tv46.m_TempRenderTexture = 0;\nL_00C7:\n\tv46.m_WaitForRendering = 0;\n\treturn 0;\nL_00D0:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0026:\n\tv46 = this.<>4__this;\n\tv51 = this.<>1__state == 1;\n\tif (v51) goto L_0063;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MultiDisplayCameraCapture._003CAsyncReadCoroutine_003Ed__9::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x3C45704", Offset = "0x3C45704", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400000A")]
		public static List<MultiDisplayCameraCapture> m_MultiDisplayCamera;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x20")]
		public Texture2D m_TargetTexture;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x28")]
		public bool m_WaitForRendering;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x30")]
		private RenderTexture m_TempRenderTexture;

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x3C44EA0", Offset = "0x3C44EA0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\t;\n\tv51 = v49.m_MultiDisplayCamera == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0031;\n\tgoto L_005F;\nL_0031:\n\t;\n\tgoto L_005D;\nL_005D:\n\tSystem.Collections.Generic.List`1<AlmostEngine.MultiDisplayCameraCapture>::Add(v49.m_MultiDisplayCamera, this);\n\treturn;\nL_005F:\n\tthrow System.NullReferenceException;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (m_MultiDisplayCamera != null)
			{
				m_MultiDisplayCamera.Add(this);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x3C44F9C", Offset = "0x3C44F9C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tv75 = System.Collections.Generic.List`1<AlmostEngine.MultiDisplayCameraCapture>::Remove(v49.m_MultiDisplayCamera, this);\n\treturn;\n")]
		private void OnDisable()
		{
			bool flag = m_MultiDisplayCamera.Remove(this);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x3C45040", Offset = "0x3C45040", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_TargetTexture = targetTexture;\n\tthis.m_WaitForRendering = 1;\n\treturn;\n")]
		public void WaitRenderingAndCopyCameraToTexture(Texture2D targetTexture)
		{
			m_TargetTexture = targetTexture;
			m_WaitForRendering = true;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x3C45070", Offset = "0x3C45070", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_WaitForRendering == 0;\n\treturn v6;\n")]
		public bool CopyIsOver()
		{
			return !m_WaitForRendering;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x3C45080", Offset = "0x3C45080", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0029:\n\tUnityEngine.Graphics::Blit(src, dest);\n\tv75 = this.m_WaitForRendering != 1;\n\tif (v75) goto L_004D;\n\tgoto L_0040;\nL_0040:\n\tv92 = UnityEngine.Object::op_Inequality(this.m_TargetTexture, 0);\n\tv188 = ~v92;\n\tv96 = ~v188;\n\tif (v96) goto L_005C;\nL_004D:\n\treturn;\nL_005C:\n\tgoto L_0061;\nL_0061:\n\tv94 = UnityEngine.Object::op_Equality(this.m_TempRenderTexture, 0);\n\tv98 = ~v94;\n\tif (v98) goto L_004D;\n\tgoto L_006B;\nL_006B:\n\tv207 = UnityEngine.Application::get_isPlaying();\n\tv210 = v207 == 0;\n\tif (v210) goto L_00C9;\n\tv227 = UnityEngine.RenderTexture::get_width(src);\n\tv232 = UnityEngine.RenderTexture::get_height(src);\n\tv236 = UnityEngine.RenderTexture::get_format(src);\n\tv251 = UnityEngine.RenderTexture::GetTemporary(v227, v232, 0, v236);\n\tthis.m_TempRenderTexture = v251;\n\tgoto L_0094;\nL_0094:\n\tUnityEngine.Graphics::Blit(src, this.m_TempRenderTexture);\n\tgoto L_00A3;\n\tv157 = UnityEngine.MonoBehaviour::StartCoroutine(this, v280);\n\treturn;\nL_00C9:\n\tv247 = UnityEngine.Texture::get_width(this.m_TargetTexture);\n\tv253 = UnityEngine.Texture::get_height(this.m_TargetTexture);\n\t// 218 MakeStruct v117 @ AGG3C45304_1_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v247 @ X0_v17 (System.Int32), v253 @ X0_v19 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(this.m_TargetTexture, v117, 0, 0);\n\tUnityEngine.Texture2D::Apply(this.m_TargetTexture, 0);\n\tthis.m_WaitForRendering = 0;\n\treturn;\nL_0024:\n\tgoto L_0029;\nL_00A3:\n\tv280 = new AlmostEngine.MultiDisplayCameraCapture+<AsyncReadCoroutine>d__9();\n\tSystem.Object::.ctor(v280);\n\tv280.<>1__state = 0;\n\tv280.<>4__this = this;\n")]
		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			Graphics.Blit(src, dest);
			if (m_WaitForRendering && m_TargetTexture != null && m_TempRenderTexture == null)
			{
				if (Application.isPlaying)
				{
					int width = src.width;
					int height = src.height;
					RenderTextureFormat format = src.format;
					RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, format);
					m_TempRenderTexture = temporary;
					Graphics.Blit(src, m_TempRenderTexture);
					_003CAsyncReadCoroutine_003Ed__9 _003CAsyncReadCoroutine_003Ed__10 = (_003CAsyncReadCoroutine_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CAsyncReadCoroutine_003Ed__9));
					_003CAsyncReadCoroutine_003Ed__10._003C_003E1__state = 0;
					_003CAsyncReadCoroutine_003Ed__10._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(_003CAsyncReadCoroutine_003Ed__10);
				}
				else
				{
					int width2 = m_TargetTexture.width;
					int height2 = m_TargetTexture.height;
					Rect source = default(Rect);
					source.x = 0f;
					source.y = 0f;
					source.width = width2;
					source.height = height2;
					m_TargetTexture.ReadPixels(source, 0, 0);
					m_TargetTexture.Apply(updateMipmaps: false);
					m_WaitForRendering = false;
				}
			}
		}

		[IteratorStateMachine(typeof(_003CAsyncReadCoroutine_003Ed__9))]
		[Token(Token = "0x600000C")]
		[Address(RVA = "0x3C45338", Offset = "0x3C45338", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.MultiDisplayCameraCapture+<AsyncReadCoroutine>d__9();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator AsyncReadCoroutine()
		{
			_003CAsyncReadCoroutine_003Ed__9 _003CAsyncReadCoroutine_003Ed__10 = (_003CAsyncReadCoroutine_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CAsyncReadCoroutine_003Ed__9));
			_003CAsyncReadCoroutine_003Ed__10._003C_003E1__state = 0;
			_003CAsyncReadCoroutine_003Ed__10._003C_003E4__this = this;
			return _003CAsyncReadCoroutine_003Ed__10;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x3C453DC", Offset = "0x3C453DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MultiDisplayCameraCapture()
		{
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x3C453E4", Offset = "0x3C453E4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.List`1<AlmostEngine.MultiDisplayCameraCapture>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.MultiDisplayCameraCapture>::.ctor(v49);\n\tv58.m_MultiDisplayCamera = v49;\n")]
		static MultiDisplayCameraCapture()
		{
			List<MultiDisplayCameraCapture> multiDisplayCamera = new List<MultiDisplayCameraCapture>();
			m_MultiDisplayCamera = multiDisplayCamera;
		}
	}
}
