# Vendored Cpp2IL

`Il2CppIlGenerator.cs` is Cpp2IL's `Cpp2IL.Core/IlGenerator.cs` at commit
`291ce6cb95e9cbe661831c53d5ed8fff833d8318`, which is the source the `AssetRipper.Cpp2IL.Core` 1.0.9
package this project references was built from — its nuspec names that commit. MIT licensed; the
licence is in `LICENSE.txt` and the file's own header lists every change against the original.

It is here because the generator has defects this project cannot fix from the outside, and no
published package carries the fixes. There is no seam to substitute a generator through, so
`Il2CppIlRecoveryOutputFormat.GenerateBody` reproduces the twenty lines of
`AsmResolverDllOutputFormatIlRecovery.FillMethodBody` that call it. Nothing else of Cpp2IL is
vendored: the package supplies the loader, the lifter and the analysis, and the vendored generator
runs on the ISIL they produce.

`NestedFieldReference.cs` and `NestedFieldResolver.cs` are ours, not Cpp2IL's. They exist because the
nested field access fix belongs in `MetadataResolver.ResolveFieldOffsets`, which runs inside
`MethodAnalysisContext.Analyze` where there is nothing to override. The resolver runs after `Analyze`
instead and rewrites what that left behind, which costs it the accesses a further iteration of
Cpp2IL's own loop would have reached.

## Updating

When the package version changes, take the new `IlGenerator.cs` from the commit its nuspec names,
re-apply the changes the header lists, and re-measure with `RUN-TEST.bat`. Drop `NestedFieldResolver`
entirely if upstream ever resolves nested field offsets itself.

Two things were tried and are deliberately absent. Resolving a call target that arrives as a bare
address, by looking it up in `MethodsByAddress` when exactly one method sits there, resolves nothing
on this package or on Cpp2IL's development branch: the unresolved targets are il2cpp runtime
functions and PLT stubs, which are not managed methods at all. Naming those targets from the key
function addresses finds nothing either, because the lifter has already consumed every call it
recognised by the time the generator runs.
