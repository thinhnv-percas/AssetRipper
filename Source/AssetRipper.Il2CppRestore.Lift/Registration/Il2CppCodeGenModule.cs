using AssetRipper.Il2CppRestore.Binary;

namespace AssetRipper.Il2CppRestore.Lift.Registration;

/// <summary>
/// One assembly's worth of native method addresses, reached through <c>Il2CppCodeRegistration.codeGenModules</c>.
/// </summary>
/// <remarks>
/// Only the leading fields are read at a fixed offset: <c>moduleName</c>, the method pointer table, the
/// adjustor thunk table, and <c>invokerIndices</c> — everything the guide's §7 (method address table)
/// and §7 "don't repeat DevX's function-length mistake" boundary calculation actually need. The fields
/// after that (rgctx ranges, debugger metadata, module initializer, static constructor indices, and
/// finally the per-assembly-mode <c>metadataRegistration</c>/<c>codeRegistaration</c> pointers) are not
/// given a concrete offset anywhere in the integration guide, and guessing one would silently misread
/// everything past it — exactly the failure mode §13.3 warns is expensive to notice. Per-assembly mode
/// detection is therefore left unimplemented rather than guessed at; see <see cref="ReadAll"/>.
/// </remarks>
public sealed class Il2CppCodeGenModule
{
	public required string ModuleName { get; init; }
	public required uint MethodPointerCount { get; init; }
	public required ulong MethodPointersVa { get; init; }
	public required uint AdjustorThunkCount { get; init; }
	public required ulong InvokerIndicesVa { get; init; }

	public static Il2CppCodeGenModule Read(IBinaryImage image, ulong va)
	{
		long offset = image.MapVaToOffset(va);
		int ptr = image.Is32Bit ? 4 : 8;

		ulong nameVa = image.ReadPointer(offset);
		string name = ReadCString(image, nameVa);

		uint methodPointerCount = (uint)image.ReadPointer(offset + ptr);
		ulong methodPointersVa = image.ReadPointer(offset + ptr * 2);
		uint adjustorThunkCount = (uint)image.ReadPointer(offset + ptr * 3);
		// adjustorThunks pointer sits at offset + ptr * 4; skipped over to reach invokerIndices.
		ulong invokerIndicesVa = image.ReadPointer(offset + ptr * 5);

		return new Il2CppCodeGenModule
		{
			ModuleName = name,
			MethodPointerCount = methodPointerCount,
			MethodPointersVa = methodPointersVa,
			AdjustorThunkCount = adjustorThunkCount,
			InvokerIndicesVa = invokerIndicesVa,
		};
	}

	/// <summary>
	/// Reads every <c>Il2CppCodeGenModule</c> pointed to by <c>Il2CppCodeRegistration.codeGenModules</c>.
	/// </summary>
	public static Dictionary<string, Il2CppCodeGenModule> ReadAll(IBinaryImage image, ulong codeRegistrationVa, int imageCount)
	{
		Dictionary<string, Il2CppCodeGenModule> byName = [];
		long structOffset = image.MapVaToOffset(codeRegistrationVa);
		if (structOffset < 0)
		{
			return byName;
		}

		int ptr = image.Is32Bit ? 4 : 8;
		// codeGenModulesCount/codeGenModules is the last (count, pointer) pair, 16 slots into the struct
		// — see RegistrationSearch.CodeRegistrationSlotsBeforeCodeGenModules.
		long countSlotOffset = structOffset + 16L * ptr;
		ulong modulesArrayVa = image.ReadPointer(countSlotOffset + ptr);
		long modulesArray = image.MapVaToOffset(modulesArrayVa);
		if (modulesArray < 0)
		{
			return byName;
		}

		for (int i = 0; i < imageCount; i++)
		{
			ulong moduleVa = image.ReadPointer(modulesArray + (long)i * ptr);
			if (moduleVa == 0)
			{
				continue;
			}
			Il2CppCodeGenModule module = Read(image, moduleVa);
			if (module.ModuleName.Length > 0)
			{
				byName[module.ModuleName] = module;
			}
		}

		return byName;
	}

	private static string ReadCString(IBinaryImage image, ulong va)
	{
		long offset = image.MapVaToOffset(va);
		if (offset < 0)
		{
			return "";
		}

		List<byte> bytes = [];
		ReadOnlySpan<byte> data = image.Data.Span;
		for (long i = offset; i < data.Length && data[(int)i] != 0; i++)
		{
			bytes.Add(data[(int)i]);
		}
		return System.Text.Encoding.UTF8.GetString(bytes.ToArray());
	}
}
