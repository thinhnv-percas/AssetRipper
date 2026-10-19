using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	[Token(Token = "0x2000069")]
	public class CellView : EnhancedScrollerCellView
	{
		[CompilerGenerated]
		[Token(Token = "0x200006A")]
		private sealed class _003CLoadRemoteImage_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001B2")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001B3")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001B4")]
			[FieldOffset(Offset = "0x20")]
			public Data data;

			[Token(Token = "0x40001B5")]
			[FieldOffset(Offset = "0x28")]
			public CellView _003C_003E4__this;

			[Token(Token = "0x40001B6")]
			[FieldOffset(Offset = "0x30")]
			private string _003Cpath_003E5__2;

			[Token(Token = "0x40001B7")]
			[FieldOffset(Offset = "0x38")]
			private Texture2D _003Ctexture_003E5__3;

			[Token(Token = "0x40001B8")]
			[FieldOffset(Offset = "0x40")]
			private UnityWebRequest _003CwebRequest_003E5__4;

			[Token(Token = "0x1700002F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000215")]
				[Address(RVA = "0x402EFA0", Offset = "0x402EFA0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000030")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000217")]
				[Address(RVA = "0x402EFE8", Offset = "0x402EFE8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000212")]
			[Address(RVA = "0x402EC78", Offset = "0x402EC78", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CLoadRemoteImage_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000213")]
			[Address(RVA = "0x402ECE4", Offset = "0x402ECE4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000214")]
			[Address(RVA = "0x402ECE8", Offset = "0x402ECE8", Length = "0x2B8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv57 = this.<>1__state != 1;\n\tif (v57) goto L_0091;\n\tv64 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv226 = UnityEngine.Networking.UnityWebRequest::get_result(this.<webRequest>5__4);\n\tv161 = v226 != 1;\n\tif (v161) goto L_00A3;\n\tv198 = UnityEngine.Networking.UnityWebRequest::get_downloadHandler(this.<webRequest>5__4);\n\tv324 = *([v198 @ X0_v47 (UnityEngine.Networking.DownloadHandler)]) != UnityEngine.Networking.DownloadHandlerTexture;\n\tif (v324) goto L_0103;\n\tv370 = UnityEngine.Networking.DownloadHandlerTexture::get_texture(v198);\n\tthis.<texture>5__3 = v370;\n\tv409 = this.<texture>5__3;\n\tgoto L_00C4;\nL_0069:\n\tthis.<>1__state = -1;\n\tv59 = this.data;\n\tthis.<path>5__2 = v59.imageUrl;\n\tthis.<texture>5__3 = 0;\n\tv340 = UnityEngine.Networking.UnityWebRequestTexture::GetTexture(this.<path>5__2);\n\tthis.<webRequest>5__4 = v340;\n\tv358 = UnityEngine.Networking.UnityWebRequest::SendWebRequest(this.<webRequest>5__4);\n\tthis.<>2__current = v358;\n\tthis.<>1__state = 1;\nL_00A3:\n\tv346 = UnityEngine.Networking.UnityWebRequest::get_error(this.<webRequest>5__4);\n\tv374 = System.String::Concat(\"Failed to download image [\", this.<path>5__2, \"]: \", v346);\n\tgoto L_00BA;\nL_00C4:\n\tv415 = UnityEngine.Object::op_Inequality(v409, 0);\n\tv437 = ~v415;\n\tif (v437) goto L_00EA;\n\tv216 = this.data;\n\t// 214 MakeStruct v124 @ AGG402EF34_1_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v216.imageDimensions (UnityEngine.Vector2), v216.imageDimensions.y (System.Single)\n\t// 215 MakeStruct v121 @ AGG402EF34_2_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 0\n\tv201 = UnityEngine.Sprite::Create(this.<texture>5__3, v124, v121, v216.imageDimensions);\n\tv271 = v201;\n\tv458 = v64.cellImage;\n\tgoto L_00EF;\nL_00EA:\n\tv458 = v64.cellImage;\n\tv271 = v64.defaultSprite;\nL_0103:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\nL_0021:\n\tv44 = this.<>1__state == 0;\n\tif (v44) goto L_0069;\nL_0091:\n\tv102 = this.<>1__state == 0;\n\treturn v102;\nL_00BA:\n\tUnityEngine.Debug::LogError(v374);\n\tv409 = this.<texture>5__3;\n\tgoto L_00C4;\nL_00EF:\n\tUnityEngine.UI.Image::set_sprite(v458, v271);\n\tv292 = this.<>1__state == 0;\n\treturn v292;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CellView._003CLoadRemoteImage_003Ed__4::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000216")]
			[Address(RVA = "0x402EFA8", Offset = "0x402EFA8", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0x38")]
		public Image cellImage;

		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0x40")]
		public Sprite defaultSprite;

		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0x48")]
		private Coroutine _loadImageCoroutine;

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x402EB48", Offset = "0x402EB48", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.data = data;\n\tv60 = UnityEngine.MonoBehaviour::StartCoroutine(this, v46);\n\tthis._loadImageCoroutine = v60;\n\treturn;\nL_0018:\n\tv46 = new EnhancedScrollerDemos.RemoteResourcesDemo.CellView+<LoadRemoteImage>d__4();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.<>4__this = this;\n")]
		public void SetData(Data data)
		{
			_003CLoadRemoteImage_003Ed__4 _003CLoadRemoteImage_003Ed__5 = (_003CLoadRemoteImage_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CLoadRemoteImage_003Ed__4));
			_003CLoadRemoteImage_003Ed__5._003C_003E1__state = 0;
			_003CLoadRemoteImage_003Ed__5._003C_003E4__this = this;
			_003CLoadRemoteImage_003Ed__5.data = data;
			Coroutine loadImageCoroutine = StartCoroutine(_003CLoadRemoteImage_003Ed__5);
			_loadImageCoroutine = loadImageCoroutine;
		}

		[IteratorStateMachine(typeof(_003CLoadRemoteImage_003Ed__4))]
		[Token(Token = "0x600020E")]
		[Address(RVA = "0x402EBEC", Offset = "0x402EBEC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.data = data;\n\treturn v46;\nL_0018:\n\tv46 = new EnhancedScrollerDemos.RemoteResourcesDemo.CellView+<LoadRemoteImage>d__4();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.<>4__this = this;\n")]
		public IEnumerator LoadRemoteImage(Data data)
		{
			_003CLoadRemoteImage_003Ed__4 _003CLoadRemoteImage_003Ed__5 = (_003CLoadRemoteImage_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CLoadRemoteImage_003Ed__4));
			_003CLoadRemoteImage_003Ed__5._003C_003E1__state = 0;
			_003CLoadRemoteImage_003Ed__5._003C_003E4__this = this;
			_003CLoadRemoteImage_003Ed__5.data = data;
			return _003CLoadRemoteImage_003Ed__5;
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0x402ECA4", Offset = "0x402ECA4", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Image::set_sprite(this.cellImage, this.defaultSprite);\n\treturn;\n")]
		public void ClearImage()
		{
			cellImage.sprite = defaultSprite;
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0x402ECC8", Offset = "0x402ECC8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._loadImageCoroutine == 0;\n\tif (v2) goto L_0006;\n\tUnityEngine.MonoBehaviour::StopCoroutine(this, this._loadImageCoroutine);\n\treturn;\nL_0006:\n\treturn;\n")]
		public void WillRecycle()
		{
			if (_loadImageCoroutine != null)
			{
				StopCoroutine(_loadImageCoroutine);
			}
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0x402ECDC", Offset = "0x402ECDC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScrollerCellView::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
