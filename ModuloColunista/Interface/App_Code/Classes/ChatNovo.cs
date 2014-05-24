using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ChatNovo
{
    static List<ChatUsers> ConnectedUsers = new List<ChatUsers>();
    static List<ChatMessage> CurrentMessage = new List<ChatMessage>();

    public String addUser(string name, int id)
    {
        bool n = false;

        foreach (ChatUsers element in ConnectedUsers)
        {
            if (element.userId == id)
            {
                n = true;
            }
        }

        if (!n)
        {
            ChatUsers usr = new ChatUsers();
            usr.userId = id;
            usr.userName = name;
            ConnectedUsers.Add(usr);
            return " ID: " + usr.userId + " NAME: " + usr.userName;
        }
        else
        {
            return name + " " + id;
        }

        
    }//addUser

    public List<ChatUsers> Lista()
    {
        return ConnectedUsers;
    }

    public void Disconnect(int id)
    {
        foreach (ChatUsers element in ConnectedUsers)
        {
            if (element.userId == id)
            {
                ConnectedUsers.Remove(element);
            }
        }

    }





}//class