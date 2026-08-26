namespace Mon2.Cecil;

public interface IModifierType
{
	TypeReference ModifierType { get; }

	TypeReference ElementType { get; }
}
