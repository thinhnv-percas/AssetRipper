using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class MethodExtents
{
	private readonly Dictionary<DocumentId, ImmutableArray<MethodLineExtent>> _extentsByDocument;

	private Dictionary<DocumentId, ImmutableArray<ImmutableArray<MethodLineExtent>>> _lazyPartitionedExtentsByDocument = new Dictionary<DocumentId, ImmutableArray<ImmutableArray<MethodLineExtent>>>();

	public MethodExtents(PortablePdbReader pdbReader)
	{
		_extentsByDocument = GroupExtentsByDocument(GetMethodExtents(pdbReader));
	}

	internal void Update(PortablePdbReader pdbReader, MethodDebugInformationHandle methodHandle, ImmutableArray<int> deltas, int expectedSequencePointCount)
	{
		foreach (var (key, immutableArray2) in GroupExtentsByDocument(GetMethodExtents(pdbReader, methodHandle, deltas, expectedSequencePointCount)))
		{
			_extentsByDocument[key] = UpdateExtent(_extentsByDocument[key], immutableArray2.Single());
		}
	}

	private ImmutableArray<MethodLineExtent> UpdateExtent(ImmutableArray<MethodLineExtent> extents, MethodLineExtent newExtent)
	{
		int index = extents.BinarySearch(newExtent, (MethodLineExtent x, MethodLineExtent y) => x.Method.CompareTo(y.Method));
		return extents.SetItem(index, newExtent);
	}

	internal void Update(PortablePdbReader pdbReader, Dictionary<DocumentId, List<(MethodId, int)>> lineDeltasByDocument)
	{
		DocumentId key;
		foreach (KeyValuePair<DocumentId, List<(MethodId, int)>> item in lineDeltasByDocument)
		{
			KeyValuePair.Deconstruct(item, out key, out var value);
			DocumentId key2 = key;
			List<(MethodId, int)> deltas = value;
			_extentsByDocument[key2] = ApplyDeltas(_extentsByDocument[key2], deltas);
		}
		Dictionary<DocumentId, ImmutableArray<MethodLineExtent>> dictionary = GroupExtentsByDocument(GetMethodExtents(pdbReader));
		foreach (KeyValuePair<DocumentId, ImmutableArray<MethodLineExtent>> item2 in dictionary)
		{
			KeyValuePair.Deconstruct(item2, out key, out var value2);
			DocumentId key3 = key;
			ImmutableArray<MethodLineExtent> immutableArray = value2;
			if (_extentsByDocument.TryGetValue(key3, out var value3))
			{
				_extentsByDocument[key3] = MergeExtents(value3, immutableArray);
			}
			else
			{
				_extentsByDocument[key3] = immutableArray;
			}
		}
		lock (_lazyPartitionedExtentsByDocument)
		{
			foreach (DocumentId key4 in lineDeltasByDocument.Keys)
			{
				_lazyPartitionedExtentsByDocument.Remove(key4);
			}
			foreach (DocumentId key5 in dictionary.Keys)
			{
				_lazyPartitionedExtentsByDocument.Remove(key5);
			}
		}
	}

	private static ImmutableArray<MethodLineExtent> ApplyDeltas(ImmutableArray<MethodLineExtent> extents, List<(MethodId Method, int Delta)> deltas)
	{
		ImmutableArray<MethodLineExtent>.Builder builder = ImmutableArray.CreateBuilder<MethodLineExtent>(extents.Length);
		int num = 0;
		int num2 = 0;
		while (num < extents.Length && num2 < deltas.Count)
		{
			if (extents[num].Method == deltas[num2].Method)
			{
				builder.Add(extents[num].ApplyDelta(deltas[num2].Delta));
				num++;
				num2++;
			}
			else if (extents[num].Method < deltas[num2].Method)
			{
				builder.Add(extents[num]);
				num++;
			}
			else
			{
				num2++;
			}
		}
		builder.AddSubRange(extents, num);
		return builder.MoveToImmutable();
	}

	private ImmutableArray<MethodLineExtent> MergeExtents(ImmutableArray<MethodLineExtent> existingExtents, ImmutableArray<MethodLineExtent> newExtents)
	{
		ImmutableArray<MethodLineExtent>.Builder builder = ImmutableArray.CreateBuilder<MethodLineExtent>();
		int num = 0;
		int num2 = 0;
		while (num < existingExtents.Length && num2 < newExtents.Length)
		{
			if (existingExtents[num].Method == newExtents[num2].Method)
			{
				builder.Add(newExtents[num2]);
				num++;
				num2++;
			}
			else if (existingExtents[num].Method < newExtents[num2].Method)
			{
				builder.Add(existingExtents[num]);
				num++;
			}
			else
			{
				builder.Add(newExtents[num2]);
				num2++;
			}
		}
		builder.AddSubRange(existingExtents, num);
		builder.AddSubRange(newExtents, num2);
		return builder.ToImmutable();
	}

	private static Dictionary<DocumentId, ImmutableArray<MethodLineExtent>> GroupExtentsByDocument(IEnumerable<(DocumentId DocumentId, MethodLineExtent Extent)> methodExtents)
	{
		Dictionary<DocumentId, ImmutableArray<MethodLineExtent>.Builder> dictionary = new Dictionary<DocumentId, ImmutableArray<MethodLineExtent>.Builder>();
		foreach (var (key, item) in methodExtents)
		{
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = (dictionary[key] = ImmutableArray.CreateBuilder<MethodLineExtent>());
			}
			value.Add(item);
		}
		Dictionary<DocumentId, ImmutableArray<MethodLineExtent>> dictionary2 = new Dictionary<DocumentId, ImmutableArray<MethodLineExtent>>(dictionary.Count);
		foreach (var (key2, builder3) in dictionary)
		{
			builder3.Sort(MethodLineExtent.MethodComparer.Instance);
			int num = 0;
			for (int i = 1; i < builder3.Count; i++)
			{
				if (builder3[i].Method == builder3[num].Method)
				{
					builder3[num] = MethodLineExtent.Merge(builder3[i], builder3[num]);
					continue;
				}
				num++;
				if (num < i)
				{
					builder3[num] = builder3[i];
				}
			}
			builder3.Count = num + 1;
			dictionary2.Add(key2, builder3.ToImmutable());
		}
		return dictionary2;
	}

	private bool TryGetPartitionedExtents(DocumentId documentId, out ImmutableArray<ImmutableArray<MethodLineExtent>> partitionedExtents)
	{
		lock (_lazyPartitionedExtentsByDocument)
		{
			if (_lazyPartitionedExtentsByDocument.TryGetValue(documentId, out partitionedExtents))
			{
				return true;
			}
		}
		if (!_extentsByDocument.TryGetValue(documentId, out var value))
		{
			partitionedExtents = default(ImmutableArray<ImmutableArray<MethodLineExtent>>);
			return false;
		}
		partitionedExtents = PartitionToNonOverlappingSubsequences(value);
		lock (_lazyPartitionedExtentsByDocument)
		{
			_lazyPartitionedExtentsByDocument[documentId] = partitionedExtents;
		}
		return true;
	}

	private static ImmutableArray<ImmutableArray<MethodLineExtent>> PartitionToNonOverlappingSubsequences(ImmutableArray<MethodLineExtent> extents)
	{
		ImmutableArray<MethodLineExtent> immutableArray = extents.Sort(MethodLineExtent.MinLineComparer.Instance);
		ImmutableArray<ImmutableArray<MethodLineExtent>.Builder>.Builder builder = ImmutableArray.CreateBuilder<ImmutableArray<MethodLineExtent>.Builder>();
		foreach (MethodLineExtent item in immutableArray)
		{
			bool flag = false;
			foreach (ImmutableArray<MethodLineExtent>.Builder item2 in builder)
			{
				if (item2.Count == 0 || item.MinLine > item2[item2.Count - 1].MaxLine)
				{
					item2.Add(item);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				ImmutableArray<MethodLineExtent>.Builder builder2 = ImmutableArray.CreateBuilder<MethodLineExtent>();
				builder2.Add(item);
				builder.Add(builder2);
			}
		}
		ImmutableArray<ImmutableArray<MethodLineExtent>>.Builder builder3 = ImmutableArray.CreateBuilder<ImmutableArray<MethodLineExtent>>();
		foreach (ImmutableArray<MethodLineExtent>.Builder item3 in builder)
		{
			builder3.Add(item3.ToImmutable());
		}
		return builder3.ToImmutable();
	}

	private static IEnumerable<(DocumentId, MethodLineExtent)> GetMethodExtents(PortablePdbReader pdbReader)
	{
		foreach (MethodDebugInformationHandle item in pdbReader.MetadataReader.MethodDebugInformation)
		{
			foreach (var methodExtent in GetMethodExtents(pdbReader, item))
			{
				yield return methodExtent;
			}
		}
	}

	private static IEnumerable<(DocumentId, MethodLineExtent)> GetMethodExtents(PortablePdbReader pdbReader, MethodDebugInformationHandle methodDebugHandle, ImmutableArray<int> lineDeltasOpt = default(ImmutableArray<int>), int expectedSequencePointCount = -1)
	{
		MetadataReader metadataReader = pdbReader.MetadataReader;
		int version = pdbReader.Version;
		MethodDebugInformation methodDebugInformation = metadataReader.GetMethodDebugInformation(methodDebugHandle);
		if (methodDebugInformation.SequencePointsBlob.IsNil)
		{
			yield break;
		}
		DocumentHandle document = methodDebugInformation.Document;
		MethodId methodId = pdbReader.GetMethodId(methodDebugHandle);
		int sequencePointIndex = 0;
		int num = int.MaxValue;
		int num2 = int.MinValue;
		foreach (SequencePoint sequencePoint in methodDebugInformation.GetSequencePoints())
		{
			if (sequencePoint.IsHidden)
			{
				sequencePointIndex++;
				continue;
			}
			int startLine = sequencePoint.StartLine;
			int endLine = sequencePoint.EndLine;
			if (!lineDeltasOpt.IsDefault && sequencePointIndex < lineDeltasOpt.Length)
			{
				int num3 = lineDeltasOpt[sequencePointIndex];
				startLine += num3;
				endLine += num3;
			}
			if (sequencePoint.Document != document)
			{
				if (!document.IsNil)
				{
					yield return (pdbReader.GetDocumentId(document), new MethodLineExtent(methodId, version, num, num2));
				}
				document = sequencePoint.Document;
				num = startLine;
				num2 = endLine;
			}
			else
			{
				if (startLine < num)
				{
					num = startLine;
				}
				if (endLine > num2)
				{
					num2 = endLine;
				}
			}
			sequencePointIndex++;
		}
		if (!document.IsNil)
		{
			yield return (pdbReader.GetDocumentId(document), new MethodLineExtent(methodId, version, num, num2));
		}
		if (expectedSequencePointCount >= 0 && sequencePointIndex != expectedSequencePointCount)
		{
			throw new InvalidInputDataException();
		}
	}

	internal static (DocumentHandle Single, IEnumerable<DocumentHandle> Multiple) GetMethodBodyDocuments(MetadataReader reader, MethodDebugInformationHandle handle)
	{
		MethodDebugInformation debugInfo = reader.GetMethodDebugInformation(handle);
		if (debugInfo.SequencePointsBlob.IsNil)
		{
			return (Single: default(DocumentHandle), Multiple: null);
		}
		if (!debugInfo.Document.IsNil)
		{
			return (Single: debugInfo.Document, Multiple: null);
		}
		return (Single: default(DocumentHandle), Multiple: Multiple());
		IEnumerable<DocumentHandle> Multiple()
		{
			DocumentHandle document = debugInfo.Document;
			foreach (SequencePoint sequencePoint in debugInfo.GetSequencePoints())
			{
				if (!sequencePoint.IsHidden && sequencePoint.Document != document)
				{
					if (!document.IsNil)
					{
						yield return document;
					}
					document = sequencePoint.Document;
				}
			}
			if (!document.IsNil)
			{
				yield return document;
			}
		}
	}

	internal IEnumerable<(MethodId Id, int Version)> GetMethodsContainingLine(DocumentId documentId, int line)
	{
		if (!TryGetPartitionedExtents(documentId, out var partitionedExtents))
		{
			return null;
		}
		return EnumerateMethodsContainingLine(partitionedExtents, line);
	}

	private static IEnumerable<(MethodId Id, int Version)> EnumerateMethodsContainingLine(ImmutableArray<ImmutableArray<MethodLineExtent>> extents, int line)
	{
		foreach (ImmutableArray<MethodLineExtent> item in extents)
		{
			int num = IndexOfContainingExtent(item, line, out var _);
			if (num >= 0)
			{
				yield return (Id: item[num].Method, Version: item[num].Version);
			}
		}
	}

	private static int IndexOfContainingExtent(ImmutableArray<MethodLineExtent> orderedNonOverlappingExtents, int startLine, out int closestFollowingExtent)
	{
		closestFollowingExtent = -1;
		int num = orderedNonOverlappingExtents.BinarySearch(startLine, (MethodLineExtent extent, int line) => extent.MinLine - line);
		if (num >= 0)
		{
			return num;
		}
		int num2 = ~num - 1;
		if (num2 >= 0 && startLine <= orderedNonOverlappingExtents[num2].MaxLine)
		{
			return num2;
		}
		closestFollowingExtent = ~num;
		return -1;
	}

	internal ImmutableArray<MethodLineExtent> GetMethodExtents(DocumentId documentId)
	{
		if (!_extentsByDocument.TryGetValue(documentId, out var value))
		{
			return ImmutableArray<MethodLineExtent>.Empty;
		}
		return value;
	}

	internal bool TryGetMethodSourceExtent(DocumentId documentId, MethodId methodId, out int startLine, out int endLine)
	{
		if (!_extentsByDocument.TryGetValue(documentId, out var value))
		{
			startLine = (endLine = 0);
			return false;
		}
		int num = value.BinarySearch(methodId, (MethodLineExtent ext, MethodId id) => ext.Method.CompareTo(id));
		if (num < 0)
		{
			startLine = (endLine = 0);
			return false;
		}
		MethodLineExtent methodLineExtent = value[num];
		startLine = methodLineExtent.MinLine;
		endLine = methodLineExtent.MaxLine;
		return true;
	}

	internal IEnumerable<MethodLineExtent> EnumerateContainingOrClosestFollowingMethodExtents(DocumentId documentId, int line)
	{
		if (!TryGetPartitionedExtents(documentId, out var partitionedExtents))
		{
			yield break;
		}
		foreach (ImmutableArray<MethodLineExtent> item in partitionedExtents)
		{
			int num = IndexOfContainingExtent(item, line, out var closestFollowingExtent);
			if (num >= 0)
			{
				yield return item[num];
			}
			else if (closestFollowingExtent < item.Length)
			{
				yield return item[closestFollowingExtent];
			}
		}
	}
}
