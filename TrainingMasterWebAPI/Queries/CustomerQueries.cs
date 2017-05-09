using System;
using System.Collections.Generic;
using System.Linq;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

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
                                hidden = x.hidden
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
                                 hidden = x.hidden
                             });
            return customers;
        }

        public bool UpdateCustomer(CustomerDTO customer)
        {
            try
            {
                var c = (from x in db.customer
                         where customer.CID == x.CID
                         select x).SingleOrDefault();

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
                c.profileImagePath = customer.profileImagePath;
                c.height = customer.height;
                c.trainer_TRID = customer.trainer_TRID;
                c.hidden = customer.hidden;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddCustomer(CustomerDTO Customer)
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
                    profileImagePath = Customer.profileImagePath,
                    height = Customer.height,
                    trainer_TRID = Customer.trainer_TRID,
                    hidden = Customer.hidden
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