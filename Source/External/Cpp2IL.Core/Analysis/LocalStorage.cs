using System;
using System.Collections.Generic;

namespace Cpp2IL.Core.Analysis;

/// <summary>Where the value a lifted local names actually lives in the generated method.</summary>
public enum LocalStorageKind
{
    /// <summary>A local the generator declared for it.</summary>
    Local,

    /// <summary>The method's own receiver.</summary>
    This,

    /// <summary>One of the method's parameters.</summary>
    Parameter,
}

/// <summary>What a load, a store and an address-of must all agree on for one lifted local.</summary>
public readonly record struct LocalStorageSite(LocalStorageKind Kind, int ParameterIndex, bool ByReference);

/// <summary>
/// AssetRipper: the one decision about where a lifted local lives.
/// </summary>
/// <remarks>
/// <para>
/// A lifted local is frequently a <em>parameter</em>: the analysis names the register a parameter
/// arrived in after that parameter, and every read, write and address-take of it is a read, write or
/// address-take of the parameter. The generator has three places that need to know this - loading a
/// value, storing one, and taking an address - and they must give the same answer, because they
/// together decide where one value lives.
/// </para>
/// <para>
/// They have twice not agreed, and both times the cost was silent. Iteration 058: the address-of site
/// took <c>ldloca</c> of a local the generator invented, so a method reading a field off a struct
/// parameter read it off a slot nothing had written - <c>ObscuredBool.op_Implicit</c> returned the
/// decryption of zero. Iteration 059: the store site took <c>stloc</c> while the load site took
/// <c>ldarg</c>, so a body with a <c>ref</c> or <c>out</c> parameter wrote the invented local and the
/// caller saw nothing - 46 files on one fixture, every one of them a <c>ref</c>/<c>out</c> parameter
/// assigned into a local named <c>reference</c>.
/// </para>
/// <para>
/// Written over names rather than over AsmResolver's model so the rule is testable with no metadata
/// behind it, which is the same shape <c>NestedFieldResolver</c> and <c>PointerProvenance</c> take.
/// </para>
/// </remarks>
public static class LocalStorage
{
    /// <summary>
    /// Where <paramref name="localName"/> lives, given the method's own parameters.
    /// </summary>
    /// <param name="localName">The lifted local's name.</param>
    /// <param name="isThis">Whether the analysis flagged it as the receiver.</param>
    /// <param name="parameterNames">The generated method's parameter names, in order.</param>
    /// <param name="parameterIsByReference">
    /// Whether each parameter is a managed reference. A <c>ref</c> or <c>out</c> parameter is already
    /// an address, so taking its address again would give a pointer to the pointer.
    /// </param>
    public static LocalStorageSite For(
        string localName,
        bool isThis,
        IReadOnlyList<string> parameterNames,
        IReadOnlyList<bool> parameterIsByReference)
    {
        if (isThis)
            return new LocalStorageSite(LocalStorageKind.This, -1, false);

        for (var index = 0; index < parameterNames.Count; index++)
        {
            if (!string.Equals(parameterNames[index], localName, StringComparison.Ordinal))
                continue;

            var byReference = index < parameterIsByReference.Count && parameterIsByReference[index];
            return new LocalStorageSite(LocalStorageKind.Parameter, index, byReference);
        }

        return new LocalStorageSite(LocalStorageKind.Local, -1, false);
    }
}
