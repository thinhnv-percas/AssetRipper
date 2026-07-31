"""Phase 11: `assetripper-gui-web` auto-opens the default browser on startup (mirrors
upstream's WelcomeMessage.cs), unless `--no-browser` is passed. `app.run()` itself is
monkeypatched out here since it would otherwise block forever serving requests.
"""
from __future__ import annotations

import assetripper_gui_web.__main__ as gui_main


class _FakeApp:
    def __init__(self):
        self.run_calls = []

    def run(self, **kwargs):
        self.run_calls.append(kwargs)


def test_main_schedules_browser_open_by_default(monkeypatch):
    fake_app = _FakeApp()
    scheduled = []

    class _FakeTimer:
        def __init__(self, delay, func):
            scheduled.append((delay, func))

        def start(self):
            scheduled[-1][1]()  # run immediately instead of waiting a real second

    opened = []
    monkeypatch.setattr(gui_main.threading, "Timer", _FakeTimer)
    monkeypatch.setattr(gui_main.webbrowser, "open", lambda url: opened.append(url))
    monkeypatch.setattr("assetripper_gui_web.create_app", lambda: fake_app)

    gui_main.main(["5050"])

    assert opened == ["http://127.0.0.1:5050/"]
    assert fake_app.run_calls == [{"host": "127.0.0.1", "port": 5050, "threaded": True}]


def test_main_skips_browser_open_with_no_browser_flag(monkeypatch):
    fake_app = _FakeApp()
    monkeypatch.setattr("assetripper_gui_web.create_app", lambda: fake_app)

    opened = []
    monkeypatch.setattr(gui_main.webbrowser, "open", lambda url: opened.append(url))

    gui_main.main(["5051", "--no-browser"])

    assert opened == []
    assert fake_app.run_calls == [{"host": "127.0.0.1", "port": 5051, "threaded": True}]
