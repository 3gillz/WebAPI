﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class TrainerQueries
    {
        private TMEntities db;
        public TrainerQueries()
        {
            db = new TMEntities();
        }
        public IEnumerable<TrainerDTO> GetAllTrainers()
        {
            var t = (from x in db.trainer
                     select new TrainerDTO
                     {
                         TRID = x.TRID,
                         name = x.name,
                         email = x.email,
                         phone = x.phone,
                         kennitala = x.kennitala,
                         gender = x.gender,
                         address = x.address,
                         profileImagePath = x.profileImagePath,
                         location = x.location,
                         hidden = x.hidden
                     });
            return t;
        }

        public TrainerDTO GetTrainerByTRID(int id)
        {
            var t = (from x in db.trainer
                     where x.TRID == id
                     select new TrainerDTO
                     {
                         TRID = x.TRID,
                         name = x.name,
                         email = x.email,
                         phone = x.phone,
                         kennitala = x.kennitala,
                         gender = x.gender,
                         address = x.address,
                         profileImagePath = x.profileImagePath,
                         location = x.location,
                         hidden = x.hidden
                     }).SingleOrDefault();
            return t;
        }
        
        public TrainerDTO GetTrainerCardByTRID(int id)
        {
            var t = (from x in db.trainer
                     where x.TRID == id
                     select new TrainerDTO
                     {
                         TRID = x.TRID,
                         name = x.name,
                         email = x.email,
                         phone = null,
                         kennitala = null,
                         gender = x.gender,
                         address = null,
                         profileImagePath = x.profileImagePath,
                         location = x.location,
                         hidden = null
                     }).SingleOrDefault();
            return t;
        }

        public TrainerDTO GetTrainerById(string id)
        {
            var t = (from x in db.trainer
                     where x.ID == id
                     select new TrainerDTO
                     {
                         TRID = x.TRID,
                         name = x.name,
                         email = x.email,
                         phone = x.phone,
                         kennitala = x.kennitala,
                         gender = x.gender,
                         address = x.address,
                         profileImagePath = x.profileImagePath,
                         location = x.location,
                         hidden = x.hidden
                     }).SingleOrDefault();
            return t;
        }

        public TrainerDTO GetCurrentTrainer(string id)
        {
            var t = (from x in db.trainer
                     where x.ID == id
                     select new TrainerDTO
                     {
                         TRID = x.TRID,
                         name = x.name,
                         email = x.email,
                         phone = x.phone,
                         kennitala = x.kennitala,
                         gender = x.gender,
                         address = x.address,
                         location = x.location,
                         hidden = x.hidden,
                         profileImagePath = x.profileImagePath
                     }).SingleOrDefault();
            return t;
        }

        public bool RegisterTrainer(TrainerDTO Trainer)
        {
            AspNetUsers user = db.AspNetUsers.FirstOrDefault(x => x.Id == Trainer.ID);
            trainer tr = db.trainer.FirstOrDefault(x => x.ID == Trainer.ID);
            if(user == null || tr != null) 
            {
                return false;
            }
            try
            {
                var t = new trainer
                {
                    TRID = Trainer.TRID,
                    ID = Trainer.ID,
                    name = Trainer.name,
                    email = Trainer.email,
                    phone = Trainer.phone,
                    kennitala = Trainer.kennitala,
                    gender = Trainer.gender,
                    address = Trainer.address,
                    location = Trainer.location,
                    profileImagePath = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Profile_avatar_placeholder_large.png",
                    hidden = false
                };
                db.trainer.Add(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddTrainer(TrainerDTO Trainer)
        {
            try
            {
                var t = new trainer
                {
                    TRID = Trainer.TRID,
                    name = Trainer.name,
                    email = Trainer.email,
                    phone = Trainer.phone,
                    kennitala = Trainer.kennitala,
                    gender = Trainer.gender,
                    address = Trainer.address,
                    profileImagePath =Trainer.profileImagePath,
                    location = Trainer.location,
                    hidden = Trainer.hidden
                };
                db.trainer.Add(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool UpdateTrainer(TrainerDTO Trainer)
        {
            try
            {
                var t = (from x in db.trainer
                         where x.TRID == Trainer.TRID
                         select x).SingleOrDefault();

                t.TRID = Trainer.TRID;
                t.name = Trainer.name;
                t.email = Trainer.email;
                t.phone = Trainer.phone;
                t.kennitala = Trainer.kennitala;
                t.gender = Trainer.gender;
                t.address = Trainer.address;
                t.profileImagePath = Trainer.profileImagePath;
                t.location = Trainer.location;
                t.hidden = Trainer.hidden;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}