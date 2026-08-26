using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class MethodMap
{
	[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
	internal struct MethodInfo
	{
		public readonly MethodDebugInformationHandle Handle;

		public readonly int Version;

		public MethodInfo(MethodDebugInformationHandle handle, int version)
		{
			Handle = handle;
			Version = version;
		}

		private object GetDebuggerDisplay()
		{
			return string.Format("{0:X8} v{1}", new object[2]
			{
				MetadataTokens.GetToken(Handle),
				Version
			});
		}
	}

	private List<MethodInfo> _lazyInfos;

	private readonly int _baselineMethodCount;

	public MethodMap(PortablePdbReader pdbReader)
	{
		_baselineMethodCount = pdbReader.MetadataReader.MethodDebugInformation.Count;
	}

	internal void Update(SymReader symReader, MetadataReader reader, int version, out ImmutableArray<MethodId> handleToIdMap)
	{
		if (_lazyInfos == null)
		{
			_lazyInfos = new List<MethodInfo>();
			foreach (MethodDebugInformationHandle item in symReader.GetReader(1).MetadataReader.MethodDebugInformation)
			{
				_lazyInfos.Add(new MethodInfo(item, 1));
			}
		}
		handleToIdMap = CreateHandleToIdMap(reader, _lazyInfos, version);
	}

	internal MethodInfo GetInfo(MethodId methodId)
	{
		int value = methodId.Value;
		if (_lazyInfos == null)
		{
			return new MethodInfo(MetadataTokens.MethodDebugInformationHandle(value), 1);
		}
		return _lazyInfos[value - 1];
	}

	internal bool IsValidMethodId(MethodId id)
	{
		return IsValidMethodRowId(id.Value);
	}

	internal bool IsValidMethodRowId(int rowId)
	{
		if (rowId > _baselineMethodCount)
		{
			if (_lazyInfos != null)
			{
				return rowId <= _lazyInfos.Count;
			}
			return false;
		}
		return true;
	}

	internal bool IsValidMethodToken(int token)
	{
		if (MetadataUtilities.IsMethodToken(token))
		{
			return IsValidMethodRowId(MetadataUtilities.GetRowId(token));
		}
		return false;
	}

	private static ImmutableArray<MethodId> CreateHandleToIdMap(MetadataReader reader, List<MethodInfo> infos, int version)
	{
		ImmutableArray<MethodId>.Builder builder = ImmutableArray.CreateBuilder<MethodId>(reader.MethodDebugInformation.Count);
		foreach (EntityHandle editAndContinueMapEntry in reader.GetEditAndContinueMapEntries())
		{
			if (editAndContinueMapEntry.Kind == HandleKind.MethodDebugInformation)
			{
				MethodId item = new MethodId(MetadataTokens.GetRowNumber(editAndContinueMapEntry));
				builder.Add(item);
				MethodDebugInformationHandle handle = MetadataTokens.MethodDebugInformationHandle(builder.Count);
				int num = item.Value - 1;
				while (infos.Count <= num)
				{
					infos.Add(default(MethodInfo));
				}
				infos[num] = new MethodInfo(handle, version);
			}
		}
		return builder.MoveToImmutable();
	}
}
