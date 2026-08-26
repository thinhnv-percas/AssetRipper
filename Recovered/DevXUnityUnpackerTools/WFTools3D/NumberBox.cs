using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WFTools3D
{
	public class NumberBox : Grid
	{
		public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(double), typeof(NumberBox), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020));

		internal TextBlock _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A;

		internal TextBox _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020;

		internal ScrollBar _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A;

		internal string _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal EventHandler _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A;

		public double Number
		{
			get
			{
				return (double)GetValue(NumberProperty);
			}
			set
			{
				SetValue(NumberProperty, value);
			}
		}

		public double SmallChange
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.SmallChange;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.SmallChange = value;
			}
		}

		public double LargeChange
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.LargeChange;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.LargeChange = value;
			}
		}

		public double Minimum
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Minimum;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Minimum != value)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Minimum = value;
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A();
				}
			}
		}

		public double Maximum
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Maximum;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Maximum != value)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Maximum = value;
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A();
				}
			}
		}

		public string FormatString
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020 != value)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020 = value;
					_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A();
				}
			}
		}

		public string Label
		{
			get
			{
				return _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A.Text;
			}
			set
			{
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A.Text = value;
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A.Margin = (string.IsNullOrEmpty(value) ? new Thickness(0.0) : new Thickness(5.0, 0.0, 5.0, 0.0));
			}
		}

		public double TBMinWidth
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020.MinWidth;
			}
			set
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020.MinWidth = value;
			}
		}

		public event EventHandler NumberChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal static void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020(DependencyObject _0020, DependencyPropertyChangedEventArgs _0020_000A)
		{
			(_0020 as NumberBox)?._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A();
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A()
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020.Text = Number.ToString(FormatString);
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Value = _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A(Number);
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A != null)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A(this, null);
			}
		}

		internal static object _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020(DependencyObject _0020, object _0020_000A)
		{
			NumberBox numberBox = (NumberBox)_0020;
			return MathUtils.Clamp((double)_0020_000A, numberBox.Minimum, numberBox.Maximum);
		}

		public NumberBox()
		{
			Initialize();
		}

		internal virtual void Initialize()
		{
			base.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = GridLength.Auto
			});
			base.ColumnDefinitions.Add(new ColumnDefinition());
			base.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = GridLength.Auto
			});
			_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A = new TextBlock();
			_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetColumn(_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A, 0);
			base.Children.Add(_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A);
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020 = new TextBox();
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020.TextChanged += _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A;
			Grid.SetColumn(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020, 1);
			base.Children.Add(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020);
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A = new ScrollBar();
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Focusable = true;
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.ContextMenu = null;
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Scroll += _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020;
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Margin = new Thickness(0.0, 1.0, 0.0, 0.0);
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.MouseRightButtonDown += _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A;
			Grid.SetColumn(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A, 2);
			base.Children.Add(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A);
			FormatString = "F0";
			Minimum = 0.0;
			Maximum = 100.0;
			SmallChange = 1.0;
			LargeChange = 10.0;
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A(object _0020, TextChangedEventArgs _0020_000A)
		{
			if (double.TryParse(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020.Text, out double result))
			{
				Number = result;
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020(object _0020, ScrollEventArgs _0020_000A)
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Focus();
			Number = _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.Value);
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A(object _0020, MouseButtonEventArgs _0020_000A)
		{
			if (_0020_000A.GetPosition(_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A).Y > _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.ActualHeight * 0.5)
			{
				Number -= _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.LargeChange;
			}
			else
			{
				Number += _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.LargeChange;
			}
		}

		internal double _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A(double _0020)
		{
			return Maximum + Minimum - _0020;
		}
	}
}
