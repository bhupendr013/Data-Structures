using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface ISort
    {
        void Sort(int[] array);
    }

    public class BubbleSort : ISort
    {
        public void Sort(int[] arr)
        {
            // Bubble Sort logic
        }
    }

    public class QuickSort : ISort
    {
        public void Sort(int[] array)
        {
            // Quick Sort Logic
        }
    }

    public class InsertionSort : ISort
    {
        public void Sort(int[] array)
        {
            // Insertion sort logic
        }
    }

    public abstract class Sorter
    {
        private ISort strategy;

        public void SetSorter(ISort strategy)
        {
            this.strategy = strategy;
        }

        public ISort GetSorter()
        {
            return this.strategy;
        }

        public abstract void DoSort(int[] array);
    }

    public class MySorter : Sorter
    {
        public override void DoSort(int[] array)
        {
            GetSorter().Sort(array);
        }
    }
    class StrategyPattern
    {
        public void StrategyControl()
        {
            int[] list = { 23, 4, 7, 12, 45, 21, 9, 1 };
            MySorter ms = new MySorter();
            ms.SetSorter(new QuickSort());
            ms.DoSort(list);
            ms.SetSorter(new InsertionSort());
            ms.DoSort(list);
        }
    }
}
