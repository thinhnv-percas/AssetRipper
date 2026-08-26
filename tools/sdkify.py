#!/usr/bin/env python3
"""
Convert the legacy .csproj files dnSpy.Console emits into SDK-style projects
that a current .NET SDK can actually build.

dnSpy writes ToolsVersion 4.0 projects, and for some assemblies it picks a
target that no longer exists on a modern machine (Mono.Cecil comes out as
.NETPortable Profile344). This rewrites each project to Microsoft.NET.Sdk on a
single modern .NET Framework target, keeps the <Reference> and
<EmbeddedResource> items, and lets the SDK glob the .cs files.

Usage:
    python sdkify.py <decompiled-project.csproj> [...]
    python sdkify.py --all Recovered
"""
import os, re, sys
import xml.etree.ElementTree as ET

NS = 'http://schemas.microsoft.com/developer/msbuild/2003'
ET.register_namespace('', NS)

# WPF/WinForms assemblies need the desktop SDK; everything else the plain one
DESKTOP_REFS = {'PresentationCore', 'PresentationFramework', 'WindowsBase',
                'System.Windows.Forms', 'System.Drawing'}


def convert(path, tfm='net472'):
    tree = ET.parse(path)
    root = tree.getroot()

    def q(tag):
        return '{%s}%s' % (NS, tag)

    asm_name = None
    root_ns = None
    out_type = 'Library'
    for pg in root.findall(q('PropertyGroup')):
        for el in pg:
            tag = el.tag.split('}')[-1]
            if tag == 'AssemblyName':
                asm_name = el.text
            elif tag == 'RootNamespace':
                root_ns = el.text
            elif tag == 'OutputType':
                out_type = el.text or 'Library'
    asm_name = asm_name or os.path.basename(path)[:-7]

    refs, embedded, nones = [], [], []
    for ig in root.findall(q('ItemGroup')):
        for el in ig:
            tag = el.tag.split('}')[-1]
            inc = el.get('Include')
            if not inc:
                continue
            if tag == 'Reference':
                refs.append((inc, el.find(q('HintPath')).text if el.find(q('HintPath')) is not None else None))
            elif tag == 'EmbeddedResource':
                ln = el.find(q('LogicalName'))
                embedded.append((inc, ln.text if ln is not None else None))
            elif tag == 'None' and inc.lower().endswith(('.manifest', '.settings')):
                nones.append(inc)

    use_wpf = any(r[0] in ('PresentationCore', 'PresentationFramework') for r in refs)
    use_wf = any(r[0] == 'System.Windows.Forms' for r in refs)
    desktop = use_wpf or use_wf or any(r[0] in DESKTOP_REFS for r in refs)
    sdk = 'Microsoft.NET.Sdk.WindowsDesktop' if desktop else 'Microsoft.NET.Sdk'

    L = []
    L.append('<Project Sdk="%s">' % sdk)
    L.append('  <PropertyGroup>')
    L.append('    <AssemblyName>%s</AssemblyName>' % asm_name)
    if root_ns:
        L.append('    <RootNamespace>%s</RootNamespace>' % root_ns)
    else:
        L.append('    <RootNamespace />')
    L.append('    <OutputType>%s</OutputType>' % out_type)
    L.append('    <TargetFramework>%s</TargetFramework>' % tfm)
    L.append('    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>')
    L.append('    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>')
    L.append('    <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>')
    L.append('    <LangVersion>latest</LangVersion>')
    L.append('    <NoWarn>$(NoWarn);CS0108;CS0109;CS0114;CS0162;CS0164;CS0169;CS0219;CS0414;CS0618;CS0649;CS1030;CS1717;CS3021;SYSLIB0011</NoWarn>')
    L.append('    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>')
    if use_wpf:
        L.append('    <UseWPF>true</UseWPF>')
    if use_wf:
        L.append('    <UseWindowsForms>true</UseWindowsForms>')
    L.append('    <EnableDefaultEmbeddedResourceItems>false</EnableDefaultEmbeddedResourceItems>')
    L.append('  </PropertyGroup>')

    skip = {'mscorlib', 'System.Runtime'}
    keep = [r for r in refs if r[0] not in skip]
    if keep:
        L.append('  <ItemGroup>')
        for inc, hint in keep:
            if hint:
                L.append('    <Reference Include="%s"><HintPath>%s</HintPath></Reference>' % (inc, hint))
            else:
                L.append('    <Reference Include="%s" />' % inc)
        L.append('  </ItemGroup>')

    if embedded:
        L.append('  <ItemGroup>')
        for inc, ln in embedded:
            if ln:
                L.append('    <EmbeddedResource Include="%s" LogicalName="%s" />' % (inc, ln))
            else:
                L.append('    <EmbeddedResource Include="%s" />' % inc)
        L.append('  </ItemGroup>')

    L.append('</Project>')

    open(path, 'w', encoding='utf-8-sig', newline='\r\n').write('\n'.join(L) + '\n')
    return sdk, tfm, len(keep), len(embedded)


def main():
    args = sys.argv[1:]
    if not args:
        print(__doc__)
        return 2
    if args[0] == '--all':
        root = args[1]
        targets = []
        for dirpath, _, files in os.walk(root):
            for f in files:
                if f.endswith('.csproj'):
                    targets.append(os.path.join(dirpath, f))
    else:
        targets = args
    for t in targets:
        try:
            sdk, tfm, nref, nres = convert(t)
            print('%-46s -> %s / %s  (%d refs, %d resources)'
                  % (os.path.basename(t), sdk.replace('Microsoft.NET.', ''), tfm, nref, nres))
        except Exception as e:
            print('%-46s FAILED: %s' % (os.path.basename(t), e))
    return 0


if __name__ == '__main__':
    sys.exit(main())
