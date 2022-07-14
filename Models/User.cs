using MVC_User.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_User.Models
{
    public class User
    {
        [Key]
        public int U_ID { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string U_NAME { get; set; }
        [Required]
        [DisplayName("User Role")]
        public string U_ROLL { get; set; }

        public void Save_User(User oUser)
        {
            User_DAL oUserData = new User_DAL();
            oUserData.Save_User(oUser);
        }
    }
}