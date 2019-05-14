------------------------------------------- Les delegates ----------------------------------------------------------------------------

// Ils permettent de créer des variables spéciales. Ce sont des variables qui "pointent" vers une méthode.
// Cela enregistre une méthode dans une variable
// Le délégué va nous permettre de définir une signature de méthode et avec lui, nous pourrons pointer vers n’importe quelle méthode qui respecte cette signature.
// En général, on utilise un délégué quand on veut passer une méthode en paramètres d’une autre méthode.
// Ils sont la base des évenements

public class TrieurDeTableau
{
	// Le delegate doit prendre le même type de paramêtre que les méthodes associés
	// Si le paramêtre de la méthode est un table, le paramètre du delegate doit être un tableau
    private delegate void DelegateTri(int[] tableau);

    private void TriAscendant(int[] tableau)
    {
        Array.Sort(tableau);
    }

    private void TriDescendant(int[] tableau)
    {
        Array.Sort(tableau);
        Array.Reverse(tableau);
    }

    //Puis on utlilise les méthodes TriAscendant et TriDescendant au sein de la méthode DemoTri grâce au delegate
    public void DemoTri(int[] tableau)
    {
        DelegateTri tri = TriAscendant;
        tri(tableau);
        foreach (int i in tableau)
        {
            Console.WriteLine(i);
        }

        tri = TriDescendant;
        tri(tableau);
        foreach (int i in tableau)
        {
            Console.WriteLine(i);
        }
    }
}

// On peut encore factoriser le code en rajoutant la méthode suivante
public class TrieurDeTableau
{
    private delegate void DelegateTri(int[] tableau);

    private void TriAscendant(int[] tableau)
    {
        Array.Sort(tableau);
    }

    private void TriDescendant(int[] tableau)
    {
        Array.Sort(tableau);
        Array.Reverse(tableau);
    }

    private void TrierEtAfficher(int[] tableau, DelegateTri methodeDeTri)
	{
    	methodeDeTri(tableau);
    	foreach (int i in tableau)
    	{
    	    Console.WriteLine(i);
    	}
	}

    public void DemoTri(int[] tableau)
    {
		TrierEtAfficher(tableau, delegate(int[] leTableau)
        {
            Array.Sort(leTableau);
        });

        Console.WriteLine();

        TrierEtAfficher(tableau, delegate(int[] leTableau)
        {
            Array.Sort(leTableau);
            Array.Reverse(leTableau);
        });
    }
}

---------------------------------------- Func / Action --------------------------------------------------

// Les délégués Aciton et Func osnt des délégués générique

// Action est un délégué qui permet de pointer vers une méthode qui ne renvoie rien et qui peut accepter jusqu’à 16 types différents.
private delegate void DelegateTri(int[] tableau);
private void TrierEtAfficher(int[] tableau, DelegateTri methodeDeTri)
	{
    	methodeDeTri(tableau);
    	foreach (int i in tableau)
    	{
    	    Console.WriteLine(i);
    	}
	}

// Peut etre remplacer par :

private void TrierEtAfficher(int[] tableau, Action<int[]> methodeDeTri)
    {
        methodeDeTri(tableau);
        foreach (int i in tableau)
        {
            Console.WriteLine(i);
        }
    }

// La différence se situe au niveau du paramètre de la méthode TrierEtAfficher qui prend un Action<int[]>. 
// En fait, cela est équivalent à créer un délégué qui ne renvoie rien et qui prend un tableau d’entier en paramètre.
// Si notre méthode avait deux paramètres, il aurait suffi d’utiliser la forme de Action avec plusieurs paramètres génériques, 
// par exemple Action<int[], string> pour avoir une méthode qui ne renvoie rien et qui prend un tableau d’entier et une chaine de caractères en paramètres.

// Lorsque la méthode renvoie quelque chose, on peut utiliser le délégué Func<T>, sachant qu’ici, c’est le dernier paramètre générique qui sera du type de retour du délégué.

public class Operations
{
    public void DemoOperations()
    {
        double division = Calcul(delegate(int a, int b)
        {
            return (double)a / (double)b;
        }, 4, 5);

        double puissance = Calcul(delegate(int a, int b)
        {
            return Math.Pow((double)a, (double)b);
        }, 4, 5);

        Console.WriteLine("Division : " + division);
        Console.WriteLine("Puissance : " + puissance);
    }

    private double Calcul(Func<int, int, double> methodeDeCalcul, int a, int b)
    {
        return methodeDeCalcul(a, b);
    }
}

// Ici, dans la méthode Calcul, on utilise le délégué Func pour indiquer que la méthode prend deux entiers en paramètres et renvoie un double.

----------------------------------------------- Les expressions lambdas ------------------------------------------------------

// Les expressions lambda permet d'écrire les délégués de façon plus simplifier

private delegate void DelegateTri(int[] tableau);

DelegateTri tri = delegate(int[] leTableau)
{
    Array.Sort(leTableau);
};
// S'ecrit maintenant :
DelegateTri tri = (leTableau) => 
{
    Array.Sort(leTableau);
};

// L’expression lambda « (leTableau) => » se lit : « leTableau conduit à ».
// La variable leTableau permet de spécifier le paramètre d’entrée de l’expression lambda. 
// Ce paramètre est écrit entre parenthèses. Ici, pas besoin d’indiquer son type vu qu’il est connu par la signature associée au délégué.
// On utilise ensuite la flèche « => » pour définir l’expression lambda qui sera utilisée. Elle s’écrit de la même façon qu’une méthode, dans un bloc de code.

double division = Calcul(delegate(int a, int b)
        {
            return (double)a / (double)b;
        }, 4, 5);
// Peut s'ecrire :
double division = Calcul((a, b) => (double)a / (double)b, 4, 5);