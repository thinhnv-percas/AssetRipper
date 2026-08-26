using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.IO.Compression;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	private const string s_resourcesName = "FxResources.System.IO.Compression.SR";

	private static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(ResourceType));

	internal static string ArgumentOutOfRange_Enum => GetResourceString("ArgumentOutOfRange_Enum", null);

	internal static string ArgumentOutOfRange_NeedPosNum => GetResourceString("ArgumentOutOfRange_NeedPosNum", null);

	internal static string CannotReadFromDeflateStream => GetResourceString("CannotReadFromDeflateStream", null);

	internal static string CannotWriteToDeflateStream => GetResourceString("CannotWriteToDeflateStream", null);

	internal static string GenericInvalidData => GetResourceString("GenericInvalidData", null);

	internal static string InvalidArgumentOffsetCount => GetResourceString("InvalidArgumentOffsetCount", null);

	internal static string InvalidBeginCall => GetResourceString("InvalidBeginCall", null);

	internal static string InvalidBlockLength => GetResourceString("InvalidBlockLength", null);

	internal static string InvalidHuffmanData => GetResourceString("InvalidHuffmanData", null);

	internal static string NotSupported => GetResourceString("NotSupported", null);

	internal static string NotSupported_UnreadableStream => GetResourceString("NotSupported_UnreadableStream", null);

	internal static string NotSupported_UnwritableStream => GetResourceString("NotSupported_UnwritableStream", null);

	internal static string ObjectDisposed_StreamClosed => GetResourceString("ObjectDisposed_StreamClosed", null);

	internal static string UnknownBlockType => GetResourceString("UnknownBlockType", null);

	internal static string UnknownState => GetResourceString("UnknownState", null);

	internal static string ZLibErrorDLLLoadError => GetResourceString("ZLibErrorDLLLoadError", null);

	internal static string ZLibErrorInconsistentStream => GetResourceString("ZLibErrorInconsistentStream", null);

	internal static string ZLibErrorIncorrectInitParameters => GetResourceString("ZLibErrorIncorrectInitParameters", null);

	internal static string ZLibErrorNotEnoughMemory => GetResourceString("ZLibErrorNotEnoughMemory", null);

	internal static string ZLibErrorVersionMismatch => GetResourceString("ZLibErrorVersionMismatch", null);

	internal static string ZLibErrorUnexpected => GetResourceString("ZLibErrorUnexpected", null);

	internal static string ArgumentNeedNonNegative => GetResourceString("ArgumentNeedNonNegative", null);

	internal static string CannotBeEmpty => GetResourceString("CannotBeEmpty", null);

	internal static string CDCorrupt => GetResourceString("CDCorrupt", null);

	internal static string CentralDirectoryInvalid => GetResourceString("CentralDirectoryInvalid", null);

	internal static string CreateInReadMode => GetResourceString("CreateInReadMode", null);

	internal static string CreateModeCapabilities => GetResourceString("CreateModeCapabilities", null);

	internal static string CreateModeCreateEntryWhileOpen => GetResourceString("CreateModeCreateEntryWhileOpen", null);

	internal static string CreateModeWriteOnceAndOneEntryAtATime => GetResourceString("CreateModeWriteOnceAndOneEntryAtATime", null);

	internal static string DateTimeOutOfRange => GetResourceString("DateTimeOutOfRange", null);

	internal static string DeletedEntry => GetResourceString("DeletedEntry", null);

	internal static string DeleteOnlyInUpdate => GetResourceString("DeleteOnlyInUpdate", null);

	internal static string DeleteOpenEntry => GetResourceString("DeleteOpenEntry", null);

	internal static string EntriesInCreateMode => GetResourceString("EntriesInCreateMode", null);

	internal static string EntryNameEncodingNotSupported => GetResourceString("EntryNameEncodingNotSupported", null);

	internal static string EntryNamesTooLong => GetResourceString("EntryNamesTooLong", null);

	internal static string EntryTooLarge => GetResourceString("EntryTooLarge", null);

	internal static string EOCDNotFound => GetResourceString("EOCDNotFound", null);

	internal static string FieldTooBigCompressedSize => GetResourceString("FieldTooBigCompressedSize", null);

	internal static string FieldTooBigLocalHeaderOffset => GetResourceString("FieldTooBigLocalHeaderOffset", null);

	internal static string FieldTooBigNumEntries => GetResourceString("FieldTooBigNumEntries", null);

	internal static string FieldTooBigOffsetToCD => GetResourceString("FieldTooBigOffsetToCD", null);

	internal static string FieldTooBigOffsetToZip64EOCD => GetResourceString("FieldTooBigOffsetToZip64EOCD", null);

	internal static string FieldTooBigStartDiskNumber => GetResourceString("FieldTooBigStartDiskNumber", null);

	internal static string FieldTooBigUncompressedSize => GetResourceString("FieldTooBigUncompressedSize", null);

	internal static string FrozenAfterWrite => GetResourceString("FrozenAfterWrite", null);

	internal static string HiddenStreamName => GetResourceString("HiddenStreamName", null);

	internal static string LengthAfterWrite => GetResourceString("LengthAfterWrite", null);

	internal static string LocalFileHeaderCorrupt => GetResourceString("LocalFileHeaderCorrupt", null);

	internal static string NumEntriesWrong => GetResourceString("NumEntriesWrong", null);

	internal static string OffsetLengthInvalid => GetResourceString("OffsetLengthInvalid", null);

	internal static string ReadingNotSupported => GetResourceString("ReadingNotSupported", null);

	internal static string ReadModeCapabilities => GetResourceString("ReadModeCapabilities", null);

	internal static string ReadOnlyArchive => GetResourceString("ReadOnlyArchive", null);

	internal static string SeekingNotSupported => GetResourceString("SeekingNotSupported", null);

	internal static string SetLengthRequiresSeekingAndWriting => GetResourceString("SetLengthRequiresSeekingAndWriting", null);

	internal static string SplitSpanned => GetResourceString("SplitSpanned", null);

	internal static string UnexpectedEndOfStream => GetResourceString("UnexpectedEndOfStream", null);

	internal static string UnsupportedCompression => GetResourceString("UnsupportedCompression", null);

	internal static string UnsupportedCompressionMethod => GetResourceString("UnsupportedCompressionMethod", null);

	internal static string UpdateModeCapabilities => GetResourceString("UpdateModeCapabilities", null);

	internal static string UpdateModeOneStream => GetResourceString("UpdateModeOneStream", null);

	internal static string WritingNotSupported => GetResourceString("WritingNotSupported", null);

	internal static string Zip64EOCDNotWhereExpected => GetResourceString("Zip64EOCDNotWhereExpected", null);

	internal static string Argument_InvalidPathChars => GetResourceString("Argument_InvalidPathChars", null);

	internal static Type ResourceType => typeof(SR);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string GetResourceString(string resourceKey, string defaultString)
	{
		string text = null;
		try
		{
			text = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		if (defaultString != null && resourceKey.Equals(text, StringComparison.Ordinal))
		{
			return defaultString;
		}
		return text;
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}
}
