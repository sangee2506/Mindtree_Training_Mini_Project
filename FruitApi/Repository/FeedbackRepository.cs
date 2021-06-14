using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Repository
{
    public class FeedbackRepository
    {
        private readonly FruitVendorContext db = null;
        public FeedbackRepository()
        {
            db = new FruitVendorContext();
        }

        public List<Feedback> GetAllFeedback()
        {
            return db.Feedbacks.ToList();
        }
        public bool CreateFeedback(Feedback obj)
        {
            if (obj != null)
            {
                db.Feedbacks.Add(obj);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Feedback> GetAllDataById(int userId)
        {
            List<Feedback> feedbackList = db.Feedbacks.ToList();
            List<Feedback> res = new List<Feedback>();
            foreach(Feedback feedback in feedbackList)
            {
                if (feedback.UserId==userId)
                {
                    res.Add(feedback);
                }
            }
            return res;
        }
    }
}
