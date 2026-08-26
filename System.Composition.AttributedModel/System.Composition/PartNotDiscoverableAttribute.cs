namespace System.Composition;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class PartNotDiscoverableAttribute : Attribute
{
}
