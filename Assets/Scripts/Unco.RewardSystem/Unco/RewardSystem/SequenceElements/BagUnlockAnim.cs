using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Unco.RewardSystem.SimpleSequenceSystem;

namespace Unco.RewardSystem.SequenceElements
{
	[Token(Token = "0x2000030")]
	public class BagUnlockAnim : ISequenceElement
	{
		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<ShopItemData> _rewards;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x18")]
		private readonly string _chestName;

		[CompilerGenerated]
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x20")]
		private Action _003COnComplete_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x28")]
		private Action _003COnStart_003Ek__BackingField;

		[Token(Token = "0x14000009")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0x81DB6A4", Offset = "0x81DB6A4", Length = "0xA4")]
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
			[Token(Token = "0x60000BE")]
			[Address(RVA = "0x81DB748", Offset = "0x81DB748", Length = "0xA4")]
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

		[Token(Token = "0x1400000A")]
		public event Action OnStart
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BF")]
			[Address(RVA = "0x81DB7EC", Offset = "0x81DB7EC", Length = "0xA4")]
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
			[Token(Token = "0x60000C0")]
			[Address(RVA = "0x81DB890", Offset = "0x81DB890", Length = "0xA4")]
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

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x81DB934", Offset = "0x81DB934", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._chestName = chestName;\n\tthis._rewards = rewards;\n\treturn;\n")]
		public BagUnlockAnim(string chestName, List<ShopItemData> rewards)
		{
			_chestName = chestName;
			_rewards = rewards;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x81DB984", Offset = "0x81DB984", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.OnStart == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.OnStart);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			if (_003COnStart_003Ek__BackingField != null)
			{
				_003COnStart_003Ek__BackingField();
			}
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x81DB9A0", Offset = "0x81DB9A0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturn;\nL_001C:\n\tv48 = new System.Action();\n\tSystem.Action::.ctor(v48, this, Il2CppMethodInfo);\n\tv66 = PrimeTween.Tween::Delay(0.25f, v48, 0, 1);\n")]
		private void Complete()
		{
			Action onComplete = delegate
			{
				if (_003COnComplete_003Ek__BackingField != null)
				{
					_003COnComplete_003Ek__BackingField();
				}
			};
			Tween tween = Tween.Delay(0.25f, onComplete);
		}
	}
}
