using System;
using System.Collections.Generic;
using System.Text;

namespace Heap
{
    public class Node
    {
        private int distance;
        public int Distance { get => distance; set => distance = value; }
        public Node(int distance)
        {
            Distance = distance;
        }

        public override string ToString()
        {
            return this.Distance + "";
        }
    }
}
