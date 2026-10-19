using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x2000017")]
	public abstract class ReactiveCondition : ICondition, IDisposable
	{
		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x10")]
		internal bool _isInit;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x14")]
		internal int _lastState;

		[CompilerGenerated]
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x18")]
		internal Action OnConditionChanged;

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x81AE218", Offset = "0x81AE218", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._isInit == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0017;\n\tv20 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = returnVal1;\n\tv58 = this.OnConditionChanged == 0;\n\tif (v58) goto L_0033;\n\tSystem.Action::Invoke(this.OnConditionChanged);\nL_0017:\n\treturnVal1 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(this);\n\tv52 = this._lastState == returnVal1;\n\tif (v52) goto L_0033;\nL_0033:\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsConditionMet()
		{
			if (!_isInit)
			{
				Subscribe();
				_isInit = true;
			}
			bool flag = InnerIsConditionMet();
			if (_lastState != (flag ? 1 : 0))
			{
				_lastState = (flag ? 1 : 0);
				if (OnConditionChanged != null)
				{
					OnConditionChanged();
				}
			}
			return flag;
		}

		[Token(Token = "0x6000044")]
		protected internal abstract bool InnerIsConditionMet();

		[Token(Token = "0x6000045")]
		protected internal abstract void Subscribe();

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x81AF504", Offset = "0x81AF504", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._isInit != 1;\n\tif (v11) goto L_001D;\n\tv26 = Unco.GameConditions.Implementations.ReactiveCondition::InnerDispose(this);\n\tthis._isInit = 0;\nL_001D:\n\treturn;\n")]
		public void Dispose()
		{
			if (_isInit)
			{
				InnerDispose();
				_isInit = false;
			}
		}

		[Token(Token = "0x6000047")]
		protected abstract void InnerDispose();

		[CompilerGenerated]
		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81AE7A8", Offset = "0x81AE7A8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnConditionChanged (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnConditionChanged;\n\tgoto L_002C;\n")]
		public void add_OnConditionChanged(Action value)
		{
			Action action = OnConditionChanged;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnConditionChanged, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000049")]
		[Address(RVA = "0x81AE98C", Offset = "0x81AE98C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnConditionChanged (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnConditionChanged;\n\tgoto L_002C;\n")]
		public void remove_OnConditionChanged(Action value)
		{
			Action action = OnConditionChanged;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnConditionChanged, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x81AF4E8", Offset = "0x81AF4E8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.OnConditionChanged == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InvokeOnOnConditionChanged()
		{
			if (OnConditionChanged != null)
			{
				OnConditionChanged();
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x81AE2A8", Offset = "0x81AE2A8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected internal ReactiveCondition()
		{
			_lastState = -1;
		}
	}
}
