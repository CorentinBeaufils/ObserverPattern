// See https://aka.ms/new-console-template for more information
using ObserverPattern;

Console.WriteLine("Declaration des Objets : \n\n");
AtomObservable atom = new AtomObservable("Carbon", "C", 12.001074);
AtomObserver Obs1 = new AtomObserver("Observer1");
AtomObserver Obs2 = new AtomObserver("Oberver2");

Console.WriteLine("\n ------------------------------------ \n");

atom.Attach(Obs1);
atom.Attach(Obs2);

Console.WriteLine("\nUpdate \n\n");
atom.ChangeState("Hydrogen", "H", 1.00794);

