using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace DecompTools.Decompiler.Metadata;

internal class MethodSemanticsLookup
{
	private readonly struct Entry : IComparable<Entry>
	{
		public readonly MethodSemanticsAttributes Semantics;

		public readonly int MethodRowNumber;

		public readonly EntityHandle Association;

		public MethodDefinitionHandle Method => MetadataTokens.MethodDefinitionHandle(MethodRowNumber);

		public Entry(MethodSemanticsAttributes semantics, MethodDefinitionHandle method, EntityHandle association)
		{
			Semantics = semantics;
			MethodRowNumber = MetadataTokens.GetRowNumber(method);
			Association = association;
		}

		public int CompareTo(Entry other)
		{
			int methodRowNumber = MethodRowNumber;
			return methodRowNumber.CompareTo(other.MethodRowNumber);
		}
	}

	private const MethodSemanticsAttributes csharpAccessors = MethodSemanticsAttributes.Setter | MethodSemanticsAttributes.Getter | MethodSemanticsAttributes.Adder | MethodSemanticsAttributes.Remover;

	private readonly List<Entry> entries;

	public MethodSemanticsLookup(MetadataReader metadata, MethodSemanticsAttributes filter = MethodSemanticsAttributes.Setter | MethodSemanticsAttributes.Getter | MethodSemanticsAttributes.Adder | MethodSemanticsAttributes.Remover)
	{
		MethodSemanticsLookup methodSemanticsLookup = this;
		if ((filter & MethodSemanticsAttributes.Other) != 0)
		{
			throw new NotSupportedException("SRM doesn't provide access to 'other' accessors");
		}
		entries = new List<Entry>(metadata.GetTableRowCount(TableIndex.MethodSemantics));
		foreach (PropertyDefinitionHandle propertyDefinition in metadata.PropertyDefinitions)
		{
			PropertyAccessors accessors = metadata.GetPropertyDefinition(propertyDefinition).GetAccessors();
			AddEntry(MethodSemanticsAttributes.Getter, accessors.Getter, propertyDefinition);
			AddEntry(MethodSemanticsAttributes.Setter, accessors.Setter, propertyDefinition);
		}
		foreach (EventDefinitionHandle eventDefinition in metadata.EventDefinitions)
		{
			EventAccessors accessors2 = metadata.GetEventDefinition(eventDefinition).GetAccessors();
			AddEntry(MethodSemanticsAttributes.Adder, accessors2.Adder, eventDefinition);
			AddEntry(MethodSemanticsAttributes.Remover, accessors2.Remover, eventDefinition);
			AddEntry(MethodSemanticsAttributes.Raiser, accessors2.Raiser, eventDefinition);
		}
		entries.Sort();
		void AddEntry(MethodSemanticsAttributes semantics, MethodDefinitionHandle method, EntityHandle association)
		{
			if ((semantics & filter) != 0 && !method.IsNil)
			{
				entries.Add(new Entry(semantics, method, association));
			}
		}
	}

	public (EntityHandle, MethodSemanticsAttributes) GetSemantics(MethodDefinitionHandle method)
	{
		int num = entries.BinarySearch(new Entry((MethodSemanticsAttributes)0, method, default(EntityHandle)));
		if (num >= 0)
		{
			return (entries[num].Association, entries[num].Semantics);
		}
		return (default(EntityHandle), (MethodSemanticsAttributes)0);
	}
}
