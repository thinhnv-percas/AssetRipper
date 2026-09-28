using System.Globalization;
using System.Text;
using AssetRipper.Import.Logging;
using Cpp2IL.Core.Model.Contexts;
using LibCpp2IL;
using LibCpp2IL.Metadata;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Writes what AssetRipper read out of the native binary, one fact per line, so that an independent
/// reader can check it.
/// </summary>
/// <remarks>
/// <para>
/// Every native fact the recovery rests on - where a method's body is, where a field sits, which
/// generic instantiation a shared body belongs to - comes from one reader, LibCpp2IL. Nothing in the
/// pipeline checks those facts against anything, so an error in the reader is indistinguishable from
/// a property of the game. <c>Test/Scripts/native_cross_oracle.py</c> reads the same tables with code
/// that shares nothing with LibCpp2IL and compares, and this is the other half of that comparison.
/// </para>
/// <para>
/// Only written when <c>CPP2IL_DUMP_NATIVE_FACTS</c> names a file, like every other dump in this
/// project: a measurement must not change the artefact it measures, and an ordinary rip has no use
/// for eighty thousand lines of addresses.
/// </para>
/// <para>
/// Two things are recorded for a method because they are two different facts. <c>module</c> is the
/// codegen module's own entry for the method's token, exactly as the binary holds it. <c>pointer</c>
/// is the address LibCpp2IL finally attributes, which consults the generic method table first - so
/// where they differ, a definition has been given the body of one of its instantiations. That is an
/// interpretation, and the cross-check has to be able to see it as one.
/// </para>
/// <para>
/// Field offsets are recorded <em>raw</em>, before the conversion into the value-type frame that
/// <see cref="Il2CppBinary.GetFieldOffsetFromIndex"/> performs. A cross-check compares what the binary
/// says before it compares what either reader made of it.
/// </para>
/// </remarks>
internal static class NativeFactsDump
{
	private static readonly string? DumpPath = Environment.GetEnvironmentVariable("CPP2IL_DUMP_NATIVE_FACTS");

	public static void WriteIfRequested(ApplicationAnalysisContext appContext)
	{
		if (string.IsNullOrEmpty(DumpPath))
		{
			return;
		}

		try
		{
			int lines = Write(appContext, DumpPath);
			Logger.Info(LogCategory.Import, $"Il2Cpp recovery: native facts: {lines} lines written to {DumpPath}.");
		}
		catch (Exception ex)
		{
			Logger.Warning(LogCategory.Import, $"Il2Cpp recovery: native facts could not be written: {ex.Message}");
		}
	}

	private static int Write(ApplicationAnalysisContext appContext, string path)
	{
		Il2CppBinary binary = appContext.Binary;
		Il2CppMetadata metadata = appContext.Metadata;
		int lines = 0;

		using StreamWriter writer = new(path, false, new UTF8Encoding(false));

		writer.WriteLine("{\"kind\":\"header\""
			+ $",\"metadataVersion\":{metadata.MetadataVersion.ToString(CultureInfo.InvariantCulture)}"
			+ $",\"pointerSize\":{binary.PointerSizeBytes}"
			+ $",\"binary\":{Quote(binary.GetType().Name)}"
			+ $",\"codeRegistration\":{Hex(binary.CodeRegistrationAddress)}"
			+ $",\"metadataRegistration\":{Hex(binary.MetadataRegistrationAddress)}"
			+ $",\"typeCount\":{metadata.typeDefs.Length}"
			+ $",\"methodCount\":{metadata.methodDefs.Length}"
			+ $",\"imageCount\":{metadata.imageDefinitions.Length}"
			+ $",\"genericMethodPointerCount\":{binary.GenericMethodPointers.Count}}}");
		lines++;

		for (int imageIndex = 0; imageIndex < metadata.imageDefinitions.Length; imageIndex++)
		{
			Il2CppImageDefinition image = metadata.imageDefinitions[imageIndex];
			string imageName = image.Name ?? "";
			int moduleIndex = binary.GetCodegenModuleIndexByName(imageName);
			ulong[] modulePointers = moduleIndex >= 0 ? binary.GetCodegenModuleMethodPointers(moduleIndex) : [];

			writer.WriteLine("{\"kind\":\"image\""
				+ $",\"index\":{imageIndex},\"name\":{Quote(imageName)}"
				+ $",\"typeStart\":{image.firstTypeIndex.Value},\"typeCount\":{image.typeCount}"
				+ $",\"module\":{moduleIndex},\"modulePointerCount\":{modulePointers.Length}}}");
			lines++;

			for (int t = 0; t < image.typeCount; t++)
			{
				int typeIndex = image.firstTypeIndex.Value + t;
				Il2CppTypeDefinition type = metadata.typeDefs[typeIndex];
				lines += WriteType(writer, binary, type, typeIndex, imageIndex);
				lines += WriteMethods(writer, metadata, type, typeIndex, imageIndex, modulePointers);
			}
		}

		IReadOnlyList<ulong> genericPointers = binary.GenericMethodPointers;

		for (int entry = 0; entry < (metadata.genericMethodTables?.Length ?? 0); entry++)
		{
			var table = metadata.genericMethodTables![entry];
			int specIndex = table.GenericMethodIndex;
			bool specReadable = specIndex >= 0 && specIndex < metadata.methodSpecs.Length;
			var spec = specReadable ? metadata.methodSpecs[specIndex] : null;
			ulong pointer = table.methodIndex >= 0 && table.methodIndex < genericPointers.Count ? genericPointers[table.methodIndex] : 0;

			writer.WriteLine("{\"kind\":\"generic\""
				+ $",\"index\":{entry},\"spec\":{specIndex}"
				+ $",\"method\":{(spec is null ? -1 : spec.methodDefinitionIndex.Value)}"
				+ $",\"classInst\":{(spec is null || spec.classIndexIndex.IsNull ? -1 : spec.classIndexIndex.Value)}"
				+ $",\"methodInst\":{(spec is null || spec.methodIndexIndex.IsNull ? -1 : spec.methodIndexIndex.Value)}"
				+ $",\"pointerIndex\":{table.methodIndex},\"pointer\":{Hex(pointer)}"
				+ $",\"invoker\":{table.invokerIndex},\"adjustor\":{table.adjustorThunk}}}");
			lines++;
		}

		return lines;
	}

	private static int WriteType(StreamWriter writer, Il2CppBinary binary, Il2CppTypeDefinition type, int typeIndex, int imageIndex)
	{
		StringBuilder fields = new();

		for (int f = 0; f < type.FieldCount; f++)
		{
			if (f > 0)
			{
				fields.Append(',');
			}

			int? raw = binary.ReadRawFieldOffset(typeIndex, f);
			fields.Append(raw.HasValue ? raw.Value.ToString(CultureInfo.InvariantCulture) : "null");
		}

		var sizes = binary.ReadTypeDefinitionSizes(typeIndex);
		string sizeText = sizes is null
			? "null"
			: $"[{sizes.instance_size},{sizes.native_size},{sizes.static_fields_size},{sizes.thread_static_fields_size}]";

		writer.WriteLine("{\"kind\":\"type\""
			+ $",\"index\":{typeIndex},\"image\":{imageIndex},\"name\":{Quote(type.FullName ?? "")}"
			+ $",\"valueType\":{(type.IsValueType ? "true" : "false")}"
			+ $",\"fieldStart\":{type.FirstFieldIdx.Value},\"fields\":[{fields}],\"sizes\":{sizeText}}}");
		return 1;
	}

	private static int WriteMethods(StreamWriter writer, Il2CppMetadata metadata, Il2CppTypeDefinition type, int typeIndex, int imageIndex, ulong[] modulePointers)
	{
		if (type.FirstMethodIdx.IsNull)
		{
			return 0;
		}

		int written = 0;

		for (int m = 0; m < type.MethodCount; m++)
		{
			int methodIndex = type.FirstMethodIdx.Value + m;
			Il2CppMethodDefinition method = metadata.methodDefs[methodIndex];
			uint rid = method.token & 0x00FFFFFFu;
			ulong module = rid > 0 && rid <= (uint)modulePointers.Length ? modulePointers[rid - 1] : 0;

			ulong pointer;
			try
			{
				pointer = method.MethodPointer;
			}
			catch
			{
				pointer = 0;
			}

			writer.WriteLine("{\"kind\":\"method\""
				+ $",\"index\":{methodIndex},\"type\":{typeIndex},\"image\":{imageIndex}"
				+ $",\"token\":\"0x{method.token:X8}\",\"name\":{Quote(method.Name ?? "")}"
				+ $",\"module\":{Hex(module)},\"pointer\":{Hex(pointer)}}}");
			written++;
		}

		return written;
	}

	private static string Hex(ulong value) => $"\"0x{value:X}\"";

	private static string Quote(string value)
	{
		StringBuilder builder = new(value.Length + 2);
		builder.Append('"');

		foreach (char c in value)
		{
			switch (c)
			{
				case '"': builder.Append("\\\""); break;
				case '\\': builder.Append("\\\\"); break;
				case < ' ': builder.Append($"\\u{(int)c:X4}"); break;
				default: builder.Append(c); break;
			}
		}

		builder.Append('"');
		return builder.ToString();
	}
}
