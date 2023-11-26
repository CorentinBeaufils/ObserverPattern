using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IAtomObserver
    {
        void Update(AtomObservable atomObservable);
    }

    public interface IAtomObservable
    {
        void Attach(IAtomObserver observer);
        void Detach(IAtomObserver observer);
        void Notify();
    }

    public class AtomObserver : IAtomObserver
    {
        private string _ObserveNname;

        public AtomObserver(string nname)
        {
            _ObserveNname = nname;
            Console.WriteLine($"Création de l'observer {_ObserveNname}");
        }

        public void Update(AtomObservable atom)
        {
            Console.WriteLine($"{_ObserveNname} a été notifié du changement de l'atome {atom.Name}.");
        }
    }

    public class AtomObservable : IAtomObservable
    {
        private List<IAtomObserver> observers = new List<IAtomObserver>();
        private string name;
        private string symbol;
        private double mass;

        public AtomObservable(string name, string symbol, double mass)
        {
            this.name = name;
            this.symbol = symbol;
            this.mass = mass;
            Console.WriteLine($"Création de l'atom {name}, de symbole {symbol}, et de mass : {mass}");
        }
        public string Name => name;
        public string Symbol => symbol;
        public double Mass => mass;


        public void Attach(IAtomObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IAtomObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }
        public void ChangeState(string newName, string newSymbol, double newMass)
        {
            Console.WriteLine($"Update des Valeurs : \nname : {name} => {newName}, Symbole : {symbol}" +
                $" => {newSymbol}, Mass : {mass} => {newMass}");
            name = newName;
            symbol = newSymbol;
            mass = newMass;
            
            Notify();
        }
    }
}

