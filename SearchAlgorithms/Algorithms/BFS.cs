﻿using SearchAlgorithms.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms.Algorithms
{
    public class BreadthFirstSearch<T> : SearchAlgo<T> where T :  IComparable
    {
        Node<T> _goalNode, _startNode;
        public BreadthFirstSearch(Node<T> goalNode, Node<T> startNode) : base(goalNode, startNode)
        {
            _goalNode = goalNode;
            _startNode = startNode;
        }
        public override void Search()
        {
            var visitedNodes = new List<Node<T>>();
            var queue = new Queue<Node<T>>();

            Log($"Start Node : {_startNode.NodeName}");
            if (_startNode.NodeName.Equals(_goalNode.NodeName))
            {
                Log($"Goal Node found");
                LogVisitedNodes(visitedNodes);
            }
            else
            {
                if (!visitedNodes.Contains(_startNode))
                {
                    queue.Enqueue(_startNode);
                    visitedNodes.Add(_startNode);
                }
                while (queue.Count > 0)
                {
                    var currentNode = queue.Dequeue();

                    if (currentNode.NodeName.Equals(_goalNode.NodeName))
                    {
                        Log($"Goal Node found {currentNode.NodeName}");
                        if (!visitedNodes.Contains(currentNode))
                            visitedNodes.Add(currentNode);
                        break;
                    }
                    var children = currentNode.Children;
                    //var children = currentNode.Children();
                    if (children == null || children.Count <= 0) continue;
                    foreach (var child in children)
                    {
                        if (child.NodeName.Equals(_goalNode.NodeName))
                        {
                                     
                            if (!visitedNodes.Contains(child))
                                visitedNodes.Add(child);
                            LogVisitedNodes(visitedNodes);
                            Log($"\nGoal Node found: {child.NodeName}");
                            break;
                        }
                        if (visitedNodes.Contains(child)) continue;
                        visitedNodes.Add(child);
                        queue.Enqueue(child);
                    }
                }

            }

        }
    }
}
