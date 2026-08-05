"""Shared helper for tests exercising the Phase 19c background load (`/LoadFile`/
`/LoadFolder` now start `game_file_loader.start_load` on a thread and return immediately, so
any test asserting post-load state must wait for it first, exactly like the existing
`_wait_for_export_to_finish` pattern each export-wiring test file already has for exports."""
from __future__ import annotations

import time

from assetripper_gui_web import game_file_loader


def wait_for_load_to_finish(timeout: float = 5.0) -> None:
    deadline = time.monotonic() + timeout
    while game_file_loader.load_progress()["running"]:
        if time.monotonic() > deadline:
            raise AssertionError("load did not finish within the timeout")
        time.sleep(0.01)
