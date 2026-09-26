#!/usr/bin/env python3
"""The C# a build actually compiled, from the C# a programmer wrote.

Every source oracle in this project reads the whole text of a `.cs` file and compares it against the
recovery. That is the wrong program. Unity compiles a player build with a fixed set of preprocessor
symbols, and a file is routinely written to be three programs at once:

    public static bool IsIOS()
    {
    #if UNITY_EDITOR
        if (m_CurrentDevice != null) return m_CurrentDevice.m_Platform.Contains("iOS");
    #endif
    #if UNITY_IOS
        return true;
    #else
        return false;
    #endif
    }

An Android player compiles `return false;` and nothing else, which is exactly what the recovery
brought back. Read whole, the source names a call (`Contains`) and the recovery names none, so the
oracle reported it as a body that lost everything. 192 of Merge-Room's methods read that way, and
`ES3Stream.CopyTo` - "loops: source 1, recovered 0", the shape a whole iteration was briefed to
investigate - is `#if UNITY_2019_1_OR_NEWER source.CopyTo(destination); #else <a loop> #endif`.

So this evaluates the directives against the symbols the build is *known* to have had, and leaves
alone everything it does not know:

  known true    the platform the fixture was built for, and the version gates that version satisfies
  known false   UNITY_EDITOR and every other platform
  not known     both branches are kept

Keeping both branches for an unknown symbol is deliberate: it errs towards reporting a loss, which is
the direction that costs a reader time rather than misleading them. A symbol has to be *established*
before it removes code from the comparison.
"""
import re

DIRECTIVE = re.compile(r"^[ \t]*#[ \t]*(if|elif|else|endif|define|undef|region|endregion|pragma|warning|error|line|nullable)\b(.*)$")

# Unity's own version gates, true for a 2022.3 build. `UNITY_2022_3_OR_NEWER` and everything below it.
_VERSION_GATE = re.compile(r"^UNITY_(\d{4})_(\d+)(?:_(\d+))?_OR_NEWER$")


def defines_for(unity_version: str, platform: str) -> dict:
    """The symbol table for one fixture: what its build is known to have had.

    `platform` is "android" or "ios". Only symbols whose value follows from those two facts are
    listed; anything a project defines itself is left unknown on purpose.
    """
    android = platform == "android"

    known = {
        # Never defined in a player build. This project has recorded that as a fact since iteration
        # 030 - `#if UNITY_EDITOR` is not in the build - and used it in `source_manifest.py`.
        "UNITY_EDITOR": False,
        "UNITY_EDITOR_WIN": False,
        "UNITY_EDITOR_OSX": False,
        "UNITY_EDITOR_LINUX": False,
        "DEVELOPMENT_BUILD": False,
        "UNITY_ASSERTIONS": False,

        "UNITY_ANDROID": android,
        "UNITY_IOS": not android,
        "UNITY_IPHONE": not android,
        "UNITY_STANDALONE": False,
        "UNITY_STANDALONE_WIN": False,
        "UNITY_STANDALONE_OSX": False,
        "UNITY_STANDALONE_LINUX": False,
        "UNITY_WEBGL": False,
        "UNITY_WSA": False,
        "UNITY_PS4": False,
        "UNITY_XBOXONE": False,
        "UNITY_SWITCH": False,
        "UNITY_TVOS": False,
        "UNITY_WII": False,

        # Every fixture in this project is an il2cpp build.
        "ENABLE_IL2CPP": True,
        "ENABLE_MONO": False,
        "NET_4_6": True,
        "NET_STANDARD_2_0": True,
        "CSHARP_7_3_OR_NEWER": True,
    }

    major, minor = (int(part) for part in unity_version.split(".")[:2])

    # `UNITY_2019_1_OR_NEWER` and friends: a plain comparison against the editor version, which the
    # rip reads out of `ProjectSettings` and the fixture record states.
    for year in range(2017, major + 1):
        for release in range(1, 5):
            known[f"UNITY_{year}_{release}_OR_NEWER"] = (year, release) <= (major, minor)

    known[f"UNITY_{major}"] = True
    known[f"UNITY_{major}_{minor}"] = True

    # The build's own version, so a gate above the table's range is answered by comparing rather than
    # by not being in the table. `UNITY_2023_1_OR_NEWER` on a 2022.3 build is definitely false, and
    # leaving it unknown keeps a branch the build certainly did not compile.
    known["__version__"] = (major, minor)
    return known


def _value(token: str, defines: dict):
    """True, False, or None for a symbol whose value is not established."""
    if token == "true":
        return True
    if token == "false":
        return False
    if token in defines:
        return defines[token]

    match = _VERSION_GATE.match(token)

    if match is None:
        return None

    version = defines.get("__version__")

    if version is None:
        return None

    return (int(match[1]), int(match[2])) <= version


def evaluate(expression: str, defines: dict):
    """The value of a `#if` expression, or None when any part of it is not established.

    Handles the operators a Unity source file uses: `!`, `&&`, `||` and parentheses. Anything else -
    a symbol nobody declared, a construct not handled - answers None, and the caller keeps both
    branches.
    """
    tokens = re.findall(r"\(|\)|&&|\|\||!|[A-Za-z_]\w*", expression)

    if not tokens:
        return None

    position = 0

    def primary():
        nonlocal position

        if position >= len(tokens):
            raise ValueError("expression ended early")

        token = tokens[position]

        if token == "!":
            position += 1
            inner = primary()
            return None if inner is None else not inner

        if token == "(":
            position += 1
            inner = disjunction()

            if position >= len(tokens) or tokens[position] != ")":
                raise ValueError("unbalanced")

            position += 1
            return inner

        position += 1
        return _value(token, defines)

    def conjunction():
        nonlocal position
        left = primary()

        while position < len(tokens) and tokens[position] == "&&":
            position += 1
            right = primary()

            # `false && unknown` is false; `unknown && true` is unknown.
            if left is False or right is False:
                left = False
            elif left is None or right is None:
                left = None
            else:
                left = left and right

        return left

    def disjunction():
        nonlocal position
        left = conjunction()

        while position < len(tokens) and tokens[position] == "||":
            position += 1
            right = conjunction()

            if left is True or right is True:
                left = True
            elif left is None or right is None:
                left = None
            else:
                left = left or right

        return left

    try:
        result = disjunction()
    except ValueError:
        return None

    return result if position == len(tokens) else None


def compile_text(text: str, defines: dict) -> str:
    """The file as the build compiled it, with lines under a false branch removed.

    A region whose condition is not established keeps every branch, so the comparison still sees the
    code and can still report it lost. Directive lines themselves become blank so that line numbers -
    which nothing here depends on, but a reader might - do not move.
    """
    output = []

    # One frame per open `#if`: (emitting, decided) where `decided` says a branch has already been
    # taken, so an `#elif` after it is dead.
    stack = []

    for line in text.splitlines():
        match = DIRECTIVE.match(line)

        if match is None:
            output.append(line if all(frame[0] for frame in stack) else "")
            continue

        keyword, rest = match[1], match[2]

        if keyword == "if":
            value = evaluate(rest, defines)
            stack.append([value is not False, value is True])
        elif keyword == "elif" and stack:
            if stack[-1][1]:
                stack[-1][0] = False
            else:
                value = evaluate(rest, defines)
                stack[-1] = [value is not False, value is True]
        elif keyword == "else" and stack:
            # The else of a branch that was definitely taken is dead; the else of an undecided one is
            # kept, because either might be what the build compiled.
            stack[-1][0] = not stack[-1][1]
        elif keyword == "endif" and stack:
            stack.pop()

        output.append("")

    return "\n".join(output)


def _self_test() -> int:
    """That each rule decides something, and that an unknown symbol decides nothing.

    This file is load-bearing for every source oracle in the harness: if it removed the wrong branch,
    a correct recovery would read as a loss and a lost one as correct, in silence. Each case is red
    if the rule it names is removed.
    """
    defines = defines_for("2022.3", "android")
    cases = [
        ("the editor branch is not in the build", "#if UNITY_EDITOR\nA();\n#endif", [], ["A()"]),
        ("this platform is", "#if UNITY_ANDROID\nA();\n#else\nB();\n#endif", ["A()"], ["B()"]),
        ("the other platform is not", "#if UNITY_IOS\nA();\n#else\nB();\n#endif", ["B()"], ["A()"]),
        ("a version gate this build satisfies",
         "#if UNITY_2019_1_OR_NEWER\nA();\n#else\nB();\n#endif", ["A()"], ["B()"]),
        ("a version gate it does not",
         "#if UNITY_2023_1_OR_NEWER\nA();\n#else\nB();\n#endif", ["B()"], ["A()"]),
        ("an unknown symbol keeps both branches",
         "#if SOME_PROJECT_FLAG\nA();\n#else\nB();\n#endif", ["A()", "B()"], []),
        ("negation", "#if !UNITY_EDITOR\nA();\n#endif", ["A()"], []),
        ("conjunction with an unknown is unknown",
         "#if UNITY_ANDROID && SOME_FLAG\nA();\n#endif", ["A()"], []),
        ("conjunction with a false is false",
         "#if UNITY_EDITOR && SOME_FLAG\nA();\n#endif", [], ["A()"]),
        ("disjunction with a true is true",
         "#if UNITY_ANDROID || SOME_FLAG\nA();\n#else\nB();\n#endif", ["A()"], ["B()"]),
        ("elif after a false if",
         "#if UNITY_IOS\nA();\n#elif UNITY_ANDROID\nB();\n#else\nC();\n#endif", ["B()"], ["A()", "C()"]),
        ("nesting", "#if UNITY_ANDROID\n#if UNITY_EDITOR\nA();\n#endif\nB();\n#endif", ["B()"], ["A()"]),
        ("an unbalanced directive does not throw", "#if UNITY_ANDROID\nA();", ["A()"], []),
    ]

    failures = 0

    for name, text, wanted, unwanted in cases:
        compiled = compile_text(text, defines)
        missing = [token for token in wanted if token not in compiled]
        present = [token for token in unwanted if token in compiled]

        if missing or present:
            print(f"FAIL {name}: missing {missing}, still present {present}")
            failures += 1
        else:
            print(f"ok   {name}")

    print(f"{len(cases) - failures}/{len(cases)} cases")
    return 1 if failures else 0


if __name__ == "__main__":
    import sys
    sys.exit(_self_test())
