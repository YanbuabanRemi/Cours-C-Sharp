___________________________________________________________________Tableau_______________________________________________________________

//Un tableau doit toujours être defini en fonction de sa taille, la taille du tableau est donc prédéfini des le depart
// Declare a single-dimensional array 
int[] array1 = new int[5];

// Declare and set array element values
int[] array2 = new int[] { 1, 3, 5, 7, 9 };

// Alternative syntax
int[] array3 = { 1, 2, 3, 4, 5, 6 };

// Declare a two dimensional array
int[,] multiDimensionalArray1 = new int[2, 3];

// Declare and set array element values
int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

// Declare a jagged array
int[][] jaggedArray = new int[6][];

// Set the values of the first array in the jagged array structure
jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

// Les valeurs par défaut des éléments de tableau numériques sont définies sur zéro et les éléments de référence sont définis sur Null.
// Les tableaux sont indexés sur zéro : un tableau avec n éléments est indexée de 0 à n-1.
// Les éléments de tableau peuvent être de n’importe quel type, y compris un type tableau.

____________________________________________________________________________Liste__________________________________________________________________

List<int> maListe = new List<int>();
// Le type de la liste est prédéfini dès le départ et ne peut être modifié

pour ajouter un element dans la liste
            maListe.Add(15);
            maListe.Add(20);

modifier un element
            maListe[0] = 10;

taille de la liste
            Console.WriteLine(maListe.Count);

supprimer un element
            maListe.Remove(15);

supprimer à un index
            maListe.RemoveAt(0);

Rechercher un éléments et renvoyer son index
			maListe.IndexOf("10");

Afficher la liste
            foreach(int a in maListe)
            {
                Console.WriteLine(a);
            }

Trie les éléments de la liste            
            maListe.Sort();
