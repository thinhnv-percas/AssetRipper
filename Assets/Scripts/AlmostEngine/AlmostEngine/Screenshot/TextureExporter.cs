using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;
using Debug = UnityEngine.Debug;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x200004A")]
	public class TextureExporter
	{
		[Token(Token = "0x200004B")]
		public enum ImageFileFormat
		{
			[Token(Token = "0x40001D8")]
			PNG = 0,
			[Token(Token = "0x40001D9")]
			JPG = 1,
			[Token(Token = "0x40001DA")]
			TGA = 2
		}

		[Serializable]
		[Token(Token = "0x200004C")]
		public class ImageFile
		{
			[Token(Token = "0x40001DB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public Texture2D m_Texture;

			[Token(Token = "0x40001DC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string m_Name;

			[Token(Token = "0x40001DD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string m_Fullname;

			[Token(Token = "0x40001DE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public DateTime m_CreationDate;

			[Token(Token = "0x6000173")]
			[Address(RVA = "0x3C42E84", Offset = "0x3C42E84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public ImageFile()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200004D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40001DF")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40001E0")]
			public static UnityAction _003C_003E9__1_0;

			[Token(Token = "0x40001E1")]
			public static UnityAction _003C_003E9__1_1;

			[Token(Token = "0x6000174")]
			[Address(RVA = "0x3C42E94", Offset = "0x3C42E94", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new AlmostEngine.Screenshot.TextureExporter+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000175")]
			[Address(RVA = "0x3C42EF8", Offset = "0x3C42EF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CExportToFile_003Eb__1_0()
			{
			}

			internal void _003CExportToFile_003Eb__1_1()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200004E")]
		private sealed class _003C_003Ec__DisplayClass3_0
		{
			[Token(Token = "0x40001E2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string fullpath;

			[Token(Token = "0x40001E3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public byte[] textureRawDataClone;

			[Token(Token = "0x40001E4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public GraphicsFormat format;

			[Token(Token = "0x40001E5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			public int width;

			[Token(Token = "0x40001E6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public int height;

			[Token(Token = "0x40001E7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public ImageFileFormat imageFormat;

			[Token(Token = "0x40001E8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public int JPGQuality;

			[Token(Token = "0x6000178")]
			[Address(RVA = "0x3C42F08", Offset = "0x3C42F08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass3_0()
			{
			}

			internal bool _003CEncodeAndExportToFileAsync_003Eb__0()
			{
				Thread currentThread = Thread.CurrentThread;
				int managedThreadId = currentThread.ManagedThreadId;
				int num = managedThreadId;
				string text = num.ToString();
				string message = "Starting fully threaded texture file export " + fullpath + " current thread ID : " + text;
				Debug.Log(message);
				byte[] encodedBytes = EncodeRawTextureToBytes(textureRawDataClone, format, width, height, imageFormat, JPGQuality);
				return WriteBytesToFile(encodedBytes, fullpath, (ImageFileFormat)width, height);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200004F")]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x40001E9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string fullpath;

			[Token(Token = "0x40001EA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public byte[] encodedBytes;

			[Token(Token = "0x40001EB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public ImageFileFormat imageFormat;

			[Token(Token = "0x40001EC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			public int JPGQuality;

			[Token(Token = "0x600017A")]
			[Address(RVA = "0x3C43018", Offset = "0x3C43018", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass4_0()
			{
			}

			internal bool _003CExportToFileWriteAsync_003Eb__0()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TextureExporter._003C_003Ec__DisplayClass4_0::_003CExportToFileWriteAsync_003Eb__0");
				return default;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000050")]
		private struct _003CEncodeAndExportToFileAsync_003Ed__3 : IAsyncStateMachine
		{
			[Token(Token = "0x40001ED")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x40001EE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x40001EF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string fullpath;

			[Token(Token = "0x40001F0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public ImageFileFormat imageFormat;

			[Token(Token = "0x40001F1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public int JPGQuality;

			[Token(Token = "0x40001F2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public Texture2D texture;

			[Token(Token = "0x40001F3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public UnityAction onExportFailure;

			[Token(Token = "0x40001F4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public bool addToGallery;

			[Token(Token = "0x40001F5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

			[Token(Token = "0x40001F6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public UnityAction onExportSuccess;

			[Token(Token = "0x40001F7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private TaskAwaiter<bool> _003C_003Eu__1;

			[Token(Token = "0x600017C")]
			[Address(RVA = "0x3C43114", Offset = "0x3C43114", Length = "0x554")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv58 = new AlmostEngine.Screenshot.TextureExporter+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v58);\n\tthis.<>8__1 = v58;\n\tv108 = this.<>8__1;\n\tv109 = this.<>8__1 == 0;\n\tif (v109) goto L_0128;\n\tv108.fullpath = this.fullpath;\n\tv147 = this.<>8__1;\n\tv148 = this.<>8__1 == 0;\n\tif (v148) goto L_012A;\n\tv147.imageFormat = this.imageFormat;\n\tv190 = this.texture == 0;\n\tif (v190) goto L_012C;\n\tv278 = UnityEngine.Texture2D::GetRawTextureData(this.texture);\n\tv215 = this.<>8__1;\n\tv290 = System.Linq.Enumerable::ToArray(v278);\n\tv232 = this.<>8__1 == 0;\n\tif (v232) goto L_012E;\n\tv215.textureRawDataClone = v290;\n\tv233 = this.texture == 0;\n\tif (v233) goto L_0130;\n\tv217 = this.<>8__1;\n\tv354 = UnityEngine.Texture::get_graphicsFormat(this.texture);\n\tv234 = this.<>8__1 == 0;\n\tif (v234) goto L_0132;\n\tv217.format = v354;\n\tv235 = this.texture == 0;\n\tif (v235) goto L_0134;\n\tv218 = this.<>8__1;\n\tv356 = UnityEngine.Texture::get_width(this.texture);\n\tv236 = this.<>8__1 == 0;\n\tif (v236) goto L_0136;\n\tv218.width = v356;\n\tv237 = this.texture == 0;\n\tif (v237) goto L_0138;\n\tv219 = this.<>8__1;\n\tv358 = UnityEngine.Texture::get_height(this.texture);\n\tv238 = this.<>8__1 == 0;\n\tif (v238) goto L_013A;\n\tv219.height = v358;\n\tv362 = new System.Func`1<System.Boolean>();\n\tSystem.Func`1<System.Boolean>::.ctor(v362, this.<>8__1, Il2CppMethodInfo);\n\tgoto L_00A0;\nL_00A0:\n\tv376 = System.Threading.Tasks.Task::Run(v362);\n\tv239 = v376 == 0;\n\tif (v239) goto L_013C;\n\tv380 = System.Threading.Tasks.Task`1<System.Boolean>::GetAwaiter(v376);\n\tv83 = System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>::get_IsCompleted(&v67 @ stack_-48_v2 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>));\n\tv385 = v83 == 0;\n\tv85 = ~v385;\n\tif (v85) goto L_00D8;\n\tthis.<>1__state = 0;\n\tthis.<>u__1 = v67;\n\tgoto L_00C1;\nL_00C1:\n\t;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::AwaitUnsafeOnCompleted(&this.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), &v67 @ stack_-48_v2 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>), this);\n\treturn;\nL_00D1:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = -1;\nL_FFFFFFFF:\n\tv67 = this.<>u__1;\n\tv120 = this.addToGallery != 1;\n\tif (v120) goto L_00F0;\n\tv130 = this.<>8__1;\n\tv131 = this.<>8__1 == 0;\n\tif (v131) goto L_0142;\n\tv133 = AlmostEngine.Screenshot.GalleryUtils::AddToGallery(v130.fullpath);\n\tv135 = v133 == 0;\n\tif (v135) goto L_0120;\nL_00F0:\n\t;\n\tv138 = this.onExportSuccess == 0;\n\tif (v138) goto L_0140;\n\tUnityEngine.Events.UnityAction::Invoke(this.onExportSuccess);\nL_FFFFFFFF:\n\tv264 = 1;\n\tgoto L_0105;\nL_00F9:\n\t;\n\tv122 = this.onExportFailure == 0;\n\tif (v122) goto L_013E;\n\tUnityEngine.Events.UnityAction::Invoke(this.onExportFailure);\nL_0115:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::SetResult(&this.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), v264);\n\treturn;\nL_0120:\n\t;\n\tv182 = this.onExportFailure == 0;\n\tif (v182) goto L_0144;\n\tUnityEngine.Events.UnityAction::Invoke(this.onExportFailure);\n\tgoto L_FFFFFFFF;\nL_0128:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_012A:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_012C:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_012E:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0130:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0132:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0134:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0136:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0138:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_013A:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_013C:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_013E:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0140:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0142:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_0144:\n\tv220 = new System.NullReferenceException();\n\tgoto L_019E;\nL_019E:\n\t// 414 Interrupt\n\tv248 = 0x8BF5BF4(v220, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv280 = 0x8BF0368(v220, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv291 = 0xA1B8(v280, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_003B:\n\tv51 = this.<>1__state == 0;\n\tif (v51) goto L_00D1;\nL_00D8:\n\tv94 = System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>::GetResult(&v67 @ stack_-48_v2 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>));\n\tv104 = v94 == 0;\n\tif (v104) goto L_00F9;\nL_0105:\n\tthis.<>1__state = -2;\n\tthis.<>8__1 = 0;\n\tgoto L_0115;\nL_FFFFFFFF:\n\tv264 = 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TextureExporter._003CEncodeAndExportToFileAsync_003Ed__3::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600017D")]
			[Address(RVA = "0x3C43668", Offset = "0x3C43668", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0023:\n\t;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::SetStateMachine(&this.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), stateMachine);\n\treturn;\nL_0020:\n\tgoto L_0023;\n")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000051")]
		private struct _003CExportToFileWriteAsync_003Ed__4 : IAsyncStateMachine
		{
			[Token(Token = "0x40001F8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x40001F9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			[Token(Token = "0x40001FA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string fullpath;

			[Token(Token = "0x40001FB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public ImageFileFormat imageFormat;

			[Token(Token = "0x40001FC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public int JPGQuality;

			[Token(Token = "0x40001FD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public Texture2D texture;

			[Token(Token = "0x40001FE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public UnityAction onExportFailure;

			[Token(Token = "0x40001FF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public bool addToGallery;

			[Token(Token = "0x4000200")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

			[Token(Token = "0x4000201")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public UnityAction onExportSuccess;

			[Token(Token = "0x4000202")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private TaskAwaiter<bool> _003C_003Eu__1;

			[Token(Token = "0x600017E")]
			[Address(RVA = "0x3C436E8", Offset = "0x3C436E8", Length = "0x4A8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv58 = new AlmostEngine.Screenshot.TextureExporter+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v58);\n\tthis.<>8__1 = v58;\n\tv103 = this.<>8__1;\n\tv104 = this.<>8__1 == 0;\n\tif (v104) goto L_0109;\n\tv103.fullpath = this.fullpath;\n\tv142 = this.<>8__1;\n\tv143 = this.<>8__1 == 0;\n\tif (v143) goto L_010B;\n\tv142.imageFormat = this.imageFormat;\n\tv142.JPGQuality = this.JPGQuality;\n\tv197 = AlmostEngine.Screenshot.TextureExporter::EncodeTextureToBytes(this.texture, this.imageFormat, this.JPGQuality);\n\tv142.encodedBytes = v197;\n\tv76 = this.<>8__1;\n\tv221 = this.<>8__1 == 0;\n\tif (v221) goto L_010D;\n\tv282 = v76.encodedBytes == 0;\n\tif (v282) goto L_00DA;\n\tv294 = new System.Func`1<System.Boolean>();\n\tSystem.Func`1<System.Boolean>::.ctor(v294, this.<>8__1, Il2CppMethodInfo);\n\tgoto L_0079;\nL_0079:\n\tv349 = System.Threading.Tasks.Task::Run(v294);\n\tv222 = v349 == 0;\n\tif (v222) goto L_010F;\n\tv353 = System.Threading.Tasks.Task`1<System.Boolean>::GetAwaiter(v349);\n\tv78 = System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>::get_IsCompleted(&v67 @ stack_-48_v4 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>));\n\tv358 = v78 == 0;\n\tv80 = ~v358;\n\tif (v80) goto L_00B1;\n\tthis.<>1__state = 0;\n\tthis.<>u__1 = v67;\n\tgoto L_009A;\nL_009A:\n\t;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::AwaitUnsafeOnCompleted(&this.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), &v67 @ stack_-48_v4 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>), this);\n\treturn;\nL_00AA:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = -1;\nL_FFFFFFFF:\n\tv67 = this.<>u__1;\n\tv115 = this.addToGallery != 1;\n\tif (v115) goto L_00C9;\n\tv125 = this.<>8__1;\n\tv126 = this.<>8__1 == 0;\n\tif (v126) goto L_0117;\n\tv128 = AlmostEngine.Screenshot.GalleryUtils::AddToGallery(v125.fullpath);\n\tv130 = v128 == 0;\n\tif (v130) goto L_00E2;\nL_00C9:\n\t;\n\tv133 = this.onExportSuccess == 0;\n\tif (v133) goto L_0115;\n\tUnityEngine.Events.UnityAction::Invoke(this.onExportSuccess);\nL_FFFFFFFF:\n\tv247 = 1;\n\tgoto L_00EE;\nL_00D2:\n\t;\n\tv117 = this.onExportFailure == 0;\n\tif (v117) goto L_0111;\n\tUnityEngine.Events.UnityAction::Invoke(this.onExportFailure);\n\tgoto L_FFFFFFFF;\nL_00DA:\n\t;\n\tv186 = this.onExportFailure == 0;\n\tif (v186) goto L_0113;\n\tUnityEngine.Events.UnityAction::Invoke(this.onExportFailure);\n\tgoto L_FFFFFFFF;\nL_00E2:\n\t;\n\tv185 = this.onExportFailure == 0;\n\tif (v185) goto L_0119;\n\tUnityEngine.Events.UnityAction::Invoke(this.onExportFailure);\nL_00FE:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::SetResult(&this.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), v247);\n\treturn;\nL_0109:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_010B:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_010D:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_010F:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_0111:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_0113:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_0115:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_0117:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_0119:\n\tv215 = new System.NullReferenceException();\n\tgoto L_016D;\nL_016D:\n\t// 365 Interrupt\n\tv227 = 0x8BF5BF4(v215, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv264 = 0x8BF0368(v215, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv272 = 0xA1B8(v264, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0038:\n\tv51 = this.<>1__state == 0;\n\tif (v51) goto L_00AA;\nL_00B1:\n\tv89 = System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>::GetResult(&v67 @ stack_-48_v4 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>));\n\tv99 = v89 == 0;\n\tif (v99) goto L_00D2;\nL_00EE:\n\tthis.<>1__state = -2;\n\tthis.<>8__1 = 0;\n\tgoto L_00FE;\nL_FFFFFFFF:\n\tv247 = 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TextureExporter._003CExportToFileWriteAsync_003Ed__4::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600017F")]
			[Address(RVA = "0x3C43B90", Offset = "0x3C43B90", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0023:\n\t;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::SetStateMachine(&this.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), stateMachine);\n\treturn;\nL_0020:\n\tgoto L_0023;\n")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0x3C33A9C", Offset = "0x3C33A9C", Length = "0x31C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tgoto L_0040;\nL_0040:\n\tv113 = v79.<>9__1_0;\n\tv76 = v79.<>9__1_0 == 0;\n\tif (v76) goto L_005F;\nL_0044:\n\tv101 = 0xB292000 + 0x5A0;\n\tv86 = onExportFailure == 0;\n\tv87 = ~v86;\n\tv111 = addToGallery;\n\tv131 = v101;\n\tv144 = addToGallery;\n\tv146 = v113;\n\tv147 = onExportFailure;\n\tif (v87) goto L_009E;\nL_004D:\n\tgoto L_004F;\nL_004F:\n\tv147 = v141.<>9__1_1;\n\tv164 = v141.<>9__1_1 == 0;\n\tv137 = ~v164;\n\tv131 = v101;\n\tv144 = v111;\n\tv146 = v113;\n\tif (v137) goto L_009E;\n\tgoto L_0087;\nL_005F:\n\tgoto L_0067;\n\tv131 = 0xB292000 + 0x5A0;\n\tv269 = onExportFailure == 0;\n\tv106 = ~v269;\n\tv144 = addToGallery;\n\tv146 = v182;\n\tv147 = onExportFailure;\n\tif (v106) goto L_009E;\n\tv101 = v131;\n\tv111 = addToGallery;\n\tv113 = v182;\n\tgoto L_004D;\nL_0087:\n\tgoto L_008F;\n\tv131 = v101;\n\tv144 = v111;\n\tv146 = v113;\n\tv147 = v241;\n\tv169 = UnityEngine.Object::op_Equality(texture, 0);\n\tv184 = ~v169;\n\tif (v184) goto L_00D3;\nL_00B2:\n\tv277 = System.String::Concat(\"Can not export the texture to file \", fullpath, \", texture is empty.\");\n\tgoto L_00BD;\n\tUnityEngine.Events.UnityAction::Invoke(v147);\n\treturnVal2 = 0;\n\tgoto L_00E6;\nL_00CA:\n\tv188 = UnityEngine.Object::op_Equality(texture, 0);\n\tv227 = ~v188;\n\tv205 = ~v227;\n\tif (v205) goto L_00B2;\nL_00D3:\n\tv226 = ~async;\n\tif (v226) goto L_00F7;\n\tv248 = AlmostEngine.Screenshot.TextureExporter::EncodeAndExportToFileAsync(texture, fullpath, imageFormat, JPGQuality, v144, v146, v147);\n\treturnVal2 = 1;\nL_00F7:\n\treturnVal1 = AlmostEngine.Screenshot.TextureExporter::ExportToFileNoAsync(texture, fullpath, imageFormat, JPGQuality, v144, 0, v146, v147);\n\treturn returnVal1;\nL_0036:\n\tv62 = onExportSuccess == 0;\n\tv63 = ~v62;\n\tv113 = onExportSuccess;\n\tif (v63) goto L_0044;\nL_009E:\n\tv151 = *([v131 @ X28_v1 (System.Int32)]);\n\tv153 = *([v151 @ X0_v3+E4]) == 0;\n\tif (v153) goto L_00CA;\nL_0067:\n\tv182 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v182, v176.<>9, Il2CppMethodInfo);\n\tv231.<>9__1_0 = v182;\nL_008F:\n\tv241 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v241, v235.<>9, Il2CppMethodInfo);\n\tv282.<>9__1_1 = v241;\nL_00BD:\n\tUnityEngine.Debug::LogError(v277);\nL_00E6:\n\treturn returnVal2;\n")]
		public static bool ExportToFile(Texture2D texture, string fullpath, ImageFileFormat imageFormat, int JPGQuality = 70, bool addToGallery = true, bool async = false, UnityAction onExportSuccess = null, UnityAction onExportFailure = null)
		{
			//IL_02af: Expected O, but got I4
			bool flag = onExportSuccess == null;
			bool flag2 = !flag;
			UnityAction unityAction = onExportSuccess;
			int num;
			bool addToGallery2;
			UnityAction onExportSuccess2;
			UnityAction unityAction3;
			int num2;
			bool flag5;
			if (!flag2)
			{
				unityAction = _003C_003Ec._003C_003E9__1_0;
				if (_003C_003Ec._003C_003E9__1_0 == null)
				{
					UnityAction unityAction2 = (_003C_003Ec._003C_003E9__1_0 = delegate
					{
					});
					num = 187244544 + 1440;
					bool flag3 = onExportFailure == null;
					bool flag4 = !flag3;
					addToGallery2 = addToGallery;
					onExportSuccess2 = unityAction2;
					unityAction3 = onExportFailure;
					if (!flag4)
					{
						num2 = num;
						flag5 = addToGallery;
						unityAction = unityAction2;
						goto IL_008d;
					}
					goto IL_02a7;
				}
			}
			num2 = 187244544 + 1440;
			bool flag6 = onExportFailure == null;
			bool flag7 = !flag6;
			flag5 = addToGallery;
			num = num2;
			addToGallery2 = addToGallery;
			onExportSuccess2 = unityAction;
			unityAction3 = onExportFailure;
			if (!flag7)
			{
				goto IL_008d;
			}
			goto IL_02a7;
			IL_008d:
			unityAction3 = _003C_003Ec._003C_003E9__1_1;
			bool flag8 = _003C_003Ec._003C_003E9__1_1 == null;
			bool flag9 = !flag8;
			num = num2;
			addToGallery2 = flag5;
			onExportSuccess2 = unityAction;
			if (!flag9)
			{
				UnityAction unityAction4 = (_003C_003Ec._003C_003E9__1_1 = delegate
				{
				});
				num = num2;
				addToGallery2 = flag5;
				onExportSuccess2 = unityAction;
				unityAction3 = unityAction4;
			}
			goto IL_02a7;
			IL_0196:
			string message = "Can not export the texture to file " + fullpath + ", texture is empty.";
			Debug.LogError(message);
			unityAction3();
			return false;
			IL_02a7:
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X0_v3+E4]");
			if ((nint)0 != 0)
			{
				if (texture == null)
				{
					goto IL_0196;
				}
			}
			else if (texture == null)
			{
				goto IL_0196;
			}
			if (async)
			{
				Task<bool> task = EncodeAndExportToFileAsync(texture, fullpath, imageFormat, JPGQuality, addToGallery2, onExportSuccess2, unityAction3);
				return true;
			}
			return ExportToFile(texture, fullpath, imageFormat, JPGQuality, addToGallery2, async: false, onExportSuccess2, unityAction3);
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x3C42400", Offset = "0x3C42400", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = AlmostEngine.Screenshot.TextureExporter::EncodeTextureToBytes(texture, imageFormat, JPGQuality);\n\tv28 = v26 == 0;\n\tif (v28) goto L_FFFFFFFF;\n\tv30 = AlmostEngine.Screenshot.TextureExporter::WriteBytesToFile(v26, fullpath, JPGQuality, JPGQuality);\n\tv32 = v30 == 0;\n\tif (v32) goto L_FFFFFFFF;\n\tv55 = ~addToGallery;\n\tif (v55) goto L_FFFFFFFF;\n\tv35 = AlmostEngine.Screenshot.GalleryUtils::AddToGallery(fullpath);\n\tv33 = v35 == 0;\n\tif (v33) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv59 = 1;\nL_FFFFFFFF:\n\tv61 = onExportSuccess;\n\tgoto L_0028;\nL_FFFFFFFF:\n\tv59 = 0;\nL_FFFFFFFF:\n\tv61 = onExportFailure;\nL_0028:\n\tUnityEngine.Events.UnityAction::Invoke(v61);\n\treturn v59;\n")]
		private static bool ExportToFileNoAsync(Texture2D texture, string fullpath, ImageFileFormat imageFormat, int JPGQuality = 70, bool addToGallery = true, bool async = false, UnityAction onExportSuccess = null, UnityAction onExportFailure = null)
		{
			byte[] array = EncodeTextureToBytes(texture, imageFormat, JPGQuality);
			bool result;
			UnityAction unityAction;
			if (array != null && WriteBytesToFile(array, fullpath, (ImageFileFormat)JPGQuality, JPGQuality) && (!addToGallery || GalleryUtils.AddToGallery(fullpath)))
			{
				result = true;
				unityAction = onExportSuccess;
			}
			else
			{
				result = false;
				unityAction = onExportFailure;
			}
			unityAction();
			return result;
		}

		[AsyncStateMachine(typeof(_003CEncodeAndExportToFileAsync_003Ed__3))]
		[Token(Token = "0x600016B")]
		[Address(RVA = "0x3C42288", Offset = "0x3C42288", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\nL_003E:\n\tv86 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::Create();\n\tv126.<>t__builder = v86;\n\tv126.texture = texture;\n\tv126.fullpath = fullpath;\n\tv126.imageFormat = imageFormat;\n\tv126.JPGQuality = JPGQuality;\n\tv126.addToGallery = addToGallery;\n\tv126.onExportSuccess = onExportSuccess;\n\tv126.onExportFailure = onExportFailure;\n\tv126.<>1__state = -1;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::Start(&v126.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), &v126 @ stack_-C0_v2 (AlmostEngine.Screenshot.TextureExporter+<EncodeAndExportToFileAsync>d__3));\n\treturnVal1 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::get_Task(&v126.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>));\n\treturn returnVal1;\nL_003A:\n\tgoto L_003E;\n")]
		public static Task<bool> EncodeAndExportToFileAsync(Texture2D texture, string fullpath, ImageFileFormat imageFormat, int JPGQuality = 70, bool addToGallery = true, UnityAction onExportSuccess = null, UnityAction onExportFailure = null)
		{
			AsyncTaskMethodBuilder<bool> _003C_003Et__builder = AsyncTaskMethodBuilder<bool>.Create();
			_003CEncodeAndExportToFileAsync_003Ed__3 stateMachine = default(_003CEncodeAndExportToFileAsync_003Ed__3);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine.texture = texture;
			stateMachine.fullpath = fullpath;
			stateMachine.imageFormat = imageFormat;
			stateMachine.JPGQuality = JPGQuality;
			stateMachine.addToGallery = addToGallery;
			stateMachine.onExportSuccess = onExportSuccess;
			stateMachine.onExportFailure = onExportFailure;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CExportToFileWriteAsync_003Ed__4))]
		[Token(Token = "0x600016C")]
		[Address(RVA = "0x3C4276C", Offset = "0x3C4276C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\nL_003E:\n\tv86 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::Create();\n\tv126.<>t__builder = v86;\n\tv126.texture = texture;\n\tv126.fullpath = fullpath;\n\tv126.imageFormat = imageFormat;\n\tv126.JPGQuality = JPGQuality;\n\tv126.addToGallery = addToGallery;\n\tv126.onExportSuccess = onExportSuccess;\n\tv126.onExportFailure = onExportFailure;\n\tv126.<>1__state = -1;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::Start(&v126.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>), &v126 @ stack_-C0_v2 (AlmostEngine.Screenshot.TextureExporter+<ExportToFileWriteAsync>d__4));\n\treturnVal1 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>::get_Task(&v126.<>t__builder (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>));\n\treturn returnVal1;\nL_003A:\n\tgoto L_003E;\n")]
		public static Task<bool> ExportToFileWriteAsync(Texture2D texture, string fullpath, ImageFileFormat imageFormat, int JPGQuality = 70, bool addToGallery = true, UnityAction onExportSuccess = null, UnityAction onExportFailure = null)
		{
			AsyncTaskMethodBuilder<bool> _003C_003Et__builder = AsyncTaskMethodBuilder<bool>.Create();
			_003CExportToFileWriteAsync_003Ed__4 stateMachine = default(_003CExportToFileWriteAsync_003Ed__4);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine.texture = texture;
			stateMachine.fullpath = fullpath;
			stateMachine.imageFormat = imageFormat;
			stateMachine.JPGQuality = JPGQuality;
			stateMachine.addToGallery = addToGallery;
			stateMachine.onExportSuccess = onExportSuccess;
			stateMachine.onExportFailure = onExportFailure;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x3C4248C", Offset = "0x3C4248C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = imageFormat == 2;\n\tif (v15) goto L_0025;\n\tv29 = imageFormat != 1;\n\tif (v29) goto L_0028;\n\treturnVal1 = UnityEngine.ImageConversion::EncodeToJPG(texture, JPGQuality);\nL_0023:\n\treturn returnVal1;\nL_0025:\n\treturnVal1 = UnityEngine.ImageConversion::EncodeToTGA(texture);\n\tgoto L_0023;\nL_0028:\n\treturnVal1 = UnityEngine.ImageConversion::EncodeToPNG(texture);\n\tgoto L_0023;\n")]
		public static byte[] EncodeTextureToBytes(Texture2D texture, ImageFileFormat imageFormat, int JPGQuality = 70)
		{
			return imageFormat switch
			{
				ImageFileFormat.JPG => texture.EncodeToJPG(JPGQuality), 
				ImageFileFormat.TGA => texture.EncodeToTGA(), 
				_ => texture.EncodeToPNG(), 
			};
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x3C428E4", Offset = "0x3C428E4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = imageFormat == 2;\n\tif (v15) goto L_0026;\n\tv29 = imageFormat != 1;\n\tif (v29) goto L_002A;\n\treturnVal1 = UnityEngine.ImageConversion::EncodeArrayToJPG(rawTextureData, format, width, height, 0, JPGQuality);\nL_0023:\n\treturn returnVal1;\nL_0026:\n\treturnVal1 = UnityEngine.ImageConversion::EncodeArrayToTGA(rawTextureData, format, width, height, 0);\n\tgoto L_0023;\nL_002A:\n\treturnVal1 = UnityEngine.ImageConversion::EncodeArrayToPNG(rawTextureData, format, width, height, 0);\n\tgoto L_0023;\n")]
		public static byte[] EncodeRawTextureToBytes(byte[] rawTextureData, GraphicsFormat format, int width, int height, ImageFileFormat imageFormat, int JPGQuality = 70)
		{
			return imageFormat switch
			{
				ImageFileFormat.JPG => ImageConversion.EncodeArrayToJPG(rawTextureData, format, (uint)width, (uint)height, 0u, JPGQuality), 
				ImageFileFormat.TGA => ImageConversion.EncodeArrayToTGA(rawTextureData, format, (uint)width, (uint)height), 
				_ => ImageConversion.EncodeArrayToPNG(rawTextureData, format, (uint)width, (uint)height), 
			};
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x3C425C0", Offset = "0x3C425C0", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tSystem.IO.File::WriteAllBytes(fullpath, encodedBytes);\n\treturn 1;\nL_0032:\n\tv61 = System.String::Concat(\"Could not create the export directory : \", fullpath);\n\tgoto L_003C;\nL_003C:\n\tUnityEngine.Debug::LogError(v61);\n\treturn 0;\nL_001A:\n\tv46 = AlmostEngine.PathUtils::CreateExportDirectory(fullpath);\n\tv50 = v46 == 0;\n\tif (v50) goto L_0032;\n")]
		public static bool WriteBytesToFile(byte[] encodedBytes, string fullpath, ImageFileFormat imageFormat, int JPGQuality)
		{
			if (PathUtils.CreateExportDirectory(fullpath))
			{
				File.WriteAllBytes(fullpath, encodedBytes);
				return true;
			}
			string message = "Could not create the export directory : " + fullpath;
			Debug.LogError(message);
			return false;
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x3C42A20", Offset = "0x3C42A20", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv60 = System.IO.File::ReadAllBytes(fullname);\n\tv75 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v75, 2, 2);\n\tv124 = UnityEngine.ImageConversion::LoadImage(v75, v60);\n\tv145 = v124 == 0;\n\tv133 = ~v145;\n\tv135 = v75;\n\tif (v133) goto L_006C;\n\tv112 = System.String::Concat(\"Failed to load the texture \", fullname, \".\");\n\tv135 = v75;\n\tgoto L_0063;\nL_0057:\n\tv112 = System.String::Concat(\"Can not load texture from file \", fullname, \", file does not exists.\");\n\tv135 = 0;\n\tgoto L_0063;\nL_006C:\n\treturn v135;\nL_0027:\n\tv47 = System.IO.File::Exists(fullname);\n\tv52 = v47 == 0;\n\tif (v52) goto L_0057;\nL_0063:\n\tUnityEngine.Debug::LogError(v112);\n")]
		public static Texture2D LoadFromFile(string fullname)
		{
			Texture2D result;
			string message;
			if (File.Exists(fullname))
			{
				byte[] data = File.ReadAllBytes(fullname);
				Texture2D texture2D = new Texture2D(2, 2);
				bool flag = texture2D.LoadImage(data);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = texture2D;
				if (flag3)
				{
					goto IL_00b6;
				}
				message = "Failed to load the texture " + fullname + ".";
				result = texture2D;
			}
			else
			{
				message = "Can not load texture from file " + fullname + ", file does not exists.";
				result = null;
			}
			Debug.LogError(message);
			goto IL_00b6;
			IL_00b6:
			return result;
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x3C42B84", Offset = "0x3C42B84", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv76 = v71 == 0;\n\tif (v76) goto L_00E6;\n\tv83 = new System.IO.DirectoryInfo();\n\tSystem.IO.DirectoryInfo::.ctor(v83, path);\n\tv121 = System.IO.DirectoryInfo::GetFiles(v83);\n\tv223 = v121.Length < 1;\n\tif (v223) goto L_0100;\n\tv148 = 0;\n\tgoto L_007F;\nL_0071:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::Add(v60, v342);\nL_0073:\n\tv148 = v148 + 1;\n\tv224 = v148 >= v121.Length;\n\tif (v224) goto L_0100;\nL_007F:\n\t;\n\tv324 = System.IO.FileSystemInfo::get_Extension(v121[v148 @ X23_v5 (System.Int32)]);\n\tv327 = System.String::op_Equality(v324, \".jpg\");\n\tv329 = v327 == 0;\n\tv330 = ~v329;\n\tif (v330) goto L_0095;\n\tv333 = System.IO.FileSystemInfo::get_Extension(v121[v148 @ X23_v5 (System.Int32)]);\n\tv338 = System.String::op_Equality(v333, \".png\");\n\tv340 = ~v338;\n\tif (v340) goto L_0073;\nL_0095:\n\tv342 = new AlmostEngine.Screenshot.TextureExporter+ImageFile();\n\tSystem.Object::.ctor(v342);\n\tv185 = System.IO.FileSystemInfo::get_Name(v121[v148 @ X23_v5 (System.Int32)]);\n\tv342.m_Name = v185;\n\tv381 = System.IO.FileSystemInfo::get_FullName(v121[v148 @ X23_v5 (System.Int32)]);\n\tv342.m_Fullname = v381;\n\tv388 = System.IO.FileSystemInfo::get_CreationTime(v121[v148 @ X23_v5 (System.Int32)]);\n\tv342.m_CreationDate = v388;\n\tv391 = System.IO.FileSystemInfo::get_FullName(v121[v148 @ X23_v5 (System.Int32)]);\n\tv392 = AlmostEngine.Screenshot.TextureExporter::LoadFromFile(v391);\n\tv342.m_Texture = v392;\n\tgoto L_0071;\nL_00E6:\n\tv112 = System.String::Concat(\"Can not load images from directory \", path, \", directory does not exists.\");\n\tgoto L_00F1;\nL_0100:\n\treturn v60;\nL_003A:\n\tv60 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::.ctor(v60);\n\tv71 = System.IO.Directory::Exists(path);\nL_00F1:\n\tUnityEngine.Debug::LogError(v112);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<ImageFile> LoadFromPath(string path)
		{
			List<ImageFile> list = new List<ImageFile>();
			if (Directory.Exists(path))
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				FileInfo[] files = directoryInfo.GetFiles();
				if (files.Length >= 1)
				{
					int num = 0;
					do
					{
						string extension = files[num].Extension;
						if (!(extension == ".jpg"))
						{
							string extension2 = files[num].Extension;
							if (!(extension2 == ".png"))
							{
								goto IL_0086;
							}
						}
						ImageFile imageFile = new ImageFile();
						string name = ((FileSystemInfo)files[num]).Name;
						imageFile.m_Name = name;
						string fullName = files[num].FullName;
						imageFile.m_Fullname = fullName;
						DateTime creationTime = files[num].CreationTime;
						imageFile.m_CreationDate = creationTime;
						string fullName2 = files[num].FullName;
						Texture2D texture = LoadFromFile(fullName2);
						imageFile.m_Texture = texture;
						list.Add(imageFile);
						goto IL_0086;
						IL_0086:
						num++;
					}
					while (num < files.Length);
				}
			}
			else
			{
				string message = "Can not load images from directory " + path + ", directory does not exists.";
				Debug.LogError(message);
			}
			return list;
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0x3C42E8C", Offset = "0x3C42E8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TextureExporter()
		{
		}
	}
}
