using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.DTO;
using TrainingMasterWebAPI.Models.EF;

namespace TrainingMasterWebAPI.Queries
{
    public class GoalsQueries
    {
        private TMEntities db;
        public GoalsQueries()
        {
            db = new TMEntities();
        }

        public IEnumerable<GoalsDTO> GetAllGoals()
        {
            var g = (from x in db.goals
                            select new GoalsDTO
                            {
                                GID = x.GID,
                                customer_CID = x.customer_CID,
                                kg = x.kg,
                                percentage = x.percentage,
                                description = x.description,
                                diameter = x.diameter,
                                startDate = x.startDate, 
                                dueDate = x.dueDate
                            });
            return g;
        }

        public GoalsDTO GetGoalById(int id)
        {
            var g = (from x in db.goals
                            where x.GID == id
                            select new GoalsDTO
                            {
                                GID = x.GID,
                                customer_CID = x.customer_CID,
                                kg = x.kg,
                                percentage = x.percentage,
                                description = x.description,
                                diameter = x.diameter,
                                startDate = x.startDate,
                                dueDate = x.dueDate
                            }).SingleOrDefault();
            return g;
        }

        public bool AddGoal(GoalsDTO Goals)
        {
            try
            {
                var g = new goals
                {
                    GID = Goals.GID,
                    customer_CID = Goals.customer_CID,
                    kg = Goals.kg,
                    percentage = Goals.percentage,
                    description = Goals.description,
                    diameter = Goals.diameter,
                    startDate = Goals.startDate,
                    dueDate = Goals.dueDate
                };
                db.goals.Add(g);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateGoal(GoalsDTO Goals)
        {
            try
            {
                var g = (from x in db.goals
                                where x.GID == Goals.GID
                                select x).SingleOrDefault();

                g.GID = Goals.GID;
                g.customer_CID = Goals.customer_CID;
                g.kg = Goals.kg;
                g.percentage = Goals.percentage;
                g.description = Goals.description;
                g.diameter = Goals.diameter;
                g.startDate = Goals.startDate;
                g.dueDate = Goals.dueDate;

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