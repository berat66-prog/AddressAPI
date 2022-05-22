# AddressAPI

.NET/C# API case

Instructies voor het opstarten en gebruik van het project:

Clone het project in een IDE. Open de Address.db file in de Data folder met de tool "DB Browser For SQLITE".

De solution bestaat uit twee projecten namelijk AddressAPI Project en Distances Project. De AddressAPI project word gebruikt om de CRUD operations
uit te voeren (Deel 1 van de opdracht) en om te filteren en te sorteren(deel 2 van de opdracht). Het project "Distances" binnen de solution wordt gebruikt
om de afstand in km tussen twee adressen te berekenen (Deel 3 van de opdracht).

De onderdeel waar ik trots op ben is deel 3 van de opdracht, omdat ik niet eerder een connectie heb gemaakt met een geolocation API(Google Maps API) en het een uitdaging
is geweest om dit uit te vogelen en werkend te krijgen. Ik hou van uitdagingen en het is me uiteindelijk gelukt. Bij het runnen van de "Distance" project is er een
Http get methode op Swagger te zien waarbij je twee adres id's, die in de database bestaan, in de velden moet invullen. Dit returned vervolgens de afstand in km 
tussen beide adressen.

Deel 1 van de opdracht is niet echt een uitdaging geweest. Dit was het implementeren van standaard CRUD operations waar ik al ervaring mee had. Wel heb ik als
extra's gebruik gemaakt van een repository pattern en een DTO. Deel 2 van de opdracht was ook een beetje uitvogelen hoe ik nou zonder if en switch statements dynamisch kon filteren en sorteren, maar uiteindelijk is dit ook goed gekomen.
