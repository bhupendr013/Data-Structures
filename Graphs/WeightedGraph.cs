using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraph
{
    class Graph
    {
        int V;
        int E;
        public List<Edge>[] AdjList;
        public Graph(int v, int e)
        {
            this.V = v;
            this.E = e;
            AdjList = new List<Edge>[v];
            for (int i = 0; i < v; i++)
            {
                AdjList[i] = new List<Edge>();
            }
        }

        public class Edge
        {
            public int dest;
            public int weight;
            public Edge(int dest, int weight)
            {
                this.dest = dest;
                this.weight = weight;
            }
        }

        public void AddEdge(int source, int dest, int weight)
        {
            AdjList[source].Add(new Edge(dest, weight));
        }

        #region Breath First Search
        public void BFS(int v)
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            for (int i = 0; i < v; i++)
            {
                if (!dict.ContainsKey(i))
                {
                    BFSUtil(i, queue, dict);
                }
            }
        }

        public void BFSUtil(int v, Queue<int> queue, Dictionary<int, bool> dict)
        {
            queue.Enqueue(v);
            //dict[v] = true;
            while (queue.Count != 0)
            {
                int temp = queue.Dequeue();
                if (!dict.ContainsKey(temp))
                {
                    dict[temp] = true;
                    foreach (var item in AdjList[temp])
                    {
                        queue.Enqueue(item.dest);
                        Console.WriteLine("Edge " + temp + " to dest " + item.dest + " is of length" + item.weight);

                    }
                }
            }
        }
        #endregion

        #region  Calculate Path
        public bool IsPathExist(int source, int dest)
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            queue.Enqueue(source);
            while (queue.Count != 0)
            {
                int temp = queue.Dequeue();
                if (!dict.ContainsKey(temp))
                {
                    dict[temp] = true;
                    foreach (var item in AdjList[temp])
                    {
                        if (item.dest == dest)
                        {
                            return true;
                        }
                        queue.Enqueue(item.dest);
                    }
                }
            }
            return false;
        }

        public int GetPathLengthUtil(Stack<int> stack, Dictionary<int, bool> dict, int sum, int source, int dest)
        {
            stack.Push(source);
            while (stack.Count != 0)
            {
                int temp = stack.Pop();
                if (!dict.ContainsKey(temp))
                {
                    //sum += temp;
                    if (temp == dest)
                    {
                        return sum;
                    }
                    dict[temp] = true;
                    foreach (var item in AdjList[temp])
                    {
                        if (!dict.ContainsKey(item.dest))
                        {
                            return GetPathLengthUtil(stack, dict, sum + item.weight, item.dest, dest);
                        }
                    }
                }

            }
            return 0;
        }
        public int GetPathLength(int source, int dest)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            int sum = 0;

            return GetPathLengthUtil(stack, dict, sum, source, dest);
        }
        #endregion

        #region Topological Sorting 

        public void TopologicalSortingUtil(Stack<int> stack, Dictionary<int, bool> dict, int source)
        {

            int temp = source;
            if (!dict.ContainsKey(temp))
            {
                dict[temp] = true;
                foreach (var item in AdjList[temp])
                {
                    TopologicalSortingUtil(stack, dict, item.dest);
                }
                stack.Push(temp);
            }

        }
        public void TopologicalSorting()
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            for (int i = 0; i < V; i++)
            {
                if (!dict.ContainsKey(i))
                {
                    TopologicalSortingUtil(stack, dict, i);
                }
            }
            Console.WriteLine("Topological sorted order of the Graph:");
            foreach (var item in stack)
            {
                Console.WriteLine(item + "->");
            }
        }

        public void AlphabetOrder()
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            for (int i = 0; i < V; i++)
            {
                if (!dict.ContainsKey(i))
                {
                    TopologicalSortingUtil(stack, dict, i);
                }
            }
            Console.WriteLine("Order of alphabets:");
            foreach (var item in stack)
            {
                Console.WriteLine((char)(item + 'a') + "->");
            }
        }
        public void FindAlienLanguage(String[] words)
        {
            Graph graph = new Graph(26, 26);
            int len = words.Length;
            for (int i = 0; i < len - 1; i++)
            {
                String word1 = words[i];
                String word2 = words[i + 1];
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        graph.AddEdge(word1[j] - 'a', word2[j] - 'a', 0);
                        break;
                    }
                }
            }
            AlphabetOrder();

        }
        #endregion

        #region Dictionary Words
        int min(int x, int y, int z)
        {
            return Math.Min(Math.Min(x, y), z);
        }

        int editDistDP(string str1, string str2, int m, int n)
        {
            // Create a table to store results of subproblems
            int[,] dp = new int[m + 1, n + 1];

            // Fill d[][] in bottom up manner
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    // If first string is empty, only option is to
                    // isnert all characters of second string
                    if (i == 0)
                        dp[i, j] = j;  // Min. operations = j

                    // If second string is empty, only option is to
                    // remove all characters of second string
                    else if (j == 0)
                        dp[i, j] = i; // Min. operations = i

                    // If last characters are same, ignore last char
                    // and recur for remaining string
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    // If last character are different, consider all
                    // possibilities and find minimum
                    else
                        dp[i, j] = 1 + min(dp[i, j - 1],  // Insert
                                            dp[i - 1, j],  // Remove
                                            dp[i - 1, j - 1]); // Replace
                }
            }


            return dp[m, n];
        }
        public void WordDistance(string[] words, string source, string dest)
        {
            Graph graph = new Graph(words.Length, words.Length);
            Dictionary<String, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                dict[words[i]] = i;
                for (int j = i + 1; j < words.Length; j++)
                {
                    string word1 = words[i];
                    string word2 = words[j];
                    if (editDistDP(word1, word2, word1.Length, word2.Length) == 1)
                    {

                        //continue;
                        graph.AddEdge(i, j, 1);
                    }
                }
            }
            Stack<int> stack = new Stack<int>();
            Dictionary<int, bool> dict2 = new Dictionary<int, bool>();
            List<int> list = new List<int>();
            list.Add(dict[source]);
            list = PrintPath(words, dict[source], dict[dest], stack, dict2, list);
            Console.WriteLine(" Source to destination path is:");
            foreach (var item in list)
            {
                Console.Write(words[item] + "->");
            }
        }

        public List<int> PrintPath(string[] words, int source, int dest, Stack<int> stack, Dictionary<int, bool> dict, List<int> list)
        {
            if (!dict.ContainsKey(source))
            {
                dict[source] = true;
                foreach (var item in AdjList[source])
                {
                    list.Add(item.dest);
                    if (item.dest == dest)
                    {
                        return list;
                    }
                    return PrintPath(words, item.dest, dest, stack, dict, list);
                }
            }
            return list;
        }
        #endregion

        #region Prims MST
        /*
        struct MinHeapNode
{
    int  v;
    int key;
};
 
// Structure to represent a min heap
struct MinHeap
{
    int size;      // Number of heap nodes present currently
    int capacity;  // Capacity of min heap
    int *pos;     // This is needed for decreaseKey()
    struct MinHeapNode **array;
};
 
// A utility function to create a new Min Heap Node
struct MinHeapNode* newMinHeapNode(int v, int key)
{
    struct MinHeapNode* minHeapNode =
           (struct MinHeapNode*) malloc(sizeof(struct MinHeapNode));
    minHeapNode->v = v;
    minHeapNode->key = key;
    return minHeapNode;
}

            */
        public class MinHeapNode
        {
            public int key;
            public int value;
            public MinHeapNode(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public class MinHeap
        {
            public MinHeapNode[] array;
            public int[] pos;
            public int size;
            public int capacity;
            public MinHeap(int capacity)
            {
                this.size = 0;
                this.capacity = capacity;
                array = new MinHeapNode[capacity];
                pos = new int[capacity];
            }

            public bool IsEmptyMinHeap(MinHeap heap)
            {
                return heap.size == 0;
            }

            public void MinHeapify(MinHeap heap, int index)
            {
                int smallest, left, right;
                smallest = index;
                left = 2 * index + 1;
                right = 2 * index + 2;
                if (left < heap.size && heap.array[left].key < heap.array[smallest].key)
                {
                    smallest = left;
                }
                if (right < heap.size && heap.array[right].key < heap.array[smallest].key)
                {
                    smallest = right;
                }
                if (smallest != index)
                {
                    MinHeapNode smallestNode = heap.array[smallest];
                    MinHeapNode indexNode = heap.array[index];
                    heap.pos[smallestNode.value] = index;
                    heap.pos[indexNode.value] = smallest;
                    MinHeapNode temp = smallestNode;
                    smallestNode = indexNode;
                    indexNode = temp;
                    MinHeapify(heap, smallest);
                }
            }
            public MinHeapNode ExtractMinKey(MinHeap heap)
            {
                if (IsEmptyMinHeap(heap))
                {
                    return null;
                }
                MinHeapNode first = heap.array[0];
                MinHeapNode last = heap.array[heap.size - 1];
                heap.array[0] = last;
                heap.pos[first.value] = heap.size - 1;
                heap.pos[last.value] = 0;
                heap.size--;
                MinHeapify(heap, 0);
                return first;
            }

            public bool IsInMinHeap(MinHeap minHeap, int v)
            {
                if (minHeap.pos[v] < minHeap.size)
                {
                    return true;
                }
                return false;
            }
            public void DecreaseKey(MinHeap minHeap, int key, int v)
            {

            }
        }
        public void FindPrimsMSTAdjList(int[,] graph)
        {
            int vertext = V;
            int[] parent = new int[V];
            int[] key = new int[V];
            MinHeap minHeap = new MinHeap(vertext);
            for (int v = 1; v < vertext; v++)
            {
                parent[v] = -1;
                key[v] = Int32.MaxValue;
                minHeap.array[v] = new MinHeapNode(v, key[v]);
                minHeap.pos[v] = v;
            }

            key[0] = 0;
            minHeap.pos[0] = 0;
            minHeap.array[0] = new MinHeapNode(0, key[0]);
            minHeap.size = vertext;
            while (!minHeap.IsEmptyMinHeap(minHeap))
            {
                MinHeapNode node = minHeap.ExtractMinKey(minHeap);
                int u = node.value;
                foreach (var item in AdjList[u])
                {
                    int v = item.dest;
                    if (minHeap.IsInMinHeap(minHeap, v) && item.weight < key[v])
                    {
                        key[v] = item.weight;
                        parent[v] = u;
                        minHeap.DecreaseKey(minHeap, key[v], v);
                    }
                }
            }
        }


        public void FindPrimsMST(int[,] graph)
        {
            int vertex = graph.GetLength(0);
            int[] key = new int[vertex];
            bool[] mstIncluded = new bool[vertex];
            int[] parent = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                key[i] = Int32.MaxValue;
                mstIncluded[i] = false;
            }
            key[0] = 0;
            //mstIncluded[0] = true;
            parent[0] = -1;
            for (int i = 0; i < vertex; i++)
            {
                int u = FindMinKey(key, mstIncluded);
                mstIncluded[u] = true;
                for (int v = 0; v < vertex; v++)
                {
                    if (graph[u, v] != 0 && mstIncluded[v] == false && graph[u, v] < key[v])
                    {
                        key[v] = graph[u, v];
                        parent[v] = u;
                    }
                }

            }
            PrintPrimsMST(parent, graph);
        }

        int FindMinKey(int[] key, bool[] mstIncluded)
        {
            int index = -1;
            int min = Int32.MaxValue;
            for (int i = 0; i < key.Length; i++)
            {
                if (mstIncluded[i] == false && key[i] < min)
                {
                    min = key[i];
                    index = i;
                }
            }

            return index;
        }

        void PrintPrimsMST(int[] parent, int[,] graph)
        {
            for (int i = 0; i < parent.Length; i++)
            {
                if (parent[i] != -1)
                {
                    Console.WriteLine(i + "-" + parent[i] + " Weight " + graph[parent[i], i]);
                }

            }
        }
        #endregion

        #region Kruskal Spanning Tree
        class Subset
        {
            public int parent;
            public int rank;
        }

        int Find(Subset[] subset, int i)
        {
            if (subset[i].parent != i)
            {
                subset[i].parent = Find(subset, subset[i].parent);
            }
            return subset[i].parent;
        }

        void Union(Subset[] subset, int x, int y)
        {
            int xRoot = Find(subset, x);
            int yRoot = Find(subset, y);
            if (subset[xRoot].rank < subset[yRoot].rank)
            {
                subset[xRoot].parent = yRoot;
            }
            else if (subset[xRoot].rank > subset[yRoot].rank)
            {
                subset[yRoot].parent = xRoot;
            }
            else
            {
                subset[yRoot].parent = xRoot;
                subset[xRoot].rank++;
            }
        }
        public void KruskalSpannigTree(Graph graph)
        {

        }
        #endregion

        #region Dijkstra's Algorithms
        public void DijkstraAdjMat(int[,] mat)
        {
            int vertex = mat.GetLength(0);
            bool[] include = new bool[vertex];
            int[] dist = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                include[i] = false;
                dist[i] = Int32.MaxValue;
            }
            dist[0] = 0;

            for (int i = 0; i < vertex; i++)
            {
                int u = FindMinKey(dist, include);
                for (int v = 0; v < vertex; v++)
                {
                    if (include[v] == false && mat[u, v] != 0 && dist[u] != Int32.MaxValue && dist[u] + mat[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + mat[u, v];
                    }
                }
            }
            Console.ReadLine();

        }
        //public void DijkstraAdjMatTest(int[,] mat)
        //{
        //    int vertex = mat.GetLength(0);
        //    bool[,] include = new bool[vertex,vertex];
        //    int[,] dist = new int[vertex,vertex];
        //    for (int i = 0; i < vertex; i++)
        //    {
        //        for(int j = 0; j < vertex; j++)
        //        {
        //            include[i, j] = false;
        //            dist[i, j] = Int32.MaxValue;
        //        }
        //        //include[i] = false;
        //        //dist[i] = Int32.MaxValue;
        //    }
        //    //dist[0] = 0;

        //    for (int i = 0; i < vertex; i++)
        //    {
        //        //int u = FindMinKey(dist, include);
        //        for (int v = 0; v < vertex; v++)
        //        {
        //            if (include[i,v] == false && mat[i, v] != 0 && dist[u] != Int32.MaxValue && dist[u] + mat[u, v] < dist[v])
        //            {
        //                dist[v] = dist[u] + mat[u, v];
        //            }
        //        }
        //    }
        //    Console.ReadLine();

        //}
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(3, 3);
            /* graph.AddEdge(0, 1, 5);
             graph.AddEdge(1, 2, 4);
             graph.AddEdge(4, 0, 7);
             graph.AddEdge(3, 4, 3);
             graph.AddEdge(3, 2, 8); */
            string[] words = { "caa", "aaa", "aab" };
            string[] dictionary = { "BCCI", "AICC", "ICC", "CCI", "MCC", "MCA", "ACC" };
            graph.WordDistance(dictionary, "AICC", "MCA");
            graph.FindAlienLanguage(words);
            Graph graphDict = new Graph(6, 6);
            graphDict.AddEdge(5, 2, 5);
            graphDict.AddEdge(5, 0, 4);
            graphDict.AddEdge(4, 0, 7);
            graphDict.AddEdge(4, 1, 4);
            graphDict.AddEdge(2, 3, 3);
            graphDict.AddEdge(3, 1, 8);
            graphDict.BFS(6);
            graphDict.TopologicalSorting();
            Console.WriteLine("Find path:");
            if (graph.IsPathExist(0, 2))
            {
                Console.WriteLine("Path exists:");
            }
            else
            {
                Console.WriteLine("Path doesnot exists:");
            }
            Console.WriteLine("Path length is" + graph.GetPathLength(0, 2));

            int[,] primsgraph = {{0, 2, 0, 6, 0},
                      {2, 0, 3, 8, 5},
                      {0, 3, 0, 0, 7},
                      {6, 8, 0, 0, 9},
                      {0, 5, 7, 9, 0},
                     };
            graph.DijkstraAdjMat(primsgraph);
            Console.WriteLine("Prims MST");
            graph.FindPrimsMST(primsgraph);
            Graph kruskalGraph = new Graph(4, 4);
            kruskalGraph.AddEdge(0, 1, 10);
            kruskalGraph.AddEdge(0, 2, 6);
            kruskalGraph.AddEdge(0, 3, 5);
            kruskalGraph.AddEdge(1, 3, 15);
            kruskalGraph.AddEdge(2, 3, 4);

            
            Console.ReadLine();
        }
    }
}