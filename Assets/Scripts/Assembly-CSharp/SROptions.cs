using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using SRDebugger;
using SRDebugger.Internal;
using SRF.Service;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
[Token(Token = "0x200000A")]
public class SROptions : INotifyPropertyChanged
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
	[Token(Token = "0x200000B")]
	public sealed class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
	{
		[Token(Token = "0x6000034")]
		[Address(RVA = "0x3C61A5C", Offset = "0x3C61A5C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0027:\n\tSystem.ComponentModel.DisplayNameAttribute::.ctor(this, displayName);\n\treturn;\nL_001B:\n\tgoto L_0027;\n")]
		public DisplayNameAttribute(string displayName)
			: base(displayName)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	[Token(Token = "0x200000C")]
	public sealed class IncrementAttribute : SRDebugger.IncrementAttribute
	{
		[Token(Token = "0x6000035")]
		[Address(RVA = "0x3C61AC8", Offset = "0x3C61AC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSRDebugger.IncrementAttribute::.ctor(this, increment);\n\treturn;\n")]
		public IncrementAttribute(double increment)
			: base(increment)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Property)]
	[Token(Token = "0x200000D")]
	public sealed class NumberRangeAttribute : SRDebugger.NumberRangeAttribute
	{
		[Token(Token = "0x6000036")]
		[Address(RVA = "0x3C61AD0", Offset = "0x3C61AD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSRDebugger.NumberRangeAttribute::.ctor(this, min, max);\n\treturn;\n")]
		public NumberRangeAttribute(double min, double max)
			: base(min, max)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
	[Token(Token = "0x200000E")]
	public sealed class SortAttribute : SRDebugger.SortAttribute
	{
		[Token(Token = "0x6000037")]
		[Address(RVA = "0x3C61AD8", Offset = "0x3C61AD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSRDebugger.SortAttribute::.ctor(this, priority);\n\treturn;\n")]
		public SortAttribute(int priority)
			: base(priority)
		{
		}
	}

	[Token(Token = "0x400000E")]
	private static SROptions _current;

	[CompilerGenerated]
	[Token(Token = "0x400000F")]
	[FieldOffset(Offset = "0x10")]
	private SROptionsPropertyChanged _003CPropertyChanged_003Ek__BackingField;

	[CompilerGenerated]
	[Token(Token = "0x4000010")]
	[FieldOffset(Offset = "0x18")]
	private PropertyChangedEventHandler InterfacePropertyChangedEventHandler;

	[Token(Token = "0x1700000D")]
	public static SROptions Current
	{
		[Token(Token = "0x600002A")]
		[Address(RVA = "0x3C61470", Offset = "0x3C61470", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40._current;\n")]
		get
		{
			return _current;
		}
	}

	[Token(Token = "0x14000001")]
	public event SROptionsPropertyChanged PropertyChanged
	{
		[CompilerGenerated]
		[Token(Token = "0x600002C")]
		[Address(RVA = "0x3C615D0", Offset = "0x3C615D0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.PropertyChanged (SROptionsPropertyChanged), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == SROptionsPropertyChanged;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.PropertyChanged;\n\tgoto L_002C;\n")]
		add
		{
			SROptionsPropertyChanged sROptionsPropertyChanged = _003CPropertyChanged_003Ek__BackingField;
			SROptionsPropertyChanged sROptionsPropertyChanged2;
			do
			{
				sROptionsPropertyChanged2 = sROptionsPropertyChanged;
				SROptionsPropertyChanged value2 = (SROptionsPropertyChanged)Delegate.Combine(sROptionsPropertyChanged2, value);
				sROptionsPropertyChanged = Interlocked.CompareExchange(ref _003CPropertyChanged_003Ek__BackingField, value2, sROptionsPropertyChanged2);
			}
			while ((object)sROptionsPropertyChanged != sROptionsPropertyChanged2);
		}
		[CompilerGenerated]
		[Token(Token = "0x600002D")]
		[Address(RVA = "0x3C61674", Offset = "0x3C61674", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.PropertyChanged (SROptionsPropertyChanged), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == SROptionsPropertyChanged;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.PropertyChanged;\n\tgoto L_002C;\n")]
		remove
		{
			SROptionsPropertyChanged sROptionsPropertyChanged = _003CPropertyChanged_003Ek__BackingField;
			SROptionsPropertyChanged sROptionsPropertyChanged2;
			do
			{
				sROptionsPropertyChanged2 = sROptionsPropertyChanged;
				SROptionsPropertyChanged value2 = (SROptionsPropertyChanged)Delegate.Remove(sROptionsPropertyChanged2, value);
				sROptionsPropertyChanged = Interlocked.CompareExchange(ref _003CPropertyChanged_003Ek__BackingField, value2, sROptionsPropertyChanged2);
			}
			while ((object)sROptionsPropertyChanged != sROptionsPropertyChanged2);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	[Token(Token = "0x600002B")]
	[Address(RVA = "0x3C614BC", Offset = "0x3C614BC", Length = "0x10C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_002E;\nL_002E:\n\tv92 = SRF.Service.SRServiceManager::GetService();\n\tv69 = *([B193A90]) & 1;\n\tv70 = v69 == 0;\n\tif (v70) goto L_0053;\nL_0041:\n\tSRDebugger.Internal.InternalOptionsRegistry::AddOptionContainer(v92, v101._current);\n\treturn;\nL_0053:\n\t*([B193A90]) = 1;\n\tv116 = v92 == 0;\n\tv95 = ~v116;\n\tv92 = v92;\n\tif (v95) goto L_0041;\n\tthrow System.NullReferenceException;\nL_0020:\n\tv49 = new SROptions();\n\tSystem.Object::.ctor(v49);\n\tv58._current = v49;\n")]
	public static void OnStartup()
	{
		SROptions current = new SROptions();
		_current = current;
		InternalOptionsRegistry internalOptionsRegistry = SRServiceManager.GetService<InternalOptionsRegistry>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A90]");
		if ((int)((nint)0 & (nint)1) == 0)
		{
			_ = 1;
			bool flag = internalOptionsRegistry == null;
			bool flag2 = !flag;
			internalOptionsRegistry = internalOptionsRegistry;
			if (!flag2)
			{
				throw new NullReferenceException();
			}
		}
		internalOptionsRegistry.AddOptionContainer(_current);
	}

	[Token(Token = "0x600002E")]
	[Address(RVA = "0x3C61718", Offset = "0x3C61718", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tSROptionsPropertyChanged::Invoke(this.PropertyChanged, this, propertyName);\n\tv62 = new System.ComponentModel.PropertyChangedEventArgs();\n\tSystem.ComponentModel.PropertyChangedEventArgs::.ctor(v62, propertyName);\n\tSystem.ComponentModel.PropertyChangedEventHandler::Invoke(this.InterfacePropertyChangedEventHandler, this, v62);\n\treturn;\nL_003D:\n\treturn;\nL_0015:\n\t;\n\tv44 = this.PropertyChanged == 0;\n\tif (v44) goto L_001E;\nL_001E:\n\t;\n\tv58 = this.InterfacePropertyChangedEventHandler == 0;\n\tif (v58) goto L_003D;\n")]
	public void OnPropertyChanged(string propertyName)
	{
		if (_003CPropertyChanged_003Ek__BackingField != null)
		{
			_003CPropertyChanged_003Ek__BackingField(this, propertyName);
		}
		if (InterfacePropertyChangedEventHandler != null)
		{
			PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
			InterfacePropertyChangedEventHandler(this, e);
		}
	}

	[CompilerGenerated]
	[Token(Token = "0x600002F")]
	[Address(RVA = "0x3C617CC", Offset = "0x3C617CC", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.InterfacePropertyChangedEventHandler (System.ComponentModel.PropertyChangedEventHandler), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.ComponentModel.PropertyChangedEventHandler;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.InterfacePropertyChangedEventHandler;\n\tgoto L_002C;\n")]
	private void add_InterfacePropertyChangedEventHandler(PropertyChangedEventHandler value)
	{
		PropertyChangedEventHandler propertyChangedEventHandler = InterfacePropertyChangedEventHandler;
		PropertyChangedEventHandler propertyChangedEventHandler2;
		do
		{
			propertyChangedEventHandler2 = propertyChangedEventHandler;
			PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
			propertyChangedEventHandler = Interlocked.CompareExchange(ref InterfacePropertyChangedEventHandler, value2, propertyChangedEventHandler2);
		}
		while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
	}

	[CompilerGenerated]
	[Token(Token = "0x6000030")]
	[Address(RVA = "0x3C61870", Offset = "0x3C61870", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.InterfacePropertyChangedEventHandler (System.ComponentModel.PropertyChangedEventHandler), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.ComponentModel.PropertyChangedEventHandler;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.InterfacePropertyChangedEventHandler;\n\tgoto L_002C;\n")]
	private void remove_InterfacePropertyChangedEventHandler(PropertyChangedEventHandler value)
	{
		PropertyChangedEventHandler propertyChangedEventHandler = InterfacePropertyChangedEventHandler;
		PropertyChangedEventHandler propertyChangedEventHandler2;
		do
		{
			propertyChangedEventHandler2 = propertyChangedEventHandler;
			PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
			propertyChangedEventHandler = Interlocked.CompareExchange(ref InterfacePropertyChangedEventHandler, value2, propertyChangedEventHandler2);
		}
		while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
	}

	[Token(Token = "0x6000031")]
	[Address(RVA = "0x3C61914", Offset = "0x3C61914", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.InterfacePropertyChangedEventHandler (System.ComponentModel.PropertyChangedEventHandler), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.ComponentModel.PropertyChangedEventHandler;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.InterfacePropertyChangedEventHandler;\n\tgoto L_002C;\n")]
	event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
	{
		add { InterfacePropertyChangedEventHandler += value; }
		remove { InterfacePropertyChangedEventHandler -= value; }
	}

	[Token(Token = "0x6000033")]
	[Address(RVA = "0x3C615C8", Offset = "0x3C615C8", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
	public SROptions()
	{
	}
}
