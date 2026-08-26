using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DecompTools.Decompiler.IL;

public class ILAstWritingOptions : INotifyPropertyChanged
{
	private bool useLogicOperationSugar;

	private bool useFieldSugar;

	private bool showILRanges;

	private bool showChildIndexInBlock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PropertyChangedEventHandler m_PropertyChanged;

	public bool UseLogicOperationSugar
	{
		get
		{
			return useLogicOperationSugar;
		}
		set
		{
			if (useLogicOperationSugar != value)
			{
				useLogicOperationSugar = value;
				OnPropertyChanged("UseLogicOperationSugar");
			}
		}
	}

	public bool UseFieldSugar
	{
		get
		{
			return useFieldSugar;
		}
		set
		{
			if (useFieldSugar != value)
			{
				useFieldSugar = value;
				OnPropertyChanged("UseFieldSugar");
			}
		}
	}

	public bool ShowILRanges
	{
		get
		{
			return showILRanges;
		}
		set
		{
			if (showILRanges != value)
			{
				showILRanges = value;
				OnPropertyChanged("ShowILRanges");
			}
		}
	}

	public bool ShowChildIndexInBlock
	{
		get
		{
			return showChildIndexInBlock;
		}
		set
		{
			if (showChildIndexInBlock != value)
			{
				showChildIndexInBlock = value;
				OnPropertyChanged("ShowChildIndexInBlock");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			PropertyChangedEventHandler val = this.m_PropertyChanged;
			PropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove((Delegate?)(object)val2, (Delegate?)(object)value);
				val = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, val2);
			}
			while (val != val2);
		}
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
	}

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		PropertyChangedEventHandler obj = this.m_PropertyChanged;
		if (obj != null)
		{
			obj.Invoke((object)this, e);
		}
	}
}
