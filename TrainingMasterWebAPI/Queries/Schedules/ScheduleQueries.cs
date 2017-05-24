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

        public Schedule getScheduleForTrainee(string UserID)
        {
            Schedule schedule = new Schedule();

            if (UserID != null)
            {
              int s =  getProgram(UserID);
              List<FoodProgramPortionDTO> li = getProgramPortion(s);
                for (int i = 0; i < li.Count; i++)
                {
                    Day day = new Day();
                    day.weekday = li[i].weekDay;
                    List<FoodPortionDTO> portions = getPortion(li[i].foodPortion_FPID);
                    for (int j = 0; j < portions.Count; j++)
                    {
                        Meal meal = new Meal();
                        FoodItemDTO item = getFoodItem(portions[j].foodItem_FIID);
                        meal.food.Add(item);
                        meal.time = li[i].timeOfDay.ToString();
                        day.meal.Add(meal);
                    }
                    schedule.day.Add(day);
                }
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
        public List<FoodProgramPortionDTO> getProgramPortion(int id)
        {
            var item = (from x in db.foodProgramPortion
                        where id == x.foodProgram_FPMID
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
        public Schedule(Day day)
        {
            this.day.Add(day);
        }
    }
    public class Day
    {
        public int weekday { get; set; }
        public List<Meal> meal { get; set; }
        public string time { get; set; }
        public Day() { }
        public Day(string time,Meal meal, int weekday)
        {
            this.time = time;
            this.meal.Add(meal);
            this.weekday = weekday;
        }
    }
    public class Meal 
    {
        public string time { get; set; }
        public List<FoodItemDTO> food { get; set; }
        public Meal() { }
        public Meal(string time, FoodItemDTO food)
        {
            this.food.Add(food);
        }
    }
}

