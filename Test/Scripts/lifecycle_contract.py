#!/usr/bin/env python3
"""The Unity lifecycle contract of each script: which messages it receives, and in what order.

A MonoBehaviour's behaviour is not only its methods but *when the engine calls them*. The engine
decides that from two facts a compiler never checks: which of the messages it knows a class declares
(`Awake`, `OnEnable`, `Start`, `Update`, `OnTriggerEnter`, ...) and the script's execution order. A
recovery that loses `Start`, adds a stray `Update`, turns `IEnumerator Start` into `void Start`, or
drops an execution order of -1000 runs different code at different times, and every method in it can
be right.

So for every class both sides declare, by namespace and name:

  messages         each Unity message the class declares, matched on the declaration (name and
                   parameter count), never on the name alone - a helper called `Start(int)` is not a
                   message. `IEnumerator Start` is recorded as a coroutine, which is a different
                   contract from `void Start`.
  execution order  from the script's `.meta` (`executionOrder`) and from `[DefaultExecutionOrder]`,
                   whichever the side carries; a build records the resolved value in the MonoScript,
                   which is what the recovered `.meta` carries.

The source is first reduced to what the build compiled (`source_preprocessor`), because an
`#if UNITY_EDITOR` `OnValidate` is not in any player.

Per class: MATCH | MESSAGE_MISSING | MESSAGE_EXTRA | SIGNATURE_DIFFERENT | ORDER_DIFFERENT, plus
MESSAGE_UNDER_UNDECIDED_BRANCH - a message the source declares only inside an `#if` whose value this
checkout cannot establish (a symbol no scripting define, asmdef versionDefine or built-in sets), whose
absence is therefore UNKNOWN and never counted as a loss. A class the recovery does not have is
reported by `source_manifest.py`, not here.

Usage: lifecycle_contract.py <source project> <recovered game directory> --unity <version>
       [--platform Android] [--json out.json]
       lifecycle_contract.py --self-test
"""
import argparse
import collections
import json
import pathlib
import re
import sys

sys.path.insert(0, str(pathlib.Path(__file__).parent))
import source_preprocessor  # noqa: E402

# Unity's messages and how many parameters each takes. A declaration with a different count is a
# method of the same name, not the message.
MESSAGES = {
    "Awake": 0, "OnEnable": 0, "Start": 0, "Update": 0, "FixedUpdate": 0, "LateUpdate": 0,
    "OnDisable": 0, "OnDestroy": 0, "OnGUI": 0, "OnApplicationQuit": 0, "OnBecameVisible": 0,
    "OnBecameInvisible": 0, "OnApplicationPause": 1, "OnApplicationFocus": 1, "Reset": 0,
    "OnValidate": 0, "OnTriggerEnter": 1, "OnTriggerExit": 1, "OnTriggerStay": 1,
    "OnTriggerEnter2D": 1, "OnTriggerExit2D": 1, "OnTriggerStay2D": 1, "OnCollisionEnter": 1,
    "OnCollisionExit": 1, "OnCollisionStay": 1, "OnCollisionEnter2D": 1, "OnCollisionExit2D": 1,
    "OnCollisionStay2D": 1, "OnMouseDown": 0, "OnMouseUp": 0, "OnMouseDrag": 0, "OnMouseEnter": 0,
    "OnMouseExit": 0, "OnMouseOver": 0, "OnMouseUpAsButton": 0, "OnRenderObject": 0,
    "OnWillRenderObject": 0, "OnPreRender": 0, "OnPostRender": 0, "OnRenderImage": 2,
    "OnAnimatorMove": 0, "OnAnimatorIK": 1, "OnParticleCollision": 1, "OnParticleSystemStopped": 0,
    "OnTransformParentChanged": 0, "OnTransformChildrenChanged": 0, "OnRectTransformDimensionsChange": 0,
    "OnCanvasGroupChanged": 0, "OnDrawGizmos": 0, "OnDrawGizmosSelected": 0,
    "OnControllerColliderHit": 1, "OnJointBreak": 1, "OnJointBreak2D": 1, "OnLevelWasLoaded": 1,
    "OnServerInitialized": 0, "OnConnectedToServer": 0,
}

TYPE_DECLARATION = re.compile(
    r"\b(?:class|struct)\s+(?P<name>[A-Za-z_]\w*)(?:\s*<[^>{]*>)?\s*(?::\s*(?P<bases>[^{]+))?\{")
NAMESPACE = re.compile(r"\bnamespace\s+(?P<name>[A-Za-z_][\w.]*)\s*[{;]")
METHOD = re.compile(
    r"(?P<prefix>(?:\[[^\]]*\]\s*)*(?:(?:public|private|protected|internal|static|virtual|override|"
    r"new|sealed|async|unsafe|extern)\s+)*)(?P<returns>void|IEnumerator|System\.Collections\.IEnumerator|"
    r"async\s+void|Task)\s+(?P<name>[A-Za-z_]\w*)\s*\((?P<parameters>[^)]*)\)\s*(?:\{|=>)")
EXECUTION_ORDER_ATTRIBUTE = re.compile(r"\[\s*DefaultExecutionOrder\s*\(\s*(?P<order>-?\d+)\s*\)\s*\]")
COMMENT = re.compile(r"//[^\n]*|/\*.*?\*/", re.S)


def parameter_count(text: str) -> int:
    text = text.strip()
    return 0 if not text else text.count(",") + 1


def declarations(text: str):
    """(namespace.class, {message: signature}, attribute order) for each class a file declares."""
    text = COMMENT.sub("", text)
    namespaces = [(m.start(), m.group("name")) for m in NAMESPACE.finditer(text)]
    found = []
    types = list(TYPE_DECLARATION.finditer(text))
    for position, match in enumerate(types):
        start = match.end()
        # The body runs to the matching brace; a method belongs to the innermost type around it.
        depth, end = 1, start
        while end < len(text) and depth:
            depth += {"{": 1, "}": -1}.get(text[end], 0)
            end += 1
        body = text[start:end]
        for inner in types[position + 1:]:
            if start <= inner.start() < end:
                inner_start = inner.end()
                inner_depth, inner_end = 1, inner_start
                while inner_end < len(text) and inner_depth:
                    inner_depth += {"{": 1, "}": -1}.get(text[inner_end], 0)
                    inner_end += 1
                body = body.replace(text[inner.start():inner_end], "")
        namespace = ""
        for at, name in namespaces:
            if at < match.start():
                namespace = name
        messages = {}
        for method in METHOD.finditer(body):
            name = method.group("name")
            if name in MESSAGES and parameter_count(method.group("parameters")) == MESSAGES[name] \
                    and " static " not in f" {method.group('prefix')} ":
                returns = method.group("returns").replace("System.Collections.", "")
                messages[name] = "coroutine" if returns == "IEnumerator" else "void"
        order = EXECUTION_ORDER_ATTRIBUTE.search(text[max(0, match.start() - 400):match.start()])
        identity = f"{namespace}.{match.group('name')}" if namespace else match.group("name")
        found.append((identity, messages, int(order.group("order")) if order else None))
    return found


def meta_order(cs: pathlib.Path):
    meta = cs.with_name(cs.name + ".meta")
    try:
        match = re.search(r"executionOrder:\s*(-?\d+)", meta.read_text(encoding="utf-8", errors="replace"))
    except OSError:
        return None
    return int(match.group(1)) if match else None


def assembly_of(cs: pathlib.Path, root: pathlib.Path, recovered: bool) -> str:
    """The assembly a script compiles into: its folder under Scripts/ in a recovery, its nearest
    asmdef in a source tree. Two assemblies routinely declare the same namespace and class - Feel
    ships one `MMAutoFocus` for URP and another for post-processing - so a class is not an identity
    on its own."""
    parts = cs.relative_to(root).parts
    if recovered:
        return parts[1] if len(parts) > 2 and parts[0] == "Scripts" else "?"
    directory = cs.parent
    while True:
        for asmdef in sorted(directory.glob("*.asmdef")):
            try:
                return json.loads(asmdef.read_text(encoding="utf-8-sig")).get("name") or asmdef.stem
            except (OSError, ValueError):
                return asmdef.stem
        if directory == root or directory.parent == directory:
            break
        directory = directory.parent
    first_pass = parts[0] in ("Plugins", "Standard Assets", "Pro Standard Assets")
    return "Assembly-CSharp-firstpass" if first_pass else "Assembly-CSharp"


def owning_asmdef(cs: pathlib.Path, root: pathlib.Path):
    directory = cs.parent
    while True:
        found = sorted(directory.glob("*.asmdef"))
        if found:
            return found[0]
        if directory == root or directory.parent == directory:
            return None
        directory = directory.parent


def collect(root: pathlib.Path, defines=None, project=None, platform="android", undecided="keep"):
    classes = {}
    recovered = defines is None
    per_asmdef = {}
    for cs in root.rglob("*.cs"):
        if "/Editor/" in cs.as_posix() + "/":
            continue
        try:
            text = cs.read_text(encoding="utf-8", errors="replace")
        except OSError:
            continue
        if defines is not None:
            asmdef = owning_asmdef(cs, root)
            if asmdef not in per_asmdef:
                per_asmdef[asmdef] = {**defines, **source_preprocessor.project_defines(project, platform, asmdef)}
            text = source_preprocessor.compile_text(text, per_asmdef[asmdef], undecided)
        file_order = meta_order(cs)
        for identity, messages, attribute_order in declarations(text):
            # A file's .meta order belongs to the class the file is named after.
            order = attribute_order if attribute_order is not None else (
                file_order if identity.split(".")[-1] == cs.stem else None)
            classes.setdefault((assembly_of(cs, root, recovered), identity), (messages, order, cs))
    return classes


def compare(source, recovered, certain=None):
    """`certain` is the source read with undecided regions dropped; a message only the kept reading
    has sits under a branch this checkout cannot decide, so its absence is UNKNOWN, not a loss."""
    tally = collections.Counter()
    differences = []
    by_class = collections.defaultdict(list)
    for key in recovered:
        by_class[key[1]].append(key)
    for key, (source_messages, source_order, path) in sorted(source.items()):
        if not source_messages:
            continue
        # Assembly and class first. Which assembly a file lands in is Unity's decision from asmdefs
        # and package layout, so a class the recovery has in exactly one other assembly is the same
        # class; one it has in several is not decidable and is not compared.
        match = key if key in recovered else (by_class[key[1]][0] if len(by_class[key[1]]) == 1 else None)
        if match is None:
            if len(by_class[key[1]]) > 1:
                tally["AMBIGUOUS_ASSEMBLY"] += 1
            continue
        identity = f"{key[0]}:{key[1]}"
        recovered_messages, recovered_order, _ = recovered[match]
        statuses = []
        for name in sorted(set(source_messages) | set(recovered_messages)):
            if name not in recovered_messages:
                surely = certain is None or name in certain.get(key, ({}, None, None))[0]
                statuses.append(("MESSAGE_MISSING" if surely else "MESSAGE_UNDER_UNDECIDED_BRANCH", name))
            elif name not in source_messages:
                statuses.append(("MESSAGE_EXTRA", name))
            elif source_messages[name] != recovered_messages[name]:
                statuses.append(("SIGNATURE_DIFFERENT", f"{name}: {source_messages[name]} -> {recovered_messages[name]}"))
        if (source_order or 0) != (recovered_order or 0):
            statuses.append(("ORDER_DIFFERENT", f"{source_order} -> {recovered_order}"))
        decided = [entry for entry in statuses if entry[0] != "MESSAGE_UNDER_UNDECIDED_BRANCH"]
        for status, detail in statuses:
            if status == "MESSAGE_UNDER_UNDECIDED_BRANCH":
                tally[status] += 1
                differences.append({"class": identity, "differences": [f"{status} {detail}"]})
        statuses = decided
        if statuses:
            for status, detail in statuses:
                tally[status] += 1
            differences.append({"class": identity, "differences": [f"{s} {d}" for s, d in statuses]})
            tally["CLASS_DIFFERENT"] += 1
        else:
            tally["MATCH"] += 1
        tally["MESSAGES_COMPARED"] += len(source_messages)
    classes = tally["MATCH"] + tally["CLASS_DIFFERENT"]
    return {"classes": classes, "tally": dict(tally),
            "lifecycle_match_rate": round(tally["MATCH"] / classes, 4) if classes else None,
            "differences": differences}


def self_test() -> int:
    failures = 0

    def check(name, condition):
        nonlocal failures
        print(("ok   " if condition else "FAIL ") + name)
        failures += 0 if condition else 1

    text = """namespace Game {
    public class Mover : MonoBehaviour {
        void Start() { }
        IEnumerator OnEnable() { yield break; }
        public void Update(float dt) { }
        void OnTriggerEnter(Collider other) { }
        class Inner { void Awake() { } }
    }
    [DefaultExecutionOrder(-50)]
    public class Early : MonoBehaviour { void Awake() {} }
}"""
    found = {identity: (messages, order) for identity, messages, order in declarations(text)}
    check("a message is matched on its declaration", "Start" in found["Game.Mover"][0])
    check("a helper with the message's name and other parameters is not the message", "Update" not in found["Game.Mover"][0])
    check("a coroutine message is recorded as one", found["Game.Mover"][0].get("OnEnable") == "coroutine")
    check("a message with a parameter is matched on its count", "OnTriggerEnter" in found["Game.Mover"][0])
    check("a nested type's message belongs to the nested type", "Awake" not in found["Game.Mover"][0])
    check("[DefaultExecutionOrder] is read", found["Game.Early"][1] == -50)
    result = compare({("X", "A"): ({"Start": "void"}, 0, None)}, {("X", "A"): ({"Start": "coroutine"}, 0, None)})
    check("void Start and IEnumerator Start are different contracts", result["tally"].get("SIGNATURE_DIFFERENT") == 1)
    result = compare({("X", "A"): ({"Start": "void"}, -1000, None)}, {("X", "A"): ({"Start": "void"}, 0, None)})
    check("an execution order lost is a difference", result["tally"].get("ORDER_DIFFERENT") == 1)
    result = compare({("URP", "A"): ({"Start": "void"}, 0, None)},
                     {("URP", "A"): ({"Start": "void"}, 0, None), ("PostProcessing", "A"): ({}, 0, None)})
    check("a class is matched in its own assembly, not in another that declares the same name",
          result["tally"].get("MATCH") == 1)
    return failures


def main():
    parser = argparse.ArgumentParser(description=__doc__.split("\n")[0])
    parser.add_argument("source", nargs="?")
    parser.add_argument("recovered", nargs="?")
    parser.add_argument("--unity")
    parser.add_argument("--platform", default="android", help="android or ios")
    parser.add_argument("--json")
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()
    if args.self_test:
        sys.exit(1 if self_test() else 0)
    if not (args.source and args.recovered and args.unity):
        parser.error("source, recovered and --unity are required")
    platform = args.platform.lower()
    defines = source_preprocessor.defines_for(args.unity, platform)
    source = collect(pathlib.Path(args.source) / "Assets", defines, pathlib.Path(args.source), platform)
    certain = collect(pathlib.Path(args.source) / "Assets", defines, pathlib.Path(args.source), platform, "drop")
    recovered = collect(pathlib.Path(args.recovered) / "Assets")
    result = compare(source, recovered, certain)
    print(f"classes compared {result['classes']}: {json.dumps(result['tally'], sort_keys=True)}")
    print(f"lifecycle_match_rate {result['lifecycle_match_rate']}")
    for item in result["differences"][:25]:
        print(f"  {item['class']}: {'; '.join(item['differences'])}")
    if args.json:
        pathlib.Path(args.json).write_text(json.dumps(result, indent=1, sort_keys=True))


if __name__ == "__main__":
    main()
