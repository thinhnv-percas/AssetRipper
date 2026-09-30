// Every type and member an assembly declares, one row each, from the metadata tables alone:
//
//   AssemblyFingerprint <directory or .dll>...   ->  TSV on stdout
//   assembly  type  kind  name  arity  parameters  visibility
//
// Iteration 063. The question it answers is whether two builds carry the same program surface - a
// source project's compiled assemblies against the metadata a player build shipped - which is what
// "was this binary built from this source" rests on. Names, arities and parameter counts are compared
// rather than bodies: a body differs between a Unity build and an il2cpp stub by construction, the
// declaration does not. Parameter *types* are decoded as names so that an overload set compares by
// signature, not by count.

using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

if (args.Length == 0)
{
    Console.Error.WriteLine("usage: AssemblyFingerprint <directory or .dll>...");
    return 2;
}

var files = new List<string>();
foreach (var arg in args)
{
    if (Directory.Exists(arg))
        files.AddRange(Directory.GetFiles(arg, "*.dll").OrderBy(f => f, StringComparer.Ordinal));
    else if (File.Exists(arg))
        files.Add(arg);
}

var output = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };

foreach (var file in files)
{
    using var stream = File.OpenRead(file);
    PEReader pe;
    try { pe = new PEReader(stream); } catch { continue; }
    if (!pe.HasMetadata) continue;
    var md = pe.GetMetadataReader();
    var assembly = md.IsAssembly ? md.GetString(md.GetAssemblyDefinition().Name) : Path.GetFileNameWithoutExtension(file);
    var provider = new NameProvider(md);

    foreach (var handle in md.TypeDefinitions)
    {
        var type = md.GetTypeDefinition(handle);
        var typeName = FullName(md, type);
        if (typeName == "<Module>") continue;
        var typeVisibility = (type.Attributes & TypeAttributes.VisibilityMask) is TypeAttributes.Public or TypeAttributes.NestedPublic ? "public" : "nonpublic";
        output.WriteLine($"{assembly}\t{typeName}\ttype\t\t{type.GetGenericParameters().Count}\t\t{typeVisibility}");

        foreach (var mh in type.GetMethods())
        {
            var method = md.GetMethodDefinition(mh);
            string parameters;
            try
            {
                var signature = method.DecodeSignature(provider, null);
                parameters = string.Join(",", signature.ParameterTypes);
            }
            catch { parameters = "?"; }
            var visibility = (method.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public ? "public" : "nonpublic";
            output.WriteLine($"{assembly}\t{typeName}\tmethod\t{md.GetString(method.Name)}\t{method.GetGenericParameters().Count}\t{parameters}\t{visibility}");
        }

        foreach (var fh in type.GetFields())
        {
            var field = md.GetFieldDefinition(fh);
            string fieldType;
            try { fieldType = field.DecodeSignature(provider, null); } catch { fieldType = "?"; }
            var visibility = (field.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public ? "public" : "nonpublic";
            output.WriteLine($"{assembly}\t{typeName}\tfield\t{md.GetString(field.Name)}\t0\t{fieldType}\t{visibility}");
        }
    }
}

output.Flush();
return 0;

static string FullName(MetadataReader md, TypeDefinition type)
{
    var name = md.GetString(type.Name);
    if (type.GetDeclaringType() is { IsNil: false } declaring)
        return FullName(md, md.GetTypeDefinition(declaring)) + "/" + name;
    var ns = md.GetString(type.Namespace);
    return ns.Length == 0 ? name : ns + "." + name;
}

sealed class NameProvider(MetadataReader md) : ISignatureTypeProvider<string, object?>
{
    public string GetPrimitiveType(PrimitiveTypeCode typeCode) => typeCode.ToString();
    public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        => Program_FullName(reader, reader.GetTypeDefinition(handle));
    public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
    {
        var reference = reader.GetTypeReference(handle);
        var name = reader.GetString(reference.Name);
        if (reference.ResolutionScope.Kind == HandleKind.TypeReference)
            return GetTypeFromReference(reader, (TypeReferenceHandle)reference.ResolutionScope, rawTypeKind) + "/" + name;
        var ns = reader.GetString(reference.Namespace);
        return ns.Length == 0 ? name : ns + "." + name;
    }
    public string GetTypeFromSpecification(MetadataReader reader, object? context, TypeSpecificationHandle handle, byte rawTypeKind)
        => reader.GetTypeSpecification(handle).DecodeSignature(this, context);
    public string GetSZArrayType(string elementType) => elementType + "[]";
    public string GetArrayType(string elementType, ArrayShape shape) => elementType + "[" + new string(',', shape.Rank - 1) + "]";
    public string GetByReferenceType(string elementType) => elementType + "&";
    public string GetPointerType(string elementType) => elementType + "*";
    public string GetGenericInstantiation(string genericType, ImmutableArray<string> typeArguments) => genericType + "<" + string.Join(",", typeArguments) + ">";
    public string GetGenericTypeParameter(object? context, int index) => "!" + index;
    public string GetGenericMethodParameter(object? context, int index) => "!!" + index;
    public string GetFunctionPointerType(MethodSignature<string> signature) => "fnptr";
    public string GetModifiedType(string modifier, string unmodifiedType, bool isRequired) => unmodifiedType;
    public string GetPinnedType(string elementType) => elementType;

    static string Program_FullName(MetadataReader reader, TypeDefinition type)
    {
        var name = reader.GetString(type.Name);
        if (type.GetDeclaringType() is { IsNil: false } declaring)
            return Program_FullName(reader, reader.GetTypeDefinition(declaring)) + "/" + name;
        var ns = reader.GetString(type.Namespace);
        return ns.Length == 0 ? name : ns + "." + name;
    }
}
