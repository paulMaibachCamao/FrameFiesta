# Einleitung
Das Backend zum BT-S Schulprojekt im 3. Lehrjahr - FrameFiesta

[Frontend Repo](https://github.com/JannikKrusch/framefiesta)

# Einrichtung
Das Backend ist nach dem Klonen des Repository ausführbar, jedoch erfüllt es erst mit der Datenbank die vollständige Funktion

## Kurzanleitung
1. Repository klonen
2. ```bash
   FrameFiesta.Api
   └───appsettings.json
   ```
    MongoDBCompass installieren und `ConnectionString` anpassen
4. Postman installieren
5. Dummydaten mit Postman erstellen

## Anleitung
Wir benutzen MongoDB als Datenbank. Mit [MongoDBCompass](https://www.mongodb.com/try/download/compass) bietet MongoDB eine grafische Oberfläche, um mit dieser zur interagiern.
Die Standardeinstellungen zum Connecten benutzen, die `URL` im Backend in der `appsettings.json` beim `ConnectionString` einfügen.

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/97b4d41d-dec6-4ec0-b969-a3470ec312d3)

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/5a8ec395-0490-4dca-97bb-f70c783fd0db)

Falls nötig, muss nun [Postman](https://www.postman.com/downloads/) installiert werden.
Nun muss man die `Postman Collection` und die `Dummydaten` Dateien herunterladen.

[FrameFiesta.postman_collection.json](https://github.com/paulMaibachCamao/FrameFiesta/files/13752813/FrameFiesta.postman_collection.json)

[DummyDaten.json](https://github.com/paulMaibachCamao/FrameFiesta/files/13752820/DummyDaten.json)

Bevor man die Daten einspielen kann, müssen die Datenbank und das Backend im Hintergrund laufen.

In Postman auf der linken Seite auf `Import` drücken und die Collection zum importieren auswählen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/ebfc2d4b-8bad-4b43-8204-46939a08a807)

Danach ganz unten rechts auf den `Runner` gehen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/2de6f2c2-18d3-4a68-826c-e70baeb871f5)

Die `FrameFiesta` Collection in das `Run order` Feld ziehen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/90c1bdcb-6481-49fc-9342-da76fa8d4192)

Schließlich nur noch rechts bei `Select File` die `DummyData.json` auswählen und auf `Run FrameFiesta` drücken um die Dummydaten einzuspielen

![image](https://github.com/paulMaibachCamao/FrameFiesta/assets/101870362/9720a6d0-d5f8-401c-866e-1d516440abc6)
