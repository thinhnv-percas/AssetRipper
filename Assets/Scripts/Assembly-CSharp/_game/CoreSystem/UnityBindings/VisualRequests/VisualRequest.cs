using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Unco.RewardSystem.SimpleSequenceSystem;

namespace _game.CoreSystem.UnityBindings.VisualRequests
{
	[Token(Token = "0x2000089")]
	public abstract class VisualRequest : ISequenceElement
	{
		[CompilerGenerated]
		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x10")]
		private Action _003COnComplete_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x18")]
		private Action _003COnStart_003Ek__BackingField;

		[Token(Token = "0x17000050")]
		[field: Token(Token = "0x400016C")]
		[field: FieldOffset(Offset = "0x20")]
		public bool IsCompleted
		{
			[Token(Token = "0x600025F")]
			[Address(RVA = "0x3C76A7C", Offset = "0x3C76A7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsCompleted;\n")]
			get;
			[Token(Token = "0x6000260")]
			[Address(RVA = "0x3C76A84", Offset = "0x3C76A84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IsCompleted = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1400000D")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x600025B")]
			[Address(RVA = "0x3C767EC", Offset = "0x3C767EC", Length = "0xA4")]
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
			[Token(Token = "0x600025C")]
			[Address(RVA = "0x3C76890", Offset = "0x3C76890", Length = "0xA4")]
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

		[Token(Token = "0x1400000E")]
		public event Action OnStart
		{
			[CompilerGenerated]
			[Token(Token = "0x600025D")]
			[Address(RVA = "0x3C76934", Offset = "0x3C76934", Length = "0xA4")]
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
			[Token(Token = "0x600025E")]
			[Address(RVA = "0x3C769D8", Offset = "0x3C769D8", Length = "0xA4")]
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

		[Token(Token = "0x6000261")]
		protected abstract Sequence CreateSequence();

		[Token(Token = "0x6000262")]
		[Address(RVA = "0x3C76A8C", Offset = "0x3C76A8C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tSystem.Action::Invoke(this.OnStart);\n\tv71 = new System.Action();\n\tSystem.Action::.ctor(v71, this, Il2CppMethodInfo);\n\tv97 = PrimeTween.Sequence::ChainCallback(&v60 @ stack_-40_v1 (PrimeTween.Sequence), v71, 1);\nL_0041:\n\treturn;\nL_0043:\n\tthis.IsCompleted = 1;\n\tv74 = this.OnComplete == 0;\n\tif (v74) goto L_0041;\n\tSystem.Action::Invoke(this.OnComplete);\n\treturn;\nL_0017:\n\t;\n\tv44 = this.OnStart == 0;\n\tif (v44) goto L_0022;\nL_0022:\n\tv59 = _game.CoreSystem.UnityBindings.VisualRequests.VisualRequest::CreateSequence(this);\n\tv60 = v59;\n\tv64 = PrimeTween.Sequence::get_isAlive(&v60 @ stack_-40_v1 (PrimeTween.Sequence));\n\tv65 = ~v64;\n\tif (v65) goto L_0043;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			if (_003COnStart_003Ek__BackingField != null)
			{
				_003COnStart_003Ek__BackingField();
			}
			Sequence sequence = CreateSequence();
			Sequence sequence2 = sequence;
			if (sequence2.isAlive)
			{
				Action callback = delegate
				{
					IsCompleted = true;
					if (_003COnComplete_003Ek__BackingField != null)
					{
						_003COnComplete_003Ek__BackingField();
					}
				};
				Sequence sequence3 = sequence2.ChainCallback(callback);
			}
			else
			{
				IsCompleted = true;
				if (_003COnComplete_003Ek__BackingField != null)
				{
					_003COnComplete_003Ek__BackingField();
				}
			}
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0x3C76B94", Offset = "0x3C76B94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected internal VisualRequest()
		{
		}
	}
}
