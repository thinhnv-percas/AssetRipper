namespace Mon3.Cecil;

public interface IModifierType
{
	TypeReference ModifierType { get; }

	TypeReference ElementType { get; }
}
