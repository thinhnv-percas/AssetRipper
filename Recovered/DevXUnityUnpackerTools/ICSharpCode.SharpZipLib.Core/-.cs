using APK;
using @as;
using BrotliSharpLib;
using DevXForms;
using DevXUnityUnpackerTools._WinForm;
using DSMCaps;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Wasm.Interpret;

namespace ICSharpCode.SharpZipLib.Core
{
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A : EventArgs
	{
		internal string _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		internal bool _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = true;

		public string Name => _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		public bool ContinueRunning
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = value;
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A(string name)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 = name;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 : EventArgs
	{
		internal string _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		internal long _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020;

		internal long _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A;

		internal bool _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = true;

		public string Name => _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		public bool ContinueRunning
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = value;
			}
		}

		public float PercentComplete
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A <= 0)
				{
					return 0f;
				}
				return (float)_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020 / (float)_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A * 100f;
			}
		}

		public long Processed => _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020;

		public long Target => _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(string name, long processed, long target)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 = name;
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020 = processed;
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A = target;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A : _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A
	{
		internal readonly bool _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A;

		public bool HasMatchingFiles => _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A(string name, bool hasMatchingFiles)
			: base(name)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A = hasMatchingFiles;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 : EventArgs
	{
		internal string _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		internal Exception _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A;

		internal bool _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;

		public string Name => _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		public Exception Exception => _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A;

		public bool ContinueRunning
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = value;
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020(string name, Exception e)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 = name;
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A = e;
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = true;
		}
	}
	internal delegate void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A(object sender, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A e);
	internal delegate void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020(object sender, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 e);
	internal delegate void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A(object sender, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A e);
	internal delegate void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020(object sender, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 e);
	internal delegate void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(object sender, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 e);
	internal class _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020
	{
		[CompilerGenerated]
		internal EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A ProcessFile;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A CompletedFile;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020 DirectoryFailure;

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A FileFailure;

		internal IScanFilter _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A;

		internal IScanFilter _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020;

		internal bool _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A;

		public event EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> ProcessDirectory
		{
			[CompilerGenerated]
			add
			{
				EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> eventHandler = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020;
				EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> value2 = (EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> eventHandler = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020;
				EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> value2 = (EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(string filter)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(filter);
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(string fileFilter, string directoryFilter)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(fileFilter);
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020 = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(directoryFilter);
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(IScanFilter fileFilter)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A = fileFilter;
		}

		public _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(IScanFilter fileFilter, IScanFilter directoryFilter)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A = fileFilter;
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020 = directoryFilter;
		}

		internal bool _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(string _0020, Exception _0020_000A)
		{
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020 directoryFailure = DirectoryFailure;
			bool num = directoryFailure != null;
			if (num)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020(_0020, _0020_000A);
				directoryFailure(this, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020);
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020.ContinueRunning;
			}
			return num;
		}

		internal bool _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A(string _0020, Exception _0020_000A)
		{
			bool num = FileFailure != null;
			if (num)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020(_0020, _0020_000A);
				FileFailure(this, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020);
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020.ContinueRunning;
			}
			return num;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020(string _0020)
		{
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A processFile = ProcessFile;
			if (processFile != null)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A(_0020);
				processFile(this, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A);
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A.ContinueRunning;
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A(string _0020)
		{
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A completedFile = CompletedFile;
			if (completedFile != null)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A(_0020);
				completedFile(this, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A);
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A.ContinueRunning;
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020(string _0020, bool _0020_000A)
		{
			EventHandler<_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A> eventHandler = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020;
			if (eventHandler != null)
			{
				_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A(_0020, _0020_000A);
				eventHandler(this, _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A);
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A.ContinueRunning;
			}
		}

		public void Scan(string directory, bool recurse)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = true;
			_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A(directory, recurse);
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A(string _0020, bool _0020_000A)
		{
			try
			{
				string[] files = Directory.GetFiles(_0020);
				bool flag = false;
				for (int i = 0; i < files.Length; i++)
				{
					if (!_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A.IsMatch(files[i]))
					{
						files[i] = null;
					}
					else
					{
						flag = true;
					}
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020(_0020, flag);
				if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A && flag)
				{
					string[] array = files;
					foreach (string text in array)
					{
						try
						{
							if (text != null)
							{
								_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020(text);
								if (!_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A)
								{
									goto IL_0098;
								}
							}
						}
						catch (Exception _0020_000A2)
						{
							if (!_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A(text, _0020_000A2))
							{
								throw;
							}
						}
					}
				}
			}
			catch (Exception _0020_000A3)
			{
				if (!_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(_0020, _0020_000A3))
				{
					throw;
				}
			}
			goto IL_0098;
			IL_0098:
			if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A && _0020_000A)
			{
				try
				{
					string[] array = Directory.GetDirectories(_0020);
					foreach (string text2 in array)
					{
						if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020 == null || _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020.IsMatch(text2))
						{
							_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A(text2, _0020_000A: true);
							if (!_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A)
							{
								break;
							}
						}
					}
				}
				catch (Exception _0020_000A4)
				{
					if (!_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(_0020, _0020_000A4))
					{
						throw;
					}
				}
			}
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A : IScanFilter
	{
		internal string _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A;

		internal ArrayList _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020;

		internal ArrayList _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A;

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(string filter)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A = filter;
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = new ArrayList();
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A = new ArrayList();
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020();
		}

		public static bool IsValidExpression(string expression)
		{
			bool result = true;
			try
			{
				new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
				return result;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		public static bool IsValidFilterExpression(string toTest)
		{
			bool result = true;
			try
			{
				if (toTest == null)
				{
					return result;
				}
				string[] array = SplitQuoted(toTest);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null && array[i].Length > 0)
					{
						string pattern = (array[i][0] == '+') ? array[i].Substring(1, array[i].Length - 1) : ((array[i][0] != '-') ? array[i] : array[i].Substring(1, array[i].Length - 1));
						new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
					}
				}
				return result;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		public static string[] SplitQuoted(string original)
		{
			char c = '\\';
			char[] array = new char[1]
			{
				';'
			};
			ArrayList arrayList = new ArrayList();
			if (!string.IsNullOrEmpty(original))
			{
				int num = -1;
				StringBuilder stringBuilder = new StringBuilder();
				while (num < original.Length)
				{
					num++;
					if (num >= original.Length)
					{
						arrayList.Add(stringBuilder.ToString());
					}
					else if (original[num] == c)
					{
						num++;
						if (num >= original.Length)
						{
							throw new ArgumentException("Missing terminating escape character", "original");
						}
						if (Array.IndexOf(array, original[num]) < 0)
						{
							stringBuilder.Append(c);
						}
						stringBuilder.Append(original[num]);
					}
					else if (Array.IndexOf(array, original[num]) >= 0)
					{
						arrayList.Add(stringBuilder.ToString());
						stringBuilder.Length = 0;
					}
					else
					{
						stringBuilder.Append(original[num]);
					}
				}
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		public override string ToString()
		{
			return _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A;
		}

		public bool IsIncluded(string name)
		{
			bool result = false;
			if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020.Count == 0)
			{
				return true;
			}
			foreach (Regex item in _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020)
			{
				if (item.IsMatch(name))
				{
					return true;
				}
			}
			return result;
		}

		public bool IsExcluded(string name)
		{
			bool result = false;
			foreach (Regex item in _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A)
			{
				if (item.IsMatch(name))
				{
					return true;
				}
			}
			return result;
		}

		public bool IsMatch(string name)
		{
			if (IsIncluded(name))
			{
				return !IsExcluded(name);
			}
			return false;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020()
		{
			if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
			{
				return;
			}
			string[] array = SplitQuoted(_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && array[i].Length > 0)
				{
					bool num = array[i][0] != '-';
					string pattern = (array[i][0] == '+') ? array[i].Substring(1, array[i].Length - 1) : ((array[i][0] != '-') ? array[i] : array[i].Substring(1, array[i].Length - 1));
					if (num)
					{
						_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020.Add(new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
					else
					{
						_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A.Add(new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
				}
			}
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A : IScanFilter
	{
		internal readonly _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020;

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(string filter)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020 = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(filter);
		}

		public virtual bool IsMatch(string name)
		{
			bool result = false;
			if (name != null)
			{
				string name2 = (name.Length > 0) ? Path.GetFullPath(name) : "";
				result = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020.IsMatch(name2);
			}
			return result;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020 : _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A
	{
		internal long _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020;

		internal long _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A = long.MaxValue;

		internal DateTime _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020 = DateTime.MinValue;

		internal DateTime _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A = DateTime.MaxValue;

		public long MinSize
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020;
			}
			set
			{
				if (value < 0 || _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A < value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020 = value;
			}
		}

		public long MaxSize
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A;
			}
			set
			{
				if (value < 0 || _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020 > value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A = value;
			}
		}

		public DateTime MinDate
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020;
			}
			set
			{
				if (value > _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A)
				{
					throw new ArgumentOutOfRangeException("value", "Exceeds MaxDate");
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020 = value;
			}
		}

		public DateTime MaxDate
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A;
			}
			set
			{
				if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020 > value)
				{
					throw new ArgumentOutOfRangeException("value", "Exceeds MinDate");
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A = value;
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020(string filter, long minSize, long maxSize)
			: base(filter)
		{
			MinSize = minSize;
			MaxSize = maxSize;
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020(string filter, DateTime minDate, DateTime maxDate)
			: base(filter)
		{
			MinDate = minDate;
			MaxDate = maxDate;
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020(string filter, long minSize, long maxSize, DateTime minDate, DateTime maxDate)
			: base(filter)
		{
			MinSize = minSize;
			MaxSize = maxSize;
			MinDate = minDate;
			MaxDate = maxDate;
		}

		public override bool IsMatch(string name)
		{
			bool flag = base.IsMatch(name);
			if (flag)
			{
				FileInfo fileInfo = new FileInfo(name);
				flag = (MinSize <= fileInfo.Length && MaxSize >= fileInfo.Length && MinDate <= fileInfo.LastWriteTime && MaxDate >= fileInfo.LastWriteTime);
			}
			return flag;
		}
	}
	[Obsolete("Use ExtendedPathFilter instead")]
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A : _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A
	{
		internal long _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020;

		internal long _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A = long.MaxValue;

		public long MinSize
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020;
			}
			set
			{
				if (value < 0 || _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A < value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020 = value;
			}
		}

		public long MaxSize
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A;
			}
			set
			{
				if (value < 0 || _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020 > value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A = value;
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A(string filter, long minSize, long maxSize)
			: base(filter)
		{
			MinSize = minSize;
			MaxSize = maxSize;
		}

		public override bool IsMatch(string name)
		{
			bool flag = base.IsMatch(name);
			if (flag)
			{
				long length = new FileInfo(name).Length;
				flag = (MinSize <= length && MaxSize >= length);
			}
			return flag;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A
	{
		internal unsafe void _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020(decimal _0020, object _0020_000A, float _0020_0020)
		{
			((_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A)null)._0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020((_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020)null);
			PkzipClassic.GenerateKeys(null);
			VertexComponent target = ((_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A*)(byte*)null)->Target;
			FbxVersion fbxVersion = ((_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A)null)._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020()
		{
			ManyCodeCls manyCodeCl = ((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020;
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A();
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020()
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A.Create();
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020(decimal _0020, short _0020_000A, float _0020_0020)
		{
			CapstoneDisassembler<, , , , , , , >._003C_002Ector_003Eg__CreateNativeDisassembleMode_007C33_0(null);
			((ScriptGenerateOptions)null)._0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020((object)null, (EventArgs)null);
			((CodeWriter)null).WriteLine();
			return 1477378959;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A
	{
		internal unsafe string _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020(VerFormat _0020, VerFormat _0020_000A)
		{
			//IL_0024: Expected I, but got O
			//IL_0024: Expected I, but got O
			((MultiSelectTreeView2)null)._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A();
			Brotli._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A((Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020*)(long)(IntPtr)(void*)null, (Brotli._0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A*)(long)(IntPtr)(void*)null);
			bool canDecompress = ((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A)null).CanDecompress;
			return "1455195062";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020(string _0020)
		{
			((_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A)null)._0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020((_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020)null);
			OperatorImpls.Int64Load8S(null, null);
			((_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A)null)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A();
		}
	}
}
