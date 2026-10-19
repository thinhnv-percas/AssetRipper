using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.Extensions
{
	[Token(Token = "0x2000019")]
	public static class TaskExtensions
	{
		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x81AABD4", Offset = "0x81AABD4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void Forget(this Task task)
		{
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x81AABD8", Offset = "0x81AABD8", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = cancellationToken;\n\tgoto L_0039;\n\tSystem.Threading.Tasks.TaskCompletionSource`1<System.Boolean>::.ctor(v70);\n\tv60.tcs = v70;\n\tSystem.Diagnostics.Process::set_EnableRaisingEvents(process, 1);\n\tv197 = new System.EventHandler();\n\tSystem.EventHandler::.ctor(v197, v60, Il2CppMethodInfo);\n\tSystem.Diagnostics.Process::add_Exited(process, v197);\n\tgoto L_0068;\nL_0068:\n\tv209 = System.Threading.CancellationToken::op_Inequality(cancellationToken, 0);\n\tv211 = ~v209;\n\tv212 = ~v211;\n\tif (v212) goto L_0087;\n\tv185 = v60.tcs;\nL_007B:\n\treturn v185.Task;\nL_0087:\n\tv226 = new System.Action();\n\tSystem.Action::.ctor(v226, v60.tcs, Il2CppMethodInfo);\n\tgoto L_0099;\nL_0099:\n\tv118 = System.Threading.CancellationToken::Register(&v26 @ stack_-58_v1 (System.Threading.CancellationToken), v226);\n\tv185 = v60.tcs;\n\tv242 = v60.tcs == 0;\n\tv121 = ~v242;\n\tif (v121) goto L_007B;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0039:\n\tv60 = new Unco.Extensions.TaskExtensions+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v60);\n\tv70 = new System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>();\n")]
		public static Task WaitForExitAsync(this Process process, CancellationToken cancellationToken = default(CancellationToken))
		{
			CancellationToken cancellationToken2 = cancellationToken;
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			TaskCompletionSource<bool> tcs = taskCompletionSource;
			process.EnableRaisingEvents = true;
			EventHandler value = delegate
			{
				bool flag = tcs.TrySetResult(result: true);
			};
			process.Exited += value;
			TaskCompletionSource<bool> taskCompletionSource2;
			if (!(cancellationToken != default(CancellationToken)))
			{
				taskCompletionSource2 = tcs;
			}
			else
			{
				Action callback = tcs.SetCanceled;
				CancellationTokenRegistration cancellationTokenRegistration = cancellationToken2.Register(callback);
				taskCompletionSource2 = tcs;
				if (tcs == null)
				{
					return (Task)(object)new NullReferenceException();
				}
			}
			return taskCompletionSource2.Task;
		}
	}
}
