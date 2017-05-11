using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class AccountQueries
    {
        private TMEntities db;
        public AccountQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<AspNetUsersDTO> GetAllCustomers()
        {
            var users = (from x in db.AspNetUsers
                             select new AspNetUsersDTO
                             {
                                 ID = x.Id,
                                 Address = x.Address,
                                 Email = x.Email,
                                 EmailConfirmed = x.EmailConfirmed,
                                 PasswordHash = x.PasswordHash,
                                 SecurityStamp = x.SecurityStamp, 
                                 PhoneNumber = x.PhoneNumber,
                                 PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                                 TwoFactorEnabled = x.TwoFactorEnabled,
                                 LockoutEndDateUtc = x.LockoutEndDateUtc,
                                 LockoutEnabled = x.LockoutEnabled,
                                 AccessFailedCount = x.AccessFailedCount,
                                 UserName = x.UserName,
                                 customer_CID = x.customer_CID,
                                 trainer_TRID = x.trainer_TRID
                             });
            return users;
        }


    }
}