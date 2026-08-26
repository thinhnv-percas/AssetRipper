using System;
using System.Threading;
using dnSpy.Contracts.MVVM;

namespace dnSpy.Decompiler.ILSpy.Core.Settings;

internal class ILSettings : ViewModelBase
{
	private volatile int settingsVersion;

	private bool showILComments;

	private bool showXmlDocumentation = true;

	private bool showTokenAndRvaComments = true;

	private bool showILBytes = true;

	private bool sortMembers;

	private bool showPdbInfo = true;

	public int SettingsVersion => settingsVersion;

	public bool ShowILComments
	{
		get
		{
			return showILComments;
		}
		set
		{
			if (showILComments != value)
			{
				showILComments = value;
				OnPropertyChanged("ShowILComments");
				OptionsChanged();
			}
		}
	}

	public bool ShowXmlDocumentation
	{
		get
		{
			return showXmlDocumentation;
		}
		set
		{
			if (showXmlDocumentation != value)
			{
				showXmlDocumentation = value;
				OnPropertyChanged("ShowXmlDocumentation");
				OptionsChanged();
			}
		}
	}

	public bool ShowTokenAndRvaComments
	{
		get
		{
			return showTokenAndRvaComments;
		}
		set
		{
			if (showTokenAndRvaComments != value)
			{
				showTokenAndRvaComments = value;
				OnPropertyChanged("ShowTokenAndRvaComments");
				OptionsChanged();
			}
		}
	}

	public bool ShowILBytes
	{
		get
		{
			return showILBytes;
		}
		set
		{
			if (showILBytes != value)
			{
				showILBytes = value;
				OnPropertyChanged("ShowILBytes");
				OptionsChanged();
			}
		}
	}

	public bool SortMembers
	{
		get
		{
			return sortMembers;
		}
		set
		{
			if (sortMembers != value)
			{
				sortMembers = value;
				OnPropertyChanged("SortMembers");
				OptionsChanged();
			}
		}
	}

	public bool ShowPdbInfo
	{
		get
		{
			return showPdbInfo;
		}
		set
		{
			if (showPdbInfo != value)
			{
				showPdbInfo = value;
				OnPropertyChanged("ShowPdbInfo");
				OptionsChanged();
			}
		}
	}

	public event EventHandler SettingsVersionChanged;

	protected virtual void OnModified()
	{
	}

	private void OptionsChanged()
	{
		Interlocked.Increment(ref settingsVersion);
		OnModified();
		SettingsVersionChanged?.Invoke(this, EventArgs.Empty);
	}

	public ILSettings Clone()
	{
		return CopyTo(new ILSettings());
	}

	public ILSettings CopyTo(ILSettings other)
	{
		other.ShowILComments = ShowILComments;
		other.ShowXmlDocumentation = ShowXmlDocumentation;
		other.ShowTokenAndRvaComments = ShowTokenAndRvaComments;
		other.ShowILBytes = ShowILBytes;
		other.SortMembers = SortMembers;
		other.ShowPdbInfo = ShowPdbInfo;
		return other;
	}

	public override bool Equals(object obj)
	{
		if (obj is ILSettings iLSettings && ShowILComments == iLSettings.ShowILComments && ShowXmlDocumentation == iLSettings.ShowXmlDocumentation && ShowTokenAndRvaComments == iLSettings.ShowTokenAndRvaComments && ShowILBytes == iLSettings.ShowILBytes && SortMembers == iLSettings.SortMembers)
		{
			return ShowPdbInfo == iLSettings.ShowPdbInfo;
		}
		return false;
	}

	public override int GetHashCode()
	{
		uint num = 0u;
		if (ShowILComments)
		{
			num ^= 0x80000000u;
		}
		if (ShowXmlDocumentation)
		{
			num ^= 0x40000000;
		}
		if (ShowTokenAndRvaComments)
		{
			num ^= 0x20000000;
		}
		if (ShowILBytes)
		{
			num ^= 0x10000000;
		}
		if (SortMembers)
		{
			num ^= 0x8000000;
		}
		if (ShowPdbInfo)
		{
			num ^= 0x4000000;
		}
		return (int)num;
	}
}
