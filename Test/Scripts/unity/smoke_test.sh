#!/usr/bin/env bash
# U8: install the built player on a connected device and read the first 30 seconds of its log.
set -u
apk=${1:?usage: smoke_test.sh <apk>}

command -v adb >/dev/null || { echo "adb is not installed; this validation is BLOCKED." >&2; exit 90; }
[ -f "$apk" ] || { echo "no apk at $apk" >&2; exit 2; }

package=$(aapt dump badging "$apk" 2>/dev/null | sed -n "s/package: name='\([^']*\)'.*/\1/p")
[ -n "$package" ] || { echo "could not read the package name from $apk" >&2; exit 2; }

adb install -r "$apk" || exit 1
adb logcat -c
adb shell monkey -p "$package" -c android.intent.category.LAUNCHER 1 || exit 1

sleep 30
log=${LOG:-player.log}
adb logcat -d > "$log"

echo "log $log"
grep -cE 'Unity|Exception' "$log" || true
! grep -qE 'FATAL EXCEPTION|NullReferenceException|Unhandled Exception' "$log"
