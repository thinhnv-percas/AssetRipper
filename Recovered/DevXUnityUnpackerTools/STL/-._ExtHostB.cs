using @as;
using DevXUnityUnpackerTools._WinForm;
using ICSharpCode.SharpZipLib.Zip;
using MiniLZO;
using SpirV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Unity.IO.Compression;
using Wasm.Interpret;

namespace STL
{
	internal static class STL___ExtHostB1
	{
	internal static void Shift(this IEnumerable<_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020> facets, float x, float y, float z)
	{
		_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.Shift(facets, x, y, z);
	}
	internal static void Shift(this IEnumerable<_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020> facets, _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A shift)
	{
		_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.Shift(facets, shift);
	}
	internal static void Shift(this IEnumerable<_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A> vertices, float x, float y, float z)
	{
		_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.Shift(vertices, x, y, z);
	}
	internal static void Shift(this IEnumerable<_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A> vertices, _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A shift)
	{
		_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.Shift(vertices, shift);
	}
	internal static void Invert(this IEnumerable<_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020> facets)
	{
		_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.Invert(facets);
	}
	internal static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
	{
		_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.ForEach<T>(items, action);
	}
	internal static bool All<T>(this IEnumerable<T> items, Func<int, T, bool> predicate)
	{
		return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.All<T>(items, predicate);
	}
	internal static bool IsNullOrEmpty(this string value)
	{
		return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.IsNullOrEmpty(value);
	}
	internal static string Interpolate(this string format, params object[] args)
	{
		return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.Interpolate(format, args);
	}
	internal static string Interpolate(this string format, CultureInfo culture, params object[] args)
	{
		return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020.Interpolate(format, culture, args);
	}
	}
}
