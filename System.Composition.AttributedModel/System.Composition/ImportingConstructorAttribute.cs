namespace System.Composition;

[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
public sealed class ImportingConstructorAttribute : Attribute
{
}
