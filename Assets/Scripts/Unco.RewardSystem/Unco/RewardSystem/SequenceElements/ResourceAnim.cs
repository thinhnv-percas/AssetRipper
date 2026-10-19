using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Unco.ResourceSystem;
using Unco.RewardSystem.SimpleSequenceSystem;

namespace Unco.RewardSystem.SequenceElements
{
	[Token(Token = "0x2000031")]
	public class ResourceAnim : ISequenceElement
	{
		[CompilerGenerated]
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x10")]
		private Action _003COnStart_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x18")]
		private Action _003COnComplete_003Ek__BackingField;

		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x20")]
		public ResourceType ResourceType;

		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x24")]
		public int Amount;

		[Token(Token = "0x1400000B")]
		public event Action OnStart
		{
			[CompilerGenerated]
			[Token(Token = "0x60000C5")]
			[Address(RVA = "0x81DBA4C", Offset = "0x81DBA4C", Length = "0xA4")]
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
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0x81DBAF0", Offset = "0x81DBAF0", Length = "0xA4")]
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

		[Token(Token = "0x1400000C")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0x81DBB94", Offset = "0x81DBB94", Length = "0xA4")]
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
			[Token(Token = "0x60000C8")]
			[Address(RVA = "0x81DBC38", Offset = "0x81DBC38", Length = "0xA4")]
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

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x81DBCDC", Offset = "0x81DBCDC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.ResourceType = resourceType;\n\tthis.Amount = amount;\n\treturn;\n")]
		public ResourceAnim(ResourceType resourceType, int amount)
		{
			ResourceType = resourceType;
			Amount = amount;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x81DBD14", Offset = "0x81DBD14", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tSystem.Action::Invoke(this.OnStart);\n\treturn;\nL_001B:\n\t;\n\tv48 = this.OnStart == 0;\n\tif (v48) goto L_0023;\nL_0023:\n\tv60 = new System.Action();\n\tSystem.Action::.ctor(v60, this, Il2CppMethodInfo);\n\tv76 = PrimeTween.Tween::Delay(0.5f, v60, 1, 1);\n")]
		public void Start()
		{
			if (_003COnStart_003Ek__BackingField != null)
			{
				_003COnStart_003Ek__BackingField();
			}
			Action onComplete = delegate
			{
				if (_003COnComplete_003Ek__BackingField != null)
				{
					_003COnComplete_003Ek__BackingField();
				}
			};
			Tween tween = Tween.Delay(0.5f, onComplete, useUnscaledTime: true);
		}
	}
}
