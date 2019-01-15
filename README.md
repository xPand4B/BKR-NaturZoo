# NaturZoo-Rheine
Hierbei handelt es sich um ein Schulprojekt, was dazu gedacht ist, eine eigens erstellte Datenbank so einfach wir möglich zu verwalten.

Die Datenbank läuft unter MySql, damit eine einfache Anbindung an eine Website möglich ist.

Dabei wurde versucht das Projekt nach dem vereinfachten __[Repository Design Pattern](https://www.norberteder.com/das-repository-pattern-anhand-eines-beispiels-inkl-tests/)__ zu erstellen.

## General Information
* Sobald man das Programm unter Visual Studio öffnet bekommt man jede Query innerhalb der __Debug Console__ angezeigt.
	* So lässt sich einfacher nachvollziehen, welche Daten geholt oder gesetzt werden.

## ToDo
* Create Log Services + Event
	* Push Log to DB and file
* Create Generic method __GetDropdownData()__
* Add possibility for join in query (EntityBase, Database, GenericRepository)