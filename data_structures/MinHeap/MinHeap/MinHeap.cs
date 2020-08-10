using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Heap
{
    /* 
     * node at index k:
     * Left child is at index 2k + 1
     * Right child is at index 2k + 2
     * Its parent is at index (k-1)/2 
     */
    public class MinHeap
    {
        private Dictionary<Node, int> map;
        private List<Node> nodes;
        private int cap, size = 0;

        public MinHeap(int cap)
        {
            this.nodes = new List<Node>(cap);
            this.map = new Dictionary<Node, int>();
            this.cap = cap;
        }

        public bool Add(Node node)
        {
            if (this.size >= this.cap)
            {
                Console.WriteLine("Error: attempted to add to full heap.");
                return false;
            }

            this.map.Add(node, this.size); // track new node in our map
            this.nodes.Add(node);
            this.PercolateUp(this.size);
            this.size++;

            return true;
        }

        public Node Poll()
        {
            if (this.size == 0)
            {
                Console.WriteLine("Error: attempted to remove from empty heap");
                return null;
            }

            Node output = this.nodes[0];
            this.nodes[0] = this.nodes[this.size - 1];
            this.nodes.RemoveAt(this.size-1);
            this.size--;
            this.PercolateDown(0);
            this.map.Remove(output); // no longer needed our map
            return output;
        }

        public void UpdateKey(Node node, int newDistance)
        {
            if (node == null) return;

            bool found = this.map.TryGetValue(node, out int idx);
            if (found)
            {
                int currentDistance = this.nodes[idx].Distance;
                this.nodes[idx].Distance = newDistance;
                if (currentDistance > newDistance)
                {
                    this.PercolateUp(idx);
                }
                else
                {
                    this.PercolateDown(idx);
                }
            }
        }

        public Node Min()
        {
            return nodes[0] ?? null;
        }

        private void PercolateUp(int k)
        {
            if (k > this.size || k == 0) return;
            int parentIdx = (k-1) / 2;
            Node parent = this.nodes[parentIdx];
            Node current = this.nodes[k];
            if (current.Distance < parent.Distance)
            {
                this.Swap(k, parentIdx);
                this.PercolateUp(parentIdx);
            }
        }

        private void PercolateDown(int k)
        {
            int lesserChildIndex;
            int leftIndex = 2 * k + 1;
            int rightIndex = 2 * k + 2;

            int leftDistance = leftIndex < this.size ? this.nodes[leftIndex].Distance : 0;
            int rightDistance = rightIndex < this.size ? this.nodes[rightIndex].Distance : 0;

            // figure out child with smaller distance. Exit if reached null nodes
            if (rightIndex < this.size && rightDistance< leftDistance)
            {
                lesserChildIndex = rightIndex;
            }
            else if (leftIndex < this.size)
            {
                lesserChildIndex = leftIndex;
            }
            else
            {
                return;
            }

            // recurse if min heap structure is not satisfied.
            if (this.nodes[k].Distance > this.nodes[lesserChildIndex].Distance)
            {
                this.Swap(k, lesserChildIndex);
                this.PercolateDown(lesserChildIndex);
            }
        }

        private void Swap(int x, int y)
        {
            if (x > this.size || y > this.size) return;
            // reflect changes on map 
            this.map[this.nodes[x]] = y;
            this.map[this.nodes[y]] = x;

            // swap
            Node temp = this.nodes[x];
            this.nodes[x] = this.nodes[y];
            this.nodes[y] = temp;
        }

        public override string ToString()
        {
            string output = "";
            foreach (Node node in nodes)
            {
                output += node + " ";
            }

            return output;
        }
    }
}
