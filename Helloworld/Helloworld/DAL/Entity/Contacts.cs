using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld.DAL.Entity
{
    public class Contacts
    {
        private string name;
        private string phone;
        private string email;
        private char firstCharName;
        // Constructor
        /*
        public Contacts(string Name, string Phone, string Email)
        {
            name = Name;
            phone = Phone;
            email = Email;
        }
        */
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public char FirstCharName { get => firstCharName; set => firstCharName = value; }

        public static List<Contacts> getListContacts(string path)
        {
            List<Contacts> lstContacts = new List<Contacts>();

            string[] data = File.ReadAllLines(path);
            foreach(string line in data)
            {
                var lstValue = line.Split('|');

                Contacts contact = new Contacts
                {
                     firstCharName = getCharFirst(lstValue[0]),
                     name = lstValue[0],
                     phone = lstValue[1],
                     email = lstValue[2],
                };
                lstContacts.Add(contact);
            }
            return lstContacts;
        }

        public static List<Contacts> getListABC(string path, char c)
        {
            List<Contacts> lstContacts = getListContacts(path);

            List<Contacts> lstContactsABC = new List<Contacts>();

            foreach(Contacts contact in lstContacts)
            {
              
                if (contact.firstCharName >= c)
                {
                    lstContactsABC.Add(contact);
                }
                
            }
            return lstContactsABC;
        }

        public static void deleteContact(string path, string name, string phone, string email)
        {
            string[] data = File.ReadAllLines(path);
            File.WriteAllText(path, "");
            using(StreamWriter writer = new StreamWriter(path))
            {
                foreach(string line in data)
                {
                    /*
                    var lstValue = line.Split('|');
                    string n = lstValue[0];
                    string p = lstValue[1];
                    string e = lstValue[2];
                    */
                    if(!line.Equals(name) && !line.Equals(phone))
                    {
                        writer.WriteLine(line);
                    }  
                }
                writer.Flush();
                writer.Close();
            }
        }

        private static char getCharFirst(string str)
        {
            return str[0];
        }
    }
}
