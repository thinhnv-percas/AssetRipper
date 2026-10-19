using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.RewardSystem.SimpleSequenceSystem
{
	[Token(Token = "0x2000029")]
	public class TimeElement : ISequenceElement
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200002A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400004C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400004D")]
			public static Action<TimeElement> _003C_003E9__9_0;

			[Token(Token = "0x60000A8")]
			[Address(RVA = "0x81DAE1C", Offset = "0x81DAE1C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.RewardSystem.SimpleSequenceSystem.TimeElement+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000A9")]
			[Address(RVA = "0x81DAE80", Offset = "0x81DAE80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CStart_003Eb__9_0(TimeElement t)
			{
				if (t._003COnComplete_003Ek__BackingField != null)
				{
					t._003COnComplete_003Ek__BackingField();
				}
			}
		}

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x10")]
		internal readonly float _time;

		[CompilerGenerated]
		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x18")]
		private Action _003COnComplete_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x20")]
		private Action _003COnStart_003Ek__BackingField;

		[Token(Token = "0x14000005")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x81DAA40", Offset = "0x81DAA40", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnComplete (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnComplete;\n\tgoto L_002C;\n")]
			add
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0x81DAAE4", Offset = "0x81DAAE4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnComplete (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnComplete;\n\tgoto L_002C;\n")]
			remove
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x14000006")]
		public event Action OnStart
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A5")]
			[Address(RVA = "0x81DAB88", Offset = "0x81DAB88", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnStart (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnStart;\n\tgoto L_002C;\n")]
			add
			{
				Action action = _003COnStart_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnStart_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0x81DAC2C", Offset = "0x81DAC2C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnStart (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnStart;\n\tgoto L_002C;\n")]
			remove
			{
				Action action = _003COnStart_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnStart_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x81D9DD8", Offset = "0x81D9DD8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._time = time;\n\treturn;\n")]
		public TimeElement(float time)
		{
			_time = time;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x81DA9C0", Offset = "0x81DA9C0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = this._time;\n\tv47 = 0xB7D5000 + 0x538;\n\tv50 = \"il2cpp_vm_object_box\"(*([v47 @ X8_v4 (System.Int32)+78]), &v45 @ stack_-34_v1 (System.Single), v27, v28, v29, v30, v31, v32, this._time, v34, v35, v36, v37, v38, v39, v40);\n\treturnVal1 = System.String::Format(\"TimeElement {0}\", v50);\n\treturn returnVal1;\n")]
		public override string ToString()
		{
			float time = _time;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"TimeElement {arg}";
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x81DACD0", Offset = "0x81DACD0", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tSystem.Action::Invoke(this.OnStart);\nL_0030:\n\tv89 = 0xB2D6000 + 0xFB8;\n\tv104 = v75.<>9__9_0;\n\tv77 = v75.<>9__9_0 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_006A;\n\tgoto L_0043;\nL_0043:\n\tgoto L_004B;\nL_006A:\n\tv123 = PrimeTween.Tween::Delay /* +1 sharing this address */(this, this._time, v104, 0, 1, *([v89 @ X23_v3 (System.Int32)]));\n\treturn;\nL_0023:\n\t;\n\tv54 = this.OnStart == 0;\n\tif (v54) goto L_002E;\nL_004B:\n\tv138 = new System.Action`1<Unco.RewardSystem.SimpleSequenceSystem.TimeElement>();\n\tSystem.Action`1<Unco.RewardSystem.SimpleSequenceSystem.TimeElement>::.ctor(v138, v133.<>9, Il2CppMethodInfo);\n\tv143.<>9__9_0 = v138;\n\tv104 = v138;\nL_002E:\n\tgoto L_0030;\n")]
		public void Start()
		{
			if (_003COnStart_003Ek__BackingField != null)
			{
				_003COnStart_003Ek__BackingField();
			}
			int num = 187523072 + 4024;
			Action<TimeElement> _003C_003E9__9_ = _003C_003Ec._003C_003E9__9_0;
			if (_003C_003Ec._003C_003E9__9_0 == null)
			{
				_003C_003E9__9_ = (_003C_003Ec._003C_003E9__9_0 = delegate(TimeElement t)
				{
					if (t._003COnComplete_003Ek__BackingField != null)
					{
						t._003COnComplete_003Ek__BackingField();
					}
				});
			}
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4D167B4 (PrimeTween.Tween::Delay, and 1 more at this address)");
		}
	}
}
