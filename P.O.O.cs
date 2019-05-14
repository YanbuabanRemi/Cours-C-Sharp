------------------------------------------------------------------- Programmation orienté objet ----------------------------------------------------------------------

------------------------------------------------------------------- 1 - Encapsulation ---------------------------------------------------------------------- 

// L’encapsulation signifie qu’un groupe de propriétés, méthodes et autres membres corrélés est traité comme une unité ou un objet unique.
// Il protège les données de l'objet et son fonctionnement interne


____________________________________________________________________________Les Classes ______________________________________________________________________

// Chaque classe peut avoir différents membres de classe : 
// - des propriétés qui décrivent les données de classe
// - des méthodes qui définissent le comportement de classe 
// - des événements qui permettent la communication entre les différents objets et classes.

// Création de class :
Voiture v1 = new Voiture();
v1.couleur = "rouge";
v1.model = "Ford";
v1.km = 20000;

Voiture v1 = new Voiture("rouge", "ford");



______________________________________________________________________Les attributs et propriétés__________________________________________________________________

// Les attributs, les propriétés et les champs sont des informations contenues dans un objet. Les champs sont similaires aux variables, car ils peuvent être lus ou définis directement.
// Les attributs et les propriétés peuvent être en public ou private

public string couleur;
public string model;
public int km;
private bool roule;

// La méthode get set permet d'accéder au contenu de l'attribut
// Alt + enter sur la propriété

//attribut
private int idClient;
//propriété
public int IdClient { get => idClient; set => idClient = value; }

__________________________________________________________________________________Les méthodes____________________________________________________________________

public void Rouler()
    {
        Console.WriteLine("Je roule " + model);
    }

// Les méthodes peuvent prendre un ou plusieurs paramètres

public void SetCouleur(string c)
        {
           couleur = c;
        }
public void SetCouleur1(string c, string m)
        {
           couleur = c;
           model = m;
        }

_______________________________________________________________________________Les constructeurs____________________________________________________________________

//Le constructeur est une méthode qui s'effectuera lors de la création de l'objet

public Voiture()
        {
            Km = 1000;
        }

// On peut creer un constructeur à partir d'un constructeur déjà existant

public Voiture(string toto) : this()
        {
            Couleur = toto;
        }
// this() fera reférance au constructeur Voiture() car this() ne contient aucune propriété

public Voiture(string c, string m) : this(c)
        {
            Model = m;
        }
// this(c) fera reférance au constructeur Voiture(string toto) car this(c) contient une seul propriété (c) comme dans le constructeur Voiture(string toto)
// Le constructeur Voiture(string c, string m) construira la class d'abord par 
// - le constructeur Voiture() puis
// - le constructeur Voiture(string toto) puis
// - le constructeur public Voiture(string c, string m)



            
_________________________________________________________________________ Class Générique______________________________________________________________________

// Permet de construire un objet générique en fonction de la caractéristique de T.
// Les méthodes et les classes génériques combinent la réutilisabilité, la cohérence des types et l’efficacité, ce que ne peuvent pas faire leurs équivalents non génériques.

//pile.cs
public class Pile<T>
    {
        private int nbMax;
        private int index;
        public int NbMax { get => nbMax; set => nbMax = value; }
        public T[] tab;

        public Pile(int nombre)
        {
            NbMax = nombre;
            tab = new T[NbMax];
            index = 0;
        }
        public void Empiler(T element)
        {
            if(index < NbMax)
            {
                tab[index] = element;
                index++;
            }
            else
            {
                Console.WriteLine("Pile pleine");
            }
        } 
        public void Depiler()
        {
            if(index-1 >= 0)
            {
                tab[index - 1] = default(T);
                index--;
            }
        }
    }

//Programme.cs
Pile<string> pile = new Pile<string>(10);
            pile.Empiler("test");
            pile.Empiler("coucou");
            pile.Empiler("tata");
            pile.Depiler();

------------------------------------------------------------------- 2 - Héritage ---------------------------------------------------------------------- 

// Creer un objet à partir d'un moule parent. Un objet "fils" est créer à partir d'un objet père, on dit alors que l’objet fils hérite de l’objet père
// On dit également que l’objet fils est une spécialisation de l’objet père ou qu’il dérive de l’objet père.
// Un objet ne peut pas hériter de plusieurs objet, l'héritage multiple est dont interdit en C#, on utilise donc l'héritage en cascade
// ex : A <---hérite---- B <-----hérite------ C <-------hérite-------- D
// D hérite donc de A, B et C

// Il existe 3 niveau d'accessibilité : 
// - public : accessible a tous le monde
// - protected : accessible à l'intérieur de la classe et à ses héritiers
// - private : accessible seulement à l'intérieur de la classe
public class Voiture {}
protected class Moto {}
private class Velo {}

// abstract permet d'utiliser une classe de manière de référence mais ne peut être utiliser pour creer un objet 
// Il est donc utiliser pour creer des enfants utilisant des caractéristiques commune
public abstract class Avion {}

// sealed permet de vérrouiller la classe et permet d'interdire le création de class enfant à partir de celle-ci (interdit l'héritage)
public sealed class Helicoptere {}

// La classe fils qui hérite de la classe père héritera de son type, de ses attributs, de ses propriètés, de ses méthodes mais pas de ses constructeurs.
Avion a1 = new Avion();
Velo v1 = new Velo("VTT", 2);




------------------------------------------------------------------- 3 - Polymorphisme ---------------------------------------------------------------------- .

_____________________________________________________________________Ad hoc ou paramétré ___________________________________________________________________
// Polymorphisme "ad hoc" ou polymorphisme "paramétré" est le fait de pouvoir utiliser une même méthode ou toute action utilisant des paramètres différents
// C'est la capacité pour un objet de faire un même action avec différetns types d'intervenants.
// Par exemple, notre objet voiture peut rouler sur la route, rouler sur l’autoroute, rouler sur la terre si elle est équipée de pneus adéquats, rouler au fond de l’eau si elle est amphibie, etc …

public class VoitureVolante
	{
		// La methode Avancer permet de définir dans cet exemple la façon dont la voiture avance, dans les airs, sur terre, etc
		public void Avancer("air")
		{

		}
		//La méthode Avancer permet de définir ici de combien de km la voiture avance
		public void Avancer(50)
		{
			
		}
	}

// La méthode Avancer est donc différente car elle utilise deux paramètres différents
 
_______________________________________________________________________Héritage_____________________________________________________________________________
// Le polymorphisme par héritage est le fait de s'approprié une méthode ou toute action par héritage et de se l'approprié en fonciton de ses caractéristiques personnelles
// Par exemple :Tous ces mammifères sont capables de se déplacer, mais chacun va le faire d’une manière différente. 
// Ceci est donc possible grâce à la substitution qui permet de redéfinir un comportement hérité.
// Ainsi, chaque fils sera libre de réécrire son propre comportement, si celui de son père ne lui convient pas.

//Défini la class Personne
public  class Personne
    {
        protected string nom;
        private string prenom;

        public Personne()
        {
        }

        public Personne(string n, string p)
        {
            Nom = n;
            Prenom = p;
        }

        public virtual void Afficher()
        {
            Console.WriteLine(Nom + " " + Prenom);
        }

        public virtual void AfficherAvecNew()
        {
            Console.WriteLine("Avec new : " + Nom + " " + Prenom);
        }
    }

// Défini la class Etudiant héritier de la classe Personne
 public sealed class Etudiant : Personne
    {
        private string level;
        public Etudiant()
        {
        }

        // Le constructeur Etudiant hérite du constructeur Personne gràce à base(n, p)
        // Lors de la construction d'un Etudiant, il va passer par la constructeur de Personne pour prendre le Nom et Prenom
        // Puis passera par le constructeur de l'etudiant pour prendr le Level
        public Etudiant(string n, string p, string l) : base(n,p)
        {
            Level = l;
        }

        // La méthode hérite de la méthode Afficher de Personne et ajoute une fonctionnalité en plus
        // C'est le polymorphisme par héritage
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Level : " + Level);    
        }

        // Dans cet exemple override et new sont identiques
        // new permet d'utiliser seulement les méthodes du parents (à confirmer..)
        public new void AfficherAvecNew()
        {
            base.AfficherAvecNew();
            Console.WriteLine("Avec new Level : " + Level);
        }

        // Cette méthode est propre à la classe Etudiant et n'existe pas dans la classe Personne
        public void specialEtudiant()
        {
        }
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------- Interfaces ----------------------------------------------------------------------------------------------

// L'interface permet de creer un "cahier des charges" que les classes doivent respecter
// Liste les méthodes indispensables 
// À noter que les interfaces ne fournissent qu’un contrat, elles ne fournissent pas d’implémentation c'est-à-dire pas de code C#. 
// On peut implementer plusieurs interface à une classe
// Orthographe conventionnel : INomDeLinterface

//IVolant.cs
public interface IVolant
    {
        string Nom { get; set; }
        void Voler();
    }

// Implémenter une interface à une classe
public class Avion : IVolant 
{
	private string nom;

        public string Nom { get => nom; set => nom = value; }

        public void Voler()
        {
            Console.WriteLine("Oiseau qui vole");
        }
}

public class Avion : IVolant
    {
        private string nom;

        public string Nom { get => nom; set => nom = value; }

        public void Voler()
        {
            Console.WriteLine("Avion qui vole");
        }
    }

// On peut mettre au sein d'une liste toutes les classes ayant la même interface
List<IVolant> lVolants = new List<IVolant>();
            IVolant o1 = new Oiseau();
            IVolant a1 = new Avion();
            lVolants.Add(o1);
            lVolants.Add(a1);
            
            foreach(IVolant v in lVolants)
            {
                Console.WriteLine(v.GetType());
                v.Voler();
            }