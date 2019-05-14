// Un design pattern est une architecture ou une solution qui repond à des problématique liées aux design ou à l'intéraction des objets
// Les “design patterns” sont des solutions de design et d’implémentation de code informatique dans le but de le rendre propre, optimisé, robuste, maintenable et évolutif. 
// Ce qui permet ainsi de répondre à des problématiques récurrentes de développement, tout particulièrement en Programmation Orientée Objet (POO).
// Il existe 23 design pattern répartit en 3 catégories :

// 1 / Les Creational Patterns  :
// - Abstract Facotory : Creates an instance of several families of classes
// - Builder : 	Separates object construction from its representation
// - Factory Method : 	Creates an instance of several derived classes
// - Prototype : A fully initialized instance to be copied or cloned
// - Singleton : A class of which only a single instance can exist

// 2 / Les Structural Patterns
// - Adapter : Match interfaces of different classes
// - Bridge : Separates an object’s interface from its implementation
// - Composite : A tree structure of simple and composite objects
// - Decorator : Add responsibilities to objects dynamically
// - Facade : A single class that represents an entire subsystem
// - Flyweight : A fine-grained instance used for efficient sharing
// - Proxy : An object representing another object

// 3 / Behavioral Patterns
// - Chain of Resp. :	A way of passing a request between a chain of objects
// - Command :	Encapsulate a command request as an object
// - Interpreter :	A way to include language elements in a program
// - Iterator :	Sequentially access the elements of a collection
// - Mediator :	Defines simplified communication between classes
// - Memento :	Capture and restore an object's internal state
// - Observer :	A way of notifying change to a number of classes
// - State :	Alter an object's behavior when its state changes
// - Strategy :	Encapsulates an algorithm inside a class
// - Template Method :	Defer the exact steps of an algorithm to a subclass
// - Visitor :	Defines a new operation to a class without change

------------------------------------------------------------- Singleton ------------------------------------------------------
// Permet d'instancier une seule fois la classe dans tous le programme

// singleton de SQLConnection
public static SqlConnection Instance {
            get
            {
                lock(_lock)
                {
                    if (_instance == null)
                        _instance = new SqlConnection(@"Data Source=(localDb)\CoursAdoNet;Integrated Security=True");
                    return _instance;
                }
            }
}
// Le Lock permet de sécuriser la création de l'instance
// Si le token change dans lors du new SqlConnection, lorsqu'il va revenir, l'instance n'aura rien renvoyer, donc il va recréer une seconde instance
private Connection()
{

}
// Le constructeur ne doit prendre aucune paramétre et doit être en private, ceci empêche d'autres classes de l'instancier (ce qui serait une violation du pattern)

------------------------------------------------------------- Abstract Factory ------------------------------------------------------

// Factory : En développement orienté objet, une Factory (Fabrique) est un bout de code dédié qui a pour fonction de construire des objets : d’où son nom “Fabrique”.

// Abstract : l’abstraction en développement objet permet de regrouper des comportements communs à une famille d’objets. 
// Par exemple, un carré, un rectangle et un triangle vont hériter d’une classe “abstraite” “Forme Géométrique” qui contient un nombre de cotés, une superficie, etc.

// Le pattern abstract Factory permet de rassembler des méthodes communes à des familles d’objets différents dans une classe commune : 
// la fabrique abstraite, afin d’éviter au client d’appeler des méthodes différentes (concrètes) par famille d’objets.

------------------------------------------------------------- Injection de dépendance ------------------------------------------------------

// Evite la création d'objet à l'intérieur d'un objet
// Cela evite donc un couplage fort



































