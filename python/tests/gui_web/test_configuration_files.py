"""
Tests for `/ConfigurationFiles` and its five edit routes (2026-08-03).

Before this, `/ConfigurationFiles` rendered `stub.html` and the five POST routes upstream has
(`Singleton/Add`, `Singleton/Remove`, `List/Add`, `List/Replace`, `List/Remove`) didn't exist --
a gap the Phase 20e route audit found. It's also the first and only consumer of
`assetripper_configuration`'s DataStorage hierarchy, which was ported and tested in Phase 22 and
then had no callers at all; see `config_files.py`'s docstring on why it gets its own storage
instance instead of reusing `FullConfiguration`.
"""
from __future__ import annotations

import pytest
from assetripper_gui_web import config_files, create_app


@pytest.fixture(autouse=True)
def _reset_config_files():
    config_files.reset()
    yield
    config_files.reset()


@pytest.fixture
def client():
    app = create_app()
    app.testing = True
    return app.test_client()


def test_page_renders_and_is_no_longer_a_stub(client):
    response = client.get("/ConfigurationFiles")

    assert response.status_code == 200
    text = response.get_data(as_text=True)
    assert "Configuration Files" in text
    assert "Singletons" in text and "Lists" in text
    assert "not been implemented" not in text, "should no longer be the stub page"


def test_page_reports_empty_storages_up_front(client):
    text = client.get("/ConfigurationFiles").get_data(as_text=True)
    assert "No singleton entries." in text
    assert "No list entries." in text


# --- singletons -----------------------------------------------------------------------------


def test_singleton_add_then_shows_on_the_page(client):
    response = client.post("/ConfigurationFiles/Singleton/Add", data={"Key": "my-key", "Content": "hello"})
    assert response.status_code == 302

    text = client.get("/ConfigurationFiles").get_data(as_text=True)
    assert "my-key" in text
    assert "hello" in text


def test_singleton_add_with_an_existing_key_replaces_the_content(client):
    """`DataStorage.add` rejects duplicate keys, so this path has to update in place -- the form
    submits the same key again to edit a value."""
    client.post("/ConfigurationFiles/Singleton/Add", data={"Key": "k", "Content": "first"})
    client.post("/ConfigurationFiles/Singleton/Add", data={"Key": "k", "Content": "second"})

    text = client.get("/ConfigurationFiles").get_data(as_text=True)
    assert "second" in text
    assert "first" not in text


def test_singleton_remove_clears_the_content_but_keeps_the_key(client):
    """Mirrors upstream exactly: `HandleSingletonRemovePostRequest` calls `.Clear()` on the
    entry rather than dropping the key, so the key stays listed with empty content."""
    client.post("/ConfigurationFiles/Singleton/Add", data={"Key": "k", "Content": "the-content"})
    client.post("/ConfigurationFiles/Singleton/Remove", data={"Key": "k"})

    # Asserted against the storage rather than the rendered HTML: the page is full of
    # `value="..."` form attributes, so a substring check on the response would pass for the
    # wrong reason.
    assert "k" in config_files.singletons().keys
    assert config_files.singletons()["k"].text == ""

    text = client.get("/ConfigurationFiles").get_data(as_text=True)
    assert "the-content" not in text


def test_singleton_remove_of_an_unknown_key_is_a_noop(client):
    response = client.post("/ConfigurationFiles/Singleton/Remove", data={"Key": "never-added"})
    assert response.status_code == 302


def test_singleton_routes_require_a_key(client):
    assert client.post("/ConfigurationFiles/Singleton/Add", data={"Content": "x"}).status_code == 400
    assert client.post("/ConfigurationFiles/Singleton/Remove", data={}).status_code == 400


# --- lists ----------------------------------------------------------------------------------


def test_list_add_creates_the_key_then_appends_to_it(client):
    client.post("/ConfigurationFiles/List/Add", data={"Key": "paths", "Content": "one"})
    client.post("/ConfigurationFiles/List/Add", data={"Key": "paths", "Content": "two"})

    assert list(config_files.lists()["paths"].strings) == ["one", "two"]
    text = client.get("/ConfigurationFiles").get_data(as_text=True)
    assert "paths" in text and "one" in text and "two" in text


def test_list_replace_changes_only_the_addressed_index(client):
    for content in ("a", "b", "c"):
        client.post("/ConfigurationFiles/List/Add", data={"Key": "k", "Content": content})

    response = client.post("/ConfigurationFiles/List/Replace", data={"Key": "k", "Index": "1", "Content": "B"})

    assert response.status_code == 302
    assert list(config_files.lists()["k"].strings) == ["a", "B", "c"]


def test_list_remove_drops_only_the_addressed_index(client):
    for content in ("a", "b", "c"):
        client.post("/ConfigurationFiles/List/Add", data={"Key": "k", "Content": content})

    client.post("/ConfigurationFiles/List/Remove", data={"Key": "k", "Index": "0"})

    assert list(config_files.lists()["k"].strings) == ["b", "c"]


def test_list_routes_reject_an_out_of_range_index(client):
    client.post("/ConfigurationFiles/List/Add", data={"Key": "k", "Content": "only"})

    assert client.post("/ConfigurationFiles/List/Replace", data={"Key": "k", "Index": "5", "Content": "x"}).status_code == 400
    assert client.post("/ConfigurationFiles/List/Remove", data={"Key": "k", "Index": "5"}).status_code == 400
    assert list(config_files.lists()["k"].strings) == ["only"], "a rejected edit must not mutate"


def test_list_routes_reject_an_unknown_key(client):
    assert client.post("/ConfigurationFiles/List/Replace", data={"Key": "nope", "Index": "0", "Content": "x"}).status_code == 400
    assert client.post("/ConfigurationFiles/List/Remove", data={"Key": "nope", "Index": "0"}).status_code == 400


def test_list_routes_reject_a_non_numeric_index(client):
    client.post("/ConfigurationFiles/List/Add", data={"Key": "k", "Content": "only"})
    assert client.post("/ConfigurationFiles/List/Remove", data={"Key": "k", "Index": "abc"}).status_code == 400


def test_list_add_requires_a_key(client):
    assert client.post("/ConfigurationFiles/List/Add", data={"Content": "x"}).status_code == 400


# --- interaction with /Reset ----------------------------------------------------------------


def test_reset_clears_configuration_entries(client):
    """These are session state like the loaded game, so a Reset that left them behind would be a
    half-reset."""
    client.post("/ConfigurationFiles/Singleton/Add", data={"Key": "s", "Content": "v"})
    client.post("/ConfigurationFiles/List/Add", data={"Key": "l", "Content": "v"})

    client.post("/Reset")

    text = client.get("/ConfigurationFiles").get_data(as_text=True)
    assert "No singleton entries." in text
    assert "No list entries." in text
