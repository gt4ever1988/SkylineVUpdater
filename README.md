Dieses Skript ist für den [alt:V-Launcher](https://altv.mp) um laufend den Updatestand zu überprüfen ob eine neue Version von [alt:V](https://altv.mp) veröffentlicht wurde.
Sollte eine [Aktualisierung](https://docs.altv.mp/articles/cdn_links.html) festgestellt werden kann diese automatisch heruntergeladen werden (sofern der Server ausgeschalten ist). Weiteres kann eine Discord-Benachrichtigung versandt werden.

## Funktionsweite
Starte einfach die **SkylineVUpdater.exe** nachdem du die Einstellungen nach deinen Anforderungen eingestellt hast.

## Einstellungen (via App.config)
general:altVBranch
```
Gibt den Branch an welcher geladen werden soll, laut https://docs.altv.mp/articles/cdn_links.html
Verfügbare Versionen: release, rc and dev
Standard: release
```
general:altVOS
```
Gibt das Betriebssystem an welcher geladen werden soll, laut https://docs.altv.mp/articles/cdn_links.html
Verfügbare Versionen: x64_win32, x64_linux
Standard: x64_win32
```
general:altVRootPath
```
Gibt den Speicherort (Pfad) vom alt:V-Server an
Standard: C:\ALTV-S
```
general:altVServerExe
```
Gibt den Dateiname vom alt:V-Server an
Standard: altv-server.exe
```
general:autoUpdateWhenServerOff
```
Gibt an ob die Aktualisierung (Download notwendiger Dateien) automatisch erfolgen soll wenn der Server ausgeschalten ist. Zur Sicherheit wird keine Datei überschrieben sondern die bestehende Datei umbenannt und erst im Anschluss die neue Version geladen. Erstelle Backups kannst du manuell jederzeit löschen.
Standard: true
```
general:updateCheckSeconds
```
Gibt an wie oft eine neue Überprüfung durchgeführt werden soll - der angegebene Wert ist in Sekunden.
Standard: 30
```
general:extendLog
```
Gibt an ob ein eingeschränkte Logging oder vollständige Logging dargestellt werden soll. Ein vollständiges Logging zeigt alle einzelnen Überprüfungen jeder Datei.
Standard: false
```
module:coreClr
```
Aktiviert dass CoreClr/C# Module synchronisiert werden soll, bspw. AltV.Net.Host.dll
Standard: true
```
module:js
```
Aktiviert dass JS Module synchronisiert werden soll, bspw. js-module.dll
Standard: true
```
module:jsBytecode
```
Aktiviert dass JS Bytecode Module synchronisiert werden soll, bspw. js-bytecode-module.dll
Standard: true
```
module:voiceServer
```
Aktiviert dass Voice Server synchronisiert werden soll, bspw. altv-voice-server.exe
Standard: false
```
module:server
```
Aktiviert dass Server synchronisiert werden soll, bspw. altv-server.exe
Standard: true
```
module:serverBin
```
Aktiviert dass Server BIN synchronisiert werden soll, bspw. vehmodels.bin
Standard: true
```
discord:author
```
Gibt den Namen an welcher im Discord-Kanal gezeigt wird wenn ein Logging erstellt wird.
Standard: alt:V-Update
```
discord:webhookId
```
Gibt den Kanal-Webhook-ID laut Discord an, siehe https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks
Standard: 0
```
discord:webhookToken
```
Gibt den Kanal-Webhook-Token laut Discord an, siehe https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks
Standard: <leer>
```
discord:notificationUserId1
```
Gibt optional ein Discord-Benutzer-ID an welcher bei einem Logging markiert wird. Durch die Angabe 0 wird keine Benachrichtung erzeugt. https://support.discord.com/hc/en-us/articles/206346498-Where-can-I-find-my-User-Server-Message-ID-
Standard: 0
```
discord:notificationUserId2
```
Gibt optional einen weiteren Discord-Benutzer-ID an welcher bei einem Logging markiert wird. Durch die Angabe 0 wird keine Benachrichtung erzeugt. https://support.discord.com/hc/en-us/articles/206346498-Where-can-I-find-my-User-Server-Message-ID-
Standard: 0
```
discord:notificationUserId3
```
Gibt optional einen weiteren Discord-Benutzer-ID an welcher bei einem Logging markiert wird. Durch die Angabe 0 wird keine Benachrichtung erzeugt. https://support.discord.com/hc/en-us/articles/206346498-Where-can-I-find-my-User-Server-Message-ID-
Standard: 0
```
