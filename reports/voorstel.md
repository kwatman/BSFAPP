# Over het topic
## Situering
In haar vrije tijd houdt mijn vriendin haar vaak bezig met het bakken van patisserie, gebak en koekjes.
Ze zou dit op termijn graag in zelfstandig bijberoep doen, en heeft zelf al een naam (**Glazed**) en een huisstijl incl. logo's.
Wat ze nog niet heeft is een website + webshop en een bijhorende mobile app. Deze zou ik dus voor haar willen maken, gelet op alle vereisten voor dit project.

## Beschrijving
Om het gebruik van twee gebruikersrollen voor de Identity te waarborgen, zal het algemeen project bestaan uit een gesloten catalogus/webshop waarop enkel ingelogde gebruikers bestellingen kunnen plaatsen. Er wordt niet gewerkt met een inventaris omdat alles vers op bestelling wordt gemaakt. Wel worden bestellingen in een winkelmandje geplaatst.
Daarnaast is er een Admin-portaal om de CRUD-funtionaliteiten op de producten toe te passen.
Dit model wordt toegepast op zowel de Vue.js-, mobile- en blazor app.

De **Klanten** starten bij een *index*-page met een banner, wat info over haar onderneming, en enkele producten in de kijker/suggesties van de week.

Er kan worden genavigeerd naar *producten*, waar alles wat kan besteld worden wordt getoond. Hier kan worden gefilterd op 3 verschillende parameters:
* Categorien: Taarten, Gebak, Koekjes met glazuur, Koekjes met rolfondant
* Dieetvereisten: Vegan, Glutenvrij, Notenvrij, Lactosevrij
* Prijs met slider

Producten worden getoond via product cards met een foto en wat info met de catergorie, dieetvereiste en prijs erbij. Er is een bestelknop per product aanwezig die en pop-up screen toont die het gewenste aantal vraagt. Bestelde producten worden in een winkelmandje bijgehouden.

Er kan genavigeerd worden naar *blog*, waar blogposts, recepten en tips worden getoond in chronologische volgorde.

Ten slotte kan er genavigeerd worden naar *contact*, waar contactgegevens, een map, een form en links naar sociale media staan.

Ook is er een grote knop *bestelling afronden*, die navigeert naar een bestelpagina om alle items in het winkelmandje te bestellen. Hier dient de ophaaldatum te worden ingevuld. 
Naast deze knop bevinden zich de *registreer*- en *login*-knoppen, die elk naar hun respectievelijke vensters navigeren. 

De **Admin** kan CRUD-operaties uitvoeren op de data die wordt getoond in de apps. Bv. producten, categorien en blogposts toevoegen, wijzigen en verwijderen.
Ook kunnen hier de bestellingen bekeken worden, alsook users wijzigen en verwijderen. 

# Modulespecifieke vereisten
## Integration
### Web API
Uiteraard zal alle data aangeleverd worden via de zelfgeprogrammeerde Web API. Hiervoor zullen 4 controllers worden geschreven:
* UsersController
* ProductsController
* CategoriesController
* BlogpostsController

Volgende EndPoints zullen aangesproken kunnen worden:
Endpoint | Methode
---------|----------
api/users| GET, POST, PUT
api/users/1 | GET, DEL
api/products | GET, POST, PUT
api/products/1 | GET, DEL
api/categories | GET, POST, PUT
api/categories/1 | GET, DEL
api/categories/1/products | GET
api/blogposts | GET, POST, PUT
api/blogposts | GET, DEL

Alle GET-methoden zijn toegankelijk voor gebruikers, alle overige methoden zijn enkel toegankelijk voor Admin.

### Vue.js-app
De app gemaakt in Vue.js zal alle functionaliteit bevatten die wordt beschreven in de algemene beschrijving van dit project hierboven.

## Mobile Development
### Xamarin App
De Xamarin App zal een mobiele versie zijn van het algemeen project, met dezelfde huisstijl, maar geoptimaliseerd voor mobiel gebruik. Dit door vooral gebruik te maken van StackLayout. 
Voor de data zal de zelfgeprogrammeerde Web API aangesproken worden. 
Als Native Service zal gebruik worden gemaakt van locatievoorzieningen en maps implementaties om de route van de gebruiker naar het afhaalpunt te tonen.

Ik verwijs naar de Wireframes voor in de daartoebehorende map voor een eerste indruk van de UI. 

## Innovation
### Blazor App
Ook de Blazor App zal het algemeen project implementeren, zij het in een verkorte versie. De data wordt wederom aangesproken via de Web API. 
De app zal bestaan uit de gevraagde CRUD-pagina, waarop meteen alle producten te zien zijn, met de mogelijkheid om hier meteen alle CRUD-operaties op toe te passen, en de Concepts-pagina, waarop via een extern Blazor-component afbeeldingen van producten zullen worden getoond met de mogelijkheid om hier te filteren.
Ik zal hier ook het spelletje "Memory" voorzien met het thema "Taarten en Gebak". 
