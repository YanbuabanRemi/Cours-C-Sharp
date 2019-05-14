------------------------------------------- Multithreading ----------------------------------------------------------------------------

// Pour utiliser les threads, il faut ajouter l'espace nom "using System.Threading" 
// Une applicaiton demarre toujours sur le thread principal
// Un thread est un process, un canal ou un flux qui va permettre d'éffectué des taches
// Un thread ne peut être appelé qu'une seule fois
// Les données entre les thrds ne se synchronise pas

// Création de thread :
Thread t1 = new Thread(MethodeThread1);

static void MethodeThread1()
        {
           for(int i=1; i<100; i++)
               Console.WriteLine("Je suis la methode 1 executée dans un thread secondaire "+i);
        }

// Démarrer un thread :
t1.Start();

// Création d'un thread avec des paramètres :
// Le delegate du "new Thread" doit être un void qui n'accepte aucun paramètre.(Afficher)
Thread t1 = new Thread(afficher);

static void afficher()
{
	Console.WriteLine("hello");
}

Personne p1 = new Personne { Nom = "tata", Prenom = "toto" };
t1.Start(p1);
t2.Start(p1);

// L'OS permute le token entre les threads de manière aléatoire

// Si on veut passer des paramètres dans une méthode qui va passer dans un thread, ce paramètre doit être de type objet
Thread t1 = new Thread(Afficher);
Thread t2 = new Thread(Afficher);

// Si on veut bloquer l'accèe à un thread afin que le token "finisse" le travail avant de passer à un autre thread
// Il faut initialiser un lock, tant que celui ci n'a pas fini, le token ne peut pas partir du thread

static void Afficher(object c)
        {
           //utilisation du lock pour synchronisation d'acces au data
           lock(_lock)
           {
               Personne p = c as Personne;
               for (int i = 1; i < 100; i++)
               {
                   Console.WriteLine(p.Prenom + " " + p.Nom);
                   if (i == 20)
                   {
                       p.Nom = "Nom 20";
                   }
               }
           }    
        }

// Un mutex à le même rôle que le lock
// Il doit être creer, initier puis liberer
// Personne peut acceder aux données dans le mutex tant que celui ci n'a pas été libéré

private static Mutex m1 = new Mutex();
private static Mutex m2 = new Mutex();

static void init()
        {
           m1.WaitOne(); // le mutex est initié
           m2.WaitOne(); // le mutex est initié
           v1 = 10;
           m1.ReleaseMutex(); // le mutex est libéré
           v2 = 20;
           m2.ReleaseMutex(); // le mutex est libéré
        }

// Le ThreadPool permet de mettre plusieurs thread dans un pool et celui regroupe tous les threads qui l'on souhaite effectué
ThreadPool.QueueUserWorkItem(afficher, "Coucou");
ThreadPool.QueueUserWorkItem(afficher, "bonjour");
ThreadPool.QueueUserWorkItem(afficher, "10");     

// Un sémaphore permet de verrouiller l'ordi a un nombre de thread maximum en travail
// Comme un portier à l'entrer d'une boite de nuit qui laisse entrer seulement un nombre défini de personne
private static SemaphoreSlim s = new SemaphoreSlim(3);

static void Afficher(object c)
        {
           Console.WriteLine("Start Thread N° : "+c);
           s.Wait();
           Console.WriteLine("Thread En travail : "+c);
           Thread.Sleep(6000);
           Console.WriteLine("Fin du travail : " + c);
           s.Release();
        }

// Les exeptions géré par un thread se gère à l'intérieur du thread lui même

-------------------------------------------------------------- Task -----------------------------------------------------------------

// Une task permet de gerer 3 problèmes:
// - l'impossibilité de remonter les exeptions
// - l'impossibilité d'agir sur l'état d'un thread
// - l'impossibilité de renvoyer un résultat