// Answer, for a reference assembly set, whether a named member of a named type exists and whether a
// compiler outside that assembly could see it.
//
//   MemberVisibility <references directory>        queries on stdin, one "Type|member" per line
//
// and per line: "Type|member|PRESENT_PUBLIC", "PRESENT_NONPUBLIC" or "ABSENT".
//
// This is the fact the Roslyn log cannot give. C# reports a private member of a base type with the
// same "does not contain a definition" text it uses for a member that is not there at all, and the
// two want opposite work: a member IL2CPP stripped from the build is a defect of what we compile
// against, while a private member the export reached is a defect of the export, which should have
// named the public API. A string-heap probe cannot separate them either, because the recovered
// assemblies are themselves in the reference set and their memberrefs carry every name the export
// names. The metadata tables carry the visibility flags, so they can.

using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

if (args.Length < 1)
{
    Console.Error.WriteLine("usage: MemberVisibility <references directory>   (queries \"Type|member\" on stdin)");
    return 2;
}

var directory = args[0];

if (!Directory.Exists(directory))
{
    Console.Error.WriteLine($"no such directory: {directory}");
    return 2;
}

// Simple type name -> the members it declares, with whether each is visible outside its assembly.
var members = new Dictionary<string, Dictionary<string, bool>>(StringComparer.Ordinal);

// Simple type name -> its base type's simple name, so a lookup can walk up as C# does.
var bases = new Dictionary<string, string>(StringComparer.Ordinal);

foreach (var path in Directory.EnumerateFiles(directory, "*.dll").OrderBy(p => p, StringComparer.Ordinal))
{
    try
    {
        using var stream = File.OpenRead(path);
        using var reader = new PEReader(stream);

        if (!reader.HasMetadata)
        {
            continue;
        }

        Read(reader.GetMetadataReader(), members, bases);
    }
    catch (BadImageFormatException)
    {
        // Not a managed assembly, or one this runtime cannot read. Say nothing rather than guess.
    }
}

string? line;

while ((line = Console.ReadLine()) is not null)
{
    var parts = line.Split('|');

    if (parts.Length < 2)
    {
        continue;
    }

    Console.WriteLine($"{parts[0]}|{parts[1]}|{Lookup(parts[0], parts[1], members, bases)}");
}

return 0;

static void Read(MetadataReader metadata, Dictionary<string, Dictionary<string, bool>> members, Dictionary<string, string> bases)
{
    foreach (var handle in metadata.TypeDefinitions)
    {
        var definition = metadata.GetTypeDefinition(handle);
        var name = Simple(metadata.GetString(definition.Name));

        if (!members.TryGetValue(name, out var declared))
        {
            declared = new Dictionary<string, bool>(StringComparer.Ordinal);
            members[name] = declared;
        }

        if (BaseName(metadata, definition.BaseType) is { } baseName && !bases.ContainsKey(name))
        {
            bases[name] = baseName;
        }

        foreach (var fieldHandle in definition.GetFields())
        {
            var field = metadata.GetFieldDefinition(fieldHandle);
            var access = field.Attributes & FieldAttributes.FieldAccessMask;
            var visible = access is FieldAttributes.Public or FieldAttributes.Family or FieldAttributes.FamORAssem;
            Record(declared, metadata.GetString(field.Name), visible);
        }

        foreach (var methodHandle in definition.GetMethods())
        {
            var method = metadata.GetMethodDefinition(methodHandle);
            var access = method.Attributes & MethodAttributes.MemberAccessMask;
            var visible = access is MethodAttributes.Public or MethodAttributes.Family or MethodAttributes.FamORAssem;
            Record(declared, metadata.GetString(method.Name), visible);
        }

        foreach (var propertyHandle in definition.GetProperties())
        {
            var property = metadata.GetPropertyDefinition(propertyHandle);
            var accessors = property.GetAccessors();
            var visible = IsVisible(metadata, accessors.Getter) || IsVisible(metadata, accessors.Setter);
            Record(declared, metadata.GetString(property.Name), visible);
        }
    }
}

static bool IsVisible(MetadataReader metadata, MethodDefinitionHandle handle)
{
    if (handle.IsNil)
    {
        return false;
    }

    var access = metadata.GetMethodDefinition(handle).Attributes & MethodAttributes.MemberAccessMask;
    return access is MethodAttributes.Public or MethodAttributes.Family or MethodAttributes.FamORAssem;
}

static void Record(Dictionary<string, bool> declared, string name, bool visible)
{
    // A name can be declared more than once - overloads, and the same simple type name in two
    // assemblies. Visible anywhere is visible: the question is whether a compiler could reach one.
    declared[name] = declared.TryGetValue(name, out var already) ? already || visible : visible;
}

static string? BaseName(MetadataReader metadata, EntityHandle handle)
{
    if (handle.IsNil)
    {
        return null;
    }

    return handle.Kind switch
    {
        HandleKind.TypeDefinition => Simple(metadata.GetString(metadata.GetTypeDefinition((TypeDefinitionHandle)handle).Name)),
        HandleKind.TypeReference => Simple(metadata.GetString(metadata.GetTypeReference((TypeReferenceHandle)handle).Name)),
        _ => null,
    };
}

// `List`1` is `List`; a nested type's name is already unqualified in the tables.
static string Simple(string name)
{
    var tick = name.IndexOf('`');
    return tick < 0 ? name : name[..tick];
}

static string Lookup(string type, string member, Dictionary<string, Dictionary<string, bool>> members, Dictionary<string, string> bases)
{
    var seen = new HashSet<string>(StringComparer.Ordinal);
    var current = type;

    while (current is not null && seen.Add(current))
    {
        if (members.TryGetValue(current, out var declared) && declared.TryGetValue(member, out var visible))
        {
            return visible ? "PRESENT_PUBLIC" : "PRESENT_NONPUBLIC";
        }

        current = bases.TryGetValue(current, out var next) ? next : null;
    }

    return "ABSENT";
}
