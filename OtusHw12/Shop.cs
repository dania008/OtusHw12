using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHw12
{
    public class Shop
    {
        public ObservableCollection<Item> Items { get; set; }

        public Shop()
        {
            Items = new ObservableCollection<Item>();
            Items.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Item item in e.NewItems)
                {
                    Console.WriteLine($"Добавлен товар: {item.Name} (id={item.Id})");
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Item item in e.OldItems)
                {
                    Console.WriteLine($"Удален товар: {item.Name} (id={item.Id})");
                }
            }
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(int id)
        {
            var item = Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }
}
