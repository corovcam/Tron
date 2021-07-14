# Tron
Verzia: 1.0.0  
Dátum vydania 14.7.2021  
Jazyk skriptov: C#  
Game Engine: Unity 2020.3.11f1  
Autor: Martin Čorovčák

## Popis hry
Tron je hra pre 2-4 hráčov, ktorí sa aktívne pohybujú jedným zo 4 smerov (N, S, W, E) a ktorej cieľom je vydržať čo najdlhšie v hre alebo eliminovať svojich spoluhráčov a zostať ako posledný nažive.  
Prežiť znamená nenaraziť do prekážok, ktoré predstavujú buď steny hracieho poľa, farebné cesty ostatných spoluhráčov alebo vlastná cesta.  
V hre sa nachádzajú 2 špeciálne schopnosti (PowerUps). Zelené štvorčeky zrýchlia a červené štvorčeky spomalia všetkých hráčov v hre na určitú, náhodne danú dobu. Tieto "PowerUps" sa spawnujú náhodne ale postupne ich pribúda viac a viac.  
Na začiatku v hlavnom menu sa dá zvoliť počet hráčov, počiatočná rýchlosť a pozadie hry. Hra na začiatku poskytne základne info o ovládaní a na konci hry (keď zostane už iba 1 hráč nažive) vypíše výťaza. Ak sa všetci hráči navzájom eliminujú v rovnakom čase, hra skončí remízou.

## Popis projektu
V adresári Assets sa nachádzajú všetky podstatné súbory, ktoré tvoria základ celého projektu.

- **Animations** (Controllery sú v hre nevyužité, iba základné animácie)
    - GameStartText - animácia textu "PRESS SPACE TO START"
    - PauseIcon
- **Plugins**
    - Github
    - Sci-Fi UI - grafika, ktorú využívajú tlačítka v hre
- **Prefabs** - Predvytvorené objekty, ktoré využívajú Skripty na dynamické generovanie hráčov *(Player#)*, segmentov jednotlivých hráčov *(Player#Seg)* a zrýchlení/spomalení *(SpeedUp, SpeedDown)*
- **Renderers** - na renderovanie jednotlivých scien a osvetlenia sa využíva *Universal Render Pipeline* (svetlá hráčov a global illumination)
- **Resources** - grafika zvoleného pozadia
- **Scenes**
    - *Game* - hlavná časť hry, v ktorej prebieha väčšina Skriptov - pohyb hráčov, tvorba segmentov/powerupov, detekcia kolízií
    - *GameOver* - koniec hry s výsledným výťazom a s tlačítkom pre reset alebo návrat do hlavného menu
    - *StartMenu* - hlavné nastavenia hry a počiatočná Scéna
- **Scripts**
    - *DropdownHandler.cs* - načítava základné nastavenia hry z Dropdown polí v StartMenu
    - *GameInit.cs* - pri spustení Game scény sa nastavia všetky užívateľom definované nastavenia, hra sa pozastaví a zobrazí úžívateľovi nápovedu
    - *GameOptions.cs* - obsahuje verejnú statickú triedu GameOptions a statické premenné, ktoré využívajú ostatné Skripty na čítanie a zápis spoločných (verejných) dát
    - *PauseControl.cs* - Skript kontroluje či úžívateľ stlačil Escape alebo Space a na to hru pozastaví
    - *Player.cs* - každá inštancia hráča vlastní a riadi sa týmto skriptom, ktorý zabezpečuje pravidelný pohyb určitým smerom, rieši kolízie, deštrukcie jednotlivých inštancií hráčov a ich segmentov a kontroluje či nenastal koniec hry
    - *PowerUp.cs* - náhodné generovanie a jednotlivý štart a koniec efektov
    - *SceneHandler.cs* - rieši prepínanie rôznych Scien v hre
    - *Winner.cs* - rieši výsledný výpis výťaza

### Scéna: Game
Scénu tvorí viacero GameObject-ov, ktoré sú už aktivované alebo sa aktivujú po určitej udalosti, definovanej skriptami.

- **Main Camera** - obsahuje Skripty, ktoré sa aktualizujú pravidelne a sú vždy aktívne - kontrolujú udalosti každý Frame
- **Wall (#)** - obsahuje komponent *Box Collider 2D*, ktorý ohraničuje hraciu plochu
- **GridArea** - obsahuje komponent *Box Collider 2D*, v ktorom sa náhodne spawnujú *PowerUps*
- **Background** - jednoduchý Sprite 2D na pozadí
- **Global Light 2D** - global illumination, osvetlenie všetkých viditeľných GameObject-ov
- **CanvasStop** - canvas, ktorý sa aktivuje/deaktivuje po stisknutý ESC/Space
- **CanvasStart** - canvas, ktorý je aktívny iba na začiatku hry

## Nastavenie, inštalácia a spustenie
Hra je vytvorená v editore Unity verzie 2020.3.11f1, ktorý je taktiež potrebný na spustenie a nastavenie tohto projektu. Stačí len jednoducho naklonovať repozitár a otvoriť adresár projektu v Unity Hub alebo priamo v Editore. Pred prvým spustením sa vytvoria všetky potrebné meta súbory a skompilujú sa jednotlivé skripty.  
Hra je už predkompilovaná, využíva knižnicu WebGL a je v prehliadači dostupná a spustiteľná na tomto odkaze:  
<https://play.unity.com/mg/other/tron-zhu3>  
Alt link: <https://developer.cloud.unity3d.com/share/share.html?shareId=WkTwVLpa7w>  
Hra bola základne tvorená pre rozlíšenie 1920x1080, ale je optimalizovaná aj pre iné rozlíšenia v prehliadači (aspect ratio: 16:9, 4:3).  
