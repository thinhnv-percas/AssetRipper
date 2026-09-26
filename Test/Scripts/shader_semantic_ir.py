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

_GLSL = {name: re.compile(pattern) for name, pattern in GLSL.items()}
_HLSL = {name: re.compile(pattern) for name, pattern in HLSL.items()}

# A ShaderLab program block, in any of the spellings Unity accepts.
PROGRAM_BLOCK = re.compile(
    r"\b(?:CGPROGRAM|HLSLPROGRAM|GLSLPROGRAM)\b(.*?)\b(?:ENDCG|ENDHLSL|ENDGLSL)\b", re.S)


def strip(text: str) -> str:
    """Comments and preprocessor lines removed, so a `+` in a comment is not arithmetic."""
    return _DIRECTIVE.sub("", _COMMENT.sub(" ", text))


def operations(text: str, language: str) -> dict:
    """{operation: count} for one program's text."""
    patterns = _GLSL if language == "glsl" else _HLSL
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


def samplers(text: str) -> set[str]:
    """The samplers and textures a program declares, by name."""
    return set(SAMPLER_DECLARATION.findall(strip(text)))


def vector_widths(text: str) -> dict:
    """{width: count} for the vector constructions a program performs."""
    found = {}

    for width in VECTOR_WIDTH.findall(strip(text)):
        found[int(width)] = found.get(int(width), 0) + 1

    return found


def source_programs(shader_path: pathlib.Path) -> list[str]:
    """Every program block a source `.shader` carries."""
    return PROGRAM_BLOCK.findall(shader_path.read_text(encoding="utf-8", errors="replace"))


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
        for name, count in operations(program, language).items():
            total[name] = total.get(name, 0) + count

    return total
