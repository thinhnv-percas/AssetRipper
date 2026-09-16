#!/usr/bin/env python3
"""Records what a game's source project contains, and what of it a rip brought back.

The source oracle compares one method against one method; it can only do that for a method it found
on both sides, so it is silent about everything the recovery never produced at all. This is the other
half: it enumerates the source, resolves each file to the assembly Unity would compile it into, and
says for each declared type whether the rip has it - with a reason when it does not.

Three absences are legitimate and are named rather than counted as loss:

  EDITOR_ONLY       the file is under an Editor folder, or in an assembly definition whose
                    includePlatforms is Editor. Unity does not ship it in a player build, so the
                    binary cannot contain it and the rip cannot recover it.
  ASSEMBLY_ABSENT   the whole assembly is missing from the rip. IL2CPP strips an assembly nothing
                    references, and this harness stubs assemblies it does not recover; either way
                    the file's absence is that assembly's fact, not this file's.
  CONDITIONAL       the declaration sits inside a preprocessor region. `#if UNITY_EDITOR` is not
                    in a player build at all, and neither is a platform or feature symbol the build
                    did not define; the condition is recorded so the claim can be checked.
  RECOVERED_ELSEWHERE  the rip has the type, in another assembly. Which assembly a file compiles
                    into is decided by Unity from asmdefs and package layout, and this tool models
                    that from the source tree alone - a package that ships its own assembly puts
                    `DOTweenModuleUtils` in `DOTween` where the source tree reads `Assembly-CSharp`.
                    The type came back; only the attribution differs.
  NOT_IN_METADATA   the type's name does not occur in the build's own `global-metadata.dat`, so
                    il2cpp never compiled it. That is read from the binary rather than argued: a
                    source tree can carry an SDK a build excludes, and reading that as recovery loss
                    is reading a build configuration as a defect. Needs `--metadata`.
  NOT_IN_BUILD      the type is not in the rip, its assembly is, and nothing explains it. This is
                    the one that counts - but only once the source is known to be the revision the
                    build was made from, which `source_matches_build` answers. A source tree ahead of
                    or behind the build declares types the build never had, and counting those as
                    recovery loss is reading a version difference as a defect.

The verdicts are per declared type, because the exporter writes one type per file: a source file
holding four types comes back as four files, and pairing by file name would invent three losses.

Usage: source_manifest.py <source project> <recovered game directory> [--json out.json] [--name X]
"""
import argparse
import collections
import json
import pathlib
import re
import subprocess
import sys

# A top-level type declaration. Nested types are deliberately not collected: the exporter writes a
# nested type inside its declaring type's file, so it is not a file of its own to look for.
# A type declaration. The BOM has to be allowed in the indent: a file that opens with one and then
# `public enum EventID` matched nothing, and the type read as missing from the source - which the
# build-mismatch check then reported as the source being a different revision.
# A delegate is a type and the exporter writes it to its own file like any other, so it belongs here.
TYPE_DECLARATION = re.compile(
    r"^(?P<indent>[ \t\ufeff]*)(?:\[[^\]]*\][ \t]*)*"
    r"(?:public|internal|private|protected|static|sealed|abstract|partial|unsafe|readonly|ref|new|\s)*"
    r"(?:(?:class|struct|interface|enum|record)\s+(?P<name>[A-Za-z_]\w*)"
    r"|delegate\s+[\w<>\[\],.?]+\s+(?P<delegateName>[A-Za-z_]\w*)\s*[<(])", re.MULTILINE)

BLOCK_COMMENT = re.compile(r"/\*.*?\*/", re.DOTALL)
LINE_COMMENT = re.compile(r"//[^\n]*")
STRING_LITERAL = re.compile(r'@?"(?:[^"\\\n]|\\.|"")*"')

RECOVERED, ELSEWHERE, EDITOR_ONLY, ASSEMBLY_ABSENT, CONDITIONAL, NOT_IN_METADATA, NOT_IN_BUILD = (
    "RECOVERED", "RECOVERED_ELSEWHERE", "EDITOR_ONLY", "ASSEMBLY_ABSENT", "CONDITIONAL",
    "NOT_IN_METADATA", "NOT_IN_BUILD")
ORDER = [RECOVERED, ELSEWHERE, EDITOR_ONLY, ASSEMBLY_ABSENT, CONDITIONAL, NOT_IN_METADATA,
         NOT_IN_BUILD]

DIRECTIVE = re.compile(r"^[ \t\ufeff]*#\s*(?P<kind>if|elif|else|endif)\b[ \t]*(?P<condition>[^\r\n]*)")


def code_only(text):
    """The text with comments and string literals removed, so neither can declare a type."""
    return LINE_COMMENT.sub("", BLOCK_COMMENT.sub("", STRING_LITERAL.sub('""', text)))


def top_level_types(text):
    """Every type declared at the outermost brace depth a type can sit at.

    Namespaces nest and types nest inside types, and only the second is written into the declaring
    type's own file. So what a declaration is compared against is the depth of the braces that are
    namespaces, tracked with a stack rather than assumed: a file-scoped namespace opens no brace at
    all, and a type declaration that follows one is still top level.
    """
    code = code_only(text)
    token = re.compile(r"namespace\s+[\w.]+\s*(?P<braced>\{)?|[{}]|" + TYPE_DECLARATION.pattern,
                       re.MULTILINE)
    names, stack, namespace_depth = [], [], 0
    for match in token.finditer(code):
        text_of = match.group(0)
        if text_of.startswith("namespace"):
            if match.group("braced"):
                stack.append("namespace")
                namespace_depth += 1
            else:
                namespace_depth += 1  # File-scoped: open until the end of the file.
        elif text_of == "{":
            stack.append("block")
        elif text_of == "}":
            if stack and stack.pop() == "namespace":
                namespace_depth -= 1
        elif match.groupdict().get("name") or match.groupdict().get("delegateName"):
            if len(stack) == sum(1 for entry in stack if entry == "namespace"):
                name = match.group("name") or match.group("delegateName")
                names.append((name, code.count("\n", 0, match.start())))
    return names


def conditions_by_line(text):
    """For each line, the preprocessor conditions enclosing it, outermost first.

    No symbol table is consulted and none is needed: what this answers is whether a declaration is
    conditional at all, and under what condition. Deciding whether the build defined that symbol is
    the reader's, and the condition is carried into the report so they can.
    """
    active, per_line = [], []
    for line in text.splitlines():
        match = DIRECTIVE.match(line)
        if match:
            kind = match.group("kind")
            if kind == "if":
                active.append(match.group("condition").strip())
            elif kind == "elif" and active:
                active[-1] = "elif " + match.group("condition").strip()
            elif kind == "else" and active:
                active[-1] = "!(" + active[-1] + ")"
            elif kind == "endif" and active:
                active.pop()
            per_line.append(list(active))
        else:
            per_line.append(list(active))
    return per_line


def assembly_of(path, asmdefs, project):
    """The assembly Unity compiles `path` into: the nearest assembly definition above it, or the
    predefined assembly its folder implies."""
    for folder, definition in asmdefs:
        if folder in path.parents:
            return definition["name"], definition
    editor = any(part == "Editor" for part in path.relative_to(project).parts)
    return ("Assembly-CSharp-Editor" if editor else "Assembly-CSharp"), None


def is_editor_only(path, project, definition):
    if any(part == "Editor" for part in path.relative_to(project).parts):
        return True
    if definition is None:
        return False
    platforms = definition.get("includePlatforms") or []
    return platforms == ["Editor"]


def load_asmdefs(project):
    """Assembly definitions, deepest first, so the nearest one above a file is found first."""
    found = []
    for path in project.rglob("*.asmdef"):
        try:
            found.append((path.parent, json.loads(path.read_text(encoding="utf-8-sig"))))
        except (OSError, ValueError):
            continue
    found.sort(key=lambda entry: len(entry[0].parts), reverse=True)
    return found


def recovered_types(game):
    """Every type the rip wrote, as {assembly: {type name}}, from the one-type-per-file layout."""
    scripts = game / "Assets" / "Scripts"
    by_assembly = {}
    if not scripts.is_dir():
        return by_assembly
    for assembly in sorted(p for p in scripts.iterdir() if p.is_dir()):
        by_assembly[assembly.name] = {path.stem for path in assembly.rglob("*.cs")}
    return by_assembly


# The types the exporter itself declares. They are in the rip and in no source project, so they are
# not evidence that the source and the build differ.
INJECTED = {
    "AddressAttribute", "AssemblyInfo", "Cpp2ILHelpers", "FieldOffsetAttribute", "Il2CppRuntime",
    "NativeSourceAttribute", "TokenAttribute", "MetadataOffsetAttribute", "AttributeAttribute",
}


# Assets Unity generates a C# wrapper from at import time. The type is in the build and there is no
# `.cs` for it in the source, which is not a version difference: the source accounts for it through
# the asset. `PlayerInput.inputactions` generating `PlayerInput` is the shape.
GENERATED_FROM = ("*.inputactions",)

# A name no C# source can declare. `<>f__AnonymousType0` and `<PrivateImplementationDetails>` reach
# the export with their angle brackets mangled, and neither is something a source tree omits.
UNWRITEABLE = re.compile(r"[^A-Za-z0-9_`]")


def metadata_names(path):
    """The bytes of a global-metadata.dat, for asking whether it ever heard of a name.

    The string heap is a run of null-terminated UTF-8, so searching for the name *between two nulls*
    answers "is this name in the metadata" without parsing it. The delimiters are what make it an
    answer: a bare substring search reported `Menu`, `Settings`, `Game` and `Pay` as present because
    each is a substring of some other identifier, and eleven types the build never had then read as
    recovery loss.
    """
    if path is None:
        return None
    try:
        return pathlib.Path(path).read_bytes()
    except OSError:
        return None


def generated_type_names(project):
    """Type names Unity generates from an asset rather than from a checked-in source file."""
    names = set()
    for pattern in GENERATED_FROM:
        for path in project.rglob(pattern):
            names.add(path.stem)
    return names


def every_declared_name(project):
    """Every type name the source declares at any depth, for the build-mismatch check only.

    The per-type verdicts are about top-level types, because that is what the exporter writes to a
    file of its own. The mismatch check asks a different question - has the source heard of this
    name at all - and a nested type answers it just as well.
    """
    found = set()
    for path in project.rglob("*.cs"):
        if any(part in (".git", "Library", "Temp", "obj", "Builds") for part in path.parts):
            continue
        try:
            code = code_only(path.read_text(encoding="utf-8", errors="replace"))
        except OSError:
            continue
        for match in TYPE_DECLARATION.finditer(code):
            found.add(match.group("name") or match.group("delegateName"))
    return found


def build_mismatch(entries, present, anywhere):
    """Types the rip has that the source does not declare - the evidence that the two differ.

    The manifest can only read an absence as a recovery failure while the source is the revision the
    build was made from. The check that says so runs the other way round: a type in the build that
    the source has never heard of cannot be a recovery artefact, so it is a version difference, and
    every absence in the other direction is then suspect too.
    """
    declared = {(entry["assembly"], entry["type"]) for entry in entries}
    assemblies = {entry["assembly"] for entry in entries}
    extra = sorted(
        f"{assembly}::{name}"
        for assembly, names in present.items() if assembly in assemblies
        for name in names
        if name not in INJECTED and (assembly, name) not in declared and name not in anywhere
        and not UNWRITEABLE.search(name))
    return extra


def provenance(project):
    """Where the source came from, so a manifest can be checked against the repository later."""
    def git(*arguments):
        try:
            return subprocess.run(("git", "-C", str(project)) + arguments, capture_output=True,
                                  text=True, timeout=30).stdout.strip() or None
        except (OSError, subprocess.SubprocessError):
            return None
    return {
        "remote": git("config", "--get", "remote.origin.url"),
        "commit": git("rev-parse", "HEAD"),
        "described": git("log", "-1", "--format=%s"),
        "dirty": bool(git("status", "--porcelain")),
    }


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("source")
    parser.add_argument("game")
    parser.add_argument("--json")
    parser.add_argument("--name", default=None)
    parser.add_argument("--metadata", help="the build's global-metadata.dat, for NOT_IN_METADATA")
    parser.add_argument("--verbose", action="store_true")
    arguments = parser.parse_args()

    project = pathlib.Path(arguments.source).resolve()
    game = pathlib.Path(arguments.game).resolve()
    if not project.is_dir():
        print(f"SOURCE_NOT_AVAILABLE {project}")
        return 2
    if not game.is_dir():
        print(f"RIP_NOT_AVAILABLE {game}")
        return 2

    metadata = metadata_names(arguments.metadata)
    asmdefs = load_asmdefs(project)
    present = recovered_types(game)
    anywhere_in_rip = {name for names in present.values() for name in names}
    if not present:
        print(f"RIP_HAS_NO_SCRIPTS {game}")
        return 2

    entries, counts = [], collections.Counter()
    for path in sorted(project.rglob("*.cs")):
        if any(part in (".git", "Library", "Temp", "obj", "Builds") for part in path.parts):
            continue
        assembly, definition = assembly_of(path, asmdefs, project)
        editor = is_editor_only(path, project, definition)
        try:
            body = path.read_text(encoding="utf-8", errors="replace")
        except OSError:
            body = ""
        declared = top_level_types(body)
        conditions = conditions_by_line(code_only(body))
        for name, line in declared:
            enclosing = conditions[line] if line < len(conditions) else []
            if editor:
                verdict = EDITOR_ONLY
            elif assembly in present and name in present[assembly]:
                verdict = RECOVERED
            elif name in anywhere_in_rip:
                verdict = ELSEWHERE
            elif metadata is not None and b"\0" + name.encode("utf-8") + b"\0" not in metadata:
                verdict = NOT_IN_METADATA
            elif assembly not in present:
                verdict = ASSEMBLY_ABSENT
            elif enclosing:
                verdict = CONDITIONAL
            else:
                verdict = NOT_IN_BUILD
            counts[verdict] += 1
            entries.append({
                "file": str(path.relative_to(project)),
                "assembly": assembly,
                "type": name,
                "editor_only": editor,
                "conditions": enclosing,
                "verdict": verdict,
            })

    extra = build_mismatch(entries, present,
                           every_declared_name(project) | generated_type_names(project))
    # NOT_IN_METADATA is out of the denominator because the build never had the type; every other
    # exclusion is too, for a reason stated per verdict. NOT_IN_BUILD is what stays.
    shipped = counts[RECOVERED] + counts[ELSEWHERE] + counts[NOT_IN_BUILD]
    report = {
        "fixture": arguments.name or game.name,
        "source": str(project),
        "rip": str(game),
        "provenance": provenance(project),
        "source_files": len({entry["file"] for entry in entries}),
        "declared_types": len(entries),
        "verdicts": {verdict: counts[verdict] for verdict in ORDER},
        "assemblies_in_source": sorted({entry["assembly"] for entry in entries}),
        "assemblies_in_rip": sorted(present),
        "type_recovery_rate": (round((counts[RECOVERED] + counts[ELSEWHERE]) / shipped, 4)
                               if shipped else None),
        "source_matches_build": not extra,
        "types_in_build_not_in_source": extra[:200],
        "types_in_build_not_in_source_count": len(extra),
        "types": entries,
    }

    print(f"{report['fixture']}: {report['declared_types']} types declared in "
          f"{report['source_files']} source files")
    for verdict in ORDER:
        print(f"  {verdict:<16} {counts[verdict]}")
    print(f"  type_recovery_rate {report['type_recovery_rate']} "
          f"({counts[RECOVERED] + counts[ELSEWHERE]} of {shipped} shipped types)")
    if extra:
        print(f"  SOURCE_BUILD_MISMATCH: {len(extra)} types are in the build and not in the source, "
              f"e.g. {', '.join(extra[:3])}.")
        print(f"  NOT_IN_BUILD ({counts[NOT_IN_BUILD]}) cannot be read as recovery loss until the "
              f"source revision matches the build.")
    if arguments.verbose:
        for entry in entries:
            if entry["verdict"] in (NOT_IN_BUILD, CONDITIONAL):
                condition = " ".join(entry["conditions"]) or "-"
                print(f"    {entry['verdict']:<12} {entry['assembly']}::{entry['type']}"
                      f"  [{condition}]  {entry['file']}")
    if arguments.json:
        pathlib.Path(arguments.json).write_text(json.dumps(report, indent=2))
        print(f"  wrote {arguments.json}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
