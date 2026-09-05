# Cpp2IL patches

`cpp2il-ilgenerator-fixes.patch` fixes two defects in `Cpp2IL.Core/IlGenerator.cs` that between them
cost this project 2490 method bodies on the test game. Both are in the generator, so they cannot be
fixed from here; what is here is the patch, the mechanism to build against a patched checkout, and
the measurements that justify it.

## What it fixes

**A body can run off its own end.** `GenerateIl` bridges each block to its successor, but a block
whose only successor is the exit block gets no bridge, and the analysis warnings appended at the end
finish on a call. Nothing guarantees a terminator, so the body is invalid IL: reading it walks past
the last instruction. AsmResolver reports that as a stack imbalance at an offset one byte past the
final call, and the body is discarded. `EnsureTerminated` appends a return, preceded by a default
value where the method returns one.

**A resolved call target is thrown away.** The lifter resolves a call, uses it, and keeps only the
address, so a method the model knows arrives at the generator as a bare number and is emitted as a
`Method not found @ACC5DC` diagnostic. Looking the address up again in `MethodsByAddress` turns it
back into the call it is. Only an unambiguous address is taken: identical bodies are folded onto one
address and generic sharing puts dozens of methods there, where any single pick would be wrong.

Doing this in the generator is what makes it safe. The generator loads arguments from the resolved
signature, so the stack balances by construction. The same idea applied downstream, where the
signature is not available, unbalanced the stack in 1019 methods and cost them their bodies — that
was measured, and is why this belongs here.

## Measured on the test game

Ripping `Test/Input/Pinata` at script content level 3, 18397 methods attempted:

| | Package 1.0.9 | Package + downstream repair | Patched source |
|---|---|---|---|
| Bodies discarded as invalid | 2490 | 21 | **0** |
| `Method not found` placeholders | 40034 | 40034 | **27007** |
| Decompilation errors | 0 | 0 | 0 |

## Applying it

```
git clone --branch development https://github.com/AssetRipper/Cpp2IL.git
git -C Cpp2IL apply /path/to/AssetRipper/Patches/cpp2il-ilgenerator-fixes.patch
dotnet build /path/to/AssetRipper/AssetRipper.slnx -p:Cpp2ILSourcePath=/path/to/Cpp2IL
```

Without `Cpp2ILSourcePath` the build uses the published package and behaves as before, with the
downstream repair in `Il2CppIlRecoveryOutputFormat` covering what it can. That repair is kept
deliberately: it is what protects a package build, and it costs nothing on a patched build, where it
reports zero repairs because there is nothing left to repair.

The patch targets the `development` branch. It is written to be submitted upstream — that is the
real home for it, and this directory is the interim.
