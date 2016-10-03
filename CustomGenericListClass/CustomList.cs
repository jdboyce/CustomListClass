using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;


namespace CustomGenericListClass
{
    public class CustomList<T> : IEnumerable
    {

        public T[] items;

        private int _count;

        public int count
                {
                    get
                    {
                        return _count;
                    }
                    set
                    {
                        _count = value;
                    }
                }

        public CustomList()
        {
            items = new T[0];
            count = 0;
        }

        public void Add(T passedItem)
        {
            T[] newArray = new T[count + 1];

            newArray[count] = passedItem;

            for (int i = 0; i < count; i++)
            {
                newArray[i] = items[i];
            }
            count += 1;
            items = newArray;
        }

        public void Remove(T passedItem)
        {
            if (CheckMatch(passedItem) > 0)
            {
                DiscardMatches(passedItem, CheckMatch(passedItem));
            }
        }

        private int CheckMatch(T passedItem)
        {
            int matchesFound = 0;
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(passedItem))
                {
                    matchesFound += 1;
                }
            }
            return matchesFound;
        }

        private void DiscardMatches(T passedItem, int matchesFound)
        {
            T[] newArray = new T[count - matchesFound];
            int discardedItems = 0;
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(passedItem))
                {
                    discardedItems += 1;
                    
                }
                else
                {
                    newArray[i - discardedItems] = items[i];
                }
            }
            count -= matchesFound;
            items = newArray;
        }

        public static CustomList<T> operator +(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> combinedList = new CustomList<T>();
            int combinedListLength = firstList.count + secondList.count;
            combinedList.items = new T[combinedListLength];

            for (int i = 0; i < firstList.count; i++)
            {
                combinedList.items[i] = firstList.items[i];
            }

            for (int i = 0; i < secondList.count; i++)
            {
                combinedList.items[firstList.count + i] = secondList.items[i];
            }

            return combinedList;
        }

        public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> subtractedList = new CustomList<T>();
            subtractedList.items = new T[firstList.count];
            T[] emptyArray = new T[0];

            if (firstList.Equals(secondList))
            {
                subtractedList.items = emptyArray;
            }

            else
            {
                for (int i = 0; i < secondList.count; i++)
                {
                    firstList.Remove(secondList.items[i]);
                }
                subtractedList = firstList;
            }
            return subtractedList;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        public override string ToString()
        {
            string toString = null;
            for (int i = 0; i < count; i++)
            {
                if (i == count -1)
                {
                    toString += items[i];
                }
                else
                {
                    toString += items[i] + ", ";
                }  
            }
            return toString;
        }

        public void ZipWith(CustomList<T> passedList)
        {
            int zipListLength;
            if (count <= passedList.count)
            {
                zipListLength = count * 2;
            }
            else
            {
                zipListLength = passedList.count * 2;
            }
            T[] newArray = new T[zipListLength];
            int copyAt = 0;
            for (int i = 0; i < zipListLength/2; i++)
            {
                newArray[copyAt] = items[i];
                copyAt++;
                newArray[copyAt] = passedList.items[i];
                copyAt++;
            }
            items = newArray;
            count = zipListLength;
        }

    }
}
