from assetripper_export_modules.scripts.mono_script_info import MonoScriptInfo


class _FakeScript:
    def __init__(self, class_name="", namespace="", assembly_name=""):
        self._data = {"m_ClassName": class_name, "m_Namespace": namespace, "m_AssemblyName": assembly_name}

    def get(self, name, default=None):
        return self._data.get(name, default)


def test_from_mono_script_fixes_assembly_name():
    info = MonoScriptInfo.from_mono_script(_FakeScript("Foo", "Bar", "CSharp"))
    assert info == MonoScriptInfo("Foo", "Bar", "Assembly - CSharp")


def test_from_mono_script_defaults_to_empty_strings():
    info = MonoScriptInfo.from_mono_script(_FakeScript())
    assert info == MonoScriptInfo("", "", "")


def test_is_injected():
    assert MonoScriptInfo("", "", "").is_injected()
    assert not MonoScriptInfo("Foo", "", "").is_injected()
    assert not MonoScriptInfo("", "", "Assembly-CSharp").is_injected()


def test_is_hashable_for_use_as_dict_key():
    assert {MonoScriptInfo("Foo", "", "A"): 1}.get(MonoScriptInfo("Foo", "", "A")) == 1
