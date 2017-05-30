using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingMasterWebAPI.Models.EF;
using TrainingMasterWebAPI.Models.DTO;

namespace TrainingMasterWebAPI.Queries.Schedules
{
    public class ScheduleQueries
    {
        private TMEntities db;

        public ScheduleQueries()
        {
            db = new TMEntities();
        }
        public TrainingSchedule getUserid(string UserId, int[] days)
        {
            int id = FindCid(UserId);
            id = (int)FindProgram(id);
            id = GetTrainingProgram(id);
            List<TD> td = getWeekday(id, days);
            TrainingSchedule ts = new TrainingSchedule();
            ts.list = td;
            return ts;
        }
        public List<TD> getWeekday(int id, int[] days)
        {
            List<TD> tds = new List<TD>();
            for (int i = 0; i < days.Length; i++)
            {
                TD td = new TD();
                TrainingProgramTrainingDTO[] trainingDay = GetTrainingDay(id, days[i]);
                List<Training> ts = new List<Training>();
                for (int j = 0; j < trainingDay.Length; j++)
                {
                    
                    TrainingDTO training = GetTraining(trainingDay[j].training_TID);
                    Training t = new Training();
                    td.time = trainingDay[j].timeOfDay.ToString();
                    t.durationMin = training.durationMin.ToString();
                    t.reps = training.numberOfReps.ToString();
                    t.sets = training.numberOfReps.ToString();
                    t.restBetween = training.restBetweenMin.ToString();
                    t.exercise = GetExercise(training.exercise_EID);
                    ts.Add(t);
                }
                td.training = ts;
                tds.Add(td);
            }
            return tds;
        }
        public int FindCid(string id)
        {
            var obj = (from x in db.customer
                       where x.ID == id
                       select x.CID).SingleOrDefault();
            return obj;
        }
        public int? FindProgram(int id)
        {
            var obj = (from x in db.trainingProgramDate
                       where x.customer_CID == id
                       select x.trainingProgram_TPID).SingleOrDefault();
            return obj;
        }
        public int GetTrainingProgram(int id)
        {
            var obj = (from x in db.trainingProgram
                       where x.TPID == id
                       select x.TPID).SingleOrDefault();
            return obj;
        }
        public TrainingProgramTrainingDTO[] GetTrainingDay(int id, int weekday)
        {
            var day = (from x in db.trainingProgramTraining
                       where x.trainingProgram_TPID == id && weekday == x.weekday
                       select new TrainingProgramTrainingDTO
                       {
                          timeOfDay = x.timeOfDay,
                          training_TID = x.training_TID
                       });
            return day.ToArray();
        }
        public TrainingDTO GetTraining(int id)
        {
            var list = (from x in db.training
                        where x.TID == id
                        select new TrainingDTO
                        {
                            TID = x.TID,
                            durationMin = x.durationMin,
                            exercise_EID = x.exercise_EID,
                            numberOfReps = x.numberOfReps,
                            numberOfSets = x.numberOfSets,
                            restBetweenMin = x.restBetweenMin
                        }
                        ).SingleOrDefault();
            return list;
        }

        public Exercise GetExercise(int? id)
        {
            var ex = (from x in db.exercise
                      where x.EID == id
                      select new Exercise
                      {
                          name = x.name,
                          description = x.description,
                          link = x.link,
                          type = x.type
                      }).SingleOrDefault();
            return ex;
        }
        public class TrainingSchedule
        {
            public List<TD> list { get; set; }
            public TrainingSchedule()
            {
                
            }
            public TrainingSchedule(List<TD> list)
            {
                this.list = list;
            }
        }
        public class Exercise
        {
            public string name { get; set; }
            public string description { get; set; }
            public string link { get; set; }
            public string type { get; set; }
            public Exercise() { }
            public Exercise(string name, string description,string link, string type) {
                this.name = name;
                this.type = type;
                this.link = link;
                this.description = description;
            }
        }
        public class Training
        {
            public Exercise exercise { get; set; }
            public string reps { get; set; }
            public string sets { get; set; }
            public string durationMin { get; set; }
            public string restBetween { get; set; }
            public Training() { }
            public Training(Exercise exercise, string reps, string sets,string durationMin, string restBetween)
            {
                this.exercise = exercise;
                this.reps = reps;
                this.sets = sets;
                this.durationMin = durationMin;
                this.restBetween = restBetween;
            }
        } 
        public class TD
        {
            public List<Training> training { get; set; }
            public string day { get; set; }
            public string time { get; set; }
            public string duration { get; set; }
            public TD() { }
            public TD(List<Training> training, string day, string time) {
                this.training = training;
                this.day = day;
                this.time = time;
            }
        }
        public Schedule getScheduleForTrainee(string UserID)
        {
            Schedule schedule = new Schedule();
            if (UserID != null)
            {
                List<Day> days = new List<Day>();
                int s =  getProgram(UserID);
                for (int d = 0; d < 7; d++)
                {
                    List<FoodProgramPortionDTO> li = getProgramPortion(s,d);
                    Day day = new Day();
                    day.weekday = d;
                    List < Meal > meals = new List<Meal>();
                    for (int i = 0; i < li.Count; i++)
                {

                     
                        List<FoodPortionDTO> portions = getPortion(li[i].foodPortion_FPID);
                      
                    for (int j = 0; j < portions.Count; j++)
                    {
                        Meal meal = new Meal();
                        FoodItemDTO item = getFoodItem(portions[j].foodItem_FIID);
                            meal.food = item;
                        meal.time = li[j].timeOfDay.ToString();
                            meals.Add(meal);
                    }
                        day.meal = meals;
                }
                    days.Add(day);
                }
                schedule.day = days;
                return schedule;
            }
            return schedule;
              
        }
        public int getProgram( string UserId)
        {
            var cid = (from y in db.customer
                      where y.ID == UserId
                      select y.CID).SingleOrDefault();
            var list = (from x in db.foodProgramDate
                        where x.customer_CID == cid
                        select x.customer_CID).SingleOrDefault();
           
            return (int)list;
        }
        public FoodItemDTO getFoodItem(int id)
        {
            var item = (from x in db.foodItem
                        where id == x.FIID
                        select new FoodItemDTO
                        {
                            name = x.name,
                            kcal = x.kcal,
                            fat = x.fat,
                            saturatedFat = x.saturatedFat,
                            unsaturatedFat = x.unsaturatedFat,
                            colestrol = x.colestrol,
                            carbohydrate = x.carbohydrate,
                            addedSugar = x.addedSugar,
                            fiber = x.fiber,
                            water = x.water,
                            protein = x.protein,
                            suppliment = x.suppliment
                        }).SingleOrDefault();
            return item;
        }
        public List<FoodPortionDTO> getPortion(int id)
        {
            var item = (from x in db.foodPortion
                        where id == x.FPID
                        select new FoodPortionDTO
                        {
                            quantity = x.quantity,
                            foodItem_FIID = x.foodItem_FIID
                        });
            return item.ToList();
        }
        public List<FoodProgramPortionDTO> getProgramPortion(int id, int weekday)
        {
            var item = (from x in db.foodProgramPortion
                        where id == x.foodProgram_FPMID && x.weekday == weekday
                        select new FoodProgramPortionDTO
                        {
                            weekDay = x.weekday,
                            timeOfDay = x.timeOfDay,
                            foodPortion_FPID = x.foodPortion_FPID

                        });
            return item.ToList();
        }

    }
    public class Schedule
    {
        public List<Day> day { get; set; }
        public Schedule() { }
        public Schedule(List<Day> day)
        {
            this.day = day;
        }
    }
    public class Day
    {
        public int weekday { get; set; }
        public List<Meal> meal { get; set; }
        public Day() { }
        public Day( List<Meal> meal, int weekday)
        {
            this.meal = meal;
            this.weekday = weekday;
        }
    }
    public class Meal 
    {
        public string time { get; set; }
        public FoodItemDTO food { get; set; }
        public Meal() { }
        public Meal(string time, FoodItemDTO food)
        {
            this.food=food;
        }
    }
}

