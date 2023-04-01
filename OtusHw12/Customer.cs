using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHw12
{
    public class Customer
    {
        public void OnItemChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Item item in e.NewItems)
                {
                    Console.WriteLine($"Добавлен новый товар в магазин: {item.Name} (id={item.Id})");
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Item item in e.OldItems)
                {
                    Console.WriteLine($"Удален товар из магазина: {item.Name} (id={item.Id})");
                }
            }
        }
    }
}
