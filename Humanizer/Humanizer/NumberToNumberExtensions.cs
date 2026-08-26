using System.Runtime.CompilerServices;

namespace Humanizer;

public static class NumberToNumberExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Tens(this int input)
	{
		return input * 10;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Tens(this uint input)
	{
		return input * 10;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long Tens(this long input)
	{
		return input * 10;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong Tens(this ulong input)
	{
		return input * 10;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Tens(this double input)
	{
		return input * 10.0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Hundreds(this int input)
	{
		return input * 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Hundreds(this uint input)
	{
		return input * 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long Hundreds(this long input)
	{
		return input * 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong Hundreds(this ulong input)
	{
		return input * 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Hundreds(this double input)
	{
		return input * 100.0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Thousands(this int input)
	{
		return input * 1000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Thousands(this uint input)
	{
		return input * 1000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long Thousands(this long input)
	{
		return input * 1000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong Thousands(this ulong input)
	{
		return input * 1000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Thousands(this double input)
	{
		return input * 1000.0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Millions(this int input)
	{
		return input * 1000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Millions(this uint input)
	{
		return input * 1000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long Millions(this long input)
	{
		return input * 1000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong Millions(this ulong input)
	{
		return input * 1000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Millions(this double input)
	{
		return input * 1000000.0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Billions(this int input)
	{
		return input * 1000000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Billions(this uint input)
	{
		return input * 1000000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long Billions(this long input)
	{
		return input * 1000000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong Billions(this ulong input)
	{
		return input * 1000000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Billions(this double input)
	{
		return input * 1000000000.0;
	}
}
