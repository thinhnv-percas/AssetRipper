using System;
using System.ComponentModel;

namespace dnSpy.Contracts.MVVM;

public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
{
	string IDataErrorInfo.Error
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	string IDataErrorInfo.this[string columnName] => Verify(columnName);

	public virtual bool HasError => false;

	public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged(string propName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
	}

	protected void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		PropertyChanged?.Invoke(this, e);
	}

	protected virtual string Verify(string columnName)
	{
		return string.Empty;
	}

	protected void HasErrorUpdated()
	{
		OnPropertyChanged("HasError");
	}
}
