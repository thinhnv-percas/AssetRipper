using ARMD;
using @as;
using DevXForms;
using DMP4;
using DSMCaps.PowerPc;
using DSMCaps.X86;
using DSMCaps.XCore;
using ICSharpCode.SharpZipLib.Zip;
using Org.Brotli.Dec;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using TrunkTracesConsole.Pages;
using Unreal;
using Wasm.Interpret;
using XmlBin;

namespace ICSharpCode.SharpZipLib.Tar
{
	internal delegate void _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 archive, _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A entry, string message);
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 : IDisposable
	{
		[CompilerGenerated]
		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020 = string.Empty;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A = string.Empty;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A;

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020;

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020;

		public bool AsciiTranslate
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020;
			}
			set
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020 = value;
			}
		}

		public string PathPrefix
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020;
			}
			set
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020 = value;
			}
		}

		public string RootPath
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A;
			}
			set
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A = value.Replace('\\', '/').TrimEnd('/');
			}
		}

		public bool ApplyUserInfoOverrides
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A;
			}
			set
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A = value;
			}
		}

		public int UserId
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020;
			}
		}

		public string UserName
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020;
			}
		}

		public int GroupId
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A;
			}
		}

		public string GroupName
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A;
			}
		}

		public int RecordSize
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020 != null)
				{
					return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020.RecordSize;
				}
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A != null)
				{
					return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A.RecordSize;
				}
				return 10240;
			}
		}

		public bool IsStreamOwner
		{
			set
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020 != null)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020.IsStreamOwner = value;
				}
				else
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A.IsStreamOwner = value;
				}
			}
		}

		public event _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A ProgressMessageEvent
		{
			[CompilerGenerated]
			add
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020;
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2;
				do
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A;
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A value2 = (_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A)Delegate.Combine(_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2, value);
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A = Interlocked.CompareExchange(ref _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020, value2, _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2);
				}
				while ((object)_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A != _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2);
			}
			[CompilerGenerated]
			remove
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020;
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2;
				do
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A;
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A value2 = (_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A)Delegate.Remove(_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2, value);
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A = Interlocked.CompareExchange(ref _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020, value2, _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2);
				}
				while ((object)_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A != _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A2);
			}
		}

		internal virtual void OnProgressMessageEvent(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A entry, string message)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020?.Invoke(this, entry, message);
		}

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020()
		{
		}

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020 = stream;
		}

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A = stream;
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 CreateInputTarArchive(Stream inputStream)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 = inputStream as _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020;
			if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 != null)
			{
				return new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020);
			}
			return CreateInputTarArchive(inputStream, 20);
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 CreateInputTarArchive(Stream inputStream, int blockFactor)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (inputStream is _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020)
			{
				throw new ArgumentException("TarInputStream not valid");
			}
			return new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020(inputStream, blockFactor));
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 CreateOutputTarArchive(Stream outputStream)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A = outputStream as _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A;
			if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A != null)
			{
				return new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A);
			}
			return CreateOutputTarArchive(outputStream, 20);
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 CreateOutputTarArchive(Stream outputStream, int blockFactor)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (outputStream is _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A)
			{
				throw new ArgumentException("TarOutputStream is not valid");
			}
			return new _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(outputStream, blockFactor));
		}

		public void SetKeepOldFiles(bool keepExistingFiles)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A = keepExistingFiles;
		}

		[Obsolete("Use the AsciiTranslate property")]
		public void SetAsciiTranslation(bool translateAsciiFiles)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020 = translateAsciiFiles;
		}

		public void SetUserInfo(int userId, string userName, int groupId, string groupName)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020 = userId;
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020 = userName;
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A = groupId;
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A = groupName;
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A = true;
		}

		[Obsolete("Use Close instead")]
		public void CloseArchive()
		{
			Close();
		}

		public void ListContents()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			while (true)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A nextEntry = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020.GetNextEntry();
				if (nextEntry != null)
				{
					OnProgressMessageEvent(nextEntry, null);
					continue;
				}
				break;
			}
		}

		public void ExtractContents(string destinationDirectory)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			while (true)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A nextEntry = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020.GetNextEntry();
				if (nextEntry != null)
				{
					if (nextEntry.TarHeader.TypeFlag != 49 && nextEntry.TarHeader.TypeFlag != 50)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(destinationDirectory, nextEntry);
					}
					continue;
				}
				break;
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(string _0020, _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A _0020_000A)
		{
			OnProgressMessageEvent(_0020_000A, null);
			string text = _0020_000A.Name;
			if (Path.IsPathRooted(text))
			{
				text = text.Substring(Path.GetPathRoot(text).Length);
			}
			text = text.Replace('/', Path.DirectorySeparatorChar);
			string text2 = Path.Combine(_0020, text);
			if (_0020_000A.IsDirectory)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(text2);
				return;
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(Path.GetDirectoryName(text2));
			bool flag = true;
			FileInfo fileInfo = new FileInfo(text2);
			if (fileInfo.Exists)
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A)
				{
					OnProgressMessageEvent(_0020_000A, "Destination file already exists");
					flag = false;
				}
				else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != 0)
				{
					OnProgressMessageEvent(_0020_000A, "Destination file already exists, and is read-only");
					flag = false;
				}
			}
			if (!flag)
			{
				return;
			}
			bool flag2 = false;
			Stream stream = File.Create(text2);
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020)
			{
				flag2 = !_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020(text2);
			}
			StreamWriter streamWriter = null;
			if (flag2)
			{
				streamWriter = new StreamWriter(stream);
			}
			byte[] array = new byte[32768];
			while (true)
			{
				int num = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				if (flag2)
				{
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						if (array[i] == 10)
						{
							string @string = Encoding.ASCII.GetString(array, num2, i - num2);
							streamWriter.WriteLine(@string);
							num2 = i + 1;
						}
					}
				}
				else
				{
					stream.Write(array, 0, num);
				}
			}
			if (flag2)
			{
				streamWriter.Close();
			}
			else
			{
				stream.Close();
			}
		}

		public void WriteEntry(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A sourceEntry, bool recurse)
		{
			if (sourceEntry == null)
			{
				throw new ArgumentNullException("sourceEntry");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			try
			{
				if (recurse)
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A(sourceEntry.UserId, sourceEntry.UserName, sourceEntry.GroupId, sourceEntry.GroupName);
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(sourceEntry, recurse);
			}
			finally
			{
				if (recurse)
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020();
				}
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A _0020, bool _0020_000A)
		{
			string text = null;
			string text2 = _0020.File;
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A = (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A)_0020.Clone();
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.GroupId = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A;
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.GroupName = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A;
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.UserId = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020;
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.UserName = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020;
			}
			OnProgressMessageEvent(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A, null);
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020 && !_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.IsDirectory && !_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020(text2))
			{
				text = TempManager.MakeTempFileName();
				using (StreamReader streamReader = File.OpenText(text2))
				{
					using (Stream stream = File.Create(text))
					{
						while (true)
						{
							string text3 = streamReader.ReadLine();
							if (text3 == null)
							{
								break;
							}
							byte[] bytes = Encoding.ASCII.GetBytes(text3);
							stream.Write(bytes, 0, bytes.Length);
							stream.WriteByte(10);
						}
						stream.Flush();
					}
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.Size = new FileInfo(text).Length;
				text2 = text;
			}
			string text4 = null;
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A != null && (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.Name.StartsWith(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, StringComparison.OrdinalIgnoreCase) || _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.Name.Replace("\\", "/").StartsWith(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, StringComparison.OrdinalIgnoreCase)))
			{
				text4 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.Name.Replace("\\", "/").Substring(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A.Length + 1);
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020 != null)
			{
				text4 = ((text4 == null) ? (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020 + "/" + _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.Name) : (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020 + "/" + text4));
			}
			if (text4 != null)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.Name = text4;
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A.PutNextEntry(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A);
			if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.IsDirectory)
			{
				if (_0020_000A)
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A[] directoryEntries = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.GetDirectoryEntries(this);
					for (int i = 0; i < directoryEntries.Length; i++)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(directoryEntries[i], _0020_000A);
					}
				}
			}
			else
			{
				using (Stream stream2 = File.OpenRead(text2))
				{
					byte[] array = new byte[32768];
					while (true)
					{
						int num = stream2.Read(array, 0, array.Length);
						if (num <= 0)
						{
							break;
						}
						_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A.Write(array, 0, num);
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					File.Delete(text);
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A.CloseEntry();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		internal virtual void Dispose(bool disposing)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020)
			{
				return;
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020 = true;
			if (disposing)
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A != null)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A.Flush();
					_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A.Close();
				}
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020 != null)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020.Close();
				}
			}
		}

		public virtual void Close()
		{
			Dispose(disposing: true);
		}

		~_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020()
		{
			Dispose(disposing: false);
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(string _0020)
		{
			if (!Directory.Exists(_0020))
			{
				try
				{
					Directory.CreateDirectory(_0020);
				}
				catch (Exception ex)
				{
					throw new TarException("Exception creating directory '" + _0020 + "', " + ex.Message, ex);
				}
			}
		}

		internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020(string _0020)
		{
			using (FileStream fileStream = File.OpenRead(_0020))
			{
				int num = Math.Min(4096, (int)fileStream.Length);
				byte[] array = new byte[num];
				int num2 = fileStream.Read(array, 0, num);
				for (int i = 0; i < num2; i++)
				{
					byte b = array[i];
					if (b < 8 || (b > 13 && b < 32) || b == byte.MaxValue)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020
	{
		public const int BlockSize = 512;

		public const int DefaultBlockFactor = 20;

		public const int DefaultRecordSize = 10240;

		internal Stream _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020;

		internal Stream _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;

		internal byte[] _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A = 10240;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020 = 20;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A = true;

		public int RecordSize => _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A;

		public int BlockFactor => _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020;

		public int CurrentBlock => _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A;

		public bool IsStreamOwner
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A = value;
			}
		}

		public int CurrentRecord => _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020;

		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A;
		}

		[Obsolete("Use BlockFactor property instead")]
		public int GetBlockFactor()
		{
			return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020;
		}

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020()
		{
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 CreateInputTarBuffer(Stream inputStream)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			return CreateInputTarBuffer(inputStream, 20);
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 CreateInputTarBuffer(Stream inputStream, int blockFactor)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (blockFactor <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020();
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020._0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 = inputStream;
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020._0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A = null;
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020(blockFactor);
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020;
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 CreateOutputTarBuffer(Stream outputStream)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			return CreateOutputTarBuffer(outputStream, 20);
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 CreateOutputTarBuffer(Stream outputStream, int blockFactor)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (blockFactor <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020();
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020._0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 = null;
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020._0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A = outputStream;
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020(blockFactor);
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020(int _0020)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020 = _0020;
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A = _0020 * 512;
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020 = new byte[RecordSize];
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 != null)
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020 = -1;
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A = BlockFactor;
			}
			else
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020 = 0;
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A = 0;
			}
		}

		[Obsolete("Use IsEndOfArchiveBlock instead")]
		public bool IsEOFBlock(byte[] block)
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}
			if (block.Length != 512)
			{
				throw new ArgumentException("block length is invalid");
			}
			for (int i = 0; i < 512; i++)
			{
				if (block[i] != 0)
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsEndOfArchiveBlock(byte[] block)
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}
			if (block.Length != 512)
			{
				throw new ArgumentException("block length is invalid");
			}
			for (int i = 0; i < 512; i++)
			{
				if (block[i] != 0)
				{
					return false;
				}
			}
			return true;
		}

		public void SkipBlock()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 == null)
			{
				throw new TarException("no input stream defined");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A >= BlockFactor && !_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A())
			{
				throw new TarException("Failed to read a record");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A++;
		}

		public byte[] ReadBlock()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 == null)
			{
				throw new TarException("TarBuffer.ReadBlock - no input stream defined");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A >= BlockFactor && !_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A())
			{
				throw new TarException("Failed to read a record");
			}
			byte[] array = new byte[512];
			Array.Copy(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020, _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A * 512, array, 0, 512);
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A++;
			return array;
		}

		internal bool _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 == null)
			{
				throw new TarException("no input stream stream defined");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A = 0;
			int num = 0;
			long num3;
			for (int num2 = RecordSize; num2 > 0; num2 -= (int)num3)
			{
				num3 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020.Read(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020, num, num2);
				if (num3 <= 0)
				{
					break;
				}
				num += (int)num3;
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020++;
			return true;
		}

		[Obsolete("Use CurrentBlock property instead")]
		public int GetCurrentBlockNum()
		{
			return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A;
		}

		[Obsolete("Use CurrentRecord property instead")]
		public int GetCurrentRecordNum()
		{
			return _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020;
		}

		public void WriteBlock(byte[] block)
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream defined");
			}
			if (block.Length != 512)
			{
				throw new TarException($"TarBuffer.WriteBlock - block to write has length '{block.Length}' which is not the block size of '{512}'");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A >= BlockFactor)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020();
			}
			Array.Copy(block, 0, _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020, _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A * 512, 512);
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A++;
		}

		public void WriteBlock(byte[] buffer, int offset)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream stream defined");
			}
			if (offset < 0 || offset >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (offset + 512 > buffer.Length)
			{
				throw new TarException($"TarBuffer.WriteBlock - record has length '{buffer.Length}' with offset '{offset}' which is less than the record size of '{_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A}'");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A >= BlockFactor)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020();
			}
			Array.Copy(buffer, offset, _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020, _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A * 512, 512);
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A++;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A == null)
			{
				throw new TarException("TarBuffer.WriteRecord no output stream defined");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A.Write(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020, 0, RecordSize);
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A.Flush();
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A = 0;
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020++;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A == null)
			{
				throw new TarException("TarBuffer.WriteFinalRecord no output stream defined");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A > 0)
			{
				int num = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A * 512;
				Array.Clear(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020, num, RecordSize - num);
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020();
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A.Flush();
		}

		public void Close()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A != null)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A();
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A.Close();
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A = null;
			}
			else if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 != null)
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020.Close();
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 = null;
			}
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A : ICloneable
	{
		internal string _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A;

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 TarHeader => _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A;

		public string Name
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.Name;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.Name = value;
			}
		}

		public int UserId
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.UserId;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.UserId = value;
			}
		}

		public int GroupId
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.GroupId;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.GroupId = value;
			}
		}

		public string UserName
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.UserName;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.UserName = value;
			}
		}

		public string GroupName
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.GroupName;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.GroupName = value;
			}
		}

		public DateTime ModTime
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.ModTime;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.ModTime = value;
			}
		}

		public string File => _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;

		public long Size
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.Size;
			}
			set
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.Size = value;
			}
		}

		public bool IsDirectory
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 != null)
				{
					return Directory.Exists(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020);
				}
				if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A != null && (_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.TypeFlag == 53 || Name.EndsWith("/", StringComparison.Ordinal)))
				{
					return true;
				}
				return false;
			}
		}

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A()
		{
			_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020();
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A(byte[] headerBuffer)
		{
			_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020();
			_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.ParseBuffer(headerBuffer);
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 header)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020)header.Clone();
		}

		public object Clone()
		{
			return new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020,
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020)_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.Clone(),
				Name = Name
			};
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateTarEntry(string name)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A();
			NameTarHeader(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A, name);
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A;
		}

		public static _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateEntryFromFile(string fileName, _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 tarArchive)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A();
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.GetFileTarHeader(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A, fileName, tarArchive);
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A;
		}

		public override bool Equals(object obj)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A = obj as _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A;
			if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A != null)
			{
				return Name.Equals(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.Name);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public bool IsDescendent(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A toTest)
		{
			if (toTest == null)
			{
				throw new ArgumentNullException("toTest");
			}
			return toTest.Name.StartsWith(Name, StringComparison.Ordinal);
		}

		public void SetIds(int userId, int groupId)
		{
			UserId = userId;
			GroupId = groupId;
		}

		public void SetNames(string userName, string groupName)
		{
			UserName = userName;
			GroupName = groupName;
		}

		public void GetFileTarHeader(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 header, string file, _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 tarArchive)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 = file;
			string text = file;
			if (tarArchive != null && tarArchive.RootPath != null && (text.StartsWith(tarArchive.RootPath, StringComparison.OrdinalIgnoreCase) || text.Replace("\\", "/").StartsWith(tarArchive.RootPath, StringComparison.OrdinalIgnoreCase) || text.Replace(Path.DirectorySeparatorChar, '/').StartsWith(tarArchive.RootPath, StringComparison.OrdinalIgnoreCase)))
			{
				text = text.Replace("\\", "/").Substring(tarArchive.RootPath.Length + 1);
			}
			if (text.IndexOf(Directory.GetCurrentDirectory(), StringComparison.Ordinal) == 0)
			{
				text = text.Substring(Directory.GetCurrentDirectory().Length);
			}
			text = text.Replace(Path.DirectorySeparatorChar, '/');
			while (text.StartsWith("/", StringComparison.Ordinal))
			{
				text = text.Substring(1);
			}
			header.LinkName = string.Empty;
			header.Name = text;
			if (Directory.Exists(file))
			{
				header.Mode = 1003;
				header.TypeFlag = 53;
				if (header.Name.Length == 0 || header.Name[header.Name.Length - 1] != '/')
				{
					header.Name += "/";
				}
				header.Size = 0L;
			}
			else
			{
				header.Mode = 33216;
				header.TypeFlag = 48;
				header.Size = new FileInfo(file.Replace('/', Path.DirectorySeparatorChar)).Length;
			}
			header.ModTime = System.IO.File.GetLastWriteTime(file.Replace('/', Path.DirectorySeparatorChar)).ToUniversalTime();
			header.DevMajor = 0;
			header.DevMinor = 0;
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A[] GetDirectoryEntries(_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 tarArchive)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 == null || !Directory.Exists(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020))
			{
				return new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A[0];
			}
			string[] fileSystemEntries = Directory.GetFileSystemEntries(_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020);
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A[] array = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A[fileSystemEntries.Length];
			for (int i = 0; i < fileSystemEntries.Length; i++)
			{
				array[i] = CreateEntryFromFile(fileSystemEntries[i], tarArchive);
			}
			return array;
		}

		public void WriteEntryHeader(byte[] outBuffer)
		{
			_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A.WriteHeader(outBuffer);
		}

		public static void AdjustEntryName(byte[] buffer, string newName)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.GetNameBytes(newName, buffer, 0, 100);
		}

		public static void NameTarHeader(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 header, string name)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			bool flag = name.EndsWith("/", StringComparison.Ordinal);
			header.Name = name;
			header.Mode = (flag ? 1003 : 33216);
			header.UserId = 0;
			header.GroupId = 0;
			header.Size = 0L;
			header.ModTime = DateTime.UtcNow;
			header.TypeFlag = (byte)(flag ? 53 : 48);
			header.LinkName = string.Empty;
			header.UserName = string.Empty;
			header.GroupName = string.Empty;
			header.DevMajor = 0;
			header.DevMinor = 0;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 : ICloneable
	{
		public const int NAMELEN = 100;

		public const int MODELEN = 8;

		public const int UIDLEN = 8;

		public const int GIDLEN = 8;

		public const int CHKSUMLEN = 8;

		public const int CHKSUMOFS = 148;

		public const int SIZELEN = 12;

		public const int MAGICLEN = 6;

		public const int VERSIONLEN = 2;

		public const int MODTIMELEN = 12;

		public const int UNAMELEN = 32;

		public const int GNAMELEN = 32;

		public const int DEVLEN = 8;

		public const int PREFIXLEN = 155;

		public const byte LF_OLDNORM = 0;

		public const byte LF_NORMAL = 48;

		public const byte LF_LINK = 49;

		public const byte LF_SYMLINK = 50;

		public const byte LF_CHR = 51;

		public const byte LF_BLK = 52;

		public const byte LF_DIR = 53;

		public const byte LF_FIFO = 54;

		public const byte LF_CONTIG = 55;

		public const byte LF_GHDR = 103;

		public const byte LF_XHDR = 120;

		public const byte LF_ACL = 65;

		public const byte LF_GNU_DUMPDIR = 68;

		public const byte LF_EXTATTR = 69;

		public const byte LF_META = 73;

		public const byte LF_GNU_LONGLINK = 75;

		public const byte LF_GNU_LONGNAME = 76;

		public const byte LF_GNU_MULTIVOL = 77;

		public const byte LF_GNU_NAMES = 78;

		public const byte LF_GNU_SPARSE = 83;

		public const byte LF_GNU_VOLHDR = 86;

		public const string TMAGIC = "ustar";

		public const string GNU_TMAGIC = "ustar  ";

		internal const long _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A = 10000000L;

		internal static readonly DateTime _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020 = new DateTime(1970, 1, 1, 0, 0, 0, 0);

		internal string _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A;

		internal long _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A;

		internal DateTime _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020;

		internal byte _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A;

		internal string _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020;

		internal string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A;

		internal static int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020;

		internal static int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A;

		internal static string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020;

		internal static string _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A = "None";

		internal static int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020;

		internal static int _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A;

		internal static string _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020 = "None";

		internal static string _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A;

		public string Name
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = value;
			}
		}

		public int Mode
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A = value;
			}
		}

		public int UserId
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020 = value;
			}
		}

		public int GroupId
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A = value;
			}
		}

		public long Size
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
				}
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A = value;
			}
		}

		public DateTime ModTime
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020;
			}
			set
			{
				if (value < _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020)
				{
					throw new ArgumentOutOfRangeException("value", "ModTime cannot be before Jan 1st 1970");
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020 = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
			}
		}

		public int Checksum => _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A;

		public bool IsChecksumValid => _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020;

		public byte TypeFlag
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A = value;
			}
		}

		public string LinkName
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 = value;
			}
		}

		public string Magic
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A = value;
			}
		}

		public string Version
		{
			get
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020 = value;
			}
		}

		public string UserName
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020;
			}
			set
			{
				if (value != null)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020 = value.Substring(0, Math.Min(32, value.Length));
					return;
				}
				string text = DevXSystemInfo.UserName;
				if (text.Length > 32)
				{
					text = text.Substring(0, 32);
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020 = text;
			}
		}

		public string GroupName
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A;
			}
			set
			{
				if (value == null)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A = "None";
				}
				else
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A = value;
				}
			}
		}

		public int DevMajor
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020 = value;
			}
		}

		public int DevMinor
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A;
			}
			set
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A = value;
			}
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020()
		{
			Magic = "ustar";
			Version = " ";
			Name = "";
			LinkName = "";
			UserId = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020;
			GroupId = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A;
			UserName = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A;
			GroupName = _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020;
			Size = 0L;
		}

		[Obsolete("Use the Name property instead", true)]
		public string GetName()
		{
			return _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public void ParseBuffer(byte[] header)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			int num = 0;
			_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = ParseName(header, num, 100).ToString();
			num += 100;
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A = (int)ParseOctal(header, num, 8);
			num += 8;
			UserId = (int)ParseOctal(header, num, 8);
			num += 8;
			GroupId = (int)ParseOctal(header, num, 8);
			num += 8;
			Size = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A(header, num, 12);
			num += 12;
			ModTime = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A(ParseOctal(header, num, 12));
			num += 12;
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A = (int)ParseOctal(header, num, 8);
			num += 8;
			TypeFlag = header[num++];
			LinkName = ParseName(header, num, 100).ToString();
			num += 100;
			Magic = ParseName(header, num, 6).ToString();
			num += 6;
			if (Magic == "ustar")
			{
				Version = ParseName(header, num, 2).ToString();
				num += 2;
				UserName = ParseName(header, num, 32).ToString();
				num += 32;
				GroupName = ParseName(header, num, 32).ToString();
				num += 32;
				DevMajor = (int)ParseOctal(header, num, 8);
				num += 8;
				DevMinor = (int)ParseOctal(header, num, 8);
				num += 8;
				string text = ParseName(header, num, 155).ToString();
				if (!string.IsNullOrEmpty(text))
				{
					Name = text + "/" + Name;
				}
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020 = (Checksum == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A(header));
		}

		public void WriteHeader(byte[] outBuffer)
		{
			if (outBuffer == null)
			{
				throw new ArgumentNullException("outBuffer");
			}
			int offset = 0;
			offset = GetNameBytes(Name, outBuffer, offset, 100);
			offset = GetOctalBytes(_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A, outBuffer, offset, 8);
			offset = GetOctalBytes(UserId, outBuffer, offset, 8);
			offset = GetOctalBytes(GroupId, outBuffer, offset, 8);
			offset = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(Size, outBuffer, offset, 12);
			offset = GetOctalBytes(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020(ModTime), outBuffer, offset, 12);
			int _0020_0020 = offset;
			for (int i = 0; i < 8; i++)
			{
				outBuffer[offset++] = 32;
			}
			outBuffer[offset++] = TypeFlag;
			offset = GetNameBytes(LinkName, outBuffer, offset, 100);
			offset = GetAsciiBytes(Magic, 0, outBuffer, offset, 6);
			offset = GetNameBytes(Version, outBuffer, offset, 2);
			offset = GetNameBytes(UserName, outBuffer, offset, 32);
			offset = GetNameBytes(GroupName, outBuffer, offset, 32);
			if (TypeFlag == 51 || TypeFlag == 52)
			{
				offset = GetOctalBytes(DevMajor, outBuffer, offset, 8);
				offset = GetOctalBytes(DevMinor, outBuffer, offset, 8);
			}
			while (offset < outBuffer.Length)
			{
				outBuffer[offset++] = 0;
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020(outBuffer);
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A(_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A, outBuffer, _0020_0020, 8);
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020 = true;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 = obj as _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020;
			if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 != null)
			{
				return _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 && _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020._0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A && UserId == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.UserId && GroupId == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.GroupId && Size == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.Size && ModTime == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.ModTime && Checksum == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.Checksum && TypeFlag == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag && LinkName == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.LinkName && Magic == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.Magic && Version == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.Version && UserName == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.UserName && GroupName == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.GroupName && DevMajor == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.DevMajor && DevMinor == _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.DevMinor;
			}
			return false;
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A(int _0020, string _0020_000A, int _0020_0020, string _0020_000A_000A)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020 = (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020 = _0020);
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A = (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020 = _0020_000A);
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A = (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A = _0020_0020);
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020 = (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A = _0020_000A_000A);
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020()
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020;
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020;
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A;
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020 = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A;
		}

		internal static long _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			if (_0020[_0020_000A] >= 128)
			{
				long num = 0L;
				for (int i = _0020_0020 - 8; i < _0020_0020; i++)
				{
					num = ((num << 8) | _0020[_0020_000A + i]);
				}
				return num;
			}
			return ParseOctal(_0020, _0020_000A, _0020_0020);
		}

		public static long ParseOctal(byte[] header, int offset, int length)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			long num = 0L;
			bool flag = true;
			int num2 = offset + length;
			for (int i = offset; i < num2 && header[i] != 0; i++)
			{
				if (header[i] == 32 || header[i] == 48)
				{
					if (flag)
					{
						continue;
					}
					if (header[i] == 32)
					{
						break;
					}
				}
				flag = false;
				num = (num << 3) + (header[i] - 48);
			}
			return num;
		}

		public static StringBuilder ParseName(byte[] header, int offset, int length)
		{
			if (header == null)
			{
				throw new ArgumentNullException("header");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be less than zero");
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Cannot be less than zero");
			}
			if (offset + length > header.Length)
			{
				throw new ArgumentException("Exceeds header size", "length");
			}
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = offset; i < offset + length && header[i] != 0; i++)
			{
				stringBuilder.Append((char)header[i]);
			}
			return stringBuilder;
		}

		public static int GetNameBytes(StringBuilder name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return GetNameBytes(name.ToString(), nameOffset, buffer, bufferOffset, length);
		}

		public static int GetNameBytes(string name, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int i;
			for (i = 0; i < length && nameOffset + i < name.Length; i++)
			{
				buffer[bufferOffset + i] = (byte)name[nameOffset + i];
			}
			for (; i < length; i++)
			{
				buffer[bufferOffset + i] = 0;
			}
			return bufferOffset + length;
		}

		public static int GetNameBytes(StringBuilder name, byte[] buffer, int offset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return GetNameBytes(name.ToString(), 0, buffer, offset, length);
		}

		public static int GetNameBytes(string name, byte[] buffer, int offset, int length)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return GetNameBytes(name, 0, buffer, offset, length);
		}

		public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length)
		{
			if (toAdd == null)
			{
				throw new ArgumentNullException("toAdd");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int i;
			for (i = 0; i < length && nameOffset + i < toAdd.Length; i++)
			{
				buffer[bufferOffset + i] = (byte)toAdd[nameOffset + i];
			}
			for (; i < length; i++)
			{
				buffer[bufferOffset + i] = 0;
			}
			return bufferOffset + length;
		}

		public static int GetOctalBytes(long value, byte[] buffer, int offset, int length)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = length - 1;
			buffer[offset + num] = 0;
			num--;
			if (value > 0)
			{
				long num2 = value;
				while (num >= 0 && num2 > 0)
				{
					buffer[offset + num] = (byte)(48 + (byte)(num2 & 7));
					num2 >>= 3;
					num--;
				}
			}
			while (num >= 0)
			{
				buffer[offset + num] = 48;
				num--;
			}
			return offset + length;
		}

		internal static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(long _0020, byte[] _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			if (_0020 > 8589934591L)
			{
				for (int num = _0020_000A_000A - 1; num > 0; num--)
				{
					_0020_000A[_0020_0020 + num] = (byte)_0020;
					_0020 >>= 8;
				}
				_0020_000A[_0020_0020] = 128;
				return _0020_0020 + _0020_000A_000A;
			}
			return GetOctalBytes(_0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal static void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A(long _0020, byte[] _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			GetOctalBytes(_0020, _0020_000A, _0020_0020, _0020_000A_000A - 1);
		}

		internal static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020(byte[] _0020)
		{
			int num = 0;
			for (int i = 0; i < _0020.Length; i++)
			{
				num += _0020[i];
			}
			return num;
		}

		internal static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A(byte[] _0020)
		{
			int num = 0;
			for (int i = 0; i < 148; i++)
			{
				num += _0020[i];
			}
			for (int j = 0; j < 8; j++)
			{
				num += 32;
			}
			for (int k = 156; k < _0020.Length; k++)
			{
				num += _0020[k];
			}
			return num;
		}

		internal static int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020(DateTime _0020)
		{
			return (int)((_0020.Ticks - _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020.Ticks) / 10000000);
		}

		internal static DateTime _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A(long _0020)
		{
			try
			{
				return new DateTime(_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020.Ticks + _0020 * 10000000);
			}
			catch (ArgumentOutOfRangeException)
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020;
			}
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020 : Stream
	{
		internal interface IEntryFactory
		{
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateEntry(string name);

			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateEntryFromFile(string fileName, _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 tarArchive);

			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateEntry(byte[] headerBuffer);
		}

		internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 : IEntryFactory
		{
			public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateEntry(string name)
			{
				return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.CreateTarEntry(name);
			}

			public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateEntryFromFile(string fileName, _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020 tarArchive)
			{
				return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A.CreateEntryFromFile(fileName, tarArchive);
			}

			public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A CreateEntry(byte[] headerBuffer)
			{
				return new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A(headerBuffer);
			}
		}

		internal bool hasHitEOF;

		internal long entrySize;

		internal long entryOffset;

		internal byte[] readBuffer;

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 tarBuffer;

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A;

		internal IEntryFactory entryFactory;

		internal readonly Stream _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020;

		public bool IsStreamOwner
		{
			get
			{
				return tarBuffer.IsStreamOwner;
			}
			set
			{
				tarBuffer.IsStreamOwner = value;
			}
		}

		public override bool CanRead => _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020.CanRead;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020.Length;

		public override long Position
		{
			get
			{
				return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020.Position;
			}
			set
			{
				throw new NotSupportedException("TarInputStream Seek not supported");
			}
		}

		public int RecordSize => tarBuffer.RecordSize;

		public long Available => entrySize - entryOffset;

		public bool IsMarkSupported => false;

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020(Stream inputStream)
			: this(inputStream, 20)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020(Stream inputStream, int blockFactor)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 = inputStream;
			tarBuffer = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020.CreateInputTarBuffer(inputStream, blockFactor);
		}

		public override void Flush()
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("TarInputStream Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("TarInputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("TarInputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("TarInputStream WriteByte not supported");
		}

		public override int ReadByte()
		{
			byte[] array = new byte[1];
			if (Read(array, 0, 1) <= 0)
			{
				return -1;
			}
			return array[0];
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = 0;
			if (entryOffset >= entrySize)
			{
				return 0;
			}
			long num2 = count;
			if (num2 + entryOffset > entrySize)
			{
				num2 = entrySize - entryOffset;
			}
			if (readBuffer != null)
			{
				int num3 = (int)((num2 > readBuffer.Length) ? readBuffer.Length : num2);
				Array.Copy(readBuffer, 0, buffer, offset, num3);
				if (num3 >= readBuffer.Length)
				{
					readBuffer = null;
				}
				else
				{
					int num4 = readBuffer.Length - num3;
					byte[] destinationArray = new byte[num4];
					Array.Copy(readBuffer, num3, destinationArray, 0, num4);
					readBuffer = destinationArray;
				}
				num += num3;
				num2 -= num3;
				offset += num3;
			}
			while (num2 > 0)
			{
				byte[] array = tarBuffer.ReadBlock();
				if (array == null)
				{
					throw new TarException("unexpected EOF with " + num2 + " bytes unread");
				}
				int num5 = (int)num2;
				int num6 = array.Length;
				if (num6 > num5)
				{
					Array.Copy(array, 0, buffer, offset, num5);
					readBuffer = new byte[num6 - num5];
					Array.Copy(array, num5, readBuffer, 0, num6 - num5);
				}
				else
				{
					num5 = num6;
					Array.Copy(array, 0, buffer, offset, num6);
				}
				num += num5;
				num2 -= num5;
				offset += num5;
			}
			entryOffset += num;
			return num;
		}

		public override void Close()
		{
			tarBuffer.Close();
		}

		public void SetEntryFactory(IEntryFactory factory)
		{
			entryFactory = factory;
		}

		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return tarBuffer.RecordSize;
		}

		public void Skip(long skipCount)
		{
			byte[] array = new byte[8192];
			long num = skipCount;
			while (num > 0)
			{
				int count = (int)((num > array.Length) ? array.Length : num);
				int num2 = Read(array, 0, count);
				if (num2 != -1)
				{
					num -= num2;
					continue;
				}
				break;
			}
		}

		public void Mark(int markLimit)
		{
		}

		public void Reset()
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A GetNextEntry()
		{
			if (hasHitEOF)
			{
				return null;
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A != null)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A();
			}
			byte[] array = tarBuffer.ReadBlock();
			if (array == null)
			{
				hasHitEOF = true;
			}
			else
			{
				hasHitEOF |= _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020.IsEndOfArchiveBlock(array);
			}
			if (hasHitEOF)
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A = null;
			}
			else
			{
				try
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020();
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.ParseBuffer(array);
					if (!_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.IsChecksumValid)
					{
						throw new TarException("Header checksum is invalid");
					}
					entryOffset = 0L;
					entrySize = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.Size;
					StringBuilder stringBuilder = null;
					if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag == 76)
					{
						byte[] array2 = new byte[512];
						long num = entrySize;
						stringBuilder = new StringBuilder();
						while (num > 0)
						{
							int num2 = Read(array2, 0, (int)((num > array2.Length) ? array2.Length : num));
							if (num2 == -1)
							{
								throw new InvalidHeaderException("Failed to read long name entry");
							}
							stringBuilder.Append(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.ParseName(array2, 0, num2).ToString());
							num -= num2;
						}
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A();
						array = tarBuffer.ReadBlock();
					}
					else if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag == 103)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A();
						array = tarBuffer.ReadBlock();
					}
					else if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag == 120)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A();
						array = tarBuffer.ReadBlock();
					}
					else if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag == 86)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A();
						array = tarBuffer.ReadBlock();
					}
					else if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag != 48 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag != 0 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag != 49 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag != 50 && _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.TypeFlag != 53)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A();
						array = tarBuffer.ReadBlock();
					}
					if (entryFactory == null)
					{
						_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A(array);
						if (stringBuilder != null)
						{
							_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A.Name = stringBuilder.ToString();
						}
					}
					else
					{
						_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A = entryFactory.CreateEntry(array);
					}
					entryOffset = 0L;
					entrySize = _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A.Size;
				}
				catch (InvalidHeaderException ex)
				{
					entrySize = 0L;
					entryOffset = 0L;
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A = null;
					throw new InvalidHeaderException($"Bad header in record {tarBuffer.CurrentRecord} block {tarBuffer.CurrentBlock} {ex.Message}");
				}
			}
			return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A;
		}

		public void CopyEntryContents(Stream outputStream)
		{
			byte[] array = new byte[32768];
			while (true)
			{
				int num = Read(array, 0, array.Length);
				if (num > 0)
				{
					outputStream.Write(array, 0, num);
					continue;
				}
				break;
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A()
		{
			long num = entrySize - entryOffset;
			if (num > 0)
			{
				Skip(num);
			}
			readBuffer = null;
		}
	}
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A : Stream
	{
		internal long _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020;

		internal int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A;

		internal bool _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020;

		internal long currSize;

		internal byte[] blockBuffer;

		internal byte[] assemblyBuffer;

		internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 buffer;

		internal Stream outputStream;

		public bool IsStreamOwner
		{
			get
			{
				return buffer.IsStreamOwner;
			}
			set
			{
				buffer.IsStreamOwner = value;
			}
		}

		public override bool CanRead => outputStream.CanRead;

		public override bool CanSeek => outputStream.CanSeek;

		public override bool CanWrite => outputStream.CanWrite;

		public override long Length => outputStream.Length;

		public override long Position
		{
			get
			{
				return outputStream.Position;
			}
			set
			{
				outputStream.Position = value;
			}
		}

		public int RecordSize => buffer.RecordSize;

		internal bool _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020 => _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 < currSize;

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(Stream outputStream)
			: this(outputStream, 20)
		{
		}

		public _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(Stream outputStream, int blockFactor)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			this.outputStream = outputStream;
			buffer = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020.CreateOutputTarBuffer(outputStream, blockFactor);
			assemblyBuffer = new byte[512];
			blockBuffer = new byte[512];
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return outputStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			outputStream.SetLength(value);
		}

		public override int ReadByte()
		{
			return outputStream.ReadByte();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return outputStream.Read(buffer, offset, count);
		}

		public override void Flush()
		{
			outputStream.Flush();
		}

		public void Finish()
		{
			if (_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020)
			{
				CloseEntry();
			}
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020();
		}

		public override void Close()
		{
			if (!_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020)
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 = true;
				Finish();
				buffer.Close();
			}
		}

		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return buffer.RecordSize;
		}

		public void PutNextEntry(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (entry.TarHeader.Name.Length > 100)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020 obj = new _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020
				{
					TypeFlag = 76
				};
				obj.Name += "././@LongLink";
				obj.Mode = 420;
				obj.UserId = entry.UserId;
				obj.GroupId = entry.GroupId;
				obj.GroupName = entry.GroupName;
				obj.UserName = entry.UserName;
				obj.LinkName = "";
				obj.Size = entry.TarHeader.Name.Length + 1;
				obj.WriteHeader(blockBuffer);
				buffer.WriteBlock(blockBuffer);
				int num = 0;
				while (num < entry.TarHeader.Name.Length + 1)
				{
					Array.Clear(blockBuffer, 0, blockBuffer.Length);
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020.GetAsciiBytes(entry.TarHeader.Name, num, blockBuffer, 0, 512);
					num += 512;
					buffer.WriteBlock(blockBuffer);
				}
			}
			entry.WriteEntryHeader(blockBuffer);
			buffer.WriteBlock(blockBuffer);
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 = 0L;
			currSize = (entry.IsDirectory ? 0 : entry.Size);
		}

		public void CloseEntry()
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A > 0)
			{
				Array.Clear(assemblyBuffer, _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A, assemblyBuffer.Length - _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A);
				buffer.WriteBlock(assemblyBuffer);
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 += _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A;
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A = 0;
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 < currSize)
			{
				throw new TarException($"Entry closed at '{_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020}' before the '{currSize}' bytes specified in the header were written");
			}
		}

		public override void WriteByte(byte value)
		{
			Write(new byte[1]
			{
				value
			}, 0, 1);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("offset and count combination is invalid");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 + count > currSize)
			{
				string message = $"request to write '{count}' bytes exceeds size in header of '{currSize}' bytes";
				throw new ArgumentOutOfRangeException("count", message);
			}
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A > 0)
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A + count >= blockBuffer.Length)
				{
					int num = blockBuffer.Length - _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A;
					Array.Copy(assemblyBuffer, 0, blockBuffer, 0, _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A);
					Array.Copy(buffer, offset, blockBuffer, _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A, num);
					this.buffer.WriteBlock(blockBuffer);
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 += blockBuffer.Length;
					offset += num;
					count -= num;
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A = 0;
				}
				else
				{
					Array.Copy(buffer, offset, assemblyBuffer, _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A, count);
					offset += count;
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A += count;
					count -= count;
				}
			}
			while (true)
			{
				if (count > 0)
				{
					if (count < blockBuffer.Length)
					{
						break;
					}
					this.buffer.WriteBlock(buffer, offset);
					int num2 = blockBuffer.Length;
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 += num2;
					count -= num2;
					offset += num2;
					continue;
				}
				return;
			}
			Array.Copy(buffer, offset, assemblyBuffer, _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A, count);
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A += count;
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020()
		{
			Array.Clear(blockBuffer, 0, blockBuffer.Length);
			buffer.WriteBlock(blockBuffer);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020(bool _0020, _0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020 _0020_000A, object _0020_0020, string _0020_000A_000A)
		{
			((_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020)null)._0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020((string)null);
			((_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A)null)._0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020((_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A)null, (string)null);
			return "26225493";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020()
		{
			int num = ((_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A)null)._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020;
			((ImagesViewControl)null)._0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020();
			((_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A)null)._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A((Stream)null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020(_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020 _0020, Config _0020_000A, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A _0020_0020)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020(string _0020, object _0020_000A)
		{
			MainForm._0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A((object)null);
			return 2101067173;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020()
		{
			byte[] array = ((_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A)null)._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020;
			int bufferSize = ((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A)null).BufferSize;
			PowerPcBranchCode branchCode = ((PowerPcInstructionDetail)null).BranchCode;
			OperatorImpls._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A((InterpreterContext)null);
			return "688651475";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020(TreeNode _0020, int _0020_000A, bool _0020_0020, int _0020_000A_000A, bool _0020_000A_0020, bool _0020_0020_000A)
		{
			((TreeNode)null).SetData((object[])null);
		}
	}
}
