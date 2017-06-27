using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;
using TrainingMasterWebAPI.Models;

namespace TrainingMasterWebAPI.Queries
{
    public class CustomerQueries
    {
        private TMEntities db;
        public CustomerQueries()
        {
            db = new TMEntities();
        }

        public CustomerDTO GetCustomerById(string id)
        {

            var customer = (from x in db.customer
                            where x.ID == id
                            select new CustomerDTO
                            {
                                CID = x.CID,
                                name = x.name,
                                email = x.email,
                                phone = x.phone,
                                gender = x.gender,
                                kennitala = x.kennitala,
                                address = x.address,
                                country = x.country,
                                foodPref = x.foodPref,
                                injury = x.injury,
                                allergy = x.allergy,
                                zipcodes_ZIP = x.zipcodes_ZIP,
                                profileImagePath = x.profileImagePath,
                                height = x.height,
                                trainer_TRID = x.trainer_TRID,
                                hidden = x.hidden,
                                jobDifficulty = x.jobDifficulty
                            }).SingleOrDefault();
            return customer;
        }

        public CustomerDTO GetCustomerByCID(int CID, string userID)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userID
                           select x).FirstOrDefault();

            var customer = (from x in db.customer
                            where x.CID == CID && x.trainer_TRID == trainer.TRID
                            select new CustomerDTO
                            {
                                CID = x.CID,
                                name = x.name,
                                email = x.email,
                                phone = x.phone,
                                gender = x.gender,
                                kennitala = x.kennitala,
                                address = x.address,
                                country = x.country,
                                foodPref = x.foodPref,
                                injury = x.injury,
                                allergy = x.allergy,
                                zipcodes_ZIP = x.zipcodes_ZIP,
                                profileImagePath = x.profileImagePath,
                                height = x.height,
                                trainer_TRID = x.trainer_TRID,
                                hidden = x.hidden,
                                jobDifficulty = x.jobDifficulty
                            }).SingleOrDefault();
            return customer;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            var customers = (from x in db.customer
                             select new CustomerDTO
                             {
                                 CID = x.CID,
                                 name = x.name,
                                 email = x.email,
                                 phone = x.phone,
                                 gender = x.gender,
                                 kennitala = x.kennitala,
                                 address = x.address,
                                 country = x.country,
                                 foodPref = x.foodPref,
                                 injury = x.injury,
                                 allergy = x.allergy,
                                 zipcodes_ZIP = x.zipcodes_ZIP,
                                 profileImagePath = x.profileImagePath,
                                 height = x.height,
                                 trainer_TRID = x.trainer_TRID,
                                 hidden = x.hidden,
                                 jobDifficulty = x.jobDifficulty
                             });
            return customers;
        }

        public IEnumerable<CustomerDTO> GetAllCustomersByTRID(string userId)
        {
            var trainer = (from x in db.trainer
                           where x.ID == userId
                           select x).FirstOrDefault();
            var customers = (from x in db.customer
                             where x.trainer_TRID == trainer.TRID
                             select new CustomerDTO
                             {
                                 CID = x.CID,
                                 name = x.name,
                                 email = x.email,
                                 phone = x.phone,
                                 gender = x.gender,
                                 kennitala = x.kennitala,
                                 address = x.address,
                                 country = x.country,
                                 foodPref = x.foodPref,
                                 injury = x.injury,
                                 allergy = x.allergy,
                                 zipcodes_ZIP = x.zipcodes_ZIP,
                                 profileImagePath = x.profileImagePath,
                                 height = x.height,
                                 trainer_TRID = x.trainer_TRID,
                                 hidden = x.hidden
                             });
            return customers;
        }

        public CustomerDTO UpdateCustomer(string userId, CustomerDTO customer)
        {
            var c = (from x in db.customer
                     where x.ID == userId
                     select x).FirstOrDefault();

                c.name = customer.name;
                c.email = customer.email;
                c.phone = customer.phone;
                c.gender = customer.gender;
                c.kennitala = customer.kennitala;
                c.address = customer.address;
                c.country = customer.country;
                c.foodPref = customer.foodPref;
                c.injury = customer.injury;
                c.allergy = customer.allergy;
                c.zipcodes_ZIP = customer.zipcodes_ZIP;
                c.height = customer.height;
                c.jobDifficulty = customer.jobDifficulty;
            //unaffected by customer update
                customer.profileImagePath = c.profileImagePath;
                customer.trainer_TRID = c.trainer_TRID;
                customer.hidden = c.hidden;
                customer.CID = c.CID;

            db.SaveChanges();
            return customer;

        }

        public string UpdateProfileImage(string userId, CustomerDTO Customer)
        {
            var c = (from x in db.customer
                     where x.ID == userId
                     select x).FirstOrDefault();
            c.profileImagePath = Customer.profileImagePath;
            db.SaveChanges();
            return c.profileImagePath;
        }

        public bool RegisterCustomer(CustomerDTO Customer)
        {
            try
            {
                var c = new customer
                {
                    CID = Customer.CID,
                    ID = Customer.ID,
                    name = Customer.name,
                    email = Customer.email,
                    phone = Customer.phone,
                    gender = Customer.gender,
                    kennitala = Customer.kennitala,
                    address = Customer.address,
                    foodPref = Customer.foodPref,
                    injury = Customer.injury,
                    allergy = Customer.allergy,
                    zipcodes_ZIP = Customer.zipcodes_ZIP,
                    profileImagePath = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Profile_avatar_placeholder_large.png",
                    height = Customer.height,
                    trainer_TRID = Customer.trainer_TRID,
                    hidden = false,
                    jobDifficulty = Customer.jobDifficulty
                };

                db.customer.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddCustomer(CustomerDTO Customer, string userId)
        {
            try
            {
                var trainer = (from x in db.trainer
                               where x.ID == userId
                               select x).FirstOrDefault();
                var c = new customer
                {
                    CID = Customer.CID,
                    ID = Customer.ID,
                    name = Customer.name,
                    email = Customer.email,
                    phone = Customer.phone,
                    gender = Customer.gender,
                    kennitala = Customer.kennitala,
                    address = Customer.address,
                    foodPref = Customer.foodPref,
                    injury = Customer.injury,
                    allergy = Customer.allergy,
                    zipcodes_ZIP = Customer.zipcodes_ZIP,
                    profileImagePath = Customer.profileImagePath,
                    height = Customer.height,
                    trainer_TRID = trainer.TRID,
                    hidden = Customer.hidden,
                    jobDifficulty = Customer.jobDifficulty
                };

                db.customer.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}