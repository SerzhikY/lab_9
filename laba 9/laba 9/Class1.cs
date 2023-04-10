using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_9
{
    public class Bike
    {
        private readonly List<IBikeComponent> _components = new List<IBikeComponent>();

        public void AddComponent(IBikeComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IBikeComponent component)
        {
            _components.Remove(component);
        }

        public void Operate()
        {
            MessageBox.Show("The Bike is operating...");

            foreach (var component in _components)
            {
                component.Operate();
            }
        }
        public IEnumerable<IBikeComponent> GetComponents()
        {
            return _components.SelectMany(c => c.GetComponents()).Concat(_components);
        }
    }
    public interface IBikeComponent
    {
        void AddComponent(IBikeComponent component);
        
        void Operate();
        IEnumerable<IBikeComponent> GetComponents();
    }

    
    public class Wheels : IBikeComponent
    {
        public void AddComponent(IBikeComponent component)
        {
            
        }

        public void Operate()
        {
            Console.WriteLine("Wheel is spinning...");
        }

        public IEnumerable<IBikeComponent> GetComponents()
        {
            return Enumerable.Empty<IBikeComponent>();
        }
    }

    public class Pedals : IBikeComponent
    {
        private readonly List<IBikeComponent> _components = new List<IBikeComponent>();

        public void AddComponent(IBikeComponent component)
        {
            _components.Add(component);
        }

        public void Operate()
        {
            Console.WriteLine("bicycle pedals is running...");

            foreach (var component in _components)
            {
                component.Operate();
            }
        }

        public IEnumerable<IBikeComponent> GetComponents()
        {
            return _components.SelectMany(c => c.GetComponents()).Concat(_components);
        }
    }

 
    public class BikeBuilder
    {
        public static Bike Build()
        {
            var Bike = new Bike();
            var wheel = new Wheels();
            var pedals = new Pedals();
            


            pedals.AddComponent(wheel);
            Bike.AddComponent(pedals);
            Bike.AddComponent(pedals);


            MessageBox.Show("Wheel, Pedals added to the Bike.");

            return Bike;
        }
    }

}
