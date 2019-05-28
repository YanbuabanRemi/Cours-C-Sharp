// Pour tester une application, il existe deux méthodes différentes :

// Les tests fonctionnels :
// => test toutes les possibilités directement en lançant le logiciel
// Problématique = 
// - le cout en ressources, 
// - le risques de regresser 
// - un temps de debug élévé

// Les tests unitaires :
// => test toutes les fonctionnalités indépendement des autres
// Problématique = 
// - il faut développer un sous projet qui va tester toutes les fonctionnalités du projet 
// - beaucoup de test en fonction des possibilités de la méthode
// - code moins coupler

// Un bon test unitaire doit regrouper plusieurs caractéristiques
// - Rapidité
// - Etre isolé ( il ne doit pas dépendre d'une base de donnée)
// - Etre cohérent avec le code
// - Autovérification
// - Respect des délais décriture

// Regles de bon sens :

// Nommages des tests (en 3 parties)
// 1/ Nom de la méthode à tester
// 2/ Scénario du test
// 3/ Comportement attendu

// AjouterClient = nom de la méthode
// Client = classe ou se situe cette méthode
// bool = valeur renvoyé par la méthode
public void AjouterClient_Client_bool(){
}

// Respect du scénario ou organisation du test
// 1/ Création et configuration des objets du test
// 2/ Action sur objet
// 3/ Insertion du résultat

Class classGenerique = new Class();
public void AjouterClient_Class_bool(){
    // 1 partie
    Client c = new Client(){
        prenom = "Remi",
        nom = "Yanbuaban"
    };
    // 2 partie (dans cet exemple, cette phrase ne sert à rien puisqu'elle est repris juste aprés dans l'Assert)
    classGenerique.AjouterClient(c);
    // 3 partie
    Assert.IsTrue(classGenerique.AjouterClient(c));
}

// Ecrire des tests minimaux
// Eviter les chaines magiques (il vaut mieux inserer les paramètres dans des variables plutot que de les utilisers directement dans les paramètes de la méthode)
Class classGenerique = new Class();
string nomVariable = "Yanbuaban";
string prenomVariable = "Remi";
public void AjouterClient_Class_bool(){
    Client c = new Client(){
        prenom = prenomVariable,
        nom = nomVariable
    };
    Assert.IsTrue(classGenerique.AjouterClient(c));
}

// Eviter les logiques tests (If, Else, ...)
// Eviter les insertions multiples




// La méthode traditionnelle consistait à écrire le code et ensuite tester les méthodes

// La méthode TDD (Test Driven Development) fait l'inverse, cad qu'on développe le code à partir des tests
// A partir du diagramme de classe et d'activité,  on défini les tests possibles, puis on doit faire échouer les tests
// Ensuite on vérifie l'echec des tests
// On implémente la logique métier de la méthode
// Vérification de la réussite des tests
// Dernière étapes : le Refractoring (on nettoie le code des éléments qui ne servent à rien ou qui peuvent être factoriser)
// Red => Green => Refractor

// Les différents TDD dans le .NET 
// - NUnit
// - XUnit
// - MSTest
