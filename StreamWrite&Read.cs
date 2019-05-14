// StreamWrite permet d'écrire/de transformer des données choisies en un fichier de type choisi(txt, Json, doc, etc..)
// StreamRead permet de lire des fichiers (txt, Json, doc, etc)

// Pour utiliser ces fonctions, il faut importer la méthode "using System.IO"

---------------- StreamWrite ------------
// Il faut en premier lieu, instancier la classe StreamWrite

StreamWriter writer = new StreamWriter(@"C:\Users\Administrateur\Desktop\fichier.doc");
// @ pour eviter d'echapper le back-slash
// "C:\Users\Administrateur\Desktop\fichier.doc" => chemin de sauvegarde du fichier
writer.WriteLine(text);
// text peut être une variable contenant du texte, ou un chaine de caractére, une liste, une classe, etc
writer.Close();
// Fini la class StreamWrite

-- Tester si un fichier existe : --
if (File.Exists(@"C:\Users\Administrateur\Desktop\fichier.doc"))

---------------- StreamRead -------------
// Il faut en premier lieu, instancier la classe StreamRead

StreamReader reader = new StreamReader(@"C:\Users\Administrateur\Desktop\fichier.doc");
string contenu = reader.ReadToEnd();
// Met le contenu du fichier dans la variable contenu
Console.WriteLine(contenu);
// Affiche le contenu


// Pour pouvoir sauvegarder une classe et pouvoir la réutiliser, il faut la sauvgarder dans un fichier Json
// Pour cela, il faut importer l'extension Newtonsoft.Json
// => Click droit sur le dossier (dans l'explorateur de solution)
// => Gerer les packages nugets pour la solution
// Parcourir et installer l'extension Newtonsoft.Json
Personne perso = new Personne() { Nom = n, Prenom = p };
StreamWriter writer = new StreamWriter("Perso.txt");
// Perso.txt sauvegarde le fichier dans le dossier du projet
string persoEnJson = JsonConvert.SerializeObject(perso);
// Sauvegarde la classe perso dans la variable en Json
writer.WriteLine(persoEnJson);
writer.Close();
// StreamRead
StreamReader reader = new StreamReader("Perso.txt");
string contenuFichier = reader.ReadToEnd();

Personne p2 = JsonConvert.DeserializeObject<Personne>(contenuFichier);
reader.Close();
// Remet le contenu de la variable qui est sous format Json en un objet de type Class
// p2 est maintenant utilisable comme une class
Console.WriteLine(p2.Nom + " " + p2.Prenom);