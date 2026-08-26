using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class CachedComposition : ICompositionCacheManager, IRuntimeCompositionCacheManager
{
	private class SerializationContext : SerializationContextBase
	{
		private enum RuntimeImportFlags : byte
		{
			None = 0,
			IsNonSharedInstanceRequired = 1,
			IsExportFactory = 2,
			CardinalityExactlyOne = 4,
			CardinalityOneOrZero = 8,
			IsParameter = 0x10
		}

		internal SerializationContext(BinaryReader reader, Resolver resolver)
			: base(reader, resolver)
		{
		}

		internal SerializationContext(BinaryWriter writer, int estimatedObjectCount, Resolver resolver)
			: base(writer, estimatedObjectCount, resolver)
		{
		}

		internal void Write(RuntimeComposition compositionRuntime)
		{
			Requires.NotNull(writer, "writer");
			Requires.NotNull(compositionRuntime, "compositionRuntime");
			using (Trace("RuntimeComposition"))
			{
				Write(compositionRuntime.Parts, Write);
				Write(compositionRuntime.MetadataViewsAndProviders);
			}
		}

		internal RuntimeComposition ReadRuntimeComposition()
		{
			Requires.NotNull(reader, "reader");
			using (Trace("RuntimeComposition"))
			{
				IReadOnlyList<RuntimeComposition.RuntimePart> parts = ReadList(reader, ReadRuntimePart);
				IReadOnlyDictionary<TypeRef, RuntimeComposition.RuntimeExport> metadataViewsAndProviders = ReadMetadataViewsAndProviders();
				return RuntimeComposition.CreateRuntimeComposition(parts, metadataViewsAndProviders, base.Resolver);
			}
		}

		private void Write(RuntimeComposition.RuntimeExport export)
		{
			using (Trace("RuntimeExport"))
			{
				if (TryPrepareSerializeReusableObject(export))
				{
					Write(export.ContractName);
					Write(export.DeclaringTypeRef);
					Write(export.MemberRef);
					Write(export.ExportedValueTypeRef);
					Write(export.Metadata);
				}
			}
		}

		private RuntimeComposition.RuntimeExport ReadRuntimeExport()
		{
			using (Trace("RuntimeExport"))
			{
				if (TryPrepareDeserializeReusableObject<RuntimeComposition.RuntimeExport>(out var id, out var value))
				{
					string contractName = ReadString();
					TypeRef declaringTypeRef = ReadTypeRef();
					MemberRef memberRef = ReadMemberRef();
					TypeRef exportedValueTypeRef = ReadTypeRef();
					IReadOnlyDictionary<string, object> metadata = ReadMetadata();
					value = new RuntimeComposition.RuntimeExport(contractName, declaringTypeRef, memberRef, exportedValueTypeRef, metadata);
					OnDeserializedReusableObject(id, value);
				}
				return value;
			}
		}

		private void Write(RuntimeComposition.RuntimePart part)
		{
			using (Trace("RuntimePart"))
			{
				Write(part.TypeRef);
				Write(part.Exports, Write);
				if (part.ImportingConstructorRef.IsEmpty)
				{
					writer.Write(value: false);
				}
				else
				{
					writer.Write(value: true);
					Write(part.ImportingConstructorRef);
					Write(part.ImportingConstructorArguments, Write);
				}
				Write(part.ImportingMembers, Write);
				Write(part.OnImportsSatisfiedRef);
				Write(part.SharingBoundary);
			}
		}

		private RuntimeComposition.RuntimePart ReadRuntimePart()
		{
			using (Trace("RuntimePart"))
			{
				ConstructorRef importingConstructor = default(ConstructorRef);
				IReadOnlyList<RuntimeComposition.RuntimeImport> importingConstructorArguments = ImmutableList<RuntimeComposition.RuntimeImport>.Empty;
				TypeRef type = ReadTypeRef();
				IReadOnlyList<RuntimeComposition.RuntimeExport> exports = ReadList(reader, ReadRuntimeExport);
				if (reader.ReadBoolean())
				{
					importingConstructor = ReadConstructorRef();
					importingConstructorArguments = ReadList(reader, ReadRuntimeImport);
				}
				IReadOnlyList<RuntimeComposition.RuntimeImport> importingMembers = ReadList(reader, ReadRuntimeImport);
				MethodRef onImportsSatisfied = ReadMethodRef();
				string sharingBoundary = ReadString();
				return new RuntimeComposition.RuntimePart(type, importingConstructor, importingConstructorArguments, importingMembers, exports, onImportsSatisfied, sharingBoundary);
			}
		}

		private void Write(RuntimeComposition.RuntimeImport import)
		{
			using (Trace("RuntimeImport"))
			{
				RuntimeImportFlags runtimeImportFlags = RuntimeImportFlags.None;
				runtimeImportFlags = (RuntimeImportFlags)((uint)runtimeImportFlags | (uint)(import.ImportingMemberRef.IsEmpty ? 16 : 0));
				runtimeImportFlags = (RuntimeImportFlags)((uint)runtimeImportFlags | (uint)(import.IsNonSharedInstanceRequired ? 1 : 0));
				runtimeImportFlags = (RuntimeImportFlags)((uint)runtimeImportFlags | (uint)(import.IsExportFactory ? 2 : 0));
				runtimeImportFlags = (RuntimeImportFlags)((uint)runtimeImportFlags | (uint)((import.Cardinality == ImportCardinality.ExactlyOne) ? 4 : ((import.Cardinality == ImportCardinality.OneOrZero) ? 8 : 0)));
				writer.Write((byte)runtimeImportFlags);
				if (import.ImportingMemberRef.IsEmpty)
				{
					Write(import.ImportingParameterRef);
				}
				else
				{
					Write(import.ImportingMemberRef);
				}
				Write(import.ImportingSiteTypeRef);
				Write(import.SatisfyingExports, Write);
				Write(import.Metadata);
				if (import.IsExportFactory)
				{
					Write(import.ExportFactorySharingBoundaries, base.Write);
				}
			}
		}

		private RuntimeComposition.RuntimeImport ReadRuntimeImport()
		{
			using (Trace("RuntimeImport"))
			{
				RuntimeImportFlags runtimeImportFlags = (RuntimeImportFlags)reader.ReadByte();
				ImportCardinality cardinality = (runtimeImportFlags.HasFlag(RuntimeImportFlags.CardinalityOneOrZero) ? ImportCardinality.OneOrZero : ((!runtimeImportFlags.HasFlag(RuntimeImportFlags.CardinalityExactlyOne)) ? ImportCardinality.ZeroOrMore : ImportCardinality.ExactlyOne));
				bool flag = runtimeImportFlags.HasFlag(RuntimeImportFlags.IsExportFactory);
				MemberRef importingMemberRef = default(MemberRef);
				ParameterRef importingParameterRef = default(ParameterRef);
				if (runtimeImportFlags.HasFlag(RuntimeImportFlags.IsParameter))
				{
					importingParameterRef = ReadParameterRef();
				}
				else
				{
					importingMemberRef = ReadMemberRef();
				}
				TypeRef importingSiteTypeRef = ReadTypeRef();
				IReadOnlyList<RuntimeComposition.RuntimeExport> satisfyingExports = ReadList(reader, ReadRuntimeExport);
				IReadOnlyDictionary<string, object> metadata = ReadMetadata();
				IReadOnlyList<string> readOnlyList;
				if (!flag)
				{
					IReadOnlyList<string> empty = ImmutableList<string>.Empty;
					readOnlyList = empty;
				}
				else
				{
					readOnlyList = ReadList(reader, base.ReadString);
				}
				IReadOnlyList<string> exportFactorySharingBoundaries = readOnlyList;
				return importingMemberRef.IsEmpty ? new RuntimeComposition.RuntimeImport(importingParameterRef, importingSiteTypeRef, cardinality, satisfyingExports, runtimeImportFlags.HasFlag(RuntimeImportFlags.IsNonSharedInstanceRequired), flag, metadata, exportFactorySharingBoundaries) : new RuntimeComposition.RuntimeImport(importingMemberRef, importingSiteTypeRef, cardinality, satisfyingExports, runtimeImportFlags.HasFlag(RuntimeImportFlags.IsNonSharedInstanceRequired), flag, metadata, exportFactorySharingBoundaries);
			}
		}

		private void Write(IReadOnlyDictionary<TypeRef, RuntimeComposition.RuntimeExport> metadataTypesAndProviders)
		{
			using (Trace("MetadataTypesAndProviders"))
			{
				WriteCompressedUInt((uint)metadataTypesAndProviders.Count);
				foreach (KeyValuePair<TypeRef, RuntimeComposition.RuntimeExport> metadataTypesAndProvider in metadataTypesAndProviders)
				{
					Write(metadataTypesAndProvider.Key);
					Write(metadataTypesAndProvider.Value);
				}
			}
		}

		private IReadOnlyDictionary<TypeRef, RuntimeComposition.RuntimeExport> ReadMetadataViewsAndProviders()
		{
			using (Trace("MetadataTypesAndProviders"))
			{
				uint num = ReadCompressedUInt();
				ImmutableDictionary<TypeRef, RuntimeComposition.RuntimeExport>.Builder builder = ImmutableDictionary.CreateBuilder<TypeRef, RuntimeComposition.RuntimeExport>();
				for (uint num2 = 0u; num2 < num; num2++)
				{
					TypeRef key = ReadTypeRef();
					RuntimeComposition.RuntimeExport value = ReadRuntimeExport();
					builder.Add(key, value);
				}
				return builder.ToImmutable();
			}
		}
	}

	private static readonly Encoding TextEncoding = Encoding.UTF8;

	public Task SaveAsync(CompositionConfiguration configuration, Stream cacheStream, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(configuration, "configuration");
		Requires.NotNull(cacheStream, "cacheStream");
		Requires.Argument(cacheStream.CanWrite, "cacheStream", Strings.WritableStreamRequired);
		return Task.Run(async delegate
		{
			RuntimeComposition composition = RuntimeComposition.CreateRuntimeComposition(configuration);
			await SaveAsync(composition, cacheStream, cancellationToken);
		});
	}

	public Task SaveAsync(RuntimeComposition composition, Stream cacheStream, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(composition, "composition");
		Requires.NotNull(cacheStream, "cacheStream");
		Requires.Argument(cacheStream.CanWrite, "cacheStream", Strings.WritableStreamRequired);
		return Task.Run(delegate
		{
			using BinaryWriter writer = new BinaryWriter(cacheStream, TextEncoding, leaveOpen: true);
			SerializationContext serializationContext = new SerializationContext(writer, composition.Parts.Count * 5, composition.Resolver);
			serializationContext.Write(composition);
			serializationContext.FinalizeObjectTableCapacity();
		});
	}

	public Task<RuntimeComposition> LoadRuntimeCompositionAsync(Stream cacheStream, Resolver resolver, CancellationToken cancellationToken = default(CancellationToken))
	{
		Requires.NotNull(cacheStream, "cacheStream");
		Requires.Argument(cacheStream.CanRead, "cacheStream", Strings.ReadableStreamRequired);
		Requires.NotNull(resolver, "resolver");
		return Task.Run(delegate
		{
			using BinaryReader reader = new BinaryReader(cacheStream, TextEncoding, leaveOpen: true);
			return new SerializationContext(reader, resolver).ReadRuntimeComposition();
		});
	}

	public async Task<IExportProviderFactory> LoadExportProviderFactoryAsync(Stream cacheStream, Resolver resolver, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await LoadRuntimeCompositionAsync(cacheStream, resolver, cancellationToken)).CreateExportProviderFactory();
	}
}
