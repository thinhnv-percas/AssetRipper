#!/usr/bin/env python3
"""One semantic IR for a shader program, whichever language it is written in.

The recovered side and the source side are not in the same language and never will be: what a build
carries is HLSLcc's GLSL, and what a programmer wrote is Cg/HLSL. Comparing the two as text answers
nothing. What both can be reduced to is what the program *does* - which inputs it reads, which
samplers it samples, which arithmetic it performs, what it writes.

That reduction is this file, and it is the only source of truth for a shader program in the harness:
the recovered side reads the extracted program bytes (`AuxiliaryFiles/ShaderPrograms.json` and the
`.glsl` files beside it), the source side reads the programmer's `.shader`, and both produce the same
vocabulary.

Nothing here decompiles and nothing here guesses. An operation is recorded because a token that
performs it is present; a program that could not be read produces no operations and says so, rather
than producing an empty set that reads like a program which does nothing.
"""
import json
import pathlib
import re

# The canonical operations, in the brief's own spelling.
OPERATIONS = [
    "LOAD_UNIFORM", "LOAD_TEXTURE", "LOAD_SAMPLER", "TEXTURE_SAMPLE",
    "LOAD_VERTEX_POSITION", "LOAD_VERTEX_NORMAL", "LOAD_VERTEX_UV", "LOAD_VERTEX_COLOR",
    "ADD", "SUB", "MUL", "DIV",
    "DOT", "CROSS", "NORMALIZE", "LENGTH",
    "MIN", "MAX", "CLAMP", "LERP",
    "MATRIX_MUL", "VECTOR_MUL",
    "SIN", "COS",
    "COMPARE", "BRANCH", "DISCARD",
    "STORE_POSITION", "STORE_COLOR", "STORE_NORMAL", "RETURN",
]

# The vocabulary is the one iteration 058 established. The brief for 059 names several of these
# differently - `UNIFORM_READ` for `LOAD_UNIFORM`, `WRITE_COLOR` for `STORE_COLOR` - and they are the
# same operations. Renaming them would make every number published before this iteration
# incomparable for nothing, so the mapping is written down instead.
ALTERNATE_NAMES = {
    "LOAD_UNIFORM": "UNIFORM_READ",
    "LOAD_SAMPLER": "SAMPLER_READ",
    "LOAD_VERTEX_POSITION": "ATTRIBUTE_READ",
    "VECTOR_MUL": "VECTOR_CONSTRUCT",
    "MATRIX_MUL": "MATRIX_MULTIPLY",
    "STORE_POSITION": "WRITE_POSITION",
    "STORE_COLOR": "WRITE_COLOR",
    "STORE_NORMAL": "WRITE_NORMAL",
}

# The arithmetic operators, matched away from the places they are not arithmetic: a `+` inside a
# preprocessor line or a comment is not a program adding two things.
_COMMENT = re.compile(r"//[^\n]*|/\*.*?\*/", re.S)
_DIRECTIVE = re.compile(r"^\s*#[^\n]*$", re.M)

# GLSL, as HLSLcc emits it for GLES. Each pattern is a token that performs the operation; none of
# them is a heuristic about what the program probably does.
GLSL = {
    "LOAD_UNIFORM": r"\buniform\b|\bUNITY_UNIFORM\b|\blayout\s*\(\s*std140",
    "LOAD_SAMPLER": r"\bsampler2D\b|\bsamplerCube\b|\bsampler3D\b|\bsampler2DArray\b",
    "LOAD_TEXTURE": r"\buniform\s+(?:lowp|mediump|highp\s+)?sampler|\b_MainTex\b",
    "TEXTURE_SAMPLE": r"\btexture2D\s*\(|\btextureLod\s*\(|\btexture\s*\(|\btexelFetch\s*\(",
    "LOAD_VERTEX_POSITION": r"\bin_POSITION\d*\b|\bgl_Vertex\b",
    "LOAD_VERTEX_NORMAL": r"\bin_NORMAL\d*\b|\bgl_Normal\b",
    "LOAD_VERTEX_UV": r"\bin_TEXCOORD\d*\b|\bgl_MultiTexCoord\d*\b",
    "LOAD_VERTEX_COLOR": r"\bin_COLOR\d*\b|\bgl_Color\b",
    "ADD": r"[^+\s]\s*\+\s*[^+=]",
    "SUB": r"[^-\s]\s*-\s*[^-=]",
    "MUL": r"[^*\s]\s*\*\s*[^*=]",
    "DIV": r"[^/\s]\s*/\s*[^/=*]",
    "DOT": r"\bdot\s*\(",
    "CROSS": r"\bcross\s*\(",
    "NORMALIZE": r"\bnormalize\s*\(|\binversesqrt\s*\(",
    "LENGTH": r"\blength\s*\(",
    "MIN": r"\bmin\s*\(",
    "MAX": r"\bmax\s*\(",
    "CLAMP": r"\bclamp\s*\(",
    "LERP": r"\bmix\s*\(",
    "MATRIX_MUL": r"\bhlslcc_mtx\w*\b|\bmat[234]\s*\(",
    "VECTOR_MUL": r"\bvec[234]\s*\(",
    "SIN": r"\bsin\s*\(",
    "COS": r"\bcos\s*\(",
    "COMPARE": r"[<>]=?|==|!=|\bgreaterThan\b|\blessThan\b",
    "BRANCH": r"\bif\s*\(|\bswitch\s*\(",
    "DISCARD": r"\bdiscard\b",
    "STORE_POSITION": r"\bgl_Position\b",
    "STORE_COLOR": r"\bgl_FragColor\b|\bgl_FragData\b|\bSV_Target\d*\b",
    "STORE_NORMAL": r"\bSV_Target1\b|\bout_NORMAL\b",
    "RETURN": r"\breturn\b",
}

# Cg/HLSL, as a Unity shader is written. The same operations under the names that language gives them.
HLSL = {
    "LOAD_UNIFORM": r"\buniform\b|\bCBUFFER_START\b|\bfloat[234]?\s+_\w+\s*;|\bhalf[234]?\s+_\w+\s*;",
    "LOAD_SAMPLER": r"\bsampler2D\b|\bsamplerCUBE\b|\bSamplerState\b|\bSAMPLER\s*\(",
    "LOAD_TEXTURE": r"\bTexture2D\b|\bTEXTURE2D\s*\(|\b_MainTex\b",
    "TEXTURE_SAMPLE": r"\btex2D\w*\s*\(|\btexCUBE\w*\s*\(|\bSAMPLE_TEXTURE2D\w*\s*\(|\.Sample\w*\s*\(",
    "LOAD_VERTEX_POSITION": r":\s*POSITION\b|\bUNITY_POSITION\b",
    "LOAD_VERTEX_NORMAL": r":\s*NORMAL\b",
    "LOAD_VERTEX_UV": r":\s*TEXCOORD\d*\b",
    "LOAD_VERTEX_COLOR": r":\s*COLOR\d*\b",
    "ADD": r"[^+\s]\s*\+\s*[^+=]",
    "SUB": r"[^-\s]\s*-\s*[^-=>]",
    "MUL": r"[^*\s]\s*\*\s*[^*=]",
    "DIV": r"[^/\s]\s*/\s*[^/=*]",
    "DOT": r"\bdot\s*\(",
    "CROSS": r"\bcross\s*\(",
    "NORMALIZE": r"\bnormalize\s*\(|\brsqrt\s*\(",
    "LENGTH": r"\blength\s*\(",
    "MIN": r"\bmin\s*\(",
    "MAX": r"\bmax\s*\(",
    "CLAMP": r"\bclamp\s*\(|\bsaturate\s*\(",
    "LERP": r"\blerp\s*\(",
    "MATRIX_MUL": r"\bmul\s*\(|\bfloat4x4\b|\bUnityObjectToClipPos\s*\(",
    "VECTOR_MUL": r"\bfloat[234]\s*\(|\bhalf[234]\s*\(|\bfixed[234]\s*\(",
    "SIN": r"\bsin\s*\(",
    "COS": r"\bcos\s*\(",
    "COMPARE": r"[<>]=?|==|!=",
    "BRANCH": r"\bif\s*\(|\bswitch\s*\(",
    "DISCARD": r"\bclip\s*\(|\bdiscard\b",
    "STORE_POSITION": r":\s*SV_POSITION\b|:\s*POSITION\b",
    "STORE_COLOR": r":\s*SV_Target\d*\b|:\s*COLOR\d*\b",
    "STORE_NORMAL": r":\s*SV_Target1\b",
    "RETURN": r"\breturn\b",
}

# Metal Shading Language, as HLSLcc emits it for Unity's Metal backend (iteration 063: an iOS build ships
# its Metal programs as this source unless it precompiled them). Uniforms arrive as a `constant` struct
# bound to a buffer, vertex inputs as `[[ attribute(n) ]]` members named after their semantics, and the
# outputs as `mtl_Position` and a colour attachment.
MSL = {
    "LOAD_UNIFORM": r"\bconstant\s+\w+_Type\s*&|\[\[\s*buffer\s*\(",
    "LOAD_SAMPLER": r"\bsampler\s+\w+\s*\[\[",
    "LOAD_TEXTURE": r"\btexture(?:2d|3d|cube|2d_array)\s*<",
    "TEXTURE_SAMPLE": r"\.sample(?:_compare)?\s*\(|\.read\s*\(",
    "LOAD_VERTEX_POSITION": r"\bPOSITION\d*\s*\[\[\s*attribute",
    "LOAD_VERTEX_NORMAL": r"\bNORMAL\d*\s*\[\[\s*attribute",
    "LOAD_VERTEX_UV": r"\bTEXCOORD\d*\s*\[\[\s*attribute",
    "LOAD_VERTEX_COLOR": r"\bCOLOR\d*\s*\[\[\s*attribute",
    "ADD": r"[^+\s]\s*\+\s*[^+=]|\bfma\s*\(",
    "SUB": r"[^-\s]\s*-\s*[^-=>]",
    "MUL": r"[^*\s]\s*\*\s*[^*=]|\bfma\s*\(",
    "DIV": r"[^/\s]\s*/\s*[^/=*]",
    "DOT": r"\bdot\s*\(",
    "CROSS": r"\bcross\s*\(",
    "NORMALIZE": r"\bnormalize\s*\(|\brsqrt\s*\(",
    "LENGTH": r"\blength\s*\(",
    "MIN": r"\bmin\s*\(",
    "MAX": r"\bmax\s*\(",
    "CLAMP": r"\bclamp\s*\(|\bsaturate\s*\(",
    "LERP": r"\bmix\s*\(",
    "MATRIX_MUL": r"\bhlslcc_mtx\w*\b|\bfloat[234]x[234]\b",
    "VECTOR_MUL": r"\b(?:float|half)[234]\s*\(",
    "SIN": r"\bsin\s*\(",
    "COS": r"\bcos\s*\(",
    "COMPARE": r"[<>]=?|==|!=",
    "BRANCH": r"\bif\s*\(|\bswitch\s*\(",
    "DISCARD": r"\bdiscard_fragment\s*\(",
    "STORE_POSITION": r"\bmtl_Position\b",
    "STORE_COLOR": r"\bSV_Target\d*\b|\[\[\s*color\s*\(",
    "STORE_NORMAL": r"\bSV_Target1\b",
    "RETURN": r"\breturn\b",
}

_GLSL = {name: re.compile(pattern) for name, pattern in GLSL.items()}
_MSL = {name: re.compile(pattern) for name, pattern in MSL.items()}
_HLSL = {name: re.compile(pattern) for name, pattern in HLSL.items()}

# A ShaderLab program block, in any of the spellings Unity accepts.
PROGRAM_BLOCK = re.compile(
    r"\b(?:CGPROGRAM|HLSLPROGRAM|GLSLPROGRAM)\b(.*?)\b(?:ENDCG|ENDHLSL|ENDGLSL)\b", re.S)


def strip(text: str) -> str:
    """Comments and preprocessor lines removed, so a `+` in a comment is not arithmetic."""
    return _DIRECTIVE.sub("", _COMMENT.sub(" ", text))


def operations(text: str, language: str) -> dict:
    """{operation: count} for one program's text."""
    patterns = {"glsl": _GLSL, "msl": _MSL}.get(language, _HLSL)
    cleaned = strip(text)
    return {name: len(pattern.findall(cleaned))
            for name, pattern in patterns.items()
            if pattern.search(cleaned)}


# What a program samples, which is identity rather than shape: two programs that reach the same
# operations and sample different textures do different things.
SAMPLER_DECLARATION = re.compile(
    r"\b(?:uniform\s+)?(?:lowp|mediump|highp\s+)?(?:sampler2D|samplerCube|sampler3D|sampler2DArray|"
    r"Texture2D|TextureCube|sampler2D_float)\s+(\w+)")

# `vec3(...)`, `float4(...)`: the width a program builds its values at.
VECTOR_WIDTH = re.compile(r"\b(?:vec|float|half|fixed|ivec|int)([234])\s*\(")


# What is actually sampled, as opposed to what is declared. A shader routinely declares a sampler it
# only uses under a keyword, and a compiler strips an unused uniform - so comparing declarations
# reports a texture as lost that the base variant correctly never reads.
SAMPLED = re.compile(
    r"\b(?:tex2D\w*|texCUBE\w*|texture2D\w*|textureCube\w*|textureLod|texture)\s*\(\s*(\w+)"
    r"|\bSAMPLE_TEXTURE2D\w*\s*\(\s*(\w+)")


# MSL samples through the texture object: `_MainTex.sample(sampler_MainTex, uv)`. Its `[[ texture(0) ]]`
# binding attribute is not a sample and would read as one to the GLSL pattern.
MSL_SAMPLED = re.compile(r"\b(\w+)\.sample(?:_compare)?\s*\(")


def samplers(text: str) -> set[str]:
    """The samplers and textures a program actually reads, by name."""
    if language_of(text) == "msl":
        return {name for name in MSL_SAMPLED.findall(strip(text)) if not name.startswith("sampler")}

    found = set()

    for first, second in SAMPLED.findall(strip(text)):
        name = first or second

        if name and not name.startswith("sampler"):
            found.add(name)

    return found


def declared_samplers(text: str) -> set[str]:
    """The samplers and textures a program declares, which is not the same set."""
    return set(SAMPLER_DECLARATION.findall(strip(text)))


def vector_widths(text: str) -> dict:
    """{width: count} for the vector constructions a program performs."""
    found = {}

    for width in VECTOR_WIDTH.findall(strip(text)):
        found[int(width)] = found.get(int(width), 0) + 1

    return found


# The keywords a pass declares. A variant is a choice among these, and the *base* variant - the one
# the exported ShaderLab carries - is the one with none of them enabled.
MULTI_COMPILE = re.compile(r"#\s*pragma\s+(?:multi_compile|shader_feature)\w*\s+([^\n]*)")
IFDEF = re.compile(r"^[ \t]*#[ \t]*(ifdef|ifndef|if|elif|else|endif)\b(.*)$", re.M)


def declared_keywords(text: str) -> set[str]:
    """Every keyword the shader's own pragmas name."""
    found = set()

    for line in MULTI_COMPILE.findall(text):
        for token in line.split():
            if token and token != "_" and not token.startswith("-"):
                found.add(token)

    return found


def base_variant(text: str) -> str:
    """
    The program text as the *base* variant compiles: every keyword the shader declares is off.

    The recovered program in an exported pass is the variant compiled with no keywords, so comparing
    it against the whole source reports every keyword-gated operation as lost. `Graphy/Graph Mobile`
    samples `_AlphaTex` under `ETC1_EXTERNAL_ALPHA`, and the base variant does not sample it because
    it was not compiled to. That is the same defect as reading a C# file whole, one language over.

    Only the keywords the shader itself declares are resolved. Anything else - a platform macro, a
    version gate - keeps both branches, so the error leans towards reporting a loss.
    """
    keywords = declared_keywords(text)

    if not keywords:
        return text

    output = []
    stack = []

    for line in text.splitlines():
        match = IFDEF.match(line)

        if match is None:
            output.append(line if all(frame[0] for frame in stack) else "")
            continue

        keyword, rest = match[1], match[2].strip()

        if keyword == "ifdef":
            value = False if rest in keywords else None
            stack.append([value is not False, value is True])
        elif keyword == "ifndef":
            value = True if rest in keywords else None
            stack.append([value is not False, value is True])
        elif keyword == "if":
            # `#if defined(X)` and `#if X`, where X is one of the shader's own keywords.
            named = re.findall(r"[A-Za-z_]\w*", rest)
            value = False if len(named) == 1 and named[0] in keywords else (
                False if len(named) == 2 and named[0] == "defined" and named[1] in keywords else None)
            stack.append([value is not False, value is True])
        elif keyword == "elif" and stack:
            stack[-1] = [not stack[-1][1], stack[-1][1]]
        elif keyword == "else" and stack:
            stack[-1][0] = not stack[-1][1]
        elif keyword == "endif" and stack:
            stack.pop()

        output.append("")

    return "\n".join(output)


def source_programs(shader_path: pathlib.Path, base_only: bool = True) -> list[str]:
    """Every program block a source `.shader` carries, as the base variant compiles them."""
    text = shader_path.read_text(encoding="utf-8", errors="replace")
    blocks = PROGRAM_BLOCK.findall(text)
    keywords = declared_keywords(text)

    if not base_only or not keywords:
        return blocks

    # The pragmas may sit outside the block that uses them, so the keyword set is taken from the whole
    # file and applied to each block.
    return [base_variant(f"{chr(10).join(f'#pragma multi_compile {k}' for k in keywords)}\n{block}")
            for block in blocks]


def source_shader_name(shader_path: pathlib.Path) -> str | None:
    text = shader_path.read_text(encoding="utf-8", errors="replace")
    match = re.search(r'Shader\s+"([^"]+)"', text)
    return match[1] if match else None


def recovered_programs(rip: pathlib.Path, shader_name: str) -> list[str]:
    """Every extracted program of one shader, read from the rip's own report."""
    report = rip / "AuxiliaryFiles" / "ShaderPrograms.json"

    if not report.is_file():
        return []

    found = []

    for record in json.loads(report.read_text()):
        if record.get("shader") != shader_name or not record.get("payload"):
            continue

        path = rip / "AuxiliaryFiles" / record["payload"]

        if path.is_file():
            found.append(path.read_text(encoding="utf-8", errors="replace"))

    return found


def language_of(program: str) -> str:
    """Which language an extracted program is in, from its own first line: MSL always includes the
    Metal standard library, and everything else this project extracts is HLSLcc's GLSL."""
    return "msl" if "#include <metal_stdlib>" in program else "glsl"


def backends_of(rip: pathlib.Path, shader_name: str) -> set:
    """Which compiled-program backends a shader carries, from the rip's own report."""
    report = rip / "AuxiliaryFiles" / "ShaderPrograms.json"

    if not report.is_file():
        return set()

    return {record.get("backend") for record in json.loads(report.read_text())
            if record.get("shader") == shader_name and record.get("backend")}


def merge(programs: list[str], language: str) -> dict:
    """The operations a whole shader reaches, over all of its programs."""
    total = {}

    for program in programs:
        # "recovered" picks each program's own language, since one rip can hold GLSL and MSL together.
        for name, count in operations(program, language_of(program) if language == "recovered" else language).items():
            total[name] = total.get(name, 0) + count

    return total
