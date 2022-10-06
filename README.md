# AutoAuctionProjekt
H2 tvæfaglig projekt
Projektet er en WPF app som kan styre et auktionshus. Som udgangspunkt er det kun biler, som kan handles med; men der er muligheder for udvidelser af dette.
Systemet indeholder 3 hovedelementer: en backend, en MS SQL database og en WPF frontend.
## Backend
Backend'en håndtere al logikken, udregniner, oprettelser af auktioner, køretøjer og brugere; kommunikation med databasen og udstiller data til frontenden.

## Database
Databasen lagre alle systemets data. Dette gælder køretøjer, auktioner, brugere og budhistorik.

## Frontend
Frontend'en er brugerfladen til programmet. Denne binder sin data fra backenden, som denne modtager fra databasen.


