# TIA Portal FUP Add-In

Ein Add-In für **Siemens TIA Portal V20**, um FUP-Bausteine (und weitere Bausteintypen) als Quelle zu **exportieren** und **importieren**.

## Funktionen

- Export von FUP-/AWL-/SCL-/KOP-Bausteinen als TIA-Quelldateien (.scl / .awl)
- Export ausgewählter Bausteine oder ganzer Bausteinordner
- Import von Quelldateien zurück in das Projekt
- Auswahl des Zielordners beim Import

## Installation

1. Dieses Repository klonen und mit Visual Studio bauen (Ziel: .NET Framework, kompatibel zu TIA Portal V20 Add-Ins).
2. Die resultierende DLL in den Add-In-Ordner des TIA-Projekts kopieren:
   `<Projektordner>/AddIns/`
3. Im TIA Portal: Werzeugkasten → Add-Ins → Add-In aktivieren.

## Nutzung

- Im Projektbauer rechten Mausklick auf einen Baustein oder Ordner → Add-In → **Export blocks as sources**
- Rechte Mausklick auf einen Bausteinordner → Add-In → **Import sources**

## Projektstruktur

```
src/TiaFupAddIn/        Add-In Quellcode (C#)
src/TiaFupAddIn.Tests/  Unit-Tests
docs/                   Dokumentation
.github/workflows/      CI-Build
```

## Voraussetzungen

- Siemens TIA Portal V20 mit OpenSource-/Add-In-Fähigkeit
- Visual Studio 2022
- Referenz auf `Siemens.Engineering.dll` (Version 20)

## Lizenz

MIT – siehe [LICENSE](LICENSE).
