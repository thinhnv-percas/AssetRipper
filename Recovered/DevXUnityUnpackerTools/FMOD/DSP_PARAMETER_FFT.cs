using System;
using System.Runtime.InteropServices;

namespace FMOD
{
	public struct DSP_PARAMETER_FFT
	{
		public int length;

		public int numchannels;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private IntPtr[] _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020;

		public float[][] spectrum
		{
			get
			{
				float[][] array = new float[numchannels][];
				for (int i = 0; i < numchannels; i++)
				{
					array[i] = new float[length];
					Marshal.Copy(_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020[i], array[i], 0, length);
				}
				return array;
			}
		}
	}
}
