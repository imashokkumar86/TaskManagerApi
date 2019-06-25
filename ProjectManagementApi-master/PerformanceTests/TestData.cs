using Entities;
using System;
using System.Collections.Generic;
namespace PerformanceTests
{
    static class TestData
    {
       
     
        public static IList<TaskDetail> GetTasks()
        {
            return new List<TaskDetail>()
            {
               new TaskDetail() {Id = 112,  Name ="Initial Design of Project Management API", StartDate=new DateTime(2018,11,1),EndDate=new DateTime(2019,12,1),ActiveStatus=false, Priority = 2},
               new TaskDetail() {Id = 113,  Name ="NUNIT TESTS",StartDate=new DateTime(2018,11,1),EndDate=new DateTime(2019,12,1),ActiveStatus=true, Priority = 3},
               new TaskDetail() {Id = 114,  Name ="DATABASE DESING",StartDate=new DateTime(2018,11,1),EndDate=new DateTime(2019,12,1),ActiveStatus=true, Priority = 10},
               new TaskDetail() {Id = 115,  Name ="TASK 99",StartDate=new DateTime(2018,11,1),EndDate=new DateTime(2019,12,1),ActiveStatus=false, Priority = 4},
            };

        }
        public static IList<ParentTaskDetails> GetParentTaskDetails()
        {
            return new List<ParentTaskDetails>()
            {
                  new ParentTaskDetails() {ParentId = 112,   ParentTask ="Initial Design of Project Management API" },
                  new ParentTaskDetails() {ParentId = 112,   ParentTask ="DATABASE DESING" }
            };
        }
    }
}
