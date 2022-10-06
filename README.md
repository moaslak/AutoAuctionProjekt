# AutoAuctionProjekt
H2 tværfagligt projekt
Projektet er en WPF app som kan styre et auktionshus. Som udgangspunkt er det kun biler, som kan handles med; men der er muligheder for udvidelser af dette.
Systemet indeholder 3 hovedelementer: en backend, en MS SQL database og en WPF frontend.
## Backend
Backend'en håndtere al logikken, udregninger, oprettelser af auktioner, køretøjer og brugere; kommunikation med databasen og udstiller data til frontenden.
Bandend’en er skrevet i C#, og er løst koblet. Dette er opnået ved implementere adskillige interfaces. På denne kan associationer mellem klasser fjerenes, og nedarvningshierarkiet bliver dermed simplificeret.
Der findes 4, isolerede, hierarkier med de generaliserede klasser:
* Database
* User
* Vehicle
* Auction
### Database
Denne bruges til alt kommunikation med systemets SQL database. Denne skrevet som en partial klasse, for overskuelighedens skyld. Flere af partials implementerer et interface (IDatabase), som giver grundlæggende CRUD-funktionalitet, ud fra en generic<T>. Der laves override på samtlige metoder, så blot den generiske type skal ændres når den ønskede metode kaldes. 
AuctionBid klassen implementerer IKKE denne, da denne ikke har behov for fuld CRUD-funktionalitet.
### User
De oprettede brugere gemmes i en tabel i databasen. Der findes to specifikke brugerklasser, privateUser og corporateUser, som begge nedarver fra den generaliserede abstrakte klasse User. 
### Vehicle
Dette hierarki benyttes til at instantiere køretøjer. Denne er opbygget som et simpelt nedarvningshieraki, og kalder de respektive partials fra databaseklassen.
### Auction
Denne klasse samler de forskellige objekter, som skal bruges til at lave en auktion, samt øvrig information omkring auktionerne; pris, slutdata mm..



## Database
Databasen lagrer alle systemets data. Dette gælder køretøjer, auktioner, brugere og budhistorik. Det er MS SQL Server, som kører på en udleveret docker container. Denne styres udelukkende af backend’en.
Til denne er oprettede adskillige stored procedures. Det netop disse som bruges af backend’en til at tilgå data i databasen.

## Frontend
Frontend'en er brugerfladen til programmet. Denne binder sin data fra backenden, som denne henter fra databasen. Denne er en WPF applikation, og indeholder vinduer til brugerhåndtering (oprettelse og login), hentning af auktionsdata, oprettelse af auktioner og budhåndtering af disse. Der findes tilmed et vindue som viser den indloggede brugers budhistorik.

## Licens
Projekt er Open Source, og kode herfra kan frit benyttes af alle. Dog forventes det at projektets contributors krediteres.

## Contributors
moaslak – https://github.com/moaslak \
stef663k – https://github.com/stef663k
