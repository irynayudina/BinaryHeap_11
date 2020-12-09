using System;

namespace BinaryHeap_11
{
    class BinaryHeapMax
    {
        private int[] arrayOfelementsHEAP = new int[1];
        private int heapsize = 0;
        public int[] arraySorted = new int[1];
        //BinaryTree tree = new BinaryTree();



        public void PrintHeap()
        {
            Console.WriteLine("Array:");
            foreach (int i in arrayOfelementsHEAP)
            {
                Console.Write(i + "   ");
            }
            Console.WriteLine();
            //Console.WriteLine("Heap:");
            //for(int i =0; i <=heapsize; i++)
            //{
            //    int line = 0;
            //    line += Convert.ToInt32(Math.Pow(2, i));
            //    if(i == line)
            //    {

            //    }
            //}
        }



        public void insert(int e)
        {
            insert_arr(e);
        }
        private void insert_arr(int elem)
        {
            if ((arrayOfelementsHEAP.Length - heapsize) < 2)
            {
                Array.Resize(ref arrayOfelementsHEAP, arrayOfelementsHEAP.Length + 1);
            }
            heapsize++;
            arrayOfelementsHEAP[heapsize] = elem;
            HeapifyBottomToTop(heapsize);
        }




        public int maximum()
        {
            if (heapsize == 0)
            {
                Console.WriteLine("Heap is empty");
                return 0;
            }
            Console.WriteLine("Head of the Heap is: " + arrayOfelementsHEAP[1]);
            return arrayOfelementsHEAP[1];
        }




        public int extractMax()
        {
            if (heapsize == 0)
            {
                Console.WriteLine("Heap is empty");
                return -1;
            }
            else
            {
                Console.WriteLine("Head of the Heap is: " + arrayOfelementsHEAP[1]);
                Console.WriteLine("Extracting it now...");
                int extractedValue = arrayOfelementsHEAP[1];
                arrayOfelementsHEAP[1] = arrayOfelementsHEAP[heapsize]; //Replacing with last element of the array  
                heapsize--;
                HeapifyTopToBottom(1);
                Array.Resize(ref arrayOfelementsHEAP, heapsize+1);
                return extractedValue;
            }
        }





        public void increase(int x, int k)
        {
            int ind = 0;
            if (k >= x)
            {
                for (int i = 0; i <= heapsize; i++)
                {
                    if (arrayOfelementsHEAP[i] == x)
                    {
                        ind = i;
                    }
                }
                arrayOfelementsHEAP[ind] = k;
                //PrintHeap();
                HeapifyBottomToTop(ind);
            }

        }



        public void HeapSort()
        {
            Array.Resize(ref arraySorted, heapsize+1);
            int size = heapsize;
            for(int i=0; i<=size; i++)
            {
                arraySorted[size - i] = this.extractMax();
                if (i == size)
                {
                    arraySorted[size - i] = 0;
                }
            }
            Console.WriteLine("Array:");
            foreach (int i in arraySorted)
            {
                Console.Write(i + "   ");
            }
            Console.WriteLine();
        }



        private void HeapifyBottomToTop(int index)
        {
            int parent = index / 2;
            // We are at root of the tree. Hence no more Heapifying is required.  
            if (index <= 1)
            {
                return;
            }
            // If Current value is smaller than its parent, then we need to swap  
            if (arrayOfelementsHEAP[index] > arrayOfelementsHEAP[parent])
            {
                int tmp = arrayOfelementsHEAP[index];
                arrayOfelementsHEAP[index] = arrayOfelementsHEAP[parent];
                arrayOfelementsHEAP[parent] = tmp;
            }
            HeapifyBottomToTop(parent);
        }
        private void HeapifyTopToBottom(int index)
        {
            int left = index * 2;
            int right = (index * 2) + 1;
            int biggestChild = 0;

            int sizeOfTree = heapsize;
            if (sizeOfTree < left)
            { //If there is no child of this node, then nothing to do. Just return.  
                return;
            }
            else if (sizeOfTree == left)
            { //If there is only left child of this node, then do a comparison and return.  
                if (arrayOfelementsHEAP[index] < arrayOfelementsHEAP[left])
                {
                    int tmp = arrayOfelementsHEAP[index];
                    arrayOfelementsHEAP[index] = arrayOfelementsHEAP[left];
                    arrayOfelementsHEAP[left] = tmp;
                }
                return;
            }
            else
            { //If both children are there  
                if (arrayOfelementsHEAP[left] > arrayOfelementsHEAP[right])
                { //Find out the smallest child  
                    biggestChild = left;
                }
                else
                {
                    biggestChild = right;
                }
                if (arrayOfelementsHEAP[index] < arrayOfelementsHEAP[biggestChild])
                { //If Parent is greater than smallest child, then swap  
                    int tmp = arrayOfelementsHEAP[index];
                    arrayOfelementsHEAP[index] = arrayOfelementsHEAP[biggestChild];
                    arrayOfelementsHEAP[biggestChild] = tmp;
                }
            }
            HeapifyTopToBottom(biggestChild);
        }

        
       

    }


    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int a = 0, b = 0, c = 0;
            BinaryHeapMax heap = new BinaryHeapMax();
            while (a != 7)
            {
                Console.WriteLine("choose action: \n1-insert\n2-maximun\n3-extract max\n4-increase key\n5-heap sort\n6-print\n7-exit");
                line = Console.ReadLine();
                a = int.Parse(line);
                switch (a)
                {
                    case 1:
                        Console.WriteLine("enter value: ");
                        line = Console.ReadLine();
                        b = int.Parse(line);
                        heap.insert(b);
                        break;
                    case 2:
                        int m = heap.maximum();
                        break;
                    case 3:
                        int m1 = heap.extractMax();
                        break;
                    case 4:
                        Console.WriteLine("enter value x: ");
                        line = Console.ReadLine();
                        b = int.Parse(line);
                        Console.WriteLine("enter value y: ");
                        line = Console.ReadLine();
                        c = int.Parse(line);
                        heap.increase(b, c);
                        break;
                    case 5:
                        heap.HeapSort();
                        break;
                    case 6:
                        heap.PrintHeap();
                        break;
                }
            }
        }
    }
}

