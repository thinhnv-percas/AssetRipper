"""Port of Source/AssetRipper.Export.UnityProjects/Scripts/EmptyScript.cs

Pure text generation (the dummy-class comment explaining why the script has no real
content) -- copied verbatim from upstream, not reconstructed.
"""
from __future__ import annotations

from .mono_script_extensions import is_generic

_EXPLANATION = """\tDummy class. This could have happened for several reasons:

\t1. No dll files were provided to AssetRipper.

\t\tUnity asset bundles and serialized files do not contain script information to decompile.
\t\t\t* For Mono games, that information is contained in .NET dll files.
\t\t\t* For Il2Cpp games, that information is contained in compiled C++ assemblies and the global metadata.

\t\tAssetRipper usually expects games to conform to a normal file structure for Unity games of that platform.
\t\tA unexpected file structure could cause AssetRipper to not find the required files.

\t2. Incorrect dll files were provided to AssetRipper.

\t\tAny of the following could cause this:
\t\t\t* Il2CppInterop assemblies
\t\t\t* Deobfuscated assemblies
\t\t\t* Older assemblies (compared to when the bundle was built)
\t\t\t* Newer assemblies (compared to when the bundle was built)

\t\tNote: Although assembly publicizing is bad, it alone cannot cause empty scripts. See: https://github.com/AssetRipper/AssetRipper/issues/653

\t3. Assembly Reconstruction has not been implemented.

\t\tAsset bundles contain a small amount of information about the script content.
\t\tThis information can be used to recover the serializable fields of a script.

\t\tSee: https://github.com/AssetRipper/AssetRipper/issues/655

\t4. This script is unnecessary.

\t\tIf this script has no asset or script references, it can be deleted.
\t\tBe sure to resolve any compile errors before deleting because they can hide references.

\t5. Script Content Level 0

\t\tAssetRipper was set to not load any script information.

\t6. Cpp2IL failed to decompile Il2Cpp data

\t\tIf this happened, there will be errors in the AssetRipper.log indicating that it happened.
\t\tThis is an upstream problem, and the AssetRipper developer has very little control over it.
\t\tPlease post a GitHub issue at: https://github.com/SamboyCoding/Cpp2IL/issues

\t7. An incorrect path was provided to AssetRipper.

\t\tThis is characterized by "Mixed game structure has been found at" in the AssetRipper.log file.
\t\tAssetRipper expects games to conform to a normal file structure for Unity games of that platform.
\t\tAn unexpected file structure could cause AssetRipper to not find the required files for script decompilation.
\t\tGenerally, AssetRipper expects users to provide the root folder of the game. For example:
\t\t\t* Windows: the folder containing the game's .exe file
\t\t\t* Mac: the .app file/folder
\t\t\t* Linux: the folder containing the game's executable file
\t\t\t* Android: the apk file
\t\t\t* iOS: the ipa file
\t\t\t* Switch: the folder containing exefs and romfs
"""


def get_content(namespace: "str | None", name: str) -> str:
    is_gen, generic_name, generic_count = is_generic(name)
    if is_gen:
        generic_params = ", ".join(f"T{i}" for i in range(1, generic_count + 1))
        name = f"{generic_name}<{generic_params}>"

    if not namespace:
        return (
            "using UnityEngine;\n\n"
            f"public class {name} : MonoBehaviour\n"
            "{\n"
            "\t/*\n"
            f"{_EXPLANATION}"
            "\t*/\n"
            "}\n"
        )
    return (
        "using UnityEngine;\n\n"
        f"namespace {namespace}\n"
        "{\n"
        f"\tpublic class {name} : MonoBehaviour\n"
        "\t{\n"
        "\t\t/*\n"
        f"{_indent(_EXPLANATION)}"
        "\t\t*/\n"
        "\t}\n"
        "}\n"
    )


def _indent(text: str) -> str:
    return "".join(f"\t{line}" if line.strip() else line for line in text.splitlines(keepends=True))
