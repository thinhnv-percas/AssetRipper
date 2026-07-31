"""Entry point for `python -m assetripper_gui_web` / the `assetripper-gui-web` script."""
from __future__ import annotations

import sys


def main(argv: list[str] | None = None) -> int:
    argv = sys.argv[1:] if argv is None else argv
    port = int(argv[0]) if argv else 5000

    from . import create_app

    app = create_app()
    app.run(host="127.0.0.1", port=port)
    return 0


if __name__ == "__main__":
    sys.exit(main())
