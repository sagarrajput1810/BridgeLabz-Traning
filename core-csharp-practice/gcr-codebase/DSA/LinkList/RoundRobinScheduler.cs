using System;
using System.Collections.Generic;
using System.Linq;

public class RoundRobinScheduler
{
    private class Node
    {
        public int ProcessId;
        public int BurstTime;
        public int Priority;
        public Node? Next;

        public Node(int processId, int burstTime, int priority)
        {
            ProcessId = processId;
            BurstTime = burstTime;
            Priority = priority;
        }
    }

    private Node? _head;
    private Node? _tail;

    public void AddProcess(int processId, int burstTime, int priority)
    {
        var node = new Node(processId, burstTime, priority);
        if (_tail == null)
        {
            _head = _tail = node;
            node.Next = node;
            return;
        }

        node.Next = _head;
        _tail.Next = node;
        _tail = node;
    }

    public bool RemoveProcess(int processId)
    {
        if (_head == null)
        {
            return false;
        }

        Node? current = _head;
        Node? prev = null;
        do
        {
            if (current!.ProcessId == processId)
            {
                if (prev == null)
                {
                    if (_head == _tail)
                    {
                        _head = _tail = null;
                        return true;
                    }
                    _head = _head!.Next;
                    _tail!.Next = _head;
                }
                else
                {
                    prev.Next = current.Next;
                    if (current == _tail)
                    {
                        _tail = prev;
                    }
                }
                return true;
            }
            prev = current;
            current = current.Next;
        } while (current != _head);

        return false;
    }

    public (List<string> rounds, double averageWaitingTime, double averageTurnaroundTime) Simulate(int timeQuantum)
    {
        if (_head == null || timeQuantum <= 0)
        {
            return (new List<string>(), 0, 0);
        }

        var log = new List<string>();
        var burstRemaining = new Dictionary<int, int>();
        var originalBurst = new Dictionary<int, int>();
        var completionTime = new Dictionary<int, int>();
        var readyOrder = new List<int>();
        var current = _head;
        do
        {
            burstRemaining[current!.ProcessId] = current.BurstTime;
            originalBurst[current.ProcessId] = current.BurstTime;
            readyOrder.Add(current.ProcessId);
            current = current.Next;
        } while (current != _head);

        int time = 0;
        while (burstRemaining.Values.Any(v => v > 0))
        {
            foreach (var pid in readyOrder)
            {
                if (burstRemaining[pid] <= 0)
                {
                    continue;
                }

                int runTime = Math.Min(timeQuantum, burstRemaining[pid]);
                burstRemaining[pid] -= runTime;
                time += runTime;
                log.Add($"Process {pid} ran for {runTime} units; remaining {burstRemaining[pid]}");

                if (burstRemaining[pid] == 0)
                {
                    completionTime[pid] = time;
                }
            }
        }

        double avgWaiting = completionTime.Keys.Average(pid => completionTime[pid] - originalBurst[pid]);
        double avgTurnaround = completionTime.Values.Average();
        return (log, avgWaiting, avgTurnaround);
    }

    public List<(int ProcessId, int BurstTime, int Priority)> DisplayProcesses()
    {
        var list = new List<(int, int, int)>();
        if (_head == null)
        {
            return list;
        }
        var current = _head;
        do
        {
            list.Add((current!.ProcessId, current.BurstTime, current.Priority));
            current = current.Next;
        } while (current != _head);
        return list;
    }
}
