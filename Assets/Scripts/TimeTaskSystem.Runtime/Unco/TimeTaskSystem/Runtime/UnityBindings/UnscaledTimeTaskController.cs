using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TimeTaskSystem.Runtime.UnityBindings
{
	[Token(Token = "0x200000E")]
	public class UnscaledTimeTaskController : ITimeTaskController, IDisposable
	{
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x10")]
		private readonly TimeTaskController _timeTaskController;

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x8195EF8", Offset = "0x8195EF8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tthis._timeTaskController = v60;\n\tgoto L_003F;\nL_003F:\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::Register(this);\n\treturn;\nL_0025:\n\tSystem.Object::.ctor(this);\n\tv60 = new Unco.TimeTaskSystem.Runtime.TimeTaskController();\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::.ctor(v60, initialBuffer, \"UnscaledTimeTaskController\");\n")]
		public UnscaledTimeTaskController(int initialBuffer = 256)
		{
			TimeTaskController timeTaskController = new TimeTaskController(initialBuffer, "UnscaledTimeTaskController");
			_timeTaskController = timeTaskController;
			TimeTaskPlayerLoopSystem.Register(this);
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x8195FD8", Offset = "0x8195FD8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = *([B799EB5]) & 1;\n\tv52 = v51 == 0;\n\tif (v52) goto L_0035;\n\tv66 = this == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_003C;\n\tgoto L_0052;\nL_0035:\n\t*([B799EB5]) = 1;\n\tv80 = this == 0;\n\tif (v80) goto L_0052;\nL_003C:\n\tgoto L_0047;\nL_0047:\n\tv95 = System.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::Remove(v106._controllers, this);\nL_0052:\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::Dispose(this._timeTaskController);\n\treturn;\n")]
		public void Dispose()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799EB5]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if (this != null)
				{
					goto IL_0084;
				}
			}
			else
			{
				_ = 1;
				if (this != null)
				{
					goto IL_0084;
				}
			}
			goto IL_0098;
			IL_0098:
			_timeTaskController.Dispose();
			return;
			IL_0084:
			bool flag = TimeTaskPlayerLoopSystem._controllers.Remove(this);
			goto IL_0098;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x81960C4", Offset = "0x81960C4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_unscaledDeltaTime();\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::Tick(this._timeTaskController, v13);\n\treturn;\n")]
		void ITimeTaskController.Update()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			_timeTaskController.Tick(unscaledDeltaTime);
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x81960F4", Offset = "0x81960F4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.TimeTaskSystem.Runtime.TimeTaskController::CreateTimer(this._timeTaskController, duration, flags, elapsed, updateInterval);\n\treturn returnVal1;\n")]
		public TimerHandle CreateTimer(float duration, TimerFlags flags, float elapsed = 0f, float updateInterval = 0f)
		{
			return _timeTaskController.CreateTimer(duration, flags, elapsed, updateInterval);
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x819610C", Offset = "0x819610C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = countDown == 0;\n\tv14 = ~v8;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv68 = 9;\n\tgoto L_0014;\nL_FFFFFFFF:\n\tv68 = 1;\nL_FFFFFFFF:\n\tv68 = v39;\n\tgoto L_0025;\nL_FFFFFFFF:\n\tv60 = v52;\n\tgoto L_0036;\nL_FFFFFFFF:\n\tv60 = v68;\nL_0014:\n\tv39 = v68 | 4;\n\tv44 = hasInterval == 0;\n\tv49 = ~v44;\n\tv50 = ~v49;\n\tif (v50) goto L_0025;\nL_0025:\n\tv52 = v68 | 0x10;\n\tv83 = loops == 0;\n\tv65 = ~v83;\n\tv62 = ~v65;\n\tif (v62) goto L_FFFFFFFF;\nL_0036:\n\treturnVal2 = Unco.TimeTaskSystem.Runtime.TimeTaskController::CreateTimer(this._timeTaskController, duration, v60, elapsed, updateInterval);\n\treturn returnVal2;\n")]
		public TimerHandle CreateTimer(float duration, bool countDown, bool hasInterval, bool loops, float elapsed = 0f, float updateInterval = 0f)
		{
			int num = ((!countDown) ? 1 : 9);
			int num2 = num | 4;
			if (hasInterval)
			{
				num = num2;
			}
			int num3 = num | 0x10;
			TimerFlags flags = (TimerFlags)((!loops) ? num : num3);
			return _timeTaskController.CreateTimer(duration, flags, elapsed, updateInterval);
		}
	}
}
