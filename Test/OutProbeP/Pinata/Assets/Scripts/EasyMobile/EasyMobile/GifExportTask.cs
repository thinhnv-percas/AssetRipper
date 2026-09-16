using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000058")]
	internal class GifExportTask
	{
		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0x10")]
		internal int taskId;

		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0x18")]
		internal AnimatedClip clip;

		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x20")]
		internal Color32[][] imageData;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x28")]
		internal string filepath;

		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0x30")]
		internal int loop;

		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0x34")]
		internal int sampleFac;

		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0x38")]
		internal bool isExporting;

		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0x39")]
		internal bool isDone;

		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x3C")]
		internal float progress;

		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x40")]
		internal Action<AnimatedClip, float> exportProgressCallback;

		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0x48")]
		internal Action<AnimatedClip, string> exportCompletedCallback;

		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x50")]
		internal ThreadPriority workerPriority;

		[Token(Token = "0x600046B")]
		[Address(RVA = "0xBF404C", Offset = "0xBF404C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GifExportTask()
		{
		}
	}
}
