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
  NOT_IN_BUILD      the type is not in the rip, its assembly is, and nothing explains it. This is
                    the one that counts.

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
TYPE_DECLARATION = re.compile(
    r"^(?P<indent>[ \t]*)(?:\[[^\]]*\][ \t]*)*"
    r"(?:public|internal|private|protected|static|sealed|abstract|partial|unsafe|readonly|ref|new|\s)*"
    r"(?:class|struct|interface|enum|record)\s+(?P<name>[A-Za-z_]\w*)", re.MULTILINE)

BLOCK_COMMENT = re.compile(r"/\*.*?\*/", re.DOTALL)
LINE_COMMENT = re.compile(r"//[^\n]*")
STRING_LITERAL = re.compile(r'@?"(?:[^"\\\n]|\\.|"")*"')

RECOVERED, EDITOR_ONLY, ASSEMBLY_ABSENT, CONDITIONAL, NOT_IN_BUILD = (
    "RECOVERED", "EDITOR_ONLY", "ASSEMBLY_ABSENT", "CONDITIONAL", "NOT_IN_BUILD")
ORDER = [RECOVERED, EDITOR_ONLY, ASSEMBLY_ABSENT, CONDITIONAL, NOT_IN_BUILD]

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
        elif match.groupdict().get("name"):
            if len(stack) == sum(1 for entry in stack if entry == "namespace"):
                names.append((match.group("name"), code.count("\n", 0, match.start())))
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

    asmdefs = load_asmdefs(project)
    present = recovered_types(game)
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
            elif assembly not in present:
                verdict = ASSEMBLY_ABSENT
            elif name in present[assembly]:
                verdict = RECOVERED
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

    shipped = counts[RECOVERED] + counts[NOT_IN_BUILD]
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
        "type_recovery_rate": round(counts[RECOVERED] / shipped, 4) if shipped else None,
        "types": entries,
    }

    print(f"{report['fixture']}: {report['declared_types']} types declared in "
          f"{report['source_files']} source files")
    for verdict in ORDER:
        print(f"  {verdict:<16} {counts[verdict]}")
    print(f"  type_recovery_rate {report['type_recovery_rate']} "
          f"({counts[RECOVERED]} of {shipped} shipped types)")
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
