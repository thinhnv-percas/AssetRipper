using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class CachedCatalog
{
	private class SerializationContext : SerializationContextBase
	{
		private enum ConstraintTypes
		{
			ImportMetadataViewConstraint,
			ExportTypeIdentityConstraint,
			PartCreationPolicyConstraint,
			ExportMetadataValueImportConstraint
		}

		internal SerializationContext(BinaryReader reader, Resolver resolver)
			: base(reader, resolver)
		{
		}

		internal SerializationContext(BinaryWriter writer, int estimatedObjectCount, Resolver resolver)
			: base(writer, estimatedObjectCount, resolver)
		{
		}

		internal void Write(ComposableCatalog catalog)
		{
			using (Trace("Catalog"))
			{
				Write(catalog.Parts, Write);
			}
		}

		internal ComposableCatalog ReadComposableCatalog()
		{
			using (Trace("Catalog"))
			{
				IReadOnlyList<ComposablePartDefinition> parts = ReadList(ReadComposablePartDefinition);
				return ComposableCatalog.Create(base.Resolver).AddParts(parts);
			}
		}

		private void Write(ComposablePartDefinition partDefinition)
		{
			using (Trace("ComposablePartDefinition"))
			{
				Write(partDefinition.TypeRef);
				Write(partDefinition.Metadata);
				Write(partDefinition.ExportedTypes, Write);
				WriteCompressedUInt((uint)partDefinition.ExportingMembers.Count);
				foreach (KeyValuePair<MemberRef, IReadOnlyCollection<ExportDefinition>> exportingMember in partDefinition.ExportingMembers)
				{
					Write(exportingMember.Key);
					Write(exportingMember.Value, Write);
				}
				Write(partDefinition.ImportingMembers, Write);
				Write(partDefinition.SharingBoundary);
				Write(partDefinition.OnImportsSatisfiedRef);
				if (partDefinition.ImportingConstructorRef.IsEmpty)
				{
					writer.Write(value: false);
				}
				else
				{
					writer.Write(value: true);
					Write(partDefinition.ImportingConstructorRef);
					Write(partDefinition.ImportingConstructorImports, Write);
				}
				Write(partDefinition.CreationPolicy);
				writer.Write(partDefinition.IsSharingBoundaryInferred);
			}
		}

		private ComposablePartDefinition ReadComposablePartDefinition()
		{
			using (Trace("ComposablePartDefinition"))
			{
				TypeRef partType = ReadTypeRef();
				IReadOnlyDictionary<string, object> metadata = ReadMetadata();
				IReadOnlyList<ExportDefinition> exportedTypes = ReadList(ReadExportDefinition);
				ImmutableDictionary<MemberRef, IReadOnlyCollection<ExportDefinition>>.Builder builder = ImmutableDictionary.CreateBuilder<MemberRef, IReadOnlyCollection<ExportDefinition>>();
				uint num = ReadCompressedUInt();
				for (int i = 0; i < num; i++)
				{
					MemberRef key = ReadMemberRef();
					IReadOnlyList<ExportDefinition> value = ReadList(ReadExportDefinition);
					builder.Add(key, value);
				}
				IReadOnlyList<ImportDefinitionBinding> importingMembers = ReadList(ReadImportDefinitionBinding);
				string sharingBoundary = ReadString();
				MethodRef onImportsSatisfied = ReadMethodRef();
				ConstructorRef importingConstructorRef = default(ConstructorRef);
				IReadOnlyList<ImportDefinitionBinding> importingConstructorImports = null;
				if (reader.ReadBoolean())
				{
					importingConstructorRef = ReadConstructorRef();
					importingConstructorImports = ReadList(ReadImportDefinitionBinding);
				}
				CreationPolicy partCreationPolicy = ReadCreationPolicy();
				bool isSharingBoundaryInferred = reader.ReadBoolean();
				return new ComposablePartDefinition(partType, metadata, exportedTypes, builder, importingMembers, sharingBoundary, onImportsSatisfied, importingConstructorRef, importingConstructorImports, partCreationPolicy, isSharingBoundaryInferred);
			}
		}

		private void Write(CreationPolicy creationPolicy)
		{
			using (Trace("CreationPolicy"))
			{
				writer.Write((byte)creationPolicy);
			}
		}

		private CreationPolicy ReadCreationPolicy()
		{
			using (Trace("CreationPolicy"))
			{
				return (CreationPolicy)reader.ReadByte();
			}
		}

		private void Write(ExportDefinition exportDefinition)
		{
			using (Trace("ExportDefinition"))
			{
				Write(exportDefinition.ContractName);
				Write(exportDefinition.Metadata);
			}
		}

		private ExportDefinition ReadExportDefinition()
		{
			using (Trace("ExportDefinition"))
			{
				string contractName = ReadString();
				IReadOnlyDictionary<string, object> metadata = ReadMetadata();
				return new ExportDefinition(contractName, metadata);
			}
		}

		private void Write(ImportDefinition importDefinition)
		{
			using (Trace("ImportDefinition"))
			{
				Write(importDefinition.ContractName);
				Write(importDefinition.Cardinality);
				Write(importDefinition.Metadata);
				Write(importDefinition.ExportConstraints, Write);
				Write(importDefinition.ExportFactorySharingBoundaries, base.Write);
			}
		}

		private ImportDefinition ReadImportDefinition()
		{
			using (Trace("ImportDefinition"))
			{
				string contractName = ReadString();
				ImportCardinality cardinality = ReadImportCardinality();
				IReadOnlyDictionary<string, object> metadata = ReadMetadata();
				IReadOnlyList<IImportSatisfiabilityConstraint> additionalConstraints = ReadList(ReadIImportSatisfiabilityConstraint);
				IReadOnlyList<string> exportFactorySharingBoundaries = ReadList(base.ReadString);
				return new ImportDefinition(contractName, cardinality, metadata, additionalConstraints, exportFactorySharingBoundaries);
			}
		}

		private void Write(ImportDefinitionBinding importDefinitionBinding)
		{
			using (Trace("ImportDefinitionBinding"))
			{
				Write(importDefinitionBinding.ImportDefinition);
				Write(importDefinitionBinding.ComposablePartTypeRef);
				if (importDefinitionBinding.ImportingMemberRef.IsEmpty)
				{
					writer.Write(value: false);
					Write(importDefinitionBinding.ImportingParameterRef);
				}
				else
				{
					writer.Write(value: true);
					Write(importDefinitionBinding.ImportingMemberRef);
				}
			}
		}

		private ImportDefinitionBinding ReadImportDefinitionBinding()
		{
			using (Trace("ImportDefinitionBinding"))
			{
				ImportDefinition importDefinition = ReadImportDefinition();
				TypeRef composablePartType = ReadTypeRef();
				if (reader.ReadBoolean())
				{
					MemberRef importingMember = ReadMemberRef();
					return new ImportDefinitionBinding(importDefinition, composablePartType, importingMember);
				}
				ParameterRef importingConstructorParameter = ReadParameterRef();
				return new ImportDefinitionBinding(importDefinition, composablePartType, importingConstructorParameter);
			}
		}

		private void Write(IImportSatisfiabilityConstraint importConstraint)
		{
			using (Trace("IImportSatisfiabilityConstraint"))
			{
				ConstraintTypes constraintTypes;
				if (importConstraint is ImportMetadataViewConstraint)
				{
					constraintTypes = ConstraintTypes.ImportMetadataViewConstraint;
				}
				else if (importConstraint is ExportTypeIdentityConstraint)
				{
					constraintTypes = ConstraintTypes.ExportTypeIdentityConstraint;
				}
				else if (importConstraint is PartCreationPolicyConstraint)
				{
					constraintTypes = ConstraintTypes.PartCreationPolicyConstraint;
				}
				else
				{
					if (!(importConstraint is ExportMetadataValueImportConstraint))
					{
						throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Strings.ImportConstraintTypeNotSupported, new object[1] { importConstraint.GetType().FullName }));
					}
					constraintTypes = ConstraintTypes.ExportMetadataValueImportConstraint;
				}
				writer.Write((byte)constraintTypes);
				switch (constraintTypes)
				{
				case ConstraintTypes.ImportMetadataViewConstraint:
				{
					ImportMetadataViewConstraint importMetadataViewConstraint = (ImportMetadataViewConstraint)importConstraint;
					WriteCompressedUInt((uint)importMetadataViewConstraint.Requirements.Count);
					{
						foreach (KeyValuePair<string, ImportMetadataViewConstraint.MetadatumRequirement> requirement in importMetadataViewConstraint.Requirements)
						{
							Write(requirement.Key);
							Write(requirement.Value.MetadatumValueTypeRef);
							writer.Write(requirement.Value.IsMetadataumValueRequired);
						}
						break;
					}
				}
				case ConstraintTypes.ExportTypeIdentityConstraint:
				{
					ExportTypeIdentityConstraint exportTypeIdentityConstraint = (ExportTypeIdentityConstraint)importConstraint;
					Write(exportTypeIdentityConstraint.TypeIdentityName);
					break;
				}
				case ConstraintTypes.PartCreationPolicyConstraint:
				{
					PartCreationPolicyConstraint partCreationPolicyConstraint = (PartCreationPolicyConstraint)importConstraint;
					Write(partCreationPolicyConstraint.RequiredCreationPolicy);
					break;
				}
				case ConstraintTypes.ExportMetadataValueImportConstraint:
				{
					ExportMetadataValueImportConstraint exportMetadataValueImportConstraint = (ExportMetadataValueImportConstraint)importConstraint;
					Write(exportMetadataValueImportConstraint.Name);
					WriteObject(exportMetadataValueImportConstraint.Value);
					break;
				}
				default:
					throw Assumes.NotReachable();
				}
			}
		}

		private IImportSatisfiabilityConstraint ReadIImportSatisfiabilityConstraint()
		{
			using (Trace("IImportSatisfiabilityConstraint"))
			{
				ConstraintTypes constraintTypes = (ConstraintTypes)reader.ReadByte();
				switch (constraintTypes)
				{
				case ConstraintTypes.ImportMetadataViewConstraint:
				{
					uint num = ReadCompressedUInt();
					ImmutableDictionary<string, ImportMetadataViewConstraint.MetadatumRequirement>.Builder builder = ImmutableDictionary.CreateBuilder<string, ImportMetadataViewConstraint.MetadatumRequirement>();
					for (int i = 0; i < num; i++)
					{
						string key = ReadString();
						TypeRef valueType = ReadTypeRef();
						bool required = reader.ReadBoolean();
						builder.Add(key, new ImportMetadataViewConstraint.MetadatumRequirement(valueType, required));
					}
					return new ImportMetadataViewConstraint(builder.ToImmutable());
				}
				case ConstraintTypes.ExportTypeIdentityConstraint:
					return new ExportTypeIdentityConstraint(ReadString());
				case ConstraintTypes.PartCreationPolicyConstraint:
					return PartCreationPolicyConstraint.GetRequiredCreationPolicyConstraint(ReadCreationPolicy());
				case ConstraintTypes.ExportMetadataValueImportConstraint:
				{
					string name = ReadString();
					object value = ReadObject();
					return new ExportMetadataValueImportConstraint(name, value);
				}
				default:
					throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Strings.UnexpectedConstraintType, new object[1] { constraintTypes }));
				}
			}
		}
	}

	protected static readonly Encoding TextEncoding = Encoding.UTF8;

	public Task SaveAsync(ComposableCatalog catalog, Stream cacheStream, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(catalog, "catalog");
		Requires.NotNull(cacheStream, "cacheStream");
		return Task.Run(delegate
		{
			using BinaryWriter writer = new BinaryWriter(cacheStream, TextEncoding, leaveOpen: true);
			SerializationContext serializationContext = new SerializationContext(writer, catalog.Parts.Count * 4, catalog.Resolver);
			serializationContext.Write(catalog);
			serializationContext.FinalizeObjectTableCapacity();
		});
	}

	public Task<ComposableCatalog> LoadAsync(Stream cacheStream, Resolver resolver, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(cacheStream, "cacheStream");
		Requires.NotNull(resolver, "resolver");
		return Task.Run(delegate
		{
			using BinaryReader reader = new BinaryReader(cacheStream, TextEncoding, leaveOpen: true);
			return new SerializationContext(reader, resolver).ReadComposableCatalog();
		});
	}
}
