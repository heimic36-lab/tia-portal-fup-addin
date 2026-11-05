# Architektur

## Überblick

Das Add-In wird als .NET-DLL (net48) geladen und nutzt die TIA Openness API (Siemens.Engineering.dll, V20).

## Komponenten

- **AddInMain** – Einstiegslogik: Export/Import von Bausteinen als Quellen.
- **Plugin** – Registrierung der Kontextmenü-Einträge (MenuAddIn).

## Export-Flow

1. Nutzer wählt im TIA Portal Bausteine aus (FUP, AWL, SCL, KOP …).
2. Kontextmenü → *Export as source*.
3. Add-In erzeugt über `GenerateSourceFromBlock()` eine Quelldatei in der gewählten Quelle.

## Import-Flow

1. Kontextmenü am Bausteinordner → *Import sources*.
2. Quelldateien aus dem gewählten Verzeichnis werden über die TIA Openness API in die Quelle eingespielt und kompiliert.

## Einschränkungen

- Benötigt installiertes TIA Portal V20 mit aktivierter Openness-Freigabe.
- Nicht alle Bausteintypen (z. B. Systembausteine) lassen sich exportieren.
