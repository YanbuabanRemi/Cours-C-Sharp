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

private static Mutex m1 = new Mutex();

public void Add()
        {
            Task.Run(() =>
            {
                m1.WaitOne();
                ...
                m1.ReleaseMutex();
            });          
        }
// Le Mutex permet que la methode finisse avant que le token ne soit distribuer a un autre thread
private object _lock = new object();
public void Add()
        {
            Task t = Task.Run(() =>
            {
                lock (_lock)
                {
                    ...
                }
            });
            t.Wait();
        }
// Le Lock a la même rôle que le mutex
// t.wait permet d'attendre que la méthode a l'intérieur de la Task finisse avant de passer à la suivante
// A chaque fois que la fonction Add sera lancée, elle sera lancé dans un nouveau thread

Client c = new Client(nom, prenom, tel);
Task t = Task.Run(()=>  c.Add());
t.Wait();

// Une Task peut renvoyer une valeur
public static List<Operation> GetOperations(int compte)
        {
            
            Task<List<Operation>> t = Task.Run(new Func<List<Operation>>(() =>
            {
                List<Operation> liste = new List<Operation>();
                SqlCommand command = new SqlCommand("SELECT * FROM Operation  WHERE CompteId = @n", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@n", compte));
                lock(new object())
                {
                    Connection.Instance.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Operation o = new Operation()
                        {
                            Id = reader.GetInt32(0),
                            CompteId = reader.GetInt32(1),
                            Montant = reader.GetDecimal(2),
                            DateOperation = reader.GetDateTime(3)
                        };
                        liste.Add(o);
                    }
                    reader.Close();
                    command.Dispose();
                    Connection.Instance.Close();
                    return liste;
                }
                
            }));
            
            return t.Result;
        }

// La Task renverra donc une liste d'operation

// On peut affecter plusieurs méthode dans une Task.Factory
Baignoire b = new Baignoire();
Robinet r = new Robinet();
Task.Factory.StartNew(() => r.debite(50, b));
Task.Factory.StartNew(() => b.Fuite(10));
