using System;
using System.Collections.Generic;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using EM_Moments.Encoder;

namespace EM_Moments
{
	[Token(Token = "0x2000004")]
	internal sealed class Worker
	{
		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x10")]
		private Thread m_Thread;

		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x18")]
		private int m_Id;

		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x20")]
		internal List<GifFrame> m_Frames;

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x28")]
		internal GifEncoder m_Encoder;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x30")]
		internal string m_FilePath;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x38")]
		internal Action<int, string> m_OnFileSaved;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x40")]
		internal Action<int, float> m_OnFileSaveProgress;

		[Token(Token = "0x600000A")]
		[Address(RVA = "0xA42514", Offset = "0xA42514", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv46 = *([1F04280]);\n\tv47 = *([v46 @ X8_v10]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, taskId, priority, frames, encoder, filepath, onFileSaveProgress, onFileSaved, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2021E85]) = v59;\nL_0023:\n\tSystem.Object::.ctor(this);\n\tthis.m_Id = taskId;\n\tv65 = new System.Threading.ThreadStart();\n\tSystem.Threading.ThreadStart::.ctor(v65, this, Il2CppMethodInfo);\n\tv75 = new System.Threading.Thread();\n\tSystem.Threading.Thread::.ctor(v75, v65);\n\tthis.m_Thread = v75;\n\tSystem.Threading.Thread::set_Priority(v75, priority);\n\tthis.m_Frames = frames;\n\tthis.m_Encoder = encoder;\n\tthis.m_FilePath = filepath;\n\tthis.m_OnFileSaved = onFileSaved;\n\tthis.m_OnFileSaveProgress = onFileSaveProgress;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Worker(int taskId, ThreadPriority priority, List<GifFrame> frames, GifEncoder encoder, string filepath, Action<int, float> onFileSaveProgress, Action<int, string> onFileSaved)
		{
			m_Id = taskId;
			ThreadStart start = Run;
			(m_Thread = new Thread(start)).Priority = priority;
			m_Frames = frames;
			m_Encoder = encoder;
			m_FilePath = filepath;
			m_OnFileSaved = onFileSaved;
			m_OnFileSaveProgress = onFileSaveProgress;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0xA42618", Offset = "0xA42618", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Threading.Thread::Start(this.m_Thread);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Start()
		{
			m_Thread.Start();
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0xA42634", Offset = "0xA42634", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBC8B0]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E86]) = v42;\nL_0018:\n\t;\n\tEM_Moments.Encoder.GifEncoder::Start(this.m_Encoder, this.m_FilePath);\n\tv99 = this.m_Frames;\nL_002A:\n\tv219 = v114 >= v99._size;\n\tif (v219) goto L_0059;\n\tv222 = v99._size < v114;\n\tv92 = ~v222;\n\tv88 = v99._size - v114;\n\tv80 = v88 == 0;\n\tv223 = ~v80;\n\tv60 = v92 & v223;\n\tif (v60) goto L_003D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003D:\n\tv226 = v99._items;\n\tEM_Moments.Encoder.GifEncoder::AddFrame(this.m_Encoder, v226[v114 @ X20_v8 (System.Int32)]);\n\tv229 = this.m_OnFileSaveProgress == 0;\n\tif (v229) goto L_004F;\n\tv151 = this.m_Frames;\n\tv232 = v114 / v151._size;\n\tSystem.Action`2<System.Int32, System.Single>::Invoke(this.m_OnFileSaveProgress, this.m_Id, v232);\nL_004F:\n\tv99 = this.m_Frames;\n\tv114 = v114 + 1;\n\tv235 = this.m_Frames == 0;\n\tv147 = ~v235;\n\tif (v147) goto L_002A;\n\tthrow System.NullReferenceException;\nL_0059:\n\tEM_Moments.Encoder.GifEncoder::Finish(this.m_Encoder);\n\tv186 = this.m_OnFileSaved == 0;\n\tif (v186) goto L_0072;\n\tSystem.Action`2<System.Int32, System.String>::Invoke(this.m_OnFileSaved, this.m_Id, this.m_FilePath);\n\treturn;\nL_0072:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Run()
		{
			m_Encoder.Start(m_FilePath);
			List<GifFrame> frames = m_Frames;
			int num = 0;
			while (num < frames.Count)
			{
				bool flag = frames.Count < num;
				bool flag2 = !flag;
				int num2 = frames.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				GifFrame[] items = frames._items;
				m_Encoder.AddFrame(items[num]);
				if (m_OnFileSaveProgress != null)
				{
					List<GifFrame> frames2 = m_Frames;
					float arg = (float)num / (float)frames2.Count;
					m_OnFileSaveProgress(m_Id, arg);
				}
				frames = m_Frames;
				num++;
				if (m_Frames == null)
				{
					throw new NullReferenceException();
				}
			}
			m_Encoder.Finish();
			if (m_OnFileSaved != null)
			{
				m_OnFileSaved(m_Id, m_FilePath);
			}
		}
	}
}
