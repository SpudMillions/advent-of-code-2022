using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day7 : DayBase
    {
        internal Day7() : base(7, 2022, "No Space Left On Device")
        {
        }

        private const int AvailableSpace = 70000000;
        private const int SpaceNeededForUpgrade = 30000000;

        public override void Play()
        {
            var input = Input;
            var currentWorkingDirectory = new Node("/", null, NodeType.Directory, 0);
            var root = currentWorkingDirectory;

            foreach (var line in input)
            {
                if (line.StartsWith("$"))
                {
                    ProcessCommand(line, ref currentWorkingDirectory, ref root);
                }
                else
                {
                    ProcessDirectory(line, ref currentWorkingDirectory, ref root);
                }
            }

            var nodes = root.GetAllNodes();
            var enumerable = nodes.ToList();
            var totalSize = enumerable.Where(node => node.Type == NodeType.Directory && node.Size < 100000).Sum(node => node.Size);
            
            var totalCurrentSizeUsed = root.Size;
            var spaceNotUsed = AvailableSpace - totalCurrentSizeUsed;
            var spaceNeeded = SpaceNeededForUpgrade - spaceNotUsed;

            var closestNode = enumerable.Where(node => node.Type == NodeType.Directory && node.Size > spaceNeeded).OrderBy(node => node.Size).First();

            Console.WriteLine($"{GetType().Name} : {Title} --- Total Size Available to Delete: {totalSize}. Directory to delete: {closestNode.Name} with size {closestNode.Size}");
        }


        private void PrintTree(Node root, int i)
        {
            var indent = root.Type == NodeType.Directory ? "/" : "";
            var size = root.Type == NodeType.File ? "" : $"({root.Size})";
            Console.WriteLine($"{new string(' ', i)}{indent}{root.Name}{size}");
            foreach (var child in root.Children)
            {
                PrintTree(child, i + 1);
            }
            
        }

        private void ProcessDirectory(string line, ref Node currentWorkingDirectory, ref Node root)
        {
            var cmd = line.Split(" ");
            if (cmd[0] == "dir" && cmd.Length > 1)
            {
                var child = currentWorkingDirectory.Children.Find(x => x.Name == cmd[1]);
                if (child != null) return;
                var newNode = new Node(cmd[1], currentWorkingDirectory, NodeType.Directory, 0);
                currentWorkingDirectory.Children.Add(newNode);
            }
            else if (int.TryParse(cmd[0], out var _))
            {
                var child = currentWorkingDirectory.Children.Find(x => x.Name == cmd[1]);
                if (child != null) return;
                var newNode = new Node(cmd[1], currentWorkingDirectory, NodeType.File, int.Parse(cmd[0]));
                currentWorkingDirectory.Size += newNode.Size;
                UpdateParentSizes(currentWorkingDirectory, newNode.Size);
                currentWorkingDirectory.Children.Add(newNode);
            }
        }

        private void UpdateParentSizes(Node currentWorkingDirectory, int newNodeSize)
        {
            var parent = currentWorkingDirectory.Parent;
            while (parent != null)
            {
                parent.Size += newNodeSize;
                parent = parent.Parent;
            }
        }


        private void ProcessCommand(string line, ref Node currentWorkingDirectory, ref Node root)
        {
            var cmd = line.Split(" ");
            if (cmd[1] == "cd")
            {
                currentWorkingDirectory = cmd[2] switch
                {
                    ".." => currentWorkingDirectory.Parent,
                    "/" => root,
                    _ => currentWorkingDirectory.Children.Find(x => x.Name == cmd[2])
                };
            }
        }
    }

    public enum NodeType
    {
        File,
        Directory
    }

    public class Node
    {
        public Node(string name, Node node, NodeType type, int size)
        {
            Name = name;
            Parent = node;
            Children = new List<Node>();
            Type = type;
            Size = size;
        }

        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public NodeType Type { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }

        public IEnumerable<Node> GetAllNodes()
        {
            var nodes = new List<Node> { this };
            foreach (var child in Children)
            {
                nodes.AddRange(child.GetAllNodes());
            }

            return nodes;
        }
    }
}