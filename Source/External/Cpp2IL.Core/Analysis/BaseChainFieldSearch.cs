using System;
using System.Collections.Generic;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: finds the field at an offset by walking a type's base chain, asking each link the way
/// that link can actually answer.
/// </summary>
/// <remarks>
/// <para>
/// A field an object reads at <c>[this + k]</c> can be declared anywhere up its base chain, so the
/// chain is searched rather than only the type itself. The catch is that not every link answers the
/// same way. A plain type records each field's offset in its metadata. A <b>generic instance</b> does
/// not: every field of one is a concrete wrapper built with no definition behind it, so it has no
/// recorded offset at all - the metadata of a generic definition puts all of its fields at zero, and
/// the real offsets exist only in the layout <see cref="GenericInstanceFieldLayout"/> computes.
/// </para>
/// <para>
/// Reading such a link the metadata way is not merely fruitless, it is wrong in both directions: no
/// offset above zero can ever match, and offset zero would match <i>every</i> field of the type. So a
/// generic instance link is asked through the computed layout instead, and the search reports which
/// link answered - because the field it returns is declared by the open definition, and naming that
/// gives a cast to a type C# cannot spell. The caller instantiates it on the link that was reported.
/// </para>
/// <para>
/// Written over delegates rather than over <c>TypeAnalysisContext</c> so the walk can be tested
/// without a game behind it; building one of those needs a whole application context.
/// </para>
/// </remarks>
public static class BaseChainFieldSearch
{
    /// <summary>
    /// How far up a base chain the search will walk. Deeper than any real hierarchy, and finite so a
    /// malformed chain that points at itself cannot hang the run.
    /// </summary>
    public const int MaximumDepth = 16;

    /// <param name="owner">The type the access is made through.</param>
    /// <param name="targetOffset">The offset read or written, relative to the object.</param>
    /// <param name="baseOf">The next link up, or null at the root.</param>
    /// <param name="isGenericInstance">Whether a link records no field offsets of its own.</param>
    /// <param name="metadataField">The field a plain link records at this offset, if any.</param>
    /// <param name="computedField">The field a generic instance's computed layout places here, if any.</param>
    /// <param name="declaringTypeOf">Which type declares a field.</param>
    /// <param name="definitionOf">The open definition behind a link, for comparing against that.</param>
    /// <returns>
    /// The field, and the link it must be instantiated on - null when the link recorded it itself and
    /// the field is already closed.
    /// </returns>
    public static (TField? Field, TType? InstantiateOn) Find<TType, TField>(
        TType owner,
        long targetOffset,
        Func<TType, TType?> baseOf,
        Func<TType, bool> isGenericInstance,
        Func<TType, long, TField?> metadataField,
        Func<TType, long, TField?> computedField,
        Func<TField, TType?> declaringTypeOf,
        Func<TType, TType> definitionOf)
        where TType : class
        where TField : class
    {
        TType? link = owner;

        for (int depth = 0; link is not null && depth < MaximumDepth; depth++)
        {
            if (isGenericInstance(link))
            {
                // A computed layout covers the link's whole base chain, so it can return a field some
                // *ancestor* declares - PlayMaker's `ComponentAction<T> : FsmStateAction` places
                // `FsmStateAction.fsm`, and instantiating that on `ComponentAction<InputField>` says
                // the field is declared by a type that does not declare it. A link answers only for
                // what it declares itself; anything else is left to the link that does, which the walk
                // reaches next and which can name it closed.
                if (computedField(link, targetOffset) is { } computed
                    && declaringTypeOf(computed) is { } declaring
                    && ReferenceEquals(declaring, definitionOf(link)))
                {
                    return (computed, link);
                }
            }
            else if (metadataField(link, targetOffset) is { } recorded)
            {
                return (recorded, null);
            }

            link = baseOf(link);
        }

        return (null, null);
    }
}
