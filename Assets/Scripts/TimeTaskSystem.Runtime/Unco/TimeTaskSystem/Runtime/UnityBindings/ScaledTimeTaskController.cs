using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TimeTaskSystem.Runtime.UnityBindings
{
	[Token(Token = "0x200000C")]
	public class ScaledTimeTaskController : ITimeTaskController, IDisposable
	{
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x10")]
		private readonly TimeTaskController _timeTaskController;

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x81952C4", Offset = "0x81952C4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tthis._timeTaskController = v60;\n\tgoto L_003F;\nL_003F:\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::Register(this);\n\treturn;\nL_0025:\n\tSystem.Object::.ctor(this);\n\tv60 = new Unco.TimeTaskSystem.Runtime.TimeTaskController();\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::.ctor(v60, initialBuffer, \"ScaledTimeTaskController\");\n")]
		public ScaledTimeTaskController(int initialBuffer = 256)
		{
			TimeTaskController timeTaskController = new TimeTaskController(initialBuffer, "ScaledTimeTaskController");
			_timeTaskController = timeTaskController;
			TimeTaskPlayerLoopSystem.Register(this);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x81955E8", Offset = "0x81955E8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = *([B799EB5]) & 1;\n\tv52 = v51 == 0;\n\tif (v52) goto L_004B;\n\tv66 = this == 0;\n\tif (v66) goto L_0056;\nL_001F:\n\tgoto L_0031;\nL_0031:\n\tv114 = System.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::Remove(v102._controllers, this);\n\treturn;\nL_004B:\n\t*([B799EB5]) = 1;\n\tv127 = this == 0;\n\tv79 = ~v127;\n\tif (v79) goto L_001F;\nL_0056:\n\treturn;\n")]
		public void Dispose()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799EB5]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if (this == null)
				{
					return;
				}
			}
			else
			{
				_ = 1;
				if (this == null)
				{
					return;
				}
			}
			bool flag = TimeTaskPlayerLoopSystem._controllers.Remove(this);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x819576C", Offset = "0x819576C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_deltaTime();\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::Tick(this._timeTaskController, v13);\n\treturn;\n")]
		void ITimeTaskController.Update()
		{
			float deltaTime = Time.deltaTime;
			_timeTaskController.Tick(deltaTime);
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x819579C", Offset = "0x819579C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.TimeTaskSystem.Runtime.TimeTaskController::CreateTimer(this._timeTaskController, duration, flags, elapsed, updateInterval);\n\treturn returnVal1;\n")]
		public TimerHandle CreateTimer(float duration, TimerFlags flags, float elapsed = 0f, float updateInterval = 0f)
		{
			return _timeTaskController.CreateTimer(duration, flags, elapsed, updateInterval);
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x81957B4", Offset = "0x81957B4", Length = "0x3C")]
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
