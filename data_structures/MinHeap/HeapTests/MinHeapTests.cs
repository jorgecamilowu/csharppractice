using System;
using Xunit;
using Heap;
using System.Runtime;

namespace HeapTests
{
    public class MinHeapTests
    {
        [Fact]
        public void AddFailsWhenReachedCapacity()
        {
            MinHeap heap = new MinHeap(2);
            heap.Add(new Node(5));
            heap.Add(new Node(3));
            Assert.False(heap.Add(new Node(2)));
        }

        [Fact]
        public void RemoveEmptyHeapReturnsNull()
        {
            MinHeap heap = new MinHeap(2);
            Assert.Null(heap.Poll());
        }

        [Fact]
        public void MinReturnsHeapRoot()
        {
            MinHeap heap = new MinHeap(4);
            heap.Add(new Node(5));
            heap.Add(new Node(3));
            heap.Add(new Node(2));
            heap.Add(new Node(7));

            Assert.Equal(2, heap.Min().Distance);
        }

        [Fact]
        public void MaintainsStructureAfterPoll()
        {
            MinHeap heap = new MinHeap(4);
            heap.Add(new Node(5));
            heap.Add(new Node(3));
            heap.Add(new Node(2));
            heap.Add(new Node(7));

            Assert.Equal(2, heap.Poll().Distance);
            Assert.Equal(3, heap.Min().Distance);

            Assert.Equal(3, heap.Poll().Distance);
            Assert.Equal(5, heap.Min().Distance);

            Assert.Equal(5, heap.Poll().Distance);
            Assert.Equal(7, heap.Min().Distance);
        }

        [Fact]
        public void UpdateKeyMaintainsStructure()
        {
            MinHeap heap = new MinHeap(4);
            Node a = new Node(1);
            Node b = new Node(2);
            Node c = new Node(3);
            Node d = new Node(4);
            heap.Add(a);
            heap.Add(b);
            heap.Add(c);
            heap.Add(d);

            heap.UpdateKey(a, 5);
            Assert.Equal(2, heap.Min().Distance);

            heap.UpdateKey(b, 11);
            Assert.Equal(3, heap.Min().Distance);

            heap.UpdateKey(d, 1);
            Assert.Equal(1, heap.Min().Distance);
        }
    }
}
