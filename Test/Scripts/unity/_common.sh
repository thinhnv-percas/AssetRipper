# Shared preamble for the Unity validation scripts. Sourced, not executed.
#
# Every one of these refuses to run without a real editor rather than reporting anything. A validation
# that cannot be performed is not a passing validation, and a script that pretends otherwise is worse
# than no script.

set -u

require_unity() {
    if [ -z "${UNITY:-}" ]; then
        echo "UNITY is not set. Point it at the 2022.3.62f2 editor binary." >&2
        echo "This validation is BLOCKED, not passing. See reports/BLOCKED_UNITY_TESTS.md." >&2
        exit 90
    fi

    if [ ! -x "$UNITY" ]; then
        echo "UNITY=$UNITY is not an executable." >&2
        exit 90
    fi
}

require_project() {
    project=${1:?usage: $0 <unity project directory>}

    if [ ! -d "$project/Assets" ] || [ ! -d "$project/ProjectSettings" ]; then
        echo "$project does not look like a Unity project: no Assets/ or ProjectSettings/." >&2
        exit 2
    fi
}

# The version the binary and the reference source were both built with. A different editor will
# reimport and may migrate assets, which makes any result it produces a result about that editor.
expected_version() {
    if [ -f "$project/ProjectSettings/ProjectVersion.txt" ]; then
        grep -oE '[0-9]+\.[0-9]+\.[0-9]+[a-z][0-9]+' "$project/ProjectSettings/ProjectVersion.txt" | head -1
    fi
}

log_for() {
    mkdir -p "$(dirname "$1")"
    echo "$1"
}

# Runs the editor in batch mode and returns its exit code, having written the log where asked.
run_editor() {
    local logfile=$1; shift
    "$UNITY" -batchmode -nographics -logFile "$logfile" -projectPath "$project" "$@"
}

report_editor_errors() {
    local logfile=$1
    if [ ! -f "$logfile" ]; then
        echo "no editor log at $logfile" >&2
        return 1
    fi
    grep -cE 'error CS[0-9]+' "$logfile" || true
}
