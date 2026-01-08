using System;
using System.Collections.Generic;
using System.Linq;

public class SocialMediaConnections
{
    private class UserNode
    {
        public int UserId;
        public string Name;
        public int Age;
        public HashSet<int> FriendIds;
        public UserNode? Next;

        public UserNode(int userId, string name, int age)
        {
            UserId = userId;
            Name = name;
            Age = age;
            FriendIds = new HashSet<int>();
        }
    }

    private UserNode? _head;

    public void AddUser(int userId, string name, int age)
    {
        var node = new UserNode(userId, name, age) { Next = _head };
        _head = node;
    }

    private UserNode? FindUser(int userId)
    {
        var current = _head;
        while (current != null)
        {
            if (current.UserId == userId)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public bool AddFriendConnection(int userIdA, int userIdB)
    {
        var userA = FindUser(userIdA);
        var userB = FindUser(userIdB);
        if (userA == null || userB == null || userIdA == userIdB)
        {
            return false;
        }
        userA.FriendIds.Add(userIdB);
        userB.FriendIds.Add(userIdA);
        return true;
    }

    public bool RemoveFriendConnection(int userIdA, int userIdB)
    {
        var userA = FindUser(userIdA);
        var userB = FindUser(userIdB);
        if (userA == null || userB == null)
        {
            return false;
        }

        bool removed = userA.FriendIds.Remove(userIdB);
        removed |= userB.FriendIds.Remove(userIdA);
        return removed;
    }

    public List<int> FindMutualFriends(int userIdA, int userIdB)
    {
        var userA = FindUser(userIdA);
        var userB = FindUser(userIdB);
        if (userA == null || userB == null)
        {
            return new List<int>();
        }
        return userA.FriendIds.Intersect(userB.FriendIds).ToList();
    }

    public List<int> DisplayFriends(int userId)
    {
        var user = FindUser(userId);
        if (user == null)
        {
            return new List<int>();
        }
        return user.FriendIds.ToList();
    }

    public (int UserId, string Name, int Age, IEnumerable<int> Friends)? SearchUserById(int userId)
    {
        var user = FindUser(userId);
        if (user == null)
        {
            return null;
        }
        return (user.UserId, user.Name, user.Age, user.FriendIds);
    }

    public List<(int UserId, string Name, int Age)> SearchUserByName(string name)
    {
        var list = new List<(int, string, int)>();
        var current = _head;
        while (current != null)
        {
            if (current.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                list.Add((current.UserId, current.Name, current.Age));
            }
            current = current.Next;
        }
        return list;
    }

    public Dictionary<int, int> CountFriendsPerUser()
    {
        var result = new Dictionary<int, int>();
        var current = _head;
        while (current != null)
        {
            result[current.UserId] = current.FriendIds.Count;
            current = current.Next;
        }
        return result;
    }
}
