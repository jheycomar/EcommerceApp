using EcommerceApp.Clases;
using EcommerceApp.Date;
using EcommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Services
{
    public class DateService
    {

        public Response UpdateUser(User user)
        {
            try
            {
                using (var db = new DataAccess())
                {
                    var oldUser = db.First<User>(false); // saca el primer usuario
                    if (oldUser != null)
                    {
                        db.Delete(oldUser);
                    }
                    db.Update(user);
                }
                return new Response { IsSucces = true, Message = "Usuario actualizado", Result = user, };
            }
            catch (Exception ex)
            {

                return new Response {IsSucces=false,Message= ex.Message};
            }
        }
        public User GetUser()
        {
            using (var db = new DataAccess())
            {
                return db.First<User>(true);
            }           
           
        }
        public Response InsertUser(User user)
        {
            try
            {
                using (var db=new DataAccess())
                {
                    var oldUser = db.First<User>(false); // saca el primer usuario
                    if (oldUser!=null)
                    {
                        db.Delete(oldUser);
                    }
                    db.Insert(user);
                }
                return new Response { IsSucces=true,Message="Usuario insertado",Result=user,};

            }
            catch (Exception ex)
            {

                return new Response {IsSucces=false,Message= ex.Message};
            }
        }
    }
}
