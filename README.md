cloud-api-2020-2021-nielsxformer02
# About

naam: verschooten Niels

klasgroep: 2eacl1

onderwerp:

een api over the elder scrolls online trial groups

**Externe api url:** https://weatherstack.com/

**eigen api url:** https://cloud-api-314909.ew.r.appspot.com/

**client url:** https://cloud-api-2021.web.app/

# Updates

28/03
EER schema gemaakt voor referentie tijdens het maken van de API backend.

30/03
Models toegevoegd en begonnen met de start up van de API.
begonnen met het leggen van relaties.

31/03
edited model
generated test db -> zit nog een fout in.
tested first controller -> werkt nog niet helemaal.

27/04
fixed inheritance ETF.
added dummy data.
added items controller with getall methods.
added newtonsoft -> needed to get child fields in GetAllItems().
added modelbuilder relations for Item.
added getbyid for ItemController.
added post requests for ItemController.
added update armor and weapon in ItemController -> still needs some validations i think.

28/04
added playeritem => player en item veel op veel relatie.
added playercontroller with code.
added player validation checks.

30/04
zit vast met veel op veel relatie.
begonnen aan client.
added all getitem methods in client.
added postitem methods in client.
 => update en delete moet nog komen.
 
 10-14/05
 item component afgewerkt.
 begonnen aan player component.
 opgezocht over BPO, OAuth en JWT --> implementatie volgt nog.
 Open API bekeken --> implementatie volgt nog.
 
 18-20/05
 added paging, querrying.
 added authentication and authorization.
 JWT Token security added.
 firebase Oauth added.
 many to many relationship added in client.
 completed player component.
 added external API.
 
 24-25/05
 documentatie van externe api gemaakt.
 documentatie api uitbereidingen gemaakt.
 
 25-27/05
 proberen te deployen naar google cloud.
 gepushed naar google cloud.
 site gehost op firebase.
 
