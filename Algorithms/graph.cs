using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    enum State { Visited, Visiting, Unvisited }

    class GraphNode {

        public GraphNode[] adj;

        public State state = State.Unvisited; 

        GraphNode(GraphNode[] adj) {
            this.adj = adj;
        }
    }


    class Graph
    {
        public GraphNode[] nodes;

        Graph(GraphNode[] nodes) {
            this.nodes = nodes;
        }

        //4.2 Given a directed graph, design an algorithm to find out whether there is a route between two nodes.

        bool findPath(GraphNode start, GraphNode end) {

            var list = new List<GraphNode>();
            list.Add(start);

            GraphNode iter;

            while (list.Count != 0)
            {
                iter = list.First();                
                list.Remove(iter);
                iter.state = State.Visiting;

                foreach (var adj in iter.adj)
                {
                    if (adj.state == State.Unvisited)
                    {
                        if (adj == end)
                        {
                            return true;
                        }
                        else {
                            adj.state = State.Visiting;
                            list.Add(adj);
                        }
                    }

                    iter.state = State.Visited;
                }
            }

            return false;
        }
        
    }
}
