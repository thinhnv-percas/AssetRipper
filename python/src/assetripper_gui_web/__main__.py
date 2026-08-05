"""Entry point for `python -m assetripper_gui_web` / the `assetripper-gui-web` script."""
from __future__ import annotations

import sys
import threading
import webbrowser


def main(argv: list[str] | None = None) -> int:
    argv = sys.argv[1:] if argv is None else argv
    port = int(argv[0]) if argv else 5000
    no_browser = "--no-browser" in argv

    from . import create_app

    app = create_app()

    if not no_browser:
        # Mirrors upstream's WelcomeMessage.cs, which opens the default browser to the
        # local URL on startup. `webbrowser.open` degrades to a no-op-ish failure (returns
        # False, doesn't raise) when there's no browser/display to open -- fine for a
        # headless server, where `--no-browser` skips even trying.
        url = f"http://127.0.0.1:{port}/"
        threading.Timer(1.0, lambda: webbrowser.open(url)).start()

    app.run(host="127.0.0.1", port=port, threaded=True)
    return 0


if __name__ == "__main__":
    sys.exit(main())
