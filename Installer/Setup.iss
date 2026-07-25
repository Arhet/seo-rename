#define MyAppName "SEO Rename"
#define MyAppVersion "1.0"
#define MyAppPublisher "Даниил Гаранин"
#define MyAppExeName "SeoRename.exe"

[Setup]
AppId={{7F4B5A0E-2B8D-4C5A-A4D0-4C8F6F6D8D81}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}

DefaultDirName={autopf}\SEO Rename
DefaultGroupName=SEO Rename

OutputDir=Output
OutputBaseFilename=SEO-Rename-Setup

Compression=lzma2
SolidCompression=yes

WizardStyle=modern

SetupIconFile=..\Resources\SeoRename.ico
UninstallDisplayIcon={app}\SeoRename.exe

PrivilegesRequired=admin

[Files]
Source: "..\bin\Release\net10.0-windows\win-x64\publish\SeoRename.exe"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\SEO Rename"; Filename: "{app}\SeoRename.exe"

[Registry]

; Пункт меню
Root: HKCR; Subkey: "*\shell\SeoRename"; \
    ValueType: string; ValueName: ""; \
    ValueData: "SEO Rename"; Flags: uninsdeletekey

; Иконка
Root: HKCR; Subkey: "*\shell\SeoRename"; \
    ValueType: string; ValueName: "Icon"; \
    ValueData: "{app}\SeoRename.exe"

; Команда
Root: HKCR; Subkey: "*\shell\SeoRename\command"; \
    ValueType: string; ValueName: ""; \
    ValueData: """{app}\SeoRename.exe"" ""%1"""

[Run]
Filename: "{app}\SeoRename.exe"; Description: "Запустить SEO Rename"; Flags: nowait postinstall skipifsilent