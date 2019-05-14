------------------------------------------------------------------- 1 - Variables ----------------------------------------------------------------------
Declaration des variable 
        Variable de type valeur
            short, int, long => Entier
            int a = 10;
            int b = a + 5;
            Float, double, decimal
            float f = 20.4F;
            decimal d = 20.4M;
        bool
            bool test = false;
        char
            char c = 'A';
        string 
            string nom = "Abadi";

        Operation 
            Addition +
            string prenom = "Ihab";
            string nomComplet = nom + prenom;
        Opérateur logique
            ET => &&
            OU => ||
            Négation => !
            bool test2 = true;
        Opérateur de comparaison
            Egalité ==
            superieur ou égal >=
            Inferieur ou égél <=

------------------------------------------------------------------- 2 - Struture conditionnelle ----------------------------------------------------------------------


        If & else
            int a = 10;
            if(a >= 20)
            {
               Console.WriteLine("a est superieur à 20");
            }
            else if( a > 10 && a < 20)
            {
               Console.WriteLine("a est inferieur à 20 et supérieur à 10");
            }
            else
            {
               Console.WriteLine("a est inferieur ou égale à 10");
            }
            
            if (a >= 20)
               Console.WriteLine("a est superieur à 20");
            else if (a > 10 && a < 20)
               Console.WriteLine("a est inferieur à 20 et supérieur à 10");
            else
               Console.WriteLine("a est inferieur ou égale à 10");

            bool result;
            if(a > 10)
            {
               result = true;
            }
            else
            {
               result = false;
            }
            bool result = (a > 10) ? true : false;

        Switch
            int mois = 1;
            switch(mois)
            {
               case 1:
                   Console.WriteLine("Janvier");
                   break;
               case 2:
                   Console.WriteLine("Février");
                   break;
               case 3:
                   Console.WriteLine("Mars");
                   break;
               default:
                   Console.WriteLine("ce n'est pas un mois");
                   break;
            }

            switch(mois)
            {
               case int n  when (n >= 1 && n <= 3):
                   Console.WriteLine("Hiver");
                   break;
               case int n when (n >= 4 && n <= 6):
                   break;
            }

------------------------------------------------------------------- 3 - Boucle ----------------------------------------------------------------------

        for
            for(int i= 1; i<= 10; i++)
            {
               Console.WriteLine(i);
            }
            for (int i = 49; i >= 0; i=i-3)
            {
               Console.WriteLine(i);
            }
            for(char c='A'; c <= 'z'; c++)
            {
               Console.WriteLine(c);
            }

        while
            int i = 10;
            while( i >0)
            {
               Console.WriteLine(i);
               i--;
            }

        do while
            do
            {
               Console.WriteLine(i);
               i++;
            } while (i < 10);

        tableau c#
            int[] tab = new int[10];
            tab[3] = 100;
            tab[5] = 200;
            int[] tab = new int[] { 1, 3, 5 };
            for(int i = 0; i < tab.Length; i++)
            {
               Console.WriteLine(tab[i]);
            }
            foreach(int i in tab)
            {
               Console.WriteLine(i);
            }

------------------------------------------------------------------- 4 - Console ----------------------------------------------------------------------

Console.Write() = Ecrit à la suite
Console.WriteLine() = Ecrit et revient à la ligne
Console.ReadLine() = Lit la ligne 

// Affecte a la variable nom ce qu'on va entrer dans la console
Console.Write("Merci de saisir votre nom : ");
string nom = Console.ReadLine();