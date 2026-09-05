using AssetRipper.Il2CppRestore.Binary;
using AssetRipper.Il2CppRestore.Metadata;

namespace AssetRipper.Il2CppRestore.Lift.Registration;

/// <summary>
/// Maps a method's metadata entry to where its native code actually lives, and estimates how long that
/// code runs for — global-metadata.dat has neither, by design (guide §7).
/// </summary>
public sealed class MethodAddressTable
{
	private readonly IBinaryImage _image;
	private readonly IReadOnlyDictionary<string, Il2CppCodeGenModule> _codeGenModules;

	public MethodAddressTable(IBinaryImage image, IReadOnlyDictionary<string, Il2CppCodeGenModule> codeGenModules)
	{
		_image = image;
		_codeGenModules = codeGenModules;
	}

	/// <summary>
	/// The VA of a method's body, or 0 when it has none (abstract, extern, or stripped).
	/// </summary>
	/// <remarks>
	/// From metadata v24.2 onward the index into <c>methodPointers</c> is the method's token's RID
	/// (record id, the low 24 bits), not its raw metadata array index — a detail that silently produces
	/// plausible-looking but wrong addresses if missed.
	/// </remarks>
	public ulong GetMethodPointer(string moduleName, Il2CppMethodDefinition method)
	{
		if (method.IsAbstract || !_codeGenModules.TryGetValue(moduleName, out Il2CppCodeGenModule? module))
		{
			return 0;
		}

		uint rid = method.token & 0x00FFFFFFu;
		if (rid == 0 || rid > module.MethodPointerCount)
		{
			return 0;
		}

		int pointerSize = _image.Is32Bit ? 4 : 8;
		long arrayOffset = _image.MapVaToOffset(module.MethodPointersVa);
		if (arrayOffset < 0)
		{
			return 0;
		}

		return _image.ReadPointer(arrayOffset + (long)(rid - 1) * pointerSize);
	}

	/// <summary>
	/// Every non-zero method pointer across every module, used to build the boundary table below.
	/// </summary>
	public IEnumerable<ulong> AllMethodPointers()
	{
		int pointerSize = _image.Is32Bit ? 4 : 8;
		foreach (Il2CppCodeGenModule module in _codeGenModules.Values)
		{
			long arrayOffset = _image.MapVaToOffset(module.MethodPointersVa);
			if (arrayOffset < 0)
			{
				continue;
			}
			for (uint i = 0; i < module.MethodPointerCount; i++)
			{
				ulong pointer = _image.ReadPointer(arrayOffset + (long)i * pointerSize);
				if (pointer != 0)
				{
					yield return pointer;
				}
			}
		}
	}

	/// <summary>
	/// Builds a VA -&gt; next-VA table used to estimate a function's length: the distance to whatever
	/// comes right after it in address order. Deliberately more inclusive than the boundary points DevX
	/// used (guide §7): invoker thunks and generic method instantiations sit interleaved with regular
	/// method bodies, and leaving either out overestimates neighboring functions' length, lifting well
	/// past their actual end into the next one.
	/// </summary>
	public SortedDictionary<ulong, ulong> BuildFunctionBoundaries()
	{
		SortedSet<ulong> boundaries = [];
		foreach (ulong va in AllMethodPointers())
		{
			boundaries.Add(va);
		}
		foreach (BinarySection section in _image.Sections)
		{
			if (section.Executable)
			{
				boundaries.Add(section.Va + (ulong)section.Size);
			}
		}

		SortedDictionary<ulong, ulong> result = [];
		ulong? previous = null;
		foreach (ulong va in boundaries)
		{
			if (previous is ulong p)
			{
				result[p] = va;
			}
			previous = va;
		}
		return result;
	}
}
