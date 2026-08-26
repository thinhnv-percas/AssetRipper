using @as;
using DSMCaps;
using ICSharpCode.SharpZipLib.Zip;
using SpirV;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Unity.IO.Compression;
using zlib;

namespace FMOD
{
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A
	{
		public const int number = 67350;

		public const string dll = "Library\\fmod_x64.dll";
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020
	{
		public const int MAX_CHANNEL_WIDTH = 32;

		public const int MAX_LISTENERS = 8;
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A
	{
		public static RESULT System_Create(out _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A system)
		{
			system = null;
			RESULT rESULT = RESULT.OK;
			IntPtr raw = default(IntPtr);
			rESULT = FMOD_System_Create(out raw);
			if (rESULT != 0)
			{
				return rESULT;
			}
			system = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A(raw);
			return rESULT;
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Create(out IntPtr _0020);
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020
	{
		public static RESULT Initialize(IntPtr poolmem, int poollen, MEMORY_ALLOC_CALLBACK useralloc, MEMORY_REALLOC_CALLBACK userrealloc, MEMORY_FREE_CALLBACK userfree, MEMORY_TYPE memtypeflags)
		{
			return FMOD_Memory_Initialize(poolmem, poollen, useralloc, userrealloc, userfree, memtypeflags);
		}

		public static RESULT GetStats(out int currentalloced, out int maxalloced)
		{
			return GetStats(out currentalloced, out maxalloced, blocking: false);
		}

		public static RESULT GetStats(out int currentalloced, out int maxalloced, bool blocking)
		{
			return FMOD_Memory_GetStats(out currentalloced, out maxalloced, blocking);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Memory_Initialize(IntPtr _0020, int _0020_000A, MEMORY_ALLOC_CALLBACK _0020_0020, MEMORY_REALLOC_CALLBACK _0020_000A_000A, MEMORY_FREE_CALLBACK _0020_000A_0020, MEMORY_TYPE _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Memory_GetStats(out int _0020, out int _0020_000A, bool _0020_0020);
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A
	{
		public static RESULT Initialize(DEBUG_FLAGS flags, DEBUG_MODE mode, DEBUG_CALLBACK callback, string filename)
		{
			return FMOD_Debug_Initialize(flags, mode, callback, filename);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Debug_Initialize(DEBUG_FLAGS _0020, DEBUG_MODE _0020_000A, DEBUG_CALLBACK _0020_0020, string _0020_000A_000A);
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		protected IntPtr rawPtr;

		public _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020(IntPtr newPtr)
		{
			rawPtr = newPtr;
		}

		public bool isValid()
		{
			return rawPtr != IntPtr.Zero;
		}

		public IntPtr getRaw()
		{
			return rawPtr;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020);
		}

		public bool Equals(_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 p)
		{
			if ((object)p != null)
			{
				return rawPtr == p.rawPtr;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return rawPtr.ToInt32();
		}

		public static bool operator ==(_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 a, _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 b)
		{
			if ((object)a == b)
			{
				return true;
			}
			if ((object)a == null || (object)b == null)
			{
				return false;
			}
			return a.rawPtr == b.rawPtr;
		}

		public static bool operator !=(_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 a, _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 b)
		{
			return !(a == b);
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		{
			RESULT num = FMOD_System_Release(rawPtr);
			if (num == RESULT.OK)
			{
				rawPtr = IntPtr.Zero;
			}
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020(OUTPUTTYPE _0020)
		{
			return FMOD_System_SetOutput(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020(out OUTPUTTYPE _0020)
		{
			return FMOD_System_GetOutput(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A(out int _0020)
		{
			return FMOD_System_GetNumDrivers(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020(int _0020, StringBuilder _0020_000A, int _0020_0020, out Guid _0020_000A_000A, out int _0020_000A_0020, out SPEAKERMODE _0020_0020_000A, out int _0020_0020_0020)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020_000A.Capacity);
			RESULT result = FMOD_System_GetDriverInfo(rawPtr, _0020, intPtr, _0020_0020, out _0020_000A_000A, out _0020_000A_0020, out _0020_0020_000A, out _0020_0020_0020);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020_000A, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A(int _0020)
		{
			return FMOD_System_SetDriver(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020(out int _0020)
		{
			return FMOD_System_GetDriver(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A(int _0020)
		{
			return FMOD_System_SetSoftwareChannels(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020(out int _0020)
		{
			return FMOD_System_GetSoftwareChannels(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A(int _0020, SPEAKERMODE _0020_000A, int _0020_0020)
		{
			return FMOD_System_SetSoftwareFormat(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020(out int _0020, out SPEAKERMODE _0020_000A, out int _0020_0020)
		{
			return FMOD_System_GetSoftwareFormat(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A(uint _0020, int _0020_000A)
		{
			return FMOD_System_SetDSPBufferSize(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020(out uint _0020, out int _0020_000A)
		{
			return FMOD_System_GetDSPBufferSize(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A(FILE_OPENCALLBACK _0020, FILE_CLOSECALLBACK _0020_000A, FILE_READCALLBACK _0020_0020, FILE_SEEKCALLBACK _0020_000A_000A, FILE_ASYNCREADCALLBACK _0020_000A_0020, FILE_ASYNCCANCELCALLBACK _0020_0020_000A, int _0020_0020_0020)
		{
			return FMOD_System_SetFileSystem(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020, _0020_0020_000A, _0020_0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020(FILE_OPENCALLBACK _0020, FILE_CLOSECALLBACK _0020_000A, FILE_READCALLBACK _0020_0020, FILE_SEEKCALLBACK _0020_000A_000A)
		{
			return FMOD_System_AttachFileSystem(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A(ref ADVANCEDSETTINGS _0020)
		{
			_0020.cbSize = Marshal.SizeOf((object)_0020);
			return FMOD_System_SetAdvancedSettings(rawPtr, ref _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020(ref ADVANCEDSETTINGS _0020)
		{
			_0020.cbSize = Marshal.SizeOf((object)_0020);
			return FMOD_System_GetAdvancedSettings(rawPtr, ref _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A(SYSTEM_CALLBACK _0020, SYSTEM_CALLBACK_TYPE _0020_000A)
		{
			return FMOD_System_SetCallback(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A(string _0020)
		{
			return FMOD_System_SetPluginPath(rawPtr, Encoding.UTF8.GetBytes(_0020 + "\0"));
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020(string _0020, out uint _0020_000A, uint _0020_0020)
		{
			return FMOD_System_LoadPlugin(rawPtr, Encoding.UTF8.GetBytes(_0020 + "\0"), out _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020(string _0020, out uint _0020_000A)
		{
			return _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020(_0020, out _0020_000A, 0u);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A(uint _0020)
		{
			return FMOD_System_UnloadPlugin(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020(PLUGINTYPE _0020, out int _0020_000A)
		{
			return FMOD_System_GetNumPlugins(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A(PLUGINTYPE _0020, int _0020_000A, out uint _0020_0020)
		{
			return FMOD_System_GetPluginHandle(rawPtr, _0020, _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020(uint _0020, out PLUGINTYPE _0020_000A, StringBuilder _0020_0020, int _0020_000A_000A, out uint _0020_000A_0020)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020_0020.Capacity);
			RESULT result = FMOD_System_GetPluginInfo(rawPtr, _0020, out _0020_000A, intPtr, _0020_000A_000A, out _0020_000A_0020);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020_0020, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A(uint _0020)
		{
			return FMOD_System_SetOutputByPlugin(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020(out uint _0020)
		{
			return FMOD_System_GetOutputByPlugin(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A(uint _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_System_CreateDSPByPlugin(rawPtr, _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020(uint _0020, out IntPtr _0020_000A)
		{
			return FMOD_System_GetDSPInfoByPlugin(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A(ref DSP_DESCRIPTION _0020, out uint _0020_000A)
		{
			return FMOD_System_RegisterDSP(rawPtr, ref _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020(int _0020, INITFLAGS _0020_000A, IntPtr _0020_0020)
		{
			return FMOD_System_Init(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A()
		{
			return FMOD_System_Close(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A()
		{
			return FMOD_System_Update(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020(SPEAKER _0020, float _0020_000A, float _0020_0020, bool _0020_000A_000A)
		{
			return FMOD_System_SetSpeakerPosition(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A(SPEAKER _0020, out float _0020_000A, out float _0020_0020, out bool _0020_000A_000A)
		{
			return FMOD_System_GetSpeakerPosition(rawPtr, _0020, out _0020_000A, out _0020_0020, out _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020(uint _0020, TIMEUNIT _0020_000A)
		{
			return FMOD_System_SetStreamBufferSize(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A(out uint _0020, out TIMEUNIT _0020_000A)
		{
			return FMOD_System_GetStreamBufferSize(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020(float _0020, float _0020_000A, float _0020_0020)
		{
			return FMOD_System_Set3DSettings(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A(out float _0020, out float _0020_000A, out float _0020_0020)
		{
			return FMOD_System_Get3DSettings(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020(int _0020)
		{
			return FMOD_System_Set3DNumListeners(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A(out int _0020)
		{
			return FMOD_System_Get3DNumListeners(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020(int _0020, ref VECTOR _0020_000A, ref VECTOR _0020_0020, ref VECTOR _0020_000A_000A, ref VECTOR _0020_000A_0020)
		{
			return FMOD_System_Set3DListenerAttributes(rawPtr, _0020, ref _0020_000A, ref _0020_0020, ref _0020_000A_000A, ref _0020_000A_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A(int _0020, out VECTOR _0020_000A, out VECTOR _0020_0020, out VECTOR _0020_000A_000A, out VECTOR _0020_000A_0020)
		{
			return FMOD_System_Get3DListenerAttributes(rawPtr, _0020, out _0020_000A, out _0020_0020, out _0020_000A_000A, out _0020_000A_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020(CB_3D_ROLLOFFCALLBACK _0020)
		{
			return FMOD_System_Set3DRolloffCallback(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A()
		{
			return FMOD_System_MixerSuspend(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020()
		{
			return FMOD_System_MixerResume(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A(SPEAKERMODE _0020, SPEAKERMODE _0020_000A, float[] _0020_0020, int _0020_000A_000A)
		{
			return FMOD_System_GetDefaultMixMatrix(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020(SPEAKERMODE _0020, out int _0020_000A)
		{
			return FMOD_System_GetSpeakerModeChannels(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A(out uint _0020)
		{
			return FMOD_System_GetVersion(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020(out IntPtr _0020)
		{
			return FMOD_System_GetOutputHandle(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A(out int _0020)
		{
			return FMOD_System_GetChannelsPlaying(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020(out int _0020)
		{
			return FMOD_System_GetChannelsReal(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A(out float _0020, out float _0020_000A, out float _0020_0020, out float _0020_000A_000A, out float _0020_000A_0020)
		{
			return FMOD_System_GetCPUUsage(rawPtr, out _0020, out _0020_000A, out _0020_0020, out _0020_000A_000A, out _0020_000A_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020(out int _0020, out int _0020_000A, out int _0020_0020)
		{
			return FMOD_System_GetSoundRAM(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(string _0020, MODE _0020_000A, ref CREATESOUNDEXINFO _0020_0020, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_000A_000A)
		{
			_0020_000A_000A = null;
			byte[] bytes = Encoding.UTF8.GetBytes(_0020 + "\0");
			_0020_0020.cbsize = Marshal.SizeOf((object)_0020_0020);
			IntPtr raw;
			RESULT result = FMOD_System_CreateSound(rawPtr, bytes, _0020_000A, ref _0020_0020, out raw);
			_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(byte[] _0020, MODE _0020_000A, ref CREATESOUNDEXINFO _0020_0020, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_000A_000A)
		{
			_0020_000A_000A = null;
			_0020_0020.cbsize = Marshal.SizeOf((object)_0020_0020);
			IntPtr raw;
			RESULT result = FMOD_System_CreateSound(rawPtr, _0020, _0020_000A, ref _0020_0020, out raw);
			_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(string _0020, MODE _0020_000A, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_0020)
		{
			CREATESOUNDEXINFO cREATESOUNDEXINFO = default(CREATESOUNDEXINFO);
			cREATESOUNDEXINFO.cbsize = Marshal.SizeOf((object)cREATESOUNDEXINFO);
			return _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A(_0020, _0020_000A, ref cREATESOUNDEXINFO, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020(string _0020, MODE _0020_000A, ref CREATESOUNDEXINFO _0020_0020, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_000A_000A)
		{
			_0020_000A_000A = null;
			byte[] bytes = Encoding.UTF8.GetBytes(_0020 + "\0");
			_0020_0020.cbsize = Marshal.SizeOf((object)_0020_0020);
			IntPtr raw;
			RESULT result = FMOD_System_CreateStream(rawPtr, bytes, _0020_000A, ref _0020_0020, out raw);
			_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020(byte[] _0020, MODE _0020_000A, ref CREATESOUNDEXINFO _0020_0020, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_000A_000A)
		{
			_0020_000A_000A = null;
			_0020_0020.cbsize = Marshal.SizeOf((object)_0020_0020);
			IntPtr raw;
			RESULT result = FMOD_System_CreateStream(rawPtr, _0020, _0020_000A, ref _0020_0020, out raw);
			_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020(string _0020, MODE _0020_000A, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_0020)
		{
			CREATESOUNDEXINFO cREATESOUNDEXINFO = default(CREATESOUNDEXINFO);
			cREATESOUNDEXINFO.cbsize = Marshal.SizeOf((object)cREATESOUNDEXINFO);
			return _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020(_0020, _0020_000A, ref cREATESOUNDEXINFO, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A(ref DSP_DESCRIPTION _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_System_CreateDSP(rawPtr, ref _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020(DSP_TYPE _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_System_CreateDSPByType(rawPtr, _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A(string _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020_000A)
		{
			_0020_000A = null;
			byte[] bytes = Encoding.UTF8.GetBytes(_0020 + "\0");
			IntPtr raw;
			RESULT result = FMOD_System_CreateChannelGroup(rawPtr, bytes, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020(string _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020 _0020_000A)
		{
			_0020_000A = null;
			byte[] bytes = Encoding.UTF8.GetBytes(_0020 + "\0");
			IntPtr raw;
			RESULT result = FMOD_System_CreateSoundGroup(rawPtr, bytes, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020 _0020)
		{
			IntPtr raw;
			RESULT result = FMOD_System_CreateReverb3D(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020(_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020, _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020_000A, bool _0020_0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_000A_000A)
		{
			_0020_000A_000A = null;
			IntPtr _0020_00202 = (_0020_000A != null) ? _0020_000A.getRaw() : IntPtr.Zero;
			IntPtr raw;
			RESULT result = FMOD_System_PlaySound(rawPtr, _0020.getRaw(), _0020_00202, _0020_0020, out raw);
			_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020, _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020_000A, bool _0020_0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_000A_000A)
		{
			_0020_000A_000A = null;
			IntPtr _0020_00202 = (_0020_000A != null) ? _0020_000A.getRaw() : IntPtr.Zero;
			IntPtr raw;
			RESULT result = FMOD_System_PlayDSP(rawPtr, _0020.getRaw(), _0020_00202, _0020_0020, out raw);
			_0020_000A_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020(int _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_System_GetChannel(rawPtr, _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020(out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_System_GetMasterChannelGroup(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020 _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_System_GetMasterSoundGroup(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020(uint _0020, ulong _0020_000A, _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020_0020, bool _0020_000A_000A = false)
		{
			return FMOD_System_AttachChannelGroupToPort(rawPtr, _0020, _0020_000A, _0020_0020.getRaw(), _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020)
		{
			return FMOD_System_DetachChannelGroupFromPort(rawPtr, _0020.getRaw());
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A(int _0020, ref REVERB_PROPERTIES _0020_000A)
		{
			return FMOD_System_SetReverbProperties(rawPtr, _0020, ref _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020(int _0020, out REVERB_PROPERTIES _0020_000A)
		{
			return FMOD_System_GetReverbProperties(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020()
		{
			return FMOD_System_LockDSP(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A()
		{
			return FMOD_System_UnlockDSP(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020(out int _0020, out int _0020_000A)
		{
			return FMOD_System_GetRecordNumDrivers(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A(int _0020, StringBuilder _0020_000A, int _0020_0020, out Guid _0020_000A_000A, out int _0020_000A_0020, out SPEAKERMODE _0020_0020_000A, out int _0020_0020_0020, out DRIVER_STATE _0020_000A_000A_000A)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020_000A.Capacity);
			RESULT result = FMOD_System_GetRecordDriverInfo(rawPtr, _0020, intPtr, _0020_0020, out _0020_000A_000A, out _0020_000A_0020, out _0020_0020_000A, out _0020_0020_0020, out _0020_000A_000A_000A);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020_000A, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020(int _0020, out uint _0020_000A)
		{
			return FMOD_System_GetRecordPosition(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A(int _0020, _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_000A, bool _0020_0020)
		{
			return FMOD_System_RecordStart(rawPtr, _0020, _0020_000A.getRaw(), _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020(int _0020)
		{
			return FMOD_System_RecordStop(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A(int _0020, out bool _0020_000A)
		{
			return FMOD_System_IsRecording(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020(int _0020, int _0020_000A, out _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020 _0020_0020)
		{
			_0020_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_System_CreateGeometry(rawPtr, _0020, _0020_000A, out raw);
			_0020_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A(float _0020)
		{
			return FMOD_System_SetGeometrySettings(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020(out float _0020)
		{
			return FMOD_System_GetGeometrySettings(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A(IntPtr _0020, int _0020_000A, out _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020 _0020_0020)
		{
			_0020_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_System_LoadGeometry(rawPtr, _0020, _0020_000A, out raw);
			_0020_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020(ref VECTOR _0020, ref VECTOR _0020_000A, out float _0020_0020, out float _0020_000A_000A)
		{
			return FMOD_System_GetGeometryOcclusion(rawPtr, ref _0020, ref _0020_000A, out _0020_0020, out _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A(string _0020)
		{
			return FMOD_System_SetNetworkProxy(rawPtr, Encoding.UTF8.GetBytes(_0020 + "\0"));
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020(StringBuilder _0020, int _0020_000A)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020.Capacity);
			RESULT result = FMOD_System_GetNetworkProxy(rawPtr, intPtr, _0020_000A);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A(int _0020)
		{
			return FMOD_System_SetNetworkTimeout(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020(out int _0020)
		{
			return FMOD_System_GetNetworkTimeout(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_System_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_System_GetUserData(rawPtr, out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Release(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetOutput(IntPtr _0020, OUTPUTTYPE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetOutput(IntPtr _0020, out OUTPUTTYPE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetNumDrivers(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetDriverInfo(IntPtr _0020, int _0020_000A, IntPtr _0020_0020, int _0020_000A_000A, out Guid _0020_000A_0020, out int _0020_0020_000A, out SPEAKERMODE _0020_0020_0020, out int _0020_000A_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetDriver(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetDriver(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetSoftwareChannels(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetSoftwareChannels(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetSoftwareFormat(IntPtr _0020, int _0020_000A, SPEAKERMODE _0020_0020, int _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetSoftwareFormat(IntPtr _0020, out int _0020_000A, out SPEAKERMODE _0020_0020, out int _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetDSPBufferSize(IntPtr _0020, uint _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetDSPBufferSize(IntPtr _0020, out uint _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetFileSystem(IntPtr _0020, FILE_OPENCALLBACK _0020_000A, FILE_CLOSECALLBACK _0020_0020, FILE_READCALLBACK _0020_000A_000A, FILE_SEEKCALLBACK _0020_000A_0020, FILE_ASYNCREADCALLBACK _0020_0020_000A, FILE_ASYNCCANCELCALLBACK _0020_0020_0020, int _0020_000A_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_AttachFileSystem(IntPtr _0020, FILE_OPENCALLBACK _0020_000A, FILE_CLOSECALLBACK _0020_0020, FILE_READCALLBACK _0020_000A_000A, FILE_SEEKCALLBACK _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetPluginPath(IntPtr _0020, byte[] _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_LoadPlugin(IntPtr _0020, byte[] _0020_000A, out uint _0020_0020, uint _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_UnloadPlugin(IntPtr _0020, uint _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetNumPlugins(IntPtr _0020, PLUGINTYPE _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetPluginHandle(IntPtr _0020, PLUGINTYPE _0020_000A, int _0020_0020, out uint _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetPluginInfo(IntPtr _0020, uint _0020_000A, out PLUGINTYPE _0020_0020, IntPtr _0020_000A_000A, int _0020_000A_0020, out uint _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateDSPByPlugin(IntPtr _0020, uint _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetOutputByPlugin(IntPtr _0020, uint _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetOutputByPlugin(IntPtr _0020, out uint _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetDSPInfoByPlugin(IntPtr _0020, uint _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_RegisterDSP(IntPtr _0020, ref DSP_DESCRIPTION _0020_000A, out uint _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Init(IntPtr _0020, int _0020_000A, INITFLAGS _0020_0020, IntPtr _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Close(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Update(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetAdvancedSettings(IntPtr _0020, ref ADVANCEDSETTINGS _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetAdvancedSettings(IntPtr _0020, ref ADVANCEDSETTINGS _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Set3DRolloffCallback(IntPtr _0020, CB_3D_ROLLOFFCALLBACK _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_MixerSuspend(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_MixerResume(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetDefaultMixMatrix(IntPtr _0020, SPEAKERMODE _0020_000A, SPEAKERMODE _0020_0020, float[] _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetSpeakerModeChannels(IntPtr _0020, SPEAKERMODE _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetCallback(IntPtr _0020, SYSTEM_CALLBACK _0020_000A, SYSTEM_CALLBACK_TYPE _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetSpeakerPosition(IntPtr _0020, SPEAKER _0020_000A, float _0020_0020, float _0020_000A_000A, bool _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetSpeakerPosition(IntPtr _0020, SPEAKER _0020_000A, out float _0020_0020, out float _0020_000A_000A, out bool _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Set3DSettings(IntPtr _0020, float _0020_000A, float _0020_0020, float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Get3DSettings(IntPtr _0020, out float _0020_000A, out float _0020_0020, out float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Set3DNumListeners(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Get3DNumListeners(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Set3DListenerAttributes(IntPtr _0020, int _0020_000A, ref VECTOR _0020_0020, ref VECTOR _0020_000A_000A, ref VECTOR _0020_000A_0020, ref VECTOR _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_Get3DListenerAttributes(IntPtr _0020, int _0020_000A, out VECTOR _0020_0020, out VECTOR _0020_000A_000A, out VECTOR _0020_000A_0020, out VECTOR _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetStreamBufferSize(IntPtr _0020, uint _0020_000A, TIMEUNIT _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetStreamBufferSize(IntPtr _0020, out uint _0020_000A, out TIMEUNIT _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetVersion(IntPtr _0020, out uint _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetOutputHandle(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetChannelsPlaying(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetChannelsReal(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetCPUUsage(IntPtr _0020, out float _0020_000A, out float _0020_0020, out float _0020_000A_000A, out float _0020_000A_0020, out float _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetSoundRAM(IntPtr _0020, out int _0020_000A, out int _0020_0020, out int _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateSound(IntPtr _0020, byte[] _0020_000A, MODE _0020_0020, ref CREATESOUNDEXINFO _0020_000A_000A, out IntPtr _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateStream(IntPtr _0020, byte[] _0020_000A, MODE _0020_0020, ref CREATESOUNDEXINFO _0020_000A_000A, out IntPtr _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateDSP(IntPtr _0020, ref DSP_DESCRIPTION _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateDSPByType(IntPtr _0020, DSP_TYPE _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateChannelGroup(IntPtr _0020, byte[] _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateSoundGroup(IntPtr _0020, byte[] _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateReverb3D(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_PlaySound(IntPtr _0020, IntPtr _0020_000A, IntPtr _0020_0020, bool _0020_000A_000A, out IntPtr _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_PlayDSP(IntPtr _0020, IntPtr _0020_000A, IntPtr _0020_0020, bool _0020_000A_000A, out IntPtr _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetChannel(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetMasterChannelGroup(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetMasterSoundGroup(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_AttachChannelGroupToPort(IntPtr _0020, uint _0020_000A, ulong _0020_0020, IntPtr _0020_000A_000A, bool _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_DetachChannelGroupFromPort(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetReverbProperties(IntPtr _0020, int _0020_000A, ref REVERB_PROPERTIES _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetReverbProperties(IntPtr _0020, int _0020_000A, out REVERB_PROPERTIES _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_LockDSP(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_UnlockDSP(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetRecordNumDrivers(IntPtr _0020, out int _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetRecordDriverInfo(IntPtr _0020, int _0020_000A, IntPtr _0020_0020, int _0020_000A_000A, out Guid _0020_000A_0020, out int _0020_0020_000A, out SPEAKERMODE _0020_0020_0020, out int _0020_000A_000A_000A, out DRIVER_STATE _0020_000A_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetRecordPosition(IntPtr _0020, int _0020_000A, out uint _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_RecordStart(IntPtr _0020, int _0020_000A, IntPtr _0020_0020, bool _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_RecordStop(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_IsRecording(IntPtr _0020, int _0020_000A, out bool _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_CreateGeometry(IntPtr _0020, int _0020_000A, int _0020_0020, out IntPtr _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetGeometrySettings(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetGeometrySettings(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_LoadGeometry(IntPtr _0020, IntPtr _0020_000A, int _0020_0020, out IntPtr _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetGeometryOcclusion(IntPtr _0020, ref VECTOR _0020_000A, ref VECTOR _0020_0020, out float _0020_000A_000A, out float _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetNetworkProxy(IntPtr _0020, byte[] _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetNetworkProxy(IntPtr _0020, IntPtr _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetNetworkTimeout(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetNetworkTimeout(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_System_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		public _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		{
			RESULT num = FMOD_Sound_Release(rawPtr);
			if (num == RESULT.OK)
			{
				rawPtr = IntPtr.Zero;
			}
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_Sound_GetSystemObject(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A(uint _0020, uint _0020_000A, out IntPtr _0020_0020, out IntPtr _0020_000A_000A, out uint _0020_000A_0020, out uint _0020_0020_000A)
		{
			return FMOD_Sound_Lock(rawPtr, _0020, _0020_000A, out _0020_0020, out _0020_000A_000A, out _0020_000A_0020, out _0020_0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020(IntPtr _0020, IntPtr _0020_000A, uint _0020_0020, uint _0020_000A_000A)
		{
			return FMOD_Sound_Unlock(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A(float _0020, int _0020_000A)
		{
			return FMOD_Sound_SetDefaults(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020(out float _0020, out int _0020_000A)
		{
			return FMOD_Sound_GetDefaults(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020(float _0020, float _0020_000A)
		{
			return FMOD_Sound_Set3DMinMaxDistance(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A(out float _0020, out float _0020_000A)
		{
			return FMOD_Sound_Get3DMinMaxDistance(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(float _0020, float _0020_000A, float _0020_0020)
		{
			return FMOD_Sound_Set3DConeSettings(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A(out float _0020, out float _0020_000A, out float _0020_0020)
		{
			return FMOD_Sound_Get3DConeSettings(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020(ref VECTOR _0020, int _0020_000A)
		{
			return FMOD_Sound_Set3DCustomRolloff(rawPtr, ref _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A(out IntPtr _0020, out int _0020_000A)
		{
			return FMOD_Sound_Get3DCustomRolloff(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A(int _0020, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_Sound_GetSubSound(rawPtr, _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020(out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_Sound_GetSubSoundParent(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(StringBuilder _0020, int _0020_000A)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020.Capacity);
			RESULT result = FMOD_Sound_GetName(rawPtr, intPtr, _0020_000A);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A(out uint _0020, TIMEUNIT _0020_000A)
		{
			return FMOD_Sound_GetLength(rawPtr, out _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020(out SOUND_TYPE _0020, out SOUND_FORMAT _0020_000A, out int _0020_0020, out int _0020_000A_000A)
		{
			return FMOD_Sound_GetFormat(rawPtr, out _0020, out _0020_000A, out _0020_0020, out _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A(out int _0020)
		{
			return FMOD_Sound_GetNumSubSounds(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020(out int _0020, out int _0020_000A)
		{
			return FMOD_Sound_GetNumTags(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A(string _0020, int _0020_000A, out TAG _0020_0020)
		{
			return FMOD_Sound_GetTag(rawPtr, _0020, _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020(out OPENSTATE _0020, out uint _0020_000A, out bool _0020_0020, out bool _0020_000A_000A)
		{
			return FMOD_Sound_GetOpenState(rawPtr, out _0020, out _0020_000A, out _0020_0020, out _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A(IntPtr _0020, uint _0020_000A, out uint _0020_0020)
		{
			return FMOD_Sound_ReadData(rawPtr, _0020, _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020(uint _0020)
		{
			return FMOD_Sound_SeekData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020 _0020)
		{
			return FMOD_Sound_SetSoundGroup(rawPtr, _0020.getRaw());
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020(out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020 _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_Sound_GetSoundGroup(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A(out int _0020)
		{
			return FMOD_Sound_GetNumSyncPoints(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020(int _0020, out IntPtr _0020_000A)
		{
			return FMOD_Sound_GetSyncPoint(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A(IntPtr _0020, StringBuilder _0020_000A, int _0020_0020, out uint _0020_000A_000A, TIMEUNIT _0020_000A_0020)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020_000A.Capacity);
			RESULT result = FMOD_Sound_GetSyncPointInfo(rawPtr, _0020, intPtr, _0020_0020, out _0020_000A_000A, _0020_000A_0020);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020_000A, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020(uint _0020, TIMEUNIT _0020_000A, string _0020_0020, out IntPtr _0020_000A_000A)
		{
			return FMOD_Sound_AddSyncPoint(rawPtr, _0020, _0020_000A, _0020_0020, out _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A(IntPtr _0020)
		{
			return FMOD_Sound_DeleteSyncPoint(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A(MODE _0020)
		{
			return FMOD_Sound_SetMode(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020(out MODE _0020)
		{
			return FMOD_Sound_GetMode(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020(int _0020)
		{
			return FMOD_Sound_SetLoopCount(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A(out int _0020)
		{
			return FMOD_Sound_GetLoopCount(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020(uint _0020, TIMEUNIT _0020_000A, uint _0020_0020, TIMEUNIT _0020_000A_000A)
		{
			return FMOD_Sound_SetLoopPoints(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A(out uint _0020, TIMEUNIT _0020_000A, out uint _0020_0020, TIMEUNIT _0020_000A_000A)
		{
			return FMOD_Sound_GetLoopPoints(rawPtr, out _0020, _0020_000A, out _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020(out int _0020)
		{
			return FMOD_Sound_GetMusicNumChannels(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A(int _0020, float _0020_000A)
		{
			return FMOD_Sound_SetMusicChannelVolume(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020(int _0020, out float _0020_000A)
		{
			return FMOD_Sound_GetMusicChannelVolume(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A(float _0020)
		{
			return FMOD_Sound_SetMusicSpeed(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020(out float _0020)
		{
			return FMOD_Sound_GetMusicSpeed(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_Sound_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_Sound_GetUserData(rawPtr, out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Release(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetSystemObject(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Lock(IntPtr _0020, uint _0020_000A, uint _0020_0020, out IntPtr _0020_000A_000A, out IntPtr _0020_000A_0020, out uint _0020_0020_000A, out uint _0020_0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Unlock(IntPtr _0020, IntPtr _0020_000A, IntPtr _0020_0020, uint _0020_000A_000A, uint _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetDefaults(IntPtr _0020, float _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetDefaults(IntPtr _0020, out float _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Set3DMinMaxDistance(IntPtr _0020, float _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Get3DMinMaxDistance(IntPtr _0020, out float _0020_000A, out float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Set3DConeSettings(IntPtr _0020, float _0020_000A, float _0020_0020, float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Get3DConeSettings(IntPtr _0020, out float _0020_000A, out float _0020_0020, out float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Set3DCustomRolloff(IntPtr _0020, ref VECTOR _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_Get3DCustomRolloff(IntPtr _0020, out IntPtr _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetSubSound(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetSubSoundParent(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetName(IntPtr _0020, IntPtr _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetLength(IntPtr _0020, out uint _0020_000A, TIMEUNIT _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetFormat(IntPtr _0020, out SOUND_TYPE _0020_000A, out SOUND_FORMAT _0020_0020, out int _0020_000A_000A, out int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetNumSubSounds(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetNumTags(IntPtr _0020, out int _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetTag(IntPtr _0020, string _0020_000A, int _0020_0020, out TAG _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetOpenState(IntPtr _0020, out OPENSTATE _0020_000A, out uint _0020_0020, out bool _0020_000A_000A, out bool _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_ReadData(IntPtr _0020, IntPtr _0020_000A, uint _0020_0020, out uint _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SeekData(IntPtr _0020, uint _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetSoundGroup(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetSoundGroup(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetNumSyncPoints(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetSyncPoint(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetSyncPointInfo(IntPtr _0020, IntPtr _0020_000A, IntPtr _0020_0020, int _0020_000A_000A, out uint _0020_000A_0020, TIMEUNIT _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_AddSyncPoint(IntPtr _0020, uint _0020_000A, TIMEUNIT _0020_0020, string _0020_000A_000A, out IntPtr _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_DeleteSyncPoint(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetMode(IntPtr _0020, MODE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetMode(IntPtr _0020, out MODE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetLoopCount(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetLoopCount(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetLoopPoints(IntPtr _0020, uint _0020_000A, TIMEUNIT _0020_0020, uint _0020_000A_000A, TIMEUNIT _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetLoopPoints(IntPtr _0020, out uint _0020_000A, TIMEUNIT _0020_0020, out uint _0020_000A_000A, TIMEUNIT _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetMusicNumChannels(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetMusicChannelVolume(IntPtr _0020, int _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetMusicChannelVolume(IntPtr _0020, int _0020_000A, out float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetMusicSpeed(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetMusicSpeed(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Sound_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		public _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020 : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_ChannelGroup_GetSystemObject(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020()
		{
			return FMOD_ChannelGroup_Stop(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020(bool _0020)
		{
			return FMOD_ChannelGroup_SetPaused(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A(out bool _0020)
		{
			return FMOD_ChannelGroup_GetPaused(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020(float _0020)
		{
			return FMOD_ChannelGroup_SetVolume(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A(out float _0020)
		{
			return FMOD_ChannelGroup_GetVolume(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020(bool _0020)
		{
			return FMOD_ChannelGroup_SetVolumeRamp(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A(out bool _0020)
		{
			return FMOD_ChannelGroup_GetVolumeRamp(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020(out float _0020)
		{
			return FMOD_ChannelGroup_GetAudibility(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A(float _0020)
		{
			return FMOD_ChannelGroup_SetPitch(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020(out float _0020)
		{
			return FMOD_ChannelGroup_GetPitch(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A(bool _0020)
		{
			return FMOD_ChannelGroup_SetMute(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020(out bool _0020)
		{
			return FMOD_ChannelGroup_GetMute(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A(int _0020, float _0020_000A)
		{
			return FMOD_ChannelGroup_SetReverbProperties(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020(int _0020, out float _0020_000A)
		{
			return FMOD_ChannelGroup_GetReverbProperties(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A(float _0020)
		{
			return FMOD_ChannelGroup_SetLowPassGain(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020(out float _0020)
		{
			return FMOD_ChannelGroup_GetLowPassGain(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A(MODE _0020)
		{
			return FMOD_ChannelGroup_SetMode(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020(out MODE _0020)
		{
			return FMOD_ChannelGroup_GetMode(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A(CHANNEL_CALLBACK _0020)
		{
			return FMOD_ChannelGroup_SetCallback(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020(out bool _0020)
		{
			return FMOD_ChannelGroup_IsPlaying(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A(float _0020)
		{
			return FMOD_ChannelGroup_SetPan(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020(float _0020, float _0020_000A, float _0020_0020, float _0020_000A_000A, float _0020_000A_0020, float _0020_0020_000A, float _0020_0020_0020, float _0020_000A_000A_000A)
		{
			return FMOD_ChannelGroup_SetMixLevelsOutput(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020, _0020_0020_000A, _0020_0020_0020, _0020_000A_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A(float[] _0020, int _0020_000A)
		{
			return FMOD_ChannelGroup_SetMixLevelsInput(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A(float[] _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			return FMOD_ChannelGroup_SetMixMatrix(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020(float[] _0020, out int _0020_000A, out int _0020_0020, int _0020_000A_000A)
		{
			return FMOD_ChannelGroup_GetMixMatrix(rawPtr, _0020, out _0020_000A, out _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020(out ulong _0020, out ulong _0020_000A)
		{
			return FMOD_ChannelGroup_GetDSPClock(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A(ulong _0020, ulong _0020_000A, bool _0020_0020)
		{
			return FMOD_ChannelGroup_SetDelay(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020(out ulong _0020, out ulong _0020_000A, out bool _0020_0020)
		{
			return FMOD_ChannelGroup_GetDelay(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A(ulong _0020, float _0020_000A)
		{
			return FMOD_ChannelGroup_AddFadePoint(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020(ulong _0020, float _0020_000A)
		{
			return FMOD_ChannelGroup_SetFadePointRamp(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A(ulong _0020, ulong _0020_000A)
		{
			return FMOD_ChannelGroup_RemoveFadePoints(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020(ref uint _0020, ulong[] _0020_000A, float[] _0020_0020)
		{
			return FMOD_ChannelGroup_GetFadePoints(rawPtr, ref _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A(int _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_ChannelGroup_GetDSP(rawPtr, _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020(int _0020, _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A)
		{
			return FMOD_ChannelGroup_AddDSP(rawPtr, _0020, _0020_000A.getRaw());
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020)
		{
			return FMOD_ChannelGroup_RemoveDSP(rawPtr, _0020.getRaw());
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020(out int _0020)
		{
			return FMOD_ChannelGroup_GetNumDSPs(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020, int _0020_000A)
		{
			return FMOD_ChannelGroup_SetDSPIndex(rawPtr, _0020.getRaw(), _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020, out int _0020_000A)
		{
			return FMOD_ChannelGroup_GetDSPIndex(rawPtr, _0020.getRaw(), out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020)
		{
			return FMOD_ChannelGroup_OverridePanDSP(rawPtr, _0020.getRaw());
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020(ref VECTOR _0020, ref VECTOR _0020_000A, ref VECTOR _0020_0020)
		{
			return FMOD_ChannelGroup_Set3DAttributes(rawPtr, ref _0020, ref _0020_000A, ref _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A(out VECTOR _0020, out VECTOR _0020_000A, out VECTOR _0020_0020)
		{
			return FMOD_ChannelGroup_Get3DAttributes(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020(float _0020, float _0020_000A)
		{
			return FMOD_ChannelGroup_Set3DMinMaxDistance(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A(out float _0020, out float _0020_000A)
		{
			return FMOD_ChannelGroup_Get3DMinMaxDistance(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020(float _0020, float _0020_000A, float _0020_0020)
		{
			return FMOD_ChannelGroup_Set3DConeSettings(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A(out float _0020, out float _0020_000A, out float _0020_0020)
		{
			return FMOD_ChannelGroup_Get3DConeSettings(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020(ref VECTOR _0020)
		{
			return FMOD_ChannelGroup_Set3DConeOrientation(rawPtr, ref _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A(out VECTOR _0020)
		{
			return FMOD_ChannelGroup_Get3DConeOrientation(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020(ref VECTOR _0020, int _0020_000A)
		{
			return FMOD_ChannelGroup_Set3DCustomRolloff(rawPtr, ref _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A(out IntPtr _0020, out int _0020_000A)
		{
			return FMOD_ChannelGroup_Get3DCustomRolloff(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020(float _0020, float _0020_000A)
		{
			return FMOD_ChannelGroup_Set3DOcclusion(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A(out float _0020, out float _0020_000A)
		{
			return FMOD_ChannelGroup_Get3DOcclusion(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020(float _0020)
		{
			return FMOD_ChannelGroup_Set3DSpread(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A(out float _0020)
		{
			return FMOD_ChannelGroup_Get3DSpread(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020(float _0020)
		{
			return FMOD_ChannelGroup_Set3DLevel(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A(out float _0020)
		{
			return FMOD_ChannelGroup_Get3DLevel(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020(float _0020)
		{
			return FMOD_ChannelGroup_Set3DDopplerLevel(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A(out float _0020)
		{
			return FMOD_ChannelGroup_Get3DDopplerLevel(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020(bool _0020, float _0020_000A, float _0020_0020)
		{
			return FMOD_ChannelGroup_Set3DDistanceFilter(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A(out bool _0020, out float _0020_000A, out float _0020_0020)
		{
			return FMOD_ChannelGroup_Get3DDistanceFilter(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_ChannelGroup_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_ChannelGroup_GetUserData(rawPtr, out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Stop(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetPaused(IntPtr _0020, bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetPaused(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetVolume(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetVolumeRamp(IntPtr _0020, bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetVolumeRamp(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetAudibility(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetPitch(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetPitch(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetMute(IntPtr _0020, bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetMute(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetReverbProperties(IntPtr _0020, int _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetReverbProperties(IntPtr _0020, int _0020_000A, out float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetLowPassGain(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetLowPassGain(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetMode(IntPtr _0020, MODE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetMode(IntPtr _0020, out MODE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetCallback(IntPtr _0020, CHANNEL_CALLBACK _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_IsPlaying(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetPan(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetMixLevelsOutput(IntPtr _0020, float _0020_000A, float _0020_0020, float _0020_000A_000A, float _0020_000A_0020, float _0020_0020_000A, float _0020_0020_0020, float _0020_000A_000A_000A, float _0020_000A_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetMixLevelsInput(IntPtr _0020, float[] _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetMixMatrix(IntPtr _0020, float[] _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetMixMatrix(IntPtr _0020, float[] _0020_000A, out int _0020_0020, out int _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetDSPClock(IntPtr _0020, out ulong _0020_000A, out ulong _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetDelay(IntPtr _0020, ulong _0020_000A, ulong _0020_0020, bool _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetDelay(IntPtr _0020, out ulong _0020_000A, out ulong _0020_0020, out bool _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_AddFadePoint(IntPtr _0020, ulong _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetFadePointRamp(IntPtr _0020, ulong _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_RemoveFadePoints(IntPtr _0020, ulong _0020_000A, ulong _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetFadePoints(IntPtr _0020, ref uint _0020_000A, ulong[] _0020_0020, float[] _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DAttributes(IntPtr _0020, ref VECTOR _0020_000A, ref VECTOR _0020_0020, ref VECTOR _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DAttributes(IntPtr _0020, out VECTOR _0020_000A, out VECTOR _0020_0020, out VECTOR _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DMinMaxDistance(IntPtr _0020, float _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DMinMaxDistance(IntPtr _0020, out float _0020_000A, out float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DConeSettings(IntPtr _0020, float _0020_000A, float _0020_0020, float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DConeSettings(IntPtr _0020, out float _0020_000A, out float _0020_0020, out float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DConeOrientation(IntPtr _0020, ref VECTOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DConeOrientation(IntPtr _0020, out VECTOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DCustomRolloff(IntPtr _0020, ref VECTOR _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DCustomRolloff(IntPtr _0020, out IntPtr _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DOcclusion(IntPtr _0020, float _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DOcclusion(IntPtr _0020, out float _0020_000A, out float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DSpread(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DSpread(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DLevel(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DLevel(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DDopplerLevel(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DDopplerLevel(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Set3DDistanceFilter(IntPtr _0020, bool _0020_000A, float _0020_0020, float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Get3DDistanceFilter(IntPtr _0020, out bool _0020_000A, out float _0020_0020, out float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetSystemObject(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetVolume(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetDSP(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_AddDSP(IntPtr _0020, int _0020_000A, IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_RemoveDSP(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetNumDSPs(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetDSPIndex(IntPtr _0020, IntPtr _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetDSPIndex(IntPtr _0020, IntPtr _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_OverridePanDSP(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		protected _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A : _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020(float _0020)
		{
			return FMOD_Channel_SetFrequency(getRaw(), _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A(out float _0020)
		{
			return FMOD_Channel_GetFrequency(getRaw(), out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020(int _0020)
		{
			return FMOD_Channel_SetPriority(getRaw(), _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A(out int _0020)
		{
			return FMOD_Channel_GetPriority(getRaw(), out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A(uint _0020, TIMEUNIT _0020_000A)
		{
			return FMOD_Channel_SetPosition(getRaw(), _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020(out uint _0020, TIMEUNIT _0020_000A)
		{
			return FMOD_Channel_GetPosition(getRaw(), out _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020)
		{
			return FMOD_Channel_SetChannelGroup(getRaw(), _0020.getRaw());
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_Channel_GetChannelGroup(getRaw(), out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020(int _0020)
		{
			return FMOD_Channel_SetLoopCount(getRaw(), _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A(out int _0020)
		{
			return FMOD_Channel_GetLoopCount(getRaw(), out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020(uint _0020, TIMEUNIT _0020_000A, uint _0020_0020, TIMEUNIT _0020_000A_000A)
		{
			return FMOD_Channel_SetLoopPoints(getRaw(), _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A(out uint _0020, TIMEUNIT _0020_000A, out uint _0020_0020, TIMEUNIT _0020_000A_000A)
		{
			return FMOD_Channel_GetLoopPoints(getRaw(), out _0020, _0020_000A, out _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020(out bool _0020)
		{
			return FMOD_Channel_IsVirtual(getRaw(), out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A(out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_Channel_GetCurrentSound(getRaw(), out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020(out int _0020)
		{
			return FMOD_Channel_GetIndex(getRaw(), out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetFrequency(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetFrequency(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetPriority(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetPriority(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetChannelGroup(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetChannelGroup(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_IsVirtual(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetCurrentSound(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetIndex(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetPosition(IntPtr _0020, uint _0020_000A, TIMEUNIT _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetPosition(IntPtr _0020, out uint _0020_000A, TIMEUNIT _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetMode(IntPtr _0020, MODE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetMode(IntPtr _0020, out MODE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetLoopCount(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetLoopCount(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetLoopPoints(IntPtr _0020, uint _0020_000A, TIMEUNIT _0020_0020, uint _0020_000A_000A, TIMEUNIT _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetLoopPoints(IntPtr _0020, out uint _0020_000A, TIMEUNIT _0020_0020, out uint _0020_000A_000A, TIMEUNIT _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Channel_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		public _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A : _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		{
			RESULT num = FMOD_ChannelGroup_Release(getRaw());
			if (num == RESULT.OK)
			{
				rawPtr = IntPtr.Zero;
			}
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020, bool _0020_000A, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 _0020_0020)
		{
			_0020_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_ChannelGroup_AddGroup(getRaw(), _0020.getRaw(), _0020_000A, out raw);
			_0020_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(out int _0020)
		{
			return FMOD_ChannelGroup_GetNumGroups(getRaw(), out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A(int _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_ChannelGroup_GetGroup(getRaw(), _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020(out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_ChannelGroup_GetParentGroup(getRaw(), out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(StringBuilder _0020, int _0020_000A)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020.Capacity);
			RESULT result = FMOD_ChannelGroup_GetName(getRaw(), intPtr, _0020_000A);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A(out int _0020)
		{
			return FMOD_ChannelGroup_GetNumChannels(getRaw(), out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020(int _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_ChannelGroup_GetChannel(getRaw(), _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A(raw);
			return result;
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_Release(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_AddGroup(IntPtr _0020, IntPtr _0020_000A, bool _0020_0020, out IntPtr _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetNumGroups(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetGroup(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetParentGroup(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetName(IntPtr _0020, IntPtr _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetNumChannels(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_ChannelGroup_GetChannel(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		public _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020 : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		{
			RESULT num = FMOD_SoundGroup_Release(getRaw());
			if (num == RESULT.OK)
			{
				rawPtr = IntPtr.Zero;
			}
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_SoundGroup_GetSystemObject(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020(int _0020)
		{
			return FMOD_SoundGroup_SetMaxAudible(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A(out int _0020)
		{
			return FMOD_SoundGroup_GetMaxAudible(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020(SOUNDGROUP_BEHAVIOR _0020)
		{
			return FMOD_SoundGroup_SetMaxAudibleBehavior(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A(out SOUNDGROUP_BEHAVIOR _0020)
		{
			return FMOD_SoundGroup_GetMaxAudibleBehavior(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020(float _0020)
		{
			return FMOD_SoundGroup_SetMuteFadeSpeed(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A(out float _0020)
		{
			return FMOD_SoundGroup_GetMuteFadeSpeed(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020(float _0020)
		{
			return FMOD_SoundGroup_SetVolume(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A(out float _0020)
		{
			return FMOD_SoundGroup_GetVolume(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020()
		{
			return FMOD_SoundGroup_Stop(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020(StringBuilder _0020, int _0020_000A)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(_0020.Capacity);
			RESULT result = FMOD_SoundGroup_GetName(rawPtr, intPtr, _0020_000A);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A(out int _0020)
		{
			return FMOD_SoundGroup_GetNumSounds(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020(int _0020, out _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A _0020_000A)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_SoundGroup_GetSound(rawPtr, _0020, out raw);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A(out int _0020)
		{
			return FMOD_SoundGroup_GetNumPlaying(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_SoundGroup_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_SoundGroup_GetUserData(rawPtr, out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_Release(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetSystemObject(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudible(IntPtr _0020, int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudible(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudibleBehavior(IntPtr _0020, SOUNDGROUP_BEHAVIOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudibleBehavior(IntPtr _0020, out SOUNDGROUP_BEHAVIOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_SetMuteFadeSpeed(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetMuteFadeSpeed(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_SetVolume(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetVolume(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_Stop(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetName(IntPtr _0020, IntPtr _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetNumSounds(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetSound(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetNumPlaying(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_SoundGroup_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		public _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		{
			RESULT num = FMOD_DSP_Release(getRaw());
			if (num == RESULT.OK)
			{
				rawPtr = IntPtr.Zero;
			}
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_DSP_GetSystemObject(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 _0020_000A, DSPCONNECTION_TYPE _0020_0020)
		{
			_0020_000A = null;
			IntPtr raw;
			RESULT result = FMOD_DSP_AddInput(rawPtr, _0020.getRaw(), out raw, _0020_0020);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A(_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020, _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 _0020_000A)
		{
			return FMOD_DSP_DisconnectFrom(rawPtr, _0020.getRaw(), _0020_000A.getRaw());
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020(bool _0020, bool _0020_000A)
		{
			return FMOD_DSP_DisconnectAll(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A(out int _0020)
		{
			return FMOD_DSP_GetNumInputs(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020(out int _0020)
		{
			return FMOD_DSP_GetNumOutputs(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A(int _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 _0020_0020)
		{
			_0020_000A = null;
			_0020_0020 = null;
			IntPtr raw;
			IntPtr raw2;
			RESULT result = FMOD_DSP_GetInput(rawPtr, _0020, out raw, out raw2);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			_0020_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020(raw2);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020(int _0020, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A, out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 _0020_0020)
		{
			_0020_000A = null;
			_0020_0020 = null;
			IntPtr raw;
			IntPtr raw2;
			RESULT result = FMOD_DSP_GetOutput(rawPtr, _0020, out raw, out raw2);
			_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			_0020_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020(raw2);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020(bool _0020)
		{
			return FMOD_DSP_SetActive(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A(out bool _0020)
		{
			return FMOD_DSP_GetActive(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A(bool _0020)
		{
			return FMOD_DSP_SetBypass(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020(out bool _0020)
		{
			return FMOD_DSP_GetBypass(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A(float _0020, float _0020_000A, float _0020_0020)
		{
			return FMOD_DSP_SetWetDryMix(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020(out float _0020, out float _0020_000A, out float _0020_0020)
		{
			return FMOD_DSP_GetWetDryMix(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A(CHANNELMASK _0020, int _0020_000A, SPEAKERMODE _0020_0020)
		{
			return FMOD_DSP_SetChannelFormat(rawPtr, _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020(out CHANNELMASK _0020, out int _0020_000A, out SPEAKERMODE _0020_0020)
		{
			return FMOD_DSP_GetChannelFormat(rawPtr, out _0020, out _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A(CHANNELMASK _0020, int _0020_000A, SPEAKERMODE _0020_0020, out CHANNELMASK _0020_000A_000A, out int _0020_000A_0020, out SPEAKERMODE _0020_0020_000A)
		{
			return FMOD_DSP_GetOutputChannelFormat(rawPtr, _0020, _0020_000A, _0020_0020, out _0020_000A_000A, out _0020_000A_0020, out _0020_0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020()
		{
			return FMOD_DSP_Reset(rawPtr);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020(int _0020, float _0020_000A)
		{
			return FMOD_DSP_SetParameterFloat(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A(int _0020, int _0020_000A)
		{
			return FMOD_DSP_SetParameterInt(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020(int _0020, bool _0020_000A)
		{
			return FMOD_DSP_SetParameterBool(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A(int _0020, byte[] _0020_000A)
		{
			return FMOD_DSP_SetParameterData(rawPtr, _0020, Marshal.UnsafeAddrOfPinnedArrayElement((Array)_0020_000A, 0), (uint)_0020_000A.Length);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020(int _0020, out float _0020_000A)
		{
			IntPtr zero = IntPtr.Zero;
			return FMOD_DSP_GetParameterFloat(rawPtr, _0020, out _0020_000A, zero, 0);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A(int _0020, out int _0020_000A)
		{
			IntPtr zero = IntPtr.Zero;
			return FMOD_DSP_GetParameterInt(rawPtr, _0020, out _0020_000A, zero, 0);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020(int _0020, out bool _0020_000A)
		{
			return FMOD_DSP_GetParameterBool(rawPtr, _0020, out _0020_000A, IntPtr.Zero, 0);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A(int _0020, out IntPtr _0020_000A, out uint _0020_0020)
		{
			return FMOD_DSP_GetParameterData(rawPtr, _0020, out _0020_000A, out _0020_0020, IntPtr.Zero, 0);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020(out int _0020)
		{
			return FMOD_DSP_GetNumParameters(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A(int _0020, out DSP_PARAMETER_DESC _0020_000A)
		{
			IntPtr ptr;
			RESULT num = FMOD_DSP_GetParameterInfo(rawPtr, _0020, out ptr);
			if (num == RESULT.OK)
			{
				_0020_000A = (DSP_PARAMETER_DESC)Marshal.PtrToStructure(ptr, typeof(DSP_PARAMETER_DESC));
				return num;
			}
			_0020_000A = default(DSP_PARAMETER_DESC);
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020(int _0020, out int _0020_000A)
		{
			return FMOD_DSP_GetDataParameterIndex(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A(IntPtr _0020, bool _0020_000A)
		{
			return FMOD_DSP_ShowConfigDialog(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020(StringBuilder _0020, out uint _0020_000A, out int _0020_0020, out int _0020_000A_000A, out int _0020_000A_0020)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(32);
			RESULT result = FMOD_DSP_GetInfo(rawPtr, intPtr, out _0020_000A, out _0020_0020, out _0020_000A_000A, out _0020_000A_0020);
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A(out DSP_TYPE _0020)
		{
			return FMOD_DSP_GetType(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A(out bool _0020)
		{
			return FMOD_DSP_GetIdle(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_DSP_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_DSP_GetUserData(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020(bool _0020, bool _0020_000A)
		{
			return FMOD_DSP_SetMeteringEnabled(rawPtr, _0020, _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A(out bool _0020, out bool _0020_000A)
		{
			return FMOD_DSP_GetMeteringEnabled(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020(DSP_METERING_INFO _0020, DSP_METERING_INFO _0020_000A)
		{
			return FMOD_DSP_GetMeteringInfo(rawPtr, _0020, _0020_000A);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_Release(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetSystemObject(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_AddInput(IntPtr _0020, IntPtr _0020_000A, out IntPtr _0020_0020, DSPCONNECTION_TYPE _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_DisconnectFrom(IntPtr _0020, IntPtr _0020_000A, IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_DisconnectAll(IntPtr _0020, bool _0020_000A, bool _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetNumInputs(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetNumOutputs(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetInput(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020, out IntPtr _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetOutput(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020, out IntPtr _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetActive(IntPtr _0020, bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetActive(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetBypass(IntPtr _0020, bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetBypass(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetWetDryMix(IntPtr _0020, float _0020_000A, float _0020_0020, float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetWetDryMix(IntPtr _0020, out float _0020_000A, out float _0020_0020, out float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetChannelFormat(IntPtr _0020, CHANNELMASK _0020_000A, int _0020_0020, SPEAKERMODE _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetChannelFormat(IntPtr _0020, out CHANNELMASK _0020_000A, out int _0020_0020, out SPEAKERMODE _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetOutputChannelFormat(IntPtr _0020, CHANNELMASK _0020_000A, int _0020_0020, SPEAKERMODE _0020_000A_000A, out CHANNELMASK _0020_000A_0020, out int _0020_0020_000A, out SPEAKERMODE _0020_0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_Reset(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetParameterFloat(IntPtr _0020, int _0020_000A, float _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetParameterInt(IntPtr _0020, int _0020_000A, int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetParameterBool(IntPtr _0020, int _0020_000A, bool _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetParameterData(IntPtr _0020, int _0020_000A, IntPtr _0020_0020, uint _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetParameterFloat(IntPtr _0020, int _0020_000A, out float _0020_0020, IntPtr _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetParameterInt(IntPtr _0020, int _0020_000A, out int _0020_0020, IntPtr _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetParameterBool(IntPtr _0020, int _0020_000A, out bool _0020_0020, IntPtr _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetParameterData(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020, out uint _0020_000A_000A, IntPtr _0020_000A_0020, int _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetNumParameters(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetParameterInfo(IntPtr _0020, int _0020_000A, out IntPtr _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetDataParameterIndex(IntPtr _0020, int _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_ShowConfigDialog(IntPtr _0020, IntPtr _0020_000A, bool _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetInfo(IntPtr _0020, IntPtr _0020_000A, out uint _0020_0020, out int _0020_000A_000A, out int _0020_000A_0020, out int _0020_0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetType(IntPtr _0020, out DSP_TYPE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetIdle(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSP_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		public static extern RESULT FMOD_DSP_SetMeteringEnabled(IntPtr _0020, bool _0020_000A, bool _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		public static extern RESULT FMOD_DSP_GetMeteringEnabled(IntPtr _0020, out bool _0020_000A, out bool _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		public static extern RESULT FMOD_DSP_GetMeteringInfo(IntPtr _0020, [Out] DSP_METERING_INFO _0020_000A, [Out] DSP_METERING_INFO _0020_0020);

		public _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A(out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_DSPConnection_GetInput(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020(out _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020)
		{
			_0020 = null;
			IntPtr raw;
			RESULT result = FMOD_DSPConnection_GetOutput(rawPtr, out raw);
			_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A(raw);
			return result;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A(float _0020)
		{
			return FMOD_DSPConnection_SetMix(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020(out float _0020)
		{
			return FMOD_DSPConnection_GetMix(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A(float[] _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A)
		{
			return FMOD_DSPConnection_SetMixMatrix(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020(float[] _0020, out int _0020_000A, out int _0020_0020, int _0020_000A_000A)
		{
			return FMOD_DSPConnection_GetMixMatrix(rawPtr, _0020, out _0020_000A, out _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A(out DSPCONNECTION_TYPE _0020)
		{
			return FMOD_DSPConnection_GetType(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_DSPConnection_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_DSPConnection_GetUserData(rawPtr, out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_GetInput(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_GetOutput(IntPtr _0020, out IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_SetMix(IntPtr _0020, float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_GetMix(IntPtr _0020, out float _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_SetMixMatrix(IntPtr _0020, float[] _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_GetMixMatrix(IntPtr _0020, float[] _0020_000A, out int _0020_0020, out int _0020_000A_000A, int _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_GetType(IntPtr _0020, out DSPCONNECTION_TYPE _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_DSPConnection_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		public _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020 : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		{
			RESULT num = FMOD_Geometry_Release(getRaw());
			if (num == RESULT.OK)
			{
				rawPtr = IntPtr.Zero;
			}
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A(float _0020, float _0020_000A, bool _0020_0020, int _0020_000A_000A, VECTOR[] _0020_000A_0020, out int _0020_0020_000A)
		{
			return FMOD_Geometry_AddPolygon(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020, out _0020_0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020(out int _0020)
		{
			return FMOD_Geometry_GetNumPolygons(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A(out int _0020, out int _0020_000A)
		{
			return FMOD_Geometry_GetMaxPolygons(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020(int _0020, out int _0020_000A)
		{
			return FMOD_Geometry_GetPolygonNumVertices(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A(int _0020, int _0020_000A, ref VECTOR _0020_0020)
		{
			return FMOD_Geometry_SetPolygonVertex(rawPtr, _0020, _0020_000A, ref _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020(int _0020, int _0020_000A, out VECTOR _0020_0020)
		{
			return FMOD_Geometry_GetPolygonVertex(rawPtr, _0020, _0020_000A, out _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A(int _0020, float _0020_000A, float _0020_0020, bool _0020_000A_000A)
		{
			return FMOD_Geometry_SetPolygonAttributes(rawPtr, _0020, _0020_000A, _0020_0020, _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020(int _0020, out float _0020_000A, out float _0020_0020, out bool _0020_000A_000A)
		{
			return FMOD_Geometry_GetPolygonAttributes(rawPtr, _0020, out _0020_000A, out _0020_0020, out _0020_000A_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020(bool _0020)
		{
			return FMOD_Geometry_SetActive(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A(out bool _0020)
		{
			return FMOD_Geometry_GetActive(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A(ref VECTOR _0020, ref VECTOR _0020_000A)
		{
			return FMOD_Geometry_SetRotation(rawPtr, ref _0020, ref _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020(out VECTOR _0020, out VECTOR _0020_000A)
		{
			return FMOD_Geometry_GetRotation(rawPtr, out _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A(ref VECTOR _0020)
		{
			return FMOD_Geometry_SetPosition(rawPtr, ref _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020(out VECTOR _0020)
		{
			return FMOD_Geometry_GetPosition(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A(ref VECTOR _0020)
		{
			return FMOD_Geometry_SetScale(rawPtr, ref _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020(out VECTOR _0020)
		{
			return FMOD_Geometry_GetScale(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A(IntPtr _0020, out int _0020_000A)
		{
			return FMOD_Geometry_Save(rawPtr, _0020, out _0020_000A);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_Geometry_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_Geometry_GetUserData(rawPtr, out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_Release(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_AddPolygon(IntPtr _0020, float _0020_000A, float _0020_0020, bool _0020_000A_000A, int _0020_000A_0020, VECTOR[] _0020_0020_000A, out int _0020_0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetNumPolygons(IntPtr _0020, out int _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetMaxPolygons(IntPtr _0020, out int _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetPolygonNumVertices(IntPtr _0020, int _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_SetPolygonVertex(IntPtr _0020, int _0020_000A, int _0020_0020, ref VECTOR _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetPolygonVertex(IntPtr _0020, int _0020_000A, int _0020_0020, out VECTOR _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_SetPolygonAttributes(IntPtr _0020, int _0020_000A, float _0020_0020, float _0020_000A_000A, bool _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetPolygonAttributes(IntPtr _0020, int _0020_000A, out float _0020_0020, out float _0020_000A_000A, out bool _0020_000A_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_SetActive(IntPtr _0020, bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetActive(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_SetRotation(IntPtr _0020, ref VECTOR _0020_000A, ref VECTOR _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetRotation(IntPtr _0020, out VECTOR _0020_000A, out VECTOR _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_SetPosition(IntPtr _0020, ref VECTOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetPosition(IntPtr _0020, out VECTOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_SetScale(IntPtr _0020, ref VECTOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetScale(IntPtr _0020, out VECTOR _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_Save(IntPtr _0020, IntPtr _0020_000A, out int _0020_0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Geometry_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		public _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020 : _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020
	{
		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		{
			RESULT num = FMOD_Reverb3D_Release(getRaw());
			if (num == RESULT.OK)
			{
				rawPtr = IntPtr.Zero;
			}
			return num;
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020(ref VECTOR _0020, float _0020_000A, float _0020_0020)
		{
			return FMOD_Reverb3D_Set3DAttributes(rawPtr, ref _0020, _0020_000A, _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A(ref VECTOR _0020, ref float _0020_000A, ref float _0020_0020)
		{
			return FMOD_Reverb3D_Get3DAttributes(rawPtr, ref _0020, ref _0020_000A, ref _0020_0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020(ref REVERB_PROPERTIES _0020)
		{
			return FMOD_Reverb3D_SetProperties(rawPtr, ref _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A(ref REVERB_PROPERTIES _0020)
		{
			return FMOD_Reverb3D_GetProperties(rawPtr, ref _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020(bool _0020)
		{
			return FMOD_Reverb3D_SetActive(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A(out bool _0020)
		{
			return FMOD_Reverb3D_GetActive(rawPtr, out _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020(IntPtr _0020)
		{
			return FMOD_Reverb3D_SetUserData(rawPtr, _0020);
		}

		internal RESULT _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(out IntPtr _0020)
		{
			return FMOD_Reverb3D_GetUserData(rawPtr, out _0020);
		}

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_Release(IntPtr _0020);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_Set3DAttributes(IntPtr _0020, ref VECTOR _0020_000A, float _0020_0020, float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_Get3DAttributes(IntPtr _0020, ref VECTOR _0020_000A, ref float _0020_0020, ref float _0020_000A_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_SetProperties(IntPtr _0020, ref REVERB_PROPERTIES _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_GetProperties(IntPtr _0020, ref REVERB_PROPERTIES _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_SetActive(IntPtr _0020, bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_GetActive(IntPtr _0020, out bool _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_SetUserData(IntPtr _0020, IntPtr _0020_000A);

		[DllImport("Library\\fmod_x64.dll")]
		private static extern RESULT FMOD_Reverb3D_GetUserData(IntPtr _0020, out IntPtr _0020_000A);

		public _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020(IntPtr raw)
			: base(raw)
		{
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020
	{
		internal static void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A(StringBuilder _0020, IntPtr _0020_000A)
		{
			byte[] array = new byte[_0020.Capacity];
			Marshal.Copy(_0020_000A, array, 0, _0020.Capacity);
			int num = Array.IndexOf(array, (byte)0);
			if (num > 0)
			{
				string @string = Encoding.UTF8.GetString(array, 0, num);
				_0020.Append(@string);
			}
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A
	{
		private int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020(decimal _0020)
		{
			string text = ((_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A)null)._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A;
			bool isDietModeEnabled = CapstoneDisassembler.IsDietModeEnabled;
			BinaryAnalizerControl._0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A((object)null);
			((_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020)null)._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A();
			return 1000435941;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A
	{
		private object _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020(ref int _0020, ref int _0020_000A)
		{
			_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020._0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A(null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A
	{
		private void _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020()
		{
			bool flag = _0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A;
			Module.IsDebugInstruction(null);
			_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A.CleanName(null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A
	{
		private string _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020(float _0020, OpImageSparseFetch _0020_000A, decimal _0020_0020)
		{
			return "1892482586";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A
	{
		private object _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020()
		{
			MainForm._0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A((object)null);
			((_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A)null)._0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020();
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A
	{
		private object _0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020, _0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 _0020_000A, int _0020_0020)
		{
			MatchState matchState = ((_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020)null)._0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A;
			return null;
		}
	}
}
