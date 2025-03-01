using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLib.Models
{
    public class MemoryUsersModel : IUsersModel
    {
        private List<User> _users = new List<User>();
        private List<User> FiltrUser = new List<User>();
        public event Action SuccessLoadedInfoUsers;
        

        public List<User> GetUsers()
        {
            return FiltrUser;
        }

        public void LoadInfoUsers()
        {
            _users.Add(new User {Id = 101,Login = "ЕгорГудЛак", Password = "123", Name = "Егор", Surname = "Глагольев", Email = "pgbc303@gmail.com", Avatar = "D://П-40/56.jpg", DateBirth = new DateTime(2006, 08, 14) });
            _users.Add(new User {Id = 202,Login = "ЕгорЦветок", Password = "321", Name = "Егор", Surname = "Цветков", Email = "egor@gmail.com", Avatar = "D://П-40/6f3c2g4l29-1920.jpg", DateBirth = new DateTime(2006, 09, 25) });
            _users.Add(new User {Id = 303,Login = "ДамирБека", Password = "213", Name = "Дамир", Surname = "Жруманулов", Email = "damir@gmail.com", Avatar = "D://П-40/1700843682_new_preview_1648647805_new_preview_крош.jpg", DateBirth = new DateTime(2006, 02, 08) });
            _users.Add(new User {Id = 404,Login = "СаняМексикаУсики", Password = "312", Name = "Александр", Surname = "Филиппов", Email = "sanya@gmail.com", Avatar = "D://П-40/d621e3u-960.jpg", DateBirth = new DateTime(2005, 07, 15) });

            FiltrUser = _users;
            
            SuccessLoadedInfoUsers.Invoke();
        }

        public void FiltrUserData(string NameFiltr, string input)
        {
            if (input == "Имя")
            {
                FiltrUser = _users.Where(p => p.Name.Contains(NameFiltr)).ToList();
                SuccessLoadedInfoUsers.Invoke();
            }
            if (input == "Логин")
            {
                FiltrUser = _users.Where(p => p.Login.Contains(NameFiltr)).ToList();
                SuccessLoadedInfoUsers.Invoke();
            }
        }

        public List<User> ReturnUsers()
        {
            FiltrUser = _users;
            return FiltrUser;
        }

        public void ChangeUser(User u)
        {
            foreach (User current in _users)
            {
                if (current.Id == u.Id)
                {

                    current.Name = u.Name;
                    current.Surname = u.Surname;
                    current.Email = u.Email;
                    SuccessLoadedInfoUsers.Invoke();
                }
            }

            foreach (User current in FiltrUser)
            {
                if (current.Id == u.Id)
                {
                    current.Name = u.Name;
                    current.Surname = u.Surname;
                    current.Email = u.Email;
                    SuccessLoadedInfoUsers.Invoke();
                }
            }
        }

        public void DeleteUser (int del)
        {
            User delete = FiltrUser.FirstOrDefault(u => u.Id == del);
            if (delete != null)
            {
                _users.Remove(delete); FiltrUser.Remove(delete);
                SuccessLoadedInfoUsers.Invoke();
            }
        }
    }
}
